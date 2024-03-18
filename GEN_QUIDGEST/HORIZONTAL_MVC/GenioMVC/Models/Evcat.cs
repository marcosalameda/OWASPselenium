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
	public class Evcat : ModelBase
	{
		[JsonIgnore]
		public CSGenioAevcat klass { get { return baseklass as CSGenioAevcat; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodprogr { get { return klass.ValCodprogr; } set { klass.ValCodprogr = value; } }
		public bool ShouldSerializeValCodprogr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValCodprogr");

		[DisplayName(">PERSON")]
		/// <summary>Field : ">PERSON" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValCodpesso");
		private Pesso _pesso;
		[DisplayName("Pesso")]
		public virtual Pesso Pesso { get { if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso)))) _pesso = Models.Pesso.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pesso == null) _pesso = new Models.Pesso(true, _fieldsToSerialize); return _pesso; } set { _pesso = value; } }
		public bool ShouldSerializePesso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso");

		[DisplayName(">CATEGORy")]
		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		public bool ShouldSerializeValCodcateg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValCodcateg");
		private Cate1 _cate1;
		[DisplayName("Cate1")]
		public virtual Cate1 Cate1 { get { if (!this.isEmptyModel && (_cate1 == null || (!string.IsNullOrEmpty(ValCodcateg) && (_cate1.isEmptyModel || _cate1.klass.QPrimaryKey != ValCodcateg)))) _cate1 = Models.Cate1.Find(ValCodcateg, Identifier, _fieldsToSerialize); if (_cate1 == null) _cate1 = new Models.Cate1(true, _fieldsToSerialize); return _cate1; } set { _cate1 = value; } }
		public bool ShouldSerializeCate1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cate1");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValSince() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValSince");

		[DisplayName("Up manual")]
		/// <summary>Field : "Up manual" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValUntilman { get { return klass.ValUntilman; } set { klass.ValUntilman = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValUntilman() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValUntilman");

		[DisplayName("Until")]
		/// <summary>Field : "Until" Tipo: "D" Formula: FP "[EVCAT->SINCE][EVCAT->CODPESSO]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValUntil { get { return klass.ValUntil; } set { klass.ValUntil = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValUntil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValUntil");

		[DisplayName("Observation")]
		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }
		public bool ShouldSerializeValObservat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValObservat");

		[DisplayName("End-of-period")]
		/// <summary>Field : "End-of-period" Tipo: "D" Formula: + "iif(emptyD([EVCAT->UNTILMAN])==0,[EVCAT->UNTILMAN],[EVCAT->UNTIL])"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFimperio { get { return klass.ValFimperio; } set { klass.ValFimperio = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValFimperio() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValFimperio");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Evcat.ValZzstate");

		public Evcat() : this(UserContext.Current.User) { }

		public Evcat(User u)
		{
			this.klass = new CSGenioAevcat(u);
		}

		public Evcat(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Evcat(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Evcat(bool isEmpty) : this(isEmpty, null) { }

		public Evcat(CSGenioAevcat val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Evcat(CSGenioAevcat val) : this(val, null) { }

		public Evcat(CSGenioAevcat val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Evcat(CSGenioAevcat val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAevcat csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cate1":
						if (_cate1 == null)
							_cate1 = new Cate1(true, _fieldsToSerialize);
						_cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Evcat Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Evcat Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAevcat>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Evcat(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Evcat> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAevcat>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Evcat>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAevcat> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAevcat>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAevcat> All(CriteriaSet args = null)
		{
			return Where<CSGenioAevcat>(false, args, numRegs: -1);
		}

		public static List<Evcat> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAevcat>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Evcat>((r) => new Evcat(r));
		}

// USE /[MANUAL GQT MODEL EVCAT]/
	}
}
