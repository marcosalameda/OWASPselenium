using System;
using CSGenio.framework;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using CSGenio.persistence;
using System.Text;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace CSGenio.business
{
	/// <summary>
	/// Summary description for CSArea.
	/// </summary>
	public class CSGenioApswup : DbArea
	{
	    /// <summary>
		/// Meta-informação sobre esta àrea
		/// </summary>
		protected static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioApswup(User user,string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
		}
	
		public CSGenioApswup(User user) : this(user, user.CurrentModule)
		{
		}
	
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();
			
			/*Information das areas*/
			info.TableName = "UserLogin";
			info.ShadowTabName = "";
			info.PrimaryKeyName = "codpsw";
            info.HumanKeyName = "nome";
			info.ShadowTabKeyName = "";
			info.Alias = "pswup";
			info.IsDomain =  false;
			info.AreaDesignation = "Delegador";
			info.AreaPluralDesignation = "Delegadores";
			info.DescriptionCav = "Delegador";
			
			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(9.0);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23.0);
			info.SyncCompleteHour = TimeSpan.FromHours(1.0);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
					
			info.RegisterFieldDB(new Field("codpsw", FieldType.CHAVE_PRIMARIA_GUID));
			info.DBFields["codpsw"].FieldSize = 36;
			info.KeyType = CodeType.GUID_KEY;
			info.RegisterFieldDB(new Field("sty", FieldType.NUMERO));
			info.DBFields["sty"].FieldSize = 3;
			info.RegisterFieldDB(new Field("ptn", FieldType.NUMERO));
			info.DBFields["ptn"].FieldSize = 3;
			info.RegisterFieldDB(new Field("gqt", FieldType.NUMERO));
			info.DBFields["gqt"].FieldSize = 3;
			info.RegisterFieldDB(new Field("imo", FieldType.NUMERO));
			info.DBFields["imo"].FieldSize = 3;
			info.RegisterFieldDB(new Field("reg", FieldType.NUMERO));
			info.DBFields["reg"].FieldSize = 3;
			info.RegisterFieldDB(new Field("tbs", FieldType.NUMERO));
			info.DBFields["tbs"].FieldSize = 3;
			info.RegisterFieldDB(new Field("wms", FieldType.NUMERO));
			info.DBFields["wms"].FieldSize = 3;
			info.RegisterFieldDB(new Field("trn", FieldType.NUMERO));
			info.DBFields["trn"].FieldSize = 3;
			info.RegisterFieldDB(new Field("nome", FieldType.TEXTO));
			info.DBFields["nome"].FieldSize = 100;
			
			info.RegisterFieldDB(new Field("password", FieldType.TEXTO));
			info.DBFields["password"].FieldSize = 150;
			
			info.RegisterFieldDB(new Field("certsn", FieldType.TEXTO));
			info.DBFields["certsn"].FieldSize = 32;
			
			info.RegisterFieldDB(new Field("zzstate", FieldType.INTEIRO));

			// Relações Filhas
			//------------------------------
  info.ChildTable = new ChildRelation[1];
  info.ChildTable[0]= new ChildRelation("delega", new string[] {"codpswup"}, DeleteProc.NA);

			// Relações Mãe
			//------------------------------

			// Pathways
			//------------------------------

			// Levels de acesso
			//------------------------------
			info.QLevel = new QLevel();
			info.QLevel.Query = Role.UNAUTHORIZED;
			info.QLevel.Create = Role.UNAUTHORIZED;
			info.QLevel.AlterAlways = Role.UNAUTHORIZED;
			info.QLevel.RemoveAlways = Role.UNAUTHORIZED;

			// Automatic audit stamps in BD
            //------------------------------


			return info;
		}
		
		/// <summary>
		/// Meta-informação sobre esta àrea
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-informação sobre esta àrea
		/// </summary>		
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		// USE /[MANUAL GQT TABAUX PSWUP]/

		        public static FieldRef FldCodpsw { get { return m_FldCodpsw; } }
        private static FieldRef m_FldCodpsw = new FieldRef("pswup", "codpsw");

        public string ValCodpsw
        {
            get { return (string)returnValueField(FldCodpsw); }
            set { insertNameValueField(FldCodpsw, value); }
        }


	}
}
