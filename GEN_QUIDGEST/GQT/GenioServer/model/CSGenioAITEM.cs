

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
	/// Articles
	/// </summary>
	public class CSGenioAitem : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAitem(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ITEM]/
		}

		public CSGenioAitem(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "coditem", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codgitem", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">GLOBAL ARTICLE";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "_GLOBAL_ARTICLE51116";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codwareh", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">WAREHOUSE";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "_WAREHOUSE19861";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "itemtype", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Type";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "TYPE00312";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCtipoarti";
            Qfield.ArrayClassName = "Tipoarti";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "itemdes", FieldType.TEXT);
			Qfield.FieldDescription = "Article";
			Qfield.FieldSize =  85;
			Qfield.CavDesignation = "ARTICLE60065";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"itemdes"},new int[] {0},"gitem","codgitem"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "itemcod", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  15;
			Qfield.CavDesignation = "CODE49225";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"itemgcod"},new int[] {0},"gitem","codgitem"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "entries", FieldType.NUMERIC);
			Qfield.FieldDescription = "Entries";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "ENTRIES32319";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "exits", FieldType.NUMERIC);
			Qfield.FieldDescription = "Outputs";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "OUTPUTS47833";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "existenc", FieldType.NUMERIC);
			Qfield.FieldDescription = "Stocks";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "STOCKS47349";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "image", FieldType.IMAGE);
			Qfield.FieldDescription = "Image";
			Qfield.FieldSize =  3;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE65174";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "category", FieldType.MEMO);
			Qfield.FieldDescription = "Categorization";
			Qfield.FieldSize =  85;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "CATEGORIZATION17554";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "valid", FieldType.LOGIC);
			Qfield.FieldDescription = "In use";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "IN_USE42606";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "disponib", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Availability";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AVAILABILITY56489";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"existenc","existenc"}, new int[] {0,1}, "item", "coditem"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((((decimal)args[0])>0)?("A"):(((((decimal)args[1])<=0)?("O"):("D"))));
			});
            Qfield.ArrayName = "dbo.GetValArrayCdsiponib";
            Qfield.ArrayClassName = "Dsiponib";
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
			Qfield = new Field(info.Alias, "techspec", FieldType.DOCUMENT);
			Qfield.FieldDescription = "Specifications";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SPECIFICATIONS59226";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
 			Qfield = new Field(info.Alias, "techspecfk", FieldType.KEY_GUID);
			Qfield.FieldSize = 16;
			Qfield.FieldDescription = "Chave estrangeira para o documento";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

			info.SolrList.Add("DEXITTM");
			info.SolrList.Add("TMLINEM");
			info.SolrList.Add("TMLINEW");
			info.SolrList.Add("TMLINEY");
			info.SolrList.Add("TMlLEDAY");
		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[6];
			info.ChildTable[0]= new ChildRelation("ccorr", new String[] {"coditem"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("ldent", new String[] {"coditem"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("itemp", new String[] {"coditem"}, DeleteProc.AP);
			info.ChildTable[3]= new ChildRelation("outpu", new String[] {"coditem"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("itemc", new String[] {"coditem"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("equip", new String[] {"coditem"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("gitem", new Relation("GQT", "gqtitem", "item", "coditem", "codgitem", "GQT", "gqtgitem", "gitem", "codgitem", "codgitem"));
			info.ParentTables.Add("wareh", new Relation("GQT", "gqtitem", "item", "coditem", "codwareh", "GQT", "gqtwareh", "wareh", "codwareh", "codwareh"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("wareh","wareh");
			info.Pathways.Add("gitem","gitem");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "disponib"
			};

			info.DefaultValues = new string[] {
			 "itemdes","itemcod"
			};


			info.RelatedSumFields = new string[] {
			 "entries","exits","existenc"
			};



			info.AggregateListFields = new string[] {
			 "category"
			};


			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAitem()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtitem";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coditem";
			info.HumanKeyName="itemdes,".TrimEnd(',');
			info.Alias="item";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Articles";
			info.AreaPluralDesignation="Articles";
			info.DescriptionCav="ARTICLES59822";

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
			info.DocumsForeignKeys = new List<String> {
			 "techspecfk"
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
		public static FieldRef FldCoditem { get { return m_fldCoditem; } }
		private static FieldRef m_fldCoditem = new FieldRef("item", "coditem");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoditem
		{
			get { return (string)returnValueField(FldCoditem); }
			set { insertNameValueField(FldCoditem, value); }
		}

		/// <summary>Field : ">GLOBAL ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodgitem { get { return m_fldCodgitem; } }
		private static FieldRef m_fldCodgitem = new FieldRef("item", "codgitem");

		/// <summary>Field : ">GLOBAL ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodgitem
		{
			get { return (string)returnValueField(FldCodgitem); }
			set { insertNameValueField(FldCodgitem, value); }
		}

		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodwareh { get { return m_fldCodwareh; } }
		private static FieldRef m_fldCodwareh = new FieldRef("item", "codwareh");

		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh
		{
			get { return (string)returnValueField(FldCodwareh); }
			set { insertNameValueField(FldCodwareh, value); }
		}

		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldItemtype { get { return m_fldItemtype; } }
		private static FieldRef m_fldItemtype = new FieldRef("item", "itemtype");

		/// <summary>Field : "Type" Tipo: "AC" Formula:  ""</summary>
		public string ValItemtype
		{
			get { return (string)returnValueField(FldItemtype); }
			set { insertNameValueField(FldItemtype, value); }
		}

		/// <summary>Field : "Article" Tipo: "C" Formula: DF "[GITEM->ITEMDES]"</summary>
		public static FieldRef FldItemdes { get { return m_fldItemdes; } }
		private static FieldRef m_fldItemdes = new FieldRef("item", "itemdes");

		/// <summary>Field : "Article" Tipo: "C" Formula: DF "[GITEM->ITEMDES]"</summary>
		public string ValItemdes
		{
			get { return (string)returnValueField(FldItemdes); }
			set { insertNameValueField(FldItemdes, value); }
		}

		/// <summary>Field : "Code" Tipo: "C" Formula: DF "[GITEM->ITEMGCOD]"</summary>
		public static FieldRef FldItemcod { get { return m_fldItemcod; } }
		private static FieldRef m_fldItemcod = new FieldRef("item", "itemcod");

		/// <summary>Field : "Code" Tipo: "C" Formula: DF "[GITEM->ITEMGCOD]"</summary>
		public string ValItemcod
		{
			get { return (string)returnValueField(FldItemcod); }
			set { insertNameValueField(FldItemcod, value); }
		}

		/// <summary>Field : "Entries" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]"</summary>
		public static FieldRef FldEntries { get { return m_fldEntries; } }
		private static FieldRef m_fldEntries = new FieldRef("item", "entries");

		/// <summary>Field : "Entries" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]"</summary>
		public decimal ValEntries
		{
			get { return (decimal)returnValueField(FldEntries); }
			set { insertNameValueField(FldEntries, value); }
		}

		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[OUTPU->EXITQNTY]"</summary>
		public static FieldRef FldExits { get { return m_fldExits; } }
		private static FieldRef m_fldExits = new FieldRef("item", "exits");

		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[OUTPU->EXITQNTY]"</summary>
		public decimal ValExits
		{
			get { return (decimal)returnValueField(FldExits); }
			set { insertNameValueField(FldExits, value); }
		}

		/// <summary>Field : "Stocks" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]-[OUTPU->EXITQNTY]"</summary>
		public static FieldRef FldExistenc { get { return m_fldExistenc; } }
		private static FieldRef m_fldExistenc = new FieldRef("item", "existenc");

		/// <summary>Field : "Stocks" Tipo: "N" Formula: SR "[LDENT->QTDENTRA]-[OUTPU->EXITQNTY]"</summary>
		public decimal ValExistenc
		{
			get { return (decimal)returnValueField(FldExistenc); }
			set { insertNameValueField(FldExistenc, value); }
		}

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldImage { get { return m_fldImage; } }
		private static FieldRef m_fldImage = new FieldRef("item", "image");

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValImage
		{
			get { return (byte[])returnValueField(FldImage); }
			set { insertNameValueField(FldImage, value); }
		}

		/// <summary>Field : "Categorization" Tipo: "MO" Formula: CL "ITEMC[ITEMC->TPCATEG][ITEMC->TPCATEG](; )"</summary>
		public static FieldRef FldCategory { get { return m_fldCategory; } }
		private static FieldRef m_fldCategory = new FieldRef("item", "category");

		/// <summary>Field : "Categorization" Tipo: "MO" Formula: CL "ITEMC[ITEMC->TPCATEG][ITEMC->TPCATEG](; )"</summary>
		public string ValCategory
		{
			get { return (string)returnValueField(FldCategory); }
			set { insertNameValueField(FldCategory, value); }
		}

		/// <summary>Field : "In use" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldValid { get { return m_fldValid; } }
		private static FieldRef m_fldValid = new FieldRef("item", "valid");

		/// <summary>Field : "In use" Tipo: "L" Formula:  ""</summary>
		public int ValValid
		{
			get { return (int)returnValueField(FldValid); }
			set { insertNameValueField(FldValid, value); }
		}

		/// <summary>Field : "Availability" Tipo: "AC" Formula: + "iif([ITEM->EXISTENC]>0,"A",iif([ITEM->EXISTENC]<=0,"O","D"))"</summary>
		public static FieldRef FldDisponib { get { return m_fldDisponib; } }
		private static FieldRef m_fldDisponib = new FieldRef("item", "disponib");

		/// <summary>Field : "Availability" Tipo: "AC" Formula: + "iif([ITEM->EXISTENC]>0,"A",iif([ITEM->EXISTENC]<=0,"O","D"))"</summary>
		public string ValDisponib
		{
			get { return (string)returnValueField(FldDisponib); }
			set { insertNameValueField(FldDisponib, value); }
		}

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("item", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Specifications" Tipo: "IB" Formula:  ""</summary>
		public static FieldRef FldTechspec { get { return m_fldTechspec; } }
		private static FieldRef m_fldTechspec = new FieldRef("item", "techspec");

		/// <summary>Field : "Specifications" Tipo: "IB" Formula:  ""</summary>
		public string ValTechspec
		{
			get { return (string)returnValueField(FldTechspec); }
			set { insertNameValueField(FldTechspec, value); }
		}

		/// <summary>Field : "Specifications FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldTechspecfk { get { return m_fldTechspecfk; } }
		private static FieldRef m_fldTechspecfk = new FieldRef("item", "techspecfk");

		/// <summary>Field : "Specifications FK" Tipo: "CE" Formula:  ""</summary>
		public string ValTechspecfk
		{
			get { return (string)returnValueField(FldTechspecfk); }
			set { insertNameValueField(FldTechspecfk, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("item", "zzstate");



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
        public static CSGenioAitem search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAitem area = new CSGenioAitem(user, user.CurrentModule);

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
        public static List<CSGenioAitem> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAitem>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAitem> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAitem>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX ITEM]/

     

                

	}
}
