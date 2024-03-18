

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
	/// Table (Basic Types)
	/// </summary>
	public class CSGenioAtblb : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAtblb(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR TBLB]/
		}

		public CSGenioAtblb(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codtblb", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("fkey1", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "Foreign Key";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FOREIGN_KEY39588";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("text", FieldType.TEXTO);
			Qfield.FieldDescription = "Text";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT04938";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("textml", FieldType.MEMO);
			Qfield.FieldDescription = "Multiline Text";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MULTILINE_TEXT38013";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("numint", FieldType.NUMERO);
			Qfield.FieldDescription = "Numeric (Integer)";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NUMERIC__INTEGER_50289";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("numdec", FieldType.NUMERO);
			Qfield.FieldDescription = "Numeric (Decimal)";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "NUMERIC__DECIMAL_36157";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("curint", FieldType.VALOR);
			Qfield.FieldDescription = "Currency (Interger)";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "CURRENCY__INTERGER_21437";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("curdec", FieldType.VALOR);
			Qfield.FieldDescription = "Currency (Decimal)";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "CURRENCY__DECIMAL_11718";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("bool", FieldType.LOGICO);
			Qfield.FieldDescription = "Boolean";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BOOLEAN45002";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("date", FieldType.DATA);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("datetm", FieldType.DATAHORA);
			Qfield.FieldDescription = "DateTime (Minutes)";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATETIME__MINUTES_59352";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("datets", FieldType.DATASEGUNDO);
			Qfield.FieldDescription = "DateTime (Seconds)";
			Qfield.FieldSize =  19;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATETIME__SECONDS_49861";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("timehm", FieldType.TEMPO);
			Qfield.FieldDescription = "Time (Hours-Minutes)";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TIME__HOURS_MINUTES_01660";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("enumt", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Enumeration (Text)";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ENUMERATION__TEXT_15855";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCtypet";
            Qfield.ArrayClassName = "Typet";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("enumn", FieldType.ARRAY_COD_NUMERICO);
			Qfield.FieldDescription = "Enumeration (Numeric)";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ENUMERATION__NUMERIC44708";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNtypen";
            Qfield.ArrayClassName = "Typen";
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
			info.ParentTables.Add("grpb", new Relation("GQT", "gqttblb", "tblb", "codtblb", "fkey1", "GQT", "gqtgrpb", "grpb", "codgrpb", "codgrpb"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("grpb","grpb");
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
		/// static CSGenioAtblb()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqttblb";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codtblb";
			info.HumanKeyName="text,".TrimEnd(',');
			info.Alias="tblb";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Table (Basic Types)";
			info.AreaPluralDesignation="Tables (Basic Types)";
			info.DescriptionCav="TABLE__BASIC_TYPES_42027";

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
		public static FieldRef FldCodtblb { get { return m_fldCodtblb; } }
		private static FieldRef m_fldCodtblb = new FieldRef("tblb", "codtblb");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodtblb
		{
			get { return (string)returnValueField(FldCodtblb); }
			set { insertNameValueField(FldCodtblb, value); }
		}


		/// <summary>Field : "Foreign Key" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldFkey1 { get { return m_fldFkey1; } }
		private static FieldRef m_fldFkey1 = new FieldRef("tblb", "fkey1");

		/// <summary>Field : "Foreign Key" Tipo: "CE" Formula:  ""</summary>
		public string ValFkey1
		{
			get { return (string)returnValueField(FldFkey1); }
			set { insertNameValueField(FldFkey1, value); }
		}


		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldText { get { return m_fldText; } }
		private static FieldRef m_fldText = new FieldRef("tblb", "text");

		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValText
		{
			get { return (string)returnValueField(FldText); }
			set { insertNameValueField(FldText, value); }
		}


		/// <summary>Field : "Multiline Text" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldTextml { get { return m_fldTextml; } }
		private static FieldRef m_fldTextml = new FieldRef("tblb", "textml");

		/// <summary>Field : "Multiline Text" Tipo: "MO" Formula:  ""</summary>
		public string ValTextml
		{
			get { return (string)returnValueField(FldTextml); }
			set { insertNameValueField(FldTextml, value); }
		}


		/// <summary>Field : "Numeric (Integer)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumint { get { return m_fldNumint; } }
		private static FieldRef m_fldNumint = new FieldRef("tblb", "numint");

		/// <summary>Field : "Numeric (Integer)" Tipo: "N" Formula:  ""</summary>
		public double ValNumint
		{
			get { return (double)returnValueField(FldNumint); }
			set { insertNameValueField(FldNumint, value); }
		}


		/// <summary>Field : "Numeric (Decimal)" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldNumdec { get { return m_fldNumdec; } }
		private static FieldRef m_fldNumdec = new FieldRef("tblb", "numdec");

		/// <summary>Field : "Numeric (Decimal)" Tipo: "ND" Formula:  ""</summary>
		public double ValNumdec
		{
			get { return (double)returnValueField(FldNumdec); }
			set { insertNameValueField(FldNumdec, value); }
		}


		/// <summary>Field : "Currency (Interger)" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldCurint { get { return m_fldCurint; } }
		private static FieldRef m_fldCurint = new FieldRef("tblb", "curint");

		/// <summary>Field : "Currency (Interger)" Tipo: "$" Formula:  ""</summary>
		public double ValCurint
		{
			get { return (double)returnValueField(FldCurint); }
			set { insertNameValueField(FldCurint, value); }
		}


		/// <summary>Field : "Currency (Decimal)" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldCurdec { get { return m_fldCurdec; } }
		private static FieldRef m_fldCurdec = new FieldRef("tblb", "curdec");

		/// <summary>Field : "Currency (Decimal)" Tipo: "$D" Formula:  ""</summary>
		public double ValCurdec
		{
			get { return (double)returnValueField(FldCurdec); }
			set { insertNameValueField(FldCurdec, value); }
		}


		/// <summary>Field : "Boolean" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldBool { get { return m_fldBool; } }
		private static FieldRef m_fldBool = new FieldRef("tblb", "bool");

		/// <summary>Field : "Boolean" Tipo: "L" Formula:  ""</summary>
		public int ValBool
		{
			get { return (int)returnValueField(FldBool); }
			set { insertNameValueField(FldBool, value); }
		}


		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("tblb", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}


		/// <summary>Field : "DateTime (Minutes)" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDatetm { get { return m_fldDatetm; } }
		private static FieldRef m_fldDatetm = new FieldRef("tblb", "datetm");

		/// <summary>Field : "DateTime (Minutes)" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDatetm
		{
			get { return (DateTime)returnValueField(FldDatetm); }
			set { insertNameValueField(FldDatetm, value); }
		}


		/// <summary>Field : "DateTime (Seconds)" Tipo: "DS" Formula:  ""</summary>
		public static FieldRef FldDatets { get { return m_fldDatets; } }
		private static FieldRef m_fldDatets = new FieldRef("tblb", "datets");

		/// <summary>Field : "DateTime (Seconds)" Tipo: "DS" Formula:  ""</summary>
		public DateTime ValDatets
		{
			get { return (DateTime)returnValueField(FldDatets); }
			set { insertNameValueField(FldDatets, value); }
		}


		/// <summary>Field : "Time (Hours-Minutes)" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldTimehm { get { return m_fldTimehm; } }
		private static FieldRef m_fldTimehm = new FieldRef("tblb", "timehm");

		/// <summary>Field : "Time (Hours-Minutes)" Tipo: "T" Formula:  ""</summary>
		public string ValTimehm
		{
			get { return (string)returnValueField(FldTimehm); }
			set { insertNameValueField(FldTimehm, value); }
		}


		/// <summary>Field : "Enumeration (Text)" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldEnumt { get { return m_fldEnumt; } }
		private static FieldRef m_fldEnumt = new FieldRef("tblb", "enumt");

		/// <summary>Field : "Enumeration (Text)" Tipo: "AC" Formula:  ""</summary>
		public string ValEnumt
		{
			get { return (string)returnValueField(FldEnumt); }
			set { insertNameValueField(FldEnumt, value); }
		}


		/// <summary>Field : "Enumeration (Numeric)" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldEnumn { get { return m_fldEnumn; } }
		private static FieldRef m_fldEnumn = new FieldRef("tblb", "enumn");

		/// <summary>Field : "Enumeration (Numeric)" Tipo: "AN" Formula:  ""</summary>
		public double ValEnumn
		{
			get { return (double)returnValueField(FldEnumn); }
			set { insertNameValueField(FldEnumn, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("tblb", "zzstate");



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
        public static CSGenioAtblb search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAtblb area = new CSGenioAtblb(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAtblb> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAtblb> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAtblb>(where, user, fields);
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
        public static List<CSGenioAtblb> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAtblb>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAtblb> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAtblb>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX TBLB]/

     

                

	}
}
