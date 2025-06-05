using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Models
{
	public class Docums : ModelBase
	{
		[Newtonsoft.Json.JsonIgnore]
		public CSGenioAdocums klass;

		[Key]
		public string ValCoddocums { get { return klass.ValCoddocums; } set { klass.ValCoddocums = value; } }

		public string ValDocumid { get { return klass.ValDocumid; } set { klass.ValDocumid = value; } }

		public byte[] ValDocument { get { return klass.ValDocument; } }

		public string ValDocpath { get { return klass.ValDocpath; } set { klass.ValDocpath = value; } }

		[Display(Name = "DOCUMENTO60418", ResourceType = typeof(Resources.Resources))]
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }

		[Display(Name = "BYTES25864", ResourceType = typeof(Resources.Resources))]
		public string ValTamanho { get { return klass.ValTamanho; } set { klass.ValTamanho = value; } }

		public string ValExtensao { get { return klass.ValExtensao; } set { klass.ValExtensao = value; } }

		[Display(Name = "AUTOR45670", ResourceType = typeof(Resources.Resources))]
		public string ValOpercria { get { return klass.ValOpercria; } set { klass.ValOpercria = value; } }

		[Display(Name = "DATA_DE_CRIACAO16914", ResourceType = typeof(Resources.Resources))]
		[DataType(DataType.DateTime)]
		public DateTime ValDatacria { get { return klass.ValDatacria; } set { klass.ValDatacria = value; } }

		[Display(Name = "VERSAO61228", ResourceType = typeof(Resources.Resources))]
		public string ValVersao { get { return klass.ValVersao; } set { klass.ValVersao = value; } }

		/// <summary>
		/// Just used for the docums versions dbedit
		/// </summary>
		public string Ticket { get; set; }

		#region Class Methods

		public Docums() { }

		public Docums(CSGenioAdocums val)
		{
			klass = val;
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <returns>Model or NULL</returns>
		public static Docums Find(string id)
		{
			if (string.IsNullOrEmpty(id))
				return null;

			CriteriaSet args = CriteriaSet.And();
			args.Equal(CSGenio.business.CSGenioAdocums.FldCoddocums, id);

			List<Docums> results = Where(false, args).RowsForViewModel<Docums>();
			if (results.Count == 0)
				return null;

			return results.First();
		}

		public static Docums GetLatestVersion(string documid)
		{
			if (string.IsNullOrEmpty(documid))
				return null;

			CriteriaSet args = CriteriaSet.And();
			args.Equal(CSGenio.business.CSGenioAdocums.FldDocumid, documid);

			return Where(false, args, null, 0, 0, new List<ColumnSort>()).RowsForViewModel<Docums>().FirstOrDefault();
		}

		public static ListingMVC<CSGenioAdocums> Where(bool distinct, CriteriaSet args = null, FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null)
		{
			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;

			//EPH
			args = Docums.AddEPH<CSGenioAdocums>(ref u, args);

			ColumnSort sortPk = new ColumnSort(new ColumnReference(CSGenioAdocums.FldVersao), SortOrder.Descending);
			if (sorts != null && !sorts.Exists(x => x == sortPk))
				sorts.Add(sortPk);

			ListingMVC<CSGenioAdocums> listing = new ListingMVC<CSGenioAdocums>(fields, sorts, offset, numRegs, distinct, u, false);

			CSGenioAdocums.searchListAdvancedWhere(sp, u, args, listing);

			return listing;
		}

		// TODO: check if this static New() with no references
		// is still necessary
		public static Docums New()
		{
			User u = UserContext.Current.User;

			Docums new_row = new Docums();
			new_row.klass = new CSGenioAdocums(u, u.CurrentModule);

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			sp.openConnection();
			//Aplicação da EPH
			//TODO: verificar se exists um método melhor to aplicar a EPH
			new_row.klass.fillEPH(u, sp, "");
			new_row.klass.insertPseud(sp);
			sp.closeConnection();

			return new_row;
		}

		#endregion
	}
}
