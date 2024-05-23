/*
* MultiSelect v0.2
* Copyright (c) 2011 Louis Cuny
*
* Dual licensed under the MIT and GPL licenses:
*    http://www.opensource.org/licenses/mit-license.php
*    http://www.gnu.org/licenses/gpl.html
*
*/
(function ($) {
    var msMethods = {
        'init': function (options) {
            this.settings = {
                disabledClass: 'disabled',
                emptyArray: false,
                callbackOnInit: false,
                keepOrder: false
            };
            if (options) {
                this.settings = $.extend(this.settings, options);
            }
            var ms = $(this);
            var selectableUl = $("#" + ms.attr('id') + ' .ms-selectable ul'),
                selectedUl = $("#" + ms.attr('id') + ' .ms-selection ul');

            var type = this.settings.type;
            var collapse = this.settings.collapse;
            var search = this.settings.search;

            var arrayList = "";
            if (type != undefined) {
                if (type == "O") {
                    arrayList += '<div class="orders">';
                    for (var key in order) {
                        arrayList += '<div key="' + key + '">' + order[key] + '</div>'
                        textSelected = "";
                    }
                    arrayList += '</div>';
                }
                else if (type == "C") {
                    arrayList += '<select class="optionValues OP">' +
                        '<option selected value=""></option>' +
                        '</select>';
                    arrayList += '<input class="optionValues" type="text" style="width:auto;"/>';
                }
            }

            $(this).parent().append(arrayList);

            $(this).find("li.ms-elem-selectable").click(function () {
                ms.multiSelect('select', $(this));
                if (type == "F") {
                    updateGroups(this, false)
                    updateOrder(this, false)
                }
            });

            if (search) {
                var selector = '#' + $(this).attr("id") + ' .ms-selectable .ms-optgroup li.ms-elem-selectable'
                $(this).find(".searchInput").quicksearch(selector, {
                    hide: function () {
                        $(this).addClass('quicksearchHide');
                    },
                    show: function () {
                        $(this).removeClass('quicksearchHide');
                        var label = $(this).siblings('.ms-optgroup-label')
                        //Expand
                        $(label).nextAll('li:not(.ms-selected)').show();
                        $(label).addClass('collapsed')
                        $('.e-icon--group', label).removeClass('glyphicons-plus-sign')
                        $('.e-icon--group', label).addClass('glyphicons-minus-sign')
                    }
                });
            } else
                $(this).find(".searchInput").hide()

            if (collapse) {
                $(this).find('.ms-optgroup-label').on("click", function () {
                    if ($(this).hasClass('collapsed')) {
                        //Collapse
                        $(this).nextAll('li').hide();
                        $(this).removeClass('collapsed');
                        $('.e-icon--group', this).removeClass('glyphicons-minus-sign')
                        $('.e-icon--group', this).addClass('glyphicons-plus-sign')
                    } else {
                        //Expand
                        $(this).nextAll('li:not(.ms-selected)').show();
                        $(this).addClass('collapsed');
                        $('.e-icon--group', this).removeClass('glyphicons-plus-sign')
                        $('.e-icon--group', this).addClass('glyphicons-minus-sign')
                    }
                });
                $(this).find('li.ms-elem-selectable').hide();
            }
            //else
                ////ACÇÃO NECESSÁRIA PARA AS TABELAS SURGIREM NÃO COLLAPSED
            $('.ms-optgroup-label').click();


            var onloading = $(selectedUl).children("li").length

            if (onloading) {
                if (!(type == "G")) {
                    $(selectedUl).children("li").each(function () {
                        updateListeners("", $(this), $(selectableUl).find("li[ms-value='" + $(this).attr("ms-value") + "']"), selectedUl, selectableUl, ms, type, type == "C", true, true)
                    });
                } else {
                    $(selectedUl).find("li.group").find("li").each(function () {
                        updateListeners("", $(this), $(selectableUl).find("li[ms-value='" + $(this).attr("ms-value") + "']"), selectedUl, selectableUl, ms, type, type == "C", true, true)
                    });
                }
            }

            if (type == "G") {
                ////###### EVENTO MOVER PARA CIMA GRUPO #######
                $('#group-up').click(function () {
                    var liGroupList = $(selectedUl).children('li.group')
                    var lisSelected = $(liGroupList).find('li.selected');
                    var parentLisSelected = $(lisSelected).parent().parent()
                    var index = $(liGroupList).index(parentLisSelected)
                    var indexFuture = index - 1;
                    var groupId = indexFuture + 1;

                    if (indexFuture >= 0) {
                        $(liGroupList[indexFuture]).children("ul").append(lisSelected.hide().fadeIn(500, function () { updateTotal(); $(lisSelected).resize(); }))
                        $(parentLisSelected).removeClass('currentSelection')
                        $(liGroupList[indexFuture]).addClass('currentSelection')

                        if ($(parentLisSelected).children("ul").children("li").length == 0) {
                            index++
                            var paddingleft = Number($(liGroupList[indexFuture]).css("padding-left").replace("px", ""));
                            $(parentLisSelected).nextAll('li.group').each(function () {
                                var paddingleft = Number($(liGroupList[index]).css("padding-left").replace("px", ""));
                                var width = Number($(liGroupList[index]).css("width").replace("px", ""));
                                $(this).children('div.group-title').text(textos[lang]["G"] + (index++) + ' - ' + textos[lang]["PB"] + ': ').append('<input name="pagebreak" type="checkbox" value="true"/>');
                                $(this).animate({
                                    paddingLeft: (paddingleft + 20) + "px",
                                    width: (width - 20) + "px"
                                }, 500, function () { updateTotal(); });
                            })
                            $(parentLisSelected).remove();
                        }
                    }
                    else if (indexFuture == -1) {
                        if (!($(parentLisSelected).children("ul").children("li").length == lisSelected.length)) {
                            var newGroup = $('<li class="ms-elem-selected group"><div class="group-title">' + textos[lang]["G"] + ' 1 - ' + textos[lang]["PB"] + ': <input type="checkbox" name="pagebreak" value="true"/></div><ul></ul></li>')

                            if (liGroupList.length) {
                                $($(liGroupList[index]).parent()).prepend(newGroup.hide())
                            }

                            var newLiAppend = $(selectedUl).children('li.group')[index]

                            $(newLiAppend).children("ul").append(lisSelected.removeClass("selected"))
                            $(newGroup).fadeIn()
                            index++
                            index++
                            $(newGroup).nextAll('li.group').each(function () {
                                $(this).removeClass('currentSelection')
                                $(this).children('div.group-title').text(textos[lang]["G"] + " " + (index++) + ' - ' + textos[lang]["PB"] + ':').append('<input name="pagebreak" type="checkbox" value="true"/>')

                                var paddingleft = Number($(this).css("padding-left").replace("px", ""));
                                var width = Number($(this).css("width").replace("px", ""));

                                $(this).fadeIn(500).animate({
                                    paddingLeft: (paddingleft + 20) + "px",
                                    width: (width - 20) + "px"
                                }, 500, function () { updateTotal(); });

                            })
                        }
                    }

                });
                ////###### EVENTO MOVER PARA BAIXO GRUPO #######
                $('#group-down').click(function () {
                    var liGroupList = $(selectedUl).children('li.group')
                    var lisSelected = $(liGroupList).find('li.selected');
                    var parentLisSelected = $(lisSelected).parent().parent()
                    var index = $(liGroupList).index(parentLisSelected)
                    var indexFuture = index + 1;
                    var groupId = indexFuture + 1;

                    if (indexFuture < liGroupList.length) {
                        $(liGroupList[indexFuture]).children("ul").append(lisSelected.hide().fadeIn(500, function () { updateTotal(); }))
                        $(parentLisSelected).removeClass('currentSelection')
                        $(liGroupList[indexFuture]).addClass('currentSelection')
                        if ($(parentLisSelected).children("ul").children("li").length == 0) {
                            $(parentLisSelected).nextAll('li.group').each(function () {

                                var paddingleft = Number($(liGroupList[indexFuture]).css("padding-left").replace("px", ""));
                                var width = Number($(liGroupList[indexFuture]).css("width").replace("px", ""));

                                $(this).children('div.group-title').text(textos[lang]["G"] + " " + (indexFuture++) + ' - ' + textos[lang]["PB"] + ':').append('<input name="pagebreak" type="checkbox" value="true"/>')
                                $(this).animate({
                                    paddingLeft: (paddingleft - 20) + "px",
                                    width: (width + 20) + "px"
                                }, 500, function () { updateTotal() });
                            })
                            $(parentLisSelected).remove()
                        }
                    }
                    else if (indexFuture == liGroupList.length) {
                        if (!($(parentLisSelected).children("ul").children("li").length == lisSelected.length)) {
                            var newId = (liGroupList.length + 1);
                            var paddingleft = Number($(liGroupList[liGroupList.length - 1]).css("padding-left").replace("px", ""));
                            var width = Number($(liGroupList[liGroupList.length - 1]).css("width").replace("px", ""));
                            var newGroup = $('<li class="ms-elem-selected group" style="padding-left:' + paddingleft + 'px;"><div class="group-title">' + textos[lang]["G"] + ' ' + newId + ' - ' + textos[lang]["PB"] + ': <input type="checkbox" name="pagebreak" value="true"/></div><ul></ul></li>')

                            if (liGroupList.length) {
                                $($(liGroupList[0]).parent()).append(newGroup.hide())
                            }

                            var newLiAppend = $(selectedUl).children('li.group')[indexFuture]
                            lisSelected.parent().removeClass("currentSelection")
                            $(newLiAppend).children("ul").append(lisSelected.removeClass("selected"));

                            $(newGroup).fadeIn(500).animate({
                                paddingLeft: (paddingleft + 20) + "px",
                                width: (width - 20) + "px"
                            }, 500, function () { updateTotal(); $(this).css("width", "auto") });
                        }
                    }
                });
            }



        },
        'refresh': function () {
            $("#" + $(this).attr("id")).remove();
            $(this).multiSelect("init");
        },
        'select': function (value, method) {
            var ms = this,
                klass = $(value).attr("ms-type"),
                selectableUl = $("#" + ms.attr('id') + ' .ms-selectable ul'),
                selectedUl = $("#" + ms.attr('id') + ' .ms-selection ul'),
                selectableLi = value,
                tableText = $(selectableLi).attr('ms-group'),
                text = selectableLi.text(),
                haveToSelect = value != '';

            value = $(value).attr("ms-value");

            var classState = " incomplete";
            var haveConditions = false;
            //VERIFICAÇÃO DA EXISTÊNCIA OU NÃO DE TYPES
            var type = $(selectedUl).attr("ms-type")
            //VERIFICAÇÃO DO MODO DO MULTIANO
            var yearMode = $(selectedUl).attr("ms-year")
            var haveYearMode = false;

            if (yearMode == "INNER" || yearMode == "OUTER")
                haveYearMode = true;

            if (type == "C")
                haveConditions = true;

            if (haveConditions)
                klass += classState;

            var IsArrayType = $(selectableLi).attr("Array");
            if (IsArrayType != undefined) {
                klass += " array";
            }

            //CONSTRUÇãO DA LI (LADO ESQUERDO)
            // Evitei um ternário porque ficava demasiado longa a linha
            //            var selectedItem = '<div class="text-lis"><div>' + text + ' <strong>[' + tableText + ']</strong></div>';

            //            if (selectedItem.length > 95)
            selectedItem = '<div class="text-lis"><div><strong>[' + tableText + ']</strong></div></div><div class="text-lis"><div>' + text + '</div>';

            var selectedLiString = '<li class="ms-elem-selected ' + klass + '" ms-value="' + value + '" ms-type="' + $(selectableLi).attr("ms-type") + '" ms-group="' + tableText + '" >' +
                (haveConditions ? '<div class="imgState"></div>' : '') +
                '<div class="delete" style="position:relative; height: 20px; width:22px; float:right; cursor:pointer;"></div>' +
                selectedItem +
                (type == "F" ? "<span>" + textos[lang]["order"] + " </span>" : (type == "O" ? "<span>" + textos[lang]["order"] + " </span>" : ""))

            if (haveConditions) {
                selectedLiString += "<div class='result1 condition'>&nbsp;</div>";
                selectedLiString += "<div class='result2 condition'>&nbsp;</div>";
            }

            selectedLiString += "</div>";

            if (type == "F")
                selectedLiString += '<div class="colName">Coluna:<input type="text" style="width:auto;" value="' + text + '"></div>';

            selectedLiString += (haveYearMode ? '<div class="yearMode">Desdobrar por ano: <input type="checkbox" name="yearmode"/></div>' : "");
            selectedLiString += '</li>';

            var selectedLi = $(selectedLiString);
            $(selectedLi).attr("ms-text", text)
            updateListeners(method, selectedLi, selectableLi, selectedUl, selectableUl, ms, type, haveConditions, haveToSelect, false);

        },
        'deselect': function (selectedLi) {
            var value = $(selectedLi).attr("ms-value")
            var ms = this,
                selectedUl = $('#' + ms.attr('id') + ' .ms-selection ul');

            if (selectedLi) {
                var selectableUl = $('#' + ms.attr('id') + ' .ms-selectable ul'),
                    selectedUl = $('#' + ms.attr('id') + ' .ms-selection ul'),
                    selectableLi = selectableUl.children('li[ms-value="' + value + '"]');

                var parentOptgroup = selectableLi.parent('.ms-optgroup');

                if (parentOptgroup.length > 0)
                    parentOptgroup.children('.ms-optgroup-label').show();

                selectableLi.removeClass('ms-selected');

                if (selectableLi.parent().find("li.ms-optgroup-label").hasClass('collapsed'))
                    selectableLi.show();
                else if (selectableLi.parent().find("li.ms-optgroup-label").length == 0)
                    selectableLi.show();

                var container = $(selectedUl).parent().parent();

                if ($(selectedUl).attr("ms-type") == "G") {
                    if ($(selectedLi).parent().children("li").length == 1) {
                        $(selectedLi).hide().addClass("selected")
                        if ($(selectedLi).parent().next().length)
                            $(container).children('div').children('#group-down').click();
                        else
                            $(container).children('div').children('#group-up').click();

                        $(selectedLi).remove();
                    }
                    else
                        selectedLi.remove();

                    updateTotal()
                }
                else
                    selectedLi.remove();
            }
        },
        'select_all': function () {
            var ms = this;
            /*   ms.find("option:not(option[value=''])").each(function () {
            ms.multiSelect('select', $(this).val(), 'select_all');
            });*/
        },
        'deselect_all': function () {
            var ms = this;
            /*  ms.find("option:not(option[value=''])").each(function () {
            ms.multiSelect('deselect', $(this).val(), 'deselect_all');
            });*/
        }
    };

    $.fn.multiSelect = function (method) {
        if (msMethods[method]) {
            return msMethods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return msMethods.init.apply(this, arguments);
        } else {
            if (console.log) console.log('Method ' + method + ' does not exist on jquery.multiSelect');
        }
        return false;
    };
})(jQuery);


function update(element) {
    //codigo necessario para apanhar o key press do input

    //id="ui-datepicker-div" class="ui-datepicker
    // Adicionado por causa do datepicker - mas deve ser conciliado com change que está abaixo
    /*  $(element).find("input.optionValues.date").blur(function () {
  
      });*/

    $(element).find("input.optionValues").keyup(function () {
        var appendTo = 'div.result2';
        $(this).parent().find(appendTo).empty().append($(this).val());
        verifyAll(this);
    });

    //codigo necessario para mudança no select (combo)
    $(element).find("select.optionValues").change(function () {
        var appendTo = "";
        var finalValue = $(this).find("option:selected").text();

        if ($(this).hasClass("OP")) {
            var valOp = $(this).val();
            appendTo = 'div.result1';
            if (valOp != "IN" && valOp != "BETWEEN") {
                var inputValue = $(this).parent().find("input")[0];
                var arrayValues = $(inputValue).val().split(",");
                if (arrayValues.length > 1) {
                    $(inputValue).val(arrayValues[0]);
                    //TODO: FAZER A PERGUNTA ANTES E LIMITAR QUANDO É BETWEEN A DOIS VALORES.
                    $(this).parent().find("div.result2").empty().append(arrayValues[0]);
                }
            }
        } else {
            var valOp = $(this).parent().find("select.OP").val();
            var value = $(this).find("option:selected").text();
            var inputValue = $(this).parent().find("input.ov2")
            var values = $(inputValue).val();

            if (valOp == "IN" || valOp == "BETWEEN") {
                if (values.length > 0) {
                    $(inputValue).val("");
                    if (valOp == "BETWEEN") {
                        var splitV = values.split(",");
                        if (splitV.length > 1) {
                            if (!$(inputValue).hasClass("ft")) {//se é a segunda vez que se clicka ou não...
                                finalValue = value + ", " + splitV[1]
                                $(inputValue).toggleClass("ft");
                            } else {
                                finalValue = splitV[0] + ", " + value
                                $(inputValue).toggleClass("ft");
                            }
                        } else {
                            finalValue = values + ", " + value
                        }
                    }
                    else {
                        finalValue = values + ", " + value
                    }
                    $(inputValue).val(finalValue);
                }
                else
                    $(inputValue).val(finalValue);
            } else {
                $(inputValue).val(value);
            }
            appendTo = 'div.result2';
        }
        $(this).parent().find(appendTo).empty().append(finalValue);
        verifyAll(this);
    });
}

function verifyAll(element) {
    var allValues = false;
    var Values = $(element).parent().find(".optionValues").length;
    var ValuesWithNoValue = $(element).parent().find(".optionValues[value!='']").length;
    if (ValuesWithNoValue == Values)
        allValues = true;

    var op = $(element).parent().children("select").val();

    if (allValues || op == "ISNULL" || op == "ISNOTNULL")
        $(element).parent().removeClass("incomplete").addClass("complete")
    else
        $(element).parent().removeClass("complete").addClass("incomplete")
}

function stringOptions(type) {
    var valuesType = types_to_operands[type];
    var optionsValues = "";
    for (var key in valuesType) {
        optionsValues += '<option value="' + key + '">' + valuesType[key] + '</option>'
    }
    return optionsValues;
}

function constructArrayTotal(element, isNotSelectedField) {
    var checkBoxs = $("<div class='checkbTotal'></div>")
    var fieldType = $(element).attr("ms-type");
    $(checkBoxs).append(stringOptionsTotal(fieldType));
    $(element).append($(checkBoxs))
}

function stringOptionsTotal(type) {
    var valuesType = total[type];
    var optionsValues = "";
    for (var key in valuesType) {
        optionsValues += valuesType[key] + ':&nbsp;<input type="checkbox" value="' + key + '"/> '
    }
    return optionsValues;
}

function updateTotal() {
    $(function () {
        //selecção dos grupos, valores a adicionar, e valores nao seleccionados
        var listToRefresh = $("#ms-TotalSelect > div.ms-selectable > .ms-list");
        var listNewValuesRefresh = $("#ms-GroupBySelected > div.ms-selection > .ms-list").clone();
        var listNotSelectRefresh = $("#ms-GroupBySelected > div.ms-selectable > ul.ms-list > li.ms-optgroup-container > ul.ms-optgroup").clone();

        //LIS escolhidas inicialmente, nos campos para o select para aparecerem no grupo dos totalizadores Globais.
        var lisChoosen = $("#ms-GroupBySelected > div.ms-selectable > ul.ms-list > li.ms-optgroup-container > ul.ms-optgroup").clone();

        $(listNotSelectRefresh).children("li.ms-selected").remove();
        $(listNotSelectRefresh).children("li.ms-optgroup-label").remove();
        $(listNotSelectRefresh).children("li").addClass("elemTotalizer")

        //criação dos grupos vazios para fazerem append
        var groupList = $(listNewValuesRefresh).clone()
        $(groupList).children("li.group").find("input").remove()
        $(groupList).children("li.group").children("ul").children("li").remove()

        //actualização do nome do grupo.
        $(groupList).children("li.group").children("div.group-title").each(function () {
            var titleGroup = $(this).text();
            var TGValues = titleGroup.split("-")
            titleGroup = TGValues[0];
            $(this).text(titleGroup)
            $(this).parent().css("width", "auto");
        })
        $(groupList).addClass("totalizer");

        var overallGroup = $(groupList).children("li:eq(0)").clone()
        $(overallGroup).find("div.group-title").text("Geral");

        //colocar arrays de tipos nos campos não seleccionados
        $(listNotSelectRefresh).children("li").each(function () {
            var textLi = $(this).text()
            $(this).text("")
            $(this).append(constructHtmlTotalLi($(this).attr('ms-group'), textLi))
            constructArrayTotal($(this));
        })
        $(listNewValuesRefresh).children("li.group").each(function () {
            //colocar arrays de tipos
            $(this).children("ul").children("li").each(function () {
                constructArrayTotal($(this))
                $(this).children("div.delete").remove()
            });
        });

        $(lisChoosen).children("li.ms-elem-selectable").each(function () {
            //CSS do ms-selected esconde o elemento e como é um clone vai com todas as propriedades...convém retirar esta class.
            $(this).removeClass("ms-selected");
            $(this).show();
            var textLi = $(this).text();
            $(this).text("")
            var parent = $(this).attr('ms-group');
            //$(this).append('<div class="text-lis">' + textLi + ' <strong>[' + parent + ']</strong></div>')
            $(this).append(constructHtmlTotalLi(parent, textLi));
            constructArrayTotal($(this))
            $(overallGroup).children("ul").append($(this))
        });

        //acrescentar todos os campos não seleccionados em todos os grupos 
        $(groupList).children("li.group").each(function () {
            var currElem = $(this);
            //Verificação se já existem campos escolhidos para o primeiro grupo.
            var hasElems = $(listNewValuesRefresh).children("li.group").first().children("ul").children().length;
            //Calculo da index do grupo que está a ser percorrido e para saber o ponto apartir do qual vai-se obter os campos para baixo.
            var currIndex = $(groupList).children("li.group").index($(this));
            if ((hasElems > 0 && currIndex == 0) || (hasElems && currIndex > 0)) {
                //Busca de cada grupo já existente no lado direito.
                $(listNewValuesRefresh).children("li.group").each(function () {
                    //Index actual
                    var thisIndex = $(listNewValuesRefresh).children("li.group").index($(this))
                    $(this).children("div").remove()
                    //Percorrer os campos do grupo actual, se i undex for maior do que o actual.
                    if (thisIndex > currIndex) {
                        $(this).children("ul").children("li").each(function () {
                            $(this).removeClass("ms-elem-selected").removeClass("selected").addClass("ms-elem-selectable").addClass("elemTotalizer");
                            var textLi = $(this).attr("ms-text");
                            $(this).text("");
                            var parent = $(this).attr('ms-group');
                            //$(this).append('<div class="text-lis">' + textLi + ' <strong>[' + parent + ']</strong></div>')
                            $(this).append(constructHtmlTotalLi(parent, textLi));
                            constructArrayTotal($(this));
                        });
                        $(currElem).children("ul").append($(this).children("ul").html());
                    }
                })
                $(listNotSelectRefresh).find("li").show();
                $(listNotSelectRefresh).each(function () {
                    $(currElem).children("ul").append($(this).html());
                });
            }
            else {
                $(currElem).remove();
            }
        });
        //limpar lista e fazer append dos grupos vazios
        var parentContainer = $(listToRefresh).parent();
        $(parentContainer).empty();
        $(groupList).prepend(overallGroup);
        $(parentContainer).append(groupList);
    })
}

function constructHtmlTotalLi(parent, textLi) {
    return '<div class="text-lis"><div><strong>[' + parent + ']</strong></div></div><div class ="text.lis"><div>' + textLi + '</div></div>'
}

function updateListeners(method, selectedLi, selectableLi, selectedUl, selectableUl, ms, type, haveConditions, haveToSelect, onloading) {
    $(function () {
        //CONSTRUÇÃO DOS SELECTS E (SE HOUVER CONDIÇÕES) DE INPUTS
        if (type == "C" && !onloading) {
            var value = $(selectableLi).attr("ms-value");
            var id = $(ms).attr("id")
            var selector = value + id.substring(3, id.length - 2)

            var selectValues = '<div><select class="optionValues OP" id="' + (selector + "OP") + '">' +
                '<option selected value=""></option>' +
                '</select></div>';

            var selectFinal = $(selectValues);
            var optionsValues = "";
            var inputValue = "";
            //Se é do tipo Array tem de ir buscar o elemento correspondente à array que ele está a utilizar.
            if ($(selectedLi).hasClass("A")) {

                if ($(selectedLi).hasClass("array")) {
                    optionsValues = stringOptions("ARRAY");
                    var idArray = $(selectableLi).attr("array-id");
                    idArray = "#" + idArray;
                    var arrayField = $('<div>').append($(idArray).clone()).remove();
                    $(arrayField).find("select")[0].id = (selector + "VAL");
                    $(arrayField).find("select").addClass("optionValues");
                    //TODO: Passar os textos para o javascript....
                    inputValue += '<br/><span>Escolha aqui:</span>' + $(arrayField).html();
                    inputValue += '<br/><span>' + textos[lang]["V"] + "</span>";
                    //inputValue += '<input class="optionValues ov2" type="text" style="width:auto;"/>';
                }
                else {
                    optionsValues = stringOptions("A");
                    inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues" type="text" style="width:auto;"/>';
                }
            }
            else if ($(selectedLi).hasClass("D")) {
                optionsValues = stringOptions("D");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues date" type="text" style="width:auto;"/>';
            }
            else if ($(selectedLi).hasClass("H")) {
                optionsValues = stringOptions("H");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues hour" type="text" style="width:auto;"/>';
            }
            else if ($(selectedLi).hasClass("B")) {
                optionsValues = stringOptions("B");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span>' +
                    '<select class="optionValues" id="' + (selector + "VAL") + '">' +
                    '<option selected value=""></option>';
                for (k in logicos)
                    inputValue += '<option value="' + k + '">' + logicos[k] + '</option>';

                inputValue += '</select>';
            }
            else if ($(selectedLi).hasClass("N")) {
                optionsValues = stringOptions("N");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues numeric" type="text" style="width:auto;"/>';
            }
            else if ($(selectedLi).hasClass("T")) {
                optionsValues = stringOptions("T");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues time" type="text" style="width:auto;"/>';
            }
            else if ($(selectedLi).hasClass("$")) {
                optionsValues = stringOptions("$");
                inputValue = '<br/><span>' + textos[lang]["V"] + '</span><input class="optionValues money" type="text" style="width:auto;"/>';
            }
            $(selectFinal).find('option').append(optionsValues);
            $(selectFinal).append(inputValue);
            $(selectedLi).append('<span>' + textos[lang]["O"] + '</span>' + $(selectFinal).html());
            $(selectedLi).append('<div class="condition-show-nulls">' + quidgestGlobals.Resources.MOSTRAR_LINHAS_VAZIA48693 +':<input type="checkbox"/></div>');
        }
        else if (type == "O") {
            if (!onloading) {
                var selectV = $(ms).parent().children("div.orders").eq(0);
                var listToAppend = $(selectV).clone();
                var cloneSelectV = $('<div>').append(listToAppend.css("display", "inline")).remove()
                $(cloneSelectV).find("div.orders div").first().css("display", "inline").addClass("selectedOrder").addClass("asc")
                $(selectedLi).find("div.text-lis span").before($(cloneSelectV).html())
            }
            $(selectedLi).find("div.text-lis").find("div.orders").click(function () {
                var curr = $(this).find("div:visible")
                var next = $(curr).next()

                $(curr).hide()
                $(this).children("div").removeClass("selectedOrder")

                if ($(next).length)
                    $(next).css("display", "inline").addClass("selectedOrder").removeClass("asc").addClass("desc");
                else
                    $(this).children().first().css("display", "inline").addClass("selectedOrder").removeClass("desc").addClass("asc");
            })
        }

        if (haveToSelect) {
            if (!haveConditions) {
                var parentOptgroup = selectableLi.parent('.ms-optgroup');
                if (parentOptgroup.length > 0)
                    if (parentOptgroup.children('.ms-elem-selectable:not(:hidden)').length == 1)
                        parentOptgroup.children('.ms-optgroup-label').hide();

                selectableLi.addClass('ms-selected');
                selectableLi.hide();
            }

            if (type != "G") {
                //click no botão do caixote do lixo apaga
                $(selectedLi).find("div.delete").click(function () {
                    ms.multiSelect('deselect', $(this).parent());
                    if (type == "F") {
                        updateGroups($(this).parent(), true)
                        updateOrder($(this).parent(), true)
                    }
                });
            }

            //############### O HOVER DA LI SELECCIONADA ################
            $(selectedLi).hover(function () {
                if ($(this).parent().find("input:focus, .optionValues:focus").length == 0) {
                    $(this).parent().find("li").removeClass("hoverState");
                    $(this).parent().find(".optionValues").hide();
                    $(this).find(".optionValues").css('display', 'inline-block');
                    $(this).addClass("hoverState")
                    //Acerta a scrollbar de modo a visualizar-se toda a li
                    var pos = $(this).height()
                    var list = $(this).parent().children("li");
                    var index = list.index($(this))
                    if ((index + 1) == list.length)
                        $(this).parent().scrollTop(pos * index);

                }
            }, function () {
                if ($(this).parent().find("input:focus, .optionValues:focus").length == 0 && $("#ui-datepicker-div:visible").length == 0) {
                    $(this).find(".optionValues").hide();
                    $(this).parent().removeClass("hoverState");
                    $(this).removeClass("hoverState");
                }
            })

            //click numa li
            $(selectedLi).click(function () {
                if ($(this).parent().find(".optionValues:focus").length == 0) {
                    $(this).parent().find("li").removeClass("hoverState");
                    $(this).parent().find(".optionValues").hide();
                    $(this).find(".optionValues").css('display', 'inline-block');
                    $(this).addClass("hoverState")
                }
            })

            //se é do tipo de condições associa ao campo os eventos de actualização
            if (haveConditions) {
                //################# TRATAMENTO DE MASKS ##################//
                $.datepicker.setDefaults($.datepicker.regional["pt"]);
                $(selectedLi).find("input.date").datepicker({
                    onSelect: function (dateText, inst) {
                        var valOp = $(selectedLi).find("select").val();
                        var finalValue = $(this).val();
                        // só permite separador de valores "," se já estiver escolhido o operador...
                        if ((valOp == "IN" || valOp == "BETWEEN")) {
                            var values = inst.lastVal;
                            if (values.length > 0) {
                                $(this).val("");
                                if (valOp == "BETWEEN") {
                                    var splitV = values.split(",");
                                    if (splitV.length > 1) {
                                        if (!$(this).hasClass("ft")) {//se é a segunda vez que se clicka ou não...
                                            finalValue = dateText + ", " + splitV[1]
                                            $(this).toggleClass("ft");
                                        } else {
                                            finalValue = splitV[0] + ", " + dateText
                                            $(this).toggleClass("ft");
                                        }
                                    } else {
                                        finalValue = values + ", " + dateText
                                    }
                                }
                                else {
                                    finalValue = values + ", " + dateText
                                }
                                $(this).val(finalValue);
                            }
                            else
                                $(this).val(finalValue);
                        } else {
                            $(this).val(finalValue);
                        }

                        var appendTo = 'div.result2';
                        $(this).parent().find(appendTo).empty().append(finalValue);
                        verifyAll(this);
                    }
                });
                //$(selectedLi).find("input.hour").mask("99:99");
                $(selectedLi).find('input.money, input.numeric').bind('keypress', function (e) {
                    // limitação de inputs do tipo money e numéricos
                    // a separação de valores é com "," (44)
                    // utilizado com os operadores IN ou BETWEEN
                    // o caracter separador dos décimais é "." (46)

                    // TODO:
                    // isto devia ser com listas ou ranges de exclusões, assim fica um bocado feio

                    // para debug - tooltip do botão de nova consulta fica com o valor
                    //$("#new-button").attr("data-original-title", e.which + "");

                    var valOp = $(selectedLi).find("select").val();

                    // só permite separador de valores "," (44) e espaço (32) se for escolhido um dos operadores "entre" ou "um de"
                    if ((valOp == "IN" || valOp == "BETWEEN") && (e.which == 44 || e.which == 32))
                        return true;

                    return (e.which != 46 && e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) ? false : true;
                })
                ////###### EVENTO PARA ACTUALIZAR AO PRESSIONAR TEXTO #######
                update(selectedLi);
            }

            //##################### APPEND DA LI ######################## 
            //############### VERIFICA SE NÂO EXISTE GROUP BY ###############
            if (!(type == "G")) {
                var selectedUlLis = selectedUl.children('.ms-elem-selected');
                if (method != 'init'/* && ms.data('settings').keepOrder */ && selectedUlLis.length > 0) {
                    var getIndexOf = function (value) {
                        elems = selectableUl.children('.ms-elem-selectable');
                        return (elems.index(elems.closest('[ms-value="' + value + '"]')));
                    }
                    selectedUl.append(selectedLi);
                } else {
                    selectedUl.append(selectedLi);
                }
            }
            else {
                $(selectedLi).click(function (evt) {
                    var liGroupList = $(selectedUl).find('li.group');
                    var liSelected = $(this).parent().parent();
                    var currentSelection = $(selectedUl).find("li.group.currentSelection");
                    var index = $(liGroupList).index(liSelected);
                    var index2 = $(liGroupList).index(currentSelection);

                    if (evt.ctrlKey) {
                        if (index == index2) {
                            $(this).toggleClass('selected')
                            if ($(this).parent().find("li.selected").length)
                                liSelected.addClass("currentSelection");
                            else
                                liSelected.removeClass("currentSelection");
                        }
                        else if (index2 == -1) {
                            $(this).toggleClass('selected')
                            liSelected.addClass("currentSelection");
                        }
                    }
                    else {
                        liSelected.parent().find("li.currentSelection > ul > li.selected").removeClass("selected")
                        liSelected.parent().find("li.currentSelection").removeClass("currentSelection")
                        $(this).toggleClass('selected');
                        liSelected.addClass("currentSelection");
                    }
                })
                //Se for no loading inicial da query ele não necessita disto, só quando é a passagem de uma li para o grupo.
                if (!onloading) {
                    var allChildrenUl = $(selectedUl).children('li').children("ul")
                    var lastGroup = $(allChildrenUl).last()
                    $(lastGroup).append(selectedLi);
                    updateTotal();
                }

                //click no botão do caixote do lixo apaga
                $(selectedUl).children("li").children("ul").find("div.delete").click(function () {
                    var liParent = $(this).parent()
                    var ulParent = $(liParent).parent()
                    if ($(ulParent).children("li").length == 1) {
                        var allGroups = $(selectedUl).find("li.group")
                        var currIndex = $(allGroups).index($(ulParent.parent())) + 1
                        var numberOfGroups = $(selectedUl).find("li.group").length;
                        $(ulParent).parent().nextAll('li.group').each(function () {
                            var paddingleft = Number($(this).css("padding-left").replace("px", ""));
                            var width = Number($(this).css("width").replace("px", ""));
                            $(this).children('div.group-title').text(textos[lang]["G"] + " " + (currIndex++) + ' - ' + textos[lang]["PB"] + ': ').append('<input name="pagebreak" type="checkbox" value="true"/>')
                            $(this).animate({
                                paddingLeft: (paddingleft - 20) + "px",
                                width: (width + 20) + "px"
                            }, 500, function () { updateTotal() });
                        })
                        if (numberOfGroups > 1)
                            $(ulParent).parent().remove();
                    }
                    ms.multiSelect('deselect', liParent);
                });
            }
        }
    });
}
