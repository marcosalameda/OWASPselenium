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
	public class Faci2 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfaci2 klass { get { return baseklass as CSGenioAfaci2; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValCodfacil")]
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		[DisplayName("Incorporation")]
		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValIncorpor")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get { return klass.ValIncorpor; } set { klass.ValIncorpor = value ?? DateTime.MinValue; } }

		[DisplayName("Facility name")]
		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValFaciltyp")]
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get { return klass.ValFaciltyp; } set { klass.ValFaciltyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValfaciltyp { get { return new SelectList(CSGenio.business.ArrayFaciltyp.GetDictionary(), "Key", "Value", ValFaciltyp); } set { ValFaciltyp = value.SelectedValue as string; } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValAddress")]
		[DataType(DataType.MultilineText)]
		public string ValAddress { get { return klass.ValAddress; } set { klass.ValAddress = value; } }

		[DisplayName(">>Facility type")]
		/// <summary>Field : ">>Facility type" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValCodfacty")]
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValImage { get { return new ImageModel(klass.ValImage) { Ticket = ValImageQTicket }; } set { klass.ValImage = value; } }
		[JsonIgnore]
		public string ValImageQTicket = null;

		[DisplayName("GPS input")]
		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValGpsinput")]
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get { return klass.ValGpsinput; } set { klass.ValGpsinput = value; } }
		[JsonIgnore]
		public SelectList ArrayValgpsinput { get { return new SelectList(CSGenio.business.ArrayGpsinput.GetDictionary(), "Key", "Value", ValGpsinput); } set { ValGpsinput = value.SelectedValue as string; } }

		[DisplayName("Latitude")]
		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValLatitude")]
		[NumericAttribute(6)]
		public decimal? ValLatitude { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValLatitude, 6)); } set { klass.ValLatitude = Convert.ToDecimal(value); } }

		[DisplayName("Longitude")]
		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValLongitud")]
		[NumericAttribute(6)]
		public decimal? ValLongitud { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValLongitud, 6)); } set { klass.ValLongitud = Convert.ToDecimal(value); } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Faci2.ValGeocoori")]
		[GeographicAttribute("GG")]
		public string ValGeocoori { get { return klass.ValGeocoori; } set { klass.ValGeocoori = value; } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACI2->GPSINPUT]=="L",GetGeoFromLatLng([FACI2->LATITUDE],[FACI2->LONGITUD]),[FACI2->GEOCOORI])"</summary>
		[ShouldSerialize("Faci2.ValGeocoord")]
		[GeographicAttribute("GG")]
		public string ValGeocoord { get { return klass.ValGeocoord; } set { klass.ValGeocoord = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Faci2.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Faci2(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfaci2(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Faci2(UserContext userContext, CSGenioAfaci2 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAfaci2 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Faci2 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfaci2>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Faci2(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Faci2> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfaci2>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Faci2>((r) => new Faci2(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FACI2]/
	}
}
