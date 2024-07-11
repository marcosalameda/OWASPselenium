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
	public class Prpin : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprpin klass { get { return baseklass as CSGenioAprpin; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// Gets a reference to the GLOB table
		/// to provide access to the necessary fields
		/// to client and server-side formulas.
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCodpesso");

		[DisplayName("Foreign key")]
		/// <summary>Field : "Foreign key" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCodpsw");
		private Psw _psw;
		[DisplayName("Psw")]
		public virtual Psw Psw { get { if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw)))) _psw = Models.Psw.Find(ValCodpsw, Identifier, _fieldsToSerialize); if (_psw == null) _psw = new Models.Psw(true, _fieldsToSerialize); return _psw; } set { _psw = value; } }
		public bool ShouldSerializePsw () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw");

		[DisplayName("Mechanografic number")]
		/// <summary>Field : "Mechanografic number" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNummecan { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNummecan, 0)); } set { klass.ValNummecan = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNummecan() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValNummecan");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValPessoa { get { return klass.ValPessoa; } set { klass.ValPessoa = value; } }
		public bool ShouldSerializeValPessoa() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValPessoa");

		[DisplayName("Role")]
		/// <summary>Field : "Role" Tipo: "C" Formula:  ""</summary>
		public string ValCargo { get { return klass.ValCargo; } set { klass.ValCargo = value; } }
		public bool ShouldSerializeValCargo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCargo");

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValEmail");

		[DisplayName("Individual Notifications")]
		/// <summary>Field : "Individual Notifications" Tipo: "L" Formula:  ""</summary>
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }
		public bool ShouldSerializeValNotifind() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValNotifind");

		[DisplayName("Foreign key")]
		/// <summary>Field : "Foreign key" Tipo: "CF" Formula:  ""</summary>
		public string ValCodorgaf { get { return klass.ValCodorgaf; } set { klass.ValCodorgaf = value; } }
		public bool ShouldSerializeValCodorgaf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCodorgaf");

		[DisplayName("External Entity")]
		/// <summary>Field : "External Entity" Tipo: "L" Formula:  ""</summary>
		public bool ValEexterna { get { return Convert.ToBoolean(klass.ValEexterna); } set { klass.ValEexterna = Convert.ToInt32(value); } }
		public bool ShouldSerializeValEexterna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValEexterna");

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValCreatdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCreatdat");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }
		public bool ShouldSerializeValCreatope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValCreatope");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValChngdate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValChngdate");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }
		public bool ShouldSerializeValOperchng() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValOperchng");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prpin.ValZzstate");

		public Prpin() : this(UserContext.Current.User) { }

		public Prpin(User u)
		{
			this.klass = new CSGenioAprpin(u);
		}

		public Prpin(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Prpin(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Prpin(bool isEmpty) : this(isEmpty, null) { }

		public Prpin(CSGenioAprpin val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Prpin(CSGenioAprpin val) : this(val, null) { }

		public Prpin(CSGenioAprpin val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Prpin(CSGenioAprpin val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAprpin csgenioa)
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
		public static Prpin Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Prpin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprpin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Prpin(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Prpin> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAprpin>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Prpin>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAprpin> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAprpin>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAprpin> All(CriteriaSet args = null)
		{
			return Where<CSGenioAprpin>(false, args, numRegs: -1);
		}

		public static List<Prpin> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprpin>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Prpin>((r) => new Prpin(r));
		}

// USE /[MANUAL GQT MODEL PRPIN]/
	}
}
