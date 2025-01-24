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
	public class Airto : ModelBase
	{
		[JsonIgnore]
		public CSGenioAairto klass { get { return baseklass as CSGenioAairto; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Airto.ValCodairpt")]
		public string ValCodairpt { get { return klass.ValCodairpt; } set { klass.ValCodairpt = value; } }

		[DisplayName("Airport Name")]
		/// <summary>Field : "Airport Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Airto.ValAirptnam")]
		public string ValAirptnam { get { return klass.ValAirptnam; } set { klass.ValAirptnam = value; } }

		[DisplayName("IATA Code")]
		/// <summary>Field : "IATA Code" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Airto.ValIatacode")]
		public string ValIatacode { get { return klass.ValIatacode; } set { klass.ValIatacode = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Airto.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }
		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry {
			get {
				if (!this.isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry))))
					_cntry = Models.Cntry.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				if (_cntry == null)
					_cntry = new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Airto.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Airto(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAairto(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Airto(UserContext userContext, CSGenioAairto val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAairto csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						if (_cntry == null)
							_cntry = new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Airto Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAairto>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Airto(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Airto> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAairto>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Airto>((r) => new Airto(userCtx, r));
		}

// USE /[MANUAL GQT MODEL AIRTO]/
	}
}
