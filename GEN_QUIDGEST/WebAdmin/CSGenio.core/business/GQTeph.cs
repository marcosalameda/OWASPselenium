using System.Collections.Generic;

namespace CSGenio.framework
{
	/// <summary>
	/// Defines the EPH conditions for module GQT
	/// </summary>
	public class GQTEPH : EPH
	{
        /// <summary>
        /// Maps each access level to their list of EPH
        /// </summary>
		private static Dictionary<string, List<EPHCondition>> ephsPorModulo;

        /// <summary>
        /// Id of all the UI control where a EPH should be turned off
        /// </summary>
		private static Dictionary<string, List<string>> menusNaoSujeitosEPH;

        /// <summary>
        /// Access levels subject to EPH
        /// </summary>
        private static string[] niveis;

		/// <summary>
		/// Static constructor
		/// </summary>
		static GQTEPH ()
		{
			ephsPorModulo = new ();
			//PHE in role Query            
            ephsPorModulo["1"] = [
                new EPHCondition("COMODANTE", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, ""),
                new EPHCondition("USER", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, ""),
            ];
			//PHE in role Vendedor            
            ephsPorModulo["2"] = [
                new EPHCondition("ORGAN", "GQT", "gqtpworg", "pworg", "codorgan", "pworg", "codorgan", FieldType.KEY_GUID, ""),
            ];
			//PHE in role Manager            
            ephsPorModulo["20"] = [
                new EPHCondition("COMODANTE", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, ""),
                new EPHCondition("USER", "GQT", "gqtpwcom", "pwcom", "codpess1", "pwcom", "codpess1", FieldType.KEY_GUID, ""),
            ];

			niveis = [ "1","2","20" ];

			menusNaoSujeitosEPH = new Dictionary<string, List<string>>();
            //Add self-exceptions to the ui pages that set the initial eph
            if(ephsPorModulo is not null)
                foreach(var level in ephsPorModulo)
                    foreach(var condition in level.Value)
                        if(!string.IsNullOrEmpty(condition.IntialForm))
                            AdicionaMenuNaoSujeitoEPH("ML" + condition.IntialForm, condition.EPHName);

		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nome">module</param>
        public GQTEPH(string name)
        {
            moduleName = name;
        }

		/// <inheritdoc/>
		public override Dictionary<string, List<EPHCondition>> EphsPerModule
		{
			get{return ephsPorModulo;}
		}

        /// <inheritdoc/>
        public override string[] Levels
		{
			get{return niveis;}
		}

        /// <summary>
        /// Id of all the UI control where a EPH should be turned off
        /// </summary>
        public override Dictionary<string, List<string>> MenusNotSubjectEPH
        {
            get { return menusNaoSujeitosEPH; }
        }


        private static void AdicionaMenuNaoSujeitoEPH(string identifier, string eph)
        {
            //verifica se já contem o identifier, caso contenha, adiciona outra entrada ao dicionário
            if(!menusNaoSujeitosEPH.TryGetValue(identifier, out var ephs))
                menusNaoSujeitosEPH[identifier] = [eph];
            else if(!eph.Contains(eph))
                ephs.Add(eph);
        }

		/// <inheritdoc/>
		public override bool HasIdentifierSubjectEPH(string identifier, string areaeph)
        {
            return !(menusNaoSujeitosEPH != null && menusNaoSujeitosEPH.ContainsKey(identifier)
                                                 && menusNaoSujeitosEPH[identifier].Contains(areaeph));
        }
	}
}
