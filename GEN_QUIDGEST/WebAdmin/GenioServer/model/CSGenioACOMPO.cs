
 
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
	/// Component type
	/// </summary>
	public class CSGenioAcompo : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAcompo(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR COMPO]/
		}

		public CSGenioAcompo(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codcompo", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codcompc", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Components Class";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COMPONENTS_CLASS59339";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "release", FieldType.NUMERIC);
			Qfield.FieldDescription = "Release version";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "RELEASE_VERSION03981";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "compdesc", FieldType.MEMO);
			Qfield.FieldDescription = "Component description";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "COMPONENT_DESCRIPTIO08871";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "preview", FieldType.IMAGE);
			Qfield.FieldDescription = "Preview";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PREVIEW45357";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "comptype", FieldType.TEXT);
			Qfield.FieldDescription = "Component type";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COMPONENT_TYPE41163";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "compinte", FieldType.TEXT);
			Qfield.FieldDescription = "Interaction";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "INTERACTION46097";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "compbeha", FieldType.MEMO);
			Qfield.FieldDescription = "Behaviour";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "BEHAVIOUR57826";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "compvari", FieldType.TEXT);
			Qfield.FieldDescription = "Variants";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VARIANTS59281";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "vardescr", FieldType.MEMO);
			Qfield.FieldDescription = "Variant Description";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "VARIANT_DESCRIPTION11900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "wuse", FieldType.MEMO);
			Qfield.FieldDescription = "When to use";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "WHEN_TO_USE63699";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "wnuse", FieldType.MEMO);
			Qfield.FieldDescription = "When not to use";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "WHEN_NOT_TO_USE63828";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "vuemvc", FieldType.LOGIC);
			Qfield.FieldDescription = "VUE";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VUE05393";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "mvc", FieldType.LOGIC);
			Qfield.FieldDescription = "MVC";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MVC48022";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "accessib", FieldType.MEMO);
			Qfield.FieldDescription = "Accesibilty Compliance & Best Practices";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.Decimals = 8;
			Qfield.CavDesignation = "ACCESIBILTY_COMPLIAN11604";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cdatatyp", FieldType.TEXT);
			Qfield.FieldDescription = "Data type";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATA_TYPE47159";

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
			info.ParentTables.Add("compc", new Relation("GQT", "gqtcompo", "compo", "codcompo", "codcompc", "GQT", "gqtcompc", "compc", "codcompc", "codcompc"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("compc","compc");
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
		/// static CSGenioAcompo()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtcompo";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codcompo";
			info.HumanKeyName="comptype,".TrimEnd(',');
			info.Alias="compo";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Component type";
			info.AreaPluralDesignation="Component type";
			info.DescriptionCav="COMPONENT_TYPE41163";

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
		public static FieldRef FldCodcompo { get { return m_fldCodcompo; } }
		private static FieldRef m_fldCodcompo = new FieldRef("compo", "codcompo");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcompo
		{
			get { return (string)returnValueField(FldCodcompo); }
			set { insertNameValueField(FldCodcompo, value); }
		}

		/// <summary>Field : "Components Class" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcompc { get { return m_fldCodcompc; } }
		private static FieldRef m_fldCodcompc = new FieldRef("compo", "codcompc");

		/// <summary>Field : "Components Class" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcompc
		{
			get { return (string)returnValueField(FldCodcompc); }
			set { insertNameValueField(FldCodcompc, value); }
		}

		/// <summary>Field : "Release version" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldRelease { get { return m_fldRelease; } }
		private static FieldRef m_fldRelease = new FieldRef("compo", "release");

		/// <summary>Field : "Release version" Tipo: "N" Formula:  ""</summary>
		public decimal ValRelease
		{
			get { return (decimal)returnValueField(FldRelease); }
			set { insertNameValueField(FldRelease, value); }
		}

		/// <summary>Field : "Component description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldCompdesc { get { return m_fldCompdesc; } }
		private static FieldRef m_fldCompdesc = new FieldRef("compo", "compdesc");

		/// <summary>Field : "Component description" Tipo: "MO" Formula:  ""</summary>
		public string ValCompdesc
		{
			get { return (string)returnValueField(FldCompdesc); }
			set { insertNameValueField(FldCompdesc, value); }
		}

		/// <summary>Field : "Preview" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPreview { get { return m_fldPreview; } }
		private static FieldRef m_fldPreview = new FieldRef("compo", "preview");

		/// <summary>Field : "Preview" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPreview
		{
			get { return (byte[])returnValueField(FldPreview); }
			set { insertNameValueField(FldPreview, value); }
		}

		/// <summary>Field : "Component type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldComptype { get { return m_fldComptype; } }
		private static FieldRef m_fldComptype = new FieldRef("compo", "comptype");

		/// <summary>Field : "Component type" Tipo: "C" Formula:  ""</summary>
		public string ValComptype
		{
			get { return (string)returnValueField(FldComptype); }
			set { insertNameValueField(FldComptype, value); }
		}

		/// <summary>Field : "Interaction" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCompinte { get { return m_fldCompinte; } }
		private static FieldRef m_fldCompinte = new FieldRef("compo", "compinte");

		/// <summary>Field : "Interaction" Tipo: "C" Formula:  ""</summary>
		public string ValCompinte
		{
			get { return (string)returnValueField(FldCompinte); }
			set { insertNameValueField(FldCompinte, value); }
		}

		/// <summary>Field : "Behaviour" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldCompbeha { get { return m_fldCompbeha; } }
		private static FieldRef m_fldCompbeha = new FieldRef("compo", "compbeha");

		/// <summary>Field : "Behaviour" Tipo: "MO" Formula:  ""</summary>
		public string ValCompbeha
		{
			get { return (string)returnValueField(FldCompbeha); }
			set { insertNameValueField(FldCompbeha, value); }
		}

		/// <summary>Field : "Variants" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCompvari { get { return m_fldCompvari; } }
		private static FieldRef m_fldCompvari = new FieldRef("compo", "compvari");

		/// <summary>Field : "Variants" Tipo: "C" Formula:  ""</summary>
		public string ValCompvari
		{
			get { return (string)returnValueField(FldCompvari); }
			set { insertNameValueField(FldCompvari, value); }
		}

		/// <summary>Field : "Variant Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldVardescr { get { return m_fldVardescr; } }
		private static FieldRef m_fldVardescr = new FieldRef("compo", "vardescr");

		/// <summary>Field : "Variant Description" Tipo: "MO" Formula:  ""</summary>
		public string ValVardescr
		{
			get { return (string)returnValueField(FldVardescr); }
			set { insertNameValueField(FldVardescr, value); }
		}

		/// <summary>Field : "When to use" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldWuse { get { return m_fldWuse; } }
		private static FieldRef m_fldWuse = new FieldRef("compo", "wuse");

		/// <summary>Field : "When to use" Tipo: "MO" Formula:  ""</summary>
		public string ValWuse
		{
			get { return (string)returnValueField(FldWuse); }
			set { insertNameValueField(FldWuse, value); }
		}

		/// <summary>Field : "When not to use" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldWnuse { get { return m_fldWnuse; } }
		private static FieldRef m_fldWnuse = new FieldRef("compo", "wnuse");

		/// <summary>Field : "When not to use" Tipo: "MO" Formula:  ""</summary>
		public string ValWnuse
		{
			get { return (string)returnValueField(FldWnuse); }
			set { insertNameValueField(FldWnuse, value); }
		}

		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldVuemvc { get { return m_fldVuemvc; } }
		private static FieldRef m_fldVuemvc = new FieldRef("compo", "vuemvc");

		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		public int ValVuemvc
		{
			get { return (int)returnValueField(FldVuemvc); }
			set { insertNameValueField(FldVuemvc, value); }
		}

		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMvc { get { return m_fldMvc; } }
		private static FieldRef m_fldMvc = new FieldRef("compo", "mvc");

		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		public int ValMvc
		{
			get { return (int)returnValueField(FldMvc); }
			set { insertNameValueField(FldMvc, value); }
		}

		/// <summary>Field : "Accesibilty Compliance & Best Practices" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldAccessib { get { return m_fldAccessib; } }
		private static FieldRef m_fldAccessib = new FieldRef("compo", "accessib");

		/// <summary>Field : "Accesibilty Compliance & Best Practices" Tipo: "MO" Formula:  ""</summary>
		public string ValAccessib
		{
			get { return (string)returnValueField(FldAccessib); }
			set { insertNameValueField(FldAccessib, value); }
		}

		/// <summary>Field : "Data type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCdatatyp { get { return m_fldCdatatyp; } }
		private static FieldRef m_fldCdatatyp = new FieldRef("compo", "cdatatyp");

		/// <summary>Field : "Data type" Tipo: "C" Formula:  ""</summary>
		public string ValCdatatyp
		{
			get { return (string)returnValueField(FldCdatatyp); }
			set { insertNameValueField(FldCdatatyp, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("compo", "zzstate");



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
        public static CSGenioAcompo search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAcompo area = new CSGenioAcompo(user, user.CurrentModule);

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
        public static List<CSGenioAcompo> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAcompo>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAcompo> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAcompo>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX COMPO]/

     
                 

	}
}
