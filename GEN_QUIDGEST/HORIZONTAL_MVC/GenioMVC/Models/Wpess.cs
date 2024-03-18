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
	public class Wpess : ModelBase
	{
		[JsonIgnore]
		public CSGenioAwpess klass { get { return baseklass as CSGenioAwpess; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpess { get { return klass.ValCodpess; } set { klass.ValCodpess = value; } }
		public bool ShouldSerializeValCodpess() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValCodpess");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValName");

		[DisplayName("Birth date")]
		/// <summary>Field : "Birth date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValDate");

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Sexo", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSex { get { return klass.ValSex; } set { klass.ValSex = value; } }
		[JsonIgnore]
		public SelectList ArrayValsex { get { return new SelectList(CSGenio.business.ArraySexo.GetDictionary(), "Key", "Value", ValSex); } set { ValSex = value.SelectedValue as string; } }
		public bool ShouldSerializeValSex() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValSex");

		[DisplayName("NºFuncionário")]
		/// <summary>Field : "NºFuncionário" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNfunc { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNfunc, 0)); } set { klass.ValNfunc = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNfunc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValNfunc");

		[DisplayName("Address")]
		/// <summary>Field : "Address" Tipo: "C" Formula:  ""</summary>
		public string ValAdress { get { return klass.ValAdress; } set { klass.ValAdress = value; } }
		public bool ShouldSerializeValAdress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValAdress");

		[DisplayName("Zip code")]
		/// <summary>Field : "Zip code" Tipo: "C" Formula:  ""</summary>
		public string ValZipcode { get { return klass.ValZipcode; } set { klass.ValZipcode = value; } }
		public bool ShouldSerializeValZipcode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValZipcode");

		[DisplayName("Pais")]
		/// <summary>Field : "Pais" Tipo: "C" Formula:  ""</summary>
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }
		public bool ShouldSerializeValCountry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValCountry");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValEmail");

		[DisplayName("NºTelefone")]
		/// <summary>Field : "NºTelefone" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValCellphon { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValCellphon, 0)); } set { klass.ValCellphon = Convert.ToDouble(value); } }
		public bool ShouldSerializeValCellphon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValCellphon");

		[DisplayName("Naturalness")]
		/// <summary>Field : "Naturalness" Tipo: "C" Formula:  ""</summary>
		public string ValNaturali { get { return klass.ValNaturali; } set { klass.ValNaturali = value; } }
		public bool ShouldSerializeValNaturali() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValNaturali");

		[DisplayName("Nacionalidade")]
		/// <summary>Field : "Nacionalidade" Tipo: "C" Formula:  ""</summary>
		public string ValNacional { get { return klass.ValNacional; } set { klass.ValNacional = value; } }
		public bool ShouldSerializeValNacional() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValNacional");

		[DisplayName("Profile picture")]
		/// <summary>Field : "Profile picture" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPfoto { get { return klass.ValPfoto; } set { klass.ValPfoto = value; } }
		public bool ShouldSerializeValPfoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValPfoto");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		public bool ShouldSerializeValCodwareh() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValCodwareh");
		private Wareh _wareh;
		[DisplayName("Wareh")]
		public virtual Wareh Wareh { get { if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh)))) _wareh = Models.Wareh.Find(ValCodwareh, Identifier, _fieldsToSerialize); if (_wareh == null) _wareh = new Models.Wareh(true, _fieldsToSerialize); return _wareh; } set { _wareh = value; } }
		public bool ShouldSerializeWareh () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wareh");

		[DisplayName("Image Top")]
		/// <summary>Field : "Image Top" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFtimgtop { get { return klass.ValFtimgtop; } set { klass.ValFtimgtop = value; } }
		public bool ShouldSerializeValFtimgtop() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValFtimgtop");

		[DisplayName("Image thumbnail")]
		/// <summary>Field : "Image thumbnail" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFtthumb { get { return klass.ValFtthumb; } set { klass.ValFtthumb = value; } }
		public bool ShouldSerializeValFtthumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValFtthumb");

		[DisplayName("Image Background")]
		/// <summary>Field : "Image Background" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFtbackgr { get { return klass.ValFtbackgr; } set { klass.ValFtbackgr = value; } }
		public bool ShouldSerializeValFtbackgr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValFtbackgr");

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowreco { get { return Convert.ToBoolean(klass.ValShowreco); } set { klass.ValShowreco = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowreco() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValShowreco");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Wpess.ValZzstate");

		public Wpess() : this(UserContext.Current.User) { }

		public Wpess(User u)
		{
			this.klass = new CSGenioAwpess(u);
		}

		public Wpess(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Wpess(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Wpess(bool isEmpty) : this(isEmpty, null) { }

		public Wpess(CSGenioAwpess val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Wpess(CSGenioAwpess val) : this(val, null) { }

		public Wpess(CSGenioAwpess val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Wpess(CSGenioAwpess val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAwpess csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Wpess Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Wpess Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAwpess>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Wpess(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Wpess> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAwpess>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Wpess>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAwpess> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAwpess>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAwpess> All(CriteriaSet args = null)
		{
			return Where<CSGenioAwpess>(false, args, numRegs: -1);
		}

		public static List<Wpess> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAwpess>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Wpess>((r) => new Wpess(r));
		}

// USE /[MANUAL GQT MODEL WPESS]/
	}
}
