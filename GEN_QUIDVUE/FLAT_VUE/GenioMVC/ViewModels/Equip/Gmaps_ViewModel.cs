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

namespace GenioMVC.ViewModels.Equip
{
	public class Gmaps_ViewModel : FormViewModel<Models.Equip>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCoddeco { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodpess1 { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodrooms { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "No. register" Tipo: "C"</summary>
		public string ValRegistnr { get; set; }

		#endregion

		public string ValCodequip { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Gmaps_ViewModel() : base(null!) { }

		public Gmaps_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGMAPS", nestedForm) { }

		public Gmaps_ViewModel(UserContext userContext, Models.Equip row, bool nestedForm = false) : base(userContext, "FGMAPS", row, nestedForm) { }

		public Gmaps_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, userContext, "FGMAPS", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip(userContext) { Identifier = "FGMAPS" };
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
			Models.Equip model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Gmaps) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Gmaps) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Gmaps) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Gmaps) to Model (Equip) - Error during mapping");
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGMAPS");
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

			Model.Identifier = "FGMAPS";
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

		protected override void LoadDocumentsProperties(Models.Equip row)
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGMAPS");
				if (Model == null)
				{
					Model = new Models.Equip(m_userContext) { Identifier = "FGMAPS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GMAPS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GMAPS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GMAPS]/
		public override void Save()
		{

			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGMAPS"); }
			finally { if (Model == null) Model = new Models.Equip(m_userContext) { Identifier = "FGMAPS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GMAPS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FGMAPS"); }
			finally { if (Model == null) Model = new Models.Equip(m_userContext) { Identifier = "FGMAPS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GMAPS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GMAPS]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, m_userContext, "FGMAPS");
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
				"equip.codempre" => ViewModelConversion.ToString(modelValue),
				"equip.coddeco" => ViewModelConversion.ToString(modelValue),
				"equip.coditem" => ViewModelConversion.ToString(modelValue),
				"equip.codpess1" => ViewModelConversion.ToString(modelValue),
				"equip.codtpequ" => ViewModelConversion.ToString(modelValue),
				"equip.codwareh" => ViewModelConversion.ToString(modelValue),
				"equip.codrooms" => ViewModelConversion.ToString(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GMAPS]/

		#endregion
	}
}
