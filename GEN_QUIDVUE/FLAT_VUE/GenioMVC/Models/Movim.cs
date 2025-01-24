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
	public class Movim : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmovim klass { get { return baseklass as CSGenioAmovim; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Movim.ValCodmovim")]
		public string ValCodmovim { get { return klass.ValCodmovim; } set { klass.ValCodmovim = value; } }

		[DisplayName("Change")]
		/// <summary>Field : "Change" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Movim.ValDhmudanc")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhmudanc { get { return klass.ValDhmudanc; } set { klass.ValDhmudanc = value ?? DateTime.MinValue; } }

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Movim.ValCodequip")]
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		private Equip _equip;
		[DisplayName("Equip")]
		[ShouldSerialize("Equip")]
		public virtual Equip Equip {
			get {
				if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip))))
					_equip = Models.Equip.Find(ValCodequip, m_userContext, Identifier, _fieldsToSerialize);
				if (_equip == null)
					_equip = new Models.Equip(m_userContext, true, _fieldsToSerialize);
				return _equip;
			}
			set { _equip = value; }
		}


		[DisplayName(">ROOM")]
		/// <summary>Field : ">ROOM" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Movim.ValCodrooms")]
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }
		private Rooms _rooms;
		[DisplayName("Rooms")]
		[ShouldSerialize("Rooms")]
		public virtual Rooms Rooms {
			get {
				if (!this.isEmptyModel && (_rooms == null || (!string.IsNullOrEmpty(ValCodrooms) && (_rooms.isEmptyModel || _rooms.klass.QPrimaryKey != ValCodrooms))))
					_rooms = Models.Rooms.Find(ValCodrooms, m_userContext, Identifier, _fieldsToSerialize);
				if (_rooms == null)
					_rooms = new Models.Rooms(m_userContext, true, _fieldsToSerialize);
				return _rooms;
			}
			set { _rooms = value; }
		}


		[DisplayName("Observation")]
		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Movim.ValObservat")]
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }

		[DisplayName("N.R. Room")]
		/// <summary>Field : "N.R. Room" Tipo: "C" Formula: + "[ROOMS->ROOMNR]+" "+[ROOMS->DESIGNAT]"</summary>
		[ShouldSerialize("Movim.ValRoomnr")]
		public string ValRoomnr { get { return klass.ValRoomnr; } set { klass.ValRoomnr = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Movim.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Movim(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAmovim(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Movim(UserContext userContext, CSGenioAmovim val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}


		public void FillRelatedAreas(CSGenioAmovim csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "equip":
						if (_equip == null)
							_equip = new Equip(m_userContext, true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "rooms":
						if (_rooms == null)
							_rooms = new Rooms(m_userContext, true, _fieldsToSerialize);
						_rooms.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Movim Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmovim>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Movim(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Movim> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmovim>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Movim>((r) => new Movim(userCtx, r));
		}

// USE /[MANUAL GQT MODEL MOVIM]/
	}
}
