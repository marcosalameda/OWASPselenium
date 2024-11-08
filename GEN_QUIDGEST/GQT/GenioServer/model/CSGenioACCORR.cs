

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
	/// Current account
	/// </summary>
	public class CSGenioAccorr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAccorr(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR CCORR]/
		}

		public CSGenioAccorr(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codccorr", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("norder", FieldType.NUMERO);
			Qfield.FieldDescription = "Order";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ORDER39632";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("date", FieldType.DATAHORA);
			Qfield.FieldDescription = "Instant";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "INSTANT35907";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("type", FieldType.TEXTO);
			Qfield.FieldDescription = "Type";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TYPE00312";

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
			Qfield = new Field("coddentr", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("qnty", FieldType.NUMERO);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("balance", FieldType.NUMERO);
			Qfield.FieldDescription = "Balance";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BALANCE13297";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("referenc", FieldType.TEXTO);
			Qfield.FieldDescription = "Ref";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "REF48861";

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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("indoc", new Relation("GQT", "ccorr", "ccorr", "codccorr", "coddentr", "GQT", "gqtindoc", "indoc", "coddentr", "coddentr"));
			info.ParentTables.Add("item", new Relation("GQT", "ccorr", "ccorr", "codccorr", "coditem", "GQT", "gqtitem", "item", "coditem", "coditem"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(10);
			info.Pathways.Add("item","item");
			info.Pathways.Add("indoc","indoc");
			info.Pathways.Add("wareh","item");
			info.Pathways.Add("gitem","item");
			info.Pathways.Add("cntry","indoc");
			info.Pathways.Add("ware1","indoc");
			info.Pathways.Add("cmpny","indoc");
			info.Pathways.Add("pesso","indoc");
			info.Pathways.Add("pais1","indoc");
			info.Pathways.Add("regi1","indoc");
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
		/// static CSGenioAccorr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="ccorr";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codccorr";
			info.HumanKeyName="type,".TrimEnd(',');
			info.Alias="ccorr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.View;
			info.AreaDesignation="Current account";
			info.AreaPluralDesignation="Current account";
			info.DescriptionCav="CURRENT_ACCOUNT19471";

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
		public static FieldRef FldCodccorr { get { return m_fldCodccorr; } }
		private static FieldRef m_fldCodccorr = new FieldRef("ccorr", "codccorr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodccorr
		{
			get { return (string)returnValueField(FldCodccorr); }
			set { insertNameValueField(FldCodccorr, value); }
		}


		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNorder { get { return m_fldNorder; } }
		private static FieldRef m_fldNorder = new FieldRef("ccorr", "norder");

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public decimal ValNorder
		{
			get { return (decimal)returnValueField(FldNorder); }
			set { insertNameValueField(FldNorder, value); }
		}


		/// <summary>Field : "Instant" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("ccorr", "date");

		/// <summary>Field : "Instant" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}


		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldType { get { return m_fldType; } }
		private static FieldRef m_fldType = new FieldRef("ccorr", "type");

		/// <summary>Field : "Type" Tipo: "C" Formula:  ""</summary>
		public string ValType
		{
			get { return (string)returnValueField(FldType); }
			set { insertNameValueField(FldType, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoditem { get { return m_fldCoditem; } }
		private static FieldRef m_fldCoditem = new FieldRef("ccorr", "coditem");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem
		{
			get { return (string)returnValueField(FldCoditem); }
			set { insertNameValueField(FldCoditem, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddentr { get { return m_fldCoddentr; } }
		private static FieldRef m_fldCoddentr = new FieldRef("ccorr", "coddentr");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddentr
		{
			get { return (string)returnValueField(FldCoddentr); }
			set { insertNameValueField(FldCoddentr, value); }
		}


		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQnty { get { return m_fldQnty; } }
		private static FieldRef m_fldQnty = new FieldRef("ccorr", "qnty");

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public decimal ValQnty
		{
			get { return (decimal)returnValueField(FldQnty); }
			set { insertNameValueField(FldQnty, value); }
		}


		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBalance { get { return m_fldBalance; } }
		private static FieldRef m_fldBalance = new FieldRef("ccorr", "balance");

		/// <summary>Field : "Balance" Tipo: "N" Formula:  ""</summary>
		public decimal ValBalance
		{
			get { return (decimal)returnValueField(FldBalance); }
			set { insertNameValueField(FldBalance, value); }
		}


		/// <summary>Field : "Ref" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldReferenc { get { return m_fldReferenc; } }
		private static FieldRef m_fldReferenc = new FieldRef("ccorr", "referenc");

		/// <summary>Field : "Ref" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc
		{
			get { return (string)returnValueField(FldReferenc); }
			set { insertNameValueField(FldReferenc, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("ccorr", "zzstate");



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
        public static CSGenioAccorr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAccorr area = new CSGenioAccorr(user, user.CurrentModule);

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
        public static List<CSGenioAccorr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAccorr>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAccorr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAccorr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX CCORR]/

     

          

	}
}
