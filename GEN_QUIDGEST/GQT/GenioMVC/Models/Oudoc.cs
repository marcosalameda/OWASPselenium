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
	public class Oudoc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoudoc klass { get { return baseklass as CSGenioAoudoc; } set { baseklass = value; } }

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
		public string ValCoddocsd { get { return klass.ValCoddocsd; } set { klass.ValCoddocsd = value; } }
		public bool ShouldSerializeValCoddocsd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc.ValCoddocsd");

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrdocsda { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrdocsda, 0)); } set { klass.ValNrdocsda = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNrdocsda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc.ValNrdocsda");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtdocsda { get { return klass.ValDtdocsda; } set { klass.ValDtdocsda = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtdocsda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc.ValDtdocsda");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc.ValTitle");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc.ValZzstate");

		public Oudoc() : this(UserContext.Current.User) { }

		public Oudoc(User u)
		{
			this.klass = new CSGenioAoudoc(u);
		}

		public Oudoc(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Oudoc(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Oudoc(bool isEmpty) : this(isEmpty, null) { }

		public Oudoc(CSGenioAoudoc val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Oudoc(CSGenioAoudoc val) : this(val, null) { }

		public Oudoc(CSGenioAoudoc val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Oudoc(CSGenioAoudoc val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAoudoc csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Oudoc Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Oudoc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoudoc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Oudoc(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Oudoc> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAoudoc>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Oudoc>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAoudoc> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAoudoc>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAoudoc> All(CriteriaSet args = null)
		{
			return Where<CSGenioAoudoc>(false, args, numRegs: -1);
		}

		public static List<Oudoc> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoudoc>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Oudoc>((r) => new Oudoc(r));
		}

// USE /[MANUAL GQT MODEL OUDOC]/
	}
}
