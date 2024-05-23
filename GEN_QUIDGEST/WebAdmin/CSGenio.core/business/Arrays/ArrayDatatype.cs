using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array DataType (Data type)
	/// </summary>
	public class ArrayDatatype : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayDatatype _instance = new ArrayDatatype();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayDatatype Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Text
		/// </summary>
		public const string E_T_1 = "T";
		/// <summary>
		/// Numeric
		/// </summary>
		public const string E_N_2 = "N";
		/// <summary>
		/// Date
		/// </summary>
		public const string E_D_3 = "D";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayDatatype"/> class from being created.
		/// </summary>
		private ArrayDatatype() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_T_1, new ArrayElement() { ResourceId = "TEXT04938", HelpId = "", Group = "" } },
				{ E_N_2, new ArrayElement() { ResourceId = "NUMERIC19292", HelpId = "", Group = "" } },
				{ E_D_3, new ArrayElement() { ResourceId = "DATE18475", HelpId = "", Group = "" } },
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
