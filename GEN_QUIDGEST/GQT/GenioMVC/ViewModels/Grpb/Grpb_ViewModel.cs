using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using GenioMVC.Helpers;
using GenioMVC.Helpers.ModelBinders;
using GenioMVC.Helpers.Table.Properties;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Grpb
{
	public class Grpb_ViewModel : FormViewModel<Models.Grpb>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Name" Tipo:"C"</summary>
		[Display(Name = "NAME31974", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "" Tipo:"DN"</summary>
		public GridTableList<GenioMVC.ViewModels.Tblb.Grpb____pseudtblb_____ViewModel> ValTblb { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		#endregion

		public string ValCodgrpb { get; set; }

		public Grpb_ViewModel() : base("FGRPB") { }

		public Grpb_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FGRPB", currentNavigation, nestedForm) { }

		public Grpb_ViewModel(Models.Grpb row, NavigationContext currentNavigation, bool nestedForm = false) : base("FGRPB", row, currentNavigation, nestedForm) { }

		public Grpb_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("grpb", id);
			Model = Models.Grpb.Find(id, "FGRPB", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Grpb model = new Models.Grpb() { Identifier = "FGRPB" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Grpb model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			return DeleteConditions(Model);
		}

		public static StatusMessage DeleteConditions(Models.Grpb model)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			return ViewConditions(Model);
		}

		public static StatusMessage ViewConditions(Models.Grpb model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Grpb model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Grpb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Grpb) to ViewModel (Grpb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValCodgrpb = ViewModelConversion.ToString(m.ValCodgrpb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Grpb) to ViewModel (Grpb) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Grpb m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Grpb) to Model (Grpb) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodgrpb = ViewModelConversion.ToString(ValCodgrpb);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Grpb) to Model (Grpb) - Error during mapping");
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
				Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), "FGRPB");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Grpb() { Identifier = "FGRPB" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("grpb");
					}

					LoadDefaultValues();
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");

					oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FGRPB";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Grpb row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST" && Model == null) {
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), "FGRPB");
				if (Model == null)
				{
					Model = new Models.Grpb() { Identifier = "FGRPB" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("grpb");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL GRPB]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW GRPB]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE GRPB]/
		public override void Save()
		{
			try
			{
				this.ValTblb?.Save();
			}
			catch (FieldValidationException fvExc)
			{
				var sMsg = StatusMessage.Error();
				foreach (var message in fvExc.StatusMessage.GetErrorList())
					sMsg.MergeStatusMessage(new StatusMessage(message.Status, message.Message, string.Format("Tblb.{0}", message.Origin)));

				throw new FieldValidationException(sMsg, fvExc.ExceptionSite);
			}

			try { Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), "FGRPB"); }
			finally { if (Model == null) Model = new Models.Grpb() { Identifier = "FGRPB" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY GRPB]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Grpb.Find(Navigation.GetStrValue("grpb"), "FGRPB"); }
			finally { if (Model == null) Model = new Models.Grpb() { Identifier = "FGRPB" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE GRPB]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY GRPB]/
		public override void Destroy(string id)
		{
			Model = Models.Grpb.Find(id, "FGRPB");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
		}




		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM GRPB]/
		#endregion
	}
}
