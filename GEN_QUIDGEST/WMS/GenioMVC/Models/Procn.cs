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
	public class Procn : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprocn klass { get { return baseklass as CSGenioAprocn; } set { baseklass = value; } }

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
		public string ValCodprocn { get { return klass.ValCodprocn; } set { klass.ValCodprocn = value; } }
		public bool ShouldSerializeValCodprocn() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValCodprocn");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValName");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValEmail");

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValTelephon");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValDescript { get { return klass.ValDescript; } set { klass.ValDescript = value; } }
		public bool ShouldSerializeValDescript() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValDescript");

		[DisplayName("Date")]
		/// <summary>Field : "Date" Tipo: "D" Formula: DF "[Today]"</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDate() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValDate");

		[DisplayName("Property")]
		/// <summary>Field : "Property" Tipo: "CE" Formula:  ""</summary>
		public string ValCodprope { get { return klass.ValCodprope; } set { klass.ValCodprope = value; } }
		public bool ShouldSerializeValCodprope() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValCodprope");
		private Prope _prope;
		[DisplayName("Prope")]
		public virtual Prope Prope { get { if (!this.isEmptyModel && (_prope == null || (!string.IsNullOrEmpty(ValCodprope) && (_prope.isEmptyModel || _prope.klass.QPrimaryKey != ValCodprope)))) _prope = Models.Prope.Find(ValCodprope, Identifier, _fieldsToSerialize); if (_prope == null) _prope = new Models.Prope(true, _fieldsToSerialize); return _prope; } set { _prope = value; } }
		public bool ShouldSerializePrope () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Prope");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Procn.ValZzstate");

		public Procn() : this(UserContext.Current.User) { }

		public Procn(User u)
		{
			this.klass = new CSGenioAprocn(u);
		}

		public Procn(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Procn(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Procn(bool isEmpty) : this(isEmpty, null) { }

		public Procn(CSGenioAprocn val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Procn(CSGenioAprocn val) : this(val, null) { }

		public Procn(CSGenioAprocn val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Procn(CSGenioAprocn val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAprocn csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "prope":
						if (_prope == null)
							_prope = new Prope(true, _fieldsToSerialize);
						_prope.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Procn Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Procn Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprocn>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Procn(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Procn> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAprocn>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Procn>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAprocn> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAprocn>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAprocn> All(CriteriaSet args = null)
		{
			return Where<CSGenioAprocn>(false, args, numRegs: -1);
		}

		public static List<Procn> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprocn>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Procn>((r) => new Procn(r));
		}

// USE /[MANUAL GQT MODEL PROCN]/
	}
}
