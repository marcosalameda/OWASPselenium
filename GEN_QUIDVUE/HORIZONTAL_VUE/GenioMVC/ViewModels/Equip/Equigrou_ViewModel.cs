using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Equip
{
	public class Equigrou_ViewModel : FormViewModel<Models.Equip>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		public string ValCodempre { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCoddeco { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCoditem { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "CE"
		/// </summary>
		public string ValCodpess1 { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodrooms { get; set; }
		/// <summary>
		/// Title: "TYPE OF EQUIPMENT" | Type: "CE"
		/// </summary>
		public string ValCodtpequ { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodwareh { get; set; }

		#endregion
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel Pess1ValPhotogra 
		{
			get
			{
				return funcPess1ValPhotogra != null ? funcPess1ValPhotogra() : _auxPess1ValPhotogra;
			}
			set { funcPess1ValPhotogra = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.Models.ImageModel> funcPess1ValPhotogra { get; set; }

		private GenioMVC.Models.ImageModel _auxPess1ValPhotogra { get; set; }
		/// <summary>
		/// Title: "Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Pess1> TablePess1Name { get; set; }
		/// <summary>
		/// Title: "Genre" | Type: "AC"
		/// </summary>
		[ValidateSetAccess]
		public string Pess1ValGender 
		{
			get
			{
				return funcPess1ValGender != null ? funcPess1ValGender() : _auxPess1ValGender;
			}
			set { funcPess1ValGender = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPess1ValGender { get; set; }

		private string _auxPess1ValGender { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_Pess1ValGender { get; set; }
		/// <summary>
		/// Title: "Birth" | Type: "D"
		/// </summary>
		[ValidateSetAccess]
		public DateTime? Pess1ValDtnascim 
		{
			get
			{
				return funcPess1ValDtnascim != null ? funcPess1ValDtnascim() : _auxPess1ValDtnascim;
			}
			set { funcPess1ValDtnascim = () => value; }
		}

		[JsonIgnore]
		public Func<DateTime?> funcPess1ValDtnascim { get; set; }

		private DateTime? _auxPess1ValDtnascim { get; set; }
		/// <summary>
		/// Title: "Age" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? Pess1ValIdade 
		{
			get
			{
				return funcPess1ValIdade != null ? funcPess1ValIdade() : _auxPess1ValIdade;
			}
			set { funcPess1ValIdade = () => value; }
		}

		[JsonIgnore]
		public Func<decimal?> funcPess1ValIdade { get; set; }

		private decimal? _auxPess1ValIdade { get; set; }
		/// <summary>
		/// Title: "Official No." | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? Pess1ValIdfuncio 
		{
			get
			{
				return funcPess1ValIdfuncio != null ? funcPess1ValIdfuncio() : _auxPess1ValIdfuncio;
			}
			set { funcPess1ValIdfuncio = () => value; }
		}

		[JsonIgnore]
		public Func<decimal?> funcPess1ValIdfuncio { get; set; }

		private decimal? _auxPess1ValIdfuncio { get; set; }
		/// <summary>
		/// Title: "Phone" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string Pess1ValTelephon 
		{
			get
			{
				return funcPess1ValTelephon != null ? funcPess1ValTelephon() : _auxPess1ValTelephon;
			}
			set { funcPess1ValTelephon = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPess1ValTelephon { get; set; }

		private string _auxPess1ValTelephon { get; set; }
		/// <summary>
		/// Title: "Email 1" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string Pess1ValEmail 
		{
			get
			{
				return funcPess1ValEmail != null ? funcPess1ValEmail() : _auxPess1ValEmail;
			}
			set { funcPess1ValEmail = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPess1ValEmail { get; set; }

		private string _auxPess1ValEmail { get; set; }
		/// <summary>
		/// Title: "Email 2" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string Pess1ValEmail2 
		{
			get
			{
				return funcPess1ValEmail2 != null ? funcPess1ValEmail2() : _auxPess1ValEmail2;
			}
			set { funcPess1ValEmail2 = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcPess1ValEmail2 { get; set; }

		private string _auxPess1ValEmail2 { get; set; }
		/// <summary>
		/// Title: "Logo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		[ValidateSetAccess]
		public GenioMVC.Models.ImageModel CmpnyValLogo 
		{
			get
			{
				return funcCmpnyValLogo != null ? funcCmpnyValLogo() : _auxCmpnyValLogo;
			}
			set { funcCmpnyValLogo = () => value; }
		}

		[JsonIgnore]
		public Func<GenioMVC.Models.ImageModel> funcCmpnyValLogo { get; set; }

		private GenioMVC.Models.ImageModel _auxCmpnyValLogo { get; set; }
		/// <summary>
		/// Title: "Designation" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CmpnyValDesignat 
		{
			get
			{
				return funcCmpnyValDesignat != null ? funcCmpnyValDesignat() : _auxCmpnyValDesignat;
			}
			set { funcCmpnyValDesignat = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCmpnyValDesignat { get; set; }

		private string _auxCmpnyValDesignat { get; set; }
		/// <summary>
		/// Title: "Acronym" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CmpnyValAcronym 
		{
			get
			{
				return funcCmpnyValAcronym != null ? funcCmpnyValAcronym() : _auxCmpnyValAcronym;
			}
			set { funcCmpnyValAcronym = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCmpnyValAcronym { get; set; }

		private string _auxCmpnyValAcronym { get; set; }
		/// <summary>
		/// Title: "Tax identification" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CmpnyValNif 
		{
			get
			{
				return funcCmpnyValNif != null ? funcCmpnyValNif() : _auxCmpnyValNif;
			}
			set { funcCmpnyValNif = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCmpnyValNif { get; set; }

		private string _auxCmpnyValNif { get; set; }
		/// <summary>
		/// Title: "Phone" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CmpnyValTelephon 
		{
			get
			{
				return funcCmpnyValTelephon != null ? funcCmpnyValTelephon() : _auxCmpnyValTelephon;
			}
			set { funcCmpnyValTelephon = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCmpnyValTelephon { get; set; }

		private string _auxCmpnyValTelephon { get; set; }
		/// <summary>
		/// Title: "Email" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string CmpnyValEmail 
		{
			get
			{
				return funcCmpnyValEmail != null ? funcCmpnyValEmail() : _auxCmpnyValEmail;
			}
			set { funcCmpnyValEmail = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcCmpnyValEmail { get; set; }

		private string _auxCmpnyValEmail { get; set; }
		/// <summary>
		/// Title: "Changes number" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValQtdmovim { get; set; }
		/// <summary>
		/// Title: "Acquisition" | Type: "D"
		/// </summary>
		public DateTime? ValDtaquisi { get; set; }
		/// <summary>
		/// Title: "TYPE OF EQUIPMENT" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Tpequ> TableTpequTipoequi { get; set; }
		/// <summary>
		/// Title: "Code" | Type: "TF"
		/// </summary>
		[ValidateSetAccess]
		public string TpequValTpequcod 
		{
			get
			{
				return funcTpequValTpequcod != null ? funcTpequValTpequcod() : _auxTpequValTpequcod;
			}
			set { funcTpequValTpequcod = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcTpequValTpequcod { get; set; }

		private string _auxTpequValTpequcod { get; set; }
		/// <summary>
		/// Title: "Maximum price" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? TpequValPrecomax 
		{
			get
			{
				return funcTpequValPrecomax != null ? funcTpequValPrecomax() : _auxTpequValPrecomax;
			}
			set { funcTpequValPrecomax = () => value; }
		}

		[JsonIgnore]
		public Func<decimal?> funcTpequValPrecomax { get; set; }

		private decimal? _auxTpequValPrecomax { get; set; }
		/// <summary>
		/// Title: "Dependent on" | Type: "TP"
		/// </summary>
		[ValidateSetAccess]
		public string TpequValTpequpai 
		{
			get
			{
				return funcTpequValTpequpai != null ? funcTpequValTpequpai() : _auxTpequValTpequpai;
			}
			set { funcTpequValTpequpai = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcTpequValTpequpai { get; set; }

		private string _auxTpequValTpequpai { get; set; }
		/// <summary>
		/// Title: "Level" | Type: "TN"
		/// </summary>
		[ValidateSetAccess]
		public decimal TpequValNivel 
		{
			get
			{
				return funcTpequValNivel != null ? funcTpequValNivel() : _auxTpequValNivel;
			}
			set { funcTpequValNivel = () => value; }
		}

		[JsonIgnore]
		public Func<decimal> funcTpequValNivel { get; set; }

		private decimal _auxTpequValNivel { get; set; }
		/// <summary>
		/// Title: "Background color" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string TpequValBackcolo 
		{
			get
			{
				return funcTpequValBackcolo != null ? funcTpequValBackcolo() : _auxTpequValBackcolo;
			}
			set { funcTpequValBackcolo = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcTpequValBackcolo { get; set; }

		private string _auxTpequValBackcolo { get; set; }
		/// <summary>
		/// Title: "Letter color" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string TpequValCorletra 
		{
			get
			{
				return funcTpequValCorletra != null ? funcTpequValCorletra() : _auxTpequValCorletra;
			}
			set { funcTpequValCorletra = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcTpequValCorletra { get; set; }

		private string _auxTpequValCorletra { get; set; }
		/// <summary>
		/// Title: "Sequential no." | Type: "N"
		/// </summary>
		public decimal? ValSequennr { get; set; }
		/// <summary>
		/// Title: "No. register" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValRegistnr { get; set; }
		/// <summary>
		/// Title: "Total value" | Type: "$D"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValortot { get; set; }
		/// <summary>
		/// Title: "Loan frequency" | Type: "AN"
		/// </summary>
		public decimal ValFrequenc { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValFrequenc { get; set; }
		/// <summary>
		/// Title: "Bought" | Type: "L"
		/// </summary>
		[ValidateSetAccess]
		public bool ValBought { get; set; }
		/// <summary>
		/// Title: "Reference" | Type: "DT"
		/// </summary>
		public DateTime? ValDtrefere { get; set; }
		/// <summary>
		/// Title: "First" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValFirst { get; set; }
		/// <summary>
		/// Title: "Photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhotogra { get; set; }
		/// <summary>
		/// Title: "Designation" | Type: "C"
		/// </summary>
		public string ValDesignat { get; set; }



		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the ItemValItemdes field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<string> funcItemValItemdes { get; set; }
		private string _auxItemValItemdes { get; set; }
		/// <summary>Field: "Article" Tipo: "C"</summary>
		[ValidateSetAccess]
		public string ItemValItemdes { get { return funcItemValItemdes != null ? funcItemValItemdes() : _auxItemValItemdes; } private set { funcItemValItemdes = () => value; } }

		#endregion

		public string ValCodequip { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Equigrou_ViewModel() : base(null!) { }

		public Equigrou_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FEQUIGROU", nestedForm) { }

		public Equigrou_ViewModel(UserContext userContext, Models.Equip row, bool nestedForm = false) : base(userContext, "FEQUIGROU", row, nestedForm) { }

		public Equigrou_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("equip", id);
			Model = Models.Equip.Find(id, userContext, "FEQUIGROU", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Equip model = new Models.Equip(userContext) { Identifier = "FEQUIGROU" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FEQUIGROU");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equigrou) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodempre = ViewModelConversion.ToString(m.ValCodempre);
				ValCoddeco = ViewModelConversion.ToString(m.ValCoddeco);
				ValCoditem = ViewModelConversion.ToString(m.ValCoditem);
				ValCodpess1 = ViewModelConversion.ToString(m.ValCodpess1);
				ValCodrooms = ViewModelConversion.ToString(m.ValCodrooms);
				ValCodtpequ = ViewModelConversion.ToString(m.ValCodtpequ);
				ValCodwareh = ViewModelConversion.ToString(m.ValCodwareh);
				funcPess1ValPhotogra = () => ViewModelConversion.ToImage(m.Pess1.ValPhotogra);
				funcPess1ValGender = () => ViewModelConversion.ToString(m.Pess1.ValGender);
				funcPess1ValDtnascim = () => ViewModelConversion.ToDateTime(m.Pess1.ValDtnascim);
				funcPess1ValIdade = () => ViewModelConversion.ToNumeric(m.Pess1.ValIdade);
				funcPess1ValIdfuncio = () => ViewModelConversion.ToNumeric(m.Pess1.ValIdfuncio);
				funcPess1ValTelephon = () => ViewModelConversion.ToString(m.Pess1.ValTelephon);
				funcPess1ValEmail = () => ViewModelConversion.ToString(m.Pess1.ValEmail);
				funcPess1ValEmail2 = () => ViewModelConversion.ToString(m.Pess1.ValEmail2);
				funcCmpnyValLogo = () => ViewModelConversion.ToImage(m.Cmpny.ValLogo);
				funcCmpnyValDesignat = () => ViewModelConversion.ToString(m.Cmpny.ValDesignat);
				funcCmpnyValAcronym = () => ViewModelConversion.ToString(m.Cmpny.ValAcronym);
				funcCmpnyValNif = () => ViewModelConversion.ToString(m.Cmpny.ValNif);
				funcCmpnyValTelephon = () => ViewModelConversion.ToString(m.Cmpny.ValTelephon);
				funcCmpnyValEmail = () => ViewModelConversion.ToString(m.Cmpny.ValEmail);
				ValQtdmovim = ViewModelConversion.ToNumeric(m.ValQtdmovim);
				ValDtaquisi = ViewModelConversion.ToDateTime(m.ValDtaquisi);
				funcTpequValTpequcod = () => ViewModelConversion.ToString(m.Tpequ.ValTpequcod);
				funcTpequValPrecomax = () => ViewModelConversion.ToNumeric(m.Tpequ.ValPrecomax);
				funcTpequValTpequpai = () => ViewModelConversion.ToString(m.Tpequ.ValTpequpai);
				funcTpequValNivel = () => ViewModelConversion.ToNumeric(m.Tpequ.ValNivel);
				funcTpequValBackcolo = () => ViewModelConversion.ToString(m.Tpequ.ValBackcolo);
				funcTpequValCorletra = () => ViewModelConversion.ToString(m.Tpequ.ValCorletra);
				ValSequennr = ViewModelConversion.ToNumeric(m.ValSequennr);
				ValRegistnr = ViewModelConversion.ToString(m.ValRegistnr);
				ValValortot = ViewModelConversion.ToNumeric(m.ValValortot);
				ValFrequenc = ViewModelConversion.ToNumeric(m.ValFrequenc);
				ValBought = ViewModelConversion.ToLogic(m.ValBought);
				ValDtrefere = ViewModelConversion.ToDateTime(m.ValDtrefere);
				ValFirst = ViewModelConversion.ToString(m.ValFirst);
				ValPhotogra = ViewModelConversion.ToImage(m.ValPhotogra);
				ValDesignat = ViewModelConversion.ToString(m.ValDesignat);
				funcItemValItemdes = () => ViewModelConversion.ToString(m.Item.ValItemdes);
				ValCodequip = ViewModelConversion.ToString(m.ValCodequip);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Equip) to ViewModel (Equigrou) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Equip m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Equigrou) to Model (Equip) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodempre = ViewModelConversion.ToString(ValCodempre);
				m.ValCodpess1 = ViewModelConversion.ToString(ValCodpess1);
				m.ValCodtpequ = ViewModelConversion.ToString(ValCodtpequ);
				m.ValDtaquisi = ViewModelConversion.ToDateTime(ValDtaquisi);
				m.ValSequennr = ViewModelConversion.ToNumeric(ValSequennr);
				m.ValFrequenc = ViewModelConversion.ToNumeric(ValFrequenc);
				m.ValDtrefere = ViewModelConversion.ToDateTime(ValDtrefere);
				if (ValPhotogra == null || !ValPhotogra.IsThumbnail)
					m.ValPhotogra = ViewModelConversion.ToImage(ValPhotogra);
				m.ValDesignat = ViewModelConversion.ToString(ValDesignat);
				m.ValCodequip = ViewModelConversion.ToString(ValCodequip);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCoddeco = ViewModelConversion.ToString(ValCoddeco);
				m.ValCoditem = ViewModelConversion.ToString(ValCoditem);
				m.ValCodrooms = ViewModelConversion.ToString(ValCodrooms);
				m.ValCodwareh = ViewModelConversion.ToString(ValCodwareh);
				m.ValQtdmovim = ViewModelConversion.ToNumeric(ValQtdmovim);
				m.ValRegistnr = ViewModelConversion.ToString(ValRegistnr);
				m.ValValortot = ViewModelConversion.ToNumeric(ValValortot);
				m.ValBought = ViewModelConversion.ToLogic(ValBought);
				m.ValFirst = ViewModelConversion.ToString(ValFirst);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Equigrou) to Model (Equip) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "equip.codempre":
						this.ValCodempre = ViewModelConversion.ToString(_value);
						break;
					case "equip.codpess1":
						this.ValCodpess1 = ViewModelConversion.ToString(_value);
						break;
					case "equip.codtpequ":
						this.ValCodtpequ = ViewModelConversion.ToString(_value);
						break;
					case "equip.dtaquisi":
						this.ValDtaquisi = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.sequennr":
						this.ValSequennr = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.frequenc":
						this.ValFrequenc = ViewModelConversion.ToNumeric(_value);
						break;
					case "equip.dtrefere":
						this.ValDtrefere = ViewModelConversion.ToDateTime(_value);
						break;
					case "equip.photogra":
						this.ValPhotogra = ViewModelConversion.ToImage(_value);
						break;
					case "equip.designat":
						this.ValDesignat = ViewModelConversion.ToString(_value);
						break;
					case "equip.codequip":
						this.ValCodequip = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Equigrou) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Equigrou)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Equip.Find(id ?? Navigation.GetStrValue("equip"), m_userContext, "FEQUIGROU"); }
			finally { Model ??= new Models.Equip(m_userContext) { Identifier = "FEQUIGROU" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FEQUIGROU");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FEQUIGROU";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Equip row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Equip.Find(Navigation.GetStrValue("equip"), m_userContext, "FEQUIGROU");
				if (Model == null)
				{
					Model = new Models.Equip(m_userContext) { Identifier = "FEQUIGROU" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("equip");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Equigroupess1name____(qs, lazyLoad);
			Load_Equigroutpequtipoequi(qs, lazyLoad);
// USE /[MANUAL GQT VIEWMODEL_LOADPARTIAL EQUIGROU]/
		}

// USE /[MANUAL GQT VIEWMODEL_NEW EQUIGROU]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("Pess1ValTelephon", Resources.Resources.PHONE56703, Pess1ValTelephon, 20);
			validator.StringLength("Pess1ValEmail", Resources.Resources.EMAIL_106184, Pess1ValEmail, 254);
			validator.StringLength("Pess1ValEmail2", Resources.Resources.EMAIL_211233, Pess1ValEmail2, 254);
			validator.StringLength("CmpnyValDesignat", Resources.Resources.DESIGNATION35876, CmpnyValDesignat, 85);
			validator.StringLength("CmpnyValAcronym", Resources.Resources.ACRONYM00872, CmpnyValAcronym, 15);
			validator.StringLength("CmpnyValNif", Resources.Resources.TAX_IDENTIFICATION51190, CmpnyValNif, 15);
			validator.StringLength("CmpnyValTelephon", Resources.Resources.PHONE56703, CmpnyValTelephon, 20);
			validator.StringLength("CmpnyValEmail", Resources.Resources.EMAIL25170, CmpnyValEmail, 254);
			validator.StringLength("TpequValTpequcod", Resources.Resources.CODE49225, TpequValTpequcod, 20);
			validator.StringLength("TpequValTpequpai", Resources.Resources.DEPENDENT_ON28321, TpequValTpequpai, 20);
			validator.StringLength("TpequValBackcolo", Resources.Resources.BACKGROUND_COLOR47883, TpequValBackcolo, 50);
			validator.StringLength("TpequValCorletra", Resources.Resources.LETTER_COLOR15736, TpequValCorletra, 50);
			validator.StringLength("ValRegistnr", Resources.Resources.NO__REGISTER04207, ValRegistnr, 6);
			validator.StringLength("ValFirst", Resources.Resources.FIRST42972, ValFirst, 10);
			validator.StringLength("ValDesignat", Resources.Resources.DESIGNATION35876, ValDesignat, 85);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL GQT VIEWMODEL_SAVE EQUIGROU]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL GQT VIEWMODEL_APPLY EQUIGROU]/

// USE /[MANUAL GQT VIEWMODEL_DUPLICATE EQUIGROU]/

// USE /[MANUAL GQT VIEWMODEL_DESTROY EQUIGROU]/
		public override void Destroy(string id)
		{
			Model = Models.Equip.Find(id, m_userContext, "FEQUIGROU");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TablePess1Name -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equigroupess1name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equigroupess1name____DoLoad = true;
			CriteriaSet equigroupess1name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("pess1", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equigroupess1name____Conds.Equal(CSGenioApess1.FldCodpesso, hValue);
					this.ValCodpess1 = DBConversion.ToString(hValue);
				}
			}
			// Limits Generation

			// Area limit
			equigroupess1name____DoLoad &= AddCriteriaAreaLimit(equigroupess1name____Conds, CSGenio.business.CSGenioAcmpny.FldCodempre, "cmpny", this.ValCodempre, true);

			TablePess1Name = new TableDBEdit<Models.Pess1>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}
				FillDependant_EquigrouTablePess1Name(lazyLoad);
				return;
			}

			if (string.IsNullOrEmpty(this.ValCodempre))
				equigroupess1name____DoLoad = false;

			if (equigroupess1name____DoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TablePess1Name, "sTablePess1Name", "dTablePess1Name", qs, "pess1");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePess1Name_tableFilters"]))
					TablePess1Name.TableFilters = bool.Parse(qs["TablePess1Name_tableFilters"]);
				else
					TablePess1Name.TableFilters = false;

				query = qs["qTablePess1Name"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioApess1.FldName, query + "%");
				}
				equigroupess1name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePess1Name"] != null ? qs["pTablePess1Name"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIGROU_PESS1NAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("pess1", FormMode.New) || Navigation.checkFormMode("pess1", FormMode.Duplicate))
					equigroupess1name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioApess1.FldZzstate, 0)
						.Equal(CSGenioApess1.FldCodpesso, Navigation.GetStrValue("pess1")));
				else
					equigroupess1name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioApess1.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("pess1", "name");
				ListingMVC<CSGenioApess1> listing = Models.ModelBase.Where<CSGenioApess1>(m_userContext, false, equigroupess1name____Conds, fields, offset, numberItems, sorts, "LED_EQUIGROUPESS1NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePess1Name.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePess1Name.Query = query;
				TablePess1Name.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Pess1(m_userContext, r, true, _fieldsToSerialize_EQUIGROUPESS1NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_pess1") != null)
				{
					this.ValCodpess1 = Navigation.GetStrValue("RETURN_pess1");
					Navigation.CurrentLevel.SetEntry("RETURN_pess1", null);
				}

				TablePess1Name.List = new SelectList(TablePess1Name.Elements.ToSelectList(x => x.ValName, x => x.ValCodpesso,  x => x.ValCodpesso == this.ValCodpess1), "Value", "Text", this.ValCodpess1);
				FillDependant_EquigrouTablePess1Name();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Pess1</param>
		public ConcurrentDictionary<string, object> GetDependant_EquigrouTablePess1Name(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioApess1.FldCodpesso, CSGenioApess1.FldName, CSGenioApess1.FldPhotogra, CSGenioApess1.FldGender, CSGenioApess1.FldDtnascim, CSGenioApess1.FldIdade, CSGenioApess1.FldIdfuncio, CSGenioApess1.FldTelephon, CSGenioApess1.FldEmail, CSGenioApess1.FldEmail2, CSGenioAcmpny.FldCodempre, CSGenioAcmpny.FldLogo, CSGenioAcmpny.FldDesignat, CSGenioAcmpny.FldAcronym, CSGenioAcmpny.FldNif, CSGenioAcmpny.FldTelephon, CSGenioAcmpny.FldEmail];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			{
				object hValue = Navigation.GetValue("cmpny");
				if (!(hValue is Array))
				{
					if (GenFunctions.emptyG(hValue) == 1)
						returnEmptyDependants = true;
					wherecodition.Equal(CSGenioApess1.FldCodempre, hValue);
				}
			}
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioApess1 tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioApess1.FldCodpesso, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePess1Name (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquigrouTablePess1Name(bool lazyLoad = false)
		{
			var row = GetDependant_EquigrouTablePess1Name(this.ValCodpess1);
			try
			{
				this.funcPess1ValPhotogra = () => (GenioMVC.Models.ImageModel)row["pess1.photogra"];
				this.funcPess1ValGender = () => (string)row["pess1.gender"];
				this.funcPess1ValDtnascim = () => (DateTime?)row["pess1.dtnascim"];
				this.funcPess1ValIdade = () => (decimal?)row["pess1.idade"];
				this.funcPess1ValIdfuncio = () => (decimal?)row["pess1.idfuncio"];
				this.funcPess1ValTelephon = () => (string)row["pess1.telephon"];
				this.funcPess1ValEmail = () => (string)row["pess1.email"];
				this.funcPess1ValEmail2 = () => (string)row["pess1.email2"];
				this.ValCodempre = (string)row["cmpny.codempre"];
				this.funcCmpnyValLogo = () => (GenioMVC.Models.ImageModel)row["cmpny.logo"];
				this.funcCmpnyValDesignat = () => (string)row["cmpny.designat"];
				this.funcCmpnyValAcronym = () => (string)row["cmpny.acronym"];
				this.funcCmpnyValNif = () => (string)row["cmpny.nif"];
				this.funcCmpnyValTelephon = () => (string)row["cmpny.telephon"];
				this.funcCmpnyValEmail = () => (string)row["cmpny.email"];

				// Fill List fields
				this.ValCodpess1 = ViewModelConversion.ToString(row["pess1.codpesso"]);
				TablePess1Name.Value = (string)row["pess1.name"];
				if (GenFunctions.emptyG(this.ValCodpess1) == 1)
				{
					this.ValCodpess1 = "";
					TablePess1Name.Value = "";
					Navigation.ClearValue("pess1");
				}
				else if (lazyLoad)
				{
					TablePess1Name.SetPagination(1, 0, false, false, 1);
					TablePess1Name.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodpess1),
							Text = Convert.ToString(TablePess1Name.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodpess1);
				}

				TablePess1Name.Selected = this.ValCodpess1;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePess1Name): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIGROUPESS1NAME____ = ["Pess1", "Pess1.ValCodpesso", "Pess1.ValZzstate", "Pess1.ValName"];

		/// <summary>
		/// TableTpequTipoequi -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Equigroutpequtipoequi(NameValueCollection qs, bool lazyLoad = false)
		{
			bool equigroutpequtipoequiDoLoad = true;
			CriteriaSet equigroutpequtipoequiConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("tpequ", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					equigroutpequtipoequiConds.Equal(CSGenioAtpequ.FldCodtpequ, hValue);
					this.ValCodtpequ = DBConversion.ToString(hValue);
				}
			}

			TableTpequTipoequi = new TableDBEdit<Models.Tpequ>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}
				FillDependant_EquigrouTableTpequTipoequi(lazyLoad);
				return;
			}

			if (equigroutpequtipoequiDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableTpequTipoequi, "sTableTpequTipoequi", "dTableTpequTipoequi", qs, "tpequ");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableTpequTipoequi_tableFilters"]))
					TableTpequTipoequi.TableFilters = bool.Parse(qs["TableTpequTipoequi_tableFilters"]);
				else
					TableTpequTipoequi.TableFilters = false;

				query = qs["qTableTpequTipoequi"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAtpequ.FldTipoequi, query + "%");
				}
				equigroutpequtipoequiConds.SubSet(search_filters);

				string tryParsePage = qs["pTableTpequTipoequi"] != null ? qs["pTableTpequTipoequi"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldZzstate];

// USE /[MANUAL GQT OVERRQ EQUIGROU_TPEQUTIPOEQUI]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("tpequ", FormMode.New) || Navigation.checkFormMode("tpequ", FormMode.Duplicate))
					equigroutpequtipoequiConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAtpequ.FldZzstate, 0)
						.Equal(CSGenioAtpequ.FldCodtpequ, Navigation.GetStrValue("tpequ")));
				else
					equigroutpequtipoequiConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAtpequ.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("tpequ", "tipoequi");
				ListingMVC<CSGenioAtpequ> listing = Models.ModelBase.Where<CSGenioAtpequ>(m_userContext, false, equigroutpequtipoequiConds, fields, offset, numberItems, sorts, "LED_EQUIGROUTPEQUTIPOEQUI", true, false, firstVisibleColumn: firstVisibleColumn);

				TableTpequTipoequi.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableTpequTipoequi.Query = query;
				TableTpequTipoequi.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Tpequ(m_userContext, r, true, _fieldsToSerialize_EQUIGROUTPEQUTIPOEQUI));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_tpequ") != null)
				{
					this.ValCodtpequ = Navigation.GetStrValue("RETURN_tpequ");
					Navigation.CurrentLevel.SetEntry("RETURN_tpequ", null);
				}

				TableTpequTipoequi.List = new SelectList(TableTpequTipoequi.Elements.ToSelectList(x => x.ValTipoequi, x => x.ValCodtpequ,  x => x.ValCodtpequ == this.ValCodtpequ), "Value", "Text", this.ValCodtpequ);
				FillDependant_EquigrouTableTpequTipoequi();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Tpequ</param>
		public ConcurrentDictionary<string, object> GetDependant_EquigrouTableTpequTipoequi(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAtpequ.FldCodtpequ, CSGenioAtpequ.FldTipoequi, CSGenioAtpequ.FldTpequcod, CSGenioAtpequ.FldPrecomax, CSGenioAtpequ.FldTpequpai, CSGenioAtpequ.FldNivel, CSGenioAtpequ.FldBackcolo, CSGenioAtpequ.FldCorletra];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAtpequ tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAtpequ.FldCodtpequ, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableTpequTipoequi (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_EquigrouTableTpequTipoequi(bool lazyLoad = false)
		{
			var row = GetDependant_EquigrouTableTpequTipoequi(this.ValCodtpequ);
			try
			{
				this.funcTpequValTpequcod = () => (string)row["tpequ.tpequcod"];
				this.funcTpequValPrecomax = () => (decimal?)row["tpequ.precomax"];
				this.funcTpequValTpequpai = () => (string)row["tpequ.tpequpai"];
				this.funcTpequValNivel = () => (decimal)row["tpequ.nivel"];
				this.funcTpequValBackcolo = () => (string)row["tpequ.backcolo"];
				this.funcTpequValCorletra = () => (string)row["tpequ.corletra"];

				// Fill List fields
				this.ValCodtpequ = ViewModelConversion.ToString(row["tpequ.codtpequ"]);
				TableTpequTipoequi.Value = (string)row["tpequ.tipoequi"];
				if (GenFunctions.emptyG(this.ValCodtpequ) == 1)
				{
					this.ValCodtpequ = "";
					TableTpequTipoequi.Value = "";
					Navigation.ClearValue("tpequ");
				}
				else if (lazyLoad)
				{
					TableTpequTipoequi.SetPagination(1, 0, false, false, 1);
					TableTpequTipoequi.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodtpequ),
							Text = Convert.ToString(TableTpequTipoequi.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodtpequ);
				}

				TableTpequTipoequi.Selected = this.ValCodtpequ;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableTpequTipoequi): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_EQUIGROUTPEQUTIPOEQUI = ["Tpequ", "Tpequ.ValCodtpequ", "Tpequ.ValZzstate", "Tpequ.ValTipoequi"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"equip.codempre" => ViewModelConversion.ToString(modelValue),
				"equip.coddeco" => ViewModelConversion.ToString(modelValue),
				"equip.coditem" => ViewModelConversion.ToString(modelValue),
				"equip.codpess1" => ViewModelConversion.ToString(modelValue),
				"equip.codrooms" => ViewModelConversion.ToString(modelValue),
				"equip.codtpequ" => ViewModelConversion.ToString(modelValue),
				"equip.codwareh" => ViewModelConversion.ToString(modelValue),
				"pess1.photogra" => ViewModelConversion.ToImage(modelValue),
				"pess1.gender" => ViewModelConversion.ToString(modelValue),
				"pess1.dtnascim" => ViewModelConversion.ToDateTime(modelValue),
				"pess1.idade" => ViewModelConversion.ToNumeric(modelValue),
				"pess1.idfuncio" => ViewModelConversion.ToNumeric(modelValue),
				"pess1.telephon" => ViewModelConversion.ToString(modelValue),
				"pess1.email" => ViewModelConversion.ToString(modelValue),
				"pess1.email2" => ViewModelConversion.ToString(modelValue),
				"cmpny.logo" => ViewModelConversion.ToImage(modelValue),
				"cmpny.designat" => ViewModelConversion.ToString(modelValue),
				"cmpny.acronym" => ViewModelConversion.ToString(modelValue),
				"cmpny.nif" => ViewModelConversion.ToString(modelValue),
				"cmpny.telephon" => ViewModelConversion.ToString(modelValue),
				"cmpny.email" => ViewModelConversion.ToString(modelValue),
				"equip.qtdmovim" => ViewModelConversion.ToNumeric(modelValue),
				"equip.dtaquisi" => ViewModelConversion.ToDateTime(modelValue),
				"tpequ.tpequcod" => ViewModelConversion.ToString(modelValue),
				"tpequ.precomax" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.tpequpai" => ViewModelConversion.ToString(modelValue),
				"tpequ.nivel" => ViewModelConversion.ToNumeric(modelValue),
				"tpequ.backcolo" => ViewModelConversion.ToString(modelValue),
				"tpequ.corletra" => ViewModelConversion.ToString(modelValue),
				"equip.sequennr" => ViewModelConversion.ToNumeric(modelValue),
				"equip.registnr" => ViewModelConversion.ToString(modelValue),
				"equip.valortot" => ViewModelConversion.ToNumeric(modelValue),
				"equip.frequenc" => ViewModelConversion.ToNumeric(modelValue),
				"equip.bought" => ViewModelConversion.ToLogic(modelValue),
				"equip.dtrefere" => ViewModelConversion.ToDateTime(modelValue),
				"equip.first" => ViewModelConversion.ToString(modelValue),
				"equip.photogra" => ViewModelConversion.ToImage(modelValue),
				"equip.designat" => ViewModelConversion.ToString(modelValue),
				"item.itemdes" => ViewModelConversion.ToString(modelValue),
				"equip.codequip" => ViewModelConversion.ToString(modelValue),
				"pess1.codpesso" => ViewModelConversion.ToString(modelValue),
				"cmpny.codempre" => ViewModelConversion.ToString(modelValue),
				"pess1.name" => ViewModelConversion.ToString(modelValue),
				"tpequ.codtpequ" => ViewModelConversion.ToString(modelValue),
				"tpequ.tipoequi" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (Pess1ValPhotogra != null)
				Pess1ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPESS1, CSGenioApess1.FldPhotogra.Field, null, ValCodpess1);
			if (CmpnyValLogo != null)
				CmpnyValLogo.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCMPNY, CSGenioAcmpny.FldLogo.Field, null, ValCodempre);
			if (ValPhotogra != null)
				ValPhotogra.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaEQUIP, CSGenioAequip.FldPhotogra.Field, null, ValCodequip);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL GQT VIEWMODEL_CUSTOM EQUIGROU]/

		#endregion
	}
}
