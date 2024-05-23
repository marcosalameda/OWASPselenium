using System;

namespace Quidgest.Persistence.GenericQuery
{
    /// <summary>
    /// Represents a sql constant value
    /// </summary>
    /// <remarks>
    /// <!--
    /// Author: CX 2011.06.28
    /// Modified:
    /// Reviewed:
    /// -->
    /// </remarks>
    public class SqlValue : ISqlExpression
    {
        /// <summary>
        /// The value to use in the sql
        /// </summary>
        /// <remarks>
        /// <!--
        /// Author: CX 2011.06.28
        /// Modified:
        /// Reviewed:
        /// -->
        /// </remarks>
        public object Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value to use in the sql</param>
        /// <remarks>
        /// <!--
        /// Author: CX 2011.06.28
        /// Modified:
        /// Reviewed:
        /// -->
        /// </remarks>
        public SqlValue(object value)
        {
            Value = value;
        }

        public object Clone()
        {
            return new SqlValue(Value);
        }

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is SqlValue))
			{
				return false;
			}

			SqlValue other = (SqlValue)obj;

			return Object.Equals(this.Value, other.Value);
		}

		public override int GetHashCode()
		{
			return (Value == null ? 0 : Value.GetHashCode());
		}
    }
}
