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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Speci
{
	public class Espec_ViewModel : FormViewModel<Models.Speci>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Specialty" Tipo:"C"</summary>
		[Display(Name = "SPECIALTY09304", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEspecial { get; set; }

		/// <summary>Campo : "Technical  area" Tipo:"AC"</summary>
		[Display(Name = "TECHNICAL__AREA15929", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAreatecn { get; set; }
		[JsonIgnore]
		public SelectList List_ValAreatecn { get; set; }


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

		public string ValCodespec { get; set; }

		public Espec_ViewModel() : base("FESPEC") { }

		public Espec_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FESPEC", currentNavigation, nestedForm) { }

		public Espec_ViewModel(Models.Speci row, NavigationContext currentNavigation, bool nestedForm = false) : base("FESPEC", row, currentNavigation, nestedForm) { }

		public Espec_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("speci", id);
			Model = Models.Speci.Find(id, "FESPEC", fieldsToQuery: fieldsToLoad);
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
			Models.Speci model = new Models.Speci() { Identifier = "FESPEC" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Speci model)
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

		public static StatusMessage DeleteConditions(Models.Speci model)
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

		public static StatusMessage ViewConditions(Models.Speci model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Speci model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Speci m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Speci) to ViewModel (Espec) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValEspecial = ViewModelConversion.ToString(m.ValEspecial);
 				ValAreatecn = ViewModelConversion.ToString(m.ValAreatecn);
 				ValCodespec = ViewModelConversion.ToString(m.ValCodespec);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Speci) to ViewModel (Espec) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Speci m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Espec) to Model (Speci) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValEspecial = ViewModelConversion.ToString(ValEspecial);
				m.ValAreatecn = ViewModelConversion.ToString(ValAreatecn);
				m.ValCodespec = ViewModelConversion.ToString(ValCodespec);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Espec) to Model (Speci) - Error during mapping");
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
				Model = Models.Speci.Find(Navigation.GetStrValue("speci"), "FESPEC");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Speci() { Identifier = "FESPEC" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("speci");
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

			Model.Identifier = "FESPEC";
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

		protected override void LoadDocumentsProperties(Models.Speci row)
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
				Model = Models.Speci.Find(Navigation.GetStrValue("speci"), "FESPEC");
				if (Model == null)
				{
					Model = new Models.Speci() { Identifier = "FESPEC" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("speci");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ESPEC]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ESPEC]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ESPEC]/
		public override void Save()
		{

			try { Model = Models.Speci.Find(Navigation.GetStrValue("speci"), "FESPEC"); }
			finally { if (Model == null) Model = new Models.Speci() { Identifier = "FESPEC" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ESPEC]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Speci.Find(Navigation.GetStrValue("speci"), "FESPEC"); }
			finally { if (Model == null) Model = new Models.Speci() { Identifier = "FESPEC" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ESPEC]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ESPEC]/
		public override void Destroy(string id)
		{
			Model = Models.Speci.Find(id, "FESPEC");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValAreatecn = new SelectList(
				ArrayAreatecn.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValAreatecn);
		}



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ESPEC]/
		#endregion
	}
}
