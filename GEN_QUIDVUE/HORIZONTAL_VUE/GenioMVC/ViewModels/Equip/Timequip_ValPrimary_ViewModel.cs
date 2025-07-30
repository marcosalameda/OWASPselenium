using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
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

namespace GenioMVC.ViewModels.Equip
{
	public class Timequip_ValPrimary_ViewModel : ViewModelBase
	{
		public TablePartial<Models.TimelineItem> Menu { get; set; }

		/// <summary>
		/// The primary key field.
		/// </summary>
		[JsonIgnore]
		public string ValCodequip { get; set; }

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		public string Uuid { get => "Timequip_ValPrimary"; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Timequip_ValPrimary_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public Timequip_ValPrimary_ViewModel(UserContext userContext) : base(userContext) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Timequip_ValPrimary_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public Timequip_ValPrimary_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
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

		public static Expression<Func<CSGenioArepar, string>> backgroundColorconditionREPARASO = p => (((p.ValHours)>10)?("RGB(255,0,0)"):("RGB(0,255,0)"));
		Func<CSGenioArepar, string> backgroundColorREPARASO = backgroundColorconditionREPARASO.Compile();

		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref List<Models.TimelineItem> Qlisting, ref CriteriaSet conditions)
		{
			if (ajaxRequest)
				this.Navigation.SetValue("requestValues" + "Timequip_ValPrimary", requestValues);
			else if (!ajaxRequest && this.Navigation.CheckKey("requestValues" + "Timequip_ValPrimary"))
				requestValues = this.Navigation.GetValue<NameValueCollection>("requestValues" + "Timequip_ValPrimary");

			Menu = new TablePartial<Models.TimelineItem>();
			this.ValCodequip = this.Navigation.GetValue("equip").ToString();
			List<Models.TimelineItem> datalist = new List<Models.TimelineItem>();
			int totalrecords = tableConfig.RowsPerPage;
			totalrecords = 50;

			// REPARASO
			CriteriaSet filterREPARASO = conditions ?? CriteriaSet.And();
			List<ColumnSort> sortsREPARASO = new List<ColumnSort>();
			filterREPARASO.Equal(CSGenioArepar.FldCodequip, this.ValCodequip);
			TablePartial<GenioMVC.Models.Repar> Menu_REPARASO = new TablePartial<GenioMVC.Models.Repar>();
			FieldRef[] fieldsREPARASO = new FieldRef[] { CSGenioArepar.FldCodrepar, CSGenioArepar.FldZzstate, CSGenioArepar.FldNrrepara, CSGenioArepar.FldDtrepara, CSGenioArepar.FldHours, CSGenioArepar.FldCodpesso, CSGenioApesso.FldCodpesso, CSGenioApesso.FldName, CSGenioArepar.FldDescript, CSGenioArepar.FldCodespec, CSGenioAspeci.FldCodespec, CSGenioAspeci.FldEspecial };


			ListingMVC<CSGenioArepar> listingREPARASO = Models.ModelBase.Where<CSGenioArepar>(m_userContext, false, filterREPARASO, fieldsREPARASO, 0, totalrecords, sortsREPARASO, "IBL_TIMEQUIPPSEUDPRIMARY_", true, false);
			datalist.AddRange(MapREPARASO(listingREPARASO));

			Menu.Elements = datalist.Select(item =>
			{
				item.Columns = item.Columns.OrderBy(column => column.Order).ToList();
				return item;
			}).OrderBy(p => p.Data).ToList();
		}

		private List<Models.TimelineItem> MapREPARASO(ListingMVC<CSGenioArepar> Qlisting)
		{
			int i = 0;
			var Elements = new List<Models.TimelineItem>();

			foreach (var row in Qlisting.Rows)
			{
				if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
					break;
				Elements.Add(MapREPARASO(row));
				i++;
			}

			return Elements;
		}

		private Models.TimelineItem MapREPARASO(CSGenioArepar row)
		{
			var model = new Models.TimelineItem();
			model.Columns = new List<Models.TimelineColumn>();
			model.ImagesColumns = new List<Models.TimelineColumn>();

			if (row == null)
				return model;

			model.Background = backgroundColorREPARASO(row);
			// Check TimeLineStyle to see more about the style values.
			model.Style = "P";

			model.Icon = "";
			model.Escala = "dd";
			model.TipoTimeLine = "";

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				if (Qfield.FullName.Equals("repar.codrepar"))
					model.Identifier = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("repar.dtrepara"))
					model.Data = Conversion.internalDateTime2InternalValidDateTime(Qfield.Value);

				if (Qfield.FullName.Equals("repar.nrrepara"))
					model.Texto = Qfield.Value.ToString();

				if (Qfield.FullName.Equals("pesso.name"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Name", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 1, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}

				if (Qfield.FullName.Equals("repar.descript"))
				{
					var fieldType = FieldType.MEMO;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Description of the repair", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 2, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}

				if (Qfield.FullName.Equals("repar.nrrepara"))
				{
					var fieldType = FieldType.NUMERIC;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "No rumour in the Company", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 3, fieldType = fieldType.ToString() };
					model.Columns.Add(column);

				}

				if (Qfield.FullName.Equals("speci.especial"))
				{
					var fieldType = FieldType.TEXT;
					Models.TimelineColumn column = new Models.TimelineColumn { Titulo = "Specialty", Valor = Conversion.internal2String(Qfield.Value, fieldType), Icone = "", Order = 4, fieldType = fieldType.ToString() };
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

// USE /[MANUAL GQT VIEWMODEL_CUSTOM TIMEQUIP_VALPRIMARY]/

		#endregion
	}
}
