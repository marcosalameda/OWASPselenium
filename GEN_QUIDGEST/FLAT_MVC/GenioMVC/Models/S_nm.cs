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
	public class S_nm : ModelBase
	{
		[JsonIgnore]
		public CSGenioAs_nm klass { get { return baseklass as CSGenioAs_nm; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodmesgs { get { return klass.ValCodmesgs; } set { klass.ValCodmesgs = value; } }
		public bool ShouldSerializeValCodmesgs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCodmesgs");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValCodsigna { get { return klass.ValCodsigna; } set { klass.ValCodsigna = value; } }
		public bool ShouldSerializeValCodsigna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCodsigna");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValCodpmail { get { return klass.ValCodpmail; } set { klass.ValCodpmail = value; } }
		public bool ShouldSerializeValCodpmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCodpmail");

		[DisplayName("Sender")]
		/// <summary>Field : "Sender" Tipo: "C" Formula:  ""</summary>
		public string ValFrom { get { return klass.ValFrom; } set { klass.ValFrom = value; } }
		public bool ShouldSerializeValFrom() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValFrom");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValCodtpnot { get { return klass.ValCodtpnot; } set { klass.ValCodtpnot = value; } }
		public bool ShouldSerializeValCodtpnot() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCodtpnot");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "C" Formula:  ""</summary>
		public string ValCoddestn { get { return klass.ValCoddestn; } set { klass.ValCoddestn = value; } }
		public bool ShouldSerializeValCoddestn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCoddestn");

		[DisplayName("To")]
		/// <summary>Field : "To" Tipo: "C" Formula:  ""</summary>
		public string ValTo { get { return klass.ValTo; } set { klass.ValTo = value; } }
		public bool ShouldSerializeValTo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValTo");

		[DisplayName("Manual destination")]
		/// <summary>Field : "Manual destination" Tipo: "L" Formula:  ""</summary>
		public bool ValDestnman { get { return Convert.ToBoolean(klass.ValDestnman); } set { klass.ValDestnman = Convert.ToInt32(value); } }
		public bool ShouldSerializeValDestnman() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValDestnman");

		[DisplayName("Manual destination")]
		/// <summary>Field : "Manual destination" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValTomanual { get { return klass.ValTomanual; } set { klass.ValTomanual = value; } }
		public bool ShouldSerializeValTomanual() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValTomanual");

		[DisplayName("Cc")]
		/// <summary>Field : "Cc" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValCc { get { return klass.ValCc; } set { klass.ValCc = value; } }
		public bool ShouldSerializeValCc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValCc");

		[DisplayName("Bcc")]
		/// <summary>Field : "Bcc" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValBcc { get { return klass.ValBcc; } set { klass.ValBcc = value; } }
		public bool ShouldSerializeValBcc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValBcc");

		[DisplayName("Notification ID")]
		/// <summary>Field : "Notification ID" Tipo: "C" Formula:  ""</summary>
		public string ValIdnotif { get { return klass.ValIdnotif; } set { klass.ValIdnotif = value; } }
		public bool ShouldSerializeValIdnotif() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValIdnotif");

		[DisplayName("Create a website alert")]
		/// <summary>Field : "Create a website alert" Tipo: "L" Formula:  ""</summary>
		public bool ValNotifica { get { return Convert.ToBoolean(klass.ValNotifica); } set { klass.ValNotifica = Convert.ToInt32(value); } }
		public bool ShouldSerializeValNotifica() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValNotifica");

		[DisplayName("Sends email?")]
		/// <summary>Field : "Sends email?" Tipo: "L" Formula:  ""</summary>
		public bool ValEmail { get { return Convert.ToBoolean(klass.ValEmail); } set { klass.ValEmail = Convert.ToInt32(value); } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValEmail");

		[DisplayName("Subject")]
		/// <summary>Field : "Subject" Tipo: "C" Formula:  ""</summary>
		public string ValAssunto { get { return klass.ValAssunto; } set { klass.ValAssunto = value; } }
		public bool ShouldSerializeValAssunto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValAssunto");

		[DisplayName("Aggregate")]
		/// <summary>Field : "Aggregate" Tipo: "L" Formula:  ""</summary>
		public bool ValAgregado { get { return Convert.ToBoolean(klass.ValAgregado); } set { klass.ValAgregado = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAgregado() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValAgregado");

		[DisplayName("Sends attachment?")]
		/// <summary>Field : "Sends attachment?" Tipo: "L" Formula:  ""</summary>
		public bool ValAnexo { get { return Convert.ToBoolean(klass.ValAnexo); } set { klass.ValAnexo = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAnexo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValAnexo");

		[DisplayName("HTML format?")]
		/// <summary>Field : "HTML format?" Tipo: "L" Formula:  ""</summary>
		public bool ValHtml { get { return Convert.ToBoolean(klass.ValHtml); } set { klass.ValHtml = Convert.ToInt32(value); } }
		public bool ShouldSerializeValHtml() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValHtml");

		[DisplayName("Enabled?")]
		/// <summary>Field : "Enabled?" Tipo: "L" Formula:  ""</summary>
		public bool ValAtivo { get { return Convert.ToBoolean(klass.ValAtivo); } set { klass.ValAtivo = Convert.ToInt32(value); } }
		public bool ShouldSerializeValAtivo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValAtivo");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValDesignac { get { return klass.ValDesignac; } set { klass.ValDesignac = value; } }
		public bool ShouldSerializeValDesignac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValDesignac");

		[DisplayName("Message")]
		/// <summary>Field : "Message" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValMensagem { get { return klass.ValMensagem; } set { klass.ValMensagem = value; } }
		public bool ShouldSerializeValMensagem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValMensagem");

		[DisplayName("Saves on DB?")]
		/// <summary>Field : "Saves on DB?" Tipo: "L" Formula:  ""</summary>
		public bool ValGravabd { get { return Convert.ToBoolean(klass.ValGravabd); } set { klass.ValGravabd = Convert.ToInt32(value); } }
		public bool ShouldSerializeValGravabd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValGravabd");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValDatacria");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOpermuda { get { return klass.ValOpermuda; } set { klass.ValOpermuda = value; } }
		public bool ShouldSerializeValOpermuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValOpermuda");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValDatamuda { get { return klass.ValDatamuda; } set { klass.ValDatamuda = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValDatamuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValDatamuda");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nm.ValZzstate");

		public S_nm() : this(UserContext.Current.User) { }

		public S_nm(User u)
		{
			this.klass = new CSGenioAs_nm(u);
		}

		public S_nm(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_nm(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public S_nm(bool isEmpty) : this(isEmpty, null) { }

		public S_nm(CSGenioAs_nm val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_nm(CSGenioAs_nm val) : this(val, null) { }

		public S_nm(CSGenioAs_nm val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public S_nm(CSGenioAs_nm val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAs_nm csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static S_nm Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static S_nm Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAs_nm>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new S_nm(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<S_nm> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAs_nm>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<S_nm>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAs_nm> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAs_nm>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAs_nm> All(CriteriaSet args = null)
		{
			return Where<CSGenioAs_nm>(false, args, numRegs: -1);
		}

		public static List<S_nm> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAs_nm>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<S_nm>((r) => new S_nm(r));
		}

// USE /[MANUAL GQT MODEL S_NM]/
	}
}
