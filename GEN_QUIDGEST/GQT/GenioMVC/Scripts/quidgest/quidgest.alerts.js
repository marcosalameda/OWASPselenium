function Load_Alerts(reload)
{
    const curLocalStorageAlerts = JSON.parse(
        localStorage["alerts-container"] || "{}"
    )
    localStorage["alerts-container_modulo"] = qApi.GetModulo()

    if (reload) $.notifyClose()
    else reload = false

    if (reload)
    {
        $.ajax({
            url: quidgestGlobals.UrlAction.Alerts,
            cache: false,
            type: "GET",
            contentType: "application/json",
            success: function (data)
            {
                createAlerts(data)
                localStorage["alerts-container"] = JSON.stringify(data || {})
                updateAlertCounter()
            },
        })
    } else if (!$.isEmptyObject(curLocalStorageAlerts))
    {
        createAlerts(curLocalStorageAlerts)
        updateAlertCounter()
    }

    if ($.isEmptyObject(curLocalStorageAlerts)) $("#alerts").css("display", "none")

    updateAlertCounter()
}

function createAlerts(alerts)
{
    $.each(alerts, function (_, alert)
    {
        if (
            (alert.module === qapi.prototype.GetModulo() ||
                $.isEmptyObject(alert.module) ||
                (qapi.prototype.GetModulo() === "Public" &&
                    alert.module === "")) &&
            alert.count > alert.disableIfLowerThan
        )
        {
            $.notify(
                {
                    // options
                    title: alert.title,
                    message: alert.description,
                    url: alert.url,
                    target: "_self",
                    icon: "",
                },
                {
                    // settings
                    element: "#alerts-container",
                    position: "relative",
                    type: getAlertColor(alert.type),
                    allow_dismiss: alert.dismissible,
                    newest_on_top: false,
                    showProgressbar: false,
                    placement: {
                        from: "top",
                        align: "center",
                    },
                    offset: 10,
                    spacing: 10,
                    z_index: 1031,
                    delay: 0,
                    //timer: 1000, --MEXER NO TIMER NÃO FAZ SENTIDO.
                    url_target: "_blank",
                    mouse_over: null,
                    animate: {
                        enter: "animated bounceInUp",
                        exit: "animated bounceOutRight",
                    },
                    onShow: null,
                    onShown: null,
                    onClose: function () { updateAlertCounter(alert.id) },
                    onClosed: null,
                    icon_type: "image",

                    /*
                     * In version 3+ the template setting was modified
                     * to use a combination of data attributes and a C# string.format like function
                     * to control the content within the notification.
                     * {0} = type
                     * {1} = title
                     * {2} = message
                     * {3} = url
                     * {4} = target */

                    template:
                        '<div data-notify="container" class="alert c-alert c-alert--{0} c-sidebar__alert fade show" role="alert">' +
                        '<i data-notify="icon" class="glyphicons glyphicons-' +
                        getAlertIcon(alert.type) +
                        ' c-sidebar__alert-icon"></i>' +
                        '<a class="c-alert__dismissible" aria-hidden="true" data-notify="dismiss" data-toggle="tooltip" title="Ignorar"><i class="glyphicons glyphicons-remove e-icon--primary"></i></a>' +
                        '<h4 class="c-sidebar__alert-title" data-notify="title">{1}</h4>' +
                        '<div class = "c-sidebar__alert-text" data-notify="message">{2}</div>' +
                        '<a href="{3}" target="{4}" data-notify="url"><span class="hidden-elem">{1}</span></a>' +
                        "</div>",
                }
            )
        }
    })
}

function getAlertIcon(alertType)
{
    switch (alertType)
    {
        case "info":
            return "info-sign"
        case "success":
            return "ok-sign"
        case "warning":
            return "alert"
        case "error":
            return "light-beacon"
        default:
            return ""
    }
}

function getAlertColor(alertType) {
    switch (alertType) {
        case "info":
        case "success":
        case "warning":
            return alertType;
        case "error":
            return "danger"
        default:
            return ""
    }
}

function openNav()
{
    $("#alerts-container").toggle()
    $("#alert-button").toggle()
}

function updateAlertCounter(alertId)
{
    const alerts_counter = $("#alerts-container").children(
        'div:not([data-closing="true"])'
    ).length
    $(".alert-button .text").text(alerts_counter)
    $(".c-notification__counter").text(alerts_counter)

    //save alerts-container in local storage (remove the alert chosen)
    if (alertId)
    {
        let curLocalStorageAlerts = JSON.parse(
            localStorage["alerts-container"] || "{}"
        )

        if (!$.isEmptyObject(curLocalStorageAlerts))
            curLocalStorageAlerts = $.grep(
                curLocalStorageAlerts,
                function (value)
                {
                    return value.id !== alertId
                }
            )

        localStorage["alerts-container"] = JSON.stringify(curLocalStorageAlerts)
    }

    if (alerts_counter) $("#alerts").css("display", "")
}
function dismissAlerts()
{
    $.notifyClose()

    let curLocalStorageAlerts = JSON.parse(
        localStorage["alerts-container"] || "{}"
    )

    if (!$.isEmptyObject(curLocalStorageAlerts))
    {
        curLocalStorageAlerts = $.grep(
            curLocalStorageAlerts,
            function (value)
            {
                return !value.dismissible
            }
        )
    }

    localStorage["alerts-container"] = JSON.stringify(curLocalStorageAlerts)
    Load_Alerts()
    updateAlertCounter()
}
