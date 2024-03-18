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
	public class Perso : ModelBase
	{
		[JsonIgnore]
		public CSGenioAperso klass { get { return baseklass as CSGenioAperso; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(m_userContext, false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValCodperso")]
		public string ValCodperso { get { return klass.ValCodperso; } set { klass.ValCodperso = value; } }

		[DisplayName("Person name")]
		/// <summary>Field : "Person name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Identification number")]
		/// <summary>Field : "Identification number" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValIdentifi")]
		public string ValIdentifi { get { return klass.ValIdentifi; } set { klass.ValIdentifi = value; } }

		[DisplayName("Gender")]
		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValGender")]
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("Photo")]
		/// <summary>Field : "Photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public byte[] ValPhoto { get { return klass.ValPhoto; } set { klass.ValPhoto = value; } }

		[DisplayName("E-mail")]
		/// <summary>Field : "E-mail" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Year")]
		/// <summary>Field : "Year" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValYear")]
		[NumericAttribute(0)]
		public decimal? ValYear { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValYear, 0)); } set { klass.ValYear = Convert.ToDouble(value); } }

		[DisplayName("Month")]
		/// <summary>Field : "Month" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValMonth")]
		[DataArray("Months", GenioMVC.Helpers.ArrayType.Numeric)]
		public double ValMonth { get { return klass.ValMonth; } set { klass.ValMonth = value; } }
		[JsonIgnore]
		public SelectList ArrayValmonth { get { return new SelectList(CSGenio.business.ArrayMonths.GetDictionary(), "Key", "Value", ValMonth); } set { ValMonth = Convert.ToDouble(value.SelectedValue); } }

		[DisplayName("Date of birth")]
		/// <summary>Field : "Date of birth" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValDob")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDob { get { return klass.ValDob; } set { klass.ValDob = value ?? DateTime.MinValue; } }

		[DisplayName("Time of birth")]
		/// <summary>Field : "Time of birth" Tipo: "T" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValTob")]
		[DateAttribute("T")]
		public string ValTob { get { return klass.ValTob; } set { klass.ValTob = value; } }

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValCreatusr")]
		public string ValCreatusr { get { return klass.ValCreatusr; } set { klass.ValCreatusr = value; } }

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValCreatdat")]
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValCreatdat { get { return klass.ValCreatdat; } set { klass.ValCreatdat = value ?? DateTime.Now;  } }

		[DisplayName("Modified by")]
		/// <summary>Field : "Modified by" Tipo: "EN" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValModifusr")]
		public string ValModifusr { get { return klass.ValModifusr; } set { klass.ValModifusr = value; } }

		[DisplayName("Modified on")]
		/// <summary>Field : "Modified on" Tipo: "ED" Formula:  ""</summary>
		[ShouldSerialize("Perso.ValModifdat")]
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValModifdat { get { return klass.ValModifdat; } set { klass.ValModifdat = value ?? DateTime.MinValue;  } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Perso.ValZzstate")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Perso(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAperso(userContext.User);
            isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
        }

		public Perso(UserContext userContext, CSGenioAperso val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
        {
			klass = val;
			isEmptyModel = isEmpty;
            if (fieldsToSerialize != null)
                SetFieldsToSerialize(fieldsToSerialize);
            FillRelatedAreas(val);
        }


		public void FillRelatedAreas(CSGenioAperso csgenioa)
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
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Perso Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAperso>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Perso(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Perso> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAperso>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Perso>((r) => new Perso(userCtx, r));
		}

// USE /[MANUAL GQT MODEL PERSO]/
	}
}
