(function ($) {
    $.fn.FullCalendar = function (options) {
        var elem = $(this);
        var a = $(elem).data('FullCalendar');
        if (!options || !options.linkReload || !options.data) return a;

        $(elem).data('FullCalendar', this);

        //GET EVENTS INFO
        var events = new Array();
        $.each(options.data, function (i, v) {
            events.push({
                id: v.EventID,
                title: v.Title,
                resourceId: v.resourceId,
                description: v.Description,
                start: v.Start,
                end: v.End !== null ? v.End : null,
                allDay: v.IsFullDay,
                color: v.ThemeColor,
                rendering: v.IsBackground ? 'background' : '',
            });
        });

        //CHECK IF IT'S A SCHEDULER
        var divID = document.getElementsByClassName("ccontrol-FullCalendar")[0].id;
        var extraOptions = document.getElementById(divID).getAttribute("data-extra-options");
        var isScheduler = false;

        if (extraOptions.indexOf("resource") !== -1) {
            isScheduler = true;
        }

        //GET RESOURCES INFO
        var resources = null;
        var resourceLabel = "";
        var groupInfo = new Array();
        var hasChildren = false;
        if (isScheduler) {
            resources = new Array();
            $.each(options.resources, function (i, v) {
                resources.push({
                    id: v.id,
                    title: v.title,
                    group: v.group,
                    groupLabel: v.groupLabel,
                    children: v.children,
                });

                if (typeof v.children !== 'undefined' && v.children.length > 0) {
                    // the array is defined and has at least one element
                    hasChildren = true;
                }

                if (!(v.group in groupInfo)) {
                    groupInfo[v.group] = v.groupLabel;
                }
            });

            //GET RESOURCES LABEL
            if (resources.length !== 0) {
                resourceLabel = options.resources[0].columnLabel;
            }
        }

        /*********************/
        //EXTRA OPTION: fullReload
        //Useful to keep calendar on the same page (view) when different views are used, without 'jumping' to the default view after a form reload
        /*********************/
        function getFullReload() {
            if (extraOptions.indexOf("fullReload") !== -1) {
                return true;
            }
            else {
                return false;
            }
        }
        

        this.Reload = function () {
            localStorage["currentView"] = elem[0].id + "." + calendar.state.viewType;
            if (getFullReload()) {
                window.location.reload();
            }
            else {
            $(elem).load(options.linkReload);
        }
        }

        //Get user's timezone
        var timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;

        //GET VIEWS WHETHER IT'S A FULLCALENDAR OR A SCHEDULER
        function getViewModes() {
            var views = extraOptions;
            return views;
        }

        //GET THE DEFAULT VIEW
        function getDefaultView() {
            //If fullRealod extra option is set, changes the view to the one its stored on localStorage, if its valid
            //Redo this to change the current view using calendar functions 
            if (localStorage["currentView"] !== "" && getFullReload()) {
                var plugins = getPlugins();
                var i = 0;
                var valid = false;
                while (plugins[i] && !valid) {
                    if (localStorage["currentView"].split('.')[1].indexOf(plugins[i]) !== -1) {
                        valid = true;
                    }
                    i++;
                }
                if (valid)
                    return localStorage["currentView"].split('.')[1];
                else
                    localStorage["currentView"] = "";
            }

            var views = extraOptions.split(",");
            var dView = views[0];
            return dView;
        }

        //GET THE PLUGINS TO USE THE VIEWS
        function getPlugins() {
            var plugins = new Array();
            plugins.push("interaction");
            plugins.push("bootstrap");

            if (extraOptions.indexOf("dayGrid") !== -1) {
                plugins.push("dayGrid");
            }

            if (extraOptions.indexOf("timeGrid") !== -1) {
                plugins.push("timeGrid");
            }

            if (extraOptions.indexOf("list") !== -1) {
                plugins.push("list");
            }

            if (extraOptions.indexOf("Timeline") !== -1) {
                plugins.push("resourceTimeline");
            }

            if (extraOptions.indexOf("resourceTimeGrid") !== -1) {
                plugins.push("resourceTimeGrid");
            }

            if (extraOptions.indexOf("resourceDayGrid") !== -1) {
                plugins.push("resourceDayGrid");
            }

            return plugins;
        }

        //EDITS THE EVENT WHEN IT'S MOVED OR RESIZED
        function dropOrResize(info) {
            var hasNewResource = true;

            if (info.oldResource === null && info.newResource === null) {
                hasNewResource = false;
            }

            if (hasChildren && hasNewResource && info.newResource._resource.parentId === "") {
                bootbox.alert(quidgestGlobals.Resources.APENAS_E_PERMITIDO_A39067);
                info.revert();
            } else {
                var parameters = {
                    id: info.event.id,
                    dateTimeINI: info.event.start,
                    dateTimeFIM: info.event.end,
                    isScheduler: isScheduler,
                    hasNewResource: hasNewResource,
                    resourceId: (isScheduler && hasNewResource) ? info.newResource.id : "",
                    hasChildren: hasChildren,
                    noDates: !getShowDates()
                };
                //check if its a resize
                var resize = info.endDelta !== undefined ? true : false;

                //checks if new event colides with the original event:
                var colides = false;
                if (!resize) {
                    var dateTimeINI = info.event.start;
                    var dateTimeFIM = info.event.end;

                    var oldDateTimeINI = info.oldEvent.start;
                    var oldDateTimeFIM = info.oldEvent.end;

                    //colides if New INI falls into old period
                    if ((dateTimeINI.getTime() < oldDateTimeFIM.getTime() && dateTimeINI.getTime() > oldDateTimeINI.getTime())) {
                        colides = true;
                    }

                    //colides if New FIM falls into old period
                    if ((dateTimeFIM.getTime() < oldDateTimeFIM.getTime() && dateTimeFIM.getTime() > oldDateTimeINI.getTime())) {
                        colides = true;
                    }
                }
                //if it colides with eventsOverlap turned off it cannot be duplicated, thus leaving just one option that is to move (change) the original event
                if (resize || (colides && !getEventsOverlap())) {
                    bootbox.confirm(resize ? quidgestGlobals.Resources.PRETENDE_ALTERAR_O_E59231 : quidgestGlobals.Resources.PRETENDE_MOVER_O_EVE36449, function (result) {
                    if (result) {
                        $.ajax({
                            url: options.dragdroplink,
                            data: JSON.stringify(parameters),
                            type: "POST",
                            contentType: 'application/json',
                            dataType: "json",
                            success: function (data) {
                                if (data.success) {
                                        bootbox.alert(resize ? quidgestGlobals.Resources.EVENTO_ALTERADO_COM_57794 : quidgestGlobals.Resources.EVENTO_MOVIDO_COM_SU59433);
                                } else {
                                    bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091);
                                    info.revert();
                                }
                            },
                            error: function () {
                                bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091);
                                info.revert();
                            }
                        });
                        }
                        else {
                            info.revert();
                        }
                    }
                    );
                }
                else {
                    //TRADUÇÕES::::::::::::::::::
                    var popupMessage = quidgestGlobals.Resources.POR_FAVOR_INDIQUE_A_58070;

                    var buttons = [];

                    //actions reorganized in order to other follow all actions displacement throughout the application
                    if (options.editLink) {
                        buttons.push({
                            "label": quidgestGlobals.Resources.MOVER62644,
                            "callback": function () {
                                $.ajax({
                                    url: options.dragdroplink,
                                    data: JSON.stringify(parameters),
                                    type: "POST",
                                    contentType: 'application/json',
                                    dataType: "json",
                                    success: function (data) {
                                        if (data.success) {
                                            bootbox.alert(quidgestGlobals.Resources.EVENTO_MOVIDO_COM_SU59433);
                    } else {
                                            bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091);
                                            info.revert();
                                        }
                                    },
                                    error: function () {
                                        bootbox.alert(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091);
                                        info.revert();
                                    }
                                });
                            }
                        });
                    }

                    if (options.duplicateLink) {
                        buttons.push({
                            "label": quidgestGlobals.Resources.DUPLICAR09748,
                            "callback": function () {
                                $.ajax({
                                    url: options.duplicateLink,
                                    data: JSON.stringify(parameters),
                                    type: "POST",
                                    contentType: 'application/json',
                                    dataType: "json",
                                    success: function (data) {
                                        if (data.success) {
                                            bootbox.alert(quidgestGlobals.Resources.DUPLICACAO_BEM_SUCED21475, $(elem).data('FullCalendar').Reload());
                                        } else {
                                            bootbox.alert(quidgestGlobals.Resources.ERRO_NA_DUPLICACAO15159);
                                            info.revert();
                                        }
                                    },
                                    error: function () {
                                        bootbox.alert(quidgestGlobals.Resources.ERRO_NA_DUPLICACAO15159);
                                        info.revert();
                                    }
                                });
                    }
                });
            }

                    buttons.push({
                        "label": quidgestGlobals.Resources.CANCELAR,
                        "callback": function () { info.revert(); }
                    });

                    //TRADUÇÕES::::::::::::::::::

                    //Bootbox.dialog created for intermediary form w/ edit and delete buttons depending on permission. (Bootbox v2.5.1)
                    bootbox.dialog({
                        header: info.event.title,
                        message: popupMessage,
                        buttons: buttons,
                        closeButton: false
                    });
                }
            }
        }

        //GET THE LICENSE FOR THE SCHEDULER
        function getLicense() {
            if (isScheduler) {
                lic = options.license !== null ? options.license : "";
            } else {
                lic = 'GPL-My-Project-Is-Open-Source';
            }
            return lic;
        }

        //GET THE TRANSLATION OF THE TODAY'S BUTTON TEXT
        function getTodayText() {
            var txt = "";
            txt = quidgestGlobals.Resources.HOJE09655;
            return txt;
        }

        var resDropped = ""; //id of the resource where the external event was dropped. It will be called on the property drop

        /*********************/
        //EXTRA OPTION: noAllDay
        /*********************/
        //CHECK IF ALLDAY SLOT IS TO BE REMOVED
        var noAllDay = false;
        if (extraOptions.indexOf("noAllDay") !== -1) {
            noAllDay = true;
        }

        function getShowAllDay() {
            var showAllDay = true;
            if (noAllDay) {
                showAllDay = false;
            }
            return showAllDay;
        }

        /*********************/
        //EXTRA OPTION: noDates
        /*********************/
        //CHECK IF IT'S A GENERIC CALENDAR WITHOUT DATES
        var noDates = false;
        if (extraOptions.indexOf("noDates") !== -1) {
            noDates = true;
        }

        function getShowDates() {
            var showDates = true;
            if (noDates)
                showDates = false;
            return showDates;
        }

        //funtion to set the calendar on the first monday of the year 2018 which is a Monday when no dates are required. 
        //Since this is fixed and no dates are required, passing dates between calendar and business records will be easier to determine 
        function getFirstMonday() {
            var d = '2018-01-01';
            return d;
        }

        /*********************/
        /*********************/
        //WITHOUT DATES IT'S SUPPOSED TO REMOVE HEADER AND BUTTONS
        var noHeader = false;
        if (!getShowDates()) {
            noHeader = true;
        }
        function getShowHeader() {
            var showHeader = true;
            if (noHeader) {
                showHeader = false;
            }
            return showHeader;
        }

        /*********************/
        //EXTRA OPTION: minTime=07:00:00
        /*********************/
        //CHECK IF IT'S SUPPOSED CHANGE MINTIME
        var minTimeSet = false;
        if (extraOptions.indexOf("minTime") !== -1) {
            minTimeSet = true;
        }

        function getMinTime() {
            var minTime = '00:00:00';
            if (minTimeSet) {
                var minTimeUser = extraOptions.substring(extraOptions.indexOf("minTime=") + 8, extraOptions.indexOf("minTime=") + 18);
                minTime = minTimeUser;
            }
            return minTime;
        }


        /*********************/
        //EXTRA OPTION: maxTime=07:00:00
        /*********************/
        //CHECK IF IT'S SUPPOSED CHANGE maxTIME
        var maxTimeSet = false;
        if (extraOptions.indexOf("maxTime") !== -1) {
            maxTimeSet = true;
        }

        function getMaxTime() {
            var maxTime = '23:59:59';
            if (maxTimeSet) {
                var maxTimeUser = extraOptions.substring(extraOptions.indexOf("maxTime=") + 8, extraOptions.indexOf("maxTime=") + 18);
                maxTime = maxTimeUser;
            }
            return maxTime;
        }

        /*********************/
        //EXTRA OPTION: autoHeight
        /*********************/
        //CHECK IF IT'S SUPPOSED SET CALENDAR HEIGHT AS AUTO
        var autoHeight = false;
        if (extraOptions.indexOf("autoHeight") !== -1 || minTimeSet || maxTimeSet) {
            autoHeight = true;
        }

        /*********************/
        //EXTRA OPTION: maxHeight=YYYYY, 
        /*********************/
        //CHECK IF IT'S SUPPOSED CHANGE maxHeight
        var maxHeightSet = false;
        if (extraOptions.indexOf("maxHeight") !== -1) {
            maxHeightSet = true;
        }

        function getHeight() {
            var height = 750;
            if (autoHeight) {
                height = 'auto';
            }
            if (maxHeightSet) {
                var maxTimeUserTemp = extraOptions.substring(extraOptions.indexOf("maxHeight=") + 10, extraOptions.length);
                var finalIndex = maxTimeUserTemp.indexOf(",") !== -1 ? maxTimeUserTemp.indexOf(",") : maxTimeUserTemp.length;
                height = parseInt(maxTimeUserTemp.substring(0, finalIndex));
            }
            return height;
        }

        /*********************/
        //EXTRA OPTION: noWeekends
        /*********************/
        //CHECK IF IT'S SUPPOSED TO REMOVE WEEKENDS
        var noWeekends = false;
        if (extraOptions.indexOf("noWeekends") !== -1) {
            noWeekends = true;
        }

        function getShowWeekends() {
            var weekends = true;
            if (noWeekends) {
                weekends = false;
            }
            return weekends;
        }

        /*********************/
        //EXTRA OPTION: noTooltips
        /*********************/
        //CHECK IF IT'S SUPPOSED TO HIDE TOOLTIPS
        var noTooltips = false;
        if (extraOptions.indexOf("noTooltips") !== -1) {
            noTooltips = true;
        }

        function getShowTooltips() {
            var tooltips = true;
            if (noTooltips) {
                tooltips = false;
            }
            return tooltips;
        }

        /*********************/
        //EXTRA OPTION: eventOvelaps
        /*********************/
        //CHECK IF IT'S SUPPOSED TO EVENTS TO OVERLAP
        var eventsOverlapOption = false;
        if (extraOptions.indexOf("eventsOverlap") !== -1) {
            eventsOverlapOption = true;
        }

        function getEventsOverlap() {
            var eventOverlap = false;
            if (eventsOverlapOption) {
                eventOverlap = true;
            }
            return eventOverlap;
        }
        /*********************/
        //EXTRA OPTION: limitRange
        /*********************/
        var validRangeSet = false;
        if (extraOptions.indexOf("limitRange") !== -1) {
            validRangeSet = true;
        }        

		//Start and end fields references
        var jqueryStartDateField;
        try {
            jqueryStartDateField = '[data-form] #' + options.validRangeStart.split('.')[1] + '';
        }
        catch {}
        var jqueryEndDateField;
        try {
            jqueryEndDateField = '[data-form] #' + options.validRangeEnd.split('.')[1] + '';
        }
        catch {}

		//Reloads the calendar when start and end date range feilds changes
        $(jqueryStartDateField).on('change', function () {
            $(elem).data('FullCalendar').Reload()
        });

        $(jqueryEndDateField).on('change', function () {
            $(elem).data('FullCalendar').Reload()
        });
        
        function getValidRangeStart() {
            if (validRangeSet && getShowDates()) {
                try {
                    var startDate = moment($(jqueryStartDateField).val(), 'DD/MM/YYYY').toDate();//.format('YYYY/MM/DD');
                    return startDate;
                }
                catch (error) {
                    return null;
                }
            }
            return null;
        }
        

        function getValidRangeEnd() {
            if (validRangeSet && getShowDates()) {
                try {
                    var endDate = moment($(jqueryEndDateField).val(), 'DD/MM/YYYY').toDate();//.format('YYYY/MM/DD');
                    endDate.setDate(endDate.getDate() + 1);
                    return endDate;

                }
                catch (error) {
                    return null;
                }
            }
            return null;
        }



        //BUILDS THE CALENDAR
        var calendar = new FullCalendar.Calendar($(elem)[0], {
            schedulerLicenseKey: getLicense(),
            plugins: getPlugins(),
            defaultView: getDefaultView(),
            editable: options.editable,
            eventTimeFormat: {  // like '14:30'
                hour: '2-digit',
                minute: '2-digit',
                hour12: false   //this property is equal to meridiem (if it's true will add AM or PM)
            },
            slotEventOverlap: true,
            eventOverlap: getEventsOverlap(),
            eventDurationEditable: true, //this needs the interaction plugin
            customButtons: {
                todayButton: {
                    text: getTodayText(),
                    click: function () {
                        calendar.today();
                    }
                }
            },
            dateClick: isScheduler ? function (info) {

                if (!info.jsEvent.target.classList.contains('fc-bgevent')) { //check if the click was on a background event. If it was then does nothing.
                    if (hasChildren && info.resource._resource.parentId === "") {
                        bootbox.alert(quidgestGlobals.Resources.APENAS_E_PERMITIDO_A39067);
                    } else {
                        localStorage["isDateClick"] = true;
                        localStorage["varDate"] = info.dateStr;
                        localStorage["resource"] = info.resource.id;
                        localStorage["allDay"] = info.allDay;


                        var parameters = {
                            startDateField: options.startDateField,
                            endDateField: options.endDateField,
                            dateTimeINI: info.dateStr,
                            minTime: getMinTime(),
                            maxTime: getMaxTime(),
                            noDates: !getShowDates(),
                            NewEdit: false,
                            allDayField: options.allDayField,
                            startTimeField: options.startTimeField,
                            endTimeField: options.endTimeField,
                            allDay: info.allDay,
                            validDateStart: getValidRangeStart() !== null ? getValidRangeStart().toJSON() : null,
                            validDateEnd: getValidRangeEnd() !== null ? getValidRangeEnd().toJSON() : null,
                            isScheduler: isScheduler,
                            hasNewResource: true,
                            resourceId: (isScheduler) ? info.resource.id : "",
                            hasChildren: hasChildren
                        };

                        if (info.resource._resource.parentId !== "") {
                            localStorage["parentId"] = info.resource._resource.parentId;
                        }
                        if (options.newLink) {
                            if (options.IsModal) {
                                OpenModalForm(options.newLink, parameters, null, function () { $(elem).data('FullCalendar').Reload(); });
                            } else {

                                //QUtils.NavigateTo = options.newLink + "&date=" + info.dateStr;
                                QUtils.NavigateTo = options.newLink;
                            }
                        }
                    }
                }
            } : function (info) {
				var hasNewResource = true;

                if (info.oldResource === null && info.newResource === null) {
                    hasNewResource = false;
                }
				
                if (!info.jsEvent.target.classList.contains('fc-bgevent')) {    //check if the click was on a background event. If it was then does nothing.
                    localStorage["isDateClick"] = true;
                    localStorage["varDate"] = info.dateStr;
                    localStorage["allDay"] = info.allDay;

                    var parameters = {
                        startDateField: options.startDateField,
                        endDateField: options.endDateField,
                        dateTimeINI: info.dateStr,
                        minTime: getMinTime(),
                        maxTime: getMaxTime(),
                        noDates: !getShowDates(),
                        NewEdit: true,
                        allDayField: options.allDayField,
                        startTimeField: options.startTimeField,
                        endTimeField: options.endTimeField,
                        allDay: info.allDay,
                        validDateStart: getValidRangeStart() !== null ? getValidRangeStart().toJSON() : null,
                        validDateEnd: getValidRangeEnd() !== null ? getValidRangeEnd().toJSON() : null,
						isScheduler: isScheduler,
						hasNewResource: hasNewResource,
						resourceId: (isScheduler && hasNewResource) ? info.newResource.id : "",
						hasChildren: hasChildren
                    };

                    if (options.newLink) {
                        var newLink = options.newLink;
                        if (options.IsModal) {
                            OpenModalForm(newLink, parameters, null, function () { $(elem).data('FullCalendar').Reload(); });
                        } else {
                            QUtils.NavigateTo = newLink;
                        }
                    }
                }
            },
            eventClick: function (info) {
                if (info.event.rendering !== 'background') { //check if the click was on a background event. If it was then does nothing.
                    var buttons = [];
                    var minTimeCalendarParameter = getMinTime().substring(0, 5); //remove seconds and all after hours and minutes
                    var maxTimeCalendarParameter = getMaxTime().substring(0, 5);
                    var parameters = {
                        id: info.event.id,
                        startDateField: options.startDateField,
                        endDateField: options.endDateField,
                        minTime: minTimeCalendarParameter,
                        maxTime: maxTimeCalendarParameter,
                        noDates: !getShowDates(),
                        NewEdit: false,
                        allDayField: options.allDayField,
                        startTimeField: options.startTimeField,
                        endTimeField: options.endTimeField,
                        allDay: info.event.allDay,
                        validDateStart: getValidRangeStart() !== null ? getValidRangeStart().toJSON() : null,
                        validDateEnd: getValidRangeEnd() !== null ? getValidRangeEnd().toJSON() : null
                    };
                    callbacks = function (link, eventID) {
                        info.jsEvent.preventDefault();
                        info.jsEvent.stopPropagation();
                        if (options.IsModal) {
                            if (link === options.deleteLink) {
                                OpenModalForm(link, parameters, null, null, null, function () { $(elem).data('FullCalendar').Reload(); });
                            }
                            else {
                                OpenModalForm(link, parameters, null, function () { $(elem).data('FullCalendar').Reload(); });
                            }
                        }
                        else {
                            var iQS = link.indexOf('?');
                            QUtils.NavigateTo = link.substr(0, iQS) + '/' + encodeURI(info.event.id) + link.substr(iQS);
                        }
                    };

                    //actions reorganized in order to other follow all actions displacement throughout the application
                    if (options.viewLink) {
                    buttons.push({
                            "label": quidgestGlobals.Resources.CONSULTAR,
                            "callback": function () { callbacks(options.viewLink, info.event.id) }
                        });
                    }

                    if (options.editLink) {
                        buttons.push({
                            "label": quidgestGlobals.Resources.EDITAR,
                            "callback": function () { callbacks(options.editLink, info.event.id) }
                    });
                    }

                    if (options.deleteLink) {
                        buttons.push({
                            "label": quidgestGlobals.Resources.APAGAR,
                            "callback": function () { callbacks(options.deleteLink, info.event.id) }
                        });
                    }

                        buttons.push({
                        "label": quidgestGlobals.Resources.CANCELAR,
                        "callback": function () { }
                        });

                    //message is constructed differently if using "noDates" option (on a week calendar) and also allDay events have are different
                    var startDateFormat = "";
                    var endDateFormat = "";
                    if (getShowDates()) {
                        startDateFormat = info.event.allDay ? moment(info.event.start).format('LL') : moment(info.event.start).format('LLL'); //:->standard event
                        endDateFormat = info.event.allDay ? "" : moment(info.event.end).format('LLL'); //?no end date on allDay events :->standard event
                    }
                    else {
                        startDateFormat = info.event.start.toLocaleString(options.locale, { weekday: "long" }) + (info.event.allDay ? "" : ", " + info.event.start.toLocaleTimeString(options.locale));
                        endDateFormat = info.event.allDay ? "" : info.event.start.toLocaleString(options.locale, { weekday: "long" }) + ", " + info.event.end.toLocaleTimeString(options.locale);
                    }
                    var startDateMessage = '<b>' + quidgestGlobals.Resources.DATA_DE_INICIO + ': </b>' + startDateFormat;
                    var endDateMessage = endDateFormat !== "" ? '<b>' + quidgestGlobals.Resources.DATA_DE_FIM + ': </b>' + endDateFormat + "<br>" : "";

                    var allDayMessage = info.event.allDay ? "<b> (" + calendar.optionsManager.computed.allDayText + ")</b>" : "";

                    var popupMessage = startDateMessage + allDayMessage + "<br>" + endDateMessage
                        + '<b>' + quidgestGlobals.Resources.TITULO_DO_EVENTO64085 + ': </b>' + info.event.title + '<br>' //event title wasn't present for no reason
                        + '<b>' + quidgestGlobals.Resources.DESCRICAO_DO_EVENTO47400 + ': </b>' + info.event.extendedProps.description //description isn't a default field of event, so it is stored on extendedProps

                    //Bootbox.dialog created for intermediary form w/ edit and delete buttons depending on permission. (Bootbox v2.5.1)
                    bootbox.dialog({
                        header: event.title,
                        message: popupMessage,
                        buttons: buttons
                    });
                }
            },
            fixedWeekCount: false, //Determines the number of weeks displayed in a month view.
            //If true, the calendar will always be 6 weeks tall. 
            //If false, the calendar will have either 4, 5, or 6 weeks, depending on the month.

            eventLimit: true, //Limits the number of events displayed on a day. The rest will show up in a popover.
            resourceLabelText: resourceLabel,
            resources: resources,
            resourceGroupField: 'group',
            resourceGroupText: function (groupValue) {
                return groupInfo[groupValue];
            },
            resourceOrder: 'title',
            events: events,
            eventRender: function (info) {
                $(info.el).tooltip({
                    title: info.event.extendedProps.description,
                    trigger: getShowTooltips() ? 'hover' : 'none',
                    placement: 'top',
                    container: 'body'
                });
            },
            eventDrop: dropOrResize, //eventDrop does not get called when an external event lands on the calendar. eventReceive is called instead. // called when an event (already on the calendar) is moved
            eventResize: dropOrResize,
            droppable: true,
            drop: function (info) { //this is called when an external draggable element has been dropped onto the calendar IT'S CALLED BEFORE EVENTRECEIVE
                resDropped = info.resource.id;
            },
            eventReceive: function (info) { // called when a proper external event is dropped
                if (isScheduler && hasChildren && (resources.some(res => res.id === resDropped))) {
                    bootbox.alert(quidgestGlobals.Resources.APENAS_E_PERMITIDO_A39067);
                    $(elem).data('FullCalendar').Reload();
                } else {
                    localStorage["isDateClick"] = false;
                    localStorage["startWhereDragged"] = info.event.start.toQString();
                    localStorage["allDay"] = info.event.allDay;

                    //INSTEAD OF THE OPTION BELOW WE USE THIS METHOD TO WORK ON IE
                    $.each(Object.entries(info.event.extendedProps), function (i, v) {
                        localStorage[v[0]] = v[1];
                    });

                    //THIS OPTION GIVES AN ERROR ON IE
                    /*
                    Object.entries(info.event.extendedProps).forEach(entry => {
                        var key = entry[0];
                        var value = entry[1];
                        localStorage[key] = value;
                    });*/

                    if (isScheduler) {
                        localStorage["resource"] = resDropped;
                        if (options.newLink) {
                            if (options.IsModal) {
                                OpenModalForm(options.newLink, null, null, function () { $(elem).data('FullCalendar').Reload(); }, function () { $(elem).data('FullCalendar').Reload(); });
                            } else {
                                QUtils.NavigateTo = options.newLink;
                            }
                        }
                    } else {
                        if (options.newLink) {
                            if (options.IsModal) {
                                OpenModalForm(options.newLink, null, null, function () { $(elem).data('FullCalendar').Reload(); });
                            } else {
                                QUtils.NavigateTo = options.newLink;
                            }
                        }
                    }
                }
            },
            locale: options.locale, //calendar language
            //timeZone: timezone, //this will get the name of the timezone from the IANA time zone database such as 'Europe/Lisbon'
            themeSystem: 'bootstrap',

            //Extra options added (or changed to be controlled):
            allDaySlot: getShowAllDay(),
            header: getShowHeader() ?
                {
                    left: 'prevYear,prev,next,nextYear todayButton',
                    center: 'title',
                    right: getViewModes(),
                } : {
                    left: '',
                    center: '',
                    right: '',
                },
            nowIndicator: getShowDates(),
            height: getHeight(), //previously we gave the value "auto" but when we had a lot of resources it woud get too big and since it had no scroll, the header wouldn't be fixed
            minTime: getMinTime(),
            maxTime: getMaxTime(),
            weekends: getShowWeekends(),
             //without dates and on week view, shows only name of weekday
            columnHeaderFormat: getShowDates() === false && getDefaultView() === 'timeGridWeek' ? { weekday: 'long' } : { weekday: 'short', month: 'numeric', day: 'numeric', omitCommas: true },
            validRange: { start: getValidRangeStart(), end: getValidRangeEnd() }, //e.g: {start: '2021-05-10', end: '2021-06-25'}
            
        });

        if (!getShowDates()) {
            calendar.gotoDate(getFirstMonday()); //to start the week at a fixed monday (2018)
        }

        calendar.render();


        
       
        //THE BOOTSTRAP THEME DOESN'T ALLOW THE USE OF ICONS BESIDES THE ONES FROM FONT-AWESOME -> THIS FIXES THAT ISSUE
        $('.fa-angle-double-left').addClass("glyphicons glyphicons-rewind e-icon");
        $('.fa-chevron-left').addClass("glyphicons glyphicons-chevron-left e-icon");
        $('.fa-chevron-right').addClass("glyphicons glyphicons-chevron-right e-icon");
        $('.fa-angle-double-right').addClass("glyphicons glyphicons-forward e-icon");
    };
})(jQuery);