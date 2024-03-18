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

namespace GenioMVC.ViewModels.Attac
{
	public class Attac_ViewModel : FormViewModel<Models.Attac>
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
		/// Title: "Attached" | Type: "DT"
		/// </summary>
		public DateTime? ValAttached { get; set; }

		/// <summary>
		/// Title: "Note" | Type: "MO"
		/// </summary>
		public string ValNote { get; set; }

		/// <summary>
		/// Title: "Document" | Type: "IB"
		/// </summary>
		[Document("ValDocument", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValDocument { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string ValDocumentfk { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public DocumsProperties_ViewModel ValDocumentPropertiesVM { get; set; }

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

		public string ValCodattac { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Attac_ViewModel() : base(null!) { }

		public Attac_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FATTAC", nestedForm) { }

		public Attac_ViewModel(UserContext userContext, Models.Attac row, bool nestedForm = false) : base(userContext, "FATTAC", row, nestedForm) { }

		public Attac_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("attac", id);
			Model = Models.Attac.Find(id, userContext, "FATTAC", fieldsToQuery: fieldsToLoad);
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
			Models.Attac model = new Models.Attac(userContext) { Identifier = "FATTAC" };
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
			Models.Attac model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Attac m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Attac) to ViewModel (Attac) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValAttached = ViewModelConversion.ToDateTime(m.ValAttached);
				ValNote = ViewModelConversion.ToString(m.ValNote);
				ValDocument = ViewModelConversion.ToString(m.ValDocument);
				ValDocumentfk = ViewModelConversion.ToString(m.ValDocumentfk);
				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
				ValCodattac = ViewModelConversion.ToString(m.ValCodattac);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Attac) to ViewModel (Attac) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Attac m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Attac) to Model (Attac) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValAttached = ViewModelConversion.ToDateTime(ValAttached);
				m.ValNote = ViewModelConversion.ToString(ValNote);
				m.ValDocument = ViewModelConversion.ToString(ValDocument);
				m.ValDocumentfk = ViewModelConversion.ToString(ValDocumentfk);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
				m.ValCodattac = ViewModelConversion.ToString(ValCodattac);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Attac) to Model (Attac) - Error during mapping");
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
				Model = Models.Attac.Find(Navigation.GetStrValue("attac"), m_userContext, "FATTAC");
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

			Model.Identifier = "FATTAC";
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

		protected override void LoadDocumentsProperties(Models.Attac row)
		{
			try
			{
				ValDocumentPropertiesVM = row.GetInfoDoc("ValDocument");
			}
			catch (Exception)
			{
				ValDocumentPropertiesVM = new DocumsProperties_ViewModel(m_userContext);
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
				Model = Models.Attac.Find(Navigation.GetStrValue("attac"), m_userContext, "FATTAC");
				if (Model == null)
				{
					Model = new Models.Attac(m_userContext) { Identifier = "FATTAC" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("attac");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Attac___assetname____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ATTAC]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ATTAC]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ATTAC]/
		public override void Save()
		{

			try { Model = Models.Attac.Find(Navigation.GetStrValue("attac"), m_userContext, "FATTAC"); }
			finally { if (Model == null) Model = new Models.Attac(m_userContext) { Identifier = "FATTAC" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ATTAC]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Attac.Find(Navigation.GetStrValue("attac"), m_userContext, "FATTAC"); }
			finally { if (Model == null) Model = new Models.Attac(m_userContext) { Identifier = "FATTAC" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ATTAC]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ATTAC]/
		public override void Destroy(string id)
		{
			Model = Models.Attac.Find(id, m_userContext, "FATTAC");
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
		public void Load_Attac___assetname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool attac___assetname____DoLoad = true;
			CriteriaSet attac___assetname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("asset", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					attac___assetname____Conds.Equal(CSGenioAasset.FldCodasset, Navigation.GetValue("asset"));
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
				FillDependant_AttacTableAssetName(lazyLoad);
				//Check if foreignkey comes from history
				TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
				return;
			}

			if (attac___assetname____DoLoad)
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
				attac___assetname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAssetName"] != null ? qs["pTableAssetName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAasset.FldCodasset, CSGenioAasset.FldName, CSGenioAasset.FldZzstate };

// USE /[MANUAL GQT OVERRQ ATTAC_ASSETNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("asset", FormMode.New) || Navigation.checkFormMode("asset", FormMode.Duplicate))
					attac___assetname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAasset.FldZzstate, 0)
						.Equal(CSGenioAasset.FldCodasset, Navigation.GetStrValue("asset")));
				else
					attac___assetname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAasset.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("asset", "name");
				ListingMVC<CSGenioAasset> listing = Models.ModelBase.Where<CSGenioAasset>(m_userContext, false, attac___assetname____Conds, fields, offset, numberItems, sorts, "LED_ATTAC___ASSETNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAssetName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAssetName.Query = query;
				TableAssetName.Elements = listing.RowsForViewModel<GenioMVC.Models.Asset>((r) => new GenioMVC.Models.Asset(m_userContext, r, true, _fieldsToSerialize_ATTAC___ASSETNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_asset") != null)
				{
					this.ValCodasset = Navigation.GetStrValue("RETURN_asset");
					Navigation.CurrentLevel.SetEntry("RETURN_asset", null);
				}

				TableAssetName.List = new SelectList(TableAssetName.Elements.ToSelectList(x => x.ValName, x => x.ValCodasset,  x => x.ValCodasset == this.ValCodasset), "Value", "Text", this.ValCodasset);
				FillDependant_AttacTableAssetName();

				//Check if foreignkey comes from history
				TableAssetName.FilledByHistory = Navigation.CheckFilledByHistory("asset");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAssetName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Asset</param>
		public ConcurrentDictionary<string, object> GetDependant_AttacTableAssetName(string PKey)
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
		public void FillDependant_AttacTableAssetName(bool lazyLoad = false)
		{
			var row = GetDependant_AttacTableAssetName(this.ValCodasset);
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

		private readonly string[] _fieldsToSerialize_ATTAC___ASSETNAME____ = ["Asset", "Asset.ValCodasset", "Asset.ValZzstate", "Asset.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"attac.attached" => ViewModelConversion.ToDateTime(modelValue),
				"attac.note" => ViewModelConversion.ToString(modelValue),
				"attac.document" => ViewModelConversion.ToString(modelValue),
				"attac.codasset" => ViewModelConversion.ToString(modelValue),
				"attac.codattac" => ViewModelConversion.ToString(modelValue),
				"asset.codasset" => ViewModelConversion.ToString(modelValue),
				"asset.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ATTAC]/

		#endregion
	}
}
