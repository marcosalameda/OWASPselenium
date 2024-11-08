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
	public class Tradu : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtradu klass { get { return baseklass as CSGenioAtradu; } set { baseklass = value; } }

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
		public string ValCodtradu { get { return klass.ValCodtradu; } set { klass.ValCodtradu = value; } }
		public bool ShouldSerializeValCodtradu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValCodtradu");

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }
		public bool ShouldSerializeValReferenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValReferenc");

		[DisplayName("language")]
		/// <summary>Field : "language" Tipo: "CE" Formula:  ""</summary>
		public string ValCodidio1 { get { return klass.ValCodidio1; } set { klass.ValCodidio1 = value; } }
		public bool ShouldSerializeValCodidio1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValCodidio1");
		private Lang1 _lang1;
		[DisplayName("Lang1")]
		public virtual Lang1 Lang1 { get { if (!this.isEmptyModel && (_lang1 == null || (!string.IsNullOrEmpty(ValCodidio1) && (_lang1.isEmptyModel || _lang1.klass.QPrimaryKey != ValCodidio1)))) _lang1 = Models.Lang1.Find(ValCodidio1, Identifier, _fieldsToSerialize); if (_lang1 == null) _lang1 = new Models.Lang1(true, _fieldsToSerialize); return _lang1; } set { _lang1 = value; } }
		public bool ShouldSerializeLang1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lang1");

		[DisplayName("To review")]
		/// <summary>Field : "To review" Tipo: "C" Formula:  ""</summary>
		public string ValAtraduzi { get { return klass.ValAtraduzi; } set { klass.ValAtraduzi = value; } }
		public bool ShouldSerializeValAtraduzi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValAtraduzi");

		[DisplayName("Language")]
		/// <summary>Field : "Language" Tipo: "CE" Formula:  ""</summary>
		public string ValCodidio2 { get { return klass.ValCodidio2; } set { klass.ValCodidio2 = value; } }
		public bool ShouldSerializeValCodidio2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValCodidio2");
		private Lang2 _lang2;
		[DisplayName("Lang2")]
		public virtual Lang2 Lang2 { get { if (!this.isEmptyModel && (_lang2 == null || (!string.IsNullOrEmpty(ValCodidio2) && (_lang2.isEmptyModel || _lang2.klass.QPrimaryKey != ValCodidio2)))) _lang2 = Models.Lang2.Find(ValCodidio2, Identifier, _fieldsToSerialize); if (_lang2 == null) _lang2 = new Models.Lang2(true, _fieldsToSerialize); return _lang2; } set { _lang2 = value; } }
		public bool ShouldSerializeLang2 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lang2");

		[DisplayName("Translated")]
		/// <summary>Field : "Translated" Tipo: "C" Formula:  ""</summary>
		public string ValTraduzid { get { return klass.ValTraduzid; } set { klass.ValTraduzid = value; } }
		public bool ShouldSerializeValTraduzid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValTraduzid");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tradu.ValZzstate");

		public Tradu() : this(UserContext.Current.User) { }

		public Tradu(User u)
		{
			this.klass = new CSGenioAtradu(u);
		}

		public Tradu(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tradu(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tradu(bool isEmpty) : this(isEmpty, null) { }

		public Tradu(CSGenioAtradu val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tradu(CSGenioAtradu val) : this(val, null) { }

		public Tradu(CSGenioAtradu val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tradu(CSGenioAtradu val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtradu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lang1":
						if (_lang1 == null)
							_lang1 = new Lang1(true, _fieldsToSerialize);
						_lang1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "lang2":
						if (_lang2 == null)
							_lang2 = new Lang2(true, _fieldsToSerialize);
						_lang2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tradu Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tradu Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtradu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tradu(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tradu> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtradu>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tradu>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtradu> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtradu>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtradu> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtradu>(false, args, numRegs: -1);
		}

		public static List<Tradu> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtradu>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tradu>((r) => new Tradu(r));
		}

// USE /[MANUAL GQT MODEL TRADU]/
	}
}
