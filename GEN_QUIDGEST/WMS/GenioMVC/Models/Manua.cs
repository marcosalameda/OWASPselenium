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
	public class Manua : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmanua klass { get { return baseklass as CSGenioAmanua; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmanua { get { return klass.ValCodmanua; } set { klass.ValCodmanua = value; } }
		public bool ShouldSerializeValCodmanua() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValCodmanua");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }
		public bool ShouldSerializeValCodkinde() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValCodkinde");
		private Kinde _kinde;
		[DisplayName("Kinde")]
		public virtual Kinde Kinde { get { if (!this.isEmptyModel && (_kinde == null || (!string.IsNullOrEmpty(ValCodkinde) && (_kinde.isEmptyModel || _kinde.klass.QPrimaryKey != ValCodkinde)))) _kinde = Models.Kinde.Find(ValCodkinde, Identifier, _fieldsToSerialize); if (_kinde == null) _kinde = new Models.Kinde(true, _fieldsToSerialize); return _kinde; } set { _kinde = value; } }
		public bool ShouldSerializeKinde () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Kinde");

		[DisplayName("Manual name")]
		/// <summary>Field : "Manual name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValName");

		[DisplayName("Digital document")]
		/// <summary>Field : "Digital document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDigdocum", false, true, false, false)]
		public string ValDigdocum { get { return klass.ValDigdocum; } set { klass.ValDigdocum = value; } }
		public string ValDigdocumfk { get { return klass.ValDigdocumfk; } set { klass.ValDigdocumfk = value; } }
		public bool ShouldSerializeValDigdocum() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValDigdocum");

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValNotes { get { return klass.ValNotes; } set { klass.ValNotes = value; } }
		public bool ShouldSerializeValNotes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValNotes");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Manua.ValZzstate");

		public Manua() : this(UserContext.Current.User) { }

		public Manua(User u)
		{
			this.klass = new CSGenioAmanua(u);
		}

		public Manua(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manua(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Manua(bool isEmpty) : this(isEmpty, null) { }

		public Manua(CSGenioAmanua val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Manua(CSGenioAmanua val) : this(val, null) { }

		public Manua(CSGenioAmanua val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Manua(CSGenioAmanua val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAmanua csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "kinde":
						if (_kinde == null)
							_kinde = new Kinde(true, _fieldsToSerialize);
						_kinde.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Manua Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Manua Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmanua>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Manua(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Manua> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAmanua>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Manua>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAmanua> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAmanua>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAmanua> All(CriteriaSet args = null)
		{
			return Where<CSGenioAmanua>(false, args, numRegs: -1);
		}

		public static List<Manua> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmanua>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Manua>((r) => new Manua(r));
		}

// USE /[MANUAL GQT MODEL MANUA]/
	}
}
