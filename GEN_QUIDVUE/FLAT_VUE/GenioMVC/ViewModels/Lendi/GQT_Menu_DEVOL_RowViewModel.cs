using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Lendi;

public class GQT_Menu_DEVOL_RowViewModel : Models.Lendi
{
	#region Constructors

	public GQT_Menu_DEVOL_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public GQT_Menu_DEVOL_RowViewModel(UserContext userContext, CSGenioAlendi val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "PESS1",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "EQUIP",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "EQUIP",
				Field = "REGISTNR",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "EQUIP",
				Field = "FREQUENC",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "PESS2",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "LENDI",
				Field = "LENDINNR",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "LENDI",
				Field = "START",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "LENDI",
				Field = "WARNDT",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "LENDI",
				Field = "END",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "LENDI",
				Field = "OBSERVAT",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "LENDI",
				Field = "RETURNDT",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "LENDI",
				Field = "DAYSLIMI",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "LENDI",
				Field = "RETURNED",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "LENDI",
				Field = "IFOUTDT",
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
