

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
	/// Entry
	/// </summary>
	public class CSGenioAldent : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAldent(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR LDENT]/
		}

		public CSGenioAldent(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codldent", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coddentr", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "line";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "line", FieldType.NUMERIC);
			Qfield.FieldDescription = "Line";
			Qfield.FieldSize =  5;
			Qfield.IntegerDigits = 3;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "LINE27983";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "coddentr";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "line");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codwareh", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">ARMAZEM";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "_ARMAZEM43996";

			Qfield.Dupmsg = "";
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"codwareh"},new int[] {0},"indoc","coddentr"));
			Qfield.DefaultValue = new DefaultValue(new InternalOperationFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return (object)(((string)args[0]));
			}));

			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coditem", FieldType.KEY_GUID);
			Qfield.FieldDescription = ">ARTICLE";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "_ARTICLE38266";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "qtdentra", FieldType.NUMERIC);
			Qfield.FieldDescription = "Qtd entry";
			Qfield.FieldSize =  10;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "QTD_ENTRY35144";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(1);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dhentra", FieldType.DATETIME);
			Qfield.FieldDescription = "Instant entrance";
			Qfield.FieldSize =  16;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_coddentr", "dhdocume");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "emuso", FieldType.LOGIC);
			Qfield.FieldDescription = "Articles in use";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "ARTICLES_IN_USE35156";

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
			info.ParentTables.Add("indoc", new Relation("GQT", "gqtldent", "ldent", "codldent", "coddentr", "GQT", "gqtindoc", "indoc", "coddentr", "coddentr"));
			info.ParentTables.Add("item", new Relation("GQT", "gqtldent", "ldent", "codldent", "coditem", "GQT", "gqtitem", "item", "coditem", "coditem"));
			info.ParentTables.Add("wareh", new Relation("GQT", "gqtldent", "ldent", "codldent", "codwareh", "GQT", "gqtwareh", "wareh", "codwareh", "codwareh"));
			info.ParentTables.Add("_replicRel_coddentr", new Relation("GQT", "gqtldent", "ldent", "codldent", "coddentr", "GQT", "gqtindoc", "indoc", "coddentr", "coddentr"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(11);
			info.Pathways.Add("wareh","wareh");
			info.Pathways.Add("item","item");
			info.Pathways.Add("indoc","indoc");
			info.Pathways.Add("gitem","item");
			info.Pathways.Add("cntry","indoc");
			info.Pathways.Add("ware1","indoc");
			info.Pathways.Add("cmpny","indoc");
			info.Pathways.Add("pesso","indoc");
			info.Pathways.Add("categ","indoc");
			info.Pathways.Add("pais1","indoc");
			info.Pathways.Add("regi1","indoc");
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
			info.RelatedSumArgs.Add( new RelatedSumArgument("ldent", "item", "entries", "qtdentra", '+', true));
			info.RelatedSumArgs.Add( new RelatedSumArgument("ldent", "item", "existenc", "qtdentra", '+', true));



			info.ReplicaFields = new string[] {
			 "dhentra"
			};

			info.DefaultValues = new string[] {
			 "codwareh","qtdentra"
			};

			info.SequentialDefaultValues = new string[] {
			 "line"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAldent()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtldent";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codldent";
			info.HumanKeyName="line,".TrimEnd(',');
			info.Alias="ldent";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Entry";
			info.AreaPluralDesignation="Entries";
			info.DescriptionCav="ENTRY29068";

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
		public static FieldRef FldCodldent { get { return m_fldCodldent; } }
		private static FieldRef m_fldCodldent = new FieldRef("ldent", "codldent");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodldent
		{
			get { return (string)returnValueField(FldCodldent); }
			set { insertNameValueField(FldCodldent, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoddentr { get { return m_fldCoddentr; } }
		private static FieldRef m_fldCoddentr = new FieldRef("ldent", "coddentr");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddentr
		{
			get { return (string)returnValueField(FldCoddentr); }
			set { insertNameValueField(FldCoddentr, value); }
		}

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldLine { get { return m_fldLine; } }
		private static FieldRef m_fldLine = new FieldRef("ldent", "line");

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public decimal ValLine
		{
			get { return (decimal)returnValueField(FldLine); }
			set { insertNameValueField(FldLine, value); }
		}

		/// <summary>Field : ">ARMAZEM" Tipo: "CE" Formula: DF "[INDOC->CODWAREH]"</summary>
		public static FieldRef FldCodwareh { get { return m_fldCodwareh; } }
		private static FieldRef m_fldCodwareh = new FieldRef("ldent", "codwareh");

		/// <summary>Field : ">ARMAZEM" Tipo: "CE" Formula: DF "[INDOC->CODWAREH]"</summary>
		public string ValCodwareh
		{
			get { return (string)returnValueField(FldCodwareh); }
			set { insertNameValueField(FldCodwareh, value); }
		}

		/// <summary>Field : ">ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCoditem { get { return m_fldCoditem; } }
		private static FieldRef m_fldCoditem = new FieldRef("ldent", "coditem");

		/// <summary>Field : ">ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem
		{
			get { return (string)returnValueField(FldCoditem); }
			set { insertNameValueField(FldCoditem, value); }
		}

		/// <summary>Field : "Qtd entry" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQtdentra { get { return m_fldQtdentra; } }
		private static FieldRef m_fldQtdentra = new FieldRef("ldent", "qtdentra");

		/// <summary>Field : "Qtd entry" Tipo: "N" Formula:  ""</summary>
		public decimal ValQtdentra
		{
			get { return (decimal)returnValueField(FldQtdentra); }
			set { insertNameValueField(FldQtdentra, value); }
		}

		/// <summary>Field : "Instant entrance" Tipo: "DT" Formula: ++ "[INDOC->DHDOCUME]"</summary>
		public static FieldRef FldDhentra { get { return m_fldDhentra; } }
		private static FieldRef m_fldDhentra = new FieldRef("ldent", "dhentra");

		/// <summary>Field : "Instant entrance" Tipo: "DT" Formula: ++ "[INDOC->DHDOCUME]"</summary>
		public DateTime ValDhentra
		{
			get { return (DateTime)returnValueField(FldDhentra); }
			set { insertNameValueField(FldDhentra, value); }
		}

		/// <summary>Field : "Articles in use" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldEmuso { get { return m_fldEmuso; } }
		private static FieldRef m_fldEmuso = new FieldRef("ldent", "emuso");

		/// <summary>Field : "Articles in use" Tipo: "L" Formula:  ""</summary>
		public int ValEmuso
		{
			get { return (int)returnValueField(FldEmuso); }
			set { insertNameValueField(FldEmuso, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("ldent", "zzstate");



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
        public static CSGenioAldent search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAldent area = new CSGenioAldent(user, user.CurrentModule);

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
        public static List<CSGenioAldent> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAldent>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAldent> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAldent>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 		//To usar routine manual no pedido eliminate
		public override StatusMessage eliminate(PersistentSupport sp)
		{
			StatusMessage msg = base.eliminate(sp);

			// ROW_REORDERING
			CriteriaSet criteria = CriteriaSet.And();
			criteria.Equal(CSGenioAldent.FldCoddentr, ValCoddentr);
			sp.ReorderSequence(Area.AreaLDENT, CSGenioAldent.FldLine, criteria);

            return msg;
		}

 


		// USE /[MANUAL GQT TABAUX LDENT]/

     

  
		/// <summary>
        /// Reorders the values of the ordering field along a subset so that the current record moves in that order to the specified position
        /// </summary>
        /// <param name="sp">The current PersistentSupport</param>
        /// <param name="position">The position to where the record will be moved</param>
        /// <param name="condition">The subset to be reordered</param>
        public void Reorder_Line(PersistentSupport sp, int position, CriteriaSet condition, List<Relation> relations = null, bool moveRow = true)
        {
            int posactual = (int)ValLine;
            int posnova = position + 1;
            ValLine = posnova;

			//Get highest value for ordering field
			int maxOrder;

            try
			{
				maxOrder = sp.GetMaxFieldValue(Area.AreaLDENT, CSGenioAldent.FldLine, condition, relations);
			}
			catch(Exception ex)
			{
                Log.Error(ex.Message);
                return;
			}

			//Row is not being moved
			if (posnova > maxOrder)
			{
				return;
			}
			if (!moveRow)
			{
				posactual = maxOrder + 1;
			}
			//Row is not being moved
			if(posnova == posactual || posnova < 1){
				return;
			}

			if (moveRow) {
				//Set moved record position to 0 temporarily
				UpdateQuery up_temp = new UpdateQuery()
							.Update(Area.AreaLDENT)
							.Set(CSGenioAldent.FldLine, 0)
							.Where(CriteriaSet.And().Equal(CSGenioAldent.FldCodldent, QPrimaryKey));
				sp.Execute(up_temp);
			}

			//Set new positions of records in the range from the previous position to the new position
			int posLow;
			int posHigh;
            int difference;
			//If new position is greater than previous position
			if (posnova > posactual) {
				posLow = posactual + 1;
				posHigh = posnova;
                difference = -1;
			}
			//If new position is less than previous position
			else {
				posLow = posnova;
				posHigh = posactual - 1;
                difference = 1;
            }
			CriteriaSet range_condition = CriteriaSet.And();
            range_condition.SubSet(condition);
            range_condition.GreaterOrEqual(CSGenioAldent.FldLine, posLow);
            range_condition.LesserOrEqual(CSGenioAldent.FldLine, posHigh);

			sp.ReorderSequence(Area.AreaLDENT, CSGenioAldent.FldLine, range_condition, relations, posLow + difference);

			if (moveRow) {
				//Set moved record position to new position
				UpdateQuery up = new UpdateQuery()
							.Update(Area.AreaLDENT)
							.Set(CSGenioAldent.FldLine, posnova)
							.Where(CriteriaSet.And().Equal(CSGenioAldent.FldCodldent, QPrimaryKey));
				sp.Execute(up);
			}

			OnReorder_Line(sp, posactual, condition, relations);
        }

        private void OnReorder_Line(PersistentSupport sp, int oldpos, CriteriaSet condition, List<Relation> relations)
        {
// USE /[MANUAL GQT ONREORDER LDENT.LINE]/
        }

       

	}
}
