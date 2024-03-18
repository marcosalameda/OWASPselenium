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
	public class Repar : ModelBase
	{
		[JsonIgnore]
		public CSGenioArepar klass { get { return baseklass as CSGenioArepar; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValCodrepar")]
		public string ValCodrepar { get { return klass.ValCodrepar; } set { klass.ValCodrepar = value; } }

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip { 
			get { 
				if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				if (_equip == null)
					_equip = new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; } 
		}
		

		[DisplayName(">COMPANY")]
		/// <summary>Field : ">COMPANY" Tipo: "CE" Formula: ++ "[EQUIP->CODEMPRE]"</summary>
		[ShouldSerialize("Repar.ValCodempre")]
		public string ValCodempre { get { return klass.ValCodempre; } set { klass.ValCodempre = value; } }
		private Cmpny _cmpny;
		[DisplayName("Cmpny")]
		[ShouldSerialize("Cmpny")]
		public virtual Cmpny Cmpny { 
			get { 
				if (!this.isEmptyModel && (_cmpny == null || (!string.IsNullOrEmpty(ValCodempre) && (_cmpny.isEmptyModel || _cmpny.klass.QPrimaryKey != ValCodempre))))
					_cmpny = Models.Cmpny.Find(ValCodempre, m_userContext, Identifier, _fieldsToSerialize);
				if (_cmpny == null)
					_cmpny = new Models.Cmpny(m_userContext, true, _fieldsToSerialize);
				return _cmpny;
			}
			set { _cmpny = value; } 
		}
		

		[DisplayName("Fixed in")]
		/// <summary>Field : "Fixed in" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValDtrepara")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtrepara { get { return klass.ValDtrepara; } set { klass.ValDtrepara = value ?? DateTime.MinValue; } }

		[DisplayName("No rumour in the Company")]
		/// <summary>Field : "No rumour in the Company" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValNrrepara")]
		[NumericAttribute(0)]
		public decimal? ValNrrepara { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrrepara, 0)); } set { klass.ValNrrepara = Convert.ToDouble(value); } }

		[DisplayName("Technical area")]
		/// <summary>Field : "Technical area" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValTipoarea")]
		[DataArray("Areatecn", GenioMVC.Helpers.ArrayType.Character)]
		public string ValTipoarea { get { return klass.ValTipoarea; } set { klass.ValTipoarea = value; } }
		[JsonIgnore]
		public SelectList ArrayValtipoarea { get { return new SelectList(CSGenio.business.ArrayAreatecn.GetDictionary(), "Key", "Value", ValTipoarea); } set { ValTipoarea = value.SelectedValue as string; } }

		[DisplayName(">SPECIALTY")]
		/// <summary>Field : ">SPECIALTY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValCodespec")]
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
		

		[DisplayName(">CATEGORy")]
		/// <summary>Field : ">CATEGORy" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValCodcateg")]
		public string ValCodcateg { get { return klass.ValCodcateg; } set { klass.ValCodcateg = value; } }
		private Cate1 _cate1;
		[DisplayName("Cate1")]
		[ShouldSerialize("Cate1")]
		public virtual Cate1 Cate1 { 
			get { 
				if (!this.isEmptyModel && (_cate1 == null || (!string.IsNullOrEmpty(ValCodcateg) && (_cate1.isEmptyModel || _cate1.klass.QPrimaryKey != ValCodcateg))))
					_cate1 = Models.Cate1.Find(ValCodcateg, m_userContext, Identifier, _fieldsToSerialize);
				if (_cate1 == null)
					_cate1 = new Models.Cate1(m_userContext, true, _fieldsToSerialize);
				return _cate1;
			}
			set { _cate1 = value; } 
		}
		

		[DisplayName(">REPAIRER")]
		/// <summary>Field : ">REPAIRER" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValCodpesso")]
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
		

		[DisplayName("Description of the repair")]
		/// <summary>Field : "Description of the repair" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValDescript")]
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }

		[DisplayName("Spent on hours")]
		/// <summary>Field : "Spent on hours" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Repar.ValHours")]
		[NumericAttribute(0)]
		public decimal? ValHours { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValHours, 0)); } set { klass.ValHours = Convert.ToDouble(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Repar.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Repar(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioArepar(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Repar(UserContext userContext, CSGenioArepar val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioArepar csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						if (_equip == null)
							_equip = new Equip(m_userContext, true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cmpny":
						if (_cmpny == null)
							_cmpny = new Cmpny(m_userContext, true, _fieldsToSerialize);
						_cmpny.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "speci":
						if (_speci == null)
							_speci = new Speci(m_userContext, true, _fieldsToSerialize);
						_speci.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "cate1":
						if (_cate1 == null)
							_cate1 = new Cate1(m_userContext, true, _fieldsToSerialize);
						_cate1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(m_userContext, true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Repar Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArepar>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Repar(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Repar> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArepar>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Repar>((r) => new Repar(userCtx, r));
		}

// USE /[MANUAL GQT MODEL REPAR]/
	}
}
