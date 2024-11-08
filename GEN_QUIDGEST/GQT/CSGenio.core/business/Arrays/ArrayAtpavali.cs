using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aTpAvali ()
	/// </summary>
	public class ArrayAtpavali : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpavali _instance = new ArrayAtpavali();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpavali Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Dirigentes e Funcionários
		/// </summary>
		public const string E_T_1 = "T";
		/// <summary>
		/// Dirigentes
		/// </summary>
		public const string E_D_2 = "D";
		/// <summary>
		/// Funcionários
		/// </summary>
		public const string E_F_3 = "F";
		/// <summary>
		/// Unidade Orgânica
		/// </summary>
		public const string E_O_4 = "O";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpavali"/> class from being created.
		/// </summary>
		private ArrayAtpavali() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_T_1, new ArrayElement() { ResourceId = "DIRIGENTES_E_FUNCION02178", HelpId = "", Group = "" } },
				{ E_D_2, new ArrayElement() { ResourceId = "DIRIGENTES24546", HelpId = "", Group = "" } },
				{ E_F_3, new ArrayElement() { ResourceId = "FUNCIONARIOS50597", HelpId = "", Group = "" } },
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
