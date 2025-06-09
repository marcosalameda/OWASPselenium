using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aTpSeg (Tipo de segmento)
	/// </summary>
	public class ArrayAtpseg : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpseg _instance = new ArrayAtpseg();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpseg Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Sexo
		/// </summary>
		public const string E_SEX_1 = "SEX";
		/// <summary>
		/// Sector
		/// </summary>
		public const string E_SEC_2 = "SEC";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpseg"/> class from being created.
		/// </summary>
		private ArrayAtpseg() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_SEX_1, new ArrayElement() { ResourceId = "SEXO52099", HelpId = "", Group = "" } },
				{ E_SEC_2, new ArrayElement() { ResourceId = "SECTOR41481", HelpId = "", Group = "" } },
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
