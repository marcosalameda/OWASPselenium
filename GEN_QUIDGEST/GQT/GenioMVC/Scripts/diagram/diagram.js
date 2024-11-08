var graphic = {
    id: "",
    canvasID: "",
    JSON: undefined,
    isButtonPressed: false,
    globalView: undefined,
    org: Joint.dia.org,
    paper: Joint._paper,
    height: 500,
    width: "100%",
    maxElems: 0,
    posX: 0,
    posY: 0,
    elem_width: 120,
    elem_height: 60,
    button_width: 30,
    button_height: 30,
    elem_distance_x: 170,
    elem_distance_y: 100,
    offset_X: 100,
    offset_Y: 15,
    center: 220,
    zoomInVal: { height: 25, width: 100 },
    zoomOutVal: { height: 25, width: 100 },
    zoomInLimit: { height: 50, width: 50 },
    zoomOutLimit: { height: 1800, width: 2880 },
    percentage: 0.1,
    backgroundColor: "#eeeeee",
    messages: { PT: { nodata: "Não existem elementos"} },
    init: function (id, canvasid) {
        this.id = id;
        this.canvasID = canvasid;
        this.width = $("#" + canvasid).width();
        Joint.paper(this.canvasID, this.width, this.height);
        this.paper = Joint._paper;
        $("svg rect").css("cursor", "pointer");
        return this;
    },
    redraw: function () {        
        this.paper.canvas.style.backgroundColor = this.backgroundColor;
        this.paper.setViewBox(this.posX, this.posY, this.width, this.height, true);

        if(this.globalView != undefined) {
            // Re-criar botão para retornar à vista completa
            this.globalView.remove();
            this.org.base = this.org.createBase(this.org.Elements["Full"], this);
            this.globalView = this.org.base.create({
                rect: 
                {
                    x: this.offset_X - (this.elem_distance_x / 2) + this.posX, 
                    y: this.offset_Y + this.posY, 
                    width: this.button_width * 2,
                    height: this.button_height * 2
                },
                name: "",
                position: "",
            }).draggable(false);

            this.createButtonFull(this.globalView);
        }
    },
    constructDiagram: function (json) {
        this.JSON = json;
        var obj = this;











        $("#" + this.id + "br").click(function () { if (event.preventDefault) { event.preventDefault(); } else { event.returnValue = false; } obj.moveRight() });
        $("#" + this.id + "bl").unbind('click').click(function () { if (event.preventDefault) { event.preventDefault(); } else { event.returnValue = false; } obj.moveLeft() });
        $("#" + this.id + "zi").click(function () { if (event.preventDefault) { event.preventDefault(); } else { event.returnValue = false; } obj.zoomIn() });
        $("#" + this.id + "zo").click(function () { if (event.preventDefault) { event.preventDefault(); } else { event.returnValue = false; } obj.zoomOut() });

        // Override dos eventos mousedown/mouseup/mousemove para permitir fazer pan do diagrama movendo o rato

        var start_x = 0.0;
        var start_y = 0.0;

        $("#" + this.id + "PlaceHolder").mousedown(function (e) {
            if (e.preventDefault) { e.preventDefault(); }
            else { e.returnValue = false; }
            this.isButtonPressed = true;
            $('body').css('cursor', 'move');
            start_x = e.pageX;
            start_y = e.pageY;
        });

        $("#" + this.id + "PlaceHolder").mouseup(function (e) {
            if (e.preventDefault) { e.preventDefault(); }
            else { e.returnValue = false; }
            $('body').css('cursor', 'default');
            this.isButtonPressed = false;
        });

        $("#" + this.id + "PlaceHolder").mousemove(function (e) {
            if (e.preventDefault) { e.preventDefault(); }
            else { e.returnValue = false; }
            temp_x = e.pageX;
            temp_y = e.pageY;
            if (this.isButtonPressed) {
                obj.posX -= (e.pageX - start_x) * obj.percentage * 10;
                obj.posY -= (e.pageY - start_y) * obj.percentage * 10;
                obj.redraw();
            }
            start_x = e.pageX;
            start_y = e.pageY;
        });
        this.constructDiagramFull();
        return this;
    },
    constructDiagramFull: function () {
        var obj = this;
        this.posX = 0;
        this.posY = 0;
        obj.paper.clear();
        obj.globalView = undefined;
        var items = {}; // Hashtable de elementos indexada pela posição do elemento
        var rows = {};  // Hashtable de rows indexada pelo nº da row. O value é o nº minimo das colunas que fazem parte dessa row
        if (obj.JSON.elements.length === 0) {
            obj.paper.text(obj.width / 2, obj.height / 2, obj.messages.PT.nodata).attr(
                {
                    fill: 'grey',
                    'font-size': 40,
                    'font-family': 'Arial, Helvetica, sans-serif'
                });
            this.redraw();
            return false;
        }

        this.maxElems = obj.JSON.elements.length > obj.maxElems ? obj.JSON.elements.length : obj.maxElems;
        Joint._paper.setViewBox()

        jQuery.each(obj.JSON.elements, function (i, val) {

            obj.org.base = obj.org.createBase(obj.org.Elements[val.Type]);

            var item = obj.org.base.create({
                rect: 
                { 
                    x: ((val.Position.Y - 1) * obj.elem_distance_x) + obj.offset_X, 
                    y: ((val.Position.X - 1) * obj.elem_distance_y) + obj.offset_Y, 
                    width: obj.elem_width, 
                    height: obj.elem_height 
                },
                name: FormatLabel(val.Name, 27),
                position: val.Acronym,
				form: val.Form,
            }).draggable(false);
            item.antecessor = val.Antecessor;

            obj.createLink(item, i, val, val.Type);

            // Adicionar o elemento à hashtable A key é a posição única
            items[val.Position.X.toString() + ", " + val.Position.Y.toString()] = item;

            // Actualizar o valor da coluna mínima para a linha do item actual
            if (!rows.hasOwnProperty(val.Position.X))
            {
                // Se ainda não existir a linha adicioná-la agora
                rows[val.Position.X] = val.Position.Y;
            }
            else
            {
                // Se já existir a linha, verificar se o valor da coluna actual é inferior ao do mínimo actual
                if(val.Position.X < rows[val.Position.Y])
                    rows[val.Position.Y] = val.Position.X;
            }
        });

        // Construir as ligações entre os elementos
        for (var key in items) 
        {
            if (items.hasOwnProperty(key)) 
            {
                var antecessorKey = items[key].antecessor.X.toString() + ", " + items[key].antecessor.Y.toString();
                if (items.hasOwnProperty(antecessorKey)) 
                {
                    var arrow = obj.createArrow(false, true);
                    items[antecessorKey].joint(items[key], arrow);
                }
            }
        }

        // Colocar os botões de toggle, de modo de visão, em cada linha. A sua posição é baseada no valor da coluna mínima
        for (var key in rows) 
        {
            if (rows.hasOwnProperty(key)) 
            {
                obj.org.base = obj.org.createBase(obj.org.Elements["Details"], obj, key);
                var d = obj.org.base.create({
                    rect: 
                    { 
                        //x: (key==1) ? obj.offset_X - (obj.elem_distance_x / 2) : ((rows[key] - 1) * obj.elem_distance_x) + obj.offset_X - obj.elem_distance_x/2,
                        x: obj.offset_X - (obj.elem_distance_x / 2),
                        y: ((key - 1) * obj.elem_distance_y) + obj.offset_Y + (obj.button_height / 2), 
                        width: obj.button_width, 
                        height: obj.button_height 
                    },
                    name: "",
                    position: "",
                }).draggable(false);

                // Associar ao botão uma função que alterna para a linha correspondente
                obj.createButtonDetails(d, key);
            }
        }

        this.redraw();
        return this;
    },
    constructDiagramRow: function (rowNum) {
        var obj = this;
        this.posX = 0;
        this.posY = 0;
        obj.paper.clear();
        var items = [];
        if (obj.JSON.elements.length === 0) {
            obj.paper.text(obj.width / 2, obj.height / 2, obj.messages.PT.nodata).attr(
                {
                    fill: 'grey',
                    'font-size': 40,
                    'font-family': 'Arial, Helvetica, sans-serif'
                });
            this.redraw();
            return false;
        }

        this.maxElems = obj.JSON.elements.length > obj.maxElems ? obj.JSON.elements.length : obj.maxElems;
        Joint._paper.setViewBox()

        var col = 0;
        jQuery.each(obj.JSON.elements, function (i, val) {

            // Se o elemento não pertencer à linha que estamos a mostrar, passamos ao próximo
            if(val.Position.X != rowNum)
                return true;


            obj.org.base = obj.org.createBase(obj.org.Elements[val.Type]);

            var item = obj.org.base.create({
                rect: 
                { 
                    x: (col * obj.elem_distance_x) + obj.offset_X, 
                    y: obj.center, width: obj.elem_width, 
                    height: obj.elem_height 
                },

                name: FormatLabel(val.Name, 27),
                position: val.Acronym,
				form: val.Form,
            }).draggable(false);

            // Entrances
            var previous_element = item;
            jQuery.each(val.entrance, function (j, entr) {
                var entrance_activity = obj.createElement(col, j, entr, true);
                var arrow = obj.createArrow(j == 0, false);

                obj.createLink(entrance_activity, j, entr, entr.Type);
                previous_element.joint(entrance_activity, arrow);
                previous_element = entrance_activity;
            });

            // Exits
            previous_element = item;
            jQuery.each(val.exit, function (k, exit) {
                var exit_activity = obj.createElement(col, k, exit, false);
                var arrow = obj.createArrow(false, k == 0);

                obj.createLink(exit_activity, k, exit, exit.Type);
                previous_element.joint(exit_activity, arrow);
                previous_element = exit_activity;
            });

            obj.createLink(item, col, val, val.Type);

            items.push(item);

            var arrow = obj.createArrow(true, false);

            //  interactive: false no ficheiro joint.js fixa a arrow
            if (col > 0)

               item.joint(items[col - 1], arrow);

            col++;
        });

        // Criar botão para retornar à vista completa
        obj.org.base = obj.org.createBase(obj.org.Elements["Full"], obj);
        obj.globalView = obj.org.base.create({
            rect: 
            {
                x: obj.offset_X - (obj.elem_distance_x / 2), 
                y: obj.offset_Y , 
                width: obj.button_width * 2,
                height: obj.button_height * 2
            },
            name: "",
            position: "",
        }).draggable(false);

        obj.createButtonFull(obj.globalView);

        this.redraw();
        return this;
    },
    createLink: function (item, i, val, Type) {
        item.wrapper.click((function (i, val, Type) {
            return function () {
                if(val.Form != undefined && val.Form != "")
                    window.location = val.Form;
            }
        })(i, val, Type));
    },
    createButtonDetails: function (item, i) {
        var obj = this;
        item.wrapper.click((function (item, i) {
            return function () {
                obj.constructDiagramRow(i);
            }
        })(item, i));
    },
    createButtonFull: function (item, i) {
        var obj = this;
        item.wrapper.click((function (item, i) {
            return function () {
                obj.constructDiagramFull();
            }
        })(item, i));
    },
    createElement: function (i, j, item, top) {
        var obj = this;
        this.org.base = this.org.createBase(this.org.Elements[item.Type]);
        var element = this.org.base.create({
            rect: { x: (i * obj.elem_distance_x) + obj.offset_X, y: (top == true ? obj.center - obj.elem_distance_y : obj.center + obj.elem_distance_y) + (top == true ? -(obj.elem_distance_y * j) : obj.elem_distance_y * j), width: obj.elem_width, height: obj.elem_height },

            name: FormatLabel(item.Name, 27),
            position: item.Acronymm,
			form: item.Form
        }).draggable(false);

        return element;
    },
    createArrow: function (arrow_begin, arrow_end) {
        var arrow = {
            startArrow: (arrow_begin == true ? { type: "basic", size: 3} : { type: 'none' }),
            endArrow: (arrow_end == true ? { type: "basic", size: 3} : { type: 'none' })
        };
        var arrowFinal = jQuery.extend(true, this.org.arrow, arrow);
        return arrowFinal;
    },
    moveUp: function () {
        this.posY -= Math.ceil(this.height * this.percentage);
        this.redraw();
    },
    moveDown: function () {
        this.posY += Math.ceil(this.height * this.percentage);
        this.redraw();
    },
    moveRight: function () {
        this.posX += Math.ceil(this.width * this.percentage);
        this.redraw();
    },
    moveLeft: function () {
        if (this.posX == 0 && this.posY == 0) return false;
        this.posX -= Math.ceil(this.width * this.percentage);
        this.redraw();
    },
    zoomIn: function () {
        if (!(this.height > this.zoomInLimit.height && this.width > this.zoomInLimit.width)) return false;
        this.height -= this.zoomInVal.height;
        this.width -= this.zoomInVal.width;
        this.redraw();
    },
    zoomOut: function () {
        if (!(this.height < this.zoomOutLimit.height && this.width < this.zoomOutLimit.width)) return false;
        this.height += this.zoomOutVal.height;
        this.width += this.zoomOutVal.width;
        this.redraw();
    }
}

function Left(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0, n);
}

function FormatLabel(str, n) {
    var aux = String(str);
    var line1 = "";
    var line2 = "";

    if (n <= 0)
        return "";
    else if (n > aux.length)
        return pad(str, n, "");
    else
    {
        var word = "";
        var line = 1;
        for(var i=0; i<aux.length; i++)
        {
            // Se não encontramos um espaço em branco adicionamos o caracter actual à palavra actual
            if(aux[i] != ' ')
                word += aux[i];
            
            if(aux[i]==' ' || i+1==aux.length)
            {
                // Caso contrário a palavra acabou
                if(line == 1)
                {
                    if(line1.length + word.length + 2 <= n) {
                        // Se estamos na 1ª linha e a palavra ainda cabe, adicionamos a palavra à linha
                        line1 = (line1.length > 0) ? line1 + " " + word : line1 + word;
                        //line1 = line1 + " " + word;
                     }
                     else {
                        // Se a palavra já não cabe, mudamos de linha e adicionamos a palavra à segunda linha
                        line2 += word;
                        line ++;
                     }
                }
                else if (line == 2)
                {
                    if(line2.length + word.length + 2 <= n) {
                        // Se estamos na 2ª linha e a palavra ainda cabe, adicionamos a palavra à linha
                        line2 = (line2.length > 0) ? line2 + " " + word : line2 + word;
                     }
                     else {
                        // Se a palavra já não cabe, fazemos truncate da palavra para caber na 2ª linha e acabamos ciclo
                        line2 += Left(word, n - line2.length);
                        break;
                     }
                }
                // Fazer reset à palavra
                word = "";
            }
        }
    }

    var res = pad(line1, n-1, "") + '\n' + pad(line2, n, "");
    return res;
}


String.prototype.lpad = function(padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}

String.prototype.rpad = function(padString, length) {
    var str = this;
    while (str.length < length)
        str = str + padString;
    return str;
}


function pad(n, width, z) {
  z = z || '%A0%A0';
  n = n + '';
  return n.length >= width - 2? n : unescape(n + new Array(width - 2 - n.length + 1).join(z));
}

//#########################################################################################################