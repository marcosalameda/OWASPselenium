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

namespace GenioMVC.ViewModels.Lnhpd
{
	public class Lnhpd_ViewModel : FormViewModel<Models.Lnhpd>, IPreparableForSerialization
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
		/// Title: "Order no:" | Type: "CE"
		/// </summary>
		public string ValCodpedid { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }

		#endregion

		/// <summary>
		/// Title: "Order no:" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pedid> TablePedidNrpedido { get; set; }
		/// <summary>
		/// Title: "Line" | Type: "N"
		/// </summary>
		public decimal? ValLine { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }
		/// <summary>
		/// Title: "Quantity" | Type: "N"
		/// </summary>
		public decimal? ValQuantida { get; set; }
		/// <summary>
		/// Title: "Amount" | Type: "ND"
		/// </summary>
		public decimal? ValQuantdec { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodlnhpd { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Lnhpd_ViewModel() : base(null!) { }

		public Lnhpd_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FLNHPD", nestedForm) { }

		public Lnhpd_ViewModel(UserContext userContext, Models.Lnhpd row, bool nestedForm = false) : base(userContext, "FLNHPD", row, nestedForm) { }

		public Lnhpd_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("lnhpd", id);
			Model = Models.Lnhpd.Find(id, userContext, "FLNHPD", fieldsToQuery: fieldsToLoad);
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
			Models.Lnhpd model = new Models.Lnhpd(userContext) { Identifier = "FLNHPD" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FLNHPD");
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
		public override void MapFromModel(Models.Lnhpd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhpd) to ViewModel (Lnhpd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodpedid = ViewModelConversion.ToString(m.ValCodpedid);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValLine = ViewModelConversion.ToNumeric(m.ValLine);
				ValQuantida = ViewModelConversion.ToNumeric(m.ValQuantida);
				ValQuantdec = ViewModelConversion.ToNumeric(m.ValQuantdec);
				ValCodlnhpd = ViewModelConversion.ToString(m.ValCodlnhpd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Lnhpd) to ViewModel (Lnhpd) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Lnhpd m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Lnhpd) to Model (Lnhpd) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodpedid = ViewModelConversion.ToString(ValCodpedid);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValLine = ViewModelConversion.ToNumeric(ValLine);
				m.ValQuantida = ViewModelConversion.ToNumeric(ValQuantida);
				m.ValQuantdec = ViewModelConversion.ToNumeric(ValQuantdec);
				m.ValCodlnhpd = ViewModelConversion.ToString(ValCodlnhpd);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Lnhpd) to Model (Lnhpd) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "lnhpd.codpedid":
						this.ValCodpedid = ViewModelConversion.ToString(_value);
						break;
					case "lnhpd.codtpequ":
						this.ValCodtpequ = ViewModelConversion.ToString(_value);
						break;
					case "lnhpd.line":
						this.ValLine = ViewModelConversion.ToNumeric(_value);
						break;
					case "lnhpd.quantida":
						this.ValQuantida = ViewModelConversion.ToNumeric(_value);
						break;
					case "lnhpd.quantdec":
						this.ValQuantdec = ViewModelConversion.ToNumeric(_value);
						break;
					case "lnhpd.codlnhpd":
						this.ValCodlnhpd = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Lnhpd) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Lnhpd)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Lnhpd.Find(id ?? Navigation.GetStrValue("lnhpd"), m_userContext, "FLNHPD"); }
			finally { Model ??= new Models.Lnhpd(m_userContext) { Identifier = "FLNHPD" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), m_userContext, "FLNHPD");
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

			Model.Identifier = "FLNHPD";
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

		protected override void LoadDocumentsProperties(Models.Lnhpd row)
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
				Model = Models.Lnhpd.Find(Navigation.GetStrValue("lnhpd"), m_userContext, "FLNHPD");
				if (Model == null)
				{
					Model = new Models.Lnhpd(m_userContext) { Identifier = "FLNHPD" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Lnhpd___pedidnrpedido(qs, lazyLoad);
			Load_Lnhpd___tpequtipoequi(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL LNHPD]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW LNHPD]/

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
// USE /[MANUAL GQT VIEWMODEL_SAVE LNHPD]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY LNHPD]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE LNHPD]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY LNHPD]/
		public override void Destroy(string id)
		{
			Model = Models.Lnhpd.Find(id, m_userContext, "FLNHPD");
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
		/// TablePedidNrpedido -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhpd___pedidnrpedido(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhpd___pedidnrpedidoDoLoad = true;
			CriteriaSet lnhpd___pedidnrpedidoConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pedid", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhpd___pedidnrpedidoConds.Equal(CSGenioApedid.FldCodpedid, hValue);
					this.ValCodpedid = DBConversion.ToString(hValue);
				}
			}

			TablePedidNrpedido = new TableDBEdit<Models.Pedid>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}
				FillDependant_LnhpdTablePedidNrpedido(lazyLoad);
				return;
			}

			if (lnhpd___pedidnrpedidoDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePedidNrpedido, "sTablePedidNrpedido", "dTablePedidNrpedido", qs, "pedid");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePedidNrpedido_tableFilters"]))
					TablePedidNrpedido.TableFilters = bool.Parse(qs["TablePedidNrpedido_tableFilters"]);
				else
					TablePedidNrpedido.TableFilters = false;

				query = qs["qTablePedidNrpedido"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApedid.FldNrpedido, query + "%");
				}
				lnhpd___pedidnrpedidoConds.SubSet(search_filters);

				string tryParsePage = qs["pTablePedidNrpedido"] != null ? qs["pTablePedidNrpedido"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido, CSGenioApedid.FldZzstate];

// USE /[MANUAL GQT OVERRQ LNHPD_PEDIDNRPEDIDO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pedid", FormMode.New) || Navigation.checkFormMode("pedid", FormMode.Duplicate))
					lnhpd___pedidnrpedidoConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApedid.FldZzstate, 0)
						.Equal(CSGenioApedid.FldCodpedid, Navigation.GetStrValue("pedid")));
				else
					lnhpd___pedidnrpedidoConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApedid.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pedid", "nrpedido");
				ListingMVC<CSGenioApedid> listing = Models.ModelBase.Where<CSGenioApedid>(m_userContext, false, lnhpd___pedidnrpedidoConds, fields, offset, numberItems, sorts, "LED_LNHPD___PEDIDNRPEDIDO", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePedidNrpedido.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePedidNrpedido.Query = query;
				TablePedidNrpedido.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Pedid(m_userContext, r, true, _fieldsToSerialize_LNHPD___PEDIDNRPEDIDO));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pedid") != null)
				{
					this.ValCodpedid = Navigation.GetStrValue("RETURN_pedid");
					Navigation.CurrentLevel.SetEntry("RETURN_pedid", null);
				}

				TablePedidNrpedido.List = new SelectList(TablePedidNrpedido.Elements.ToSelectList(x => x.ValNrpedido, x => x.ValCodpedid,  x => x.ValCodpedid == this.ValCodpedid), "Value", "Text", this.ValCodpedid);
				FillDependant_LnhpdTablePedidNrpedido();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePedidNrpedido (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pedid</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhpdTablePedidNrpedido(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApedid.FldCodpedid, CSGenioApedid.FldNrpedido];

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

			CSGenioApedid tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApedid.FldCodpedid, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePedidNrpedido (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LnhpdTablePedidNrpedido(bool lazyLoad = false)
		{
			var row = GetDependant_LnhpdTablePedidNrpedido(this.ValCodpedid);
			try
			{

				// Fill List fields
				this.ValCodpedid = ViewModelConversion.ToString(row["pedid.codpedid"]);
				TablePedidNrpedido.Value = (decimal?)row["pedid.nrpedido"];
				if (GenFunctions.emptyG(this.ValCodpedid) == 1)
				{
					this.ValCodpedid = "";
					TablePedidNrpedido.Value = 0m;
					Navigation.ClearValue("pedid");
				}
				else if (lazyLoad)
				{
					TablePedidNrpedido.SetPagination(1, 0, false, false, 1);
					TablePedidNrpedido.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpedid),
							Text = Convert.ToString(TablePedidNrpedido.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpedid);
				}

				TablePedidNrpedido.Selected = this.ValCodpedid;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePedidNrpedido): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LNHPD___PEDIDNRPEDIDO = ["Pedid", "Pedid.ValCodpedid", "Pedid.ValZzstate", "Pedid.ValNrpedido"];

		/// <summary>
		/// TableTpequTipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Lnhpd___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool lnhpd___tpequtipoequiDoLoad = true;
			CriteriaSet lnhpd___tpequtipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpequ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					lnhpd___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, hValue);
					this.ValCodtpequ = DBConversion.ToString(hValue);
				}
			}

			TableTpequTipoequi = new TableDBEdit<Models.Tpequ>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
				FillDependant_LnhpdTableTpequTipoequi(lazyLoad);
				return;
			}

			if (lnhpd___tpequtipoequiDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTipoequi), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
					TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
				else
					TableTpequTipoequi.TableFilters = false;

				query = qs["qTableTpequTipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
				}
				lnhpd___tpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate];

// USE /[MANUAL GQT OVERRQ LNHPD_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					lnhpd___tpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					lnhpd___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, lnhpd___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_LNHPD___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_LNHPD___TPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_LnhpdTableTpequTipoequi();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_LnhpdTableTpequTipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi];

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

			CSGenioAtpequ tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_LnhpdTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_LnhpdTableTpequTipoequi(this.ValCodtpequ);
			try
			{

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
				TableTpequTipoequi.Value = (string)row["tpequ.tipoequi"];
				if (GenFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
					TableTpequTipoequi.Value = "";
					Navigation.ClearValue("tpequ");
				}
				else if (lazyLoad)
				{
					TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
					TableTpequTipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpequTipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpequTipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_LNHPD___TPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"lnhpd.codpedid" => ViewModelConversion.ToString(modelValue),
				"lnhpd.codtpequ" => ViewModelConversion.ToString(modelValue),
				"lnhpd.line" => ViewModelConversion.ToNumeric(modelValue),
				"lnhpd.quantida" => ViewModelConversion.ToNumeric(modelValue),
				"lnhpd.quantdec" => ViewModelConversion.ToNumeric(modelValue),
				"lnhpd.codlnhpd" => ViewModelConversion.ToString(modelValue),
				"pedid.codpedid" => ViewModelConversion.ToString(modelValue),
				"pedid.nrpedido" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM LNHPD]/

		#endregion
	}
}
