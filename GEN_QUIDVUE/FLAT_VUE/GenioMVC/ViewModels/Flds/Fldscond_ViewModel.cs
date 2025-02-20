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
	public class Fldscond_ViewModel : FormViewModel<Models.Flds>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => true; }

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
		/// Title: "Field state" | Type: "AC"
		/// </summary>
		public string ValCond { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValCond { get; set; }
		/// <summary>
		/// Title: "Cumprir condições da tabela" | Type: "L"
		/// </summary>
		public bool ValTblcond { get; set; }
		/// <summary>
		/// Title: "Cumprir condições do formulário" | Type: "L"
		/// </summary>
		public bool ValFormcond { get; set; }
		/// <summary>
		/// Title: "Campo com condições client-side" | Type: "C"
		/// </summary>
		public string ValFclient1 { get; set; }
		/// <summary>
		/// Title: "Campo com condição de Preenchimento" | Type: "C"
		/// </summary>
		public string ValFfillwhn { get; set; }
		/// <summary>
		/// Title: "Campo com condições server-side" | Type: "DT"
		/// </summary>
		public DateTime? ValFserver1 { get; set; }
		/// <summary>
		/// Title: "Campo com condições client-side" | Type: "L"
		/// </summary>
		public bool ValFclient2 { get; set; }
		/// <summary>
		/// Title: "Campo com condições server-side" | Type: "N"
		/// </summary>
		public decimal? ValFserver2 { get; set; }
		/// <summary>
		/// Title: "Campo com condições client-side" | Type: "IB"
		/// </summary>
		[Document("ValFclient3", false, false, false, DocumentViewTypeMode.Preview)]
		public string ValFclient3 { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValFclient3fk { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValFclient3PropertiesVM { get; set; }
		/// <summary>
		/// Title: "Campo com condições server-side" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 100)]
		public GenioMVC.Models.ImageModel ValFserver3 { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[ValidateSetAccess]
		public GridTableList<GenioMVC.ViewModels.Feeca.Fldscondpseudgridtbl__ViewModel> ValGridtbl { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Field: "Description" Tipo: "MO"</summary>
		[ValidateSetAccess]
		public string ValDescrip { get; set; }

		#endregion

		public string ValCodflds { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Fldscond_ViewModel() : base(null!) { }

		public Fldscond_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFLDSCOND", nestedForm) { }

		public Fldscond_ViewModel(UserContext userContext, Models.Flds row, bool nestedForm = false) : base(userContext, "FFLDSCOND", row, nestedForm) { }

		public Fldscond_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, userContext, "FFLDSCOND", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds(userContext) { Identifier = "FFLDSCOND" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFLDSCOND");
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
			Models.Flds areaFlds = model;
			try
			{
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A"))
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFserver2).isEmptyValue(ViewModelConversion.ToNumeric(model.ValFserver2)))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFclient3).isEmptyValue(ViewModelConversion.ToString(model.ValFclient3)))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE" && HasRole("A")
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A"))
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFserver3).isEmptyValue(ViewModelConversion.ToImage(model.ValFserver3)))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
				// (FLDSCOND form condition) !isEmptyL([FLDS->FORMCOND]) && [FLDS->COND] == "REQUIRE"
				if (!isApply && (!(areaFlds.klass.ValFormcond == 0)&&areaFlds.klass.ValCond=="REQUIRE")
					&& CSGenio.business.Area.GetFieldInfo(CSGenioAflds.FldFclient2).isEmptyValue(ViewModelConversion.ToLogic(model.ValFclient2)))
				{
					var status = Status.E;
					var message = new StatusMessage(status, ""); // Message: ""
					result.MergeStatusMessage(message);
				}
			}
			catch (Exception exc)
			{
				Log.Error($"Error executing form FFLDSCOND access condition: {exc.Message}");
				throw;
			}
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
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fldscond) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValGridtbl?.MapFromModel();
				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValCond = ViewModelConversion.ToString(m.ValCond);
				ValTblcond = ViewModelConversion.ToLogic(m.ValTblcond);
				ValFormcond = ViewModelConversion.ToLogic(m.ValFormcond);
				ValFclient1 = ViewModelConversion.ToString(m.ValFclient1);
				ValFfillwhn = ViewModelConversion.ToString(m.ValFfillwhn);
				ValFserver1 = ViewModelConversion.ToDateTime(m.ValFserver1);
				ValFclient2 = ViewModelConversion.ToLogic(m.ValFclient2);
				ValFserver2 = ViewModelConversion.ToNumeric(m.ValFserver2);
				ValFclient3 = ViewModelConversion.ToString(m.ValFclient3);
				ValFclient3fk = ViewModelConversion.ToString(m.ValFclient3fk);
				ValFserver3 = ViewModelConversion.ToImage(m.ValFserver3);
				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Fldscond) - Error during mapping");
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
				CSGenio.framework.Log.Error("Map ViewModel (Fldscond) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValGridtbl?.MapToModel();
				m.ValCond = ViewModelConversion.ToString(ValCond);
				m.ValTblcond = ViewModelConversion.ToLogic(ValTblcond);
				m.ValFormcond = ViewModelConversion.ToLogic(ValFormcond);
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || !(Logical)(!(((Logical)m.ValTblcond) == 0)&&((string)m.ValCond)=="BLOCK"))
				{
					m.ValFclient1 = ViewModelConversion.ToString(ValFclient1);
				}
				m.ValFfillwhn = ViewModelConversion.ToString(ValFfillwhn);
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || !(Logical)(!(((Logical)m.ValTblcond) == 0)&&((string)m.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
				{
					m.ValFserver1 = ViewModelConversion.ToDateTime(ValFserver1);
				}
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || !(Logical)(!(((Logical)m.ValFormcond) == 0)&&((string)m.ValCond)=="BLOCK"))
				{
					m.ValFclient2 = ViewModelConversion.ToLogic(ValFclient2);
				}
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || !(Logical)(!(((Logical)m.ValFormcond) == 0)&&((string)m.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))
				{
					m.ValFserver2 = ViewModelConversion.ToNumeric(ValFserver2);
				}
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || (!(Logical)(!(((Logical)m.ValTblcond) == 0)&&((string)m.ValCond)=="BLOCK") && (!(Logical)(!(((Logical)m.ValFormcond) == 0)&&((string)m.ValCond)=="BLOCK"))))
				{
					m.ValFclient3 = ViewModelConversion.ToString(ValFclient3);
					m.ValFclient3fk = ViewModelConversion.ToString(ValFclient3fk);
				}
				// Block When condition(s)
				if (HasDisabledUserValuesSecurity || (!(Logical)(!(((Logical)m.ValTblcond) == 0)&&((string)m.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")) && (!(Logical)(!(((Logical)m.ValFormcond) == 0)&&((string)m.ValCond)=="BLOCK"&&CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"A")))))
				{
					if (ValFserver3 == null || !ValFserver3.IsThumbnail)
					m.ValFserver3 = ViewModelConversion.ToImage(ValFserver3);
				}
				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Fldscond) to Model (Flds) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "flds.cond":
						this.ValCond = ViewModelConversion.ToString(_value);
						break;
					case "flds.tblcond":
						this.ValTblcond = ViewModelConversion.ToLogic(_value);
						break;
					case "flds.formcond":
						this.ValFormcond = ViewModelConversion.ToLogic(_value);
						break;
					case "flds.fclient1":
						this.ValFclient1 = ViewModelConversion.ToString(_value);
						break;
					case "flds.ffillwhn":
						this.ValFfillwhn = ViewModelConversion.ToString(_value);
						break;
					case "flds.fserver1":
						this.ValFserver1 = ViewModelConversion.ToDateTime(_value);
						break;
					case "flds.fclient2":
						this.ValFclient2 = ViewModelConversion.ToLogic(_value);
						break;
					case "flds.fserver2":
						this.ValFserver2 = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.fclient3":
						this.ValFclient3 = ViewModelConversion.ToString(_value);
						break;
					case "flds.fserver3":
						this.ValFserver3 = ViewModelConversion.ToImage(_value);
						break;
					case "flds.codflds":
						this.ValCodflds = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Fldscond) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Fldscond)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Flds.Find(id ?? Navigation.GetStrValue("flds"), m_userContext, "FFLDSCOND"); }
			finally { Model ??= new Models.Flds(m_userContext) { Identifier = "FFLDSCOND" }; }

			ValGridtbl?.LoadModel();

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFLDSCOND");
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

			Model.Identifier = "FFLDSCOND";
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
			try
			{
				ValFclient3PropertiesVM = row.GetInfoDoc("ValFclient3");
			}
			catch (Exception)
			{
				ValFclient3PropertiesVM = new DocumsProperties_ViewModel(m_userContext);
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FFLDSCOND");
				if (Model == null)
				{
					Model = new Models.Flds(m_userContext) { Identifier = "FFLDSCOND" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FLDSCOND]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FLDSCOND]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.Merge(ValGridtbl?.Validate(), "ValGridtbl");
			validator.StringLength("ValFclient1", Resources.Resources.CAMPO_COM_CONDICOES_42569, ValFclient1, 50);
			validator.StringLength("ValFfillwhn", Resources.Resources.CAMPO_COM_CONDICAO_D59708, ValFfillwhn, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE FLDSCOND]/
		public override void Save()
		{
			try
			{
				ValGridtbl?.Save();
			}
			catch (FieldValidationException fvExc)
			{
				var sMsg = StatusMessage.Error();
				foreach (var message in fvExc.StatusMessage.GetErrorList())
					sMsg.MergeStatusMessage(new StatusMessage(message.Status, message.Message, string.Format("ValGridtbl.{0}", message.Origin)));

				throw new FieldValidationException(sMsg, fvExc.ExceptionSite);
			}


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FLDSCOND]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FLDSCOND]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FLDSCOND]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, m_userContext, "FFLDSCOND");
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
				"flds.cond" => ViewModelConversion.ToString(modelValue),
				"flds.tblcond" => ViewModelConversion.ToLogic(modelValue),
				"flds.formcond" => ViewModelConversion.ToLogic(modelValue),
				"flds.fclient1" => ViewModelConversion.ToString(modelValue),
				"flds.ffillwhn" => ViewModelConversion.ToString(modelValue),
				"flds.fserver1" => ViewModelConversion.ToDateTime(modelValue),
				"flds.fclient2" => ViewModelConversion.ToLogic(modelValue),
				"flds.fserver2" => ViewModelConversion.ToNumeric(modelValue),
				"flds.fclient3" => ViewModelConversion.ToString(modelValue),
				"flds.fserver3" => ViewModelConversion.ToImage(modelValue),
				"flds.descrip" => ViewModelConversion.ToString(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}


		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValFserver3 != null)
				ValFserver3.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaFLDS, CSGenioAflds.FldFserver3.Field, null, ValCodflds);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FLDSCOND]/

		#endregion
	}
}
