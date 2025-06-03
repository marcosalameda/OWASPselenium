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
	public class Glob : ModelBase
	{
		[JsonIgnore]
		public CSGenioAglob klass { get { return baseklass as CSGenioAglob; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCodglob")]
		public string ValCodglob { get { return klass.ValCodglob; } set { klass.ValCodglob = value; } }

		[DisplayName("Home text")]
		/// <summary>Field : "Home text" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValHome")]
		[DataType(DataType.MultilineText)]
		public string ValHome { get { return klass.ValHome; } set { klass.ValHome = value; } }

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPzero")]
		[NumericAttribute(2)]
		public decimal? ValPzero { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPzero, 2)); } set { klass.ValPzero = Convert.ToDecimal(value); } }

		[DisplayName("Sender Email")]
		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValRemetent")]
		public string ValRemetent { get { return klass.ValRemetent; } set { klass.ValRemetent = value; } }

		[DisplayName("Data Responsible")]
		/// <summary>Field : "Data Responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSemrspdd")]
		public bool ValSemrspdd { get { return Convert.ToBoolean(klass.ValSemrspdd); } set { klass.ValSemrspdd = Convert.ToInt32(value); } }

		[DisplayName("Indicator Responsible")]
		/// <summary>Field : "Indicator Responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSemrspin")]
		public bool ValSemrspin { get { return Convert.ToBoolean(klass.ValSemrspin); } set { klass.ValSemrspin = Convert.ToInt32(value); } }

		[DisplayName("Responsible")]
		/// <summary>Field : "Responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSemrpbsc")]
		public bool ValSemrpbsc { get { return Convert.ToBoolean(klass.ValSemrpbsc); } set { klass.ValSemrpbsc = Convert.ToInt32(value); } }

		[DisplayName("Iniciative Responsible")]
		/// <summary>Field : "Iniciative Responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSemrpini")]
		public bool ValSemrpini { get { return Convert.ToBoolean(klass.ValSemrpini); } set { klass.ValSemrpini = Convert.ToInt32(value); } }

		[DisplayName("Activity Responsible")]
		/// <summary>Field : "Activity Responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSemrpact")]
		public bool ValSemrpact { get { return Convert.ToBoolean(klass.ValSemrpact); } set { klass.ValSemrpact = Convert.ToInt32(value); } }

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPvalmin")]
		[NumericAttribute(2)]
		public decimal? ValPvalmin { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPvalmin, 2)); } set { klass.ValPvalmin = Convert.ToDecimal(value); } }

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPlimmau")]
		[NumericAttribute(2)]
		public decimal? ValPlimmau { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimmau, 2)); } set { klass.ValPlimmau = Convert.ToDecimal(value); } }

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPalert")]
		[NumericAttribute(2)]
		public decimal? ValPalert { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPalert, 2)); } set { klass.ValPalert = Convert.ToDecimal(value); } }

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPlimbom")]
		[NumericAttribute(2)]
		public decimal? ValPlimbom { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimbom, 2)); } set { klass.ValPlimbom = Convert.ToDecimal(value); } }

		[DisplayName("Overcome")]
		/// <summary>Field : "Overcome" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPlimsup")]
		[NumericAttribute(2)]
		public decimal? ValPlimsup { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimsup, 2)); } set { klass.ValPlimsup = Convert.ToDecimal(value); } }

		[DisplayName("Maximum")]
		/// <summary>Field : "Maximum" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPvalmax")]
		[NumericAttribute(2)]
		public decimal? ValPvalmax { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPvalmax, 2)); } set { klass.ValPvalmax = Convert.ToDecimal(value); } }

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula: + "100+(100-[GLOB->PZERO])"</summary>
		[ShouldSerialize("Glob.ValPzerod")]
		[NumericAttribute(2)]
		public decimal? ValPzerod { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPzerod, 2)); } set { klass.ValPzerod = Convert.ToDecimal(value); } }

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMAX])"</summary>
		[ShouldSerialize("Glob.ValPvalmind")]
		[NumericAttribute(2)]
		public decimal? ValPvalmind { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPvalmind, 2)); } set { klass.ValPvalmind = Convert.ToDecimal(value); } }

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula: + "100+(100-[GLOB->PALERT])"</summary>
		[ShouldSerialize("Glob.ValPalertd")]
		[NumericAttribute(2)]
		public decimal? ValPalertd { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPalertd, 2)); } set { klass.ValPalertd = Convert.ToDecimal(value); } }

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMBOM])"</summary>
		[ShouldSerialize("Glob.ValPlimbomd")]
		[NumericAttribute(2)]
		public decimal? ValPlimbomd { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimbomd, 2)); } set { klass.ValPlimbomd = Convert.ToDecimal(value); } }

		[DisplayName("Overcome")]
		/// <summary>Field : "Overcome" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMSUP])"</summary>
		[ShouldSerialize("Glob.ValPlimsupd")]
		[NumericAttribute(2)]
		public decimal? ValPlimsupd { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimsupd, 2)); } set { klass.ValPlimsupd = Convert.ToDecimal(value); } }

		[DisplayName("Maximum")]
		/// <summary>Field : "Maximum" Tipo: "N" Formula: + "100+(100-[GLOB->PVALMIN])"</summary>
		[ShouldSerialize("Glob.ValPvalmaxd")]
		[NumericAttribute(2)]
		public decimal? ValPvalmaxd { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPvalmaxd, 2)); } set { klass.ValPvalmaxd = Convert.ToDecimal(value); } }

		[DisplayName("Beginning of the year")]
		/// <summary>Field : "Beginning of the year" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValIniciano")]
		[DataArray("Ameses", GenioMVC.Helpers.ArrayType.Character)]
		public string ValIniciano { get { return klass.ValIniciano; } set { klass.ValIniciano = value; } }
		[JsonIgnore]
		public SelectList ArrayValiniciano { get { return new SelectList(CSGenio.business.ArrayAmeses.GetDictionary(), "Key", "Value", ValIniciano); } set { ValIniciano = value.SelectedValue as string; } }

		[DisplayName("0%")]
		/// <summary>Field : "0%" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPzeroc")]
		[NumericAttribute(2)]
		public decimal? ValPzeroc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPzeroc, 2)); } set { klass.ValPzeroc = Convert.ToDecimal(value); } }

		[DisplayName("Minimum")]
		/// <summary>Field : "Minimum" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPminc")]
		[NumericAttribute(2)]
		public decimal? ValPminc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPminc, 2)); } set { klass.ValPminc = Convert.ToDecimal(value); } }

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPmauc")]
		[NumericAttribute(2)]
		public decimal? ValPmauc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPmauc, 2)); } set { klass.ValPmauc = Convert.ToDecimal(value); } }

		[DisplayName("Alert")]
		/// <summary>Field : "Alert" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPalertc")]
		[NumericAttribute(2)]
		public decimal? ValPalertc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPalertc, 2)); } set { klass.ValPalertc = Convert.ToDecimal(value); } }

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PLIMMAU])"</summary>
		[ShouldSerialize("Glob.ValPlimmaud")]
		[NumericAttribute(2)]
		public decimal? ValPlimmaud { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPlimmaud, 2)); } set { klass.ValPlimmaud = Convert.ToDecimal(value); } }

		[DisplayName("Good")]
		/// <summary>Field : "Good" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPbomc")]
		[NumericAttribute(2)]
		public decimal? ValPbomc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPbomc, 2)); } set { klass.ValPbomc = Convert.ToDecimal(value); } }

		[DisplayName("Good sup.")]
		/// <summary>Field : "Good sup." Tipo: "N" Formula: + "100+(100-[GLOB->PBOMC])"</summary>
		[ShouldSerialize("Glob.ValPbomsc")]
		[NumericAttribute(2)]
		public decimal? ValPbomsc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPbomsc, 2)); } set { klass.ValPbomsc = Convert.ToDecimal(value); } }

		[DisplayName("Alert sup.")]
		/// <summary>Field : "Alert sup." Tipo: "N" Formula: + "100+(100-[GLOB->PALERTC])"</summary>
		[ShouldSerialize("Glob.ValPalertsc")]
		[NumericAttribute(2)]
		public decimal? ValPalertsc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPalertsc, 2)); } set { klass.ValPalertsc = Convert.ToDecimal(value); } }

		[DisplayName("Bad")]
		/// <summary>Field : "Bad" Tipo: "N" Formula: + "100+(100-[GLOB->PMAUC])"</summary>
		[ShouldSerialize("Glob.ValPmausc")]
		[NumericAttribute(2)]
		public decimal? ValPmausc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPmausc, 2)); } set { klass.ValPmausc = Convert.ToDecimal(value); } }

		[DisplayName("Maximum Sup.")]
		/// <summary>Field : "Maximum Sup." Tipo: "N" Formula: + "100+(100-[GLOB->PMINC])"</summary>
		[ShouldSerialize("Glob.ValPmaxsc")]
		[NumericAttribute(2)]
		public decimal? ValPmaxsc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPmaxsc, 2)); } set { klass.ValPmaxsc = Convert.ToDecimal(value); } }

		[DisplayName("100%")]
		/// <summary>Field : "100%" Tipo: "N" Formula: + "100+(100-[GLOB->PZEROC])"</summary>
		[ShouldSerialize("Glob.ValPzerosc")]
		[NumericAttribute(2)]
		public decimal? ValPzerosc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPzerosc, 2)); } set { klass.ValPzerosc = Convert.ToDecimal(value); } }

		[DisplayName("Scorecard type")]
		/// <summary>Field : "Scorecard type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValTipscard")]
		[DataArray("Atpscore", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipscard { get { return klass.ValTipscard; } set { klass.ValTipscard = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipscard { get { return new SelectList(CSGenio.business.ArrayAtpscore.GetDictionary(), "Key", "Value", ValTipscard); } set { ValTipscard = value.SelectedValue as string; } }

		[DisplayName("Organism")]
		/// <summary>Field : "Organism" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValOrganism")]
		public string ValOrganism { get { return klass.ValOrganism; } set { klass.ValOrganism = value; } }

		[DisplayName("Organism code")]
		/// <summary>Field : "Organism code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCode")]
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValMorada")]
		public string ValMorada { get { return klass.ValMorada; } set { klass.ValMorada = value; } }

		[DisplayName("zipcode")]
		/// <summary>Field : "zipcode" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCpostal")]
		public string ValCpostal { get { return klass.ValCpostal; } set { klass.ValCpostal = value; } }

		[DisplayName("Local")]
		/// <summary>Field : "Local" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValLpostal")]
		public string ValLpostal { get { return klass.ValLpostal; } set { klass.ValLpostal = value; } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Fax")]
		/// <summary>Field : "Fax" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValFax")]
		public string ValFax { get { return klass.ValFax; } set { klass.ValFax = value; } }

		[DisplayName("e-mail")]
		/// <summary>Field : "e-mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("URL")]
		/// <summary>Field : "URL" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSite")]
		public string ValSite { get { return klass.ValSite; } set { klass.ValSite = value; } }

		[DisplayName("Header")]
		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSimbolo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValSimbolo { get { return new ImageModel(klass.ValSimbolo) { Ticket = ValSimboloQTicket }; } set { klass.ValSimbolo = value; } }
		[JsonIgnore]
		public string ValSimboloQTicket = null;

		[DisplayName("Header")]
		/// <summary>Field : "Header" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSimbolol")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValSimbolol { get { return new ImageModel(klass.ValSimbolol) { Ticket = ValSimbololQTicket }; } set { klass.ValSimbolol = value; } }
		[JsonIgnore]
		public string ValSimbololQTicket = null;

		[DisplayName("Footer")]
		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValFooterp")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFooterp { get { return new ImageModel(klass.ValFooterp) { Ticket = ValFooterpQTicket }; } set { klass.ValFooterp = value; } }
		[JsonIgnore]
		public string ValFooterpQTicket = null;

		[DisplayName("Footer")]
		/// <summary>Field : "Footer" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValFooterl")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFooterl { get { return new ImageModel(klass.ValFooterl) { Ticket = ValFooterlQTicket }; } set { klass.ValFooterl = value; } }
		[JsonIgnore]
		public string ValFooterlQTicket = null;

		[DisplayName("Watermark")]
		/// <summary>Field : "Watermark" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValMarcagua")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValMarcagua { get { return new ImageModel(klass.ValMarcagua) { Ticket = ValMarcaguaQTicket }; } set { klass.ValMarcagua = value; } }
		[JsonIgnore]
		public string ValMarcaguaQTicket = null;

		[DisplayName("Ministry Logo")]
		/// <summary>Field : "Ministry Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValLogomint")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogomint { get { return new ImageModel(klass.ValLogomint) { Ticket = ValLogomintQTicket }; } set { klass.ValLogomint = value; } }
		[JsonIgnore]
		public string ValLogomintQTicket = null;

		[DisplayName("Documents path")]
		/// <summary>Field : "Documents path" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPathdocu")]
		public string ValPathdocu { get { return klass.ValPathdocu; } set { klass.ValPathdocu = value; } }

		[DisplayName("Sender Email")]
		/// <summary>Field : "Sender Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSmtpmail")]
		public string ValSmtpmail { get { return klass.ValSmtpmail; } set { klass.ValSmtpmail = value; } }

		[DisplayName("SMTP Server")]
		/// <summary>Field : "SMTP Server" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValServsmtp")]
		public string ValServsmtp { get { return klass.ValServsmtp; } set { klass.ValServsmtp = value; } }

		[DisplayName("SMTP Port")]
		/// <summary>Field : "SMTP Port" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSmtpport")]
		[NumericAttribute(0)]
		public decimal? ValSmtpport { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSmtpport, 0)); } set { klass.ValSmtpport = Convert.ToDecimal(value); } }

		[DisplayName("SSL?")]
		/// <summary>Field : "SSL?" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSmtpssl")]
		public bool ValSmtpssl { get { return Convert.ToBoolean(klass.ValSmtpssl); } set { klass.ValSmtpssl = Convert.ToInt32(value); } }

		[DisplayName("STMP User Access")]
		/// <summary>Field : "STMP User Access" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSmtpuser")]
		public string ValSmtpuser { get { return klass.ValSmtpuser; } set { klass.ValSmtpuser = value; } }

		[DisplayName("SMTP Access Password")]
		/// <summary>Field : "SMTP Access Password" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSmtppass")]
		public string ValSmtppass { get { return klass.ValSmtppass; } set { klass.ValSmtppass = value; } }

		[DisplayName("Automatic bonuses")]
		/// <summary>Field : "Automatic bonuses" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValTpbonifi")]
		[DataArray("Atpbonif", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTpbonifi { get { return klass.ValTpbonifi; } set { klass.ValTpbonifi = value; } }
		[JsonIgnore]
		public SelectList ArrayValtpbonifi { get { return new SelectList(CSGenio.business.ArrayAtpbonif.GetDictionary(), "Key", "Value", ValTpbonifi); } set { ValTpbonifi = value.SelectedValue as string; } }

		[DisplayName("Show Closed Maps")]
		/// <summary>Field : "Show Closed Maps" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValMostrano")]
		public bool ValMostrano { get { return Convert.ToBoolean(klass.ValMostrano); } set { klass.ValMostrano = Convert.ToInt32(value); } }

		[DisplayName("Calculations exclusively with working days?")]
		/// <summary>Field : "Calculations exclusively with working days?" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValSodiasut")]
		public bool ValSodiasut { get { return Convert.ToBoolean(klass.ValSodiasut); } set { klass.ValSodiasut = Convert.ToInt32(value); } }

		[DisplayName("Executed unique routine")]
		/// <summary>Field : "Executed unique routine" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValExecutou")]
		public bool ValExecutou { get { return Convert.ToBoolean(klass.ValExecutou); } set { klass.ValExecutou = Convert.ToInt32(value); } }

		[DisplayName("Graphix XML")]
		/// <summary>Field : "Graphix XML" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValXmlgraph")]
		[DataType(DataType.MultilineText)]
		public string ValXmlgraph { get { return klass.ValXmlgraph; } set { klass.ValXmlgraph = value; } }

		[DisplayName("Filter by Organic Unit")]
		/// <summary>Field : "Filter by Organic Unit" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValFiltrorg")]
		public bool ValFiltrorg { get { return Convert.ToBoolean(klass.ValFiltrorg); } set { klass.ValFiltrorg = Convert.ToInt32(value); } }

		[DisplayName("Scorecard appearance")]
		/// <summary>Field : "Scorecard appearance" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValScoreout")]
		[DataArray("Ascorout", GenioMVC.Helpers.ArrayType.Character)]
		public string ValScoreout { get { return klass.ValScoreout; } set { klass.ValScoreout = value; } }
		[JsonIgnore]
		public SelectList ArrayValscoreout { get { return new SelectList(CSGenio.business.ArrayAscorout.GetDictionary(), "Key", "Value", ValScoreout); } set { ValScoreout = value.SelectedValue as string; } }

		[DisplayName("Ministry")]
		/// <summary>Field : "Ministry" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValMinister")]
		public string ValMinister { get { return klass.ValMinister; } set { klass.ValMinister = value; } }

		[DisplayName("Last notification date")]
		/// <summary>Field : "Last notification date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValDtultnot")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtultnot { get { return klass.ValDtultnot; } set { klass.ValDtultnot = value ?? DateTime.MinValue; } }

		[DisplayName("Does it integrate with Document")]
		/// <summary>Field : "Does it integrate with Document" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValIntegdoc")]
		public bool ValIntegdoc { get { return Convert.ToBoolean(klass.ValIntegdoc); } set { klass.ValIntegdoc = Convert.ToInt32(value); } }

		[DisplayName("Objetivos")]
		/// <summary>Field : "Objetivos" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPrefobje")]
		public string ValPrefobje { get { return klass.ValPrefobje; } set { klass.ValPrefobje = value; } }

		[DisplayName("Indicator")]
		/// <summary>Field : "Indicator" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValPrefindi")]
		public string ValPrefindi { get { return klass.ValPrefindi; } set { klass.ValPrefindi = value; } }

		[DisplayName("Gantt - Scale")]
		/// <summary>Field : "Gantt - Scale" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValGantunit")]
		[DataArray("Aganttun", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGantunit { get { return klass.ValGantunit; } set { klass.ValGantunit = value; } }
		[JsonIgnore]
		public SelectList ArrayValgantunit { get { return new SelectList(CSGenio.business.ArrayAganttun.GetDictionary(), "Key", "Value", ValGantunit); } set { ValGantunit = value.SelectedValue as string; } }

		[DisplayName("Gantt - Forward")]
		/// <summary>Field : "Gantt - Forward" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValGantstep")]
		[NumericAttribute(0)]
		public decimal? ValGantstep { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValGantstep, 0)); } set { klass.ValGantstep = Convert.ToDecimal(value); } }

		[DisplayName("Migrate status/report on initiatives and tasks")]
		/// <summary>Field : "Migrate status/report on initiatives and tasks" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValMigrarlt")]
		public bool ValMigrarlt { get { return Convert.ToBoolean(klass.ValMigrarlt); } set { klass.ValMigrarlt = Convert.ToInt32(value); } }

		[DisplayName("Filter by responsible")]
		/// <summary>Field : "Filter by responsible" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValFiltrrsp")]
		public bool ValFiltrrsp { get { return Convert.ToBoolean(klass.ValFiltrrsp); } set { klass.ValFiltrrsp = Convert.ToInt32(value); } }

		[DisplayName("Document Path")]
		/// <summary>Field : "Document Path" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValDocbd")]
		[Document("ValDocbd", true, false, false)]
		public string ValDocbd { get { return klass.ValDocbd; } set { klass.ValDocbd = value; } }
		public string ValDocbdfk { get { return klass.ValDocbdfk; } set { klass.ValDocbdfk = value; } }

		[DisplayName("Number of weekly hours")]
		/// <summary>Field : "Number of weekly hours" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValHorassem")]
		[DataArray("Ahorasse", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValHorassem { get { return klass.ValHorassem; } set { klass.ValHorassem = value; } }
		[JsonIgnore]
		public SelectList ArrayValhorassem { get { return new SelectList(CSGenio.business.ArrayAhorasse.GetDictionary(), "Key", "Value", ValHorassem); } set { ValHorassem = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Afetação / Contabilidade Custos")]
		/// <summary>Field : "Afetação / Contabilidade Custos" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValAfetacao")]
		[DataArray("Accustos", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAfetacao { get { return klass.ValAfetacao; } set { klass.ValAfetacao = value; } }
		[JsonIgnore]
		public SelectList ArrayValafetacao { get { return new SelectList(CSGenio.business.ArrayAccustos.GetDictionary(), "Key", "Value", ValAfetacao); } set { ValAfetacao = value.SelectedValue as string; } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValChngdate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValOperchng")]
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }

		[DisplayName("Primary color")]
		/// <summary>Field : "Primary color" Tipo: "C" Formula: + ""#009AA5""</summary>
		[ShouldSerialize("Glob.ValPricolor")]
		public string ValPricolor { get { return klass.ValPricolor; } set { klass.ValPricolor = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValCodfacty")]
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }

		private Facty _facty;
		[DisplayName("Facty")]
		[ShouldSerialize("Facty")]
		public virtual Facty Facty
		{
			get
			{
				if (!isEmptyModel && (_facty == null || (!string.IsNullOrEmpty(ValCodfacty) && (_facty.isEmptyModel || _facty.klass.QPrimaryKey != ValCodfacty))))
					_facty = Models.Facty.Find(ValCodfacty, m_userContext, Identifier, _fieldsToSerialize);
				_facty ??= new Models.Facty(m_userContext, true, _fieldsToSerialize);
				return _facty;
			}
			set { _facty = value; }
		}

		[DisplayName("Legend")]
		/// <summary>Field : "Legend" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValLegend")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLegend { get { return new ImageModel(klass.ValLegend) { Ticket = ValLegendQTicket }; } set { klass.ValLegend = value; } }
		[JsonIgnore]
		public string ValLegendQTicket = null;

		[DisplayName("External API address")]
		/// <summary>Field : "External API address" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Glob.ValApiurl")]
		public string ValApiurl { get { return klass.ValApiurl; } set { klass.ValApiurl = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Glob.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Glob(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAglob(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Glob(UserContext userContext, CSGenioAglob val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAglob csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "facty":
						_facty ??= new Facty(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Glob Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAglob>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Glob(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Glob> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAglob>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Glob>((r) => new Glob(userCtx, r));
		}

		/// <summary>
		/// Obter a ficha do GLOB
		/// </summary>
		/// <param name="createGlob">Criar uma nova ficha caso se não exists nenhuma</param>
		/// <param name="fieldsToSerialize">The list of fields to be serialized</param>
		/// <returns></returns>
		public static Glob GetGlob(UserContext userCtx, bool createGlob = false, string[] fieldsToSerialize = null)
		{
			CSGenioAglob globarea = null;

			try
			{
				globarea = CSGenioAglob.searchGlob(userCtx.PersistentSupport, userCtx.User);
			}
			catch
			{
				Log.Error("Glob not found");
			}

			if (globarea != null)
				return new Glob(userCtx, globarea, false, fieldsToSerialize);

			if (createGlob)
			{
				try
				{
					userCtx.PersistentSupport.openTransaction();

					globarea = new CSGenioAglob(userCtx.User);
					globarea.insert(userCtx.PersistentSupport);

					userCtx.PersistentSupport.closeTransaction();

					return new Glob(userCtx, globarea, false, fieldsToSerialize);
				}
				catch (System.Exception)
				{
					userCtx.PersistentSupport.rollbackTransaction();
					return new Glob(userCtx, false, fieldsToSerialize);
				}
			}

			return new Glob(userCtx, false, fieldsToSerialize);
		}

// USE /[MANUAL GQT MODEL GLOB]/
	}
}
