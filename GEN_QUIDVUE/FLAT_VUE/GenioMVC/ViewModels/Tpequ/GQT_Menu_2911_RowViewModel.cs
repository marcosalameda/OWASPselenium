using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Tpequ;

public class GQT_Menu_2911_RowViewModel : Models.Tpequ
{
	#region Constructors

	public GQT_Menu_2911_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public GQT_Menu_2911_RowViewModel(UserContext userContext, CSGenioAtpequ val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "TPEQU",
				Field = "TPEQUCOD",
				TextColorFormula = () => ((CSGenio.framework.GenFunctions.emptyC(((string)this.ValCorletra))==1)?("RGB(0,0,0)"):(((string)this.ValCorletra))),
				BackColorFormula = () => ((CSGenio.framework.GenFunctions.emptyC(((string)this.ValBackcolo))==1)?("RGB(255,255,255)"):(((string)this.ValBackcolo))),
			},
			new ListColumn()
			{
				Order = 2,
				Area = "TPEQU",
				Field = "TIPOEQUI",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "FAMIL",
				Field = "FAMILY",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "TPEQU",
				Field = "TPEQUPAI",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "TPEQU",
				Field = "NIVEL",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "TPEQU",
				Field = "BACKCOLO",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "TPEQU",
				Field = "CORLETRA",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "TPEQU",
				Field = "PRECOMAX",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "TPEQU",
				Field = "PRECOULT",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "TPEQU",
				Field = "SINCE",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "TPEQU",
				Field = "QTDEQUIP",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "TPEQU",
				Field = "KIT",
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
