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
	public class Pess3 : ModelBase
	{
		[JsonIgnore]
		public CSGenioApess3 klass { get { return baseklass as CSGenioApess3; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodempre")]
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

		[DisplayName(">INTERESTED PARTY")]
		/// <summary>Field : ">INTERESTED PARTY" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodparte")]
		public string ValCodparte { get { return klass.ValCodparte; } set { klass.ValCodparte = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValGender")]
		[DataArray("Genero", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGenero.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("Birth")]
		/// <summary>Field : "Birth" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValDtnascim")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtnascim { get { return klass.ValDtnascim; } set { klass.ValDtnascim = value ?? DateTime.MinValue; } }

		[DisplayName("Age")]
		/// <summary>Field : "Age" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValIdade")]
		[NumericAttribute(0)]
		public decimal? ValIdade { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIdade, 0)); } set { klass.ValIdade = Convert.ToDecimal(value); } }

		[DisplayName("Official No.")]
		/// <summary>Field : "Official No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValIdfuncio")]
		[NumericAttribute(0)]
		public decimal? ValIdfuncio { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValIdfuncio, 0)); } set { klass.ValIdfuncio = Convert.ToDecimal(value); } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValEmail2")]
		public string ValEmail2 { get { return klass.ValEmail2; } set { klass.ValEmail2 = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValPhotogra")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhotogra { get { return new ImageModel(klass.ValPhotogra) { Ticket = ValPhotograQTicket }; } set { klass.ValPhotogra = value; } }
		[JsonIgnore]
		public string ValPhotograQTicket = null;

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValDtultcat")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultcat { get { return klass.ValDtultcat; } set { klass.ValDtultcat = value ?? DateTime.MinValue; } }

		[DisplayName(">LAST CATEGORY")]
		/// <summary>Field : ">LAST CATEGORY" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodcateg")]
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }

		[DisplayName("External")]
		/// <summary>Field : "External" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValExterna")]
		public bool ValExterna { get { return Convert.ToBoolean(klass.ValExterna); } set { klass.ValExterna = Convert.ToInt32(value); } }

		[DisplayName("Internal")]
		/// <summary>Field : "Internal" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValInterna")]
		public bool ValInterna { get { return Convert.ToBoolean(klass.ValInterna); } set { klass.ValInterna = Convert.ToInt32(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodpaise")]
		public string ValCodpaise { get { return klass.ValCodpaise; } set { klass.ValCodpaise = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }

		[DisplayName("Notificações Individuais")]
		/// <summary>Field : "Notificações Individuais" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValNotifind")]
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }

		[DisplayName("Terrain")]
		/// <summary>Field : "Terrain" Tipo: "GS" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValTerrain")]
		[GeographicAttribute("GS")]
		public CSGenio.framework.Geography.GeographicData ValTerrain { get { return klass.ValTerrain; } set { klass.ValTerrain = value; } }

		[DisplayName("Query for external API")]
		/// <summary>Field : "Query for external API" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValExtquery")]
		public string ValExtquery { get { return klass.ValExtquery; } set { klass.ValExtquery = value; } }

		[DisplayName("Minimum zoom to load features")]
		/// <summary>Field : "Minimum zoom to load features" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValExtminzm")]
		[NumericAttribute(0)]
		public decimal? ValExtminzm { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValExtminzm, 0)); } set { klass.ValExtminzm = Convert.ToDecimal(value); } }

		[DisplayName("Map height")]
		/// <summary>Field : "Map height" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValMapheigh")]
		public string ValMapheigh { get { return klass.ValMapheigh; } set { klass.ValMapheigh = value; } }

		[DisplayName("Zoom level")]
		/// <summary>Field : "Zoom level" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValZoomlvl")]
		[NumericAttribute(0)]
		public decimal? ValZoomlvl { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValZoomlvl, 0)); } set { klass.ValZoomlvl = Convert.ToDecimal(value); } }

		[DisplayName("Outline weight")]
		/// <summary>Field : "Outline weight" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValOutweigh")]
		[NumericAttribute(0)]
		public decimal? ValOutweigh { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValOutweigh, 0)); } set { klass.ValOutweigh = Convert.ToDecimal(value); } }

		[DisplayName("Polyline color")]
		/// <summary>Field : "Polyline color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValLineclr")]
		public string ValLineclr { get { return klass.ValLineclr; } set { klass.ValLineclr = value; } }

		[DisplayName("Polygon color")]
		/// <summary>Field : "Polygon color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValPolyclr")]
		public string ValPolyclr { get { return klass.ValPolyclr; } set { klass.ValPolyclr = value; } }

		[DisplayName("Group markers in cluster")]
		/// <summary>Field : "Group markers in cluster" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValGroupmrk")]
		public bool ValGroupmrk { get { return Convert.ToBoolean(klass.ValGroupmrk); } set { klass.ValGroupmrk = Convert.ToInt32(value); } }

		[DisplayName("Allow feature editing")]
		/// <summary>Field : "Allow feature editing" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCanedit")]
		public bool ValCanedit { get { return Convert.ToBoolean(klass.ValCanedit); } set { klass.ValCanedit = Convert.ToInt32(value); } }

		[DisplayName("Allow feature cutting")]
		/// <summary>Field : "Allow feature cutting" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCancut")]
		public bool ValCancut { get { return Convert.ToBoolean(klass.ValCancut); } set { klass.ValCancut = Convert.ToInt32(value); } }

		[DisplayName("Allow feature dragging")]
		/// <summary>Field : "Allow feature dragging" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCandrag")]
		public bool ValCandrag { get { return Convert.ToBoolean(klass.ValCandrag); } set { klass.ValCandrag = Convert.ToInt32(value); } }

		[DisplayName("Allow feature rotation")]
		/// <summary>Field : "Allow feature rotation" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCanrot")]
		public bool ValCanrot { get { return Convert.ToBoolean(klass.ValCanrot); } set { klass.ValCanrot = Convert.ToInt32(value); } }

		[DisplayName("Allow feature removal")]
		/// <summary>Field : "Allow feature removal" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCanremov")]
		public bool ValCanremov { get { return Convert.ToBoolean(klass.ValCanremov); } set { klass.ValCanremov = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing markers")]
		/// <summary>Field : "Allow drawing markers" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValDrawmrk")]
		public bool ValDrawmrk { get { return Convert.ToBoolean(klass.ValDrawmrk); } set { klass.ValDrawmrk = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing polylines")]
		/// <summary>Field : "Allow drawing polylines" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValAllowlin")]
		public bool ValAllowlin { get { return Convert.ToBoolean(klass.ValAllowlin); } set { klass.ValAllowlin = Convert.ToInt32(value); } }

		[DisplayName("Allow drawing polygons")]
		/// <summary>Field : "Allow drawing polygons" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValAllowpol")]
		public bool ValAllowpol { get { return Convert.ToBoolean(klass.ValAllowpol); } set { klass.ValAllowpol = Convert.ToInt32(value); } }

		[DisplayName("Allow exporting map")]
		/// <summary>Field : "Allow exporting map" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Pess3.ValCanexpor")]
		public bool ValCanexpor { get { return Convert.ToBoolean(klass.ValCanexpor); } set { klass.ValCanexpor = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pess3.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pess3(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApess3(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pess3(UserContext userContext, CSGenioApess3 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioApess3 csgenioa)
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
		public static Pess3 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApess3>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pess3(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pess3> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApess3>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pess3>((r) => new Pess3(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PESS3]/
	}
}
