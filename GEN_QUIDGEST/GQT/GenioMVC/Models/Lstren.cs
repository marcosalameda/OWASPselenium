using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Models
{
	public class Lstren : ModelBase
	{
		[Newtonsoft.Json.JsonIgnore]
		public CSGenioAlstren klass { get { return baseklass as CSGenioAlstren; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlstren { get { return klass.ValCodlstren; } set { klass.ValCodlstren = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlstusr { get { return klass.ValCodlstusr; } set { klass.ValCodlstusr = value; } }

		[DisplayName("Renderização")]
		/// <summary>Field : "Renderização" Tipo: "C" Formula:  ""</summary>
		public string ValRenderizacao { get { return klass.ValRenderizacao; } set { klass.ValRenderizacao = value; } }

		[DisplayName("Visível")]
		/// <summary>Field : "Visível" Tipo: "L" Formula:  ""</summary>
		public bool ValVisivel { get { return Convert.ToBoolean(klass.ValVisivel); } set { klass.ValVisivel = Convert.ToInt32(value); } }

		[DisplayName("Posição")]
		/// <summary>Field : "Posição" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValPosicao { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValPosicao, 0)); } set { klass.ValPosicao = Convert.ToDecimal(value); } }

		[DisplayName("Operação")]
		/// <summary>Field : "Operação" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValOperacao { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValOperacao, 0)); } set { klass.ValOperacao = Convert.ToDecimal(value); } }

		[DisplayName("Tipo")]
		/// <summary>Field : "Tipo" Tipo: "N" Formula:  ""</summary>
		[NumericAttribute(0)]
		public decimal? ValTipo { get { return Convert.ToDecimal(GlobalFunctions.RoundQG(klass.ValTipo, 0)); } set { klass.ValTipo = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		#region Class Methods

		public Lstren() : this(UserContext.Current.User) { }

		public Lstren(User u)
		{
			this.klass = new CSGenioAlstren(u);
		}

		public Lstren(bool isEmpty) : this()
		{
			this.isEmptyModel = isEmpty;
		}

		public Lstren(CSGenioAlstren val)
		{
			klass = val;
		}

		public Lstren(CSGenioAlstren val, bool fillAreasRel)
		{
			klass = val;
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="identifier">The identifier.</param>
		/// <returns>Model or NULL</returns>
		public static Lstren Find(string id, string identifier = null)
		{
			if (String.IsNullOrEmpty(id))
				return null;

			CriteriaSet args = CriteriaSet.And();
			args.Equal(CSGenio.business.CSGenioAlstren.FldCodlstren, id);

			User u = UserContext.Current.User;
			args = Lstren.AddEPH<CSGenioAlstren>(ref u, args, identifier);

			var pos = CSGenioAlstren.searchList(UserContext.Current.PersistentSupport, u, args, null, false, true);
			if (pos.Count == 0)
				return null;

			var res = new Lstren(pos[0]);
			res.Identifier = identifier;

			return res;
		}

		public static List<Lstren> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where(false, args, null, 0, 0, null, identifier, noLock).RowsForViewModel<Lstren>();
		}

		public static ListingMVC<CSGenioAlstren> Where(bool distinct, CriteriaSet args = null, FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true)
		{
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;

			//EPH
			args = Lstren.AddEPH<CSGenioAlstren>(ref u, args, identifier);

			ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioAlstren.FldCodlstren), SortOrder.Ascending);
			if (sorts != null && !sorts.Exists(x => x == sortPk))
				sorts.Add(sortPk);

			ListingMVC<CSGenioAlstren> listing = new ListingMVC<CSGenioAlstren>(fields, sorts, offset, numRegs, distinct, u, noLock, identifier);

			CSGenioAlstren.searchListAdvancedWhere(sp, u, args, listing);

			return listing;
		}

		public static ListingMVC<CSGenioAlstren> All(CriteriaSet args = null)
		{
			return Where(false, args, numRegs: -1);
		}

		public static List<Lstren> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lstren>();
		}

		#endregion
	}
}
