/*
*
*	Extension to make inputs and select lists subscriptors of others
*
*/

(function() {

    $ = jQuery;

    var Subscriptor;

    $.fn.extend({
        subscribe: function (options) {
            return this.each(function (input_field) {
                var $this;
                $this = $(this);
                return $this.data('subscribe', new Subscriptor(this, options));
            });
        }
    });

    Subscriptor = (function() {

        var field;

        function Subscriptor(form_field, options) {
            var dependants = $(form_field).attr("dependant");
            if (dependants) {
				$.each(dependants.split(';'), function (index, dependant) {
					// the origin of the change
					field = $("#" + dependant);

					if (!field.data("subscriptors")) {
						field.data("subscriptors", new Array());
						field.data("subscriptors").push(form_field);
						field.change(function (evt) {
						    var changedField = $(this);
						    var subscriptors = changedField.data("subscriptors");
							var array = new Array();
							$(subscriptors).each(function (i, subscriptor) {
							    subscriptor = $(subscriptor);
							    var omodel = changedField.attr("pers-cs-area");
								var dmodel = subscriptor.attr("pers-cs-area");
								if (omodel != dmodel)
                                    // if DB or DL
                                    PropagateChanges(changedField, omodel, dmodel, [subscriptor]);
                                else
                                    // if FM or F2
                                    array.push(subscriptor);
                            });
                            if (array.length > 0) {
                                // process just 1 request to all dependant fields
							    var model = changedField.attr("pers-cs-area");
							    PropagateChanges(changedField, model, model, array);
							}
						});
						if (!field.val() && $("#" + field.attr("id")).val())
							field.change();
					} else
						field.data("subscriptors").push(form_field);
				});
            }
        }

        return Subscriptor;

    })();

    this.Subscriptor = Subscriptor;

}).call(this);
