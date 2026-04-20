
 
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
	/// Disaggregation line
	/// </summary>
	public class CSGenioAlnhde : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAlnhde(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR LNHDE]/
		}

		public CSGenioAlnhde(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codlnhde", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codlnhpd", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codpedid", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_codlnhpd", "codpedid");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ordem", FieldType.NUMERIC);
			Qfield.FieldDescription = "Order";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "ORDER39632";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codpedid";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "ordem");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtpequ", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantida", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(1);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codlnhag", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "code", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CODE49225";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "url", FieldType.TEXT);
			Qfield.FieldDescription = "Site";
			Qfield.FieldSize =  250;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SITE06486";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantdec", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"quantdec"},new int[] {0},"lnhpd","codlnhpd"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((decimal)args[0]));
			}));

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
			info.ChildTable[0]= new ChildRelation("lnhdf", new String[] {"codlnhde"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("lnhag", new Relation("GQT", "gqtlnhde", "lnhde", "codlnhde", "codlnhag", "GQT", "gqtlnhag", "lnhag", "codlnhag", "codlnhag"));
			info.ParentTables.Add("lnhpd", new Relation("GQT", "gqtlnhde", "lnhde", "codlnhde", "codlnhpd", "GQT", "gqtlnhpd", "lnhpd", "codlnhpd", "codlnhpd"));
			info.ParentTables.Add("pedid", new Relation("GQT", "gqtlnhde", "lnhde", "codlnhde", "codpedid", "GQT", "gqtpedid", "pedid", "codpedid", "codpedid"));
			info.ParentTables.Add("tpeq1", new Relation("GQT", "gqtlnhde", "lnhde", "codlnhde", "codtpequ", "GQT", "gqttpequ", "tpeq1", "codtpequ", "codtpequ"));
			info.ParentTables.Add("_replicRel_codlnhpd", new Relation("GQT", "gqtlnhde", "lnhde", "codlnhde", "codlnhpd", "GQT", "gqtlnhpd", "lnhpd", "codlnhpd", "codlnhpd"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(7);
			info.Pathways.Add("pedid","pedid");
			info.Pathways.Add("tpeq1","tpeq1");
			info.Pathways.Add("lnhpd","lnhpd");
			info.Pathways.Add("lnhag","lnhag");
			info.Pathways.Add("fami1","tpeq1");
			info.Pathways.Add("tpequ","lnhpd");
			info.Pathways.Add("famil","lnhpd");
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
			info.RelatedSumArgs.Add( new RelatedSumArgument("lnhde", "lnhag", "qtdtpequ", "quantida", '+', true));


			//Actualiza as seguintes somas que criam registos:
			info.SumCreateRecords = new SumsCreatesRecords[1];

			info.SumCreateRecords[0] = new SumsCreatesRecords("gqtlnhag", "lnhag", "codlnhag", "codlnhag", new string[]{"codpedid","codtpequ"}, new string[]{"codpedid","codtpequ"});
			info.ObtainAllFields = new string[] {"codpedid","codtpequ"};

			info.ReplicaFields = new string[] {
			 "codpedid"
			};

			info.DefaultValues = new string[] {
			 "quantida","quantdec"
			};

			info.SequentialDefaultValues = new string[] {
			 "ordem"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAlnhde()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtlnhde";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codlnhde";
			info.HumanKeyName="ordem,".TrimEnd(',');
			info.Alias="lnhde";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Disaggregation line";
			info.AreaPluralDesignation="Disaggregation lines";
			info.DescriptionCav="DISAGGREGATION_LINE06730";

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
		public static FieldRef FldCodlnhde { get { return m_fldCodlnhde; } }
		private static FieldRef m_fldCodlnhde = new FieldRef("lnhde", "codlnhde");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlnhde
		{
			get { return (string)returnValueField(FldCodlnhde); }
			set { insertNameValueField(FldCodlnhde, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlnhpd { get { return m_fldCodlnhpd; } }
		private static FieldRef m_fldCodlnhpd = new FieldRef("lnhde", "codlnhpd");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlnhpd
		{
			get { return (string)returnValueField(FldCodlnhpd); }
			set { insertNameValueField(FldCodlnhpd, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula: ++ "[LNHPD->CODPEDID]"</summary>
		public static FieldRef FldCodpedid { get { return m_fldCodpedid; } }
		private static FieldRef m_fldCodpedid = new FieldRef("lnhde", "codpedid");

		/// <summary>Field : "" Tipo: "CE" Formula: ++ "[LNHPD->CODPEDID]"</summary>
		public string ValCodpedid
		{
			get { return (string)returnValueField(FldCodpedid); }
			set { insertNameValueField(FldCodpedid, value); }
		}

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrdem { get { return m_fldOrdem; } }
		private static FieldRef m_fldOrdem = new FieldRef("lnhde", "ordem");

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrdem
		{
			get { return (decimal)returnValueField(FldOrdem); }
			set { insertNameValueField(FldOrdem, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("lnhde", "codtpequ");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantida { get { return m_fldQuantida; } }
		private static FieldRef m_fldQuantida = new FieldRef("lnhde", "quantida");

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantida
		{
			get { return (decimal)returnValueField(FldQuantida); }
			set { insertNameValueField(FldQuantida, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlnhag { get { return m_fldCodlnhag; } }
		private static FieldRef m_fldCodlnhag = new FieldRef("lnhde", "codlnhag");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlnhag
		{
			get { return (string)returnValueField(FldCodlnhag); }
			set { insertNameValueField(FldCodlnhag, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("lnhde", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCode { get { return m_fldCode; } }
		private static FieldRef m_fldCode = new FieldRef("lnhde", "code");

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValCode
		{
			get { return (string)returnValueField(FldCode); }
			set { insertNameValueField(FldCode, value); }
		}

		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldUrl { get { return m_fldUrl; } }
		private static FieldRef m_fldUrl = new FieldRef("lnhde", "url");

		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		public string ValUrl
		{
			get { return (string)returnValueField(FldUrl); }
			set { insertNameValueField(FldUrl, value); }
		}

		/// <summary>Field : "Amount" Tipo: "ND" Formula: DF "[LNHPD->QUANTDEC]"</summary>
		public static FieldRef FldQuantdec { get { return m_fldQuantdec; } }
		private static FieldRef m_fldQuantdec = new FieldRef("lnhde", "quantdec");

		/// <summary>Field : "Amount" Tipo: "ND" Formula: DF "[LNHPD->QUANTDEC]"</summary>
		public decimal ValQuantdec
		{
			get { return (decimal)returnValueField(FldQuantdec); }
			set { insertNameValueField(FldQuantdec, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("lnhde", "zzstate");



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
        public static CSGenioAlnhde search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAlnhde area = new CSGenioAlnhde(user, user.CurrentModule);

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
        public static List<CSGenioAlnhde> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAlnhde>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAlnhde> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAlnhde>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX LNHDE]/

     
            

	}
}
