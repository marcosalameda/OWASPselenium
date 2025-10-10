
 
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
	/// Dispatch
	/// </summary>
	public class CSGenioAdispa : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAdispa(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR DISPA]/
		}

		public CSGenioAdispa(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "coddispa", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codentit", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>CUSTOMER";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__CUSTOMER21546";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coddisst", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">> STATUS";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "___STATUS46938";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "isprepar", FieldType.LOGIC);
			Qfield.FieldDescription = "Is prepared";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IS_PREPARED16113";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dispadt", FieldType.DATETIME);
			Qfield.FieldDescription = "Dispatch date";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DISPATCH_DATE54413";

			Qfield.Dupmsg = "";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtdispatchline", "coddispa", "instant"));
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getNow);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dispanr", FieldType.NUMERIC);
			Qfield.FieldDescription = "Dispatch number";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "DISPATCH_NUMBER23616";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "dispanr");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prepared", FieldType.DATETIME);
			Qfield.FieldDescription = "Prepared";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PREPARED38522";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"isprepar"},new int[] {0},"dispa","coddispa"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((GenFunctions.emptyL(((int)args[0]))==1)?(DateTime.MinValue):(DateTime.Today)));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codperso", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>PERSON RESPONSIBLE";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__PERSON_RESPONSIBLE00553";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "status", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Status";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STATUS62033";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dispadt","prepared"}, new int[] {0,1}, "dispa", "coddispa"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GenFunctions.emptyD(((DateTime)args[0]))==0)?("D"):(((GenFunctions.emptyD(((DateTime)args[1]))==0)?("P"):("I"))));
			});
            Qfield.ArrayName = "dbo.GetValArrayCdispstat";
            Qfield.ArrayClassName = "Dispstat";
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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("dilin", new String[] {"coddispa"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("stock", new String[] {"coddispa"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("disst", new Relation("GQT", "gqtdispatch", "dispa", "coddispa", "coddisst", "GQT", "gqtdisst", "disst", "coddisst", "coddisst"));
			info.ParentTables.Add("entit", new Relation("GQT", "gqtdispatch", "dispa", "coddispa", "codentit", "GQT", "gqtentity", "entit", "codentit", "codentit"));
			info.ParentTables.Add("perso", new Relation("GQT", "gqtdispatch", "dispa", "coddispa", "codperso", "GQT", "gqtperson", "perso", "codperso", "codperso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(5);
			info.Pathways.Add("perso","perso");
			info.Pathways.Add("disst","disst");
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
			 "status"
			};

			info.DefaultValues = new string[] {
			 "dispadt","prepared"
			};

			info.SequentialDefaultValues = new string[] {
			 "dispanr"
			};




			info.FieldsParametersReplicas = new string[] {
			 "dispadt"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAdispa()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtdispatch";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coddispa";
			info.HumanKeyName="dispanr,".TrimEnd(',');
			info.Alias="dispa";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Dispatch";
			info.AreaPluralDesignation="Dispatches";
			info.DescriptionCav="DISPATCH46310";

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
		public static FieldRef FldCoddispa { get { return m_fldCoddispa; } }
		private static FieldRef m_fldCoddispa = new FieldRef("dispa", "coddispa");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddispa
		{
			get { return (string)returnValueField(FldCoddispa); }
			set { insertNameValueField(FldCoddispa, value); }
		}

		/// <summary>Field : ">>CUSTOMER" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodentit { get { return m_fldCodentit; } }
		private static FieldRef m_fldCodentit = new FieldRef("dispa", "codentit");

		/// <summary>Field : ">>CUSTOMER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit
		{
			get { return (string)returnValueField(FldCodentit); }
			set { insertNameValueField(FldCodentit, value); }
		}

		/// <summary>Field : ">> STATUS" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddisst { get { return m_fldCoddisst; } }
		private static FieldRef m_fldCoddisst = new FieldRef("dispa", "coddisst");

		/// <summary>Field : ">> STATUS" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddisst
		{
			get { return (string)returnValueField(FldCoddisst); }
			set { insertNameValueField(FldCoddisst, value); }
		}

		/// <summary>Field : "Is prepared" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldIsprepar { get { return m_fldIsprepar; } }
		private static FieldRef m_fldIsprepar = new FieldRef("dispa", "isprepar");

		/// <summary>Field : "Is prepared" Tipo: "L" Formula:  ""</summary>
		public int ValIsprepar
		{
			get { return (int)returnValueField(FldIsprepar); }
			set { insertNameValueField(FldIsprepar, value); }
		}

		/// <summary>Field : "Dispatch date" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDispadt { get { return m_fldDispadt; } }
		private static FieldRef m_fldDispadt = new FieldRef("dispa", "dispadt");

		/// <summary>Field : "Dispatch date" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDispadt
		{
			get { return (DateTime)returnValueField(FldDispadt); }
			set { insertNameValueField(FldDispadt, value); }
		}

		/// <summary>Field : "Dispatch number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldDispanr { get { return m_fldDispanr; } }
		private static FieldRef m_fldDispanr = new FieldRef("dispa", "dispanr");

		/// <summary>Field : "Dispatch number" Tipo: "N" Formula:  ""</summary>
		public decimal ValDispanr
		{
			get { return (decimal)returnValueField(FldDispanr); }
			set { insertNameValueField(FldDispanr, value); }
		}

		/// <summary>Field : "Prepared" Tipo: "DT" Formula: DF "iif(emptyL([DISPA->ISPREPAR])==1,[ZEROD],[Today])"</summary>
		public static FieldRef FldPrepared { get { return m_fldPrepared; } }
		private static FieldRef m_fldPrepared = new FieldRef("dispa", "prepared");

		/// <summary>Field : "Prepared" Tipo: "DT" Formula: DF "iif(emptyL([DISPA->ISPREPAR])==1,[ZEROD],[Today])"</summary>
		public DateTime ValPrepared
		{
			get { return (DateTime)returnValueField(FldPrepared); }
			set { insertNameValueField(FldPrepared, value); }
		}

		/// <summary>Field : ">>PERSON RESPONSIBLE" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodperso { get { return m_fldCodperso; } }
		private static FieldRef m_fldCodperso = new FieldRef("dispa", "codperso");

		/// <summary>Field : ">>PERSON RESPONSIBLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperso
		{
			get { return (string)returnValueField(FldCodperso); }
			set { insertNameValueField(FldCodperso, value); }
		}

		/// <summary>Field : "Status" Tipo: "AC" Formula: + "iif(emptyD([DISPA->DISPADT])==0,"D",iif(emptyD([DISPA->PREPARED])==0,"P","I"))"</summary>
		public static FieldRef FldStatus { get { return m_fldStatus; } }
		private static FieldRef m_fldStatus = new FieldRef("dispa", "status");

		/// <summary>Field : "Status" Tipo: "AC" Formula: + "iif(emptyD([DISPA->DISPADT])==0,"D",iif(emptyD([DISPA->PREPARED])==0,"P","I"))"</summary>
		public string ValStatus
		{
			get { return (string)returnValueField(FldStatus); }
			set { insertNameValueField(FldStatus, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("dispa", "zzstate");



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
        public static CSGenioAdispa search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAdispa area = new CSGenioAdispa(user, user.CurrentModule);

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
        public static List<CSGenioAdispa> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAdispa>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAdispa> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAdispa>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX DISPA]/

     
          

	}
}
