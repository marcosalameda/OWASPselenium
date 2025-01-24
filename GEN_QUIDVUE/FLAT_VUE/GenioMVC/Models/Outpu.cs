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
	public class Outpu : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoutpu klass { get { return baseklass as CSGenioAoutpu; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Outpu.ValCodoutpu")]
		public string ValCodoutpu { get { return klass.ValCodoutpu; } set { klass.ValCodoutpu = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Outpu.ValCodoutpt")]
		public string ValCodoutpt { get { return klass.ValCodoutpt; } set { klass.ValCodoutpt = value; } }
		private Outpt _outpt;
		[DisplayName("Outpt")]
		[ShouldSerialize("Outpt")]
		public virtual Outpt Outpt {
			get {
				if (!this.isEmptyModel && (_outpt == null || (!string.IsNullOrEmpty(ValCodoutpt) && (_outpt.isEmptyModel || _outpt.klass.QPrimaryKey != ValCodoutpt))))
					_outpt = Models.Outpt.Find(ValCodoutpt, m_userContext, Identifier, _fieldsToSerialize);
				if (_outpt == null)
					_outpt = new Models.Outpt(m_userContext, true, _fieldsToSerialize);
				return _outpt;
			}
			set { _outpt = value; }
		}


		[DisplayName("Line")]
		/// <summary>Field : "Line" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Outpu.ValLine")]
		[NumericAttribute(1)]
		public decimal? ValLine { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValLine, 1)); } set { klass.ValLine = Convert.ToDecimal(value); } }

		[DisplayName(">WAREHOUSE")]
		/// <summary>Field : ">WAREHOUSE" Tipo: "CE" Formula: DF "[OUTPT->CODWAREH]"</summary>
		[ShouldSerialize("Outpu.ValCodwareh")]
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
		[ShouldSerialize("Outpu.ValCoditem")]
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


		[DisplayName("Exit instant")]
		/// <summary>Field : "Exit instant" Tipo: "DT" Formula: ++ "[OUTPT->DHDOCUME]"</summary>
		[ShouldSerialize("Outpu.ValExitdt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValExitdt { get { return klass.ValExitdt; } set { klass.ValExitdt = value ?? DateTime.MinValue; } }

		[DisplayName(">EXIT DOCUMENT")]
		/// <summary>Field : ">EXIT DOCUMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Outpu.ValCoddocsd")]
		public string ValCoddocsd { get { return klass.ValCoddocsd; } set { klass.ValCoddocsd = value; } }
		private Oudoc _oudoc;
		[DisplayName("Oudoc")]
		[ShouldSerialize("Oudoc")]
		public virtual Oudoc Oudoc {
			get {
				if (!this.isEmptyModel && (_oudoc == null || (!string.IsNullOrEmpty(ValCoddocsd) && (_oudoc.isEmptyModel || _oudoc.klass.QPrimaryKey != ValCoddocsd))))
					_oudoc = Models.Oudoc.Find(ValCoddocsd, m_userContext, Identifier, _fieldsToSerialize);
				if (_oudoc == null)
					_oudoc = new Models.Oudoc(m_userContext, true, _fieldsToSerialize);
				return _oudoc;
			}
			set { _oudoc = value; }
		}


		[DisplayName("Qtd output")]
		/// <summary>Field : "Qtd output" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Outpu.ValExitqnty")]
		[NumericAttribute(0)]
		public decimal? ValExitqnty { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValExitqnty, 0)); } set { klass.ValExitqnty = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Outpu.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Outpu(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAoutpu(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Outpu(UserContext userContext, CSGenioAoutpu val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAoutpu csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "outpt":
						if (_outpt == null)
							_outpt = new Outpt(m_userContext, true, _fieldsToSerialize);
						_outpt.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
					case "oudoc":
						if (_oudoc == null)
							_oudoc = new Oudoc(m_userContext, true, _fieldsToSerialize);
						_oudoc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Outpu Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoutpu>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Outpu(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Outpu> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoutpu>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Outpu>((r) => new Outpu(userCtx, r));
		}

// USE /[MANUAL GQT MODEL OUTPU]/
	}
}
