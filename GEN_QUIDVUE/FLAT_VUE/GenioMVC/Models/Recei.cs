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
	public class Recei : ModelBase
	{
		[JsonIgnore]
		public CSGenioArecei klass { get { return baseklass as CSGenioArecei; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValCodrecei")]
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }

		[DisplayName(">>SUPPLIER")]
		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		private Entit _entit;
		[DisplayName("Entit")]
		[ShouldSerialize("Entit")]
		public virtual Entit Entit
		{
			get
			{
				if (!isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit))))
					_entit = Models.Entit.Find(ValCodentit, m_userContext, Identifier, _fieldsToSerialize);
				_entit ??= new Models.Entit(m_userContext, true, _fieldsToSerialize);
				return _entit;
			}
			set { _entit = value; }
		}

		[DisplayName("Receipt number")]
		/// <summary>Field : "Receipt number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValNumber")]
		[NumericAttribute(0)]
		public decimal? ValNumber { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumber, 0)); } set { klass.ValNumber = Convert.ToDecimal(value); } }

		[DisplayName("Receipt date")]
		/// <summary>Field : "Receipt date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValDtreceip")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtreceip { get { return klass.ValDtreceip; } set { klass.ValDtreceip = value ?? DateTime.MinValue; } }

		[DisplayName("Receipt verification")]
		/// <summary>Field : "Receipt verification" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValDtcheck")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtcheck { get { return klass.ValDtcheck; } set { klass.ValDtcheck = value ?? DateTime.MinValue; } }

		[DisplayName("Checked")]
		/// <summary>Field : "Checked" Tipo: "L" Formula: + "iif(isEmptyD([RECEI->DTCHECK]),0,1)"</summary>
		[ShouldSerialize("Recei.ValChecked")]
		public bool ValChecked { get { return Convert.ToBoolean(klass.ValChecked); } set { klass.ValChecked = Convert.ToInt32(value); } }

		[DisplayName("To check")]
		/// <summary>Field : "To check" Tipo: "L" Formula: + "iif(!isEmptyD([RECEI->DTRECEIP]) && isEmptyD([RECEI->DTCHECK]),1,0)"</summary>
		[ShouldSerialize("Recei.ValTocheck")]
		public bool ValTocheck { get { return Convert.ToBoolean(klass.ValTocheck); } set { klass.ValTocheck = Convert.ToInt32(value); } }

		[DisplayName("Stored")]
		/// <summary>Field : "Stored" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValStored")]
		public bool ValStored { get { return Convert.ToBoolean(klass.ValStored); } set { klass.ValStored = Convert.ToInt32(value); } }

		[DisplayName("Storage date")]
		/// <summary>Field : "Storage date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Recei.ValDtstorag")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtstorag { get { return klass.ValDtstorag; } set { klass.ValDtstorag = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Recei.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Recei(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArecei(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Recei(UserContext userContext, CSGenioArecei val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioArecei csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						_entit ??= new Entit(m_userContext, true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Recei Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArecei>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Recei(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Recei> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArecei>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Recei>((r) => new Recei(userCtx, r));
		}

// USE /[MANUAL GQT MODEL RECEI]/
	}
}
