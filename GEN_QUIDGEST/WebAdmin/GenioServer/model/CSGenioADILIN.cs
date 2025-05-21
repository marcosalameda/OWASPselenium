

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
	/// Dispatch line
	/// </summary>
	public class CSGenioAdilin : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAdilin(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR DILIN]/
		}

		public CSGenioAdilin(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "coddilin", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coddispa", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>DISPATCH";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__DISPATCH53890";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "linenumb";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "linenumb", FieldType.NUMERIC);
			Qfield.FieldDescription = "Line";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "LINE27983";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "coddispa";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "linenumb");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codprodu", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>PRODUCT";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__PRODUCT04710";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ordered", FieldType.NUMERIC);
			Qfield.FieldDescription = "Ordered";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "ORDERED04034";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "delivere", FieldType.NUMERIC);
			Qfield.FieldDescription = "Delivered";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "DELIVERED26597";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "outstand", FieldType.NUMERIC);
			Qfield.FieldDescription = "Outstanding";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "OUTSTANDING36400";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"ordered","delivere"}, new int[] {0,1}, "dilin", "coddilin"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])-((decimal)args[1]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "instant", FieldType.DATETIME);
			Qfield.FieldDescription = "Instant";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_coddispa", "dispadt");
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
			info.ParentTables.Add("dispa", new Relation("GQT", "gqtdispatchline", "dilin", "coddilin", "coddispa", "GQT", "gqtdispatch", "dispa", "coddispa", "coddispa"));
			info.ParentTables.Add("produ", new Relation("GQT", "gqtdispatchline", "dilin", "coddilin", "codprodu", "GQT", "gqtproduct", "produ", "codprodu", "codprodu"));
			info.ParentTables.Add("_replicRel_coddispa", new Relation("GQT", "gqtdispatchline", "dilin", "coddilin", "coddispa", "GQT", "gqtdispatch", "dispa", "coddispa", "coddispa"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(12);
			info.Pathways.Add("dispa","dispa");
			info.Pathways.Add("produ","produ");
			info.Pathways.Add("perso","dispa");
			info.Pathways.Add("disst","dispa");
			info.Pathways.Add("entit","dispa");
			info.Pathways.Add("faci1","dispa");
			info.Pathways.Add("faci2","dispa");
			info.Pathways.Add("locat","produ");
			info.Pathways.Add("lcext","produ");
			info.Pathways.Add("facil","produ");
			info.Pathways.Add("cntry","produ");
			info.Pathways.Add("facty","produ");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("dilin", "produ", "stock", "delivere", '-', true));
			info.RelatedSumArgs.Add( new RelatedSumArgument("dilin", "produ", "outputs", "delivere", '+', true));



			info.ReplicaFields = new string[] {
			 "instant"
			};

			info.InternalOperationFields = new string[] {
			 "outstand"
			};

			info.SequentialDefaultValues = new string[] {
			 "linenumb"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAdilin()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtdispatchline";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="coddilin";
			info.HumanKeyName="linenumb,".TrimEnd(',');
			info.Alias="dilin";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Dispatch line";
			info.AreaPluralDesignation="Dispatch lines";
			info.DescriptionCav="DISPATCH_LINE65326";

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
		public static FieldRef FldCoddilin { get { return m_fldCoddilin; } }
		private static FieldRef m_fldCoddilin = new FieldRef("dilin", "coddilin");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddilin
		{
			get { return (string)returnValueField(FldCoddilin); }
			set { insertNameValueField(FldCoddilin, value); }
		}

		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddispa { get { return m_fldCoddispa; } }
		private static FieldRef m_fldCoddispa = new FieldRef("dilin", "coddispa");

		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddispa
		{
			get { return (string)returnValueField(FldCoddispa); }
			set { insertNameValueField(FldCoddispa, value); }
		}

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldLinenumb { get { return m_fldLinenumb; } }
		private static FieldRef m_fldLinenumb = new FieldRef("dilin", "linenumb");

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public decimal ValLinenumb
		{
			get { return (decimal)returnValueField(FldLinenumb); }
			set { insertNameValueField(FldLinenumb, value); }
		}

		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodprodu { get { return m_fldCodprodu; } }
		private static FieldRef m_fldCodprodu = new FieldRef("dilin", "codprodu");

		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprodu
		{
			get { return (string)returnValueField(FldCodprodu); }
			set { insertNameValueField(FldCodprodu, value); }
		}

		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrdered { get { return m_fldOrdered; } }
		private static FieldRef m_fldOrdered = new FieldRef("dilin", "ordered");

		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrdered
		{
			get { return (decimal)returnValueField(FldOrdered); }
			set { insertNameValueField(FldOrdered, value); }
		}

		/// <summary>Field : "Delivered" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldDelivere { get { return m_fldDelivere; } }
		private static FieldRef m_fldDelivere = new FieldRef("dilin", "delivere");

		/// <summary>Field : "Delivered" Tipo: "N" Formula:  ""</summary>
		public decimal ValDelivere
		{
			get { return (decimal)returnValueField(FldDelivere); }
			set { insertNameValueField(FldDelivere, value); }
		}

		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[DILIN->ORDERED]-[DILIN->DELIVERE]"</summary>
		public static FieldRef FldOutstand { get { return m_fldOutstand; } }
		private static FieldRef m_fldOutstand = new FieldRef("dilin", "outstand");

		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[DILIN->ORDERED]-[DILIN->DELIVERE]"</summary>
		public decimal ValOutstand
		{
			get { return (decimal)returnValueField(FldOutstand); }
			set { insertNameValueField(FldOutstand, value); }
		}

		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[DISPA->DISPADT]"</summary>
		public static FieldRef FldInstant { get { return m_fldInstant; } }
		private static FieldRef m_fldInstant = new FieldRef("dilin", "instant");

		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[DISPA->DISPADT]"</summary>
		public DateTime ValInstant
		{
			get { return (DateTime)returnValueField(FldInstant); }
			set { insertNameValueField(FldInstant, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("dilin", "zzstate");



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
        public static CSGenioAdilin search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAdilin area = new CSGenioAdilin(user, user.CurrentModule);

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
        public static List<CSGenioAdilin> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAdilin>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAdilin> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAdilin>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX DILIN]/

     

         

	}
}
