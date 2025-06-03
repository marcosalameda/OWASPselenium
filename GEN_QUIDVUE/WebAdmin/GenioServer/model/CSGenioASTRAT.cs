

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
	/// Estratégia
	/// </summary>
	public class CSGenioAstrat : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAstrat(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR STRAT]/
		}

		public CSGenioAstrat(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codestra", FieldType.KEY_GUID);
			Qfield.FieldDescription = "Primary key";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "CHAVE_PRIMARIA61422";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "estrateg", FieldType.TEXT);
			Qfield.FieldDescription = "Strategy";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "ESTRATEGIA20488";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatdat", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Creation date";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "CRIADO_EM61283";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatope", FieldType.TEXT);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  200;
			Qfield.CavDesignation = "CRIADO_POR17895";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "chngdate", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Changed on";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "ALTERADO_EM23573";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "operchng", FieldType.TEXT);
			Qfield.FieldDescription = "Changed by";
			Qfield.FieldSize =  200;
			Qfield.CavDesignation = "ALTERADO_POR39254";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  10;
			Qfield.Decimals = 9;
			Qfield.CavDesignation = "DESCRIPTION07383";

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
		/// static CSGenioAstrat()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtstrat";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codestra";
			info.HumanKeyName="estrateg,".TrimEnd(',');
			info.Alias="strat";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Estratégia";
			info.AreaPluralDesignation="Estratégias";
			info.DescriptionCav="ESTRATEGIA31298";

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
                "creatope","creatdat"
			};

			info.StampFieldsAlt = new string[] {
                "operchng","chngdate"
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

		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodestra { get { return m_fldCodestra; } }
		private static FieldRef m_fldCodestra = new FieldRef("strat", "codestra");

		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public string ValCodestra
		{
			get { return (string)returnValueField(FldCodestra); }
			set { insertNameValueField(FldCodestra, value); }
		}

		/// <summary>Field : "Strategy" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEstrateg { get { return m_fldEstrateg; } }
		private static FieldRef m_fldEstrateg = new FieldRef("strat", "estrateg");

		/// <summary>Field : "Strategy" Tipo: "C" Formula:  ""</summary>
		public string ValEstrateg
		{
			get { return (string)returnValueField(FldEstrateg); }
			set { insertNameValueField(FldEstrateg, value); }
		}

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("strat", "creatdat");

		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatope { get { return m_fldCreatope; } }
		private static FieldRef m_fldCreatope = new FieldRef("strat", "creatope");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope
		{
			get { return (string)returnValueField(FldCreatope); }
			set { insertNameValueField(FldCreatope, value); }
		}

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public static FieldRef FldChngdate { get { return m_fldChngdate; } }
		private static FieldRef m_fldChngdate = new FieldRef("strat", "chngdate");

		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		public DateTime ValChngdate
		{
			get { return (DateTime)returnValueField(FldChngdate); }
			set { insertNameValueField(FldChngdate, value); }
		}

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public static FieldRef FldOperchng { get { return m_fldOperchng; } }
		private static FieldRef m_fldOperchng = new FieldRef("strat", "operchng");

		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng
		{
			get { return (string)returnValueField(FldOperchng); }
			set { insertNameValueField(FldOperchng, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("strat", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("strat", "zzstate");



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
        public static CSGenioAstrat search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAstrat area = new CSGenioAstrat(user, user.CurrentModule);

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
        public static List<CSGenioAstrat> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAstrat>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAstrat> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAstrat>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX STRAT]/

     

        

	}
}
