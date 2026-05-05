using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array feedback (User feedback)
	/// </summary>
	public class ArrayFeedback : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayFeedback _instance = new ArrayFeedback();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayFeedback Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// 1 star
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// 2 stars
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// 3 stars
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// 4 stars
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// 5 stars
		/// </summary>
		public const decimal E_5_5 = 5M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayFeedback"/> class from being created.
		/// </summary>
		private ArrayFeedback() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "_1_STAR25353", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "_2_STARS16357", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "_3_STARS22471", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "_4_STARS65305", HelpId = "", Group = "" } },
				{ E_5_5, new ArrayElement() { ResourceId = "_5_STARS57620", HelpId = "", Group = "" } },
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
