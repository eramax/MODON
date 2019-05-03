$(function() {
    'use strict';

    // Default
    $('.repeater-default').repeater();

    // Custom Show / Hide Configurations
    $('.file-repeater, .input-repeater').repeater({
        show: function() {
            $(this).slideDown();
        },
        hide: function(remove) {
            if (confirm('هل انت متأكد من حذف العنصر?')) {
                $(this).slideUp(remove);
            }
        }
    });


});