

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
	/// Equipment
	/// </summary>
	public class CSGenioAequip : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAequip(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR EQUIP]/
		}

		public CSGenioAequip(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codequip", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codempre", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">COMPANY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_COMPANY02087";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "sequennr";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtrepar", "codequip", "codempre"));
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpess1", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">COMOMODOR";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_COMOMODOR01469";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("sequennr", FieldType.NUMERO);
			Qfield.FieldDescription = "Sequential no.";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "SEQUENTIAL_NO_38590";

			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codempre";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "sequennr");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("registnr", FieldType.TEXTO);
			Qfield.FieldDescription = "No. register";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NO__REGISTER04207";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"sequennr"}, new int[] {0}, "equip", "codequip"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GlobalFunctions.RIGHT("000000"+GlobalFunctions.NumericToString(((decimal)args[0]),0),6);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codtpequ", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">TYPE OF EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_TYPE_OF_EQUIPMENT35057";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codwareh", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("coditem", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("designat", FieldType.TEXTO);
			Qfield.FieldDescription = "Designation";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "DESIGNATION35876";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"itemdes"},new int[] {0},"item","coditem"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtaquisi", FieldType.DATA);
			Qfield.FieldDescription = "Acquisition";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ACQUISITION44180";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("coddeco", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtdeco", FieldType.DATAHORA);
			Qfield.FieldDescription = "Decomission";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_coddeco", "dtdeco");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ifabatif", FieldType.LOGICO);
			Qfield.FieldDescription = "Downed equipment";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "DOWNED_EQUIPMENT43331";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dtdeco"}, new int[] {0}, "equip", "codequip"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==1)?(0):(1));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("photogra", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("valortot", FieldType.VALOR);
			Qfield.FieldDescription = "Total value";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "TOTAL_VALUE30570";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("frequenc", FieldType.ARRAY_COD_NUMERICO);
			Qfield.FieldDescription = "Loan frequency";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "LOAN_FREQUENCY00701";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNfreqempr";
            Qfield.ArrayClassName = "Freqempr";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("bought", FieldType.LOGICO);
			Qfield.FieldDescription = "Bought";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BOUGHT32044";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dtaquisi"}, new int[] {0}, "equip", "codequip"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==1)?(0):(1));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codrooms", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtrefere", FieldType.DATAHORA);
			Qfield.FieldDescription = "Reference";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "REFERENCE28402";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("first", FieldType.TEXTO);
			Qfield.FieldDescription = "First";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "FIRST42972";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtmovim", "dtrefere", "dhmudanc", "roomnr", SortOrder.Ascending, LookupFormulaType.Previous, "codequip", "codequip");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("before", FieldType.TEXTO);
			Qfield.FieldDescription = "Before";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BEFORE60156";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtmovim", "dtrefere", "dhmudanc", "roomnr", SortOrder.Descending, LookupFormulaType.Previous);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("followin", FieldType.TEXTO);
			Qfield.FieldDescription = "Following";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "FOLLOWING22170";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtmovim", "dtrefere", "dhmudanc", "roomnr", SortOrder.Ascending, LookupFormulaType.Next, "codequip", "codequip");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("last", FieldType.TEXTO);
			Qfield.FieldDescription = "Last";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "LAST49207";

			Qfield.Dupmsg = "";
            Qfield.ZeroDuplication = true;
			Qfield.Formula = new QueryTableFormula("GQT", "gqtmovim", "dtrefere", "dhmudanc", "roomnr", SortOrder.Descending, LookupFormulaType.Next, "codequip", "codequip");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("sitefabr", FieldType.TEXTO);
			Qfield.FieldDescription = "Manufacturer's website";
			Qfield.FieldSize =  256;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "MANUFACTURER_S_WEBSI11084";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("lastpho", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Last photo attached";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "LAST_PHOTO_ATTACHED43884";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("moviment", FieldType.MEMO);
			Qfield.FieldDescription = "Drives";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "DRIVES34119";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("qtdmovim", FieldType.NUMERO);
			Qfield.FieldDescription = "Qtd. movimentações";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "QTD__MOVIMENTACOES28400";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("showrc", FieldType.LOGICO);
			Qfield.FieldDescription = "Show record";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHOW_RECORD53851";

			Qfield.Dupmsg = "";
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
			info.ChildTable = new ChildRelation[8];
			info.ChildTable[0]= new ChildRelation("lendi", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("repar", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("movim", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("photo", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("visit", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("insta", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("anexd", new String[] {"codequip"}, DeleteProc.NA);
			info.ChildTable[7]= new ChildRelation("flds", new String[] {"codequip"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("cmpny", new Relation("GQT", "gqtequip", "equip", "codequip", "codempre", "GQT", "gqtcmpny", "cmpny", "codempre", "codempre"));
			info.ParentTables.Add("decom", new Relation("GQT", "gqtequip", "equip", "codequip", "coddeco", "GQT", "gqtdecom", "decom", "coddeco", "coddeco"));
			info.ParentTables.Add("item", new Relation("GQT", "gqtequip", "equip", "codequip", "coditem", "GQT", "gqtitem", "item", "coditem", "coditem"));
			info.ParentTables.Add("pess1", new Relation("GQT", "gqtequip", "equip", "codequip", "codpess1", "GQT", "gqtpessoas", "pess1", "codpesso", "codpesso"));
			info.ParentTables.Add("room1", new Relation("GQT", "gqtequip", "equip", "codequip", "codrooms", "GQT", "gqtrooms", "room1", "codrooms", "codrooms"));
			info.ParentTables.Add("tpequ", new Relation("GQT", "gqtequip", "equip", "codequip", "codtpequ", "GQT", "gqttpequ", "tpequ", "codtpequ", "codtpequ"));
			info.ParentTables.Add("wareh", new Relation("GQT", "gqtequip", "equip", "codequip", "codwareh", "GQT", "gqtwareh", "wareh", "codwareh", "codwareh"));
			info.ParentTables.Add("_replicRel_coddeco", new Relation("GQT", "gqtequip", "equip", "codequip", "coddeco", "GQT", "gqtdecom", "decom", "coddeco", "coddeco"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(12);
			info.Pathways.Add("decom","decom");
			info.Pathways.Add("wareh","wareh");
			info.Pathways.Add("tpequ","tpequ");
			info.Pathways.Add("room1","room1");
			info.Pathways.Add("cmpny","cmpny");
			info.Pathways.Add("item","item");
			info.Pathways.Add("pess1","pess1");
			info.Pathways.Add("famil","tpequ");
			info.Pathways.Add("cntry","cmpny");
			info.Pathways.Add("gitem","item");
			info.Pathways.Add("stake","pess1");
			info.Pathways.Add("cate2","pess1");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.CheckTableFields = new string[] {
			 "first","before","followin","last"
			};

			info.ReplicaFields = new string[] {
			 "dtdeco"
			};

			info.InternalOperationFields = new string[] {
			 "ifabatif","bought"
			};

			info.InternalOperationSequentialFields = new string[] {
			 "registnr"
			};

			info.DefaultValues = new string[] {
			 "designat"
			};

			info.SequentialDefaultValues = new string[] {
			 "sequennr"
			};

			info.RelatedSumFields = new string[] {
			 "valortot","qtdmovim"
			};


			info.LastValueFields = new string[] {
			 "codrooms","lastpho"
			};

			info.AggregateListFields = new string[] {
			 "moviment"
			};

			info.FieldsParametersReplicas = new string[] {
			 "codempre"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAequip()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtequip";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codequip";
			info.HumanKeyName="registnr,".TrimEnd(',');
			info.Alias="equip";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Equipment";
			info.AreaPluralDesignation="Equipment";
			info.DescriptionCav="EQUIPMENT03632";

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
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("equip", "codequip");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodempre { get { return m_fldCodempre; } }
		private static FieldRef m_fldCodempre = new FieldRef("equip", "codempre");

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre
		{
			get { return (string)returnValueField(FldCodempre); }
			set { insertNameValueField(FldCodempre, value); }
		}

		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpess1 { get { return m_fldCodpess1; } }
		private static FieldRef m_fldCodpess1 = new FieldRef("equip", "codpess1");

		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1
		{
			get { return (string)returnValueField(FldCodpess1); }
			set { insertNameValueField(FldCodpess1, value); }
		}

		/// <summary>Field : "Sequential no." Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSequennr { get { return m_fldSequennr; } }
		private static FieldRef m_fldSequennr = new FieldRef("equip", "sequennr");

		/// <summary>Field : "Sequential no." Tipo: "N" Formula:  ""</summary>
		public decimal ValSequennr
		{
			get { return (decimal)returnValueField(FldSequennr); }
			set { insertNameValueField(FldSequennr, value); }
		}

		/// <summary>Field : "No. register" Tipo: "C" Formula: + "RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)"</summary>
		public static FieldRef FldRegistnr { get { return m_fldRegistnr; } }
		private static FieldRef m_fldRegistnr = new FieldRef("equip", "registnr");

		/// <summary>Field : "No. register" Tipo: "C" Formula: + "RIGHT("000000"+NumericToString([EQUIP->SEQUENNR],0),6)"</summary>
		public string ValRegistnr
		{
			get { return (string)returnValueField(FldRegistnr); }
			set { insertNameValueField(FldRegistnr, value); }
		}

		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("equip", "codtpequ");

		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodwareh { get { return m_fldCodwareh; } }
		private static FieldRef m_fldCodwareh = new FieldRef("equip", "codwareh");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh
		{
			get { return (string)returnValueField(FldCodwareh); }
			set { insertNameValueField(FldCodwareh, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoditem { get { return m_fldCoditem; } }
		private static FieldRef m_fldCoditem = new FieldRef("equip", "coditem");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem
		{
			get { return (string)returnValueField(FldCoditem); }
			set { insertNameValueField(FldCoditem, value); }
		}

		/// <summary>Field : "Designation" Tipo: "C" Formula: DF "[ITEM->ITEMDES]"</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("equip", "designat");

		/// <summary>Field : "Designation" Tipo: "C" Formula: DF "[ITEM->ITEMDES]"</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}

		/// <summary>Field : "Acquisition" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtaquisi { get { return m_fldDtaquisi; } }
		private static FieldRef m_fldDtaquisi = new FieldRef("equip", "dtaquisi");

		/// <summary>Field : "Acquisition" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtaquisi
		{
			get { return (DateTime)returnValueField(FldDtaquisi); }
			set { insertNameValueField(FldDtaquisi, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddeco { get { return m_fldCoddeco; } }
		private static FieldRef m_fldCoddeco = new FieldRef("equip", "coddeco");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddeco
		{
			get { return (string)returnValueField(FldCoddeco); }
			set { insertNameValueField(FldCoddeco, value); }
		}

		/// <summary>Field : "Decomission" Tipo: "DT" Formula: ++ "[DECOM->DTDECO]"</summary>
		public static FieldRef FldDtdeco { get { return m_fldDtdeco; } }
		private static FieldRef m_fldDtdeco = new FieldRef("equip", "dtdeco");

		/// <summary>Field : "Decomission" Tipo: "DT" Formula: ++ "[DECOM->DTDECO]"</summary>
		public DateTime ValDtdeco
		{
			get { return (DateTime)returnValueField(FldDtdeco); }
			set { insertNameValueField(FldDtdeco, value); }
		}

		/// <summary>Field : "Downed equipment" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTDECO])==1,0,1)"</summary>
		public static FieldRef FldIfabatif { get { return m_fldIfabatif; } }
		private static FieldRef m_fldIfabatif = new FieldRef("equip", "ifabatif");

		/// <summary>Field : "Downed equipment" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTDECO])==1,0,1)"</summary>
		public int ValIfabatif
		{
			get { return (int)returnValueField(FldIfabatif); }
			set { insertNameValueField(FldIfabatif, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhotogra { get { return m_fldPhotogra; } }
		private static FieldRef m_fldPhotogra = new FieldRef("equip", "photogra");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhotogra
		{
			get { return (byte[])returnValueField(FldPhotogra); }
			set { insertNameValueField(FldPhotogra, value); }
		}

		/// <summary>Field : "Total value" Tipo: "$D" Formula: SR "[INSTA->VALUE]"</summary>
		public static FieldRef FldValortot { get { return m_fldValortot; } }
		private static FieldRef m_fldValortot = new FieldRef("equip", "valortot");

		/// <summary>Field : "Total value" Tipo: "$D" Formula: SR "[INSTA->VALUE]"</summary>
		public decimal ValValortot
		{
			get { return (decimal)returnValueField(FldValortot); }
			set { insertNameValueField(FldValortot, value); }
		}

		/// <summary>Field : "Loan frequency" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldFrequenc { get { return m_fldFrequenc; } }
		private static FieldRef m_fldFrequenc = new FieldRef("equip", "frequenc");

		/// <summary>Field : "Loan frequency" Tipo: "AN" Formula:  ""</summary>
		public decimal ValFrequenc
		{
			get { return (decimal)returnValueField(FldFrequenc); }
			set { insertNameValueField(FldFrequenc, value); }
		}

		/// <summary>Field : "Bought" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTAQUISI])==1,0,1)"</summary>
		public static FieldRef FldBought { get { return m_fldBought; } }
		private static FieldRef m_fldBought = new FieldRef("equip", "bought");

		/// <summary>Field : "Bought" Tipo: "L" Formula: + "iif(emptyD([EQUIP->DTAQUISI])==1,0,1)"</summary>
		public int ValBought
		{
			get { return (int)returnValueField(FldBought); }
			set { insertNameValueField(FldBought, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula: U1 "MOVIM[MOVIM->DHMUDANC][MOVIM->CODROOMS][Today]"</summary>
		public static FieldRef FldCodrooms { get { return m_fldCodrooms; } }
		private static FieldRef m_fldCodrooms = new FieldRef("equip", "codrooms");

		/// <summary>Field : "" Tipo: "CE" Formula: U1 "MOVIM[MOVIM->DHMUDANC][MOVIM->CODROOMS][Today]"</summary>
		public string ValCodrooms
		{
			get { return (string)returnValueField(FldCodrooms); }
			set { insertNameValueField(FldCodrooms, value); }
		}

		/// <summary>Field : "Reference" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtrefere { get { return m_fldDtrefere; } }
		private static FieldRef m_fldDtrefere = new FieldRef("equip", "dtrefere");

		/// <summary>Field : "Reference" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtrefere
		{
			get { return (DateTime)returnValueField(FldDtrefere); }
			set { insertNameValueField(FldDtrefere, value); }
		}

		/// <summary>Field : "First" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public static FieldRef FldFirst { get { return m_fldFirst; } }
		private static FieldRef m_fldFirst = new FieldRef("equip", "first");

		/// <summary>Field : "First" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public string ValFirst
		{
			get { return (string)returnValueField(FldFirst); }
			set { insertNameValueField(FldFirst, value); }
		}

		/// <summary>Field : "Before" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR](DESC)"</summary>
		public static FieldRef FldBefore { get { return m_fldBefore; } }
		private static FieldRef m_fldBefore = new FieldRef("equip", "before");

		/// <summary>Field : "Before" Tipo: "C" Formula: CT "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR](DESC)"</summary>
		public string ValBefore
		{
			get { return (string)returnValueField(FldBefore); }
			set { insertNameValueField(FldBefore, value); }
		}

		/// <summary>Field : "Following" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public static FieldRef FldFollowin { get { return m_fldFollowin; } }
		private static FieldRef m_fldFollowin = new FieldRef("equip", "followin");

		/// <summary>Field : "Following" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](ASC)"</summary>
		public string ValFollowin
		{
			get { return (string)returnValueField(FldFollowin); }
			set { insertNameValueField(FldFollowin, value); }
		}

		/// <summary>Field : "Last" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](DESC)"</summary>
		public static FieldRef FldLast { get { return m_fldLast; } }
		private static FieldRef m_fldLast = new FieldRef("equip", "last");

		/// <summary>Field : "Last" Tipo: "C" Formula: CS "MOVIM[EQUIP->DTREFERE][MOVIM->DHMUDANC][MOVIM->ROOMNR][EQUIP->CODEQUIP][MOVIM->CODEQUIP](DESC)"</summary>
		public string ValLast
		{
			get { return (string)returnValueField(FldLast); }
			set { insertNameValueField(FldLast, value); }
		}

		/// <summary>Field : "Manufacturer's website" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSitefabr { get { return m_fldSitefabr; } }
		private static FieldRef m_fldSitefabr = new FieldRef("equip", "sitefabr");

		/// <summary>Field : "Manufacturer's website" Tipo: "C" Formula:  ""</summary>
		public string ValSitefabr
		{
			get { return (string)returnValueField(FldSitefabr); }
			set { insertNameValueField(FldSitefabr, value); }
		}

		/// <summary>Field : "Last photo attached" Tipo: "IJ" Formula: U1 "PHOTO[PHOTO->ANEXED][PHOTO->PHOTOGRA][Today]"</summary>
		public static FieldRef FldLastpho { get { return m_fldLastpho; } }
		private static FieldRef m_fldLastpho = new FieldRef("equip", "lastpho");

		/// <summary>Field : "Last photo attached" Tipo: "IJ" Formula: U1 "PHOTO[PHOTO->ANEXED][PHOTO->PHOTOGRA][Today]"</summary>
		public byte[] ValLastpho
		{
			get { return (byte[])returnValueField(FldLastpho); }
			set { insertNameValueField(FldLastpho, value); }
		}

		/// <summary>Field : "Drives" Tipo: "MO" Formula: CL "MOVIM[MOVIM->ROOMNR][MOVIM->DHMUDANC](; )"</summary>
		public static FieldRef FldMoviment { get { return m_fldMoviment; } }
		private static FieldRef m_fldMoviment = new FieldRef("equip", "moviment");

		/// <summary>Field : "Drives" Tipo: "MO" Formula: CL "MOVIM[MOVIM->ROOMNR][MOVIM->DHMUDANC](; )"</summary>
		public string ValMoviment
		{
			get { return (string)returnValueField(FldMoviment); }
			set { insertNameValueField(FldMoviment, value); }
		}

		/// <summary>Field : "Qtd. movimentações" Tipo: "N" Formula: SR "[MOVIM->1]"</summary>
		public static FieldRef FldQtdmovim { get { return m_fldQtdmovim; } }
		private static FieldRef m_fldQtdmovim = new FieldRef("equip", "qtdmovim");

		/// <summary>Field : "Qtd. movimentações" Tipo: "N" Formula: SR "[MOVIM->1]"</summary>
		public decimal ValQtdmovim
		{
			get { return (decimal)returnValueField(FldQtdmovim); }
			set { insertNameValueField(FldQtdmovim, value); }
		}

		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShowrc { get { return m_fldShowrc; } }
		private static FieldRef m_fldShowrc = new FieldRef("equip", "showrc");

		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public int ValShowrc
		{
			get { return (int)returnValueField(FldShowrc); }
			set { insertNameValueField(FldShowrc, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("equip", "zzstate");



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
        public static CSGenioAequip search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAequip area = new CSGenioAequip(user, user.CurrentModule);

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
        public static List<CSGenioAequip> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAequip>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAequip> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAequip>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX EQUIP]/

     

                             

	}
}
