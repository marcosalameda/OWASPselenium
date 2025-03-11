

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
	/// Digital Attachement
	/// </summary>
	public class CSGenioAanexd : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAanexd(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR ANEXD]/
		}

		public CSGenioAanexd(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codanexd", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codequip", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dthranex", FieldType.DATAHORA);
			Qfield.FieldDescription = "Attached";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ATTACHED26247";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("title", FieldType.TEXTO);
			Qfield.FieldDescription = "Title";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TITLE21885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("document", FieldType.FICHEIRO_BD);
			Qfield.FieldDescription = "Document";
			Qfield.FieldSize =  260;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "DOCUMENT00695";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field("documentfk", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			Qfield.Alias = info.Alias;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codlang", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">LANGUAGE";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_LANGUAGE30793";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("tittradu", FieldType.TEXTO);
			Qfield.FieldDescription = "Translated title";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TRANSLATED_TITLE58577";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqttradu", "title", "atraduzi", "traduzid", SortOrder.Descending, LookupFormulaType.Previous, "codlang", "codidio2");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("referenc", FieldType.TEXTO);
			Qfield.FieldDescription = "Reference";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "REFERENCE28402";

			Qfield.Dupmsg = "";
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("equip", new Relation("GQT", "gqtanexd", "anexd", "codanexd", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
			info.ParentTables.Add("langu", new Relation("GQT", "gqtanexd", "anexd", "codanexd", "codlang", "GQT", "gqtlangu", "langu", "codlang", "codlang"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(14);
			info.Pathways.Add("langu","langu");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("tpequ","equip");
			info.Pathways.Add("room1","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("cmpny","equip");
			info.Pathways.Add("pess1","equip");
			info.Pathways.Add("famil","equip");
			info.Pathways.Add("gitem","equip");
			info.Pathways.Add("cntry","equip");
			info.Pathways.Add("stake","equip");
			info.Pathways.Add("cate2","equip");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.CheckTableFields = new string[] {
			 "tittradu"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAanexd()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtanexd";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codanexd";
			info.HumanKeyName="title,".TrimEnd(',');
			info.Alias="anexd";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Digital Attachement";
			info.AreaPluralDesignation="Digital Attachements";
			info.DescriptionCav="DIGITAL_ATTACHEMENT41252";

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
		public static FieldRef FldCodanexd { get { return m_fldCodanexd; } }
		private static FieldRef m_fldCodanexd = new FieldRef("anexd", "codanexd");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodanexd
		{
			get { return (string)returnValueField(FldCodanexd); }
			set { insertNameValueField(FldCodanexd, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("anexd", "codequip");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}

		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDthranex { get { return m_fldDthranex; } }
		private static FieldRef m_fldDthranex = new FieldRef("anexd", "dthranex");

		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDthranex
		{
			get { return (DateTime)returnValueField(FldDthranex); }
			set { insertNameValueField(FldDthranex, value); }
		}

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("anexd", "title");

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldDocument { get { return m_fldDocument; } }
		private static FieldRef m_fldDocument = new FieldRef("anexd", "document");

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public string ValDocument
		{
			get { return (string)returnValueField(FldDocument); }
			set { insertNameValueField(FldDocument, value); }
		}

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldDocumentfk { get { return m_fldDocumentfk; } }
		private static FieldRef m_fldDocumentfk = new FieldRef("anexd", "documentfk");

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public string ValDocumentfk
		{
			get { return (string)returnValueField(FldDocumentfk); }
			set { insertNameValueField(FldDocumentfk, value); }
		}

		/// <summary>Field : ">LANGUAGE" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlang { get { return m_fldCodlang; } }
		private static FieldRef m_fldCodlang = new FieldRef("anexd", "codlang");

		/// <summary>Field : ">LANGUAGE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlang
		{
			get { return (string)returnValueField(FldCodlang); }
			set { insertNameValueField(FldCodlang, value); }
		}

		/// <summary>Field : "Translated title" Tipo: "C" Formula: CT "TRADU[ANEXD->TITLE][TRADU->ATRADUZI][TRADU->TRADUZID][ANEXD->CODLANG][TRADU->CODIDIO2](DESC)"</summary>
		public static FieldRef FldTittradu { get { return m_fldTittradu; } }
		private static FieldRef m_fldTittradu = new FieldRef("anexd", "tittradu");

		/// <summary>Field : "Translated title" Tipo: "C" Formula: CT "TRADU[ANEXD->TITLE][TRADU->ATRADUZI][TRADU->TRADUZID][ANEXD->CODLANG][TRADU->CODIDIO2](DESC)"</summary>
		public string ValTittradu
		{
			get { return (string)returnValueField(FldTittradu); }
			set { insertNameValueField(FldTittradu, value); }
		}

		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldReferenc { get { return m_fldReferenc; } }
		private static FieldRef m_fldReferenc = new FieldRef("anexd", "referenc");

		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc
		{
			get { return (string)returnValueField(FldReferenc); }
			set { insertNameValueField(FldReferenc, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("anexd", "zzstate");



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
        public static CSGenioAanexd search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAanexd area = new CSGenioAanexd(user, user.CurrentModule);

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
        public static List<CSGenioAanexd> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAanexd>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAanexd> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAanexd>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX ANEXD]/

     

         

	}
}
