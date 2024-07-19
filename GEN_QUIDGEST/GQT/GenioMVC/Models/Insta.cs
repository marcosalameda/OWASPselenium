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
	public class Insta : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinsta klass { get { return baseklass as CSGenioAinsta; } set { baseklass = value; } }

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
		public string ValCodinsta { get { return klass.ValCodinsta; } set { klass.ValCodinsta = value; } }
		public bool ShouldSerializeValCodinsta() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValCodinsta");

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValCodtpequ");
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		public virtual Tpequ Tpequ { get { if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ)))) _tpequ = Models.Tpequ.Find(ValCodtpequ, Identifier, _fieldsToSerialize); if (_tpequ == null) _tpequ = new Models.Tpequ(true, _fieldsToSerialize); return _tpequ; } set { _tpequ = value; } }
		public bool ShouldSerializeTpequ () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ");

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName("Scheduling")]
		/// <summary>Field : "Scheduling" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValDesignat");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtiniage { get { return klass.ValDtiniage; } set { klass.ValDtiniage = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtiniage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValDtiniage");

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtfimage { get { return klass.ValDtfimage; } set { klass.ValDtfimage = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtfimage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValDtfimage");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValDescript");

		[DisplayName("All day")]
		/// <summary>Field : "All day" Tipo: "L" Formula:  ""</summary>
		public bool ValAllday { get { return Convert.ToBoolean(klass.ValAllday); } set { klass.ValAllday = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAllday() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValAllday");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValSince() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValSince");

		[DisplayName("Until")]
		/// <summary>Field : "Until" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValUntil { get { return klass.ValUntil; } set { klass.ValUntil = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValUntil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValUntil");

		[DisplayName("Qtd hours")]
		/// <summary>Field : "Qtd hours" Tipo: "N" Formula: + "iif(emptyD([INSTA->SINCE])==1 || emptyD([INSTA->UNTIL])==1,0,Diferenca_entre_Datas([INSTA->SINCE],[INSTA->UNTIL],"H"))"</summary>
		[NumericAttribute(2)]
		public decimal? ValHours { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValHours, 2)); } set { klass.ValHours = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValHours() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValHours");

		[DisplayName("Hourly price")]
		/// <summary>Field : "Hourly price" Tipo: "$D" Formula: CT "TABPR[INSTA->SINCE][TABPR->SINCE][TABPR->PRECOHOR][INSTA->CODTPEQU][TABPR->CODTPEQ1](DESC)"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecohor { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecohor, 2)); } set { klass.ValPrecohor = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecohor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValPrecohor");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula: + "[INSTA->HOURS]*[INSTA->PRECOHOR]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValValue() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValValue");

		[DisplayName("Geographic coordinate")]
		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		[GeographicAttribute("GG")]
		public string ValCoordgeo { get { return klass.ValCoordgeo; } set { klass.ValCoordgeo = value; } }
		public bool ShouldSerializeValCoordgeo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValCoordgeo");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Insta.ValZzstate");

		public Insta() : this(UserContext.Current.User) { }

		public Insta(User u)
		{
			this.klass = new CSGenioAinsta(u);
		}

		public Insta(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Insta(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Insta(bool isEmpty) : this(isEmpty, null) { }

		public Insta(CSGenioAinsta val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Insta(CSGenioAinsta val) : this(val, null) { }

		public Insta(CSGenioAinsta val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Insta(CSGenioAinsta val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAinsta csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Insta Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Insta Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinsta>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Insta(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Insta> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAinsta>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Insta>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAinsta> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAinsta>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAinsta> All(CriteriaSet args = null)
		{
			return Where<CSGenioAinsta>(false, args, numRegs: -1);
		}

		public static List<Insta> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinsta>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Insta>((r) => new Insta(r));
		}

// USE /[MANUAL GQT MODEL INSTA]/
	}
}
