

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
	/// Sale
	/// </summary>
	public class CSGenioAsale : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAsale(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR SALE]/
		}

		public CSGenioAsale(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codvenda", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codorgan", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nrlide", FieldType.NUMERO);
			Qfield.FieldDescription = "leadership numb";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "LEADERSHIP_NUMB16426";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "startdt", FieldType.DATAHORA);
			Qfield.FieldDescription = "Beginning";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "BEGINNING18124";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "identifi", FieldType.TEXTO);
			Qfield.FieldDescription = "Identification of business opportunity";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "IDENTIFICATION_OF_BU58085";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "potcompr", FieldType.TEXTO);
			Qfield.FieldDescription = "Potential Buyers";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "POTENTIAL_BUYERS56564";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prospecc", FieldType.LOGICO);
			Qfield.FieldDescription = "Prospecting carried out";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "PROSPECTING_CARRIED_08979";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "interess", FieldType.LOGICO);
			Qfield.FieldDescription = "Interested";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "INTERESTED34576";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrfina", FieldType.LOGICO);
			Qfield.FieldDescription = "Without financial resources";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "WITHOUT_FINANCIAL_RE07914";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semcapac", FieldType.LOGICO);
			Qfield.FieldDescription = "No decision-making power";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "NO_DECISION_MAKING_P36615";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtqualif", FieldType.DATAHORA);
			Qfield.FieldDescription = "Qualification";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "QUALIFICATION64257";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "qualific", FieldType.LOGICO);
			Qfield.FieldDescription = "Qualification carried out";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "QUALIFICATION_CARRIE05255";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "preabord", FieldType.DATAHORA);
			Qfield.FieldDescription = "Pre-approach";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "PRE_APPROACH58979";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "homework", FieldType.LOGICO);
			Qfield.FieldDescription = "Homework done";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "HOMEWORK_DONE45166";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtaborda", FieldType.DATAHORA);
			Qfield.FieldDescription = "Approach";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "APPROACH06577";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "approach", FieldType.LOGICO);
			Qfield.FieldDescription = "Abordagem efectuada";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "ABORDAGEM_EFECTUADA60152";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "apresent", FieldType.LOGICO);
			Qfield.FieldDescription = "Presentation";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "PRESENTATION64246";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtaprese", FieldType.DATAHORA);
			Qfield.FieldDescription = "Presentation made";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "PRESENTATION_MADE15117";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtsupera", FieldType.DATAHORA);
			Qfield.FieldDescription = "Overcome objections";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "OVERCOME_OBJECTIONS61930";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tentfech", FieldType.DATAHORA);
			Qfield.FieldDescription = "Closing attempts";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "CLOSING_ATTEMPTS40059";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtvenda", FieldType.DATAHORA);
			Qfield.FieldDescription = "Closing of the sale";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "CLOSING_OF_THE_SALE05493";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtacompa", FieldType.DATAHORA);
			Qfield.FieldDescription = "Follow-up";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "FOLLOW_UP22119";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "showrcrd", FieldType.LOGICO);
			Qfield.FieldDescription = "Show Record";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHOW_RECORD11620";

			Qfield.Dupmsg = "";
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
			info.ParentTables.Add("organ", new Relation("GQT", "gqtsale", "sale", "codvenda", "codorgan", "GQT", "gqtorgan", "organ", "codorgan", "codorgan"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("organ","organ");
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
		/// static CSGenioAsale()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtsale";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codvenda";
			info.HumanKeyName="identifi,".TrimEnd(',');
			info.Alias="sale";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Sale";
			info.AreaPluralDesignation="Sales";
			info.DescriptionCav="SALE02786";

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
			camposEPH[0] = new EPHField("ORGAN", "organ", "codorgan", "EN", false);
			info.Ephs.Add(new Par("GQT", "2"), camposEPH);

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
		public static FieldRef FldCodvenda { get { return m_fldCodvenda; } }
		private static FieldRef m_fldCodvenda = new FieldRef("sale", "codvenda");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodvenda
		{
			get { return (string)returnValueField(FldCodvenda); }
			set { insertNameValueField(FldCodvenda, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodorgan { get { return m_fldCodorgan; } }
		private static FieldRef m_fldCodorgan = new FieldRef("sale", "codorgan");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodorgan
		{
			get { return (string)returnValueField(FldCodorgan); }
			set { insertNameValueField(FldCodorgan, value); }
		}

		/// <summary>Field : "leadership numb" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNrlide { get { return m_fldNrlide; } }
		private static FieldRef m_fldNrlide = new FieldRef("sale", "nrlide");

		/// <summary>Field : "leadership numb" Tipo: "N" Formula:  ""</summary>
		public decimal ValNrlide
		{
			get { return (decimal)returnValueField(FldNrlide); }
			set { insertNameValueField(FldNrlide, value); }
		}

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldStartdt { get { return m_fldStartdt; } }
		private static FieldRef m_fldStartdt = new FieldRef("sale", "startdt");

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValStartdt
		{
			get { return (DateTime)returnValueField(FldStartdt); }
			set { insertNameValueField(FldStartdt, value); }
		}

		/// <summary>Field : "Identification of business opportunity" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdentifi { get { return m_fldIdentifi; } }
		private static FieldRef m_fldIdentifi = new FieldRef("sale", "identifi");

		/// <summary>Field : "Identification of business opportunity" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi
		{
			get { return (string)returnValueField(FldIdentifi); }
			set { insertNameValueField(FldIdentifi, value); }
		}

		/// <summary>Field : "Potential Buyers" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPotcompr { get { return m_fldPotcompr; } }
		private static FieldRef m_fldPotcompr = new FieldRef("sale", "potcompr");

		/// <summary>Field : "Potential Buyers" Tipo: "C" Formula:  ""</summary>
		public string ValPotcompr
		{
			get { return (string)returnValueField(FldPotcompr); }
			set { insertNameValueField(FldPotcompr, value); }
		}

		/// <summary>Field : "Prospecting carried out" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldProspecc { get { return m_fldProspecc; } }
		private static FieldRef m_fldProspecc = new FieldRef("sale", "prospecc");

		/// <summary>Field : "Prospecting carried out" Tipo: "L" Formula:  ""</summary>
		public int ValProspecc
		{
			get { return (int)returnValueField(FldProspecc); }
			set { insertNameValueField(FldProspecc, value); }
		}

		/// <summary>Field : "Interested" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldInteress { get { return m_fldInteress; } }
		private static FieldRef m_fldInteress = new FieldRef("sale", "interess");

		/// <summary>Field : "Interested" Tipo: "L" Formula:  ""</summary>
		public int ValInteress
		{
			get { return (int)returnValueField(FldInteress); }
			set { insertNameValueField(FldInteress, value); }
		}

		/// <summary>Field : "Without financial resources" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrfina { get { return m_fldSemrfina; } }
		private static FieldRef m_fldSemrfina = new FieldRef("sale", "semrfina");

		/// <summary>Field : "Without financial resources" Tipo: "L" Formula:  ""</summary>
		public int ValSemrfina
		{
			get { return (int)returnValueField(FldSemrfina); }
			set { insertNameValueField(FldSemrfina, value); }
		}

		/// <summary>Field : "No decision-making power" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemcapac { get { return m_fldSemcapac; } }
		private static FieldRef m_fldSemcapac = new FieldRef("sale", "semcapac");

		/// <summary>Field : "No decision-making power" Tipo: "L" Formula:  ""</summary>
		public int ValSemcapac
		{
			get { return (int)returnValueField(FldSemcapac); }
			set { insertNameValueField(FldSemcapac, value); }
		}

		/// <summary>Field : "Qualification" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtqualif { get { return m_fldDtqualif; } }
		private static FieldRef m_fldDtqualif = new FieldRef("sale", "dtqualif");

		/// <summary>Field : "Qualification" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtqualif
		{
			get { return (DateTime)returnValueField(FldDtqualif); }
			set { insertNameValueField(FldDtqualif, value); }
		}

		/// <summary>Field : "Qualification carried out" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldQualific { get { return m_fldQualific; } }
		private static FieldRef m_fldQualific = new FieldRef("sale", "qualific");

		/// <summary>Field : "Qualification carried out" Tipo: "L" Formula:  ""</summary>
		public int ValQualific
		{
			get { return (int)returnValueField(FldQualific); }
			set { insertNameValueField(FldQualific, value); }
		}

		/// <summary>Field : "Pre-approach" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldPreabord { get { return m_fldPreabord; } }
		private static FieldRef m_fldPreabord = new FieldRef("sale", "preabord");

		/// <summary>Field : "Pre-approach" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValPreabord
		{
			get { return (DateTime)returnValueField(FldPreabord); }
			set { insertNameValueField(FldPreabord, value); }
		}

		/// <summary>Field : "Homework done" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldHomework { get { return m_fldHomework; } }
		private static FieldRef m_fldHomework = new FieldRef("sale", "homework");

		/// <summary>Field : "Homework done" Tipo: "L" Formula:  ""</summary>
		public int ValHomework
		{
			get { return (int)returnValueField(FldHomework); }
			set { insertNameValueField(FldHomework, value); }
		}

		/// <summary>Field : "Approach" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtaborda { get { return m_fldDtaborda; } }
		private static FieldRef m_fldDtaborda = new FieldRef("sale", "dtaborda");

		/// <summary>Field : "Approach" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtaborda
		{
			get { return (DateTime)returnValueField(FldDtaborda); }
			set { insertNameValueField(FldDtaborda, value); }
		}

		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldApproach { get { return m_fldApproach; } }
		private static FieldRef m_fldApproach = new FieldRef("sale", "approach");

		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public int ValApproach
		{
			get { return (int)returnValueField(FldApproach); }
			set { insertNameValueField(FldApproach, value); }
		}

		/// <summary>Field : "Presentation" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldApresent { get { return m_fldApresent; } }
		private static FieldRef m_fldApresent = new FieldRef("sale", "apresent");

		/// <summary>Field : "Presentation" Tipo: "L" Formula:  ""</summary>
		public int ValApresent
		{
			get { return (int)returnValueField(FldApresent); }
			set { insertNameValueField(FldApresent, value); }
		}

		/// <summary>Field : "Presentation made" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtaprese { get { return m_fldDtaprese; } }
		private static FieldRef m_fldDtaprese = new FieldRef("sale", "dtaprese");

		/// <summary>Field : "Presentation made" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtaprese
		{
			get { return (DateTime)returnValueField(FldDtaprese); }
			set { insertNameValueField(FldDtaprese, value); }
		}

		/// <summary>Field : "Overcome objections" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtsupera { get { return m_fldDtsupera; } }
		private static FieldRef m_fldDtsupera = new FieldRef("sale", "dtsupera");

		/// <summary>Field : "Overcome objections" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtsupera
		{
			get { return (DateTime)returnValueField(FldDtsupera); }
			set { insertNameValueField(FldDtsupera, value); }
		}

		/// <summary>Field : "Closing attempts" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldTentfech { get { return m_fldTentfech; } }
		private static FieldRef m_fldTentfech = new FieldRef("sale", "tentfech");

		/// <summary>Field : "Closing attempts" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValTentfech
		{
			get { return (DateTime)returnValueField(FldTentfech); }
			set { insertNameValueField(FldTentfech, value); }
		}

		/// <summary>Field : "Closing of the sale" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtvenda { get { return m_fldDtvenda; } }
		private static FieldRef m_fldDtvenda = new FieldRef("sale", "dtvenda");

		/// <summary>Field : "Closing of the sale" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtvenda
		{
			get { return (DateTime)returnValueField(FldDtvenda); }
			set { insertNameValueField(FldDtvenda, value); }
		}

		/// <summary>Field : "Follow-up" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtacompa { get { return m_fldDtacompa; } }
		private static FieldRef m_fldDtacompa = new FieldRef("sale", "dtacompa");

		/// <summary>Field : "Follow-up" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtacompa
		{
			get { return (DateTime)returnValueField(FldDtacompa); }
			set { insertNameValueField(FldDtacompa, value); }
		}

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShowrcrd { get { return m_fldShowrcrd; } }
		private static FieldRef m_fldShowrcrd = new FieldRef("sale", "showrcrd");

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public int ValShowrcrd
		{
			get { return (int)returnValueField(FldShowrcrd); }
			set { insertNameValueField(FldShowrcrd, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("sale", "zzstate");



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
        public static CSGenioAsale search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAsale area = new CSGenioAsale(user, user.CurrentModule);

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
        public static List<CSGenioAsale> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAsale>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAsale> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAsale>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX SALE]/

     

                        

	}
}
