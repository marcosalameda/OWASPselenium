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

namespace GenioMVC.ViewModels.Produ
{
	public class Produ_ViewModel : FormViewModel<Models.Produ>, IPreparableForSerialization
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
		/// Title: "GLN Extension Component" | Type: "CE"
		/// </summary>
		public string ValCodlcext { get; set; }
		/// <summary>
		/// Title: "Global Location Number" | Type: "CE"
		/// </summary>
		public string ValCodlocat { get; set; }

		#endregion
		/// <summary>
		/// Title: "Product" | Type: "C"
		/// </summary>
		public string ValProduct { get; set; }
		/// <summary>
		/// Title: "In use" | Type: "AL"
		/// </summary>
		public int ValIn_use { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValIn_use { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }
		/// <summary>
		/// Title: "SKU" | Type: "C"
		/// </summary>
		public string ValSku { get; set; }
		/// <summary>
		/// Title: "GTIN" | Type: "C"
		/// </summary>
		public string ValGtin { get; set; }
		/// <summary>
		/// Title: "Size" | Type: "C"
		/// </summary>
		public string ValSize { get; set; }
		/// <summary>
		/// Title: "Weight" | Type: "N"
		/// </summary>
		public decimal? ValWeight { get; set; }
		/// <summary>
		/// Title: "Price" | Type: "$D"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "Inputs" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValInputs { get; set; }
		/// <summary>
		/// Title: "Outputs" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValOutputs { get; set; }
		/// <summary>
		/// Title: "Stock" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValStock { get; set; }
		/// <summary>
		/// Title: "Image" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(400, 300)]
		public GenioMVC.Models.ImageModel ValImage { get; set; }
		/// <summary>
		/// Title: "Global Location Number" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Locat> TableLocatGln { get; set; }
		/// <summary>
		/// Title: "GLN Extension Component" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Lcext> TableLcextGlnext { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodprodu { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Produ_ViewModel() : base(null!) { }

		public Produ_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPRODU", nestedForm) { }

		public Produ_ViewModel(UserContext userContext, Models.Produ row, bool nestedForm = false) : base(userContext, "FPRODU", row, nestedForm) { }

		public Produ_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("produ", id);
			Model = Models.Produ.Find(id, userContext, "FPRODU", fieldsToQuery: fieldsToLoad);
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
			Models.Produ model = new Models.Produ(userContext) { Identifier = "FPRODU" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPRODU");
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
		public override void MapFromModel(Models.Produ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Produ) to ViewModel (Produ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodlcext = ViewModelConversion.ToString(m.ValCodlcext);
				ValCodlocat = ViewModelConversion.ToString(m.ValCodlocat);
				ValProduct = ViewModelConversion.ToString(m.ValProduct);
				ValIn_use = ViewModelConversion.ToInteger(m.ValIn_use);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValSku = ViewModelConversion.ToString(m.ValSku);
				ValGtin = ViewModelConversion.ToString(m.ValGtin);
				ValSize = ViewModelConversion.ToString(m.ValSize);
				ValWeight = ViewModelConversion.ToNumeric(m.ValWeight);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValInputs = ViewModelConversion.ToNumeric(m.ValInputs);
				ValOutputs = ViewModelConversion.ToNumeric(m.ValOutputs);
				ValStock = ViewModelConversion.ToNumeric(m.ValStock);
				ValImage = ViewModelConversion.ToImage(m.ValImage);
				ValCodprodu = ViewModelConversion.ToString(m.ValCodprodu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Produ) to ViewModel (Produ) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Produ m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Produ) to Model (Produ) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodlcext = ViewModelConversion.ToString(ValCodlcext);
				m.ValCodlocat = ViewModelConversion.ToString(ValCodlocat);
				m.ValProduct = ViewModelConversion.ToString(ValProduct);
				m.ValIn_use = ViewModelConversion.ToInteger(ValIn_use);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValSku = ViewModelConversion.ToString(ValSku);
				m.ValGtin = ViewModelConversion.ToString(ValGtin);
				m.ValSize = ViewModelConversion.ToString(ValSize);
				m.ValWeight = ViewModelConversion.ToNumeric(ValWeight);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				if (ValImage == null || !ValImage.IsThumbnail)
					m.ValImage = ViewModelConversion.ToImage(ValImage);
				m.ValCodprodu = ViewModelConversion.ToString(ValCodprodu);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValInputs = ViewModelConversion.ToNumeric(ValInputs);
				m.ValOutputs = ViewModelConversion.ToNumeric(ValOutputs);
				m.ValStock = ViewModelConversion.ToNumeric(ValStock);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Produ) to Model (Produ) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "produ.codlcext":
						this.ValCodlcext = ViewModelConversion.ToString(_value);
						break;
					case "produ.codlocat":
						this.ValCodlocat = ViewModelConversion.ToString(_value);
						break;
					case "produ.product":
						this.ValProduct = ViewModelConversion.ToString(_value);
						break;
					case "produ.in_use":
						this.ValIn_use = ViewModelConversion.ToInteger(_value);
						break;
					case "produ.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "produ.sku":
						this.ValSku = ViewModelConversion.ToString(_value);
						break;
					case "produ.gtin":
						this.ValGtin = ViewModelConversion.ToString(_value);
						break;
					case "produ.size":
						this.ValSize = ViewModelConversion.ToString(_value);
						break;
					case "produ.weight":
						this.ValWeight = ViewModelConversion.ToNumeric(_value);
						break;
					case "produ.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "produ.image":
						this.ValImage = ViewModelConversion.ToImage(_value);
						break;
					case "produ.codprodu":
						this.ValCodprodu = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Produ) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Produ)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Produ.Find(id ?? Navigation.GetStrValue("produ"), m_userContext, "FPRODU"); }
			finally { Model ??= new Models.Produ(m_userContext) { Identifier = "FPRODU" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Produ.Find(Navigation.GetStrValue("produ"), m_userContext, "FPRODU");
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

			Model.Identifier = "FPRODU";
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

		protected override void LoadDocumentsProperties(Models.Produ row)
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
				Model = Models.Produ.Find(Navigation.GetStrValue("produ"), m_userContext, "FPRODU");
				if (Model == null)
				{
					Model = new Models.Produ(m_userContext) { Identifier = "FPRODU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("produ");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Produ___locatgln_____(qs, lazyLoad);
			Load_Produ___lcextglnext__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PRODU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PRODU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValProduct", Resources.Resources.PRODUCT12880, ValProduct, 85);

			validator.Required("ValProduct", Resources.Resources.PRODUCT12880, ViewModelConversion.ToString(ValProduct), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValSku", Resources.Resources.SKU42303, ValSku, 20);
			validator.StringLength("ValGtin", Resources.Resources.GTIN45487, ValGtin, 14);
			validator.StringLength("ValSize", Resources.Resources.SIZE10299, ValSize, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PRODU]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PRODU]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PRODU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PRODU]/
		public override void Destroy(string id)
		{
			Model = Models.Produ.Find(id, m_userContext, "FPRODU");
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
		/// TableLocatGln -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Produ___locatgln_____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool produ___locatgln_____DoLoad = true;
			CriteriaSet produ___locatgln_____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("locat", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					produ___locatgln_____Conds.Equal(CSGenioAlocat.FldCodlocat, hValue);
					this.ValCodlocat = DBConversion.ToString(hValue);
				}
			}

			TableLocatGln = new TableDBEdit<Models.Locat>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}
				FillDependant_ProduTableLocatGln(lazyLoad);
				return;
			}

			if (produ___locatgln_____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableLocatGln, "sTableLocatGln", "dTableLocatGln", qs, "locat");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlocat.FldGln), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLocatGln_tableFilters"]))
					TableLocatGln.TableFilters = bool.Parse(qs["TableLocatGln_tableFilters"]);
				else
					TableLocatGln.TableFilters = false;

				query = qs["qTableLocatGln"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlocat.FldGln, query + "%");
				}
				produ___locatgln_____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLocatGln"] != null ? qs["pTableLocatGln"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln, CSGenioAlocat.FldZzstate };

// USE /[MANUAL GQT OVERRQ PRODU_LOCATGLN]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("locat", FormMode.New) || Navigation.checkFormMode("locat", FormMode.Duplicate))
					produ___locatgln_____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlocat.FldZzstate, 0)
						.Equal(CSGenioAlocat.FldCodlocat, Navigation.GetStrValue("locat")));
				else
					produ___locatgln_____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlocat.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("locat", "gln");
				ListingMVC<CSGenioAlocat> listing = Models.ModelBase.Where<CSGenioAlocat>(m_userContext, false, produ___locatgln_____Conds, fields, offset, numberItems, sorts, "LED_PRODU___LOCATGLN_____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLocatGln.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLocatGln.Query = query;
				TableLocatGln.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Locat(m_userContext, r, true, _fieldsToSerialize_PRODU___LOCATGLN_____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_locat") != null)
				{
					this.ValCodlocat = Navigation.GetStrValue("RETURN_locat");
					Navigation.CurrentLevel.SetEntry("RETURN_locat", null);
				}

				TableLocatGln.List = new SelectList(TableLocatGln.Elements.ToSelectList(x => x.ValGln, x => x.ValCodlocat,  x => x.ValCodlocat == this.ValCodlocat), "Value", "Text", this.ValCodlocat);
				FillDependant_ProduTableLocatGln();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLocatGln (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Locat</param>
		public ConcurrentDictionary<string, object> GetDependant_ProduTableLocatGln(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlocat.FldCodlocat, CSGenioAlocat.FldGln];

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

			CSGenioAlocat tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlocat.FldCodlocat, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLocatGln (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProduTableLocatGln(bool lazyLoad = false)
		{
			var row = GetDependant_ProduTableLocatGln(this.ValCodlocat);
			try
			{

				// Fill List fields
				this.ValCodlocat = ViewModelConversion.ToString(row["locat.codlocat"]);
				TableLocatGln.Value = (string)row["locat.gln"];
				if (GenFunctions.emptyG(this.ValCodlocat) == 1)
				{
					this.ValCodlocat = "";
					TableLocatGln.Value = "";
					Navigation.ClearValue("locat");
				}
				else if (lazyLoad)
				{
					TableLocatGln.SetPagination(1, 0, false, false, 1);
					TableLocatGln.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodlocat),
							Text = Convert.ToString(TableLocatGln.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodlocat);
				}

				TableLocatGln.Selected = this.ValCodlocat;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLocatGln): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PRODU___LOCATGLN_____ = ["Locat", "Locat.ValCodlocat", "Locat.ValZzstate", "Locat.ValGln"];

		/// <summary>
		/// TableLcextGlnext -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Produ___lcextglnext__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool produ___lcextglnext__DoLoad = true;
			CriteriaSet produ___lcextglnext__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("lcext", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					produ___lcextglnext__Conds.Equal(CSGenioAlcext.FldCodlcext, hValue);
					this.ValCodlcext = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			produ___lcextglnext__DoLoad &= AddCriteriaAreaLimit(produ___lcextglnext__Conds, CSGenio.business.CSGenioAlocat.FldCodlocat, "locat", this.ValCodlocat, true);

			TableLcextGlnext = new TableDBEdit<Models.Lcext>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_lcext") != null)
				{
					this.ValCodlcext = Navigation.GetStrValue("RETURN_lcext");
					Navigation.CurrentLevel.SetEntry("RETURN_lcext", null);
				}
				FillDependant_ProduTableLcextGlnext(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodlocat))
				produ___lcextglnext__DoLoad = false;

			if (produ___lcextglnext__DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableLcextGlnext, "sTableLcextGlnext", "dTableLcextGlnext", qs, "lcext");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlcext.FldGlnext), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLcextGlnext_tableFilters"]))
					TableLcextGlnext.TableFilters = bool.Parse(qs["TableLcextGlnext_tableFilters"]);
				else
					TableLcextGlnext.TableFilters = false;

				query = qs["qTableLcextGlnext"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlcext.FldGlnext, query + "%");
				}
				produ___lcextglnext__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLcextGlnext"] != null ? qs["pTableLcextGlnext"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext, CSGenioAlcext.FldZzstate };

// USE /[MANUAL GQT OVERRQ PRODU_LCEXTGLNEXT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("lcext", FormMode.New) || Navigation.checkFormMode("lcext", FormMode.Duplicate))
					produ___lcextglnext__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlcext.FldZzstate, 0)
						.Equal(CSGenioAlcext.FldCodlcext, Navigation.GetStrValue("lcext")));
				else
					produ___lcextglnext__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlcext.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("lcext", "glnext");
				ListingMVC<CSGenioAlcext> listing = Models.ModelBase.Where<CSGenioAlcext>(m_userContext, false, produ___lcextglnext__Conds, fields, offset, numberItems, sorts, "LED_PRODU___LCEXTGLNEXT__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLcextGlnext.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLcextGlnext.Query = query;
				TableLcextGlnext.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Lcext(m_userContext, r, true, _fieldsToSerialize_PRODU___LCEXTGLNEXT__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_lcext") != null)
				{
					this.ValCodlcext = Navigation.GetStrValue("RETURN_lcext");
					Navigation.CurrentLevel.SetEntry("RETURN_lcext", null);
				}

				TableLcextGlnext.List = new SelectList(TableLcextGlnext.Elements.ToSelectList(x => x.ValGlnext, x => x.ValCodlcext,  x => x.ValCodlcext == this.ValCodlcext), "Value", "Text", this.ValCodlcext);
				FillDependant_ProduTableLcextGlnext();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLcextGlnext (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Lcext</param>
		public ConcurrentDictionary<string, object> GetDependant_ProduTableLcextGlnext(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlcext.FldCodlcext, CSGenioAlcext.FldGlnext];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("locat");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAlcext.FldCodlocat, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAlcext tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlcext.FldCodlcext, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLcextGlnext (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ProduTableLcextGlnext(bool lazyLoad = false)
		{
			var row = GetDependant_ProduTableLcextGlnext(this.ValCodlcext);
			try
			{

				// Fill List fields
				this.ValCodlcext = ViewModelConversion.ToString(row["lcext.codlcext"]);
				TableLcextGlnext.Value = (string)row["lcext.glnext"];
				if (GenFunctions.emptyG(this.ValCodlcext) == 1)
				{
					this.ValCodlcext = "";
					TableLcextGlnext.Value = "";
					Navigation.ClearValue("lcext");
				}
				else if (lazyLoad)
				{
					TableLcextGlnext.SetPagination(1, 0, false, false, 1);
					TableLcextGlnext.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodlcext),
							Text = Convert.ToString(TableLcextGlnext.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodlcext);
				}

				TableLcextGlnext.Selected = this.ValCodlcext;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLcextGlnext): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PRODU___LCEXTGLNEXT__ = ["Lcext", "Lcext.ValCodlcext", "Lcext.ValZzstate", "Lcext.ValGlnext"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"produ.codlcext" => ViewModelConversion.ToString(modelValue),
				"produ.codlocat" => ViewModelConversion.ToString(modelValue),
				"produ.product" => ViewModelConversion.ToString(modelValue),
				"produ.in_use" => ViewModelConversion.ToInteger(modelValue),
				"produ.descript" => ViewModelConversion.ToString(modelValue),
				"produ.sku" => ViewModelConversion.ToString(modelValue),
				"produ.gtin" => ViewModelConversion.ToString(modelValue),
				"produ.size" => ViewModelConversion.ToString(modelValue),
				"produ.weight" => ViewModelConversion.ToNumeric(modelValue),
				"produ.price" => ViewModelConversion.ToNumeric(modelValue),
				"produ.inputs" => ViewModelConversion.ToNumeric(modelValue),
				"produ.outputs" => ViewModelConversion.ToNumeric(modelValue),
				"produ.stock" => ViewModelConversion.ToNumeric(modelValue),
				"produ.image" => ViewModelConversion.ToImage(modelValue),
				"produ.codprodu" => ViewModelConversion.ToString(modelValue),
				"locat.codlocat" => ViewModelConversion.ToString(modelValue),
				"locat.gln" => ViewModelConversion.ToString(modelValue),
				"lcext.codlcext" => ViewModelConversion.ToString(modelValue),
				"lcext.glnext" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValImage != null)
				ValImage.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPRODU, CSGenioAprodu.FldImage.Field, null, ValCodprodu);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PRODU]/

		#endregion
	}
}
