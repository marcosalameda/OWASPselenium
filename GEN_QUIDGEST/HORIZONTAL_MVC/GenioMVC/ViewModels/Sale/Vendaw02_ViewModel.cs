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

namespace GenioMVC.ViewModels.Sale
{
	public class Vendaw02_ViewModel : FormViewModel<Models.Sale>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Interested" Tipo:"L"</summary>
		[Display(Name = "INTERESTED34576", ResourceType = typeof(Resources.Resources))]
		public bool ValInteress { get; set; }

		/// <summary>Campo : "No financial resources" Tipo:"L"</summary>
		[Display(Name = "NO_FINANCIAL_RESOURC29226", ResourceType = typeof(Resources.Resources))]
		public bool ValSemrfina { get; set; }

		/// <summary>Campo : "No decision-making capacity" Tipo:"L"</summary>
		[Display(Name = "NO_DECISION_MAKING_C52676", ResourceType = typeof(Resources.Resources))]
		public bool ValSemcapac { get; set; }

		/// <summary>Campo : "Qualification" Tipo:"DT"</summary>
		[Display(Name = "QUALIFICATION64257", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("DT")]
		public DateTime? ValDtqualif { get; set; }

		/// <summary>Campo : "Qualification carried out" Tipo:"L"</summary>
		[Display(Name = "QUALIFICATION_CARRIE05255", ResourceType = typeof(Resources.Resources))]
		public bool ValQualific { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodorgan { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Identification of business opportunity" Tipo: "C"</summary>
		[AllowHtml]
		public string ValIdentifi { get; set; }
		#endregion

		public string ValCodvenda { get; set; }

		public Vendaw02_ViewModel() : base("FVENDAW02") { }

		public Vendaw02_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FVENDAW02", currentNavigation, nestedForm) { }

		public Vendaw02_ViewModel(Models.Sale row, NavigationContext currentNavigation, bool nestedForm = false) : base("FVENDAW02", row, currentNavigation, nestedForm) { }

		public Vendaw02_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("sale", id);
			Model = Models.Sale.Find(id, "FVENDAW02", fieldsToQuery: fieldsToLoad);
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
			Models.Sale model = new Models.Sale() { Identifier = "FVENDAW02" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Sale model)
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

		public static StatusMessage DeleteConditions(Models.Sale model)
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

		public static StatusMessage ViewConditions(Models.Sale model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Sale model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw02) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValInteress = ViewModelConversion.ToLogic(m.ValInteress);
 				ValSemrfina = ViewModelConversion.ToLogic(m.ValSemrfina);
 				ValSemcapac = ViewModelConversion.ToLogic(m.ValSemcapac);
 				ValDtqualif = ViewModelConversion.ToDateTime(m.ValDtqualif);
 				ValQualific = ViewModelConversion.ToLogic(m.ValQualific);
 				ValCodorgan = ViewModelConversion.ToString(m.ValCodorgan);
 				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
 				ValCodvenda = ViewModelConversion.ToString(m.ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Sale) to ViewModel (Vendaw02) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Sale m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Vendaw02) to Model (Sale) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValInteress = ViewModelConversion.ToLogic(ValInteress);
				m.ValSemrfina = ViewModelConversion.ToLogic(ValSemrfina);
				m.ValSemcapac = ViewModelConversion.ToLogic(ValSemcapac);
				m.ValDtqualif = ViewModelConversion.ToDateTime(ValDtqualif);
				m.ValQualific = ViewModelConversion.ToLogic(ValQualific);
				m.ValCodorgan = ViewModelConversion.ToString(ValCodorgan);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValCodvenda = ViewModelConversion.ToString(ValCodvenda);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Vendaw02) to Model (Sale) - Error during mapping");
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDAW02");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Sale() { Identifier = "FVENDAW02" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
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

			Model.Identifier = "FVENDAW02";
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

		protected override void LoadDocumentsProperties(Models.Sale row)
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
				Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDAW02");
				if (Model == null)
				{
					Model = new Models.Sale() { Identifier = "FVENDAW02" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("sale");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL VENDAW02]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW VENDAW02]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE VENDAW02]/
		public override void Save()
		{

			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDAW02"); }
			finally { if (Model == null) Model = new Models.Sale() { Identifier = "FVENDAW02" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY VENDAW02]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Sale.Find(Navigation.GetStrValue("sale"), "FVENDAW02"); }
			finally { if (Model == null) Model = new Models.Sale() { Identifier = "FVENDAW02" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE VENDAW02]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY VENDAW02]/
		public override void Destroy(string id)
		{
			Model = Models.Sale.Find(id, "FVENDAW02");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM VENDAW02]/
		#endregion
	}
}
