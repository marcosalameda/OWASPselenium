

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
	/// Receipt of good
	/// </summary>
	public class CSGenioArecei : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioArecei(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR RECEI]/
		}

		public CSGenioArecei(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codrecei", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codentit", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">>SUPPLIER";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__SUPPLIER62145";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("number", FieldType.NUMERO);
			Qfield.FieldDescription = "Receipt number";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RECEIPT_NUMBER31380";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "number");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtreceip", FieldType.DATAHORA);
			Qfield.FieldDescription = "Receipt date";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RECEIPT_DATE00996";

			Qfield.Dupmsg = "";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtreceiptline", "codrecei", "instant"));
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getNow);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtcheck", FieldType.DATAHORA);
			Qfield.FieldDescription = "Receipt verification";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RECEIPT_VERIFICATION62328";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("checked", FieldType.LOGICO);
			Qfield.FieldDescription = "Checked";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CHECKED31708";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dtcheck"}, new int[] {0}, "recei", "codrecei"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return (((((DateTime)args[0]) == DateTime.MinValue))?(0):(1));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("tocheck", FieldType.LOGICO);
			Qfield.FieldDescription = "To check";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TO_CHECK57511";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dtreceip","dtcheck"}, new int[] {0,1}, "recei", "codrecei"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((!(((DateTime)args[0]) == DateTime.MinValue)&&(((DateTime)args[1]) == DateTime.MinValue))?(1):(0));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("stored", FieldType.LOGICO);
			Qfield.FieldDescription = "Stored";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STORED41854";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtstorag", FieldType.DATAHORA);
			Qfield.FieldDescription = "Storage date";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STORAGE_DATE59954";

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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("relin", new String[] {"codrecei"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("stock", new String[] {"codrecei"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("entit", new Relation("GQT", "gqtreceipt", "recei", "codrecei", "codentit", "GQT", "gqtentity", "entit", "codentit", "codentit"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("entit","entit");
			info.Pathways.Add("faci1","entit");
			info.Pathways.Add("faci2","entit");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "checked","tocheck"
			};

			info.DefaultValues = new string[] {
			 "dtreceip"
			};

			info.SequentialDefaultValues = new string[] {
			 "number"
			};




			info.FieldsParametersReplicas = new string[] {
			 "dtreceip"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioArecei()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtreceipt";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codrecei";
			info.HumanKeyName="number,".TrimEnd(',');
			info.Alias="recei";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Receipt of good";
			info.AreaPluralDesignation="Receipts of goods";
			info.DescriptionCav="RECEIPT_OF_GOOD16561";

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
		public static FieldRef FldCodrecei { get { return m_fldCodrecei; } }
		private static FieldRef m_fldCodrecei = new FieldRef("recei", "codrecei");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrecei
		{
			get { return (string)returnValueField(FldCodrecei); }
			set { insertNameValueField(FldCodrecei, value); }
		}


		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodentit { get { return m_fldCodentit; } }
		private static FieldRef m_fldCodentit = new FieldRef("recei", "codentit");

		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit
		{
			get { return (string)returnValueField(FldCodentit); }
			set { insertNameValueField(FldCodentit, value); }
		}


		/// <summary>Field : "Receipt number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumber { get { return m_fldNumber; } }
		private static FieldRef m_fldNumber = new FieldRef("recei", "number");

		/// <summary>Field : "Receipt number" Tipo: "N" Formula:  ""</summary>
		public decimal ValNumber
		{
			get { return (decimal)returnValueField(FldNumber); }
			set { insertNameValueField(FldNumber, value); }
		}


		/// <summary>Field : "Receipt date" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtreceip { get { return m_fldDtreceip; } }
		private static FieldRef m_fldDtreceip = new FieldRef("recei", "dtreceip");

		/// <summary>Field : "Receipt date" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtreceip
		{
			get { return (DateTime)returnValueField(FldDtreceip); }
			set { insertNameValueField(FldDtreceip, value); }
		}


		/// <summary>Field : "Receipt verification" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtcheck { get { return m_fldDtcheck; } }
		private static FieldRef m_fldDtcheck = new FieldRef("recei", "dtcheck");

		/// <summary>Field : "Receipt verification" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtcheck
		{
			get { return (DateTime)returnValueField(FldDtcheck); }
			set { insertNameValueField(FldDtcheck, value); }
		}


		/// <summary>Field : "Checked" Tipo: "L" Formula: + "iif(isEmptyD([RECEI->DTCHECK]),0,1)"</summary>
		public static FieldRef FldChecked { get { return m_fldChecked; } }
		private static FieldRef m_fldChecked = new FieldRef("recei", "checked");

		/// <summary>Field : "Checked" Tipo: "L" Formula: + "iif(isEmptyD([RECEI->DTCHECK]),0,1)"</summary>
		public int ValChecked
		{
			get { return (int)returnValueField(FldChecked); }
			set { insertNameValueField(FldChecked, value); }
		}


		/// <summary>Field : "To check" Tipo: "L" Formula: + "iif(!isEmptyD([RECEI->DTRECEIP]) && isEmptyD([RECEI->DTCHECK]),1,0)"</summary>
		public static FieldRef FldTocheck { get { return m_fldTocheck; } }
		private static FieldRef m_fldTocheck = new FieldRef("recei", "tocheck");

		/// <summary>Field : "To check" Tipo: "L" Formula: + "iif(!isEmptyD([RECEI->DTRECEIP]) && isEmptyD([RECEI->DTCHECK]),1,0)"</summary>
		public int ValTocheck
		{
			get { return (int)returnValueField(FldTocheck); }
			set { insertNameValueField(FldTocheck, value); }
		}


		/// <summary>Field : "Stored" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldStored { get { return m_fldStored; } }
		private static FieldRef m_fldStored = new FieldRef("recei", "stored");

		/// <summary>Field : "Stored" Tipo: "L" Formula:  ""</summary>
		public int ValStored
		{
			get { return (int)returnValueField(FldStored); }
			set { insertNameValueField(FldStored, value); }
		}


		/// <summary>Field : "Storage date" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtstorag { get { return m_fldDtstorag; } }
		private static FieldRef m_fldDtstorag = new FieldRef("recei", "dtstorag");

		/// <summary>Field : "Storage date" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtstorag
		{
			get { return (DateTime)returnValueField(FldDtstorag); }
			set { insertNameValueField(FldDtstorag, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("recei", "zzstate");



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
        public static CSGenioArecei search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioArecei area = new CSGenioArecei(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioArecei> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioArecei> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioArecei>(where, user, fields);
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
        public static List<CSGenioArecei> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioArecei>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioArecei> listing)
        {
			sp.searchListAdvancedWhere<CSGenioArecei>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX RECEI]/

     

          

	}
}
