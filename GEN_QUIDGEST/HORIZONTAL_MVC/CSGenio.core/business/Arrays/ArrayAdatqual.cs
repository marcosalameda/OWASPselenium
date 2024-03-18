using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array adatqual ()
	/// </summary>
	public class ArrayAdatqual : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAdatqual _instance = new ArrayAdatqual();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAdatqual Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Muito Boa
		/// </summary>
		public const double E_5_1 = 5;
		/// <summary>
		/// Boa
		/// </summary>
		public const double E_4_2 = 4;
		/// <summary>
		/// Razoável
		/// </summary>
		public const double E_3_3 = 3;
		/// <summary>
		/// Má
		/// </summary>
		public const double E_2_4 = 2;
		/// <summary>
		/// Muito Má
		/// </summary>
		public const double E_1_5 = 1;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAdatqual"/> class from being created.
		/// </summary>
		private ArrayAdatqual() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_5_1, new ArrayElement() { ResourceId = "MUITO_BOA49280", HelpId = "", Group = "" } },
				{ E_4_2, new ArrayElement() { ResourceId = "BOA18662", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "RAZOAVEL14967", HelpId = "", Group = "" } },
				{ E_2_4, new ArrayElement() { ResourceId = "MA11547", HelpId = "", Group = "" } },
				{ E_1_5, new ArrayElement() { ResourceId = "MUITO_MA26606", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(double cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<double> GetElements()
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
            return Instance.GetElementImpl(double.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<double, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(double.Parse(cod));
		}
	}
}
