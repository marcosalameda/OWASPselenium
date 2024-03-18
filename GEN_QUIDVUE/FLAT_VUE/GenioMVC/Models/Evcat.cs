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
	public class Evcat : ModelBase
	{
		[JsonIgnore]
		public CSGenioAevcat klass { get { return baseklass as CSGenioAevcat; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValCodprogr")]
		public string ValCodprogr { get { return klass.ValCodprogr; } set { klass.ValCodprogr = value; } }

		[DisplayName(">PERSON")]
		/// <summary>Field : ">PERSON" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		private Pesso _pesso;
		[DisplayName("Pesso")]
		[ShouldSerialize("Pesso")]
		public virtual Pesso Pesso { 
			get { 
				if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso))))
					_pesso = Models.Pesso.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				if (_pesso == null)
					_pesso = new Models.Pesso(m_userContext, true, _fieldsToSerialize);
				return _pesso;
			}
			set { _pesso = value; } 
		}
		

		[DisplayName(">CATEGORy")]
		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValCodcateg")]
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		private Cate1 _cate1;
		[DisplayName("Cate1")]
		[ShouldSerialize("Cate1")]
		public virtual Cate1 Cate1 { 
			get { 
				if (!this.isEmptyModel && (_cate1 == null || (!string.IsNullOrEmpty(ValCodcateg) && (_cate1.isEmptyModel || _cate1.klass.QPrimaryKey != ValCodcateg))))
					_cate1 = Models.Cate1.Find(ValCodcateg, m_userContext, Identifier, _fieldsToSerialize);
				if (_cate1 == null)
					_cate1 = new Models.Cate1(m_userContext, true, _fieldsToSerialize);
				return _cate1;
			}
			set { _cate1 = value; } 
		}
		

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValSince")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }

		[DisplayName("Up manual")]
		/// <summary>Field : "Up manual" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValUntilman")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValUntilman { get { return klass.ValUntilman; } set { klass.ValUntilman = value ?? DateTime.MinValue; } }

		[DisplayName("Until")]
		/// <summary>Field : "Until" Tipo: "D" Formula: FP "[EVCAT->SINCE][EVCAT->CODPESSO]"</summary>
		[ShouldSerialize("Evcat.ValUntil")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValUntil { get { return klass.ValUntil; } set { klass.ValUntil = value ?? DateTime.MinValue; } }

		[DisplayName("Observation")]
		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Evcat.ValObservat")]
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }

		[DisplayName("End-of-period")]
		/// <summary>Field : "End-of-period" Tipo: "D" Formula: + "iif(emptyD([EVCAT->UNTILMAN])==0,[EVCAT->UNTILMAN],[EVCAT->UNTIL])"</summary>
		[ShouldSerialize("Evcat.ValFimperio")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFimperio { get { return klass.ValFimperio; } set { klass.ValFimperio = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Evcat.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Evcat(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAevcat(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Evcat(UserContext userContext, CSGenioAevcat val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAevcat csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cate1":
						if (_cate1 == null)
							_cate1 = new Cate1(m_userContext, true, _fieldsToSerialize);
						_cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Evcat Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAevcat>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Evcat(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Evcat> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAevcat>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Evcat>((r) => new Evcat(userCtx, r));
		}

// USE /[MANUAL GQT MODEL EVCAT]/
	}
}
