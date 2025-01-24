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

namespace GenioMVC.ViewModels.Roigf
{
	public class Roigf_ViewModel : FormViewModel<Models.Roigf>, IPreparableForSerialization
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
		/// Title: "Title" | Type: "CE"
		/// </summary>
		public string ValCodrogl1 { get; set; }

		#endregion
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Rogl1> TableRogl1Title { get; set; }
		/// <summary>
		/// Title: "Order" | Type: "N"
		/// </summary>
		public decimal? ValOrder { get; set; }
		/// <summary>
		/// Title: "Title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodroigf { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Roigf_ViewModel() : base(null!) { }

		public Roigf_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FROIGF", nestedForm) { }

		public Roigf_ViewModel(UserContext userContext, Models.Roigf row, bool nestedForm = false) : base(userContext, "FROIGF", row, nestedForm) { }

		public Roigf_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("roigf", id);
			Model = Models.Roigf.Find(id, userContext, "FROIGF", fieldsToQuery: fieldsToLoad);
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
			Models.Roigf model = new Models.Roigf(userContext) { Identifier = "FROIGF" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FROIGF");
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
			Models.Roigf model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Roigf m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Roigf) to ViewModel (Roigf) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodrogl1 = ViewModelConversion.ToString(m.ValCodrogl1);
				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValCodroigf = ViewModelConversion.ToString(m.ValCodroigf);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Roigf) to ViewModel (Roigf) - Error during mapping");
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
		public override void MapToModel(Models.Roigf m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Roigf) to Model (Roigf) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodrogl1 = ViewModelConversion.ToString(ValCodrogl1);
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValCodroigf = ViewModelConversion.ToString(ValCodroigf);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Roigf) to Model (Roigf) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "roigf.codrogl1":
						this.ValCodrogl1 = ViewModelConversion.ToString(_value);
						break;
					case "roigf.order":
						this.ValOrder = ViewModelConversion.ToNumeric(_value);
						break;
					case "roigf.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "roigf.codroigf":
						this.ValCodroigf = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Roigf) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Roigf)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Roigf.Find(id ?? Navigation.GetStrValue("roigf"), m_userContext, "FROIGF"); }
			finally { Model ??= new Models.Roigf(m_userContext) { Identifier = "FROIGF" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Roigf.Find(Navigation.GetStrValue("roigf"), m_userContext, "FROIGF");
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

			Model.Identifier = "FROIGF";
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

		protected override void LoadDocumentsProperties(Models.Roigf row)
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
				Model = Models.Roigf.Find(Navigation.GetStrValue("roigf"), m_userContext, "FROIGF");
				if (Model == null)
				{
					Model = new Models.Roigf(m_userContext) { Identifier = "FROIGF" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("roigf");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Roigf___rogl1title___(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ROIGF]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ROIGF]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTitle", Resources.Resources.TITLE21885, ValTitle, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE ROIGF]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ROIGF]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ROIGF]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ROIGF]/
		public override void Destroy(string id)
		{
			Model = Models.Roigf.Find(id, m_userContext, "FROIGF");
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
		/// TableRogl1Title -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Roigf___rogl1title___(NameValueCollection qs, bool lazyLoad = false)
		{
			bool roigf___rogl1title___DoLoad = true;
			CriteriaSet roigf___rogl1title___Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("rogl1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					roigf___rogl1title___Conds.Equal(CSGenioArogl1.FldCodrogl1, hValue);
					this.ValCodrogl1 = DBConversion.ToString(hValue);
				}
			}

			TableRogl1Title = new TableDBEdit<Models.Rogl1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_rogl1") != null)
				{
					this.ValCodrogl1 = Navigation.GetStrValue("RETURN_rogl1");
					Navigation.CurrentLevel.SetEntry("RETURN_rogl1", null);
				}
				FillDependant_RoigfTableRogl1Title(lazyLoad);
				return;
			}

			if (roigf___rogl1title___DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRogl1Title, "sTableRogl1Title", "dTableRogl1Title", qs, "rogl1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioArogl1.FldTitle), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRogl1Title_tableFilters"]))
					TableRogl1Title.TableFilters = bool.Parse(qs["TableRogl1Title_tableFilters"]);
				else
					TableRogl1Title.TableFilters = false;

				query = qs["qTableRogl1Title"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioArogl1.FldTitle, query + "%");
				}
				roigf___rogl1title___Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRogl1Title"] != null ? qs["pTableRogl1Title"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioArogl1.FldCodrogl1, CSGenioArogl1.FldTitle, CSGenioArogl1.FldZzstate };

// USE /[MANUAL GQT OVERRQ ROIGF_ROGL1TITLE]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("rogl1", FormMode.New) || Navigation.checkFormMode("rogl1", FormMode.Duplicate))
					roigf___rogl1title___Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioArogl1.FldZzstate, 0)
						.Equal(CSGenioArogl1.FldCodrogl1, Navigation.GetStrValue("rogl1")));
				else
					roigf___rogl1title___Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArogl1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("rogl1", "title");
				ListingMVC<CSGenioArogl1> listing = Models.ModelBase.Where<CSGenioArogl1>(m_userContext, false, roigf___rogl1title___Conds, fields, offset, numberItems, sorts, "LED_ROIGF___ROGL1TITLE___", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRogl1Title.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRogl1Title.Query = query;
				TableRogl1Title.Elements = listing.RowsForViewModel<GenioMVC.Models.Rogl1>((r) => new GenioMVC.Models.Rogl1(m_userContext, r, true, _fieldsToSerialize_ROIGF___ROGL1TITLE___));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_rogl1") != null)
				{
					this.ValCodrogl1 = Navigation.GetStrValue("RETURN_rogl1");
					Navigation.CurrentLevel.SetEntry("RETURN_rogl1", null);
				}

				TableRogl1Title.List = new SelectList(TableRogl1Title.Elements.ToSelectList(x => x.ValTitle, x => x.ValCodrogl1,  x => x.ValCodrogl1 == this.ValCodrogl1), "Value", "Text", this.ValCodrogl1);
				FillDependant_RoigfTableRogl1Title();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRogl1Title (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Rogl1</param>
		public ConcurrentDictionary<string, object> GetDependant_RoigfTableRogl1Title(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioArogl1.FldCodrogl1, CSGenioArogl1.FldTitle];

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

			CSGenioArogl1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioArogl1.FldCodrogl1, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRogl1Title (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_RoigfTableRogl1Title(bool lazyLoad = false)
		{
			var row = GetDependant_RoigfTableRogl1Title(this.ValCodrogl1);
			try
			{

				// Fill List fields
				this.ValCodrogl1 = ViewModelConversion.ToString(row["rogl1.codrogl1"]);
				TableRogl1Title.Value = (string)row["rogl1.title"];
				if (GlobalFunctions.emptyG(this.ValCodrogl1) == 1)
				{
					this.ValCodrogl1 = "";
					TableRogl1Title.Value = "";
					Navigation.ClearValue("rogl1");
				}
				else if (lazyLoad)
				{
					TableRogl1Title.SetPagination(1, 0, false, false, 1);
					TableRogl1Title.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodrogl1),
							Text = Convert.ToString(TableRogl1Title.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodrogl1);
				}

				TableRogl1Title.Selected = this.ValCodrogl1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRogl1Title): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_ROIGF___ROGL1TITLE___ = ["Rogl1", "Rogl1.ValCodrogl1", "Rogl1.ValZzstate", "Rogl1.ValTitle"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"roigf.codrogl1" => ViewModelConversion.ToString(modelValue),
				"roigf.order" => ViewModelConversion.ToNumeric(modelValue),
				"roigf.title" => ViewModelConversion.ToString(modelValue),
				"roigf.codroigf" => ViewModelConversion.ToString(modelValue),
				"rogl1.codrogl1" => ViewModelConversion.ToString(modelValue),
				"rogl1.title" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM ROIGF]/

		#endregion
	}
}
