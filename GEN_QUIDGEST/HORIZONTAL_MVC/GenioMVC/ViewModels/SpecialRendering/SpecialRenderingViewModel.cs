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
    public class SpecialRenderingViewModel : ViewModelBase
    {
        public bool editable { get; set; }

        /// <summary>
        /// Reference for the Model
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        private Models.Lstren Model;

        public string ValRenderizacao { get; set; }
        
        public string ValDisplayName { get; set; }

        /// <summary>Field : "Vis�vel" Tipo: "L"</summary>
        [Display(Name = "VISIVEL07768", ResourceType = typeof(Resources.Resources))]
        public bool ValVisivel { get; set; }

        /// <summary>Field : "Posi��o" Tipo: "N"</summary>
        [Display(Name = "ORDEM38897", ResourceType = typeof(Resources.Resources))]
        [NumericAttribute(0)]
        public decimal? ValPosicao { get; set; }

        /// <summary>Field : "Opera��o" Tipo: "N"</summary>
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

        public string ValCodlstren { get; set; }

        #region ViewModel Lstusr_ViewModel_ValLstrenForm

        #region Mapper
        public void MapFromModel()
        {
            MapFromModel(this.Model);
        }

        public void MapFromModel(Models.Lstren m)
        {
            if (m == null)
            {
                CSGenio.framework.Log.Error("Map Model (Lstren) to ViewModel (Lstusr_ViewModel_ValLstrenForm) - Model is a null reference");
                throw new ModelNotFoundException("Model not found");
            }
            try
            {
                ValCodlstren = ViewModelConversion.ToString(m.ValCodlstren);
                ValRenderizacao = ViewModelConversion.ToString(m.ValRenderizacao);
                ValVisivel = ViewModelConversion.ToLogic(m.ValVisivel);
                ValPosicao = ViewModelConversion.ToNumeric(m.ValPosicao);
                ValOperacao = ViewModelConversion.ToNumeric(m.ValOperacao);
                ValTipo = ViewModelConversion.ToNumeric(m.ValTipo);
                ValDisplayName = GetLocalizedRenderingName(ValRenderizacao);
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map Model (Lstren) to ViewModel (Lstusr_ViewModel_ValLstrenForm) - Error during mapping");
                throw;
            }
        }

        public void MapToModel(Models.Lstren m)
        {
            if (m == null)
            {
                CSGenio.framework.Log.Error("Map ViewModel (Lstusr_ViewModel_ValLstrenForm) to Model (Lstren) - Model is a null reference");
                throw new ModelNotFoundException("Model not found");
            }
            try
            {
                m.ValCodlstren = ViewModelConversion.ToString(ValCodlstren);
                m.ValRenderizacao = ViewModelConversion.ToString(ValRenderizacao);
                m.ValVisivel = ViewModelConversion.ToLogic(ValVisivel);
                m.ValPosicao = ViewModelConversion.ToNumeric(ValPosicao);
                m.ValOperacao = ViewModelConversion.ToNumeric(ValOperacao);
                m.ValTipo = ViewModelConversion.ToNumeric(ValTipo);
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map ViewModel (Lstusr_ViewModel_ValLstrenForm) to Model (Lstren) - Error during mapping");
                throw;
            }
        }
        #endregion

        public SpecialRenderingViewModel() { }

        public SpecialRenderingViewModel(NavigationContext currentNavigation)
        {
            this.Navigation = currentNavigation;
        }

        public SpecialRenderingViewModel(Models.Lstren row, NavigationContext currentNavigation, bool nestedForm = false)
        {
            this.Navigation = currentNavigation;
            this.NestedForm = nestedForm;
            row.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.MapFromModel(row);
            LoadDocumentsProperties(row);
            LoadPartial(new NameValueCollection());
        }

        public void Load()
        {
            Load(new NameValueCollection(), false, false);
        }

        public void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false)
        {
            this.editable = editable;
            // TODO: Depois da implementação do suporte pesistente deve ser substituido por search do CSGenioA
            this.Model = null;
            //TODO: Change the next code after implementation of PersistentSupport
            try { this.Model = Models.Lstren.Find(Navigation.GetStrValue("Lstren"), "FLstusr_ViewModel"); }
            finally
            { // TODO: Remove FormMode ?
                if (this.Model == null && (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate))
                {
                    this.Model = new Models.Lstren();
                    this.Model.klass.QPrimaryKey = Navigation.GetStrValue("Lstren");
                }
            }

            if (Model == null)
				throw new ModelNotFoundException("Model not found");

            this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.MapFromModel(this.Model);
            LoadDocumentsProperties(this.Model);
            LoadPartial(qs, ajaxRequest);
        }

        public void LoadDocumentsProperties(GenioMVC.Models.Lstren row) { }

        public void LoadPartial(NameValueCollection qs, bool ajaxRequest = false)
        {
            // MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
            if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
            {
                this.Model = new Models.Lstren();
                this.MapToModel(this.Model);
                LoadDocumentsProperties(this.Model);
            }
        }

        public void New()
        {
            this.editable = true;
            this.Model = new Models.Lstren();
            this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level);
            this.Model.New("Lstusr_ViewModel_ValLstrenForm");
            // Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
            this.Model.LoadKeysFormHistory(this.Navigation, this.Navigation.CurrentLevel.Level, false);
            this.MapFromModel(this.Model);
        }

        public void NewLoad()
        {
            this.LoadPartial(new NameValueCollection());

            //after the interface contextual fill, we give a last chance for the row to update internal formulas
            this.Model = new Models.Lstren();
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
            try { this.Model = Models.Lstren.Find(Navigation.GetStrValue("Lstren"), "FLstusr_ViewModel"); }
            finally { if (this.Model == null) this.Model = new Models.Lstren(); }
            this.MapToModel(this.Model);
            this.Model.Save();
            //this.MapFromModel(this.Model);
        }

        public void Apply()
        {
            this.Model = null;
            try { this.Model = Models.Lstren.Find(Navigation.GetStrValue("Lstren"), "FLstusr_ViewModel"); }
            finally { if (this.Model == null) this.Model = new Models.Lstren(); }
            this.MapToModel(this.Model);
            this.Model.Apply();
            this.MapFromModel(this.Model);
        }

        public void Duplicate(string id)
        {
            this.Model = new Models.Lstren();
            this.Model.Duplicate(id);
            this.MapFromModel(this.Model);
        }

        public void Destroy()
        {
            this.Model = Models.Lstren.Find(this.ValCodlstren, "FLstusr_ViewModel");
            this.Model.Destroy();
        }

        public Dictionary<string, string> GetLocalizedRenderingNames() 
        {
            var columns = new Dictionary<string, string>() {
                {"LIST", Resources.Resources.LISTA13474},
                {"CARDS", Resources.Resources.CARTOES27587},
                {"CAROUSEL", Resources.Resources.CARROSSEL41899},
                {"CHART", Resources.Resources.GRAFICO38823},
            };
			
            return columns;
        }

        public string GetLocalizedRenderingName(string id)
        {
            Dictionary<string, string> localizedRenderingNames = GetLocalizedRenderingNames();

            if (localizedRenderingNames.ContainsKey(id))
                return localizedRenderingNames[id];
            return String.Empty;
        }
        #endregion
    }
}
