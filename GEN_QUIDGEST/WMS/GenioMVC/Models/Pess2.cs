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
	public class Pess2 : ModelBase
	{
		[JsonIgnore]
		public CSGenioApess2 klass { get { return baseklass as CSGenioApess2; } set { baseklass = value; } }

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
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodpesso");

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodempre");
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		public virtual Cmpny Cmpny { get { if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre)))) _cmpny = Models.Cmpny.Find(ValCodempre, Identifier, _fieldsToSerialize); if (_cmpny == null) _cmpny = new Models.Cmpny(true, _fieldsToSerialize); return _cmpny; } set { _cmpny = value; } }
		public bool ShouldSerializeCmpny () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny");

		[DisplayName(">INTERESTED PARTY")]
		/// <summary>Field : ">INTERESTED PARTY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }
		public bool ShouldSerializeValCodparte() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodparte");
		private Stake _stake;
		[DisplayName("Stake")]
		public virtual Stake Stake { get { if (!this.isEmptyModel && (_stake == null || (!string.IsNullOrEmpty(ValCodparte) && (_stake.isEmptyModel || _stake.klass.QPrimaryKey != ValCodparte)))) _stake = Models.Stake.Find(ValCodparte, Identifier, _fieldsToSerialize); if (_stake == null) _stake = new Models.Stake(true, _fieldsToSerialize); return _stake; } set { _stake = value; } }
		public bool ShouldSerializeStake () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Stake");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValName");

		[DisplayName("Genus")]
		/// <summary>Field : "Genus" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGenero.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }
		public bool ShouldSerializeValGender() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValGender");

		[DisplayName("Birth")]
		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get { return klass.ValDtnascim; } set { klass.ValDtnascim = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtnascim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValDtnascim");

		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIdade { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIdade, 0)); } set { klass.ValIdade = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIdade() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValIdade");

		[DisplayName("Official No.")]
		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIdfuncio, 0)); } set { klass.ValIdfuncio = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIdfuncio() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValIdfuncio");

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValTelephon");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValEmail");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail2 { get { return klass.ValEmail2; } set { klass.ValEmail2 = value; } }
		public bool ShouldSerializeValEmail2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValEmail2");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhotogra { get { return klass.ValPhotogra; } set { klass.ValPhotogra = value; } }
		public bool ShouldSerializeValPhotogra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValPhotogra");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get { return klass.ValDtultcat; } set { klass.ValDtultcat = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtultcat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValDtultcat");

		[DisplayName(">LAST CATEGORY")]
		/// <summary>Field : ">LAST CATEGORY" Tipo: "CF" Formula:  ""</summary>
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		public bool ShouldSerializeValCodcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodcateg");

		[DisplayName("External")]
		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		public bool ValExterna { get { return Convert.ToBoolean(klass.ValExterna); } set { klass.ValExterna = Convert.ToInt32(value); } }
		public bool ShouldSerializeValExterna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValExterna");

		[DisplayName("Internal")]
		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		public bool ValInterna { get { return Convert.ToBoolean(klass.ValInterna); } set { klass.ValInterna = Convert.ToInt32(value); } }
		public bool ShouldSerializeValInterna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValInterna");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodpaise { get { return klass.ValCodpaise; } set { klass.ValCodpaise = value; } }
		public bool ShouldSerializeValCodpaise() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodpaise");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodcntry");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCodregia");

		[DisplayName("Individual notifications")]
		/// <summary>Field : "Individual notifications" Tipo: "L" Formula:  ""</summary>
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }
		public bool ShouldSerializeValNotifind() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValNotifind");

		[DisplayName("Terrain")]
		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		[GeographicAttribute("GS")]
		public CSGenio.framework.Geography.GeographicData ValTerrain { get { return klass.ValTerrain; } set { klass.ValTerrain = value; } }
		public bool ShouldSerializeValTerrain() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValTerrain");

		[DisplayName("Query for external API")]
		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		public string ValExtquery { get { return klass.ValExtquery; } set { klass.ValExtquery = value; } }
		public bool ShouldSerializeValExtquery() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValExtquery");

		[DisplayName("Minimum zoom to load features")]
		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValExtminzm { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExtminzm, 0)); } set { klass.ValExtminzm = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValExtminzm() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValExtminzm");

		[DisplayName("Map height")]
		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		public string ValMapheigh { get { return klass.ValMapheigh; } set { klass.ValMapheigh = value; } }
		public bool ShouldSerializeValMapheigh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValMapheigh");

		[DisplayName("Zoom level")]
		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValZoomlvl { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValZoomlvl, 0)); } set { klass.ValZoomlvl = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValZoomlvl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValZoomlvl");

		[DisplayName("Outline weight")]
		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOutweigh { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutweigh, 0)); } set { klass.ValOutweigh = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOutweigh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValOutweigh");

		[DisplayName("Polyline color")]
		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		public string ValLineclr { get { return klass.ValLineclr; } set { klass.ValLineclr = value; } }
		public bool ShouldSerializeValLineclr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValLineclr");

		[DisplayName("Polygon color")]
		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		public string ValPolyclr { get { return klass.ValPolyclr; } set { klass.ValPolyclr = value; } }
		public bool ShouldSerializeValPolyclr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValPolyclr");

		[DisplayName("Group markers in cluster")]
		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		public bool ValGroupmrk { get { return Convert.ToBoolean(klass.ValGroupmrk); } set { klass.ValGroupmrk = Convert.ToInt32(value); } }
		public bool ShouldSerializeValGroupmrk() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValGroupmrk");

		[DisplayName("Allow feature editing")]
		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		public bool ValCanedit { get { return Convert.ToBoolean(klass.ValCanedit); } set { klass.ValCanedit = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanedit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCanedit");

		[DisplayName("Allow feature cutting")]
		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		public bool ValCancut { get { return Convert.ToBoolean(klass.ValCancut); } set { klass.ValCancut = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCancut() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCancut");

		[DisplayName("Allow feature dragging")]
		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		public bool ValCandrag { get { return Convert.ToBoolean(klass.ValCandrag); } set { klass.ValCandrag = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCandrag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCandrag");

		[DisplayName("Allow feature rotation")]
		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		public bool ValCanrot { get { return Convert.ToBoolean(klass.ValCanrot); } set { klass.ValCanrot = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanrot() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCanrot");

		[DisplayName("Allow feature removal")]
		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		public bool ValCanremov { get { return Convert.ToBoolean(klass.ValCanremov); } set { klass.ValCanremov = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanremov() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCanremov");

		[DisplayName("Allow drawing markers")]
		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		public bool ValDrawmrk { get { return Convert.ToBoolean(klass.ValDrawmrk); } set { klass.ValDrawmrk = Convert.ToInt32(value); } }
		public bool ShouldSerializeValDrawmrk() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValDrawmrk");

		[DisplayName("Allow drawing polylines")]
		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		public bool ValAllowlin { get { return Convert.ToBoolean(klass.ValAllowlin); } set { klass.ValAllowlin = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAllowlin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValAllowlin");

		[DisplayName("Allow drawing polygons")]
		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		public bool ValAllowpol { get { return Convert.ToBoolean(klass.ValAllowpol); } set { klass.ValAllowpol = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAllowpol() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValAllowpol");

		[DisplayName("Allow exporting map")]
		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		public bool ValCanexpor { get { return Convert.ToBoolean(klass.ValCanexpor); } set { klass.ValCanexpor = Convert.ToInt32(value); } }
		public bool ShouldSerializeValCanexpor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValCanexpor");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2.ValZzstate");

		public Pess2() : this(UserContext.Current.User) { }

		public Pess2(User u)
		{
			this.klass = new CSGenioApess2(u);
		}

		public Pess2(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pess2(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pess2(bool isEmpty) : this(isEmpty, null) { }

		public Pess2(CSGenioApess2 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pess2(CSGenioApess2 val) : this(val, null) { }

		public Pess2(CSGenioApess2 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pess2(CSGenioApess2 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApess2 csgenioa)
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
					case "stake":
						if (_stake == null)
							_stake = new Stake(true, _fieldsToSerialize);
						_stake.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Pess2 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Pess2 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApess2>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pess2(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pess2> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApess2>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pess2>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApess2> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApess2>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApess2> All(CriteriaSet args = null)
		{
			return Where<CSGenioApess2>(false, args, numRegs: -1);
		}

		public static List<Pess2> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApess2>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pess2>((r) => new Pess2(r));
		}

// USE /[MANUAL GQT MODEL PESS2]/
	}
}
