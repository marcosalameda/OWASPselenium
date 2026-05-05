using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array usefulfeedb (useful feedback)
	/// </summary>
	public class ArrayUsefulfeedb : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayUsefulfeedb _instance = new ArrayUsefulfeedb();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayUsefulfeedb Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Yes
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// No
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// Partially
		/// </summary>
		public const decimal E_3_3 = 3M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayUsefulfeedb"/> class from being created.
		/// </summary>
		private ArrayUsefulfeedb() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "YES34196", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "NO57340", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "PARTIALLY30150", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
