$.fn.extend({
    treeFor: function (options) {
        return this.each(function () {
            $(this).data('treeFor', new QTreeTable(this, options));
        }).data('treeFor');
    },
    treeSeeMoreFor: function (selectList) {
        return this.each(function () {
            $(this).data('treeFor', new QTreeTableSeeMore(this, selectList));
        }).data('treeFor');
    }
});


function QTreeTable(element, data) {

    function _build(data, level) {

        var levelClass0 = "n-treeview__item";
        var levelClasses = [];
        //    "i-chip i-chip--primary mb-3",
        //    "i-chip n-treeview__chip"
        //];

        var html = '<ul class="branch">';
        $.each(data, function (idx, item) {
            // Check if has childrens / An array will return 'object'
            var hasChildren = typeof item.Children === 'object' && item.Children.length > 0;
            if (level > 0 && hasChildren) {
                html += '<li key="' + item.Key + '" class="branch" style="display: none">';
            }
            else if (level > 0) {
                html += '<li key="' + item.Key + '" style="display: none">';
            }
            else {
                html += '<li key="' + item.Key + '">';
            }

            //support for different styles according to the item level
            var ic = levelClass0;
            if (level < levelClasses.length)
                ic = levelClasses[level];

            html += '<div class="item ' + ic + '">';
            if (hasChildren) {
                html += '<i class="indicator glyphicons glyphicons-plus-sign"></i>';
            }
            else
                html += '<div class="spacer"> </div>';

            if (item.Image !== undefined && item.Image !== null)
                html += item.Image;
            html += item.Text;
            if (item.Action !== undefined && item.Action !== null)
                html += item.Action;
            html += '</div>';

            if (hasChildren) {
                html += _build(item.Children, level + 1);
            }

            html += '</li>';
        });
        html += '</ul>';
        return html;
    }

    this.Reload = function (selectedKey) {
        if (selectedKey) {
            $('#' + this._containerId).attr("selectedKey", selectedKey);
        }
        makeAjaxRequest(this._requestUrl, this._containerId, this._element.attr('id'));
    };

    this.ExpandItem = function (coditem) {
        var item = this._element.find("li[key='" + coditem + "']");
        if (item.length > 0)
            _expandUpRecursive(item);
    };

    function _expandUpRecursive(item) {
        //console.log('expand', item);
        item.click();
        //find parent
        var parent = item.parent().parent('li');
        if (parent.length > 0)
            _expandUpRecursive(parent);
    }

    //constructor code
    this._element = $(element);    
    this._requestUrl = data.requestsUrl;
    this._containerId = data.container;

    this._element.append(_build(data.tree, 0));
    QTreeTable_AddClickEvent(this._element);
    var sk = $('#' + this._containerId).attr("selectedKey");
    if (sk)
        this.ExpandItem(sk);
}


function QTreeTable_AddClickEvent(element) {
    var openedClass = 'glyphicons-minus-sign';
    var closedClass = 'glyphicons-plus-sign';
    var tree = $(element);

    //Add click events
    tree.find('li').each(function () {
        $(this).on('click', function (e) {
            //li with children ul
            if (this === e.target && $(this).has("ul")) {
                var icon = $(this).children('.item').children('.indicator:first');
                icon.toggleClass(openedClass + " " + closedClass);
                $(this).children('ul').children().toggle();
            }
        });
    });

    //fire event from the icon
    tree.find('.indicator').each(function () {
        $(this).on('click', function (e) {
            $(this).closest('li').click();
        });
    });

    tree.find('.item').each(function () {
        $(this).on('click', function (e) {
            if (this === e.target) {
                $(this).closest('li').click();
            }
        });
    });
}


function QTreeTableSeeMore(element, selectList) {

    function _build(data, isTop, parentField, callback, baseArea) {
        // Vai ser utiizado para "Ver mais ..." em arvore
        var ul = $('<ul class="branch"></ul>');
        $.each(data, function (idx, item) {
            // Check if has childrens / An array will return 'object'
            var hasChildren = typeof item.Children === 'object' && item.Children.length > 0;
            var li = $('<li></li>');
            if (!isTop) {
                li.hide();
                if (hasChildren) {
                    li.addClass('branch');
                }
            }
            var div = $('<div class="item n-treeview__item"></div>');//.data('branch', item);
            if (hasChildren) {
                var i = $('<i class="indicator glyphicons glyphicons-plus-sign"></i>');
                div.append(i).append(item.Text);
                li.append(div);
                li.append(_build(item.Children, false, parentField, callback, baseArea));
            } else {
                div.append($('<div class="spacer"> </div>'));
                div.append(item.Text);// No submenu
                li.append(div);
            }
            // Callback event
            if (callback && item.Area === baseArea) {
                var option = $('<div class="options b-btn-group"><div class="options-button"><i class="glyphicons glyphicons-play"></i></div></div>');
                $(option).find('.options-button').click({ branch: item, element: parentField }, callback);
                div.append(option);
            }
            ul.append(li);
        });

        return ul;
    }

    var treeControl = $(element);
    var baseArea = ($(selectList).attr('pers-cs-area').split('.')[0] || '').toUpperCase();
    var params = { id: selectList.data("form-key") };
    $.extend(params, _getDependentFieldsValue(selectList));
    var link = selectList.data("see-more-tree-url");

    // Collect request parameters used to filter the queries
    var targetDiv = treeControl.parent();
    var inputs = $("input:not(:button), select", targetDiv);
    var params2 = GetPostRquestParameters(inputs, targetDiv.attr('id'));
    $.extend(params, params2);

    $.ajax({
        type: 'GET',
        data: params,
        url: link,
        success: function (data) {
            if (data.Success && data.Data) {
                var callback = function (event) {
                    var branch = event.data.branch;
                    var selectList = event.data.element;
                    selectList.trigger("DBEditSetValue", branch.Key);
                    // Hide PopUp
                    $(this).closest('#modal-dbedit').modal('hide');
                };

                // Avoid repeating the request if the data is the same
                treeControl.data('tree', true);
                //Build HTML
                treeControl.append(_build(data.Data, true, selectList, callback, baseArea));
                QTreeTable_AddClickEvent(treeControl);
            } else if (data.Success && data.Data === null) {
                treeControl.append(quidgestGlobals.Resources.LISTA_ESTA_VAZIA);
            }
        },
        error: function () {
            treeControl.append(quidgestGlobals.Resources.OCORREU_UM_ERRO_AO_P53091);
        }
    });
}


function TreeTable(tree) {

    //---------------------------------------------------------
    var tree_toggle = function (node) {
        //check if its expanded or collapsed
        var expander = node.children('td').first().children('div.tree-expander').first();
        if (expander.hasClass('expanded')) {
            //toggle the node to collapsed state
            tree_hide_recurse(node);
            expander.addClass('collapsed');
            expander.removeClass('expanded');
        }
        else {
            //toggle the node to expanded state
            tree_show_recurse(node);
            expander.removeClass('collapsed');
            expander.addClass('expanded');
        }
    };
    //---------------------------------------------------------
    var tree_toggle_all = function (node) {
        //check if its expanded or collapsed
        var expander = node.find('thead tr th').first().children('div.tree-expander').first();
        if (expander.hasClass('allexpanded')) {
            tree.find('tbody tr').filter("[tree-parent!='']").hide();
            $('#ValMenutree div.tree-expander').addClass('collapsed').removeClass('expanded');
            expander.addClass('allcollapsed');
            expander.removeClass('allexpanded');
        }
        else {
            tree.find('tbody tr').filter("[tree-parent!='']").show();
            $('#ValMenutree div.tree-expander').removeClass('collapsed').addClass('expanded');
            expander.removeClass('allcollapsed');
            expander.addClass('allexpanded');
        }
    };

    //---------------------------------------------------------  
    var tree_get_childs = function (node) {
        var nodeid = node.attr('tree');
        return node.siblings('[tree-parent="' + nodeid + '"]');
    };
    //---------------------------------------------------------
    var tree_show_recurse = function (node) {
        tree_get_childs(node).each(function (index, value) {
            var child = $(value);
            child.show();
            var expander = child.children('td').first().children('div.tree-expander').first();
            if (expander.hasClass('expanded'))
                tree_show_recurse(child);
        });
    };
    //---------------------------------------------------------
    var tree_hide_recurse = function (node) {
        tree_get_childs(node).each(function (index, value) {
            $(value).hide();
            tree_hide_recurse($(value));
        });
    };
    //---------------------------------------------------------

    //hide all the subitems
    tree.find('tbody tr').filter("[tree-parent!='']").hide();

    //calculate all the row ids that are expandable
    var expandables = [];
    tree.find('tbody tr').each(function (index, value) {
        var x = $(value).attr('tree-parent');
        if (x !== '' && $.inArray(x, expandables) === -1)
            expandables.push(x);
    });

    //find all the rows of the table to add an expander element
    tree.find('tbody tr').each(function (index, value) {
        if ($.inArray($(value).attr('tree'), expandables) >= 0) {
            //add a expander to the first cell of the table
            var firstCell = $(value).children('td').first();
            var newExpander = $('<div class="tree-expander collapsed"/>');
            firstCell.prepend(newExpander);

            //setup the click event
            newExpander.click(function () {
                tree_toggle($(value));
            });
        }
        else {
            //add a padding element
            var firstCell = $(value).children('td').first();
            var newPadder = $('<div class="tree-padder"/>');
            firstCell.prepend(newPadder);
        }

    });

    //Add paddings according to the level of tree
    tree.find('tbody tr').each(function (index, value) {
        //TODO: mudar para um metodo recursivo que não dependa do formato dos id's
        var level = $(value).attr('tree').split('.').length - 1;
        for (i = 0; i < level; i++) {
            var firstCell = $(value).children('td').first();
            var newPadder = $('<div class="tree-padder"/>');
            firstCell.prepend(newPadder);
        }
    });

    //Add the div for the All expand-collapse button
    var newExpander = $('<div class="tree-expander allcollapsed"/>');
    var firstCell = tree.find('thead tr th').first();
    firstCell.prepend(newExpander);

    //setup the click event
    newExpander.click(function () {
        tree_toggle_all(tree);
    });

}
