

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
	/// Drive
	/// </summary>
	public class CSGenioAmovim : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAmovim(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR MOVIM]/
		}

		public CSGenioAmovim(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codmovim", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dhmudanc", FieldType.DATAHORA);
			Qfield.FieldDescription = "Change";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "CHANGE36355";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getNow);
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
			Qfield = new Field("codrooms", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">ROOM";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_ROOM54790";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("observat", FieldType.MEMO);
			Qfield.FieldDescription = "Observation";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "OBSERVATION37880";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("roomnr", FieldType.TEXTO);
			Qfield.FieldDescription = "N.R. Room";
			Qfield.FieldSize =  65;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "N_R__ROOM43805";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"roomnr","designat"}, new int[] {0,1}, "rooms", "codrooms"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((string)args[0])+" "+((string)args[1]);
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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("equip", new Relation("GQT", "gqtmovim", "movim", "codmovim", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
			info.ParentTables.Add("rooms", new Relation("GQT", "gqtmovim", "movim", "codmovim", "codrooms", "GQT", "gqtrooms", "rooms", "codrooms", "codrooms"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(14);
			info.Pathways.Add("rooms","rooms");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("room1","equip");
			info.Pathways.Add("cmpny","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("tpequ","equip");
			info.Pathways.Add("pess1","equip");
			info.Pathways.Add("cntry","equip");
			info.Pathways.Add("gitem","equip");
			info.Pathways.Add("famil","equip");
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
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("movim", "equip", "qtdmovim", "1", '+', false));

			info.ArgsListAggregate = new List<ListAggregateArgument>();
			info.ArgsListAggregate.Add(new ListAggregateArgument("movim", "equip", "moviment", "roomnr","dhmudanc","; "));


			//Actualiza as seguintes rotinas de ultimo Qvalue:
			info.LastValueArgs = new List<LastValueArgument>();
			info.LastValueArgs.Add( new LastValueArgument("equip",
				new string [] {"codrooms"},
				new string [] {"codrooms"},
				"dhmudanc",
				null,

	"today", true));


			info.InternalOperationFields = new string[] {
			 "roomnr"
			};

			info.DefaultValues = new string[] {
			 "dhmudanc"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAmovim()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtmovim";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codmovim";
			info.HumanKeyName="dhmudanc,".TrimEnd(',');
			info.Alias="movim";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Drive";
			info.AreaPluralDesignation="Drives";
			info.DescriptionCav="DRIVE03517";

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
		public static FieldRef FldCodmovim { get { return m_fldCodmovim; } }
		private static FieldRef m_fldCodmovim = new FieldRef("movim", "codmovim");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmovim
		{
			get { return (string)returnValueField(FldCodmovim); }
			set { insertNameValueField(FldCodmovim, value); }
		}

		/// <summary>Field : "Change" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDhmudanc { get { return m_fldDhmudanc; } }
		private static FieldRef m_fldDhmudanc = new FieldRef("movim", "dhmudanc");

		/// <summary>Field : "Change" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDhmudanc
		{
			get { return (DateTime)returnValueField(FldDhmudanc); }
			set { insertNameValueField(FldDhmudanc, value); }
		}

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("movim", "codequip");

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}

		/// <summary>Field : ">ROOM" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodrooms { get { return m_fldCodrooms; } }
		private static FieldRef m_fldCodrooms = new FieldRef("movim", "codrooms");

		/// <summary>Field : ">ROOM" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrooms
		{
			get { return (string)returnValueField(FldCodrooms); }
			set { insertNameValueField(FldCodrooms, value); }
		}

		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldObservat { get { return m_fldObservat; } }
		private static FieldRef m_fldObservat = new FieldRef("movim", "observat");

		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		public string ValObservat
		{
			get { return (string)returnValueField(FldObservat); }
			set { insertNameValueField(FldObservat, value); }
		}

		/// <summary>Field : "N.R. Room" Tipo: "C" Formula: + "[ROOMS->ROOMNR]+" "+[ROOMS->DESIGNAT]"</summary>
		public static FieldRef FldRoomnr { get { return m_fldRoomnr; } }
		private static FieldRef m_fldRoomnr = new FieldRef("movim", "roomnr");

		/// <summary>Field : "N.R. Room" Tipo: "C" Formula: + "[ROOMS->ROOMNR]+" "+[ROOMS->DESIGNAT]"</summary>
		public string ValRoomnr
		{
			get { return (string)returnValueField(FldRoomnr); }
			set { insertNameValueField(FldRoomnr, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("movim", "zzstate");



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
        public static CSGenioAmovim search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAmovim area = new CSGenioAmovim(user, user.CurrentModule);

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
        public static List<CSGenioAmovim> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAmovim>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAmovim> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAmovim>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX MOVIM]/

     

       

	}
}
