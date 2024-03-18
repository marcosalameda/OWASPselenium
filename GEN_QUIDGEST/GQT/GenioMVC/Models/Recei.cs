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
	public class Recei : ModelBase
	{
		[JsonIgnore]
		public CSGenioArecei klass { get { return baseklass as CSGenioArecei; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodrecei { get { return klass.ValCodrecei; } set { klass.ValCodrecei = value; } }
		public bool ShouldSerializeValCodrecei() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValCodrecei");

		[DisplayName(">>SUPPLIER")]
		/// <summary>Field : ">>SUPPLIER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName("Receipt number")]
		/// <summary>Field : "Receipt number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNumber { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumber, 0)); } set { klass.ValNumber = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNumber() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValNumber");

		[DisplayName("Receipt date")]
		/// <summary>Field : "Receipt date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtreceip { get { return klass.ValDtreceip; } set { klass.ValDtreceip = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtreceip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValDtreceip");

		[DisplayName("Receipt verification")]
		/// <summary>Field : "Receipt verification" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtcheck { get { return klass.ValDtcheck; } set { klass.ValDtcheck = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtcheck() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValDtcheck");

		[DisplayName("Checked")]
		/// <summary>Field : "Checked" Tipo: "L" Formula: + "iif(isEmptyD([RECEI->DTCHECK]),0,1)"</summary>
		public bool ValChecked { get { return Convert.ToBoolean(klass.ValChecked); } set { klass.ValChecked = Convert.ToInt32(value); } }
		public bool ShouldSerializeValChecked() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValChecked");

		[DisplayName("To check")]
		/// <summary>Field : "To check" Tipo: "L" Formula: + "iif(!isEmptyD([RECEI->DTRECEIP]) && isEmptyD([RECEI->DTCHECK]),1,0)"</summary>
		public bool ValTocheck { get { return Convert.ToBoolean(klass.ValTocheck); } set { klass.ValTocheck = Convert.ToInt32(value); } }
		public bool ShouldSerializeValTocheck() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValTocheck");

		[DisplayName("Stored")]
		/// <summary>Field : "Stored" Tipo: "L" Formula:  ""</summary>
		public bool ValStored { get { return Convert.ToBoolean(klass.ValStored); } set { klass.ValStored = Convert.ToInt32(value); } }
		public bool ShouldSerializeValStored() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValStored");

		[DisplayName("Storage date")]
		/// <summary>Field : "Storage date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDtstorag { get { return klass.ValDtstorag; } set { klass.ValDtstorag = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDtstorag() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValDtstorag");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Recei.ValZzstate");

		public Recei() : this(UserContext.Current.User) { }

		public Recei(User u)
		{
			this.klass = new CSGenioArecei(u);
		}

		public Recei(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Recei(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Recei(bool isEmpty) : this(isEmpty, null) { }

		public Recei(CSGenioArecei val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Recei(CSGenioArecei val) : this(val, null) { }

		public Recei(CSGenioArecei val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Recei(CSGenioArecei val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioArecei csgenioa)
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
		public static Recei Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Recei Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioArecei>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Recei(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Recei> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioArecei>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Recei>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioArecei> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioArecei>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioArecei> All(CriteriaSet args = null)
		{
			return Where<CSGenioArecei>(false, args, numRegs: -1);
		}

		public static List<Recei> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioArecei>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Recei>((r) => new Recei(r));
		}

// USE /[MANUAL GQT MODEL RECEI]/
	}
}
