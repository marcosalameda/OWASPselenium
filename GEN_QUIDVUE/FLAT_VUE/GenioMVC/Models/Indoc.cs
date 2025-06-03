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
	public class Indoc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAindoc klass { get { return baseklass as CSGenioAindoc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValCoddentr")]
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry
		{
			get
			{
				if (!isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry))))
					_cntry = Models.Cntry.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				_cntry ??= new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }

		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		[ShouldSerialize("Cmpny")]
		public virtual Cmpny Cmpny
		{
			get
			{
				if (!isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre))))
					_cmpny = Models.Cmpny.Find(ValCodempre, m_userContext, Identifier, _fieldsToSerialize);
				_cmpny ??= new Models.Cmpny(m_userContext, true, _fieldsToSerialize);
				return _cmpny;
			}
			set { _cmpny = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValCodpesso")]
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

		[DisplayName("BY OMISSION")]
		/// <summary>Field : "BY OMISSION" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }

		private Ware1 _ware1;
		[DisplayName("Ware1")]
		[ShouldSerialize("Ware1")]
		public virtual Ware1 Ware1
		{
			get
			{
				if (!isEmptyModel && (_ware1 == null || (!string.IsNullOrEmpty(ValCodwareh) && (_ware1.isEmptyModel || _ware1.klass.QPrimaryKey != ValCodwareh))))
					_ware1 = Models.Ware1.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				_ware1 ??= new Models.Ware1(m_userContext, true, _fieldsToSerialize);
				return _ware1;
			}
			set { _ware1 = value; }
		}

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValDocumenr")]
		[NumericAttribute(0)]
		public decimal? ValDocumenr { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDocumenr, 0)); } set { klass.ValDocumenr = Convert.ToDecimal(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Indoc.ValDhdocume")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhdocume { get { return klass.ValDhdocume; } set { klass.ValDhdocume = value ?? DateTime.MinValue; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula: + "iif(emptyG([INDOC->CODWAREH])==1,[ZEROD],[INDOC->DHDOCUME])"</summary>
		[ShouldSerialize("Indoc.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Indoc.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Indoc(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAindoc(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Indoc(UserContext userContext, CSGenioAindoc val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAindoc csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						_cntry ??= new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cmpny":
						_cmpny ??= new Cmpny(m_userContext, true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						_pesso ??= new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "ware1":
						_ware1 ??= new Ware1(m_userContext, true, _fieldsToSerialize);
						_ware1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Indoc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAindoc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Indoc(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Indoc> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAindoc>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Indoc>((r) => new Indoc(userCtx, r));
		}

// USE /[MANUAL GQT MODEL INDOC]/
	}
}
