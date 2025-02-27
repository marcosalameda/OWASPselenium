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
	public class Dispa : ModelBase
	{
		[JsonIgnore]
		public CSGenioAdispa klass { get { return baseklass as CSGenioAdispa; } set { baseklass = value; } }

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
		public string ValCoddispa { get { return klass.ValCoddispa; } set { klass.ValCoddispa = value; } }
		public bool ShouldSerializeValCoddispa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValCoddispa");

		[DisplayName(">>CUSTOMER")]
		/// <summary>Field : ">>CUSTOMER" Tipo: "CE" Formula:  ""</summary>
		public string ValCodentit { get { return klass.ValCodentit; } set { klass.ValCodentit = value; } }
		public bool ShouldSerializeValCodentit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValCodentit");
		private Entit _entit;
		[DisplayName("Entit")]
		public virtual Entit Entit { get { if (!this.isEmptyModel && (_entit == null || (!string.IsNullOrEmpty(ValCodentit) && (_entit.isEmptyModel || _entit.klass.QPrimaryKey != ValCodentit)))) _entit = Models.Entit.Find(ValCodentit, Identifier, _fieldsToSerialize); if (_entit == null) _entit = new Models.Entit(true, _fieldsToSerialize); return _entit; } set { _entit = value; } }
		public bool ShouldSerializeEntit () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Entit");

		[DisplayName(">> STATUS")]
		/// <summary>Field : ">> STATUS" Tipo: "CE" Formula:  ""</summary>
		public string ValCoddisst { get { return klass.ValCoddisst; } set { klass.ValCoddisst = value; } }
		public bool ShouldSerializeValCoddisst() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValCoddisst");
		private Disst _disst;
		[DisplayName("Disst")]
		public virtual Disst Disst { get { if (!this.isEmptyModel && (_disst == null || (!string.IsNullOrEmpty(ValCoddisst) && (_disst.isEmptyModel || _disst.klass.QPrimaryKey != ValCoddisst)))) _disst = Models.Disst.Find(ValCoddisst, Identifier, _fieldsToSerialize); if (_disst == null) _disst = new Models.Disst(true, _fieldsToSerialize); return _disst; } set { _disst = value; } }
		public bool ShouldSerializeDisst () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Disst");

		[DisplayName("Is prepared")]
		/// <summary>Field : "Is prepared" Tipo: "L" Formula:  ""</summary>
		public bool ValIsprepar { get { return Convert.ToBoolean(klass.ValIsprepar); } set { klass.ValIsprepar = Convert.ToInt32(value); } }
		public bool ShouldSerializeValIsprepar() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValIsprepar");

		[DisplayName("Dispatch date")]
		/// <summary>Field : "Dispatch date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDispadt { get { return klass.ValDispadt; } set { klass.ValDispadt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDispadt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValDispadt");

		[DisplayName("Dispatch number")]
		/// <summary>Field : "Dispatch number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValDispanr { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValDispanr, 0)); } set { klass.ValDispanr = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValDispanr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValDispanr");

		[DisplayName("Prepared")]
		/// <summary>Field : "Prepared" Tipo: "DT" Formula: DF "iif(emptyL([DISPA->ISPREPAR])==1,[ZEROD],[Today])"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValPrepared { get { return klass.ValPrepared; } set { klass.ValPrepared = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValPrepared() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValPrepared");

		[DisplayName(">>PERSON RESPONSIBLE")]
		/// <summary>Field : ">>PERSON RESPONSIBLE" Tipo: "CE" Formula:  ""</summary>
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }
		public bool ShouldSerializeValCodperso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValCodperso");
		private Perso _perso;
		[DisplayName("Perso")]
		public virtual Perso Perso { get { if (!this.isEmptyModel && (_perso == null || (!string.IsNullOrEmpty(ValCodperso) && (_perso.isEmptyModel || _perso.klass.QPrimaryKey != ValCodperso)))) _perso = Models.Perso.Find(ValCodperso, Identifier, _fieldsToSerialize); if (_perso == null) _perso = new Models.Perso(true, _fieldsToSerialize); return _perso; } set { _perso = value; } }
		public bool ShouldSerializePerso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Perso");

		[DisplayName("Status")]
		/// <summary>Field : "Status" Tipo: "AC" Formula: + "iif(emptyD([DISPA->DISPADT])==0,"D",iif(emptyD([DISPA->PREPARED])==0,"P","I"))"</summary>
		[DataArray("Dispstat", GenioMVC.Helpers.ArrayType.Character)]
		public string ValStatus { get { return klass.ValStatus; } set { klass.ValStatus = value; } }
		[JsonIgnore]
		public SelectList ArrayValstatus { get { return new SelectList(CSGenio.business.ArrayDispstat.GetDictionary(), "Key", "Value", ValStatus); } set { ValStatus = value.SelectedValue as string; } }
		public bool ShouldSerializeValStatus() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValStatus");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Dispa.ValZzstate");

		public Dispa() : this(UserContext.Current.User) { }

		public Dispa(User u)
		{
			this.klass = new CSGenioAdispa(u);
		}

		public Dispa(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dispa(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Dispa(bool isEmpty) : this(isEmpty, null) { }

		public Dispa(CSGenioAdispa val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Dispa(CSGenioAdispa val) : this(val, null) { }

		public Dispa(CSGenioAdispa val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Dispa(CSGenioAdispa val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAdispa csgenioa)
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
					case "disst":
						if (_disst == null)
							_disst = new Disst(true, _fieldsToSerialize);
						_disst.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Dispa Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Dispa Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAdispa>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Dispa(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Dispa> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAdispa>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Dispa>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAdispa> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAdispa>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAdispa> All(CriteriaSet args = null)
		{
			return Where<CSGenioAdispa>(false, args, numRegs: -1);
		}

		public static List<Dispa> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAdispa>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Dispa>((r) => new Dispa(r));
		}

// USE /[MANUAL GQT MODEL DISPA]/
	}
}
