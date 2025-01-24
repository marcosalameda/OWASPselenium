using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Wareh
{
	public class Tmline_ValTmdsaid_ViewModel : ViewModelBase
	{
		public TablePartial<Models.TimelineItem> Menu { get; set; }

		public string ValCodwareh { get; set; }

		public string Uuid { get => "Tmline_ValTmdsaid"; }
		
		public Tmline_ValTmdsaid_ViewModel(UserContext userContext) : base(userContext) { }

		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			List<Models.TimelineItem> listing = null;
			CriteriaSet conditions = null;
			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}
		
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref List<Models.TimelineItem> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();
			
			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}
		
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			List<Models.TimelineItem> listing = null;
			CriteriaSet conditions = null;
			Load(tableConfig, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref List<Models.TimelineItem> Qlisting, ref CriteriaSet conditions)
		{
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Tmline_ValTmdsaid", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Tmline_ValTmdsaid"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Tmline_ValTmdsaid");

			Menu = new TablePartial<Models.TimelineItem>();
			this.ValCodwareh = this.Navigation.GetValue("wareh").ToString();
			List<Models.TimelineItem> datalist = new List<Models.TimelineItem>();
			int totalrecords = tableConfig.RowsPerPage;

			// DEXITTM
			CriteriaSet filterDEXITTM = conditions ?? CriteriaSet.And();
			List<ColumnSort> sortsDEXITTM = new List<ColumnSort>();
			filterDEXITTM.Equal(CSGenioAitem.FldCodwareh, this.ValCodwareh);
			TablePartial<GenioMVC.Models.Item> Menu_DEXITTM = new TablePartial<GenioMVC.Models.Item>();
			FieldRef[] fieldsDEXITTM = new FieldRef[] { CSGenioAitem.FldCoditem, CSGenioAitem.FldZzstate, CSGenioAitem.FldItemdes, CSGenioAitem.FldDate, CSGenioAitem.FldItemcod };


			ListingMVC<CSGenioAitem> listingDEXITTM = Models.ModelBase.Where<CSGenioAitem>(m_userContext, false, filterDEXITTM, fieldsDEXITTM, 0, totalrecords, sortsDEXITTM, "IBL_TMLINE__PSEUDTMDSAID_", true, false);
			datalist.AddRange(MapDEXITTM(listingDEXITTM));

			Menu.Elements = datalist.Select(item =>
			{
				item.Columns = item.Columns.OrderBy(column => column.Order).ToList();
				return item;
			}).OrderBy(p => p.Data).ToList();
		}

		private List<Models.TimelineItem> MapDEXITTM(ListingMVC<CSGenioAitem> Qlisting)
		{
			int i = 0;
			var Elements = new List<Models.TimelineItem>();

			foreach (var row in Qlisting.Rows)
			{
				if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
					break;
				Elements.Add(MapDEXITTM(row));
				i++;
			}

			return Elements;
		}

		private Models.TimelineItem MapDEXITTM(CSGenioAitem row)
		{
			var model = new Models.TimelineItem();
			model.Columns = new List<Models.TimelineColumn>();
			model.ImagesColumns = new List<Models.TimelineColumn>();

			if (row == null)
				return model;


			model.Icon = "";
			model.Escala = "un";

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				if (Qfield.FullName.Equals("item.coditem"))
					model.Identifier = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("item.date"))
					model.Data = Conversion.internalDateTime2InternalValidDateTime(Qfield.Value);

				if (Qfield.FullName.Equals("item.itemdes"))
					model.Texto = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("item.itemdes"))
				{
					var fieldType = FieldType.TEXTO;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Item", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 1, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}

				if (Qfield.FullName.Equals("item.itemcod"))
				{
					var fieldType = FieldType.TEXTO;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Code", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 2, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}

				if (Qfield.FullName.Equals("item.date"))
				{
					var fieldType = FieldType.DATA;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Date", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 3, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}
			}

			model.Url = new ItemActionDescriptor()
			{
				Action = "Artig_Show",
				Resource = "Item",
				Id = model.Identifier,
				Nav = Navigation.NavigationId
			};
			model.SupportForm = "ARTIG";

			return model;
		}

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TMLINE_VALTMDSAID]/

		#endregion
	}
}
