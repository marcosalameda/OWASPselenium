using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array atpacumu ()
	/// </summary>
	public class ArrayAtpacumu : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpacumu _instance = new ArrayAtpacumu();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpacumu Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Valor Único
		/// </summary>
		public const string E_U_1 = "U";
		/// <summary>
		/// Somatório
		/// </summary>
		public const string E_S_2 = "S";
		/// <summary>
		/// Average
		/// </summary>
		public const string E_M_3 = "M";
		/// <summary>
		/// Contagem
		/// </summary>
		public const string E_C_4 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpacumu"/> class from being created.
		/// </summary>
		private ArrayAtpacumu() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_U_1, new ArrayElement() { ResourceId = "VALOR_UNICO39183", HelpId = "", Group = "" } },
				{ E_S_2, new ArrayElement() { ResourceId = "SOMATORIO37638", HelpId = "", Group = "" } },
				{ E_M_3, new ArrayElement() { ResourceId = "AVERAGE50639", HelpId = "", Group = "" } },
				{ E_C_4, new ArrayElement() { ResourceId = "CONTAGEM11714", HelpId = "", Group = "" } },
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
