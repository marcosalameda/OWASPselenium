using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Dttyp;

public class WMS_Menu_7111_RowViewModel : Models.Dttyp
{
	#region Constructors

	public WMS_Menu_7111_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public WMS_Menu_7111_RowViewModel(UserContext userContext, CSGenioAdttyp val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "DTTYP",
				Field = "STRING",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "DTTYP",
				Field = "UPPERCAS",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "DTTYP",
				Field = "QRCODE",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "DTTYP",
				Field = "MULTILIN",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "DTTYP",
				Field = "MULTILI3",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "DTTYP",
				Field = "BOOLEAN",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "DTTYP",
				Field = "BOOLEAN2",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "DTTYP",
				Field = "SMALLINT",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "DTTYP",
				Field = "INTEGER",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "DTTYP",
				Field = "BIGINT",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "DTTYP",
				Field = "REAL",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "DTTYP",
				Field = "FLOAT",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "DTTYP",
				Field = "DECIMAL",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "DTTYP",
				Field = "DECIMAL9",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "DTTYP",
				Field = "MONEY",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "DTTYP",
				Field = "MONEY9",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "DTTYP",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "DTTYP",
				Field = "DATETIME",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "DTTYP",
				Field = "DTSESOND",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "DTTYP",
				Field = "TIME",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "DTTYP",
				Field = "UUID",
			},
			new ListColumn()
			{
				Order = 22,
				Area = "DTTYP",
				Field = "IMAGE",
			},
			new ListColumn()
			{
				Order = 23,
				Area = "DTTYP",
				Field = "START",
			},
			new ListColumn()
			{
				Order = 24,
				Area = "DTTYP",
				Field = "END",
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
