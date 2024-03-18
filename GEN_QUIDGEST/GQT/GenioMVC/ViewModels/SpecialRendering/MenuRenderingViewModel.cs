using System;
using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence.GenericQuery;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Collections.Specialized;
using System.Web.Mvc;
using Quidgest.Persistence;

namespace GenioMVC.ViewModels
{
    public class MenuRenderingViewModel : ViewModelBase
    {
        [Newtonsoft.Json.JsonProperty("Table")]
        public TablePartial<GenioMVC.Models.Lstren> lstren { get; set; }
        public string ValCodlstusr { get; set; }

        public MenuRenderingViewModel(NavigationContext current_navigation)
        {
            this.Navigation = current_navigation;
        }

        public void Load(int numberListItems, bool ajaxRequest = false)
        {
            Load(numberListItems, new NameValueCollection(), ajaxRequest);
        }

        public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false)
        {
            ListingMVC<CSGenioAlstren> listing = null;
            CriteriaSet conditions = null;
            Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
        }

        public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlstren> Qlisting, ref CriteriaSet conditions)
        {
            //TODO: Tem um problema quando saí­mos de um form e voltamos ao dbedit e mudamos de página.
            //como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
            if (ajaxRequest)
                this.Navigation.SetValue("requestValues" + "lstusr_Vallstren", requestValues);
            else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "lstusr_Vallstren"))
                requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "lstusr_Vallstren");

            lstren = new TablePartial<GenioMVC.Models.Lstren>();


            CriteriaSet lstusr___pseudlstren_Conds = conditions ?? CriteriaSet.And();

            bool tableReload = true;

            lstren.SetFilters(bool.Parse(requestValues["Vallstren_tableFilters"] ?? "false"), false);

            CriteriaSet search_filters = ProcessSearchFilters(lstren, GetSearchColumns(), requestValues, "Vallstren_");
            lstusr___pseudlstren_Conds.SubSets.Add(search_filters);

            CriteriaSet subfilters = CriteriaSet.Or();

            lstusr___pseudlstren_Conds.SubSets.Add(subfilters);

            lstusr___pseudlstren_Conds.Equal(CSGenioAlstren.FldCodlstusr, this.ValCodlstusr);

            var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pVallstren"])) ? int.Parse(requestValues["pVallstren"]) : 1;
            var columnSort = GetRequestSort(this.lstren, "sVallstren", "dVallstren", requestValues, "lstren");

            List<ColumnSort> sorts = new List<ColumnSort>();
            if (columnSort != null)
            {
                sorts.Add(columnSort);
            }
            else
                sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlstren.FldPosicao), SortOrder.Ascending));

            FieldRef[] fields = new FieldRef[] { CSGenioAlstren.FldCodlstren, CSGenioAlstren.FldZzstate, CSGenioAlstren.FldRenderizacao, CSGenioAlstren.FldVisivel, CSGenioAlstren.FldPosicao, CSGenioAlstren.FldOperacao, CSGenioAlstren.FldTipo, CSGenioAlstren.FldCodlstusr };

            if (isToExport)
            {
                User u = UserContext.Current.User;

                //EPH
                lstusr___pseudlstren_Conds = Models.Lstren.AddEPH<CSGenioAlstren>(ref u, lstusr___pseudlstren_Conds, "IBL_lstusr___PSEUDlstren_");
                ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioAlstren.FldCodlstren), SortOrder.Ascending);
                if (sorts != null && !sorts.Exists(x => x == sortPk))
                    sorts.Add(sortPk);

                // (13/06/2017) - Export only records with ZZState == 0
                lstusr___pseudlstren_Conds.Equal(CSGenioAlstren.FldZzstate, 0);

                Qlisting = new ListingMVC<CSGenioAlstren>(fields, sorts, (pageNumber - 1) * numberListItems, numberListItems, false, u, false);
                
                conditions = lstusr___pseudlstren_Conds;
                this.Navigation.SetValue("CriteriaSet_" + Qlisting.identifier, conditions);
                return;
            }

            // Limitation by Zzstate
            if (!Navigation.checkFormMode("lstren", FormMode.New)) // TODO: Check in Duplicate mode
                lstusr___pseudlstren_Conds = extendWithZzstateCondition(lstusr___pseudlstren_Conds, CSGenioAlstren.FldZzstate, null);

            if (tableReload)
            {

                var QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lstren");
                Navigation.DestroyEntry("QMVC_POS_RECORD_lstren");
                if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
                {
                    CriteriaSet m_PagingPosEPHs = null; User u = UserContext.Current.User;
                    m_PagingPosEPHs = Models.Lstren.AddEPH<CSGenioAlstren>(ref u, m_PagingPosEPHs, "IBL_lstusr___PSEUDlstren_");
                    var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAlstren.GetInformation(), QMVC_POS_RECORD, sorts, lstusr___pseudlstren_Conds, m_PagingPosEPHs);
                    if (m_iCurPag != -1)
                    {
                        pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
                        lstren.FocusOnRecord = QMVC_POS_RECORD;
                    }
                }

                ListingMVC<CSGenioAlstren> listing = Models.ModelBase.Where<CSGenioAlstren>(false, lstusr___pseudlstren_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_lstusr___PSEUDlstren_");
                this.Navigation.SetValue("CriteriaSet_" + listing.identifier, lstusr___pseudlstren_Conds);
                lstren.Elements = Maplstusr_Vallstren(listing);
                lstren.Identifier = "IBL_lstusr___PSEUDlstren_";
                lstren.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
            }
        }

        public List<TableSearchColumn> GetSearchColumns()
        {
            List<TableSearchColumn> list = new List<TableSearchColumn>();

            list.Add(new TableSearchColumn("ValRenderizacao", CSGenioAlstren.FldRenderizacao, typeof(string)));
            list.Add(new TableSearchColumn("ValVisivel", CSGenioAlstren.FldVisivel, typeof(bool)));
            list.Add(new TableSearchColumn("ValPosicao", CSGenioAlstren.FldPosicao, typeof(decimal?)));
            list.Add(new TableSearchColumn("ValOperacao", CSGenioAlstren.FldOperacao, typeof(decimal?)));
            list.Add(new TableSearchColumn("ValTipo", CSGenioAlstren.FldTipo, typeof(decimal?)));
            return list;
        }

        private List<Models.Lstren> Maplstusr_Vallstren(ListingMVC<CSGenioAlstren> Qlisting)
        {
            int i = 0;
            var Elements = new List<Models.Lstren>();
            foreach (var row in Qlisting.Rows)
            {
                if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
                    break;
                Elements.Add(Maplstusr_Vallstren(row));
                i++;
            }
            return Elements;
        }

        private Models.Lstren Maplstusr_Vallstren(CSGenioAlstren row)
        {
            var model = new Models.Lstren(true);
            if (row == null) return model;
            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "lstren":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    default: break;
                }
            }
            return model;
        }

    }
}
