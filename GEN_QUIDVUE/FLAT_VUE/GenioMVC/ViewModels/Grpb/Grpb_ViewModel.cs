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

namespace GenioMVC.ViewModels.Grpb
{
	public class Grpb_ViewModel : FormViewModel<Models.Grpb>
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
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public GridTableList<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel> ValTblb { get; set; }

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

		public string ValCodgrpb { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Grpb_ViewModel() : base(null!) { }

		public Grpb_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGRPB", nestedForm) { }

		public Grpb_ViewModel(UserContext userContext, Models.Grpb row, bool nestedForm = false) : base(userContext, "FGRPB", row, nestedForm) { }

		public Grpb_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("grpb", id);
			Model = Models.Grpb.Find(id, userContext, "FGRPB", fieldsToQuery: fieldsToLoad);
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
			Models.Grpb model = new Models.Grpb(userContext) { Identifier = "FGRPB" };
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
			Models.Grpb model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Grpb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Grpb) to ViewModel (Grpb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValCodgrpb = ViewModelConversion.ToString(m.ValCodgrpb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Grpb) to ViewModel (Grpb) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Grpb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Grpb) to Model (Grpb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodgrpb = ViewModelConversion.ToString(ValCodgrpb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Grpb) to Model (Grpb) - Error during mapping");
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
				Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), m_userContext, "FGRPB");
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

			Model.Identifier = "FGRPB";
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

		protected override void LoadDocumentsProperties(Models.Grpb row)
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
				Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), m_userContext, "FGRPB");
				if (Model == null)
				{
					Model = new Models.Grpb(m_userContext) { Identifier = "FGRPB" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("grpb");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GRPB]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GRPB]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Merge(ValTblb?.Validate(), "ValTblb");

			validator.StringLength("ValName", Resources.Resources.NAME31974, ValName, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GRPB]/
		public override void Save()
		{
			try
			{
				ValTblb?.Save();
			}
			catch (FieldValidationException fvExc)
			{
				var sMsg = StatusMessage.Error();
				foreach (var message in fvExc.StatusMessage.GetErrorList())
					sMsg.MergeStatusMessage(new StatusMessage(message.Status, message.Message, string.Format("Tblb.{0}", message.Origin)));

				throw new FieldValidationException(sMsg, fvExc.ExceptionSite);
			}

			try { Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), m_userContext, "FGRPB"); }
			finally { if (Model == null) Model = new Models.Grpb(m_userContext) { Identifier = "FGRPB" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GRPB]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), m_userContext, "FGRPB"); }
			finally { if (Model == null) Model = new Models.Grpb(m_userContext) { Identifier = "FGRPB" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GRPB]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GRPB]/
		public override void Destroy(string id)
		{
			Model = Models.Grpb.Find(id, m_userContext, "FGRPB");
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
				"grpb.name" => ViewModelConversion.ToString(modelValue),
				"grpb.codgrpb" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GRPB]/

		#endregion
	}
}
