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
	public class Pedid : ModelBase
	{
		[JsonIgnore]
		public CSGenioApedid klass { get { return baseklass as CSGenioApedid; } set { baseklass = value; } }

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
		public string ValCodpedid { get { return klass.ValCodpedid; } set { klass.ValCodpedid = value; } }
		public bool ShouldSerializeValCodpedid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid.ValCodpedid");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtpedido { get { return klass.ValDtpedido; } set { klass.ValDtpedido = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtpedido() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid.ValDtpedido");

		[DisplayName("No.")]
		/// <summary>Field : "No." Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrpedido { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrpedido, 0)); } set { klass.ValNrpedido = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNrpedido() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid.ValNrpedido");

		[DisplayName("Reason")]
		/// <summary>Field : "Reason" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMotivo { get { return klass.ValMotivo; } set { klass.ValMotivo = value; } }
		public bool ShouldSerializeValMotivo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid.ValMotivo");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pedid.ValZzstate");

		public Pedid() : this(UserContext.Current.User) { }

		public Pedid(User u)
		{
			this.klass = new CSGenioApedid(u);
		}

		public Pedid(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pedid(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pedid(bool isEmpty) : this(isEmpty, null) { }

		public Pedid(CSGenioApedid val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pedid(CSGenioApedid val) : this(val, null) { }

		public Pedid(CSGenioApedid val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pedid(CSGenioApedid val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApedid csgenioa)
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
		public static Pedid Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Pedid Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApedid>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pedid(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pedid> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApedid>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pedid>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApedid> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApedid>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApedid> All(CriteriaSet args = null)
		{
			return Where<CSGenioApedid>(false, args, numRegs: -1);
		}

		public static List<Pedid> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApedid>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pedid>((r) => new Pedid(r));
		}

// USE /[MANUAL GQT MODEL PEDID]/
	}
}
