using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array atipoInd (Tipo de Indicador)
	/// </summary>
	public class ArrayAtipoind : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtipoind _instance = new ArrayAtipoind();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtipoind Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Impacto
		/// </summary>
		public const string E_IMPACT_1 = "IMPACT";
		/// <summary>
		/// Resultados
		/// </summary>
		public const string E_RESULT_2 = "RESULT";
		/// <summary>
		/// Processos
		/// </summary>
		public const string E_PROCES_3 = "PROCES";
		/// <summary>
		/// Produto
		/// </summary>
		public const string E_PRODU_4 = "PRODU";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtipoind"/> class from being created.
		/// </summary>
		private ArrayAtipoind() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_IMPACT_1, new ArrayElement() { ResourceId = "IMPACTO36269", HelpId = "", Group = "" } },
				{ E_RESULT_2, new ArrayElement() { ResourceId = "RESULTADOS20000", HelpId = "", Group = "" } },
				{ E_PROCES_3, new ArrayElement() { ResourceId = "PROCESSOS12945", HelpId = "", Group = "" } },
				{ E_PRODU_4, new ArrayElement() { ResourceId = "PRODUTO57112", HelpId = "", Group = "" } },
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
