using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array AssetTyp (Asset type)
	/// </summary>
	public class ArrayAssettyp : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAssettyp _instance = new ArrayAssettyp();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAssettyp Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Equipment
		/// </summary>
		public const string E_E_1 = "E";
		/// <summary>
		/// Commodity
		/// </summary>
		public const string E_C_2 = "C";
		/// <summary>
		/// Building
		/// </summary>
		public const string E_B_3 = "B";
		/// <summary>
		/// Land
		/// </summary>
		public const string E_L_4 = "L";
		/// <summary>
		/// Office supplies
		/// </summary>
		public const string E_O_5 = "O";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAssettyp"/> class from being created.
		/// </summary>
		private ArrayAssettyp() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_E_1, new ArrayElement() { ResourceId = "EQUIPMENT03632", HelpId = "", Group = "" } },
				{ E_C_2, new ArrayElement() { ResourceId = "COMMODITY03939", HelpId = "", Group = "" } },
				{ E_B_3, new ArrayElement() { ResourceId = "BUILDING13586", HelpId = "", Group = "" } },
				{ E_L_4, new ArrayElement() { ResourceId = "LAND27818", HelpId = "", Group = "" } },
				{ E_O_5, new ArrayElement() { ResourceId = "OFFICE_SUPPLIES00254", HelpId = "", Group = "" } },
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
