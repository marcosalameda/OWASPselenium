

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
	/// Project
	/// </summary>
	public class CSGenioAproje : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAproje(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PROJE]/
		}

		public CSGenioAproje(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codproje", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("projecto", FieldType.TEXTO);
			Qfield.FieldDescription = "Project";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PROJECT37121";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codyear", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">REFERENCE YEAR";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_REFERENCE_YEAR44132";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("year", FieldType.TEXTO);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  4;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_codyear", "year");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("primeiro", FieldType.VALOR);
			Qfield.FieldDescription = "First";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "FIRST42972";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtagreg", "year", "yearnumb", "value", SortOrder.Ascending, LookupFormulaType.Previous, "codproje", "codproje");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("before", FieldType.VALOR);
			Qfield.FieldDescription = "Before";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "BEFORE60156";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtagreg", "year", "yearnumb", "value", SortOrder.Descending, LookupFormulaType.Previous, "codproje", "codproje");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("followin", FieldType.VALOR);
			Qfield.FieldDescription = "Following";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "FOLLOWING22170";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtagreg", "year", "yearnumb", "value", SortOrder.Ascending, LookupFormulaType.Next, "codproje", "codproje");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("ultimo", FieldType.VALOR);
			Qfield.FieldDescription = "Last";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "LAST49207";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqtagreg", "year", "yearnumb", "value", SortOrder.Descending, LookupFormulaType.Next, "codproje", "codproje");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("saldo1", FieldType.VALOR);
			Qfield.FieldDescription = "Next - Previous =";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "NEXT___PREVIOUS__58212";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"followin","before"}, new int[] {0,1}, "proje", "codproje"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((double)args[0])-((double)args[1]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("saldo2", FieldType.VALOR);
			Qfield.FieldDescription = "Last - First =";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "LAST___FIRST__42481";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"ultimo","primeiro"}, new int[] {0,1}, "proje", "codproje"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((double)args[0])-((double)args[1]);
			});
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
			info.ChildTable[0]= new ChildRelation("expen", new String[] {"codproje"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("agreg", new String[] {"codproje"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("year1", new Relation("GQT", "gqtproje", "proje", "codproje", "codyear", "GQT", "gqtyear", "year1", "codyear", "codyear"));
			info.ParentTables.Add("_replicRel_codyear", new Relation("GQT", "gqtproje", "proje", "codproje", "codyear", "GQT", "gqtyear", "year", "codyear", "codyear"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("year1","year1");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.CheckTableFields = new string[] {
			 "primeiro","before","followin","ultimo"
			};

			info.ReplicaFields = new string[] {
			 "year"
			};

			info.InternalOperationFields = new string[] {
			 "saldo1","saldo2"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAproje()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtproje";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codproje";
			info.HumanKeyName="projecto,".TrimEnd(',');
			info.Alias="proje";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Project";
			info.AreaPluralDesignation="Projects";
			info.DescriptionCav="PROJECT37121";

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
		public static FieldRef FldCodproje { get { return m_fldCodproje; } }
		private static FieldRef m_fldCodproje = new FieldRef("proje", "codproje");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodproje
		{
			get { return (string)returnValueField(FldCodproje); }
			set { insertNameValueField(FldCodproje, value); }
		}


		/// <summary>Field : "Project" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldProjecto { get { return m_fldProjecto; } }
		private static FieldRef m_fldProjecto = new FieldRef("proje", "projecto");

		/// <summary>Field : "Project" Tipo: "C" Formula:  ""</summary>
		public string ValProjecto
		{
			get { return (string)returnValueField(FldProjecto); }
			set { insertNameValueField(FldProjecto, value); }
		}


		/// <summary>Field : ">REFERENCE YEAR" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodyear { get { return m_fldCodyear; } }
		private static FieldRef m_fldCodyear = new FieldRef("proje", "codyear");

		/// <summary>Field : ">REFERENCE YEAR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodyear
		{
			get { return (string)returnValueField(FldCodyear); }
			set { insertNameValueField(FldCodyear, value); }
		}


		/// <summary>Field : "Year" Tipo: "C" Formula: ++ "[YEAR1->YEAR]"</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("proje", "year");

		/// <summary>Field : "Year" Tipo: "C" Formula: ++ "[YEAR1->YEAR]"</summary>
		public string ValYear
		{
			get { return (string)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}


		/// <summary>Field : "First" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		public static FieldRef FldPrimeiro { get { return m_fldPrimeiro; } }
		private static FieldRef m_fldPrimeiro = new FieldRef("proje", "primeiro");

		/// <summary>Field : "First" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		public double ValPrimeiro
		{
			get { return (double)returnValueField(FldPrimeiro); }
			set { insertNameValueField(FldPrimeiro, value); }
		}


		/// <summary>Field : "Before" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		public static FieldRef FldBefore { get { return m_fldBefore; } }
		private static FieldRef m_fldBefore = new FieldRef("proje", "before");

		/// <summary>Field : "Before" Tipo: "$D" Formula: CT "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		public double ValBefore
		{
			get { return (double)returnValueField(FldBefore); }
			set { insertNameValueField(FldBefore, value); }
		}


		/// <summary>Field : "Following" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		public static FieldRef FldFollowin { get { return m_fldFollowin; } }
		private static FieldRef m_fldFollowin = new FieldRef("proje", "followin");

		/// <summary>Field : "Following" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](ASC)"</summary>
		public double ValFollowin
		{
			get { return (double)returnValueField(FldFollowin); }
			set { insertNameValueField(FldFollowin, value); }
		}


		/// <summary>Field : "Last" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		public static FieldRef FldUltimo { get { return m_fldUltimo; } }
		private static FieldRef m_fldUltimo = new FieldRef("proje", "ultimo");

		/// <summary>Field : "Last" Tipo: "$D" Formula: CS "AGREG[PROJE->YEAR][AGREG->YEARNUMB][AGREG->VALUE][PROJE->CODPROJE][AGREG->CODPROJE](DESC)"</summary>
		public double ValUltimo
		{
			get { return (double)returnValueField(FldUltimo); }
			set { insertNameValueField(FldUltimo, value); }
		}


		/// <summary>Field : "Next - Previous =" Tipo: "$D" Formula: + "[PROJE->FOLLOWIN]-[PROJE->BEFORE]"</summary>
		public static FieldRef FldSaldo1 { get { return m_fldSaldo1; } }
		private static FieldRef m_fldSaldo1 = new FieldRef("proje", "saldo1");

		/// <summary>Field : "Next - Previous =" Tipo: "$D" Formula: + "[PROJE->FOLLOWIN]-[PROJE->BEFORE]"</summary>
		public double ValSaldo1
		{
			get { return (double)returnValueField(FldSaldo1); }
			set { insertNameValueField(FldSaldo1, value); }
		}


		/// <summary>Field : "Last - First =" Tipo: "$D" Formula: + "[PROJE->ULTIMO]-[PROJE->PRIMEIRO]"</summary>
		public static FieldRef FldSaldo2 { get { return m_fldSaldo2; } }
		private static FieldRef m_fldSaldo2 = new FieldRef("proje", "saldo2");

		/// <summary>Field : "Last - First =" Tipo: "$D" Formula: + "[PROJE->ULTIMO]-[PROJE->PRIMEIRO]"</summary>
		public double ValSaldo2
		{
			get { return (double)returnValueField(FldSaldo2); }
			set { insertNameValueField(FldSaldo2, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("proje", "zzstate");



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
        public static CSGenioAproje search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAproje area = new CSGenioAproje(user, user.CurrentModule);

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
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        [Obsolete("Use List<CSGenioAproje> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAproje> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAproje>(where, user, fields);
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
        public static List<CSGenioAproje> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAproje>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAproje> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAproje>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX PROJE]/

     

           

	}
}
