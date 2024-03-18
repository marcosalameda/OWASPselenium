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
	public class Games : ModelBase
	{
		[JsonIgnore]
		public CSGenioAgames klass { get { return baseklass as CSGenioAgames; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodgames { get { return klass.ValCodgames; } set { klass.ValCodgames = value; } }
		public bool ShouldSerializeValCodgames() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Games.ValCodgames");

		[DisplayName("Game date")]
		/// <summary>Field : "Game date" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValGamedt { get { return klass.ValGamedt; } set { klass.ValGamedt = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValGamedt() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Games.ValGamedt");

		[DisplayName(">TEAM PLAYING AT HOME")]
		/// <summary>Field : ">TEAM PLAYING AT HOME" Tipo: "CE" Formula:  ""</summary>
		public string ValCodeqjgc { get { return klass.ValCodeqjgc; } set { klass.ValCodeqjgc = value; } }
		public bool ShouldSerializeValCodeqjgc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Games.ValCodeqjgc");
		private Teamp _teamp;
		[DisplayName("Teamp")]
		public virtual Teamp Teamp { get { if (!this.isEmptyModel && (_teamp == null || (!string.IsNullOrEmpty(ValCodeqjgc) && (_teamp.isEmptyModel || _teamp.klass.QPrimaryKey != ValCodeqjgc)))) _teamp = Models.Teamp.Find(ValCodeqjgc, Identifier, _fieldsToSerialize); if (_teamp == null) _teamp = new Models.Teamp(true, _fieldsToSerialize); return _teamp; } set { _teamp = value; } }
		public bool ShouldSerializeTeamp () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Teamp");

		[DisplayName(">TEAM PLAYING AWAY")]
		/// <summary>Field : ">TEAM PLAYING AWAY" Tipo: "CE" Formula:  ""</summary>
		public string ValCodeqjgf { get { return klass.ValCodeqjgf; } set { klass.ValCodeqjgf = value; } }
		public bool ShouldSerializeValCodeqjgf() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Games.ValCodeqjgf");
		private Team1 _team1;
		[DisplayName("Team1")]
		public virtual Team1 Team1 { get { if (!this.isEmptyModel && (_team1 == null || (!string.IsNullOrEmpty(ValCodeqjgf) && (_team1.isEmptyModel || _team1.klass.QPrimaryKey != ValCodeqjgf)))) _team1 = Models.Team1.Find(ValCodeqjgf, Identifier, _fieldsToSerialize); if (_team1 == null) _team1 = new Models.Team1(true, _fieldsToSerialize); return _team1; } set { _team1 = value; } }
		public bool ShouldSerializeTeam1 () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Team1");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Games.ValZzstate");

		public Games() : this(UserContext.Current.User) { }

		public Games(User u)
		{
			this.klass = new CSGenioAgames(u);
		}

		public Games(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Games(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Games(bool isEmpty) : this(isEmpty, null) { }

		public Games(CSGenioAgames val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Games(CSGenioAgames val) : this(val, null) { }

		public Games(CSGenioAgames val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Games(CSGenioAgames val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAgames csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "teamp":
						if (_teamp == null)
							_teamp = new Teamp(true, _fieldsToSerialize);
						_teamp.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "team1":
						if (_team1 == null)
							_team1 = new Team1(true, _fieldsToSerialize);
						_team1.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Games Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Games Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgames>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Games(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Games> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAgames>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Games>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAgames> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAgames>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAgames> All(CriteriaSet args = null)
		{
			return Where<CSGenioAgames>(false, args, numRegs: -1);
		}

		public static List<Games> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgames>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Games>((r) => new Games(r));
		}

// USE /[MANUAL GQT MODEL GAMES]/
	}
}
