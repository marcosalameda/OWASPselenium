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
	public class Psngr : ModelBase
	{
		[JsonIgnore]
		public CSGenioApsngr klass { get { return baseklass as CSGenioApsngr; } set { baseklass = value; } }

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
		public string ValCodpsngr { get { return klass.ValCodpsngr; } set { klass.ValCodpsngr = value; } }
		public bool ShouldSerializeValCodpsngr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValCodpsngr");

		[DisplayName("Passenger ID")]
		/// <summary>Field : "Passenger ID" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValPsngrid { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPsngrid, 0)); } set { klass.ValPsngrid = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPsngrid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValPsngrid");

		[DisplayName("First Name")]
		/// <summary>Field : "First Name" Tipo: "C" Formula:  ""</summary>
		public string ValFstname { get { return klass.ValFstname; } set { klass.ValFstname = value; } }
		public bool ShouldSerializeValFstname() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValFstname");

		[DisplayName("Last Name")]
		/// <summary>Field : "Last Name" Tipo: "C" Formula:  ""</summary>
		public string ValLstname { get { return klass.ValLstname; } set { klass.ValLstname = value; } }
		public bool ShouldSerializeValLstname() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValLstname");

		[DisplayName("Full Name")]
		/// <summary>Field : "Full Name" Tipo: "C" Formula:  ""</summary>
		public string ValFullname { get { return klass.ValFullname; } set { klass.ValFullname = value; } }
		public bool ShouldSerializeValFullname() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValFullname");

		[DisplayName("Passport Number")]
		/// <summary>Field : "Passport Number" Tipo: "C" Formula:  ""</summary>
		public string ValPassprtn { get { return klass.ValPassprtn; } set { klass.ValPassprtn = value; } }
		public bool ShouldSerializeValPassprtn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValPassprtn");

		[DisplayName("Date of Birth")]
		/// <summary>Field : "Date of Birth" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValPsngrdob { get { return klass.ValPsngrdob; } set { klass.ValPsngrdob = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPsngrdob() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValPsngrdob");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValPaddress { get { return klass.ValPaddress; } set { klass.ValPaddress = value; } }
		public bool ShouldSerializeValPaddress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValPaddress");

		[DisplayName("Email Address")]
		/// <summary>Field : "Email Address" Tipo: "C" Formula:  ""</summary>
		public string ValPsemail { get { return klass.ValPsemail; } set { klass.ValPsemail = value; } }
		public bool ShouldSerializeValPsemail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValPsemail");

		[DisplayName("Contact Number")]
		/// <summary>Field : "Contact Number" Tipo: "C" Formula:  ""</summary>
		public string ValCtcnumbr { get { return klass.ValCtcnumbr; } set { klass.ValCtcnumbr = value; } }
		public bool ShouldSerializeValCtcnumbr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValCtcnumbr");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psngr.ValZzstate");

		public Psngr() : this(UserContext.Current.User) { }

		public Psngr(User u)
		{
			this.klass = new CSGenioApsngr(u);
		}

		public Psngr(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Psngr(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Psngr(bool isEmpty) : this(isEmpty, null) { }

		public Psngr(CSGenioApsngr val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Psngr(CSGenioApsngr val) : this(val, null) { }

		public Psngr(CSGenioApsngr val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Psngr(CSGenioApsngr val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApsngr csgenioa)
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
		public static Psngr Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Psngr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApsngr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Psngr(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Psngr> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApsngr>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Psngr>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApsngr> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApsngr>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApsngr> All(CriteriaSet args = null)
		{
			return Where<CSGenioApsngr>(false, args, numRegs: -1);
		}

		public static List<Psngr> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApsngr>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Psngr>((r) => new Psngr(r));
		}

// USE /[MANUAL GQT MODEL PSNGR]/
	}
}
