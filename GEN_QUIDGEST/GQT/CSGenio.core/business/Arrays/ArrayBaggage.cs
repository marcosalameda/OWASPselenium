using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Baggage (Baggage)
	/// </summary>
	public class ArrayBaggage : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayBaggage _instance = new ArrayBaggage();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayBaggage Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Cabin + Checkin Luggage
		/// </summary>
		public const string E_0_1 = "0";
		/// <summary>
		/// Cabin Luggage only
		/// </summary>
		public const string E_1_2 = "1";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayBaggage"/> class from being created.
		/// </summary>
		private ArrayBaggage() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_0_1, new ArrayElement() { ResourceId = "CABIN___CHECKIN_LUGG64007", HelpId = "", Group = "" } },
				{ E_1_2, new ArrayElement() { ResourceId = "CABIN_LUGGAGE_ONLY28929", HelpId = "", Group = "" } },
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
