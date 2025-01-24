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
	public class Pwcom : ModelBase
	{
		[JsonIgnore]
		public CSGenioApwcom klass { get { return baseklass as CSGenioApwcom; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Pwcom.ValCodpwcom")]
		public string ValCodpwcom { get { return klass.ValCodpwcom; } set { klass.ValCodpwcom = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pwcom.ValCodpsw")]
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


		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Pwcom.ValCodpess1")]
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		[ShouldSerialize("Pess1")]
		public virtual Pess1 Pess1 {
			get {
				if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1))))
					_pess1 = Models.Pess1.Find(ValCodpess1, m_userContext, Identifier, _fieldsToSerialize);
				if (_pess1 == null)
					_pess1 = new Models.Pess1(m_userContext, true, _fieldsToSerialize);
				return _pess1;
			}
			set { _pess1 = value; }
		}


		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula: ++ "[PSW->NOME]"</summary>
		[ShouldSerialize("Pwcom.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Pwcom.ValFoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFoto { get { return new ImageModel(klass.ValFoto) { Ticket = ValFotoQTicket }; } set { klass.ValFoto = value; } }
		[JsonIgnore]
		public string ValFotoQTicket = null;

		[DisplayName("Identification")]
		/// <summary>Field : "Identification" Tipo: "N" Formula: ++ "[PESS1->IDFUNCIO]"</summary>
		[ShouldSerialize("Pwcom.ValNridenti")]
		[NumericAttribute(0)]
		public decimal? ValNridenti { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNridenti, 0)); } set { klass.ValNridenti = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Pwcom.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Pwcom(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApwcom(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pwcom(UserContext userContext, CSGenioApwcom val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioApwcom csgenioa)
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
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(m_userContext, true, _fieldsToSerialize);
						_pess1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Pwcom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApwcom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pwcom(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Pwcom> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApwcom>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pwcom>((r) => new Pwcom(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PWCOM]/
	}
}
