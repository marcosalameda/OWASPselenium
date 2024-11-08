using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aCCustos (Afetação Contabilidade Custos)
	/// </summary>
	public class ArrayAccustos : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAccustos _instance = new ArrayAccustos();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAccustos Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Sim
		/// </summary>
		public const string E_S_1 = "S";
		/// <summary>
		/// Não
		/// </summary>
		public const string E_N_2 = "N";
		/// <summary>
		/// Não existe CC (contabilidade de custos)
		/// </summary>
		public const string E_C_3 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAccustos"/> class from being created.
		/// </summary>
		private ArrayAccustos() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_S_1, new ArrayElement() { ResourceId = "SIM28552", HelpId = "", Group = "" } },
				{ E_N_2, new ArrayElement() { ResourceId = "NAO06521", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "NAO_EXISTE_CC__CONTA42559", HelpId = "", Group = "" } },
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
