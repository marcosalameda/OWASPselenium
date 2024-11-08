using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array AddressU (Address Use)
	/// </summary>
	public class ArrayAddressu : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAddressu _instance = new ArrayAddressu();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAddressu Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Home
		/// </summary>
		public const string E_HOME_1 = "home";
		/// <summary>
		/// Work
		/// </summary>
		public const string E_WORK_2 = "work";
		/// <summary>
		/// Temporary
		/// </summary>
		public const string E_TEMP_3 = "temp";
		/// <summary>
		/// Old / Incorrect
		/// </summary>
		public const string E_OLD_4 = "old";
		/// <summary>
		/// Billing
		/// </summary>
		public const string E_BILLING_5 = "billing";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAddressu"/> class from being created.
		/// </summary>
		private ArrayAddressu() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_HOME_1, new ArrayElement() { ResourceId = "HOME23643", HelpId = "_108747561", Group = "" } },
				{ E_WORK_2, new ArrayElement() { ResourceId = "WORK50501", HelpId = "_108820200", Group = "" } },
				{ E_TEMP_3, new ArrayElement() { ResourceId = "TEMPORARY00792", HelpId = "_108919783", Group = "" } },
				{ E_OLD_4, new ArrayElement() { ResourceId = "OLD___INCORRECT09129", HelpId = "_109034838", Group = "" } },
				{ E_BILLING_5, new ArrayElement() { ResourceId = "BILLING63268", HelpId = "_109131109", Group = "" } },
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
