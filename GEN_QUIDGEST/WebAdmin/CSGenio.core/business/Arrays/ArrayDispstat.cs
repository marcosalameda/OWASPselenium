using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array DispStat (Dispatch status)
	/// </summary>
	public class ArrayDispstat : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayDispstat _instance = new ArrayDispstat();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayDispstat Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Preparing
		/// </summary>
		public const string E_I_1 = "I";
		/// <summary>
		/// Prepared
		/// </summary>
		public const string E_P_2 = "P";
		/// <summary>
		/// Dispatched
		/// </summary>
		public const string E_D_3 = "D";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayDispstat"/> class from being created.
		/// </summary>
		private ArrayDispstat() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_I_1, new ArrayElement() { ResourceId = "PREPARING26576", HelpId = "", Group = "" } },
				{ E_P_2, new ArrayElement() { ResourceId = "PREPARED38522", HelpId = "", Group = "" } },
				{ E_D_3, new ArrayElement() { ResourceId = "DISPATCHED04380", HelpId = "", Group = "" } },
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
