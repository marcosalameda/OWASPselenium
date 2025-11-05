using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Genero (Genus)
	/// </summary>
	public class ArrayGenero : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayGenero _instance = new ArrayGenero();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayGenero Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Male
		/// </summary>
		public const string E_M_1 = "M";
		/// <summary>
		/// Female
		/// </summary>
		public const string E_F_2 = "F";
		/// <summary>
		/// Undifferentiated
		/// </summary>
		public const string E_I_3 = "I";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayGenero"/> class from being created.
		/// </summary>
		private ArrayGenero() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_M_1, new ArrayElement() { ResourceId = "MALE32397", HelpId = "____715057", Group = "" } },
				{ E_F_2, new ArrayElement() { ResourceId = "FEMALE46107", HelpId = "____821504", Group = "" } },
				{ E_I_3, new ArrayElement() { ResourceId = "UNDIFFERENTIATED28573", HelpId = "____921651", Group = "" } },
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
