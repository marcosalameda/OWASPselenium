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
	public class Anexd : ModelBase
	{
		[JsonIgnore]
		public CSGenioAanexd klass { get { return baseklass as CSGenioAanexd; } set { baseklass = value; } }

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
		public string ValCodanexd { get { return klass.ValCodanexd; } set { klass.ValCodanexd = value; } }
		public bool ShouldSerializeValCodanexd() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValCodanexd");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName("Attached")]
		/// <summary>Field : "Attached" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDthranex { get { return klass.ValDthranex; } set { klass.ValDthranex = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDthranex() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValDthranex");

		[DisplayName("Title")]
		/// <summary>Field : "Title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }
		public bool ShouldSerializeValTitle() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValTitle");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocument", true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }
		public bool ShouldSerializeValDocument() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValDocument");

		[DisplayName(">LANGUAGE")]
		/// <summary>Field : ">LANGUAGE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlang { get { return klass.ValCodlang; } set { klass.ValCodlang = value; } }
		public bool ShouldSerializeValCodlang() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValCodlang");
		private Langu _langu;
		[DisplayName("Langu")]
		public virtual Langu Langu { get { if (!this.isEmptyModel && (_langu == null || (!string.IsNullOrEmpty(ValCodlang) && (_langu.isEmptyModel || _langu.klass.QPrimaryKey != ValCodlang)))) _langu = Models.Langu.Find(ValCodlang, Identifier, _fieldsToSerialize); if (_langu == null) _langu = new Models.Langu(true, _fieldsToSerialize); return _langu; } set { _langu = value; } }
		public bool ShouldSerializeLangu () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Langu");

		[DisplayName("Translated title")]
		/// <summary>Field : "Translated title" Tipo: "C" Formula: CT "TRADU[ANEXD->TITLE][TRADU->ATRADUZI][TRADU->TRADUZID][ANEXD->CODLANG][TRADU->CODIDIO2](DESC)"</summary>
		public string ValTittradu { get { return klass.ValTittradu; } set { klass.ValTittradu = value; } }
		public bool ShouldSerializeValTittradu() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValTittradu");

		[DisplayName("Reference")]
		/// <summary>Field : "Reference" Tipo: "C" Formula:  ""</summary>
		public string ValReferenc { get { return klass.ValReferenc; } set { klass.ValReferenc = value; } }
		public bool ShouldSerializeValReferenc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValReferenc");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Anexd.ValZzstate");

		public Anexd() : this(UserContext.Current.User) { }

		public Anexd(User u)
		{
			this.klass = new CSGenioAanexd(u);
		}

		public Anexd(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Anexd(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Anexd(bool isEmpty) : this(isEmpty, null) { }

		public Anexd(CSGenioAanexd val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Anexd(CSGenioAanexd val) : this(val, null) { }

		public Anexd(CSGenioAanexd val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Anexd(CSGenioAanexd val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_equip = new Equip(true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "langu":
						if (_langu == null)
							_langu = new Langu(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Anexd Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Anexd Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAanexd>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Anexd(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Anexd> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAanexd>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Anexd>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAanexd> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAanexd>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAanexd> All(CriteriaSet args = null)
		{
			return Where<CSGenioAanexd>(false, args, numRegs: -1);
		}

		public static List<Anexd> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAanexd>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Anexd>((r) => new Anexd(r));
		}

// USE /[MANUAL GQT MODEL ANEXD]/
	}
}
