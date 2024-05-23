using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array FacilTyp (Facility type)
	/// </summary>
	public class ArrayFaciltyp : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayFaciltyp _instance = new ArrayFaciltyp();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayFaciltyp Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Building
		/// </summary>
		public const string E_B_1 = "B";
		/// <summary>
		/// Container depot
		/// </summary>
		public const string E_C_2 = "C";
		/// <summary>
		/// Park
		/// </summary>
		public const string E_P_3 = "P";
		/// <summary>
		/// Ship
		/// </summary>
		public const string E_S_4 = "S";
		/// <summary>
		/// Airplane
		/// </summary>
		public const string E_A_5 = "A";
		/// <summary>
		/// Office
		/// </summary>
		public const string E_O_6 = "O";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayFaciltyp"/> class from being created.
		/// </summary>
		private ArrayFaciltyp() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_B_1, new ArrayElement() { ResourceId = "BUILDING13586", HelpId = "", Group = "" } },
				{ E_C_2, new ArrayElement() { ResourceId = "CONTAINER_DEPOT28181", HelpId = "", Group = "" } },
				{ E_P_3, new ArrayElement() { ResourceId = "PARK62080", HelpId = "", Group = "" } },
				{ E_S_4, new ArrayElement() { ResourceId = "SHIP04380", HelpId = "", Group = "" } },
				{ E_A_5, new ArrayElement() { ResourceId = "AIRPLANE10508", HelpId = "", Group = "" } },
				{ E_O_6, new ArrayElement() { ResourceId = "OFFICE22960", HelpId = "", Group = "" } },
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
