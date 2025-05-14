

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
	/// Warehouse
	/// </summary>
	public class CSGenioAware2 : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAware2(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR WARE2]/
		}

		public CSGenioAware2(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codwareh", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "warehdes", FieldType.TEXT);
			Qfield.FieldDescription = "Warehouse";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "WAREHOUSE51864";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "warehcod", FieldType.TEXT);
			Qfield.FieldDescription = "Acronym";
			Qfield.FieldSize =  10;
			Qfield.CavDesignation = "ACRONYM00872";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "activity", FieldType.ARRAY_LOGIC);
			Qfield.FieldDescription = "Activity";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "ACTIVITY02681";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayLactivida";
            Qfield.ArrayClassName = "Activida";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "showreco", FieldType.LOGIC);
			Qfield.FieldDescription = "Show Record";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "SHOW_RECORD11620";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "num_employee", FieldType.NUMERIC);
			Qfield.FieldDescription = "Number of employees";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "NUMBER_OF_EMPLOYEES52067";

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
			info.ChildTable[0]= new ChildRelation("wpess", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("ldent", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("item", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("outpu", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("equip", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("indoc", new String[] {"codwareh"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("outpt", new String[] {"codwareh"}, DeleteProc.NA);

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
		/// static CSGenioAware2()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtwareh";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codwareh";
			info.HumanKeyName="warehdes,".TrimEnd(',');
			info.Alias="ware2";
			info.IsDomain = false;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Warehouse";
			info.AreaPluralDesignation="Warehouses";
			info.DescriptionCav="WAREHOUSE51864";

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
		public static FieldRef FldCodwareh { get { return m_fldCodwareh; } }
		private static FieldRef m_fldCodwareh = new FieldRef("ware2", "codwareh");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodwareh
		{
			get { return (string)returnValueField(FldCodwareh); }
			set { insertNameValueField(FldCodwareh, value); }
		}

		/// <summary>Field : "Warehouse" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldWarehdes { get { return m_fldWarehdes; } }
		private static FieldRef m_fldWarehdes = new FieldRef("ware2", "warehdes");

		/// <summary>Field : "Warehouse" Tipo: "C" Formula:  ""</summary>
		public string ValWarehdes
		{
			get { return (string)returnValueField(FldWarehdes); }
			set { insertNameValueField(FldWarehdes, value); }
		}

		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldWarehcod { get { return m_fldWarehcod; } }
		private static FieldRef m_fldWarehcod = new FieldRef("ware2", "warehcod");

		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValWarehcod
		{
			get { return (string)returnValueField(FldWarehcod); }
			set { insertNameValueField(FldWarehcod, value); }
		}

		/// <summary>Field : "Activity" Tipo: "AL" Formula:  ""</summary>
		public static FieldRef FldActivity { get { return m_fldActivity; } }
		private static FieldRef m_fldActivity = new FieldRef("ware2", "activity");

		/// <summary>Field : "Activity" Tipo: "AL" Formula:  ""</summary>
		public int ValActivity
		{
			get { return (int)returnValueField(FldActivity); }
			set { insertNameValueField(FldActivity, value); }
		}

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShowreco { get { return m_fldShowreco; } }
		private static FieldRef m_fldShowreco = new FieldRef("ware2", "showreco");

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public int ValShowreco
		{
			get { return (int)returnValueField(FldShowreco); }
			set { insertNameValueField(FldShowreco, value); }
		}

		/// <summary>Field : "Number of employees" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNum_employee { get { return m_fldNum_employee; } }
		private static FieldRef m_fldNum_employee = new FieldRef("ware2", "num_employee");

		/// <summary>Field : "Number of employees" Tipo: "N" Formula:  ""</summary>
		public decimal ValNum_employee
		{
			get { return (decimal)returnValueField(FldNum_employee); }
			set { insertNameValueField(FldNum_employee, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("ware2", "zzstate");



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
        public static CSGenioAware2 search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAware2 area = new CSGenioAware2(user, user.CurrentModule);

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
        public static List<CSGenioAware2> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAware2>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAware2> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAware2>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX WARE2]/

     

       

	}
}
