/***********************
*  Client persistence  *
***********************/
// File with important functions for the proper function of the modal form support
// Dependencies:
// - jQuery
//
// To enable add the action remove persistence from a button or a link add the attribute "data-end-pers" to the button or anchor element
//
// Structure of the saved information:
// 		LocalStorage
//			|
//			----> "savedInfo" |----> area1: {
//												PrimaryKey: { value: xxxx , form: xxxx },
//												ValFld1: { value: xxxx , form: xxxx },
//												ValFld2: { value: xxxx , form: xxxx },
//												...,
//												ValFldN: { value: xxxx , form: xxxx }
//											}
//						  	  |----> area2: ...
//						  	  |----> ...
//						      |----> areaN: ...
//							  NOTE: All saved as JSON string
//
// For an input to be considered to be saved, it must have the following attributes:
// 		"pers-cs-area" - field's area - mandatory to all fields
//		"pers-cs-field" - field's name - mandatory to all fields
//		Date specific attributes:
// 			"data-format" - the format of the date field, in which is supposed to be saved
//		Array specific attributes:
//			"data-is-array" - marks that the field corresponds to an array
//		DBedit specific attributes:
//			"data-main-field" - the fullname of the field in the database (includes the table name)
//			"data-selected-from-history" - used on dbedits and contains the id of a new created element for that dbedit
//		Number specific attributes:
//			"data-val-number" - indicates that the field is a number
//			"data-decimal-sep" - the decimal separator for number
//
// Fields with formulas must not be persisted. These fields requires constant evaluation, or either by the server, or by its formula


(function ($) {

	// Inits the persistence, by adding actions to click events for links and buttons.
	// Also tries to load any existent saved form.
	function callbackClickPersistence() {
		var form = $(this).parents("[area]").first();
		//JGF 2021.02.01 Buttons that redirect for example should be ignored
		if ($(this).attr('ignore-pers'))
			return;

		if ($(this).data("end-pers"))
			return $.localStorageFormRemove(form);
		else
			return $.localStorageFormSave(form);
	}

	function initPersistence(target) {
		// Do not associate persistence to links that will update a div (p.e: div of an extended support form)
		$("a, button", target)
			.not("[data-ajax]")/* <- The Insert button of Table list with extended support form is ignored. TODO: Why ? */
			.off('click', callbackClickPersistence)
			.click(callbackClickPersistence);

		// Also load the saved form if any
		LoadForm(target);
	}

	function _localStorageFormRemove(storage, formName, formPrimaryKey)
	{
		let tableNames = Object.keys(storage),
			formKeysDataId = 'QForm_'+ formName + '_SavedKeys',
			navLevel = Number.parseInt($('#CurrentHistoryLevel[data-interface-id="' + formName + '"]').val() || -1);

		tableNames.forEach(function(tableName) {
			let keys = Object.keys(storage[tableName]);

			keys.forEach(function(key) {
				let fieldNames = Object.keys(storage[tableName][key]);

				fieldNames.forEach(function(fieldName) {
					if(storage[tableName][key][fieldName].form === formName || (navLevel !== -1 && +storage[tableName][key][fieldName].level > navLevel))
						delete storage[tableName][key][fieldName];
				});

				if(Object.keys(storage[tableName][key]).length === 0)
					delete storage[tableName][key];
			});

			if(Object.keys(storage[tableName]).length === 0)
				delete storage[tableName];
		});

		delete (storage[formKeysDataId] || {})[formPrimaryKey];

		return storage;
	}

	// Deletes from "savedInfo" in the localStorage the information about the saved form
    $.localStorageFormRemove = function (form) {
		let qForm = $(form).getQForm(),
			formPrimaryKey = qForm ? qForm.PrimaryKey.Value : null,
			formName = $(form).data("form");
		if(formName) {
			let storage = QLocalStorage.getLocalStorage("savedInfo");
			storage = _localStorageFormRemove(storage, formName, formPrimaryKey);
			QLocalStorage.setLocalStorage("savedInfo", storage);
			ClearLastTab(formName);
		}
    };

    $.GetLastTab = function (formName) {
        return QLocalStorage.getLocalStorage("LastTabSelected")[formName] || "";
    };

    $.SetLastTab = function (formName, tab) {
        let lastTab = QLocalStorage.getLocalStorage("LastTabSelected");
        lastTab[formName] = tab;        
        QLocalStorage.setLocalStorage("LastTabSelected", lastTab);
    };
    
    function ClearLastTab(formName) {
        var lastTab = QLocalStorage.getLocalStorage("LastTabSelected");
		delete lastTab[formName];
		QLocalStorage.setLocalStorage("LastTabSelected", lastTab);
    }

	// Saves the current form into "savedInfo" in the localStorage
    $.localStorageFormSave = function (target) {
        let deferred = $.Deferred(),
			qForm = $(target).getQForm();

		// Save the main form instead of the multiform
		if(qForm && qForm.Type === window.QFormType.MULTIFORM)
			qForm = qForm.element.parent().closest('[data-form]').getQForm();

		if(qForm && qForm.Type === window.QFormType.FORM)
		{
			let storage = QLocalStorage.getLocalStorage("savedInfo"),
				formName = qForm.element.data('form'),
				formRelationTable = Object.keys(qForm.Data.RelationKeysSelector),
				formKeys = { },
				formKeysDataId = 'QForm_'+ formName + '_SavedKeys',
				pseudAreaId = (qForm._formVariableName + '_' + 'pseud').toLowerCase(),
				navLevel = Number.parseInt($('#CurrentHistoryLevel[data-interface-id="' + formName + '"]').val() || -1),
				formPrimaryKey = qForm.PrimaryKey.Value;
			// Remove previously saved data
			storage = _localStorageFormRemove(storage, formName);

			// Foreign keys
			formRelationTable.forEach(function(relTableName) {
				let qFKControl = qForm.getRelationKeyControl(relTableName) || {};
				formKeys[relTableName] = { original: qFKControl.renderedValue, value: qFKControl.Value };
			});

			// Save the FK's
			storage[formKeysDataId] = {};
			storage[formKeysDataId][formPrimaryKey] = formKeys;

			// Base area key
			formKeys[qForm.baseArea] = { original: formPrimaryKey, value: formPrimaryKey };
			formKeys[pseudAreaId] = { original: formPrimaryKey, value: formPrimaryKey };

			$.each(qForm.Controls, function(_, qControl) { 
				try {
					let area = qControl.element.attr("pers-cs-area"),
						field = qControl.element.attr("pers-cs-field");

					if(qControl instanceof QImageControl) // The image field saves the data directly to the database
						return true;
					else if(qControl instanceof QCheckListControl) { // DV & DW
						area = pseudAreaId;
						field = qControl.element.attr('id');
					}

					if(area !== undefined && field !== undefined) {
						area = area.toLowerCase();
						let areaKey = formKeys[area].value;

						if(typeof areaKey === 'string')
						{
							if(storage[area] === undefined)
								storage[area] = {};

							if(storage[area][areaKey] === undefined)
								storage[area][areaKey] = {};

							let fieldValue = qControl.Value;
							let originalValue = qControl.renderedValue;
							if (typeof (fieldValue || {}).toQString === 'function')
								fieldValue = fieldValue.toQString();

							// fields from another form cannot be updated
							if(storage[area][areaKey][field] === undefined || storage[area][areaKey][field].form === formName)
								storage[area][areaKey][field] = { value: fieldValue, original: originalValue, form: formName, level: navLevel };
						}
					}
				}
				catch(e) {
					console.error('Error writing the form control to storage', qControl.controlIdentifier);
				}
			});

			QLocalStorage.setLocalStorage("savedInfo", storage);

			deferred.resolve(true);
		}
		else
			deferred.resolve(false);

        return deferred.promise();
	}

	// Loads the values for the given form
	function LoadForm(target) {
		let qForm = $(target).getQForm();

		if(qForm) 
		{
			try {
				let storage = QLocalStorage.getLocalStorage("savedInfo"),
					formName = qForm.element.data('form'),
					formRelationTable = Object.keys(qForm.Data.RelationKeysSelector),
					formKeys = { },
					formKeysDataId = 'QForm_'+ formName + '_SavedKeys',
					formPrimaryKey = qForm.PrimaryKey.Value,
					pseudAreaId = (qForm._formVariableName + '_' + 'pseud').toLowerCase(),
					navLevel = Number.parseInt($('#CurrentHistoryLevel[data-interface-id="' + formName + '"]').val() || -1);

				// Get current foreign keys
				// If any key was removed from the history, use the one currently on the form.
				formRelationTable.forEach(function(relTableName) {
					formKeys[relTableName] = qForm.Data.RelationKeys[relTableName];
				});
				// Base area key
				formKeys[qForm.baseArea] = formPrimaryKey;
				formKeys[pseudAreaId] = formPrimaryKey;

				// Load all saved FK's of this form and update controls
				formRelationTable.forEach(function(relTableName) {
					let savedFK = ((storage[formKeysDataId] || {})[formPrimaryKey] || {})[relTableName];
					// fields that has different original data (database) will not changed.
					let fkSelector = qForm.Data.RelationKeysSelector[relTableName];
					if(savedFK && fkSelector.getQControl) {
						let qFKControl = fkSelector.getQControl();
						if(qFKControl !== undefined && qFKControl.renderedValue === savedFK.original)
						{
							qForm.Data.RelationKeys[relTableName] = savedFK.value;
							formKeys[relTableName] = savedFK.value;
						}
					}
				});

				$.each(qForm.Controls, function(_, qControl) {
					try {
						// Fields with formulas should be refreshed by the server
						if (qControl.element.data("refresh") == true && qControl.element.data("tipoform") != "DG" && qControl.element.data("tipoform") != "DF")
							return true;

						let area = qControl.element.attr("pers-cs-area"),
						field = qControl.element.attr("pers-cs-field");

						if(qControl instanceof QImageControl) // The image field saves the data directly to the database
							return true;
						else if(qControl instanceof QCheckListControl) { // DV & DW
							area = pseudAreaId;
							field = qControl.element.attr('id');
						}

						if(area !== undefined && field !== undefined) {
							area = area.toLowerCase();
							let areaKey = formKeys[area];

							if(typeof areaKey === 'string')
							{
								let objData = ((storage[area] || {})[areaKey] || {})[field];
								if(objData && objData.level <= navLevel) {
									// fields that has different original data (database) will not changed.
									if (qControl.renderedValue == objData.original)
										qControl.Value = objData.value;

									if(qControl instanceof QDbeditControl)
									{
										let textField = qControl.element.data("main-field").split(".")[1];
										if(((storage[area] || {})[areaKey] || {})[textField])
										{
											let textValue = storage[area][areaKey][textField].value,
												currentTextIsEmpty = (qControl.Text === '' || qControl.Text === null);
											if(currentTextIsEmpty || (!currentTextIsEmpty && qControl.Text !== textValue))
												qControl.Text = textValue;
										}
									}
									else if (qControl instanceof QRichTextControl) {
										qControl.Value = objData.value;
										// Update rendered html in case TinyMCE is not loaded yet
										const nameIdentifier = '[name="' + qControl.fieldName + '"]';
										$(qControl.element).find(nameIdentifier).html(objData.value);
									}
								}
							}
						}
					}
					catch(e) {
						console.error('Error reading the form control from storage', qControl.controlIdentifier);
					}
				});
				if(qForm && qForm.persistenceLoadPromise)
					qForm.persistenceLoadPromise.resolve(true);
			}
			catch(e) {
				if(qForm && qForm.persistenceLoadPromise)
					qForm.persistenceLoadPromise.resolve(false);
			}
		}
	}

	$.localStorageFormLoad = function (target) {
		LoadForm(target);
	}
	
    $.ClientSidePersistence = function (target) {
		initPersistence(target)
    }
})(jQuery);
