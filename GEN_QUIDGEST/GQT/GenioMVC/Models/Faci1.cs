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
	public class Faci1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfaci1 klass { get { return baseklass as CSGenioAfaci1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }
		public bool ShouldSerializeValCodfacil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValCodfacil");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValCodentit");

		[DisplayName("Incorporation")]
		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get { return klass.ValIncorpor; } set { klass.ValIncorpor = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValIncorpor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValIncorpor");

		[DisplayName("Facility name")]
		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValName");

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get { return klass.ValFaciltyp; } set { klass.ValFaciltyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValfaciltyp { get { return new SelectList(CSGenio.business.ArrayFaciltyp.GetDictionary(), "Key", "Value", ValFaciltyp); } set { ValFaciltyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValFaciltyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValFaciltyp");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAddress { get { return klass.ValAddress; } set { klass.ValAddress = value; } }
		public bool ShouldSerializeValAddress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValAddress");

		[DisplayName(">>Facility type")]
		/// <summary>Field : ">>Facility type" Tipo: "CF" Formula:  ""</summary>
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }
		public bool ShouldSerializeValCodfacty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValCodfacty");

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValImage");

		[DisplayName("GPS input")]
		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get { return klass.ValGpsinput; } set { klass.ValGpsinput = value; } }
		[JsonIgnore]
		public SelectList ArrayValgpsinput { get { return new SelectList(CSGenio.business.ArrayGpsinput.GetDictionary(), "Key", "Value", ValGpsinput); } set { ValGpsinput = value.SelectedValue as string; } }
		public bool ShouldSerializeValGpsinput() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValGpsinput");

		[DisplayName("Latitude")]
		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(6)]
		public decimal? ValLatitude { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLatitude, 6)); } set { klass.ValLatitude = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLatitude() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValLatitude");

		[DisplayName("Longitude")]
		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(6)]
		public decimal? ValLongitud { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLongitud, 6)); } set { klass.ValLongitud = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLongitud() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValLongitud");

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		[GeographicAttribute("GG")]
		public string ValGeocoori { get { return klass.ValGeocoori; } set { klass.ValGeocoori = value; } }
		public bool ShouldSerializeValGeocoori() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValGeocoori");

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACI1->GPSINPUT]=="L",GetGeoFromLatLng([FACI1->LATITUDE],[FACI1->LONGITUD]),[FACI1->GEOCOORI])"</summary>
		[GeographicAttribute("GG")]
		public string ValGeocoord { get { return klass.ValGeocoord; } set { klass.ValGeocoord = value; } }
		public bool ShouldSerializeValGeocoord() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValGeocoord");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faci1.ValZzstate");

		public Faci1() : this(UserContext.Current.User) { }

		public Faci1(User u)
		{
			this.klass = new CSGenioAfaci1(u);
		}

		public Faci1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Faci1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Faci1(bool isEmpty) : this(isEmpty, null) { }

		public Faci1(CSGenioAfaci1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Faci1(CSGenioAfaci1 val) : this(val, null) { }

		public Faci1(CSGenioAfaci1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Faci1(CSGenioAfaci1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Faci1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Faci1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfaci1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Faci1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Faci1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfaci1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Faci1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfaci1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfaci1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfaci1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfaci1>(false, args, numRegs: -1);
		}

		public static List<Faci1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfaci1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Faci1>((r) => new Faci1(r));
		}

// USE /[MANUAL GQT MODEL FACI1]/
	}
}
