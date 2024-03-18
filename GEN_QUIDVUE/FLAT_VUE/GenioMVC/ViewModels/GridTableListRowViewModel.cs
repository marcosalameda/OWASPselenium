using System;
using System.Collections.Specialized;

using CSGenio.framework;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public abstract class GridTableListRowViewModel<T> : CrudViewModel<T> where T : ModelBase
	{
        protected GridTableListRowViewModel(UserContext userContext, string? identifier = null, bool nestedForm = false) : base(userContext, identifier, nestedForm) { }

        protected GridTableListRowViewModel(UserContext userContext, string identifier, T row, bool nestedForm = false) : base(userContext, identifier, row, nestedForm) { }

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;

			Model.Identifier = Identifier;
			InitModel(qs, lazyLoad);
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				MapToModel(Model);
				// Preencher operações internas
				Model.baseklass.fillInternalOperations(m_userContext.PersistentSupport, null);
				MapFromModel(Model);
			}
		}

		private void MapFromClientSide()
		{
			if (Model == null)
			{
				Model = CreateModelBase();
				MapToModel(Model);
			}
			else
			{
				// Model was created by New()
				// PK is set but all other fields are empty

				// Save PK to restore later
				string pk = Model.baseklass.QPrimaryKey;

				// Fill form fields
				MapToModel(Model);

				// Restore PK
				Model.baseklass.QPrimaryKey = pk;
			}
		}

		public override void Apply()
		{
			MapFromClientSide();
			Model.Apply();
		}

		public override void Save()
		{
			MapFromClientSide();
			this.flashMessage = Model.Save();
		}

		// Creates the pseudo-new record in the database (zzstate=1)
		public override void New()
		{
			editable = true;
			Model = CreateModelBase();
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
			Model.New(Identifier);
		}

		// Loads all the information needed to present the form in insert mode
		public override void NewLoad()
		{
			editable = true;
			Model = CreateModelBase();
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);

			this.LoadPartial(new NameValueCollection());

			// Preencher Qvalues default
			Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, FunctionType.INS);
			LoadDefaultValues();
			// Preencher operações internas (In records that do not exist in the DB, it is not possible to calculate)
			//Model.baseklass.fillInternalOperations(m_userContext.PersistentSupport, null);
			MapFromModel(Model);
		}

		public override void Duplicate(string id)
		{
			throw new NotSupportedException();
		}
	}
}
