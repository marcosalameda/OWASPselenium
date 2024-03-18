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
	public class Pwreg : ModelBase
	{
		[JsonIgnore]
		public CSGenioApwreg klass { get { return baseklass as CSGenioApwreg; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pwreg.ValCodpwreg")]
		public string ValCodpwreg { get { return klass.ValCodpwreg; } set { klass.ValCodpwreg = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pwreg.ValCodpsw")]
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		private Psw _psw;
		[DisplayName("Psw")]
		[ShouldSerialize("Psw")]
		public virtual Psw Psw { 
			get { 
				if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw))))
					_psw = Models.Psw.Find(ValCodpsw, m_userContext, Identifier, _fieldsToSerialize);
				if (_psw == null)
					_psw = new Models.Psw(m_userContext, true, _fieldsToSerialize);
				return _psw;
			}
			set { _psw = value; } 
		}
		

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pwreg.ValCodregia")]
		public string ValCodregia { get { return klass.ValCodregia; } set { klass.ValCodregia = value; } }
		private Regio _regio;
		[DisplayName("Regio")]
		[ShouldSerialize("Regio")]
		public virtual Regio Regio { 
			get { 
				if (!this.isEmptyModel && (_regio == null || (!string.IsNullOrEmpty(ValCodregia) && (_regio.isEmptyModel || _regio.klass.QPrimaryKey != ValCodregia))))
					_regio = Models.Regio.Find(ValCodregia, m_userContext, Identifier, _fieldsToSerialize);
				if (_regio == null)
					_regio = new Models.Regio(m_userContext, true, _fieldsToSerialize);
				return _regio;
			}
			set { _regio = value; } 
		}
		

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pwreg.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pwreg(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApwreg(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Pwreg(UserContext userContext, CSGenioApwreg val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioApwreg csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "psw":
						if (_psw == null)
							_psw = new Psw(m_userContext, true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "regio":
						if (_regio == null)
							_regio = new Regio(m_userContext, true, _fieldsToSerialize);
						_regio.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Pwreg Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApwreg>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pwreg(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pwreg> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApwreg>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pwreg>((r) => new Pwreg(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PWREG]/
	}
}
