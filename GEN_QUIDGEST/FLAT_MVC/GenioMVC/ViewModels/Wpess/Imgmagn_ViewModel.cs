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

namespace GenioMVC.ViewModels.Wpess
{
	public class Imgmagn_ViewModel : FormViewModel<Models.Wpess>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "" Tipo:"IJ"</summary>
		[UIHint("ImageMagnifier")]
		public byte[] ValFtbackgr { get; set; }


		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls

		#endregion

		#region Additional foreign keys

		public string ValCodwareh { get; set; }

		#endregion

		#region Extra database fields

		#endregion

		#region Fields for formulas
		// Field to formula
		/// <summary>Field : "Name" Tipo: "C"</summary>
		[AllowHtml]
		public string ValName { get; set; }
		#endregion

		public string ValCodpess { get; set; }

		public Imgmagn_ViewModel() : base("FIMGMAGN") { }

		public Imgmagn_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FIMGMAGN", currentNavigation, nestedForm) { }

		public Imgmagn_ViewModel(Models.Wpess row, NavigationContext currentNavigation, bool nestedForm = false) : base("FIMGMAGN", row, currentNavigation, nestedForm) { }

		public Imgmagn_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("wpess", id);
			Model = Models.Wpess.Find(id, "FIMGMAGN", fieldsToQuery: fieldsToLoad);
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
			return InsertConditions(Navigation);
		}

		public static StatusMessage InsertConditions(NavigationContext navigation)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Wpess model = new Models.Wpess() { Identifier = "FIMGMAGN" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Wpess model)
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

		public static StatusMessage DeleteConditions(Models.Wpess model)
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

		public static StatusMessage ViewConditions(Models.Wpess model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Wpess model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Wpess m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Wpess) to ViewModel (Imgmagn) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValFtbackgr = ViewModelConversion.ToImage(m.ValFtbackgr);
 				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValCodpess = ViewModelConversion.ToString(m.ValCodpess);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Wpess) to ViewModel (Imgmagn) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Wpess m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Imgmagn) to Model (Wpess) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValCodpess = ViewModelConversion.ToString(ValCodpess);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Imgmagn) to Model (Wpess) - Error during mapping");
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
				Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), "FIMGMAGN");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Wpess() { Identifier = "FIMGMAGN" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");
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

			Model.Identifier = "FIMGMAGN";
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

		protected override void LoadDocumentsProperties(Models.Wpess row)
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
				Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), "FIMGMAGN");
				if (Model == null)
				{
					Model = new Models.Wpess() { Identifier = "FIMGMAGN" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("wpess");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL IMGMAGN]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW IMGMAGN]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE IMGMAGN]/
		public override void Save()
		{

			try { Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), "FIMGMAGN"); }
			finally { if (Model == null) Model = new Models.Wpess() { Identifier = "FIMGMAGN" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY IMGMAGN]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Wpess.Find(Navigation.GetStrValue("wpess"), "FIMGMAGN"); }
			finally { if (Model == null) Model = new Models.Wpess() { Identifier = "FIMGMAGN" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE IMGMAGN]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY IMGMAGN]/
		public override void Destroy(string id)
		{
			Model = Models.Wpess.Find(id, "FIMGMAGN");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM IMGMAGN]/
		#endregion
	}
}
