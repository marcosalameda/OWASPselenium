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
	public class Relin : ModelBase
	{
		[JsonIgnore]
		public CSGenioArelin klass { get { return baseklass as CSGenioArelin; } set { baseklass = value; } }

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
		public string ValCoddilin { get { return klass.ValCoddilin; } set { klass.ValCoddilin = value; } }
		public bool ShouldSerializeValCoddilin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValCoddilin");

		[DisplayName(">>RECEIPT")]
		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }
		public bool ShouldSerializeValCodrecei() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValCodrecei");
		private Recei _recei;
		[DisplayName("Recei")]
		public virtual Recei Recei { get { if (!this.isEmptyModel && (_recei == null || (!string.IsNullOrEmpty(ValCodrecei) && (_recei.isEmptyModel || _recei.klass.QPrimaryKey != ValCodrecei)))) _recei = Models.Recei.Find(ValCodrecei, Identifier, _fieldsToSerialize); if (_recei == null) _recei = new Models.Recei(true, _fieldsToSerialize); return _recei; } set { _recei = value; } }
		public bool ShouldSerializeRecei () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei");

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValLinenumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLinenumb, 0)); } set { klass.ValLinenumb = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValLinenumb() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValLinenumb");

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		public bool ShouldSerializeValCodprodu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValCodprodu");
		private Produ _produ;
		[DisplayName("Produ")]
		public virtual Produ Produ { get { if (!this.isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu)))) _produ = Models.Produ.Find(ValCodprodu, Identifier, _fieldsToSerialize); if (_produ == null) _produ = new Models.Produ(true, _fieldsToSerialize); return _produ; } set { _produ = value; } }
		public bool ShouldSerializeProdu () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Produ");

		[DisplayName("Ordered")]
		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOrdered { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrdered, 0)); } set { klass.ValOrdered = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOrdered() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValOrdered");

		[DisplayName("Received")]
		/// <summary>Field : "Received" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValReceived { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValReceived, 0)); } set { klass.ValReceived = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValReceived() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValReceived");

		[DisplayName("Outstanding")]
		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[RELIN->ORDERED]-[RELIN->RECEIVED]"</summary>
		[NumericAttribute(0)]
		public decimal? ValOutstand { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutstand, 0)); } set { klass.ValOutstand = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValOutstand() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValOutstand");

		[DisplayName(">>SUPPLIER")]
		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[RECEI->DTRECEIP]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValInstant { get { return klass.ValInstant; } set { klass.ValInstant = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValInstant() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValInstant");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Relin.ValZzstate");

		public Relin() : this(UserContext.Current.User) { }

		public Relin(User u)
		{
			this.klass = new CSGenioArelin(u);
		}

		public Relin(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Relin(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Relin(bool isEmpty) : this(isEmpty, null) { }

		public Relin(CSGenioArelin val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Relin(CSGenioArelin val) : this(val, null) { }

		public Relin(CSGenioArelin val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Relin(CSGenioArelin val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArelin csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "recei":
						if (_recei == null)
							_recei = new Recei(true, _fieldsToSerialize);
						_recei.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "produ":
						if (_produ == null)
							_produ = new Produ(true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "entit":
						if (_entit == null)
							_entit = new Entit(true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Relin Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Relin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArelin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Relin(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Relin> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArelin>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Relin>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArelin> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArelin>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArelin> All(CriteriaSet args = null)
		{
			return Where<CSGenioArelin>(false, args, numRegs: -1);
		}

		public static List<Relin> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArelin>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Relin>((r) => new Relin(r));
		}

// USE /[MANUAL GQT MODEL RELIN]/
	}
}
