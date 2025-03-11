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

namespace GenioMVC.ViewModels.Cmpny
{
	public class Empre_ViewModel : FormViewModel<Models.Cmpny>, IPreparableForSerialization
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
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

		#endregion
		/// <summary>
		/// Title: "Logo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValLogo { get; set; }
		/// <summary>
		/// Title: "Designation" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }
		/// <summary>
		/// Title: "Acronym" | Type: "C"
		/// </summary>
		public string ValAcronym { get; set; }
		/// <summary>
		/// Title: "Tax identification:" | Type: "C"
		/// </summary>
		public string ValNif { get; set; }
		/// <summary>
		/// Title: "Telephone" | Type: "C"
		/// </summary>
		public string ValTelephon { get; set; }
		/// <summary>
		/// Title: "Email:" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }
		/// <summary>
		/// Title: "Quantity of people" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValQtdpesso { get; set; }
		/// <summary>
		/// Title: "Headquarter location" | Type: "GG"
		/// </summary>
		public string ValHeadloc { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodempre { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Empre_ViewModel() : base(null!) { }

		public Empre_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEMPRE", nestedForm) { }

		public Empre_ViewModel(UserContext userContext, Models.Cmpny row, bool nestedForm = false) : base(userContext, "FEMPRE", row, nestedForm) { }

		public Empre_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("cmpny", id);
			Model = Models.Cmpny.Find(id, userContext, "FEMPRE", fieldsToQuery: fieldsToLoad);
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
			Models.Cmpny model = new Models.Cmpny(userContext) { Identifier = "FEMPRE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FEMPRE");
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
			Models.Cmpny model = Model;
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
		public override void MapFromModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Empre) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValLogo = ViewModelConversion.ToImage(m.ValLogo);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValAcronym = ViewModelConversion.ToString(m.ValAcronym);
				ValNif = ViewModelConversion.ToString(m.ValNif);
				ValTelephon = ViewModelConversion.ToString(m.ValTelephon);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValQtdpesso = ViewModelConversion.ToNumeric(m.ValQtdpesso);
				ValHeadloc = ViewModelConversion.ToString(m.ValHeadloc);
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Cmpny) to ViewModel (Empre) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Cmpny m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Empre) to Model (Cmpny) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				if (ValLogo == null || !ValLogo.IsThumbnail)
					m.ValLogo = ViewModelConversion.ToImage(ValLogo);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValAcronym = ViewModelConversion.ToString(ValAcronym);
				m.ValNif = ViewModelConversion.ToString(ValNif);
				m.ValTelephon = ViewModelConversion.ToString(ValTelephon);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValHeadloc = ViewModelConversion.ToString(ValHeadloc);
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValQtdpesso = ViewModelConversion.ToNumeric(ValQtdpesso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Empre) to Model (Cmpny) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "cmpny.codcntry":
						this.ValCodcntry = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.logo":
						this.ValLogo = ViewModelConversion.ToImage(_value);
						break;
					case "cmpny.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.acronym":
						this.ValAcronym = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.nif":
						this.ValNif = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.telephon":
						this.ValTelephon = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.headloc":
						this.ValHeadloc = ViewModelConversion.ToString(_value);
						break;
					case "cmpny.codempre":
						this.ValCodempre = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Empre) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Empre)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Cmpny.Find(id ?? Navigation.GetStrValue("cmpny"), m_userContext, "FEMPRE"); }
			finally { Model ??= new Models.Cmpny(m_userContext) { Identifier = "FEMPRE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), m_userContext, "FEMPRE");
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

			Model.Identifier = "FEMPRE";
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

		protected override void LoadDocumentsProperties(Models.Cmpny row)
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
				Model = Models.Cmpny.Find(Navigation.GetStrValue("cmpny"), m_userContext, "FEMPRE");
				if (Model == null)
				{
					Model = new Models.Cmpny(m_userContext) { Identifier = "FEMPRE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Empre___cntrycountry_(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EMPRE]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EMPRE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValDesignat", Resources.Resources.DESIGNATION35876, ValDesignat, 85);

			validator.Required("ValDesignat", Resources.Resources.DESIGNATION35876, ViewModelConversion.ToString(ValDesignat), FieldType.TEXTO.Formatting);
			validator.StringLength("ValAcronym", Resources.Resources.ACRONYM00872, ValAcronym, 15);
			validator.StringLength("ValNif", Resources.Resources.TAX_IDENTIFICATION_55044, ValNif, 15);
			validator.StringLength("ValTelephon", Resources.Resources.TELEPHONE28697, ValTelephon, 20);
			validator.StringLength("ValEmail", Resources.Resources.EMAIL_44228, ValEmail, 254);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE EMPRE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EMPRE]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EMPRE]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EMPRE]/
		public override void Destroy(string id)
		{
			Model = Models.Cmpny.Find(id, m_userContext, "FEMPRE");
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
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Empre___cntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool empre___cntrycountry_DoLoad = true;
			CriteriaSet empre___cntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					empre___cntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, hValue);
					this.ValCodcntry = DBConversion.ToString(hValue);
				}
			}

			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
				FillDependant_EmpreTableCntryCountry(lazyLoad);
				return;
			}

			if (empre___cntrycountry_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				query = qs["qTableCntryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				}
				empre___cntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL GQT OVERRQ EMPRE_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					empre___cntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					empre___cntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, empre___cntrycountry_Conds, fields, offset, numberItems, sorts, "LED_EMPRE___CNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_EMPRE___CNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_EmpreTableCntryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_EmpreTableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GlobalFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcntry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EmpreTableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_EmpreTableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GlobalFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TableCntryCountry.Value = "";
					Navigation.ClearValue("cntry");
				}
				else if (lazyLoad)
				{
					TableCntryCountry.SetPagination(1, 0, false, false, 1);
					TableCntryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TableCntryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TableCntryCountry.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EMPRE___CNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"cmpny.codcntry" => ViewModelConversion.ToString(modelValue),
				"cmpny.logo" => ViewModelConversion.ToImage(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"cmpny.acronym" => ViewModelConversion.ToString(modelValue),
				"cmpny.nif" => ViewModelConversion.ToString(modelValue),
				"cmpny.telephon" => ViewModelConversion.ToString(modelValue),
				"cmpny.email" => ViewModelConversion.ToString(modelValue),
				"cmpny.qtdpesso" => ViewModelConversion.ToNumeric(modelValue),
				"cmpny.headloc" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValLogo != null)
				ValLogo.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCMPNY, CSGenioAcmpny.FldLogo.Field, null, ValCodempre);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EMPRE]/

		#endregion
	}
}
