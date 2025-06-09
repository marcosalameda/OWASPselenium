using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array apriorid ()
	/// </summary>
	public class ArrayApriorid : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayApriorid _instance = new ArrayApriorid();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayApriorid Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// High
		/// </summary>
		public const string E_HIGH_1 = "HIGH";
		/// <summary>
		/// Average
		/// </summary>
		public const string E_MEDIUM_2 = "MEDIUM";
		/// <summary>
		/// Low
		/// </summary>
		public const string E_LOW_3 = "LOW";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayApriorid"/> class from being created.
		/// </summary>
		private ArrayApriorid() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_HIGH_1, new ArrayElement() { ResourceId = "HIGH47127", HelpId = "", Group = "" } },
				{ E_MEDIUM_2, new ArrayElement() { ResourceId = "AVERAGE50639", HelpId = "", Group = "" } },
				{ E_LOW_3, new ArrayElement() { ResourceId = "LOW09468", HelpId = "", Group = "" } },
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
