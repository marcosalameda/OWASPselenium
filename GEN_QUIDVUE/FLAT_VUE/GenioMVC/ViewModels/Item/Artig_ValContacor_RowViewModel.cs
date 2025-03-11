using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Item;

public class Artig_ValContacor_RowViewModel : Models.Ccorr
{
	#region Constructors

	public Artig_ValContacor_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public Artig_ValContacor_RowViewModel(UserContext userContext, CSGenioAccorr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "CCORR",
				Field = "NORDER",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "CCORR",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "CCORR",
				Field = "TYPE",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "CCORR",
				Field = "REFERENC",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "CCORR",
				Field = "QNTY",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "CCORR",
				Field = "BALANCE",
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
	/// Formula: iif([CCORR->TYPE]=="Entrada",RGB(207,255,158),iif([CCORR->TYPE]=="Saída",RGB(255,190,158),RGB(255,255,255)))
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	public string BackgroundColor => ((((string)this.ValType)=="Entrada")?("RGB(207,255,158)"):(((((string)this.ValType)=="Saída")?("RGB(255,190,158)"):("RGB(255,255,255)"))));
}
