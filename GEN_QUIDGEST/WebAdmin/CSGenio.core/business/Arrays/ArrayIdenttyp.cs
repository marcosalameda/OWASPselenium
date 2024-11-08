using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array IdentTyp (Identifier type)
	/// </summary>
	public class ArrayIdenttyp : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayIdenttyp _instance = new ArrayIdenttyp();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayIdenttyp Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Individual
		/// </summary>
		public const string E_I_1 = "I";
		/// <summary>
		/// Returnable
		/// </summary>
		public const string E_R_2 = "R";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayIdenttyp"/> class from being created.
		/// </summary>
		private ArrayIdenttyp() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_I_1, new ArrayElement() { ResourceId = "INDIVIDUAL42893", HelpId = "", Group = "" } },
				{ E_R_2, new ArrayElement() { ResourceId = "RETURNABLE23883", HelpId = "", Group = "" } },
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
