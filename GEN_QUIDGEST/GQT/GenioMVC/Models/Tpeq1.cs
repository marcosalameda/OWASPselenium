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
	public class Tpeq1 : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpeq1 klass { get { return baseklass as CSGenioAtpeq1; } set { baseklass = value; } }

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
		public string ValCodtpequ { get { return klass.ValCodtpequ; } set { klass.ValCodtpequ = value; } }
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValCodtpequ");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfamil { get { return klass.ValCodfamil; } set { klass.ValCodfamil = value; } }
		public bool ShouldSerializeValCodfamil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValCodfamil");
		private Fami1 _fami1;
		[DisplayName("Fami1")]
		public virtual Fami1 Fami1 { get { if (!this.isEmptyModel && (_fami1 == null || (!string.IsNullOrEmpty(ValCodfamil) && (_fami1.isEmptyModel || _fami1.klass.QPrimaryKey != ValCodfamil)))) _fami1 = Models.Fami1.Find(ValCodfamil, Identifier, _fieldsToSerialize); if (_fami1 == null) _fami1 = new Models.Fami1(true, _fieldsToSerialize); return _fami1; } set { _fami1 = value; } }
		public bool ShouldSerializeFami1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Fami1");

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		public string ValTipoequi { get { return klass.ValTipoequi; } set { klass.ValTipoequi = value; } }
		public bool ShouldSerializeValTipoequi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValTipoequi");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public string ValTpequcod { get { return klass.ValTpequcod; } set { klass.ValTpequcod = value; } }
		public bool ShouldSerializeValTpequcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValTpequcod");

		[DisplayName("Dependent on")]
		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		public string ValTpequpai { get { return klass.ValTpequpai; } set { klass.ValTpequpai = value; } }
		public bool ShouldSerializeValTpequpai() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValTpequpai");

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public decimal ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }
		public bool ShouldSerializeValNivel() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValNivel");

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }
		public bool ShouldSerializeValBackcolo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValBackcolo");

		[DisplayName("Letter color")]
		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		public string ValCorletra { get { return klass.ValCorletra; } set { klass.ValCorletra = value; } }
		public bool ShouldSerializeValCorletra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValCorletra");

		[DisplayName("Maximum price")]
		/// <summary>Field : "Maximum price" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecomax, 2)); } set { klass.ValPrecomax = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecomax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValPrecomax");

		[DisplayName("Last price")]
		/// <summary>Field : "Last price" Tipo: "$D" Formula:  ""</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPrecoult, 2)); } set { klass.ValPrecoult = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecoult() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValPrecoult");

		[DisplayName("In")]
		/// <summary>Field : "In" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValSince() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValSince");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValQtdequip, 0)); } set { klass.ValQtdequip = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtdequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValQtdequip");

		[DisplayName("Kit")]
		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		public bool ValKit { get { return Convert.ToBoolean(klass.ValKit); } set { klass.ValKit = Convert.ToInt32(value); } }
		public bool ShouldSerializeValKit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValKit");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpeq1.ValZzstate");

		public Tpeq1() : this(UserContext.Current.User) { }

		public Tpeq1(User u)
		{
			this.klass = new CSGenioAtpeq1(u);
		}

		public Tpeq1(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpeq1(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tpeq1(bool isEmpty) : this(isEmpty, null) { }

		public Tpeq1(CSGenioAtpeq1 val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpeq1(CSGenioAtpeq1 val) : this(val, null) { }

		public Tpeq1(CSGenioAtpeq1 val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tpeq1(CSGenioAtpeq1 val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtpeq1 csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "fami1":
						if (_fami1 == null)
							_fami1 = new Fami1(true, _fieldsToSerialize);
						_fami1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpeq1 Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tpeq1 Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpeq1>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpeq1(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tpeq1> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtpeq1>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tpeq1>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtpeq1> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtpeq1>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtpeq1> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtpeq1>(false, args, numRegs: -1);
		}

		public static List<Tpeq1> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpeq1>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpeq1>((r) => new Tpeq1(r));
		}

// USE /[MANUAL GQT MODEL TPEQ1]/
	}
}
