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

namespace GenioMVC.ViewModels.Assma
{
	public class Assma_ViewModel : FormViewModel<Models.Assma>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Identification name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Asset> TableAssetName { get; set; }

		/// <summary>
		/// Title: "Manual name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Digital document" | Type: "IB"
		/// </summary>
		[Document("ValDigdocum", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValDigdocum { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValDigdocumfk { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValDigdocumPropertiesVM { get; set; }

		/// <summary>
		/// Title: "Notes" | Type: "MO"
		/// </summary>
		public string ValNotes { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Identification name" | Type: "CE"
		/// </summary>
		public string ValCodasset { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodassma { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Assma_ViewModel() : base(null!) { }

		public Assma_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FASSMA", nestedForm) { }

		public Assma_ViewModel(UserContext userContext, Models.Assma row, bool nestedForm = false) : base(userContext, "FASSMA", row, nestedForm) { }

		public Assma_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("assma", id);
			Model = Models.Assma.Find(id, userContext, "FASSMA", fieldsToQuery: fieldsToLoad);
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
			Models.Assma model = new Models.Assma(userContext) { Identifier = "FASSMA" };
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
			Models.Assma model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Assma m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Assma) to ViewModel (Assma) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValDigdocum = ViewModelConversion.ToString(m.ValDigdocum);
				ValDigdocumfk = ViewModelConversion.ToString(m.ValDigdocumfk);
				ValNotes = ViewModelConversion.ToString(m.ValNotes);
				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
				ValCodassma = ViewModelConversion.ToString(m.ValCodassma);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Assma) to ViewModel (Assma) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Assma m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Assma) to Model (Assma) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValDigdocum = ViewModelConversion.ToString(ValDigdocum);
				m.ValDigdocumfk = ViewModelConversion.ToString(ValDigdocumfk);
				m.ValNotes = ViewModelConversion.ToString(ValNotes);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodassma = ViewModelConversion.ToString(ValCodassma);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Assma) to Model (Assma) - Error during mapping");
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
				Model = Models.Assma.Find(Navigation.GetStrValue("assma"), m_userContext, "FASSMA");
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

			Model.Identifier = "FASSMA";
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

		protected override void LoadDocumentsProperties(Models.Assma row)
		{
			try
			{
				ValDigdocumPropertiesVM = row.GetInfoDoc("ValDigdocum");
			}
			catch (Exception)
			{
				ValDigdocumPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
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
				Model = Models.Assma.Find(Navigation.GetStrValue("assma"), m_userContext, "FASSMA");
				if (Model == null)
				{
					Model = new Models.Assma(m_userContext) { Identifier = "FASSMA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("assma");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Assma___assetname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ASSMA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ASSMA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.MANUAL_NAME60077, ValName, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ASSMA]/
		public override void Save()
		{

			try { Model = Models.Assma.Find(Navigation.GetStrValue("assma"), m_userContext, "FASSMA"); }
			finally { if (Model == null) Model = new Models.Assma(m_userContext) { Identifier = "FASSMA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ASSMA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Assma.Find(Navigation.GetStrValue("assma"), m_userContext, "FASSMA"); }
			finally { if (Model == null) Model = new Models.Assma(m_userContext) { Identifier = "FASSMA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ASSMA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ASSMA]/
		public override void Destroy(string id)
		{
			Model = Models.Assma.Find(id, m_userContext, "FASSMA");
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
		/// TableAssetName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Assma___assetname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool assma___assetname____DoLoad = true;
			CriteriaSet assma___assetname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("asset", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					assma___assetname____Conds.Equal(CSGenioAasset.FldCodasset, Navigation.GetValue("asset"));
					this.ValCodasset = Navigation.GetStrValue("asset");
				}
			}

			TableAssetName = new TableDBEdit<Models.Asset>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}
				FillDependant_AssmaTableAssetName(lazyLoad);
				//Check if foreignkey comes from history
				TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
				return;
			}

			if (assma___assetname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAssetName, "sTableAssetName", "dTableAssetName", qs, "asset");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAasset.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAssetName_tableFilters"]))
					TableAssetName.TableFilters = bool.Parse(qs["TableAssetName_tableFilters"]);
				else
					TableAssetName.TableFilters = false;

				query = qs["qTableAssetName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAasset.FldName, query + "%");
				}
				assma___assetname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ASSMA_ASSETNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
					assma___assetname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAasset.FldZzstate, 0)
						.Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
				else
					assma___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("asset", "name");
				ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(m_userContext, false, assma___assetname____Conds, fields, offset, numberItems, sorts, "LED_ASSMA___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAssetName.Query = query;
				TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(m_userContext, r, true, _fieldsToSerialize_ASSMA___ASSETNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
				FillDependant_AssmaTableAssetName();

				//Check if foreignkey comes from history
				TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAssetName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Asset</param>
		public ConcurrentDictionary<string, object> GetDependant_AssmaTableAssetName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAasset.FldCodasset, CSGenioAasset.FldName];

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

			CSGenioAasset tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAasset.FldCodasset, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAssetName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_AssmaTableAssetName(bool lazyLoad = false)
		{
			var row = GetDependant_AssmaTableAssetName(this.ValCodasset);
			try
			{

				// Fill List fields
				this.ValCodasset = ViewModelConversion.ToString(row["asset.codasset"]);
				TableAssetName.Value = (string)row["asset.name"];
				if (GlobalFunctions.emptyG(this.ValCodasset) == 1)
				{
					this.ValCodasset = "";
					TableAssetName.Value = "";
					Navigation.ClearValue("asset");
				}
				else if (lazyLoad)
				{
					TableAssetName.SetPagination(1, 0, false, false, 1);
					TableAssetName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodasset),
							Text = Convert.ToString(TableAssetName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodasset);
				}

				TableAssetName.Selected = this.ValCodasset;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAssetName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ASSMA___ASSETNAME____ = ["Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"assma.name" => ViewModelConversion.ToString(modelValue),
				"assma.digdocum" => ViewModelConversion.ToString(modelValue),
				"assma.notes" => ViewModelConversion.ToString(modelValue),
				"assma.codasset" => ViewModelConversion.ToString(modelValue),
				"assma.codassma" => ViewModelConversion.ToString(modelValue),
				"asset.codasset" => ViewModelConversion.ToString(modelValue),
				"asset.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ASSMA]/

		#endregion
	}
}
