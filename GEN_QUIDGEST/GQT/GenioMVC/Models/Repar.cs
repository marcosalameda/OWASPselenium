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
	public class Repar : ModelBase
	{
		[JsonIgnore]
		public CSGenioArepar klass { get { return baseklass as CSGenioArepar; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrepar { get { return klass.ValCodrepar; } set { klass.ValCodrepar = value; } }
		public bool ShouldSerializeValCodrepar() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodrepar");

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula: ++ "[EQUIP->CODEMPRE]"</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodempre");
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		public virtual Cmpny Cmpny { get { if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre)))) _cmpny = Models.Cmpny.Find(ValCodempre, Identifier, _fieldsToSerialize); if (_cmpny == null) _cmpny = new Models.Cmpny(true, _fieldsToSerialize); return _cmpny; } set { _cmpny = value; } }
		public bool ShouldSerializeCmpny () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny");

		[DisplayName("Fixed in")]
		/// <summary>Field : "Fixed in" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtrepara { get { return klass.ValDtrepara; } set { klass.ValDtrepara = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtrepara() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValDtrepara");

		[DisplayName("No rumour in the Company")]
		/// <summary>Field : "No rumour in the Company" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrrepara { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrrepara, 0)); } set { klass.ValNrrepara = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNrrepara() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValNrrepara");

		[DisplayName("Technical area")]
		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipoarea { get { return klass.ValTipoarea; } set { klass.ValTipoarea = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipoarea { get { return new SelectList(CSGenio.business.ArrayAreatecn.GetDictionary(), "Key", "Value", ValTipoarea); } set { ValTipoarea = value.SelectedValue as string; } }
		public bool ShouldSerializeValTipoarea() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValTipoarea");

		[DisplayName(">SPECIALTY")]
		/// <summary>Field : ">SPECIALTY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodespec { get { return klass.ValCodespec; } set { klass.ValCodespec = value; } }
		public bool ShouldSerializeValCodespec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodespec");
		private Speci _speci;
		[DisplayName("Speci")]
		public virtual Speci Speci { get { if (!this.isEmptyModel && (_speci == null || (!string.IsNullOrEmpty(ValCodespec) && (_speci.isEmptyModel || _speci.klass.QPrimaryKey != ValCodespec)))) _speci = Models.Speci.Find(ValCodespec, Identifier, _fieldsToSerialize); if (_speci == null) _speci = new Models.Speci(true, _fieldsToSerialize); return _speci; } set { _speci = value; } }
		public bool ShouldSerializeSpeci () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Speci");

		[DisplayName(">CATEGORy")]
		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		public bool ShouldSerializeValCodcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodcateg");
		private Cate1 _cate1;
		[DisplayName("Cate1")]
		public virtual Cate1 Cate1 { get { if (!this.isEmptyModel && (_cate1 == null || (!string.IsNullOrEmpty(ValCodcateg) && (_cate1.isEmptyModel || _cate1.klass.QPrimaryKey != ValCodcateg)))) _cate1 = Models.Cate1.Find(ValCodcateg, Identifier, _fieldsToSerialize); if (_cate1 == null) _cate1 = new Models.Cate1(true, _fieldsToSerialize); return _cate1; } set { _cate1 = value; } }
		public bool ShouldSerializeCate1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate1");

		[DisplayName(">REPAIRER")]
		/// <summary>Field : ">REPAIRER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValCodpesso");
		private Pesso _pesso;
		[DisplayName("Pesso")]
		public virtual Pesso Pesso { get { if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso)))) _pesso = Models.Pesso.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pesso == null) _pesso = new Models.Pesso(true, _fieldsToSerialize); return _pesso; } set { _pesso = value; } }
		public bool ShouldSerializePesso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso");

		[DisplayName("Description of the repair")]
		/// <summary>Field : "Description of the repair" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValDescript");

		[DisplayName("Spent on hours")]
		/// <summary>Field : "Spent on hours" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValHours { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValHours, 0)); } set { klass.ValHours = Convert.ToDouble(value); } }
		public bool ShouldSerializeValHours() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValHours");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Repar.ValZzstate");

		public Repar() : this(UserContext.Current.User) { }

		public Repar(User u)
		{
			this.klass = new CSGenioArepar(u);
		}

		public Repar(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Repar(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Repar(bool isEmpty) : this(isEmpty, null) { }

		public Repar(CSGenioArepar val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Repar(CSGenioArepar val) : this(val, null) { }

		public Repar(CSGenioArepar val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Repar(CSGenioArepar val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArepar csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						if (_equip == null)
							_equip = new Equip(true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cmpny":
						if (_cmpny == null)
							_cmpny = new Cmpny(true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "speci":
						if (_speci == null)
							_speci = new Speci(true, _fieldsToSerialize);
						_speci.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cate1":
						if (_cate1 == null)
							_cate1 = new Cate1(true, _fieldsToSerialize);
						_cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Repar Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Repar Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArepar>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Repar(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Repar> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArepar>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Repar>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArepar> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArepar>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArepar> All(CriteriaSet args = null)
		{
			return Where<CSGenioArepar>(false, args, numRegs: -1);
		}

		public static List<Repar> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArepar>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Repar>((r) => new Repar(r));
		}

// USE /[MANUAL GQT MODEL REPAR]/
	}
}
