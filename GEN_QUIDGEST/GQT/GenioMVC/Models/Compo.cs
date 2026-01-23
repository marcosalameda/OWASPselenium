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
	public class Compo : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcompo klass { get { return baseklass as CSGenioAcompo; } set { baseklass = value; } }

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
		public string ValCodcompo { get { return klass.ValCodcompo; } set { klass.ValCodcompo = value; } }
		public bool ShouldSerializeValCodcompo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCodcompo");

		[DisplayName("Components Class")]
		/// <summary>Field : "Components Class" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcompc { get { return klass.ValCodcompc; } set { klass.ValCodcompc = value; } }
		public bool ShouldSerializeValCodcompc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCodcompc");
		private Compc _compc;
		[DisplayName("Compc")]
		public virtual Compc Compc { get { if (!this.isEmptyModel && (_compc == null || (!string.IsNullOrEmpty(ValCodcompc) && (_compc.isEmptyModel || _compc.klass.QPrimaryKey != ValCodcompc)))) _compc = Models.Compc.Find(ValCodcompc, Identifier, _fieldsToSerialize); if (_compc == null) _compc = new Models.Compc(true, _fieldsToSerialize); return _compc; } set { _compc = value; } }
		public bool ShouldSerializeCompc () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc");

		[DisplayName("Release version")]
		/// <summary>Field : "Release version" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(2)]
		public decimal? ValRelease { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValRelease, 2)); } set { klass.ValRelease = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValRelease() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValRelease");

		[DisplayName("Component description")]
		/// <summary>Field : "Component description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValCompdesc { get { return klass.ValCompdesc; } set { klass.ValCompdesc = value; } }
		public bool ShouldSerializeValCompdesc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCompdesc");

		[DisplayName("Preview")]
		/// <summary>Field : "Preview" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPreview { get { return klass.ValPreview; } set { klass.ValPreview = value; } }
		public bool ShouldSerializeValPreview() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValPreview");

		[DisplayName("Component type")]
		/// <summary>Field : "Component type" Tipo: "C" Formula:  ""</summary>
		public string ValComptype { get { return klass.ValComptype; } set { klass.ValComptype = value; } }
		public bool ShouldSerializeValComptype() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValComptype");

		[DisplayName("Interaction")]
		/// <summary>Field : "Interaction" Tipo: "C" Formula:  ""</summary>
		public string ValCompinte { get { return klass.ValCompinte; } set { klass.ValCompinte = value; } }
		public bool ShouldSerializeValCompinte() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCompinte");

		[DisplayName("Behaviour")]
		/// <summary>Field : "Behaviour" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValCompbeha { get { return klass.ValCompbeha; } set { klass.ValCompbeha = value; } }
		public bool ShouldSerializeValCompbeha() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCompbeha");

		[DisplayName("Variants")]
		/// <summary>Field : "Variants" Tipo: "C" Formula:  ""</summary>
		public string ValCompvari { get { return klass.ValCompvari; } set { klass.ValCompvari = value; } }
		public bool ShouldSerializeValCompvari() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCompvari");

		[DisplayName("Variant Description")]
		/// <summary>Field : "Variant Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValVardescr { get { return klass.ValVardescr; } set { klass.ValVardescr = value; } }
		public bool ShouldSerializeValVardescr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValVardescr");

		[DisplayName("When to use")]
		/// <summary>Field : "When to use" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValWuse { get { return klass.ValWuse; } set { klass.ValWuse = value; } }
		public bool ShouldSerializeValWuse() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValWuse");

		[DisplayName("When not to use")]
		/// <summary>Field : "When not to use" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValWnuse { get { return klass.ValWnuse; } set { klass.ValWnuse = value; } }
		public bool ShouldSerializeValWnuse() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValWnuse");

		[DisplayName("VUE")]
		/// <summary>Field : "VUE" Tipo: "L" Formula:  ""</summary>
		public bool ValVuemvc { get { return Convert.ToBoolean(klass.ValVuemvc); } set { klass.ValVuemvc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValVuemvc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValVuemvc");

		[DisplayName("MVC")]
		/// <summary>Field : "MVC" Tipo: "L" Formula:  ""</summary>
		public bool ValMvc { get { return Convert.ToBoolean(klass.ValMvc); } set { klass.ValMvc = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMvc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValMvc");

		[DisplayName("Accesibilty Compliance & Best Practices")]
		/// <summary>Field : "Accesibilty Compliance & Best Practices" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValAccessib { get { return klass.ValAccessib; } set { klass.ValAccessib = value; } }
		public bool ShouldSerializeValAccessib() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValAccessib");

		[DisplayName("Data type")]
		/// <summary>Field : "Data type" Tipo: "C" Formula:  ""</summary>
		public string ValCdatatyp { get { return klass.ValCdatatyp; } set { klass.ValCdatatyp = value; } }
		public bool ShouldSerializeValCdatatyp() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValCdatatyp");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compo.ValZzstate");

		public Compo() : this(UserContext.Current.User) { }

		public Compo(User u)
		{
			this.klass = new CSGenioAcompo(u);
		}

		public Compo(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compo(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Compo(bool isEmpty) : this(isEmpty, null) { }

		public Compo(CSGenioAcompo val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compo(CSGenioAcompo val) : this(val, null) { }

		public Compo(CSGenioAcompo val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Compo(CSGenioAcompo val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcompo csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "compc":
						if (_compc == null)
							_compc = new Compc(true, _fieldsToSerialize);
						_compc.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Compo Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Compo Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcompo>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Compo(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Compo> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcompo>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Compo>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcompo> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcompo>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcompo> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcompo>(false, args, numRegs: -1);
		}

		public static List<Compo> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcompo>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Compo>((r) => new Compo(r));
		}

// USE /[MANUAL GQT MODEL COMPO]/
	}
}
