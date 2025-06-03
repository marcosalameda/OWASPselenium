using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Entit;

public class WMS_Menu_511_RowViewModel : Models.Entit
{
	#region Constructors

	public WMS_Menu_511_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public WMS_Menu_511_RowViewModel(UserContext userContext, CSGenioAentit val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "ENTIT",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "ENTIT",
				Field = "INITIALS",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "ENTIT",
				Field = "REGISTRA",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "ENTIT",
				Field = "TAXNUMBE",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "ENTIT",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "ENTIT",
				Field = "PHONENUM",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "ENTIT",
				Field = "WEBSITE",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "ENTIT",
				Field = "PERSON",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "ENTIT",
				Field = "IBAN",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "ENTIT",
				Field = "BUILDING",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "ENTIT",
				Field = "STREET",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "ENTIT",
				Field = "TOWN",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "ENTIT",
				Field = "COUNTY",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "ENTIT",
				Field = "STATE",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "ENTIT",
				Field = "POBOX",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "ENTIT",
				Field = "POSTALCO",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "ENTIT",
				Field = "TELEPHON",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "ENTIT",
				Field = "FAX",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "ENTIT",
				Field = "CONTACT",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "ENTIT",
				Field = "MANUFACT",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "ENTIT",
				Field = "FOUNDED",
			},
			new ListColumn()
			{
				Order = 22,
				Area = "FACI1",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 23,
				Area = "FACI2",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 24,
				Area = "ENTIT",
				Field = "LANGUAGE",
			},
			new ListColumn()
			{
				Order = 25,
				Area = "ENTIT",
				Field = "CURRENCY",
			},
			new ListColumn()
			{
				Order = 26,
				Area = "ENTIT",
				Field = "OWNER",
			},
			new ListColumn()
			{
				Order = 27,
				Area = "ENTIT",
				Field = "CARRIER",
			},
			new ListColumn()
			{
				Order = 28,
				Area = "ENTIT",
				Field = "SUPPLIER",
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
