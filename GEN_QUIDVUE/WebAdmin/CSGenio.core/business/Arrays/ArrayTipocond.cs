using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array tipoCond (Tipo de condição)
	/// </summary>
	public class ArrayTipocond : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayTipocond _instance = new ArrayTipocond();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayTipocond Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Warning
		/// </summary>
		public const string E_W_1 = "W";
		/// <summary>
		/// Erro
		/// </summary>
		public const string E_E_2 = "E";
		/// <summary>
		/// Obrigatório
		/// </summary>
		public const string E_M_3 = "M";
		/// <summary>
		/// Inserir
		/// </summary>
		public const string E_I_4 = "I";
		/// <summary>
		/// Editar
		/// </summary>
		public const string E_U_5 = "U";
		/// <summary>
		/// Query
		/// </summary>
		public const string E_V_6 = "V";
		/// <summary>
		/// Delete
		/// </summary>
		public const string E_D_7 = "D";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayTipocond"/> class from being created.
		/// </summary>
		private ArrayTipocond() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_W_1, new ArrayElement() { ResourceId = "WARNING52043", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "ERRO38355", HelpId = "", Group = "" } },
				{ E_M_3, new ArrayElement() { ResourceId = "OBRIGATORIO46267", HelpId = "", Group = "" } },
				{ E_I_4, new ArrayElement() { ResourceId = "INSERIR43365", HelpId = "", Group = "" } },
				{ E_U_5, new ArrayElement() { ResourceId = "EDITAR11616", HelpId = "", Group = "" } },
				{ E_V_6, new ArrayElement() { ResourceId = "QUERY30986", HelpId = "", Group = "" } },
				{ E_D_7, new ArrayElement() { ResourceId = "DELETE48637", HelpId = "", Group = "" } },
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
