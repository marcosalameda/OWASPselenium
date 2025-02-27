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

namespace GenioMVC.ViewModels.Feeca
{
	public class Fldscondpseudgridtbl__ViewModel : GridTableListRowViewModel<Models.Feeca>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Feedback" Tipo:"C"</summary>
		[Display(Name = "FEEDBACK52855", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValFeedback { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodflds { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodfeeca { get; set; }

		public Fldscondpseudgridtbl__ViewModel() : base("FFLDSCONDPSEUDGRIDTBL_") { }

		public Fldscondpseudgridtbl__ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FFLDSCONDPSEUDGRIDTBL_", currentNavigation, nestedForm) { }

		public Fldscondpseudgridtbl__ViewModel(Models.Feeca row, NavigationContext currentNavigation, bool nestedForm = false) : base("FFLDSCONDPSEUDGRIDTBL_", row, currentNavigation, nestedForm) { }

		public Fldscondpseudgridtbl__ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("feeca", id);
			Model = Models.Feeca.Find(id, "FFLDSCONDPSEUDGRIDTBL_", fieldsToQuery: fieldsToLoad);
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
			Models.Feeca model = new Models.Feeca() { Identifier = "FFLDSCONDPSEUDGRIDTBL_" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Feeca model)
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

		public static StatusMessage DeleteConditions(Models.Feeca model)
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

		public static StatusMessage ViewConditions(Models.Feeca model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Feeca model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Fldscondpseudgridtbl_) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValFeedback = ViewModelConversion.ToString(m.ValFeedback);
 				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
 				ValCodfeeca = ViewModelConversion.ToString(m.ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Fldscondpseudgridtbl_) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fldscondpseudgridtbl_) to Model (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValFeedback = ViewModelConversion.ToString(ValFeedback);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
				m.ValCodfeeca = ViewModelConversion.ToString(ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fldscondpseudgridtbl_) to Model (Feeca) - Error during mapping");
				throw;
			}
		}

		#endregion


		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Feeca row)
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), "FFLDSCONDPSEUDGRIDTBL_");
				if (Model == null)
				{
					Model = new Models.Feeca() { Identifier = "FFLDSCONDPSEUDGRIDTBL_" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FLDSCONDPSEUDGRIDTBL_]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FLDSCONDPSEUDGRIDTBL_]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_APPLY FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FLDSCONDPSEUDGRIDTBL_]/
		public override void Destroy(string id)
		{
			Model = Models.Feeca.Find(id, "FFLDSCONDPSEUDGRIDTBL_");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FLDSCONDPSEUDGRIDTBL_]/
		#endregion
	}
}
