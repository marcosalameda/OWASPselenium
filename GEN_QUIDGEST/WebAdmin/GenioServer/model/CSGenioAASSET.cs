
 
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
	/// Asset
	/// </summary>
	public class CSGenioAasset : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAasset(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR ASSET]/
		}

		public CSGenioAasset(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codasset", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Identification name";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IDENTIFICATION_NAME16317";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "assetnum", FieldType.NUMERIC);
			Qfield.FieldDescription = "Asset number";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "ASSET_NUMBER52372";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "assetnum");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "assettyp", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Asset type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ASSET_TYPE02033";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCassettyp";
            Qfield.ArrayClassName = "Assettyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "identtyp", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Identifier type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IDENTIFIER_TYPE60623";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCidenttyp";
            Qfield.ArrayClassName = "Identtyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "grai", FieldType.TEXT);
			Qfield.FieldDescription = "GRAI – Global Returnable Asset Identifier";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GRAI___GLOBAL_RETURN06821";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"identtyp"}, new int[] {0}, "asset", "codasset"));
			Qfield.FillWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="R";
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"identtyp"}, new int[] {0}, "asset", "codasset"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="R";
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "giai", FieldType.TEXT);
			Qfield.FieldDescription = "GIAI – Global Individual Asset Identifier";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GIAI___GLOBAL_INDIVI63214";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"identtyp"}, new int[] {0}, "asset", "codasset"));
			Qfield.FillWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="I";
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"identtyp"}, new int[] {0}, "asset", "codasset"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])=="I";
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "photo", FieldType.IMAGE);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codkinde", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>Kind of equipment";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__KIND_OF_EQUIPMENT01899";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codmanuf", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "description", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  250;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "longdesc", FieldType.MEMO);
			Qfield.FieldDescription = "Detailed description";
			Qfield.FieldSize =  250;
			Qfield.MQueue = false;
			Qfield.Decimals = 10;
			Qfield.CavDesignation = "DETAILED_DESCRIPTION36560";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "category", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Category";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CATEGORY18978";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCassetcategory";
            Qfield.ArrayClassName = "Assetcategory";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bg_color", FieldType.TEXT);
			Qfield.FieldDescription = "Background color for category";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BACKGROUND_COLOR_FOR59228";

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
			info.ChildTable = new ChildRelation[4];
			info.ChildTable[0]= new ChildRelation("atags", new String[] {"codasset"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("assma", new String[] {"codasset"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("asspa", new String[] {"codasset"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("attac", new String[] {"codasset"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("kinde", new Relation("GQT", "gqtasset", "asset", "codasset", "codkinde", "GQT", "gqtkindofequipment", "kinde", "codkinde", "codkinde"));
			info.ParentTables.Add("manuf", new Relation("GQT", "gqtasset", "asset", "codasset", "codmanuf", "GQT", "gqtentity", "manuf", "codentit", "codentit"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("kinde","kinde");
			info.Pathways.Add("manuf","manuf");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.SequentialDefaultValues = new string[] {
			 "assetnum"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAasset()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtasset";
			info.ShadowTabName="Shdgqtasset";
			info.ShadowTabKeyName="SHDcodasset";

			info.PrimaryKeyName="codasset";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="asset";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Asset";
			info.AreaPluralDesignation="Assets";
			info.DescriptionCav="ASSET37028";

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
		public static FieldRef FldCodasset { get { return m_fldCodasset; } }
		private static FieldRef m_fldCodasset = new FieldRef("asset", "codasset");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodasset
		{
			get { return (string)returnValueField(FldCodasset); }
			set { insertNameValueField(FldCodasset, value); }
		}

		/// <summary>Field : "Identification name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("asset", "name");

		/// <summary>Field : "Identification name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Asset number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldAssetnum { get { return m_fldAssetnum; } }
		private static FieldRef m_fldAssetnum = new FieldRef("asset", "assetnum");

		/// <summary>Field : "Asset number" Tipo: "N" Formula:  ""</summary>
		public decimal ValAssetnum
		{
			get { return (decimal)returnValueField(FldAssetnum); }
			set { insertNameValueField(FldAssetnum, value); }
		}

		/// <summary>Field : "Asset type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldAssettyp { get { return m_fldAssettyp; } }
		private static FieldRef m_fldAssettyp = new FieldRef("asset", "assettyp");

		/// <summary>Field : "Asset type" Tipo: "AC" Formula:  ""</summary>
		public string ValAssettyp
		{
			get { return (string)returnValueField(FldAssettyp); }
			set { insertNameValueField(FldAssettyp, value); }
		}

		/// <summary>Field : "Identifier type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldIdenttyp { get { return m_fldIdenttyp; } }
		private static FieldRef m_fldIdenttyp = new FieldRef("asset", "identtyp");

		/// <summary>Field : "Identifier type" Tipo: "AC" Formula:  ""</summary>
		public string ValIdenttyp
		{
			get { return (string)returnValueField(FldIdenttyp); }
			set { insertNameValueField(FldIdenttyp, value); }
		}

		/// <summary>Field : "GRAI – Global Returnable Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldGrai { get { return m_fldGrai; } }
		private static FieldRef m_fldGrai = new FieldRef("asset", "grai");

		/// <summary>Field : "GRAI – Global Returnable Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public string ValGrai
		{
			get { return (string)returnValueField(FldGrai); }
			set { insertNameValueField(FldGrai, value); }
		}

		/// <summary>Field : "GIAI – Global Individual Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldGiai { get { return m_fldGiai; } }
		private static FieldRef m_fldGiai = new FieldRef("asset", "giai");

		/// <summary>Field : "GIAI – Global Individual Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public string ValGiai
		{
			get { return (string)returnValueField(FldGiai); }
			set { insertNameValueField(FldGiai, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("asset", "photo");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}

		/// <summary>Field : ">>Kind of equipment" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodkinde { get { return m_fldCodkinde; } }
		private static FieldRef m_fldCodkinde = new FieldRef("asset", "codkinde");

		/// <summary>Field : ">>Kind of equipment" Tipo: "CE" Formula:  ""</summary>
		public string ValCodkinde
		{
			get { return (string)returnValueField(FldCodkinde); }
			set { insertNameValueField(FldCodkinde, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodmanuf { get { return m_fldCodmanuf; } }
		private static FieldRef m_fldCodmanuf = new FieldRef("asset", "codmanuf");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodmanuf
		{
			get { return (string)returnValueField(FldCodmanuf); }
			set { insertNameValueField(FldCodmanuf, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescription { get { return m_fldDescription; } }
		private static FieldRef m_fldDescription = new FieldRef("asset", "description");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescription
		{
			get { return (string)returnValueField(FldDescription); }
			set { insertNameValueField(FldDescription, value); }
		}

		/// <summary>Field : "Detailed description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldLongdesc { get { return m_fldLongdesc; } }
		private static FieldRef m_fldLongdesc = new FieldRef("asset", "longdesc");

		/// <summary>Field : "Detailed description" Tipo: "MO" Formula:  ""</summary>
		public string ValLongdesc
		{
			get { return (string)returnValueField(FldLongdesc); }
			set { insertNameValueField(FldLongdesc, value); }
		}

		/// <summary>Field : "Category" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldCategory { get { return m_fldCategory; } }
		private static FieldRef m_fldCategory = new FieldRef("asset", "category");

		/// <summary>Field : "Category" Tipo: "AC" Formula:  ""</summary>
		public string ValCategory
		{
			get { return (string)returnValueField(FldCategory); }
			set { insertNameValueField(FldCategory, value); }
		}

		/// <summary>Field : "Background color for category" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBg_color { get { return m_fldBg_color; } }
		private static FieldRef m_fldBg_color = new FieldRef("asset", "bg_color");

		/// <summary>Field : "Background color for category" Tipo: "C" Formula:  ""</summary>
		public string ValBg_color
		{
			get { return (string)returnValueField(FldBg_color); }
			set { insertNameValueField(FldBg_color, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("asset", "zzstate");



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
        public static CSGenioAasset search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAasset area = new CSGenioAasset(user, user.CurrentModule);

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
        public static List<CSGenioAasset> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAasset>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAasset> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAasset>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX ASSET]/


		public StatusMessage carga_Manuals(string codkinde, PersistentSupport sp, User user)
		{
			int offset = 0;
			int numberOfRecords = -1;
			List<ColumnSort> sorts = null;
			
			if (GenFunctions.emptyG(codkinde) == 1)
				return StatusMessage.Error();

			FieldRef[] fields = new FieldRef[]
			{
				CSGenioAmanua.FldCodmanua,
				CSGenioAmanua.FldName,
			};

			ListingMVC<CSGenioAmanua> list = new ListingMVC<CSGenioAmanua>(fields, sorts, offset, numberOfRecords, true, user, true);
			CSGenioAmanua.searchListAdvancedWhere(sp, user, CriteriaSet.And().Equal(CSGenioAmanua.FldCodkinde, codkinde), list);

			foreach(var row in list.Rows)
			{
				CSGenioAassma assma = new CSGenioAassma(user);

				assma.ValCodasset = this.ValCodasset;
				object[] args = null;
				args = new object[1];
				args[0] = row.ValName;
				assma.ValName = ((string)args[0]);
 				assma.insert(sp);
			}

			return StatusMessage.OK();
		}
  
		public StatusMessage carga_Parameters(string codkinde, PersistentSupport sp, User user)
		{
			int offset = 0;
			int numberOfRecords = -1;
			List<ColumnSort> sorts = null;
			
			if (GenFunctions.emptyG(codkinde) == 1)
				return StatusMessage.Error();

			FieldRef[] fields = new FieldRef[]
			{
				CSGenioAparam.FldCodparam,
				CSGenioAparam.FldParameter,
				CSGenioAparam.FldDecimalplaces,
				CSGenioAparam.FldDatatype,
			};

			ListingMVC<CSGenioAparam> list = new ListingMVC<CSGenioAparam>(fields, sorts, offset, numberOfRecords, true, user, true);
			CSGenioAparam.searchListAdvancedWhere(sp, user, CriteriaSet.And().Equal(CSGenioAparam.FldCodkinde, codkinde), list);

			foreach(var row in list.Rows)
			{
				CSGenioAasspa asspa = new CSGenioAasspa(user);

				asspa.ValCodasset = this.ValCodasset;
				object[] args = null;
				args = new object[1];
				args[0] = row.ValCodparam;
				asspa.ValCodparam = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValParameter;
				asspa.ValText = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValDecimalplaces;
				asspa.ValDecimalplaces = ((decimal)args[0]);
				args = new object[1];
				args[0] = row.ValDatatype;
				asspa.ValDatatype = ((string)args[0]);
 				asspa.insert(sp);
			}

			return StatusMessage.OK();
		}
     
               

	}
}
