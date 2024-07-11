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
	public class Outpt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoutpt klass { get { return baseklass as CSGenioAoutpt; } set { baseklass = value; } }

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
		public string ValCodoutpt { get { return klass.ValCodoutpt; } set { klass.ValCodoutpt = value; } }
		public bool ShouldSerializeValCodoutpt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt.ValCodoutpt");

		[DisplayName("BY OMISSION")]
		/// <summary>Field : "BY OMISSION" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt.ValCodwareh");
		private Ware1 _ware1;
		[DisplayName("Ware1")]
		public virtual Ware1 Ware1 { get { if (!this.isEmptyModel && (_ware1 == null || (!string.IsNullOrEmpty(ValCodwareh) && (_ware1.isEmptyModel || _ware1.klass.QPrimaryKey != ValCodwareh)))) _ware1 = Models.Ware1.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_ware1 == null) _ware1 = new Models.Ware1(true, _fieldsToSerialize); return _ware1; } set { _ware1 = value; } }
		public bool ShouldSerializeWare1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ware1");

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDocumenr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDocumenr, 0)); } set { klass.ValDocumenr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDocumenr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt.ValDocumenr");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhdocume { get { return klass.ValDhdocume; } set { klass.ValDhdocume = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDhdocume() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt.ValDhdocume");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt.ValZzstate");

		public Outpt() : this(UserContext.Current.User) { }

		public Outpt(User u)
		{
			this.klass = new CSGenioAoutpt(u);
		}

		public Outpt(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpt(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Outpt(bool isEmpty) : this(isEmpty, null) { }

		public Outpt(CSGenioAoutpt val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpt(CSGenioAoutpt val) : this(val, null) { }

		public Outpt(CSGenioAoutpt val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Outpt(CSGenioAoutpt val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAoutpt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "ware1":
						if (_ware1 == null)
							_ware1 = new Ware1(true, _fieldsToSerialize);
						_ware1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Outpt Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Outpt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoutpt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Outpt(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Outpt> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAoutpt>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Outpt>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAoutpt> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAoutpt>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAoutpt> All(CriteriaSet args = null)
		{
			return Where<CSGenioAoutpt>(false, args, numRegs: -1);
		}

		public static List<Outpt> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoutpt>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Outpt>((r) => new Outpt(r));
		}

// USE /[MANUAL GQT MODEL OUTPT]/
	}
}
