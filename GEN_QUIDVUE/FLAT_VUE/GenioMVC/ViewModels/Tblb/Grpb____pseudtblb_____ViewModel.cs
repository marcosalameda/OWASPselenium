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

namespace GenioMVC.ViewModels.Tblb
{
	public class Grpb____pseudtblb_____ViewModel : GridTableListRowViewModel<Models.Tblb>, IPreparableForSerialization
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
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValFkey1 { get; set; }

		#endregion
		/// <summary>
		/// Title: "Text" | Type: "C"
		/// </summary>
		public string ValText { get; set; }
		/// <summary>
		/// Title: "Multiline Text" | Type: "C"
		/// </summary>
		public string ValTextml { get; set; }
		/// <summary>
		/// Title: "Numeric (Integer)" | Type: "N"
		/// </summary>
		public decimal? ValNumint { get; set; }
		/// <summary>
		/// Title: "Numeric (Decimal)" | Type: "ND"
		/// </summary>
		public decimal? ValNumdec { get; set; }
		/// <summary>
		/// Title: "Currency (Interger)" | Type: "$"
		/// </summary>
		public decimal? ValCurint { get; set; }
		/// <summary>
		/// Title: "Currency (Decimal)" | Type: "$D"
		/// </summary>
		public decimal? ValCurdec { get; set; }
		/// <summary>
		/// Title: "Boolean" | Type: "L"
		/// </summary>
		public bool ValBool { get; set; }
		/// <summary>
		/// Title: "Date" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "DateTime (Minutes)" | Type: "DT"
		/// </summary>
		public DateTime? ValDatetm { get; set; }
		/// <summary>
		/// Title: "DateTime (Seconds)" | Type: "DS"
		/// </summary>
		public DateTime? ValDatets { get; set; }
		/// <summary>
		/// Title: "Time (Hours-Minutes)" | Type: "T"
		/// </summary>
		public string ValTimehm { get; set; }
		/// <summary>
		/// Title: "Enumeration (Text)" | Type: "AC"
		/// </summary>
		public string ValEnumt { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValEnumt { get; set; }
		/// <summary>
		/// Title: "Enumeration (Numeric)" | Type: "AN"
		/// </summary>
		public decimal ValEnumn { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValEnumn { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtblb { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Grpb____pseudtblb_____ViewModel() : base(null!) { }

		public Grpb____pseudtblb_____ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FGRPB____PSEUDTBLB____", nestedForm) { }

		public Grpb____pseudtblb_____ViewModel(UserContext userContext, Models.Tblb row, bool nestedForm = false) : base(userContext, "FGRPB____PSEUDTBLB____", row, nestedForm) { }

		public Grpb____pseudtblb_____ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("tblb", id);
			Model = Models.Tblb.Find(id, userContext, "FGRPB____PSEUDTBLB____", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
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
			Models.Tblb model = new Models.Tblb(userContext) { Identifier = "FGRPB____PSEUDTBLB____" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FGRPB____PSEUDTBLB____");
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
			Models.Tblb model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Tblb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Tblb) to ViewModel (Grpb____pseudtblb____) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValFkey1 = ViewModelConversion.ToString(m.ValFkey1);
				ValText = ViewModelConversion.ToString(m.ValText);
				ValTextml = ViewModelConversion.ToString(m.ValTextml);
				ValNumint = ViewModelConversion.ToNumeric(m.ValNumint);
				ValNumdec = ViewModelConversion.ToNumeric(m.ValNumdec);
				ValCurint = ViewModelConversion.ToNumeric(m.ValCurint);
				ValCurdec = ViewModelConversion.ToNumeric(m.ValCurdec);
				ValBool = ViewModelConversion.ToLogic(m.ValBool);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValDatetm = ViewModelConversion.ToDateTime(m.ValDatetm);
				ValDatets = ViewModelConversion.ToDateTime(m.ValDatets);
				ValTimehm = ViewModelConversion.ToString(m.ValTimehm);
				ValEnumt = ViewModelConversion.ToString(m.ValEnumt);
				ValEnumn = ViewModelConversion.ToNumeric(m.ValEnumn);
				ValCodtblb = ViewModelConversion.ToString(m.ValCodtblb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Tblb) to ViewModel (Grpb____pseudtblb____) - Error during mapping");
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
		public override void MapToModel(Models.Tblb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Grpb____pseudtblb____) to Model (Tblb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValText = ViewModelConversion.ToString(ValText);
				m.ValTextml = ViewModelConversion.ToString(ValTextml);
				m.ValNumint = ViewModelConversion.ToNumeric(ValNumint);
				m.ValNumdec = ViewModelConversion.ToNumeric(ValNumdec);
				m.ValCurint = ViewModelConversion.ToNumeric(ValCurint);
				m.ValCurdec = ViewModelConversion.ToNumeric(ValCurdec);
				m.ValBool = ViewModelConversion.ToLogic(ValBool);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValDatetm = ViewModelConversion.ToDateTime(ValDatetm);
				m.ValDatets = ViewModelConversion.ToDateTime(ValDatets);
				m.ValTimehm = ViewModelConversion.ToString(ValTimehm);
				m.ValEnumt = ViewModelConversion.ToString(ValEnumt);
				m.ValEnumn = ViewModelConversion.ToNumeric(ValEnumn);
				m.ValCodtblb = ViewModelConversion.ToString(ValCodtblb);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValFkey1 = ViewModelConversion.ToString(ValFkey1);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Grpb____pseudtblb____) to Model (Tblb) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "tblb.text":
						this.ValText = ViewModelConversion.ToString(_value);
						break;
					case "tblb.textml":
						this.ValTextml = ViewModelConversion.ToString(_value);
						break;
					case "tblb.numint":
						this.ValNumint = ViewModelConversion.ToNumeric(_value);
						break;
					case "tblb.numdec":
						this.ValNumdec = ViewModelConversion.ToNumeric(_value);
						break;
					case "tblb.curint":
						this.ValCurint = ViewModelConversion.ToNumeric(_value);
						break;
					case "tblb.curdec":
						this.ValCurdec = ViewModelConversion.ToNumeric(_value);
						break;
					case "tblb.bool":
						this.ValBool = ViewModelConversion.ToLogic(_value);
						break;
					case "tblb.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "tblb.datetm":
						this.ValDatetm = ViewModelConversion.ToDateTime(_value);
						break;
					case "tblb.datets":
						this.ValDatets = ViewModelConversion.ToDateTime(_value);
						break;
					case "tblb.timehm":
						this.ValTimehm = ViewModelConversion.ToString(_value);
						break;
					case "tblb.enumt":
						this.ValEnumt = ViewModelConversion.ToString(_value);
						break;
					case "tblb.enumn":
						this.ValEnumn = ViewModelConversion.ToNumeric(_value);
						break;
					case "tblb.codtblb":
						this.ValCodtblb = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Grpb____pseudtblb____) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Grpb____pseudtblb____)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Tblb.Find(id ?? Navigation.GetStrValue("tblb"), m_userContext, "FGRPB____PSEUDTBLB____"); }
			finally { Model ??= new Models.Tblb(m_userContext) { Identifier = "FGRPB____PSEUDTBLB____" }; }

			base.LoadModel();
		}


		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Tblb row)
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
				Model = Models.Tblb.Find(Navigation.GetStrValue("tblb"), m_userContext, "FGRPB____PSEUDTBLB____");
				if (Model == null)
				{
					Model = new Models.Tblb(m_userContext) { Identifier = "FGRPB____PSEUDTBLB____" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GRPB____PSEUDTBLB____]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GRPB____PSEUDTBLB____]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValText", Resources.Resources.TEXT04938, ValText, 50);

			validator.Required("ValText", Resources.Resources.TEXT04938, ViewModelConversion.ToString(ValText), FieldType.TEXTO.Formatting);
			validator.StringLength("ValTextml", Resources.Resources.MULTILINE_TEXT38013, ValTextml, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE GRPB____PSEUDTBLB____]/

// USE /[MANUAL GQT VIEWMODEL_APPLY GRPB____PSEUDTBLB____]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GRPB____PSEUDTBLB____]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GRPB____PSEUDTBLB____]/
		public override void Destroy(string id)
		{
			Model = Models.Tblb.Find(id, m_userContext, "FGRPB____PSEUDTBLB____");
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

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"tblb.fkey1" => ViewModelConversion.ToString(modelValue),
				"tblb.text" => ViewModelConversion.ToString(modelValue),
				"tblb.textml" => ViewModelConversion.ToString(modelValue),
				"tblb.numint" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.numdec" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.curint" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.curdec" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.bool" => ViewModelConversion.ToLogic(modelValue),
				"tblb.date" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.datetm" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.datets" => ViewModelConversion.ToDateTime(modelValue),
				"tblb.timehm" => ViewModelConversion.ToString(modelValue),
				"tblb.enumt" => ViewModelConversion.ToString(modelValue),
				"tblb.enumn" => ViewModelConversion.ToNumeric(modelValue),
				"tblb.codtblb" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}



		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM GRPB____PSEUDTBLB____]/

		#endregion
	}
}
