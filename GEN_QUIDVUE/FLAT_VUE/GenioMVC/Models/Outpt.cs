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
	public class Outpt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoutpt klass { get { return baseklass as CSGenioAoutpt; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Outpt.ValCodoutpt")]
		public string ValCodoutpt { get { return klass.ValCodoutpt; } set { klass.ValCodoutpt = value; } }

		[DisplayName("BY OMISSION")]
		/// <summary>Field : "BY OMISSION" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Outpt.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		private Ware1 _ware1;
		[DisplayName("Ware1")]
		[ShouldSerialize("Ware1")]
		public virtual Ware1 Ware1 {
			get {
				if (!this.isEmptyModel && (_ware1 == null || (!string.IsNullOrEmpty(ValCodwareh) && (_ware1.isEmptyModel || _ware1.klass.QPrimaryKey != ValCodwareh))))
					_ware1 = Models.Ware1.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				if (_ware1 == null)
					_ware1 = new Models.Ware1(m_userContext, true, _fieldsToSerialize);
				return _ware1;
			}
			set { _ware1 = value; }
		}


		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Outpt.ValDocumenr")]
		[NumericAttribute(0)]
		public decimal? ValDocumenr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDocumenr, 0)); } set { klass.ValDocumenr = Convert.ToDecimal(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Outpt.ValDhdocume")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhdocume { get { return klass.ValDhdocume; } set { klass.ValDhdocume = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Outpt.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Outpt(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAoutpt(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpt(UserContext userContext, CSGenioAoutpt val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAoutpt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "ware1":
						if (_ware1 == null)
							_ware1 = new Ware1(m_userContext, true, _fieldsToSerialize);
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
		public static Outpt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoutpt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Outpt(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Outpt> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoutpt>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Outpt>((r) => new Outpt(userCtx, r));
		}

// USE /[MANUAL GQT MODEL OUTPT]/
	}
}
