
 
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
	/// Global article
	/// </summary>
	public class CSGenioAgitem : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAgitem(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR GITEM]/
		}

		public CSGenioAgitem(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codgitem", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "itemdes", FieldType.TEXT);
			Qfield.FieldDescription = "Global article";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "GLOBAL_ARTICLE63861";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "itemgcod", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  15;
			Qfield.CavDesignation = "CODE49225";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "document", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Document";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "DOCUMENT00695";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field(info.Alias, "documentfk", FieldType.KEY_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("item", new String[] {"codgitem"}, DeleteProc.NA);

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
		/// static CSGenioAgitem()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtgitem";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codgitem";
			info.HumanKeyName="itemdes,".TrimEnd(',');
			info.Alias="gitem";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Global article";
			info.AreaPluralDesignation="Global articles";
			info.DescriptionCav="GLOBAL_ARTICLE63861";

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
			info.DocumsForeignKeys = new List<String> {
			 "documentfk"
			};
			info.HasVersionManagment = true; //a true por omissão, quando o Qfield no genio tiver criado preencher por esse Qvalue

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
		public static FieldRef FldCodgitem { get { return m_fldCodgitem; } }
		private static FieldRef m_fldCodgitem = new FieldRef("gitem", "codgitem");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodgitem
		{
			get { return (string)returnValueField(FldCodgitem); }
			set { insertNameValueField(FldCodgitem, value); }
		}

		/// <summary>Field : "Global article" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldItemdes { get { return m_fldItemdes; } }
		private static FieldRef m_fldItemdes = new FieldRef("gitem", "itemdes");

		/// <summary>Field : "Global article" Tipo: "C" Formula:  ""</summary>
		public string ValItemdes
		{
			get { return (string)returnValueField(FldItemdes); }
			set { insertNameValueField(FldItemdes, value); }
		}

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldItemgcod { get { return m_fldItemgcod; } }
		private static FieldRef m_fldItemgcod = new FieldRef("gitem", "itemgcod");

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValItemgcod
		{
			get { return (string)returnValueField(FldItemgcod); }
			set { insertNameValueField(FldItemgcod, value); }
		}

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldDocument { get { return m_fldDocument; } }
		private static FieldRef m_fldDocument = new FieldRef("gitem", "document");

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public string ValDocument
		{
			get { return (string)returnValueField(FldDocument); }
			set { insertNameValueField(FldDocument, value); }
		}

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldDocumentfk { get { return m_fldDocumentfk; } }
		private static FieldRef m_fldDocumentfk = new FieldRef("gitem", "documentfk");

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public string ValDocumentfk
		{
			get { return (string)returnValueField(FldDocumentfk); }
			set { insertNameValueField(FldDocumentfk, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("gitem", "zzstate");



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
        public static CSGenioAgitem search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAgitem area = new CSGenioAgitem(user, user.CurrentModule);

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
        public static List<CSGenioAgitem> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAgitem>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAgitem> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAgitem>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX GITEM]/

     
     

	}
}
