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
	public class Addrl : ModelBase
	{
		[JsonIgnore]
		public CSGenioAaddrl klass { get { return baseklass as CSGenioAaddrl; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Address" Tipo: "+" Formula:  ""</summary>
		public string ValCustomeraddressid { get { return klass.ValCustomeraddressid; } set { klass.ValCustomeraddressid = value; } }
		public bool ShouldSerializeValCustomeraddressid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValCustomeraddressid");

		[DisplayName("Parent")]
		/// <summary>Field : "Parent" Tipo: "CF" Formula:  ""</summary>
		public string ValParentid { get { return klass.ValParentid; } set { klass.ValParentid = value; } }
		public bool ShouldSerializeValParentid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValParentid");

		[DisplayName("parentId Type")]
		/// <summary>Field : "parentId Type" Tipo: "C" Formula:  ""</summary>
		public string ValParentidtypecode { get { return klass.ValParentidtypecode; } set { klass.ValParentidtypecode = value; } }
		public bool ShouldSerializeValParentidtypecode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValParentidtypecode");

		[DisplayName("Address Number")]
		/// <summary>Field : "Address Number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValAddressnumber { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAddressnumber, 0)); } set { klass.ValAddressnumber = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValAddressnumber() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValAddressnumber");

		[DisplayName("Object Type")]
		/// <summary>Field : "Object Type" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Objetype", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValObjecttypecode { get { return klass.ValObjecttypecode; } set { klass.ValObjecttypecode = value; } }
		[JsonIgnore]
		public SelectList ArrayValobjecttypecode { get { return new SelectList(CSGenio.business.ArrayObjetype.GetDictionary(), "Key", "Value", ValObjecttypecode); } set { ValObjecttypecode = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValObjecttypecode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValObjecttypecode");

		[DisplayName("objectTypeCode_display")]
		/// <summary>Field : "objectTypeCode_display" Tipo: "C" Formula:  ""</summary>
		public string ValObjecttypecode_display { get { return klass.ValObjecttypecode_display; } set { klass.ValObjecttypecode_display = value; } }
		public bool ShouldSerializeValObjecttypecode_display() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValObjecttypecode_display");

		[DisplayName("Address Type Code")]
		/// <summary>Field : "Address Type Code" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Addrtyco", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValAddresstypecode { get { return klass.ValAddresstypecode; } set { klass.ValAddresstypecode = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddresstypecode { get { return new SelectList(CSGenio.business.ArrayAddrtyco.GetDictionary(), "Key", "Value", ValAddresstypecode); } set { ValAddresstypecode = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValAddresstypecode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValAddresstypecode");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addrl.ValZzstate");

		public Addrl() : this(UserContext.Current.User) { }

		public Addrl(User u)
		{
			this.klass = new CSGenioAaddrl(u);
		}

		public Addrl(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Addrl(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Addrl(bool isEmpty) : this(isEmpty, null) { }

		public Addrl(CSGenioAaddrl val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Addrl(CSGenioAaddrl val) : this(val, null) { }

		public Addrl(CSGenioAaddrl val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Addrl(CSGenioAaddrl val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAaddrl csgenioa)
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
		public static Addrl Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Addrl Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAaddrl>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Addrl(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Addrl> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAaddrl>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Addrl>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAaddrl> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAaddrl>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAaddrl> All(CriteriaSet args = null)
		{
			return Where<CSGenioAaddrl>(false, args, numRegs: -1);
		}

		public static List<Addrl> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAaddrl>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Addrl>((r) => new Addrl(r));
		}

// USE /[MANUAL GQT MODEL ADDRL]/
	}
}
