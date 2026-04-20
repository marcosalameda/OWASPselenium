using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Flds
{
	public class Listacam_ViewModel : FormViewModel<Models.Flds>, IPreparableForSerialization
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
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescrip { get; set; }
		/// <summary>
		/// Title: "Numeric" | Type: "N"
		/// </summary>
		public decimal? ValNpassage { get; set; }
		/// <summary>
		/// Title: "Numeric Decimal" | Type: "ND"
		/// </summary>
		public decimal? ValDuration { get; set; }
		/// <summary>
		/// Title: "Currency" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Currency Decimal" | Type: "$D"
		/// </summary>
		public decimal? ValPrecobil { get; set; }
		/// <summary>
		/// Title: "Year" | Type: "N"
		/// </summary>
		public decimal? ValYear { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Date Time" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetime { get; set; }
		/// <summary>
		/// Title: "Date seconds" | Type: "DS"
		/// </summary>
		public DateTime? ValDateseco { get; set; }
		/// <summary>
		/// Title: "Time" | Type: "T"
		/// </summary>
		public string ValTime { get; set; }
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
		/// Title: "Social Security No" | Type: "C"
		/// </summary>
		public string ValSsnumber { get; set; }
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
		/// Title: "Numeric enumeration" | Type: "AN"
		/// </summary>
		public decimal ValClassnum { get; set; }
		/// <summary>
		/// Title: "Text Enumeration" | Type: "AC"
		/// </summary>
		public string ValClass { get; set; }
		/// <summary>
		/// Title: "Logical Enumeration" | Type: "AL"
		/// </summary>
		public int ValLogicenu { get; set; }
		/// <summary>
		/// Title: "Logo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValLogo { get; set; }
		/// <summary>
		/// Title: "Attachments" | Type: "IB"
		/// </summary>
		[Document("ValAttach", true, false, false, DocumentViewTypeMode.Preview)]
		public string ValAttach { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValAttachfk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValAttachPropertiesVM { get; set; }
		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreatuse { get; set; }
		/// <summary>
		/// Title: "Date of Creation" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatdat { get; set; }
		/// <summary>
		/// Title: "Creation hour" | Type: "OT"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreathou { get; set; }
		/// <summary>
		/// Title: "Complete Date of Creation" | Type: "OI"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatins { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodflds { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Listacam_ViewModel() : base(null!) { }

		public Listacam_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLISTACAM", nestedForm) { }

		public Listacam_ViewModel(UserContext userContext, Models.Flds row, bool nestedForm = false) : base(userContext, "FLISTACAM", row, nestedForm) { }

		public Listacam_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, userContext, "FLISTACAM", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds(userContext) { Identifier = "FLISTACAM" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLISTACAM");
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

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Listacam) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValTxtfield = ViewModelConversion.ToString(m.ValTxtfield);
				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
				ValTime = ViewModelConversion.ToString(m.ValTime);
				ValZipfield = ViewModelConversion.ToString(m.ValZipfield);
				ValVatnumbr = ViewModelConversion.ToString(m.ValVatnumbr);
				ValLicplate = ViewModelConversion.ToString(m.ValLicplate);
				ValSsnumber = ViewModelConversion.ToString(m.ValSsnumber);
				ValBanknmbr = ViewModelConversion.ToString(m.ValBanknmbr);
				ValEmailfld = ViewModelConversion.ToString(m.ValEmailfld);
				ValIbanfiel = ViewModelConversion.ToString(m.ValIbanfiel);
				ValUpprtext = ViewModelConversion.ToString(m.ValUpprtext);
				ValClassnum = ViewModelConversion.ToNumeric(m.ValClassnum);
				ValClass = ViewModelConversion.ToString(m.ValClass);
				ValLogicenu = ViewModelConversion.ToInteger(m.ValLogicenu);
				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
				ValAttach = ViewModelConversion.ToString(m.ValAttach);
				ValAttachfk = ViewModelConversion.ToString(m.ValAttachfk);
				ValCreatuse = ViewModelConversion.ToString(m.ValCreatuse);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValCreathou = ViewModelConversion.ToString(m.ValCreathou);
				ValCreatins = ViewModelConversion.ToDateTime(m.ValCreatins);
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Listacam) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Flds m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Listacam) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValTxtfield = ViewModelConversion.ToString(ValTxtfield);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValZipfield = ViewModelConversion.ToString(ValZipfield);
				m.ValVatnumbr = ViewModelConversion.ToString(ValVatnumbr);
				m.ValLicplate = ViewModelConversion.ToString(ValLicplate);
				m.ValSsnumber = ViewModelConversion.ToString(ValSsnumber);
				m.ValBanknmbr = ViewModelConversion.ToString(ValBanknmbr);
				m.ValEmailfld = ViewModelConversion.ToString(ValEmailfld);
				m.ValIbanfiel = ViewModelConversion.ToString(ValIbanfiel);
				m.ValUpprtext = ViewModelConversion.ToString(ValUpprtext);
				m.ValClassnum = ViewModelConversion.ToNumeric(ValClassnum);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValLogicenu = ViewModelConversion.ToInteger(ValLogicenu);
				if (ValLogo == null || !ValLogo.IsThumbnail)
					m.ValLogo = ViewModelConversion.ToImage(ValLogo);
				m.ValAttach = ViewModelConversion.ToString(ValAttach);
				m.ValAttachfk = ViewModelConversion.ToString(ValAttachfk);
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
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Listacam) to Model (Flds) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <inheritdoc />
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
					case "flds.npassage":
						this.ValNpassage = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.duration":
						this.ValDuration = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.precobil":
						this.ValPrecobil = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.year":
						this.ValYear = ViewModelConversion.ToNumeric(_value);
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
					case "flds.time":
						this.ValTime = ViewModelConversion.ToString(_value);
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
					case "flds.ssnumber":
						this.ValSsnumber = ViewModelConversion.ToString(_value);
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
					case "flds.classnum":
						this.ValClassnum = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.class":
						this.ValClass = ViewModelConversion.ToString(_value);
						break;
					case "flds.logicenu":
						this.ValLogicenu = ViewModelConversion.ToInteger(_value);
						break;
					case "flds.logo":
						this.ValLogo = ViewModelConversion.ToImage(_value);
						break;
					case "flds.attach":
						this.ValAttach = ViewModelConversion.ToString(_value);
						break;
					case "flds.codflds":
						this.ValCodflds = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Listacam) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Listacam)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Flds.Find(id ?? Navigation.GetStrValue("flds"), m_userContext, "FLISTACAM"); }
			finally { Model ??= new Models.Flds(m_userContext) { Identifier = "FLISTACAM" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FLISTACAM");
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

			Model.Identifier = "FLISTACAM";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

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
			try
			{
				ValAttachPropertiesVM = row.GetInfoDoc("ValAttach");
			}
			catch (Exception)
			{
				ValAttachPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
			}
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FLISTACAM");
				if (Model == null)
				{
					Model = new Models.Flds(m_userContext) { Identifier = "FLISTACAM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();


// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LISTACAM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LISTACAM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTxtfield", Resources.Resources.TEXT_FIELD41810, ValTxtfield, 50);
			validator.StringLength("ValZipfield", Resources.Resources.ZIPCODE21021, ValZipfield, 8);
			validator.StringLength("ValVatnumbr", Resources.Resources.VAT_NUMBER24236, ValVatnumbr, 9);
			validator.StringLength("ValLicplate", Resources.Resources.LICENCE_PLATE07627, ValLicplate, 8);
			validator.StringLength("ValSsnumber", Resources.Resources.SOCIAL_SECURITY_NO48150, ValSsnumber, 11);
			validator.StringLength("ValBanknmbr", Resources.Resources.BANKING_ACCOUNT_NUMB62548, ValBanknmbr, 24);
			validator.StringLength("ValEmailfld", Resources.Resources.EMAIL25170, ValEmailfld, 50);
			validator.StringLength("ValIbanfiel", Resources.Resources.IBAN28506, ValIbanfiel, 34);
			validator.StringLength("ValUpprtext", Resources.Resources.UPPERCASE48238, ValUpprtext, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE LISTACAM]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LISTACAM]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LISTACAM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LISTACAM]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, m_userContext, "FLISTACAM");
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
				"flds.npassage" => ViewModelConversion.ToNumeric(modelValue),
				"flds.duration" => ViewModelConversion.ToNumeric(modelValue),
				"flds.price" => ViewModelConversion.ToNumeric(modelValue),
				"flds.precobil" => ViewModelConversion.ToNumeric(modelValue),
				"flds.year" => ViewModelConversion.ToNumeric(modelValue),
				"flds.date" => ViewModelConversion.ToDateTime(modelValue),
				"flds.datetime" => ViewModelConversion.ToDateTime(modelValue),
				"flds.dateseco" => ViewModelConversion.ToDateTime(modelValue),
				"flds.time" => ViewModelConversion.ToString(modelValue),
				"flds.zipfield" => ViewModelConversion.ToString(modelValue),
				"flds.vatnumbr" => ViewModelConversion.ToString(modelValue),
				"flds.licplate" => ViewModelConversion.ToString(modelValue),
				"flds.ssnumber" => ViewModelConversion.ToString(modelValue),
				"flds.banknmbr" => ViewModelConversion.ToString(modelValue),
				"flds.emailfld" => ViewModelConversion.ToString(modelValue),
				"flds.ibanfiel" => ViewModelConversion.ToString(modelValue),
				"flds.upprtext" => ViewModelConversion.ToString(modelValue),
				"flds.classnum" => ViewModelConversion.ToNumeric(modelValue),
				"flds.class" => ViewModelConversion.ToString(modelValue),
				"flds.logicenu" => ViewModelConversion.ToInteger(modelValue),
				"flds.logo" => ViewModelConversion.ToImage(modelValue),
				"flds.attach" => ViewModelConversion.ToString(modelValue),
				"flds.creatuse" => ViewModelConversion.ToString(modelValue),
				"flds.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creathou" => ViewModelConversion.ToString(modelValue),
				"flds.creatins" => ViewModelConversion.ToDateTime(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValLogo != null)
				ValLogo.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaFLDS, CSGenioAflds.FldLogo.Field, null, ValCodflds);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LISTACAM]/

		#endregion
	}
}
