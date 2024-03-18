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
	public class Assma : ModelBase
	{
		[JsonIgnore]
		public CSGenioAassma klass { get { return baseklass as CSGenioAassma; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Assma.ValCodassma")]
		public string ValCodassma { get { return klass.ValCodassma; } set { klass.ValCodassma = value; } }

		[DisplayName(">>Asset")]
		/// <summary>Field : ">>Asset" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Assma.ValCodasset")]
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }
		private Asset _asset;
		[DisplayName("Asset")]
		[ShouldSerialize("Asset")]
		public virtual Asset Asset { 
			get { 
				if (!this.isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset))))
					_asset = Models.Asset.Find(ValCodasset, m_userContext, Identifier, _fieldsToSerialize);
				if (_asset == null)
					_asset = new Models.Asset(m_userContext, true, _fieldsToSerialize);
				return _asset;
			}
			set { _asset = value; } 
		}
		

		[DisplayName("Manual name")]
		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Assma.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Digital document")]
		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Assma.ValDigdocum")]
		[Document("ValDigdocum", false, true, false, false)]
		public string ValDigdocum { get { return klass.ValDigdocum; } set { klass.ValDigdocum = value; } }
		public string ValDigdocumfk { get { return klass.ValDigdocumfk; } set { klass.ValDigdocumfk = value; } }

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Assma.ValNotes")]
		[DataType(DataType.MultilineText)]
		public string ValNotes { get { return klass.ValNotes; } set { klass.ValNotes = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Assma.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Assma(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAassma(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Assma(UserContext userContext, CSGenioAassma val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


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
							_asset = new Asset(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Assma Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAassma>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Assma(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Assma> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAassma>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Assma>((r) => new Assma(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ASSMA]/
	}
}
