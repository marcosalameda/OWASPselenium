
 
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
	public class CSGenioAaddre : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAaddre(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ADDRE]/
		}

		public CSGenioAaddre(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codaddre", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addressuse", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Address Use";
			Qfield.FieldSize =  7;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_USE16014";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaddressu";
            Qfield.ArrayClassName = "Addressu";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresstype", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Address Type";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_TYPE12455";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaddresst";
            Qfield.ArrayClassName = "Addresst";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresstext", FieldType.MEMO);
			Qfield.FieldDescription = "Entire address";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 10;
			Qfield.CavDesignation = "ENTIRE_ADDRESS64248";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresscity", FieldType.TEXT);
			Qfield.FieldDescription = "Address City";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_CITY41109";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addressdistrict", FieldType.TEXT);
			Qfield.FieldDescription = "Address District";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_DISTRICT48524";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addressstate", FieldType.TEXT);
			Qfield.FieldDescription = "Address State";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_STATE16863";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresspostalcode", FieldType.TEXT);
			Qfield.FieldDescription = "Address Postal Code";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_POSTAL_CODE41631";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "addresscountry", FieldType.TEXT);
			Qfield.FieldDescription = "Address Country";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_COUNTRY56159";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "periodstart", FieldType.DATETIME);
			Qfield.FieldDescription = "Period Start";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PERIOD_START07901";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "periodend", FieldType.DATETIME);
			Qfield.FieldDescription = "Period End";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PERIOD_END31576";

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

			// emptyC([ADDRE->ADDRUSE])==0
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"addressuse"},new int[] {0},"addre","codaddre"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return GenFunctions.emptyC(((string)args[0]))==0;
			});
			writeCondition.ErrorWarning = "Filling in this field should not be safely ignored as it may lead to misinterpretation of the information contained in the record.";
            writeCondition.Type =  ConditionType.WARNING;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["addressuse"];
			conditions.Add(writeCondition);
			}

			// emptyD([ADDRE->PERISTAR])==1 || emptyD([ADDRE->PERIEND])==1 || ComparaDatas([ADDRE->PERISTAR],[ADDRE->PERIEND])<=0
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"periodstart","periodend","periodstart","periodend"},new int[] {0,1,2,3},"addre","codaddre"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 4, delegate(object []args,User user,string module,PersistentSupport sp) {
				return GenFunctions.emptyD(((DateTime)args[0]))==1||GenFunctions.emptyD(((DateTime)args[1]))==1||GenFunctions.CompareDates(((DateTime)args[2]),((DateTime)args[3]))<=0;
			});
			writeCondition.ErrorWarning = "If present, Start SHALL have a lower value than End";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAaddre()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQP";
			info.TableName="gqpaddress";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codaddre";
			info.HumanKeyName="addressuse,".TrimEnd(',');
			info.Alias="addre";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Address";
			info.AreaPluralDesignation="Addresses";
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

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodaddre { get { return m_fldCodaddre; } }
		private static FieldRef m_fldCodaddre = new FieldRef("addre", "codaddre");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodaddre
		{
			get { return (string)returnValueField(FldCodaddre); }
			set { insertNameValueField(FldCodaddre, value); }
		}

		/// <summary>Field : "Address Use" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAddressuse { get { return m_fldAddressuse; } }
		private static FieldRef m_fldAddressuse = new FieldRef("addre", "addressuse");

		/// <summary>Field : "Address Use" Tipo: "AC" Formula:  ""</summary>
		public string ValAddressuse
		{
			get { return (string)returnValueField(FldAddressuse); }
			set { insertNameValueField(FldAddressuse, value); }
		}

		/// <summary>Field : "Address Type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAddresstype { get { return m_fldAddresstype; } }
		private static FieldRef m_fldAddresstype = new FieldRef("addre", "addresstype");

		/// <summary>Field : "Address Type" Tipo: "AC" Formula:  ""</summary>
		public string ValAddresstype
		{
			get { return (string)returnValueField(FldAddresstype); }
			set { insertNameValueField(FldAddresstype, value); }
		}

		/// <summary>Field : "Entire address" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldAddresstext { get { return m_fldAddresstext; } }
		private static FieldRef m_fldAddresstext = new FieldRef("addre", "addresstext");

		/// <summary>Field : "Entire address" Tipo: "MO" Formula:  ""</summary>
		public string ValAddresstext
		{
			get { return (string)returnValueField(FldAddresstext); }
			set { insertNameValueField(FldAddresstext, value); }
		}

		/// <summary>Field : "Address City" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAddresscity { get { return m_fldAddresscity; } }
		private static FieldRef m_fldAddresscity = new FieldRef("addre", "addresscity");

		/// <summary>Field : "Address City" Tipo: "C" Formula:  ""</summary>
		public string ValAddresscity
		{
			get { return (string)returnValueField(FldAddresscity); }
			set { insertNameValueField(FldAddresscity, value); }
		}

		/// <summary>Field : "Address District" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAddressdistrict { get { return m_fldAddressdistrict; } }
		private static FieldRef m_fldAddressdistrict = new FieldRef("addre", "addressdistrict");

		/// <summary>Field : "Address District" Tipo: "C" Formula:  ""</summary>
		public string ValAddressdistrict
		{
			get { return (string)returnValueField(FldAddressdistrict); }
			set { insertNameValueField(FldAddressdistrict, value); }
		}

		/// <summary>Field : "Address State" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAddressstate { get { return m_fldAddressstate; } }
		private static FieldRef m_fldAddressstate = new FieldRef("addre", "addressstate");

		/// <summary>Field : "Address State" Tipo: "C" Formula:  ""</summary>
		public string ValAddressstate
		{
			get { return (string)returnValueField(FldAddressstate); }
			set { insertNameValueField(FldAddressstate, value); }
		}

		/// <summary>Field : "Address Postal Code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAddresspostalcode { get { return m_fldAddresspostalcode; } }
		private static FieldRef m_fldAddresspostalcode = new FieldRef("addre", "addresspostalcode");

		/// <summary>Field : "Address Postal Code" Tipo: "C" Formula:  ""</summary>
		public string ValAddresspostalcode
		{
			get { return (string)returnValueField(FldAddresspostalcode); }
			set { insertNameValueField(FldAddresspostalcode, value); }
		}

		/// <summary>Field : "Address Country" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAddresscountry { get { return m_fldAddresscountry; } }
		private static FieldRef m_fldAddresscountry = new FieldRef("addre", "addresscountry");

		/// <summary>Field : "Address Country" Tipo: "C" Formula:  ""</summary>
		public string ValAddresscountry
		{
			get { return (string)returnValueField(FldAddresscountry); }
			set { insertNameValueField(FldAddresscountry, value); }
		}

		/// <summary>Field : "Period Start" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldPeriodstart { get { return m_fldPeriodstart; } }
		private static FieldRef m_fldPeriodstart = new FieldRef("addre", "periodstart");

		/// <summary>Field : "Period Start" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValPeriodstart
		{
			get { return (DateTime)returnValueField(FldPeriodstart); }
			set { insertNameValueField(FldPeriodstart, value); }
		}

		/// <summary>Field : "Period End" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldPeriodend { get { return m_fldPeriodend; } }
		private static FieldRef m_fldPeriodend = new FieldRef("addre", "periodend");

		/// <summary>Field : "Period End" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValPeriodend
		{
			get { return (DateTime)returnValueField(FldPeriodend); }
			set { insertNameValueField(FldPeriodend, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("addre", "zzstate");



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
        public static CSGenioAaddre search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAaddre area = new CSGenioAaddre(user, user.CurrentModule);

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
        public static List<CSGenioAaddre> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAaddre>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAaddre> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAaddre>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ADDRE]/

     
            

	}
}
