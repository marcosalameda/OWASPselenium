
 
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
	/// Operações
	/// </summary>
	public class CSGenioAoperacoes : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAoperacoes(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR OPERACOES]/
		}

		public CSGenioAoperacoes(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codoperacoes", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codentidade", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Entidade";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ENTIDADE36471";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operacao_aa", FieldType.TEXT);
			Qfield.FieldDescription = "Operação AA";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OPERACAO_AA07938";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pop_aa", FieldType.NUMERIC);
			Qfield.FieldDescription = "Pop abrangida";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "POP_ABRANGIDA36477";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operacao_ar", FieldType.TEXT);
			Qfield.FieldDescription = "Operação AR";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OPERACAO_AR11207";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pop_ar", FieldType.NUMERIC);
			Qfield.FieldDescription = "Pop abrangida";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "POP_ABRANGIDA36477";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operacao_ru", FieldType.TEXT);
			Qfield.FieldDescription = "Operação RU";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OPERACAO_RU18117";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pop_ru", FieldType.NUMERIC);
			Qfield.FieldDescription = "Pop abrangida";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "POP_ABRANGIDA36477";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sobreposicao_aa", FieldType.LOGIC);
			Qfield.FieldDescription = "Sobreposição AA";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOBREPOSICAO_AA55921";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sobreposicao_ar", FieldType.LOGIC);
			Qfield.FieldDescription = "Sobreposição AR";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOBREPOSICAO_AR58360";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sobreposicao_ru", FieldType.LOGIC);
			Qfield.FieldDescription = "Sobreposição RU";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOBREPOSICAO_RU06294";

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
			info.ParentTables.Add("entidade", new Relation("GQT", "gqtoperacoes", "operacoes", "codoperacoes", "codentidade", "GQT", "gqtentidade", "entidade", "codentidade", "codentidade"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("entidade","entidade");
			info.Pathways.Add("concelho","entidade");
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
		/// static CSGenioAoperacoes()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtoperacoes";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codoperacoes";
			info.HumanKeyName="";
			info.Alias="operacoes";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Operações";
			info.AreaPluralDesignation="Operation";
			info.DescriptionCav="OPERACOES07850";

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
		public static FieldRef FldCodoperacoes { get { return m_fldCodoperacoes; } }
		private static FieldRef m_fldCodoperacoes = new FieldRef("operacoes", "codoperacoes");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodoperacoes
		{
			get { return (string)returnValueField(FldCodoperacoes); }
			set { insertNameValueField(FldCodoperacoes, value); }
		}

		/// <summary>Field : "Entidade" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodentidade { get { return m_fldCodentidade; } }
		private static FieldRef m_fldCodentidade = new FieldRef("operacoes", "codentidade");

		/// <summary>Field : "Entidade" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentidade
		{
			get { return (string)returnValueField(FldCodentidade); }
			set { insertNameValueField(FldCodentidade, value); }
		}

		/// <summary>Field : "Operação AA" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldOperacao_aa { get { return m_fldOperacao_aa; } }
		private static FieldRef m_fldOperacao_aa = new FieldRef("operacoes", "operacao_aa");

		/// <summary>Field : "Operação AA" Tipo: "C" Formula:  ""</summary>
		public string ValOperacao_aa
		{
			get { return (string)returnValueField(FldOperacao_aa); }
			set { insertNameValueField(FldOperacao_aa, value); }
		}

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPop_aa { get { return m_fldPop_aa; } }
		private static FieldRef m_fldPop_aa = new FieldRef("operacoes", "pop_aa");

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public decimal ValPop_aa
		{
			get { return (decimal)returnValueField(FldPop_aa); }
			set { insertNameValueField(FldPop_aa, value); }
		}

		/// <summary>Field : "Operação AR" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldOperacao_ar { get { return m_fldOperacao_ar; } }
		private static FieldRef m_fldOperacao_ar = new FieldRef("operacoes", "operacao_ar");

		/// <summary>Field : "Operação AR" Tipo: "C" Formula:  ""</summary>
		public string ValOperacao_ar
		{
			get { return (string)returnValueField(FldOperacao_ar); }
			set { insertNameValueField(FldOperacao_ar, value); }
		}

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPop_ar { get { return m_fldPop_ar; } }
		private static FieldRef m_fldPop_ar = new FieldRef("operacoes", "pop_ar");

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public decimal ValPop_ar
		{
			get { return (decimal)returnValueField(FldPop_ar); }
			set { insertNameValueField(FldPop_ar, value); }
		}

		/// <summary>Field : "Operação RU" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldOperacao_ru { get { return m_fldOperacao_ru; } }
		private static FieldRef m_fldOperacao_ru = new FieldRef("operacoes", "operacao_ru");

		/// <summary>Field : "Operação RU" Tipo: "C" Formula:  ""</summary>
		public string ValOperacao_ru
		{
			get { return (string)returnValueField(FldOperacao_ru); }
			set { insertNameValueField(FldOperacao_ru, value); }
		}

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPop_ru { get { return m_fldPop_ru; } }
		private static FieldRef m_fldPop_ru = new FieldRef("operacoes", "pop_ru");

		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		public decimal ValPop_ru
		{
			get { return (decimal)returnValueField(FldPop_ru); }
			set { insertNameValueField(FldPop_ru, value); }
		}

		/// <summary>Field : "Sobreposição AA" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSobreposicao_aa { get { return m_fldSobreposicao_aa; } }
		private static FieldRef m_fldSobreposicao_aa = new FieldRef("operacoes", "sobreposicao_aa");

		/// <summary>Field : "Sobreposição AA" Tipo: "L" Formula:  ""</summary>
		public int ValSobreposicao_aa
		{
			get { return (int)returnValueField(FldSobreposicao_aa); }
			set { insertNameValueField(FldSobreposicao_aa, value); }
		}

		/// <summary>Field : "Sobreposição AR" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSobreposicao_ar { get { return m_fldSobreposicao_ar; } }
		private static FieldRef m_fldSobreposicao_ar = new FieldRef("operacoes", "sobreposicao_ar");

		/// <summary>Field : "Sobreposição AR" Tipo: "L" Formula:  ""</summary>
		public int ValSobreposicao_ar
		{
			get { return (int)returnValueField(FldSobreposicao_ar); }
			set { insertNameValueField(FldSobreposicao_ar, value); }
		}

		/// <summary>Field : "Sobreposição RU" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldSobreposicao_ru { get { return m_fldSobreposicao_ru; } }
		private static FieldRef m_fldSobreposicao_ru = new FieldRef("operacoes", "sobreposicao_ru");

		/// <summary>Field : "Sobreposição RU" Tipo: "L" Formula:  ""</summary>
		public int ValSobreposicao_ru
		{
			get { return (int)returnValueField(FldSobreposicao_ru); }
			set { insertNameValueField(FldSobreposicao_ru, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("operacoes", "zzstate");



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
        public static CSGenioAoperacoes search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAoperacoes area = new CSGenioAoperacoes(user, user.CurrentModule);

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
        public static List<CSGenioAoperacoes> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAoperacoes>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAoperacoes> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAoperacoes>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX OPERACOES]/

     
            

	}
}
