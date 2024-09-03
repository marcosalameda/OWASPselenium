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
	public class Space : ModelBase
	{
		[JsonIgnore]
		public CSGenioAspace klass { get { return baseklass as CSGenioAspace; } set { baseklass = value; } }

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
		public string ValCodespac { get { return klass.ValCodespac; } set { klass.ValCodespac = value; } }
		public bool ShouldSerializeValCodespac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValCodespac");

		[DisplayName("Code")]
		/// <summary>Field : "Code" Tipo: "TF" Formula:  ""</summary>
		public string ValCode { get { return klass.ValCode; } set { klass.ValCode = value; } }
		public bool ShouldSerializeValCode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValCode");

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValDesignat { get { return klass.ValDesignat; } set { klass.ValDesignat = value; } }
		public bool ShouldSerializeValDesignat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValDesignat");

		[DisplayName("Acronym")]
		/// <summary>Field : "Acronym" Tipo: "C" Formula:  ""</summary>
		public string ValSigla { get { return klass.ValSigla; } set { klass.ValSigla = value; } }
		public bool ShouldSerializeValSigla() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValSigla");

		[DisplayName("Level")]
		/// <summary>Field : "Level" Tipo: "TN" Formula:  ""</summary>
		public decimal ValNivel { get { return klass.ValNivel; } set { klass.ValNivel = value; } }
		public bool ShouldSerializeValNivel() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValNivel");

		[DisplayName("Dependency")]
		/// <summary>Field : "Dependency" Tipo: "TP" Formula:  ""</summary>
		public string ValCodigode { get { return klass.ValCodigode; } set { klass.ValCodigode = value; } }
		public bool ShouldSerializeValCodigode() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValCodigode");

		[DisplayName("Moving")]
		/// <summary>Field : "Moving" Tipo: "TM" Formula:  ""</summary>
		public bool ValMoviment { get { return Convert.ToBoolean(klass.ValMoviment); } set { klass.ValMoviment = Convert.ToInt32(value); } }
		public bool ShouldSerializeValMoviment() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValMoviment");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Space.ValZzstate");

		public Space() : this(UserContext.Current.User) { }

		public Space(User u)
		{
			this.klass = new CSGenioAspace(u);
		}

		public Space(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Space(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Space(bool isEmpty) : this(isEmpty, null) { }

		public Space(CSGenioAspace val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Space(CSGenioAspace val) : this(val, null) { }

		public Space(CSGenioAspace val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Space(CSGenioAspace val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAspace csgenioa)
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
		public static Space Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Space Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAspace>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Space(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Space> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAspace>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Space>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAspace> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAspace>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAspace> All(CriteriaSet args = null)
		{
			return Where<CSGenioAspace>(false, args, numRegs: -1);
		}

		public static List<Space> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAspace>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Space>((r) => new Space(r));
		}

// USE /[MANUAL GQT MODEL SPACE]/
	}
}
