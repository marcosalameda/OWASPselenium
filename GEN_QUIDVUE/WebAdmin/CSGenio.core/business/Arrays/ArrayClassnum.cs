using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array CLASSNUM (Class da viagem)
	/// </summary>
	public class ArrayClassnum : Array<double>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayClassnum _instance = new ArrayClassnum();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayClassnum Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.NUMERIC; } }

		/// <summary>
		/// 1º Classe
		/// </summary>
		public const double E_1_1 = 1;
		/// <summary>
		/// 2ª Classe
		/// </summary>
		public const double E_2_2 = 2;
		/// <summary>
		/// Económica
		/// </summary>
		public const double E_3_3 = 3;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayClassnum"/> class from being created.
		/// </summary>
		private ArrayClassnum() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<double, ArrayElement> LoadDictionary()
		{
			return new Dictionary<double, ArrayElement>()
			{
				{ E_1_1, new ArrayElement() { ResourceId = "_1O_CLASSE38057", HelpId = "", Group = "" } },
				{ E_2_2, new ArrayElement() { ResourceId = "_2A_CLASSE35193", HelpId = "", Group = "" } },
				{ E_3_3, new ArrayElement() { ResourceId = "ECONOMICA05942", HelpId = "", Group = "" } },
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
