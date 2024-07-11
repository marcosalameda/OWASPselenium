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
	public class Decom : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdecom klass { get { return baseklass as CSGenioAdecom; } set { baseklass = value; } }

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
		public string ValCoddeco { get { return klass.ValCoddeco; } set { klass.ValCoddeco = value; } }
		public bool ShouldSerializeValCoddeco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValCoddeco");

		[DisplayName("Decomission")]
		/// <summary>Field : "Decomission" Tipo: "DT" Formula: DF "[Now]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtdeco { get { return klass.ValDtdeco; } set { klass.ValDtdeco = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtdeco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValDtdeco");

		[DisplayName("No bate")]
		/// <summary>Field : "No bate" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDecomnr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDecomnr, 0)); } set { klass.ValDecomnr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDecomnr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValDecomnr");

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValNote { get { return klass.ValNote; } set { klass.ValNote = value; } }
		public bool ShouldSerializeValNote() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValNote");

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValCreatdat");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValCreatope");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValChngdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValChngdate");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }
		public bool ShouldSerializeValOperchng() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValOperchng");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Decom.ValZzstate");

		public Decom() : this(UserContext.Current.User) { }

		public Decom(User u)
		{
			this.klass = new CSGenioAdecom(u);
		}

		public Decom(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Decom(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Decom(bool isEmpty) : this(isEmpty, null) { }

		public Decom(CSGenioAdecom val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Decom(CSGenioAdecom val) : this(val, null) { }

		public Decom(CSGenioAdecom val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Decom(CSGenioAdecom val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAdecom csgenioa)
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
		public static Decom Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Decom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdecom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Decom(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Decom> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdecom>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Decom>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdecom> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdecom>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdecom> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdecom>(false, args, numRegs: -1);
		}

		public static List<Decom> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdecom>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Decom>((r) => new Decom(r));
		}

// USE /[MANUAL GQT MODEL DECOM]/
	}
}
