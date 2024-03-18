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
	public class Addre : ModelBase
	{
		[JsonIgnore]
		public CSGenioAaddre klass { get { return baseklass as CSGenioAaddre; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodaddre { get { return klass.ValCodaddre; } set { klass.ValCodaddre = value; } }
		public bool ShouldSerializeValCodaddre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValCodaddre");

		[DisplayName("Address Use")]
		/// <summary>Field : "Address Use" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Addressu", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddressuse { get { return klass.ValAddressuse; } set { klass.ValAddressuse = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddressuse { get { return new SelectList(CSGenio.business.ArrayAddressu.GetDictionary(), "Key", "Value", ValAddressuse); } set { ValAddressuse = value.SelectedValue as string; } }
		public bool ShouldSerializeValAddressuse() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddressuse");

		[DisplayName("Address Type")]
		/// <summary>Field : "Address Type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Addresst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddresstype { get { return klass.ValAddresstype; } set { klass.ValAddresstype = value; } }
		[JsonIgnore]
		public SelectList ArrayValaddresstype { get { return new SelectList(CSGenio.business.ArrayAddresst.GetDictionary(), "Key", "Value", ValAddresstype); } set { ValAddresstype = value.SelectedValue as string; } }
		public bool ShouldSerializeValAddresstype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddresstype");

		[DisplayName("Entire address")]
		/// <summary>Field : "Entire address" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAddresstext { get { return klass.ValAddresstext; } set { klass.ValAddresstext = value; } }
		public bool ShouldSerializeValAddresstext() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddresstext");

		[DisplayName("Address City")]
		/// <summary>Field : "Address City" Tipo: "C" Formula:  ""</summary>
		public string ValAddresscity { get { return klass.ValAddresscity; } set { klass.ValAddresscity = value; } }
		public bool ShouldSerializeValAddresscity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddresscity");

		[DisplayName("Address District")]
		/// <summary>Field : "Address District" Tipo: "C" Formula:  ""</summary>
		public string ValAddressdistrict { get { return klass.ValAddressdistrict; } set { klass.ValAddressdistrict = value; } }
		public bool ShouldSerializeValAddressdistrict() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddressdistrict");

		[DisplayName("Address State")]
		/// <summary>Field : "Address State" Tipo: "C" Formula:  ""</summary>
		public string ValAddressstate { get { return klass.ValAddressstate; } set { klass.ValAddressstate = value; } }
		public bool ShouldSerializeValAddressstate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddressstate");

		[DisplayName("Address Postal Code")]
		/// <summary>Field : "Address Postal Code" Tipo: "C" Formula:  ""</summary>
		public string ValAddresspostalcode { get { return klass.ValAddresspostalcode; } set { klass.ValAddresspostalcode = value; } }
		public bool ShouldSerializeValAddresspostalcode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddresspostalcode");

		[DisplayName("Address Country")]
		/// <summary>Field : "Address Country" Tipo: "C" Formula:  ""</summary>
		public string ValAddresscountry { get { return klass.ValAddresscountry; } set { klass.ValAddresscountry = value; } }
		public bool ShouldSerializeValAddresscountry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValAddresscountry");

		[DisplayName("Period Start")]
		/// <summary>Field : "Period Start" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodstart { get { return klass.ValPeriodstart; } set { klass.ValPeriodstart = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPeriodstart() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValPeriodstart");

		[DisplayName("Period End")]
		/// <summary>Field : "Period End" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPeriodend { get { return klass.ValPeriodend; } set { klass.ValPeriodend = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPeriodend() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValPeriodend");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Addre.ValZzstate");

		public Addre() : this(UserContext.Current.User) { }

		public Addre(User u)
		{
			this.klass = new CSGenioAaddre(u);
		}

		public Addre(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Addre(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Addre(bool isEmpty) : this(isEmpty, null) { }

		public Addre(CSGenioAaddre val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Addre(CSGenioAaddre val) : this(val, null) { }

		public Addre(CSGenioAaddre val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Addre(CSGenioAaddre val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAaddre csgenioa)
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
		public static Addre Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Addre Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAaddre>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Addre(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Addre> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAaddre>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Addre>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAaddre> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAaddre>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAaddre> All(CriteriaSet args = null)
		{
			return Where<CSGenioAaddre>(false, args, numRegs: -1);
		}

		public static List<Addre> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAaddre>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Addre>((r) => new Addre(r));
		}

// USE /[MANUAL GQT MODEL ADDRE]/
	}
}
