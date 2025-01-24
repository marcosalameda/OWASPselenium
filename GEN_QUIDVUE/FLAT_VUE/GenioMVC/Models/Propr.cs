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
	public class Propr : ModelBase
	{
		[JsonIgnore]
		public CSGenioApropr klass { get { return baseklass as CSGenioApropr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCodpropr")]
		public string ValCodpropr { get { return klass.ValCodpropr; } set { klass.ValCodpropr = value; } }

		[DisplayName("Property name")]
		/// <summary>Field : "Property name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Estimated price")]
		/// <summary>Field : "Estimated price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValPrecoest")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoest { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecoest, 2)); } set { klass.ValPrecoest = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCodtppro")]
		public string ValCodtppro { get { return klass.ValCodtppro; } set { klass.ValCodtppro = value; } }
		private Tppro _tppro;
		[DisplayName("Tppro")]
		[ShouldSerialize("Tppro")]
		public virtual Tppro Tppro {
			get {
				if (!this.isEmptyModel && (_tppro == null || (!string.IsNullOrEmpty(ValCodtppro) && (_tppro.isEmptyModel || _tppro.klass.QPrimaryKey != ValCodtppro))))
					_tppro = Models.Tppro.Find(ValCodtppro, m_userContext, Identifier, _fieldsToSerialize);
				if (_tppro == null)
					_tppro = new Models.Tppro(m_userContext, true, _fieldsToSerialize);
				return _tppro;
			}
			set { _tppro = value; }
		}


		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValEndereco")]
		[DataType(DataType.MultilineText)]
		public string ValEndereco { get { return klass.ValEndereco; } set { klass.ValEndereco = value; } }

		[DisplayName("Locale")]
		/// <summary>Field : "Locale" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValLocalida")]
		public string ValLocalida { get { return klass.ValLocalida; } set { klass.ValLocalida = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		private Regio _regio;
		[DisplayName("Regio")]
		[ShouldSerialize("Regio")]
		public virtual Regio Regio {
			get {
				if (!this.isEmptyModel && (_regio == null || (!string.IsNullOrEmpty(ValCodregia) && (_regio.isEmptyModel || _regio.klass.QPrimaryKey != ValCodregia))))
					_regio = Models.Regio.Find(ValCodregia, m_userContext, Identifier, _fieldsToSerialize);
				if (_regio == null)
					_regio = new Models.Regio(m_userContext, true, _fieldsToSerialize);
				return _regio;
			}
			set { _regio = value; }
		}


		[DisplayName("Zip code")]
		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValPostalco")]
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }

		[DisplayName("Postal location")]
		/// <summary>Field : "Postal location" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValPostallo")]
		public string ValPostallo { get { return klass.ValPostallo; } set { klass.ValPostallo = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry {
			get {
				if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry))))
					_cntry = Models.Cntry.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				if (_cntry == null)
					_cntry = new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}


		[DisplayName("Furnished")]
		/// <summary>Field : "Furnished" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValMobilada")]
		public bool ValMobilada { get { return Convert.ToBoolean(klass.ValMobilada); } set { klass.ValMobilada = Convert.ToInt32(value); } }

		[DisplayName("Bathrooms")]
		/// <summary>Field : "Bathrooms" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValQtd_wc")]
		[NumericAttribute(0)]
		public decimal? ValQtd_wc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtd_wc, 0)); } set { klass.ValQtd_wc = Convert.ToDecimal(value); } }

		[DisplayName("Rooms")]
		/// <summary>Field : "Rooms" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValQtdquart")]
		[NumericAttribute(0)]
		public decimal? ValQtdquart { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdquart, 0)); } set { klass.ValQtdquart = Convert.ToDecimal(value); } }

		[DisplayName("Square meters")]
		/// <summary>Field : "Square meters" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValM2")]
		[NumericAttribute(0)]
		public decimal? ValM2 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValM2, 0)); } set { klass.ValM2 = Convert.ToDecimal(value); } }

		[DisplayName("Available from")]
		/// <summary>Field : "Available from" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValDtdispon")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtdispon { get { return klass.ValDtdispon; } set { klass.ValDtdispon = value ?? DateTime.MinValue; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValPhotogra")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhotogra { get { return new ImageModel(klass.ValPhotogra) { Ticket = ValPhotograQTicket }; } set { klass.ValPhotogra = value; } }
		[JsonIgnore]
		public string ValPhotograQTicket = null;

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Geographic coordinate")]
		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCoordgeo")]
		[GeographicAttribute("GG")]
		public string ValCoordgeo { get { return klass.ValCoordgeo; } set { klass.ValCoordgeo = value; } }

		[DisplayName(">SELLER")]
		/// <summary>Field : ">SELLER" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Propr.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		private Pesso _pesso;
		[DisplayName("Pesso")]
		[ShouldSerialize("Pesso")]
		public virtual Pesso Pesso {
			get {
				if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso))))
					_pesso = Models.Pesso.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				if (_pesso == null)
					_pesso = new Models.Pesso(m_userContext, true, _fieldsToSerialize);
				return _pesso;
			}
			set { _pesso = value; }
		}


		[DisplayName(">PERSON COUNTRY")]
		/// <summary>Field : ">PERSON COUNTRY" Tipo: "CE" Formula: ++ "[PESSO->CODCNTRY]"</summary>
		[ShouldSerialize("Propr.ValCodpais1")]
		public string ValCodpais1 { get { return klass.ValCodpais1; } set { klass.ValCodpais1 = value; } }
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		[ShouldSerialize("Pais1")]
		public virtual Pais1 Pais1 {
			get {
				if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodpais1) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodpais1))))
					_pais1 = Models.Pais1.Find(ValCodpais1, m_userContext, Identifier, _fieldsToSerialize);
				if (_pais1 == null)
					_pais1 = new Models.Pais1(m_userContext, true, _fieldsToSerialize);
				return _pais1;
			}
			set { _pais1 = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Propr.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Propr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApropr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Propr(UserContext userContext, CSGenioApropr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioApropr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tppro":
						if (_tppro == null)
							_tppro = new Tppro(m_userContext, true, _fieldsToSerialize);
						_tppro.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regio":
						if (_regio == null)
							_regio = new Regio(m_userContext, true, _fieldsToSerialize);
						_regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pais1":
						if (_pais1 == null)
							_pais1 = new Pais1(m_userContext, true, _fieldsToSerialize);
						_pais1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Propr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApropr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Propr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Propr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApropr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Propr>((r) => new Propr(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PROPR]/
	}
}
