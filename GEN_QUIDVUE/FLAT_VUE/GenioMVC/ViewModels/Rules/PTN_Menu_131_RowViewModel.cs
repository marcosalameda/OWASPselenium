using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Rules;

public class PTN_Menu_131_RowViewModel : Models.Rules
{
	#region Constructors

	public PTN_Menu_131_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public PTN_Menu_131_RowViewModel(UserContext userContext, CSGenioArules val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "RULES",
				Field = "TIPOCOND",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "RULES",
				Field = "DESCRIPT",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "RULES",
				Field = "LOCAL",
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
			// Support Form REGRA CRUD conditions.
			// [RULES->TIPOCOND]!="V" || [RULES->LOCAL]!="F"
			{
				bool formulaResult = (Logical)(((string)this.ValTipocond)!="V"||((string)this.ValLocal)!="F");
				canView &= formulaResult;
				// If View is blocked by CRUD condition, Duplicate should also be blocked.
				canDuplicate &= formulaResult;
			}
			// [RULES->TIPOCOND]!="U" || [RULES->LOCAL]!="F"
			canEdit &= (Logical)(((string)this.ValTipocond)!="U"||((string)this.ValLocal)!="F");
			// [RULES->TIPOCOND]!="D" || [RULES->LOCAL]!="F"
			canDelete &= (Logical)(((string)this.ValTipocond)!="D"||((string)this.ValLocal)!="F");

			// Table RULES CRUD conditions.
			// [RULES->TIPOCOND]!="V"  || [RULES->LOCAL]!="T"
			{
				bool formulaResult = (Logical)(((string)this.ValTipocond)!="V"||((string)this.ValLocal)!="T");
				canView &= formulaResult;
				// If View is blocked by CRUD condition, Duplicate should also be blocked.
				canDuplicate &= formulaResult;
			}
			// [RULES->TIPOCOND]!="I"  || [RULES->LOCAL]!="T"
			{
				bool formulaResult = (Logical)(((string)this.ValTipocond)!="I"||((string)this.ValLocal)!="T");
				canInsert &= formulaResult;
				// If Insert is blocked by CRUD condition, Duplicate should also be blocked.
				canDuplicate &= formulaResult;
			}
			// [RULES->TIPOCOND]!="U"  || [RULES->LOCAL]!="T"
			canEdit &= (Logical)(((string)this.ValTipocond)!="U"||((string)this.ValLocal)!="T");
			// [RULES->TIPOCOND]!="D" || [RULES->LOCAL]!="T"
			canDelete &= (Logical)(((string)this.ValTipocond)!="D"||((string)this.ValLocal)!="T");
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
