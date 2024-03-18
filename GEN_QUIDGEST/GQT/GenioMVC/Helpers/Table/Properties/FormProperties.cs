using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers.Table.Properties
{
    public class FormProperties
    {
        public string HelpForm { get; private set; }
        public bool OpenInPopup { get; private set; }
        public bool RepeatInsertion { get; private set; }

        /// <summary>
        /// Allows to add additional html attributes to the CRUD buttons
        /// </summary>
        public object ButtonsHttpAttributes { get; private set; }

        public FormProperties(string helpForm, bool openInPopup, bool repeatInsertion, object btnsAttributes = null)
        {
            this.HelpForm = helpForm;
            this.OpenInPopup = openInPopup;
            this.RepeatInsertion = repeatInsertion;

            this.ButtonsHttpAttributes = btnsAttributes;
        }
    }
}