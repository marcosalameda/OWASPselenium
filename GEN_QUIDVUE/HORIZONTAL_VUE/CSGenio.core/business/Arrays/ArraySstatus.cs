using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Sstatus (Sale Status)
	/// </summary>
	public class ArraySstatus : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArraySstatus _instance = new ArraySstatus();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArraySstatus Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Available
		/// </summary>
		public const string E_AV_1 = "AV";
		/// <summary>
		/// Sold
		/// </summary>
		public const string E_SO_2 = "SO";
		/// <summary>
		/// Rented
		/// </summary>
		public const string E_RT_3 = "RT";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArraySstatus"/> class from being created.
		/// </summary>
		private ArraySstatus() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_AV_1, new ArrayElement() { ResourceId = "AVAILABLE21624", HelpId = "", Group = "" } },
				{ E_SO_2, new ArrayElement() { ResourceId = "SOLD59824", HelpId = "", Group = "" } },
				{ E_RT_3, new ArrayElement() { ResourceId = "RENTED41828", HelpId = "", Group = "" } },
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
