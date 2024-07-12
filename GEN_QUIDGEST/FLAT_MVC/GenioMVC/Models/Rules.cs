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
	public class Rules : ModelBase
	{
		[JsonIgnore]
		public CSGenioArules klass { get { return baseklass as CSGenioArules; } set { baseklass = value; } }

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
		public string ValCodregra { get { return klass.ValCodregra; } set { klass.ValCodregra = value; } }
		public bool ShouldSerializeValCodregra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rules.ValCodregra");

		[DisplayName("Condition type")]
		/// <summary>Field : "Condition type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Tipocond", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipocond { get { return klass.ValTipocond; } set { klass.ValTipocond = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipocond { get { return new SelectList(CSGenio.business.ArrayTipocond.GetDictionary(), "Key", "Value", ValTipocond); } set { ValTipocond = value.SelectedValue as string; } }
		public bool ShouldSerializeValTipocond() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rules.ValTipocond");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rules.ValDescript");

		[DisplayName("Place where you run")]
		/// <summary>Field : "Place where you run" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Alocregr", GenioMVC.Helpers.ArrayType.Character)]
		public string ValLocal { get { return klass.ValLocal; } set { klass.ValLocal = value; } }
		[JsonIgnore]
		public SelectList ArrayVallocal { get { return new SelectList(CSGenio.business.ArrayAlocregr.GetDictionary(), "Key", "Value", ValLocal); } set { ValLocal = value.SelectedValue as string; } }
		public bool ShouldSerializeValLocal() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rules.ValLocal");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rules.ValZzstate");

		public Rules() : this(UserContext.Current.User) { }

		public Rules(User u)
		{
			this.klass = new CSGenioArules(u);
		}

		public Rules(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rules(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Rules(bool isEmpty) : this(isEmpty, null) { }

		public Rules(CSGenioArules val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Rules(CSGenioArules val) : this(val, null) { }

		public Rules(CSGenioArules val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Rules(CSGenioArules val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArules csgenioa)
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
		public static Rules Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Rules Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArules>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Rules(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Rules> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArules>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Rules>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArules> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArules>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArules> All(CriteriaSet args = null)
		{
			return Where<CSGenioArules>(false, args, numRegs: -1);
		}

		public static List<Rules> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArules>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Rules>((r) => new Rules(r));
		}

// USE /[MANUAL GQT MODEL RULES]/
	}
}
