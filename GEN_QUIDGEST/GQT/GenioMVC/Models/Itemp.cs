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
	public class Itemp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitemp klass { get { return baseklass as CSGenioAitemp; } set { baseklass = value; } }

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
		public string ValCoditemp { get { return klass.ValCoditemp; } set { klass.ValCoditemp = value; } }
		public bool ShouldSerializeValCoditemp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValCoditemp");

		[DisplayName("Item")]
		/// <summary>Field : "Item" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("Property Name")]
		/// <summary>Field : "Property Name" Tipo: "C" Formula:  ""</summary>
		public string ValPropid { get { return klass.ValPropid; } set { klass.ValPropid = value; } }
		public bool ShouldSerializeValPropid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValPropid");

		[DisplayName("Property Value")]
		/// <summary>Field : "Property Value" Tipo: "C" Formula:  ""</summary>
		public string ValPropval { get { return klass.ValPropval; } set { klass.ValPropval = value; } }
		public bool ShouldSerializeValPropval() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValPropval");

		[DisplayName("Property Type")]
		/// <summary>Field : "Property Type" Tipo: "C" Formula:  ""</summary>
		public string ValProptype { get { return klass.ValProptype; } set { klass.ValProptype = value; } }
		public bool ShouldSerializeValProptype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValProptype");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemp.ValZzstate");

		public Itemp() : this(UserContext.Current.User) { }

		public Itemp(User u)
		{
			this.klass = new CSGenioAitemp(u);
		}

		public Itemp(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemp(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Itemp(bool isEmpty) : this(isEmpty, null) { }

		public Itemp(CSGenioAitemp val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemp(CSGenioAitemp val) : this(val, null) { }

		public Itemp(CSGenioAitemp val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Itemp(CSGenioAitemp val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAitemp csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "item":
						if (_item == null)
							_item = new Item(true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Itemp Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Itemp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitemp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Itemp(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Itemp> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAitemp>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Itemp>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAitemp> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAitemp>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAitemp> All(CriteriaSet args = null)
		{
			return Where<CSGenioAitemp>(false, args, numRegs: -1);
		}

		public static List<Itemp> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitemp>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Itemp>((r) => new Itemp(r));
		}

// USE /[MANUAL GQT MODEL ITEMP]/
	}
}
