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
	public class Desam : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdesam klass { get { return baseklass as CSGenioAdesam; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public string ValCoddesam { get { return klass.ValCoddesam; } set { klass.ValCoddesam = value; } }
		public bool ShouldSerializeValCoddesam() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValCoddesam");

		[DisplayName("Start date")]
		/// <summary>Field : "Start date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtini { get { return klass.ValDtini; } set { klass.ValDtini = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtini() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValDtini");

		[DisplayName("End date")]
		/// <summary>Field : "End date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtfim { get { return klass.ValDtfim; } set { klass.ValDtfim = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtfim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValDtfim");

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "C" Formula:  ""</summary>
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }
		public bool ShouldSerializeValObservat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValObservat");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValCreatope");

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValCreatdat");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }
		public bool ShouldSerializeValOperchng() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValOperchng");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValChngdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValChngdate");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Desam.ValZzstate");

		public Desam() : this(UserContext.Current.User) { }

		public Desam(User u)
		{
			this.klass = new CSGenioAdesam(u);
		}

		public Desam(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Desam(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Desam(bool isEmpty) : this(isEmpty, null) { }

		public Desam(CSGenioAdesam val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Desam(CSGenioAdesam val) : this(val, null) { }

		public Desam(CSGenioAdesam val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Desam(CSGenioAdesam val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAdesam csgenioa)
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
		public static Desam Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Desam Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdesam>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Desam(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Desam> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdesam>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Desam>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdesam> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdesam>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdesam> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdesam>(false, args, numRegs: -1);
		}

		public static List<Desam> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdesam>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Desam>((r) => new Desam(r));
		}

// USE /[MANUAL GQT MODEL DESAM]/
	}
}
