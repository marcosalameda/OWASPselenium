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
	public class Hpess : ModelBase
	{
		[JsonIgnore]
		public CSGenioAhpess klass { get { return baseklass as CSGenioAhpess; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValCodhpess")]
		public string ValCodhpess { get { return klass.ValCodhpess; } set { klass.ValCodhpess = value; } }

		[DisplayName("> PERSON")]
		/// <summary>Field : "> PERSON" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }

		private Pesso _pesso;
		[DisplayName("Pesso")]
		[ShouldSerialize("Pesso")]
		public virtual Pesso Pesso
		{
			get
			{
				if (!isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso))))
					_pesso = Models.Pesso.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				_pesso ??= new Models.Pesso(m_userContext, true, _fieldsToSerialize);
				return _pesso;
			}
			set { _pesso = value; }
		}

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }

		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		[ShouldSerialize("Cmpny")]
		public virtual Cmpny Cmpny
		{
			get
			{
				if (!isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre))))
					_cmpny = Models.Cmpny.Find(ValCodempre, m_userContext, Identifier, _fieldsToSerialize);
				_cmpny ??= new Models.Cmpny(m_userContext, true, _fieldsToSerialize);
				return _cmpny;
			}
			set { _cmpny = value; }
		}

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.Now;  } }

		[DisplayName("Author")]
		/// <summary>Field : "Author" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Hpess.ValAuthor")]
		public string ValAuthor { get { return klass.ValAuthor; } set { klass.ValAuthor = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Hpess.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Hpess(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAhpess(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Hpess(UserContext userContext, CSGenioAhpess val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAhpess csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						_pesso ??= new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cmpny":
						_cmpny ??= new Cmpny(m_userContext, true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Hpess Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAhpess>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Hpess(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Hpess> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAhpess>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Hpess>((r) => new Hpess(userCtx, r));
		}

// USE /[MANUAL GQT MODEL HPESS]/
	}
}
