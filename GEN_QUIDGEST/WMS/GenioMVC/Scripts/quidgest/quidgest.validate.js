/* ===================================================
* scripts.js v1.0.0
* http://www.quidgest.com
* ===================================================
* Copyright 2012 Quidgest, S.A.
*
* All custom scripts will be placed here.
* ========================================================== */

// replaces default date validation with correct date format
(function ($, Globalize) {

    // Tell the validator that we want dates parsed using Globalize

    $.validator.methods.date = function (value, element) {
        if (value === "__/__/____") { // [ZEROD]
            return true;
        }
        var val = Globalize.parseDate(value, element.getAttribute("data-format"), 'en'); // en - Use default dateformat without '/' replaces
        return this.optional(element) || (val);
    };

    /*$.validator.methods.number = function (value, element) {
        var value = getFieldValue($(element))
        var val = Globalize.parseFloat(value);
        var isValid = this.optional(element) || ($.isNumeric(val));
        if (isValid) {
            $(element).attr('data-realValue', value)
        }
        return isValid;
    };*/

}( jQuery, Globalize ));

/*
$.validator.addMethod(
  "number",
  function (value, element) {
      return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
  }
);



jQuery.extend(jQuery.validator.methods, {
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }
});
*/