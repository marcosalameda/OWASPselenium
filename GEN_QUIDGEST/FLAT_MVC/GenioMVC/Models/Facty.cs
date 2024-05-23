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
	public class Facty : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfacty klass { get { return baseklass as CSGenioAfacty; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }
		public bool ShouldSerializeValCodfacty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValCodfacty");

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "C" Formula:  ""</summary>
		public string ValType { get { return klass.ValType; } set { klass.ValType = value; } }
		public bool ShouldSerializeValType() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValType");

		[DisplayName("Layer name")]
		/// <summary>Field : "Layer name" Tipo: "C" Formula:  ""</summary>
		public string ValLayrname { get { return klass.ValLayrname; } set { klass.ValLayrname = value; } }
		public bool ShouldSerializeValLayrname() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValLayrname");

		[DisplayName("Icon URL")]
		/// <summary>Field : "Icon URL" Tipo: "C" Formula:  ""</summary>
		public string ValIconurl { get { return klass.ValIconurl; } set { klass.ValIconurl = value; } }
		public bool ShouldSerializeValIconurl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValIconurl");

		[DisplayName("Shadow URL")]
		/// <summary>Field : "Shadow URL" Tipo: "C" Formula:  ""</summary>
		public string ValShadowur { get { return klass.ValShadowur; } set { klass.ValShadowur = value; } }
		public bool ShouldSerializeValShadowur() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValShadowur");

		[DisplayName("Icon anchor (x-axis)")]
		/// <summary>Field : "Icon anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIconancx { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIconancx, 0)); } set { klass.ValIconancx = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIconancx() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValIconancx");

		[DisplayName("Icon anchor (y-axis)")]
		/// <summary>Field : "Icon anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIconancy { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIconancy, 0)); } set { klass.ValIconancy = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIconancy() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValIconancy");

		[DisplayName("Icon height")]
		/// <summary>Field : "Icon height" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIconheig { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIconheig, 0)); } set { klass.ValIconheig = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIconheig() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValIconheig");

		[DisplayName("Icon width")]
		/// <summary>Field : "Icon width" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValIconwid { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValIconwid, 0)); } set { klass.ValIconwid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValIconwid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValIconwid");

		[DisplayName("Popup anchor (x-axis)")]
		/// <summary>Field : "Popup anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValPopupanx { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPopupanx, 0)); } set { klass.ValPopupanx = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPopupanx() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValPopupanx");

		[DisplayName("Popup anchor (y-axis)")]
		/// <summary>Field : "Popup anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValPopupany { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPopupany, 0)); } set { klass.ValPopupany = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPopupany() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValPopupany");

		[DisplayName("Shadow anchor (x-axis)")]
		/// <summary>Field : "Shadow anchor (x-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValShadowax { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValShadowax, 0)); } set { klass.ValShadowax = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValShadowax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValShadowax");

		[DisplayName("Shadow anchor (y-axis)")]
		/// <summary>Field : "Shadow anchor (y-axis)" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValShadoway { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValShadoway, 0)); } set { klass.ValShadoway = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValShadoway() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValShadoway");

		[DisplayName("Shadow height")]
		/// <summary>Field : "Shadow height" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValShadowhe { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValShadowhe, 0)); } set { klass.ValShadowhe = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValShadowhe() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValShadowhe");

		[DisplayName("Shadow width")]
		/// <summary>Field : "Shadow width" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValShadowwi { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValShadowwi, 0)); } set { klass.ValShadowwi = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValShadowwi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValShadowwi");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty.ValZzstate");

		public Facty() : this(UserContext.Current.User) { }

		public Facty(User u)
		{
			this.klass = new CSGenioAfacty(u);
		}

		public Facty(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Facty(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Facty(bool isEmpty) : this(isEmpty, null) { }

		public Facty(CSGenioAfacty val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Facty(CSGenioAfacty val) : this(val, null) { }

		public Facty(CSGenioAfacty val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Facty(CSGenioAfacty val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAfacty csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Facty Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Facty Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfacty>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Facty(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Facty> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfacty>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Facty>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfacty> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfacty>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfacty> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfacty>(false, args, numRegs: -1);
		}

		public static List<Facty> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfacty>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Facty>((r) => new Facty(r));
		}

// USE /[MANUAL GQT MODEL FACTY]/
	}
}
