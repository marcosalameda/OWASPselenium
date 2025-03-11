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
	public class Messa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmessa klass { get { return baseklass as CSGenioAmessa; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValCodmessa")]
		public string ValCodmessa { get { return klass.ValCodmessa; } set { klass.ValCodmessa = value; } }

		[DisplayName("Notification ID")]
		/// <summary>Field : "Notification ID" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValIdnotif")]
		public string ValIdnotif { get { return klass.ValIdnotif; } set { klass.ValIdnotif = value; } }

		[DisplayName("Message ID")]
		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValIdmsg")]
		public string ValIdmsg { get { return klass.ValIdmsg; } set { klass.ValIdmsg = value; } }

		[DisplayName("To whom the message was sent")]
		/// <summary>Field : "To whom the message was sent" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValDesignat")]
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }

		[DisplayName("E-mail to whom the message was sent")]
		/// <summary>Field : "E-mail to whom the message was sent" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Message")]
		/// <summary>Field : "Message" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValMessage")]
		[DataType(DataType.MultilineText)]
		public string ValMessage { get { return klass.ValMessage; } set { klass.ValMessage = value; } }

		[DisplayName("E-mail sent?")]
		/// <summary>Field : "E-mail sent?" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValMailsent")]
		public bool ValMailsent { get { return Convert.ToBoolean(klass.ValMailsent); } set { klass.ValMailsent = Convert.ToInt32(value); } }

		[DisplayName("Error sending mail")]
		/// <summary>Field : "Error sending mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValMailerr")]
		public string ValMailerr { get { return klass.ValMailerr; } set { klass.ValMailerr = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("'Entity'")]
		/// <summary>Field : "'Entity'" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValCodentit")]
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

		[DisplayName("'Person'")]
		/// <summary>Field : "'Person'" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValCodperso")]
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

		[DisplayName("Document number")]
		/// <summary>Field : "Document number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Messa.ValDocum_nr")]
		[NumericAttribute(0)]
		public decimal? ValDocum_nr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDocum_nr, 0)); } set { klass.ValDocum_nr = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Messa.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Messa(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmessa(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Messa(UserContext userContext, CSGenioAmessa val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAmessa csgenioa)
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
		public static Messa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmessa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Messa(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Messa> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmessa>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Messa>((r) => new Messa(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MESSA]/
	}
}
