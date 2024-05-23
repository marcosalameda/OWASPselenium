using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using CSGenio.framework;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.ViewModels.Psw
{
	public class Defaultpsw_ViewModel : FormViewModel<Models.Psw>
	{
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public bool MsqActive { get; set; } = false;

		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[Display(Name = "UTILIZADOR52387", ResourceType = typeof(Resources.Resources))]
		public string ValNome { get; set; }

		[AllowHtml]
		[Required(ErrorMessageResourceName = "O_CAMPO__0__E_OBRIGA36687", ErrorMessageResourceType = typeof(Resources.Resources))]
		[DataType(DataType.Password)]
		[Display(Name = "PALAVRA_CHAVE39832", ResourceType = typeof(Resources.Resources))]
		public string ValPassword { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "EMAIL25170", ResourceType = typeof(Resources.Resources))]
		public string ValEmail { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "CONFIRMAR09808", ResourceType = typeof(Resources.Resources))]
		[System.Web.Mvc.Compare("ValPassword", ErrorMessageResourceName = "A_NOVA_PALAVRA_CHAVE41230", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ConfirmValPassword { get; set; }

		public string ValCodpsw { get; set; }

		#region ViewModel Pswnew (Password)

		public Defaultpsw_ViewModel() : base() { }

		public Defaultpsw_ViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base(currentNavigation, nestedForm) { }

		public Defaultpsw_ViewModel(Models.Psw row, NavigationContext currentNavigation, bool nestedForm = false) : base(currentNavigation, nestedForm)
		{
			if (row == null)
				throw new ModelNotFoundException("Model not found");
			Model = row;
			InitModel(new NameValueCollection(), false, false);
		}

		public Defaultpsw_ViewModel(NavigationContext currentNavigation, string id, bool nestedForm = false) : base(currentNavigation, nestedForm)
		{
			this.Navigation.SetValue("psw", id);
			Model = Models.Psw.Find(id, "FPSWNEW");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel(new NameValueCollection(), false, false);
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
			this.RoleToEdit = CSGenio.framework.Role.AUTHORIZED;
		}

		#region Mapper

		public override void MapFromModel(Models.Psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Psw) to ViewModel (Pswnew) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				ValNome = ViewModelConversion.ToString(m.ValNome);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValCodpsw = ViewModelConversion.ToString(m.ValCodpsw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Psw) to ViewModel (Pswnew) - Error during mapping");
				throw;
			}
		}

		public override void MapToModel(Models.Psw m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pswnew) to Model (Psw) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}
			try
			{
				m.ValNome = ViewModelConversion.ToString(ValNome);
				m.ValPasswordDecrypted = ViewModelConversion.ToString(ValPassword);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValCodpsw = ViewModelConversion.ToString(ValCodpsw);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Pswnew) to Model (Psw) - Error during mapping");
				throw;
			}
		}

		#endregion

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;
			// TODO: Deve ser substituido por search do CSGenioA
			try { Model = Models.Psw.Find(Navigation.GetStrValue("psw"), "FPSWNEW"); }
			finally
			{ // TODO: Remove FormMode ?
				if ((Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate))
				{
					if (Model == null)
					{
						Model = new Models.Psw() { Identifier = "FPSWNEW" };
						Model.klass.QPrimaryKey = Navigation.GetStrValue("psw");
					}
				}
				else
				{
					if (Model == null)
						throw new ModelNotFoundException("Model not found");
					else
						oldvalues = Model.klass;
				}
			}

			Model.Identifier = "FPSWNEW";
			InitModel(qs, lazyLoad, false);

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

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Psw.Find(Navigation.GetStrValue("psw"), "FPSWNEW");
				if (Model == null)
				{
					Model = new Models.Psw() { Identifier = "FPSWNEW" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("psw");
				}
				MapToModel(Model);
			}
			//add characteristics
			Characs = new List<string>();
		}

		// Loads all the information needed to present the form in insert mode
		public override void NewLoad()
		{
			this.LoadPartial(new NameValueCollection());

			//after the interface contextual fill, we give a last chance for the row to update internal formulas
			if (Model == null) // To não perder o Qvalue do ZZState executa inicialização do Model só quando o objeto está vazio.
				Model = new Models.Psw() { Identifier = "FPSWNEW" };
			MapToModel(Model);
			// Preencher Qvalues default
			Model.klass.fillValuesDefault(UserContext.Current.PersistentSupport, FunctionType.INS);
			// Preencher Qvalues default dos fields do form
			// Preencher operações internas
			Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
			MapFromModel(Model);
		}

		public override void Save()
		{
			try { Model = Models.Psw.Find(Navigation.GetStrValue("psw"), "FPSWNEW"); }
			finally { if (Model == null) Model = new Models.Psw() { Identifier = "FPSWNEW" }; }

			MapToModel(Model);
			this.flashMessage = Model.Save();
		}

		public override void Apply()
		{
			// Precisamos possicionar a ficha to não "estragar" o Qvalue do zzstate
			try { Model = Models.Psw.Find(Navigation.GetStrValue("psw"), "FPSWNEW"); }
			finally { if (Model == null) Model = new Models.Psw() { Identifier = "FPSWNEW" }; }

			base.Apply();
		}

		public override void Destroy(string id)
		{
			Model = Models.Psw.Find(id, "FPSWNEW");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		#endregion

		#region Required methods - Empties

		protected override void LoadDefaultValues() { /* Method intentionally left empty. */ }

		protected override StatusMessage EvaluateWriteConditions(bool isApply) => null;

		protected override void LoadDocumentsProperties(Models.Psw model) { /* Method intentionally left empty. */ }

		public override StatusMessage ViewConditions() => null;

		public override StatusMessage InsertConditions() => null;

		public override StatusMessage UpdateConditions() => null;

		public override StatusMessage DeleteConditions() => null;

		#endregion
	}
}
