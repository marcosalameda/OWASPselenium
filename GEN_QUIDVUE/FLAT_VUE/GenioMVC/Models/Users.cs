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
	public class Users : ModelBase
	{
		[JsonIgnore]
		public CSGenioAusers klass { get { return baseklass as CSGenioAusers; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Users.ValCodusers")]
		public string ValCodusers { get { return klass.ValCodusers; } set { klass.ValCodusers = value; } }

		[DisplayName(">>LOGIN")]
		/// <summary>Field : ">>LOGIN" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Users.ValCodpsw")]
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
		

		[DisplayName(">>PERSON")]
		/// <summary>Field : ">>PERSON" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Users.ValCodperso")]
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }
		private Perso _perso;
		[DisplayName("Perso")]
		[ShouldSerialize("Perso")]
		public virtual Perso Perso { 
			get { 
				if (!this.isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodperso) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodperso))))
					_perso = Models.Perso.Find(ValCodperso, m_userContext, Identifier, _fieldsToSerialize);
				if (_perso == null)
					_perso = new Models.Perso(m_userContext, true, _fieldsToSerialize);
				return _perso;
			}
			set { _perso = value; } 
		}
		

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Users.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Users(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAusers(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Users(UserContext userContext, CSGenioAusers val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAusers csgenioa)
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
					case "perso":
						if (_perso == null)
							_perso = new Perso(m_userContext, true, _fieldsToSerialize);
						_perso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Users Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAusers>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Users(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Users> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAusers>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Users>((r) => new Users(userCtx, r));
		}

// USE /[MANUAL GQT MODEL USERS]/
	}
}
