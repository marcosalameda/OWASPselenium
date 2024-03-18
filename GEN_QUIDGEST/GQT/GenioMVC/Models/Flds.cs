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
	public class Flds : ModelBase
	{
		[JsonIgnore]
		public CSGenioAflds klass { get { return baseklass as CSGenioAflds; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodflds { get { return klass.ValCodflds; } set { klass.ValCodflds = value; } }
		public bool ShouldSerializeValCodflds() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCodflds");

		[DisplayName("Company Name")]
		/// <summary>Field : "Company Name" Tipo: "CE" Formula:  ""</summary>
		public string ValCodaero { get { return klass.ValCodaero; } set { klass.ValCodaero = value; } }
		public bool ShouldSerializeValCodaero() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCodaero");
		private Aero _aero;
		[DisplayName("Aero")]
		public virtual Aero Aero { get { if (!this.isEmptyModel && (_aero == null || (!string.IsNullOrEmpty(ValCodaero) && (_aero.isEmptyModel || _aero.klass.QPrimaryKey != ValCodaero)))) _aero = Models.Aero.Find(ValCodaero, Identifier, _fieldsToSerialize); if (_aero == null) _aero = new Models.Aero(true, _fieldsToSerialize); return _aero; } set { _aero = value; } }
		public bool ShouldSerializeAero () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Aero");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescrip { get { return klass.ValDescrip; } set { klass.ValDescrip = value; } }
		public bool ShouldSerializeValDescrip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValDescrip");

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNpassage { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNpassage, 0)); } set { klass.ValNpassage = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNpassage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValNpassage");

		[DisplayName("Numeric Decimal")]
		/// <summary>Field : "Numeric Decimal" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValDuration { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDuration, 2)); } set { klass.ValDuration = Convert.ToDouble(value); } }
		public bool ShouldSerializeValDuration() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValDuration");

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "$" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDouble(value); } }
		public bool ShouldSerializeValPrice() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValPrice");

		[DisplayName("Currency Decimal")]
		/// <summary>Field : "Currency Decimal" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecobil { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecobil, 2)); } set { klass.ValPrecobil = Convert.ToDouble(value); } }
		public bool ShouldSerializeValPrecobil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValPrecobil");

		[DisplayName("Date (DD/MM/YY)")]
		/// <summary>Field : "Date (DD/MM/YY)" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValDate");

		[DisplayName("DateTime")]
		/// <summary>Field : "DateTime" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get { return klass.ValDatetime; } set { klass.ValDatetime = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatetime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValDatetime");

		[DisplayName("DateSecond")]
		/// <summary>Field : "DateSecond" Tipo: "DS" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDateseco { get { return klass.ValDateseco; } set { klass.ValDateseco = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDateseco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValDateseco");

		[DisplayName("Time")]
		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValTime { get { return klass.ValTime; } set { klass.ValTime = value; } }
		public bool ShouldSerializeValTime() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValTime");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValYear { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYear, 0)); } set { klass.ValYear = Convert.ToDouble(value); } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValYear");

		[DisplayName("Logical")]
		/// <summary>Field : "Logical" Tipo: "L" Formula:  ""</summary>
		public bool ValPrimviag { get { return Convert.ToBoolean(klass.ValPrimviag); } set { klass.ValPrimviag = Convert.ToInt32(value); } }
		public bool ShouldSerializeValPrimviag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValPrimviag");

		[DisplayName("Conditional")]
		/// <summary>Field : "Conditional" Tipo: "IF" Formula:  ""</summary>
		public double ValConditio { get { return klass.ValConditio; } set { klass.ValConditio = value; } }
		public bool ShouldSerializeValConditio() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValConditio");

		[DisplayName("Text Enumeration")]
		/// <summary>Field : "Text Enumeration" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Class", GenioMVC.Helpers.ArrayType.Character)]
		public string ValClass { get { return klass.ValClass; } set { klass.ValClass = value; } }
		[JsonIgnore]
		public SelectList ArrayValclass { get { return new SelectList(CSGenio.business.ArrayClass.GetDictionary(), "Key", "Value", ValClass); } set { ValClass = value.SelectedValue as string; } }
		public bool ShouldSerializeValClass() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValClass");

		[DisplayName("Numeric Enumeration")]
		/// <summary>Field : "Numeric Enumeration" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Classnum", GenioMVC.Helpers.ArrayType.Numeric)]
		public double ValClassnum { get { return klass.ValClassnum; } set { klass.ValClassnum = value; } }
		[JsonIgnore]
		public SelectList ArrayValclassnum { get { return new SelectList(CSGenio.business.ArrayClassnum.GetDictionary(), "Key", "Value", ValClassnum); } set { ValClassnum = Convert.ToDouble(value.SelectedValue); } }
		public bool ShouldSerializeValClassnum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValClassnum");

		[DisplayName("Logical Enumeration")]
		/// <summary>Field : "Logical Enumeration" Tipo: "AL" Formula:  ""</summary>
		[DataArray("Primviag", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValLogicenu { get { return klass.ValLogicenu; } set { klass.ValLogicenu = value; } }
		[JsonIgnore]
		public SelectList ArrayVallogicenu { get { return new SelectList(CSGenio.business.ArrayPrimviag.GetDictionary(), "Key", "Value", ValLogicenu); } set { ValLogicenu = (int)value.SelectedValue; } }
		public bool ShouldSerializeValLogicenu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValLogicenu");

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLogo { get { return klass.ValLogo; } set { klass.ValLogo = value; } }
		public bool ShouldSerializeValLogo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValLogo");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValAttach", false, true, false, false)]
		public string ValAttach { get { return klass.ValAttach; } set { klass.ValAttach = value; } }
		public string ValAttachfk { get { return klass.ValAttachfk; } set { klass.ValAttachfk = value; } }
		public bool ShouldSerializeValAttach() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValAttach");

		[DisplayName("Logo (External File Image)")]
		/// <summary>Field : "Logo (External File Image)" Tipo: "IX" Formula:  ""</summary>
		public string ValLogoexte { get { return klass.ValLogoexte; } set { klass.ValLogoexte = value; } }
		public bool ShouldSerializeValLogoexte() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValLogoexte");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatuse { get { return klass.ValCreatuse; } set { klass.ValCreatuse = value; } }
		public bool ShouldSerializeValCreatuse() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCreatuse");

		[DisplayName("Date of Creation (DD/MM/YY)")]
		/// <summary>Field : "Date of Creation (DD/MM/YY)" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCreatdat");

		[DisplayName("Hour of Creation")]
		/// <summary>Field : "Hour of Creation" Tipo: "OT" Formula:  ""</summary>
		[DateAttribute("OT")]
		public string ValCreathou { get { return klass.ValCreathou; } set { klass.ValCreathou = value; } }
		public bool ShouldSerializeValCreathou() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCreathou");

		[DisplayName("Complete Date of Creation")]
		/// <summary>Field : "Complete Date of Creation" Tipo: "OI" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OI")]
		public DateTime? ValCreatins { get { return klass.ValCreatins; } set { klass.ValCreatins = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValCreatins() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCreatins");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName("Text Field")]
		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		public string ValTxtfield { get { return klass.ValTxtfield; } set { klass.ValTxtfield = value; } }
		public bool ShouldSerializeValTxtfield() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValTxtfield");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmailfld { get { return klass.ValEmailfld; } set { klass.ValEmailfld = value; } }
		public bool ShouldSerializeValEmailfld() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValEmailfld");

		[DisplayName("Zipcode")]
		/// <summary>Field : "Zipcode" Tipo: "C" Formula:  ""</summary>
		public string ValZipfield { get { return klass.ValZipfield; } set { klass.ValZipfield = value; } }
		public bool ShouldSerializeValZipfield() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValZipfield");

		[DisplayName("IBAN")]
		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		public string ValIbanfiel { get { return klass.ValIbanfiel; } set { klass.ValIbanfiel = value; } }
		public bool ShouldSerializeValIbanfiel() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValIbanfiel");

		[DisplayName("Social Security No")]
		/// <summary>Field : "Social Security No" Tipo: "C" Formula:  ""</summary>
		public string ValSsnumber { get { return klass.ValSsnumber; } set { klass.ValSsnumber = value; } }
		public bool ShouldSerializeValSsnumber() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValSsnumber");

		[DisplayName("Licence plate")]
		/// <summary>Field : "Licence plate" Tipo: "C" Formula:  ""</summary>
		public string ValLicplate { get { return klass.ValLicplate; } set { klass.ValLicplate = value; } }
		public bool ShouldSerializeValLicplate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValLicplate");

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		public string ValVatnumbr { get { return klass.ValVatnumbr; } set { klass.ValVatnumbr = value; } }
		public bool ShouldSerializeValVatnumbr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValVatnumbr");

		[DisplayName("Banking Account Number")]
		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		public string ValBanknmbr { get { return klass.ValBanknmbr; } set { klass.ValBanknmbr = value; } }
		public bool ShouldSerializeValBanknmbr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValBanknmbr");

		[DisplayName("Uppercase")]
		/// <summary>Field : "Uppercase" Tipo: "C" Formula:  ""</summary>
		public string ValUpprtext { get { return klass.ValUpprtext; } set { klass.ValUpprtext = value; } }
		public bool ShouldSerializeValUpprtext() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValUpprtext");

		[DisplayName("Password")]
		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		public string ValPassfld { get { return klass.ValPassfld; } set { klass.ValPassfld = value; } }
		public bool ShouldSerializeValPassfld() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValPassfld");

		[DisplayName("Colorpicker")]
		/// <summary>Field : "Colorpicker" Tipo: "C" Formula:  ""</summary>
		public string ValClrpicke { get { return klass.ValClrpicke; } set { klass.ValClrpicke = value; } }
		public bool ShouldSerializeValClrpicke() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValClrpicke");

		[DisplayName("Show record")]
		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		public bool ValShwrc { get { return Convert.ToBoolean(klass.ValShwrc); } set { klass.ValShwrc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShwrc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValShwrc");

		[DisplayName("Radio Btn")]
		/// <summary>Field : "Radio Btn" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Radiobtn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValRadiob { get { return klass.ValRadiob; } set { klass.ValRadiob = value; } }
		[JsonIgnore]
		public SelectList ArrayValradiob { get { return new SelectList(CSGenio.business.ArrayRadiobtn.GetDictionary(), "Key", "Value", ValRadiob); } set { ValRadiob = value.SelectedValue as string; } }
		public bool ShouldSerializeValRadiob() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValRadiob");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds.ValZzstate");

		public Flds() : this(UserContext.Current.User) { }

		public Flds(User u)
		{
			this.klass = new CSGenioAflds(u);
		}

		public Flds(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Flds(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Flds(bool isEmpty) : this(isEmpty, null) { }

		public Flds(CSGenioAflds val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Flds(CSGenioAflds val) : this(val, null) { }

		public Flds(CSGenioAflds val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Flds(CSGenioAflds val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAflds csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "aero":
						if (_aero == null)
							_aero = new Aero(true, _fieldsToSerialize);
						_aero.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Flds Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Flds Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAflds>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Flds(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Flds> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAflds>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Flds>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAflds> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAflds>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAflds> All(CriteriaSet args = null)
		{
			return Where<CSGenioAflds>(false, args, numRegs: -1);
		}

		public static List<Flds> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAflds>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Flds>((r) => new Flds(r));
		}

// USE /[MANUAL GQT MODEL FLDS]/
	}
}
