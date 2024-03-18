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

namespace GenioMVC.ViewModels.Oudoc
{
	public class Docsd_ViewModel : FormViewModel<Models.Oudoc>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Number:" Tipo:"N"</summary>
		[Display(Name = "NUMBER_64178", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValNrdocsda { get; set; }

		/// <summary>Campo : "Date:" Tipo:"DT"</summary>
		[Display(Name = "DATE_55218", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtdocsda { get; set; }

		/// <summary>Campo : "Title" Tipo:"C"</summary>
		[Display(Name = "TITLE21885", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTitle { get; set; }


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

		public string ValCoddocsd { get; set; }

		public Docsd_ViewModel() : base("FDOCSD") { }

		public Docsd_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FDOCSD", currentNavigation, nestedForm) { }

		public Docsd_ViewModel(Models.Oudoc row, NavigationContext currentNavigation, bool nestedForm = false) : base("FDOCSD", row, currentNavigation, nestedForm) { }

		public Docsd_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("oudoc", id);
			Model = Models.Oudoc.Find(id, "FDOCSD", fieldsToQuery: fieldsToLoad);
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
			Models.Oudoc model = new Models.Oudoc() { Identifier = "FDOCSD" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Oudoc model)
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

		public static StatusMessage DeleteConditions(Models.Oudoc model)
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

		public static StatusMessage ViewConditions(Models.Oudoc model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Oudoc model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Oudoc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Oudoc) to ViewModel (Docsd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValNrdocsda = ViewModelConversion.ToNumeric(m.ValNrdocsda);
 				ValDtdocsda = ViewModelConversion.ToDateTime(m.ValDtdocsda);
 				ValTitle = ViewModelConversion.ToString(m.ValTitle);
 				ValCoddocsd = ViewModelConversion.ToString(m.ValCoddocsd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Oudoc) to ViewModel (Docsd) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Oudoc m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Docsd) to Model (Oudoc) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValNrdocsda = ViewModelConversion.ToNumeric(ValNrdocsda);
				m.ValDtdocsda = ViewModelConversion.ToDateTime(ValDtdocsda);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValCoddocsd = ViewModelConversion.ToString(ValCoddocsd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Docsd) to Model (Oudoc) - Error during mapping");
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
				Model = Models.Oudoc.Find(Navigation.GetStrValue("oudoc"), "FDOCSD");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Oudoc() { Identifier = "FDOCSD" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("oudoc");
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

			Model.Identifier = "FDOCSD";
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

		protected override void LoadDocumentsProperties(Models.Oudoc row)
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
				Model = Models.Oudoc.Find(Navigation.GetStrValue("oudoc"), "FDOCSD");
				if (Model == null)
				{
					Model = new Models.Oudoc() { Identifier = "FDOCSD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("oudoc");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL DOCSD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW DOCSD]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE DOCSD]/
		public override void Save()
		{

			try { Model = Models.Oudoc.Find(Navigation.GetStrValue("oudoc"), "FDOCSD"); }
			finally { if (Model == null) Model = new Models.Oudoc() { Identifier = "FDOCSD" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY DOCSD]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Oudoc.Find(Navigation.GetStrValue("oudoc"), "FDOCSD"); }
			finally { if (Model == null) Model = new Models.Oudoc() { Identifier = "FDOCSD" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE DOCSD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY DOCSD]/
		public override void Destroy(string id)
		{
			Model = Models.Oudoc.Find(id, "FDOCSD");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM DOCSD]/
		#endregion
	}
}
