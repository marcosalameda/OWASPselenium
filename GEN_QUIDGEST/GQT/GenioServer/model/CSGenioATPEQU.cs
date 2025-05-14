

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
	/// TYPE OF EQUIPMENT
	/// </summary>
	public class CSGenioAtpequ : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAtpequ(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR TPEQU]/
		}

		public CSGenioAtpequ(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codtpequ", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codfamil", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tipoequi", FieldType.TEXT);
			Qfield.FieldDescription = "TYPE OF EQUIPMENT";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "TYPE_OF_EQUIPMENT18080";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tpequcod", FieldType.TEXT);
			Qfield.FieldDescription = "Code";
			Qfield.FieldSize =  20;
			Qfield.CavDesignation = "CODE49225";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);
			info.TreeTable.DesignationField = "tpequ.tpequcod";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tpequpai", FieldType.TEXT);
			Qfield.FieldDescription = "Dependent on";
			Qfield.FieldSize =  20;
			Qfield.CavDesignation = "DEPENDENT_ON28321";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.ParentTableField = "tpequ.tpequpai";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nivel", FieldType.NUMERIC);
			Qfield.FieldDescription = "Level";
			Qfield.FieldSize =  3;
			Qfield.CavDesignation = "LEVEL06184";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);
			info.TreeTable.RecordLevelField = "tpequ.nivel";

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "backcolo", FieldType.TEXT);
			Qfield.FieldDescription = "Background color";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "BACKGROUND_COLOR47883";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "corletra", FieldType.TEXT);
			Qfield.FieldDescription = "Letter color";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "LETTER_COLOR15736";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "precomax", FieldType.CURRENCY);
			Qfield.FieldDescription = "Maximum price";
			Qfield.FieldSize =  12;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "MAXIMUM_PRICE55489";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "precoult", FieldType.CURRENCY);
			Qfield.FieldDescription = "Last price";
			Qfield.FieldSize =  12;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "LAST_PRICE25852";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "since", FieldType.DATETIME);
			Qfield.FieldDescription = "Since";
			Qfield.FieldSize =  16;
			Qfield.CavDesignation = "SINCE47259";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "qtdequip", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  6;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.IsVirtual = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "kit", FieldType.LOGIC);
			Qfield.FieldDescription = "Kit";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "KIT27179";

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
			info.ChildTable = new ChildRelation[7];
			info.ChildTable[0]= new ChildRelation("lnhpd", new String[] {"codtpequ"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("tabpr", new String[] {"codtpeq1"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("cmpki", new String[] {"codtpequ","codtpeq1"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("insta", new String[] {"codtpequ"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("equip", new String[] {"codtpequ"}, DeleteProc.NA);
			info.ChildTable[5]= new ChildRelation("lnhde", new String[] {"codtpequ"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("lnhag", new String[] {"codtpequ"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("famil", new Relation("GQT", "gqttpequ", "tpequ", "codtpequ", "codfamil", "GQT", "gqtfamil", "famil", "codfamil", "codfamil"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("famil","famil");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------




			info.RelatedSumFields = new string[] {
			 "qtdequip"
			};


			info.LastValueFields = new string[] {
			 "precomax","precoult","since"
			};



			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAtpequ()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqttpequ";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codtpequ";
			info.HumanKeyName="tipoequi,".TrimEnd(',');
			info.Alias="tpequ";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="TYPE OF EQUIPMENT";
			info.AreaPluralDesignation="Types of equipment";
			info.DescriptionCav="TYPE_OF_EQUIPMENT18080";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();




			info.TreeTable = new TreeTable();

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
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("tpequ", "codtpequ");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodfamil { get { return m_fldCodfamil; } }
		private static FieldRef m_fldCodfamil = new FieldRef("tpequ", "codfamil");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfamil
		{
			get { return (string)returnValueField(FldCodfamil); }
			set { insertNameValueField(FldCodfamil, value); }
		}

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTipoequi { get { return m_fldTipoequi; } }
		private static FieldRef m_fldTipoequi = new FieldRef("tpequ", "tipoequi");

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		public string ValTipoequi
		{
			get { return (string)returnValueField(FldTipoequi); }
			set { insertNameValueField(FldTipoequi, value); }
		}

		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public static FieldRef FldTpequcod { get { return m_fldTpequcod; } }
		private static FieldRef m_fldTpequcod = new FieldRef("tpequ", "tpequcod");

		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public string ValTpequcod
		{
			get { return (string)returnValueField(FldTpequcod); }
			set { insertNameValueField(FldTpequcod, value); }
		}

		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		public static FieldRef FldTpequpai { get { return m_fldTpequpai; } }
		private static FieldRef m_fldTpequpai = new FieldRef("tpequ", "tpequpai");

		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		public string ValTpequpai
		{
			get { return (string)returnValueField(FldTpequpai); }
			set { insertNameValueField(FldTpequpai, value); }
		}

		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public static FieldRef FldNivel { get { return m_fldNivel; } }
		private static FieldRef m_fldNivel = new FieldRef("tpequ", "nivel");

		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public decimal ValNivel
		{
			get { return (decimal)returnValueField(FldNivel); }
			set { insertNameValueField(FldNivel, value); }
		}

		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldBackcolo { get { return m_fldBackcolo; } }
		private static FieldRef m_fldBackcolo = new FieldRef("tpequ", "backcolo");

		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		public string ValBackcolo
		{
			get { return (string)returnValueField(FldBackcolo); }
			set { insertNameValueField(FldBackcolo, value); }
		}

		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCorletra { get { return m_fldCorletra; } }
		private static FieldRef m_fldCorletra = new FieldRef("tpequ", "corletra");

		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		public string ValCorletra
		{
			get { return (string)returnValueField(FldCorletra); }
			set { insertNameValueField(FldCorletra, value); }
		}

		/// <summary>Field : "Maximum price" Tipo: "$D" Formula: U1 "TABPR[TABPR->PRECOHOR][TABPR->PRECOHOR]"</summary>
		public static FieldRef FldPrecomax { get { return m_fldPrecomax; } }
		private static FieldRef m_fldPrecomax = new FieldRef("tpequ", "precomax");

		/// <summary>Field : "Maximum price" Tipo: "$D" Formula: U1 "TABPR[TABPR->PRECOHOR][TABPR->PRECOHOR]"</summary>
		public decimal ValPrecomax
		{
			get { return (decimal)returnValueField(FldPrecomax); }
			set { insertNameValueField(FldPrecomax, value); }
		}

		/// <summary>Field : "Last price" Tipo: "$D" Formula: U1 "TABPR[TABPR->SINCE][TABPR->PRECOHOR][Today]"</summary>
		public static FieldRef FldPrecoult { get { return m_fldPrecoult; } }
		private static FieldRef m_fldPrecoult = new FieldRef("tpequ", "precoult");

		/// <summary>Field : "Last price" Tipo: "$D" Formula: U1 "TABPR[TABPR->SINCE][TABPR->PRECOHOR][Today]"</summary>
		public decimal ValPrecoult
		{
			get { return (decimal)returnValueField(FldPrecoult); }
			set { insertNameValueField(FldPrecoult, value); }
		}

		/// <summary>Field : "Since" Tipo: "DT" Formula: U1 "TABPR[TABPR->SINCE][TABPR->SINCE][Today]"</summary>
		public static FieldRef FldSince { get { return m_fldSince; } }
		private static FieldRef m_fldSince = new FieldRef("tpequ", "since");

		/// <summary>Field : "Since" Tipo: "DT" Formula: U1 "TABPR[TABPR->SINCE][TABPR->SINCE][Today]"</summary>
		public DateTime ValSince
		{
			get { return (DateTime)returnValueField(FldSince); }
			set { insertNameValueField(FldSince, value); }
		}

		/// <summary>Field : "Amount" Tipo: "N" Formula: SR "[EQUIP->1]"</summary>
		public static FieldRef FldQtdequip { get { return m_fldQtdequip; } }
		private static FieldRef m_fldQtdequip = new FieldRef("tpequ", "qtdequip");

		/// <summary>Field : "Amount" Tipo: "N" Formula: SR "[EQUIP->1]"</summary>
		public decimal ValQtdequip
		{
			get { return (decimal)returnValueField(FldQtdequip); }
			set { insertNameValueField(FldQtdequip, value); }
		}

		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldKit { get { return m_fldKit; } }
		private static FieldRef m_fldKit = new FieldRef("tpequ", "kit");

		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		public int ValKit
		{
			get { return (int)returnValueField(FldKit); }
			set { insertNameValueField(FldKit, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("tpequ", "zzstate");



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
        public static CSGenioAtpequ search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAtpequ area = new CSGenioAtpequ(user, user.CurrentModule);

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
        public static List<CSGenioAtpequ> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAtpequ>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAtpequ> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAtpequ>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX TPEQU]/

   
		public StatusMessage carga_unico(string codtpequ, PersistentSupport sp, User user)
		{
			int offset = 0;
			int numberOfRecords = -1;
			List<ColumnSort> sorts = null;

			FieldRef[] fields = new FieldRef[]
			{
				CSGenioAtpequ.FldCodtpequ,
			};

			ListingMVC<CSGenioAtpequ> list = new ListingMVC<CSGenioAtpequ>(fields, sorts, offset, numberOfRecords, true, user, true);
			CSGenioAtpequ.searchListAdvancedWhere(sp, user, CriteriaSet.And().Equal(CSGenioAtpequ.FldCodtpequ, codtpequ), list);

			foreach(var row in list.Rows)
			{
				CSGenioAcmpki cmpki = new CSGenioAcmpki(user);

				object[] args = null;
				args = new object[1];
				args[0] = row.ValCodtpequ;
				cmpki.ValCodtpeq1 = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValCodtpequ;
				cmpki.ValCodtpequ = ((string)args[0]);
 				cmpki.insert(sp);
			}

			return StatusMessage.OK();
		}
   

              

	}
}
