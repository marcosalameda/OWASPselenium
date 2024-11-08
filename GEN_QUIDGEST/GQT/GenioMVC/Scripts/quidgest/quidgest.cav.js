/// Operações disponíveis
/// Operações Binárias AND  OR  EQ  GT  GET  LT  LET  NEQ  LIKE  BETWEEN  IN || Operações Unárias  ISNULL  NOT
/// PRO Math!
///"N": {"AND":"∧", "OR":"∨", "EQ":"=", "GT":">", "GET":">=", "LT":"<", "LET":"<=", "NEQ":"≠", "BETWEEN":"entre", "IN":"∃" },
var types_to_operands = {
    "A":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "GT": quidgestGlobals.Resources.E_MAIOR_QUE55118, "GET": quidgestGlobals.Resources.E_MAIOR_OU_IGUAL_A12958, "LT": quidgestGlobals.Resources.E_MENOR_QUE43521, "LET": quidgestGlobals.Resources.E_MENOR_OU_IGUAL_A33027, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "LIKE": quidgestGlobals.Resources.CONTEM4707, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087, "IN": quidgestGlobals.Resources.UM_DE14280 },
    "D":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "GT": quidgestGlobals.Resources.E_MAIOR_QUE55118, "GET": quidgestGlobals.Resources.E_MAIOR_OU_IGUAL_A12958, "LT": quidgestGlobals.Resources.E_MENOR_QUE43521, "LET": quidgestGlobals.Resources.E_MENOR_OU_IGUAL_A33027, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087, "ISNULL": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392 },
    "H":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "GT": quidgestGlobals.Resources.E_MAIOR_QUE55118, "GET": quidgestGlobals.Resources.E_MAIOR_OU_IGUAL_A12958, "LT": quidgestGlobals.Resources.E_MENOR_QUE43521, "LET": quidgestGlobals.Resources.E_MENOR_OU_IGUAL_A33027, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087 },
    "B":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330 },
    "N":
        { "EQ": "=", "GT": ">", "GET": ">=", "LT": "<", "LET": "<=", "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087, "IN": quidgestGlobals.Resources.UM_DE14280 },
    "T":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "GT": quidgestGlobals.Resources.E_MAIOR_QUE55118, "GET": quidgestGlobals.Resources.E_MAIOR_OU_IGUAL_A12958, "LT": quidgestGlobals.Resources.E_MENOR_QUE43521, "LET": quidgestGlobals.Resources.E_MENOR_OU_IGUAL_A33027, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087 },
    "$":
        { "EQ": "=", "GT": ">", "GET": ">=", "LT": "<", "LET": "<=", "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "BETWEEN": quidgestGlobals.Resources.ESTA_ENTRE61087, "IN": quidgestGlobals.Resources.UM_DE14280 },
    "ARRAY":
        { "EQ": quidgestGlobals.Resources.E_IGUAL_A44445, "NEQ": quidgestGlobals.Resources.DIFERENTE_DE49330, "IN": quidgestGlobals.Resources.UM_DE14280, "ISNULL": quidgestGlobals.Resources.NAO_ESTA_DEFINIDO42392 }
};

var order = { "ASC": "Asc", "DESC": "Desc" };

var logicos = { "0": quidgestGlobals.Resources.E_FALSO54943, "1": quidgestGlobals.Resources.E_VERDADEIRO09772 };

var total = {
    "A":
        { "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "D":
        { "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "H":
        { "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "B":
        { "SUM": "Soma", "AVG": "Média", "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "N":
        { "SUM": "Soma", "AVG": "Média", "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "T":
        { "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" },
    "$":
        { "SUM": "Soma", "AVG": "Média", "COUNT": "Total de Elementos", "MAX": "Máximo", "MIN": "Mínimo" }
};

var textos = {
    "PT":
        { "V": quidgestGlobals.Resources.VALOR32448 + ":&nbsp;", "O": quidgestGlobals.Resources.OPERADOR26143 + ":&nbsp;", "G": "Grupo", "PB": "Quebra de Página", "order": quidgestGlobals.Resources.MOVER62644 }
}

var tipoAcesso = {
    "PUB": "Pública",
    "PES": "Pessoal",
    "INA": "Inactiva" 
}

var lang = "PT";

// funções auxiliares para construção de links para url
//arguments: table
function createTableRelationUrl() {
    var url = './Cav/GetTableRelations';
    var names = ['table'];
    return createGenericUrl(url, names, arguments);
}

// a construção do Json completo do pedido fica numa função auxiliar para não ter de se alterar em vários sitios de cada vez que é necessário modificar o pedido
function getFullJsonRequest(extra, table_name) {
    var res = {        
        fields: $("#fields").val(),
        orderby: $("#orderby").val(),
        conditions: $("#conditions").val(),
        groupby: $("#groupby").val(),
        total: $("#total").val(),        
        yearmode: $("#yearmode").val(),
        relations: $("#relations").val()
    };

    if (table_name != undefined)
        res["table"] = table_name;
    if (extra) {
        res["access"] = $("#access").val();
        res["title"] = $("#queryname").val();
    }

    return res;
}


////arguments: system
//function createIndexUrl() {
//    var url = './Home/Index';
//    var names = ['system'];
//    return createGenericUrl(url, names, arguments);
//}

////arguments: system, table, years, yearmode
//function createFieldsUrl() {
//    var url = './Home/Fields';
//    var names = ['system', 'table', 'years', 'yearmode'];
//    return createGenericUrl(url, names, arguments);
//}

// função genérica para construção do url
// caso existam parametros valida-os e aplica a cada um a função de escape
function createGenericUrl(url, names, parameters) {
    if (url == undefined || names == undefined || parameters == undefined) {
        //createModalDialog_Custom("Erro", "Não é possível executar o pedido com os parâmetros dados");
        return;
    }
    if (names.length != parameters.length) {
        //createModalDialog_Custom("Erro", "Não é possível executar o pedido com os parâmetros dados");
        return;
    }
    var result = url;
    if (names.length > 0) {
        result += '?';
        for (var i = 0; i < names.length; i++) {
            if (parameters[i] == undefined) {
                //createModalDialog_Custom("Erro", "Não é possível executar o pedido com os parâmetros dados");
                return;
            }
            if (i > 0)
                result += '&';
            result += names[i] + '=' + escape(parameters[i]);
        }
    }
    return result;
}

function constructValue(value, array) {
    var auxV = value;

    if (array.length > 0) {
        auxV = $(array).find("option:contains('" + value + "')").val();
    }

    var elem = {}
    elem["ValueReference"] = auxV;
    elem["Operation"] = "LITERAL";

    return elem;
}

function JSONConditionsCreation() {        
    var camposCond = $("#ms-ConditionsSelected .ms-selection ul.ms-list > li");

    var pedidoCond = {};
    pedidoCond["Operation"] = "AND";
    pedidoCond["Operands"] = [];

    for (var i = 0; i < camposCond.length; i++) {
        var nome = $(camposCond[i]).attr("ms-value");

        var val = $(camposCond[i]).children(".optionValues")
        var operation = $(val).eq(0).val();
        var value = $(val).eq(1).val(); 
        var array = "";

        if ($(val).eq(2).length > 0) {
            array = $(val).eq(1);
            value = $(val).eq(2).val();
        }

        var showNulls = $(camposCond[i]).find("div.condition-show-nulls > input:checked").length > 0;

        pedidoCond["Operands"][i] = {};
        pedidoCond["Operands"][i]["Operation"] = operation;
        pedidoCond["Operands"][i]["Operands"] = [];
        pedidoCond["Operands"][i]["Operands"][0] = {}
        pedidoCond["Operands"][i]["Operands"][0]["ValueReference"] = nome;
        pedidoCond["Operands"][i]["Operands"][0]["Operation"] = "FIELD";
        pedidoCond["Operands"][i]["Operands"][0]["ShowNulls"] = showNulls;

        if (operation == "IN" || operation == "BETWEEN") {
            var values = value.split(',');
            if (values.length < 1 || (values.length < 2 && operation == "BETWEEN"))
                console.log("Ocorreu um erro na construção das condições do pedido");
                //createModalDialog_Custom("Erro", "Ocorreu um erro na construção das condições do pedido.");

            for (var j = 0; j < values.length; j++) {
                pedidoCond["Operands"][i]["Operands"][1 + j] = constructValue($.trim(values[j]), array);
            }
        }
        else {
            pedidoCond["Operands"][i]["Operands"][1] = constructValue(value, array);
        }
    }
    $("#conditions").val(JSON.stringify(pedidoCond))
}

function JSONOrderByCreation() {
    //FORMAÇÃO DO JSON PARA O ORDERBY
    var camposOrder = $("#ms-OrderBySelected .ms-selection ul.ms-list > li");
    var pedidoOrder = [];
    for (var i = 0; i < camposOrder.length; i++) {
        var nome = $(camposOrder[i]).attr("ms-value");
        var oper = $(camposOrder[i]).find("div.text-lis").children("div").children("div.selectedOrder").attr("key")
        var splited = nome.split('.');
        pedidoOrder[i] = {};
        pedidoOrder[i]["Direction"] = oper;
        pedidoOrder[i]["Field"] = {};
        pedidoOrder[i]["Field"]["TableId"] = splited[0];
        pedidoOrder[i]["Field"]["FieldId"] = nome; // o FieldId é o nome completo - tabela.campo
    }
    $("#orderby").val(JSON.stringify(pedidoOrder))
}

function JSONGroupbyAndTotalCreation() {

    //FORMAÇÃO DO JSON PARA OS CAMPOS
    var fieldsList = $("#columnList > ul > li");
    var pedidoFields = [];

    for (var j = 0; j < fieldsList.length; j++) {
        pedidoFields[j] = {};
        var field = $(fieldsList[j]).attr("ms-value");
        var splited = field.split('.');

        //if ($(fieldsList[j]).find('div.yearMode > input:checked').length)
        //    pedidoFields[j]["MultiDatasource"] = true;

        pedidoFields[j]["FieldId"] = field;
        pedidoFields[j]["TableId"] = splited[0];
        //pedidoFields[j]["Title"] = $(fieldsList[j]).find("div.text-lis").find("div").text();
        // a label dos campos foi alterada, portanto vai buscar o nome do campo aos options construídos no carregamento da página
        // para se obter o nome da tabela: $('#FieldsSelected > optgroup[ms-value="' + splited[0] + '"]').attr('label')
        //pedidoFields[j]["Title"] = $('#FieldsSelected > optgroup[ms-value="' + splited[0] + '"] > option[value="' + field + '"]').text();
        pedidoFields[j]["Title"] = $(fieldsList[j]).find('div.colName > input').val()
    }


    //FORMAÇÃO DO JSON PARA O GROUPBY
    var groupList = $("#ms-GroupBySelected .ms-selection ul.ms-list > li.group");
    var pedidoGroup = [];
    for (var j = 0; j < groupList.length; j++) {
        var fields = $(groupList[j]).children("ul").children("li");

        if (fields.length > 0) {
            pedidoGroup[j] = {};
            pedidoGroup[j]["Fields"] = [];
            pedidoGroup[j]["PageBreak"] = ($(groupList[j]).children("div.group-title").children("input:checked").length == 0) ? false : true;

            for (var k = 0; k < fields.length; k++) {
                pedidoGroup[j]["Fields"][k] = {};
                var field = $(fields[k]).attr("ms-value");
                var splited = field.split('.');
                pedidoGroup[j]["Fields"][k]["FieldId"] = field; // o FieldId é o nome completo - tabela.campo
                pedidoGroup[j]["Fields"][k]["TableId"] = splited[0];
                //pedidoGroup[j]["Fields"][k]["Title"] = $(fields[k]).text();
                pedidoGroup[j]["Fields"][k]["Title"] = $('#columnList > ul > li[ms-value="' + field + '"] > div.colName > input').val();
            }
        }
    }
    // isto passa a ser feito mais à frente porque ainda faltam (possivelmente) campos de totalizadores
    //$("#groupby").val(JSON.stringify(pedidoGroup))

    //FORMAÇÃO DO JSON PARA OS TOTALIZADORES
    var groupTotalList = $("#ms-TotalSelect .ms-selectable ul.ms-list > li");
    //alert(pedidoGroup.length + ' ' + groupTotalList.length);
    if (pedidoGroup.length != groupTotalList.length && (pedidoGroup.length + 1) != groupTotalList.length)
        //createModalDialog_Custom("Erro", "Ocorreu um erro na construção dos totalizadores do pedido.");
        console.log('Ocorreu um erro na construção dos totalizadores do pedido');
    else {
        // só vão para os totalizadores dos grupos os campos de grupos
        // quando não existem campos para grupos:
        // (groupList + 1) == pedidoGroup.length 
        // todos os totalizadores são adicionados aos select fields
        for (var i = 1; i < groupTotalList.length && i <= pedidoGroup.length; i++) {
            var fields = $(groupTotalList[i]).children("ul").children("li");
            for (var j = 0; j < fields.length; j++) {
                var totaliz = $(fields[j]).find("input");
                var nomeCampo = $(fields[j]).attr("ms-value");
                var fieldsGroup = pedidoGroup[i - 1]["Fields"];
                var splited = nomeCampo.split('.');
                for (var k = 0; k < totaliz.length; k++) {
                    if (totaliz[k].checked) {
                        var next = fieldsGroup.length;
                        fieldsGroup[next] = {};
                        fieldsGroup[next]["FieldId"] = nomeCampo;
                        fieldsGroup[next]["TableId"] = splited[0];
                        fieldsGroup[next]["TotalType"] = $(totaliz[k]).val();
                        fieldsGroup[next]["Title"] = splited[1] + " " + $(totaliz[k]).val();
                    }
                }
            }
        }
    }
    // passa-se o groupby para aqui, uma vez que os totalizadores vão no groupby
    $("#groupby").val(JSON.stringify(pedidoGroup))

    if (groupTotalList.length == (pedidoGroup.length + 1)) {
        // este é o caso em que não há grupos, mas foram pedidos totalizadores
        var fields = $(groupTotalList[groupList.length - 1]).children("ul").children("li");
        for (var j = 0; j < fields.length; j++) {
            var totaliz = $(fields[j]).find("input");
            var nomeCampo = $(fields[j]).attr("ms-value");
            var splited = nomeCampo.split('.');
            for (var k = 0; k < totaliz.length; k++) {
                if (totaliz[k].checked) {
                    var next = pedidoFields.length;
                    pedidoFields[next] = {};
                    pedidoFields[next]["FieldId"] = nomeCampo;
                    pedidoFields[next]["TableId"] = splited[0];
                    pedidoFields[next]["TotalType"] = $(totaliz[k]).val();
                    pedidoFields[next]["Title"] = splited[1] + " " + $(totaliz[k]).val();
                }
            }
        }
    }

    // passam-se os fileds para aqui, uma vez que também podem levar totalizadores
    $("#fields").val(JSON.stringify(pedidoFields))
}

function JSONcreation() {
    //falta trazer os dados dos campos selecionados
    JSONConditionsCreation();    
    JSONOrderByCreation();
    JSONGroupbyAndTotalCreation();        
}


function UpdateDetails(url) {
    console.log("IsDirty()");
    JSONcreation();
    $.ajax({
        url: url,
        data: JSON.stringify(getFullJsonRequest()),
        contentType: 'application/json',
        type: "POST",
        success: function (data) {
            console.log(data);
            //location.href = $("#one").parent().attr("href");
            return false;
        }
    })
}

function updateGroups(elem, remove) {
    $(function () {
        //var optionExists = $('#GroupBySelected > optgroup > option[value="' + $(elem).attr("ms-value") + '"]');
        var container = $("#ms-GroupBySelected > div.ms-selectable > ul.ms-list");
        var optionExists = $(container).find("li[ms-value='" + $(elem).attr("ms-value") + "']");

        if ($(optionExists).length > 0) {
            if (remove) {
                $('#ms-GroupBySelected > div.ms-selection > ul.ms-list > li.group > ul > li[ms-value="' + $(elem).attr("ms-value") + '"]').children("div.delete").click()
                var optgroup = $(container).find('li.ms-optgroup-container > ul.ms-optgroup')
                $(optgroup).children('li[ms-value="' + $(elem).attr("ms-value") + '"]').remove()
                //Tou a colocar a length a 1 porque é a li correspondente ao titulo da tabela, se não tiver o collapse da tabela então isto não vale a pena estar aqui
                if ($(optgroup).children('li').length == 1)
                    $(optgroup).remove()
            }
            else {
                appendNewLi("GroupBySelected", elem, container);
            }
        } else {
            appendNewLi("GroupBySelected", elem, container);
        }
        updateTotal()
    });
}

function updateOrder(elem, remove) {
    $(function () {
        var container = $("#ms-OrderBySelected > div.ms-selectable > ul.ms-list");
        var optionExists = $(container).find("li[ms-value='" + $(elem).attr("ms-value") + "']");
        if ($(optionExists).length == 0) {
            appendNewLi("OrderBySelected", elem, container);
        }
        else {
            if (remove) {
                $('#ms-OrderBySelected > div.ms-selection > ul.ms-list > li[ms-value="' + $(elem).attr("ms-value") + '"]').children("div.delete").click()
                //  $(optionExists).remove()
                var optgroup = $(container).find('li.ms-optgroup-container > ul.ms-optgroup')
                $(optgroup).children('li[ms-value="' + $(elem).attr("ms-value") + '"]').remove()
                //Tou a colocar a length a 1 porque é a li correspondente ao titulo da tabela, se não tiver o collapse da tabela então isto não vale a pena estar aqui
                if ($(optgroup).children('li').length == 1)
                    $(optgroup).remove()
            }
            else {
                appendNewLi("OrderBySelected", elem, container);
            }
        }
    });
}


function appendNewLi(into, elem, container) {
    $(function () {
        var parentID = $(elem).parent().attr('ms-value');
        var parentDesc = $(elem).attr('ms-group');
        var targetContainer = $('#ms-' + into).find('div.ms-selectable > ul.ms-list > li.ms-optgroup-container > ul.ms-optgroup[ms-value="' + parentID + '"]');

        if (targetContainer.length == 0) {
            container.append('<li class="ms-optgroup-container collapsed" id="ms-FieldsSelected-optgroup-' + container.children().length + '"><ul class="ms-optgroup" ms-value="' + parentID + '"><li class="ms-optgroup-label collapse">' + parentDesc + '</li></ul></li>');
            targetContainer = $('#ms-' + into).find('div.ms-selectable > ul.ms-list > li.ms-optgroup-container > ul.ms-optgroup[ms-value="' + parentID + '"]');
        }

        var selectableLi = $('<li class="ms-elem-selectable" ms-type="' + $(elem).attr('ms-type') + '" ms-value="' + $(elem).attr('ms-value') + '" ms-group="' + $(elem).attr('ms-group') + '">' + $(elem).text() + '</li>');

        if ($(elem).attr('title'))
            selectableLi.attr('title', $(elem).attr('title'));
        if ($(elem).attr('disabled') || $("#ms-" + into).attr('disabled')) {
            selectableLi.attr('disabled', 'disabled');
            selectableLi.addClass(multiSelects.settings.disabledClass);
        }

        selectableLi.click(function () {
            $("#ms-" + into).multiSelect('select', $(selectableLi));
        });

        targetContainer.append(selectableLi);
    });
}

function initPaginationButtons() {
    $('#fieldNext').on('click', function () {
        $('#cavtabs a[data-target="#condicoes"]').click();
    });


    $('#condBack').on('click', function () {
        $('#cavtabs a[data-target="#campos"]').click();
    });
    $('#condNext').on('click', function () {       
        $('#cavtabs a[data-target="#grupos"]').click();
    });


    $('#groupBack').on('click', function () {
        $('#cavtabs a[data-target="#condicoes"]').click();
    });
    $('#groupNext').on('click', function () {
        $('#cavtabs a[data-target="#ordenacao"]').click();
    });


    $('#orderBack').on('click', function () {
        $('#cavtabs a[data-target="#grupos"]').click();
    });
    $('#orderNext').on('click', function () {
        $('#cavtabs a[data-target="#totais"]').click();
    });


    $('#totalBack').on('click', function () {
        $('#cavtabs a[data-target="#ordenacao"]').click();
    });
    $('#totalNext').on('click', function () {
        $('#cavtabs a[data-target="#executar"]').click();
    });


    $('#execBack').on('click', function () {
        $('#cavtabs a[data-target="#totais"]').click();
    });
}


function isDirt() {

    var condition = $("#conditions").val();
    var orderBy = $("#orderby").val();
    var groupby = $("#groupby").val();
    var fields = $("#fields").val();

    console.log(condition);
    console.log(orderBy);
    console.log(groupby);
    console.log(fields);

    JSONcreation();

    if (condition != $("#conditions").val() || orderBy != $("#orderby").val() || groupby != $("#groupby").val() || fields != $("#fields").val())
        return true;
    else
        return false;
}


function CreatePageLinks(current_page, total_pages, url) {
    //Page [current page number] of [total number of pages] << < Prev Next > >>
    var next_page = current_page == total_pages ? current_page : current_page + 1;
    var prev_page = current_page == 1 ? current_page : current_page - 1;

    var htmlOut = '<div style="display:flex;"><span style="margin-top: 0.3rem;margin-right: 0.3rem;"><strong> ' + current_page + ' </strong>/<strong> ' + total_pages + ' </strong></span>';

    htmlOut += '<ul id="query-pagination" class="e-pagination">';
    htmlOut += '<li class="e-pagination__item"><a class="e-pagination__link page-button" href="'+url+'" page ="1" >&lt;&lt;</a></li>';
    htmlOut += '<li class="e-pagination__item"><a class="e-pagination__link page-button" href="' + url + '" page="' + prev_page + '">&lt;</a></li>';
    htmlOut += '<li class="e-pagination__item"><a class="e-pagination__link page-button" href="' + url + '" page="' + next_page + '">&gt;</a></li>';
    htmlOut += '<li class="e-pagination__item"><a class="e-pagination__link page-button" href="' + url + '" page="' + total_pages +'">&gt;&gt;</a></li>';
    htmlOut += '</ul></div>';    

    $('#pagination').html(htmlOut);
}


function ExecQuery(url, page) {
    //$('#results-section').html('<h1 class="waiting-message">A carregar resultados...</h1>');
    QAnimation.showPleaseWait();
    $('#record-count').html('');
    $('#pagination').html('');

    JSONcreation();

    $.post(url + '&page=' + page, { data: JSON.stringify(getFullJsonRequest()) }, function (data) {
		$('#record-count').html('<div class="e-counter"><i class="glyphicons glyphicons-sort e-counter__icon"></i><span class="e-counter__text">' + data["record_count"] + '</span></div>');
        //$('#record-count').html('<span>Foram encontrados <strong id="record-count-value">' + data["record_count"] + '</strong> registos</span>');

        $('#results-section').fadeOut(500, function () {
            CreatePageLinks(data['current_page'], data['total_pages'],url);
            $('#results-section').html(data["results"]);
            $('#results-section').fadeIn();  
            QAnimation.hidePleaseWait();  

            $('.page-button').on('click', function (ev) {
                ev.preventDefault();
                var $thisLink = $(this);
                var page = $thisLink.attr("page");
                ExecQuery($thisLink.attr("href"),page);
                return false;
            });
        });       
    })
        .fail(function (er) {
            console.log(er);
    })
    ; // Fim do POST
}


function ResetQuery() {
    $('#Sthree').html('');
    $('#Sfour').html('');
    $('#Sfive').html('');
    $('#Ssix').html('');
    $('#Sseven').html('');
    $('#cavtabs a[data-target="#campos"]').click();
}

/**
 * Create a new empty report
 * @param {string} url The url for ajax request 
*/
function NewReport(url) {
    console.log(url);
    var areaBase = $('.form-horizontal').attr('area');
    $.ajax({
        url: url,        
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify({ area: areaBase }),
        success: function (data) {
            if (data.Success == false) {
                bootbox.alert(data.Message);
            }
            else {
                //$('#dropblearea').html(data);
                $('#cavContent').html(data);
                $('#formContainer').show();
                ResetQuery();
            }
        }
    })
}

/**
 * Load report from server
 * @param {string} url The url for ajax request
 * @param {string} queryID The report ID
*/
function LoadReport(url, queryID) {    
    $.ajax({
        url: url,
        contentType: 'application/json',
        type: "GET",
        data: { queryid: queryID },
        success: function (data) {
            $('#cavContent').html(data);
            $('#cavtabs').ready(function () {
                $('#cavtabs a[data-target="#executar"]').click();
            });
        }
    })
}

/**
 * Open a report
 * @param {string} url The url for ajax request 
*/
function OpenReport(url, loadQueryUrl) {
    $.ajax({
        url: url,
        contentType: 'application/json',
        type: "GET",
        success: function (data) {
            var message = "";
            message += "<div class='scrollableQueryList'>";
            message += "<table class='c-table results' >";
            message += "<thead class='c-table__head' ><th>" + quidgestGlobals.Resources.NOME_DA_CONSULTA15812 + "</th><th>" + quidgestGlobals.Resources.ACESSO_DA_CONSULTA62026+"</th></thead>";
            message += "<tbody class='c-table__body'>";
            for (var i = 0; i < data.message.length; i++) {
                var access = tipoAcesso[data.message[i].Acess];
                message += "<tr>\
								<td><a href='#' data-dismiss=\"modal\" onclick=\"LoadReport('"+ loadQueryUrl + "','" + data.message[i].ID + "');\">" + data.message[i].Title + "</a>\</td>\
								<td>" + access + "</td>\
							</tr>";
            }
            message += "</tbody></table>";
            message += "</div>";
            createModalDialog_Custom(quidgestGlobals.Resources.ESCOLHA_A_CONSULTA47607, message);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

/**
 * Create a modal dialog with backdrop
 * @param {string} title The modal title
 * @param {string} message the modal body content
*/
function createModalDialog_Custom(title, message) {
    // Apaga conteúdos que possam lá estar
    $('#dialog .modal-header .modal-header-title').empty();
    $('#dialog .modal-body').empty();

    // Coloca um título no modal dialog
    $('#dialog .modal-header .modal-header-title').html(title);

    // Coloca a mensagem no modal dialog
    $('#dialog .modal-body').html(message);

    // Abre o modal dialog
    $('#dialog').modal({
        show: true,
        backdrop: true
    });
}

