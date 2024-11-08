using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.Models
{
	public class Brdps : ModelBase
	{
		[JsonIgnore]
		public CSGenioAbrdps klass { get { return baseklass as CSGenioAbrdps; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodbrdps { get { return klass.ValCodbrdps; } set { klass.ValCodbrdps = value; } }
		public bool ShouldSerializeValCodbrdps() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCodbrdps");

		[DisplayName("Boarding Pass ID")]
		/// <summary>Field : "Boarding Pass ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValBrdpsid { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBrdpsid, 0)); } set { klass.ValBrdpsid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBrdpsid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValBrdpsid");

		[DisplayName("Emission Date")]
		/// <summary>Field : "Emission Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValEmitdate { get { return klass.ValEmitdate; } set { klass.ValEmitdate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValEmitdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValEmitdate");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }
		public bool ShouldSerializeValCodfligh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCodfligh");
		private Fligh _fligh;
		[DisplayName("Fligh")]
		public virtual Fligh Fligh { get { if (!this.isEmptyModel && (_fligh == null || (!string.IsNullOrEmpty(ValCodfligh) && (_fligh.isEmptyModel || _fligh.klass.QPrimaryKey != ValCodfligh)))) _fligh = Models.Fligh.Find(ValCodfligh, Identifier, _fieldsToSerialize); if (_fligh == null) _fligh = new Models.Fligh(true, _fieldsToSerialize); return _fligh; } set { _fligh = value; } }
		public bool ShouldSerializeFligh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }
		public bool ShouldSerializeValCodpsngr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCodpsngr");
		private Psngr _psngr;
		[DisplayName("Psngr")]
		public virtual Psngr Psngr { get { if (!this.isEmptyModel && (_psngr == null || (!string.IsNullOrEmpty(ValCodpsngr) && (_psngr.isEmptyModel || _psngr.klass.QPrimaryKey != ValCodpsngr)))) _psngr = Models.Psngr.Find(ValCodpsngr, Identifier, _fieldsToSerialize); if (_psngr == null) _psngr = new Models.Psngr(true, _fieldsToSerialize); return _psngr; } set { _psngr = value; } }
		public bool ShouldSerializePsngr () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtickt { get { return klass.ValCodtickt; } set { klass.ValCodtickt = value; } }
		public bool ShouldSerializeValCodtickt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCodtickt");
		private Tickt _tickt;
		[DisplayName("Tickt")]
		public virtual Tickt Tickt { get { if (!this.isEmptyModel && (_tickt == null || (!string.IsNullOrEmpty(ValCodtickt) && (_tickt.isEmptyModel || _tickt.klass.QPrimaryKey != ValCodtickt)))) _tickt = Models.Tickt.Find(ValCodtickt, Identifier, _fieldsToSerialize); if (_tickt == null) _tickt = new Models.Tickt(true, _fieldsToSerialize); return _tickt; } set { _tickt = value; } }
		public bool ShouldSerializeTickt () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tickt");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfltsc { get { return klass.ValCodfltsc; } set { klass.ValCodfltsc = value; } }
		public bool ShouldSerializeValCodfltsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCodfltsc");
		private Fltsc _fltsc;
		[DisplayName("Fltsc")]
		public virtual Fltsc Fltsc { get { if (!this.isEmptyModel && (_fltsc == null || (!string.IsNullOrEmpty(ValCodfltsc) && (_fltsc.isEmptyModel || _fltsc.klass.QPrimaryKey != ValCodfltsc)))) _fltsc = Models.Fltsc.Find(ValCodfltsc, Identifier, _fieldsToSerialize); if (_fltsc == null) _fltsc = new Models.Fltsc(true, _fieldsToSerialize); return _fltsc; } set { _fltsc = value; } }
		public bool ShouldSerializeFltsc () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fltsc");

		[DisplayName("Boarding Gate")]
		/// <summary>Field : "Boarding Gate" Tipo: "C" Formula:  ""</summary>
		public string ValGate { get { return klass.ValGate; } set { klass.ValGate = value; } }
		public bool ShouldSerializeValGate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValGate");

		[DisplayName("Seat")]
		/// <summary>Field : "Seat" Tipo: "C" Formula:  ""</summary>
		public string ValSeat { get { return klass.ValSeat; } set { klass.ValSeat = value; } }
		public bool ShouldSerializeValSeat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValSeat");

		[DisplayName("Has Checkin?")]
		/// <summary>Field : "Has Checkin?" Tipo: "L" Formula:  ""</summary>
		public bool ValHaschkin { get { return Convert.ToBoolean(klass.ValHaschkin); } set { klass.ValHaschkin = Convert.ToInt32(value); } }
		public bool ShouldSerializeValHaschkin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValHaschkin");

		[DisplayName("Checkin Date/Time")]
		/// <summary>Field : "Checkin Date/Time" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValCkndtime { get { return klass.ValCkndtime; } set { klass.ValCkndtime = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValCkndtime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValCkndtime");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Brdps.ValZzstate");

		public Brdps() : this(UserContext.Current.User) { }

		public Brdps(User u)
		{
			this.klass = new CSGenioAbrdps(u);
		}

		public Brdps(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Brdps(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Brdps(bool isEmpty) : this(isEmpty, null) { }

		public Brdps(CSGenioAbrdps val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Brdps(CSGenioAbrdps val) : this(val, null) { }

		public Brdps(CSGenioAbrdps val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Brdps(CSGenioAbrdps val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAbrdps csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fligh":
						if (_fligh == null)
							_fligh = new Fligh(true, _fieldsToSerialize);
						_fligh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "psngr":
						if (_psngr == null)
							_psngr = new Psngr(true, _fieldsToSerialize);
						_psngr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tickt":
						if (_tickt == null)
							_tickt = new Tickt(true, _fieldsToSerialize);
						_tickt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "fltsc":
						if (_fltsc == null)
							_fltsc = new Fltsc(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Brdps Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
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
			return record == null ? null : new Brdps(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Brdps> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAbrdps>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Brdps>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAbrdps> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAbrdps>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAbrdps> All(CriteriaSet args = null)
		{
			return Where<CSGenioAbrdps>(false, args, numRegs: -1);
		}

		public static List<Brdps> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAbrdps>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Brdps>((r) => new Brdps(r));
		}

// USE /[MANUAL GQT MODEL BRDPS]/
	}
}
