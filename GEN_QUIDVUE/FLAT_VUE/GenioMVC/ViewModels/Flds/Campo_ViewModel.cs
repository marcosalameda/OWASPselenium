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
	public class Campo_ViewModel : FormViewModel<Models.Flds>, IPreparableForSerialization
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
		/// Title: "Airline" | Type: "CE"
		/// </summary>
		public string ValCodaero { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodequip { get; set; }

		#endregion

		/// <summary>
		/// Title: "Airline" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Aero> TableAeroName { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescrip { get; set; }
		/// <summary>
		/// Title: "Passenger capacity on the plane" | Type: "N"
		/// </summary>
		public decimal? ValNpassage { get; set; }
		/// <summary>
		/// Title: "Trip Duration" | Type: "ND"
		/// </summary>
		public decimal? ValDuration { get; set; }
		/// <summary>
		/// Title: "Rounded Ticket Price" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Ticket price at tenths" | Type: "$D"
		/// </summary>
		public decimal? ValPrecobil { get; set; }
		/// <summary>
		/// Title: "Departure date (DD/MM/YEAR)" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "Departure date (hour)" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetime { get; set; }
		/// <summary>
		/// Title: "Departure date (seconds)" | Type: "DS"
		/// </summary>
		public DateTime? ValDateseco { get; set; }
		/// <summary>
		/// Title: "Departure hour" | Type: "T"
		/// </summary>
		public string ValTime { get; set; }
		/// <summary>
		/// Title: "Creation year of the airport" | Type: "N"
		/// </summary>
		public decimal? ValYear { get; set; }
		/// <summary>
		/// Title: "1ªViagem" | Type: "L"
		/// </summary>
		public bool ValPrimviag { get; set; }
		/// <summary>
		/// Title: "Have you traveled before?" | Type: "IF"
		/// </summary>
		public decimal ValConditio { get; set; }
		/// <summary>
		/// Title: "Class (Enumeração de Texto)" | Type: "AC"
		/// </summary>
		public string ValClass { get; set; }
		/// <summary>
		/// Title: "Classe (Enumeração Numérica)" | Type: "AN"
		/// </summary>
		public decimal ValClassnum { get; set; }
		/// <summary>
		/// Title: "1st trip (Logical Enumeration)" | Type: "AL"
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
		[Document("ValAttach", true, false, false, DocumentViewTypeMode.Print)]
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
		/// Title: "Creation Date (DD/MM/YY)" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatdat { get; set; }
		/// <summary>
		/// Title: "Creation Date" | Type: "OT"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreathou { get; set; }
		/// <summary>
		/// Title: "Complete Creation Date" | Type: "OI"
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
		public Campo_ViewModel() : base(null!) { }

		public Campo_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCAMPO", nestedForm) { }

		public Campo_ViewModel(UserContext userContext, Models.Flds row, bool nestedForm = false) : base(userContext, "FCAMPO", row, nestedForm) { }

		public Campo_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("flds", id);
			Model = Models.Flds.Find(id, userContext, "FCAMPO", fieldsToQuery: fieldsToLoad);
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
			Models.Flds model = new Models.Flds(userContext) { Identifier = "FCAMPO" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCAMPO");
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
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Campo) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodaero = ViewModelConversion.ToString(m.ValCodaero);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
				ValDescrip = ViewModelConversion.ToString(m.ValDescrip);
				ValNpassage = ViewModelConversion.ToNumeric(m.ValNpassage);
				ValDuration = ViewModelConversion.ToNumeric(m.ValDuration);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValPrecobil = ViewModelConversion.ToNumeric(m.ValPrecobil);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDatetime = ViewModelConversion.ToDateTime(m.ValDatetime);
				ValDateseco = ViewModelConversion.ToDateTime(m.ValDateseco);
				ValTime = ViewModelConversion.ToString(m.ValTime);
				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
				ValPrimviag = ViewModelConversion.ToLogic(m.ValPrimviag);
				ValConditio = ViewModelConversion.ToNumeric(m.ValConditio);
				ValClass = ViewModelConversion.ToString(m.ValClass);
				ValClassnum = ViewModelConversion.ToNumeric(m.ValClassnum);
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
				CSGenio.framework.Log.Error("Map Model (Flds) to ViewModel (Campo) - Error during mapping");
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
				CSGenio.framework.Log.Error("Map ViewModel (Campo) to Model (Flds) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodaero = ViewModelConversion.ToString(ValCodaero);
				m.ValDescrip = ViewModelConversion.ToString(ValDescrip);
				m.ValNpassage = ViewModelConversion.ToNumeric(ValNpassage);
				m.ValDuration = ViewModelConversion.ToNumeric(ValDuration);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValPrecobil = ViewModelConversion.ToNumeric(ValPrecobil);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetime = ViewModelConversion.ToDateTime(ValDatetime);
				m.ValDateseco = ViewModelConversion.ToDateTime(ValDateseco);
				m.ValTime = ViewModelConversion.ToString(ValTime);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValPrimviag = ViewModelConversion.ToLogic(ValPrimviag);
				m.ValConditio = ViewModelConversion.ToNumeric(ValConditio);
				m.ValClass = ViewModelConversion.ToString(ValClass);
				m.ValClassnum = ViewModelConversion.ToNumeric(ValClassnum);
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

				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);
				m.ValCreatuse = ViewModelConversion.ToString(ValCreatuse);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreathou = ViewModelConversion.ToString(ValCreathou);
				m.ValCreatins = ViewModelConversion.ToDateTime(ValCreatins);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Campo) to Model (Flds) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "flds.codaero":
						this.ValCodaero = ViewModelConversion.ToString(_value);
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
					case "flds.year":
						this.ValYear = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.primviag":
						this.ValPrimviag = ViewModelConversion.ToLogic(_value);
						break;
					case "flds.conditio":
						this.ValConditio = ViewModelConversion.ToNumeric(_value);
						break;
					case "flds.class":
						this.ValClass = ViewModelConversion.ToString(_value);
						break;
					case "flds.classnum":
						this.ValClassnum = ViewModelConversion.ToNumeric(_value);
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
						Log.Error($"SetViewModelValue (Campo) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Campo)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Flds.Find(id ?? Navigation.GetStrValue("flds"), m_userContext, "FCAMPO"); }
			finally { Model ??= new Models.Flds(m_userContext) { Identifier = "FCAMPO" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FCAMPO");
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

			Model.Identifier = "FCAMPO";
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
				Model = Models.Flds.Find(Navigation.GetStrValue("flds"), m_userContext, "FCAMPO");
				if (Model == null)
				{
					Model = new Models.Flds(m_userContext) { Identifier = "FCAMPO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("flds");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Campo___aero_name____(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL CAMPO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW CAMPO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE CAMPO]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY CAMPO]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE CAMPO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY CAMPO]/
		public override void Destroy(string id)
		{
			Model = Models.Flds.Find(id, m_userContext, "FCAMPO");
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
		/// TableAeroName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Campo___aero_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool campo___aero_name____DoLoad = true;
			CriteriaSet campo___aero_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("aero", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					campo___aero_name____Conds.Equal(CSGenioAaero.FldCodaero, hValue);
					this.ValCodaero = DBConversion.ToString(hValue);
				}
			}

			TableAeroName = new TableDBEdit<Models.Aero>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}
				FillDependant_CampoTableAeroName(lazyLoad);
				return;
			}

			if (campo___aero_name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableAeroName, "sTableAeroName", "dTableAeroName", qs, "aero");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAaero.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAeroName_tableFilters"]))
					TableAeroName.TableFilters = bool.Parse(qs["TableAeroName_tableFilters"]);
				else
					TableAeroName.TableFilters = false;

				query = qs["qTableAeroName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAaero.FldName, query + "%");
				}
				campo___aero_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAeroName"] != null ? qs["pTableAeroName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAaero.FldCodaero, CSGenioAaero.FldName, CSGenioAaero.FldZzstate];

// USE /[MANUAL GQT OVERRQ CAMPO_AERONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("aero", FormMode.New) || Navigation.checkFormMode("aero", FormMode.Duplicate))
					campo___aero_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAaero.FldZzstate, 0)
						.Equal(CSGenioAaero.FldCodaero, Navigation.GetStrValue("aero")));
				else
					campo___aero_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAaero.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("aero", "name");
				ListingMVC<CSGenioAaero> listing = Models.ModelBase.Where<CSGenioAaero>(m_userContext, false, campo___aero_name____Conds, fields, offset, numberItems, sorts, "LED_CAMPO___AERO_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAeroName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAeroName.Query = query;
				TableAeroName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Aero(m_userContext, r, true, _fieldsToSerialize_CAMPO___AERO_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_aero") != null)
				{
					this.ValCodaero = Navigation.GetStrValue("RETURN_aero");
					Navigation.CurrentLevel.SetEntry("RETURN_aero", null);
				}

				TableAeroName.List = new SelectList(TableAeroName.Elements.ToSelectList(x => x.ValName, x => x.ValCodaero,  x => x.ValCodaero == this.ValCodaero), "Value", "Text", this.ValCodaero);
				FillDependant_CampoTableAeroName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAeroName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Aero</param>
		public ConcurrentDictionary<string, object> GetDependant_CampoTableAeroName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAaero.FldCodaero, CSGenioAaero.FldName];

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

			CSGenioAaero tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAaero.FldCodaero, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAeroName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_CampoTableAeroName(bool lazyLoad = false)
		{
			var row = GetDependant_CampoTableAeroName(this.ValCodaero);
			try
			{

				// Fill List fields
				this.ValCodaero = ViewModelConversion.ToString(row["aero.codaero"]);
				TableAeroName.Value = (string)row["aero.name"];
				if (GenFunctions.emptyG(this.ValCodaero) == 1)
				{
					this.ValCodaero = "";
					TableAeroName.Value = "";
					Navigation.ClearValue("aero");
				}
				else if (lazyLoad)
				{
					TableAeroName.SetPagination(1, 0, false, false, 1);
					TableAeroName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodaero),
							Text = Convert.ToString(TableAeroName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodaero);
				}

				TableAeroName.Selected = this.ValCodaero;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAeroName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CAMPO___AERO_NAME____ = ["Aero", "Aero.ValCodaero", "Aero.ValZzstate", "Aero.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"flds.codaero" => ViewModelConversion.ToString(modelValue),
				"flds.codequip" => ViewModelConversion.ToString(modelValue),
				"flds.descrip" => ViewModelConversion.ToString(modelValue),
				"flds.npassage" => ViewModelConversion.ToNumeric(modelValue),
				"flds.duration" => ViewModelConversion.ToNumeric(modelValue),
				"flds.price" => ViewModelConversion.ToNumeric(modelValue),
				"flds.precobil" => ViewModelConversion.ToNumeric(modelValue),
				"flds.date" => ViewModelConversion.ToDateTime(modelValue),
				"flds.datetime" => ViewModelConversion.ToDateTime(modelValue),
				"flds.dateseco" => ViewModelConversion.ToDateTime(modelValue),
				"flds.time" => ViewModelConversion.ToString(modelValue),
				"flds.year" => ViewModelConversion.ToNumeric(modelValue),
				"flds.primviag" => ViewModelConversion.ToLogic(modelValue),
				"flds.conditio" => ViewModelConversion.ToNumeric(modelValue),
				"flds.class" => ViewModelConversion.ToString(modelValue),
				"flds.classnum" => ViewModelConversion.ToNumeric(modelValue),
				"flds.logicenu" => ViewModelConversion.ToInteger(modelValue),
				"flds.logo" => ViewModelConversion.ToImage(modelValue),
				"flds.attach" => ViewModelConversion.ToString(modelValue),
				"flds.creatuse" => ViewModelConversion.ToString(modelValue),
				"flds.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"flds.creathou" => ViewModelConversion.ToString(modelValue),
				"flds.creatins" => ViewModelConversion.ToDateTime(modelValue),
				"flds.codflds" => ViewModelConversion.ToString(modelValue),
				"aero.codaero" => ViewModelConversion.ToString(modelValue),
				"aero.name" => ViewModelConversion.ToString(modelValue),
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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM CAMPO]/

		#endregion
	}
}
