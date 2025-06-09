using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array SpaceTyp (Space type)
	/// </summary>
	public class ArraySpacetyp : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArraySpacetyp _instance = new ArraySpacetyp();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArraySpacetyp Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Floor
		/// </summary>
		public const string E_F_1 = "F";
		/// <summary>
		/// Room
		/// </summary>
		public const string E_R_2 = "R";
		/// <summary>
		/// Shelf
		/// </summary>
		public const string E_S_3 = "S";
		/// <summary>
		/// Yard
		/// </summary>
		public const string E_Y_4 = "Y";
		/// <summary>
		/// Another
		/// </summary>
		public const string E_A_5 = "A";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArraySpacetyp"/> class from being created.
		/// </summary>
		private ArraySpacetyp() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_F_1, new ArrayElement() { ResourceId = "FLOOR19993", HelpId = "", Group = "" } },
				{ E_R_2, new ArrayElement() { ResourceId = "ROOM50867", HelpId = "", Group = "" } },
				{ E_S_3, new ArrayElement() { ResourceId = "SHELF59898", HelpId = "", Group = "" } },
				{ E_Y_4, new ArrayElement() { ResourceId = "YARD38498", HelpId = "", Group = "" } },
				{ E_A_5, new ArrayElement() { ResourceId = "ANOTHER00311", HelpId = "", Group = "" } },
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
