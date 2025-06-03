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
	public class Attac : ModelBase
	{
		[JsonIgnore]
		public CSGenioAattac klass { get { return baseklass as CSGenioAattac; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Attac.ValCodattac")]
		public string ValCodattac { get { return klass.ValCodattac; } set { klass.ValCodattac = value; } }

		[DisplayName(">>ASSET")]
		/// <summary>Field : ">>ASSET" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Attac.ValCodasset")]
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }

		private Asset _asset;
		[DisplayName("Asset")]
		[ShouldSerialize("Asset")]
		public virtual Asset Asset
		{
			get
			{
				if (!isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset))))
					_asset = Models.Asset.Find(ValCodasset, m_userContext, Identifier, _fieldsToSerialize);
				_asset ??= new Models.Asset(m_userContext, true, _fieldsToSerialize);
				return _asset;
			}
			set { _asset = value; }
		}

		[DisplayName("Attached")]
		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Attac.ValAttached")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValAttached { get { return klass.ValAttached; } set { klass.ValAttached = value ?? DateTime.MinValue; } }

		[DisplayName("Note")]
		/// <summary>Field : "Note" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Attac.ValNote")]
		[DataType(DataType.MultilineText)]
		public string ValNote { get { return klass.ValNote; } set { klass.ValNote = value; } }

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Attac.ValDocument")]
		[Document("ValDocument", true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Attac.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Attac(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAattac(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Attac(UserContext userContext, CSGenioAattac val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAattac csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						_asset ??= new Asset(m_userContext, true, _fieldsToSerialize);
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
		public static Attac Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAattac>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Attac(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Attac> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAattac>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Attac>((r) => new Attac(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ATTAC]/
	}
}
