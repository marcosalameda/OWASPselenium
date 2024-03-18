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

namespace GenioMVC.ViewModels.Aero
{
	public class Aero_ViewModel : FormViewModel<Models.Aero>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Airline" Tipo:"C"</summary>
		[Display(Name = "AIRLINE57868", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Code" Tipo:"N"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValCodcmaer { get; set; }


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

		public string ValCodaero { get; set; }

		public Aero_ViewModel() : base("FAERO") { }

		public Aero_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FAERO", currentNavigation, nestedForm) { }

		public Aero_ViewModel(Models.Aero row, NavigationContext currentNavigation, bool nestedForm = false) : base("FAERO", row, currentNavigation, nestedForm) { }

		public Aero_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("aero", id);
			Model = Models.Aero.Find(id, "FAERO", fieldsToQuery: fieldsToLoad);
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
			Models.Aero model = new Models.Aero() { Identifier = "FAERO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Aero model)
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

		public static StatusMessage DeleteConditions(Models.Aero model)
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

		public static StatusMessage ViewConditions(Models.Aero model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Aero model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Aero m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Aero) to ViewModel (Aero) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValCodcmaer = ViewModelConversion.ToNumeric(m.ValCodcmaer);
 				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Aero) to ViewModel (Aero) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Aero m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Aero) to Model (Aero) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodcmaer = ViewModelConversion.ToNumeric(ValCodcmaer);
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Aero) to Model (Aero) - Error during mapping");
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
				Model = Models.Aero.Find(Navigation.GetStrValue("aero"), "FAERO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Aero() { Identifier = "FAERO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("aero");
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

			Model.Identifier = "FAERO";
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

		protected override void LoadDocumentsProperties(Models.Aero row)
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
				Model = Models.Aero.Find(Navigation.GetStrValue("aero"), "FAERO");
				if (Model == null)
				{
					Model = new Models.Aero() { Identifier = "FAERO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("aero");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL AERO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW AERO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE AERO]/
		public override void Save()
		{

			try { Model = Models.Aero.Find(Navigation.GetStrValue("aero"), "FAERO"); }
			finally { if (Model == null) Model = new Models.Aero() { Identifier = "FAERO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY AERO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Aero.Find(Navigation.GetStrValue("aero"), "FAERO"); }
			finally { if (Model == null) Model = new Models.Aero() { Identifier = "FAERO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE AERO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY AERO]/
		public override void Destroy(string id)
		{
			Model = Models.Aero.Find(id, "FAERO");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM AERO]/
		#endregion
	}
}
