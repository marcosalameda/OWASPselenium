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
	public class Proph : ModelBase
	{
		[JsonIgnore]
		public CSGenioAproph klass { get { return baseklass as CSGenioAproph; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Proph.ValCodproph")]
		public string ValCodproph { get { return klass.ValCodproph; } set { klass.ValCodproph = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Proph.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Proph.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Property")]
		/// <summary>Field : "Property" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Proph.ValCodprope")]
		public string ValCodprope { get { return klass.ValCodprope; } set { klass.ValCodprope = value; } }

		private Prope _prope;
		[DisplayName("Prope")]
		[ShouldSerialize("Prope")]
		public virtual Prope Prope
		{
			get
			{
				if (!isEmptyModel && (_prope == null || (!string.IsNullOrEmpty(ValCodprope) && (_prope.isEmptyModel || _prope.klass.QPrimaryKey != ValCodprope))))
					_prope = Models.Prope.Find(ValCodprope, m_userContext, Identifier, _fieldsToSerialize);
				_prope ??= new Models.Prope(m_userContext, true, _fieldsToSerialize);
				return _prope;
			}
			set { _prope = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Proph.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Proph(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAproph(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Proph(UserContext userContext, CSGenioAproph val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAproph csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "prope":
						_prope ??= new Prope(m_userContext, true, _fieldsToSerialize);
						_prope.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Proph Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAproph>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Proph(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Proph> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAproph>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Proph>((r) => new Proph(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PROPH]/
	}
}
