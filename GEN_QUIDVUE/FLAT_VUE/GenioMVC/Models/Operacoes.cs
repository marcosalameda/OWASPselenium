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
	public class Operacoes : ModelBase
	{
		[JsonIgnore]
		public CSGenioAoperacoes klass { get { return baseklass as CSGenioAoperacoes; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValCodoperacoes")]
		public string ValCodoperacoes { get { return klass.ValCodoperacoes; } set { klass.ValCodoperacoes = value; } }

		[DisplayName("Entidade")]
		/// <summary>Field : "Entidade" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValCodentidade")]
		public string ValCodentidade { get { return klass.ValCodentidade; } set { klass.ValCodentidade = value; } }

		private Entidade _entidade;
		[DisplayName("Entidade")]
		[ShouldSerialize("Entidade")]
		public virtual Entidade Entidade
		{
			get
			{
				if (!isEmptyModel && (_entidade == null || (!string.IsNullOrEmpty(ValCodentidade) && (_entidade.isEmptyModel || _entidade.klass.QPrimaryKey != ValCodentidade))))
					_entidade = Models.Entidade.Find(ValCodentidade, m_userContext, Identifier, _fieldsToSerialize);
				_entidade ??= new Models.Entidade(m_userContext, true, _fieldsToSerialize);
				return _entidade;
			}
			set { _entidade = value; }
		}

		[DisplayName("Operação AA")]
		/// <summary>Field : "Operação AA" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValOperacao_aa")]
		public string ValOperacao_aa { get { return klass.ValOperacao_aa; } set { klass.ValOperacao_aa = value; } }

		[DisplayName("Pop abrangida")]
		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValPop_aa")]
		[NumericAttribute(0)]
		public decimal? ValPop_aa { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPop_aa, 0)); } set { klass.ValPop_aa = Convert.ToDecimal(value); } }

		[DisplayName("Operação AR")]
		/// <summary>Field : "Operação AR" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValOperacao_ar")]
		public string ValOperacao_ar { get { return klass.ValOperacao_ar; } set { klass.ValOperacao_ar = value; } }

		[DisplayName("Pop abrangida")]
		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValPop_ar")]
		[NumericAttribute(0)]
		public decimal? ValPop_ar { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPop_ar, 0)); } set { klass.ValPop_ar = Convert.ToDecimal(value); } }

		[DisplayName("Operação RU")]
		/// <summary>Field : "Operação RU" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValOperacao_ru")]
		public string ValOperacao_ru { get { return klass.ValOperacao_ru; } set { klass.ValOperacao_ru = value; } }

		[DisplayName("Pop abrangida")]
		/// <summary>Field : "Pop abrangida" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValPop_ru")]
		[NumericAttribute(0)]
		public decimal? ValPop_ru { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPop_ru, 0)); } set { klass.ValPop_ru = Convert.ToDecimal(value); } }

		[DisplayName("Sobreposição AA")]
		/// <summary>Field : "Sobreposição AA" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValSobreposicao_aa")]
		public bool ValSobreposicao_aa { get { return Convert.ToBoolean(klass.ValSobreposicao_aa); } set { klass.ValSobreposicao_aa = Convert.ToInt32(value); } }

		[DisplayName("Sobreposição AR")]
		/// <summary>Field : "Sobreposição AR" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValSobreposicao_ar")]
		public bool ValSobreposicao_ar { get { return Convert.ToBoolean(klass.ValSobreposicao_ar); } set { klass.ValSobreposicao_ar = Convert.ToInt32(value); } }

		[DisplayName("Sobreposição RU")]
		/// <summary>Field : "Sobreposição RU" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Operacoes.ValSobreposicao_ru")]
		public bool ValSobreposicao_ru { get { return Convert.ToBoolean(klass.ValSobreposicao_ru); } set { klass.ValSobreposicao_ru = Convert.ToInt32(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Operacoes.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Operacoes(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAoperacoes(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Operacoes(UserContext userContext, CSGenioAoperacoes val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAoperacoes csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entidade":
						_entidade ??= new Entidade(m_userContext, true, _fieldsToSerialize);
						_entidade.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Operacoes Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAoperacoes>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Operacoes(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Operacoes> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAoperacoes>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Operacoes>((r) => new Operacoes(userCtx, r));
		}

// USE /[MANUAL GQT MODEL OPERACOES]/
	}
}
