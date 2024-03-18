using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

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
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValCodasset")]
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }

		[DisplayName("Identification name")]
		/// <summary>Field : "Identification name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Asset number")]
		/// <summary>Field : "Asset number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValAssetnum")]
		[NumericAttribute(0)]
		public decimal? ValAssetnum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValAssetnum, 0)); } set { klass.ValAssetnum = Convert.ToDouble(value); } }

		[DisplayName("Asset type")]
		/// <summary>Field : "Asset type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValAssettyp")]
		[DataArray("Assettyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAssettyp { get { return klass.ValAssettyp; } set { klass.ValAssettyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValassettyp { get { return new SelectList(CSGenio.business.ArrayAssettyp.GetDictionary(), "Key", "Value", ValAssettyp); } set { ValAssettyp = value.SelectedValue as string; } }

		[DisplayName("Identifier type")]
		/// <summary>Field : "Identifier type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValIdenttyp")]
		[DataArray("Identtyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValIdenttyp { get { return klass.ValIdenttyp; } set { klass.ValIdenttyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValidenttyp { get { return new SelectList(CSGenio.business.ArrayIdenttyp.GetDictionary(), "Key", "Value", ValIdenttyp); } set { ValIdenttyp = value.SelectedValue as string; } }

		[DisplayName("GRAI – Global Returnable Asset Identifier")]
		/// <summary>Field : "GRAI – Global Returnable Asset Identifier" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValGrai")]
		public string ValGrai { get { return klass.ValGrai; } set { klass.ValGrai = value; } }

		[DisplayName("GIAI – Global Individual Asset Identifier")]
		/// <summary>Field : "GIAI – Global Individual Asset Identifier" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValGiai")]
		public string ValGiai { get { return klass.ValGiai; } set { klass.ValGiai = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }

		[DisplayName(">>Manufacturer")]
		/// <summary>Field : ">>Manufacturer" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValCodmanuf")]
		public string ValCodmanuf { get { return klass.ValCodmanuf; } set { klass.ValCodmanuf = value; } }
		private Manuf _manuf;
		[DisplayName("Manuf")]
		[ShouldSerialize("Manuf")]
		public virtual Manuf Manuf { 
			get { 
				if (!this.isEmptyModel && (_manuf == null || (!string.IsNullOrEmpty(ValCodmanuf) && (_manuf.isEmptyModel || _manuf.klass.QPrimaryKey != ValCodmanuf))))
					_manuf = Models.Manuf.Find(ValCodmanuf, m_userContext, Identifier, _fieldsToSerialize);
				if (_manuf == null)
					_manuf = new Models.Manuf(m_userContext, true, _fieldsToSerialize);
				return _manuf;
			}
			set { _manuf = value; } 
		}
		

		[DisplayName(">>Kind of equipment")]
		/// <summary>Field : ">>Kind of equipment" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Asset.ValCodkinde")]
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		private Kinde _kinde;
		[DisplayName("Kinde")]
		[ShouldSerialize("Kinde")]
		public virtual Kinde Kinde { 
			get { 
				if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde))))
					_kinde = Models.Kinde.Find(ValCodkinde, m_userContext, Identifier, _fieldsToSerialize);
				if (_kinde == null)
					_kinde = new Models.Kinde(m_userContext, true, _fieldsToSerialize);
				return _kinde;
			}
			set { _kinde = value; } 
		}
		

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Asset.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Asset(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAasset(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Asset(UserContext userContext, CSGenioAasset val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


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
							_manuf = new Manuf(m_userContext, true, _fieldsToSerialize);
						_manuf.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "kinde":
						if (_kinde == null)
							_kinde = new Kinde(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Asset Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAasset>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Asset(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Asset> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAasset>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Asset>((r) => new Asset(userCtx, r));
		}

		public StatusMessage carga_Manuals(string idsrc)
		{
			User u = m_userContext.User;
			PersistentSupport sp = m_userContext.PersistentSupport;
			StatusMessage Qresult = this.klass.carga_Manuals(idsrc,sp,u);

			return Qresult;
		}

		public StatusMessage carga_Parameters(string idsrc)
		{
			User u = m_userContext.User;
			PersistentSupport sp = m_userContext.PersistentSupport;
			StatusMessage Qresult = this.klass.carga_Parameters(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL ASSET]/
	}
}
