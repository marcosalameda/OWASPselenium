

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
	/// Evolution in the category
	/// </summary>
	public class CSGenioAevcat : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAevcat(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR EVCAT]/
		}

		public CSGenioAevcat(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codprogr", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpesso", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">PERSON";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_PERSON28337";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcateg", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">CATEGORy";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_CATEGORY37591";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("since", FieldType.DATA);
			Qfield.FieldDescription = "Since";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "SINCE47259";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("untilman", FieldType.DATA);
			Qfield.FieldDescription = "Up manual";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "UP_MANUAL46500";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"until"}, new int[] {0}, "evcat", "codprogr"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.emptyD(((DateTime)args[0]))==1;
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("until", FieldType.DATA);
			Qfield.FieldDescription = "Until";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "UNTIL39173";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"untilman","until"}, new int[] {0,1}, "evcat", "codprogr"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.emptyD(((DateTime)args[0]))==1&&GlobalFunctions.emptyD(((DateTime)args[1]))==0;
			});
      Qfield.Formula = new EndPeriodFormula("since", "codpesso");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("observat", FieldType.MEMO);
			Qfield.FieldDescription = "Observation";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "OBSERVATION37880";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("fimperio", FieldType.DATA);
			Qfield.FieldDescription = "End-of-period";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "END_OF_PERIOD44616";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"untilman","untilman","until"}, new int[] {0,1,2}, "evcat", "codprogr"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 3, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==0)?(((DateTime)args[1])):(((DateTime)args[2])));
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("cate1", new Relation("GQT", "gqtevcat", "evcat", "codprogr", "codcateg", "GQT", "gqtcategorias", "cate1", "codcateg", "codcateg"));
			info.ParentTables.Add("pesso", new Relation("GQT", "gqtevcat", "evcat", "codprogr", "codpesso", "GQT", "gqtpessoas", "pesso", "codpesso", "codpesso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(6);
			info.Pathways.Add("cate1","cate1");
			info.Pathways.Add("pesso","pesso");
			info.Pathways.Add("cntry","pesso");
			info.Pathways.Add("cmpny","pesso");
			info.Pathways.Add("pais1","pesso");
			info.Pathways.Add("regi1","pesso");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			//Actualiza as seguintes rotinas de ultimo Qvalue:
			info.LastValueArgs = new List<LastValueArgument>();
			info.LastValueArgs.Add( new LastValueArgument("pesso",
				new string [] {"codcateg","dtultcat"},
				new string [] {"codcateg","since"},
				"since",
				null,

	"today", true));


			info.InternalOperationFields = new string[] {
			 "fimperio"
			};

			info.EndofPeriodFields = new string[] {
			 "until"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAevcat()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtevcat";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codprogr";
			info.HumanKeyName="since,".TrimEnd(',');
			info.Alias="evcat";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Evolution in the category";
			info.AreaPluralDesignation="Evolution in categories";
			info.DescriptionCav="EVOLUTION_IN_THE_CAT03122";

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
		public static FieldRef FldCodprogr { get { return m_fldCodprogr; } }
		private static FieldRef m_fldCodprogr = new FieldRef("evcat", "codprogr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodprogr
		{
			get { return (string)returnValueField(FldCodprogr); }
			set { insertNameValueField(FldCodprogr, value); }
		}


		/// <summary>Field : ">PERSON" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("evcat", "codpesso");

		/// <summary>Field : ">PERSON" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}


		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcateg { get { return m_fldCodcateg; } }
		private static FieldRef m_fldCodcateg = new FieldRef("evcat", "codcateg");

		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcateg
		{
			get { return (string)returnValueField(FldCodcateg); }
			set { insertNameValueField(FldCodcateg, value); }
		}


		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldSince { get { return m_fldSince; } }
		private static FieldRef m_fldSince = new FieldRef("evcat", "since");

		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		public DateTime ValSince
		{
			get { return (DateTime)returnValueField(FldSince); }
			set { insertNameValueField(FldSince, value); }
		}


		/// <summary>Field : "Up manual" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldUntilman { get { return m_fldUntilman; } }
		private static FieldRef m_fldUntilman = new FieldRef("evcat", "untilman");

		/// <summary>Field : "Up manual" Tipo: "D" Formula:  ""</summary>
		public DateTime ValUntilman
		{
			get { return (DateTime)returnValueField(FldUntilman); }
			set { insertNameValueField(FldUntilman, value); }
		}


		/// <summary>Field : "Until" Tipo: "D" Formula: FP "[EVCAT->SINCE][EVCAT->CODPESSO]"</summary>
		public static FieldRef FldUntil { get { return m_fldUntil; } }
		private static FieldRef m_fldUntil = new FieldRef("evcat", "until");

		/// <summary>Field : "Until" Tipo: "D" Formula: FP "[EVCAT->SINCE][EVCAT->CODPESSO]"</summary>
		public DateTime ValUntil
		{
			get { return (DateTime)returnValueField(FldUntil); }
			set { insertNameValueField(FldUntil, value); }
		}


		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldObservat { get { return m_fldObservat; } }
		private static FieldRef m_fldObservat = new FieldRef("evcat", "observat");

		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		public string ValObservat
		{
			get { return (string)returnValueField(FldObservat); }
			set { insertNameValueField(FldObservat, value); }
		}


		/// <summary>Field : "End-of-period" Tipo: "D" Formula: + "iif(emptyD([EVCAT->UNTILMAN])==0,[EVCAT->UNTILMAN],[EVCAT->UNTIL])"</summary>
		public static FieldRef FldFimperio { get { return m_fldFimperio; } }
		private static FieldRef m_fldFimperio = new FieldRef("evcat", "fimperio");

		/// <summary>Field : "End-of-period" Tipo: "D" Formula: + "iif(emptyD([EVCAT->UNTILMAN])==0,[EVCAT->UNTILMAN],[EVCAT->UNTIL])"</summary>
		public DateTime ValFimperio
		{
			get { return (DateTime)returnValueField(FldFimperio); }
			set { insertNameValueField(FldFimperio, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("evcat", "zzstate");



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
        public static CSGenioAevcat search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAevcat area = new CSGenioAevcat(user, user.CurrentModule);

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
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        [Obsolete("Use List<CSGenioAevcat> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAevcat> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAevcat>(where, user, fields);
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
        public static List<CSGenioAevcat> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAevcat>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAevcat> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAevcat>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX EVCAT]/

     

         

	}
}
