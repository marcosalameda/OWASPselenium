

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
	/// Property
	/// </summary>
	public class CSGenioApropr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioApropr(User user, string module)
		{
			fields = new Hashtable();
            this.user = user;
            this.module = module;
			this.KeyType = CodeType.GUID_KEY;
			// USE /[MANUAL GQT CONSTRUTOR PROPR]/
		}

		public CSGenioApropr(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field("codpropr", FieldType.CHAVE_PRIMARIA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("name", FieldType.TEXTO);
			Qfield.FieldDescription = "Property name";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "PROPERTY_NAME18934";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("precoest", FieldType.VALOR);
			Qfield.FieldDescription = "Estimated price";
			Qfield.FieldSize =  12;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ESTIMATED_PRICE02986";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codtppro", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("endereco", FieldType.MEMO);
			Qfield.FieldDescription = "Address";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "ADDRESS04342";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("localida", FieldType.TEXTO);
			Qfield.FieldDescription = "Locale";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "LOCALE34521";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codregia", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("postalco", FieldType.TEXTO);
			Qfield.FieldDescription = "Zip code";
			Qfield.FieldSize =  20;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "ZIP_CODE56964";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("postallo", FieldType.TEXTO);
			Qfield.FieldDescription = "Postal location";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "POSTAL_LOCATION08708";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codcntry", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("mobilada", FieldType.LOGICO);
			Qfield.FieldDescription = "Furnished";
			Qfield.FieldSize =  1;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "FURNISHED37431";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("qtd_wc", FieldType.NUMERO);
			Qfield.FieldDescription = "Bathrooms";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "BATHROOMS54249";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("qtdquart", FieldType.NUMERO);
			Qfield.FieldDescription = "Rooms";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "ROOMS06809";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("m2", FieldType.NUMERO);
			Qfield.FieldDescription = "Square meters";
			Qfield.FieldSize =  6;
			Qfield.Alias = info.Alias;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "SQUARE_METERS28913";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("dtdispon", FieldType.DATA);
			Qfield.FieldDescription = "Available from";
			Qfield.FieldSize =  8;
			Qfield.Alias = info.Alias;
			Qfield.CavDesignation = "AVAILABLE_FROM53703";

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
			Qfield = new Field("descript", FieldType.MEMO);
			Qfield.FieldDescription = "Description";
			Qfield.FieldSize =  85;
			Qfield.Alias = info.Alias;
			Qfield.Decimals = 10;
			Qfield.CavDesignation = "DESCRIPTION07383";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("coordgeo", FieldType.GEOGRAPHY);
			Qfield.FieldDescription = "Geographic coordinate";
			Qfield.FieldSize =  50;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GEOGRAPHIC_COORDINAT21394";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpesso", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">SELLER";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "_SELLER11360";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field("codpais1", FieldType.CHAVE_ESTRANGEIRA_GUID);
			Qfield.FieldDescription = ">PERSON COUNTRY";
			Qfield.FieldSize =  36;
			Qfield.Alias = info.Alias;
			Qfield.MQueue = false;
			Qfield.VisivelCav = CavVisibilityType.Nunca;

			Qfield.Dupmsg = "";
			Qfield.Formula = new ReplicaFormula("_replicRel_codpesso", "codcntry");
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
			info.ParentTables.Add("cntry", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codcntry", "GQT", "gqtcntry", "cntry", "codcntry", "codcntry"));
			info.ParentTables.Add("pais1", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codpais1", "GQT", "gqtcntry", "pais1", "codcntry", "codcntry"));
			info.ParentTables.Add("pesso", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codpesso", "GQT", "gqtpessoas", "pesso", "codpesso", "codpesso"));
			info.ParentTables.Add("regio", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codregia", "GQT", "gqtregio", "regio", "codregia", "codregia"));
			info.ParentTables.Add("tppro", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codtppro", "GQT", "gqttppro", "tppro", "codtppro", "codtppro"));
			info.ParentTables.Add("_replicRel_codpesso", new Relation("GQT", "gqtpropr", "propr", "codpropr", "codpesso", "GQT", "gqtpessoas", "pesso", "codpesso", "codpesso"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(8);
			info.Pathways.Add("cntry","cntry");
			info.Pathways.Add("tppro","tppro");
			info.Pathways.Add("pais1","pais1");
			info.Pathways.Add("regio","regio");
			info.Pathways.Add("pesso","pesso");
			info.Pathways.Add("categ","pesso");
			info.Pathways.Add("cmpny","pesso");
			info.Pathways.Add("regi1","pesso");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.ReplicaFields = new string[] {
			 "codpais1"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioApropr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="GQT";
			info.TableName="gqtpropr";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codpropr";
			info.HumanKeyName="name,".TrimEnd(',');
			info.Alias="propr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Property";
			info.AreaPluralDesignation="Properties";
			info.DescriptionCav="PROPERTY43977";

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
			EPHField[] camposEPH;
						camposEPH = new EPHField[1];
			camposEPH[0] = new EPHField("REGIAO", "regio", "codregia", "=", false);
			info.Ephs.Add(new Par("IMO", "20"), camposEPH);

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
		public static FieldRef FldCodpropr { get { return m_fldCodpropr; } }
		private static FieldRef m_fldCodpropr = new FieldRef("propr", "codpropr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpropr
		{
			get { return (string)returnValueField(FldCodpropr); }
			set { insertNameValueField(FldCodpropr, value); }
		}

		/// <summary>Field : "Property name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("propr", "name");

		/// <summary>Field : "Property name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Estimated price" Tipo: "$D" Formula:  ""</summary>
		public static FieldRef FldPrecoest { get { return m_fldPrecoest; } }
		private static FieldRef m_fldPrecoest = new FieldRef("propr", "precoest");

		/// <summary>Field : "Estimated price" Tipo: "$D" Formula:  ""</summary>
		public decimal ValPrecoest
		{
			get { return (decimal)returnValueField(FldPrecoest); }
			set { insertNameValueField(FldPrecoest, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtppro { get { return m_fldCodtppro; } }
		private static FieldRef m_fldCodtppro = new FieldRef("propr", "codtppro");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtppro
		{
			get { return (string)returnValueField(FldCodtppro); }
			set { insertNameValueField(FldCodtppro, value); }
		}

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldEndereco { get { return m_fldEndereco; } }
		private static FieldRef m_fldEndereco = new FieldRef("propr", "endereco");

		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		public string ValEndereco
		{
			get { return (string)returnValueField(FldEndereco); }
			set { insertNameValueField(FldEndereco, value); }
		}

		/// <summary>Field : "Locale" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldLocalida { get { return m_fldLocalida; } }
		private static FieldRef m_fldLocalida = new FieldRef("propr", "localida");

		/// <summary>Field : "Locale" Tipo: "C" Formula:  ""</summary>
		public string ValLocalida
		{
			get { return (string)returnValueField(FldLocalida); }
			set { insertNameValueField(FldLocalida, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodregia { get { return m_fldCodregia; } }
		private static FieldRef m_fldCodregia = new FieldRef("propr", "codregia");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodregia
		{
			get { return (string)returnValueField(FldCodregia); }
			set { insertNameValueField(FldCodregia, value); }
		}

		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPostalco { get { return m_fldPostalco; } }
		private static FieldRef m_fldPostalco = new FieldRef("propr", "postalco");

		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public string ValPostalco
		{
			get { return (string)returnValueField(FldPostalco); }
			set { insertNameValueField(FldPostalco, value); }
		}

		/// <summary>Field : "Postal location" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPostallo { get { return m_fldPostallo; } }
		private static FieldRef m_fldPostallo = new FieldRef("propr", "postallo");

		/// <summary>Field : "Postal location" Tipo: "C" Formula:  ""</summary>
		public string ValPostallo
		{
			get { return (string)returnValueField(FldPostallo); }
			set { insertNameValueField(FldPostallo, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("propr", "codcntry");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}

		/// <summary>Field : "Furnished" Tipo: "L" Formula:  ""</summary>
		public static FieldRef FldMobilada { get { return m_fldMobilada; } }
		private static FieldRef m_fldMobilada = new FieldRef("propr", "mobilada");

		/// <summary>Field : "Furnished" Tipo: "L" Formula:  ""</summary>
		public int ValMobilada
		{
			get { return (int)returnValueField(FldMobilada); }
			set { insertNameValueField(FldMobilada, value); }
		}

		/// <summary>Field : "Bathrooms" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQtd_wc { get { return m_fldQtd_wc; } }
		private static FieldRef m_fldQtd_wc = new FieldRef("propr", "qtd_wc");

		/// <summary>Field : "Bathrooms" Tipo: "N" Formula:  ""</summary>
		public decimal ValQtd_wc
		{
			get { return (decimal)returnValueField(FldQtd_wc); }
			set { insertNameValueField(FldQtd_wc, value); }
		}

		/// <summary>Field : "Rooms" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldQtdquart { get { return m_fldQtdquart; } }
		private static FieldRef m_fldQtdquart = new FieldRef("propr", "qtdquart");

		/// <summary>Field : "Rooms" Tipo: "N" Formula:  ""</summary>
		public decimal ValQtdquart
		{
			get { return (decimal)returnValueField(FldQtdquart); }
			set { insertNameValueField(FldQtdquart, value); }
		}

		/// <summary>Field : "Square meters" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldM2 { get { return m_fldM2; } }
		private static FieldRef m_fldM2 = new FieldRef("propr", "m2");

		/// <summary>Field : "Square meters" Tipo: "N" Formula:  ""</summary>
		public decimal ValM2
		{
			get { return (decimal)returnValueField(FldM2); }
			set { insertNameValueField(FldM2, value); }
		}

		/// <summary>Field : "Available from" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDtdispon { get { return m_fldDtdispon; } }
		private static FieldRef m_fldDtdispon = new FieldRef("propr", "dtdispon");

		/// <summary>Field : "Available from" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDtdispon
		{
			get { return (DateTime)returnValueField(FldDtdispon); }
			set { insertNameValueField(FldDtdispon, value); }
		}

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhotogra { get { return m_fldPhotogra; } }
		private static FieldRef m_fldPhotogra = new FieldRef("propr", "photogra");

		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhotogra
		{
			get { return (byte[])returnValueField(FldPhotogra); }
			set { insertNameValueField(FldPhotogra, value); }
		}

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescript { get { return m_fldDescript; } }
		private static FieldRef m_fldDescript = new FieldRef("propr", "descript");

		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		public string ValDescript
		{
			get { return (string)returnValueField(FldDescript); }
			set { insertNameValueField(FldDescript, value); }
		}

		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		public static FieldRef FldCoordgeo { get { return m_fldCoordgeo; } }
		private static FieldRef m_fldCoordgeo = new FieldRef("propr", "coordgeo");

		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		public string ValCoordgeo
		{
			get { return (string)returnValueField(FldCoordgeo); }
			set { insertNameValueField(FldCoordgeo, value); }
		}

		/// <summary>Field : ">SELLER" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodpesso { get { return m_fldCodpesso; } }
		private static FieldRef m_fldCodpesso = new FieldRef("propr", "codpesso");

		/// <summary>Field : ">SELLER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso
		{
			get { return (string)returnValueField(FldCodpesso); }
			set { insertNameValueField(FldCodpesso, value); }
		}

		/// <summary>Field : ">PERSON COUNTRY" Tipo: "CE" Formula: ++ "[PESSO->CODCNTRY]"</summary>
		public static FieldRef FldCodpais1 { get { return m_fldCodpais1; } }
		private static FieldRef m_fldCodpais1 = new FieldRef("propr", "codpais1");

		/// <summary>Field : ">PERSON COUNTRY" Tipo: "CE" Formula: ++ "[PESSO->CODCNTRY]"</summary>
		public string ValCodpais1
		{
			get { return (string)returnValueField(FldCodpais1); }
			set { insertNameValueField(FldCodpais1, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("propr", "zzstate");



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
        public static CSGenioApropr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioApropr area = new CSGenioApropr(user, user.CurrentModule);

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
        public static List<CSGenioApropr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioApropr>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioApropr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioApropr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL GQT TABAUX PROPR]/

     

                     

	}
}
