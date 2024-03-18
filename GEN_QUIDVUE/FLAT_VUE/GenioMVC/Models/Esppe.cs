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
	public class Esppe : ModelBase
	{
		[JsonIgnore]
		public CSGenioAesppe klass { get { return baseklass as CSGenioAesppe; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Esppe.ValCodesppe")]
		public string ValCodesppe { get { return klass.ValCodesppe; } set { klass.ValCodesppe = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Esppe.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		private Pesso _pesso;
		[DisplayName("Pesso")]
		[ShouldSerialize("Pesso")]
		public virtual Pesso Pesso { 
			get { 
				if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso))))
					_pesso = Models.Pesso.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				if (_pesso == null)
					_pesso = new Models.Pesso(m_userContext, true, _fieldsToSerialize);
				return _pesso;
			}
			set { _pesso = value; } 
		}
		

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Esppe.ValCodespec")]
		public string ValCodespec { get { return klass.ValCodespec; } set { klass.ValCodespec = value; } }
		private Speci _speci;
		[DisplayName("Speci")]
		[ShouldSerialize("Speci")]
		public virtual Speci Speci { 
			get { 
				if (!this.isEmptyModel && (_speci == null || (!string.IsNullOrEmpty(ValCodespec) && (_speci.isEmptyModel || _speci.klass.QPrimaryKey != ValCodespec))))
					_speci = Models.Speci.Find(ValCodespec, m_userContext, Identifier, _fieldsToSerialize);
				if (_speci == null)
					_speci = new Models.Speci(m_userContext, true, _fieldsToSerialize);
				return _speci;
			}
			set { _speci = value; } 
		}
		

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Esppe.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Esppe(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAesppe(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Esppe(UserContext userContext, CSGenioAesppe val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAesppe csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "speci":
						if (_speci == null)
							_speci = new Speci(m_userContext, true, _fieldsToSerialize);
						_speci.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Esppe Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAesppe>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Esppe(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Esppe> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAesppe>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Esppe>((r) => new Esppe(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ESPPE]/
	}
}
