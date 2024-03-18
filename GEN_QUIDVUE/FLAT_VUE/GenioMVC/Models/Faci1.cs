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
	public class Faci1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfaci1 klass { get { return baseklass as CSGenioAfaci1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValCodfacil")]
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		[DisplayName("Incorporation")]
		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValIncorpor")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get { return klass.ValIncorpor; } set { klass.ValIncorpor = value ?? DateTime.MinValue; } }

		[DisplayName("Facility name")]
		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValFaciltyp")]
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get { return klass.ValFaciltyp; } set { klass.ValFaciltyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValfaciltyp { get { return new SelectList(CSGenio.business.ArrayFaciltyp.GetDictionary(), "Key", "Value", ValFaciltyp); } set { ValFaciltyp = value.SelectedValue as string; } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValAddress")]
		[DataType(DataType.MultilineText)]
		public string ValAddress { get { return klass.ValAddress; } set { klass.ValAddress = value; } }

		[DisplayName(">>Facility type")]
		/// <summary>Field : ">>Facility type" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValCodfacty")]
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }

		[DisplayName("GPS input")]
		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValGpsinput")]
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get { return klass.ValGpsinput; } set { klass.ValGpsinput = value; } }
		[JsonIgnore]
		public SelectList ArrayValgpsinput { get { return new SelectList(CSGenio.business.ArrayGpsinput.GetDictionary(), "Key", "Value", ValGpsinput); } set { ValGpsinput = value.SelectedValue as string; } }

		[DisplayName("Latitude")]
		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValLatitude")]
		[NumericAttribute(6)]
		public decimal? ValLatitude { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLatitude, 6)); } set { klass.ValLatitude = Convert.ToDouble(value); } }

		[DisplayName("Longitude")]
		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValLongitud")]
		[NumericAttribute(6)]
		public decimal? ValLongitud { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLongitud, 6)); } set { klass.ValLongitud = Convert.ToDouble(value); } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Faci1.ValGeocoori")]
		[GeographicAttribute("GG")]
		public string ValGeocoori { get { return klass.ValGeocoori; } set { klass.ValGeocoori = value; } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACI1->GPSINPUT]=="L",GetGeoFromLatLng([FACI1->LATITUDE],[FACI1->LONGITUD]),[FACI1->GEOCOORI])"</summary>
		[ShouldSerialize("Faci1.ValGeocoord")]
		[GeographicAttribute("GG")]
		public string ValGeocoord { get { return klass.ValGeocoord; } set { klass.ValGeocoord = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Faci1.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Faci1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfaci1(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Faci1(UserContext userContext, CSGenioAfaci1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAfaci1 csgenioa)
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
		public static Faci1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfaci1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Faci1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Faci1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfaci1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Faci1>((r) => new Faci1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FACI1]/
	}
}
