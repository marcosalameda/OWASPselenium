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
	public class Tpequ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpequ klass { get { return baseklass as CSGenioAtpequ; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValCodfamil")]
		public string ValCodfamil { get { return klass.ValCodfamil; } set { klass.ValCodfamil = value; } }
		private Famil _famil;
		[DisplayName("Famil")]
		[ShouldSerialize("Famil")]
		public virtual Famil Famil { 
			get { 
				if (!this.isEmptyModel && (_famil == null || (!string.IsNullOrEmpty(ValCodfamil) && (_famil.isEmptyModel || _famil.klass.QPrimaryKey != ValCodfamil))))
					_famil = Models.Famil.Find(ValCodfamil, m_userContext, Identifier, _fieldsToSerialize);
				if (_famil == null)
					_famil = new Models.Famil(m_userContext, true, _fieldsToSerialize);
				return _famil;
			}
			set { _famil = value; } 
		}
		

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValTipoequi")]
		public string ValTipoequi { get { return klass.ValTipoequi; } set { klass.ValTipoequi = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValTpequcod")]
		public string ValTpequcod { get { return klass.ValTpequcod; } set { klass.ValTpequcod = value; } }

		[DisplayName("Dependent on")]
		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValTpequpai")]
		public string ValTpequpai { get { return klass.ValTpequpai; } set { klass.ValTpequpai = value; } }

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValNivel")]
		public double ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValBackcolo")]
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }

		[DisplayName("Letter color")]
		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValCorletra")]
		public string ValCorletra { get { return klass.ValCorletra; } set { klass.ValCorletra = value; } }

		[DisplayName("Maximum price")]
		/// <summary>Field : "Maximum price" Tipo: "$D" Formula: U1 "TABPR[TABPR->PRECOHOR][TABPR->PRECOHOR]"</summary>
		[ShouldSerialize("Tpequ.ValPrecomax")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecomax, 2)); } set { klass.ValPrecomax = Convert.ToDouble(value); } }

		[DisplayName("Last price")]
		/// <summary>Field : "Last price" Tipo: "$D" Formula: U1 "TABPR[TABPR->SINCE][TABPR->PRECOHOR][Today]"</summary>
		[ShouldSerialize("Tpequ.ValPrecoult")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecoult, 2)); } set { klass.ValPrecoult = Convert.ToDouble(value); } }

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula: U1 "TABPR[TABPR->SINCE][TABPR->SINCE][Today]"</summary>
		[ShouldSerialize("Tpequ.ValSince")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula: SR "[EQUIP->1]"</summary>
		[ShouldSerialize("Tpequ.ValQtdequip")]
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdequip, 0)); } set { klass.ValQtdequip = Convert.ToDouble(value); } }

		[DisplayName("Kit")]
		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Tpequ.ValKit")]
		public bool ValKit { get { return Convert.ToBoolean(klass.ValKit); } set { klass.ValKit = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tpequ.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tpequ(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtpequ(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Tpequ(UserContext userContext, CSGenioAtpequ val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAtpequ csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "famil":
						if (_famil == null)
							_famil = new Famil(m_userContext, true, _fieldsToSerialize);
						_famil.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpequ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpequ>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpequ(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tpequ> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpequ>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpequ>((r) => new Tpequ(userCtx, r));
		}

		public StatusMessage carga_unico(string idsrc)
		{
			User u = m_userContext.User;
			PersistentSupport sp = m_userContext.PersistentSupport;
			StatusMessage Qresult = this.klass.carga_unico(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL TPEQU]/
	}
}
