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

namespace GenioMVC.ViewModels.Kinde
{
	public class Kinde_ViewModel : FormViewModel<Models.Kinde>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Kind of equipment" Tipo:"C"</summary>
		[Display(Name = "KIND_OF_EQUIPMENT22928", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }

		/// <summary>Campo : "Parameters" Tipo:"DP"</summary>
		[Display(Name = "PARAMETERS28294", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Param> ValParamete { get; set; }

		/// <summary>Campo : "Manuals" Tipo:"DP"</summary>
		[Display(Name = "MANUALS14730", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Manua> ValManuals { get; set; }


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

		public string ValCodkinde { get; set; }

		public Kinde_ViewModel() : base("FKINDE") { }

		public Kinde_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FKINDE", currentNavigation, nestedForm) { }

		public Kinde_ViewModel(Models.Kinde row, NavigationContext currentNavigation, bool nestedForm = false) : base("FKINDE", row, currentNavigation, nestedForm) { }

		public Kinde_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("kinde", id);
			Model = Models.Kinde.Find(id, "FKINDE", fieldsToQuery: fieldsToLoad);
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
			Models.Kinde model = new Models.Kinde() { Identifier = "FKINDE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Kinde model)
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

		public static StatusMessage DeleteConditions(Models.Kinde model)
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

		public static StatusMessage ViewConditions(Models.Kinde model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Kinde model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Kinde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Kinde) to ViewModel (Kinde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Kinde) to ViewModel (Kinde) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Kinde m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Kinde) to Model (Kinde) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Kinde) to Model (Kinde) - Error during mapping");
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
				Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), "FKINDE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Kinde() { Identifier = "FKINDE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("kinde");
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

			Model.Identifier = "FKINDE";
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

		protected override void LoadDocumentsProperties(Models.Kinde row)
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
				Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), "FKINDE");
				if (Model == null)
				{
					Model = new Models.Kinde() { Identifier = "FKINDE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("kinde");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL KINDE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW KINDE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE KINDE]/
		public override void Save()
		{

			try { Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), "FKINDE"); }
			finally { if (Model == null) Model = new Models.Kinde() { Identifier = "FKINDE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY KINDE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Kinde.Find(Navigation.GetStrValue("kinde"), "FKINDE"); }
			finally { if (Model == null) Model = new Models.Kinde() { Identifier = "FKINDE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE KINDE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY KINDE]/
		public override void Destroy(string id)
		{
			Model = Models.Kinde.Find(id, "FKINDE");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM KINDE]/
		#endregion
	}
}
