using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array DecPlace (Decimal places)
	/// </summary>
	public class ArrayDecplace : Array<decimal>
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
		public const decimal E_0_1 = 0M;
		/// <summary>
		/// One
		/// </summary>
		public const decimal E_1_2 = 1M;
		/// <summary>
		/// Two
		/// </summary>
		public const decimal E_2_3 = 2M;
		/// <summary>
		/// Three
		/// </summary>
		public const decimal E_3_4 = 3M;
		/// <summary>
		/// Four
		/// </summary>
		public const decimal E_4_5 = 4M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayDecplace"/> class from being created.
		/// </summary>
		private ArrayDecplace() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
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
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
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
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
