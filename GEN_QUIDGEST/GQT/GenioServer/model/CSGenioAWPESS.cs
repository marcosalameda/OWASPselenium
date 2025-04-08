

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
	/// Employee
	/// </summary>
	public class CSGenioAwpess : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAwpess(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR WPESS]/
		}

		public CSGenioAwpess(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codpess", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXTO);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NAME31974";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATA);
			Qfield.FieldDescription = "Birth date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BIRTH_DATE54504";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sex", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Genre";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GENRE63303";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCsexo";
            Qfield.ArrayClassName = "Sexo";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nfunc", FieldType.NUMERO);
			Qfield.FieldDescription = "NºFuncionário";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "NOFUNCIONARIO21429";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "adress", FieldType.TEXTO);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zipcode", FieldType.TEXTO);
			Qfield.FieldDescription = "Zip code";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ZIP_CODE56964";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateCP(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "country", FieldType.TEXTO);
			Qfield.FieldDescription = "Pais";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PAIS04637";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  150;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateEM(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "cellphon", FieldType.NUMERO);
			Qfield.FieldDescription = "NºTelefone";
			Qfield.FieldSize =  9;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.CavDesignation = "NOTELEFONE56747";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "naturali", FieldType.TEXTO);
			Qfield.FieldDescription = "Naturalness";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NATURALNESS33189";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nacional", FieldType.TEXTO);
			Qfield.FieldDescription = "Nacionalidade";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NACIONALIDADE23735";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pfoto", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Profile picture";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "PROFILE_PICTURE26817";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codwareh", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ftimgtop", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Image Top";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE_TOP34930";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ftthumb", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Image thumbnail";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE_THUMBNAIL01682";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ftbackgr", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Image Background";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE_BACKGROUND07216";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "showreco", FieldType.LOGICO);
			Qfield.FieldDescription = "Show Record";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SHOW_RECORD11620";

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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("wareh", new Relation("GQT", "gqtwpess", "wpess", "codpess", "codwareh", "GQT", "gqtwareh", "wareh", "codwareh", "codwareh"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("wareh","wareh");
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
			info.RelatedSumArgs.Add( new RelatedSumArgument("wpess", "wareh", "num_employee", "1", '+', false));








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAwpess()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtwpess";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codpess";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="wpess";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Employee";
			info.AreaPluralDesignation="Employees";
			info.DescriptionCav="EMPLOYEE55452";

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
		public static FieldRef FldCodpess { get { return m_fldCodpess; } }
		private static FieldRef m_fldCodpess = new FieldRef("wpess", "codpess");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpess
		{
			get { return (string)returnValueField(FldCodpess); }
			set { insertNameValueField(FldCodpess, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("wpess", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Birth date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("wpess", "date");

		/// <summary>Field : "Birth date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldSex { get { return m_fldSex; } }
		private static FieldRef m_fldSex = new FieldRef("wpess", "sex");

		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		public string ValSex
		{
			get { return (string)returnValueField(FldSex); }
			set { insertNameValueField(FldSex, value); }
		}

		/// <summary>Field : "NºFuncionário" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNfunc { get { return m_fldNfunc; } }
		private static FieldRef m_fldNfunc = new FieldRef("wpess", "nfunc");

		/// <summary>Field : "NºFuncionário" Tipo: "N" Formula:  ""</summary>
		public decimal ValNfunc
		{
			get { return (decimal)returnValueField(FldNfunc); }
			set { insertNameValueField(FldNfunc, value); }
		}

		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldAdress { get { return m_fldAdress; } }
		private static FieldRef m_fldAdress = new FieldRef("wpess", "adress");

		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public string ValAdress
		{
			get { return (string)returnValueField(FldAdress); }
			set { insertNameValueField(FldAdress, value); }
		}

		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldZipcode { get { return m_fldZipcode; } }
		private static FieldRef m_fldZipcode = new FieldRef("wpess", "zipcode");

		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public string ValZipcode
		{
			get { return (string)returnValueField(FldZipcode); }
			set { insertNameValueField(FldZipcode, value); }
		}

		/// <summary>Field : "Pais" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCountry { get { return m_fldCountry; } }
		private static FieldRef m_fldCountry = new FieldRef("wpess", "country");

		/// <summary>Field : "Pais" Tipo: "C" Formula:  ""</summary>
		public string ValCountry
		{
			get { return (string)returnValueField(FldCountry); }
			set { insertNameValueField(FldCountry, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("wpess", "email");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "NºTelefone" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldCellphon { get { return m_fldCellphon; } }
		private static FieldRef m_fldCellphon = new FieldRef("wpess", "cellphon");

		/// <summary>Field : "NºTelefone" Tipo: "N" Formula:  ""</summary>
		public decimal ValCellphon
		{
			get { return (decimal)returnValueField(FldCellphon); }
			set { insertNameValueField(FldCellphon, value); }
		}

		/// <summary>Field : "Naturalness" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNaturali { get { return m_fldNaturali; } }
		private static FieldRef m_fldNaturali = new FieldRef("wpess", "naturali");

		/// <summary>Field : "Naturalness" Tipo: "C" Formula:  ""</summary>
		public string ValNaturali
		{
			get { return (string)returnValueField(FldNaturali); }
			set { insertNameValueField(FldNaturali, value); }
		}

		/// <summary>Field : "Nacionalidade" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNacional { get { return m_fldNacional; } }
		private static FieldRef m_fldNacional = new FieldRef("wpess", "nacional");

		/// <summary>Field : "Nacionalidade" Tipo: "C" Formula:  ""</summary>
		public string ValNacional
		{
			get { return (string)returnValueField(FldNacional); }
			set { insertNameValueField(FldNacional, value); }
		}

		/// <summary>Field : "Profile picture" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPfoto { get { return m_fldPfoto; } }
		private static FieldRef m_fldPfoto = new FieldRef("wpess", "pfoto");

		/// <summary>Field : "Profile picture" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPfoto
		{
			get { return (byte[])returnValueField(FldPfoto); }
			set { insertNameValueField(FldPfoto, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodwareh { get { return m_fldCodwareh; } }
		private static FieldRef m_fldCodwareh = new FieldRef("wpess", "codwareh");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh
		{
			get { return (string)returnValueField(FldCodwareh); }
			set { insertNameValueField(FldCodwareh, value); }
		}

		/// <summary>Field : "Image Top" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFtimgtop { get { return m_fldFtimgtop; } }
		private static FieldRef m_fldFtimgtop = new FieldRef("wpess", "ftimgtop");

		/// <summary>Field : "Image Top" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFtimgtop
		{
			get { return (byte[])returnValueField(FldFtimgtop); }
			set { insertNameValueField(FldFtimgtop, value); }
		}

		/// <summary>Field : "Image thumbnail" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFtthumb { get { return m_fldFtthumb; } }
		private static FieldRef m_fldFtthumb = new FieldRef("wpess", "ftthumb");

		/// <summary>Field : "Image thumbnail" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFtthumb
		{
			get { return (byte[])returnValueField(FldFtthumb); }
			set { insertNameValueField(FldFtthumb, value); }
		}

		/// <summary>Field : "Image Background" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFtbackgr { get { return m_fldFtbackgr; } }
		private static FieldRef m_fldFtbackgr = new FieldRef("wpess", "ftbackgr");

		/// <summary>Field : "Image Background" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFtbackgr
		{
			get { return (byte[])returnValueField(FldFtbackgr); }
			set { insertNameValueField(FldFtbackgr, value); }
		}

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldShowreco { get { return m_fldShowreco; } }
		private static FieldRef m_fldShowreco = new FieldRef("wpess", "showreco");

		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public int ValShowreco
		{
			get { return (int)returnValueField(FldShowreco); }
			set { insertNameValueField(FldShowreco, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("wpess", "zzstate");



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
        public static CSGenioAwpess search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAwpess area = new CSGenioAwpess(user, user.CurrentModule);

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
        public static List<CSGenioAwpess> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAwpess>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAwpess> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAwpess>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX WPESS]/

     

                   

	}
}
