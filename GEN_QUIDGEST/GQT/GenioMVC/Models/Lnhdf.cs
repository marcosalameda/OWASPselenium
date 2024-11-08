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
	public class Lnhdf : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlnhdf klass { get { return baseklass as CSGenioAlnhdf; } set { baseklass = value; } }

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
		public string ValCodlnhdf { get { return klass.ValCodlnhdf; } set { klass.ValCodlnhdf = value; } }
		public bool ShouldSerializeValCodlnhdf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhdf.ValCodlnhdf");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlnhde { get { return klass.ValCodlnhde; } set { klass.ValCodlnhde = value; } }
		public bool ShouldSerializeValCodlnhde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhdf.ValCodlnhde");
		private Lnhde _lnhde;
		[DisplayName("Lnhde")]
		public virtual Lnhde Lnhde { get { if (!this.isEmptyModel && (_lnhde == null || (!string.IsNullOrEmpty(ValCodlnhde) && (_lnhde.isEmptyModel || _lnhde.klass.QPrimaryKey != ValCodlnhde)))) _lnhde = Models.Lnhde.Find(ValCodlnhde, Identifier, _fieldsToSerialize); if (_lnhde == null) _lnhde = new Models.Lnhde(true, _fieldsToSerialize); return _lnhde; } set { _lnhde = value; } }
		public bool ShouldSerializeLnhde () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhde");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhdf.ValName");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lnhdf.ValZzstate");

		public Lnhdf() : this(UserContext.Current.User) { }

		public Lnhdf(User u)
		{
			this.klass = new CSGenioAlnhdf(u);
		}

		public Lnhdf(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhdf(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lnhdf(bool isEmpty) : this(isEmpty, null) { }

		public Lnhdf(CSGenioAlnhdf val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lnhdf(CSGenioAlnhdf val) : this(val, null) { }

		public Lnhdf(CSGenioAlnhdf val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lnhdf(CSGenioAlnhdf val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlnhdf csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "lnhde":
						if (_lnhde == null)
							_lnhde = new Lnhde(true, _fieldsToSerialize);
						_lnhde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lnhdf Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lnhdf Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlnhdf>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lnhdf(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lnhdf> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlnhdf>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lnhdf>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlnhdf> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlnhdf>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlnhdf> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlnhdf>(false, args, numRegs: -1);
		}

		public static List<Lnhdf> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlnhdf>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lnhdf>((r) => new Lnhdf(r));
		}

// USE /[MANUAL GQT MODEL LNHDF]/
	}
}
