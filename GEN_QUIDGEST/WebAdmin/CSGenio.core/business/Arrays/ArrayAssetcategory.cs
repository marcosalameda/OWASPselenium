using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array assetCategory (Asset categories)
	/// </summary>
	public class ArrayAssetcategory : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAssetcategory _instance = new ArrayAssetcategory();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAssetcategory Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Real Estate
		/// </summary>
		public const string E_RE_1 = "RE";
		/// <summary>
		/// Vehicle
		/// </summary>
		public const string E_VCL_2 = "VCL";
		/// <summary>
		/// Equipment
		/// </summary>
		public const string E_EQUIP_3 = "EQUIP";
		/// <summary>
		/// Furniture
		/// </summary>
		public const string E_FNTR_4 = "FNTR";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAssetcategory"/> class from being created.
		/// </summary>
		private ArrayAssetcategory() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_RE_1, new ArrayElement() { ResourceId = "REAL_ESTATE07188", HelpId = "", Group = "" } },
				{ E_VCL_2, new ArrayElement() { ResourceId = "VEHICLE49593", HelpId = "", Group = "" } },
				{ E_EQUIP_3, new ArrayElement() { ResourceId = "EQUIPMENT03632", HelpId = "", Group = "" } },
				{ E_FNTR_4, new ArrayElement() { ResourceId = "FURNITURE42200", HelpId = "", Group = "" } },
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
