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
	public class Cattp : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcattp klass { get { return baseklass as CSGenioAcattp; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Cattp.ValCodtpcat")]
		public string ValCodtpcat { get { return klass.ValCodtpcat; } set { klass.ValCodtpcat = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Cattp.ValCodsbcat")]
		public string ValCodsbcat { get { return klass.ValCodsbcat; } set { klass.ValCodsbcat = value; } }
		private Sbcat _sbcat;
		[DisplayName("Sbcat")]
		[ShouldSerialize("Sbcat")]
		public virtual Sbcat Sbcat { 
			get { 
				if (!this.isEmptyModel && (_sbcat == null || (!string.IsNullOrEmpty(ValCodsbcat) && (_sbcat.isEmptyModel || _sbcat.klass.QPrimaryKey != ValCodsbcat))))
					_sbcat = Models.Sbcat.Find(ValCodsbcat, m_userContext, Identifier, _fieldsToSerialize);
				if (_sbcat == null)
					_sbcat = new Models.Sbcat(m_userContext, true, _fieldsToSerialize);
				return _sbcat;
			}
			set { _sbcat = value; } 
		}
		

		[DisplayName("Category type")]
		/// <summary>Field : "Category type" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Cattp.ValTpcatego")]
		public string ValTpcatego { get { return klass.ValTpcatego; } set { klass.ValTpcatego = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Cattp.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Cattp(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcattp(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Cattp(UserContext userContext, CSGenioAcattp val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAcattp csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "sbcat":
						if (_sbcat == null)
							_sbcat = new Sbcat(m_userContext, true, _fieldsToSerialize);
						_sbcat.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Cattp Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcattp>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Cattp(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Cattp> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcattp>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Cattp>((r) => new Cattp(userCtx, r));
		}

// USE /[MANUAL GQT MODEL CATTP]/
	}
}
