//---------------------------------------------
//Form
//---------------------------------------------
window.QFormType = Object.freeze({ FORM: "F", MULTIFORM: "MF", MENU: "M" });
window.QFormMode = Object.freeze({ show: 'show', delete: 'delete', new: 'new', edit: 'edit', duplicate: 'duplicate' });
//---------------------------------------------
function QForm(element, formVarName) {
    var _thisQForm = this;
    //base area of the form
    this.baseArea = "";
    //data
    this.Data = { RelationKeys: { }, RelationKeysSelector: {} };
    this.persistenceLoadPromise = false;
    // Stack of requests to be executed
    this.requestStack = [];
    //underlying element of the form
    this.element = element;
    this.elementId = element.prop('id');
    //reference to QForm
    this._formVariableName = formVarName;
    if (this._formVariableName !== undefined) {
        $(this.element).attr("QForm", this._formVariableName);
        $(this.element).data("QForm", this._formVariableName);
    }
    //Form URL's
    this.formSaveEdit = "";
    this.formAction = "";
    this.formRedirectURL = "";
    this.formSubmitURL = "";

    this.Type = QFormType.FORM;
    this.isInitialized = false;
	this.ignoreDirty = false;
    
    /**
     * While a submission (e.g. Save or Cancel) is being executed, it is disabled to prevent more than one request from being made at the same time. 
     * This prevents the history from having incorrect levels.
     */
    this.submissionDisabled = false;

    // Form loaded attribute - for web tests
    var getQFormLoaded = function () {
        return $(_thisQForm.element).attr("qform-loaded") || false;
    }, setQFormLoaded = function (val) {
        $(_thisQForm.element).attr("qform-loaded", val);
    };
    Object.defineProperty(_thisQForm, 'qFormLoaded', { get: getQFormLoaded, set: setQFormLoaded });
    _thisQForm.qFormLoaded = false;

    $(_thisQForm.element).on('CHECK_QFORM_LOADED', _thisQForm, function (event) {
        var _thisQForm = event.data;
        //console.log("check form loaded", _thisQForm);
        _thisQForm.qFormLoaded = $(_thisQForm.element).find('[qcontrol-loaded="false"]').length == 0;
    });

    //field register
    this.Fields = {};
    //controls register
    this.Controls = {};
    //default formulas register
    this._DefaultFormulas = [];
    // cache for the keys selectors
    this._allForeignKeySelectors = null;

    // Form element binding
    this.FormElementBindings = [];

    //Message Queueing
    this.QMsq = new QMsq();

    //events
    this.OnPreValida = function(mode, target) { return true; }
    this.OnBeforeSave = function () { return true; }
    this.OnAfterSave = function () { return true; }

    this.executeAfterSave = false;
};

QForm.prototype = {
    get dirtyControls() {
        var _dirtyControls = [];
        $.each((this.Controls || {}), function (qControlID, qControl) {
            if (qControl.isDirty) {
                _dirtyControls.push(qControl);
            }
        });
        return _dirtyControls;
    },
    get isDirty() {
        return !this.ignoreDirty && this.dirtyControls.length > 0;
    },
    get FormName() {
        return $(this.element).data('form');
    },
    get NavigationId() {
        var _formNavId = $('#CurrentNavigationId[data-interface-id="' + this.FormName + '"]');
        return _formNavId.length !== 1 ? null : _formNavId.val();
    },
    get NavigationLevel() {
        var _formLevel = $('#CurrentHistoryLevel[data-interface-id="' + this.FormName + '"]');
        return _formLevel.length !== 1 ? -1 : _formLevel.val();
    }
};

//------------- Actions ----------------------
QForm.prototype.Init=function() {
    var _thisForm = this;
    if (_thisForm.isInitialized) return;
    _thisForm.isInitialized = true;
    _thisForm._requestNumberRecalculateFormulas = 0;
    _thisForm._allForeignKeySelectors = null;

    // Mark all collapse groups with asterisk if they contains required fields
    $('[elem-identifier="AccordionGroup"]').has('label[data-val-required]').find('a[data-zone-type="ZC"], a[data-zone-type="ZA"]').addClass('contains-val-required');

    $.each($('[elem-identifier="TabbableIdentifier"]'), function (index, value) {
        if ($('#' + value.attributes['data-tab'].value).has('label[data-val-required]').length) {
            $(value).find('a').addClass('contains-val-required');
        }
    });

	$('[elem-identifier="TabbableIdentifier"] > a').on("keydown", function (e) {
        if (e.keyCode == 32) {
            this.click();
        }
    });

    //Só a partir do MVC 5.1 que é suportado htmlAttributes no EditorFor
    replaceIncorrectAttributes($(_thisForm.element));

    // qVar_isControlledRedirect utilizado no onbeforeunload para detetar saida "inesperada" da ficha
    window.qVar_isControlledRedirect = false;

    //Global initializations (review which ones are really global)
    $.ModalForms($(_thisForm.element));

    // Init form modes buttons
    _thisForm.initBtns();

    _thisForm.persistenceLoadPromise = $.Deferred();
    //Controls initialization
    _thisForm.DeclareControls();
    $.each(_thisForm.Controls, function (i, control) {
        if (_thisForm.FormMode === "new" || _thisForm.FormMode === "duplicate") {
            // Desativação das validações nos campo obrigatorios + sequencias
            if (control.isSequencial) {
                //$(control.element).attr('data-val', false);
                $(control.element).removeAttr('data-val-required');
            }
        }
        control._parentForm = _thisForm;
        control.Init();
        if (control.element.is('input[form-area]'))
            _thisForm.PrimaryKey = control;
        control.AttachOnChange();
    });

    if (_thisForm.FormMode === "new" || _thisForm.FormMode === "duplicate") {
        // Reatribuir validações dos campos depois de ter "desativado" validações nos campo obrigatorios + sequencias
        $(_thisForm.element).removeData("validator").removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse($(_thisForm.element));
    }

    // Init custom control
    //  Color Picker
    if($.colorpicker) {
        $(_thisForm.element).find('.colorpicker-component').colorpicker({ format: 'rgb' });
    }

    // Inicialização dos binding sobre element do form
    $.each(_thisForm.FormElementBindings, function (_, bind) {
        $(_thisForm.element).unbind(bind.Events, bind.Func).bind(bind.Events, bind.Func);
    });

    // Inicialização das formulas client-side
    _thisForm.QFormulas();

    //Filling Message Queuing info
    _thisForm.QMsq.Init(_thisForm);

    $.each(_thisForm._DefaultFormulas, function (_, formulaDefault) {
        _thisForm.Controls[formulaDefault.FieldIdentifier].SetFormulaDefault(formulaDefault.Formula, formulaDefault.BindingEvents, formulaDefault.CheckDefaultOnce);
    });

    $.when(_thisForm.persistenceLoadPromise).then(function () {
        /*(async function() {
            for(const fnRequest of _thisForm.requestStack)
                await fnRequest();
        })();*/
        return _thisForm.requestStack.reduce(function (promise, fnRequest) { return promise.then(fnRequest); }, Promise.resolve());
    });

    $.ClientSidePersistence($(_thisForm.element));
    if(_thisForm.persistenceLoadPromise && _thisForm.persistenceLoadPromise.state() !== 'resolved')
        _thisForm.persistenceLoadPromise.resolve(true);

    InitMagnificPopUp();

    //helps
    activateHelps(_thisForm);

    // Synchronize fields values between wizard and main form
    var wizardContainer = $(_thisForm.element).closest('[q-wizard]');
    if (wizardContainer.length === 1) {
        var mainFormOfWizard = wizardContainer.closest('[data-form]'),
            maninQForm = mainFormOfWizard.getQForm();

        // Wizard to Main form
        $(_thisForm.element).off('q-form-field-change-sync').on('q-form-field-change-sync', { qForm: maninQForm }, function (event, eData) {
            $(event.data.qForm.element).trigger('q-form-field-change:' + eData.fullFieldName, eData);
        });

        // Main form to Wizard
        $(maninQForm.element).off('q-form-field-change-sync').on('q-form-field-change-sync', { qForm: _thisForm }, function (event, eData) {
            $(event.data.qForm.element).trigger('q-form-field-change:' + eData.fullFieldName, eData);
        });

        // Copy wizard values to main form
        _thisForm.EmitSyncOfControls();
    }

    // Execute trigger of Form loaded after Initialize chosen's, datePickers and radioButtons.
    // TODO: Need be executed before ClientSidePersistence ??
    $(_thisForm.element).trigger('FORM_LOADED', $(_thisForm.element));
};

QForm.prototype.DeclareControls = function () { };
QForm.prototype.QFormulas = function () { };
QForm.prototype.getAllForeignKeySelectors = function () { return { }; };
QForm.prototype.getRelationKeyControl = function(table) {
    let controlSelector = this.Data.RelationKeysSelector[table];
    return controlSelector !== undefined ? this.Data.RelationKeysSelector[table].getQControl() : undefined;
};

QForm.prototype.ReplaceHTML = function(dataView, replaceAll = true)
{
    var _thisForm = this;
    var newView = $(dataView);

    // TODO: Rever! Pode ser muito perigoso usar First e Last
    var formView = $(newView).first();
    var formJavaScript = $(newView).last();
    if (_thisForm._formVariableName !== undefined)
    {
        $(formView).attr("QForm", _thisForm._formVariableName);
        $(formView).data("QForm", _thisForm._formVariableName);
    }

    // Delete previous saved active element
    var curLocalStorage = QLocalStorage.getLocalStorage('lastActiveElement');
    delete curLocalStorage[newView.data('form')];
    QLocalStorage.setLocalStorage('lastActiveElement', curLocalStorage);

    if (replaceAll)
    {
        // Init new View
        $(_thisForm.element).replaceWith($(formView));
        if (formView && formJavaScript) {
            // Até ter o preenchimento dos campos "automaticamente adicionado" dentro do Init do form, o servidor deve retornar o JS novo.
            $('#FormJavaScript_' + $(formView).data('form').toUpperCase()).replaceWith($(formJavaScript));
        }
        _thisForm.isInitialized = false;
        _thisForm.element = $(formView);

        _thisForm.element.ready(function () {
            var qForm = _thisForm._formVariableName;
            if (qForm !== undefined && window[qForm] !== undefined) {
                var _qForm = window[qForm];
                $.each(_qForm.Controls, function (i, control) {
                    delete control;
                });
                delete _qForm.Controls;
                _qForm.Controls = {};
                _qForm.isInitialized = false;
                _qForm.Init();
            }
        });
    }
    else
    {
        /*
         * [APM] Replacing the whole HTML will cause loss of data from the localStorage (see incidents #PESP2647, #RH67 and #TOP71).
         * If $.localStorageFormSave() was called after ReplaceHTML(), the form's data in the localStorage would be cleared.
         * When all we want is to show the validation errors, there's no need to replace the HTML of the entire form.
         *
         * Doing this will add an additional problem though, the MANWINs "BEFORE_LOAD_EDIT_EX" and "AFTER_LOAD_EDIT_EX" in
         * GenericHandlePostFormEdit() will become useless (they already are in VueJS), so they need to either be removed or refactored.
         */
        
        // Validation errors
        $(_thisForm.element).find('.validation-summary-errors').remove();
        $(_thisForm.element).prepend($(dataView).find('.validation-summary-errors'));

        // Validation warnings
        $(_thisForm.element).find('#validation-summary-warnings').remove();
        $(_thisForm.element).prepend($(dataView).find('#validation-summary-warnings'));
    }

    _thisForm.element.ready(function () {
        // Scroll up to show erros
        $('html, body').data('already-animated-scroll', true);
        $('html, body').animate({ scrollTop: 0 }, 'slow');
    });
};

QForm.prototype.Submit = function (repeatInsertion) {
    /**
     * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
     *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
     *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
     *  including corrupting the levels of history.
     */
    if(this.submissionDisabled)
        return;
    this.submissionDisabled = true;

    var _thisForm = this;
    try
    {
        $.when(_thisForm.OnPreValida('SUBMIT', _thisForm), repeatInsertion).then(function (prevalida, repeatInsertion) {
            if (!prevalida) 
            {
                _thisForm.submissionDisabled = false;
                return false;
            }

            $.when(_thisForm.OnBeforeSave(), repeatInsertion).then(function (resBeforeSave, repeatInsertion) {
                var formData = getInputsForNestedForm($(_thisForm.element));
                $.extend(formData, { 'redirect': false });
                var url = _thisForm.formSubmitURL;
                if(repeatInsertion && _thisForm.formSubmitURL_repeatInsertion !== undefined) {
                    url = _thisForm.formSubmitURL_repeatInsertion;
                }

                $.ajax({
                    url: url,
                    cache: false,
                    type: "POST",
                    dataType: "json",
                    data: $.param(formData, true),
                    beforeSend: function() {
                        qAddLoading(1000);
                    },
                    complete: function() {
                        _thisForm.submissionDisabled = false;
                        qRemoveLoading();
                    },
                    success: function (data) {
                        if (data.Success)
                        {
                            $.when(_thisForm.OnAfterSave(data), data).then(function(afterSave, data)
                            {
                                if (afterSave)
                                {
                                    qAddLoading(1000);
                                    _thisForm.Redirect(data, repeatInsertion);
                                }
                            });
                        }
                        else
                        {
                            // If there was an error, we want to keep the values in the storage (they are being removed as soon as the save button is clicked).
                            $.localStorageFormSave($(_thisForm.element));

                            if (data.Message)
                                console.log(data.Message);
                            if (data.View)
                                _thisForm.ReplaceHTML(data.View, false);
                        }

                        return data.Success;
                    }
                });
            }).fail(() => { _thisForm.submissionDisabled = false; });
        }).fail(() => { _thisForm.submissionDisabled = false; });
    } 
    catch (e)
    {
        console.error('Error while submitting the form', e);
        _thisForm.submissionDisabled = false;
    }
};

QForm.prototype.DeleteSubmit = function () {
    /**
     * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
     *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
     *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
     *  including corrupting the levels of history.
     */
    if(this.submissionDisabled)
        return;
    this.submissionDisabled = true;

    var _thisForm = this;
    var url = _thisForm.formSubmitURL;

    try
    {
        $.ajax({
            url: url,
            cache: false,
            type: "POST",
            dataType: "json",
            data: $.param({ id:_thisForm.PrimaryKey.Value}, true),
            beforeSend: function () {
                qAddLoading(1000);
            },
            complete: function () {
                qRemoveLoading();
            },
            error: () => { _thisForm.submissionDisabled = false },
            success: function (data) {
                if (data.Success) {
                    QUtils.NavigateTo = _thisForm.formRedirectURL;
                }
                else {
                    QUtils.WindowReload();
                }
                return data.Success;
            }
        });
    }
    catch (e)
    {
        console.error('Error while deleting the form', e);
        _thisForm.submissionDisabled = false;
    }
};

function SubmitMultipleFormsRegistration(url, mainForm, regForm, helpForm){
    mainForm = $('#' + mainForm);
    regForm = $('#' + regForm);
    helpForm = $('#' + helpForm);

    var formA = getInputsForNestedForm(regForm),
        _formData = getInputsForNestedForm(helpForm),
        capcha = getInputsForNestedForm($('#CaptchaField', mainForm));

    var _fd = {};

    $.each(formA, function (key, value) {
        _fd['model1.' + key] = value;
    });
    $.each(_formData, function (key, value) {
        _fd['model2.' + key] = value;
    });
    $.each(capcha, function (key, value) {
        _fd[key] = value;
    });

    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        dataType: "json",
        data: $.param(_fd, true),
        beforeSend: function () {
            qAddLoading(1000);
        },
        complete: function () {
            qRemoveLoading();
        },
        success: function (data) {
            if (data.Success) {
                location.href = data.Url;
            }
            else {
                if (data.Message) {
                    console.log(data.Message);
                }
                if (data.View) {
                    var _helpForm = window[data.Form];

                    _helpForm.Destroy();
                    $("#TotalRegistration").replaceWith(data.View);

                    $('html, body').data('already-animated-scroll', true);
                    $('html, body').animate({ scrollTop: 0 }, 'slow');
                    // Re inicializar QForm do form de apoio
                }
            }
            return data.Success;
        }

    });
}

QForm.prototype.Redirect = function (data, repeatInsertion) {
    var _thisForm = this;
    var url = _thisForm.formRedirectURL;
    if(repeatInsertion && _thisForm.formRedirectURL_repeatInsertion !== undefined) {
        url = _thisForm.formRedirectURL_repeatInsertion;
    }
    $(_thisForm.element).prop('action', url);
    window.qVar_isControlledRedirect = true;// Required when the Redirect is invoked from manual code.
    $(_thisForm.element)[0].submit();
};

QForm.prototype.Apply = function (showMsg, btn) {
    if (this.formSaveEdit == "") return;
    if (window.event) window.event.preventDefault();
    if (btn && ($(btn).is("button") || $(btn).is("a"))) $(btn).prop('disabled', true);
    var _thisForm = this;
    var formData = getInputsForNestedForm($(_thisForm.element));
    return $.ajax({
        url: this.formSaveEdit,
        data: $.param(formData, true),
        type: "POST",
        beforeSend: function() {
            qAddLoading(1000);
        },
        complete: function() {
            qRemoveLoading();
        },
        success: function (data) {
            if (data.Message) { console.log(data.Message); }
            if (data.Success) {
                if (showMsg && data.Message) { displayMessage(data.Message, MessageDefs.StatusEnum.OK); }
            }
            else {
                if (data.Message) {
                    console.log(data.Message);
                }
                if (data.View) {
                    // Deleting the form data is necessary for this to work properly with wizard forms.
                    delete window['Form_' + _thisForm.elementId];
                    _thisForm.ReplaceHTML(data.View);
                }
            }
            return data.Success;
        }
    }).then(function (data) { return data.Success; }).done(function (isSaved) {
        if (btn && ($(btn).is("button") || $(btn).is("a"))) { $(btn).prop('disabled', false); }
        return isSaved;
    });
};

QForm.prototype.Destroy = function () {
    try {
        $.each(this.Controls, function (i, control) {
            delete control;
        });
        delete this.Controls;
        delete window[this._formVariableName];
    } catch (err) { QError.AppendError('Error on destroy QForm: ' + err.message, err.stack, window.location.href); }
};

QForm.prototype.SetFormulaDefault = function (fieldIdentifier, formula, bindingEvents, checkDefaultOnce) {
    this._DefaultFormulas.push({ FieldIdentifier: fieldIdentifier, Formula: formula, BindingEvents: bindingEvents, CheckDefaultOnce: checkDefaultOnce });
};

QForm.prototype.SetFormBind = function (events, func) {
    this.FormElementBindings.push({ Events: events, Func: func });
    $(this.element).bind(events, func);
};

QForm.prototype.RecalculateFormulas = function () {
    var _this = this;
    var link = _this.UrlAction.RecalculateFormulas;
    var formData = getInputsForNestedForm($(_this.element));
    var logData = {
        start: new Date(),
        formData: formData,
        curReqNum: _this._requestNumberRecalculateFormulas
    };
    return $.ajax({
        type: 'POST',
        headers: { 'RecalculateFormulasRequestNumber': _this._requestNumberRecalculateFormulas += 1 },
        url: link,
        dataType: "json",
        data: $.param(formData, true),
        beforeSend: function() {
            qAddLoading(1000);
        },
        success: function (data, textStatus, request) {
            var requestNumber = request.getResponseHeader('RecalculateFormulasRequestNumber');
            if (requestNumber && requestNumber != _this._requestNumberRecalculateFormulas) {
                return;
            }
            $.extend(logData, {
                data: data,
                end: new Date(),
                curResNum: _this._requestNumberRecalculateFormulas
            });
            // console.warn("RecalculateFormulas - Log", logData);
            if (data.Success) {
                $.each(_this.Controls, function (i, control) {
                    var fieldFullName = control.area + "." + control.field;
                    //Foreign key can be have original field name
                    if (data.Data[fieldFullName] === undefined && control.trelate && control.tfrelate) {
                        fieldFullName = control.trelate + "." + control.tfrelate;
                    }
                    // DBEdit control
                    if (data.Data[fieldFullName] === undefined && control.db_full_field_name) {
                        fieldFullName = control.db_full_field_name;
                    }
                    if (data.Data[fieldFullName] === undefined) { return true; }

                    control.Value = data.Data[fieldFullName];
                });
            }
            else {
                console.error("Error on RecalculateFormulas");
            }
        },
        complete: function() {
            qRemoveLoading();
        },
        traditional: true
    });
};

QForm.prototype.ChangeMode = function (newMode) {
    var _thisForm = this,
        changeFormModeURL = _thisForm.UrlAction.ChangeFormMode + '&mode=' + newMode;

    if (_thisForm.FormMode === QFormMode.new || _thisForm.FormMode === QFormMode.duplicate || _thisForm.submissionDisabled)
        return;

    /**
     * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
     *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
     *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
     *  including corrupting the levels of history.
     */
    _thisForm.submissionDisabled = true;

    try 
    {
        var fContinue = function (result) {
            if (result) {
                // Remove local storage cache
                $.localStorageFormRemove(_thisForm.element);
                var formModal = _thisForm.element.closest('#form-modal'),
                    table = $(formModal).data('reload-table');
                delete window[_thisForm._formVariableName];
                if (formModal.length !== 0) {
                    OpenModalForm(changeFormModeURL, {}, table);
                }
                else { QUtils.NavigateTo = changeFormModeURL; }
            }
            else
                _thisForm.submissionDisabled = false;
        };

        // Confirm
        if (_thisForm.FormMode === QFormMode.edit) {
            displayMessage(quidgestGlobals.Resources.CONFIRM_EXIT_FORM_EDIT.replace('.', '.<br>'), MessageDefs.StatusEnum.Q, undefined,
                [
                    {
                        label: quidgestGlobals.Resources.SAIR,
                        callback: fContinue,
                        icon: "check"
                    },
                    {
                        label: quidgestGlobals.Resources.CANCELAR,
                        callback: () => { _thisForm.submissionDisabled = false; },
                        style: MessageDefs.ButtonTypes.Secondary,
                        icon: "ban-circle"
                    }
                ],
                {
                    onEscapeCallback: () => { _thisForm.submissionDisabled = false; }
                }
            );
        } else {
            fContinue(true);
        }
    }
    catch (e)
    {
        console.error('Error while deleting the form', e);
        _thisForm.submissionDisabled = false;
    }
};

QForm.prototype.initBtns = function () {
    var _this = this,
        formName = _this.element.data('form'),
        sidebarTemplates = $('[data-q-ref="sidebar-templates"]'),
        sidebarTarget = $('[data-q-ref="sidebar-main_container"]'),
        formTarget = $('[data-parent-form="' + formName + '"][data-q-ref="form-btns-main_container"]');

    // Only the Normal and PopUp forms will have quick access buttons
    if ($.isEmptyObject(_this.FormButtons)) return;
    if (_this.element.closest('[elem-identifier="extended-support"]').length !== 0 ||
        _this.element.closest('[elem-identifier="Multiform"]').length !== 0) return;

    // The menus with support form or continuation form in PopUp mode need the tab in the sidebar only when one of the forms is open
    var fnChangeSidebarTabVisibility = function (formName, visible) {
        var sidebarNav = $('#nav-form_mode-tab'),
            sidebarTab = $('#form_mode-tab');

        if(visible) {
            sidebarTab.css('display', '');
            sidebarNav.css('display', '').click();
        }
        else {
            var activeForms = $('[data-form]').not('[data-form="' + formName + '"]');
            // If there are no more active forms then the tab is hidden
            if (activeForms.length === 0 || (activeForms.length === 1 && activeForms.getQForm().Type === QFormType.MENU)) {
                sidebarNav.hide();
                sidebarTab.hide();
                // Position the sidebar on the first active tab
                $('#q-right-sidebar [elem-identifier="sidebar-nav"]:visible:first').click();
            }
        }
    };
    fnChangeSidebarTabVisibility(formName, true);

    // After the popup form is closed the sidebar is re-rendered with the buttons of the active (normal) form or the tab is hidden in the case of menus.
    if (_this.element.closest('#form-modal').length === 0) {
        $(document).off('QFORM_MODAL_CLOSED').on('QFORM_MODAL_CLOSED', { form: _this, formName: formName }, function (event) {
            var _this = event.data.form;
            _this.initBtns();
        });
    }
    else {
        $(document).on('QFORM_MODAL_CLOSED', { form: _this, formName: formName }, function (event) {
            fnChangeSidebarTabVisibility(event.data.formName, false);
        });
    }

    //------------------------------------------------------------------------------------
    // Auxiliary methods for creating the buttons
    //------------------------------------------------------------------------------------
    // -------- Application of active button effect --------
    var fnActiveModeBtn = function (qForm, btnConf, elem) {
        var active = qForm.FormMode === btnConf.mode;
        if (active) {
            elem.addClass('nav-item--active n-sidebar__nav-link--active');
            elem.find('a').addClass('n-sidebar__nav-link--active');
        }
    };
    var fnActiveFModeBtn = function (qForm, btnConf, elem) {
        var active = qForm.FormMode === btnConf.mode;
        if (active) {
            var target = elem.is('[data-q-ref~="btn"]') ? elem : elem.find('[data-q-ref~="btn"]');
            target.remove();
                //.removeClass('b-icon--secondary')
                //.addClass('b-icon--primary');
        }
    };

    var fnActiveRoutineBtn = function (qForm, btnConf, elem) {
        var allowedModes = [QFormMode.new, QFormMode.edit, QFormMode.duplicate]
        var active = $.inArray(qForm.FormMode, allowedModes) !== -1;
        if (!active) {
            elem.find('[data-q-ref~="btn"]')
                .removeClass('b-icon-text--secondary')
                .addClass('b-icon-text--disabled');
        }
    };

    // -------- Initialization of content (Text and Icons) and button events --------
    var fnInitBtnContent = function (qForm, elem, conf, srcBtn, sidebarTemplates) {
        var content = sidebarTemplates
            .find('[data-q-ref="sidebar-btns-content"]')
            .find(conf.content);
        var text = content.data('text'),
            icon = content.data('icon');

        elem.is('[data-q-ref~="text"]') ? elem.append(text) : elem.find('[data-q-ref~="text"]').append(text);
        elem.is('[data-q-ref~="tooltip"]') ? elem.attr('title', text) : elem.find('[data-q-ref~="tooltip"]').attr('title', text);
        elem.is('[data-q-ref~="icon"]') ? elem.addClass(icon) : elem.find('[data-q-ref~="icon"]').addClass(icon);
        //All these buttons either redirect their actions or ensure the persistance themselves
        elem.attr("ignore-pers", true);
    };

    var fnInitModeBtn = function (qForm, elem, conf, srcBtn, sidebarTemplates) {
        fnInitBtnContent(qForm, elem, conf, srcBtn, sidebarTemplates);
        elem.find('a, button').off('click');
        elem.off('click').click({ form: qForm, mode: conf.mode }, function (event) {
            var _form = event.data.form,
                _mode = event.data.mode;
            if (_form.FormMode !== _mode) {
                _form.ChangeMode(_mode);
            }
        });
    };

    var fnInitRtnBtn = function (qForm, elem, conf, srcBtn) {
        var text = srcBtn.data('frtnb-text'),
            // icon = srcBtn.data('frtnb-icon'),
            iconClass = srcBtn.data('frtnb-icon-cls');

        elem.find('[data-q-ref~="btn"]')
            .append(text)
            .click({ srcBtn: srcBtn }, function (event) {
                event.data.srcBtn.trigger('click');
            });
        elem.find('[data-q-ref~="icon"]')
            .addClass(iconClass);
    };

    var fnInitMainActionBtn = function (qForm, elem, conf, srcBtn, sidebarTemplates) {
        fnInitBtnContent(qForm, elem, conf, srcBtn, sidebarTemplates);

        if (srcBtn.is('a')) {
            elem.click({ qForm: qForm, srcBtn: srcBtn }, function (event) {
                QUtils.NavigateTo = event.data.srcBtn.attr('href');
            });
        }
        else {
            elem.click({ srcBtn: srcBtn }, function (event) {
                event.data.srcBtn.trigger('click');
            });
        }
    };

    // -------- Validation of button availability --------
    var fnCheckModeBtns = function (qForm) {
        var notAllowedModes = [QFormMode.new, QFormMode.duplicate];
        return $.inArray(qForm.FormMode, notAllowedModes) === -1;
    }

    //------------------------------------------------------------------------------------
    // Definition of sections and buttons
    //------------------------------------------------------------------------------------
    var sections = [
        {
            selector: '[data-q-ref="form-btns-container-modes"]',
            target: '[data-q-ref~="form-btns-container-modes"]',
            template: '[data-q-ref~="form-btn"]',
            buttons: [
                {
                    mode: QFormMode.show,
                    content: '[data-q-ref="btn-content-show"]',
                    fnActive: fnActiveFModeBtn,
                    fnInit: fnInitModeBtn,
                    fnCheck: fnCheckModeBtns
                },
                {
                    mode: QFormMode.edit,
                    content: '[data-q-ref="btn-content-edit"]',
                    fnActive: fnActiveFModeBtn,
                    fnInit: fnInitModeBtn,
                    fnCheck: fnCheckModeBtns
                }
            ],
            clone_buttons: [
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="ok"]',
                    content: '[data-q-ref="btn-content-save"]',
                    fnInit: fnInitMainActionBtn
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="delete"]',
                    content: '[data-q-ref="btn-content-confirm"]',
                    fnInit: fnInitMainActionBtn
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="cancel"]',
                    content: '[data-q-ref="btn-content-cancel"]',
                    fnInit: fnInitMainActionBtn,
                    fnCheck: function (qForm) {
                        var allowedModes = [QFormMode.new, QFormMode.edit, QFormMode.duplicate];
                        return $.inArray(qForm.FormMode, allowedModes) !== -1;
                    }
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="cancel"]',
                    content: '[data-q-ref="btn-content-back"]',
                    fnInit: fnInitMainActionBtn,
                    fnCheck: function (qForm) {
                        var allowedModes = [QFormMode.show, QFormMode.delete];
                        return $.inArray(qForm.FormMode, allowedModes) !== -1;
                    }
                }
            ]
        },
        {
            selector: '[data-q-ref="sidebar-btns-modes"]',
            target: '[data-q-ref="sidebar-container-modes"]',
            template: '[data-q-ref="sidebar-btn-mode"]',
            fnActive: fnActiveModeBtn,
            buttons: [
                {
                    mode: QFormMode.show,
                    content: '[data-q-ref="btn-content-show"]',
                    fnInit: fnInitModeBtn,
                    fnCheck: fnCheckModeBtns
                },
                {
                    mode: QFormMode.edit,
                    content: '[data-q-ref="btn-content-edit"]',
                    fnInit: fnInitModeBtn,
                    fnCheck: fnCheckModeBtns
                },
                {
                    mode: QFormMode.new,
                    content: '[data-q-ref="btn-content-new"]',
                    fnInit: fnInitBtnContent,
                    fnCheck: function (qForm) {
                        return qForm.FormMode === QFormMode.new;
                    }
                },
                {
                    mode: QFormMode.duplicate,
                    content: '[data-q-ref="btn-content-duplicate"]',
                    fnInit: fnInitBtnContent,
                    fnCheck: function (qForm) {
                        return qForm.FormMode === QFormMode.duplicate;
                    }
                },
                {
                    mode: QFormMode.delete,
                    content: '[data-q-ref="btn-content-delete"]',
                    fnInit: fnInitBtnContent,
                    fnCheck: function (qForm) {
                        return qForm.FormMode === QFormMode.delete;
                    }
                }
            ]
        },
        {
            selector: '[data-q-ref="sidebar-btns-actions"]',
            template: '[data-q-ref="sidebar-btn-action"]',
            target: '[data-q-ref="sidebar-container-main_actions"]',
            buttons: [
                {
                    mode: QFormMode.duplicate,
                    content: '[data-q-ref="btn-content-duplicate"]',
                    target: '[data-q-ref="sidebar-container-actions"]',
                    fnInit: fnInitModeBtn,
                    fnCheck: function (qForm) {
                        var notAllowedModes = [QFormMode.new, QFormMode.delete, QFormMode.duplicate];
                        return $.inArray(qForm.FormMode, notAllowedModes) === -1;
                    }
                },
                {
                    mode: QFormMode.delete,
                    content: '[data-q-ref="btn-content-delete"]',
                    target: '[data-q-ref="sidebar-container-actions"]',
                    fnInit: fnInitModeBtn,
                    fnCheck: function (qForm) {
                        var notAllowedModes = [QFormMode.new, QFormMode.delete, QFormMode.duplicate];
                        return $.inArray(qForm.FormMode, notAllowedModes) === -1;
                    }
                },
                {
                    mode: QFormMode.new,
                    content: '[data-q-ref="btn-content-new"]',
                    target: '[data-q-ref="sidebar-container-actions"]',
                    fnInit: fnInitModeBtn,
                    fnCheck: function (qForm) {
                        var notAllowedModes = [QFormMode.new, QFormMode.delete, QFormMode.duplicate];
                        return $.inArray(qForm.FormMode, notAllowedModes) === -1;
                    }
                },
                {
                    content: '[data-q-ref="btn-content-apply"]',
                    fnCheck: function (qForm) {
                        var allowedModes = [QFormMode.new, QFormMode.edit, QFormMode.duplicate];
                        return qForm.FormButtons.ApplyButton && $.inArray(qForm.FormMode, allowedModes) !== -1;
                    },
                    fnInit: function (qForm, elem, conf, srcBtn, sidebarTemplates) {
                        fnInitBtnContent(qForm, elem, conf, srcBtn, sidebarTemplates);
                        $(elem).off('click').click({ qForm: qForm }, function (event) { event.data.qForm.Apply(); });
                    }
                },
                {
                    content: '[data-q-ref="btn-content-audit"]',
                    fnCheck: function (qForm) {
                        return qForm.FormButtons.AuditButton;
                    },
                    fnInit: function (qForm, elem, conf, srcBtn, sidebarTemplates) {
                        fnInitBtnContent(qForm, elem, conf, srcBtn, sidebarTemplates);
                        //Init ShowAuditButton
                        $(elem).off('click').click({ qForm: qForm }, function (event) { event.data.qForm.ShowAuditHistory(); });
                    }
                }
            ],
            clone_buttons: [
                {
                    selector: '[data-frtnb="' + formName + '"]',
                    template: '[data-q-ref="sidebar-btn-routine"]',
                    target: '[data-q-ref="sidebar-container-routines"]',
                    fnInit: fnInitRtnBtn,
                    fnActive: fnActiveRoutineBtn
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="ok"]',
                    content: '[data-q-ref="btn-content-save"]',
                    fnInit: fnInitMainActionBtn
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="delete"]',
                    content: '[data-q-ref="btn-content-confirm"]',
                    fnInit: fnInitMainActionBtn
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="cancel"]',
                    content: '[data-q-ref="btn-content-cancel"]',
                    fnInit: fnInitMainActionBtn,
                    fnCheck: function (qForm) {
                        var allowedModes = [QFormMode.new, QFormMode.edit, QFormMode.duplicate];
                        return $.inArray(qForm.FormMode, allowedModes) !== -1;
                    }
                },
                {
                    selector: '[data-form-actions="' + formName + '"] > [qbutton="cancel"]',
                    content: '[data-q-ref="btn-content-back"]',
                    fnInit: fnInitMainActionBtn,
                    fnCheck: function (qForm) {
                        var allowedModes = [QFormMode.show, QFormMode.delete];
                        return $.inArray(qForm.FormMode, allowedModes) !== -1;
                    }
                }
            ]
        }
    ];

    //------------------------------------------------------------------------------------
    // Button rendering
    //------------------------------------------------------------------------------------
    $.each(sections, function (i, section) {
        // Remove all previous elements
        $(section.selector, sidebarTarget).remove();
        $(section.selector, formTarget).remove();

        // Create new elements
        var s = $(section.selector, sidebarTemplates).clone(),
            anyElement = false; // The section in some cases may have no buttons

        if (!$.isEmptyObject(section.buttons)) {
            // Some buttons only appear under certain conditions
            var _buttons = $.grep(section.buttons, function (btn) {
                var check = true;
                if (btn.fnCheck) { check = btn.fnCheck(_this, btn); }
                return check && ($.inArray(btn.mode, _this.FormButtons.Modes) !== -1 || (typeof btn.fnCheck === 'function' && $.isEmptyObject(btn.mode)));
            });

            if (!$.isEmptyObject(_buttons)) {
                $.each(_buttons, function (ii, conf) {
                    // Can be defined the same template, target and active element function for all buttons in the section
                    if (!$.isEmptyObject(section.template) && $.isEmptyObject(conf.template)) { conf.template = section.template; }
                    if (!$.isEmptyObject(section.target) && $.isEmptyObject(conf.target)) { conf.target = section.target; }
                    if (typeof section.fnActive === 'function' && typeof conf.fnActive !== 'function') { conf.fnActive = section.fnActive; }
                    // Clone the button's HTML template and add it to the final container
                    var btnClone = $(conf.template, sidebarTemplates).clone();
                    s.is(conf.target) ? s.append(btnClone) : s.find(conf.target).append(btnClone);
                    // Add the active element effect (if applicable)
                    if (conf.fnActive) { conf.fnActive(_this, conf, btnClone); }
                    // Associate events (e.g.: click) and fill the Text and Icon of the button
                    if (conf.fnInit) { conf.fnInit(_this, btnClone, conf, null, sidebarTemplates); }

                    anyElement = true;
                });
            }
        }

        // Buttons that represent a clone of the button available on the form.
        // Clicking on this button causes the same action as the original button.
        // such as: Save and Cancel button, buttons for routines.
        if (!$.isEmptyObject(section.clone_buttons)) {
            $.each(section.clone_buttons, function (i, conf) {
                if (conf.fnCheck && !conf.fnCheck(_this)) { return; }
                // Can be defined the same template, target and active element function for all buttons in the section
                if (!$.isEmptyObject(section.template) && $.isEmptyObject(conf.template)) { conf.template = section.template; }
                if (!$.isEmptyObject(section.target) && $.isEmptyObject(conf.target)) { conf.target = section.target; }
                if (typeof section.fnActive === 'function' && typeof conf.fnActive !== 'function') { conf.fnActive = section.fnActive; }
                // Collect the source buttons
                var btns = _this.element.find(conf.selector);
                if (!btns.is('a, button')) { btns = btns.find('a, button'); }
                $.each(btns, function (i, btn) {
                    // Clone the button's HTML template and add it to the final container
                    var btnClone = $(conf.template, sidebarTemplates).clone();
                    s.is(conf.target) ? s.append(btnClone) : s.find(conf.target).append(btnClone);
                    // Add the active element effect (if applicable)
                    if (conf.fnActive) { conf.fnActive(_this, conf, btnClone); }
                    // Associate events (e.g.: click) and fill the Text and Icon of the button
                    if (conf.fnInit) { conf.fnInit(_this, btnClone, conf, $(btn), sidebarTemplates); }

                    anyElement = true;
                });
            });
        }

        // The section is added only if there is a buttons otherwise it will not appear.
        if (anyElement) {
            var isSidebarSection = s.is('[data-q-ref^="sidebar"]'),
                isFormSection = s.is('[data-q-ref^="form"]');
            if (isSidebarSection) {
                $(sidebarTarget).append(s);
            }
            else if (isFormSection) {
                $(formTarget).append(s);
            }
        }
    });
};

QForm.prototype.ShowAuditHistory = function () {
    ShowAuditHistory({ logTable: this.baseArea, logRow: this.PrimaryKey.Value})
};

/**
 * If the form is in edit mode and has changed fields, it shows a message for user confirm closing of the form.
 * It must be used in Cancel and during closing of the form, without saving the record.
 * @returns {Promise} Promise object represents the result of confirmation (true / false)
*/
QForm.prototype.confirmDirtyFields = function () {
    var qForm = this,
        deferred = $.Deferred(),
        editableModes = [QFormMode.new, QFormMode.edit, QFormMode.duplicate],
        hasDirtyWizards = false;

    // Checks the form controls to see if there are any wizards. If so, checks if the
    // forms of the wizard steps are dirty.
    $.each(qForm.Controls, function(idx, qControl)
    {
        if (qControl instanceof QWizardControl)
        {
            let stepList = qControl.wizardForms;
            if (stepList !== undefined)
            {
                for (let i = 0; i < stepList.length; i++)
                {
                    if (window[stepList[i]] !== undefined && window[stepList[i]].isDirty)
                    {
                        hasDirtyWizards = true;
                        return;
                    }
                }
            }
        }
    });

    if (qForm.Type !== QFormType.MENU && $.inArray(qForm.FormMode, editableModes) !== -1 && (qForm.isDirty || hasDirtyWizards))
    {
        var applyDirtyClass = function (qForm) {
            var dirtyControlClass = 'i--dirty';
            $.each(qForm.Controls, function (idx, qControl) {
                if (qControl.isDirty) {
                    $(qControl.element).addClass(dirtyControlClass);
                } else {
                    $(qControl.element).removeClass(dirtyControlClass);
                }
            });
        };

        displayMessage(quidgestGlobals.Resources.CONFIRM_EXIT_FORM_DIRTY, MessageDefs.StatusEnum.Q, undefined,
            [
				{
                    label: quidgestGlobals.Resources.YES,
                    callback: function (result) {
                        if (!result) {
                            applyDirtyClass(qForm);
                        }
                        deferred.resolve(result);
                    },
					icon: "check"
                },
                {
                    label: quidgestGlobals.Resources.NO,
                    callback: () => deferred.resolve(false),
                    style: MessageDefs.ButtonTypes.Secondary,
					icon: "ban-circle"
                }
            ],
            {
                onEscapeCallback: () => deferred.resolve(false)
            }
        )
    }
    else {
        deferred.resolve(true);
    }

    return deferred.promise();
};

/**
 *  The click event of the "Cancel" button on normal forms with a validation of changed fields.
 */
QForm.prototype.Cancel = function () {
    /**
     * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
     *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
     *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
     *  including corrupting the levels of history.
     */
    if(this.submissionDisabled)
        return;
    this.submissionDisabled = true;
    
    var qForm = this,
        formName = $(qForm.element).data('form'),
        cancelBtn = $('[data-form-actions="' + formName + '"]', qForm.element).find('[qbutton="cancel"]');

    try
    {
        $.when(qForm.confirmDirtyFields()).then(function (result) {
            if (result) {
                $.ajax({
                    url: cancelBtn.data('href'),
                    type: "GET",
                }).done(function (data) {
                    if (data) {
                        QUtils.NavigateTo = data.Location;
                    }
                    else
                        qForm.submissionDisabled = false;
                }).fail(() => { qForm.submissionDisabled = false; });
            }
            else
                qForm.submissionDisabled = false;
        }).fail(() => { qForm.submissionDisabled = false; });
    }
    catch (e)
    {
        console.error('Error while canceling the form', e);
        qForm.submissionDisabled = false;
    }
};

QForm.prototype.EmitSyncOfControls = function () {
    $.each(this.Controls, function (_, control) {
        control.EmitSyncEvent();
    });
};

QForm.prototype.StoreSetEntry = function (area, field, newValue, key) {
    try
    {
        if(area === undefined || field === undefined)
            return;
        area = area.toLowerCase();
        if(key === undefined)
            key = this.Data.RelationKeys[area] || null;
        let formName = this.element.data('form');
        QLocalStorage.setEntry(area, field, newValue, key, formName);
    }
    catch(e) {
        console.error("Error on set store entry", { area: area, field: field, value: newValue, key: key });
    }
};

QForm.prototype.StoreGetEntry = function (area, field, key) {
    try
    {
        if(area === undefined || field === undefined)
            return;
        area = area.toLowerCase();
        if(key === undefined)
            key = this.Data.RelationKeys[area] || null;
        let formName = this.element.data('form');
        return QLocalStorage.getEntry(area, field, key, formName);
    }
    catch(e) {
        console.error("Error on get store entry", { area: area, field: field, key: key });
        return;
    }
};

QForm.prototype.StoreRemoveEntry = function (area, field, key) {
    try
    {
        if(area === undefined || field === undefined)
            return;
        area = area.toLowerCase();
        if(key === undefined)
            key = this.Data.RelationKeys[area] || null;
        let formName = this.element.data('form');
        QLocalStorage.removeEntry(area, field, key, formName);
    }
    catch(e) {
        console.error("Error on remove store entry", { area: area, field: field, key: key });
    }
};

QForm.prototype.StoreGetKeyEntry = function(tableName) {
    try {
        let formName = this.element.data('form'),
            formPrimaryKey = this.PrimaryKey.Value,
            formKeysDataId = 'QForm_'+ formName + '_SavedKeys';

        return QLocalStorage.getEntry(formKeysDataId, tableName, formPrimaryKey);
    }
    catch(e) {
        console.error("Error on get store key entry", { area: tableName });
        return;
    }
};

QForm.prototype.StoreGetAllKeyEntries = function() {
    try {
        let formName = this.element.data('form'),
            formPrimaryKey = this.PrimaryKey.Value,
            formKeysDataId = 'QForm_'+ formName + '_SavedKeys';

        let storage = this.getLocalStorage('savedInfo');

        return (storage[formKeysDataId] || {})[formPrimaryKey] || {};
    }
    catch(e) {
        console.error("Error on get store of all key entries", { area: tableName });
        return {};
    }
};

QForm.prototype.StoreSetKeyEntry = function(tableName, newValue) {
    try {
        let formName = this.element.data('form'),
            formPrimaryKey = this.PrimaryKey.Value,
            formKeysDataId = 'QForm_'+ formName + '_SavedKeys';

        return QLocalStorage.setEntry(formKeysDataId, tableName, formPrimaryKey, newValue);
    }
    catch(e) {
        console.error("Error on set store key entry", { area: tableName, key: formPrimaryKey });
        return;
    }
};

QForm.prototype.StoreRemoveKeyEntry = function(tableName) {
    try {
        let formName = this.element.data('form'),
            formPrimaryKey = this.PrimaryKey.Value,
            formKeysDataId = 'QForm_'+ formName + '_SavedKeys';

        QLocalStorage.removeEntry(formKeysDataId, tableName, formPrimaryKey);
    }
    catch(e) {
        console.error("Error on remove store key entry", { area: tableName, key: formPrimaryKey });
        return;
    }
};

QForm.prototype.FetchFieldData = function (control) {
    const modelField = "Val" + CapFirst(control.field);
    const url = this.UrlAction.ReloadControl + "_" + modelField, vm = this;

    $.ajax({
        url: url,
        type: 'GET',
        data: { id: vm.PrimaryKey.Value },
        success: function (response) {
            control.Value = response[modelField];
        },
        error: function (error) {
            console.error(error);
        }
    });
};

//---------------------------------------------
// QControl (base class)
//---------------------------------------------
function QControl(element, qParentForm) {
    /// <summary>
    ///
    /// </summary>
    /// <param name="element">Reference to the main DOM element</param>
    var _this = this;
    //reference to the main DOM element
    _this.element = $(element);
    _this.replaceIncorrectAttributes();
    //Identifier of the control
    _this.controlIdentifier = $(_this.element).data('identifier');
    //caches the last know value of the field
    //this.value = "";
    //Holds the binding between a change event and a list of function to execute when that event is triggered
    _this.changeEventSink = [];
    // Indicate when this field is just for read
    _this.isReadOnly = false;
    // Empty value of the field (used in the FillWhen)
    _this._emptyValue = '';
    //Field info
    if ($(_this.element).attr('pers-cs-area'))
        _this.area = $(_this.element).attr('pers-cs-area').toLowerCase();
    if ($(_this.element).attr('pers-cs-field')) //substr(3) => remove 'Val'
        _this.field = $(_this.element).attr('pers-cs-field').substring(3).toLowerCase();
    if ($(_this.element).attr('db-full-field-name'))
        _this.db_full_field_name = $(_this.element).attr('db-full-field-name').toLowerCase();
    //Reference to parent form object
    _this._parentForm = qParentForm;

    // Foreign key's attributes
    if ($(_this.element).attr('trelate')) _this.trelate = $(_this.element).attr('trelate').toLowerCase();
    if ($(_this.element).attr('tfrelate')) _this.tfrelate = $(_this.element).attr('tfrelate').toLowerCase();

    // Form control loaded attribute - for web tests
    var getQControlLoaded = function () {
        return $(_this.element).attr("qcontrol-loaded") || false;
    }, setQControlLoaded = function (val) {
        $(_this.element).attr("qcontrol-loaded", val);
        if (_this._parentForm)
            $(_this._parentForm.element).trigger('CHECK_QFORM_LOADED');
    };
    Object.defineProperty(_this, 'qControlLoaded', { get: getQControlLoaded, set: setQControlLoaded });
    _this.qControlLoaded = false;

    $(_this.element).on('SET_QCONTROL_LOADED', _this, function (event, value) {
        var _this = event.data;
        //console.log("set control loaded", _this, value);
        _this.qControlLoaded = value;
    });

    // Block stack
    _this._block = {
        BlockStack: [],
        isBlocked: function () { return this.BlockStack.length > 0; },
        evalCondition: function (blockType, blockValue) {
            if (blockValue === true || blockValue === 1) {
                // Add to stack
                if ($.inArray(blockType, this.BlockStack) === -1) {
                    this.BlockStack.push(blockType);
                }
            }
            else {
                // Remove from stack
                this.BlockStack = $.grep(this.BlockStack, function (value) {
                    return value != blockType;
                });
            }
        }
    };

    // Block field if its Visualization form mode
    var visualizationModes = [ QFormMode.show, QFormMode.delete ];
    if(_this._parentForm && $.inArray(_this._parentForm.FormMode, visualizationModes) !== -1 && !(_this instanceof QButtonControl)) {
        _this.isReadOnly = true;
        _this.Block('JustVisualization', true);
    }

    // Block fixed fields
    if($(_this.element).attr('fixed-field')) {
        _this.Block('FixedField', true);
    }

    // Sequencial Numbers or Text
    if ($(_this.element).attr('data-sequencial')) {
        _this.isSequencial = true;
    }

    //Associate QObject to the element
    //Used in get/set fieldValue
    $(_this.element).data("QObject", _this);
};

QControl.prototype = {
    get Value() {
        this.ParseControlValue();
        return this.value;
    },
    set Value(val) {
        if (this.value !== val) {
            this.value = val;
            this.UpdateControlValue();
            this.TriggerChange();
        }
    },
    get ParentForm() { return this._parentForm; },
    //caches the last know value of the field
    set value (val) {
        $(this.element).data("QValue", val);
    },
    get value() {
        var curValue = $(this.element).data("QValue");
        if (curValue === undefined) curValue = "";
        return curValue;
    },
    //caches the original value of the field
    set originalValue(val) {
        $(this.element).data("QOriginalValue", val);
    },
    get originalValue() { // The originalValue is assigned in the QControls' Init methods.
        var _originalValue = $(this.element).data("QOriginalValue");
        return _originalValue === undefined ? "" : _originalValue;
    },
    get renderedValue() {
        let originalValue = undefined;
        if(this.element[0]) {
            if(this.element[0].hasAttribute('original-value'))
                originalValue = this.element.attr('original-value');
            else if(this.element[0].hasAttribute('value'))
                originalValue = this.element.attr('value');
        }
        if(originalValue === undefined)
            originalValue = this.element.data('value');
        return originalValue;
    },
    get isDirty() { //true if the underlying value of the control has changed from its original database persisted value
        var a = this.originalValue, b = this.Value;

        if (jQuery.type(a) === "date") { a = a.toQString(); }
        else if (moment.isMoment(a)) { a = a.toDate().toQString(); }
        if (jQuery.type(b) === "date") { b = b.toQString(); }
        else if (moment.isMoment(b)) { b = b.toDate().toQString(); }

		if (Array.isArray(a) && Array.isArray(b)) {
            if (a.length !== b.length) {
                return true;
            }

            return !a.every(function(val) { return b.includes(val); });
        }
        else {
            return a !== b;
        }
    },
    //Id of the control
    get controlId() {
        var id = $(this.element).prop('id');

        // In case of multiple inputs (Radio buttons / Checkboxs)
        if(!id && $(this.element).find('input').length > 0)
            id = $(this.element).find('input:first').prop('id');

        return id;
    }
};

QControl.prototype.TriggerChange = function () {
    $(this.element).change();
    this.EmitSyncEvent();
};

QControl.prototype.EmitSyncEvent = function () {
    if (this._parentForm && !$.isEmptyObject(this.area) && !$.isEmptyObject(this.field)) {
        var fieldFullName = this.area + '->' + this.field;
        // The next (one) line can be commented out if we don't want an internal update. e.g: two equal fields in different Tabs
        //$(this._parentForm.element).trigger('q-form-field-change:' + fieldFullName, { fullFieldName: fieldFullName, value: this.Value, qControlId: this.controlIdentifier });
        $(this._parentForm.element).trigger('q-form-field-change-sync', { fullFieldName: fieldFullName, value: this.Value, qControlId: this.controlIdentifier });
    }
};

QControl.prototype.updateValueCallback = function (event, eData) {
    if (event.data.qControlId !== eData.qControlId) { // ignore own control
        var qControl = $('[data-identifier="' + event.data.qControlId + '"]').getQControl() || {};
        qControl.Value = (typeof eData.value !== "undefined" ?  eData.value : null);
    }
};

QControl.prototype.AttachOnChange = function () {
    var _this = this;
    // Execute events associated to change event
    if (_this._parentForm) {
        var tElem = $(_this.element);
        if (tElem.length === 0) return;
        var changeEvent = (_this.controlId || '').toUpperCase() + '_CHANGE';
        if (tElem.is("select") && tElem.data("main-field")) {
            var mainField = tElem.data("main-field").split(".");
            changeEvent += ' ' + mainField[0].toUpperCase() + mainField[1].toUpperCase() + '_CHANGE';
        }
        $(_this._parentForm.element).on(changeEvent, function () {
            _this.ProcEventsOnChange();
        });

        // synchronization of fields values
        // e.g: from wizard to main form
        if (!$.isEmptyObject(_this.area) && !$.isEmptyObject(_this.field)) {
            var fieldChangeEvent = 'q-form-field-change:' + _this.area + '->' + _this.field;
            // PK's => FK's
            if (!$.isEmptyObject(_this.trelate) && !$.isEmptyObject(_this.tfrelate)) {
                fieldChangeEvent += ' q-form-field-change:' + _this.trelate + '->' + _this.tfrelate;
            }

            $(_this._parentForm.element)
                .off(fieldChangeEvent, _this.updateValueCallback)
                .on(fieldChangeEvent, { qControlId: _this.controlIdentifier }, _this.updateValueCallback);
        }
    }
};

QControl.prototype.ProcEventsOnChange = function () {
    $.each(this.changeEventSink, function (i, e) {
        if (e.function !== undefined) { e.object[e.function]();}
        else if(typeof e == "function") e();
    });
};

QControl.prototype.replaceIncorrectAttributes = function () {
    /// <summary>
    /// Só a partir do MVC 5.1 que é suportado htmlAttributes no EditorFor
    /// </summary>
    if ($(this.element).attr('pers_cs_area')) {
        $(this.element).attr('pers-cs-area', $(this.element).attr('pers_cs_area'));
        $(this.element).removeAttr("pers_cs_area");
    }
    if ($(this.element).attr('pers_cs_field')) {
        $(this.element).attr('pers-cs-field', $(this.element).attr('pers_cs_field'));
        $(this.element).removeAttr("pers_cs_field");
    }
};

QControl.prototype.SetFormulaDefault = function (formula, bindingEvents, checkDefaultOnce) {
    /// <summary>
    /// Set default value formula.
    /// TODO: Refactored to be into specific controls.
    /// </summary>
    //Proteger da dupla inicialização da formua
    if (this.formulaDefault !== undefined) return;
    this.formulaDefault = formula;
    this.formulaCheckDefaultOnce = checkDefaultOnce;

    $(this.ParentForm.element).bind(bindingEvents, this, function (event) {
        var qControl = event.data;
        qControl._execFormulaDefault();
    });
};

QControl.prototype._execFormulaDefault = function () {
    if (this.formulaCheckDefaultOnce !== undefined) {
        if (!qApi[this.formulaCheckDefaultOnce](this.Value)) return;
    }
    if (this.formulaDefault !== undefined) {
        try {
            var ctrl = this;
            $.when(this.formulaDefault()).done(function (result) {
                $.when(result).done(function (result) {
                    ctrl.Value = result;
                });
            });
        } catch (err) { QError.AppendError('Formula of field default value. ' + err.message, err.stack, window.location.href); }
    }
};

//Abstract functions. The subclasses must allways redefine these
QControl.prototype.Init = function () { };
QControl.prototype.Clear = function () { };

QControl.prototype.Block = function (blockType, isBlocked) {
    this._block.evalCondition(blockType || "BLOCK", isBlocked);
    var _controlIsBlocked = this._block.isBlocked();
    $(this.element).prop('readonly', _controlIsBlocked).attr('readonly', _controlIsBlocked);
};

QControl.prototype.Hide = function (isHidden) {
    var hideID = "#CONTAINER_" + this.controlIdentifier,
        elem = $(this.element).closest(hideID);

    var _fnHideElem = function (elem, isHidden) {
            var displayProp = isHidden ? 'none' : '';
            $(elem).css('display', displayProp);

            // If the field has popovers, also hides them.
            let popovers = $(elem.parent()).find('[data-toggle="popover"]');
            popovers.each(function()
            {
                $(this).css('display', displayProp);
            });
        },
        _fnHideCollapse = function (elem, isHidden) {
            var aHeading = $($('[elem-identifier="AccordionHeading"]'), $(elem)),
                aBody = $($('[elem-identifier="AccordionBody"]'), $(elem)),
                aContainer = $($('[elem-identifier="ContainerAccordionInner"]'), aBody),
                hiddenClass = 'accordion-group-hidden';

            _fnHideElem($(elem).find(aHeading), isHidden);
            _fnHideElem($(elem).find(aContainer), isHidden);

            // The CSS of the following code seems a bit stupid,
            // but if we hide elements of the 'collapse' with display: none, the plugin will stop working properly.
            // This happens because the plugin needs the 'transitionend' event that is removed if it assigns the "display: none"
            if (isHidden) { $(elem).addClass(hiddenClass); }
            else { $(elem).removeClass(hiddenClass); }
        };

    if ($(elem).length === 0) {
        elem = $(this.element);
    }
    var isCollapse = $(elem).is($('[elem-identifier="AccordionGroup"]'));

    if (isCollapse) { _fnHideCollapse($(elem), isHidden); }
    else { _fnHideElem($(elem), isHidden); }

    if (isCollapse)
    {
        elem.children().each(function()
        {
            qToggleVisibility($(this), isHidden);
        });
    }
    else
        qToggleVisibility(elem.parent(), isHidden);
};

QControl.prototype.ParseControlValue = function () { };
QControl.prototype.UpdateControlValue = function () { };

QControl.prototype.SetBlockWhen = function (bindingEvents, condition) {
    this._blockWhenCondition = condition;
    $(this.ParentForm.element).bind(bindingEvents, this, function (event) {
        var qControl = event.data;
        $.when(qControl, qControl._blockWhenCondition(qControl.ParentForm.element)).done(function (qControl, conditionResult) {
            qControl.Block('BlockWhen', conditionResult);
        });
    });
};

QControl.prototype.SetFillWhen = function (bindingEvents, condition) {
    this._fillWhenCondition = condition;
    $(this.ParentForm.element).bind(bindingEvents, this, function (event) {
        var qControl = event.data;
        $.when(qControl, qControl._fillWhenCondition(qControl.ParentForm.element)).done(function (qControl, conditionResult) {
            qControl.Block('FillWhen', !conditionResult);
            // Para não invocar um evento change desnecessario, em alguns casos (lógico e numérico).
            // Para isso validado se o valor atual corresponde a valor "vazio" do campo.
            if (!conditionResult && qControl.Value !== qControl._emptyValue) {
                qControl.Value = '';
            }
        });
    });
};

QControl.prototype.CleanSequentials = function (target) {
    var element = $(this.element);
    var emptyText = "<" + quidgestGlobals.Resources.VAZIO58398 + ">";
    if (target) {
        element = $(target);
    }

    if (element.is('option')) {
        element.text(emptyText);
    } else {
        element.val("").attr("placeholder", emptyText);
    }
};

QControl.prototype.Reload = function () {
    this.ParentForm.FetchFieldData(this);
};

//---------------------------------------------
// QDbeditControl
//---------------------------------------------
function QDbeditControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    this.Limits = [];
    //caches the last know text value of the field
    this.textValue = "";
    //Hidden DBEdit
    this.isHiddenDBEdit = $(this.element).attr("hidden-dbedit") || false;
    // Number of last request
    this._requestNumberReloadDBEdit = 0;
    this._requestNumberGetDependants = 0;
};

QDbeditControl.prototype = Object.create(QControl.prototype);

Object.defineProperty(QDbeditControl.prototype, 'Text', {
    set: function (val) {
        // Set text of the selected option
        this.ParseControlText();
        if (this.textValue === val) { return; }
        // Set formated value
        this.textValue = this._getFormatedTextValue(val);
        if (!this.isHiddenDBEdit && qApi.emptyG(this.value) == 0 && $(this.element).find("option[value='" + this.value + "']").length != 0) {
            var option = $(this.element).find("option[value='" + this.value + "']");
            option.text(this.textValue);
            $(this.element).trigger('liszt:updated');
        }
        var mainField = $(this.element).data("main-field").split(".");
        $(this._parentForm.element).trigger(mainField[0].toUpperCase() + mainField[1].toUpperCase() + '_CHANGE', $(this.element));
    },
    get: function () {
        this.ParseControlText();
        return this.textValue;
    }
});

QDbeditControl.prototype._getFormatedTextValue = function (textValue) {
    /// <summary>
    ///
    /// </summary>
    var dataFormat = $(this.element).data('format');
    if (dataFormat && !isEmpty(textValue)) {
        if (jQuery.type(textValue) === "string") {
            var patternCSharp = /Date\(([^)]+)\)/,
                patternJSON = /(\d{4}-\d{2}-\d{2})[T](\d{2}:\d{2}:\d{2}.?(\d{3})?)[Z]?/,
                patternHour = /([01]\d|2[0-3]):([0-5]\d)/;
            var isHour = patternHour.test(textValue);
            if (isHour || patternJSON.test(textValue) || patternCSharp.test(textValue)) {
                //Try convert C# string to JS date
                textValue = QUtils.tryParseDate(textValue, isHour);
                if (textValue && moment.isMoment(textValue)) {
                    textValue = new Date(textValue.format('YYYY'), textValue.format('M') - 1, textValue.format('D'), textValue.format('H'), textValue.format('m'), textValue.format('s'), textValue.format('SSS'));
                }
            }
        }
        return QUtils.formatDate(textValue, dataFormat);
    }

    return textValue;
};

QDbeditControl.prototype.AddLimit = function (control, type) {
    this.Limits.push({ field: control, type: type });
    control.changeEventSink.push({ object: this, function: 'ReloadDBEditContent' });
};

QDbeditControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).val();
};


QDbeditControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    if (this.isHiddenDBEdit) {
        $(this.element).val(this.value);
    }
    else {
        //Check that option exists in the list. If not present the options, we will create a new option only with selected key.
        if (qApi.emptyG(this.value) == 0 && $(this.element).find("option[value='" + this.value + "']").length == 0) {
            //The option may be without text. The text will be received from the server in DBEditSelectedItem.
            $(this.element).append("<option value='" + this.value + "'></option>");
        }
        $(this.element).val(this.value);
        $(this.element).trigger('liszt:updated');
        //Update textValue
        this.ParseControlText();
    }
    this.DBEditSelectedItem(this.value);
};

QDbeditControl.prototype.ParseControlText = function () {
    /// <summary>
    /// Parses the html to extract the text of the selected option
    /// </summary>
    if (this.isHiddenDBEdit) {
        if (qApi.emptyG(this.value) === 1) {
            this.textValue = '';
        }
    }
    else {
        var option = $(this.element).find('option:selected');
        this.textValue = option.text();
    }

    var dataFormat = $(this.element).data('datetimepicker-format');
    if (dataFormat) {
        this.textValue = QUtils.parseDate(this.textValue, dataFormat);
    }
};

QDbeditControl.prototype.Init = function () {
    var $el = $(this.element);

    if($el.data("filled-by-history") == "True") {
        this.Block('HistoryBlocked', true);
    }

    if (this.isSequencial) {
        $el.find('option').each(function (index, option) {
            if (option.text.indexOf('-') !== -1) {
               this.CleanSequentials(this);
            }
        }.bind(this));
    }

    //if ($el.attr('trelate')) this.trelate = $el.attr('trelate').toLowerCase();
    //if ($el.attr('tfrelate')) this.tfrelate = $el.attr('tfrelate').toLowerCase();

    if(!this.isHiddenDBEdit)
        $el.chosen({ allow_single_deselect: true });
    /*
    if ($el.attr('key-field')) // Para a que ???
        this.field = $el.attr('key-field').substring(3).toLowerCase(); //substr(3) => remove 'Val'
    */
    $el.on("ReloadDBEditContent", null, this, function (e, searchInput, searchResults, loading) {
        var dbeditControl = e.data, deferred = $.Deferred();
        deferred.resolve(dbeditControl.ReloadDBEditContent(searchInput, searchResults, loading));
        return deferred.promise();
    });
    $el.on("DBEditSetValue", null, this, function (e, value) {
        var dbeditControl = e.data;
        dbeditControl.Value = value;
    });
    //init value
    this.ParseControlValue();
    this.originalValue = this.value;
    //get textValue
    if (!this.isHiddenDBEdit) {
        this.ParseControlText();
        // Lazy loading of dropdown items. Instead of load all at same time on server side will load items during init of client side.
        if ($el.data('has-more') && $el.find('option').length <= 2)
            this.ReloadDBEditContent(undefined, undefined, undefined, true);
    }

    this.qControlLoaded = true;
};

QDbeditControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    $(this.element).trigger("liszt:updated");
};

QDbeditControl.prototype.Hide = function (isHidden) {
    QControl.prototype.Hide.call(this, isHidden);
    $(this.element).trigger("liszt:updated");
};

QDbeditControl.prototype._reloadDBEditContent = function (searchInput, searchResults, loading, lazyLoad) {
    /// <summary>
    /// Invoca o reload do campo Dependete ou DBEdit
    /// </summary>
    /// <param name="searchInput"></param>
    /// <param name="searchResults"></param>
    /// <param name="loading"></param>
    /// <param name="lazyLoad"></param>
    var dbeditControl = this, deferred = $.Deferred();
    var currentValue = dbeditControl.value;
    var values = {}, auxValues = {};
    $.each(dbeditControl.Limits, function (_, limit) {
        var limitArea = limit.field.trelate || limit.field.area;
        if(limit.type === 'C' || limit.type === 'E') {
            var lKey = limit.field.controlId;
            var lValue = limit.field.Value;
            if (jQuery.type(lValue) === "date") { lValue = lValue.toQString(); }
            values[lKey] = auxValues[lKey] = lValue;
        }
        else {
            values[limitArea] = limit.field.Value;
        }
    });

    //no caso das limitações indiretas era preciso ter todas chaves
    //TODO: Mudar para procurar dentro dos controlos ou deixar até que fica implementado o 'class' dos dados
    $.each(dbeditControl.ParentForm.getAllForeignKeySelectors(), function (area, selector) { values[area.toLowerCase()] = getFieldValue(selector); });

    var searchText = "";
    if (searchInput !== undefined) {
        var searchId = "qTable" + $(dbeditControl.element).data('main-field').replace(".Val", "");
        searchText = searchInput.val();
        values[searchId] = searchText;
    }
    /*else if(dbeditControl._parentForm.itOnPersistenceLoad) {
        // No caso do carregamento inicial aplicar as chaves previamente gravados
        // Tem reduzir problemas no carregamento com existencia de chaves na persistência
        let savedKeys = dbeditControl._parentForm.StoreGetAllKeyEntries(),
            savedTables = Object.keys(savedKeys);
        savedTables.forEach(function(relTableName) {
            values[relTableName] = savedKeys[relTableName];
        });
    }*/
    else if(!lazyLoad) {
        //Caso se era um reload precisamos retirar a opção selecionada atualmente
        //para que não seja adicionada está opção a lista quando não o pertence.
        if (dbeditControl.isHiddenDBEdit) { values[dbeditControl.trelate] = null; }
        else { values[dbeditControl.area] = null; }
    }

    // Reduce unnecessary requests when limits have not changed
    if (dbeditControl.prevLimitValues !== undefined) {
        var different = false;
        $.each(values, function (key, value) {
            if (dbeditControl.prevLimitValues[key] !== value) { different = true; return; }
        });
        if (!different) { return; }
    }
    dbeditControl.prevLimitValues = values;

    var logData = {
        curReqNum: dbeditControl._requestNumberReloadDBEdit,
        limits: values,
        auxLimits: auxValues,
        identifier: dbeditControl.controlIdentifier,
        selected: dbeditControl.Value,
        start: new Date()
    };

    var link = dbeditControl.ParentForm.UrlAction.ReloadDBEdit;
    let timeoutID = undefined;
    var params = { Identifier: dbeditControl.controlIdentifier, Values: values };
    $.extend(params, auxValues); // Limits of 'C' or 'E' type
    $.ajax({
        type: 'POST',
        headers: { 'ReloadDBEditRequestNumber': dbeditControl._requestNumberReloadDBEdit += 1 },
        url: link,
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(params),
        beforeSend: function () {
            timeoutID = QAnimation.addLoading(1300);
            dbeditControl.qControlLoaded = false;
        },
        success: function (responseData, textStatus, request) {
            var data = responseData.Data;
            var requestNumber = request.getResponseHeader('ReloadDBEditRequestNumber');
            if (requestNumber && requestNumber != dbeditControl._requestNumberReloadDBEdit) {
                deferred.resolve(false);
                return;
            }
            $.extend(logData, {
                data: data,
                curResNum: requestNumber,
                end: new Date()
            });
            // console.warn("ReloadDBEdit Log", dbeditControl.controlIdentifier, logData);
            if (responseData.Success) {
                //var currentValue = dbeditControl.Value;
                var newValue = "", filledByPersistence = false;

                // MH => Client persistence + Lazy loading
                // The reload response in lazy loading mode, occurs after the client persistence script is executed which causes the loss of the previously selected value.
                /*if(lazyLoad) {
                    let savedValue = dbeditControl._parentForm.StoreGetKeyEntry(dbeditControl.area);
                    if(savedValue !== undefined) {
                        newValue = savedValue;
                        filledByPersistence = true;
                    }
                }*/

                if (!dbeditControl.isHiddenDBEdit) {
                    //not(:first) -> A primeira opção do chosen coresponde uma opção "Vazio", mas deve ser revisto se é preciso está opção.
                    //not([value=]) -> preenchido pela persistencia client-side
                    let optionPersistence = filledByPersistence ? ':not([value="' + newValue + '"])' : '';
                    $("option:not(:first)" + optionPersistence, dbeditControl.element).remove();
                    jQuery.each(data.List, function (_, row) {
                        // Se a opção for a mesma que é preenchida pela persistencia, substituir o HTML só para ter o Texto atualizado caso se esse mudou
                        /*if (filledByPersistence && row.Value === newValue) {
                            if (row.Text !== '')
                                dbeditControl.element.find('option[value="' + newValue + '"]').replaceWith('<option selected="selected" value="' + row.Value + '">' + row.Text + '</option>');
                        }
                        else
                            dbeditControl.element.append('<option ' + (!filledByPersistence && row.Selected ? 'selected="selected" ' : '') + 'value="' + row.Value + '">' + (row.Text !== '' ? row.Text : '&nbsp;') + '</option>');
                        */

                        let optionText = row.value;
                        if (optionText === '') { // Not yet saved record
                            // Try to find text in the storage
                            let textFieldName = dbeditControl.element.data("main-field").split(".")[1];
                            optionText = (QLocalStorage.getEntry(dbeditControl.area, textFieldName, row.key) || {}).value;
                            if (optionText === undefined || optionText === null)
                                optionText = '';
                        }

                        dbeditControl.element.append($('<option ' + (row.key === data.Selected ? 'selected="selected" ' : '') + 'value="' + row.key + '"></option>').text(optionText));
                    });

                    if (!filledByPersistence && data.Selected) {
                        var option = $('option[value="' + data.Selected + '"]', dbeditControl.element);
                        if (option.length == 0) {
                            var formatedVal = dbeditControl._getFormatedTextValue(data.Value);
                            dbeditControl.element.append($('<option selected="selected" value="' + data.Selected + '"></option>').text(formatedVal));
                        }
                        newValue = data.Selected;
                    }

                    if (searchInput === undefined)
                        dbeditControl.element.attr("data-has-more", data.HasMore).data("has-more", data.HasMore);
                }
                else if (!filledByPersistence) {
                    newValue = data.Selected;
                }

                // o valor deste campo ainda não foi confirmado pelo utilizador depois de uma pesquisa
                // Validar se realmente necessitamos de desencadear esta actualização
                // neste momento esta chamada causa que o valor do campo de input fique vazio, obrigando a memorizar o valor antes para restaurar depois
                var memval = "";
                if (searchInput !== undefined) {
                    memval = searchInput.val();
                }

                if (currentValue == newValue)
                    $(dbeditControl.element).trigger("liszt:updated");
                else if (dbeditControl.value == newValue) {
                    // Podem haver os casos em que a formula (default) preenche o valor do DBEdit
                    // ao mesmo tempo que o mesmo faz reload da lista dos itens
                    dbeditControl.value = '';
                }

                // TODO: Optimize the next code ...
                dbeditControl.Value = newValue;
                if (!lazyLoad && searchInput === undefined)
                    dbeditControl._execFormulaDefault();
                // - - - - - - - - - - - - - - - -

                if (searchResults !== undefined) {
                    searchInput.val(memval);
                    searchResults.show();
                }
                if (loading !== undefined) loading.hide();
                console.log("ReloadDBEdit element " + dbeditControl.controlIdentifier + " completed");
                dbeditControl.qControlLoaded = true;
                deferred.resolve(true);
            }
            else {
                console.error("ReloadDBEdit element " + dbeditControl.controlIdentifier + ": " + responseData.Message);
                dbeditControl.qControlLoaded = true;
                deferred.resolve(false);
            }
        },
        error: function () { console.error("ReloadDBEdit element " + dbeditControl.controlIdentifier); dbeditControl.qControlLoaded = true; deferred.resolve(false); },
        complete: function () {
            QAnimation.removeLoading(timeoutID);
        },
        traditional: true
    });
    return deferred.promise();
};

QDbeditControl.prototype.ReloadDBEditContent = function (searchInput, searchResults, loading, lazyLoad) {
    if(this._parentForm.persistenceLoadPromise && this._parentForm.persistenceLoadPromise.state() !== 'resolved')
    {
        var deferred = $.Deferred(), dbeditControl = this;
        this._parentForm.requestStack.push(function() {
            $.when(dbeditControl._reloadDBEditContent(searchInput, searchResults, loading, lazyLoad)).then(function(result) {
                deferred.resolve(result);
            });
            return deferred.promise();
        });
        return deferred.promise();
    }
    else
        return this._reloadDBEditContent(searchInput, searchResults, loading, lazyLoad);
};

QDbeditControl.prototype._dbEditSelectedItem = function (persistenceSelectedValue) {
    /// <summary>
    /// Preenchimento dos campos dependentes
    /// </summary>
    var dbeditControl = this, deferred = $.Deferred();

    //Verificar se DBEdit tem dependentes para que não ter de fazer um pedido a servidor desnecesario
    var dependantFields = $(dbeditControl.element).attr("dependant-fields");
    if (!dependantFields) { deferred.resolve(false); return deferred.promise(); }

    else if (!$(dbeditControl.element).is("input") && dependantFields == $(dbeditControl.element).data("main-field").toLowerCase()) {
        //Caso se o DBEdit não tiver nenhum campo dependente de si, mas foi selecionado por uma formula e a opção não existia (criada uma opção só com chave).
        if (qApi.emptyG(dbeditControl.Value) == 0 && qApi.emptyC(dbeditControl.Text) == 1) {
            deferred.resolve(false); return deferred.promise();
        }
    }

    // Get the field limit values
    var limitValues = {}, limitAuxValues = {};
    $.each(dbeditControl.Limits, function (_, limit) {
        var limitArea = limit.field.trelate || limit.field.area;
        if(limit.type === 'C' || limit.type === 'E') {
            var lKey = limit.field.controlId;
            var lValue = limit.field.Value;
            if (jQuery.type(lValue) === "date") { lValue = lValue.toQString(); }
            limitValues[lKey] = limitAuxValues[lKey] = lValue;
        }
        else {
            limitValues[limitArea] = limit.field.Value;
        }
    });
    if (isEmpty(limitValues)) { limitValues = null; }

    var logData = {
        curReqNum: dbeditControl._requestNumberGetDependants,
        limits: limitValues,
        auxLimits: limitAuxValues,
        identifier: dbeditControl.controlIdentifier,
        selected: dbeditControl.Value,
        persistenceSelectedValue: persistenceSelectedValue,
        start: new Date()
    };

    var link = dbeditControl.ParentForm.UrlAction.GetDependants,
        selectedValue = persistenceSelectedValue !== undefined ? persistenceSelectedValue : dbeditControl.Value,
        params = { Identifier: dbeditControl.controlIdentifier, Selected: selectedValue, Limits: limitValues };
    let timeoutID = undefined;
    $.extend(params, limitAuxValues); // Limits of 'C' or 'E' type
    $.ajax({
        type: 'POST',
        headers: { 'GetDependantsRequestNumber': dbeditControl._requestNumberGetDependants += 1 },
        url: link,
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(params),
        beforeSend: function() {
            timeoutID = QAnimation.addLoading(1300);
            dbeditControl.qControlLoaded = false;
        },
        success: function (data, textStatus, request) {
            var requestNumber = request.getResponseHeader('GetDependantsRequestNumber');
            if (requestNumber && requestNumber != dbeditControl._requestNumberGetDependants) {
                deferred.resolve(false);
                return;
            }
            $.extend(logData, {
                data: data,
                curResNum: requestNumber,
                end: new Date()
            });
            // console.warn("GetDependants Log", dbeditControl.controlIdentifier, logData);
            if (data.Success) {
                $.each(dbeditControl.ParentForm.Controls, function (i, control) {
                    var fieldFullName = control.area + "." + control.field;

                    //Foreign key can be have original field name
                    if (data.Data[fieldFullName] === undefined && control.trelate && control.tfrelate) {
                        fieldFullName = control.trelate + "." + control.tfrelate;
                    }
                    // DBEdit control
                    if (data.Data[fieldFullName] === undefined && control.db_full_field_name) {
                        fieldFullName = control.db_full_field_name;
                    }

                    if (data.Data[fieldFullName] === undefined) { return true; }
                    control.Value = data.Data[fieldFullName];
                });

                // Update the text field of DBEdit
                var fieldFullName = $(dbeditControl.element).data("main-field");
                fieldFullName = fieldFullName.replace(".Val", ".").toLowerCase();
                if (data.Data[fieldFullName]) dbeditControl.Text = data.Data[fieldFullName];
            }
            else {
                console.error("DBEdit Selected Item of element " + dbeditControl.controlIdentifier + ": " + data.Message);
            }
            dbeditControl.qControlLoaded = true;
        },
        error: function (err) { QError.AppendError('DBEdit Selected Item of element: ' + dbeditControl.controlIdentifier + '. ' + err.message, err.stack, window.location.href); dbeditControl.qControlLoaded = true; },
        complete: function (data) { QAnimation.removeLoading(); console.log("DBEdit Selected Item of element: " + dbeditControl.controlIdentifier + " is completed"); deferred.resolve(true); },
        traditional: true
    });
    return deferred.promise();
};

QDbeditControl.prototype.DBEditSelectedItem = function (persistenceSelectedValue) {
    if(this._parentForm.persistenceLoadPromise && this._parentForm.persistenceLoadPromise.state() !== 'resolved')
    {
        var deferred = $.Deferred(), dbeditControl = this;
        this._parentForm.requestStack.push(function() {
            $.when(dbeditControl._dbEditSelectedItem(persistenceSelectedValue)).then(function(result) {
                deferred.resolve(result);
            });
            return deferred.promise();
        });
        return deferred.promise();
    }
    else
        return this._dbEditSelectedItem();
};

//---------------------------------------------
// QArrayControl
//---------------------------------------------
function QArrayControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    //caches the last know text value of the field
    this.textValue = "";
    //Hidden DBEdit
    this.isHiddenDBEdit = ($(this.element).is("input")/* && is('hidden')'*/);

    //Save original options
    this.originalOptions = $("option:not(:first)", element).map((idx, o) => ({
        key: $(o).attr("value"),
        group: $(o).attr("group"),
        text: $(o).html(),
    }));
}

QArrayControl.prototype = Object.create(QControl.prototype);

QArrayControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).val();

    if ($(this.element).data('array-type') === "AN") {
        // Numeric array
        if (this.value && this.value !== "" && jQuery.type(this.value) === "string") {
            this.value = parseFloat(this.value);
        }
    }
};

QArrayControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    if (this.isHiddenDBEdit) {
        $(this.element).val(this.value);
    }
    else {
        $(this.element).val(this.value).trigger('liszt:updated');
        this.ParseControlText();
    }
};

QArrayControl.prototype.ParseControlText = function () {
    /// <summary>
    /// Parses the html to extract the text of the selected option
    /// </summary>
    const option = $(this.element).find('option:selected');
    this.textValue = option.text();
};

QArrayControl.prototype.Init = function () {
    if (!this.isHiddenDBEdit)
        $(this.element).chosen({ allow_single_deselect: true });
    //init value
    this.ParseControlValue();
    this.originalValue = this.value;
    //get textValue
    if (!this.isHiddenDBEdit)
        this.ParseControlText();
    $(this.element).on("DBEditSetValue", null, this, function (e, value) {
        const dbeditControl = e.data;
        dbeditControl.Value = value;
    });
    this.qControlLoaded = true;
};

QArrayControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    $(this.element).trigger("liszt:updated");
};

QArrayControl.prototype.Hide = function (isHidden) {
    QControl.prototype.Hide.call(this, isHidden);
    $(this.element).trigger("liszt:updated");
};

QArrayControl.prototype.SetArrayElementShowWhen = function (bindingEvents, condition) {
    this._arrayElShowWhenCondition = condition;
    $(this.ParentForm.element).bind(bindingEvents, this, function (event) {
        const qControl = event.data;
        qControl.UpdateVisibleElements();
    });
}

QArrayControl.prototype.UpdateVisibleElements = function () {
    const qControl = this;

    // Remove old options
    $("option:not(:first)", qControl.element).remove();

    $.each(qControl.originalOptions, function (_, option) {
        $.when(qControl, qControl._arrayElShowWhenCondition(option)).done(
            function (qControl, conditionResult) {
                if (conditionResult) {
                    qControl.element.append(
                        $(
                            "<option " +
                                (option.key === qControl.value
                                    ? 'selected="selected" '
                                    : "") +
                                'value="' +
                                option.key +
                                '"></option>'
                        ).text(option.text)
                    );
                }
            }
        );
    });

    qControl.UpdateControlValue();
};

//---------------------------------------------
// QArrayLogicalControl
//---------------------------------------------
function QArrayLogicalControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    // caches the last know text value of the field
    var _this = this;
    _this.ParseControlValue();
    _this.ParseControlText();
    _this.originalValue = _this.value;

    if (!_this.isReadOnly) {
        $(_this.element)
            .parent()
            .off('click')
            .on('click',
                function () {
                    _this.value == 1 ? _this.value == 0 : _this.value == 1;
                });
    }
};

QArrayLogicalControl.prototype = Object.create(QControl.prototype);

QArrayLogicalControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).is(":checked") ? 1 : 0;
};

QArrayLogicalControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    if (this.value == true || this.value === "true" || this.value === "True") {
        this.value = 1;
    } else {
        this.value = 0;
    }

    if (this.value === 1) {
        $(this.element)
            .attr('checked', 'checked')
            .prop('checked', true);
    } else {
        $(this.element)
            .removeAttr('checked')
            .prop('checked', false);
    }
};

QArrayLogicalControl.prototype.ParseControlText = function () {
    /// <summary>
    /// Parses the html to extract the text of the selected option
    /// </summary>
    this.textValue = $(this.element)
        .parent()
        .find('[data-option="' + (this.value === 1 ? 'true' : 'false') + '"]')
        .text();
};

QArrayLogicalControl.prototype.Init = function () {
    this.ParseControlValue();
    this.originalValue = this.value;
    this.qControlLoaded = true;
};

QArrayLogicalControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    var _controlIsBlocked = this._block.isBlocked();
    $(this.element).prop('disabled', _controlIsBlocked).attr('disabled', _controlIsBlocked);
};

QArrayLogicalControl.prototype.Hide = function (isHidden) {
    QControl.prototype.Hide.call(this, isHidden);
};

//---------------------------------------------
// QTabControl
//---------------------------------------------
function QTabControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};
QTabControl.prototype = Object.create(QControl.prototype);

QTabControl.prototype.Init = function () {
    var tabElement = $(this.element);
    $('a[data-toggle="tab"][data-target="#' + $(this.element).attr('id') + '"]').on('show.bs.tab', function (e) {
        //console.log(e.target) // newly activated tab
        var formName = tabElement.closest('[data-form]').attr("data-form");
        var tab = $(e.target).attr("data-target");
        $.SetLastTab(formName, tab);
    })

    this.qControlLoaded = true;
};

QTabControl.prototype.Hide = function (isHidden) {
    var ulNavTabs = $(this.element).parent();
    var isTabVisible = $(this.element).is(':visible');
    var isTabActive = $(this.element).hasClass('active');
    var tabDivContent = $('div#' + $(this.element).attr('data-tab'));
    var indexOfTab = -1;
    var totalVisibleTabs = ulNavTabs.find('li:visible').length;
    if (isTabVisible && isTabActive && isHidden) {
        indexOfTab = jQuery.inArray($(this.element)[0], ulNavTabs.find('li:visible'));
        indexOfTab = (indexOfTab > 0 || totalVisibleTabs == 1 ? indexOfTab - 1 : indexOfTab);
        $(this.element).removeClass('active');
        tabDivContent.removeClass('active');
    }
    $(this.element).css('display', (isHidden ? 'none' : ''));
    if (totalVisibleTabs == 0 && !isHidden)
        indexOfTab = 0;
    if (indexOfTab != -1) {
        var tabToActivate = $(ulNavTabs.find('li:visible')[indexOfTab]);
        tabToActivate.addClass('active');
        $('div#' + tabToActivate.attr('data-tab')).addClass('active');
    }
};

//---------------------------------------------
// QDateControl
//---------------------------------------------
function QDateControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    this.hasDatetimepicker = false;

    this.dateElement = $(this.element).attr('elem-identifier');
    this.datetimepicker_format = $(this.element).data('datetimepicker-format');
    this.isHour = this.dateElement === 'TimePicker';
};

QDateControl.prototype = Object.create(QControl.prototype);

Object.defineProperty(QDateControl.prototype, 'Value', {
    set: function (val) {
        if (jQuery.type(val) === "string") {
            // Try convert C# string to JS date
            val = QUtils.tryParseDate(val, this.isHour);
        }

        var eValue = false, a = this.value, b = val;
        if (jQuery.type(a) === "date") { a = a.toQString(); }
        else if (moment.isMoment(a)) { a = a.toDate().toQString(); }
        if (jQuery.type(b) === "date") { b = b.toQString(); }
        else if (moment.isMoment(b)) { b = b.toDate().toQString(); }

        eValue = (a !== b);
        if (eValue) {
            this.value = val;
            this.UpdateControlValue();
            this.TriggerChange();
        }
    },
    get: function () {
        this.ParseControlValue();
        return this.value;
    }
});

QDateControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    var curValue = $(this.element).val();
    if (curValue !== '' && this.hasDatetimepicker && this._datetimepicker !== undefined) {
        curValue = this._datetimepicker.date();
    }
    var dataFormat = $(this.element).attr("data-datetimepicker-format") || $(this.element).attr("data-format"); // datetimepicker => for correct Moment.js parsing
    if (curValue && moment.isMoment(curValue)) {
        this.value = new Date(curValue.format('YYYY'), curValue.format('M') - 1, curValue.format('D'), curValue.format('H'), curValue.format('m'), curValue.format('s'), curValue.format('SSS'));
    }
    else if (dataFormat) {
        this.value = QUtils.parseDate(curValue, dataFormat);
    } else this.value = curValue;

    if(this.isHour) {
        if (curValue && moment.isMoment(curValue)) {
            this.value = curValue.format("HH:mm");
        }
        else if (this.value === undefined || this.value === "" || this.value === null)
            this.value = "";
    }
};

QDateControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// Use UTC date only!
    /// </summary>
    //TODO: Move the next code to DBEditSelectedItem
    if (jQuery.type(this.value) === "string") {
        this.value = QUtils.tryParseDate(this.value, this.isHour);
    }

    if (this.hasDatetimepicker) {
        if (jQuery.type(this.value) === "date"  || moment.isMoment(this.value)) {
            if (this._datetimepicker !== undefined) {
                this._datetimepicker.date(this.value);
            }
            else {
                $(this.element).parent().datetimepicker('setDate', this.value);
            }
        }
        else {
            this.value = "";
            $(this.element).val("");
        }
    }
    else {
        var textValue = this.value;
        var dataFormat = $(this.element).attr("data-format");
        if (dataFormat && jQuery.type(this.value) === "date") {
            textValue = QUtils.formatDate(textValue, dataFormat);
        }
        $(this.element).val(textValue);
    }
};

QDateControl.prototype.Init = function () {
    var _this = this,
        useCurrent = (_this.dateElement === 'DatePicker') ? 'day' : true;
    switch (_this.dateElement) {
        case 'DatePicker':
        case 'DatetimePicker':
        case 'DatetimesecPicker':
        case 'TimePicker':
            _this._datetimepicker = $(_this.element).parent().datetimepicker({
                format: _this.datetimepicker_format,
                locale: moment.locale(),
                timeZone: 'Etc/UTC',/* Etc/UCT ? (w/ Daylight Saving Time (DST)) */
                useCurrent: useCurrent
            }).data('DateTimePicker');
            _this.hasDatetimepicker = true;
            break;
        default:
            return false;
    }

    _this.ParseControlValue();
    _this.originalValue = _this.value;
    _this.qControlLoaded = true;
};

QDateControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    $(this.element).trigger("liszt:updated");
    if (this._datetimepicker) {
        if (this._block.isBlocked())
            this._datetimepicker.disable();
        else
            this._datetimepicker.enable();
    }
    $(this.element).parent().find('input').prop('disabled', false);
};

//---------------------------------------------
// QCheckBoxControl
//---------------------------------------------
function QCheckBoxControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    // Empty value of the field (used in the FillWhen)
    this._emptyValue = 0;
};

QCheckBoxControl.prototype = Object.create(QControl.prototype);

QCheckBoxControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    var curValue = $(this.element).val();
    if ($(this.element).is(":checkbox")) {
        this.value = $(this.element).is(":checked") ? 1 : 0; // CheckBox visivel
    }
    else if (curValue == 'true' || curValue == 'True' || curValue === true) { //CheckBox invisivel
        this.value = 1;
    }
    else if (curValue == 'false' || curValue == 'False' || curValue === false) { //CheckBox invisivel
        this.value = 0;
    }
};

QCheckBoxControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    var isChecked = (this.value == 1 || this.value == true || this.value == 'true' || this.value == 'True') ? true : false;
    if ($(this.element).is(":checkbox")) {
        $(this.element).prop('checked', isChecked);
    }
        //CheckBox invisivel //TODO: Mudar para 0/1
    else if (isChecked) { $(this.element).val("True"); }
    else { $(this.element).val("False"); }
};

QCheckBoxControl.prototype.Init = function () {
    var readonly = $(this.element).attr('readonly');
    if (readonly && readonly.toLowerCase() !== 'false') { this.Block("ReadOnly", true); }
    this.ParseControlValue();
    this.originalValue = this.value;
    this.qControlLoaded = true;

    $(this.element).focus(function () {
        $(this).closest('Label').addClass("checkfocus")
    })

    $(this.element).blur(function () {
        $(this).closest('Label').removeClass("checkfocus")
    })
};

QCheckBoxControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    $(this.element).attr('disabled', this._block.isBlocked());
};

//---------------------------------------------
// QNumericControl
//---------------------------------------------
function QNumericControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    // Empty value of the field (used in the FillWhen)
    this._emptyValue = 0;
};

QNumericControl.prototype = Object.create(QControl.prototype);

/**
 * To prevent failures in comparing the original value, where in Decimals from the latest versions 
 *  it appears as 0 in the initial request for New, but after reloading it appears as 0.00.
 *  The numeric value will be returned directly instead of the string (in the normal form fields).
 */
Object.defineProperty(QNumericControl.prototype, 'renderedValue', {
    get: function () {
        // Check if the element exists
        if (!this.element[0]) return undefined;

        // Try to get the 'original-value' attribute
        let originalValue = this.element.attr('original-value');
        if (originalValue !== undefined) {
            return parseFloat(originalValue);
        }

        // Try to get the 'value' attribute
        originalValue = this.element.attr('value');
        if (originalValue !== undefined) {
            return originalValue;
        }

         // Return the value stored in data('value') as a fallback
        return this.element.data('value');
    }
});

QNumericControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    var tempVal = $(this.element).val();
    if (tempVal === undefined || tempVal == "") tempVal = 0;
    this.value = parseFloat(tempVal);
};

QNumericControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $(this.element).val(typeof this.value === 'number' ? { value: this.value } : this.value);
};

QNumericControl.prototype.Init = function () {
    var negativeNumberOpt = { 'translation': { 'N': { pattern: /-/, optional: true } } };
    
    /**
     * We cannot use "$.val()" which is used by "ParseControlValue" before initializing the plugins because 
     *  if non-standard formatting is used, it will initialize the ".value" with the incorrect value and then 
     *  create problems in the recalculation of formulas, especially for defaults that have already been modified by the user. 
     * e.g: The value in persistence will be numeric with decimal places, and the parsed value might not have them, 
     *  leading to a false ChangeEvent and recalculating the formulas.
     * However, the control can be initialized on a field that is not a normal form control.
     */
    var tempVal = $(this.element).attr("original-value");
    if (typeof tempVal === 'undefined') tempVal = $(this.element).val();
    if (tempVal === undefined || tempVal == "") tempVal = 0;
    this.value = parseFloat(tempVal);

    this.originalValue = this.value;

    if (this.isSequencial && this.value < 0) {
        this.CleanSequentials();
    }

    if ($(this.element).is('[data-masking]') && !$(this.element).is('[data-number-format]')) {
        var format = $(this.element).attr("data-masking");
        $(this.element).mask("N" + format, negativeNumberOpt);

    }
    else if ($(this.element).is('[data-number-format]')) {
        $(this.element).number(true, $(this.element).attr('data-number-decimals'), $(this.element).attr('data-decimal-sep'), $(this.element).attr('data-group-sep'), $(this.element).attr('data-number-integer'));
    }
    // Auto seleção do valor dos campos númericos
    $(this.element).focus(function () { $(this).select(); }).mouseup(function(e) {e.preventDefault();});

    this.qControlLoaded = true;
};

//---------------------------------------------
// QTextControl
//---------------------------------------------
function QTextControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QTextControl.prototype = Object.create(QControl.prototype);

QTextControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).val();
};

QTextControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $(this.element).val(this.value);
};

QTextControl.prototype.Init = function () {
    if ($(this.element).is('.zipCodePT')) {
        $(this.element).mask('9999-999');
    }
    else if ($(this.element).is('.Nif')) {
        $(this.element).mask('999999999');
    }
    else if ($(this.element).is('.Niss')) {
        $(this.element).mask('99999999999');
    }
    else if ($(this.element).is('.Nib')) {
        $(this.element).mask('9999-9999-99999999999-99');
    }
    else if ($(this.element).is('.Iban')) {
        $(this.element).mask('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', { 'translation': { A: { pattern: /[A-Za-z0-9]/ } } });
    }
    else if ($(this.element).is('.carPlatePT')) {
        $(this.element).mask('AA-AA-AA', { 'translation': { A: { pattern: /[A-Za-z0-9]/ } } });
    }

    this.value = $(this.element).val();
    this.originalValue = this.value;

    if (this.isSequencial && this.value.indexOf('-') !== -1) {
        this.CleanSequentials();
    }

    this.qControlLoaded = true;
};

//---------------------------------------------
// QQRcodeControl
//---------------------------------------------
function QQRcodeControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QQRcodeControl.prototype = Object.create(QControl.prototype);

QQRcodeControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>

    var img = $(this.element).find('img');
    this.value = img.attr('data-orig')

    $.ajax({
        url: quidgestGlobals.UrlAction.StringToQRcode,
        type: 'GET',
        data: { text: this.value },
        success: function (response) {
            if (response.Success) {
                const bytes = response.Value;
                if (bytes.length > 0) {
                    img.attr("src", "data:image;base64," + bytes);
                }
                else {
                    let emptyQrImg = window.applicationBaseUrl + "Content/img/empty-qr.png";
                    img.attr("src", emptyQrImg);
                }
            }
        },
        error: function (error) {
            console.error(error);
        }
    });
};

QQRcodeControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $(this.element).find('img').attr('data-orig', this.value);
};

QQRcodeControl.prototype.Init = function () {
    this.value = $(this.element).find('img').attr('data-orig');
    this.originalValue = this.value;
    this.qControlLoaded = true;
};

//---------------------------------------------
// QPasswordControl
//---------------------------------------------
function QPasswordControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
    this.FieldContainer = null;
    this.IconId = "#passwordtoggle";
    this.show = false;
    this.hideIcon = "glyphicons glyphicons-eye-close";
    this.ShowIcon = "glyphicons glyphicons-eye-open";

};

QPasswordControl.prototype = Object.create(QControl.prototype);

QPasswordControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).val();
};

QPasswordControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $(this.element).val(this.value);
};

QPasswordControl.prototype.Init = function () {
    var _this = this;
    this.value = $(this.element).val();
    this.FieldContainer = this.element.closest('span');

    $(this.FieldContainer).click(function () {
        var readonly = $(_this.element).attr('readonly');
        if (readonly != 'readonly') {
            _this.TogglePassword();
        }
    });

    this.qControlLoaded = true;
};

QPasswordControl.prototype.TogglePassword = function () {
    if (this.show) {
        $(this.element).attr('type', 'password');
        $(this.IconId, this.FieldContainer).removeClass(this.hideIcon)
        $(this.IconId, this.FieldContainer).addClass(this.ShowIcon)
        this.show = false;
    }
    else {
        $(this.element).attr('type', 'text');
        $(this.IconId, this.FieldContainer).removeClass(this.ShowIcon)
        $(this.IconId, this.FieldContainer).addClass(this.hideIcon)
        this.show = true;
    }
};

QPasswordControl.prototype.Block = function (blockType, isBlocked) {

    // Hide password (if needed) before disabling the input field.
    if (this.show)
        this.TogglePassword()

    QControl.prototype.Block.call(this, blockType, isBlocked);
};

//---------------------------------------------
// QHiddenControl
//---------------------------------------------
function QHiddenControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QHiddenControl.prototype = Object.create(QControl.prototype);

QHiddenControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $(this.element).val();
};

QHiddenControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $(this.element).val(this.value);
};

QHiddenControl.prototype.Init = function () {
    this.ParseControlValue();
    this.originalValue = this.value;

    //if ($(this.element).attr('trelate')) this.trelate = $(this.element).attr('trelate').toLowerCase();
    //if ($(this.element).attr('tfrelate')) this.tfrelate = $(this.element).attr('tfrelate').toLowerCase();

    this.qControlLoaded = true;
};

//---------------------------------------------
// QGenericControl
//---------------------------------------------
function QGenericControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QGenericControl.prototype = Object.create(QControl.prototype);

QGenericControl.prototype.ParseControlValue = function () {
    this.value = $(this.element).val();
};

QGenericControl.prototype.UpdateControlValue = function () {
    $(this.element).val(this.value);
};

QGenericControl.prototype.Init = function () {
    this.ParseControlValue();
    this.originalValue = this.value;
    this.qControlLoaded = true;
};

//---------------------------------------------
// QRadioButtonArrayControl
//---------------------------------------------
function QRadioButtonArrayControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QRadioButtonArrayControl.prototype = Object.create(QControl.prototype);

QRadioButtonArrayControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    this.value = $("input:checked", this.element).val();

    var isNumericArray = ($(this.element).data('array-type') === "AN");
    if (isNumericArray) {
        // Numeric array
        if (this.value && this.value !== "" && jQuery.type(this.value) === "string") {
            this.value = parseFloat(this.value);
        }
    }

    if (this.value === undefined || (isNumericArray && isNaN(this.value))) this.value = "";
};

QRadioButtonArrayControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    $('[value="' + this.value + '"]', this.element).prop("checked", true);
};

QRadioButtonArrayControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    $(this.element).prop('disabled', isBlocked);
};

QRadioButtonArrayControl.prototype.Init = function () {
    $(this.element).uncheckableRadio();
    //init value
    this.ParseControlValue();
    this.originalValue = this.value;

    $(this.element).focus(function () {
        $(this).closest('Label').addClass("checkfocus")
    })

    $(this.element).blur(function () {
        $(this).closest('Label').removeClass("checkfocus")
    })

    this.qControlLoaded = true;
};

//---------------------------------------------
// QCheckListControl
//---------------------------------------------
function QCheckListControl(element, qParentForm, url) {
    QControl.call(this, element, qParentForm);
    this.UrlReloadAction = url;
    this.Limits = [];
};

QCheckListControl.prototype = Object.create(QControl.prototype);

QCheckListControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
    var checkListItems = new Array();

    $.each($(this.element).find('input[data-checklist="true"]:checked'), function (i, element) {
        checkListItems.push($(element).val());
    });

    this.value = checkListItems;
};

QCheckListControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
    //TODO: Implement setVelue
};

QCheckListControl.prototype.Init = function () {
    this.ParseControlValue();
    this.originalValue = this.value;
    // TODO: Change it to get the correct field name without «_SelectedIds»
    this.CheckListName = $(this.element).find('input[data-checklist="true"]').first().attr('name');

	$('input[data-checklist="true"]', $(this.element)).focus(function () {
        $(this).closest('Label').find('span').addClass("checkfocus")
    });

    $($('input[data-checklist="true"]', this.element)).blur(function () {
        $(this).closest('Label').find('span').removeClass("checkfocus")
    });

    this.qControlLoaded = true;
};

QCheckListControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    var _controlIsBlocked = this._block.isBlocked();

    $('input', this.element).prop('disabled', _controlIsBlocked).attr('disabled', _controlIsBlocked).prop('readonly', _controlIsBlocked).attr('readonly', _controlIsBlocked);

    if (_controlIsBlocked) {
        $('.i-checkbox', this.element).addClass('i-checkbox--disabled')
    } else {
        $('.i-checkbox', this.element).removeClass('i-checkbox--disabled')
    }
};


QCheckListControl.prototype.AddLimit = function (control, type) {
    this.Limits.push({ field: control, type: type });
    control.changeEventSink.push({ object: this, function: 'ReloadChecklistContent' });
};

QCheckListControl.prototype.ReloadChecklistContent = function () {
    if(this.UrlReloadAction !== undefined && this.UrlReloadAction !== "") {
        $.when(syncFormKeys(this._parentForm), this).done(function(result, qControl){
            $.get(qControl.UrlReloadAction, { partialView: qControl.element.attr('id') }, function( data ) {
                $(qControl.element).html(data);
                //TODO: Clearn selected elemets
            });
        });
    }
}

//---------------------------------------------
// QRichTextControl
//---------------------------------------------
function QRichTextControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QRichTextControl.prototype = Object.create(QControl.prototype);

QRichTextControl.prototype.ParseControlValue = function () {
    var nameIdentifier = '[name="' + this.fieldName + '"]';
    if ($(this.element).find(nameIdentifier).length != 0)
    {
        var _text = $(this.element).find(nameIdentifier).text(),
            _tinymceLoaded = (window.parent.tinymce !== undefined && window.parent.tinymce.get(this.fieldName) !== undefined);

        if (_tinymceLoaded) //Some times (on first document load) the "tinymce" is not initialized yet.
            this.value = window.parent.tinymce.get(this.fieldName).getContent();

        // TinyMCE can be loaded by not yet completly initialized
        if (!_tinymceLoaded || (_tinymceLoaded && $.isEmptyObject(this.value) && !$.isEmptyObject(_text)))
            this.value = _text;
    }
    else
        this.value = $(this.element).html();
};

QRichTextControl.prototype.UpdateControlValue = function () {
    if ($(this.element).find('textarea').length != 0) //TODO: any other Id ? (textarea)
        window.parent.tinymce.get(this.fieldName).setContent(this.value);
    else
         $(this.element).html(this.value);
};

QRichTextControl.prototype.Init = function () {
    this.fieldName = $(this.element).data('field-name');
    this.ParseControlValue();
    this.originalValue = this.value;
    // TEMPORARY BUGFIX
    // getInputsForNestedForm can't get textarea value
    $(this.element.find('textarea')).data("QObject", this);
    this.qControlLoaded = true;
};

//---------------------------------------------
// QButtonControl
//---------------------------------------------
function QButtonControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QButtonControl.prototype = Object.create(QControl.prototype);

QButtonControl.prototype.Init = function () {
    this.UpdateOpenFormAction();
    this.qControlLoaded = true;
};

QButtonControl.prototype.Block = function (blockType, isBlocked) {
    QControl.prototype.Block.call(this, blockType, isBlocked);
    var _controlIsBlocked = this._block.isBlocked();
    $(this.element).prop('disabled', _controlIsBlocked).attr('disabled', _controlIsBlocked);
	if (_controlIsBlocked)
		$(this.element).addClass('b-icon-text--disabled');
	else
		$(this.element).removeClass('b-icon-text--disabled');
};

QButtonControl.prototype.UpdateOpenFormAction = function () {
    var elem = $(this.element),
        isOpenFormAction = elem.data('btn-open-form');
    /*
        Buttons for form.
        The key value for the form can be dynamic.
        For not to use the logic of replaces with placeholder, the button will make request to the server to obtain the new URL.
    */
    if (isOpenFormAction) {
        elem.off('click').click(function (event) {
            event.preventDefault();
            event.stopPropagation();

            var _this = this,
                elem = $(event.target),
                controller = elem.data('form-area'),
                formName = elem.data('form-name'),
                keyField = elem.data('form-key'),
                keyFieldControl = $('[data-identifier="' + keyField + '"]'),
                keyFieldQControl = keyFieldControl.getQControl(),
                keyValue = (keyFieldQControl || {}).Value,
                isPopup = elem.data('form-is-popup'),
                formMode = elem.data('form-mode'),
                routeParam = formMode === "NEW" ? {} : { id: keyValue };

            if ($.isEmptyObject(keyValue) && formMode !== "NEW")
                return;

            $.when(QUtils.GetUrlToAction(controller, formName, routeParam))
                .done(function (res) {
                    var url = res.url;
                    url = __updateQSNav(url, elem);
                    elem.attr('href', url);

                    if (isPopup) {
                        elem.data('modal-form-mode', formMode);
                        modalFormsBtnOnClickCallback.call(_this, event);
                    }
                    else {
                        onNavigation.call(_this, event, elem[0], formMode);
                    }
                });
        });
    }
};

//---------------------------------------------
// QImageControl
//---------------------------------------------
function QImageControl(element, qParentForm, deleteAction, editAction, isEmptyImg) {
    QControl.call(this, element, qParentForm);

    this.DeleteAction = deleteAction !== undefined ? deleteAction : '';
    this.EditAction = editAction !== undefined ? editAction : '';
    this.isEmpty = isEmptyImg;

    this.imgControl = $('[elem-identifier="image-control"]', $(element));
    this.imgControlImg = $('[elem-identifier="image-control-img"]', $(element));
    this.imgControlMagnify = $('[elem-identifier="image-control-magnify"]', $(element));

    this.FieldName = '';
    this.FormIdentifier = '';
    this.ModelName = '';
    this.fileUploaderElement;
    this.deleteBtnId = this.controlIdentifier + '_Delete';
    this.editBtnId = this.controlIdentifier + '_Edit';
};

QImageControl.prototype = Object.create(QControl.prototype);

Object.defineProperty(QImageControl.prototype, 'Value', {
    set: function (val) {
        this.imgControlImg.attr('src', (val || '').length !== 0 ? val : '/Content/img/unknown.png');
        this.imgControlMagnify.attr('href', (val || '').length !== 0 ? val : '/Content/img/unknown.png');
        this.value = val;
    },
    get: function () {
        return this.imgControlImg.attr('src') || '';
    }
});

Object.defineProperty(QImageControl.prototype, 'RowId', {
    get: function () {
        if (this.area != this.ParentForm.baseArea) {
            var fkIdentifier = $(this.RowIdSelector).data('identifier');
            if (!this.ParentForm.Controls) {
                this.ParentForm.Controls = {};
                this.ParentForm.DeclareControls();
            }
            return this.ParentForm.Controls[fkIdentifier].Value;
        }
        else
            return this.ParentForm.PrimaryKey !== undefined ? this.ParentForm.PrimaryKey.Value : $('input[form-area]', this.ParentForm.element).val();
    }
});

Object.defineProperty(QImageControl.prototype, 'ImageTicket', {
    set: function (val) {
        this.imgControlImg.attr('img-ticket', val || '');
    },
    get: function () {
        return this.imgControlImg.attr('img-ticket') || '';
    }
});

QImageControl.prototype.Init = function () {
    var _this = this;
    if (_this.element.length == 0) return;

    _this.FieldName = "Val" + CapFirst(_this.field);
    _this.FormIdentifier = "F" + _this.ParentForm.element.data('form').toUpperCase();
    _this.ModelName = CapFirst(_this.area);

    _this.RowIdSelector = $('input[form-area]', _this.ParentForm.element);
    if (_this.area != _this.ParentForm.baseArea) {
        var formKeys = _this.ParentForm.getAllForeignKeySelectors();
        if (!$.isEmptyObject(formKeys[_this.area.toLowerCase()])) { // Form em Show mode
            _this.RowIdSelector = formKeys[_this.area.toLowerCase()];
            // Auto update on change foreign key
            var fkId = $(_this.RowIdSelector).attr('id').toUpperCase();
            $(document).on(fkId + '_CHANGE', function () { _this.UpdateSrc.call(_this); });
        }
    }

    _this.imgControlImg.one("load", function () {
        _this.imgControlImg.ready(function () {
			//_this.UpdateMargin();//Margins not used anymore. Caused problems with other CSS.
            _this.imgControlImg.unbind();
        });
    }).each(function () {
        if (this.complete) {
            $(this).trigger('load');
        }
    });

    _this.fileUploaderElement = $('#file-uploader_' + _this.FieldName, _this.element);
    if (_this.fileUploaderElement.length == 0) { _this.qControlLoaded = true; return; }

    _this.CreateFileUploader();
    _this.originalValue = _this.Value;
    _this.qControlLoaded = true;
};

QImageControl.prototype.SetMargin = function (top, left) {
    console.log("New image margin Top: " + top + " Left: " + left);
    this.imgControlImg.css({
        'margin-top': (top || 0) + '%',
        'margin-left': (left || 0) + '%'
    });
};

QImageControl.prototype.GetMargin = function () {
    var res = { Top: 0, Left: 0 };

    var imageHeight = this.imgControlImg.height(), imageWidth = this.imgControlImg.width();
    var containerHeight = this.imgControl.height(), containerWidth = this.imgControl.width();

    if (imageHeight != 0 && containerHeight > imageHeight) {
        res.Top = (((containerHeight - imageHeight) / 2) * 100) / containerHeight;
    }

    if (imageWidth != 0 && containerWidth > imageWidth) {
        res.Left = (((containerWidth - imageWidth) / 2) * 100) / containerWidth;
    }

    return res;
};

QImageControl.prototype.UpdateMargin = function() {
    var newMargin = this.GetMargin();
    this.SetMargin(newMargin.Top, newMargin.Left);
};

QImageControl.prototype.UpdateSrc = function () {
    $.when(syncFormKeys(this._parentForm), this).done(function (_, qControl) {
        if (!isEmpty(qControl.ImageTicket)) {
            var actionUrl = quidgestGlobals.UrlAction.RefreshImageTicket;
            const url = __updateQSNav(actionUrl, qControl.element)
            $.ajax({
                type: 'GET',
                url,
                data: { ticket: qControl.ImageTicket },
                success: function (data) {
                    if (data?.success) {
                        qControl.ImageTicket = data.ticket;

                        var url = quidgestGlobals.UrlAction.ImageHandlerGet;
                        url += "?ticket=" + qControl.ImageTicket;
                        url += "&formIdentifier=" + qControl.FormIdentifier;
                        //add a random number in the link to avoid cache
                        url += "&nocache=" + (Math.floor(Math.random() * 100000));

                        qControl.Value = url;
                    }
                    else {
                        qControl.Value = "";
                    }
                },
                error: function () {
                    qControl.Value = "";
                }
            });
        }
        else {
            qControl.Value = "";
        }
    });
};

QImageControl.prototype.CreateFileUploader = function () {
    var Template = '<div class="qq-uploader" style="margin-top:8px;">' +
        '<div class="qq-upload-drop-area"><span>Drop files here to upload</span></div>' +
        '<div elem-identifier="BtnGroup" class="b-btn-group">' +
        '<div class="qq-upload-button b-icon-text b-icon-text--secondary" role="button">' + quidgestGlobals.Resources.SUBMETER + '</div>';
    Template += '<div id="' + this.editBtnId + '" class="b-icon-text b-icon-text--secondary ' + (this.isEmpty ? 'hidden' : '') + '" tabindex="0" role="button">' + quidgestGlobals.Resources.EDITAR + '</div>';
    if(this.DeleteAction !== '')
		Template += '<div id="' + this.deleteBtnId + '" class="b-icon-text b-icon-text--secondary ' + (this.isEmpty ? 'hidden' : '') + '" tabindex="0" role="button">' + quidgestGlobals.Resources.APAGAR + '</div>';
    Template += '</div>' +
        '<ul class="qq-upload-list"></ul>' +
        '</div>';
    var jQueryElement = this;
    this.FileUploader = new qq.FileUploader({
        element: jQueryElement.fileUploaderElement[0],
        action: quidgestGlobals.UrlAction.ImageHandlerPut,
        multiple: false,
        allowedExtensions: ['jpg', 'jpeg', 'png', 'gif', 'svg'],
        messages: {
            typeError: '{file} - ' + quidgestGlobals.Resources.EXTENSAO_INVALIDA + ' {extensions}',
            sizeError: '{file} - ' + quidgestGlobals.Resources.FICHEIRO_DEMASIADO_GRANDE + ' {sizeLimit}'
        },
        params: { id: jQueryElement.RowId, modelname: jQueryElement.ModelName, fldname: jQueryElement.FieldName, formIdentifier: jQueryElement.FormIdentifier },
        template: Template,
        onSubmit: function (id, fileName) {
            $('div.preview').addClass('loading');
            $(jQueryElement.element.find('img')).on("load", function () {
                $('div.preview').removeClass('loading');
                $(jQueryElement.element.find('img')).unbind();
                $(jQueryElement.element).ready(function () {
					//jQueryElement.UpdateMargin.call(jQueryElement);//Margins not used anymore. Caused problems with other CSS.
                    $(jQueryElement.element).unbind();
                });
            });
            jQueryElement.isEmpty = false;
            $(jQueryElement.element).find('#' + jQueryElement.deleteBtnId).removeClass('hidden')
                .off('click').on('click', jQueryElement, function (e) {
                    var qControl = e.data;
                    qControl.DeleteImage();
                });

            $(jQueryElement.element).find('#' + jQueryElement.editBtnId).removeClass('hidden')
                .off('click').on('click', jQueryElement, function (e) {
                    var qControl = e.data;
                    qControl.EditImage();
                });
        },
        onComplete: function (id, fileName, responseJSON) {
            jQueryElement.UpdateSrc();
        },
        showMessage: function (message, status) {
            displayMessage(message, status);
        }
    });

    $(jQueryElement.element).find("input[name='file']").attr("aria-hidden", "true"); // hides the element to screen readers for better accessibility
    $(jQueryElement.element).find('#' + jQueryElement.deleteBtnId)
        .off('click').on('click', jQueryElement, function (e) {
            var qControl = e.data;
            qControl.DeleteImage();
        });
    $(jQueryElement.element).find('#' + jQueryElement.editBtnId)
        .off('click').on('click', jQueryElement, function (e) {
            var qControl = e.data;
            qControl.EditImage();
        });
	/*FIX FOR KEYBOARD ACCESSIBILITY*/
	$(jQueryElement.element).find('#' + jQueryElement.deleteBtnId)
        .off('keypress').on('keypress', jQueryElement, function (e) {
            if(e.which == 13) {
				var qControl = e.data;
				qControl.DeleteImage();
			}
        });
    $(jQueryElement.element).find('#' + jQueryElement.editBtnId)
        .off('keypress').on('keypress', jQueryElement, function (e) {
            if (e.which == 13) {
                var qControl = e.data;
                qControl.EditImage();
            }
        });
};

QImageControl.prototype.DeleteImage = function () {
    var qControl = this;
    $.ajax({
        type: 'POST',
        url: qControl.DeleteAction,
        contentType: 'application/json',
        dataType: "json",
        success: function (data) {
            $("#" + qControl.deleteBtnId).addClass('hidden');
            $("#" + qControl.editBtnId).addClass('hidden');
            qControl.isEmpty = true;
            qControl.UpdateSrc();
        },
        traditional: true
    });
};

QImageControl.prototype.EditImage = function () {
    if ($("#ImageCropper-form-modal").length === 0)
        $('<div id="ImageCropper-form-modal" class="modal container-fluid hide" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="a-index: 50000;"></div>').appendTo('body');
    var formModal = $("#ImageCropper-form-modal");
    $(formModal).on('show.bs.modal', function () {
        $('[elem-identifier="ModalBody"]').css('overflow-y', 'auto');
        $('[elem-identifier="ModalBody"]').css('max-height', $(window).height() * 0.7);
    });
    $(formModal).html("");
    $(formModal).modal();
    $(formModal).addClass({
        show: true
    });
    $(formModal).data("open", true);

    $.ajax({
        url: this.EditAction,
        type: "GET",
        success: function (data) {
            try {
                $(formModal).removeClass("loading");
                $(formModal).html(data);
                $(formModal).modal({
                    show: true
                });
            } catch (err) { console.error(err); }
        }
    });
};

//---------------------------------------------
// QTableListControl
//---------------------------------------------
function QTableListControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QTableListControl.prototype = Object.create(QControl.prototype);

Object.defineProperty(QTableListControl.prototype, 'controlId', {
    get: function () {
        return this.element.find('table').attr('id');
    }
});

QTableListControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
};

QTableListControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
};

QTableListControl.prototype.Reload = function () {
    if (this.controlId !== undefined && window[this.controlId] !== undefined && window[this.controlId].Reload !== undefined) {
        window[this.controlId].Reload();
    }
};

//---------------------------------------------
// QTreeListControl
//---------------------------------------------
function QTreeListControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QTreeListControl.prototype = Object.create(QControl.prototype);

QTreeListControl.prototype.ParseControlValue = function () {
    /// <summary>
    /// Parses the html to extract the value
    /// </summary>
};

QTreeListControl.prototype.UpdateControlValue = function () {
    /// <summary>
    /// Updates the html according to value
    /// </summary>
};

QTreeListControl.prototype.Init = function () {
    this.qControlLoaded = true;
};

//---------------------------------------------
// QSpecialControl
//---------------------------------------------
function QSpecialControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QSpecialControl.prototype = Object.create(QControl.prototype);

Object.defineProperty(QSpecialControl.prototype, 'Value', {
    set: function (val) {
        if (jQuery.type(val) === "string") {
            var patternCSharp = /Date\(([^)]+)\)/,
                patternJSON = /(\d{4}-\d{2}-\d{2})[T](\d{2}:\d{2}:\d{2}.?(\d{3})?)[Z]?/,
                patternHour = /([01]\d|2[0-3]):([0-5]\d)/;
            var isHour = patternHour.test(val);
            var valWithoutHour = val.replace(patternHour, '');
            if ((isHour && valWithoutHour=="") || patternJSON.test(val) || patternCSharp.test(val)) {
                //Try convert C# string to JS date
                val = QUtils.tryParseDate(val, isHour);
                if (val && moment.isMoment(val)) {
                    val = new Date(val.format('YYYY'), val.format('M') - 1, val.format('D'), val.format('H'), val.format('m'), val.format('s'), val.format('SSS'));
                }
            }
        }

        var eValue = false, a = this.value, b = val;
        if (jQuery.type(a) === "date") { a = a.toQString(); }
        else if (moment.isMoment(a)) { a = a.toDate().toQString(); }
        if (jQuery.type(b) === "date") { b = b.toQString(); }
        else if (moment.isMoment(b)) { b = b.toDate().toQString(); }

        eValue = (a !== b);
        if (eValue) {
            this.value = val;
            this.UpdateControlValue();
            this.TriggerChange();
        }
    },
    get: function () {
        this.ParseControlValue();
        return this.value;
    }
});

QSpecialControl.prototype.Init = function () {
    this.qControlLoaded = true;
};

QSpecialControl.prototype.InitData = function (data) {
    if (jQuery.type(data) === "string") {
        var patternCSharp = /Date\(([^)]+)\)/,
            patternJSON = /(\d{4}-\d{2}-\d{2})[T](\d{2}:\d{2}:\d{2}.?(\d{3})?)[Z]?/,
            patternHour = /([01]\d|2[0-3]):([0-5]\d)/;
        var isHour = patternHour.test(data);
        if (isHour || patternJSON.test(data) || patternCSharp.test(data)) {
            //Try convert C# string to JS date
            data = QUtils.tryParseDate(data, isHour);
            if (data && moment.isMoment(data)) {
                data = new Date(data.format('YYYY'), data.format('M') - 1, data.format('D'), data.format('H'), data.format('m'), data.format('s'), data.format('SSS'));
            }
        }
    }
    this.value = data;
    this.originalValue = this.value;
};

//---------------------------------------------
// QStaticImageControl
//---------------------------------------------
function QStaticImageControl(element, qParentForm) {
    QControl.call(this, element, qParentForm);
};

QStaticImageControl.prototype = Object.create(QControl.prototype);

//---------------------------------------------
// Extention methods
//---------------------------------------------
(function ($) {
    $.fn.getQForm = function () {
        if (typeof this === "object" && this.length === 1 && this[0] instanceof QForm)
            return this[0];
        var _formVariableName = $(this).attr("QForm");
        if (_formVariableName !== undefined && window[_formVariableName] !== undefined) {
            return window[_formVariableName];
        }
        return;
    };

    $.fn.getQControl = function () {
        if ($(this).data("QObject") !== undefined) {
            return $(this).data("QObject");
        }
        return;
    };

    $.fn.getQTableList = function () {
        if ($(this).data("QMenuControl") !== undefined) {
            return $(this).data("QMenuControl");
        }
        return;
    };
}(jQuery));

//---------------------------------------------------------------------
//                          MENUS
//---------------------------------------------------------------------
// QMenuForm
//--------------------------------------------
function QMenuForm(element, formVarName) {
    var _thisForm = this;
    //underlying element of the form
    _thisForm.element = element;
    _thisForm.elementId = element.prop('id');
    //base area of the form
    _thisForm.baseArea = element.attr('area');
    //data
    _thisForm.Data = { RelationKeys: { } };
    //reference to QMenuForm
    _thisForm._formVariableName = formVarName;
    if (_thisForm._formVariableName !== undefined) {
        $(_thisForm.element).attr("QForm", _thisForm._formVariableName).data("QForm", _thisForm);
    }
    _thisForm.Type = QFormType.MENU;

    // Form loaded attribute - for web tests
    var getQMenuFormLoaded = function () {
        return $(_thisForm.element).attr("qform-loaded") || false;
    }, setQMenuFormLoaded = function (val) {
        $(_thisForm.element).attr("qform-loaded", val);
    };
    Object.defineProperty(_thisForm, 'qFormLoaded', { get: getQMenuFormLoaded, set: setQMenuFormLoaded });
    _thisForm.qFormLoaded = false;

    $(_thisForm.element).off('CHECK_QFORM_LOADED').on('CHECK_QFORM_LOADED', _thisForm, function (event) {
        var _thisForm = event.data;
        _thisForm.CheckQFormLoaded();
    });

    //events
    this.OnPreValida = function (mode, target) { return true; }

    //helps
    activateHelps(_thisForm);
};

QMenuForm.prototype.CheckQFormLoaded = function () {
    var _thisForm = this;
    //console.log("check menu form loaded", _thisForm);
    _thisForm.qFormLoaded = $(_thisForm.element).find('[qcontrol-loaded="false"]').length == 0;
};

QMenuForm.prototype.Init = function () {
    var _thisForm = this;
    if (_thisForm.isInitialized) return;
    _thisForm.isInitialized = true;

    $(_thisForm.element).trigger('FORM_LOADED', $(_thisForm.element));

    $(document).on("submit", _thisForm.element, function (event) {
        _thisForm.qFormLoaded = false;
    });

    //Activate tooltips for disabled buttons
    var options = {
        delay: { show: "1000" },
        trigger: 'hover',
        //Template is used to set the classes c-help and c-help__inner
        template: '<div class="tooltip c-help" role="tooltip"><div class="arrow"></div> <div class="tooltip-inner c-help__inner"></div></div> '
    };
    $('[data-toggle="tooltip"]').tooltip(options);

    _thisForm.CheckQFormLoaded();
    return _thisForm;
};

// QMenuControl (base class)
//---------------------------------------------
function QMenuControl(element) {
    /// <summary>
    /// Menu base control
    /// </summary>
    /// <param name="element">Reference to the main DOM element</param>
    var _this = this;
    //reference to the main DOM element
    _this.element = $(element);
    //Id of the control
    _this.controlId = $(_this.element).prop('id');
    //Reference to parent form object
    _this._parentForm = $(element).closest('form[data-form]');

    //reference to QMenuControl
    $(_this.element).data("QMenuControl", _this);

    // Form control loaded attribute - for web tests
    var getQMenuControlLoaded = function () {
        return $(_this.element).attr("qcontrol-loaded") || false;
    }, setQMenuControlLoaded = function (val) {
        $(_this.element).attr("qcontrol-loaded", val);
        if (_this._parentForm)
            $(_this._parentForm).trigger('CHECK_QFORM_LOADED');
    };
    Object.defineProperty(_this, 'qControlLoaded', { get: getQMenuControlLoaded, set: setQMenuControlLoaded });
    _this.qControlLoaded = false;

    $(_this.element).on('SET_QCONTROL_LOADED', _this, function (event, value) {
        var _this = event.data;
        //console.log("set control loaded", _this, value);
        _this.qControlLoaded = value;
    });

    handleQHelps(this.element);

    return _this;
};

QMenuControl.prototype = { };

//Abstract functions. The subclasses must allways redefine these
QMenuControl.prototype.Init = function () {
    var focusOnRecord = $(this.element).data('focus-record');
    if (focusOnRecord) {
        $(this.element).removeData('focus-record');
        var alertsError = $('.container-fluid.content > .alert-E, modal-header > .alert-E');
        if (alertsError.length == 0) {
            var row = $('tr[data-key~="' + $.trim(focusOnRecord) + '"]', $(this.element));
            // Remove the default animate and scroll to the row position
            if (this._parentForm) {
                var curLocalStorage = QLocalStorage.getLocalStorage('lastActiveElement');
                delete curLocalStorage[this._parentForm.data('form')];
                QLocalStorage.setLocalStorage('lastActiveElement', curLocalStorage);
            }
            if (row.length === 1) {
                var top = $(row).offset().top;
                if (!$('html, body').data('already-animated-scroll')) {
                    $('html, body').data('already-animated-scroll', true);
                    $('html, body').animate({ scrollTop: (top > 100) ? (top - 100) : top }, {
                        duration: 'slow',
                        always: function () {
                            $(row).addClass('blink-row');
                            setTimeout(function () { $(row).removeClass('blink-row'); }, 1000);
                        }
                    });
                }
            }
        }
    }

    handleQHelps(this.element);
    InitMagnificPopUp();

    this.qControlLoaded = true;
    return this;
};

//---------------------------------------------------------------------
// QMenuTableControl (base class)
//---------------------------------------------
function QMenuTableControl(element, isMultiSelection) {
    QMenuControl.call(this, element);

    this.Table = $(element); // TODO: Devia ser o 'table' ... rever o _refreshTableSelector
    var tempTableElem = $(this.Table);
    if(!$(this.Table).is('table')) { tempTableElem = $('table', this.Table); }
    this.TableId = $(tempTableElem).attr('id');

    this._isMultiSelection = isMultiSelection ? true : false;
    this._hasFollowUpAction = $(tempTableElem).data('has-follow-up-action') ? true : false;
    this._selectedKey = '';
    this._lastSelectedKey = '';
    return this;
};
QMenuTableControl.prototype = Object.create(QMenuControl.prototype);

QMenuTableControl.prototype._addCSS_Selected = function (row) {
    $(row).addClass("selected-row").data("selected", true);
    $('[elem-identifier="QTableCheckbox"] input:checkbox', row).prop('checked', true);
};

QMenuTableControl.prototype._removeCSS_Selected = function (row) {
    $(row).removeClass("selected-row").data("selected", false);
    $('[elem-identifier="QTableCheckbox"] input:checkbox', row).prop('checked', false);
};

QMenuTableControl.prototype.getRowByKey = function (key) {
    return $(this.Table).find('tbody tr[data-key~="' + $.trim(key) + '"]');
};

QMenuTableControl.prototype._addPreviousSelections = function () {
    var _this = this;
    $.each(this.getSelectionsKeys(), function (index, key) {
        _this._addCSS_Selected($(_this.Table).find('tr[data-key~="' + $.trim(key) + '"]'));
    });
    this._refreshSelectionsCounter();
};

QMenuTableControl.prototype.getSelections = function () {
    var tableIdentifier = this.TableId + QUtils.NavigationId;
    return QLocalStorage.getTableSelections(tableIdentifier);
};

QMenuTableControl.prototype.isAllSelected = function () {
    var tableIdentifier = this.TableId + QUtils.NavigationId;

    //Search for current table in the selected ones
    return QLocalStorage.getTableAllSelected(tableIdentifier);
};

QMenuTableControl.prototype.getLastSelections = function () {
    var tableIdentifier = this.TableId + QUtils.NavigationId;
    return QLocalStorage.getLastTableSelections(tableIdentifier);
};

QMenuTableControl.prototype.getSelectionsKeys = function () {
    return Object.keys(this.getSelections().Selections);
};

QMenuTableControl.prototype._refreshSelections = function () {
    var _this = this;
    var selections = _this.getSelections().Selections;
    $.each($(_this.Table).find('tbody tr'), function (i, row) {
        var _Id = $(row).data("key");
        if (!isEmpty(_Id)) {
            if (!isEmpty(selections[_Id])) { _this._addCSS_Selected($(row)); }
            else { _this._removeCSS_Selected($(row)); }
        }
    });
};

QMenuTableControl.prototype._refreshSelectionsCounter = function () {
    $(this.Table).parent().parent().find('.c-table__footer-out > [elem-identifier="Pagination"] > [elem-identifier="SelectedRecordsCounter"]').text(this.getSelectionsKeys().length);
};

QMenuTableControl.prototype._clearSelections = function (clearAll, id) {
    var tableIdentifier = this.TableId + QUtils.NavigationId;
    var objSel = this.getSelections();
    if (clearAll) {
        localStorage.setItem('TableSelections', '{}');
        localStorage.setItem('LastTableSelections', '{}');
    } else if (id) {
        if (objSel.Selections[id]) { delete objSel.Selections[id]; }
        QLocalStorage.setTableSelections(tableIdentifier, objSel);
    }
    this._refreshSelections();
    this._refreshSelectionsCounter();
    $(document).trigger(this.TableId + '_SELECTION_CHANGED');
};

QMenuTableControl.prototype._copyRowTDs = function (row) {
    var tds = '';
    $.each($(row).find('td:not(.row-actions, .checkable-column)'), function (i, td) {
        tds += $(td)[0].outerHTML;
    });
    return tds;
};

QMenuTableControl.prototype._shiftSelection = function (e, key) {
    if (e.shiftKey && !isEmpty(this.lastSelectedKey)) {
        var startRow = $(this.Table).find('tbody tr[data-key~="' + $.trim(this.lastSelectedKey) + '"]');
        var endRow = $(this.Table).find('tbody tr[data-key~="' + $.trim(key) + '"]');
        if (startRow && endRow) {
            var startIndex = startRow.index(), endIndex = endRow.index();
            if (startIndex >= 0 && endIndex >= 0) {
                var _this = this;
                var allTR = _this.Table.find('tbody tr');
                var toProcess = startIndex < endIndex ? allTR.slice(startIndex, endIndex + 1) : allTR.slice(endIndex, startIndex + 1);

                if (toProcess.length > 0) {
                    var objSel = _this.getSelections();
                    $.each(toProcess, function (i, row) {
                        var _Id = $(row).data("key");
                        if (!isEmpty(_Id)) {
                            if (isEmpty(objSel.Selections[_Id])) {
                                objSel.Selections[_Id] = _this._copyRowTDs($(row));
                                _this._addCSS_Selected($(row));
                                _this.Table.trigger('Q_ROW_CLICK', [{ key: _Id, row: $(row) }]);
                            }
                        }
                    });

                    var tableIdentifier = _this.TableId + QUtils.NavigationId;
                    QLocalStorage.setTableSelections(tableIdentifier, objSel);
                    _this._refreshSelectionsCounter();
                    _this._initCheckAll();
                    $(document).trigger(_this.TableId + '_SELECTION_CHANGED');
                }
            }
        }
    }
    else
        this.lastSelectedKey = key;
};

QMenuTableControl.prototype._refreshTableSelector = function () {
    this.Table = $(document).find(this.Table);
};

QMenuTableControl.prototype._getColumnsNumericInfo = function () {
    return $.map(this.Table.find('thead th:not([elem-identifier="TheadActions"]):not(.checkable-column)'), function (th) {
        return  {
            decimals: $(th).data('decimals') || 0,
            aggregationType: $(th).data('aggregation-type') || false
        };
    });
};

QMenuTableControl.prototype._getColumnsSum = function () {
    var columnsValues = {}, selections = this.getSelections().Selections;
    if (this._isMultiSelection && !isEmpty(selections)) {
        if ($(this.Table).has('thead tr:first th[elem-identifier="TheadNumeric"][data-aggregation-type]').length !== 0) {
            $.each(selections, function (_, row) {
                $.each($(row), function (i, td) {
                    var isNumeric = $(td).hasClass('c-table__cell-numeric');
                    if (!Array.isArray(columnsValues[i])) columnsValues[i] = [];
                    if (isNumeric) {
                        var value = '';
                        if ($(td).children().length === 0) value = $(td).text();
                        else if ($(td).children().length === 1) value = $(td).children().first().text();// Colunas com form de apoio
                        value = QUtils.ParseUIFloat(value);
                        if (!isNaN(value)) columnsValues[i].push(value);
                    }
                });
            });
        }
    }
    return columnsValues;
};

QMenuTableControl.prototype._getColumnsSumFooter = function (forExtendedTable) {
    var tableFooter = '';
    if (this._isMultiSelection && !this.isAllSelected()) {
        var columnsValues = this._getColumnsSum();
        if (Object.keys(columnsValues).length === 0) return '';

        var actionFirst = $(this.Table).find('thead tr:first th:not([elem-identifier="CheckableColumn"]):first').hasClass('thead-actions');
        var actionLast = $(this.Table).find('thead tr:first th:last').hasClass('thead-actions');

        var tds = '', tdsDetails = '', numericInfo = this._getColumnsNumericInfo(), numberFormat = quidgestGlobals.numberFormat;
        $.each(columnsValues, function (columnIdx, columnValues) {
            let value = '', details = '', columnInfo = numericInfo[columnIdx];

            try {
                if(columnInfo.aggregationType == "SUM_SEL") {
                    let totalValue = QUtils.calcAggregationFunction(columnValues, "SUM");
                    value = $.number(totalValue, columnInfo.decimals, numberFormat.numberDecimalSeparator, numberFormat.numberGroupSeparator);
                }

                /*if (columnInfo.aggregationType && columnInfo.aggregationType !== 'NONE') {
                    details += 'Sum: ' + value + '<br>';
                    let avg = QUtils.calcAggregationFunction(columnValues, "AVG");
                    avg = $.number(avg, columnInfo.decimals, numberFormat.numberDecimalSeparator, numberFormat.numberGroupSeparator);
                    details += 'Avg: ' + avg + '<br>';
                    details += 'Min: ' + QUtils.calcAggregationFunction(columnValues, "MIN") + '<br>';
                    details += 'Max: ' + QUtils.calcAggregationFunction(columnValues, "MAX") + '<br>';
                    details += 'Count: ' + QUtils.calcAggregationFunction(columnValues, "COUNT") + '<br>';
                }*/
            }
            catch(e) {
                console.error('On column aggregation', e, columnInfo, columnValues);
                details = '';
            }

            tds += '<td class="c-table__cell-numeric">' + value + '</td>';
            tdsDetails += '<td class="c-table__cell-numeric">' + details + '</td>';
        });

        if (!forExtendedTable) {
            if (actionLast) {
                tds = ' <td></td> ' + tds + '<td class="columnsSumTotalLabel columnsSumTotalRight" id="columnsSumLabel">' + quidgestGlobals.Resources.TOTAL + '</td> '
                tdsDetails += '<td></td>';
            }
            else if (actionFirst) {
                tds = '<td class="columnsSumTotalLabel columnsSumTotalLeft" id="columnsSumLabel">' + quidgestGlobals.Resources.TOTAL + '</td>  <td></td> ' + tds;
                tdsDetails = '<td></td>' + tdsDetails;
            }
        }
        else {
            tds += '<td class="columnsSumTotalLabel columnsSumTotalRight" id="columnsSumLabel">' + quidgestGlobals.Resources.TOTAL + '</td>';
            tdsDetails += '<td></td>';
        }

        tableFooter = '<tr class="columnsSum" id="columnsSum">' + tds + '</tr>';
        // tableFooter += '<tr class="columnsSum__details" id="columnsSumDetails">' + tdsDetails + '</tr>';
    }
    return tableFooter;
};

QMenuTableControl.prototype.getTotalRowCount = function () {
    let total = this.Table //Fetch the total record counter
        .find('[elem-identifier="Pagination"] > [elem-identifier="DbeditCounter"]')
        .text();

    if(!total){
        total = quidgestGlobals.Resources.ALL;
    }

    return total;
}

QMenuTableControl.prototype._selectCurrentAll = function () {
    var $this = this;

    var $rows = $this.Table.find('tbody tr');
    var objSel = $this.getSelections();

    $.each($rows, function (idx, row) {
        var rowKey = $(row).data("key");

        if (!isEmpty(rowKey)) {
            objSel.Selections[rowKey] = $this._copyRowTDs($(row));
            $this._addCSS_Selected(row);
        }
    });

    var tableIdentifier = $this.TableId + QUtils.NavigationId;
    QLocalStorage.setTableSelections(tableIdentifier, objSel);
    $this._refreshSelectionsCounter();
    $(document).trigger($this.TableId + '_SELECTION_CHANGED');
};

QMenuTableControl.prototype._selectAll = function () {
    this._selectCurrentAll(); //Check all from current page

    /* Change record counter */
    this.Table //Update current value
        .parent()
        .parent()
        .find('.c-table__footer-out > [elem-identifier="Pagination"] > [elem-identifier="SelectedRecordsCounter"]')
        .text(this.getTotalRowCount());
    /* --------------------- */
};

QMenuTableControl.prototype._initCheckAll = function () {
    var _this = this;

    const setAllSelected = (value) => {        
        var tableIdentifier = this.TableId + QUtils.NavigationId;
        QLocalStorage.setTableAllSelected(tableIdentifier, value);
    }

    /* Start all event listerners */
    var $ddpCurrentPage = $(this.Table).find('thead th.checkable-column #ddp_current_records');
    var $ddpAll = $(this.Table).find('thead th.checkable-column #ddp_all_records');
    var $ddpNone = $(this.Table).find('thead th.checkable-column #ddp_none');

    $ddpNone.off('click').click(_this, function (event) {
        //disable allSelected parameter
        if (_this.isAllSelected()) {
            setAllSelected(false);
            _this._enableAllChecks();
        }

        _this._clearSelections(true, undefined);
    });

    $ddpCurrentPage.off('click').click(_this, function (event) {
        //disable allSelected parameter
        if (_this.isAllSelected()) {
            setAllSelected(false);
            _this._enableAllChecks();
        }

        _this._selectCurrentAll();
    });

    $ddpAll.off('click').click(_this, function (event) {
        if (!_this.isAllSelected()) {
            setAllSelected(true);
            _this._selectAll();
            _this._disableAllChecks();
        }
    });

    /* -------------------------- */

    if (this.isAllSelected()){
        this._selectAll();
        this._disableAllChecks();
    }

    /*
    * This will position the dropdown outside the table container and move it
    * to the right coords. This fixes a clipping issue when there only 1 or 2 records
    */
    //Get table id
    var ddp = $('thead th.checkable-column #q-table-selector-dropdown', this.Table)[0];
    if(!ddp || !ddp.dataset) {
        //If the dropdown can't be found (this ended up happening a couple of time)
        //it will just render it inside the QTable and let bootstrap handle its open/close events
        return;
    }

    let tableid = ddp.dataset.ddpTableid;

    //Move ddp before table
    this.Table.before(ddp);

    //Get button position
    let ddp_button = $('thead th.checkable-column #' + tableid, this.Table)[0];

    const outsideClickHandler = function () {
        ddp.style.display = "none";

        $(window).off('click', outsideClickHandler);
    };

    //Add Listeners
    ddp_button.onclick = function (event) {
        /*
        * Bind dropdown events. Since we are moving the dropdown's location,
        * the Bootstrap JS will break, so we need to reimplement it
        */
        $(window).click(outsideClickHandler);
        
        //Show ddp
        ddp.style.display = "block";

        /* Move to position */        
        ddp.style.left = (ddp_button.offsetLeft + ddp_button.offsetWidth) + 'px';
        ddp.style.top = (ddp_button.offsetTop + (ddp.offsetHeight / 2) + ddp_button.offsetHeight) + 'px';
        /* ---------------- */

        event.stopPropagation();
    }
};

QMenuTableControl.prototype._disableAllChecks = function () {
    var $this = this;
    let checkboxes = $this.Table.find('tbody tr input[type="checkbox"]');

    for (let i = 0; i < checkboxes.length; i++) {
        checkboxes[i].disabled = true;
    }
};

QMenuTableControl.prototype._enableAllChecks = function () {
    var $this = this;
    let checkboxes = $this.Table.find('tbody tr input[type="checkbox"]');

    for (let i = 0; i < checkboxes.length; i++) {
        checkboxes[i].disabled = false;
    }
};

QMenuTableControl.prototype.Init = function () {
    this._lastSelectedKey = '';
    this._refreshTableSelector();
    this._addPreviousSelections();
    $(this.Table).find('tbody tr td').off('hover').off('click').hover(function () {
        $(this).css("cursor", "pointer");
    });
    var _this = this;
    if (this._isMultiSelection) {
        _this._initCheckAll();

        $(this.Table).find($('tbody tr td:not([elem-identifier="RowActions"])')).click(_this, function (event) {
            var _eTarget = $(event.target);
            // Click on the columns with the links will perform the own action.
            if (_eTarget.is('a')) { return; }

            event.preventDefault();
            event.stopPropagation();
            var _this = event.data;
            if (_this._hasFollowUpAction == false || event.ctrlKey == true || _eTarget.closest('[elem-identifier="CheckableColumn"]').length === 1) {
                var row = $(this).closest('tr');
                var _Id = $(row).data("key");

                if (!event.shiftKey && !isEmpty(_Id)) {
                    var objSel = _this.getSelections();

                    if (!isEmpty(objSel.Selections[_Id])) { delete objSel.Selections[_Id]; _this._removeCSS_Selected(row); }
                    else {
                        objSel.Selections[_Id] = _this._copyRowTDs($(row));
                        _this._addCSS_Selected(row);
                    }
                    _this.Table.trigger('Q_ROW_CLICK', [{ key: _Id, row: $(row) }]);
                    var tableIdentifier = _this.TableId + QUtils.NavigationId;
                    QLocalStorage.setTableSelections(tableIdentifier, objSel);
                    _this._refreshSelectionsCounter();
                    _this._initCheckAll();
                    $(document).trigger(_this.TableId + '_SELECTION_CHANGED');
                }
                _this._shiftSelection(event, _Id);
            }
        });
    } else {
        if (!isEmpty(_this._selectedKey)) {
            var prevRow = _this.getRowByKey(_this._selectedKey);
            if (prevRow) {
                _this._addCSS_Selected(prevRow);
            }
        }
        $(this.Table).find($('tbody tr td:not([elem-identifier="RowActions"])')).click(_this, function (event) {
            var _eTarget = $(event.target);
            // Click on the columns with the links will perform the own action.
            if (_eTarget.is('a')) { return; }

            event.preventDefault();
            event.stopPropagation();
            var _this = event.data;
            var row = $(this).closest('tr');
            var _Id = row.data("key");

            if (!isEmpty(_Id)) {
                var isRowSelected = row.data("selected");

                if (isRowSelected) { _this._removeCSS_Selected(row); }
                else { _this._addCSS_Selected(row); }

                if (_this._selectedKey !== _Id && !isEmpty(_this._selectedKey)) {
                    var oldRow = _this.getRowByKey(_this._selectedKey);
                    if (oldRow) { _this._removeCSS_Selected(oldRow); }
                }
                _this._selectedKey = _Id;
                _this.Table.trigger('Q_ROW_CLICK', [{ key: _Id, row: $(row) }]);
                $(document).trigger(_this.TableId + '_SELECTION_CHANGED');
            }
        });
    }
    _this.qControlLoaded = true;
    return _this;
};

//---------------------------------------------
// QMenuDEControl
//---------------------------------------------
function QMenuDEControl(first_element, second_element) {
    QMenuControl.call(this);

    this.SourceTable = new QMenuTableControl($(first_element), true);
    this.DestTable = new QMenuTableControl($(second_element));
    this.ExtendedTable = $('#PreviewTable');
    return this;
};

QMenuDEControl.prototype = Object.create(QMenuControl.prototype);

QMenuDEControl.prototype.InitSourceTable = function (e) {
    // Init the source table events
    var _this = e !== undefined ? e.data : this;
    _this.SourceTable.Init();
    _this.InitColumnsSum();
};

QMenuDEControl.prototype.InitDestTable = function (e) {
    var _this = e !== undefined ? e.data : this;
    _this.DestTable.Init();
};

QMenuDEControl.prototype.InitColumnsSum = function (e) {
    // Remover os elementos anteriores
    $('#columnsSum', this.SourceTable.Table).remove();
    $('#columnsSum', this.ExtendedTable.find('table')).remove();
    $('#columnsSumFooter', this.SourceTable.Table).remove();
    $('#columnsSumFooter', this.ExtendedTable.find('table')).remove();
    // Calcular novos valores das colunas
    var sumRowSourceTable = this.SourceTable._getColumnsSumFooter();
    var sumRowExtendedTable = this.SourceTable._getColumnsSumFooter(true);

    // Adidionar ao interface
    if (sumRowSourceTable !== '') {
        if ($('tfoot', this.SourceTable.Table).length == 0) {
            $(this.SourceTable.Table).find("#" + this.SourceTable.TableId.replace("_Container", "")).append('<tfoot class="c-table__footer" id="columnsSumFooter"></tfoot>');
        }
        $('tfoot', this.SourceTable.Table).prepend(sumRowSourceTable);

        if ($('tfoot', this.ExtendedTable.find('table')).length == 0) {
            this.ExtendedTable.find('table').append('<tfoot class="c-table__footer" id="columnsSumFooter"></tfoot>');
        }
        $('tfoot', this.ExtendedTable.find('table')).prepend(sumRowExtendedTable);
    }
};

QMenuDEControl.prototype.InitExtendedTable = function () {
    const $this = this;
    // Create the body of table from saved table rows in localStorage
    var tbody = '';
    $.each(this.SourceTable.getSelections().Selections, function (id, row) {
        tbody += '<tr data-key="' + id + '">';

        if (!$this.SourceTable.isAllSelected())
            tbody += '<td elem-identifier="DeExtendedAction" class="de-extended-acrion text-center"><a> <i class="glyphicons glyphicons-bin e-icon"></i></a ></td > ';

        tbody += row + '</tr > ';
    });
    this.ExtendedTable.find('tbody').replaceWith('<tbody class="c-table__body">' + tbody + '</tbody>');

    //Hide or show header clear button
    const tblHeadActions = this.ExtendedTable.find('thead > tr > .thead-actions')[0];
    if (tblHeadActions) {
        if ($this.SourceTable.isAllSelected()) {
            tblHeadActions.style.display = 'none';
        }
        else {
            tblHeadActions.style.display = '';
        }
    }    

    this.InitColumnsSum();

    //Set event for click and hover action
    const tblExtendedAction = $(this.ExtendedTable).find('[elem-identifier="DeExtendedAction"] a i');
    tblExtendedAction.off('hover').off('click');
    if (this.SourceTable.isAllSelected()) {
        tblExtendedAction.hover(function () {
            $(this).css("cursor", "pointer");
        }).click(this, function (e) {
            var _this = e.data;
            var row = $(this).closest('tr');
            var _Id = $(row).data("key");
            _this.SourceTable._clearSelections(false, _Id);
        });
    }

    //Change title text
    const previewHeader = this.ExtendedTable.find('.f-header__title')[0];
    if (previewHeader && previewHeader.tagName.toLowerCase() == 'span'
        && this.SourceTable.isAllSelected()) {
        previewHeader.innerHTML = quidgestGlobals.Resources.ALL_SELECTED_RECORDS;
    }
    else {
        previewHeader.innerHTML = quidgestGlobals.Resources.SELECTED;
    }

    // Set table record info
    const tblCaption = $(this.ExtendedTable).find('#PreviewTableCaption')[0];
    if (tblCaption) {
        //Build caption text
        let captionText = Object.keys(this.SourceTable.getSelections().Selections).length + ' / ';

        //The row number is an option that can be enabled or disabled in Genio
        //We have to account for this
        if (Number(this.SourceTable.getTotalRowCount()))
            captionText += this.SourceTable.getTotalRowCount();
        else
            captionText += '...';
        captionText += ' ' + quidgestGlobals.Resources.VISIBLE_RECORDS;

        tblCaption.innerHTML = captionText;        
    }

    var changeTrigger = this.SourceTable.TableId + '_SELECTION_CHANGED';
    $(document).off(changeTrigger).on(changeTrigger, this, function (event) {
        var _this = event.data;
        _this.InitExtendedTable();
    });
};

QMenuDEControl.prototype.Init = function () {
    this.InitDestTable();

    $(document).on(this.SourceTable.TableId + '_FirstTabInit', this, this.InitSourceTable);
    $(document).on(this.DestTable.TableId + '_SecondTabInit', this, this.InitDestTable);
    this.InitExtendedTable();
    $(this.ExtendedTable).find('#btnExTableReset').off('hover').off('click').hover(function () {
        $(this).css("cursor", "pointer");
    }).click(this, function (e) { var _this = e.data; _this.SourceTable._clearSelections(true); });

    this.qControlLoaded = true;
    return this;
};

QMenuDEControl.prototype.Send = function (ExecuteURL, RedirectURL) {
    // Submit of the DE List
    var _this = this;
    if(ExecuteURL === undefined || ExecuteURL === '') return;
    var params = { selected_ids: this.SourceTable.getSelectionsKeys(), dest_id: this.DestTable._selectedKey };

    //Add table filters to params
    params.queryParams = window[this.SourceTable.TableId].GetTableFilters();

    /* Check if the source table is in the allSelected list */
    if(this.SourceTable && this.SourceTable.TableId && this.SourceTable.isAllSelected()) {
        params.allSelected = true;
    }
    else {
        params.allSelected = false;
    }
    /* ------------------ */

    $.ajax({
        url: ExecuteURL,
        cache: false,
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(params),
        complete: function () {
            QAnimation.showPleaseWait(undefined, undefined, 0);
            setTimeout(_this.checkProgress(ExecuteURL, RedirectURL), 250); //start progress checker
        }
    })
};

QMenuDEControl.prototype.checkProgress = function (ExecuteURL, RedirectURL) {
    // Progress of the DE List task
    var _this = this;
    if (ExecuteURL === undefined || ExecuteURL === '') return;
    ExecuteURL = ExecuteURL.replace('_Execute', '_Progress');
    $.ajax({
        url: ExecuteURL,
        cache: false,
        type: "POST",
        dataType: "json"
    }).then(function (data) {
        if (data.Success) {
            if (data.finished) {
                QAnimation.hidePleaseWait();

                var tableIdentifier = _this.SourceTable.TableId + QUtils.NavigationId;
                QLocalStorage.setTableSelections(tableIdentifier);
                QLocalStorage.setLocalStorage("Tab", 'FirstTab');

                if (data.message) {
                    bootbox.alert(data.message, function () {
                        QUtils.NavigateTo = RedirectURL;
                    });
                }
            }
            else {
                //Update Progress
                if(data.percent) {
                    QAnimation.destroy();
                    QAnimation.showPleaseWait(undefined, undefined, data.percent);
                }
                //Restart timeout
                setTimeout(() => _this.checkProgress(ExecuteURL, RedirectURL), 500);
            }
        }
        else {
            QAnimation.hidePleaseWait();
            bootbox.alert(data.message);
        }
        return data;
    });
};

//---------------------------------------------
// QMenuDFControl
//---------------------------------------------
function QMenuDFControl(first_element, second_element) {
    QMenuControl.call(this);

    this.SourceTable = new QMenuTableControl($(first_element));
    this.DeselectTable = new QMenuTableControl($(second_element), true);
    this.ExtendedTable = $('#PreviewTable');

    this.source_area = this.SourceTable.Table.closest('[data-form]').attr('area').toLowerCase();
    return this;
};

QMenuDFControl.prototype = Object.create(QMenuControl.prototype);

QMenuDFControl.prototype.InitSourceTable = function (e) {
    // Init the source table events
    var _this = e !== undefined ? e.data : this;

    if (_this.SourceTable._selectedKey === undefined || _this.SourceTable._selectedKey === '' || _this.SourceTable._selectedKey === null) {
        var _queryString = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        var queryString = {};
        $.each(_queryString, function (i, value) { var temp = value.split('='); queryString[temp[0]] = temp[1]; });
        if (queryString[_this.source_area] != undefined) _this.SourceTable._selectedKey = queryString[_this.source_area];
    }

    _this.SourceTable.Init();
    var changeTrigger = _this.SourceTable.TableId + '_SELECTION_CHANGED';
    $(document).off(changeTrigger).on(changeTrigger, _this, function (event) {
        var _this = event.data;
        _this.ChangedSourceSelection();
    });
};

QMenuDFControl.prototype.InitDeselectTable = function (e) {
    // Init the deselect table events
    var _this = e !== undefined ? e.data : this;
    _this.DeselectTable.Init();
    _this.InitColumnsSum();
};

QMenuDFControl.prototype.InitColumnsSum = function (e) {
    // Remover os elementos anteriores
    $('#columnsSum', this.DeselectTable.Table).remove();
    $('#columnsSum', this.ExtendedTable.find('table')).remove();
    $('#columnsSumFooter', this.DeselectTable.Table).remove();
    $('#columnsSumFooter', this.ExtendedTable.find('table')).remove();
    // Calcular novos valores das colunas
    var sumRowDeselectTable = this.DeselectTable._getColumnsSumFooter();
    var sumRowExtendedTable = this.DeselectTable._getColumnsSumFooter(true);

    // Adidionar ao interface
    if (sumRowDeselectTable !== '') {
        if ($('tfoot', this.DeselectTable.Table).length == 0) {
            $(this.DeselectTable.Table).append('<tfoot id="columnsSumFooter"></tfoot>');
        }
        $('tfoot', this.DeselectTable.Table).prepend(sumRowDeselectTable);

        if ($('tfoot', this.ExtendedTable.find('table')).length == 0) {
            this.ExtendedTable.find('table').append('<tfoot id="columnsSumFooter"></tfoot>');
        }
        $('tfoot', this.ExtendedTable.find('table')).prepend(sumRowExtendedTable);
    }
};

QMenuDFControl.prototype.InitExtendedTable = function () {
    // Create the body of table from saved table rows in localStorage
    var tbody = '';
    $.each(this.DeselectTable.getSelections().Selections, function (id, row) {
        tbody += '<tr data-key="' + id + '"><td elem-identifier="DeExtendedAction" class="de-extended-acrion text-center"><a><i class="glyphicons glyphicons-bin e-icon"></i></a></td>' + row + '</tr>';    });
    this.ExtendedTable.find('tbody').replaceWith('<tbody class="c-table__body">' + tbody + '</tbody>');

    this.InitColumnsSum();

    $(this.ExtendedTable).find('[elem-identifier="DeExtendedAction"] a i').off('hover').off('click').hover(function () {
        $(this).css("cursor", "pointer");
    }).click(this, function (e) {
        var _this = e.data;
        var _Id = $(this).closest('tr').data("key");
        _this.DeselectTable._clearSelections(false, _Id);
    });
    var changeTrigger = this.DeselectTable.TableId + '_SELECTION_CHANGED';
    $(document).off(changeTrigger).on(changeTrigger, this, function (event) {
        var _this = event.data;
        _this.InitExtendedTable();
    });
};

QMenuDFControl.prototype.Init = function () {
    this.InitDeselectTable();
    $(document).on(this.SourceTable.TableId + '_FirstTabInit', this, this.InitSourceTable);
    $(document).on(this.DeselectTable.TableId + '_SecondTabInit', this, this.InitDeselectTable);

    $(this.ExtendedTable).find('#btnExTableReset').off('hover').off('click').hover(function () {
        $(this).css("cursor", "pointer");
    }).click(this, function (e) { var _this = e.data; _this.DeselectTable._clearSelections(true); });

    this.InitExtendedTable();

    this.qControlLoaded = true;
    return this;
};

QMenuDFControl.prototype.ChangedSourceSelection = function () {
    if (this.SourceTable._selectedKey === undefined || this.SourceTable._selectedKey === null) this.SourceTable._selectedKey = '';
    var id = this.SourceTable._selectedKey;
    if (id === '') id = '00000000-0000-0000-0000-000000000000';

    var qsStart = window.location.href.indexOf('?');
    var _queryString = window.location.href.slice(qsStart + 1).split('&');
    var queryString = {};
    $.each(_queryString, function (i, value) { var temp = value.split('='); queryString[temp[0]] = temp[1]; });

    var newUrl = window.location.href;
    if (queryString[this.source_area] != undefined)
        newUrl = newUrl.replace(this.source_area + "=" + queryString[this.source_area], this.source_area + "=" + id);
    else {
        if (qsStart === -1) newUrl += '?';
        if (window.location.search.length > 0 && window.location.search !== '?') newUrl += '&';
        newUrl += this.source_area + "=" + id;
    }

    history.constructor.savedStates[0].url = newUrl;
    history.replaceState(history.constructor.savedStates[0], history.constructor.savedStates[0].title, newUrl);

    this.DeselectTable._clearSelections(true, false);
    window[this.DeselectTable.TableId].Reload();
};

QMenuDFControl.prototype.Send = function (ExecuteURL, RedirectURL) {
    // Submit of the DE List
    var _this = this;
    if(ExecuteURL === undefined || ExecuteURL === '') return;
    var params = { selected_ids: this.DeselectTable.getSelectionsKeys() };
    $.when(RedirectURL, $.ajax({
        url: ExecuteURL,
        cache: false,
        type: "POST",
        dataType: "json",
        data: $.param(params, true),
        beforeSend: function () {
            QAnimation.showPleaseWait();
        },
        complete: function () {
            QAnimation.hidePleaseWait();
        }
    }).then(function (data) { return data; }), _this).done(function (RedirectURL, ajaxResp, _this) {
        if (ajaxResp.Success) {
            var tableIdentifier = _this.DeselectTable.TableId + QUtils.NavigationId;
            QLocalStorage.setTableSelections(tableIdentifier);
            QLocalStorage.setLocalStorage("Tab", 'FirstTab');

            var _RedirectURL = ajaxResp.RedirectURL || RedirectURL;
            if (ajaxResp.Message) {
                bootbox.alert(ajaxResp.Message, function () {
                    if (_RedirectURL) {
                        QUtils.NavigateTo = RedirectURL;
                    }
                });
            }
        }
        else if (ajaxResp.Message) {
            bootbox.alert(ajaxResp.Message);
        }
    });
};

//---------------------------------------------
// QDMControl
//---------------------------------------------
function QDMControl(element) {
    QMenuTableControl.call(this, element, true);
    var _this = this;
    $(window).on('unload', function () {
        _this._clearSelections(true, false);
    });
    return _this;
};


QDMControl.prototype = Object.create(QMenuTableControl.prototype);

QDMControl.prototype.InitColumnsSum = function (e) {
    // Remover os elementos anteriores
    $('#columnsSum', this.Table).remove();
    $('#columnsSumFooter', this.Table).remove();
    // Calcular novos valores das colunas
    var sumRowTable = this._getColumnsSumFooter();

    // Adidionar ao interface
    if (sumRowTable !== '') {
        if ($('tfoot', this.Table).length == 0) {
            $(this.Table).append('<tfoot id="columnsSumFooter"></tfoot>');
        }
        $('tfoot', this.Table).prepend(sumRowTable);

        /*$('#columnsSumLabel', this.Table).off('click')
            .click(function() {
                let details = $(this).closest('#columnsSumFooter').find('#columnsSumDetails');
                if(details.is(":visible"))
                    details.hide();
                else
                    details.show();
            });*/
    }
};

QDMControl.prototype.Init = function () {
    QMenuTableControl.prototype.Init.call(this);
    this.InitColumnsSum();

    var changeTrigger = this.TableId + '_SELECTION_CHANGED';
    $(document).off(changeTrigger).on(changeTrigger, this, function (event) {
        var _this = event.data;
        _this.InitColumnsSum();
    });
    return this;
};

//---------------------------------------------
// QTimeLineControl
//---------------------------------------------
function QTimeLineControl(element) {
    //var _this = this;
    this.element = $(element);
    this.timeLine = $('[elem-identifier="timeline"]', this.element)[0];
    return this;
};

QTimeLineControl.prototype.Filter = function (data, timeline, atrib) {
    timeLineItems = $('[elem-identifier="timeline-item"]', $(timeline));
    timeLineItems.each(function (index, value) {
        var dataValue = $(value).attr(atrib);
        if (dataValue == data) {
            $(value).css("display", "");
        }
        else {
            $(value).css("display", "none");
        }
    });
}

QTimeLineControl.prototype.Reset = function (timeline) {
    $('[elem-identifier="timeline-circle"].active').removeClass("active");
    $('[elem-identifier="timeline-item"]', $(timeline)).css("display", "");
}

QTimeLineControl.prototype.Init = function () {
    var timeLine = this.timeLine;
    var elem = this.element;
    var scale = $(timeLine).attr('scale');
    var atrib = "data";

    switch (scale) {
        case "yy": {atrib = "year"; break;}
        case "mm": {atrib = "month"; break;}
        case "ww": {atrib = "week"; break;}
        case "dd": { atrib = "data"; break; }
        default:
    }

    //fill cirle tooltips based on scale type
    $(this.element).find($('[elem-identifier="timeline-circle"]')).each(function () {
        $(this).attr("title", $(this).attr(atrib))
    });

    $(this.element).find($('[elem-identifier="timeline-circle"]')).mouseenter(function () {
        $(this).addClass("hover");
    });

    $(this.element).find($('[elem-identifier="timeline-circle"]')).mouseleave(function () {
        $(this).removeClass("hover");
    });

    //circle click
    $(this.element).find($('[elem-identifier="timeline-circle"]')).click(function () {
        var data = $(this).attr(atrib);
        var id = $(this).attr("id");

        if ($(this).hasClass('active')) {
            $(".active").removeClass("active");
            $('#timelineAccordion', $(elem)).collapse('hide')
        }
        else {
            $(".active").removeClass("active");
            $('#' + id).addClass("active");
            $('#timelineAccordion', $(elem)).collapse('show');
            QTimeLineControl.prototype.Filter(data, timeLine, atrib);
            $('[elem-identifier="timeline-reset"]', $(elem)).removeClass('active-reset');
        }
    });

    //reset click
    $(this.element).find($('[elem-identifier="timeline-reset"]')).click(function () {
        if ($(this).hasClass('active-reset')) {
            $(this).removeClass("active-reset");
            $('#timelineAccordion', $(elem)).collapse('hide');
        }
        else {
            $(this).addClass('active-reset');
            $('#timelineAccordion', $(elem)).collapse('show');
            QTimeLineControl.prototype.Reset(timeLine);
        }
    });

    return this;
};

QTimeLineControl.prototype.AttachOnChange = function () {
};

//CHN: I've created an alternative function to determine if object is empty, it uses jQuery.isEmptyObject() to return false evaluations right away,
//but test other cases to see if they are really empty while being numbers
//Its necessary because jQuery.isEmptyObject is not reliable when using numbers:
//jQuery.isEmptyObject('')           // true
//jQuery.isEmptyObject(33)           // true <<-------------------------------- This is bad, when using keys as integers
//jQuery.isEmptyObject([])           // true
//jQuery.isEmptyObject({})           // true
//jQuery.isEmptyObject({ length: 0, custom_property: [] }) // false
//jQuery.isEmptyObject('Hello')      // false
//jQuery.isEmptyObject([1, 2, 3])    // false
//jQuery.isEmptyObject({ test: 1 })  // false
//jQuery.isEmptyObject({ length: 3, custom_property: [1, 2, 3] }) // false
//jQuery.isEmptyObject(new Date())   // false
//jQuery.isEmptyObject(Infinity)     // true
//jQuery.isEmptyObject(null)         // true
//jQuery.isEmptyObject(undefined)    // true
/////////////// isEmpty() return on test cases:
//isEmpty('')           // true
//isEmpty(33)           // false <<--- correct
//isEmpty([])           // true
//isEmpty({})           // true
//isEmpty({ length: 0, custom_property: [] }) // false
//isEmpty('Hello')      // false
//isEmpty([1, 2, 3])    // false
//isEmpty({ test: 1 })  // false
//isEmpty({ length: 3, custom_property: [1, 2, 3] }) // false
//isEmpty(new Date())   // false
//isEmpty(Infinity)     // false <<-- I have doubts on this one, but anyway... its not empty!
//isEmpty(null)         // true
//isEmpty(undefined)    // true
function isEmpty(obj) {
    if (!jQuery.isEmptyObject(obj))
        return false;

    if (typeof (obj) === 'number' && String(obj).length > 0) {
        return false;
    }
    return true;
}

//---------------------------------------------
// QWizardControl
//---------------------------------------------

function QWizardControl(element, qParentForm)
{
    QControl.call(this, element, qParentForm);
};

QWizardControl.prototype = Object.create(QControl.prototype);

QWizardControl.prototype.Init = function()
{
    // We need to clear any traces of the wizard steps in the form, from previous executions.
    // Otherwise, the javascript controls won't be correctly initialized.
    var formName = this.ParentForm._formVariableName;
    for (let property in window)
        if (property.startsWith('Form_') && property != formName)
            delete window[property];
};

QWizardControl.prototype.SetWizardForms = function(forms)
{
    this.wizardForms = forms;
};

function activateHelps(form) {
    // Activate helps
    const defaultsToPopovers = form.HelpStyle == "popover";
    activateFormTooltips(defaultsToPopovers);
    if (defaultsToPopovers) {
        activatePopovers("popover");
    }
    else {
        activatePopovers("tooltip");
    }
}