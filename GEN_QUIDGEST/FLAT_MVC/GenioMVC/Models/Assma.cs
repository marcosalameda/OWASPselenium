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
	public class Assma : ModelBase
	{
		[JsonIgnore]
		public CSGenioAassma klass { get { return baseklass as CSGenioAassma; } set { baseklass = value; } }

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
		public string ValCodassma { get { return klass.ValCodassma; } set { klass.ValCodassma = value; } }
		public bool ShouldSerializeValCodassma() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValCodassma");

		[DisplayName(">>Asset")]
		/// <summary>Field : ">>Asset" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		public bool ShouldSerializeValCodasset() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValCodasset");
		private Asset _asset;
		[DisplayName("Asset")]
		public virtual Asset Asset { get { if (!this.isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset)))) _asset = Models.Asset.Find(ValCodasset, Identifier, _fieldsToSerialize); if (_asset == null) _asset = new Models.Asset(true, _fieldsToSerialize); return _asset; } set { _asset = value; } }
		public bool ShouldSerializeAsset () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset");

		[DisplayName("Manual name")]
		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValName");

		[DisplayName("Digital document")]
		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDigdocum", false, true, false, false)]
		public string ValDigdocum { get { return klass.ValDigdocum; } set { klass.ValDigdocum = value; } }
		public string ValDigdocumfk { get { return klass.ValDigdocumfk; } set { klass.ValDigdocumfk = value; } }
		public bool ShouldSerializeValDigdocum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValDigdocum");

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValNotes { get { return klass.ValNotes; } set { klass.ValNotes = value; } }
		public bool ShouldSerializeValNotes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValNotes");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Assma.ValZzstate");

		public Assma() : this(UserContext.Current.User) { }

		public Assma(User u)
		{
			this.klass = new CSGenioAassma(u);
		}

		public Assma(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Assma(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Assma(bool isEmpty) : this(isEmpty, null) { }

		public Assma(CSGenioAassma val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Assma(CSGenioAassma val) : this(val, null) { }

		public Assma(CSGenioAassma val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Assma(CSGenioAassma val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAassma csgenioa)
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
		public static Assma Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Assma Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAassma>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Assma(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Assma> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAassma>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Assma>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAassma> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAassma>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAassma> All(CriteriaSet args = null)
		{
			return Where<CSGenioAassma>(false, args, numRegs: -1);
		}

		public static List<Assma> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAassma>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Assma>((r) => new Assma(r));
		}

// USE /[MANUAL GQT MODEL ASSMA]/
	}
}
