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
	public class Lstcol : ModelBase
	{
		[Newtonsoft.Json.JsonIgnore]
		public CSGenioAlstcol klass { get { return baseklass as CSGenioAlstcol; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodlstcol { get { return klass.ValCodlstcol; } set { klass.ValCodlstcol = value; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValCodlstusr { get { return klass.ValCodlstusr; } set { klass.ValCodlstusr = value; } }

		[DisplayName("Tabela")]
		/// <summary>Field : "Tabela" Tipo: "C" Formula:  ""</summary>
		public string ValTabela { get { return klass.ValTabela; } set { klass.ValTabela = value; } }

		[DisplayName("Alias")]
		/// <summary>Field : "Alias" Tipo: "C" Formula:  ""</summary>
		public string ValAlias { get { return klass.ValAlias; } set { klass.ValAlias = value; } }

		[DisplayName("Campo")]
		/// <summary>Field : "Campo" Tipo: "C" Formula:  ""</summary>
		public string ValCampo { get { return klass.ValCampo; } set { klass.ValCampo = value; } }

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

		public Lstcol() : this(UserContext.Current.User) { }

		public Lstcol(User u)
		{
			this.klass = new CSGenioAlstcol(u);
		}

		public Lstcol(bool isEmpty) : this()
		{
			this.isEmptyModel = isEmpty;
		}

		public Lstcol(CSGenioAlstcol val)
		{
			klass = val;
		}

		public Lstcol(CSGenioAlstcol val, bool fillAreasRel)
		{
			klass = val;
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="identifier">The identifier.</param>
		/// <returns>Model or NULL</returns>
		public static Lstcol Find(string id, string identifier = null)
		{
			if (String.IsNullOrEmpty(id))
				return null;

			CriteriaSet args = CriteriaSet.And();
			args.Equal(CSGenio.business.CSGenioAlstcol.FldCodlstcol, id);

			User u = UserContext.Current.User;
			args = Lstcol.AddEPH<CSGenioAlstcol>(ref u, args, identifier);

			var pos = CSGenioAlstcol.searchList(UserContext.Current.PersistentSupport, u, args, null, false, true);
			if (pos.Count == 0)
				return null;

			var res = new Lstcol(pos[0]);
			res.Identifier = identifier;

			return res;
		}

		public static List<Lstcol> Where(CriteriaSet args = null, string identifier = null, bool noLock = true)
		{
			return Where(false, args, null, 0, 0, null, identifier, noLock).RowsForViewModel<Lstcol>();
		}

		public static ListingMVC<CSGenioAlstcol> Where(bool distinct, CriteriaSet args = null, FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true)
		{
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;

			//EPH
			args = Lstcol.AddEPH<CSGenioAlstcol>(ref u, args, identifier);

			ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioAlstcol.FldCodlstcol), SortOrder.Ascending);
			if (sorts != null && !sorts.Exists(x => x == sortPk))
				sorts.Add(sortPk);

			ListingMVC<CSGenioAlstcol> listing = new ListingMVC<CSGenioAlstcol>(fields, sorts, offset, numRegs, distinct, u, noLock, identifier);

			CSGenioAlstcol.searchListAdvancedWhere(sp, u, args, listing);

			return listing;
		}

		public static ListingMVC<CSGenioAlstcol> All(CriteriaSet args = null)
		{
			return Where(false, args, numRegs: -1);
		}

		public static List<Lstcol> AllModel(CriteriaSet args = null, string identifier = null)
		{
			return Where(false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Lstcol>();
		}

		#endregion
	}
}
