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

namespace GenioMVC.ViewModels.Perso
{
	public class Perso_ViewModel : FormViewModel<Models.Perso>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		/// <summary>Campo : "Photo" Tipo:"IJ"</summary>
		[Display(Name = "PHOTO51874", ResourceType = typeof(Resources.Resources))]
		[UIHint("DBJpegImage")]
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 100, 115, false, true)]
		public byte[] ValPhoto { get; set; }

		/// <summary>Campo : "Person name" Tipo:"C"</summary>
		[Display(Name = "PERSON_NAME40980", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(85, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValName { get; set; }

		/// <summary>Campo : "Identification number" Tipo:"C"</summary>
		[Display(Name = "IDENTIFICATION_NUMBE11999", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(10, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValIdentifi { get; set; }

		/// <summary>Campo : "Gender" Tipo:"AC"</summary>
		[Display(Name = "GENDER44172", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get; set; }
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }

		/// <summary>Campo : "Email" Tipo:"C"</summary>
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		[AllowHtml]
		[StringLength(254, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		/// <summary>Campo : "Date of birth" Tipo:"D"</summary>
		[Display(Name = "DATE_OF_BIRTH63058", ResourceType = typeof(Resources.Resources))]
		[DateAttribute("D")]
		public DateTime? ValDob { get; set; }

		/// <summary>Campo : "Time of birth" Tipo:"T"</summary>
		[Display(Name = "TIME_OF_BIRTH04797", ResourceType = typeof(Resources.Resources))]
		[StringLength(5, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DateAttribute("T")]
		public string ValTob { get; set; }

		/// <summary>Campo : "Year" Tipo:"N"</summary>
		[Display(Name = "YEAR61794", ResourceType = typeof(Resources.Resources))]
		[DisplayFormat( ApplyFormatInEditMode=true, DataFormatString="{0:N0}" )]
		[NumericAttribute(0)]
		public decimal? ValYear { get; set; }

		/// <summary>Campo : "Month" Tipo:"AN"</summary>
		[Display(Name = "MONTH46035", ResourceType = typeof(Resources.Resources))]
		[DataArray("Months", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal? ValMonth { get; set; }
		[JsonIgnore]
		public SelectList List_ValMonth { get; set; }

		/// <summary>Campo : "Created by" Tipo:"ON"</summary>
		[Display(Name = "CREATED_BY12292", ResourceType = typeof(Resources.Resources))]
		public string ValCreatusr { get; set; }

		/// <summary>Campo : "Created on" Tipo:"OD"</summary>
		[Display(Name = "CREATED_ON00051", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get; set; }

		/// <summary>Campo : "Modified by" Tipo:"EN"</summary>
		[Display(Name = "MODIFIED_BY02094", ResourceType = typeof(Resources.Resources))]
		public string ValModifusr { get; set; }

		/// <summary>Campo : "Modified on" Tipo:"ED"</summary>
		[Display(Name = "MODIFIED_ON31953", ResourceType = typeof(Resources.Resources))]
		[UIHint("HelpFixed")]
		[DateAttribute("ED")]
		public DateTime? ValModifdat { get; set; }


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

		public string ValCodperso { get; set; }

		public Perso_ViewModel() : base("FPERSO") { }

		public Perso_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base("FPERSO", currentNavigation, nestedForm) { }

		public Perso_ViewModel(Models.Perso row, NavigationContext currentNavigation, bool nestedForm = false) : base("FPERSO", row, currentNavigation, nestedForm) { }

		public Perso_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false, string[] fieldsToLoad = null) : this(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("perso", id);
			Model = Models.Perso.Find(id, "FPERSO", fieldsToQuery: fieldsToLoad);
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
			Models.Perso model = new Models.Perso() { Identifier = "FPERSO" };
			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			return UpdateConditions(Model);
		}

		public static StatusMessage UpdateConditions(Models.Perso model)
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

		public static StatusMessage DeleteConditions(Models.Perso model)
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

		public static StatusMessage ViewConditions(Models.Perso model)
		{
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		protected override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			Models.Perso model = Model;
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		public override void MapFromModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
 				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
 				ValName = ViewModelConversion.ToString(m.ValName);
 				ValIdentifi = ViewModelConversion.ToString(m.ValIdentifi);
 				ValGender = ViewModelConversion.ToString(m.ValGender);
 				ValEmail = ViewModelConversion.ToString(m.ValEmail);
 				ValDob = ViewModelConversion.ToDateTime(m.ValDob);
 				ValTob = ViewModelConversion.ToString(m.ValTob);
 				ValYear = ViewModelConversion.ToNumeric(m.ValYear);
 				ValMonth = ViewModelConversion.ToNumeric(m.ValMonth);
 				ValCreatusr = ViewModelConversion.ToString(m.ValCreatusr);
 				ValCreatdat = ViewModelConversion.ToDateTime(m.ValCreatdat);
 				ValModifusr = ViewModelConversion.ToString(m.ValModifusr);
 				ValModifdat = ViewModelConversion.ToDateTime(m.ValModifdat);
 				ValCodperso = ViewModelConversion.ToString(m.ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Perso) to ViewModel (Perso) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Perso m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Perso) to Model (Perso) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValIdentifi = ViewModelConversion.ToString(ValIdentifi);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValDob = ViewModelConversion.ToDateTime(ValDob);
				m.ValTob = ViewModelConversion.ToString(ValTob);
				m.ValYear = ViewModelConversion.ToNumeric(ValYear);
				m.ValMonth = ViewModelConversion.ToNumeric(ValMonth);
				m.ValCreatusr = ViewModelConversion.ToString(ValCreatusr);
				m.ValCreatdat = ViewModelConversion.ToDateTime(ValCreatdat);
				m.ValModifusr = ViewModelConversion.ToString(ValModifusr);
				m.ValModifdat = ViewModelConversion.ToDateTime(ValModifdat);
				m.ValCodperso = ViewModelConversion.ToString(ValCodperso);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Perso) to Model (Perso) - Error during mapping");
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
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), "FPERSO");
			}
			finally
			{
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					if (Model == null)
					{
						Model = new Models.Perso() { Identifier = "FPERSO" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("perso");
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

			Model.Identifier = "FPERSO";
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

		protected override void LoadDocumentsProperties(Models.Perso row)
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
				Model = Models.Perso.Find(Navigation.GetStrValue("perso"), "FPERSO");
				if (Model == null)
				{
					Model = new Models.Perso() { Identifier = "FPERSO" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("perso");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			//add characteristics
			Characs = new List<string>();
			LoadArrays();

// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL PERSO]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW PERSO]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

// USE /[MANUAL GQT VIEWMODEL_SAVE PERSO]/
		public override void Save()
		{

			try { Model = Models.Perso.Find(Navigation.GetStrValue("perso"), "FPERSO"); }
			finally { if (Model == null) Model = new Models.Perso() { Identifier = "FPERSO" }; }

			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY PERSO]/
		public override void Apply()
		{
			// Precisamos posicionar a ficha para não "estragar" o Qvalue do zzstate
			try { Model = Models.Perso.Find(Navigation.GetStrValue("perso"), "FPERSO"); }
			finally { if (Model == null) Model = new Models.Perso() { Identifier = "FPERSO" }; }

			base.Apply();
		}

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE PERSO]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY PERSO]/
		public override void Destroy(string id)
		{
			Model = Models.Perso.Find(id, "FPERSO");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		public void LoadArrays()
		{
			this.List_ValGender = new SelectList(
				ArrayGender.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValGender);
			this.List_ValMonth = new SelectList(
				ArrayMonths.GetDictionary().ToDictionary(p => p.Key, p => Helpers.Helpers.GetTextFromResources(p.Value)),
				"Key", "Value", this.ValMonth);
		}



		#region Charts
		#endregion


		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM PERSO]/
		#endregion
	}
}
