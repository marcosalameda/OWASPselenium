

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
	/// Product
	/// </summary>
	public class CSGenioAprodu : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAprodu(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PRODU]/
		}

		public CSGenioAprodu(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codprodu", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codlocat", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">>LOCATION";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__LOCATION45198";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codlcext", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">>LOCATION EXTENSION";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__LOCATION_EXTENSION43450";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "product", FieldType.TEXTO);
			Qfield.FieldDescription = "Product";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PRODUCT12880";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sku", FieldType.TEXTO);
			Qfield.FieldDescription = "SKU";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SKU42303";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gtin", FieldType.TEXTO);
			Qfield.FieldDescription = "GTIN";
			Qfield.FieldSize =  14;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GTIN45487";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "size", FieldType.TEXTO);
			Qfield.FieldDescription = "Size";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SIZE10299";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "weight", FieldType.NUMERO);
			Qfield.FieldDescription = "Weight";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "WEIGHT36329";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "price", FieldType.VALOR);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "inputs", FieldType.NUMERO);
			Qfield.FieldDescription = "Inputs";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "INPUTS19315";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "outputs", FieldType.NUMERO);
			Qfield.FieldDescription = "Outputs";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "OUTPUTS47833";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "stock", FieldType.NUMERO);
			Qfield.FieldDescription = "Stock";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "STOCK37618";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "image", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Image";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE65174";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "in_use", FieldType.ARRAY_COD_LOGICO);
			Qfield.FieldDescription = "In use";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IN_USE42606";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayLyesno";
            Qfield.ArrayClassName = "Yesno";
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
			info.ChildTable = new ChildRelation[3];
			info.ChildTable[0]= new ChildRelation("dilin", new String[] {"codprodu"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("relin", new String[] {"codprodu"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("stock", new String[] {"codprodu"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("lcext", new Relation("GQT", "gqtproduct", "produ", "codprodu", "codlcext", "GQT", "gqtlocationextension", "lcext", "codlcext", "codlcext"));
			info.ParentTables.Add("locat", new Relation("GQT", "gqtproduct", "produ", "codprodu", "codlocat", "GQT", "gqtlocation", "locat", "codlocat", "codlocat"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(8);
			info.Pathways.Add("locat","locat");
			info.Pathways.Add("lcext","lcext");
			info.Pathways.Add("facil","locat");
			info.Pathways.Add("entit","locat");
			info.Pathways.Add("facty","locat");
			info.Pathways.Add("cntry","locat");
			info.Pathways.Add("faci1","locat");
			info.Pathways.Add("faci2","locat");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------




			info.RelatedSumFields = new string[] {
			 "inputs","outputs","stock"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAprodu()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtproduct";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codprodu";
			info.HumanKeyName="product,".TrimEnd(',');
			info.Alias="produ";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Product";
			info.AreaPluralDesignation="Products";
			info.DescriptionCav="PRODUCT12880";

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
		public static FieldRef FldCodprodu { get { return m_fldCodprodu; } }
		private static FieldRef m_fldCodprodu = new FieldRef("produ", "codprodu");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodprodu
		{
			get { return (string)returnValueField(FldCodprodu); }
			set { insertNameValueField(FldCodprodu, value); }
		}

		/// <summary>Field : ">>LOCATION" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlocat { get { return m_fldCodlocat; } }
		private static FieldRef m_fldCodlocat = new FieldRef("produ", "codlocat");

		/// <summary>Field : ">>LOCATION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlocat
		{
			get { return (string)returnValueField(FldCodlocat); }
			set { insertNameValueField(FldCodlocat, value); }
		}

		/// <summary>Field : ">>LOCATION EXTENSION" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodlcext { get { return m_fldCodlcext; } }
		private static FieldRef m_fldCodlcext = new FieldRef("produ", "codlcext");

		/// <summary>Field : ">>LOCATION EXTENSION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlcext
		{
			get { return (string)returnValueField(FldCodlcext); }
			set { insertNameValueField(FldCodlcext, value); }
		}

		/// <summary>Field : "Product" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldProduct { get { return m_fldProduct; } }
		private static FieldRef m_fldProduct = new FieldRef("produ", "product");

		/// <summary>Field : "Product" Tipo: "C" Formula:  ""</summary>
		public string ValProduct
		{
			get { return (string)returnValueField(FldProduct); }
			set { insertNameValueField(FldProduct, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("produ", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "SKU" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSku { get { return m_fldSku; } }
		private static FieldRef m_fldSku = new FieldRef("produ", "sku");

		/// <summary>Field : "SKU" Tipo: "C" Formula:  ""</summary>
		public string ValSku
		{
			get { return (string)returnValueField(FldSku); }
			set { insertNameValueField(FldSku, value); }
		}

		/// <summary>Field : "GTIN" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldGtin { get { return m_fldGtin; } }
		private static FieldRef m_fldGtin = new FieldRef("produ", "gtin");

		/// <summary>Field : "GTIN" Tipo: "C" Formula:  ""</summary>
		public string ValGtin
		{
			get { return (string)returnValueField(FldGtin); }
			set { insertNameValueField(FldGtin, value); }
		}

		/// <summary>Field : "Size" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldSize { get { return m_fldSize; } }
		private static FieldRef m_fldSize = new FieldRef("produ", "size");

		/// <summary>Field : "Size" Tipo: "C" Formula:  ""</summary>
		public string ValSize
		{
			get { return (string)returnValueField(FldSize); }
			set { insertNameValueField(FldSize, value); }
		}

		/// <summary>Field : "Weight" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldWeight { get { return m_fldWeight; } }
		private static FieldRef m_fldWeight = new FieldRef("produ", "weight");

		/// <summary>Field : "Weight" Tipo: "N" Formula:  ""</summary>
		public decimal ValWeight
		{
			get { return (decimal)returnValueField(FldWeight); }
			set { insertNameValueField(FldWeight, value); }
		}

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("produ", "price");

		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "Inputs" Tipo: "N" Formula: SR "[RELIN->RECEIVED]"</summary>
		public static FieldRef FldInputs { get { return m_fldInputs; } }
		private static FieldRef m_fldInputs = new FieldRef("produ", "inputs");

		/// <summary>Field : "Inputs" Tipo: "N" Formula: SR "[RELIN->RECEIVED]"</summary>
		public decimal ValInputs
		{
			get { return (decimal)returnValueField(FldInputs); }
			set { insertNameValueField(FldInputs, value); }
		}

		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[DILIN->DELIVERE]"</summary>
		public static FieldRef FldOutputs { get { return m_fldOutputs; } }
		private static FieldRef m_fldOutputs = new FieldRef("produ", "outputs");

		/// <summary>Field : "Outputs" Tipo: "N" Formula: SR "[DILIN->DELIVERE]"</summary>
		public decimal ValOutputs
		{
			get { return (decimal)returnValueField(FldOutputs); }
			set { insertNameValueField(FldOutputs, value); }
		}

		/// <summary>Field : "Stock" Tipo: "N" Formula: SR "[RELIN->RECEIVED]-[DILIN->DELIVERE]"</summary>
		public static FieldRef FldStock { get { return m_fldStock; } }
		private static FieldRef m_fldStock = new FieldRef("produ", "stock");

		/// <summary>Field : "Stock" Tipo: "N" Formula: SR "[RELIN->RECEIVED]-[DILIN->DELIVERE]"</summary>
		public decimal ValStock
		{
			get { return (decimal)returnValueField(FldStock); }
			set { insertNameValueField(FldStock, value); }
		}

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldImage { get { return m_fldImage; } }
		private static FieldRef m_fldImage = new FieldRef("produ", "image");

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValImage
		{
			get { return (byte[])returnValueField(FldImage); }
			set { insertNameValueField(FldImage, value); }
		}

		/// <summary>Field : "In use" Tipo: "AL" Formula:  ""</summary>
		public static FieldRef FldIn_use { get { return m_fldIn_use; } }
		private static FieldRef m_fldIn_use = new FieldRef("produ", "in_use");

		/// <summary>Field : "In use" Tipo: "AL" Formula:  ""</summary>
		public int ValIn_use
		{
			get { return (int)returnValueField(FldIn_use); }
			set { insertNameValueField(FldIn_use, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("produ", "zzstate");



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
        public static CSGenioAprodu search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAprodu area = new CSGenioAprodu(user, user.CurrentModule);

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
        public static List<CSGenioAprodu> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAprodu>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAprodu> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAprodu>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX PRODU]/

     

                

	}
}
