using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array SERVICETYPE (Service type)
	/// </summary>
	public class ArrayServicetype : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayServicetype _instance = new ArrayServicetype();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayServicetype Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Customer service
		/// </summary>
		public const string E_A_1 = "A";
		/// <summary>
		/// Platform performance
		/// </summary>
		public const string E_B_2 = "B";
		/// <summary>
		/// Other
		/// </summary>
		public const string E_C_3 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayServicetype"/> class from being created.
		/// </summary>
		private ArrayServicetype() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_A_1, new ArrayElement() { ResourceId = "CUSTOMER_SERVICE44538", HelpId = "", Group = "" } },
				{ E_B_2, new ArrayElement() { ResourceId = "PLATFORM_PERFORMANCE46169", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "OTHER37293", HelpId = "", Group = "" } },
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
