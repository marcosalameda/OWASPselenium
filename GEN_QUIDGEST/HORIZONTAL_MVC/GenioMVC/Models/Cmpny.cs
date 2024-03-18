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
	public class Cmpny : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcmpny klass { get { return baseklass as CSGenioAcmpny; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Companies" Tipo: "+" Formula:  ""</summary>
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		public bool ShouldSerializeValCodempre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValCodempre");

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValDesignat");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValAcronym { get { return klass.ValAcronym; } set { klass.ValAcronym = value; } }
		public bool ShouldSerializeValAcronym() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValAcronym");

		[DisplayName("Tax identification")]
		/// <summary>Field : "Tax identification" Tipo: "C" Formula:  ""</summary>
		public string ValNif { get { return klass.ValNif; } set { klass.ValNif = value; } }
		public bool ShouldSerializeValNif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValNif");

		[DisplayName("Phone")]
		/// <summary>Field : "Phone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValTelephon");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValEmail");

		[DisplayName("Logo")]
		/// <summary>Field : "Logo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValLogo { get { return klass.ValLogo; } set { klass.ValLogo = value; } }
		public bool ShouldSerializeValLogo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValLogo");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		public bool ShouldSerializeValCodcntry() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValCodcntry");
		private Cntry _cntry;
		[DisplayName("Cntry")]
		public virtual Cntry Cntry { get { if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry)))) _cntry = Models.Cntry.Find(ValCodcntry, Identifier, _fieldsToSerialize); if (_cntry == null) _cntry = new Models.Cntry(true, _fieldsToSerialize); return _cntry; } set { _cntry = value; } }
		public bool ShouldSerializeCntry () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cntry");

		[DisplayName("Number of people")]
		/// <summary>Field : "Number of people" Tipo: "N" Formula: SR "[PESSO->1]"</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdpesso { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdpesso, 0)); } set { klass.ValQtdpesso = Convert.ToDouble(value); } }
		public bool ShouldSerializeValQtdpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValQtdpesso");

		[DisplayName("Headquarter location")]
		/// <summary>Field : "Headquarter location" Tipo: "GG" Formula:  ""</summary>
		[GeographicAttribute("GG")]
		public string ValHeadloc { get { return klass.ValHeadloc; } set { klass.ValHeadloc = value; } }
		public bool ShouldSerializeValHeadloc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValHeadloc");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Cmpny.ValZzstate");

		public Cmpny() : this(UserContext.Current.User) { }

		public Cmpny(User u)
		{
			this.klass = new CSGenioAcmpny(u);
		}

		public Cmpny(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpny(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Cmpny(bool isEmpty) : this(isEmpty, null) { }

		public Cmpny(CSGenioAcmpny val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpny(CSGenioAcmpny val) : this(val, null) { }

		public Cmpny(CSGenioAcmpny val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Cmpny(CSGenioAcmpny val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcmpny csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cmpny Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Cmpny Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcmpny>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cmpny(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Cmpny> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcmpny>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Cmpny>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcmpny> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcmpny>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcmpny> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcmpny>(false, args, numRegs: -1);
		}

		public static List<Cmpny> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcmpny>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cmpny>((r) => new Cmpny(r));
		}

// USE /[MANUAL GQT MODEL CMPNY]/
	}
}
