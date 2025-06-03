using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Sale;

public class GQT_Menu_531_RowViewModel : Models.Sale
{
	#region Constructors

	public GQT_Menu_531_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public GQT_Menu_531_RowViewModel(UserContext userContext, CSGenioAsale val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "ORGAN",
				Field = "ORGANIZA",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "SALE",
				Field = "NRLIDE",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "SALE",
				Field = "STARTDT",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "SALE",
				Field = "IDENTIFI",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "SALE",
				Field = "POTCOMPR",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "SALE",
				Field = "PROSPECC",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "SALE",
				Field = "INTERESS",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "SALE",
				Field = "SEMRFINA",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "SALE",
				Field = "SEMCAPAC",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "SALE",
				Field = "DTQUALIF",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "SALE",
				Field = "QUALIFIC",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "SALE",
				Field = "PREABORD",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "SALE",
				Field = "HOMEWORK",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "SALE",
				Field = "DTABORDA",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "SALE",
				Field = "APPROACH",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "SALE",
				Field = "APRESENT",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "SALE",
				Field = "DTAPRESE",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "SALE",
				Field = "DTSUPERA",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "SALE",
				Field = "TENTFECH",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "SALE",
				Field = "DTVENDA",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "SALE",
				Field = "DTACOMPA",
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
