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
	public class Ware1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAware1 klass { get { return baseklass as CSGenioAware1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValCodwareh");

		[DisplayName("Warehouse")]
		/// <summary>Field : "Warehouse" Tipo: "C" Formula:  ""</summary>
		public string ValWarehdes { get { return klass.ValWarehdes; } set { klass.ValWarehdes = value; } }
		public bool ShouldSerializeValWarehdes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValWarehdes");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValWarehcod { get { return klass.ValWarehcod; } set { klass.ValWarehcod = value; } }
		public bool ShouldSerializeValWarehcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValWarehcod");

		[DisplayName("Activity")]
		/// <summary>Field : "Activity" Tipo: "AL" Formula:  ""</summary>
		[DataArray("Activida", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValActivity { get { return klass.ValActivity; } set { klass.ValActivity = value; } }
		[JsonIgnore]
		public SelectList ArrayValactivity { get { return new SelectList(CSGenio.business.ArrayActivida.GetDictionary(), "Key", "Value", ValActivity); } set { ValActivity = (int)value.SelectedValue; } }
		public bool ShouldSerializeValActivity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValActivity");

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowreco { get { return Convert.ToBoolean(klass.ValShowreco); } set { klass.ValShowreco = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowreco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValShowreco");

		[DisplayName("Number of employees")]
		/// <summary>Field : "Number of employees" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNum_employee { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNum_employee, 0)); } set { klass.ValNum_employee = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNum_employee() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValNum_employee");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1.ValZzstate");

		public Ware1() : this(UserContext.Current.User) { }

		public Ware1(User u)
		{
			this.klass = new CSGenioAware1(u);
		}

		public Ware1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ware1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Ware1(bool isEmpty) : this(isEmpty, null) { }

		public Ware1(CSGenioAware1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ware1(CSGenioAware1 val) : this(val, null) { }

		public Ware1(CSGenioAware1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Ware1(CSGenioAware1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAware1 csgenioa)
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
		public static Ware1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Ware1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAware1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ware1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Ware1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAware1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Ware1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAware1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAware1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAware1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAware1>(false, args, numRegs: -1);
		}

		public static List<Ware1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAware1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ware1>((r) => new Ware1(r));
		}

// USE /[MANUAL GQT MODEL WARE1]/
	}
}
