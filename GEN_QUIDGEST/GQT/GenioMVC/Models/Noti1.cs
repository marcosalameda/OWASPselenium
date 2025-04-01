using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using SelectList = System.Web.Mvc.SelectList;

namespace GenioMVC.Models
{
	public class Noti1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAnoti1 klass { get { return baseklass as CSGenioAnoti1; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodnotif { get { return klass.ValCodnotif; } set { klass.ValCodnotif = value; } }
		public bool ShouldSerializeValCodnotif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValCodnotif");

		[DisplayName("No. of the dadato")]
		/// <summary>Field : "No. of the dadato" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNrcomoda { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNrcomoda, 0)); } set { klass.ValNrcomoda = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNrcomoda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValNrcomoda");

		[DisplayName("Beginning")]
		/// <summary>Field : "Beginning" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValBegin { get { return klass.ValBegin; } set { klass.ValBegin = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValBegin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValBegin");

		[DisplayName("End")]
		/// <summary>Field : "End" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValEnd { get { return klass.ValEnd; } set { klass.ValEnd = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValEnd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValEnd");

		[DisplayName("Recipient's email")]
		/// <summary>Field : "Recipient's email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValEmail");

		[DisplayName("Notification ID that generated the message")]
		/// <summary>Field : "Notification ID that generated the message" Tipo: "C" Formula:  ""</summary>
		public string ValIdnotif { get { return klass.ValIdnotif; } set { klass.ValIdnotif = value; } }
		public bool ShouldSerializeValIdnotif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValIdnotif");

		[DisplayName("Message ID")]
		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdmsg { get { return klass.ValIdmsg; } set { klass.ValIdmsg = value; } }
		public bool ShouldSerializeValIdmsg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValIdmsg");

		[DisplayName("Text of the sent message")]
		/// <summary>Field : "Text of the sent message" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMessage { get { return klass.ValMessage; } set { klass.ValMessage = value; } }
		public bool ShouldSerializeValMessage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValMessage");

		[DisplayName("Error sending email")]
		/// <summary>Field : "Error sending email" Tipo: "C" Formula:  ""</summary>
		public string ValMailerr { get { return klass.ValMailerr; } set { klass.ValMailerr = value; } }
		public bool ShouldSerializeValMailerr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValMailerr");

		[DisplayName("Recipient")]
		/// <summary>Field : "Recipient" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValDesignat");

		[DisplayName("Creation: Date")]
		/// <summary>Field : "Creation: Date" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValCreatdat");

		[DisplayName("Creation: Operator")]
		/// <summary>Field : "Creation: Operator" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValCreatope");

		[DisplayName("Returned")]
		/// <summary>Field : "Returned" Tipo: "L" Formula:  ""</summary>
		public bool ValReturned { get { return Convert.ToBoolean(klass.ValReturned); } set { klass.ValReturned = Convert.ToInt32(value); } }
		public bool ShouldSerializeValReturned() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValReturned");

		[DisplayName("Return")]
		/// <summary>Field : "Return" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDtdevolu { get { return klass.ValDtdevolu; } set { klass.ValDtdevolu = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtdevolu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValDtdevolu");

		[DisplayName("Recipient key 'Comodatário'")]
		/// <summary>Field : "Recipient key 'Comodatário'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValCodpesso");
		private Pess2 _pess2;
		[DisplayName("Pess2")]
		public virtual Pess2 Pess2 { get { if (!this.isEmptyModel && (_pess2 == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pess2.isEmptyModel || _pess2.klass.QPrimaryKey != ValCodpesso)))) _pess2 = Models.Pess2.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pess2 == null) _pess2 = new Models.Pess2(true, _fieldsToSerialize); return _pess2; } set { _pess2 = value; } }
		public bool ShouldSerializePess2 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess2");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Noti1.ValZzstate");

		public Noti1() : this(UserContext.Current.User) { }

		public Noti1(User u)
		{
			this.klass = new CSGenioAnoti1(u);
		}

		public Noti1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Noti1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Noti1(bool isEmpty) : this(isEmpty, null) { }

		public Noti1(CSGenioAnoti1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Noti1(CSGenioAnoti1 val) : this(val, null) { }

		public Noti1(CSGenioAnoti1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Noti1(CSGenioAnoti1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_pess2 = new Pess2(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Noti1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			return Find(id, UserContext.Current, identifier, fieldsToSerialize, fieldsToQuery);
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
			return record == null ? null : new Noti1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Noti1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAnoti1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Noti1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAnoti1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAnoti1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAnoti1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAnoti1>(false, args, numRegs: -1);
		}

		public static List<Noti1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAnoti1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Noti1>((r) => new Noti1(r));
		}

// USE /[MANUAL GQT MODEL NOTI1]/
	}
}
