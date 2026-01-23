using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aperiodi (Periodicidade de Recolha)
	/// </summary>
	public class ArrayAperiodi : Array<decimal>
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
		public const decimal E_1_1 = 1M;
		/// <summary>
		/// Diário
		/// </summary>
		public const decimal E_2_2 = 2M;
		/// <summary>
		/// Semanal
		/// </summary>
		public const decimal E_3_3 = 3M;
		/// <summary>
		/// Mensal
		/// </summary>
		public const decimal E_4_4 = 4M;
		/// <summary>
		/// Bimestral
		/// </summary>
		public const decimal E_10_5 = 10M;
		/// <summary>
		/// Trimestral
		/// </summary>
		public const decimal E_5_6 = 5M;
		/// <summary>
		/// Semestral
		/// </summary>
		public const decimal E_6_7 = 6M;
		/// <summary>
		/// Anual
		/// </summary>
		public const decimal E_7_8 = 7M;
		/// <summary>
		/// Variável
		/// </summary>
		public const decimal E_9_9 = 9M;
		/// <summary>
		/// Bianual
		/// </summary>
		public const decimal E_11_10 = 11M;
		/// <summary>
		/// 5 anos
		/// </summary>
		public const decimal E_12_11 = 12M;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAperiodi"/> class from being created.
		/// </summary>
		private ArrayAperiodi() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<decimal, ArrayElement> LoadDictionary()
		{
			return new Dictionary<decimal, ArrayElement>()
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
				{ E_12_11, new ArrayElement() { ResourceId = "_5_ANOS50688", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(decimal cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<decimal> GetElements()
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
            return Instance.GetElementImpl(decimal.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<decimal, string> GetDictionary()
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
			return Instance.GetHelpIdImpl(decimal.Parse(cod));
		}
	}
}
