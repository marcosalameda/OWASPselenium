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
	public class Dilin : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdilin klass { get { return baseklass as CSGenioAdilin; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValCoddilin")]
		public string ValCoddilin { get { return klass.ValCoddilin; } set { klass.ValCoddilin = value; } }

		[DisplayName(">>DISPATCH")]
		/// <summary>Field : ">>DISPATCH" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValCoddispa")]
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }
		private Dispa _dispa;
		[DisplayName("Dispa")]
		[ShouldSerialize("Dispa")]
		public virtual Dispa Dispa { 
			get { 
				if (!this.isEmptyModel && (_dispa == null || (!string.IsNullOrEmpty(ValCoddispa) && (_dispa.isEmptyModel || _dispa.klass.QPrimaryKey != ValCoddispa))))
					_dispa = Models.Dispa.Find(ValCoddispa, m_userContext, Identifier, _fieldsToSerialize);
				if (_dispa == null)
					_dispa = new Models.Dispa(m_userContext, true, _fieldsToSerialize);
				return _dispa;
			}
			set { _dispa = value; } 
		}
		

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValLinenumb")]
		[NumericAttribute(0)]
		public decimal? ValLinenumb { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLinenumb, 0)); } set { klass.ValLinenumb = Convert.ToDouble(value); } }

		[DisplayName(">>PRODUCT")]
		/// <summary>Field : ">>PRODUCT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValCodprodu")]
		public string ValCodprodu { get { return klass.ValCodprodu; } set { klass.ValCodprodu = value; } }
		private Produ _produ;
		[DisplayName("Produ")]
		[ShouldSerialize("Produ")]
		public virtual Produ Produ { 
			get { 
				if (!this.isEmptyModel && (_produ == null || (!string.IsNullOrEmpty(ValCodprodu) && (_produ.isEmptyModel || _produ.klass.QPrimaryKey != ValCodprodu))))
					_produ = Models.Produ.Find(ValCodprodu, m_userContext, Identifier, _fieldsToSerialize);
				if (_produ == null)
					_produ = new Models.Produ(m_userContext, true, _fieldsToSerialize);
				return _produ;
			}
			set { _produ = value; } 
		}
		

		[DisplayName("Ordered")]
		/// <summary>Field : "Ordered" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValOrdered")]
		[NumericAttribute(0)]
		public decimal? ValOrdered { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrdered, 0)); } set { klass.ValOrdered = Convert.ToDouble(value); } }

		[DisplayName("Delivered")]
		/// <summary>Field : "Delivered" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dilin.ValDelivere")]
		[NumericAttribute(0)]
		public decimal? ValDelivere { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDelivere, 0)); } set { klass.ValDelivere = Convert.ToDouble(value); } }

		[DisplayName("Outstanding")]
		/// <summary>Field : "Outstanding" Tipo: "N" Formula: + "[DILIN->ORDERED]-[DILIN->DELIVERE]"</summary>
		[ShouldSerialize("Dilin.ValOutstand")]
		[NumericAttribute(0)]
		public decimal? ValOutstand { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOutstand, 0)); } set { klass.ValOutstand = Convert.ToDouble(value); } }

		[DisplayName("Instant")]
		/// <summary>Field : "Instant" Tipo: "DT" Formula: ++ "[DISPA->DISPADT]"</summary>
		[ShouldSerialize("Dilin.ValInstant")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValInstant { get { return klass.ValInstant; } set { klass.ValInstant = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Dilin.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Dilin(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdilin(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Dilin(UserContext userContext, CSGenioAdilin val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAdilin csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "dispa":
						if (_dispa == null)
							_dispa = new Dispa(m_userContext, true, _fieldsToSerialize);
						_dispa.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "produ":
						if (_produ == null)
							_produ = new Produ(m_userContext, true, _fieldsToSerialize);
						_produ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Dilin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdilin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Dilin(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Dilin> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdilin>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dilin>((r) => new Dilin(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DILIN]/
	}
}
