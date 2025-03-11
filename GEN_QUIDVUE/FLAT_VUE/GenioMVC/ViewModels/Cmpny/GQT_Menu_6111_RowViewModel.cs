using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Cmpny;

public class GQT_Menu_6111_RowViewModel : Models.Cmpny
{
	#region Constructors

	public GQT_Menu_6111_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public GQT_Menu_6111_RowViewModel(UserContext userContext, CSGenioAcmpny val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "CMPNY",
				Field = "ACRONYM",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "CMPNY",
				Field = "NIF",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "CMPNY",
				Field = "TELEPHON",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "CMPNY",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "CMPNY",
				Field = "LOGO",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "CNTRY",
				Field = "COUNTRY",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "CMPNY",
				Field = "QTDPESSO",
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
			{
				"GQT_61111",
				new ListCustomAction()
				{
					Id = "GQT_61111",
				}
			},
			{
				"GQT_61112",
				new ListCustomAction()
				{
					Id = "GQT_61112",
				}
			},
			{
				"GQT_61113",
				new ListCustomAction()
				{
					Id = "GQT_61113",
				}
			},
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
