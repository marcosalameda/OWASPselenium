

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
	/// Input Group
	/// </summary>
	public class CSGenioAinpgr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAinpgr(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR INPGR]/
		}

		public CSGenioAinpgr(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codinpgr", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "icongro", FieldType.TEXTO);
			Qfield.FieldDescription = "Icon";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ICON41974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "numbgro", FieldType.NUMERO);
			Qfield.FieldDescription = "VAT Number";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.CavDesignation = "VAT_NUMBER24236";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "textgro", FieldType.TEXTO);
			Qfield.FieldDescription = "Text Field";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT_FIELD41810";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buttngro", FieldType.TEXTO);
			Qfield.FieldDescription = "Button";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BUTTON10521";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "spangro", FieldType.TEXTO);
			Qfield.FieldDescription = "Profile";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PROFILE65433";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iconspan", FieldType.TEXTO);
			Qfield.FieldDescription = "Icon";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ICON41974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXTO);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NAME31974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "lastname", FieldType.TEXTO);
			Qfield.FieldDescription = "Last name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LAST_NAME63426";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "adress", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Address type";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS_TYPE64627";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCaddresst";
            Qfield.ArrayClassName = "Addresst";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prefix", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Prefix";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PREFIX02493";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCphonepre";
            Qfield.ArrayClassName = "Phonepre";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "phone", FieldType.NUMERO);
			Qfield.FieldDescription = "Phone number";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "PHONE_NUMBER20774";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXTO);
			Qfield.FieldDescription = "E-mail";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "E_MAIL42251";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateEM(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "web", FieldType.TEXTO);
			Qfield.FieldDescription = "Web";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "WEB09813";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iban", FieldType.TEXTO);
			Qfield.FieldDescription = "IBAN";
			Qfield.FieldSize =  34;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IBAN28506";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateIN(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bankacco", FieldType.TEXTO);
			Qfield.FieldDescription = "Banking Account Number";
			Qfield.FieldSize =  24;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BANKING_ACCOUNT_NUMB62548";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateIB(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "textspan", FieldType.TEXTO);
			Qfield.FieldDescription = "Text";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT04938";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "directio", FieldType.TEXTO);
			Qfield.FieldDescription = "Adress";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADRESS39816";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bankcomp", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Entity";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ENTITY62049";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCbankcomp";
            Qfield.ArrayClassName = "Bankcomp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEIRO);
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








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAinpgr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtinpgr";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codinpgr";
			info.HumanKeyName="icongro,".TrimEnd(',');
			info.Alias="inpgr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Input Group";
			info.AreaPluralDesignation="Input Groups";
			info.DescriptionCav="INPUT_GROUP17182";

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
		public static FieldRef FldCodinpgr { get { return m_fldCodinpgr; } }
		private static FieldRef m_fldCodinpgr = new FieldRef("inpgr", "codinpgr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodinpgr
		{
			get { return (string)returnValueField(FldCodinpgr); }
			set { insertNameValueField(FldCodinpgr, value); }
		}

		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIcongro { get { return m_fldIcongro; } }
		private static FieldRef m_fldIcongro = new FieldRef("inpgr", "icongro");

		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public string ValIcongro
		{
			get { return (string)returnValueField(FldIcongro); }
			set { insertNameValueField(FldIcongro, value); }
		}

		/// <summary>Field : "VAT Number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumbgro { get { return m_fldNumbgro; } }
		private static FieldRef m_fldNumbgro = new FieldRef("inpgr", "numbgro");

		/// <summary>Field : "VAT Number" Tipo: "N" Formula:  ""</summary>
		public decimal ValNumbgro
		{
			get { return (decimal)returnValueField(FldNumbgro); }
			set { insertNameValueField(FldNumbgro, value); }
		}

		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTextgro { get { return m_fldTextgro; } }
		private static FieldRef m_fldTextgro = new FieldRef("inpgr", "textgro");

		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public string ValTextgro
		{
			get { return (string)returnValueField(FldTextgro); }
			set { insertNameValueField(FldTextgro, value); }
		}

		/// <summary>Field : "Button" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldButtngro { get { return m_fldButtngro; } }
		private static FieldRef m_fldButtngro = new FieldRef("inpgr", "buttngro");

		/// <summary>Field : "Button" Tipo: "C" Formula:  ""</summary>
		public string ValButtngro
		{
			get { return (string)returnValueField(FldButtngro); }
			set { insertNameValueField(FldButtngro, value); }
		}

		/// <summary>Field : "Profile" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSpangro { get { return m_fldSpangro; } }
		private static FieldRef m_fldSpangro = new FieldRef("inpgr", "spangro");

		/// <summary>Field : "Profile" Tipo: "C" Formula:  ""</summary>
		public string ValSpangro
		{
			get { return (string)returnValueField(FldSpangro); }
			set { insertNameValueField(FldSpangro, value); }
		}

		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIconspan { get { return m_fldIconspan; } }
		private static FieldRef m_fldIconspan = new FieldRef("inpgr", "iconspan");

		/// <summary>Field : "Icon" Tipo: "C" Formula:  ""</summary>
		public string ValIconspan
		{
			get { return (string)returnValueField(FldIconspan); }
			set { insertNameValueField(FldIconspan, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("inpgr", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Last name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLastname { get { return m_fldLastname; } }
		private static FieldRef m_fldLastname = new FieldRef("inpgr", "lastname");

		/// <summary>Field : "Last name" Tipo: "C" Formula:  ""</summary>
		public string ValLastname
		{
			get { return (string)returnValueField(FldLastname); }
			set { insertNameValueField(FldLastname, value); }
		}

		/// <summary>Field : "Address type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAdress { get { return m_fldAdress; } }
		private static FieldRef m_fldAdress = new FieldRef("inpgr", "adress");

		/// <summary>Field : "Address type" Tipo: "AC" Formula:  ""</summary>
		public string ValAdress
		{
			get { return (string)returnValueField(FldAdress); }
			set { insertNameValueField(FldAdress, value); }
		}

		/// <summary>Field : "Prefix" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldPrefix { get { return m_fldPrefix; } }
		private static FieldRef m_fldPrefix = new FieldRef("inpgr", "prefix");

		/// <summary>Field : "Prefix" Tipo: "AC" Formula:  ""</summary>
		public string ValPrefix
		{
			get { return (string)returnValueField(FldPrefix); }
			set { insertNameValueField(FldPrefix, value); }
		}

		/// <summary>Field : "Phone number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPhone { get { return m_fldPhone; } }
		private static FieldRef m_fldPhone = new FieldRef("inpgr", "phone");

		/// <summary>Field : "Phone number" Tipo: "N" Formula:  ""</summary>
		public decimal ValPhone
		{
			get { return (decimal)returnValueField(FldPhone); }
			set { insertNameValueField(FldPhone, value); }
		}

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("inpgr", "email");

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Web" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldWeb { get { return m_fldWeb; } }
		private static FieldRef m_fldWeb = new FieldRef("inpgr", "web");

		/// <summary>Field : "Web" Tipo: "C" Formula:  ""</summary>
		public string ValWeb
		{
			get { return (string)returnValueField(FldWeb); }
			set { insertNameValueField(FldWeb, value); }
		}

		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIban { get { return m_fldIban; } }
		private static FieldRef m_fldIban = new FieldRef("inpgr", "iban");

		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public string ValIban
		{
			get { return (string)returnValueField(FldIban); }
			set { insertNameValueField(FldIban, value); }
		}

		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBankacco { get { return m_fldBankacco; } }
		private static FieldRef m_fldBankacco = new FieldRef("inpgr", "bankacco");

		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public string ValBankacco
		{
			get { return (string)returnValueField(FldBankacco); }
			set { insertNameValueField(FldBankacco, value); }
		}

		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTextspan { get { return m_fldTextspan; } }
		private static FieldRef m_fldTextspan = new FieldRef("inpgr", "textspan");

		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValTextspan
		{
			get { return (string)returnValueField(FldTextspan); }
			set { insertNameValueField(FldTextspan, value); }
		}

		/// <summary>Field : "Adress" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDirectio { get { return m_fldDirectio; } }
		private static FieldRef m_fldDirectio = new FieldRef("inpgr", "directio");

		/// <summary>Field : "Adress" Tipo: "C" Formula:  ""</summary>
		public string ValDirectio
		{
			get { return (string)returnValueField(FldDirectio); }
			set { insertNameValueField(FldDirectio, value); }
		}

		/// <summary>Field : "Entity" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldBankcomp { get { return m_fldBankcomp; } }
		private static FieldRef m_fldBankcomp = new FieldRef("inpgr", "bankcomp");

		/// <summary>Field : "Entity" Tipo: "AC" Formula:  ""</summary>
		public string ValBankcomp
		{
			get { return (string)returnValueField(FldBankcomp); }
			set { insertNameValueField(FldBankcomp, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("inpgr", "zzstate");



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
        public static CSGenioAinpgr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAinpgr area = new CSGenioAinpgr(user, user.CurrentModule);

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
        public static List<CSGenioAinpgr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAinpgr>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAinpgr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAinpgr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX INPGR]/

     

                    

	}
}
