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
	public class Asset : ModelBase
	{
		[JsonIgnore]
		public CSGenioAasset klass { get { return baseklass as CSGenioAasset; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		public bool ShouldSerializeValCodasset() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValCodasset");

		[DisplayName("Identification name")]
		/// <summary>Field : "Identification name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValName");

		[DisplayName("Asset number")]
		/// <summary>Field : "Asset number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValAssetnum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValAssetnum, 0)); } set { klass.ValAssetnum = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValAssetnum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValAssetnum");

		[DisplayName("Asset type")]
		/// <summary>Field : "Asset type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Assettyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAssettyp { get { return klass.ValAssettyp; } set { klass.ValAssettyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValassettyp { get { return new SelectList(CSGenio.business.ArrayAssettyp.GetDictionary(), "Key", "Value", ValAssettyp); } set { ValAssettyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValAssettyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValAssettyp");

		[DisplayName("Identifier type")]
		/// <summary>Field : "Identifier type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Identtyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValIdenttyp { get { return klass.ValIdenttyp; } set { klass.ValIdenttyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValidenttyp { get { return new SelectList(CSGenio.business.ArrayIdenttyp.GetDictionary(), "Key", "Value", ValIdenttyp); } set { ValIdenttyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValIdenttyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValIdenttyp");

		[DisplayName("GRAI – Global Returnable Asset Identifier")]
		/// <summary>Field : "GRAI – Global Returnable Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public string ValGrai { get { return klass.ValGrai; } set { klass.ValGrai = value; } }
		public bool ShouldSerializeValGrai() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValGrai");

		[DisplayName("GIAI – Global Individual Asset Identifier")]
		/// <summary>Field : "GIAI – Global Individual Asset Identifier" Tipo: "C" Formula:  ""</summary>
		public string ValGiai { get { return klass.ValGiai; } set { klass.ValGiai = value; } }
		public bool ShouldSerializeValGiai() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValGiai");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }
		public bool ShouldSerializeValPhoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValPhoto");

		[DisplayName(">>Manufacturer")]
		/// <summary>Field : ">>Manufacturer" Tipo: "CE" Formula:  ""</summary>
		public string ValCodmanuf { get { return klass.ValCodmanuf; } set { klass.ValCodmanuf = value; } }
		public bool ShouldSerializeValCodmanuf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValCodmanuf");
		private Manuf _manuf;
		[DisplayName("Manuf")]
		public virtual Manuf Manuf { get { if (!this.isEmptyModel && (_manuf == null || (!string.IsNullOrEmpty(ValCodmanuf) && (_manuf.isEmptyModel || _manuf.klass.QPrimaryKey != ValCodmanuf)))) _manuf = Models.Manuf.Find(ValCodmanuf, Identifier, _fieldsToSerialize); if (_manuf == null) _manuf = new Models.Manuf(true, _fieldsToSerialize); return _manuf; } set { _manuf = value; } }
		public bool ShouldSerializeManuf () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manuf");

		[DisplayName(">>Kind of equipment")]
		/// <summary>Field : ">>Kind of equipment" Tipo: "CE" Formula:  ""</summary>
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		public bool ShouldSerializeValCodkinde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValCodkinde");
		private Kinde _kinde;
		[DisplayName("Kinde")]
		public virtual Kinde Kinde { get { if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde)))) _kinde = Models.Kinde.Find(ValCodkinde, Identifier, _fieldsToSerialize); if (_kinde == null) _kinde = new Models.Kinde(true, _fieldsToSerialize); return _kinde; } set { _kinde = value; } }
		public bool ShouldSerializeKinde () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Kinde");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Asset.ValZzstate");

		public Asset() : this(UserContext.Current.User) { }

		public Asset(User u)
		{
			this.klass = new CSGenioAasset(u);
		}

		public Asset(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Asset(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Asset(bool isEmpty) : this(isEmpty, null) { }

		public Asset(CSGenioAasset val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Asset(CSGenioAasset val) : this(val, null) { }

		public Asset(CSGenioAasset val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Asset(CSGenioAasset val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAasset csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "manuf":
						if (_manuf == null)
							_manuf = new Manuf(true, _fieldsToSerialize);
						_manuf.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Asset Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Asset Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAasset>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Asset(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Asset> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAasset>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Asset>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAasset> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAasset>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAasset> All(CriteriaSet args = null)
		{
			return Where<CSGenioAasset>(false, args, numRegs: -1);
		}

		public static List<Asset> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAasset>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Asset>((r) => new Asset(r));
		}

		public StatusMessage carga_Manuals(string idsrc)
		{
			StatusMessage Qresult = null;
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			Qresult = this.klass.carga_Manuals(idsrc,sp,u);

			return Qresult;
		}

		public StatusMessage carga_Parameters(string idsrc)
		{
			StatusMessage Qresult = null;
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			Qresult = this.klass.carga_Parameters(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL ASSET]/
	}
}
