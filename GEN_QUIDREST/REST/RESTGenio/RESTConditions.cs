using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RESTGenio
{
    public enum ValueType
    {
        Int,
        Double,
        DateTime,
        Logic,
        String,
		Enum
    }
    public enum conditionType
    {
        Value,
        Field,
        Null,
        In,
        Set
    }

    public enum setConditionType
    {
        And,
        Or
    }
    public enum Operator
    {
        Equal,
        NotEqual,
        Like,
        LesserThan,
        LesserThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
    }

    [JsonConverter(typeof(ValueParser))]
    [SwaggerDiscriminator("valueType")]
    [SwaggerSubType(typeof(IntValue), DiscriminatorValue = "Int")]
    [SwaggerSubType(typeof(DoubleValue), DiscriminatorValue = "Double")]
    [SwaggerSubType(typeof(DateValue), DiscriminatorValue = "DateTime")]
    [SwaggerSubType(typeof(LogicValue), DiscriminatorValue = "Logic")]
    [SwaggerSubType(typeof(StringValue), DiscriminatorValue = "String")]
	[SwaggerSubType(typeof(EnumValue), DiscriminatorValue = "Enum")]
    public abstract class Value
    {
        public ValueType ValueType { get; set; }
        public abstract object GetValue();
    }
    public class IntValue : Value
    {
        public int Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
    public class DoubleValue : Value
    {
        public double Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
    public class DateValue : Value
    {
        public DateTime Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
    public class LogicValue : Value
    {
        public bool Value { get; set; }
        public override object GetValue()
        {
            return Value;
        }
    }
    public class StringValue : Value
    {
        public string Value { get; set; } = string.Empty;
        public override object GetValue()
        {
            return Value;
        }
    }
	
    public class EnumValue : Value
    {
        public string Array { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public override object GetValue()
        {
            //We are forced to use reflection here, because EnumMember is not working correctly in System.Text.Json
            //see: https://stackoverflow.com/questions/59059989/system-text-json-how-do-i-specify-a-custom-name-for-an-enum-value
            var t = Type.GetType("RESTGenio." + Array, true, true);
            if (t is null || !t.IsEnum )
                throw new Exception($"Array {Array} not found");
            var ord = System.Enum.Parse(t, Value);
            var m = typeof(RESTArrays).GetMethod($"Get{Array}IdByValue") ?? throw new Exception($"Array {Array} convertion method not found");
            var res = m.Invoke(null, new object[] { ord }) ?? throw new Exception($"Array {Array} convertion value {Value} resulted in null");
            return res;
        }
    }


    [JsonConverter(typeof(LogicalConditionParser))]
    [SwaggerDiscriminator("conditionType")]
    [SwaggerSubType(typeof(ValueComparison), DiscriminatorValue = "Value")]
    [SwaggerSubType(typeof(FieldComparison), DiscriminatorValue = "Field")]
    [SwaggerSubType(typeof(NullComparison), DiscriminatorValue = "Null")]
    [SwaggerSubType(typeof(InComparison), DiscriminatorValue = "In")]
    [SwaggerSubType(typeof(SetCondition), DiscriminatorValue = "Set")]
    public abstract class LogicalCondition
    {
        public conditionType ConditionType { get; set; }
        public abstract CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap);
    }


    /// <summary>
    /// Conjunction or disjuntion of other conditions
    /// </summary>
    public class SetCondition : LogicalCondition
    {
        /// <summary>
        /// Type of conjuntion
        /// </summary>
        [Required]
        public setConditionType SetConditionType { get; set; }

        /// <summary>
        /// List of conditions that make up the conjuntion
        /// </summary>
        [Required]
        public List<LogicalCondition> Conditions { get; set; } = new List<LogicalCondition>();

        /// <summary>
        /// Converts this condition to its corresponding criteria set
        /// </summary>
        /// <param name="fieldMap">Maps of the field string descriptions to their corresponding FieldRef</param>
        /// <returns>The resulting CriteriaSet</returns>
        public override CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap)
        {
            CriteriaSet result = SetConditionType switch
            {
                setConditionType.And => CriteriaSet.And(),
                setConditionType.Or => CriteriaSet.Or(),
                _ => throw new Exception("Invalid set condition type"),
            };
            foreach (LogicalCondition condition in Conditions)
                result.SubSet(condition.ToCriteriaSet(fieldMap));

            return result;
        }
    }

    public static class OperatorExtensions
    {
        public static CriteriaSet OperatorToCriteriaSet(this Operator op, FieldRef field, object value)
        {
            CriteriaSet result = CriteriaSet.And();
            result = op switch
            {
                Operator.Equal => result.Equal(field, value),
                Operator.NotEqual => result.NotEqual(field, value),
                Operator.Like => result.Like(field, value),
                Operator.LesserThan => result.Lesser(field, value),
                Operator.LesserThanOrEqual => result.LesserOrEqual(field, value),
                Operator.GreaterThan => result.Greater(field, value),
                Operator.GreaterThanOrEqual => result.GreaterOrEqual(field, value),
                _ => throw new Exception("Invalid operator type"),
            };
            return result;
        }
    }


    /// <summary>
    /// Compares a field with a value
    /// </summary>
    public class ValueComparison : LogicalCondition
    {
		/// <summary>
        /// Field reference
        /// </summary>
        /// <example>fieldName</example>
		[Required]
        public string Field { get; set; } = string.Empty;
		[Required]
        public Operator Operator { get; set; }
        public Value? Value { get; set; }
        public override CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap)
        {
            FieldRef field = fieldMap[Field.ToUpper()] ?? throw new Exception("Invalid field : " + Field);
            object value = Value?.GetValue() ?? throw new Exception("Value cannot be null");
            return Operator.OperatorToCriteriaSet(field, value);
        }
    }
    /// <summary>
    /// Evaluates a field for null state
    /// </summary>
    public class NullComparison : LogicalCondition
    {
		/// <summary>
        /// Field reference
        /// </summary>
        /// <example>fieldName</example>
		[Required]
        public string Field { get; set; } = string.Empty;
        public bool IsNull { get; set; } = true;
        public override CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap)
        {
            CriteriaSet criteria = CriteriaSet.And();

            FieldRef field = fieldMap[Field.ToUpper()] ?? throw new Exception("Invalid field : " + Field);
            if (IsNull)
                criteria.Equal(field, null);
            else
                criteria.NotEqual(field, null);

            return criteria;
        }
    }
    /// <summary>
    /// Compares the values of two fields
    /// </summary>
    public class FieldComparison : LogicalCondition
    {
		/// <summary>
        /// Lefthand field reference
        /// </summary>
        /// <example>fieldName</example>
		[Required]
        public string LeftField { get; set; } = string.Empty;
		[Required]
        public Operator Operator { get; set; }
		/// <summary>
        /// Righthand field reference
        /// </summary>
        /// <example>fieldName</example>
		[Required]
        public string RightField { get; set; } = string.Empty;
        public override CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap)
        {
            FieldRef field1 = fieldMap[LeftField.ToUpper()] ?? throw new Exception("Invalid field : " + LeftField);
            FieldRef field2 = fieldMap[RightField.ToUpper()] ?? throw new Exception("Invalid field : " + RightField);
            return Operator.OperatorToCriteriaSet(field1, field2);
        }
    }
    /// <summary>
    /// Compares a field with a list of values
    /// </summary>
    public class InComparison : LogicalCondition
    {
		/// <summary>
        /// Field reference
        /// </summary>
        /// <example>fieldName</example>
		[Required]
        public string Field { get; set; } = string.Empty;
        public bool In { get; set; } = true;
		[Required]
        public List<Value> Values { get; set; } = new List<Value>();
        public override CriteriaSet ToCriteriaSet(Dictionary<string, FieldRef> fieldMap)
        {
            CriteriaSet criteria = CriteriaSet.And();

            FieldRef field = fieldMap[Field.ToUpper()] ?? throw new Exception("Invalid field : " + Field);
            if (Values.Count == 0)
                throw new Exception("In clause list cannot be empty");

            List<object> values = Values.Select(x => x.GetValue()).ToList();

            if (In)
                criteria.In(field, values);
            else
                criteria.NotIn(field, values);

            return criteria;
        }
    }
   
    public class LogicalConditionParser : JsonConverter<LogicalCondition>
    {
        public override LogicalCondition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument document = JsonDocument.ParseValue(ref reader);

            var c = document.RootElement.GetProperty("conditionType").GetString();
            LogicalCondition? logicalCondition = c switch
            {
                "Set" => JsonSerializer.Deserialize<SetCondition>(document, options),
                "Value" => JsonSerializer.Deserialize<ValueComparison>(document, options),
                "Field" => JsonSerializer.Deserialize<FieldComparison>(document, options),
                "Null" => JsonSerializer.Deserialize<NullComparison>(document, options),
                "In" => JsonSerializer.Deserialize<InComparison>(document, options),
                _ => null,
            };

            return logicalCondition ?? throw new JsonException("Invalid logical condition type");
        }
        public override void Write(Utf8JsonWriter writer, LogicalCondition value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public class ValueParser : JsonConverter<Value>
    {
        public override Value Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument document = JsonDocument.ParseValue(ref reader);

            var c = document.RootElement.GetProperty("valueType").GetString();
            Value? value = c switch
            {
                "Int" => JsonSerializer.Deserialize<IntValue>(document, options),
                "Double" => JsonSerializer.Deserialize<DoubleValue>(document, options),
                "DateTime" => JsonSerializer.Deserialize<DateValue>(document, options),
                "Logic" => JsonSerializer.Deserialize<LogicValue>(document, options),
                "String" => JsonSerializer.Deserialize<StringValue>(document, options),
                "Enum" => JsonSerializer.Deserialize<EnumValue>(document, options),
                _ => null,
            };

            return value ?? throw new JsonException("Invalid value type");
        }
        public override void Write(Utf8JsonWriter writer, Value value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
