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
	public class Pwreg : ModelBase
	{
		[JsonIgnore]
		public CSGenioApwreg klass { get { return baseklass as CSGenioApwreg; } set { baseklass = value; } }

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
		public string ValCodpwreg { get { return klass.ValCodpwreg; } set { klass.ValCodpwreg = value; } }
		public bool ShouldSerializeValCodpwreg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwreg.ValCodpwreg");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwreg.ValCodpsw");
		private Psw _psw;
		[DisplayName("Psw")]
		public virtual Psw Psw { get { if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw)))) _psw = Models.Psw.Find(ValCodpsw, Identifier, _fieldsToSerialize); if (_psw == null) _psw = new Models.Psw(true, _fieldsToSerialize); return _psw; } set { _psw = value; } }
		public bool ShouldSerializePsw () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		public bool ShouldSerializeValCodregia() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwreg.ValCodregia");
		private Regio _regio;
		[DisplayName("Regio")]
		public virtual Regio Regio { get { if (!this.isEmptyModel && (_regio == null || (!string.IsNullOrEmpty(ValCodregia) && (_regio.isEmptyModel || _regio.klass.QPrimaryKey != ValCodregia)))) _regio = Models.Regio.Find(ValCodregia, Identifier, _fieldsToSerialize); if (_regio == null) _regio = new Models.Regio(true, _fieldsToSerialize); return _regio; } set { _regio = value; } }
		public bool ShouldSerializeRegio () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Regio");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwreg.ValZzstate");

		public Pwreg() : this(UserContext.Current.User) { }

		public Pwreg(User u)
		{
			this.klass = new CSGenioApwreg(u);
		}

		public Pwreg(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pwreg(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pwreg(bool isEmpty) : this(isEmpty, null) { }

		public Pwreg(CSGenioApwreg val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pwreg(CSGenioApwreg val) : this(val, null) { }

		public Pwreg(CSGenioApwreg val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pwreg(CSGenioApwreg val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioApwreg csgenioa)
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
					case "regio":
						if (_regio == null)
							_regio = new Regio(true, _fieldsToSerialize);
						_regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Pwreg Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Pwreg Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApwreg>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pwreg(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pwreg> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApwreg>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pwreg>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApwreg> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApwreg>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApwreg> All(CriteriaSet args = null)
		{
			return Where<CSGenioApwreg>(false, args, numRegs: -1);
		}

		public static List<Pwreg> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApwreg>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pwreg>((r) => new Pwreg(r));
		}

// USE /[MANUAL GQT MODEL PWREG]/
	}
}
