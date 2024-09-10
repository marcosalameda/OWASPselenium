if (window.QErrorLogger === undefined) {
    window.QErrorLogger = [];
}

if (window.QAjaxLogger === undefined) {
    window.QAjaxLogger = {};
}

QError = {
    Create: function (msg, error, url, lineNo, columnNo) {
        var message = {
            Message: msg,
            URL: url,
            Line: lineNo !== undefined ? lineNo : '0',
            Column: columnNo !== undefined ? columnNo : '0',
            ErrorObject: JSON.stringify(error),
            Date: Globalize.format(new Date(), "dd/MM/yyyy HH:mm:ss.ms", 'en') // en - Use default dateformat without '/' replaces
        }; 
        return message;
    },
    SaveError: function (errorObj) {
        window.QErrorLogger.push(errorObj);
    },
    AppendError: function (msg, error, url, lineNo, columnNo) {
        var message = this.Create(msg, error, url, lineNo, columnNo);
        this.SaveError(message);
        //console.error(message.Message);
    }
};

QDebug = {
    FillTableLocalStorage: function () {
        var result = '';
        var savedInfo = QLocalStorage.getLocalStorage('savedInfo');

        if (savedInfo !== undefined && !jQuery.isEmptyObject(savedInfo)) {
            $.each(savedInfo, function (area, rowArea) {
                $.each(rowArea, function (areaKey, areaFields) {
                    $.each(areaFields, function (field, rowField) {
                        result = result + '<tr>' +
                            '<td id="Form" name="Form">' + rowField.form + '</td>' +
                            '<td id="Area" name="Area">' + area + '</td>' +
                            '<td id="AreaKey" name="AreaKey">' + areaKey + '</td>' +
                            '<td id="Field" name="Field">' + field + '</td>' +
                            '<td id="OriginalValue" name="OriginalValue">' + rowField.original + '</td>' +
                            '<td id="Value" name="Value">' + rowField.value + '</td>' +
                            '<td id="Level" name="Level">' + (rowField.level || '-') + '</td>' +
                        '</tr>';
                    });
                });
            });
        }
        return result;
    },
    FillTableFormSerialize: function () {
        var result = '';
        var forms = $('[data-form]');
        if (forms !== undefined && !jQuery.isEmptyObject(forms)) {
            $.each(forms, function (index_1, form) {
                var formName = $(form).data('form');
                var formArea = $(form).attr('area');
                $.each($(form).serializeArray(), function (index_2, rowField) {
                    result = result + '<tr>' +
                        '<td id="Form" name="Form">' + formName + '</td>' +
                        '<td id="FormArea" name="FormArea">' + formArea + '</td>' +
                        '<td id="Field" name="Field">' + rowField.name + '</td>' +
                        '<td id="Value" name="Value">' + rowField.value + '</td>' +
                        '</tr>';
                });
            });
        }
        return result;
    },
    FillTableQForm: function () {
        var result = '';
        var forms = $('[data-form]');

        if (forms !== undefined && !jQuery.isEmptyObject(forms)) {
            $.each(forms, function (index_1, form) {
                var formVariableName = $(form).attr("QForm");
                if (formVariableName !== undefined && window[formVariableName] !== undefined) {
                    var qForm = window[formVariableName];
                    var formName = $(form).data('form');
                    var formArea = $(form).attr('area');

                    $.each(qForm.Controls, function (index_2, qControl) {
                        result = result + '<tr>' +
                            '<td id="Form" name="Form">' + formName + '</td>' +
                            '<td id="FormArea" name="FormArea">' + formArea + '</td>' +
                            '<td id="FieldArea" name="FieldArea">' + qControl.area + '</td>' +
                            '<td id="FieldName" name="FieldName">' + qControl.field + '</td>' +
                            '<td id="ControlIdentifier" name="ControlIdentifier">' + qControl.controlIdentifier + '</td>' +
                            '<td id="Value" name="Value">' + qControl.Value + '</td>' +
                            '</tr>';
                    });
                }
            });
        }
        return result;
    },
    FillTableErrorLog: function () {
        var result = '';
        $.each(window.QErrorLogger, function (i, errorObj) {
            result = result + '<tr>' +
                '<td id="Date" name="Date" class="span1">' + errorObj.Date + '</td>' +
                '<td id="Message" name="Message" class="span4">' + errorObj.Message + '</td>' +
                '<td id="URL" name="URL"  class="span4">' + errorObj.URL + '</td>' +
                '<td id="CodePosition" name="CodePosition">' +
                (errorObj.Line !== undefined ? errorObj.Line : '0') + '; ' +
                (errorObj.Column !== undefined ? errorObj.Column : '0') + ';</td>' +
                '<td id="ErrorObject" name="ErrorObject">' + 
                (errorObj.ErrorObject !== undefined && errorObj.ErrorObject.length > 30 ?
                '<a data-toggle="popover" data-placement="left" data-qerrlogid="' + i + '">' + errorObj.ErrorObject.substring(0, 30) + ' (...)</a>' : errorObj.ErrorObject) + '</td>' +
                '</tr>';
        });
        return result;
    },
    FillTableAjaxLog: function () {
        var result = '';
        var sortedAjax = [];
        $.each(window.QAjaxLogger, function (i, aObj) {
            sortedAjax.push(aObj);
        });
        sortedAjax.sort(function (a, b) { return a._date - b._date });
        $.each(sortedAjax, function (i, ajaxObj) {
            result = result + '<tr' + (ajaxObj.LogType === "Error" ? ' class="error"' : '') + '>' +
                '<td id="Date" name="Date">' + ajaxObj.Date + '</td>' +
                '<td id="Time" name="Time">' + ajaxObj.Time + '</td>' +
                '<td id="URL" name="URL">' + ajaxObj.URL + '</td>' +
                '<td id="Type" name="Type">' + ajaxObj.Type + '</td>' +
                //Send data
                '<td id="Data" name="Data" class="span3">' +
                (ajaxObj.Data.length > 30 ?
                '<a href="#" data-toggle="popover" data-placement="bottom" data-rowtype="Send" data-qjaxid="' + ajaxObj.AjaxIdentifier + '">' + ajaxObj.Data.substring(0, 30) + ' (...)</a>' : ajaxObj.Data) + '</td>' +
                //End of Send data
                // Response
                '<td id="ResponseContent_' + ajaxObj.AjaxIdentifier + '" name="Response" class="span3">' +
                (ajaxObj.Response.length === 0 ? '' :
                '<a href="#" data-toggle="popover" data-placement="left" data-rowtype="Recive" data-qjaxid="' + ajaxObj.AjaxIdentifier + '"></a>') + '</td>' +
                //End of Response
               '</tr>';
        });
        return result;
    },
    OpenForm: function () {
        if (!window.quidgestGlobals || !window.quidgestGlobals.UrlAction || !window.quidgestGlobals.UrlAction.QDebug)
            return;
        var link = quidgestGlobals.UrlAction.QDebug;
        if ($("#qdebug-form-modal").length === 0)
            $('<div id="qdebug-form-modal" class="modal container-fluid hide" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="a-index: 50000;"></div>').appendTo('body');
        var formModal = $("#qdebug-form-modal");
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
            url: link,
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
    },
    GetRandomID: function() {
        return Math.floor(Math.random() * 1000000);
    },
    ExtraInfo: function () {
        //add an extra debug info, such as navigator or current URL
        return ' currentURL: ' + document.URL +
             '\n userAgent: ' + navigator.userAgent +
             '\n platform: ' + navigator.platform +
             '\n language: ' + navigator.language +
             '\n cookies: ' + navigator.cookieEnabled;
    },
    SaveAjax: function (type, event, xhr, settings, qAjaxIdentifier, date, msgError) {
        if(qAjaxIdentifier === undefined || qAjaxIdentifier === null) {
            qAjaxIdentifier = this.GetRandomID();
        }

        var response = xhr.responseText;
        try {
            if (xhr.responseJSON !== undefined) {
                response = '';
                $.each(xhr.responseJSON, function (prop, value) {
                    response = response + (prop + ': ' + JSON.stringify(value) + '; ');
                });
            }
        }
        catch(ex)
        {
            response = xhr.responseText;
        }

        if (type === "Error" && msgError !== undefined) {
            response = msgError;
        }

        if (type === "Recive" && !jQuery.isEmptyObject(window.QAjaxLogger[qAjaxIdentifier])) {
            window.QAjaxLogger[qAjaxIdentifier].Response = response;
            var requeststart = new Date(window.QAjaxLogger[qAjaxIdentifier]._date);
            var time = Math.abs(date - requeststart);
            window.QAjaxLogger[qAjaxIdentifier].Time = time;
        }
        else {
            var ajax = {
                LogType: type,
                Response: response !== undefined ? response : '',
                URL: settings.url,
                Type: settings.type,
                Data: settings.data !== undefined ? settings.data : '',
                Date: Globalize.format(date, "dd/MM/yyyy HH:mm:ss.ms", 'en'), // en - Use default dateformat without '/' replaces
                _date: date.getTime(),
                AjaxIdentifier: qAjaxIdentifier,
                Time: 0
            };
            window.QAjaxLogger[qAjaxIdentifier] = ajax;
        }
    },
    ErrorCount: function() {
        return window.QErrorLogger.length;
    },
    AjaxCount: function () {
        var result = 0;
        $.each(window.QAjaxLogger, function (i, error) {
            if (error.LogType === "Send") {
                result = result + 1;
            }
        });
        return result;
    },
    InitAjaxProfiler: function(){
        $(document).ajaxSend(function (event, xhr, settings) {
            var date = new Date();
            var _qAjaxIdentifier = QDebug.GetRandomID();
            xhr.setRequestHeader('QAjaxIdentifier', _qAjaxIdentifier);
            QDebug.SaveAjax('Send', event, xhr, settings, _qAjaxIdentifier, date);
        });

        $(document).ajaxSuccess(function (event, xhr, settings, data) {
            var date = new Date();
            var _qAjaxIdentifier = xhr.getResponseHeader("QAjaxIdentifier");
            if (jQuery.type(_qAjaxIdentifier) === "string") {
                _qAjaxIdentifier = (_qAjaxIdentifier).split(', ')[0];
            }
            QDebug.SaveAjax('Recive', event, xhr, settings, _qAjaxIdentifier, date);
        });

        $(document).ajaxError(function (event, xhr, settings, data, thrownError) {
            var date = new Date();
            var _qAjaxIdentifier = xhr.getResponseHeader("QAjaxIdentifier");
            if (jQuery.type(_qAjaxIdentifier) === "string") {
                _qAjaxIdentifier = (_qAjaxIdentifier).split(', ')[0];
            }
            QDebug.SaveAjax('Error', event, xhr, settings, _qAjaxIdentifier, date, xhr.statusText);
        });
    }    
};

document.onkeydown = function (event) {
    if (event.altKey === true && event.ctrlKey === true && event.shiftKey === true) QDebug.OpenForm();
};

window.onerror = function (msg, url, lineNo, columnNo, error) {
    QError.AppendError(msg, error, url, lineNo, columnNo);
    // Tell browser to run its own error handler as well   
    return false;
};

$(window).on('load', function () {
    QDebug.InitAjaxProfiler();
});
