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
	public class Genre : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgenre klass { get { return baseklass as CSGenioAgenre; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Genre.ValCodgenre")]
		public string ValCodgenre { get { return klass.ValCodgenre; } set { klass.ValCodgenre = value; } }

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Genre.ValGender")]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }

		[DisplayName("Gender contact")]
		/// <summary>Field : "Gender contact" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Genre.ValAgencont")]
		[DataArray("Genconta", GenioMVC.Helpers.ArrayType.Character)]
		public string ValAgencont { get { return klass.ValAgencont; } set { klass.ValAgencont = value; } }
		[JsonIgnore]
		public SelectList ArrayValagencont { get { return new SelectList(CSGenio.business.ArrayGenconta.GetDictionary(), "Key", "Value", ValAgencont); } set { ValAgencont = value.SelectedValue as string; } }

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Genre.ValBackcolo")]
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }

		[DisplayName("Text color")]
		/// <summary>Field : "Text color" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Genre.ValTextcolo")]
		public string ValTextcolo { get { return klass.ValTextcolo; } set { klass.ValTextcolo = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Genre.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Genre(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgenre(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Genre(UserContext userContext, CSGenioAgenre val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAgenre csgenioa)
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
		public static Genre Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgenre>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Genre(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Genre> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgenre>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Genre>((r) => new Genre(userCtx, r));
		}

// USE /[MANUAL GQT MODEL GENRE]/
	}
}
