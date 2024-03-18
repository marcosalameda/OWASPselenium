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
	public class Prpin : ModelBase
	{
		[JsonIgnore]
		public CSGenioAprpin klass { get { return baseklass as CSGenioAprpin; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "Primary key" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCodpesso")]
		public string ValCodpesso { get { return klass.ValCodpesso; } set { klass.ValCodpesso = value; } }

		[DisplayName("Foreign key")]
		/// <summary>Field : "Foreign key" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCodpsw")]
		public string ValCodpsw { get { return klass.ValCodpsw; } set { klass.ValCodpsw = value; } }
		private Psw _psw;
		[DisplayName("Psw")]
		[ShouldSerialize("Psw")]
		public virtual Psw Psw { 
			get { 
				if (!this.isEmptyModel && (_psw == null || (!string.IsNullOrEmpty(ValCodpsw) && (_psw.isEmptyModel || _psw.klass.QPrimaryKey != ValCodpsw))))
					_psw = Models.Psw.Find(ValCodpsw, m_userContext, Identifier, _fieldsToSerialize);
				if (_psw == null)
					_psw = new Models.Psw(m_userContext, true, _fieldsToSerialize);
				return _psw;
			}
			set { _psw = value; } 
		}
		

		[DisplayName("Mechanografic number")]
		/// <summary>Field : "Mechanografic number" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValNummecan")]
		[NumericAttribute(0)]
		public decimal? ValNummecan { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValNummecan, 0)); } set { klass.ValNummecan = Convert.ToDouble(value); } }

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValPessoa")]
		public string ValPessoa { get { return klass.ValPessoa; } set { klass.ValPessoa = value; } }

		[DisplayName("Role")]
		/// <summary>Field : "Role" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCargo")]
		public string ValCargo { get { return klass.ValCargo; } set { klass.ValCargo = value; } }

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Individual Notifications")]
		/// <summary>Field : "Individual Notifications" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValNotifind")]
		public bool ValNotifind { get { return Convert.ToBoolean(klass.ValNotifind); } set { klass.ValNotifind = Convert.ToInt32(value); } }

		[DisplayName("Foreign key")]
		/// <summary>Field : "Foreign key" Tipo: "CF" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCodorgaf")]
		public string ValCodorgaf { get { return klass.ValCodorgaf; } set { klass.ValCodorgaf = value; } }

		[DisplayName("External Entity")]
		/// <summary>Field : "External Entity" Tipo: "L" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValEexterna")]
		public bool ValEexterna { get { return Convert.ToBoolean(klass.ValEexterna); } set { klass.ValEexterna = Convert.ToInt32(value); } }

		[DisplayName("Creation date")]
		/// <summary>Field : "Creation date" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValCreatope")]
		public string ValCreatope { get { return klass.ValCreatope; } set { klass.ValCreatope = value; } }

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValChngdate")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValChngdate { get { return klass.ValChngdate; } set { klass.ValChngdate = value ?? DateTime.MinValue;  } }

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Prpin.ValOperchng")]
		public string ValOperchng { get { return klass.ValOperchng; } set { klass.ValOperchng = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Prpin.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Prpin(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAprpin(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Prpin(UserContext userContext, CSGenioAprpin val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAprpin csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "psw":
						if (_psw == null)
							_psw = new Psw(m_userContext, true, _fieldsToSerialize);
						_psw.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Prpin Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAprpin>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Prpin(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Prpin> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAprpin>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Prpin>((r) => new Prpin(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PRPIN]/
	}
}
