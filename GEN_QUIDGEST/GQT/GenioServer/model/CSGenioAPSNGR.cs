
 
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
	/// Passenger
	/// </summary>
	public class CSGenioApsngr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioApsngr(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR PSNGR]/
		}

		public CSGenioApsngr(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codpsngr", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "psngrid", FieldType.NUMERIC);
			Qfield.FieldDescription = "Passenger ID";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "PASSENGER_ID27843";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "fstname", FieldType.TEXT);
			Qfield.FieldDescription = "First Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FIRST_NAME10285";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "lstname", FieldType.TEXT);
			Qfield.FieldDescription = "Last Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LAST_NAME49666";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "fullname", FieldType.TEXT);
			Qfield.FieldDescription = "Full Name";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FULL_NAME48109";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "passprtn", FieldType.TEXT);
			Qfield.FieldDescription = "Passport Number";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PASSPORT_NUMBER36034";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "psngrdob", FieldType.DATE);
			Qfield.FieldDescription = "Date of Birth";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_OF_BIRTH36542";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "paddress", FieldType.MEMO);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 10;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "psemail", FieldType.TEXT);
			Qfield.FieldDescription = "Email Address";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMAIL_ADDRESS30215";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ctcnumbr", FieldType.TEXT);
			Qfield.FieldDescription = "Contact Number";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CONTACT_NUMBER46354";

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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("brdps", new String[] {"codpsngr"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("tickt", new String[] {"codpsngr"}, DeleteProc.NA);

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
		/// static CSGenioApsngr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtpsngr";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codpsngr";
			info.HumanKeyName="fstname,".TrimEnd(',');
			info.Alias="psngr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Passenger";
			info.AreaPluralDesignation="Passengers";
			info.DescriptionCav="PASSENGER40365";

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
		public static FieldRef FldCodpsngr { get { return m_fldCodpsngr; } }
		private static FieldRef m_fldCodpsngr = new FieldRef("psngr", "codpsngr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpsngr
		{
			get { return (string)returnValueField(FldCodpsngr); }
			set { insertNameValueField(FldCodpsngr, value); }
		}

		/// <summary>Field : "Passenger ID" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPsngrid { get { return m_fldPsngrid; } }
		private static FieldRef m_fldPsngrid = new FieldRef("psngr", "psngrid");

		/// <summary>Field : "Passenger ID" Tipo: "N" Formula:  ""</summary>
		public decimal ValPsngrid
		{
			get { return (decimal)returnValueField(FldPsngrid); }
			set { insertNameValueField(FldPsngrid, value); }
		}

		/// <summary>Field : "First Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFstname { get { return m_fldFstname; } }
		private static FieldRef m_fldFstname = new FieldRef("psngr", "fstname");

		/// <summary>Field : "First Name" Tipo: "C" Formula:  ""</summary>
		public string ValFstname
		{
			get { return (string)returnValueField(FldFstname); }
			set { insertNameValueField(FldFstname, value); }
		}

		/// <summary>Field : "Last Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLstname { get { return m_fldLstname; } }
		private static FieldRef m_fldLstname = new FieldRef("psngr", "lstname");

		/// <summary>Field : "Last Name" Tipo: "C" Formula:  ""</summary>
		public string ValLstname
		{
			get { return (string)returnValueField(FldLstname); }
			set { insertNameValueField(FldLstname, value); }
		}

		/// <summary>Field : "Full Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFullname { get { return m_fldFullname; } }
		private static FieldRef m_fldFullname = new FieldRef("psngr", "fullname");

		/// <summary>Field : "Full Name" Tipo: "C" Formula:  ""</summary>
		public string ValFullname
		{
			get { return (string)returnValueField(FldFullname); }
			set { insertNameValueField(FldFullname, value); }
		}

		/// <summary>Field : "Passport Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPassprtn { get { return m_fldPassprtn; } }
		private static FieldRef m_fldPassprtn = new FieldRef("psngr", "passprtn");

		/// <summary>Field : "Passport Number" Tipo: "C" Formula:  ""</summary>
		public string ValPassprtn
		{
			get { return (string)returnValueField(FldPassprtn); }
			set { insertNameValueField(FldPassprtn, value); }
		}

		/// <summary>Field : "Date of Birth" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldPsngrdob { get { return m_fldPsngrdob; } }
		private static FieldRef m_fldPsngrdob = new FieldRef("psngr", "psngrdob");

		/// <summary>Field : "Date of Birth" Tipo: "D" Formula:  ""</summary>
		public DateTime ValPsngrdob
		{
			get { return (DateTime)returnValueField(FldPsngrdob); }
			set { insertNameValueField(FldPsngrdob, value); }
		}

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldPaddress { get { return m_fldPaddress; } }
		private static FieldRef m_fldPaddress = new FieldRef("psngr", "paddress");

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public string ValPaddress
		{
			get { return (string)returnValueField(FldPaddress); }
			set { insertNameValueField(FldPaddress, value); }
		}

		/// <summary>Field : "Email Address" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPsemail { get { return m_fldPsemail; } }
		private static FieldRef m_fldPsemail = new FieldRef("psngr", "psemail");

		/// <summary>Field : "Email Address" Tipo: "C" Formula:  ""</summary>
		public string ValPsemail
		{
			get { return (string)returnValueField(FldPsemail); }
			set { insertNameValueField(FldPsemail, value); }
		}

		/// <summary>Field : "Contact Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCtcnumbr { get { return m_fldCtcnumbr; } }
		private static FieldRef m_fldCtcnumbr = new FieldRef("psngr", "ctcnumbr");

		/// <summary>Field : "Contact Number" Tipo: "C" Formula:  ""</summary>
		public string ValCtcnumbr
		{
			get { return (string)returnValueField(FldCtcnumbr); }
			set { insertNameValueField(FldCtcnumbr, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("psngr", "zzstate");



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
        public static CSGenioApsngr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioApsngr area = new CSGenioApsngr(user, user.CurrentModule);

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
        public static List<CSGenioApsngr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioApsngr>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioApsngr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioApsngr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX PSNGR]/

     

           

	}
}
