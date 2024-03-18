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
	public class Roigf : ModelBase
	{
		[JsonIgnore]
		public CSGenioAroigf klass { get { return baseklass as CSGenioAroigf; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodroigf { get { return klass.ValCodroigf; } set { klass.ValCodroigf = value; } }
		public bool ShouldSerializeValCodroigf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Roigf.ValCodroigf");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrogl1 { get { return klass.ValCodrogl1; } set { klass.ValCodrogl1 = value; } }
		public bool ShouldSerializeValCodrogl1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Roigf.ValCodrogl1");
		private Rogl1 _rogl1;
		[DisplayName("Rogl1")]
		public virtual Rogl1 Rogl1 { get { if (!this.isEmptyModel && (_rogl1 == null || (!string.IsNullOrEmpty(ValCodrogl1) && (_rogl1.isEmptyModel || _rogl1.klass.QPrimaryKey != ValCodrogl1)))) _rogl1 = Models.Rogl1.Find(ValCodrogl1, Identifier, _fieldsToSerialize); if (_rogl1 == null) _rogl1 = new Models.Rogl1(true, _fieldsToSerialize); return _rogl1; } set { _rogl1 = value; } }
		public bool ShouldSerializeRogl1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rogl1");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(1)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 1)); } set { klass.ValOrder = Convert.ToDouble(value); } }
		public bool ShouldSerializeValOrder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Roigf.ValOrder");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Roigf.ValTitle");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Roigf.ValZzstate");

		public Roigf() : this(UserContext.Current.User) { }

		public Roigf(User u)
		{
			this.klass = new CSGenioAroigf(u);
		}

		public Roigf(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Roigf(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Roigf(bool isEmpty) : this(isEmpty, null) { }

		public Roigf(CSGenioAroigf val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Roigf(CSGenioAroigf val) : this(val, null) { }

		public Roigf(CSGenioAroigf val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Roigf(CSGenioAroigf val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAroigf csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "rogl1":
						if (_rogl1 == null)
							_rogl1 = new Rogl1(true, _fieldsToSerialize);
						_rogl1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Roigf Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Roigf Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAroigf>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Roigf(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Roigf> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAroigf>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Roigf>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAroigf> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAroigf>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAroigf> All(CriteriaSet args = null)
		{
			return Where<CSGenioAroigf>(false, args, numRegs: -1);
		}

		public static List<Roigf> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAroigf>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Roigf>((r) => new Roigf(r));
		}

// USE /[MANUAL GQT MODEL ROIGF]/
	}
}
