

(function ($) {
    $.fn.singleImageChooser = function () {
        const element = this;
        const reader = new FileReader();

        const label = $(`label.file-choose[for='${element[0].id}']`);

        reader.addEventListener(
            "load",
            () => {
                
                    $(label).removeClass('empty')
                     .css('background-image',`url(${reader.result})`)
                
            },
            false,
        );

        $(element).on('change', function (e) {
            reader.readAsDataURL(e.currentTarget.files[0]);
        })
    }
})(jQuery);
 


