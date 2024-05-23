using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array GenConta (Contact type)
	/// </summary>
	public class ArrayGenconta : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayGenconta _instance = new ArrayGenconta();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayGenconta Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Phone
		/// </summary>
		public const string E_T_1 = "T";
		/// <summary>
		/// Email
		/// </summary>
		public const string E_E_2 = "E";
		/// <summary>
		/// Address
		/// </summary>
		public const string E_M_3 = "M";
		/// <summary>
		/// Other
		/// </summary>
		public const string E_O_4 = "O";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayGenconta"/> class from being created.
		/// </summary>
		private ArrayGenconta() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_T_1, new ArrayElement() { ResourceId = "PHONE56703", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "EMAIL25170", HelpId = "", Group = "" } },
				{ E_M_3, new ArrayElement() { ResourceId = "ADDRESS04342", HelpId = "", Group = "" } },
				{ E_O_4, new ArrayElement() { ResourceId = "OTHER37293", HelpId = "", Group = "" } },
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
