// Aux Methods
function GetFlash(id) {
    var object = document.getElementById(id);
    if (object.attachEvent) // aka older IE's
        return object;
    else
        return document.embeds[id];
}

function initializeFlash(controlId, flashId, flashType, key, link) {
    var BrowserName = navigator.appName.toUpperCase();
    var movieObj = GetFlash(flashId);
    var flashObj = CreateFlashObject(controlId, flashId, flashType, key, link, movieObj);
    movieObj.UsedFlash = flashObj;
    if (movieObj.attachEvent) {
        // aka older IE's 
        eval("F" + flashId + " = function(cmd, args) { movieObj.UsedFlash.FlashEvent(cmd, args); }");
        movieObj.attachEvent('FSCommand', eval("F" + flashId));
    }
    else
        eval(flashId + "_DoFSCommand = function(cmd, args) { movieObj.UsedFlash.FlashEvent(cmd, args); }");
    // IE 11 still not supported
    return flashObj;
}

function CreateFlashObject(controlId, flashId, flashType, key, link, flashObj) {
    return new GenericFlash(controlId, flashId, flashType, key, link, flashObj);
}

// Flash classes
function GenericFlash(flashId, control, type, key, link, flashObj) {
    this.FlashId = flashId;
    this.Key = key;
    this.Type = type;
    this.Control = control;
    this.Link = link;
    this.FlashObject = flashObj;
    this.FlashType = "AS2";
}

GenericFlash.prototype.TestFlashType = function () {
    try {
        var res = this.FlashObject.FlashCommand("SetFlashId", this.Control)
        if (res == "OK")
            this.FlashType = "AS3"
    }
    catch (exp) {
        this.FlashType = "AS2";
    }
}

GenericFlash.prototype.SendRequest = function (successFun, cmd, args, params) {
    if (successFun) {
        var flashObj = GetFlash(this.Control);
        var keys = new Array();
        keys.push(this.Key); 
		if (params) {
			$.each(params, function (i, v) {
				keys.push(v);
			})		
		}
		var params = { ExternalInterface: "ICTRLEXT", Type: this.Type, Id: this.FlashId, Command: cmd, Parameter: args, HistoryKeys: keys };
		
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ model: params }),
            url: this.Link,
            success: function (data) {
                successFun(data, flashObj);
            }
        });
    }
}

GenericFlash.prototype.FlashExec = function (cmd, arg) {
    if (this.FlashType == "AS3") {
        this.FlashObject.FlashCommand(cmd, arg);
    } else {
        this.FlashObject.SetVariable("ExecFunction", cmd)
        this.FlashObject.SetVariable("ExecParam", arg)
        this.FlashObject.Play()
    }
}

GenericFlash.prototype.GenericExecuteResponse = function (data, flashObj) {
    if (data.Status == "OK") 
        flashObj.UsedFlash.FlashExec(data.Function, data.Message, flashObj);
    else
        alert(data.Message);
};

GenericFlash.prototype.RegisterEvent = function (event, funct) {
    $(this).bind(event, funct);
};

GenericFlash.prototype.FlashEvent = function (cmd, args) {
    $(this).trigger(cmd, [cmd, args])
}

// Function that receives the events from Flash with support for ExternalInterface
function FlashEvent(id, cmd, args) {
    var flashMovie = GetFlash(id);
    $(flashMovie.UsedFlash).trigger(cmd, [cmd, args]);
}

GenericFlash.prototype.TriggerSave = function (args) {
    $(this).trigger("Save", [args])
}

GenericFlash.prototype.GenericSaveFlashResponse =  function (data, flashObj) {
    if (data.Status != "OK")
        alert(data.Message);
    else {
        flashObj.UsedFlash.GenericSave();
    }
};

//TODO:This can be improved...
GenericFlash.prototype.GenericSave = function () {
    //Must decrement the number of flashGraphics visted
    --ajaxCallsRemaining;
    if (ajaxCallsRemaining <= 0) {
        //if it is 0 then all flashes have been saved correctly at the database so the form can be submitted
        var form = $("form");
        form.attr("action", $("form .btn.btn-primary").attr("name")).submit();
    }
};