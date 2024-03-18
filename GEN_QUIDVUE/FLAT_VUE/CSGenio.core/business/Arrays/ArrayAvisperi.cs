using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aVisPeri ()
	/// </summary>
	public class ArrayAvisperi : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAvisperi _instance = new ArrayAvisperi();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAvisperi Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// Mensal
		/// </summary>
		public const double E_4_1 = 4;
		/// <summary>
		/// Trimestral
		/// </summary>
		public const double E_5_2 = 5;
		/// <summary>
		/// Semestral
		/// </summary>
		public const double E_6_3 = 6;
		/// <summary>
		/// Anual
		/// </summary>
		public const double E_7_4 = 7;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAvisperi"/> class from being created.
		/// </summary>
		private ArrayAvisperi() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_4_1, new ArrayElement() { ResourceId = "MENSAL53343", HelpId = "", Group = "" } },
				{ E_5_2, new ArrayElement() { ResourceId = "TRIMESTRAL58756", HelpId = "", Group = "" } },
				{ E_6_3, new ArrayElement() { ResourceId = "SEMESTRAL24523", HelpId = "", Group = "" } },
				{ E_7_4, new ArrayElement() { ResourceId = "ANUAL55239", HelpId = "", Group = "" } },
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
