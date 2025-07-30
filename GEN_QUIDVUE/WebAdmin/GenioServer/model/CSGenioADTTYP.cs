
 
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
	/// Data type
	/// </summary>
	public class CSGenioAdttyp : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAdttyp(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR DTTYP]/
		}

		public CSGenioAdttyp(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "coddttyp", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "string", FieldType.TEXT);
			Qfield.FieldDescription = "string";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STRING29433";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "uuid", FieldType.TEXT);
			Qfield.FieldDescription = "UUID (aka GUID)";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UUID__AKA_GUID_13998";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "uppercas", FieldType.TEXT);
			Qfield.FieldDescription = "Upper case";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPPER_CASE31324";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateUP(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "qrcode", FieldType.TEXT);
			Qfield.FieldDescription = "QR Code";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "QR_CODE12259";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"string"}, new int[] {0}, "dttyp", "coddttyp"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "multilin", FieldType.MEMO);
			Qfield.FieldDescription = "Multiline text";
			Qfield.FieldSize =  60;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "MULTILINE_TEXT57254";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "multili3", FieldType.MEMO);
			Qfield.FieldDescription = "Multiline text (Text editor)";
			Qfield.FieldSize =  60;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "MULTILINE_TEXT__TEXT35132";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "boolean", FieldType.LOGIC);
			Qfield.FieldDescription = "Logical (tinyint) (storage 1 byte)";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LOGICAL__TINYINT___S49012";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "boolean2", FieldType.NUMERIC);
			Qfield.FieldDescription = "Conditional (smallint) (storage: 2 byte)";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CONDITIONAL__SMALLIN41010";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smallint", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numeric  4.0 - small integer (storage: 2 byte)";
			Qfield.FieldSize =  4;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 4;
			Qfield.CavDesignation = "NUMERIC__4_0___SMALL21475";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "integer", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numeric  9.0 - integer (storage: 4 byte)";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.CavDesignation = "NUMERIC__9_0___INTEG03994";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bigint", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numeric 15.0 - big integer (storage: 8 byte)";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "NUMERIC_15_0___BIG_I46007";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "real", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "NUMERIC__8_2_REAL_FL21391";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "float", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "NUMERIC_15_2_DOUBLE_11443";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "decimal", FieldType.NUMERIC);
			Qfield.FieldDescription = "Decimal (1-10) (storage: 5 byte)";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "DECIMAL__1_10___STOR64402";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "decimal9", FieldType.NUMERIC);
			Qfield.FieldDescription = "Decimal (11-15) (storage: 9 byte)";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "DECIMAL__11_15___STO64707";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "money", FieldType.CURRENCY);
			Qfield.FieldDescription = "Money - decimal (1-10) (storage: 5 byte)";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "MONEY___DECIMAL__1_124403";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "money9", FieldType.CURRENCY);
			Qfield.FieldDescription = "Money - decimal (11-15) (storage: 9 byte)";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "MONEY___DECIMAL__11_02101";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATE);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "datetime", FieldType.DATETIME);
			Qfield.FieldDescription = "Date Time";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_TIME53960";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtsesond", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Date Time Second";
			Qfield.FieldSize =  19;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_TIME_SECOND45106";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "time", FieldType.TIME_HOURS);
			Qfield.FieldDescription = "Time";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TIME15328";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "start", FieldType.DATETIME);
			Qfield.FieldDescription = "Starting time with inclusive boundary";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STARTING_TIME_WITH_I44217";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "end", FieldType.DATETIME);
			Qfield.FieldDescription = "End time with inclusive boundary, if not ongoing";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "END_TIME_WITH_INCLUS19241";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "image", FieldType.IMAGE);
			Qfield.FieldDescription = "Image (binary)";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE__BINARY_46903";

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
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "qrcode"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAdttyp()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtdatatypes";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coddttyp";
			info.HumanKeyName="string,".TrimEnd(',');
			info.Alias="dttyp";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Data type";
			info.AreaPluralDesignation="Data types";
			info.DescriptionCav="DATA_TYPE47159";

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
            info.QLevel.AlterAlways = Role.ROLE_1;
            info.QLevel.RemoveAlways = Role.ROLE_1;

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
		public static FieldRef FldCoddttyp { get { return m_fldCoddttyp; } }
		private static FieldRef m_fldCoddttyp = new FieldRef("dttyp", "coddttyp");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddttyp
		{
			get { return (string)returnValueField(FldCoddttyp); }
			set { insertNameValueField(FldCoddttyp, value); }
		}

		/// <summary>Field : "string" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldString { get { return m_fldString; } }
		private static FieldRef m_fldString = new FieldRef("dttyp", "string");

		/// <summary>Field : "string" Tipo: "C" Formula:  ""</summary>
		public string ValString
		{
			get { return (string)returnValueField(FldString); }
			set { insertNameValueField(FldString, value); }
		}

		/// <summary>Field : "UUID (aka GUID)" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldUuid { get { return m_fldUuid; } }
		private static FieldRef m_fldUuid = new FieldRef("dttyp", "uuid");

		/// <summary>Field : "UUID (aka GUID)" Tipo: "C" Formula:  ""</summary>
		public string ValUuid
		{
			get { return (string)returnValueField(FldUuid); }
			set { insertNameValueField(FldUuid, value); }
		}

		/// <summary>Field : "Upper case" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldUppercas { get { return m_fldUppercas; } }
		private static FieldRef m_fldUppercas = new FieldRef("dttyp", "uppercas");

		/// <summary>Field : "Upper case" Tipo: "C" Formula:  ""</summary>
		public string ValUppercas
		{
			get { return (string)returnValueField(FldUppercas); }
			set { insertNameValueField(FldUppercas, value); }
		}

		/// <summary>Field : "QR Code" Tipo: "C" Formula: + "[DTTYP->STRING]"</summary>
		public static FieldRef FldQrcode { get { return m_fldQrcode; } }
		private static FieldRef m_fldQrcode = new FieldRef("dttyp", "qrcode");

		/// <summary>Field : "QR Code" Tipo: "C" Formula: + "[DTTYP->STRING]"</summary>
		public string ValQrcode
		{
			get { return (string)returnValueField(FldQrcode); }
			set { insertNameValueField(FldQrcode, value); }
		}

		/// <summary>Field : "Multiline text" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldMultilin { get { return m_fldMultilin; } }
		private static FieldRef m_fldMultilin = new FieldRef("dttyp", "multilin");

		/// <summary>Field : "Multiline text" Tipo: "MO" Formula:  ""</summary>
		public string ValMultilin
		{
			get { return (string)returnValueField(FldMultilin); }
			set { insertNameValueField(FldMultilin, value); }
		}

		/// <summary>Field : "Multiline text (Text editor)" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldMultili3 { get { return m_fldMultili3; } }
		private static FieldRef m_fldMultili3 = new FieldRef("dttyp", "multili3");

		/// <summary>Field : "Multiline text (Text editor)" Tipo: "MO" Formula:  ""</summary>
		public string ValMultili3
		{
			get { return (string)returnValueField(FldMultili3); }
			set { insertNameValueField(FldMultili3, value); }
		}

		/// <summary>Field : "Logical (tinyint) (storage 1 byte)" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldBoolean { get { return m_fldBoolean; } }
		private static FieldRef m_fldBoolean = new FieldRef("dttyp", "boolean");

		/// <summary>Field : "Logical (tinyint) (storage 1 byte)" Tipo: "L" Formula:  ""</summary>
		public int ValBoolean
		{
			get { return (int)returnValueField(FldBoolean); }
			set { insertNameValueField(FldBoolean, value); }
		}

		/// <summary>Field : "Conditional (smallint) (storage: 2 byte)" Tipo: "IF" Formula:  ""</summary>
		public static FieldRef FldBoolean2 { get { return m_fldBoolean2; } }
		private static FieldRef m_fldBoolean2 = new FieldRef("dttyp", "boolean2");

		/// <summary>Field : "Conditional (smallint) (storage: 2 byte)" Tipo: "IF" Formula:  ""</summary>
		public decimal ValBoolean2
		{
			get { return (decimal)returnValueField(FldBoolean2); }
			set { insertNameValueField(FldBoolean2, value); }
		}

		/// <summary>Field : "Numeric  4.0 - small integer (storage: 2 byte)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSmallint { get { return m_fldSmallint; } }
		private static FieldRef m_fldSmallint = new FieldRef("dttyp", "smallint");

		/// <summary>Field : "Numeric  4.0 - small integer (storage: 2 byte)" Tipo: "N" Formula:  ""</summary>
		public decimal ValSmallint
		{
			get { return (decimal)returnValueField(FldSmallint); }
			set { insertNameValueField(FldSmallint, value); }
		}

		/// <summary>Field : "Numeric  9.0 - integer (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldInteger { get { return m_fldInteger; } }
		private static FieldRef m_fldInteger = new FieldRef("dttyp", "integer");

		/// <summary>Field : "Numeric  9.0 - integer (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		public decimal ValInteger
		{
			get { return (decimal)returnValueField(FldInteger); }
			set { insertNameValueField(FldInteger, value); }
		}

		/// <summary>Field : "Numeric 15.0 - big integer (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBigint { get { return m_fldBigint; } }
		private static FieldRef m_fldBigint = new FieldRef("dttyp", "bigint");

		/// <summary>Field : "Numeric 15.0 - big integer (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		public decimal ValBigint
		{
			get { return (decimal)returnValueField(FldBigint); }
			set { insertNameValueField(FldBigint, value); }
		}

		/// <summary>Field : "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldReal { get { return m_fldReal; } }
		private static FieldRef m_fldReal = new FieldRef("dttyp", "real");

		/// <summary>Field : "Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)" Tipo: "N" Formula:  ""</summary>
		public decimal ValReal
		{
			get { return (decimal)returnValueField(FldReal); }
			set { insertNameValueField(FldReal, value); }
		}

		/// <summary>Field : "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldFloat { get { return m_fldFloat; } }
		private static FieldRef m_fldFloat = new FieldRef("dttyp", "float");

		/// <summary>Field : "Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)" Tipo: "N" Formula:  ""</summary>
		public decimal ValFloat
		{
			get { return (decimal)returnValueField(FldFloat); }
			set { insertNameValueField(FldFloat, value); }
		}

		/// <summary>Field : "Decimal (1-10) (storage: 5 byte)" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldDecimal { get { return m_fldDecimal; } }
		private static FieldRef m_fldDecimal = new FieldRef("dttyp", "decimal");

		/// <summary>Field : "Decimal (1-10) (storage: 5 byte)" Tipo: "ND" Formula:  ""</summary>
		public decimal ValDecimal
		{
			get { return (decimal)returnValueField(FldDecimal); }
			set { insertNameValueField(FldDecimal, value); }
		}

		/// <summary>Field : "Decimal (11-15) (storage: 9 byte)" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldDecimal9 { get { return m_fldDecimal9; } }
		private static FieldRef m_fldDecimal9 = new FieldRef("dttyp", "decimal9");

		/// <summary>Field : "Decimal (11-15) (storage: 9 byte)" Tipo: "ND" Formula:  ""</summary>
		public decimal ValDecimal9
		{
			get { return (decimal)returnValueField(FldDecimal9); }
			set { insertNameValueField(FldDecimal9, value); }
		}

		/// <summary>Field : "Money - decimal (1-10) (storage: 5 byte)" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldMoney { get { return m_fldMoney; } }
		private static FieldRef m_fldMoney = new FieldRef("dttyp", "money");

		/// <summary>Field : "Money - decimal (1-10) (storage: 5 byte)" Tipo: "$D" Formula:  ""</summary>
		public decimal ValMoney
		{
			get { return (decimal)returnValueField(FldMoney); }
			set { insertNameValueField(FldMoney, value); }
		}

		/// <summary>Field : "Money - decimal (11-15) (storage: 9 byte)" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldMoney9 { get { return m_fldMoney9; } }
		private static FieldRef m_fldMoney9 = new FieldRef("dttyp", "money9");

		/// <summary>Field : "Money - decimal (11-15) (storage: 9 byte)" Tipo: "$D" Formula:  ""</summary>
		public decimal ValMoney9
		{
			get { return (decimal)returnValueField(FldMoney9); }
			set { insertNameValueField(FldMoney9, value); }
		}

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("dttyp", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Date Time" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDatetime { get { return m_fldDatetime; } }
		private static FieldRef m_fldDatetime = new FieldRef("dttyp", "datetime");

		/// <summary>Field : "Date Time" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDatetime
		{
			get { return (DateTime)returnValueField(FldDatetime); }
			set { insertNameValueField(FldDatetime, value); }
		}

		/// <summary>Field : "Date Time Second" Tipo: "DS" Formula:  ""</summary>
		public static FieldRef FldDtsesond { get { return m_fldDtsesond; } }
		private static FieldRef m_fldDtsesond = new FieldRef("dttyp", "dtsesond");

		/// <summary>Field : "Date Time Second" Tipo: "DS" Formula:  ""</summary>
		public DateTime ValDtsesond
		{
			get { return (DateTime)returnValueField(FldDtsesond); }
			set { insertNameValueField(FldDtsesond, value); }
		}

		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldTime { get { return m_fldTime; } }
		private static FieldRef m_fldTime = new FieldRef("dttyp", "time");

		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		public string ValTime
		{
			get { return (string)returnValueField(FldTime); }
			set { insertNameValueField(FldTime, value); }
		}

		/// <summary>Field : "Starting time with inclusive boundary" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldStart { get { return m_fldStart; } }
		private static FieldRef m_fldStart = new FieldRef("dttyp", "start");

		/// <summary>Field : "Starting time with inclusive boundary" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValStart
		{
			get { return (DateTime)returnValueField(FldStart); }
			set { insertNameValueField(FldStart, value); }
		}

		/// <summary>Field : "End time with inclusive boundary, if not ongoing" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldEnd { get { return m_fldEnd; } }
		private static FieldRef m_fldEnd = new FieldRef("dttyp", "end");

		/// <summary>Field : "End time with inclusive boundary, if not ongoing" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValEnd
		{
			get { return (DateTime)returnValueField(FldEnd); }
			set { insertNameValueField(FldEnd, value); }
		}

		/// <summary>Field : "Image (binary)" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldImage { get { return m_fldImage; } }
		private static FieldRef m_fldImage = new FieldRef("dttyp", "image");

		/// <summary>Field : "Image (binary)" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValImage
		{
			get { return (byte[])returnValueField(FldImage); }
			set { insertNameValueField(FldImage, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("dttyp", "zzstate");



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
        public static CSGenioAdttyp search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAdttyp area = new CSGenioAdttyp(user, user.CurrentModule);

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
        public static List<CSGenioAdttyp> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAdttyp>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAdttyp> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAdttyp>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX DTTYP]/

     

                          

	}
}
