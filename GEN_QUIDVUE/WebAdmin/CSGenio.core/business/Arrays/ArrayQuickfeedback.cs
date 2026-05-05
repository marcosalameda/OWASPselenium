using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array quickfeedback (quickfeedback)
	/// </summary>
	public class ArrayQuickfeedback : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayQuickfeedback _instance = new ArrayQuickfeedback();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayQuickfeedback Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// The information is hard to understand
		/// </summary>
		public const string E_A_1 = "A";
		/// <summary>
		/// Need more details
		/// </summary>
		public const string E_B_2 = "B";
		/// <summary>
		/// I can't find what I'm looking for
		/// </summary>
		public const string E_C_3 = "C";
		/// <summary>
		/// I'd like to have more information in my language
		/// </summary>
		public const string E_D_4 = "D";
		/// <summary>
		/// I have technical issues
		/// </summary>
		public const string E_E_5 = "E";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayQuickfeedback"/> class from being created.
		/// </summary>
		private ArrayQuickfeedback() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_A_1, new ArrayElement() { ResourceId = "THE_INFORMATION_IS_H08002", HelpId = "", Group = "" } },
				{ E_B_2, new ArrayElement() { ResourceId = "NEED_MORE_DETAILS27800", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "I_CAN_T_FIND_WHAT_I_33456", HelpId = "", Group = "" } },
				{ E_D_4, new ArrayElement() { ResourceId = "I_D_LIKE_TO_HAVE_MOR23763", HelpId = "", Group = "" } },
				{ E_E_5, new ArrayElement() { ResourceId = "I_HAVE_TECHNICAL_ISS49055", HelpId = "", Group = "" } },
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
