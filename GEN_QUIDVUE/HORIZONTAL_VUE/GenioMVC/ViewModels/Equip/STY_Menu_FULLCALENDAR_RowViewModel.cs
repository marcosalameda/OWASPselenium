using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Equip;

public class STY_Menu_FULLCALENDAR_RowViewModel : Models.Equip
{
	#region Constructors

	public STY_Menu_FULLCALENDAR_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public STY_Menu_FULLCALENDAR_RowViewModel(UserContext userContext, CSGenioAequip val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "CMPNY",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "PESS1",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "EQUIP",
				Field = "SEQUENNR",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "EQUIP",
				Field = "REGISTNR",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "TPEQU",
				Field = "TIPOEQUI",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "WAREH",
				Field = "WAREHDES",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "ITEM",
				Field = "ITEMDES",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "EQUIP",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "EQUIP",
				Field = "DTAQUISI",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "DECOM",
				Field = "DECOMNR",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "EQUIP",
				Field = "DTDECO",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "EQUIP",
				Field = "IFABATIF",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "EQUIP",
				Field = "PHOTOGRA",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "EQUIP",
				Field = "VALORTOT",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "EQUIP",
				Field = "FREQUENC",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "EQUIP",
				Field = "BOUGHT",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "ROOM1",
				Field = "ROOMNR",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "EQUIP",
				Field = "DTREFERE",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "EQUIP",
				Field = "FIRST",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "EQUIP",
				Field = "BEFORE",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "EQUIP",
				Field = "FOLLOWIN",
			},
			new ListColumn()
			{
				Order = 22,
				Area = "EQUIP",
				Field = "LAST",
			},
			new ListColumn()
			{
				Order = 23,
				Area = "EQUIP",
				Field = "SITEFABR",
			},
			new ListColumn()
			{
				Order = 24,
				Area = "EQUIP",
				Field = "LASTPHO",
			},
			new ListColumn()
			{
				Order = 25,
				Area = "EQUIP",
				Field = "MOVIMENT",
			},
			new ListColumn()
			{
				Order = 26,
				Area = "EQUIP",
				Field = "QTDMOVIM",
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
