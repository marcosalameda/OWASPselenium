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
	public class Itemc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAitemc klass { get { return baseklass as CSGenioAitemc; } set { baseklass = value; } }

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
		public string ValCodcatar { get { return klass.ValCodcatar; } set { klass.ValCodcatar = value; } }
		public bool ShouldSerializeValCodcatar() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemc.ValCodcatar");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemc.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpcat { get { return klass.ValCodtpcat; } set { klass.ValCodtpcat = value; } }
		public bool ShouldSerializeValCodtpcat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemc.ValCodtpcat");
		private Cattp _cattp;
		[DisplayName("Cattp")]
		public virtual Cattp Cattp { get { if (!this.isEmptyModel && (_cattp == null || (!string.IsNullOrEmpty(ValCodtpcat) && (_cattp.isEmptyModel || _cattp.klass.QPrimaryKey != ValCodtpcat)))) _cattp = Models.Cattp.Find(ValCodtpcat, Identifier, _fieldsToSerialize); if (_cattp == null) _cattp = new Models.Cattp(true, _fieldsToSerialize); return _cattp; } set { _cattp = value; } }
		public bool ShouldSerializeCattp () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cattp");

		[DisplayName("Category type")]
		/// <summary>Field : "Category type" Tipo: "C" Formula: ++ "[CATTP->TPCATEGO]"</summary>
		public string ValTpcateg { get { return klass.ValTpcateg; } set { klass.ValTpcateg = value; } }
		public bool ShouldSerializeValTpcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemc.ValTpcateg");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Itemc.ValZzstate");

		public Itemc() : this(UserContext.Current.User) { }

		public Itemc(User u)
		{
			this.klass = new CSGenioAitemc(u);
		}

		public Itemc(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemc(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Itemc(bool isEmpty) : this(isEmpty, null) { }

		public Itemc(CSGenioAitemc val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Itemc(CSGenioAitemc val) : this(val, null) { }

		public Itemc(CSGenioAitemc val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Itemc(CSGenioAitemc val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAitemc csgenioa)
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
					case "cattp":
						if (_cattp == null)
							_cattp = new Cattp(true, _fieldsToSerialize);
						_cattp.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Itemc Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Itemc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAitemc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Itemc(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Itemc> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAitemc>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Itemc>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAitemc> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAitemc>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAitemc> All(CriteriaSet args = null)
		{
			return Where<CSGenioAitemc>(false, args, numRegs: -1);
		}

		public static List<Itemc> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAitemc>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Itemc>((r) => new Itemc(r));
		}

// USE /[MANUAL GQT MODEL ITEMC]/
	}
}
