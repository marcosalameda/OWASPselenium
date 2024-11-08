using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array CLASS (Classe da viagem)
	/// </summary>
	public class ArrayClass : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayClass _instance = new ArrayClass();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayClass Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// 1ªClasse
		/// </summary>
		public const string E_1C_1 = "1C";
		/// <summary>
		/// 2ªClasse
		/// </summary>
		public const string E_2C_2 = "2C";
		/// <summary>
		/// Classe Económica
		/// </summary>
		public const string E_CE_3 = "CE";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayClass"/> class from being created.
		/// </summary>
		private ArrayClass() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_1C_1, new ArrayElement() { ResourceId = "_1ACLASSE14213", HelpId = "", Group = "" } },
				{ E_2C_2, new ArrayElement() { ResourceId = "_2ACLASSE01747", HelpId = "", Group = "" } },
				{ E_CE_3, new ArrayElement() { ResourceId = "CLASSE_ECONOMICA36282", HelpId = "", Group = "" } },
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
