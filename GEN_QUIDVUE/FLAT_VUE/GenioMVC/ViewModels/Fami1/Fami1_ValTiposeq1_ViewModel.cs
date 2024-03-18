using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

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
		public List<TreeNode> Tree { get; set; }

		public string ValCodfamil { get; set; }

		void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		public Fami1_ValTiposeq1_ViewModel(UserContext userContext) : base(userContext)
		{
			InitLevels();
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
			List<ColumnSort> sorts = new List<ColumnSort>();


			FieldRef[] fields = new FieldRef[] { CSGenioAtpeq1.FldCodtpequ, CSGenioAtpeq1.FldZzstate, CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldNivel, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldBackcolo, CSGenioAtpeq1.FldCorletra };
			CriteriaSet subfilters = CriteriaSet.And();


			string currentBranch = requestValues["currentBranch"] ?? "0"; // Branch Id
			string currentSelectedKey = requestValues["currentSelectedKey"] ?? null; // Selected Key
// USE /[MANUAL GQT OVERRQ FAMI1_VALTIPOSEQ1]/
			switch (currentBranch)
			{
				case "0":
				{
					CriteriaSet fami1___pseudtiposeq1Conds = CriteriaSet.And();
					{
						bool tableReload = true;
						// Limits Generation

						// Area limit
						tableReload &= AddCriteriaAreaLimit(fami1___pseudtiposeq1Conds, CSGenio.business.CSGenioAfami1.FldCodfamil, "fami1", this.ValCodfamil, true);

						if (!tableReload)
							return;
						fami1___pseudtiposeq1Conds.SubSets.Add(subfilters);
					}

					var branch = new TreeBranchInfo<CSGenioAtpeq1>()
					{
						BranchLevel = 0, Area = "TPEQ1", Form = "TPEQ1", IsTree = true, IsTreeTable = true,
						KeySelector = CSGenioAtpeq1.FldCodtpequ,
						Selector = CSGenioAtpeq1.FldTpequcod,
						ParentSelector = CSGenioAtpeq1.FldTpequpai,
						Limit = (parentKey) => CriteriaSet.And().Equal(CSGenioAtpeq1.FldZzstate, 0),
						SelectFields = new FieldRef[] { CSGenioAtpeq1.FldTpequcod, CSGenioAtpeq1.FldNivel, CSGenioAtpeq1.FldTipoequi, CSGenioAtpeq1.FldTpequpai, CSGenioAtpeq1.FldCodtpequ }
					};
					Tree.AddRange(branch.BuildBranch(m_userContext, fami1___pseudtiposeq1Conds, currentSelectedKey, "IBL_FAMI1___PSEUDTIPOSEQ1"));
					break;
				}
			}
		}

		private readonly string[] _fieldsToSerialize_FAMI1___PSEUDTIPOSEQ1 = { "Tpeq1", "Tpeq1.ValCodtpequ", "Tpeq1.ValZzstate", "Tpeq1.ValTpequcod", "Tpeq1.ValNivel", "Tpeq1.ValTipoequi", "Tpeq1.ValTpequpai", "Tpeq1.ValBackcolo", "Tpeq1.ValCorletra" };

		#region Custom code
// USE /[MANUAL GQT VIEWMODEL_CUSTOM FAMI1_VALTIPOSEQ1]/
		#endregion
	}
}
