using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

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
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Games.ValCodgames")]
		public string ValCodgames { get { return klass.ValCodgames; } set { klass.ValCodgames = value; } }

		[DisplayName("Game date")]
		/// <summary>Field : "Game date" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Games.ValGamedt")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValGamedt { get { return klass.ValGamedt; } set { klass.ValGamedt = value ?? DateTime.MinValue; } }

		[DisplayName(">TEAM PLAYING AT HOME")]
		/// <summary>Field : ">TEAM PLAYING AT HOME" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Games.ValCodeqjgc")]
		public string ValCodeqjgc { get { return klass.ValCodeqjgc; } set { klass.ValCodeqjgc = value; } }
		private Teamp _teamp;
		[DisplayName("Teamp")]
		[ShouldSerialize("Teamp")]
		public virtual Teamp Teamp {
			get {
				if (!this.isEmptyModel && (_teamp == null || (!string.IsNullOrEmpty(ValCodeqjgc) && (_teamp.isEmptyModel || _teamp.klass.QPrimaryKey != ValCodeqjgc))))
					_teamp = Models.Teamp.Find(ValCodeqjgc, m_userContext, Identifier, _fieldsToSerialize);
				if (_teamp == null)
					_teamp = new Models.Teamp(m_userContext, true, _fieldsToSerialize);
				return _teamp;
			}
			set { _teamp = value; }
		}


		[DisplayName(">TEAM PLAYING AWAY")]
		/// <summary>Field : ">TEAM PLAYING AWAY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Games.ValCodeqjgf")]
		public string ValCodeqjgf { get { return klass.ValCodeqjgf; } set { klass.ValCodeqjgf = value; } }
		private Team1 _team1;
		[DisplayName("Team1")]
		[ShouldSerialize("Team1")]
		public virtual Team1 Team1 {
			get {
				if (!this.isEmptyModel && (_team1 == null || (!string.IsNullOrEmpty(ValCodeqjgf) && (_team1.isEmptyModel || _team1.klass.QPrimaryKey != ValCodeqjgf))))
					_team1 = Models.Team1.Find(ValCodeqjgf, m_userContext, Identifier, _fieldsToSerialize);
				if (_team1 == null)
					_team1 = new Models.Team1(m_userContext, true, _fieldsToSerialize);
				return _team1;
			}
			set { _team1 = value; }
		}


		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Games.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Games(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAgames(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Games(UserContext userContext, CSGenioAgames val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


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
							_teamp = new Teamp(m_userContext, true, _fieldsToSerialize);
						_teamp.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "team1":
						if (_team1 == null)
							_team1 = new Team1(m_userContext, true, _fieldsToSerialize);
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Games Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAgames>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Games(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Games> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAgames>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Games>((r) => new Games(userCtx, r));
		}

// USE /[MANUAL GQT MODEL GAMES]/
	}
}
