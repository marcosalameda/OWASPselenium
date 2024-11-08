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

namespace GenioMVC.ViewModels.Lstusr
{
	public class Lstusr_ValLstcol_ViewModel : ViewModelBase
	{
        [Newtonsoft.Json.JsonProperty("Table")]
		public TablePartial<GenioMVC.Models.Lstcol> Menu { get; set; }

		//[Display(Name = "Tabela")]
		/// <summary>Field : "Tabela" Tipo: "C"</summary>
		//[Display(Name = "Alias")]
		/// <summary>Field : "Alias" Tipo: "C"</summary>
		//[Display(Name = "Campo")]
		/// <summary>Field : "Campo" Tipo: "C"</summary>
		//[Display(Name = "Visível")]
		/// <summary>Field : "Visivel" Tipo: "L"</summary>
		//[Display(Name = "Posição")]
		/// <summary>Field : "Posicao" Tipo: "N"</summary>
		//[Display(Name = "Operação")]
		/// <summary>Field : "Operacao" Tipo: "N"</summary>
		//[Display(Name = "Tipo")]
		/// <summary>Field : "Tipo" Tipo: "N"</summary>

		public string ValCodlstusr { get; set; }

		public Lstusr_ValLstcol_ViewModel(NavigationContext current_navigation)
		{
			this.Navigation = current_navigation;
		}

        public void LoadToExport(out ListingMVC<CSGenioAlstcol> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
        {
            listing = null;
            conditions = null;
            columns = new List<Exports.QColumn>() {
                new Exports.QColumn(CSGenioAlstcol.FldTabela, FieldType.TEXTO, Resources.Resources.TABELA44049, 30, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldAlias, FieldType.TEXTO, Resources.Resources.NOME_DA_COLUNA14566, 30, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldCampo, FieldType.TEXTO, Resources.Resources.CAMPO46284, 30, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldVisivel, FieldType.LOGICO, Resources.Resources.VISIVEL07768, 1, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldPosicao, FieldType.NUMERO, Resources.Resources.ORDEM38897, 3, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldOperacao, FieldType.NUMERO, Resources.Resources.OPERACAO29482, 3, 0, true),
                new Exports.QColumn(CSGenioAlstcol.FldTipo, FieldType.NUMERO, Resources.Resources.TIPO55111, 3, 0, true),
             };

            Load(-1, requestValues, ajaxRequest, true, ref listing, ref conditions);
			
        }
	
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

        public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false)
        {
            ListingMVC<CSGenioAlstcol> listing = null;
            CriteriaSet conditions = null;
            Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
        }

		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAlstcol> Qlisting, ref CriteriaSet conditions)
		{
			//TODO: Tem um problema quando saí­mos de um form e voltamos ao dbedit e mudamos de página.
            //como não é devolvido to a view o text pesquisado, ao mudar de página assume que o Qfield está a vazio
			if (ajaxRequest)
                this.Navigation.SetValue("requestValues" + "lstusr_Vallstcol", requestValues);
            else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "lstusr_Vallstcol"))
                requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "lstusr_Vallstcol");

			Menu = new TablePartial<GenioMVC.Models.Lstcol>();


			CriteriaSet lstusr___pseudlstcol_Conds = conditions ?? CriteriaSet.And();

			bool tableReload = true;

			Menu.SetFilters(bool.Parse(requestValues["Vallstcol_tableFilters"] ?? "false"), false);

			CriteriaSet search_filters = ProcessSearchFilters(Menu, GetSearchColumns(), requestValues, "Vallstcol_");
			lstusr___pseudlstcol_Conds.SubSets.Add(search_filters);

			CriteriaSet subfilters = CriteriaSet.Or();
 
			lstusr___pseudlstcol_Conds.SubSets.Add(subfilters);

			lstusr___pseudlstcol_Conds.Equal(CSGenioAlstcol.FldCodlstusr, this.ValCodlstusr);
 
            var pageNumber = (ajaxRequest && !String.IsNullOrEmpty(requestValues["pVallstcol"])) ? int.Parse(requestValues["pVallstcol"]) : 1;
            var columnSort = GetRequestSort(this.Menu, "sVallstcol", "dVallstcol", requestValues, "lstcol");

            List<ColumnSort> sorts = new List<ColumnSort>();
            if(columnSort != null)
            {
                sorts.Add(columnSort);
            }
            else
                sorts.Add(new ColumnSort(new ColumnReference(CSGenioAlstcol.FldPosicao), SortOrder.Ascending));

				FieldRef[] fields = new FieldRef[] { CSGenioAlstcol.FldCodlstcol, CSGenioAlstcol.FldZzstate, CSGenioAlstcol.FldTabela, CSGenioAlstcol.FldAlias, CSGenioAlstcol.FldCampo, CSGenioAlstcol.FldVisivel, CSGenioAlstcol.FldPosicao, CSGenioAlstcol.FldOperacao, CSGenioAlstcol.FldTipo, CSGenioAlstcol.FldCodlstusr };

            if (isToExport)
            {
                User u = UserContext.Current.User;

                //EPH
                lstusr___pseudlstcol_Conds = Models.Lstcol.AddEPH<CSGenioAlstcol>(ref u, lstusr___pseudlstcol_Conds, "IBL_lstusr___PSEUDlstcol_");
                ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioAlstcol.FldCodlstcol), SortOrder.Ascending);
                if (sorts != null && !sorts.Exists(x => x == sortPk))
                    sorts.Add(sortPk);

                // (13/06/2017) - Export only records with ZZState == 0
                lstusr___pseudlstcol_Conds.Equal(CSGenioAlstcol.FldZzstate, 0);

                Qlisting = new ListingMVC<CSGenioAlstcol>(fields, sorts, (pageNumber - 1) * numberListItems, numberListItems, false, u,false);
                
                conditions = lstusr___pseudlstcol_Conds;
                this.Navigation.SetValue("CriteriaSet_" + Qlisting.identifier, lstusr___pseudlstcol_Conds);
                return;
            }

            // Limitation by Zzstate
            if(!Navigation.checkFormMode("lstcol", FormMode.New)) // TODO: Check in Duplicate mode
                lstusr___pseudlstcol_Conds = extendWithZzstateCondition(lstusr___pseudlstcol_Conds, CSGenioAlstcol.FldZzstate, null);

            if(tableReload) {

                var QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_lstcol");
                Navigation.DestroyEntry("QMVC_POS_RECORD_lstcol");
                if(!string.IsNullOrEmpty(QMVC_POS_RECORD))
                {  
					CriteriaSet m_PagingPosEPHs = null; User u = UserContext.Current.User;
                    m_PagingPosEPHs = Models.Lstcol.AddEPH<CSGenioAlstcol>(ref u, m_PagingPosEPHs, "IBL_lstusr___PSEUDlstcol_");
                    var m_iCurPag = UserContext.Current.PersistentSupport.getPagingPos(CSGenioAlstcol.GetInformation(), QMVC_POS_RECORD, sorts, lstusr___pseudlstcol_Conds, m_PagingPosEPHs);
                    if(m_iCurPag != -1)
                    {
                        pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
                        Menu.FocusOnRecord = QMVC_POS_RECORD;
                    }
                }

                ListingMVC<CSGenioAlstcol> listing = Models.ModelBase.Where<CSGenioAlstcol>(false, lstusr___pseudlstcol_Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "IBL_lstusr___PSEUDlstcol_");
                this.Navigation.SetValue("CriteriaSet_" + listing.identifier, lstusr___pseudlstcol_Conds);
				Menu.Elements = Maplstusr_Vallstcol(listing);

				Menu.Identifier = "IBL_lstusr___PSEUDlstcol_";

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
                {
                    element.Identifier = "IBL_lstusr___PSEUDlstcol_";
                }

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);
			}
		}

        private List<Models.Lstcol> Maplstusr_Vallstcol(ListingMVC<CSGenioAlstcol> Qlisting)
        {
            int i = 0;
            var Elements = new List<Models.Lstcol>();
            foreach (var row in Qlisting.Rows)
            {
                if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
                    break;
                Elements.Add(Maplstusr_Vallstcol(row));
                i++;
            }
            return Elements;
        }

        private Models.Lstcol Maplstusr_Vallstcol(CSGenioAlstcol row)
        {
            var model = new Models.Lstcol(true);
            if (row == null) return model;
            foreach (RequestedField Qfield in row.Fields.Values)
            {
                switch (Qfield.Area)
                {
                    case "lstcol":
                        model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
                    default: break;
                }
            }
            return model;
        }

		/// <summary>
        /// Check the loaded model for pending rows (zzsttate not 0)
        /// </summary>
        /// <returns></returns>
        public bool CheckForZzstate()
        {
            if (Menu == null) return false;
            if (Menu.Elements == null) return false;
            foreach (var row in Menu.Elements)
                if (row.ValZzstate != 0)
                    return true;
            return false;
        }

		public List<TableSearchColumn> GetSearchColumns() {
			List<TableSearchColumn> list = new List<TableSearchColumn>();
				
			list.Add(new TableSearchColumn("ValTabela", CSGenioAlstcol.FldTabela, typeof(string)));
			list.Add(new TableSearchColumn("ValAlias", CSGenioAlstcol.FldAlias, typeof(string)));
			list.Add(new TableSearchColumn("ValCampo", CSGenioAlstcol.FldCampo, typeof(string)));
			list.Add(new TableSearchColumn("ValVisivel", CSGenioAlstcol.FldVisivel, typeof(bool)));
			list.Add(new TableSearchColumn("ValPosicao", CSGenioAlstcol.FldPosicao, typeof(decimal?)));
			list.Add(new TableSearchColumn("ValOperacao", CSGenioAlstcol.FldOperacao, typeof(decimal?)));
			list.Add(new TableSearchColumn("ValTipo", CSGenioAlstcol.FldTipo, typeof(decimal?)));
 			return list;
		}

	}
}
