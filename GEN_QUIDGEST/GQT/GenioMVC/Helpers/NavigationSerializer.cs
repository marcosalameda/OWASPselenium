using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;

namespace GenioMVC.Helpers
{
	public class NavigationSerializer
	{

        /// <summary>
        /// Temporary duplication of the namevalueSerializer until we fully switch to System.text.json
        /// </summary>
        public class NameValueCollectionSerializer2 : JsonConverter<NameValueCollection>
        {
            public override NameValueCollection ReadJson(JsonReader reader, Type objectType, NameValueCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                try
                {
                    var result = new NameValueCollection();
                    var jObj = JObject.Load(reader);
                    var dictionary = jObj?.ToObject<Dictionary<string, string[]>>();
                    if (dictionary != null)
                    {
                        foreach (var item in dictionary)
                            foreach (var itemValue in item.Value)
                                result.Add(item.Key, itemValue);
                    }
                    else return null;

                    return result;
                }
                catch
                {
                    return null;
                }
            }

            public override void WriteJson(JsonWriter writer, NameValueCollection value, JsonSerializer serializer)
            {
                var items = value?.AllKeys.ToDictionary(k => k, k => value.GetValues(k));

                JToken t = JToken.FromObject(items);
                t.WriteTo(writer);
            }
        }

		private sealed class QDefaultCreatorContractResolver : DefaultContractResolver
		{
			protected override JsonObjectContract CreateObjectContract(Type objectType)
			{
				var jContract = base.CreateObjectContract(objectType);
				var parameterlessConstructor = objectType.GetConstructor(Type.EmptyTypes);

				// One of the classes may not have the default constructor.(e.g: Quidgest.Persistence.GenericQuery.ColumnReference)
				if (parameterlessConstructor == null && jContract.DefaultCreator == null && !jContract.CreatorParameters.Any())
					jContract.DefaultCreator = () => FormatterServices.GetUninitializedObject(objectType);

				return jContract;
			}
		}

		public static string Serialize(object source)
		{
			if (Object.ReferenceEquals(source, null))
				throw new ArgumentNullException("source", "Error during Serialize (Navigation)");

			var serializeSettings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				TypeNameHandling = TypeNameHandling.All,
				Converters = {
					new NameValueCollectionSerializer2()
				}
			};

			return JsonConvert.SerializeObject(source, serializeSettings);
		}

		public static T Deserialize<T>(string source)
		{
			var deserializeSettings = new JsonSerializerSettings
			{
				ObjectCreationHandling = ObjectCreationHandling.Replace,
				TypeNameHandling = TypeNameHandling.All,
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
				ContractResolver = new QDefaultCreatorContractResolver(),
				Converters = {
					new NameValueCollectionSerializer2()
				}
			};

			return JsonConvert.DeserializeObject<T>(source, deserializeSettings);
		}
	}
}
