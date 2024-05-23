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

namespace GenioMVC.ViewModels.Cfaqs
{
	public class Cfaqs_ViewModel : FormViewModel<Models.Cfaqs>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Icon" Tipo:"IJ"</summary>
		[Display(Name = "ICON41974", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 480, 10, false, true)]
		public byte[] ValIcon { get; set; }

		/// <summary>Campo : "Category" Tipo:"MO"</summary>
		[Display(Name = "CATEGORY18978", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValCategory { get; set; }

		/// <summary>Campo : "Description" Tipo:"MO"</summary>
		[Display(Name = "DESCRIPTION07383", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get; set; }

		/// <summary>Campo : "FAQS" Tipo:"DP"</summary>
		[Display(Name = "FAQS53959", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Faqs> ValExpfaqs { get; set; }


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

		public string ValCodcfaqs { get; set; }

		public Cfaqs_ViewModel() : base("FCFAQS") { }

		public Cfaqs_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FCFAQS", currentNavigation, nestedForm) { }

		public Cfaqs_ViewModel(Models.Cfaqs row, NavigationContext currentNavigation, bool nestedForm = false) : base("FCFAQS", row, currentNavigation, nestedForm) { }

		public Cfaqs_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("cfaqs", id);
			Model = Models.Cfaqs.Find(id, "FCFAQS", fieldsToQuery: fieldsToLoad);
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
			Models.Cfaqs model = new Models.Cfaqs() { Identifier = "FCFAQS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Cfaqs model)
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

		public static StatusMessage DeleteConditions(Models.Cfaqs model)
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

		public static StatusMessage ViewConditions(Models.Cfaqs model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Cfaqs model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Cfaqs m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cfaqs) to ViewModel (Cfaqs) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValIcon = ViewModelConversion.ToImage(m.ValIcon);
 				ValCategory = ViewModelConversion.ToString(m.ValCategory);
 				ValDescript = ViewModelConversion.ToString(m.ValDescript);
 				ValCodcfaqs = ViewModelConversion.ToString(m.ValCodcfaqs);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cfaqs) to ViewModel (Cfaqs) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Cfaqs m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cfaqs) to Model (Cfaqs) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCategory = ViewModelConversion.ToString(ValCategory);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValCodcfaqs = ViewModelConversion.ToString(ValCodcfaqs);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Cfaqs) to Model (Cfaqs) - Error during mapping");
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
				Model = Models.Cfaqs.Find(Navigation.GetStrValue("cfaqs"), "FCFAQS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Cfaqs() { Identifier = "FCFAQS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("cfaqs");
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

			Model.Identifier = "FCFAQS";
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

		protected override void LoadDocumentsProperties(Models.Cfaqs row)
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
				Model = Models.Cfaqs.Find(Navigation.GetStrValue("cfaqs"), "FCFAQS");
				if (Model == null)
				{
					Model = new Models.Cfaqs() { Identifier = "FCFAQS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cfaqs");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CFAQS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CFAQS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE CFAQS]/
		public override void Save()
		{

			try { Model = Models.Cfaqs.Find(Navigation.GetStrValue("cfaqs"), "FCFAQS"); }
			finally { if (Model == null) Model = new Models.Cfaqs() { Identifier = "FCFAQS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CFAQS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Cfaqs.Find(Navigation.GetStrValue("cfaqs"), "FCFAQS"); }
			finally { if (Model == null) Model = new Models.Cfaqs() { Identifier = "FCFAQS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CFAQS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CFAQS]/
		public override void Destroy(string id)
		{
			Model = Models.Cfaqs.Find(id, "FCFAQS");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM CFAQS]/
		#endregion
	}
}
