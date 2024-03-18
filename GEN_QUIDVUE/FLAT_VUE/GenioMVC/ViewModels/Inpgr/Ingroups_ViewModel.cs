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

namespace GenioMVC.ViewModels.Inpgr
{
	public class Ingroups_ViewModel : FormViewModel<Models.Inpgr>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "VAT Number" | Type: "N"
		/// </summary>
		public decimal? ValNumbgro { get; set; }

		/// <summary>
		/// Title: "First name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Last name" | Type: "C"
		/// </summary>
		public string ValLastname { get; set; }

		/// <summary>
		/// Title: "Prefix" | Type: "AC"
		/// </summary>
		public string ValPrefix { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValPrefix { get; set; }

		/// <summary>
		/// Title: "Phone number" | Type: "N"
		/// </summary>
		public decimal? ValPhone { get; set; }

		/// <summary>
		/// Title: "Address type" | Type: "AC"
		/// </summary>
		public string ValAdress { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAdress { get; set; }

		/// <summary>
		/// Title: "E-mail" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		/// <summary>
		/// Title: "Web" | Type: "C"
		/// </summary>
		public string ValWeb { get; set; }

		/// <summary>
		/// Title: "Entity" | Type: "AC"
		/// </summary>
		public string ValBankcomp { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValBankcomp { get; set; }

		/// <summary>
		/// Title: "IBAN" | Type: "C"
		/// </summary>
		public string ValIban { get; set; }

		/// <summary>
		/// Title: "Text Field" | Type: "C"
		/// </summary>
		public string ValTextgro { get; set; }

		/// <summary>
		/// Title: "Banking Account Number" | Type: "C"
		/// </summary>
		public string ValBankacco { get; set; }

		/// <summary>
		/// Title: "Adress" | Type: "C"
		/// </summary>
		public string ValDirectio { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Icon" Tipo: "C"</summary>
		public string ValIcongro { get; set; }

		#endregion

		public string ValCodinpgr { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Ingroups_ViewModel() : base(null!) { }

		public Ingroups_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FINGROUPS", nestedForm) { }

		public Ingroups_ViewModel(UserContext userContext, Models.Inpgr row, bool nestedForm = false) : base(userContext, "FINGROUPS", row, nestedForm) { }

		public Ingroups_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("inpgr", id);
			Model = Models.Inpgr.Find(id, userContext, "FINGROUPS", fieldsToQuery: fieldsToLoad);
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
			Models.Inpgr model = new Models.Inpgr(userContext) { Identifier = "FINGROUPS" };
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
			Models.Inpgr model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Inpgr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Inpgr) to ViewModel (Ingroups) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValNumbgro = ViewModelConversion.ToNumeric(m.ValNumbgro);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValLastname = ViewModelConversion.ToString(m.ValLastname);
				ValPrefix = ViewModelConversion.ToString(m.ValPrefix);
				ValPhone = ViewModelConversion.ToNumeric(m.ValPhone);
				ValAdress = ViewModelConversion.ToString(m.ValAdress);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValWeb = ViewModelConversion.ToString(m.ValWeb);
				ValBankcomp = ViewModelConversion.ToString(m.ValBankcomp);
				ValIban = ViewModelConversion.ToString(m.ValIban);
				ValTextgro = ViewModelConversion.ToString(m.ValTextgro);
				ValBankacco = ViewModelConversion.ToString(m.ValBankacco);
				ValDirectio = ViewModelConversion.ToString(m.ValDirectio);
				ValIcongro = ViewModelConversion.ToString(m.ValIcongro);
				ValCodinpgr = ViewModelConversion.ToString(m.ValCodinpgr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Inpgr) to ViewModel (Ingroups) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Inpgr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ingroups) to Model (Inpgr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValNumbgro = ViewModelConversion.ToNumeric(ValNumbgro);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValLastname = ViewModelConversion.ToString(ValLastname);
				m.ValPrefix = ViewModelConversion.ToString(ValPrefix);
				m.ValPhone = ViewModelConversion.ToNumeric(ValPhone);
				m.ValAdress = ViewModelConversion.ToString(ValAdress);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValWeb = ViewModelConversion.ToString(ValWeb);
				m.ValBankcomp = ViewModelConversion.ToString(ValBankcomp);
				m.ValIban = ViewModelConversion.ToString(ValIban);
				m.ValTextgro = ViewModelConversion.ToString(ValTextgro);
				m.ValBankacco = ViewModelConversion.ToString(ValBankacco);
				m.ValDirectio = ViewModelConversion.ToString(ValDirectio);
				m.ValIcongro = ViewModelConversion.ToString(ValIcongro);
				m.ValCodinpgr = ViewModelConversion.ToString(ValCodinpgr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Ingroups) to Model (Inpgr) - Error during mapping");
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
				Model = Models.Inpgr.Find(Navigation.GetStrValue("inpgr"), m_userContext, "FINGROUPS");
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

			Model.Identifier = "FINGROUPS";
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

		protected override void LoadDocumentsProperties(Models.Inpgr row)
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
				Model = Models.Inpgr.Find(Navigation.GetStrValue("inpgr"), m_userContext, "FINGROUPS");
				if (Model == null)
				{
					Model = new Models.Inpgr(m_userContext) { Identifier = "FINGROUPS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("inpgr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL INGROUPS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW INGROUPS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.FIRST_NAME51967, ValName, 50);
			validator.StringLength("ValLastname", Resources.Resources.LAST_NAME63426, ValLastname, 50);
			validator.StringLength("ValEmail", Resources.Resources.E_MAIL42251, ValEmail, 50);
			validator.StringLength("ValWeb", Resources.Resources.WEB09813, ValWeb, 50);
			validator.StringLength("ValIban", Resources.Resources.IBAN28506, ValIban, 34);
			validator.StringLength("ValTextgro", Resources.Resources.TEXT_FIELD41810, ValTextgro, 50);
			validator.StringLength("ValBankacco", Resources.Resources.BANKING_ACCOUNT_NUMB62548, ValBankacco, 24);
			validator.StringLength("ValDirectio", Resources.Resources.ADRESS39816, ValDirectio, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE INGROUPS]/
		public override void Save()
		{

			try { Model = Models.Inpgr.Find(Navigation.GetStrValue("inpgr"), m_userContext, "FINGROUPS"); }
			finally { if (Model == null) Model = new Models.Inpgr(m_userContext) { Identifier = "FINGROUPS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY INGROUPS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Inpgr.Find(Navigation.GetStrValue("inpgr"), m_userContext, "FINGROUPS"); }
			finally { if (Model == null) Model = new Models.Inpgr(m_userContext) { Identifier = "FINGROUPS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE INGROUPS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY INGROUPS]/
		public override void Destroy(string id)
		{
			Model = Models.Inpgr.Find(id, m_userContext, "FINGROUPS");
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
				"inpgr.numbgro" => ViewModelConversion.ToNumeric(modelValue),
				"inpgr.name" => ViewModelConversion.ToString(modelValue),
				"inpgr.lastname" => ViewModelConversion.ToString(modelValue),
				"inpgr.prefix" => ViewModelConversion.ToString(modelValue),
				"inpgr.phone" => ViewModelConversion.ToNumeric(modelValue),
				"inpgr.adress" => ViewModelConversion.ToString(modelValue),
				"inpgr.email" => ViewModelConversion.ToString(modelValue),
				"inpgr.web" => ViewModelConversion.ToString(modelValue),
				"inpgr.bankcomp" => ViewModelConversion.ToString(modelValue),
				"inpgr.iban" => ViewModelConversion.ToString(modelValue),
				"inpgr.textgro" => ViewModelConversion.ToString(modelValue),
				"inpgr.bankacco" => ViewModelConversion.ToString(modelValue),
				"inpgr.directio" => ViewModelConversion.ToString(modelValue),
				"inpgr.icongro" => ViewModelConversion.ToString(modelValue),
				"inpgr.codinpgr" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM INGROUPS]/

		#endregion
	}
}
