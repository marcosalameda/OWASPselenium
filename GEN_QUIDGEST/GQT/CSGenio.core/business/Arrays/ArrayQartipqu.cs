using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array QarTipQu ()
	/// </summary>
	public class ArrayQartipqu : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayQartipqu _instance = new ArrayQartipqu();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayQartipqu Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Não Conformidades
		/// </summary>
		public const string E_1_1 = "1";
		/// <summary>
		/// Reclamações
		/// </summary>
		public const string E_2_2 = "2";
		/// <summary>
		/// Acções Preventivas
		/// </summary>
		public const string E_3_3 = "3";
		/// <summary>
		/// Acções Correctivas
		/// </summary>
		public const string E_4_4 = "4";
		/// <summary>
		/// Acções de Melhoria
		/// </summary>
		public const string E_5_5 = "5";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayQartipqu"/> class from being created.
		/// </summary>
		private ArrayQartipqu() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "NAO_CONFORMIDADES28147", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "RECLAMACOES47951", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "ACCOES_PREVENTIVAS51089", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "ACCOES_CORRECTIVAS43681", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "ACCOES_DE_MELHORIA28491", HelpId = "", Group = "" } },
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
