
 
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
	/// Kit component
	/// </summary>
	public class CSGenioAcmpki : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAcmpki(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR CMPKI]/
		}

		public CSGenioAcmpki(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codcmpki", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtpequ", FieldType.KEY_GUID);
			Qfield.FieldDescription = "TYPE OF EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "TYPE_OF_EQUIPMENT18080";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "order";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "order", FieldType.NUMERIC);
			Qfield.FieldDescription = "Order";
			Qfield.FieldSize =  5;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "ORDER39632";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codtpequ";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "order");
			Qfield.HasOrdering = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtpeq1", FieldType.KEY_GUID);
			Qfield.FieldDescription = "TYPE OF COMPONENT EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "TYPE_OF_COMPONENT_EQ16631";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"codtpequ"},new int[] {0},"cmpki","codcmpki"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantida", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "code", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CODE49225";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "url", FieldType.TEXT);
			Qfield.FieldDescription = "Site";
			Qfield.FieldSize =  250;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SITE06486";

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
			info.ParentTables.Add("tpeq1", new Relation("GQT", "gqtcmpki", "cmpki", "codcmpki", "codtpeq1", "GQT", "gqttpequ", "tpeq1", "codtpequ", "codtpequ"));
			info.ParentTables.Add("tpequ", new Relation("GQT", "gqtcmpki", "cmpki", "codcmpki", "codtpequ", "GQT", "gqttpequ", "tpequ", "codtpequ", "codtpequ"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("tpequ","tpequ");
			info.Pathways.Add("tpeq1","tpeq1");
			info.Pathways.Add("famil","tpequ");
			info.Pathways.Add("fami1","tpeq1");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "codtpeq1"
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
		/// static CSGenioAcmpki()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtcmpki";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codcmpki";
			info.HumanKeyName="order,".TrimEnd(',');
			info.MainOrderField="order";
			info.Alias="cmpki";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Kit component";
			info.AreaPluralDesignation="Kit components";
			info.DescriptionCav="KIT_COMPONENT05829";

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
		public static FieldRef FldCodcmpki { get { return m_fldCodcmpki; } }
		private static FieldRef m_fldCodcmpki = new FieldRef("cmpki", "codcmpki");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcmpki
		{
			get { return (string)returnValueField(FldCodcmpki); }
			set { insertNameValueField(FldCodcmpki, value); }
		}

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("cmpki", "codtpequ");

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrder { get { return m_fldOrder; } }
		private static FieldRef m_fldOrder = new FieldRef("cmpki", "order");

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrder
		{
			get { return (decimal)returnValueField(FldOrder); }
			set { insertNameValueField(FldOrder, value); }
		}

		/// <summary>Field : "TYPE OF COMPONENT EQUIPMENT" Tipo: "CE" Formula: DF "[CMPKI->CODTPEQU]"</summary>
		public static FieldRef FldCodtpeq1 { get { return m_fldCodtpeq1; } }
		private static FieldRef m_fldCodtpeq1 = new FieldRef("cmpki", "codtpeq1");

		/// <summary>Field : "TYPE OF COMPONENT EQUIPMENT" Tipo: "CE" Formula: DF "[CMPKI->CODTPEQU]"</summary>
		public string ValCodtpeq1
		{
			get { return (string)returnValueField(FldCodtpeq1); }
			set { insertNameValueField(FldCodtpeq1, value); }
		}

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantida { get { return m_fldQuantida; } }
		private static FieldRef m_fldQuantida = new FieldRef("cmpki", "quantida");

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantida
		{
			get { return (decimal)returnValueField(FldQuantida); }
			set { insertNameValueField(FldQuantida, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("cmpki", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCode { get { return m_fldCode; } }
		private static FieldRef m_fldCode = new FieldRef("cmpki", "code");

		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		public string ValCode
		{
			get { return (string)returnValueField(FldCode); }
			set { insertNameValueField(FldCode, value); }
		}

		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldUrl { get { return m_fldUrl; } }
		private static FieldRef m_fldUrl = new FieldRef("cmpki", "url");

		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		public string ValUrl
		{
			get { return (string)returnValueField(FldUrl); }
			set { insertNameValueField(FldUrl, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("cmpki", "zzstate");



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
        public static CSGenioAcmpki search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAcmpki area = new CSGenioAcmpki(user, user.CurrentModule);

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
        public static List<CSGenioAcmpki> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAcmpki>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAcmpki> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAcmpki>(where, listing);
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
			criteria.Equal(CSGenioAcmpki.FldCodtpequ, ValCodtpequ);
			sp.ReorderSequence(this, DBFields[FldOrder.Field], criteria);

            return msg;
		}

 


		// USE /[MANUAL GQT TABAUX CMPKI]/

     
  		/// <summary>
        /// Reorders the values of the ordering field along a subset so that the current record moves in that order to the specified position
        /// </summary>
        /// <param name="sp">The current PersistentSupport</param>
        /// <param name="position">The position to where the record will be moved</param>
        public void Reorder_Order(PersistentSupport sp, int position, bool moveRow = true)
        {
            int posactual = (int)ValOrder;
            int posnova = position + 1;
            ValOrder = posnova;

			ReorderByField(DBFields[FldOrder.Field], sp, posactual, posnova, moveRow);
        }

        private void OnReorder_Order(PersistentSupport sp, int oldpos, CriteriaSet condition)
        {
// USE /[MANUAL GQT ONREORDER CMPKI.ORDER]/
        }

       

	}
}
