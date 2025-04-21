

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
	/// Flight
	/// </summary>
	public class CSGenioAfligh : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAfligh(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR FLIGH]/
		}

		public CSGenioAfligh(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codfligh", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "flightid", FieldType.NUMERO);
			Qfield.FieldDescription = "Flight ID";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "FLIGHT_ID40887";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "depdate", FieldType.DATA);
			Qfield.FieldDescription = "Departure Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DEPARTURE_DATE47844";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "deptime", FieldType.TEMPO);
			Qfield.FieldDescription = "Departure Time";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DEPARTURE_TIME34884";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "arvdate", FieldType.DATA);
			Qfield.FieldDescription = "Arrival Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ARRIVAL_DATE51453";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "arrtime", FieldType.TEMPO);
			Qfield.FieldDescription = "Arrival Time";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ARRIVAL_TIME43684";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codairln", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codairpt", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codairfr", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codairto", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEIRO);
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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("brdps", new String[] {"codfligh"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("fltsc", new String[] {"codfligh"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("airfr", new Relation("GQT", "gqtfligh", "fligh", "codfligh", "codairfr", "GQT", "gqtairpt", "airfr", "codairpt", "codairpt"));
			info.ParentTables.Add("airln", new Relation("GQT", "gqtfligh", "fligh", "codfligh", "codairln", "GQT", "gqtairln", "airln", "codairln", "codairln"));
			info.ParentTables.Add("airpt", new Relation("GQT", "gqtfligh", "fligh", "codfligh", "codairpt", "GQT", "gqtairpt", "airpt", "codairpt", "codairpt"));
			info.ParentTables.Add("airto", new Relation("GQT", "gqtfligh", "fligh", "codfligh", "codairto", "GQT", "gqtairpt", "airto", "codairpt", "codairpt"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(5);
			info.Pathways.Add("airln","airln");
			info.Pathways.Add("airpt","airpt");
			info.Pathways.Add("airfr","airfr");
			info.Pathways.Add("airto","airto");
			info.Pathways.Add("cntry","airpt");
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
		/// static CSGenioAfligh()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtfligh";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codfligh";
			info.HumanKeyName="flightid,".TrimEnd(',');
			info.Alias="fligh";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Flight";
			info.AreaPluralDesignation="Flights";
			info.DescriptionCav="FLIGHT55228";

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
		public static FieldRef FldCodfligh { get { return m_fldCodfligh; } }
		private static FieldRef m_fldCodfligh = new FieldRef("fligh", "codfligh");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfligh
		{
			get { return (string)returnValueField(FldCodfligh); }
			set { insertNameValueField(FldCodfligh, value); }
		}

		/// <summary>Field : "Flight ID" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldFlightid { get { return m_fldFlightid; } }
		private static FieldRef m_fldFlightid = new FieldRef("fligh", "flightid");

		/// <summary>Field : "Flight ID" Tipo: "N" Formula:  ""</summary>
		public decimal ValFlightid
		{
			get { return (decimal)returnValueField(FldFlightid); }
			set { insertNameValueField(FldFlightid, value); }
		}

		/// <summary>Field : "Departure Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDepdate { get { return m_fldDepdate; } }
		private static FieldRef m_fldDepdate = new FieldRef("fligh", "depdate");

		/// <summary>Field : "Departure Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDepdate
		{
			get { return (DateTime)returnValueField(FldDepdate); }
			set { insertNameValueField(FldDepdate, value); }
		}

		/// <summary>Field : "Departure Time" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldDeptime { get { return m_fldDeptime; } }
		private static FieldRef m_fldDeptime = new FieldRef("fligh", "deptime");

		/// <summary>Field : "Departure Time" Tipo: "T" Formula:  ""</summary>
		public string ValDeptime
		{
			get { return (string)returnValueField(FldDeptime); }
			set { insertNameValueField(FldDeptime, value); }
		}

		/// <summary>Field : "Arrival Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldArvdate { get { return m_fldArvdate; } }
		private static FieldRef m_fldArvdate = new FieldRef("fligh", "arvdate");

		/// <summary>Field : "Arrival Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValArvdate
		{
			get { return (DateTime)returnValueField(FldArvdate); }
			set { insertNameValueField(FldArvdate, value); }
		}

		/// <summary>Field : "Arrival Time" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldArrtime { get { return m_fldArrtime; } }
		private static FieldRef m_fldArrtime = new FieldRef("fligh", "arrtime");

		/// <summary>Field : "Arrival Time" Tipo: "T" Formula:  ""</summary>
		public string ValArrtime
		{
			get { return (string)returnValueField(FldArrtime); }
			set { insertNameValueField(FldArrtime, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairln { get { return m_fldCodairln; } }
		private static FieldRef m_fldCodairln = new FieldRef("fligh", "codairln");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairln
		{
			get { return (string)returnValueField(FldCodairln); }
			set { insertNameValueField(FldCodairln, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairpt { get { return m_fldCodairpt; } }
		private static FieldRef m_fldCodairpt = new FieldRef("fligh", "codairpt");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairpt
		{
			get { return (string)returnValueField(FldCodairpt); }
			set { insertNameValueField(FldCodairpt, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairfr { get { return m_fldCodairfr; } }
		private static FieldRef m_fldCodairfr = new FieldRef("fligh", "codairfr");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairfr
		{
			get { return (string)returnValueField(FldCodairfr); }
			set { insertNameValueField(FldCodairfr, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodairto { get { return m_fldCodairto; } }
		private static FieldRef m_fldCodairto = new FieldRef("fligh", "codairto");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodairto
		{
			get { return (string)returnValueField(FldCodairto); }
			set { insertNameValueField(FldCodairto, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("fligh", "zzstate");



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
        public static CSGenioAfligh search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAfligh area = new CSGenioAfligh(user, user.CurrentModule);

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
        public static List<CSGenioAfligh> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAfligh>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAfligh> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAfligh>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX FLIGH]/

     

           

	}
}
