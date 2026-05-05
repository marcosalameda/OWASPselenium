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
	public class Authenticatopt : ModelBase
	{
		[JsonIgnore]
		public CSGenioAauthenticatopt klass { get { return baseklass as CSGenioAauthenticatopt; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValCodauthenticatopt")]
		public string ValCodauthenticatopt { get { return klass.ValCodauthenticatopt; } set { klass.ValCodauthenticatopt = value; } }

		[DisplayName("Variable type")]
		/// <summary>Field : "Variable type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthvariablet")]
		public string ValAuthvariablet { get { return klass.ValAuthvariablet; } set { klass.ValAuthvariablet = value; } }

		[DisplayName("Variable name")]
		/// <summary>Field : "Variable name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthvarname")]
		public string ValAuthvarname { get { return klass.ValAuthvarname; } set { klass.ValAuthvarname = value; } }

		[DisplayName("Option")]
		/// <summary>Field : "Option" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthoptions")]
		[DataArray("Authentication_options", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAuthoptions { get { return klass.ValAuthoptions; } set { klass.ValAuthoptions = value; } }
		[JsonIgnore]
		public SelectList ArrayValauthoptions { get { return new SelectList(CSGenio.business.ArrayAuthentication_options.GetDictionary(), "Key", "Value", ValAuthoptions); } set { ValAuthoptions = value.SelectedValue as string; } }

		[DisplayName("MVC")]
		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthmvc")]
		public bool ValAuthmvc { get { return Convert.ToBoolean(klass.ValAuthmvc); } set { klass.ValAuthmvc = Convert.ToInt32(value); } }

		[DisplayName("VUE")]
		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthvue")]
		public bool ValAuthvue { get { return Convert.ToBoolean(klass.ValAuthvue); } set { klass.ValAuthvue = Convert.ToInt32(value); } }

		[DisplayName("Notes")]
		/// <summary>Field : "Notes" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthnotes")]
		[DataType(DataType.MultilineText)]
		public string ValAuthnotes { get { return klass.ValAuthnotes; } set { klass.ValAuthnotes = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Authenticatopt.ValAuthpreview")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValAuthpreview { get { return new ImageModel(klass.ValAuthpreview) { Ticket = ValAuthpreviewQTicket }; } set { klass.ValAuthpreview = value; } }
		[JsonIgnore]
		public string ValAuthpreviewQTicket = null;

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Authenticatopt.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Authenticatopt(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAauthenticatopt(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Authenticatopt(UserContext userContext, CSGenioAauthenticatopt val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAauthenticatopt csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Authenticatopt Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAauthenticatopt>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Authenticatopt(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Authenticatopt> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAauthenticatopt>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Authenticatopt>((r) => new Authenticatopt(userCtx, r));
		}

// USE /[MANUAL GQT MODEL AUTHENTICATOPT]/
	}
}
