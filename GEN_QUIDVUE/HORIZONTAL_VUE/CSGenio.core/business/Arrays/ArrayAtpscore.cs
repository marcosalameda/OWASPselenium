using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array atpscore ()
	/// </summary>
	public class ArrayAtpscore : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayAtpscore _instance = new ArrayAtpscore();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayAtpscore Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Avaliação
		/// </summary>
		public const string E_EVAL_1 = "EVAL";
		/// <summary>
		/// Monitorização
		/// </summary>
		public const string E_MONI_2 = "MONI";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayAtpscore"/> class from being created.
		/// </summary>
		private ArrayAtpscore() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_EVAL_1, new ArrayElement() { ResourceId = "AVALIACAO18442", HelpId = "", Group = "" } },
				{ E_MONI_2, new ArrayElement() { ResourceId = "MONITORIZACAO41068", HelpId = "", Group = "" } },
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
