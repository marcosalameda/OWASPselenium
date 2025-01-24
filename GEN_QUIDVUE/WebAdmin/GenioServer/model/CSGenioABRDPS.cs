

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
	/// Boarding Pass
	/// </summary>
	public class CSGenioAbrdps : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAbrdps(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR BRDPS]/
		}

		public CSGenioAbrdps(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codbrdps", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("brdpsid", FieldType.NUMERO);
			Qfield.FieldDescription = "Boarding Pass ID";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.CavDesignation = "BOARDING_PASS_ID53965";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("emitdate", FieldType.DATA);
			Qfield.FieldDescription = "Emission Date";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMISSION_DATE12449";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codfligh", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpsngr", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codtickt", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codfltsc", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("gate", FieldType.TEXTO);
			Qfield.FieldDescription = "Boarding Gate";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BOARDING_GATE16882";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("seat", FieldType.TEXTO);
			Qfield.FieldDescription = "Seat";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SEAT14580";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("haschkin", FieldType.LOGICO);
			Qfield.FieldDescription = "Has Checkin?";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "HAS_CHECKIN_57252";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ckndtime", FieldType.DATAHORA);
			Qfield.FieldDescription = "Checkin Date/Time";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CHECKIN_DATE_TIME16655";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("zzstate", FieldType.INTEIRO);
			Qfield.FieldDescription = "Estado da ficha";
			Qfield.Alias = info.Alias;
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
			info.ParentTables.Add("fligh", new Relation("GQT", "gqtbrdps", "brdps", "codbrdps", "codfligh", "GQT", "gqtfligh", "fligh", "codfligh", "codfligh"));
			info.ParentTables.Add("fltsc", new Relation("GQT", "gqtbrdps", "brdps", "codbrdps", "codfltsc", "GQT", "gqtfltsc", "fltsc", "codfltsc", "codfltsc"));
			info.ParentTables.Add("psngr", new Relation("GQT", "gqtbrdps", "brdps", "codbrdps", "codpsngr", "GQT", "gqtpsngr", "psngr", "codpsngr", "codpsngr"));
			info.ParentTables.Add("tickt", new Relation("GQT", "gqtbrdps", "brdps", "codbrdps", "codtickt", "GQT", "gqttickt", "tickt", "codtickt", "codtickt"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(9);
			info.Pathways.Add("psngr","psngr");
			info.Pathways.Add("tickt","tickt");
			info.Pathways.Add("fligh","fligh");
			info.Pathways.Add("fltsc","fltsc");
			info.Pathways.Add("airln","fligh");
			info.Pathways.Add("airpt","fligh");
			info.Pathways.Add("airto","fligh");
			info.Pathways.Add("airfr","fligh");
			info.Pathways.Add("cntry","fligh");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAbrdps()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtbrdps";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codbrdps";
			info.HumanKeyName="gate,".TrimEnd(',');
			info.Alias="brdps";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Boarding Pass";
			info.AreaPluralDesignation="Boarding Passes";
			info.DescriptionCav="BOARDING_PASS38735";

			info.KeyType = CodeType.GUID_KEY;

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

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodbrdps { get { return m_fldCodbrdps; } }
		private static FieldRef m_fldCodbrdps = new FieldRef("brdps", "codbrdps");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodbrdps
		{
			get { return (string)returnValueField(FldCodbrdps); }
			set { insertNameValueField(FldCodbrdps, value); }
		}

		/// <summary>Field : "Boarding Pass ID" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBrdpsid { get { return m_fldBrdpsid; } }
		private static FieldRef m_fldBrdpsid = new FieldRef("brdps", "brdpsid");

		/// <summary>Field : "Boarding Pass ID" Tipo: "N" Formula:  ""</summary>
		public decimal ValBrdpsid
		{
			get { return (decimal)returnValueField(FldBrdpsid); }
			set { insertNameValueField(FldBrdpsid, value); }
		}

		/// <summary>Field : "Emission Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldEmitdate { get { return m_fldEmitdate; } }
		private static FieldRef m_fldEmitdate = new FieldRef("brdps", "emitdate");

		/// <summary>Field : "Emission Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValEmitdate
		{
			get { return (DateTime)returnValueField(FldEmitdate); }
			set { insertNameValueField(FldEmitdate, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodfligh { get { return m_fldCodfligh; } }
		private static FieldRef m_fldCodfligh = new FieldRef("brdps", "codfligh");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfligh
		{
			get { return (string)returnValueField(FldCodfligh); }
			set { insertNameValueField(FldCodfligh, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpsngr { get { return m_fldCodpsngr; } }
		private static FieldRef m_fldCodpsngr = new FieldRef("brdps", "codpsngr");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsngr
		{
			get { return (string)returnValueField(FldCodpsngr); }
			set { insertNameValueField(FldCodpsngr, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtickt { get { return m_fldCodtickt; } }
		private static FieldRef m_fldCodtickt = new FieldRef("brdps", "codtickt");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtickt
		{
			get { return (string)returnValueField(FldCodtickt); }
			set { insertNameValueField(FldCodtickt, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodfltsc { get { return m_fldCodfltsc; } }
		private static FieldRef m_fldCodfltsc = new FieldRef("brdps", "codfltsc");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfltsc
		{
			get { return (string)returnValueField(FldCodfltsc); }
			set { insertNameValueField(FldCodfltsc, value); }
		}

		/// <summary>Field : "Boarding Gate" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldGate { get { return m_fldGate; } }
		private static FieldRef m_fldGate = new FieldRef("brdps", "gate");

		/// <summary>Field : "Boarding Gate" Tipo: "C" Formula:  ""</summary>
		public string ValGate
		{
			get { return (string)returnValueField(FldGate); }
			set { insertNameValueField(FldGate, value); }
		}

		/// <summary>Field : "Seat" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSeat { get { return m_fldSeat; } }
		private static FieldRef m_fldSeat = new FieldRef("brdps", "seat");

		/// <summary>Field : "Seat" Tipo: "C" Formula:  ""</summary>
		public string ValSeat
		{
			get { return (string)returnValueField(FldSeat); }
			set { insertNameValueField(FldSeat, value); }
		}

		/// <summary>Field : "Has Checkin?" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldHaschkin { get { return m_fldHaschkin; } }
		private static FieldRef m_fldHaschkin = new FieldRef("brdps", "haschkin");

		/// <summary>Field : "Has Checkin?" Tipo: "L" Formula:  ""</summary>
		public int ValHaschkin
		{
			get { return (int)returnValueField(FldHaschkin); }
			set { insertNameValueField(FldHaschkin, value); }
		}

		/// <summary>Field : "Checkin Date/Time" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldCkndtime { get { return m_fldCkndtime; } }
		private static FieldRef m_fldCkndtime = new FieldRef("brdps", "ckndtime");

		/// <summary>Field : "Checkin Date/Time" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValCkndtime
		{
			get { return (DateTime)returnValueField(FldCkndtime); }
			set { insertNameValueField(FldCkndtime, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("brdps", "zzstate");



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
        public static CSGenioAbrdps search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAbrdps area = new CSGenioAbrdps(user, user.CurrentModule);

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
        public static List<CSGenioAbrdps> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAbrdps>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAbrdps> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAbrdps>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX BRDPS]/

     

            

	}
}
