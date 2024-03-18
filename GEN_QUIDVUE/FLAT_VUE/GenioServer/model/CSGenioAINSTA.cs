

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
	/// Installation
	/// </summary>
	public class CSGenioAinsta : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAinsta(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR INSTA]/
		}

		public CSGenioAinsta(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codinsta", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codtpequ", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">TYPE OF EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_TYPE_OF_EQUIPMENT35057";

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
			Qfield = new Field("designat", FieldType.TEXTO);
			Qfield.FieldDescription = "Scheduling";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "SCHEDULING24801";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtiniage", FieldType.DATAHORA);
			Qfield.FieldDescription = "Beginning";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BEGINNING18124";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtfimage", FieldType.DATAHORA);
			Qfield.FieldDescription = "End";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "END47577";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 3;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("allday", FieldType.LOGICO);
			Qfield.FieldDescription = "All day";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALL_DAY18496";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("since", FieldType.DATAHORA);
			Qfield.FieldDescription = "Since";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "SINCE47259";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("until", FieldType.DATAHORA);
			Qfield.FieldDescription = "Until";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "UNTIL39173";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("hours", FieldType.NUMERO);
			Qfield.FieldDescription = "Qtd hours";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "QTD_HOURS28684";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"since","until","since","until"}, new int[] {0,1,2,3}, "insta", "codinsta"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 4, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((GlobalFunctions.emptyD(((DateTime)args[0]))==1||GlobalFunctions.emptyD(((DateTime)args[1]))==1)?(0):(GlobalFunctions.Diferenca_entre_Datas(((DateTime)args[2]),((DateTime)args[3]),"H")));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("precohor", FieldType.VALOR);
			Qfield.FieldDescription = "Hourly price";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "HOURLY_PRICE48005";

			Qfield.Dupmsg = "";
			Qfield.Formula = new QueryTableFormula("GQT", "gqttabpr", "since", "since", "precohor", SortOrder.Descending, LookupFormulaType.Previous, "codtpequ", "codtpeq1");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("value", FieldType.VALOR);
			Qfield.FieldDescription = "Value";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "VALUE10285";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"hours","precohor"}, new int[] {0,1}, "insta", "codinsta"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((double)args[0])*((double)args[1]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("coordgeo", FieldType.GEOGRAPHY);
			Qfield.FieldDescription = "Geographic coordinate";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "GEOGRAPHIC_COORDINAT21394";

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
			info.ParentTables.Add("equip", new Relation("GQT", "gqtinsta", "insta", "codinsta", "codequip", "GQT", "gqtequip", "equip", "codequip", "codequip"));
			info.ParentTables.Add("tpequ", new Relation("GQT", "gqtinsta", "insta", "codinsta", "codtpequ", "GQT", "gqttpequ", "tpequ", "codtpequ", "codtpequ"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(12);
			info.Pathways.Add("tpequ","tpequ");
			info.Pathways.Add("equip","equip");
			info.Pathways.Add("famil","tpequ");
			info.Pathways.Add("decom","equip");
			info.Pathways.Add("wareh","equip");
			info.Pathways.Add("cmpny","equip");
			info.Pathways.Add("item","equip");
			info.Pathways.Add("pess1","equip");
			info.Pathways.Add("cntry","equip");
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
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("insta", "equip", "valortot", "value", '+', true));



			info.CheckTableFields = new string[] {
			 "precohor"
			};

			info.InternalOperationFields = new string[] {
			 "hours","value"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAinsta()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtinsta";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codinsta";
			info.HumanKeyName="since,".TrimEnd(',');
			info.Alias="insta";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Installation";
			info.AreaPluralDesignation="Facilities";
			info.DescriptionCav="INSTALLATION12952";

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
		public static FieldRef FldCodinsta { get { return m_fldCodinsta; } }
		private static FieldRef m_fldCodinsta = new FieldRef("insta", "codinsta");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodinsta
		{
			get { return (string)returnValueField(FldCodinsta); }
			set { insertNameValueField(FldCodinsta, value); }
		}


		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("insta", "codtpequ");

		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}


		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodequip { get { return m_fldCodequip; } }
		private static FieldRef m_fldCodequip = new FieldRef("insta", "codequip");

		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip
		{
			get { return (string)returnValueField(FldCodequip); }
			set { insertNameValueField(FldCodequip, value); }
		}


		/// <summary>Field : "Scheduling" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("insta", "designat");

		/// <summary>Field : "Scheduling" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}


		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtiniage { get { return m_fldDtiniage; } }
		private static FieldRef m_fldDtiniage = new FieldRef("insta", "dtiniage");

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtiniage
		{
			get { return (DateTime)returnValueField(FldDtiniage); }
			set { insertNameValueField(FldDtiniage, value); }
		}


		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldDtfimage { get { return m_fldDtfimage; } }
		private static FieldRef m_fldDtfimage = new FieldRef("insta", "dtfimage");

		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValDtfimage
		{
			get { return (DateTime)returnValueField(FldDtfimage); }
			set { insertNameValueField(FldDtfimage, value); }
		}


		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("insta", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}


		/// <summary>Field : "All day" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldAllday { get { return m_fldAllday; } }
		private static FieldRef m_fldAllday = new FieldRef("insta", "allday");

		/// <summary>Field : "All day" Tipo: "L" Formula:  ""</summary>
		public int ValAllday
		{
			get { return (int)returnValueField(FldAllday); }
			set { insertNameValueField(FldAllday, value); }
		}


		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldSince { get { return m_fldSince; } }
		private static FieldRef m_fldSince = new FieldRef("insta", "since");

		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValSince
		{
			get { return (DateTime)returnValueField(FldSince); }
			set { insertNameValueField(FldSince, value); }
		}


		/// <summary>Field : "Until" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldUntil { get { return m_fldUntil; } }
		private static FieldRef m_fldUntil = new FieldRef("insta", "until");

		/// <summary>Field : "Until" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValUntil
		{
			get { return (DateTime)returnValueField(FldUntil); }
			set { insertNameValueField(FldUntil, value); }
		}


		/// <summary>Field : "Qtd hours" Tipo: "N" Formula: + "iif(emptyD([INSTA->SINCE])==1 || emptyD([INSTA->UNTIL])==1,0,Diferenca_entre_Datas([INSTA->SINCE],[INSTA->UNTIL],"H"))"</summary>
		public static FieldRef FldHours { get { return m_fldHours; } }
		private static FieldRef m_fldHours = new FieldRef("insta", "hours");

		/// <summary>Field : "Qtd hours" Tipo: "N" Formula: + "iif(emptyD([INSTA->SINCE])==1 || emptyD([INSTA->UNTIL])==1,0,Diferenca_entre_Datas([INSTA->SINCE],[INSTA->UNTIL],"H"))"</summary>
		public double ValHours
		{
			get { return (double)returnValueField(FldHours); }
			set { insertNameValueField(FldHours, value); }
		}


		/// <summary>Field : "Hourly price" Tipo: "$D" Formula: CT "TABPR[INSTA->SINCE][TABPR->SINCE][TABPR->PRECOHOR][INSTA->CODTPEQU][TABPR->CODTPEQ1](DESC)"</summary>
		public static FieldRef FldPrecohor { get { return m_fldPrecohor; } }
		private static FieldRef m_fldPrecohor = new FieldRef("insta", "precohor");

		/// <summary>Field : "Hourly price" Tipo: "$D" Formula: CT "TABPR[INSTA->SINCE][TABPR->SINCE][TABPR->PRECOHOR][INSTA->CODTPEQU][TABPR->CODTPEQ1](DESC)"</summary>
		public double ValPrecohor
		{
			get { return (double)returnValueField(FldPrecohor); }
			set { insertNameValueField(FldPrecohor, value); }
		}


		/// <summary>Field : "Value" Tipo: "$D" Formula: + "[INSTA->HOURS]*[INSTA->PRECOHOR]"</summary>
		public static FieldRef FldValue { get { return m_fldValue; } }
		private static FieldRef m_fldValue = new FieldRef("insta", "value");

		/// <summary>Field : "Value" Tipo: "$D" Formula: + "[INSTA->HOURS]*[INSTA->PRECOHOR]"</summary>
		public double ValValue
		{
			get { return (double)returnValueField(FldValue); }
			set { insertNameValueField(FldValue, value); }
		}


		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		public static FieldRef FldCoordgeo { get { return m_fldCoordgeo; } }
		private static FieldRef m_fldCoordgeo = new FieldRef("insta", "coordgeo");

		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		public string ValCoordgeo
		{
			get { return (string)returnValueField(FldCoordgeo); }
			set { insertNameValueField(FldCoordgeo, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("insta", "zzstate");



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
        public static CSGenioAinsta search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAinsta area = new CSGenioAinsta(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAinsta> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAinsta> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAinsta>(where, user, fields);
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
        public static List<CSGenioAinsta> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAinsta>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAinsta> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAinsta>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX INSTA]/

     

               

	}
}
