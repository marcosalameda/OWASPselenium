function Selected(idGrid) {
    var control = $('#' + idGrid);
    var selectBtn = $('[data-element="gridslideshow-btn-select"]', control);
    var deleteBtns = $('div[data-element="gridslideshow__btn-delete"]', control);

    if (selectBtn.data('active')) {
        selectBtn.data('active', false);
        deleteBtns.hide();
        $('.imgGridSelected', control).removeClass('imgGridSelected').off('click');
        $('.i-gridslideshow__body a:not(.dropdown-item)', control).unbind('click');
    }
    else {
        selectBtn.data('active', true);        
        deleteBtns.show();
        $('.i-gridslideshow__body a:not(.dropdown-item)', control).on('click', function (event) {
            event.stopPropagation();
            event.preventDefault();
        });

        $("img", control).click(function (e) {
            e.stopPropagation();
            e.preventDefault();
            if ($(this).hasClass('imgGridSelected')) {
                $(this).removeClass("imgGridSelected");
            }
            else {
                $(this).addClass("imgGridSelected");
            }
        });
    }
}

function SelectAll(idGrid) {
    var control = $('#' + idGrid);
    $('img', control).addClass("imgGridSelected");
}