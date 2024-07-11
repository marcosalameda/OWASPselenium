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
	public class Faqs : ModelBase
	{
		[JsonIgnore]
		public CSGenioAfaqs klass { get { return baseklass as CSGenioAfaqs; } set { baseklass = value; } }

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
		public string ValCodfaqs { get { return klass.ValCodfaqs; } set { klass.ValCodfaqs = value; } }
		public bool ShouldSerializeValCodfaqs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faqs.ValCodfaqs");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcfaqs { get { return klass.ValCodcfaqs; } set { klass.ValCodcfaqs = value; } }
		public bool ShouldSerializeValCodcfaqs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faqs.ValCodcfaqs");
		private Cfaqs _cfaqs;
		[DisplayName("Cfaqs")]
		public virtual Cfaqs Cfaqs { get { if (!this.isEmptyModel && (_cfaqs == null || (!string.IsNullOrEmpty(ValCodcfaqs) && (_cfaqs.isEmptyModel || _cfaqs.klass.QPrimaryKey != ValCodcfaqs)))) _cfaqs = Models.Cfaqs.Find(ValCodcfaqs, Identifier, _fieldsToSerialize); if (_cfaqs == null) _cfaqs = new Models.Cfaqs(true, _fieldsToSerialize); return _cfaqs; } set { _cfaqs = value; } }
		public bool ShouldSerializeCfaqs () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cfaqs");

		[DisplayName("Question")]
		/// <summary>Field : "Question" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValQuestion { get { return klass.ValQuestion; } set { klass.ValQuestion = value; } }
		public bool ShouldSerializeValQuestion() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faqs.ValQuestion");

		[DisplayName("Answer")]
		/// <summary>Field : "Answer" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAnswer { get { return klass.ValAnswer; } set { klass.ValAnswer = value; } }
		public bool ShouldSerializeValAnswer() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faqs.ValAnswer");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Faqs.ValZzstate");

		public Faqs() : this(UserContext.Current.User) { }

		public Faqs(User u)
		{
			this.klass = new CSGenioAfaqs(u);
		}

		public Faqs(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Faqs(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Faqs(bool isEmpty) : this(isEmpty, null) { }

		public Faqs(CSGenioAfaqs val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Faqs(CSGenioAfaqs val) : this(val, null) { }

		public Faqs(CSGenioAfaqs val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Faqs(CSGenioAfaqs val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAfaqs csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cfaqs":
						if (_cfaqs == null)
							_cfaqs = new Cfaqs(true, _fieldsToSerialize);
						_cfaqs.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Faqs Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Faqs Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAfaqs>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Faqs(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Faqs> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAfaqs>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Faqs>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAfaqs> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAfaqs>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAfaqs> All(CriteriaSet args = null)
		{
			return Where<CSGenioAfaqs>(false, args, numRegs: -1);
		}

		public static List<Faqs> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAfaqs>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Faqs>((r) => new Faqs(r));
		}

// USE /[MANUAL GQT MODEL FAQS]/
	}
}
