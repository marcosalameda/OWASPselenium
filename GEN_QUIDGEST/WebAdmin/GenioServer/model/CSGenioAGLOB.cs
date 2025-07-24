
 
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
	/// Global parameters
	/// </summary>
	public class CSGenioAglob : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAglob(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR GLOB]/
		}

		public CSGenioAglob(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codglob", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "home", FieldType.MEMO);
			Qfield.FieldDescription = "Home text";
			Qfield.FieldSize =  300;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "HOME_TEXT11153";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pzero", FieldType.NUMERIC);
			Qfield.FieldDescription = "0%";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "_0_14276";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "remetent", FieldType.TEXT);
			Qfield.FieldDescription = "Sender Email";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "E_MAIL_REMETENTE26604";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrspdd", FieldType.LOGIC);
			Qfield.FieldDescription = "Data Responsible";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RESPONSAVEIS_DADOS26494";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrspin", FieldType.LOGIC);
			Qfield.FieldDescription = "Indicator Responsible";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RESPONS__INDICADOR07689";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrpbsc", FieldType.LOGIC);
			Qfield.FieldDescription = "Responsible";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RESPONSAVEL08700";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrpini", FieldType.LOGIC);
			Qfield.FieldDescription = "Iniciative Responsible";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RESPONS__INICIATIVA38392";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrpact", FieldType.LOGIC);
			Qfield.FieldDescription = "Activity Responsible";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "RESPONS__ACTIVIDADE24594";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pvalmin", FieldType.NUMERIC);
			Qfield.FieldDescription = "Minimum";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MINIMO33485";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimmau", FieldType.NUMERIC);
			Qfield.FieldDescription = "Bad";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAU45741";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "palert", FieldType.NUMERIC);
			Qfield.FieldDescription = "Alert";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ALERTA41713";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimbom", FieldType.NUMERIC);
			Qfield.FieldDescription = "Good";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BOM29058";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimsup", FieldType.NUMERIC);
			Qfield.FieldDescription = "Overcome";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SUPERADO60727";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pvalmax", FieldType.NUMERIC);
			Qfield.FieldDescription = "Maximum";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAXIMO52072";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pzerod", FieldType.NUMERIC);
			Qfield.FieldDescription = "0%";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "_0_14276";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pzero"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pvalmind", FieldType.NUMERIC);
			Qfield.FieldDescription = "Minimum";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MINIMO33485";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pvalmax"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "palertd", FieldType.NUMERIC);
			Qfield.FieldDescription = "Alert";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ALERTA41713";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"palert"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimbomd", FieldType.NUMERIC);
			Qfield.FieldDescription = "Good";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BOM29058";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"plimbom"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimsupd", FieldType.NUMERIC);
			Qfield.FieldDescription = "Overcome";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SUPERADO60727";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"plimsup"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pvalmaxd", FieldType.NUMERIC);
			Qfield.FieldDescription = "Maximum";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAXIMO52072";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pvalmin"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iniciano", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Beginning of the year";
			Qfield.FieldSize =  2;
			Qfield.CavDesignation = "INICIO_DO_ANO45675";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue("1");
            Qfield.ArrayName = "dbo.GetValArrayCameses";
            Qfield.ArrayClassName = "Ameses";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pzeroc", FieldType.NUMERIC);
			Qfield.FieldDescription = "0%";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "_0_14276";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pminc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Minimum";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MINIMO33485";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pmauc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Bad";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAU45741";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "palertc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Alert";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ALERTA41713";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "plimmaud", FieldType.NUMERIC);
			Qfield.FieldDescription = "Bad";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAU45741";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"plimmau"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pbomc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Good";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BOM29058";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pbomsc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Good sup.";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BOM_SUP_56812";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pbomc"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "palertsc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Alert sup.";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ALERTA_SUP_32316";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"palertc"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pmausc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Bad";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAU_SUP_16499";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pmauc"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pmaxsc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Maximum Sup.";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAXIMO_SUP_02835";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pminc"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pzerosc", FieldType.NUMERIC);
			Qfield.FieldDescription = "100%";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "_100_17544";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"pzeroc"}, new int[] {0}, "glob", "codglob"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return 100+(100-((decimal)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tipscard", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Scorecard type";
			Qfield.FieldSize =  25;
			Qfield.CavDesignation = "TIPO_DE_SCORECARD04627";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCatpscore";
            Qfield.ArrayClassName = "Atpscore";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "organism", FieldType.TEXT);
			Qfield.FieldDescription = "Organism";
			Qfield.FieldSize =  80;
			Qfield.CavDesignation = "ORGANISMO01307";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "code", FieldType.TEXT);
			Qfield.FieldDescription = "Organism code";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "CODIGO_DO_ORGANISMO22253";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "morada", FieldType.TEXT);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  60;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cpostal", FieldType.TEXT);
			Qfield.FieldDescription = "zipcode";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "COD__POSTAL04857";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateCP(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "lpostal", FieldType.TEXT);
			Qfield.FieldDescription = "Local";
			Qfield.FieldSize =  25;
			Qfield.CavDesignation = "LOCALE34521";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "telephon", FieldType.TEXT);
			Qfield.FieldDescription = "Phone";
			Qfield.FieldSize =  23;
			Qfield.CavDesignation = "PHONE56703";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "fax", FieldType.TEXT);
			Qfield.FieldDescription = "Fax";
			Qfield.FieldSize =  23;
			Qfield.CavDesignation = "FAX08532";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "e-mail";
			Qfield.FieldSize =  40;
			Qfield.CavDesignation = "E_MAIL41236";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "site", FieldType.TEXT);
			Qfield.FieldDescription = "URL";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "SITIO_NA_NET35977";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "simbolo", FieldType.IMAGE);
			Qfield.FieldDescription = "Header";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "CABECALHO50133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "simbolol", FieldType.IMAGE);
			Qfield.FieldDescription = "Header";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "CABECALHO50133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "footerp", FieldType.IMAGE);
			Qfield.FieldDescription = "Footer";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "RODAPE46446";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "footerl", FieldType.IMAGE);
			Qfield.FieldDescription = "Footer";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "RODAPE46446";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "marcagua", FieldType.IMAGE);
			Qfield.FieldDescription = "Watermark";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "MARCA_AGUA18601";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "logomint", FieldType.IMAGE);
			Qfield.FieldDescription = "Ministry Logo";
			Qfield.FieldSize =  14;
			Qfield.CavDesignation = "LOGOTIPO_MINISTERIO43307";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pathdocu", FieldType.TEXT);
			Qfield.FieldDescription = "Documents path";
			Qfield.FieldSize =  120;
			Qfield.CavDesignation = "CAMINHO_PARA_DOCUMEN06620";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smtpmail", FieldType.TEXT);
			Qfield.FieldDescription = "Sender Email";
			Qfield.FieldSize =  100;
			Qfield.CavDesignation = "SENDER_EMAIL29228";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "servsmtp", FieldType.TEXT);
			Qfield.FieldDescription = "SMTP Server";
			Qfield.FieldSize =  80;
			Qfield.CavDesignation = "SERVIDOR_SMTP03820";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smtpport", FieldType.NUMERIC);
			Qfield.FieldDescription = "SMTP Port";
			Qfield.FieldSize =  5;
			Qfield.IntegerDigits = 5;
			Qfield.CavDesignation = "SMTP_PORT50933";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smtpssl", FieldType.LOGIC);
			Qfield.FieldDescription = "SSL?";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "SSL_29632";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smtpuser", FieldType.TEXT);
			Qfield.FieldDescription = "STMP User Access";
			Qfield.FieldSize =  80;
			Qfield.CavDesignation = "UTILIZADOR_ACESSO_SM08837";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "smtppass", FieldType.TEXT);
			Qfield.FieldDescription = "SMTP Access Password";
			Qfield.FieldSize =  80;
			Qfield.CavDesignation = "PALAVRA_CHAVE_ACESSO43416";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tpbonifi", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Automatic bonuses";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "BONIFICACOES_AUTOMAT45559";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCatpbonif";
            Qfield.ArrayClassName = "Atpbonif";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "mostrano", FieldType.LOGIC);
			Qfield.FieldDescription = "Show Closed Maps";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "MOSTRAR_ANOS_ANTERIO34446";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(1);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sodiasut", FieldType.LOGIC);
			Qfield.FieldDescription = "Calculations exclusively with working days?";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "CALCULATIONS_EXCLUSI63239";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "executou", FieldType.LOGIC);
			Qfield.FieldDescription = "Executed unique routine";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "EXECUTED_UNIQUE_ROUT40468";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "xmlgraph", FieldType.MEMO);
			Qfield.FieldDescription = "Graphix XML";
			Qfield.FieldSize =  10;
			Qfield.Decimals = 9;
			Qfield.CavDesignation = "GRAPHIX_XML41240";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "filtrorg", FieldType.LOGIC);
			Qfield.FieldDescription = "Filter by Organic Unit";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "FILTER_BY_ORGANIC_UN18810";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "scoreout", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Scorecard appearance";
			Qfield.FieldSize =  4;
			Qfield.CavDesignation = "SCORECARD_APPEARANCE36559";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCascorout";
            Qfield.ArrayClassName = "Ascorout";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "minister", FieldType.TEXT);
			Qfield.FieldDescription = "Ministry";
			Qfield.FieldSize =  120;
			Qfield.CavDesignation = "MINISTERIO28390";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtultnot", FieldType.DATE);
			Qfield.FieldDescription = "Last notification date";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "DATA_ULTIMA_NOTIFICA44675";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "integdoc", FieldType.LOGIC);
			Qfield.FieldDescription = "Does it integrate with Document";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "INTEGRA_C__DOCUMENTA16144";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prefobje", FieldType.TEXT);
			Qfield.FieldDescription = "Objetivos";
			Qfield.FieldSize =  6;
			Qfield.CavDesignation = "OBJETIVOS01527";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prefindi", FieldType.TEXT);
			Qfield.FieldDescription = "Indicator";
			Qfield.FieldSize =  6;
			Qfield.CavDesignation = "INDICADORES28699";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gantunit", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Gantt - Scale";
			Qfield.FieldSize =  5;
			Qfield.CavDesignation = "GANTT___SCALE29829";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaganttun";
            Qfield.ArrayClassName = "Aganttun";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gantstep", FieldType.NUMERIC);
			Qfield.FieldDescription = "Gantt - Forward";
			Qfield.FieldSize =  2;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "GANTT___FORWARD40474";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "migrarlt", FieldType.LOGIC);
			Qfield.FieldDescription = "Migrate status/report on initiatives and tasks";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "MIGRATE_STATUS_REPOR46576";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "filtrrsp", FieldType.LOGIC);
			Qfield.FieldDescription = "Filter by responsible";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "FILTRAR_RESPONSAVEIS06812";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "docbd", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Document Path";
			Qfield.FieldSize =  150;
			Qfield.CavDesignation = "DOCUMENT_PATH07040";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field(info.Alias, "docbdfk", FieldType.KEY_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "horassem", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "Number of weekly hours";
			Qfield.FieldSize =  2;
			Qfield.CavDesignation = "NO_HORAS_SEMANAIS27486";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNahorasse";
            Qfield.ArrayClassName = "Ahorasse";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "afetacao", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Afetação / Contabilidade Custos";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "AFETACAO___CONTABILI52162";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaccustos";
            Qfield.ArrayClassName = "Accustos";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatdat", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Creation date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CRIADO_EM61283";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatope", FieldType.TEXT);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CRIADO_POR_18536";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "chngdate", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Changed on";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ALTERADO_EM23573";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operchng", FieldType.TEXT);
			Qfield.FieldDescription = "Changed by";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ALTERADO_POR39254";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pricolor", FieldType.TEXT);
			Qfield.FieldDescription = "Primary color";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PRIMARY_COLOR34274";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 0, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return "#009AA5";
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codfacty", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "legend", FieldType.IMAGE);
			Qfield.FieldDescription = "Legend";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "LEGEND16814";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "apiurl", FieldType.TEXT);
			Qfield.FieldDescription = "External API address";
			Qfield.FieldSize =  350;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EXTERNAL_API_ADDRESS59205";

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
			info.ParentTables.Add("facty", new Relation("GQT", "gqtglob", "glob", "codglob", "codfacty", "GQT", "gqtfacilitytype", "facty", "codfacty", "codfacty"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("facty","facty");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "pzerod","pvalmind","palertd","plimbomd","plimsupd","pvalmaxd","plimmaud","pbomsc","palertsc","pmausc","pmaxsc","pzerosc","pricolor"
			};

			info.DefaultValues = new string[] {
			 "semrspdd","semrspin","iniciano","mostrano","sodiasut","executou","filtrorg","migrarlt"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAglob()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtglob";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codglob";
			info.HumanKeyName="home,".TrimEnd(',');
			info.Alias="glob";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Global parameters";
			info.AreaPluralDesignation="Global parameters";
			info.DescriptionCav="GLOBAL_PARAMETERS41637";

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
                "creatope","creatdat"
			};

			info.StampFieldsAlt = new string[] {
                "operchng","chngdate"
			};
            // Documents in DB
            //------------------------------
			info.DocumsForeignKeys = new List<String> {
			 "docbdfk"
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
		public static FieldRef FldCodglob { get { return m_fldCodglob; } }
		private static FieldRef m_fldCodglob = new FieldRef("glob", "codglob");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodglob
		{
			get { return (string)returnValueField(FldCodglob); }
			set { insertNameValueField(FldCodglob, value); }
		}

		/// <summary>Field : "Home text" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldHome { get { return m_fldHome; } }
		private static FieldRef m_fldHome = new FieldRef("glob", "home");

		/// <summary>Field : "Home text" Tipo: "MO" Formula:  ""</summary>
		public string ValHome
		{
			get { return (string)returnValueField(FldHome); }
			set { insertNameValueField(FldHome, value); }
		}

		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPzero { get { return m_fldPzero; } }
		private static FieldRef m_fldPzero = new FieldRef("glob", "pzero");

		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		public decimal ValPzero
		{
			get { return (decimal)returnValueField(FldPzero); }
			set { insertNameValueField(FldPzero, value); }
		}

		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldRemetent { get { return m_fldRemetent; } }
		private static FieldRef m_fldRemetent = new FieldRef("glob", "remetent");

		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public string ValRemetent
		{
			get { return (string)returnValueField(FldRemetent); }
			set { insertNameValueField(FldRemetent, value); }
		}

		/// <summary>Field : "Data Responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrspdd { get { return m_fldSemrspdd; } }
		private static FieldRef m_fldSemrspdd = new FieldRef("glob", "semrspdd");

		/// <summary>Field : "Data Responsible" Tipo: "L" Formula:  ""</summary>
		public int ValSemrspdd
		{
			get { return (int)returnValueField(FldSemrspdd); }
			set { insertNameValueField(FldSemrspdd, value); }
		}

		/// <summary>Field : "Indicator Responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrspin { get { return m_fldSemrspin; } }
		private static FieldRef m_fldSemrspin = new FieldRef("glob", "semrspin");

		/// <summary>Field : "Indicator Responsible" Tipo: "L" Formula:  ""</summary>
		public int ValSemrspin
		{
			get { return (int)returnValueField(FldSemrspin); }
			set { insertNameValueField(FldSemrspin, value); }
		}

		/// <summary>Field : "Responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrpbsc { get { return m_fldSemrpbsc; } }
		private static FieldRef m_fldSemrpbsc = new FieldRef("glob", "semrpbsc");

		/// <summary>Field : "Responsible" Tipo: "L" Formula:  ""</summary>
		public int ValSemrpbsc
		{
			get { return (int)returnValueField(FldSemrpbsc); }
			set { insertNameValueField(FldSemrpbsc, value); }
		}

		/// <summary>Field : "Iniciative Responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrpini { get { return m_fldSemrpini; } }
		private static FieldRef m_fldSemrpini = new FieldRef("glob", "semrpini");

		/// <summary>Field : "Iniciative Responsible" Tipo: "L" Formula:  ""</summary>
		public int ValSemrpini
		{
			get { return (int)returnValueField(FldSemrpini); }
			set { insertNameValueField(FldSemrpini, value); }
		}

		/// <summary>Field : "Activity Responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrpact { get { return m_fldSemrpact; } }
		private static FieldRef m_fldSemrpact = new FieldRef("glob", "semrpact");

		/// <summary>Field : "Activity Responsible" Tipo: "L" Formula:  ""</summary>
		public int ValSemrpact
		{
			get { return (int)returnValueField(FldSemrpact); }
			set { insertNameValueField(FldSemrpact, value); }
		}

		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPvalmin { get { return m_fldPvalmin; } }
		private static FieldRef m_fldPvalmin = new FieldRef("glob", "pvalmin");

		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		public decimal ValPvalmin
		{
			get { return (decimal)returnValueField(FldPvalmin); }
			set { insertNameValueField(FldPvalmin, value); }
		}

		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPlimmau { get { return m_fldPlimmau; } }
		private static FieldRef m_fldPlimmau = new FieldRef("glob", "plimmau");

		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		public decimal ValPlimmau
		{
			get { return (decimal)returnValueField(FldPlimmau); }
			set { insertNameValueField(FldPlimmau, value); }
		}

		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPalert { get { return m_fldPalert; } }
		private static FieldRef m_fldPalert = new FieldRef("glob", "palert");

		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		public decimal ValPalert
		{
			get { return (decimal)returnValueField(FldPalert); }
			set { insertNameValueField(FldPalert, value); }
		}

		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPlimbom { get { return m_fldPlimbom; } }
		private static FieldRef m_fldPlimbom = new FieldRef("glob", "plimbom");

		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		public decimal ValPlimbom
		{
			get { return (decimal)returnValueField(FldPlimbom); }
			set { insertNameValueField(FldPlimbom, value); }
		}

		/// <summary>Field : "Overcome" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPlimsup { get { return m_fldPlimsup; } }
		private static FieldRef m_fldPlimsup = new FieldRef("glob", "plimsup");

		/// <summary>Field : "Overcome" Tipo: "N" Formula:  ""</summary>
		public decimal ValPlimsup
		{
			get { return (decimal)returnValueField(FldPlimsup); }
			set { insertNameValueField(FldPlimsup, value); }
		}

		/// <summary>Field : "Maximum" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPvalmax { get { return m_fldPvalmax; } }
		private static FieldRef m_fldPvalmax = new FieldRef("glob", "pvalmax");

		/// <summary>Field : "Maximum" Tipo: "N" Formula:  ""</summary>
		public decimal ValPvalmax
		{
			get { return (decimal)returnValueField(FldPvalmax); }
			set { insertNameValueField(FldPvalmax, value); }
		}

		/// <summary>Field : "0%" Tipo: "N" Formula: + "100+(100-[GLOB->PZERO])"</summary>
		public static FieldRef FldPzerod { get { return m_fldPzerod; } }
		private static FieldRef m_fldPzerod = new FieldRef("glob", "pzerod");

		/// <summary>Field : "0%" Tipo: "N" Formula: + "100+(100-[GLOB->PZERO])"</summary>
		public decimal ValPzerod
		{
			get { return (decimal)returnValueField(FldPzerod); }
			set { insertNameValueField(FldPzerod, value); }
		}

		/// <summary>Field : "Minimum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMAX])"</summary>
		public static FieldRef FldPvalmind { get { return m_fldPvalmind; } }
		private static FieldRef m_fldPvalmind = new FieldRef("glob", "pvalmind");

		/// <summary>Field : "Minimum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMAX])"</summary>
		public decimal ValPvalmind
		{
			get { return (decimal)returnValueField(FldPvalmind); }
			set { insertNameValueField(FldPvalmind, value); }
		}

		/// <summary>Field : "Alert" Tipo: "N" Formula: + "100+(100-[GLOB->PALERT])"</summary>
		public static FieldRef FldPalertd { get { return m_fldPalertd; } }
		private static FieldRef m_fldPalertd = new FieldRef("glob", "palertd");

		/// <summary>Field : "Alert" Tipo: "N" Formula: + "100+(100-[GLOB->PALERT])"</summary>
		public decimal ValPalertd
		{
			get { return (decimal)returnValueField(FldPalertd); }
			set { insertNameValueField(FldPalertd, value); }
		}

		/// <summary>Field : "Good" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMBOM])"</summary>
		public static FieldRef FldPlimbomd { get { return m_fldPlimbomd; } }
		private static FieldRef m_fldPlimbomd = new FieldRef("glob", "plimbomd");

		/// <summary>Field : "Good" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMBOM])"</summary>
		public decimal ValPlimbomd
		{
			get { return (decimal)returnValueField(FldPlimbomd); }
			set { insertNameValueField(FldPlimbomd, value); }
		}

		/// <summary>Field : "Overcome" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMSUP])"</summary>
		public static FieldRef FldPlimsupd { get { return m_fldPlimsupd; } }
		private static FieldRef m_fldPlimsupd = new FieldRef("glob", "plimsupd");

		/// <summary>Field : "Overcome" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMSUP])"</summary>
		public decimal ValPlimsupd
		{
			get { return (decimal)returnValueField(FldPlimsupd); }
			set { insertNameValueField(FldPlimsupd, value); }
		}

		/// <summary>Field : "Maximum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMIN])"</summary>
		public static FieldRef FldPvalmaxd { get { return m_fldPvalmaxd; } }
		private static FieldRef m_fldPvalmaxd = new FieldRef("glob", "pvalmaxd");

		/// <summary>Field : "Maximum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMIN])"</summary>
		public decimal ValPvalmaxd
		{
			get { return (decimal)returnValueField(FldPvalmaxd); }
			set { insertNameValueField(FldPvalmaxd, value); }
		}

		/// <summary>Field : "Beginning of the year" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldIniciano { get { return m_fldIniciano; } }
		private static FieldRef m_fldIniciano = new FieldRef("glob", "iniciano");

		/// <summary>Field : "Beginning of the year" Tipo: "AC" Formula:  ""</summary>
		public string ValIniciano
		{
			get { return (string)returnValueField(FldIniciano); }
			set { insertNameValueField(FldIniciano, value); }
		}

		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPzeroc { get { return m_fldPzeroc; } }
		private static FieldRef m_fldPzeroc = new FieldRef("glob", "pzeroc");

		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		public decimal ValPzeroc
		{
			get { return (decimal)returnValueField(FldPzeroc); }
			set { insertNameValueField(FldPzeroc, value); }
		}

		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPminc { get { return m_fldPminc; } }
		private static FieldRef m_fldPminc = new FieldRef("glob", "pminc");

		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		public decimal ValPminc
		{
			get { return (decimal)returnValueField(FldPminc); }
			set { insertNameValueField(FldPminc, value); }
		}

		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPmauc { get { return m_fldPmauc; } }
		private static FieldRef m_fldPmauc = new FieldRef("glob", "pmauc");

		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		public decimal ValPmauc
		{
			get { return (decimal)returnValueField(FldPmauc); }
			set { insertNameValueField(FldPmauc, value); }
		}

		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPalertc { get { return m_fldPalertc; } }
		private static FieldRef m_fldPalertc = new FieldRef("glob", "palertc");

		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		public decimal ValPalertc
		{
			get { return (decimal)returnValueField(FldPalertc); }
			set { insertNameValueField(FldPalertc, value); }
		}

		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMMAU])"</summary>
		public static FieldRef FldPlimmaud { get { return m_fldPlimmaud; } }
		private static FieldRef m_fldPlimmaud = new FieldRef("glob", "plimmaud");

		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMMAU])"</summary>
		public decimal ValPlimmaud
		{
			get { return (decimal)returnValueField(FldPlimmaud); }
			set { insertNameValueField(FldPlimmaud, value); }
		}

		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPbomc { get { return m_fldPbomc; } }
		private static FieldRef m_fldPbomc = new FieldRef("glob", "pbomc");

		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		public decimal ValPbomc
		{
			get { return (decimal)returnValueField(FldPbomc); }
			set { insertNameValueField(FldPbomc, value); }
		}

		/// <summary>Field : "Good sup." Tipo: "N" Formula: + "100+(100-[GLOB->PBOMC])"</summary>
		public static FieldRef FldPbomsc { get { return m_fldPbomsc; } }
		private static FieldRef m_fldPbomsc = new FieldRef("glob", "pbomsc");

		/// <summary>Field : "Good sup." Tipo: "N" Formula: + "100+(100-[GLOB->PBOMC])"</summary>
		public decimal ValPbomsc
		{
			get { return (decimal)returnValueField(FldPbomsc); }
			set { insertNameValueField(FldPbomsc, value); }
		}

		/// <summary>Field : "Alert sup." Tipo: "N" Formula: + "100+(100-[GLOB->PALERTC])"</summary>
		public static FieldRef FldPalertsc { get { return m_fldPalertsc; } }
		private static FieldRef m_fldPalertsc = new FieldRef("glob", "palertsc");

		/// <summary>Field : "Alert sup." Tipo: "N" Formula: + "100+(100-[GLOB->PALERTC])"</summary>
		public decimal ValPalertsc
		{
			get { return (decimal)returnValueField(FldPalertsc); }
			set { insertNameValueField(FldPalertsc, value); }
		}

		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PMAUC])"</summary>
		public static FieldRef FldPmausc { get { return m_fldPmausc; } }
		private static FieldRef m_fldPmausc = new FieldRef("glob", "pmausc");

		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PMAUC])"</summary>
		public decimal ValPmausc
		{
			get { return (decimal)returnValueField(FldPmausc); }
			set { insertNameValueField(FldPmausc, value); }
		}

		/// <summary>Field : "Maximum Sup." Tipo: "N" Formula: + "100+(100-[GLOB->PMINC])"</summary>
		public static FieldRef FldPmaxsc { get { return m_fldPmaxsc; } }
		private static FieldRef m_fldPmaxsc = new FieldRef("glob", "pmaxsc");

		/// <summary>Field : "Maximum Sup." Tipo: "N" Formula: + "100+(100-[GLOB->PMINC])"</summary>
		public decimal ValPmaxsc
		{
			get { return (decimal)returnValueField(FldPmaxsc); }
			set { insertNameValueField(FldPmaxsc, value); }
		}

		/// <summary>Field : "100%" Tipo: "N" Formula: + "100+(100-[GLOB->PZEROC])"</summary>
		public static FieldRef FldPzerosc { get { return m_fldPzerosc; } }
		private static FieldRef m_fldPzerosc = new FieldRef("glob", "pzerosc");

		/// <summary>Field : "100%" Tipo: "N" Formula: + "100+(100-[GLOB->PZEROC])"</summary>
		public decimal ValPzerosc
		{
			get { return (decimal)returnValueField(FldPzerosc); }
			set { insertNameValueField(FldPzerosc, value); }
		}

		/// <summary>Field : "Scorecard type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldTipscard { get { return m_fldTipscard; } }
		private static FieldRef m_fldTipscard = new FieldRef("glob", "tipscard");

		/// <summary>Field : "Scorecard type" Tipo: "AC" Formula:  ""</summary>
		public string ValTipscard
		{
			get { return (string)returnValueField(FldTipscard); }
			set { insertNameValueField(FldTipscard, value); }
		}

		/// <summary>Field : "Organism" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldOrganism { get { return m_fldOrganism; } }
		private static FieldRef m_fldOrganism = new FieldRef("glob", "organism");

		/// <summary>Field : "Organism" Tipo: "C" Formula:  ""</summary>
		public string ValOrganism
		{
			get { return (string)returnValueField(FldOrganism); }
			set { insertNameValueField(FldOrganism, value); }
		}

		/// <summary>Field : "Organism code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCode { get { return m_fldCode; } }
		private static FieldRef m_fldCode = new FieldRef("glob", "code");

		/// <summary>Field : "Organism code" Tipo: "C" Formula:  ""</summary>
		public string ValCode
		{
			get { return (string)returnValueField(FldCode); }
			set { insertNameValueField(FldCode, value); }
		}

		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldMorada { get { return m_fldMorada; } }
		private static FieldRef m_fldMorada = new FieldRef("glob", "morada");

		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public string ValMorada
		{
			get { return (string)returnValueField(FldMorada); }
			set { insertNameValueField(FldMorada, value); }
		}

		/// <summary>Field : "zipcode" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCpostal { get { return m_fldCpostal; } }
		private static FieldRef m_fldCpostal = new FieldRef("glob", "cpostal");

		/// <summary>Field : "zipcode" Tipo: "C" Formula:  ""</summary>
		public string ValCpostal
		{
			get { return (string)returnValueField(FldCpostal); }
			set { insertNameValueField(FldCpostal, value); }
		}

		/// <summary>Field : "Local" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLpostal { get { return m_fldLpostal; } }
		private static FieldRef m_fldLpostal = new FieldRef("glob", "lpostal");

		/// <summary>Field : "Local" Tipo: "C" Formula:  ""</summary>
		public string ValLpostal
		{
			get { return (string)returnValueField(FldLpostal); }
			set { insertNameValueField(FldLpostal, value); }
		}

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTelephon { get { return m_fldTelephon; } }
		private static FieldRef m_fldTelephon = new FieldRef("glob", "telephon");

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon
		{
			get { return (string)returnValueField(FldTelephon); }
			set { insertNameValueField(FldTelephon, value); }
		}

		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFax { get { return m_fldFax; } }
		private static FieldRef m_fldFax = new FieldRef("glob", "fax");

		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public string ValFax
		{
			get { return (string)returnValueField(FldFax); }
			set { insertNameValueField(FldFax, value); }
		}

		/// <summary>Field : "e-mail" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("glob", "email");

		/// <summary>Field : "e-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "URL" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSite { get { return m_fldSite; } }
		private static FieldRef m_fldSite = new FieldRef("glob", "site");

		/// <summary>Field : "URL" Tipo: "C" Formula:  ""</summary>
		public string ValSite
		{
			get { return (string)returnValueField(FldSite); }
			set { insertNameValueField(FldSite, value); }
		}

		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldSimbolo { get { return m_fldSimbolo; } }
		private static FieldRef m_fldSimbolo = new FieldRef("glob", "simbolo");

		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValSimbolo
		{
			get { return (byte[])returnValueField(FldSimbolo); }
			set { insertNameValueField(FldSimbolo, value); }
		}

		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldSimbolol { get { return m_fldSimbolol; } }
		private static FieldRef m_fldSimbolol = new FieldRef("glob", "simbolol");

		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValSimbolol
		{
			get { return (byte[])returnValueField(FldSimbolol); }
			set { insertNameValueField(FldSimbolol, value); }
		}

		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFooterp { get { return m_fldFooterp; } }
		private static FieldRef m_fldFooterp = new FieldRef("glob", "footerp");

		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFooterp
		{
			get { return (byte[])returnValueField(FldFooterp); }
			set { insertNameValueField(FldFooterp, value); }
		}

		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFooterl { get { return m_fldFooterl; } }
		private static FieldRef m_fldFooterl = new FieldRef("glob", "footerl");

		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFooterl
		{
			get { return (byte[])returnValueField(FldFooterl); }
			set { insertNameValueField(FldFooterl, value); }
		}

		/// <summary>Field : "Watermark" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldMarcagua { get { return m_fldMarcagua; } }
		private static FieldRef m_fldMarcagua = new FieldRef("glob", "marcagua");

		/// <summary>Field : "Watermark" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValMarcagua
		{
			get { return (byte[])returnValueField(FldMarcagua); }
			set { insertNameValueField(FldMarcagua, value); }
		}

		/// <summary>Field : "Ministry Logo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldLogomint { get { return m_fldLogomint; } }
		private static FieldRef m_fldLogomint = new FieldRef("glob", "logomint");

		/// <summary>Field : "Ministry Logo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValLogomint
		{
			get { return (byte[])returnValueField(FldLogomint); }
			set { insertNameValueField(FldLogomint, value); }
		}

		/// <summary>Field : "Documents path" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPathdocu { get { return m_fldPathdocu; } }
		private static FieldRef m_fldPathdocu = new FieldRef("glob", "pathdocu");

		/// <summary>Field : "Documents path" Tipo: "C" Formula:  ""</summary>
		public string ValPathdocu
		{
			get { return (string)returnValueField(FldPathdocu); }
			set { insertNameValueField(FldPathdocu, value); }
		}

		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSmtpmail { get { return m_fldSmtpmail; } }
		private static FieldRef m_fldSmtpmail = new FieldRef("glob", "smtpmail");

		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public string ValSmtpmail
		{
			get { return (string)returnValueField(FldSmtpmail); }
			set { insertNameValueField(FldSmtpmail, value); }
		}

		/// <summary>Field : "SMTP Server" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldServsmtp { get { return m_fldServsmtp; } }
		private static FieldRef m_fldServsmtp = new FieldRef("glob", "servsmtp");

		/// <summary>Field : "SMTP Server" Tipo: "C" Formula:  ""</summary>
		public string ValServsmtp
		{
			get { return (string)returnValueField(FldServsmtp); }
			set { insertNameValueField(FldServsmtp, value); }
		}

		/// <summary>Field : "SMTP Port" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSmtpport { get { return m_fldSmtpport; } }
		private static FieldRef m_fldSmtpport = new FieldRef("glob", "smtpport");

		/// <summary>Field : "SMTP Port" Tipo: "N" Formula:  ""</summary>
		public decimal ValSmtpport
		{
			get { return (decimal)returnValueField(FldSmtpport); }
			set { insertNameValueField(FldSmtpport, value); }
		}

		/// <summary>Field : "SSL?" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSmtpssl { get { return m_fldSmtpssl; } }
		private static FieldRef m_fldSmtpssl = new FieldRef("glob", "smtpssl");

		/// <summary>Field : "SSL?" Tipo: "L" Formula:  ""</summary>
		public int ValSmtpssl
		{
			get { return (int)returnValueField(FldSmtpssl); }
			set { insertNameValueField(FldSmtpssl, value); }
		}

		/// <summary>Field : "STMP User Access" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSmtpuser { get { return m_fldSmtpuser; } }
		private static FieldRef m_fldSmtpuser = new FieldRef("glob", "smtpuser");

		/// <summary>Field : "STMP User Access" Tipo: "C" Formula:  ""</summary>
		public string ValSmtpuser
		{
			get { return (string)returnValueField(FldSmtpuser); }
			set { insertNameValueField(FldSmtpuser, value); }
		}

		/// <summary>Field : "SMTP Access Password" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSmtppass { get { return m_fldSmtppass; } }
		private static FieldRef m_fldSmtppass = new FieldRef("glob", "smtppass");

		/// <summary>Field : "SMTP Access Password" Tipo: "C" Formula:  ""</summary>
		public string ValSmtppass
		{
			get { return (string)returnValueField(FldSmtppass); }
			set { insertNameValueField(FldSmtppass, value); }
		}

		/// <summary>Field : "Automatic bonuses" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldTpbonifi { get { return m_fldTpbonifi; } }
		private static FieldRef m_fldTpbonifi = new FieldRef("glob", "tpbonifi");

		/// <summary>Field : "Automatic bonuses" Tipo: "AC" Formula:  ""</summary>
		public string ValTpbonifi
		{
			get { return (string)returnValueField(FldTpbonifi); }
			set { insertNameValueField(FldTpbonifi, value); }
		}

		/// <summary>Field : "Show Closed Maps" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMostrano { get { return m_fldMostrano; } }
		private static FieldRef m_fldMostrano = new FieldRef("glob", "mostrano");

		/// <summary>Field : "Show Closed Maps" Tipo: "L" Formula:  ""</summary>
		public int ValMostrano
		{
			get { return (int)returnValueField(FldMostrano); }
			set { insertNameValueField(FldMostrano, value); }
		}

		/// <summary>Field : "Calculations exclusively with working days?" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSodiasut { get { return m_fldSodiasut; } }
		private static FieldRef m_fldSodiasut = new FieldRef("glob", "sodiasut");

		/// <summary>Field : "Calculations exclusively with working days?" Tipo: "L" Formula:  ""</summary>
		public int ValSodiasut
		{
			get { return (int)returnValueField(FldSodiasut); }
			set { insertNameValueField(FldSodiasut, value); }
		}

		/// <summary>Field : "Executed unique routine" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldExecutou { get { return m_fldExecutou; } }
		private static FieldRef m_fldExecutou = new FieldRef("glob", "executou");

		/// <summary>Field : "Executed unique routine" Tipo: "L" Formula:  ""</summary>
		public int ValExecutou
		{
			get { return (int)returnValueField(FldExecutou); }
			set { insertNameValueField(FldExecutou, value); }
		}

		/// <summary>Field : "Graphix XML" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldXmlgraph { get { return m_fldXmlgraph; } }
		private static FieldRef m_fldXmlgraph = new FieldRef("glob", "xmlgraph");

		/// <summary>Field : "Graphix XML" Tipo: "MO" Formula:  ""</summary>
		public string ValXmlgraph
		{
			get { return (string)returnValueField(FldXmlgraph); }
			set { insertNameValueField(FldXmlgraph, value); }
		}

		/// <summary>Field : "Filter by Organic Unit" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldFiltrorg { get { return m_fldFiltrorg; } }
		private static FieldRef m_fldFiltrorg = new FieldRef("glob", "filtrorg");

		/// <summary>Field : "Filter by Organic Unit" Tipo: "L" Formula:  ""</summary>
		public int ValFiltrorg
		{
			get { return (int)returnValueField(FldFiltrorg); }
			set { insertNameValueField(FldFiltrorg, value); }
		}

		/// <summary>Field : "Scorecard appearance" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldScoreout { get { return m_fldScoreout; } }
		private static FieldRef m_fldScoreout = new FieldRef("glob", "scoreout");

		/// <summary>Field : "Scorecard appearance" Tipo: "AC" Formula:  ""</summary>
		public string ValScoreout
		{
			get { return (string)returnValueField(FldScoreout); }
			set { insertNameValueField(FldScoreout, value); }
		}

		/// <summary>Field : "Ministry" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldMinister { get { return m_fldMinister; } }
		private static FieldRef m_fldMinister = new FieldRef("glob", "minister");

		/// <summary>Field : "Ministry" Tipo: "C" Formula:  ""</summary>
		public string ValMinister
		{
			get { return (string)returnValueField(FldMinister); }
			set { insertNameValueField(FldMinister, value); }
		}

		/// <summary>Field : "Last notification date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtultnot { get { return m_fldDtultnot; } }
		private static FieldRef m_fldDtultnot = new FieldRef("glob", "dtultnot");

		/// <summary>Field : "Last notification date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtultnot
		{
			get { return (DateTime)returnValueField(FldDtultnot); }
			set { insertNameValueField(FldDtultnot, value); }
		}

		/// <summary>Field : "Does it integrate with Document" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldIntegdoc { get { return m_fldIntegdoc; } }
		private static FieldRef m_fldIntegdoc = new FieldRef("glob", "integdoc");

		/// <summary>Field : "Does it integrate with Document" Tipo: "L" Formula:  ""</summary>
		public int ValIntegdoc
		{
			get { return (int)returnValueField(FldIntegdoc); }
			set { insertNameValueField(FldIntegdoc, value); }
		}

		/// <summary>Field : "Objetivos" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPrefobje { get { return m_fldPrefobje; } }
		private static FieldRef m_fldPrefobje = new FieldRef("glob", "prefobje");

		/// <summary>Field : "Objetivos" Tipo: "C" Formula:  ""</summary>
		public string ValPrefobje
		{
			get { return (string)returnValueField(FldPrefobje); }
			set { insertNameValueField(FldPrefobje, value); }
		}

		/// <summary>Field : "Indicator" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPrefindi { get { return m_fldPrefindi; } }
		private static FieldRef m_fldPrefindi = new FieldRef("glob", "prefindi");

		/// <summary>Field : "Indicator" Tipo: "C" Formula:  ""</summary>
		public string ValPrefindi
		{
			get { return (string)returnValueField(FldPrefindi); }
			set { insertNameValueField(FldPrefindi, value); }
		}

		/// <summary>Field : "Gantt - Scale" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGantunit { get { return m_fldGantunit; } }
		private static FieldRef m_fldGantunit = new FieldRef("glob", "gantunit");

		/// <summary>Field : "Gantt - Scale" Tipo: "AC" Formula:  ""</summary>
		public string ValGantunit
		{
			get { return (string)returnValueField(FldGantunit); }
			set { insertNameValueField(FldGantunit, value); }
		}

		/// <summary>Field : "Gantt - Forward" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldGantstep { get { return m_fldGantstep; } }
		private static FieldRef m_fldGantstep = new FieldRef("glob", "gantstep");

		/// <summary>Field : "Gantt - Forward" Tipo: "N" Formula:  ""</summary>
		public decimal ValGantstep
		{
			get { return (decimal)returnValueField(FldGantstep); }
			set { insertNameValueField(FldGantstep, value); }
		}

		/// <summary>Field : "Migrate status/report on initiatives and tasks" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMigrarlt { get { return m_fldMigrarlt; } }
		private static FieldRef m_fldMigrarlt = new FieldRef("glob", "migrarlt");

		/// <summary>Field : "Migrate status/report on initiatives and tasks" Tipo: "L" Formula:  ""</summary>
		public int ValMigrarlt
		{
			get { return (int)returnValueField(FldMigrarlt); }
			set { insertNameValueField(FldMigrarlt, value); }
		}

		/// <summary>Field : "Filter by responsible" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldFiltrrsp { get { return m_fldFiltrrsp; } }
		private static FieldRef m_fldFiltrrsp = new FieldRef("glob", "filtrrsp");

		/// <summary>Field : "Filter by responsible" Tipo: "L" Formula:  ""</summary>
		public int ValFiltrrsp
		{
			get { return (int)returnValueField(FldFiltrrsp); }
			set { insertNameValueField(FldFiltrrsp, value); }
		}

		/// <summary>Field : "Document Path" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldDocbd { get { return m_fldDocbd; } }
		private static FieldRef m_fldDocbd = new FieldRef("glob", "docbd");

		/// <summary>Field : "Document Path" Tipo: "IB" Formula:  ""</summary>
		public string ValDocbd
		{
			get { return (string)returnValueField(FldDocbd); }
			set { insertNameValueField(FldDocbd, value); }
		}

		/// <summary>Field : "Document Path FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldDocbdfk { get { return m_fldDocbdfk; } }
		private static FieldRef m_fldDocbdfk = new FieldRef("glob", "docbdfk");

		/// <summary>Field : "Document Path FK" Tipo: "CE" Formula:  ""</summary>
		public string ValDocbdfk
		{
			get { return (string)returnValueField(FldDocbdfk); }
			set { insertNameValueField(FldDocbdfk, value); }
		}

		/// <summary>Field : "Number of weekly hours" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldHorassem { get { return m_fldHorassem; } }
		private static FieldRef m_fldHorassem = new FieldRef("glob", "horassem");

		/// <summary>Field : "Number of weekly hours" Tipo: "AN" Formula:  ""</summary>
		public decimal ValHorassem
		{
			get { return (decimal)returnValueField(FldHorassem); }
			set { insertNameValueField(FldHorassem, value); }
		}

		/// <summary>Field : "Afetação / Contabilidade Custos" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAfetacao { get { return m_fldAfetacao; } }
		private static FieldRef m_fldAfetacao = new FieldRef("glob", "afetacao");

		/// <summary>Field : "Afetação / Contabilidade Custos" Tipo: "AC" Formula:  ""</summary>
		public string ValAfetacao
		{
			get { return (string)returnValueField(FldAfetacao); }
			set { insertNameValueField(FldAfetacao, value); }
		}

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("glob", "creatdat");

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatope { get { return m_fldCreatope; } }
		private static FieldRef m_fldCreatope = new FieldRef("glob", "creatope");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope
		{
			get { return (string)returnValueField(FldCreatope); }
			set { insertNameValueField(FldCreatope, value); }
		}

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldChngdate { get { return m_fldChngdate; } }
		private static FieldRef m_fldChngdate = new FieldRef("glob", "chngdate");

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValChngdate
		{
			get { return (DateTime)returnValueField(FldChngdate); }
			set { insertNameValueField(FldChngdate, value); }
		}

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldOperchng { get { return m_fldOperchng; } }
		private static FieldRef m_fldOperchng = new FieldRef("glob", "operchng");

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng
		{
			get { return (string)returnValueField(FldOperchng); }
			set { insertNameValueField(FldOperchng, value); }
		}

		/// <summary>Field : "Primary color" Tipo: "C" Formula: + ""#009AA5""</summary>
		public static FieldRef FldPricolor { get { return m_fldPricolor; } }
		private static FieldRef m_fldPricolor = new FieldRef("glob", "pricolor");

		/// <summary>Field : "Primary color" Tipo: "C" Formula: + ""#009AA5""</summary>
		public string ValPricolor
		{
			get { return (string)returnValueField(FldPricolor); }
			set { insertNameValueField(FldPricolor, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodfacty { get { return m_fldCodfacty; } }
		private static FieldRef m_fldCodfacty = new FieldRef("glob", "codfacty");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfacty
		{
			get { return (string)returnValueField(FldCodfacty); }
			set { insertNameValueField(FldCodfacty, value); }
		}

		/// <summary>Field : "Legend" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldLegend { get { return m_fldLegend; } }
		private static FieldRef m_fldLegend = new FieldRef("glob", "legend");

		/// <summary>Field : "Legend" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValLegend
		{
			get { return (byte[])returnValueField(FldLegend); }
			set { insertNameValueField(FldLegend, value); }
		}

		/// <summary>Field : "External API address" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldApiurl { get { return m_fldApiurl; } }
		private static FieldRef m_fldApiurl = new FieldRef("glob", "apiurl");

		/// <summary>Field : "External API address" Tipo: "C" Formula:  ""</summary>
		public string ValApiurl
		{
			get { return (string)returnValueField(FldApiurl); }
			set { insertNameValueField(FldApiurl, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("glob", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

		/// <summary>
		/// Procura a primeira ficha da glob assumindo que vai existir apenas uma
		/// </summary>
		/// <param name="sp">O suporte persistente</param>
		/// <param name="user">O user de contexto da operação</param>
		/// <returns>A ficha da glob</returns>
		public static CSGenioAglob searchGlob(PersistentSupport sp, User user)
		{
			return searchGlob(sp, user, false);
		}

		/// <summary>
		/// Generates the appropriate cache key based on the active data system.
		/// </summary>
		/// <param name="user">The current user.</param>
		/// <returns>A string representing the cache key for the active data system.</returns>
		public static string GetCacheKey(User user)
		{
			// Create a unique cache key per data system.
			return $"glob.{user.Year}";
		}

		/// <summary>
		/// Procura a primeira ficha da glob assumindo que vai existir apenas uma
		/// </summary>
		/// <param name="sp">O suporte persistente</param>
		/// <param name="user">O user de contexto da operação</param>
		/// <param name="forceRead">True se queremos forçar a cache a ser ignorada</param>
		/// <returns>A ficha da glob</returns>
		public static CSGenioAglob searchGlob(PersistentSupport sp, User user, bool forceRead)
		{
			// Not using locks since all the following scenarios seem acceptable:

			// Scenario 1: If `Invalidate` runs before the next `searchListWhere`,
			// the algorithm performs a `Cache.Put` with a new value.

			// Scenario 2: If `Invalidate` runs after the next `searchListWhere`
			// but before `Cache.Put`, the algorithm still performs a `Cache.Put` with a new value.

			// Scenario 3: If `Invalidate` runs after `Cache.Put`,
			// the cache will be empty, and the next call will trigger an additional `searchListWhere`.

			CSGenioAglob cachedGlob = (CSGenioAglob)QCache.Instance.Records.Get(GetCacheKey(user));

			if (cachedGlob == null || forceRead)
			{
				//só deve existir uma row na table glob
				List<CSGenioAglob> res = sp.searchListWhere<CSGenioAglob>((CriteriaSet)null, user, null);
				if (res.Count > 0)
				{
					cachedGlob = res[0];
					QCache.Instance.Records.Put(GetCacheKey(user), cachedGlob);

					return cachedGlob;
				}
				
				throw new BusinessException(Translations.Get("O registo não foi encontrado.", user.Language), "CSGenioAglob.searchGlob", "Glob record not found.");
			}

			// Clone instance obtained from cache.
			CSGenioAglob glob = new CSGenioAglob(user);
			glob.CloneFrom(cachedGlob);

			return glob;
		}

		/// <summary>
		/// Invalidates the GLOB cache, forcing the next read to visit the database.
		/// </summary>
		/// <param name="user">The current user.</param>
		public static void InvalidateCache(User user)
		{
			QCache.Instance.Records.Invalidate(GetCacheKey(user));
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
        public static CSGenioAglob search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAglob area = new CSGenioAglob(user, user.CurrentModule);

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
        public static List<CSGenioAglob> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAglob>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAglob> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAglob>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);






		/// <summary>
        /// To use routine manual validations and extra calculations
		/// before the update of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="oldvalues">The oldvalues.</param>
		public override StatusMessage beforeUpdate(PersistentSupport sp, Area oldvalues)
		{
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// after the update of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
        /// <param name="oldvalues">The oldvalues.</param>
		public override StatusMessage afterUpdate(PersistentSupport sp, Area oldvalues)
		{
			CSGenioAglob.InvalidateCache(User);
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// before the insert of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage beforeInsert(PersistentSupport sp)
		{
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// after the insert of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage afterInsert(PersistentSupport sp)
		{
			CSGenioAglob.InvalidateCache(User);
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// before the duplicate of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage beforeDuplicate(PersistentSupport sp)
		{
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// after the duplicate of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage afterDuplicate(PersistentSupport sp)
		{
			CSGenioAglob.InvalidateCache(User);
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// before the eliminate of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage beforeEliminate(PersistentSupport sp)
		{
            return StatusMessage.OK();
		}

		/// <summary>
        /// To use routine manual validations and extra calculations
		/// after the eliminate of the record.
        /// </summary>
        /// <param name="sp">The sp.</param>
		public override StatusMessage afterEliminate(PersistentSupport sp)
		{
			CSGenioAglob.InvalidateCache(User);
            return StatusMessage.OK();
		}



		// USE /[MANUAL GQT TABAUX GLOB]/

     

                                                                                    

	}
}
