

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
	/// Technical
	/// </summary>
	public class CSGenioApess3 : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioApess3(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PESS3]/
		}

		public CSGenioApess3(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codpesso", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codempre", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">COMPANY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_COMPANY02087";

			Qfield.Dupmsg = "";
            Qfield.SufNDup = "idfuncio";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codparte", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = ">INTERESTED PARTY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_INTERESTED_PARTY56973";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("name", FieldType.TEXTO);
			Qfield.FieldDescription = "Name";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NAME31974";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("gender", FieldType.ARRAY_COD_TEXTO);
			Qfield.FieldDescription = "Genre";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "GENRE63303";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCgenero";
            Qfield.ArrayClassName = "Genero";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtnascim", FieldType.DATA);
			Qfield.FieldDescription = "Birth";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "BIRTH21799";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("idade", FieldType.NUMERO);
			Qfield.FieldDescription = "Age";
			Qfield.FieldSize =  5;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 5;
			Qfield.CavDesignation = "AGE28663";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("idfuncio", FieldType.NUMERO);
			Qfield.FieldDescription = "Official No.";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "OFFICIAL_NO_34819";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
            Qfield.PrefNDup = "codempre";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtpwcom", "codpess1", "nridenti"));
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "idfuncio");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("telephon", FieldType.TEXTO);
			Qfield.FieldDescription = "Phone";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "PHONE56703";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("email2", FieldType.TEXTO);
			Qfield.FieldDescription = "Email";
			Qfield.FieldSize =  254;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EMAIL25170";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("photogra", FieldType.IMAGEM_JPEG);
			Qfield.FieldDescription = "Photo";
			Qfield.FieldSize =  3;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 1;
			Qfield.CavDesignation = "PHOTO51874";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtultcat", FieldType.DATA);
			Qfield.FieldDescription = "Since";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "SINCE47259";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcateg", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = ">LAST CATEGORY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "_LAST_CATEGORY61019";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("externa", FieldType.LOGICO);
			Qfield.FieldDescription = "External";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "EXTERNAL13375";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("interna", FieldType.LOGICO);
			Qfield.FieldDescription = "Internal";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "INTERNAL04894";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpaise", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcntry", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
//Actualiza as seguintes réplicas:
			Qfield.ReplicaDestinationList = new List<ReplicaDestination>();
			Qfield.ReplicaDestinationList.Add( new ReplicaDestination("GQT", "gqtpropr", "codpesso", "codpais1"));
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codregia", FieldType.CHAVE_FALSA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("notifind", FieldType.LOGICO);
			Qfield.FieldDescription = "Notificações Individuais";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "NOTIFICACOES_INDIVID17237";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("terrain", FieldType.GEO_SHAPE);
			Qfield.FieldDescription = "Terrain";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "TERRAIN43857";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("extquery", FieldType.TEXTO);
			Qfield.FieldDescription = "Query for external API";
			Qfield.FieldSize =  250;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "QUERY_FOR_EXTERNAL_A51761";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("extminzm", FieldType.NUMERO);
			Qfield.FieldDescription = "Minimum zoom to load features";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "MINIMUM_ZOOM_TO_LOAD08509";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("mapheigh", FieldType.TEXTO);
			Qfield.FieldDescription = "Map height";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "MAP_HEIGHT06476";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("zoomlvl", FieldType.NUMERO);
			Qfield.FieldDescription = "Zoom level";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "ZOOM_LEVEL17268";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("outweigh", FieldType.NUMERO);
			Qfield.FieldDescription = "Outline weight";
			Qfield.FieldSize =  2;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "OUTLINE_WEIGHT25236";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("lineclr", FieldType.TEXTO);
			Qfield.FieldDescription = "Polyline color";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "POLYLINE_COLOR11664";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("polyclr", FieldType.TEXTO);
			Qfield.FieldDescription = "Polygon color";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "POLYGON_COLOR32161";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("groupmrk", FieldType.LOGICO);
			Qfield.FieldDescription = "Group markers in cluster";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "GROUP_MARKERS_IN_CLU31341";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("canedit", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow feature editing";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_FEATURE_EDITIN16439";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("cancut", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow feature cutting";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_FEATURE_CUTTIN10746";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("candrag", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow feature dragging";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_FEATURE_DRAGGI09054";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("canrot", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow feature rotation";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_FEATURE_ROTATI56653";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("canremov", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow feature removal";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_FEATURE_REMOVA13844";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("drawmrk", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow drawing markers";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_DRAWING_MARKER56732";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("allowlin", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow drawing polylines";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_DRAWING_POLYLI25703";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("allowpol", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow drawing polygons";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_DRAWING_POLYGO46480";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("canexpor", FieldType.LOGICO);
			Qfield.FieldDescription = "Allow exporting map";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ALLOW_EXPORTING_MAP27916";

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
			info.ChildTable = new ChildRelation[13];
			info.ChildTable[0]= new ChildRelation("repar", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("esppe", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("indoc", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[3]= new ChildRelation("propr", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[4]= new ChildRelation("hpess", new String[] {"codpesso"}, DeleteProc.DM);
			info.ChildTable[5]= new ChildRelation("conta", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[6]= new ChildRelation("grid", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[7]= new ChildRelation("evcat", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[8]= new ChildRelation("notif", new String[] {"codpesso"}, DeleteProc.NA);
			info.ChildTable[9]= new ChildRelation("lendi", new String[] {"codpess2","codpess1"}, DeleteProc.NA);
			info.ChildTable[10]= new ChildRelation("afini", new String[] {"codpess2","codpess1"}, DeleteProc.NA);
			info.ChildTable[11]= new ChildRelation("pwcom", new String[] {"codpess1"}, DeleteProc.NA);
			info.ChildTable[12]= new ChildRelation("equip", new String[] {"codpess1"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("cmpny", new Relation("GQT", "gqtpessoas", "pess3", "codpesso", "codempre", "GQT", "gqtcmpny", "cmpny", "codempre", "codempre"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("cmpny","cmpny");
			info.Pathways.Add("cntry","cmpny");
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
			info.RelatedSumArgs.Add( new RelatedSumArgument("pesso", "cmpny", "qtdpesso", "1", '+', false));



			info.SequentialDefaultValues = new string[] {
			 "idfuncio"
			};




			info.FieldsParametersReplicas = new string[] {
			 "codcntry","idfuncio"
			};

			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();

			// [PESS1->EMAIL]==[PESS1->EMAIL2]
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"email","email2"},new int[] {0,1},"pess3","codpesso"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((string)args[0])==((string)args[1]);
			});
			writeCondition.ErrorWarning = "Please make sure you have entered email correctly";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = false;
			writeCondition.Field = info.DBFields["email2"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioApess3()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtpessoas";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codpesso";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="pess3";
			info.IsDomain = false;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Technical";
			info.AreaPluralDesignation="Technical";
			info.DescriptionCav="TECHNICAL18245";

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
			info.HistoryList = new List<History>();
			info.DBFields["codempre"].CreateHist = "hpess";
			info.DBFields["name"].CreateHist = "hpess";
			info.HistoryList.Add(new History( "hpess", new string[] {"codempre","name"}));

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.ROLE_VIEW_PESSO;
            info.QLevel.Create = Role.ROLE_EDIT_PESSO;
            info.QLevel.AlterAlways = Role.ROLE_EDIT_PESSO;
            info.QLevel.RemoveAlways = Role.ROLE_EDIT_PESSO;

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
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("pess3", "codpesso");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodempre { get { return m_fldCodempre; } }
		private static FieldRef m_fldCodempre = new FieldRef("pess3", "codempre");

		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre
		{
			get { return (string)returnValueField(FldCodempre); }
			set { insertNameValueField(FldCodempre, value); }
		}

		/// <summary>Field : ">INTERESTED PARTY" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodparte { get { return m_fldCodparte; } }
		private static FieldRef m_fldCodparte = new FieldRef("pess3", "codparte");

		/// <summary>Field : ">INTERESTED PARTY" Tipo: "CF" Formula:  ""</summary>
		public string ValCodparte
		{
			get { return (string)returnValueField(FldCodparte); }
			set { insertNameValueField(FldCodparte, value); }
		}

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("pess3", "name");

		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGender { get { return m_fldGender; } }
		private static FieldRef m_fldGender = new FieldRef("pess3", "gender");

		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		public string ValGender
		{
			get { return (string)returnValueField(FldGender); }
			set { insertNameValueField(FldGender, value); }
		}

		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtnascim { get { return m_fldDtnascim; } }
		private static FieldRef m_fldDtnascim = new FieldRef("pess3", "dtnascim");

		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtnascim
		{
			get { return (DateTime)returnValueField(FldDtnascim); }
			set { insertNameValueField(FldDtnascim, value); }
		}

		/// <summary>Field : "Age" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIdade { get { return m_fldIdade; } }
		private static FieldRef m_fldIdade = new FieldRef("pess3", "idade");

		/// <summary>Field : "Age" Tipo: "N" Formula:  ""</summary>
		public decimal ValIdade
		{
			get { return (decimal)returnValueField(FldIdade); }
			set { insertNameValueField(FldIdade, value); }
		}

		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldIdfuncio { get { return m_fldIdfuncio; } }
		private static FieldRef m_fldIdfuncio = new FieldRef("pess3", "idfuncio");

		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		public decimal ValIdfuncio
		{
			get { return (decimal)returnValueField(FldIdfuncio); }
			set { insertNameValueField(FldIdfuncio, value); }
		}

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTelephon { get { return m_fldTelephon; } }
		private static FieldRef m_fldTelephon = new FieldRef("pess3", "telephon");

		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon
		{
			get { return (string)returnValueField(FldTelephon); }
			set { insertNameValueField(FldTelephon, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("pess3", "email");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail2 { get { return m_fldEmail2; } }
		private static FieldRef m_fldEmail2 = new FieldRef("pess3", "email2");

		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail2
		{
			get { return (string)returnValueField(FldEmail2); }
			set { insertNameValueField(FldEmail2, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhotogra { get { return m_fldPhotogra; } }
		private static FieldRef m_fldPhotogra = new FieldRef("pess3", "photogra");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhotogra
		{
			get { return (byte[])returnValueField(FldPhotogra); }
			set { insertNameValueField(FldPhotogra, value); }
		}

		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtultcat { get { return m_fldDtultcat; } }
		private static FieldRef m_fldDtultcat = new FieldRef("pess3", "dtultcat");

		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtultcat
		{
			get { return (DateTime)returnValueField(FldDtultcat); }
			set { insertNameValueField(FldDtultcat, value); }
		}

		/// <summary>Field : ">LAST CATEGORY" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodcateg { get { return m_fldCodcateg; } }
		private static FieldRef m_fldCodcateg = new FieldRef("pess3", "codcateg");

		/// <summary>Field : ">LAST CATEGORY" Tipo: "CF" Formula:  ""</summary>
		public string ValCodcateg
		{
			get { return (string)returnValueField(FldCodcateg); }
			set { insertNameValueField(FldCodcateg, value); }
		}

		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldExterna { get { return m_fldExterna; } }
		private static FieldRef m_fldExterna = new FieldRef("pess3", "externa");

		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		public int ValExterna
		{
			get { return (int)returnValueField(FldExterna); }
			set { insertNameValueField(FldExterna, value); }
		}

		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldInterna { get { return m_fldInterna; } }
		private static FieldRef m_fldInterna = new FieldRef("pess3", "interna");

		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		public int ValInterna
		{
			get { return (int)returnValueField(FldInterna); }
			set { insertNameValueField(FldInterna, value); }
		}

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodpaise { get { return m_fldCodpaise; } }
		private static FieldRef m_fldCodpaise = new FieldRef("pess3", "codpaise");

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodpaise
		{
			get { return (string)returnValueField(FldCodpaise); }
			set { insertNameValueField(FldCodpaise, value); }
		}

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("pess3", "codcntry");

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public static FieldRef FldCodregia { get { return m_fldCodregia; } }
		private static FieldRef m_fldCodregia = new FieldRef("pess3", "codregia");

		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodregia
		{
			get { return (string)returnValueField(FldCodregia); }
			set { insertNameValueField(FldCodregia, value); }
		}

		/// <summary>Field : "Notificações Individuais" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldNotifind { get { return m_fldNotifind; } }
		private static FieldRef m_fldNotifind = new FieldRef("pess3", "notifind");

		/// <summary>Field : "Notificações Individuais" Tipo: "L" Formula:  ""</summary>
		public int ValNotifind
		{
			get { return (int)returnValueField(FldNotifind); }
			set { insertNameValueField(FldNotifind, value); }
		}

		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		public static FieldRef FldTerrain { get { return m_fldTerrain; } }
		private static FieldRef m_fldTerrain = new FieldRef("pess3", "terrain");

		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		public CSGenio.framework.Geography.GeographicData ValTerrain
		{
			get { return (CSGenio.framework.Geography.GeographicData)returnValueField(FldTerrain); }
			set { insertNameValueField(FldTerrain, value); }
		}

		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldExtquery { get { return m_fldExtquery; } }
		private static FieldRef m_fldExtquery = new FieldRef("pess3", "extquery");

		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		public string ValExtquery
		{
			get { return (string)returnValueField(FldExtquery); }
			set { insertNameValueField(FldExtquery, value); }
		}

		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldExtminzm { get { return m_fldExtminzm; } }
		private static FieldRef m_fldExtminzm = new FieldRef("pess3", "extminzm");

		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		public decimal ValExtminzm
		{
			get { return (decimal)returnValueField(FldExtminzm); }
			set { insertNameValueField(FldExtminzm, value); }
		}

		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldMapheigh { get { return m_fldMapheigh; } }
		private static FieldRef m_fldMapheigh = new FieldRef("pess3", "mapheigh");

		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		public string ValMapheigh
		{
			get { return (string)returnValueField(FldMapheigh); }
			set { insertNameValueField(FldMapheigh, value); }
		}

		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldZoomlvl { get { return m_fldZoomlvl; } }
		private static FieldRef m_fldZoomlvl = new FieldRef("pess3", "zoomlvl");

		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		public decimal ValZoomlvl
		{
			get { return (decimal)returnValueField(FldZoomlvl); }
			set { insertNameValueField(FldZoomlvl, value); }
		}

		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldOutweigh { get { return m_fldOutweigh; } }
		private static FieldRef m_fldOutweigh = new FieldRef("pess3", "outweigh");

		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		public decimal ValOutweigh
		{
			get { return (decimal)returnValueField(FldOutweigh); }
			set { insertNameValueField(FldOutweigh, value); }
		}

		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLineclr { get { return m_fldLineclr; } }
		private static FieldRef m_fldLineclr = new FieldRef("pess3", "lineclr");

		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		public string ValLineclr
		{
			get { return (string)returnValueField(FldLineclr); }
			set { insertNameValueField(FldLineclr, value); }
		}

		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPolyclr { get { return m_fldPolyclr; } }
		private static FieldRef m_fldPolyclr = new FieldRef("pess3", "polyclr");

		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		public string ValPolyclr
		{
			get { return (string)returnValueField(FldPolyclr); }
			set { insertNameValueField(FldPolyclr, value); }
		}

		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldGroupmrk { get { return m_fldGroupmrk; } }
		private static FieldRef m_fldGroupmrk = new FieldRef("pess3", "groupmrk");

		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		public int ValGroupmrk
		{
			get { return (int)returnValueField(FldGroupmrk); }
			set { insertNameValueField(FldGroupmrk, value); }
		}

		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCanedit { get { return m_fldCanedit; } }
		private static FieldRef m_fldCanedit = new FieldRef("pess3", "canedit");

		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		public int ValCanedit
		{
			get { return (int)returnValueField(FldCanedit); }
			set { insertNameValueField(FldCanedit, value); }
		}

		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCancut { get { return m_fldCancut; } }
		private static FieldRef m_fldCancut = new FieldRef("pess3", "cancut");

		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		public int ValCancut
		{
			get { return (int)returnValueField(FldCancut); }
			set { insertNameValueField(FldCancut, value); }
		}

		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCandrag { get { return m_fldCandrag; } }
		private static FieldRef m_fldCandrag = new FieldRef("pess3", "candrag");

		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		public int ValCandrag
		{
			get { return (int)returnValueField(FldCandrag); }
			set { insertNameValueField(FldCandrag, value); }
		}

		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCanrot { get { return m_fldCanrot; } }
		private static FieldRef m_fldCanrot = new FieldRef("pess3", "canrot");

		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		public int ValCanrot
		{
			get { return (int)returnValueField(FldCanrot); }
			set { insertNameValueField(FldCanrot, value); }
		}

		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCanremov { get { return m_fldCanremov; } }
		private static FieldRef m_fldCanremov = new FieldRef("pess3", "canremov");

		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		public int ValCanremov
		{
			get { return (int)returnValueField(FldCanremov); }
			set { insertNameValueField(FldCanremov, value); }
		}

		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldDrawmrk { get { return m_fldDrawmrk; } }
		private static FieldRef m_fldDrawmrk = new FieldRef("pess3", "drawmrk");

		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		public int ValDrawmrk
		{
			get { return (int)returnValueField(FldDrawmrk); }
			set { insertNameValueField(FldDrawmrk, value); }
		}

		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldAllowlin { get { return m_fldAllowlin; } }
		private static FieldRef m_fldAllowlin = new FieldRef("pess3", "allowlin");

		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		public int ValAllowlin
		{
			get { return (int)returnValueField(FldAllowlin); }
			set { insertNameValueField(FldAllowlin, value); }
		}

		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldAllowpol { get { return m_fldAllowpol; } }
		private static FieldRef m_fldAllowpol = new FieldRef("pess3", "allowpol");

		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		public int ValAllowpol
		{
			get { return (int)returnValueField(FldAllowpol); }
			set { insertNameValueField(FldAllowpol, value); }
		}

		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldCanexpor { get { return m_fldCanexpor; } }
		private static FieldRef m_fldCanexpor = new FieldRef("pess3", "canexpor");

		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		public int ValCanexpor
		{
			get { return (int)returnValueField(FldCanexpor); }
			set { insertNameValueField(FldCanexpor, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("pess3", "zzstate");



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
        public static CSGenioApess3 search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioApess3 area = new CSGenioApess3(user, user.CurrentModule);

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
        public static List<CSGenioApess3> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioApess3>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioApess3> listing)
        {
			sp.searchListAdvancedWhere<CSGenioApess3>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX PESS3]/

     

                                       

	}
}
