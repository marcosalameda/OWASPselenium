using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Equip;

public class STY_Menu_ACCORD_RowViewModel : Models.Equip
{
	#region Constructors

	public STY_Menu_ACCORD_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public STY_Menu_ACCORD_RowViewModel(UserContext userContext, CSGenioAequip val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	#endregion

	#region Private methods

	private void InitRowData()
	{
		SetColumns();
		SetButtonPermissions();
		SetCustomActions();
	}

	private void SetColumns()
	{
		Columns ??= [
			new ListColumn()
			{
				Order = 1,
				Area = "CMPNY",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "EQUIP",
				Field = "SEQUENNR",
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
				Area = "TPEQU",
				Field = "TIPOEQUI",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "EQUIP",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "EQUIP",
				Field = "DTAQUISI",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "EQUIP",
				Field = "DTDECO",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "EQUIP",
				Field = "SITEFABR",
			},
		];
	}

	private void SetButtonPermissions()
	{
		if (BtnPermission != null)
			return;

		bool canView = true;
		bool canEdit = false;
		bool canDelete = false;
		bool canDuplicate = false;
		bool canInsert = false;

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
}
