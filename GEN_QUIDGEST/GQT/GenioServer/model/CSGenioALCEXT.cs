

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
	/// Location Extension Component
	/// </summary>
	public class CSGenioAlcext : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAlcext(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR LCEXT]/
		}

		public CSGenioAlcext(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codlcext", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codlocat", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("glnext", FieldType.TEXTO);
			Qfield.FieldDescription = "GLN Extension Component";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GLN_EXTENSION_COMPON55869";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("spacetyp", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Space type";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SPACE_TYPE42493";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCspacetyp";
            Qfield.ArrayClassName = "Spacetyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("spaceobs", FieldType.TEXTO);
			Qfield.FieldDescription = "Space";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SPACE62433";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"spacetyp"}, new int[] {0}, "lcext", "codlcext"));
			Qfield.FillWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="O";
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"spacetyp"}, new int[] {0}, "lcext", "codlcext"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="O";
			});
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("produ", new String[] {"codlcext"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("locat", new Relation("GQT", "gqtlocationextension", "lcext", "codlcext", "codlocat", "GQT", "gqtlocation", "locat", "codlocat", "codlocat"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(7);
			info.Pathways.Add("locat","locat");
			info.Pathways.Add("facil","locat");
			info.Pathways.Add("entit","locat");
			info.Pathways.Add("facty","locat");
			info.Pathways.Add("cntry","locat");
			info.Pathways.Add("faci1","locat");
			info.Pathways.Add("faci2","locat");
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
		/// static CSGenioAlcext()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtlocationextension";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codlcext";
			info.HumanKeyName="glnext,".TrimEnd(',');
			info.Alias="lcext";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Location Extension Component";
			info.AreaPluralDesignation="Location Extension Components";
			info.DescriptionCav="LOCATION_EXTENSION_C10932";

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
		public static FieldRef FldCodlcext { get { return m_fldCodlcext; } }
		private static FieldRef m_fldCodlcext = new FieldRef("lcext", "codlcext");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlcext
		{
			get { return (string)returnValueField(FldCodlcext); }
			set { insertNameValueField(FldCodlcext, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlocat { get { return m_fldCodlocat; } }
		private static FieldRef m_fldCodlocat = new FieldRef("lcext", "codlocat");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlocat
		{
			get { return (string)returnValueField(FldCodlocat); }
			set { insertNameValueField(FldCodlocat, value); }
		}

		/// <summary>Field : "GLN Extension Component" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldGlnext { get { return m_fldGlnext; } }
		private static FieldRef m_fldGlnext = new FieldRef("lcext", "glnext");

		/// <summary>Field : "GLN Extension Component" Tipo: "C" Formula:  ""</summary>
		public string ValGlnext
		{
			get { return (string)returnValueField(FldGlnext); }
			set { insertNameValueField(FldGlnext, value); }
		}

		/// <summary>Field : "Space type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldSpacetyp { get { return m_fldSpacetyp; } }
		private static FieldRef m_fldSpacetyp = new FieldRef("lcext", "spacetyp");

		/// <summary>Field : "Space type" Tipo: "AC" Formula:  ""</summary>
		public string ValSpacetyp
		{
			get { return (string)returnValueField(FldSpacetyp); }
			set { insertNameValueField(FldSpacetyp, value); }
		}

		/// <summary>Field : "Space" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSpaceobs { get { return m_fldSpaceobs; } }
		private static FieldRef m_fldSpaceobs = new FieldRef("lcext", "spaceobs");

		/// <summary>Field : "Space" Tipo: "C" Formula:  ""</summary>
		public string ValSpaceobs
		{
			get { return (string)returnValueField(FldSpaceobs); }
			set { insertNameValueField(FldSpaceobs, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("lcext", "zzstate");



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
        public static CSGenioAlcext search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAlcext area = new CSGenioAlcext(user, user.CurrentModule);

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
        public static List<CSGenioAlcext> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAlcext>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAlcext> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAlcext>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX LCEXT]/

     

      

	}
}
