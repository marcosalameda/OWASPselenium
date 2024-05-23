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
	public class Propr : ModelBase
	{
		[JsonIgnore]
		public CSGenioApropr klass { get { return baseklass as CSGenioApropr; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpropr { get { return klass.ValCodpropr; } set { klass.ValCodpropr = value; } }
		public bool ShouldSerializeValCodpropr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodpropr");

		[DisplayName("Property name")]
		/// <summary>Field : "Property name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValName");

		[DisplayName("Estimated price")]
		/// <summary>Field : "Estimated price" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoest { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecoest, 2)); } set { klass.ValPrecoest = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecoest() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValPrecoest");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtppro { get { return klass.ValCodtppro; } set { klass.ValCodtppro = value; } }
		public bool ShouldSerializeValCodtppro() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodtppro");
		private Tppro _tppro;
		[DisplayName("Tppro")]
		public virtual Tppro Tppro { get { if (!this.isEmptyModel && (_tppro == null || (!string.IsNullOrEmpty(ValCodtppro) && (_tppro.isEmptyModel || _tppro.klass.QPrimaryKey != ValCodtppro)))) _tppro = Models.Tppro.Find(ValCodtppro, Identifier, _fieldsToSerialize); if (_tppro == null) _tppro = new Models.Tppro(true, _fieldsToSerialize); return _tppro; } set { _tppro = value; } }
		public bool ShouldSerializeTppro () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tppro");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValEndereco { get { return klass.ValEndereco; } set { klass.ValEndereco = value; } }
		public bool ShouldSerializeValEndereco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValEndereco");

		[DisplayName("Locale")]
		/// <summary>Field : "Locale" Tipo: "C" Formula:  ""</summary>
		public string ValLocalida { get { return klass.ValLocalida; } set { klass.ValLocalida = value; } }
		public bool ShouldSerializeValLocalida() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValLocalida");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodregia");
		private Regio _regio;
		[DisplayName("Regio")]
		public virtual Regio Regio { get { if (!this.isEmptyModel && (_regio == null || (!string.IsNullOrEmpty(ValCodregia) && (_regio.isEmptyModel || _regio.klass.QPrimaryKey != ValCodregia)))) _regio = Models.Regio.Find(ValCodregia, Identifier, _fieldsToSerialize); if (_regio == null) _regio = new Models.Regio(true, _fieldsToSerialize); return _regio; } set { _regio = value; } }
		public bool ShouldSerializeRegio () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio");

		[DisplayName("Zip code")]
		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public string ValPostalco { get { return klass.ValPostalco; } set { klass.ValPostalco = value; } }
		public bool ShouldSerializeValPostalco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValPostalco");

		[DisplayName("Postal location")]
		/// <summary>Field : "Postal location" Tipo: "C" Formula:  ""</summary>
		public string ValPostallo { get { return klass.ValPostallo; } set { klass.ValPostallo = value; } }
		public bool ShouldSerializeValPostallo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValPostallo");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodcntry");
		private Cntry _cntry;
		[DisplayName("Cntry")]
		public virtual Cntry Cntry { get { if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry)))) _cntry = Models.Cntry.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_cntry == null) _cntry = new Models.Cntry(true, _fieldsToSerialize); return _cntry; } set { _cntry = value; } }
		public bool ShouldSerializeCntry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry");

		[DisplayName("Furnished")]
		/// <summary>Field : "Furnished" Tipo: "L" Formula:  ""</summary>
		public bool ValMobilada { get { return Convert.ToBoolean(klass.ValMobilada); } set { klass.ValMobilada = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMobilada() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValMobilada");

		[DisplayName("Bathrooms")]
		/// <summary>Field : "Bathrooms" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQtd_wc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtd_wc, 0)); } set { klass.ValQtd_wc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtd_wc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValQtd_wc");

		[DisplayName("Rooms")]
		/// <summary>Field : "Rooms" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdquart { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdquart, 0)); } set { klass.ValQtdquart = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtdquart() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValQtdquart");

		[DisplayName("Square meters")]
		/// <summary>Field : "Square meters" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValM2 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValM2, 0)); } set { klass.ValM2 = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValM2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValM2");

		[DisplayName("Available from")]
		/// <summary>Field : "Available from" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtdispon { get { return klass.ValDtdispon; } set { klass.ValDtdispon = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtdispon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValDtdispon");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhotogra { get { return klass.ValPhotogra; } set { klass.ValPhotogra = value; } }
		public bool ShouldSerializeValPhotogra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValPhotogra");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValDescript");

		[DisplayName("Geographic coordinate")]
		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		[GeographicAttribute("GG")]
		public string ValCoordgeo { get { return klass.ValCoordgeo; } set { klass.ValCoordgeo = value; } }
		public bool ShouldSerializeValCoordgeo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCoordgeo");

		[DisplayName(">SELLER")]
		/// <summary>Field : ">SELLER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodpesso");
		private Pesso _pesso;
		[DisplayName("Pesso")]
		public virtual Pesso Pesso { get { if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso)))) _pesso = Models.Pesso.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pesso == null) _pesso = new Models.Pesso(true, _fieldsToSerialize); return _pesso; } set { _pesso = value; } }
		public bool ShouldSerializePesso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso");

		[DisplayName(">PERSON COUNTRY")]
		/// <summary>Field : ">PERSON COUNTRY" Tipo: "CE" Formula: ++ "[PESSO->CODCNTRY]"</summary>
		public string ValCodpais1 { get { return klass.ValCodpais1; } set { klass.ValCodpais1 = value; } }
		public bool ShouldSerializeValCodpais1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValCodpais1");
		private Pais1 _pais1;
		[DisplayName("Pais1")]
		public virtual Pais1 Pais1 { get { if (!this.isEmptyModel && (_pais1 == null || (!string.IsNullOrEmpty(ValCodpais1) && (_pais1.isEmptyModel || _pais1.klass.QPrimaryKey != ValCodpais1)))) _pais1 = Models.Pais1.Find(ValCodpais1, Identifier, _fieldsToSerialize); if (_pais1 == null) _pais1 = new Models.Pais1(true, _fieldsToSerialize); return _pais1; } set { _pais1 = value; } }
		public bool ShouldSerializePais1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pais1");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Propr.ValZzstate");

		public Propr() : this(UserContext.Current.User) { }

		public Propr(User u)
		{
			this.klass = new CSGenioApropr(u);
		}

		public Propr(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Propr(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Propr(bool isEmpty) : this(isEmpty, null) { }

		public Propr(CSGenioApropr val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Propr(CSGenioApropr val) : this(val, null) { }

		public Propr(CSGenioApropr val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Propr(CSGenioApropr val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_tppro = new Tppro(true, _fieldsToSerialize);
						_tppro.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regio":
						if (_regio == null)
							_regio = new Regio(true, _fieldsToSerialize);
						_regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pais1":
						if (_pais1 == null)
							_pais1 = new Pais1(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Propr Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Propr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApropr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Propr(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Propr> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApropr>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Propr>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApropr> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApropr>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApropr> All(CriteriaSet args = null)
		{
			return Where<CSGenioApropr>(false, args, numRegs: -1);
		}

		public static List<Propr> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApropr>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Propr>((r) => new Propr(r));
		}

// USE /[MANUAL GQT MODEL PROPR]/
	}
}
