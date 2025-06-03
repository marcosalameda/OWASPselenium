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
	public class Wpess : ModelBase
	{
		[JsonIgnore]
		public CSGenioAwpess klass { get { return baseklass as CSGenioAwpess; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValCodpess")]
		public string ValCodpess { get { return klass.ValCodpess; } set { klass.ValCodpess = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birth date")]
		/// <summary>Field : "Birth date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValSex")]
		[DataArray("Sexo", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSex { get { return klass.ValSex; } set { klass.ValSex = value; } }
		[JsonIgnore]
		public SelectList ArrayValsex { get { return new SelectList(CSGenio.business.ArraySexo.GetDictionary(), "Key", "Value", ValSex); } set { ValSex = value.SelectedValue as string; } }

		[DisplayName("NºFuncionário")]
		/// <summary>Field : "NºFuncionário" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValNfunc")]
		[NumericAttribute(0)]
		public decimal? ValNfunc { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNfunc, 0)); } set { klass.ValNfunc = Convert.ToDecimal(value); } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValAdress")]
		public string ValAdress { get { return klass.ValAdress; } set { klass.ValAdress = value; } }

		[DisplayName("Zip code")]
		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValZipcode")]
		public string ValZipcode { get { return klass.ValZipcode; } set { klass.ValZipcode = value; } }

		[DisplayName("Pais")]
		/// <summary>Field : "Pais" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValCountry")]
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("NºTelefone")]
		/// <summary>Field : "NºTelefone" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValCellphon")]
		[NumericAttribute(0)]
		public decimal? ValCellphon { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValCellphon, 0)); } set { klass.ValCellphon = Convert.ToDecimal(value); } }

		[DisplayName("Naturalness")]
		/// <summary>Field : "Naturalness" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValNaturali")]
		public string ValNaturali { get { return klass.ValNaturali; } set { klass.ValNaturali = value; } }

		[DisplayName("Nacionalidade")]
		/// <summary>Field : "Nacionalidade" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValNacional")]
		public string ValNacional { get { return klass.ValNacional; } set { klass.ValNacional = value; } }

		[DisplayName("Profile picture")]
		/// <summary>Field : "Profile picture" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValPfoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPfoto { get { return new ImageModel(klass.ValPfoto) { Ticket = ValPfotoQTicket }; } set { klass.ValPfoto = value; } }
		[JsonIgnore]
		public string ValPfotoQTicket = null;

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }

		private Wareh _wareh;
		[DisplayName("Wareh")]
		[ShouldSerialize("Wareh")]
		public virtual Wareh Wareh
		{
			get
			{
				if (!isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh))))
					_wareh = Models.Wareh.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				_wareh ??= new Models.Wareh(m_userContext, true, _fieldsToSerialize);
				return _wareh;
			}
			set { _wareh = value; }
		}

		[DisplayName("Image Top")]
		/// <summary>Field : "Image Top" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValFtimgtop")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFtimgtop { get { return new ImageModel(klass.ValFtimgtop) { Ticket = ValFtimgtopQTicket }; } set { klass.ValFtimgtop = value; } }
		[JsonIgnore]
		public string ValFtimgtopQTicket = null;

		[DisplayName("Image thumbnail")]
		/// <summary>Field : "Image thumbnail" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValFtthumb")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFtthumb { get { return new ImageModel(klass.ValFtthumb) { Ticket = ValFtthumbQTicket }; } set { klass.ValFtthumb = value; } }
		[JsonIgnore]
		public string ValFtthumbQTicket = null;

		[DisplayName("Image Background")]
		/// <summary>Field : "Image Background" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValFtbackgr")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFtbackgr { get { return new ImageModel(klass.ValFtbackgr) { Ticket = ValFtbackgrQTicket }; } set { klass.ValFtbackgr = value; } }
		[JsonIgnore]
		public string ValFtbackgrQTicket = null;

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Wpess.ValShowreco")]
		public bool ValShowreco { get { return Convert.ToBoolean(klass.ValShowreco); } set { klass.ValShowreco = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Wpess.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Wpess(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAwpess(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Wpess(UserContext userContext, CSGenioAwpess val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAwpess csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "wareh":
						_wareh ??= new Wareh(m_userContext, true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Wpess Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAwpess>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Wpess(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Wpess> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAwpess>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Wpess>((r) => new Wpess(userCtx, r));
		}

// USE /[MANUAL GQT MODEL WPESS]/
	}
}
