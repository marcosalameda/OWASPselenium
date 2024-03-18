using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array ObjeType (Object Type)
	/// </summary>
	public class ArrayObjetype : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayObjetype _instance = new ArrayObjetype();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayObjetype Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Account
		/// </summary>
		public const double E_1_1 = 1;
		/// <summary>
		/// Contact
		/// </summary>
		public const double E_2_2 = 2;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayObjetype"/> class from being created.
		/// </summary>
		private ArrayObjetype() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "ACCOUNT64260", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "CONTACT59247", HelpId = "", Group = "" } },
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
