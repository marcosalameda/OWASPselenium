// Get the modal
function gssModalDeleteAll(control) {
    bootbox.confirm({
        message: "Pretende eliminar todos os registos selecionados?",
        callback: function (result) {
            if (result) {
                var _this = $('#' + control),
                    gss = $(_this).closest('[data-element="gridslideshow"]'),
                    aucId = $(gss).data('ajax-update-container'),
                    delLink = $(gss).data('multi-delete-url');
                DeleteAllPicturesSelected(delLink, aucId);
            }
        },
        buttons: {
            confirm: {
                label: 'Eliminar',
                className: 'btn-danger'
            },
            cancel: {
                label: 'Cancelar'
            }
        }
    });
}

function DeleteAllPicturesSelected(sendUrl, control) {
    var selectedImages = $('.imgGridSelected', "#" + control).closest('[data-key]'); 
    var ids = [];
    $.each(selectedImages, function (idx, elem) {
        var id = $(elem).data('key');
        ids.push(id);
    });

    $.ajax({
        type: "POST",
        url: sendUrl,
        dataType: 'json',
        traditional: true,
        data: $.param({ ids: ids }, true),
        success: function (data) {
            console.log('Answer is:', data);
            QUtils.WindowReload();
        }
    });
}