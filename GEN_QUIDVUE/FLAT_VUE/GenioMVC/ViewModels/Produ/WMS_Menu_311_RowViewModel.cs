using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Produ;

public class WMS_Menu_311_RowViewModel : Models.Produ
{
	#region Constructors

	public WMS_Menu_311_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public WMS_Menu_311_RowViewModel(UserContext userContext, CSGenioAprodu val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "PRODU",
				Field = "PRODUCT",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "PRODU",
				Field = "SKU",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "PRODU",
				Field = "DESCRIPT",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "PRODU",
				Field = "GTIN",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "PRODU",
				Field = "SIZE",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "PRODU",
				Field = "WEIGHT",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "LOCAT",
				Field = "GLN",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "LCEXT",
				Field = "GLNEXT",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "PRODU",
				Field = "INPUTS",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "PRODU",
				Field = "OUTPUTS",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "PRODU",
				Field = "STOCK",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "PRODU",
				Field = "PRICE",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "PRODU",
				Field = "IN_USE",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "PRODU",
				Field = "IMAGE",
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
