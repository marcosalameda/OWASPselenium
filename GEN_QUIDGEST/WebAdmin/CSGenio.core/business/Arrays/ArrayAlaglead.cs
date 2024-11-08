using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array alaglead ()
	/// </summary>
	public class ArrayAlaglead : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAlaglead _instance = new ArrayAlaglead();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAlaglead Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Lag
		/// </summary>
		public const string E_LG_1 = "LG";
		/// <summary>
		/// Lead
		/// </summary>
		public const string E_LD_2 = "LD";
		/// <summary>
		/// Resultados
		/// </summary>
		public const string E_RE_3 = "RE";
		/// <summary>
		/// Eficacia
		/// </summary>
		public const string E_EF_4 = "EF";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAlaglead"/> class from being created.
		/// </summary>
		private ArrayAlaglead() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_LG_1, new ArrayElement() { ResourceId = "LAG58416", HelpId = "", Group = "" } },
				{ E_LD_2, new ArrayElement() { ResourceId = "LEAD45626", HelpId = "", Group = "" } },
				{ E_RE_3, new ArrayElement() { ResourceId = "RESULTADOS20000", HelpId = "", Group = "" } },
				{ E_EF_4, new ArrayElement() { ResourceId = "EFICACIA03259", HelpId = "", Group = "" } },
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
