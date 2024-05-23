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
	public class S_arg : ModelBase
	{
		[JsonIgnore]
		public CSGenioAs_arg klass { get { return baseklass as CSGenioAs_arg; } set { baseklass = value; } }

		private Glob _globTable;
		/// <summary>
		/// [MH] - Referencia ao GLOB to ter acesso aos fields necessarios to formulas server-side (MVC)
		/// </summary>
		[JsonIgnore]
		public virtual Glob TGlob { get { if (_globTable == null) _globTable = Glob.GetGlob(false, this?._fieldsToSerialize); return _globTable; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodargpr { get { return klass.ValCodargpr; } set { klass.ValCodargpr = value; } }
		public bool ShouldSerializeValCodargpr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValCodargpr");

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCods_apr { get { return klass.ValCods_apr; } set { klass.ValCods_apr = value; } }
		public bool ShouldSerializeValCods_apr() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValCods_apr");
		private S_apr _s_apr;
		[DisplayName("S_apr")]
		public virtual S_apr S_apr { get { if (!this.isEmptyModel && (_s_apr == null || (!string.IsNullOrEmpty(ValCods_apr) && (_s_apr.isEmptyModel || _s_apr.klass.QPrimaryKey != ValCods_apr)))) _s_apr = Models.S_apr.Find(ValCods_apr, Identifier, _fieldsToSerialize); if (_s_apr == null) _s_apr = new Models.S_apr(true, _fieldsToSerialize); return _s_apr; } set { _s_apr = value; } }
		public bool ShouldSerializeS_apr () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_apr");

		[DisplayName("Id")]
		/// <summary>Field : "Id" Tipo: "C" Formula:  ""</summary>
		public string ValId { get { return klass.ValId; } set { klass.ValId = value; } }
		public bool ShouldSerializeValId() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValId");

		[DisplayName("Value")]
		/// <summary>Field : "Value" Tipo: "C" Formula:  ""</summary>
		public string ValValor { get { return klass.ValValor; } set { klass.ValValor = value; } }
		public bool ShouldSerializeValValor() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValValor");

		[DisplayName("Document")]
		/// <summary>Field : "Document" Tipo: "IB" Formula:  ""</summary>
		[Document("ValDocument", false, true, false, false)]
		public string ValDocument { get { return klass.ValDocument; } set { klass.ValDocument = value; } }
		public string ValDocumentfk { get { return klass.ValDocumentfk; } set { klass.ValDocumentfk = value; } }
		public bool ShouldSerializeValDocument() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValDocument");

		[DisplayName("Name")]
		/// <summary>Field : "Name" Tipo: "C" Formula:  ""</summary>
		public string ValTipo { get { return klass.ValTipo; } set { klass.ValTipo = value; } }
		public bool ShouldSerializeValTipo() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValTipo");

		[DisplayName("Description")]
		/// <summary>Field : "Description" Tipo: "C" Formula:  ""</summary>
		public string ValDesignac { get { return klass.ValDesignac; } set { klass.ValDesignac = value; } }
		public bool ShouldSerializeValDesignac() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValDesignac");

		[DisplayName("Hidden")]
		/// <summary>Field : "Hidden" Tipo: "L" Formula:  ""</summary>
		public bool ValHidden { get { return Convert.ToBoolean(klass.ValHidden); } set { klass.ValHidden = Convert.ToInt32(value); } }
		public bool ShouldSerializeValHidden() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValHidden");

		[DisplayName("Created by")]
		/// <summary>Field : "Created by" Tipo: "ON" Formula:  ""</summary>
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }
		public bool ShouldSerializeValOpercria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValOpercria");

		[DisplayName("Created on")]
		/// <summary>Field : "Created on" Tipo: "OD" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("OD")]
		public DateTime? ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value ?? DateTime.Now;  } }
		public bool ShouldSerializeValDatacria() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValDatacria");

		[DisplayName("Changed by")]
		/// <summary>Field : "Changed by" Tipo: "EN" Formula:  ""</summary>
		public string ValOpermuda { get { return klass.ValOpermuda; } set { klass.ValOpermuda = value; } }
		public bool ShouldSerializeValOpermuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValOpermuda");

		[DisplayName("Changed on")]
		/// <summary>Field : "Changed on" Tipo: "ED" Formula:  ""</summary>
		[DataType(DataType.Date)]
		[DateAttribute("ED")]
		public DateTime? ValDatamuda { get { return klass.ValDatamuda; } set { klass.ValDatamuda = value ?? DateTime.MinValue;  } }
		public bool ShouldSerializeValDatamuda() => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValDatamuda");

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }
		public bool ShouldSerializeValZzstate () => this.SerializeAllFields || this.FieldsToSerialize.Contains("S_arg.ValZzstate");

		public S_arg() : this(UserContext.Current.User) { }

		public S_arg(User u)
		{
			this.klass = new CSGenioAs_arg(u);
		}

		public S_arg(string[] fieldsToSerialize) : this()
		{
			SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_arg(bool isEmpty, string[] fieldsToSerialize) : this(fieldsToSerialize)
		{
			this.isEmptyModel = isEmpty;
		}

		public S_arg(bool isEmpty) : this(isEmpty, null) { }

		public S_arg(CSGenioAs_arg val, string[] fieldsToSerialize)
		{
			klass = val; SetFieldsToSerialize(fieldsToSerialize);
		}

		public S_arg(CSGenioAs_arg val) : this(val, null) { }

		public S_arg(CSGenioAs_arg val, bool fillAreasRel, string[] fieldsToSerialize)
		{
			klass = val;
			SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public S_arg(CSGenioAs_arg val, bool fillAreasRel) : this(val, fillAreasRel, null) { }

		public void FillRelatedAreas(CSGenioAs_arg csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "s_apr":
						if (_s_apr == null)
							_s_apr = new S_apr(true, _fieldsToSerialize);
						_s_apr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static S_arg Find(string id, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
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
		public static S_arg Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAs_arg>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new S_arg(record, fieldsToSerialize) { Identifier = identifier };
		}

		[Obsolete("This method should never be used because it uses the default pagination but never allow in the parameters to set any other page. " +
			"Might induce error in manual routines expection to return all the records in the database, when in fact they only get 1 page of records.")]
		public static List<S_arg> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where<CSGenioAs_arg>(false, args, null, 0, 0, null, identifier,noLock).RowsForViewModel<S_arg>();
		}

		[Obsolete("Please use the ModelBase<A>.Where method instead")]
		public static ListingMVC<CSGenioAs_arg> Where(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null)
		{
			return ModelBase.Where<CSGenioAs_arg>(distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		[Obsolete("Please use the ModelBase<A>.All method instead")]
		public static ListingMVC<CSGenioAs_arg> All(CriteriaSet args = null)
		{
			return Where<CSGenioAs_arg>(false, args, numRegs: -1);
		}

		public static List<S_arg> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAs_arg>(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<S_arg>((r) => new S_arg(r));
		}

// USE /[MANUAL GQT MODEL S_ARG]/
	}
}
