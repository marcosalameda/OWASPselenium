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
	public class Prope : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprope klass { get { return baseklass as CSGenioAprope; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValCodprope")]
		public string ValCodprope { get { return klass.ValCodprope; } set { klass.ValCodprope = value; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("Main Photo")]
		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValCodagent")]
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }
		private Agent _agent;
		[DisplayName("Agent")]
		[ShouldSerialize("Agent")]
		public virtual Agent Agent {
			get {
				if (!this.isEmptyModel && (_agent == null || (!string.IsNullOrEmpty(ValCodagent) && (_agent.isEmptyModel || _agent.klass.QPrimaryKey != ValCodagent))))
					_agent = Models.Agent.Find(ValCodagent, m_userContext, Identifier, _fieldsToSerialize);
				if (_agent == null)
					_agent = new Models.Agent(m_userContext, true, _fieldsToSerialize);
				return _agent;
			}
			set { _agent = value; }
		}


		[DisplayName("Size (m2)")]
		/// <summary>Field : "Size (m2)" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValSize")]
		[NumericAttribute(0)]
		public decimal? ValSize { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSize, 0)); } set { klass.ValSize = Convert.ToDecimal(value); } }

		[DisplayName("Number of Bathrooms")]
		/// <summary>Field : "Number of Bathrooms" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValBathrms")]
		[NumericAttribute(0)]
		public decimal? ValBathrms { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBathrms, 0)); } set { klass.ValBathrms = Convert.ToDecimal(value); } }

		[DisplayName("Year Built")]
		/// <summary>Field : "Year Built" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValYear")]
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("City")]
		/// <summary>Field : "City" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValCodcity")]
		public string ValCodcity { get { return klass.ValCodcity; } set { klass.ValCodcity = value; } }
		private City _city;
		[DisplayName("City")]
		[ShouldSerialize("City")]
		public virtual City City {
			get {
				if (!this.isEmptyModel && (_city == null || (!string.IsNullOrEmpty(ValCodcity) && (_city.isEmptyModel || _city.klass.QPrimaryKey != ValCodcity))))
					_city = Models.City.Find(ValCodcity, m_userContext, Identifier, _fieldsToSerialize);
				if (_city == null)
					_city = new Models.City(m_userContext, true, _fieldsToSerialize);
				return _city;
			}
			set { _city = value; }
		}


		[DisplayName("Building type")]
		/// <summary>Field : "Building type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValBuildtyp")]
		[DataArray("Buildtyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBuildtyp { get { return klass.ValBuildtyp; } set { klass.ValBuildtyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValbuildtyp { get { return new SelectList(CSGenio.business.ArrayBuildtyp.GetDictionary(), "Key", "Value", ValBuildtyp); } set { ValBuildtyp = value.SelectedValue as string; } }

		[DisplayName("Typology")]
		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValTypology")]
		[DataArray("Aparttyp", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValTypology { get { return klass.ValTypology; } set { klass.ValTypology = value; } }
		[JsonIgnore]
		public SelectList ArrayValtypology { get { return new SelectList(CSGenio.business.ArrayAparttyp.GetDictionary(), "Key", "Value", ValTypology); } set { ValTypology = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValOrder")]
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDecimal(value); } }

		[DisplayName("Building age")]
		/// <summary>Field : "Building age" Tipo: "N" Formula: + "Year([Today])-Year(DateAddYears([ZEROD],StringToInt([PROPE->YEAR])))"</summary>
		[ShouldSerialize("Prope.ValBuildage")]
		[NumericAttribute(0)]
		public decimal? ValBuildage { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBuildage, 0)); } set { klass.ValBuildage = Convert.ToDecimal(value); } }

		[DisplayName("Ground Size")]
		/// <summary>Field : "Ground Size" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValGrndsize")]
		[NumericAttribute(0)]
		public decimal? ValGrndsize { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValGrndsize, 0)); } set { klass.ValGrndsize = Convert.ToDecimal(value); } }

		[DisplayName("Floor number")]
		/// <summary>Field : "Floor number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Prope.ValFloornum")]
		[NumericAttribute(0)]
		public decimal? ValFloornum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValFloornum, 0)); } set { klass.ValFloornum = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Prope.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Prope(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAprope(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Prope(UserContext userContext, CSGenioAprope val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAprope csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "agent":
						if (_agent == null)
							_agent = new Agent(m_userContext, true, _fieldsToSerialize);
						_agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "city":
						if (_city == null)
							_city = new City(m_userContext, true, _fieldsToSerialize);
						_city.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Prope Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprope>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Prope(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Prope> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprope>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Prope>((r) => new Prope(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PROPE]/
	}
}
