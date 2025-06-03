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
	public class Grid : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgrid klass { get { return baseklass as CSGenioAgrid; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Grid.ValCodgrid")]
		public string ValCodgrid { get { return klass.ValCodgrid; } set { klass.ValCodgrid = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Grid.ValCodftgri")]
		public string ValCodftgri { get { return klass.ValCodftgri; } set { klass.ValCodftgri = value; } }

		private Ftgri _ftgri;
		[DisplayName("Ftgri")]
		[ShouldSerialize("Ftgri")]
		public virtual Ftgri Ftgri
		{
			get
			{
				if (!isEmptyModel && (_ftgri == null || (!string.IsNullOrEmpty(ValCodftgri) && (_ftgri.isEmptyModel || _ftgri.klass.QPrimaryKey != ValCodftgri))))
					_ftgri = Models.Ftgri.Find(ValCodftgri, m_userContext, Identifier, _fieldsToSerialize);
				_ftgri ??= new Models.Ftgri(m_userContext, true, _fieldsToSerialize);
				return _ftgri;
			}
			set { _ftgri = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Grid.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }

		private Pesso _pesso;
		[DisplayName("Pesso")]
		[ShouldSerialize("Pesso")]
		public virtual Pesso Pesso
		{
			get
			{
				if (!isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso))))
					_pesso = Models.Pesso.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				_pesso ??= new Models.Pesso(m_userContext, true, _fieldsToSerialize);
				return _pesso;
			}
			set { _pesso = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Grid.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Grid(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgrid(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Grid(UserContext userContext, CSGenioAgrid val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAgrid csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "ftgri":
						_ftgri ??= new Ftgri(m_userContext, true, _fieldsToSerialize);
						_ftgri.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						_pesso ??= new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Grid Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgrid>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Grid(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Grid> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgrid>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Grid>((r) => new Grid(userCtx, r));
		}

// USE /[MANUAL GQT MODEL GRID]/
	}
}
