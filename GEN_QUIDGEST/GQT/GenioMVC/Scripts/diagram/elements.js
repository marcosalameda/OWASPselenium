(function (global) {	// BEGIN CLOSURE

    var Joint = global.Joint,
     Element = Joint.dia.Element,
     point = Joint.point;

    /**
    * @name Joint.dia.org
    * @namespace Holds functionality related to Org-charts.
    */
    var org = Joint.dia.org = {};

    /**
    * Predefined arrow. You are free to use this arrow as the option parameter to joint method.
    * @name arrow
    * @memberOf Joint.dia.org
    * @example
    * var arrow = Joint.dia.org.arrow;
    */
    

	org.createBase = function (style, dia, i) {
        return Element.extend({
            init: function (properties) {
                var p = Joint.DeepSupplement(this.properties, properties, style);
                this.setWrapper(this.paper.rect(p.rect.x, p.rect.y, p.rect.width, p.rect.height, p.radius).attr(p.attrs));
                if (p.avatar) {
                    var multiplier = (p.name == undefined || p.name == "") ? 2 : 10;
                    var square = this.paper.image(p.avatar, p.rect.x + p.padding, p.rect.y + p.padding, p.rect.height - multiplier * p.padding, p.rect.height - multiplier * p.padding);
                    if (dia != undefined) {
                        if (i != undefined) {
                            this.createButtonDetails(square, dia, i);
                        }
                        else {
                            this.createButtonFull(square, dia, i);
                        }
                    }
                    this.addInner(square);
                    // p.labelOffsetX = p.rect.height;
                }
                if (p.position) {
                    var positionElement = this.getPositionElement();
                    this.addInner(positionElement[0]);
                    this.addInner(positionElement[1]);      // swimlane
                }
                this.addInner(this.getNameElement());
            },
            module: 'org',
            getPositionElement: function () {
                var p = this.properties,
				bb = this.wrapper.getBBox(),
				t = this.paper.text(bb.x + bb.width / 4, bb.y + bb.height / 4, p.position).attr(p.positionAttrs || {}),
				tbb = t.getBBox();
				t.translate(p.labelOffsetX - 15, p.labelOffsetY - 10);
                t.click(function () {
                    if (p.form != undefined && p.form != "")
                        window.location = p.form;
                })				
                tbb = t.getBBox();
                var l = this.paper.path(['M', tbb.x, tbb.y + tbb.height + p.padding,
                                     'L', tbb.x + tbb.width, tbb.y + tbb.height + p.padding].join(' '));
                return [t, l];
            },
            getNameElement: function () {
                var p = this.properties,
				bb = this.wrapper.getBBox(),
				t = this.paper.text(bb.x + bb.width / 4, bb.y + bb.height / 4, p.name).attr(p.nameAttrs || {}),
				tbb = t.getBBox();
                t.translate(p.labelOffsetX + 20, p.labelOffsetY + 15);
                t.click(function () {
                    if (p.form != undefined && p.form != "")
                        window.location = p.form;
                })				
                return t;
            },
            createButtonDetails: function (item, dia, i) {
                item.click((function (item, dia, i) {
                    return function () {
                        dia.constructDiagramRow(i);
                    }
                })(item, dia, i));
            },
            createButtonFull: function (item, dia, i) {
                item.click((function (item, json, i) {
                    return function () {
                        dia.constructDiagramFull();
                    }
                })(item, dia, i));
            }
        });
    };
})(this);          	// END CLOSURE
