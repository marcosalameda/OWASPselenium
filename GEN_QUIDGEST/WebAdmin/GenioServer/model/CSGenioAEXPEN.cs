

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
	/// Expense
	/// </summary>
	public class CSGenioAexpen : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAexpen(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR EXPEN]/
		}

		public CSGenioAexpen(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("coddespe", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codproje", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">PROJECT";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_PROJECT36907";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codyear", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">ANO";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_ANO30092";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("yearnumb", FieldType.NUMERO);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "YEAR61794";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"yearnum"}, new int[] {0}, "year", "codyear"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((double)args[0]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("yearprev", FieldType.NUMERO);
			Qfield.FieldDescription = "Previous year";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PREVIOUS_YEAR11345";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"yearnum"}, new int[] {0}, "year", "codyear"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((double)args[0])-1;
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codaggre", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">AGREGADOR";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_AGREGADOR29397";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("descript", FieldType.TEXTO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("value", FieldType.VALOR);
			Qfield.FieldDescription = "Value";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "VALUE10285";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("prevval", FieldType.VALOR);
			Qfield.FieldDescription = "Previous Value";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PREVIOUS_VALUE30042";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtexpen", "yearprev", "yearnumb", "value", SortOrder.Descending, LookupFormulaType.Previous);
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
			info.ParentTables.Add("agreg", new Relation("GQT", "gqtexpen", "expen", "coddespe", "codaggre", "GQT", "gqtagreg", "agreg", "codaggre", "codaggre"));
			info.ParentTables.Add("proje", new Relation("GQT", "gqtexpen", "expen", "coddespe", "codproje", "GQT", "gqtproje", "proje", "codproje", "codproje"));
			info.ParentTables.Add("year", new Relation("GQT", "gqtexpen", "expen", "coddespe", "codyear", "GQT", "gqtyear", "year", "codyear", "codyear"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("year","year");
			info.Pathways.Add("proje","proje");
			info.Pathways.Add("agreg","agreg");
			info.Pathways.Add("year1","proje");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("expen", "agreg", "value", "value", '+', true));


			//Actualiza as seguintes somas que criam registos:
			info.SumCreateRecords = new SumsCreatesRecords[1];

			info.SumCreateRecords[0] = new SumsCreatesRecords("gqtagreg", "agreg", "codaggre", "codaggre", new string[]{"codproje","codyear"}, new string[]{"codproje","codyear"});
			info.ObtainAllFields = new string[] {"codproje","codyear"};

			info.CheckTableFields = new string[] {
			 "prevval"
			};

			info.InternalOperationFields = new string[] {
			 "yearnumb","yearprev"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAexpen()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtexpen";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coddespe";
			info.HumanKeyName="descript,".TrimEnd(',');
			info.Alias="expen";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Expense";
			info.AreaPluralDesignation="Expenses";
			info.DescriptionCav="EXPENSE49437";

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
		public static FieldRef FldCoddespe { get { return m_fldCoddespe; } }
		private static FieldRef m_fldCoddespe = new FieldRef("expen", "coddespe");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddespe
		{
			get { return (string)returnValueField(FldCoddespe); }
			set { insertNameValueField(FldCoddespe, value); }
		}


		/// <summary>Field : ">PROJECT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodproje { get { return m_fldCodproje; } }
		private static FieldRef m_fldCodproje = new FieldRef("expen", "codproje");

		/// <summary>Field : ">PROJECT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodproje
		{
			get { return (string)returnValueField(FldCodproje); }
			set { insertNameValueField(FldCodproje, value); }
		}


		/// <summary>Field : ">ANO" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodyear { get { return m_fldCodyear; } }
		private static FieldRef m_fldCodyear = new FieldRef("expen", "codyear");

		/// <summary>Field : ">ANO" Tipo: "CE" Formula:  ""</summary>
		public string ValCodyear
		{
			get { return (string)returnValueField(FldCodyear); }
			set { insertNameValueField(FldCodyear, value); }
		}


		/// <summary>Field : "Year" Tipo: "N" Formula: + "[YEAR->YEARNUM]"</summary>
		public static FieldRef FldYearnumb { get { return m_fldYearnumb; } }
		private static FieldRef m_fldYearnumb = new FieldRef("expen", "yearnumb");

		/// <summary>Field : "Year" Tipo: "N" Formula: + "[YEAR->YEARNUM]"</summary>
		public double ValYearnumb
		{
			get { return (double)returnValueField(FldYearnumb); }
			set { insertNameValueField(FldYearnumb, value); }
		}


		/// <summary>Field : "Previous year" Tipo: "N" Formula: + "[YEAR->YEARNUM]-1"</summary>
		public static FieldRef FldYearprev { get { return m_fldYearprev; } }
		private static FieldRef m_fldYearprev = new FieldRef("expen", "yearprev");

		/// <summary>Field : "Previous year" Tipo: "N" Formula: + "[YEAR->YEARNUM]-1"</summary>
		public double ValYearprev
		{
			get { return (double)returnValueField(FldYearprev); }
			set { insertNameValueField(FldYearprev, value); }
		}


		/// <summary>Field : ">AGREGADOR" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodaggre { get { return m_fldCodaggre; } }
		private static FieldRef m_fldCodaggre = new FieldRef("expen", "codaggre");

		/// <summary>Field : ">AGREGADOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodaggre
		{
			get { return (string)returnValueField(FldCodaggre); }
			set { insertNameValueField(FldCodaggre, value); }
		}


		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("expen", "descript");

		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}


		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldValue { get { return m_fldValue; } }
		private static FieldRef m_fldValue = new FieldRef("expen", "value");

		/// <summary>Field : "Value" Tipo: "$D" Formula:  ""</summary>
		public double ValValue
		{
			get { return (double)returnValueField(FldValue); }
			set { insertNameValueField(FldValue, value); }
		}


		/// <summary>Field : "Previous Value" Tipo: "$D" Formula: CT "EXPE1[EXPEN->YEARPREV][EXPE1->YEARNUMB][EXPE1->VALUE](DESC)"</summary>
		public static FieldRef FldPrevval { get { return m_fldPrevval; } }
		private static FieldRef m_fldPrevval = new FieldRef("expen", "prevval");

		/// <summary>Field : "Previous Value" Tipo: "$D" Formula: CT "EXPE1[EXPEN->YEARPREV][EXPE1->YEARNUMB][EXPE1->VALUE](DESC)"</summary>
		public double ValPrevval
		{
			get { return (double)returnValueField(FldPrevval); }
			set { insertNameValueField(FldPrevval, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("expen", "zzstate");



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
        public static CSGenioAexpen search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAexpen area = new CSGenioAexpen(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAexpen> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAexpen> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAexpen>(where, user, fields);
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
        public static List<CSGenioAexpen> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAexpen>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAexpen> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAexpen>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX EXPEN]/

     

          

	}
}
