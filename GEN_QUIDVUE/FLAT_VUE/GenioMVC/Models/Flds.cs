using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

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
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCodflds")]
		public string ValCodflds { get { return klass.ValCodflds; } set { klass.ValCodflds = value; } }

		[DisplayName("Company Name")]
		/// <summary>Field : "Company Name" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCodaero")]
		public string ValCodaero { get { return klass.ValCodaero; } set { klass.ValCodaero = value; } }

		private Aero _aero;
		[DisplayName("Aero")]
		[ShouldSerialize("Aero")]
		public virtual Aero Aero
		{
			get
			{
				if (!isEmptyModel && (_aero == null || (!string.IsNullOrEmpty(ValCodaero) && (_aero.isEmptyModel || _aero.klass.QPrimaryKey != ValCodaero))))
					_aero = Models.Aero.Find(ValCodaero, m_userContext, Identifier, _fieldsToSerialize);
				_aero ??= new Models.Aero(m_userContext, true, _fieldsToSerialize);
				return _aero;
			}
			set { _aero = value; }
		}

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValDescrip")]
		[DataType(DataType.MultilineText)]
		public string ValDescrip { get { return klass.ValDescrip; } set { klass.ValDescrip = value; } }

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValNpassage")]
		[NumericAttribute(0)]
		public decimal? ValNpassage { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNpassage, 0)); } set { klass.ValNpassage = Convert.ToDecimal(value); } }

		[DisplayName("Numeric Decimal")]
		/// <summary>Field : "Numeric Decimal" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValDuration")]
		[NumericAttribute(2)]
		public decimal? ValDuration { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDuration, 2)); } set { klass.ValDuration = Convert.ToDecimal(value); } }

		[DisplayName("Currency")]
		/// <summary>Field : "Currency" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("Currency Decimal")]
		/// <summary>Field : "Currency Decimal" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValPrecobil")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecobil { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecobil, 2)); } set { klass.ValPrecobil = Convert.ToDecimal(value); } }

		[DisplayName("Date (DD/MM/YY)")]
		/// <summary>Field : "Date (DD/MM/YY)" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("DateTime")]
		/// <summary>Field : "DateTime" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValDatetime")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatetime { get { return klass.ValDatetime; } set { klass.ValDatetime = value ?? DateTime.MinValue; } }

		[DisplayName("DateSecond")]
		/// <summary>Field : "DateSecond" Tipo: "DS" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValDateseco")]
		[DataType(DataType.Date)]
		[DateAttribute("DS")]
		public DateTime? ValDateseco { get { return klass.ValDateseco; } set { klass.ValDateseco = value ?? DateTime.MinValue; } }

		[DisplayName("Time")]
		/// <summary>Field : "Time" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValTime")]
		[DateAttribute("T")]
		public string ValTime { get { return klass.ValTime; } set { klass.ValTime = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValYear")]
		[NumericAttribute(0)]
		public decimal? ValYear { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYear, 0)); } set { klass.ValYear = Convert.ToDecimal(value); } }

		[DisplayName("Logical")]
		/// <summary>Field : "Logical" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValPrimviag")]
		public bool ValPrimviag { get { return Convert.ToBoolean(klass.ValPrimviag); } set { klass.ValPrimviag = Convert.ToInt32(value); } }

		[DisplayName("Conditional")]
		/// <summary>Field : "Conditional" Tipo: "IF" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValConditio")]
		public decimal ValConditio { get { return klass.ValConditio; } set { klass.ValConditio = value; } }

		[DisplayName("Text Enumeration")]
		/// <summary>Field : "Text Enumeration" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValClass")]
		[DataArray("Class", GenioMVC.Helpers.ArrayType.Character)]
		public string ValClass { get { return klass.ValClass; } set { klass.ValClass = value; } }
		[JsonIgnore]
		public SelectList ArrayValclass { get { return new SelectList(CSGenio.business.ArrayClass.GetDictionary(), "Key", "Value", ValClass); } set { ValClass = value.SelectedValue as string; } }

		[DisplayName("Numeric Enumeration")]
		/// <summary>Field : "Numeric Enumeration" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValClassnum")]
		[DataArray("Classnum", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValClassnum { get { return klass.ValClassnum; } set { klass.ValClassnum = value; } }
		[JsonIgnore]
		public SelectList ArrayValclassnum { get { return new SelectList(CSGenio.business.ArrayClassnum.GetDictionary(), "Key", "Value", ValClassnum); } set { ValClassnum = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Logical Enumeration")]
		/// <summary>Field : "Logical Enumeration" Tipo: "AL" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValLogicenu")]
		[DataArray("Primviag", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValLogicenu { get { return klass.ValLogicenu; } set { klass.ValLogicenu = value; } }
		[JsonIgnore]
		public SelectList ArrayVallogicenu { get { return new SelectList(CSGenio.business.ArrayPrimviag.GetDictionary(), "Key", "Value", ValLogicenu); } set { ValLogicenu = (int)value.SelectedValue; } }

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValLogo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogo { get { return new ImageModel(klass.ValLogo) { Ticket = ValLogoQTicket }; } set { klass.ValLogo = value; } }
		[JsonIgnore]
		public string ValLogoQTicket = null;

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValAttach")]
		[Document("ValAttach", true, false, false)]
		public string ValAttach { get { return klass.ValAttach; } set { klass.ValAttach = value; } }
		public string ValAttachfk { get { return klass.ValAttachfk; } set { klass.ValAttachfk = value; } }

		[DisplayName("Logo (External File Image)")]
		/// <summary>Field : "Logo (External File Image)" Tipo: "IX" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValLogoexte")]
		public string ValLogoexte { get { return klass.ValLogoexte; } set { klass.ValLogoexte = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCreatuse")]
		public string ValCreatuse { get { return klass.ValCreatuse; } set { klass.ValCreatuse = value; } }

		[DisplayName("Date of Creation (DD/MM/YY)")]
		/// <summary>Field : "Date of Creation (DD/MM/YY)" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Hour of Creation")]
		/// <summary>Field : "Hour of Creation" Tipo: "OT" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCreathou")]
		[DateAttribute("OT")]
		public string ValCreathou { get { return klass.ValCreathou; } set { klass.ValCreathou = value; } }

		[DisplayName("Complete Date of Creation")]
		/// <summary>Field : "Complete Date of Creation" Tipo: "OI" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCreatins")]
		[DataType(DataType.Date)]
		[DateAttribute("OI")]
		public DateTime? ValCreatins { get { return klass.ValCreatins; } set { klass.ValCreatins = value ?? DateTime.MinValue; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }

		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip
		{
			get
			{
				if (!isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				_equip ??= new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; }
		}

		[DisplayName("Text Field")]
		/// <summary>Field : "Text Field" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValTxtfield")]
		public string ValTxtfield { get { return klass.ValTxtfield; } set { klass.ValTxtfield = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValEmailfld")]
		public string ValEmailfld { get { return klass.ValEmailfld; } set { klass.ValEmailfld = value; } }

		[DisplayName("Zipcode")]
		/// <summary>Field : "Zipcode" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValZipfield")]
		public string ValZipfield { get { return klass.ValZipfield; } set { klass.ValZipfield = value; } }

		[DisplayName("IBAN")]
		/// <summary>Field : "IBAN" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValIbanfiel")]
		public string ValIbanfiel { get { return klass.ValIbanfiel; } set { klass.ValIbanfiel = value; } }

		[DisplayName("Social Security No")]
		/// <summary>Field : "Social Security No" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValSsnumber")]
		public string ValSsnumber { get { return klass.ValSsnumber; } set { klass.ValSsnumber = value; } }

		[DisplayName("Licence plate")]
		/// <summary>Field : "Licence plate" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValLicplate")]
		public string ValLicplate { get { return klass.ValLicplate; } set { klass.ValLicplate = value; } }

		[DisplayName("VAT Number")]
		/// <summary>Field : "VAT Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValVatnumbr")]
		public string ValVatnumbr { get { return klass.ValVatnumbr; } set { klass.ValVatnumbr = value; } }

		[DisplayName("Banking Account Number")]
		/// <summary>Field : "Banking Account Number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValBanknmbr")]
		public string ValBanknmbr { get { return klass.ValBanknmbr; } set { klass.ValBanknmbr = value; } }

		[DisplayName("Uppercase")]
		/// <summary>Field : "Uppercase" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValUpprtext")]
		public string ValUpprtext { get { return klass.ValUpprtext; } set { klass.ValUpprtext = value; } }

		[DisplayName("Password")]
		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValPassfld")]
		public string ValPassfld { get { return klass.ValPassfld; } set { klass.ValPassfld = value; } }

		[DisplayName("Colorpicker")]
		/// <summary>Field : "Colorpicker" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValClrpicke")]
		public string ValClrpicke { get { return klass.ValClrpicke; } set { klass.ValClrpicke = value; } }

		[DisplayName("Show record")]
		/// <summary>Field : "Show record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValShwrc")]
		public bool ValShwrc { get { return Convert.ToBoolean(klass.ValShwrc); } set { klass.ValShwrc = Convert.ToInt32(value); } }

		[DisplayName("Radio Btn")]
		/// <summary>Field : "Radio Btn" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValRadiob")]
		[DataArray("Radiobtn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValRadiob { get { return klass.ValRadiob; } set { klass.ValRadiob = value; } }
		[JsonIgnore]
		public SelectList ArrayValradiob { get { return new SelectList(CSGenio.business.ArrayRadiobtn.GetDictionary(), "Key", "Value", ValRadiob); } set { ValRadiob = value.SelectedValue as string; } }

		[DisplayName("Numeric")]
		/// <summary>Field : "Numeric" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValNrcntry")]
		[NumericAttribute(0)]
		public decimal? ValNrcntry { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrcntry, 0)); } set { klass.ValNrcntry = Convert.ToDecimal(value); } }

		[DisplayName("Field state")]
		/// <summary>Field : "Field state" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValCond")]
		[DataArray("Acondtst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValCond { get { return klass.ValCond; } set { klass.ValCond = value; } }
		[JsonIgnore]
		public SelectList ArrayValcond { get { return new SelectList(CSGenio.business.ArrayAcondtst.GetDictionary(), "Key", "Value", ValCond); } set { ValCond = value.SelectedValue as string; } }

		[DisplayName("Field with client-side conditions")]
		/// <summary>Field : "Field with client-side conditions" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFclient1")]
		public string ValFclient1 { get { return klass.ValFclient1; } set { klass.ValFclient1 = value; } }

		[DisplayName("Field with server-side conditions")]
		/// <summary>Field : "Field with server-side conditions" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFserver1")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValFserver1 { get { return klass.ValFserver1; } set { klass.ValFserver1 = value ?? DateTime.MinValue; } }

		[DisplayName("Field with client-side conditions")]
		/// <summary>Field : "Field with client-side conditions" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFclient2")]
		public bool ValFclient2 { get { return Convert.ToBoolean(klass.ValFclient2); } set { klass.ValFclient2 = Convert.ToInt32(value); } }

		[DisplayName("Field with server-side conditions")]
		/// <summary>Field : "Field with server-side conditions" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFserver2")]
		[NumericAttribute(2)]
		public decimal? ValFserver2 { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValFserver2, 2)); } set { klass.ValFserver2 = Convert.ToDecimal(value); } }

		[DisplayName("Field with client-side conditions")]
		/// <summary>Field : "Field with client-side conditions" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFclient3")]
		[Document("ValFclient3", false, false, false)]
		public string ValFclient3 { get { return klass.ValFclient3; } set { klass.ValFclient3 = value; } }
		public string ValFclient3fk { get { return klass.ValFclient3fk; } set { klass.ValFclient3fk = value; } }

		[DisplayName("Field with server-side conditions")]
		/// <summary>Field : "Field with server-side conditions" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFserver3")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFserver3 { get { return new ImageModel(klass.ValFserver3) { Ticket = ValFserver3QTicket }; } set { klass.ValFserver3 = value; } }
		[JsonIgnore]
		public string ValFserver3QTicket = null;

		[DisplayName("Enforce table conditions")]
		/// <summary>Field : "Enforce table conditions" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValTblcond")]
		public bool ValTblcond { get { return Convert.ToBoolean(klass.ValTblcond); } set { klass.ValTblcond = Convert.ToInt32(value); } }

		[DisplayName("Enforce form conditions")]
		/// <summary>Field : "Enforce form conditions" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFormcond")]
		public bool ValFormcond { get { return Convert.ToBoolean(klass.ValFormcond); } set { klass.ValFormcond = Convert.ToInt32(value); } }

		[DisplayName("Field with Fill when condition")]
		/// <summary>Field : "Field with Fill when condition" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Flds.ValFfillwhn")]
		public string ValFfillwhn { get { return klass.ValFfillwhn; } set { klass.ValFfillwhn = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Flds.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Flds(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAflds(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Flds(UserContext userContext, CSGenioAflds val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAflds csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "aero":
						_aero ??= new Aero(m_userContext, true, _fieldsToSerialize);
						_aero.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "equip":
						_equip ??= new Equip(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Flds Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAflds>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Flds(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Flds> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAflds>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Flds>((r) => new Flds(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FLDS]/
	}
}
