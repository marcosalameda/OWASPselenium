using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array componenticons (Components icon)
	/// </summary>
	public class ArrayComponenticons : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayComponenticons _instance = new ArrayComponenticons();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayComponenticons Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Data Input
		/// </summary>
		public const decimal E_2_1 = 2M;
		/// <summary>
		/// Data Display
		/// </summary>
		public const decimal E_6_2 = 6M;
		/// <summary>
		/// Data Grid
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// Action
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// Container
		/// </summary>
		public const decimal E_5_5 = 5M;
		/// <summary>
		/// Relational structure
		/// </summary>
		public const decimal E_8_6 = 8M;
		/// <summary>
		/// Interactive
		/// </summary>
		public const decimal E_7_7 = 7M;
		/// <summary>
		/// Media
		/// </summary>
		public const decimal E_1_8 = 1M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayComponenticons"/> class from being created.
		/// </summary>
		private ArrayComponenticons() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_2_1, new ArrayElement() { ResourceId = "DATA_INPUT23684", HelpId = "", Group = "" } },
				{ E_6_2, new ArrayElement() { ResourceId = "DATA_DISPLAY32113", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "DATA_GRID17400", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "ACTION41832", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "CONTAINER62757", HelpId = "", Group = "" } },
				{ E_8_6, new ArrayElement() { ResourceId = "RELATIONAL_STRUCTURE39801", HelpId = "", Group = "" } },
				{ E_7_7, new ArrayElement() { ResourceId = "INTERACTIVE04535", HelpId = "", Group = "" } },
				{ E_1_8, new ArrayElement() { ResourceId = "MEDIA07084", HelpId = "", Group = "" } },
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
