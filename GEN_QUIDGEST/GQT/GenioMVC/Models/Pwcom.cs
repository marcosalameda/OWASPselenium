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
	public class Pwcom : ModelBase
	{
		[JsonIgnore]
		public CSGenioApwcom klass { get { return baseklass as CSGenioApwcom; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodpwcom { get { return klass.ValCodpwcom; } set { klass.ValCodpwcom = value; } }
		public bool ShouldSerializeValCodpwcom() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValCodpwcom");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValCodpsw");
		private Psw _psw;
		[DisplayName("Psw")]
		public virtual Psw Psw { get { if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw)))) _psw = Models.Psw.Find(ValCodpsw, Identifier, _fieldsToSerialize); if (_psw == null) _psw = new Models.Psw(true, _fieldsToSerialize); return _psw; } set { _psw = value; } }
		public bool ShouldSerializePsw () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw");

		[DisplayName(">COMOMODOR")]
		/// <summary>Field : ">COMOMODOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpess1 { get { return klass.ValCodpess1; } set { klass.ValCodpess1 = value; } }
		public bool ShouldSerializeValCodpess1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValCodpess1");
		private Pess1 _pess1;
		[DisplayName("Pess1")]
		public virtual Pess1 Pess1 { get { if (!this.isEmptyModel && (_pess1 == null || (!string.IsNullOrEmpty(ValCodpess1) && (_pess1.isEmptyModel || _pess1.klass.QPrimaryKey != ValCodpess1)))) _pess1 = Models.Pess1.Find(ValCodpess1, Identifier, _fieldsToSerialize); if (_pess1 == null) _pess1 = new Models.Pess1(true, _fieldsToSerialize); return _pess1; } set { _pess1 = value; } }
		public bool ShouldSerializePess1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pess1");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula: ++ "[PSW->NOME]"</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValName");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValFoto { get { return klass.ValFoto; } set { klass.ValFoto = value; } }
		public bool ShouldSerializeValFoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValFoto");

		[DisplayName("Identification")]
		/// <summary>Field : "Identification" Tipo: "N" Formula: ++ "[PESS1->IDFUNCIO]"</summary>
		[NumericAttribute(0)]
		public decimal? ValNridenti { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNridenti, 0)); } set { klass.ValNridenti = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNridenti() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValNridenti");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pwcom.ValZzstate");

		public Pwcom() : this(UserContext.Current.User) { }

		public Pwcom(User u)
		{
			this.klass = new CSGenioApwcom(u);
		}

		public Pwcom(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pwcom(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Pwcom(bool isEmpty) : this(isEmpty, null) { }

		public Pwcom(CSGenioApwcom val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Pwcom(CSGenioApwcom val) : this(val, null) { }

		public Pwcom(CSGenioApwcom val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Pwcom(CSGenioApwcom val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_psw = new Psw(true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "pess1":
						if (_pess1 == null)
							_pess1 = new Pess1(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Pwcom Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Pwcom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApwcom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Pwcom(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Pwcom> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioApwcom>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Pwcom>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioApwcom> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioApwcom>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioApwcom> All(CriteriaSet args = null)
		{
			return Where<CSGenioApwcom>(false, args, numRegs: -1);
		}

		public static List<Pwcom> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApwcom>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Pwcom>((r) => new Pwcom(r));
		}

// USE /[MANUAL GQT MODEL PWCOM]/
	}
}
