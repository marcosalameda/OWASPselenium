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

namespace GenioMVC.ViewModels.Faqs
{
	public class Faqs_ViewModel : FormViewModel<Models.Faqs>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Question" Tipo:"MO"</summary>
		[Display(Name = "QUESTION00194", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValQuestion { get; set; }

		/// <summary>Campo : "Answer" Tipo:"MO"</summary>
		[Display(Name = "ANSWER22961", ResourceType = typeof(Resources.Resources))]
		[UIHint("tinymce")]
		[AllowHtml, Helpers.Attributes.HtmlSanitizer(isDocument: true)]
		public string ValAnswer { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodcfaqs { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodfaqs { get; set; }

		public Faqs_ViewModel() : base("FFAQS") { }

		public Faqs_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFAQS", currentNavigation, nestedForm) { }

		public Faqs_ViewModel(Models.Faqs row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFAQS", row, currentNavigation, nestedForm) { }

		public Faqs_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("faqs", id);
			Model = Models.Faqs.Find(id, "FFAQS", fieldsToQuery: fieldsToLoad);
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
			Models.Faqs model = new Models.Faqs() { Identifier = "FFAQS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Faqs model)
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

		public static StatusMessage DeleteConditions(Models.Faqs model)
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

		public static StatusMessage ViewConditions(Models.Faqs model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Faqs model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Faqs m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Faqs) to ViewModel (Faqs) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValQuestion = ViewModelConversion.ToString(m.ValQuestion);
 				ValAnswer = ViewModelConversion.ToString(m.ValAnswer);
 				ValCodcfaqs = ViewModelConversion.ToString(m.ValCodcfaqs);
 				ValCodfaqs = ViewModelConversion.ToString(m.ValCodfaqs);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Faqs) to ViewModel (Faqs) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Faqs m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Faqs) to Model (Faqs) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValQuestion = ViewModelConversion.ToString(ValQuestion);
				m.ValAnswer = ViewModelConversion.ToString(ValAnswer);
				m.ValCodcfaqs = ViewModelConversion.ToString(ValCodcfaqs);
				m.ValCodfaqs = ViewModelConversion.ToString(ValCodfaqs);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Faqs) to Model (Faqs) - Error during mapping");
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
				Model = Models.Faqs.Find(Navigation.GetStrValue("faqs"), "FFAQS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Faqs() { Identifier = "FFAQS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("faqs");
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

			Model.Identifier = "FFAQS";
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

		protected override void LoadDocumentsProperties(Models.Faqs row)
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
				Model = Models.Faqs.Find(Navigation.GetStrValue("faqs"), "FFAQS");
				if (Model == null)
				{
					Model = new Models.Faqs() { Identifier = "FFAQS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("faqs");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FAQS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FAQS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FAQS]/
		public override void Save()
		{

			try { Model = Models.Faqs.Find(Navigation.GetStrValue("faqs"), "FFAQS"); }
			finally { if (Model == null) Model = new Models.Faqs() { Identifier = "FFAQS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FAQS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Faqs.Find(Navigation.GetStrValue("faqs"), "FFAQS"); }
			finally { if (Model == null) Model = new Models.Faqs() { Identifier = "FFAQS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FAQS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FAQS]/
		public override void Destroy(string id)
		{
			Model = Models.Faqs.Find(id, "FFAQS");
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
			ValAnswer = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValAnswer, true);
		}

		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FAQS]/
		#endregion
	}
}
