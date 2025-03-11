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
	public class Cmpny : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcmpny klass { get { return baseklass as CSGenioAcmpny; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "Companies" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValAcronym")]
		public string ValAcronym { get { return klass.ValAcronym; } set { klass.ValAcronym = value; } }

		[DisplayName("Tax identification")]
		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValNif")]
		public string ValNif { get { return klass.ValNif; } set { klass.ValNif = value; } }

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValLogo")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValLogo { get { return new ImageModel(klass.ValLogo) { Ticket = ValLogoQTicket }; } set { klass.ValLogo = value; } }
		[JsonIgnore]
		public string ValLogoQTicket = null;

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry
		{
			get
			{
				if (!isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry))))
					_cntry = Models.Cntry.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				_cntry ??= new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}

		[DisplayName("Number of people")]
		/// <summary>Field : "Number of people" Tipo: "N" Formula: SR "[PESSO->1]"</summary>
		[ShouldSerialize("Cmpny.ValQtdpesso")]
		[NumericAttribute(0)]
		public decimal? ValQtdpesso { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdpesso, 0)); } set { klass.ValQtdpesso = Convert.ToDecimal(value); } }

		[DisplayName("Headquarter location")]
		/// <summary>Field : "Headquarter location" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Cmpny.ValHeadloc")]
		[GeographicAttribute("GG")]
		public string ValHeadloc { get { return klass.ValHeadloc; } set { klass.ValHeadloc = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cmpny.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cmpny(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcmpny(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpny(UserContext userContext, CSGenioAcmpny val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcmpny csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						_cntry ??= new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cmpny Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcmpny>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cmpny(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cmpny> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcmpny>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cmpny>((r) => new Cmpny(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CMPNY]/
	}
}
