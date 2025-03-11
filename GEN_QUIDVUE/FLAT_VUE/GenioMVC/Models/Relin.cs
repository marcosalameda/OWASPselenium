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
	public class Relin : ModelBase
	{
		[JsonIgnore]
		public CSGenioArelin klass { get { return baseklass as CSGenioArelin; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValCoddilin")]
		public string ValCoddilin { get { return klass.ValCoddilin; } set { klass.ValCoddilin = value; } }

		[DisplayName(">>RECEIPT")]
		/// <summary>Field : ">>RECEIPT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValCodrecei")]
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }

		private Recei _recei;
		[DisplayName("Recei")]
		[ShouldSerialize("Recei")]
		public virtual Recei Recei
		{
			get
			{
				if (!isEmptyModel && (_recei == null || (!string.IsNullOrEmpty(ValCodrecei) && (_recei.isEmptyModel || _recei.klass.QPrimaryKey != ValCodrecei))))
					_recei = Models.Recei.Find(ValCodrecei, m_userContext, Identifier, _fieldsToSerialize);
				_recei ??= new Models.Recei(m_userContext, true, _fieldsToSerialize);
				return _recei;
			}
			set { _recei = value; }
		}

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValLinenumb")]
		[NumericAttribute(0)]
		public decimal? ValLinenumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLinenumb, 0)); } set { klass.ValLinenumb = Convert.ToDecimal(value); } }

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValCodprodu")]
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }

		private Produ _produ;
		[DisplayName("Produ")]
		[ShouldSerialize("Produ")]
		public virtual Produ Produ
		{
			get
			{
				if (!isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu))))
					_produ = Models.Produ.Find(ValCodprodu, m_userContext, Identifier, _fieldsToSerialize);
				_produ ??= new Models.Produ(m_userContext, true, _fieldsToSerialize);
				return _produ;
			}
			set { _produ = value; }
		}

		[DisplayName("Ordered")]
		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValOrdered")]
		[NumericAttribute(0)]
		public decimal? ValOrdered { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrdered, 0)); } set { klass.ValOrdered = Convert.ToDecimal(value); } }

		[DisplayName("Received")]
		/// <summary>Field : "Received" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValReceived")]
		[NumericAttribute(0)]
		public decimal? ValReceived { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValReceived, 0)); } set { klass.ValReceived = Convert.ToDecimal(value); } }

		[DisplayName("Outstanding")]
		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[RELIN->ORDERED]-[RELIN->RECEIVED]"</summary>
		[ShouldSerialize("Relin.ValOutstand")]
		[NumericAttribute(0)]
		public decimal? ValOutstand { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutstand, 0)); } set { klass.ValOutstand = Convert.ToDecimal(value); } }

		[DisplayName(">>SUPPLIER")]
		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Relin.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		private Entit _entit;
		[DisplayName("Entit")]
		[ShouldSerialize("Entit")]
		public virtual Entit Entit
		{
			get
			{
				if (!isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit))))
					_entit = Models.Entit.Find(ValCodentit, m_userContext, Identifier, _fieldsToSerialize);
				_entit ??= new Models.Entit(m_userContext, true, _fieldsToSerialize);
				return _entit;
			}
			set { _entit = value; }
		}

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[RECEI->DTRECEIP]"</summary>
		[ShouldSerialize("Relin.ValInstant")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValInstant { get { return klass.ValInstant; } set { klass.ValInstant = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Relin.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Relin(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArelin(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Relin(UserContext userContext, CSGenioArelin val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioArelin csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "recei":
						_recei ??= new Recei(m_userContext, true, _fieldsToSerialize);
						_recei.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "produ":
						_produ ??= new Produ(m_userContext, true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "entit":
						_entit ??= new Entit(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Relin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArelin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Relin(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Relin> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArelin>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Relin>((r) => new Relin(userCtx, r));
		}

// USE /[MANUAL GQT MODEL RELIN]/
	}
}
