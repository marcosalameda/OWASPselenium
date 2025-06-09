

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
	public class CSGenioAsales : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAsales(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR SALES]/
		}

		public CSGenioAsales(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codsales", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codorgan", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nrlide", FieldType.NUMERIC);
			Qfield.FieldDescription = "N.º da lide";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "N_O_DA_LIDE50722";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "startdt", FieldType.DATETIME);
			Qfield.FieldDescription = "Beginning";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "BEGINNING18124";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "identifi", FieldType.TEXT);
			Qfield.FieldDescription = "Identificação da oportunidade comercial";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "IDENTIFICACAO_DA_OPO05341";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "potcompr", FieldType.TEXT);
			Qfield.FieldDescription = "Potenciais compradores";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "POTENCIAIS_COMPRADOR25099";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "prospecc", FieldType.LOGIC);
			Qfield.FieldDescription = "Prospecção efectuada";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "PROSPECCAO_EFECTUADA42558";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "interess", FieldType.LOGIC);
			Qfield.FieldDescription = "Interessado";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "INTERESSADO26080";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semrfina", FieldType.LOGIC);
			Qfield.FieldDescription = "Sem recursos financeiros";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "SEM_RECURSOS_FINANCE28439";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "semcapac", FieldType.LOGIC);
			Qfield.FieldDescription = "Sem capacidade de decisão";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "SEM_CAPACIDADE_DE_DE07701";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtqualif", FieldType.DATETIME);
			Qfield.FieldDescription = "Qualificação";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "QUALIFICACAO07026";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "qualific", FieldType.LOGIC);
			Qfield.FieldDescription = "Qualificação efectuada";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "QUALIFICACAO_EFECTUA30983";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "preabord", FieldType.DATETIME);
			Qfield.FieldDescription = "Pré-abordagem";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "PRE_ABORDAGEM30870";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "homework", FieldType.LOGIC);
			Qfield.FieldDescription = "Trabalho de casa efectuado";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "TRABALHO_DE_CASA_EFE54337";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtaborda", FieldType.DATETIME);
			Qfield.FieldDescription = "Abordagem";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "ABORDAGEM05839";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "approach", FieldType.LOGIC);
			Qfield.FieldDescription = "Abordagem efectuada";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "ABORDAGEM_EFECTUADA60152";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "apresent", FieldType.LOGIC);
			Qfield.FieldDescription = "Apresentação";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "APRESENTACAO15975";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtaprese", FieldType.DATETIME);
			Qfield.FieldDescription = "Apresentação efectuada";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "APRESENTACAO_EFECTUA37455";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtsupera", FieldType.DATETIME);
			Qfield.FieldDescription = "Superar objeções";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "SUPERAR_OBJECOES02243";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tentfech", FieldType.DATETIME);
			Qfield.FieldDescription = "Tentativas de fecho";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "TENTATIVAS_DE_FECHO20342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtvenda", FieldType.DATETIME);
			Qfield.FieldDescription = "Fecho da venda";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "FECHO_DA_VENDA48081";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dtacompa", FieldType.DATETIME);
			Qfield.FieldDescription = "Acompanhamento";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "ACOMPANHAMENTO53507";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "showrcrd", FieldType.LOGIC);
			Qfield.FieldDescription = "Show Record";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHOW_RECORD11620";

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
			info.ParentTables.Add("organ", new Relation("GQT", "gqtsales", "sales", "codsales", "codorgan", "GQT", "gqtorgan", "organ", "codorgan", "codorgan"));
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
		/// static CSGenioAsales()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtsales";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codsales";
			info.HumanKeyName="identifi,".TrimEnd(',');
			info.Alias="sales";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Sale";
			info.AreaPluralDesignation="Sales";
			info.DescriptionCav="SALE02786";

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
		public static FieldRef FldCodsales { get { return m_fldCodsales; } }
		private static FieldRef m_fldCodsales = new FieldRef("sales", "codsales");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodsales
		{
			get { return (string)returnValueField(FldCodsales); }
			set { insertNameValueField(FldCodsales, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodorgan { get { return m_fldCodorgan; } }
		private static FieldRef m_fldCodorgan = new FieldRef("sales", "codorgan");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodorgan
		{
			get { return (string)returnValueField(FldCodorgan); }
			set { insertNameValueField(FldCodorgan, value); }
		}

		/// <summary>Field : "N.º da lide" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNrlide { get { return m_fldNrlide; } }
		private static FieldRef m_fldNrlide = new FieldRef("sales", "nrlide");

		/// <summary>Field : "N.º da lide" Tipo: "N" Formula:  ""</summary>
		public decimal ValNrlide
		{
			get { return (decimal)returnValueField(FldNrlide); }
			set { insertNameValueField(FldNrlide, value); }
		}

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldStartdt { get { return m_fldStartdt; } }
		private static FieldRef m_fldStartdt = new FieldRef("sales", "startdt");

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValStartdt
		{
			get { return (DateTime)returnValueField(FldStartdt); }
			set { insertNameValueField(FldStartdt, value); }
		}

		/// <summary>Field : "Identificação da oportunidade comercial" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdentifi { get { return m_fldIdentifi; } }
		private static FieldRef m_fldIdentifi = new FieldRef("sales", "identifi");

		/// <summary>Field : "Identificação da oportunidade comercial" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi
		{
			get { return (string)returnValueField(FldIdentifi); }
			set { insertNameValueField(FldIdentifi, value); }
		}

		/// <summary>Field : "Potenciais compradores" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPotcompr { get { return m_fldPotcompr; } }
		private static FieldRef m_fldPotcompr = new FieldRef("sales", "potcompr");

		/// <summary>Field : "Potenciais compradores" Tipo: "C" Formula:  ""</summary>
		public string ValPotcompr
		{
			get { return (string)returnValueField(FldPotcompr); }
			set { insertNameValueField(FldPotcompr, value); }
		}

		/// <summary>Field : "Prospecção efectuada" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldProspecc { get { return m_fldProspecc; } }
		private static FieldRef m_fldProspecc = new FieldRef("sales", "prospecc");

		/// <summary>Field : "Prospecção efectuada" Tipo: "L" Formula:  ""</summary>
		public int ValProspecc
		{
			get { return (int)returnValueField(FldProspecc); }
			set { insertNameValueField(FldProspecc, value); }
		}

		/// <summary>Field : "Interessado" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldInteress { get { return m_fldInteress; } }
		private static FieldRef m_fldInteress = new FieldRef("sales", "interess");

		/// <summary>Field : "Interessado" Tipo: "L" Formula:  ""</summary>
		public int ValInteress
		{
			get { return (int)returnValueField(FldInteress); }
			set { insertNameValueField(FldInteress, value); }
		}

		/// <summary>Field : "Sem recursos financeiros" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemrfina { get { return m_fldSemrfina; } }
		private static FieldRef m_fldSemrfina = new FieldRef("sales", "semrfina");

		/// <summary>Field : "Sem recursos financeiros" Tipo: "L" Formula:  ""</summary>
		public int ValSemrfina
		{
			get { return (int)returnValueField(FldSemrfina); }
			set { insertNameValueField(FldSemrfina, value); }
		}

		/// <summary>Field : "Sem capacidade de decisão" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSemcapac { get { return m_fldSemcapac; } }
		private static FieldRef m_fldSemcapac = new FieldRef("sales", "semcapac");

		/// <summary>Field : "Sem capacidade de decisão" Tipo: "L" Formula:  ""</summary>
		public int ValSemcapac
		{
			get { return (int)returnValueField(FldSemcapac); }
			set { insertNameValueField(FldSemcapac, value); }
		}

		/// <summary>Field : "Qualificação" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtqualif { get { return m_fldDtqualif; } }
		private static FieldRef m_fldDtqualif = new FieldRef("sales", "dtqualif");

		/// <summary>Field : "Qualificação" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtqualif
		{
			get { return (DateTime)returnValueField(FldDtqualif); }
			set { insertNameValueField(FldDtqualif, value); }
		}

		/// <summary>Field : "Qualificação efectuada" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldQualific { get { return m_fldQualific; } }
		private static FieldRef m_fldQualific = new FieldRef("sales", "qualific");

		/// <summary>Field : "Qualificação efectuada" Tipo: "L" Formula:  ""</summary>
		public int ValQualific
		{
			get { return (int)returnValueField(FldQualific); }
			set { insertNameValueField(FldQualific, value); }
		}

		/// <summary>Field : "Pré-abordagem" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldPreabord { get { return m_fldPreabord; } }
		private static FieldRef m_fldPreabord = new FieldRef("sales", "preabord");

		/// <summary>Field : "Pré-abordagem" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValPreabord
		{
			get { return (DateTime)returnValueField(FldPreabord); }
			set { insertNameValueField(FldPreabord, value); }
		}

		/// <summary>Field : "Trabalho de casa efectuado" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldHomework { get { return m_fldHomework; } }
		private static FieldRef m_fldHomework = new FieldRef("sales", "homework");

		/// <summary>Field : "Trabalho de casa efectuado" Tipo: "L" Formula:  ""</summary>
		public int ValHomework
		{
			get { return (int)returnValueField(FldHomework); }
			set { insertNameValueField(FldHomework, value); }
		}

		/// <summary>Field : "Abordagem" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtaborda { get { return m_fldDtaborda; } }
		private static FieldRef m_fldDtaborda = new FieldRef("sales", "dtaborda");

		/// <summary>Field : "Abordagem" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtaborda
		{
			get { return (DateTime)returnValueField(FldDtaborda); }
			set { insertNameValueField(FldDtaborda, value); }
		}

		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldApproach { get { return m_fldApproach; } }
		private static FieldRef m_fldApproach = new FieldRef("sales", "approach");

		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public int ValApproach
		{
			get { return (int)returnValueField(FldApproach); }
			set { insertNameValueField(FldApproach, value); }
		}

		/// <summary>Field : "Apresentação" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldApresent { get { return m_fldApresent; } }
		private static FieldRef m_fldApresent = new FieldRef("sales", "apresent");

		/// <summary>Field : "Apresentação" Tipo: "L" Formula:  ""</summary>
		public int ValApresent
		{
			get { return (int)returnValueField(FldApresent); }
			set { insertNameValueField(FldApresent, value); }
		}

		/// <summary>Field : "Apresentação efectuada" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtaprese { get { return m_fldDtaprese; } }
		private static FieldRef m_fldDtaprese = new FieldRef("sales", "dtaprese");

		/// <summary>Field : "Apresentação efectuada" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtaprese
		{
			get { return (DateTime)returnValueField(FldDtaprese); }
			set { insertNameValueField(FldDtaprese, value); }
		}

		/// <summary>Field : "Superar objeções" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtsupera { get { return m_fldDtsupera; } }
		private static FieldRef m_fldDtsupera = new FieldRef("sales", "dtsupera");

		/// <summary>Field : "Superar objeções" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtsupera
		{
			get { return (DateTime)returnValueField(FldDtsupera); }
			set { insertNameValueField(FldDtsupera, value); }
		}

		/// <summary>Field : "Tentativas de fecho" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldTentfech { get { return m_fldTentfech; } }
		private static FieldRef m_fldTentfech = new FieldRef("sales", "tentfech");

		/// <summary>Field : "Tentativas de fecho" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValTentfech
		{
			get { return (DateTime)returnValueField(FldTentfech); }
			set { insertNameValueField(FldTentfech, value); }
		}

		/// <summary>Field : "Fecho da venda" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtvenda { get { return m_fldDtvenda; } }
		private static FieldRef m_fldDtvenda = new FieldRef("sales", "dtvenda");

		/// <summary>Field : "Fecho da venda" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtvenda
		{
			get { return (DateTime)returnValueField(FldDtvenda); }
			set { insertNameValueField(FldDtvenda, value); }
		}

		/// <summary>Field : "Acompanhamento" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtacompa { get { return m_fldDtacompa; } }
		private static FieldRef m_fldDtacompa = new FieldRef("sales", "dtacompa");

		/// <summary>Field : "Acompanhamento" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtacompa
		{
			get { return (DateTime)returnValueField(FldDtacompa); }
			set { insertNameValueField(FldDtacompa, value); }
		}

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShowrcrd { get { return m_fldShowrcrd; } }
		private static FieldRef m_fldShowrcrd = new FieldRef("sales", "showrcrd");

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public int ValShowrcrd
		{
			get { return (int)returnValueField(FldShowrcrd); }
			set { insertNameValueField(FldShowrcrd, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("sales", "zzstate");



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
        public static CSGenioAsales search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAsales area = new CSGenioAsales(user, user.CurrentModule);

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
        public static List<CSGenioAsales> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAsales>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAsales> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAsales>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX SALES]/

     

                        

	}
}
