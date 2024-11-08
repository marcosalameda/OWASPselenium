var slideIndex = 1;
showDivs(slideIndex, "");

function plusDivs(n, control) {
    showDivs(slideIndex += n, '#' + control);
}

function _hideShowGSSActions_Slide() {
    $('[data-element="gridslideshow"] .contGrid .i-gridslideshow__body div[data-key] .gss-dropdownActions').removeClass("slidedisplaynone");

    var tr = $('[data-element="gridslideshow"] .contSlide .i-gridslideshow__body div[data-key]');
    tr.find('.gss-dropdownActions').addClass("slidedisplaynone");
    tr.find('a div').not('.slidedisplaynone').closest('div[data-key]').find('.gss-dropdownActions').removeClass("slidedisplaynone");
}

function showDivs(n, control) {
    var x = $(".mySlides", control);
    var y = $(".mySlidesBtn", control);
    var z = $(".mySlidesLegend", control);

    if (x.length <= 0) return;
    if (n > x.length) {
        slideIndex = 1;
    }
    if (n < 1) {
        slideIndex = x.length;
    }
    
    $(x).addClass("slidedisplaynone");
    $(y).addClass("slidedisplaynone");
    $(z).addClass("slidedisplaynone");

    $(x[slideIndex - 1]).removeClass("slidedisplaynone");
    $(y[slideIndex - 1]).removeClass("slidedisplaynone");
    $(z[slideIndex - 1]).removeClass("slidedisplaynone");

    _hideShowGSSActions_Slide();
}