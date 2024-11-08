/****************
*  Modal Forms  *
****************/
// File with important functions for the proper function of the modal form support
// Dependencies:
// - bootstrap modal
// - bootstrap modal manager
// - jQuery
//
// To support modal forms, just add to the element the attribute "data-modal-form"

function OpenModalForm(link, params, table, callbackSave, callbackCancel, callbackDelete, modalId)
{
    // If the form HTML already exists we want to remove it and readd it
    // This will fix an issue where it might show up behind another pop up that is already open
    //  since now we garantee it is at the bottom of the DOM
    const targetModalId = modalId || 'form-modal'
    var formModal = $('#' + targetModalId);
    if (formModal.length)
    {
        formModal.modal('hide');
        formModal.remove();
    }

    formModal = $('<div></div>', {
        id: targetModalId,
        "class": "modal container-fluid hide",
        "data-backdrop": "static",
        "data-keyboard": "false",
        tabindex: -1,
        role: "dialog",
        "aria-hidden": "true"
    }).appendTo("body");

    // erase modal content
    formModal.html("");
    // show modal
    formModal.modal();
    // add loading class
    formModal.addClass("loading");
    formModal.data("open", true);
    formModal.data("open-link", link);
    if(callbackSave)
        formModal.data("callbackSave", callbackSave);
    else
        formModal.data("callbackSave", null);
    if(callbackCancel)
        formModal.data("callbackCancel", callbackCancel);
    else
        formModal.data("callbackCancel", null);
	if(callbackDelete)
	    formModal.data("callbackDelete", callbackDelete);
    else
	    formModal.data("callbackDelete", null);

    $.ajax({
        url: link,
        type: "GET",
        data: params,
        cache: false,
        beforeSend: function () {
            QAnimation.addLoading(1000);
        },
        complete: function () {
            QAnimation.removeLoading();
        },
        success: function (data) {
            // remove loading class
            formModal.removeClass("loading");
            formModal.html(data);
            formModal.modal("show");
            if(table)
            {
                formModal.data("reload-table", table);
            }
			if (window.modal_QuidgestGlobals) {
				formModal.data("extend-Globals","true")
				extendQuidgestGlobals(modal_QuidgestGlobals);
				modal_QuidgestGlobals = null;
            }
            //formModal.find('#sidebarModalToggle').off('click').on('click', sidebarToggle);
			//Controlos do tipo data (datepicker) provocam trigger do hide.
			// if a user clicks outside the modal, the action associated with the last button of the modal (usually cancel) should be triggered
            /*formModal.off('hide').on('hide', function () {
				// only if the modal was ordered to be hidden before, that we should click the button
                if(formModal.data("open"))
                    $("[data-modal-close=true]", formModal).last().click();
            })*/
        },
        error: function (/*jqXHR, textStatus, errorThrown*/) {
            var QErrorModalForm = '<div class="alert alert-error permissionErrorPopUp"><p><strong>' + quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091 + '</strong></p></div><div class="modal-footer"><button class="btn" data-dismiss="modal" aria-hidden="true">' + quidgestGlobals.Resources.FECHAR + '</button></div>';

            formModal.removeClass("loading");
            formModal.html(QErrorModalForm);
            formModal.modal("show");
            if(table)
                formModal.data("reload-table", table);
        }
    });
}

function CloseModalForm(link, params, isCancel, repeatInsertion, modalId)
{
    if (!modalId) modalId = "form-modal"
    var formModal = $('#' + modalId);

    var qFormVarName = formModal.find('[data-form]').data("QForm");
    var qForm = qFormVarName != undefined ? window[qFormVarName] : undefined;
    var isQForm = (qForm != undefined);

    if (isQForm)
    {
        if(!isCancel && qForm.FormMode === QFormMode.delete)
        {
            CloseModalFormOnDelete(link, modalId);
            return;
        }

        /**
         * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
         *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
         *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
         *  including corrupting the levels of history.
         */
        if(qForm.submissionDisabled)
            return;

        qForm.submissionDisabled = true;
    }

   try
   {
        var preValidaMode = isCancel ? 'CANCEL' : 'SUBMIT';

        $.when(isCancel ? (isQForm ? qForm.confirmDirtyFields() : true) : true, isQForm ? qForm.OnPreValida(preValidaMode, qFormVarName) : true, repeatInsertion)
        .then(function (confirmDirtyFields, prevalida, repeatInsertion) {

            if (!confirmDirtyFields || !prevalida) 
            {
                if(isQForm) 
                    qForm.submissionDisabled = false;
                return false;
            }

            $.when(isQForm && !isCancel ? qForm.OnBeforeSave() : true, repeatInsertion).then(function (resBeforeSave, repeatInsertion) {
                var inputs = getInputsForNestedForm(formModal);
                var dataParams = $.extend({}, inputs, params);
                $.ajax({
                    url: link,
                    type: "POST",
                    data: dataParams,
                    cache: false,
                    traditional: true,
                    beforeSend: function() {
                        QAnimation.addLoading(1000);
                    },
                    complete: function() {
                        QAnimation.removeLoading();
                        if(isQForm)
                            qForm.submissionDisabled = false;
                    },
                    success: function (data) {
                        if (data && data.Success) {
                            formModal.data("open", false);
                            var temp_GET_link = formModal.data("open-link");
                            var table = formModal.data("reload-table");
                            if (table) {
                                formModal.removeData("reload-table");
                                if (window[table] !== undefined) {
                                    window[table].Reload();
                                }
                            }
                            var callback;
                            if (data.Operation == "Save" || data.Operation == "Edit")
                                callback = formModal.data("callbackSave");
                            else if (data.Operation == "Cancel")
                                callback = formModal.data("callbackCancel");
                            else if (data.Operation == "Delete")
                                callback = formModal.data("callbackDelete");
                            if (callback)
                                callback(data);
                            if (formModal.find('[data-form]').data("QForm") !== undefined) {
                                var qFormVarName = formModal.find('[data-form]').data("QForm");
                                $.when(isCancel ? true : window[qFormVarName].OnAfterSave(data)).then(function () {
                                    //Destroy form variable
                                    if (window[qFormVarName] !== undefined) window[qFormVarName].Destroy();

                                    formModal.html("");
                                    if (formModal.data("extend-Globals") == "true") {
                                        restoreQuidgestGlobals();
                                    }
                                    if (repeatInsertion) {
                                        formModal.modal('hide'); //Hide the current pop form before open the new one
                                        OpenModalForm(temp_GET_link, {}, table);
                                    }
                                    else {
                                        if (isQForm) { $(document).trigger("QFORM_MODAL_CLOSED"); }
                                        formModal.modal('hide');
                                    }
                                });
                            }
                            else {
                                formModal.html("");
                                if (formModal.data("extend-Globals") == "true") {
                                    restoreQuidgestGlobals();
                                }
                                if (repeatInsertion) {
                                    OpenModalForm(temp_GET_link, {}, table);
                                }
                                else {
                                    if (isQForm) { $(document).trigger("QFORM_MODAL_CLOSED"); }
                                    formModal.modal('hide');
                                }
                            }

                            // Show warnings
                            if (!repeatInsertion && Array.isArray(data.Warnings) && data.Warnings.length > 0)
                                QAnimation.renderMessages();
                        }
                        else
                        {
                            /*
                            //Destroy form variable
                            if (formModal.find('[data-form]').data("QForm") !== undefined) {
                                var qFormVarName = formModal.find('[data-form]').data("QForm");
                                if (window[qFormVarName] !== undefined) window[qFormVarName].Destroy();
                            }
                            formModal.html(data);
                            */
                            // [APM] Changed this to match the Submit() action in quidgest.controls.js.
                            
                            // Validation errors
                            $.localStorageFormSave(formModal.find('form').first());
                            $(formModal).find('.validation-summary-errors').remove();
                            $(formModal).find('[elem-identifier="ModalBody"]').find('.form-flow').first().prepend($(data).find('.validation-summary-errors'));

                            // Validation warnings
                            $(formModal).find('#validation-summary-warnings').remove();
                            $(formModal).find('[elem-identifier="ModalBody"]').find('.form-flow').first().prepend($(data).find('#validation-summary-warnings'));
                        }
                    }
                });
            }).fail(() => { if(isQForm) qForm.submissionDisabled = false; });
        }).fail(() => { if(isQForm) qForm.submissionDisabled = false; });
   }
   catch(e)
   {
        console.error('Error while closing the modal form', e);
        if(isQForm) 
            qForm.submissionDisabled = false;
   }
}

function CloseModalFormOnDelete(link, modalId) {
    if (!modalId) modalId = "form-modal"
    var formModal = $('#' + modalId);

    var qForm = formModal.find('form').first().getQForm();
    /**
     * To prevent multiple executions of handlers from different actions (which can occur in the case of multiple clicks on the same button, 
     *  especially if the system and network are slow), "submissionDisabled" is used to block some actions 
     *  and only unlocks if the page is not changed to another. Without this block, multiple executions can cause various problems on the server,
     *  including corrupting the levels of history.
     */
    if(qForm.submissionDisabled)
        return;
    qForm.submissionDisabled = true;

    $.ajax({
        url: link,
        type: "POST",
        data: $.param({ id: qForm.PrimaryKey.Value }, true),
        cache: false,
        beforeSend: function() {
            QAnimation.addLoading(1000);
        },
        complete: function() {
            QAnimation.removeLoading();
            qForm.submissionDisabled = false;
        },
        success: function (data) {
            if (data && data.Success) {
                formModal.data("open", false);
                var table = formModal.data("reload-table");
                if (table) {
                    formModal.removeData("reload-table");
                    if (window[table] !== undefined) {
                        window[table].Reload();
                    }
                }
                var callback = formModal.data("callbackDelete");
                if (callback)
                    callback(data);

                qForm.Destroy();
                formModal.html("");

                if (formModal.data("extend-Globals") == "true") {
                    restoreQuidgestGlobals();
                }

                $(document).trigger("QFORM_MODAL_CLOSED");
                formModal.modal('hide');
            }
            if (data.Message) {
                displayMessage(data.Message);
            }
        }
    });
}

function modalFormsBtnOnClickCallback(e, callbackSave) {
    e.preventDefault()

    const EXECUTION_DISABLED_ATTR = 'modal-execution-disabled';
    const _this = $(this);

    /**
     * To prevent multiple executions of handlers (which can happen in cases of multiple clicks on the same button if the system and network are slow), 
     *  a specific attribute is used to block the element that triggers the event and only unlocks if the page is not changed to another. 
     * Without this block, multiple executions can cause various problems on the server, including corrupting the levels of history.
     */
    if (_this.data(EXECUTION_DISABLED_ATTR)) {
        console.warn('Already processing, please wait...');
        return false;
    }
    _this.data(EXECUTION_DISABLED_ATTR, true);

    const _fnEnableSubmission = () => _this.data(EXECUTION_DISABLED_ATTR, false);


    try
    {
        var modalId = $(this).data("modal-id") || "form-modal";
        var url = "";
        if ($(this).is("a"))
            url = $(this).attr("href");
        else if ($(this).is("button"))
            url = $(this).data("modal-url");
        else if ($(this).is("li")) // Insert direto no Chosen
            url = $(this).attr("href");
        else {
            console.log("Not supposed to be here...");
            _fnEnableSubmission();
            return false;
        }

        var closeModal = $(this).data("modal-close");
        var isCancel = $(this).data("modal-cancel");
        var isRefresh = $(this).data("modal-refresh");
        var repeatInsertion = $(this).data("modal-repeat-insertion");
        var table = $(this).data("table");
        var skipPreValida = $(this).data("skip-prevalida");

        if (closeModal) {
            CloseModalForm(url, {}, isCancel, repeatInsertion, modalId);
            _fnEnableSubmission();
        }
        else {
            var preValida = function (target, mode) {
                return QPreValida($(target), mode);
            }

            var _qForm = _this.closest('[data-form]'),
                formMode = _this.data('modal-form-mode');

            //Skip PreValida() for popup support forms for related tables (these have the attribute data-skip-prevalida="true")
            if (skipPreValida) {
                $.when(url, table, isRefresh, callbackSave, _qForm).done(function (href, table, isRefresh, callbackSave, _qForm) {
                    $.when(syncFormKeys(_qForm), $.localStorageFormSave($(_this).closest("[data-form]").first()), isRefresh, callbackSave)
                        .done(function (res1, res2, isRefresh, callbackSave) {
                            if (isRefresh) {
                                //Destroy form variable
                                $.localStorageFormRemove($(_this).closest("[data-form]").first());
                                if ($('#' + modalId).find('[data-form]').data("QForm") !== undefined) {
                                    var qFormVarName = $('#' + modalId).find('[data-form]').data("QForm");
                                    if (window[qFormVarName] !== undefined) window[qFormVarName].Destroy();
                                }
                            }
                            OpenModalForm(url, {}, table, callbackSave, undefined, undefined, modalId);
                            _fnEnableSubmission();
                        })
                        .fail(() => _fnEnableSubmission());
                })
                .fail(() => _fnEnableSubmission());

            }
            else {
                $.when(preValida(this, formMode || "POPUP"), url, table, isRefresh, callbackSave, _qForm)
                .done(function (preValida, href, table, isRefresh, callbackSave, _qForm) {
                    if (preValida) {
                        $.when(syncFormKeys(_qForm), $.localStorageFormSave($(_this).closest("[data-form]").first()), isRefresh, callbackSave)
                            .done(function (res1, res2, isRefresh, callbackSave) {
                                if (isRefresh) {
                                    //Destroy form variable
                                    $.localStorageFormRemove($(_this).closest("[data-form]").first());
                                    if ($("#form-modal").find('[data-form]').data("QForm") !== undefined) {
                                        var qFormVarName = $("#form-modal").find('[data-form]').data("QForm");
                                        if (window[qFormVarName] !== undefined) window[qFormVarName].Destroy();
                                    }
                                }
                                OpenModalForm(url, {}, table, callbackSave, undefined, undefined, modalId);
                                _fnEnableSubmission();
                            })
                            .fail(() => _fnEnableSubmission());
                    }
                    else
                        _fnEnableSubmission();
                })
                .fail(() => _fnEnableSubmission());
            }
        }
    }
    catch(e)
    {
        console.error('Error while processing click for the modal form', e);
        $(this).data(EXECUTION_DISABLED_ATTR, false);
    }
};

(function ($) {
    $.ModalForms = function (target, callbackSave) {
        $("[data-modal-form]", target).off("click").click(function (e) {
            e.preventDefault();
            modalFormsBtnOnClickCallback.call(this, e, callbackSave);
        });
    }
})(jQuery);