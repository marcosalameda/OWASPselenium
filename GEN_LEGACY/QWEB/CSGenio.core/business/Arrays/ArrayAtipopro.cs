using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array atipopro ()
	/// </summary>
	public class ArrayAtipopro : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtipopro _instance = new ArrayAtipopro();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtipopro Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Programa
		/// </summary>
		public const string E_PR_1 = "PR";
		/// <summary>
		/// Proyecto
		/// </summary>
		public const string E_PJ_2 = "PJ";
		/// <summary>
		/// Componente
		/// </summary>
		public const string E_C_3 = "C";
		/// <summary>
		/// Acción
		/// </summary>
		public const string E_A_4 = "A";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtipopro"/> class from being created.
		/// </summary>
		private ArrayAtipopro() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_PR_1, new ArrayElement() { ResourceId = "PROGRAMA08229", HelpId = "", Group = "" } },
				{ E_PJ_2, new ArrayElement() { ResourceId = "PROYECTO07336", HelpId = "", Group = "" } },
				{ E_C_3, new ArrayElement() { ResourceId = "COMPONENTE41748", HelpId = "", Group = "" } },
				{ E_A_4, new ArrayElement() { ResourceId = "ACCION51528", HelpId = "", Group = "" } },
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
