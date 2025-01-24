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
	public class Afini : ModelBase
	{
		[JsonIgnore]
		public CSGenioAafini klass { get { return baseklass as CSGenioAafini; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValCodafini")]
		public string ValCodafini { get { return klass.ValCodafini; } set { klass.ValCodafini = value; } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValIniafini")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValIniafini { get { return klass.ValIniafini; } set { klass.ValIniafini = value ?? DateTime.MinValue; } }

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValEndafini")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValEndafini { get { return klass.ValEndafini; } set { klass.ValEndafini = value ?? DateTime.MinValue; } }

		[DisplayName(">AFFINITY GENRE")]
		/// <summary>Field : ">AFFINITY GENRE" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValCodgafin")]
		public string ValCodgafin { get { return klass.ValCodgafin; } set { klass.ValCodgafin = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValCodpess2")]
		public string ValCodpess2 { get { return klass.ValCodpess2; } set { klass.ValCodpess2 = value; } }
		private Pess2 _pess2;
		[DisplayName("Pess2")]
		[ShouldSerialize("Pess2")]
		public virtual Pess2 Pess2 {
			get {
				if (!this.isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpess2) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpess2))))
					_pess2 = Models.Pess2.Find(ValCodpess2, m_userContext, Identifier, _fieldsToSerialize);
				if (_pess2 == null)
					_pess2 = new Models.Pess2(m_userContext, true, _fieldsToSerialize);
				return _pess2;
			}
			set { _pess2 = value; }
		}


		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Afini.ValCodpess1")]
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		[ShouldSerialize("Pess1")]
		public virtual Pess1 Pess1 {
			get {
				if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1))))
					_pess1 = Models.Pess1.Find(ValCodpess1, m_userContext, Identifier, _fieldsToSerialize);
				if (_pess1 == null)
					_pess1 = new Models.Pess1(m_userContext, true, _fieldsToSerialize);
				return _pess1;
			}
			set { _pess1 = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Afini.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Afini(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAafini(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Afini(UserContext userContext, CSGenioAafini val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAafini csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess2":
						if (_pess2 == null)
							_pess2 = new Pess2(m_userContext, true, _fieldsToSerialize);
						_pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(m_userContext, true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Afini Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAafini>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Afini(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Afini> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAafini>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Afini>((r) => new Afini(userCtx, r));
		}

// USE /[MANUAL GQT MODEL AFINI]/
	}
}
