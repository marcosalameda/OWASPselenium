

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
	/// Person
	/// </summary>
	public class CSGenioAperso : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAperso(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PERSO]/
		}

		public CSGenioAperso(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codperso", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXTO);
			Qfield.FieldDescription = "Person name";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PERSON_NAME40980";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "identifi", FieldType.TEXTO);
			Qfield.FieldDescription = "Identification number";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "IDENTIFICATION_NUMBE11999";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gender", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Gender";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GENDER44172";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCgender";
            Qfield.ArrayClassName = "Gender";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "photo", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXTO);
			Qfield.FieldDescription = "E-mail";
			Qfield.FieldSize =  254;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "E_MAIL42251";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "year", FieldType.NUMERO);
			Qfield.FieldDescription = "Year";
			Qfield.FieldSize =  4;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 4;
			Qfield.CavDesignation = "YEAR61794";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "month", FieldType.ARRAY_COD_NUMERICO);
			Qfield.FieldDescription = "Month";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MONTH46035";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNmonths";
            Qfield.ArrayClassName = "Months";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dob", FieldType.DATA);
			Qfield.FieldDescription = "Date of birth";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_OF_BIRTH63058";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tob", FieldType.TEMPO);
			Qfield.FieldDescription = "Time of birth";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TIME_OF_BIRTH04797";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatusr", FieldType.OPERCRIA);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_BY12292";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatdat", FieldType.DATACRIA);
			Qfield.FieldDescription = "Created on";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CREATED_ON00051";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "modifusr", FieldType.OPERMUDA);
			Qfield.FieldDescription = "Modified by";
			Qfield.FieldSize =  20;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MODIFIED_BY02094";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "modifdat", FieldType.DATAMUDA);
			Qfield.FieldDescription = "Modified on";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MODIFIED_ON31953";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEIRO);
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
			info.ChildTable = new ChildRelation[3];
			info.ChildTable[0]= new ChildRelation("dispa", new String[] {"codperso"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("users", new String[] {"codperso"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("messa", new String[] {"codperso"}, DeleteProc.NA);

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
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAperso()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtperson";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codperso";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="perso";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Person";
			info.AreaPluralDesignation="Persons";
			info.DescriptionCav="PERSON10446";

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
			info.StampFieldsIns = new string[] {
                "creatusr","creatdat"
			};

			info.StampFieldsAlt = new string[] {
                "modifusr","modifdat"
			};
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
		public static FieldRef FldCodperso { get { return m_fldCodperso; } }
		private static FieldRef m_fldCodperso = new FieldRef("perso", "codperso");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodperso
		{
			get { return (string)returnValueField(FldCodperso); }
			set { insertNameValueField(FldCodperso, value); }
		}

		/// <summary>Field : "Person name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("perso", "name");

		/// <summary>Field : "Person name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Identification number" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdentifi { get { return m_fldIdentifi; } }
		private static FieldRef m_fldIdentifi = new FieldRef("perso", "identifi");

		/// <summary>Field : "Identification number" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi
		{
			get { return (string)returnValueField(FldIdentifi); }
			set { insertNameValueField(FldIdentifi, value); }
		}

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGender { get { return m_fldGender; } }
		private static FieldRef m_fldGender = new FieldRef("perso", "gender");

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public string ValGender
		{
			get { return (string)returnValueField(FldGender); }
			set { insertNameValueField(FldGender, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("perso", "photo");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("perso", "email");

		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldYear { get { return m_fldYear; } }
		private static FieldRef m_fldYear = new FieldRef("perso", "year");

		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		public decimal ValYear
		{
			get { return (decimal)returnValueField(FldYear); }
			set { insertNameValueField(FldYear, value); }
		}

		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldMonth { get { return m_fldMonth; } }
		private static FieldRef m_fldMonth = new FieldRef("perso", "month");

		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		public decimal ValMonth
		{
			get { return (decimal)returnValueField(FldMonth); }
			set { insertNameValueField(FldMonth, value); }
		}

		/// <summary>Field : "Date of birth" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDob { get { return m_fldDob; } }
		private static FieldRef m_fldDob = new FieldRef("perso", "dob");

		/// <summary>Field : "Date of birth" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDob
		{
			get { return (DateTime)returnValueField(FldDob); }
			set { insertNameValueField(FldDob, value); }
		}

		/// <summary>Field : "Time of birth" Tipo: "T" Formula:  ""</summary>
		public static FieldRef FldTob { get { return m_fldTob; } }
		private static FieldRef m_fldTob = new FieldRef("perso", "tob");

		/// <summary>Field : "Time of birth" Tipo: "T" Formula:  ""</summary>
		public string ValTob
		{
			get { return (string)returnValueField(FldTob); }
			set { insertNameValueField(FldTob, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatusr { get { return m_fldCreatusr; } }
		private static FieldRef m_fldCreatusr = new FieldRef("perso", "creatusr");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatusr
		{
			get { return (string)returnValueField(FldCreatusr); }
			set { insertNameValueField(FldCreatusr, value); }
		}

		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("perso", "creatdat");

		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}

		/// <summary>Field : "Modified by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldModifusr { get { return m_fldModifusr; } }
		private static FieldRef m_fldModifusr = new FieldRef("perso", "modifusr");

		/// <summary>Field : "Modified by" Tipo: "EN" Formula:  ""</summary>
		public string ValModifusr
		{
			get { return (string)returnValueField(FldModifusr); }
			set { insertNameValueField(FldModifusr, value); }
		}

		/// <summary>Field : "Modified on" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldModifdat { get { return m_fldModifdat; } }
		private static FieldRef m_fldModifdat = new FieldRef("perso", "modifdat");

		/// <summary>Field : "Modified on" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValModifdat
		{
			get { return (DateTime)returnValueField(FldModifdat); }
			set { insertNameValueField(FldModifdat, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("perso", "zzstate");



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
        public static CSGenioAperso search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAperso area = new CSGenioAperso(user, user.CurrentModule);

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
        public static List<CSGenioAperso> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAperso>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAperso> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAperso>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX PERSO]/

     

               

	}
}
