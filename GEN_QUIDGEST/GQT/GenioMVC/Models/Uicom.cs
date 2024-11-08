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
	public class Uicom : ModelBase
	{
		[JsonIgnore]
		public CSGenioAuicom klass { get { return baseklass as CSGenioAuicom; } set { baseklass = value; } }

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
		public string ValCoduicom { get { return klass.ValCoduicom; } set { klass.ValCoduicom = value; } }
		public bool ShouldSerializeValCoduicom() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValCoduicom");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValName");

		[DisplayName("Category")]
		/// <summary>Field : "Category" Tipo: "C" Formula:  ""</summary>
		public string ValCategory { get { return klass.ValCategory; } set { klass.ValCategory = value; } }
		public bool ShouldSerializeValCategory() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValCategory");

		[DisplayName("Fixed menu name")]
		/// <summary>Field : "Fixed menu name" Tipo: "C" Formula:  ""</summary>
		public string ValMenuid { get { return klass.ValMenuid; } set { klass.ValMenuid = value; } }
		public bool ShouldSerializeValMenuid() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValMenuid");

		[DisplayName("Thumbnail")]
		/// <summary>Field : "Thumbnail" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValThumbnai { get { return klass.ValThumbnai; } set { klass.ValThumbnai = value; } }
		public bool ShouldSerializeValThumbnai() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValThumbnai");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Uicom.ValZzstate");

		public Uicom() : this(UserContext.Current.User) { }

		public Uicom(User u)
		{
			this.klass = new CSGenioAuicom(u);
		}

		public Uicom(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Uicom(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Uicom(bool isEmpty) : this(isEmpty, null) { }

		public Uicom(CSGenioAuicom val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Uicom(CSGenioAuicom val) : this(val, null) { }

		public Uicom(CSGenioAuicom val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Uicom(CSGenioAuicom val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAuicom csgenioa)
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
		public static Uicom Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Uicom Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAuicom>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Uicom(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Uicom> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAuicom>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Uicom>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAuicom> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAuicom>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAuicom> All(CriteriaSet args = null)
		{
			return Where<CSGenioAuicom>(false, args, numRegs: -1);
		}

		public static List<Uicom> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAuicom>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Uicom>((r) => new Uicom(r));
		}

// USE /[MANUAL GQT MODEL UICOM]/
	}
}
