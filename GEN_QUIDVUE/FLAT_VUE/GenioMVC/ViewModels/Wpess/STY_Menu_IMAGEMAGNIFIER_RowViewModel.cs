using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Wpess;

public class STY_Menu_IMAGEMAGNIFIER_RowViewModel : Models.Wpess
{
	#region Constructors

	public STY_Menu_IMAGEMAGNIFIER_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public STY_Menu_IMAGEMAGNIFIER_RowViewModel(UserContext userContext, CSGenioAwpess val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "WPESS",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "WPESS",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "WPESS",
				Field = "SEX",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "WPESS",
				Field = "NFUNC",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "WPESS",
				Field = "ADRESS",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "WPESS",
				Field = "ZIPCODE",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "WPESS",
				Field = "COUNTRY",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "WPESS",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "WPESS",
				Field = "CELLPHON",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "WPESS",
				Field = "NATURALI",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "WPESS",
				Field = "NACIONAL",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "WPESS",
				Field = "PFOTO",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "WAREH",
				Field = "WAREHDES",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "WPESS",
				Field = "FTIMGTOP",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "WPESS",
				Field = "FTTHUMB",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "WPESS",
				Field = "FTBACKGR",
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
