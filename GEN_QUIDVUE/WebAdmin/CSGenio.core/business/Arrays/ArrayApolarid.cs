using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array apolarid ()
	/// </summary>
	public class ArrayApolarid : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayApolarid _instance = new ArrayApolarid();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayApolarid Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Maior é Melhor
		/// </summary>
		public const string E_CR_1 = "CR";
		/// <summary>
		/// Menor é Melhor
		/// </summary>
		public const string E_DE_2 = "DE";
		/// <summary>
		/// Centrada
		/// </summary>
		public const string E_C_3 = "C";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayApolarid"/> class from being created.
		/// </summary>
		private ArrayApolarid() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_CR_1, new ArrayElement() { ResourceId = "MAIOR_E_MELHOR43422", HelpId = "", Group = "" } },
				{ E_DE_2, new ArrayElement() { ResourceId = "MENOR_E_MELHOR57832", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "CENTRADA33827", HelpId = "", Group = "" } },
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
