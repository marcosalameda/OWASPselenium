using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Pedid
{
	public class Pedid_ViewModel : FormViewModel<Models.Pedid>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Date:" Tipo:"D"</summary>
		[Display(Name = "DATE_55218", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDtpedido { get; set; }

		/// <summary>Campo : "Number" Tipo:"N"</summary>
		[Display(Name = "NUMBER35625", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNrpedido { get; set; }

		/// <summary>Campo : "Motive:" Tipo:"MO"</summary>
		[Display(Name = "MOTIVE_64781", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValMotivo { get; set; }

		/// <summary>Campo : "Lines" Tipo:"DP"</summary>
		[Display(Name = "LINES35526", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Lnhpd> ValLinhas { get; set; }

		/// <summary>Campo : "Breakdown:" Tipo:"DP"</summary>
		[Display(Name = "BREAKDOWN_60448", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Lnhde> ValDesagreg { get; set; }

		/// <summary>Campo : "Grouping of Equipment Types" Tipo:"DP"</summary>
		[Display(Name = "GROUPING_OF_EQUIPMEN34190", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Lnhag> ValAgrupame { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodpedid { get; set; }

		public Pedid_ViewModel() : base("FPEDID") { }

		public Pedid_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPEDID", currentNavigation, nestedForm) { }

		public Pedid_ViewModel(Models.Pedid row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPEDID", row, currentNavigation, nestedForm) { }

		public Pedid_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("pedid", id);
			Model = Models.Pedid.Find(id, "FPEDID", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Pedid model = new Models.Pedid() { Identifier = "FPEDID" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Pedid model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			return DeleteConditions(Model);
		}

		public static StatusMessage DeleteConditions(Models.Pedid model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			return ViewConditions(Model);
		}

		public static StatusMessage ViewConditions(Models.Pedid model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Pedid model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Pedid m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Pedid) to ViewModel (Pedid) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDtpedido = ViewModelConversion.ToDateTime(m.ValDtpedido);
 				ValNrpedido = ViewModelConversion.ToNumeric(m.ValNrpedido);
 				ValMotivo = ViewModelConversion.ToString(m.ValMotivo);
 				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Pedid) to ViewModel (Pedid) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Pedid m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pedid) to Model (Pedid) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDtpedido = ViewModelConversion.ToDateTime(ValDtpedido);
				m.ValNrpedido = ViewModelConversion.ToNumeric(ValNrpedido);
				m.ValMotivo = ViewModelConversion.ToString(ValMotivo);
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pedid) to Model (Pedid) - Error during mapping");
				throw;
			}
		}

		#endregion


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Pedid.Find(Navigation.GetStrValue("pedid"), "FPEDID");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Pedid() { Identifier = "FPEDID" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("pedid");
					}

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FPEDID";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Pedid row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Pedid.Find(Navigation.GetStrValue("pedid"), "FPEDID");
				if (Model == null)
				{
					Model = new Models.Pedid() { Identifier = "FPEDID" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("pedid");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PEDID]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PEDID]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PEDID]/
		public override void Save()
		{

			try { Model = Models.Pedid.Find(Navigation.GetStrValue("pedid"), "FPEDID"); }
			finally { if (Model == null) Model = new Models.Pedid() { Identifier = "FPEDID" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PEDID]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Pedid.Find(Navigation.GetStrValue("pedid"), "FPEDID"); }
			finally { if (Model == null) Model = new Models.Pedid() { Identifier = "FPEDID" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PEDID]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PEDID]/
		public override void Destroy(string id)
		{
			Model = Models.Pedid.Find(id, "FPEDID");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PEDID]/
		#endregion
	}
}
