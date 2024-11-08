using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array YesNo (Yes / No)
	/// </summary>
	public class ArrayYesno : Array<int>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayYesno _instance = new ArrayYesno();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayYesno Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.LOGICAL; } }

		/// <summary>
		/// Not in use
		/// </summary>
		public const int E_0_1 = 0;
		/// <summary>
		/// In use
		/// </summary>
		public const int E_1_2 = 1;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayYesno"/> class from being created.
		/// </summary>
		private ArrayYesno() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<int, ArrayElement> LoadDictionary()
		{
			return new Dictionary<int, ArrayElement>()
			{
				{ E_0_1, new ArrayElement() { ResourceId = "NOT_IN_USE41845", HelpId = "", Group = "" } },
				{ E_1_2, new ArrayElement() { ResourceId = "IN_USE42606", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(int cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<int> GetElements()
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
            return Instance.GetElementImpl(int.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<int, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(int.Parse(cod));
		}
	}
}
