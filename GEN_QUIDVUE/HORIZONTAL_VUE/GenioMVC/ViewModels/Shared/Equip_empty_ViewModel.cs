using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels
{
	public class Equip_empty_ViewModel(UserContext userContext, bool nestedForm = false) : EmptyFormViewModel(userContext, nestedForm)
	{
		/// <summary>
		/// Title: "Downed equipment" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValIfabatif 
		{
			get
			{
				return funcValIfabatif != null ? funcValIfabatif() : _auxValIfabatif;
			}
			set { funcValIfabatif = () => value; }
		}

		[JsonIgnore]
		public Func<bool> funcValIfabatif { get; set; }

		private bool _auxValIfabatif { get; set; }
		#region DatabaseFields used in title buttons



		#endregion

		#region Tab region


		#endregion

		#region Foreign Keys


		#endregion

		#region Fields for formulas



		#endregion

		#region Global filters fields
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string CntryValCodcntryFilterKey { get; set; }
		public TableDBEdit<Models.Cntry> TableCntryCountry { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string CmpnyValCodempreFilterKey { get; set; }
		public TableDBEdit<Models.Cmpny> TableCmpnyDesignat { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Pess1ValCodpessoFilterKey { get; set; }
		public TableDBEdit<Models.Pess1> TablePess1Name { get; set; }
		#endregion


		#region ViewModel Equip_empty (Equipment)

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			Load_Equip_empty__cntry__country_fg(qs, lazyLoad);
			Load_Equip_empty__cmpny__designat_fg(qs, lazyLoad);
			Load_Equip_empty__pess1__name_fg(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIP_EMPTY]/
		}

		/// <summary>
		/// TableCntryCountry -> (FG/lk)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip_empty__cntry__country_fg(NameValueCollection qs, bool lazyLoad = false)
		{
			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if(lazyLoad)
			{
				var historyKeyValue = Navigation.GetStrValue("cntry");
				IncludeSelected_Equip_emptyTableCntryCountry(historyKeyValue);
				return;
			}

			bool loadData = true;
			CriteriaSet mainCondition = CriteriaSet.And();
			if (loadData)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				string query = qs["qTableCntryCountry"];
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				mainCondition.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"]?.ToString() ?? "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate];

				// Limitation by Zzstate
				mainCondition.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, mainCondition, fields, offset, numberItems, sorts, "FILTER_EQUIP_EMPTY__CNTRY__COUNTRY_FG", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel((r) => new Models.Cntry(m_userContext, r, true, _fieldsToSerialize_EQUIP_EMPTY__CNTRY__COUNTRY_FG));

				var currentSelected = Navigation.CurrentLevel.GetEntry<string>("global-filter-cntry");

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == currentSelected), "Value", "Text", currentSelected);
				IncludeSelected_Equip_emptyTableCntryCountry(currentSelected);
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		/// <param name="returnEmptyValues"></param>
		public ConcurrentDictionary<string, object> GetDependant_Equip_emptyTableCntryCountry(string PKey, bool returnEmptyValues = true)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];
			
			User u = m_userContext.User;
			bool loadData = GenFunctions.emptyG(PKey) == 0;
			CriteriaSet mainCondition = CriteriaSet.And()
				.Equal(CSGenioAcntry.FldCodcntry, PKey);
			

			// Return default values
			if (!loadData)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			mainCondition = Models.ModelBase.AddEPH<CSGenioAcntry>(ref u, mainCondition, "FILTER_EQUIP_EMPTY__CNTRY__COUNTRY_FG");
			// Select option primery key and text field
			SelectQuery querySelect = new SelectQuery()
				.PageSize(1)
				.Select(CSGenioAcntry.FldCodcntry)
				.Select(CSGenioAcntry.FldCountry)
				.From(Area.AreaCNTRY)
				.Where(mainCondition);

			string[] dependantFields = [.. refDependantFields.Select(f => f.FullName)];
			QueryUtils.SetInnerJoins(dependantFields, mainCondition, new CSGenioAcntry(u), querySelect);

			ArrayList values = m_userContext.PersistentSupport.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			// Return default values
			if (useDefaults)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry
		/// </summary>
		/// <param name="selectedKey">Primary Key of Cntry</param>
		/// <param name="returnEmptyValues"></param>
		public void IncludeSelected_Equip_emptyTableCntryCountry(string selectedKey)
		{
			bool tryIncludeSelected = GenFunctions.emptyG(selectedKey) == 0 && TableCntryCountry.List?.Any(item => item.Value == selectedKey) != true;
			if (tryIncludeSelected)
			{
				var row = GetDependant_Equip_emptyTableCntryCountry(selectedKey, false);
				if(row != null)
				{
					TableCntryCountry.Value = ViewModelConversion.ToString(row[CSGenioAcntry.FldCountry]);
					var selectedItem = new SelectListItem()
					{
						Value = Convert.ToString(selectedKey),
						Text = Convert.ToString(TableCntryCountry.Value),
						Selected = true

					};
					var items = TableCntryCountry.List == null ? [selectedItem] : TableCntryCountry.List.Prepend(selectedItem);
					TableCntryCountry.List = new SelectList(items, "Value", "Text", selectedKey);
					TableCntryCountry.Selected = selectedKey;
					CntryValCodcntryFilterKey = selectedKey;
				}
				else
				{
					TableCntryCountry.Selected = null;
					CntryValCodcntryFilterKey = null;
				}
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP_EMPTY__CNTRY__COUNTRY_FG = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate"];

		/// <summary>
		/// TableCmpnyDesignat -> (FG/lk)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip_empty__cmpny__designat_fg(NameValueCollection qs, bool lazyLoad = false)
		{
			TableCmpnyDesignat = new TableDBEdit<Models.Cmpny>
			{
				IsLazyLoad = lazyLoad
			};

			if(lazyLoad)
			{
				var historyKeyValue = Navigation.GetStrValue("cmpny");
				IncludeSelected_Equip_emptyTableCmpnyDesignat(historyKeyValue);
				return;
			}

			bool loadData = true;
			CriteriaSet mainCondition = CriteriaSet.And();
			if (loadData)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCmpnyDesignat, "sTableCmpnyDesignat", "dTableCmpnyDesignat", qs, "cmpny");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				if (!string.IsNullOrEmpty(qs["TableCmpnyDesignat_tableFilters"]))
					TableCmpnyDesignat.TableFilters = bool.Parse(qs["TableCmpnyDesignat_tableFilters"]);
				else
					TableCmpnyDesignat.TableFilters = false;

				string query = qs["qTableCmpnyDesignat"];
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
					search_filters.Like(CSGenioAcmpny.FldDesignat, query + "%");
				mainCondition.SubSet(search_filters);

				string tryParsePage = qs["pTableCmpnyDesignat"]?.ToString() ?? "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldZzstate];

				// Limitation by Zzstate
				mainCondition.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcmpny.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioAcmpny> listing = Models.ModelBase.Where<CSGenioAcmpny>(m_userContext, false, mainCondition, fields, offset, numberItems, sorts, "FILTER_EQUIP_EMPTY__CMPNY__DESIGNAT_FG", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCmpnyDesignat.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCmpnyDesignat.Query = query;
				TableCmpnyDesignat.Elements = listing.RowsForViewModel((r) => new Models.Cmpny(m_userContext, r, true, _fieldsToSerialize_EQUIP_EMPTY__CMPNY__DESIGNAT_FG));

				var currentSelected = Navigation.CurrentLevel.GetEntry<string>("global-filter-cmpny");

				TableCmpnyDesignat.List = new SelectList(TableCmpnyDesignat.Elements.ToSelectList(x => x.ValDesignat, x => x.ValCodempre,  x => x.ValCodempre == currentSelected), "Value", "Text", currentSelected);
				IncludeSelected_Equip_emptyTableCmpnyDesignat(currentSelected);
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat
		/// </summary>
		/// <param name="PKey">Primary Key of Cmpny</param>
		/// <param name="returnEmptyValues"></param>
		public ConcurrentDictionary<string, object> GetDependant_Equip_emptyTableCmpnyDesignat(string PKey, bool returnEmptyValues = true)
		{
			FieldRef[] refDependantFields = [CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldDesignat];
			
			User u = m_userContext.User;
			bool loadData = GenFunctions.emptyG(PKey) == 0;
			CriteriaSet mainCondition = CriteriaSet.And()
				.Equal(CSGenioAcmpny.FldCodempre, PKey);
			

			// Return default values
			if (!loadData)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			mainCondition = Models.ModelBase.AddEPH<CSGenioAcmpny>(ref u, mainCondition, "FILTER_EQUIP_EMPTY__CMPNY__DESIGNAT_FG");
			// Select option primery key and text field
			SelectQuery querySelect = new SelectQuery()
				.PageSize(1)
				.Select(CSGenioAcmpny.FldCodempre)
				.Select(CSGenioAcmpny.FldDesignat)
				.From(Area.AreaCMPNY)
				.Where(mainCondition);

			string[] dependantFields = [.. refDependantFields.Select(f => f.FullName)];
			QueryUtils.SetInnerJoins(dependantFields, mainCondition, new CSGenioAcmpny(u), querySelect);

			ArrayList values = m_userContext.PersistentSupport.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			// Return default values
			if (useDefaults)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Get Dependant fields values -> TableCmpnyDesignat
		/// </summary>
		/// <param name="selectedKey">Primary Key of Cmpny</param>
		/// <param name="returnEmptyValues"></param>
		public void IncludeSelected_Equip_emptyTableCmpnyDesignat(string selectedKey)
		{
			bool tryIncludeSelected = GenFunctions.emptyG(selectedKey) == 0 && TableCmpnyDesignat.List?.Any(item => item.Value == selectedKey) != true;
			if (tryIncludeSelected)
			{
				var row = GetDependant_Equip_emptyTableCmpnyDesignat(selectedKey, false);
				if(row != null)
				{
					TableCmpnyDesignat.Value = ViewModelConversion.ToString(row[CSGenioAcmpny.FldDesignat]);
					var selectedItem = new SelectListItem()
					{
						Value = Convert.ToString(selectedKey),
						Text = Convert.ToString(TableCmpnyDesignat.Value),
						Selected = true

					};
					var items = TableCmpnyDesignat.List == null ? [selectedItem] : TableCmpnyDesignat.List.Prepend(selectedItem);
					TableCmpnyDesignat.List = new SelectList(items, "Value", "Text", selectedKey);
					TableCmpnyDesignat.Selected = selectedKey;
					CmpnyValCodempreFilterKey = selectedKey;
				}
				else
				{
					TableCmpnyDesignat.Selected = null;
					CmpnyValCodempreFilterKey = null;
				}
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP_EMPTY__CMPNY__DESIGNAT_FG = ["Cmpny", "Cmpny.ValCodempre", "Cmpny.ValZzstate"];

		/// <summary>
		/// TablePess1Name -> (FG/lk)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equip_empty__pess1__name_fg(NameValueCollection qs, bool lazyLoad = false)
		{
			TablePess1Name = new TableDBEdit<Models.Pess1>
			{
				IsLazyLoad = lazyLoad
			};

			if(lazyLoad)
			{
				var historyKeyValue = Navigation.GetStrValue("pess1");
				IncludeSelected_Equip_emptyTablePess1Name(historyKeyValue);
				return;
			}

			bool loadData = true;
			CriteriaSet mainCondition = CriteriaSet.And();
			if (loadData)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				if (!string.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
					TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
				else
					TablePess1Name.TableFilters = false;

				string query = qs["qTablePess1Name"];
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
					search_filters.Like(CSGenioApess1.FldName, query + "%");
				mainCondition.SubSet(search_filters);

				string tryParsePage = qs["pTablePess1Name"]?.ToString() ?? "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate];

				// Limitation by Zzstate
				mainCondition.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = null;
				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, false, mainCondition, fields, offset, numberItems, sorts, "FILTER_EQUIP_EMPTY__PESS1__NAME_FG", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess1Name.Query = query;
				TablePess1Name.Elements = listing.RowsForViewModel((r) => new Models.Pess1(m_userContext, r, true, _fieldsToSerialize_EQUIP_EMPTY__PESS1__NAME_FG));

				var currentSelected = Navigation.CurrentLevel.GetEntry<string>("global-filter-pess1");

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == currentSelected), "Value", "Text", currentSelected);
				IncludeSelected_Equip_emptyTablePess1Name(currentSelected);
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name
		/// </summary>
		/// <param name="PKey">Primary Key of Pess1</param>
		/// <param name="returnEmptyValues"></param>
		public ConcurrentDictionary<string, object> GetDependant_Equip_emptyTablePess1Name(string PKey, bool returnEmptyValues = true)
		{
			FieldRef[] refDependantFields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName];
			
			User u = m_userContext.User;
			bool loadData = GenFunctions.emptyG(PKey) == 0;
			CriteriaSet mainCondition = CriteriaSet.And()
				.Equal(CSGenioApess1.FldCodpesso, PKey);
			

			// Return default values
			if (!loadData)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			mainCondition = Models.ModelBase.AddEPH<CSGenioApess1>(ref u, mainCondition, "FILTER_EQUIP_EMPTY__PESS1__NAME_FG");
			// Select option primery key and text field
			SelectQuery querySelect = new SelectQuery()
				.PageSize(1)
				.Select(CSGenioApess1.FldCodpesso)
				.Select(CSGenioApess1.FldName)
				.From(Area.AreaPESS1)
				.Where(mainCondition);

			string[] dependantFields = [.. refDependantFields.Select(f => f.FullName)];
			QueryUtils.SetInnerJoins(dependantFields, mainCondition, new CSGenioApess1(u), querySelect);

			ArrayList values = m_userContext.PersistentSupport.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			// Return default values
			if (useDefaults)
				return returnEmptyValues ? GetViewModelFieldValues(refDependantFields) : null;

			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name
		/// </summary>
		/// <param name="selectedKey">Primary Key of Pess1</param>
		/// <param name="returnEmptyValues"></param>
		public void IncludeSelected_Equip_emptyTablePess1Name(string selectedKey)
		{
			bool tryIncludeSelected = GenFunctions.emptyG(selectedKey) == 0 && TablePess1Name.List?.Any(item => item.Value == selectedKey) != true;
			if (tryIncludeSelected)
			{
				var row = GetDependant_Equip_emptyTablePess1Name(selectedKey, false);
				if(row != null)
				{
					TablePess1Name.Value = ViewModelConversion.ToString(row[CSGenioApess1.FldName]);
					var selectedItem = new SelectListItem()
					{
						Value = Convert.ToString(selectedKey),
						Text = Convert.ToString(TablePess1Name.Value),
						Selected = true

					};
					var items = TablePess1Name.List == null ? [selectedItem] : TablePess1Name.List.Prepend(selectedItem);
					TablePess1Name.List = new SelectList(items, "Value", "Text", selectedKey);
					TablePess1Name.Selected = selectedKey;
					Pess1ValCodpessoFilterKey = selectedKey;
				}
				else
				{
					TablePess1Name.Selected = null;
					Pess1ValCodpessoFilterKey = null;
				}
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIP_EMPTY__PESS1__NAME_FG = ["Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_EMPTY]/

		#endregion
	}
}
