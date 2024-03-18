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
	public class Conta : ModelBase
	{
		[JsonIgnore]
		public CSGenioAconta klass { get { return baseklass as CSGenioAconta; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodconta { get { return klass.ValCodconta; } set { klass.ValCodconta = value; } }
		public bool ShouldSerializeValCodconta() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValCodconta");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }
		public bool ShouldSerializeValCodpesso() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValCodpesso");
		private Pesso _pesso;
		[DisplayName("Pesso")]
		public virtual Pesso Pesso { get { if (!this.isEmptyModel && (_pesso == null || (!string.IsNullOrEmpty(ValCodpesso) && (_pesso.isEmptyModel || _pesso.klass.QPrimaryKey != ValCodpesso)))) _pesso = Models.Pesso.Find(ValCodpesso, Identifier, _fieldsToSerialize); if (_pesso == null) _pesso = new Models.Pesso(true, _fieldsToSerialize); return _pesso; } set { _pesso = value; } }
		public bool ShouldSerializePesso () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Pesso");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodgenre { get { return klass.ValCodgenre; } set { klass.ValCodgenre = value; } }
		public bool ShouldSerializeValCodgenre() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValCodgenre");
		private Genre _genre;
		[DisplayName("Genre")]
		public virtual Genre Genre { get { if (!this.isEmptyModel && (_genre == null || (!string.IsNullOrEmpty(ValCodgenre) && (_genre.isEmptyModel || _genre.klass.QPrimaryKey != ValCodgenre)))) _genre = Models.Genre.Find(ValCodgenre, Identifier, _fieldsToSerialize); if (_genre == null) _genre = new Models.Genre(true, _fieldsToSerialize); return _genre; } set { _genre = value; } }
		public bool ShouldSerializeGenre () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Genre");

		[DisplayName("Contact type")]
		/// <summary>Field : "Contact type" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtpcon { get { return klass.ValCodtpcon; } set { klass.ValCodtpcon = value; } }
		public bool ShouldSerializeValCodtpcon() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValCodtpcon");
		private Tpcon _tpcon;
		[DisplayName("Tpcon")]
		public virtual Tpcon Tpcon { get { if (!this.isEmptyModel && (_tpcon == null || (!string.IsNullOrEmpty(ValCodtpcon) && (_tpcon.isEmptyModel || _tpcon.klass.QPrimaryKey != ValCodtpcon)))) _tpcon = Models.Tpcon.Find(ValCodtpcon, Identifier, _fieldsToSerialize); if (_tpcon == null) _tpcon = new Models.Tpcon(true, _fieldsToSerialize); return _tpcon; } set { _tpcon = value; } }
		public bool ShouldSerializeTpcon () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Tpcon");

		[DisplayName("Contact")]
		/// <summary>Field : "Contact" Tipo: "C" Formula:  ""</summary>
		public string ValContacto { get { return klass.ValContacto; } set { klass.ValContacto = value; } }
		public bool ShouldSerializeValContacto() => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValContacto");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("Conta.ValZzstate");

		public Conta() : this(UserContext.Current.User) { }

		public Conta(User u)
		{
			this.klass = new CSGenioAconta(u);
		}

		public Conta(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public Conta(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public Conta(bool isEmpty) : this(isEmpty, null) { }

		public Conta(CSGenioAconta val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public Conta(CSGenioAconta val) : this(val, null) { }

		public Conta(CSGenioAconta val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public Conta(CSGenioAconta val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAconta csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "pesso":
						if (_pesso == null)
							_pesso = new Pesso(true, _fieldsToSerialize);
						_pesso.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "genre":
						if (_genre == null)
							_genre = new Genre(true, _fieldsToSerialize);
						_genre.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "tpcon":
						if (_tpcon == null)
							_tpcon = new Tpcon(true, _fieldsToSerialize);
						_tpcon.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Conta Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static Conta Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAconta>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Conta(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<Conta> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAconta>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<Conta>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAconta> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAconta>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAconta> All(CriteriaSet args = null)
		{
			return Where<CSGenioAconta>(false, args, numRegs: -1);
		}

		public static List<Conta> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAconta>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Conta>((r) => new Conta(r));
		}

// USE /[MANUAL GQT MODEL CONTA]/
	}
}
