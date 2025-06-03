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
	public class Fligh : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfligh klass { get { return baseklass as CSGenioAfligh; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodfligh")]
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }

		[DisplayName("Flight ID")]
		/// <summary>Field : "Flight ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValFlightid")]
		[NumericAttribute(0)]
		public decimal? ValFlightid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValFlightid, 0)); } set { klass.ValFlightid = Convert.ToDecimal(value); } }

		[DisplayName("Departure Date")]
		/// <summary>Field : "Departure Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValDepdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDepdate { get { return klass.ValDepdate; } set { klass.ValDepdate = value ?? DateTime.MinValue; } }

		[DisplayName("Departure Time")]
		/// <summary>Field : "Departure Time" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValDeptime")]
		[DateAttribute("T")]
		public string ValDeptime { get { return klass.ValDeptime; } set { klass.ValDeptime = value; } }

		[DisplayName("Arrival Date")]
		/// <summary>Field : "Arrival Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValArvdate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValArvdate { get { return klass.ValArvdate; } set { klass.ValArvdate = value ?? DateTime.MinValue; } }

		[DisplayName("Arrival Time")]
		/// <summary>Field : "Arrival Time" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValArrtime")]
		[DateAttribute("T")]
		public string ValArrtime { get { return klass.ValArrtime; } set { klass.ValArrtime = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodairln")]
		public string ValCodairln { get { return klass.ValCodairln; } set { klass.ValCodairln = value; } }

		private Airln _airln;
		[DisplayName("Airln")]
		[ShouldSerialize("Airln")]
		public virtual Airln Airln
		{
			get
			{
				if (!isEmptyModel && (_airln == null || (!string.IsNullOrEmpty(ValCodairln) && (_airln.isEmptyModel || _airln.klass.QPrimaryKey != ValCodairln))))
					_airln = Models.Airln.Find(ValCodairln, m_userContext, Identifier, _fieldsToSerialize);
				_airln ??= new Models.Airln(m_userContext, true, _fieldsToSerialize);
				return _airln;
			}
			set { _airln = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodairpt")]
		public string ValCodairpt { get { return klass.ValCodairpt; } set { klass.ValCodairpt = value; } }

		private Airpt _airpt;
		[DisplayName("Airpt")]
		[ShouldSerialize("Airpt")]
		public virtual Airpt Airpt
		{
			get
			{
				if (!isEmptyModel && (_airpt == null || (!string.IsNullOrEmpty(ValCodairpt) && (_airpt.isEmptyModel || _airpt.klass.QPrimaryKey != ValCodairpt))))
					_airpt = Models.Airpt.Find(ValCodairpt, m_userContext, Identifier, _fieldsToSerialize);
				_airpt ??= new Models.Airpt(m_userContext, true, _fieldsToSerialize);
				return _airpt;
			}
			set { _airpt = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodairfr")]
		public string ValCodairfr { get { return klass.ValCodairfr; } set { klass.ValCodairfr = value; } }

		private Airfr _airfr;
		[DisplayName("Airfr")]
		[ShouldSerialize("Airfr")]
		public virtual Airfr Airfr
		{
			get
			{
				if (!isEmptyModel && (_airfr == null || (!string.IsNullOrEmpty(ValCodairfr) && (_airfr.isEmptyModel || _airfr.klass.QPrimaryKey != ValCodairfr))))
					_airfr = Models.Airfr.Find(ValCodairfr, m_userContext, Identifier, _fieldsToSerialize);
				_airfr ??= new Models.Airfr(m_userContext, true, _fieldsToSerialize);
				return _airfr;
			}
			set { _airfr = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Fligh.ValCodairto")]
		public string ValCodairto { get { return klass.ValCodairto; } set { klass.ValCodairto = value; } }

		private Airto _airto;
		[DisplayName("Airto")]
		[ShouldSerialize("Airto")]
		public virtual Airto Airto
		{
			get
			{
				if (!isEmptyModel && (_airto == null || (!string.IsNullOrEmpty(ValCodairto) && (_airto.isEmptyModel || _airto.klass.QPrimaryKey != ValCodairto))))
					_airto = Models.Airto.Find(ValCodairto, m_userContext, Identifier, _fieldsToSerialize);
				_airto ??= new Models.Airto(m_userContext, true, _fieldsToSerialize);
				return _airto;
			}
			set { _airto = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Fligh.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Fligh(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfligh(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fligh(UserContext userContext, CSGenioAfligh val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAfligh csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "airln":
						_airln ??= new Airln(m_userContext, true, _fieldsToSerialize);
						_airln.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airpt":
						_airpt ??= new Airpt(m_userContext, true, _fieldsToSerialize);
						_airpt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airfr":
						_airfr ??= new Airfr(m_userContext, true, _fieldsToSerialize);
						_airfr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "airto":
						_airto ??= new Airto(m_userContext, true, _fieldsToSerialize);
						_airto.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Fligh Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfligh>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Fligh(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Fligh> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfligh>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Fligh>((r) => new Fligh(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FLIGH]/
	}
}
