using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aRecolha ()
	/// </summary>
	public class ArrayArecolha : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayArecolha _instance = new ArrayArecolha();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayArecolha Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Utilização de dados administrativos
		/// </summary>
		public const string E_A_1 = "A";
		/// <summary>
		/// Recolha direta dos Dados
		/// </summary>
		public const string E_D_2 = "D";
		/// <summary>
		/// Conjunto de dados Estatísticos e administrativos
		/// </summary>
		public const string E_C_3 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayArecolha"/> class from being created.
		/// </summary>
		private ArrayArecolha() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_A_1, new ArrayElement() { ResourceId = "UTILIZACAO_DE_DADOS_26961", HelpId = "", Group = "" } },
				{ E_D_2, new ArrayElement() { ResourceId = "RECOLHA_DIRETA_DOS_D20088", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "CONJUNTO_DE_DADOS_ES36750", HelpId = "", Group = "" } },
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
