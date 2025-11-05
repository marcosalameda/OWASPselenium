tinyMCE.init({
    // General options
    theme: "modern",
    plugins: [
        "advlist autolink lists link image charmap print preview hr anchor pagebreak",
        "searchreplace wordcount visualblocks visualchars code fullscreen",
        "insertdatetime media nonbreaking save table contextmenu directionality",
        "emoticons template paste textcolor layer"
    ],
    // Theme options 
    toolbar1: "insertfile undo redo | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | print preview | forecolor backcolor | link image | insertlayer moveforward movebackward absolute",
    statusbar: false,
	toolbar_items_size: 'small',
    setup: function (ed) {
        ed.on('init', function (inst) {
            HtmlBoxInit(inst)
        });
        ed.on('load', function () {
            // resize the editor to fit
            this.theme.resizeBy(0, (this.contentWindow.innerHeight - this.editorContainer.offsetHeight));
        });
        ed.on('blur', function (e) {
            HtmlBoxBlur()
        });
    }
});