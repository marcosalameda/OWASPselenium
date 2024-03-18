using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array addrtyco (Address Type)
	/// </summary>
	public class ArrayAddrtyco : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAddrtyco _instance = new ArrayAddrtyco();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAddrtyco Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Bill To
		/// </summary>
		public const double E_1_1 = 1;
		/// <summary>
		/// Ship To
		/// </summary>
		public const double E_2_2 = 2;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAddrtyco"/> class from being created.
		/// </summary>
		private ArrayAddrtyco() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "BILL_TO10407", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "SHIP_TO13065", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(double cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<double> GetElements()
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
            return Instance.GetElementImpl(double.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<double, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(double.Parse(cod));
		}
	}
}
