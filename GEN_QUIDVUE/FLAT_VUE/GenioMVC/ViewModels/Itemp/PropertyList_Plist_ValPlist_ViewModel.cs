
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Itemp
{
    public class PropertyList_Plist_ValPlist_ViewModel : PropertyList<GenioMVC.Models.Itemp>
    {
        public List<PropertyListProperty> Fields { get; set; }

        private UserContext m_userContext;

		public string ValTxtprop { get; set; }
		public string ValMultprop { get; set; }
		public string ValDateprop { get; set; }
		public string ValBoolprop { get; set; }
		public string ValNumprop { get; set; }
		public string ValEnumprop { get; set; }

        public PropertyList_Plist_ValPlist_ViewModel() { }

        public PropertyList_Plist_ValPlist_ViewModel (UserContext userContext) 
        {
            m_userContext = userContext;
        }

        public override void Init(UserContext userContext)
        {
            m_userContext = userContext;
            MapFromModels();
        }

        public override CrudViewModelValidationResult Validate()
        {
            CrudViewModelFieldValidator validator = new(m_userContext.User.Language);
            validator.Required("ValTxtprop", Resources.Resources.TEXT_PROP21994, ValTxtprop);

            return validator.GetResult();
        }

        /// <summary>
        /// Maps the properties from the list of models that to the view model
        /// </summary>
        public override void MapFromModels()
        {
            foreach(var property in Fields)
            {
                switch(property.Id)
                {
                    case "ValTxtprop":
                        ValTxtprop = property.Value;
                        break;
                    case "ValMultprop":
                        ValMultprop = property.Value;
                        break;
                    case "ValDateprop":
                        ValDateprop = property.Value;
                        break;
                    case "ValBoolprop":
                        ValBoolprop = property.Value;
                        break;
                    case "ValNumprop":
                        ValNumprop = property.Value;
                        break;
                    case "ValEnumprop":
                        ValEnumprop = property.Value;
                        break;
                }
            }
        }

        public void SetRows()
        {
            List<GenioMVC.Models.Itemp> rows = new List<GenioMVC.Models.Itemp>();

            foreach (var property in Fields)
            {
                GenioMVC.Models.Itemp model = new GenioMVC.Models.Itemp(m_userContext);

                // If its a new property insert a new record, otherwise update
                if(String.IsNullOrEmpty(property.RowId))
                {
                    model.New();
                }
                else
                {
                    model.ValCoditemp = property.RowId;
                }				

                model.LoadKeysFromHistory(m_userContext.CurrentNavigation, m_userContext.CurrentNavigation.CurrentLevel.Level);
                model.ValPropid = property.Name;
                model.ValProptype = property.Type;
                model.ValPropval = property.Value;
                rows.Add(model);
            }

            this.propertyListRows = rows;
        }
    }

}
