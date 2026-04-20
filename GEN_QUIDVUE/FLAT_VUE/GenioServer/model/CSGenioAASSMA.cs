
 
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
	/// Asset Manual
	/// </summary>
	public class CSGenioAassma : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAassma(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ASSMA]/
		}

		public CSGenioAassma(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codassma", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codasset", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>Asset";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Manual name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MANUAL_NAME60077";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "digdocum", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Digital document";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DIGITAL_DOCUMENT59580";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field(info.Alias, "digdocumfk", FieldType.KEY_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "notes", FieldType.MEMO);
			Qfield.FieldDescription = "Notes";
			Qfield.FieldSize =  65;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "NOTES05274";

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
			info.ParentTables.Add("asset", new Relation("GQT", "gqtassetmanual", "assma", "codassma", "codasset", "GQT", "gqtasset", "asset", "codasset", "codasset"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("asset","asset");
			info.Pathways.Add("kinde","asset");
			info.Pathways.Add("manuf","asset");
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
		/// static CSGenioAassma()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtassetmanual";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codassma";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="assma";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Asset Manual";
			info.AreaPluralDesignation="Asset Manuals";
			info.DescriptionCav="ASSET_MANUAL50119";

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
			 "digdocumfk"
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
		public static FieldRef FldCodassma { get { return m_fldCodassma; } }
		private static FieldRef m_fldCodassma = new FieldRef("assma", "codassma");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodassma
		{
			get { return (string)returnValueField(FldCodassma); }
			set { insertNameValueField(FldCodassma, value); }
		}

		/// <summary>Field : ">>Asset" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodasset { get { return m_fldCodasset; } }
		private static FieldRef m_fldCodasset = new FieldRef("assma", "codasset");

		/// <summary>Field : ">>Asset" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset
		{
			get { return (string)returnValueField(FldCodasset); }
			set { insertNameValueField(FldCodasset, value); }
		}

		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("assma", "name");

		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldDigdocum { get { return m_fldDigdocum; } }
		private static FieldRef m_fldDigdocum = new FieldRef("assma", "digdocum");

		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		public string ValDigdocum
		{
			get { return (string)returnValueField(FldDigdocum); }
			set { insertNameValueField(FldDigdocum, value); }
		}

		/// <summary>Field : "Digital document FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldDigdocumfk { get { return m_fldDigdocumfk; } }
		private static FieldRef m_fldDigdocumfk = new FieldRef("assma", "digdocumfk");

		/// <summary>Field : "Digital document FK" Tipo: "CE" Formula:  ""</summary>
		public string ValDigdocumfk
		{
			get { return (string)returnValueField(FldDigdocumfk); }
			set { insertNameValueField(FldDigdocumfk, value); }
		}

		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldNotes { get { return m_fldNotes; } }
		private static FieldRef m_fldNotes = new FieldRef("assma", "notes");

		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		public string ValNotes
		{
			get { return (string)returnValueField(FldNotes); }
			set { insertNameValueField(FldNotes, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("assma", "zzstate");



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
        public static CSGenioAassma search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAassma area = new CSGenioAassma(user, user.CurrentModule);

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
        public static List<CSGenioAassma> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAassma>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAassma> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAassma>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ASSMA]/

     
      

	}
}
