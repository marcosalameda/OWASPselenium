using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array FreqEmpr (Loan frequency)
	/// </summary>
	public class ArrayFreqempr : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayFreqempr _instance = new ArrayFreqempr();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayFreqempr Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Average
		/// </summary>
		public const decimal E_7_1 = 7M;
		/// <summary>
		/// High
		/// </summary>
		public const decimal E_1_2 = 1M;
		/// <summary>
		/// Low
		/// </summary>
		public const decimal E_15_3 = 15M;
		/// <summary>
		/// Rare
		/// </summary>
		public const decimal E_30_4 = 30M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayFreqempr"/> class from being created.
		/// </summary>
		private ArrayFreqempr() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_7_1, new ArrayElement() { ResourceId = "AVERAGE50639", HelpId = "___1040299", Group = "" } },
				{ E_1_2, new ArrayElement() { ResourceId = "HIGH47127", HelpId = "___1140948", Group = "" } },
				{ E_15_3, new ArrayElement() { ResourceId = "LOW09468", HelpId = "___1238797", Group = "" } },
				{ E_30_4, new ArrayElement() { ResourceId = "RARE54339", HelpId = "___1337918", Group = "" } },
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
