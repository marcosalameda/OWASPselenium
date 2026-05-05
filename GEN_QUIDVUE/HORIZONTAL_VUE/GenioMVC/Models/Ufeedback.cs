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
	public class Ufeedback : ModelBase
	{
		[JsonIgnore]
		public CSGenioAufeedback klass { get { return baseklass as CSGenioAufeedback; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "CODUFEEDBACK" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValCodufeedback")]
		public string ValCodufeedback { get { return klass.ValCodufeedback; } set { klass.ValCodufeedback = value; } }

		[DisplayName("feedback")]
		/// <summary>Field : "feedback" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValSfeedback")]
		[DataArray("Feedback", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValSfeedback { get { return klass.ValSfeedback; } set { klass.ValSfeedback = value; } }
		[JsonIgnore]
		public SelectList ArrayValsfeedback { get { return new SelectList(CSGenio.business.ArrayFeedback.GetDictionary(), "Key", "Value", ValSfeedback); } set { ValSfeedback = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("Comments")]
		/// <summary>Field : "Comments" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValFeedbcoment")]
		[DataType(DataType.MultilineText)]
		public string ValFeedbcoment { get { return klass.ValFeedbcoment; } set { klass.ValFeedbcoment = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValCodfeedbacktype")]
		public string ValCodfeedbacktype { get { return klass.ValCodfeedbacktype; } set { klass.ValCodfeedbacktype = value; } }

		private Feedbacktype _feedbacktype;
		[DisplayName("Feedbacktype")]
		[ShouldSerialize("Feedbacktype")]
		public virtual Feedbacktype Feedbacktype
		{
			get
			{
				if (!isEmptyModel && (_feedbacktype == null || (!string.IsNullOrEmpty(ValCodfeedbacktype) && (_feedbacktype.isEmptyModel || _feedbacktype.klass.QPrimaryKey != ValCodfeedbacktype))))
					_feedbacktype = Models.Feedbacktype.Find(ValCodfeedbacktype, m_userContext, Identifier, _fieldsToSerialize);
				_feedbacktype ??= new Models.Feedbacktype(m_userContext, true, _fieldsToSerialize);
				return _feedbacktype;
			}
			set { _feedbacktype = value; }
		}

		[DisplayName("icon rating")]
		/// <summary>Field : "icon rating" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValIconrating")]
		[DataArray("Iconrating", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValIconrating { get { return klass.ValIconrating; } set { klass.ValIconrating = value; } }
		[JsonIgnore]
		public SelectList ArrayValiconrating { get { return new SelectList(CSGenio.business.ArrayIconrating.GetDictionary(), "Key", "Value", ValIconrating); } set { ValIconrating = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("quick feedback")]
		/// <summary>Field : "quick feedback" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValQuickfeedback")]
		[DataArray("Quickfeedback", GenioMVC.Helpers.ArrayType.Character)]
		public string ValQuickfeedback { get { return klass.ValQuickfeedback; } set { klass.ValQuickfeedback = value; } }
		[JsonIgnore]
		public SelectList ArrayValquickfeedback { get { return new SelectList(CSGenio.business.ArrayQuickfeedback.GetDictionary(), "Key", "Value", ValQuickfeedback); } set { ValQuickfeedback = value.SelectedValue as string; } }

		[DisplayName("SERVICE FEEDBACK")]
		/// <summary>Field : "SERVICE FEEDBACK" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValServicefeedback")]
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValServicefeedback { get { return klass.ValServicefeedback; } set { klass.ValServicefeedback = value; } }
		[JsonIgnore]
		public SelectList ArrayValservicefeedback { get { return new SelectList(CSGenio.business.ArrayAreatecn.GetDictionary(), "Key", "Value", ValServicefeedback); } set { ValServicefeedback = value.SelectedValue as string; } }

		[DisplayName("SERVICE TYPE")]
		/// <summary>Field : "SERVICE TYPE" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValServicetype")]
		[DataArray("Servicetype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValServicetype { get { return klass.ValServicetype; } set { klass.ValServicetype = value; } }
		[JsonIgnore]
		public SelectList ArrayValservicetype { get { return new SelectList(CSGenio.business.ArrayServicetype.GetDictionary(), "Key", "Value", ValServicetype); } set { ValServicetype = value.SelectedValue as string; } }

		[DisplayName("FEEDBACK DATE")]
		/// <summary>Field : "FEEDBACK DATE" Tipo: "DT" Formula: + "[Now]"</summary>
		[ShouldSerialize("Ufeedback.ValFeedbackdate")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValFeedbackdate { get { return klass.ValFeedbackdate; } set { klass.ValFeedbackdate = value ?? DateTime.MinValue; } }

		[DisplayName("Files")]
		/// <summary>Field : "Files" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValFeedbfile")]
		[Document("ValFeedbfile", true, false, false)]
		public string ValFeedbfile { get { return klass.ValFeedbfile; } set { klass.ValFeedbfile = value; } }
		public string ValFeedbfilefk { get { return klass.ValFeedbfilefk; } set { klass.ValFeedbfilefk = value; } }

		[DisplayName("USEFULFEEDB")]
		/// <summary>Field : "USEFULFEEDB" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValUsefulfeedb")]
		[DataArray("Usefulfeedb", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValUsefulfeedb { get { return klass.ValUsefulfeedb; } set { klass.ValUsefulfeedb = value; } }
		[JsonIgnore]
		public SelectList ArrayValusefulfeedb { get { return new SelectList(CSGenio.business.ArrayUsefulfeedb.GetDictionary(), "Key", "Value", ValUsefulfeedb); } set { ValUsefulfeedb = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("The information is hard to understand")]
		/// <summary>Field : "The information is hard to understand" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValLogicalfeedb")]
		public bool ValLogicalfeedb { get { return Convert.ToBoolean(klass.ValLogicalfeedb); } set { klass.ValLogicalfeedb = Convert.ToInt32(value); } }

		[DisplayName("Need more details")]
		/// <summary>Field : "Need more details" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValMoredetlogic")]
		public bool ValMoredetlogic { get { return Convert.ToBoolean(klass.ValMoredetlogic); } set { klass.ValMoredetlogic = Convert.ToInt32(value); } }

		[DisplayName("I can't find what I'm looking for")]
		/// <summary>Field : "I can't find what I'm looking for" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValLogicfeed")]
		public bool ValLogicfeed { get { return Convert.ToBoolean(klass.ValLogicfeed); } set { klass.ValLogicfeed = Convert.ToInt32(value); } }

		[DisplayName("I'd like to have more information in my language")]
		/// <summary>Field : "I'd like to have more information in my language" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Ufeedback.ValLanguagelogic")]
		public bool ValLanguagelogic { get { return Convert.ToBoolean(klass.ValLanguagelogic); } set { klass.ValLanguagelogic = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Ufeedback.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Ufeedback(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAufeedback(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Ufeedback(UserContext userContext, CSGenioAufeedback val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAufeedback csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "feedbacktype":
						_feedbacktype ??= new Feedbacktype(m_userContext, true, _fieldsToSerialize);
						_feedbacktype.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Ufeedback Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAufeedback>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Ufeedback(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Ufeedback> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAufeedback>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Ufeedback>((r) => new Ufeedback(userCtx, r));
		}

// USE /[MANUAL GQT MODEL UFEEDBACK]/
	}
}
