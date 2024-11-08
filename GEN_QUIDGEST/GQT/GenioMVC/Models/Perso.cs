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
	public class Perso : ModelBase
	{
		[JsonIgnore]
		public CSGenioAperso klass { get { return baseklass as CSGenioAperso; } set { baseklass = value; } }

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
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }
		public bool ShouldSerializeValCodperso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValCodperso");

		[DisplayName("Person name")]
		/// <summary>Field : "Person name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValName");

		[DisplayName("Identification number")]
		/// <summary>Field : "Identification number" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }
		public bool ShouldSerializeValIdentifi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValIdentifi");

		[DisplayName("Gender")]
		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }
		public bool ShouldSerializeValGender() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValGender");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }
		public bool ShouldSerializeValPhoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValPhoto");

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValEmail");

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValYear { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYear, 0)); } set { klass.ValYear = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValYear() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValYear");

		[DisplayName("Month")]
		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		[DataArray("Months", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValMonth { get { return klass.ValMonth; } set { klass.ValMonth = value; } }
		[JsonIgnore]
		public SelectList ArrayValmonth { get { return new SelectList(CSGenio.business.ArrayMonths.GetDictionary(), "Key", "Value", ValMonth); } set { ValMonth = Convert.ToDecimal(value.SelectedValue); } }
		public bool ShouldSerializeValMonth() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValMonth");

		[DisplayName("Date of birth")]
		/// <summary>Field : "Date of birth" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDob { get { return klass.ValDob; } set { klass.ValDob = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDob() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValDob");

		[DisplayName("Time of birth")]
		/// <summary>Field : "Time of birth" Tipo: "T" Formula:  ""</summary>
		[DateAttribute("T")]
		public string ValTob { get { return klass.ValTob; } set { klass.ValTob = value; } }
		public bool ShouldSerializeValTob() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValTob");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatusr { get { return klass.ValCreatusr; } set { klass.ValCreatusr = value; } }
		public bool ShouldSerializeValCreatusr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValCreatusr");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValCreatdat");

		[DisplayName("Modified by")]
		/// <summary>Field : "Modified by" Tipo: "EN" Formula:  ""</summary>
		public string ValModifusr { get { return klass.ValModifusr; } set { klass.ValModifusr = value; } }
		public bool ShouldSerializeValModifusr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValModifusr");

		[DisplayName("Modified on")]
		/// <summary>Field : "Modified on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValModifdat { get { return klass.ValModifdat; } set { klass.ValModifdat = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValModifdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValModifdat");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso.ValZzstate");

		public Perso() : this(UserContext.Current.User) { }

		public Perso(User u)
		{
			this.klass = new CSGenioAperso(u);
		}

		public Perso(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Perso(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Perso(bool isEmpty) : this(isEmpty, null) { }

		public Perso(CSGenioAperso val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Perso(CSGenioAperso val) : this(val, null) { }

		public Perso(CSGenioAperso val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Perso(CSGenioAperso val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAperso csgenioa)
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
		public static Perso Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Perso Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAperso>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Perso(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Perso> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAperso>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Perso>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAperso> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAperso>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAperso> All(CriteriaSet args = null)
		{
			return Where<CSGenioAperso>(false, args, numRegs: -1);
		}

		public static List<Perso> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAperso>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Perso>((r) => new Perso(r));
		}

// USE /[MANUAL GQT MODEL PERSO]/
	}
}
