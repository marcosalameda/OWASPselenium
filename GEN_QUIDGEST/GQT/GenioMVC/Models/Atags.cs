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
	public class Atags : ModelBase
	{
		[JsonIgnore]
		public CSGenioAatags klass { get { return baseklass as CSGenioAatags; } set { baseklass = value; } }

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
		public string ValCodtags { get { return klass.ValCodtags; } set { klass.ValCodtags = value; } }
		public bool ShouldSerializeValCodtags() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValCodtags");

		[DisplayName("Tag name")]
		/// <summary>Field : "Tag name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValName");

		[DisplayName("Background color of the tag")]
		/// <summary>Field : "Background color of the tag" Tipo: "C" Formula:  ""</summary>
		public string ValColor { get { return klass.ValColor; } set { klass.ValColor = value; } }
		public bool ShouldSerializeValColor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValColor");

		[DisplayName("Icon associated with the tag")]
		/// <summary>Field : "Icon associated with the tag" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Assettags", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValIcon { get { return klass.ValIcon; } set { klass.ValIcon = value; } }
		[JsonIgnore]
		public SelectList ArrayValicon { get { return new SelectList(CSGenio.business.ArrayAssettags.GetDictionary(), "Key", "Value", ValIcon); } set { ValIcon = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValIcon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValIcon");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		public bool ShouldSerializeValCodasset() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValCodasset");
		private Asset _asset;
		[DisplayName("Asset")]
		public virtual Asset Asset { get { if (!this.isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset)))) _asset = Models.Asset.Find(ValCodasset, Identifier, _fieldsToSerialize); if (_asset == null) _asset = new Models.Asset(true, _fieldsToSerialize); return _asset; } set { _asset = value; } }
		public bool ShouldSerializeAsset () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Atags.ValZzstate");

		public Atags() : this(UserContext.Current.User) { }

		public Atags(User u)
		{
			this.klass = new CSGenioAatags(u);
		}

		public Atags(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Atags(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Atags(bool isEmpty) : this(isEmpty, null) { }

		public Atags(CSGenioAatags val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Atags(CSGenioAatags val) : this(val, null) { }

		public Atags(CSGenioAatags val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Atags(CSGenioAatags val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAatags csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						if (_asset == null)
							_asset = new Asset(true, _fieldsToSerialize);
						_asset.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Atags Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Atags Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAatags>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Atags(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Atags> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAatags>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Atags>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAatags> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAatags>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAatags> All(CriteriaSet args = null)
		{
			return Where<CSGenioAatags>(false, args, numRegs: -1);
		}

		public static List<Atags> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAatags>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Atags>((r) => new Atags(r));
		}

// USE /[MANUAL GQT MODEL ATAGS]/
	}
}
