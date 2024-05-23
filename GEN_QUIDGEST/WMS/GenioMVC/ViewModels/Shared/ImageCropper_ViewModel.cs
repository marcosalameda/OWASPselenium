using CSGenio.framework;
using GenioMVC.Models.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.ViewModels
{
    public class ImageCropper_ViewModel : ViewModelBase
    {
        public string Key { get; set; }

        public string modelname { get; set; }

        public string fldname { get; set; }


        public string FormName { get; set; }

        public string FieldIdentifier { get; set; }

        public ImageCropper_ViewModel(string Key, string modelname, string fldname, string identifier, string Formname, string FieldId)
        {
            this.Key = Key;
            this.modelname = modelname;
            this.fldname = fldname;
            this.Identifier = identifier;
            this.FormName = Formname;
            this.FieldIdentifier = FieldId;
        }
    }
}
