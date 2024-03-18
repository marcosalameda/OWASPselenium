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
	public class S_ua : ModelBase
	{
		[JsonIgnore]
		public CSGenioAs_ua klass { get { return baseklass as CSGenioAs_ua; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodua { get { return klass.ValCodua; } set { klass.ValCodua = value; } }
		public bool ShouldSerializeValCodua() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValCodua");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		public bool ShouldSerializeValCodpsw() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValCodpsw");
		private Psw _psw;
		[DisplayName("Psw")]
		public virtual Psw Psw { get { if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw)))) _psw = Models.Psw.Find(ValCodpsw, Identifier, _fieldsToSerialize); if (_psw == null) _psw = new Models.Psw(true, _fieldsToSerialize); return _psw; } set { _psw = value; } }
		public bool ShouldSerializePsw () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Psw");

		[DisplayName("System")]
		/// <summary>Field : "System" Tipo: "C" Formula:  ""</summary>
		public string ValSistema { get { return klass.ValSistema; } set { klass.ValSistema = value; } }
		public bool ShouldSerializeValSistema() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValSistema");

		[DisplayName("Module")]
		/// <summary>Field : "Module" Tipo: "AC" Formula:  ""</summary>
		[DataArray("S_module", GenioMVC.Helpers.ArrayType.Character)]
		public string ValModulo { get { return klass.ValModulo; } set { klass.ValModulo = value; } }
		[JsonIgnore]
		public SelectList ArrayValmodulo { get { return new SelectList(CSGenio.business.ArrayS_module.GetDictionary(), "Key", "Value", ValModulo); } set { ValModulo = value.SelectedValue as string; } }
		public bool ShouldSerializeValModulo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValModulo");

		[DisplayName("Role")]
		/// <summary>Field : "Role" Tipo: "AC" Formula:  ""</summary>
		[DataArray("S_roles", GenioMVC.Helpers.ArrayType.Character)]
		public string ValRole { get { return klass.ValRole; } set { klass.ValRole = value; } }
		[JsonIgnore]
		public SelectList ArrayValrole { get { return new SelectList(CSGenio.business.ArrayS_roles.GetDictionary(), "Key", "Value", ValRole); } set { ValRole = value.SelectedValue as string; } }
		public bool ShouldSerializeValRole() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValRole");

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "N" Formula: + "GetLevelFromRole([S_UA->NIVEL], [S_UA->ROLE])"</summary>
		[NumericAttribute(0)]
		public decimal? ValNivel { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNivel, 0)); } set { klass.ValNivel = Convert.ToDouble(value); } }
		public bool ShouldSerializeValNivel() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValNivel");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValDatacria");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOpermuda { get { return klass.ValOpermuda; } set { klass.ValOpermuda = value; } }
		public bool ShouldSerializeValOpermuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValOpermuda");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValDatamuda { get { return klass.ValDatamuda; } set { klass.ValDatamuda = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValDatamuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValDatamuda");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_ua.ValZzstate");

		public S_ua() : this(UserContext.Current.User) { }

		public S_ua(User u)
		{
			this.klass = new CSGenioAs_ua(u);
		}

		public S_ua(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_ua(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public S_ua(bool isEmpty) : this(isEmpty, null) { }

		public S_ua(CSGenioAs_ua val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_ua(CSGenioAs_ua val) : this(val, null) { }

		public S_ua(CSGenioAs_ua val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public S_ua(CSGenioAs_ua val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAs_ua csgenioa)
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
		public static S_ua Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static S_ua Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAs_ua>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new S_ua(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<S_ua> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAs_ua>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<S_ua>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAs_ua> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAs_ua>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAs_ua> All(CriteriaSet args = null)
		{
			return Where<CSGenioAs_ua>(false, args, numRegs: -1);
		}

		public static List<S_ua> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAs_ua>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<S_ua>((r) => new S_ua(r));
		}

// USE /[MANUAL GQT MODEL S_UA]/
	}
}
