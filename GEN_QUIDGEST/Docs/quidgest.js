jQuery(function ($) {
    $('.menu-item a').each(function () {
        if (window.href === window.location.href) {
            $('.menu-item').addClass('selected');
        }
    });
});


//listen for window resize event
window.addEventListener('resize', () => {
    var menuHeight = $(".menu-bar").height();
    console.log(`Height = ${menuHeight} px`);
    $(".content-main-body").css({ marginTop: menuHeight })
});


