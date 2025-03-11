using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Flds;

public class STY_Menu_358211_RowViewModel : Models.Flds
{
	#region Constructors

	public STY_Menu_358211_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public STY_Menu_358211_RowViewModel(UserContext userContext, CSGenioAflds val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "AERO",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "FLDS",
				Field = "DESCRIP",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "FLDS",
				Field = "NPASSAGE",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "FLDS",
				Field = "DURATION",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "FLDS",
				Field = "PRICE",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "FLDS",
				Field = "PRECOBIL",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "FLDS",
				Field = "DATE",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "FLDS",
				Field = "DATETIME",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "FLDS",
				Field = "DATESECO",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "FLDS",
				Field = "TIME",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "FLDS",
				Field = "YEAR",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "FLDS",
				Field = "PRIMVIAG",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "FLDS",
				Field = "CONDITIO",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "FLDS",
				Field = "CLASS",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "FLDS",
				Field = "CLASSNUM",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "FLDS",
				Field = "LOGICENU",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "FLDS",
				Field = "LOGO",
			},
			new ListColumn()
			{
				Order = 18,
				Area = "FLDS",
				Field = "ATTACH",
			},
			new ListColumn()
			{
				Order = 19,
				Area = "FLDS",
				Field = "CREATUSE",
			},
			new ListColumn()
			{
				Order = 20,
				Area = "FLDS",
				Field = "CREATDAT",
			},
			new ListColumn()
			{
				Order = 21,
				Area = "FLDS",
				Field = "CREATHOU",
			},
			new ListColumn()
			{
				Order = 22,
				Area = "FLDS",
				Field = "CREATINS",
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
		bool canInsert = false;

		using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport))
		{

			// Table FLDS CRUD conditions.
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
