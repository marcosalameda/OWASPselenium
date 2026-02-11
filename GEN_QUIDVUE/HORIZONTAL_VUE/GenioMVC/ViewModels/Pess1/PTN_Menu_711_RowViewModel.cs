using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Pess1;

public class PTN_Menu_711_RowViewModel : Models.Pess1
{
	#region Constructors

	public PTN_Menu_711_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public PTN_Menu_711_RowViewModel(UserContext userContext, CSGenioApess1 val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "PESS1",
				Field = "MAPHEIGH",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "PESS1",
				Field = "GENDER",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "PESS1",
				Field = "CURRICUL",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "PESS1",
				Field = "TELEPHON",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "PESS1",
				Field = "LINECLR",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "PESS1",
				Field = "CANROT",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "PESS1",
				Field = "DRAWMRK",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "PESS1",
				Field = "CANEXPOR",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "PESS1",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "PESS1",
				Field = "CANREMOV",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "PESS1",
				Field = "DTULTCAT",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "PESS1",
				Field = "OUTWEIGH",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "PESS1",
				Field = "DTNASCIM",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "PESS1",
				Field = "PHOTOGRA",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "PESS1",
				Field = "TERRAIN",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "PESS1",
				Field = "ALLOWLIN",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "PESS1",
				Field = "EMAIL2",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "PESS1",
				Field = "EXTQUERY",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "PESS1",
				Field = "CANDRAG",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "CATE2",
				Field = "CATEGORIA",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "STAKE",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 22,
				Area = "CMPNY",
				Field = "DESIGNAT",
			},
			new ListColumn()
			{
				Order = 23,
				Area = "PESS1",
				Field = "IDADE",
			},
			new ListColumn()
			{
				Order = 24,
				Area = "PESS1",
				Field = "CANEDIT",
			},
			new ListColumn()
			{
				Order = 25,
				Area = "PESS1",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 26,
				Area = "PESS1",
				Field = "GROUPMRK",
			},
			new ListColumn()
			{
				Order = 27,
				Area = "PESS1",
				Field = "ALLOWPOL",
			},
			new ListColumn()
			{
				Order = 28,
				Area = "PESS1",
				Field = "ZOOMLVL",
			},
			new ListColumn()
			{
				Order = 29,
				Area = "PESS1",
				Field = "EXTERNA",
			},
			new ListColumn()
			{
				Order = 30,
				Area = "PESS1",
				Field = "EXTMINZM",
			},
			new ListColumn()
			{
				Order = 31,
				Area = "PESS1",
				Field = "INTERNA",
			},
			new ListColumn()
			{
				Order = 32,
				Area = "PESS1",
				Field = "CANCUT",
			},
			new ListColumn()
			{
				Order = 33,
				Area = "PESS1",
				Field = "IDFUNCIO",
			},
			new ListColumn()
			{
				Order = 34,
				Area = "PESS1",
				Field = "POLYCLR",
			},
			new ListColumn()
			{
				Order = 35,
				Area = "PESS1",
				Field = "NOTIFIND",
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

			// Table PESS1 CRUD conditions.
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
