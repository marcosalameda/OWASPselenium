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
	public class Entidade : ModelBase
	{
		[JsonIgnore]
		public CSGenioAentidade klass { get { return baseklass as CSGenioAentidade; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValCodentidade")]
		public string ValCodentidade { get { return klass.ValCodentidade; } set { klass.ValCodentidade = value; } }

		[DisplayName("Concelho")]
		/// <summary>Field : "Concelho" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValCodconcelho")]
		public string ValCodconcelho { get { return klass.ValCodconcelho; } set { klass.ValCodconcelho = value; } }

		private Concelho _concelho;
		[DisplayName("Concelho")]
		[ShouldSerialize("Concelho")]
		public virtual Concelho Concelho
		{
			get
			{
				if (!isEmptyModel && (_concelho == null || (!string.IsNullOrEmpty(ValCodconcelho) && (_concelho.isEmptyModel || _concelho.klass.QPrimaryKey != ValCodconcelho))))
					_concelho = Models.Concelho.Find(ValCodconcelho, m_userContext, Identifier, _fieldsToSerialize);
				_concelho ??= new Models.Concelho(m_userContext, true, _fieldsToSerialize);
				return _concelho;
			}
			set { _concelho = value; }
		}

		[DisplayName("ID Entidade")]
		/// <summary>Field : "ID Entidade" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValId_entidade")]
		[NumericAttribute(0)]
		public decimal? ValId_entidade { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValId_entidade, 0)); } set { klass.ValId_entidade = Convert.ToDecimal(value); } }

		[DisplayName("Entidade")]
		/// <summary>Field : "Entidade" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValEntidade")]
		public string ValEntidade { get { return klass.ValEntidade; } set { klass.ValEntidade = value; } }

		[DisplayName("Submodelo de gestão")]
		/// <summary>Field : "Submodelo de gestão" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValSub_modelo_gestao")]
		public string ValSub_modelo_gestao { get { return klass.ValSub_modelo_gestao; } set { klass.ValSub_modelo_gestao = value; } }

		[DisplayName("Sistema contabilístico")]
		/// <summary>Field : "Sistema contabilístico" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Entidade.ValSistema_contabilistico")]
		[DataArray("Sistema_contabilistico", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSistema_contabilistico { get { return klass.ValSistema_contabilistico; } set { klass.ValSistema_contabilistico = value; } }
		[JsonIgnore]
		public SelectList ArrayValsistema_contabilistico { get { return new SelectList(CSGenio.business.ArraySistema_contabilistico.GetDictionary(), "Key", "Value", ValSistema_contabilistico); } set { ValSistema_contabilistico = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Entidade.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Entidade(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAentidade(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Entidade(UserContext userContext, CSGenioAentidade val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAentidade csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "concelho":
						_concelho ??= new Concelho(m_userContext, true, _fieldsToSerialize);
						_concelho.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Entidade Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAentidade>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Entidade(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Entidade> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAentidade>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Entidade>((r) => new Entidade(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ENTIDADE]/
	}
}
