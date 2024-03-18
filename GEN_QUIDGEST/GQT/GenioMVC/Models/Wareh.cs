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
	public class Wareh : ModelBase
	{
		[JsonIgnore]
		public CSGenioAwareh klass { get { return baseklass as CSGenioAwareh; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValCodwareh");

		[DisplayName("Warehouse")]
		/// <summary>Field : "Warehouse" Tipo: "C" Formula:  ""</summary>
		public string ValWarehdes { get { return klass.ValWarehdes; } set { klass.ValWarehdes = value; } }
		public bool ShouldSerializeValWarehdes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValWarehdes");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValWarehcod { get { return klass.ValWarehcod; } set { klass.ValWarehcod = value; } }
		public bool ShouldSerializeValWarehcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValWarehcod");

		[DisplayName("Activity")]
		/// <summary>Field : "Activity" Tipo: "AL" Formula:  ""</summary>
		[DataArray("Activida", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValActivity { get { return klass.ValActivity; } set { klass.ValActivity = value; } }
		[JsonIgnore]
		public SelectList ArrayValactivity { get { return new SelectList(CSGenio.business.ArrayActivida.GetDictionary(), "Key", "Value", ValActivity); } set { ValActivity = (int)value.SelectedValue; } }
		public bool ShouldSerializeValActivity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValActivity");

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowreco { get { return Convert.ToBoolean(klass.ValShowreco); } set { klass.ValShowreco = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowreco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValShowreco");

		[DisplayName("Number of employees")]
		/// <summary>Field : "Number of employees" Tipo: "N" Formula: SR "[WPESS->1]"</summary>
		[NumericAttribute(0)]
		public decimal? ValNum_employee { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNum_employee, 0)); } set { klass.ValNum_employee = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNum_employee() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValNum_employee");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh.ValZzstate");

		public Wareh() : this(UserContext.Current.User) { }

		public Wareh(User u)
		{
			this.klass = new CSGenioAwareh(u);
		}

		public Wareh(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Wareh(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Wareh(bool isEmpty) : this(isEmpty, null) { }

		public Wareh(CSGenioAwareh val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Wareh(CSGenioAwareh val) : this(val, null) { }

		public Wareh(CSGenioAwareh val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Wareh(CSGenioAwareh val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAwareh csgenioa)
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
		public static Wareh Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Wareh Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAwareh>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Wareh(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Wareh> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAwareh>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Wareh>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAwareh> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAwareh>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAwareh> All(CriteriaSet args = null)
		{
			return Where<CSGenioAwareh>(false, args, numRegs: -1);
		}

		public static List<Wareh> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAwareh>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Wareh>((r) => new Wareh(r));
		}

// USE /[MANUAL GQT MODEL WAREH]/
	}
}
