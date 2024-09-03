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
	public class Glob : ModelBase
	{
		[JsonIgnore]
		public CSGenioAglob klass { get { return baseklass as CSGenioAglob; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodglob { get { return klass.ValCodglob; } set { klass.ValCodglob = value; } }
		public bool ShouldSerializeValCodglob() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCodglob");

		[DisplayName("Home text")]
		/// <summary>Field : "Home text" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValHome { get { return klass.ValHome; } set { klass.ValHome = value; } }
		public bool ShouldSerializeValHome() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValHome");

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPzero { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPzero, 2)); } set { klass.ValPzero = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPzero() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPzero");

		[DisplayName("Sender Email")]
		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public string ValRemetent { get { return klass.ValRemetent; } set { klass.ValRemetent = value; } }
		public bool ShouldSerializeValRemetent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValRemetent");

		[DisplayName("Data Responsible")]
		/// <summary>Field : "Data Responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrspdd { get { return Convert.ToBoolean(klass.ValSemrspdd); } set { klass.ValSemrspdd = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrspdd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSemrspdd");

		[DisplayName("Indicator Responsible")]
		/// <summary>Field : "Indicator Responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrspin { get { return Convert.ToBoolean(klass.ValSemrspin); } set { klass.ValSemrspin = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrspin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSemrspin");

		[DisplayName("Responsible")]
		/// <summary>Field : "Responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrpbsc { get { return Convert.ToBoolean(klass.ValSemrpbsc); } set { klass.ValSemrpbsc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrpbsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSemrpbsc");

		[DisplayName("Iniciative Responsible")]
		/// <summary>Field : "Iniciative Responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrpini { get { return Convert.ToBoolean(klass.ValSemrpini); } set { klass.ValSemrpini = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrpini() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSemrpini");

		[DisplayName("Activity Responsible")]
		/// <summary>Field : "Activity Responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrpact { get { return Convert.ToBoolean(klass.ValSemrpact); } set { klass.ValSemrpact = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrpact() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSemrpact");

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPvalmin { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPvalmin, 2)); } set { klass.ValPvalmin = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPvalmin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPvalmin");

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimmau { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimmau, 2)); } set { klass.ValPlimmau = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimmau() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimmau");

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPalert { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPalert, 2)); } set { klass.ValPalert = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPalert() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPalert");

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimbom { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimbom, 2)); } set { klass.ValPlimbom = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimbom() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimbom");

		[DisplayName("Overcome")]
		/// <summary>Field : "Overcome" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimsup { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimsup, 2)); } set { klass.ValPlimsup = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimsup() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimsup");

		[DisplayName("Maximum")]
		/// <summary>Field : "Maximum" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPvalmax { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPvalmax, 2)); } set { klass.ValPvalmax = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPvalmax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPvalmax");

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula: + "100+(100-[GLOB->PZERO])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPzerod { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPzerod, 2)); } set { klass.ValPzerod = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPzerod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPzerod");

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMAX])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPvalmind { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPvalmind, 2)); } set { klass.ValPvalmind = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPvalmind() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPvalmind");

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula: + "100+(100-[GLOB->PALERT])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPalertd { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPalertd, 2)); } set { klass.ValPalertd = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPalertd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPalertd");

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMBOM])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimbomd { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimbomd, 2)); } set { klass.ValPlimbomd = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimbomd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimbomd");

		[DisplayName("Overcome")]
		/// <summary>Field : "Overcome" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMSUP])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimsupd { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimsupd, 2)); } set { klass.ValPlimsupd = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimsupd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimsupd");

		[DisplayName("Maximum")]
		/// <summary>Field : "Maximum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMIN])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPvalmaxd { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPvalmaxd, 2)); } set { klass.ValPvalmaxd = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPvalmaxd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPvalmaxd");

		[DisplayName("Beginning of the year")]
		/// <summary>Field : "Beginning of the year" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Ameses", GenioMVC.Helpers.ArrayType.Character)]
		public string ValIniciano { get { return klass.ValIniciano; } set { klass.ValIniciano = value; } }
		[JsonIgnore]
		public SelectList ArrayValiniciano { get { return new SelectList(CSGenio.business.ArrayAmeses.GetDictionary(), "Key", "Value", ValIniciano); } set { ValIniciano = value.SelectedValue as string; } }
		public bool ShouldSerializeValIniciano() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValIniciano");

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPzeroc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPzeroc, 2)); } set { klass.ValPzeroc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPzeroc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPzeroc");

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPminc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPminc, 2)); } set { klass.ValPminc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPminc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPminc");

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPmauc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPmauc, 2)); } set { klass.ValPmauc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPmauc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPmauc");

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPalertc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPalertc, 2)); } set { klass.ValPalertc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPalertc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPalertc");

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMMAU])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPlimmaud { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPlimmaud, 2)); } set { klass.ValPlimmaud = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPlimmaud() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPlimmaud");

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValPbomc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPbomc, 2)); } set { klass.ValPbomc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPbomc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPbomc");

		[DisplayName("Good sup.")]
		/// <summary>Field : "Good sup." Tipo: "N" Formula: + "100+(100-[GLOB->PBOMC])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPbomsc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPbomsc, 2)); } set { klass.ValPbomsc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPbomsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPbomsc");

		[DisplayName("Alert sup.")]
		/// <summary>Field : "Alert sup." Tipo: "N" Formula: + "100+(100-[GLOB->PALERTC])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPalertsc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPalertsc, 2)); } set { klass.ValPalertsc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPalertsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPalertsc");

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PMAUC])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPmausc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPmausc, 2)); } set { klass.ValPmausc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPmausc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPmausc");

		[DisplayName("Maximum Sup.")]
		/// <summary>Field : "Maximum Sup." Tipo: "N" Formula: + "100+(100-[GLOB->PMINC])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPmaxsc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPmaxsc, 2)); } set { klass.ValPmaxsc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPmaxsc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPmaxsc");

		[DisplayName("100%")]
		/// <summary>Field : "100%" Tipo: "N" Formula: + "100+(100-[GLOB->PZEROC])"</summary>
		[NumericAttribute(2)]
		public decimal? ValPzerosc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPzerosc, 2)); } set { klass.ValPzerosc = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPzerosc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPzerosc");

		[DisplayName("Scorecard type")]
		/// <summary>Field : "Scorecard type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Atpscore", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipscard { get { return klass.ValTipscard; } set { klass.ValTipscard = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipscard { get { return new SelectList(CSGenio.business.ArrayAtpscore.GetDictionary(), "Key", "Value", ValTipscard); } set { ValTipscard = value.SelectedValue as string; } }
		public bool ShouldSerializeValTipscard() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValTipscard");

		[DisplayName("Organism")]
		/// <summary>Field : "Organism" Tipo: "C" Formula:  ""</summary>
		public string ValOrganism { get { return klass.ValOrganism; } set { klass.ValOrganism = value; } }
		public bool ShouldSerializeValOrganism() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValOrganism");

		[DisplayName("Organism code")]
		/// <summary>Field : "Organism code" Tipo: "C" Formula:  ""</summary>
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }
		public bool ShouldSerializeValCode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCode");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public string ValMorada { get { return klass.ValMorada; } set { klass.ValMorada = value; } }
		public bool ShouldSerializeValMorada() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValMorada");

		[DisplayName("zipcode")]
		/// <summary>Field : "zipcode" Tipo: "C" Formula:  ""</summary>
		public string ValCpostal { get { return klass.ValCpostal; } set { klass.ValCpostal = value; } }
		public bool ShouldSerializeValCpostal() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCpostal");

		[DisplayName("Local")]
		/// <summary>Field : "Local" Tipo: "C" Formula:  ""</summary>
		public string ValLpostal { get { return klass.ValLpostal; } set { klass.ValLpostal = value; } }
		public bool ShouldSerializeValLpostal() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValLpostal");

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValTelephon");

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }
		public bool ShouldSerializeValFax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValFax");

		[DisplayName("e-mail")]
		/// <summary>Field : "e-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValEmail");

		[DisplayName("URL")]
		/// <summary>Field : "URL" Tipo: "C" Formula:  ""</summary>
		public string ValSite { get { return klass.ValSite; } set { klass.ValSite = value; } }
		public bool ShouldSerializeValSite() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSite");

		[DisplayName("Header")]
		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValSimbolo { get { return klass.ValSimbolo; } set { klass.ValSimbolo = value; } }
		public bool ShouldSerializeValSimbolo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSimbolo");

		[DisplayName("Header")]
		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValSimbolol { get { return klass.ValSimbolol; } set { klass.ValSimbolol = value; } }
		public bool ShouldSerializeValSimbolol() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSimbolol");

		[DisplayName("Footer")]
		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFooterp { get { return klass.ValFooterp; } set { klass.ValFooterp = value; } }
		public bool ShouldSerializeValFooterp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValFooterp");

		[DisplayName("Footer")]
		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFooterl { get { return klass.ValFooterl; } set { klass.ValFooterl = value; } }
		public bool ShouldSerializeValFooterl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValFooterl");

		[DisplayName("Watermark")]
		/// <summary>Field : "Watermark" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValMarcagua { get { return klass.ValMarcagua; } set { klass.ValMarcagua = value; } }
		public bool ShouldSerializeValMarcagua() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValMarcagua");

		[DisplayName("Ministry Logo")]
		/// <summary>Field : "Ministry Logo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLogomint { get { return klass.ValLogomint; } set { klass.ValLogomint = value; } }
		public bool ShouldSerializeValLogomint() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValLogomint");

		[DisplayName("Documents path")]
		/// <summary>Field : "Documents path" Tipo: "C" Formula:  ""</summary>
		public string ValPathdocu { get { return klass.ValPathdocu; } set { klass.ValPathdocu = value; } }
		public bool ShouldSerializeValPathdocu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPathdocu");

		[DisplayName("Sender Email")]
		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		public string ValSmtpmail { get { return klass.ValSmtpmail; } set { klass.ValSmtpmail = value; } }
		public bool ShouldSerializeValSmtpmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSmtpmail");

		[DisplayName("SMTP Server")]
		/// <summary>Field : "SMTP Server" Tipo: "C" Formula:  ""</summary>
		public string ValServsmtp { get { return klass.ValServsmtp; } set { klass.ValServsmtp = value; } }
		public bool ShouldSerializeValServsmtp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValServsmtp");

		[DisplayName("SMTP Port")]
		/// <summary>Field : "SMTP Port" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSmtpport { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSmtpport, 0)); } set { klass.ValSmtpport = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSmtpport() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSmtpport");

		[DisplayName("SSL?")]
		/// <summary>Field : "SSL?" Tipo: "L" Formula:  ""</summary>
		public bool ValSmtpssl { get { return Convert.ToBoolean(klass.ValSmtpssl); } set { klass.ValSmtpssl = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSmtpssl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSmtpssl");

		[DisplayName("STMP User Access")]
		/// <summary>Field : "STMP User Access" Tipo: "C" Formula:  ""</summary>
		public string ValSmtpuser { get { return klass.ValSmtpuser; } set { klass.ValSmtpuser = value; } }
		public bool ShouldSerializeValSmtpuser() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSmtpuser");

		[DisplayName("SMTP Access Password")]
		/// <summary>Field : "SMTP Access Password" Tipo: "C" Formula:  ""</summary>
		public string ValSmtppass { get { return klass.ValSmtppass; } set { klass.ValSmtppass = value; } }
		public bool ShouldSerializeValSmtppass() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSmtppass");

		[DisplayName("Automatic bonuses")]
		/// <summary>Field : "Automatic bonuses" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Atpbonif", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTpbonifi { get { return klass.ValTpbonifi; } set { klass.ValTpbonifi = value; } }
		[JsonIgnore]
		public SelectList ArrayValtpbonifi { get { return new SelectList(CSGenio.business.ArrayAtpbonif.GetDictionary(), "Key", "Value", ValTpbonifi); } set { ValTpbonifi = value.SelectedValue as string; } }
		public bool ShouldSerializeValTpbonifi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValTpbonifi");

		[DisplayName("Show Closed Maps")]
		/// <summary>Field : "Show Closed Maps" Tipo: "L" Formula:  ""</summary>
		public bool ValMostrano { get { return Convert.ToBoolean(klass.ValMostrano); } set { klass.ValMostrano = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMostrano() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValMostrano");

		[DisplayName("Calculations exclusively with working days?")]
		/// <summary>Field : "Calculations exclusively with working days?" Tipo: "L" Formula:  ""</summary>
		public bool ValSodiasut { get { return Convert.ToBoolean(klass.ValSodiasut); } set { klass.ValSodiasut = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSodiasut() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValSodiasut");

		[DisplayName("Executed unique routine")]
		/// <summary>Field : "Executed unique routine" Tipo: "L" Formula:  ""</summary>
		public bool ValExecutou { get { return Convert.ToBoolean(klass.ValExecutou); } set { klass.ValExecutou = Convert.ToInt32(value); } }
		public bool ShouldSerializeValExecutou() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValExecutou");

		[DisplayName("Graphix XML")]
		/// <summary>Field : "Graphix XML" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValXmlgraph { get { return klass.ValXmlgraph; } set { klass.ValXmlgraph = value; } }
		public bool ShouldSerializeValXmlgraph() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValXmlgraph");

		[DisplayName("Filter by Organic Unit")]
		/// <summary>Field : "Filter by Organic Unit" Tipo: "L" Formula:  ""</summary>
		public bool ValFiltrorg { get { return Convert.ToBoolean(klass.ValFiltrorg); } set { klass.ValFiltrorg = Convert.ToInt32(value); } }
		public bool ShouldSerializeValFiltrorg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValFiltrorg");

		[DisplayName("Scorecard appearance")]
		/// <summary>Field : "Scorecard appearance" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Ascorout", GenioMVC.Helpers.ArrayType.Character)]
		public string ValScoreout { get { return klass.ValScoreout; } set { klass.ValScoreout = value; } }
		[JsonIgnore]
		public SelectList ArrayValscoreout { get { return new SelectList(CSGenio.business.ArrayAscorout.GetDictionary(), "Key", "Value", ValScoreout); } set { ValScoreout = value.SelectedValue as string; } }
		public bool ShouldSerializeValScoreout() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValScoreout");

		[DisplayName("Ministry")]
		/// <summary>Field : "Ministry" Tipo: "C" Formula:  ""</summary>
		public string ValMinister { get { return klass.ValMinister; } set { klass.ValMinister = value; } }
		public bool ShouldSerializeValMinister() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValMinister");

		[DisplayName("Last notification date")]
		/// <summary>Field : "Last notification date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultnot { get { return klass.ValDtultnot; } set { klass.ValDtultnot = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtultnot() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValDtultnot");

		[DisplayName("Does it integrate with Document")]
		/// <summary>Field : "Does it integrate with Document" Tipo: "L" Formula:  ""</summary>
		public bool ValIntegdoc { get { return Convert.ToBoolean(klass.ValIntegdoc); } set { klass.ValIntegdoc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValIntegdoc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValIntegdoc");

		[DisplayName("Objetivos")]
		/// <summary>Field : "Objetivos" Tipo: "C" Formula:  ""</summary>
		public string ValPrefobje { get { return klass.ValPrefobje; } set { klass.ValPrefobje = value; } }
		public bool ShouldSerializeValPrefobje() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPrefobje");

		[DisplayName("Indicator")]
		/// <summary>Field : "Indicator" Tipo: "C" Formula:  ""</summary>
		public string ValPrefindi { get { return klass.ValPrefindi; } set { klass.ValPrefindi = value; } }
		public bool ShouldSerializeValPrefindi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPrefindi");

		[DisplayName("Gantt - Scale")]
		/// <summary>Field : "Gantt - Scale" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Aganttun", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGantunit { get { return klass.ValGantunit; } set { klass.ValGantunit = value; } }
		[JsonIgnore]
		public SelectList ArrayValgantunit { get { return new SelectList(CSGenio.business.ArrayAganttun.GetDictionary(), "Key", "Value", ValGantunit); } set { ValGantunit = value.SelectedValue as string; } }
		public bool ShouldSerializeValGantunit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValGantunit");

		[DisplayName("Gantt - Forward")]
		/// <summary>Field : "Gantt - Forward" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValGantstep { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValGantstep, 0)); } set { klass.ValGantstep = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValGantstep() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValGantstep");

		[DisplayName("Migrate status/report on initiatives and tasks")]
		/// <summary>Field : "Migrate status/report on initiatives and tasks" Tipo: "L" Formula:  ""</summary>
		public bool ValMigrarlt { get { return Convert.ToBoolean(klass.ValMigrarlt); } set { klass.ValMigrarlt = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMigrarlt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValMigrarlt");

		[DisplayName("Filter by responsible")]
		/// <summary>Field : "Filter by responsible" Tipo: "L" Formula:  ""</summary>
		public bool ValFiltrrsp { get { return Convert.ToBoolean(klass.ValFiltrrsp); } set { klass.ValFiltrrsp = Convert.ToInt32(value); } }
		public bool ShouldSerializeValFiltrrsp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValFiltrrsp");

		[DisplayName("Document Path")]
		/// <summary>Field : "Document Path" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocbd", true, false, false)]
		public string ValDocbd { get { return klass.ValDocbd; } set { klass.ValDocbd = value; } }
		public string ValDocbdfk { get { return klass.ValDocbdfk; } set { klass.ValDocbdfk = value; } }
		public bool ShouldSerializeValDocbd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValDocbd");

		[DisplayName("Number of weekly hours")]
		/// <summary>Field : "Number of weekly hours" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Ahorasse", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValHorassem { get { return klass.ValHorassem; } set { klass.ValHorassem = value; } }
		[JsonIgnore]
		public SelectList ArrayValhorassem { get { return new SelectList(CSGenio.business.ArrayAhorasse.GetDictionary(), "Key", "Value", ValHorassem); } set { ValHorassem = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValHorassem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValHorassem");

		[DisplayName("Afetação / Contabilidade Custos")]
		/// <summary>Field : "Afetação / Contabilidade Custos" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Accustos", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAfetacao { get { return klass.ValAfetacao; } set { klass.ValAfetacao = value; } }
		[JsonIgnore]
		public SelectList ArrayValafetacao { get { return new SelectList(CSGenio.business.ArrayAccustos.GetDictionary(), "Key", "Value", ValAfetacao); } set { ValAfetacao = value.SelectedValue as string; } }
		public bool ShouldSerializeValAfetacao() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValAfetacao");

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCreatdat");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCreatope");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValChngdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValChngdate");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }
		public bool ShouldSerializeValOperchng() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValOperchng");

		[DisplayName("Primary color")]
		/// <summary>Field : "Primary color" Tipo: "C" Formula: + ""#009AA5""</summary>
		public string ValPricolor { get { return klass.ValPricolor; } set { klass.ValPricolor = value; } }
		public bool ShouldSerializeValPricolor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValPricolor");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }
		public bool ShouldSerializeValCodfacty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValCodfacty");
		private Facty _facty;
		[DisplayName("Facty")]
		public virtual Facty Facty { get { if (!this.isEmptyModel && (_facty == null || (!string.IsNullOrEmpty(ValCodfacty) && (_facty.isEmptyModel || _facty.klass.QPrimaryKey != ValCodfacty)))) _facty = Models.Facty.Find(ValCodfacty, Identifier, _fieldsToSerialize); if (_facty == null) _facty = new Models.Facty(true, _fieldsToSerialize); return _facty; } set { _facty = value; } }
		public bool ShouldSerializeFacty () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty");

		[DisplayName("Legend")]
		/// <summary>Field : "Legend" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLegend { get { return klass.ValLegend; } set { klass.ValLegend = value; } }
		public bool ShouldSerializeValLegend() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValLegend");

		[DisplayName("External API address")]
		/// <summary>Field : "External API address" Tipo: "C" Formula:  ""</summary>
		public string ValApiurl { get { return klass.ValApiurl; } set { klass.ValApiurl = value; } }
		public bool ShouldSerializeValApiurl() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValApiurl");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Glob.ValZzstate");

		public Glob() : this(UserContext.Current.User) { }

		public Glob(User u)
		{
			this.klass = new CSGenioAglob(u);
		}

		public Glob(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Glob(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Glob(bool isEmpty) : this(isEmpty, null) { }

		public Glob(CSGenioAglob val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Glob(CSGenioAglob val) : this(val, null) { }

		public Glob(CSGenioAglob val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Glob(CSGenioAglob val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAglob csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "facty":
						if (_facty == null)
							_facty = new Facty(true, _fieldsToSerialize);
						_facty.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Glob Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Glob Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAglob>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Glob(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Glob> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAglob>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Glob>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAglob> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAglob>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAglob> All(CriteriaSet args = null)
		{
			return Where<CSGenioAglob>(false, args, numRegs: -1);
		}

		public static List<Glob> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAglob>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Glob>((r) => new Glob(r));
		}

		/// <summary>
		/// Obter a ficha do GLOB
		/// </summary>
		/// <param name="createGlob">Criar uma nova ficha caso se não exists nenhuma</param>
		/// <param name="fieldsToSerialize">The list of fields to be serialized</param>
		/// <returns></returns>
		public static Glob GetGlob(bool createGlob = false, string[] fieldsToSerialize = null)
		{
			CSGenioAglob globarea = null;

			try
			{
				globarea = CSGenioAglob.searchGlob(UserContext.Current.PersistentSupport, UserContext.Current.User, true);
			}
			catch
			{
				Log.Error("Glob not found");
			}

			if (globarea != null)
				return new Glob(globarea, fieldsToSerialize);

			if (createGlob)
			{
				try
				{
					UserContext.Current.PersistentSupport.openTransaction();

					globarea = new CSGenioAglob(UserContext.Current.User);
					globarea.insert(UserContext.Current.PersistentSupport);

					UserContext.Current.PersistentSupport.closeTransaction();

					return new Glob(globarea, fieldsToSerialize);
				}
				catch (System.Exception)
				{
					UserContext.Current.PersistentSupport.rollbackTransaction();
					return new Glob(fieldsToSerialize);
				}
			}

			return new Glob(fieldsToSerialize);
		}

// USE /[MANUAL GQT MODEL GLOB]/
	}
}
