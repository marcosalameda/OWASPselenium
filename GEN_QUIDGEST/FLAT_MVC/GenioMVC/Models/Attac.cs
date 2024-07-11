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
	public class Attac : ModelBase
	{
		[JsonIgnore]
		public CSGenioAattac klass { get { return baseklass as CSGenioAattac; } set { baseklass = value; } }

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
		public string ValCodattac { get { return klass.ValCodattac; } set { klass.ValCodattac = value; } }
		public bool ShouldSerializeValCodattac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValCodattac");

		[DisplayName(">>ASSET")]
		/// <summary>Field : ">>ASSET" Tipo: "CE" Formula:  ""</summary>
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		public bool ShouldSerializeValCodasset() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValCodasset");
		private Asset _asset;
		[DisplayName("Asset")]
		public virtual Asset Asset { get { if (!this.isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset)))) _asset = Models.Asset.Find(ValCodasset, Identifier, _fieldsToSerialize); if (_asset == null) _asset = new Models.Asset(true, _fieldsToSerialize); return _asset; } set { _asset = value; } }
		public bool ShouldSerializeAsset () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset");

		[DisplayName("Attached")]
		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValAttached { get { return klass.ValAttached; } set { klass.ValAttached = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValAttached() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValAttached");

		[DisplayName("Note")]
		/// <summary>Field : "Note" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValNote { get { return klass.ValNote; } set { klass.ValNote = value; } }
		public bool ShouldSerializeValNote() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValNote");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocument", false, true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }
		public bool ShouldSerializeValDocument() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValDocument");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Attac.ValZzstate");

		public Attac() : this(UserContext.Current.User) { }

		public Attac(User u)
		{
			this.klass = new CSGenioAattac(u);
		}

		public Attac(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Attac(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Attac(bool isEmpty) : this(isEmpty, null) { }

		public Attac(CSGenioAattac val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Attac(CSGenioAattac val) : this(val, null) { }

		public Attac(CSGenioAattac val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Attac(CSGenioAattac val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAattac csgenioa)
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
		public static Attac Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Attac Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAattac>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Attac(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Attac> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAattac>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Attac>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAattac> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAattac>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAattac> All(CriteriaSet args = null)
		{
			return Where<CSGenioAattac>(false, args, numRegs: -1);
		}

		public static List<Attac> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAattac>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Attac>((r) => new Attac(r));
		}

// USE /[MANUAL GQT MODEL ATTAC]/
	}
}
