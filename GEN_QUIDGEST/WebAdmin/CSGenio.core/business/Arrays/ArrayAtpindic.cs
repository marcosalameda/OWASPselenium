using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aTpIndic ()
	/// </summary>
	public class ArrayAtpindic : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpindic _instance = new ArrayAtpindic();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpindic Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Qualidade
		/// </summary>
		public const string E_Q_1 = "Q";
		/// <summary>
		/// Eficiência
		/// </summary>
		public const string E_E_2 = "E";
		/// <summary>
		/// Eficácia
		/// </summary>
		public const string E_F_3 = "F";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpindic"/> class from being created.
		/// </summary>
		private ArrayAtpindic() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_Q_1, new ArrayElement() { ResourceId = "QUALIDADE42726", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "EFICIENCIA22805", HelpId = "", Group = "" } },
				{ E_F_3, new ArrayElement() { ResourceId = "EFICACIA33755", HelpId = "", Group = "" } },
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
