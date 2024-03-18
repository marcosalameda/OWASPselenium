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
	public class Ldent : ModelBase
	{
		[JsonIgnore]
		public CSGenioAldent klass { get { return baseklass as CSGenioAldent; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValCodldent")]
		public string ValCodldent { get { return klass.ValCodldent; } set { klass.ValCodldent = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValCoddentr")]
		public string ValCoddentr { get { return klass.ValCoddentr; } set { klass.ValCoddentr = value; } }
		private Indoc _indoc;
		[DisplayName("Indoc")]
		[ShouldSerialize("Indoc")]
		public virtual Indoc Indoc { 
			get { 
				if (!this.isEmptyModel && (_indoc == null || (!string.IsNullOrEmpty(ValCoddentr) && (_indoc.isEmptyModel || _indoc.klass.QPrimaryKey != ValCoddentr))))
					_indoc = Models.Indoc.Find(ValCoddentr, m_userContext, Identifier, _fieldsToSerialize);
				if (_indoc == null)
					_indoc = new Models.Indoc(m_userContext, true, _fieldsToSerialize);
				return _indoc;
			}
			set { _indoc = value; } 
		}
		

		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValLine")]
		[NumericAttribute(1)]
		public decimal? ValLine { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLine, 1)); } set { klass.ValLine = Convert.ToDouble(value); } }

		[DisplayName(">ARMAZEM")]
		/// <summary>Field : ">ARMAZEM" Tipo: "CE" Formula: DF "[INDOC->CODWAREH]"</summary>
		[ShouldSerialize("Ldent.ValCodwareh")]
		public string ValCodwareh { get { return klass.ValCodwareh; } set { klass.ValCodwareh = value; } }
		private Wareh _wareh;
		[DisplayName("Wareh")]
		[ShouldSerialize("Wareh")]
		public virtual Wareh Wareh { 
			get { 
				if (!this.isEmptyModel && (_wareh == null || (!string.IsNullOrEmpty(ValCodwareh) && (_wareh.isEmptyModel || _wareh.klass.QPrimaryKey != ValCodwareh))))
					_wareh = Models.Wareh.Find(ValCodwareh, m_userContext, Identifier, _fieldsToSerialize);
				if (_wareh == null)
					_wareh = new Models.Wareh(m_userContext, true, _fieldsToSerialize);
				return _wareh;
			}
			set { _wareh = value; } 
		}
		

		[DisplayName(">ARTICLE")]
		/// <summary>Field : ">ARTICLE" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValCoditem")]
		public string ValCoditem { get { return klass.ValCoditem; } set { klass.ValCoditem = value; } }
		private Item _item;
		[DisplayName("Item")]
		[ShouldSerialize("Item")]
		public virtual Item Item { 
			get { 
				if (!this.isEmptyModel && (_item == null || (!string.IsNullOrEmpty(ValCoditem) && (_item.isEmptyModel || _item.klass.QPrimaryKey != ValCoditem))))
					_item = Models.Item.Find(ValCoditem, m_userContext, Identifier, _fieldsToSerialize);
				if (_item == null)
					_item = new Models.Item(m_userContext, true, _fieldsToSerialize);
				return _item;
			}
			set { _item = value; } 
		}
		

		[DisplayName("Qtd entry")]
		/// <summary>Field : "Qtd entry" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValQtdentra")]
		[NumericAttribute(0)]
		public decimal? ValQtdentra { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdentra, 0)); } set { klass.ValQtdentra = Convert.ToDouble(value); } }

		[DisplayName("Instant entrance")]
		/// <summary>Field : "Instant entrance" Tipo: "DT" Formula: ++ "[INDOC->DHDOCUME]"</summary>
		[ShouldSerialize("Ldent.ValDhentra")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhentra { get { return klass.ValDhentra; } set { klass.ValDhentra = value ?? DateTime.MinValue; } }

		[DisplayName("Articles in use")]
		/// <summary>Field : "Articles in use" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ldent.ValEmuso")]
		public bool ValEmuso { get { return Convert.ToBoolean(klass.ValEmuso); } set { klass.ValEmuso = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Ldent.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Ldent(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAldent(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Ldent(UserContext userContext, CSGenioAldent val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAldent csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "indoc":
						if (_indoc == null)
							_indoc = new Indoc(m_userContext, true, _fieldsToSerialize);
						_indoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "wareh":
						if (_wareh == null)
							_wareh = new Wareh(m_userContext, true, _fieldsToSerialize);
						_wareh.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "item":
						if (_item == null)
							_item = new Item(m_userContext, true, _fieldsToSerialize);
						_item.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Ldent Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAldent>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ldent(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Ldent> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAldent>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ldent>((r) => new Ldent(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LDENT]/
	}
}
