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
	public class Fltsc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfltsc klass { get { return baseklass as CSGenioAfltsc; } set { baseklass = value; } }

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
		public string ValCodfltsc { get { return klass.ValCodfltsc; } set { klass.ValCodfltsc = value; } }
		public bool ShouldSerializeValCodfltsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fltsc.ValCodfltsc");

		[DisplayName("Scale ID")]
		/// <summary>Field : "Scale ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValScaleid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValScaleid, 0)); } set { klass.ValScaleid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValScaleid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fltsc.ValScaleid");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfligh { get { return klass.ValCodfligh; } set { klass.ValCodfligh = value; } }
		public bool ShouldSerializeValCodfligh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fltsc.ValCodfligh");
		private Fligh _fligh;
		[DisplayName("Fligh")]
		public virtual Fligh Fligh { get { if (!this.isEmptyModel && (_fligh == null || (!string.IsNullOrEmpty(ValCodfligh) && (_fligh.isEmptyModel || _fligh.klass.QPrimaryKey != ValCodfligh)))) _fligh = Models.Fligh.Find(ValCodfligh, Identifier, _fieldsToSerialize); if (_fligh == null) _fligh = new Models.Fligh(true, _fieldsToSerialize); return _fligh; } set { _fligh = value; } }
		public bool ShouldSerializeFligh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fligh");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fltsc.ValZzstate");

		public Fltsc() : this(UserContext.Current.User) { }

		public Fltsc(User u)
		{
			this.klass = new CSGenioAfltsc(u);
		}

		public Fltsc(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fltsc(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Fltsc(bool isEmpty) : this(isEmpty, null) { }

		public Fltsc(CSGenioAfltsc val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Fltsc(CSGenioAfltsc val) : this(val, null) { }

		public Fltsc(CSGenioAfltsc val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Fltsc(CSGenioAfltsc val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAfltsc csgenioa)
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
		public static Fltsc Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Fltsc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfltsc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Fltsc(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Fltsc> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfltsc>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Fltsc>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfltsc> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfltsc>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfltsc> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfltsc>(false, args, numRegs: -1);
		}

		public static List<Fltsc> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfltsc>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Fltsc>((r) => new Fltsc(r));
		}

// USE /[MANUAL GQT MODEL FLTSC]/
	}
}
