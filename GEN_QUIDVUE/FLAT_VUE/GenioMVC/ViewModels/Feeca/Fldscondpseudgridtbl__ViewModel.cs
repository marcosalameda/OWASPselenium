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

namespace GenioMVC.ViewModels.Feeca
{
	public class Fldscondpseudgridtbl__ViewModel : GridTableListRowViewModel<Models.Feeca>, IPreparableForSerialization
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
		public string ValCodflds { get; set; }

		#endregion
		/// <summary>
		/// Title: "Feedback" | Type: "C"
		/// </summary>
		public string ValFeedback { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodfeeca { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Fldscondpseudgridtbl__ViewModel() : base(null!) { }

		public Fldscondpseudgridtbl__ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FFLDSCONDPSEUDGRIDTBL_", nestedForm) { }

		public Fldscondpseudgridtbl__ViewModel(UserContext userContext, Models.Feeca row, bool nestedForm = false) : base(userContext, "FFLDSCONDPSEUDGRIDTBL_", row, nestedForm) { }

		public Fldscondpseudgridtbl__ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("feeca", id);
			Model = Models.Feeca.Find(id, userContext, "FFLDSCONDPSEUDGRIDTBL_", fieldsToQuery: fieldsToLoad);
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
			Models.Feeca model = new Models.Feeca(userContext) { Identifier = "FFLDSCONDPSEUDGRIDTBL_" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FFLDSCONDPSEUDGRIDTBL_");
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
			Models.Feeca model = Model;
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
		public override void MapFromModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Fldscondpseudgridtbl_) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodflds = ViewModelConversion.ToString(m.ValCodflds);
				ValFeedback = ViewModelConversion.ToString(m.ValFeedback);
				ValCodfeeca = ViewModelConversion.ToString(m.ValCodfeeca);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Feeca) to ViewModel (Fldscondpseudgridtbl_) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Feeca m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Fldscondpseudgridtbl_) to Model (Feeca) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValFeedback = ViewModelConversion.ToString(ValFeedback);
				m.ValCodfeeca = ViewModelConversion.ToString(ValCodfeeca);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodflds = ViewModelConversion.ToString(ValCodflds);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Fldscondpseudgridtbl_) to Model (Feeca) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "feeca.feedback":
						this.ValFeedback = ViewModelConversion.ToString(_value);
						break;
					case "feeca.codfeeca":
						this.ValCodfeeca = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Fldscondpseudgridtbl_) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Fldscondpseudgridtbl_)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Feeca.Find(id ?? Navigation.GetStrValue("feeca"), m_userContext, "FFLDSCONDPSEUDGRIDTBL_"); }
			finally { Model ??= new Models.Feeca(m_userContext) { Identifier = "FFLDSCONDPSEUDGRIDTBL_" }; }

			base.LoadModel();
		}


		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Feeca row)
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
				Model = Models.Feeca.Find(Navigation.GetStrValue("feeca"), m_userContext, "FFLDSCONDPSEUDGRIDTBL_");
				if (Model == null)
				{
					Model = new Models.Feeca(m_userContext) { Identifier = "FFLDSCONDPSEUDGRIDTBL_" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("feeca");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL FLDSCONDPSEUDGRIDTBL_]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW FLDSCONDPSEUDGRIDTBL_]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValFeedback", Resources.Resources.FEEDBACK52855, ValFeedback, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_APPLY FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE FLDSCONDPSEUDGRIDTBL_]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY FLDSCONDPSEUDGRIDTBL_]/
		public override void Destroy(string id)
		{
			Model = Models.Feeca.Find(id, m_userContext, "FFLDSCONDPSEUDGRIDTBL_");
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
				"feeca.codflds" => ViewModelConversion.ToString(modelValue),
				"feeca.feedback" => ViewModelConversion.ToString(modelValue),
				"feeca.codfeeca" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM FLDSCONDPSEUDGRIDTBL_]/

		#endregion
	}
}
