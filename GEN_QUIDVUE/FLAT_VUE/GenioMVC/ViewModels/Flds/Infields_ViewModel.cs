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

namespace GenioMVC.ViewModels.Flds
{
	public class Infields_ViewModel : FormViewModel<Models.Flds>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodaero { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodequip { get; set; }

		#endregion
		/// <summary>
		/// Title: "Text Field" | Type: "C"
		/// </summary>
		public string ValTxtfield { get; set; }
		/// <summary>
		/// Title: "Multine Text" | Type: "MO"
		/// </summary>
		public string ValDescrip { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "N"
		/// </summary>
		public decimal? ValYear { get; set; }
		/// <summary>
		/// Title: "Time" | Type: "T"
		/// </summary>
		public string ValTime { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Date time" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetime { get; set; }
		/// <summary>
		/// Title: "Date second" | Type: "DS"
		/// </summary>
		public DateTime? ValDateseco { get; set; }
		/// <summary>
		/// Title: "Numeric" | Type: "N"
		/// </summary>
		public decimal? ValNpassage { get; set; }
		/// <summary>
		/// Title: "Numeric decimal" | Type: "ND"
		/// </summary>
		public decimal? ValDuration { get; set; }
		/// <summary>
		/// Title: "Currency Decimal" | Type: "$D"
		/// </summary>
		public decimal? ValPrecobil { get; set; }
		/// <summary>
		/// Title: "Currency" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Social Security No" | Type: "C"
		/// </summary>
		public string ValSsnumber { get; set; }
		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValZipfield { get; set; }
		/// <summary>
		/// Title: "VAT Number" | Type: "C"
		/// </summary>
		public string ValVatnumbr { get; set; }
		/// <summary>
		/// Title: "Licence plate" | Type: "C"
		/// </summary>
		public string ValLicplate { get; set; }
		/// <summary>
		/// Title: "Banking Account Number" | Type: "C"
		/// </summary>
		public string ValBanknmbr { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmailfld { get; set; }
		/// <summary>
		/// Title: "IBAN" | Type: "C"
		/// </summary>
		public string ValIbanfiel { get; set; }
		/// <summary>
		/// Title: "Uppercase" | Type: "C"
		/// </summary>
		public string ValUpprtext { get; set; }
		/// <summary>
		/// Title: "Password" | Type: "C"
		/// </summary>
		public string ValPassfld { get; set; }
		/// <summary>
		/// Title: "Colorpicker" | Type: "C"
		/// </summary>
		public string ValClrpicke { get; set; }
		/// <summary>
		/// Title: "Logical" | Type: "L"
		/// </summary>
		public bool ValPrimviag { get; set; }
		/// <summary>
		/// Title: "" | Type: "AL"
		/// </summary>
		public int ValLogicenu { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValLogicenu { get; set; }
		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreatuse { get; set; }
		/// <summary>
		/// Title: "Day" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatdat { get; set; }
		/// <summary>
		/// Title: "Complete Date" | Type: "OI"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatins { get; set; }
		/// <summary>
		/// Title: "Hour" | Type: "OT"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreathou { get; set; }
		/// <summary>
		/// Title: "Radio Btn" | Type: "AC"
		/// </summary>
		public string ValRadiob { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValRadiob { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Enforce table conditions" Tipo: "L"</summary>
		[ValidateSetAccess]
		public bool ValTblcond { get; set; }
		// Field for formula
		/// <summary>Field: "Field state" Tipo: "AC"</summary>
		[ValidateSetAccess]
		public string ValCond { get; set; }

		#endregion

		public string ValCodflds { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Infields_ViewModel() : base(null!) { }

		public Infields_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FINFIELDS", nestedForm) { }

		public Infields_ViewModel(UserContext userContext, Models.Flds row, bool nestedForm = false) : base(userContext, "FINFIELDS", row, nestedForm) { }

		public Infields_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, userContext, "FINFIELDS", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds(userContext) { Identifier = "FINFIELDS" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FINFIELDS");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

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
			Models.Flds model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Infields) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValTxtfield = ViewModelConversion.ToString(m.ValTxtfield);
				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValTime = ViewModelConversion.ToString(m.ValTime);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValSsnumber = ViewModelConversion.ToString(m.ValSsnumber);
				ValZipfield = ViewModelConversion.ToString(m.ValZipfield);
				ValVatnumbr = ViewModelConversion.ToString(m.ValVatnumbr);
				ValLicplate = ViewModelConversion.ToString(m.ValLicplate);
				ValBanknmbr = ViewModelConversion.ToString(m.ValBanknmbr);
				ValEmailfld = ViewModelConversion.ToString(m.ValEmailfld);
				ValIbanfiel = ViewModelConversion.ToString(m.ValIbanfiel);
				ValUpprtext = ViewModelConversion.ToString(m.ValUpprtext);
				ValPassfld = ViewModelConversion.ToString(m.ValPassfld);
				ValClrpicke = ViewModelConversion.ToString(m.ValClrpicke);
				ValPrimviag = ViewModelConversion.ToLogic(m.ValPrimviag);
				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
				ValRadiob = ViewModelConversion.ToString(m.ValRadiob);
				ValTblcond = ViewModelConversion.ToLogic(m.ValTblcond);
				ValCond = ViewModelConversion.ToString(m.ValCond);
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Infields) - Error during mapping");
				throw;
			}
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <summary>
		/// Performs the mapping of field values from the ViewModel to the Model.
		/// </summary>
		/// <param name="m">The Model to be filled.</param>
		/// <exception cref="ModelNotFoundException">Thrown if <paramref name="m"/> is null.</exception>
		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Infields) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTxtfield = ViewModelConversion.ToString(ValTxtfield);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValSsnumber = ViewModelConversion.ToString(ValSsnumber);
				m.ValZipfield = ViewModelConversion.ToString(ValZipfield);
				m.ValVatnumbr = ViewModelConversion.ToString(ValVatnumbr);
				m.ValLicplate = ViewModelConversion.ToString(ValLicplate);
				m.ValBanknmbr = ViewModelConversion.ToString(ValBanknmbr);
				m.ValEmailfld = ViewModelConversion.ToString(ValEmailfld);
				m.ValIbanfiel = ViewModelConversion.ToString(ValIbanfiel);
				m.ValUpprtext = ViewModelConversion.ToString(ValUpprtext);
				m.ValPassfld = ViewModelConversion.ToString(ValPassfld);
				m.ValClrpicke = ViewModelConversion.ToString(ValClrpicke);
				m.ValPrimviag = ViewModelConversion.ToLogic(ValPrimviag);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				m.ValRadiob = ViewModelConversion.ToString(ValRadiob);
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValTblcond = ViewModelConversion.ToLogic(ValTblcond);
				m.ValCond = ViewModelConversion.ToString(ValCond);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Infields) to Model (Flds) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "flds.txtfield":
						this.ValTxtfield = ViewModelConversion.ToString(_value);
						break;
					case "flds.descrip":
						this.ValDescrip = ViewModelConversion.ToString(_value);
						break;
					case "flds.year":
						this.ValYear = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.time":
						this.ValTime = ViewModelConversion.ToString(_value);
						break;
					case "flds.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "flds.datetime":
						this.ValDatetime = ViewModelConversion.ToDateTime(_value);
						break;
					case "flds.dateseco":
						this.ValDateseco = ViewModelConversion.ToDateTime(_value);
						break;
					case "flds.npassage":
						this.ValNpassage = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.duration":
						this.ValDuration = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.precobil":
						this.ValPrecobil = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.ssnumber":
						this.ValSsnumber = ViewModelConversion.ToString(_value);
						break;
					case "flds.zipfield":
						this.ValZipfield = ViewModelConversion.ToString(_value);
						break;
					case "flds.vatnumbr":
						this.ValVatnumbr = ViewModelConversion.ToString(_value);
						break;
					case "flds.licplate":
						this.ValLicplate = ViewModelConversion.ToString(_value);
						break;
					case "flds.banknmbr":
						this.ValBanknmbr = ViewModelConversion.ToString(_value);
						break;
					case "flds.emailfld":
						this.ValEmailfld = ViewModelConversion.ToString(_value);
						break;
					case "flds.ibanfiel":
						this.ValIbanfiel = ViewModelConversion.ToString(_value);
						break;
					case "flds.upprtext":
						this.ValUpprtext = ViewModelConversion.ToString(_value);
						break;
					case "flds.passfld":
						this.ValPassfld = ViewModelConversion.ToString(_value);
						break;
					case "flds.clrpicke":
						this.ValClrpicke = ViewModelConversion.ToString(_value);
						break;
					case "flds.primviag":
						this.ValPrimviag = ViewModelConversion.ToLogic(_value);
						break;
					case "flds.logicenu":
						this.ValLogicenu = ViewModelConversion.ToInteger(_value);
						break;
					case "flds.radiob":
						this.ValRadiob = ViewModelConversion.ToString(_value);
						break;
					case "flds.codflds":
						this.ValCodflds = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Infields) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Infields)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Flds.Find(id ?? Navigation.GetStrValue("flds"), m_userContext, "FINFIELDS"); }
			finally { Model ??= new Models.Flds(m_userContext) { Identifier = "FINFIELDS" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FINFIELDS");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FINFIELDS";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
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

		protected override void LoadDocumentsProperties(Models.Flds row)
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FINFIELDS");
				if (Model == null)
				{
					Model = new Models.Flds(m_userContext) { Identifier = "FINFIELDS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL INFIELDS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW INFIELDS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTxtfield", Resources.Resources.TEXT_FIELD41810, ValTxtfield, 50);
			validator.StringLength("ValSsnumber", Resources.Resources.SOCIAL_SECURITY_NO48150, ValSsnumber, 11);
			validator.StringLength("ValZipfield", Resources.Resources.ZIPCODE21021, ValZipfield, 8);
			validator.StringLength("ValVatnumbr", Resources.Resources.VAT_NUMBER24236, ValVatnumbr, 9);
			validator.StringLength("ValLicplate", Resources.Resources.LICENCE_PLATE07627, ValLicplate, 8);
			validator.StringLength("ValBanknmbr", Resources.Resources.BANKING_ACCOUNT_NUMB62548, ValBanknmbr, 24);
			validator.StringLength("ValEmailfld", Resources.Resources.EMAIL25170, ValEmailfld, 50);
			validator.StringLength("ValIbanfiel", Resources.Resources.IBAN28506, ValIbanfiel, 34);
			validator.StringLength("ValUpprtext", Resources.Resources.UPPERCASE48238, ValUpprtext, 50);
			validator.StringLength("ValPassfld", Resources.Resources.PASSWORD09467, ValPassfld, 50);
			validator.StringLength("ValClrpicke", Resources.Resources.COLORPICKER39653, ValClrpicke, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE INFIELDS]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY INFIELDS]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE INFIELDS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY INFIELDS]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, m_userContext, "FINFIELDS");
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
				"flds.codaero" => ViewModelConversion.ToString(modelValue),
				"flds.codequip" => ViewModelConversion.ToString(modelValue),
				"flds.txtfield" => ViewModelConversion.ToString(modelValue),
				"flds.descrip" => ViewModelConversion.ToString(modelValue),
				"flds.year" => ViewModelConversion.ToNumeric(modelValue),
				"flds.time" => ViewModelConversion.ToString(modelValue),
				"flds.date" => ViewModelConversion.ToDateTime(modelValue),
				"flds.datetime" => ViewModelConversion.ToDateTime(modelValue),
				"flds.dateseco" => ViewModelConversion.ToDateTime(modelValue),
				"flds.npassage" => ViewModelConversion.ToNumeric(modelValue),
				"flds.duration" => ViewModelConversion.ToNumeric(modelValue),
				"flds.precobil" => ViewModelConversion.ToNumeric(modelValue),
				"flds.price" => ViewModelConversion.ToNumeric(modelValue),
				"flds.ssnumber" => ViewModelConversion.ToString(modelValue),
				"flds.zipfield" => ViewModelConversion.ToString(modelValue),
				"flds.vatnumbr" => ViewModelConversion.ToString(modelValue),
				"flds.licplate" => ViewModelConversion.ToString(modelValue),
				"flds.banknmbr" => ViewModelConversion.ToString(modelValue),
				"flds.emailfld" => ViewModelConversion.ToString(modelValue),
				"flds.ibanfiel" => ViewModelConversion.ToString(modelValue),
				"flds.upprtext" => ViewModelConversion.ToString(modelValue),
				"flds.passfld" => ViewModelConversion.ToString(modelValue),
				"flds.clrpicke" => ViewModelConversion.ToString(modelValue),
				"flds.primviag" => ViewModelConversion.ToLogic(modelValue),
				"flds.logicenu" => ViewModelConversion.ToInteger(modelValue),
				"flds.creatuse" => ViewModelConversion.ToString(modelValue),
				"flds.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creatins" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creathou" => ViewModelConversion.ToString(modelValue),
				"flds.radiob" => ViewModelConversion.ToString(modelValue),
				"flds.tblcond" => ViewModelConversion.ToLogic(modelValue),
				"flds.cond" => ViewModelConversion.ToString(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM INFIELDS]/

		#endregion
	}
}
