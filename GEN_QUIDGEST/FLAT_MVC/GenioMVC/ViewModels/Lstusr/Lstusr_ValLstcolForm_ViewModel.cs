using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CSGenio.business;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using System.Collections.Specialized;
using System.Globalization;
using System.Data;
using Quidgest.Persistence;
using CSGenio.framework;

namespace GenioMVC.ViewModels.Lstusr
{
    public class Lstusr_ValLstcolForm_ViewModel : ViewModelBase
    {
        public bool editable { get; set; }

        /// <summary>
        /// Reference for the Model
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        private Models.Lstcol Model;

        /// <summary>Field : "Tabela" Tipo: "C"</summary>
        [Display(Name = "TABELA44049", ResourceType = typeof(Resources.Resources))]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValTabela { get; set; }

        /// <summary>Field : "Alias" Tipo: "C"</summary>
        [Display(Name = "NOME_DA_COLUNA14566", ResourceType = typeof(Resources.Resources))]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValAlias { get; set; }

        /// <summary>Field : "Campo" Tipo: "C"</summary>
        [Display(Name = "CAMPO46284", ResourceType = typeof(Resources.Resources))]
		[StringLength(50, ErrorMessageResourceName = "O_COMPRIMENTO_MAXIMO21747", ErrorMessageResourceType = typeof(Resources.Resources))]
		public string ValCampo { get; set; }

        /// <summary>Field : "Visível" Tipo: "L"</summary>
        [Display(Name = "VISIVEL07768", ResourceType = typeof(Resources.Resources))]
		public bool ValVisivel { get; set; }

        /// <summary>Field : "Posição" Tipo: "N"</summary>
        [Display(Name = "ORDEM38897", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public decimal? ValPosicao { get; set; }

        /// <summary>Field : "Operação" Tipo: "N"</summary>
        [Display(Name = "OPERACAO29482", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public decimal? ValOperacao { get; set; }

        /// <summary>Field : "Tipo" Tipo: "N"</summary>
        [Display(Name = "TIPO55111", ResourceType = typeof(Resources.Resources))]
		[NumericAttribute(0)]
		public decimal? ValTipo { get; set; }


        #region Foreign Keys
        public string ValCodLstusr_ViewModel { get; set; }
        #endregion

        public string ValCodlstcol { get; set; }

        #region ViewModel Lstusr_ViewModel_ValLstcolForm

        #region Mapper
        public void MapFromModel()
        {
            MapFromModel(this.Model);
        }

        public void MapFromModel(Models.Lstcol m)
        {
            if (m == null)
            {
                CSGenio.framework.Log.Error("Map Model (Lstcol) to ViewModel (Lstusr_ViewModel_ValLstcolForm) - Model is a null reference");
                throw new ModelNotFoundException("Model not found");
            }
            try
            {
                ValCodlstcol = ViewModelConversion.ToString(m.ValCodlstcol);
                ValTabela = ViewModelConversion.ToString(m.ValTabela);
                ValAlias = ViewModelConversion.ToString(m.ValAlias);
                ValCampo = ViewModelConversion.ToString(m.ValCampo);
                ValVisivel = ViewModelConversion.ToLogic(m.ValVisivel);
                ValPosicao = ViewModelConversion.ToNumeric(m.ValPosicao);
                ValOperacao = ViewModelConversion.ToNumeric(m.ValOperacao);
                ValTipo = ViewModelConversion.ToNumeric(m.ValTipo);
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map Model (Lstcol) to ViewModel (Lstusr_ViewModel_ValLstcolForm) - Error during mapping");
                throw;
            }
        }

        public void MapToModel(Models.Lstcol m)
        {
            if(m == null)
            {
                CSGenio.framework.Log.Error("Map ViewModel (Lstusr_ViewModel_ValLstcolForm) to Model (Lstcol) - Model is a null reference");
                throw new ModelNotFoundException("Model not found");
            }
            try
            {
                m.ValCodlstcol = ViewModelConversion.ToString(ValCodlstcol);
                m.ValTabela = ViewModelConversion.ToString(ValTabela);
                m.ValAlias = ViewModelConversion.ToString(ValAlias);
                m.ValCampo = ViewModelConversion.ToString(ValCampo);
                m.ValVisivel = ViewModelConversion.ToLogic(ValVisivel);
                m.ValPosicao = ViewModelConversion.ToNumeric(ValPosicao);
                m.ValOperacao = ViewModelConversion.ToNumeric(ValOperacao);
                m.ValTipo = ViewModelConversion.ToNumeric(ValTipo);
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map ViewModel (Lstusr_ViewModel_ValLstcolForm) to Model (Lstcol) - Error during mapping");
                throw;
            }
        }
        #endregion

        public Lstusr_ValLstcolForm_ViewModel() { }

        public Lstusr_ValLstcolForm_ViewModel(NavigationContext currentNavigation)
        {
            this.Navigation = currentNavigation;
        }

        public Lstusr_ValLstcolForm_ViewModel(Models.Lstcol row, NavigationContext currentNavigation, bool nestedForm = false)
        {
            this.Navigation = currentNavigation;
            this.NestedForm = nestedForm;
            row.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.MapFromModel(row);
            LoadDocumentsProperties(row);
            LoadPartial(new NameValueCollection());
        }

        public void Load() {
            Load(new NameValueCollection(), false, false);
        }

        public void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false)
        {
            this.editable = editable;
			// TODO: Depois da implementação do suporte pesistente deve ser substituido por search do CSGenioA
            this.Model = null;
			//TODO: Change the next code after implementation of PersistentSupport
			try { this.Model = Models.Lstcol.Find(Navigation.GetStrValue("Lstcol"), "FLstusr_ViewModel"); }
            finally { // TODO: Remove FormMode ?
                if (this.Model == null && (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate))
                {
					this.Model = new Models.Lstcol();
					this.Model.klass.QPrimaryKey = Navigation.GetStrValue("Lstcol");
                }
            }

            if (Model == null)
				throw new ModelNotFoundException("Model not found");

            this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.MapFromModel(this.Model);
            LoadDocumentsProperties(this.Model);
            LoadPartial(qs, ajaxRequest);
        }

        public void LoadDocumentsProperties(GenioMVC.Models.Lstcol row) { }

        public void LoadPartial(NameValueCollection qs, bool ajaxRequest = false)
        {
            // MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
            if (System.Web.HttpContext.Current.Request.HttpMethod == "POST") {
                this.Model = new Models.Lstcol();
                this.MapToModel(this.Model);
                LoadDocumentsProperties(this.Model);
            }
        }

        public void New()
        {
            this.editable = true;
            this.Model = new Models.Lstcol();
            this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.Model.New("Lstusr_ViewModel_ValLstcolForm");
			// Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
			this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level, false);
            this.MapFromModel(this.Model);
		}

        public void NewLoad()
        {
            this.LoadPartial(new NameValueCollection());

			//after the interface contextual fill, we give a last chance for the row to update internal formulas
            this.Model = new Models.Lstcol();
            this.MapToModel(this.Model);
            // Preencher Qvalues default
            this.Model.klass.fillValuesDefault(UserContext.Current.PersistentSupport, FunctionType.INS);
            // Preencher operações internas
            this.Model.klass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
            this.MapFromModel(this.Model);
        }

        public void Save()
        {
            this.Model = null;
            try { this.Model = Models.Lstcol.Find(Navigation.GetStrValue("Lstcol"), "FLstusr_ViewModel"); }
            finally { if(this.Model == null) this.Model = new Models.Lstcol(); }
            this.MapToModel(this.Model);
            this.Model.Save();
            //this.MapFromModel(this.Model);
        }

        public void Apply()
        {
            this.Model = null;
            try { this.Model = Models.Lstcol.Find(Navigation.GetStrValue("Lstcol"), "FLstusr_ViewModel"); }
            finally { if(this.Model == null) this.Model = new Models.Lstcol(); }
            this.MapToModel(this.Model);
            this.Model.Apply();
            this.MapFromModel(this.Model);
        }

        public void Duplicate(string id)
        {
            this.Model = new Models.Lstcol();
            this.Model.Duplicate(id);
            this.MapFromModel(this.Model);
        }

        public void Destroy()
        {
            this.Model = Models.Lstcol.Find(this.ValCodlstcol, "FLstusr_ViewModel");
            this.Model.Destroy();
        }

        #endregion
    }
}
