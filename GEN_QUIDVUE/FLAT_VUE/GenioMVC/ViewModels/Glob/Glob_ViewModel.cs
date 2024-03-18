using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Glob
{
	public class Glob_ViewModel : FormViewModel<Models.Glob>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Home text" | Type: "MO"
		/// </summary>
		public string ValHome { get; set; }

		/// <summary>
		/// Title: "External API address" | Type: "C"
		/// </summary>
		public string ValApiurl { get; set; }

		/// <summary>
		/// Title: "Legend" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(480, 100)]
		public GenioMVC.ViewModels.ImageModel ValLegend { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodfacty { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodglob { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Glob_ViewModel() : base(null!) { }

		public Glob_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGLOB", nestedForm) { }

		public Glob_ViewModel(UserContext userContext, Models.Glob row, bool nestedForm = false) : base(userContext, "FGLOB", row, nestedForm) { }

		public Glob_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("glob", id);
			Model = Models.Glob.Find(id, userContext, "FGLOB", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Glob model = new Models.Glob(userContext) { Identifier = "FGLOB" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Glob model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Glob) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValHome = ViewModelConversion.ToString(m.ValHome);
				ValApiurl = ViewModelConversion.ToString(m.ValApiurl);
				ValLegend = ViewModelConversion.ToImage(m.ValLegend);
				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
				ValCodglob = ViewModelConversion.ToString(m.ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Glob) to ViewModel (Glob) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Glob m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Glob) to Model (Glob) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValHome = ViewModelConversion.ToString(ValHome);
				m.ValApiurl = ViewModelConversion.ToString(ValApiurl);
				m.ValLegend = ViewModelConversion.ToImage(ValLegend);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValCodglob = ViewModelConversion.ToString(ValCodglob);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Glob) to Model (Glob) - Error during mapping");
				throw;
			}
		}

		#endregion

		public void LoadGlob()
		{
			LoadGlob(new NameValueCollection(), false, false);
		}

		public override void LoadGlob(NameValueCollection qs, bool editable, bool ajaxRequest = false)
		{
			this.editable = editable;

			Model = Models.Glob.GetGlob(m_userContext, true);

			if (Model == null)
				throw new ModelNotFoundException("Model not found");

			InitModel(qs);
		}


		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOB");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FGLOB";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Glob row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOB");
				if (Model == null)
				{
					Model = new Models.Glob(m_userContext) { Identifier = "FGLOB" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("glob");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GLOB]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GLOB]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValApiurl", Resources.Resources.EXTERNAL_API_ADDRESS59205, ValApiurl, 350);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GLOB]/
		public override void Save()
		{

			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOB"); }
			finally { if (Model == null) Model = new Models.Glob(m_userContext) { Identifier = "FGLOB" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GLOB]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Glob.Find(Navigation.GetStrValue("glob"), m_userContext, "FGLOB"); }
			finally { if (Model == null) Model = new Models.Glob(m_userContext) { Identifier = "FGLOB" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GLOB]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GLOB]/
		public override void Destroy(string id)
		{
			Model = Models.Glob.Find(id, m_userContext, "FGLOB");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"glob.home" => ViewModelConversion.ToString(modelValue),
				"glob.apiurl" => ViewModelConversion.ToString(modelValue),
				"glob.legend" => ViewModelConversion.ToImage(modelValue),
				"glob.codfacty" => ViewModelConversion.ToString(modelValue),
				"glob.codglob" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GLOB]/

		#endregion
	}
}
