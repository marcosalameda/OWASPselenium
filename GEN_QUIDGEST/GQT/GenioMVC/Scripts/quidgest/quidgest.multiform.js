/**************
*  Multiform  *
**************/
// File with important functions for the proper function of the multiform control
// Dependencies:
// - bootbox plugin
// - jQuery
// - shared js function (in _Javascript.cshtml named getInputsForNestedForm)
//
// To support to Multiforms, just add to the css classes of the element the class "multiform-container"

function ReplaceMultiFormHTML(multiForm, dataView, afterDoneCallback) {
    var _thisForm = $(multiForm).getQForm();

    if (!$.isEmptyObject(_thisForm)) {
        _thisForm.Destroy();
    }

    var newView = $(dataView);
    // TODO: Rever! Pode ser muito perigoso usar First e Last
    var formView = $(newView).first(),
        formJavaScript = $(newView).last(),
        dataForm = $(formView).data('form');

    // Delete previous saved active element
    var curLocalStorage = QLocalStorage.getLocalStorage('lastActiveElement');
    delete curLocalStorage[dataForm];
    QLocalStorage.setLocalStorage('lastActiveElement', curLocalStorage);

    // Update the form HTML
    $(multiForm).replaceWith($(formView));

    // Update the form JavaScript
    if (formView && formJavaScript) {
        $('#FormJavaScript_' + dataForm).replaceWith($(formJavaScript));
    }

    if(typeof afterDoneCallback === 'function') {
        afterDoneCallback(formView, formJavaScript);
    }
};

// Adds a new multiform to multiform section
function insertMultiForm(link, target) {
	var containerDiv = $("#" + target),
	    multiformObjName = containerDiv.data("object");
	if (window[multiformObjName].HasActiveInsert()) {
		bootbox.alert(quidgestGlobals.Resources.MULT_FORM_EM_EDICAO)
	} else {
		var lastChild = containerDiv.find('[elem-identifier="MultiformContainer"] > div').last();
		$.ajax({
			url: link,
			type: 'GET',
			success: function (data) {
				lastChild.after(data);
				var newMultiform = containerDiv.find('[elem-identifier="MultiformContainer"] > [elem-identifier="Multiform"]').last();
				newMultiform.addClass("multiform-insert");
				var insertId = newMultiform.attr("id");
				// Adds the Multiform object name to data of the new container
				newMultiform.data("object", multiformObjName);
				// Because it's an insert we should change the information of object regarding this
				window[multiformObjName].ActiveInsert(insertId);
				initSingleForm(newMultiform);
                if (modal_QuidgestGlobals) {
                    $(newMultiform).data("extend-Globals", "true")
                    extendQuidgestGlobals(modal_QuidgestGlobals);
                    modal_QuidgestGlobals = null;
                }
			},
			error: function (XMLHttpRequest, textStatus, errorThrown, data) {
				bootbox.alert(JSON.parse(data.responseText));
			}
		});
	}
}

// Cancels a  multiform in Edit Mode
function cancelMultiForm(link, target) {
    var containerDiv = $("#" + target),
        multiformObjName = containerDiv.data("object"),
        qForm = $(containerDiv).getQForm();

    if (window[multiformObjName].HasActiveInsert()) {
        $.when(qForm.confirmDirtyFields()).then(function (confirmDirtyFields) {
            if (!confirmDirtyFields) return;
            $.ajax({
                url: link,
                type: 'GET',
                success: function (response) {
                    if (containerDiv.data("extend-Globals") === "true") {
                        restoreQuidgestGlobals();
                    }

                    // If it was canceled successfully we do not need to update the HTML of the form. 
                    // The list Reload will already destroy and recreate all forms.
                    window[multiformObjName].InsertDone(target);
                    window[multiformObjName].Reload();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown, data) {
                    bootbox.alert(JSON.parse(data.responseText));
                },
                currentTarget: containerDiv
            });
        });
    }
}

// Adds a new multiform to multiform section
function getMultiForm(link, target, mode) {
    var containerDiv = $("#" + target),
        multiformObjName = containerDiv.data("object");

    if (window[multiformObjName].HasActiveInsert()) {
        bootbox.alert(quidgestGlobals.Resources.MULT_FORM_EM_EDICAO);
    } else {
        $.ajax({
            url: link,
            type: 'GET',
            success: function (response) {
                ReplaceMultiFormHTML(containerDiv, response);

                var newMultiform = $("#" + target);
                newMultiform.addClass("multiform-edit");
                var insertId = newMultiform.attr("id");
                // Adds the Multiform object name to data of the new container
                newMultiform.data("object", multiformObjName);
                // Because it's like an insert we should change the information of object regarding this
                window[multiformObjName].ActiveInsert(insertId);
                initSingleForm(newMultiform);
                $(newMultiform).trigger('FORM_LOADED', $(newMultiform));

                if (modal_QuidgestGlobals) {
                    $(newMultiform).data("extend-Globals", "true")
                    extendQuidgestGlobals(modal_QuidgestGlobals);
                    modal_QuidgestGlobals = null;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown, data) {
                bootbox.alert(JSON.parse(data.responseText));
            }
        });
    }
}

// Submits a multiform to the server
function submitMultiForm(link, target, mode) {
   var container = $("#" + target);

    // Gets the params from the multiform div
    var params = getInputsForNestedForm(container),
        multiformObjName = container.data("object");

    if (mode !== "delete")
        params["mode"] = window[multiformObjName].IsInsertBeingSaved(target) ? "INSERT" : "EDIT";
	else {
        var _thisQForm = container.getQForm();
        if (_thisQForm !== undefined)
            params = { id: _thisQForm.PrimaryKey.Value };
        else
            return; //it is desirable that this never occurs
    }

    // Submits the multiform
    $.ajax({
        url: link,
        cache: false,
        type: "POST",
        dataType: "json",
        data: $.param(params, true),
        success: function (data) {
           //Destroy form variable
           var _thisQForm, qFormVarName = container.data("QForm");
           if (qFormVarName !== undefined) {
               _thisQForm = window[qFormVarName];
           }
            if (data.Success) {
               var onSuccess = function (container, mode, multiformObjName, data, target) {
                   if (container.data("extend-Globals") === "true") {
                       restoreQuidgestGlobals();
                   }

                   container.addClass("alert-success");
                   setTimeout(function () { container.removeClass("alert-success"); }, 4000);

                   if (mode === "delete") {
                       if (container.parent().children('[elem-identifier="Multiform"]').length === 1)
                           // last multiform we need to go back 1 page
                           window[multiformObjName].DecrementPageField();
                       displayMessage(data.Message, MessageDefs.StatusEnum.E);
                       container.remove();
                       $('#FormJavaScript_' + target).remove();// Form JavaScript div
                   }

                   window[multiformObjName].InsertDone(target);
                   window[multiformObjName].Reload();
               };

               if (_thisQForm !== undefined) {
                   $.when(_thisQForm.OnAfterSave(data), onSuccess, container, mode, multiformObjName, data, target).then(function (afterSave, onSuccess, container, mode, multiformObjName, data, target) {
                       _thisQForm.Destroy();
                       onSuccess(container, mode, multiformObjName, data, target);
                   });
               }
               else {
                   onSuccess(container, mode, multiformObjName, data, target);
               }
            } else {
                if (_thisQForm !== undefined) { _thisQForm.Destroy(); }
                ReplaceMultiFormHTML(container, data.View, function (formHTML) {
                    if (window[multiformObjName].HasActiveInsert())
                        formHTML.addClass("multiform-insert");
                    formHTML.data("object", multiformObjName);
                    formHTML.addClass("alert-error");
                    initSingleForm(formHTML);
                    setTimeout(function () { formHTML.removeClass("alert-error"); }, 4000);
                });
                
                displayMessage(data.Message, MessageDefs.StatusEnum.E);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown, data) {
            bootbox.alert(JSON.parse(data.responseText));
        },
        currentTarget: container
    });
}

//Enable form actions after edit mode is loaded
function initSingleForm(target) {

    target.find('[elem-identifier="Actions"] > button').click(function () {
        var target = $(this).data("target"),
            link = $(this).data("link"),
            mode = $(this).data("mode");
        if (mode === "cancel")
            cancelMultiForm(link, target);
        else
            submitMultiForm(link, target, mode);
    })

    loaded(target,true);
};

(function ($) {

    function AddSupportToMultiforms() {
        $("button[data-mode]", $('[elem-identifier="MultiformContainer"]')).off('click').click(function () {
            var btn = $(this),
                target = btn.data('target'),
                link = btn.data('link'),
                mode = btn.data("mode");
            if (mode === "insert")
                insertMultiForm(link, target);
            else
                submitMultiForm(link, target, mode);
        });

        $('[elem-identifier="MultiformContainer"][data-mf-editable="true"]')
        .find('[elem-identifier="Multiform"]').off('click').click(function (event) {
			event.preventDefault();
			event.stopPropagation();
			if ($(event.target).is('button[data-mode="delete"]') || $(event.target).parent().is('button[data-mode="delete"]')) { return; } //to not put form on edit mode when delete pressedd
            var container = $(this),
                target = container.attr('id'),
                link = container.data('link');
            getMultiForm(link, target, 'edit');
        });

        $('[elem-identifier="MultiformContainer"]').each(function (i, v) {
            var objectName = $(v).parent().data("object");
            $('[elem-identifier="Multiform"]', $(v)).data("object", objectName);
        });

        $('[elem-identifier="MultiformContainer"] [elem-identifier="Multiform"]').each(function (i, v) {
            $(this).trigger('FORM_LOADED', $(this));
        });
    };

    $.Multiforms = function () {
        // Add actions to action buttons inside multiforms
        AddSupportToMultiforms();
    };
})(jQuery);