
 
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
	/// Message
	/// </summary>
	public class CSGenioAmessa : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAmessa(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL GQT CONSTRUTOR MESSA]/
		}

		public CSGenioAmessa(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codmessa", FieldType.KEY_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "idnotif", FieldType.TEXT);
			Qfield.FieldDescription = "Notification ID";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "NOTIFICATION_ID25507";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "idmsg", FieldType.TEXT);
			Qfield.FieldDescription = "Message ID";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "MESSAGE_ID37133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "designat", FieldType.TEXT);
			Qfield.FieldDescription = "To whom the message was sent";
			Qfield.FieldSize =  50;
			Qfield.CavDesignation = "TO_WHOM_THE_MESSAGE_02337";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "E-mail to whom the message was sent";
			Qfield.FieldSize =  254;
			Qfield.CavDesignation = "E_MAIL_TO_WHOM_THE_M37668";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "message", FieldType.MEMO);
			Qfield.FieldDescription = "Message";
			Qfield.FieldSize =  100;
			Qfield.MQueue = false;
			Qfield.Decimals = 10;
			Qfield.CavDesignation = "MESSAGE30602";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "mailsent", FieldType.LOGIC);
			Qfield.FieldDescription = "E-mail sent?";
			Qfield.FieldSize =  1;
			Qfield.CavDesignation = "E_MAIL_SENT_60490";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(0);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "mailerr", FieldType.TEXT);
			Qfield.FieldDescription = "Error sending mail";
			Qfield.FieldSize =  300;
			Qfield.CavDesignation = "ERROR_SENDING_MAIL44674";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatope", FieldType.TEXT);
			Qfield.FieldDescription = "Created by";
			Qfield.FieldSize =  128;
			Qfield.CavDesignation = "CREATED_BY12292";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "creatdat", FieldType.DATETIMESECONDS);
			Qfield.FieldDescription = "Created on";
			Qfield.FieldSize =  8;
			Qfield.CavDesignation = "CREATED_ON00051";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codentit", FieldType.KEY_GUID);
			Qfield.FieldDescription = "'Entity'";
			Qfield.FieldSize =  36;
			Qfield.CavDesignation = "_ENTITY_22923";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codperso", FieldType.KEY_GUID);
			Qfield.FieldDescription = "'Person'";
			Qfield.FieldSize =  36;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_PERSON_09109";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "docum_nr", FieldType.NUMERIC);
			Qfield.FieldDescription = "Document number";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "DOCUMENT_NUMBER28451";

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
			info.ParentTables.Add("entit", new Relation("GQT", "gqtmessages", "messa", "codmessa", "codentit", "GQT", "gqtentity", "entit", "codentit", "codentit"));
			info.ParentTables.Add("perso", new Relation("GQT", "gqtmessages", "messa", "codmessa", "codperso", "GQT", "gqtperson", "perso", "codperso", "codperso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(4);
			info.Pathways.Add("perso","perso");
			info.Pathways.Add("entit","entit");
			info.Pathways.Add("faci2","entit");
			info.Pathways.Add("faci1","entit");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "mailsent"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAmessa()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtmessages";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codmessa";
			info.HumanKeyName="idnotif,".TrimEnd(',');
			info.Alias="messa";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Message";
			info.AreaPluralDesignation="Messages";
			info.DescriptionCav="MESSAGE30602";

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
		public static FieldRef FldCodmessa { get { return m_fldCodmessa; } }
		private static FieldRef m_fldCodmessa = new FieldRef("messa", "codmessa");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmessa
		{
			get { return (string)returnValueField(FldCodmessa); }
			set { insertNameValueField(FldCodmessa, value); }
		}

		/// <summary>Field : "Notification ID" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdnotif { get { return m_fldIdnotif; } }
		private static FieldRef m_fldIdnotif = new FieldRef("messa", "idnotif");

		/// <summary>Field : "Notification ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdnotif
		{
			get { return (string)returnValueField(FldIdnotif); }
			set { insertNameValueField(FldIdnotif, value); }
		}

		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldIdmsg { get { return m_fldIdmsg; } }
		private static FieldRef m_fldIdmsg = new FieldRef("messa", "idmsg");

		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdmsg
		{
			get { return (string)returnValueField(FldIdmsg); }
			set { insertNameValueField(FldIdmsg, value); }
		}

		/// <summary>Field : "To whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldDesignat { get { return m_fldDesignat; } }
		private static FieldRef m_fldDesignat = new FieldRef("messa", "designat");

		/// <summary>Field : "To whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat
		{
			get { return (string)returnValueField(FldDesignat); }
			set { insertNameValueField(FldDesignat, value); }
		}

		/// <summary>Field : "E-mail to whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("messa", "email");

		/// <summary>Field : "E-mail to whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Message" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldMessage { get { return m_fldMessage; } }
		private static FieldRef m_fldMessage = new FieldRef("messa", "message");

		/// <summary>Field : "Message" Tipo: "MO" Formula:  ""</summary>
		public string ValMessage
		{
			get { return (string)returnValueField(FldMessage); }
			set { insertNameValueField(FldMessage, value); }
		}

		/// <summary>Field : "E-mail sent?" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMailsent { get { return m_fldMailsent; } }
		private static FieldRef m_fldMailsent = new FieldRef("messa", "mailsent");

		/// <summary>Field : "E-mail sent?" Tipo: "L" Formula:  ""</summary>
		public int ValMailsent
		{
			get { return (int)returnValueField(FldMailsent); }
			set { insertNameValueField(FldMailsent, value); }
		}

		/// <summary>Field : "Error sending mail" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldMailerr { get { return m_fldMailerr; } }
		private static FieldRef m_fldMailerr = new FieldRef("messa", "mailerr");

		/// <summary>Field : "Error sending mail" Tipo: "C" Formula:  ""</summary>
		public string ValMailerr
		{
			get { return (string)returnValueField(FldMailerr); }
			set { insertNameValueField(FldMailerr, value); }
		}

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public static FieldRef FldCreatope { get { return m_fldCreatope; } }
		private static FieldRef m_fldCreatope = new FieldRef("messa", "creatope");

		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope
		{
			get { return (string)returnValueField(FldCreatope); }
			set { insertNameValueField(FldCreatope, value); }
		}

		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		public static FieldRef FldCreatdat { get { return m_fldCreatdat; } }
		private static FieldRef m_fldCreatdat = new FieldRef("messa", "creatdat");

		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		public DateTime ValCreatdat
		{
			get { return (DateTime)returnValueField(FldCreatdat); }
			set { insertNameValueField(FldCreatdat, value); }
		}

		/// <summary>Field : "'Entity'" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodentit { get { return m_fldCodentit; } }
		private static FieldRef m_fldCodentit = new FieldRef("messa", "codentit");

		/// <summary>Field : "'Entity'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit
		{
			get { return (string)returnValueField(FldCodentit); }
			set { insertNameValueField(FldCodentit, value); }
		}

		/// <summary>Field : "'Person'" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodperso { get { return m_fldCodperso; } }
		private static FieldRef m_fldCodperso = new FieldRef("messa", "codperso");

		/// <summary>Field : "'Person'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperso
		{
			get { return (string)returnValueField(FldCodperso); }
			set { insertNameValueField(FldCodperso, value); }
		}

		/// <summary>Field : "Document number" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldDocum_nr { get { return m_fldDocum_nr; } }
		private static FieldRef m_fldDocum_nr = new FieldRef("messa", "docum_nr");

		/// <summary>Field : "Document number" Tipo: "N" Formula:  ""</summary>
		public decimal ValDocum_nr
		{
			get { return (decimal)returnValueField(FldDocum_nr); }
			set { insertNameValueField(FldDocum_nr, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("messa", "zzstate");



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
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAmessa search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAmessa area = new CSGenioAmessa(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
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
        public static List<CSGenioAmessa> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAmessa>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAmessa> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAmessa>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL GQT TABAUX MESSA]/

     
              

	}
}
