/***************
*  Menu types  *
***************/
// File with important functions for the proper function of the modal form support
// Dependencies:
// - jQuery
//
// To support different types of menus, just add to the element the attribute:
//		- "data-menu-se" - selection between limits
//		- "data-menu-su" - selection of a limit
// And across them all the:
//		- "data-link" - the action that will be submitted

(function ($) {

    function MenuSE() {
        // all elements that should be links for a selection with limits menu, should have the following attributes:
        // data-menu-se -> the attribute identifying that it's in fact a menu SE
        // data-link    -> the url link to the menu SE
        LoadMenu("[data-menu-se]");
    };

    function MenuSU() {
        // all elements that should be links for a selection with limits menu, should have the following attributes:
        // data-menu-su -> the attribute identifying that it's in fact a menu SU
        // data-link    -> the url link to the menu SU
        LoadMenu("[data-menu-su]");
    };

    function MenuSV() {
        // all elements that should be links for a selection with limits menu, should have the following attributes:
        // data-menu-sv -> the attribute identifying that it's in fact a menu SV
        // data-link    -> the url link to the menu SU
        LoadMenu("[data-menu-sv]");
    };

    function LoadMenu(selector) {
        $(selector).off("click").click(async function() {
            var element = $(this);
            var link = element.data("link");

            //Check if its multiple selection
            if (typeof SubmitMultiSelection === 'function' && element.data("routine") == 'SubmitMultiSelection')
            {
                const tblElem = element.closest('[element-identifier="List"]').find('table');

                if (tblElem.length !== 1) {
                    displayMessage('An error ocurred processing your request.', 'e');
                    return;
                }

                const tblControl = tblElem.getQTableList();
                if (!tblControl) {
                    displayMessage('An error ocurred processing your request.', 'e');
                    return;
                }

                link = await SubmitMultiSelection(tblControl.getSelectionsKeys(), true);
            }

            $.OpenLimitMenuForm(link);
        });
    };

    $.SpecialMenus = function () {
        // Check for menus with limits
        MenuSE();
        MenuSU();
        MenuSV();
    };

    $.OpenLimitMenuForm = function (link) {
        var modalDiv = $("#LimitsModal");
        if (!modalDiv.length) {
            // it does not exists
            $("body").append('<div id="LimitsModal" data-ignore-ajax-nav-id="true"></div>');
            modalDiv = $("#LimitsModal");
            modalDiv.data("open", false);
        }
        if (!modalDiv.data("open")) {
            modalDiv.data("open", true);
            modalDiv.qLoad(link);
        } else {
            modalDiv.qLoad(link);
        }
    };
})(jQuery);

function SetSubmitLimitMenu(id, type, alertMessages) {
    $('[data-link]', '#modal_' + id).off("click").click(
        function () {
            var button = $(this);
            var url;
            if (type === "SE") {
                var $minValElem = $('#startLimit', '#modal_' + id);
                var minValue = getFieldValue($minValElem);
                if ($.type(minValue) === 'date') {
                    minValue = minValue.toQString();
                }
                var $maxValElem = $('#endLimit', '#modal_' + id);
                var maxValue = getFieldValue($maxValElem);
                if ($.type(maxValue) === 'date') {
                    maxValue = maxValue.toQString();
                }


                $("#modal_" + id).css("z-index", "1040");
                $(".modal-backdrop").css("z-index", "1030");

                if (minValue === "" || minValue === undefined || minValue === null) {
                    displayMessage(alertMessages.minValueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                if (maxValue === "" || maxValue === undefined || maxValue === null) {
                    displayMessage(alertMessages.maxValueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                url = button.data("link").replace(/rplStartLimit/g, minValue).replace(/rplEndLimit/g, maxValue);

                if (button.data('menu-se') || button.data('menu-su')) {
                    $.OpenLimitMenuForm(url);
                }
                else if (button.attr("target") === '_blank') {
                    QUtils.WindowOpen(url, '_blank');
                }
                else {
                    QUtils.NavigateTo = url;
                }
            }
            else if(type === "SU"){

				var $valElem = $('#limit', '#modal_' + id);
                var value = getFieldValue($valElem);

                if ($.type(value) === 'date') {
                    value = value.toQString();
                }


                $("#modal_" + id).css("z-index", "1040");
                $(".modal-backdrop").css("z-index", "1030");

                if (value === "" || value === undefined || value === null) {
                    displayMessage(alertMessages.valueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                url = button.data("link").replace(/rplLimit/g, value);

                if (button.data('menu-se') || button.data('menu-su')) {
                    $.OpenLimitMenuForm(url);
                }
                else if (button.attr("target") === '_blank') {
                    QUtils.WindowOpen(url, '_blank');
                }
                else {
                    QUtils.NavigateTo = url;
                }
            }

            return false;
        }
    )
}

function SetSubmitMultipleLimitMenu(id, control, type, alertMessages) {
    $('[data-link]', '#modal_' + id).off("click").click(
        function () {
            var button = $(this);
            var url;
            if (type === "ID") {
                var $minValElem = $('#min' + control, '#modal_' + id);
                var minValue = getFieldValue($minValElem);
                if ($.type(minValue) === 'date') {
                    minValue = minValue.toQString();
                }
                var $maxValElem = $('#max' + control, '#modal_' + id);
                var maxValue = getFieldValue($maxValElem);
                if ($.type(maxValue) === 'date') {
                    maxValue = maxValue.toQString();
                }

                $("#modal_" + id).css("z-index", "1040");
                $(".modal-backdrop").css("z-index", "1030");

                if (minValue === "" || minValue === undefined || minValue === null) {
                    displayMessage(alertMessages.minValueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                if (maxValue === "" || maxValue === undefined || maxValue === null) {
                    displayMessage(alertMessages.maxValueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                url = button.data("link").replace(/rplStartLimit/g, minValue).replace(/rplEndLimit/g, maxValue);

                if (button.data('menu-se') || button.data('menu-su') || button.data('menu-sv')) {
                    $.OpenLimitMenuForm(url);
                }
                else if (button.attr("target") === '_blank') {
                    QUtils.WindowOpen(url, '_blank');
                }
                else {
                    QUtils.NavigateTo = url;
                }
            }
            else if (type === "DT") {

                var $valElem = $('#' + control, '#modal_' + id);
                var value = getFieldValue($valElem);

                if ($.type(value) === 'date') {
                    value = value.toQString();
                }

                $("#modal_" + id).css("z-index", "1040");
                $(".modal-backdrop").css("z-index", "1030");

                if (value === "" || value === undefined || value === null) {
                    displayMessage(alertMessages.valueEmpty, MessageDefs.StatusEnum.E);
                    return false;
                }

                url = button.data("link").replace(/rplLimit/g, value);

                if (button.data('menu-se') || button.data('menu-su') || button.data('menu-sv')) {
                    $.OpenLimitMenuForm(url);
                }
                else if (button.attr("target") === '_blank') {
                    QUtils.WindowOpen(url, '_blank');
                }
                else {
                    QUtils.NavigateTo = url;
                }
            }

            return false;
        }
    )
}