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

namespace GenioMVC.ViewModels.Equip
{
	public class Equip_ViewModel : FormViewModel<Models.Equip>, IPreparableForSerialization
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
		/// Title: "Company:" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "Decomission No." | Type: "CE"
		/// </summary>
		public string ValCoddeco { get; set; }
		/// <summary>
		/// Title: "Item:" | Type: "CE"
		/// </summary>
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "Person" | Type: "CE"
		/// </summary>
		public string ValCodpess1 { get; set; }
		/// <summary>
		/// Title: "Room No:" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodrooms { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "CE"
		/// </summary>
		public string ValCodwareh { get; set; }

		#endregion

		/// <summary>
		/// Title: "Company:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cmpny> TableCmpnyDesignat { get; set; }
		/// <summary>
		/// Title: "Person" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess1> TablePess1Name { get; set; }
		/// <summary>
		/// Title: "Sequential No." | Type: "N"
		/// </summary>
		public decimal? ValSequennr { get; set; }
		/// <summary>
		/// Title: "Registration No." | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValRegistnr { get; set; }
		/// <summary>
		/// Title: "Type of equipment" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }
		/// <summary>
		/// Title: "Manufacturer's website:" | Type: "C"
		/// </summary>
		public string ValSitefabr { get; set; }
		/// <summary>
		/// Title: "Warehouse" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Wareh> TableWarehWarehdes { get; set; }
		/// <summary>
		/// Title: "Item:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Item> TableItemItemdes { get; set; }
		/// <summary>
		/// Title: "Designation:" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }
		/// <summary>
		/// Title: "Loan Frequency" | Type: "AN"
		/// </summary>
		public decimal ValFrequenc { get; set; }
		/// <summary>
		/// Title: "Total Value:" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValortot { get; set; }
		/// <summary>
		/// Title: "Acquisition:" | Type: "D"
		/// </summary>
		public DateTime? ValDtaquisi { get; set; }
		/// <summary>
		/// Title: "Decomission:" | Type: "D"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? ValDtdeco { get; set; }
		/// <summary>
		/// Title: "bought" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValBought { get; set; }
		/// <summary>
		/// Title: "Room No:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Room1> TableRoom1Roomnr { get; set; }
		/// <summary>
		/// Title: "Room Designation:" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string Room1ValDesignat
		{
			get
			{
				return funcRoom1ValDesignat != null ? funcRoom1ValDesignat() : _auxRoom1ValDesignat;
			}
			set { funcRoom1ValDesignat = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcRoom1ValDesignat { get; set; }

		private string _auxRoom1ValDesignat { get; set; }
		/// <summary>
		/// Title: "Reference" | Type: "DT"
		/// </summary>
		public DateTime? ValDtrefere { get; set; }
		/// <summary>
		/// Title: "First" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValFirst { get; set; }
		/// <summary>
		/// Title: "Before" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValBefore { get; set; }
		/// <summary>
		/// Title: "Following" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValFollowin { get; set; }
		/// <summary>
		/// Title: "last" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValLast { get; set; }
		/// <summary>
		/// Title: "Quantity of transactions" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValQtdmovim { get; set; }
		/// <summary>
		/// Title: "Movements" | Type: "MO"
		/// </summary>
		[ValidateSetAccess]
		public string ValMoviment { get; set; }
		/// <summary>
		/// Title: "Choose room" | Type: "PSEUD"
		/// </summary>
		[ValidateSetAccess]
		public List<GenioMVC.Models.Rooms> List_Movimevv { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public List<GenioMVC.Models.Rooms> List_MovimevvSelected { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string[] List_Movimevv_SelectedIds { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		public string List_Movimevv_Area { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhotogra { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel ValLastpho { get; set; }
		/// <summary>
		/// Title: "Decomission No." | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Decom> TableDecomDecomnr { get; set; }
		/// <summary>
		/// Title: "Downed equipment" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValIfabatif { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the TpequValTipoequi field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<string> funcTpequValTipoequi { get; set; }
		private string _auxTpequValTipoequi { get; set; }
		/// <summary>Field: "TYPE OF EQUIPMENT" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string TpequValTipoequi { get { return funcTpequValTipoequi != null ? funcTpequValTipoequi() : _auxTpequValTipoequi; } private set { funcTpequValTipoequi = () => value; } }
		// Field for formula
		/// <summary>Used only for lazy loading of the ItemValItemdes field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<string> funcItemValItemdes { get; set; }
		private string _auxItemValItemdes { get; set; }
		/// <summary>Field: "Article" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string ItemValItemdes { get { return funcItemValItemdes != null ? funcItemValItemdes() : _auxItemValItemdes; } private set { funcItemValItemdes = () => value; } }

		#endregion

		public string ValCodequip { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Equip_ViewModel() : base(null!) { }

		public Equip_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEQUIP", nestedForm) { }

		public Equip_ViewModel(UserContext userContext, Models.Equip row, bool nestedForm = false) : base(userContext, "FEQUIP", row, nestedForm) { }

		public Equip_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, userContext, "FEQUIP", fieldsToQuery: fieldsToLoad);
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
			Models.Equip model = new Models.Equip(userContext) { Identifier = "FEQUIP" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FEQUIP");
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
		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
				ValSitefabr = ViewModelConversion.ToString(m.ValSitefabr);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				ValFrequenc = ViewModelConversion.ToNumeric(m.ValFrequenc);
				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
				ValDtdeco = ViewModelConversion.ToDateTime(m.ValDtdeco);
				ValBought = ViewModelConversion.ToLogic(m.ValBought);
				funcRoom1ValDesignat = () => ViewModelConversion.ToString(m.Room1.ValDesignat);
				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
				ValFirst = ViewModelConversion.ToString(m.ValFirst);
				ValBefore = ViewModelConversion.ToString(m.ValBefore);
				ValFollowin = ViewModelConversion.ToString(m.ValFollowin);
				ValLast = ViewModelConversion.ToString(m.ValLast);
				ValQtdmovim = ViewModelConversion.ToNumeric(m.ValQtdmovim);
				ValMoviment = ViewModelConversion.ToString(m.ValMoviment);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValLastpho = ViewModelConversion.ToImage(m.ValLastpho);
				ValIfabatif = ViewModelConversion.ToLogic(m.ValIfabatif);
				funcTpequValTipoequi = () => ViewModelConversion.ToString(m.Tpequ.ValTipoequi);
				funcItemValItemdes = () => ViewModelConversion.ToString(m.Item.ValItemdes);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equip) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equip) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValSitefabr = ViewModelConversion.ToString(ValSitefabr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValFrequenc = ViewModelConversion.ToNumeric(ValFrequenc);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				if (ValPhotogra == null || !ValPhotogra.IsThumbnail)
					m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValDtdeco = ViewModelConversion.ToDateTime(ValDtdeco);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
				m.ValBefore = ViewModelConversion.ToString(ValBefore);
				m.ValFollowin = ViewModelConversion.ToString(ValFollowin);
				m.ValLast = ViewModelConversion.ToString(ValLast);
				m.ValQtdmovim = ViewModelConversion.ToNumeric(ValQtdmovim);
				m.ValMoviment = ViewModelConversion.ToString(ValMoviment);
				if (ValLastpho == null || !ValLastpho.IsThumbnail)
					m.ValLastpho = ViewModelConversion.ToImage(ValLastpho);
				m.ValIfabatif = ViewModelConversion.ToLogic(ValIfabatif);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Equip) to Model (Equip) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "equip.codempre":
						this.ValCodempre = ViewModelConversion.ToString(_value);
						break;
					case "equip.coddeco":
						this.ValCoddeco = ViewModelConversion.ToString(_value);
						break;
					case "equip.coditem":
						this.ValCoditem = ViewModelConversion.ToString(_value);
						break;
					case "equip.codpess1":
						this.ValCodpess1 = ViewModelConversion.ToString(_value);
						break;
					case "equip.codtpequ":
						this.ValCodtpequ = ViewModelConversion.ToString(_value);
						break;
					case "equip.codwareh":
						this.ValCodwareh = ViewModelConversion.ToString(_value);
						break;
					case "equip.sequennr":
						this.ValSequennr = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.sitefabr":
						this.ValSitefabr = ViewModelConversion.ToString(_value);
						break;
					case "equip.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "equip.frequenc":
						this.ValFrequenc = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.dtaquisi":
						this.ValDtaquisi = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.dtrefere":
						this.ValDtrefere = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.photogra":
						this.ValPhotogra = ViewModelConversion.ToImage(_value);
						break;
					case "equip.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Equip) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Equip)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Equip.Find(id ?? Navigation.GetStrValue("equip"), m_userContext, "FEQUIP"); }
			finally { Model ??= new Models.Equip(m_userContext) { Identifier = "FEQUIP" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FEQUIP");
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

			Model.Identifier = "FEQUIP";
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

		protected override void LoadDocumentsProperties(Models.Equip row)
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
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FEQUIP");
				if (Model == null)
				{
					Model = new Models.Equip(m_userContext) { Identifier = "FEQUIP" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Equip___cmpnydesignat(qs, lazyLoad);
			Load_Equip___pess1name____(qs, lazyLoad);
			Load_Equip___tpequtipoequi(qs, lazyLoad);
			Load_Equip___warehwarehdes(qs, lazyLoad);
			Load_Equip___item_itemdes_(qs, lazyLoad);
			Load_Equip___room1roomnr__(qs, lazyLoad);
			Load_Equip___decomdecomnr_(qs, lazyLoad);

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIP]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIP]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValRegistnr", Resources.Resources.REGISTRATION_NO_06209, ValRegistnr, 6);
			validator.StringLength("ValSitefabr", Resources.Resources.MANUFACTURER_S_WEBSI12156, ValSitefabr, 256);
			validator.Hyperlink(Resources.Resources.MANUFACTURER_S_WEBSI12156, ValSitefabr);
			validator.StringLength("ValDesignat", Resources.Resources.DESIGNATION_35800, ValDesignat, 85);
			validator.StringLength("Room1ValDesignat", Resources.Resources.ROOM_DESIGNATION_33759, Room1ValDesignat, 50);
			validator.StringLength("ValFirst", Resources.Resources.FIRST42972, ValFirst, 10);
			validator.StringLength("ValBefore", Resources.Resources.BEFORE60156, ValBefore, 10);
			validator.StringLength("ValFollowin", Resources.Resources.FOLLOWING22170, ValFollowin, 10);
			validator.StringLength("ValLast", Resources.Resources.LAST48120, ValLast, 10);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIP]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIP]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIP]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIP]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, m_userContext, "FEQUIP");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
			Load_Equip___pseudmovimevv_selected_ids();
		}

		/// <summary>
		/// TableCmpnyDesignat -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___cmpnydesignat(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___cmpnydesignatDoLoad = true;
			CriteriaSet equip___cmpnydesignatConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cmpny", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___cmpnydesignatConds.Equal(CSGenioAcmpny.FldCodempre, hValue);
					this.ValCodempre = DBConversion.ToString(hValue);
				}
			}

			TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}
				FillDependant_EquipTableCmpnyDesignat(lazyLoad);
				return;
			}

			if (equip___cmpnydesignatDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcmpny.FldDesignat), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
					TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
				else
					TableCmpnyDesignat.TableFilters = false;

				query = qs["qTableCmpnyDesignat"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
				}
				equip___cmpnydesignatConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"] != null ? qs["pTableCmpnyDesignat"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_CMPNYDESIGNAT]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cmpny", FormMode.New) || Navigation.checkFormMode("cmpny", FormMode.Duplicate))
					equip___cmpnydesignatConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcmpny.FldZzstate, 0)
						.Equal(CSGenioAcmpny.FldCodempre, Navigation.GetStrValue("cmpny")));
				else
					equip___cmpnydesignatConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cmpny", "designat");
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, equip___cmpnydesignatConds, fields, offset, numberItems, sorts, "LED_EQUIP___CMPNYDESIGNAT", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_EQUIP___CMPNYDESIGNAT));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cmpny") != null)
				{
					this.ValCodempre = Navigation.GetStrValue("RETURN_cmpny");
					Navigation.CurrentLevel.SetEntry("RETURN_cmpny", null);
				}

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == this.ValCodempre), "Value", "Text", this.ValCodempre);
				FillDependant_EquipTableCmpnyDesignat();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableCmpnyDesignat(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];

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

			CSGenioAcmpny tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcmpny.FldCodempre, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCmpnyDesignat (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTableCmpnyDesignat(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableCmpnyDesignat(this.ValCodempre);
			try
			{

				// Fill List fields
				this.ValCodempre = ViewModelConversion.ToString(row["cmpny.codempre"]);
				TableCmpnyDesignat.Value = (string)row["cmpny.designat"];
				if (GenFunctions.emptyG(this.ValCodempre) == 1)
				{
					this.ValCodempre = "";
					TableCmpnyDesignat.Value = "";
					Navigation.ClearValue("cmpny");
				}
				else if (lazyLoad)
				{
					TableCmpnyDesignat.SetPagination(1, 0, false, false, 1);
					TableCmpnyDesignat.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodempre),
							Text = Convert.ToString(TableCmpnyDesignat.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodempre);
				}

				TableCmpnyDesignat.Selected = this.ValCodempre;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCmpnyDesignat): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP___CMPNYDESIGNAT = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate", "Cmpny.ValDesignat"];

		/// <summary>
		/// TablePess1Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___pess1name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___pess1name____DoLoad = true;
			CriteriaSet equip___pess1name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___pess1name____Conds.Equal(CSGenioApess1.FldCodpesso, hValue);
					this.ValCodpess1 = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			equip___pess1name____DoLoad &= AddCriteriaAreaLimit(equip___pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

			TablePess1Name = new TableDBEdit<Models.Pess1>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
				FillDependant_EquipTablePess1Name(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodempre))
				equip___pess1name____DoLoad = false;

			if (equip___pess1name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
					TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
				else
					TablePess1Name.TableFilters = false;

				query = qs["qTablePess1Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess1.FldName, query + "%");
				}
				equip___pess1name____Conds.SubSet(search_filters);

				// Last updated by [CJP] at [2016.12.07]
				// Os filtros definidos no Qfield DBEdit passam a ser filtros fracos, to não limparem o Qvalue escolhido.
				// Os filtros podem ser alterados no "ver mais", mas não são obrigatórios.

				string selectedValue = qs["pess1"] ?? this.ValCodpess1;
				CriteriaSet weakFilters = CriteriaSet.Or();
				if (!string.IsNullOrEmpty(selectedValue))
					weakFilters.Equal(CSGenioApess1.FldCodpesso, selectedValue);

				CriteriaSet subfilters = CriteriaSet.And();
				weakFilters.SubSets.Add(subfilters);
				equip___pess1name____Conds.SubSets.Add(weakFilters);

				string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_PESS1NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
					equip___pess1name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess1.FldZzstate, 0)
						.Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
				else
					equip___pess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, false, equip___pess1name____Conds, fields, offset, numberItems, sorts, "LED_EQUIP___PESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess1Name.Query = query;
				TablePess1Name.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Pess1(m_userContext, r, true, _fieldsToSerialize_EQUIP___PESS1NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
				//Seleciona se só um
				if (TablePess1Name.List != null && TablePess1Name.List.Count() == 1)
				{
					this.ValCodpess1 = TablePess1Name.List.First().Value;
					Navigation.SetValue("pess1", this.ValCodpess1);
				}
				FillDependant_EquipTablePess1Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess1</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTablePess1Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cmpny");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApess1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTablePess1Name(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTablePess1Name(this.ValCodpess1);
			try
			{

				// Fill List fields
				this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
				TablePess1Name.Value = (string)row["pess1.name"];
				if (GenFunctions.emptyG(this.ValCodpess1) == 1)
				{
					this.ValCodpess1 = "";
					TablePess1Name.Value = "";
					Navigation.ClearValue("pess1");
				}
				else if (lazyLoad)
				{
					TablePess1Name.SetPagination(1, 0, false, false, 1);
					TablePess1Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpess1),
							Text = Convert.ToString(TablePess1Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpess1);
				}

				TablePess1Name.Selected = this.ValCodpess1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		public List<TreeNode> Tree_TablePess1Name { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TablePess1Name
		/// </summary>
		public void LoadTree_TablePess1Name(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioApess1.FldCodpesso, CSGenioApess1.FldZzstate, CSGenioApess1.FldName };
			CriteriaSet subfilters = CriteriaSet.And();

			{
				var groupFilters = CriteriaSet.Or();
				subfilters.SubSets.Add(groupFilters);
			}
			{
				var groupFilters = CriteriaSet.Or();
				subfilters.SubSets.Add(groupFilters);
			}

			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ EQUIP_PESS1VALNAME]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet equip___pess1name____Conds = CriteriaSet.And();
					{
						bool equip___pess1name____DoLoad = true;
						// Limits Generation

						// Area limit
						equip___pess1name____DoLoad &= AddCriteriaAreaLimit(equip___pess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

						if (!equip___pess1name____DoLoad)
							return;
						equip___pess1name____Conds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioApess1>()
					{
						BranchLevel = 0, Area = "PESS1", Form = "", IsTree = true, IsTreeTable = false,
						KeySelector = CSGenioApess1.FldCodpesso,
						Selector = CSGenioApess1.FldName,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioApess1.FldName), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioApess1.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioApess1.FldName, CSGenioApess1.FldCodpesso }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, equip___pess1name____Conds, currentSelectedKey, "IBL_EQUIP___PESS1NAME____"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TablePess1Name = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_EQUIP___PESS1NAME____ = ["Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName"];

		/// <summary>
		/// TableTpequTipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___tpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___tpequtipoequiDoLoad = true;
			CriteriaSet equip___tpequtipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpequ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___tpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, hValue);
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
				FillDependant_EquipTableTpequTipoequi(lazyLoad);
				return;
			}

			if (equip___tpequtipoequiDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));

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
				equip___tpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					equip___tpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					equip___tpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tpequcod");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, equip___tpequtipoequiConds, fields, offset, numberItems, sorts, "LED_EQUIP___TPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_EQUIP___TPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_EquipTableTpequTipoequi();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableTpequTipoequi(string PKey)
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
		public void FillDependant_EquipTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableTpequTipoequi(this.ValCodtpequ);
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

		public List<TreeNode> Tree_TableTpequTipoequi { get; protected set; }

		/// <summary>
		/// Get tree structure data -> TableTpequTipoequi
		/// </summary>
		public void LoadTree_TableTpequTipoequi(NameValueCollection requestValues)
		{
			List<TreeNode> Tree = null;

			Tree = new List<TreeNode>();
			List<ColumnSort> sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending));


			FieldRef[] fields = new FieldRef[] { CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldZzstate, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra };
			CriteriaSet subfilters = CriteriaSet.And();


			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ EQUIP_TPEQUVALTIPOEQUI]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet equip___tpequtipoequiConds = CriteriaSet.And();
					{
						bool equip___tpequtipoequiDoLoad = true;

						if (!equip___tpequtipoequiDoLoad)
							return;
						equip___tpequtipoequiConds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioAtpequ>()
					{
						BranchLevel = 0, Area = "TPEQU", Form = "", IsTree = true, IsTreeTable = true,
						KeySelector = CSGenioAtpequ.FldCodtpequ,
						Selector = CSGenioAtpequ.FldTpequcod,
						ParentSelector = CSGenioAtpequ.FldTpequpai,
						Sorts = new List<ColumnSort>() { new ColumnSort(new ColumnReference(CSGenioAtpequ.FldTpequcod), SortOrder.Ascending) },
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioAtpequ.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra, CSGenioAtpequ.FldCodtpequ }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, equip___tpequtipoequiConds, currentSelectedKey, "IBL_EQUIP___TPEQUTIPOEQUI"));
					break;
				}
			}
			// Filter the final list to only include the top nodes
			Tree_TableTpequTipoequi = Tree.FindAll(x => x.HasParent == false);
		}

		private readonly string[] _fieldsToSerialize_EQUIP___TPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTpequcod", "Tpequ.ValTipoequi", "Tpequ.ValTpequpai", "Tpequ.ValNivel", "Tpequ.ValBackcolo", "Tpequ.ValCorletra"];

		/// <summary>
		/// TableWarehWarehdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___warehwarehdes(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___warehwarehdesDoLoad = true;
			CriteriaSet equip___warehwarehdesConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("wareh", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___warehwarehdesConds.Equal(CSGenioAwareh.FldCodwareh, hValue);
					this.ValCodwareh = DBConversion.ToString(hValue);
				}
			}

			TableWarehWarehdes = new TableDBEdit<Models.Wareh>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}
				FillDependant_EquipTableWarehWarehdes(lazyLoad);
				return;
			}

			if (equip___warehwarehdesDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableWarehWarehdes, "sTableWarehWarehdes", "dTableWarehWarehdes", qs, "wareh");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAwareh.FldWarehcod), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableWarehWarehdes_tableFilters"]))
					TableWarehWarehdes.TableFilters = bool.Parse(qs["TableWarehWarehdes_tableFilters"]);
				else
					TableWarehWarehdes.TableFilters = false;

				query = qs["qTableWarehWarehdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAwareh.FldWarehdes, query + "%");
				}
				equip___warehwarehdesConds.SubSet(search_filters);

				string tryParsePage = qs["pTableWarehWarehdes"] != null ? qs["pTableWarehWarehdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes, CSGenioAwareh.FldWarehcod, CSGenioAwareh.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_WAREHWAREHDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("wareh", FormMode.New) || Navigation.checkFormMode("wareh", FormMode.Duplicate))
					equip___warehwarehdesConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAwareh.FldZzstate, 0)
						.Equal(CSGenioAwareh.FldCodwareh, Navigation.GetStrValue("wareh")));
				else
					equip___warehwarehdesConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAwareh.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("wareh", "warehdes");
				ListingMVC<CSGenioAwareh> listing = Models.ModelBase.Where<CSGenioAwareh>(m_userContext, false, equip___warehwarehdesConds, fields, offset, numberItems, sorts, "LED_EQUIP___WAREHWAREHDES", true, false, firstVisibleColumn: firstVisibleColumn);

				TableWarehWarehdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableWarehWarehdes.Query = query;
				TableWarehWarehdes.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Wareh(m_userContext, r, true, _fieldsToSerialize_EQUIP___WAREHWAREHDES));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_wareh") != null)
				{
					this.ValCodwareh = Navigation.GetStrValue("RETURN_wareh");
					Navigation.CurrentLevel.SetEntry("RETURN_wareh", null);
				}

				TableWarehWarehdes.List = new SelectList(TableWarehWarehdes.Elements.ToSelectList(x => x.ValWarehdes, x => x.ValCodwareh,  x => x.ValCodwareh == this.ValCodwareh), "Value", "Text", this.ValCodwareh);
				FillDependant_EquipTableWarehWarehdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Wareh</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableWarehWarehdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAwareh.FldCodwareh, CSGenioAwareh.FldWarehdes];

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

			CSGenioAwareh tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAwareh.FldCodwareh, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableWarehWarehdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTableWarehWarehdes(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableWarehWarehdes(this.ValCodwareh);
			try
			{

				// Fill List fields
				this.ValCodwareh = ViewModelConversion.ToString(row["wareh.codwareh"]);
				TableWarehWarehdes.Value = (string)row["wareh.warehdes"];
				if (GenFunctions.emptyG(this.ValCodwareh) == 1)
				{
					this.ValCodwareh = "";
					TableWarehWarehdes.Value = "";
					Navigation.ClearValue("wareh");
				}
				else if (lazyLoad)
				{
					TableWarehWarehdes.SetPagination(1, 0, false, false, 1);
					TableWarehWarehdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodwareh),
							Text = Convert.ToString(TableWarehWarehdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodwareh);
				}

				TableWarehWarehdes.Selected = this.ValCodwareh;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableWarehWarehdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP___WAREHWAREHDES = ["Wareh", "Wareh.ValCodwareh", "Wareh.ValZzstate", "Wareh.ValWarehdes", "Wareh.ValWarehcod"];

		/// <summary>
		/// TableItemItemdes -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___item_itemdes_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___item_itemdes_DoLoad = true;
			CriteriaSet equip___item_itemdes_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("item", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___item_itemdes_Conds.Equal(CSGenioAitem.FldCoditem, hValue);
					this.ValCoditem = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			equip___item_itemdes_DoLoad &= AddCriteriaAreaLimit(equip___item_itemdes_Conds, CSGenio.business.CSGenioAwareh.FldCodwareh, "wareh", this.ValCodwareh, true);

			TableItemItemdes = new TableDBEdit<Models.Item>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}
				FillDependant_EquipTableItemItemdes(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodwareh))
				equip___item_itemdes_DoLoad = false;

			if (equip___item_itemdes_DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableItemItemdes, "sTableItemItemdes", "dTableItemItemdes", qs, "item");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAitem.FldItemcod), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableItemItemdes_tableFilters"]))
					TableItemItemdes.TableFilters = bool.Parse(qs["TableItemItemdes_tableFilters"]);
				else
					TableItemItemdes.TableFilters = false;

				query = qs["qTableItemItemdes"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAitem.FldItemdes, query + "%");
				}
				equip___item_itemdes_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableItemItemdes"] != null ? qs["pTableItemItemdes"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes, CSGenioAitem.FldItemcod, CSGenioAitem.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_ITEMITEMDES]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("item", FormMode.New) || Navigation.checkFormMode("item", FormMode.Duplicate))
					equip___item_itemdes_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAitem.FldZzstate, 0)
						.Equal(CSGenioAitem.FldCoditem, Navigation.GetStrValue("item")));
				else
					equip___item_itemdes_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAitem.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("item", "itemdes");
				ListingMVC<CSGenioAitem> listing = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, equip___item_itemdes_Conds, fields, offset, numberItems, sorts, "LED_EQUIP___ITEM_ITEMDES_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableItemItemdes.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableItemItemdes.Query = query;
				TableItemItemdes.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Item(m_userContext, r, true, _fieldsToSerialize_EQUIP___ITEM_ITEMDES_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_item") != null)
				{
					this.ValCoditem = Navigation.GetStrValue("RETURN_item");
					Navigation.CurrentLevel.SetEntry("RETURN_item", null);
				}

				TableItemItemdes.List = new SelectList(TableItemItemdes.Elements.ToSelectList(x => x.ValItemdes, x => x.ValCoditem,  x => x.ValCoditem == this.ValCoditem), "Value", "Text", this.ValCoditem);
				FillDependant_EquipTableItemItemdes();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Item</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableItemItemdes(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAitem.FldCoditem, CSGenioAitem.FldItemdes];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("wareh");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioAitem.FldCodwareh, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAitem tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAitem.FldCoditem, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableItemItemdes (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTableItemItemdes(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableItemItemdes(this.ValCoditem);
			try
			{

				// Fill List fields
				this.ValCoditem = ViewModelConversion.ToString(row["item.coditem"]);
				TableItemItemdes.Value = (string)row["item.itemdes"];
				if (GenFunctions.emptyG(this.ValCoditem) == 1)
				{
					this.ValCoditem = "";
					TableItemItemdes.Value = "";
					Navigation.ClearValue("item");
				}
				else if (lazyLoad)
				{
					TableItemItemdes.SetPagination(1, 0, false, false, 1);
					TableItemItemdes.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoditem),
							Text = Convert.ToString(TableItemItemdes.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoditem);
				}

				TableItemItemdes.Selected = this.ValCoditem;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableItemItemdes): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP___ITEM_ITEMDES_ = ["Item", "Item.ValCoditem", "Item.ValZzstate", "Item.ValItemdes", "Item.ValItemcod"];

		/// <summary>
		/// TableRoom1Roomnr -> (F1)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___room1roomnr__(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___room1roomnr__DoLoad = true;
			CriteriaSet equip___room1roomnr__Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("room1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___room1roomnr__Conds.Equal(CSGenioAroom1.FldCodrooms, hValue);
					this.ValCodrooms = DBConversion.ToString(hValue);
				}
			}

			TableRoom1Roomnr = new TableDBEdit<Models.Room1>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}
				FillDependant_EquipTableRoom1Roomnr(lazyLoad);
				return;
			}

			if (equip___room1roomnr__DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableRoom1Roomnr, "sTableRoom1Roomnr", "dTableRoom1Roomnr", qs, "room1");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableRoom1Roomnr_tableFilters"]))
					TableRoom1Roomnr.TableFilters = bool.Parse(qs["TableRoom1Roomnr_tableFilters"]);
				else
					TableRoom1Roomnr.TableFilters = false;

				query = qs["qTableRoom1Roomnr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAroom1.FldRoomnr, query + "%");
				}
				equip___room1roomnr__Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableRoom1Roomnr"] != null ? qs["pTableRoom1Roomnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_ROOM1ROOMNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("room1", FormMode.New) || Navigation.checkFormMode("room1", FormMode.Duplicate))
					equip___room1roomnr__Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAroom1.FldZzstate, 0)
						.Equal(CSGenioAroom1.FldCodrooms, Navigation.GetStrValue("room1")));
				else
					equip___room1roomnr__Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAroom1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAroom1> listing = Models.ModelBase.Where<CSGenioAroom1>(m_userContext, false, equip___room1roomnr__Conds, fields, offset, numberItems, sorts, "LED_EQUIP___ROOM1ROOMNR__", true, false, firstVisibleColumn: firstVisibleColumn);

				TableRoom1Roomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableRoom1Roomnr.Query = query;
				TableRoom1Roomnr.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Room1(m_userContext, r, true, _fieldsToSerialize_EQUIP___ROOM1ROOMNR__));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_room1") != null)
				{
					this.ValCodrooms = Navigation.GetStrValue("RETURN_room1");
					Navigation.CurrentLevel.SetEntry("RETURN_room1", null);
				}

				TableRoom1Roomnr.List = new SelectList(TableRoom1Roomnr.Elements.ToSelectList(x => x.ValRoomnr, x => x.ValCodrooms,  x => x.ValCodrooms == this.ValCodrooms), "Value", "Text", this.ValCodrooms);
				FillDependant_EquipTableRoom1Roomnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableRoom1Roomnr (F1)
		/// </summary>
		/// <param name="PKey">Primary Key of Room1</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableRoom1Roomnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAroom1.FldCodrooms, CSGenioAroom1.FldRoomnr, CSGenioAroom1.FldDesignat];

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

			CSGenioAroom1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAroom1.FldCodrooms, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableRoom1Roomnr (F1)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTableRoom1Roomnr(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableRoom1Roomnr(this.ValCodrooms);
			try
			{
				this.funcRoom1ValDesignat = () => (string)row["room1.designat"];

				// Fill List fields
				this.ValCodrooms = ViewModelConversion.ToString(row["room1.codrooms"]);
				TableRoom1Roomnr.Value = (string)row["room1.roomnr"];
				if (GenFunctions.emptyG(this.ValCodrooms) == 1)
				{
					this.ValCodrooms = "";
					TableRoom1Roomnr.Value = "";
					Navigation.ClearValue("room1");
				}
				else if (lazyLoad)
				{
					TableRoom1Roomnr.SetPagination(1, 0, false, false, 1);
					TableRoom1Roomnr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodrooms),
							Text = Convert.ToString(TableRoom1Roomnr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodrooms);
				}

				TableRoom1Roomnr.Selected = this.ValCodrooms;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableRoom1Roomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP___ROOM1ROOMNR__ = ["Room1", "Room1.ValCodrooms", "Room1.ValZzstate"];
		/// <summary>
		/// List_Movimevv -> (DW)
		/// </summary>
		/// <param name="qs"></param>
		public void Load_Equip___pseudmovimevv(NameValueCollection qs)
		{
			bool equip___pseudmovimevvDoLoad = true;
			CriteriaSet equip___pseudmovimevvConds = CriteriaSet.And();


			this.List_Movimevv_Area = "Rooms";
			this.List_Movimevv = new List<GenioMVC.Models.Rooms>();
			this.List_MovimevvSelected = new List<GenioMVC.Models.Rooms>();
			
			if (equip___pseudmovimevvDoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();



// USE /[MANUAL GQT OVERRQ EQUIP_PSEUDMOVIMEVV]/

				// Limitation by Zzstate
				if (!Navigation.checkFormMode("Rooms", FormMode.New)) // TODO: Check in Duplicate mode
					equip___pseudmovimevvConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioArooms.FldZzstate), CriteriaOperator.NotEqual, 1));

				List_Movimevv = Models.ModelBase.Where<CSGenioArooms>(m_userContext, false, args: equip___pseudmovimevvConds, numRegs: -1, sorts: sorts).RowsForViewModel<GenioMVC.Models.Rooms>((r) => new GenioMVC.Models.Rooms(m_userContext, r));
				
				// Get primary keys of selected rows
				Load_Equip___pseudmovimevv_selected_ids();
				
				List_MovimevvSelected = List_Movimevv.Where(x => List_Movimevv_SelectedIds.Contains(x.ValCodrooms)).ToList();
			}
		}
		
		/// <summary>
		/// List_Movimevv_SelectedIds
		/// </summary>
		public void Load_Equip___pseudmovimevv_selected_ids()
		{
			if (List_Movimevv_SelectedIds == null)
				List_Movimevv_SelectedIds = [];
			
			// Create criteria set
			CriteriaSet equip___pseudmovimevv_roomnr_Conds = CriteriaSet.And();
			equip___pseudmovimevv_roomnr_Conds.Equal(CSGenioAmovim.FldCodequip, ValCodequip);

			// Get primary keys of selected rows
			if (List_Movimevv_SelectedIds.Length == 0)
				List_Movimevv_SelectedIds = Models.ModelBase.All<CSGenioAmovim>(m_userContext, equip___pseudmovimevv_roomnr_Conds).Rows.Select(x => x.ValCodrooms).ToArray();
		}

		/// <summary>
		/// TableDecomDecomnr -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip___decomdecomnr_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equip___decomdecomnr_DoLoad = true;
			CriteriaSet equip___decomdecomnr_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("decom", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equip___decomdecomnr_Conds.Equal(CSGenioAdecom.FldCoddeco, hValue);
					this.ValCoddeco = DBConversion.ToString(hValue);
				}
			}

			TableDecomDecomnr = new TableDBEdit<Models.Decom>();

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_decom") != null)
				{
					this.ValCoddeco = Navigation.GetStrValue("RETURN_decom");
					Navigation.CurrentLevel.SetEntry("RETURN_decom", null);
				}
				FillDependant_EquipTableDecomDecomnr(lazyLoad);
				return;
			}

			if (equip___decomdecomnr_DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableDecomDecomnr, "sTableDecomDecomnr", "dTableDecomDecomnr", qs, "decom");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableDecomDecomnr_tableFilters"]))
					TableDecomDecomnr.TableFilters = bool.Parse(qs["TableDecomDecomnr_tableFilters"]);
				else
					TableDecomDecomnr.TableFilters = false;

				query = qs["qTableDecomDecomnr"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAdecom.FldDecomnr, query + "%");
				}
				equip___decomdecomnr_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableDecomDecomnr"] != null ? qs["pTableDecomDecomnr"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr, CSGenioAdecom.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIP_DECOMDECOMNR]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("decom", FormMode.New) || Navigation.checkFormMode("decom", FormMode.Duplicate))
					equip___decomdecomnr_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAdecom.FldZzstate, 0)
						.Equal(CSGenioAdecom.FldCoddeco, Navigation.GetStrValue("decom")));
				else
					equip___decomdecomnr_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAdecom.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("decom", "decomnr");
				ListingMVC<CSGenioAdecom> listing = Models.ModelBase.Where<CSGenioAdecom>(m_userContext, false, equip___decomdecomnr_Conds, fields, offset, numberItems, sorts, "LED_EQUIP___DECOMDECOMNR_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableDecomDecomnr.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableDecomDecomnr.Query = query;
				TableDecomDecomnr.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Decom(m_userContext, r, true, _fieldsToSerialize_EQUIP___DECOMDECOMNR_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_decom") != null)
				{
					this.ValCoddeco = Navigation.GetStrValue("RETURN_decom");
					Navigation.CurrentLevel.SetEntry("RETURN_decom", null);
				}

				TableDecomDecomnr.List = new SelectList(TableDecomDecomnr.Elements.ToSelectList(x => x.ValDecomnr, x => x.ValCoddeco,  x => x.ValCoddeco == this.ValCoddeco), "Value", "Text", this.ValCoddeco);
				FillDependant_EquipTableDecomDecomnr();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableDecomDecomnr (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Decom</param>
		public ConcurrentDictionary<string, object> GetDependant_EquipTableDecomDecomnr(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAdecom.FldCoddeco, CSGenioAdecom.FldDecomnr];

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

			CSGenioAdecom tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAdecom.FldCoddeco, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableDecomDecomnr (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquipTableDecomDecomnr(bool lazyLoad = false)
		{
			var row = GetDependant_EquipTableDecomDecomnr(this.ValCoddeco);
			try
			{

				// Fill List fields
				this.ValCoddeco = ViewModelConversion.ToString(row["decom.coddeco"]);
				TableDecomDecomnr.Value = (decimal?)row["decom.decomnr"];
				if (GenFunctions.emptyG(this.ValCoddeco) == 1)
				{
					this.ValCoddeco = "";
					TableDecomDecomnr.Value = 0m;
					Navigation.ClearValue("decom");
				}
				else if (lazyLoad)
				{
					TableDecomDecomnr.SetPagination(1, 0, false, false, 1);
					TableDecomDecomnr.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCoddeco),
							Text = Convert.ToString(TableDecomDecomnr.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCoddeco);
				}

				TableDecomDecomnr.Selected = this.ValCoddeco;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableDecomDecomnr): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP___DECOMDECOMNR_ = ["Decom", "Decom.ValCoddeco", "Decom.ValZzstate", "Decom.ValDecomnr"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"equip.codempre" => ViewModelConversion.ToString(modelValue),
				"equip.coddeco" => ViewModelConversion.ToString(modelValue),
				"equip.coditem" => ViewModelConversion.ToString(modelValue),
				"equip.codpess1" => ViewModelConversion.ToString(modelValue),
				"equip.codrooms" => ViewModelConversion.ToString(modelValue),
				"equip.codtpequ" => ViewModelConversion.ToString(modelValue),
				"equip.codwareh" => ViewModelConversion.ToString(modelValue),
				"equip.sequennr" => ViewModelConversion.ToNumeric(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"equip.sitefabr" => ViewModelConversion.ToString(modelValue),
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"equip.frequenc" => ViewModelConversion.ToNumeric(modelValue),
				"equip.valortot" => ViewModelConversion.ToNumeric(modelValue),
				"equip.dtaquisi" => ViewModelConversion.ToDateTime(modelValue),
				"equip.dtdeco" => ViewModelConversion.ToDateTime(modelValue),
				"equip.bought" => ViewModelConversion.ToLogic(modelValue),
				"room1.designat" => ViewModelConversion.ToString(modelValue),
				"equip.dtrefere" => ViewModelConversion.ToDateTime(modelValue),
				"equip.first" => ViewModelConversion.ToString(modelValue),
				"equip.before" => ViewModelConversion.ToString(modelValue),
				"equip.followin" => ViewModelConversion.ToString(modelValue),
				"equip.last" => ViewModelConversion.ToString(modelValue),
				"equip.qtdmovim" => ViewModelConversion.ToNumeric(modelValue),
				"equip.moviment" => ViewModelConversion.ToString(modelValue),
				"equip.photogra" => ViewModelConversion.ToImage(modelValue),
				"equip.lastpho" => ViewModelConversion.ToImage(modelValue),
				"equip.ifabatif" => ViewModelConversion.ToLogic(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"wareh.codwareh" => ViewModelConversion.ToString(modelValue),
				"wareh.warehdes" => ViewModelConversion.ToString(modelValue),
				"item.coditem" => ViewModelConversion.ToString(modelValue),
				"room1.codrooms" => ViewModelConversion.ToString(modelValue),
				"room1.roomnr" => ViewModelConversion.ToString(modelValue),
				"decom.coddeco" => ViewModelConversion.ToString(modelValue),
				"decom.decomnr" => ViewModelConversion.ToNumeric(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SanitizeHTMLFields()
		{
			ValMoviment = Helpers.HtmlSanitizerHelper.SanitizeHTML(ValMoviment, false);
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhotogra != null)
				ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, ValCodequip);
			if (ValLastpho != null)
				ValLastpho.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldLastpho.Field, null, ValCodequip);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP]/

		#endregion
	}
}
