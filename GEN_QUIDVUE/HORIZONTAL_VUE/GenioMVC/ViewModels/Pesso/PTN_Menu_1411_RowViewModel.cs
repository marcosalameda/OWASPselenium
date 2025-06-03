using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Pesso;

public class PTN_Menu_1411_RowViewModel : Models.Pesso
{
	#region Constructors

	public PTN_Menu_1411_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public PTN_Menu_1411_RowViewModel(UserContext userContext, CSGenioApesso val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
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
				Area = "PESSO",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "PESSO",
				Field = "GENDER",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "PESSO",
				Field = "DTNASCIM",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "PESSO",
				Field = "IDADE",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "PESSO",
				Field = "IDFUNCIO",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "PESSO",
				Field = "TELEPHON",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "PESSO",
				Field = "EMAIL",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "PESSO",
				Field = "EMAIL2",
			},
			new ListColumn()
			{
				Order = 10,
				Area = "PESSO",
				Field = "PHOTOGRA",
			},
			new ListColumn()
			{
				Order = 11,
				Area = "PESSO",
				Field = "DTULTCAT",
			},
			new ListColumn()
			{
				Order = 12,
				Area = "CATEG",
				Field = "CATEGORIA",
			},
			new ListColumn()
			{
				Order = 13,
				Area = "PESSO",
				Field = "EXTERNA",
			},
			new ListColumn()
			{
				Order = 14,
				Area = "PESSO",
				Field = "INTERNA",
			},
			new ListColumn()
			{
				Order = 15,
				Area = "CNTRY",
				Field = "COUNTRY",
			},
			new ListColumn()
			{
				Order = 16,
				Area = "PAIS1",
				Field = "COUNTRY",
			},
			new ListColumn()
			{
				Order = 17,
				Area = "REGI1",
				Field = "REGIAO",
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

			// Table PESSO CRUD conditions.
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
