/*************************
* QHistory and Window Id *
*************************/
// Some controls should not have the navigation id on the links. ex: GHT_LMS
const Q_NavigationIngnoreContainer = '[data-navigation-ignore-set]';

/**
 * @param {string} nwurl - New window URL (ex: quidgestGlobals.UrlAction.newWindow).
 */
function newWindow(nwurl) {
    var curWinId = $("#CurrentNavigationId");
    var cwi = curWinId.length !== 0 ? curWinId.val() : undefined;
    var firstLoadOfSite = (cwi === undefined && window.name.length === 0 && document.referrer.length === 0);

    //JGF 2021.08.25 If the nav is different, we need to ensure that it doesn't exist, to avoid having the same nav in different tabs
    var needNewNav = window.name.length === 0 || (cwi !== undefined && window.name !== cwi && navExists(cwi));
    if (needNewNav) {
        $.ajax({
            type: "GET",
            url: nwurl,
            data: {cwname: cwi},
            success: function (data) {
                if (data.Success) {
                    window.name = data.newNav;
                    copyLocalStorage(data.oldNav, data.newNav);
                    if (!firstLoadOfSite) navIdToQueryStr(data.newNav);
                    else setNavigationId();
                    registerNav(window.name);
                } else {
                    if(data.View){
                        $('form').html(data.View);
                    }
                    else if (data.errorMessage) {                                             
                        $('form').html('<div class="validation-summary-errors i-text__error"><ul><li>' + data.errorMessage + '</li></ul></div>');                                                    
                    }
                }
            }
        });
    } else {
        if (cwi !== undefined && window.name !== cwi) {
            copyLocalStorage(window.name, cwi);
            window.name = cwi;
            var qstr = window.location.search;
            var oldQstr = qstr;
            qstr = qstr.replace("bc=True&", ""); qstr = qstr.replace("bc=True", "");
            qstr = qstr.replace("newMenu=True&", ""); qstr = qstr.replace("newMenu=True", "");
            qstr = setQueryStringNavigationId(qstr, window.name);
            if (window.location.search !== ("?" + qstr)) {
                var newUrl = window.location.href;
                if (oldQstr.length !== 0 && oldQstr !== "?") newUrl = newUrl.replace(oldQstr, "?"+qstr);
                else newUrl = newUrl + "?" + qstr;
                history.constructor.savedStates[0].url = newUrl;
                history.replaceState(history.constructor.savedStates[0], history.constructor.savedStates[0].title, newUrl);
                //window.location.search = qstr;
            }
            registerNav(window.name);
        }
    }
}

function parseQueryString(source, toFind) {
    //Get query string value
    var Result = "";
    if (source.indexOf(toFind) !== -1) {
        var searchString = source;
        if (source.indexOf("?") === 0) searchString = source.substring(1);
        $.each(searchString.split("&"), function (i, value) {
            var val = value.split("=");
            if (val[0] === toFind) {
                Result = val[1];
                return false;
            }
        });
    }
    return Result;
}

function getQSNav() {
    return parseQueryString(window.location.search, "nav");
}

/**
 * Check if nav exists in local storage
*/
function navExists(nav) {
    existing = localStorage.getItem("nav");
    return existing && existing.includes(nav);
}

/**
 * Registers the nav in local storage
 */
function registerNav(nav) {
    var existingNavs = localStorage.getItem("nav");
    if (!existingNavs)
        existingNavs = [];
    else
        existingNavs = existingNavs.split(",");
    existingNavs.push(nav);
    localStorage.setItem("nav", existingNavs.toString());
}

function navIdToQueryStr(nId) {
    //Set query string navigation Id
    var src = window.location.search;
    var oldSrc = src;

    if (src.indexOf("bc=True&") !== -1) src = src.replace("bc=True&", "");
    else if (src.indexOf("bc=True") !== -1) src = src.replace("bc=True", "");

    if (src.indexOf("nav") !== -1) {
        var nav = getQSNav();
        if(nav.length !== 0 && nav !== nId)
            src = src.replace("nav=" + nav, "nav=" + nId);
    }
    else {
        if (src.length === 0) { src = "nav=" + nId; }
        else { src = src + "&nav=" + nId; }
    }

    var newUrl = window.location.href;
    if (oldSrc.length !== 0 && oldSrc !== "?") newUrl = newUrl.replace(oldSrc, src);
    else newUrl = newUrl + "?" + src;
    history.constructor.savedStates[0].url = newUrl;
    history.replaceState(history.constructor.savedStates[0], history.constructor.savedStates[0].title, newUrl);
    window.location.search = src;
}

function copyLocalStorage(oldNav, newGuid) {
    //Clone local storage
    var LStorage = { 0: "savedInfo", 3: "selections", 4: "accordions", 5: "collapsible", 6: "lastActiveElement", 7: "ribbon_selectedTabIndex", 8: "sidebar_selectedMenu", 9: "LastTabSelected", 10: "sidebar_selectedItemMenu", 11: "reportingMode", 12: "rigthsidebaropen", 13: "rigthsidebarnavclosed"};
    if (oldNav && oldNav.length !== 0 && oldNav !== newGuid) {
        $.each(LStorage, function (_, value) {
            if (localStorage[value]) {
                var LocalStorageAll = JSON.parse(localStorage[value]);
                var oldLocalStorage = LocalStorageAll[oldNav];
                LocalStorageAll[newGuid] = oldLocalStorage;
                localStorage.setItem(value, JSON.stringify(LocalStorageAll));
            }
        });
        QLocalStorage.refreshLSTimestamp(newGuid);
    }
}

function setQueryStringNavigationId(src, wId, targetElement)
{
    if (src.length !== 0)
    {
        if (src.indexOf("nav=") !== -1)
        {
            let curValue = parseQueryString(src, "nav");
            if (wId !== curValue)
                src = src.replace("nav=" + curValue, "nav=" + wId);
        }
        else
            src = src + "&nav=" + wId;
    }
    else
        src = "nav=" + wId;

    if ($("#CurrentHistoryLevel").length !== 0)
    {
        let cHistoryLevel = getCurrentHistoryLevel(targetElement);
        if ($("div#form-modal") && $("div#form-modal").data("open") && $("div#form-modal").find("#CurrentHistoryLevel"))
            cHistoryLevel = $("div#form-modal").find("#CurrentHistoryLevel").val();

        if (typeof cHistoryLevel !== 'undefined')
        {
            if (src.indexOf("niv=") !== -1)
            {
                let curValue = parseQueryString(src, "niv");
                src = src.replace("niv=" + curValue, "niv=" + cHistoryLevel);
            }
            else
                src = src + "&niv=" + cHistoryLevel;
        }
    }

    if (src.indexOf("?") === 0)
        return src.substring(1);
    return src;
}

function setSubmitNavigationId(event) {
    //On Form submit
    if (event.currentTarget.action !== undefined) {
        var qsIdx = event.currentTarget.action.indexOf("?");
        if (qsIdx !== -1) {
            var src = setQueryStringNavigationId(event.currentTarget.action.substring(qsIdx), window.name, event.currentTarget);
            event.currentTarget.action = event.currentTarget.action.substring(0, qsIdx) + "?" + src;
        } else { event.currentTarget.action = event.currentTarget.action + "?" + setQueryStringNavigationId("", window.name, event.currentTarget); }
    }
}

function getCurrentHistoryLevel(targetElement) {
    if ($("#CurrentHistoryLevel").length !== 0) {
        var cHistiryLevel = $('input[id="CurrentHistoryLevel"]').last().val();
        // Extended support forms have another CurrentHistoryLevel
        if (!$.isEmptyObject(targetElement)) {
            var _targetElementForm = $(targetElement).is("[data-form]") ? $(targetElement) : $(targetElement).closest("[data-form]"),
                _currentHistoryLevel = $('input[id="CurrentHistoryLevel"]', _targetElementForm);
            if (_currentHistoryLevel.length !== 0) {
                cHistiryLevel = _currentHistoryLevel.val();
            }
        }
        // Multiforms have another CurrentHistoryLevel
        else if ($("div#form-modal") && $("div#form-modal").data("open") && $("div#form-modal").find("#CurrentHistoryLevel"))
            cHistiryLevel = $("div#form-modal").find('input[id="CurrentHistoryLevel"]').val();
        return cHistiryLevel;
    }
    return;
}

function setAjaxSendNavigationId(event, jqxhr, settings) {
    /**
     * SE/SU type menus should be ignored.
     * These menus, in addition to creating a new history,
     *   in case when we have more than one SE/SU menu one after the other would cause problems on using the navigation id of the opened page before.
     */
    if(!$.isEmptyObject(settings.currentTarget) && settings.currentTarget.data('ignore-ajax-nav-id') === true) 
        return;

    //On ajax send
    if (settings.url !== undefined) {
        var qsIdx = settings.url.indexOf("?");
        if (qsIdx !== -1) {
            var src = setQueryStringNavigationId(settings.url.substring(qsIdx), window.name);
            settings.url = settings.url.substring(0, qsIdx) + "?" + src;
        } else { settings.url = settings.url + "?" + setQueryStringNavigationId("", window.name, settings.currentTarget); }
    }
    // TODO: Use only request header
    jqxhr.setRequestHeader('Quidgest-Nav', window.name);
    var cHistoryLevel = getCurrentHistoryLevel(settings.currentTarget);
    if (cHistoryLevel) {
        jqxhr.setRequestHeader('Quidgest-Niv', cHistoryLevel);
    }
}

function __updateQSNav(originalLink, targetElement) {
    var dLinkQS = originalLink;
    var dLinkQSIdx = dLinkQS.indexOf("?");
    if (dLinkQSIdx !== -1) {
        dLinkQS = dLinkQS.substring(dLinkQSIdx);
        originalLink = originalLink.replace(dLinkQS, "?" + setQueryStringNavigationId(dLinkQS, window.name, targetElement));
    } else { originalLink = originalLink + "?" + setQueryStringNavigationId("", window.name, targetElement); }
    return originalLink;
}

function setNewContentNavigationId(target) {
    //On node inserted (new context)
    if (window.name.length === 0) return;

    var _fnFilter = function () {
        return $(this).closest(Q_NavigationIngnoreContainer).length === 0;
    };

    var fnProc_bt_li = function (index, aTarget) {
        var _href = $(aTarget).attr('href');
        // Link can already come with a new attribute "m", so we cannot validate if there is no "?". As it shouldn't even be necessary.
        if (_href !== undefined && _href !== '#' && /*_href.indexOf("?") === -1 &&*/ _href.indexOf("javascript") === -1
            && $(aTarget).closest(Q_NavigationIngnoreContainer).length === 0) {
            $(aTarget).attr('href', __updateQSNav(_href, aTarget));
        }
    };

    var _selector = 'button[href], li[href]';
    if ($(target).is(_selector) && $(target).closest(Q_NavigationIngnoreContainer).length === 0) {
        fnProc_bt_li(0, $(target));
    }
    $.each($(_selector, target).filter(_fnFilter), fnProc_bt_li);

    var fnProc_a = function (index, aTarget) {
        if ($(aTarget).attr('href') !== '#' && aTarget.search !== undefined && aTarget.href.indexOf("javascript") === -1
            && $(aTarget).closest(Q_NavigationIngnoreContainer).length === 0) {
            aTarget.search = setQueryStringNavigationId(aTarget.search, window.name);
        }
    };

    _selector = 'a';
    if ($(target).is(_selector) && $(target).closest(Q_NavigationIngnoreContainer).length === 0) {
        fnProc_bt_li(0, $(target));
    }
    $.each($(_selector, target).filter(_fnFilter), fnProc_a);
}

function setNavigationId() {
    var _fnFilter = function () {
        return $(this).closest(Q_NavigationIngnoreContainer).length === 0;
    };

    //Append window Id to all 'a' and 'button' tags
    var _anchorsSelector = 'a[href^="/"], a[href^="http://"], a[href^="https://"], button[href^="/"], button[href^="http://"], button[href^="https://"], li[href^="/"], li[href^="http://"], li[href^="https://"]';
    var anchors = $(_anchorsSelector, $(document)).filter(_fnFilter);
    $.each(anchors, function (index, element) {
        if (element.tagName === "BUTTON" || element.tagName === "LI") {
            $(element).attr('href', __updateQSNav($(element).attr('href'), element));
        }
        else {
            element.search = setQueryStringNavigationId(element.search, window.name, element);
        }
    });
    //Append window Id to buttons data links (rare)
    _anchorsSelector = 'a[href^="javascript"][data-link^="/"], a[href^="javascript"][data-link^="http://"], a[href^="javascript"][data-link^="https://"], button[href^="javascript"][data-link^="/"], button[href^="javascript"][data-link^="http://"], button[href^="javascript"][data-link^="https://"]';
    anchors = $(_anchorsSelector, $(document)).filter(_fnFilter);
    $.each(anchors, function (index, element) {
        var originalDLink = element.getAttribute("data-link");
        originalDLink = __updateQSNav(originalDLink, element);
        element.setAttribute("data-link", originalDLink);
    });
    //Append window Id to ReportRequest (rare)
    _anchorsSelector = 'a[href^="javascript"][onclick^="javascript"]';
    anchors = $(_anchorsSelector, $(document)).filter(_fnFilter);
    $.each(anchors, function (index, element) {
        var originalLink = element.attributes["onclick"].value;
        var dLink = originalLink;
        //procurar link entre parenteses. ex:[onclick=javascript:func('LINK')]
        var linkStart = dLink.indexOf("('");
        var linkEnd = dLink.indexOf("')");
        if (linkStart !== -1 && linkEnd !== -1) {
            dLink = dLink.substring(linkStart + 2, linkEnd);//2 = "('"
            var dLinkQS = dLink.indexOf("?");
            if (dLinkQS !== -1) {
                dLink = dLink.substring(dLinkQS);
                element.attributes["onclick"].value = originalLink.replace(dLink, "?" + setQueryStringNavigationId(dLink, window.name, element));
            }
            else element.attributes["onclick"].value = originalLink.replace(dLink, dLink + "?" + setQueryStringNavigationId("", window.name, element));
        }
    });
}