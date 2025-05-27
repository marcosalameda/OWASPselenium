using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Equip
{
	public class Equip_ValTlequipa_ViewModel : ViewModelBase
	{
		public TablePartial<Models.TimelineItem> Menu { get; set; }

		public string ValCodequip { get; set; }

		public Equip_ValTlequipa_ViewModel(NavigationContext current_navigation)
		{
			this.Navigation = current_navigation;
						ValCodequip = current_navigation.CurrentLevel.GetEntry("equip")?.ToString();
						
		}

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

		public static Expression<Func<CSGenioAvisit, string>> backgroundColorconditionVISITAS = p => "RGB(0,255,0)";
		Func<CSGenioAvisit, string> backgroundColorVISITAS = backgroundColorconditionVISITAS.Compile();

		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref List<Models.TimelineItem> Qlisting, ref CriteriaSet conditions)
		{
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Equip_ValTlequipa", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Equip_ValTlequipa"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Equip_ValTlequipa");

			Menu = new TablePartial<Models.TimelineItem>();
			List<Models.TimelineItem> datalist = new List<Models.TimelineItem>();
			int totalrecords = numberListItems;
			totalrecords = 5;

			// VISITAS
			CriteriaSet filterVISITAS = conditions ?? CriteriaSet.And();
			List<ColumnSort> sortsVISITAS = new List<ColumnSort>();
			filterVISITAS.Equal(CSGenioAvisit.FldCodequip, this.ValCodequip);
			TablePartial<GenioMVC.Models.Visit> Menu_VISITAS = new TablePartial<GenioMVC.Models.Visit>();
			FieldRef[] fieldsVISITAS = new FieldRef[] { CSGenioAvisit.FldCodvisit, CSGenioAvisit.FldZzstate, CSGenioAvisit.FldTitle, CSGenioAvisit.FldStartdt, CSGenioAvisit.FldObservat };


			ListingMVC<CSGenioAvisit> listingVISITAS = Models.ModelBase.Where<CSGenioAvisit>(false, filterVISITAS, fieldsVISITAS, 0, totalrecords, sortsVISITAS, "IBL_EQUIP___PSEUDTLEQUIPA", true, false);
			datalist.AddRange(MapVISITAS(listingVISITAS));

			// REPARACO
			CriteriaSet filterREPARACO = conditions ?? CriteriaSet.And();
			List<ColumnSort> sortsREPARACO = new List<ColumnSort>();
			filterREPARACO.Equal(CSGenioArepar.FldCodequip, this.ValCodequip);
			TablePartial<GenioMVC.Models.Repar> Menu_REPARACO = new TablePartial<GenioMVC.Models.Repar>();
			FieldRef[] fieldsREPARACO = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldDescript, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldCodespec, CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial };


			ListingMVC<CSGenioArepar> listingREPARACO = Models.ModelBase.Where<CSGenioArepar>(false, filterREPARACO, fieldsREPARACO, 0, totalrecords, sortsREPARACO, "IBL_EQUIP___PSEUDTLEQUIPA", true, false);
			datalist.AddRange(MapREPARACO(listingREPARACO));

			Menu.Elements = datalist.Select(item =>
			{
				item.Columns = item.Columns.OrderBy(column => column.Order).ToList();
				return item;
			}).OrderBy(p => p.Data).ToList();
		}

		private List<Models.TimelineItem> MapVISITAS(ListingMVC<CSGenioAvisit> Qlisting)
		{
			int i = 0;
			var Elements = new List<Models.TimelineItem>();

			foreach (var row in Qlisting.Rows)
			{
				if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
					break;
				Elements.Add(MapVISITAS(row));
				i++;
			}

			return Elements;
		}

		private Models.TimelineItem MapVISITAS(CSGenioAvisit row)
		{
			var model = new Models.TimelineItem();
			model.Columns = new List<Models.TimelineColumn>();
			model.ImagesColumns = new List<Models.TimelineColumn>();

			if (row == null)
				return model;

			model.Background = backgroundColorVISITAS(row);
			// Check TimeLineStyle to see more about the style values.
			model.Style = "P";

			model.Icon = "";
			model.Escala = "mm";
			model.TipoTimeLine = "";

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				if (Qfield.FullName.Equals("visit.codvisit"))
					model.Identifier = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("visit.startdt"))
					model.Data = Conversion.internalDateTime2InternalValidDateTime(Qfield.Value);

				if (Qfield.FullName.Equals("visit.title"))
					model.Texto = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("visit.title"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Título", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 1, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}

				if (Qfield.FullName.Equals("visit.observat"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Observações", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 2, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}
			}
			model.Url = new ItemActionDescriptor()
			{
				Action = "Visit_Show",
				Resource = "Visit",
				Id = model.Identifier,
				Nav = Navigation.NavigationId
			};
			model.SupportForm = "VISIT";

			return model;
		}

		private List<Models.TimelineItem> MapREPARACO(ListingMVC<CSGenioArepar> Qlisting)
		{
			int i = 0;
			var Elements = new List<Models.TimelineItem>();

			foreach (var row in Qlisting.Rows)
			{
				if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
					break;
				Elements.Add(MapREPARACO(row));
				i++;
			}

			return Elements;
		}

		private Models.TimelineItem MapREPARACO(CSGenioArepar row)
		{
			var model = new Models.TimelineItem();
			model.Columns = new List<Models.TimelineColumn>();
			model.ImagesColumns = new List<Models.TimelineColumn>();

			if (row == null)
				return model;


			model.Icon = "";
			model.Escala = "mm";
			model.TipoTimeLine = "";

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				if (Qfield.FullName.Equals("repar.codrepar"))
					model.Identifier = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("repar.dtrepara"))
					model.Data = Conversion.internalDateTime2InternalValidDateTime(Qfield.Value);

				if (Qfield.FullName.Equals("repar.nrrepara"))
					model.Texto = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("repar.nrrepara"))
				{
					var fieldType = FieldType.NUMERIC;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "N.º reparação na Empresa", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 3, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}

				if (Qfield.FullName.Equals("repar.descript"))
				{
					var fieldType = FieldType.MEMO;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Descrição da reparação", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 4, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}

				if (Qfield.FullName.Equals("pesso.name"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Nome", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 5, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}

				if (Qfield.FullName.Equals("speci.especial"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Especialidade", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 6, fieldType = fieldType.ToString() };
					model.Columns.Add(column);
				}
			}
			model.Url = new ItemActionDescriptor()
			{
				Action = "Repar_Show",
				Resource = "Repar",
				Id = model.Identifier,
				Nav = Navigation.NavigationId
			};
			model.SupportForm = "REPAR";

			return model;
		}

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIP_VALTLEQUIPA]/

		#endregion
	}
}
