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
	public class Noti1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAnoti1 klass { get { return baseklass as CSGenioAnoti1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValCodnotif")]
		public string ValCodnotif { get { return klass.ValCodnotif; } set { klass.ValCodnotif = value; } }

		[DisplayName("No. of the dadato")]
		/// <summary>Field : "No. of the dadato" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValNrcomoda")]
		[NumericAttribute(0)]
		public decimal? ValNrcomoda { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNrcomoda, 0)); } set { klass.ValNrcomoda = Convert.ToDecimal(value); } }

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValBegin")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValBegin { get { return klass.ValBegin; } set { klass.ValBegin = value ?? DateTime.MinValue; } }

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValEnd")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }

		[DisplayName("Recipient's email")]
		/// <summary>Field : "Recipient's email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Notification ID that generated the message")]
		/// <summary>Field : "Notification ID that generated the message" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValIdnotif")]
		public string ValIdnotif { get { return klass.ValIdnotif; } set { klass.ValIdnotif = value; } }

		[DisplayName("Message ID")]
		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValIdmsg")]
		public string ValIdmsg { get { return klass.ValIdmsg; } set { klass.ValIdmsg = value; } }

		[DisplayName("Text of the sent message")]
		/// <summary>Field : "Text of the sent message" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValMessage")]
		[DataType(DataType.MultilineText)]
		public string ValMessage { get { return klass.ValMessage; } set { klass.ValMessage = value; } }

		[DisplayName("Error sending email")]
		/// <summary>Field : "Error sending email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValMailerr")]
		public string ValMailerr { get { return klass.ValMailerr; } set { klass.ValMailerr = value; } }

		[DisplayName("Recipient")]
		/// <summary>Field : "Recipient" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("Creation: Date")]
		/// <summary>Field : "Creation: Date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Creation: Operator")]
		/// <summary>Field : "Creation: Operator" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Returned")]
		/// <summary>Field : "Returned" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValReturned")]
		public bool ValReturned { get { return Convert.ToBoolean(klass.ValReturned); } set { klass.ValReturned = Convert.ToInt32(value); } }

		[DisplayName("Return")]
		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValDtdevolu")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtdevolu { get { return klass.ValDtdevolu; } set { klass.ValDtdevolu = value ?? DateTime.MinValue; } }

		[DisplayName("Recipient key 'Comodatário'")]
		/// <summary>Field : "Recipient key 'Comodatário'" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Noti1.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		private Pess2 _pess2;
		[DisplayName("Pess2")]
		[ShouldSerialize("Pess2")]
		public virtual Pess2 Pess2 {
			get {
				if (!this.isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpesso))))
					_pess2 = Models.Pess2.Find(ValCodpesso, m_userContext, Identifier, _fieldsToSerialize);
				if (_pess2 == null)
					_pess2 = new Models.Pess2(m_userContext, true, _fieldsToSerialize);
				return _pess2;
			}
			set { _pess2 = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Noti1.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Noti1(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAnoti1(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Noti1(UserContext userContext, CSGenioAnoti1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAnoti1 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pess2":
						if (_pess2 == null)
							_pess2 = new Pess2(m_userContext, true, _fieldsToSerialize);
						_pess2.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Noti1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAnoti1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Noti1(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Noti1> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAnoti1>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Noti1>((r) => new Noti1(userCtx, r));
		}

// USE /[MANUAL GQT MODEL NOTI1]/
	}
}
