using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Months (Month)
	/// </summary>
	public class ArrayMonths : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayMonths _instance = new ArrayMonths();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayMonths Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// January
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// February
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// March
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// April
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// May
		/// </summary>
		public const decimal E_5_5 = 5M;
		/// <summary>
		/// June
		/// </summary>
		public const decimal E_6_6 = 6M;
		/// <summary>
		/// July
		/// </summary>
		public const decimal E_7_7 = 7M;
		/// <summary>
		/// August
		/// </summary>
		public const decimal E_8_8 = 8M;
		/// <summary>
		/// September
		/// </summary>
		public const decimal E_9_9 = 9M;
		/// <summary>
		/// October
		/// </summary>
		public const decimal E_10_10 = 10M;
		/// <summary>
		/// November
		/// </summary>
		public const decimal E_11_11 = 11M;
		/// <summary>
		/// December
		/// </summary>
		public const decimal E_12_12 = 12M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayMonths"/> class from being created.
		/// </summary>
		private ArrayMonths() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "JANUARY26193", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "FEBRUARY35476", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "MARCH41748", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "APRIL13388", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "MAY55681", HelpId = "", Group = "" } },
				{ E_6_6, new ArrayElement() { ResourceId = "JUNE07845", HelpId = "", Group = "" } },
				{ E_7_7, new ArrayElement() { ResourceId = "JULY41219", HelpId = "", Group = "" } },
				{ E_8_8, new ArrayElement() { ResourceId = "AUGUST15687", HelpId = "", Group = "" } },
				{ E_9_9, new ArrayElement() { ResourceId = "SEPTEMBER29714", HelpId = "", Group = "" } },
				{ E_10_10, new ArrayElement() { ResourceId = "OCTOBER62709", HelpId = "", Group = "" } },
				{ E_11_11, new ArrayElement() { ResourceId = "NOVEMBER01178", HelpId = "", Group = "" } },
				{ E_12_12, new ArrayElement() { ResourceId = "DECEMBER43699", HelpId = "", Group = "" } },
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
