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
	public class Jdtst : ModelBase
	{
		[JsonIgnore]
		public CSGenioAjdtst klass { get { return baseklass as CSGenioAjdtst; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodjdtst { get { return klass.ValCodjdtst; } set { klass.ValCodjdtst = value; } }
		public bool ShouldSerializeValCodjdtst() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Jdtst.ValCodjdtst");

		[DisplayName("Nome")]
		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }
		public bool ShouldSerializeValNome() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Jdtst.ValNome");

		[DisplayName("Data de Registo")]
		/// <summary>Field : "Data de Registo" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDatareg { get { return klass.ValDatareg; } set { klass.ValDatareg = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDatareg() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Jdtst.ValDatareg");

		[DisplayName("Number")]
		/// <summary>Field : "Número" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValNumero { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNumero, 0)); } set { klass.ValNumero = Convert.ToDecimal(value); } }
		public bool ShouldSerializeValNumero() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Jdtst.ValNumero");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Jdtst.ValZzstate");

		public Jdtst() : this(UserContext.Current.User) { }

		public Jdtst(User u)
		{
			this.klass = new CSGenioAjdtst(u);
		}

		public Jdtst(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Jdtst(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Jdtst(bool isEmpty) : this(isEmpty, null) { }

		public Jdtst(CSGenioAjdtst val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Jdtst(CSGenioAjdtst val) : this(val, null) { }

		public Jdtst(CSGenioAjdtst val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Jdtst(CSGenioAjdtst val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAjdtst csgenioa)
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
		public static Jdtst Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Jdtst Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAjdtst>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Jdtst(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Jdtst> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAjdtst>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Jdtst>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAjdtst> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAjdtst>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAjdtst> All(CriteriaSet args = null)
		{
			return Where<CSGenioAjdtst>(false, args, numRegs: -1);
		}

		public static List<Jdtst> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAjdtst>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Jdtst>((r) => new Jdtst(r));
		}

// USE /[MANUAL GQT MODEL JDTST]/
	}
}
