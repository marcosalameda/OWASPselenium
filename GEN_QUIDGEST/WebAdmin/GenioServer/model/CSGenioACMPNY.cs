

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
	/// Company
	/// </summary>
	public class CSGenioAcmpny : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAcmpny(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR CMPNY]/
		}

		public CSGenioAcmpny(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codempre", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "Companies";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "COMPANIES04875";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("designat", FieldType.TEXTO);
			Qfield.FieldDescription = "Designation";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "DESIGNATION35876";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("acronym", FieldType.TEXTO);
			Qfield.FieldDescription = "Acronym";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ACRONYM00872";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("nif", FieldType.TEXTO);
			Qfield.FieldDescription = "Tax identification";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TAX_IDENTIFICATION51190";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("telephon", FieldType.TEXTO);
			Qfield.FieldDescription = "Phone";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "PHONE56703";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("logo", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Logo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "LOGO62483";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcntry", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("qtdpesso", FieldType.NUMERO);
			Qfield.FieldDescription = "Number of people";
			Qfield.FieldSize =  10;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NUMBER_OF_PEOPLE08859";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("headloc", FieldType.GEOGRAPHY);
			Qfield.FieldDescription = "Headquarter location";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "HEADQUARTER_LOCATION30734";

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
			info.ChildTable = new ChildRelation[4];
			info.ChildTable[0]= new ChildRelation("repar", new String[] {"codempre"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("pesso", new String[] {"codempre"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("indoc", new String[] {"codempre"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("equip", new String[] {"codempre"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("cntry", new Relation("GQT", "gqtcmpny", "cmpny", "codempre", "codcntry", "GQT", "gqtcntry", "cntry", "codcntry", "codcntry"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("cntry","cntry");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------




			info.RelatedSumFields = new string[] {
			 "qtdpesso"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAcmpny()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtcmpny";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codempre";
			info.HumanKeyName="designat,".TrimEnd(',');
			info.Alias="cmpny";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Company";
			info.AreaPluralDesignation="Companies";
			info.DescriptionCav="COMPANY52963";

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

		/// <summary>Field : "Companies" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodempre { get { return m_fldCodempre; } }
		private static FieldRef m_fldCodempre = new FieldRef("cmpny", "codempre");

		/// <summary>Field : "Companies" Tipo: "+" Formula:  ""</summary>
		public string ValCodempre
		{
			get { return (string)returnValueField(FldCodempre); }
			set { insertNameValueField(FldCodempre, value); }
		}


		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("cmpny", "designat");

		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}


		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAcronym { get { return m_fldAcronym; } }
		private static FieldRef m_fldAcronym = new FieldRef("cmpny", "acronym");

		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValAcronym
		{
			get { return (string)returnValueField(FldAcronym); }
			set { insertNameValueField(FldAcronym, value); }
		}


		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNif { get { return m_fldNif; } }
		private static FieldRef m_fldNif = new FieldRef("cmpny", "nif");

		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		public string ValNif
		{
			get { return (string)returnValueField(FldNif); }
			set { insertNameValueField(FldNif, value); }
		}


		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTelephon { get { return m_fldTelephon; } }
		private static FieldRef m_fldTelephon = new FieldRef("cmpny", "telephon");

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon
		{
			get { return (string)returnValueField(FldTelephon); }
			set { insertNameValueField(FldTelephon, value); }
		}


		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("cmpny", "email");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}


		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldLogo { get { return m_fldLogo; } }
		private static FieldRef m_fldLogo = new FieldRef("cmpny", "logo");

		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValLogo
		{
			get { return (byte[])returnValueField(FldLogo); }
			set { insertNameValueField(FldLogo, value); }
		}


		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("cmpny", "codcntry");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}


		/// <summary>Field : "Number of people" Tipo: "N" Formula: SR "[PESSO->1]"</summary>
		public static FieldRef FldQtdpesso { get { return m_fldQtdpesso; } }
		private static FieldRef m_fldQtdpesso = new FieldRef("cmpny", "qtdpesso");

		/// <summary>Field : "Number of people" Tipo: "N" Formula: SR "[PESSO->1]"</summary>
		public double ValQtdpesso
		{
			get { return (double)returnValueField(FldQtdpesso); }
			set { insertNameValueField(FldQtdpesso, value); }
		}


		/// <summary>Field : "Headquarter location" Tipo: "GG" Formula:  ""</summary>
		public static FieldRef FldHeadloc { get { return m_fldHeadloc; } }
		private static FieldRef m_fldHeadloc = new FieldRef("cmpny", "headloc");

		/// <summary>Field : "Headquarter location" Tipo: "GG" Formula:  ""</summary>
		public string ValHeadloc
		{
			get { return (string)returnValueField(FldHeadloc); }
			set { insertNameValueField(FldHeadloc, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("cmpny", "zzstate");



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
        public static CSGenioAcmpny search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAcmpny area = new CSGenioAcmpny(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAcmpny> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAcmpny> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAcmpny>(where, user, fields);
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
        public static List<CSGenioAcmpny> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAcmpny>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAcmpny> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAcmpny>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX CMPNY]/

     

           

	}
}
