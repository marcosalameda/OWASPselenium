

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
	/// Authentication options
	/// </summary>
	public class CSGenioAauthenticatopt : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAauthenticatopt(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR AUTHENTICATOPT]/
		}

		public CSGenioAauthenticatopt(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codauthenticatopt", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authvariablet", FieldType.TEXT);
			Qfield.FieldDescription = "Variable type";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VARIABLE_TYPE39289";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authvarname", FieldType.TEXT);
			Qfield.FieldDescription = "Variable name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VARIABLE_NAME27631";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authoptions", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Option";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OPTION19344";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCauthentication_options";
            Qfield.ArrayClassName = "Authentication_options";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authmvc", FieldType.LOGIC);
			Qfield.FieldDescription = "MVC";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MVC48022";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authvue", FieldType.LOGIC);
			Qfield.FieldDescription = "VUE";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VUE05393";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authnotes", FieldType.MEMO);
			Qfield.FieldDescription = "Notes";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "NOTES05274";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "authpreview", FieldType.IMAGE);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

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
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAauthenticatopt()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtauthenticatopt";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codauthenticatopt";
			info.HumanKeyName="authoptions,".TrimEnd(',');
			info.Alias="authenticatopt";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Authentication options";
			info.AreaPluralDesignation="Authentication options";
			info.DescriptionCav="AUTHENTICATION_OPTIO56668";

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
		public static FieldRef FldCodauthenticatopt { get { return m_fldCodauthenticatopt; } }
		private static FieldRef m_fldCodauthenticatopt = new FieldRef("authenticatopt", "codauthenticatopt");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodauthenticatopt
		{
			get { return (string)returnValueField(FldCodauthenticatopt); }
			set { insertNameValueField(FldCodauthenticatopt, value); }
		}

		/// <summary>Field : "Variable type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAuthvariablet { get { return m_fldAuthvariablet; } }
		private static FieldRef m_fldAuthvariablet = new FieldRef("authenticatopt", "authvariablet");

		/// <summary>Field : "Variable type" Tipo: "C" Formula:  ""</summary>
		public string ValAuthvariablet
		{
			get { return (string)returnValueField(FldAuthvariablet); }
			set { insertNameValueField(FldAuthvariablet, value); }
		}

		/// <summary>Field : "Variable name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAuthvarname { get { return m_fldAuthvarname; } }
		private static FieldRef m_fldAuthvarname = new FieldRef("authenticatopt", "authvarname");

		/// <summary>Field : "Variable name" Tipo: "C" Formula:  ""</summary>
		public string ValAuthvarname
		{
			get { return (string)returnValueField(FldAuthvarname); }
			set { insertNameValueField(FldAuthvarname, value); }
		}

		/// <summary>Field : "Option" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAuthoptions { get { return m_fldAuthoptions; } }
		private static FieldRef m_fldAuthoptions = new FieldRef("authenticatopt", "authoptions");

		/// <summary>Field : "Option" Tipo: "AC" Formula:  ""</summary>
		public string ValAuthoptions
		{
			get { return (string)returnValueField(FldAuthoptions); }
			set { insertNameValueField(FldAuthoptions, value); }
		}

		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldAuthmvc { get { return m_fldAuthmvc; } }
		private static FieldRef m_fldAuthmvc = new FieldRef("authenticatopt", "authmvc");

		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		public int ValAuthmvc
		{
			get { return (int)returnValueField(FldAuthmvc); }
			set { insertNameValueField(FldAuthmvc, value); }
		}

		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldAuthvue { get { return m_fldAuthvue; } }
		private static FieldRef m_fldAuthvue = new FieldRef("authenticatopt", "authvue");

		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		public int ValAuthvue
		{
			get { return (int)returnValueField(FldAuthvue); }
			set { insertNameValueField(FldAuthvue, value); }
		}

		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldAuthnotes { get { return m_fldAuthnotes; } }
		private static FieldRef m_fldAuthnotes = new FieldRef("authenticatopt", "authnotes");

		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		public string ValAuthnotes
		{
			get { return (string)returnValueField(FldAuthnotes); }
			set { insertNameValueField(FldAuthnotes, value); }
		}

		/// <summary>Field : "" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldAuthpreview { get { return m_fldAuthpreview; } }
		private static FieldRef m_fldAuthpreview = new FieldRef("authenticatopt", "authpreview");

		/// <summary>Field : "" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValAuthpreview
		{
			get { return (byte[])returnValueField(FldAuthpreview); }
			set { insertNameValueField(FldAuthpreview, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("authenticatopt", "zzstate");



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
        public static CSGenioAauthenticatopt search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAauthenticatopt area = new CSGenioAauthenticatopt(user, user.CurrentModule);

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
        public static List<CSGenioAauthenticatopt> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAauthenticatopt>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAauthenticatopt> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAauthenticatopt>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX AUTHENTICATOPT]/

     

         

	}
}
