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
	public class Prope : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprope klass { get { return baseklass as CSGenioAprope; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodprope { get { return klass.ValCodprope; } set { klass.ValCodprope = value; } }
		public bool ShouldSerializeValCodprope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValCodprope");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValTitle");

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrice() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValPrice");

		[DisplayName("Main Photo")]
		/// <summary>Field : "Main Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }
		public bool ShouldSerializeValPhoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValPhoto");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }
		public bool ShouldSerializeValCodagent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValCodagent");
		private Agent _agent;
		[DisplayName("Agent")]
		public virtual Agent Agent { get { if (!this.isEmptyModel && (_agent == null || (!string.IsNullOrEmpty(ValCodagent) && (_agent.isEmptyModel || _agent.klass.QPrimaryKey != ValCodagent)))) _agent = Models.Agent.Find(ValCodagent, Identifier, _fieldsToSerialize); if (_agent == null) _agent = new Models.Agent(true, _fieldsToSerialize); return _agent; } set { _agent = value; } }
		public bool ShouldSerializeAgent () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent");

		[DisplayName("Size (m2)")]
		/// <summary>Field : "Size (m2)" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValSize { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValSize, 0)); } set { klass.ValSize = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValSize() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValSize");

		[DisplayName("Number of Bathrooms")]
		/// <summary>Field : "Number of Bathrooms" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValBathrms { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBathrms, 0)); } set { klass.ValBathrms = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBathrms() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValBathrms");

		[DisplayName("Year Built")]
		/// <summary>Field : "Year Built" Tipo: "C" Formula:  ""</summary>
		public string ValYear { get { return klass.ValYear; } set { klass.ValYear = value; } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValYear");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValDescript");

		[DisplayName("City")]
		/// <summary>Field : "City" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcity { get { return klass.ValCodcity; } set { klass.ValCodcity = value; } }
		public bool ShouldSerializeValCodcity() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValCodcity");
		private City _city;
		[DisplayName("City")]
		public virtual City City { get { if (!this.isEmptyModel && (_city == null || (!string.IsNullOrEmpty(ValCodcity) && (_city.isEmptyModel || _city.klass.QPrimaryKey != ValCodcity)))) _city = Models.City.Find(ValCodcity, Identifier, _fieldsToSerialize); if (_city == null) _city = new Models.City(true, _fieldsToSerialize); return _city; } set { _city = value; } }
		public bool ShouldSerializeCity () => this.SerializeAllFields || this.FieldsToSerialize.Contains("City");

		[DisplayName("Building type")]
		/// <summary>Field : "Building type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Buildtyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBuildtyp { get { return klass.ValBuildtyp; } set { klass.ValBuildtyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValbuildtyp { get { return new SelectList(CSGenio.business.ArrayBuildtyp.GetDictionary(), "Key", "Value", ValBuildtyp); } set { ValBuildtyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValBuildtyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValBuildtyp");

		[DisplayName("Typology")]
		/// <summary>Field : "Typology" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Aparttyp", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValTypology { get { return klass.ValTypology; } set { klass.ValTypology = value; } }
		[JsonIgnore]
		public SelectList ArrayValtypology { get { return new SelectList(CSGenio.business.ArrayAparttyp.GetDictionary(), "Key", "Value", ValTypology); } set { ValTypology = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValTypology() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValTypology");

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrder() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValOrder");

		[DisplayName("Building age")]
		/// <summary>Field : "Building age" Tipo: "N" Formula: + "Year([Today])-Year(DateAddYears([ZEROD],StringToInt([PROPE->YEAR])))"</summary>
		[NumericAttribute(0)]
		public decimal? ValBuildage { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValBuildage, 0)); } set { klass.ValBuildage = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValBuildage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValBuildage");

		[DisplayName("Ground Size")]
		/// <summary>Field : "Ground Size" Tipo: "ND" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValGrndsize { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValGrndsize, 0)); } set { klass.ValGrndsize = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValGrndsize() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValGrndsize");

		[DisplayName("Floor number")]
		/// <summary>Field : "Floor number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValFloornum { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValFloornum, 0)); } set { klass.ValFloornum = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValFloornum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValFloornum");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope.ValZzstate");

		public Prope() : this(UserContext.Current.User) { }

		public Prope(User u)
		{
			this.klass = new CSGenioAprope(u);
		}

		public Prope(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Prope(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Prope(bool isEmpty) : this(isEmpty, null) { }

		public Prope(CSGenioAprope val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Prope(CSGenioAprope val) : this(val, null) { }

		public Prope(CSGenioAprope val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Prope(CSGenioAprope val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_agent = new Agent(true, _fieldsToSerialize);
						_agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "city":
						if (_city == null)
							_city = new City(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Prope Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Prope Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprope>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Prope(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Prope> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAprope>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Prope>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAprope> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAprope>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAprope> All(CriteriaSet args = null)
		{
			return Where<CSGenioAprope>(false, args, numRegs: -1);
		}

		public static List<Prope> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprope>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Prope>((r) => new Prope(r));
		}

// USE /[MANUAL GQT MODEL PROPE]/
	}
}
