using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aGanttUn (Escala do gráfico Gantt)
	/// </summary>
	public class ArrayAganttun : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAganttun _instance = new ArrayAganttun();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAganttun Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Day
		/// </summary>
		public const string E_DAY_1 = "day";
		/// <summary>
		/// Semana
		/// </summary>
		public const string E_WEEK_2 = "week";
		/// <summary>
		/// Mês
		/// </summary>
		public const string E_MONTH_3 = "month";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAganttun"/> class from being created.
		/// </summary>
		private ArrayAganttun() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_DAY_1, new ArrayElement() { ResourceId = "DAY27593", HelpId = "", Group = "" } },
				{ E_WEEK_2, new ArrayElement() { ResourceId = "SEMANA00471", HelpId = "", Group = "" } },
				{ E_MONTH_3, new ArrayElement() { ResourceId = "MES61580", HelpId = "", Group = "" } },
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
