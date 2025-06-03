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
	public class Tpeq1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpeq1 klass { get { return baseklass as CSGenioAtpeq1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValCodfamil")]
		public string ValCodfamil { get { return klass.ValCodfamil; } set { klass.ValCodfamil = value; } }

		private Fami1 _fami1;
		[DisplayName("Fami1")]
		[ShouldSerialize("Fami1")]
		public virtual Fami1 Fami1
		{
			get
			{
				if (!isEmptyModel && (_fami1 == null || (!string.IsNullOrEmpty(ValCodfamil) && (_fami1.isEmptyModel || _fami1.klass.QPrimaryKey != ValCodfamil))))
					_fami1 = Models.Fami1.Find(ValCodfamil, m_userContext, Identifier, _fieldsToSerialize);
				_fami1 ??= new Models.Fami1(m_userContext, true, _fieldsToSerialize);
				return _fami1;
			}
			set { _fami1 = value; }
		}

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValTipoequi")]
		public string ValTipoequi { get { return klass.ValTipoequi; } set { klass.ValTipoequi = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValTpequcod")]
		public string ValTpequcod { get { return klass.ValTpequcod; } set { klass.ValTpequcod = value; } }

		[DisplayName("Dependent on")]
		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValTpequpai")]
		public string ValTpequpai { get { return klass.ValTpequpai; } set { klass.ValTpequpai = value; } }

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValNivel")]
		public decimal ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValBackcolo")]
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }

		[DisplayName("Letter color")]
		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValCorletra")]
		public string ValCorletra { get { return klass.ValCorletra; } set { klass.ValCorletra = value; } }

		[DisplayName("Maximum price")]
		/// <summary>Field : "Maximum price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValPrecomax")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecomax, 2)); } set { klass.ValPrecomax = Convert.ToDecimal(value); } }

		[DisplayName("Last price")]
		/// <summary>Field : "Last price" Tipo: "$D" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValPrecoult")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecoult, 2)); } set { klass.ValPrecoult = Convert.ToDecimal(value); } }

		[DisplayName("In")]
		/// <summary>Field : "In" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValSince")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValQtdequip")]
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQtdequip, 0)); } set { klass.ValQtdequip = Convert.ToDecimal(value); } }

		[DisplayName("Kit")]
		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Tpeq1.ValKit")]
		public bool ValKit { get { return Convert.ToBoolean(klass.ValKit); } set { klass.ValKit = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tpeq1.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tpeq1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtpeq1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpeq1(UserContext userContext, CSGenioAtpeq1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtpeq1 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fami1":
						_fami1 ??= new Fami1(m_userContext, true, _fieldsToSerialize);
						_fami1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpeq1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpeq1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpeq1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tpeq1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpeq1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpeq1>((r) => new Tpeq1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TPEQ1]/
	}
}
