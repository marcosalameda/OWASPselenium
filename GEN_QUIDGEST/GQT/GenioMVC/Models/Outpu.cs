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
	public class Outpu : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoutpu klass { get { return baseklass as CSGenioAoutpu; } set { baseklass = value; } }

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
		public string ValCodoutpu { get { return klass.ValCodoutpu; } set { klass.ValCodoutpu = value; } }
		public bool ShouldSerializeValCodoutpu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValCodoutpu");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodoutpt { get { return klass.ValCodoutpt; } set { klass.ValCodoutpt = value; } }
		public bool ShouldSerializeValCodoutpt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValCodoutpt");
		private Outpt _outpt;
		[DisplayName("Outpt")]
		public virtual Outpt Outpt { get { if (!this.isEmptyModel && (_outpt == null || (!string.IsNullOrEmpty(ValCodoutpt) && (_outpt.isEmptyModel || _outpt.klass.QPrimaryKey != ValCodoutpt)))) _outpt = Models.Outpt.Find(ValCodoutpt, Identifier, _fieldsToSerialize); if (_outpt == null) _outpt = new Models.Outpt(true, _fieldsToSerialize); return _outpt; } set { _outpt = value; } }
		public bool ShouldSerializeOutpt () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpt");

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(1)]
		public decimal? ValLine { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValLine, 1)); } set { klass.ValLine = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLine() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValLine");

		[DisplayName(">WAREHOUSE")]
		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula: DF "[OUTPT->CODWAREH]"</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValCodwareh");
		private Wareh _wareh;
		[DisplayName("Wareh")]
		public virtual Wareh Wareh { get { if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh)))) _wareh = Models.Wareh.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_wareh == null) _wareh = new Models.Wareh(true, _fieldsToSerialize); return _wareh; } set { _wareh = value; } }
		public bool ShouldSerializeWareh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh");

		[DisplayName(">ARTICLE")]
		/// <summary>Field : ">ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("Exit instant")]
		/// <summary>Field : "Exit instant" Tipo: "DT" Formula: ++ "[OUTPT->DHDOCUME]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValExitdt { get { return klass.ValExitdt; } set { klass.ValExitdt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValExitdt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValExitdt");

		[DisplayName(">EXIT DOCUMENT")]
		/// <summary>Field : ">EXIT DOCUMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddocsd { get { return klass.ValCoddocsd; } set { klass.ValCoddocsd = value; } }
		public bool ShouldSerializeValCoddocsd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValCoddocsd");
		private Oudoc _oudoc;
		[DisplayName("Oudoc")]
		public virtual Oudoc Oudoc { get { if (!this.isEmptyModel && (_oudoc == null || (!string.IsNullOrEmpty(ValCoddocsd) && (_oudoc.isEmptyModel || _oudoc.klass.QPrimaryKey != ValCoddocsd)))) _oudoc = Models.Oudoc.Find(ValCoddocsd, Identifier, _fieldsToSerialize); if (_oudoc == null) _oudoc = new Models.Oudoc(true, _fieldsToSerialize); return _oudoc; } set { _oudoc = value; } }
		public bool ShouldSerializeOudoc () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Oudoc");

		[DisplayName("Qtd output")]
		/// <summary>Field : "Qtd output" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValExitqnty { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValExitqnty, 0)); } set { klass.ValExitqnty = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValExitqnty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValExitqnty");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Outpu.ValZzstate");

		public Outpu() : this(UserContext.Current.User) { }

		public Outpu(User u)
		{
			this.klass = new CSGenioAoutpu(u);
		}

		public Outpu(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpu(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Outpu(bool isEmpty) : this(isEmpty, null) { }

		public Outpu(CSGenioAoutpu val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpu(CSGenioAoutpu val) : this(val, null) { }

		public Outpu(CSGenioAoutpu val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Outpu(CSGenioAoutpu val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAoutpu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "outpt":
						if (_outpt == null)
							_outpt = new Outpt(true, _fieldsToSerialize);
						_outpt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "item":
						if (_item == null)
							_item = new Item(true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "oudoc":
						if (_oudoc == null)
							_oudoc = new Oudoc(true, _fieldsToSerialize);
						_oudoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Outpu Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Outpu Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoutpu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Outpu(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Outpu> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAoutpu>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Outpu>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAoutpu> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAoutpu>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAoutpu> All(CriteriaSet args = null)
		{
			return Where<CSGenioAoutpu>(false, args, numRegs: -1);
		}

		public static List<Outpu> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoutpu>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Outpu>((r) => new Outpu(r));
		}

// USE /[MANUAL GQT MODEL OUTPU]/
	}
}
