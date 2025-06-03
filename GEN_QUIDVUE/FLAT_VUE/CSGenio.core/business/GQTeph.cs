using System;
using System.Collections;
using System.Collections.Generic;

namespace CSGenio.framework
{
	/// <summary>
	/// Classe que representa as Entradas Permanentes de historial existentes
	/// em cada modulo.Name da classe [Module]EPH
	/// </summary>
	public class GQTEPH : EPH
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
		static GQTEPH ()
		{
			ephsPorModulo = new Hashtable();
			//Esta a obter os do cliente e nao os do modulo
			//PHE in role Query
			EPHCondition[] eph1 = new EPHCondition[2];
			eph1[0] = new EPHCondition("COMODANTE", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, "");
			eph1[1] = new EPHCondition("USER", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, "");
			ephsPorModulo.Add("1", eph1);
			//PHE in role Vendedor
			EPHCondition[] eph2 = new EPHCondition[1];
			eph2[0] = new EPHCondition("ORGAN", "GQT", "gqtpworg", "pworg", "codorgan", "pworg", "codorgan", FieldType.KEY_GUID, "");
			ephsPorModulo.Add("2", eph2);
			//PHE in role Manager
			EPHCondition[] eph20 = new EPHCondition[2];
			eph20[0] = new EPHCondition("COMODANTE", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, "");
			eph20[1] = new EPHCondition("USER", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, "");
			ephsPorModulo.Add("20", eph20);
			niveis = new string[]{ "1","2","20" };
		}

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome">name do módulo</param>
        public GQTEPH(string name)
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
