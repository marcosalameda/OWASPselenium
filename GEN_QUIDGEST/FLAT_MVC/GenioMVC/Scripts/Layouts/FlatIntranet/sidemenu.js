//file for SideMenu Javascript

$(document).mouseup(function (e) {
    var container = $('.navigationside');

    if (!container.is(e.target) // if the target of the click isn't the container...
        && container.has(e.target).length === 0) // ... nor a descendant of the container
    {
        container.removeClass('open');
    }
});
$('.navigationside .button a').click(function () {
    $('.navigationside').toggleClass('open');
});

