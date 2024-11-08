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
	public class Mem : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmem klass { get { return baseklass as CSGenioAmem; } set { baseklass = value; } }

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
		public string ValCodmem { get { return klass.ValCodmem; } set { klass.ValCodmem = value; } }
		public bool ShouldSerializeValCodmem() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValCodmem");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValLogin { get { return klass.ValLogin; } set { klass.ValLogin = value; } }
		public bool ShouldSerializeValLogin() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValLogin");

		[DisplayName("Routine")]
		/// <summary>Field : "Routine" Tipo: "C" Formula:  ""</summary>
		public string ValRotina { get { return klass.ValRotina; } set { klass.ValRotina = value; } }
		public bool ShouldSerializeValRotina() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValRotina");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValAltura { get { return klass.ValAltura; } set { klass.ValAltura = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValAltura() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValAltura");

		[DisplayName("Obs")]
		/// <summary>Field : "Obs" Tipo: "C" Formula:  ""</summary>
		public string ValObs { get { return klass.ValObs; } set { klass.ValObs = value; } }
		public bool ShouldSerializeValObs() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValObs");

		[DisplayName("Host")]
		/// <summary>Field : "Host" Tipo: "C" Formula:  ""</summary>
		public string ValHostid { get { return klass.ValHostid; } set { klass.ValHostid = value; } }
		public bool ShouldSerializeValHostid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValHostid");

		[DisplayName("Client ip address")]
		/// <summary>Field : "Client ip address" Tipo: "C" Formula:  ""</summary>
		public string ValClientid { get { return klass.ValClientid; } set { klass.ValClientid = value; } }
		public bool ShouldSerializeValClientid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValClientid");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Mem.ValZzstate");

		public Mem() : this(UserContext.Current.User) { }

		public Mem(User u)
		{
			this.klass = new CSGenioAmem(u);
		}

		public Mem(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Mem(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Mem(bool isEmpty) : this(isEmpty, null) { }

		public Mem(CSGenioAmem val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Mem(CSGenioAmem val) : this(val, null) { }

		public Mem(CSGenioAmem val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Mem(CSGenioAmem val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAmem csgenioa)
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
		public static Mem Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Mem Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmem>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Mem(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Mem> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAmem>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Mem>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAmem> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAmem>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAmem> All(CriteriaSet args = null)
		{
			return Where<CSGenioAmem>(false, args, numRegs: -1);
		}

		public static List<Mem> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmem>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Mem>((r) => new Mem(r));
		}

// USE /[MANUAL GQT MODEL MEM]/
	}
}
