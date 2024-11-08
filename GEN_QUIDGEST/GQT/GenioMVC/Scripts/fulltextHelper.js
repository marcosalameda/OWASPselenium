function submitForm(areas) {
    checkAreas(areas);

    // Suggester
    //similarQueries();

    if (validateDateRange())
        // submit the form.
        document.forms[0].submit();
}

function similarQueries() {
    var s = $("#Search_SimilarQueries");
    s.val('');
    var input = $("#search-input");
    // If suggester is enabled
    //var input = $("#as-input-null");
    var queries = input.val().split(",");
    var result = "";
    for (var x = 0; x < queries.length; x++) {
        if (queries[x]) {
            var params = {};
            params["q"] = encodeURIComponent(decodeURIComponent(queries[x]));
            $.ajax({
                url: "http://localhost:8080/suggest",
                data: params,
                async: false,
                success: function (data, textStatus) {
                    $.each(data.items, function (index, value) {
                        result = result + value.value + "^0.75,";
                    });
                }
            });
        }
    }
    s.val(result);
}

function checkAreas(areas) {
    for (var i = 0; i < areas; i++) {
        var checkboxListValues = document.getElementsByName("area_s[" + i + "]");
        if (checkboxListValues.length > 1)
            document.forms[0].removeChild(checkboxListValues[1]);
        else if (checkboxListValues.length == 1) {
            var cb = checkboxListValues[0];
            if (cb.checked == false) {
                hidden = document.createElement("input");
                hidden.setAttribute("type", "hidden");
                hidden.setAttribute("name", "area_s[" + i + "]");
                hidden.setAttribute("value", "false");
                document.forms[0].appendChild(hidden);
            }
        }
    }
}

function validateDateRange() {
    var f = $('input.date');
    if(f.length > 1)
        for (var i = 0; i < f.length - 1 ; i++) {
            var in1 = f[i];
            var in2 = f[i+1];
            if (in1.name == in2.name) {
                var d1 = new Date(convertDate(in1.value));
                var d2 = new Date(convertDate(in2.value));
                if (d2 < d1) {
                    var field = 'input.date:nth(' + i + ')';
                    bootbox.alert($(field).data('range-error')); //"Make sure the second date is greater than first date");
                    return false;
                }
            }
        }

    return true;
}

function convertDate(date) {
    var dateString = date.split(/[\/-]/)
    return dateString[1] + "-" + dateString[0] + "-" + dateString[2];
}

function setFacet(name, value, n_areas) {
    // set the hidden input's name to the value you want.
    hidden = document.createElement("input");
    hidden.setAttribute("type", "hidden");
    hidden.setAttribute("name", name);
    hidden.setAttribute("value", value);

    if (document.getElementsByName(name).length == 0)
        $('form').append(hidden);
    else if (document.getElementsByName(name).length == 1)
        document.getElementsByName(name)[0].setAttribute("value", value)

    if (n_areas == 0)
        n_areas = $("input[name^='area_s']").length;

    submitForm(n_areas);
}

function removeFacet(name, n_areas) {
    // removes the element from document.
    var f = document.getElementsByName(name)[0];
    if ($(f).attr('type') == 'hidden') {
        $(f).remove();
    } else {
        f = document.getElementsByName(name);
        $(f).val('');
    }
    submitForm(n_areas);
}
