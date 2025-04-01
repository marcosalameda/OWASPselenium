

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
	/// Property
	/// </summary>
	public class CSGenioAprope : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAprope(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PROPE]/
		}

		public CSGenioAprope(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codprope", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("title", FieldType.TEXTO);
			Qfield.FieldDescription = "Title";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITLE21885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("price", FieldType.VALOR);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("photo", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Main Photo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "MAIN_PHOTO18723";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codagent", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("size", FieldType.NUMERO);
			Qfield.FieldDescription = "Size (m2)";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "SIZE__M2_57059";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("bathrms", FieldType.NUMERO);
			Qfield.FieldDescription = "Number of Bathrooms";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "NUMBER_OF_BATHROOMS64857";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("year", FieldType.TEXTO);
			Qfield.FieldDescription = "Year Built";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "YEAR_BUILT55277";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  500;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcity", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "City";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CITY42505";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("buildtyp", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Building type";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BUILDING_TYPE57152";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCbuildtyp";
            Qfield.ArrayClassName = "Buildtyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("typology", FieldType.ARRAY_COD_NUMERICO);
			Qfield.FieldDescription = "Typology";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TYPOLOGY11991";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNaparttyp";
            Qfield.ArrayClassName = "Aparttyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("order", FieldType.NUMERO);
			Qfield.FieldDescription = "Order";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "ORDER39632";

			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "order");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("buildage", FieldType.NUMERO);
			Qfield.FieldDescription = "Building age";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 8;
			Qfield.CavDesignation = "BUILDING_AGE27311";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"year"}, new int[] {0}, "prope", "codprope"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GenFunctions.Year(DateTime.Today)-GenFunctions.Year(GenFunctions.DateAddYears(DateTime.MinValue,GenFunctions.atoi(((string)args[0]))));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("grndsize", FieldType.NUMERO);
			Qfield.FieldDescription = "Ground Size";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 15;
			Qfield.CavDesignation = "GROUND_SIZE62055";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("floornum", FieldType.NUMERO);
			Qfield.FieldDescription = "Floor number";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "FLOOR_NUMBER26169";

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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("proph", new String[] {"codprope"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("procn", new String[] {"codprope"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("agent", new Relation("GQT", "gqtprope", "prope", "codprope", "codagent", "GQT", "gqtagent", "agent", "codagent", "codagent"));
			info.ParentTables.Add("city", new Relation("GQT", "gqtprope", "prope", "codprope", "codcity", "GQT", "gqtcity", "city", "codcity", "codcity"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("agent","agent");
			info.Pathways.Add("city","city");
			info.Pathways.Add("ctry","city");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "buildage"
			};

			info.SequentialDefaultValues = new string[] {
			 "order"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAprope()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtprope";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codprope";
			info.HumanKeyName="title,".TrimEnd(',');
			info.Alias="prope";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Property";
			info.AreaPluralDesignation="Properties";
			info.DescriptionCav="PROPERTY43977";

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
		public static FieldRef FldCodprope { get { return m_fldCodprope; } }
		private static FieldRef m_fldCodprope = new FieldRef("prope", "codprope");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodprope
		{
			get { return (string)returnValueField(FldCodprope); }
			set { insertNameValueField(FldCodprope, value); }
		}

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("prope", "title");

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("prope", "price");

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("prope", "photo");

		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodagent { get { return m_fldCodagent; } }
		private static FieldRef m_fldCodagent = new FieldRef("prope", "codagent");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodagent
		{
			get { return (string)returnValueField(FldCodagent); }
			set { insertNameValueField(FldCodagent, value); }
		}

		/// <summary>Field : "Size (m2)" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldSize { get { return m_fldSize; } }
		private static FieldRef m_fldSize = new FieldRef("prope", "size");

		/// <summary>Field : "Size (m2)" Tipo: "ND" Formula:  ""</summary>
		public decimal ValSize
		{
			get { return (decimal)returnValueField(FldSize); }
			set { insertNameValueField(FldSize, value); }
		}

		/// <summary>Field : "Number of Bathrooms" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBathrms { get { return m_fldBathrms; } }
		private static FieldRef m_fldBathrms = new FieldRef("prope", "bathrms");

		/// <summary>Field : "Number of Bathrooms" Tipo: "N" Formula:  ""</summary>
		public decimal ValBathrms
		{
			get { return (decimal)returnValueField(FldBathrms); }
			set { insertNameValueField(FldBathrms, value); }
		}

		/// <summary>Field : "Year Built" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("prope", "year");

		/// <summary>Field : "Year Built" Tipo: "C" Formula:  ""</summary>
		public string ValYear
		{
			get { return (string)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("prope", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "City" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcity { get { return m_fldCodcity; } }
		private static FieldRef m_fldCodcity = new FieldRef("prope", "codcity");

		/// <summary>Field : "City" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcity
		{
			get { return (string)returnValueField(FldCodcity); }
			set { insertNameValueField(FldCodcity, value); }
		}

		/// <summary>Field : "Building type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldBuildtyp { get { return m_fldBuildtyp; } }
		private static FieldRef m_fldBuildtyp = new FieldRef("prope", "buildtyp");

		/// <summary>Field : "Building type" Tipo: "AC" Formula:  ""</summary>
		public string ValBuildtyp
		{
			get { return (string)returnValueField(FldBuildtyp); }
			set { insertNameValueField(FldBuildtyp, value); }
		}

		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldTypology { get { return m_fldTypology; } }
		private static FieldRef m_fldTypology = new FieldRef("prope", "typology");

		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		public decimal ValTypology
		{
			get { return (decimal)returnValueField(FldTypology); }
			set { insertNameValueField(FldTypology, value); }
		}

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrder { get { return m_fldOrder; } }
		private static FieldRef m_fldOrder = new FieldRef("prope", "order");

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrder
		{
			get { return (decimal)returnValueField(FldOrder); }
			set { insertNameValueField(FldOrder, value); }
		}

		/// <summary>Field : "Building age" Tipo: "N" Formula: + "Year([Today])-Year(DateAddYears([ZEROD],StringToInt([PROPE->YEAR])))"</summary>
		public static FieldRef FldBuildage { get { return m_fldBuildage; } }
		private static FieldRef m_fldBuildage = new FieldRef("prope", "buildage");

		/// <summary>Field : "Building age" Tipo: "N" Formula: + "Year([Today])-Year(DateAddYears([ZEROD],StringToInt([PROPE->YEAR])))"</summary>
		public decimal ValBuildage
		{
			get { return (decimal)returnValueField(FldBuildage); }
			set { insertNameValueField(FldBuildage, value); }
		}

		/// <summary>Field : "Ground Size" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldGrndsize { get { return m_fldGrndsize; } }
		private static FieldRef m_fldGrndsize = new FieldRef("prope", "grndsize");

		/// <summary>Field : "Ground Size" Tipo: "ND" Formula:  ""</summary>
		public decimal ValGrndsize
		{
			get { return (decimal)returnValueField(FldGrndsize); }
			set { insertNameValueField(FldGrndsize, value); }
		}

		/// <summary>Field : "Floor number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldFloornum { get { return m_fldFloornum; } }
		private static FieldRef m_fldFloornum = new FieldRef("prope", "floornum");

		/// <summary>Field : "Floor number" Tipo: "N" Formula:  ""</summary>
		public decimal ValFloornum
		{
			get { return (decimal)returnValueField(FldFloornum); }
			set { insertNameValueField(FldFloornum, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("prope", "zzstate");



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
        public static CSGenioAprope search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAprope area = new CSGenioAprope(user, user.CurrentModule);

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
        public static List<CSGenioAprope> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAprope>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAprope> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAprope>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 		//To usar routine manual no pedido eliminate
		public override StatusMessage eliminate(PersistentSupport sp)
		{
			StatusMessage msg = base.eliminate(sp);

			// ROW_REORDERING
			CriteriaSet criteria = CriteriaSet.And();
			sp.ReorderSequence(Area.AreaPROPE, CSGenioAprope.FldOrder, criteria);

            return msg;
		}

 


		// USE /[MANUAL GQT TABAUX PROPE]/

     

            
		/// <summary>
        /// Reorders the values of the ordering field along a subset so that the current record moves in that order to the specified position
        /// </summary>
        /// <param name="sp">The current PersistentSupport</param>
        /// <param name="position">The position to where the record will be moved</param>
        /// <param name="condition">The subset to be reordered</param>
        public void Reorder_Order(PersistentSupport sp, int position, CriteriaSet condition, List<Relation> relations = null, bool moveRow = true)
        {
            int posactual = (int)ValOrder;
            int posnova = position + 1;
            ValOrder = posnova;

			//Get highest value for ordering field
			int maxOrder;

            try
			{
				maxOrder = sp.GetMaxFieldValue(Area.AreaPROPE, CSGenioAprope.FldOrder, condition, relations);
			}
			catch(Exception ex)
			{
                Log.Error(ex.Message);
                return;
			}

			//Row is not being moved
			if (posnova > maxOrder)
			{
				return;
			}
			if (!moveRow)
			{
				posactual = maxOrder + 1;
			}
			//Row is not being moved
			if(posnova == posactual || posnova < 1){
				return;
			}

			if (moveRow) {
				//Set moved record position to 0 temporarily
				UpdateQuery up_temp = new UpdateQuery()
							.Update(Area.AreaPROPE)
							.Set(CSGenioAprope.FldOrder, 0)
							.Where(CriteriaSet.And().Equal(CSGenioAprope.FldCodprope, QPrimaryKey));
				sp.Execute(up_temp);
			}

			//Set new positions of records in the range from the previous position to the new position
			int posLow;
			int posHigh;
            int difference;
			//If new position is greater than previous position
			if (posnova > posactual) {
				posLow = posactual + 1;
				posHigh = posnova;
                difference = -1;
			}
			//If new position is less than previous position
			else {
				posLow = posnova;
				posHigh = posactual - 1;
                difference = 1;
            }
			CriteriaSet range_condition = CriteriaSet.And();
            range_condition.SubSet(condition);
            range_condition.GreaterOrEqual(CSGenioAprope.FldOrder, posLow);
            range_condition.LesserOrEqual(CSGenioAprope.FldOrder, posHigh);

			sp.ReorderSequence(Area.AreaPROPE, CSGenioAprope.FldOrder, range_condition, relations, posLow + difference);

			if (moveRow) {
				//Set moved record position to new position
				UpdateQuery up = new UpdateQuery()
							.Update(Area.AreaPROPE)
							.Set(CSGenioAprope.FldOrder, posnova)
							.Where(CriteriaSet.And().Equal(CSGenioAprope.FldCodprope, QPrimaryKey));
				sp.Execute(up);
			}

			OnReorder_Order(sp, posactual, condition, relations);
        }

        private void OnReorder_Order(PersistentSupport sp, int oldpos, CriteriaSet condition, List<Relation> relations)
        {
// USE /[MANUAL GQT ONREORDER PROPE.ORDER]/
        }

     

	}
}
