using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array assetTags (Asset tag)
	/// </summary>
	public class ArrayAssettags : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAssettags _instance = new ArrayAssettags();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAssettags Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Urgent
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// Checked
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// In Repair
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// Important
		/// </summary>
		public const decimal E_4_4 = 4M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAssettags"/> class from being created.
		/// </summary>
		private ArrayAssettags() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "URGENT40554", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "CHECKED31708", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "IN_REPAIR33602", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "IMPORTANT21753", HelpId = "", Group = "" } },
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
