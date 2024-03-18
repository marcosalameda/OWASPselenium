

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
	/// Notification
	/// </summary>
	public class CSGenioAnotif : DbArea	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAnotif(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR NOTIF]/
		}

		public CSGenioAnotif(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codnotif", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("nrcomoda", FieldType.NUMERO);
			Qfield.FieldDescription = "No. of the dadato";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NO__OF_THE_DADATO35934";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("begin", FieldType.DATAHORA);
			Qfield.FieldDescription = "Beginning";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BEGINNING18124";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getNow);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("end", FieldType.DATAHORA);
			Qfield.FieldDescription = "End";
			Qfield.FieldSize =  16;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "END47577";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email", FieldType.TEXTO);
			Qfield.FieldDescription = "Recipient's email";
			Qfield.FieldSize =  100;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RECIPIENT_S_EMAIL43894";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("idnotif", FieldType.TEXTO);
			Qfield.FieldDescription = "Notification ID that generated the message";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NOTIFICATION_ID_THAT61751";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("idmsg", FieldType.TEXTO);
			Qfield.FieldDescription = "Message ID";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "MESSAGE_ID37133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("message", FieldType.MEMO);
			Qfield.FieldDescription = "Text of the sent message";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 15;
			Qfield.CavDesignation = "TEXT_OF_THE_SENT_MES52307";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("mailerr", FieldType.TEXTO);
			Qfield.FieldDescription = "Error sending email";
			Qfield.FieldSize =  300;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ERROR_SENDING_EMAIL53846";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("designat", FieldType.TEXTO);
			Qfield.FieldDescription = "Recipient";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RECIPIENT65165";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creatdat", FieldType.DATACRIA);
			Qfield.FieldDescription = "Creation: Date";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "CREATION__DATE13180";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("creatope", FieldType.OPERCRIA);
			Qfield.FieldDescription = "Creation: Operator";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "CREATION__OPERATOR50535";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("returned", FieldType.LOGICO);
			Qfield.FieldDescription = "Returned";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RETURNED01606";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtdevolu", FieldType.DATA);
			Qfield.FieldDescription = "Return";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RETURN32222";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpesso", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "Recipient key 'Comodatário'";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "RECIPIENT_KEY__COMOD31618";

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
			info.ParentTables.Add("pess2", new Relation("GQT", "gqtnotif", "notif", "codnotif", "codpesso", "GQT", "gqtpessoas", "pess2", "codpesso", "codpesso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("pess2","pess2");
			info.Pathways.Add("stake","pess2");
			info.Pathways.Add("cmpny","pess2");
			info.Pathways.Add("cntry","pess2");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "begin","returned"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAnotif()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtnotif";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codnotif";
			info.HumanKeyName="nrcomoda,".TrimEnd(',');
			info.Alias="notif";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Notification";
			info.AreaPluralDesignation="Notifications";
			info.DescriptionCav="NOTIFICATION15372";

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
                "creatope","creatdat"
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
		public static FieldRef FldCodnotif { get { return m_fldCodnotif; } }
		private static FieldRef m_fldCodnotif = new FieldRef("notif", "codnotif");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodnotif
		{
			get { return (string)returnValueField(FldCodnotif); }
			set { insertNameValueField(FldCodnotif, value); }
		}


		/// <summary>Field : "No. of the dadato" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNrcomoda { get { return m_fldNrcomoda; } }
		private static FieldRef m_fldNrcomoda = new FieldRef("notif", "nrcomoda");

		/// <summary>Field : "No. of the dadato" Tipo: "N" Formula:  ""</summary>
		public double ValNrcomoda
		{
			get { return (double)returnValueField(FldNrcomoda); }
			set { insertNameValueField(FldNrcomoda, value); }
		}


		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldBegin { get { return m_fldBegin; } }
		private static FieldRef m_fldBegin = new FieldRef("notif", "begin");

		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValBegin
		{
			get { return (DateTime)returnValueField(FldBegin); }
			set { insertNameValueField(FldBegin, value); }
		}


		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldEnd { get { return m_fldEnd; } }
		private static FieldRef m_fldEnd = new FieldRef("notif", "end");

		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValEnd
		{
			get { return (DateTime)returnValueField(FldEnd); }
			set { insertNameValueField(FldEnd, value); }
		}


		/// <summary>Field : "Recipient's email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("notif", "email");

		/// <summary>Field : "Recipient's email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}


		/// <summary>Field : "Notification ID that generated the message" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdnotif { get { return m_fldIdnotif; } }
		private static FieldRef m_fldIdnotif = new FieldRef("notif", "idnotif");

		/// <summary>Field : "Notification ID that generated the message" Tipo: "C" Formula:  ""</summary>
		public string ValIdnotif
		{
			get { return (string)returnValueField(FldIdnotif); }
			set { insertNameValueField(FldIdnotif, value); }
		}


		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdmsg { get { return m_fldIdmsg; } }
		private static FieldRef m_fldIdmsg = new FieldRef("notif", "idmsg");

		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdmsg
		{
			get { return (string)returnValueField(FldIdmsg); }
			set { insertNameValueField(FldIdmsg, value); }
		}


		/// <summary>Field : "Text of the sent message" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldMessage { get { return m_fldMessage; } }
		private static FieldRef m_fldMessage = new FieldRef("notif", "message");

		/// <summary>Field : "Text of the sent message" Tipo: "MO" Formula:  ""</summary>
		public string ValMessage
		{
			get { return (string)returnValueField(FldMessage); }
			set { insertNameValueField(FldMessage, value); }
		}


		/// <summary>Field : "Error sending email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldMailerr { get { return m_fldMailerr; } }
		private static FieldRef m_fldMailerr = new FieldRef("notif", "mailerr");

		/// <summary>Field : "Error sending email" Tipo: "C" Formula:  ""</summary>
		public string ValMailerr
		{
			get { return (string)returnValueField(FldMailerr); }
			set { insertNameValueField(FldMailerr, value); }
		}


		/// <summary>Field : "Recipient" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("notif", "designat");

		/// <summary>Field : "Recipient" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}


		/// <summary>Field : "Creation: Date" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("notif", "creatdat");

		/// <summary>Field : "Creation: Date" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}


		/// <summary>Field : "Creation: Operator" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatope { get { return m_fldCreatope; } }
		private static FieldRef m_fldCreatope = new FieldRef("notif", "creatope");

		/// <summary>Field : "Creation: Operator" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope
		{
			get { return (string)returnValueField(FldCreatope); }
			set { insertNameValueField(FldCreatope, value); }
		}


		/// <summary>Field : "Returned" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldReturned { get { return m_fldReturned; } }
		private static FieldRef m_fldReturned = new FieldRef("notif", "returned");

		/// <summary>Field : "Returned" Tipo: "L" Formula:  ""</summary>
		public int ValReturned
		{
			get { return (int)returnValueField(FldReturned); }
			set { insertNameValueField(FldReturned, value); }
		}


		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtdevolu { get { return m_fldDtdevolu; } }
		private static FieldRef m_fldDtdevolu = new FieldRef("notif", "dtdevolu");

		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtdevolu
		{
			get { return (DateTime)returnValueField(FldDtdevolu); }
			set { insertNameValueField(FldDtdevolu, value); }
		}


		/// <summary>Field : "Recipient key 'Comodatário'" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("notif", "codpesso");

		/// <summary>Field : "Recipient key 'Comodatário'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}


		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("notif", "zzstate");



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
        public static CSGenioAnotif search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAnotif area = new CSGenioAnotif(user, user.CurrentModule);

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
        [Obsolete("Use List<CSGenioAnotif> searchList(PersistentSupport sp, User user, CriteriaSet where, string []fields) instead")]
        public static List<CSGenioAnotif> searchList(PersistentSupport sp, User user, string where, string []fields = null)
        {
            return sp.searchListWhere<CSGenioAnotif>(where, user, fields);
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
        public static List<CSGenioAnotif> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAnotif>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAnotif> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAnotif>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);







		// USE /[MANUAL GQT TABAUX NOTIF]/

     

                

	}
}
