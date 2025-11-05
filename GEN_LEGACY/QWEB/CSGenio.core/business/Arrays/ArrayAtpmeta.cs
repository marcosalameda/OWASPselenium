using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aTpMeta ()
	/// </summary>
	public class ArrayAtpmeta : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpmeta _instance = new ArrayAtpmeta();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpmeta Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Soma
		/// </summary>
		public const string E_SUM_1 = "SUM";
		/// <summary>
		/// Average
		/// </summary>
		public const string E_AVG_2 = "AVG";
		/// <summary>
		/// Nenhuma
		/// </summary>
		public const string E_NAN_3 = "NAN";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpmeta"/> class from being created.
		/// </summary>
		private ArrayAtpmeta() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_SUM_1, new ArrayElement() { ResourceId = "SOMA06480", HelpId = "", Group = "" } },
				{ E_AVG_2, new ArrayElement() { ResourceId = "AVERAGE50639", HelpId = "", Group = "" } },
				{ E_NAN_3, new ArrayElement() { ResourceId = "NENHUMA23117", HelpId = "", Group = "" } },
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
