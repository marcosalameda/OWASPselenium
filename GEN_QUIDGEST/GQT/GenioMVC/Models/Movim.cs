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
	public class Movim : ModelBase
	{
		[JsonIgnore]
		public CSGenioAmovim klass { get { return baseklass as CSGenioAmovim; } set { baseklass = value; } }

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
		public string ValCodmovim { get { return klass.ValCodmovim; } set { klass.ValCodmovim = value; } }
		public bool ShouldSerializeValCodmovim() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValCodmovim");

		[DisplayName("Change")]
		/// <summary>Field : "Change" Tipo: "DT" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValDhmudanc { get { return klass.ValDhmudanc; } set { klass.ValDhmudanc = value ?? DateTime.MinValue; } }
		public bool ShouldSerializeValDhmudanc() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValDhmudanc");

		[DisplayName(">EQUIPMENT")]
		/// <summary>Field : ">EQUIPMENT" Tipo: "CE" Formula:  ""</summary>
		public string ValCodequip { get { return klass.ValCodequip; } set { klass.ValCodequip = value; } }
		public bool ShouldSerializeValCodequip() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValCodequip");
		private Equip _equip;
		[DisplayName("Equip")]
		public virtual Equip Equip { get { if (!this.isEmptyModel && (_equip == null || (!string.IsNullOrEmpty(ValCodequip) && (_equip.isEmptyModel || _equip.klass.QPrimaryKey != ValCodequip)))) _equip = Models.Equip.Find(ValCodequip, Identifier, _fieldsToSerialize); if (_equip == null) _equip = new Models.Equip(true, _fieldsToSerialize); return _equip; } set { _equip = value; } }
		public bool ShouldSerializeEquip () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Equip");

		[DisplayName(">ROOM")]
		/// <summary>Field : ">ROOM" Tipo: "CE" Formula:  ""</summary>
		public string ValCodrooms { get { return klass.ValCodrooms; } set { klass.ValCodrooms = value; } }
		public bool ShouldSerializeValCodrooms() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValCodrooms");
		private Rooms _rooms;
		[DisplayName("Rooms")]
		public virtual Rooms Rooms { get { if (!this.isEmptyModel && (_rooms == null || (!string.IsNullOrEmpty(ValCodrooms) && (_rooms.isEmptyModel || _rooms.klass.QPrimaryKey != ValCodrooms)))) _rooms = Models.Rooms.Find(ValCodrooms, Identifier, _fieldsToSerialize); if (_rooms == null) _rooms = new Models.Rooms(true, _fieldsToSerialize); return _rooms; } set { _rooms = value; } }
		public bool ShouldSerializeRooms () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Rooms");

		[DisplayName("Observation")]
		/// <summary>Field : "Observation" Tipo: "MO" Formula:  ""</summary>
		[DataType(DataType.MultilineText)]
		public string ValObservat { get { return klass.ValObservat; } set { klass.ValObservat = value; } }
		public bool ShouldSerializeValObservat() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValObservat");

		[DisplayName("N.R. Room")]
		/// <summary>Field : "N.R. Room" Tipo: "C" Formula: + "[ROOMS->ROOMNR]+" "+[ROOMS->DESIGNAT]"</summary>
		public string ValRoomnr { get { return klass.ValRoomnr; } set { klass.ValRoomnr = value; } }
		public bool ShouldSerializeValRoomnr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValRoomnr");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Movim.ValZzstate");

		public Movim() : this(UserContext.Current.User) { }

		public Movim(User u)
		{
			this.klass = new CSGenioAmovim(u);
		}

		public Movim(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Movim(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Movim(bool isEmpty) : this(isEmpty, null) { }

		public Movim(CSGenioAmovim val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Movim(CSGenioAmovim val) : this(val, null) { }

		public Movim(CSGenioAmovim val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Movim(CSGenioAmovim val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

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
							_equip = new Equip(true, _fieldsToSerialize);
						_equip.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "rooms":
						if (_rooms == null)
							_rooms = new Rooms(true, _fieldsToSerialize);
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
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Movim Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Movim Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAmovim>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Movim(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Movim> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAmovim>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Movim>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAmovim> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAmovim>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAmovim> All(CriteriaSet args = null)
		{
			return Where<CSGenioAmovim>(false, args, numRegs: -1);
		}

		public static List<Movim> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAmovim>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Movim>((r) => new Movim(r));
		}

// USE /[MANUAL GQT MODEL MOVIM]/
	}
}
