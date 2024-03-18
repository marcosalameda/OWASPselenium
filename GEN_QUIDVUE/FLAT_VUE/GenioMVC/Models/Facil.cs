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
	public class Facil : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfacil klass { get { return baseklass as CSGenioAfacil; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValCodfacil")]
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		private Entit _entit;
		[DisplayName("Entit")]
		[ShouldSerialize("Entit")]
		public virtual Entit Entit { 
			get { 
				if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit))))
					_entit = Models.Entit.Find(ValCodentit, m_userContext, Identifier, _fieldsToSerialize);
				if (_entit == null)
					_entit = new Models.Entit(m_userContext, true, _fieldsToSerialize);
				return _entit;
			}
			set { _entit = value; } 
		}
		

		[DisplayName("Incorporation")]
		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValIncorpor")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get { return klass.ValIncorpor; } set { klass.ValIncorpor = value ?? DateTime.MinValue; } }

		[DisplayName("Facility name")]
		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValFaciltyp")]
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get { return klass.ValFaciltyp; } set { klass.ValFaciltyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValfaciltyp { get { return new SelectList(CSGenio.business.ArrayFaciltyp.GetDictionary(), "Key", "Value", ValFaciltyp); } set { ValFaciltyp = value.SelectedValue as string; } }

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValAddress")]
		[DataType(DataType.MultilineText)]
		public string ValAddress { get { return klass.ValAddress; } set { klass.ValAddress = value; } }

		[DisplayName(">>Facility type")]
		/// <summary>Field : ">>Facility type" Tipo: "CE" Formula: DG "[GLOB->CODFACTY]"</summary>
		[ShouldSerialize("Facil.ValCodfacty")]
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }
		private Facty _facty;
		[DisplayName("Facty")]
		[ShouldSerialize("Facty")]
		public virtual Facty Facty { 
			get { 
				if (!this.isEmptyModel && (_facty == null || (!string.IsNullOrEmpty(ValCodfacty) && (_facty.isEmptyModel || _facty.klass.QPrimaryKey != ValCodfacty))))
					_facty = Models.Facty.Find(ValCodfacty, m_userContext, Identifier, _fieldsToSerialize);
				if (_facty == null)
					_facty = new Models.Facty(m_userContext, true, _fieldsToSerialize);
				return _facty;
			}
			set { _facty = value; } 
		}
		

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValImage")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }

		[DisplayName("GPS input")]
		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValGpsinput")]
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get { return klass.ValGpsinput; } set { klass.ValGpsinput = value; } }
		[JsonIgnore]
		public SelectList ArrayValgpsinput { get { return new SelectList(CSGenio.business.ArrayGpsinput.GetDictionary(), "Key", "Value", ValGpsinput); } set { ValGpsinput = value.SelectedValue as string; } }

		[DisplayName("Latitude")]
		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValLatitude")]
		[NumericAttribute(6)]
		public decimal? ValLatitude { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLatitude, 6)); } set { klass.ValLatitude = Convert.ToDouble(value); } }

		[DisplayName("Longitude")]
		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValLongitud")]
		[NumericAttribute(6)]
		public decimal? ValLongitud { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLongitud, 6)); } set { klass.ValLongitud = Convert.ToDouble(value); } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Facil.ValGeocoori")]
		[GeographicAttribute("GG")]
		public string ValGeocoori { get { return klass.ValGeocoori; } set { klass.ValGeocoori = value; } }

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACIL->GPSINPUT]=="L",GetGeoFromLatLng([FACIL->LATITUDE],[FACIL->LONGITUD]),[FACIL->GEOCOORI])"</summary>
		[ShouldSerialize("Facil.ValGeocoord")]
		[GeographicAttribute("GG")]
		public string ValGeocoord { get { return klass.ValGeocoord; } set { klass.ValGeocoord = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Facil.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Facil(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAfacil(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Facil(UserContext userContext, CSGenioAfacil val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAfacil csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						if (_entit == null)
							_entit = new Entit(m_userContext, true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "facty":
						if (_facty == null)
							_facty = new Facty(m_userContext, true, _fieldsToSerialize);
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
		public static Facil Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfacil>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Facil(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Facil> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfacil>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Facil>((r) => new Facil(userCtx, r));
		}

// USE /[MANUAL GQT MODEL FACIL]/
	}
}
