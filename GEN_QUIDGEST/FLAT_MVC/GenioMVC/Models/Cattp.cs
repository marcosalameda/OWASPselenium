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
	public class Cattp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcattp klass { get { return baseklass as CSGenioAcattp; } set { baseklass = value; } }

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
		public string ValCodtpcat { get { return klass.ValCodtpcat; } set { klass.ValCodtpcat = value; } }
		public bool ShouldSerializeValCodtpcat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cattp.ValCodtpcat");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodsbcat { get { return klass.ValCodsbcat; } set { klass.ValCodsbcat = value; } }
		public bool ShouldSerializeValCodsbcat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cattp.ValCodsbcat");
		private Sbcat _sbcat;
		[DisplayName("Sbcat")]
		public virtual Sbcat Sbcat { get { if (!this.isEmptyModel && (_sbcat == null || (!string.IsNullOrEmpty(ValCodsbcat) && (_sbcat.isEmptyModel || _sbcat.klass.QPrimaryKey != ValCodsbcat)))) _sbcat = Models.Sbcat.Find(ValCodsbcat, Identifier, _fieldsToSerialize); if (_sbcat == null) _sbcat = new Models.Sbcat(true, _fieldsToSerialize); return _sbcat; } set { _sbcat = value; } }
		public bool ShouldSerializeSbcat () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sbcat");

		[DisplayName("Category type")]
		/// <summary>Field : "Category type" Tipo: "C" Formula:  ""</summary>
		public string ValTpcatego { get { return klass.ValTpcatego; } set { klass.ValTpcatego = value; } }
		public bool ShouldSerializeValTpcatego() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cattp.ValTpcatego");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cattp.ValZzstate");

		public Cattp() : this(UserContext.Current.User) { }

		public Cattp(User u)
		{
			this.klass = new CSGenioAcattp(u);
		}

		public Cattp(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cattp(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Cattp(bool isEmpty) : this(isEmpty, null) { }

		public Cattp(CSGenioAcattp val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cattp(CSGenioAcattp val) : this(val, null) { }

		public Cattp(CSGenioAcattp val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Cattp(CSGenioAcattp val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcattp csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "sbcat":
						if (_sbcat == null)
							_sbcat = new Sbcat(true, _fieldsToSerialize);
						_sbcat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cattp Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Cattp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcattp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cattp(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Cattp> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcattp>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Cattp>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcattp> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcattp>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcattp> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcattp>(false, args, numRegs: -1);
		}

		public static List<Cattp> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcattp>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cattp>((r) => new Cattp(r));
		}

// USE /[MANUAL GQT MODEL CATTP]/
	}
}
