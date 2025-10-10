
 
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
	/// Rule
	/// </summary>
	public class CSGenioArules : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioArules(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR RULES]/
		}

		public CSGenioArules(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codregra", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "tipocond", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Condition type";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CONDITION_TYPE57524";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCtipocond";
            Qfield.ArrayClassName = "Tipocond";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descript", FieldType.TEXT);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "local", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Place where you run";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PLACE_WHERE_YOU_RUN27490";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCalocregr";
            Qfield.ArrayClassName = "Alocregr";
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

			// [RULES->TIPOCOND]=="M" && [RULES->LOCAL]=="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])=="M"&&((string)args[1])=="T";
			});
			writeCondition.ErrorWarning = "O campo descrição é obrigatório";
            writeCondition.Type =  ConditionType.MANDATORY;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["descript"];
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="V"  || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="V"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "Falhou condição de visualização na tabela";
            writeCondition.Type =  ConditionType.VIEW;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="E" || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="E"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "A condição de escrita da tabela não está a ser cumprida";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="I"  || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="I"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "Falhou condição de inserção na tabela";
            writeCondition.Type =  ConditionType.INSERT;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="W" || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="W"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "A validação da tabela deu um warning";
            writeCondition.Type =  ConditionType.WARNING;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="U"  || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="U"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "Falhou condição de edição na tabela";
            writeCondition.Type =  ConditionType.UPDATE;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}

			// [RULES->TIPOCOND]!="D" || [RULES->LOCAL]!="T"
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"tipocond","local"},new int[] {0,1},"rules","codregra"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])!="D"||((string)args[1])!="T";
			});
			writeCondition.ErrorWarning = "Falhou condição de eliminação na tabela";
            writeCondition.Type =  ConditionType.DELETE;
            writeCondition.Validate = false;
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioArules()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtrules";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codregra";
			info.HumanKeyName="descript,".TrimEnd(',');
			info.Alias="rules";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Rule";
			info.AreaPluralDesignation="Rules";
			info.DescriptionCav="RULE61609";

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
		public static FieldRef FldCodregra { get { return m_fldCodregra; } }
		private static FieldRef m_fldCodregra = new FieldRef("rules", "codregra");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodregra
		{
			get { return (string)returnValueField(FldCodregra); }
			set { insertNameValueField(FldCodregra, value); }
		}

		/// <summary>Field : "Condition type" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldTipocond { get { return m_fldTipocond; } }
		private static FieldRef m_fldTipocond = new FieldRef("rules", "tipocond");

		/// <summary>Field : "Condition type" Tipo: "AC" Formula:  ""</summary>
		public string ValTipocond
		{
			get { return (string)returnValueField(FldTipocond); }
			set { insertNameValueField(FldTipocond, value); }
		}

		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("rules", "descript");

		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldLocal { get { return m_fldLocal; } }
		private static FieldRef m_fldLocal = new FieldRef("rules", "local");

		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		public string ValLocal
		{
			get { return (string)returnValueField(FldLocal); }
			set { insertNameValueField(FldLocal, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("rules", "zzstate");



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
        public static CSGenioArules search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioArules area = new CSGenioArules(user, user.CurrentModule);

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
        public static List<CSGenioArules> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioArules>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioArules> listing)
        {
			sp.searchListAdvancedWhere<CSGenioArules>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX RULES]/

     
     

	}
}
