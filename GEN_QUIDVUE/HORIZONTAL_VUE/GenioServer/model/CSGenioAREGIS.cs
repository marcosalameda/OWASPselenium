

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
	/// Registration
	/// </summary>
	public class CSGenioAregis : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAregis(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR REGIS]/
		}

		public CSGenioAregis(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codregis", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("name", FieldType.TEXTO);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NAME31974";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("nif", FieldType.TEXTO);
			Qfield.FieldDescription = "Tax identification no.";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TAX_IDENTIFICATION_N63094";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email1", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email2", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("telephon", FieldType.TEXTO);
			Qfield.FieldDescription = "Phone";
			Qfield.FieldSize =  15;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "PHONE56703";

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
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
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

			// [REGIS->EMAIL1]==[REGIS->EMAIL2]
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"email1","email2"},new int[] {0,1},"regis","codregis"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])==((string)args[1]);
			});
			writeCondition.ErrorWarning = "Please confirm that you have entered the Email correctly.";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["email2"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAregis()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtregis";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codregis";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="regis";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Registration";
			info.AreaPluralDesignation="Records";
			info.DescriptionCav="REGISTRATION03584";

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
		public static FieldRef FldCodregis { get { return m_fldCodregis; } }
		private static FieldRef m_fldCodregis = new FieldRef("regis", "codregis");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodregis
		{
			get { return (string)returnValueField(FldCodregis); }
			set { insertNameValueField(FldCodregis, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("regis", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Tax identification no." Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNif { get { return m_fldNif; } }
		private static FieldRef m_fldNif = new FieldRef("regis", "nif");

		/// <summary>Field : "Tax identification no." Tipo: "C" Formula:  ""</summary>
		public string ValNif
		{
			get { return (string)returnValueField(FldNif); }
			set { insertNameValueField(FldNif, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail1 { get { return m_fldEmail1; } }
		private static FieldRef m_fldEmail1 = new FieldRef("regis", "email1");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail1
		{
			get { return (string)returnValueField(FldEmail1); }
			set { insertNameValueField(FldEmail1, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail2 { get { return m_fldEmail2; } }
		private static FieldRef m_fldEmail2 = new FieldRef("regis", "email2");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail2
		{
			get { return (string)returnValueField(FldEmail2); }
			set { insertNameValueField(FldEmail2, value); }
		}

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTelephon { get { return m_fldTelephon; } }
		private static FieldRef m_fldTelephon = new FieldRef("regis", "telephon");

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon
		{
			get { return (string)returnValueField(FldTelephon); }
			set { insertNameValueField(FldTelephon, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("regis", "zzstate");



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
        public static CSGenioAregis search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAregis area = new CSGenioAregis(user, user.CurrentModule);

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
        public static List<CSGenioAregis> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAregis>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAregis> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAregis>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX REGIS]/

     

       

	}
}
