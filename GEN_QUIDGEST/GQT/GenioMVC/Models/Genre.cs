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
	public class Genre : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgenre klass { get { return baseklass as CSGenioAgenre; } set { baseklass = value; } }

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
		public string ValCodgenre { get { return klass.ValCodgenre; } set { klass.ValCodgenre = value; } }
		public bool ShouldSerializeValCodgenre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValCodgenre");

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "C" Formula:  ""</summary>
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		public bool ShouldSerializeValGender() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValGender");

		[DisplayName("Gender contact")]
		/// <summary>Field : "Gender contact" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Genconta", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAgencont { get { return klass.ValAgencont; } set { klass.ValAgencont = value; } }
		[JsonIgnore]
		public SelectList ArrayValagencont { get { return new SelectList(CSGenio.business.ArrayGenconta.GetDictionary(), "Key", "Value", ValAgencont); } set { ValAgencont = value.SelectedValue as string; } }
		public bool ShouldSerializeValAgencont() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValAgencont");

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }
		public bool ShouldSerializeValBackcolo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValBackcolo");

		[DisplayName("Text color")]
		/// <summary>Field : "Text color" Tipo: "C" Formula:  ""</summary>
		public string ValTextcolo { get { return klass.ValTextcolo; } set { klass.ValTextcolo = value; } }
		public bool ShouldSerializeValTextcolo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValTextcolo");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre.ValZzstate");

		public Genre() : this(UserContext.Current.User) { }

		public Genre(User u)
		{
			this.klass = new CSGenioAgenre(u);
		}

		public Genre(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Genre(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Genre(bool isEmpty) : this(isEmpty, null) { }

		public Genre(CSGenioAgenre val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Genre(CSGenioAgenre val) : this(val, null) { }

		public Genre(CSGenioAgenre val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Genre(CSGenioAgenre val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAgenre csgenioa)
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
		public static Genre Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Genre Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgenre>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Genre(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Genre> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAgenre>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Genre>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAgenre> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAgenre>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAgenre> All(CriteriaSet args = null)
		{
			return Where<CSGenioAgenre>(false, args, numRegs: -1);
		}

		public static List<Genre> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgenre>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Genre>((r) => new Genre(r));
		}

// USE /[MANUAL GQT MODEL GENRE]/
	}
}
