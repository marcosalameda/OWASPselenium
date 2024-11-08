function QMsq() {
    this.displayMsqInfo = false;
    this.GetMsqInfoInterval = null;

    this.SendMsqUpdate_URL = "";
    this.GetMsqInfo_URL = "";

    this.refreshInterval = 15000;
    this.GetMsqInfoInterval = null;

    this.msqInfoDiv = null;
    this.msqButton = null;

    this.levels = {
        "initial": 	{"level":"information", 	"icon": "clock", 		"string": quidgestGlobals.Resources.A_INTEGRACAO_DO_REGI35852 },		
        "waiting": { "level": "pending", "icon": "clock", 		"string": quidgestGlobals.Resources.A_INTEGRACAO_DO_REGI39557 },
        "ok": 		{"level":"success",	"icon": "ok", 			"string": quidgestGlobals.Resources.A_INTEGRACAO_DO_REGI54486 },
        "fail": 	{"level":"error", 	"icon": "warning-sign", "string": quidgestGlobals.Resources.INTEGRACAO_DO_REGISTOFALH },
        "fail_wait": { "level": "error", "icon": "warning-sign", "string": quidgestGlobals.Resources.OCORREU_UM_ERRO_NA_I55842},
        "empty": 	{"level":"information", 	"icon": "question-sign","string": quidgestGlobals.Resources.INTEGRACAO_VAZIA },
		"expired": 	{"level":"error", 	"icon": "warning-sign", "string": quidgestGlobals.Resources.INTEGRACAO_DO_REGIST35481},
    }
}

QMsq.prototype.Init = function (Qform) {
    this.Form = Qform;

    if (this.displayMsqInfo) {

        var actions = $(this.Form.element).find('[elem-identifier="FormActions"]');
        if ($(this.Form.element).closest('#form-modal').length === 1)
            actions = $(this.Form.element).find('[elem-identifier="Actions"]');
            
        var html = "";

        html += '<div elem-identifier="AccordionGroup" class="c-accordion">';
        html += '   <div class="c-accordion__panel">';
        html += '       <div elem-identifier="AccordionHeading" id="mqstatusheader" class="" > <a class="b-btn b-btn--link c-accordion__panel-title" data-toggle="collapse" data-target="#MsqContainer"><i class="glyphicons glyphicons-plus-sign c-accordion__panel-icon float-right"></i><span id="msqGlobalStatus" class=""></span></a></div > ';
        html += '       <div id="MsqContainer" elem-identifier="AccordionBody" class="collapse" style="height: 0px;"><div class="c-accordion__panel-body" elem-identifier="AccordionInner">';
        html += '           <table class="c-table c-table--sm"><tbody id="MsqFillInfo"></tbody></table>';
        html += '           <a id="MsqSendUpdate" href="javascript:;" class="b-icon-text b-icon-text--primary">' + quidgestGlobals.Resources.REENVIAR_FICHA_PARA_20173 + '</a> ';
        html += '       </div></div>';
        html += '   </div>';
        html += '</div>';

        actions.after(html);
        var _target = $(actions).parent();
        AccordionIconToggle(_target);

        this.msqButton = $(this.Form.element).find('#MsqSendUpdate');
        this.msqInfoDiv = $(this.Form.element).find('#MsqFillInfo');
        this.globalStatus = $(this.Form.element).find('#msqGlobalStatus');
        this.msqStausheader = $(this.Form.element).find('#mqstatusheader');

        this.DisableButton();
        this.FillmsqInfo();
    }
};

QMsq.prototype.EnableButton = function () {
    this.msqButton.attr('disabled', false);
    this.msqButton.off().click(this.ResendMsq.bind(this));
};
QMsq.prototype.DisableButton = function () {
    this.msqButton.attr('disabled', true);
    this.msqButton.off();
};

QMsq.prototype.StopLoop = function () {
    //check if loop is running
    if (this.GetMsqInfoInterval != null) {
        clearInterval(this.GetMsqInfoInterval);
        this.GetMsqInfoInterval = null;
    }

};

QMsq.prototype.StartLoop = function () {
    this.GetMsqInfoInterval = setInterval(function () {
        //refesh msqInfo
        this.FillmsqInfo();
    }.bind(this), this.refreshInterval); // seconds to get  integration result  
};

QMsq.prototype.ResendMsq = function () {

    if (this.displayMsqInfo) {

        this.StopLoop();
        //disable button after click
        this.DisableButton();

        $.ajax({
            url: this.SendMsqUpdate_URL,
            cache: false,
            type: "GET",
            dataType: "json",
            success: function (data) {
                bootbox.alert(data.Message);
                this.StartLoop();
            }.bind(this)
        });
    }
};

QMsq.prototype.FillmsqInfo = function () {

    if (this.displayMsqInfo) {
        $.ajax({
            url: this.GetMsqInfo_URL,
            cache: false,
            type: "GET",
            dataType: "json",
            success: function (data) {
                if (data.Success == true) {
                    var infos = data.infos;
                    //Grouping by by QueueID
                    var Queues = {};
                    for (var i = 0, len = infos.length; i < len; i++) {
                        var info = infos[i];
                        if (Queues.hasOwnProperty(info.QueueID)) {
                            Queues[info.QueueID].push(info);
                        } else {
                            Queues[info.QueueID] = [info];
                        }
                    }
                    this.displayMsqInfos(Queues, this.msqInfoDiv);
                    this.SetGeneralStatus(Queues);
                };
            }.bind(this)
        });
    }
};

QMsq.prototype.SetGeneralStatus = function (Queues) {

    var completeOK = true;
    var waitingForIntegration = false;
    var level = this.levels.empty;
    this.DisableButton();

    //No info on MQQueues tables, maybe check on history?
    if (jQuery.isEmptyObject(Queues)) {
        level = this.levels.empty;
        this.EnableButton();
    } else {
        for (var Queue in Queues) {
            var infos = Queues[Queue];
            //Single Line Shown the Last one
            var info = infos[infos.length - 1];

            //Check if still in initial state
            if (info.MQStatus == 0) {
                level = this.levels.initial;
                this.DisableButton();
                break;
            }
            //Check if still waiting to finish
            if (info.MQStatus == 1 || info.MQStatus == 2 || info.MQStatus == 5) {
                level = this.levels.waiting;
                this.DisableButton();
                break;
            }
            //Check if any error occurred
            if (info.MQStatus == 4) {
                level = this.levels.fail;
                this.EnableButton();
                break;
            }
            //Check if ALL are ok
            if (info.MQStatus == 3 || info.MQStatus == 6 || info.MQStatus == 7) {
                level = this.levels.ok;
                this.EnableButton();
            }
        };
    }

    //Still no better way for this ?
    if (level == this.levels.ok) {
        this.EnableButton();
    }

    this.globalStatus.html('<span class="glyphicons glyphicons-' + level.icon + '" style="font-size: 1.25rem;color: #fff; margin-right: 0.5rem; padding-top: 0.27rem;"></span> ' + level.string);    
    this.msqStausheader.attr('class', "c-accordion__panel-header c-card--"+level.level);

};

QMsq.prototype.displayMsqInfos = function (Queues, element) {
    //check for infos
    if (Queues.length <= 0) {
        return;
    }
    //check if element exists
    if ($(element).length <= 0) {
        return;
    }
    //$(element).addClass('zone-field');

    element.html("");


    //Rendering the infos
    for (var Queue in Queues) {
        if (Queues.hasOwnProperty(Queue)) {

            var infos = Queues[Queue];
            //Single Line Shown the Last one
            var info = infos[infos.length - 1];

            var alertLevel = this.levels.initial;
            var html = '<tr data-QueueID="{1}" class="c-table__row--{2}"><td><i class="icon-{6}"></i></td><td>{1}</td><td>{5}</td><td>{3}</td><td>{4}</td></tr>';

            switch (info.MQStatus) {
                case 0:
                    alertLevel = this.levels.initial;
                    break;
                case 1:
                    alertLevel = this.levels.waiting;
                    break;
                case 2:
                    alertLevel = this.levels.expired;
                    break;
                case 4:
                    alertLevel = this.levels.fail;
                    break;
                case 5:
                    alertLevel = this.levels.fail_wait;
                    break;
                case 3:
                case 6:
                case 7:
                    alertLevel = this.levels.ok;
            }
            if (info.Resposta.length > 0) {
                info.Resposta += ' Msg: ' + info.Resposta;
            }
            html = html.replace('{1}', info.QueueID).replace('{1}', info.QueueID)
            html = html.replace('{2}', alertLevel.level)
            html = html.replace('{3}', alertLevel.string)
            html = html.replace('{4}', info.Resposta)
            html = html.replace('{5}', info.DataStatus)
            html = html.replace('{6}', alertLevel.icon)

            /* Commented for now, in the future it may have a button to show the full list, need to be checked if necessary
            //Multiple line shown
            var html = '<table class="table table-condensed" style="display:none">';
            html += '<thead><td>#</td><td>Status</td><td>Msg</td></thead>';
            html += '<tbody>';
            for (var i = 0, len = infos.length; i < len; i++) {
                var info = infos[i];
                html += '<tr><td>' + i + '</td><td>' + info.MQStatus + '</td><td>' + info.Resposta + '</td></tr>';
            }
            html += '</tbody>';
            html += '</table>';
            */
            $(element).append(html);
        }
    }
}