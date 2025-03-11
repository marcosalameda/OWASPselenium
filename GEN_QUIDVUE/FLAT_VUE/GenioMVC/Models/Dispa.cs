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
	public class Dispa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdispa klass { get { return baseklass as CSGenioAdispa; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValCoddispa")]
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }

		[DisplayName(">>CUSTOMER")]
		/// <summary>Field : ">>CUSTOMER" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValCodentit")]
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }

		private Entit _entit;
		[DisplayName("Entit")]
		[ShouldSerialize("Entit")]
		public virtual Entit Entit
		{
			get
			{
				if (!isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit))))
					_entit = Models.Entit.Find(ValCodentit, m_userContext, Identifier, _fieldsToSerialize);
				_entit ??= new Models.Entit(m_userContext, true, _fieldsToSerialize);
				return _entit;
			}
			set { _entit = value; }
		}

		[DisplayName(">> STATUS")]
		/// <summary>Field : ">> STATUS" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValCoddisst")]
		public string ValCoddisst { get { return klass.ValCoddisst; } set { klass.ValCoddisst = value; } }

		private Disst _disst;
		[DisplayName("Disst")]
		[ShouldSerialize("Disst")]
		public virtual Disst Disst
		{
			get
			{
				if (!isEmptyModel && (_disst == null || (!string.IsNullOrEmpty(ValCoddisst) && (_disst.isEmptyModel || _disst.klass.QPrimaryKey != ValCoddisst))))
					_disst = Models.Disst.Find(ValCoddisst, m_userContext, Identifier, _fieldsToSerialize);
				_disst ??= new Models.Disst(m_userContext, true, _fieldsToSerialize);
				return _disst;
			}
			set { _disst = value; }
		}

		[DisplayName("Is prepared")]
		/// <summary>Field : "Is prepared" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValIsprepar")]
		public bool ValIsprepar { get { return Convert.ToBoolean(klass.ValIsprepar); } set { klass.ValIsprepar = Convert.ToInt32(value); } }

		[DisplayName("Dispatch date")]
		/// <summary>Field : "Dispatch date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValDispadt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDispadt { get { return klass.ValDispadt; } set { klass.ValDispadt = value ?? DateTime.MinValue; } }

		[DisplayName("Dispatch number")]
		/// <summary>Field : "Dispatch number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValDispanr")]
		[NumericAttribute(0)]
		public decimal? ValDispanr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDispanr, 0)); } set { klass.ValDispanr = Convert.ToDecimal(value); } }

		[DisplayName("Prepared")]
		/// <summary>Field : "Prepared" Tipo: "DT" Formula: DF "iif(emptyL([DISPA->ISPREPAR])==1,[ZEROD],[Today])"</summary>
		[ShouldSerialize("Dispa.ValPrepared")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPrepared { get { return klass.ValPrepared; } set { klass.ValPrepared = value ?? DateTime.MinValue; } }

		[DisplayName(">>PERSON RESPONSIBLE")]
		/// <summary>Field : ">>PERSON RESPONSIBLE" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Dispa.ValCodperso")]
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }

		private Perso _perso;
		[DisplayName("Perso")]
		[ShouldSerialize("Perso")]
		public virtual Perso Perso
		{
			get
			{
				if (!isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodperso) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodperso))))
					_perso = Models.Perso.Find(ValCodperso, m_userContext, Identifier, _fieldsToSerialize);
				_perso ??= new Models.Perso(m_userContext, true, _fieldsToSerialize);
				return _perso;
			}
			set { _perso = value; }
		}

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "AC" Formula: + "iif(emptyD([DISPA->DISPADT])==0,"D",iif(emptyD([DISPA->PREPARED])==0,"P","I"))"</summary>
		[ShouldSerialize("Dispa.ValStatus")]
		[DataArray("Dispstat", GenioMVC.Helpers.ArrayType.Character)]
		public string ValStatus { get { return klass.ValStatus; } set { klass.ValStatus = value; } }
		[JsonIgnore]
		public SelectList ArrayValstatus { get { return new SelectList(CSGenio.business.ArrayDispstat.GetDictionary(), "Key", "Value", ValStatus); } set { ValStatus = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Dispa.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Dispa(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAdispa(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dispa(UserContext userContext, CSGenioAdispa val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAdispa csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						_entit ??= new Entit(m_userContext, true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "disst":
						_disst ??= new Disst(m_userContext, true, _fieldsToSerialize);
						_disst.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "perso":
						_perso ??= new Perso(m_userContext, true, _fieldsToSerialize);
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
		public static Dispa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdispa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Dispa(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Dispa> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdispa>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dispa>((r) => new Dispa(userCtx, r));
		}

// USE /[MANUAL GQT MODEL DISPA]/
	}
}
