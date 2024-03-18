using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array aHorasSe (Nº Horas de Trabalho)
	/// </summary>
	public class ArrayAhorasse : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAhorasse _instance = new ArrayAhorasse();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAhorasse Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// 35
		/// </summary>
		public const double E_35_1 = 35;
		/// <summary>
		/// 40
		/// </summary>
		public const double E_40_2 = 40;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAhorasse"/> class from being created.
		/// </summary>
		private ArrayAhorasse() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_35_1, new ArrayElement() { ResourceId = "_3534512", HelpId = "", Group = "" } },
				{ E_40_2, new ArrayElement() { ResourceId = "_4033029", HelpId = "", Group = "" } },
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
