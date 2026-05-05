using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array CITY (Cities)
	/// </summary>
	public class ArrayCity : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayCity _instance = new ArrayCity();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayCity Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Lisboa
		/// </summary>
		public const string E_LS_1 = "LS";
		/// <summary>
		/// Cascais
		/// </summary>
		public const string E_CS_2 = "CS";
		/// <summary>
		/// Porto
		/// </summary>
		public const string E_PO_3 = "PO";
		/// <summary>
		/// Guimarães
		/// </summary>
		public const string E_GM_4 = "GM";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayCity"/> class from being created.
		/// </summary>
		private ArrayCity() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_LS_1, new ArrayElement() { ResourceId = "LISBOA65493", HelpId = "", Group = "" } },
				{ E_CS_2, new ArrayElement() { ResourceId = "CASCAIS37276", HelpId = "", Group = "" } },
				{ E_PO_3, new ArrayElement() { ResourceId = "PORTO56181", HelpId = "", Group = "" } },
				{ E_GM_4, new ArrayElement() { ResourceId = "GUIMARAES11953", HelpId = "", Group = "" } },
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
