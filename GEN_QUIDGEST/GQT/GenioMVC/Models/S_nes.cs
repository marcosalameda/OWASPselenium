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
	public class S_nes : ModelBase
	{
		[JsonIgnore]
		public CSGenioAs_nes klass { get { return baseklass as CSGenioAs_nes; } set { baseklass = value; } }

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
		public string ValCodsigna { get { return klass.ValCodsigna; } set { klass.ValCodsigna = value; } }
		public bool ShouldSerializeValCodsigna() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValCodsigna");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }
		public bool ShouldSerializeValName() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValName");

		[DisplayName("Image")]
		/// <summary>Field : "Image" Tipo: "IJ" Formula:  ""</summary>
		[Newtonsoft.Json.JsonConverter(typeof(Helpers.ResizeImageSerializer), 75, 75, true)]
		public byte[] ValImage { get { return klass.ValImage; } set { klass.ValImage = value; } }
		public bool ShouldSerializeValImage() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValImage");

		[DisplayName("Text after signature")]
		/// <summary>Field : "Text after signature" Tipo: "C" Formula:  ""</summary>
		public string ValTextass { get { return klass.ValTextass; } set { klass.ValTextass = value; } }
		public bool ShouldSerializeValTextass() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValTextass");

		[DisplayName("Username")]
		/// <summary>Field : "Username" Tipo: "C" Formula:  ""</summary>
		public string ValUsername { get { return klass.ValUsername; } set { klass.ValUsername = value; } }
		public bool ShouldSerializeValUsername() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValUsername");

		[DisplayName("Password")]
		/// <summary>Field : "Password" Tipo: "C" Formula:  ""</summary>
		public string ValPassword { get { return klass.ValPassword; } set { klass.ValPassword = value; } }
		public bool ShouldSerializeValPassword() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValPassword");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValDatacria");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOpermuda { get { return klass.ValOpermuda; } set { klass.ValOpermuda = value; } }
		public bool ShouldSerializeValOpermuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValOpermuda");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValDatamuda { get { return klass.ValDatamuda; } set { klass.ValDatamuda = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValDatamuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValDatamuda");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_nes.ValZzstate");

		public S_nes() : this(UserContext.Current.User) { }

		public S_nes(User u)
		{
			this.klass = new CSGenioAs_nes(u);
		}

		public S_nes(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_nes(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public S_nes(bool isEmpty) : this(isEmpty, null) { }

		public S_nes(CSGenioAs_nes val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_nes(CSGenioAs_nes val) : this(val, null) { }

		public S_nes(CSGenioAs_nes val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public S_nes(CSGenioAs_nes val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAs_nes csgenioa)
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
		public static S_nes Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static S_nes Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAs_nes>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new S_nes(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<S_nes> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAs_nes>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<S_nes>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAs_nes> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAs_nes>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAs_nes> All(CriteriaSet args = null)
		{
			return Where<CSGenioAs_nes>(false, args, numRegs: -1);
		}

		public static List<S_nes> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAs_nes>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<S_nes>((r) => new S_nes(r));
		}

// USE /[MANUAL GQT MODEL S_NES]/
	}
}
