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
	public class Tblk : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtblk klass { get { return baseklass as CSGenioAtblk; } set { baseklass = value; } }

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
		public string ValCodtblk { get { return klass.ValCodtblk; } set { klass.ValCodtblk = value; } }
		public bool ShouldSerializeValCodtblk() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblk.ValCodtblk");

		[DisplayName("Foreign Key 1")]
		/// <summary>Field : "Foreign Key 1" Tipo: "CE" Formula:  ""</summary>
		public string ValFkey1 { get { return klass.ValFkey1; } set { klass.ValFkey1 = value; } }
		public bool ShouldSerializeValFkey1() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblk.ValFkey1");
		private Grpb _grpb;
		[DisplayName("Grpb")]
		public virtual Grpb Grpb { get { if (!this.isEmptyModel && (_grpb == null || (!string.IsNullOrEmpty(ValFkey1) && (_grpb.isEmptyModel || _grpb.klass.QPrimaryKey != ValFkey1)))) _grpb = Models.Grpb.Find(ValFkey1, Identifier, _fieldsToSerialize); if (_grpb == null) _grpb = new Models.Grpb(true, _fieldsToSerialize); return _grpb; } set { _grpb = value; } }
		public bool ShouldSerializeGrpb () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Grpb");

		[DisplayName("Foreign Key 2")]
		/// <summary>Field : "Foreign Key 2" Tipo: "CE" Formula:  ""</summary>
		public string ValFkey2 { get { return klass.ValFkey2; } set { klass.ValFkey2 = value; } }
		public bool ShouldSerializeValFkey2() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblk.ValFkey2");
		private Trsb _trsb;
		[DisplayName("Trsb")]
		public virtual Trsb Trsb { get { if (!this.isEmptyModel && (_trsb == null || (!string.IsNullOrEmpty(ValFkey2) && (_trsb.isEmptyModel || _trsb.klass.QPrimaryKey != ValFkey2)))) _trsb = Models.Trsb.Find(ValFkey2, Identifier, _fieldsToSerialize); if (_trsb == null) _trsb = new Models.Trsb(true, _fieldsToSerialize); return _trsb; } set { _trsb = value; } }
		public bool ShouldSerializeTrsb () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Trsb");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblk.ValName");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tblk.ValZzstate");

		public Tblk() : this(UserContext.Current.User) { }

		public Tblk(User u)
		{
			this.klass = new CSGenioAtblk(u);
		}

		public Tblk(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblk(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tblk(bool isEmpty) : this(isEmpty, null) { }

		public Tblk(CSGenioAtblk val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblk(CSGenioAtblk val) : this(val, null) { }

		public Tblk(CSGenioAtblk val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tblk(CSGenioAtblk val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtblk csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "grpb":
						if (_grpb == null)
							_grpb = new Grpb(true, _fieldsToSerialize);
						_grpb.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "trsb":
						if (_trsb == null)
							_trsb = new Trsb(true, _fieldsToSerialize);
						_trsb.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tblk Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tblk Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtblk>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tblk(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tblk> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtblk>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tblk>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtblk> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtblk>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtblk> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtblk>(false, args, numRegs: -1);
		}

		public static List<Tblk> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtblk>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tblk>((r) => new Tblk(r));
		}

// USE /[MANUAL GQT MODEL TBLK]/
	}
}
