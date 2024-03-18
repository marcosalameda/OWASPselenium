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

namespace GenioMVC.ViewModels.Messa
{
	public class Messa_ViewModel : FormViewModel<Models.Messa>
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>
		/// Title: "Notification ID" | Type: "C"
		/// </summary>
		public string ValIdnotif { get; set; }

		/// <summary>
		/// Title: "Message ID" | Type: "C"
		/// </summary>
		public string ValIdmsg { get; set; }

		/// <summary>
		/// Title: "E-mail sent" | Type: "L"
		/// </summary>
		public bool ValMailsent { get; set; }

		/// <summary>
		/// Title: "Error sending mail" | Type: "C"
		/// </summary>
		public string ValMailerr { get; set; }

		/// <summary>
		/// Title: "Entity name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Entit> TableEntitName { get; set; }

		/// <summary>
		/// Title: "Person name" | Type: "C"
		/// </summary>
		public TableDBEdit<GenioMVC.Models.Perso> TablePersoName { get; set; }

		/// <summary>
		/// Title: "Document number" | Type: "N"
		/// </summary>
		public decimal? ValDocum_nr { get; set; }

		/// <summary>
		/// Title: "To whom the message was sent" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }

		/// <summary>
		/// Title: "E-mail to whom the message was sent" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }

		/// <summary>
		/// Title: "Message" | Type: "MO"
		/// </summary>
		public string ValMessage { get; set; }

		/// <summary>
		/// Title: "Created by" | Type: "ON"
		/// </summary>
		public string ValCreatope { get; set; }

		/// <summary>
		/// Title: "Created on" | Type: "OD"
		/// </summary>
		public DateTime? ValCreatdat { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Additional foreign keys


		/// <summary>
		/// Title: "Entity name" | Type: "CE"
		/// </summary>
		public string ValCodentit { get; set; }

		/// <summary>
		/// Title: "Person name" | Type: "CE"
		/// </summary>
		public string ValCodperso { get; set; }
		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodmessa { get; set; }

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be made manually after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Messa_ViewModel() : base(null!) { }

		public Messa_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FMESSA", nestedForm) { }

		public Messa_ViewModel(UserContext userContext, Models.Messa row, bool nestedForm = false) : base(userContext, "FMESSA", row, nestedForm) { }

		public Messa_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("messa", id);
			Model = Models.Messa.Find(id, userContext, "FMESSA", fieldsToQuery: fieldsToLoad);
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
			Models.Messa model = new Models.Messa(userContext) { Identifier = "FMESSA" };
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
			Models.Messa model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Messa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Messa) to ViewModel (Messa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValIdnotif = ViewModelConversion.ToString(m.ValIdnotif);
				ValIdmsg = ViewModelConversion.ToString(m.ValIdmsg);
				ValMailsent = ViewModelConversion.ToLogic(m.ValMailsent);
				ValMailerr = ViewModelConversion.ToString(m.ValMailerr);
				ValDocum_nr = ViewModelConversion.ToNumeric(m.ValDocum_nr);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValMessage = ViewModelConversion.ToString(m.ValMessage);
				ValCreatope = ViewModelConversion.ToString(m.ValCreatope);
				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
				ValCodentit = ViewModelConversion.ToString(m.ValCodentit);
				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
				ValCodmessa = ViewModelConversion.ToString(m.ValCodmessa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Messa) to ViewModel (Messa) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Messa m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Messa) to Model (Messa) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValIdnotif = ViewModelConversion.ToString(ValIdnotif);
				m.ValIdmsg = ViewModelConversion.ToString(ValIdmsg);
				m.ValMailsent = ViewModelConversion.ToLogic(ValMailsent);
				m.ValMailerr = ViewModelConversion.ToString(ValMailerr);
				m.ValDocum_nr = ViewModelConversion.ToNumeric(ValDocum_nr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValMessage = ViewModelConversion.ToString(ValMessage);
				m.ValCreatope = ViewModelConversion.ToString(ValCreatope);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValCodentit = ViewModelConversion.ToString(ValCodentit);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
				m.ValCodmessa = ViewModelConversion.ToString(ValCodmessa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Messa) to Model (Messa) - Error during mapping");
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
				Model = Models.Messa.Find(Navigation.GetStrValue("messa"), m_userContext, "FMESSA");
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

			Model.Identifier = "FMESSA";
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

		protected override void LoadDocumentsProperties(Models.Messa row)
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
				Model = Models.Messa.Find(Navigation.GetStrValue("messa"), m_userContext, "FMESSA");
				if (Model == null)
				{
					Model = new Models.Messa(m_userContext) { Identifier = "FMESSA" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("messa");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Messa___entitname____(qs, lazyLoad);
			Load_Messa___personame____(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL MESSA]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW MESSA]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);


			validator.StringLength("ValIdnotif", Resources.Resources.NOTIFICATION_ID25507, ValIdnotif, 50);
			validator.StringLength("ValIdmsg", Resources.Resources.MESSAGE_ID37133, ValIdmsg, 50);
			validator.StringLength("ValMailerr", Resources.Resources.ERROR_SENDING_MAIL44674, ValMailerr, 300);
			validator.StringLength("ValDesignat", Resources.Resources.TO_WHOM_THE_MESSAGE_02337, ValDesignat, 50);
			validator.StringLength("ValEmail", Resources.Resources.E_MAIL_TO_WHOM_THE_M37668, ValEmail, 254);

			return validator.GetResult();
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE MESSA]/
		public override void Save()
		{

			try { Model = Models.Messa.Find(Navigation.GetStrValue("messa"), m_userContext, "FMESSA"); }
			finally { if (Model == null) Model = new Models.Messa(m_userContext) { Identifier = "FMESSA" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY MESSA]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Messa.Find(Navigation.GetStrValue("messa"), m_userContext, "FMESSA"); }
			finally { if (Model == null) Model = new Models.Messa(m_userContext) { Identifier = "FMESSA" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE MESSA]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY MESSA]/
		public override void Destroy(string id)
		{
			Model = Models.Messa.Find(id, m_userContext, "FMESSA");
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
		/// TableEntitName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Messa___entitname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool messa___entitname____DoLoad = true;
			CriteriaSet messa___entitname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("entit", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					messa___entitname____Conds.Equal(CSGenioAentit.FldCodentit, Navigation.GetValue("entit"));
					this.ValCodentit = Navigation.GetStrValue("entit");
				}
			}

			TableEntitName = new TableDBEdit<Models.Entit>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}
				FillDependant_MessaTableEntitName(lazyLoad);
				//Check if foreignkey comes from history
				TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
				return;
			}

			if (messa___entitname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableEntitName, "sTableEntitName", "dTableEntitName", qs, "entit");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAentit.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableEntitName_tableFilters"]))
					TableEntitName.TableFilters = bool.Parse(qs["TableEntitName_tableFilters"]);
				else
					TableEntitName.TableFilters = false;

				query = qs["qTableEntitName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAentit.FldName, query + "%");
				}
				messa___entitname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableEntitName"] != null ? qs["pTableEntitName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAentit.FldCodentit, CSGenioAentit.FldName, CSGenioAentit.FldInitials, CSGenioAentit.FldZzstate };

// USE /[MANUAL GQT OVERRQ MESSA_ENTITNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("entit", FormMode.New) || Navigation.checkFormMode("entit", FormMode.Duplicate))
					messa___entitname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAentit.FldZzstate, 0)
						.Equal(CSGenioAentit.FldCodentit, Navigation.GetStrValue("entit")));
				else
					messa___entitname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAentit.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("entit", "name");
				ListingMVC<CSGenioAentit> listing = Models.ModelBase.Where<CSGenioAentit>(m_userContext, false, messa___entitname____Conds, fields, offset, numberItems, sorts, "LED_MESSA___ENTITNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableEntitName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableEntitName.Query = query;
				TableEntitName.Elements = listing.RowsForViewModel<GenioMVC.Models.Entit>((r) => new GenioMVC.Models.Entit(m_userContext, r, true, _fieldsToSerialize_MESSA___ENTITNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_entit") != null)
				{
					this.ValCodentit = Navigation.GetStrValue("RETURN_entit");
					Navigation.CurrentLevel.SetEntry("RETURN_entit", null);
				}

				TableEntitName.List = new SelectList(TableEntitName.Elements.ToSelectList(x => x.ValName, x => x.ValCodentit,  x => x.ValCodentit == this.ValCodentit), "Value", "Text", this.ValCodentit);
				FillDependant_MessaTableEntitName();

				//Check if foreignkey comes from history
				TableEntitName.FilledByHistory = Navigation.CheckFilledByHistory("entit");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Entit</param>
		public ConcurrentDictionary<string, object> GetDependant_MessaTableEntitName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAentit.FldCodentit, CSGenioAentit.FldName];

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

			CSGenioAentit tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAentit.FldCodentit, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableEntitName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_MessaTableEntitName(bool lazyLoad = false)
		{
			var row = GetDependant_MessaTableEntitName(this.ValCodentit);
			try
			{

				// Fill List fields
				this.ValCodentit = ViewModelConversion.ToString(row["entit.codentit"]);
				TableEntitName.Value = (string)row["entit.name"];
				if (GlobalFunctions.emptyG(this.ValCodentit) == 1)
				{
					this.ValCodentit = "";
					TableEntitName.Value = "";
					Navigation.ClearValue("entit");
				}
				else if (lazyLoad)
				{
					TableEntitName.SetPagination(1, 0, false, false, 1);
					TableEntitName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodentit),
							Text = Convert.ToString(TableEntitName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodentit);
				}

				TableEntitName.Selected = this.ValCodentit;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableEntitName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_MESSA___ENTITNAME____ = ["Entit", "Entit.ValCodentit", "Entit.ValZzstate", "Entit.ValName", "Entit.ValInitials"];

		/// <summary>
		/// TablePersoName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Messa___personame____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool messa___personame____DoLoad = true;
			CriteriaSet messa___personame____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("perso", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					messa___personame____Conds.Equal(CSGenioAperso.FldCodperso, Navigation.GetValue("perso"));
					this.ValCodperso = Navigation.GetStrValue("perso");
				}
			}

			TablePersoName = new TableDBEdit<Models.Perso>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}
				FillDependant_MessaTablePersoName(lazyLoad);
				//Check if foreignkey comes from history
				TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
				return;
			}

			if (messa___personame____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePersoName, "sTablePersoName", "dTablePersoName", qs, "perso");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAperso.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePersoName_tableFilters"]))
					TablePersoName.TableFilters = bool.Parse(qs["TablePersoName_tableFilters"]);
				else
					TablePersoName.TableFilters = false;

				query = qs["qTablePersoName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAperso.FldName, query + "%");
				}
				messa___personame____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePersoName"] != null ? qs["pTablePersoName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAperso.FldCodperso, CSGenioAperso.FldName, CSGenioAperso.FldZzstate };

// USE /[MANUAL GQT OVERRQ MESSA_PERSONAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("perso", FormMode.New) || Navigation.checkFormMode("perso", FormMode.Duplicate))
					messa___personame____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAperso.FldZzstate, 0)
						.Equal(CSGenioAperso.FldCodperso, Navigation.GetStrValue("perso")));
				else
					messa___personame____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAperso.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("perso", "name");
				ListingMVC<CSGenioAperso> listing = Models.ModelBase.Where<CSGenioAperso>(m_userContext, false, messa___personame____Conds, fields, offset, numberItems, sorts, "LED_MESSA___PERSONAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePersoName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePersoName.Query = query;
				TablePersoName.Elements = listing.RowsForViewModel<GenioMVC.Models.Perso>((r) => new GenioMVC.Models.Perso(m_userContext, r, true, _fieldsToSerialize_MESSA___PERSONAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_perso") != null)
				{
					this.ValCodperso = Navigation.GetStrValue("RETURN_perso");
					Navigation.CurrentLevel.SetEntry("RETURN_perso", null);
				}

				TablePersoName.List = new SelectList(TablePersoName.Elements.ToSelectList(x => x.ValName, x => x.ValCodperso,  x => x.ValCodperso == this.ValCodperso), "Value", "Text", this.ValCodperso);
				FillDependant_MessaTablePersoName();

				//Check if foreignkey comes from history
				TablePersoName.FilledByHistory = Navigation.CheckFilledByHistory("perso");
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Perso</param>
		public ConcurrentDictionary<string, object> GetDependant_MessaTablePersoName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAperso.FldCodperso, CSGenioAperso.FldName];

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

			CSGenioAperso tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAperso.FldCodperso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePersoName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_MessaTablePersoName(bool lazyLoad = false)
		{
			var row = GetDependant_MessaTablePersoName(this.ValCodperso);
			try
			{

				// Fill List fields
				this.ValCodperso = ViewModelConversion.ToString(row["perso.codperso"]);
				TablePersoName.Value = (string)row["perso.name"];
				if (GlobalFunctions.emptyG(this.ValCodperso) == 1)
				{
					this.ValCodperso = "";
					TablePersoName.Value = "";
					Navigation.ClearValue("perso");
				}
				else if (lazyLoad)
				{
					TablePersoName.SetPagination(1, 0, false, false, 1);
					TablePersoName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodperso),
							Text = Convert.ToString(TablePersoName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodperso);
				}

				TablePersoName.Selected = this.ValCodperso;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePersoName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_MESSA___PERSONAME____ = ["Perso", "Perso.ValCodperso", "Perso.ValZzstate", "Perso.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"messa.idnotif" => ViewModelConversion.ToString(modelValue),
				"messa.idmsg" => ViewModelConversion.ToString(modelValue),
				"messa.mailsent" => ViewModelConversion.ToLogic(modelValue),
				"messa.mailerr" => ViewModelConversion.ToString(modelValue),
				"messa.docum_nr" => ViewModelConversion.ToNumeric(modelValue),
				"messa.designat" => ViewModelConversion.ToString(modelValue),
				"messa.email" => ViewModelConversion.ToString(modelValue),
				"messa.message" => ViewModelConversion.ToString(modelValue),
				"messa.creatope" => ViewModelConversion.ToString(modelValue),
				"messa.creatdat" => ViewModelConversion.ToDateTime(modelValue),
				"messa.codentit" => ViewModelConversion.ToString(modelValue),
				"messa.codperso" => ViewModelConversion.ToString(modelValue),
				"messa.codmessa" => ViewModelConversion.ToString(modelValue),
				"entit.codentit" => ViewModelConversion.ToString(modelValue),
				"entit.name" => ViewModelConversion.ToString(modelValue),
				"perso.codperso" => ViewModelConversion.ToString(modelValue),
				"perso.name" => ViewModelConversion.ToString(modelValue),
				_ => throw new Exception("Unexpected field identifier")
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM MESSA]/

		#endregion
	}
}
