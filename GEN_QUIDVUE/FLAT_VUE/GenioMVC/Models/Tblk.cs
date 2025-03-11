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
	public class Tblk : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtblk klass { get { return baseklass as CSGenioAtblk; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) { _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); _globTable.SetIsEmptyModel(true); } return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Tblk.ValCodtblk")]
		public string ValCodtblk { get { return klass.ValCodtblk; } set { klass.ValCodtblk = value; } }

		[DisplayName("Foreign Key 1")]
		/// <summary>Field : "Foreign Key 1" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tblk.ValFkey1")]
		public string ValFkey1 { get { return klass.ValFkey1; } set { klass.ValFkey1 = value; } }

		private Grpb _grpb;
		[DisplayName("Grpb")]
		[ShouldSerialize("Grpb")]
		public virtual Grpb Grpb
		{
			get
			{
				if (!isEmptyModel && (_grpb == null || (!string.IsNullOrEmpty(ValFkey1) && (_grpb.isEmptyModel || _grpb.klass.QPrimaryKey != ValFkey1))))
					_grpb = Models.Grpb.Find(ValFkey1, m_userContext, Identifier, _fieldsToSerialize);
				_grpb ??= new Models.Grpb(m_userContext, true, _fieldsToSerialize);
				return _grpb;
			}
			set { _grpb = value; }
		}

		[DisplayName("Foreign Key 2")]
		/// <summary>Field : "Foreign Key 2" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Tblk.ValFkey2")]
		public string ValFkey2 { get { return klass.ValFkey2; } set { klass.ValFkey2 = value; } }

		private Trsb _trsb;
		[DisplayName("Trsb")]
		[ShouldSerialize("Trsb")]
		public virtual Trsb Trsb
		{
			get
			{
				if (!isEmptyModel && (_trsb == null || (!string.IsNullOrEmpty(ValFkey2) && (_trsb.isEmptyModel || _trsb.klass.QPrimaryKey != ValFkey2))))
					_trsb = Models.Trsb.Find(ValFkey2, m_userContext, Identifier, _fieldsToSerialize);
				_trsb ??= new Models.Trsb(m_userContext, true, _fieldsToSerialize);
				return _trsb;
			}
			set { _trsb = value; }
		}

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Tblk.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Tblk.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Tblk(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtblk(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Tblk(UserContext userContext, CSGenioAtblk val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtblk csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "grpb":
						_grpb ??= new Grpb(m_userContext, true, _fieldsToSerialize);
						_grpb.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "trsb":
						_trsb ??= new Trsb(m_userContext, true, _fieldsToSerialize);
						_trsb.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Tblk Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtblk>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Tblk(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Tblk> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtblk>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Tblk>((r) => new Tblk(userCtx, r));
		}

// USE /[MANUAL GQT MODEL TBLK]/
	}
}
