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
	public class Ldent : ModelBase
	{
		[JsonIgnore]
		public CSGenioAldent klass { get { return baseklass as CSGenioAldent; } set { baseklass = value; } }

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
		public string ValCodldent { get { return klass.ValCodldent; } set { klass.ValCodldent = value; } }
		public bool ShouldSerializeValCodldent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValCodldent");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }
		public bool ShouldSerializeValCoddentr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValCoddentr");
		private Indoc _indoc;
		[DisplayName("Indoc")]
		public virtual Indoc Indoc { get { if (!this.isEmptyModel && (_indoc == null || (!string.IsNullOrEmpty(ValCoddentr) && (_indoc.isEmptyModel || _indoc.klass.QPrimaryKey != ValCoddentr)))) _indoc = Models.Indoc.Find(ValCoddentr, Identifier, _fieldsToSerialize); if (_indoc == null) _indoc = new Models.Indoc(true, _fieldsToSerialize); return _indoc; } set { _indoc = value; } }
		public bool ShouldSerializeIndoc () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Indoc");

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(1)]
		public decimal? ValLine { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLine, 1)); } set { klass.ValLine = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLine() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValLine");

		[DisplayName(">ARMAZEM")]
		/// <summary>Field : ">ARMAZEM" Tipo: "CE" Formula: DF "[INDOC->CODWAREH]"</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValCodwareh");
		private Wareh _wareh;
		[DisplayName("Wareh")]
		public virtual Wareh Wareh { get { if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh)))) _wareh = Models.Wareh.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_wareh == null) _wareh = new Models.Wareh(true, _fieldsToSerialize); return _wareh; } set { _wareh = value; } }
		public bool ShouldSerializeWareh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh");

		[DisplayName(">ARTICLE")]
		/// <summary>Field : ">ARTICLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		public bool ShouldSerializeValCoditem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValCoditem");
		private Item _item;
		[DisplayName("Item")]
		public virtual Item Item { get { if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem)))) _item = Models.Item.Find(ValCoditem, Identifier, _fieldsToSerialize); if (_item == null) _item = new Models.Item(true, _fieldsToSerialize); return _item; } set { _item = value; } }
		public bool ShouldSerializeItem () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Item");

		[DisplayName("Qtd entry")]
		/// <summary>Field : "Qtd entry" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdentra { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdentra, 0)); } set { klass.ValQtdentra = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtdentra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValQtdentra");

		[DisplayName("Instant entrance")]
		/// <summary>Field : "Instant entrance" Tipo: "DT" Formula: ++ "[INDOC->DHDOCUME]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhentra { get { return klass.ValDhentra; } set { klass.ValDhentra = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDhentra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValDhentra");

		[DisplayName("Articles in use")]
		/// <summary>Field : "Articles in use" Tipo: "L" Formula:  ""</summary>
		public bool ValEmuso { get { return Convert.ToBoolean(klass.ValEmuso); } set { klass.ValEmuso = Convert.ToInt32(value); } }
		public bool ShouldSerializeValEmuso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValEmuso");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Ldent.ValZzstate");

		public Ldent() : this(UserContext.Current.User) { }

		public Ldent(User u)
		{
			this.klass = new CSGenioAldent(u);
		}

		public Ldent(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ldent(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Ldent(bool isEmpty) : this(isEmpty, null) { }

		public Ldent(CSGenioAldent val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ldent(CSGenioAldent val) : this(val, null) { }

		public Ldent(CSGenioAldent val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Ldent(CSGenioAldent val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAldent csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "indoc":
						if (_indoc == null)
							_indoc = new Indoc(true, _fieldsToSerialize);
						_indoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Ldent Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Ldent Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAldent>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ldent(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Ldent> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAldent>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Ldent>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAldent> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAldent>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAldent> All(CriteriaSet args = null)
		{
			return Where<CSGenioAldent>(false, args, numRegs: -1);
		}

		public static List<Ldent> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAldent>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ldent>((r) => new Ldent(r));
		}

// USE /[MANUAL GQT MODEL LDENT]/
	}
}
