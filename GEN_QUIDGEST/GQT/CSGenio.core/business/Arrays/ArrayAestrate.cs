using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aestrate ()
	/// </summary>
	public class ArrayAestrate : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAestrate _instance = new ArrayAestrate();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAestrate Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Produtividade
		/// </summary>
		public const string E_P_1 = "P";
		/// <summary>
		/// Crescimento
		/// </summary>
		public const string E_C_2 = "C";
		/// <summary>
		/// Prod. e Cresc.
		/// </summary>
		public const string E_A_3 = "A";
		/// <summary>
		/// N/A
		/// </summary>
		public const string E_N_4 = "N";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAestrate"/> class from being created.
		/// </summary>
		private ArrayAestrate() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_P_1, new ArrayElement() { ResourceId = "PRODUTIVIDADE55481", HelpId = "", Group = "" } },
				{ E_C_2, new ArrayElement() { ResourceId = "CRESCIMENTO17722", HelpId = "", Group = "" } },
				{ E_A_3, new ArrayElement() { ResourceId = "PROD__E_CRESC_35758", HelpId = "", Group = "" } },
				{ E_N_4, new ArrayElement() { ResourceId = "N_A00986", HelpId = "", Group = "" } },
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
