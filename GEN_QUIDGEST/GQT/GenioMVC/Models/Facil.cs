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
	public class Facil : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfacil klass { get { return baseklass as CSGenioAfacil; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }
		public bool ShouldSerializeValCodfacil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValCodfacil");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName("Incorporation")]
		/// <summary>Field : "Incorporation" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIncorpor { get { return klass.ValIncorpor; } set { klass.ValIncorpor = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValIncorpor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValIncorpor");

		[DisplayName("Facility name")]
		/// <summary>Field : "Facility name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValName");

		[DisplayName("Facility type")]
		/// <summary>Field : "Facility type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Faciltyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFaciltyp { get { return klass.ValFaciltyp; } set { klass.ValFaciltyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValfaciltyp { get { return new SelectList(CSGenio.business.ArrayFaciltyp.GetDictionary(), "Key", "Value", ValFaciltyp); } set { ValFaciltyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValFaciltyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValFaciltyp");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAddress { get { return klass.ValAddress; } set { klass.ValAddress = value; } }
		public bool ShouldSerializeValAddress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValAddress");

		[DisplayName(">>Facility type")]
		/// <summary>Field : ">>Facility type" Tipo: "CE" Formula: DG "[GLOB->CODFACTY]"</summary>
		public string ValCodfacty { get { return klass.ValCodfacty; } set { klass.ValCodfacty = value; } }
		public bool ShouldSerializeValCodfacty() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValCodfacty");
		private Facty _facty;
		[DisplayName("Facty")]
		public virtual Facty Facty { get { if (!this.isEmptyModel && (_facty == null || (!string.IsNullOrEmpty(ValCodfacty) && (_facty.isEmptyModel || _facty.klass.QPrimaryKey != ValCodfacty)))) _facty = Models.Facty.Find(ValCodfacty, Identifier, _fieldsToSerialize); if (_facty == null) _facty = new Models.Facty(true, _fieldsToSerialize); return _facty; } set { _facty = value; } }
		public bool ShouldSerializeFacty () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facty");

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValImage");

		[DisplayName("GPS input")]
		/// <summary>Field : "GPS input" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Gpsinput", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGpsinput { get { return klass.ValGpsinput; } set { klass.ValGpsinput = value; } }
		[JsonIgnore]
		public SelectList ArrayValgpsinput { get { return new SelectList(CSGenio.business.ArrayGpsinput.GetDictionary(), "Key", "Value", ValGpsinput); } set { ValGpsinput = value.SelectedValue as string; } }
		public bool ShouldSerializeValGpsinput() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValGpsinput");

		[DisplayName("Latitude")]
		/// <summary>Field : "Latitude" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(6)]
		public decimal? ValLatitude { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLatitude, 6)); } set { klass.ValLatitude = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLatitude() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValLatitude");

		[DisplayName("Longitude")]
		/// <summary>Field : "Longitude" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(6)]
		public decimal? ValLongitud { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLongitud, 6)); } set { klass.ValLongitud = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLongitud() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValLongitud");

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula:  ""</summary>
		[GeographicAttribute("GG")]
		public string ValGeocoori { get { return klass.ValGeocoori; } set { klass.ValGeocoori = value; } }
		public bool ShouldSerializeValGeocoori() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValGeocoori");

		[DisplayName("Geographical coordinate")]
		/// <summary>Field : "Geographical coordinate" Tipo: "GG" Formula: + "iif([FACIL->GPSINPUT]=="L",GetGeoFromLatLng([FACIL->LATITUDE],[FACIL->LONGITUD]),[FACIL->GEOCOORI])"</summary>
		[GeographicAttribute("GG")]
		public string ValGeocoord { get { return klass.ValGeocoord; } set { klass.ValGeocoord = value; } }
		public bool ShouldSerializeValGeocoord() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValGeocoord");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil.ValZzstate");

		public Facil() : this(UserContext.Current.User) { }

		public Facil(User u)
		{
			this.klass = new CSGenioAfacil(u);
		}

		public Facil(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Facil(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Facil(bool isEmpty) : this(isEmpty, null) { }

		public Facil(CSGenioAfacil val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Facil(CSGenioAfacil val) : this(val, null) { }

		public Facil(CSGenioAfacil val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Facil(CSGenioAfacil val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_entit = new Entit(true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Facil Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Facil Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfacil>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Facil(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Facil> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfacil>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Facil>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfacil> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfacil>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfacil> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfacil>(false, args, numRegs: -1);
		}

		public static List<Facil> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfacil>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Facil>((r) => new Facil(r));
		}

// USE /[MANUAL GQT MODEL FACIL]/
	}
}
