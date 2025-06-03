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

namespace GenioMVC.ViewModels.Notif
{
	public class Notif_ViewModel : FormViewModel<Models.Notif>, IPreparableForSerialization
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
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValCodpesso { get; set; }

		#endregion
		/// <summary>
		/// Title: "Lending No" | Type: "N"
		/// </summary>
		public decimal? ValNrcomoda { get; set; }
		/// <summary>
		/// Title: "Start" | Type: "DT"
		/// </summary>
		public DateTime? ValBegin { get; set; }
		/// <summary>
		/// Title: "End" | Type: "DT"
		/// </summary>
		public DateTime? ValEnd { get; set; }
		/// <summary>
		/// Title: "Receiver's Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "ID of the notification that generated the message" | Type: "C"
		/// </summary>
		public string ValIdnotif { get; set; }
		/// <summary>
		/// Title: "Mensage ID" | Type: "C"
		/// </summary>
		public string ValIdmsg { get; set; }
		/// <summary>
		/// Title: "Text of sent message" | Type: "MO"
		/// </summary>
		public string ValMessage { get; set; }
		/// <summary>
		/// Title: "Erro on sending the email" | Type: "C"
		/// </summary>
		public string ValMailerr { get; set; }
		/// <summary>
		/// Title: "Receiver" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }
		/// <summary>
		/// Title: "Created on" | Type: "OD"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValCreatdat { get; set; }
		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		[ValidateSetAccess]
		public string ValCreatope { get; set; }
		/// <summary>
		/// Title: "Returned" | Type: "L"
		/// </summary>
		public bool ValReturned { get; set; }
		/// <summary>
		/// Title: "Returned" | Type: "D"
		/// </summary>
		public DateTime? ValDtdevolu { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess2> TablePess2Name { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodnotif { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Notif_ViewModel() : base(null!) { }

		public Notif_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FNOTIF", nestedForm) { }

		public Notif_ViewModel(UserContext userContext, Models.Notif row, bool nestedForm = false) : base(userContext, "FNOTIF", row, nestedForm) { }

		public Notif_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("notif", id);
			Model = Models.Notif.Find(id, userContext, "FNOTIF", fieldsToQuery: fieldsToLoad);
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
			Models.Notif model = new Models.Notif(userContext) { Identifier = "FNOTIF" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FNOTIF");
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
			Models.Notif model = Model;
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
		public override void MapFromModel(Models.Notif m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Notif) to ViewModel (Notif) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodpesso = ViewModelConversion.ToString(m.ValCodpesso);
				ValNrcomoda = ViewModelConversion.ToNumeric(m.ValNrcomoda);
				ValBegin = ViewModelConversion.ToDateTime(m.ValBegin);
				ValEnd = ViewModelConversion.ToDateTime(m.ValEnd);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValIdnotif = ViewModelConversion.ToString(m.ValIdnotif);
				ValIdmsg = ViewModelConversion.ToString(m.ValIdmsg);
				ValMessage = ViewModelConversion.ToString(m.ValMessage);
				ValMailerr = ViewModelConversion.ToString(m.ValMailerr);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValCreatope = ViewModelConversion.ToString(m.ValCreatope);
				ValReturned = ViewModelConversion.ToLogic(m.ValReturned);
				ValDtdevolu = ViewModelConversion.ToDateTime(m.ValDtdevolu);
				ValCodnotif = ViewModelConversion.ToString(m.ValCodnotif);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Notif) to ViewModel (Notif) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Notif m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Notif) to Model (Notif) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodpesso = ViewModelConversion.ToString(ValCodpesso);
				m.ValNrcomoda = ViewModelConversion.ToNumeric(ValNrcomoda);
				m.ValBegin = ViewModelConversion.ToDateTime(ValBegin);
				m.ValEnd = ViewModelConversion.ToDateTime(ValEnd);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValIdnotif = ViewModelConversion.ToString(ValIdnotif);
				m.ValIdmsg = ViewModelConversion.ToString(ValIdmsg);
				m.ValMessage = ViewModelConversion.ToString(ValMessage);
				m.ValMailerr = ViewModelConversion.ToString(ValMailerr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValReturned = ViewModelConversion.ToLogic(ValReturned);
				m.ValDtdevolu = ViewModelConversion.ToDateTime(ValDtdevolu);
				m.ValCodnotif = ViewModelConversion.ToString(ValCodnotif);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCreatope = ViewModelConversion.ToString(ValCreatope);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Notif) to Model (Notif) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "notif.codpesso":
						this.ValCodpesso = ViewModelConversion.ToString(_value);
						break;
					case "notif.nrcomoda":
						this.ValNrcomoda = ViewModelConversion.ToNumeric(_value);
						break;
					case "notif.begin":
						this.ValBegin = ViewModelConversion.ToDateTime(_value);
						break;
					case "notif.end":
						this.ValEnd = ViewModelConversion.ToDateTime(_value);
						break;
					case "notif.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "notif.idnotif":
						this.ValIdnotif = ViewModelConversion.ToString(_value);
						break;
					case "notif.idmsg":
						this.ValIdmsg = ViewModelConversion.ToString(_value);
						break;
					case "notif.message":
						this.ValMessage = ViewModelConversion.ToString(_value);
						break;
					case "notif.mailerr":
						this.ValMailerr = ViewModelConversion.ToString(_value);
						break;
					case "notif.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "notif.returned":
						this.ValReturned = ViewModelConversion.ToLogic(_value);
						break;
					case "notif.dtdevolu":
						this.ValDtdevolu = ViewModelConversion.ToDateTime(_value);
						break;
					case "notif.codnotif":
						this.ValCodnotif = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Notif) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Notif)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Notif.Find(id ?? Navigation.GetStrValue("notif"), m_userContext, "FNOTIF"); }
			finally { Model ??= new Models.Notif(m_userContext) { Identifier = "FNOTIF" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Notif.Find(Navigation.GetStrValue("notif"), m_userContext, "FNOTIF");
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

			Model.Identifier = "FNOTIF";
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

		protected override void LoadDocumentsProperties(Models.Notif row)
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
				Model = Models.Notif.Find(Navigation.GetStrValue("notif"), m_userContext, "FNOTIF");
				if (Model == null)
				{
					Model = new Models.Notif(m_userContext) { Identifier = "FNOTIF" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("notif");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Notif___pess2name____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL NOTIF]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW NOTIF]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.Required("ValBegin", Resources.Resources.START00919, ViewModelConversion.ToDateTime(ValBegin), FieldType.DATETIME.GetFormatting());
			validator.StringLength("ValEmail", Resources.Resources.RECEIVER_S_EMAIL60306, ValEmail, 100);
			validator.StringLength("ValIdnotif", Resources.Resources.ID_OF_THE_NOTIFICATI28920, ValIdnotif, 50);
			validator.StringLength("ValIdmsg", Resources.Resources.MENSAGE_ID32109, ValIdmsg, 85);
			validator.StringLength("ValMailerr", Resources.Resources.ERRO_ON_SENDING_THE_05516, ValMailerr, 300);
			validator.StringLength("ValDesignat", Resources.Resources.RECEIVER16744, ValDesignat, 85);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE NOTIF]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY NOTIF]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE NOTIF]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY NOTIF]/
		public override void Destroy(string id)
		{
			Model = Models.Notif.Find(id, m_userContext, "FNOTIF");
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
		/// TablePess2Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Notif___pess2name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool notif___pess2name____DoLoad = true;
			CriteriaSet notif___pess2name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess2", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					notif___pess2name____Conds.Equal(CSGenioApess2.FldCodpesso, hValue);
					this.ValCodpesso = DBConversion.ToString(hValue);
				}
			}

			TablePess2Name = new TableDBEdit<Models.Pess2>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}
				FillDependant_NotifTablePess2Name(lazyLoad);
				return;
			}

			if (notif___pess2name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePess2Name, "sTablePess2Name", "dTablePess2Name", qs, "pess2");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess2.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess2Name_tableFilters"]))
					TablePess2Name.TableFilters = bool.Parse(qs["TablePess2Name_tableFilters"]);
				else
					TablePess2Name.TableFilters = false;

				query = qs["qTablePess2Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess2.FldName, query + "%");
				}
				notif___pess2name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePess2Name"] != null ? qs["pTablePess2Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioApess2.FldCodpesso, CSGenioApess2.FldName, CSGenioApess2.FldZzstate };

// USE /[MANUAL GQT OVERRQ NOTIF_PESS2NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess2", FormMode.New) || Navigation.checkFormMode("pess2", FormMode.Duplicate))
					notif___pess2name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess2.FldZzstate, 0)
						.Equal(CSGenioApess2.FldCodpesso, Navigation.GetStrValue("pess2")));
				else
					notif___pess2name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess2.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess2", "name");
				ListingMVC<CSGenioApess2> listing = Models.ModelBase.Where<CSGenioApess2>(m_userContext, false, notif___pess2name____Conds, fields, offset, numberItems, sorts, "LED_NOTIF___PESS2NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess2Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess2Name.Query = query;
				TablePess2Name.Elements = listing.RowsForViewModel<GenioMVC.Models.Pess2>((r) => new GenioMVC.Models.Pess2(m_userContext, r, true, _fieldsToSerialize_NOTIF___PESS2NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess2") != null)
				{
					this.ValCodpesso = Navigation.GetStrValue("RETURN_pess2");
					Navigation.CurrentLevel.SetEntry("RETURN_pess2", null);
				}

				TablePess2Name.List = new SelectList(TablePess2Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpesso), "Value", "Text", this.ValCodpesso);
				FillDependant_NotifTablePess2Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess2Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess2</param>
		public ConcurrentDictionary<string, object> GetDependant_NotifTablePess2Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess2.FldCodpesso, CSGenioApess2.FldName];

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

			CSGenioApess2 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess2.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess2Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_NotifTablePess2Name(bool lazyLoad = false)
		{
			var row = GetDependant_NotifTablePess2Name(this.ValCodpesso);
			try
			{

				// Fill List fields
				this.ValCodpesso = ViewModelConversion.ToString(row["pess2.codpesso"]);
				TablePess2Name.Value = (string)row["pess2.name"];
				if (GenFunctions.emptyG(this.ValCodpesso) == 1)
				{
					this.ValCodpesso = "";
					TablePess2Name.Value = "";
					Navigation.ClearValue("pess2");
				}
				else if (lazyLoad)
				{
					TablePess2Name.SetPagination(1, 0, false, false, 1);
					TablePess2Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpesso),
							Text = Convert.ToString(TablePess2Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpesso);
				}

				TablePess2Name.Selected = this.ValCodpesso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess2Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_NOTIF___PESS2NAME____ = ["Pess2", "Pess2.ValCodpesso", "Pess2.ValZzstate", "Pess2.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"notif.codpesso" => ViewModelConversion.ToString(modelValue),
				"notif.nrcomoda" => ViewModelConversion.ToNumeric(modelValue),
				"notif.begin" => ViewModelConversion.ToDateTime(modelValue),
				"notif.end" => ViewModelConversion.ToDateTime(modelValue),
				"notif.email" => ViewModelConversion.ToString(modelValue),
				"notif.idnotif" => ViewModelConversion.ToString(modelValue),
				"notif.idmsg" => ViewModelConversion.ToString(modelValue),
				"notif.message" => ViewModelConversion.ToString(modelValue),
				"notif.mailerr" => ViewModelConversion.ToString(modelValue),
				"notif.designat" => ViewModelConversion.ToString(modelValue),
				"notif.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"notif.creatope" => ViewModelConversion.ToString(modelValue),
				"notif.returned" => ViewModelConversion.ToLogic(modelValue),
				"notif.dtdevolu" => ViewModelConversion.ToDateTime(modelValue),
				"notif.codnotif" => ViewModelConversion.ToString(modelValue),
				"pess2.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess2.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM NOTIF]/

		#endregion
	}
}
