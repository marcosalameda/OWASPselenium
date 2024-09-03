

/**
 * @param {string} module The Application module
 * @returns {int} The current application level
 * @deprecated Deprecated, use HasRole() instead
 */
User.GetNivel = function (module) {
	return User.Levels[module].LevelValue;
};

//*   API para uso em Formulas ou Scripts
var qApi = new qapi();

qapi.prototype.Sigla=function() {
	this.LogCmd("Sigla");
	return quidgestGlobals.Sigla;
};


qapi.prototype.GetModulo=function() {
	this.LogCmd("GetModulo");
	return quidgestGlobals.Mod;
};


qapi.prototype.GUIDCreate=function() {
	this.LogCmd("GUIDCreate");

	// https://stackoverflow.com/a/2117523
	return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
		(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
	);
};


qapi.prototype.GetServerFormula = function (url, qForm) {
	this.LogCmd("GetServerFormula", arguments);

	if (qForm === undefined || qForm == null) {
		QError.AppendError("Error on GetServerFormula: Invalid arguments", qForm);
		return "";
	}

	var params = getInputsForNestedForm(qForm);

	return $.ajax({
		type: 'POST',
		url: url,
		data: $.param(params),
		cache: false
	}).then(function (response) {
		if (response.Success === true) {
			return response.Result;
		}
		else {
			QError.AppendError("Error on GetServerFormula", response.Message, url);
			return null;
		}
	}, function (jqXHR, textStatus, errorThrown) {
		QError.AppendError("Request failed on GetServerFormula: " + textStatus, errorThrown, url);
		return null;
	});
}

qapi.prototype.GetHist=function(area, nome, op) {
	this.LogCmd("GetHist", arguments);
	//TODO: return ;
	return "";
}

qapi.prototype.GetEph = function (area, ephID) {
	this.LogCmd("GetEph", arguments);

	var params = { ephID: ephID };
	if (ephID === undefined) {
		QError.AppendError("Error on GetEph: Invalid arguments", params);
		return "";
	}

	return $.ajax({
		type: 'GET',
		url: quidgestGlobals.UrlAction.GetEph,
		data: $.param(params),
		cache: false
	}).then(function (response) {
		if (response.Success) {
			return response.Value;
		}
		else {
			QError.AppendError("Error on GetEph: " + response.Message, response.Value, quidgestGlobals.UrlAction.GetEph);
			return "";
		}
	}, function () {
		return "";
	});
}

qapi.prototype.HasRole = function (roleId) {
	this.LogCmd("HasRole", arguments);

	var params = { roleId: roleId };
	if (roleId === undefined) {
		QError.AppendError("Error on HasRole: Invalid arguments", params);
		return "";
	}

	return $.ajax({
		type: 'GET',
		url: quidgestGlobals.UrlAction.HasRole,
		data: $.param(params),
		cache: false
	}).then(function (response) {
		if (response.Success) {
			return response.Value;
		}
		else {
			QError.AppendError("Error on HasRole: " + response.Message, response.Value, quidgestGlobals.UrlAction.HasRole);
			return "";
		}
	}, function () {
		return "";
	});
}

///For security reasons IsFeatureActive goes to the database to get the value
qapi.prototype.IsFeatureActive = function (feature) {
	this.LogCmd("IsFeatureActive", arguments);

	var params = { feature: feature };
	if (feature === undefined) {
		QError.AppendError("Error on IsFeatureActive: Invalid arguments", params);
		return "";
	}

	return $.ajax({
		type: 'GET',
		url: quidgestGlobals.UrlAction.IsFeatureActive,
		data: $.param(params),
		cache: false
	}).then(function (response) {
		if (response.Success) {
			return response.Value;
		}
		else {
			QError.AppendError("Error on IsFeatureActive: " + response.Message, response.Value, quidgestGlobals.UrlAction.IsFeatureActive);
			return "";
		}
	}, function () {
		return "";
	});
}

qapi.prototype.GetLevelFromRole = function (level, roleId) {
	this.LogCmd("GetLevelFromRole", arguments);

	const params = { level: level, roleId: roleId };
	if (roleId === undefined) {
		QError.AppendError("Error on GetLevelFromRole: Invalid arguments", params);
		return "";
	}

	return $.ajax({
		type: 'GET',
		url: quidgestGlobals.UrlAction.GetLevelFromRole,
		data: $.param(params),
		cache: false
	}).then(function (response) {
		if (response.Success) {
			return response.Value;
		}
		else {
			QError.AppendError("Error on GetLevelFromRole: " + response.Message, response.Value, quidgestGlobals.UrlAction.GetLevelFromRole);
			return "";
		}
	}, function () {
		return "";
	});
}

qapi.prototype.Today = function () {
	this.LogCmd("Today");
	var now = new Date();
	return moment([now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0, 0]).toDate();
}

qapi.prototype.Now = function () {
	this.LogCmd("Now");
	return moment().toDate();
}

// MH - The funtions Hoje, Agora and CriaData need to be overridden to use the momentJS plugin
qapi.prototype.Hoje = function () {
	this.LogCmd("Hoje (deprecated)");
	return this.Today();
}

qapi.prototype.Agora = function () {
	this.LogCmd("Agora (deprecated)");
	return this.Now();
}

// since DateSetTime calls CreateDateTime, we do not need to override the DateSetTime method
qapi.prototype.CreateDateTime = function (year, month, day, hour, minute, second) {
	this.LogCmd("CreateDateTime", arguments);
	this.ValidateDateTime(year, month, day, hour, minute, second);

	return moment([year, month - 1, day, hour, minute, second]).toDate();
}

qapi.prototype.CriaData = function (ano, mes, dia, hora, minuto, segundo) {
	this.LogCmd("CriaData (deprecated)", arguments);

	return this.CreateDateTime(ano, mes, dia, hora, minuto, segundo);
}

// Specifying the format of the dates sent by AJAX requests.
if (!Date.prototype.toQString) {
	(function () {
		function pad(number) {
			if (number < 10) {
				return '0' + number;
			}
			return number;
		}
		// Alternative method of toISOString.
		// Returns a string in simplified extended ISO-8601 format but without specified time zone.
		// YYYY-MM-DDTHH:mm:ss.sss
		Date.prototype.toQString = function () {
			return this.getFullYear() +
				'-' + pad(this.getMonth() + 1) +
				'-' + pad(this.getDate()) +
				'T' + pad(this.getHours()) +
				':' + pad(this.getMinutes()) +
				':' + pad(this.getSeconds()) +
				'.' + (this.getMilliseconds() / 1000).toFixed(3).slice(2, 5);
		};
	}());
}

// Bloquear dupla submissão
function BlockDoubleSubmission() {
	// select all buttons that save or cancel or delete a record - they all have data-end-pers attribute
		//MH (19/08/2015) - [bugfix] Depois de bloquear os botões pode acontecer que algum campo foi mal preenchido
		var validation = $('form').data("unobtrusiveValidation");
		var isValid = true;
		if (validation)
			isValid = $('form').data("unobtrusiveValidation").validate();

		if (isValid) {
			$('[data-end-pers], [elem-identifier="FormActions"] > *').click(function (e) {
				e.preventDefault();
				e.stopPropagation();
				DisableTableButtons();
			}).addClass("disabled");
		}
}

function DisableTableButtons() {
	$("table a, table button").click(function (e) {
		e.preventDefault();
	}).addClass("disabled");
}

function HideTableEmptyFooter() {
	if ($('.c-table__footer-out').find('.b-icon, .b-icon-text, .e-counter, .e-pagination__link, .selected-records-counter').length == 0) {
		$('.c-table__footer-out').addClass('hidden');
	}
}

/**
 *
 * Run the search when pressed Enter in the search textbox
 */
function ListSearchEnter(event) {
	if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) {
		var searchButton = $('[elem-identifier="ListSearchButton"]', $(event.target).parent());
		if (searchButton) {event.stopPropagation(); event.preventDefault();  $(searchButton).click(); }
	}
}


// Função para executar o Bloqueia Quando de um campo
function BlockWhen(fieldSelector, conditionResult) {
	if (conditionResult === 0) conditionResult = false;
	else if (conditionResult === 1) conditionResult = true;
	if ($(fieldSelector).data("QObject") !== undefined) {
		$(fieldSelector).data("QObject").Block("BlockWhen", conditionResult);
	}
	else {
		$(fieldSelector).prop('readonly', conditionResult).attr('readonly', conditionResult);
	}
}

// Função para executar o Mostra Quando de um campo
function ShowWhen(fieldSelector, conditionResult, isTab, fieldIdentifier) {
	if (isTab) {
		var ulNavTabs = $(fieldSelector).parent();
		var tempTab = $(fieldSelector);
		var isTabVisible = $(fieldSelector).is(':visible');
		var isTabActive = $('a', $(tempTab)).hasClass('active');

		var tabDivContent = $('div#' + $(fieldSelector).attr('data-tab'));

		var indexOfTab = -1;
		var totalVisibleTabs = ulNavTabs.find('li:visible').length;

		if (isTabVisible && isTabActive && !conditionResult)
		{
			indexOfTab = jQuery.inArray($(fieldSelector)[0], ulNavTabs.find('li:visible'));
			indexOfTab = (indexOfTab > 0 || totalVisibleTabs == 1 ? indexOfTab - 1 : indexOfTab);
			$('a',$(fieldSelector)).removeClass('active');
			tabDivContent.removeClass('active');
		}
		$(fieldSelector).css('display', (conditionResult ? '' : 'none'));

		if (totalVisibleTabs == 0 && conditionResult)
			indexOfTab = 0;

		if (indexOfTab != -1)
		{
			var tabToActivate = $(ulNavTabs.find('li:visible')[indexOfTab]);
			$('a', $(tabToActivate)).tab('show')
		}
	}
	else {
		var _qControlByIdentifier = $('[data-identifier="' + fieldIdentifier || '' + '"]');
		if ($(fieldSelector).data("QObject") !== undefined) {
			$(fieldSelector).data("QObject").Hide(!conditionResult);
		}
		else if ($(_qControlByIdentifier).length === 1 && $(_qControlByIdentifier).data("QObject") !== undefined) {
			$(_qControlByIdentifier).data("QObject").Hide(!conditionResult);
		}
		else {
			console.warn("Run the ShowWhen of a field without QControl");
			if (fieldIdentifier === undefined || fieldIdentifier === "")
				fieldIdentifier = $(fieldSelector).data('identifier');

			var hideID = "#CONTAINER_" + (fieldIdentifier || "");

			if ($(fieldSelector).closest(hideID).length != 0)
			{
				let elem = $(fieldSelector).closest(hideID);
				elem.css('display', (!conditionResult ? 'none' : ''));
				qToggleVisibility(elem.parent(), !conditionResult);
			}
			else
			{
				let elem = $(fieldSelector);
				elem.css('display', (!conditionResult ? 'none' : ''));
				qToggleVisibility(elem.parent(), !conditionResult);
			}

			if ($(fieldSelector).is("select"))
				$(fieldSelector).trigger("liszt:updated");
		}
	}
}

// Função para executar o Preenche Quando de um campo
function FillWhen(fieldSelector, conditionResult, changeTrigger) {
	var originalValue = getFieldValue($(fieldSelector));
	if ($(fieldSelector).data("QObject") !== undefined) {
		$(fieldSelector).data("QObject").Block("FillWhen", !conditionResult);
	}
	else {
		$(fieldSelector).prop('readonly', !conditionResult).attr('readonly', !conditionResult);
	}

	if (!conditionResult) {
		setFieldValue($(fieldSelector), "");
	}
	if (originalValue != getFieldValue($(fieldSelector))) {
		$(fieldSelector).change();
		if(changeTrigger) $(fieldSelector).trigger(changeTrigger)
	}
}

// Função para download documento no controlo de documentos
function Download(url, newTab = false) {
	window.qVar_isControlledRedirect = true;
	
	if (newTab)
		window.open(window.location.origin + url, "_blank")
	else
		window.location = window.location.origin + url;
}
/********************** Funções globais para o MVC ***********************/

function RegExpEscape(text) {
	return text.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");
}

function wrapTextWithWhitespaces(message) {
	var div = document.createElement("div");
	var t = document.createTextNode(message);
	div.appendChild(t);
	div.style.whiteSpace = "pre-wrap";
	return div;
}


function getAsyncJavaScript(fileScript, callback) {
	$.getScript(fileScript,
		function () {
			callback();
		}
	)
}

function SetPropertyBag(property, value) {
	//check if the input field exists
	var input = $('form input [name="arg[' + property + ']"]');
	if (input.length > 0) { //modify the value
		input.attr('value', value);
	}
	else { //create the element
		input = $('<input name="arg[' + property + ']" type="hidden" value="' + value + '"/>');
		$('form').append(input);
	}
}

function CapFirst(str){
		  str=str.toLowerCase();
		  return str.replace(/(\b)([a-zA-Z])/,
				   function(firstLetter){
					  return   firstLetter.toUpperCase();
				   });
}

/**
 * A recursive function that hides or shows the parents of "element", depending on the "wasHidden" parameter.
 * This function is used as a temporary fix in ShowWhen() and Hide() functions of controls, to hide their parents in the form.
 * @param {object} element A jquery object representing the element we want to hide.
 * @param {boolean} wasHidden True if the element is to be hidden, false otherwise.
 * @param {boolean} childIsHidden True if this element's immediate child is hidden, false otherwise.
 */
function qToggleVisibility(element, wasHidden, childIsHidden)
{
	// This function checks if there are any styles in the current element ("el") that may hide it.
	// The function can return true even if the element isn't visible (when one of it's parents is hidden).
	function isVisible(el)
	{
		if (el === undefined)
			return false;
		var hasHiddenClass = el.hasClass('accordion-group-hidden') || el.hasClass('collapse');
		var hasHiddenStyle = el.css('display') == 'none';
		return !hasHiddenClass && !hasHiddenStyle;
	}

	if (element === null || element === undefined || typeof element.parent != 'function')
		throw new Error('Unexpected type of parameter: element');
	if (element.attr('qform') !== undefined || element.prop('tagName') == 'BODY')
		return;

	var hidden = true;
	$(element).children().each(function()
	{
		if (isVisible($(this)))
		{
			hidden = false;
			return false;
		}
	});

	var currentIsVisible = isVisible(element);
	$(element).css('display', (hidden && wasHidden ? 'none' : ''));

	// No need to keep escalating if the visibility of the elements is no longer changing.
	if (childIsHidden !== undefined && childIsHidden != currentIsVisible)
		return;
	qToggleVisibility(element.parent(), wasHidden, !isVisible(element));
}

/*******************
*  Clicks history  *
********************/

function showTable(link, divId) {
	$(divId).load(link);
	return true;
}

function addClicker(link) {
	link.addEventListener("click", function (e) {
		if (showTable(link.href, link.getAttribute('data-divid'))) {
			History.pushState(null, null, link.href);
			e.preventDefault();
		}
	}, true);
}

function setupHistoryClicks() {
	var areas = $('a[data-divid]');
	for (var x = 0; x < areas.length; x++) {
		addClicker(areas[x]);
	}
}

function showWarningMsg(msg) {
	if ($("#topPageWarning").length < 1) {
		if ($('#wrap').length > 0) {
			if ($('.loginPage').length > 0) {
				$('body').prepend('<div id="topPageWarning"></div>');
			}
			else {
				$('#wrap').prepend('<div id="topPageWarning"></div>');
			}
		}
		else if ($('#wrapper').length > 0) {
			$('#wrapper').prepend('<div id="topPageWarning"></div>');
		}
	}

	var html = '<div class="alert c-alert c-alert--info" role="alert" style="margin-bottom:0;border-radius: 0;">';
	html += '<i class="glyphicons glyphicons-info-sign c-alert__icon mr-2"></i>';
	html += '<div class="c-alert__text">' + msg + '</div>';
	html += '</div>';

	$("#topPageWarning").append(html);
	return;
};

function checkBrowserVersion() {
	var supportedBrowsers = {
		msie: "9",
		chrome: "54",
		safari: "9",
		firefox: "50",
		android: "30",
		ios: "9",
	};

	if (bowser.isUnsupportedBrowser(supportedBrowsers, false, window.navigator.userAgent)) {
		showWarningMsg(quidgestGlobals.Resources.A_SUA_VERSAO_DE_BROWSER);
		return;
	}
	if (bowser.isUnsupportedBrowser(supportedBrowsers, true, window.navigator.userAgent)) {
		showWarningMsg(quidgestGlobals.Resources.O_SEU_BROWSER_NAO_E_18363);
	}

	return;
};

function checkMaintenance() {
	if (quidgestGlobals.Maintenance.IsMaintenanceSchedule) {
		showWarningMsg(quidgestGlobals.Resources.O_SISTEMA_EM_IRA_ENT45921.replace("{0}",quidgestGlobals.Maintenance.MaintenanceSchedule));
	}
	if (quidgestGlobals.Maintenance.IsMaintenance) {
		showWarningMsg(quidgestGlobals.Resources.SISTEMA_EM_MANUTENCA49570);
	}

	return;
}

function qAddLoading(timer) {
	QAnimation.addLoading(timer);
}

function qRemoveLoading() {
	QAnimation.removeLoading();
}

var QKeepAlive = QKeepAlive || (function () {
	return {
		get keepAliveTimeout() {
			var _keepAliveTimeout = (quidgestGlobals.KeepAliveConfig.Timeout * 60000) - 60000;
			if(_keepAliveTimeout < 30000) _keepAliveTimeout = 30000; // 30s is minimal timeout
			return _keepAliveTimeout;
		},
		retryCount: 0,
		keepAliveTimer: null,
		Start: function () {
			QKeepAlive.keepAliveTimer = setTimeout(function () {
				QKeepAlive.retryCount = 0;//3;
				QKeepAlive._sendRequest();
				QKeepAlive.Start();
			}, QKeepAlive.keepAliveTimeout);
		},
		Stop: function () {
			if (QKeepAlive.keepAliveTimer) { clearTimeout(QKeepAlive.keepAliveTimer); }
		},
		Restart: function () { QKeepAlive.Stop(); QKeepAlive.Start(); },
		_sendRequest: function () {
			$.ajax({
				url: quidgestGlobals.KeepAliveConfig.Url,
				cache: false
			}).fail(function () { if (QKeepAlive.retryCount > 0) { QKeepAlive.retryCount--; QKeepAlive._sendRequest(); } });
		}
	};
})();

$.ajaxSetup({ headers: { '__RequestVerificationToken': $('[name="__RequestVerificationToken"]').first().val() } });
window.onload = function () {
	checkBrowserVersion();
	checkMaintenance();
	newWindow(quidgestGlobals.UrlAction.newWindow);
	setupHistoryClicks();
	TurnSuggestionsOff();
	window.setTimeout(function () {
		var eventName = "popstate";
		eventHandler = function (e) {
			if(window.location.pathname != location.pathname)
				window.location.pathname = location.pathname;
		};

		if (window.addEventListener) {
			window.addEventListener(eventName, eventHandler, false);
		} else if (window.attachEvent) {
			window.attachEvent('on' + eventName, eventHandler);
		}
	}, 1);

	//Navigation Id to QueryString
	setNavigationId();

	new MutationObserver((mutationList) => {
		for (const mutation of mutationList) {
			//go through everything that was added in this execution cycle
			for (const addedNode of mutation.addedNodes) {
                if (addedNode.nodeType === Node.ELEMENT_NODE) {
                    setNewContentNavigationId(addedNode);
                    //MH (12/08/2016) [bugfix] - replace dos atributos incorretos
                    replaceIncorrectAttributes(addedNode);
                }
			}
		}
	}).observe(document, { attributes: false, childList: true, subtree: true });

	$(document).ajaxSend(setAjaxSendNavigationId);
	//$("a, button", document).click(setClickNavigationId);

	$("form", document).submit(function (event) {
		setSubmitNavigationId(event);
		if ($("div.field-validation-error").length >= 0) {
			// on form submission (due to a problem with with the submit button, not passing the action name when the button is disabled)
			BlockDoubleSubmission();
		}
	});
	

	// MH - Prevent self-submission of forms by clicking Enter key
	document.onkeypress = stopEnterKeyAutoSubmit;

	// Loading animation
	/*$(document).on({
		ajaxStart: qAddLoading,
		ajaxStop: qRemoveLoading
	});*/

	QKeepAlive.Start();
	if ($.notify) {
		var curModulo = qApi.GetModulo();
		var curLocalStorageModulo = localStorage['alerts-container_modulo'] || '';

		if ($.isEmptyObject(localStorage['alerts-container']) || curModulo != curLocalStorageModulo || localStorage['alerts-year'] != User.Ano || qapi.prototype.GetModulo() === 'Public') {
			localStorage.removeItem('alerts-container');
			Load_Alerts(true);
			//$('#alerts-container').hide();
		}
		else
			Load_Alerts();
		localStorage['alerts-year'] = User.Ano;
	}
	else {
		$('#sidebarCollapse').remove();
		localStorage.removeItem('alerts-container');
		localStorage.removeItem('alerts-container_modulo');
	}

	//TableResizeColumn();
}

function stopEnterKeyAutoSubmit(evt) {
	// MH - Prevent self-submission of forms by clicking Enter key
	var evt = (evt) ? evt : ((event) ? event : null);
	var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);

	if (evt.keyCode == 13) {
		if (node.type === "text" && $(node).closest('.search').length == 0)
			return false;
		else if (node.type === "radio" || node.type === "checkbox")
			return false;
	}
}

//function TableResizeColumn() {
//    window.tableResizeVar = {
//        startX: 0,
//        startWidth: 0,
//        $handle: null,
//        $table: null,
//        pressed: false
//    }

//    $(document).on({
//        mousemove: function (event) {
//            if (window.tableResizeVar.pressed) {
//                window.tableResizeVar.$handle.width(window.tableResizeVar.startWidth + (event.pageX - window.tableResizeVar.startX));
//            }
//        },
//        mouseup: function () {
//            if (window.tableResizeVar.pressed) {
//                window.tableResizeVar.$table.removeClass('resizing');
//                window.tableResizeVar.pressed = false;

//                $('td[headers*="' + window.tableResizeVar.$handle.attr('id') + '"]', $(window.tableResizeVar.$table)).each(function () {
//                    if (this.scrollWidth > this.offsetWidth)
//                        $(this).attr("title", $(this).html());
//                });
//            }
//        }
//    });
//}

window.onbeforeunload = function (e) {
	// Reset TableList export validation override
	QLocalStorage.setLocalStorage("ExportValidationOverride", "false");

	var activeElem = $(document.activeElement);
	var isActionButton = $(activeElem).parent().is($('[elem-identifier="FormActions"]'));
	var isFormControl = $(activeElem).is('a') && $(activeElem).closest('fieldset').length == 1;
	if (isActionButton || isFormControl || window.qVar_isControlledRedirect) { return; }

	var formElements = $(document.activeElement).closest('[data-form]');
	if (formElements.length === 0) {
		formElements = $('form');
	}

	if (formElements.length === 1) {
		var formName = $(formElements).data('form');
		// Save last active element
		var curLocalStorage = QLocalStorage.getLocalStorage('lastActiveElement');
		curLocalStorage[formName] = $(document.activeElement).getPath(true);
		QLocalStorage.setLocalStorage('lastActiveElement', curLocalStorage);
	}

	var forms = $.map(formElements, function (formElement) {
		// Check Form Hist Lock
		var _FormLock = $(formElement, '#NavigationFormHistLock');
		var formHistLock = (_FormLock.val() === 'True' || _FormLock.val() === true);

		var formMode = "";
		if ($(formElement).data('QForm') !== undefined) {
			var qForm = $(formElement).getQForm();
			formMode = qForm.FormMode || "";
		}

		return {
			FormHistLock: formHistLock,
			FormMode: formMode
		};
	});

	var formsHistLock = $.map(forms, function (form) { return form.FormHistLock; });
	var formsMode = $.map(forms, function (form) { return form.FormMode; });

	if ($.inArray(true, formsHistLock) >= 0
		|| (!window.qVar_isControlledRedirect && ($.inArray("new", formsMode) >= 0 || $.inArray("edit", formsMode) >= 0 ))) {
		// If we haven't been passed the event get the window.event
		e = e || window.event;
		var message = quidgestGlobals.Resources.FORMLOCK;
		// For IE6-8 and Firefox prior to version 4
		if (e) { e.returnValue = message; }
		// For Chrome, Safari, IE8+ and Opera 12+
		return message;
	}
};

$(document).ready(function () {
	var curLocalStorage = QLocalStorage.getLocalStorage('lastActiveElement');
	$.each($('form'), function(i, form) {
		var formName = $(form).data('form');
		if($(curLocalStorage[formName]).length !== 0) {
			var top = 0;
			var alertsError = $('.container.content > .alert-E, modal-header > .alert-E');
			if (alertsError.length == 0) {
				top = $(curLocalStorage[formName]).offset().top;
			}
			else {
				top = alertsError.first().offset().top;
			}

			var cardsPage = false;
			if ($('.c-card--gridView').length)
				cardsPage = true;

			if (!$('html, body').data('already-animated-scroll') && !cardsPage) {
				$('html, body').data('already-animated-scroll', true);
				$('html, body').animate({ scrollTop: (top > 100) ? (top - 100) : top }, 'slow');
			}
		}

		//Open last selected tab
		var curtab = $.GetLastTab(formName);
		if (!$.isEmptyObject(curtab)) {
			$('ul.c-tab > li:visible > a[data-target="' + curtab + '"]').click();
		}
	});

});

function replaceIncorrectAttributes(target) {
	/// <summary>
	/// Só a partir do MVC 5.1 que é suportado htmlAttributes no EditorFor
	/// MH (12/08/2016) - por agora só precisamos substituir o atributo data_identifier.
	/// O resto dos atributos ficam substituidos dentro do init do controlo
	/// </summary>
	$.each($(target).find("[data_identifier]"), function () {
		$(this).attr("data-identifier", $(this).attr("data_identifier"));
		$(this).removeAttr("data_identifier");
	});
}

/*****************************
*  Init and important stuff  *
******************************/
function makeAjaxRequest(link, target, targetFilters, isDEMenu = false) {
	var targetDiv;
	if (isDEMenu) {
		targetDiv = $(`#${target}, #${targetFilters}_filters, #${targetFilters}_simple_filter`).parent();
	} else {
		targetDiv = $(`#${target}`).parent();
	}

	var inputs = $("input:not(:button), select", targetDiv);
	postRequest(inputs, target, link);
	return false;
}


function updateTabs(link, target) {
	var inputs = $(":input:not(:button)");
	postRequest(inputs, target, link);
	return false;
}

function postRequest(inputs, target, link, formMethod) {
	var params = GetPostRquestParameters(inputs, target);
	var mode = formMethod ? formMethod : 'POST';

	// Syncronize foreign keys to apply correct Limits
	var _qForm = $("#" + target).closest('[data-form]');
	syncFormKeys(_qForm);

	// DBEdit see more limits
	var see_more_limits = $("#" + target).data('see-more-limits-values');
	if (!$.isEmptyObject(see_more_limits)) {
		params = $.extend(params, see_more_limits);
	}

	$.ajax({
		url: link,
		type: mode,
		data: params,
		success: function (data) {
			$('#' + target).html(data);
			InitSpecialControls($('#' + target));
			$.ModalForms($('#' + target)); // Attach events for open support form in the PopUp
			$.ClientSidePersistence($('#' + target)); // Attach events of client persistence
			$('#' + target).trigger(target + '_RELOADED');
		}
	});
}

function GetPostRquestParameters(inputs, target) {
	var params = { partialView: target };
	$.each(inputs, function (index, value) {
		var paramName = value.id !== "" ? value.id : value.name;
		// MH - Inputs without parameter name cause errors on TryUpdateModel on the server side.
		// The TryUpdateModel used for mapping the limits values to model, for example on See more.
		if($.isEmptyObject(paramName)) return;
		if ($(value).parent().data('DateTimePicker')) {
			var curValue = $(value).parent().data('DateTimePicker').date();
			if (!$.isEmptyObject(curValue) && moment.isMoment(curValue)) {
				curValue = new Date(curValue.format('YYYY'), curValue.format('M') - 1, curValue.format('D'), curValue.format('H'), curValue.format('m'), curValue.format('s'), curValue.format('SSS'));
			}
			if (!params[paramName]) {
				if (jQuery.type(curValue) === "date")
					curValue = curValue.toQString();
				params[paramName] = curValue;
			}
		}
		else if (value.type == "text" || value.type == "hidden") {
			if (!params[paramName])
				params[paramName] = value.value;
		}
		else if (value.type == "select-one" && value.selectedIndex != -1)
			params[paramName] = value[value.selectedIndex].value;
		else if ((value.type == "checkbox" || value.type == "radio") && value.checked && !$(this).data('wasChecked'))
			if (params[paramName])
				params[paramName] += value.value;
			else
				params[paramName] = value.value;
	});
	return params;
}

function setFieldAnchors(id, value) {
	var filterQS = document.getElementById(id);
	filterQS.value = value;
	$('a[href*="' + id + '"]').each(function () {
		$(this).attr('href', value);
	});
}


function changeFiltersAnchors(id) {
	var filterQS = document.getElementById(id);
	var oldValue = filterQS.value;
	filterQS.value = oldValue == "true" ? "false" : "true";
	$('a[href*="' + id + '"]').each(function () {
		$(this).attr('href', $(this).attr('href').replace(id + '=' + oldValue, id + '=' + filterQS.value));
	});
}


function hideShowDiv(target, otherDisplay) {
	var ele = document.getElementById(target);
	if (ele.style.display == "none") {
		if (otherDisplay)
			ele.style.display = otherDisplay;
		else
			ele.style.display = "block";
	}
	else
		ele.style.display = "none";
}

function jQuery_hideShowDiv(target, otherDisplay) {
	if ($(target).css('display') == "none") {
		if (otherDisplay)
			$(target).css('display', otherDisplay);
		else
			$(target).css('display', 'block');
	}
	else
		$(target).css('display', "none");
}

function changeFilters(complexFilters, hiddenValue) {
	changeFiltersAnchors(hiddenValue);
	jQuery_hideShowDiv(complexFilters, "table-row");
	//Change + sign to - in advanced search box, and vice versa
	var id = complexFilters.replace("complex_filter", "extra");
	toggleSearchIcon(id);
}

function toggleSearchIcon(id){
	$(id + " .glyphicons").toggleClass("glyphicons-zoom-in");
	$(id + " .glyphicons").toggleClass("glyphicons-zoom-out");
}

function initDatePickers(element) {
	$('[elem-identifier="DatePicker"], [elem-identifier="DatetimePicker"], [elem-identifier="DatetimesecPicker"], [elem-identifier="TimePicker"]',
		element).not('[readonly]').each(function () {
			var dateTimePickerFormat = $(this).data('datetimepicker-format'),
				dateElement = $(this).attr('elem-identifier');
			$(this).parent().datetimepicker({
				format: dateTimePickerFormat,
				locale: moment.locale(),
				timeZone: 'Etc/UTC',
				useCurrent: (dateElement === 'DatePicker') ? 'day' : true
			});
		});
}

function initMasks(target) {
	//Masks

	// jQuery Mask Plugin default values
	$.jMaskGlobals = {
		maskElements: 'input,td,span,div',
		dataMaskAttr: '*[data-mask]',
		dataMask: false,
		watchInterval: 300,
		watchInputs: false,
		watchDataMask: false,
		byPassKeys: [9, 16, 17, 18, 36, 37, 38, 39, 40, 91],
		translation: {
			'0': { pattern: /\d/ },
			'9': { pattern: /\d/, optional: true },
			'#': { pattern: /\d/, recursive: true },
			'A': { pattern: /[a-zA-Z0-9]/ },
			'S': { pattern: /[a-zA-Z]/ },
			'N': { pattern: /-/, optional: true }
		}
	};
}

function loaded(target, isMultiform) {
	//Trigger para mudança de valor dos campos do form
	var _target = target || $(document);
	// TODO: Verificar a necesidade do 'changeDate', o controlo de data faz trigger dos dois eventos.
	$(_target).on("change dp.change", null, $(_target), function (event) {
		var _target = $(event.data), eTarget = $(event.target);
		var isChangeDate = (event.type === "dp" && event.namespace === "change");
		var id = !isChangeDate ? event.target.id : eTarget.find('input').prop("id");
		var qForm = eTarget.closest('[data-form]');
		$(qForm).trigger(id.toUpperCase() + '_CHANGE', $(_target));
		//DBEdits corespondem a dois campos (chave e texto)
		if (eTarget.is("select") && eTarget.data("main-field")) {
			var mainField = eTarget.data("main-field").split(".");
			$(qForm).trigger(mainField[0].toUpperCase() + mainField[1].toUpperCase() + '_CHANGE', $(event.target));
		}

		var qControl = eTarget.getQControl();
		if (!qControl) { // e.g: date-time-picker
			qControl = eTarget.find('[data-identifier]').getQControl();
		}
		if (qControl && !$.isEmptyObject(qControl.area) && !$.isEmptyObject(qControl.field)) {
			var fieldFullName = qControl.area + '->' + qControl.field;
			// The next (one) line can be commented out if we don't want an internal update. e.g: two equal fields in different Tabs
			//$(qForm).trigger('q-form-field-change:' + fieldFullName, { fullFieldName: fieldFullName, value: qControl.Value, qControlId: qControl.controlIdentifier });
			$(qForm).trigger('q-form-field-change-sync', { fullFieldName: fieldFullName, value: qControl.Value, qControlId: qControl.controlIdentifier });
		}

	});
	if (!target && !isMultiform) { _target = $("body"); }

	$.SpecialMenus();
	Globalize.culture(quidgestGlobals.culture);
	initMasks(_target);

	AccordionIconToggle(_target);
	InitMagnificPopUp();
	sidebarPositioning();
}

/**
 * Toggle Reporting mode
 */
function ReportingModeToggle() {
	var opened = QLocalStorage.getLocalStorage('reportingMode');

	if (!$.isEmptyObject(opened) && opened == "true") {
		ReportingModeOFF();
	}
	else {
		ReportingModeON();
	}
}

/**
 *Turning Reporting mode ON
 */
function ReportingModeON() {
	$('#cavContainer').show();
	$(".draggable").draggable({ helper: "clone" });
	QLocalStorage.setLocalStorage('reportingMode', "true");
	location.reload();
}

/**
 *Turning Reporting mode OFF
 */
function ReportingModeOFF() {
	$('#cavContainer').hide();
	$('#formContainer').removeClass("reportmodeon");
	$('#advacedReportModeToggle').attr("title", quidgestGlobals.Resources.ENTRAR_EM_MODO_DE_RE61567);
	$(".draggable.ui-draggable").draggable('destroy');
	QLocalStorage.setLocalStorage('reportingMode', "false");
	$('#formContainer').show();
	$(".report-mode").addClass("d-none");
	window.dispatchEvent(new Event("cavtoggleoff"));
}


function AccordionIconToggle(elem) {
	$('[elem-identifier="AccordionGroup"]', $(elem)).off("show.bs.collapse").on("show.bs.collapse", function () {
			$('[elem-identifier="AccordionHeading"] i', this).removeClass('glyphicons glyphicons-plus-sign e-icon');
			$('[elem-identifier="AccordionHeading"] i', this).addClass('glyphicons glyphicons-minus-sign e-icon');
		}).off("hide.bs.collapse").on("hide.bs.collapse", function () {
			$('[elem-identifier="AccordionHeading"] i', this).removeClass('glyphicons glyphicons-minus-sign e-icon');
			$('[elem-identifier="AccordionHeading"] i', this).addClass('glyphicons glyphicons-plus-sign e-icon');
		});
}

function InitMagnificPopUp() {
	var imgCtrlMafnify = $('[elem-identifier="image-control-magnify"]');
	if (imgCtrlMafnify.length > 0) {
		InitMagnificPopUpEvents();
		$('[data-lazy="magnific-popup"]').not('[data-already-loaded]').data('already-loaded', true).Lazy({ onFinishedAll: InitMagnificPopUpEvents });
	}
}

function InitMagnificPopUpEvents() {
	if ($.magnificPopup !== undefined) {
		$('[elem-identifier="image-control-magnify"]')
			.not('[data="magnific-popup-ready"]')
			.data('magnific-popup-ready', true)
			.click(function (event) { event.preventDefault(); event.stopPropagation(); })
			.magnificPopup({
				type: 'image',
				closeOnContentClick: true,
				closeBtnInside: true,
				fixedContentPos: true,
				mainClass: 'mfp-no-margins mfp-with-zoom',
				image: {
					verticalFit: true
				},
				zoom: {
					enabled: true,
					duration: 300
				}
			});
	}
}

function InitSpecialControls(element) {
	//Temporary solution for loading menu form controls
	$.ModalForms($(element));
	$('[elem-identifier="ChosenDropdown"]:not([treated])', $(element)).chosen({ allow_single_deselect: true });
	$('input[type=radio]', $(element)).uncheckableRadio();
	initDatePickers($(element));

	var area = $(element).attr("area");
	if (area) {
		$('[elem-identifier="ShowAudit"]').on("click", function () {
			ShowAuditHistory({ 'logTable': area});
		});
	}
}


var ShowAuditHistory = function (params) {
	var link = quidgestGlobals.UrlAction.Audit;
	var modalElement = $("#modal-showAudit");

	if (modalElement.length < 1) {
		$('body').append('<div id="modal-showAudit" class="modal c-modal hide container" tabindex="-1" role="dialog" aria-labelledby="importList" aria-hidden="true">\
					<div elem-identifier="ModalBody" class="c-modal__body">\
					</div>\
					<div class="c-modal__footer">\
						<div class="actions">\
							<button type="button" class="btn btn-danger" data-end-pers="true" data-modal-close="true" onclick="CloseAuditHistory()">'+quidgestGlobals.Resources.FECHAR+'</button>\
						</div>\
					</div>\
				</div>');
		modalElement = $("#modal-showAudit");
	}

	// erase modal content
	modalElement.find('[elem-identifier="ModalBody"]').html("");
	// show modal
	modalElement.modal();
	// add loading class
	modalElement.addClass("loading");
	modalElement.data("open", true);
	modalElement.data("open-link", link);
	$.ajax({
		url: link,
		type: "GET",
		data: params,
		cache: false,
		success: function (data) {
			// remove loading class
			modalElement.removeClass("loading");
			modalElement.find('[elem-identifier="ModalBody"]').html(data);
			modalElement.modal("show");
		}
	});
}
var CloseAuditHistory = function (params) {
	var modalElement = $("#modal-showAudit");
	modalElement.find('[elem-identifier="ModalBody"]').html("");
	modalElement.modal("hide");

}

function QTabPreviousState() {
	var History = window.History;

	if (!History.enabled) {
		return false;
	}

	var State = History.getState();
	var hash = History.getHash();

	// Our default tab.
	if (!State.data || !State.data.tab) {
		if (hash) {
			State.data.tab = hash;
			window.location.hash = '';
		} else {
			State.data.tab = 'DEFAULT ACTIVE TAB';
		}
	}
	$('ul.nav-tabs > li:visible > a[href="#' + State.data.tab + '"]').click();
}

(function ($) {
	$.fn.uncheckableRadio = function () {
		return this.each(function () {
			$(this).mousedown(function () {
				if (!$(this).is('[readonly]')) {
					$(this).data('wasChecked', this.checked);
				}
			});
			$(this).click(function () {
				if (!$(this).is('[readonly]')) {
					if ($(this).data('wasChecked')) {
						this.checked = false;
						$(this).trigger('change');
					}
				}
			});
		});
	};
})(jQuery);

$(document).ready(function () { loaded(); });

/***********
*  Tables  *
************/
function _getDependentFieldsValue(selectList) {
	var params = {};
	if (selectList.attr("dependant")) {
		var depedantFields = selectList.attr("dependant").split(";");
		var depedantAreas = selectList.attr('dependant-area').split(";");

		for (var i in depedantFields) {
			var field = depedantFields[i];
			var area = depedantAreas[i];

			var element = $('[pers-cs-field="' + field + '"][pers-cs-area="' + area + '"]');
			if (element.length === 0) {
				element = $('[tfrelate="' + field.substring(3) + '"][trelate="' + area + '"]');
			}

			var paramName = area + field;
			if (element.length !== 0) {
				var fkname = GetDbName(element, field);
				paramName = area + fkname;
				params[paramName] = getFieldValue(element);
			} else {
				params[paramName] = null;
			}
		}
	}
	return params;
}

function RequestModalDBEdit(selectList) {
	var params = { id: selectList.data("form-key"), partialView: selectList.data("see-more") },
		values = { }, auxValues = { },
		dbeditControl = $(selectList).getQControl();

	$.each(dbeditControl.Limits, function (identifier, limit) {
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
	$.each(dbeditControl.ParentForm.getAllForeignKeySelectors(), function (area, selector) { values[area.toLowerCase()] = getFieldValue(selector); });
	// Retirar a opção selecionada atualmente
	values[dbeditControl.area] = null;

	var _getDFV = _getDependentFieldsValue(selectList);
	params['Limits'] = values;
	$.extend(params, auxValues);
	$.extend(params, _getDFV);

	if (dbeditControl) {
		var qpos = {}; qpos["Q_POS_RECORD_" + dbeditControl.area.toLowerCase()] = dbeditControl.Value;
		$.extend(params, qpos);
		$('html, body').data('already-animated-scroll', false);
	}

	var modalDiv = $("body #modal-dbedit", document);
	if(modalDiv.length > 0)
		modalDiv.remove();

	var modalBodyId = selectList.data('see-more');
	modalDiv = $('<div id="modal-dbedit" class="modal c-modal hide container-fluid" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"></div>');

	var modalDialog = $('<div class="c-modal__dialog c-modal--lg"></div>');
	var modalBody = $('<div class="c-modal__content"><div elem-identifier="ModalBody" class="c-modal__body" id="' + modalBodyId + '"></div></div>');
	modalBody.data('control-identifier', dbeditControl.controlIdentifier)

	modalDialog.append(modalBody);
	modalDiv.append(modalDialog);

	$("body", document).append(modalDiv);
	modalDiv.modal('show');

	var link = selectList.data("see-more-url");
	$.ajax({
		type: 'POST',
		data: $.param(params),
		url: link,
		traditional: true,
		success: function (data) {
			$("#" + modalBodyId, modalDiv).data('see-more-limits-values', $.extend({ Limits: params['Limits'] }, auxValues, _getDFV));
			$("#" + modalBodyId, modalDiv).html(data)
			.ready(function () {
				InitSpecialControls($("#" + modalBodyId, modalDiv));
			});
			modalDiv.modal({
				keyboard: true,
				show: true
			});
			$.ModalForms($("#" + modalBodyId, modalDiv)); // Attach events for open support form in the PopUp

			$('#modal-dbedit.modal').on('hidden.bs.modal', function (e) {
				if ($('.modal').hasClass('show')) {
					$('body').addClass('modal-open');
				}
			});
		},
		error: function () {
			modalDiv.modal('hide');
			displayMessage(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091, MessageDefs.StatusEnum.E);
		}
	});
}

function RequestModalDBEdit2(selectList) {
	// NÃO É PARA UTILIZAR !!!
	// Está em desenvolvimento
	var params = { id: selectList.data("form-key") }
	if (selectList.attr("dependant")) {
		var depedantFields = selectList.attr("dependant").split(";");
		var depedantAreas = selectList.attr('dependant-area').split(";");

		for (var i in depedantFields) {
			var field = depedantFields[i];
			var area = depedantAreas[i];

			var element = $('[pers-cs-field="' + field + '"][pers-cs-area="' + area + '"]');
			if (element.length === 0) {
				element = $('[tfrelate="' + field.substring(3) + '"][trelate="' + area + '"]');
			}

			var paramName = area + field;
			if (element.length !== 0) {
				var fkname = GetDbName(element, field);
				paramName = area + fkname;
				params[paramName] = getFieldValue(element);
			} else {
				params[paramName] = null;
			}
		}
	}
	var modalDiv = $("body #modal-dbedit", document);
	if (modalDiv.length > 0)
		modalDiv.remove();
	modalDiv = $('<div id="modal-dbedit" class="modal c-modal hide container" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"><div elem-identifier="ModalBody" class="modal-body"><div class="tree" id="qSeeMoreTree_body"></div></div></div>');
	$("body", document).append(modalDiv);
	modalDiv.modal('show');
	var link = selectList.data("see-more-tree-url");
	$.ajax({
		type: 'GET',
		data: params,
		url: link,
		success: function (data) {
			if (data.Success && data.Data) {
				var modal = $(modalDiv);
				modal.modal();
				$("#qSeeMoreTree_body", $(modalDiv)).QTreeTable_SeeMore(data.Data, selectList);
				modalDiv.modal("layout");
			}
		},
		traditional: true
	});
}

function changeTableSort(containerDiv, column) {
	var container = $("#" + containerDiv);
	var tableId = $("table", container).attr("id");
	var sortInput = $("input[id='s" + tableId + "']", container);
	var directionInput = $("input[id='d" + tableId + "']", container);
	if(sortInput.val() == column && directionInput.val() == "ASC")
		directionInput.val("DESC");
	else
		directionInput.val("ASC");
	sortInput.val(column);
	$("button:first", container).click();
}

function changeTablePagination(containerDiv, page) {
	var container = $("#" + containerDiv);
	var tableId = $("table", container).attr("id");
	var pageInput = $("input[id='p" + tableId + "']", container);
	pageInput.val(page);
	$("button:first", container).click();
}

/*****************
*  Delete Image  *
*****************/

function DeleteImage(divId, link, buttonDelete) {
	$.ajax({
		type: 'POST',
		url: link,
		contentType: 'application/json',
		dataType: "json",
		success: function (data) {
			var element = $("#thumbnail_" + divId).parent().parent();
			var parent = element.parent();
			element.remove();
			parent.prepend("<text class='empty-value' color='whiteSmoke' font-style='italic' data-empty='&lt;"+quidgestGlobals.Resources.VAZIO58398+"&gt;'></text>");
			$("#" + buttonDelete).remove();
		},
		traditional: true
	});
}

/************
*  DBEdits  *
*************/

function GetDbName(element, currName) {
	var dbName = element.attr("db-field");
	if(dbName)
		return dbName;
	else
		return currName;
}

/******************
*  Extended Form  *
******************/

// Makes extended form clickable
function extendedAjaxForm(target) {
	$(target + ' tbody tr').css('cursor', 'pointer'); // TODO ...

	$('tbody td:not(.row-actions)', target).off('click').click(function (e) {
		var eTarget = e.target,
			row = eTarget.nodeName === 'TR' ? $(eTarget) : $(eTarget).closest('tr'),
			action = $('.row-actions a.b-icon-text.b-icon-text--primary', row);
		action.click();
	});
}

// Makes extended form clickable
/*function extendedHorizontalAjaxForm(target) {
	$(target + ' tbody tr td:not(:nth-child(1))').css('cursor', 'pointer'); // TODO ...

	$('tbody td', target).click(function (e) {
		var eTarget = e.target,
			row = $(eTarget).closest('tr'),
			rowActions = $('.row-actions a', row);
		rowActions.click();
	});
}*/

// Makes extended form clickable
function extendedHorizontalAjaxForm(target) {
	$(target + ' tbody tr td:not(:nth-child(1))').css( 'cursor', 'pointer' );

	$(target).click(function(e){
		var Elem = e.target;
		if (Elem.nodeName=='TD'){
			var index = $(Elem).index();
			var att = $($(Elem).parent().siblings().last().children().get(index)).children();
			att.click();
		}
	});
}

// Submits a nested form
function submitNestedForm(link, target, isDelete) {
	// Gets the params for the inner form
	var divForm = $("#" + target).parent();
	var listTable = $("#" + divForm.attr("data-target")).attr("id");
	var params = { nestedForm: true }
	if (!isDelete) { //if is a delete action, we just need the "id", not the whole form
		params = $.extend(params, getInputsForNestedForm(divForm));
	}

	// submits change
	$.ajax({
		url: link,
		type: 'POST',
		data: params,
		currentTarget: divForm.find('[data-form]'),
		traditional: true,
		success: function (data) {
			if(data.Success) {
				//Destroy form variable
				if (divForm.find('[data-form]').data("QForm") !== undefined) {
					var qFormVarName = divForm.find('[data-form]').data("QForm");
					if(window[qFormVarName] !== undefined) window[qFormVarName].Destroy();
				}
				// reloads list table
				window[divForm.attr("data-target")].Reload();

				$('#' + divForm.attr("id")).html('<div class="alert alert-block alert-success">' + data.Message + ' '+quidgestGlobals.Resources.ESCOLHA_UM_ELEMENTO_24060+'</div>');
			} else
				$('#' + divForm.attr("id")).html('<div class="alert alert-block alert-error">' + data.Message + ' '+quidgestGlobals.Resources.ESCOLHA_UM_ELEMENTO_24060+'</div>');
		},
		error: function (data) {
			$('#' + divForm.attr("id")).html('<div class="alert alert-block alert-error">' + JSON.parse(data.responseText) + ' '+quidgestGlobals.Resources.ESCOLHA_UM_ELEMENTO_24060+'</div>');
		}
	});
}

function submitModalForm(link, target) {
	// Gets the params for the inner form
	var divForm = $("#" + target).parent();
	var params = getInputsForNestedForm(divForm);
	// submits change
	$.ajax({
		url: link,
		type: 'POST',
		data: params,
		success: function (data) {
			if(data.Success) {
				divForm.modal('hide');
				alert(data.Message);
			} else
				divForm.prepend('<div class="alert alert-block alert-error">' + data.Message + ' '+quidgestGlobals.Resources.ESCOLHA_UM_ELEMENTO_24060+'</div>');
		},
		error: function (data) {
			divForm.prepend('<div class="alert alert-block alert-error">' + JSON.parse(data.responseText) + ' '+quidgestGlobals.Resources.ESCOLHA_UM_ELEMENTO_24060+'</div>');
		}
	});
}

/***********
*  Shared  *
***********/

// Adds the input values to them to the params array
function getInputValues(inputs) {
	var params = {};

	$.each(inputs, function (index, input) {
		var _auxValue = getFieldValue($(input));

		// MH - para manter o FormCollection no POST por ajax, tive que usar $.param que não formata as datas coretamente
		if ($.type(_auxValue) === 'date') {
			_auxValue = _auxValue.toQString();
		}

		params[input.id] = _auxValue;
	});

	// checkLists Values
	var checkLists_Items = $.grep(inputs, function(cb) {
		return $(cb).data("checklist") && $(cb).is(":checked");
	});
	while(checkLists_Items.length > 0) {
		var firstItemName = checkLists_Items[0].name;
		params[firstItemName] = new Array();

		var tmp_Items = $.grep(checkLists_Items, function(cb) {
			return $(cb).attr("name") == firstItemName;
		});

		$.each(tmp_Items, function (index, input) {
			params[firstItemName].push(input.value);
		});

		checkLists_Items = $.grep(checkLists_Items, function(cb) {
			return $(cb).attr("name") != firstItemName;
		});
	}

	return params;
}

// Selects all inputs of a nested form with the given id
function getInputsForNestedForm(form) {
	var inputs = $("input:not(:button), select, textarea", form);
	return getInputValues(inputs);
}

function OpenSuggestion(id, array){
	var labelValue = $('[label-id="' + id + '"]').text();
	labelValue = $.trim(labelValue);
	var helpValue = $('[help-id="' + id + '"]').attr("data-original-title");
	OpenModalForm(quidgestGlobals.UrlAction.Suggestion, { id: id, label: labelValue , help: helpValue, arrayName:array });
}

function TurnSuggestionsOn() {
	$(".suggest").removeClass("suggest--hidden");
	$("#suggestion-icon").addClass("secondary-color");
	$('#suggestcontent').css("right", "50px");
}

function TurnSuggestionsOff() {
	$(".suggest").addClass("suggest--hidden");
	$("#suggestion-icon").removeClass("secondary-color");
}


function ToggleSuggestion() {
	if ($(".suggest--hidden").length) {
		TurnSuggestionsOn();
	}
	else {
		TurnSuggestionsOff();
	}
}


function ChangeElementBKColorByID(id, new_color) {
	$('#'+id).css('background-color', new_color);
}

function appendColumn(tableId) {
	var tbl = $('#' + tableId);
	tbl.find('thead tr:first').prepend('<th elem-identifier="RowOrders" class="RowOrders"></th>');
	tbl.find('tbody tr')
		.addClass('c-table__row--draggable')
		.prepend($('<td class="RowOrders" elem-identifier="RowOrders"></td>')
			.append('<i class="glyphicons glyphicons-move c-table__drag-icon action-elem-alt" tabindex="0" title="' + quidgestGlobals.Resources.CHANGE_ROW_ORDER + '"></i>'));
}

function OrderTable(table, link, holder, button) {

	var order = $(holder).data('order');

	if (order == "B") {
		//we are in reordering mode
		$(button).removeClass('b-icon--secondary');
		$(button).addClass('b-icon--primary');

		appendColumn(table);
		$("#" + table).css('cursor', 'all-scroll');
		$("#" + table + " tbody").sortable({
			helper: function (e, tr) {
				var $originals = tr.children();
				var $helper = tr.clone();
				$helper.children().each(function (index) {
					$(this).width($originals.eq(index).width());
				}); return $helper;
			},
			change: function (event, ui) {
				$("#" + table + " tbody tr[data-key=" + $(ui.item).attr("data-key") + "]").addClass('highlighted');
			},
			stop: function (event, ui) {
				$("#" + table + " tbody tr[data-key=" + $(ui.item).attr("data-key") + "]").addClass('highlighted');
				$.ajax({
					url: link,
					type: "POST",
					dataType: "json",
					data: {
						id: $(ui.item).attr("data-key"),
						position: ui.item.index(),
						partialView: table + "_Partial"
					},
					success: function () {
						window[table].Reload();
					}
				});
			},
			update: function (event, ui) {
				$("#" + table + " tbody tr[data-key=" + $(ui.item).attr("data-key") + "]").removeClass('highlighted');
			}
		}).disableSelection();
	}
	else {
		//we are in normal mode
		$(button).removeClass('b-icon--primary');
		$(button).addClass('b-icon--secondary');
		$("#" + table).css('cursor', 'default');
	}

	//setup the button click
	$(button).off("click").on("click", function () {
		var o = $(holder).data('order');

		//Get advanced search button
		var asBtn = $('#' + table + '_extra');
		//Get advanced search row
		var asRow = $('#' + table + '_complex_filter');

		if (o == 'B') {
			$(holder).removeData('order');
			$(button).removeClass('b-icon--primary');
			$(button).addClass('b-icon--secondary');

			//Show advanced search button
			if (asBtn !== undefined && asBtn !== null) {
				asBtn.show();
			}
		}
		else {
			$(holder).data('order', 'B');
			$(button).addClass('b-icon--primary');
			$(button).removeClass('b-icon--secondary');

			//Hide advanced search button
			if (asBtn !== undefined && asBtn !== null) {
				asBtn.hide();

				//Close advanced search
				if (asRow.is(':visible')) {
					changeFilters('#' + table + '_complex_filter', table + '_tableFilters');
					applyComplexFilterIDs();
				}
				//Clear advanced search
				RemoveAllSearchFilters();
				window[table].Search();
			}
		}
		window[table].Reload();
	});
}


/************
*  Reports  *
************/
// Requests a report
function requestReport(link, isAjaxRequest) {
	if(isAjaxRequest) {
		$.ajax({
			url: link,
			type: 'POST',
			success: function (data) {
				if (data.Success) {
					$("#result-report").append("<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert'>x</button>" + data.Message + "</div>");
				} else {
					$("#result-report").append("<div class='alert alert-error'><button type='button' class='close' data-dismiss='alert'>x</button>" + data.Message + "</div>");
				}
			}
		});
	}
	else {
		QUtils.NavigateTo = link;
	}

	return false;
}

/*************
*  QRoutine  *
*************/
function QRoutine_AjaxCall(urlAction, parameters, beforeSend_Callback, done_Callback) {
		$.ajax({
			url : urlAction,
			cache: false,
			type: "POST",
			contentType: 'application/json',
			data: JSON.stringify(parameters),
			beforeSend: beforeSend_Callback,
		}).done(done_Callback).fail(function(jqXHR, textStatus, errorThrown) {
			if (errorThrown != "canceled") {
				displayMessage(quidgestGlobals.Resources.NAO_FOI_POSSIVEL_CONCLUIR, MessageDefs.StatusEnum.E);
			}
		});
	}

/*************
*  Functions *
*************/
function ExecuteServerFunction(func, args) {
	var params = { func: func, args: args };
	if (func === undefined || args === undefined) {
		QError.AppendError("Error on ExecuteServerFunction: Invalid arguments", params);
		return;
	}


	//To prevent functions that retrun date values from going back 1 hour
	if (Array.isArray(args)) {
		for (i = 0; i <= args.length; i++) {
			if (args[i] instanceof Date) {
				args[i] = args[i].toQString();
			}
		}
	}

	return $.ajax({
		type: 'POST',
		url: quidgestGlobals.UrlAction.ExecuteServerFunction,
		dataType: "json",
		contentType: "application/json",
		data: JSON.stringify(params),
		cache: false
	}).then(function (response, textStatus, jqXHR) {
		var data = JSON.parse(response);
		if (data.success) {
			return data.result;
		}
		else {
			QError.AppendError("Error on ExecuteServerFunction: " + data.message, data.result, quidgestGlobals.UrlAction.ExecuteFunction);
			return undefined;
		}
	}, function (response) {
		return undefined;
	});
}

/*************
*  Formulas  *
*************/
function getFieldValue(target, getHumanValue) {
	if ($(target).data("QObject")) {
		var qControl = $(target).data("QObject");
		if (getHumanValue && qControl.Text !== undefined) return qControl.Text;
		return qControl.Value;
	}
	else {
		// radio buttons without QObject
		if ($(target).is(":radio"))
			return $('input[name="' + $(target).attr("name") + '"]:checked').val();
		else if ($(target).is('div'))
			return $(target).text();
		else
			return $(target).val();
	}
}

function setFieldValue(target, targetValue, setHumanValue) {
	if ($(target).data("QObject")) $(target).data("QObject").Value = targetValue;
	else {
		if ($(target).is('div'))
			$(target).text(targetValue);
		else
			$(target).val(targetValue);
	}
}

function QPreValida(target, mode) {
	/// <summary>
	/// Pre-Validação
	/// </summary>
	/// <param name="target">html object, ex: botão que foi clicado</param>
	/// <param name="mode">SAVE | NEW | EDIT | DUP | DELETE</param>
	/// <returns>true/false</returns>
	var formElement = $(target).closest('[data-form]');
	if ($(formElement).data('QForm') !== undefined) {
		var qForm = $(formElement).getQForm();
		return qForm.OnPreValida(mode, $(target));
	}
	else return true;
}

function onNavigation(event, target, mode) {
	event.preventDefault();
	event.stopPropagation();

	const EXECUTION_DISABLED_ATTR = 'navigation-execution-disabled';

    /**
     * To prevent multiple executions of handlers (which can happen in cases of multiple clicks on the same button if the system and network are slow), 
     *  a specific attribute is used to block the element that triggers the event and only unlocks if the page is not changed to another. 
	 * Without this block, multiple executions can cause various problems on the server, including corrupting the levels of history.
     */
	if ($(target).data(EXECUTION_DISABLED_ATTR)) {
        console.warn('Already processing, please wait...');
        return false;
    }
    $(target).data(EXECUTION_DISABLED_ATTR, true);

	const _fnEnableSubmission = () => $(target).data(EXECUTION_DISABLED_ATTR, false);

	try
	{
		//Determine if form mode has a loading animation
		mode = (mode || '').toUpperCase()
		hasLoadingAnimation = (mode === 'DUP' || mode === 'SHOW' || mode === 'NEW' || mode === 'DELETE')

		var href = target.getAttribute("href"),
			isModalForm = (target.getAttribute("data-modal-form") == "True" || target.getAttribute("data-modal-form") == "true"),
			_qForm = $(target).closest('[data-form]'),
			skipPreValida = $(target).data("skip-prevalida");

		var preValida = function (isModalForm, target, mode) {
			if (!isModalForm) return QPreValida($(target), mode);
			else return true;
		}

		// The insertion of the new record in the upper table does not require saving the form (PreValida + Apply)
		// Between copying and/or opening a link in a new tab, it is preferable that controlled exit be made
		// The most common case is insertion in required dbedit field
		if (skipPreValida) {
			window.qVar_isControlledRedirect = true;
			$.when(syncFormKeys(_qForm)).then(function () {
				//Navigate to href
				if (!isModalForm) { //Os modal forms tenham o load proprio - Deve ser revisto para fazer load a partir daqui!
					//Add loading animation if necessary here since the navigation will happen
					if (hasLoadingAnimation)
						qAddLoading(0);
					_fnEnableSubmission();
					window.location = href;
				}
				else
					_fnEnableSubmission();
			}).fail(() => _fnEnableSubmission());
		} else {
			$.when(preValida(isModalForm, target, mode), href, isModalForm, _qForm).then(function (preValida, href, isModalForm, _qForm) {
				window.qVar_isControlledRedirect = preValida;
				$.when(syncFormKeys(_qForm)).then(function () {
					//Navigate to href
					if (!isModalForm && preValida) { //Os modal forms tenham o load proprio - Deve ser revisto para fazer load a partir daqui!
						//Add loading animation if necessary here since the navigation will happen
						if (hasLoadingAnimation)
							qAddLoading(0);
						_fnEnableSubmission();
						window.location = href;
					}
					else 
						_fnEnableSubmission();
				}).fail(() => _fnEnableSubmission());
			}).fail(() => _fnEnableSubmission());
		}
	}
	catch(e)
    {
        console.error('Error while processing navigation handler', e);
        $(target).data(EXECUTION_DISABLED_ATTR, false);
    }
}

function extendQuidgestGlobals(object){
	var keepsafe = $.extend(true,{}, quidgestGlobals);
	$.extend(true, quidgestGlobals, object);
	quidgestGlobalsStack.push(keepsafe);
	return keepsafe;
};

function restoreQuidgestGlobals(){
	var object = quidgestGlobalsStack.pop();
	$.extend(true, quidgestGlobals, object);

	return object;
};

function _getRecursiveFormsKeys(targetForm) {
	var parentForm = $(targetForm).parent().closest('[data-form]'),
		keys = [];

	if (parentForm.length !== 0)
		keys.concat(_getRecursiveFormsKeys(parentForm));

	var qForm = $(targetForm).getQForm();
	if (qForm instanceof QForm ) {
		var formKeys = {
			level: qForm.NavigationLevel,
			navId: qForm.NavigationId,
			formAction: qForm.formAction,
			values: []
		};
		$.each(qForm.Data.RelationKeys, function (area, keyValue) {
			if(area !== "formContext")
				formKeys.values.push({
					key: area,
					value: keyValue
				});
		});
		if(formKeys.values.length !== 0)
			keys.push(formKeys);
	}
	return keys;
}

function syncFormKeysSubmit(keys) {
	if (keys === undefined || keys.length === 0)
		return false;

	return $.ajax({
		type: 'POST',
		url: quidgestGlobals.UrlAction.syncFormKeys,
		contentType: 'application/json',
		dataType: "json",
		data: JSON.stringify({ formKeys: keys }),
		success: function (data) {
			if (data.Success == 'OK') { return true; }
			else { console.log("Error on submit form keys"); return false;}
		},
		traditional: true
	});
}

function syncFormKeys(mainTarget)
{
	var deferred = $.Deferred(),
		targetForm = $(mainTarget);
	if (targetForm.length === 0) {
		targetForm = $("form").first();
	}
	if (targetForm.length === 0) { deferred.resolve(true); }
	else {
		try {
			var keys = _getRecursiveFormsKeys(targetForm);
			$.when(syncFormKeysSubmit(keys)).done(function () { deferred.resolve(true); });
		} catch (err) {
			QError.AppendError('Synchronizing form keys: ' + err.message, err.stack, window.location.href);
			deferred.resolve(false);
		}
	}
	return deferred.promise();
}

jQuery.fn.getPath = function (onlyVisible, asArr) {
	var firstTag = onlyVisible ? $(this.closest('.open').first()) : $(this);
	if (firstTag.length === 0) firstTag = $(this);
	var tags = onlyVisible ? firstTag.parents().addBack().filter(':visible') : firstTag.parents().addBack();
	var path = tags.map(function () {
		var $this = $(this),
			tagName = this.nodeName.toLowerCase();
		if ($this.siblings(tagName).length > 0) {
			tagName += ":eq(" + $this.prevAll(tagName).length + ")";
		}
		return tagName;
	}).get();
	return asArr ? path : path.join(">");
}

/**
 * Load a url into a page + set currentTarget to the Ajax request.
 * (simplified version of jQuery.fn.load)
 */
jQuery.fn.qLoad = function(url) {
	var self = this
	// If we have elements to modify, make the request
	if (self.length > 0) {
		jQuery.ajax({
			url: url,
			type: "GET",
			dataType: "html",
			currentTarget: self
		}).done(function(responseText) { self.html(responseText ); } );
	}
	return this;
}

// Generic Utils
var QUtils = QUtils || (function () {
	return {
		WindowReload: function () { syncFormKeys(); window.qVar_isControlledRedirect = true; window.location.reload(); },
		set NavigateTo(newURL) { if (newURL) { window.qVar_isControlledRedirect = true; window.location.href = newURL; } },
		WindowOpen: function (URL, target) {
			if(target === '_self') {
				window.qVar_isControlledRedirect = true;
			}
			var newWindow = window.open(URL, target);
			if (newWindow == null || typeof (newWindow) == 'undefined') {
				QAnimation.alert(quidgestGlobals.Resources.POPUP_BLOQUEADO, 11000);
			}
		},
		escapeRegExp: function (string) {
			return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&'); // $& means the whole matched string
		},
		ParseUIFloat: function(value) {
			var numberFormat = quidgestGlobals.numberFormat;
			if ( value.indexOf(numberFormat.currencySymbol) > -1 ) {
				// remove currency symbol
				value = value.replace(new RegExp(QUtils.escapeRegExp(numberFormat.currencySymbol), "g"), "");
				// replace currency group seperator
				value = value.replace(new RegExp(QUtils.escapeRegExp(numberFormat.currencyGroupSeparator), "g"), "");
				// replace currency decimal seperator
				value = value.replace(new RegExp(QUtils.escapeRegExp(numberFormat.currencyDecimalSeparator), "g"), numberFormat.numberDecimalSeparator);
			}
			else {
				// replace group seperator
				value = value.replace(new RegExp(QUtils.escapeRegExp(numberFormat.numberGroupSeparator), "g"), "");
			}
			// replace decimal seperator
			value = value.replace(new RegExp(QUtils.escapeRegExp(numberFormat.numberDecimalSeparator), "g"), ".");
			//Remove percentage character from number string before parsing
			if (value.indexOf('%') > -1){
				value = value.replace('%', "");
			}
			// Remove spaces
			value = value.replace( / /g, "");
			return parseFloat(value);
		},
		parseDate: function(value, dataFormat) {
			var date = moment(value, dataFormat);
			if(date.isValid()) { return date.toDate(); }
			else return null; // Return null in case if value is empty string or invalid
		},
		formatDate: function(date, dataFormat) {
			if(date && date._isAMomentObject) {
				return date.format(dataFormat);
			}
			return Globalize.format(date, dataFormat, 'en'); // en - Use default dateformat without '/' replaces
		},
		DateCtl2ISOString: function (fieldSelector) {
			var value = $(fieldSelector).val();
			var qControl = $(fieldSelector).getQControl();
			if (qControl) {
				value = qControl.Value;
			}
			else {
				var dataFormat = $(fieldSelector).attr("data-datetimepicker-format") || $(fieldSelector).attr("data-format"); // datetimepicker => for correct Moment.js parsing
				if (dataFormat) {
					value = QUtils.parseDate(value, dataFormat);
				}
			}
			if ($.type(value) === 'date') {
				value = value.toQString();
			}
			return value;
		},
		tryParseDate: function (value, isHour) {
			if (jQuery.type(value) === "string") {
				// Try convert C# string to JS date
				var patternCSharp = /Date\(([^)]+)\)/,
					patternJSON = /(\d{4}-\d{2}-\d{2})[T](\d{2}:\d{2}:\d{2}.?(\d{3})?)[Z]?/;
				if (patternCSharp.test(value)) {
					return moment.utc(value);
				} else if (patternJSON.test(value)) {
					return moment.utc(value);
				} else if (isHour) {
					var patternHour = /([01]\d|2[0-3]):([0-5]\d)/;
					if (patternHour.test(value)) {
						var results = patternHour.exec(value);
						return moment.utc(results[1] + ':' + results[2], 'HH:mm');
					}
				} else if (value === "") {
					return null; // Null is the default value of empty Date control
				}
			}
			return null;
		},
		get NavigationId() {
		   return $('#CurrentNavigationId').first().val() || 'Unknown';
		},
		MousePosition: {
			__currentMousePos: { x: -1, y: -1 },
			__eventAlreadyHandled: false,
			__init: function () {
				if (!QUtils.MousePosition.__eventAlreadyHandled) {
					QUtils.MousePosition.__eventAlreadyHandled = true;
					$(document).mousemove(function (event) {
						QUtils.MousePosition.__currentMousePos.x = event.pageX;
						QUtils.MousePosition.__currentMousePos.y = event.pageY;
					});
				}
			},
			get Current() {
				QUtils.MousePosition.__init();
				return QUtils.MousePosition.__currentMousePos;
			}
		},
		focusOnId: function (id) {
			var label = $('label[for="' + id + '"]');
			if (label && label.length === 1) {
				var tabs = label.closest('[elem-identifier="Tabbable"]').first();
				if (tabs) {
					var tabId = label.closest('div.tab-pane').attr('id');
					var tab = $('ul > li[data-tab="' + tabId + '"] > a[data-toggle="tab"]', tabs);
					if (tab) { tab.click(); }
				}

				var groups = label.parents('[elem-identifier="AccordionBody"]');
				$.each(groups, function (i, group) {
					var groupId = $(group).attr('id');
					var groupHeader = $(group).closest('[elem-identifier="AccordionGroup"]')
						.find('a.collapsed[data-zone-type="ZC"][data-target="#' + groupId + '"], a.collapsed[data-zone-type="ZA"][data-target="#' + groupId + '"]');
					if (groupHeader) { groupHeader.click(); }
				});

				var top = label.offset().top;
				$('html, body').data('already-animated-scroll', true);
				$('html, body').animate({ scrollTop: (top > 100) ? (top - 100) : top }, 'slow', 'swing', function () {
					$(label).addClass('highlighted-lable');
					setTimeout(function () { $(label).removeClass('highlighted-lable'); }, 1000);
				});
			}
		},
		isElementInView: function (element, fullyInView) {
			var w = $(window), elem = $(element),
				pageTop = w.scrollTop(),
				pageBottom = pageTop + w.height(),
				pageLeft = w.scrollLeft(),
				pageRight = pageLeft + w.width(),
				elementTop = elem.offset().top,
				elementBottom = elementTop + elem.height(),
				elementLeft = elem.offset().left,
				elementRight = elementLeft + elem.width();

			if (fullyInView === true) {
				return ((pageTop < elementTop) && (pageBottom > elementBottom)
				&& (pageLeft < elementLeft) && (pageRight > elementRight));
			} else {
				return ((elementTop <= pageBottom) && (elementBottom >= pageTop)
				&& (elementLeft <= pageRight) && (elementRight >= pageLeft));
			}
		},
		GetUrlToAction: function (controller, action, routeValues) {
			return $.post(quidgestGlobals.UrlAction.GetUrlToAction, {
				controllerName: controller,
				actionName: action,
				additionalValues: routeValues
			})
		},
		/**
		 * Calculate the value of a set of values.
		 * @param {Array} values Array with the values to be calculated
		 * @param {String} aggregationFunction Aggregation type (SUM, AVG, MIN, MAX, COUNT)
		 * @returns {Number} The result of the calculation or zero if it fails
		 */
		calcAggregationFunction: function(values, aggregationFunction) {
			let result = 0;

			try {
				if(!Array.isArray(values) || values.length === 0) return 0;

				switch(aggregationFunction)
				{
					case 'SUM':
						{
							result = values.reduce(function(pv, cv) { return pv + cv; }, 0);
						}
						break;
					case 'AVG':
						{
							result = values.reduce(function(pv, cv) { return pv + cv; }, 0) / values.length;
						}
						break;
					case 'MIN':
						{
							result = Math.min.apply(null, values);
						}
						break;
					case 'MAX':
						{
							result = Math.max.apply(null, values);
						}
						break;
					case 'COUNT':
						{
							result = values.length;
						}
				}
			}
			catch(e) {
				console.error('On calc aggregation function', e, aggregationFunction, values);
				return 0;
			}

			return result;
		}
	};
})();

// Generic Animations
var QAnimation = QAnimation || (function () {
	return {
		pleaseWaitDiv: undefined,
		pleaseWaitDivTemplate: '<div class="c-modal c-modal--center hide" id="qPleaseWaitDialog" data-backdrop="static" data-keyboard="false"><div class="c-modal__dialog"><div class="c-modal__content">{0}</div></div></div></div></div></div>',
		pleaseWaitBody_withoutHeader: '<div elem-identifier="ModalBody" class="c-modal__body"><div class="progress" style="margin-bottom: 0px;"><div class="progress-bar progress-bar-striped progress-bar-animated" style="width: {1}%;">{0}',
		pleaseWaitBody_withHeader: '<div class="c-modal__header"><h3 class="c-modal__header-title">{0}</h3></div><div elem-identifier="ModalBody" class="c-modal__body"><div class="progress" style="margin-bottom: 0px;"><div class="progress-bar progress-bar-striped progress-bar-animated" style="width: {1}%;">',
		showPleaseWait: function (text, withoutTitle, progress) {
			/// <summary>Display loading animation (with progress bar)</summary>
			/// <param name="text" type="String" optional="true">The text to appear. Default: "Processing ..."</param>
			/// <param name="withoutTitle" type="Boolean" optional="true">Without title. Default: false</param>
			/// <param name="progress" type="String", optional="true">Progress to start at (0-100). Default: 100%</param>
			if (!progress && progress != '0') progress = '100';
			if (QAnimation.pleaseWaitDiv) { this.hidePleaseWait(); }
			if (withoutTitle === false) { this.hasTitle = true; }
			this.currentText = text;
			var template = withoutTitle ?
				QAnimation.pleaseWaitDivTemplate.replace("{0}", QAnimation.pleaseWaitBody_withoutHeader.replace("{1}", progress)) : QAnimation.pleaseWaitDivTemplate.replace("{0}", QAnimation.pleaseWaitBody_withHeader.replace("{1}", progress));
			QAnimation.pleaseWaitDiv = $(template.replace("{0}", text || quidgestGlobals.Resources.A_PROCESSAR));
			QAnimation.pleaseWaitDiv.modal({
				show:true
			});
		},
		hidePleaseWait: function () {
			/// <summary>Hide loading animation (with progress bar)</summary>
			if (QAnimation.pleaseWaitDiv) {
				QAnimation.pleaseWaitDiv.modal('hide');
			}
			QAnimation.pleaseWaitDiv = undefined;
		},
		destroy: function () {
			const elem = document.getElementById('qPleaseWaitDialog')
			if (elem) {
				document.getElementById('qPleaseWaitDialog').remove();
			}

			const backdrop = document.querySelectorAll('.modal-backdrop');

			backdrop.forEach(backdrop => {
				backdrop.remove();
			});

        },
		addLoading: function (timeout) {
			/// <summary>Display simple loading animation</summary>
			/// <param name="timeout" type="Number" optional="true">Show after 'N' milliseconds. Default: 1000</param>
			var qLoadingCount = window["qLoadingCount"] || 0;
			qLoadingCount++;
			window["qLoadingCount"] = qLoadingCount;

			const startLoading = () => {
				var qLoadingCount = window["qLoadingCount"] || 0;
				if (qLoadingCount > 0 && quidgestGlobals && quidgestGlobals.enableQLoader) {
					$("body").addClass("qloading");
				}
			}

			//When the timeout is 0, execute the loading instantly
			if(timeout == 0) {
				startLoading();
				return;
			}

			return setTimeout(startLoading, timeout || 1000);
		},
		removeLoading: function (timeoutID) {
			/// <summary>Remove simple loading animation</summary>
			if (timeoutID) clearTimeout(timeoutID);
			var qLoadingCount = window["qLoadingCount"] || 0;
			qLoadingCount--;
			if (qLoadingCount <= 0) {
				qLoadingCount = 0;
				$("body").removeClass("qloading");
			}
			window["qLoadingCount"] = qLoadingCount;
		},
		alert: function (msg, timeout) {
			/// <summary>Display alert that disappears automatically</summary>
			/// <param name="msg" type="String" optional="true">The text to appear. Default: "This may take some time"</param>
			/// <param name="timeout" type="Number" optional="true">Timeout. Default: 2500</param>
			displayMessage(msg || quidgestGlobals.Resources.THIS_MAY_TAKE_SOME_TIME, MessageDefs.StatusEnum.W, undefined, undefined, {timeout: timeout || 2500});
		},
		/**
		 * Render the HTML of the server messages
		 * */
		renderMessages: function () {
			try {
				$.get(quidgestGlobals.UrlAction.RenderMessages, function (messagesHtml) {
					// if it has nothing to show, it does nothing
					if (typeof messagesHtml !== 'string' || messagesHtml.length === 0)
						return;
					// Get current active form
					// first try if it is modal form. If not, use the first one (for ignore extended and multi forms)
					let  = true;
					let qForm = $('[qform]', '#form-modal').getQForm();
					if (!qForm) {
						isModal = false;
						qForm = $('[qform]').first().getQForm();
					}

					if (isModal)
						$('[elem-identifier="modal-header"]', qForm.element).append(messagesHtml);
					else
						$(messagesHtml).insertBefore(qForm.element);
				})
			}
			catch (e) {
				console.error('Error on renderMessages', e);
			}
		},
		tracerWaitDiv: undefined,
		tracerWaitDivTemplate: '<div class="c-modal c-modal--center hide" id="TracerDialogModal" data-backdrop="static" data-keyboard="false"><div class="c-modal__dialog"><div class="c-modal__content"><div class="c-modal__header"><h3 class="c-modal__header-title">{0}</h3></div><div elem-identifier="ModalBody" class="c-modal__body"><div class="progress" style="margin-bottom: 0px;"><div class="progress-bar progress-bar-striped progress-bar-animated" style="width: 100%;"></div></div><div style="height: 250px; overflow: auto"><table id="tracetable"></table></div></div><div class="modal-footer"><button type="button" id="btnDownloadCode" class="b-icon-text b-icon-text--secondary">Download</button><button type="button" class="b-icon-text b-icon-text--secondary" data-dismiss="modal">Close</button></div></div></div></div>',
		showTracerWait: function (text,token,url,idAppcl,tracerCallback) {
			/// <summary>Display loading animation (with progress bar)</summary>
			/// <param name="text" type="String" optional="true">The text to appear. Default: "Processing ..."</param>
			$('#TracerDialogModal').remove()
			QAnimation.tracerWaitDiv = $(QAnimation.tracerWaitDivTemplate.replace("{0}", text || quidgestGlobals.Resources.A_PROCESSAR));
			QAnimation.tracerWaitDiv.modal({
				show: true
			});
			//$('#tracetable').append('<tr><td>Trace message</td></tr>');
			if (tracerCallback)
				tracerCallback(url, token, 0, idAppcl);
		},

		hideTracerWait: function () {
			/// <summary>Hide loading animation (with progress bar)</summary>
			if (QAnimation.tracerWaitDiv) {
				QAnimation.tracerWaitDiv.modal('hide');
				$('#tracetable').empty();
			}
			QAnimation.tracerWaitDiv = undefined;
		}
	};
})();

////DSG [temp Bugfix] - adds headers to the table footer to comply with the accessibility rule WCAG2AA.Principle1.Guideline1_3.1_3_1.H43.MissingHeadersAttrs
function addHeaders(element) {

	var tables;
	if(element.is('table') ){
		tables = [element];
	} else {
		tables = element.find('table').toArray();
	}

	tables.forEach(function (table) {
		var headers = "";
		$(table).find("thead > tr > th").each(function () {
			//if(!($(this).attr('id').equals('undefined')))
			if($(this).attr('id'))
				headers += $(this).attr('id') + ' ';
		});

		$(table).find("tfoot > tr > td").attr('headers', headers.trim());
	});
}

//JGF Activate bootstrap tooltips
function activateFormTooltips(forcedOnly) {

	// If help style is set to popover,
	// activates only the ones that force the tooltip format
	let targets = [];
	if (forcedOnly) targets = $('[data-force-tooltip="true"]');
	else targets = $('[data-toggle="tooltip"]');

	var boundaryElement = $("[QForm]")[0];
	var options = {
		delay: { show: "1000" },
		trigger: "hover",
		html:true,
		//Boundary element is needed so the tooltip doesn't overflow to side menus and other controls
		boundary: boundaryElement,
		//Template is used to set the classes c-help and c-help__inner
		template:
			'<div class="tooltip c-help" role="tooltip"><div class="arrow"></div> <div class="tooltip-inner c-help__inner"></div></div> ',
	};

	targets.tooltip(options);

	//Dropdown elements
	$(".chzn-single[title]").tooltip(options);

	var observer = new MutationObserver(function () {
		$('.active-result[data-toggle="tooltip"]').tooltip(options);
	});
	var arrays = document.getElementsByClassName("chzn-drop");

	for (var i = 0; i < arrays.length; i++) {
		observer.observe(arrays[i], { childList: true, subtree: true });
	}

	//Hide the tooltip on click or remove
	targets.on("click remove", function () {
		$(this).tooltip("hide", options);
	});
}

function activatePopovers(typeHelper) {
	$('[data-toggle="tooltip"]').each(function () {
		if (
			$(this).length == 0 ||
			($(this)[0] && $(this)[0].tagName == "LABEL") ||
			$(this).attr("data-force-tooltip")
		) {
			return;
		}

		var labelDiv;

		if (["DatePicker", "TimePicker", "DatetimesecPicker", "DatetimePicker"].includes($(this).attr("elem-identifier")))
			labelDiv = $(this).parent().parent().find("label");
		else if ($(this).attr("elem-identifier") == "FileInputBox")
			labelDiv = $(this).parent().parent().parent().find("label");
		else if ($(this).is(".c-groupbox__title")){
			labelDiv = $(this).children().first();
			$(this).css("display", "flex")
		}
		else if ($(this).is(".b-icon-text"))
			labelDiv = $(this).parent();
		else if (["MenuList", "List"].includes($(this).attr("elem-identifier"))){
			labelDiv = $(this).find("[list-header]");
			$(this).css("width", "fit-content");
		}
		else {
			labelDiv = $(this).parent().find("label");

			if (!labelDiv || labelDiv.length == 0)
				labelDiv = $(this).parent().parent().find("label");
		}

		const verboseDesc = $(this).attr('description');
		let helpText = ''
		if (labelDiv && labelDiv.length != 0 && ((typeHelper == "tooltip" && verboseDesc) || typeHelper == "popover")) {
			labelDiv = labelDiv[0];

			labelDiv.classList.add("i-text__label--popover");

			const title = labelDiv.innerText;
			helpText = $(this).attr("title");
			if (!helpText) helpText = $(this).attr("data-original-title");



			if (verboseDesc != "") btnPopover(title, sanitizeHtml(verboseDesc), labelDiv);
			else if (verboseDesc == "" && typeHelper != "tooltip") btnPopover(title, sanitizeHtml(helpText), labelDiv);


			// Remove the tooltip:hover to keep everything in one place
			$(this).removeAttr("data-toggle");
			$(this).removeAttr("title");
		}

		if (typeHelper == "popover" && verboseDesc && helpText) {
			$(this).tooltip('dispose')
			$(this).attr('data-original-title', null)
		}
		else {
			$(this).tooltip({
				trigger: 'hover',
				html: true,
				template: '<div class="tooltip c-help" role="tooltip"><div class="arrow"></div> <div class="tooltip-inner c-help__inner"></div></div> '
			});
		}
	});

	$('[data-toggle="popover"]').popover({ trigger: 'click' });

	// hide popover when click outside - this allows copy the text inside the popover
	$('body').on('click', function (e) {
		$('[data-toggle="popover"]').each(function () {
			if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
				$(this).popover('hide');
			}
		});
	});
}

function btnPopover(title, text, labelToAppend) {
	// Creation of the info button for verbose helps.
	jQuery(
		`<button type="button" class="b-icon btn-popover" data-toggle="popover"
				data-selector="true" data-html="true" data-trigger="focus"
				data-title="` + title + `" data-content="` + text + `" >
			<svg style="width:16px;height:16px" viewBox="0 0 24 24">
				<path fill="currentColor" d="M11,9H13V7H11M12,20C7.59,20 4,16.41 4,12C4,7.59 7.59,4 12,4C16.41,4 20,7.59 20,12C20,16.41 16.41,20 12,20M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2M11,17H13V11H11V17Z" />
			</svg>
		</button >`
	).appendTo(labelToAppend);
}

function sanitizeHtml(html) {
	if (html !== null && typeof html === "string")
		return html
			.replace(/&/g, "&amp;")
			.replace(/</g, "&lt;")
			.replace(/>/g, "&gt;")
			.replace(/"/g, "&quot;");
	return "";
}

// MH - The help tooltip
(function ($, window) {
	/* Setup the options for the tooltip that can be accessed from outside the plugin */
	var pluginName = 'qHelpTooltip',
		defaults = {
			delay: 1500,
			content: "",
			offsetVertical: 20,
			offsetHorizontal: 20
		};

	function QHelpTooltip(element, options) {
		this.el = element;
		this.$el = $(this.el);
		this.options = $.extend({}, defaults, options);

		this.init();
	}

	QHelpTooltip.prototype = {
		init: function () {
			var $this = this;

			this.title = "";

			/*var offset = $this.$el.offset();
			var tLeft = offset.left;
			var tTop = offset.top;*/

			/* Create a function that builds the tooltip markup */
			var getTip = function () {
				// Create container
				var container = jQuery('<div class="q-help-tip"/>').appendTo('body');
				return container;
			};

			/* Position the tooltip relative to the target associated with the tooltip */
			var setTip = function (tTop, tLeft) {
				var top = tTop + $this.options.offsetVertical,
					bottom = 'auto',
					left = tLeft + $this.options.offsetHorizontal,
					right = 'auto';

				if (top + $this.tip.outerHeight() >= $(window).scrollTop() + $(window).height()) {
					bottom = $(window).height() - top + ($this.options.offsetVertical * 2);
					top = 'auto';
				}

				if (left + $this.tip.outerWidth() >= $(window).width()) {
					right = $(window).width() - left + ($this.options.offsetHorizontal * 2);
					left = 'auto';
				}

				$this.tip.css({ 'top': top, 'bottom': bottom, 'left': left, 'right': right });
			};

			var stopTimer = function () {
				clearInterval($this.showTipTimer);
			};

			/* This function stops the timer and creates the fade-in animation */
			var showTip = function () {
				stopTimer();
				$this.tip = getTip().html($this.options.content);

				// Get mouse possition
				var offset = QUtils.MousePosition.Current;
				var tLeft = offset.x;
				var tTop = offset.y;

				setTip(tTop, tLeft);
			};

			/* Delay the fade-in animation of the tooltip */
			var setTimer = function () {
				$this.showTipTimer = setInterval(showTip, $this.options.delay);
			};

			/* Mouse over and out functions */
			$this.$el.hover(function () {
				setTimer();
			},
				function () {
					stopTimer();
					if ($this.tip) { $this.tip.remove(); }
				}
			);
		}
	};

	$.fn[pluginName] = function (options) {
		return this.each(function () {
			if (!$.data(this, pluginName)) {
				$.data(this, pluginName, new QHelpTooltip(this, options));
			}
		});
	};

})(jQuery, window);

function handleQHelps(element) {
	if(quidgestGlobals.enableQHelp) {
		$('[q-help="column-form"]', element || $(document)).qHelpTooltip({ content: quidgestGlobals.Resources.HELP_COLUMN_FORM });
		$('[q-help="multi-select-column"]', element || $(document)).qHelpTooltip({ content: quidgestGlobals.Resources.HELP_MULTI_SELECT_COLUMN });
		$('[q-help="row-follow-up"]', element || $(document)).qHelpTooltip({ content: quidgestGlobals.Resources.HELP_ROW_FOLLOW_UP });
	}
}

// MH (03/10/2018) - Temporary "brute force" destroy of the QForm before open the other form
function destroyQForm(formName) {
	if (!$.isEmptyObject(formName)) {
		if (window[formName] !== undefined) {
			window[formName].Destroy();
		}
	}
}

function closeExtendedListItem(listId, rowkey) {
	$('#' + listId + ' tr[data-key="' + rowkey + '"]' + ' input:checkbox').click();
}

//TSX (2019/05/09) - Bootbox to request 2FA code
function bootbox2FA(data) {
	var returnData = data;
	var form = $("<form id='form2FA'></form>");
	form.bind('keydown', function (e) {
		if (e.keyCode == 13) {
			e.preventDefault();
			$('[data-bb-handler="ok"]').click();
			//$('[data-handler="1"]', $('#form2FA')).click();
		}
	});
	form.append('<div id="error" class="validation-summary-errors hidden"></div>');
	form.append('<label class=\"i-text__label\">' + quidgestGlobals.Resources.DLG2FAMSG + '</label>');
	form.append('<input id="value2fa" placeholder="000000" class="i-text__field i-text input-xxlarge"/>');

	var form2FA = bootbox.dialog({
		message: form,
		title: quidgestGlobals.Resources.DLG2FATITLE,
		size: 'large',
		closeButton: false,
		backdrop: false,
		onEscape:true,
		buttons: {
			ok: {
				"label": quidgestGlobals.Resources.ENTRAR16118,
				"className": "b-icon-text b-icon-text--primary",
				"callback": function () {
					$.post(quidgestGlobals.UrlAction.Account2FA, $.param({ returnUrl: returnData.Redirect, code: form.find("#value2fa").val() }, true), function (data2FA) {
						if (!data2FA.Success) {
							$("#error").text(data2FA.Message);
							$("#error").removeClass("hidden");
						}
						else {
							form2FA.modal('hide');
							loginSuccess(data2FA);
						}
					});
					return false;
				}
			},

			cancel: {
				"label": quidgestGlobals.Resources.CANCELAR,
				"className": "b-icon-text b-icon-text--secondary",
				"callback": function () { }
			}
		}
	});

	form2FA.find(".modal-dialog").addClass("modal-dialog-centered");
	form2FA.find(".modal-title").addClass("c-modal__header-title");

	form2FA.on('shown.bs.modal', function () {
		$("#value2fa").focus();
	});
}

function sidebarToggle(event)
{
	// TODO: Evaluate the need for this method's existence. If it's really necessary,
	// refactor it to use '#mySidenav' instead of '#sidebar', which no longer exists.
	/*
	var target = $(event.target),
		alreadyOpen = $('#sidebar').hasClass('active');
	if (alreadyOpen) {
		$('#sidebar').removeClass('active');
		$('.overlay').removeClass('active');
	}
	else {
		$('#sidebar').addClass('active');
		$('.overlay').addClass('active');
		$('.collapse.in').toggleClass('in');
		$(target).attr('aria-expanded', 'false');// $('a[aria-expanded=true]')
	}
	*/
}

function scorePassword(pass) {
	var score = 0;
	if (!pass)
		return score;

	// award every unique letter until 5 repetitions
	var letters = new Object();
	for (var i = 0; i < pass.length; i++) {
		letters[pass[i]] = (letters[pass[i]] || 0) + 1;
		score += 5.0 / letters[pass[i]];
	}

	// bonus points for mixing it up
	var variations = {
		digits: /\d/.test(pass),
		lower: /[a-z]/.test(pass),
		upper: /[A-Z]/.test(pass),
		nonWords: /\W/.test(pass),
	}

	variationCount = 0;
	for (var check in variations) {
		variationCount += (variations[check] == true) ? 1 : 0;
	}
	score += (variationCount - 1) * 10;

	return parseInt(score);
}


function AttachPasswordMeter() {
	//For each password-meter elements
	$("[password-meter]").each(function () {
		var inputElement = "#" + $(this).attr("input-element");
		var passwordMeter = $(this);
		$(inputElement).on('input', function () {
			//calcular score da password
			var score = scorePassword($(inputElement).val());
			var scoreStrenght = 0;
			if ($(inputElement).val().length === 0) {
				scoreStrenght = 0;
				$("[password-strength-text]", passwordMeter).text("");
			}
			else {
				if (score > 80) {
					scoreStrenght = 4;
					$("[password-strength-text]", passwordMeter).text(quidgestGlobals.Resources.FORTE);
				}
				else if (score > 60) {
					scoreStrenght = 3;
					$("[password-strength-text]", passwordMeter).text(quidgestGlobals.Resources.BOM);
				}
				else if (score >= 30) {
						scoreStrenght = 2;
						$("[password-strength-text]", passwordMeter).text(quidgestGlobals.Resources.FRACO);
				}
				else if (score <= 30) {
					scoreStrenght = 1;
					$("[password-strength-text]", passwordMeter).text(quidgestGlobals.Resources.POBRE);
				}
			}
			$('[password-strength-meter]', passwordMeter).val(scoreStrenght);
		});
	});
}
AttachPasswordMeter();

var QBookmarks = QBookmarks || (function () {
	return {
		get _menuContainer() { return $('[data-identifier="sidemenu_container"], #menuNavbar'); },
		get _menuBtnSelector() { return $('[menu-module][menu-id]'); },
		get _bookmarksContainer() { return $('[data-identifier="bookmarks_container"]'); },
		ActivateSelectionMode: function () {
			var menus = QBookmarks._menuContainer.find(QBookmarks._menuBtnSelector);

			menus.one('click', function (event) {
				event.preventDefault();
				event.stopPropagation();

				var menu = $(this),
					module = menu.attr('menu-module'),
					menuId = menu.attr('menu-id');
				QBookmarks.AddBookmark(module, menuId);
			});
		},
		_updateContent: function (newHTML) {
			QBookmarks._bookmarksContainer.replaceWith(newHTML);
		},
		AddBookmark: function (module, menuId) {
			var url = quidgestGlobals.UrlAction.AddBookmark;
			$.post(url, { module: module, menuId: menuId }, function (data) {
				if (data.Success && !$.isEmptyObject(data.View)) {
					QBookmarks._updateContent(data.View);
				}
			});
		},
		RemoveBookmark: function (bookmarkId) {
			var url = quidgestGlobals.UrlAction.RemoveBookmark;
			$.post(url, { bookmarkId: bookmarkId }, function (data) {
				if (data.Success) {
					QBookmarks._bookmarksContainer.find('[bookmark-id="' + data.fav_id + '"]').remove();
				} else if (!$.isEmptyObject(data.Message)) {
					displayMessage(data.Message, MessageDefs.StatusEnum.E);
				}
			});
		},
		onClickRemoveBookmark: function (elem) {
			var _target = $(elem),
			bookmarkRow = _target.closest('[bookmark-id]'),
			bookmarkId = bookmarkRow.attr('bookmark-id');
			QBookmarks.RemoveBookmark(bookmarkId);
		}
	}
})();

//Prevent duplicate IDs of applyComplexFilter
function applyComplexFilterIDs() {
	$.each($('[data-id="applyComplexFilter"]'), function () {
		if($(this).is(":visible"))
			{$(this).attr("id", "applyComplexFilter");}
		else
			{$(this).removeAttr("id");}
	});
}

//---------------------------------------------------------------------------------------
// Search Filter functions
//---------------------------------------------------------------------------------------

//FOR: SEARCH FILTERS (FROM SEARCH BAR)

/**
 * Search without using filters
 * @param {string} listId : Menu/table ID
 */
function UnfilteredSearch(listId) {
	//Set all search filters to inactive
	RemoveAllSearchFilters();

	searchFilterGroups = [];
	UpdateSearchFilterBoxes(listId, searchFilterGroups);
	UpdateSearchFilterMenu(listId, searchFilterGroups);

	//Hide search bar field menu
	$("#q" + listId + "_srch_flds").removeClass("show");

	//Hide advanced search
	$("#" + listId + "_complex_filter").css("display", "none");
	setFieldAnchors(listId + "_tableFilters", false);

	//Search without filter data
	$('#SearchFilters').val('');
	window[listId].Search();
}

/**
 * Add event listener to search bar for showing list of fields to search when typing
 * @param {string} search_box_id : Search bar ID
 */
function InitSearchFieldMenu(search_box_id) {
	//Add event listener to search bar
	$("#" + search_box_id).on("keyup", function () {
		if ($("#" + search_box_id).val().length > 0)
			$("#" + search_box_id + "_srch_flds").addClass('show');
		else
			$("#" + search_box_id + "_srch_flds").removeClass('show');

		//Set all fields in search menu to show text in search bar
		$("#" + search_box_id + "_srch_flds a strong").text($("#" + search_box_id).val());
	});
}

/**
 * Add search filter for selected field with text in search bar
 * @param {string} listId : Menu/table ID
 */
function HideSearchFieldMenuOnUnfocus(listId) {
	setTimeout(function () {
		if (!document.activeElement ||
			!document.activeElement.hasAttribute("data-search-field-menu-elem") ||
			document.activeElement.getAttribute("data-search-field-menu-elem") !== "show") {
			$("#q" + listId + "_srch_flds").removeClass("show");
		}
	}, 50);
}

/**
 * Add search filter for selected field with text in search bar
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 * @param {object} fields : Dictionary of all fields in this table
 * @param {string} field : Full name of field (TABLE.COLUMN)
 */
function AddSearchFieldFilter(listId, baseArea, field) {
	var val = $("#q" + listId).val();
	$("#q" + listId).val("");

	//Hide search field menu
	$("#q" + listId + "_srch_flds").removeClass("show");
	//Returns if nothing is searched
	if (val.length < 1) {
		window[listId].Search();
		return;
	}
	RemoveAllSearchFilters();
	SetSearchColumnFilter(listId, baseArea, field, val);

	//Search with filters
	//$('#SearchFilters').val(JSON.stringify(searchFilterGroups));
	window[listId].Search();
}

function SetSearchColumnFilter(listId, baseArea, columnId, value) {
	$("#" + listId + "_complex_filter").css("display", "table-row");
	setFieldAnchors(listId + "_tableFilters", true);
	const toggleButtonId = '#' + listId + '_extra';

	if ($(toggleButtonId + " .glyphicons").hasClass('glyphicons-zoom-in')) {
		toggleSearchIcon(toggleButtonId)
	}

	//JGF 2021.09.06 There is a mismatch in the format of the field name and the column in dbedit. I am mapping it for now, but it should be made the same in the future.
	var areaField = columnId.split(".");
	var area = CapFirst(areaField[0])
	var field = CapFirst(areaField[1])
	baseArea = baseArea.charAt(0) + baseArea.substring(1, baseArea.length).toLowerCase();
	var id = listId + "_" + area + "_" + "Val" + field;
	var el = $("#" + id); //Area above
	if (el.length == 0 && baseArea == area) {
		el = $("#" + listId + "_" + "Val" + field); //Same area
	} else {
		el = $("[id$='" + area + "_Val" + field + "']"); //Area 2x above
	}
	el.val("%"+value+"%");
}

/**
 * Add search filters for all fields with text in search bar
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 * @param {object} fields : Dictionary of all fields in this table
 */
function AddSearchFieldFilterAll(listId, searchFilterGroups, fields) {
	var val = $("#q" + listId).val();
	var condOperator = "";
	var sfcArray = [];

	for (var field in fields) {
		//Set operator based on field type
		condOperator = "";
		switch (fields[field].Type) {
			case "text":
				condOperator = "CON";
				break;
			case "num":
				condOperator = "EQ";
				break;
			case "bool":
				if (val.toUpperCase() === "TRUE")
					condOperator = "TRUE";
				else if (val.toUpperCase() === "FALSE")
					condOperator = "FALSE";
				else
					continue;
				break;
			case "date":
				condOperator = "EQ";
				break;
			case "enum":
				condOperator = "IS";
				break;
		}

		//Add condition to this search filter
		var sfc = new SearchFilterCondition("", true, field, condOperator, [val]);
		sfcArray.push(sfc);
	}

	//Add this search filter to menu search filters
	searchFilterGroups.push(new SearchFilter('', true, sfcArray));

	//Update search filter object and corresponding controls
	UpdateSearchFilterStatus(listId, searchFilterGroups);

	//Hide search field menu
	$("#q" + listId + "_srch_flds").removeClass("show");

	//Search with filters
	$('#SearchFilters').val(JSON.stringify(searchFilterGroups));
	window[listId].Search();
}

//FOR: SEARCH FILTERS (FROM MENU)

//Search filter objects with corresponding objects in C#

/**
 * Search filter
 * @param {string} name : Name of search filter
 * @param {bool} active : Active/inactive state
 * @param {SearchFilterCondition[]} conditions : Array of conditions
 */
function SearchFilter(name, active, conditions) {
	this.Name = name;
	this.Active = active;
	this.Conditions = conditions;
}

/**
 * Search filter condition
 * @param {string} name : Name of condition
 * @param {bool} active : Active/inactive state
 * @param {string} field : Full name of field (TABLE.COLUMN)
 * @param {string} operator : Operator code (as in operators object)
 * @param {string[]} values : Array of values
 */
function SearchFilterCondition(name, active, field, operator, values) {
	this.Name = name;
	this.Active = active;
	this.Field = field;
	this.Operator = operator;
	this.Values = values;
}

/**
 * Field with information needed for search filters
 * @param {string} area : Name of table/area
 * @param {string} field : Name of field
 * @param {string} title : Title/description of field
 * @param {string} type : type of field (as in operators object)
 * @param {string[]} array : Array of enumerated values field can have (only for enumerated field types)
 */
function TableFilterField(area, field, title, type, array) {
	this.Area = area;
	this.Field = field;
	this.Title = title;
	this.Type = type;
	this.Array = array;
}

/**
 * Stop event propagation
 * @param {object} e : Event
 */
function StopProp(e) {
	var event = e || window.event;
	event.stopPropagation();
}

//Search filter condition operators
var operators = {
	"text": {
		"LIKE": { "Title": quidgestGlobals.Resources.E_COMO08847, "ValueCount": 1 },
		"STRTWTH": { "Title": quidgestGlobals.Resources.COMECA_COM43341, "ValueCount": 1 },
		"CON": { "Title": quidgestGlobals.Resources.CONTEM47071, "ValueCount": 1 },
		"NOTCON": { "Title": quidgestGlobals.Resources.NAO_CONTEM06109, "ValueCount": 1 },
		"EQ": { "Title": quidgestGlobals.Resources.E_IGUAL_A44445, "ValueCount": 1 },
		"NOTEQ": { "Title": quidgestGlobals.Resources.DIFERENTE_DE49330, "ValueCount": 1 },
		"SET": { "Title": quidgestGlobals.Resources.ESTA_DEFINIDO06498, "ValueCount": 0 },
		"NOTSET": { "Title": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392, "ValueCount": 0 }
	},
	"num": {
		"EQ": { "Title": quidgestGlobals.Resources.E_IGUAL_A44445, "ValueCount": 1 },
		"NOTEQ": { "Title": quidgestGlobals.Resources.DIFERENTE_DE49330, "ValueCount": 1 },
		"GREAT": { "Title": quidgestGlobals.Resources.E_MAIOR_QUE55118, "ValueCount": 1 },
		"LESS": { "Title": quidgestGlobals.Resources.E_MENOR_QUE43521, "ValueCount": 1 },
		"GREATEQ": { "Title": quidgestGlobals.Resources.E_MAIOR_OU_IGUAL_A12958, "ValueCount": 1 },
		"LESSEQ": { "Title": quidgestGlobals.Resources.E_MENOR_OU_IGUAL_A33027, "ValueCount": 1 },
		"BETW": { "Title": quidgestGlobals.Resources.ESTA_ENTRE61087, "ValueCount": 2 },
		"SET": { "Title": quidgestGlobals.Resources.ESTA_DEFINIDO06498, "ValueCount": 0 },
		"NOTSET": { "Title": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392, "ValueCount": 0 }
	},
	"bool": {
		"TRUE": { "Title": quidgestGlobals.Resources.E_VERDADEIRO09772, "ValueCount": 0 },
		"FALSE": { "Title": quidgestGlobals.Resources.E_FALSO54943, "ValueCount": 0 }
	},
	"date": {
		"BETW": { "Title": quidgestGlobals.Resources.ESTA_ENTRE61087, "ValueCount": 2 },
		"EQ": { "Title": quidgestGlobals.Resources.E_IGUAL_A44445, "ValueCount": 1 },
		"NOTEQ": { "Title": quidgestGlobals.Resources.DIFERENTE_DE49330, "ValueCount": 1 },
		"AFT": { "Title": quidgestGlobals.Resources.E_DEPOIS37889, "ValueCount": 1 },
		"BEF": { "Title": quidgestGlobals.Resources.E_ANTES60177, "ValueCount": 1 },
		"AFTEQ": { "Title": quidgestGlobals.Resources.E_DEPOIS_OU_IGUAL_A34778, "ValueCount": 1 },
		"BEFEQ": { "Title": quidgestGlobals.Resources.E_ANTES_OU_IGUAL_A19958, "ValueCount": 1 },
		"SET": { "Title": quidgestGlobals.Resources.ESTA_DEFINIDO06498, "ValueCount": 0 },
		"NOTSET": { "Title": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392, "ValueCount": 0 }
	},
	"enum": {
		"IS": { "Title": quidgestGlobals.Resources.E00079, "ValueCount": 1 },
		"ISNOT": { "Title": quidgestGlobals.Resources.NAO_E03382, "ValueCount": 1 },
		"SET": { "Title": quidgestGlobals.Resources.ESTA_DEFINIDO06498, "ValueCount": 0 },
		"NOTSET": { "Title": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392, "ValueCount": 0 }
	}
};

/**
 * Add controls for adding a condition
 * @param {string} listId : Menu/table ID
 * @param {object} fields : Dictionary of all fields in this table
 * @param {object} operators : Search filter condition operators
 */
AddSearchFilterConditionForm.conditionID = 0;
function AddSearchFilterConditionForm(listId, fields, operators) {
	//Create condition element ID
	AddSearchFilterConditionForm.conditionID++;
	var condID = listId + "_condition_" + AddSearchFilterConditionForm.conditionID;

	//Condition container element
	var condCont = document.createElement("div");
	condCont.setAttribute("data-search-filter-elem", "condition");
	condCont.setAttribute("id", condID);
	condCont.classList.add("filter-condition-container");
	var conditionGroup = $("#filter_menu_" + listId + " [data-search-filter-elem='condition-group']").get(0);

	//Show "or" for conditions after the first
	if (conditionGroup.children.length > 0) {
		var condSep = document.createElement("div");
		condSep.setAttribute("data-search-filter-elem", "separator-or");
		condSep.classList.add("filter-separator-or");
		var condSepText = document.createTextNode(quidgestGlobals.Resources.OU11765);
		condSep.appendChild(condSepText);
		condCont.appendChild(condSep);
	}

	conditionGroup.appendChild(condCont);

	//Field list box
	var condField = document.createElement("select");
	condField.setAttribute("data-search-filter-elem", "field");
	for (field in fields)
	{
		var optField = document.createElement("option");
		optField.value = fields[field].Area + "." + fields[field].Field;
		optField.innerHTML = fields[field].Title;
		condField.appendChild(optField);
	}
	condField.classList.add("filter-input-field");
	condCont.appendChild(condField);

	//Break
	var br1 = document.createElement("br");
	condCont.appendChild(br1);

	//Operator list box
	var condOp = document.createElement("select");
	condOp.setAttribute("data-search-filter-elem", "operator");
	condOp.classList.add("filter-input-operator");
	condCont.appendChild(condOp);

	//Break
	var br2 = document.createElement("br");
	condCont.appendChild(br2);

	//Value container
	var condVals = document.createElement("div");
	condVals.setAttribute("data-search-filter-elem", "value-container");
	condCont.appendChild(condVals);

	//Remove button
	var removeIcon = document.createElement("i");
	removeIcon.classList.add("glyphicons");
	removeIcon.classList.add("glyphicons-remove");
	var removeBtn = document.createElement("button");
	removeBtn.setAttribute("type", "button");
	removeBtn.setAttribute("data-search-filter-elem", "condition-form-remove");
	removeBtn.innerHTML += quidgestGlobals.Resources.ELIMINAR_CONDICAO10490;
	removeBtn.appendChild(removeIcon);
	removeBtn.classList.add("b-btn");
	removeBtn.classList.add("b-icon-text");
	removeBtn.classList.add("b-btn--full-width");
	removeBtn.classList.add("b-icon-text--secondary");
	removeBtn.classList.add("filter-cond-btn");
	removeBtn.classList.add("filter-remove-btn");
	removeBtn.onclick = function () {
		RemoveSearchFilterConditionForm(condID, listId);
	}
	condCont.appendChild(removeBtn);

	//Disable remove button if there is only one condition
	var conditionConts = $(conditionGroup).find("[data-search-filter-elem='condition']");
	if (conditionConts.length == 1) {
		removeBtn.disabled = true;
		removeBtn.classList.add("disabled");
	}
	//Enable remove button in first condition if there are multiple conditions
	else {
		var removeBtnFirst = conditionConts.first().find("[data-search-filter-elem='condition-form-remove']").get(0);
		removeBtnFirst.removeAttribute("disabled");
		removeBtnFirst.classList.remove("disabled");
	}

	//Set method to set operators list box values based on field selected
	condField.onchange = function () { SetFilterFieldOperators(fields, operators, condCont, condField, condOp); };
	//Set operators list box values for first condition
	SetFilterFieldOperators(fields, operators, condCont, condField.firstChild, condOp);

	//Scroll to bottom of menu to show controls for new condition
	var applyBtn = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='apply-filter']").get(0);
	applyBtn.scrollIntoView(false);
}

/**
 * Remove controls for adding a search filter condition
 * @param {string} condID : Condition container element ID
 * @param {string} listId : Menu/table ID
 */
function RemoveSearchFilterConditionForm(condID, listId) {
	//Remove controls for adding condition
	var condContainer = document.getElementById(condID);
	condContainer.parentElement.removeChild(condContainer);

	//Remove "OR" display element from before first condition controls
	//Get condition containers
	var conditionGroup = $("#filter_menu_" + listId + " [data-search-filter-elem='condition-group']").get(0);
	var conditionConts = $(conditionGroup).find("[data-search-filter-elem='condition']");
	//If there are no conditions, add 1
	if (conditionConts.length < 1) {
		AddSearchFilterConditionForm(listId, fields, operators);
		return;
	}
	//Disable remove button if there is only one condition
	if (conditionConts.length == 1) {
		var removeBtn = $(conditionConts).find("[data-search-filter-elem='condition-form-remove']").get(0);
		removeBtn.disabled = true;
		removeBtn.classList.add("disabled");
	}
	//Remove "OR" display element
	var sepOr = $(conditionConts).find("[data-search-filter-elem='separator-or']");
	if (sepOr.length > 0) {
		conditionConts.get(0).removeChild(sepOr.get(0));
	}
}

/**
 * Set operators list box values based on field selected
 * @param {object} fields : Dictionary of all fields in this table
 * @param {object} operators : Search filter condition operators
 * @param {DOM object} container : Condition controls container element
 * @param {DOM object} fieldSelect : Field list box element
 * @param {DOM object} operatorSelect : Operator list box element
 */
function SetFilterFieldOperators(fields, operators, container, fieldSelect, operatorSelect) {
	//Clear operator list box
	while (operatorSelect.lastElementChild) {
		operatorSelect.removeChild(operatorSelect.lastElementChild);
	}

	//Field info
	var field = fields[fieldSelect.value];

	//Operator info
	var operatorList = operators[field.Type];

	//Add operators to list box
	for (operator in operatorList) {
		var optOperator = document.createElement("option");
		optOperator.value = operator;
		optOperator.innerHTML = operatorList[operator].Title;
		operatorSelect.appendChild(optOperator);
	}

	//Set method to create controls for values based on operator selected
	operatorSelect.onchange = function () { SetFilterFieldValues(fields, operators, container, fieldSelect, operatorSelect); };
	//Create controls for values of first operator
	SetFilterFieldValues(fields, operators, container, fieldSelect, operatorSelect);
}

/**
 * Create controls for values based on operator selected
 * @param {object} fields : Dictionary of all fields in this table
 * @param {object} operators : Search filter condition operators
 * @param {DOM object} container : Condition controls container element
 * @param {DOM object} fieldSelect : Field list box element
 * @param {DOM object} operatorSelect : Operator list box element
 */
function SetFilterFieldValues(fields, operators, container, fieldSelect, operatorSelect) {
	//Field and operator info
	var field = fields[fieldSelect.value];
	var operator = operators[field.Type][operatorSelect.value];

	//Get value container
	var valueCont = $(container).find("[data-search-filter-elem='value-container']").get(0);

	//Clear any previous controls for values
	while (valueCont.lastElementChild) {
		valueCont.removeChild(valueCont.lastElementChild);
	}

	//Add controls for values based on field and operator type
	for (var x = 0; x < operator.ValueCount; x++) {
		switch (field.Type) {
			case "text":
			case "num":
				var val = document.createElement("input");
				val.type = "text";
				val.setAttribute("data-search-filter-elem", "value");
				if(x == operator.ValueCount - 1)
					val.setAttribute("onkeypress", "SubmitSearchFilterOnEnter(event);");
				val.classList.add("filter-input-value");
				valueCont.appendChild(val);
				break;
			case "date":
				var val = document.createElement("input");
				val.type = "text";
				val.setAttribute("data-search-filter-elem", "value");
				if(x == operator.ValueCount - 1)
					val.setAttribute("onkeypress", "SubmitSearchFilterOnEnter(event);");
				val.classList.add("filter-input-value");
				valueCont.appendChild(val);
				break;
			case "enum":
				var val = document.createElement("select");
				val.setAttribute("data-search-filter-elem", "value");
				var arr = field.Array;

				//Add list box with enumerated values
				for (enumVal in arr) {
					var enumOpt = document.createElement("option");
					enumOpt.value = arr[enumVal];
					enumOpt.innerHTML = arr[enumVal];
					val.appendChild(enumOpt);
				}
				val.classList.add("filter-input-value");
				valueCont.appendChild(val);
				break;
		}
	}
}

/**
 * Get search filter information from controls and add to table search filters
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 */
function AddSearchFilter(listId, searchFilterGroups) {
	//Get condition container elements
	var filterCondForms = $("#filter_menu_" + listId + " [data-search-filter-elem='condition-group'] [data-search-filter-elem='condition']");
	var conditions = [];

	//Iterate condition containers
	for (var x = 0; x < filterCondForms.length; x++) {
		var condElems = filterCondForms[x].children;
		var condField = "";
		var condOperator = "";
		var condValues = [];
		//Iterate condition controls to get field, operator and values
		for (var y = 0; y < condElems.length; y++) {
			var condElem = condElems[y];
			if (!condElem.hasAttribute("data-search-filter-elem"))
				continue;

			var condElemType = condElem.getAttribute("data-search-filter-elem");
			if (condElemType === "field")
				condField = condElem.value;
			if (condElemType === "operator")
				condOperator = condElem.value;
			if (condElemType === "value-container") {
				var valElems = condElem.children;
				for (var z = 0; z < valElems.length; z++) {
					var valElem = valElems[z];
					var condValElemType = valElem.getAttribute("data-search-filter-elem");
					if (condValElemType === "value")
						condValues.push(valElem.value);
				}
			}
		}
		//Add condition to current search filter being created
		var condition = new SearchFilterCondition("", true, condField, condOperator, condValues);
		conditions.push(condition);
	}
	//Add created search filter to table search filters
	searchFilterGroups.push(new SearchFilter("", true, conditions));

	//Update filter menu controls
	UpdateSearchFilterMenu(listId, searchFilterGroups);
	UpdateSearchFilterBoxes(listId, searchFilterGroups);

	//Search with filters
	$('#SearchFilters').val(JSON.stringify(searchFilterGroups));
	window[listId].Search();
}

/**
 * Show/hide controls for creating new search filter
 * @param {string} listId : Menu/table ID
 */
function ToggleSearchFilterForm(listId) {
	var searchForm = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='filter-form']").get(0);

	if (searchForm.classList.contains("show"))
		searchForm.classList.remove("show");
	else
		searchForm.classList.add("show");

	//Create controls for first condition if they don't already exist
	var filterConds = $("#filter_menu_" + listId + " [data-search-filter-elem='condition-group']").get(0);
	if (filterConds.children.length == 0)
		AddSearchFilterConditionForm(listId, fields, operators);
}

/**
 * When opening search filter menu, show/hide controls for creating new search filter if no filters exist already
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 */
function OnOpenFilterMenu(listId, searchFilterGroups) {
	if (searchFilterGroups.length < 1) {
		//var searchForm = document.getElementById(formId);
		var searchForm = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='filter-form']").get(0);
		searchForm.classList.remove("show");
		ToggleSearchFilterForm(listId)
	}
}

/**
 * Clear all condition container elements and hide controls for creating new search filters
 * @param {string} listId : Menu/table ID
 */
function ClearSearchFilterForm(listId) {
	//Get container element of condition container elements
	const search_box_id = 'q' + listId;
	ClearSearchBox(search_box_id);

	var searchForm = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='filter-form']").get(0);
	var condGroup = $(searchForm).find("[data-search-filter-elem='condition-group']").get(0);

	//Clear all condition container elements
	while (condGroup.lastElementChild) {
		condGroup.removeChild(condGroup.lastElementChild);
	}

	//Hide controls for creating new search filter
	searchForm.classList.remove("show");
}

/**
 * Get search filter information from controls and add to table search filters
 * @param {object} event : Event
 */
function SubmitSearchFilterOnEnter(event) {
	event = event || window.event;
	var target = event.target || event.srcElement;
	if (event.code === "Enter") {
		event.preventDefault();
		$(target.parentElement.parentElement.parentElement.parentElement).find("[data-search-filter-menu-elem='apply-filter']").click();
	}
}

/**
 * Update status of filter in table search filters and update search filter menu and controls
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 * @param {object} searchFilterCheck (optional) : Search filter checkbox DOM element
 */
function UpdateSearchFilterStatus(listId, searchFilterGroups, searchFilterCheck) {
	//Update status of filter in table search filters
	if (searchFilterCheck !== undefined) {
		var sfg_index = parseInt(searchFilterCheck.getAttribute("data-sfg_index"));
		var sfc_index = parseInt(searchFilterCheck.getAttribute("data-sfc_index"));
		searchFilterGroups[sfg_index].Conditions[sfc_index].Active = searchFilterCheck.checked;
	}

	//Update search filter menu and controls
	UpdateSearchFilterMenu(listId, searchFilterGroups);
	UpdateSearchFilterBoxes(listId, searchFilterGroups);

	//Search with filters
	$('#SearchFilters').val(JSON.stringify(searchFilterGroups));
	window[listId].Search();
}

/**
 * Remove filter in table search filters and update search filter menu and controls
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 * @param {object} searchFilterButton : Search filter remove button DOM element
 */
function RemoveSearchFilter(listId, searchFilterGroups, searchFilterButton) {
	var sfg_index = parseInt(searchFilterButton.getAttribute("data-sfg_index"));
	//var sfc_index = parseInt(searchFilterButton.getAttribute("data-sfc_index"));
	/*
	//Remove condition
	searchFilterGroups[sfg_index].Conditions.splice(sfc_index, 1);
	//Remove filter if it has no conditions
	if (searchFilterGroups[sfg_index].Conditions.length < 1)
		searchFilterGroups.splice(sfg_index, 1);
	*/
	//Remove filter
	searchFilterGroups.splice(sfg_index, 1);

	//Update search filter menu and controls
	UpdateSearchFilterMenu(listId, searchFilterGroups);
	UpdateSearchFilterBoxes(listId, searchFilterGroups);

	//Search with filters
	$('#SearchFilters').val(JSON.stringify(searchFilterGroups));
	window[listId].Search();
}

/**
 * Update search filter menu
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 */
function UpdateSearchFilterMenu(listId, searchFilterGroups) {
	//Get search filter menu
	var filterListMenu = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='filter-list']")[0];

	//Clear all elements in menu
	while (filterListMenu.lastElementChild) {
		filterListMenu.removeChild(filterListMenu.lastElementChild);
	}

	//Show "Active filters" title if there are active filters
	var searchFilterTitle = $("#filter_menu_" + listId + " [data-search-filter-menu-elem='filter-list-title']").get(0);
	if(searchFilterGroups.length > 0)
		searchFilterTitle.classList.add("show");
	else
		searchFilterTitle.classList.remove("show");

	//Iterate table search filters and create elements in menu
	for (var sfg_index in searchFilterGroups) {
		var sfg = searchFilterGroups[sfg_index];

		//var filterDisplay = "";
		var filterDisplay = document.createElement("div");

		//Use filter name if defined
		if (sfg.Name.length > 0) {
			filterDisplay.innerHTML = sfg.Name;
		}

		//Filter container
		var filterCondCont = document.createElement("div");
		filterCondCont.classList.add("filter-menu-item");

		//Filter separator element
		var hr = document.createElement("div");
		hr.classList.add("dropdown-divider");
		hr.setAttribute("role", "separator");

		//Iterate conditions in search filter
		for (var sfc_index in sfg.Conditions) {
			var sfc = sfg.Conditions[sfc_index];
			//var filterDisplay = "";
			if (sfc_index > 0) {
				//filterDisplay += ", ";
				filterDisplay.innerHTML += " " + quidgestGlobals.Resources.OU11765 + " <br>";
			}
			/*
			//Filter container
			var filterCondCont = document.createElement("div");
			filterCondCont.classList.add("filter-menu-item");
			*/
			//Filter checkbox (stores status)
			/*var filterCondCheck = document.createElement("input");
			filterCondCheck.type = "checkbox";
			filterCondCheck.checked = sfc.Active;
			filterCondCheck.setAttribute("data-sfg_index", sfg_index);
			filterCondCheck.setAttribute("data-sfc_index", sfc_index);

			//Filter display checkbox (for display only)
			var filterCondCheckDisplay = document.createElement("span");
			filterCondCheckDisplay.classList.add("i-checkbox__field");*/

			//Filter label
			var filterIcon = document.createElement("i");
			filterIcon.classList.add("glyphicons");
			filterIcon.classList.add("glyphicons-filter");
			filterIcon.classList.add("filter-title-icon");
			var filterCondLabel = document.createElement("label");
			filterCondLabel.appendChild(filterIcon);
			/*
			//Use filter name if defined
			if (sfc.Name.length > 0) {
				filterDisplay = sfc.Name;
			}
			*/
			//Generate filter name based on field, operator and values
			//else {
				//Add field title and operator title
				filterDisplay.innerHTML += fields[sfc.Field].Title + " " + operators[fields[sfc.Field].Type][sfc.Operator].Title;
				//Add first value based on field and operator type
				if (sfc.Values.length > 0) {
					if (fields[sfc.Field].Type === "enum") {
						if (fields[sfc.Field].Array[sfc.Values[0]] !== undefined)
							filterDisplay.innerHTML += " \"" + fields[sfc.Field].Array[sfc.Values[0]] + "\"";
						else
							filterDisplay.innerHTML += " \"" + sfc.Values[0] + "\"";
					}
					else if (fields[sfc.Field].Type !== "bool") {
						filterDisplay.innerHTML += " \"" + sfc.Values[0] + "\"";
					}
				}
				//Add other values if they exist
				for (var val_index = 1; val_index < sfc.Values.length; val_index++) {
					filterDisplay.innerHTML += " " + quidgestGlobals.Resources.E49900 + " \"" + sfc.Values[val_index] + "\"";
				}
			//}
			//filterCondLabel.classList.add("i-checkbox");
			//filterCondLabel.classList.add("i-checkbox__label");
			filterCondLabel.classList.add("search-filter-menu-label");
			//filterCondLabel.appendChild(filterCondCheck);
			//filterCondLabel.appendChild(filterCondCheckDisplay);

			/*
			//Display search filter title
			var filterDisplayNode = document.createTextNode(filterDisplay);
			filterCondLabel.appendChild(filterDisplayNode);

			//Filter remove button
			var removeIcon = document.createElement("i");
			removeIcon.classList.add("glyphicons");
			removeIcon.classList.add("glyphicons-remove");
			var filterRemoveBtn = document.createElement("button");
			filterRemoveBtn.type = "button";
			filterRemoveBtn.setAttribute("data-sfg_index", sfg_index);
			filterRemoveBtn.setAttribute("data-sfc_index", sfc_index);
			filterRemoveBtn.classList.add("filter-delete-btn");
			filterRemoveBtn.appendChild(removeIcon);
			*/
			//Set method to update filter status when checking or unchecking checkbox
			/*filterCondCheck.onchange = function (event) {
				event = event || window.event;
				var target = event.target || event.srcElement;
				UpdateSearchFilterStatus(listId, searchFilterGroups, target);
			}*/
			/*
			//Set method to remove filter when clicking
			filterRemoveBtn.onclick = function (event) {
				event = event || window.event;
				var target = event.target || event.srcElement;
				var btn = target;
				if (!target.getAttribute("data-sfg_index"))
					btn = target.parentElement;
				RemoveSearchFilter(listId, searchFilterGroups, btn);
			}

			filterCondCont.appendChild(filterIcon);
			filterCondCont.appendChild(filterCondLabel);
			filterCondCont.appendChild(filterRemoveBtn);
			filterListMenu.appendChild(filterCondCont);
			*/
		}

		//Display search filter title
		//var filterDisplayNode = document.createTextNode(filterDisplay);
		//filterCondLabel.appendChild(filterDisplayNode);
		filterCondLabel.appendChild(filterDisplay);

		//Filter remove button
		var removeIcon = document.createElement("i");
		removeIcon.classList.add("glyphicons");
		removeIcon.classList.add("glyphicons-remove");
		var filterRemoveBtn = document.createElement("button");
		filterRemoveBtn.type = "button";
		filterRemoveBtn.setAttribute("data-sfg_index", sfg_index);
		//filterRemoveBtn.setAttribute("data-sfc_index", sfc_index);
		filterRemoveBtn.classList.add("filter-delete-btn");
		filterRemoveBtn.appendChild(removeIcon);

		//Set method to remove filter when clicking
		filterRemoveBtn.onclick = function (event) {
			event = event || window.event;
			var target = event.target || event.srcElement;
			var btn = target;
			if (!target.getAttribute("data-sfg_index"))
				btn = target.parentElement;
			RemoveSearchFilter(listId, searchFilterGroups, btn);
		}

		//filterCondCont.appendChild(filterIcon);
		filterCondCont.appendChild(filterCondLabel);
		filterCondCont.appendChild(filterRemoveBtn);
		filterListMenu.appendChild(filterCondCont);

		//Add separator after each filter
		filterListMenu.appendChild(hr);
	}
}

/**
 * Update search filter display box controls
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 */
 function UpdateSearchFilterBoxes(listId, searchFilterGroups) {
	//Get search filter display element
	var filterBoxList = $("#" + listId + "_simple_filter [data-search-filter-menu-elem='filter-box-list']")[0];
	var filterButton = $('#filter_menu_' + listId + ' button')[0];

	const badge = document.createElement("span")
	badge.classList.add("e-badge")
	badge.classList.add("e-badge--danger")

	//Set to display only when there are active filters
	if (CountActiveConditions(searchFilterGroups) > 0) {
		if (filterBoxList.children.length == 0){
			const span = document.createElement("span")
			span.setAttribute("aria-hidden", true)
			badge.appendChild(span);
			filterButton.appendChild(badge);
		}
	}
	else if (filterButton.lastChild) {
		filterButton.removeChild(filterButton.lastChild)
	}
}

/**
 * Get number of filters set to active
 * @param {object} searchFilterGroups : Search filters
 */
function CountActiveConditions(searchFilterGroups) {
	var total = 0;

	//Iterate search filters
	for (var sfg_index in searchFilterGroups) {
		var sfg = searchFilterGroups[sfg_index];

		//Iterate conditions
		for (var sfc_index in sfg.Conditions) {
			var sfc = sfg.Conditions[sfc_index];

			if (sfc.Active)
				total++;
		}
	}
	return total;
}

/**
 * Set all search filters to inactive
 * @param {string} listId : Menu/table ID
 * @param {object} searchFilterGroups : Search filters
 */
function DeactivateAllSearchFilters(listId, searchFilterGroups) {
	for (var sfg_index in searchFilterGroups) {
		var sfg = searchFilterGroups[sfg_index];

		for (var sfc_index in sfg.Conditions) {
			var sfc = sfg.Conditions[sfc_index];

			sfc.Active = false;
		}
	}

	UpdateSearchFilterMenu(listId, searchFilterGroups);
	UpdateSearchFilterBoxes(listId, searchFilterGroups);
}

function RemoveAllSearchFilters() {
	const filtersRow = '.filtersRow';
	const EnumContainer = '.chzn-single';
	const filtersRowInputs = $(filtersRow).children().children().not('div.c-action-bar.b-btn-group.d-flex'); //Ignores CRUD buttons

	//Clears the values from normal input boxes
	filtersRowInputs.each(function () {
		this.value = null;
	})

	// Clears the values from date filters if it exists in the list
	if ($(filtersRow + ' th').hasClass('filter-date-cell')) {
		$(".i-input-group.input-medium.i-date-picker.date").datetimepicker('clear');
	}

	//Clears the values from enum filters if it exists in the list
	if ($(filtersRow + ' th ').find(EnumContainer).length) {
		const EnumDefaultValue = $('.i-select.chosen-dropdown.chzn-done option')[0].innerHTML;
		$(EnumContainer).each(function () {
			var EnumSelector = '.' + $(this).attr('class') + ' span';
			$(EnumSelector)[0].innerText = EnumDefaultValue;
		});
	}

}

function ClearSearchBox(search_box_id){
	const SearchBox = $('#'+search_box_id);

	if (SearchBox.val().length > 0) {
		SearchBox.val(null);
	}
}

function ToggleSearchFilterBox(listID) {
	const search_box_id = 'q'+listID;
	const ClearBtnID = $('#'+search_box_id+'-clearBtn');

	// Toggles the clear Button
	$(ClearBtnID).removeClass('d-none');

	//Hides the Clear Button when Search bar has no focus
	$('#'+search_box_id).on('focusout',function (){
		$(ClearBtnID).addClass('d-none');

		return;
	})
}

function RegisterClearEvents(listID) {
	const search_box_id = 'q' + listID;
	const ClearBtnID = $('#' + search_box_id + '-clearBtn');

	//Clears the search when X button is clicked
	$(ClearBtnID).mousedown(function () {
		ClearSearchBox(search_box_id);

		RemoveAllSearchFilters();
		window[listID].Search();

		//Clears the dropdown items text when button is clicked
		$('a.dropdown-item strong').each(function () {
			this.innerHTML = null;
		})
	})


	//Clears search when the dropdown items get clicked
	$('a.dropdown-item').click(function () {
		$('a.dropdown-item strong').each(function () {
			this.innerHTML = null;
		})
	})

}


//---------------------------------------------------------------------------------------
// Wizard functions
//---------------------------------------------------------------------------------------

/**
 * Dynamically loads the content of the given step.
 * @param {object} step The step of which the content will be loaded
 * @param {function} callback A function to be called after the ajax request completes (optional)
 * @param {number} tries The number of times we tried to load the content of the step (optional)
 */
function loadWizardStep(step, callback, tries)
{
	// If an error occurs while trying to load the content of a step, we try to load it again
	// until we reach the number of max tries.
	var maxTries = 5;
	var triesCount = 0;
	if (typeof tries === 'number')
		triesCount = tries + 1;
	var wizard = step.closest('div.wizard-area');
	var wizardName = wizard.attr('q-wizard');
	var formName = wizard.attr('q-form');
	var url = window['Form_' + formName].UrlAction[wizardName].ContentLink;
	var stepView = step.attr('q-form');
	var data = { 'wizardStepView': stepView };

	$.ajax({
		url: url,
		data: data,
		type: 'GET',
		contentType: 'text/html',
		success: function(content)
		{
			// If everything went ok, the content should be the html of the step and it's type should be 'string'.
			// On the other hand, if a server side error occurs, the content will be a json object.
			if (typeof content === 'object' && !content.Success)
			{
				if (triesCount >= maxTries)
				{
					if (typeof callback == 'function')
						callback(content.Message);
					console.log(content.Message);
				}
				else
					loadWizardStep(step, callback, triesCount);
			}
			else
			{
				// Checks if the step should be loaded/reloaded.
				if (step.attr('step-loaded') != 'true')
				{
					let form = window['Form_' + stepView];

					// If the form isn't undefined, it means the content of the step is already loaded and we want to force it's reload.
					if (form !== undefined)
					{
						delete window['Form_' + stepView];
						form.ReplaceHTML(content);
					}
					else
						step.html(content);
					step.attr('step-loaded', true);
				}
				if (typeof callback == 'function')
					callback();
			}
		},
		error: function(jqXhr, status, error)
		{
			if (triesCount >= maxTries)
			{
				let errorInfo = 'Status: ' + status + '\nError: ' + error + '\nResponse: ' + jqXhr.responseText;
				if (typeof callback == 'function')
					callback(errorInfo);
				console.log(errorInfo);
			}
			else
				loadWizardStep(step, callback, triesCount);
		}
	});
}

/**
 * Gets the id of the next step, from the server, and calls the callback function with that value as a parameter.
 * @param {object} wizard The wizard
 * @param {string} stepId The id of the current step
 * @param {function} callback The function to be called after the ajax request completes
 */
function getNextStep(wizard, stepId, callback)
{
	var step = $('#' + stepId);
	var stepFormName = step.attr('q-form');
	var stepForm = window['Form_' + stepFormName];
	var wizardName = wizard.attr('q-wizard');
	var formName = wizard.attr('q-form');
	var url = window['Form_' + formName].UrlAction[wizardName].ForwardLink;
	if (stepId == null)
		stepId = '';
	var primaryKey = wizard.attr('q-record-id');
	var formGuid = $('#' + primaryKey).val();
	var data = { 'formId': formGuid, 'currentStep': stepId };

	$.ajax({
		url: url,
		data: data,
		type: 'GET',
		dataType: 'json',
		contentType: 'application/json',
		success: function(result)
		{
			// The synching of the form keys needs to happen after the path is calculated server-side, but before the loadWizardStep() is called.
			$.when(syncFormKeys(stepForm.element)).done(function()
			{
				if (result.Success)
					callback(result.StepId, true);
				else
				{
					callback(result.Message, false);
					console.log(result.Message);
				}
			});
		},
		error: function(jqXhr, status, error)
		{
			var errorInfo = 'Status: ' + status + '\nError: ' + error + '\nResponse: ' + jqXhr.responseText;
			callback(errorInfo, false);
			console.log(errorInfo);
		}
	});
}

/**
 * Gets the current progress of the wizard.
 * @param {object} wizard The wizard
 * @param {function} callback The function to be called after the ajax request completes
 */
function getWizardState(wizard, callback)
{
	var wizardName = wizard.attr('q-wizard');
	var formName = wizard.attr('q-form');
	var primaryKey = wizard.attr('q-record-id');
	var formGuid = $('#' + primaryKey).val();
	var url = window['Form_' + formName].UrlAction[wizardName].PathLink;
	var data = { 'formId': formGuid };

	$.ajax({
		url: url,
		data: data,
		type: 'GET',
		dataType: 'json',
		contentType: 'application/json',
		success: function(result)
		{
			if (result.Success)
				callback(result.Path, true);
			else
			{
				callback(result.Message, false);
				console.log(result.Message);
			}
		},
		error: function(jqXhr, status, error)
		{
			var errorInfo = 'Status: ' + status + '\nError: ' + error + '\nResponse: ' + jqXhr.responseText;
			callback(errorInfo, false);
			console.log(errorInfo);
		}
	});
}

/**
 * Saves the current progress of the wizard.
 * @param {object} wizard The wizard
 * @param {string} stepId The id of the current step
 * @param {function} callback The function to be called after the ajax request completes (optional)
 * @param {boolean} isGoingBack True if the user is going to the previous step, false otherwise (optional)
 * @param {boolean} clearData True if the current data should be cleared, false otherwise (optional)
 */
function saveWizardState(wizard, stepId, callback, isGoingBack, clearData)
{
	var step = $('#' + stepId);
	var stepFormName = step.attr('q-form');
	var stepForm = window['Form_' + stepFormName];
	var wizardName = wizard.attr('q-wizard');
	var formName = wizard.attr('q-form');
	var wizardForm = window['Form_' + formName];
	var url = wizardForm.UrlAction[wizardName][stepFormName + 'SaveLink'];
	var formData = getInputsForNestedForm($(stepForm.element));
	if (typeof isGoingBack !== 'boolean')
		isGoingBack = false;
	if (typeof clearData !== 'boolean')
		clearData = false;
	if (isGoingBack)
	{
		url += url.indexOf('?') == -1 ? '?' : '&';
		url += 'isGoingBack=true';
	}
	if (clearData)
	{
		url += url.indexOf('?') == -1 ? '?' : '&';
		url += 'clearData=true';
	}

	$.ajax({
		url: url,
		data: $.param(formData),
		type: 'POST',
		success: function(result)
		{
			if (result.Success)
			{
				if (typeof callback == 'function')
					callback(result.Message, true);
			}
			else
			{
				if (typeof callback == 'function')
					callback(result.Message, false, result.View);
				console.log(result.Message);
			}
		},
		error: function(jqXhr, status, error)
		{
			var errorInfo = 'Status: ' + status + '\nError: ' + error + '\nResponse: ' + jqXhr.responseText;
			if (typeof callback == 'function')
				callback(errorInfo, false);
			console.log(errorInfo);
		}
	});
}

/**
 * Toggle sticky header on onscroll (only for form).
 */
/**
 * Toggle sticky header on onscroll (only for form).
 */
 function ToggleStickyHeader(header, threshold_el, breadcrumbs)
 {
	 var topSide = $('nav').first().outerHeight();
	 var threshold = threshold_el.outerHeight();
	 //The layout variable containerWidth changes the formContainer class to "container"
	 var hasContainerFluid = $("#formContainer").hasClass('container-fluid')

	 //For vertical layout when there is no breadcrumbs the default threshold doesn't work
	 if (threshold_el.hasClass('main-header') && breadcrumbs == null) {
		 threshold = header.offset().top - topSide;
	 }

	 // Below the top of the page
	 if (window.scrollY >= threshold)
	 {
		 //In case containerWidth = "reduced" we don't want to stick the header
		 if (hasContainerFluid) {
			 header.addClass('sticky-top');
			 header.css('top', topSide);
		 }

		 if (breadcrumbs) {
			 breadcrumbs.css('visibility', 'hidden'); // breadcrumbs.hide();
		 }
	 }
	 // At the top of the page
	 else
	 {
		 header.removeClass('sticky-top');
		 header.css('top', '');
		 if(breadcrumbs){
			 breadcrumbs.css('visibility', 'visible'); // breadcrumbs.show();
		 };
	 }
 }

function sidebarPositioning() {
	var topSide = $('#header-container').outerHeight() - $(window).scrollTop();
	if ($('nav').first().hasClass('fixed-header'))
		topSide = $('nav').first().outerHeight();

	$('#mySidenav').css('top', topSide);
}

/**
 * Toggle sticky header on onscroll (only for menus).
 */
/**
 * Toggle sticky header on onscroll (only for menus).
 */
 function ToggleMenuStickyHeader(nav, header, breadcrumbs, threshold_el) {
	var phs = "page-head-scrolled";
	var topSide = $('nav').first().outerHeight();
	var threshold = threshold_el.hasClass('main-header') ? header.offset().top - topSide : threshold_el.height();
	var stickyCondition = threshold_el.hasClass('main-header') ? threshold : threshold + 35;
	//The layout variable containerWidth changes the formContainer class to "container"
	var hasContainerFluid = $("#formContainer").hasClass('container-fluid')


	if (window.scrollY >= threshold) {
		nav.classList.add('fixed-header');
		breadcrumbs.addClass('breadcrumbs-scrolled');
		$('.c-rightSidebar').css('top', topSide);


	} else {
		nav.classList.remove('fixed-header');
		breadcrumbs.removeClass('breadcrumbs-scrolled');

	}

	if (window.scrollY >= stickyCondition && hasContainerFluid) {
		header.addClass(phs);
		header.css('top', topSide);
	} else {
		header.removeClass(phs);
		header.css('top', '');

	}
}

/*Cookie banner*/
class QCookieConsent {
	constructor(message, filePath) {
		this.modalId = "QCookieConsent";
		this.storageName = "isCookieAccepted";
		this.filePath = filePath;
		this.message = message;
	}


	getData() {
		/*
		* Resource String Politica de Cookies:
		* quidgestGlobals.Resources.POLITICA_DE_COOKIES37385
		*/

		var returnValue = '<a href="' + this.filePath + '" target="blank">' + this.message + '</a>';

		returnValue += `<button type="button" id="bntCookie" class="b-icon-text b-icon-text--primary b-icon-text--login" onclick="window.cookieManager.hide()">`
		returnValue += quidgestGlobals.Resources.TOMEI_CONHECIMENTO;
		returnValue += `</button>`;

		return returnValue;

	}
	/**
	 * Shows the Cookie banner
	 */
	show() {
		this.modal = document.getElementById(this.modalId)
		if (!self.modal) {
			self.modal = document.createElement("div")
			self.modal.id = this.modalId
			self.modal.setAttribute("class", "q-cookie-banner alert alert-dark text-center mb-0")
			self.modal.setAttribute("role", "alert")
			//self.modal.style.color = "#fff";
			self.modal.innerHTML = this.getData();
			self.modal.style.display = "block";
			document.body.append(self.modal)
		}
	}

	/**
	 * Hides the Cookie footer and saves the value to localstorage
	 */
	hide() {
		localStorage.setItem(this.storageName, true);
		var cookieBanner = document.getElementsByClassName("q-cookie-banner")[0];
		cookieBanner.style.display = "none";
	}
	/**
	 * Checks the localstorage and shows Cookie footer based on it.
	 */
	initialize() {
		var isCookieAccepted = new Boolean(localStorage.getItem(this.storageName));
		if (isCookieAccepted != true) {
			this.show();
		}
	}
}

const MessageDefs = {
	ButtonTypes: {
		Info: "Info",
		Danger: "Danger",
		Success: "Success",
		Primary: "Primary",
		Secondary: "Secondary"
	},
	StatusEnum: {
		OK: "OK",
		E: "E",
		W: "W",
		Q: "Q",
		I: "I",
	}
}

// function to display a message in a modal each is dismassable by clicking in the background.
// Message - mandatory and corresponds to the text displayed in the modal body.
// Status - optional and used to display an icon in the header section of the modal.
// Icons are loaded by default for all status in the array but can replaced/extended to new statuses if the naming format, DIALOG_statusName.png is respected and file placed in content/img.
// If the supplied status does not have an associated icon it will print an error in the console and will not display anything on the resulting modal.
// title - optional and its string value will be displayed along with the title icon in the header section.
// buttons - optional parameter that defines the buttons that should appear on the modal. If not defined (undefined) it will default to a single button with the OK label and no callback
// each button object is structured with label, style, callback and icon where only the label is mandatory. The default style is the Primary style. The icon is the glyphicons class. In ".glyphicons .glyphicons-check" only "check" should be passed.
// options - extension variable to be able to behavior without having to change the functions signature in the future.
//	onEscapeCallback which associates a specific (pass a function) or a callback on a button (pass a integer) when closing the modal.
//  timeout - pass an valid value to timeout and the modal will close after it elapses. This does not trigger the onEscape callback.
//  inputs - replaces message with title, ignores title. inputs are array of objects defined with the members type and name
//  imgWidth - allows the user to set a width for the image (ex: "12px")
//	imgHeight - allows the user to set a height for the image (ex: "12px")
//	imgAllign - sets the allignment of the image ("center", "left", "right")
function displayMessage(message, status, title, buttons, options) {
	if (buttons === undefined) {
		buttons = [{ label: "OK", style: MessageDefs.ButtonTypes.Primary, icon: "check" }];
	}

	if (message === undefined) {
		window.console.error("displayMessage called with missing message");
		return;
	}

	var modalFrameworkButtons = convertGenericButtonsToModalFramework(buttons);
	var inputsFrameworkButtons;
	if (options && options.inputs) {
		inputsFrameworkButtons = convertGenericInputsToModalFramework(options.inputs);
	}

	//from this point forward, depends on the underlaying framework
	var onEscape = true;
	if (options && options.hasOwnProperty('onEscapeCallback')) {
		if (typeof (options.onEscapeCallback) == "function") {
			onEscape = options.onEscapeCallback;
		} else if (options.onEscapeCallback < buttons.length && typeof (buttons[options.onEscapeCallback].callback) == "function") {
			onEscape = buttons[options.onEscapeCallback].callback;
		}
	}

	var timeout = undefined;
	if (options && options.hasOwnProperty("timeout")) {
		timeout = options.timeout;
	}

	var titleSec = "";
	if (status && status != "") {
		var imgURL = quidgestGlobals.UrlAction.ContentFolder + "/img/DIALOG_" + status + ".svg";
		$.when(LoadSvgContent(imgURL))
			.then(function (data) {
				if (options && options.imgAllign && options.imgAllign.toLowerCase() == 'left')
					var svgCont = '<svg style="margin: 0 0;' + ((options && options.imgWidth) ? 'width:' + options.imgWidth + ';' : '') + ((options && options.imgHeight) ? 'height:' + options.imgHeight + ';' : '') +
						'" class="c-message--' + status + '" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 26 26" xml:space="preserve">';
				else if (options && options.imgAllign && options.imgAllign.toLowerCase() == 'right')
					var svgCont = '<svg style="' + ((options && options.imgWidth) ? 'width:' + options.imgWidth + ';' : '') + ((options && options.imgHeight) ? 'height:' + options.imgHeight + ';' : '')
						+ '" class="c-message--' + status + '" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 26 26" xml:space="preserve">';
				else
					var svgCont = '<svg style="' + ((options && options.imgWidth) ? 'width:' + options.imgWidth + ';' : '') + ((options && options.imgHeight) ? 'height:' + options.imgHeight + ';' : '')
						+ '" class="c-message--' + status + '" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 26 26" xml:space="preserve">';

				svgCont += data;
				svgCont += '</svg>';
				titleSec = svgCont;
				generateModal(message, titleSec, modalFrameworkButtons, onEscape, timeout, inputsFrameworkButtons);
			})
			.catch(() => {
				window.console.error("Status " + status + " does not have a corresponding icon.");
				generateModal(message, titleSec, modalFrameworkButtons, onEscape, timeout, inputsFrameworkButtons);
			});
	} else {
		generateModal(message, "", modalFrameworkButtons, onEscape, timeout, inputsFrameworkButtons);
	}

	return "DisplayMessage executed successfully";

	function generateModal(message, titleSec, modalFrameworkButtons, onEscapeCallback, timeout, inputs) {
		var structure;
		if (inputs) {
			structure =
			{
				message: message + inputs,
				onEscape: onEscapeCallback,
				backdrop: true,
				buttons: modalFrameworkButtons,
				title: titleSec
			}
		} else {
			structure =
			{
				message,
				onEscape: onEscapeCallback,
				backdrop: true,
				buttons: modalFrameworkButtons,
				title: titleSec
			}
		}

		if (title !== undefined) {
			structure["title"] += "<span class='c-table__title'>" + title + "</span>";;
		}

		var diag = bootbox.dialog(structure);
		if (timeout) {
			setTimeout(() => diag.modal('hide'), timeout)
		}
	}

	function convertGenericInputsToModalFramework(inputs) {
		var content = "<form class=\"bootbox-form\">";
		for (var i = 0; i < inputs.length; i++) {
			var currInput = inputs[i];
			var typefield = "input";
			var rows = 3;
			var fieldText = "";
			var callback;
			var classToUse = "bootbox-input form-control ";

			if (currInput.class != null)
				classToUse = currInput.class;

			if (currInput.type == "text") {
				if (currInput.class == null)
					classToUse += "bootbox-input-text";
			}

			if (currInput.typefield == "textarea" && currInput.class == null)
				classToUse = "i-textarea__field i-textarea";

			if (currInput.rows != null)
				rows = "\" rows=\""+ currInput.rows +"\"";

			if (currInput.typefield != null)
				typefield = currInput.typefield;

			if (currInput.textfield != null)
				fieldText = currInput.textfield;

			if (currInput.callback != null)
				callback = "onclick=\"" + currInput.callback + "\"";

			content += "<" + typefield + " class=\"" + classToUse + "\" id = \"" + currInput.name + "\" " + rows + " name=\"" + currInput.name + "\" autocomplete=\"off\" type=\"" + currInput.type + "\" " + callback + ">" + fieldText +"\</" + typefield + ">";
		}
		content += "</form>";
		return content;
	}

	function convertGenericButtonsToModalFramework(buttons) {
		var buttonStyles = {
			Info: "b-icon-text btn-info",
			Success: "b-icon-text btn-success",
			Danger: "b-icon-text btn-danger",
			Primary: "b-icon-text b-icon-text--primary",
			Secondary: "b-icon-text b-icon-text--secondary"
		}
		var frameworkButtons = {};
		buttons.forEach(function (buttonDef) {
			if (!(buttonDef.label in frameworkButtons)) {
				var currentDef = {};
				currentDef["label"] = buttonDef.label
				if (buttonDef.style !== undefined) {
					if (buttonDef.style in buttonStyles) {
						currentDef["className"] = buttonStyles[buttonDef.style]
					} else {
						currentDef["className"] = buttonDef.style;
					}

				} else {
					currentDef["className"] = buttonStyles.Primary;
				}

				if (buttonDef.callback !== undefined) {
					currentDef["callback"] = buttonDef.callback;
				}

				if (buttonDef.icon !== undefined) {
					var iconDef = "<i class=\"glyphicons glyphicons-" + buttonDef.icon + " e-icon\"></i>";
					currentDef["label"] = iconDef + currentDef["label"];
				}

				frameworkButtons[buttonDef.label] = currentDef;
			}
		})
		return frameworkButtons;
	}
}

function LoadSvgContent(imgURL) {
	return fetch(imgURL)
		.then(response => {
			if (response.ok) {
				return response.text();
			}
			return Promise.reject("Error loading SVG");
			//throw new Error('An error occurred');
		})
		.then((data) => {
			var parser = new DOMParser();
			var xmlDoc = parser.parseFromString(data, "image/svg+xml");
			return xmlDoc.firstElementChild.innerHTML;
		})
		.catch((error)=> {
			console.log(error);
		});
}

//Observers if the height of the header as changed so the advanced search row always sticks to the header
function StickAdvancedSearch() {
	const tableHeader = document.getElementById('TableHeader');

	if (tableHeader)
	{
		const resizeObserver = new ResizeObserver(entries => {
			height = entries[0].target.clientHeight;
			$('.filtersRow').css({
				top: height,
				'transform': 'translateY(-3px)'
			});
		});

		resizeObserver.observe(tableHeader);
	}
}

//Highlights the header that as an active filter in lists
function SetActiveFilters(listID, area, filterValues) {
	area = CapFirst(area)
	for (var filter in filterValues) {
		const headerFilter = area + '_' + listID + '_' + filter;
		$('[data-filter="' + headerFilter + '"]').addClass('filtersRow__active');
	}
}

//Used so row order can be done via keyboard aswell
function swapInputvalues(input1, input2) {
	const originalValue = $(input1).val();

	if ($(input1).val() != $(input2).val()) {
		$(input1).val($(input2).val()).change(); //calls the change event so the request is sent
		$(input2).val(originalValue).change();
	}
}
