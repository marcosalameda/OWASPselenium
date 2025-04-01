using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.Models
{
	public class Pesso : ModelBase
	{
		[JsonIgnore]
		public CSGenioApesso klass { get { return baseklass as CSGenioApesso; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodpesso");

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodempre");
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		public virtual Cmpny Cmpny { get { if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre)))) _cmpny = Models.Cmpny.Find(ValCodempre, Identifier, _fieldsToSerialize); if (_cmpny == null) _cmpny = new Models.Cmpny(true, _fieldsToSerialize); return _cmpny; } set { _cmpny = value; } }
		public bool ShouldSerializeCmpny () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny");

		[DisplayName("Interested party")]
		/// <summary>Field : "Interested party" Tipo: "CF" Formula:  ""</summary>
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }
		public bool ShouldSerializeValCodparte() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodparte");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValName");

		[DisplayName("Genus")]
		/// <summary>Field : "Genus" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGenero.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }
		public bool ShouldSerializeValGender() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValGender");

		[DisplayName("Birth")]
		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get { return klass.ValDtnascim; } set { klass.ValDtnascim = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtnascim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValDtnascim");

		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula: + "Idade([PESSO->DTNASCIM],[Today])"</summary>
		[NumericAttribute(0)]
		public decimal? ValIdade { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIdade, 0)); } set { klass.ValIdade = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIdade() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValIdade");

		[DisplayName("Official No.")]
		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIdfuncio, 0)); } set { klass.ValIdfuncio = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIdfuncio() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValIdfuncio");

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValTelephon");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValEmail");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail2 { get { return klass.ValEmail2; } set { klass.ValEmail2 = value; } }
		public bool ShouldSerializeValEmail2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValEmail2");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhotogra { get { return klass.ValPhotogra; } set { klass.ValPhotogra = value; } }
		public bool ShouldSerializeValPhotogra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValPhotogra");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula: U1 "EVCAT[EVCAT->SINCE][EVCAT->SINCE][Today]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get { return klass.ValDtultcat; } set { klass.ValDtultcat = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtultcat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValDtultcat");

		[DisplayName(">LAST CATEGORY")]
		/// <summary>Field : ">LAST CATEGORY" Tipo: "CE" Formula: U1 "EVCAT[EVCAT->SINCE][EVCAT->CODCATEG][Today]"</summary>
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		public bool ShouldSerializeValCodcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodcateg");
		private Categ _categ;
		[DisplayName("Categ")]
		public virtual Categ Categ { get { if (!this.isEmptyModel && (_categ == null || (!string.IsNullOrEmpty(ValCodcateg) && (_categ.isEmptyModel || _categ.klass.QPrimaryKey != ValCodcateg)))) _categ = Models.Categ.Find(ValCodcateg, Identifier, _fieldsToSerialize); if (_categ == null) _categ = new Models.Categ(true, _fieldsToSerialize); return _categ; } set { _categ = value; } }
		public bool ShouldSerializeCateg () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Categ");

		[DisplayName("External")]
		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		public bool ValExterna { get { return Convert.ToBoolean(klass.ValExterna); } set { klass.ValExterna = Convert.ToInt32(value); } }
		public bool ShouldSerializeValExterna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValExterna");

		[DisplayName("Internal")]
		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		public bool ValInterna { get { return Convert.ToBoolean(klass.ValInterna); } set { klass.ValInterna = Convert.ToInt32(value); } }
		public bool ShouldSerializeValInterna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValInterna");

		[DisplayName("COMPANY PARENTS")]
		/// <summary>Field : "COMPANY PARENTS" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpaise { get { return klass.ValCodpaise; } set { klass.ValCodpaise = value; } }
		public bool ShouldSerializeValCodpaise() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodpaise");
		private Cntry _cntry;
		[DisplayName("Cntry")]
		public virtual Cntry Cntry { get { if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodpaise) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodpaise)))) _cntry = Models.Cntry.Find(ValCodpaise, Identifier, _fieldsToSerialize); if (_cntry == null) _cntry = new Models.Cntry(true, _fieldsToSerialize); return _cntry; } set { _cntry = value; } }
		public bool ShouldSerializeCntry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry");

		[DisplayName("PERSON'S PARENTS")]
		/// <summary>Field : "PERSON'S PARENTS" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodcntry");
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		public virtual Pais1 Pais1 { get { if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodcntry) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodcntry)))) _pais1 = Models.Pais1.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_pais1 == null) _pais1 = new Models.Pais1(true, _fieldsToSerialize); return _pais1; } set { _pais1 = value; } }
		public bool ShouldSerializePais1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCodregia");
		private Regi1 _regi1;
		[DisplayName("Regi1")]
		public virtual Regi1 Regi1 { get { if (!this.isEmptyModel && (_regi1 == null || (!string.IsNullOrEmpty(ValCodregia) && (_regi1.isEmptyModel || _regi1.klass.QPrimaryKey != ValCodregia)))) _regi1 = Models.Regi1.Find(ValCodregia, Identifier, _fieldsToSerialize); if (_regi1 == null) _regi1 = new Models.Regi1(true, _fieldsToSerialize); return _regi1; } set { _regi1 = value; } }
		public bool ShouldSerializeRegi1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regi1");

		[DisplayName("Indiviudal notifications")]
		/// <summary>Field : "Indiviudal notifications" Tipo: "L" Formula:  ""</summary>
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }
		public bool ShouldSerializeValNotifind() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValNotifind");

		[DisplayName("Terrain")]
		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		[GeographicAttribute("GS")]
		public CSGenio.framework.Geography.GeographicData ValTerrain { get { return klass.ValTerrain; } set { klass.ValTerrain = value; } }
		public bool ShouldSerializeValTerrain() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValTerrain");

		[DisplayName("Query for external API")]
		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		public string ValExtquery { get { return klass.ValExtquery; } set { klass.ValExtquery = value; } }
		public bool ShouldSerializeValExtquery() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValExtquery");

		[DisplayName("Minimum zoom to load features")]
		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValExtminzm { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValExtminzm, 0)); } set { klass.ValExtminzm = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValExtminzm() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValExtminzm");

		[DisplayName("Map height")]
		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		public string ValMapheigh { get { return klass.ValMapheigh; } set { klass.ValMapheigh = value; } }
		public bool ShouldSerializeValMapheigh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValMapheigh");

		[DisplayName("Zoom level")]
		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValZoomlvl { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValZoomlvl, 0)); } set { klass.ValZoomlvl = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValZoomlvl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValZoomlvl");

		[DisplayName("Outline weight")]
		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOutweigh { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOutweigh, 0)); } set { klass.ValOutweigh = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOutweigh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValOutweigh");

		[DisplayName("Polyline color")]
		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		public string ValLineclr { get { return klass.ValLineclr; } set { klass.ValLineclr = value; } }
		public bool ShouldSerializeValLineclr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValLineclr");

		[DisplayName("Polygon color")]
		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		public string ValPolyclr { get { return klass.ValPolyclr; } set { klass.ValPolyclr = value; } }
		public bool ShouldSerializeValPolyclr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValPolyclr");

		[DisplayName("Group markers in cluster")]
		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		public bool ValGroupmrk { get { return Convert.ToBoolean(klass.ValGroupmrk); } set { klass.ValGroupmrk = Convert.ToInt32(value); } }
		public bool ShouldSerializeValGroupmrk() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValGroupmrk");

		[DisplayName("Allow feature editing")]
		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		public bool ValCanedit { get { return Convert.ToBoolean(klass.ValCanedit); } set { klass.ValCanedit = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanedit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCanedit");

		[DisplayName("Allow feature cutting")]
		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		public bool ValCancut { get { return Convert.ToBoolean(klass.ValCancut); } set { klass.ValCancut = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCancut() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCancut");

		[DisplayName("Allow feature dragging")]
		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		public bool ValCandrag { get { return Convert.ToBoolean(klass.ValCandrag); } set { klass.ValCandrag = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCandrag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCandrag");

		[DisplayName("Allow feature rotation")]
		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		public bool ValCanrot { get { return Convert.ToBoolean(klass.ValCanrot); } set { klass.ValCanrot = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanrot() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCanrot");

		[DisplayName("Allow feature removal")]
		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		public bool ValCanremov { get { return Convert.ToBoolean(klass.ValCanremov); } set { klass.ValCanremov = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanremov() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCanremov");

		[DisplayName("Allow drawing markers")]
		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		public bool ValDrawmrk { get { return Convert.ToBoolean(klass.ValDrawmrk); } set { klass.ValDrawmrk = Convert.ToInt32(value); } }
		public bool ShouldSerializeValDrawmrk() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValDrawmrk");

		[DisplayName("Allow drawing polylines")]
		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		public bool ValAllowlin { get { return Convert.ToBoolean(klass.ValAllowlin); } set { klass.ValAllowlin = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAllowlin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValAllowlin");

		[DisplayName("Allow drawing polygons")]
		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		public bool ValAllowpol { get { return Convert.ToBoolean(klass.ValAllowpol); } set { klass.ValAllowpol = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAllowpol() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValAllowpol");

		[DisplayName("Allow exporting map")]
		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		public bool ValCanexpor { get { return Convert.ToBoolean(klass.ValCanexpor); } set { klass.ValCanexpor = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanexpor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValCanexpor");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso.ValZzstate");

		public Pesso() : this(UserContext.Current.User) { }

		public Pesso(User u)
		{
			this.klass = new CSGenioApesso(u);
		}

		public Pesso(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pesso(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pesso(bool isEmpty) : this(isEmpty, null) { }

		public Pesso(CSGenioApesso val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pesso(CSGenioApesso val) : this(val, null) { }

		public Pesso(CSGenioApesso val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pesso(CSGenioApesso val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApesso csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cmpny":
						if (_cmpny == null)
							_cmpny = new Cmpny(true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "categ":
						if (_categ == null)
							_categ = new Categ(true, _fieldsToSerialize);
						_categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pais1":
						if (_pais1 == null)
							_pais1 = new Pais1(true, _fieldsToSerialize);
						_pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regi1":
						if (_regi1 == null)
							_regi1 = new Regi1(true, _fieldsToSerialize);
						_regi1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Pesso Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Pesso Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApesso>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pesso(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pesso> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApesso>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pesso>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApesso> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApesso>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApesso> All(CriteriaSet args = null)
		{
			return Where<CSGenioApesso>(false, args, numRegs: -1);
		}

		public static List<Pesso> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApesso>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pesso>((r) => new Pesso(r));
		}

// USE /[MANUAL GQT MODEL PESSO]/
	}
}
