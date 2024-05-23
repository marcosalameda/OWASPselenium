using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array a_facili ()
	/// </summary>
	public class ArrayA_facili : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayA_facili _instance = new ArrayA_facili();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayA_facili Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Factible
		/// </summary>
		public const string E_F_1 = "F";
		/// <summary>
		/// No Disponible
		/// </summary>
		public const string E_ND_2 = "ND";
		/// <summary>
		/// No Aplica
		/// </summary>
		public const string E_NA_3 = "NA";
		/// <summary>
		/// No Factible
		/// </summary>
		public const string E_NF_4 = "NF";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayA_facili"/> class from being created.
		/// </summary>
		private ArrayA_facili() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_F_1, new ArrayElement() { ResourceId = "FACTIBLE13061", HelpId = "", Group = "" } },
				{ E_ND_2, new ArrayElement() { ResourceId = "NO_DISPONIBLE08299", HelpId = "", Group = "" } },
				{ E_NA_3, new ArrayElement() { ResourceId = "NO_APLICA13087", HelpId = "", Group = "" } },
				{ E_NF_4, new ArrayElement() { ResourceId = "NO_FACTIBLE14448", HelpId = "", Group = "" } },
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
