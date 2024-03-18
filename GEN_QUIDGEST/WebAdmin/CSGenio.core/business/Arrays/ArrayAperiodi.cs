using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aperiodi (Periodicidade de Recolha)
	/// </summary>
	public class ArrayAperiodi : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAperiodi _instance = new ArrayAperiodi();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAperiodi Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Horário
		/// </summary>
		public const double E_1_1 = 1;
		/// <summary>
		/// Diário
		/// </summary>
		public const double E_2_2 = 2;
		/// <summary>
		/// Semanal
		/// </summary>
		public const double E_3_3 = 3;
		/// <summary>
		/// Mensal
		/// </summary>
		public const double E_4_4 = 4;
		/// <summary>
		/// Bimestral
		/// </summary>
		public const double E_10_5 = 10;
		/// <summary>
		/// Trimestral
		/// </summary>
		public const double E_5_6 = 5;
		/// <summary>
		/// Semestral
		/// </summary>
		public const double E_6_7 = 6;
		/// <summary>
		/// Anual
		/// </summary>
		public const double E_7_8 = 7;
		/// <summary>
		/// Variável
		/// </summary>
		public const double E_9_9 = 9;
		/// <summary>
		/// Bianual
		/// </summary>
		public const double E_11_10 = 11;
		/// <summary>
		/// 5 anos
		/// </summary>
		public const double E_12_11 = 12;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAperiodi"/> class from being created.
		/// </summary>
		private ArrayAperiodi() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "HORARIO56549", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "DIARIO16236", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "SEMANAL19148", HelpId = "", Group = "" } },
				{ E_4_4, new ArrayElement() { ResourceId = "MENSAL53343", HelpId = "", Group = "" } },
				{ E_10_5, new ArrayElement() { ResourceId = "BIMESTRAL50606", HelpId = "", Group = "" } },
				{ E_5_6, new ArrayElement() { ResourceId = "TRIMESTRAL58756", HelpId = "", Group = "" } },
				{ E_6_7, new ArrayElement() { ResourceId = "SEMESTRAL24523", HelpId = "", Group = "" } },
				{ E_7_8, new ArrayElement() { ResourceId = "ANUAL55239", HelpId = "", Group = "" } },
				{ E_9_9, new ArrayElement() { ResourceId = "VARIAVEL46886", HelpId = "", Group = "" } },
				{ E_11_10, new ArrayElement() { ResourceId = "BIANUAL25027", HelpId = "", Group = "" } },
				{ E_12_11, new ArrayElement() { ResourceId = "_5_ANOS28378", HelpId = "", Group = "" } },
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
