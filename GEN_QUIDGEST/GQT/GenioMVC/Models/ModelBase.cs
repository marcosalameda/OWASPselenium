using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Models
{
	public class ModelBase
	{
		/// <summary>
		/// Local access to usercontext to improve compatibility with core version
		/// </summary>
		protected UserContext m_userContext => UserContext.Current;

		/// <summary>
		/// List of fields to be serialized. If it is null, serialize all.
		/// The property exists only for compatibility with constructors and functions such as Find and Search.
		/// Due to the large amount of Reflection accessing the methods, it would be too risky to change everything to HashSet already.
		/// </summary>
		protected string[] _fieldsToSerialize;

		/// <summary>
		/// List of fields to be serialized (ShouldSerialize[...]). If it is null, serialize all.
		/// The «.Contains» in the HashSet is faster than in the Array.
		/// </summary>
		protected HashSet<string> FieldsToSerialize;
		protected bool SerializeAllFields = true;

		[Newtonsoft.Json.JsonIgnore]
		public DbArea baseklass;

		[Newtonsoft.Json.JsonIgnore]
		public string Identifier { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public bool isEmptyModel { get; protected set; }

		/// <summary>
		/// Define the list of fields to be serialized
		/// </summary>
		/// <param name="fieldsToSerialize">The list of fields to be serialized</param>
		public void SetFieldsToSerialize(string[] fieldsToSerialize)
		{
			// The «_fieldsToSerialize» property exists only for compatibility with constructors and functions such as Find and Search.
			// Due to the large amount of Reflection accessing the methods, it would be too risky to change everything to HashSet already.
			_fieldsToSerialize = fieldsToSerialize;
			SerializeAllFields = fieldsToSerialize == null;
			FieldsToSerialize = SerializeAllFields ? null : new HashSet<string>(fieldsToSerialize);
		}

		public void SetIsEmptyModel(bool isEmptyModel)
		{
			this.isEmptyModel = isEmptyModel;
		}

		public T SetIsEmptyModel<T>(bool isEmptyModel) where T : ModelBase
		{
			SetIsEmptyModel(isEmptyModel);
			return (T)this;
		}

		public void New(string identifier = null)
		{
			this.New(UserContext.Current.PersistentSupport, UserContext.Current, identifier);
		}

		public void New(PersistentSupport sp, string identifier = null)
		{
			this.New(sp, UserContext.Current, identifier);
		}

		virtual public void New(PersistentSupport sp, UserContext ctx, string identifier = null)
		{
			User u = ctx.User;
			try
			{
				this.baseklass.fillEPH(u, sp, identifier);
				this.baseklass.insertPseud(sp);
			}
			finally
			{
				this.Identifier = identifier;
			}
		}

		public StatusMessage Save()
		{
			return this.Save(UserContext.Current.PersistentSupport);
		}

		public StatusMessage Save(PersistentSupport sp)
		{
			// Save self
			this.baseklass.removeCalculatedFields();
			this.baseklass.RemovePasswordFields(true);
			StatusMessage Qresult = this.baseklass.change(sp, (CriteriaSet)null);

			return Qresult;
		}

		public void Apply()
		{
			// Save self
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			this.baseklass.removeCalculatedFields();
			this.baseklass.RemovePasswordFields(true);
			//navigation direction from wizard forward/back
			bool isGoingBack = Convert.ToBoolean(UserContext.Current.CurrentNavigation.GetValue("clearData"));
			this.baseklass.apply(sp, isGoingBack);
		}

		public StatusMessage Destroy()
		{
			// Destroy Self
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			StatusMessage Qresult = this.baseklass.eliminate(sp);

			return Qresult;
		}

		public void Duplicate(string id)
		{
			// Duplicate
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			this.baseklass.duplicate(sp, CriteriaSet.And().Equal(this.baseklass.PrimaryKeyName, id));
		}

		public static CriteriaSet AddEPH<A>(ref User user, CriteriaSet args, string identifier = null) where A : CSGenio.business.Area
		{
			CriteriaSet condEph = Listing.CalculateConditionsEphGeneric((A)Activator.CreateInstance(typeof(A), user), identifier);

			if (condEph != null && (condEph.Criterias.Count > 0 || condEph.SubSets.Count > 0))
			{
				if (args == null)
					args = CriteriaSet.And();

				//garantir que não exists já um critério igual ao que vamos adicionar
				foreach (Criteria q in condEph.Criterias)
				{
					ColumnReference column = (ColumnReference)q.LeftTerm;
					Criteria criteria = args.FindCriteria(column.TableAlias, column.ColumnName, q.Operation, CriteriaSet.FindVariable.Any);
					if (criteria != null)
						condEph.Criterias.Remove(criteria);
				}

				args.SubSet(condEph);
			}

			return args;
		}

		/// <summary>
		/// Loads EPH fields into the model
		/// </summary>
		public void LoadEPH(string identifier = null)
		{
			if (baseklass == null)
				return;

			User u = UserContext.Current.User;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			baseklass.fillEPH(u, sp, identifier);
		}

		/// <summary>
		/// Gets a specific file (more importantly a specific version of a file)
		/// </summary>
		/// <param name="id">Coddocums</param>
		/// <returns>DBFile</returns>
		public static DBFile GetSpecificDocument(string id)
		{
			Docums doc = Docums.Find(id);
			DBFile fileDB = new DBFile(doc.ValNome, doc.ValExtensao, doc.ValVersao, doc.ValDocument, int.Parse(doc.ValTamanho));
			return fileDB;
		}

		/// <summary>
		/// Gets the lastest version of a specific document
		/// </summary>
		/// <param name="documid">documid</param>
		/// <returns>DBFile</returns>
		public static DBFile GetDocumentsLatestVersion(string documid)
		{
			Docums doc = Docums.GetLatestVersion(documid);
			DBFile fileDB = null;
			if (doc.ValDocument == null || doc.ValDocument.Length == 0)
				fileDB = new DBFile(doc.ValNome, doc.ValExtensao, doc.ValVersao, doc.ValDocpath, int.Parse(doc.ValTamanho));
			else
				fileDB = new DBFile(doc.ValNome, doc.ValExtensao, doc.ValVersao, doc.ValDocument, int.Parse(doc.ValTamanho));
			return fileDB;
		}

		/// <summary>
		/// Deletes the version history of a file
		/// </summary>
		/// <param name="field">The field name that holds the docum name</param>
		public bool DeleteHistoricVersions(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openConnection();
				field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
				baseklass.deleteHistoryDocums(sp, field);
				sp.closeConnection();

				return true;
			}
			catch (System.Exception)
			{
				// [RC] 06/06/2017 We need to close the connection here
				sp.closeConnection();
				return false;
			}
		}

		/// <summary>
		/// Deletes the last version of a file
		/// </summary>
		/// <param name="field">The field name that holds the docum name</param>
		public bool DeleteLastVersion(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openConnection();
				field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
				baseklass.deleteLastDocums(sp, field);
				sp.closeConnection();

				return true;
			}
			catch (System.Exception)
			{
				// [RC] 06/06/2017 We need to close the connection here
				sp.closeConnection();
				return false;
			}
		}

		/// <summary>
		/// Gathers all the available info for a given file (versions, size, author, etc.)
		/// </summary>
		/// <param name="field">The field name that holds the docum name</param>
		/// <returns>A view model that holds all the info of a file</returns>
		public DocumsProperties_ViewModel GetInfoDoc(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;

			field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
			string documid = baseklass.returnValueField(baseklass.Alias + "." + field + "fk") as string;
			DBFile info;
			if (String.IsNullOrEmpty(documid))
				info = DBFile.EmptyFile();
			else
				info = baseklass.infoDocum(sp, field);

			string checkoutEditor = info.CheckoutEditor == "" ? info.CurrentUser : info.CheckoutEditor;

			DocumsProperties_ViewModel doc = new DocumsProperties_ViewModel(info.Coddocums, info.DocumId, info.Name, info.GetSizeUnit(), info.Extension, info.Author, info.CreatedAt, info.Version, info.IsCheckout, checkoutEditor, info.Versions);
			return doc;
		}

		/// <summary>
		/// Rerturns the last version of a file
		/// </summary>
		/// <param name="field">The field name that holds the docum name</param>
		/// <returns>DBFile</returns>
		public DBFile FindDocument(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			DBFile file = null;
			field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
			file = baseklass.returnLastVersionFileDocum(sp, field);
			return file;
		}

		/// <summary>
		/// Saves a document
		/// </summary>
		/// <param name="area">The area</param>
		/// <param name="field">The field</param>
		/// <param name="file">The file</param>
		/// <returns>True if successful</returns>
		public bool SubmitVersion(string area, string field, byte[] file, string fileName, string coddocums , string mode, string version)
		{
			bool success = false;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();

				sp.openTransaction();
				baseklass.submitDocum(sp, field, file, fileName + "_" + coddocums, mode, version);
				baseklass.updateDirect(sp);
				sp.closeTransaction();
                success = true;
			}
			catch (System.Exception ex)
			{
				sp.rollbackTransaction();
                Log.Error("Error submiting document: " + ex);
            }

            return success;
        }

		/// <summary>
		/// Saves a document
		/// </summary>
		/// <param name="area">The area</param>
		/// <param name="field">The field</param>
		/// <param name="file">The file</param>
		/// <returns>True if successful</returns>
		public bool CheckoutVersion(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();

			try
			{
				sp.openTransaction();
				string newcodDocums = "";

				bool result = baseklass.checkoutDocums(sp, field, out newcodDocums);
				baseklass.updateDirect(sp);
				sp.closeTransaction();
				return result;
			}
			catch (System.Exception)
			{
				// [RC] 06/06/2017 We need to rollback the transaction here
				sp.rollbackTransaction();
				return false;
			}
		}

		/// <summary>
		/// Saves a document
		/// </summary>
		/// <param name="area">The area</param>
		/// <param name="field">The field</param>
		/// <param name="file">The file</param>
		/// <returns>True if successful</returns>
		public bool SaveDocument(string area, string field, DBFile file)
		{
			bool success = false;
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();

			List<KeyValuePair<string, CSGenio.framework.Field>> fields = DbArea.GetInfoArea(baseklass.Alias).DBFields.Where(x => x.Value.FieldType.Equals(FieldType.FICHEIRO_BD)).ToList();

			if (fields.Exists(x => x.Key.ToLower() == field))
			{
				if (file != null)
				{
					try
					{
						sp.openTransaction();
						if (!String.IsNullOrEmpty(baseklass.returnValueField(baseklass.Alias + "." + field + "fk").ToString()))
							baseklass.removeDocums(sp, field);
						baseklass.insertNameValueFileDB(field, file.File, file.Name + "_", "", sp, file.Version, null);
						baseklass.updateDirect(sp);
						sp.closeTransaction();
                        success = true;
					}
					catch (System.Exception ex)
					{
						sp.rollbackTransaction();
						Log.Error("Error saving document: " + ex);
					}
				}
			}

			return success;
		}

		/// <summary>
		/// Deletes a document
		/// </summary>
		/// <param name="field">The field name that holds the docum name</param>
		/// <returns>True if successful</returns>
		public bool DeleteDocument(string field)
		{
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			field = field.Substring(0, 3).ToLower() == "val" ? field.Substring(3).ToLower() : field.ToLower();
			bool varOk = false;

			if (!String.IsNullOrEmpty(baseklass.returnValueField(baseklass.Alias + "." + field + "fk").ToString()))
			{
				// [RC] 06/06/2017 We must catch exceptions here, so we can rollback the transaction
				try
				{
					sp.openTransaction();

					if (baseklass.removeDocums(sp, field))
					{
						baseklass.updateDirect(sp);
						varOk = true;
					}

					sp.closeTransaction();
				}
				catch (System.Exception ex)
				{
					sp.rollbackTransaction();
					throw new BusinessException("Não foi possível apagar o documento.", "ModelBase.DeleteDocument", "Error deleting document: " + ex, ex);
				}
			}

			return varOk;
		}

		/// <summary>
		/// Sets all foreign keys for the nextLevel.
		/// Iterate and fill all foreign keys of this table, with history values.
		/// </summary>
		/// <param name="navigation">Navigation Context</param>
		/// <param name="level">History Level</param>
		/// <param name="changeHistory">Permitir change o Historial (no reload dos dbedits e dependentes é false)</param>
		/// <param name="allowNull">Permitir override do Qvalue na ficha com Null do Historial</param>
		/// <param name="allowOverrideComputed">Permite override do valor da ficha dos campos com formulas. Só deve ser usado nos casos como Reload do DBEdit content, para aplicar novo limite e não ter enviar e calcular a ficha inteira</param>
		public void LoadKeysFormHistory(NavigationContext navigation, int level, bool changeHistory = true, bool allowNull = false, bool allowOverrideComputed = false)
		{
			var allowOverrideMode = new object[] { FormMode.New, FormMode.Edit, FormMode.Duplicate };
			var allowOverride = allowOverrideMode.Contains(navigation.CurrentLevel.FormMode);
			LoadKeysFormHistory(navigation, level, changeHistory, allowNull, allowOverride, allowOverrideComputed);
		}

		/// <summary>
		/// Sets all foreign keys for the nextLevel.
		/// Iterate and fill all foreign keys of this table, with history values.
		/// </summary>
		/// <param name="navigation">Navigation Context</param>
		/// <param name="level">History Level</param>
		/// <param name="changeHistory">Permitir change o Historial (no reload dos dbedits e dependentes é false)</param>
		/// <param name="allowNull">Permitir override do Qvalue na ficha com Null do Historial</param>
		/// <param name="allowOverride">Permitir override do Qvalue que vem da BD com o Qvalue do Historial</param>
		/// <param name="allowOverrideComputed">Permite override do valor da ficha dos campos com formulas. Só deve ser usado nos casos como Reload do DBEdit content, para aplicar novo limite e não ter enviar e calcular a ficha inteira</param>
		public void LoadKeysFormHistory(NavigationContext navigation, int level, bool changeHistory, bool allowNull, bool allowOverride, bool allowOverrideComputed)
		{
			if (baseklass.ParentTables == null) // Caso da table PSW
				return;

			foreach (var tblMae in baseklass.ParentTables)
			{
				string areaToLoad = tblMae.Value.AliasTargetTab;
				if (!tblMae.Key.Equals(areaToLoad))
					continue;

				//Value da BD
				string Qfield = tblMae.Value.AliasSourceTab + "." + tblMae.Value.SourceRelField;
				string fieldValue = baseklass.returnValueField(Qfield).ToString();
				bool isEmptyVal = GlobalFunctions.emptyG(fieldValue) == 1;

				var isComputedField = false;
				if (!allowOverrideComputed)
				{
					if (baseklass.RelatedSumFields != null)
						isComputedField = baseklass.RelatedSumFields.Contains(tblMae.Value.SourceRelField);

					if (baseklass.LastValueFields != null && !isComputedField)
						isComputedField = baseklass.LastValueFields.Contains(tblMae.Value.SourceRelField);

					if (baseklass.CheckTableFields != null && !isComputedField)
						isComputedField = baseklass.CheckTableFields.Contains(tblMae.Value.SourceRelField);

					if (baseklass.EndofPeriodFields != null && !isComputedField)
						isComputedField = baseklass.EndofPeriodFields.Contains(tblMae.Value.SourceRelField);

					if (baseklass.InternalOperationFields != null && !isComputedField)
						isComputedField = baseklass.InternalOperationFields.Contains(tblMae.Value.SourceRelField);
				}

				//Value do Hist
				object hValue = null;
				bool hasKey = navigation.CheckKey(areaToLoad, out hValue, level);
				bool isEmptyHistVal = GlobalFunctions.emptyG(hValue) == 1;

				// skip if unable to find a single value for this key
				if (hValue is Array)
				{
					// check if the value is filled and does not invalidate the EPH
					if (!string.IsNullOrEmpty(fieldValue) && !Array.Exists<string>((string[])hValue, el => el == fieldValue))
					{
						object emptyVal = "";
						if (baseklass.DBFields.ContainsKey(tblMae.Value.SourceRelField))
							emptyVal = baseklass.DBFields[tblMae.Value.SourceRelField].GetValorEmpty();

						// clear the field with invalid value - might have been filled by a default/formula
						baseklass.insertNameValueField(Qfield, emptyVal);
					}

					continue;
				}

				//Overide do Qvalue da BD com Qvalue do Hist
				if (isEmptyVal && hasKey && !isEmptyHistVal && !isComputedField) //Se o Qvalue não for preenchido na BD e existir no Hist
					baseklass.insertNameValueField(Qfield, Convert.ToString(hValue));
				else if (((allowNull && !isEmptyVal && hasKey && hValue == null)
					|| (allowOverride && !isEmptyVal && hasKey)) && !isComputedField) //Override do Qvalue que vem da BD com o Qvalue do Historial
					baseklass.insertNameValueField(Qfield, hValue);
				else if (!isEmptyVal && changeHistory) //Preenche o Hist com Qvalue da BD
					navigation.SetValue(areaToLoad, fieldValue, level);
			}
		}

		/// <summary>
		/// Check table permissions
		/// </summary>
		/// <param name="mode">Form mode</param>
		/// <returns></returns>
		public bool CheckTablePremissions(FormMode mode)
		{
			bool status = false;

			switch (mode)
			{
				case FormMode.List:
				case FormMode.Show:
					status = baseklass.AccessRightsToConsult();
					break;
				case FormMode.New:
				case FormMode.Duplicate:
					status = baseklass.AccessRightsToCreate();
					break;
				case FormMode.Edit:
					status = baseklass.accessRightsToChange();
					break;
				case FormMode.Delete:
					status = baseklass.accessRightsToDelete();
					break;
				default:
					throw new FrameworkException("FormMode not implemented.", "CheckTablePremissions", "FormMode not implemented: " + mode);
			}

			return status;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			var user = UserContext.Current.User;
			var ps = UserContext.Current.PersistentSupport;
			return this.baseklass.EvaluateCrudConditions(ps, user, type);
		}

		public string GetTicketForDocField(string field)
		{
			string modelName = this.GetType().Name;

			Type type = this.GetType();
			string fileName = type.GetProperty(field).GetValue(this, null) as string;

			PropertyInfo[] infos = type.GetProperties();

			var pk = "";
			foreach (var fi in infos)
				if (fi.IsDefined(typeof(KeyAttribute), true))
					pk = fi.GetValue(this, null).ToString();

			ResourceQuery rec = new ResourceQuery(fileName, modelName.ToLower(), field, "", pk);
			return QResources.CreateTicketEncryptedBase64(UserContext.Current.User.Name, UserContext.Current.User.Location, rec);
		}

		/// <summary>
		/// MH - tentar obter FK to table do Dependente
		/// </summary>
		/// <param name="alias"></param>
		/// <param name="alternativeAlias">Será usado quando o form não tem DB ou DL to area do F2 ou FM, mas tem ligação direta com area (CE)</param>
		/// <returns>Value da key</returns>
		public string TryGetForeignKey(string alias, string alternativeAlias = null)
		{
			dynamic areaFK = this;
			foreach (CSGenio.framework.Relation rel in baseklass.Information.GetRelations((String.IsNullOrEmpty(alternativeAlias) ? alias : alternativeAlias)))
			{
				areaFK = areaFK.GetType().GetProperty(CSGenio.framework.StringUtils.CapFirst(rel.AliasTargetTab)).GetValue(areaFK, null);
				if (areaFK == null)
					return null;
				if (rel.AliasTargetTab == (String.IsNullOrEmpty(alternativeAlias) ? alias : alternativeAlias))
				{
					if (String.IsNullOrEmpty(alternativeAlias))
						return areaFK.GetType().GetProperty("Val" + CSGenio.framework.StringUtils.CapFirst(rel.TargetRelField)).GetValue(areaFK, null);
					else
						return areaFK.TryGetForeignKey(alias);
				}
			}

			return null;
		}

		/// <summary>
		/// Recalculate formulas of the area. (++, CT, CS, SR, CL and U1)
		/// </summary>
		/// <param name="model">Current form data</param>
		/// <returns></returns>
		public Dictionary<string, object> RecalculateFormulas()
		{
			UserContext.Current.PersistentSupport.openConnection();
			baseklass.fillInternalOperations(UserContext.Current.PersistentSupport, null);
			UserContext.Current.PersistentSupport.closeConnection();

			// Return only fields with formulas
			var fields = new List<string>();
			if (baseklass.ReplicaFields != null)
				fields.AddRange(baseklass.ReplicaFields);
			if (baseklass.CheckTableFields != null)
				fields.AddRange(baseklass.CheckTableFields);
			if (baseklass.RelatedSumFields != null)
				fields.AddRange(baseklass.RelatedSumFields);
			if (baseklass.LastValueFields != null)
				fields.AddRange(baseklass.LastValueFields);
			if (baseklass.AggregateListFields != null)
				fields.AddRange(baseklass.AggregateListFields);

			var res = new Dictionary<string, object>();
			foreach (var field in fields)
			{
				var fullFieldName = baseklass.Alias.ToLowerInvariant() + "." + field;
				var value = baseklass.returnValueField(fullFieldName);
				if (value is DateTime && (DateTime)value == DateTime.MinValue)
					res[fullFieldName] = string.Empty;
				else
					res[fullFieldName] = value;
			}

			return res;
		}

		/// <summary>
		/// Backup fields that are formula aggregated like SR, UV, etc
		/// </summary>
		/// <returns>A dictionary will all the currrent values of these kinds of calculated fields</returns>
		public Dictionary<string, object> BackupAgregationFields()
		{
			var fields = new List<string>();
			if (baseklass.RelatedSumFields != null)
				fields.AddRange(baseklass.RelatedSumFields);
			if (baseklass.LastValueFields != null)
				fields.AddRange(baseklass.LastValueFields);
			if (baseklass.AggregateListFields != null)
				fields.AddRange(baseklass.AggregateListFields);

			var backupFields = new Dictionary<string, object>();
			foreach (var field in fields)
			{
				var fullFieldName = baseklass.Alias + "." + field;
				backupFields[fullFieldName] = baseklass.returnValueField(fullFieldName);
			}

			return backupFields;
		}

		/// <summary>
		/// Overwrites a list of previously memorized values to the current model values
		/// </summary>
		/// <param name="fields">The list of fields and their values to overwrite</param>
		public void MergeFields(Dictionary<string, object> fields)
		{
			foreach (var bakField in fields)
				baseklass.insertNameValueField(bakField.Key, bakField.Value);
		}

		/// <summary>
		/// Finds a row by its primary key
		/// </summary>
		/// <typeparam name="A">Class of row to find</typeparam>
		/// <param name="id">The value of the primary key</param>
		/// <param name="userCtx">User context</param>
		/// <param name="identifier">Interface indentifier</param>
		/// <param name="fieldsToQuery">Fields that need to be queried to the database</param>
		/// <returns>The row found or null otherwise</returns>
		public static A Find<A>(string id, UserContext userCtx, string identifier = null, string[] fieldsToQuery = null) where A : CSGenio.business.Area
		{
			if (string.IsNullOrEmpty(id))
				return null;

			AreaInfo info = CSGenio.business.Area.GetInfoArea<A>();
			CriteriaSet args = CriteriaSet.And();
			args.Equal(info.Alias, info.PrimaryKeyName, id);

			User u = (userCtx ?? UserContext.Current)?.User;
			CriteriaSet ephCriteria = AddEPH<A>(ref u, null, identifier);

			if (!(ephCriteria is null))
			{
				CriteriaSet ephOrZzstate = new CriteriaSet(CriteriaSetOperator.Or);
				ephOrZzstate.Equal(info.Alias, "zzstate", 1);
				ephOrZzstate.SubSet(ephCriteria);
				args.SubSet(ephOrZzstate);
			}

			var sp = (userCtx ?? UserContext.Current)?.PersistentSupport;
			//turns out this part needs to be called by reflection unfortunately, because searchListWhere is generated differently
			//for manual tables that are not Db persisted. Calling the searchListWhere directly on the sp is not equivalent.
			var method = typeof(A).GetMethod("searchList", new Type[] { typeof(PersistentSupport), typeof(User) , typeof(CriteriaSet) , typeof(string[]) , typeof(bool) , typeof(bool) });
			if (method == null)
				return null;
			var pos = method.Invoke(null, new object[] { sp, u, args, fieldsToQuery, false, true }) as List<A>;

			if (pos.Count == 0)
				return null;

			return pos[0];
		}

		/// <summary>
		/// Finds rows that obey to a criteria
		/// </summary>
		/// <typeparam name="A">Class of rows to find</typeparam>
		/// <param name="distinct">Does it perform a distict operation</param>
		/// <param name="args">Criteria for the search</param>
		/// <param name="fields">Fields that we want to retrieve from the database</param>
		/// <param name="offset">Pagination offset</param>
		/// <param name="numRegs">Pagination size</param>
		/// <param name="sorts">Fields the result should be sorted by</param>
		/// <param name="identifier">Interface indentifier</param>
		/// <param name="noLock">True if dirty reads are allowed</param>
		/// <param name="getTotal">True if we want to retreive a total record found value that ignores the pagination</param>
		/// <param name="selectrow">Primary key of a row to highlight</param>
		/// <param name="PagingPosEPHs">EPH positioning data</param>
		/// <param name="firstVisibleColumn">First visible column</param>
		/// <returns>A listing containing all the rows and information retrieved</returns>
		public static ListingMVC<A> Where<A>(bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null) where A : CSGenio.business.Area		
		{
			return Where<A>(UserContext.Current, distinct, args, fields, offset, numRegs, sorts, identifier, noLock, getTotal, selectrow, PagingPosEPHs, firstVisibleColumn);
		}

		public static ListingMVC<A> Where<A>(UserContext ctx, bool distinct, CriteriaSet args = null, Quidgest.Persistence.FieldRef[] fields = null, int offset = 0, int numRegs = 0, List<ColumnSort> sorts = null, string identifier = null, bool noLock = true, bool getTotal = false, string selectrow = "", CriteriaSet PagingPosEPHs = null, Quidgest.Persistence.FieldRef firstVisibleColumn = null) where A : CSGenio.business.Area
		{
			User u = ctx.User;
			PersistentSupport sp = ctx.PersistentSupport;

			//EPH
			args = AddEPH<A>(ref u, args, identifier);

			// `sorts` may arrive null.
			if (sorts == null)
				sorts = new List<ColumnSort>();

			// No user-selected sorting method
			if (!sorts.Any())
			{
				// Condition for field type added because sorting by an image field causes an error
				if (firstVisibleColumn != null
					&& CSGenio.business.Area.GetFieldInfo(firstVisibleColumn).FieldType != FieldType.IMAGEM_JPEG
					&& CSGenio.business.Area.GetFieldInfo(firstVisibleColumn).FieldType != FieldType.GEOGRAPHY
					&& CSGenio.business.Area.GetFieldInfo(firstVisibleColumn).FieldType != FieldType.GEO_SHAPE)
				{
					ColumnSort sortFirstVisibleColumn = new ColumnSort(new ColumnReference(firstVisibleColumn), SortOrder.Ascending);
					sorts.Add(sortFirstVisibleColumn);
				}
			}

			if(!distinct)
			{
				//< Make sure at least one of the fields or combination of fields is unique
				bool hasUniqueField = false;
				AreaInfo areaInfo = CSGenio.business.Area.GetInfoArea<A>();

				// Iterate a copy of the sorts because fields can be added to sorts during this
				List<ColumnSort> originalSorts = new List<ColumnSort>(sorts);
				foreach (ColumnSort sort in originalSorts)
				{
					// Check if this field is unique
					ColumnReference sortColumnReference = (ColumnReference)sort.Expression;
					Field field = CSGenio.business.Area.GetFieldInfo(new Quidgest.Persistence.FieldRef(sortColumnReference.TableAlias, sortColumnReference.ColumnName));
					if (
						// Field has unique property
						field.NotDup
						// Field is the table's primary key
						|| (field.Alias != null && field.Alias.Equals(areaInfo.Alias) && field.Name != null && field.Name.Equals(areaInfo.PrimaryKeyName))
						// Field is a sequential
						|| (areaInfo.SequentialDefaultValues != null && areaInfo.SequentialDefaultValues.Contains(field.Name))
					)
						hasUniqueField = true;

					// If field has a "prefix to be unique" field, add it to the ordering
					if (!string.IsNullOrEmpty(field.PrefNDup))
					{
						ColumnReference prefixColumnRef = new ColumnReference(field.Alias, field.PrefNDup);
						ColumnSort prefixColumnSort = new ColumnSort(prefixColumnRef, SortOrder.Ascending);
						if(!sorts.Contains(prefixColumnSort))
							sorts.Add(prefixColumnSort);
					}

					// If the field is a "prefix to be unique" field, add its corresponding unique field to the ordering
					if (!string.IsNullOrEmpty(field.SufNDup))
					{
						ColumnReference suffixColumnRef = new ColumnReference(field.Alias, field.SufNDup);
						ColumnSort suffixColumnSort = new ColumnSort(suffixColumnRef, SortOrder.Ascending);
						if (!sorts.Contains(suffixColumnSort))
							sorts.Add(suffixColumnSort);
						hasUniqueField = true;
					}
				}

				// If ordering does not have a unique column or combination of columns, add the primary key column
				// to keep the order of records consistent
				if (!hasUniqueField)
				{
					ColumnSort pkColumnSort = new ColumnSort(new ColumnReference(areaInfo.Alias, areaInfo.PrimaryKeyName), SortOrder.Ascending);
					sorts.Add(pkColumnSort);
				}
				//> Make sure at least one of the fields or combination of fields is unique
			}

			ListingMVC<A> listing = new ListingMVC<A>(fields, sorts, offset, numRegs, distinct, u, noLock, identifier, getTotal, selectrow, PagingPosEPHs);

			//turns out this part needs to be called by reflection unfortunately, because searchListWhere is generated differently
			//for manual tables that are not Db persisted. Calling the searchListAdvancedWhere directly on the sp is not equivalent.
			var method = typeof(A).GetMethod("searchListAdvancedWhere", BindingFlags.Public | BindingFlags.Static);
			if (method == null)
				return listing;
			method.Invoke(null, new object[] { sp, u, args, listing });

			return listing;
		}

		/// <summary>
		/// Finds rows that obey to a criteria
		/// </summary>
		/// <typeparam name="A">Class of rows to find</typeparam>
		/// <param name="args">Criteria for the search</param>
		/// <returns>A listing containing all the rows and information retrieved</returns>
		public static ListingMVC<A> All<A>(CriteriaSet args = null) where A : CSGenio.business.Area
		{
			return All<A>(UserContext.Current, args);
		}

		public static ListingMVC<A> All<A>(UserContext ctx, CriteriaSet args = null) where A : CSGenio.business.Area
		{
			return Where<A>(ctx, false, args, numRegs: -1);
		}
	}
}
