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

namespace GenioMVC.ViewModels.Decom
{
	public class Abate_ViewModel : FormViewModel<Models.Decom>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "No decomission" Tipo:"N"</summary>
		[Display(Name = "NO_DECOMISSION13045", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValDecomnr { get; set; }

		/// <summary>Campo : "Decomission" Tipo:"DT"</summary>
		[Display(Name = "DECOMISSION14486", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtdeco { get; set; }


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

		public string ValCoddeco { get; set; }

		public Abate_ViewModel() : base("FABATE") { }

		public Abate_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FABATE", currentNavigation, nestedForm) { }

		public Abate_ViewModel(Models.Decom row, NavigationContext currentNavigation, bool nestedForm = false) : base("FABATE", row, currentNavigation, nestedForm) { }

		public Abate_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("decom", id);
			Model = Models.Decom.Find(id, "FABATE", fieldsToQuery: fieldsToLoad);
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
			Models.Decom model = new Models.Decom() { Identifier = "FABATE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Decom model)
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

		public static StatusMessage DeleteConditions(Models.Decom model)
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

		public static StatusMessage ViewConditions(Models.Decom model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Decom model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abate) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValDecomnr = ViewModelConversion.ToNumeric(m.ValDecomnr);
 				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
 				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Decom) to ViewModel (Abate) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Decom m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Abate) to Model (Decom) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValDecomnr = ViewModelConversion.ToNumeric(ValDecomnr);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Abate) to Model (Decom) - Error during mapping");
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
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), "FABATE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Decom() { Identifier = "FABATE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("decom");
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

			Model.Identifier = "FABATE";
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

		protected override void LoadDocumentsProperties(Models.Decom row)
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
				Model = Models.Decom.Find(Navigation.GetStrValue("decom"), "FABATE");
				if (Model == null)
				{
					Model = new Models.Decom() { Identifier = "FABATE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("decom");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ABATE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ABATE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ABATE]/
		public override void Save()
		{

			try { Model = Models.Decom.Find(Navigation.GetStrValue("decom"), "FABATE"); }
			finally { if (Model == null) Model = new Models.Decom() { Identifier = "FABATE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ABATE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Decom.Find(Navigation.GetStrValue("decom"), "FABATE"); }
			finally { if (Model == null) Model = new Models.Decom() { Identifier = "FABATE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ABATE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ABATE]/
		public override void Destroy(string id)
		{
			Model = Models.Decom.Find(id, "FABATE");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ABATE]/
		#endregion
	}
}
