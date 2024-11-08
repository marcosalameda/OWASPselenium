using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array phonepre (Phone prefix)
	/// </summary>
	public class ArrayPhonepre : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPhonepre _instance = new ArrayPhonepre();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPhonepre Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// +1
		/// </summary>
		public const string E_USA_1 = "USA";
		/// <summary>
		/// +34
		/// </summary>
		public const string E_ESP_2 = "ESP";
		/// <summary>
		/// +351
		/// </summary>
		public const string E_POR_3 = "POR";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPhonepre"/> class from being created.
		/// </summary>
		private ArrayPhonepre() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_USA_1, new ArrayElement() { ResourceId = "_100989", HelpId = "", Group = "" } },
				{ E_ESP_2, new ArrayElement() { ResourceId = "_3417988", HelpId = "", Group = "" } },
				{ E_POR_3, new ArrayElement() { ResourceId = "_35140328", HelpId = "", Group = "" } },
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
