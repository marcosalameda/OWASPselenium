using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array atipouo (Tipo de Unidade Org.)
	/// </summary>
	public class ArrayAtipouo : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtipouo _instance = new ArrayAtipouo();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtipouo Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Interno
		/// </summary>
		public const string E_I_1 = "I";
		/// <summary>
		/// Externo
		/// </summary>
		public const string E_E_2 = "E";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtipouo"/> class from being created.
		/// </summary>
		private ArrayAtipouo() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_I_1, new ArrayElement() { ResourceId = "INTERNO52273", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "EXTERNO12394", HelpId = "", Group = "" } },
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
