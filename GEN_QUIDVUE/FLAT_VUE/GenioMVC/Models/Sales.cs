using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Sales : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsales klass { get { return baseklass as CSGenioAsales; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValCodsales")]
		public string ValCodsales { get { return klass.ValCodsales; } set { klass.ValCodsales = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValCodorgan")]
		public string ValCodorgan { get { return klass.ValCodorgan; } set { klass.ValCodorgan = value; } }

		private Organ _organ;
		[DisplayName("Organ")]
		[ShouldSerialize("Organ")]
		public virtual Organ Organ
		{
			get
			{
				if (!isEmptyModel && (_organ == null || (!string.IsNullOrEmpty(ValCodorgan) && (_organ.isEmptyModel || _organ.klass.QPrimaryKey != ValCodorgan))))
					_organ = Models.Organ.Find(ValCodorgan, m_userContext, Identifier, _fieldsToSerialize);
				_organ ??= new Models.Organ(m_userContext, true, _fieldsToSerialize);
				return _organ;
			}
			set { _organ = value; }
		}

		[DisplayName("N.º da lide")]
		/// <summary>Field : "N.º da lide" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValNrlide")]
		[NumericAttribute(0)]
		public decimal? ValNrlide { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrlide, 0)); } set { klass.ValNrlide = Convert.ToDecimal(value); } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValStartdt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }

		[DisplayName("Identificação da oportunidade comercial")]
		/// <summary>Field : "Identificação da oportunidade comercial" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValIdentifi")]
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }

		[DisplayName("Potenciais compradores")]
		/// <summary>Field : "Potenciais compradores" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValPotcompr")]
		public string ValPotcompr { get { return klass.ValPotcompr; } set { klass.ValPotcompr = value; } }

		[DisplayName("Prospecção efectuada")]
		/// <summary>Field : "Prospecção efectuada" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValProspecc")]
		public bool ValProspecc { get { return Convert.ToBoolean(klass.ValProspecc); } set { klass.ValProspecc = Convert.ToInt32(value); } }

		[DisplayName("Interessado")]
		/// <summary>Field : "Interessado" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValInteress")]
		public bool ValInteress { get { return Convert.ToBoolean(klass.ValInteress); } set { klass.ValInteress = Convert.ToInt32(value); } }

		[DisplayName("Sem recursos financeiros")]
		/// <summary>Field : "Sem recursos financeiros" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValSemrfina")]
		public bool ValSemrfina { get { return Convert.ToBoolean(klass.ValSemrfina); } set { klass.ValSemrfina = Convert.ToInt32(value); } }

		[DisplayName("Sem capacidade de decisão")]
		/// <summary>Field : "Sem capacidade de decisão" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValSemcapac")]
		public bool ValSemcapac { get { return Convert.ToBoolean(klass.ValSemcapac); } set { klass.ValSemcapac = Convert.ToInt32(value); } }

		[DisplayName("Qualificação")]
		/// <summary>Field : "Qualificação" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtqualif")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get { return klass.ValDtqualif; } set { klass.ValDtqualif = value ?? DateTime.MinValue; } }

		[DisplayName("Qualificação efectuada")]
		/// <summary>Field : "Qualificação efectuada" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValQualific")]
		public bool ValQualific { get { return Convert.ToBoolean(klass.ValQualific); } set { klass.ValQualific = Convert.ToInt32(value); } }

		[DisplayName("Pré-abordagem")]
		/// <summary>Field : "Pré-abordagem" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValPreabord")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPreabord { get { return klass.ValPreabord; } set { klass.ValPreabord = value ?? DateTime.MinValue; } }

		[DisplayName("Trabalho de casa efectuado")]
		/// <summary>Field : "Trabalho de casa efectuado" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValHomework")]
		public bool ValHomework { get { return Convert.ToBoolean(klass.ValHomework); } set { klass.ValHomework = Convert.ToInt32(value); } }

		[DisplayName("Abordagem")]
		/// <summary>Field : "Abordagem" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtaborda")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaborda { get { return klass.ValDtaborda; } set { klass.ValDtaborda = value ?? DateTime.MinValue; } }

		[DisplayName("Abordagem efectuada")]
		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValApproach")]
		public bool ValApproach { get { return Convert.ToBoolean(klass.ValApproach); } set { klass.ValApproach = Convert.ToInt32(value); } }

		[DisplayName("Apresentação")]
		/// <summary>Field : "Apresentação" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValApresent")]
		public bool ValApresent { get { return Convert.ToBoolean(klass.ValApresent); } set { klass.ValApresent = Convert.ToInt32(value); } }

		[DisplayName("Apresentação efectuada")]
		/// <summary>Field : "Apresentação efectuada" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtaprese")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaprese { get { return klass.ValDtaprese; } set { klass.ValDtaprese = value ?? DateTime.MinValue; } }

		[DisplayName("Superar objeções")]
		/// <summary>Field : "Superar objeções" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtsupera")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtsupera { get { return klass.ValDtsupera; } set { klass.ValDtsupera = value ?? DateTime.MinValue; } }

		[DisplayName("Tentativas de fecho")]
		/// <summary>Field : "Tentativas de fecho" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValTentfech")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValTentfech { get { return klass.ValTentfech; } set { klass.ValTentfech = value ?? DateTime.MinValue; } }

		[DisplayName("Fecho da venda")]
		/// <summary>Field : "Fecho da venda" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtvenda")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtvenda { get { return klass.ValDtvenda; } set { klass.ValDtvenda = value ?? DateTime.MinValue; } }

		[DisplayName("Acompanhamento")]
		/// <summary>Field : "Acompanhamento" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValDtacompa")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtacompa { get { return klass.ValDtacompa; } set { klass.ValDtacompa = value ?? DateTime.MinValue; } }

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sales.ValShowrcrd")]
		public bool ValShowrcrd { get { return Convert.ToBoolean(klass.ValShowrcrd); } set { klass.ValShowrcrd = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Sales.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Sales(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAsales(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sales(UserContext userContext, CSGenioAsales val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAsales csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "organ":
						_organ ??= new Organ(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Sales Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsales>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Sales(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Sales> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsales>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Sales>((r) => new Sales(userCtx, r));
		}

// USE /[MANUAL GQT MODEL SALES]/
	}
}
