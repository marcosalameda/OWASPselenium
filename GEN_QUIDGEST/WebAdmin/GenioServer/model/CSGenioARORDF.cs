

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
	/// Order (Float field)
	/// </summary>
	public class CSGenioArordf : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioArordf(User user, string module)
		{
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR RORDF]/
		}

		public CSGenioArordf(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codrordf", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "order", FieldType.NUMERO);
			Qfield.FieldDescription = "Order";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 8;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "ORDER39632";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "order");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "title", FieldType.TEXTO);
			Qfield.FieldDescription = "Title";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITLE21885";

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



			info.SequentialDefaultValues = new string[] {
			 "order"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioArordf()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtrordf";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codrordf";
			info.HumanKeyName="order,".TrimEnd(',');
			info.Alias="rordf";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Order (Float field)";
			info.AreaPluralDesignation="Orders  (Float field)";
			info.DescriptionCav="ORDER__FLOAT_FIELD_21693";

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
		public static FieldRef FldCodrordf { get { return m_fldCodrordf; } }
		private static FieldRef m_fldCodrordf = new FieldRef("rordf", "codrordf");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrordf
		{
			get { return (string)returnValueField(FldCodrordf); }
			set { insertNameValueField(FldCodrordf, value); }
		}

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOrder { get { return m_fldOrder; } }
		private static FieldRef m_fldOrder = new FieldRef("rordf", "order");

		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		public decimal ValOrder
		{
			get { return (decimal)returnValueField(FldOrder); }
			set { insertNameValueField(FldOrder, value); }
		}

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("rordf", "title");

		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("rordf", "zzstate");



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
        public static CSGenioArordf search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioArordf area = new CSGenioArordf(user, user.CurrentModule);

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
        public static List<CSGenioArordf> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioArordf>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioArordf> listing)
        {
			sp.searchListAdvancedWhere<CSGenioArordf>(where, listing);
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
			sp.ReorderSequence(Area.AreaRORDF, CSGenioArordf.FldOrder, criteria);

            return msg;
		}

 


		// USE /[MANUAL GQT TABAUX RORDF]/

     

 
		/// <summary>
        /// Reorders the values of the ordering field along a subset so that the current record moves in that order to the specified position
        /// </summary>
        /// <param name="sp">The current PersistentSupport</param>
        /// <param name="position">The position to where the record will be moved</param>
        /// <param name="condition">The subset to be reordered</param>
        public void Reorder_Order(PersistentSupport sp, int position, CriteriaSet condition, List<Relation> relations = null, bool moveRow = true)
        {
            int posactual = (int)ValOrder;
            int posnova = position + 1;
            ValOrder = posnova;

			//Get highest value for ordering field
			int maxOrder;

            try
			{
				maxOrder = sp.GetMaxFieldValue(Area.AreaRORDF, CSGenioArordf.FldOrder, condition, relations);
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
							.Update(Area.AreaRORDF)
							.Set(CSGenioArordf.FldOrder, 0)
							.Where(CriteriaSet.And().Equal(CSGenioArordf.FldCodrordf, QPrimaryKey));
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
            range_condition.GreaterOrEqual(CSGenioArordf.FldOrder, posLow);
            range_condition.LesserOrEqual(CSGenioArordf.FldOrder, posHigh);

			sp.ReorderSequence(Area.AreaRORDF, CSGenioArordf.FldOrder, range_condition, relations, posLow + difference);

			if (moveRow) {
				//Set moved record position to new position
				UpdateQuery up = new UpdateQuery()
							.Update(Area.AreaRORDF)
							.Set(CSGenioArordf.FldOrder, posnova)
							.Where(CriteriaSet.And().Equal(CSGenioArordf.FldCodrordf, QPrimaryKey));
				sp.Execute(up);
			}

			OnReorder_Order(sp, posactual, condition, relations);
        }

        private void OnReorder_Order(PersistentSupport sp, int oldpos, CriteriaSet condition, List<Relation> relations)
        {
// USE /[MANUAL GQT ONREORDER RORDF.Order]/
        }

   

	}
}
