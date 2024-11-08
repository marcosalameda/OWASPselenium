using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array bankComp (Bank Company)
	/// </summary>
	public class ArrayBankcomp : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayBankcomp _instance = new ArrayBankcomp();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayBankcomp Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Santander
		/// </summary>
		public const string E_ST_1 = "ST";
		/// <summary>
		/// Caixa Bank
		/// </summary>
		public const string E_CB_2 = "CB";
		/// <summary>
		/// ING
		/// </summary>
		public const string E_IG_3 = "IG";
		/// <summary>
		/// Novobanco
		/// </summary>
		public const string E_NB_4 = "NB";
		/// <summary>
		/// ActivoBank
		/// </summary>
		public const string E_AB_5 = "AB";
		/// <summary>
		/// OpenBank
		/// </summary>
		public const string E_OB_6 = "OB";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayBankcomp"/> class from being created.
		/// </summary>
		private ArrayBankcomp() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_ST_1, new ArrayElement() { ResourceId = "SANTANDER27925", HelpId = "", Group = "" } },
				{ E_CB_2, new ArrayElement() { ResourceId = "CAIXA_BANK13668", HelpId = "", Group = "" } },
				{ E_IG_3, new ArrayElement() { ResourceId = "ING19160", HelpId = "", Group = "" } },
				{ E_NB_4, new ArrayElement() { ResourceId = "NOVOBANCO44101", HelpId = "", Group = "" } },
				{ E_AB_5, new ArrayElement() { ResourceId = "ACTIVOBANK40861", HelpId = "", Group = "" } },
				{ E_OB_6, new ArrayElement() { ResourceId = "OPENBANK20445", HelpId = "", Group = "" } },
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
