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
	public class Dilin : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdilin klass { get { return baseklass as CSGenioAdilin; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddilin { get { return klass.ValCoddilin; } set { klass.ValCoddilin = value; } }
		public bool ShouldSerializeValCoddilin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValCoddilin");

		[DisplayName(">>DISPATCH")]
		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }
		public bool ShouldSerializeValCoddispa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValCoddispa");
		private Dispa _dispa;
		[DisplayName("Dispa")]
		public virtual Dispa Dispa { get { if (!this.isEmptyModel && (_dispa == null || (!string.IsNullOrEmpty(ValCoddispa) && (_dispa.isEmptyModel || _dispa.klass.QPrimaryKey != ValCoddispa)))) _dispa = Models.Dispa.Find(ValCoddispa, Identifier, _fieldsToSerialize); if (_dispa == null) _dispa = new Models.Dispa(true, _fieldsToSerialize); return _dispa; } set { _dispa = value; } }
		public bool ShouldSerializeDispa () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa");

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValLinenumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLinenumb, 0)); } set { klass.ValLinenumb = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLinenumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValLinenumb");

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		public bool ShouldSerializeValCodprodu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValCodprodu");
		private Produ _produ;
		[DisplayName("Produ")]
		public virtual Produ Produ { get { if (!this.isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu)))) _produ = Models.Produ.Find(ValCodprodu, Identifier, _fieldsToSerialize); if (_produ == null) _produ = new Models.Produ(true, _fieldsToSerialize); return _produ; } set { _produ = value; } }
		public bool ShouldSerializeProdu () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ");

		[DisplayName("Ordered")]
		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOrdered { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrdered, 0)); } set { klass.ValOrdered = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrdered() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValOrdered");

		[DisplayName("Delivered")]
		/// <summary>Field : "Delivered" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDelivere { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDelivere, 0)); } set { klass.ValDelivere = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDelivere() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValDelivere");

		[DisplayName("Outstanding")]
		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[DILIN->ORDERED]-[DILIN->DELIVERE]"</summary>
		[NumericAttribute(0)]
		public decimal? ValOutstand { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutstand, 0)); } set { klass.ValOutstand = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOutstand() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValOutstand");

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[DISPA->DISPADT]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValInstant { get { return klass.ValInstant; } set { klass.ValInstant = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValInstant() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValInstant");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dilin.ValZzstate");

		public Dilin() : this(UserContext.Current.User) { }

		public Dilin(User u)
		{
			this.klass = new CSGenioAdilin(u);
		}

		public Dilin(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dilin(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Dilin(bool isEmpty) : this(isEmpty, null) { }

		public Dilin(CSGenioAdilin val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dilin(CSGenioAdilin val) : this(val, null) { }

		public Dilin(CSGenioAdilin val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Dilin(CSGenioAdilin val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAdilin csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "dispa":
						if (_dispa == null)
							_dispa = new Dispa(true, _fieldsToSerialize);
						_dispa.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "produ":
						if (_produ == null)
							_produ = new Produ(true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Dilin Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Dilin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdilin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Dilin(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Dilin> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdilin>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Dilin>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdilin> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdilin>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdilin> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdilin>(false, args, numRegs: -1);
		}

		public static List<Dilin> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdilin>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dilin>((r) => new Dilin(r));
		}

// USE /[MANUAL GQT MODEL DILIN]/
	}
}
