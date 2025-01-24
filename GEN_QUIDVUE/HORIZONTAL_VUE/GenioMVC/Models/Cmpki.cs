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
	public class Cmpki : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcmpki klass { get { return baseklass as CSGenioAcmpki; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValCodcmpki")]
		public string ValCodcmpki { get { return klass.ValCodcmpki; } set { klass.ValCodcmpki = value; } }

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValCodtpequ")]
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		private Tpequ _tpequ;
		[DisplayName("Tpequ")]
		[ShouldSerialize("Tpequ")]
		public virtual Tpequ Tpequ {
			get {
				if (!this.isEmptyModel && (_tpequ == null || (!string.IsNullOrEmpty(ValCodtpequ) && (_tpequ.isEmptyModel || _tpequ.klass.QPrimaryKey != ValCodtpequ))))
					_tpequ = Models.Tpequ.Find(ValCodtpequ, m_userContext, Identifier, _fieldsToSerialize);
				if (_tpequ == null)
					_tpequ = new Models.Tpequ(m_userContext, true, _fieldsToSerialize);
				return _tpequ;
			}
			set { _tpequ = value; }
		}


		[DisplayName("Order")]
		/// <summary>Field : "Order" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValOrder")]
		[NumericAttribute(1)]
		public decimal? ValOrder { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOrder, 1)); } set { klass.ValOrder = Convert.ToDecimal(value); } }

		[DisplayName("TYPE OF COMPONENT EQUIPMENT")]
		/// <summary>Field : "TYPE OF COMPONENT EQUIPMENT" Tipo: "CE" Formula: DF "[CMPKI->CODTPEQU]"</summary>
		[ShouldSerialize("Cmpki.ValCodtpeq1")]
		public string ValCodtpeq1 { get { return klass.ValCodtpeq1; } set { klass.ValCodtpeq1 = value; } }
		private Tpeq1 _tpeq1;
		[DisplayName("Tpeq1")]
		[ShouldSerialize("Tpeq1")]
		public virtual Tpeq1 Tpeq1 {
			get {
				if (!this.isEmptyModel && (_tpeq1 == null || (!string.IsNullOrEmpty(ValCodtpeq1) && (_tpeq1.isEmptyModel || _tpeq1.klass.QPrimaryKey != ValCodtpeq1))))
					_tpeq1 = Models.Tpeq1.Find(ValCodtpeq1, m_userContext, Identifier, _fieldsToSerialize);
				if (_tpeq1 == null)
					_tpeq1 = new Models.Tpeq1(m_userContext, true, _fieldsToSerialize);
				return _tpeq1;
			}
			set { _tpeq1 = value; }
		}


		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValQuantida")]
		[NumericAttribute(0)]
		public decimal? ValQuantida { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQuantida, 0)); } set { klass.ValQuantida = Convert.ToDecimal(value); } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValCode")]
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }

		[DisplayName("Site")]
		/// <summary>Field : "Site" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cmpki.ValUrl")]
		[HyperLink]
		public string ValUrl { get { return klass.ValUrl; } set { klass.ValUrl = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cmpki.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cmpki(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcmpki(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Cmpki(UserContext userContext, CSGenioAcmpki val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAcmpki csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "tpequ":
						if (_tpequ == null)
							_tpequ = new Tpequ(m_userContext, true, _fieldsToSerialize);
						_tpequ.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpeq1":
						if (_tpeq1 == null)
							_tpeq1 = new Tpeq1(m_userContext, true, _fieldsToSerialize);
						_tpeq1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cmpki Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcmpki>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cmpki(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cmpki> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcmpki>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cmpki>((r) => new Cmpki(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CMPKI]/
	}
}
