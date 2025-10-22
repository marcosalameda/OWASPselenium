
 
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
	/// Country
	/// </summary>
	public class CSGenioApais1 : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioApais1(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR PAIS1]/
		}

		public CSGenioApais1(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codcntry", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "country", FieldType.TEXT);
			Qfield.FieldDescription = "Country";
			Qfield.FieldSize =  90;
			Qfield.CavDesignation = "COUNTRY64133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "active", FieldType.LOGIC);
			Qfield.FieldDescription = "Active";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "ACTIVE03270";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codigonr", FieldType.TEXT);
			Qfield.FieldDescription = "Numeric";
			Qfield.FieldSize =  3;
			Qfield.CavDesignation = "NUMERIC19292";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "alfa2", FieldType.TEXT);
			Qfield.FieldDescription = "Alphabetic 2";
			Qfield.FieldSize =  2;
			Qfield.CavDesignation = "ALPHABETIC_232435";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "alfa3", FieldType.TEXT);
			Qfield.FieldDescription = "Alphabetic 3";
			Qfield.FieldSize =  3;
			Qfield.CavDesignation = "ALPHABETIC_316640";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "flag", FieldType.IMAGE);
			Qfield.FieldDescription = "Flag";
			Qfield.FieldSize =  3;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "FLAG51937";

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
			info.ChildTable = new ChildRelation[7];
			info.ChildTable[0]= new ChildRelation("regio", new String[] {"codcntry","codpais1"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("airpt", new String[] {"codcntry"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("cmpny", new String[] {"codcntry"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("indoc", new String[] {"codcntry"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("propr", new String[] {"codcntry","codpais1"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("pesso", new String[] {"codpaise","codcntry"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("facil", new String[] {"codcntry"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
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
		/// static CSGenioApais1()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtcntry";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codcntry";
			info.HumanKeyName="country,".TrimEnd(',');
			info.Alias="pais1";
			info.IsDomain = false;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Country";
			info.AreaPluralDesignation="Countries";
			info.DescriptionCav="COUNTRY64133";

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
            info.QLevel.Query = Role.ROLE_1;
            info.QLevel.Create = Role.ROLE_1;
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
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("pais1", "codcntry");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}

		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCountry { get { return m_fldCountry; } }
		private static FieldRef m_fldCountry = new FieldRef("pais1", "country");

		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public string ValCountry
		{
			get { return (string)returnValueField(FldCountry); }
			set { insertNameValueField(FldCountry, value); }
		}

		/// <summary>Field : "Active" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldActive { get { return m_fldActive; } }
		private static FieldRef m_fldActive = new FieldRef("pais1", "active");

		/// <summary>Field : "Active" Tipo: "L" Formula:  ""</summary>
		public int ValActive
		{
			get { return (int)returnValueField(FldActive); }
			set { insertNameValueField(FldActive, value); }
		}

		/// <summary>Field : "Numeric" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCodigonr { get { return m_fldCodigonr; } }
		private static FieldRef m_fldCodigonr = new FieldRef("pais1", "codigonr");

		/// <summary>Field : "Numeric" Tipo: "C" Formula:  ""</summary>
		public string ValCodigonr
		{
			get { return (string)returnValueField(FldCodigonr); }
			set { insertNameValueField(FldCodigonr, value); }
		}

		/// <summary>Field : "Alphabetic 2" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAlfa2 { get { return m_fldAlfa2; } }
		private static FieldRef m_fldAlfa2 = new FieldRef("pais1", "alfa2");

		/// <summary>Field : "Alphabetic 2" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa2
		{
			get { return (string)returnValueField(FldAlfa2); }
			set { insertNameValueField(FldAlfa2, value); }
		}

		/// <summary>Field : "Alphabetic 3" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAlfa3 { get { return m_fldAlfa3; } }
		private static FieldRef m_fldAlfa3 = new FieldRef("pais1", "alfa3");

		/// <summary>Field : "Alphabetic 3" Tipo: "C" Formula:  ""</summary>
		public string ValAlfa3
		{
			get { return (string)returnValueField(FldAlfa3); }
			set { insertNameValueField(FldAlfa3, value); }
		}

		/// <summary>Field : "Flag" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFlag { get { return m_fldFlag; } }
		private static FieldRef m_fldFlag = new FieldRef("pais1", "flag");

		/// <summary>Field : "Flag" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFlag
		{
			get { return (byte[])returnValueField(FldFlag); }
			set { insertNameValueField(FldFlag, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("pais1", "zzstate");



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
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioApais1 search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioApais1 area = new CSGenioApais1(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
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
        public static List<CSGenioApais1> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioApais1>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioApais1> listing)
        {
			sp.searchListAdvancedWhere<CSGenioApais1>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX PAIS1]/

     
        

	}
}
