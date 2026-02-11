using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Rules;

public class Regra_Up_rulesValDescript_RowViewModel : Models.Up_rules
{
	#region Constructors

	public Regra_Up_rulesValDescript_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public Regra_Up_rulesValDescript_RowViewModel(UserContext userContext, CSGenioAup_rules val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	#endregion

	#region Private methods

	private void InitRowProperties()
	{
		SetColumns();
		SetCustomActions();
	}

	private void SetColumns()
	{
		Columns ??= [
			new ListColumn()
			{
				Order = 1,
				Area = "UP_RULES",
				Field = "DESCRIPT",
			},
		];
	}

	private void SetButtonPermissions()
	{
		if (BtnPermission != null)
			return;

		bool canView = true;
		bool canEdit = true;
		bool canDelete = true;
		bool canDuplicate = true;
		bool canInsert = true;

		using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport))
		{
			// Support Form UP_RULES CRUD conditions.
			// [UP_RULES->DESCRIPT]!="VIEW" || [UP_RULES->LOCAL]!="F" || [UP_RULES->ALLOW_ALL] == 1
			{
				bool formulaResult = (Logical)(((string)this.ValDescript)!="VIEW"||((string)this.ValLocal)!="F"||((Logical)this.ValAllow_all)==1);
				canView &= formulaResult;
				// If View is blocked by CRUD condition, Duplicate should also be blocked.
				canDuplicate &= formulaResult;
			}
			// [UP_RULES->DESCRIPT]!="UPDATE" || [UP_RULES->LOCAL]!="F" || [UP_RULES->ALLOW_ALL] == 1 || HasRole("99")
			canEdit &= (Logical)(((string)this.ValDescript)!="UPDATE"||((string)this.ValLocal)!="F"||((Logical)this.ValAllow_all)==1||CSGenio.business.GlobalFunctions.HasRole(m_userContext.User,"99"));

			// Table UP_RULES CRUD conditions.
			// [UP_RULES->DESCRIPT]!="VIEW" || [UP_RULES->LOCAL]!="T"
			{
				bool formulaResult = (Logical)(((string)this.ValDescript)!="VIEW"||((string)this.ValLocal)!="T");
				canView &= formulaResult;
				// If View is blocked by CRUD condition, Duplicate should also be blocked.
				canDuplicate &= formulaResult;
			}
			// [UP_RULES->DESCRIPT]!="UPDATE" || [UP_RULES->LOCAL]!="T"
			canEdit &= (Logical)(((string)this.ValDescript)!="UPDATE"||((string)this.ValLocal)!="T");
		}

		BtnPermission = new TableRowCrudButtonPermissions()
		{
			ViewBtnDisabled = !canView,
			EditBtnDisabled = !canEdit,
			DeleteBtnDisabled = !canDelete,
			DuplicateBtnDisabled = !canDuplicate,
			InsertBtnDisabled = !canInsert
		};
	}

	private void SetCustomActions()
	{
		CustomActions ??= new()
		{
		};
	}

	#endregion

	/// <summary>
	/// The state of the row (it's an internal value, therefore it shouldn't be sent to the client-side)
	/// </summary>
	[JsonIgnore]
	public override int ValZzstate => base.ValZzstate;

	/// <summary>
	/// Whether the row is in a valid state
	/// </summary>
	[JsonPropertyName("isValid")]
	public bool IsValid => ValZzstate == 0;

	/// <summary>
	/// The list columns
	/// </summary>
	[JsonPropertyName("columns")]
	public List<ListColumn> Columns { get; private set; }

	/// <summary>
	/// The button permissions
	/// </summary>
	[JsonPropertyName("btnPermission")]
	public TableRowCrudButtonPermissions BtnPermission { get; private set; }

	/// <summary>
	/// The custom action buttons
	/// </summary>
	[JsonPropertyName("customActions")]
	public Dictionary<string, ListCustomAction> CustomActions { get; private set; }

	/// <summary>
	/// The foreground color
	/// </summary>
	[JsonPropertyName("foregroundColor")]
	public string ForegroundColor => "";

	/// <summary>
	/// The background color
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	public string BackgroundColor => "";

	/// <summary>
	/// Runs init logic that depends on row data.
	/// </summary>
	public void InitRowData()
	{
		SetButtonPermissions();
	}
}
