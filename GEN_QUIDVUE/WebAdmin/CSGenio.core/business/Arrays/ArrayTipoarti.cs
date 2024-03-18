using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array TipoArti (Article types)
	/// </summary>
	public class ArrayTipoarti : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayTipoarti _instance = new ArrayTipoarti();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayTipoarti Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Very mobile
		/// </summary>
		public const string E_B_1 = "B";
		/// <summary>
		/// Vehicle
		/// </summary>
		public const string E_V_2 = "V";
		/// <summary>
		/// Property
		/// </summary>
		public const string E_I_3 = "I";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayTipoarti"/> class from being created.
		/// </summary>
		private ArrayTipoarti() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_B_1, new ArrayElement() { ResourceId = "VERY_MOBILE37160", HelpId = "", Group = "" } },
				{ E_V_2, new ArrayElement() { ResourceId = "VEHICLE49593", HelpId = "", Group = "" } },
				{ E_I_3, new ArrayElement() { ResourceId = "PROPERTY43977", HelpId = "", Group = "" } },
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
