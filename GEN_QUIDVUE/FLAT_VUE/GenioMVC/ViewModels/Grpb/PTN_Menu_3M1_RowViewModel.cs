using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Grpb;

public class PTN_Menu_3M1_RowViewModel : Models.Grpb
{
	#region Constructors

	public PTN_Menu_3M1_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public PTN_Menu_3M1_RowViewModel(UserContext userContext, CSGenioAgrpb val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "GRPB",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "TBLB",
				Field = "BOOL",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "TBLB",
				Field = "CURDEC",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "TBLB",
				Field = "CURINT",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "TBLB",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "TBLB",
				Field = "DATETM",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "TBLB",
				Field = "DATETS",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "TBLB",
				Field = "ENUMN",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "TBLB",
				Field = "ENUMT",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "TBLB",
				Field = "NUMDEC",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "TBLB",
				Field = "NUMINT",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "TBLB",
				Field = "TEXT",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "TBLB",
				Field = "TEXTML",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "TBLB",
				Field = "TIMEHM",
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

	#region Columns from table below

	[ShouldSerialize("Tblb.ValBool")]
	public List<bool> TblbValBool { get; set; } = [];

	[ShouldSerialize("Tblb.ValCurdec")]
	public List<decimal?> TblbValCurdec { get; set; } = [];

	[ShouldSerialize("Tblb.ValCurint")]
	public List<decimal?> TblbValCurint { get; set; } = [];

	[ShouldSerialize("Tblb.ValDate")]
	public List<DateTime?> TblbValDate { get; set; } = [];

	[ShouldSerialize("Tblb.ValDatetm")]
	public List<DateTime?> TblbValDatetm { get; set; } = [];

	[ShouldSerialize("Tblb.ValDatets")]
	public List<DateTime?> TblbValDatets { get; set; } = [];

	[ShouldSerialize("Tblb.ValEnumn")]
	public List<decimal> TblbValEnumn { get; set; } = [];

	[ShouldSerialize("Tblb.ValEnumt")]
	public List<string> TblbValEnumt { get; set; } = [];

	[ShouldSerialize("Tblb.ValNumdec")]
	public List<decimal?> TblbValNumdec { get; set; } = [];

	[ShouldSerialize("Tblb.ValNumint")]
	public List<decimal?> TblbValNumint { get; set; } = [];

	[ShouldSerialize("Tblb.ValText")]
	public List<string> TblbValText { get; set; } = [];

	[ShouldSerialize("Tblb.ValTextml")]
	public List<string> TblbValTextml { get; set; } = [];

	[ShouldSerialize("Tblb.ValTimehm")]
	public List<string> TblbValTimehm { get; set; } = [];

	#endregion

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
