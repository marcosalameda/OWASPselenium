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
	public class Visit : ModelBase
	{
		[JsonIgnore]
		public CSGenioAvisit klass { get { return baseklass as CSGenioAvisit; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValCodvisit")]
		public string ValCodvisit { get { return klass.ValCodvisit; } set { klass.ValCodvisit = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip { 
			get { 
				if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				if (_equip == null)
					_equip = new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; } 
		}
		

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValStartdt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValStartdt { get { return klass.ValStartdt; } set { klass.ValStartdt = value ?? DateTime.MinValue; } }

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValDtfim")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtfim { get { return klass.ValDtfim; } set { klass.ValDtfim = value ?? DateTime.MinValue; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Day")]
		/// <summary>Field : "Day" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValTodoodia")]
		public bool ValTodoodia { get { return Convert.ToBoolean(klass.ValTodoodia); } set { klass.ValTodoodia = Convert.ToInt32(value); } }

		[DisplayName("Observations")]
		/// <summary>Field : "Observations" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValObservat")]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }

		[DisplayName("Color")]
		/// <summary>Field : "Color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValColor")]
		public string ValColor { get { return klass.ValColor; } set { klass.ValColor = value; } }

		[DisplayName("Background")]
		/// <summary>Field : "Background" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Visit.ValBack")]
		public bool ValBack { get { return Convert.ToBoolean(klass.ValBack); } set { klass.ValBack = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Visit.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Visit(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAvisit(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Visit(UserContext userContext, CSGenioAvisit val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAvisit csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						if (_equip == null)
							_equip = new Equip(m_userContext, true, _fieldsToSerialize);
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
		public static Visit Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAvisit>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Visit(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Visit> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAvisit>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Visit>((r) => new Visit(userCtx, r));
		}

// USE /[MANUAL GQT MODEL VISIT]/
	}
}
