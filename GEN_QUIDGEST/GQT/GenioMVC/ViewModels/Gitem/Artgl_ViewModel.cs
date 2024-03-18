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
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Gitem
{
	public class Artgl_ViewModel : FormViewModel<Models.Gitem>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Global Item" Tipo:"C"</summary>
		[Display(Name = "GLOBAL_ITEM49586", ResourceType = typeof(Resources.Resources))]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValItemdes { get; set; }

		/// <summary>Campo : "Code" Tipo:"C"</summary>
		[Display(Name = "CODE49225", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(15, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValItemgcod { get; set; }

		/// <summary>Campo : "Catalog" Tipo:"IB"</summary>
		[Display(Name = "CATALOG23832", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBDocument")]
		[Document("ValDocument", false, true, false, false, DocumentViewTypeMode.Print)]
		public string ValDocument { get; set; }
		public string ValDocumentfk { get; set; }
		public DocumsProperties_ViewModel ValDocumentPropertiesVM { get; set; }


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

		public string ValCodgitem { get; set; }

		public Artgl_ViewModel() : base("FARTGL") { }

		public Artgl_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FARTGL", currentNavigation, nestedForm) { }

		public Artgl_ViewModel(Models.Gitem row, NavigationContext currentNavigation, bool nestedForm = false) : base("FARTGL", row, currentNavigation, nestedForm) { }

		public Artgl_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("gitem", id);
			Model = Models.Gitem.Find(id, "FARTGL", fieldsToQuery: fieldsToLoad);
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
			Models.Gitem model = new Models.Gitem() { Identifier = "FARTGL" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Gitem model)
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

		public static StatusMessage DeleteConditions(Models.Gitem model)
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

		public static StatusMessage ViewConditions(Models.Gitem model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Gitem model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Gitem m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Gitem) to ViewModel (Artgl) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValItemdes = ViewModelConversion.ToString(m.ValItemdes);
 				ValItemgcod = ViewModelConversion.ToString(m.ValItemgcod);
 				ValDocument = ViewModelConversion.ToString(m.ValDocument);
				ValDocumentfk = ViewModelConversion.ToString(m.ValDocumentfk);
 				ValCodgitem = ViewModelConversion.ToString(m.ValCodgitem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Gitem) to ViewModel (Artgl) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Gitem m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artgl) to Model (Gitem) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValItemdes = ViewModelConversion.ToString(ValItemdes);
				m.ValItemgcod = ViewModelConversion.ToString(ValItemgcod);
				m.ValDocument = ViewModelConversion.ToString(ValDocument);
				m.ValDocumentfk = ViewModelConversion.ToString(ValDocumentfk);

				m.ValCodgitem = ViewModelConversion.ToString(ValCodgitem);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Artgl) to Model (Gitem) - Error during mapping");
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
				Model = Models.Gitem.Find(Navigation.GetStrValue("gitem"), "FARTGL");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Gitem() { Identifier = "FARTGL" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("gitem");
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

			Model.Identifier = "FARTGL";
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

		protected override void LoadDocumentsProperties(Models.Gitem row)
		{
			try
			{
				ValDocumentPropertiesVM = row.GetInfoDoc("ValDocument");
			}
			catch (Exception)
			{
				ValDocumentPropertiesVM = DocumsProperties_ViewModel.EmptyDocum();
			}
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
				Model = Models.Gitem.Find(Navigation.GetStrValue("gitem"), "FARTGL");
				if (Model == null)
				{
					Model = new Models.Gitem() { Identifier = "FARTGL" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("gitem");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL ARTGL]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW ARTGL]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE ARTGL]/
		public override void Save()
		{

			try { Model = Models.Gitem.Find(Navigation.GetStrValue("gitem"), "FARTGL"); }
			finally { if (Model == null) Model = new Models.Gitem() { Identifier = "FARTGL" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY ARTGL]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Gitem.Find(Navigation.GetStrValue("gitem"), "FARTGL"); }
			finally { if (Model == null) Model = new Models.Gitem() { Identifier = "FARTGL" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE ARTGL]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY ARTGL]/
		public override void Destroy(string id)
		{
			Model = Models.Gitem.Find(id, "FARTGL");
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
// USE /[MANUAL GQT VIEWMODEL_CUSTOM ARTGL]/
		#endregion
	}
}
