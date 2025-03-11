using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Inpgr;

public class STY_Menu_361_RowViewModel : Models.Inpgr
{
	#region Constructors

	public STY_Menu_361_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public STY_Menu_361_RowViewModel(UserContext userContext, CSGenioAinpgr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "INPGR",
				Field = "NUMBGRO",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "INPGR",
				Field = "TEXTGRO",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "INPGR",
				Field = "BUTTNGRO",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "INPGR",
				Field = "SPANGRO",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "INPGR",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "INPGR",
				Field = "LASTNAME",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "INPGR",
				Field = "ADRESS",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "INPGR",
				Field = "PREFIX",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "INPGR",
				Field = "PHONE",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "INPGR",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "INPGR",
				Field = "WEB",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "INPGR",
				Field = "IBAN",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "INPGR",
				Field = "BANKACCO",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "INPGR",
				Field = "TEXTSPAN",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "INPGR",
				Field = "DIRECTIO",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "INPGR",
				Field = "BANKCOMP",
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
}
