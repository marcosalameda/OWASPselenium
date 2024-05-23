$(document).ready(function () {
    SaveView();
    initGridSlideShowBtnEvents();
});

function initGridSlideShowBtnEvents() {
    $('[data-element="gridslideshow-btn-chg-view"]')
        .off('click')
        .click(function () {
            var _this = this,
                mode = $(_this).data('view'),
                gss = $(_this).closest('[data-element="gridslideshow"]'),
                tableId = $(gss).data('table-id');
            SwicthView(mode, tableId);
        });
    $('[data-element="gridslideshow-btn-select"]')
        .off('click')
        .click(function () {
            var _this = this,
                gss = $(_this).closest('[data-element="gridslideshow"]'),
                aucId = $(gss).data('ajax-update-container');
            Selected(aucId);
        });
}

function SaveView() {
    var abc = $('.gridSlideMosaic').toArray();
    for (let idx = 0; idx < abc.length; idx++) {
        let view = localStorage.getItem(abc[idx].id + 'view');
        SwicthView(view, abc[idx].id);
    }
}

function SwicthView(clickedBtn, control) {
    if (localStorage !== null && clickedBtn !== null) {
        localStorage.setItem(control + 'view', clickedBtn);
    }
    if (clickedBtn === null) {
        grid(control);
        return;
    }
    var view;
    switch (localStorage.getItem(control + "view")) {
        case 'mosaic': mosaic(control); view = "Mosaic"; break;
        case 'slide': slide(control); view = "Slide"; break;
        default: grid(control); view = "Grid"; break;
    }
    var divViews = $('.divGroupViews', "#" + control);
    ActiveSwitch(divViews, view);
    _hideShowGSSActions_Slide();
}

function mosaic(idMosaic) {
    var control = $('#' + idMosaic);
    grid(idMosaic);
    $('.imgGrid', control).removeClass('imgGrid').addClass('imgMosaic');
    $('.divGrid', control).removeClass('divGrid').addClass('divMosaic');
}

function grid(idGrid) {
    var control = $('#' + idGrid);

    ImgSwitch('imgGrid', 'imgSlideShow', control);
    ImgSwitch('imgGrid', 'imgMosaic', control);

    $('.divIndSlideShow', control).removeClass('slidedisplaynone w3-display-container divIndSlideShow mySlides').addClass('divGrid');
    $('.divMosaic', control).removeClass('divMosaic').addClass('divGrid');

    SimpleSwitch(control, 'btnGridRight', 'w3-button w3-display-right w3-black', 'w3-display-right');
    SimpleSwitch(control, 'contGrid', 'contSlide', 'contSlide');
    SimpleSwitch(control, 'btnGridLeft', 'w3-button w3-display-left w3-black', 'w3-display-left');
}

function slide(idSlide) {
    var control = $('#' + idSlide);
    $('.legendGrid', control)
        .removeClass('legendGrid').addClass('legendSlideShow mySlidesLegend')
        .not(':first').addClass('slidedisplaynone');

    ImgSwitch('imgSlideShow', 'imgGrid', control);
    ImgSwitch('imgSlideShow', 'imgMosaic', control);

    $('.divGrid, .divMosaic', control)
        .removeClass('divGrid').removeClass('divMosaic')
        .addClass('w3-display-container divIndSlideShow mySlides')
        .not(':first').addClass('slidedisplaynone');

    SimpleSwitch(control, 'contSlide', 'contGrid', 'contGrid');
    SimpleSwitch(control, 'w3-button w3-display-left w3-black', 'btnGridLeft', 'btnGridLeft');
    SimpleSwitch(control, 'w3-button w3-display-right w3-black', 'btnGridRight', 'btnGridRight');
}

function ImgSwitch(adicionar, remover, control) {
    $('.' + remover, control).removeClass(remover).addClass(adicionar);
}

function ActiveSwitch(control, view) {
    var viewclass;
    switch (view) {
        case 'Mosaic': viewclass = $('.Mosaic', control); break;
        case 'Slide': viewclass = $('.Slide', control); break;
        case 'Grid': viewclass = $('.Grid', control); break;
    }
    $('.active', control).removeClass('active');
    $(viewclass).addClass('active');
}

function SimpleSwitch(control, add, remove, search) {
    var x = $('.' + search, control);
    $(x).removeClass(remove).addClass(add);
}