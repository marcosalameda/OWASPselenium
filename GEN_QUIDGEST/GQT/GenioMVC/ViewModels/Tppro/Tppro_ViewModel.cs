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

namespace GenioMVC.ViewModels.Tppro
{
	public class Tppro_ViewModel : FormViewModel<Models.Tppro>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Property type" Tipo:"C"</summary>
		[Display(Name = "PROPERTY_TYPE51419", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTppropri { get; set; }


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

		public string ValCodtppro { get; set; }

		public Tppro_ViewModel() : base("FTPPRO") { }

		public Tppro_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FTPPRO", currentNavigation, nestedForm) { }

		public Tppro_ViewModel(Models.Tppro row, NavigationContext currentNavigation, bool nestedForm = false) : base("FTPPRO", row, currentNavigation, nestedForm) { }

		public Tppro_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("tppro", id);
			Model = Models.Tppro.Find(id, "FTPPRO", fieldsToQuery: fieldsToLoad);
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
			Models.Tppro model = new Models.Tppro() { Identifier = "FTPPRO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Tppro model)
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

		public static StatusMessage DeleteConditions(Models.Tppro model)
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

		public static StatusMessage ViewConditions(Models.Tppro model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Tppro model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tppro m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tppro) to ViewModel (Tppro) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValTppropri = ViewModelConversion.ToString(m.ValTppropri);
 				ValCodtppro = ViewModelConversion.ToString(m.ValCodtppro);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tppro) to ViewModel (Tppro) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Tppro m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tppro) to Model (Tppro) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValTppropri = ViewModelConversion.ToString(ValTppropri);
				m.ValCodtppro = ViewModelConversion.ToString(ValCodtppro);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tppro) to Model (Tppro) - Error during mapping");
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
				Model = Models.Tppro.Find(Navigation.GetStrValue("tppro"), "FTPPRO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Tppro() { Identifier = "FTPPRO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("tppro");
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

			Model.Identifier = "FTPPRO";
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

		protected override void LoadDocumentsProperties(Models.Tppro row)
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
				Model = Models.Tppro.Find(Navigation.GetStrValue("tppro"), "FTPPRO");
				if (Model == null)
				{
					Model = new Models.Tppro() { Identifier = "FTPPRO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tppro");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TPPRO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TPPRO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE TPPRO]/
		public override void Save()
		{

			try { Model = Models.Tppro.Find(Navigation.GetStrValue("tppro"), "FTPPRO"); }
			finally { if (Model == null) Model = new Models.Tppro() { Identifier = "FTPPRO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TPPRO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Tppro.Find(Navigation.GetStrValue("tppro"), "FTPPRO"); }
			finally { if (Model == null) Model = new Models.Tppro() { Identifier = "FTPPRO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TPPRO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TPPRO]/
		public override void Destroy(string id)
		{
			Model = Models.Tppro.Find(id, "FTPPRO");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM TPPRO]/
		#endregion
	}
}
