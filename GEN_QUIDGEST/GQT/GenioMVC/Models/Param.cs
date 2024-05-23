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
	public class Param : ModelBase
	{
		[JsonIgnore]
		public CSGenioAparam klass { get { return baseklass as CSGenioAparam; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodparam { get { return klass.ValCodparam; } set { klass.ValCodparam = value; } }
		public bool ShouldSerializeValCodparam() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValCodparam");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		public bool ShouldSerializeValCodkinde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValCodkinde");
		private Kinde _kinde;
		[DisplayName("Kinde")]
		public virtual Kinde Kinde { get { if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde)))) _kinde = Models.Kinde.Find(ValCodkinde, Identifier, _fieldsToSerialize); if (_kinde == null) _kinde = new Models.Kinde(true, _fieldsToSerialize); return _kinde; } set { _kinde = value; } }
		public bool ShouldSerializeKinde () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Kinde");

		[DisplayName("Parameter")]
		/// <summary>Field : "Parameter" Tipo: "C" Formula:  ""</summary>
		public string ValParameter { get { return klass.ValParameter; } set { klass.ValParameter = value; } }
		public bool ShouldSerializeValParameter() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValParameter");

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Datatype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDatatype { get { return klass.ValDatatype; } set { klass.ValDatatype = value; } }
		[JsonIgnore]
		public SelectList ArrayValdatatype { get { return new SelectList(CSGenio.business.ArrayDatatype.GetDictionary(), "Key", "Value", ValDatatype); } set { ValDatatype = value.SelectedValue as string; } }
		public bool ShouldSerializeValDatatype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValDatatype");

		[DisplayName("Decimal places")]
		/// <summary>Field : "Decimal places" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Decplace", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValDecimalplaces { get { return klass.ValDecimalplaces; } set { klass.ValDecimalplaces = value; } }
		[JsonIgnore]
		public SelectList ArrayValdecimalplaces { get { return new SelectList(CSGenio.business.ArrayDecplace.GetDictionary(), "Key", "Value", ValDecimalplaces); } set { ValDecimalplaces = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValDecimalplaces() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValDecimalplaces");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Param.ValZzstate");

		public Param() : this(UserContext.Current.User) { }

		public Param(User u)
		{
			this.klass = new CSGenioAparam(u);
		}

		public Param(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Param(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Param(bool isEmpty) : this(isEmpty, null) { }

		public Param(CSGenioAparam val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Param(CSGenioAparam val) : this(val, null) { }

		public Param(CSGenioAparam val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Param(CSGenioAparam val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAparam csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "kinde":
						if (_kinde == null)
							_kinde = new Kinde(true, _fieldsToSerialize);
						_kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Param Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Param Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAparam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Param(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Param> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAparam>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Param>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAparam> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAparam>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAparam> All(CriteriaSet args = null)
		{
			return Where<CSGenioAparam>(false, args, numRegs: -1);
		}

		public static List<Param> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAparam>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Param>((r) => new Param(r));
		}

// USE /[MANUAL GQT MODEL PARAM]/
	}
}
