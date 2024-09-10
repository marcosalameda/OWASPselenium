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

namespace GenioMVC.ViewModels.Addre
{
	public class Addre_ViewModel : FormViewModel<Models.Addre>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Address Use" Tipo:"AC"</summary>
		[Display(Name = "ADDRESS_USE16014", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Addressu", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddressuse { get; set; }
		[JsonIgnore]
		public SelectList List_ValAddressuse { get; set; }

		/// <summary>Campo : "Address Type" Tipo:"AC"</summary>
		[Display(Name = "ADDRESS_TYPE12455", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Addresst", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAddresstype { get; set; }
		[JsonIgnore]
		public SelectList List_ValAddresstype { get; set; }

		/// <summary>Campo : "Entire address" Tipo:"MO"</summary>
		[Display(Name = "ENTIRE_ADDRESS64248", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string ValAddresstext { get; set; }

		/// <summary>Campo : "Address City" Tipo:"C"</summary>
		[Display(Name = "ADDRESS_CITY41109", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAddresscity { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Period Start" Tipo: "DT"</summary>
		public DateTime? ValPeriodstart { get; set; }
		// Field to formula
		/// <summary>Field : "Period End" Tipo: "DT"</summary>
		public DateTime? ValPeriodend { get; set; }
		#endregion

		public string ValCodaddre { get; set; }

		public Addre_ViewModel() : base("FADDRE") { }

		public Addre_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FADDRE", currentNavigation, nestedForm) { }

		public Addre_ViewModel(Models.Addre row, NavigationContext currentNavigation, bool nestedForm = false) : base("FADDRE", row, currentNavigation, nestedForm) { }

		public Addre_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("addre", id);
			Model = Models.Addre.Find(id, "FADDRE", fieldsToQuery: fieldsToLoad);
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
			Models.Addre model = new Models.Addre() { Identifier = "FADDRE" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Addre model)
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

		public static StatusMessage DeleteConditions(Models.Addre model)
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

		public static StatusMessage ViewConditions(Models.Addre model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Addre model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Addre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Addre) to ViewModel (Addre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValAddressuse = ViewModelConversion.ToString(m.ValAddressuse);
 				ValAddresstype = ViewModelConversion.ToString(m.ValAddresstype);
 				ValAddresstext = ViewModelConversion.ToString(m.ValAddresstext);
 				ValAddresscity = ViewModelConversion.ToString(m.ValAddresscity);
 				ValPeriodstart = ViewModelConversion.ToDateTime(m.ValPeriodstart);
 				ValPeriodend = ViewModelConversion.ToDateTime(m.ValPeriodend);
 				ValCodaddre = ViewModelConversion.ToString(m.ValCodaddre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Addre) to ViewModel (Addre) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Addre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Addre) to Model (Addre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValAddressuse = ViewModelConversion.ToString(ValAddressuse);
				m.ValAddresstype = ViewModelConversion.ToString(ValAddresstype);
				m.ValAddresstext = ViewModelConversion.ToString(ValAddresstext);
				m.ValAddresscity = ViewModelConversion.ToString(ValAddresscity);
				m.ValPeriodstart = ViewModelConversion.ToDateTime(ValPeriodstart);
				m.ValPeriodend = ViewModelConversion.ToDateTime(ValPeriodend);
				m.ValCodaddre = ViewModelConversion.ToString(ValCodaddre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Addre) to Model (Addre) - Error during mapping");
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
				Model = Models.Addre.Find(Navigation.GetStrValue("addre"), "FADDRE");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Addre() { Identifier = "FADDRE" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("addre");
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

			Model.Identifier = "FADDRE";
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

		protected override void LoadDocumentsProperties(Models.Addre row)
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
				Model = Models.Addre.Find(Navigation.GetStrValue("addre"), "FADDRE");
				if (Model == null)
				{
					Model = new Models.Addre() { Identifier = "FADDRE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("addre");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ADDRE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ADDRE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ADDRE]/
		public override void Save()
		{

			try { Model = Models.Addre.Find(Navigation.GetStrValue("addre"), "FADDRE"); }
			finally { if (Model == null) Model = new Models.Addre() { Identifier = "FADDRE" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ADDRE]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Addre.Find(Navigation.GetStrValue("addre"), "FADDRE"); }
			finally { if (Model == null) Model = new Models.Addre() { Identifier = "FADDRE" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ADDRE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ADDRE]/
		public override void Destroy(string id)
		{
			Model = Models.Addre.Find(id, "FADDRE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValAddressuse = new SelectList(
				ArrayAddressu.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValAddressuse);
			this.List_ValAddresstype = new SelectList(
				ArrayAddresst.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValAddresstype);
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ADDRE]/
		#endregion
	}
}
