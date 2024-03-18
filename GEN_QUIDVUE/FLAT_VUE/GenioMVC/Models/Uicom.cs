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
	public class Uicom : ModelBase
	{
		[JsonIgnore]
		public CSGenioAuicom klass { get { return baseklass as CSGenioAuicom; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Uicom.ValCoduicom")]
		public string ValCoduicom { get { return klass.ValCoduicom; } set { klass.ValCoduicom = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Uicom.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Uicom.ValCategory")]
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }

		[DisplayName("Fixed menu name")]
		/// <summary>Field : "Fixed menu name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Uicom.ValMenuid")]
		public string ValMenuid { get { return klass.ValMenuid; } set { klass.ValMenuid = value; } }

		[DisplayName("Thumbnail")]
		/// <summary>Field : "Thumbnail" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Uicom.ValThumbnai")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValThumbnai { get { return klass.ValThumbnai; } set { klass.ValThumbnai = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Uicom.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Uicom(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAuicom(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Uicom(UserContext userContext, CSGenioAuicom val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAuicom csgenioa)
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
		public static Uicom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAuicom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Uicom(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Uicom> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAuicom>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Uicom>((r) => new Uicom(userCtx, r));
		}

// USE /[MANUAL GQT MODEL UICOM]/
	}
}
