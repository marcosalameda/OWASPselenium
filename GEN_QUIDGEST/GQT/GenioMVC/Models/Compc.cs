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
	public class Compc : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcompc klass { get { return baseklass as CSGenioAcompc; } set { baseklass = value; } }

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
		public string ValCodcompc { get { return klass.ValCodcompc; } set { klass.ValCodcompc = value; } }
		public bool ShouldSerializeValCodcompc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc.ValCodcompc");

		[DisplayName("Components Class")]
		/// <summary>Field : "Components Class" Tipo: "C" Formula:  ""</summary>
		public string ValCompclas { get { return klass.ValCompclas; } set { klass.ValCompclas = value; } }
		public bool ShouldSerializeValCompclas() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc.ValCompclas");

		[DisplayName("Class Description")]
		/// <summary>Field : "Class Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValClassdes { get { return klass.ValClassdes; } set { klass.ValClassdes = value; } }
		public bool ShouldSerializeValClassdes() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc.ValClassdes");

		[DisplayName("Class icon")]
		/// <summary>Field : "Class icon" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValClassico { get { return klass.ValClassico; } set { klass.ValClassico = value; } }
		public bool ShouldSerializeValClassico() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc.ValClassico");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Compc.ValZzstate");

		public Compc() : this(UserContext.Current.User) { }

		public Compc(User u)
		{
			this.klass = new CSGenioAcompc(u);
		}

		public Compc(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compc(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Compc(bool isEmpty) : this(isEmpty, null) { }

		public Compc(CSGenioAcompc val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Compc(CSGenioAcompc val) : this(val, null) { }

		public Compc(CSGenioAcompc val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Compc(CSGenioAcompc val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAcompc csgenioa)
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
		public static Compc Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Compc Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcompc>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Compc(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Compc> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAcompc>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Compc>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAcompc> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAcompc>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAcompc> All(CriteriaSet args = null)
		{
			return Where<CSGenioAcompc>(false, args, numRegs: -1);
		}

		public static List<Compc> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcompc>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Compc>((r) => new Compc(r));
		}

// USE /[MANUAL GQT MODEL COMPC]/
	}
}
