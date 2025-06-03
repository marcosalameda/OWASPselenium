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
	public class Lendi : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlendi klass { get { return baseklass as CSGenioAlendi; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValCodlendi")]
		public string ValCodlendi { get { return klass.ValCodlendi; } set { klass.ValCodlendi = value; } }

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValCodpess1")]
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }

		private Pess1 _pess1;
		[DisplayName("Pess1")]
		[ShouldSerialize("Pess1")]
		public virtual Pess1 Pess1
		{
			get
			{
				if (!isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1))))
					_pess1 = Models.Pess1.Find(ValCodpess1, m_userContext, Identifier, _fieldsToSerialize);
				_pess1 ??= new Models.Pess1(m_userContext, true, _fieldsToSerialize);
				return _pess1;
			}
			set { _pess1 = value; }
		}

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }

		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip
		{
			get
			{
				if (!isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				_equip ??= new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; }
		}

		[DisplayName(">DADATARY")]
		/// <summary>Field : ">DADATARY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValCodpess2")]
		public string ValCodpess2 { get { return klass.ValCodpess2; } set { klass.ValCodpess2 = value; } }

		private Pess2 _pess2;
		[DisplayName("Pess2")]
		[ShouldSerialize("Pess2")]
		public virtual Pess2 Pess2
		{
			get
			{
				if (!isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpess2) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpess2))))
					_pess2 = Models.Pess2.Find(ValCodpess2, m_userContext, Identifier, _fieldsToSerialize);
				_pess2 ??= new Models.Pess2(m_userContext, true, _fieldsToSerialize);
				return _pess2;
			}
			set { _pess2 = value; }
		}

		[DisplayName("Number of lending")]
		/// <summary>Field : "Number of lending" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValLendinnr")]
		[NumericAttribute(0)]
		public decimal? ValLendinnr { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValLendinnr, 0)); } set { klass.ValLendinnr = Convert.ToDecimal(value); } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValStart")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStart { get { return klass.ValStart; } set { klass.ValStart = value ?? DateTime.MinValue; } }

		[DisplayName("Warning")]
		/// <summary>Field : "Warning" Tipo: "DT" Formula: + "SomaDias([LENDI->START],[EQUIP->FREQUENC])"</summary>
		[ShouldSerialize("Lendi.ValWarndt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValWarndt { get { return klass.ValWarndt; } set { klass.ValWarndt = value ?? DateTime.MinValue; } }

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula: + "SomaDias([LENDI->WARNDT],1)"</summary>
		[ShouldSerialize("Lendi.ValEnd")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValObservat")]
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }

		[DisplayName("Return")]
		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Lendi.ValReturndt")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValReturndt { get { return klass.ValReturndt; } set { klass.ValReturndt = value ?? DateTime.MinValue; } }

		[DisplayName("Returned")]
		/// <summary>Field : "Returned" Tipo: "L" Formula: + "iif(emptyD([LENDI->RETURNDT])==1,0,1)"</summary>
		[ShouldSerialize("Lendi.ValReturned")]
		public bool ValReturned { get { return Convert.ToBoolean(klass.ValReturned); } set { klass.ValReturned = Convert.ToInt32(value); } }

		[DisplayName("Days for return period")]
		/// <summary>Field : "Days for return period" Tipo: "N" Formula: +H "iif(emptyD([LENDI->END])==1,0,Diferenca_entre_Datas([Today],[LENDI->END],"D"))"</summary>
		[ShouldSerialize("Lendi.ValDayslimi")]
		[NumericAttribute(0)]
		public decimal? ValDayslimi { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDayslimi, 0)); } set { klass.ValDayslimi = Convert.ToDecimal(value); } }

		[DisplayName("If out of date")]
		/// <summary>Field : "If out of date" Tipo: "L" Formula: + "iif([LENDI->DAYSLIMI]<0,1,0)"</summary>
		[ShouldSerialize("Lendi.ValIfoutdt")]
		public bool ValIfoutdt { get { return Convert.ToBoolean(klass.ValIfoutdt); } set { klass.ValIfoutdt = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Lendi.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Lendi(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlendi(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lendi(UserContext userContext, CSGenioAlendi val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAlendi csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess1":
						_pess1 ??= new Pess1(m_userContext, true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "equip":
						_equip ??= new Equip(m_userContext, true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess2":
						_pess2 ??= new Pess2(m_userContext, true, _fieldsToSerialize);
						_pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lendi Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlendi>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lendi(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Lendi> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlendi>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lendi>((r) => new Lendi(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LENDI]/
	}
}
