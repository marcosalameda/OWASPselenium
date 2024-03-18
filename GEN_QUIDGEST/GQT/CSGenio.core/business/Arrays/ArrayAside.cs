using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aSide (Lado)
	/// </summary>
	public class ArrayAside : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAside _instance = new ArrayAside();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAside Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Left
		/// </summary>
		public const string E_L_1 = "L";
		/// <summary>
		/// Right
		/// </summary>
		public const string E_R_2 = "R";
		/// <summary>
		/// Top
		/// </summary>
		public const string E_T_3 = "T";
		/// <summary>
		/// Bottom
		/// </summary>
		public const string E_B_4 = "B";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAside"/> class from being created.
		/// </summary>
		private ArrayAside() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_L_1, new ArrayElement() { ResourceId = "LEFT43751", HelpId = "", Group = "" } },
				{ E_R_2, new ArrayElement() { ResourceId = "RIGHT33051", HelpId = "", Group = "" } },
				{ E_T_3, new ArrayElement() { ResourceId = "TOP31303", HelpId = "", Group = "" } },
				{ E_B_4, new ArrayElement() { ResourceId = "BOTTOM53759", HelpId = "", Group = "" } },
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
