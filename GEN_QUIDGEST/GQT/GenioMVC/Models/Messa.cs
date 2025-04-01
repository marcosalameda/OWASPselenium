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
	public class Messa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmessa klass { get { return baseklass as CSGenioAmessa; } set { baseklass = value; } }

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
		public string ValCodmessa { get { return klass.ValCodmessa; } set { klass.ValCodmessa = value; } }
		public bool ShouldSerializeValCodmessa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValCodmessa");

		[DisplayName("Notification ID")]
		/// <summary>Field : "Notification ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdnotif { get { return klass.ValIdnotif; } set { klass.ValIdnotif = value; } }
		public bool ShouldSerializeValIdnotif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValIdnotif");

		[DisplayName("Message ID")]
		/// <summary>Field : "Message ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdmsg { get { return klass.ValIdmsg; } set { klass.ValIdmsg = value; } }
		public bool ShouldSerializeValIdmsg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValIdmsg");

		[DisplayName("To whom the message was sent")]
		/// <summary>Field : "To whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValDesignat");

		[DisplayName("E-mail to whom the message was sent")]
		/// <summary>Field : "E-mail to whom the message was sent" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValEmail");

		[DisplayName("Message")]
		/// <summary>Field : "Message" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMessage { get { return klass.ValMessage; } set { klass.ValMessage = value; } }
		public bool ShouldSerializeValMessage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValMessage");

		[DisplayName("E-mail sent?")]
		/// <summary>Field : "E-mail sent?" Tipo: "L" Formula:  ""</summary>
		public bool ValMailsent { get { return Convert.ToBoolean(klass.ValMailsent); } set { klass.ValMailsent = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMailsent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValMailsent");

		[DisplayName("Error sending mail")]
		/// <summary>Field : "Error sending mail" Tipo: "C" Formula:  ""</summary>
		public string ValMailerr { get { return klass.ValMailerr; } set { klass.ValMailerr = value; } }
		public bool ShouldSerializeValMailerr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValMailerr");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValCreatope");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValCreatdat");

		[DisplayName("'Entity'")]
		/// <summary>Field : "'Entity'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName("'Person'")]
		/// <summary>Field : "'Person'" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }
		public bool ShouldSerializeValCodperso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValCodperso");
		private Perso _perso;
		[DisplayName("Perso")]
		public virtual Perso Perso { get { if (!this.isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodperso) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodperso)))) _perso = Models.Perso.Find(ValCodperso, Identifier, _fieldsToSerialize); if (_perso == null) _perso = new Models.Perso(true, _fieldsToSerialize); return _perso; } set { _perso = value; } }
		public bool ShouldSerializePerso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso");

		[DisplayName("Document number")]
		/// <summary>Field : "Document number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDocum_nr { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValDocum_nr, 0)); } set { klass.ValDocum_nr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDocum_nr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValDocum_nr");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Messa.ValZzstate");

		public Messa() : this(UserContext.Current.User) { }

		public Messa(User u)
		{
			this.klass = new CSGenioAmessa(u);
		}

		public Messa(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Messa(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Messa(bool isEmpty) : this(isEmpty, null) { }

		public Messa(CSGenioAmessa val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Messa(CSGenioAmessa val) : this(val, null) { }

		public Messa(CSGenioAmessa val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Messa(CSGenioAmessa val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAmessa csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "entit":
						if (_entit == null)
							_entit = new Entit(true, _fieldsToSerialize);
						_entit.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "perso":
						if (_perso == null)
							_perso = new Perso(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Messa Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Messa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmessa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Messa(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Messa> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAmessa>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Messa>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAmessa> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAmessa>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAmessa> All(CriteriaSet args = null)
		{
			return Where<CSGenioAmessa>(false, args, numRegs: -1);
		}

		public static List<Messa> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmessa>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Messa>((r) => new Messa(r));
		}

// USE /[MANUAL GQT MODEL MESSA]/
	}
}
