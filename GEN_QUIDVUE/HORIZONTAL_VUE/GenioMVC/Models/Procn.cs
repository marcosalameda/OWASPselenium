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
	public class Procn : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprocn klass { get { return baseklass as CSGenioAprocn; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValCodprocn")]
		public string ValCodprocn { get { return klass.ValCodprocn; } set { klass.ValCodprocn = value; } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValTelephon")]
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula: DF "[Today]"</summary>
		[ShouldSerialize("Procn.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("Property")]
		/// <summary>Field : "Property" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Procn.ValCodprope")]
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
		[ShouldSerialize("Procn.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Procn(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAprocn(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Procn(UserContext userContext, CSGenioAprocn val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAprocn csgenioa)
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
		public static Procn Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprocn>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Procn(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Procn> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprocn>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Procn>((r) => new Procn(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PROCN]/
	}
}
