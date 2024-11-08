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

namespace GenioMVC.ViewModels.Year
{
	public class Ano_ViewModel : FormViewModel<Models.Year>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Year" Tipo:"C"</summary>
		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(4, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValYear { get; set; }

		/// <summary>Campo : "Year (numbers)" Tipo:"N"</summary>
		[Display(Name = "YEAR__NUMBERS_29394", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYearnum { get; set; }

		/// <summary>Campo : "All the expenses" Tipo:"DP"</summary>
		[Display(Name = "ALL_THE_EXPENSES38264", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Expen> ValTodasdes { get; set; }

		/// <summary>Campo : "Aggregated per year" Tipo:"DP"</summary>
		[Display(Name = "AGGREGATED_PER_YEAR01261", ResourceType = typeof(Resources.Resources))]
		public TablePartial<GenioMVC.Models.Agreg> ValAgregado { get; set; }

		/// <summary>Campo : "Value" Tipo:"$D"</summary>
		[Display(Name = "VALUE10285", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValue { get; set; }


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

		public string ValCodyear { get; set; }

		public Ano_ViewModel() : base("FANO") { }

		public Ano_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FANO", currentNavigation, nestedForm) { }

		public Ano_ViewModel(Models.Year row, NavigationContext currentNavigation, bool nestedForm = false) : base("FANO", row, currentNavigation, nestedForm) { }

		public Ano_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("year", id);
			Model = Models.Year.Find(id, "FANO", fieldsToQuery: fieldsToLoad);
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
			Models.Year model = new Models.Year() { Identifier = "FANO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Year model)
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

		public static StatusMessage DeleteConditions(Models.Year model)
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

		public static StatusMessage ViewConditions(Models.Year model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Year model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Year m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Year) to ViewModel (Ano) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValYear = ViewModelConversion.ToString(m.ValYear);
 				ValYearnum = ViewModelConversion.ToNumeric(m.ValYearnum);
 				ValValue = ViewModelConversion.ToNumeric(m.ValValue);
 				ValCodyear = ViewModelConversion.ToString(m.ValCodyear);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Year) to ViewModel (Ano) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Year m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ano) to Model (Year) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValYear = ViewModelConversion.ToString(ValYear);
				m.ValYearnum = ViewModelConversion.ToNumeric(ValYearnum);
				m.ValValue = ViewModelConversion.ToNumeric(ValValue);
				m.ValCodyear = ViewModelConversion.ToString(ValCodyear);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ano) to Model (Year) - Error during mapping");
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
				Model = Models.Year.Find(Navigation.GetStrValue("year"), "FANO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Year() { Identifier = "FANO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("year");
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

			Model.Identifier = "FANO";
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

		protected override void LoadDocumentsProperties(Models.Year row)
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
				Model = Models.Year.Find(Navigation.GetStrValue("year"), "FANO");
				if (Model == null)
				{
					Model = new Models.Year() { Identifier = "FANO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("year");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ANO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ANO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ANO]/
		public override void Save()
		{

			try { Model = Models.Year.Find(Navigation.GetStrValue("year"), "FANO"); }
			finally { if (Model == null) Model = new Models.Year() { Identifier = "FANO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ANO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Year.Find(Navigation.GetStrValue("year"), "FANO"); }
			finally { if (Model == null) Model = new Models.Year() { Identifier = "FANO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ANO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ANO]/
		public override void Destroy(string id)
		{
			Model = Models.Year.Find(id, "FANO");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ANO]/
		#endregion
	}
}
