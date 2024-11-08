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
	public class Locat : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlocat klass { get { return baseklass as CSGenioAlocat; } set { baseklass = value; } }

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
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }
		public bool ShouldSerializeValCodlocat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat.ValCodlocat");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfacil { get { return klass.ValCodfacil; } set { klass.ValCodfacil = value; } }
		public bool ShouldSerializeValCodfacil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat.ValCodfacil");
		private Facil _facil;
		[DisplayName("Facil")]
		public virtual Facil Facil { get { if (!this.isEmptyModel && (_facil == null || (!string.IsNullOrEmpty(ValCodfacil) && (_facil.isEmptyModel || _facil.klass.QPrimaryKey != ValCodfacil)))) _facil = Models.Facil.Find(ValCodfacil, Identifier, _fieldsToSerialize); if (_facil == null) _facil = new Models.Facil(true, _fieldsToSerialize); return _facil; } set { _facil = value; } }
		public bool ShouldSerializeFacil () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Facil");

		[DisplayName("Global Location Number")]
		/// <summary>Field : "Global Location Number" Tipo: "C" Formula:  ""</summary>
		public string ValGln { get { return klass.ValGln; } set { klass.ValGln = value; } }
		public bool ShouldSerializeValGln() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat.ValGln");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Locat.ValZzstate");

		public Locat() : this(UserContext.Current.User) { }

		public Locat(User u)
		{
			this.klass = new CSGenioAlocat(u);
		}

		public Locat(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Locat(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Locat(bool isEmpty) : this(isEmpty, null) { }

		public Locat(CSGenioAlocat val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Locat(CSGenioAlocat val) : this(val, null) { }

		public Locat(CSGenioAlocat val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Locat(CSGenioAlocat val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAlocat csgenioa)
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
					case "facil":
						if (_facil == null)
							_facil = new Facil(true, _fieldsToSerialize);
						_facil.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Locat Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Locat Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlocat>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Locat(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Locat> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAlocat>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Locat>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAlocat> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAlocat>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAlocat> All(CriteriaSet args = null)
		{
			return Where<CSGenioAlocat>(false, args, numRegs: -1);
		}

		public static List<Locat> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlocat>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Locat>((r) => new Locat(r));
		}

// USE /[MANUAL GQT MODEL LOCAT]/
	}
}
