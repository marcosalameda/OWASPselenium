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

namespace GenioMVC.ViewModels.Facil
{
	public class Facil_ViewModel : FormViewModel<Models.Facil>, IPreparableForSerialization
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
		public string ValCodcntry { get; set; }
		/// <summary>
		/// Title: "Legal name" | Type: "CE"
		/// </summary>
		public string ValCodentit { get; set; }
		/// <summary>
		/// Title: "Facility type" | Type: "CE"
		/// </summary>
		public string ValCodfacty { get; set; }

		#endregion
		/// <summary>
		/// Title: "Legal name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Entit> TableEntitName { get; set; }
		/// <summary>
		/// Title: "Incorporation" | Type: "D"
		/// </summary>
		public DateTime? ValIncorpor { get; set; }
		/// <summary>
		/// Title: "Facility name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Facility type" | Type: "AC"
		/// </summary>
		public string ValFaciltyp { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValFaciltyp { get; set; }
		/// <summary>
		/// Title: "Facility type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Facty> TableFactyType { get; set; }
		/// <summary>
		/// Title: "Address" | Type: "MO"
		/// </summary>
		public string ValAddress { get; set; }
		/// <summary>
		/// Title: "Image" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(400, 300)]
		public GenioMVC.Models.ImageModel ValImage { get; set; }
		/// <summary>
		/// Title: "GPS input" | Type: "AC"
		/// </summary>
		public string ValGpsinput { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValGpsinput { get; set; }
		/// <summary>
		/// Title: "Latitude" | Type: "ND"
		/// </summary>
		public decimal? ValLatitude { get; set; }
		/// <summary>
		/// Title: "Longitude" | Type: "ND"
		/// </summary>
		public decimal? ValLongitud { get; set; }
		/// <summary>
		/// Title: "Geographical coordinate" | Type: "GG"
		/// </summary>
		public string ValGeocoori { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodfacil { get; set; }

		private readonly string[] _fieldsToSerialize = ["Glob", "Glob.ValCodfacty"];
		/// <summary>
		/// Gets the list of fields that should be serialized when sending information to the client-side.
		/// Currently, it is only used to limit the serialized fields of the GLOB table.
		/// </summary>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Facil_ViewModel() : base(null!) { }

		public Facil_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFACIL", nestedForm) { }

		public Facil_ViewModel(UserContext userContext, Models.Facil row, bool nestedForm = false) : base(userContext, "FFACIL", row, nestedForm) { }

		public Facil_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("facil", id);
			Model = Models.Facil.Find(id, userContext, "FFACIL", fieldsToQuery: fieldsToLoad);
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
			Models.Facil model = new Models.Facil(userContext) { Identifier = "FFACIL" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFACIL");
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
		public override void MapFromModel(Models.Facil m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Facil) to ViewModel (Facil) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
				ValCodfacty = ViewModelConversion.ToString(m.ValCodfacty);
				ValIncorpor = ViewModelConversion.ToDateTime(m.ValIncorpor);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValFaciltyp = ViewModelConversion.ToString(m.ValFaciltyp);
				ValAddress = ViewModelConversion.ToString(m.ValAddress);
				ValImage = ViewModelConversion.ToImage(m.ValImage);
				ValGpsinput = ViewModelConversion.ToString(m.ValGpsinput);
				ValLatitude = ViewModelConversion.ToNumeric(m.ValLatitude);
				ValLongitud = ViewModelConversion.ToNumeric(m.ValLongitud);
				ValGeocoori = ViewModelConversion.ToString(m.ValGeocoori);
				ValCodfacil = ViewModelConversion.ToString(m.ValCodfacil);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Facil) to ViewModel (Facil) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Facil m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Facil) to Model (Facil) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodfacty = ViewModelConversion.ToString(ValCodfacty);
				m.ValIncorpor = ViewModelConversion.ToDateTime(ValIncorpor);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValFaciltyp = ViewModelConversion.ToString(ValFaciltyp);
				m.ValAddress = ViewModelConversion.ToString(ValAddress);
				if (ValImage == null || !ValImage.IsThumbnail)
					m.ValImage = ViewModelConversion.ToImage(ValImage);
				m.ValGpsinput = ViewModelConversion.ToString(ValGpsinput);
				m.ValLatitude = ViewModelConversion.ToNumeric(ValLatitude);
				m.ValLongitud = ViewModelConversion.ToNumeric(ValLongitud);
				m.ValGeocoori = ViewModelConversion.ToString(ValGeocoori);
				m.ValCodfacil = ViewModelConversion.ToString(ValCodfacil);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Facil) to Model (Facil) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "facil.codentit":
						this.ValCodentit = ViewModelConversion.ToString(_value);
						break;
					case "facil.codfacty":
						this.ValCodfacty = ViewModelConversion.ToString(_value);
						break;
					case "facil.incorpor":
						this.ValIncorpor = ViewModelConversion.ToDateTime(_value);
						break;
					case "facil.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "facil.faciltyp":
						this.ValFaciltyp = ViewModelConversion.ToString(_value);
						break;
					case "facil.address":
						this.ValAddress = ViewModelConversion.ToString(_value);
						break;
					case "facil.image":
						this.ValImage = ViewModelConversion.ToImage(_value);
						break;
					case "facil.gpsinput":
						this.ValGpsinput = ViewModelConversion.ToString(_value);
						break;
					case "facil.latitude":
						this.ValLatitude = ViewModelConversion.ToNumeric(_value);
						break;
					case "facil.longitud":
						this.ValLongitud = ViewModelConversion.ToNumeric(_value);
						break;
					case "facil.geocoori":
						this.ValGeocoori = ViewModelConversion.ToString(_value);
						break;
					case "facil.codfacil":
						this.ValCodfacil = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Facil) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Facil)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Facil.Find(id ?? Navigation.GetStrValue("facil"), m_userContext, "FFACIL"); }
			finally { Model ??= new Models.Facil(m_userContext) { Identifier = "FFACIL" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Facil.Find(Navigation.GetStrValue("facil"), m_userContext, "FFACIL");
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

			Model.Identifier = "FFACIL";
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

		protected override void LoadDocumentsProperties(Models.Facil row)
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
				Model = Models.Facil.Find(Navigation.GetStrValue("facil"), m_userContext, "FFACIL");
				if (Model == null)
				{
					Model = new Models.Facil(m_userContext) { Identifier = "FFACIL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("facil");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Facil___entitname____(qs, lazyLoad);
			Load_Facil___factytype____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FACIL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FACIL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.FACILITY_NAME19514, ValName, 85);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE FACIL]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY FACIL]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FACIL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FACIL]/
		public override void Destroy(string id)
		{
			Model = Models.Facil.Find(id, m_userContext, "FFACIL");
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
		/// TableEntitName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Facil___entitname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool facil___entitname____DoLoad = true;
			CriteriaSet facil___entitname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("entit", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					facil___entitname____Conds.Equal(CSGenioAentit.FldCodentit, hValue);
					this.ValCodentit = DBConversion.ToString(hValue);
				}
			}

			TableEntitName = new TableDBEdit<Models.Entit>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
				FillDependant_FacilTableEntitName(lazyLoad);
				return;
			}

			if (facil___entitname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
					TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
				else
					TableEntitName.TableFilters = false;

				query = qs["qTableEntitName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAentit.FldName, query + "%");
				}
				facil___entitname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ FACIL_ENTITNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
					facil___entitname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAentit.FldZzstate, 0)
						.Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
				else
					facil___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("entit", "name");
				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, facil___entitname____Conds, fields, offset, numberItems, sorts, "LED_FACIL___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEntitName.Query = query;
				TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(m_userContext, r, true, _fieldsToSerialize_FACIL___ENTITNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
				FillDependant_FacilTableEntitName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Entit</param>
		public ConcurrentDictionary<string, object> GetDependant_FacilTableEntitName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAentit.FldCodentit, CSGenioAentit.FldName];

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

			CSGenioAentit tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FacilTableEntitName(bool lazyLoad = false)
		{
			var row = GetDependant_FacilTableEntitName(this.ValCodentit);
			try
			{

				// Fill List fields
				this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
				TableEntitName.Value = (string)row["entit.name"];
				if (GenFunctions.emptyG(this.ValCodentit) == 1)
				{
					this.ValCodentit = "";
					TableEntitName.Value = "";
					Navigation.ClearValue("entit");
				}
				else if (lazyLoad)
				{
					TableEntitName.SetPagination(1, 0, false, false, 1);
					TableEntitName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodentit),
							Text = Convert.ToString(TableEntitName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodentit);
				}

				TableEntitName.Selected = this.ValCodentit;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FACIL___ENTITNAME____ = ["Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials"];

		/// <summary>
		/// TableFactyType -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Facil___factytype____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool facil___factytype____DoLoad = true;
			CriteriaSet facil___factytype____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("facty", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					facil___factytype____Conds.Equal(CSGenioAfacty.FldCodfacty, hValue);
					this.ValCodfacty = DBConversion.ToString(hValue);
				}
			}

			TableFactyType = new TableDBEdit<Models.Facty>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}
				FillDependant_FacilTableFactyType(lazyLoad);
				return;
			}

			if (facil___factytype____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableFactyType, "sTableFactyType", "dTableFactyType", qs, "facty");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAfacty.FldType), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableFactyType_tableFilters"]))
					TableFactyType.TableFilters = bool.Parse(qs["TableFactyType_tableFilters"]);
				else
					TableFactyType.TableFilters = false;

				query = qs["qTableFactyType"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAfacty.FldType, query + "%");
				}
				facil___factytype____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableFactyType"] != null ? qs["pTableFactyType"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType, CSGenioAfacty.FldLayrname, CSGenioAfacty.FldIconurl, CSGenioAfacty.FldShadowur, CSGenioAfacty.FldIconancx, CSGenioAfacty.FldIconancy, CSGenioAfacty.FldIconheig, CSGenioAfacty.FldIconwid, CSGenioAfacty.FldPopupanx, CSGenioAfacty.FldPopupany, CSGenioAfacty.FldShadowax, CSGenioAfacty.FldShadoway, CSGenioAfacty.FldShadowhe, CSGenioAfacty.FldShadowwi, CSGenioAfacty.FldZzstate };

// USE /[MANUAL GQT OVERRQ FACIL_FACTYTYPE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("facty", FormMode.New) || Navigation.checkFormMode("facty", FormMode.Duplicate))
					facil___factytype____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAfacty.FldZzstate, 0)
						.Equal(CSGenioAfacty.FldCodfacty, Navigation.GetStrValue("facty")));
				else
					facil___factytype____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAfacty.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("facty", "type");
				ListingMVC<CSGenioAfacty> listing = Models.ModelBase.Where<CSGenioAfacty>(m_userContext, false, facil___factytype____Conds, fields, offset, numberItems, sorts, "LED_FACIL___FACTYTYPE____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableFactyType.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableFactyType.Query = query;
				TableFactyType.Elements = listing.RowsForViewModel<GenioMVC.Models.Facty>((r) => new GenioMVC.Models.Facty(m_userContext, r, true, _fieldsToSerialize_FACIL___FACTYTYPE____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_facty") != null)
				{
					this.ValCodfacty = Navigation.GetStrValue("RETURN_facty");
					Navigation.CurrentLevel.SetEntry("RETURN_facty", null);
				}

				TableFactyType.List = new SelectList(TableFactyType.Elements.ToSelectList(x => x.ValType, x => x.ValCodfacty,  x => x.ValCodfacty == this.ValCodfacty), "Value", "Text", this.ValCodfacty);
				FillDependant_FacilTableFactyType();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableFactyType (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Facty</param>
		public ConcurrentDictionary<string, object> GetDependant_FacilTableFactyType(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAfacty.FldCodfacty, CSGenioAfacty.FldType];

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

			CSGenioAfacty tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAfacty.FldCodfacty, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableFactyType (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_FacilTableFactyType(bool lazyLoad = false)
		{
			var row = GetDependant_FacilTableFactyType(this.ValCodfacty);
			try
			{

				// Fill List fields
				this.ValCodfacty = ViewModelConversion.ToString(row["facty.codfacty"]);
				TableFactyType.Value = (string)row["facty.type"];
				if (GenFunctions.emptyG(this.ValCodfacty) == 1)
				{
					this.ValCodfacty = "";
					TableFactyType.Value = "";
					Navigation.ClearValue("facty");
				}
				else if (lazyLoad)
				{
					TableFactyType.SetPagination(1, 0, false, false, 1);
					TableFactyType.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodfacty),
							Text = Convert.ToString(TableFactyType.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodfacty);
				}

				TableFactyType.Selected = this.ValCodfacty;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableFactyType): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_FACIL___FACTYTYPE____ = ["Facty", "Facty.ValCodfacty", "Facty.ValZzstate", "Facty.ValType", "Facty.ValLayrname", "Facty.ValIconurl", "Facty.ValShadowur", "Facty.ValIconancx", "Facty.ValIconancy", "Facty.ValIconheig", "Facty.ValIconwid", "Facty.ValPopupanx", "Facty.ValPopupany", "Facty.ValShadowax", "Facty.ValShadoway", "Facty.ValShadowhe", "Facty.ValShadowwi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"facil.codcntry" => ViewModelConversion.ToString(modelValue),
				"facil.codentit" => ViewModelConversion.ToString(modelValue),
				"facil.codfacty" => ViewModelConversion.ToString(modelValue),
				"facil.incorpor" => ViewModelConversion.ToDateTime(modelValue),
				"facil.name" => ViewModelConversion.ToString(modelValue),
				"facil.faciltyp" => ViewModelConversion.ToString(modelValue),
				"facil.address" => ViewModelConversion.ToString(modelValue),
				"facil.image" => ViewModelConversion.ToImage(modelValue),
				"facil.gpsinput" => ViewModelConversion.ToString(modelValue),
				"facil.latitude" => ViewModelConversion.ToNumeric(modelValue),
				"facil.longitud" => ViewModelConversion.ToNumeric(modelValue),
				"facil.geocoori" => ViewModelConversion.ToString(modelValue),
				"facil.codfacil" => ViewModelConversion.ToString(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"entit.name" => ViewModelConversion.ToString(modelValue),
				"facty.codfacty" => ViewModelConversion.ToString(modelValue),
				"facty.type" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValImage != null)
				ValImage.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaFACIL, CSGenioAfacil.FldImage.Field, null, ValCodfacil);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FACIL]/

		#endregion
	}
}
