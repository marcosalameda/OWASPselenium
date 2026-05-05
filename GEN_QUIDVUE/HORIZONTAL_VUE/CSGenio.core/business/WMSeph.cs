using System;
using System.Collections;
using System.Collections.Generic;

namespace CSGenio.framework
{
	/// <summary>
	/// Classe que representa as Entradas Permanentes de historial existentes
	/// em cada modulo.Name da classe [Module]EPH
	/// </summary>
	public class WMSEPH : EPH
	{
        /// <summary>
        /// Hashtable com as ephs activas em cada nível
        /// </summary>
		protected static Hashtable ephsPorModulo;

        /// <summary>
        /// Código dos vários controlos onde a eph referida não tem efeito
        /// </summary>
		protected static Dictionary<string, List<string>> menusNaoSujeitosEPH;

		/// <summary>
		/// Contructor da classe
		/// </summary>
		static WMSEPH ()
		{
			ephsPorModulo = new Hashtable();
			//Esta a obter os do cliente e nao os do modulo
			//PHE in role Manager
			EPHCondition[] eph20 = new EPHCondition[1];
			eph20[0] = new EPHCondition("USERS", "GQT", "gqtusers", "users", "codperso", "users", "codperso", FieldType.KEY_GUID, "");
			ephsPorModulo.Add("20", eph20);
			niveis = new string[]{ "20" };
		}

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome">name do módulo</param>
        public WMSEPH(string name)
        {
            moduleName = name;
        }

		/// <summary>
		/// Método que coloca e devolve as ephs por módulo
		/// </summary>
		public override Hashtable EphsPerModule
		{
			get{return ephsPorModulo;}
			set{ephsPorModulo=value;}
		}

        /// <summary>
        /// Método que coloca e devolve os menus não sujeitos a EPH
        /// </summary>
        public override Dictionary<string, List<string>> MenusNotSubjectEPH
        {
            get { return menusNaoSujeitosEPH; }
            set { menusNaoSujeitosEPH = value; }
        }

		//02-12-2009
        public static void AdicionaMenuNaoSujeitoEPH(string identifier, string eph)
        {
            //verifica se já contem o identifier, caso contenha, adiciona outra entrada ao dicionário
            //[TMV](2020.09.30) -> initializes if is null
            if(menusNaoSujeitosEPH == null)
            {
                menusNaoSujeitosEPH = new Dictionary<string, List<string>>();
                menusNaoSujeitosEPH.Add(identifier, new List<string> { eph });
            }
            else if (!menusNaoSujeitosEPH.ContainsKey(identifier))
                menusNaoSujeitosEPH.Add(identifier, new List<string> { eph });
            else if (!menusNaoSujeitosEPH[identifier].Contains(eph))
                menusNaoSujeitosEPH[identifier].Add(eph);

        }

		/// <summary>
        /// Verifica se neste módulo o identifier está sujeito à eph da area
        /// </summary>
        /// <param name="identificador">identifier do controlo</param>
        /// <param name="areaeph">area da eph</param>
        /// <returns>true se o identifier está sujeito a eph</returns>
		public override bool HasIdentifierSubjectEPH(string identifier, string areaeph)
        {
            return !(menusNaoSujeitosEPH != null && menusNaoSujeitosEPH.ContainsKey(identifier)
                                                 && menusNaoSujeitosEPH[identifier].Contains(areaeph));
        }
	}
}
