

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
	/// Order line
	/// </summary>
	public class CSGenioAlnhpd : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAlnhpd(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR LNHPD]/
		}

		public CSGenioAlnhpd(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codlnhpd", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codpedid", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "line";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtlnhde", "codlnhpd", "codpedid"));
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "line", FieldType.NUMERIC);
			Qfield.FieldDescription = "Line";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "LINE27983";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codpedid";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "line");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtpequ", FieldType.KEY_GUID);
			Qfield.FieldDescription = "TYPE OF EQUIPMENT";
			Qfield.FieldSize =  36;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantida", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  3;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "AMOUNT46885";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "quantdec", FieldType.NUMERIC);
			Qfield.FieldDescription = "Amount";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "AMOUNT46885";

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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("lnhde", new String[] {"codlnhpd"}, DeleteProc.AP);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("pedid", new Relation("GQT", "gqtlnhpd", "lnhpd", "codlnhpd", "codpedid", "GQT", "gqtpedid", "pedid", "codpedid", "codpedid"));
			info.ParentTables.Add("tpequ", new Relation("GQT", "gqtlnhpd", "lnhpd", "codlnhpd", "codtpequ", "GQT", "gqttpequ", "tpequ", "codtpequ", "codtpequ"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("pedid","pedid");
			info.Pathways.Add("tpequ","tpequ");
			info.Pathways.Add("famil","tpequ");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.SequentialDefaultValues = new string[] {
			 "line"
			};




			info.FieldsParametersReplicas = new string[] {
			 "codpedid"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAlnhpd()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtlnhpd";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codlnhpd";
			info.HumanKeyName="line,".TrimEnd(',');
			info.Alias="lnhpd";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Order line";
			info.AreaPluralDesignation="Order lines";
			info.DescriptionCav="ORDER_LINE50035";

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
		public static FieldRef FldCodlnhpd { get { return m_fldCodlnhpd; } }
		private static FieldRef m_fldCodlnhpd = new FieldRef("lnhpd", "codlnhpd");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlnhpd
		{
			get { return (string)returnValueField(FldCodlnhpd); }
			set { insertNameValueField(FldCodlnhpd, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpedid { get { return m_fldCodpedid; } }
		private static FieldRef m_fldCodpedid = new FieldRef("lnhpd", "codpedid");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpedid
		{
			get { return (string)returnValueField(FldCodpedid); }
			set { insertNameValueField(FldCodpedid, value); }
		}

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldLine { get { return m_fldLine; } }
		private static FieldRef m_fldLine = new FieldRef("lnhpd", "line");

		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		public decimal ValLine
		{
			get { return (decimal)returnValueField(FldLine); }
			set { insertNameValueField(FldLine, value); }
		}

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtpequ { get { return m_fldCodtpequ; } }
		private static FieldRef m_fldCodtpequ = new FieldRef("lnhpd", "codtpequ");

		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ
		{
			get { return (string)returnValueField(FldCodtpequ); }
			set { insertNameValueField(FldCodtpequ, value); }
		}

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQuantida { get { return m_fldQuantida; } }
		private static FieldRef m_fldQuantida = new FieldRef("lnhpd", "quantida");

		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		public decimal ValQuantida
		{
			get { return (decimal)returnValueField(FldQuantida); }
			set { insertNameValueField(FldQuantida, value); }
		}

		/// <summary>Field : "Amount" Tipo: "ND" Formula:  ""</summary>
		public static FieldRef FldQuantdec { get { return m_fldQuantdec; } }
		private static FieldRef m_fldQuantdec = new FieldRef("lnhpd", "quantdec");

		/// <summary>Field : "Amount" Tipo: "ND" Formula:  ""</summary>
		public decimal ValQuantdec
		{
			get { return (decimal)returnValueField(FldQuantdec); }
			set { insertNameValueField(FldQuantdec, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("lnhpd", "zzstate");



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
        public static CSGenioAlnhpd search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAlnhpd area = new CSGenioAlnhpd(user, user.CurrentModule);

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
        public static List<CSGenioAlnhpd> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAlnhpd>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAlnhpd> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAlnhpd>(where, listing);
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
			criteria.Equal(CSGenioAlnhpd.FldCodpedid, ValCodpedid);
			sp.ReorderSequence(Area.AreaLNHPD, CSGenioAlnhpd.FldLine, criteria);

            return msg;
		}

 


		// USE /[MANUAL GQT TABAUX LNHPD]/

  
		public StatusMessage carga_CONJUNTO(string codtpequ, PersistentSupport sp, User user)
		{
			int offset = 0;
			int numberOfRecords = -1;
			List<ColumnSort> sorts = null;
			
			if (GenFunctions.emptyG(codtpequ) == 1)
				return StatusMessage.Error();

			FieldRef[] fields = new FieldRef[]
			{
				CSGenioAcmpki.FldCodcmpki,
				CSGenioAcmpki.FldCode,
				CSGenioAcmpki.FldUrl,
				CSGenioAcmpki.FldCodtpeq1,
				CSGenioAcmpki.FldDescript,
				CSGenioAcmpki.FldOrder,
				CSGenioAcmpki.FldQuantida,
			};

			ListingMVC<CSGenioAcmpki> list = new ListingMVC<CSGenioAcmpki>(fields, sorts, offset, numberOfRecords, true, user, true);
			CSGenioAcmpki.searchListAdvancedWhere(sp, user, CriteriaSet.And().Equal(CSGenioAcmpki.FldCodtpequ, codtpequ), list);

			foreach(var row in list.Rows)
			{
				CSGenioAlnhde lnhde = new CSGenioAlnhde(user);

				lnhde.ValCodlnhpd = this.ValCodlnhpd;
				object[] args = null;
				args = new object[1];
				args[0] = row.ValCode;
				lnhde.ValCode = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValUrl;
				lnhde.ValUrl = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValCodtpeq1;
				lnhde.ValCodtpequ = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValDescript;
				lnhde.ValDescript = ((string)args[0]);
				args = new object[1];
				args[0] = row.ValOrder;
				lnhde.ValOrdem = ((decimal)args[0]);
				args = new object[1];
				args[0] = row.ValQuantida;
				lnhde.ValQuantida = ((decimal)args[0]);
 				lnhde.insert(sp);
			}

			return StatusMessage.OK();
		}
    

  
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
				maxOrder = sp.GetMaxFieldValue(Area.AreaLNHPD, CSGenioAlnhpd.FldLine, condition, relations);
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
							.Update(Area.AreaLNHPD)
							.Set(CSGenioAlnhpd.FldLine, 0)
							.Where(CriteriaSet.And().Equal(CSGenioAlnhpd.FldCodlnhpd, QPrimaryKey));
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
            range_condition.GreaterOrEqual(CSGenioAlnhpd.FldLine, posLow);
            range_condition.LesserOrEqual(CSGenioAlnhpd.FldLine, posHigh);

			sp.ReorderSequence(Area.AreaLNHPD, CSGenioAlnhpd.FldLine, range_condition, relations, posLow + difference);

			if (moveRow) {
				//Set moved record position to new position
				UpdateQuery up = new UpdateQuery()
							.Update(Area.AreaLNHPD)
							.Set(CSGenioAlnhpd.FldLine, posnova)
							.Where(CriteriaSet.And().Equal(CSGenioAlnhpd.FldCodlnhpd, QPrimaryKey));
				sp.Execute(up);
			}

			OnReorder_Line(sp, posactual, condition, relations);
        }

        private void OnReorder_Line(PersistentSupport sp, int oldpos, CriteriaSet condition, List<Relation> relations)
        {
// USE /[MANUAL GQT ONREORDER LNHPD.LINE]/
        }

     

	}
}
