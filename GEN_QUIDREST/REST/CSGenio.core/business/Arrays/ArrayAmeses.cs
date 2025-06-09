using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aMeses ()
	/// </summary>
	public class ArrayAmeses : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAmeses _instance = new ArrayAmeses();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAmeses Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Janeiro
		/// </summary>
		public const string E_1_1 = "1";
		/// <summary>
		/// Fevereiro
		/// </summary>
		public const string E_2_2 = "2";
		/// <summary>
		/// Março
		/// </summary>
		public const string E_3_3 = "3";
		/// <summary>
		/// Abril
		/// </summary>
		public const string E_4_4 = "4";
		/// <summary>
		/// Maio
		/// </summary>
		public const string E_5_5 = "5";
		/// <summary>
		/// Junho
		/// </summary>
		public const string E_6_6 = "6";
		/// <summary>
		/// Julho
		/// </summary>
		public const string E_7_7 = "7";
		/// <summary>
		/// Agosto
		/// </summary>
		public const string E_8_8 = "8";
		/// <summary>
		/// Setembro
		/// </summary>
		public const string E_9_9 = "9";
		/// <summary>
		/// Outubro
		/// </summary>
		public const string E_10_10 = "10";
		/// <summary>
		/// Novembro
		/// </summary>
		public const string E_11_11 = "11";
		/// <summary>
		/// Dezembro
		/// </summary>
		public const string E_12_12 = "12";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAmeses"/> class from being created.
		/// </summary>
		private ArrayAmeses() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "JANEIRO25316", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "FEVEREIRO25443", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "MARCO22234", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "ABRIL58220", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "MAIO10443", HelpId = "", Group = "" } },
				{ E_6_6, new ArrayElement() { ResourceId = "JUNHO15214", HelpId = "", Group = "" } },
				{ E_7_7, new ArrayElement() { ResourceId = "JULHO20764", HelpId = "", Group = "" } },
				{ E_8_8, new ArrayElement() { ResourceId = "AGOSTO05568", HelpId = "", Group = "" } },
				{ E_9_9, new ArrayElement() { ResourceId = "SETEMBRO19956", HelpId = "", Group = "" } },
				{ E_10_10, new ArrayElement() { ResourceId = "OUTUBRO17690", HelpId = "", Group = "" } },
				{ E_11_11, new ArrayElement() { ResourceId = "NOVEMBRO18614", HelpId = "", Group = "" } },
				{ E_12_12, new ArrayElement() { ResourceId = "DEZEMBRO01950", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
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
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
