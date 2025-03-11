

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
	/// Repair
	/// </summary>
	public class CSGenioArepar : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioArepar(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR REPAR]/
		}

		public CSGenioArepar(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codrepar", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codequip", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_EQUIPMENT12605";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codempre", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">COMPANY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "nrrepara";
			Qfield.Formula = new ReplicaFormula("_replicRel_codequip", "codempre");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtrepara", FieldType.DATAHORA);
			Qfield.FieldDescription = "Fixed in";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "FIXED_IN00179";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("nrrepara", FieldType.NUMERO);
			Qfield.FieldDescription = "No rumour in the Company";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "NO_RUMOUR_IN_THE_COM15248";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codempre";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "nrrepara");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("tipoarea", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Technical area";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TECHNICAL_AREA50773";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCareatecn";
            Qfield.ArrayClassName = "Areatecn";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codespec", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">SPECIALTY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_SPECIALTY24336";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcateg", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">CATEGORy";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_CATEGORY37591";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpesso", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">REPAIRER";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_REPAIRER36801";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description of the repair";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "DESCRIPTION_OF_THE_R26085";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("hours", FieldType.NUMERO);
			Qfield.FieldDescription = "Spent on hours";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "SPENT_ON_HOURS19285";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("zzstate", FieldType.INTEIRO);
			Qfield.FieldDescription = "Estado da ficha";
			Qfield.Alias = info.Alias;
			info.RegisterFieldDB(Qfield);

			info.SolrList.Add("PREPAIRS");
			info.SolrList.Add("REPARACO");
			info.SolrList.Add("REPARASO");
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
			info.ParentTables.Add("cate1", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codcateg", "GQT", "gqtcategorias", "cate1", "codcateg", "codcateg"));
			info.ParentTables.Add("cmpny", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codempre", "GQT", "gqtcmpny", "cmpny", "codempre", "codempre"));
			info.ParentTables.Add("equip", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
			info.ParentTables.Add("pesso", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codpesso", "GQT", "gqtpessoas", "pesso", "codpesso", "codpesso"));
			info.ParentTables.Add("speci", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codespec", "GQT", "gqtspeci", "speci", "codespec", "codespec"));
			info.ParentTables.Add("_replicRel_codequip", new Relation("GQT", "gqtrepar", "repar", "codrepar", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(19);
			info.Pathways.Add("speci","speci");
			info.Pathways.Add("cate1","cate1");
			info.Pathways.Add("cmpny","cmpny");
			info.Pathways.Add("pesso","pesso");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("cntry","cmpny");
			info.Pathways.Add("categ","pesso");
			info.Pathways.Add("pais1","pesso");
			info.Pathways.Add("regi1","pesso");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("room1","equip");
			info.Pathways.Add("tpequ","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("pess1","equip");
			info.Pathways.Add("famil","equip");
			info.Pathways.Add("gitem","equip");
			info.Pathways.Add("stake","equip");
			info.Pathways.Add("cate2","equip");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.ReplicaFields = new string[] {
			 "codempre"
			};

			info.SequentialDefaultValues = new string[] {
			 "nrrepara"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioArepar()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtrepar";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codrepar";
			info.HumanKeyName="dtrepara,".TrimEnd(',');
			info.Alias="repar";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Repair";
			info.AreaPluralDesignation="Repairs";
			info.DescriptionCav="REPAIR34508";

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
		public static FieldRef FldCodrepar { get { return m_fldCodrepar; } }
		private static FieldRef m_fldCodrepar = new FieldRef("repar", "codrepar");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrepar
		{
			get { return (string)returnValueField(FldCodrepar); }
			set { insertNameValueField(FldCodrepar, value); }
		}

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("repar", "codequip");

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula: ++ "[EQUIP->CODEMPRE]"</summary>
		public static FieldRef FldCodempre { get { return m_fldCodempre; } }
		private static FieldRef m_fldCodempre = new FieldRef("repar", "codempre");

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula: ++ "[EQUIP->CODEMPRE]"</summary>
		public string ValCodempre
		{
			get { return (string)returnValueField(FldCodempre); }
			set { insertNameValueField(FldCodempre, value); }
		}

		/// <summary>Field : "Fixed in" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtrepara { get { return m_fldDtrepara; } }
		private static FieldRef m_fldDtrepara = new FieldRef("repar", "dtrepara");

		/// <summary>Field : "Fixed in" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtrepara
		{
			get { return (DateTime)returnValueField(FldDtrepara); }
			set { insertNameValueField(FldDtrepara, value); }
		}

		/// <summary>Field : "No rumour in the Company" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNrrepara { get { return m_fldNrrepara; } }
		private static FieldRef m_fldNrrepara = new FieldRef("repar", "nrrepara");

		/// <summary>Field : "No rumour in the Company" Tipo: "N" Formula:  ""</summary>
		public decimal ValNrrepara
		{
			get { return (decimal)returnValueField(FldNrrepara); }
			set { insertNameValueField(FldNrrepara, value); }
		}

		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldTipoarea { get { return m_fldTipoarea; } }
		private static FieldRef m_fldTipoarea = new FieldRef("repar", "tipoarea");

		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		public string ValTipoarea
		{
			get { return (string)returnValueField(FldTipoarea); }
			set { insertNameValueField(FldTipoarea, value); }
		}

		/// <summary>Field : ">SPECIALTY" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodespec { get { return m_fldCodespec; } }
		private static FieldRef m_fldCodespec = new FieldRef("repar", "codespec");

		/// <summary>Field : ">SPECIALTY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodespec
		{
			get { return (string)returnValueField(FldCodespec); }
			set { insertNameValueField(FldCodespec, value); }
		}

		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcateg { get { return m_fldCodcateg; } }
		private static FieldRef m_fldCodcateg = new FieldRef("repar", "codcateg");

		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcateg
		{
			get { return (string)returnValueField(FldCodcateg); }
			set { insertNameValueField(FldCodcateg, value); }
		}

		/// <summary>Field : ">REPAIRER" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("repar", "codpesso");

		/// <summary>Field : ">REPAIRER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}

		/// <summary>Field : "Description of the repair" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("repar", "descript");

		/// <summary>Field : "Description of the repair" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "Spent on hours" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldHours { get { return m_fldHours; } }
		private static FieldRef m_fldHours = new FieldRef("repar", "hours");

		/// <summary>Field : "Spent on hours" Tipo: "N" Formula:  ""</summary>
		public decimal ValHours
		{
			get { return (decimal)returnValueField(FldHours); }
			set { insertNameValueField(FldHours, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("repar", "zzstate");



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
        public static CSGenioArepar search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioArepar area = new CSGenioArepar(user, user.CurrentModule);

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
        public static List<CSGenioArepar> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioArepar>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioArepar> listing)
        {
			sp.searchListAdvancedWhere<CSGenioArepar>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX REPAR]/

     

            

	}
}
