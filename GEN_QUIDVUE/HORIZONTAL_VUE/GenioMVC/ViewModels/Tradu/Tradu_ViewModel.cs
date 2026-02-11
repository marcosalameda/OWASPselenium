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

namespace GenioMVC.ViewModels.Tradu
{
	public class Tradu_ViewModel : FormViewModel<Models.Tradu>, IPreparableForSerialization
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
		/// Title: "Language" | Type: "CE"
		/// </summary>
		public string ValCodidio1 { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "CE"
		/// </summary>
		public string ValCodidio2 { get; set; }

		#endregion
		/// <summary>
		/// Title: "Reference" | Type: "C"
		/// </summary>
		public string ValReferenc { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Lang1> TableLang1Langua { get; set; }
		/// <summary>
		/// Title: "To translate" | Type: "C"
		/// </summary>
		public string ValAtraduzi { get; set; }
		/// <summary>
		/// Title: "Language" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Lang2> TableLang2Langua { get; set; }
		/// <summary>
		/// Title: "Translated" | Type: "C"
		/// </summary>
		public string ValTraduzid { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtradu { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Tradu_ViewModel() : base(null!) { }

		public Tradu_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTRADU", nestedForm) { }

		public Tradu_ViewModel(UserContext userContext, Models.Tradu row, bool nestedForm = false) : base(userContext, "FTRADU", row, nestedForm) { }

		public Tradu_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tradu", id);
			Model = Models.Tradu.Find(id, userContext, "FTRADU", fieldsToQuery: fieldsToLoad);
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
			Models.Tradu model = new Models.Tradu(userContext) { Identifier = "FTRADU" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FTRADU");
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
		public override void MapFromModel(Models.Tradu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tradu) to ViewModel (Tradu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodidio1 = ViewModelConversion.ToString(m.ValCodidio1);
				ValCodidio2 = ViewModelConversion.ToString(m.ValCodidio2);
				ValReferenc = ViewModelConversion.ToString(m.ValReferenc);
				ValAtraduzi = ViewModelConversion.ToString(m.ValAtraduzi);
				ValTraduzid = ViewModelConversion.ToString(m.ValTraduzid);
				ValCodtradu = ViewModelConversion.ToString(m.ValCodtradu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tradu) to ViewModel (Tradu) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Tradu m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Tradu) to Model (Tradu) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodidio1 = ViewModelConversion.ToString(ValCodidio1);
				m.ValCodidio2 = ViewModelConversion.ToString(ValCodidio2);
				m.ValReferenc = ViewModelConversion.ToString(ValReferenc);
				m.ValAtraduzi = ViewModelConversion.ToString(ValAtraduzi);
				m.ValTraduzid = ViewModelConversion.ToString(ValTraduzid);
				m.ValCodtradu = ViewModelConversion.ToString(ValCodtradu);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Tradu) to Model (Tradu) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "tradu.codidio1":
						this.ValCodidio1 = ViewModelConversion.ToString(_value);
						break;
					case "tradu.codidio2":
						this.ValCodidio2 = ViewModelConversion.ToString(_value);
						break;
					case "tradu.referenc":
						this.ValReferenc = ViewModelConversion.ToString(_value);
						break;
					case "tradu.atraduzi":
						this.ValAtraduzi = ViewModelConversion.ToString(_value);
						break;
					case "tradu.traduzid":
						this.ValTraduzid = ViewModelConversion.ToString(_value);
						break;
					case "tradu.codtradu":
						this.ValCodtradu = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Tradu) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Tradu)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Tradu.Find(id ?? Navigation.GetStrValue("tradu"), m_userContext, "FTRADU"); }
			finally { Model ??= new Models.Tradu(m_userContext) { Identifier = "FTRADU" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), m_userContext, "FTRADU");
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

			Model.Identifier = "FTRADU";
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

		protected override void LoadDocumentsProperties(Models.Tradu row)
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
				Model = Models.Tradu.Find(Navigation.GetStrValue("tradu"), m_userContext, "FTRADU");
				if (Model == null)
				{
					Model = new Models.Tradu(m_userContext) { Identifier = "FTRADU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tradu");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Tradu___lang1langua__(qs, lazyLoad);
			Load_Tradu___lang2langua__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL TRADU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW TRADU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValReferenc", Resources.Resources.REFERENCE28402, ValReferenc, 50);
			validator.StringLength("ValAtraduzi", Resources.Resources.TO_TRANSLATE20058, ValAtraduzi, 50);
			validator.StringLength("ValTraduzid", Resources.Resources.TRANSLATED03333, ValTraduzid, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE TRADU]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY TRADU]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE TRADU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY TRADU]/
		public override void Destroy(string id)
		{
			Model = Models.Tradu.Find(id, m_userContext, "FTRADU");
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
		/// TableLang1Langua -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tradu___lang1langua__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tradu___lang1langua__DoLoad = true;
			CriteriaSet tradu___lang1langua__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("lang1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tradu___lang1langua__Conds.Equal(CSGenioAlang1.FldCodlang, hValue);
					this.ValCodidio1 = DBConversion.ToString(hValue);
				}
			}

			TableLang1Langua = new TableDBEdit<Models.Lang1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_lang1") != null)
				{
					this.ValCodidio1 = Navigation.GetStrValue("RETURN_lang1");
					Navigation.CurrentLevel.SetEntry("RETURN_lang1", null);
				}
				FillDependant_TraduTableLang1Langua(lazyLoad);
				return;
			}

			if (tradu___lang1langua__DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableLang1Langua, "sTableLang1Langua", "dTableLang1Langua", qs, "lang1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlang1.FldLangua), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLang1Langua_tableFilters"]))
					TableLang1Langua.TableFilters = bool.Parse(qs["TableLang1Langua_tableFilters"]);
				else
					TableLang1Langua.TableFilters = false;

				query = qs["qTableLang1Langua"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlang1.FldLangua, query + "%");
				}
				tradu___lang1langua__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLang1Langua"] != null ? qs["pTableLang1Langua"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAlang1.FldCodlang, CSGenioAlang1.FldLangua, CSGenioAlang1.FldZzstate];

// USE /[MANUAL GQT OVERRQ TRADU_LANG1LANGUA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("lang1", FormMode.New) || Navigation.checkFormMode("lang1", FormMode.Duplicate))
					tradu___lang1langua__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlang1.FldZzstate, 0)
						.Equal(CSGenioAlang1.FldCodlang, Navigation.GetStrValue("lang1")));
				else
					tradu___lang1langua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlang1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("lang1", "langua");
				ListingMVC<CSGenioAlang1> listing = Models.ModelBase.Where<CSGenioAlang1>(m_userContext, false, tradu___lang1langua__Conds, fields, offset, numberItems, sorts, "LED_TRADU___LANG1LANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLang1Langua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLang1Langua.Query = query;
				TableLang1Langua.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Lang1(m_userContext, r, true, _fieldsToSerialize_TRADU___LANG1LANGUA__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_lang1") != null)
				{
					this.ValCodidio1 = Navigation.GetStrValue("RETURN_lang1");
					Navigation.CurrentLevel.SetEntry("RETURN_lang1", null);
				}

				TableLang1Langua.List = new SelectList(TableLang1Langua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodidio1), "Value", "Text", this.ValCodidio1);
				FillDependant_TraduTableLang1Langua();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLang1Langua (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Lang1</param>
		public ConcurrentDictionary<string, object> GetDependant_TraduTableLang1Langua(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlang1.FldCodlang, CSGenioAlang1.FldLangua];

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

			CSGenioAlang1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlang1.FldCodlang, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLang1Langua (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TraduTableLang1Langua(bool lazyLoad = false)
		{
			var row = GetDependant_TraduTableLang1Langua(this.ValCodidio1);
			try
			{

				// Fill List fields
				this.ValCodidio1 = ViewModelConversion.ToString(row["lang1.codlang"]);
				TableLang1Langua.Value = (string)row["lang1.langua"];
				if (GenFunctions.emptyG(this.ValCodidio1) == 1)
				{
					this.ValCodidio1 = "";
					TableLang1Langua.Value = "";
					Navigation.ClearValue("lang1");
				}
				else if (lazyLoad)
				{
					TableLang1Langua.SetPagination(1, 0, false, false, 1);
					TableLang1Langua.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodidio1),
							Text = Convert.ToString(TableLang1Langua.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodidio1);
				}

				TableLang1Langua.Selected = this.ValCodidio1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLang1Langua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TRADU___LANG1LANGUA__ = ["Lang1", "Lang1.ValCodlang", "Lang1.ValZzstate", "Lang1.ValLangua"];

		/// <summary>
		/// TableLang2Langua -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Tradu___lang2langua__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool tradu___lang2langua__DoLoad = true;
			CriteriaSet tradu___lang2langua__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("lang2", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					tradu___lang2langua__Conds.Equal(CSGenioAlang2.FldCodlang, hValue);
					this.ValCodidio2 = DBConversion.ToString(hValue);
				}
			}

			TableLang2Langua = new TableDBEdit<Models.Lang2>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_lang2") != null)
				{
					this.ValCodidio2 = Navigation.GetStrValue("RETURN_lang2");
					Navigation.CurrentLevel.SetEntry("RETURN_lang2", null);
				}
				FillDependant_TraduTableLang2Langua(lazyLoad);
				return;
			}

			if (tradu___lang2langua__DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableLang2Langua, "sTableLang2Langua", "dTableLang2Langua", qs, "lang2");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlang2.FldLangua), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableLang2Langua_tableFilters"]))
					TableLang2Langua.TableFilters = bool.Parse(qs["TableLang2Langua_tableFilters"]);
				else
					TableLang2Langua.TableFilters = false;

				query = qs["qTableLang2Langua"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAlang2.FldLangua, query + "%");
				}
				tradu___lang2langua__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableLang2Langua"] != null ? qs["pTableLang2Langua"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAlang2.FldCodlang, CSGenioAlang2.FldLangua, CSGenioAlang2.FldZzstate];

// USE /[MANUAL GQT OVERRQ TRADU_LANG2LANGUA]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("lang2", FormMode.New) || Navigation.checkFormMode("lang2", FormMode.Duplicate))
					tradu___lang2langua__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAlang2.FldZzstate, 0)
						.Equal(CSGenioAlang2.FldCodlang, Navigation.GetStrValue("lang2")));
				else
					tradu___lang2langua__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAlang2.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("lang2", "langua");
				ListingMVC<CSGenioAlang2> listing = Models.ModelBase.Where<CSGenioAlang2>(m_userContext, false, tradu___lang2langua__Conds, fields, offset, numberItems, sorts, "LED_TRADU___LANG2LANGUA__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableLang2Langua.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableLang2Langua.Query = query;
				TableLang2Langua.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Lang2(m_userContext, r, true, _fieldsToSerialize_TRADU___LANG2LANGUA__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_lang2") != null)
				{
					this.ValCodidio2 = Navigation.GetStrValue("RETURN_lang2");
					Navigation.CurrentLevel.SetEntry("RETURN_lang2", null);
				}

				TableLang2Langua.List = new SelectList(TableLang2Langua.Elements.ToSelectList(x => x.ValLangua, x => x.ValCodlang,  x => x.ValCodlang == this.ValCodidio2), "Value", "Text", this.ValCodidio2);
				FillDependant_TraduTableLang2Langua();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableLang2Langua (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Lang2</param>
		public ConcurrentDictionary<string, object> GetDependant_TraduTableLang2Langua(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAlang2.FldCodlang, CSGenioAlang2.FldLangua];

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

			CSGenioAlang2 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAlang2.FldCodlang, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableLang2Langua (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TraduTableLang2Langua(bool lazyLoad = false)
		{
			var row = GetDependant_TraduTableLang2Langua(this.ValCodidio2);
			try
			{

				// Fill List fields
				this.ValCodidio2 = ViewModelConversion.ToString(row["lang2.codlang"]);
				TableLang2Langua.Value = (string)row["lang2.langua"];
				if (GenFunctions.emptyG(this.ValCodidio2) == 1)
				{
					this.ValCodidio2 = "";
					TableLang2Langua.Value = "";
					Navigation.ClearValue("lang2");
				}
				else if (lazyLoad)
				{
					TableLang2Langua.SetPagination(1, 0, false, false, 1);
					TableLang2Langua.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodidio2),
							Text = Convert.ToString(TableLang2Langua.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodidio2);
				}

				TableLang2Langua.Selected = this.ValCodidio2;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableLang2Langua): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TRADU___LANG2LANGUA__ = ["Lang2", "Lang2.ValCodlang", "Lang2.ValZzstate", "Lang2.ValLangua"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tradu.codidio1" => ViewModelConversion.ToString(modelValue),
				"tradu.codidio2" => ViewModelConversion.ToString(modelValue),
				"tradu.referenc" => ViewModelConversion.ToString(modelValue),
				"tradu.atraduzi" => ViewModelConversion.ToString(modelValue),
				"tradu.traduzid" => ViewModelConversion.ToString(modelValue),
				"tradu.codtradu" => ViewModelConversion.ToString(modelValue),
				"lang1.codlang" => ViewModelConversion.ToString(modelValue),
				"lang1.langua" => ViewModelConversion.ToString(modelValue),
				"lang2.codlang" => ViewModelConversion.ToString(modelValue),
				"lang2.langua" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TRADU]/

		#endregion
	}
}
