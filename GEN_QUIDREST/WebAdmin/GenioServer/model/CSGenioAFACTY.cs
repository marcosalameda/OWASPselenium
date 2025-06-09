

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
	/// Facility type
	/// </summary>
	public class CSGenioAfacty : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAfacty(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR FACTY]/
		}

		public CSGenioAfacty(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codfacty", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "type", FieldType.TEXT);
			Qfield.FieldDescription = "Facility type";
			Qfield.FieldSize =  25;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FACILITY_TYPE44577";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "layrname", FieldType.TEXT);
			Qfield.FieldDescription = "Layer name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LAYER_NAME49545";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconurl", FieldType.TEXT);
			Qfield.FieldDescription = "Icon URL";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ICON_URL07016";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shadowur", FieldType.TEXT);
			Qfield.FieldDescription = "Shadow URL";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHADOW_URL57805";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconancx", FieldType.NUMERIC);
			Qfield.FieldDescription = "Icon anchor (x-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "ICON_ANCHOR__X_AXIS_18664";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconancy", FieldType.NUMERIC);
			Qfield.FieldDescription = "Icon anchor (y-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "ICON_ANCHOR__Y_AXIS_63725";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconheig", FieldType.NUMERIC);
			Qfield.FieldDescription = "Icon height";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "ICON_HEIGHT61896";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconwid", FieldType.NUMERIC);
			Qfield.FieldDescription = "Icon width";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "ICON_WIDTH02295";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "popupanx", FieldType.NUMERIC);
			Qfield.FieldDescription = "Popup anchor (x-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "POPUP_ANCHOR__X_AXIS15060";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "popupany", FieldType.NUMERIC);
			Qfield.FieldDescription = "Popup anchor (y-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "POPUP_ANCHOR__Y_AXIS64670";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shadowax", FieldType.NUMERIC);
			Qfield.FieldDescription = "Shadow anchor (x-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "SHADOW_ANCHOR__X_AXI31230";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shadoway", FieldType.NUMERIC);
			Qfield.FieldDescription = "Shadow anchor (y-axis)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "SHADOW_ANCHOR__Y_AXI51495";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shadowhe", FieldType.NUMERIC);
			Qfield.FieldDescription = "Shadow height";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "SHADOW_HEIGHT64343";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "shadowwi", FieldType.NUMERIC);
			Qfield.FieldDescription = "Shadow width";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "SHADOW_WIDTH01769";

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
			info.ChildTable[0]= new ChildRelation("glob", new String[] {"codfacty"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("facil", new String[] {"codfacty"}, DeleteProc.NA);

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
		/// static CSGenioAfacty()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtfacilitytype";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codfacty";
			info.HumanKeyName="type,".TrimEnd(',');
			info.Alias="facty";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Facility type";
			info.AreaPluralDesignation="Facility types";
			info.DescriptionCav="FACILITY_TYPE44577";

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
		public static FieldRef FldCodfacty { get { return m_fldCodfacty; } }
		private static FieldRef m_fldCodfacty = new FieldRef("facty", "codfacty");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfacty
		{
			get { return (string)returnValueField(FldCodfacty); }
			set { insertNameValueField(FldCodfacty, value); }
		}

		/// <summary>Field : "Facility type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldType { get { return m_fldType; } }
		private static FieldRef m_fldType = new FieldRef("facty", "type");

		/// <summary>Field : "Facility type" Tipo: "C" Formula:  ""</summary>
		public string ValType
		{
			get { return (string)returnValueField(FldType); }
			set { insertNameValueField(FldType, value); }
		}

		/// <summary>Field : "Layer name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLayrname { get { return m_fldLayrname; } }
		private static FieldRef m_fldLayrname = new FieldRef("facty", "layrname");

		/// <summary>Field : "Layer name" Tipo: "C" Formula:  ""</summary>
		public string ValLayrname
		{
			get { return (string)returnValueField(FldLayrname); }
			set { insertNameValueField(FldLayrname, value); }
		}

		/// <summary>Field : "Icon URL" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIconurl { get { return m_fldIconurl; } }
		private static FieldRef m_fldIconurl = new FieldRef("facty", "iconurl");

		/// <summary>Field : "Icon URL" Tipo: "C" Formula:  ""</summary>
		public string ValIconurl
		{
			get { return (string)returnValueField(FldIconurl); }
			set { insertNameValueField(FldIconurl, value); }
		}

		/// <summary>Field : "Shadow URL" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldShadowur { get { return m_fldShadowur; } }
		private static FieldRef m_fldShadowur = new FieldRef("facty", "shadowur");

		/// <summary>Field : "Shadow URL" Tipo: "C" Formula:  ""</summary>
		public string ValShadowur
		{
			get { return (string)returnValueField(FldShadowur); }
			set { insertNameValueField(FldShadowur, value); }
		}

		/// <summary>Field : "Icon anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIconancx { get { return m_fldIconancx; } }
		private static FieldRef m_fldIconancx = new FieldRef("facty", "iconancx");

		/// <summary>Field : "Icon anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValIconancx
		{
			get { return (decimal)returnValueField(FldIconancx); }
			set { insertNameValueField(FldIconancx, value); }
		}

		/// <summary>Field : "Icon anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIconancy { get { return m_fldIconancy; } }
		private static FieldRef m_fldIconancy = new FieldRef("facty", "iconancy");

		/// <summary>Field : "Icon anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValIconancy
		{
			get { return (decimal)returnValueField(FldIconancy); }
			set { insertNameValueField(FldIconancy, value); }
		}

		/// <summary>Field : "Icon height" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIconheig { get { return m_fldIconheig; } }
		private static FieldRef m_fldIconheig = new FieldRef("facty", "iconheig");

		/// <summary>Field : "Icon height" Tipo: "N" Formula:  ""</summary>
		public decimal ValIconheig
		{
			get { return (decimal)returnValueField(FldIconheig); }
			set { insertNameValueField(FldIconheig, value); }
		}

		/// <summary>Field : "Icon width" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIconwid { get { return m_fldIconwid; } }
		private static FieldRef m_fldIconwid = new FieldRef("facty", "iconwid");

		/// <summary>Field : "Icon width" Tipo: "N" Formula:  ""</summary>
		public decimal ValIconwid
		{
			get { return (decimal)returnValueField(FldIconwid); }
			set { insertNameValueField(FldIconwid, value); }
		}

		/// <summary>Field : "Popup anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPopupanx { get { return m_fldPopupanx; } }
		private static FieldRef m_fldPopupanx = new FieldRef("facty", "popupanx");

		/// <summary>Field : "Popup anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValPopupanx
		{
			get { return (decimal)returnValueField(FldPopupanx); }
			set { insertNameValueField(FldPopupanx, value); }
		}

		/// <summary>Field : "Popup anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPopupany { get { return m_fldPopupany; } }
		private static FieldRef m_fldPopupany = new FieldRef("facty", "popupany");

		/// <summary>Field : "Popup anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValPopupany
		{
			get { return (decimal)returnValueField(FldPopupany); }
			set { insertNameValueField(FldPopupany, value); }
		}

		/// <summary>Field : "Shadow anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldShadowax { get { return m_fldShadowax; } }
		private static FieldRef m_fldShadowax = new FieldRef("facty", "shadowax");

		/// <summary>Field : "Shadow anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValShadowax
		{
			get { return (decimal)returnValueField(FldShadowax); }
			set { insertNameValueField(FldShadowax, value); }
		}

		/// <summary>Field : "Shadow anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldShadoway { get { return m_fldShadoway; } }
		private static FieldRef m_fldShadoway = new FieldRef("facty", "shadoway");

		/// <summary>Field : "Shadow anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		public decimal ValShadoway
		{
			get { return (decimal)returnValueField(FldShadoway); }
			set { insertNameValueField(FldShadoway, value); }
		}

		/// <summary>Field : "Shadow height" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldShadowhe { get { return m_fldShadowhe; } }
		private static FieldRef m_fldShadowhe = new FieldRef("facty", "shadowhe");

		/// <summary>Field : "Shadow height" Tipo: "N" Formula:  ""</summary>
		public decimal ValShadowhe
		{
			get { return (decimal)returnValueField(FldShadowhe); }
			set { insertNameValueField(FldShadowhe, value); }
		}

		/// <summary>Field : "Shadow width" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldShadowwi { get { return m_fldShadowwi; } }
		private static FieldRef m_fldShadowwi = new FieldRef("facty", "shadowwi");

		/// <summary>Field : "Shadow width" Tipo: "N" Formula:  ""</summary>
		public decimal ValShadowwi
		{
			get { return (decimal)returnValueField(FldShadowwi); }
			set { insertNameValueField(FldShadowwi, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("facty", "zzstate");



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
        public static CSGenioAfacty search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAfacty area = new CSGenioAfacty(user, user.CurrentModule);

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
        public static List<CSGenioAfacty> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAfacty>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAfacty> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAfacty>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX FACTY]/

     

                

	}
}
