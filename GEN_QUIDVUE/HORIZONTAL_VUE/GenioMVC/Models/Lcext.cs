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
	public class Lcext : ModelBase
	{
		[JsonIgnore]
		public CSGenioAlcext klass { get { return baseklass as CSGenioAlcext; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Lcext.ValCodlcext")]
		public string ValCodlcext { get { return klass.ValCodlcext; } set { klass.ValCodlcext = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Lcext.ValCodlocat")]
		public string ValCodlocat { get { return klass.ValCodlocat; } set { klass.ValCodlocat = value; } }
		private Locat _locat;
		[DisplayName("Locat")]
		[ShouldSerialize("Locat")]
		public virtual Locat Locat {
			get {
				if (!this.isEmptyModel && (_locat == null || (!string.IsNullOrEmpty(ValCodlocat) && (_locat.isEmptyModel || _locat.klass.QPrimaryKey != ValCodlocat))))
					_locat = Models.Locat.Find(ValCodlocat, m_userContext, Identifier, _fieldsToSerialize);
				if (_locat == null)
					_locat = new Models.Locat(m_userContext, true, _fieldsToSerialize);
				return _locat;
			}
			set { _locat = value; }
		}


		[DisplayName("GLN Extension Component")]
		/// <summary>Field : "GLN Extension Component" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Lcext.ValGlnext")]
		public string ValGlnext { get { return klass.ValGlnext; } set { klass.ValGlnext = value; } }

		[DisplayName("Space type")]
		/// <summary>Field : "Space type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Lcext.ValSpacetyp")]
		[DataArray("Spacetyp", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpacetyp { get { return klass.ValSpacetyp; } set { klass.ValSpacetyp = value; } }
		[JsonIgnore]
		public SelectList ArrayValspacetyp { get { return new SelectList(CSGenio.business.ArraySpacetyp.GetDictionary(), "Key", "Value", ValSpacetyp); } set { ValSpacetyp = value.SelectedValue as string; } }

		[DisplayName("Space")]
		/// <summary>Field : "Space" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Lcext.ValSpaceobs")]
		public string ValSpaceobs { get { return klass.ValSpaceobs; } set { klass.ValSpaceobs = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Lcext.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Lcext(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAlcext(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Lcext(UserContext userContext, CSGenioAlcext val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAlcext csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "locat":
						if (_locat == null)
							_locat = new Locat(m_userContext, true, _fieldsToSerialize);
						_locat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Lcext Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAlcext>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Lcext(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Lcext> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAlcext>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lcext>((r) => new Lcext(userCtx, r));
		}

// USE /[MANUAL GQT MODEL LCEXT]/
	}
}
