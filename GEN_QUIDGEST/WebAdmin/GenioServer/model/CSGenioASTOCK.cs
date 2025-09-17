
 
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
	/// Stock evolution
	/// </summary>
	public class CSGenioAstock : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAstock(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR STOCK]/
		}

		public CSGenioAstock(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codstock", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sequence", FieldType.NUMERIC);
			Qfield.FieldDescription = "Sequence";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "SEQUENCE42310";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATETIME);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "type", FieldType.TEXT);
			Qfield.FieldDescription = "Type";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TYPE00312";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codprodu", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>PRODUCT";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__PRODUCT04710";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codrecei", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>RECEIPT";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__RECEIPT04632";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coddispa", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>DISPATCH";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__DISPATCH53890";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantity", FieldType.NUMERIC);
			Qfield.FieldDescription = "Quantity";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "QUANTITY06415";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "balance", FieldType.NUMERIC);
			Qfield.FieldDescription = "Balance";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "BALANCE13297";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "referenc", FieldType.TEXT);
			Qfield.FieldDescription = "Reference";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "REFERENCE28402";

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
			info.ParentTables.Add("dispa", new Relation("GQT", "stock", "stock", "codstock", "coddispa", "GQT", "gqtdispatch", "dispa", "coddispa", "coddispa"));
			info.ParentTables.Add("produ", new Relation("GQT", "stock", "stock", "codstock", "codprodu", "GQT", "gqtproduct", "produ", "codprodu", "codprodu"));
			info.ParentTables.Add("recei", new Relation("GQT", "stock", "stock", "codstock", "codrecei", "GQT", "gqtreceipt", "recei", "codrecei", "codrecei"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(13);
			info.Pathways.Add("dispa","dispa");
			info.Pathways.Add("recei","recei");
			info.Pathways.Add("produ","produ");
			info.Pathways.Add("disst","dispa");
			info.Pathways.Add("perso","dispa");
			info.Pathways.Add("entit","dispa");
			info.Pathways.Add("faci1","dispa");
			info.Pathways.Add("faci2","dispa");
			info.Pathways.Add("locat","produ");
			info.Pathways.Add("lcext","produ");
			info.Pathways.Add("facil","produ");
			info.Pathways.Add("facty","produ");
			info.Pathways.Add("cntry","produ");
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
		/// static CSGenioAstock()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="stock";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codstock";
			info.HumanKeyName="type,".TrimEnd(',');
			info.Alias="stock";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.View;
			info.AreaDesignation="Stock evolution";
			info.AreaPluralDesignation="Stock evolution";
			info.DescriptionCav="STOCK_EVOLUTION61800";

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
		public static FieldRef FldCodstock { get { return m_fldCodstock; } }
		private static FieldRef m_fldCodstock = new FieldRef("stock", "codstock");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodstock
		{
			get { return (string)returnValueField(FldCodstock); }
			set { insertNameValueField(FldCodstock, value); }
		}

		/// <summary>Field : "Sequence" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSequence { get { return m_fldSequence; } }
		private static FieldRef m_fldSequence = new FieldRef("stock", "sequence");

		/// <summary>Field : "Sequence" Tipo: "N" Formula:  ""</summary>
		public decimal ValSequence
		{
			get { return (decimal)returnValueField(FldSequence); }
			set { insertNameValueField(FldSequence, value); }
		}

		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("stock", "date");

		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldType { get { return m_fldType; } }
		private static FieldRef m_fldType = new FieldRef("stock", "type");

		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public string ValType
		{
			get { return (string)returnValueField(FldType); }
			set { insertNameValueField(FldType, value); }
		}

		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodprodu { get { return m_fldCodprodu; } }
		private static FieldRef m_fldCodprodu = new FieldRef("stock", "codprodu");

		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprodu
		{
			get { return (string)returnValueField(FldCodprodu); }
			set { insertNameValueField(FldCodprodu, value); }
		}

		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodrecei { get { return m_fldCodrecei; } }
		private static FieldRef m_fldCodrecei = new FieldRef("stock", "codrecei");

		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrecei
		{
			get { return (string)returnValueField(FldCodrecei); }
			set { insertNameValueField(FldCodrecei, value); }
		}

		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddispa { get { return m_fldCoddispa; } }
		private static FieldRef m_fldCoddispa = new FieldRef("stock", "coddispa");

		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddispa
		{
			get { return (string)returnValueField(FldCoddispa); }
			set { insertNameValueField(FldCoddispa, value); }
		}

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantity { get { return m_fldQuantity; } }
		private static FieldRef m_fldQuantity = new FieldRef("stock", "quantity");

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantity
		{
			get { return (decimal)returnValueField(FldQuantity); }
			set { insertNameValueField(FldQuantity, value); }
		}

		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBalance { get { return m_fldBalance; } }
		private static FieldRef m_fldBalance = new FieldRef("stock", "balance");

		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public decimal ValBalance
		{
			get { return (decimal)returnValueField(FldBalance); }
			set { insertNameValueField(FldBalance, value); }
		}

		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldReferenc { get { return m_fldReferenc; } }
		private static FieldRef m_fldReferenc = new FieldRef("stock", "referenc");

		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc
		{
			get { return (string)returnValueField(FldReferenc); }
			set { insertNameValueField(FldReferenc, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("stock", "zzstate");



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
        public static CSGenioAstock search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAstock area = new CSGenioAstock(user, user.CurrentModule);

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
        public static List<CSGenioAstock> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAstock>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAstock> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAstock>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX STOCK]/

     

           

	}
}
