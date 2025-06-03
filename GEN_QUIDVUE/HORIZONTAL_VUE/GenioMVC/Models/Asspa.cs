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
	public class Asspa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAasspa klass { get { return baseklass as CSGenioAasspa; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValCodasspa")]
		public string ValCodasspa { get { return klass.ValCodasspa; } set { klass.ValCodasspa = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValCodasset")]
		public string ValCodasset { get { return klass.ValCodasset; } set { klass.ValCodasset = value; } }

		private Asset _asset;
		[DisplayName("Asset")]
		[ShouldSerialize("Asset")]
		public virtual Asset Asset
		{
			get
			{
				if (!isEmptyModel && (_asset == null || (!string.IsNullOrEmpty(ValCodasset) && (_asset.isEmptyModel || _asset.klass.QPrimaryKey != ValCodasset))))
					_asset = Models.Asset.Find(ValCodasset, m_userContext, Identifier, _fieldsToSerialize);
				_asset ??= new Models.Asset(m_userContext, true, _fieldsToSerialize);
				return _asset;
			}
			set { _asset = value; }
		}

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValCodkinde")]
		public string ValCodkinde { get { return klass.ValCodkinde; } set { klass.ValCodkinde = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValCodparam")]
		public string ValCodparam { get { return klass.ValCodparam; } set { klass.ValCodparam = value; } }

		private Param _param;
		[DisplayName("Param")]
		[ShouldSerialize("Param")]
		public virtual Param Param
		{
			get
			{
				if (!isEmptyModel && (_param == null || (!string.IsNullOrEmpty(ValCodparam) && (_param.isEmptyModel || _param.klass.QPrimaryKey != ValCodparam))))
					_param = Models.Param.Find(ValCodparam, m_userContext, Identifier, _fieldsToSerialize);
				_param ??= new Models.Param(m_userContext, true, _fieldsToSerialize);
				return _param;
			}
			set { _param = value; }
		}

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValDatatype")]
		[DataArray("Datatype", GenioMVC.Helpers.ArrayType.Character)]
		public string ValDatatype { get { return klass.ValDatatype; } set { klass.ValDatatype = value; } }
		[JsonIgnore]
		public SelectList ArrayValdatatype { get { return new SelectList(CSGenio.business.ArrayDatatype.GetDictionary(), "Key", "Value", ValDatatype); } set { ValDatatype = value.SelectedValue as string; } }

		[DisplayName("Decimal places")]
		/// <summary>Field : "Decimal places" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValDecimalplaces")]
		[NumericAttribute(0)]
		public decimal? ValDecimalplaces { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDecimalplaces, 0)); } set { klass.ValDecimalplaces = Convert.ToDecimal(value); } }

		[DisplayName("Text")]
		/// <summary>Field : "Text" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValText")]
		public string ValText { get { return klass.ValText; } set { klass.ValText = value; } }

		[DisplayName("Quantity")]
		/// <summary>Field : "Quantity" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValQuantity")]
		[NumericAttribute(4)]
		public decimal? ValQuantity { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQuantity, 4)); } set { klass.ValQuantity = Convert.ToDecimal(value); } }

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Asspa.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("To show")]
		/// <summary>Field : "To show" Tipo: "C" Formula: + "iif([ASSPA->DATATYPE]=="T",[ASSPA->TEXT],iif([ASSPA->DATATYPE]=="N",NumericToString([ASSPA->QUANTITY],0),iif([ASSPA->DATATYPE]=="D",NumericToString(Year([ASSPA->DATE]),0)+"-"+RIGHT("00"+NumericToString(Month([ASSPA->DATE]),0),2)+"-"+RIGHT("00"+NumericToString(Day([ASSPA->DATE]),0),2),"") ) )"</summary>
		[ShouldSerialize("Asspa.ValToshow")]
		public string ValToshow { get { return klass.ValToshow; } set { klass.ValToshow = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Asspa.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Asspa(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAasspa(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Asspa(UserContext userContext, CSGenioAasspa val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAasspa csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "asset":
						_asset ??= new Asset(m_userContext, true, _fieldsToSerialize);
						_asset.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "param":
						_param ??= new Param(m_userContext, true, _fieldsToSerialize);
						_param.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Asspa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAasspa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Asspa(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Asspa> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAasspa>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Asspa>((r) => new Asspa(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ASSPA]/
	}
}
