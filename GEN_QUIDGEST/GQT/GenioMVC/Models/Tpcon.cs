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
	public class Tpcon : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtpcon klass { get { return baseklass as CSGenioAtpcon; } set { baseklass = value; } }

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
		public string ValCodtpcon { get { return klass.ValCodtpcon; } set { klass.ValCodtpcon = value; } }
		public bool ShouldSerializeValCodtpcon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon.ValCodtpcon");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodgenre { get { return klass.ValCodgenre; } set { klass.ValCodgenre = value; } }
		public bool ShouldSerializeValCodgenre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon.ValCodgenre");
		private Genre _genre;
		[DisplayName("Genre")]
		public virtual Genre Genre { get { if (!this.isEmptyModel && (_genre == null || (!string.IsNullOrEmpty(ValCodgenre) && (_genre.isEmptyModel || _genre.klass.QPrimaryKey != ValCodgenre)))) _genre = Models.Genre.Find(ValCodgenre, Identifier, _fieldsToSerialize); if (_genre == null) _genre = new Models.Genre(true, _fieldsToSerialize); return _genre; } set { _genre = value; } }
		public bool ShouldSerializeGenre () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre");

		[DisplayName("Genre")]
		/// <summary>Field : "Genre" Tipo: "AC" Formula:  ""</summary>
		[DataArray("Genconta", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGenconta { get { return klass.ValGenconta; } set { klass.ValGenconta = value; } }
		[JsonIgnore]
		public SelectList ArrayValgenconta { get { return new SelectList(CSGenio.business.ArrayGenconta.GetDictionary(), "Key", "Value", ValGenconta); } set { ValGenconta = value.SelectedValue as string; } }
		public bool ShouldSerializeValGenconta() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon.ValGenconta");

		[DisplayName("Designation")]
		/// <summary>Field : "Designation" Tipo: "C" Formula:  ""</summary>
		public string ValTipocont { get { return klass.ValTipocont; } set { klass.ValTipocont = value; } }
		public bool ShouldSerializeValTipocont() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon.ValTipocont");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon.ValZzstate");

		public Tpcon() : this(UserContext.Current.User) { }

		public Tpcon(User u)
		{
			this.klass = new CSGenioAtpcon(u);
		}

		public Tpcon(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpcon(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Tpcon(bool isEmpty) : this(isEmpty, null) { }

		public Tpcon(CSGenioAtpcon val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tpcon(CSGenioAtpcon val) : this(val, null) { }

		public Tpcon(CSGenioAtpcon val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Tpcon(CSGenioAtpcon val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAtpcon csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "genre":
						if (_genre == null)
							_genre = new Genre(true, _fieldsToSerialize);
						_genre.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tpcon Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Tpcon Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtpcon>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tpcon(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Tpcon> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAtpcon>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Tpcon>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAtpcon> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAtpcon>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAtpcon> All(CriteriaSet args = null)
		{
			return Where<CSGenioAtpcon>(false, args, numRegs: -1);
		}

		public static List<Tpcon> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtpcon>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tpcon>((r) => new Tpcon(r));
		}

// USE /[MANUAL GQT MODEL TPCON]/
	}
}
