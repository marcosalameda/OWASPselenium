using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aestado ()
	/// </summary>
	public class ArrayAestado : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAestado _instance = new ArrayAestado();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAestado Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Adiada
		/// </summary>
		public const string E_DELAYED_1 = "DELAYED";
		/// <summary>
		/// Concluída
		/// </summary>
		public const string E_COMPLETE_2 = "COMPLETE";
		/// <summary>
		/// Em Curso
		/// </summary>
		public const string E_ONCOURSE_3 = "ONCOURSE";
		/// <summary>
		/// Encerrada
		/// </summary>
		public const string E_CLOSED_4 = "CLOSED";
		/// <summary>
		/// Parada
		/// </summary>
		public const string E_STOPPED_5 = "STOPPED";
		/// <summary>
		/// Planeada
		/// </summary>
		public const string E_PLANNED_6 = "PLANNED";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAestado"/> class from being created.
		/// </summary>
		private ArrayAestado() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_DELAYED_1, new ArrayElement() { ResourceId = "ADIADA24595", HelpId = "", Group = "" } },
				{ E_COMPLETE_2, new ArrayElement() { ResourceId = "CONCLUIDA26734", HelpId = "", Group = "" } },
				{ E_ONCOURSE_3, new ArrayElement() { ResourceId = "EM_CURSO28102", HelpId = "", Group = "" } },
				{ E_CLOSED_4, new ArrayElement() { ResourceId = "ENCERRADA29062", HelpId = "", Group = "" } },
				{ E_STOPPED_5, new ArrayElement() { ResourceId = "PARADA59671", HelpId = "", Group = "" } },
				{ E_PLANNED_6, new ArrayElement() { ResourceId = "PLANEADA29857", HelpId = "", Group = "" } },
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
