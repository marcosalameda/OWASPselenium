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

namespace GenioMVC.ViewModels.Wareh
{
	public class Armaz03_ViewModel : FormViewModel<Models.Wareh>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Catalog articles" Tipo:"DP"</summary>
		[Display(Name = "CATALOG_ARTICLES06740", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Item> ValArtigos { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Warehouse" Tipo: "C"</summary>
		[AllowHtml]
		public string ValWarehdes { get; set; }
		#endregion

		public string ValCodwareh { get; set; }

		public Armaz03_ViewModel() : base("FARMAZ03") { }

		public Armaz03_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FARMAZ03", currentNavigation, nestedForm) { }

		public Armaz03_ViewModel(Models.Wareh row, NavigationContext currentNavigation, bool nestedForm = false) : base("FARMAZ03", row, currentNavigation, nestedForm) { }

		public Armaz03_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("wareh", id);
			Model = Models.Wareh.Find(id, "FARMAZ03", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Wareh model = new Models.Wareh() { Identifier = "FARMAZ03" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Wareh model)
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

		public static StatusMessage DeleteConditions(Models.Wareh model)
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

		public static StatusMessage ViewConditions(Models.Wareh model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Wareh model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Wareh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Wareh) to ViewModel (Armaz03) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValWarehdes = ViewModelConversion.ToString(m.ValWarehdes);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Wareh) to ViewModel (Armaz03) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Wareh m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Armaz03) to Model (Wareh) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValWarehdes = ViewModelConversion.ToString(ValWarehdes);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Armaz03) to Model (Wareh) - Error during mapping");
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
				Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), "FARMAZ03");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Wareh() { Identifier = "FARMAZ03" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");
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

			Model.Identifier = "FARMAZ03";
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

		protected override void LoadDocumentsProperties(Models.Wareh row)
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
				Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), "FARMAZ03");
				if (Model == null)
				{
					Model = new Models.Wareh() { Identifier = "FARMAZ03" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARMAZ03]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARMAZ03]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ARMAZ03]/
		public override void Save()
		{

			try { Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), "FARMAZ03"); }
			finally { if (Model == null) Model = new Models.Wareh() { Identifier = "FARMAZ03" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARMAZ03]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Wareh.Find(Navigation.GetStrValue("wareh"), "FARMAZ03"); }
			finally { if (Model == null) Model = new Models.Wareh() { Identifier = "FARMAZ03" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARMAZ03]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARMAZ03]/
		public override void Destroy(string id)
		{
			Model = Models.Wareh.Find(id, "FARMAZ03");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARMAZ03]/
		#endregion
	}
}
