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
	public class Tpcon : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpcon klass { get { return baseklass as CSGenioAtpcon; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tpcon.ValCodtpcon")]
		public string ValCodtpcon { get { return klass.ValCodtpcon; } set { klass.ValCodtpcon = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tpcon.ValCodgenre")]
		public string ValCodgenre { get { return klass.ValCodgenre; } set { klass.ValCodgenre = value; } }
		private Genre _genre;
		[DisplayName("Genre")]
		[ShouldSerialize("Genre")]
		public virtual Genre Genre {
			get {
				if (!this.isEmptyModel && (_genre == null || (!string.IsNullOrEmpty(ValCodgenre) && (_genre.isEmptyModel || _genre.klass.QPrimaryKey != ValCodgenre))))
					_genre = Models.Genre.Find(ValCodgenre, m_userContext, Identifier, _fieldsToSerialize);
				if (_genre == null)
					_genre = new Models.Genre(m_userContext, true, _fieldsToSerialize);
				return _genre;
			}
			set { _genre = value; }
		}


		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Tpcon.ValGenconta")]
		[DataArray("Genconta", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGenconta { get { return klass.ValGenconta; } set { klass.ValGenconta = value; } }
		[JsonIgnore]
		public SelectList ArrayValgenconta { get { return new SelectList(CSGenio.business.ArrayGenconta.GetDictionary(), "Key", "Value", ValGenconta); } set { ValGenconta = value.SelectedValue as string; } }

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tpcon.ValTipocont")]
		public string ValTipocont { get { return klass.ValTipocont; } set { klass.ValTipocont = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tpcon.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tpcon(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtpcon(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpcon(UserContext userContext, CSGenioAtpcon val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAtpcon csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "genre":
						if (_genre == null)
							_genre = new Genre(m_userContext, true, _fieldsToSerialize);
						_genre.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpcon Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpcon>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpcon(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tpcon> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpcon>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpcon>((r) => new Tpcon(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TPCON]/
	}
}
