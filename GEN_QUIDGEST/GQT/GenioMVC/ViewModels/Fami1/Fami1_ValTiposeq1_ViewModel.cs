using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Fami1
{
	public class Fami1_ValTiposeq1_ViewModel : ViewModelBase
	{
		public List<TreeNode> Tree;

		public string ValCodfamil { get; set; }

		void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public Fami1_ValTiposeq1_ViewModel(NavigationContext current_navigation)
		{
			InitLevels();
			this.Navigation = current_navigation;
		}

		public void Load()
		{
			Load(new NameValueCollection());
		}

		public void Load(NameValueCollection requestValues)
		{
			CriteriaSet conditions = null;
			Load(requestValues, ref conditions);
		}

		public void Load(NameValueCollection requestValues, ref CriteriaSet conditions)
		{
            Tree = new List<TreeNode>();
            CriteriaSet fami1___pseudtiposeq1Conds = CriteriaSet.And();

            bool tableReload = true;
			// Limits Generation

			// Area limit
			tableReload &= AddCriteriaAreaLimit(fami1___pseudtiposeq1Conds, CSGenio.business.CSGenioAfami1.FldCodfamil, "fami1", this.ValCodfamil, true);

			if(!tableReload) return;
            List<ColumnSort> sorts = new List<ColumnSort>();


            FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldNivel, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldBackcolo, CSGenioAtpeq1.FldCorletra };

            fami1___pseudtiposeq1Conds.Equal(CSGenioAtpeq1.FldZzstate, 0);

            CriteriaSet subfilters = CriteriaSet.And();
 
			fami1___pseudtiposeq1Conds.SubSets.Add(subfilters);


            TreeViewControl<Models.Tpeq1> tree = new TreeViewControl<Models.Tpeq1>();

// USE /[MANUAL GQT OVERRQ FAMI1_VALTIPOSEQ1]/
			tree.AddBranch(new TreeBranchInfo<Models.Tpeq1>() {
				Area = "TPEQ1", Form = "TPEQ1",
				KeySelector = x => x.klass.QPrimaryKey,
				IsTree = true,
				Selector = new Func<Models.Tpeq1, string>(x => x.ValTpequcod),
				ParentSelector = new Func<Models.Tpeq1, string>(x => x.ValTpequpai),
				LevelSelector = new Func<Models.Tpeq1, decimal>(x => x.ValNivel),
				TextSelector = new Func<Models.Tpeq1, string>(x => string.Format("{0} {1} {2} {3}", x.ValTpequcod, x.ValNivel, x.ValTipoequi, x.ValTpequpai))
			});

            ListingMVC<CSGenioAtpeq1> listing = Models.ModelBase.Where<CSGenioAtpeq1>(false, fami1___pseudtiposeq1Conds, fields, 0, -1, sorts, "IBL_FAMI1___PSEUDTIPOSEQ1");

            var rowsAsModels = listing.RowsForViewModel<Models.Tpeq1>((r) => new Models.Tpeq1(r, true, _fieldsToSerialize_FAMI1___PSEUDTIPOSEQ1).SetIsEmptyModel<Models.Tpeq1>(true));
            Tree.AddRange(tree.BuildTree(rowsAsModels, !sorts.Any()));
		}

		private readonly string[] _fieldsToSerialize_FAMI1___PSEUDTIPOSEQ1 = { "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTpequcod", "Tpeq1.ValNivel", "Tpeq1.ValTipoequi", "Tpeq1.ValTpequpai", "Tpeq1.ValBackcolo", "Tpeq1.ValCorletra" };

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FAMI1_VALTIPOSEQ1]/
		#endregion
	}
}
