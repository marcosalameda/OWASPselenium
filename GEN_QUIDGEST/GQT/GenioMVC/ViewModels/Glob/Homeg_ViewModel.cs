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

namespace GenioMVC.ViewModels.Glob
{
	public class Homeg_ViewModel : FormViewModel<Models.Glob>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "" Tipo:"MO"</summary>
		[UIHint("tinymce")]
		[AllowHtml, Helpers.Attributes.HtmlSanitizer(isDocument: true)]
		public string ValHome { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodfacty { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodglob { get; set; }

		public Homeg_ViewModel() : base("FHOMEG") { }

		public Homeg_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FHOMEG", currentNavigation, nestedForm) { }

		public Homeg_ViewModel(Models.Glob row, NavigationContext currentNavigation, bool nestedForm = false) : base("FHOMEG", row, currentNavigation, nestedForm) { }

		public Homeg_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("glob", id);
			Model = Models.Glob.Find(id, "FHOMEG", fieldsToQuery: fieldsToLoad);
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
			Models.Glob model = new Models.Glob() { Identifier = "FHOMEG" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Glob model)
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

		public static StatusMessage DeleteConditions(Models.Glob model)
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

		public static StatusMessage ViewConditions(Models.Glob model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Glob model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Homeg) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValHome = ViewModelConversion.ToString(m.ValHome);
 				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
 				ValCodglob = ViewModelConversion.ToString(m.ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Homeg) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Homeg) to Model (Glob) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValHome = ViewModelConversion.ToString(ValHome);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValCodglob = ViewModelConversion.ToString(ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Homeg) to Model (Glob) - Error during mapping");
				throw;
			}
		}

		#endregion

		public void LoadGlob()
		{
			LoadGlob(new NameValueCollection(), false, false);
		}

		public override void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false)
		{
			this.editable = editable;

			Model = Models.Glob.GetGlob(true);

			if (Model == null)
				throw new ModelNotFoundException("Model not found");

			InitModel(qs);
		}


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FHOMEG");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Glob() { Identifier = "FHOMEG" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
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

			Model.Identifier = "FHOMEG";
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

		protected override void LoadDocumentsProperties(Models.Glob row)
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
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FHOMEG");
				if (Model == null)
				{
					Model = new Models.Glob() { Identifier = "FHOMEG" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL HOMEG]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW HOMEG]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE HOMEG]/
		public override void Save()
		{

			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FHOMEG"); }
			finally { if (Model == null) Model = new Models.Glob() { Identifier = "FHOMEG" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY HOMEG]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), "FHOMEG"); }
			finally { if (Model == null) Model = new Models.Glob() { Identifier = "FHOMEG" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE HOMEG]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY HOMEG]/
		public override void Destroy(string id)
		{
			Model = Models.Glob.Find(id, "FHOMEG");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}




		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValHome = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValHome, true);
		}

		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM HOMEG]/
		#endregion
	}
}
