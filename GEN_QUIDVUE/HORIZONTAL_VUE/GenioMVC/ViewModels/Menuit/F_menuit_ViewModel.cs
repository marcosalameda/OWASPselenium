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

namespace GenioMVC.ViewModels.Menuit
{
	public class F_menuit_ViewModel : FormViewModel<Models.Menuit>, IPreparableForSerialization
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
		/// Title: "Menu Item Class" | Type: "CE"
		/// </summary>
		public string ValMclass { get; set; }

		#endregion
		/// <summary>
		/// Title: "Sigla" | Type: "C"
		/// </summary>
		public string ValSigl { get; set; }
		/// <summary>
		/// Title: "Order" | Type: "N"
		/// </summary>
		public decimal? ValOrder { get; set; }
		/// <summary>
		/// Title: "Menu Item Type" | Type: "C"
		/// </summary>
		public string ValMtype { get; set; }
		/// <summary>
		/// Title: "Menu Item Class" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Menuc> TableMenucMenucl { get; set; }
		/// <summary>
		/// Title: "Menu Type Description" | Type: "MO"
		/// </summary>
		public string ValMdesc { get; set; }
		/// <summary>
		/// Title: "" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 250)]
		public GenioMVC.Models.ImageModel ValMenuimg { get; set; }
		/// <summary>
		/// Title: "Example Link" | Type: "C"
		/// </summary>
		public string ValLink { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodmenuit { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_menuit_ViewModel() : base(null!) { }

		public F_menuit_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_MENUIT", nestedForm) { }

		public F_menuit_ViewModel(UserContext userContext, Models.Menuit row, bool nestedForm = false) : base(userContext, "FF_MENUIT", row, nestedForm) { }

		public F_menuit_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("menuit", id);
			Model = Models.Menuit.Find(id, userContext, "FF_MENUIT", fieldsToQuery: fieldsToLoad);
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
			Models.Menuit model = new Models.Menuit(userContext) { Identifier = "FF_MENUIT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_MENUIT");
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
		public override void MapFromModel(Models.Menuit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Menuit) to ViewModel (F_menuit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValMclass = ViewModelConversion.ToString(m.ValMclass);
				ValSigl = ViewModelConversion.ToString(m.ValSigl);
				ValOrder = ViewModelConversion.ToNumeric(m.ValOrder);
				ValMtype = ViewModelConversion.ToString(m.ValMtype);
				ValMdesc = ViewModelConversion.ToString(m.ValMdesc);
				ValMenuimg = ViewModelConversion.ToImage(m.ValMenuimg);
				ValLink = ViewModelConversion.ToString(m.ValLink);
				ValCodmenuit = ViewModelConversion.ToString(m.ValCodmenuit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Menuit) to ViewModel (F_menuit) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Menuit m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_menuit) to Model (Menuit) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValMclass = ViewModelConversion.ToString(ValMclass);
				m.ValSigl = ViewModelConversion.ToString(ValSigl);
				m.ValOrder = ViewModelConversion.ToNumeric(ValOrder);
				m.ValMtype = ViewModelConversion.ToString(ValMtype);
				m.ValMdesc = ViewModelConversion.ToString(ValMdesc);
				if (ValMenuimg == null || !ValMenuimg.IsThumbnail)
					m.ValMenuimg = ViewModelConversion.ToImage(ValMenuimg);
				m.ValLink = ViewModelConversion.ToString(ValLink);
				m.ValCodmenuit = ViewModelConversion.ToString(ValCodmenuit);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_menuit) to Model (Menuit) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "menuit.mclass":
						this.ValMclass = ViewModelConversion.ToString(_value);
						break;
					case "menuit.sigl":
						this.ValSigl = ViewModelConversion.ToString(_value);
						break;
					case "menuit.order":
						this.ValOrder = ViewModelConversion.ToNumeric(_value);
						break;
					case "menuit.mtype":
						this.ValMtype = ViewModelConversion.ToString(_value);
						break;
					case "menuit.mdesc":
						this.ValMdesc = ViewModelConversion.ToString(_value);
						break;
					case "menuit.menuimg":
						this.ValMenuimg = ViewModelConversion.ToImage(_value);
						break;
					case "menuit.link":
						this.ValLink = ViewModelConversion.ToString(_value);
						break;
					case "menuit.codmenuit":
						this.ValCodmenuit = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_menuit) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_menuit)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Menuit.Find(id ?? Navigation.GetStrValue("menuit"), m_userContext, "FF_MENUIT"); }
			finally { Model ??= new Models.Menuit(m_userContext) { Identifier = "FF_MENUIT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Menuit.Find(Navigation.GetStrValue("menuit"), m_userContext, "FF_MENUIT");
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

			Model.Identifier = "FF_MENUIT";
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

		protected override void LoadDocumentsProperties(Models.Menuit row)
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
				Model = Models.Menuit.Find(Navigation.GetStrValue("menuit"), m_userContext, "FF_MENUIT");
				if (Model == null)
				{
					Model = new Models.Menuit(m_userContext) { Identifier = "FF_MENUIT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("menuit");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_menuitmenucmenucl__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL F_MENUIT]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW F_MENUIT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValMclass", Resources.Resources.MENU_ITEM_CLASS00317, ViewModelConversion.ToString(ValMclass), FieldType.KEY_GUID.GetFormatting());
			validator.StringLength("ValSigl", Resources.Resources.SIGLA14738, ValSigl, 50);
			validator.StringLength("ValMtype", Resources.Resources.MENU_ITEM_TYPE45031, ValMtype, 50);

			validator.Required("ValMtype", Resources.Resources.MENU_ITEM_TYPE45031, ViewModelConversion.ToString(ValMtype), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValLink", Resources.Resources.EXAMPLE_LINK09181, ValLink, 50);
			validator.Hyperlink(Resources.Resources.EXAMPLE_LINK09181, ValLink);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE F_MENUIT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY F_MENUIT]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE F_MENUIT]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY F_MENUIT]/
		public override void Destroy(string id)
		{
			Model = Models.Menuit.Find(id, m_userContext, "FF_MENUIT");
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
		/// TableMenucMenucl -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_menuitmenucmenucl__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_menuitmenucmenucl__DoLoad = true;
			CriteriaSet f_menuitmenucmenucl__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("menuc", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_menuitmenucmenucl__Conds.Equal(CSGenioAmenuc.FldCodmenuc, hValue);
					this.ValMclass = DBConversion.ToString(hValue);
				}
			}

			TableMenucMenucl = new TableDBEdit<Models.Menuc>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_menuc") != null)
				{
					this.ValMclass = Navigation.GetStrValue("RETURN_menuc");
					Navigation.CurrentLevel.SetEntry("RETURN_menuc", null);
				}
				FillDependant_F_menuitTableMenucMenucl(lazyLoad);
				return;
			}

			if (f_menuitmenucmenucl__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableMenucMenucl, "sTableMenucMenucl", "dTableMenucMenucl", qs, "menuc");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAmenuc.FldMenucl), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableMenucMenucl_tableFilters"]))
					TableMenucMenucl.TableFilters = bool.Parse(qs["TableMenucMenucl_tableFilters"]);
				else
					TableMenucMenucl.TableFilters = false;

				query = qs["qTableMenucMenucl"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAmenuc.FldMenucl, query + "%");
				}
				f_menuitmenucmenucl__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableMenucMenucl"] != null ? qs["pTableMenucMenucl"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAmenuc.FldCodmenuc, CSGenioAmenuc.FldMenucl, CSGenioAmenuc.FldZzstate];

// USE /[MANUAL GQT OVERRQ F_MENUIT_MENUCMENUCL]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("menuc", FormMode.New) || Navigation.checkFormMode("menuc", FormMode.Duplicate))
					f_menuitmenucmenucl__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAmenuc.FldZzstate, 0)
						.Equal(CSGenioAmenuc.FldCodmenuc, Navigation.GetStrValue("menuc")));
				else
					f_menuitmenucmenucl__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAmenuc.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("menuc", "menucl");
				ListingMVC<CSGenioAmenuc> listing = Models.ModelBase.Where<CSGenioAmenuc>(m_userContext, false, f_menuitmenucmenucl__Conds, fields, offset, numberItems, sorts, "LED_F_MENUITMENUCMENUCL__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableMenucMenucl.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableMenucMenucl.Query = query;
				TableMenucMenucl.Elements = listing.RowsForViewModel<GenioMVC.Models.Menuc>((r) => new GenioMVC.Models.Menuc(m_userContext, r, true, _fieldsToSerialize_F_MENUITMENUCMENUCL__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_menuc") != null)
				{
					this.ValMclass = Navigation.GetStrValue("RETURN_menuc");
					Navigation.CurrentLevel.SetEntry("RETURN_menuc", null);
				}

				TableMenucMenucl.List = new SelectList(TableMenucMenucl.Elements.ToSelectList(x => x.ValMenucl, x => x.ValCodmenuc,  x => x.ValCodmenuc == this.ValMclass), "Value", "Text", this.ValMclass);
				//Seleciona se só um
				if (TableMenucMenucl.List != null && TableMenucMenucl.List.Count() == 1)
				{
					this.ValMclass = TableMenucMenucl.List.First().Value;
					Navigation.SetValue("menuc", this.ValMclass);
				}
				FillDependant_F_menuitTableMenucMenucl();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableMenucMenucl (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Menuc</param>
		public ConcurrentDictionary<string, object> GetDependant_F_menuitTableMenucMenucl(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAmenuc.FldCodmenuc, CSGenioAmenuc.FldMenucl];

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

			CSGenioAmenuc tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAmenuc.FldCodmenuc, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableMenucMenucl (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_menuitTableMenucMenucl(bool lazyLoad = false)
		{
			var row = GetDependant_F_menuitTableMenucMenucl(this.ValMclass);
			try
			{

				// Fill List fields
				this.ValMclass = ViewModelConversion.ToString(row["menuc.codmenuc"]);
				TableMenucMenucl.Value = (string)row["menuc.menucl"];
				if (GenFunctions.emptyG(this.ValMclass) == 1)
				{
					this.ValMclass = "";
					TableMenucMenucl.Value = "";
					Navigation.ClearValue("menuc");
				}
				else if (lazyLoad)
				{
					TableMenucMenucl.SetPagination(1, 0, false, false, 1);
					TableMenucMenucl.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValMclass),
							Text = Convert.ToString(TableMenucMenucl.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValMclass);
				}

				TableMenucMenucl.Selected = this.ValMclass;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableMenucMenucl): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_MENUITMENUCMENUCL__ = ["Menuc", "Menuc.ValCodmenuc", "Menuc.ValZzstate", "Menuc.ValMenucl"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"menuit.mclass" => ViewModelConversion.ToString(modelValue),
				"menuit.sigl" => ViewModelConversion.ToString(modelValue),
				"menuit.order" => ViewModelConversion.ToNumeric(modelValue),
				"menuit.mtype" => ViewModelConversion.ToString(modelValue),
				"menuit.mdesc" => ViewModelConversion.ToString(modelValue),
				"menuit.menuimg" => ViewModelConversion.ToImage(modelValue),
				"menuit.link" => ViewModelConversion.ToString(modelValue),
				"menuit.codmenuit" => ViewModelConversion.ToString(modelValue),
				"menuc.codmenuc" => ViewModelConversion.ToString(modelValue),
				"menuc.menucl" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValMenuimg != null)
				ValMenuimg.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaMENUIT, CSGenioAmenuit.FldMenuimg.Field, null, ValCodmenuit);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM F_MENUIT]/

		#endregion
	}
}
