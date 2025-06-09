using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aLocRegr (Local da regra)
	/// </summary>
	public class ArrayAlocregr : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAlocregr _instance = new ArrayAlocregr();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAlocregr Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Tabela
		/// </summary>
		public const string E_T_1 = "T";
		/// <summary>
		/// Form
		/// </summary>
		public const string E_F_2 = "F";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAlocregr"/> class from being created.
		/// </summary>
		private ArrayAlocregr() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_T_1, new ArrayElement() { ResourceId = "TABELA44049", HelpId = "", Group = "" } },
				{ E_F_2, new ArrayElement() { ResourceId = "FORM54242", HelpId = "", Group = "" } },
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
