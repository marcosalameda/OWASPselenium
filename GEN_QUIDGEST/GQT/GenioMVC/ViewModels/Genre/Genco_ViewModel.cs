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

namespace GenioMVC.ViewModels.Genre
{
	public class Genco_ViewModel : FormViewModel<Models.Genre>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Contact Genre" Tipo:"AC"</summary>
		[Display(Name = "CONTACT_GENRE31604", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Genconta", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAgencont { get; set; }
		[JsonIgnore]
		public SelectList List_ValAgencont { get; set; }

		/// <summary>Campo : "Genre" Tipo:"C"</summary>
		[Display(Name = "GENRE63303", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(20, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValGender { get; set; }

		/// <summary>Campo : "Background Color" Tipo:"C"</summary>
		[Display(Name = "BACKGROUND_COLOR07511", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValBackcolo { get; set; }

		/// <summary>Campo : "Text Color" Tipo:"C"</summary>
		[Display(Name = "TEXT_COLOR63426", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTextcolo { get; set; }


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

		public string ValCodgenre { get; set; }

		public Genco_ViewModel() : base("FGENCO") { }

		public Genco_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FGENCO", currentNavigation, nestedForm) { }

		public Genco_ViewModel(Models.Genre row, NavigationContext currentNavigation, bool nestedForm = false) : base("FGENCO", row, currentNavigation, nestedForm) { }

		public Genco_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("genre", id);
			Model = Models.Genre.Find(id, "FGENCO", fieldsToQuery: fieldsToLoad);
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
			Models.Genre model = new Models.Genre() { Identifier = "FGENCO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Genre model)
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

		public static StatusMessage DeleteConditions(Models.Genre model)
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

		public static StatusMessage ViewConditions(Models.Genre model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Genre model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Genre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Genre) to ViewModel (Genco) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValAgencont = ViewModelConversion.ToString(m.ValAgencont);
 				ValGender = ViewModelConversion.ToString(m.ValGender);
 				ValBackcolo = ViewModelConversion.ToString(m.ValBackcolo);
 				ValTextcolo = ViewModelConversion.ToString(m.ValTextcolo);
 				ValCodgenre = ViewModelConversion.ToString(m.ValCodgenre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Genre) to ViewModel (Genco) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Genre m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Genco) to Model (Genre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValAgencont = ViewModelConversion.ToString(ValAgencont);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValBackcolo = ViewModelConversion.ToString(ValBackcolo);
				m.ValTextcolo = ViewModelConversion.ToString(ValTextcolo);
				m.ValCodgenre = ViewModelConversion.ToString(ValCodgenre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Genco) to Model (Genre) - Error during mapping");
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
				Model = Models.Genre.Find(Navigation.GetStrValue("genre"), "FGENCO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Genre() { Identifier = "FGENCO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("genre");
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

			Model.Identifier = "FGENCO";
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

		protected override void LoadDocumentsProperties(Models.Genre row)
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
				Model = Models.Genre.Find(Navigation.GetStrValue("genre"), "FGENCO");
				if (Model == null)
				{
					Model = new Models.Genre() { Identifier = "FGENCO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("genre");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GENCO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GENCO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GENCO]/
		public override void Save()
		{

			try { Model = Models.Genre.Find(Navigation.GetStrValue("genre"), "FGENCO"); }
			finally { if (Model == null) Model = new Models.Genre() { Identifier = "FGENCO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GENCO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Genre.Find(Navigation.GetStrValue("genre"), "FGENCO"); }
			finally { if (Model == null) Model = new Models.Genre() { Identifier = "FGENCO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GENCO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GENCO]/
		public override void Destroy(string id)
		{
			Model = Models.Genre.Find(id, "FGENCO");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValAgencont = new SelectList(
				ArrayGenconta.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValAgencont);
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GENCO]/
		#endregion
	}
}
