using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array a_categ ()
	/// </summary>
	public class ArrayA_categ : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayA_categ _instance = new ArrayA_categ();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayA_categ Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Global
		/// </summary>
		public const string E_G_1 = "G";
		/// <summary>
		/// Nacional
		/// </summary>
		public const string E_N_2 = "N";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayA_categ"/> class from being created.
		/// </summary>
		private ArrayA_categ() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_G_1, new ArrayElement() { ResourceId = "GLOBAL58588", HelpId = "", Group = "" } },
				{ E_N_2, new ArrayElement() { ResourceId = "NACIONAL39968", HelpId = "", Group = "" } },
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
