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

namespace GenioMVC.ViewModels.Regis
{
	public class Regis_ViewModel : FormViewModel<Models.Regis>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Tax ID No:" | Type: "C"
		/// </summary>
		public string ValNif { get; set; }

		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }

		/// <summary>
		/// Title: "Email:" | Type: "C"
		/// </summary>
		public string ValEmail1 { get; set; }

		/// <summary>
		/// Title: "Alternative Email" | Type: "C"
		/// </summary>
		public string ValEmail2 { get; set; }

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

		public string ValCodregis { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Regis_ViewModel() : base(null!) { }

		public Regis_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FREGIS", nestedForm) { }

		public Regis_ViewModel(UserContext userContext, Models.Regis row, bool nestedForm = false) : base(userContext, "FREGIS", row, nestedForm) { }

		public Regis_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("regis", id);
			Model = Models.Regis.Find(id, userContext, "FREGIS", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Regis model = new Models.Regis(userContext) { Identifier = "FREGIS" };
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
			Models.Regis model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Regis m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Regis) to ViewModel (Regis) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValNif = ViewModelConversion.ToString(m.ValNif);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail1 = ViewModelConversion.ToString(m.ValEmail1);
				ValEmail2 = ViewModelConversion.ToString(m.ValEmail2);
				ValCodregis = ViewModelConversion.ToString(m.ValCodregis);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Regis) to ViewModel (Regis) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Regis m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regis) to Model (Regis) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValNif = ViewModelConversion.ToString(ValNif);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail1 = ViewModelConversion.ToString(ValEmail1);
				m.ValEmail2 = ViewModelConversion.ToString(ValEmail2);
				m.ValCodregis = ViewModelConversion.ToString(ValCodregis);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Regis) to Model (Regis) - Error during mapping");
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
				Model = Models.Regis.Find(Navigation.GetStrValue("regis"), m_userContext, "FREGIS");
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

			Model.Identifier = "FREGIS";
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

		protected override void LoadDocumentsProperties(Models.Regis row)
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
				Model = Models.Regis.Find(Navigation.GetStrValue("regis"), m_userContext, "FREGIS");
				if (Model == null)
				{
					Model = new Models.Regis(m_userContext) { Identifier = "FREGIS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("regis");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL REGIS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW REGIS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 85);
			validator.Required("ValName", Resources.Resources.NAME31974, ValName);
			validator.StringLength("ValNif", Resources.Resources.TAX_ID_NO_58377, ValNif, 20);
			validator.Required("ValNif", Resources.Resources.TAX_ID_NO_58377, ValNif);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 15);
			validator.StringLength("ValEmail1", Resources.Resources.EMAIL_44228, ValEmail1, 254);
			validator.StringLength("ValEmail2", Resources.Resources.ALTERNATIVE_EMAIL17444, ValEmail2, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE REGIS]/
		public override void Save()
		{

			try { Model = Models.Regis.Find(Navigation.GetStrValue("regis"), m_userContext, "FREGIS"); }
			finally { if (Model == null) Model = new Models.Regis(m_userContext) { Identifier = "FREGIS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY REGIS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Regis.Find(Navigation.GetStrValue("regis"), m_userContext, "FREGIS"); }
			finally { if (Model == null) Model = new Models.Regis(m_userContext) { Identifier = "FREGIS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE REGIS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY REGIS]/
		public override void Destroy(string id)
		{
			Model = Models.Regis.Find(id, m_userContext, "FREGIS");
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
				"regis.name" => ViewModelConversion.ToString(modelValue),
				"regis.nif" => ViewModelConversion.ToString(modelValue),
				"regis.telephon" => ViewModelConversion.ToString(modelValue),
				"regis.email1" => ViewModelConversion.ToString(modelValue),
				"regis.email2" => ViewModelConversion.ToString(modelValue),
				"regis.codregis" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM REGIS]/

		#endregion
	}
}
