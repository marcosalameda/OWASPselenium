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

namespace GenioMVC.ViewModels.Propr
{
	public class Propr00_ViewModel : FormViewModel<Models.Propr>, IPreparableForSerialization
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
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodpais1 { get; set; }
		/// <summary>
		/// Title: "Seller" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }
		/// <summary>
		/// Title: "Region" | Type: "CE"
		/// </summary>
		public string ValCodregia { get; set; }
		/// <summary>
		/// Title: "Property Type" | Type: "CE"
		/// </summary>
		public string ValCodtppro { get; set; }

		#endregion
		/// <summary>
		/// Title: "Real estate" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Estimated price" | Type: "$D"
		/// </summary>
		public decimal? ValPrecoest { get; set; }
		/// <summary>
		/// Title: "Property Type" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Tppro> TableTpproTppropri { get; set; }
		/// <summary>
		/// Title: "Furnished" | Type: "L"
		/// </summary>
		public bool ValMobilada { get; set; }
		/// <summary>
		/// Title: "Seller" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pesso> TablePessoName { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(100, 50)]
		public GenioMVC.Models.ImageModel ValPhotogra { get; set; }
		/// <summary>
		/// Title: "Bathroom" | Type: "N"
		/// </summary>
		public decimal? ValQtd_wc { get; set; }
		/// <summary>
		/// Title: "Quartos" | Type: "N"
		/// </summary>
		public decimal? ValQtdquart { get; set; }
		/// <summary>
		/// Title: "Square meters" | Type: "N"
		/// </summary>
		public decimal? ValM2 { get; set; }
		/// <summary>
		/// Title: "Available from" | Type: "D"
		/// </summary>
		public DateTime? ValDtdispon { get; set; }
		/// <summary>
		/// Title: "Address" | Type: "MO"
		/// </summary>
		public string ValEndereco { get; set; }
		/// <summary>
		/// Title: "Localization" | Type: "C"
		/// </summary>
		public string ValLocalida { get; set; }
		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValPostalco { get; set; }
		/// <summary>
		/// Title: "Zipcode" | Type: "C"
		/// </summary>
		public string ValPostallo { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }
		/// <summary>
		/// Title: "Region" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Regio> TableRegioRegiao { get; set; }
		/// <summary>
		/// Title: "Geographic Coordinates" | Type: "GG"
		/// </summary>
		public string ValCoordgeo { get; set; }
		/// <summary>
		/// Title: "Description" | Type: "MO"
		/// </summary>
		public string ValDescript { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodpropr { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Propr00_ViewModel() : base(null!) { }

		public Propr00_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FPROPR00", nestedForm) { }

		public Propr00_ViewModel(UserContext userContext, Models.Propr row, bool nestedForm = false) : base(userContext, "FPROPR00", row, nestedForm) { }

		public Propr00_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("propr", id);
			Model = Models.Propr.Find(id, userContext, "FPROPR00", fieldsToQuery: fieldsToLoad);
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
			Models.Propr model = new Models.Propr(userContext) { Identifier = "FPROPR00" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FPROPR00");
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
		public override void MapFromModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Propr00) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValCodpais1 = ViewModelConversion.ToString(m.ValCodpais1);
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValCodregia = ViewModelConversion.ToString(m.ValCodregia);
				ValCodtppro = ViewModelConversion.ToString(m.ValCodtppro);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValPrecoest = ViewModelConversion.ToNumeric(m.ValPrecoest);
				ValMobilada = ViewModelConversion.ToLogic(m.ValMobilada);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValQtd_wc = ViewModelConversion.ToNumeric(m.ValQtd_wc);
				ValQtdquart = ViewModelConversion.ToNumeric(m.ValQtdquart);
				ValM2 = ViewModelConversion.ToNumeric(m.ValM2);
				ValDtdispon = ViewModelConversion.ToDateTime(m.ValDtdispon);
				ValEndereco = ViewModelConversion.ToString(m.ValEndereco);
				ValLocalida = ViewModelConversion.ToString(m.ValLocalida);
				ValPostalco = ViewModelConversion.ToString(m.ValPostalco);
				ValPostallo = ViewModelConversion.ToString(m.ValPostallo);
				ValCoordgeo = ViewModelConversion.ToString(m.ValCoordgeo);
				ValDescript = ViewModelConversion.ToString(m.ValDescript);
				ValCodpropr = ViewModelConversion.ToString(m.ValCodpropr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Propr) to ViewModel (Propr00) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Propr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Propr00) to Model (Propr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValCodregia = ViewModelConversion.ToString(ValCodregia);
				m.ValCodtppro = ViewModelConversion.ToString(ValCodtppro);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValPrecoest = ViewModelConversion.ToNumeric(ValPrecoest);
				m.ValMobilada = ViewModelConversion.ToLogic(ValMobilada);
				if (ValPhotogra == null || !ValPhotogra.IsThumbnail)
					m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValQtd_wc = ViewModelConversion.ToNumeric(ValQtd_wc);
				m.ValQtdquart = ViewModelConversion.ToNumeric(ValQtdquart);
				m.ValM2 = ViewModelConversion.ToNumeric(ValM2);
				m.ValDtdispon = ViewModelConversion.ToDateTime(ValDtdispon);
				m.ValEndereco = ViewModelConversion.ToString(ValEndereco);
				m.ValLocalida = ViewModelConversion.ToString(ValLocalida);
				m.ValPostalco = ViewModelConversion.ToString(ValPostalco);
				m.ValPostallo = ViewModelConversion.ToString(ValPostallo);
				m.ValCoordgeo = ViewModelConversion.ToString(ValCoordgeo);
				m.ValDescript = ViewModelConversion.ToString(ValDescript);
				m.ValCodpropr = ViewModelConversion.ToString(ValCodpropr);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodpais1 = ViewModelConversion.ToString(ValCodpais1);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Propr00) to Model (Propr) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "propr.codcntry":
						this.ValCodcntry = ViewModelConversion.ToString(_value);
						break;
					case "propr.codpesso":
						this.ValCodpesso = ViewModelConversion.ToString(_value);
						break;
					case "propr.codregia":
						this.ValCodregia = ViewModelConversion.ToString(_value);
						break;
					case "propr.codtppro":
						this.ValCodtppro = ViewModelConversion.ToString(_value);
						break;
					case "propr.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "propr.precoest":
						this.ValPrecoest = ViewModelConversion.ToNumeric(_value);
						break;
					case "propr.mobilada":
						this.ValMobilada = ViewModelConversion.ToLogic(_value);
						break;
					case "propr.photogra":
						this.ValPhotogra = ViewModelConversion.ToImage(_value);
						break;
					case "propr.qtd_wc":
						this.ValQtd_wc = ViewModelConversion.ToNumeric(_value);
						break;
					case "propr.qtdquart":
						this.ValQtdquart = ViewModelConversion.ToNumeric(_value);
						break;
					case "propr.m2":
						this.ValM2 = ViewModelConversion.ToNumeric(_value);
						break;
					case "propr.dtdispon":
						this.ValDtdispon = ViewModelConversion.ToDateTime(_value);
						break;
					case "propr.endereco":
						this.ValEndereco = ViewModelConversion.ToString(_value);
						break;
					case "propr.localida":
						this.ValLocalida = ViewModelConversion.ToString(_value);
						break;
					case "propr.postalco":
						this.ValPostalco = ViewModelConversion.ToString(_value);
						break;
					case "propr.postallo":
						this.ValPostallo = ViewModelConversion.ToString(_value);
						break;
					case "propr.coordgeo":
						this.ValCoordgeo = ViewModelConversion.ToString(_value);
						break;
					case "propr.descript":
						this.ValDescript = ViewModelConversion.ToString(_value);
						break;
					case "propr.codpropr":
						this.ValCodpropr = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Propr00) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Propr00)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Propr.Find(id ?? Navigation.GetStrValue("propr"), m_userContext, "FPROPR00"); }
			finally { Model ??= new Models.Propr(m_userContext) { Identifier = "FPROPR00" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPR00");
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

			Model.Identifier = "FPROPR00";
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

		protected override void LoadDocumentsProperties(Models.Propr row)
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
				Model = Models.Propr.Find(Navigation.GetStrValue("propr"), m_userContext, "FPROPR00");
				if (Model == null)
				{
					Model = new Models.Propr(m_userContext) { Identifier = "FPROPR00" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("propr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Propr00_tpprotppropri(qs, lazyLoad);
			Load_Propr00_pessoname____(qs, lazyLoad);
			Load_Propr01_cntrycountry_(qs, lazyLoad);
			Load_Propr01_regioregiao__(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PROPR00]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PROPR00]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.REAL_ESTATE24996, ValName, 85);
			validator.StringLength("ValLocalida", Resources.Resources.LOCALIZATION34148, ValLocalida, 50);
			validator.StringLength("ValPostalco", Resources.Resources.ZIPCODE21021, ValPostalco, 20);
			validator.StringLength("ValPostallo", Resources.Resources.ZIPCODE21021, ValPostallo, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE PROPR00]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PROPR00]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PROPR00]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PROPR00]/
		public override void Destroy(string id)
		{
			Model = Models.Propr.Find(id, m_userContext, "FPROPR00");
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
		/// TableTpproTppropri -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Propr00_tpprotppropri(NameValueCollection qs, bool lazyLoad = false)
		{
			bool propr00_tpprotppropriDoLoad = true;
			CriteriaSet propr00_tpprotppropriConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tppro", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					propr00_tpprotppropriConds.Equal(CSGenioAtppro.FldCodtppro, hValue);
					this.ValCodtppro = DBConversion.ToString(hValue);
				}
			}

			TableTpproTppropri = new TableDBEdit<Models.Tppro>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
					this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}
				FillDependant_Propr00TableTpproTppropri(lazyLoad);
				return;
			}

			if (propr00_tpprotppropriDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableTpproTppropri, "sTableTpproTppropri", "dTableTpproTppropri", qs, "tppro");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtppro.FldTppropri), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpproTppropri_tableFilters"]))
					TableTpproTppropri.TableFilters = bool.Parse(qs["TableTpproTppropri_tableFilters"]);
				else
					TableTpproTppropri.TableFilters = false;

				query = qs["qTableTpproTppropri"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtppro.FldTppropri, query + "%");
				}
				propr00_tpprotppropriConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpproTppropri"] != null ? qs["pTableTpproTppropri"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri, CSGenioAtppro.FldZzstate];

// USE /[MANUAL GQT OVERRQ PROPR00_TPPROTPPROPRI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tppro", FormMode.New) || Navigation.checkFormMode("tppro", FormMode.Duplicate))
					propr00_tpprotppropriConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtppro.FldZzstate, 0)
						.Equal(CSGenioAtppro.FldCodtppro, Navigation.GetStrValue("tppro")));
				else
					propr00_tpprotppropriConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtppro.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tppro", "tppropri");
				ListingMVC<CSGenioAtppro> listing = Models.ModelBase.Where<CSGenioAtppro>(m_userContext, false, propr00_tpprotppropriConds, fields, offset, numberItems, sorts, "LED_PROPR00_TPPROTPPROPRI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpproTppropri.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpproTppropri.Query = query;
				TableTpproTppropri.Elements = listing.RowsForViewModel<GenioMVC.Models.Tppro>((r) => new GenioMVC.Models.Tppro(m_userContext, r, true, _fieldsToSerialize_PROPR00_TPPROTPPROPRI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tppro") != null)
				{
					this.ValCodtppro = Navigation.GetStrValue("RETURN_tppro");
					Navigation.CurrentLevel.SetEntry("RETURN_tppro", null);
				}

				TableTpproTppropri.List = new SelectList(TableTpproTppropri.Elements.ToSelectList(x => x.ValTppropri, x => x.ValCodtppro,  x => x.ValCodtppro == this.ValCodtppro), "Value", "Text", this.ValCodtppro);
				FillDependant_Propr00TableTpproTppropri();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpproTppropri (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tppro</param>
		public ConcurrentDictionary<string, object> GetDependant_Propr00TableTpproTppropri(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtppro.FldCodtppro, CSGenioAtppro.FldTppropri];

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

			CSGenioAtppro tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtppro.FldCodtppro, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpproTppropri (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Propr00TableTpproTppropri(bool lazyLoad = false)
		{
			var row = GetDependant_Propr00TableTpproTppropri(this.ValCodtppro);
			try
			{

				// Fill List fields
				this.ValCodtppro = ViewModelConversion.ToString(row["tppro.codtppro"]);
				TableTpproTppropri.Value = (string)row["tppro.tppropri"];
				if (GenFunctions.emptyG(this.ValCodtppro) == 1)
				{
					this.ValCodtppro = "";
					TableTpproTppropri.Value = "";
					Navigation.ClearValue("tppro");
				}
				else if (lazyLoad)
				{
					TableTpproTppropri.SetPagination(1, 0, false, false, 1);
					TableTpproTppropri.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtppro),
							Text = Convert.ToString(TableTpproTppropri.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtppro);
				}

				TableTpproTppropri.Selected = this.ValCodtppro;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpproTppropri): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPR00_TPPROTPPROPRI = ["Tppro", "Tppro.ValCodtppro", "Tppro.ValZzstate", "Tppro.ValTppropri"];

		/// <summary>
		/// TablePessoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Propr00_pessoname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool propr00_pessoname____DoLoad = true;
			CriteriaSet propr00_pessoname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pesso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					propr00_pessoname____Conds.Equal(CSGenioApesso.FldCodpesso, hValue);
					this.ValCodpesso = DBConversion.ToString(hValue);
				}
			}

			TablePessoName = new TableDBEdit<Models.Pesso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}
				FillDependant_Propr00TablePessoName(lazyLoad);
				return;
			}

			if (propr00_pessoname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePessoName, "sTablePessoName", "dTablePessoName", qs, "pesso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApesso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePessoName_tableFilters"]))
					TablePessoName.TableFilters = bool.Parse(qs["TablePessoName_tableFilters"]);
				else
					TablePessoName.TableFilters = false;

				query = qs["qTablePessoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApesso.FldName, query + "%");
				}
				propr00_pessoname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePessoName"] != null ? qs["pTablePessoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioApesso.FldZzstate];

// USE /[MANUAL GQT OVERRQ PROPR00_PESSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pesso", FormMode.New) || Navigation.checkFormMode("pesso", FormMode.Duplicate))
					propr00_pessoname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApesso.FldZzstate, 0)
						.Equal(CSGenioApesso.FldCodpesso, Navigation.GetStrValue("pesso")));
				else
					propr00_pessoname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApesso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pesso", "name");
				ListingMVC<CSGenioApesso> listing = Models.ModelBase.Where<CSGenioApesso>(m_userContext, false, propr00_pessoname____Conds, fields, offset, numberItems, sorts, "LED_PROPR00_PESSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePessoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePessoName.Query = query;
				TablePessoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Pesso>((r) => new GenioMVC.Models.Pesso(m_userContext, r, true, _fieldsToSerialize_PROPR00_PESSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pesso") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pesso");
					Navigation.CurrentLevel.SetEntry("RETURN_pesso", null);
				}

				TablePessoName.List = new SelectList(TablePessoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_Propr00TablePessoName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pesso</param>
		public ConcurrentDictionary<string, object> GetDependant_Propr00TablePessoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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

			CSGenioApesso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApesso.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePessoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Propr00TablePessoName(bool lazyLoad = false)
		{
			var row = GetDependant_Propr00TablePessoName(this.ValCodpesso);
			try
			{
				this.ValCodcntry = (string)row["cntry.codcntry"];

				// Fill List fields
				this.ValCodpesso = ViewModelConversion.ToString(row["pesso.codpesso"]);
				TablePessoName.Value = (string)row["pesso.name"];
				if (GenFunctions.emptyG(this.ValCodpesso) == 1)
				{
					this.ValCodpesso = "";
					TablePessoName.Value = "";
					Navigation.ClearValue("pesso");
				}
				else if (lazyLoad)
				{
					TablePessoName.SetPagination(1, 0, false, false, 1);
					TablePessoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpesso),
							Text = Convert.ToString(TablePessoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpesso);
				}

				TablePessoName.Selected = this.ValCodpesso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePessoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPR00_PESSONAME____ = ["Pesso", "Pesso.ValCodpesso", "Pesso.ValZzstate", "Pesso.ValName"];

		/// <summary>
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Propr01_cntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool propr01_cntrycountry_DoLoad = true;
			CriteriaSet propr01_cntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					propr01_cntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, hValue);
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
				FillDependant_Propr01TableCntryCountry(lazyLoad);
				return;
			}

			if (propr01_cntrycountry_DoLoad)
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
				propr01_cntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate];

// USE /[MANUAL GQT OVERRQ PROPR01_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					propr01_cntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					propr01_cntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, propr01_cntrycountry_Conds, fields, offset, numberItems, sorts, "LED_PROPR01_CNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_PROPR01_CNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_Propr01TableCntryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_Propr01TableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

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
		public void FillDependant_Propr01TableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_Propr01TableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GenFunctions.emptyG(this.ValCodcntry) == 1)
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

		private readonly string[] _fieldsToSerialize_PROPR01_CNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		/// <summary>
		/// TableRegioRegiao -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Propr01_regioregiao__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool propr01_regioregiao__DoLoad = true;
			CriteriaSet propr01_regioregiao__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("regio", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					propr01_regioregiao__Conds.Equal(CSGenioAregio.FldCodregia, hValue);
					this.ValCodregia = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			propr01_regioregiao__DoLoad &= AddCriteriaAreaLimit(propr01_regioregiao__Conds, CSGenio.business.CSGenioAcntry.FldCodcntry, "cntry", this.ValCodcntry, true);

			TableRegioRegiao = new TableDBEdit<Models.Regio>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}
				FillDependant_Propr01TableRegioRegiao(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodcntry))
				propr01_regioregiao__DoLoad = false;

			if (propr01_regioregiao__DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableRegioRegiao, "sTableRegioRegiao", "dTableRegioRegiao", qs, "regio");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAregio.FldRegiao), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRegioRegiao_tableFilters"]))
					TableRegioRegiao.TableFilters = bool.Parse(qs["TableRegioRegiao_tableFilters"]);
				else
					TableRegioRegiao.TableFilters = false;

				query = qs["qTableRegioRegiao"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAregio.FldRegiao, query + "%");
				}
				propr01_regioregiao__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRegioRegiao"] != null ? qs["pTableRegioRegiao"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao, CSGenioAregio.FldZzstate];

// USE /[MANUAL GQT OVERRQ PROPR01_REGIOREGIAO]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("regio", FormMode.New) || Navigation.checkFormMode("regio", FormMode.Duplicate))
					propr01_regioregiao__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAregio.FldZzstate, 0)
						.Equal(CSGenioAregio.FldCodregia, Navigation.GetStrValue("regio")));
				else
					propr01_regioregiao__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAregio.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("regio", "regiao");
				ListingMVC<CSGenioAregio> listing = Models.ModelBase.Where<CSGenioAregio>(m_userContext, false, propr01_regioregiao__Conds, fields, offset, numberItems, sorts, "LED_PROPR01_REGIOREGIAO__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRegioRegiao.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRegioRegiao.Query = query;
				TableRegioRegiao.Elements = listing.RowsForViewModel<GenioMVC.Models.Regio>((r) => new GenioMVC.Models.Regio(m_userContext, r, true, _fieldsToSerialize_PROPR01_REGIOREGIAO__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_regio") != null)
				{
					this.ValCodregia = Navigation.GetStrValue("RETURN_regio");
					Navigation.CurrentLevel.SetEntry("RETURN_regio", null);
				}

				TableRegioRegiao.List = new SelectList(TableRegioRegiao.Elements.ToSelectList(x => x.ValRegiao, x => x.ValCodregia,  x => x.ValCodregia == this.ValCodregia), "Value", "Text", this.ValCodregia);
				FillDependant_Propr01TableRegioRegiao();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Regio</param>
		public ConcurrentDictionary<string, object> GetDependant_Propr01TableRegioRegiao(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAregio.FldCodregia, CSGenioAregio.FldRegiao];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cntry");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAregio.FldCodcntry, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAregio tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAregio.FldCodregia, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRegioRegiao (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_Propr01TableRegioRegiao(bool lazyLoad = false)
		{
			var row = GetDependant_Propr01TableRegioRegiao(this.ValCodregia);
			try
			{

				// Fill List fields
				this.ValCodregia = ViewModelConversion.ToString(row["regio.codregia"]);
				TableRegioRegiao.Value = (string)row["regio.regiao"];
				if (GenFunctions.emptyG(this.ValCodregia) == 1)
				{
					this.ValCodregia = "";
					TableRegioRegiao.Value = "";
					Navigation.ClearValue("regio");
				}
				else if (lazyLoad)
				{
					TableRegioRegiao.SetPagination(1, 0, false, false, 1);
					TableRegioRegiao.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodregia),
							Text = Convert.ToString(TableRegioRegiao.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodregia);
				}

				TableRegioRegiao.Selected = this.ValCodregia;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRegioRegiao): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_PROPR01_REGIOREGIAO__ = ["Regio", "Regio.ValCodregia", "Regio.ValZzstate", "Regio.ValRegiao"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"propr.codcntry" => ViewModelConversion.ToString(modelValue),
				"propr.codpais1" => ViewModelConversion.ToString(modelValue),
				"propr.codpesso" => ViewModelConversion.ToString(modelValue),
				"propr.codregia" => ViewModelConversion.ToString(modelValue),
				"propr.codtppro" => ViewModelConversion.ToString(modelValue),
				"propr.name" => ViewModelConversion.ToString(modelValue),
				"propr.precoest" => ViewModelConversion.ToNumeric(modelValue),
				"propr.mobilada" => ViewModelConversion.ToLogic(modelValue),
				"propr.photogra" => ViewModelConversion.ToImage(modelValue),
				"propr.qtd_wc" => ViewModelConversion.ToNumeric(modelValue),
				"propr.qtdquart" => ViewModelConversion.ToNumeric(modelValue),
				"propr.m2" => ViewModelConversion.ToNumeric(modelValue),
				"propr.dtdispon" => ViewModelConversion.ToDateTime(modelValue),
				"propr.endereco" => ViewModelConversion.ToString(modelValue),
				"propr.localida" => ViewModelConversion.ToString(modelValue),
				"propr.postalco" => ViewModelConversion.ToString(modelValue),
				"propr.postallo" => ViewModelConversion.ToString(modelValue),
				"propr.coordgeo" => ViewModelConversion.ToString(modelValue),
				"propr.descript" => ViewModelConversion.ToString(modelValue),
				"propr.codpropr" => ViewModelConversion.ToString(modelValue),
				"tppro.codtppro" => ViewModelConversion.ToString(modelValue),
				"tppro.tppropri" => ViewModelConversion.ToString(modelValue),
				"pesso.codpesso" => ViewModelConversion.ToString(modelValue),
				"pesso.name" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"regio.codregia" => ViewModelConversion.ToString(modelValue),
				"regio.regiao" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValDescript = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValDescript, true);
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhotogra != null)
				ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPR, CSGenioApropr.FldPhotogra.Field, null, ValCodpropr);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM PROPR00]/

		#endregion
	}
}
