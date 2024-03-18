using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array GpsInput (GPS input)
	/// </summary>
	public class ArrayGpsinput : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayGpsinput _instance = new ArrayGpsinput();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayGpsinput Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Latitude and Longitude
		/// </summary>
		public const string E_L_1 = "L";
		/// <summary>
		/// Point in Map
		/// </summary>
		public const string E_P_2 = "P";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayGpsinput"/> class from being created.
		/// </summary>
		private ArrayGpsinput() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_L_1, new ArrayElement() { ResourceId = "LATITUDE_AND_LONGITU45730", HelpId = "", Group = "" } },
				{ E_P_2, new ArrayElement() { ResourceId = "POINT_IN_MAP40870", HelpId = "", Group = "" } },
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
