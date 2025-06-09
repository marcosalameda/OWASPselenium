

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
	/// Space
	/// </summary>
	public class CSGenioAspace : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAspace(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR SPACE]/
		}

		public CSGenioAspace(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codespac", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "code", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "CODE49225";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.DesignationField = "space.code";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "designat", FieldType.TEXT);
			Qfield.FieldDescription = "Designation";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "DESIGNATION35876";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sigla", FieldType.TEXT);
			Qfield.FieldDescription = "Acronym";
			Qfield.FieldSize =  10;
			Qfield.CavDesignation = "ACRONYM00872";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nivel", FieldType.NUMERIC);
			Qfield.FieldDescription = "Level";
			Qfield.FieldSize =  3;
			Qfield.CavDesignation = "LEVEL06184";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.RecordLevelField = "space.nivel";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codigode", FieldType.TEXT);
			Qfield.FieldDescription = "Dependency";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "DEPENDENCY54251";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.ParentTableField = "space.codigode";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "moviment", FieldType.LOGIC);
			Qfield.FieldDescription = "Moving";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "MOVING46562";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.MoveableField = "space.moviment";

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
		/// static CSGenioAspace()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtspace";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codespac";
			info.HumanKeyName="designat,".TrimEnd(',');
			info.Alias="space";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Space";
			info.AreaPluralDesignation="Spaces";
			info.DescriptionCav="SPACE62433";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();




			info.TreeTable = new TreeTable();

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
		public static FieldRef FldCodespac { get { return m_fldCodespac; } }
		private static FieldRef m_fldCodespac = new FieldRef("space", "codespac");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodespac
		{
			get { return (string)returnValueField(FldCodespac); }
			set { insertNameValueField(FldCodespac, value); }
		}

		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public static FieldRef FldCode { get { return m_fldCode; } }
		private static FieldRef m_fldCode = new FieldRef("space", "code");

		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public string ValCode
		{
			get { return (string)returnValueField(FldCode); }
			set { insertNameValueField(FldCode, value); }
		}

		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("space", "designat");

		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}

		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSigla { get { return m_fldSigla; } }
		private static FieldRef m_fldSigla = new FieldRef("space", "sigla");

		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValSigla
		{
			get { return (string)returnValueField(FldSigla); }
			set { insertNameValueField(FldSigla, value); }
		}

		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public static FieldRef FldNivel { get { return m_fldNivel; } }
		private static FieldRef m_fldNivel = new FieldRef("space", "nivel");

		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public decimal ValNivel
		{
			get { return (decimal)returnValueField(FldNivel); }
			set { insertNameValueField(FldNivel, value); }
		}

		/// <summary>Field : "Dependency" Tipo: "TP" Formula:  ""</summary>
		public static FieldRef FldCodigode { get { return m_fldCodigode; } }
		private static FieldRef m_fldCodigode = new FieldRef("space", "codigode");

		/// <summary>Field : "Dependency" Tipo: "TP" Formula:  ""</summary>
		public string ValCodigode
		{
			get { return (string)returnValueField(FldCodigode); }
			set { insertNameValueField(FldCodigode, value); }
		}

		/// <summary>Field : "Moving" Tipo: "TM" Formula:  ""</summary>
		public static FieldRef FldMoviment { get { return m_fldMoviment; } }
		private static FieldRef m_fldMoviment = new FieldRef("space", "moviment");

		/// <summary>Field : "Moving" Tipo: "TM" Formula:  ""</summary>
		public int ValMoviment
		{
			get { return (int)returnValueField(FldMoviment); }
			set { insertNameValueField(FldMoviment, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("space", "zzstate");



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
        public static CSGenioAspace search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAspace area = new CSGenioAspace(user, user.CurrentModule);

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
        public static List<CSGenioAspace> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAspace>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAspace> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAspace>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX SPACE]/

     

        

	}
}
