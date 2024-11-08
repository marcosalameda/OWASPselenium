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
	public class Lcext : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlcext klass { get { return baseklass as CSGenioAlcext; } set { baseklass = value; } }

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
		public string ValCodlcext { get { return klass.ValCodlcext; } set { klass.ValCodlcext = value; } }
		public bool ShouldSerializeValCodlcext() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValCodlcext");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }
		public bool ShouldSerializeValCodlocat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValCodlocat");
		private Locat _locat;
		[DisplayName("Locat")]
		public virtual Locat Locat { get { if (!this.isEmptyModel && (_locat == null || (!string.IsNullOrEmpty(ValCodlocat) && (_locat.isEmptyModel || _locat.klass.QPrimaryKey != ValCodlocat)))) _locat = Models.Locat.Find(ValCodlocat, Identifier, _fieldsToSerialize); if (_locat == null) _locat = new Models.Locat(true, _fieldsToSerialize); return _locat; } set { _locat = value; } }
		public bool ShouldSerializeLocat () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat");

		[DisplayName("GLN Extension Component")]
		/// <summary>Field : "GLN Extension Component" Tipo: "C" Formula:  ""</summary>
		public string ValGlnext { get { return klass.ValGlnext; } set { klass.ValGlnext = value; } }
		public bool ShouldSerializeValGlnext() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValGlnext");

		[DisplayName("Space type")]
		/// <summary>Field : "Space type" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Spacetyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpacetyp { get { return klass.ValSpacetyp; } set { klass.ValSpacetyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValspacetyp { get { return new SelectList(CSGenio.business.ArraySpacetyp.GetDictionary(), "Key", "Value", ValSpacetyp); } set { ValSpacetyp = value.SelectedValue as string; } }
		public bool ShouldSerializeValSpacetyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValSpacetyp");

		[DisplayName("Space")]
		/// <summary>Field : "Space" Tipo: "C" Formula:  ""</summary>
		public string ValSpaceobs { get { return klass.ValSpaceobs; } set { klass.ValSpaceobs = value; } }
		public bool ShouldSerializeValSpaceobs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValSpaceobs");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Lcext.ValZzstate");

		public Lcext() : this(UserContext.Current.User) { }

		public Lcext(User u)
		{
			this.klass = new CSGenioAlcext(u);
		}

		public Lcext(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lcext(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Lcext(bool isEmpty) : this(isEmpty, null) { }

		public Lcext(CSGenioAlcext val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lcext(CSGenioAlcext val) : this(val, null) { }

		public Lcext(CSGenioAlcext val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Lcext(CSGenioAlcext val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlcext csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "locat":
						if (_locat == null)
							_locat = new Locat(true, _fieldsToSerialize);
						_locat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lcext Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Lcext Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlcext>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lcext(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Lcext> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlcext>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Lcext>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlcext> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlcext>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlcext> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlcext>(false, args, numRegs: -1);
		}

		public static List<Lcext> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlcext>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lcext>((r) => new Lcext(r));
		}

// USE /[MANUAL GQT MODEL LCEXT]/
	}
}
