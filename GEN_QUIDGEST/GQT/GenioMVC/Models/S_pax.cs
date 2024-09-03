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
	public class S_pax : ModelBase
	{
		[JsonIgnore]
		public CSGenioAs_pax klass { get { return baseklass as CSGenioAs_pax; } set { baseklass = value; } }

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
		public string ValCodpranx { get { return klass.ValCodpranx; } set { klass.ValCodpranx = value; } }
		public bool ShouldSerializeValCodpranx() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValCodpranx");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCods_apr { get { return klass.ValCods_apr; } set { klass.ValCods_apr = value; } }
		public bool ShouldSerializeValCods_apr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValCods_apr");
		private S_apr _s_apr;
		[DisplayName("S_apr")]
		public virtual S_apr S_apr { get { if (!this.isEmptyModel && (_s_apr == null || (!string.IsNullOrEmpty(ValCods_apr) && (_s_apr.isEmptyModel || _s_apr.klass.QPrimaryKey != ValCods_apr)))) _s_apr = Models.S_apr.Find(ValCods_apr, Identifier, _fieldsToSerialize); if (_s_apr == null) _s_apr = new Models.S_apr(true, _fieldsToSerialize); return _s_apr; } set { _s_apr = value; } }
		public bool ShouldSerializeS_apr () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_apr");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocument", true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }
		public bool ShouldSerializeValDocument() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValDocument");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValDatacria");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_pax.ValZzstate");

		public S_pax() : this(UserContext.Current.User) { }

		public S_pax(User u)
		{
			this.klass = new CSGenioAs_pax(u);
		}

		public S_pax(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_pax(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public S_pax(bool isEmpty) : this(isEmpty, null) { }

		public S_pax(CSGenioAs_pax val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_pax(CSGenioAs_pax val) : this(val, null) { }

		public S_pax(CSGenioAs_pax val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public S_pax(CSGenioAs_pax val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAs_pax csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "s_apr":
						if (_s_apr == null)
							_s_apr = new S_apr(true, _fieldsToSerialize);
						_s_apr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static S_pax Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static S_pax Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAs_pax>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new S_pax(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<S_pax> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAs_pax>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<S_pax>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAs_pax> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAs_pax>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAs_pax> All(CriteriaSet args = null)
		{
			return Where<CSGenioAs_pax>(false, args, numRegs: -1);
		}

		public static List<S_pax> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAs_pax>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<S_pax>((r) => new S_pax(r));
		}

// USE /[MANUAL GQT MODEL S_PAX]/
	}
}
