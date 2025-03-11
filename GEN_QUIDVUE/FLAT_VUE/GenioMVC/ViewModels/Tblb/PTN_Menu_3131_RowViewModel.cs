using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Tblb;

public class PTN_Menu_3131_RowViewModel : Models.Tblb
{
	#region Constructors

	public PTN_Menu_3131_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public PTN_Menu_3131_RowViewModel(UserContext userContext, CSGenioAtblb val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "TBLB",
				Field = "TEXT",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "TBLB",
				Field = "TEXTML",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "TBLB",
				Field = "NUMINT",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "TBLB",
				Field = "NUMDEC",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "TBLB",
				Field = "CURINT",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "TBLB",
				Field = "CURDEC",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "TBLB",
				Field = "BOOL",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "TBLB",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "TBLB",
				Field = "DATETM",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "TBLB",
				Field = "DATETS",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "TBLB",
				Field = "TIMEHM",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "TBLB",
				Field = "ENUMT",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "TBLB",
				Field = "ENUMN",
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
