

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
	/// Field Type
	/// </summary>
	public class CSGenioAflds : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAflds(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR FLDS]/
		}

		public CSGenioAflds(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codflds", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codaero", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "Company Name";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COMPANY_NAME10342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("descrip", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  300;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("npassage", FieldType.NUMERO);
			Qfield.FieldDescription = "Numeric";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NUMERIC19292";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("duration", FieldType.NUMERO);
			Qfield.FieldDescription = "Numeric Decimal";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "NUMERIC_DECIMAL37352";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("price", FieldType.VALOR);
			Qfield.FieldDescription = "Currency";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "CURRENCY13881";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("precobil", FieldType.VALOR);
			Qfield.FieldDescription = "Currency Decimal";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "CURRENCY_DECIMAL48296";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("date", FieldType.DATA);
			Qfield.FieldDescription = "Date (DD/MM/YY)";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE__DD_MM_YY_57869";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("datetime", FieldType.DATAHORA);
			Qfield.FieldDescription = "DateTime";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATETIME61308";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dateseco", FieldType.DATASEGUNDO);
			Qfield.FieldDescription = "DateSecond";
			Qfield.FieldSize =  19;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATESECOND44557";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("time", FieldType.TEMPO);
			Qfield.FieldDescription = "Time";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TIME15328";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("year", FieldType.NUMERO);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "YEAR61794";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("primviag", FieldType.LOGICO);
			Qfield.FieldDescription = "Logical";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LOGICAL47485";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("conditio", FieldType.NUMERO);
			Qfield.FieldDescription = "Conditional";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CONDITIONAL01431";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("class", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Text Enumeration";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT_ENUMERATION45668";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCclass";
            Qfield.ArrayClassName = "Class";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("classnum", FieldType.ARRAY_COD_NUMERICO);
			Qfield.FieldDescription = "Numeric Enumeration";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NUMERIC_ENUMERATION19068";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNclassnum";
            Qfield.ArrayClassName = "Classnum";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("logicenu", FieldType.ARRAY_COD_LOGICO);
			Qfield.FieldDescription = "Logical Enumeration";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LOGICAL_ENUMERATION30276";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayLprimviag";
            Qfield.ArrayClassName = "Primviag";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("logo", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Logo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "LOGO62483";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("attach", FieldType.FICHEIRO_BD);
			Qfield.FieldDescription = "Document";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DOCUMENT00695";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field("attachfk", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			Qfield.Alias = info.Alias;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("logoexte", FieldType.PATH);
			Qfield.FieldDescription = "Logo (External File Image)";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LOGO__EXTERNAL_FILE_58162";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creatuse", FieldType.OPERCRIA);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_BY12292";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creatdat", FieldType.DATACRIA);
			Qfield.FieldDescription = "Date of Creation (DD/MM/YY)";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_OF_CREATION__DD02208";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creathou", FieldType.HORACRIA);
			Qfield.FieldDescription = "Hour of Creation";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "HOUR_OF_CREATION33629";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creatins", FieldType.INSTANTECRIA);
			Qfield.FieldDescription = "Complete Date of Creation";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COMPLETE_DATE_OF_CRE57046";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codequip", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("txtfield", FieldType.TEXTO);
			Qfield.FieldDescription = "Text Field";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT_FIELD41810";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("emailfld", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateEM(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("zipfield", FieldType.TEXTO);
			Qfield.FieldDescription = "Zipcode";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ZIPCODE21021";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateCP(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ibanfiel", FieldType.TEXTO);
			Qfield.FieldDescription = "IBAN";
			Qfield.FieldSize =  34;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IBAN28506";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateIN(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ssnumber", FieldType.TEXTO);
			Qfield.FieldDescription = "Social Security No";
			Qfield.FieldSize =  11;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOCIAL_SECURITY_NO48150";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateSS(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("licplate", FieldType.TEXTO);
			Qfield.FieldDescription = "Licence plate";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LICENCE_PLATE07627";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateMA(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("vatnumbr", FieldType.TEXTO);
			Qfield.FieldDescription = "VAT Number";
			Qfield.FieldSize =  9;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VAT_NUMBER24236";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateNC(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("banknmbr", FieldType.TEXTO);
			Qfield.FieldDescription = "Banking Account Number";
			Qfield.FieldSize =  24;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BANKING_ACCOUNT_NUMB62548";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateIB(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("upprtext", FieldType.TEXTO);
			Qfield.FieldDescription = "Uppercase";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UPPERCASE48238";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateUP(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("passfld", FieldType.TEXTO);
			Qfield.FieldDescription = "Password";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PASSWORD09467";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("clrpicke", FieldType.TEXTO);
			Qfield.FieldDescription = "Colorpicker";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COLORPICKER39653";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("shwrc", FieldType.LOGICO);
			Qfield.FieldDescription = "Show record";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHOW_RECORD53851";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("radiob", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Radio Btn";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RADIO_BTN20980";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCradiobtn";
            Qfield.ArrayClassName = "Radiobtn";
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("feeca", new String[] {"codflds"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("aero", new Relation("GQT", "gqtflds", "flds", "codflds", "codaero", "GQT", "gqtaero", "aero", "codaero", "codaero"));
			info.ParentTables.Add("equip", new Relation("GQT", "gqtflds", "flds", "codflds", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(13);
			info.Pathways.Add("aero","aero");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("tpequ","equip");
			info.Pathways.Add("cmpny","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("pess1","equip");
			info.Pathways.Add("famil","equip");
			info.Pathways.Add("cntry","equip");
			info.Pathways.Add("gitem","equip");
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








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAflds()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtflds";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codflds";
			info.HumanKeyName="descrip,".TrimEnd(',');
			info.Alias="flds";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Field Type";
			info.AreaPluralDesignation="Field Types";
			info.DescriptionCav="FIELD_TYPE57098";

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
			info.StampFieldsIns = new string[] {
                "creatuse","creatdat","creathou","creatins"
			};

            // Documents in DB
            //------------------------------
			info.DocumsForeignKeys = new List<String> {
			 "attachfk"
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
		public static FieldRef FldCodflds { get { return m_fldCodflds; } }
		private static FieldRef m_fldCodflds = new FieldRef("flds", "codflds");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodflds
		{
			get { return (string)returnValueField(FldCodflds); }
			set { insertNameValueField(FldCodflds, value); }
		}


		/// <summary>Field : "Company Name" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodaero { get { return m_fldCodaero; } }
		private static FieldRef m_fldCodaero = new FieldRef("flds", "codaero");

		/// <summary>Field : "Company Name" Tipo: "CE" Formula:  ""</summary>
		public string ValCodaero
		{
			get { return (string)returnValueField(FldCodaero); }
			set { insertNameValueField(FldCodaero, value); }
		}


		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescrip { get { return m_fldDescrip; } }
		private static FieldRef m_fldDescrip = new FieldRef("flds", "descrip");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescrip
		{
			get { return (string)returnValueField(FldDescrip); }
			set { insertNameValueField(FldDescrip, value); }
		}


		/// <summary>Field : "Numeric" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNpassage { get { return m_fldNpassage; } }
		private static FieldRef m_fldNpassage = new FieldRef("flds", "npassage");

		/// <summary>Field : "Numeric" Tipo: "N" Formula:  ""</summary>
		public double ValNpassage
		{
			get { return (double)returnValueField(FldNpassage); }
			set { insertNameValueField(FldNpassage, value); }
		}


		/// <summary>Field : "Numeric Decimal" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldDuration { get { return m_fldDuration; } }
		private static FieldRef m_fldDuration = new FieldRef("flds", "duration");

		/// <summary>Field : "Numeric Decimal" Tipo: "ND" Formula:  ""</summary>
		public double ValDuration
		{
			get { return (double)returnValueField(FldDuration); }
			set { insertNameValueField(FldDuration, value); }
		}


		/// <summary>Field : "Currency" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("flds", "price");

		/// <summary>Field : "Currency" Tipo: "$" Formula:  ""</summary>
		public double ValPrice
		{
			get { return (double)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}


		/// <summary>Field : "Currency Decimal" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldPrecobil { get { return m_fldPrecobil; } }
		private static FieldRef m_fldPrecobil = new FieldRef("flds", "precobil");

		/// <summary>Field : "Currency Decimal" Tipo: "$D" Formula:  ""</summary>
		public double ValPrecobil
		{
			get { return (double)returnValueField(FldPrecobil); }
			set { insertNameValueField(FldPrecobil, value); }
		}


		/// <summary>Field : "Date (DD/MM/YY)" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("flds", "date");

		/// <summary>Field : "Date (DD/MM/YY)" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}


		/// <summary>Field : "DateTime" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDatetime { get { return m_fldDatetime; } }
		private static FieldRef m_fldDatetime = new FieldRef("flds", "datetime");

		/// <summary>Field : "DateTime" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDatetime
		{
			get { return (DateTime)returnValueField(FldDatetime); }
			set { insertNameValueField(FldDatetime, value); }
		}


		/// <summary>Field : "DateSecond" Tipo: "DS" Formula:  ""</summary>
		public static FieldRef FldDateseco { get { return m_fldDateseco; } }
		private static FieldRef m_fldDateseco = new FieldRef("flds", "dateseco");

		/// <summary>Field : "DateSecond" Tipo: "DS" Formula:  ""</summary>
		public DateTime ValDateseco
		{
			get { return (DateTime)returnValueField(FldDateseco); }
			set { insertNameValueField(FldDateseco, value); }
		}


		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldTime { get { return m_fldTime; } }
		private static FieldRef m_fldTime = new FieldRef("flds", "time");

		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		public string ValTime
		{
			get { return (string)returnValueField(FldTime); }
			set { insertNameValueField(FldTime, value); }
		}


		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("flds", "year");

		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public double ValYear
		{
			get { return (double)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}


		/// <summary>Field : "Logical" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldPrimviag { get { return m_fldPrimviag; } }
		private static FieldRef m_fldPrimviag = new FieldRef("flds", "primviag");

		/// <summary>Field : "Logical" Tipo: "L" Formula:  ""</summary>
		public int ValPrimviag
		{
			get { return (int)returnValueField(FldPrimviag); }
			set { insertNameValueField(FldPrimviag, value); }
		}


		/// <summary>Field : "Conditional" Tipo: "IF" Formula:  ""</summary>
		public static FieldRef FldConditio { get { return m_fldConditio; } }
		private static FieldRef m_fldConditio = new FieldRef("flds", "conditio");

		/// <summary>Field : "Conditional" Tipo: "IF" Formula:  ""</summary>
		public double ValConditio
		{
			get { return (double)returnValueField(FldConditio); }
			set { insertNameValueField(FldConditio, value); }
		}


		/// <summary>Field : "Text Enumeration" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldClass { get { return m_fldClass; } }
		private static FieldRef m_fldClass = new FieldRef("flds", "class");

		/// <summary>Field : "Text Enumeration" Tipo: "AC" Formula:  ""</summary>
		public string ValClass
		{
			get { return (string)returnValueField(FldClass); }
			set { insertNameValueField(FldClass, value); }
		}


		/// <summary>Field : "Numeric Enumeration" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldClassnum { get { return m_fldClassnum; } }
		private static FieldRef m_fldClassnum = new FieldRef("flds", "classnum");

		/// <summary>Field : "Numeric Enumeration" Tipo: "AN" Formula:  ""</summary>
		public double ValClassnum
		{
			get { return (double)returnValueField(FldClassnum); }
			set { insertNameValueField(FldClassnum, value); }
		}


		/// <summary>Field : "Logical Enumeration" Tipo: "AL" Formula:  ""</summary>
		public static FieldRef FldLogicenu { get { return m_fldLogicenu; } }
		private static FieldRef m_fldLogicenu = new FieldRef("flds", "logicenu");

		/// <summary>Field : "Logical Enumeration" Tipo: "AL" Formula:  ""</summary>
		public int ValLogicenu
		{
			get { return (int)returnValueField(FldLogicenu); }
			set { insertNameValueField(FldLogicenu, value); }
		}


		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldLogo { get { return m_fldLogo; } }
		private static FieldRef m_fldLogo = new FieldRef("flds", "logo");

		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValLogo
		{
			get { return (byte[])returnValueField(FldLogo); }
			set { insertNameValueField(FldLogo, value); }
		}


		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldAttach { get { return m_fldAttach; } }
		private static FieldRef m_fldAttach = new FieldRef("flds", "attach");

		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		public string ValAttach
		{
			get { return (string)returnValueField(FldAttach); }
			set { insertNameValueField(FldAttach, value); }
		}

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldAttachfk { get { return m_fldAttachfk; } }
		private static FieldRef m_fldAttachfk = new FieldRef("flds", "attachfk");

		/// <summary>Field : "Document FK" Tipo: "CE" Formula:  ""</summary>
		public string ValAttachfk
		{
			get { return (string)returnValueField(FldAttachfk); }
			set { insertNameValueField(FldAttachfk, value); }
		}

		/// <summary>Field : "Logo (External File Image)" Tipo: "IX" Formula:  ""</summary>
		public static FieldRef FldLogoexte { get { return m_fldLogoexte; } }
		private static FieldRef m_fldLogoexte = new FieldRef("flds", "logoexte");

		/// <summary>Field : "Logo (External File Image)" Tipo: "IX" Formula:  ""</summary>
		public string ValLogoexte
		{
			get { return (string)returnValueField(FldLogoexte); }
			set { insertNameValueField(FldLogoexte, value); }
		}


		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatuse { get { return m_fldCreatuse; } }
		private static FieldRef m_fldCreatuse = new FieldRef("flds", "creatuse");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatuse
		{
			get { return (string)returnValueField(FldCreatuse); }
			set { insertNameValueField(FldCreatuse, value); }
		}


		/// <summary>Field : "Date of Creation (DD/MM/YY)" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("flds", "creatdat");

		/// <summary>Field : "Date of Creation (DD/MM/YY)" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}


		/// <summary>Field : "Hour of Creation" Tipo: "OT" Formula:  ""</summary>
		public static FieldRef FldCreathou { get { return m_fldCreathou; } }
		private static FieldRef m_fldCreathou = new FieldRef("flds", "creathou");

		/// <summary>Field : "Hour of Creation" Tipo: "OT" Formula:  ""</summary>
		public string ValCreathou
		{
			get { return (string)returnValueField(FldCreathou); }
			set { insertNameValueField(FldCreathou, value); }
		}


		/// <summary>Field : "Complete Date of Creation" Tipo: "OI" Formula:  ""</summary>
		public static FieldRef FldCreatins { get { return m_fldCreatins; } }
		private static FieldRef m_fldCreatins = new FieldRef("flds", "creatins");

		/// <summary>Field : "Complete Date of Creation" Tipo: "OI" Formula:  ""</summary>
		public DateTime ValCreatins
		{
			get { return (DateTime)returnValueField(FldCreatins); }
			set { insertNameValueField(FldCreatins, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("flds", "codequip");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}


		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTxtfield { get { return m_fldTxtfield; } }
		private static FieldRef m_fldTxtfield = new FieldRef("flds", "txtfield");

		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public string ValTxtfield
		{
			get { return (string)returnValueField(FldTxtfield); }
			set { insertNameValueField(FldTxtfield, value); }
		}


		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmailfld { get { return m_fldEmailfld; } }
		private static FieldRef m_fldEmailfld = new FieldRef("flds", "emailfld");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmailfld
		{
			get { return (string)returnValueField(FldEmailfld); }
			set { insertNameValueField(FldEmailfld, value); }
		}


		/// <summary>Field : "Zipcode" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldZipfield { get { return m_fldZipfield; } }
		private static FieldRef m_fldZipfield = new FieldRef("flds", "zipfield");

		/// <summary>Field : "Zipcode" Tipo: "C" Formula:  ""</summary>
		public string ValZipfield
		{
			get { return (string)returnValueField(FldZipfield); }
			set { insertNameValueField(FldZipfield, value); }
		}


		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIbanfiel { get { return m_fldIbanfiel; } }
		private static FieldRef m_fldIbanfiel = new FieldRef("flds", "ibanfiel");

		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public string ValIbanfiel
		{
			get { return (string)returnValueField(FldIbanfiel); }
			set { insertNameValueField(FldIbanfiel, value); }
		}


		/// <summary>Field : "Social Security No" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSsnumber { get { return m_fldSsnumber; } }
		private static FieldRef m_fldSsnumber = new FieldRef("flds", "ssnumber");

		/// <summary>Field : "Social Security No" Tipo: "C" Formula:  ""</summary>
		public string ValSsnumber
		{
			get { return (string)returnValueField(FldSsnumber); }
			set { insertNameValueField(FldSsnumber, value); }
		}


		/// <summary>Field : "Licence plate" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLicplate { get { return m_fldLicplate; } }
		private static FieldRef m_fldLicplate = new FieldRef("flds", "licplate");

		/// <summary>Field : "Licence plate" Tipo: "C" Formula:  ""</summary>
		public string ValLicplate
		{
			get { return (string)returnValueField(FldLicplate); }
			set { insertNameValueField(FldLicplate, value); }
		}


		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldVatnumbr { get { return m_fldVatnumbr; } }
		private static FieldRef m_fldVatnumbr = new FieldRef("flds", "vatnumbr");

		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public string ValVatnumbr
		{
			get { return (string)returnValueField(FldVatnumbr); }
			set { insertNameValueField(FldVatnumbr, value); }
		}


		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBanknmbr { get { return m_fldBanknmbr; } }
		private static FieldRef m_fldBanknmbr = new FieldRef("flds", "banknmbr");

		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public string ValBanknmbr
		{
			get { return (string)returnValueField(FldBanknmbr); }
			set { insertNameValueField(FldBanknmbr, value); }
		}


		/// <summary>Field : "Uppercase" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldUpprtext { get { return m_fldUpprtext; } }
		private static FieldRef m_fldUpprtext = new FieldRef("flds", "upprtext");

		/// <summary>Field : "Uppercase" Tipo: "C" Formula:  ""</summary>
		public string ValUpprtext
		{
			get { return (string)returnValueField(FldUpprtext); }
			set { insertNameValueField(FldUpprtext, value); }
		}


		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPassfld { get { return m_fldPassfld; } }
		private static FieldRef m_fldPassfld = new FieldRef("flds", "passfld");

		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		public string ValPassfld
		{
			get { return (string)returnValueField(FldPassfld); }
			set { insertNameValueField(FldPassfld, value); }
		}


		/// <summary>Field : "Colorpicker" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldClrpicke { get { return m_fldClrpicke; } }
		private static FieldRef m_fldClrpicke = new FieldRef("flds", "clrpicke");

		/// <summary>Field : "Colorpicker" Tipo: "C" Formula:  ""</summary>
		public string ValClrpicke
		{
			get { return (string)returnValueField(FldClrpicke); }
			set { insertNameValueField(FldClrpicke, value); }
		}


		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShwrc { get { return m_fldShwrc; } }
		private static FieldRef m_fldShwrc = new FieldRef("flds", "shwrc");

		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public int ValShwrc
		{
			get { return (int)returnValueField(FldShwrc); }
			set { insertNameValueField(FldShwrc, value); }
		}


		/// <summary>Field : "Radio Btn" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldRadiob { get { return m_fldRadiob; } }
		private static FieldRef m_fldRadiob = new FieldRef("flds", "radiob");

		/// <summary>Field : "Radio Btn" Tipo: "AC" Formula:  ""</summary>
		public string ValRadiob
		{
			get { return (string)returnValueField(FldRadiob); }
			set { insertNameValueField(FldRadiob, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("flds", "zzstate");



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
        public static CSGenioAflds search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAflds area = new CSGenioAflds(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAflds> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAflds> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAflds>(where, user, fields);
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
        public static List<CSGenioAflds> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAflds>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAflds> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAflds>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX FLDS]/

     

                                       

	}
}
