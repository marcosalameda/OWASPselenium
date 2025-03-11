using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Propr;

public class IMO_Menu_111_RowViewModel : Models.Propr
{
	#region Constructors

	public IMO_Menu_111_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowData();
	}

	public IMO_Menu_111_RowViewModel(UserContext userContext, CSGenioApropr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "PROPR",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "PROPR",
				Field = "PRECOEST",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "TPPRO",
				Field = "TPPROPRI",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "PROPR",
				Field = "ENDERECO",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "PROPR",
				Field = "LOCALIDA",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "REGIO",
				Field = "REGIAO",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "PROPR",
				Field = "POSTALCO",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "PROPR",
				Field = "POSTALLO",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "CNTRY",
				Field = "COUNTRY",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "PROPR",
				Field = "MOBILADA",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "PROPR",
				Field = "QTD_WC",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "PROPR",
				Field = "QTDQUART",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "PROPR",
				Field = "M2",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "PROPR",
				Field = "DTDISPON",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "PROPR",
				Field = "PHOTOGRA",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "PROPR",
				Field = "DESCRIPT",
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
}
