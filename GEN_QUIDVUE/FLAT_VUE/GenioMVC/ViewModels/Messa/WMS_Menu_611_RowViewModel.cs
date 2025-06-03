using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Messa;

public class WMS_Menu_611_RowViewModel : Models.Messa
{
	#region Constructors

	public WMS_Menu_611_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public WMS_Menu_611_RowViewModel(UserContext userContext, CSGenioAmessa val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "MESSA",
				Field = "IDNOTIF",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "MESSA",
				Field = "IDMSG",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "MESSA",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "MESSA",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "MESSA",
				Field = "MESSAGE",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "MESSA",
				Field = "MAILSENT",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "MESSA",
				Field = "MAILERR",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "MESSA",
				Field = "CREATOPE",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "MESSA",
				Field = "CREATDAT",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "ENTIT",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "PERSO",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "MESSA",
				Field = "DOCUM_NR",
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
