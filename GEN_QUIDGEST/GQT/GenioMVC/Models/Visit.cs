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
	public class Visit : ModelBase
	{
		[JsonIgnore]
		public CSGenioAvisit klass { get { return baseklass as CSGenioAvisit; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodvisit { get { return klass.ValCodvisit; } set { klass.ValCodvisit = value; } }
		public bool ShouldSerializeValCodvisit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValCodvisit");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValTitle");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValStartdt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValStartdt");

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtfim { get { return klass.ValDtfim; } set { klass.ValDtfim = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtfim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValDtfim");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValDescript");

		[DisplayName("Day")]
		/// <summary>Field : "Day" Tipo: "L" Formula:  ""</summary>
		public bool ValTodoodia { get { return Convert.ToBoolean(klass.ValTodoodia); } set { klass.ValTodoodia = Convert.ToInt32(value); } }
		public bool ShouldSerializeValTodoodia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValTodoodia");

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "C" Formula:  ""</summary>
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }
		public bool ShouldSerializeValObservat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValObservat");

		[DisplayName("Color")]
		/// <summary>Field : "Color" Tipo: "C" Formula:  ""</summary>
		public string ValColor { get { return klass.ValColor; } set { klass.ValColor = value; } }
		public bool ShouldSerializeValColor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValColor");

		[DisplayName("Background")]
		/// <summary>Field : "Background" Tipo: "L" Formula:  ""</summary>
		public bool ValBack { get { return Convert.ToBoolean(klass.ValBack); } set { klass.ValBack = Convert.ToInt32(value); } }
		public bool ShouldSerializeValBack() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValBack");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Visit.ValZzstate");

		public Visit() : this(UserContext.Current.User) { }

		public Visit(User u)
		{
			this.klass = new CSGenioAvisit(u);
		}

		public Visit(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Visit(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Visit(bool isEmpty) : this(isEmpty, null) { }

		public Visit(CSGenioAvisit val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Visit(CSGenioAvisit val) : this(val, null) { }

		public Visit(CSGenioAvisit val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Visit(CSGenioAvisit val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAvisit csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						if (_equip == null)
							_equip = new Equip(true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Visit Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Visit Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAvisit>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Visit(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Visit> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAvisit>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Visit>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAvisit> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAvisit>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAvisit> All(CriteriaSet args = null)
		{
			return Where<CSGenioAvisit>(false, args, numRegs: -1);
		}

		public static List<Visit> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAvisit>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Visit>((r) => new Visit(r));
		}

// USE /[MANUAL GQT MODEL VISIT]/
	}
}
