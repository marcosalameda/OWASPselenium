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
	public class Users : ModelBase
	{
		[JsonIgnore]
		public CSGenioAusers klass { get { return baseklass as CSGenioAusers; } set { baseklass = value; } }

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
		public string ValCodusers { get { return klass.ValCodusers; } set { klass.ValCodusers = value; } }
		public bool ShouldSerializeValCodusers() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Users.ValCodusers");

		[DisplayName(">>LOGIN")]
		/// <summary>Field : ">>LOGIN" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Users.ValCodpsw");
		private Psw _psw;
		[DisplayName("Psw")]
		public virtual Psw Psw { get { if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw)))) _psw = Models.Psw.Find(ValCodpsw, Identifier, _fieldsToSerialize); if (_psw == null) _psw = new Models.Psw(true, _fieldsToSerialize); return _psw; } set { _psw = value; } }
		public bool ShouldSerializePsw () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw");

		[DisplayName(">>PERSON")]
		/// <summary>Field : ">>PERSON" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }
		public bool ShouldSerializeValCodperso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Users.ValCodperso");
		private Perso _perso;
		[DisplayName("Perso")]
		public virtual Perso Perso { get { if (!this.isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodperso) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodperso)))) _perso = Models.Perso.Find(ValCodperso, Identifier, _fieldsToSerialize); if (_perso == null) _perso = new Models.Perso(true, _fieldsToSerialize); return _perso; } set { _perso = value; } }
		public bool ShouldSerializePerso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Users.ValZzstate");

		public Users() : this(UserContext.Current.User) { }

		public Users(User u)
		{
			this.klass = new CSGenioAusers(u);
		}

		public Users(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Users(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Users(bool isEmpty) : this(isEmpty, null) { }

		public Users(CSGenioAusers val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Users(CSGenioAusers val) : this(val, null) { }

		public Users(CSGenioAusers val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Users(CSGenioAusers val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAusers csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "psw":
						if (_psw == null)
							_psw = new Psw(true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "perso":
						if (_perso == null)
							_perso = new Perso(true, _fieldsToSerialize);
						_perso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Users Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Users Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAusers>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Users(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Users> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAusers>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Users>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAusers> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAusers>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAusers> All(CriteriaSet args = null)
		{
			return Where<CSGenioAusers>(false, args, numRegs: -1);
		}

		public static List<Users> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAusers>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Users>((r) => new Users(r));
		}

// USE /[MANUAL GQT MODEL USERS]/
	}
}
