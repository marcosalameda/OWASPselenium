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

namespace GenioMVC.ViewModels.Rooms
{
	public class Salas_ViewModel : FormViewModel<Models.Rooms>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Room No." Tipo:"C"</summary>
		[Display(Name = "ROOM_NO_08024", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValRoomnr { get; set; }

		/// <summary>Campo : "Room Designation" Tipo:"C"</summary>
		[Display(Name = "ROOM_DESIGNATION35483", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValDesignat { get; set; }


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

		public string ValCodrooms { get; set; }

		public Salas_ViewModel() : base("FSALAS") { }

		public Salas_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FSALAS", currentNavigation, nestedForm) { }

		public Salas_ViewModel(Models.Rooms row, NavigationContext currentNavigation, bool nestedForm = false) : base("FSALAS", row, currentNavigation, nestedForm) { }

		public Salas_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("rooms", id);
			Model = Models.Rooms.Find(id, "FSALAS", fieldsToQuery: fieldsToLoad);
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
			Models.Rooms model = new Models.Rooms() { Identifier = "FSALAS" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Rooms model)
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

		public static StatusMessage DeleteConditions(Models.Rooms model)
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

		public static StatusMessage ViewConditions(Models.Rooms model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Rooms model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Rooms m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Rooms) to ViewModel (Salas) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValRoomnr = ViewModelConversion.ToString(m.ValRoomnr);
 				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
 				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Rooms) to ViewModel (Salas) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Rooms m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Salas) to Model (Rooms) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValRoomnr = ViewModelConversion.ToString(ValRoomnr);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Salas) to Model (Rooms) - Error during mapping");
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
				Model = Models.Rooms.Find(Navigation.GetStrValue("rooms"), "FSALAS");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Rooms() { Identifier = "FSALAS" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("rooms");
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

			Model.Identifier = "FSALAS";
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

		protected override void LoadDocumentsProperties(Models.Rooms row)
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
				Model = Models.Rooms.Find(Navigation.GetStrValue("rooms"), "FSALAS");
				if (Model == null)
				{
					Model = new Models.Rooms() { Identifier = "FSALAS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("rooms");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL SALAS]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW SALAS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE SALAS]/
		public override void Save()
		{

			try { Model = Models.Rooms.Find(Navigation.GetStrValue("rooms"), "FSALAS"); }
			finally { if (Model == null) Model = new Models.Rooms() { Identifier = "FSALAS" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY SALAS]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Rooms.Find(Navigation.GetStrValue("rooms"), "FSALAS"); }
			finally { if (Model == null) Model = new Models.Rooms() { Identifier = "FSALAS" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE SALAS]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY SALAS]/
		public override void Destroy(string id)
		{
			Model = Models.Rooms.Find(id, "FSALAS");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM SALAS]/
		#endregion
	}
}
