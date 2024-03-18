using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array a_nivele ()
	/// </summary>
	public class ArrayA_nivele : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayA_nivele _instance = new ArrayA_nivele();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayA_nivele Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Nivel I
		/// </summary>
		public const string E_I_1 = "I";
		/// <summary>
		/// Nivel II
		/// </summary>
		public const string E_II_2 = "II";
		/// <summary>
		/// Nivel III
		/// </summary>
		public const string E_III_3 = "III";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayA_nivele"/> class from being created.
		/// </summary>
		private ArrayA_nivele() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_I_1, new ArrayElement() { ResourceId = "NIVEL_I61863", HelpId = "", Group = "" } },
				{ E_II_2, new ArrayElement() { ResourceId = "NIVEL_II23028", HelpId = "", Group = "" } },
				{ E_III_3, new ArrayElement() { ResourceId = "NIVEL_III58608", HelpId = "", Group = "" } },
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
