
 
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
	/// Attachment
	/// </summary>
	public class CSGenioAattac : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAattac(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ATTAC]/
		}

		public CSGenioAattac(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codattac", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codasset", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>ASSET";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "attached", FieldType.DATETIME);
			Qfield.FieldDescription = "Attached";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ATTACHED26247";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "note", FieldType.MEMO);
			Qfield.FieldDescription = "Note";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "NOTE54557";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "document", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Document";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("asset", new Relation("GQT", "gqtattachment", "attac", "codattac", "codasset", "GQT", "gqtasset", "asset", "codasset", "codasset"));
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
		/// static CSGenioAattac()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtattachment";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codattac";
			info.HumanKeyName="attached,".TrimEnd(',');
			info.Alias="attac";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Attachment";
			info.AreaPluralDesignation="Attachments";
			info.DescriptionCav="ATTACHMENT29376";

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
		public static FieldRef FldCodattac { get { return m_fldCodattac; } }
		private static FieldRef m_fldCodattac = new FieldRef("attac", "codattac");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodattac
		{
			get { return (string)returnValueField(FldCodattac); }
			set { insertNameValueField(FldCodattac, value); }
		}

		/// <summary>Field : ">>ASSET" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodasset { get { return m_fldCodasset; } }
		private static FieldRef m_fldCodasset = new FieldRef("attac", "codasset");

		/// <summary>Field : ">>ASSET" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset
		{
			get { return (string)returnValueField(FldCodasset); }
			set { insertNameValueField(FldCodasset, value); }
		}

		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldAttached { get { return m_fldAttached; } }
		private static FieldRef m_fldAttached = new FieldRef("attac", "attached");

		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValAttached
		{
			get { return (DateTime)returnValueField(FldAttached); }
			set { insertNameValueField(FldAttached, value); }
		}

		/// <summary>Field : "Note" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldNote { get { return m_fldNote; } }
		private static FieldRef m_fldNote = new FieldRef("attac", "note");

		/// <summary>Field : "Note" Tipo: "MO" Formula:  ""</summary>
		public string ValNote
		{
			get { return (string)returnValueField(FldNote); }
			set { insertNameValueField(FldNote, value); }
		}

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldDocument { get { return m_fldDocument; } }
		private static FieldRef m_fldDocument = new FieldRef("attac", "document");

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public string ValDocument
		{
			get { return (string)returnValueField(FldDocument); }
			set { insertNameValueField(FldDocument, value); }
		}

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldDocumentfk { get { return m_fldDocumentfk; } }
		private static FieldRef m_fldDocumentfk = new FieldRef("attac", "documentfk");

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public string ValDocumentfk
		{
			get { return (string)returnValueField(FldDocumentfk); }
			set { insertNameValueField(FldDocumentfk, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("attac", "zzstate");



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
        public static CSGenioAattac search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAattac area = new CSGenioAattac(user, user.CurrentModule);

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
        public static List<CSGenioAattac> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAattac>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAattac> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAattac>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ATTAC]/

     
      

	}
}
