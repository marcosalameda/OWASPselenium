using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aCondTst (Condição)
	/// </summary>
	public class ArrayAcondtst : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAcondtst _instance = new ArrayAcondtst();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAcondtst Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Block field
		/// </summary>
		public const string E_BLOCK_1 = "BLOCK";
		/// <summary>
		/// Hide field
		/// </summary>
		public const string E_HIDE_2 = "HIDE";
		/// <summary>
		/// Require field
		/// </summary>
		public const string E_REQUIRE_3 = "REQUIRE";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAcondtst"/> class from being created.
		/// </summary>
		private ArrayAcondtst() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_BLOCK_1, new ArrayElement() { ResourceId = "BLOCK_FIELD33648", HelpId = "", Group = "" } },
				{ E_HIDE_2, new ArrayElement() { ResourceId = "HIDE_FIELD21772", HelpId = "", Group = "" } },
				{ E_REQUIRE_3, new ArrayElement() { ResourceId = "REQUIRE_FIELD20203", HelpId = "", Group = "" } },
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
