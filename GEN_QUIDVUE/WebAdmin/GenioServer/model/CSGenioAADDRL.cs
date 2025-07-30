
 
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
	/// Address
	/// </summary>
	public class CSGenioAaddrl : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAaddrl(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ADDRL]/
		}

		public CSGenioAaddrl(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "customeraddressid", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "parentid", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Parent";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PARENT12107";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "parentidtypecode", FieldType.TEXT);
			Qfield.FieldDescription = "parentId Type";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PARENTID_TYPE43984";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addressnumber", FieldType.NUMERIC);
			Qfield.FieldDescription = "Address Number";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.CavDesignation = "ADDRESS_NUMBER36138";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "objecttypecode", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "Object Type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OBJECT_TYPE18115";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNobjetype";
            Qfield.ArrayClassName = "Objetype";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "objecttypecode_display", FieldType.TEXT);
			Qfield.FieldDescription = "objectTypeCode_display";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OBJECTTYPECODE_DISPL38583";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresstypecode", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "Address Type Code";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_TYPE_CODE33992";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNaddrtyco";
            Qfield.ArrayClassName = "Addrtyco";
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

			// [ADDRL->ADDRNUMB]>=0 && [ADDRL->ADDRNUMB]<=1000000000
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"addressnumber","addressnumber"},new int[] {0,1},"addrl","customeraddressid"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>=0&&((decimal)args[1])<=1000000000;
			});
			writeCondition.ErrorWarning = "minimumValue=0 and maximumValue=1000000000";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["addressnumber"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAaddrl()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtaddrl";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="customeraddressid";
			info.HumanKeyName="parentidtypecode,".TrimEnd(',');
			info.Alias="addrl";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Address";
			info.AreaPluralDesignation="Address";
			info.DescriptionCav="ADDRESS04342";

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

		/// <summary>Field : "Address" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCustomeraddressid { get { return m_fldCustomeraddressid; } }
		private static FieldRef m_fldCustomeraddressid = new FieldRef("addrl", "customeraddressid");

		/// <summary>Field : "Address" Tipo: "+" Formula:  ""</summary>
		public string ValCustomeraddressid
		{
			get { return (string)returnValueField(FldCustomeraddressid); }
			set { insertNameValueField(FldCustomeraddressid, value); }
		}

		/// <summary>Field : "Parent" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldParentid { get { return m_fldParentid; } }
		private static FieldRef m_fldParentid = new FieldRef("addrl", "parentid");

		/// <summary>Field : "Parent" Tipo: "CF" Formula:  ""</summary>
		public string ValParentid
		{
			get { return (string)returnValueField(FldParentid); }
			set { insertNameValueField(FldParentid, value); }
		}

		/// <summary>Field : "parentId Type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldParentidtypecode { get { return m_fldParentidtypecode; } }
		private static FieldRef m_fldParentidtypecode = new FieldRef("addrl", "parentidtypecode");

		/// <summary>Field : "parentId Type" Tipo: "C" Formula:  ""</summary>
		public string ValParentidtypecode
		{
			get { return (string)returnValueField(FldParentidtypecode); }
			set { insertNameValueField(FldParentidtypecode, value); }
		}

		/// <summary>Field : "Address Number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldAddressnumber { get { return m_fldAddressnumber; } }
		private static FieldRef m_fldAddressnumber = new FieldRef("addrl", "addressnumber");

		/// <summary>Field : "Address Number" Tipo: "N" Formula:  ""</summary>
		public decimal ValAddressnumber
		{
			get { return (decimal)returnValueField(FldAddressnumber); }
			set { insertNameValueField(FldAddressnumber, value); }
		}

		/// <summary>Field : "Object Type" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldObjecttypecode { get { return m_fldObjecttypecode; } }
		private static FieldRef m_fldObjecttypecode = new FieldRef("addrl", "objecttypecode");

		/// <summary>Field : "Object Type" Tipo: "AN" Formula:  ""</summary>
		public decimal ValObjecttypecode
		{
			get { return (decimal)returnValueField(FldObjecttypecode); }
			set { insertNameValueField(FldObjecttypecode, value); }
		}

		/// <summary>Field : "objectTypeCode_display" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldObjecttypecode_display { get { return m_fldObjecttypecode_display; } }
		private static FieldRef m_fldObjecttypecode_display = new FieldRef("addrl", "objecttypecode_display");

		/// <summary>Field : "objectTypeCode_display" Tipo: "C" Formula:  ""</summary>
		public string ValObjecttypecode_display
		{
			get { return (string)returnValueField(FldObjecttypecode_display); }
			set { insertNameValueField(FldObjecttypecode_display, value); }
		}

		/// <summary>Field : "Address Type Code" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldAddresstypecode { get { return m_fldAddresstypecode; } }
		private static FieldRef m_fldAddresstypecode = new FieldRef("addrl", "addresstypecode");

		/// <summary>Field : "Address Type Code" Tipo: "AN" Formula:  ""</summary>
		public decimal ValAddresstypecode
		{
			get { return (decimal)returnValueField(FldAddresstypecode); }
			set { insertNameValueField(FldAddresstypecode, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("addrl", "zzstate");



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
        public static CSGenioAaddrl search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAaddrl area = new CSGenioAaddrl(user, user.CurrentModule);

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
        public static List<CSGenioAaddrl> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAaddrl>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAaddrl> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAaddrl>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ADDRL]/

     

        

	}
}
