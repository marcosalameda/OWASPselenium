using System;
using System.Collections.Generic;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Data;
using System.Collections;
using System.Xml.XPath;
using System.Linq;
using CSGenio.business;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.IO;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
    /// <summary>
    /// Interface ListPropertiesViewModel
    /// </summary>
    public class ListPropertiesViewModel : ViewModelBase
    {
        /// <summary>
        /// Class to store information on Email Signature to be used when sending messages through email
        /// </summary>
		/// <summary>Campo : "PK da tabela" Tipo: "+" Formula:  ""</summary>
        public string ValCodlstusr { get; set; } //PK
        public string ValCodpsw { get; set; } //PK

        public string ValIdlist { get; set; } //List ID

        [Required]
        [Display(Name = "Nome da Lista")]
        public string ValDescric { get; set; } //List name

        [Display(Name = "Módulo")]
        public string ValModulo { get; set; } //Module

        [Display(Name = "Sistema")]
        public string ValSistema { get; set; } //Sistem

        [Display(Name = "Coluna de ordenação")]
        public int ValOrdercol { get; set; } //#Order column

        [Display(Name = "Tipo de ordenação")]
        public int ValOrdertype { get; set; } //Order type

        [Display(Name = "Data")]
        public DateTime ValData { get; set; } //Date

        public int ValZzstate { get; set; }

        new public string FormMode { get; set; }
        public string ResultMsg { get; set; }
        
        public void MapToModel(CSGenioAlstusr m)
        {
            if (m == null)
            {
                CSGenio.framework.Log.Error("Map ViewModel (ListPropertiesViewModel) to Model (CSGenioAlstusr) - Model is a null reference");
                throw new Exception("Model not found");
            }
            try
            {

                m.ValCodlstusr = DBConversion.ToString(ValCodlstusr);
                m.ValCodpsw = DBConversion.ToString(ValCodpsw);
                m.ValIdlist = DBConversion.ToString(ValIdlist);
                m.ValDescric = DBConversion.ToString(ValDescric);
                m.ValModulo = DBConversion.ToString(ValModulo);
                m.ValSistema = DBConversion.ToString(ValSistema);
                m.ValOrdercol = DBConversion.ToInteger(ValOrdercol);
                m.ValOrdertype = DBConversion.ToInteger(ValOrdertype);
                m.ValData = DBConversion.ToDateTime(ValData);
                m.ValZzstate = DBConversion.ToInteger(ValZzstate);
                
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map ViewModel (ListPropertiesViewModel) to Model (CSGenioAlstusr) - Error during mapping");
                throw;
            }
        }

        public void MapFromModel(CSGenioAlstusr m)
        {
            if (m == null)
            {
                CSGenio.framework.Log.Error("Map ViewModel (ListPropertiesViewModel) to Model (CSGenioAlstusr) - Model is a null reference");
                throw new Exception("Model not found");
            }
            try
            {
                ValCodlstusr = DBConversion.ToString(m.ValCodlstusr);
                ValCodpsw = DBConversion.ToString(m.ValCodpsw);
                ValIdlist = DBConversion.ToString(m.ValIdlist);
                ValDescric = DBConversion.ToString(m.ValDescric);
                ValModulo = DBConversion.ToString(m.ValModulo);
                ValSistema = DBConversion.ToString(m.ValSistema);
                ValOrdercol = DBConversion.ToInteger(m.ValOrdercol);
                ValOrdertype = DBConversion.ToInteger(m.ValOrdertype);
                ValData = DBConversion.ToDateTime(m.ValData);
                ValZzstate = DBConversion.ToInteger(m.ValZzstate);
            }
            catch (Exception)
            {
                CSGenio.framework.Log.Error("Map ViewModel (ListPropertiesViewModel) to Model (CSGenioAlstusr) - Error during mapping");
                throw;
            }
        }
        
    }


}

