
 
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
	/// Entity
	/// </summary>
	public class CSGenioAentit : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAentit(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ENTIT]/
		}

		public CSGenioAentit(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codentit", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Legal name";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LEGAL_NAME42902";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "initials", FieldType.TEXT);
			Qfield.FieldDescription = "Iniciais da empresa";
			Qfield.FieldSize =  10;
			Qfield.CavDesignation = "COMPANY_INITIALS56204";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "registra", FieldType.TEXT);
			Qfield.FieldDescription = "Legal registration";
			Qfield.FieldSize =  30;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LEGAL_REGISTRATION04413";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "taxnumbe", FieldType.TEXT);
			Qfield.FieldDescription = "VAT Number";
			Qfield.FieldSize =  30;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "VAT_NUMBER24236";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "phonenum", FieldType.TEXT);
			Qfield.FieldDescription = "Phone number";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHONE_NUMBER20774";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "iban", FieldType.TEXT);
			Qfield.FieldDescription = "IBAN (International Bank Account Number)";
			Qfield.FieldSize =  33;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IBAN__INTERNATIONAL_45066";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "building", FieldType.TEXT);
			Qfield.FieldDescription = "Número do edifício/casa";
			Qfield.FieldSize =  25;
			Qfield.CavDesignation = "BUILDING_HOUSE_NUMBE20738";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "street", FieldType.TEXT);
			Qfield.FieldDescription = "Street";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "STREET44324";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "town", FieldType.TEXT);
			Qfield.FieldDescription = "Town/City";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "TOWN_CITY16259";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "county", FieldType.TEXT);
			Qfield.FieldDescription = "Concelho/Província";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "COUNTY_PROVINCE34285";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "state", FieldType.TEXT);
			Qfield.FieldDescription = "State/Province";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "STATE_PROVINCE28516";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pobox", FieldType.TEXT);
			Qfield.FieldDescription = "Post office box";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "POST_OFFICE_BOX06223";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "postalco", FieldType.TEXT);
			Qfield.FieldDescription = "ZIP/Postal code";
			Qfield.FieldSize =  10;
			Qfield.CavDesignation = "ZIP_POSTAL_CODE55613";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "telephon", FieldType.TEXT);
			Qfield.FieldDescription = "Telephone";
			Qfield.FieldSize =  20;
			Qfield.CavDesignation = "TELEPHONE28697";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "fax", FieldType.TEXT);
			Qfield.FieldDescription = "Fax";
			Qfield.FieldSize =  20;
			Qfield.CavDesignation = "FAX08532";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "website", FieldType.TEXT);
			Qfield.FieldDescription = "Web site";
			Qfield.FieldSize =  254;
			Qfield.CavDesignation = "WEB_SITE06263";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "person", FieldType.TEXT);
			Qfield.FieldDescription = "Person/Department to contact";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "PERSON_DEPARTMENT_TO28777";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "contact", FieldType.TEXT);
			Qfield.FieldDescription = "Contact telephone number";
			Qfield.FieldSize =  30;
			Qfield.CavDesignation = "CONTACT_TELEPHONE_NU12694";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "owner", FieldType.TEXT);
			Qfield.FieldDescription = "Owner";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OWNER09558";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "carrier", FieldType.LOGIC);
			Qfield.FieldDescription = "Carrier";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CARRIER64855";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "supplier", FieldType.LOGIC);
			Qfield.FieldDescription = "Supplier";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SUPPLIER17230";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "manufact", FieldType.LOGIC);
			Qfield.FieldDescription = "Manufacturer";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "MANUFACTURER50759";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "founded", FieldType.DATE);
			Qfield.FieldDescription = "Founded in";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FOUNDED_IN54120";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "firstfacilitie", FieldType.KEY_INT);
			Qfield.FieldDescription = "Primeira instalação incorporada";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FIRST_INCORPORATED_F63789";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtfacility", "founded", "incorpor", "codfacil", SortOrder.Ascending, LookupFormulaType.Previous, "codentit", "codentit");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "lastfacilitie", FieldType.KEY_INT);
			Qfield.FieldDescription = "Last incorporated facility";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LAST_INCORPORATED_FA29541";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtfacility", "founded", "incorpor", "codfacil", SortOrder.Descending, LookupFormulaType.Next, "codentit", "codentit");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "language", FieldType.TEXT);
			Qfield.FieldDescription = "Language";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "LANGUAGE16872";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "currency", FieldType.TEXT);
			Qfield.FieldDescription = "Currency";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CURRENCY13881";

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
			info.ChildTable = new ChildRelation[7];
			info.ChildTable[0]= new ChildRelation("dispa", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("relin", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("locat", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("messa", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("recei", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("facil", new String[] {"codentit"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("asset", new String[] {"codmanuf"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("faci1", new Relation("GQT", "gqtentity", "entit", "codentit", "firstfacilitie", "GQT", "gqtfacility", "faci1", "codfacil", "codfacil"));
			info.ParentTables.Add("faci2", new Relation("GQT", "gqtentity", "entit", "codentit", "lastfacilitie", "GQT", "gqtfacility", "faci2", "codfacil", "codfacil"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("faci1","faci1");
			info.Pathways.Add("faci2","faci2");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.CheckTableFields = new string[] {
			 "firstfacilitie","lastfacilitie"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAentit()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtentity";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codentit";
			info.HumanKeyName="name,initials,".TrimEnd(',');
			info.Alias="entit";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Entity";
			info.AreaPluralDesignation="Entities";
			info.DescriptionCav="ENTITY62049";

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
		public static FieldRef FldCodentit { get { return m_fldCodentit; } }
		private static FieldRef m_fldCodentit = new FieldRef("entit", "codentit");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodentit
		{
			get { return (string)returnValueField(FldCodentit); }
			set { insertNameValueField(FldCodentit, value); }
		}

		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("entit", "name");

		/// <summary>Field : "Legal name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldInitials { get { return m_fldInitials; } }
		private static FieldRef m_fldInitials = new FieldRef("entit", "initials");

		/// <summary>Field : "Company initials" Tipo: "C" Formula:  ""</summary>
		public string ValInitials
		{
			get { return (string)returnValueField(FldInitials); }
			set { insertNameValueField(FldInitials, value); }
		}

		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldRegistra { get { return m_fldRegistra; } }
		private static FieldRef m_fldRegistra = new FieldRef("entit", "registra");

		/// <summary>Field : "Legal registration" Tipo: "C" Formula:  ""</summary>
		public string ValRegistra
		{
			get { return (string)returnValueField(FldRegistra); }
			set { insertNameValueField(FldRegistra, value); }
		}

		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTaxnumbe { get { return m_fldTaxnumbe; } }
		private static FieldRef m_fldTaxnumbe = new FieldRef("entit", "taxnumbe");

		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public string ValTaxnumbe
		{
			get { return (string)returnValueField(FldTaxnumbe); }
			set { insertNameValueField(FldTaxnumbe, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("entit", "email");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPhonenum { get { return m_fldPhonenum; } }
		private static FieldRef m_fldPhonenum = new FieldRef("entit", "phonenum");

		/// <summary>Field : "Phone number" Tipo: "C" Formula:  ""</summary>
		public string ValPhonenum
		{
			get { return (string)returnValueField(FldPhonenum); }
			set { insertNameValueField(FldPhonenum, value); }
		}

		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIban { get { return m_fldIban; } }
		private static FieldRef m_fldIban = new FieldRef("entit", "iban");

		/// <summary>Field : "IBAN (International Bank Account Number)" Tipo: "C" Formula:  ""</summary>
		public string ValIban
		{
			get { return (string)returnValueField(FldIban); }
			set { insertNameValueField(FldIban, value); }
		}

		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBuilding { get { return m_fldBuilding; } }
		private static FieldRef m_fldBuilding = new FieldRef("entit", "building");

		/// <summary>Field : "Building/house number" Tipo: "C" Formula:  ""</summary>
		public string ValBuilding
		{
			get { return (string)returnValueField(FldBuilding); }
			set { insertNameValueField(FldBuilding, value); }
		}

		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldStreet { get { return m_fldStreet; } }
		private static FieldRef m_fldStreet = new FieldRef("entit", "street");

		/// <summary>Field : "Street" Tipo: "C" Formula:  ""</summary>
		public string ValStreet
		{
			get { return (string)returnValueField(FldStreet); }
			set { insertNameValueField(FldStreet, value); }
		}

		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTown { get { return m_fldTown; } }
		private static FieldRef m_fldTown = new FieldRef("entit", "town");

		/// <summary>Field : "Town/City" Tipo: "C" Formula:  ""</summary>
		public string ValTown
		{
			get { return (string)returnValueField(FldTown); }
			set { insertNameValueField(FldTown, value); }
		}

		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCounty { get { return m_fldCounty; } }
		private static FieldRef m_fldCounty = new FieldRef("entit", "county");

		/// <summary>Field : "County/Province" Tipo: "C" Formula:  ""</summary>
		public string ValCounty
		{
			get { return (string)returnValueField(FldCounty); }
			set { insertNameValueField(FldCounty, value); }
		}

		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldState { get { return m_fldState; } }
		private static FieldRef m_fldState = new FieldRef("entit", "state");

		/// <summary>Field : "State/Province" Tipo: "C" Formula:  ""</summary>
		public string ValState
		{
			get { return (string)returnValueField(FldState); }
			set { insertNameValueField(FldState, value); }
		}

		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPobox { get { return m_fldPobox; } }
		private static FieldRef m_fldPobox = new FieldRef("entit", "pobox");

		/// <summary>Field : "Post office box" Tipo: "C" Formula:  ""</summary>
		public string ValPobox
		{
			get { return (string)returnValueField(FldPobox); }
			set { insertNameValueField(FldPobox, value); }
		}

		/// <summary>Field : "ZIP/Postal code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPostalco { get { return m_fldPostalco; } }
		private static FieldRef m_fldPostalco = new FieldRef("entit", "postalco");

		/// <summary>Field : "ZIP/Postal code" Tipo: "C" Formula:  ""</summary>
		public string ValPostalco
		{
			get { return (string)returnValueField(FldPostalco); }
			set { insertNameValueField(FldPostalco, value); }
		}

		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTelephon { get { return m_fldTelephon; } }
		private static FieldRef m_fldTelephon = new FieldRef("entit", "telephon");

		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon
		{
			get { return (string)returnValueField(FldTelephon); }
			set { insertNameValueField(FldTelephon, value); }
		}

		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFax { get { return m_fldFax; } }
		private static FieldRef m_fldFax = new FieldRef("entit", "fax");

		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public string ValFax
		{
			get { return (string)returnValueField(FldFax); }
			set { insertNameValueField(FldFax, value); }
		}

		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldWebsite { get { return m_fldWebsite; } }
		private static FieldRef m_fldWebsite = new FieldRef("entit", "website");

		/// <summary>Field : "Web site" Tipo: "C" Formula:  ""</summary>
		public string ValWebsite
		{
			get { return (string)returnValueField(FldWebsite); }
			set { insertNameValueField(FldWebsite, value); }
		}

		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPerson { get { return m_fldPerson; } }
		private static FieldRef m_fldPerson = new FieldRef("entit", "person");

		/// <summary>Field : "Person/Department to contact" Tipo: "C" Formula:  ""</summary>
		public string ValPerson
		{
			get { return (string)returnValueField(FldPerson); }
			set { insertNameValueField(FldPerson, value); }
		}

		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldContact { get { return m_fldContact; } }
		private static FieldRef m_fldContact = new FieldRef("entit", "contact");

		/// <summary>Field : "Contact telephone number" Tipo: "C" Formula:  ""</summary>
		public string ValContact
		{
			get { return (string)returnValueField(FldContact); }
			set { insertNameValueField(FldContact, value); }
		}

		/// <summary>Field : "Owner" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldOwner { get { return m_fldOwner; } }
		private static FieldRef m_fldOwner = new FieldRef("entit", "owner");

		/// <summary>Field : "Owner" Tipo: "C" Formula:  ""</summary>
		public string ValOwner
		{
			get { return (string)returnValueField(FldOwner); }
			set { insertNameValueField(FldOwner, value); }
		}

		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCarrier { get { return m_fldCarrier; } }
		private static FieldRef m_fldCarrier = new FieldRef("entit", "carrier");

		/// <summary>Field : "Carrier" Tipo: "L" Formula:  ""</summary>
		public int ValCarrier
		{
			get { return (int)returnValueField(FldCarrier); }
			set { insertNameValueField(FldCarrier, value); }
		}

		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSupplier { get { return m_fldSupplier; } }
		private static FieldRef m_fldSupplier = new FieldRef("entit", "supplier");

		/// <summary>Field : "Supplier" Tipo: "L" Formula:  ""</summary>
		public int ValSupplier
		{
			get { return (int)returnValueField(FldSupplier); }
			set { insertNameValueField(FldSupplier, value); }
		}

		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldManufact { get { return m_fldManufact; } }
		private static FieldRef m_fldManufact = new FieldRef("entit", "manufact");

		/// <summary>Field : "Manufacturer" Tipo: "L" Formula:  ""</summary>
		public int ValManufact
		{
			get { return (int)returnValueField(FldManufact); }
			set { insertNameValueField(FldManufact, value); }
		}

		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldFounded { get { return m_fldFounded; } }
		private static FieldRef m_fldFounded = new FieldRef("entit", "founded");

		/// <summary>Field : "Founded in" Tipo: "D" Formula:  ""</summary>
		public DateTime ValFounded
		{
			get { return (DateTime)returnValueField(FldFounded); }
			set { insertNameValueField(FldFounded, value); }
		}

		/// <summary>Field : "First incorporated facility" Tipo: "CE" Formula: CT "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](ASC)"</summary>
		public static FieldRef FldFirstfacilitie { get { return m_fldFirstfacilitie; } }
		private static FieldRef m_fldFirstfacilitie = new FieldRef("entit", "firstfacilitie");

		/// <summary>Field : "First incorporated facility" Tipo: "CE" Formula: CT "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](ASC)"</summary>
		public string ValFirstfacilitie
		{
			get { return (string)returnValueField(FldFirstfacilitie); }
			set { insertNameValueField(FldFirstfacilitie, value); }
		}

		/// <summary>Field : "Last incorporated facility" Tipo: "CE" Formula: CS "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](DESC)"</summary>
		public static FieldRef FldLastfacilitie { get { return m_fldLastfacilitie; } }
		private static FieldRef m_fldLastfacilitie = new FieldRef("entit", "lastfacilitie");

		/// <summary>Field : "Last incorporated facility" Tipo: "CE" Formula: CS "FACIL[ENTIT->FOUNDED][FACIL->INCORPOR][FACIL->CODFACIL][ENTIT->CODENTIT][FACIL->CODENTIT](DESC)"</summary>
		public string ValLastfacilitie
		{
			get { return (string)returnValueField(FldLastfacilitie); }
			set { insertNameValueField(FldLastfacilitie, value); }
		}

		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLanguage { get { return m_fldLanguage; } }
		private static FieldRef m_fldLanguage = new FieldRef("entit", "language");

		/// <summary>Field : "Language" Tipo: "C" Formula:  ""</summary>
		public string ValLanguage
		{
			get { return (string)returnValueField(FldLanguage); }
			set { insertNameValueField(FldLanguage, value); }
		}

		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCurrency { get { return m_fldCurrency; } }
		private static FieldRef m_fldCurrency = new FieldRef("entit", "currency");

		/// <summary>Field : "Currency" Tipo: "C" Formula:  ""</summary>
		public string ValCurrency
		{
			get { return (string)returnValueField(FldCurrency); }
			set { insertNameValueField(FldCurrency, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("entit", "zzstate");



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
        public static CSGenioAentit search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAentit area = new CSGenioAentit(user, user.CurrentModule);

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
        public static List<CSGenioAentit> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAentit>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAentit> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAentit>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ENTIT]/

     
                              

	}
}
