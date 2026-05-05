

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
	/// User Feedback
	/// </summary>
	public class CSGenioAufeedback : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAufeedback(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR UFEEDBACK]/
		}

		public CSGenioAufeedback(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codufeedback", FieldType.KEY_GUID);
			Qfield.FieldDescription = "CODUFEEDBACK";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sfeedback", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "feedback";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FEEDBACK36998";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNfeedback";
            Qfield.ArrayClassName = "Feedback";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "feedbcoment", FieldType.MEMO);
			Qfield.FieldDescription = "Comments";
			Qfield.FieldSize =  80;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "COMMENTS30895";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codfeedbacktype", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconrating", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "icon rating";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ICON_RATING50574";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNiconrating";
            Qfield.ArrayClassName = "Iconrating";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quickfeedback", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "quick feedback";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "QUICK_FEEDBACK30835";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCquickfeedback";
            Qfield.ArrayClassName = "Quickfeedback";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "servicefeedback", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "SERVICE FEEDBACK";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SERVICE_FEEDBACK32323";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCareatecn";
            Qfield.ArrayClassName = "Areatecn";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "servicetype", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "SERVICE TYPE";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SERVICE_TYPE52940";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCservicetype";
            Qfield.ArrayClassName = "Servicetype";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "feedbackdate", FieldType.DATETIME);
			Qfield.FieldDescription = "FEEDBACK DATE";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FEEDBACK_DATE28454";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return DateTime.Now;
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "feedbfile", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Files";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FILES64557";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field(info.Alias, "feedbfilefk", FieldType.KEY_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "usefulfeedb", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "USEFULFEEDB";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "USEFULFEEDB16828";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNusefulfeedb";
            Qfield.ArrayClassName = "Usefulfeedb";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "logicalfeedb", FieldType.LOGIC);
			Qfield.FieldDescription = "The information is hard to understand";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "THE_INFORMATION_IS_H08002";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "moredetlogic", FieldType.LOGIC);
			Qfield.FieldDescription = "Need more details";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NEED_MORE_DETAILS27800";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "logicfeed", FieldType.LOGIC);
			Qfield.FieldDescription = "I can't find what I'm looking for";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "I_CAN_T_FIND_WHAT_I_33456";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "languagelogic", FieldType.LOGIC);
			Qfield.FieldDescription = "I'd like to have more information in my language";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "I_D_LIKE_TO_HAVE_MOR23763";

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
			info.ParentTables.Add("feedbacktype", new Relation("GQT", "gqtufeedback", "ufeedback", "codufeedback", "codfeedbacktype", "GQT", "gqtfeedbacktype", "feedbacktype", "codfeedbacktype", "codfeedbacktype"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("feedbacktype","feedbacktype");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "feedbackdate"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAufeedback()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtufeedback";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codufeedback";
			info.HumanKeyName="";
			info.Alias="ufeedback";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="User Feedback";
			info.AreaPluralDesignation="User Feedback";
			info.DescriptionCav="USER_FEEDBACK45000";

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
			 "feedbfilefk"
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

		/// <summary>Field : "CODUFEEDBACK" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodufeedback { get { return m_fldCodufeedback; } }
		private static FieldRef m_fldCodufeedback = new FieldRef("ufeedback", "codufeedback");

		/// <summary>Field : "CODUFEEDBACK" Tipo: "+" Formula:  ""</summary>
		public string ValCodufeedback
		{
			get { return (string)returnValueField(FldCodufeedback); }
			set { insertNameValueField(FldCodufeedback, value); }
		}

		/// <summary>Field : "feedback" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldSfeedback { get { return m_fldSfeedback; } }
		private static FieldRef m_fldSfeedback = new FieldRef("ufeedback", "sfeedback");

		/// <summary>Field : "feedback" Tipo: "AN" Formula:  ""</summary>
		public decimal ValSfeedback
		{
			get { return (decimal)returnValueField(FldSfeedback); }
			set { insertNameValueField(FldSfeedback, value); }
		}

		/// <summary>Field : "Comments" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldFeedbcoment { get { return m_fldFeedbcoment; } }
		private static FieldRef m_fldFeedbcoment = new FieldRef("ufeedback", "feedbcoment");

		/// <summary>Field : "Comments" Tipo: "MO" Formula:  ""</summary>
		public string ValFeedbcoment
		{
			get { return (string)returnValueField(FldFeedbcoment); }
			set { insertNameValueField(FldFeedbcoment, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodfeedbacktype { get { return m_fldCodfeedbacktype; } }
		private static FieldRef m_fldCodfeedbacktype = new FieldRef("ufeedback", "codfeedbacktype");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfeedbacktype
		{
			get { return (string)returnValueField(FldCodfeedbacktype); }
			set { insertNameValueField(FldCodfeedbacktype, value); }
		}

		/// <summary>Field : "icon rating" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldIconrating { get { return m_fldIconrating; } }
		private static FieldRef m_fldIconrating = new FieldRef("ufeedback", "iconrating");

		/// <summary>Field : "icon rating" Tipo: "AN" Formula:  ""</summary>
		public decimal ValIconrating
		{
			get { return (decimal)returnValueField(FldIconrating); }
			set { insertNameValueField(FldIconrating, value); }
		}

		/// <summary>Field : "quick feedback" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldQuickfeedback { get { return m_fldQuickfeedback; } }
		private static FieldRef m_fldQuickfeedback = new FieldRef("ufeedback", "quickfeedback");

		/// <summary>Field : "quick feedback" Tipo: "AC" Formula:  ""</summary>
		public string ValQuickfeedback
		{
			get { return (string)returnValueField(FldQuickfeedback); }
			set { insertNameValueField(FldQuickfeedback, value); }
		}

		/// <summary>Field : "SERVICE FEEDBACK" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldServicefeedback { get { return m_fldServicefeedback; } }
		private static FieldRef m_fldServicefeedback = new FieldRef("ufeedback", "servicefeedback");

		/// <summary>Field : "SERVICE FEEDBACK" Tipo: "AC" Formula:  ""</summary>
		public string ValServicefeedback
		{
			get { return (string)returnValueField(FldServicefeedback); }
			set { insertNameValueField(FldServicefeedback, value); }
		}

		/// <summary>Field : "SERVICE TYPE" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldServicetype { get { return m_fldServicetype; } }
		private static FieldRef m_fldServicetype = new FieldRef("ufeedback", "servicetype");

		/// <summary>Field : "SERVICE TYPE" Tipo: "AC" Formula:  ""</summary>
		public string ValServicetype
		{
			get { return (string)returnValueField(FldServicetype); }
			set { insertNameValueField(FldServicetype, value); }
		}

		/// <summary>Field : "FEEDBACK DATE" Tipo: "DT" Formula: + "[Now]"</summary>
		public static FieldRef FldFeedbackdate { get { return m_fldFeedbackdate; } }
		private static FieldRef m_fldFeedbackdate = new FieldRef("ufeedback", "feedbackdate");

		/// <summary>Field : "FEEDBACK DATE" Tipo: "DT" Formula: + "[Now]"</summary>
		public DateTime ValFeedbackdate
		{
			get { return (DateTime)returnValueField(FldFeedbackdate); }
			set { insertNameValueField(FldFeedbackdate, value); }
		}

		/// <summary>Field : "Files" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldFeedbfile { get { return m_fldFeedbfile; } }
		private static FieldRef m_fldFeedbfile = new FieldRef("ufeedback", "feedbfile");

		/// <summary>Field : "Files" Tipo: "IB" Formula:  ""</summary>
		public string ValFeedbfile
		{
			get { return (string)returnValueField(FldFeedbfile); }
			set { insertNameValueField(FldFeedbfile, value); }
		}

		/// <summary>Field : "Files FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldFeedbfilefk { get { return m_fldFeedbfilefk; } }
		private static FieldRef m_fldFeedbfilefk = new FieldRef("ufeedback", "feedbfilefk");

		/// <summary>Field : "Files FK" Tipo: "CE" Formula:  ""</summary>
		public string ValFeedbfilefk
		{
			get { return (string)returnValueField(FldFeedbfilefk); }
			set { insertNameValueField(FldFeedbfilefk, value); }
		}

		/// <summary>Field : "USEFULFEEDB" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldUsefulfeedb { get { return m_fldUsefulfeedb; } }
		private static FieldRef m_fldUsefulfeedb = new FieldRef("ufeedback", "usefulfeedb");

		/// <summary>Field : "USEFULFEEDB" Tipo: "AN" Formula:  ""</summary>
		public decimal ValUsefulfeedb
		{
			get { return (decimal)returnValueField(FldUsefulfeedb); }
			set { insertNameValueField(FldUsefulfeedb, value); }
		}

		/// <summary>Field : "The information is hard to understand" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldLogicalfeedb { get { return m_fldLogicalfeedb; } }
		private static FieldRef m_fldLogicalfeedb = new FieldRef("ufeedback", "logicalfeedb");

		/// <summary>Field : "The information is hard to understand" Tipo: "L" Formula:  ""</summary>
		public int ValLogicalfeedb
		{
			get { return (int)returnValueField(FldLogicalfeedb); }
			set { insertNameValueField(FldLogicalfeedb, value); }
		}

		/// <summary>Field : "Need more details" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMoredetlogic { get { return m_fldMoredetlogic; } }
		private static FieldRef m_fldMoredetlogic = new FieldRef("ufeedback", "moredetlogic");

		/// <summary>Field : "Need more details" Tipo: "L" Formula:  ""</summary>
		public int ValMoredetlogic
		{
			get { return (int)returnValueField(FldMoredetlogic); }
			set { insertNameValueField(FldMoredetlogic, value); }
		}

		/// <summary>Field : "I can't find what I'm looking for" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldLogicfeed { get { return m_fldLogicfeed; } }
		private static FieldRef m_fldLogicfeed = new FieldRef("ufeedback", "logicfeed");

		/// <summary>Field : "I can't find what I'm looking for" Tipo: "L" Formula:  ""</summary>
		public int ValLogicfeed
		{
			get { return (int)returnValueField(FldLogicfeed); }
			set { insertNameValueField(FldLogicfeed, value); }
		}

		/// <summary>Field : "I'd like to have more information in my language" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldLanguagelogic { get { return m_fldLanguagelogic; } }
		private static FieldRef m_fldLanguagelogic = new FieldRef("ufeedback", "languagelogic");

		/// <summary>Field : "I'd like to have more information in my language" Tipo: "L" Formula:  ""</summary>
		public int ValLanguagelogic
		{
			get { return (int)returnValueField(FldLanguagelogic); }
			set { insertNameValueField(FldLanguagelogic, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("ufeedback", "zzstate");



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
        public static CSGenioAufeedback search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAufeedback area = new CSGenioAufeedback(user, user.CurrentModule);

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
        public static List<CSGenioAufeedback> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAufeedback>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAufeedback> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAufeedback>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX UFEEDBACK]/

     

                

	}
}
