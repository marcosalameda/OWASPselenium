using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array AreaTecn (Technical area)
	/// </summary>
	public class ArrayAreatecn : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAreatecn _instance = new ArrayAreatecn();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAreatecn Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Mechanical
		/// </summary>
		public const string E_M_1 = "M";
		/// <summary>
		/// Electricity
		/// </summary>
		public const string E_E_2 = "E";
		/// <summary>
		/// Cleaning
		/// </summary>
		public const string E_L_3 = "L";
		/// <summary>
		/// Management
		/// </summary>
		public const string E_G_4 = "G";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAreatecn"/> class from being created.
		/// </summary>
		private ArrayAreatecn() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_M_1, new ArrayElement() { ResourceId = "MECHANICAL47923", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "ELECTRICITY31511", HelpId = "", Group = "" } },
				{ E_L_3, new ArrayElement() { ResourceId = "CLEANING01363", HelpId = "", Group = "" } },
				{ E_G_4, new ArrayElement() { ResourceId = "MANAGEMENT02985", HelpId = "", Group = "" } },
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
