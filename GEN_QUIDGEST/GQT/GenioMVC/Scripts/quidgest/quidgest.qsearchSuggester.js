Array.prototype.unique = function () {
    var a = this.concat();
    var b = this.concat();
    for (var i = 0; i < a.length; ++i) {
        var count = 0;
        for (var j = i + 1; j < a.length; ++j) {
            if (a[i].name == a[j].name && a[i].value == a[j].value)
                b.splice(j - count++, 1);
        }
        a = b;
        b = a.concat();
    }

    return a;
};

function compare(a, b) {
    if (a.hits < b.hits)
        return 1;
    if (a.hits > b.hits)
        return -1;
    return 0;
};

function initSearh(links){
	$("#search-input").autoSuggest(links , {
		minChars		: 1,
		keyDelay		: 140,
		startText		: "Search...",
		usePlaceholder	: true,
		queryParam		: "q",
		limitParam      : "spellcheck.count",
		retrieveLimit	: 10,
		afterRequest	: function(data, isLastRequest, query) {
							var suggestions = [];
							var collations = [];
							if(data.spellcheck) {
								data = data.spellcheck.suggestions;
								var index = 0;
								for (var x in data) {
									 if (data[x].hasOwnProperty('suggestion')) {
										$.each(data[x].suggestion, function(index, value) {
											suggestions.push({"name": value.word, "value": value.word, "hits": value.freq}); 
										});
									 }
									 if (data[x] == 'collation') {
										if(data.length > index+1) 
										{
											collations.push({"name": data[index+1], "value": unescape(data[index+1])}); 
										}
									 }
									 index++;
								}

								suggestions.sort(compare);
								suggestions = suggestions.concat(collations);
								suggestions = suggestions.unique();
							}

							query = query.replace(/^\s+|\s+$/g, '');
							if (suggestions.length < 10 && query && isLastRequest) {
								params = {};
								params["q"] = encodeURIComponent(decodeURIComponent(query));
								$.ajax({
									url: "http://localhost:8080/suggest",
									data: params,
									async: false,
									success: function (data, textStatus) {
										$.each(data.items, function (index, value) {
											suggestions.push({ "name": value.value, "value": value.value });
										});
									}
								});
								suggestions = suggestions.unique();
							}
							if (suggestions > 10)
								suggestions = suggestions.slice(0, 10);
							return suggestions;
						},
		showResultListWhenNoMatch :false,
		searchActive 	: false,
		beforeRequest	: function(string) {
			$('.qtip.ui-tooltip').qtip('hide');
			var index = string.lastIndexOf(',');
			if(index < 0)
				index = 0;
			else
				index = index + 1;
			return string.substring(index, string.length).toLowerCase();
		},
		selectionClick	: function(element) {
		},
		resultAdded	: function(elementBefore, data) {
						params = {};
						params["q"] = encodeURIComponent(decodeURIComponent(data.name));
						elementBefore.qtip({
							content: {
								text: "Loading...",
								title: {
									text: "Also matches"
								},
								ajax: {
									url: "http://localhost:8080/expansions",
									data: params,
									once: true,
									success: function(data, status) {
										var items = [];
										// Process
										if ('items' in data && data.items.length > 0) {
											items = data.items.join("</br>");
										} else {
											items = "No expansions";
										}
										this.set('content.text', items);
										// only hide if we received data
										setTimeout('$("#ui-tooltip-' + this.id + '").qtip("hide")', 5000);
									}
								}
							},
							style: {
								classes: 'ui-tooltip-shadow exp-tooltip'
							},
							position: {
								my: 'top left',
								at: 'bottom center',
								target: !$.fn.qtip.plugins.iOS ? 'mouse' : false,
								adjust: {
									x: 17,
									y: 10
								}
							},
							show: {
								event: 'mouseenter ' + ($.fn.qtip.plugins.iOS ? 'click' : '')
							},
							hide: {
								event: 'mouseleave ' + ($.fn.qtip.plugins.iOS ? 'click' : ''),
								effect: function() {
									$(this).fadeOut('fast');
								}
							},
							events: {
								show: function(event, api) {
									if (event.target.innerText.indexOf('Loading...') == -1) {
										setTimeout('$("#' + event.target.id + '").qtip("hide")', 5000);
									}
								}
							}
						});
		}
	});
};