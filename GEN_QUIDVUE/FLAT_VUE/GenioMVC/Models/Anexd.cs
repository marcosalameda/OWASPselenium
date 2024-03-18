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
	public class Anexd : ModelBase
	{
		[JsonIgnore]
		public CSGenioAanexd klass { get { return baseklass as CSGenioAanexd; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValCodanexd")]
		public string ValCodanexd { get { return klass.ValCodanexd; } set { klass.ValCodanexd = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValCodequip")]
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
		

		[DisplayName("Attached")]
		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValDthranex")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDthranex { get { return klass.ValDthranex; } set { klass.ValDthranex = value ?? DateTime.MinValue; } }

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValDocument")]
		[Document("ValDocument", false, true, false, true)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }

		[DisplayName(">LANGUAGE")]
		/// <summary>Field : ">LANGUAGE" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValCodlang")]
		public string ValCodlang { get { return klass.ValCodlang; } set { klass.ValCodlang = value; } }
		private Langu _langu;
		[DisplayName("Langu")]
		[ShouldSerialize("Langu")]
		public virtual Langu Langu { 
			get { 
				if (!this.isEmptyModel && (_langu == null || (!string.IsNullOrEmpty(ValCodlang) && (_langu.isEmptyModel || _langu.klass.QPrimaryKey != ValCodlang))))
					_langu = Models.Langu.Find(ValCodlang, m_userContext, Identifier, _fieldsToSerialize);
				if (_langu == null)
					_langu = new Models.Langu(m_userContext, true, _fieldsToSerialize);
				return _langu;
			}
			set { _langu = value; } 
		}
		

		[DisplayName("Translated title")]
		/// <summary>Field : "Translated title" Tipo: "C" Formula: CT "TRADU[ANEXD->TITLE][TRADU->ATRADUZI][TRADU->TRADUZID][ANEXD->CODLANG][TRADU->CODIDIO2](DESC)"</summary>
		[ShouldSerialize("Anexd.ValTittradu")]
		public string ValTittradu { get { return klass.ValTittradu; } set { klass.ValTittradu = value; } }

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Anexd.ValReferenc")]
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Anexd.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Anexd(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAanexd(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Anexd(UserContext userContext, CSGenioAanexd val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAanexd csgenioa)
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
					case "langu":
						if (_langu == null)
							_langu = new Langu(m_userContext, true, _fieldsToSerialize);
						_langu.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Anexd Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAanexd>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Anexd(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Anexd> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAanexd>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Anexd>((r) => new Anexd(userCtx, r));
		}

// USE /[MANUAL GQT MODEL ANEXD]/
	}
}
