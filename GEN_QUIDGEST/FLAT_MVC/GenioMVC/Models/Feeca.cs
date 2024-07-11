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
	public class Feeca : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfeeca klass { get { return baseklass as CSGenioAfeeca; } set { baseklass = value; } }

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
		public string ValCodfeeca { get { return klass.ValCodfeeca; } set { klass.ValCodfeeca = value; } }
		public bool ShouldSerializeValCodfeeca() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Feeca.ValCodfeeca");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodflds { get { return klass.ValCodflds; } set { klass.ValCodflds = value; } }
		public bool ShouldSerializeValCodflds() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Feeca.ValCodflds");
		private Flds _flds;
		[DisplayName("Flds")]
		public virtual Flds Flds { get { if (!this.isEmptyModel && (_flds == null || (!string.IsNullOrEmpty(ValCodflds) && (_flds.isEmptyModel || _flds.klass.QPrimaryKey != ValCodflds)))) _flds = Models.Flds.Find(ValCodflds, Identifier, _fieldsToSerialize); if (_flds == null) _flds = new Models.Flds(true, _fieldsToSerialize); return _flds; } set { _flds = value; } }
		public bool ShouldSerializeFlds () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Flds");

		[DisplayName("Feedback")]
		/// <summary>Field : "Feedback" Tipo: "C" Formula:  ""</summary>
		public string ValFeedback { get { return klass.ValFeedback; } set { klass.ValFeedback = value; } }
		public bool ShouldSerializeValFeedback() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Feeca.ValFeedback");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Feeca.ValZzstate");

		public Feeca() : this(UserContext.Current.User) { }

		public Feeca(User u)
		{
			this.klass = new CSGenioAfeeca(u);
		}

		public Feeca(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Feeca(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Feeca(bool isEmpty) : this(isEmpty, null) { }

		public Feeca(CSGenioAfeeca val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Feeca(CSGenioAfeeca val) : this(val, null) { }

		public Feeca(CSGenioAfeeca val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Feeca(CSGenioAfeeca val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAfeeca csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "flds":
						if (_flds == null)
							_flds = new Flds(true, _fieldsToSerialize);
						_flds.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Feeca Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Feeca Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfeeca>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Feeca(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Feeca> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfeeca>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Feeca>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfeeca> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfeeca>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfeeca> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfeeca>(false, args, numRegs: -1);
		}

		public static List<Feeca> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfeeca>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Feeca>((r) => new Feeca(r));
		}

// USE /[MANUAL GQT MODEL FEECA]/
	}
}
