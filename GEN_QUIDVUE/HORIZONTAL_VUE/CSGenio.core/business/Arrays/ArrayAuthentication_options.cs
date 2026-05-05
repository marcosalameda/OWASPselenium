using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array authentication_options (Authentication options)
	/// </summary>
	public class ArrayAuthentication_options : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAuthentication_options _instance = new ArrayAuthentication_options();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAuthentication_options Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Default
		/// </summary>
		public const string E_D_1 = "D";
		/// <summary>
		/// Light
		/// </summary>
		public const string E_L_2 = "L";
		/// <summary>
		/// Secondary
		/// </summary>
		public const string E_S_3 = "S";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAuthentication_options"/> class from being created.
		/// </summary>
		private ArrayAuthentication_options() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_D_1, new ArrayElement() { ResourceId = "DEFAULT10658", HelpId = "", Group = "" } },
				{ E_L_2, new ArrayElement() { ResourceId = "LIGHT29213", HelpId = "", Group = "" } },
				{ E_S_3, new ArrayElement() { ResourceId = "SECONDARY47548", HelpId = "", Group = "" } },
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
