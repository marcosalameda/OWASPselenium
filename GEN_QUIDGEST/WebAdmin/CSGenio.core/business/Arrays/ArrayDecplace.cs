using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array DecPlace (Decimal places)
	/// </summary>
	public class ArrayDecplace : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayDecplace _instance = new ArrayDecplace();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayDecplace Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// None
		/// </summary>
		public const double E_0_1 = 0;
		/// <summary>
		/// One
		/// </summary>
		public const double E_1_2 = 1;
		/// <summary>
		/// Two
		/// </summary>
		public const double E_2_3 = 2;
		/// <summary>
		/// Three
		/// </summary>
		public const double E_3_4 = 3;
		/// <summary>
		/// Four
		/// </summary>
		public const double E_4_5 = 4;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayDecplace"/> class from being created.
		/// </summary>
		private ArrayDecplace() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_0_1, new ArrayElement() { ResourceId = "NONE51124", HelpId = "", Group = "" } },
				{ E_1_2, new ArrayElement() { ResourceId = "ONE44350", HelpId = "", Group = "" } },
				{ E_2_3, new ArrayElement() { ResourceId = "TWO16230", HelpId = "", Group = "" } },
				{ E_3_4, new ArrayElement() { ResourceId = "THREE09760", HelpId = "", Group = "" } },
				{ E_4_5, new ArrayElement() { ResourceId = "FOUR61011", HelpId = "", Group = "" } },
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
