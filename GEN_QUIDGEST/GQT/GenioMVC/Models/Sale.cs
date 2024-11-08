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
	public class Sale : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsale klass { get { return baseklass as CSGenioAsale; } set { baseklass = value; } }

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
		public string ValCodvenda { get { return klass.ValCodvenda; } set { klass.ValCodvenda = value; } }
		public bool ShouldSerializeValCodvenda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValCodvenda");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodorgan { get { return klass.ValCodorgan; } set { klass.ValCodorgan = value; } }
		public bool ShouldSerializeValCodorgan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValCodorgan");
		private Organ _organ;
		[DisplayName("Organ")]
		public virtual Organ Organ { get { if (!this.isEmptyModel && (_organ == null || (!string.IsNullOrEmpty(ValCodorgan) && (_organ.isEmptyModel || _organ.klass.QPrimaryKey != ValCodorgan)))) _organ = Models.Organ.Find(ValCodorgan, Identifier, _fieldsToSerialize); if (_organ == null) _organ = new Models.Organ(true, _fieldsToSerialize); return _organ; } set { _organ = value; } }
		public bool ShouldSerializeOrgan () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ");

		[DisplayName("leadership numb")]
		/// <summary>Field : "leadership numb" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrlide { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrlide, 0)); } set { klass.ValNrlide = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNrlide() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValNrlide");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValStartdt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValStartdt");

		[DisplayName("Identification of business opportunity")]
		/// <summary>Field : "Identification of business opportunity" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }
		public bool ShouldSerializeValIdentifi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValIdentifi");

		[DisplayName("Potential Buyers")]
		/// <summary>Field : "Potential Buyers" Tipo: "C" Formula:  ""</summary>
		public string ValPotcompr { get { return klass.ValPotcompr; } set { klass.ValPotcompr = value; } }
		public bool ShouldSerializeValPotcompr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValPotcompr");

		[DisplayName("Prospecting carried out")]
		/// <summary>Field : "Prospecting carried out" Tipo: "L" Formula:  ""</summary>
		public bool ValProspecc { get { return Convert.ToBoolean(klass.ValProspecc); } set { klass.ValProspecc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValProspecc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValProspecc");

		[DisplayName("Interested")]
		/// <summary>Field : "Interested" Tipo: "L" Formula:  ""</summary>
		public bool ValInteress { get { return Convert.ToBoolean(klass.ValInteress); } set { klass.ValInteress = Convert.ToInt32(value); } }
		public bool ShouldSerializeValInteress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValInteress");

		[DisplayName("Without financial resources")]
		/// <summary>Field : "Without financial resources" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrfina { get { return Convert.ToBoolean(klass.ValSemrfina); } set { klass.ValSemrfina = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrfina() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValSemrfina");

		[DisplayName("No decision-making power")]
		/// <summary>Field : "No decision-making power" Tipo: "L" Formula:  ""</summary>
		public bool ValSemcapac { get { return Convert.ToBoolean(klass.ValSemcapac); } set { klass.ValSemcapac = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemcapac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValSemcapac");

		[DisplayName("Qualification")]
		/// <summary>Field : "Qualification" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get { return klass.ValDtqualif; } set { klass.ValDtqualif = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtqualif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtqualif");

		[DisplayName("Qualification carried out")]
		/// <summary>Field : "Qualification carried out" Tipo: "L" Formula:  ""</summary>
		public bool ValQualific { get { return Convert.ToBoolean(klass.ValQualific); } set { klass.ValQualific = Convert.ToInt32(value); } }
		public bool ShouldSerializeValQualific() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValQualific");

		[DisplayName("Pre-approach")]
		/// <summary>Field : "Pre-approach" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPreabord { get { return klass.ValPreabord; } set { klass.ValPreabord = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPreabord() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValPreabord");

		[DisplayName("Homework done")]
		/// <summary>Field : "Homework done" Tipo: "L" Formula:  ""</summary>
		public bool ValHomework { get { return Convert.ToBoolean(klass.ValHomework); } set { klass.ValHomework = Convert.ToInt32(value); } }
		public bool ShouldSerializeValHomework() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValHomework");

		[DisplayName("Approach")]
		/// <summary>Field : "Approach" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaborda { get { return klass.ValDtaborda; } set { klass.ValDtaborda = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtaborda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtaborda");

		[DisplayName("Abordagem efectuada")]
		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public bool ValApproach { get { return Convert.ToBoolean(klass.ValApproach); } set { klass.ValApproach = Convert.ToInt32(value); } }
		public bool ShouldSerializeValApproach() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValApproach");

		[DisplayName("Presentation")]
		/// <summary>Field : "Presentation" Tipo: "L" Formula:  ""</summary>
		public bool ValApresent { get { return Convert.ToBoolean(klass.ValApresent); } set { klass.ValApresent = Convert.ToInt32(value); } }
		public bool ShouldSerializeValApresent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValApresent");

		[DisplayName("Presentation made")]
		/// <summary>Field : "Presentation made" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaprese { get { return klass.ValDtaprese; } set { klass.ValDtaprese = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtaprese() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtaprese");

		[DisplayName("Overcome objections")]
		/// <summary>Field : "Overcome objections" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtsupera { get { return klass.ValDtsupera; } set { klass.ValDtsupera = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtsupera() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtsupera");

		[DisplayName("Closing attempts")]
		/// <summary>Field : "Closing attempts" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValTentfech { get { return klass.ValTentfech; } set { klass.ValTentfech = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValTentfech() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValTentfech");

		[DisplayName("Closing of the sale")]
		/// <summary>Field : "Closing of the sale" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtvenda { get { return klass.ValDtvenda; } set { klass.ValDtvenda = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtvenda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtvenda");

		[DisplayName("Follow-up")]
		/// <summary>Field : "Follow-up" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtacompa { get { return klass.ValDtacompa; } set { klass.ValDtacompa = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtacompa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValDtacompa");

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowrcrd { get { return Convert.ToBoolean(klass.ValShowrcrd); } set { klass.ValShowrcrd = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowrcrd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValShowrcrd");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sale.ValZzstate");

		public Sale() : this(UserContext.Current.User) { }

		public Sale(User u)
		{
			this.klass = new CSGenioAsale(u);
		}

		public Sale(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sale(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Sale(bool isEmpty) : this(isEmpty, null) { }

		public Sale(CSGenioAsale val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sale(CSGenioAsale val) : this(val, null) { }

		public Sale(CSGenioAsale val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Sale(CSGenioAsale val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAsale csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "organ":
						if (_organ == null)
							_organ = new Organ(true, _fieldsToSerialize);
						_organ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Sale Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Sale Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsale>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Sale(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Sale> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAsale>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Sale>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAsale> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAsale>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAsale> All(CriteriaSet args = null)
		{
			return Where<CSGenioAsale>(false, args, numRegs: -1);
		}

		public static List<Sale> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsale>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Sale>((r) => new Sale(r));
		}

// USE /[MANUAL GQT MODEL SALE]/
	}
}
