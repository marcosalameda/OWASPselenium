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

namespace GenioMVC.ViewModels.Asset
{
	public class Equipm_ViewModel : FormViewModel<Models.Asset>
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
		public string ValName { get; set; }

		/// <summary>
		/// Title: "Asset type" | Type: "AC"
		/// </summary>
		public string ValAssettyp { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValAssettyp { get; set; }

		/// <summary>
		/// Title: "Asset number" | Type: "N"
		/// </summary>
		public decimal? ValAssetnum { get; set; }

		/// <summary>
		/// Title: "Identifier type" | Type: "AC"
		/// </summary>
		public string ValIdenttyp { get; set; }

		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValIdenttyp { get; set; }

		/// <summary>
		/// Title: "GRAI – Global Returnable Asset Identifier" | Type: "C"
		/// </summary>
		public string ValGrai { get; set; }

		/// <summary>
		/// Title: "GIAI – Global Individual Asset Identifier" | Type: "C"
		/// </summary>
		public string ValGiai { get; set; }

		/// <summary>
		/// Title: "Manufacturer" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Manuf> TableManufName { get; set; }

		/// <summary>
		/// Title: "Kind of equipment" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Kinde> TableKindeDesignat { get; set; }

		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(400, 300)]
		public GenioMVC.ViewModels.ImageModel ValPhoto { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Kind of equipment" | Type: "CE"
		/// </summary>
		public string ValCodkinde { get; set; }

		/// <summary>
		/// Title: "Manufacturer" | Type: "CE"
		/// </summary>
		public string ValCodmanuf { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodasset { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Equipm_ViewModel() : base(null!) { }

		public Equipm_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEQUIPM", nestedForm) { }

		public Equipm_ViewModel(UserContext userContext, Models.Asset row, bool nestedForm = false) : base(userContext, "FEQUIPM", row, nestedForm) { }

		public Equipm_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("asset", id);
			Model = Models.Asset.Find(id, userContext, "FEQUIPM", fieldsToQuery: fieldsToLoad);
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
			Models.Asset model = new Models.Asset(userContext) { Identifier = "FEQUIPM" };
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
			Models.Asset model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Equipm) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValName = ViewModelConversion.ToString(m.ValName);
				ValAssettyp = ViewModelConversion.ToString(m.ValAssettyp);
				ValAssetnum = ViewModelConversion.ToNumeric(m.ValAssetnum);
				ValIdenttyp = ViewModelConversion.ToString(m.ValIdenttyp);
				ValGrai = ViewModelConversion.ToString(m.ValGrai);
				ValGiai = ViewModelConversion.ToString(m.ValGiai);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValCodkinde = ViewModelConversion.ToString(m.ValCodkinde);
				ValCodmanuf = ViewModelConversion.ToString(m.ValCodmanuf);
				ValCodasset = ViewModelConversion.ToString(m.ValCodasset);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Asset) to ViewModel (Equipm) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Asset m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equipm) to Model (Asset) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValAssettyp = ViewModelConversion.ToString(ValAssettyp);
				m.ValAssetnum = ViewModelConversion.ToNumeric(ValAssetnum);
				m.ValIdenttyp = ViewModelConversion.ToString(ValIdenttyp);
				m.ValGrai = ViewModelConversion.ToString(ValGrai);
				m.ValGiai = ViewModelConversion.ToString(ValGiai);
				m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValCodkinde = ViewModelConversion.ToString(ValCodkinde);
				m.ValCodmanuf = ViewModelConversion.ToString(ValCodmanuf);
				m.ValCodasset = ViewModelConversion.ToString(ValCodasset);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equipm) to Model (Asset) - Error during mapping");
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
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FEQUIPM");
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

			Model.Identifier = "FEQUIPM";
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

		protected override void LoadDocumentsProperties(Models.Asset row)
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
				Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FEQUIPM");
				if (Model == null)
				{
					Model = new Models.Asset(m_userContext) { Identifier = "FEQUIPM" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("asset");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Equipm__manufname____(qs, lazyLoad);
			Load_Equipm__kindedesignat(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIPM]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIPM]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValName", Resources.Resources.IDENTIFICATION_NAME16317, ValName, 85);
			validator.StringLength("ValGrai", Resources.Resources.GRAI___GLOBAL_RETURN06821, ValGrai, 50);
			validator.StringLength("ValGiai", Resources.Resources.GIAI___GLOBAL_INDIVI63214, ValGiai, 50);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIPM]/
		public override void Save()
		{

			try { Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FEQUIPM"); }
			finally { if (Model == null) Model = new Models.Asset(m_userContext) { Identifier = "FEQUIPM" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIPM]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Asset.Find(Navigation.GetStrValue("asset"), m_userContext, "FEQUIPM"); }
			finally { if (Model == null) Model = new Models.Asset(m_userContext) { Identifier = "FEQUIPM" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIPM]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIPM]/
		public override void Destroy(string id)
		{
			Model = Models.Asset.Find(id, m_userContext, "FEQUIPM");
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
		/// TableManufName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equipm__manufname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equipm__manufname____DoLoad = true;
			CriteriaSet equipm__manufname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("manuf", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equipm__manufname____Conds.Equal(CSGenioAmanuf.FldCodentit, Navigation.GetValue("manuf"));
					this.ValCodmanuf = Navigation.GetStrValue("manuf");
				}
			}
			// Limits Generation

			object equipm__manufname_____flimitmanuf_manufact = "1";
			equipm__manufname____Conds.Equal(
				CSGenio.business.CSGenioAmanuf.FldManufact,
				equipm__manufname_____flimitmanuf_manufact);

			TableManufName = new TableDBEdit<Models.Manuf>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_manuf") != null)
				{
					this.ValCodmanuf = Navigation.GetStrValue("RETURN_manuf");
					Navigation.CurrentLevel.SetEntry("RETURN_manuf", null);
				}
				FillDependant_EquipmTableManufName(lazyLoad);
				//Check if foreignkey comes from history
				TableManufName.FilledByHistory = Navigation.CheckFilledByHistory("manuf");
				return;
			}

			if (equipm__manufname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableManufName, "sTableManufName", "dTableManufName", qs, "manuf");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmanuf.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableManufName_tableFilters"]))
					TableManufName.TableFilters = bool.Parse(qs["TableManufName_tableFilters"]);
				else
					TableManufName.TableFilters = false;

				query = qs["qTableManufName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAmanuf.FldName, query + "%");
				}
				equipm__manufname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableManufName"] != null ? qs["pTableManufName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName, CSGenioAmanuf.FldInitials, CSGenioAmanuf.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIPM_MANUFNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("manuf", FormMode.New) || Navigation.checkFormMode("manuf", FormMode.Duplicate))
					equipm__manufname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmanuf.FldZzstate, 0)
						.Equal(CSGenioAmanuf.FldCodentit, Navigation.GetStrValue("manuf")));
				else
					equipm__manufname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmanuf.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("manuf", "name");
				ListingMVC<CSGenioAmanuf> listing = Models.ModelBase.Where<CSGenioAmanuf>(m_userContext, false, equipm__manufname____Conds, fields, offset, numberItems, sorts, "LED_EQUIPM__MANUFNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableManufName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableManufName.Query = query;
				TableManufName.Elements = listing.RowsForViewModel<GenioMVC.Models.Manuf>((r) => new GenioMVC.Models.Manuf(m_userContext, r, true, _fieldsToSerialize_EQUIPM__MANUFNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_manuf") != null)
				{
					this.ValCodmanuf = Navigation.GetStrValue("RETURN_manuf");
					Navigation.CurrentLevel.SetEntry("RETURN_manuf", null);
				}

				TableManufName.List = new SelectList(TableManufName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodmanuf), "Value", "Text", this.ValCodmanuf);
				FillDependant_EquipmTableManufName();

				//Check if foreignkey comes from history
				TableManufName.FilledByHistory = Navigation.CheckFilledByHistory("manuf");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableManufName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Manuf</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipmTableManufName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAmanuf.FldCodentit, CSGenioAmanuf.FldName];

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

			CSGenioAmanuf tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAmanuf.FldCodentit, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableManufName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipmTableManufName(bool lazyLoad = false)
		{
			var row = GetDependant_EquipmTableManufName(this.ValCodmanuf);
			try
			{

				// Fill List fields
				this.ValCodmanuf = ViewModelConversion.ToString(row["manuf.codentit"]);
				TableManufName.Value = (string)row["manuf.name"];
				if (GlobalFunctions.emptyG(this.ValCodmanuf) == 1)
				{
					this.ValCodmanuf = "";
					TableManufName.Value = "";
					Navigation.ClearValue("manuf");
				}
				else if (lazyLoad)
				{
					TableManufName.SetPagination(1, 0, false, false, 1);
					TableManufName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodmanuf),
							Text = Convert.ToString(TableManufName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodmanuf);
				}

				TableManufName.Selected = this.ValCodmanuf;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableManufName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIPM__MANUFNAME____ = ["Manuf", "Manuf.ValCodentit", "Manuf.ValZzstate", "Manuf.ValName", "Manuf.ValInitials"];

		/// <summary>
		/// TableKindeDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equipm__kindedesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equipm__kindedesignatDoLoad = true;
			CriteriaSet equipm__kindedesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("kinde", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equipm__kindedesignatConds.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetValue("kinde"));
					this.ValCodkinde = Navigation.GetStrValue("kinde");
				}
			}

			TableKindeDesignat = new TableDBEdit<Models.Kinde>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}
				FillDependant_EquipmTableKindeDesignat(lazyLoad);
				//Check if foreignkey comes from history
				TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
				return;
			}

			if (equipm__kindedesignatDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableKindeDesignat, "sTableKindeDesignat", "dTableKindeDesignat", qs, "kinde");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAkinde.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableKindeDesignat_tableFilters"]))
					TableKindeDesignat.TableFilters = bool.Parse(qs["TableKindeDesignat_tableFilters"]);
				else
					TableKindeDesignat.TableFilters = false;

				query = qs["qTableKindeDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAkinde.FldDesignat, query + "%");
				}
				equipm__kindedesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableKindeDesignat"] != null ? qs["pTableKindeDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat, CSGenioAkinde.FldZzstate };

// USE /[MANUAL GQT OVERRQ EQUIPM_KINDEDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("kinde", FormMode.New) || Navigation.checkFormMode("kinde", FormMode.Duplicate))
					equipm__kindedesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAkinde.FldZzstate, 0)
						.Equal(CSGenioAkinde.FldCodkinde, Navigation.GetStrValue("kinde")));
				else
					equipm__kindedesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAkinde.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("kinde", "designat");
				ListingMVC<CSGenioAkinde> listing = Models.ModelBase.Where<CSGenioAkinde>(m_userContext, false, equipm__kindedesignatConds, fields, offset, numberItems, sorts, "LED_EQUIPM__KINDEDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableKindeDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableKindeDesignat.Query = query;
				TableKindeDesignat.Elements = listing.RowsForViewModel<GenioMVC.Models.Kinde>((r) => new GenioMVC.Models.Kinde(m_userContext, r, true, _fieldsToSerialize_EQUIPM__KINDEDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_kinde") != null)
				{
					this.ValCodkinde = Navigation.GetStrValue("RETURN_kinde");
					Navigation.CurrentLevel.SetEntry("RETURN_kinde", null);
				}

				TableKindeDesignat.List = new SelectList(TableKindeDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodkinde,  x => x.ValCodkinde == this.ValCodkinde), "Value", "Text", this.ValCodkinde);
				FillDependant_EquipmTableKindeDesignat();

				//Check if foreignkey comes from history
				TableKindeDesignat.FilledByHistory = Navigation.CheckFilledByHistory("kinde");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Kinde</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipmTableKindeDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAkinde.FldCodkinde, CSGenioAkinde.FldDesignat];

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

			CSGenioAkinde tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAkinde.FldCodkinde, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableKindeDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipmTableKindeDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_EquipmTableKindeDesignat(this.ValCodkinde);
			try
			{

				// Fill List fields
				this.ValCodkinde = ViewModelConversion.ToString(row["kinde.codkinde"]);
				TableKindeDesignat.Value = (string)row["kinde.designat"];
				if (GlobalFunctions.emptyG(this.ValCodkinde) == 1)
				{
					this.ValCodkinde = "";
					TableKindeDesignat.Value = "";
					Navigation.ClearValue("kinde");
				}
				else if (lazyLoad)
				{
					TableKindeDesignat.SetPagination(1, 0, false, false, 1);
					TableKindeDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodkinde),
							Text = Convert.ToString(TableKindeDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodkinde);
				}

				TableKindeDesignat.Selected = this.ValCodkinde;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableKindeDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIPM__KINDEDESIGNAT = ["Kinde", "Kinde.ValCodkinde", "Kinde.ValZzstate", "Kinde.ValDesignat"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"asset.name" => ViewModelConversion.ToString(modelValue),
				"asset.assettyp" => ViewModelConversion.ToString(modelValue),
				"asset.assetnum" => ViewModelConversion.ToNumeric(modelValue),
				"asset.identtyp" => ViewModelConversion.ToString(modelValue),
				"asset.grai" => ViewModelConversion.ToString(modelValue),
				"asset.giai" => ViewModelConversion.ToString(modelValue),
				"asset.photo" => ViewModelConversion.ToImage(modelValue),
				"asset.codkinde" => ViewModelConversion.ToString(modelValue),
				"asset.codmanuf" => ViewModelConversion.ToString(modelValue),
				"asset.codasset" => ViewModelConversion.ToString(modelValue),
				"manuf.codentit" => ViewModelConversion.ToString(modelValue),
				"manuf.name" => ViewModelConversion.ToString(modelValue),
				"kinde.codkinde" => ViewModelConversion.ToString(modelValue),
				"kinde.designat" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIPM]/

		#endregion
	}
}
