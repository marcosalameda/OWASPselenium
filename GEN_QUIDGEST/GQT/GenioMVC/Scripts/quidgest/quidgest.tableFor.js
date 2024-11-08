(function($){
    var TableFor = function(element, options) {
        var tableId = $(element).attr('id');
        var obj = this;
        $(element).data("tableFor", this);
        this._element = $(element);
        options.tableElement = this._element;

        options.multipleSelection = $(element).data('multiple-selection') || false;
        if (options.multipleSelection) {
            obj._qMenuControl = new QDMControl($(element)).Init();
            var _this = obj;
            $('[elem-identifier="ActionsContainer"] a[data-routine]', $('#' + options.container)).off('click').click(function () {
                var routine = $(this).data("routine");
                var selections = _this._qMenuControl.getSelectionsKeys();
                var groupRoutine = eval(routine);
                if (groupRoutine !== undefined && selections !== undefined)
                    groupRoutine({ ids: selections });
            });
        }
        else {
            obj._qMenuControl = new QMenuControl($(element)).Init();
        }

        //Default settings:
        var defaults = {
            requestsUrl: null,
            container: null,
            tableType: null,
            pageField: 'p' + tableId,
            sortField: 's' + tableId,
            sortDirField: 'd' + tableId,
            filters: `${tableId}_filters`,
            simpleFilters: `${tableId}_simple_filters`
        };
        var settings = $.extend(true, {}, defaults, options || {});

        this._ = function (aKey) {
            return aKey === element && { tableId: tableId, defaults: defaults, settings: settings };
        };

        this.GetId = function () {
            return tableId;
        };

        this.GetSettings = function () {
            return settings;
        };

        this.GetTableFilters = function (isDEMenu = false) {
            let targetDiv = '';

            if (isDEMenu) {
                targetDiv = $(`#${settings.container}, #${settings.filters}, #${settings.simpleFilters}`).parent();
            } else {
                targetDiv = $(`#${settings.container}`).parent();
            }

            let inputs = $("input:not(:button), select", targetDiv);
            return GetPostRquestParameters(inputs, settings.container);
        };

        this.GetType = function () {
            return settings.tableType;
        };

        this.Reload = function()
        {
            // Before reloading the HTML of all multiforms it is necessary to destroy the control objects of the form.
            _destroyMultiForms();

            _reload();
        };
        var _reload = function()
        {
            $(settings.tableElement).trigger('SET_QCONTROL_LOADED', [false]);
            $('html, body').data('already-animated-scroll', false);
            // This prevents losing the query part of the url (such as the limits of selection between limits, ex: ?ValMinvalue=01-04-2014&ValMaxvalue=28-05-2014)
            var queryString = window.location.search;
            queryString = queryString.replace("newMenu=True&", "");
            queryString = queryString.replace("newMenu=True", "");
            // The search property returns the querystring part of a URL, including the question mark (?)
            if (settings.requestsUrl.indexOf("?") !== -1 && queryString.length > 1)
                queryString = "&" + queryString.substring(1);
            var url = settings.requestsUrl + queryString;

            // Destroy all QForm object into table. (Multiforms)
            $.each($('#' + settings.container).find('[qform]'), function (i, qform) {
                var qFormVarName = $(qform).data("QForm");
                if(window[qFormVarName] !== undefined) window[qFormVarName].Destroy();
            });

            //For menus type DE/DF
            if ($('#Menu_tabs').length > 0) {
                makeAjaxRequest(url, settings.container, tableId, true);
            } else {
                makeAjaxRequest(url, settings.container, tableId);
            }

            _applyLoading();
        };

        var _destroyMultiForms = function () {
            var multiforms = $("#" + settings.container).find('[elem-identifier="Multiform"]');
            if (multiforms.length !== 0) {
                $.each(multiforms, function (i, qMForm) {
                    if (!$.isEmptyObject($(qMForm).getQForm())) {
                        $(qMForm).getQForm().Destroy();
                    }
                });
            }
        };

        this.ExportList = function (exportType) {
            _ExportList(exportType);
        };
        var _ExportList = function (exportType) {
            var params = {};
            params['ExportList'] = true;
            params['ExportType'] = exportType;

            // JMN (2021-04-09) - First validate export formatting and then export the file.
            _ValidateExportFile(params);
        };

        this.ExportTemplate = function (importType) {
            _ExportTemplate(importType);
        };
        var _ExportTemplate = function (importType) {
            if (importType.indexOf('template_') !== -1) {
                importType = importType.replace('template_', '');
                var params = {};
                params['ImportList'] = true;
                params['ImportType'] = importType;

                _DownloadExportFile(params);
            } else {
                //TODO: IMPLMENT UPLOAD
            }

        };

        var TableResizeColumn = function () {
            window.tableResizeVar = {
                startX: 0,
                startWidth: 0,
                $handle: null,
                $table: null,
                pressed: false
            }

            $(document).on('mousedown', '[id="' + tableId + '"].table-resizable th a', function (event) {
                event.preventDefault();
            });
            
            // Prevent text selection of advanced search inputs from changing the width of the table columns
            $(document).on('mousedown', '[id="' + tableId + '"].table-resizable th > input', function (event) {
                event.stopPropagation();
            });

            $(document).on('mousedown', '[id="' + tableId + '"].table-resizable th', function (event) {
                window.tableResizeVar.$handle = $(this);
                window.tableResizeVar.pressed = true;
                window.tableResizeVar.startX = event.pageX;
                window.tableResizeVar.startWidth = window.tableResizeVar.$handle.width();

                window.tableResizeVar.$table = window.tableResizeVar.$handle.closest('.table-resizable').addClass('resizing');
            }).on('dblclick', '.table-resizable thead', function () {
                // Reset column sizes on double click
                $(this).find('th[style]').css('width', '');

            }).on('mousemove', function () {
                if (window.tableResizeVar.pressed) {
                    window.tableResizeVar.$handle.width(window.tableResizeVar.startWidth + (event.pageX - window.tableResizeVar.startX));
                }
            }).on('mouseup', function () {
                if (window.tableResizeVar.pressed) {
                    window.tableResizeVar.$table.removeClass('resizing');
                    window.tableResizeVar.pressed = false;

                    $('td[headers*="' + window.tableResizeVar.$handle.attr('id') + '"]', $(window.tableResizeVar.$table)).each(function () {
                        if (this.scrollWidth > this.offsetWidth)
                            $(this).attr("title", $(this).html());
                    });
                }
            });
        };
        TableResizeColumn();

        // Warning: make sure to call _DownloadExportFile() with the orginal parameters (listParams)
        var _ValidateExportFile = function (listParams) {

            // Note: this variable is reset by window.onbeforeunload (quidgest.globalFunctions.js)
            if (QLocalStorage.getLocalStorage("ExportValidationOverride") == "true") {

                // Skip validation
                _DownloadExportFile(listParams);
                return;
            }

            var queryString = window.location.search;
            // Remove any querystring key-value corresponding to "newMenu=True"
            queryString = queryString.replace(/newMenu=True&?/gi, "");
            // The search property returns the querystring part of a URL, including the question mark (?)
            if (settings.requestsUrl.indexOf("?") !== -1 && queryString.length > 1)
                queryString = "&" + queryString.substring(1);
            var url = settings.requestsUrl + queryString;
            var targetDiv = $("#" + settings.container).parent();
            var inputs = $("input:not(:button), select", targetDiv);
            var params = GetPostRquestParameters(inputs, settings.container);

            for (var attrname in listParams) { params[attrname] = listParams[attrname]; }


            // Check PDF column limits
            if (listParams.ExportType && listParams.ExportType == "pdf") {

                params['ExportValidate'] = true;

                $.ajax({
                    url: url,
                    type: 'POST',
                    data: params,
                    beforeSend: function () {
                        qAddLoading(1000);
                    },
                    complete: function () {
                        qRemoveLoading();
                    }
                })
                    .done(function (data, textStatus, jqXHR) {
                        if (data.ValidFormat === false) {
                            bootbox.confirm(quidgestGlobals.Resources.EXPORT_FILE_FORMATTING, function (result) {
                                QLocalStorage.setLocalStorage("ExportValidationOverride", result.toString());
                                if (result) {
                                    _DownloadExportFile(listParams);
                                }
                            });
                        } else {
                            _DownloadExportFile(listParams);
                        }
                    })
                    .fail(function (jqXHR, textStatus, errorThrown) {
                        // Allow download if validation fails - next time user tries to export, it will skip validation.
                        QLocalStorage.setLocalStorage("ExportValidationOverride", "true");
                        if (errorThrown !== "canceled")
                            bootbox.alert(quidgestGlobals.Resources.NAO_FOI_POSSIVEL_CONCLUIR);
                    });

            } else {
                _DownloadExportFile(listParams);
            }
        }

        var _DownloadExportFile = function (listParams) {
            var queryString = window.location.search;
            // Remove any querystring key-value corresponding to "newMenu=True"
            queryString = queryString.replace(/newMenu=True&?/gi, "");

            // The search property returns the querystring part of a URL, including the question mark (?)
            if (settings.requestsUrl.indexOf("?") !== -1 && queryString.length > 1)
                queryString = "&" + queryString.substring(1);
            var url = settings.requestsUrl + queryString;
            var targetDiv = $("#" + settings.container).parent();
            var inputs = $("input:not(:button), select", targetDiv);
            var params = GetPostRquestParameters(inputs, settings.container);

            for (var attrname in listParams) { params[attrname] = listParams[attrname]; }

            $.ajax({
                url: url,
                type: 'POST',
                data: params,
                beforeSend: function () {
                    // Show warning that it may take some time
                    if ($('[elem-identifier="DbeditCounter"]', targetDiv).text() > quidgestGlobals.exportWarningCountLimit) {
                        QAnimation.alert();
                    }
                    qAddLoading(1000);
                },
                complete: function () {
                    qRemoveLoading();
                }
            })
                .done(function (data, textStatus, jqXHR) {
                    try {
                        QUtils.WindowOpen(data.Url, "_self");
                    }
                    catch (e) {
                        displayMessage(quidgestGlobals.Resources.NAO_FOI_POSSIVEL_CONCLUIR, MessageDefs.StatusEnum.E);
                    }
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    if (errorThrown !== "canceled")
                        displayMessage(quidgestGlobals.Resources.NAO_FOI_POSSIVEL_CONCLUIR, MessageDefs.StatusEnum.E);
                });

        };

        this.ImportList = function (actionUrl) {
            _ImportList(this);
        };
        var _ImportList = function (tableGrid) {
            var importType;
            var Template = '<div class="qq-uploader" style="margin-top:8px;">' +
                '<div class="qq-upload-drop-area"><span>Drop files here to upload</span></div>' +
                '<div elem-identifier="BtnGroup" class="btn-group">' +
                '<div class="qq-upload-button b-icon-text b-icon-text--primary">' + quidgestGlobals.Resources.SUBMETER + '</div>' +
                '</div>' +
                '<ul class="qq-upload-list"></ul>' +
                '</div>';

            var jQueryElement = $("#importListinput");
            var uploader = new qq.FileUploader({
                element: jQueryElement[0],
                action: jQueryElement.attr('data-action'),
                multiple: false,
                allowedExtensions: ['xlsx'],
                template: Template,
                params: { importType: importType },
                messages: {
                    typeError: '{file} - ' + quidgestGlobals.Resources.EXTENSAO_INVALIDA + ' {extensions}',
                    sizeError: '{file} - ' + quidgestGlobals.Resources.FICHEIRO_DEMASIADO_GRANDE + ' {sizeLimit}'
                },
                onSubmit: function (id, fileName) {
                    this.params.importType = fileName.split('.').pop();
                    $('div.preview').addClass('loading');
                },
                onComplete: function (id, fileName, result) {
                    console.log(result);
                    if (result.success == true) {
                        tableGrid.CloseImportList();
                        tableGrid.Reload();
                        tableGrid.ShowImportSuccess(result);
                    } else {
                        tableGrid.ShowImportFail(result);
                    }
                },
                showMessage: function (message, status) {
					displayMessage(message, status);
                }
            });

            $('#modal-importList').modal('show');
        };

        this.ShowImportSuccess = function (result) {

            var html = "<h4>" + result.msg + "</h4>";
            for (i = 0; i < result.lines.length; i++) {
                html += "<div>" + result.lines[0] + "</div>";
            }
            displayMessage(html, MessageDefs.StatusEnum.OK);
        };

        this.ShowImportFail = function (result) {

            var html = "<h4>" + result.msg+"</h4>";
            for (i = 0; i < result.errors.length; i++) {
                html += "<div>" + result.errors[0]+"</div>";
            }
            displayMessage(html, MessageDefs.StatusEnum.E);
        };

        this.CloseImportList = function () {
            _CloseImportList();
        };

        var _CloseImportList = function () {
            $("#importListinput").html('');
            var formModal = $('#modal-importList');
            $(formModal).data('open', false);
            $(formModal).modal('hide');
        };

        this.ApplyLoading = function () {
            _applyLoading();
        };

        var _applyLoading = function () {
            var table = $('#' + settings.container).find('table#' + tableId);
            var colsNumber = table.find('thead tr:first-child th').length;
            var currentHeight = table.find('tbody').css('height');

            table.find('tbody').html('<tr style="height: ' + currentHeight + '"><td colspan="' + colsNumber + '" class="loading">&nbsp</td></tr>');
        };

        this.NoSort = function () {
            displayMessage("No sort is available for this field.", MessageDefs.StatusEnum.W);
        };

        this.Sort = function (field, direction) {
            this.KeepHorizontalScrollPosition();
            _sort(field, direction);
        };

        var _sort = function (_field, _direction) {
            $('#' + settings.sortField).val(_field);
            $('#' + settings.sortDirField).val(_direction);
            _reload();
        };

        this.Page = function (page) {
            this.KeepHorizontalScrollPosition();
            _page(page);
        };

        // This function should called when an element of a table is removed,
        // due to the fact that it can be the only record of a given page,
        // and if so the pagination field should be updated also.
        this.DecrementPageField = function () {
            var pageField = $('#' + settings.pageField);
            if (pageField.val() > 1)
                // Page cannot be 0
                pageField.val(pageField.val() - 1);
        };

        var _page = function (_page) {
            $('#' + settings.pageField).val(_page);
            _reload();
        };

        // An alias for the search action, that should call the reload action
        this.Search = function () {
            var target = $('#' + settings.container).parent();
            var pageInput = $('#' + settings.pageField, target);
            if (pageInput) { $(pageInput).val(1); }
            this.KeepHorizontalScrollPosition();

            var treeBody = $('#qSeeMoreTree_body', target);
            // if tree view is shown, do not call _reload(),  instead call treeSeeMore -> see button click for tree-view
            if (treeBody.is(":visible")) {
                if(treeBody.data('tree')) {
                   // Clean up previous tree
                   treeBody.empty();
                   treeBody.data('tree', false);
                }
                // data-identifier=IFF_EQUIP___PESS1NOME____
                var controlIdentifier = target.data('control-identifier');
                var control = $('[data-identifier=' + controlIdentifier + ']');
                treeBody.treeSeeMoreFor(control);
            } else {
                _reload();
            }
        };

        
        this.InitFilters = function () {
            $("#" + obj.GetId() + "_filters .input-filter").off('click').click(function () {
                obj.Search();
            });
        };

        $(settings.tableElement).on(this.GetId() + '_RELOADED', this.InitFilters);
        this.InitFilters();

        this.KeepHorizontalScrollPosition = function () {
            var target = $('#' + settings.container),
                tblRContainer = target.find('[elem-identifier="table-responsive-container"]'),
                hScrollPosition = tblRContainer.scrollLeft();

            target.one(settings.container + '_RELOADED',
                {
                    container: settings.container,
                    hScrollPosition: hScrollPosition
                },
                function (event) {
                    var data = event.data,
                        target = $('#' + data.container),
                        tblRContainer = target.find('[elem-identifier="table-responsive-container"]')
                    tblRContainer.scrollLeft(data.hScrollPosition);
                    
                    // Since reloading deactivates tooltips within the table,
                    // we need to activate them again here (after the reload)
                    activateFormTooltips(true);
                });
        }

        this.ToggleViewMode = (idlist, idlistController, idlistArea, codlista, target) => {
            const params = {
                idlist: idlist,
                idlistController: idlistController,
                idlistArea: idlistArea,
                codlista: codlista,
                target: target
            }

            $.ajax({
                url: quidgestGlobals.UrlAction.ToggleViewMode,
                type: 'POST',
                data: params,
                success: () => {
                    QUtils.WindowReload()
                }
            })
        }

        //Aplly loading when click the search button
        $('#' + tableId + '_simple_filter').find('button:submit').click(function () { _applyLoading(); });

		//created by [SF] at [2017.01.17]
        //Resize table onclick button in "Expoetabela"
        $('[elem-identifier="BtnGroup"]').on('click', function () {
            var element = $(this).parents();
            $('[elem-identifier="AccordionInner"]').removeAttr("style");
            var numberrows = $("#" + element.closest("table").attr("id") + " tr[data-key='" + element.closest("table tr").attr("data-key") + "']").nextAll().length;
            var heightcontainer = $("#" + element.closest("table").attr("id") + " thead").height() * numberrows;
            var heightdropdown = $("#" + element.closest("table").attr("id") + " ul[class~='dropdown-menu']").height();
            if (!$(this).hasClass("open")) {
                if (heightcontainer < heightdropdown)
                    element.closest('[elem-identifier="AccordionInner"]').css("height", element.closest('[elem-identifier="AccordionInner"]').height() + (heightdropdown - heightcontainer));
            }
        });
        
        const rowActionButtons = $("[elem-identifier=\"RowActions\"]").find("button.dropdown");
        rowActionButtons.click(function () {
            // The dropdown button to toggle
            const dropdownBtnEl = $(this);

            // The table container (where the scroll occurs)
            const tableScrollContainer = document.getElementById(tableId).parentElement;

            const closeDropdownsOnTableScroll = function () {
                // If the dropdown is open, toggle it (close)
                if (dropdownBtnEl.attr("aria-expanded") == "true")
                    dropdownBtnEl.dropdown("toggle");

                // The listener is no longer needed
                tableScrollContainer.removeEventListener(
                    "scroll",
                    closeDropdownsOnTableScroll,
                    false
                );
            };

            // Only adds the listener if the dropdown is opening
            if (dropdownBtnEl.attr("aria-expanded") != "true") {
                // Close the dropdown on table scroll
                tableScrollContainer.addEventListener(
                    "scroll",
                    closeDropdownsOnTableScroll,
                    false
                );
            }
        });

        if (settings.container) {
            // Adds the search action to search button
            $("#" + settings.container + " .search [data-search-btn]").click(this.Search);
        }
    };

    var DbEditFor = function (element, options, enabled) {
        $.extend(this, new TableFor(element, options));

        var tableId = this._(element).tableId;
        var isDisabled = false;

        var dbEditDefaults = {
            tableFilters: this._(element).tableId + '_tableFilters',
            queryField: 'q' + this._(element).tableId,
            query: ''
        };

        var settings = $.extend(true, {}, dbEditDefaults, this._(element).settings);
        var defaults = this._(element).defaults;

        this._ = function (aKey) {
            return aKey === element && { tableId: tableId, defaults: defaults, settings: settings };
        };

        this.IsEnabled = function () {
            return !isDisabled;
        };

        this.Enable = function (enabled) {
            _setState(!enabled);
        };
        var _setState = function (disable) {
            //Disable or Enable Edit, Delete and Insert buttons

            if(!disable)
                $("#" + tableId + " li.disabled > a, #" + tableId + " a.disabled").unbind("click");

            $.each($("#" + tableId).find('a'), function (key, value) {
                if ($(value).attr("href")) {
                    if ($(value).attr("href").indexOf('_Edit/') !== -1 || $(value).attr("href").indexOf('_Delete/') !== -1) {
                        if (disable)
                            $(value).parent().addClass("disabled");
                        else
                            $(value).parent().removeClass("disabled");
                    }
                    else if ($(value).attr('href').indexOf('_New') !== -1) {
                        if (disable)
                            $(value).addClass("disabled");
                        else
                            $(value).removeClass("disabled");
                    }
                }
            });

            if (disable)
                $("#" + tableId + " li.disabled > a, #" + tableId + " a.disabled").click(function (event) {
                    event.preventDefault();
                });

            isDisabled = disable;
        };

        var table = $('#' + settings.container).find('table#' + tableId);
        if (table.find("td.selectable").length > 0) {
            var rows = table.find("td.selectable").parent();

            rows.each(function (idx, row) {
                var rowAnchor = $(row).find("td.selectable a[data-followup-button]");
                $($(row).find("td:not(.selectable):not([elem-identifier='CheckableColumn'])")).click(function (event) {
                    var _eTarget = $(event.target);
                    // Click on the columns with the links will perform the own action.
                    if (_eTarget.is('a')) { return; }

                    if (!event.ctrlKey && !event.altKey) {
                        if (_eTarget.attr("elem-identifier") == "RowData") {
                            // Skip page change confirmation on follow-up row click
                            window.qVar_isControlledRedirect = true;
                        }
                        rowAnchor[0].click();
                    }
                });
                /*FIX FOR TABBING*/
                rowAnchor.focus(function(){
                    rowAnchor.parent().parent().addClass("highlighted");
                });
                rowAnchor.blur(function(){
                    rowAnchor.parent().parent().removeClass("highlighted");
                });
            });

            rows.mouseenter(function () {
                $(this).addClass("highlighted");
            });
            rows.mouseleave(function () {
                $(this).removeClass("highlighted");
            });
        }

        ///commented because this changed the behavior in the case of multiselection
        //// Hide Actions Column Wher the followup action is the same as only action allowed
        //if ($("table").find(".view-action").length >= 1 || $("table").find(".edit-action").length >= 1) {
        //    $("table#" + tableId + " th:nth-child(1), td:nth-child(1)").hide();
        //}

        var column_forms = table.find("td[data-col-field]:not(.selectable) a[data-href]");
        $.each(column_forms, function (idx, td) {
            $(td).click(function (event) {
                if($(this).data('ispopup'))
                    OpenModalForm($(this).data('href'), {}, tableId);
                else
                    QUtils.NavigateTo = $(this).data('href');
            });
        });

        _setState(!enabled);

        //MH [temp Bugfix] - Nas colunas com border visivel conseguese ver que filtro fica mal posicionado e saem para fora do limite da coluna
        $.each($(element).find('input:not([type=radio], [type=checkbox], [data-format])'), function (index, value) { $(value).css('padding-left', 0); $(value).css('padding-right', 0); $(value).css('width', '95%'); })

		//DSG [temp Bugfix] - adds headers to the table footer to comply with the accessibility rule WCAG2AA.Principle1.Guideline1_3.1_3_1.H43.MissingHeadersAttrs
        addHeaders($(element));
    };

    var TableListFor = function (element, options, enabled) {
        $.extend(this, new DbEditFor(element, options, enabled));
    };

    var CheckListFor = function (element, options) {
        $.extend(this, new TableFor(element, options));

        var tableId = this._(element).tableId;

        var checkListDefaults = {
            isExtended: false,
            extentedControlId: ''
        };

        var settings = $.extend(true, {}, checkListDefaults, this._(element).settings);
        var defaults = this._(element).defaults;

        var _setExtendedContent = function () {
            var checkedRows = $('#' + tableId).find('tr[data-checked=\'true\']');

            var names = '';
            for (var i = 0; i < checkedRows.length; i++) {
                names += '<div class="i-chip f-filter__active-filter mb-2">';
                names += '<a class="i-chip--action" href="#" onclick="closeExtendedListItem(\'' + tableId + '\',\'' + $(checkedRows.get(i)).attr('data-key') + '\')">';
                names += '<i class="glyphicons glyphicons-remove-sign i-chip__icon" ></i></a>' + $($(checkedRows.get(i)).children().get(1)).html() + '</div> ';
            }
            names = names.substr(0, names.length - 2);

            $('div#' + settings.extentedControlId).html(names);
        };

        var _checkListClick = function (cb) {
            var row = $(cb).closest('tr');
            var isChecked = row.attr('data-checked') === 'true';

            row.attr('data-checked', (!isChecked).toString());
            _setExtendedContent();
        };

        this._ = function (aKey) {
            return aKey === element && { tableId: tableId, defaults: defaults, settings: settings };
        };

        if (settings.isExtended) {
            $(element).find('input:checkbox').click(function () {
                _checkListClick(this);
            });
            _setExtendedContent();
        }
    };

    var MultiformFor = function (element, options) {
        var activeInsert = false;
        var insertId = "";

        $.extend(this, new TableFor(element, options));

        this.HasActiveInsert = function () {
            return activeInsert;
        }

        this.IsInsertBeingSaved = function (id) {
            return id === insertId;
        }

        this.ActiveInsert = function (id) {
            activeInsert = true;
            insertId = id;
        }

        this.InsertDone = function (id) {
            if (id === insertId) {
                activeInsert = false;
                insertId = "";
            }
        }
    };

    var GridTableListFor = function (element, options) {
        $.extend(this, new TableFor(element, options));

        var tableId = this._(element).tableId;
        var table = undefined;
        var disabled = false;
        var keyOfEditingRow = undefined;
        var rowInEditMode = undefined;
        var focusedField = undefined;
        var insertionFocusedField = undefined;
        var pendingInsertionRows = false;
        var numberOf_addedInsertionRows = 0;
        var firstFieldsManipulationExecuted = false;
        var insertingRows_mode = false;
        var deletingRows_mode = false;
        var paginating_mode = false;
        var insertedRowsWithErrors = false;
        var deletedRowsWithErrors = false;
        var editedRowsWithErrors = false;
        var reloadTrigger = undefined;
        var pageTrigger = undefined;
        var newRowId = 'gtl_' + tableId + '_newR';
        var newRowInputsId = 'gtl_' + tableId + '_newI';
        var insertButtonId = 'gtl_' + tableId + '_InsertRows';
        var deleteButtonId = 'gtl_' + tableId + '_DeleteSelectedRows';
        var rowsInQueue = new Array();

        var gridTableListDefaults = {
            keyName: null,
            foreignKeyName: null,
            foreignKeyValue: null,
            isEmpty: false,
            saveAction: null,
            insertAction: null,
            deleteAction: null,
            newRowTemplate: null
        };

        var settings = $.extend(true, {}, gridTableListDefaults, this._(element).settings);
        var defaults = this._(element).defaults;

        var _enable = function (row) {
            if (!insertingRows_mode && !deletingRows_mode) {
                var tableInputs = table.find('input, select');
                tableInputs.each(function (idxTI, tableInput) {
                    tableInput = $(tableInput);
                    if (tableInput.data('gtl_input_disabled') !== undefined && tableInput.data('gtl_input_disabled') == false)
                        tableInput.prop('disabled', false);
                });

                table.find('select').trigger("liszt:updated");
                disabled = false;
            }
            else if ((insertingRows_mode && insertedRowsWithErrors && row) || (deletingRows_mode && deletedRowsWithErrors && row)) {
                row.find('input, select').prop('disabled', false);
                row.find('select').trigger("liszt:updated");
            }
        };

        var _disable = function () {
            var tableInputs = table.find('input, select');
            tableInputs.each(function (idxTI, tableInput) {
                tableInput = $(tableInput);
                if (tableInput.is('[disabled]') && tableInput.data('gtl_input_disabled') === undefined)
                    tableInput.data('gtl_input_disabled', true);
                else if (!tableInput.is('[disabled]'))
                    tableInput.prop('disabled', true).data('gtl_input_disabled', false);
            });

            table.find('select').trigger("liszt:updated");
            disabled = true;
        };

        var _setInsertionRowClass = function (row, cssClass) {
            if (row.hasClass(cssClass))
                row.removeClass(cssClass);

            switch (cssClass)
            {
                case 'warning':
                    row.addClass(cssClass);
                    row.css('background-color', '#FBEED5');
                    break;
                case 'error':
                    row.addClass(cssClass);
                    row.css('background-color', '#F2D5D5');
                    break;
                case 'success':
                    row.addClass(cssClass);
                    row.css('background-color', '#CDEDC0');
                    break;
            }
        };

        // BEGIN Init GTL
        var _manipulateFieldsId = function (addedInsertionRow) {
            table = $('#' + tableId);
            var rows = table.find('tr[data-key], tr[data-gridtablelist-newrow]');

            if (addedInsertionRow && addedInsertionRow.is('[data-gridtablelist-newrow="true"]') && addedInsertionRow.is('[id="' + newRowId + '_' + (numberOf_addedInsertionRows - 1).toString() + '"]')) {
                rows = addedInsertionRow;
            }
            else if (firstFieldsManipulationExecuted) {
                return;
            }

            rows.each(function (r, row) {
                if (row) {
                    row = $(row);
                    var isInsertRow = row.is('[data-gridtablelist-newrow="true"]');
                    var newInputIndex = numberOf_addedInsertionRows > 0 ? (numberOf_addedInsertionRows - 1).toString() : '';
                    var rowKey = isInsertRow ? newRowInputsId + newInputIndex : row.attr('data-key');
                    rowKey = rowKey.replace(/ /g, "_");
                    var fields = row.find('td').find('input:not([data-gridtablelist="true"]), select')

                    fields.each(function (f, field) {
                        if (field) {
                            field = $(field);
                            var id = field.attr('id');
                            var newId = rowKey + "_" + id;
                            field.data('realId', id);
                            field.attr('id', newId);
                            field.data('rowKey', rowKey);

                            if (field.attr('dependant') !== undefined)
                            {
                                var dependant = field.attr('dependant');
                                var newDependant = rowKey + "_" + dependant;
                                field.data('realDependant', dependant);
                                field.attr('dependant', newDependant);

                                var dependant_area = field.attr('dependant-area');
                                var newDependant_area = rowKey + "_" + dependant_area;
                                field.data('realDependant-area', dependant_area);
                                field.attr('dependant-area', newDependant_area);

                                //field.subscribe();
                                field.removeData('subscribe');
                            }

                            if (field.attr('pers-cs-area') !== undefined)
                            {
                                var pers_cs_area = field.attr('pers-cs-area');
                                var newPers_cs_area = rowKey + "_" + pers_cs_area;
                                field.data('realPers-cs-area', pers_cs_area);
                                field.attr('pers-cs-area', newPers_cs_area);
                            }

                            var triggersData = { key: rowKey, field: field, fromInsertRow: isInsertRow };

                            if (field.is('select')) {
                                field.removeData('see-more').attr('data-see-more', '');
                                field.removeData('see-more-url').attr('data-see-more-url', '');

                                var chzn = field.closest('td').find('#' + id + "_chzn");
                                if (chzn) {
                                    field.show().removeClass('chzn-done');
                                    field.next().remove();
                                    field.chosen({ allow_single_deselect: true });
                                }
                            }

                            if (field.closest('div').hasClass('date') && field.closest('div').data("datetimepicker") !== undefined) {
                                var dtDiv = field.closest('div');
                                dtDiv.on('changeDate', function (event) {
                                    $(document).trigger('GRIDTABLELIST_VALFIELDCHANGE', triggersData);
                                }).on("show", function () {
                                    $(document).trigger('GRIDTABLELIST_FIELDFOCUSED', triggersData);
                                });
                            }

                            field.on('change', function (event, params) {
                                if (($(event.target).is('select') && params) || $(event.target).is('input')) {
                                    $(document).trigger('GRIDTABLELIST_VALFIELDCHANGE', triggersData);
                                }
                                else if ($(event.target).is('select') && params === undefined && $(event.target).val() == "") {
                                    field.trigger("chosen:focus");
                                    $(document).trigger('GRIDTABLELIST_VALFIELDCHANGE', triggersData);
                                }
                            }).on("focus chosen:focus", function () {
                                $(document).trigger('GRIDTABLELIST_FIELDFOCUSED', triggersData);
                            });

                            if (isInsertRow) {
                                field.keypress(function (event) {
                                    var keycode = (event.keyCode ? event.keyCode : event.which);
                                    if (keycode === '13' || keycode === '10' || keycode === 9) {
                                        if (field.closest('tr').is("#" + tableId + " tr[data-gridtablelist-newrow]:last")) {
                                            _insertNewInsertionRow();
                                        }
                                        if(keycode !== 9)
                                            event.preventDefault();
                                    }
                                });
                            }
                        }
                    });
                }
            });

            $(document).bind("GRIDTABLELIST_VALFIELDCHANGE GRIDTABLELIST_FIELDFOCUSED", function (event, data) {
                if (!data.fromInsertRow) {
                    if (event.type === "GRIDTABLELIST_VALFIELDCHANGE") {
                        _fieldValueChanged(data.field, data.key);
                    }
                    else if (event.type === "GRIDTABLELIST_FIELDFOCUSED") {
                        _fieldFocused(data.field, data.key);
                    }
                }
                else {
                    if (event.type === "GRIDTABLELIST_VALFIELDCHANGE") {
                        var row = data.field.closest('tr');
                        if (!row.hasClass('warning')) {
                            _setInsertionRowClass(row, 'warning');
							if (row.is("table#" + table.attr('id') + " tr[data-gridtablelist-newrow]:last"))
                                _insertNewInsertionRow();
                        }

                        var isBtnDisabled = table.find('a#' + insertButtonId ).hasClass('disabled');
                        if (isBtnDisabled) {
                            table.find('a#' + insertButtonId).removeClass('disabled').show();
                        }

                        pendingInsertionRows = true;

                        if (focusedField !== data.field)
                        {
                            _manipulateDependanciesProperties(data.field, undefined, false, true, data.field.closest('tr'));
                            insertionFocusedField = data.field;
                        }
                    }
                    else if (event.type === "GRIDTABLELIST_FIELDFOCUSED" && keyOfEditingRow) {
                        _manipulateDependanciesProperties(data.field, undefined, true, true, data.field.closest('tr'));
                        var allRows = table.find(' > tbody > tr[data-key]');
                        if (allRows.length > 1 && keyOfEditingRow) {
                            editedRowsWithErrors = false;
                            _saveRow(rowInEditMode, keyOfEditingRow, false);
                        }
                    }
                }
            });

            firstFieldsManipulationExecuted = true;
        };

        var _setRowsSelectable = function (row) {
            var checkboxList = undefined;

            if (row)
                checkboxList = row.find('input[data-gridtablelist="true"]');
            else
                checkboxList = table.find('input[data-gridtablelist="true"]');

            checkboxList.each(function (f, checkbox) {
                if (checkbox) {
                    checkbox = $(checkbox);

                    checkbox.on('change', function (event, params) {
                        var hasSelected = table.find('input[data-gridtablelist="true"]:checked').length > 0;
                        var isBtnDisabled = table.find('a#' + deleteButtonId).hasClass('disabled');

                        if (hasSelected && isBtnDisabled) {
                            table.find('a#' + deleteButtonId).removeClass('disabled').show();
                        }
                        else if (!hasSelected && !isBtnDisabled) {
                            table.find('a#' + deleteButtonId).addClass('disabled').hide();
                        }
                    });
                }
            });
        };

        var _fillInsertionRows = function () {
            var savedData = _getPersistedPendingInsertionRows();

            if (savedData) {
                $(savedData).each(function (idx, data) {
                    var row;
                    if (idx === 0) {
                        row = table.find('tr[id="' + newRowId + '"]');
                    }
                    else {
                        _insertNewInsertionRow();
                        row = table.find('tr[id="' + newRowId + '_' + (numberOf_addedInsertionRows - 1).toString() + '"]');
                    }
                    var isDefaultRow = row.is('[id="' + newRowId + '"]');
                    var inputIndex = isDefaultRow ? '' : (numberOf_addedInsertionRows - 1).toString();

                    var fields = row.find('td').children('input, select');
                    fields.each(function (f, field) {
                        field = $(field);
                        var id = field.attr('id');
                        var regex = new RegExp(newRowInputsId + inputIndex + "_", 'g');
                        id = id.replace(regex, "");
                        var value = data[id];

                        if (data.hasOwnProperty(id)) {
                            if (field.is(':checkbox') || field.is(':radio')) {
                                field.prop("checked", value);
                            }
                            else if (field.is('select')) {
                                field.val(value).trigger("liszt:updated");
                            }
                            if (field.is('[data-mask-number]')) {
                                field.val(value);
                                field.attr("value", value);
                            }
                            else {
                                field.val(value);
                            }
                        }
                    });

                    _setInsertionRowClass(row, 'warning');
                    var isBtnDisabled = table.find('a#' + insertButtonId).hasClass('disabled');
                    if (isBtnDisabled) {
                        table.find('a#' + insertButtonId).removeClass('disabled').show();
                    }
                    pendingInsertionRows = true;
                });

                _clearPersistedPendingInsertionRows();
            }
        };
        // END Init GTL


        // BEGIN Persistence
        var _clearPersistedPendingInsertionRows = function () {
            QLocalStorage.remLocalStorage("gtlIns_" + tableId);
        };

        var _getPersistedPendingInsertionRows = function () {
            var data = QLocalStorage.getLocalStorage("gtlIns_" + tableId);
            return $.isEmptyObject(data) ? undefined : data;
        };

        var _setPersistedPendingInsertionRows = function (data) {
            QLocalStorage.setLocalStorage("gtlIns_" + tableId, $.isEmptyObject(data) ? {} : data);
        };

        var _persistPendingInsertionRows = function () {
            if (pendingInsertionRows ) {
                _clearPersistedPendingInsertionRows();

                var params = undefined;
                var newRows = table.find('tr[data-gridtablelist-newrow]');

                newRows.each(function (idxR, newRow) {
                    if (idxR === 0)
                        params = "[";

                    newRow = $(newRow);
                    var isDefaultRow = newRow.is('[id="' + newRowId + '"]');
                    var inputIndex = isDefaultRow ? '' : (idxR - 1).toString();
                    var hasChangedValues = newRow.hasClass('warning') || newRow.hasClass('error');

                    if (hasChangedValues) {
                        var rowData = GetPostRquestParameters(newRow.find('input, select'), null);
                        rowData[settings.foreignKeyName] = settings.foreignKeyValue;
                        rowData["defaultRow"] = isDefaultRow;
                        rowData["rowId"] = newRow.attr('id');
                        var stringified = JSON.stringify(rowData);
                        var regex = new RegExp(newRowInputsId + inputIndex + "_", 'g');
                        params += stringified.replace(regex, "");

                        if (idxR < newRows.length - 1) {
                            params += ", ";
                        }
                    }

                    if (idxR === newRows.length - 1) {
                        if (params.substring(params.length - 2) === ", ")
                            params = params.substring(0, params.length - 2);

                        params += "]";
                        params = JSON.parse(params);
                    }
                });

                if (params)
                    _setPersistedPendingInsertionRows(params);
            }
        };
	    // END Persistence


	    // BEGIN Triggers
        var _manipulateDependanciesProperties = function (contextField, datakey, fromFocus, fromInsertion, rowInInsertion) {
            var fields = contextField.closest('tr').find('td').find('input:not([data-gridtablelist="true"]), select');

            if (fromFocus !== undefined && fromFocus == true && rowInEditMode !== undefined && keyOfEditingRow !== undefined)//se vem do focus
            {
                fields = rowInEditMode.find('td').find('input:not([data-gridtablelist="true"]), select');
                fields.each(function (f, field) {
                    if (field) {
                        field = $(field);
                        if (field.attr('pers-cs-area') !== undefined && field.data('realPers-cs-area') === undefined) {
                            var pers_cs_area = field.attr('pers-cs-area');
                            var newPers_cs_area = keyOfEditingRow + "_" + pers_cs_area;
                            field.data('realPers-cs-area', pers_cs_area);
                            field.attr('pers-cs-area', newPers_cs_area);
                        }

                        if (field.attr('dependant-area') !== undefined && field.data('realDependant-area') === undefined) {
                            var dependant_area = field.attr('dependant-area');
                            var newDependant_area = keyOfEditingRow + "_" + dependant_area;
                            field.data('realDependant-area', dependant_area);
                            field.attr('dependant-area', newDependant_area);
                        }
                    }
                });

                if (fromInsertion !== undefined && fromInsertion === false)
                    fields = table.find('tr[data-key="' + datakey + '"]').find('td').find('input:not([data-gridtablelist="true"]), select');
                else
                    fields = rowInInsertion.find('td').find('input:not([data-gridtablelist="true"]), select');
            }
            else if (fromFocus !== undefined && fromFocus === false && pendingInsertionRows === true && insertionFocusedField !== undefined && insertionFocusedField.closest('tr').is('[data-gridtablelist-newrow="true"]'))
            {
                //var isInsertRow = row.is('[data-gridtablelist-newrow="true"]');
                var allNewRows = table.find('tfoot > tr[data-gridtablelist-newrow="true"]');
                var actualNewFocusedRow = insertionFocusedField.closest('tr');
                var idx = $.inArray(actualNewFocusedRow[0], allNewRows);

                var newRowId = newRowInputsId;
                if (idx > 0)
                    newRowId += (idx - 1).toString();

                //var newInputIndex = numberOf_addedInsertionRows > 0 ? (numberOf_addedInsertionRows - 1).toString() : '';
                //var rowKey = isInsertRow ? newRowInputsId + newInputIndex : row.attr('data-key');
                //rowKey = rowKey.replace(/ /g, "_");
                //var fields = row.find('td').find('input:not([data-gridtablelist="true"]), select')


                var newRowFields = insertionFocusedField.closest('tr').find('td').find('input:not([data-gridtablelist="true"]), select');
                newRowFields.each(function (f, field) {
                    if (field) {
                        field = $(field);
                        if (field.attr('pers-cs-area') !== undefined) {
                            var pers_cs_area = field.attr('pers-cs-area');
                            var newPers_cs_area = newRowId + "_" + pers_cs_area;
                            field.data('realPers-cs-area', pers_cs_area);
                            field.attr('pers-cs-area', newPers_cs_area);
                        }

                        if (field.attr('dependant-area') !== undefined) {
                            var dependant_area = field.attr('dependant-area');
                            var newDependant_area = newRowId + "_" + dependant_area;
                            field.data('realDependant-area', dependant_area);
                            field.attr('dependant-area', newDependant_area);
                        }
                    }
                });

                if (fromInsertion !== undefined && fromInsertion === false)
                    insertionFocusedField = undefined;
            }


            if (fromInsertion !== undefined && (fromInsertion === false || (fromInsertion === true && fromFocus !== undefined && fromFocus === false)))
            {
                if (pendingInsertionRows === true && fromInsertion !== undefined && fromInsertion === false && insertionFocusedField !== undefined && insertionFocusedField.closest('tr').is('[data-gridtablelist-newrow="true"]'))
                    fields = insertionFocusedField.closest('tr').find('td').find('input:not([data-gridtablelist="true"]), select');

                fields.each(function (f, field) {
                    if (field) {
                        field = $(field);
                        if (field.data('realPers-cs-area') !== undefined) {
                            field.attr('pers-cs-area', field.data('realPers-cs-area'));
                            field.removeData('realPers-cs-area');
                            field.removeData('subscribe');
                        }

                        if (field.data('realDependant-area') !== undefined) {
                            field.attr('dependant-area', field.data('realDependant-area'));
                            field.removeData('realDependant-area');
                            field.removeData('subscribe');
                        }
                    }
                });

                fields.each(function (f, field) {
                    if (field) {
                        field = $(field);
                       // field.subscribe();
                    }
                });
            }

            if (fromFocus === false && contextField.is('[dependant]'))
            {
                var filedsub = contextField.data('subscribe');
                filedsub.triggerFieldChange(this, contextField);
            }
        }

        var _fieldFocused = function (field, datakey) {
            if (!focusedField) {
                focusedField = field;
            }

            if (keyOfEditingRow !== undefined && keyOfEditingRow !== datakey && focusedField !== field) {
                _manipulateDependanciesProperties(field, datakey, true, false, undefined);
                focusedField = field;
                editedRowsWithErrors = false;
                _saveRow(rowInEditMode, keyOfEditingRow, false);
            }

            focusedField = field;
        };

        var _fieldValueChanged = function (field, datakey) {
            var row = field.closest('tr');
            if (!row.hasClass('info')) {
                row.addClass('info');
            }

            if (!keyOfEditingRow) {
                keyOfEditingRow = datakey;
                rowInEditMode = row;

                _manipulateDependanciesProperties(field, datakey, false, false, undefined);
            }

            var allRows = $('#' + tableId + ' > tbody > tr[data-key]');
            if (allRows.length === 1 && field.data("subscriptors") === undefined) {
                editedRowsWithErrors = false;
                _saveRow(rowInEditMode, keyOfEditingRow, false);
                //keyOfEditingRow = focusedField = rowInEditMode = undefined;
            }
        };
        // END Triggers


        // BEGIN Table Actions
        var _saveEditRows = function () {
           // _manipulateDependanciesProperties(rowInEditMode, keyOfEditingRow, false, false, undefined);
            $("#ValLstcol").find('tr').each(function (e, tr) {
                if ($(this).hasClass('info') || $(this).hasClass('warning')) {
                    keyOfEditingRow = ($(tr).attr("data-key"));

                    _saveRow($(this), keyOfEditingRow, false);
                }
            })

        }

        var _saveRow = function (row, keyOfRow, isInsertion, dataToInsert, isLastRow) {
            keyOfRow = keyOfRow.replace(/ /g, "_");
            if (!isInsertion)
            {
                if (rowsInQueue.indexOf(keyOfRow) === -1) {
                    rowsInQueue[rowsInQueue.length] = keyOfRow;
                }
                else {
                    return;
                }
            }

            if (!isInsertion) {
                row.removeClass('info');
                row.addClass('warning');
            }
            if (table.find('tr#errorRow_' + keyOfRow).length > 0) {
                table.find('tr#errorRow_' + keyOfRow).remove();
            }
            _disable();

            var params = dataToInsert;
            if (!isInsertion) {
                params = GetPostRquestParameters(row.find('input:not([data-gridtablelist="true"]), select'), null);
                var stringified = JSON.stringify(params);
                var regex = new RegExp(keyOfRow + "_", 'g');
                params = JSON.parse(stringified.replace(regex, ""));
                params[settings.keyName] = keyOfRow.replace(/_/g, " ");
                params[settings.foreignKeyName] = settings.foreignKeyValue;
            }
            else if(row.hasClass("error")) {
                params[settings.keyName] = row.attr('data-key');
            }

            params["InsertMode"] = isInsertion;
            params["Expose"] = tableId;

            $.ajax({
                url: (isInsertion && (!row.hasClass("error") || row.attr('data-key') === undefined || row.attr('data-key') === null) ? settings.insertAction : settings.saveAction),
                type: 'POST',
                data: params,
                beforeSend: function( xhr ) {
                    _enable();
                }
            })
            .done(function (data, textStatus, jqXHR) {
                if (data) {
                    var savedRow = table.find(data.InsertMode ? 'tr[id="' + data.InsertedRow + '"]' : 'tr[data-key="' + data.Key + '"]');
                    var cellsCount = savedRow.find('td:visible').length;
                    savedRow.removeClass("success error warning").addClass(data.Success ? "success" : "error");
                    if (data.InsertMode)
                        _setInsertionRowClass(savedRow, data.Success ? "success" : "error");

                    if (!data.Success) {
                        if (data.InsertMode) {
                            insertedRowsWithErrors = true;
                            savedRow.attr('data-key', data.Key);
                            savedRow.find('td:first').data('oldHtml', savedRow.html());
                            if (data.Key !== undefined && data.Key !== null)
                            {
                                savedRow.find('td:first').html('<input type="checkbox" value="' + data.Key + '" data-gridtablelist="true">');
                                _setRowsSelectable(savedRow);
                            }
                            _enable(savedRow);
                        }
                        else {
                            editedRowsWithErrors = true;
                        }

                        var messages = "";
                        for (var m in data.Messages) {
                            messages += "<li>" + data.Messages[m].toString() + "</li>";
                        }
                        var errorRow = $("<tr id='errorRow_" + (data.InsertMode ? data.InsertedRow : data.Key.replace(/ /g, "_")).toString() + "' class='error'><td style='color:red;font-weight:bold;' colspan='" + cellsCount.toString() + "'><ul>" + messages + "</ul></td></tr>");
                        if (data.InsertMode)
                            _setInsertionRowClass(errorRow, 'error');
                        errorRow.insertBefore(savedRow);
                    }
                    else {
                        if (data.InsertMode && savedRow.find('td:first').data('oldHtml') !== undefined)
                            savedRow.html(savedRow.find('td:first').data('oldHtml'));
                    }

                    if (insertingRows_mode && isLastRow && !insertedRowsWithErrors) {
                        insertingRows_mode = false;
                        _enable();
                    }
                    else if (data.InsertMode == false) {
                        var allRows = table.find('> tbody > tr[data-key]');
                        if (allRows.length > 1) {
                            keyOfEditingRow = undefined;
                        }

                        var queueRowIndex = rowsInQueue.indexOf(data.Key);
                        if (queueRowIndex !== -1) {
                            rowsInQueue.splice(queueRowIndex, 1);
                        }
                    }
					if (savedRow.length > 0) {
						$(document).trigger('GRIDTABLELIST_ROWSAVED', { tableId: table.attr('id'), serverData: data });
					}
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                if (errorThrown !== "canceled")
                    table.find(isInsertion ? 'tr[id="' + keyOfRow + '"]' : 'tr[data-key="' + keyOfRow + '"]').removeClass().addClass("error");
            });
        };

        var _deleteRow = function (row, key, fromInsertedRow, isLastRow) {
            if (fromInsertedRow) {
                if (table.find('tr#errorRow_' + row.attr('id')).length > 0)
                    table.find('tr#errorRow_' + row.attr('id')).remove();
            }
            else {
                if (table.find('tr#errorRow_' + key).length > 0)
                    table.find('tr#errorRow_' + key).remove();
            }
            _disable();

            var params = {};

            if (fromInsertedRow && insertingRows_mode)
                params["rowId"] = row.attr('id');

            params[settings.keyName] = key;
            params["InsertMode"] = (fromInsertedRow && insertingRows_mode);
            params["Expose"] = tableId;

            $.ajax({
                url: settings.deleteAction,
                type: 'POST',
                data: params
            })
            .done(function (data, textStatus, jqXHR) {
                if (data) {
                    var deletedRow = table.find(data.InsertMode ? 'tr[id="' + data.InsertedRow + '"]' : 'tr[data-key="' + data.Key + '"]');
                    var cellsCount = deletedRow.find('td:visible').length;

                    if (data.Success) {
                        deletedRow.hide();
                    }
                    else {
                        deletedRowsWithErrors = true;
                        if (data.InsertMode && data.rowId.length > 0) {
                            _setInsertionRowClass(deletedRow, "error");
                            _enable(deletedRow);
                        }
                        else if (data.InsertMode == false) {
                            deletedRow.removeClass().addClass("error");
                        }

                        var messages = "";
                        for (var m in data.Messages) {
                            messages += "<li>" + data.Messages[m].toString() + "</li>";
                        }
                        var errorRow = $("<tr id='errorRow_" + (data.InsertMode ? data.InsertedRow : data.Key).toString() + "' class='error'><td style='color:red;font-weight:bold;' colspan='" + cellsCount.toString() + "'><ul>" + messages + "</ul></td></tr>");
                        if (data.InsertMode && data.rowId.length > 0)
                            _setInsertionRowClass(errorRow, 'error');
                        errorRow.insertBefore(deletedRow);
                    }

                    if (deletingRows_mode && isLastRow && !deletedRowsWithErrors) {
                        if (insertingRows_mode) {
                            var is_InsertedRowsWithErrors = table.find('tr[data-gridtablelist-newrow="true"].error:visible').length > 0;

                            if (!is_InsertedRowsWithErrors)
                                insertedRowsWithErrors = insertingRows_mode = false;
                        }

                        deletingRows_mode = false;
                        _enable();
                    }
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                if (errorThrown !== "canceled")
                    table.find(fromInsertedRow ? 'tr[id="' + key + '"]' : 'tr[data-key="' + key + '"]').removeClass().addClass("error");
            });
        };

        var _insertNewInsertionRow = function () {
            var lineForm = $('<div/>').html(settings.newRowTemplate).text();
            var newRow = $('<tr id="' + newRowId + '_' + (numberOf_addedInsertionRows).toString() + '" data-gridtablelist-newrow="true">' + lineForm + '</tr>');
            newRow.insertAfter(table.find('tr[data-gridtablelist-newrow]:last'));
            numberOf_addedInsertionRows += 1;
            loaded(newRow);
            _manipulateFieldsId(newRow);
        };

        var _deleteSelectedRows = function () {
            var selectedRows = table.find('input[data-gridtablelist="true"]:checked');
            if (!disabled || (deletingRows_mode && deletedRowsWithErrors) || (insertingRows_mode && insertedRowsWithErrors)) {
                if (selectedRows.length > 0) {
                    deletingRows_mode = true;
                    deletedRowsWithErrors = false;
                    _disable();
                    if (!insertingRows_mode)
                        _persistPendingInsertionRows();

                    selectedRows.each(function (idx, checkbox) {
                        var row = $(checkbox).closest('tr');
                        var fromInsert = row.is('[data-gridtablelist-newrow="true"]');

                        if (!insertingRows_mode || (insertingRows_mode && fromInsert))
                            _deleteRow(row, $(checkbox).val(), fromInsert, (idx === (selectedRows.length - 1)));
                    });
                }
            }
        };

        var _insertPendingInsertionRows = function () {
            if (!disabled || (insertingRows_mode && insertedRowsWithErrors)) {
                if (pendingInsertionRows ) {
                    insertingRows_mode = true;
                    insertedRowsWithErrors = false;
                    _disable();
                    _persistPendingInsertionRows();
                    var dataToInsert = _getPersistedPendingInsertionRows();
                    _clearPersistedPendingInsertionRows();

                    $(dataToInsert).each(function (idx, data) {
                        _saveRow(table.find('tr[id="' + data.rowId + '"]'), data.rowId, true, data, (idx === dataToInsert.length - 1));
                    });
                }
            }
        };

        var _basePage = this.Page;
        var _pageGrid = function (_page) {
            if (!disabled) {
                paginating_mode = true;
                _persistPendingInsertionRows();

                if (keyOfEditingRow !== undefined) {
                    if (!pageTrigger) {
                        pageTrigger = setInterval(function () {
                            if (keyOfEditingRow === undefined && !editedRowsWithErrors) {
                                clearInterval(pageTrigger);
                                _basePage(_page);
                                paginating_mode = false;
                            }
                        }, 100);
                    }
                    editedRowsWithErrors = false;
                    _saveRow(rowInEditMode, keyOfEditingRow, false);
                }
                else {
                    _basePage(_page);
                    paginating_mode = false;
                }
            }
        };

        var _baseReload = this.Reload;
        var _reloadGrid = function () {
            if (insertingRows_mode || deletingRows_mode) { // || (insertingRows_mode && insertedRowsWithErrors)
                if (!reloadTrigger) {
                    reloadTrigger = setInterval(function () {
                        if (!insertingRows_mode && !deletingRows_mode && !disabled) {
                            clearInterval(reloadTrigger);
                            _baseReload();
                        }
                    }, 100);
                }
            }
            else {
                _baseReload();
            }
        };
        // END Table Actions


        // BEGIN Public Methods
        this.DeleteSelected = function () {
            _deleteSelectedRows();
            this.Reload();
        };

        this.Insert = function () {
            _insertPendingInsertionRows();
            this.Reload();
        };

        this.Page = function (page) {
            _pageGrid(page);
        };

        this.Reload = function () {
            _reloadGrid();
        };

        this.ClearSavedPendingInsertionRows = function () {
            if (!disabled)
                _clearSavedPendingInsertionRows();
        };

        this._ = function (aKey) {
            return aKey === element && { tableId: tableId, defaults: defaults, settings: settings };
        };

        this.SaveEditRows = function () {
            _saveEditRows();
        }
        // END Public Methods


        $('#' + tableId).ready(function () {
            if (Chosen) {
                Chosen.prototype.activate_field = function () {
                    if (!this.active_field) {
                        this.container.addClass("chzn-container-active");
                        this.active_field = true;
                        this.results_show();
                        this.search_field.val(this.search_field.val());
                        this.form_field_jq.trigger('chosen:focus', { chosen: this });
                        return this.search_field.focus();
                    }
                };
            }

            _manipulateFieldsId();
            _setRowsSelectable();
            _fillInsertionRows();

            if (settings.isEmpty)
                $('#' + tableId).addClass('table');
        });
    };

    $.fn.tableFor = function(options)
    {
        return this.each(function()
        {
            if (undefined === window.listTableFor)
                window.listTableFor = new Array();

            var index = window.listTableFor.length;

            for (var i = 0; i < window.listTableFor.length; i++) {
                if (window.listTableFor[i].GetId() == $(this).attr('id') && window.listTableFor[i].GetType() == options.tableType) {
                    index = i;
                    break;
                }
            }

            if (undefined !== options.tableType) {
                var enabled = true;
                switch (options.tableType) {
                    case "DBedit":
                    case "DBeditMultipleSelection":
                    case "DBeditQuery":
                    case "DBeditNN":
                        if (window.listTableFor[index])
                            enabled = window.listTableFor[index].IsEnabled();

                        window.listTableFor[index] = new DbEditFor(this, options, enabled);
                        break;
                    case "List":
                    case "ListUnfiltered":
                        if (window.listTableFor[index])
                            enabled = window.listTableFor[index].IsEnabled();

                        window.listTableFor[index] = new TableListFor(this, options, enabled);
                        break;
                    case "CheckList":
                    case "CheckListLimited":
                        window.listTableFor[index] = new CheckListFor(this, options);
                        break;
                    case "Multiform":
                        window.listTableFor[index] = new MultiformFor(this, options);
                        break;
                    case "GridTableList":
                        window.listTableFor[index] = new GridTableListFor(this, options);
                        break;
                    default:
                        window.listTableFor[index] = new TableFor(this, options);
                        break;
                }
            }
            else {
                window.listTableFor[index] = new TableFor(this, options);
            }

            $(this).data('tableFor', window.listTableFor[index]);
        }).data('tableFor');
    };
})(jQuery);
