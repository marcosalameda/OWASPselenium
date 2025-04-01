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
	public class Tpequ : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpequ klass { get { return baseklass as CSGenioAtpequ; } set { baseklass = value; } }

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
		public bool ShouldSerializeValCodtpequ() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValCodtpequ");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodfamil { get { return klass.ValCodfamil; } set { klass.ValCodfamil = value; } }
		public bool ShouldSerializeValCodfamil() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValCodfamil");
		private Famil _famil;
		[DisplayName("Famil")]
		public virtual Famil Famil { get { if (!this.isEmptyModel && (_famil == null || (!string.IsNullOrEmpty(ValCodfamil) && (_famil.isEmptyModel || _famil.klass.QPrimaryKey != ValCodfamil)))) _famil = Models.Famil.Find(ValCodfamil, Identifier, _fieldsToSerialize); if (_famil == null) _famil = new Models.Famil(true, _fieldsToSerialize); return _famil; } set { _famil = value; } }
		public bool ShouldSerializeFamil () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Famil");

		[DisplayName("TYPE OF EQUIPMENT")]
		/// <summary>Field : "TYPE OF EQUIPMENT" Tipo: "C" Formula:  ""</summary>
		public string ValTipoequi { get { return klass.ValTipoequi; } set { klass.ValTipoequi = value; } }
		public bool ShouldSerializeValTipoequi() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValTipoequi");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public string ValTpequcod { get { return klass.ValTpequcod; } set { klass.ValTpequcod = value; } }
		public bool ShouldSerializeValTpequcod() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValTpequcod");

		[DisplayName("Dependent on")]
		/// <summary>Field : "Dependent on" Tipo: "TP" Formula:  ""</summary>
		public string ValTpequpai { get { return klass.ValTpequpai; } set { klass.ValTpequpai = value; } }
		public bool ShouldSerializeValTpequpai() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValTpequpai");

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public decimal ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }
		public bool ShouldSerializeValNivel() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValNivel");

		[DisplayName("Background color")]
		/// <summary>Field : "Background color" Tipo: "C" Formula:  ""</summary>
		public string ValBackcolo { get { return klass.ValBackcolo; } set { klass.ValBackcolo = value; } }
		public bool ShouldSerializeValBackcolo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValBackcolo");

		[DisplayName("Letter color")]
		/// <summary>Field : "Letter color" Tipo: "C" Formula:  ""</summary>
		public string ValCorletra { get { return klass.ValCorletra; } set { klass.ValCorletra = value; } }
		public bool ShouldSerializeValCorletra() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValCorletra");

		[DisplayName("Maximum price")]
		/// <summary>Field : "Maximum price" Tipo: "$D" Formula: U1 "TABPR[TABPR->PRECOHOR][TABPR->PRECOHOR]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecomax { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecomax, 2)); } set { klass.ValPrecomax = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecomax() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValPrecomax");

		[DisplayName("Last price")]
		/// <summary>Field : "Last price" Tipo: "$D" Formula: U1 "TABPR[TABPR->SINCE][TABPR->PRECOHOR][Today]"</summary>
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrecoult { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrecoult, 2)); } set { klass.ValPrecoult = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValPrecoult() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValPrecoult");

		[DisplayName("Since")]
		/// <summary>Field : "Since" Tipo: "DT" Formula: U1 "TABPR[TABPR->SINCE][TABPR->SINCE][Today]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValSince { get { return klass.ValSince; } set { klass.ValSince = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValSince() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValSince");

		[DisplayName("Amount")]
		/// <summary>Field : "Amount" Tipo: "N" Formula: SR "[EQUIP->1]"</summary>
		[NumericAttribute(0)]
		public decimal? ValQtdequip { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValQtdequip, 0)); } set { klass.ValQtdequip = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValQtdequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValQtdequip");

		[DisplayName("Kit")]
		/// <summary>Field : "Kit" Tipo: "L" Formula:  ""</summary>
		public bool ValKit { get { return Convert.ToBoolean(klass.ValKit); } set { klass.ValKit = Convert.ToInt32(value); } }
		public bool ShouldSerializeValKit() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValKit");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpequ.ValZzstate");

		public Tpequ() : this(UserContext.Current.User) { }

		public Tpequ(User u)
		{
			this.klass = new CSGenioAtpequ(u);
		}

		public Tpequ(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpequ(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tpequ(bool isEmpty) : this(isEmpty, null) { }

		public Tpequ(CSGenioAtpequ val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpequ(CSGenioAtpequ val) : this(val, null) { }

		public Tpequ(CSGenioAtpequ val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tpequ(CSGenioAtpequ val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtpequ csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "famil":
						if (_famil == null)
							_famil = new Famil(true, _fieldsToSerialize);
						_famil.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpequ Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tpequ Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpequ>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpequ(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tpequ> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtpequ>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tpequ>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtpequ> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtpequ>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtpequ> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtpequ>(false, args, numRegs: -1);
		}

		public static List<Tpequ> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpequ>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpequ>((r) => new Tpequ(r));
		}

		public StatusMessage carga_unico(string idsrc)
		{
			StatusMessage Qresult = null;
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			Qresult = this.klass.carga_unico(idsrc,sp,u);

			return Qresult;
		}

// USE /[MANUAL GQT MODEL TPEQU]/
	}
}
