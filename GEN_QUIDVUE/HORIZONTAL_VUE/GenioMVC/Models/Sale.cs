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
	public class Sale : ModelBase
	{
		[JsonIgnore]
		public CSGenioAsale klass { get { return baseklass as CSGenioAsale; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValCodvenda")]
		public string ValCodvenda { get { return klass.ValCodvenda; } set { klass.ValCodvenda = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValCodorgan")]
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

		[DisplayName("leadership numb")]
		/// <summary>Field : "leadership numb" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValNrlide")]
		[NumericAttribute(0)]
		public decimal? ValNrlide { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrlide, 0)); } set { klass.ValNrlide = Convert.ToDecimal(value); } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValStartdt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }

		[DisplayName("Identification of business opportunity")]
		/// <summary>Field : "Identification of business opportunity" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValIdentifi")]
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }

		[DisplayName("Potential Buyers")]
		/// <summary>Field : "Potential Buyers" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValPotcompr")]
		public string ValPotcompr { get { return klass.ValPotcompr; } set { klass.ValPotcompr = value; } }

		[DisplayName("Prospecting carried out")]
		/// <summary>Field : "Prospecting carried out" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValProspecc")]
		public bool ValProspecc { get { return Convert.ToBoolean(klass.ValProspecc); } set { klass.ValProspecc = Convert.ToInt32(value); } }

		[DisplayName("Interested")]
		/// <summary>Field : "Interested" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValInteress")]
		public bool ValInteress { get { return Convert.ToBoolean(klass.ValInteress); } set { klass.ValInteress = Convert.ToInt32(value); } }

		[DisplayName("Without financial resources")]
		/// <summary>Field : "Without financial resources" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValSemrfina")]
		public bool ValSemrfina { get { return Convert.ToBoolean(klass.ValSemrfina); } set { klass.ValSemrfina = Convert.ToInt32(value); } }

		[DisplayName("No decision-making power")]
		/// <summary>Field : "No decision-making power" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValSemcapac")]
		public bool ValSemcapac { get { return Convert.ToBoolean(klass.ValSemcapac); } set { klass.ValSemcapac = Convert.ToInt32(value); } }

		[DisplayName("Qualification")]
		/// <summary>Field : "Qualification" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtqualif")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get { return klass.ValDtqualif; } set { klass.ValDtqualif = value ?? DateTime.MinValue; } }

		[DisplayName("Qualification carried out")]
		/// <summary>Field : "Qualification carried out" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValQualific")]
		public bool ValQualific { get { return Convert.ToBoolean(klass.ValQualific); } set { klass.ValQualific = Convert.ToInt32(value); } }

		[DisplayName("Pre-approach")]
		/// <summary>Field : "Pre-approach" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValPreabord")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPreabord { get { return klass.ValPreabord; } set { klass.ValPreabord = value ?? DateTime.MinValue; } }

		[DisplayName("Homework done")]
		/// <summary>Field : "Homework done" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValHomework")]
		public bool ValHomework { get { return Convert.ToBoolean(klass.ValHomework); } set { klass.ValHomework = Convert.ToInt32(value); } }

		[DisplayName("Approach")]
		/// <summary>Field : "Approach" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtaborda")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaborda { get { return klass.ValDtaborda; } set { klass.ValDtaborda = value ?? DateTime.MinValue; } }

		[DisplayName("Abordagem efectuada")]
		/// <summary>Field : "Abordagem efectuada" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValApproach")]
		public bool ValApproach { get { return Convert.ToBoolean(klass.ValApproach); } set { klass.ValApproach = Convert.ToInt32(value); } }

		[DisplayName("Presentation")]
		/// <summary>Field : "Presentation" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValApresent")]
		public bool ValApresent { get { return Convert.ToBoolean(klass.ValApresent); } set { klass.ValApresent = Convert.ToInt32(value); } }

		[DisplayName("Presentation made")]
		/// <summary>Field : "Presentation made" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtaprese")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtaprese { get { return klass.ValDtaprese; } set { klass.ValDtaprese = value ?? DateTime.MinValue; } }

		[DisplayName("Overcome objections")]
		/// <summary>Field : "Overcome objections" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtsupera")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtsupera { get { return klass.ValDtsupera; } set { klass.ValDtsupera = value ?? DateTime.MinValue; } }

		[DisplayName("Closing attempts")]
		/// <summary>Field : "Closing attempts" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValTentfech")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValTentfech { get { return klass.ValTentfech; } set { klass.ValTentfech = value ?? DateTime.MinValue; } }

		[DisplayName("Closing of the sale")]
		/// <summary>Field : "Closing of the sale" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtvenda")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtvenda { get { return klass.ValDtvenda; } set { klass.ValDtvenda = value ?? DateTime.MinValue; } }

		[DisplayName("Follow-up")]
		/// <summary>Field : "Follow-up" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValDtacompa")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtacompa { get { return klass.ValDtacompa; } set { klass.ValDtacompa = value ?? DateTime.MinValue; } }

		[DisplayName("Show Record")]
		/// <summary>Field : "Show Record" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Sale.ValShowrcrd")]
		public bool ValShowrcrd { get { return Convert.ToBoolean(klass.ValShowrcrd); } set { klass.ValShowrcrd = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Sale.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Sale(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAsale(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Sale(UserContext userContext, CSGenioAsale val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAsale csgenioa)
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
		public static Sale Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAsale>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Sale(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Sale> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAsale>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Sale>((r) => new Sale(userCtx, r));
		}

// USE /[MANUAL GQT MODEL SALE]/
	}
}
