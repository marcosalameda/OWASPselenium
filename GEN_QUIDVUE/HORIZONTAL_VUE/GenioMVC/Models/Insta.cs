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
	public class Insta : ModelBase
	{
		[JsonIgnore]
		public CSGenioAinsta klass { get { return baseklass as CSGenioAinsta; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValCodinsta")]
		public string ValCodinsta { get { return klass.ValCodinsta; } set { klass.ValCodinsta = value; } }

		[DisplayName(">TYPE OF EQUIPMENT")]
		/// <summary>Field : ">TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }

		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		[ShouldSerialize("Tpequ")]
		public virtual Tpequ Tpequ
		{
			get
			{
				if (!isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ))))
					_tpequ = Models.Tpequ.Find(ValCodtpequ, m_userContext, Identifier, _fieldsToSerialize);
				_tpequ ??= new Models.Tpequ(m_userContext, true, _fieldsToSerialize);
				return _tpequ;
			}
			set { _tpequ = value; }
		}

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }

		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip
		{
			get
			{
				if (!isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				_equip ??= new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; }
		}

		[DisplayName("Scheduling")]
		/// <summary>Field : "Scheduling" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValDtiniage")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtiniage { get { return klass.ValDtiniage; } set { klass.ValDtiniage = value ?? DateTime.MinValue; } }

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValDtfimage")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtfimage { get { return klass.ValDtfimage; } set { klass.ValDtfimage = value ?? DateTime.MinValue; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("All day")]
		/// <summary>Field : "All day" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValAllday")]
		public bool ValAllday { get { return Convert.ToBoolean(klass.ValAllday); } set { klass.ValAllday = Convert.ToInt32(value); } }

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValSince")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }

		[DisplayName("Until")]
		/// <summary>Field : "Until" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValUntil")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValUntil { get { return klass.ValUntil; } set { klass.ValUntil = value ?? DateTime.MinValue; } }

		[DisplayName("Qtd hours")]
		/// <summary>Field : "Qtd hours" Tipo: "N" Formula: + "iif(emptyD([INSTA->SINCE])==1 || emptyD([INSTA->UNTIL])==1,0,Diferenca_entre_Datas([INSTA->SINCE],[INSTA->UNTIL],"H"))"</summary>
		[ShouldSerialize("Insta.ValHours")]
		[NumericAttribute(2)]
		public decimal? ValHours { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValHours, 2)); } set { klass.ValHours = Convert.ToDecimal(value); } }

		[DisplayName("Hourly price")]
		/// <summary>Field : "Hourly price" Tipo: "$D" Formula: CT "TABPR[INSTA->SINCE][TABPR->SINCE][TABPR->PRECOHOR][INSTA->CODTPEQU][TABPR->CODTPEQ1](DESC)"</summary>
		[ShouldSerialize("Insta.ValPrecohor")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecohor { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecohor, 2)); } set { klass.ValPrecohor = Convert.ToDecimal(value); } }

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "$D" Formula: + "[INSTA->HOURS]*[INSTA->PRECOHOR]"</summary>
		[ShouldSerialize("Insta.ValValue")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValValue, 2)); } set { klass.ValValue = Convert.ToDecimal(value); } }

		[DisplayName("Geographic coordinate")]
		/// <summary>Field : "Geographic coordinate" Tipo: "GG" Formula:  ""</summary>
		[ShouldSerialize("Insta.ValCoordgeo")]
		[GeographicAttribute("GG")]
		public string ValCoordgeo { get { return klass.ValCoordgeo; } set { klass.ValCoordgeo = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Insta.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Insta(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAinsta(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Insta(UserContext userContext, CSGenioAinsta val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAinsta csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						_tpequ ??= new Tpequ(m_userContext, true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "equip":
						_equip ??= new Equip(m_userContext, true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Insta Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAinsta>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Insta(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Insta> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAinsta>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Insta>((r) => new Insta(userCtx, r));
		}

// USE /[MANUAL GQT MODEL INSTA]/
	}
}
