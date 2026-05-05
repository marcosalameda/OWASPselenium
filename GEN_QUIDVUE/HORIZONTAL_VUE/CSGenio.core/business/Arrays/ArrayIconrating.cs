using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array iconrating (Rating)
	/// </summary>
	public class ArrayIconrating : Array<decimal>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayIconrating _instance = new ArrayIconrating();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayIconrating Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Good
		/// </summary>
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// Average
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// Bad
		/// </summary>
		public const decimal E_3_3 = 3M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayIconrating"/> class from being created.
		/// </summary>
		private ArrayIconrating() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "GOOD01908", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "AVERAGE50639", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "BAD40612", HelpId = "", Group = "" } },
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
