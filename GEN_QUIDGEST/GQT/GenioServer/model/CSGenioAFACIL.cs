

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
	/// Facility
	/// </summary>
	public class CSGenioAfacil : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAfacil(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR FACIL]/
		}

		public CSGenioAfacil(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codfacil", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codentit", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "incorpor", FieldType.DATA);
			Qfield.FieldDescription = "Incorporation";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "INCORPORATION10135";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXTO);
			Qfield.FieldDescription = "Facility name";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FACILITY_NAME19514";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "faciltyp", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Facility type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FACILITY_TYPE44577";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCfaciltyp";
            Qfield.ArrayClassName = "Faciltyp";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "address", FieldType.MEMO);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.Decimals = 5;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codfacty", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">>Facility type";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "__FACILITY_TYPE27254";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"codfacty"},new int[] {0},"glob",""));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "image", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Image";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "IMAGE65174";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gpsinput", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "GPS input";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GPS_INPUT13625";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCgpsinput";
            Qfield.ArrayClassName = "Gpsinput";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "latitude", FieldType.NUMERO);
			Qfield.FieldDescription = "Latitude";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 6;
			Qfield.CavDesignation = "LATITUDE11291";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "longitud", FieldType.NUMERO);
			Qfield.FieldDescription = "Longitude";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 6;
			Qfield.CavDesignation = "LONGITUDE01015";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "geocoori", FieldType.GEOGRAPHY);
			Qfield.FieldDescription = "Geographical coordinate";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GEOGRAPHICAL_COORDIN45869";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "geocoord", FieldType.GEOGRAPHY);
			Qfield.FieldDescription = "Geographical coordinate";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GEOGRAPHICAL_COORDIN45869";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"gpsinput","latitude","longitud","geocoori"}, new int[] {0,1,2,3}, "facil", "codfacil"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 4, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((((string)args[0])=="L")?(new GlobalFunctions(user,module,sp).GetGeoFromLatLng(((decimal)args[1]),((decimal)args[2]))):(((string)args[3])));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codcntry", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">> Country";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "___COUNTRY10061";

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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("locat", new String[] {"codfacil"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("entit", new String[] {"firstfacilitie","lastfacilitie"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("cntry", new Relation("GQT", "gqtfacility", "facil", "codfacil", "codcntry", "GQT", "gqtcntry", "cntry", "codcntry", "codcntry"));
			info.ParentTables.Add("entit", new Relation("GQT", "gqtfacility", "facil", "codfacil", "codentit", "GQT", "gqtentity", "entit", "codentit", "codentit"));
			info.ParentTables.Add("facty", new Relation("GQT", "gqtfacility", "facil", "codfacil", "codfacty", "GQT", "gqtfacilitytype", "facty", "codfacty", "codfacty"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(5);
			info.Pathways.Add("facty","facty");
			info.Pathways.Add("cntry","cntry");
			info.Pathways.Add("entit","entit");
			info.Pathways.Add("faci1","entit");
			info.Pathways.Add("faci2","entit");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "geocoord"
			};

			info.DefaultValues = new string[] {
			 "codfacty"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();

			// [FACIL->LONGITUD]>=-180 && [FACIL->LONGITUD]<=180
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"longitud","longitud"},new int[] {0,1},"facil","codfacil"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>=-180&&((decimal)args[1])<=180;
			});
			writeCondition.ErrorWarning = "Longitudes range from -180 to 180.";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["longitud"];
			conditions.Add(writeCondition);
			}

			// [FACIL->LATITUDE]>=-90 && [FACIL->LATITUDE]<=90
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"latitude","latitude"},new int[] {0,1},"facil","codfacil"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>=-90&&((decimal)args[1])<=90;
			});
			writeCondition.ErrorWarning = "Latitudes range from -90 to 90.";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["latitude"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAfacil()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtfacility";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codfacil";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="facil";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Facility";
			info.AreaPluralDesignation="Facilities";
			info.DescriptionCav="FACILITY55206";

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
		public static FieldRef FldCodfacil { get { return m_fldCodfacil; } }
		private static FieldRef m_fldCodfacil = new FieldRef("facil", "codfacil");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfacil
		{
			get { return (string)returnValueField(FldCodfacil); }
			set { insertNameValueField(FldCodfacil, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodentit { get { return m_fldCodentit; } }
		private static FieldRef m_fldCodentit = new FieldRef("facil", "codentit");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit
		{
			get { return (string)returnValueField(FldCodentit); }
			set { insertNameValueField(FldCodentit, value); }
		}

		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldIncorpor { get { return m_fldIncorpor; } }
		private static FieldRef m_fldIncorpor = new FieldRef("facil", "incorpor");

		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		public DateTime ValIncorpor
		{
			get { return (DateTime)returnValueField(FldIncorpor); }
			set { insertNameValueField(FldIncorpor, value); }
		}

		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("facil", "name");

		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldFaciltyp { get { return m_fldFaciltyp; } }
		private static FieldRef m_fldFaciltyp = new FieldRef("facil", "faciltyp");

		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		public string ValFaciltyp
		{
			get { return (string)returnValueField(FldFaciltyp); }
			set { insertNameValueField(FldFaciltyp, value); }
		}

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldAddress { get { return m_fldAddress; } }
		private static FieldRef m_fldAddress = new FieldRef("facil", "address");

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public string ValAddress
		{
			get { return (string)returnValueField(FldAddress); }
			set { insertNameValueField(FldAddress, value); }
		}

		/// <summary>Field : ">>Facility type" Tipo: "CE" Formula: DG "[GLOB->CODFACTY]"</summary>
		public static FieldRef FldCodfacty { get { return m_fldCodfacty; } }
		private static FieldRef m_fldCodfacty = new FieldRef("facil", "codfacty");

		/// <summary>Field : ">>Facility type" Tipo: "CE" Formula: DG "[GLOB->CODFACTY]"</summary>
		public string ValCodfacty
		{
			get { return (string)returnValueField(FldCodfacty); }
			set { insertNameValueField(FldCodfacty, value); }
		}

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldImage { get { return m_fldImage; } }
		private static FieldRef m_fldImage = new FieldRef("facil", "image");

		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValImage
		{
			get { return (byte[])returnValueField(FldImage); }
			set { insertNameValueField(FldImage, value); }
		}

		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGpsinput { get { return m_fldGpsinput; } }
		private static FieldRef m_fldGpsinput = new FieldRef("facil", "gpsinput");

		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		public string ValGpsinput
		{
			get { return (string)returnValueField(FldGpsinput); }
			set { insertNameValueField(FldGpsinput, value); }
		}

		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldLatitude { get { return m_fldLatitude; } }
		private static FieldRef m_fldLatitude = new FieldRef("facil", "latitude");

		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		public decimal ValLatitude
		{
			get { return (decimal)returnValueField(FldLatitude); }
			set { insertNameValueField(FldLatitude, value); }
		}

		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldLongitud { get { return m_fldLongitud; } }
		private static FieldRef m_fldLongitud = new FieldRef("facil", "longitud");

		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		public decimal ValLongitud
		{
			get { return (decimal)returnValueField(FldLongitud); }
			set { insertNameValueField(FldLongitud, value); }
		}

		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		public static FieldRef FldGeocoori { get { return m_fldGeocoori; } }
		private static FieldRef m_fldGeocoori = new FieldRef("facil", "geocoori");

		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		public string ValGeocoori
		{
			get { return (string)returnValueField(FldGeocoori); }
			set { insertNameValueField(FldGeocoori, value); }
		}

		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACIL->GPSINPUT]=="L",GetGeoFromLatLng([FACIL->LATITUDE],[FACIL->LONGITUD]),[FACIL->GEOCOORI])"</summary>
		public static FieldRef FldGeocoord { get { return m_fldGeocoord; } }
		private static FieldRef m_fldGeocoord = new FieldRef("facil", "geocoord");

		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACIL->GPSINPUT]=="L",GetGeoFromLatLng([FACIL->LATITUDE],[FACIL->LONGITUD]),[FACIL->GEOCOORI])"</summary>
		public string ValGeocoord
		{
			get { return (string)returnValueField(FldGeocoord); }
			set { insertNameValueField(FldGeocoord, value); }
		}

		/// <summary>Field : ">> Country" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("facil", "codcntry");

		/// <summary>Field : ">> Country" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("facil", "zzstate");



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
        public static CSGenioAfacil search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAfacil area = new CSGenioAfacil(user, user.CurrentModule);

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
        public static List<CSGenioAfacil> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAfacil>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAfacil> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAfacil>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX FACIL]/

     

               

	}
}
