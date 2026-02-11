using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Compo : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcompo klass { get { return baseklass as CSGenioAcompo; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValCodcompo")]
		public string ValCodcompo { get { return klass.ValCodcompo; } set { klass.ValCodcompo = value; } }

		[DisplayName("Components Class")]
		/// <summary>Field : "Components Class" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValCodcompc")]
		public string ValCodcompc { get { return klass.ValCodcompc; } set { klass.ValCodcompc = value; } }

		private Compc _compc;
		[DisplayName("Compc")]
		[ShouldSerialize("Compc")]
		public virtual Compc Compc
		{
			get
			{
				if (!isEmptyModel && (_compc == null || (!string.IsNullOrEmpty(ValCodcompc) && (_compc.isEmptyModel || _compc.klass.QPrimaryKey != ValCodcompc))))
					_compc = Models.Compc.Find(ValCodcompc, m_userContext, Identifier, _fieldsToSerialize);
				_compc ??= new Models.Compc(m_userContext, true, _fieldsToSerialize);
				return _compc;
			}
			set { _compc = value; }
		}

		[DisplayName("Release version")]
		/// <summary>Field : "Release version" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValRelease")]
		public string ValRelease { get { return klass.ValRelease; } set { klass.ValRelease = value; } }

		[DisplayName("Component description")]
		/// <summary>Field : "Component description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValCompdesc")]
		[DataType(DataType.MultilineText)]
		public string ValCompdesc { get { return klass.ValCompdesc; } set { klass.ValCompdesc = value; } }

		[DisplayName("Preview")]
		/// <summary>Field : "Preview" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValPreview")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPreview { get { return new ImageModel(klass.ValPreview) { Ticket = ValPreviewQTicket }; } set { klass.ValPreview = value; } }
		[JsonIgnore]
		public string ValPreviewQTicket = null;

		[DisplayName("Component type")]
		/// <summary>Field : "Component type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValComptype")]
		public string ValComptype { get { return klass.ValComptype; } set { klass.ValComptype = value; } }

		[DisplayName("Variants")]
		/// <summary>Field : "Variants" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValCompvari")]
		public string ValCompvari { get { return klass.ValCompvari; } set { klass.ValCompvari = value; } }

		[DisplayName("Variant Description")]
		/// <summary>Field : "Variant Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValVardescr")]
		[DataType(DataType.MultilineText)]
		public string ValVardescr { get { return klass.ValVardescr; } set { klass.ValVardescr = value; } }

		[DisplayName("When to use")]
		/// <summary>Field : "When to use" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValWuse")]
		[DataType(DataType.MultilineText)]
		public string ValWuse { get { return klass.ValWuse; } set { klass.ValWuse = value; } }

		[DisplayName("When not to use")]
		/// <summary>Field : "When not to use" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValWnuse")]
		[DataType(DataType.MultilineText)]
		public string ValWnuse { get { return klass.ValWnuse; } set { klass.ValWnuse = value; } }

		[DisplayName("VUE")]
		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValVuemvc")]
		public bool ValVuemvc { get { return Convert.ToBoolean(klass.ValVuemvc); } set { klass.ValVuemvc = Convert.ToInt32(value); } }

		[DisplayName("MVC")]
		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValMvc")]
		public bool ValMvc { get { return Convert.ToBoolean(klass.ValMvc); } set { klass.ValMvc = Convert.ToInt32(value); } }

		[DisplayName("Accesibilty Compliance & Best Practices")]
		/// <summary>Field : "Accesibilty Compliance & Best Practices" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValAccessib")]
		[DataType(DataType.MultilineText)]
		public string ValAccessib { get { return klass.ValAccessib; } set { klass.ValAccessib = value; } }

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Compo.ValCdatatyp")]
		public string ValCdatatyp { get { return klass.ValCdatatyp; } set { klass.ValCdatatyp = value; } }

		[DisplayName("Component class")]
		/// <summary>Field : "Component class" Tipo: "AN" Formula: + "iif ([COMPC->COMPCLAS] == "Media", 1, iif ([COMPC->COMPCLAS] == "Data Input", 2, iif ([COMPC->COMPCLAS] == "Data Grid", 3, iif ([COMPC->COMPCLAS] == "Action", 4, iif ([COMPC->COMPCLAS] == "Container", 5, iif ([COMPC->COMPCLAS] == "Data Display", 6, iif ([COMPC->COMPCLAS] == "Interactive", 7, 8)))))))"</summary>
		[ShouldSerialize("Compo.ValCompicon")]
		[DataArray("Componenticons", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValCompicon { get { return klass.ValCompicon; } set { klass.ValCompicon = value; } }
		[JsonIgnore]
		public SelectList ArrayValcompicon { get { return new SelectList(CSGenio.business.ArrayComponenticons.GetDictionary(), "Key", "Value", ValCompicon); } set { ValCompicon = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Compo.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Compo(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcompo(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compo(UserContext userContext, CSGenioAcompo val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcompo csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "compc":
						_compc ??= new Compc(m_userContext, true, _fieldsToSerialize);
						_compc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Compo Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcompo>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Compo(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Compo> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcompo>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Compo>((r) => new Compo(userCtx, r));
		}

// USE /[MANUAL GQT MODEL COMPO]/
	}
}
