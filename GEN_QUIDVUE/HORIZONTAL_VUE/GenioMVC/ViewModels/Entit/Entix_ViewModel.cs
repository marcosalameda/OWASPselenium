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

namespace GenioMVC.ViewModels.Entit
{
	public class Entix_ViewModel : FormViewModel<Models.Entit>, IPreparableForSerialization
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
		/// Title: "Facility name" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValFirstfacilitie { get; set; }
		/// <summary>
		/// Title: "Facility name" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValLastfacilitie { get; set; }

		#endregion
		/// <summary>
		/// Title: "Legal name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Founded in" | Type: "D"
		/// </summary>
		public DateTime? ValFounded { get; set; }
		/// <summary>
		/// Title: "Company initials" | Type: "C"
		/// </summary>
		public string ValInitials { get; set; }
		/// <summary>
		/// Title: "Legal registration" | Type: "C"
		/// </summary>
		public string ValRegistra { get; set; }
		/// <summary>
		/// Title: "VAT Number" | Type: "C"
		/// </summary>
		public string ValTaxnumbe { get; set; }
		/// <summary>
		/// Title: "IBAN (International Bank Account Number)" | Type: "C"
		/// </summary>
		public string ValIban { get; set; }
		/// <summary>
		/// Title: "Phone number" | Type: "C"
		/// </summary>
		public string ValPhonenum { get; set; }
		/// <summary>
		/// Title: "Owner" | Type: "C"
		/// </summary>
		public string ValOwner { get; set; }
		/// <summary>
		/// Title: "Carrier" | Type: "L"
		/// </summary>
		public bool ValCarrier { get; set; }
		/// <summary>
		/// Title: "Supplier" | Type: "L"
		/// </summary>
		public bool ValSupplier { get; set; }
		/// <summary>
		/// Title: "Manufacturer" | Type: "L"
		/// </summary>
		public bool ValManufact { get; set; }
		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }
		/// <summary>
		/// Title: "Fax" | Type: "C"
		/// </summary>
		public string ValFax { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Web site" | Type: "C"
		/// </summary>
		public string ValWebsite { get; set; }
		/// <summary>
		/// Title: "Person/Department to contact" | Type: "C"
		/// </summary>
		public string ValPerson { get; set; }
		/// <summary>
		/// Title: "Contact telephone number" | Type: "C"
		/// </summary>
		public string ValContact { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "C"
		/// </summary>
		public string ValLanguage { get; set; }
		/// <summary>
		/// Title: "Currency" | Type: "C"
		/// </summary>
		public string ValCurrency { get; set; }
		/// <summary>
		/// Title: "Building/house number" | Type: "C"
		/// </summary>
		public string ValBuilding { get; set; }
		/// <summary>
		/// Title: "Street" | Type: "C"
		/// </summary>
		public string ValStreet { get; set; }
		/// <summary>
		/// Title: "Town/City" | Type: "C"
		/// </summary>
		public string ValTown { get; set; }
		/// <summary>
		/// Title: "County/Province" | Type: "C"
		/// </summary>
		public string ValCounty { get; set; }
		/// <summary>
		/// Title: "State/Province" | Type: "C"
		/// </summary>
		public string ValState { get; set; }
		/// <summary>
		/// Title: "ZIP/Postal code" | Type: "C"
		/// </summary>
		public string ValPostalco { get; set; }
		/// <summary>
		/// Title: "Post office box" | Type: "C"
		/// </summary>
		public string ValPobox { get; set; }
		/// <summary>
		/// Title: "Facility name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Faci1> TableFaci1Name { get; set; }
		/// <summary>
		/// Title: "Facility name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Faci2> TableFaci2Name { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodentit { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Entix_ViewModel() : base(null!) { }

		public Entix_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FENTIX", nestedForm) { }

		public Entix_ViewModel(UserContext userContext, Models.Entit row, bool nestedForm = false) : base(userContext, "FENTIX", row, nestedForm) { }

		public Entix_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("entit", id);
			Model = Models.Entit.Find(id, userContext, "FENTIX", fieldsToQuery: fieldsToLoad);
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
			Models.Entit model = new Models.Entit(userContext) { Identifier = "FENTIX" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FENTIX");
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
		public override void MapFromModel(Models.Entit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Entit) to ViewModel (Entix) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValFirstfacilitie = ViewModelConversion.ToString(m.ValFirstfacilitie);
				ValLastfacilitie = ViewModelConversion.ToString(m.ValLastfacilitie);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValFounded = ViewModelConversion.ToDateTime(m.ValFounded);
				ValInitials = ViewModelConversion.ToString(m.ValInitials);
				ValRegistra = ViewModelConversion.ToString(m.ValRegistra);
				ValTaxnumbe = ViewModelConversion.ToString(m.ValTaxnumbe);
				ValIban = ViewModelConversion.ToString(m.ValIban);
				ValPhonenum = ViewModelConversion.ToString(m.ValPhonenum);
				ValOwner = ViewModelConversion.ToString(m.ValOwner);
				ValCarrier = ViewModelConversion.ToLogic(m.ValCarrier);
				ValSupplier = ViewModelConversion.ToLogic(m.ValSupplier);
				ValManufact = ViewModelConversion.ToLogic(m.ValManufact);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValFax = ViewModelConversion.ToString(m.ValFax);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValWebsite = ViewModelConversion.ToString(m.ValWebsite);
				ValPerson = ViewModelConversion.ToString(m.ValPerson);
				ValContact = ViewModelConversion.ToString(m.ValContact);
				ValLanguage = ViewModelConversion.ToString(m.ValLanguage);
				ValCurrency = ViewModelConversion.ToString(m.ValCurrency);
				ValBuilding = ViewModelConversion.ToString(m.ValBuilding);
				ValStreet = ViewModelConversion.ToString(m.ValStreet);
				ValTown = ViewModelConversion.ToString(m.ValTown);
				ValCounty = ViewModelConversion.ToString(m.ValCounty);
				ValState = ViewModelConversion.ToString(m.ValState);
				ValPostalco = ViewModelConversion.ToString(m.ValPostalco);
				ValPobox = ViewModelConversion.ToString(m.ValPobox);
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Entit) to ViewModel (Entix) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Entit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Entix) to Model (Entit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValFounded = ViewModelConversion.ToDateTime(ValFounded);
				m.ValInitials = ViewModelConversion.ToString(ValInitials);
				m.ValRegistra = ViewModelConversion.ToString(ValRegistra);
				m.ValTaxnumbe = ViewModelConversion.ToString(ValTaxnumbe);
				m.ValIban = ViewModelConversion.ToString(ValIban);
				m.ValPhonenum = ViewModelConversion.ToString(ValPhonenum);
				m.ValOwner = ViewModelConversion.ToString(ValOwner);
				m.ValCarrier = ViewModelConversion.ToLogic(ValCarrier);
				m.ValSupplier = ViewModelConversion.ToLogic(ValSupplier);
				m.ValManufact = ViewModelConversion.ToLogic(ValManufact);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValFax = ViewModelConversion.ToString(ValFax);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValWebsite = ViewModelConversion.ToString(ValWebsite);
				m.ValPerson = ViewModelConversion.ToString(ValPerson);
				m.ValContact = ViewModelConversion.ToString(ValContact);
				m.ValLanguage = ViewModelConversion.ToString(ValLanguage);
				m.ValCurrency = ViewModelConversion.ToString(ValCurrency);
				m.ValBuilding = ViewModelConversion.ToString(ValBuilding);
				m.ValStreet = ViewModelConversion.ToString(ValStreet);
				m.ValTown = ViewModelConversion.ToString(ValTown);
				m.ValCounty = ViewModelConversion.ToString(ValCounty);
				m.ValState = ViewModelConversion.ToString(ValState);
				m.ValPostalco = ViewModelConversion.ToString(ValPostalco);
				m.ValPobox = ViewModelConversion.ToString(ValPobox);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValFirstfacilitie = ViewModelConversion.ToString(ValFirstfacilitie);
				m.ValLastfacilitie = ViewModelConversion.ToString(ValLastfacilitie);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Entix) to Model (Entit) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "entit.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "entit.founded":
						this.ValFounded = ViewModelConversion.ToDateTime(_value);
						break;
					case "entit.initials":
						this.ValInitials = ViewModelConversion.ToString(_value);
						break;
					case "entit.registra":
						this.ValRegistra = ViewModelConversion.ToString(_value);
						break;
					case "entit.taxnumbe":
						this.ValTaxnumbe = ViewModelConversion.ToString(_value);
						break;
					case "entit.iban":
						this.ValIban = ViewModelConversion.ToString(_value);
						break;
					case "entit.phonenum":
						this.ValPhonenum = ViewModelConversion.ToString(_value);
						break;
					case "entit.owner":
						this.ValOwner = ViewModelConversion.ToString(_value);
						break;
					case "entit.carrier":
						this.ValCarrier = ViewModelConversion.ToLogic(_value);
						break;
					case "entit.supplier":
						this.ValSupplier = ViewModelConversion.ToLogic(_value);
						break;
					case "entit.manufact":
						this.ValManufact = ViewModelConversion.ToLogic(_value);
						break;
					case "entit.telephon":
						this.ValTelephon = ViewModelConversion.ToString(_value);
						break;
					case "entit.fax":
						this.ValFax = ViewModelConversion.ToString(_value);
						break;
					case "entit.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "entit.website":
						this.ValWebsite = ViewModelConversion.ToString(_value);
						break;
					case "entit.person":
						this.ValPerson = ViewModelConversion.ToString(_value);
						break;
					case "entit.contact":
						this.ValContact = ViewModelConversion.ToString(_value);
						break;
					case "entit.language":
						this.ValLanguage = ViewModelConversion.ToString(_value);
						break;
					case "entit.currency":
						this.ValCurrency = ViewModelConversion.ToString(_value);
						break;
					case "entit.building":
						this.ValBuilding = ViewModelConversion.ToString(_value);
						break;
					case "entit.street":
						this.ValStreet = ViewModelConversion.ToString(_value);
						break;
					case "entit.town":
						this.ValTown = ViewModelConversion.ToString(_value);
						break;
					case "entit.county":
						this.ValCounty = ViewModelConversion.ToString(_value);
						break;
					case "entit.state":
						this.ValState = ViewModelConversion.ToString(_value);
						break;
					case "entit.postalco":
						this.ValPostalco = ViewModelConversion.ToString(_value);
						break;
					case "entit.pobox":
						this.ValPobox = ViewModelConversion.ToString(_value);
						break;
					case "entit.codentit":
						this.ValCodentit = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Entix) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Entix)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Entit.Find(id ?? Navigation.GetStrValue("entit"), m_userContext, "FENTIX"); }
			finally { Model ??= new Models.Entit(m_userContext) { Identifier = "FENTIX" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Entit.Find(Navigation.GetStrValue("entit"), m_userContext, "FENTIX");
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

			Model.Identifier = "FENTIX";
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

		protected override void LoadDocumentsProperties(Models.Entit row)
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
				Model = Models.Entit.Find(Navigation.GetStrValue("entit"), m_userContext, "FENTIX");
				if (Model == null)
				{
					Model = new Models.Entit(m_userContext) { Identifier = "FENTIX" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("entit");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Entix___faci1name____(qs, lazyLoad);
			Load_Entix___faci2name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ENTIX]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ENTIX]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.LEGAL_NAME42902, ValName, 85);

			validator.Required("ValName", Resources.Resources.LEGAL_NAME42902, ViewModelConversion.ToString(ValName), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValInitials", Resources.Resources.COMPANY_INITIALS56204, ValInitials, 10);
			validator.StringLength("ValRegistra", Resources.Resources.LEGAL_REGISTRATION04413, ValRegistra, 30);
			validator.StringLength("ValTaxnumbe", Resources.Resources.VAT_NUMBER24236, ValTaxnumbe, 30);
			validator.StringLength("ValIban", Resources.Resources.IBAN__INTERNATIONAL_45066, ValIban, 33);
			validator.StringLength("ValPhonenum", Resources.Resources.PHONE_NUMBER20774, ValPhonenum, 20);
			validator.StringLength("ValOwner", Resources.Resources.OWNER09558, ValOwner, 50);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValFax", Resources.Resources.FAX08532, ValFax, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL25170, ValEmail, 254);
			validator.StringLength("ValWebsite", Resources.Resources.WEB_SITE06263, ValWebsite, 254);
			validator.Hyperlink(Resources.Resources.WEB_SITE06263, ValWebsite);
			validator.StringLength("ValPerson", Resources.Resources.PERSON_DEPARTMENT_TO28777, ValPerson, 85);
			validator.StringLength("ValContact", Resources.Resources.CONTACT_TELEPHONE_NU12694, ValContact, 30);
			validator.StringLength("ValLanguage", Resources.Resources.LANGUAGE16872, ValLanguage, 2);
			validator.StringLength("ValCurrency", Resources.Resources.CURRENCY13881, ValCurrency, 3);
			validator.StringLength("ValBuilding", Resources.Resources.BUILDING_HOUSE_NUMBE20738, ValBuilding, 25);
			validator.StringLength("ValStreet", Resources.Resources.STREET44324, ValStreet, 50);
			validator.StringLength("ValTown", Resources.Resources.TOWN_CITY16259, ValTown, 50);
			validator.StringLength("ValCounty", Resources.Resources.COUNTY_PROVINCE34285, ValCounty, 50);
			validator.StringLength("ValState", Resources.Resources.STATE_PROVINCE28516, ValState, 50);
			validator.StringLength("ValPostalco", Resources.Resources.ZIP_POSTAL_CODE55613, ValPostalco, 10);
			validator.StringLength("ValPobox", Resources.Resources.POST_OFFICE_BOX06223, ValPobox, 5);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ENTIX]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ENTIX]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ENTIX]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ENTIX]/
		public override void Destroy(string id)
		{
			Model = Models.Entit.Find(id, m_userContext, "FENTIX");
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

		/// <summary>
		/// TableFaci1Name -> (F1)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Entix___faci1name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool entix___faci1name____DoLoad = true;
			CriteriaSet entix___faci1name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("faci1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					entix___faci1name____Conds.Equal(CSGenioAfaci1.FldCodfacil, hValue);
					this.ValFirstfacilitie = DBConversion.ToString(hValue);
				}
			}

			TableFaci1Name = new TableDBEdit<Models.Faci1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_faci1") != null)
				{
					this.ValFirstfacilitie = Navigation.GetStrValue("RETURN_faci1");
					Navigation.CurrentLevel.SetEntry("RETURN_faci1", null);
				}
				FillDependant_EntixTableFaci1Name(lazyLoad);
				return;
			}

			if (entix___faci1name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableFaci1Name, "sTableFaci1Name", "dTableFaci1Name", qs, "faci1");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFaci1Name_tableFilters"]))
					TableFaci1Name.TableFilters = bool.Parse(qs["TableFaci1Name_tableFilters"]);
				else
					TableFaci1Name.TableFilters = false;

				query = qs["qTableFaci1Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfaci1.FldName, query + "%");
				}
				entix___faci1name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFaci1Name"] != null ? qs["pTableFaci1Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName, CSGenioAfaci1.FldZzstate];

// USE /[MANUAL GQT OVERRQ ENTIX_FACI1NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("faci1", FormMode.New) || Navigation.checkFormMode("faci1", FormMode.Duplicate))
					entix___faci1name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfaci1.FldZzstate, 0)
						.Equal(CSGenioAfaci1.FldCodfacil, Navigation.GetStrValue("faci1")));
				else
					entix___faci1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfaci1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAfaci1> listing = Models.ModelBase.Where<CSGenioAfaci1>(m_userContext, false, entix___faci1name____Conds, fields, offset, numberItems, sorts, "LED_ENTIX___FACI1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFaci1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFaci1Name.Query = query;
				TableFaci1Name.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Faci1(m_userContext, r, true, _fieldsToSerialize_ENTIX___FACI1NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_faci1") != null)
				{
					this.ValFirstfacilitie = Navigation.GetStrValue("RETURN_faci1");
					Navigation.CurrentLevel.SetEntry("RETURN_faci1", null);
				}

				TableFaci1Name.List = new SelectList(TableFaci1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodfacil,  x => x.ValCodfacil == this.ValFirstfacilitie), "Value", "Text", this.ValFirstfacilitie);
				FillDependant_EntixTableFaci1Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFaci1Name (F1)
		/// </summary>
		/// <param name="PKey">Primary Key of Faci1</param>
		public ConcurrentDictionary<string, object> GetDependant_EntixTableFaci1Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfaci1.FldCodfacil, CSGenioAfaci1.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAfaci1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfaci1.FldCodfacil, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFaci1Name (F1)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EntixTableFaci1Name(bool lazyLoad = false)
		{
			var row = GetDependant_EntixTableFaci1Name(this.ValFirstfacilitie);
			try
			{

				// Fill List fields
				this.ValFirstfacilitie = ViewModelConversion.ToString(row["faci1.codfacil"]);
				TableFaci1Name.Value = (string)row["faci1.name"];
				if (GenFunctions.emptyG(this.ValFirstfacilitie) == 1)
				{
					this.ValFirstfacilitie = "";
					TableFaci1Name.Value = "";
					Navigation.ClearValue("faci1");
				}
				else if (lazyLoad)
				{
					TableFaci1Name.SetPagination(1, 0, false, false, 1);
					TableFaci1Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValFirstfacilitie),
							Text = Convert.ToString(TableFaci1Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValFirstfacilitie);
				}

				TableFaci1Name.Selected = this.ValFirstfacilitie;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFaci1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ENTIX___FACI1NAME____ = ["Faci1", "Faci1.ValCodfacil", "Faci1.ValZzstate"];

		/// <summary>
		/// TableFaci2Name -> (F1)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Entix___faci2name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool entix___faci2name____DoLoad = true;
			CriteriaSet entix___faci2name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("faci2", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					entix___faci2name____Conds.Equal(CSGenioAfaci2.FldCodfacil, hValue);
					this.ValLastfacilitie = DBConversion.ToString(hValue);
				}
			}

			TableFaci2Name = new TableDBEdit<Models.Faci2>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_faci2") != null)
				{
					this.ValLastfacilitie = Navigation.GetStrValue("RETURN_faci2");
					Navigation.CurrentLevel.SetEntry("RETURN_faci2", null);
				}
				FillDependant_EntixTableFaci2Name(lazyLoad);
				return;
			}

			if (entix___faci2name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableFaci2Name, "sTableFaci2Name", "dTableFaci2Name", qs, "faci2");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFaci2Name_tableFilters"]))
					TableFaci2Name.TableFilters = bool.Parse(qs["TableFaci2Name_tableFilters"]);
				else
					TableFaci2Name.TableFilters = false;

				query = qs["qTableFaci2Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfaci2.FldName, query + "%");
				}
				entix___faci2name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFaci2Name"] != null ? qs["pTableFaci2Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName, CSGenioAfaci2.FldZzstate];

// USE /[MANUAL GQT OVERRQ ENTIX_FACI2NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("faci2", FormMode.New) || Navigation.checkFormMode("faci2", FormMode.Duplicate))
					entix___faci2name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfaci2.FldZzstate, 0)
						.Equal(CSGenioAfaci2.FldCodfacil, Navigation.GetStrValue("faci2")));
				else
					entix___faci2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfaci2.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAfaci2> listing = Models.ModelBase.Where<CSGenioAfaci2>(m_userContext, false, entix___faci2name____Conds, fields, offset, numberItems, sorts, "LED_ENTIX___FACI2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFaci2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFaci2Name.Query = query;
				TableFaci2Name.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Faci2(m_userContext, r, true, _fieldsToSerialize_ENTIX___FACI2NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_faci2") != null)
				{
					this.ValLastfacilitie = Navigation.GetStrValue("RETURN_faci2");
					Navigation.CurrentLevel.SetEntry("RETURN_faci2", null);
				}

				TableFaci2Name.List = new SelectList(TableFaci2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodfacil,  x => x.ValCodfacil == this.ValLastfacilitie), "Value", "Text", this.ValLastfacilitie);
				FillDependant_EntixTableFaci2Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFaci2Name (F1)
		/// </summary>
		/// <param name="PKey">Primary Key of Faci2</param>
		public ConcurrentDictionary<string, object> GetDependant_EntixTableFaci2Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfaci2.FldCodfacil, CSGenioAfaci2.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAfaci2 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfaci2.FldCodfacil, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFaci2Name (F1)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EntixTableFaci2Name(bool lazyLoad = false)
		{
			var row = GetDependant_EntixTableFaci2Name(this.ValLastfacilitie);
			try
			{

				// Fill List fields
				this.ValLastfacilitie = ViewModelConversion.ToString(row["faci2.codfacil"]);
				TableFaci2Name.Value = (string)row["faci2.name"];
				if (GenFunctions.emptyG(this.ValLastfacilitie) == 1)
				{
					this.ValLastfacilitie = "";
					TableFaci2Name.Value = "";
					Navigation.ClearValue("faci2");
				}
				else if (lazyLoad)
				{
					TableFaci2Name.SetPagination(1, 0, false, false, 1);
					TableFaci2Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValLastfacilitie),
							Text = Convert.ToString(TableFaci2Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValLastfacilitie);
				}

				TableFaci2Name.Selected = this.ValLastfacilitie;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFaci2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ENTIX___FACI2NAME____ = ["Faci2", "Faci2.ValCodfacil", "Faci2.ValZzstate"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"entit.firstfacilitie" => ViewModelConversion.ToString(modelValue),
				"entit.lastfacilitie" => ViewModelConversion.ToString(modelValue),
				"entit.name" => ViewModelConversion.ToString(modelValue),
				"entit.founded" => ViewModelConversion.ToDateTime(modelValue),
				"entit.initials" => ViewModelConversion.ToString(modelValue),
				"entit.registra" => ViewModelConversion.ToString(modelValue),
				"entit.taxnumbe" => ViewModelConversion.ToString(modelValue),
				"entit.iban" => ViewModelConversion.ToString(modelValue),
				"entit.phonenum" => ViewModelConversion.ToString(modelValue),
				"entit.owner" => ViewModelConversion.ToString(modelValue),
				"entit.carrier" => ViewModelConversion.ToLogic(modelValue),
				"entit.supplier" => ViewModelConversion.ToLogic(modelValue),
				"entit.manufact" => ViewModelConversion.ToLogic(modelValue),
				"entit.telephon" => ViewModelConversion.ToString(modelValue),
				"entit.fax" => ViewModelConversion.ToString(modelValue),
				"entit.email" => ViewModelConversion.ToString(modelValue),
				"entit.website" => ViewModelConversion.ToString(modelValue),
				"entit.person" => ViewModelConversion.ToString(modelValue),
				"entit.contact" => ViewModelConversion.ToString(modelValue),
				"entit.language" => ViewModelConversion.ToString(modelValue),
				"entit.currency" => ViewModelConversion.ToString(modelValue),
				"entit.building" => ViewModelConversion.ToString(modelValue),
				"entit.street" => ViewModelConversion.ToString(modelValue),
				"entit.town" => ViewModelConversion.ToString(modelValue),
				"entit.county" => ViewModelConversion.ToString(modelValue),
				"entit.state" => ViewModelConversion.ToString(modelValue),
				"entit.postalco" => ViewModelConversion.ToString(modelValue),
				"entit.pobox" => ViewModelConversion.ToString(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"faci1.codfacil" => ViewModelConversion.ToString(modelValue),
				"faci1.name" => ViewModelConversion.ToString(modelValue),
				"faci2.codfacil" => ViewModelConversion.ToString(modelValue),
				"faci2.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ENTIX]/

		#endregion
	}
}
