using System;
using System.Collections.Specialized;

using CSGenio.framework;
using CSGenio.business;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public abstract class GridTableListRowViewModel<T> : CrudViewModel<T> where T : ModelBase, new()
	{
		protected GridTableListRowViewModel() : base() { }

		protected GridTableListRowViewModel(string identifier) : base(identifier) { }

		protected GridTableListRowViewModel(NavigationContext currentNavigation, bool nestedForm = false) : base(currentNavigation, nestedForm) { }

		protected GridTableListRowViewModel(string identifier, NavigationContext currentNavigation, bool nestedForm = false) : base(identifier, currentNavigation, nestedForm) { }

		protected GridTableListRowViewModel(string identifier, T row, NavigationContext currentNavigation, bool nestedForm = false) : base(identifier, row, currentNavigation, nestedForm) { }

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
				Model.baseklass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
				MapFromModel(Model);
			}
		}

		private void MapFromClientSide()
		{
			if (Model == null)
			{
				Model = new T();
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

            StatusMessage result = new StatusMessage();
            result = EvaluateWriteConditions(isApply: false);

            if (result.Status == Status.E)
                throw new BusinessException(result.Message, "DbArea.alterar", "Error updating record: " + result.Message);
            else
                Model.Apply();
        }

        public override void Save()
        {
            MapFromClientSide();

            if (HasWriteConditions)
            {
                StatusMessage result = new StatusMessage();
                result = EvaluateWriteConditions(isApply: false);

                if (result.Status != Status.OK)
                    this.flashMessage = result;
                if (result.Status == Status.E)
                    throw new BusinessException(result.Message, "DbArea.alterar", "Error updating record: " + result.Message);
                else
                    this.flashMessage = Model.Save();
            }
            else
                this.flashMessage = Model.Save();
        }

		// Creates the pseudo-new record in the database (zzstate=1)
		public override void New()
		{
			editable = true;
			Model = new T();
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);
			Model.New(Identifier);
		}

		// Loads all the information needed to present the form in insert mode
		public override void NewLoad()
		{
			editable = true;
			Model = new T();
			Model.LoadKeysFormHistory(Navigation, Navigation.CurrentLevel.Level);

			this.LoadPartial(new NameValueCollection());

			// Preencher Qvalues default
			Model.baseklass.fillValuesDefault(UserContext.Current.PersistentSupport, FunctionType.INS);
			LoadDefaultValues();
			// Preencher operações internas (In records that do not exist in the DB, it is not possible to calculate)
			//Model.baseklass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
			MapFromModel(Model);
		}

		public override void Duplicate(string id)
		{
			throw new NotSupportedException();
		}
	}
}
