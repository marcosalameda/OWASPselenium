

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
	/// Lending
	/// </summary>
	public class CSGenioAlendi : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAlendi(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR LENDI]/
		}

		public CSGenioAlendi(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codlendi", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpess1", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">COMOMODOR";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_COMOMODOR01469";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "lendinnr";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codequip", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_EQUIPMENT12605";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpess2", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">DADATARY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_DADATARY21139";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("lendinnr", FieldType.NUMERO);
			Qfield.FieldDescription = "Number of lending";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NUMBER_OF_LENDING63925";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codpess1";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "lendinnr");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("start", FieldType.DATAHORA);
			Qfield.FieldDescription = "Beginning";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BEGINNING18124";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getNow);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("warndt", FieldType.DATAHORA);
			Qfield.FieldDescription = "Warning";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "WARNING52043";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"start"}, new int[] {0}, "lendi", "codlendi"));
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"frequenc"}, new int[] {1}, "equip", "codequip"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.SumDays(((DateTime)args[0]),((decimal)args[1]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("end", FieldType.DATAHORA);
			Qfield.FieldDescription = "End";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "END47577";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"warndt"}, new int[] {0}, "lendi", "codlendi"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.SumDays(((DateTime)args[0]),1);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("observat", FieldType.MEMO);
			Qfield.FieldDescription = "Observations";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "OBSERVATIONS03729";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("returndt", FieldType.DATA);
			Qfield.FieldDescription = "Return";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RETURN32222";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("returned", FieldType.LOGICO);
			Qfield.FieldDescription = "Returned";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RETURNED01606";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"returndt"}, new int[] {0}, "lendi", "codlendi"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==1)?(0):(1));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dayslimi", FieldType.NUMERO);
			Qfield.FieldDescription = "Days for return period";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "DAYS_FOR_RETURN_PERI04559";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"end","end"}, new int[] {0,1}, "lendi", "codlendi"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==1)?(0):(GlobalFunctions.Diferenca_entre_Datas(DateTime.Today,((DateTime)args[1]),"D")));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ifoutdt", FieldType.LOGICO);
			Qfield.FieldDescription = "If out of date";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "IF_OUT_OF_DATE49042";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dayslimi"}, new int[] {0}, "lendi", "codlendi"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((((decimal)args[0])<0)?(1):(0));
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
			info.ParentTables.Add("equip", new Relation("GQT", "gqtlendi", "lendi", "codlendi", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
			info.ParentTables.Add("pess1", new Relation("GQT", "gqtlendi", "lendi", "codlendi", "codpess1", "GQT", "gqtpessoas", "pess1", "codpesso", "codpesso"));
			info.ParentTables.Add("pess2", new Relation("GQT", "gqtlendi", "lendi", "codlendi", "codpess2", "GQT", "gqtpessoas", "pess2", "codpesso", "codpesso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(13);
			info.Pathways.Add("pess2","pess2");
			info.Pathways.Add("pess1","pess1");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("stake","pess2");
			info.Pathways.Add("cmpny","pess2");
			info.Pathways.Add("cntry","pess2");
			info.Pathways.Add("cate2","pess1");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("tpequ","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("famil","equip");
			info.Pathways.Add("gitem","equip");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "warndt","end","returned","dayslimi","ifoutdt"
			};

			info.DefaultValues = new string[] {
			 "start"
			};

			info.SequentialDefaultValues = new string[] {
			 "lendinnr"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAlendi()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtlendi";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codlendi";
			info.HumanKeyName="lendinnr,".TrimEnd(',');
			info.Alias="lendi";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Lending";
			info.AreaPluralDesignation="Lending";
			info.DescriptionCav="LENDING18782";

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
			EPHField[] camposEPH;
						camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("COMODANTE", "pess1", "codpesso", "=", false);
			info.Ephs.Add(new Par("REG", "1"), camposEPH);
			camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("COMODANTE", "pess1", "codpesso", "=", false);
			info.Ephs.Add(new Par("GQT", "1"), camposEPH);
			camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("COMODANTE", "pess1", "codpesso", "=", false);
			info.Ephs.Add(new Par("GQT", "20"), camposEPH);

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
		public static FieldRef FldCodlendi { get { return m_fldCodlendi; } }
		private static FieldRef m_fldCodlendi = new FieldRef("lendi", "codlendi");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlendi
		{
			get { return (string)returnValueField(FldCodlendi); }
			set { insertNameValueField(FldCodlendi, value); }
		}


		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpess1 { get { return m_fldCodpess1; } }
		private static FieldRef m_fldCodpess1 = new FieldRef("lendi", "codpess1");

		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1
		{
			get { return (string)returnValueField(FldCodpess1); }
			set { insertNameValueField(FldCodpess1, value); }
		}


		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("lendi", "codequip");

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}


		/// <summary>Field : ">DADATARY" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpess2 { get { return m_fldCodpess2; } }
		private static FieldRef m_fldCodpess2 = new FieldRef("lendi", "codpess2");

		/// <summary>Field : ">DADATARY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess2
		{
			get { return (string)returnValueField(FldCodpess2); }
			set { insertNameValueField(FldCodpess2, value); }
		}


		/// <summary>Field : "Number of lending" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldLendinnr { get { return m_fldLendinnr; } }
		private static FieldRef m_fldLendinnr = new FieldRef("lendi", "lendinnr");

		/// <summary>Field : "Number of lending" Tipo: "N" Formula:  ""</summary>
		public decimal ValLendinnr
		{
			get { return (decimal)returnValueField(FldLendinnr); }
			set { insertNameValueField(FldLendinnr, value); }
		}


		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldStart { get { return m_fldStart; } }
		private static FieldRef m_fldStart = new FieldRef("lendi", "start");

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValStart
		{
			get { return (DateTime)returnValueField(FldStart); }
			set { insertNameValueField(FldStart, value); }
		}


		/// <summary>Field : "Warning" Tipo: "DT" Formula: + "SomaDias([LENDI->START],[EQUIP->FREQUENC])"</summary>
		public static FieldRef FldWarndt { get { return m_fldWarndt; } }
		private static FieldRef m_fldWarndt = new FieldRef("lendi", "warndt");

		/// <summary>Field : "Warning" Tipo: "DT" Formula: + "SomaDias([LENDI->START],[EQUIP->FREQUENC])"</summary>
		public DateTime ValWarndt
		{
			get { return (DateTime)returnValueField(FldWarndt); }
			set { insertNameValueField(FldWarndt, value); }
		}


		/// <summary>Field : "End" Tipo: "DT" Formula: + "SomaDias([LENDI->WARNDT],1)"</summary>
		public static FieldRef FldEnd { get { return m_fldEnd; } }
		private static FieldRef m_fldEnd = new FieldRef("lendi", "end");

		/// <summary>Field : "End" Tipo: "DT" Formula: + "SomaDias([LENDI->WARNDT],1)"</summary>
		public DateTime ValEnd
		{
			get { return (DateTime)returnValueField(FldEnd); }
			set { insertNameValueField(FldEnd, value); }
		}


		/// <summary>Field : "Observations" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldObservat { get { return m_fldObservat; } }
		private static FieldRef m_fldObservat = new FieldRef("lendi", "observat");

		/// <summary>Field : "Observations" Tipo: "MO" Formula:  ""</summary>
		public string ValObservat
		{
			get { return (string)returnValueField(FldObservat); }
			set { insertNameValueField(FldObservat, value); }
		}


		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldReturndt { get { return m_fldReturndt; } }
		private static FieldRef m_fldReturndt = new FieldRef("lendi", "returndt");

		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		public DateTime ValReturndt
		{
			get { return (DateTime)returnValueField(FldReturndt); }
			set { insertNameValueField(FldReturndt, value); }
		}


		/// <summary>Field : "Returned" Tipo: "L" Formula: + "iif(emptyD([LENDI->RETURNDT])==1,0,1)"</summary>
		public static FieldRef FldReturned { get { return m_fldReturned; } }
		private static FieldRef m_fldReturned = new FieldRef("lendi", "returned");

		/// <summary>Field : "Returned" Tipo: "L" Formula: + "iif(emptyD([LENDI->RETURNDT])==1,0,1)"</summary>
		public int ValReturned
		{
			get { return (int)returnValueField(FldReturned); }
			set { insertNameValueField(FldReturned, value); }
		}


		/// <summary>Field : "Days for return period" Tipo: "N" Formula: +H "iif(emptyD([LENDI->END])==1,0,Diferenca_entre_Datas([Today],[LENDI->END],"D"))"</summary>
		public static FieldRef FldDayslimi { get { return m_fldDayslimi; } }
		private static FieldRef m_fldDayslimi = new FieldRef("lendi", "dayslimi");

		/// <summary>Field : "Days for return period" Tipo: "N" Formula: +H "iif(emptyD([LENDI->END])==1,0,Diferenca_entre_Datas([Today],[LENDI->END],"D"))"</summary>
		public decimal ValDayslimi
		{
			get { return (decimal)returnValueField(FldDayslimi); }
			set { insertNameValueField(FldDayslimi, value); }
		}


		/// <summary>Field : "If out of date" Tipo: "L" Formula: + "iif([LENDI->DAYSLIMI]<0,1,0)"</summary>
		public static FieldRef FldIfoutdt { get { return m_fldIfoutdt; } }
		private static FieldRef m_fldIfoutdt = new FieldRef("lendi", "ifoutdt");

		/// <summary>Field : "If out of date" Tipo: "L" Formula: + "iif([LENDI->DAYSLIMI]<0,1,0)"</summary>
		public int ValIfoutdt
		{
			get { return (int)returnValueField(FldIfoutdt); }
			set { insertNameValueField(FldIfoutdt, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("lendi", "zzstate");



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
        public static CSGenioAlendi search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAlendi area = new CSGenioAlendi(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAlendi> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAlendi> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAlendi>(where, user, fields);
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
        public static List<CSGenioAlendi> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAlendi>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAlendi> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAlendi>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX LENDI]/

     

              

	}
}
