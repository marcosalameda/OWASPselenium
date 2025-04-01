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
	public class Sales : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsales klass { get { return baseklass as CSGenioAsales; } set { baseklass = value; } }

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
		public string ValCodsales { get { return klass.ValCodsales; } set { klass.ValCodsales = value; } }
		public bool ShouldSerializeValCodsales() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValCodsales");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodorgan { get { return klass.ValCodorgan; } set { klass.ValCodorgan = value; } }
		public bool ShouldSerializeValCodorgan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValCodorgan");
		private Organ _organ;
		[DisplayName("Organ")]
		public virtual Organ Organ { get { if (!this.isEmptyModel && (_organ == null || (!string.IsNullOrEmpty(ValCodorgan) && (_organ.isEmptyModel || _organ.klass.QPrimaryKey != ValCodorgan)))) _organ = Models.Organ.Find(ValCodorgan, Identifier, _fieldsToSerialize); if (_organ == null) _organ = new Models.Organ(true, _fieldsToSerialize); return _organ; } set { _organ = value; } }
		public bool ShouldSerializeOrgan () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Organ");

		[DisplayName("N.º da lide")]
		/// <summary>Field : "N.º da lide" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrlide { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrlide, 0)); } set { klass.ValNrlide = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNrlide() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValNrlide");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValStartdt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValStartdt");

		[DisplayName("Identificação da oportunidade comercial")]
		/// <summary>Field : "Identificação da oportunidade comercial" Tipo: "C" Formula:  ""</summary>
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }
		public bool ShouldSerializeValIdentifi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValIdentifi");

		[DisplayName("Potenciais compradores")]
		/// <summary>Field : "Potenciais compradores" Tipo: "C" Formula:  ""</summary>
		public string ValPotcompr { get { return klass.ValPotcompr; } set { klass.ValPotcompr = value; } }
		public bool ShouldSerializeValPotcompr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValPotcompr");

		[DisplayName("Prospecção efectuada")]
		/// <summary>Field : "Prospecção efectuada" Tipo: "L" Formula:  ""</summary>
		public bool ValProspecc { get { return Convert.ToBoolean(klass.ValProspecc); } set { klass.ValProspecc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValProspecc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValProspecc");

		[DisplayName("Interessado")]
		/// <summary>Field : "Interessado" Tipo: "L" Formula:  ""</summary>
		public bool ValInteress { get { return Convert.ToBoolean(klass.ValInteress); } set { klass.ValInteress = Convert.ToInt32(value); } }
		public bool ShouldSerializeValInteress() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValInteress");

		[DisplayName("Sem recursos financeiros")]
		/// <summary>Field : "Sem recursos financeiros" Tipo: "L" Formula:  ""</summary>
		public bool ValSemrfina { get { return Convert.ToBoolean(klass.ValSemrfina); } set { klass.ValSemrfina = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemrfina() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValSemrfina");

		[DisplayName("Sem capacidade de decisão")]
		/// <summary>Field : "Sem capacidade de decisão" Tipo: "L" Formula:  ""</summary>
		public bool ValSemcapac { get { return Convert.ToBoolean(klass.ValSemcapac); } set { klass.ValSemcapac = Convert.ToInt32(value); } }
		public bool ShouldSerializeValSemcapac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValSemcapac");

		[DisplayName("Qualificação")]
		/// <summary>Field : "Qualificação" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get { return klass.ValDtqualif; } set { klass.ValDtqualif = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtqualif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtqualif");

		[DisplayName("Qualificação efectuada")]
		/// <summary>Field : "Qualificação efectuada" Tipo: "L" Formula:  ""</summary>
		public bool ValQualific { get { return Convert.ToBoolean(klass.ValQualific); } set { klass.ValQualific = Convert.ToInt32(value); } }
		public bool ShouldSerializeValQualific() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValQualific");

		[DisplayName("Pré-abordagem")]
		/// <summary>Field : "Pré-abordagem" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPreabord { get { return klass.ValPreabord; } set { klass.ValPreabord = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPreabord() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValPreabord");

		[DisplayName("Trabalho de casa efectuado")]
		/// <summary>Field : "Trabalho de casa efectuado" Tipo: "L" Formula:  ""</summary>
		public bool ValHomework { get { return Convert.ToBoolean(klass.ValHomework); } set { klass.ValHomework = Convert.ToInt32(value); } }
		public bool ShouldSerializeValHomework() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValHomework");

		[DisplayName("Abordagem")]
		/// <summary>Field : "Abordagem" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaborda { get { return klass.ValDtaborda; } set { klass.ValDtaborda = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtaborda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtaborda");

		[DisplayName("Abordagem efectuada")]
		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		public bool ValApproach { get { return Convert.ToBoolean(klass.ValApproach); } set { klass.ValApproach = Convert.ToInt32(value); } }
		public bool ShouldSerializeValApproach() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValApproach");

		[DisplayName("Apresentação")]
		/// <summary>Field : "Apresentação" Tipo: "L" Formula:  ""</summary>
		public bool ValApresent { get { return Convert.ToBoolean(klass.ValApresent); } set { klass.ValApresent = Convert.ToInt32(value); } }
		public bool ShouldSerializeValApresent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValApresent");

		[DisplayName("Apresentação efectuada")]
		/// <summary>Field : "Apresentação efectuada" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaprese { get { return klass.ValDtaprese; } set { klass.ValDtaprese = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtaprese() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtaprese");

		[DisplayName("Superar objeções")]
		/// <summary>Field : "Superar objeções" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtsupera { get { return klass.ValDtsupera; } set { klass.ValDtsupera = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtsupera() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtsupera");

		[DisplayName("Tentativas de fecho")]
		/// <summary>Field : "Tentativas de fecho" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValTentfech { get { return klass.ValTentfech; } set { klass.ValTentfech = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValTentfech() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValTentfech");

		[DisplayName("Fecho da venda")]
		/// <summary>Field : "Fecho da venda" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtvenda { get { return klass.ValDtvenda; } set { klass.ValDtvenda = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtvenda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtvenda");

		[DisplayName("Acompanhamento")]
		/// <summary>Field : "Acompanhamento" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtacompa { get { return klass.ValDtacompa; } set { klass.ValDtacompa = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtacompa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValDtacompa");

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		public bool ValShowrcrd { get { return Convert.ToBoolean(klass.ValShowrcrd); } set { klass.ValShowrcrd = Convert.ToInt32(value); } }
		public bool ShouldSerializeValShowrcrd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValShowrcrd");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Sales.ValZzstate");

		public Sales() : this(UserContext.Current.User) { }

		public Sales(User u)
		{
			this.klass = new CSGenioAsales(u);
		}

		public Sales(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sales(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Sales(bool isEmpty) : this(isEmpty, null) { }

		public Sales(CSGenioAsales val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sales(CSGenioAsales val) : this(val, null) { }

		public Sales(CSGenioAsales val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Sales(CSGenioAsales val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAsales csgenioa)
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
		public static Sales Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Sales Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsales>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Sales(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Sales> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAsales>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Sales>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAsales> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAsales>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAsales> All(CriteriaSet args = null)
		{
			return Where<CSGenioAsales>(false, args, numRegs: -1);
		}

		public static List<Sales> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsales>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Sales>((r) => new Sales(r));
		}

// USE /[MANUAL GQT MODEL SALES]/
	}
}
