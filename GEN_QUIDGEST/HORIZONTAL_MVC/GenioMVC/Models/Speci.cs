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
	public class Speci : ModelBase
	{
		[JsonIgnore]
		public CSGenioAspeci klass { get { return baseklass as CSGenioAspeci; } set { baseklass = value; } }

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
		public string ValCodespec { get { return klass.ValCodespec; } set { klass.ValCodespec = value; } }
		public bool ShouldSerializeValCodespec() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Speci.ValCodespec");

		[DisplayName("Specialty")]
		/// <summary>Field : "Specialty" Tipo: "C" Formula:  ""</summary>
		public string ValEspecial { get { return klass.ValEspecial; } set { klass.ValEspecial = value; } }
		public bool ShouldSerializeValEspecial() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Speci.ValEspecial");

		[DisplayName("Technical area")]
		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAreatecn { get { return klass.ValAreatecn; } set { klass.ValAreatecn = value; } }
		[JsonIgnore]
		public SelectList ArrayValareatecn { get { return new SelectList(CSGenio.business.ArrayAreatecn.GetDictionary(), "Key", "Value", ValAreatecn); } set { ValAreatecn = value.SelectedValue as string; } }
		public bool ShouldSerializeValAreatecn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Speci.ValAreatecn");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Speci.ValZzstate");

		public Speci() : this(UserContext.Current.User) { }

		public Speci(User u)
		{
			this.klass = new CSGenioAspeci(u);
		}

		public Speci(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Speci(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Speci(bool isEmpty) : this(isEmpty, null) { }

		public Speci(CSGenioAspeci val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Speci(CSGenioAspeci val) : this(val, null) { }

		public Speci(CSGenioAspeci val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Speci(CSGenioAspeci val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAspeci csgenioa)
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
		public static Speci Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Speci Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAspeci>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Speci(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Speci> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAspeci>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Speci>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAspeci> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAspeci>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAspeci> All(CriteriaSet args = null)
		{
			return Where<CSGenioAspeci>(false, args, numRegs: -1);
		}

		public static List<Speci> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAspeci>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Speci>((r) => new Speci(r));
		}

// USE /[MANUAL GQT MODEL SPECI]/
	}
}
