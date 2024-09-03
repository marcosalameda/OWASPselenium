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
	public class Agent : ModelBase
	{
		[JsonIgnore]
		public CSGenioAagent klass { get { return baseklass as CSGenioAagent; } set { baseklass = value; } }

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
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }
		public bool ShouldSerializeValCodagent() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValCodagent");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValName");

		[DisplayName("Birthdate")]
		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthdat { get { return klass.ValBirthdat; } set { klass.ValBirthdat = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValBirthdat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValBirthdat");

		[DisplayName("Email")]
		/// <summary>Field : "Email" Tipo: "C" Formula: DF ""@agency.com""</summary>
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }
		public bool ShouldSerializeValEmail() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValEmail");

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }
		public bool ShouldSerializeValPhoto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValPhoto");

		[DisplayName("Telephone")]
		/// <summary>Field : "Telephone" Tipo: "C" Formula:  ""</summary>
		public string ValTelephon { get { return klass.ValTelephon; } set { klass.ValTelephon = value; } }
		public bool ShouldSerializeValTelephon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValTelephon");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Agent.ValZzstate");

		public Agent() : this(UserContext.Current.User) { }

		public Agent(User u)
		{
			this.klass = new CSGenioAagent(u);
		}

		public Agent(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agent(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Agent(bool isEmpty) : this(isEmpty, null) { }

		public Agent(CSGenioAagent val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agent(CSGenioAagent val) : this(val, null) { }

		public Agent(CSGenioAagent val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Agent(CSGenioAagent val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAagent csgenioa)
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
		public static Agent Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Agent Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAagent>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Agent(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Agent> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAagent>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Agent>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAagent> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAagent>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAagent> All(CriteriaSet args = null)
		{
			return Where<CSGenioAagent>(false, args, numRegs: -1);
		}

		public static List<Agent> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAagent>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Agent>((r) => new Agent(r));
		}

// USE /[MANUAL GQT MODEL AGENT]/
	}
}
