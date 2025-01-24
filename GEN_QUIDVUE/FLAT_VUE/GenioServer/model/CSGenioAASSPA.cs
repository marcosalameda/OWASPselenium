

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
	/// Asset parameter
	/// </summary>
	public class CSGenioAasspa : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAasspa(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR ASSPA]/
		}

		public CSGenioAasspa(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codasspa", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codasset", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codkinde", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codparam", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("datatype", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Data type";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATA_TYPE47159";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCdatatype";
            Qfield.ArrayClassName = "Datatype";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("decimalplaces", FieldType.NUMERO);
			Qfield.FieldDescription = "Decimal places";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 1;
			Qfield.CavDesignation = "DECIMAL_PLACES62575";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("text", FieldType.TEXTO);
			Qfield.FieldDescription = "Text";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TEXT04938";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("quantity", FieldType.NUMERO);
			Qfield.FieldDescription = "Quantity";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 4;
			Qfield.CavDesignation = "QUANTITY06415";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("date", FieldType.DATA);
			Qfield.FieldDescription = "Date";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE18475";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("toshow", FieldType.TEXTO);
			Qfield.FieldDescription = "To show";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TO_SHOW13268";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"datatype","text","datatype","quantity","datatype","date","date","date"}, new int[] {0,1,2,3,4,5,6,7}, "asspa", "codasspa"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 8, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((((string)args[0])=="T")?(((string)args[1])):(((((string)args[2])=="N")?(GlobalFunctions.NumericToString(((decimal)args[3]),0)):(((((string)args[4])=="D")?(GlobalFunctions.NumericToString(GlobalFunctions.Year(((DateTime)args[5])),0)+"-"+GlobalFunctions.RIGHT("00"+GlobalFunctions.NumericToString(GlobalFunctions.Month(((DateTime)args[6])),0),2)+"-"+GlobalFunctions.RIGHT("00"+GlobalFunctions.NumericToString(GlobalFunctions.Day(((DateTime)args[7])),0),2)):(""))))));
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
			info.ParentTables.Add("asset", new Relation("GQT", "gqtassetparameter", "asspa", "codasspa", "codasset", "GQT", "gqtasset", "asset", "codasset", "codasset"));
			info.ParentTables.Add("param", new Relation("GQT", "gqtassetparameter", "asspa", "codasspa", "codparam", "GQT", "gqtparameter", "param", "codparam", "codparam"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("param","param");
			info.Pathways.Add("asset","asset");
			info.Pathways.Add("kinde","param");
			info.Pathways.Add("manuf","asset");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "toshow"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAasspa()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtassetparameter";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codasspa";
			info.HumanKeyName="text,".TrimEnd(',');
			info.Alias="asspa";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Asset parameter";
			info.AreaPluralDesignation="Asset parameters";
			info.DescriptionCav="ASSET_PARAMETER22072";

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
		public static FieldRef FldCodasspa { get { return m_fldCodasspa; } }
		private static FieldRef m_fldCodasspa = new FieldRef("asspa", "codasspa");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodasspa
		{
			get { return (string)returnValueField(FldCodasspa); }
			set { insertNameValueField(FldCodasspa, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodasset { get { return m_fldCodasset; } }
		private static FieldRef m_fldCodasset = new FieldRef("asspa", "codasset");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset
		{
			get { return (string)returnValueField(FldCodasset); }
			set { insertNameValueField(FldCodasset, value); }
		}

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodkinde { get { return m_fldCodkinde; } }
		private static FieldRef m_fldCodkinde = new FieldRef("asspa", "codkinde");

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodkinde
		{
			get { return (string)returnValueField(FldCodkinde); }
			set { insertNameValueField(FldCodkinde, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodparam { get { return m_fldCodparam; } }
		private static FieldRef m_fldCodparam = new FieldRef("asspa", "codparam");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodparam
		{
			get { return (string)returnValueField(FldCodparam); }
			set { insertNameValueField(FldCodparam, value); }
		}

		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldDatatype { get { return m_fldDatatype; } }
		private static FieldRef m_fldDatatype = new FieldRef("asspa", "datatype");

		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		public string ValDatatype
		{
			get { return (string)returnValueField(FldDatatype); }
			set { insertNameValueField(FldDatatype, value); }
		}

		/// <summary>Field : "Decimal places" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldDecimalplaces { get { return m_fldDecimalplaces; } }
		private static FieldRef m_fldDecimalplaces = new FieldRef("asspa", "decimalplaces");

		/// <summary>Field : "Decimal places" Tipo: "N" Formula:  ""</summary>
		public decimal ValDecimalplaces
		{
			get { return (decimal)returnValueField(FldDecimalplaces); }
			set { insertNameValueField(FldDecimalplaces, value); }
		}

		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldText { get { return m_fldText; } }
		private static FieldRef m_fldText = new FieldRef("asspa", "text");

		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		public string ValText
		{
			get { return (string)returnValueField(FldText); }
			set { insertNameValueField(FldText, value); }
		}

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantity { get { return m_fldQuantity; } }
		private static FieldRef m_fldQuantity = new FieldRef("asspa", "quantity");

		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantity
		{
			get { return (decimal)returnValueField(FldQuantity); }
			set { insertNameValueField(FldQuantity, value); }
		}

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("asspa", "date");

		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "To show" Tipo: "C" Formula: + "iif([ASSPA->DATATYPE]=="T",[ASSPA->TEXT],iif([ASSPA->DATATYPE]=="N",NumericToString([ASSPA->QUANTITY],0),iif([ASSPA->DATATYPE]=="D",NumericToString(Year([ASSPA->DATE]),0)+"-"+RIGHT("00"+NumericToString(Month([ASSPA->DATE]),0),2)+"-"+RIGHT("00"+NumericToString(Day([ASSPA->DATE]),0),2),"") ) )"</summary>
		public static FieldRef FldToshow { get { return m_fldToshow; } }
		private static FieldRef m_fldToshow = new FieldRef("asspa", "toshow");

		/// <summary>Field : "To show" Tipo: "C" Formula: + "iif([ASSPA->DATATYPE]=="T",[ASSPA->TEXT],iif([ASSPA->DATATYPE]=="N",NumericToString([ASSPA->QUANTITY],0),iif([ASSPA->DATATYPE]=="D",NumericToString(Year([ASSPA->DATE]),0)+"-"+RIGHT("00"+NumericToString(Month([ASSPA->DATE]),0),2)+"-"+RIGHT("00"+NumericToString(Day([ASSPA->DATE]),0),2),"") ) )"</summary>
		public string ValToshow
		{
			get { return (string)returnValueField(FldToshow); }
			set { insertNameValueField(FldToshow, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("asspa", "zzstate");



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
        public static CSGenioAasspa search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAasspa area = new CSGenioAasspa(user, user.CurrentModule);

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
        public static List<CSGenioAasspa> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAasspa>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAasspa> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAasspa>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX ASSPA]/

     

           

	}
}
