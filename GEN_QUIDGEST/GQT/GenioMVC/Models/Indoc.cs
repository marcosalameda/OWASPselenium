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
	public class Indoc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAindoc klass { get { return baseklass as CSGenioAindoc; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }
		public bool ShouldSerializeValCoddentr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValCoddentr");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValCodcntry");
		private Cntry _cntry;
		[DisplayName("Cntry")]
		public virtual Cntry Cntry { get { if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry)))) _cntry = Models.Cntry.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_cntry == null) _cntry = new Models.Cntry(true, _fieldsToSerialize); return _cntry; } set { _cntry = value; } }
		public bool ShouldSerializeCntry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValCodempre");
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		public virtual Cmpny Cmpny { get { if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre)))) _cmpny = Models.Cmpny.Find(ValCodempre, Identifier, _fieldsToSerialize); if (_cmpny == null) _cmpny = new Models.Cmpny(true, _fieldsToSerialize); return _cmpny; } set { _cmpny = value; } }
		public bool ShouldSerializeCmpny () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValCodpesso");
		private Pesso _pesso;
		[DisplayName("Pesso")]
		public virtual Pesso Pesso { get { if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso)))) _pesso = Models.Pesso.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pesso == null) _pesso = new Models.Pesso(true, _fieldsToSerialize); return _pesso; } set { _pesso = value; } }
		public bool ShouldSerializePesso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso");

		[DisplayName("BY OMISSION")]
		/// <summary>Field : "BY OMISSION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValCodwareh");
		private Ware1 _ware1;
		[DisplayName("Ware1")]
		public virtual Ware1 Ware1 { get { if (!this.isEmptyModel && (_ware1 == null || (!string.IsNullOrEmpty(ValCodwareh) && (_ware1.isEmptyModel || _ware1.klass.QPrimaryKey != ValCodwareh)))) _ware1 = Models.Ware1.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_ware1 == null) _ware1 = new Models.Ware1(true, _fieldsToSerialize); return _ware1; } set { _ware1 = value; } }
		public bool ShouldSerializeWare1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1");

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDocumenr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDocumenr, 0)); } set { klass.ValDocumenr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDocumenr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValDocumenr");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhdocume { get { return klass.ValDhdocume; } set { klass.ValDhdocume = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDhdocume() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValDhdocume");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula: + "iif(emptyG([INDOC->CODWAREH])==1,[ZEROD],[INDOC->DHDOCUME])"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValDate");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc.ValZzstate");

		public Indoc() : this(UserContext.Current.User) { }

		public Indoc(User u)
		{
			this.klass = new CSGenioAindoc(u);
		}

		public Indoc(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Indoc(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Indoc(bool isEmpty) : this(isEmpty, null) { }

		public Indoc(CSGenioAindoc val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Indoc(CSGenioAindoc val) : this(val, null) { }

		public Indoc(CSGenioAindoc val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Indoc(CSGenioAindoc val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAindoc csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cmpny":
						if (_cmpny == null)
							_cmpny = new Cmpny(true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "ware1":
						if (_ware1 == null)
							_ware1 = new Ware1(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Indoc Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Indoc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAindoc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Indoc(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Indoc> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAindoc>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Indoc>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAindoc> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAindoc>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAindoc> All(CriteriaSet args = null)
		{
			return Where<CSGenioAindoc>(false, args, numRegs: -1);
		}

		public static List<Indoc> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAindoc>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Indoc>((r) => new Indoc(r));
		}

// USE /[MANUAL GQT MODEL INDOC]/
	}
}
