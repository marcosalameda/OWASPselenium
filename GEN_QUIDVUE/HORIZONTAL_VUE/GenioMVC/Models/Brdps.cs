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
	public class Brdps : ModelBase
	{
		[JsonIgnore]
		public CSGenioAbrdps klass { get { return baseklass as CSGenioAbrdps; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCodbrdps")]
		public string ValCodbrdps { get { return klass.ValCodbrdps; } set { klass.ValCodbrdps = value; } }

		[DisplayName("Boarding Pass ID")]
		/// <summary>Field : "Boarding Pass ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValBrdpsid")]
		[NumericAttribute(0)]
		public decimal? ValBrdpsid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBrdpsid, 0)); } set { klass.ValBrdpsid = Convert.ToDecimal(value); } }

		[DisplayName("Emission Date")]
		/// <summary>Field : "Emission Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValEmitdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValEmitdate { get { return klass.ValEmitdate; } set { klass.ValEmitdate = value ?? DateTime.MinValue; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCodfligh")]
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }

		private Fligh _fligh;
		[DisplayName("Fligh")]
		[ShouldSerialize("Fligh")]
		public virtual Fligh Fligh
		{
			get
			{
				if (!isEmptyModel && (_fligh == null || (!string.IsNullOrEmpty(ValCodfligh) && (_fligh.isEmptyModel || _fligh.klass.QPrimaryKey != ValCodfligh))))
					_fligh = Models.Fligh.Find(ValCodfligh, m_userContext, Identifier, _fieldsToSerialize);
				_fligh ??= new Models.Fligh(m_userContext, true, _fieldsToSerialize);
				return _fligh;
			}
			set { _fligh = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCodpsngr")]
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }

		private Psngr _psngr;
		[DisplayName("Psngr")]
		[ShouldSerialize("Psngr")]
		public virtual Psngr Psngr
		{
			get
			{
				if (!isEmptyModel && (_psngr == null || (!string.IsNullOrEmpty(ValCodpsngr) && (_psngr.isEmptyModel || _psngr.klass.QPrimaryKey != ValCodpsngr))))
					_psngr = Models.Psngr.Find(ValCodpsngr, m_userContext, Identifier, _fieldsToSerialize);
				_psngr ??= new Models.Psngr(m_userContext, true, _fieldsToSerialize);
				return _psngr;
			}
			set { _psngr = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCodtickt")]
		public string ValCodtickt { get { return klass.ValCodtickt; } set { klass.ValCodtickt = value; } }

		private Tickt _tickt;
		[DisplayName("Tickt")]
		[ShouldSerialize("Tickt")]
		public virtual Tickt Tickt
		{
			get
			{
				if (!isEmptyModel && (_tickt == null || (!string.IsNullOrEmpty(ValCodtickt) && (_tickt.isEmptyModel || _tickt.klass.QPrimaryKey != ValCodtickt))))
					_tickt = Models.Tickt.Find(ValCodtickt, m_userContext, Identifier, _fieldsToSerialize);
				_tickt ??= new Models.Tickt(m_userContext, true, _fieldsToSerialize);
				return _tickt;
			}
			set { _tickt = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCodfltsc")]
		public string ValCodfltsc { get { return klass.ValCodfltsc; } set { klass.ValCodfltsc = value; } }

		private Fltsc _fltsc;
		[DisplayName("Fltsc")]
		[ShouldSerialize("Fltsc")]
		public virtual Fltsc Fltsc
		{
			get
			{
				if (!isEmptyModel && (_fltsc == null || (!string.IsNullOrEmpty(ValCodfltsc) && (_fltsc.isEmptyModel || _fltsc.klass.QPrimaryKey != ValCodfltsc))))
					_fltsc = Models.Fltsc.Find(ValCodfltsc, m_userContext, Identifier, _fieldsToSerialize);
				_fltsc ??= new Models.Fltsc(m_userContext, true, _fieldsToSerialize);
				return _fltsc;
			}
			set { _fltsc = value; }
		}

		[DisplayName("Boarding Gate")]
		/// <summary>Field : "Boarding Gate" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValGate")]
		public string ValGate { get { return klass.ValGate; } set { klass.ValGate = value; } }

		[DisplayName("Seat")]
		/// <summary>Field : "Seat" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValSeat")]
		public string ValSeat { get { return klass.ValSeat; } set { klass.ValSeat = value; } }

		[DisplayName("Has Checkin?")]
		/// <summary>Field : "Has Checkin?" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValHaschkin")]
		public bool ValHaschkin { get { return Convert.ToBoolean(klass.ValHaschkin); } set { klass.ValHaschkin = Convert.ToInt32(value); } }

		[DisplayName("Checkin Date/Time")]
		/// <summary>Field : "Checkin Date/Time" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Brdps.ValCkndtime")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValCkndtime { get { return klass.ValCkndtime; } set { klass.ValCkndtime = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Brdps.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Brdps(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAbrdps(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Brdps(UserContext userContext, CSGenioAbrdps val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAbrdps csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fligh":
						_fligh ??= new Fligh(m_userContext, true, _fieldsToSerialize);
						_fligh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "psngr":
						_psngr ??= new Psngr(m_userContext, true, _fieldsToSerialize);
						_psngr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tickt":
						_tickt ??= new Tickt(m_userContext, true, _fieldsToSerialize);
						_tickt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "fltsc":
						_fltsc ??= new Fltsc(m_userContext, true, _fieldsToSerialize);
						_fltsc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Brdps Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAbrdps>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Brdps(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Brdps> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAbrdps>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Brdps>((r) => new Brdps(userCtx, r));
		}

// USE /[MANUAL GQT MODEL BRDPS]/
	}
}
