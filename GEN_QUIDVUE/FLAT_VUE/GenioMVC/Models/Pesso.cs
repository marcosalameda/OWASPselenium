using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Pesso : ModelBase
	{
		[JsonIgnore]
		public CSGenioApesso klass { get { return baseklass as CSGenioApesso; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }

		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		[ShouldSerialize("Cmpny")]
		public virtual Cmpny Cmpny
		{
			get
			{
				if (!isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre))))
					_cmpny = Models.Cmpny.Find(ValCodempre, m_userContext, Identifier, _fieldsToSerialize);
				_cmpny ??= new Models.Cmpny(m_userContext, true, _fieldsToSerialize);
				return _cmpny;
			}
			set { _cmpny = value; }
		}

		[DisplayName("Interested party")]
		/// <summary>Field : "Interested party" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodparte")]
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Genus")]
		/// <summary>Field : "Genus" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValGender")]
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGenero.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("Birth")]
		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValDtnascim")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get { return klass.ValDtnascim; } set { klass.ValDtnascim = value ?? DateTime.MinValue; } }

		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula: + "Idade([PESSO->DTNASCIM],[Today])"</summary>
		[ShouldSerialize("Pesso.ValIdade")]
		[NumericAttribute(0)]
		public decimal? ValIdade { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIdade, 0)); } set { klass.ValIdade = Convert.ToDecimal(value); } }

		[DisplayName("Official No.")]
		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValIdfuncio")]
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIdfuncio, 0)); } set { klass.ValIdfuncio = Convert.ToDecimal(value); } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValEmail2")]
		public string ValEmail2 { get { return klass.ValEmail2; } set { klass.ValEmail2 = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValPhotogra")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhotogra { get { return new ImageModel(klass.ValPhotogra) { Ticket = ValPhotograQTicket }; } set { klass.ValPhotogra = value; } }
		[JsonIgnore]
		public string ValPhotograQTicket = null;

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula: U1 "EVCAT[EVCAT->SINCE][EVCAT->SINCE][Today]"</summary>
		[ShouldSerialize("Pesso.ValDtultcat")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get { return klass.ValDtultcat; } set { klass.ValDtultcat = value ?? DateTime.MinValue; } }

		[DisplayName(">LAST CATEGORY")]
		/// <summary>Field : ">LAST CATEGORY" Tipo: "CE" Formula: U1 "EVCAT[EVCAT->SINCE][EVCAT->CODCATEG][Today]"</summary>
		[ShouldSerialize("Pesso.ValCodcateg")]
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }

		private Categ _categ;
		[DisplayName("Categ")]
		[ShouldSerialize("Categ")]
		public virtual Categ Categ
		{
			get
			{
				if (!isEmptyModel && (_categ == null || (!string.IsNullOrEmpty(ValCodcateg) && (_categ.isEmptyModel || _categ.klass.QPrimaryKey != ValCodcateg))))
					_categ = Models.Categ.Find(ValCodcateg, m_userContext, Identifier, _fieldsToSerialize);
				_categ ??= new Models.Categ(m_userContext, true, _fieldsToSerialize);
				return _categ;
			}
			set { _categ = value; }
		}

		[DisplayName("External")]
		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValExterna")]
		public bool ValExterna { get { return Convert.ToBoolean(klass.ValExterna); } set { klass.ValExterna = Convert.ToInt32(value); } }

		[DisplayName("Internal")]
		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValInterna")]
		public bool ValInterna { get { return Convert.ToBoolean(klass.ValInterna); } set { klass.ValInterna = Convert.ToInt32(value); } }

		[DisplayName("COMPANY PARENTS")]
		/// <summary>Field : "COMPANY PARENTS" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodpaise")]
		public string ValCodpaise { get { return klass.ValCodpaise; } set { klass.ValCodpaise = value; } }

		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry
		{
			get
			{
				if (!isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodpaise) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodpaise))))
					_cntry = Models.Cntry.Find(ValCodpaise, m_userContext, Identifier, _fieldsToSerialize);
				_cntry ??= new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}

		[DisplayName("PERSON'S PARENTS")]
		/// <summary>Field : "PERSON'S PARENTS" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		private Pais1 _pais1;
		[DisplayName("Pais1")]
		[ShouldSerialize("Pais1")]
		public virtual Pais1 Pais1
		{
			get
			{
				if (!isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodcntry) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodcntry))))
					_pais1 = Models.Pais1.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				_pais1 ??= new Models.Pais1(m_userContext, true, _fieldsToSerialize);
				return _pais1;
			}
			set { _pais1 = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }

		private Regi1 _regi1;
		[DisplayName("Regi1")]
		[ShouldSerialize("Regi1")]
		public virtual Regi1 Regi1
		{
			get
			{
				if (!isEmptyModel && (_regi1 == null || (!string.IsNullOrEmpty(ValCodregia) && (_regi1.isEmptyModel || _regi1.klass.QPrimaryKey != ValCodregia))))
					_regi1 = Models.Regi1.Find(ValCodregia, m_userContext, Identifier, _fieldsToSerialize);
				_regi1 ??= new Models.Regi1(m_userContext, true, _fieldsToSerialize);
				return _regi1;
			}
			set { _regi1 = value; }
		}

		[DisplayName("Indiviudal notifications")]
		/// <summary>Field : "Indiviudal notifications" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValNotifind")]
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }

		[DisplayName("Terrain")]
		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValTerrain")]
		[GeographicAttribute("GS")]
		public CSGenio.framework.Geography.GeographicData ValTerrain { get { return klass.ValTerrain; } set { klass.ValTerrain = value; } }

		[DisplayName("Query for external API")]
		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValExtquery")]
		public string ValExtquery { get { return klass.ValExtquery; } set { klass.ValExtquery = value; } }

		[DisplayName("Minimum zoom to load features")]
		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValExtminzm")]
		[NumericAttribute(0)]
		public decimal? ValExtminzm { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExtminzm, 0)); } set { klass.ValExtminzm = Convert.ToDecimal(value); } }

		[DisplayName("Map height")]
		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValMapheigh")]
		public string ValMapheigh { get { return klass.ValMapheigh; } set { klass.ValMapheigh = value; } }

		[DisplayName("Zoom level")]
		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValZoomlvl")]
		[NumericAttribute(0)]
		public decimal? ValZoomlvl { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValZoomlvl, 0)); } set { klass.ValZoomlvl = Convert.ToDecimal(value); } }

		[DisplayName("Outline weight")]
		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValOutweigh")]
		[NumericAttribute(0)]
		public decimal? ValOutweigh { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutweigh, 0)); } set { klass.ValOutweigh = Convert.ToDecimal(value); } }

		[DisplayName("Polyline color")]
		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValLineclr")]
		public string ValLineclr { get { return klass.ValLineclr; } set { klass.ValLineclr = value; } }

		[DisplayName("Polygon color")]
		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValPolyclr")]
		public string ValPolyclr { get { return klass.ValPolyclr; } set { klass.ValPolyclr = value; } }

		[DisplayName("Group markers in cluster")]
		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValGroupmrk")]
		public bool ValGroupmrk { get { return Convert.ToBoolean(klass.ValGroupmrk); } set { klass.ValGroupmrk = Convert.ToInt32(value); } }

		[DisplayName("Allow feature editing")]
		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCanedit")]
		public bool ValCanedit { get { return Convert.ToBoolean(klass.ValCanedit); } set { klass.ValCanedit = Convert.ToInt32(value); } }

		[DisplayName("Allow feature cutting")]
		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCancut")]
		public bool ValCancut { get { return Convert.ToBoolean(klass.ValCancut); } set { klass.ValCancut = Convert.ToInt32(value); } }

		[DisplayName("Allow feature dragging")]
		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCandrag")]
		public bool ValCandrag { get { return Convert.ToBoolean(klass.ValCandrag); } set { klass.ValCandrag = Convert.ToInt32(value); } }

		[DisplayName("Allow feature rotation")]
		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCanrot")]
		public bool ValCanrot { get { return Convert.ToBoolean(klass.ValCanrot); } set { klass.ValCanrot = Convert.ToInt32(value); } }

		[DisplayName("Allow feature removal")]
		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCanremov")]
		public bool ValCanremov { get { return Convert.ToBoolean(klass.ValCanremov); } set { klass.ValCanremov = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing markers")]
		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValDrawmrk")]
		public bool ValDrawmrk { get { return Convert.ToBoolean(klass.ValDrawmrk); } set { klass.ValDrawmrk = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing polylines")]
		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValAllowlin")]
		public bool ValAllowlin { get { return Convert.ToBoolean(klass.ValAllowlin); } set { klass.ValAllowlin = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing polygons")]
		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValAllowpol")]
		public bool ValAllowpol { get { return Convert.ToBoolean(klass.ValAllowpol); } set { klass.ValAllowpol = Convert.ToInt32(value); } }

		[DisplayName("Allow exporting map")]
		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pesso.ValCanexpor")]
		public bool ValCanexpor { get { return Convert.ToBoolean(klass.ValCanexpor); } set { klass.ValCanexpor = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pesso.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pesso(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApesso(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pesso(UserContext userContext, CSGenioApesso val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioApesso csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cmpny":
						_cmpny ??= new Cmpny(m_userContext, true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "categ":
						_categ ??= new Categ(m_userContext, true, _fieldsToSerialize);
						_categ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cntry":
						_cntry ??= new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pais1":
						_pais1 ??= new Pais1(m_userContext, true, _fieldsToSerialize);
						_pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regi1":
						_regi1 ??= new Regi1(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Pesso Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApesso>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pesso(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pesso> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApesso>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pesso>((r) => new Pesso(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PESSO]/
	}
}
