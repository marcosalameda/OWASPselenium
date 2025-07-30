
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Responsible for the Indicator
	/// </summary>
	public class CSGenioAprpin : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAprpin(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR PRPIN]/
		}

		public CSGenioAprpin(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codpesso", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Primary key";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "CHAVE_PRIMARIA61422";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codpsw", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Foreign key";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "CHAVE_ESTRANGEIRA25502";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nummecan", FieldType.NUMERIC);
			Qfield.FieldDescription = "Mechanografic number";
			Qfield.FieldSize =  5;
			Qfield.IntegerDigits = 5;
			Qfield.CavDesignation = "NO_MECANOGRAFICO18516";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pessoa", FieldType.TEXT);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  100;
			Qfield.CavDesignation = "NAME31974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cargo", FieldType.TEXT);
			Qfield.FieldDescription = "Role";
			Qfield.FieldSize =  100;
			Qfield.CavDesignation = "CARGO15596";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "E-mail";
			Qfield.FieldSize =  100;
			Qfield.CavDesignation = "E_MAIL42251";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "notifind", FieldType.LOGIC);
			Qfield.FieldDescription = "Individual Notifications";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "NOTIFICACOES_INDIVID17237";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codorgaf", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Foreign key";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "CHAVE_ESTRANGEIRA25502";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "eexterna", FieldType.LOGIC);
			Qfield.FieldDescription = "External Entity";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "EXTERNAL_ENTITY00698";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatdat", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Creation date";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "CRIADO_EM61283";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatope", FieldType.TEXT);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  200;
			Qfield.CavDesignation = "CRIADO_POR17895";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "chngdate", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Changed on";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "ALTERADO_EM23573";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operchng", FieldType.TEXT);
			Qfield.FieldDescription = "Changed by";
			Qfield.FieldSize =  200;
			Qfield.CavDesignation = "ALTERADO_POR39254";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("psw", new Relation("GQT", "gqtprpin", "prpin", "codpesso", "codpsw", "GQT", "userlogin", "psw", "codpsw", "codpsw"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("psw","psw");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "eexterna"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAprpin()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtprpin";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codpesso";
			info.HumanKeyName="pessoa,".TrimEnd(',');
			info.Alias="prpin";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Responsible for the Indicator";
			info.AreaPluralDesignation="Responsibles for the Indicators";
			info.DescriptionCav="RESPONSIBLE_FOR_THE_21918";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------
			info.StampFieldsIns = new string[] {
                "creatope","creatdat"
			};

			info.StampFieldsAlt = new string[] {
                "operchng","chngdate"
			};
            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("prpin", "codpesso");

		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}

		/// <summary>Field : "Foreign key" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpsw { get { return m_fldCodpsw; } }
		private static FieldRef m_fldCodpsw = new FieldRef("prpin", "codpsw");

		/// <summary>Field : "Foreign key" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw
		{
			get { return (string)returnValueField(FldCodpsw); }
			set { insertNameValueField(FldCodpsw, value); }
		}

		/// <summary>Field : "Mechanografic number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNummecan { get { return m_fldNummecan; } }
		private static FieldRef m_fldNummecan = new FieldRef("prpin", "nummecan");

		/// <summary>Field : "Mechanografic number" Tipo: "N" Formula:  ""</summary>
		public decimal ValNummecan
		{
			get { return (decimal)returnValueField(FldNummecan); }
			set { insertNameValueField(FldNummecan, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPessoa { get { return m_fldPessoa; } }
		private static FieldRef m_fldPessoa = new FieldRef("prpin", "pessoa");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValPessoa
		{
			get { return (string)returnValueField(FldPessoa); }
			set { insertNameValueField(FldPessoa, value); }
		}

		/// <summary>Field : "Role" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCargo { get { return m_fldCargo; } }
		private static FieldRef m_fldCargo = new FieldRef("prpin", "cargo");

		/// <summary>Field : "Role" Tipo: "C" Formula:  ""</summary>
		public string ValCargo
		{
			get { return (string)returnValueField(FldCargo); }
			set { insertNameValueField(FldCargo, value); }
		}

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("prpin", "email");

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Individual Notifications" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldNotifind { get { return m_fldNotifind; } }
		private static FieldRef m_fldNotifind = new FieldRef("prpin", "notifind");

		/// <summary>Field : "Individual Notifications" Tipo: "L" Formula:  ""</summary>
		public int ValNotifind
		{
			get { return (int)returnValueField(FldNotifind); }
			set { insertNameValueField(FldNotifind, value); }
		}

		/// <summary>Field : "Foreign key" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodorgaf { get { return m_fldCodorgaf; } }
		private static FieldRef m_fldCodorgaf = new FieldRef("prpin", "codorgaf");

		/// <summary>Field : "Foreign key" Tipo: "CF" Formula:  ""</summary>
		public string ValCodorgaf
		{
			get { return (string)returnValueField(FldCodorgaf); }
			set { insertNameValueField(FldCodorgaf, value); }
		}

		/// <summary>Field : "External Entity" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldEexterna { get { return m_fldEexterna; } }
		private static FieldRef m_fldEexterna = new FieldRef("prpin", "eexterna");

		/// <summary>Field : "External Entity" Tipo: "L" Formula:  ""</summary>
		public int ValEexterna
		{
			get { return (int)returnValueField(FldEexterna); }
			set { insertNameValueField(FldEexterna, value); }
		}

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("prpin", "creatdat");

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatope { get { return m_fldCreatope; } }
		private static FieldRef m_fldCreatope = new FieldRef("prpin", "creatope");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope
		{
			get { return (string)returnValueField(FldCreatope); }
			set { insertNameValueField(FldCreatope, value); }
		}

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldChngdate { get { return m_fldChngdate; } }
		private static FieldRef m_fldChngdate = new FieldRef("prpin", "chngdate");

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValChngdate
		{
			get { return (DateTime)returnValueField(FldChngdate); }
			set { insertNameValueField(FldChngdate, value); }
		}

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldOperchng { get { return m_fldOperchng; } }
		private static FieldRef m_fldOperchng = new FieldRef("prpin", "operchng");

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng
		{
			get { return (string)returnValueField(FldOperchng); }
			set { insertNameValueField(FldOperchng, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("prpin", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAprpin search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAprpin area = new CSGenioAprpin(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAprpin> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAprpin>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAprpin> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAprpin>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX PRPIN]/

     

              

	}
}
