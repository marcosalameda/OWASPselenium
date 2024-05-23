/**************
*  Documents  *
***************/

DBDocument = (function () {

    function DBDocument(container, options) {
        this.options = options != null ? options : { maxFileSize: 100000000, maxChunkSize: 1024000, acceptFileTypes: null };
        this.container = container;
        this.ticket = container.data("ticket");
        this.inputDocumFK = $("input[data-fieldfk]", container);
        this.downloadAnchor = $("a[data-action='download']", container);
        this.texts = $("[id='texts']", container);
        this.displayInputJQ = $("[elem-identifier='FileInputBox']", container);
        this.dataIdentifier = $(container).find("input").first().attr("data-identifier");
        this.usesTemplates = container.data("use-templates");
        this.configureFileuploadActions();
    }

    DBDocument.prototype.configureFileuploadActions = function () {
        // Works for submit and download action
        this.disableDisabledLinks();

        // Submit Action
        this.submitAction();

        // Delete Action
        this.deleteAction();

        // Properties Action
        this.propertiesAction();

        // Versions DBedit Action
        this.versionsDBEditAction();

        this.configureDeleteVersionAction();

        this.addDocTemplateAction();
    }

    DBDocument.prototype.submitAction = function () {
        EventResize();
        var obj = this;
        var form = $('[data-identifier=' + obj.dataIdentifier + ']').closest("form");

        $('a[data-action="attach"]', this.container).each(function (i, v) {
            var anchor = $(this);
            var mode = anchor.data("mode");
            var url = anchor.data("url");

            $("input[type='file']", anchor)
                .each(function (index, value) {
                    $(this).fileupload({
                        url: url,
                        formData: { ticket: obj.ticket, usesTemplates: obj.usesTemplates, dataIdentifier: obj.dataIdentifier },
                        dataType: 'json',
                        acceptFileTypes: obj.options.acceptFileTypes,
                        maxFileSize: obj.options.maxFileSize,
                        messages: {
                            maxNumberOfFiles: quidgestGlobals.Resources.MAXIMUM_NUMBER_OF_FI03180,
                            acceptFileTypes: quidgestGlobals.Resources.FILE_TYPE_NOT_ALLOWE47893,
                            maxFileSize: quidgestGlobals.Resources.FILE_IS_TOO_LARGE22896,
                            minFileSize: quidgestGlobals.Resources.FILE_IS_TOO_SMALL45972
                        },

                        // TODO move maxChunkSize to obj.options
                        // (requires changes outside this file)
                        maxChunkSize: 1024000,
                        autoUpload: true,
                        progress: function (e, data) {
                            if (!(bowser.msie && bowser.version <= 9)) {
                                eval("var pgr = parseInt(data.loaded / data.total * 100, 10)");
                                obj.displayInputJQ.val(pgr + '%');
                            }
                            else
                                obj.checkFileInIE(data);//IE things
                        }
                    }).on('fileuploadprocessalways', function (e, data) {
                        var index = data.index;
                        var file = data.files[index];
                        if (file.error)
                            bootbox.alert(file.error);
                        else
                            obj.displayInputJQ.addClass('fileupload-loading');
                    }).on('fileuploadsend', function (e, data) {
                        data.context = obj.displayInputJQ;
                        $('[qbutton=ok]', $(form)).addClass('disabled');
                        $('[qbutton=ok]', $(form)).attr('disabled', 'disabled'); 
                    }).on('fileuploaddone', function (e, data) {
                        if (data.result) {
                            if (data.result.success)
                                obj.reloadDocumsControl(data.result.controlUpdate);
                            else if (data.result.message) {
                                bootbox.alert(data.result.message, () => {
                                    obj.reloadDocumsControl(data.result.controlUpdate);
                                });
                            }
                        }
                        obj.displayInputJQ.removeClass('fileupload-loading');
                        $('[qbutton=ok]', $(form)).removeClass('disabled'); 
                        $('[qbutton=ok]', $(form)).removeAttr('disabled');                       
                    }).on('fileuploadfail', function (e, data) {
                        obj.displayInputJQ.removeClass('fileupload-loading');
                        bootbox.alert(obj.texts.data("text-error"))
                        $('[qbutton=ok]', $(form)).removeClass('disabled');
                        $('[qbutton=ok]', $(form)).removeAttr('disabled');
                    });
                });
            anchor.each(function () {
                if (mode == "Checkout" || mode == "Submit") {
                    $(this).click(function () {
                        if (anchor.parent().hasClass('disabled'))
                            return false;
                        anchor.parent().addClass("disabled");
                        var dataType = mode == "Checkout" ? 'json' : 'html';
                        $.ajax({
                            url: url,
                            type: "POST",
                            dataType: dataType,
                            data: { ticket: obj.ticket, usesTemplates: obj.usesTemplates, dataIdentifier: obj.dataIdentifier }
                        }).done(function (data) {
							if (mode == "Checkout") {
								// Last updated by [HTA] at [2019.10.01]
								var extra = anchor.data("extra");
								obj.reloadDocumsControl(data.controlUpdate);
								if (extra != undefined && extra != "") {
									CallCustomScheme(extra, obj.downloadAnchor.attr("data-url"));
								} else {
									QUtils.NavigateTo = obj.downloadAnchor.attr("data-url");
								}
							}
							else {
								obj.submitVersionResponse(data);
							}
                            anchor.parent().removeClass("disabled");
                        }).fail(function (jqXHR, textStatus) {
                            bootbox.alert(obj.texts.data("text-error"));
                            anchor.parent().removeClass("disabled");
                        });
                        return false;
                    });
                }
            });
        });
    }

    // Reload Document Control
    DBDocument.prototype.reloadDocumsControl = function (control) {
        EventResize();
        this.container.replaceWith(control);
    }

    // Submit Version Modal
    DBDocument.prototype.submitVersionResponse = function (data) {
        bootbox.dialog({
            message: data,
            buttons: {
                cancel: {
                    label: this.texts.data("text-cancel"),
                    className: "b-icon-text--secondary",
                    callback: function () { }
                },
                ok: {
                    label: this.texts.data("text-submit"),
                    className: "b-icon-text--primary",
                    callback: function () { }
                }
            }
        });
    }

    // Helper method for IE
    DBDocument.prototype.checkFileInIE = function (data) {
        try {
            var activeXObj = new ActiveXObject("Scripting.FileSystemObject");
            var thefile = activeXObj.getFile(data.fileInput[0].value);
            var size = thefile.size;
            if (size > data.maxFileSize)
                bootbox.alert(data.messages['maxFileSize']);
        } catch (e) {
            if (e.number == -2146827859) {
                bootbox.alert('Unable to access local files due to browser security settings. ' +
                'To overcome this, go to Tools->Internet Options->Security->Custom Level. ' +
                'Find the setting for "Initialize and script ActiveX controls not marked as safe" and change it to "Enable" or "Prompt"');
            }
        }
    }

    DBDocument.prototype.disableDisabledLinks = function () {
        $("a", this.container).click(function (e) {
            if ($(this).parents("div").hasClass('disabled'))
                return false;
            //Safari things
            e.stopPropagation();
        });
    }

    DBDocument.prototype.deleteAction = function () {
        EventResize();
        var obj = this;
        $("a[data-action='delete']", this.container).click(function (e) {
            var anchor = $(this);
            if (anchor.parents("div").hasClass('disabled'))
                return false;
            bootbox.confirm({
                message: obj.texts.data('text-confirm-delete'),
                buttons: {
                    cancel: { label: obj.texts.data('text-no') },
                    confirm: { label: obj.texts.data('text-yes') }
                }, callback: function (result) {
                    if (result)
                        obj.doAction(anchor);
                }
            });
            //Safari things
            e.stopPropagation();
        });
    }

    DBDocument.prototype.doAction = function (anchor) {
        // Only for delete and properties
        var url = anchor.data('url');
        var action = anchor.data('action');
        var requestType = action == "delete" ? "POST" : "GET";
        var dataType = action == "delete" ? "json" : "html";
        var obj = this;

        $.ajax({
            url: url,
            type: requestType,
            data: { ticket: obj.ticket, usesTemplates: obj.usesTemplates, dataIdentifier: obj.dataIdentifier },
            dataType: dataType
        }).done(function (data) {
            if (action == "delete") {
                if (data.success && data.controlUpdate)
                    obj.reloadDocumsControl(data.controlUpdate);
                else
                    bootbox.alert(data.message);
            }
            else if (action == "properties") {
                bootbox.alert(data);
                anchor.parents("div").removeClass('disabled');
            }
            else
                bootbox.alert(data.message);
        }).fail(function (jqXHR, textStatus) {
            bootbox.alert(texts.data("text-error"));
        });
    }

    DBDocument.prototype.propertiesAction = function () {
        var obj = this;

        $("a[data-action='properties']", obj.container).click(function (e) {
            var anchor = $(this);
            if (anchor.parents("div").hasClass('disabled'))
                return false;

            anchor.parents("div").addClass('disabled');
            obj.doAction(anchor);
            //Safari things
            e.stopPropagation();
        });
    }

    DBDocument.prototype.versionsDBEditAction = function () {
        var obj = this;

        // Fixes dropdown sub-menus not working properly, namely the versions sub-menu.
        $('a.dropdown-item', obj.container).click(function()
        {
            var next = $(this).next();
            if (next.length > 0 && next.attr('class').includes('dropdown-menu'))
            {
                if (next.hasClass('show'))
                    next.removeClass('show');
                else
                    next.addClass('show');
            }
        });
        $('button.dropdown', obj.container).first().click(function()
        {
            $('.dropdown-submenu > .dropdown-menu', obj.container).removeClass('show');
        });

        $('[elem-identifier="DocumsDbedit"] a', obj.container).click(function (e) {
            var anchor = $(this);
            var url = $(this).data("url");
            if (anchor.parent().hasClass('disabled'))
                return false;
            anchor.parent().addClass("disabled");

            $.ajax({
                url: url,
                type: "POST",
                data: { ticket: obj.ticket }
            }).done(function (data) {
                bootbox.dialog({
                    size: "large",
                    message: '<div id="_DocumsVersionsDBEdit">' + data + '</div>'
                });
                anchor.parent().removeClass("disabled");
            }).fail(function (jqXHR, textStatus) {
                bootbox.alert(texts.data("text-error"));
                anchor.parent().removeClass("disabled");
            });
            return false;
        });
    }

    DBDocument.prototype.configureDeleteVersionAction = function () {
        EventResize();
        var obj = this;
        $('[elem-identifier="DeleteVersion"]', obj.container).unbind('click').click(function (e) {
            obj.deleteVersion($(this));
        });
    }

    DBDocument.prototype.deleteVersion = function (anchor) {
        EventResize();
        var obj = this;
        var action = anchor.data("action");
        var url = anchor.data("url");
        if (!url)
        {
            anchor = $("a[data-action='" + action + "']", obj.container);
            url = anchor.data("url");
        }

        var message = action == "Historic" ? obj.texts.data("text-delete-all-versions") : obj.texts.data("text-delete-last-version");
        bootbox.confirm({
            message: wrapTextWithWhitespaces(message),
            buttons: {
                cancel: {
                    label: obj.texts.data("text-no")
                }, confirm: {
                    label: obj.texts.data("text-yes")
                }
            }, callback: function (e) {
                    if (e) {
                        $.ajax({
                            url: url,
                            type: "POST",
                            dataType: 'json',
                            data: { ticket: obj.ticket, usesTemplates: false, action: action, dataIdentifier: obj.dataIdentifier }
                        }).done(function (data) {
                            if (data.success) {
                                obj.reloadDocumsControl(data.controlUpdate);
                                bootbox.hideAll();
                                bootbox.alert(obj.texts.data("text-delete-file-sucess"));
                            } else {
                                bootbox.alert(data.message);
                            }
                        }).fail(function (jqXHR, textStatus) {
                            bootbox.alert(obj.texts.data("text-error"));
                        });
                    }
                }
        });
    }

	DBDocument.prototype.addDocTemplateAction = function() {
	    var obj = this;
	    $('[elem-identifier="CreateDocTempl"]', obj.container).click(function () {
			window.onbeforeunload = false;
			var anchor = $(this);
			if(anchor.parent().hasClass('disabled'))
				return false;
			anchor.parent().addClass("disabled");

			var fldname = anchor.data("fldname");
			var form = anchor.data("formname");
			var idFormFldname = form + "_" + fldname;

			var link = anchor.data("url");
			$.ajax({
				url: link,
				type: "POST",
				data: { partialView : idFormFldname + "_Templates" }
			}).done(function(data) {
                var dialog = bootbox.dialog({
                    message: data
                });
                var _id = idFormFldname + '_Templates';
                dialog.find('.bootbox-body').prop('id', _id).attr('id', _id);
				anchor.parent().removeClass("disabled");
			}).fail(function(jqXHR, textStatus) {
				bootbox.alert(obj.texts.data("text-error"));
			});
			return false;
	    });
	}

	DBDocument.prototype.initSubmitVersion = function (setFileUrl, fieldContainer) {
	    EventResize();
        $('button[data-bb-handler="ok"]').click(function () {
			var obj = $("#submitVersionFile");
			var ticket = obj.data('ticket');
			var action = $("#action:checked").val();
			var version = $("#version:checked").val();
			var usesTemplates = obj.data('use-templates');
			if (action === "Submit" && $("#versionProgress").val() === "") {
				$(".bootbox.modal").css("z-index", "1040");
				$(".modal-backdrop").css("z-index", "1030");
				bootbox.alert(quidgestGlobals.Resources.NENHUM_FICHEIRO_SELE48024);

				return false;
			}

			var params = { ticket: ticket, usesTemplates: usesTemplates, mode: action, version: version };

			$.ajax({
				url: setFileUrl,
				type: "POST",
				data: params,
				dataType: "json"
			}).done(function (data) {
				if (data.success) {
					DBControl.reloadDocumsControl(data.controlUpdate);
				}
				else{
					bootbox.alert(data.message);
				}
				fieldContainer.removeClass('fileupload-loading');
			}).fail(function (jqXHR, textStatus) {
				fieldContainer.removeClass('fileupload-loading');
                bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_NA_S47287);
			});
		});

		$("#submitVersion").click(function (e) {
			$("#" + $(this).data('fldname')).addClass('fileupload-loading');
			$("input:file", $(this).parent()).trigger("click");
		});

		$("#submitVersionFile").change(function (e) {
			$("#" + $(this).data('fldname')).addClass('fileupload-loading');
			$("#versionProgress").val($(this).val().replace(/C:\\fakepath\\/i, ''));
		}).click(function (e) {
			e.stopPropagation();
		}).each(function (i, e) {
			var obj = $(this);
			var ticket = obj.data('ticket');
			var url = setFileUrl;
			var inputSelector = 'input[id="versionProgress"]';
			var thisInput = $(this);
			var usesTemplates = obj.data('use-templates');
			$(this).fileupload({
                add: function (e, data) {
                    var $this = $(this);
                    data.context = $('button[data-bb-handler="ok"]')
                        .unbind("click").click(function () {
                            data.process(function () {
                                return $this.fileupload('process', data);
                            }).done(function () {
                                data.submit();
                            });
                        });
                },
				url: url,
				dataType: 'json',
				acceptFileTypes: DBControl.options.acceptFileTypes,
				maxFileSize: DBControl.options.maxFileSize,

                // TODO move maxChunkSize to DBControl.options
                // (requires changes outside this file)
                maxChunkSize: 1024000,
				autoUpload: false,
				progress: function (e, data) {
					if (!(bowser.msie && bowser.version <= 9)) {
						eval("var pgr = parseInt(data.loaded / data.total * 100, 10)");
                        DBControl.displayInputJQ.val(pgr + '%');
					}
					else
						checkFileInIE(data);//IE things
				},
				done: function (e, data) {
					if (data.result) {
						if (data.result.success) {
							DBControl.reloadDocumsControl(data.result.controlUpdate);
						}
						else
							bootbox.alert(data.result.message);
						$(this).parents('div.btn-group.open').children('button').dropdown('toggle');
					}
					$(inputSelector).removeClass('fileupload-loading');
				}
			}).bind('fileuploadsubmit', function (e, data) {
				// The example input, doesn't have to be part of the upload form:
				var action = $("#action:checked").val();
				var version = $("#version:checked").val();
				data.formData = { ticket: ticket, usesTemplates: usesTemplates, mode: action, version: version };
			}).on('fileuploadprocessalways', function (e, data) {
				var index = data.index;
				var file = data.files[index];
				if (file.error)
					bootbox.alert(file.error);
				else
					$(inputSelector).addClass('fileupload-loading');
			}).on('fileuploadsend', function (e, data) {
				data.context = $(inputSelector);
			}).on('fileuploadfail', function (e, data) {
				$(inputSelector).removeClass('fileupload-loading');
				bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_NA_S47287)
			});

		});
	}
    return DBDocument;
})();


(function () {
    $.fn.extend({
        InitFileControl: function (options) {
            var mainContainer = $(this).closest('[elem-identifier="DocumContainer"]');
            return mainContainer.data('dbdocument', new DBDocument(mainContainer, options));
        }
    });
}).call(this);

function EventResize() {
    $('[elem-identifier="BtnGroup"]').on('click', function () {
        var element = $(this).parents();
        $('[elem-identifier="AccordionInner"]').removeAttr("style");
        //element document
        var heightdropdown = $(this).children("div").height();
        var parent = $(this).children("div");
        var children = $(parent).children("div[class='dropdown-submenu']");
        //remove events
        $(children).off('mouseover');
        $(children).off('mouseout');
        $(children).on('mouseover', function () {
            element.closest('[elem-identifier="AccordionInner"]').css("height", element.closest('[elem-identifier="AccordionInner"]').height() + ($(children).children("div").children().not(".dropdown-divider").length * ($(children).height() - 3)));
        });
        $(children).on('mouseout', function () {
            element.closest('[elem-identifier="AccordionInner"]').css("height", element.closest('[elem-identifier="AccordionInner"]').height() - ($(children).children("div").children().not(".dropdown-divider").length * ($(children).height() - 3)));
        });
        //element is open (Not needed anymore. Causes collapsible zones to expand more than necessary.)
		/*
        if (!$(this).hasClass("open"))
            element.closest('[elem-identifier="AccordionInner"]').css("height", element.closest('[elem-identifier="AccordionInner"]').height() + heightdropdown);
		*/
    });
}

// Last updated by [MH] at [05/02/2020]
function CallCustomScheme(url, fallback) {
    // Using local version of https://github.com/SatoshiKawabata/fallback-custom-scheme
    // Loaded in bundle.js and used in both DBDocument.cshtml referencing QuidgestDBDocumentLaunch inside URLNames
    var fcs = new window.FallbackCustomScheme({
        urlScheme: url, // your application custom scheme
        fallback: fallback, // if not installed the application, handling (ex. app store, google play store etc)
        onFallback: function () {
            //remove files when don't exist protocol (addin:)
            $.ajax({
                type: "POST",
                url: quidgestGlobals.UrlAction.formArea.replace("form", "RemoveFileTemp").replace("area", "Home"),
                async: false,
                dataType: "json"
            });
            window.qVar_isControlledRedirect = false; // Enable confirmation message
        } // fallback handler
    });
    window.qVar_isControlledRedirect = true; // Disable confirmation message
    fcs.launch();
}

// Last updated by [HTA] at [2019.10.01]
function DownloadConsoleFile(obj) {
    var element = obj;
    var anchor = $(element);
    var extra = anchor.data("extra");
    var url = anchor.data("url");

    if (!element.parentElement.classList.contains("disabled"))
        CallCustomScheme(extra, url);
}

