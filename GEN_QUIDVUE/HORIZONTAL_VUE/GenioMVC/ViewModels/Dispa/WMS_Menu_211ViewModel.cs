using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Dispa;

using Area = CSGenio.business.Area;

public class WMS_Menu_211_ViewModel : KanbanBaseViewModel<CSGenioAdisst, CSGenioAdispa, WMS_Menu_211ColumnViewModel, WMS_Menu_211CardViewModel>
{
	public WMS_Menu_211_ViewModel(UserContext m_userContext) : base(m_userContext)
	{
		RoleToShow = CSGenio.framework.Role.AUTHORIZED;
		RoleToEdit = CSGenio.framework.Role.AUTHORIZED; // TODO: Change to Edit
	}

	[JsonIgnore]
	public new string Identifier { get => "ML211"; }

	[JsonIgnore]
	public override FieldRef[] ColumnFields
	{
		get => [
			CSGenioAdisst.FldCoddisst, CSGenioAdisst.FldOrder, CSGenioAdisst.FldStatus, CSGenioAdisst.FldDescript, CSGenioAdisst.FldZzstate
		];
	}

	[JsonIgnore]
	public override FieldRef[] CardFields
	{
		get => [
			CSGenioAdispa.FldCoddispa, CSGenioAdispa.FldCoddisst, CSGenioAdisst.FldCoddisst, CSGenioAdispa.FldDispanr, CSGenioAdispa.FldDispadt, CSGenioAperso.FldName, CSGenioAdispa.FldCodperso, CSGenioAperso.FldCodperso, CSGenioAdisst.FldStatus, CSGenioAentit.FldName, CSGenioAdispa.FldCodentit, CSGenioAentit.FldCodentit, CSGenioAdispa.FldZzstate
		];
	}

	protected override AreaRef CardsArea => Area.AreaDISPA;
	protected override FieldRef CardGroupIdField => CSGenioAdispa.FldCoddisst;
	protected override FieldRef ColumnOrderField => CSGenioAdisst.FldOrder;
	protected override FieldRef CardOrderField => CSGenioAdispa.FldDispanr;

	public override CriteriaSet GetColumnLimits(NavigationContext navigation = null)
	{
		var args = CriteriaSet.And();
		args = extendWithZzstateCondition(args, CSGenioAdisst.FldZzstate, null);
		return args;
	}

	public override CriteriaSet GetCardLimits(NavigationContext navigation = null)
	{
		var args = CriteriaSet.And();
		args = extendWithZzstateCondition(args, CSGenioAdisst.FldZzstate, null);
		args = extendWithZzstateCondition(args, CSGenioAdispa.FldZzstate, null);
		return args;
	}

	protected override CSGenioAdispa GetCardRecord(PersistentSupport sp, string id, User user) => CSGenioAdispa.search(sp, id, user);
}

public class WMS_Menu_211ColumnViewModel(CSGenioAdisst row) : KanbanRowBaseViewModel<CSGenioAdisst>(row)
{
	public WMS_Menu_211ColumnViewModel() : this(null) { }

	public string DisstValCoddisst { get; set; }
	public decimal? DisstValOrder { get; set; }
	public string DisstValStatus { get; set; }
	public string DisstValDescript { get; set; }

	public override void MapFromModel(CSGenioAdisst row)
	{
		DisstValCoddisst = ViewModelConversion.ToString(row.returnValueField(CSGenioAdisst.FldCoddisst));
		DisstValOrder = ViewModelConversion.ToNumeric(row.returnValueField(CSGenioAdisst.FldOrder));
		DisstValStatus = ViewModelConversion.ToString(row.returnValueField(CSGenioAdisst.FldStatus));
		DisstValDescript = ViewModelConversion.ToString(row.returnValueField(CSGenioAdisst.FldDescript));
	}
}

public class WMS_Menu_211CardViewModel(CSGenioAdispa row) : KanbanRowBaseViewModel<CSGenioAdispa>(row)
{
	public WMS_Menu_211CardViewModel() : this(null) { }

	public string DispaValCoddispa { get; set; }
	public string DispaValCoddisst { get; set; }
	public string DisstValCoddisst { get; set; }
	public decimal? DispaValDispanr { get; set; }
	public DateTime? DispaValDispadt { get; set; }
	public string PersoValName { get; set; }
	public string DispaValCodperso { get; set; }
	public string PersoValCodperso { get; set; }
	public string DisstValStatus { get; set; }
	public string EntitValName { get; set; }
	public string DispaValCodentit { get; set; }
	public string EntitValCodentit { get; set; }

	public override void MapFromModel(CSGenioAdispa row)
	{
		DispaValCoddispa = ViewModelConversion.ToString(row.returnValueField(CSGenioAdispa.FldCoddispa));
		DispaValCoddisst = ViewModelConversion.ToString(row.returnValueField(CSGenioAdispa.FldCoddisst));
		DisstValCoddisst = ViewModelConversion.ToString(row.returnValueField(CSGenioAdisst.FldCoddisst));
		DispaValDispanr = ViewModelConversion.ToNumeric(row.returnValueField(CSGenioAdispa.FldDispanr));
		DispaValDispadt = ViewModelConversion.ToDateTime(row.returnValueField(CSGenioAdispa.FldDispadt));
		PersoValName = ViewModelConversion.ToString(row.returnValueField(CSGenioAperso.FldName));
		DispaValCodperso = ViewModelConversion.ToString(row.returnValueField(CSGenioAdispa.FldCodperso));
		PersoValCodperso = ViewModelConversion.ToString(row.returnValueField(CSGenioAperso.FldCodperso));
		DisstValStatus = ViewModelConversion.ToString(row.returnValueField(CSGenioAdisst.FldStatus));
		EntitValName = ViewModelConversion.ToString(row.returnValueField(CSGenioAentit.FldName));
		DispaValCodentit = ViewModelConversion.ToString(row.returnValueField(CSGenioAdispa.FldCodentit));
		EntitValCodentit = ViewModelConversion.ToString(row.returnValueField(CSGenioAentit.FldCodentit));
	}
}
