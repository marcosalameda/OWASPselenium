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
	public class Roigi : ModelBase
	{
		[JsonIgnore]
		public CSGenioAroigi klass { get { return baseklass as CSGenioAroigi; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Roigi.ValCodroigi")]
		public string ValCodroigi { get { return klass.ValCodroigi; } set { klass.ValCodroigi = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Roigi.ValCodrogl1")]
		public string ValCodrogl1 { get { return klass.ValCodrogl1; } set { klass.ValCodrogl1 = value; } }
		private Rogl1 _rogl1;
		[DisplayName("Rogl1")]
		[ShouldSerialize("Rogl1")]
		public virtual Rogl1 Rogl1 { 
			get { 
				if (!this.isEmptyModel && (_rogl1 == null || (!string.IsNullOrEmpty(ValCodrogl1) && (_rogl1.isEmptyModel || _rogl1.klass.QPrimaryKey != ValCodrogl1))))
					_rogl1 = Models.Rogl1.Find(ValCodrogl1, m_userContext, Identifier, _fieldsToSerialize);
				if (_rogl1 == null)
					_rogl1 = new Models.Rogl1(m_userContext, true, _fieldsToSerialize);
				return _rogl1;
			}
			set { _rogl1 = value; } 
		}
		

		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Roigi.ValOrder")]
		[NumericAttribute(0)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 0)); } set { klass.ValOrder = Convert.ToDouble(value); } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Roigi.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Roigi.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Roigi(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAroigi(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Roigi(UserContext userContext, CSGenioAroigi val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAroigi csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "rogl1":
						if (_rogl1 == null)
							_rogl1 = new Rogl1(m_userContext, true, _fieldsToSerialize);
						_rogl1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Roigi Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAroigi>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Roigi(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Roigi> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAroigi>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Roigi>((r) => new Roigi(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ROIGI]/
	}
}
