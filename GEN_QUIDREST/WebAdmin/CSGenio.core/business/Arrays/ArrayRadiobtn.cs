using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array RADIOBTN (Radio Button)
	/// </summary>
	public class ArrayRadiobtn : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayRadiobtn _instance = new ArrayRadiobtn();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayRadiobtn Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Radio
		/// </summary>
		public const string E_RADIO_1 = "Radio";
		/// <summary>
		/// Opção 2
		/// </summary>
		public const string E_OP2_2 = "op2";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayRadiobtn"/> class from being created.
		/// </summary>
		private ArrayRadiobtn() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_RADIO_1, new ArrayElement() { ResourceId = "RADIO44833", HelpId = "_112615498", Group = "" } },
				{ E_OP2_2, new ArrayElement() { ResourceId = "OPCAO_214220", HelpId = "_112514035", Group = "" } },
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
