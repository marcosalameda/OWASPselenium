//*************** Web Player para Aplicações Quidgest *****************
//**           Modulo de Estilos e Controlos de Exibição             **
//**                                                                 **
//**                           versão 3.00                           **
//*********************************************************************


var fieldtabindex=50
var buttontabindex=50 //200

//***************************************************************** Generic Display Ctl -  Funções genéricas para controlos de exibição
function GenericDisplayCtl_Construct(xnod, hostpage, hostpanel, parentobj) {
	GenericDisplayCtl_ConstructIni.call(this, xnod, hostpage, hostpanel, parentobj)
	GenericDisplayCtl_ConstructDiv.call(this, xnod)
}

function GenericDisplayCtl_ConstructIni(xnod, hostpage, hostpanel, parentobj) {
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.ParentObj=parentobj
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id=this.Tipo + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	//this.Hid=hostpanel.Hid + "." + this.Id
	if (this.HostPanel == App) {
		if (this.ParentObj != undefined && this.HostPanel != this.ParentObj) {
			this.Hid=this.ParentObj.Hid + "." + this.Id
		} else {
			this.Hid=this.HostPage.Hid + "." + this.Id
		}
	} else {
		this.Hid=this.HostPanel.Hid + "." + this.Id
	}

	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=null
	if (this.Datactl != "") {
		this.DatactlObj=hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "O controlo (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
		if (this.DatactlObj.Tipo.indexOf(this.Tipo) > -1) {
			var Aw=this.DatactlObj.Tipo.split(".")
			this.Tipo4Style=Aw[Aw.length-1] + "." + this.Tipo
		} else {
			this.Tipo4Style=this.DatactlObj.Tipo + "." + this.Tipo
		}
	}
	this.Actls=new Array()
	this.Events=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	if (this.Tipo4Style == undefined) this.Tipo4Style=this.Tipo
	this.StyleObj=App.GetStyle(this.Style, this.Tipo4Style)
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Disabled=false
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Activated=false
	this.InitialFocus=GetAtt(xnod, "FOCUS", "N")
	if (this.InitialFocus == "S") this.HostPage.InitialFocusSet=true
}

function GenericDisplayCtl_ConstructDiv(xnod) {
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "100,20"), this.HostPanel)
	var wdiv=CreateDiv(this.HostPanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=1
	if (this.Tip != "" && this.Tip != "*") wdiv.title=this.Tip
	if (this.Prot == "S") this.Disable("PROT")
}

function GenericDisplayCtl_Activate(opt) {
	this.Activated=true
	if (this.Visivel == "S") this.Show("INIT")
}

function GenericDisplayCtl_Activate2(opt) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate("INIT")
		if (this.Actls[i].Class == "PANEL" && this.Scroll == "S") GenericDisplayCtl_TestScrollIE.call(this, this.Actls[i])
	}
	if (this.InitialFocus == "S") this.Focus()
}

function GenericDisplayCtl_Resize(opt) {
	this.Locsize.Resize(this.Hobj)
	this.Frame.Resize()
	if (FocusCtl.HostCtl == this) FocusCtl.Show(this)
}

function GenericDisplayCtl_SetState(st) {
	this.Frame.SetState(st)
}

function GenericDisplayCtl_Disable(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	if (tipo == "VIS") {
		if (this.Tipo == "DOC") {
			this.DisableUpdate()
			return
		}
	}
	this.Disabled=true
	if (FocusCtl.HostCtl == this) FocusCtl.Hide(this)
	this.Hobj.disabled=true
	this.SetState("DISA")
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Disable(tipo)
	}
	if (this.Hobj.tabIndex > 0) this.Hobj.tabIndex=-this.Hobj.tabIndex
	if (this.Hobj.style.cursor == "pointer") {
		this.CursorPointer=true
		this.Hobj.style.cursor="default"
	}
}

function GenericDisplayCtl_Enable(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		if (tipo == "VIS") {
			if (this.Tipo == "DOC") {
				this.EnableUpdate()
				return
			}
		}
		this.Disabled=false
		this.Hobj.disabled=false
		this.SetState("NORM")
		
		if (this.Hobj.tabIndex < 0) this.Hobj.tabIndex=-this.Hobj.tabIndex
		if (this.CursorPointer == true) {
			this.CursorPointer=false
			this.Hobj.style.cursor="pointer"
		}
	}
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Enable(tipo)
	}
}

function GenericDisplayCtl_Show(opt) {
	if (this.Activated == false) {
		this.Visivel="S"
		this.Activate()
		return
	}
	if (opt == "INIT") {
		var wanim=new Qanimator(this, "IN", this.StyleObj.AnimIn)
		this.Visible=true
		wanim.Activate(this.Activate2)
		return
	}
	if (opt == "CASCADE" && this.Visivel == "N") return
	var wanim=new Qanimator(this, "IN", this.StyleObj.AnimIn)
	this.Visible=true
	if (opt != "CASCADE") this.Visivel = "S"
	wanim.Activate()
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Tipo != "TABPANEL" && this.Actls[i].Tipo != "CONTXPANEL" && this.Actls[i].Tipo != "FCONTROLLIST") this.Actls[i].Show("CASCADE")
	}
}

function GenericDisplayCtl_Hide(opt) {
	if (FocusCtl.HostCtl == this) FocusCtl.Hide(this)
	this.Visible=false
	for (var i=this.Actls.length-1; i>=0; i--) {
		if (opt == "DESTROY" || opt == "DESTROYNOW") {
			this.Actls[i].Destroy(opt);
		} else {
			this.Actls[i].Hide("CASCADE");
		}
	}
	if (opt == "DESTROY") {
		var wanim=new Qanimator(this, "OUT", this.StyleObj.AnimOut);
		wanim.Activate(this.Destroy2);
		return;
	}
	if (opt == "DESTROYNOW") {  //não passa pela animação, destroy em modo sincrono
		this.Hobj.style.display="none";
		this.Destroy2();
		return;
	}
	var wanim=new Qanimator(this, "OUT", this.StyleObj.AnimOut);
	wanim.Activate();
	if (opt != "CASCADE") this.Visivel = "N"
}

function GenericDisplayCtl_ShowErr(msg) {
	this.SetState("ERRO")
	this.Hobj.title=msg
}

function GenericDisplayCtl_HideErr() {
	if (this.Disabled == false) this.SetState("NORM")
	this.Hobj.title=""
	if (this.Tip != "" && this.Tip != "*") this.Hobj.title=this.Tip
	if (this.Tip == "*" && this.Tipo == "TEXT") this.Hobj.title=FormatCol(this.DataCol, valor, "user")
}

function GenericDisplayCtl_OnFocus() {
	if (this.Disabled == true || this.ReadOnly == "S") return
	if (this.StyleObj.StateExists("FOCU") == true) {
		this.SetState("FOCU")
	} else {
		FocusCtl.Show(this)
	}
}

function GenericDisplayCtl_OnBlur() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	if (this.StyleObj.StateExists("FOCU") == true) {
		this.SetState("NORM")
	} else {
		FocusCtl.Hide(this)
	}
}

function GenericDisplayCtl_OnMouseOver(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) {
		this.HostDataPanel.OnMouseOver(id, hnod)
	} else {
		this.HostPanel.OnMouseOver(id, hnod)
	}
}

function GenericDisplayCtl_OnMouseOut(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) {
		this.HostDataPanel.OnMouseOut(id, hnod)
	} else {
		this.HostPanel.OnMouseOut(id, hnod)
	}
}

function GenericDisplayCtl_OnMouseDown(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.OnMouseDown) this.HostDataPanel.OnMouseDown(id, hnod, wx, wy)
	} else {
		if (this.HostPanel.OnMouseDown) this.HostPanel.OnMouseDown(id, hnod, wx, wy)
	}
}


function GenericDisplayCtl_OnMouseUp(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.OnMouseUp) this.HostDataPanel.OnMouseUp(id, hnod, wx, wy)
	} else {
		if (this.HostPanel.OnMouseUp) this.HostPanel.OnMouseUp(id, hnod, wx, wy)
	}
}

function GenericDisplayCtl_OnContext(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
		this.HostDataPanel.OnContext(id, hnod, wx, wy)
	}
}

function GenericDisplayCtl_OnClick(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.Select("CLK", keys)
}

function GenericDisplayCtl_Focus() {
	this.Hobj.focus()
}

function GenericDisplayCtl_Destroy(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";  //opt="DESTROYNOW" destroy em modo sincrono sem esperar animações
	this.Hide(opt);
	if (this.ParentObj != null) {
		GenericDisplayCtl_RemoveFromParent(this.ParentObj, this)
	}
	GenericDisplayCtl_RemoveFromParent(this.HostPanel, this)
}

function GenericDisplayCtl_RemoveFromParent(wparent, wctl) {
	if (wparent != null) {
		if (wparent.Actls != null && wparent.Actls != undefined) {
			for (var i=0; i<wparent.Actls.length; i++) {
				if (wparent.Actls[i] == wctl) {
					wparent.Actls.splice(i,1)
					break
				}
			}
		}
	}
}

function GenericDisplayCtl_Destroy2() {
	this.Actls=new Array()
	if (this.Frame != undefined) this.Frame.Destroy()
	if (this.Hobj != null) {
		var wparent=this.Hobj.parentNode;
		if (wparent != null) wparent.removeChild(this.Hobj);
	}
}

function GenericDisplayCtl_TestScrollIE(obj) {
	if (BrowserIE == true) {  //bug do IE9 com o scrolling
		/*
		if (navigator.appVersion.indexOf("MSIE 9.0") > -1) {
			var largura=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
			var altura=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
			if (obj.Locsize.ObjW > largura && obj.Locsize.ObjH > altura) {
				this.Hobj.style.width=(this.Locsize.ObjW + 17) + "px"
				this.Hobj.style.height=(this.Locsize.ObjH + 17) + "px"
			}
		}
		*/
	}
}

function GenericDisplayCtl_SetRowOrig() {
	if (this.HostDataPanel != null) {
		RowOrig="_R" + this.HostDataPanel.LineNumber
	} else {
		RowOrig=""
	}
}


//***************************************************************** QFOCUS - define Focus
function Qfocus() {
	this.Tipo="FOCUS"
	this.Class="FOCUS"
	this.Hid="FocusCtl"
	this.HostDiv=App.PanelObj
	this.HostCtl = App
	this.Style="DEFAULT"
	this.StyleObj=App.GetStyle("DEFAULT", "FOCUS")
	var wdiv=CreateDiv(this.HostDiv, this.Hid)
	wdiv.style.display="none"
	this.Hobj=wdiv
	this.Frame=new Qframe(this)
}

Qfocus.prototype.Show=function(ctl) {
	if (ctl.Visible == false) this.Hide(ctl)
	var wstylehost=ctl.StyleObj.Id
	if (this.Style != wstylehost) {
		this.StyleObj=App.GetStyle(wstylehost, "FOCUS")
		if (this.StyleObj.Id != this.Style) {
			this.Style=this.StyleObj.Id
			this.Frame=new Qframe(this)
		}
	}
	ctl.HostPage.LastFocusCtl=ctl  //guardar na Page qual o ultimo control a ter focus
	this.HostCtl=ctl
	this.HostDiv=ctl.HostPanel.PanelObj
	var wpanel=this.HostDiv.appendChild(this.Hobj)
	this.Hobj.style.display="block"
	this.Hobj.style.left = (GetSizeNumber(ctl.Hobj.style.left) - this.StyleObj.PadL) + "px"
	this.Hobj.style.top = (GetSizeNumber(ctl.Hobj.style.top) - this.StyleObj.PadT) + "px"
	this.Hobj.style.width = (GetSizeNumber(ctl.Hobj.style.width) + this.StyleObj.PadL + this.StyleObj.PadR) + "px"
	this.Hobj.style.height = (GetSizeNumber(ctl.Hobj.style.height) + this.StyleObj.PadT + this.StyleObj.PadB) + "px"
	this.Hobj.style.zIndex=Number(ctl.Hobj.style.zIndex) - 1
}

Qfocus.prototype.Hide=function(ctl) {
	if (ctl != this.HostCtl) return
	if (this.HostDiv != undefined || this.HostDiv != null) {
		try {this.HostDiv.removeChild(this.Hobj)}
		catch(exp) {}
	}
	this.Hobj.style.display="none"
}


//***************************************************************** QSCROLL - define barras de Scroll especialmente para equipamento movel
function Qscroll(hostpage, hostpanel) {
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.Tipo="SCROLL"
	this.Class="SCROLL"
	this.Actls=new Array()
	this.Hobjv=null
	this.Hobjvc=null
	this.Hobjh=null
	this.Hobjhc=null
}

Qscroll.prototype.Refresh=function() {
	var scrollv=false
	var scrollh=false
	if (this.HostPanel.Hobj.scrollHeight > this.HostPanel.Hobj.clientHeight) scrollv=true
	if (this.HostPanel.Hobj.scrollWidth > this.HostPanel.Hobj.clientWidth) scrollh=true
	if (scrollv == true) {
		if (this.Hobjv == null) {
			this.Hobjv = new Qscrollbar(this.HostPanel, this, "SCROLLBAR._.V")
			this.Actls.push(this.Hobjv)
			this.Hobjvc = new Qscrollbar(this.HostPanel, this, "SCROLLBAR.CURSOR._.V")
			this.Actls.push(this.Hobjvc)
		}
		var wleft=this.HostPanel.Locsize.ObjL + this.HostPanel.Locsize.MargL + this.HostPanel.Locsize.ObjW - this.HostPanel.Locsize.MargR - 4
		var wtop=this.HostPanel.Locsize.ObjT + this.HostPanel.Locsize.MargT
		var wheight=this.HostPanel.Locsize.ObjH - this.HostPanel.Locsize.MargT - this.HostPanel.Locsize.MargB
		var ratio=this.HostPanel.Hobj.clientHeight / this.HostPanel.Hobj.scrollHeight
		this.Hobjv.Resize(wleft, wtop, 7, wheight)
		this.Hobjvc.Resize(wleft + 1, wtop + (ratio * this.HostPanel.Hobj.scrollTop), 5, ratio * wheight)
	} else {
		if (this.Hobjv != null) {
			this.Hobjv.Hide()
			this.Hobjvc.Hide()
		}
	}
	if (scrollh == true) {
		if (this.Hobjh == null) {
			this.Hobjh = new Qscrollbar(this.HostPanel, this, "SCROLLBAR._.H")
			this.Actls.push(this.Hobjh)
			this.Hobjhc = new Qscrollbar(this.HostPanel, this, "SCROLLBAR.CURSOR._.H")
			this.Actls.push(this.Hobjhc)
		}
		var wleft=this.HostPanel.Locsize.ObjL + this.HostPanel.Locsize.MargL
		var wtop=this.HostPanel.Locsize.ObjT + this.HostPanel.Locsize.MargT + this.HostPanel.Locsize.ObjH - this.HostPanel.Locsize.MargB - 4
		var wwidth=this.HostPanel.Locsize.ObjW - this.HostPanel.Locsize.MargL - this.HostPanel.Locsize.MargR
		var ratio=this.HostPanel.Hobj.clientWidth / this.HostPanel.Hobj.scrollWidth
		this.Hobjh.Resize(wleft, wtop, wwidth, 7)
		this.Hobjhc.Resize(wleft + (ratio * this.HostPanel.Hobj.scrollLeft), wtop + 1 , ratio * wwidth, 5)
	} else {
		if (this.Hobjh != null) {
			this.Hobjh.Hide()
			this.Hobjhc.Hide()
		}
	}
}

Qscroll.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Destroy(opt)
	}
	this.Actls=new Array()
}


//***************************************************************** QSCROLLBAR - define parte de uma scrollbar (o fundo ou o cursor)
function Qscrollbar(hostpanel, parentobj, tipo) {
	this.HostPanel=hostpanel
	this.ParentObj=parentobj
	var j=tipo.indexOf("._.")
	this.Tipo=tipo.substr(0,j)
	this.Class="SCROLL"
	this.Hid=this.HostPanel.Hid + "._." + tipo
	this.Style=this.HostPanel.StyleObj.Id
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Locsize=new QlocSize("0,0", "5,5", this.HostPanel)
	var wdiv=CreateDiv(this.HostPanel.HostPanel.PanelObj, this.Hid)
	wdiv.style.zIndex=8
	wdiv.style.display="none"
	this.Hobj=wdiv
	this.Frame=new Qframe(this)
}

Qscrollbar.prototype.Resize=function(x, y, w, h) {
	this.Locsize.ObjL=x
	this.Locsize.ObjT=y
	this.Locsize.ObjW=w
	this.Locsize.ObjH=h
	this.Hobj.style.left=x + "px"
	this.Hobj.style.top=y + "px"
	this.Hobj.style.width=w + "px"
	this.Hobj.style.height=h + "px"
	this.Hobj.style.display="block"
}

Qscrollbar.prototype.Hide=function() {
	this.Hobj.style.display="none"
}

Qscrollbar.prototype.Destroy=function(opt) {
	this.HostPanel.HostPanel.PanelObj.removeNode(this.Hobj)
}


//***************************************************************** QPANEL - define Painel
function Qpanel(xnod, hostpage, hostpanel, tipo) {
	if (tipo == "" || tipo == undefined) {
		this.Tipo="PANEL"
	} else {
		this.Tipo=tipo
	}
	this.Class="PANEL"
	GenericDisplayCtl_ConstructIni.call(this, xnod, hostpage, hostpanel)
	this.Nivseg=GetAtt(xnod, "NIVSEG", "")
	this.Scroll=GetAtt(xnod, "SCROLL", "N")
	var wsize=GetAtt(xnod, "SIZE", "0,0")
	if (this.HostPage.FirstPanel == "") this.HostPage.FirstPanel=this
	if ((this.HostPage.Tipo == "DIALOG" || this.HostPage.Tipo == "POPUPDIALOG") && (this.HostPage.FirstPanel == this)) {
		var w=GetAtt(xnod, "SIZEDIALOG", "")
		if (w != "") wsize=w
		w=GetAtt(xnod, "SCROLLDIALOG", "")
		if (w != "") this.Scroll=w
		this.LocationDialog=GetAtt(xnod, "LOCATIONDIALOG", "")
		this.Locsize=new QlocSize("0,0", wsize, hostpanel)
	} else {
		this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), wsize, hostpanel)
	}
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	wdiv.onmouseover=EvtMouseOver
	wdiv.onmouseout=EvtMouseOut
	//wdiv.onmousedown=EvtMouseDown
	//wdiv.onmouseup=EvtMouseUp
	//wdiv.onmousemove=EvtMouseMove

	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.Frame=new Qframe(this)
	if (this.Scroll == "S") {
		wdiv.style.overflow="auto"
	} else {
		wdiv.style.overflow="hidden"
	}
	this.HostPanel.Actls.push(this);
	wdiv.style.zIndex=1
	CreateDisplayCtls(xnod, this)
}

Qpanel.prototype.Activate=function(opt) {
	this.Activated=true
	if (opt == "INIT") {
		if (this.Tipo == "TABPANEL") this.Visivel="N"
	}
	GenericDisplayCtl_Activate.call(this, opt)
}

Qpanel.prototype.Activate2=function(opt) {
	//this.Resize()
	GenericDisplayCtl_Activate2.call(this, opt)
}

Qpanel.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Locsize.Resizable == true) this.Actls[i].Resize()
		if (this.Actls[i].Class == "PANEL" && this.Scroll == "S") GenericDisplayCtl_TestScrollIE.call(this, this.Actls[i])
	}
	if (this.Locsize.RefH == "R" && this.HostPage.Area.CanExpand == "S") {
		this.Locsize.UnScrollH(this.Hobj)
		this.Frame.Resize()
	}
}

Qpanel.prototype.SetState=function(st) {
	this.Frame.SetState(st)
}

Qpanel.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
}


Qpanel.prototype.Hide=function(opt) {
	GenericDisplayCtl_Hide.call(this, opt)
}

Qpanel.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qpanel.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qpanel.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qpanel.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qpanel.prototype.OnClick=function() {}

Qpanel.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qpanel.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

/*
Qpanel.prototype.OnMouseUp=function() {
	document.onselectstart=function() {return true}
	this.IsDragging=false
	var timenow=new Date().getTime();
	var desloc=this.Sleft - this.HostPanel.Hobj.scrollLeft
	var tempo=timenow-this.Sstart
	var veloc=desloc / tempo
	api.SetVal("Arodape", "STATUS", "desloc=" + desloc + "          speed=" + veloc)
}

Qpanel.prototype.OnMouseDown=function(id, hnod, wx, wy, cx, cy) {
	if (this.HostPanel.Scroll != "S") return;
	if (this.HostPanel.Hobj.scrollHeight <= this.HostPanel.Hobj.clientHeight && this.HostPanel.Hobj.scrollWidth <= this.HostPanel.Hobj.clientWidth) return;
	//Prepara-se para scrolling
	this.Offsetx = cx; //wx;
	this.Offsety = cy; //wy;
	this.IsDragging=true
	this.Sleft=this.HostPanel.Hobj.scrollLeft
	this.Sstart=new Date().getTime();
	document.onselectstart=function() {return false}
}


Qpanel.prototype.OnMouseMove=function(id, hnod, zx, zy, wx, wy) {
	if (this.IsDragging != true) return
	var dx=wx - this.Offsetx //- wx
	var dy=wy - this.Offsety //- wy
	this.Offsetx=wx
	this.Offsety=wy
	//api.SetVal("Arodape", "STATUS", "dx=" + this.dx)
	this.HostPanel.Hobj.scrollLeft=this.HostPanel.Hobj.scrollLeft - dx
}
*/

//***************************************************************** QWINPANEL - define Painel que aloja windows dentre dele
function Qwinpanel(xnod, hostpage, hostpanel) {
	this.Tipo="WINPANEL"
	this.Class="PANEL"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="WinPanel" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Actls=new Array()
	this.Scroll=GetAtt(xnod, "SCROLL", "N")
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.Padding=GetAtt(xnod, "PADDING", 0, "N")
	this.Orientation=GetAtt(xnod, "ORIENT", "V")
	this.AcceptDrop=GetAtt(xnod, "ACCEPTDROP", "N")
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.WindowW=0
	this.WindowH=0
	this.WindowX=0
	this.WindowY=0
	this.ContextPanel=null
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Frame=new Qframe(this)
	if (this.Scroll == "S") {
		wdiv.style.overflow="auto"
	} else {
		wdiv.style.overflow="hidden"
	}
	wdiv.style.zIndex=0
	this.IsBusy=false
	this.Activated=false
	this.Resize()
}

Qwinpanel.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qwinpanel.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qwinpanel.prototype.Resize=function() {
	this.Locsize.Resize(this.PanelObj)
	this.Frame.Resize()
	this.WindowW=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
	this.WindowH=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
	if (this.Orientation == "V") this.WindowH="*"
	if (this.Orientation == "H") this.WindowW="*"
	this.Rearange()
}


Qwinpanel.prototype.Rearange=function() {
	if (this.IsBusy == true) return
	var wctl
	if (this.Orientation == "V") {
		this.IsBusy=true
		this.Actls.sort(SortActlsByTop)
		var offsetV=this.Locsize.MargT
		for (var i=0; i<this.Actls.length; i++) {
			wctl=this.Actls[i]
			if (wctl.Locsize.ObjL != this.Locsize.MargL || wctl.Locsize.ObjT != offsetV) wctl.Animate(this.Locsize.MargL, offsetV, "", "", 10)  //wctl.Resize(this.Locsize.MargL, offsetV, 10)
			offsetV=offsetV + wctl.Locsize.ObjH + this.Padding
		}
		this.WindowX=this.Locsize.MargL
		this.WindowY=offsetV
		this.IsBusy=false
		return
	}
	if (this.Orientation == "H") {
		this.IsBusy=true
		this.Actls.sort(SortActlsByLeft)
		var offsetH=this.Locsize.MargL
		for (var i=0; i<this.Actls.length; i++) {
			wctl=this.Actls[i]
			if (wctl.Locsize.ObjL != offsetH || wctl.Locsize.ObjT != this.Locsize.MargT) wctl.Animate(offsetH, this.Locsize.MargT, "", "", 10)  //wctl.Resize(offsetH, this.Locsize.MargT, 10)
			offsetH=offsetH + wctl.Locsize.ObjW + this.Padding
		}
		this.WindowX=offsetH
		this.WindowY=this.Locsize.MargT
		this.IsBusy=false
		return
	}
}

function SortActlsByTop(ctl1, ctl2) {
	var v1=ctl1.Locsize.ObjT
	var v2=ctl2.Locsize.ObjT
	if (v1 == v2) return 0
	if (v1 < v2) return -1
	return 1
}

function SortActlsByLeft(ctl1, ctl2) {
	var v1=ctl1.Locsize.ObjL
	var v2=ctl2.Locsize.ObjL
	if (v1 == v2) return 0
	if (v1 < v2) return -1
	return 1
}


Qwinpanel.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
}

Qwinpanel.prototype.Hide=function(opt) {
	GenericDisplayCtl_Hide.call(this, opt)
}

Qwinpanel.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qwinpanel.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qwinpanel.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	this.Hide(opt);
}

Qwinpanel.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qwinpanel.prototype.OnClick=function() {
}
Qwinpanel.prototype.OnMouseOver=function(id, hnod) {
}
Qwinpanel.prototype.OnMouseOut=function(id, hnod) {
}


//***************************************************************** QWINCAP - define Window Caption
function Qwincap(xnod, hostpanel) {
	this.Tipo="WINCAP"
	this.Class="PANEL"
	this.HostPage=hostpanel
	this.HostPanel=hostpanel
	this.HostDataPanel=null
	this.ParentObj=hostpanel
	this.Id="Caption"
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Actls=new Array()
	this.Style=hostpanel.Style
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Nivseg=""
	this.Locsize=new QlocSize("0,0", "*,20", this.HostPanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	//this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=3
	wdiv.onmouseover=EvtMouseOver
	wdiv.onmouseout=EvtMouseOut
	wdiv.onmousedown=EvtMouseDown
	wdiv.style.cursor="move"
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Resize()
	CreateDisplayCtls(xnod, this)
	this.BotMin=null
	this.BotRest=null
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Id == "Botmin") this.BotMin=this.Actls[i]
		if (this.Actls[i].Id == "Botrest") this.BotRest=this.Actls[i]
	}
	this.Activated=false
}

Qwincap.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qwincap.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qwincap.prototype.Resize=function() {
	var wL=this.HostPanel.Locsize.MargL
	var wT=this.HostPanel.Locsize.MargT
	var wR=this.HostPanel.Locsize.MargR
	this.HostPanel.Locsize.MargL=4
	this.HostPanel.Locsize.MargT=2
	this.HostPanel.Locsize.MargR=4
	GenericDisplayCtl_Resize.call(this)
	this.HostPanel.Locsize.MargL=wL
	this.HostPanel.Locsize.MargT=wT
	this.HostPanel.Locsize.MargR=wR
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Locsize.Resizable == true) this.Actls[i].Resize()
	}
}

Qwincap.prototype.SetState=function(st) {
	this.Frame.SetState(st)
}

Qwincap.prototype.RefreshWindowState=function() {
	if (this.HostPanel.Minimized == true) {
		if (this.BotMin != null) this.BotMin.Hide()
		if (this.BotRest != null) this.BotRest.Show()
	} else {
		if (this.BotMin != null) this.BotMin.Show()
		if (this.BotRest != null) this.BotRest.Hide()
	}
}

Qwincap.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
}

Qwincap.prototype.Hide=function(opt) {
	GenericDisplayCtl_Hide.call(this, opt)
}

Qwincap.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qwincap.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qwincap.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qwincap.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qwincap.prototype.OnClick=function() {}
Qwincap.prototype.OnMouseOver=function(id, hnod) {
	this.HostPanel.OnMouseOver(id, hnod)
	this.SetState("HIGH")
}
Qwincap.prototype.OnMouseOut=function(id, hnod) {
	this.HostPanel.OnMouseOut(id, hnod)
	this.SetState("NORM")
}

Qwincap.prototype.OnMouseDown=function(id, hnod, wx, wy) {
	this.SetState("SELE")
	this.HostPanel.CapMouseDown(wx, wy)
}

Qwincap.prototype.MouseUp=function() {
	this.SetState("HIGH")
}

Qwincap.prototype.OnMouseOver=function(id, hnod) {
	this.HostPanel.OnMouseOver(id, hnod)
	this.SetState("HIGH")
}
Qwincap.prototype.OnMouseOut=function(id, hnod) {
	this.HostPanel.OnMouseOut(id, hnod)
	this.SetState("NORM")
}


//***************************************************************** QWINRESIZER - define Window resize area
function Qwinresizer(xnod, hostpanel) {
	this.Tipo="WINRESIZER"
	this.Class="PANEL"
	this.HostPage=hostpanel
	this.HostPanel=hostpanel
	this.HostDataPanel=null
	this.ParentObj=hostpanel
	this.Id="Rszarea"
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Actls=new Array()
	this.Style=hostpanel.Style
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Nivseg=""
	this.Locsize=new QlocSize("0,0", "20,20", this.HostPanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	//this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=5
	wdiv.onmouseover=EvtMouseOver
	wdiv.onmouseout=EvtMouseOut
	wdiv.onmousedown=EvtMouseDown
	wdiv.style.cursor="move"
	this.Visivel="S"
	this.Visible=true
	this.Resize()
	this.Activated=false
}

Qwinresizer.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qwinresizer.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qwinresizer.prototype.Resize=function() {
	this.Locsize.ObjL=this.HostPanel.Locsize.ObjW-20
	this.Locsize.ObjT=this.HostPanel.Locsize.ObjH-20
	this.Hobj.style.left=this.Locsize.ObjL + "px"
	this.Hobj.style.top=this.Locsize.ObjT + "px"
	this.Hobj.style.width=20 + "px"
	this.Hobj.style.height=20 + "px"
}

Qwinresizer.prototype.SetState=function(st) {
	this.Frame.SetState(st)
}

Qwinresizer.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qwinresizer.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qwinresizer.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qwinresizer.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qwinresizer.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qwinresizer.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qwinresizer.prototype.OnClick=function() {}

Qwinresizer.prototype.OnMouseOver=function(id, hnod) {
	this.HostPanel.OnMouseOver(id, hnod)
	this.SetState("HIGH")
}
Qwinresizer.prototype.OnMouseOut=function(id, hnod) {
	this.HostPanel.OnMouseOut(id, hnod)
	this.SetState("NORM")
}

Qwinresizer.prototype.OnMouseDown=function(id, hnod, wx, wy) {
	this.SetState("SELE")
	this.HostPanel.ResizeMouseDown(wx, wy)
}

Qwinresizer.prototype.MouseUp=function() {
	this.SetState("HIGH")
}


//***************************************************************** QCONTXPANEL - define Painel de Contexto
function Qcontxpanel(xnod, hostpage, hostpanel) {
	this.Tipo="CONTXPANEL"
	this.Class="PANEL"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.Xnod=xnod
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="ContxPanel" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Hid=hostpanel.Hid + "." + this.Id
	SetAtt(xnod, "ID", this.Id + "CTX")
	this.Actls=new Array()
	this.Locsize=new QlocSize("0,0", "0,0", hostpanel)
	this.ContextPanel=null;
	this.Events=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
}

Qcontxpanel.prototype.Show=function() {
	if (this.Actls.length >  0) {
		this.Actls[0].OnMouseOver("", "")
		return
	}
	this.ContextPanel = new Qitempanel(this.Xnod, this.HostPage, this.HostPage, this, "CONTEXTPANEL", null, null, 0, 0, 0, 0)
	this.Actls.push(this.ContextPanel)
	this.ContextPanel.Activate()
}

Qcontxpanel.prototype.Activate=function() {
}

Qcontxpanel.prototype.Execute=function(act) {
	if (act == "PanelHide") {
		for (var i=0; i<this.Events.length; i++) {
			var evt=this.Events[i]
			if (evt.Id == "PANELHIDE") ExecCmd(this.HostPage.Area, evt.Act)
		}
		return
	}
	if (act == "PanelClose") {
		this.ContextPanel.Destroy()
		this.ContextPanel = null
		this.Execute("PanelHide")
		return
	}
}

Qcontxpanel.prototype.Hide=function() {
}
Qcontxpanel.prototype.Disable=function() {
}
Qcontxpanel.prototype.Enable=function() {
}

Qcontxpanel.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	if (this.Actls.length > 0) this.Actls[0].Destroy(opt)
	this.Actls=new Array()
}

//***************************************************************** Rotina para criar Display controls num painel
function CreateDisplayCtls(xnod, hostpanel) {
	var hostpage=hostpanel.HostPage
	var wctl
	var xn=xnod.firstChild
	while (xn!=undefined) {
		switch(xn.nodeName) {
			case "PANEL":
				wctl=new Qpanel(xn, hostpage, hostpanel)
				//o hostpanel.Actls.push(wctl) é feito no proprio panel
				break
			case "GRP":
				wctl=new Qgrp(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "TABPANEL":
				wctl=new Qpanel(xn, hostpage, hostpanel, "TABPANEL")
				//hostpanel.Actls.push(wctl) é feito no proprio panel
				break
			case "MENU":
				wctl=new Qmenu(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "DBGRID":
				window.alert(GetMsg(1, "O DBGRID não é suportado em Qweb3 - deve usar MULTIGRID"));
				break;
			case "TITLE":
				wctl=new Qtitle(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "PATH":
				wctl=new Qpath(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "LABEL":
				wctl=new Qlabel(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "LEDTXT":
				wctl=new Qledtxt(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "TEXT":
				wctl=new Qtext(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "COMBO":
				wctl=new Qcombo(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "CHECK":
				wctl=new Qcheck(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "RADIO":
				wctl=new Qradio(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "BOTAO":
				wctl=new Qbotao(xn, hostpage, hostpanel, "BOTAO")
				hostpanel.Actls.push(wctl)
				break
			case "BOTAUX":
				wctl=new Qbotao(xn, hostpage, hostpanel, "BOTAUX")
				hostpanel.Actls.push(wctl)
				break
			case "LINK":
				wctl=new Qbotao(xn, hostpage, hostpanel, "LINK")
				hostpanel.Actls.push(wctl)
				break
			case "IMG":
				wctl=new Qimg(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "MSG":
				wctl=new Qmsg(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "TABSTRIP":
				wctl=new Qtabstrip(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "FLASH":
				wctl=new Qflash(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "CHART":
				wctl=new Qchart(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "DBTREE*":
				wctl=new Qdbtree(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "WEBPAGE":
				wctl=new Qwebpage(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "CRYSTAL":
				wctl=new Qcrystal(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "GRPBOX":
				wctl=new Qgrpbox(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "PARAGRAPH":
				wctl=new Qparagraph(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "SINAL":
				wctl=new Qsinal(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "MULTIGRID":
				wctl=new Qmultigrid(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "DOC":
				wctl=new Qdoc(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "CALEND":
				wctl=new Qcalend(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "CONTEXTPANEL":
				wctl=new Qcontxpanel(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "WINPANEL":
				wctl=new Qwinpanel(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "COLOR":
				wctl=new Qcolor(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "COLORPAD":
				wctl=new Qcolorpad(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "ACORDEON":
				wctl=new Qacordeon(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "SHARE":
				wctl=new Qshare(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "HTMLBOX":
				wctl=new Qhtmlbox(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "FLVIDEO":
				wctl=new Qflvideo(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "FCONTROL":
				wctl = new Qfcontrol(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "FILECTL":
				wctl = new Qfilectl(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "EXTCTL":
				wctl = new Qextctl(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "RIBBON":
				wctl = new Qribbon(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			case "METER":
				wctl = new Qmeter(xn, hostpage, hostpanel)
				hostpanel.Actls.push(wctl)
				break
			/*
			default:
				try {eval("wctl = new " + xn.nodeName + "(xn, hostpage, hostpanel)")}
				catch(exp) {window.alert(GetMsg(1, "Erro na tentativa de criação de controlo do tipo = " + xn.nodeName))}
				break
			*/
		}
		xn=xn.nextSibling
	}
}

//***************************************************************** QGRP - define Grupo
function Qgrp(xnod, hostpage, hostpanel, tipo) {
	this.Tipo="GRP"
	this.Class="PANEL"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.Id=GetAtt(xnod, "ID", "")
	this.Actls=new Array()
	this.Nivseg=GetAtt(xnod, "NIVSEG", "")
	if (this.Id == "") {
		this.Id="Grp" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Style=hostpanel.Style
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.BreakBefore=GetAtt(xnod, "BREAKBEFORE", "N")
	this.BreakAfter=GetAtt(xnod, "BREAKAFTER", "N")
	this.Prediv=""
	var wdiv = document.createElement("DIV")
	wdiv.style.display="none"
	if (this.Locsize.OffL != "0" || this.Locsize.OffT != 0) {
		wdiv.style.position="absolute"
	} else {
		wdiv.style.position="relative"
		wdiv.style.overflow="hidden"
		if (BrowserIE || BrowserOP) {
			wdiv.style.styleFloat="left"
		} else {
			wdiv.style.cssFloat="left"
		}
	}
	this.Locsize.Resize(wdiv)
	this.IniWidth=this.Locsize.ObjW
	this.IniHeight=this.Locsize.ObjH
	var wbrb=""
	var wbra=""
	if (this.BreakBefore == "S") {
		wbrb = document.createElement("DIV")
		wbrb.style.position="relative"
		wbrb.style.clear="both"
		wbrb.style.width="100%"
		wbrb.style.height="0px"
		hostpanel.PanelObj.appendChild(wbrb)
		var whr = document.createElement("HR")
		whr.style.width="100%"
		whr.style.height="0px"
		whr.style.visibility="hidden"
		whr.style.display="none"
		wbrb.appendChild(whr)
	}
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	if (this.Nivseg != "") {
		if (User.ModAutorizado(hostpage.Modulo, this.Nivseg) == false) wdiv.style.display="none"
	}
	hostpanel.PanelObj.appendChild(wdiv)
	wdiv.style.zIndex=0

	if (this.BreakAfter == "S") {
		wbra = document.createElement("DIV")
		wbra.style.position="relative"
		wbra.style.clear="both"
		wbra.style.width="100%"
		wbra.style.height="0px"
		hostpanel.PanelObj.appendChild(wbra)
		var whr = document.createElement("HR")
		whr.style.width="100%"
		whr.style.height="0px"
		whr.style.visibility="hidden"
		whr.style.display="none"
		wbra.appendChild(whr)
	}

	this.PanelObj=wdiv
	this.Hobj=wdiv
	this.Hbefore=wbrb
	this.Hafter=wbra
	CreateDisplayCtls(xnod, this)
	this.Activated=false
}

Qgrp.prototype.Activate=function(opt) {
	this.Activated=true
	if (this.Visivel == "S") this.Show("INIT")
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate("INIT")
	}
}

Qgrp.prototype.Resize=function() {
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Resizable == "S") this.Actls[i].Resize()
	}
}

Qgrp.prototype.Show=function(opt) {
	if (this.Activated == false) {
		this.Activate()
		return
	}
	if (opt == "INIT") {
		this.PanelObj.style.display="block"
		this.Visible=true
		for (var i=0; i<this.Actls.length; i++) {
			this.Actls[i].Show()
		}
		return
	}
	if (opt == "CASCADE" && this.Visivel == "N") return
	this.Visible=true
	this.PanelObj.style.display="block"
	if (opt != "CASCADE") this.Visivel = "S"
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Tipo != "TABPANEL") this.Actls[i].Show("CASCADE")
	}
}

Qgrp.prototype.Hide=function(opt) {
	this.Visible=false
	for (var i=this.Actls.length-1; i>=0; i--) {
		if (opt == "DESTROY" || opt == "DESTROYNOW") {
			this.Actls[i].Destroy(opt)
		} else {
			this.Actls[i].Hide("CASCADE")
		}
	}
	this.PanelObj.style.display="none"
	this.Visible=false
	if (opt == "DESTROY" || opt == "DESTROYNOW") {
		this.Destroy2()
	} else {
		if (opt != "CASCADE") this.Visivel = "N"
	}
}

Qgrp.prototype.Expand=function() {
	this.Show()
	var wanim=new Qanimator(this, "MOVE", "LINEAR,10,N", this.Locsize.ObjL, this.Locsize.ObjT, this.IniWidth, this.IniHeight)
	wanim.Activate(this.Expand2)
}

Qgrp.prototype.Expand2=function() {

}

Qgrp.prototype.Collapse=function() {
	var wanim=new Qanimator(this, "MOVE", "LINEAR,10,N", this.Locsize.ObjL, this.Locsize.ObjT, this.IniWidth, 1)
	wanim.Activate(this.Collapse2)
}

Qgrp.prototype.Collapse2=function() {
	this.Hide()
}

Qgrp.prototype.Disable=function(tipo) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Disable(tipo)
	}
}

Qgrp.prototype.Enable=function(tipo) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Enable(tipo)
	}
}

Qgrp.prototype.Destroy=function() {GenericDisplayCtl_Destroy.call(this)}

Qgrp.prototype.Destroy2=function() {
	GenericDisplayCtl_Destroy2.call(this)
	this.PanelObj=null
	this.Hobj=null
	this.Hbefore=null
	this.Hafter=null
}

Qgrp.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.HostPanel.OnMouseOver(id, hnod)
}
Qgrp.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.HostPanel.OnMouseOut(id, hnod)
}


//***************************************************************** QMENU - define Menu
function Qmenu(xnod, hostpage, hostpanel) {
	this.Tipo="MENU"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.DatactlObj.Grpctls.push(this)
	this.ForCol=GetAtt(xnod, "FORCOL", "")
	this.ForColIx=null
	if (this.ForCol != "") {
		this.ForColIx=new Array()
		var Aw=this.ForCol.split("[")
		for (var i=0; i<Aw.length; i++) {
			var fcol=this.DatactlObj.GetColIndex(Aw[i])
			if (fcol == null) {
				window.alert(GetMsg(1, "MENU (" + this.Id + ") referencia um FORCOL (" + Aw[i] + ") inválido"))
			} else {
				this.ForColIx.push(fcol)
			}
		}
	}
	this.PanelObj=this.Hobj
	this.DataPanels=new Array()
	this.DataPforVal=new Array()
	this.ContextPanels=new Array()
	this.ContextPforVal=new Array()
	this.Hpad=GetAtt(xnod, "HPADDING", 0, "N")
	this.Vpad=GetAtt(xnod, "VPADDING", 0, "N")
	this.XpandDir=GetAtt(xnod, "XPANDDIR", "RIGHT")
	this.ShowUnauth=GetAtt(xnod, "SHOWUNAUTH", "S")
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "DATAPANEL") {
			var Autolayout=GetAtt(xn, "AUTOLAYOUT", "")
			if (Autolayout == "S") {
				var wsize=GetAtt(xn, "SIZE", "22,22")
				var Aw=wsize.split(",")
				this.AutoDataWidth=Aw[0]
				this.AutoDataHeight=Aw[1]
				var xstr="<DATAPANEL LOCATION=\"0,0\" SIZE=\"" + Aw[0] + "," + Aw[1] + "\">"
				xstr +=  "  <TEXT LOCATION=\"0,0\" SIZE=\"*,20\" DATACTL=\"" + this.Datactl + "\" DATAFLD=\"label\" READONLY=\"S\" ALIGN=\"left\"/>"
				xstr +=  "</DATAPANEL>"
				var xnod=CreateXnode(xstr)
				this.DataPanels.push(xnod)
			} else {
				this.DataPanels.push(xn)
			}
			var forval=GetAtt(xn, "FORVAL", "*[*[*[*")
			var aforval=forval.split("[")
			this.DataPforVal.push(aforval)
		}
		if (xn.nodeName == "CONTEXTPANEL") {
			var Autolayout=GetAtt(xn, "AUTOLAYOUT", "")
			if (Autolayout == "S") {
				this.ContextPanels.push(null)
			} else {
				this.ContextPanels.push(xn)
			}
			var forval=GetAtt(xn, "FORVAL", "")
			var aforval=forval.split("[")
			this.ContextPforVal.push(aforval)
		}
		xn=xn.nextSibling
	}
	if (this.DataPanels.length == 0) {
		this.DataPanels.push(null)
		var aforval=new Array()
		this.DataPforVal.push(aforval)
	}
	this.Hdet=new Qstackpanel(this.HostPage, this, this, "0,0", "*,*", this.Vpad, this.Hpad, 1, 99)
	this.Actls.push(this.Hdet)
	this.DadosN0=new Array()
	this.DadosN1=new Array()
	this.DadosN2=new Array()
	this.DadosN3=new Array()
	this.DadosN4=new Array()
	this.SelIndexN0=-1
	this.SelIndexN1=-1
	this.SelIndexN2=-1
	this.SelIndexN3=-1
	this.PanelSelN0=null
	this.PanelSelN1=null
	this.PanelSelN2=null
	this.PanelSelN3=null
	this.Active=false
	this.LastKey=""
	this.MouseIsOver=false
}

Qmenu.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qmenu.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qmenu.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qmenu.prototype.SetState=function() {}

Qmenu.prototype.Execute=function(act, parm) {
	if (act == "DetOut") {
		if (this.MouseIsOver == false) {
			this.CloseAll()
			this.LastKey=""
		}
		return
	}
}

Qmenu.prototype.SetVal=function(opt) {
	var Cols=this.DatactlObj.Cols
	var Dados = this.DatactlObj.Dados
	var DadosN0=new Array()
	var DadosN1=new Array()
	var DadosN2=new Array()
	var DadosN3=new Array()
	var DadosN4=new Array()
	var SelIndexN0=-1
	var SelIndexN1=-1
	var SelIndexN2=-1
	var SelIndexN3=-1
	for (var r=0; r<Dados.length; r++) {
		var Rec=Dados[r]
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var vis=Rec.Field("vis").Val
		var tipo=Rec.Field("tipo").Val
		if (vis == "S")  {
			if (niv == "0") {
				if (tipo == "O") SelIndexN0=DadosN0.length
				DadosN0.push(Rec)
			}
			if (niv == "1") {
				if (tipo == "O") SelIndexN1=DadosN1.length
				DadosN1.push(Rec)
			}
			if (niv == "2") {
				if (tipo == "O") SelIndexN2=DadosN2.length
				DadosN2.push(Rec)
			}
			if (niv == "3") {
				if (tipo == "O") SelIndexN3=DadosN3.length
				DadosN3.push(Rec)
			}
			if (niv == "4") DadosN4.push(Rec)
		}
	}
	//if (this.DadosN0.length == 0) {
	if (this.DadosN0 != DadosN0) {
		this.DadosN0=DadosN0
		this.DrawN0()
	}
	if (SelIndexN0 != this.SelIndexN0) {
		this.SelIndexN1=-1
		if (this.ContextPanelN1 != null && this.ContextPanelN1 != undefined) {
			this.ContextPanelN1.Destroy()
			this.ContextPanelN1=null
		}
		this.DadosN1=DadosN1
		this.SelIndexN0=SelIndexN0
		if (this.DadosN1.length > 0) this.DrawN1()
	}
	if (SelIndexN1 == -1) {
		if (this.ContextPanelN2 != null && this.ContextPanelN2 != undefined) {
			this.ContextPanelN2.Destroy()
			this.ContextPanelN2=null
		}
		this.SelIndexN1=-1
	}
	if (SelIndexN1 != this.SelIndexN1) {
		if (SelIndexN1 != -1) {
			this.DadosN2=DadosN2
			this.SelIndexN1=SelIndexN1
			if (this.DadosN2.length > 0) {
				this.DrawN2()
			} else {
				if (this.ContextPanelN2 != null && this.ContextPanelN2 != undefined) {
					this.ContextPanelN2.Destroy()
					this.ContextPanelN2=null
				}
			}
		}
	}
	if (SelIndexN2 == -1) {
		if (this.ContextPanelN3 != null && this.ContextPanelN3 != undefined) {
			this.ContextPanelN3.Destroy()
			this.ContextPanelN3=null
		}
		this.SelIndexN2=-1
	}
	if (SelIndexN2 != this.SelIndexN2) {
		if (SelIndexN2 != -1) {
			this.DadosN3=DadosN3
			this.SelIndexN2=SelIndexN2
			if (this.DadosN3.length > 0) {
				this.DrawN3()
			} else {
				if (this.ContextPanelN3 != null && this.ContextPanelN3 != undefined) {
					this.ContextPanelN3.Destroy()
					this.ContextPanelN3=null
				}
			}
		}
	}
	if (SelIndexN3 == -1) {
		if (this.ContextPanelN4 != null && this.ContextPanelN4 != undefined) {
			this.ContextPanelN4.Destroy()
			this.ContextPanelN4=null
		}
		this.SelIndexN3=-1
	}
	if (SelIndexN3 != this.SelIndexN3) {
		if (SelIndexN3 != -1) {
			this.DadosN4=DadosN4
			this.SelIndexN3=SelIndexN3
			if (this.DadosN4.length > 0) {
				this.DrawN4()
			} else {
				if (this.ContextPanelN4 != null && this.ContextPanelN4 != undefined) {
					this.ContextPanelN4.Destroy()
					this.ContextPanelN4=null
				}
			}
		}
	}
	for (var i=0; i<this.Hdet.Actls.length; i++) {
		if (i == this.SelIndexN0) {
			this.Hdet.Actls[i].Mark("SEL")
		} else {
			this.Hdet.Actls[i].Mark("UNSEL")
			if (this.Hdet.Actls[i].Record.Key == this.LastKey) this.Hdet.Actls[i].SetState("HIGH")
		}
	}
	if (this.Hdet1 != undefined && this.Hdet1 != null) {
		for (var i=0; i<this.Hdet1.Actls.length; i++) {
			if (i == this.SelIndexN1) {
				this.Hdet1.Actls[i].Mark("SEL")
			} else {
				this.Hdet1.Actls[i].Mark("UNSEL")
				if (this.Hdet1.Actls[i].Record.Key == this.LastKey) this.Hdet1.Actls[i].SetState("HIGH")
			}
		}
	}
	if (this.Hdet2 != undefined && this.Hdet2 != null) {
		for (var i=0; i<this.Hdet2.Actls.length; i++) {
			if (i == this.SelIndexN2) {
				this.Hdet2.Actls[i].Mark("SEL")
			} else {
				this.Hdet2.Actls[i].Mark("UNSEL")
				if (this.Hdet2.Actls[i].Record.Key == this.LastKey) this.Hdet2.Actls[i].SetState("HIGH")
			}
		}
	}
	if (this.Hdet3 != undefined && this.Hdet3 != null) {
		for (var i=0; i<this.Hdet3.Actls.length; i++) {
			if (i == this.SelIndexN3) {
				this.Hdet3.Actls[i].Mark("SEL")
			} else {
				this.Hdet3.Actls[i].Mark("UNSEL")
				if (this.Hdet3.Actls[i].Record.Key == this.LastKey) this.Hdet3.Actls[i].SetState("HIGH")
			}
		}
	}
}

Qmenu.prototype.DrawN0=function() {
	this.Hdet.DestroyPanels()
	var n=0
	for (var r=0; r<this.DadosN0.length; r++) {
		var Rec=this.DadosN0[r]
		var wlinha=""
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var tipo=Rec.Field("tipo").Val
		if (this.ForColIx != null) {
			var Avalrec=new Array()
			for (var c=0; c<this.ForColIx.length; c++) {
				Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
			}
			for (var i=0; i<this.DataPanels.length; i++) {
				var ismatch=true
				var Aforval=this.DataPforVal[i]
				for (var c=0; c<this.ForColIx.length; c++) {
					if (Aforval[c] != "*") {
						if (Avalrec[c] != Aforval[c]) {
							ismatch=false
							break
						}
					}
				}
				if (ismatch == true) {
					Rec.ResetCtls()
					wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet, this, "N0.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
					break
				}
			}
		} else {
			Rec.ResetCtls()
			wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet, this, "N0.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
		}
		if (wlinha != "") {
			var autoriz=Rec.Field("autoriz").Val
			if (autoriz == "N") wlinha.Disable("AUT")
			this.Hdet.AddPanel(wlinha)
			var wctl=""
			for (var i=0; i<Rec.Fields.length; i++) {
				var Field=Rec.Fields[i]
				for (var c=0; c<Field.ColCtls.length; c++) {
					wctl=Field.ColCtls[c]
					wctl.SetVal(Field.Val)
				}
			}
			n++
		}
	}
	this.Hdet.ActivatePanels()
}

Qmenu.prototype.DrawN1=function() {
	var selectedctxpanel=null
	if (this.ForColIx != null && this.ContextPanels.length > 0) {
		var wparentrec=this.DadosN0[this.SelIndexN0]
		var Avalrec=new Array()
		for (var c=0; c<this.ForColIx.length; c++) {
			if (wparentrec.Coldefs[this.ForColIx[c]].Id != "niv") {
				Avalrec.push(wparentrec.Fields[this.ForColIx[c]].Val)
			} else {
				Avalrec.push("1")
			}
		}
		for (var i=0; i<this.ContextPanels.length; i++) {
			var ismatch=true
			var Aforval=this.ContextPforVal[i]
			for (var c=0; c<this.ForColIx.length; c++) {
				if (Aforval[c] != "*") {
					if (Avalrec[c] != Aforval[c]) {
						ismatch=false
						break
					}
				}
			}
			if (ismatch == true) {
				selectedctxpanel=this.ContextPanels[i]
				break
			}
		}
	}
	var wpanel=this.Hdet.Actls[this.SelIndexN0]
	var offset=GetOffsetFor("APP", wpanel)
	if (this.ContextPanelN1 != undefined && this.ContextPanelN1 != null) {
		this.ContextPanelN1.Destroy()
		this.ContextPanelN1=null
	}
	if (this.ContextPanelN2 != undefined && this.ContextPanelN2 != null) {
		this.ContextPanelN2.Destroy()
		this.ContextPanelN2=null
	}
	if (selectedctxpanel == null) {
		this.ContextPanelN1 = new Qitempanel(null, this.HostPage, App, this, "N1.MENU.DROPPANEL", null, null, offset.Left - App.Locsize.MargL, wpanel.Locsize.ObjH + offset.Top - App.Locsize.MargT, 300, 400)
	} else {
		this.ContextPanelN1 = new Qitempanel(selectedctxpanel, this.HostPage, App, this, "N1.MENU.DROPPANEL", null, null)
		this.ContextPanelN1.SetLocation((offset.Left - App.Locsize.MargL) + "," + (wpanel.Locsize.ObjH + offset.Top - App.Locsize.MargT))
	}
	this.Actls.push(this.ContextPanelN1)
	var wpanel=GetCtlChild(this.ContextPanelN1, "MENUDATA")
	if (wpanel == null) {
		this.Hdet1=new Qstackpanel(this.HostPage, this.ContextPanelN1, this, "0,0", "*,*", this.Vpad, this.Hpad, 99, 1)
	} else {
		this.Hdet1=new Qstackpanel(this.HostPage, wpanel, this, "0,0", "*,*", 0, 0, 99, 1)
	}
	this.Hdet1.SetScroll("N")
	this.ContextPanelN1.Actls.push(this.Hdet1)
	this.Hdet1.Activate()
	var n=0
	for (var r=0; r<this.DadosN1.length; r++) {
		var Rec=this.DadosN1[r]
		var wlinha=""
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var tipo=Rec.Field("tipo").Val
		var autoriz=Rec.Field("autoriz").Val
		if (this.ForColIx != null && autoriz == "S") {
			var Avalrec=new Array()
			for (var c=0; c<this.ForColIx.length; c++) {
				Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
			}
			for (var i=0; i<this.DataPanels.length; i++) {
				var ismatch=true
				var Aforval=this.DataPforVal[i]
				for (var c=0; c<this.ForColIx.length; c++) {
					if (Aforval[c] != "*") {
						if (this.DatactlObj.Cols[this.ForColIx[c]].Id == "niv") {
							if (Aforval[c] != 1) {
								ismatch=false
								break
							}
						} else {
							if (Avalrec[c] != Aforval[c]) {
								ismatch=false
								break
							}
						}
					}
				}
				if (ismatch == true) {
					Rec.ResetCtls()
					if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet1, this, "N1.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
					break
				}
			}
		} else {
			Rec.ResetCtls()
			if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet1, this, "N1.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
		}
		if (wlinha != "") {
			var autoriz=Rec.Field("autoriz").Val
			if (autoriz == "N") wlinha.Disable("AUT")
			this.Hdet1.AddPanel(wlinha)
			var wctl=""
			for (var i=0; i<Rec.Fields.length; i++) {
				var Field=Rec.Fields[i]
				for (var c=0; c<Field.ColCtls.length; c++) {
					wctl=Field.ColCtls[c]
					wctl.SetVal(Field.Val)
				}
			}
			n++
		}
	}
	this.Hdet1.ActivatePanels()
	if (selectedctxpanel == null) {
		this.ContextPanelN1.SetSize((this.Hdet1.MaxWidth + this.ContextPanelN1.Locsize.MargL + this.ContextPanelN1.Locsize.MargR + 2) + "," + (this.Hdet1.MaxHeight + this.ContextPanelN1.Locsize.MargT + this.ContextPanelN1.Locsize.MargB + 2))
	}
	this.ContextPanelN1.Resize()
	this.ContextPanelN1.Activate()
}

Qmenu.prototype.DrawN2=function() {
	var selectedctxpanel=null
	if (this.ForColIx != null && this.ContextPanels.length > 0) {
		var wparentrec=this.DadosN1[this.SelIndexN1]
		var Avalrec=new Array()
		for (var c=0; c<this.ForColIx.length; c++) {
			if (wparentrec.Coldefs[this.ForColIx[c]].Id != "niv") {
				Avalrec.push(wparentrec.Fields[this.ForColIx[c]].Val)
			} else {
				Avalrec.push("2")
			}
		}
		for (var i=0; i<this.ContextPanels.length; i++) {
			var ismatch=true
			var Aforval=this.ContextPforVal[i]
			for (var c=0; c<this.ForColIx.length; c++) {
				if (Aforval[c] != "*") {
					if (Avalrec[c] != Aforval[c]) {
						ismatch=false
						break
					}
				}
			}
			if (ismatch == true) {
				selectedctxpanel=this.ContextPanels[i]
				break
			}
		}
	}
	var wpanel=this.Hdet1.Actls[this.SelIndexN1]
	var wparentpanel=wpanel.HostPanel.HostPanel
	var offset=GetOffsetFor("APP", wpanel)
	if (this.ContextPanelN2 != undefined && this.ContextPanelN2 != null) {
		this.ContextPanelN2.Destroy()
		this.ContextPanelN2=null
	}
	if (selectedctxpanel == null) {
		this.ContextPanelN2 = new Qitempanel(null, this.HostPage, App, this, "N2.MENU.DROPPANEL", null, null, wpanel.Locsize.ObjW + offset.Left, offset.Top, 300, 400)
	} else {
		this.ContextPanelN2 = new Qitempanel(selectedctxpanel, this.HostPage, App, this, "N2.MENU.DROPPANEL", null, null)
		this.ContextPanelN2.SetLocation((wpanel.Locsize.ObjW + offset.Left) + "," + (offset.Top))
	}
	this.Actls.push(this.ContextPanelN2)
	var wpanel=GetCtlChild(this.ContextPanelN2, "MENUDATA")
	if (wpanel == null) {
		this.Hdet2=new Qstackpanel(this.HostPage, this.ContextPanelN2, this, "0,0", "*,*", this.Vpad, this.Hpad, 99, 1)
	} else {
		this.Hdet2=new Qstackpanel(this.HostPage, wpanel, this, "0,0", "*,*", 0, 0, 99, 1)
	}
	this.Hdet2.SetScroll("N")
	this.ContextPanelN2.Actls.push(this.Hdet2)
	this.Hdet2.Activate()
	var n=0
	for (var r=0; r<this.DadosN2.length; r++) {
		var Rec=this.DadosN2[r]
		var wlinha=""
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var autoriz=Rec.Field("autoriz").Val
		if (this.ForColIx != null) {
			var Avalrec=new Array()
			for (var c=0; c<this.ForColIx.length; c++) {
				Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
			}
			for (var i=0; i<this.DataPanels.length; i++) {
				var ismatch=true
				var Aforval=this.DataPforVal[i]
				for (var c=0; c<this.ForColIx.length; c++) {
					if (Aforval[c] != "*") {
						if (this.DatactlObj.Cols[this.ForColIx[c]].Id == "niv") {
							if (Aforval[c] != 2) {
								ismatch=false
								break
							}
						} else {
							if (Avalrec[c] != Aforval[c]) {
								ismatch=false
								break
							}
						}
					}
				}
				if (ismatch == true) {
					Rec.ResetCtls()
					if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet2, this, "N2.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
					break
				}
			}
		} else {
			Rec.ResetCtls()
			if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet2, this, "N2.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
		}
		if (wlinha != "") {
			var autoriz=Rec.Field("autoriz").Val
			if (autoriz == "N") wlinha.Disable("AUT")
			this.Hdet2.AddPanel(wlinha)
			var wctl=""
			for (var i=0; i<Rec.Fields.length; i++) {
				var Field=Rec.Fields[i]
				for (var c=0; c<Field.ColCtls.length; c++) {
					wctl=Field.ColCtls[c]
					wctl.SetVal(Field.Val)
				}
			}
			n++
		}
	}
	this.Hdet2.ActivatePanels()
	if (selectedctxpanel == null) {
		this.ContextPanelN2.SetSize((this.Hdet2.MaxWidth + this.ContextPanelN2.Locsize.MargL + this.ContextPanelN2.Locsize.MargR + 2) + "," + (this.Hdet2.MaxHeight + this.ContextPanelN2.Locsize.MargT + this.ContextPanelN2.Locsize.MargB + 2))
	}
	this.ContextPanelN2.Resize()
	if (this.XpandDir == "RIGHT") {
		var actw=this.ContextPanelN2.Locsize.ObjW + this.ContextPanelN2.Locsize.ObjL
		if (actw > offset.MaxWidth - 10) {  //ver se ha espaço para abrir para a direita ou se abre para a esquerda
			var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN2.Locsize.ObjW
			this.ContextPanelN2.SetLocation(newleft + "," + this.ContextPanelN2.Locsize.ObjT)
			this.ContextPanelN2.Resize()
		}
	} else {
		var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN2.Locsize.ObjW
		if (newleft > 10) {  //ver se ha espaço para abrir para a esquerda ou se abre para a direita
			this.ContextPanelN2.SetLocation(newleft + "," + this.ContextPanelN2.Locsize.ObjT)
			this.ContextPanelN2.Resize()
		}
	}
	this.ContextPanelN2.Activate()
}

Qmenu.prototype.DrawN3=function() {
	var selectedctxpanel=null
	if (this.ForColIx != null && this.ContextPanels.length > 0) {
		var wparentrec=this.DadosN2[this.SelIndexN2]
		var Avalrec=new Array()
		for (var c=0; c<this.ForColIx.length; c++) {
			if (wparentrec.Coldefs[this.ForColIx[c]].Id != "niv") {
				Avalrec.push(wparentrec.Fields[this.ForColIx[c]].Val)
			} else {
				Avalrec.push("3")
			}
		}
		for (var i=0; i<this.ContextPanels.length; i++) {
			var ismatch=true
			var Aforval=this.ContextPforVal[i]
			for (var c=0; c<this.ForColIx.length; c++) {
				if (Aforval[c] != "*") {
					if (Avalrec[c] != Aforval[c]) {
						ismatch=false
						break
					}
				}
			}
			if (ismatch == true) {
				selectedctxpanel=this.ContextPanels[i]
				break
			}
		}
	}
	var wpanel=this.Hdet2.Actls[this.SelIndexN2]
	var wparentpanel=wpanel.HostPanel.HostPanel
	var offset=GetOffsetFor("APP", wpanel)
	if (this.ContextPanelN3 != undefined && this.ContextPanelN3 != null) {
		this.ContextPanelN3.Destroy()
		this.ContextPanelN3=null
	}
	if (selectedctxpanel == null) {
		this.ContextPanelN3 = new Qitempanel(null, this.HostPage, App, this, "N3.MENU.DROPPANEL", null, null, wpanel.Locsize.ObjW + offset.Left, offset.Top, 300, 400)
	} else {
		this.ContextPanelN3 = new Qitempanel(selectedctxpanel, this.HostPage, App, this, "N3.MENU.DROPPANEL", null, null)
		this.ContextPanelN3.SetLocation((wpanel.Locsize.ObjW + offset.Left) + "," + (offset.Top))
	}
	this.Actls.push(this.ContextPanelN3)
	var wpanel=GetCtlChild(this.ContextPanelN3, "MENUDATA")
	if (wpanel == null) {
		this.Hdet3=new Qstackpanel(this.HostPage, this.ContextPanelN3, this, "0,0", "*,*", this.Vpad, this.Hpad, 99, 1)
	} else {
		this.Hdet3=new Qstackpanel(this.HostPage, wpanel, this, "0,0", "*,*", 0, 0, 99, 1)
	}
	this.Hdet3.SetScroll("N")
	this.ContextPanelN3.Actls.push(this.Hdet3)
	this.Hdet3.Activate()
	var n=0
	for (var r=0; r<this.DadosN3.length; r++) {
		var Rec=this.DadosN3[r]
		var wlinha=""
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var autoriz=Rec.Field("autoriz").Val
		if (this.ForColIx != null) {
			var Avalrec=new Array()
			for (var c=0; c<this.ForColIx.length; c++) {
				Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
			}
			for (var i=0; i<this.DataPanels.length; i++) {
				var ismatch=true
				var Aforval=this.DataPforVal[i]
				for (var c=0; c<this.ForColIx.length; c++) {
					if (Aforval[c] != "*") {
						if (this.DatactlObj.Cols[this.ForColIx[c]].Id == "niv") {
							if (Aforval[c] != 3) {
								ismatch=false
								break
							}
						} else {
							if (Avalrec[c] != Aforval[c]) {
								ismatch=false
								break
							}
						}
					}
				}
				if (ismatch == true) {
					Rec.ResetCtls()
					if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet3, this, "N3.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
					break
				}
			}
		} else {
			Rec.ResetCtls()
			if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet3, this, "N3.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
		}
		if (wlinha != "") {
			var autoriz=Rec.Field("autoriz").Val
			if (autoriz == "N") wlinha.Disable("AUT")
			this.Hdet3.AddPanel(wlinha)
			var wctl=""
			for (var i=0; i<Rec.Fields.length; i++) {
				var Field=Rec.Fields[i]
				for (var c=0; c<Field.ColCtls.length; c++) {
					wctl=Field.ColCtls[c]
					wctl.SetVal(Field.Val)
				}
			}
			n++
		}
	}
	this.Hdet3.ActivatePanels()
	if (selectedctxpanel == null) {
		this.ContextPanelN3.SetSize((this.Hdet3.MaxWidth + this.ContextPanelN3.Locsize.MargL + this.ContextPanelN3.Locsize.MargR + 2) + "," + (this.Hdet3.MaxHeight + this.ContextPanelN3.Locsize.MargT + this.ContextPanelN3.Locsize.MargB + 2))
	}
	this.ContextPanelN3.Resize()
	if (this.XpandDir == "RIGHT") {
		var actw=this.ContextPanelN3.Locsize.ObjW + this.ContextPanelN3.Locsize.ObjL
		if (actw > offset.MaxWidth - 10) {  //ver se ha espaço para abrir para a direita ou se abre para a esquerda
			var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN3.Locsize.ObjW
			this.ContextPanelN3.SetLocation(newleft + "," + this.ContextPanelN3.Locsize.ObjT)
			this.ContextPanelN3.Resize()
		}
	} else {
		var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN3.Locsize.ObjW
		if (newleft > 10) {  //ver se ha espaço para abrir para a esquerda ou se abre para a direita
			this.ContextPanelN3.SetLocation(newleft + "," + this.ContextPanelN3.Locsize.ObjT)
			this.ContextPanelN3.Resize()
		}
	}
	this.ContextPanelN3.Activate()
}

Qmenu.prototype.DrawN4=function() {
	var selectedctxpanel=null
	if (this.ForColIx != null && this.ContextPanels.length > 0) {
		var wparentrec=this.DadosN3[this.SelIndexN3]
		var Avalrec=new Array()
		for (var c=0; c<this.ForColIx.length; c++) {
			if (wparentrec.Coldefs[this.ForColIx[c]].Id != "niv") {
				Avalrec.push(wparentrec.Fields[this.ForColIx[c]].Val)
			} else {
				Avalrec.push("4")
			}
		}
		for (var i=0; i<this.ContextPanels.length; i++) {
			var ismatch=true
			var Aforval=this.ContextPforVal[i]
			for (var c=0; c<this.ForColIx.length; c++) {
				if (Aforval[c] != "*") {
					if (Avalrec[c] != Aforval[c]) {
						ismatch=false
						break
					}
				}
			}
			if (ismatch == true) {
				selectedctxpanel=this.ContextPanels[i]
				break
			}
		}
	}
	var wpanel=this.Hdet3.Actls[this.SelIndexN3]
	var wparentpanel=wpanel.HostPanel.HostPanel
	var offset=GetOffsetFor("APP", wpanel)
	if (this.ContextPanelN4 != undefined && this.ContextPanelN4 != null) {
		this.ContextPanelN4.Destroy()
		this.ContextPanelN4=null
	}
	if (selectedctxpanel == null) {
		this.ContextPanelN4 = new Qitempanel(null, this.HostPage, App, this, "N4.MENU.DROPPANEL", null, null, wpanel.Locsize.ObjW + offset.Left, offset.Top, 300, 400)
	} else {
		this.ContextPanelN4 = new Qitempanel(selectedctxpanel, this.HostPage, App, this, "N4.MENU.DROPPANEL", null, null)
		this.ContextPanelN4.SetLocation((wpanel.Locsize.ObjW + offset.Left) + "," + (offset.Top))
	}
	this.Actls.push(this.ContextPanelN4)
	var wpanel=GetCtlChild(this.ContextPanelN4, "MENUDATA")
	if (wpanel == null) {
		this.Hdet4=new Qstackpanel(this.HostPage, this.ContextPanelN4, this, "0,0", "*,*", this.Vpad, this.Hpad, 99, 1)
	} else {
		this.Hdet4=new Qstackpanel(this.HostPage, wpanel, this, "0,0", "*,*", 0, 0, 99, 1)
	}
	this.Hdet4.SetScroll("N")
	this.ContextPanelN4.Actls.push(this.Hdet4)
	this.Hdet4.Activate()
	var n=0
	for (var r=0; r<this.DadosN4.length; r++) {
		var Rec=this.DadosN4[r]
		var wlinha=""
		var niv=Rec.Field("niv").Val
		if (this.DatactlObj.NiveisZero == 1 && this.DatactlObj.HideSingleLevelZero == "S") niv=niv-1
		var autoriz=Rec.Field("autoriz").Val
		if (this.ForColIx != null) {
			var Avalrec=new Array()
			for (var c=0; c<this.ForColIx.length; c++) {
				Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
			}
			for (var i=0; i<this.DataPanels.length; i++) {
				var ismatch=true
				var Aforval=this.DataPforVal[i]
				for (var c=0; c<this.ForColIx.length; c++) {
					if (Aforval[c] != "*") {
						if (this.DatactlObj.Cols[this.ForColIx[c]].Id == "niv") {
							if (Aforval[c] != 4) {
								ismatch=false
								break
							}
						} else {
							if (Avalrec[c] != Aforval[c]) {
								ismatch=false
								break
							}
						}
					}
				}
				if (ismatch == true) {
					Rec.ResetCtls()
					if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet4, this, "N4.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
					break
				}
			}
		} else {
			Rec.ResetCtls()
			if (autoriz == "S" || this.ShowUnauth == "S") wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet4, this, "N4.MENU.DATAPANEL", Rec, n, 0, 0, "30" , "30")
		}
		if (wlinha != "") {
			var autoriz=Rec.Field("autoriz").Val
			if (autoriz == "N") wlinha.Disable("AUT")
			this.Hdet4.AddPanel(wlinha)
			var wctl=""
			for (var i=0; i<Rec.Fields.length; i++) {
				var Field=Rec.Fields[i]
				for (var c=0; c<Field.ColCtls.length; c++) {
					wctl=Field.ColCtls[c]
					wctl.SetVal(Field.Val)
				}
			}
			n++
		}
	}
	this.Hdet4.ActivatePanels()
	if (selectedctxpanel == null) {
		this.ContextPanelN4.SetSize((this.Hdet4.MaxWidth + this.ContextPanelN4.Locsize.MargL + this.ContextPanelN4.Locsize.MargR + 2) + "," + (this.Hdet4.MaxHeight + this.ContextPanelN4.Locsize.MargT + this.ContextPanelN4.Locsize.MargB + 2))
	}
	this.ContextPanelN4.Resize()
	if (this.XpandDir == "RIGHT") {
		var actw=this.ContextPanelN4.Locsize.ObjW + this.ContextPanelN4.Locsize.ObjL
		if (actw > offset.MaxWidth - 10) {  //ver se ha espaço para abrir para a direita ou se abre para a esquerda
			var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN4.Locsize.ObjW
			this.ContextPanelN4.SetLocation(newleft + "," + this.ContextPanelN4.Locsize.ObjT)
			this.ContextPanelN4.Resize()
		}
	} else {
		var newleft=wparentpanel.Locsize.ObjL - this.ContextPanelN4.Locsize.ObjW
		if (newleft > 10) {  //ver se ha espaço para abrir para a esquerda ou se abre para a direita
			this.ContextPanelN4.SetLocation(newleft + "," + this.ContextPanelN4.Locsize.ObjT)
			this.ContextPanelN4.Resize()
		}
	}
	this.ContextPanelN4.Activate()
}


Qmenu.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qmenu.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qmenu.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qmenu.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qmenu.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qmenu.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qmenu.prototype.CloseAll=function() {
	if (this.SelIndexN0 > -1) {
		var panel=this.Hdet.Actls[this.SelIndexN0]
		var r=this.DatactlObj.SetRow(panel.Record.Key, false)
		this.DatactlObj.Execute("CLOSE")
		for (var i=0; i<this.Hdet.Actls.length; i++) {
			this.Hdet.Actls[i].Mark("UNSEL")
		}
	}
	this.SelIndexN0=-1
	this.SelIndexN1=-1
	this.SelIndexN2=-1
	if (this.ContextPanelN1 != undefined && this.ContextPanelN1 != null) {
		this.ContextPanelN1.Destroy()
		this.ContextPanelN1=null
	}
	if (this.ContextPanelN2 != undefined && this.ContextPanelN2 != null) {
		this.ContextPanelN2.Destroy()
		this.ContextPanelN2=null
	}
	if (this.ContextPanelN3 != undefined && this.ContextPanelN3 != null) {
		this.ContextPanelN3.Destroy()
		this.ContextPanelN3=null
	}
	if (this.ContextPanelN4 != undefined && this.ContextPanelN4 != null) {
		this.ContextPanelN4.Destroy()
		this.ContextPanelN4=null
	}
}

Qmenu.prototype.DetClick=function(panel) {
	if (panel.Tipo.indexOf("N0.MENU.DATAPANEL") > -1) {
		if (panel.Record.Field("tipo").Val == "L") {
			var r=this.DatactlObj.SetRow(panel.Record.Key, false)
			this.DatactlObj.Execute("NAVIGATEX")
			this.CloseAll()
		} else {
			if (this.LastKey != panel.Record.Key) {
				this.CloseAll()
			}
		}
	} else {
		var r=this.DatactlObj.SetRow(panel.Record.Key, false)
		this.DatactlObj.Execute("NAVIGATEX")
		this.CloseAll()
	}
}

Qmenu.prototype.DetDblClick=function(panel) {
}

Qmenu.prototype.DetOver=function(panel) {
	this.MouseIsOver=true
	if (panel.Tipo.indexOf("MENU.DROPPANEL") > -1) return
	if (panel.Disabled == true) return
	var r=this.DatactlObj.SetRow(panel.Record.Key, false)
	if (this.LastKey != panel.Record.Key) {
		this.LastKey=panel.Record.Key
		this.DatactlObj.Execute("OPEN")
	}
}

Qmenu.prototype.DetOut=function(panel) {
	this.MouseIsOver=false
	ExecCmdDelayed(300, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",DetOut")
}

Qmenu.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qmenu.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qmenu.prototype.OnScroll=function() {}

Qmenu.prototype.OnContext=function() {}

Qmenu.prototype.SetCurrentRow=function(nrow) {}



//***************************************************************** QMULTIGRID - define MultiGrid
function Qmultigrid(xnod, hostpage, hostpanel) {
	this.Tipo="MULTIGRID"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.DatactlObj.Grpctls.push(this)
	this.Showcheck=GetAtt(xnod, "SHOWCHECK", "N")
	this.Alloworder=GetAtt(xnod, "ALLOWORDER", "S")
	this.Allowheaderresize=GetAtt(xnod, "ALLOWHEADERRESIZE", "S")
	this.Allowcontext=GetAtt(xnod, "ALLOWCONTEXT", "N")
	this.ContextOnClick=GetAtt(xnod, "CONTEXTONCLICK", "N")
	this.Allowmulti=GetAtt(xnod, "ALLOWMULTISEL", "N")
	this.AllowChange=GetAtt(xnod, "ALLOWCHANGE", "N")
	this.AllowInsert=GetAtt(xnod, "ALLOWINSERT", "N")
	this.AllowDelete = GetAtt(xnod, "ALLOWDELETE", "N")
	this.AutoColResize = GetAtt(xnod, "AUTOCOLRESIZE", "N")
	this.AutoHeightResize = GetAtt(xnod, "AUTOHEIGHTRESIZE", "N")
	this.PointerScroll = GetAtt(xnod, "POINTERSCROLL", "N")
	this.Actls=new Array()
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Tip=GetAtt(xnod, "TIP", "")
	// created by [SF] at [2017.02.14]
	//attriuto para pintar linhas
	this.Functioncolor = GetAtt(xnod, "FUNCTIONCOLOR", "")
	this.Paddh=GetAtt(xnod, "HPADDING", 0, "N")
	this.Paddv=GetAtt(xnod, "VPADDING", 0, "N")
	this.ForCol=GetAtt(xnod, "FORCOL", "")
	this.Hrepeat=GetAtt(xnod, "HREPEAT", 1, "N")
	this.Vrepeat=GetAtt(xnod, "VREPEAT", 9999, "N")
	//variaveis para quando actua como data control
	this.Grpctls=new Array()
	this.Dados=new Array()
	this.SelectedKeys=new Array()
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
	//-------------------------
	this.ForColIx=null
	if (this.ForCol != "") {
		this.ForColIx=new Array()
		var Aw=this.ForCol.split("[")
		for (var i=0; i<Aw.length; i++) {
			var fcol=this.DatactlObj.GetColIndex(Aw[i])
			if (fcol == null) {
				window.alert(GetMsg(1, "MULTIGRID (" + this.Id + ") referencia um FORCOL (" + Aw[i] + ") inválido"))
			} else {
				this.ForColIx.push(fcol)
			}
		}
	}
	this.HeaderPanels=new Array()
	this.AutoHeaderPanel=null
	this.AutoQueryPanel=null
	this.ContextPanel=null
	this.DataPanels=new Array()
	this.DataPforVal=new Array()
	this.AutoDataWidth=0
	this.AutoDataHeight=21
	//this.AutoDataUseCombo=true
	this.FooterPanels=new Array()
	this.HeaderHeight=0
	this.FooterHeight=0
	this.CurrentRow=""
	this.SelectDisabled=false
	this.Gcols=new Array()
	var wleft=0
	var windex=0
	var wncols=0  //numero de colunas visiveis.  Só interessa quando ShowCheck="S"
	if (this.Showcheck == "S") {
		var wcol = new Qcol(null, "$selected", "B", 1)
		wcol.Larg=20
		var wgcol=new Qcolgrid("$selected", "", "B", 20, wcol)
		wgcol.Left=wleft
		wleft=wleft + 20
		wgcol.Index=windex
		this.Gcols.push(wgcol)
		windex++
		for (var i=0; i<this.DatactlObj.Cols.length; i++) {
			var wcol=this.DatactlObj.Cols[i]
			if (wcol.Vis == "S") wncols++
		}
	}
	var wsubtract=0
	if (wncols > 0)	wsubtract=21/wncols   //quando ha ShowCheck é preciso diluir os 20 pixels da checkbox na largura das outras colunas
	for (var i=0; i<this.DatactlObj.Cols.length; i++) {
		var wcol=this.DatactlObj.Cols[i]
		if (wcol.Vis == "S") {
			var wgcol=new Qcolgrid(wcol.Id, wcol.Tit, wcol.Type, wcol.Larg - wsubtract, wcol)
			wgcol.Left=wleft
			wleft=wleft + wcol.Larg
			wcol.Index=windex
			if (i == 0) wgcol.Ord="A"
			this.Gcols.push(wgcol)
			windex++
		}
	}
	var wgcol=new Qcolgrid("filler", "", "A", 600, null)
	wgcol.Left=wleft
	wcol.Index=windex
	this.Gcols.push(wgcol)
	this.PanelObj=this.Hobj
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "HEADERPANEL") {
			var Autolayout=GetAtt(xn, "AUTOLAYOUT", "")
			if (Autolayout == "CAB" || Autolayout == "QRY") {
				if (Autolayout == "CAB") {
					var wsize=GetAtt(xn, "SIZE", "0,21")
					var Aw=wsize.split(",")
					this.AutoCabWidth=Number(Aw[0])
					this.AutoCabHeight=Number(Aw[1])
					var wpanel=new Qitempanel(null, this.HostPage, this, this, this.Tipo4Style + ".AUTOHEADERPANEL", null, null, 0, 0, "*", this.AutoCabHeight)
					this.AutoHeaderPanel=wpanel
				}
				if (Autolayout == "QRY") {
					var wrec=new Qrecord(this.DatactlObj.Cols, new Array())
					var wsize=GetAtt(xn, "SIZE", "0,21")
					var Aw=wsize.split(",")
					this.AutoQryWidth=Number(Aw[0])
					this.AutoQryHeight=Number(Aw[1])
					var wpanel=new Qitempanel(null, this.HostPage, this, this, this.Tipo4Style + ".AUTOQUERYPANEL", wrec, 0, 0, 0, "*", this.AutoQryHeight)
					this.AutoQueryPanel=wpanel
				}
			} else {
				var wpanel=new Qitempanel(xn, this.HostPage, this, this, this.Tipo4Style + ".HEADERPANEL", null, null, 0, 0, "*", 20)
			}
			this.HeaderPanels.push(wpanel)
			this.Actls.push(wpanel)
		}
		if (xn.nodeName == "DATAPANEL") {
			this.DataPanels.push(xn)
			var forval=GetAtt(xn, "FORVAL", "")
			var aforval=forval.split("[")
			this.DataPforVal.push(aforval)
		}
		if (xn.nodeName == "FOOTERPANEL") {
		    var wpanel = new Qitempanel(xn, this.HostPage, this, this, this.Tipo4Style + ".FOOTERPANEL", null, null, 0, 0, "*", 20)
		    wpanel.Hobj.style.zIndex = 3; //martelada enquanto o resize do datapanel não é corrigido
			this.FooterPanels.push(wpanel)
			this.Actls.push(wpanel)
		}
		xn=xn.nextSibling
	}
	if (this.DataPanels.length == 0) {
		this.DataPanels.push(null)
		var aforval=new Array()
		this.DataPforVal.push(aforval)
	}
	//area de detalhe
	this.Hdet=new Qstackpanel(this.HostPage, this, this, "0,0", "20,20", this.Paddv, this.Paddh, this.Vrepeat, this.Hrepeat)
	this.Actls.push(this.Hdet)
	this.Resize()
}

Qmultigrid.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qmultigrid.prototype.Activate2=function(opt) {
	GenericDisplayCtl_Activate2.call(this, opt)
}

Qmultigrid.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qmultigrid.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	var offtop=0
	for (var i=0; i<this.HeaderPanels.length; i++) {
		this.HeaderPanels[i].SetLocation(0 + "," + offtop)
		this.HeaderPanels[i].Resize()
		offtop = offtop + this.HeaderPanels[i].Locsize.ObjH
	}
	var footh=0
	for (var i=0; i<this.FooterPanels.length; i++) {
		footh = footh + this.FooterPanels[i].Locsize.ObjH
	}
	this.HeaderHeight=offtop
	this.FooterHeight=footh
	this.Hdet.SetLocation(0 + "," + offtop)
	this.Hdet.SetSize("*" + "," + "*-" + footh)
	this.Hdet.Resize()

	offtop=this.Hdet.Locsize.ObjT + this.Hdet.Locsize.ObjH - this.Locsize.MargT
	for (var i=0; i<this.FooterPanels.length; i++) {
		this.FooterPanels[i].SetLocation("0," + offtop)
		this.FooterPanels[i].Resize()
		offtop = offtop + this.FooterPanels[i].Locsize.ObjH
    }
    this.RecalcGcols()
    if (this.AutoHeightResize == "S") this.ResizeHeight("RESIZE")
}

Qmultigrid.prototype.ResizeHeight=function(opt) {
	if (opt != "RESIZE") this.Resize()
	if (this.Hdet.MaxHeight == 0) return
	var toth=this.HeaderHeight + this.FooterHeight + this.Locsize.MargT + this.Locsize.MargB + this.Hdet.MaxHeight
	if (toth >= this.Locsize.ObjH) return
	this.Hdet.SetSize("*" + "," + this.Hdet.MaxHeight)
	this.Hdet.Resize()
	var offtop=this.Hdet.Locsize.ObjT + this.Hdet.Locsize.ObjH - this.Locsize.MargT
	for (var i=0; i<this.FooterPanels.length; i++) {
		this.FooterPanels[i].SetLocation("0," + offtop)
		this.FooterPanels[i].Resize()
		offtop = offtop + this.FooterPanels[i].Locsize.ObjH
    }
    this.Locsize.ObjH=offtop + this.Locsize.MargB + this.Locsize.MargT
    this.Hobj.style.position="relative"
    this.Hobj.style.height=this.Locsize.ObjH + "px"

    if (this.HostPanel.Hobj.style.width == "" && BrowserWKIT == true) {  //isto é um bug do Chrome que não calcula correctamente a largura do container à primeira vez
    	this.HostPanel.Hobj.style.width="100%"
    }
}

Qmultigrid.prototype.GetHeightFor=function(lines, maxhdown, maxhup) {
	var warround=this.Locsize.ObjH - this.Hdet.Locsize.ObjH
	var wlinh=this.AutoDataHeight + this.Paddv
	var scoredown=0
	var scoreup=0
	var wutildown=maxhdown - warround
	var wlinsdown=Math.floor(wutildown / wlinh)
	if (wlinsdown > 1) scoredown=1
	if (wlinsdown > lines) scoredown=2
	var wutilup=maxhup - warround
	var wlinsup=Math.floor(wutilup / wlinh)
	if (wlinsup > 1) scoreup=1
	if (wlinsup > lines) scoreup=2
	if (scoredown >= scoreup) {
		if (scoredown == 0) return maxhdown
		if (scoredown == 1) return warround + (wlinsdown * wlinh)
		return warround + (lines * wlinh)
	} else {
		if (scoreup == 0) return -maxhup
		if (scoreup == 1) return -(warround + (wlinsup * wlinh))
		return -(warround + (lines * wlinh))
	}
}

Qmultigrid.prototype.NeedScrolling=function(lines, altura) {
	var warround=this.Locsize.ObjH - this.Hdet.Locsize.ObjH
	var wlinh=this.AutoDataHeight + this.Paddv
	var autil=altura - warround
	if ((autil / wlinh) >= lines) {
		return false
	} else {
		return true
	}
}

Qmultigrid.prototype.RecalcGcols = function(opt) {
    var totwidth = 0
    if (this.AutoColResize != "N") {
        for (var i = 0; i < this.Gcols.length; i++) {
            if (this.Gcols[i].Id != "filler") totwidth = totwidth + this.Gcols[i].Col.Larg
        }
    }
    var realwidth = this.Hdet.Locsize.ObjW
    if (this.Hdet.ScrollV == true) realwidth = realwidth-17
    //So conta se excede por isso não fazemos a diferença contrária
    var dif = totwidth - realwidth
    if (realwidth == 0) dif = 0;
    else dif = 100 * dif / realwidth;

    var colresize=false
    if (this.AutoColResize == "S") {
	    colresize=true
    } else {
	    if (this.AutoColResize != "N") {
		    if (dif <= Number(this.AutoColResize)) colresize=true
	    }
    }
    if (opt == "HEADER") colresize=false
    var wleft = 0
    for (var i = 0; i < this.Gcols.length; i++) {
        this.Gcols[i].Left = wleft
        if (colresize == true && this.Gcols[i].Id != "filler") this.Gcols[i].Larg = Math.floor(realwidth * this.Gcols[i].Col.Larg / totwidth)
        if (this.Gcols[i].Id != "filler") wleft = wleft + this.Gcols[i].Larg
        this.Gcols[i].Index = i
    }
    if (this.AutoHeaderPanel != null) this.AutoHeaderPanel.RefreshCols()
    if (this.AutoQueryPanel != null) this.AutoQueryPanel.RefreshCols()
    if (colresize == true) {
	    this.Hdet.SetDataWidth(wleft)
	    this.RefreshDataCols()
    }
}

Qmultigrid.prototype.RefreshDataCols=function() {
	for (var i=0; i<this.Hdet.Actls.length; i++) {
		this.Hdet.Actls[i].RefreshCols()
	}
}

Qmultigrid.prototype.SetVal=function(valor) {
	if (this.DatactlObj.Tipo != "CALEND") App.BlockAllInput("MULTIGRID")  //não pode bloquear porque o calendario usa botoes com autorepeat
	this.Keys=new Array()
	var wselrow=""
	var wseloffset=-1
	if (valor == "REFRESH") {
		wseloffset=this.Hdet.Hobj.scrollTop
	}
	this.Hdet.DestroyPanels()
	valor = null
	var Cols=this.DatactlObj.Cols
	var pagindex=this.DatactlObj.PagIndex
	var paginas=this.DatactlObj.Paginas
	var Dados = this.DatactlObj.Dados
	var keypagact=paginas[pagindex]
	if (pagindex == paginas.length - 1) {
		var keypagseg="9999999999999999999999999999"
	} else {
		var keypagseg=paginas[pagindex + 1]
	}
	for (var r=0; r<Dados.length; r++) {
		if (Dados[r].Key == keypagact) break
	}
	var key=""
	var n=0
	for (var r=r; r<Dados.length; r++) {
		key = Dados[r].Key
		if (key == keypagseg) break
		var wlinha=""
		var Rec=Dados[r]
		if (Rec.Func != "ELI") {
			if (this.ForColIx != null) {
				var Avalrec=new Array()
				for (var c=0; c<this.ForColIx.length; c++) {
					Avalrec.push(Rec.Fields[this.ForColIx[c]].Val)
				}
				for (var i=0; i<this.DataPanels.length; i++) {
					var ismatch=true
					var Aforval=this.DataPforVal[i]
					for (var c=0; c<this.ForColIx.length; c++) {
						if (Aforval[c] != "*") {
							if (Avalrec[c] != Aforval[c]) {
								ismatch=false
								break
							}
						}
					}
					if (ismatch == true) {
						Rec.ResetCtls()
						wlinha=new Qitempanel(this.DataPanels[i], this.HostPage, this.Hdet, this, this.Tipo4Style + ".DATAPANEL", Rec, n, 0, 0, "30" , "30")
						break
					}
				}
			} else {
				Rec.ResetCtls()
				wlinha=new Qitempanel(this.DataPanels[0], this.HostPage, this.Hdet, this, this.Tipo4Style + ".DATAPANEL", Rec, n, 0, 0, "30" , "30")
			}
			if (wlinha != "") {
				this.Hdet.AddPanel(wlinha)
				var wctl=""
				for (var i=0; i<Rec.Fields.length; i++) {
					var Field=Rec.Fields[i]
					for (var c=0; c<Field.ColCtls.length; c++) {
						wctl=Field.ColCtls[c]
						wctl.SetVal(FormatCol(Field.Coldef, Field.Val, "user"))
						if (wlinha.Tipo.indexOf(".DATAPANEL") > -1 && this.AllowChange == "S") {  //se for DATAPANEL e com AllowCange é preciso proteger os campos se a função é VIS ou ELI
							if (this.DatactlObj.HostFunc == "VIS" || this.DatactlObj.HostFunc == "ELI") wctl.Disable("VIS");
						}
					}
				}
				
				//created by [SF] at [2017.02.14]
				//Pintar linhas
				var valuesPinta = new Array()

				for (var i = 0; i < Cols.length; i++) {
				    var wcol = Cols[i]
				    if (wcol.Vis == "S" && wcol.Send != "N") {
				        var value = Rec.Fields[i].Val;
				        //se tem função para pintar linha
				        if (this.Functioncolor != "") {
				            //converte para o nativo e guarda numa hashtable
				            valuesPinta[wcol.Id] = ConvertToNative(value, wcol.Type)
				            valuesPinta.length++;
				        }
				        
				    }
				}
			    //se tem função para pintar linha
				if (this.Functioncolor != "") {
				    try {
				        //chama a função gerada pelo génio no ficheiro funcoesmanuais.js
				        var testes = window[this.Functioncolor](valuesPinta);
				        wlinha.Hobj.style.backgroundColor = window[this.Functioncolor](valuesPinta);
				    } catch (exp) { }
				}

				if (Rec.Func != "") wlinha.Mark(Rec.Func)
				for (var j=0; j<this.DatactlObj.SelectedKeys.length; j++) {
					if (key == this.DatactlObj.SelectedKeys[j]) {
						wlinha.Mark("SEL")
						if (this.Allowmulti == "N") {
							wselrow=wlinha
							if (wseloffset == -1) wseloffset=wlinha.Locsize.ObjT
						}
					}
				}
				this.Keys.push(key)
				n++
			}
		}
	}
	this.Hdet.Hobj.scrollTop=0
	this.Hdet.ActivatePanels()
	this.RecalcGcols()
	if (wseloffset > 0) this.Hdet.Hobj.scrollTop=wseloffset
	if (this.AutoHeightResize == "S") this.ResizeHeight()
	App.UnBlockAllInput("MULTIGRID")
}


Qmultigrid.prototype.HeaderClick=function(wheader) {
	if (this.Alloworder == "N") return
	if (wheader.Col.Ord == "" || wheader.Col.Ord == "D") {
		wheader.Col.Ord = "A"
		wheader.SetOrder()
		this.DatactlObj.SortCol=wheader.Col.Id
		this.DatactlObj.SortOrder="ASC"
	} else {
		wheader.Col.Ord = "D"
		wheader.SetOrder()
		this.DatactlObj.SortCol=wheader.Col.Id
		this.DatactlObj.SortOrder="DESC"
	}
	for (var i=0; i<this.AutoHeaderPanel.Actls.length; i++) {
		var wh=this.AutoHeaderPanel.Actls[i]
		if (wh != wheader) {
			wh.Col.Ord=""
			wh.SetOrder()
		}
	}
	this.DatactlObj.Activate()
}

Qmultigrid.prototype.GetPanel=function(rec) {
	var pag=-1
	for (var p=this.DatactlObj.Paginas.length -1; p >=0; p--) {
		if (rec >= this.DatactlObj.Paginas[p]) {
			pag=p
			break
		}
	}
	if (pag == -1) return this.Hdet.Actls[rec]
	if (pag < this.DatactlObj.PagIndex-1) return null
	var panl = rec - this.DatactlObj.Paginas[pag] - 1
	return this.Hdet.Actls[panl]
}

Qmultigrid.prototype.Execute=function(act, parm) {
	if (act == "CloseContext") {
		if (this.ContextPanel != null) this.ContextPanel.Destroy()
		return
	}
	if (act == "AutoScroll") {
		this.Hdet.AutoScroll()
	}
	if (act == "ScrollInercia") {
		this.Hdet.ScrollInercia()
	}
}

Qmultigrid.prototype.DisableSelect=function() {
	this.SelectDisabled=true
}

Qmultigrid.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	for (var i=0; i<this.HeaderPanels.length; i++) {
		this.HeaderPanels[i].Disable(tipo)
	}
	for (var i=0; i<this.FooterPanels.length; i++) {
		this.FooterPanels[i].Disable(tipo)
	}
	if (this.AutoHeaderPanel != null) this.AutoHeaderPanel.Disable(tipo)
	if (this.AutoQueryPanel != null) this.AutoQueryPanel.Disable(tipo)
	this.Hdet.Disable(tipo)
}

Qmultigrid.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		for (var i=0; i<this.HeaderPanels.length; i++) {
			this.HeaderPanels[i].Enable(tipo)
		}
		for (var i=0; i<this.FooterPanels.length; i++) {
			this.FooterPanels[i].Enable(tipo)
		}
		if (this.AutoHeaderPanel != null) this.AutoHeaderPanel.Enable(tipo)
		if (this.AutoQueryPanel != null) this.AutoQueryPanel.Enable(tipo)
		this.Hdet.Enable(tipo)
	}
}

Qmultigrid.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qmultigrid.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qmultigrid.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qmultigrid.prototype.Destroy2=function() {
	for (var i=0; i<this.DatactlObj.Grpctls.length; i++) {
		if (this.DatactlObj.Grpctls[i] == this) {
			this.DatactlObj.Grpctls.splice(i,1);
			break;
		}
	}
	this.Hdet=null
	this.HeaderPanels=null
	this.DataPanels=null
	this.FooterPanels=null
	GenericDisplayCtl_Destroy2.call(this)
}

Qmultigrid.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qmultigrid.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qmultigrid.prototype.OnScroll=function() {
	var scro=this.Hdet.Hobj.scrollLeft
	for (var p=0; p<this.HeaderPanels.length; p++) {
		if (this.HeaderPanels[p].Autoscroll == "S") this.HeaderPanels[p].Hobj.scrollLeft=scro
	}
	for (var p=0; p<this.FooterPanels.length; p++) {
		if (this.FooterPanels[p].Autoscroll == "S") this.FooterPanels[p].Hobj.scrollLeft=scro
	}
	if (InternalScrollBars == true || this.PointerScroll != "N") this.Hdet.InnerScroll.Refresh()
}

Qmultigrid.prototype.OnPanelScroll=function(scrval) {
	this.Hdet.Hobj.scrollLeft=scrval
	for (var p=0; p<this.HeaderPanels.length; p++) {
		if (this.HeaderPanels[p].Autoscroll == "S") this.HeaderPanels[p].Hobj.scrollLeft=scrval
	}
	for (var p=0; p<this.FooterPanels.length; p++) {
		if (this.FooterPanels[p].Autoscroll == "S") this.FooterPanels[p].Hobj.scrollLeft=scrval
	}
}

Qmultigrid.prototype.OnClick=function(id) {
	if (AllInputBlocked == true) return
	if (this.SelectDisabled == true) return
	var Aw=id.split(".")
	var ctl=null
	if (Aw[3] == "DATAPANEL") var ctl = this.Hdet.Actls[Number(Aw[4])]
	if (ctl != null) ctl.OnClick()
	var Aw=id.split(".")
	if (Aw[3] == "DATAPANEL") this.DetClick(Number(Aw[4]))
}

Qmultigrid.prototype.OnDblClick=function(id) {
	if (AllInputBlocked == true) return
	if (this.SelectDisabled == true) return
	var Aw=id.split(".")
	if (Aw[3] == "DATAPANEL") this.DetDblClick(Number(Aw[4]))
}

Qmultigrid.prototype.DetClick = function(panel, opt, kbkeys) {
	if (this.SelectDisabled == true) return
	if (kbkeys == undefined) kbkeys=""
    var key = panel.Record.Key
    if (opt == "NOSEL") {
        this.DatactlObj.SetPointer(key)
        return
    }
    var selectedkeys = this.DatactlObj.SelectedKeys
    if (this.Allowmulti == "N" || (this.Allowmulti == "W" && kbkeys == "")) {
        selectedkeys = new Array()
        selectedkeys[0] = key
        this.DatactlObj.PointerKey = key
    }
    if (this.Allowmulti == "S" || (this.Allowmulti == "W" && kbkeys == "CTRL")) {
        var found = false
        for (var k = 0; k < selectedkeys.length; k++) {
            if (selectedkeys[k] == key) {
                selectedkeys.splice(k, 1)
                found = true
                break
            }
        }
        if (found == false) {
            var warray = new Array()
            warray.push(key)
            selectedkeys = warray.concat(selectedkeys)
        }
        this.DatactlObj.PointerKey = key
    }
    if (this.Allowmulti == "W" && kbkeys == "SHIFT") {
        var wk = selectedkeys[0]
        selectedkeys = new Array()
        selectedkeys[0] = wk
        var addkeys = false
        for (var i = 0; i < this.Hdet.Actls.length; i++) {
            var witem = this.Hdet.Actls[i]
            if (witem.Record.Key == key || witem.Record.Key == wk) {
                if (addkeys == false) {
                    addkeys = true
                } else {
                    if (witem.Record.Key != wk) selectedkeys.push(witem.Record.Key)
                    addkeys = false
                }
            }
            if (addkeys == true && witem.Record.Key != wk) selectedkeys.push(witem.Record.Key)
        }
    }
    // marcar os registos que constam no selectedkeys e desmarcar os outros
    this.RefreshSelected(selectedkeys)
    this.DatactlObj.SelectedKeys=selectedkeys
    if (opt == "NOCLICK") return
    this.DatactlObj.Execute("CLK")
}

Qmultigrid.prototype.RefreshSelected=function(selectedkeys) {
	if (selectedkeys == undefined || selectedkeys == "") selectedkeys=this.DatactlObj.SelectedKeys
	for (var i = 0; i < this.Hdet.Actls.length; i++) {
        var witem = this.Hdet.Actls[i]
        var found = false
        for (var k = 0; k < selectedkeys.length; k++) {
            if (selectedkeys[k] == witem.Record.Key) {
                found = true
                break
            }
        }
        if (found == true) {
            if (witem.Selected == false) witem.Mark("SEL")
        } else {
            if (witem.Selected == true) witem.Mark("UNSEL")
        }
    }
}

Qmultigrid.prototype.DetDblClick=function(panel, opt) {
	this.DatactlObj.Execute("DBL")
}

Qmultigrid.prototype.OnQryChange=function() {
	this.CriaCond()
}

Qmultigrid.prototype.OnContext=function(tipo, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Allowcontext == "N") return
	var offset=GetOffsetFor("WINDOW", this.HostPage)
	wx=wx - offset.Left
	wy=wy - offset.Top
	if (tipo == "DET") {
		var wdbe=this.DatactlObj
		var Atext=new Array()
		var Aact=new Array()
		for (var i=0; i<wdbe.Events.length; i++) {
			var wevent=wdbe.Events[i]
			if (wevent.Disabled == false) {
				if (wevent.ContextId != "") {
					Atext.push(wevent.ContextId)
					Aact.push(wevent.Id)
				}
			}
		}
		if (Atext.length == 0) return
		if (this.ContextPanel != null) this.ContextPanel.Destroy()
		var wh=Atext.length * 20 + 20
		wx=wx-40
		wy=wy-(wh / 2)
		if (wx<0) wx=0
		if (wy<0) wy=0
		var wdifx=offset.MaxWidth - 150
		if (wdifx < wx && wdifx > 0) wx=wdifx
		var wdify=offset.MaxHeight - wh
		if (wdify < wy && wdify > 0) wy=wdify
		var xstr="<PANEL LOCATION=\"" + wx + "," + wy + "\" SIZE=\"150," + wh + "\">"
		var offsetv=0
		for (var i=0; i<Atext.length; i++) {
			xstr +=  "  <BOTAO LOCATION=\"0," + offsetv + "\" SIZE=\"*,20\" TXT=\"" + Atext[i] + "\" ACT=\"Execute(" + wdbe.Id + "," + Aact[i] + "{Execute(" + this.Id + ",CloseContext\" STYLE=\"BOTAOCONTEXT\"/>"
			offsetv=offsetv + 20
		}
		xstr +=  "</PANEL>"
		var xnod=CreateXnode(xstr)
		this.ContextPanel = new Qitempanel(xnod, this.HostPage, this.HostPage, this, "MULTIGRID.CONTEXTPANEL", null, null, 0, 0, 300, 400)
		this.Actls.push(this.ContextPanel)
		this.ContextPanel.Activate()
		return
	}
	//tipo=  HDR || DET || QRY
	if (this.ContextPanel != null) {
		for (var i=0; i< this.Actls.length; i++) {
			if (this.Actls[i] == this.ContextPanel) {
				this.Actls.splice(i,1)
				break
			}
		}
		this.ContextPanel=null
	}
	/*
	if (this.ContextPanel == null) {
		var xstr="<PANEL LOCATION=\"50,50\" SIZE=\"300,400\">"
		xstr +=  "  <LABEL LOCATION=\"10,10\" SIZE=\"200,17\" TXT=\"Floating Panel\"/>"
		xstr +=  "  <LABEL LOCATION=\"10,40\" SIZE=\"200,17\" TXT=\"Floating Panel2\"/>"
		xstr +=  "  <LABEL LOCATION=\"10,80\" SIZE=\"200,17\" TXT=\"Floating Panel3\"/>"
		xstr +=  "</PANEL>"
		var xnod=CreateXnode(xstr)
		this.ContextPanel = new Qitempanel(xnod, this.HostPage, this.HostPage, this, "CONTEXTPANEL", null, null, 50, 50, 300, 400)
		this.Actls.push(this.ContextPanel)
		this.ContextPanel.Activate()
	} else {

	}
	*/
}

Qmultigrid.prototype.CriaCond=function() {
	var Rec=this.AutoQueryPanel.Record
	var wcond=""
	var wval=""
	for (var q=0; q<Rec.Fields.length; q++) {
		wval=Rec.Fields[q].Val
		if (wval != "" && wval != "*") {
			wcond=AppendCond(wcond, Rec.Fields[q].Coldef.Id, Rec.Fields[q].Coldef.Type, wval, "MULTIGRID")
		}
	}
	this.DatactlObj.Cond=wcond
	this.DatactlObj.Execute("GET")
}

Qmultigrid.prototype.SetCurrentRow=function(nrow) {
	this.CurrentRow=nrow
}

Qmultigrid.prototype.GetCurrentRowSufix=function() {
	return "_R" + this.CurrentRow
}


//funções como controlo de dados
Qmultigrid.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	var Rec = ctl.HostDataPanel.Record
	var Field = Rec.Fields[ix]
	Field.ColCtls.push(ctl)
}

Qmultigrid.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

//------------------------------

function QmultigridDetSelstart(evt) {
	if (BrowserIE || BrowserOP) {
		window.event.returnValue=false
	} else {
		//não existe
	}
}

//***************************************************************** QSTACKPANEL - define StackPanel
function Qstackpanel(hostpage, hostpanel, parentobj, wlocation, wsize, vpad, hpad, vrepeat, hrepeat) {
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.ParentObj=parentobj
	this.Tipo=parentobj.Tipo4Style + ".STACKPANEL"
	this.Class="PANEL"
	this.Selected=false
	this.Actls=new Array()
	this.Id="Stack" + this.HostPage.CtlCount
	this.HostPage.CtlCount ++
	//this.Hid=parentobj.Hid + "." + this.Id
	if (this.HostPanel == App) {
		if (this.ParentObj != undefined && this.HostPanel != this.ParentObj) {
			this.Hid=this.ParentObj.Hid + "." + this.Id
			alert("APP stack by parentobj " + this.Id)
		} else {
			this.Hid=this.HostPage.Hid + "." + this.Id
			alert("APP stack by hostpage " + this.Id)
		}
	} else {
		this.Hid=this.HostPanel.Hid + "." + this.Id
	}
	this.Location=wlocation
	this.Size=wsize
	this.Locsize=new QlocSize(wlocation, wsize, hostpanel)
	this.Vpad=vpad
	this.Hpad=hpad
	this.Vrepeat=vrepeat
	this.Hrepeat=hrepeat
	//this.OffsetH=0
	//this.OffsetV=0
	this.MouseOverxi=0
	this.MouseOveryi=0
	this.MouseOverxf=0
	this.MouseOveryf=0
	this.CountH=0
	this.CountV=0
	this.MaxWidth=0
	this.MaxHeight=0
	this.Style=parentobj.Style
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.ScrollH=false
	this.ScrollV=false
	this.lastdeltay=0
	this.lastdeltax=0
	this.Frame=new Qframe(this)
	if (this.HostPanel.PointerScroll == "N") {
		wdiv.style.overflow="auto"
	} else {
		wdiv.style.overflow="hidden"
		wdiv.onmousewheel=EvtMouseWheel
		if (BrowserMOZ) wdiv.addEventListener("DOMMouseScroll", EvtMouseWheel, false)   //wdiv.onDOMMouseScroll=EvtMouseWheel
	}
	wdiv.onscroll = EvtScroll
	//if (this.HandCursor == "S") wdiv.style.cursor="pointer"
	wdiv.style.zIndex=0
	this.Visible=true
	this.Visivel="S"
	var wfil=CreateDiv(wdiv, this.Hid + "._.FILLER", 0, 0, 10, 1)
	wfil.style.borderWidth="0px"
	wfil.style.backgroundColor="transparent"
	wfil.style.display="block"
	this.Hfil=wfil
	if (InternalScrollBars == true || this.HostPanel.PointerScroll != "N") this.InnerScroll=new Qscroll(this.HostPage, this)
}

Qstackpanel.prototype.SetLocation=function(wloc) {
	this.Location=wloc
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
	if (this.HostPanel.PointerScroll != "N") this.SetCoords()
}

Qstackpanel.prototype.SetSize=function(wsize) {
	this.Size=wsize
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
	if (this.HostPanel.PointerScroll != "N") this.SetCoords()
}

Qstackpanel.prototype.SetWidth=function(wwidth) {
	var Aw=this.Size.split(",")
	this.Size=wwidth + "," + Aw[1]
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
	if (this.HostPanel.PointerScroll != "N") this.SetCoords()
}

Qstackpanel.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
	this.Frame.Resize()
	this.Rearange()
	if (InternalScrollBars == true || this.HostPanel.PointerScroll == "S") this.InnerScroll.Refresh()
	if (this.HostPanel.PointerScroll != "N") this.SetCoords()
}

Qstackpanel.prototype.SetScroll=function(wscrl) {
	this.Scroll=wscrl
	if (this.Scroll == "S" || this.Scroll == "E") {
		this.Hobj.style.overflow="auto"
		this.Hobj.onscroll=EvtScroll
	} else {
		this.Hobj.style.overflow="hidden"
	}
}

Qstackpanel.prototype.SetCoords=function() {
	if (this.Hobj.style.display == "none") return
	var offset=GetOffsetFor("WINDOW", this);
	this.MouseOverxi=offset.Left //+ this.Locsize.ObjL;
	this.MouseOveryi=offset.Top //+ this.Locsize.ObjT;
	this.MouseOverxf=this.MouseOverxi + this.Locsize.ObjW
	this.MouseOveryf=this.MouseOveryi + this.Locsize.ObjH
}

Qstackpanel.prototype.SetMouseOver=function(stat) {
	if (stat == true) {  //acrescentar este controlo à lista de controlos para os quais se quer detectar MouseOver
		var found=false
		for (var i=0; i<CtlMouseOver.length; i++) {
			if (CtlMouseOver[i] == this) {
				found=true
				break
			}
		}
		if (found == false) CtlMouseOver.push(this)
	} else {   //retirrar este controlo da lista de controlos para os quais se quer detectar MouseOver
		for (var i=0; i<CtlMouseOver.length; i++) {
			if (CtlMouseOver[i] == this) {
				CtlMouseOver.splice(i,1)
				break
			}
		}
	}
}

Qstackpanel.prototype.AddPanel=function(wpanel) {
	this.Actls.push(wpanel)
}

Qstackpanel.prototype.SetDataWidth=function(w) {
	this.Hfil.style.width=w + "px"
}

Qstackpanel.prototype.Rearange=function() {
	var offsetV=0
	var offsetH=0
	var countH=0
	var countV=0
	var posv=0
	var posh=0
	var wid=0
	var hei=0
	var wctl
	this.MaxWidth=0
	this.MaxHeight=0
	this.ScrollH=false
	this.ScrollV=false
	var largura = this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
	var altura=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
	for (var i=0; i<this.Actls.length; i++) {
		wctl=this.Actls[i]
		wid=wctl.Locsize.ObjW
		hei=wctl.Locsize.ObjH
		posh=offsetH
		posv=offsetV
		countH++
		if (countH >= this.Hrepeat) {
			offsetH=0
			countH=0
			countV++
			if (countV >= this.Vrepeat) {
				offsetV=0
				countV=0
			} else {
				offsetV = offsetV + hei + this.Vpad
			}
		} else {
			offsetH = offsetH + wid + this.Hpad
		}

		if (wctl.Locsize.ObjL != posh || wctl.Locsize.ObjT != posv) {
			wctl.SetLocation(posh + "," + posv)
			wctl.Relocate()
		}
		if (offsetH > this.MaxWidth) this.MaxWidth = offsetH
		if (offsetV > this.MaxHeight) this.MaxHeight = offsetV
		if (this.MaxWidth == 0) this.MaxWidth = wid
		if (this.MaxHeight == 0) this.MaxHeight = hei
		if (this.MaxHeight > altura) this.ScrollV=true
		if (this.MaxWidth > largura-16) this.ScrollH=true
	}
	if (BrowserIE == true) {  //bug do IE9 com o scrolling
		/*
		if (navigator.appVersion.indexOf("MSIE 9.0") > -1) {
			if (this.ScrollH == true) this.Hobj.style.height=(this.Locsize.ObjH + 17) + "px"
			if (this.ScrollV == true) this.Hobj.style.width=(this.Locsize.ObjW + 17) + "px"
		}
		*/
	}
	//var wanim=new Qanimator(this, "WAIT", "NONE,2,0,S")   #######
	//var wanim=new Qanimator(this, "WAIT", "NONE,1,0,S")
	//wanim.Activate(this.Rearange2);
	this.Rearange2()
}

Qstackpanel.prototype.Rearange2=function() {
	if (InternalScrollBars == true || this.HostPanel.PointerScroll != "N") this.InnerScroll.Refresh()
}

Qstackpanel.prototype.SetState=function(st) {
	this.Frame.SetState(st)
}

Qstackpanel.prototype.Activate=function(opt) {
	this.Show("INIT")
}

Qstackpanel.prototype.ActivatePanels=function() {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate()
	}
	this.Rearange()
	if (this.HostPanel.Disabled == true) this.Disable() 
}

Qstackpanel.prototype.DestroyPanels=function() {
	for (var i=this.Actls.length-1; i>=0; i--) {
		this.Actls[i].Destroy()
	}
	this.Actls=new Array()
	this.ScrollV=false
}

Qstackpanel.prototype.Show=function(opt) {
	var wanim=new Qanimator(this, "IN", this.StyleObj.AnimIn)
	wanim.Activate()
	if (this.HostPanel.PointerScroll != "N") {
		this.SetCoords()
		this.SetMouseOver(true)
	}
}

Qstackpanel.prototype.Hide=function(opt) {
	if (this.HostPanel.PointerScroll != "N") this.SetMouseOver(false)
	if (opt == "DESTROYNOW") {  //não passa pela animação, destroy em modo sincrono
		this.Hobj.style.display="none";
		this.Destroy2();
		return;
	}
	var wanim=new Qanimator(this, "OUT", this.StyleObj.AnimOut)
	if (opt == "DESTROY") {
		wanim.Activate(this.Destroy2)
		return
	} else {
		wanim.Activate()
	}
}


Qstackpanel.prototype.Disable=function(tipo) {
	if (this.HostPanel.PointerScroll != "N") this.SetMouseOver(false)
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Disable()
	}
}

Qstackpanel.prototype.Enable=function(tipo) {
	if (this.HostPanel.PointerScroll != "N") this.SetMouseOver(true)
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Enable()
	}
}

Qstackpanel.prototype.AutoScroll=function() {  //é o Multigrid que invoca esta função
	if (this.AutoScrollDir == "" || this.AutoScrollDir == undefined) return
	if (this.AutoScrollDir.indexOf("L") > -1) this.Hobj.scrollLeft = this.Hobj.scrollLeft - 7
	if (this.AutoScrollDir.indexOf("R") > -1) this.Hobj.scrollLeft = this.Hobj.scrollLeft + 7
	if (this.AutoScrollDir.indexOf("T") > -1) this.Hobj.scrollTop = this.Hobj.scrollTop - 7
	if (this.AutoScrollDir.indexOf("B") > -1) this.Hobj.scrollTop = this.Hobj.scrollTop + 7
	ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.HostPanel.Id + ",AutoScroll")
}

Qstackpanel.prototype.MouseOver=function(wx, wy) {  //MouseOver para PointerScroll
	if (this.HostPanel.PointerScroll != "S") return
	wx=wx-this.MouseOverxi
	wy=wy-this.MouseOveryi
	var needstart=false
	if (this.AutoScrollDir == "" || this.AutoScrollDir == undefined) needstart=true
	this.AutoScrollDir=""
	if (wx < 30) {
		if (this.Hobj.scrollLeft > 0) this.AutoScrollDir="L"
	} else {
		if (wx > this.Locsize.ObjW - 30) this.AutoScrollDir="R"
	}
	if (wy < 30) {
		if (this.Hobj.scrollTop > 0) this.AutoScrollDir += "T"
	} else {
		if (wy > this.Locsize.ObjH - 30) this.AutoScrollDir += "B"
	}
	if (this.AutoScrollDir != "") {
		if (needstart == true) ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.HostPanel.Id + ",AutoScroll")
	} else {
		this.MouseOut()
	}
}

Qstackpanel.prototype.MouseOut=function(id, hnod) {  //MouseOut para PointerScroll
	this.AutoScrollDir=""
}

Qstackpanel.prototype.OnMouseOver=function(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	this.HostPanel.OnMouseOver(id, hnod)
}

Qstackpanel.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.HostPanel.OnMouseOut(id, hnod)
}

Qstackpanel.prototype.OnMouseDown=function(id, hnod, wx, wy, cx, cy, itempanel) {
	if (AllInputBlocked == true) return
	if (this.HostPanel.DatactlObj != null) {
		if (this.HostPanel.DatactlObj.Tipo.indexOf("COMBO") > -1) this.HostPanel.DatactlObj.IsScrolling=true
	}
	if (this.HostPanel.PointerScroll != "D") return
	CtlMouse=this
	this.scrolly=null
	this.scrollx=null
	this.mouseitempanel=itempanel
}

Qstackpanel.prototype.OnMouseUp=function(id) {
	if (AllInputBlocked == true) return
	if (this.HostPanel.PointerScroll != "D") return
	CtlMouse=null
	if (this.lastdeltay == 0 && this.lastdeltax == 0) {  //se não houve deslocamento interpreta como clique
		this.mouseitempanel.Select("CLK", "", 0, 0)
		return
	}
	ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.HostPanel.Id + ",ScrollInercia")
}

Qstackpanel.prototype.MouseUp=function() {
	CtlMouse=null
	ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.HostPanel.Id + ",ScrollInercia")
}

Qstackpanel.prototype.MouseMove=function(wx, wy) {
	if (this.scrolly == null) {
		this.scrolly=wy
		this.scrollx=wx
		return
	}
	var deltay=this.scrolly - wy
	this.scrolly=wy
	var deltax=this.scrollx - wx
	this.scrollx=wx
	this.lastdeltay=deltay
	this.lastdeltax=deltax
	if (deltay != 0) this.Hobj.scrollTop = this.Hobj.scrollTop + deltay
	if (deltax != 0) this.Hobj.scrollLeft = this.Hobj.scrollLeft + deltax
}

Qstackpanel.prototype.ScrollInercia=function() {  // fazer scroll por inercia quando se larga o botão do rato
	if (this.lastdeltay != 0) {
		if (this.lastdeltay > 0) {
			this.lastdeltay=this.lastdeltay - 0.5
		} else {
			this.lastdeltay=this.lastdeltay + 0.5
		}
	}
	if (this.lastdeltax != 0) {
		if (this.lastdeltax > 0) {
			this.lastdeltax=this.lastdeltax - 0.5
		} else {
			this.lastdeltax=this.lastdeltax + 0.5
		}
	}
	if (this.lastdeltay != 0) this.Hobj.scrollTop = this.Hobj.scrollTop + this.lastdeltay
	if (this.lastdeltax != 0) this.Hobj.scrollLeft = this.Hobj.scrollLeft + this.lastdeltax
	if (this.lastdeltay != 0 || this.lastdeltax != 0) ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.HostPanel.Id + ",ScrollInercia")
}

Qstackpanel.prototype.OnScroll=function() {
	if (this.HostPanel.DatactlObj != null) {
		if (this.HostPanel.DatactlObj.Tipo.indexOf("COMBO") > -1) this.HostPanel.DatactlObj.IsScrolling=true
	}
	this.ParentObj.OnScroll()
}

Qstackpanel.prototype.OnMouseWheel=function(id, hnode, delta) {
	if (delta < 1) {
		//this.AutoScrollDir += "B"
		this.Hobj.scrollTop = this.Hobj.scrollTop + 40
	} else {
		//this.AutoScrollDir += "T"
		this.Hobj.scrollTop = this.Hobj.scrollTop - 40
	}
}

Qstackpanel.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	this.DestroyPanels()
	this.Hide(opt)
}

Qstackpanel.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}



//***************************************************************** Qdatapanel - define StackPanel
function Qitempanel(xnod, hostpage, hostpanel, parentobj, tipo, record, linenumber, wleft, wtop, wwid, whei, limits) {
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.ParentObj=parentobj
	this.Tipo=tipo
	this.Class="PANEL"
	this.Record=record
	this.LineNumber=linenumber
	this.Limits=limits
	this.Selected=false
	this.OverResize=-1
	this.IsDragging=false
	this.MouseIsOver=false
	this.Actls=new Array()
	this.Disabled=false
	var wtipo1=this.Tipo
	var wtipo2=this.Tipo
	var ix=this.Tipo.lastIndexOf(".")
	if (ix > -1) {
		wtipo1=this.Tipo.substr(0,ix)
		wtipo2=this.Tipo.substr(ix+1)
	}
	if (xnod != null) {
		var Autolayout=GetAtt(xnod, "AUTOLAYOUT", "")
		if (Autolayout == "DET") {
			wtipo2="AUTODATAPANEL"
			this.Tipo=wtipo1 + "." + wtipo2
			var usecombo=GetAtt(xnod, "USECOMBO", "S")
			if (usecombo == "N") {
				this.AutoDataUseCombo=false
			} else {
				this.AutoDataUseCombo=true
			}
		}
		this.Id=GetAtt(xnod, "ID", "")
		if (this.Id == "") {
			if (linenumber != null) {
				this.Id = wtipo2 + "_R" + linenumber
			} else {
				this.Id=wtipo2 + this.HostPage.CtlCount
				this.HostPage.CtlCount ++
			}
		} else {
			if (linenumber != null) this.Id += "_R" + linenumber
		}
		this.Location=GetAtt(xnod, "LOCATION", "0,0")
		this.Size=GetAtt(xnod, "SIZE", "0,21")
		this.Locsize=new QlocSize(this.Location, this.Size, hostpanel)
		this.HandCursor=GetAtt(xnod, "HANDCURSOR", "N")
		this.Style=GetAtt(xnod, "STYLE", parentobj.Style)
		this.Scroll=GetAtt(xnod, "SCROLL", "N")
		this.Nivseg=GetAtt(xnod, "NIVSEG", "")
		this.Prot=GetAtt(xnod, "PROT", "N")
		this.Autoscroll=GetAtt(xnod, "AUTOSCROLL", "N")
	} else {
		this.Id=wtipo2
		if (linenumber != null) {
			this.Id += "_R" + linenumber
		} else {
			this.Id += this.HostPage.CtlCount
				this.HostPage.CtlCount ++
			this.Id += parentobj.Actls.length
		}
		this.Location=wleft + "," + wtop
		this.Size=wwid + "," + whei
		this.Locsize=new QlocSize(this.Location, this.Size, hostpanel)
		this.HandCursor="N"
		this.Style=parentobj.Style
		this.Scroll="N"
		this.Nivseg=""
		this.Prot="N"
		this.Autoscroll="N"
	}
	//this.Hid=parentobj.Hid + "." + this.Id

	if (this.HostPanel == App) {
		if (this.ParentObj != undefined && this.HostPanel != this.ParentObj) {
			this.Hid=this.ParentObj.Hid + "." + this.Id
		} else {
			this.Hid=this.HostPage.Hid + "." + this.Id
		}
	} else {
		this.Hid=this.HostPanel.Hid + "." + this.Id
	}

	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Hobj=wdiv
	this.PanelObj=wdiv
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Frame=new Qframe(this)
	if (this.Scroll == "S") {
		wdiv.style.overflow="auto"
	} else {
		wdiv.style.overflow="hidden"
	}
	this.Locsize.Resize(wdiv)
	if (this.HandCursor == "S") wdiv.style.cursor="pointer"
	if (this.Tipo.indexOf("DATAPANEL") > -1) {
		wdiv.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
		wdiv.onclick=EvtClick
		wdiv.ondblclick=EvtDblClick
		wdiv.oncontextmenu=EvtContext

		//para scrolling
		wdiv.onmousedown=EvtMouseDown
		wdiv.onmouseup=EvtMouseUp
		//--------------

		wdiv.onmouseover=EvtMouseOver
		wdiv.onmouseout=EvtMouseOut
		wdiv.onfocus=EvtFocus
		wdiv.onblur=EvtBlur
		wdiv.onkeypress=EvtKeyPress
		if (this.ParentObj.PointerScroll != "N") {
			wdiv.onmousewheel=EvtMouseWheel
			if (BrowserMOZ) wdiv.addEventListener("DOMMouseScroll", EvtMouseWheel, false)   //wdiv.onDOMMouseScroll=EvtMouseWheel
		}
	}
	if (this.Tipo.indexOf("DROPPANEL") > -1 || this.Tipo.indexOf("CONTEXTPANEL") > -1) {
		wdiv.onmouseover=EvtMouseOver
		wdiv.onmouseout=EvtMouseOut
	}
	if (this.Tipo.indexOf("AUTOHEADERPANEL") > -1 || this.Tipo.indexOf("AUTOQUERYPANEL") > -1 || this.Tipo.indexOf("AUTODATAPANEL") > -1) {
		this.Gcols=parentobj.Gcols
		this.RefreshCols()
		this.Autoscroll="S"
		if (this.Tipo.indexOf("AUTOHEADERPANEL") > -1) {
			wdiv.onmousedown=EvtMouseDown
			wdiv.onmouseup=EvtMouseUp
		}
		if (this.Tipo.indexOf("AUTOHEADERPANEL") > -1 || this.Tipo.indexOf("AUTOQUERYPANEL") > -1) {
			wdiv.onscroll = EvtScroll
		}
	}
	this.Disabled=false
	if (this.Prot == "S") this.Disable("PROT")
	this.Visible=true
	this.Visivel="S"
	wdiv.style.zIndex=1
	this.SetState("NORM")
	if (xnod != null) CreateDisplayCtls(xnod, this)
	this.Activated=false
}

Qitempanel.prototype.SetLocation=function(wloc) {
	this.Location=wloc
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
}

Qitempanel.prototype.SetSize=function(wsize) {
	this.Size=wsize
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
}

Qitempanel.prototype.SetWidth=function(wwidth) {
	var Aw=this.Size.split(",")
	this.Size=wwidth + "," + Aw[1]
	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	this.Locsize.SetMargins(this.StyleObj.PadL, this.StyleObj.PadR, this.StyleObj.PadT, this.StyleObj.PadB)
}

Qitempanel.prototype.Relocate=function() {
	this.Locsize.Resize(this.Hobj)
}

Qitempanel.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
	this.Frame.Resize()
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Locsize.Resizable == true) this.Actls[i].Resize()
	}
}

Qitempanel.prototype.SetScroll=function(wscrl) {
	this.Scroll=wscrl
	if (this.Scroll == "S" || this.Scroll == "E") {
		this.Hobj.style.overflow="auto"
		this.Hobj.onscroll=EvtScroll
	} else {
		this.Hobj.style.overflow="hidden"
	}
}

Qitempanel.prototype.AddCtl=function(wctl) {
	this.Actls.push(wctl)
	wctl.HostPanel=this
}

Qitempanel.prototype.SetState=function(st) {
	if (this.Tipo.indexOf("AUTODATAPANEL") > -1) {
		if ((this.LineNumber / 2) == Math.floor(this.LineNumber / 2)) {
			if (st == "NORM") st="NOR2"
		}
	}
	this.Frame.SetState(st)
	for (var i=0; i<this.Actls.length; i++) {
		var wctl=this.Actls[i]
		if (wctl.Frame.GetStateId() != "EDIT" && wctl.Disabled == false) wctl.SetState(st)
	}
}

Qitempanel.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qitempanel.prototype.Activate2=function() {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate("INIT")
	}
	if (this.Tipo.indexOf("CONTEXTPANEL") > -1) {
		ExecCmdDelayed(2200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",MouseOut")
	}
	if (this.ParentObj.SelectDisabled == true) this.Disable()
}

Qitempanel.prototype.RefreshCols=function() {
	if (this.Tipo.indexOf("AUTOQUERYPANEL") == -1 && this.Tipo.indexOf("AUTOHEADERPANEL") == -1 && this.Tipo.indexOf("AUTODATAPANEL") == -1) return
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Inuse=false
	}
	var ultcol=this.Gcols[this.Gcols.length-2]
	var maxwidth=ultcol.Left + ultcol.Larg
	if (this.Tipo.indexOf("AUTODATAPANEL") > -1) {
		this.SetWidth(maxwidth)
		this.Resize()
	}
	for (var c=0; c<this.Gcols.length; c++) {
		var col = this.Gcols[c]
		var encontrou=false
		for (var i=0; i<this.Actls.length; i++) {
			if (this.Actls[i].Col == col) {
				//redimensionar o controlo se necessario
				var wctl=this.Actls[i]
				wctl.Locsize.OffW = col.Larg
				wctl.Locsize.OffL = col.Left
				/*
				if (wctl.Locsize.ObjW != col.Larg || wctl.Locsize.ObjL != col.Left) {
					wctl.Resize()
				}
				*/
				if (wctl.Locsize.ObjW != col.Larg || wctl.Locsize.ObjL != col.Left) {
					var wanim=new Qanimator(wctl, "MOVE", "LINEAR,2,0,N", col.Left, wctl.Locsize.ObjT, col.Larg, wctl.Locsize.ObjH)
					wanim.Activate()
				}
				if (this.Tipo.indexOf("AUTOHEADERPANEL") > -1) {
					if (col.Ord == "") wctl.Hord.src=GetImageAddress("idbenord.gif")
					if (col.Ord == "A") wctl.Hord.src=GetImageAddress("idbeasc.gif")
					if (col.Ord == "D") wctl.Hord.src=GetImageAddress("idbedesc.gif")
				}
				this.Actls[i].Inuse=true
				encontrou=true
				break
			}
		}
		if (encontrou == false) {
			var wctl=null
			if (this.Tipo.indexOf("AUTOHEADERPANEL") > -1) {
				wctl = new Qheader(this.HostPage, this, this.ParentObj, col)
			}
			if (this.Tipo.indexOf("AUTODATAPANEL") > -1) {
				if (col.Id != "filler" && col.Id != "$selected") {
					var wreadonly="S"
					if (this.ParentObj.AllowChange == "S") wreadonly="N"
					if (this.ParentObj.HostFunc == "VIS" || this.ParentObj.HostFunc == "ELI") wreadonly="S";
					if (col.Col.Val != "" && this.AutoDataUseCombo == true) {
						var wx="<COMBO LOCATION=\"0,0\" SIZE=\"" + col.Col.Larg + ",*\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Col.Id + "\" VAL=\"" + Xencode(col.Col.Val) + "\" STYLE=\"" + this.Style + "\" READONLY=\"" + wreadonly + "\"/>"
						wctl = new Qcombo(CreateXnode(wx), this.HostPage, this);
					} else {
						var walign="LEFT"
						if (col.Col.Type == "D" || col.Col.Type == "H") walign="CENTER"
						if (col.Col.Type == "N" || col.Col.Type == "$") walign="RIGHT"
						var wx="<TEXT LOCATION=\"0,0\" SIZE=\"" + col.Col.Larg + ",*\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Col.Id + "\" ALIGN=\"" + walign + "\" STYLE=\"" + this.Style + "\" READONLY=\"" + wreadonly + "\"/>"
						wctl = new Qtext(CreateXnode(wx), this.HostPage, this);
					}
				} else {
					if (col.Id == "$selected") {
						var wx="<CHECK ID=\"$selected\" LOCATION=\"0,0\" SIZE=\"\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Col.Id + "\" VAL=\"1{0\" STYLE=\"" + this.Style + "\" READONLY=\"S\"/>"
						wctl = new Qcheck(CreateXnode(wx), this.HostPage, this);
					}
				}
			}
			if (this.Tipo.indexOf("AUTOQUERYPANEL") > -1) {
				if (col.Id != "filler" && col.Id != "$selected") {
					if (col.Col.Val != "") {
						var wx="<COMBO LOCATION=\"0,0\" SIZE=\"" + col.Col.Larg + ",*\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Col.Id + "\" VAL=\"*[*{" + Xencode(col.Col.Val) + "\" STYLE=\"" + this.Style + "\" READONLY=\"N\"/>"
						wctl = new Qcombo(CreateXnode(wx), this.HostPage, this);
					} else {
						var wx="<TEXT LOCATION=\"0,0\" SIZE=\"" + col.Col.Larg + ",*\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Col.Id + "\" ALIGN=\"LEFT\" STYLE=\"" + this.Style + "\" READONLY=\"N\"/>"
						wctl = new Qtext(CreateXnode(wx), this.HostPage, this);
					}
				} else {
					var wx="<TEXT LOCATION=\"0,0\" SIZE=\"" + col.Larg + ",*\" DATACTL=\"" + this.ParentObj.DatactlObj.Id + "\" DATAFLD=\"" + col.Id + "\" ALIGN=\"LEFT\" STYLE=\"" + this.Style + "\" READONLY=\"S\"/>"
					wctl = new Qtext(CreateXnode(wx), this.HostPage, this);				}
			}
			if (wctl != null) {
				this.Actls.push(wctl)
				wctl.Inuse=true
				wctl.Col=col
				wctl.Locsize.OffW = col.Larg
				wctl.Locsize.OffL = col.Left
				wctl.Resize()
			}
		}
	}
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Inuse == false) {
			this.Actls[i].Destroy()
			this.Actls.splice(i,1)
			i--
		}
	}
}

Qitempanel.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
	if (this.Tipo.indexOf("CONTEXTPANEL") > -1) this.MouseIsOver=true
}

Qitempanel.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qitempanel.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qitempanel.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qitempanel.prototype.Select=function(opt, keys, wx, wy) {
	if (this.Disabled == true) return
	if (opt == "DBL") {
		this.ParentObj.DetDblClick(this)
	} else {
		this.ParentObj.DetClick(this, opt, keys)
		if (this.ParentObj.ContextOnClick == "S") {
			if (this.Hid.indexOf("AUTOQUERYPANEL") > -1) {
				this.ParentObj.OnContext("QRY", wx, wy)
			} else {
				this.ParentObj.OnContext("DET", wx, wy)
			}
		}
	}
}

Qitempanel.prototype.Mark=function(opt) {
	if (this.Disabled == true) return
	wselctl=null
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Id.indexOf("$selected") == 0) {
			wselctl=this.Actls[i];
			break;
		}
	}
	if (opt == "SEL") {
		this.SetState("SELE")
		this.Selected=true
		if (wselctl != null) wselctl.SetVal("1")
	}
	if (opt == "UNSEL") {
		this.SetState("NORM")
		this.Selected=false
		if (wselctl != null) wselctl.SetVal("0")
	}
}

Qitempanel.prototype.Execute=function(act) {
	if (act == "MouseOut") {
		if (this.MouseIsOver == false) {
			if (this.Tipo.indexOf("CONTEXTPANEL") > -1) {
				for (var i=0; i< this.ParentObj.Actls.length; i++) {
					if (this.ParentObj.Actls[i] == this) {
						this.ParentObj.Actls.splice(i,1)
						break
					}
				}
				this.ParentObj.ContextPanel=null
				this.Destroy()
				this.ParentObj.Execute("PanelHide")
			}
		}
	}
}

Qitempanel.prototype.SetCurrentRow=function() {
	this.ParentObj.SetCurrentRow(this.LineNumber)
}

Qitempanel.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	if (this.Tipo.indexOf("DATAPANEL") > -1) {
		if (this.Disabled == false) {
			if (this.Selected == false) this.SetState("HIGH")
		}
		if (this.Tipo.indexOf(".MENU.") > -1) this.ParentObj.DetOver(this)
	}
	if (this.Tipo.indexOf("MENU.DROPPANEL") > -1) this.ParentObj.DetOver(this)
	this.MouseIsOver=true
	this.HostPanel.OnMouseOver(id, hnod)
}

Qitempanel.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	this.MouseIsOver=false
	if (this.Tipo.indexOf("DATAPANEL") > -1) {
		if (this.Disabled == false) {
			if (this.Selected == false) {
				this.SetState("NORM")
			} else {
				this.SetState("SELE")
			}
		}
		if (this.Tipo.indexOf(".MENU.") > -1) this.ParentObj.DetOut(this)
	}
	if (this.Tipo.indexOf("MENU.DROPPANEL") > -1) this.ParentObj.DetOut(this)
	if (this.Tipo.indexOf("CONTEXTPANEL") > -1) {
		ExecCmdDelayed(400, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",MouseOut")
	}
	this.HostPanel.OnMouseOut(id, hnod)
}

Qitempanel.prototype.OnMouseUp=function(id, hnod, wx, wy, cx, cy) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	this.IsDragging=false
	if (this.HostPanel.OnMouseUp) this.HostPanel.OnMouseUp(id, hnod, wx, wy, cx, cy)
}

Qitempanel.prototype.OnMouseDown=function(id, hnod, wx, wy, cx, cy) {
	if (AllInputBlocked == true) return
	//if (this.Disabled == true) return
	if (this.HostPanel.OnMouseDown) this.HostPanel.OnMouseDown(id, hnod, wx, wy, cx, cy, this)
	if (this.HostPanel.DatactlObj != null) {
		if (this.HostPanel.DatactlObj.Tipo.indexOf("COMBO") > -1) this.HostPanel.DatactlObj.IsQuerying=true
	}
}

//Qitempanel.prototype.OnMouseDown=function(id, hnod, wx, wy) {GenericDisplayCtl_OnMouseDown(this, id, hnod, wx, wy)}

Qitempanel.prototype.OnFocus=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.OnMouseOver("", "")
}

Qitempanel.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.OnMouseOut("", "")
}

Qitempanel.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) this.OnClick()
	if (BrowserIE) {
		window.event.returnValue=false;
	} else {
		evt.preventDefault();
	}
}

Qitempanel.prototype.HeaderMouseDown=function(wheader) {
	if (this.OverResize == wheader) {
		this.IsDragging=true
	} else {
		this.ParentObj.HeaderClick(wheader)
	}
}

Qitempanel.prototype.HeaderMouseUp=function(wheader) {
	this.IsDragging=false
	this.ParentObj.RecalcGcols()
	this.ParentObj.RefreshDataCols()
}

Qitempanel.prototype.HeaderMouseMove=function(wheader, wx, wy) {
	if (this.IsDragging == true) {
		this.OverResize.Hobj.style.cursor="col-resize"
		this.OverResize.Htxt.style.cursor="col-resize"
		wheader.Hobj.style.cursor="col-resize"
		wheader.Htxt.style.cursor="col-resize"
		var absx=wx + wheader.Col.Left
		var wlarg=absx - this.OverResize.Col.Left
		if (wlarg > 20 && wlarg < 600) {
			this.OverResize.Col.Larg=absx - this.OverResize.Col.Left
			this.OverResize.Col.Col.Larg=this.OverResize.Col.Larg
			this.ParentObj.RecalcGcols("HEADER")
		}
		return
	}
	if (wx > wheader.Col.Larg - 6) {
		this.OverResize=wheader
		if (this.ParentObj.Allowheaderresize == "S") {
			wheader.Hobj.style.cursor="col-resize"
			wheader.Htxt.style.cursor="col-resize"
		}
	} else {
		this.OverResize=null
		if (this.ParentObj.Alloworder == "N") {
			wheader.Hobj.style.cursor="default"
			wheader.Htxt.style.cursor="default"
		} else {
			wheader.Hobj.style.cursor="pointer"
			wheader.Htxt.style.cursor="pointer"
		}
	}
}

Qitempanel.prototype.OnClick=function(id, hnod, keys, wx, wy) {
	if (AllInputBlocked == true) return
    if (this.Disabled == true) return
    if (this.HostPanel.HostPanel.PointerScroll == "D") return
	this.Select("CLK", keys, wx, wy)
}

Qitempanel.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.Select("DBL")
}

Qitempanel.prototype.OnMouseWheel=function(id, hnod, delta) {
	this.HostPanel.OnMouseWheel(id, hnod, delta)
}

Qitempanel.prototype.OnScroll=function() {
	this.ParentObj.OnPanelScroll(this.Hobj.scrollLeft)
}

Qitempanel.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qitempanel.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qitempanel.prototype.OnContext=function(id, hnod, wx, wy) {
	if (this.Disabled == true) return
	if (this.Hid.indexOf("AUTOQUERYPANEL") > -1) {
		this.ParentObj.OnContext("QRY", wx, wy)
	} else {
		this.Select()
		this.ParentObj.OnContext("DET", wx, wy)
	}
}

//***************************************************************** QHEADER - define Header de coluna
function Qheader(hostpage, hostpanel, parentobj, col) {
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.ParentObj=parentobj
	this.Tipo="HEADER"
	this.CLASS="HEADER"
	this.Id="Header" + this.HostPage.CtlCount
	this.HostPage.CtlCount ++
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Col=col
	this.Inuse=true
	this.Disabled=false
	this.Actls=new Array()
	this.Style=parentobj.Style
	this.Locsize=new QlocSize((hostpanel.Locsize.MargL + col.Left) + "," + hostpanel.Locsize.MargT, col.Larg + "," + (hostpanel.Locsize.ObjH - hostpanel.Locsize.MargT - hostpanel.Locsize.MargB), hostpanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Frame=new Qframe(this)
	wdiv.onmousemove=EvtMouseMove
	wdiv.onmousedown=EvtMouseDown
	wdiv.onmouseup=EvtMouseUp
	wdiv.oncontextmenu=EvtContext
	var wtxt=CreateDiv(wdiv, this.Hid + "._.TXT", this.Locsize.MargL, this.Locsize.MargT, "100%", "100%")
	wtxt.style.padding=this.Locsize.MargT + "px " + this.Locsize.MargR + "px " + this.Locsize.MargB + "px " + this.Locsize.MargL + "px"
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0px"
	wtxt.align="center"
	wtxt.innerHTML = col.Tit
	SetUnselectable(wtxt)
	if (this.ParentObj.Alloworder == "S") {
		//wtxt.style.cursor="pointer"
		wdiv.style.cursor="pointer"
	}
	if (col.Id == "filler") {  //para as coluna filler
		this.Hobj.style.backgroundColor="transparent"
		this.Hobj.style.borderStyle="none"
		this.Hobj.style.backgroundImage="url()"
	}
	if (col.Id == "$selected") wdiv.style.cursor="default"
	this.Htxt=wtxt
	var wiord=CreateImg(wdiv, this.Hid + "._.ORD", 2, 4)
	this.Hord=wiord
	this.SetOrder()
	this.SetState("NORM")
}

Qheader.prototype.SetState=function(st) {
	this.Frame.SetState(st)
	this.Htxt.className=this.Frame.StateObj.TxtClass
}

Qheader.prototype.Activate=function() {
}

Qheader.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
	this.Frame.Resize()
}

Qheader.prototype.Show=function() {
}

Qheader.prototype.Hide=function() {
}

Qheader.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qheader.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qheader.prototype.SetOrder=function() {
	if (this.Col.Ord == "") this.Hord.src=GetImageAddress("idbenord.gif")
	if (this.Col.Ord == "A") this.Hord.src=GetImageAddress("idbeasc.gif")
	if (this.Col.Ord == "D") this.Hord.src=GetImageAddress("idbedesc.gif")
}

Qheader.prototype.OnMouseOver=function(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Col.Id == "$selected") return
	if (this.ParentObj.Alloworder == "N") return
	this.SetState("HIGH")
}

Qheader.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Col.Id == "$selected") return
	if (this.ParentObj.Alloworder == "N") return
	this.SetState("NORM")
	if (this.ParentObj.Alloworder == "S") this.Hobj.style.cursor="pointer"
}

Qheader.prototype.OnMouseDown=function(id) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Col.Id == "$selected") return
	if (this.Col.Col == null) return
	//if (this.ParentObj.Alloworder == "N") return
	this.HostPanel.HeaderMouseDown(this)
}

Qheader.prototype.OnMouseUp=function(id) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Col.Id == "$selected") return
	if (this.Col.Col == null) {
		if (this.Col.Id == "filler") {
			this.HostPanel.HeaderMouseUp(this)
		} else {
			return
		}
	}
	//if (this.ParentObj.Alloworder == "N") return
	this.HostPanel.HeaderMouseUp(this)
}

Qheader.prototype.OnMouseMove=function(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.ParentObj.Allowheaderresize == "N") return
	if (this.Col.Id == "$selected") return
	this.HostPanel.HeaderMouseMove(this, wx, wy)
}

Qheader.prototype.OnContext=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.ParentObj.OnContext("HDR")
}

Qheader.prototype.Destroy=function(opt) {
	this.Frame.Destroy()
	this.Frame=null
	this.Hobj.removeChild(this.Htxt)
	this.Htxt=null
	this.Hobj.parentNode.removeChild(this.Hobj);
	this.Hobj=null
}



//***************************************************************** QLEDTXT - define Ledit Txt
function Qledtxt(xnod, hostpage, hostpanel) {
	this.Tipo="LEDTXT"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	this.DatafldIx=this.DatactlObj.GetColIndex(this.Datafld)
	if (this.DatafldIx == null) {
		window.alert(GetMsg(1, "O controlo (" + this.Id + ") referencia um DATAFLD (" + this.Datafld + ") inválido"))
		return
	}
	var wcol=this.DatactlObj.Cols[this.DatafldIx]
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disabled=false
	}
	this.DatactlKey=this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.HasFocus=false
	this.Obrig=false
	if (wcol.Obrig == "S" || this.DatactlObj.Obrig == "S") this.Obrig=true
	var wtxt = document.createElement("INPUT")
	wtxt.type="text"
	wtxt.id=this.Hid + "._.TXT"
	wtxt.style.position="absolute"
	this.Hobj.appendChild(wtxt)
	this.Htxt=wtxt
	wtxt.style.left=(this.Locsize.MargL) + "px"
	wtxt.style.top=(this.Locsize.MargT - 2) + "px"
	wtxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	wtxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	wtxt.style.borderWidth="0px"
	wtxt.style.backgroundColor="transparent"
	wtxt.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) wtxt.tabIndex=wtxt.tabIndex+100
	this.SetState("NORM")
	wtxt.value=""
	this.ValorAnt=""
	wtxt.onfocus=EvtFocus
	wtxt.onblur=EvtBlur
	wtxt.onkeyup=EvtKeyUp
	wtxt.onkeypress=EvtKeyPress
	wtxt.onclick=EvtClick
}

Qledtxt.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qledtxt.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qledtxt.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qledtxt.prototype.SetState=function(st) {
	if ((st == "NORM" || st == "HIGH" || st == "SELE") && this.Obrig == true) st="OBRI"
	if (this.HostDataPanel == null) {
		if (st == "HIGH" || st == "SELE") return
	}
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qledtxt.prototype.SetVal=function(valor, cmd) {
	this.Htxt.value = valor
	if (this.HasFocus == true) {
		var csel=0
		var vant=""
		var vact=""
		for (var i=0; i<this.ValorAnt.length && i<valor.length; i++) {
			vant=this.ValorAnt.substr(i,1)
			vact=valor.substr(i,1)
			if (vant.toUpperCase() == vact.toUpperCase()) csel=i+1
		}
		if (BrowserIE || BrowserOP) {
			var range=this.Htxt.createTextRange()
			range.moveStart("character", csel)
			range.select()
		} else {
			this.Htxt.selectionStart=csel
			this.Htxt.selectionEnd=this.Htxt.value.length
		}
	}
	this.DatactlObj.SetIndex(this.DatactlKey)
	//if (cmd == "SAVE")
	this.DatactlObj.HideErr()
	this.TestEvents()
}

Qledtxt.prototype.GetVal=function() {
	return this.Htxt.value
}

Qledtxt.prototype.TestEvents=function() {
	this.DatactlObj.SetIndex(this.DatactlKey)
	var wval=this.DatactlObj.GetVal(this.DatactlObj.KeyIndex)
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if ((evt.Id ==	"EQ" && evt.Valor == wval) || (evt.Id ==	"NE" && evt.Valor != wval) || (evt.Id ==	"GT" && wval > evt.Valor) || (evt.Id ==	"GE" && wval >= evt.Valor) || (evt.Id ==	"LT" && wval < evt.Valor) || (evt.Id ==	"LE" && wval <= evt.Valor)) {
			GenericDisplayCtl_SetRowOrig.call(this)
			ExecCmd(this.HostPage.Area, evt.Act)
		}
	}
}

Qledtxt.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	this.Htxt.tabIndex=-this.Htxt.tabIndex
	this.Htxt.readOnly = true
}

Qledtxt.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		this.Htxt.tabIndex=-this.Htxt.tabIndex
		this.Htxt.readOnly = false
	}
}

Qledtxt.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qledtxt.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qledtxt.prototype.ShowErr=function(msg) {GenericDisplayCtl_ShowErr.call(this, msg)}

Qledtxt.prototype.HideErr=function(msg) {GenericDisplayCtl_HideErr.call(this, msg)}

Qledtxt.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qledtxt.prototype.Destroy2=function() {
	this.DatactlObj.DestroyUnit(this.DatactlKey)
	GenericDisplayCtl_Destroy2.call(this)
}

Qledtxt.prototype.OnFocus=function() {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnFocus.call(this)
	if (BrowserIE || BrowserOP) {
		var range=this.Htxt.createTextRange()
		range.moveStart("character",this.ValorAnt.length)
		range.select()
	} else {
		this.Htxt.selectionStart=this.ValorAnt.length
		this.Htxt.selectionEnd=this.Htxt.value.length
	}
	this.HasFocus=true
}

Qledtxt.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnBlur.call(this)
	var wcol=this.DatactlObj.Cols[this.DatafldIx]
	var valor=this.Htxt.value
	this.HasFocus=false
}

Qledtxt.prototype.Focus=function() {
	if (this.Visible == false || this.Disabled == true) return
	this.Htxt.focus()
}

Qledtxt.prototype.OnClick=function(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
	    if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) return
		this.HostDataPanel.Select("CLK", keys)
	}
}

Qledtxt.prototype.OnKeyPress=function(wkey) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
	    if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) return
		this.HostDataPanel.Select("CLK", "")
	}
}

Qledtxt.prototype.OnKeyUp=function(wkey) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	var valact=this.Htxt.value
	if (wkey == 37 || wkey == 38 || wkey == 39 || wkey == 40 || wkey == 9 || wkey == 16) return
	if (valact == this.ValorAnt && wkey != 46 && wkey != 8) return
	this.ValorAnt=valact
	this.DatactlObj.SetIndex(this.DatactlKey)
	var Unit=this.DatactlObj.Units[this.DatactlObj.Uix]
	if (valact != "") {
		var wcol=this.DatactlObj.Cols[this.DatafldIx]
		Unit.Cond=AppendCond("", wcol.Id, wcol.Type, valact, "LEDTXT")
	} else {
		Unit.Cond=""
	}
	if (Unit.Queue == false) {
		Unit.Queue = true
		ExecCmdDelayed(600, this.HostPage.Area, "ExecuteInternal(" + this.Datactl)
	}
}



//***************************************************************** QTITLE - define Title
function Qtitle(xnod, hostpage, hostpanel) {
	this.Tipo="TITLE"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Align=GetAtt(xnod, "ALIGN", "LEFT")
	this.Txt=GetAtt(xnod, "TXT", hostpage.Tit)
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	this.Cols=new Array()
	this.Dados=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			this.Dados.push("")
		}
		xn=xn.nextSibling
	}
	var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", 0, 0, "100%", "100%")
	wtxt.style.padding=this.Locsize.MargT + "px " + this.Locsize.MargR + "px " + this.Locsize.MargB + "px " + this.Locsize.MargL + "px"
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0"
	wtxt.align=this.Align
	wtxt.style.backgroundColor="transparent"
	SetUnselectable(wtxt)
	//wtxt.style.cursor="pointer"
	this.Htxt=wtxt
	this.SetState("NORM")
}


Qtitle.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qtitle.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qtitle.prototype.Activate=function(opt) {
	this.Activated=true
	if (this.Provider != "") {
		if (this.HostPage.Func == "INS") {  //se está em Inserção não vai pedir dados ao servidor, preenche campos com vazio
			for (var i=0; i<this.Cols.length; i++) {
				var ix=this.Txt.indexOf("(" + this.Cols[i].Id + ")")
				if (ix != -1) {
					var ix2=this.Txt.indexOf(")",ix+1)
					this.Txt = this.Txt.substr(0, ix) + this.Txt.substr(ix2+1)
				}
			}
		} else {
			this.Send()
		}
	}
	this.Htxt.innerHTML = this.Txt
	this.HostPage.Tit = this.Txt
	if (this.Visible == true) this.Show("INIT")
}


Qtitle.prototype.Disable=function() {
}
Qtitle.prototype.Enable=function() {
}

Qtitle.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qtitle.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qtitle.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qtitle.prototype.Destroy2=function() {
	this.Cols=null
	this.Dados=null
	GenericDisplayCtl_Destroy2.call(this)
}

Qtitle.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qtitle.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qtitle.prototype.Send=function() {
	if (this.Provider == "") return
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.IDENT=this.Id
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.FUNC="GET1"
	iblk.COND=""
	var histgetid=""
	var histop=""
	var hix=-1
	var area=this.HostPage.Area
	var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		iblk.CMPS.push(col.Id)
		wrec.push("")
		histgetid=col.HistGetId
		histop=col.HistOp
		if (histgetid == "") {
			histgetid=col.Id
			histop="EQ"
		}
		if (histop == "BL") {
			hix=GetHistorialIndex(area, histgetid, "GE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "GE")
			hix=GetHistorialIndex(area, histgetid, "LE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "LE")
		} else {
			hix=GetHistorialIndex(area, histgetid, histop)
			if (hix > -1 && area.Historial[hix].Valor != "") {
				iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", histop)
			}
		}
	}
	iblk.DADOS.push(wrec)
	SendServer(this.HostPage, iblk, "SINGLE")
}

Qtitle.prototype.Receive=function(iblk, gstatus) {
	var Adad=iblk.DADOS[0]
	for (var i=0; i<this.Cols.length; i++) {
		if (i < Adad.length) {
			this.Dados[i]=Adad[i]
		} else {
			this.Dados[i]=""
		}
	}
	for (var i=0; i<this.Cols.length; i++) {
		var ix=this.Txt.indexOf("(" + this.Cols[i].Id + ")")
		if (ix != -1) {
			var ix2=this.Txt.indexOf(")",ix+1)
			this.Txt = this.Txt.substr(0, ix) + FormatCol(this.Cols[i], this.Dados[i], "user") + this.Txt.substr(ix2+1)
		}
	}
	this.Htxt.innerHTML = this.Txt
	this.HostPage.Tit = this.Txt
	if (iblk.STAT != "OK") this.HostPage.ShowWarning(iblk.MSG)
}


//***************************************************************** QPATH - define Path
function Qpath(xnod, hostpage, hostpanel) {
	this.Tipo="PATH"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.PanelObj=this.Hobj
	for (var i=0; i<this.HostPage.Area.Pages.length; i++) {
		if (i > 0) {
			var wsep=document.createElement("SPAN")
			wsep.style.cursor="default"
			wsep.innerHTML = "&nbsp;-->&nbsp;"
			this.Hobj.appendChild(wsep)
        }
        var wctl = new Qpathelem("", hostpage, this)
        this.Actls.push(wctl)
	}
	this.SetState("NORM")
}

Qpath.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qpath.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qpath.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qpath.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
}

Qpath.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qpath.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qpath.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qpath.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qpath.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qpath.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qpath.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.SetState("HIGH")
	this.HostPanel.OnMouseOver(id, hnod)
}

Qpath.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.SetState("NORM")
	this.HostPanel.OnMouseOut(id, hnod)
}


//***************************************************************** QPATHELEM - define elemento de path
function Qpathelem(xnod, hostpage, hostpanel) {
    this.Tipo = "PATHELEM"
    this.Class = "DISPLAY"
    this.HostPage = hostpage
    this.HostPanel = hostpanel
    this.HostDataPanel = FindDataPanel(this)
    this.ParentObj = null
    this.Actls = new Array()
    this.Id=this.Tipo + this.HostPage.CtlCount
	this.HostPage.CtlCount ++
	this.Hid=hostpanel.Hid + "." + this.Id
    this.Style = hostpanel.Style
    this.StyleObj = App.GetStyle(this.Style, this.Tipo)
    this.Disabled=false
	this.Visible=true
	this.Hobj = document.createElement("SPAN")
	this.Hobj.id=this.Hid
	this.Hobj.style.cursor = "pointer"
	hostpanel.PanelObj.appendChild(this.Hobj)
	this.Frame = new Qframe(this)
	this.Index = hostpanel.Actls.length
	this.Hobj.innerHTML = this.HostPage.Area.Pages[this.Index].Tit
	this.Hobj.onmouseover = EvtMouseOver
	this.Hobj.onmouseout = EvtMouseOut
	this.Hobj.onclick = EvtClick
    this.Hobj.onfocus = EvtFocus
    this.Hobj.onblur = EvtBlur
    this.Hobj.onkeydown = EvtKeyDown
    this.SetState("NORM")
}

Qpathelem.prototype.SetState = function(st) {
    GenericDisplayCtl_SetState.call(this, st)
    this.Hobj.className = this.Hobj.className + " " + this.Frame.StateObj.TxtClass
}

Qpathelem.prototype.Activate = function() { GenericDisplayCtl_Activate.call(this) }

Qpathelem.prototype.Activate2 = function() {
}

Qpathelem.prototype.Disable = function(tipo) {
    GenericDisplayCtl_Disable.call(this, tipo)
}

Qpathelem.prototype.Enable = function(tipo) {
    GenericDisplayCtl_Enable.call(this, tipo)
}

Qpathelem.prototype.Show = function(opt) {
    this.Hobj.style.display = "block"
}

Qpathelem.prototype.Hide = function(opt) {
    this.Hobj.style.display = "none"
}

Qpathelem.prototype.Destroy = function(opt) { GenericDisplayCtl_Destroy.call(this, opt) }

Qpathelem.prototype.Destroy2 = function() { GenericDisplayCtl_Destroy2.call(this) }

Qpathelem.prototype.OnClick = function() {
	if (AllInputBlocked == true) return
    if (this.Disabled == true) return
    GoToPage(this.HostPage.Area, this.Index)
}

Qpathelem.prototype.OnMouseOver = function(id, hnod) {
	if (AllInputBlocked == true) return
    if (this.Disabled == true) return
    this.SetState("HIGH")
    GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
}

Qpathelem.prototype.OnMouseOut = function(id, hnod) {
	if (AllInputBlocked == true) return
    if (this.Disabled == true) return
    this.SetState("NORM")
    GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qpathelem.prototype.OnFocus = function() { GenericDisplayCtl_OnFocus.call(this) }

Qpathelem.prototype.OnBlur = function() { GenericDisplayCtl_OnBlur.call(this) }

Qpathelem.prototype.Focus = function() { GenericDisplayCtl_Focus.call(this) }

Qpathelem.prototype.OnKeyDown = function(wkey) {
	if (AllInputBlocked == true) return
    if (this.Disabled == true) return
    if (wkey == 13 || wkey == 32) {  //Enter ou space bar
        this.OnClick()
    }
}


//***************************************************************** QMSG - define Msg
function Qmsg(xnod, hostpage, hostpanel) {
	this.Tipo="MSG"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Align=GetAtt(xnod, "ALIGN", "LEFT")
	var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", 0, 0, "100%", "100%")
	wtxt.style.padding=this.Locsize.MargT + "px " + this.Locsize.MargR + "px " + this.Locsize.MargB + "px " + this.Locsize.MargL + "px"
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0"
	wtxt.align=this.Align
	this.Htxt=wtxt
	this.SetState("NORM")
}

Qmsg.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}

Qmsg.prototype.Activate2=function(opt) {GenericDisplayCtl_Activate2.call(this, opt)}

Qmsg.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qmsg.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qmsg.prototype.SetVal=function(valor) {
	this.Htxt.innerHTML = valor
}

Qmsg.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qmsg.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qmsg.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qmsg.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qmsg.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qmsg.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qmsg.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qmsg.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}


//***************************************************************** QPARAGRAPH - define Paragraph
function Qparagraph(xnod, hostpage, hostpanel) {
	this.Tipo="PARAGRAPH"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Paragraph" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Actls=new Array()
	this.Events=new Array()
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Disabled=false
	if (this.Prot == "S") this.Disabled=true
	this.Align=GetAtt(xnod, "ALIGN", "LEFT")
	this.TxtOrig=GetAtt(xnod, "TXT", "")
	var re=/\\r\\n/g
	this.TxtOrig=this.TxtOrig.replace(re, "<br>")
	this.Txt=""
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	this.Modulo=GetAtt(xnod, "MOD", "")
	this.Nivseg=GetAtt(xnod, "NIVSEG", "0")
	this.Cols=new Array()
	this.Dados=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			this.Dados.push("")
		}
		xn=xn.nextSibling
	}
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	this.Locsize=new QlocSize("0,0", "10,10", this.HostPanel)  // tem que existir por compatibilidade com os outros display controls
	var wdiv = document.createElement("DIV")
	wdiv.id=this.Hid
	wdiv.style.display="none"
	wdiv.style.position="relative"
	hostpanel.PanelObj.appendChild(wdiv)
	var state=this.StyleObj.GetState("NORM")
	wdiv.className=state.BgClass + " " + state.TxtClass

	wdiv.align=this.Align
	wdiv.style.padding="3px 3px"
	wdiv.innerHTML = this.Txt
	wdiv.style.zIndex=1
	this.Hobj=wdiv
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	if (User.ModAutorizado(this.Modulo, this.Nivseg) == false) this.Visible=false
	this.Activated=false
}

Qparagraph.prototype.Resize=function() {
}

Qparagraph.prototype.Activate=function(opt) {
	this.Activated=true
	this.Txt=this.TxtOrig
	if (this.Provider != "") {
		if (User.ModAutorizado(this.Modulo, this.Nivseg) == false) return
		if (this.Provider != "*") this.SendRequest(this)
	} else {
		this.Activate2(opt)
	}
}

Qparagraph.prototype.Activate2=function(opt) {
	if (this.Provider != "") {
		for (var i=0; i<this.Cols.length; i++) {
			var ix=this.Txt.indexOf("(" + this.Cols[i].Id + ")")
			while (ix > -1) {
				var ix2=this.Txt.indexOf(")",ix+1)
				this.Txt = this.Txt.substr(0, ix) + this.Dados[i] + this.Txt.substr(ix2+1)
				ix=this.Txt.indexOf("(" + this.Cols[i].Id + ")")
			}
		}
		var re=/\r\n/g
		this.Txt=this.Txt.replace(re, "<br>")
		var re=/\r/g
		this.Txt=this.Txt.replace(re, "<br>")
		var re=/\n/g
		this.Txt=this.Txt.replace(re, "<br>")
	}
	//procurar TOKENs
	var ix=this.Txt.indexOf("<TOKEN")
	while (ix > -1) {
		var iz=this.Txt.indexOf("</TOKEN>", ix+6)
		if (iz == -1) {
			window.alert(GetMsg(1, "TOKEN incompleto no PARAGRAPH ID=" + this.Id + " TXT=" + this.Txt))
			break
		}
		this.Txt=this.Txt.substr(0,ix) + Qtoken(this.Txt.substr(ix, iz+8-ix), this.HostPage, this.HostPanel) + this.Txt.substr(iz+8)
		ix=this.Txt.indexOf("<TOKEN", ix)
	}
	this.Hobj.innerHTML = this.Txt
	if (opt == "INIT") {
		if (this.Visivel == "S") this.Show()
	}
}

Qparagraph.prototype.SetVal=function(valor) {
	this.TxtOrig = valor
	var re=/\r\n/g
	this.TxtOrig=this.TxtOrig.replace(re, "<br>")
	var re=/\r/g
	this.Txt=this.Txt.replace(re, "<br>")
	var re=/\n/g
	this.Txt=this.Txt.replace(re, "<br>")
	this.Activate()
}

Qparagraph.prototype.Disable=function() {
}
Qparagraph.prototype.Enable=function() {
}

Qparagraph.prototype.Show=function() {
	if (this.Activated == false) {
		this.Activate()
		return
	}
	this.Hobj.style.display="block"
	this.Visible=true
}

Qparagraph.prototype.Hide=function(opt) {
	this.Hobj.style.display="none"
	this.Visible=false
}

Qparagraph.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qparagraph.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qparagraph.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	this.Hide(opt)
}

Qparagraph.prototype.SendRequest=function() {
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.IDENT=this.Id
	if(this.Modulo == "") {
    	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
    } else {
    	iblk.MOD=User.GetModDb(this.Modulo)
	}
	iblk.FUNC="GET1"
	iblk.COND=""
	var histgetid=""
	var histop=""
	var hix=-1
	var area=this.HostPage.Area
	var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		iblk.CMPS.push(col.Id)
		wrec.push("")
		histgetid=col.HistGetId
		histop=col.HistOp
		if (histgetid == "") {
			histgetid=col.Id
			histop="EQ"
		}
		if (histop == "BL") {
			hix=GetHistorialIndex(area, histgetid, "GE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "GE")
			hix=GetHistorialIndex(area, histgetid, "LE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "LE")
		} else {
			hix=GetHistorialIndex(area, histgetid, histop)
			if (hix > -1 && area.Historial[hix].Valor != "") {
				iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", histop)
			}
		}
	}
	iblk,DADOS.push(wrec)
	SendServer(this.HostPage, iblk, "SINGLE")
}

Qparagraph.prototype.Receive=function(iblk, gstatus, last) {
	var Adad=iblk.DADOS[0]
	for (var i=0; i<this.Cols.length; i++) {
		if (i < Adad.length) {
			this.Dados[i]=Adad[i]
			this.Dados[i]=FormatCol(this.Cols[i], Adad[i], "user")
		} else {
			this.Dados[i]=""
		}
	}
	if (iblk.STAT != "OK") this.HostPage.ShowWarning(iblk.MSG)
	this.Activate2()
}


//***************************************************************** QTOKEN - define Token
function Qtoken(xstr, hostpage, hostpanel) {
	this.Tipo="TOKEN"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	if (BrowserIE) {
		var xnod=new ActiveXObject("MSXML.DOMDocument")
		xnod.loadXML(xstr)
	} else {
		var docparser=new DOMParser()
		var xnod=docparser.parseFromString(xstr,"text/xml")
	}
	var xnod=xnod.documentElement
	this.Id=this.Tipo
	this.Text=GetAtt(xnod, "TXT", "")
	var re=/\r\n/g
	this.Text=this.Text.replace(re, "<br>")
	var re=/\r/g
	this.Text=this.Text.replace(re, "<br>")
	var re=/\n/g
	this.Text=this.Text.replace(re, "<br>")
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Link=GetAtt(xnod, "LINK", "")
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	this.Cols=new Array()
	this.Dados=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			this.Dados.push("")
		}
		xn=xn.nextSibling
	}
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	var wdiv="<span "
	var wstl="class='" + this.StyleObj.States[0].BgClass + " " + this.StyleObj.States[0].TxtClass + "'"
	if (this.Tip != "") wstl += " style='cursor: pointer;'"
	wdiv += wstl
	if (this.Provider != "") QtokenSendReceive(this)
	for (var i=0; i<this.Cols.length; i++) {
		var wstr="(" + this.Cols[i].Id + ")"
		if (this.Text.indexOf("(") > -1) this.Text=ReplaceText(this.Text, wstr, this.Dados[i])
		if (this.Tip.indexOf("(") > -1) this.Tip=ReplaceText(this.Tip, wstr, this.Dados[i])
		if (this.Link.indexOf("(") > -1) this.Link=ReplaceText(this.Link, wstr, this.Dados[i])
	}
	var re=/\\r\\n/g
	this.Text=this.Text.replace(re, "<br>")
	if (this.Tip != "") wdiv += " title='" + this.Tip + "'"
	wdiv+=">"
	if (this.Link != "") {
		wdiv += "<a target='_blank' href='" + this.Link + "' " + wstl + ">" + this.Text + "</a>"
	} else {
		wdiv += this.Text
	}
	wdiv += "</span>"
	return wdiv
}

function QtokenSendReceive(ctl) {
	var iblk=new Interblk()
	iblk.APP=ctl.Provider
	iblk.IDENT=ctl.Id
   	iblk.MOD=User.GetModDb(ctl.HostPage.Modulo)
	iblk.FUNC="GET1"
	iblk.COND=""
	var histgetid=""
	var histop=""
	var hix=-1
	var area=ctl.HostPage.Area
	var wrec=new Array()
	for (var i=0; i<ctl.Cols.length; i++) {
		var col=ctl.Cols[i]
		iblk.CMPS.push(col.Id)
		wrec.push("")
		histgetid=col.HistGetId
		histop=col.HistOp
		if (histgetid == "") {
			histgetid=col.Id
			histop="EQ"
		}
		if (histop == "BL") {
			hix=GetHistorialIndex(area, histgetid, "GE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "GE")
			hix=GetHistorialIndex(area, histgetid, "LE")
			if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "LE")
		} else {
			hix=GetHistorialIndex(area, histgetid, histop)
			if (hix > -1 && area.Historial[hix].Valor != "") {
				iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", histop)
			}
		}
	}
	iblk.DADOS.push(wrec)
	iblk=SendServerSync(ctl.HostPage, iblk)
	var Adad=iblk.DADOS[0]
	for (var i=0; i<ctl.Cols.length; i++) {
		if (i < Adad.length) {
			ctl.Dados[i]=Adad[i]
			ctl.Dados[i]=FormatCol(ctl.Cols[i], Adad[i], "user")
		} else {
			ctl.Dados[i]=""
		}
	}
	if (iblk.STAT != "OK") ctl.HostPage.ShowWarning(iblk.MSG)
}


//***************************************************************** QLABEL - define Label
function Qlabel(xnod, hostpage, hostpanel) {
	this.Tipo="LABEL"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Txt=GetAtt(xnod, "TXT", "")
	this.Align=GetAtt(xnod, "ALIGN", "LEFT")
	var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", 0, 0, "100%", "100%")
	wtxt.style.padding=this.Locsize.MargT + "px " + this.Locsize.MargR + "px " + this.Locsize.MargB + "px " + this.Locsize.MargL + "px"
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0"
	wtxt.align=this.Align
	wtxt.innerHTML = this.Txt
	wtxt.style.cursor="default"
	SetUnselectable(wtxt)

	this.Htxt=wtxt
	this.SetState("NORM")
}

Qlabel.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qlabel.prototype.Activate2=function(opt) {}

Qlabel.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qlabel.prototype.SetState=function(st) {
	this.Frame.SetState(st)   //fica com o state inicial, não muda
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qlabel.prototype.SetVal=function(valor) {
	this.Htxt.innerHTML = valor;
}

Qlabel.prototype.GetVal=function(valor) {
	return this.Htxt.innerHTML;
}

Qlabel.prototype.Disable=function() {}
Qlabel.prototype.Enable=function() {}

Qlabel.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qlabel.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qlabel.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qlabel.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qlabel.prototype.OnClick=function() {GenericDisplayCtl_OnClick.call(this)}

Qlabel.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qlabel.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}





//***************************************************************** GRPBOX - define groupbox
function Qgrpbox(xnod, hostpage, hostpanel) {
	this.Tipo="GRPBOX"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Txt=GetAtt(xnod, "TXT", "")
	if (this.Txt != "") {
		var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", this.Locsize.MargL + 5, 0)
		wtxt.innerHTML = this.Txt
		wtxt.style.cursor="default"
		SetUnselectable(wtxt)
		this.Htxt=wtxt
	}
	this.SetState("NORM")
	this.Hobj.style.zIndex=0
	this.Hobj.onclick=EvtClick
	this.Hobj.ondblclick=EvtDblClick
}

Qgrpbox.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qgrpbox.prototype.Activate2=function(opt) {}

Qgrpbox.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qgrpbox.prototype.SetState=function(st) {
	if (this.Htxt != undefined) this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qgrpbox.prototype.Disable=function() {
}
Qgrpbox.prototype.Enable=function() {
}

Qgrpbox.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qgrpbox.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qgrpbox.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qgrpbox.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qgrpbox.prototype.OnClick=function() {GenericDisplayCtl_OnClick.call(this)}

Qgrpbox.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("DBL")
}

Qgrpbox.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qgrpbox.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}


//***************************************************************** QTEXT - define Textbox
function Qtext(xnod, hostpage, hostpanel) {
	this.Tipo="TEXT"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.NoPaste = GetAtt(xnod, "NOPASTE", "")
	this.Queryfld=false
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) this.Queryfld=true
	}
	this.Events=new Array()
	this.Actls=new Array()
	this.Disabled=false
	this.Tipo4Style=this.Tipo
	this.InitialFocus="N"
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Text" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Align=GetAtt(xnod, "ALIGN", "LEFT")
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=null
	if (this.Datactl != "") {
		this.DatactlObj=hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "TEXT (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
	}
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.ReadOnly=GetAtt(xnod, "READONLY", "N")
	this.Pw=GetAtt(xnod, "PW", "N")
	this.Multiline=GetAtt(xnod, "MULTILINE", "N")
	this.Ucase=GetAtt(xnod, "UCASE", "N")
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Calend=GetAtt(xnod, "CALEND", "N")
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.Mask=GetAtt(xnod, "MASK", "")
	this.Placeholder=GetAtt(xnod, "PLACEHOLDER", "")
	this.Location=GetAtt(xnod, "LOCATION", "0,0")
	this.Size=GetAtt(xnod, "SIZE", "0,0")
	this.InitialFocus=GetAtt(xnod, "FOCUS", "N")
	this.Nseq=GetAtt(xnod, "NSEQ", "N")  // indicador de que se trata de um numero sequencial
	if (this.InitialFocus == "S") this.HostPage.InitialFocusSet=true
	this.CalendInteracting=false  //fica true se existir calendario aberto e alguem clicar num botão do calendario fazendo o controlo de texto perder o focus
	if (this.Mask == "") {
		if (this.DataCol.Type == "D") {
			this.Mask="00/00/0000"
			if (User.DateFmt == "AMD") this.Mask="0000/00/00"
		}
		if (this.DataCol.Type == "H") {
			this.Mask="00/00/0000"
			if (User.DateFmt == "AMD") this.Mask="0000/00/00"
			if (User.TimeFmt == "24") {
				this.Mask=this.Mask + " 00:00"
			} else {
				this.Mask=this.Mask + " 00:00LL"
			}
		}
		if (this.DataCol.Type == "S") {
			this.Mask="00/00/0000"
			if (User.DateFmt == "AMD") this.Mask="0000/00/00"
			if (User.TimeFmt == "24") {
				this.Mask=this.Mask + " 00:00:00"
			} else {
				this.Mask=this.Mask + " 00:00:00LL"
			}
		}
		if (this.DataCol.Type == "T") {
			this.Mask="00:00"
			if (User.TimeFmt == "12") this.Mask="00:00LL"
		}
	}
	if (this.Mask != "" && this.Queryfld == true) this.Mask=""
	// 0=numerico obrigatorio
	// L=letra obrigatoria
	// &=caracter obrigatorio
	this.Locsize=new QlocSize(this.Location, this.Size, hostpanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	wdiv.style.zIndex=1
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	if (this.Multiline == "S") this.Tipo4Style+="M"
	this.Tipo4Style=hostpanel.Tipo + "." + this.Tipo4Style
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.Tipo.indexOf("AUTODATAPANEL") > -1) this.Tip="*"
	}
	this.StyleObj=App.GetStyle(this.Style, this.Tipo4Style)
	this.Frame=new Qframe(this)
	if (this.Tip != "" && this.Tip != "*") wdiv.title=this.Tip
	var txtoffset=0
	if (this.Multiline == "N") {
		if (this.ReadOnly == "N") {
			txtoffset=-2
			var wtxt = document.createElement("INPUT")
			wtxt.style.outlineStyle="none"
			if (this.Pw == "S") {
				wtxt.type="password"
			} else {
				wtxt.type="text"
			}
		} else {
			if (this.Pw == "S") {
				txtoffset=-2
				var wtxt = document.createElement("INPUT")
				wtxt.style.outlineStyle="none"
				wtxt.type="password"
				wtxt.readOnly=true
			} else {
				txtoffset=1
				var wtxt = document.createElement("DIV")
				wtxt.align=this.Align
				wtxt.readOnly=true
				wtxt.style.textOverflow="clip"
				wtxt.style.whiteSpace="nowrap"
				SetUnselectable(wtxt)
			}
			if (this.HostDataPanel != null && this.HostPanel.Disabled == false) {
				wtxt.style.cursor="pointer"
				wdiv.style.cursor="pointer"
			}
		}
	} else {
		if (this.ReadOnly == "N") {
			var wtxt = document.createElement("TEXTAREA")
			wtxt.style.outlineStyle="none"
			wtxt.style.overflow="auto"
			wtxt.style.overflowX="hidden"
			} else {
			var wtxt = document.createElement("DIV")
			wtxt.align=this.Align
			wtxt.style.overflow="auto"
		}
	}
	wtxt.style.borderWidth="0px"
	wtxt.style.backgroundColor="transparent"
	wtxt.id=this.Hid + "._.TXT"
	wtxt.style.position="absolute"
	this.Hobj.appendChild(wtxt)
	this.Htxt=wtxt
	wtxt.style.left=(this.Locsize.MargL) + "px"
	wtxt.style.top=(this.Locsize.MargT + txtoffset) + "px"
	wtxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	wtxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	if (this.Mask == "") {
		if (this.Queryfld == false) {
			if (this.DataCol.Comp > 0) {
				wtxt.maxLength=this.DataCol.Comp
	        	if(this.DataCol.Type == "N" && this.DataCol.Dec>=0) wtxt.maxLength=wtxt.maxLength+1+this.DataCol.Dec+Math.floor(this.DataCol.Comp / 3)
	        	if(this.DataCol.Type == "$") wtxt.maxLength=wtxt.maxLength+2+this.DataCol.Dec+Math.floor(this.DataCol.Comp / 3)
	    	}
    	} else {
	    	var maxl=this.DataCol.Comp
			if (maxl < 0) maxl=14
			wtxt.maxLength=maxl + 2
    	}
	}
	if (this.Placeholder != "") {
		this.Htxt.placeholder=this.Placeholder
	}

	if (this.Calend == "S") {
		var wbot = document.createElement("IMG")
		wbot.style.position="absolute"
		if (this.Prot == "N") {
			wbot.src=GetImageAddress("icalend.gif")
		} else {
			wbot.src=GetImageAddress("icalend_dis.gif")
		}
		wbot.style.zIndex=2
		wbot.style.cursor="pointer"
		wbot.style.top="1px"
		wbot.style.left=(this.Locsize.ObjW - 17) + "px"
		wbot.id=this.Hid + "._.BOT"
		wbot.onclick=EvtClick  //TextCalendClick
		this.Hobj.appendChild(wbot)
		this.Hbot=wbot
		if (this.Prot == "S") {
			this.Hbot.disabled=false
			this.Hbot.style.cursor="pointer"
		}
	}
	this.Hcalend=null
	if (this.DataCol.Id == "filler") {  //os campos do AUTOQRYPANEL que não têm interacção
		this.Hobj.style.visibility="hidden"
	}
	if (this.DataCol.Id == "$selected") {  //os campos do AUTOQRYPANEL que não têm interacção
		this.Hobj.style.cursor="default"
		this.Htxt.style.cursor="default"
	}
	if (this.ReadOnly == "N") wtxt.onblur=EvtBlur
	wtxt.onkeypress=EvtKeyPress
	wtxt.onkeyup=EvtKeyUp
	wtxt.onkeydown=EvtKeyDown
	wtxt.onfocus=EvtFocus
	wtxt.onclick=EvtClick
	wtxt.ondoubleclick=EvtDblClick
	wtxt.onpaste=EvtPaste
	wtxt.oncontextmenu=EvtContext

	wtxt.onmousedown=EvtMouseDown
	wtxt.onmouseup=EvtMouseUp

	if (this.ReadOnly == "S") {
		wtxt.tabIndex=-1
	} else {
		wtxt.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
		//if (this.HostDataPanel != null) wtxt.tabIndex=wtxt.tabIndex+100
	}
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	if (this.Prot == "S") {
		this.Disable("PROT")
	} else {
		this.SetState("NORM")
	}
	this.Activated=false
}

Qtext.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qtext.prototype.Activate2=function(opt) {
	if (this.InitialFocus == "S") this.Focus();
	if (this.DatactlObj.Tipo.indexOf("COMBO") > -1) {
		if (this.HostPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) {
			this.DatactlObj.IsQuerying=true;
			this.DatactlObj.QueryField=this;
			this.Focus();
		}
	}
}

Qtext.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	if (this.Calend == "S") {
		this.Hbot.style.top="1px"
		this.Hbot.style.left=(this.Locsize.ObjW - 17) + "px"
	}
}

Qtext.prototype.Execute = function(act) {
	if(act == "CloseCalend") {
		if (this.Hcalend != null) {
			if (this.CalendInteracting == true) {
				this.Focus()
				this.CalendInteracting = false
				return
			}
			this.CalendInteracting = false
			this.Hcalend.Execute("CLOSE")
		}
	}
}

Qtext.prototype.SetState=function(st) {
	if ((st == "NORM" || st == "HIGH" || st == "SELE") && this.DataCol.Obrig == "S") st="OBRI"
	if (this.HostDataPanel == null) {
		if (st == "HIGH" || st == "SELE") return
	}
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qtext.prototype.SetVal=function(valor, cmd) {
	if (this.Nseq == "S") {  // não mostra nada se o numero sequencial é negativo
		var wv=ConvertToNative(valor, this.DataCol.Type);
		if (wv < 0) valor="";
	}
	if (this.Mask != "") {
		var r = FormatMask(valor, this.Mask, 0)
		if (this.ReadOnly == "N") {
			this.Htxt.value = r.Texto
		} else {
			this.Htxt.innerHTML = r.Texto
		}
	} else {
		if (this.ReadOnly == "N") {
			this.Htxt.value = valor
		} else {
			if (this.Pw == "S") {
				this.Htxt.value = valor
			} else {
				this.Htxt.innerHTML = valor
			}
		}
	}
	if (this.Tip == "*") this.Hobj.title=FormatCol(this.DataCol, valor, "user")
	if (this.HostDataPanel != null) this.HostDataPanel.SetCurrentRow()
	if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") this.ValidarInput()
	this.TestEvents()
}


Qtext.prototype.GetVal=function() {
	var t=this.Htxt.tagName.toUpperCase()
	if (t == "INPUT") {
		return this.Htxt.value
	} else {
		return this.Htxt.innerHTML
	}
}

Qtext.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	this.Disabled=true
	if (FocusCtl.HostCtl == this) FocusCtl.Hide(this)
	this.Htxt.tabIndex=-this.Htxt.tabIndex
	if (this.ReadOnly == "N") this.Htxt.readOnly = true
	if (this.Htxt.style.cursor == "pointer") {
		this.CursorPointer=true
		this.Htxt.style.cursor="default"
		this.Hobj.style.cursor="default"
	}
	if (this.Calend == "S") {
		this.Hbot.src=GetImageAddress("icalend_dis.gif")
		this.Hbot.disabled=true
		this.Hbot.style.cursor="default"
	}
	this.SetState("DISA")
}

Qtext.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		this.Disabled=false
		if (this.ReadOnly == "N") this.Htxt.readOnly = false
		this.SetState("NORM")
		this.Htxt.tabIndex=-this.Htxt.tabIndex
		if (this.CursorPointer == true) {
			this.CursorPointer=false
			this.Htxt.style.cursor="pointer"
			this.Hobj.style.cursor="pointer"
		}
		if (this.Calend == "S") {
			this.Hbot.src=GetImageAddress("icalend.gif")
			this.Hbot.disabled=false
			this.Hbot.style.cursor="pointer"
		}
	}
}

Qtext.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
	if (this.Calend == "S") this.Hbot.style.display="block"
}

Qtext.prototype.Hide=function(opt) {
	GenericDisplayCtl_Hide.call(this, opt)
	if (this.Calend == "S") this.Hbot.style.display="none"
}

Qtext.prototype.ShowErr=function(msg) {GenericDisplayCtl_ShowErr.call(this)}

Qtext.prototype.HideErr=function(msg) {GenericDisplayCtl_HideErr.call(this)}

Qtext.prototype.TestEvents = function() {
    if (this.ReadOnly == "N") {
        var wval=this.Htxt.value
    } else {
        var wval = this.Htxt.innerHTML
    }
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if ((evt.Id ==	"EQ" && evt.Valor == wval) || (evt.Id ==	"NE" && evt.Valor != wval) || (evt.Id ==	"GT" && wval > evt.Valor) || (evt.Id ==	"GE" && wval >= evt.Valor) || (evt.Id ==	"LT" && wval < evt.Valor) || (evt.Id ==	"LE" && wval <= evt.Valor)) {
			GenericDisplayCtl_SetRowOrig.call(this)
			ExecCmd(this.HostPage.Area, evt.Act)
		}
	}
}

Qtext.prototype.TestEventEnter=function() {
	if (this.Disabled == true) return
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if (evt.Id == "ENTER") ExecCmd(this.HostPage.Area, evt.Act)
	}
}

Qtext.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qtext.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qtext.prototype.OnFocus=function() {
	GenericDisplayCtl_OnFocus.call(this)
	if (this.Disabled == true) return
	if (!BrowserIE && !BrowserOP) {
		if (this.Ucase == "S") this.Htxt.value = this.Htxt.value.toUpperCase()
	}
	if (this.HostDataPanel != null && this.ReadOnly != "S") {
		this.LastState = this.Frame.GetStateId()
		this.SetState("EDIT")
	}
	if (this.Placeholder != "" && ('placeholder' in this.Htxt) == false) {
		this.Htxt.value = this.Placeholder
	}
}

Qtext.prototype.Focus=function() {
	this.Htxt.focus()
}

Qtext.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	if (this.DatactlObj.Tipo.indexOf("COMBO") > -1) {
		this.DatactlObj.IsQuerying=false;
		this.DatactlObj.OnBlur2();
		return;
	}
	GenericDisplayCtl_OnBlur.call(this)
	if (this.Disabled == true) return
	if (!BrowserIE && !BrowserOP) {
		if (this.Ucase == "S") this.Htxt.value = this.Htxt.value.toUpperCase()
	}
	if (this.HostDataPanel != null && this.ReadOnly != "S") this.SetState(this.LastState)
	if (this.Placeholder != "" && ('placeholder' in this.Htxt) == false) {
		this.Htxt.value = ""
	}
	if (this.Hcalend != null) {
		ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",CloseCalend")
	}
	this.ValidarInput()
}

Qtext.prototype.OnClick=function(id, hnod, keys, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (id.indexOf("._.BOT") > -1) {
		this.CalendClick()
		return
	}
	if (this.HostDataPanel != null) {
	    if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) return
		//this.HostDataPanel.Select("CLK", keys, wx, wy)
		this.HostDataPanel.OnClick(id, hnod, keys, wx, wy)
	}
}

Qtext.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.Select("DBL")
}

Qtext.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	var keyEnter=false
	if (wkey == 13) keyEnter=true
	if (this.HostDataPanel != null) {
	    if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) {
		    if (keyEnter == true) this.ValidarInput()
		    if (wkey == 38 || wkey == 40) this.DatactlObj.OnKeyPress(wkey, evt);
		    return
	    }
		this.HostDataPanel.Select("CLK", "")
	}
	var posi
	var posf
	if (BrowserOP) {
		if (wkey == 8 || wkey == 46 || wkey == 45) wkey = 0
		if (wkey >= 16 && wkey <= 18) wkey = 0
		if (wkey >= 35 && wkey <= 40) wkey = 0
	}
	if (this.ReadOnly == "S") return
	if (BrowserIE) {
		if (this.Mask != "") {
			var range=document.selection.createRange()
			var trange=range.duplicate()
			if (this.Multiline == "N") {
				trange.expand("textedit")
			} else {
				trange.moveToElementText(this.Htxt)
			}
			trange.setEndPoint("EndToEnd", range)
			posi=trange.text.length - range.text.length
			posf=posi + range.text.length
		}
	} else {
		if (this.Mask != "") {
			if (wkey == 0) return
			posi=this.Htxt.selectionStart
			posf=this.Htxt.selectionEnd
		}
	}
	if (this.Mask == "") {
		if (keyEnter == true) {
			this.ValidarInput()
			return
		}
		if (wkey == 0) return
		wkey=String.fromCharCode(wkey)
		var wcancel=false
		if (this.Queryfld == false) {
			if (this.DataCol.Type == "N") {
				if("0123456789.,-+".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "$") {
				if("0123456789.,-+€£$".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "D") {
				if("0123456789/- :".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "H") {
				if("0123456789/- :APM".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "A") {
				//if("[]{}".indexOf(wkey) > -1) wcancel=true
			}
			if (this.DataCol.Type == "T") {
				if("0123456789:".indexOf(wkey) == -1) wcancel=true
			}
		} else {
			if (this.DataCol.Type == "N") {
				if("0123456789.,-+=!<>".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "$") {
				if("0123456789.,-+€£$=!<>".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "D" || this.DataCol.Type == "H") {
				if("0123456789/- :=!<>".indexOf(wkey) == -1) wcancel=true
			}
			if (this.DataCol.Type == "A") {
				//if("[]{}'\";".indexOf(wkey) > -1) wcancel=true
			}
			if (this.DataCol.Type == "T") {
				if("0123456789:=!<>".indexOf(wkey) == -1) wcancel=true
			}
		}
		if (wcancel == true) {
			if (BrowserIE || BrowserOP) {
				window.event.returnValue=false
			} else {
				evt.preventDefault()
			}
		} else {
			if (this.Ucase == "S") {
				wkey=wkey.toUpperCase()
				if (BrowserIE) window.event.keyCode = wkey.charCodeAt(0)
			}
		}
		return
	}
	var texto=this.Htxt.value
	var mask=this.Mask
	var sellen=posf-posi+1
	var txtin=String.fromCharCode(wkey)
	if (texto.length > posi) {
		texto=texto.substr(0,posi) + txtin + "                       ".substr(0,sellen-1) + texto.substr(posi + sellen)
	} else {
		texto += txtin
	}
	var r = FormatMask(texto, mask, posi)
	if (BrowserIE) {
		window.event.returnValue=false
		this.Htxt.value=r.Texto
		var range=this.Htxt.createTextRange()
		range.collapse(true)
		range.moveStart("character",r.Posi)
		range.select()
	} else {
		if (wkey == 8 || wkey == 9 || wkey == 46 || wkey == 45) wkey = 0
		if (wkey >= 16 && wkey <= 18) wkey = 0
		if (wkey >= 35 && wkey <= 40) wkey = 0
		if (wkey != 0) evt.preventDefault()
		this.Htxt.value=r.Texto
		this.Htxt.selectionStart=r.Posi
		this.Htxt.selectionEnd=r.Posi
	}
}

Qtext.prototype.OnKeyUp=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	var posi
	var posf
	if (this.DatactlObj.Tipo.indexOf("COMBO") > -1) {
		if (wkey != 38 && wkey != 40) this.ValidarInput(); //immediate input when in a COMBO
		return
	}
	if (this.Hcalend != null) this.Hcalend.Execute("CLOSE")
	if (wkey == 13) {
		this.TestEventEnter()
		return
	}
	if (wkey != 8 && wkey != 46) return
	if (this.ReadOnly == "S") return
	if (this.Mask == "") return
	if (BrowserIE) {
		var range=document.selection.createRange()
		var trange=range.duplicate()
		if (this.Multiline == "N") {
			trange.expand("textedit")
		} else {
			trange.moveToElementText(this.Htxt)
		}
		trange.setEndPoint("EndToEnd", range)
		posi=trange.text.length - range.text.length
		posf=posi + range.text.length
	} else {
		posi=this.Htxt.selectionStart
		posf=this.Htxt.selectionEnd
	}
	var texto=this.Htxt.value
	var mask=this.Mask
	var sellen=posf-posi+1
	var posinew=posi
	if (wkey == 8) {
		if (texto.length > posi) {
			texto=texto.substr(0,posi) + "_" + texto.substr(posi)
		}
	}
	if (wkey == 46) {
		if (texto.length > posi) {
			texto=texto.substr(0,posi) + "_" + "                       ".substr(0,sellen-1) + texto.substr(posi + sellen-1)
		}
	}
	var r = FormatMask(texto, this.Mask, posi)
	this.Htxt.value= r.Texto
	if (BrowserIE || BrowserOP) {
		var range=this.Htxt.createTextRange()
		range.collapse(true)
		range.moveStart("character",posinew)
		range.select()
	} else {
		this.Htxt.selectionStart=posinew
		this.Htxt.selectionEnd=posinew
	}
}

Qtext.prototype.OnKeyDown=function(wkey, evt) {
	if (this.DatactlObj.Tipo.indexOf("COMBO") > -1) {
		if (wkey == 38 || wkey == 40 || wkey == 13 || wkey == 27) {
			this.DatactlObj.OnKeyDown(wkey, evt);
		}
		if (wkey == 46) {
			if (this.Htxt.value == "") this.DatactlObj.OnKeyDown(wkey, evt);
		}
	}
}

Qtext.prototype.OnPaste=function(event) {
	if (AllInputBlocked == true) return
	//if (this.Mask != "" || this.Disabled == true) {   FHC 2018/01/22 não deixava fazer paste quando havia mascara
	if (this.Disabled == true) {
		if (BrowserIE || BrowserOP) {
			event.returnValue=false
		} else {
			event.preventDefault()
		}
		return
	}
}

Qtext.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qtext.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qtext.prototype.OnMouseDown=function(id, hnod, wx, wy) {GenericDisplayCtl_OnMouseDown.call(this, id, hnod, wx, wy)}
Qtext.prototype.OnMouseUp=function(id, hnod, wx, wy) {GenericDisplayCtl_OnMouseUp.call(this, id, hnod, wx, wy)}

Qtext.prototype.OnContext=function(id, hnod, wx, wy) {
	GenericDisplayCtl_OnContext.call(this, id, hnod, wx, wy)
}

Qtext.prototype.ValidarInput=function() {
	if (this.HostDataPanel != null) this.HostDataPanel.SetCurrentRow()
	if (this.ReadOnly == "N") {
		var valor=this.Htxt.value
	} else {
		var valor=this.Htxt.innerHTML
	}
	//var re=/[\[\{\}\]]/g   //retirar todos os [ ] { }
	//valor=valor.replace(re,"")
	if (this.Mask != "") {
		r=FormatMask("", this.Mask, 0)
		if (r.Texto == valor) valor=""
	}
	if (this.ReadOnly == "S") return
	if (this.Queryfld == true) {
		this.DatactlObj.StoreVal(this.Datafld, valor, this)
		return
	}
	var msg=""
	if (this.DataCol.Type == "A") msg=ValidarAlfa(this.DataCol, valor)
	if (this.DataCol.Type == "N") {
		valor=ConvertNumeroToSrv(valor)
		msg=ValidarNumber(this.DataCol, valor)
	}
	if (this.DataCol.Type == "$") {
		valor=ConvertNumeroToSrv(valor)
		msg=ValidarDinheiro(this.DataCol, valor)
	}
	if (this.DataCol.Type == "D") {
		valor=ConvertDataToSrv(valor)
		msg=ValidarDate(this.DataCol, valor)
	}
	if (this.DataCol.Type == "H") {
		valor=ConvertDataHToSrv(valor)
		msg=ValidarDate(this.DataCol, valor)
	}
	if (this.DataCol.Type == "T") {
		valor=ConvertHoraToSrv(valor)
		msg=ValidarTime(this.DataCol, valor)
	}
	if (this.DataCol.Type == "B") {
		valor=ConvertBooleanToSrv(valor)
		msg=ValidarBoolean(this.DataCol, valor)
	}
	if (msg != "") {
		this.ShowErr(msg)
		window.alert(msg)
	} else {
		this.HideErr()
		if (this.DataCol.Type == "N") {
			valor=FormatNumber(valor, this.DataCol.Dec, "server")
			this.Htxt.value=FormatNumber(valor, this.DataCol.Dec, "user")
		}
		if (this.DataCol.Type == "$") {
			valor=FormatNumber(valor, this.DataCol.Dec, "server")
			this.Htxt.value=FormatDinheiro(valor, this.DataCol.Dec, "user")
		}
		if (this.DataCol.Type == "D") {
			var wdate=ConvertToDate(valor)
			valor=FormatFromDate(wdate, "server")
			this.Htxt.value=FormatFromDate(wdate, "user")
		}
		if (this.DataCol.Type == "H") {
			var wdate=ConvertToDate(valor)
			valor=FormatFromDateH(wdate, "server")
			this.Htxt.value=FormatFromDateH(wdate, "user")
		}
		if (this.Datactl != "" && this.ReadOnly != "S") this.DatactlObj.StoreVal(this.Datafld, valor, this)
		this.TestEvents()
	}
}

Qtext.prototype.CalendClick=function() {
	if (AllInputBlocked == true) return
	if (this.Hcalend != null) {
		this.Hcalend.Execute("CLOSE")
		return
	}
	this.Hcalend = new Qcalend(null, this.HostPage, this.HostPanel, this)
	this.Hcalend.Activate("INIT")
	this.Focus()
}



//***************************************************************** QCOMBO - define Combobox
function Qcombo(xnod, hostpage, hostpanel, datacol, readonly, list) {
	this.Tipo="COMBO"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Grpctls=new Array()
	this.Actls=new Array()
	this.Dados=new Array()
	this.SelectedKeys=new Array()
	this.OldSelectedKeys=new Array();
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
	this.Value = ""
	this.ValKey = null
	this.Events=new Array()
	this.IsScrolling=false
	this.Tipo4Style=this.Tipo
	this.InitialFocus="N"
	this.Obrig=false
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Combo" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=null
	if (this.Datactl != "") {
		this.DatactlObj=hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "COMBO (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
	}
	this.Datafld = GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
	    this.DataCol = this.DatactlObj.GetCol(this.Datafld)
	} else {
	    this.DataCol = new Qcol(null, this.Datafld, "A", "255")
	}
	if (this.DataCol.Obrig == "S" || this.DatactlObj.Obrig == "S") this.Obrig=true
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.Location=GetAtt(xnod, "LOCATION", "0,0")
	this.Size=GetAtt(xnod, "SIZE", "0,0")
	var wvals=GetAtt(xnod, "VAL", "")
	this.ReadOnly=GetAtt(xnod, "READONLY", "N")
	this.InitialFocus=GetAtt(xnod, "FOCUS", "N")
	if (this.InitialFocus == "S") this.HostPage.InitialFocusSet=true

	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	var wdiv=CreateDiv(this.HostPanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.Tipo4Style=hostpanel.Tipo + "." + this.Tipo4Style
	this.StyleObj=App.GetStyle(this.Style, this.Tipo4Style)
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=1
	if (this.Tip != "") wdiv.title=this.Tip
	var wtxt=CreateDiv(wdiv, this.Hid + "._.TXT", this.Locsize.MargL + 1, this.Locsize.MargT + 2, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0px"
	wtxt.style.cursor="pointer"
	SetUnselectable(wtxt)
	this.Hobj.appendChild(wtxt)
	this.Htxt=wtxt
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) this.Hobj.tabIndex=this.Hobj.tabIndex+100
	this.SetState("NORM")
	this.Cols=new Array()
	var wcol=new Qcol(null, "Chave", "A", "255")
	wcol.Key="S"
	this.Cols.push(wcol)
	var wcol=new Qcol(null, "Valor", "A", "255")
	wcol.Larg=this.Locsize.ObjW -25
	wcol.Vis="S"
	this.Cols.push(wcol)
	wcol.Index=1
	//if (wvals.indexOf("]") != -1) wvals=SubstVars(this.HostPage.Area, wvals)
	//substituir #_ano#
	if (wvals.indexOf("#_ano") > -1) {
		var re=/#_ano#4#/g
		wvals=wvals.replace(re, User.Ano)
		var re=/#_ano1#4#/g
		wvals=wvals.replace(re, User.Ano + 1)
		var re=/#_ano2#4#/g
		wvals=wvals.replace(re, User.Ano + 2)
		var re=/#_ano_1#4#/g
		wvals=wvals.replace(re, User.Ano - 1)
		var re=/#_ano_2#4#/g
		wvals=wvals.replace(re, User.Ano - 2)
		var re=/#_ano_3#4#/g
		wvals=wvals.replace(re, User.Ano - 3)
		var re=/#_ano_4#4#/g
		wvals=wvals.replace(re, User.Ano - 4)
		var re=/#_ano_5#4#/g
		wvals=wvals.replace(re, User.Ano - 5)
	}
	this.Val=wvals
	this.ContextPanel=null
	if (wvals.indexOf("]") == -1) this.SetOpt()

	wdiv.onblur=EvtBlur
	wdiv.onfocus=EvtFocus
	wdiv.onclick=EvtClick
	wdiv.ondoubleclick=EvtDblClick
	wdiv.onkeydown=EvtKeyDown
	this.Disabled=false
	if (this.Prot == "S") this.Disable("PROT")
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Datactl != "") this.DatactlKey=this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Activated=false
}

Qcombo.prototype.SetOpt=function() {  //Carregar os valores das opções
	if (this.Val.indexOf("]") != -1) this.Val=SubstVars(this.HostPage.Area, this.Val)
	var primeirakey=null
	var Avals=this.Val.split("{")
	for (var v=0; v<Avals.length; v++) {
		var wrec=Avals[v].split("[")
		if (wrec.length == 1) wrec[1]=wrec[0]  // para os casos em que não se especifica a chave e o valor - por o valor igual à chave
		var Rec=new Qrecord(this.Cols, wrec)
		if (primeirakey == null) primeirakey=Rec.Key
		this.Dados.push(Rec)
	}
	this.DadosIni=this.Dados;
	this.Paginas.push(primeirakey)
	this.PagIndex=0
	this.Val=""
}

Qcombo.prototype.SetFilter=function(filtro) {  //Selecionar registos por filtro
	filtro=filtro.toUpperCase();
	this.Dados=new Array()
	var primeirakey = null
	for (var i=0; i<this.DadosIni.length; i++) {
		var rec=this.DadosIni[i];
		var wval=rec.Fields[1].Val.toUpperCase();
		if (filtro == "" || (filtro != "" && wval.indexOf(filtro) > -1)) {
			this.Dados.push(rec);
			if (primeirakey == null) primeirakey = rec.Key
		}
	}
	this.Paginas = new Array()
    this.Paginas.push(primeirakey)
    this.PagIndex = 0
    this.SetDropHeight();
    this.SelectedKeys=new Array();
    this.SelectedKeys.push(primeirakey);

    //this.SetVal(primeirakey, "JUSTSAVE");
    this.Grpctls[0].SetVal(null);
}

Qcombo.prototype.StoreVal = function(fld, valor, ctl, opt) {
	this.SetFilter(valor);
	//this.Grpctls[0].SetVal();
}

Qcombo.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qcombo.prototype.Activate2=function(opt) {
	if (this.InitialFocus == "S") this.Focus()
}

Qcombo.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qcombo.prototype.SetState=function(st) {
	if ((st == "NORM" || st == "HIGH" || st == "SELE") && this.Obrig == true) st="OBRI"
	if (this.HostDataPanel == null) {
		if (st == "HIGH" || st == "SELE") return
	}
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qcombo.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	var Rec = ctl.HostDataPanel.Record
	var Field = Rec.Fields[ix]
	Field.ColCtls.push(ctl)
}

Qcombo.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qcombo.prototype.GetCol=function(colid) {
	if (colid == "filler")  return new Qcol(null, "filler", "A", 1);
	if (colid == "$selected")  return new Qcol(null, "$selected", "B", 1);
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
	return null
}

Qcombo.prototype.SetVal = function(key, cmd) {
    if (this.Val != "") this.SetOpt()
    this.ValKey = key
    var encontrou = false
    for (var i = 0; i < this.Dados.length; i++) {
        if (this.Dados[i].Key == key && this.Dados[i].Key != "") {
            encontrou = true
            break
        }
    }
    this.SelectedKeys = new Array()
    if (encontrou == false) {
        this.Htxt.innerHTML = ""
        if (this.Datactl != "" && this.Disabled == false && (cmd == "SAVE" || cmd == "JUSTSAVE")) {
	        this.DatactlObj.StoreVal(this.Datafld, "", this)
	    }
        return
    }
    this.SelectedKeys.push(key)
    if (cmd == "JUSTSAVE") {
    	this.Grpctls[0].SetVal(null);
    	return;
    } else {
    	this.Execute("CLK");
    }
    if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") {
        this.DatactlObj.StoreVal(this.Datafld, key, this)
        this.OldSelectedKeys[0]=key;
    }
    this.TestEvents()
}

Qcombo.prototype.GetVal = function(opt) {
    if (this.SelectedKeys.length > 0) {
        if (opt == "VAL") {
            return this.Value
        } else {
            return this.SelectedKeys[0]
        }
    } else {
        return ""
    }
}

Qcombo.prototype.Unselect=function() {
	if (this.SelectedIndex != -1) {
		var wlin=document.getElementById(this.Hid + "._.L" + this.SelectedIndex)
		wlin.style.backgroundColor="transparent"
	}
	this.SelectedIndex=-1
	if (this.Datactl != "") this.DatactlObj.StoreVal(this.Datafld, "", this)
	this.TestEvents()
	this.Hobj.value=""
	this.Hopt.style.display="none"
}

Qcombo.prototype.SetList = function(list) {
    var re = /\|/g
    var wlist = list.replace(re, "{")
    var re = /;/g
    wlist = wlist.replace(re, "[")
    this.Dados = new Array()
    var primeirakey = null
    var Avals = wlist.split("{")
    for (var v = 0; v < Avals.length; v++) {
    	var wrec=Avals[v].split("[")
		if (wrec.length == 1) wrec[1]=wrec[0]  // para os casos em que não se especifica a chave e o valor - por o valor igual à chave
		var Rec=new Qrecord(this.Cols, wrec)
        if (primeirakey == null) primeirakey = Rec.Key
        this.Dados.push(Rec)
    }
    this.DadosIni=this.Dados;
    this.Paginas = new Array()
    this.Paginas.push(primeirakey)
    this.PagIndex = 0
    if (this.ValKey != null) this.SetVal(this.ValKey, "SAVE")
    this.TestEvents()
}

Qcombo.prototype.Execute = function(act) {
    if (act == "CLK") {
        var wsep = ";"
        this.Value = ""
        this.ValKey = ""
        this.OldSelectedKeys[0]=this.SelectedKeys[0];
        for (var k = 0; k < this.SelectedKeys.length; k++) {
            for (var i = 0; i < this.Dados.length; i++) {
                if (this.Dados[i].Key == this.SelectedKeys[k]) {
                    if (this.Value != "") {
                        this.Value += wsep
                        this.ValKey += wsep
                    }
                    this.Value += this.Dados[i].Fields[1].Val
                    this.ValKey += this.SelectedKeys[k]
                }
            }
        }
        this.Htxt.innerHTML = this.Value
        if (this.HostDataPanel != null) this.HostDataPanel.SetCurrentRow()
        if (this.Datactl != "" && this.Disabled == false) {
            this.DatactlObj.StoreVal(this.Datafld, this.SelectedKeys[0], this)
        }
        if (this.ContextPanel != null) this.HideList()
        this.TestEvents()
        return
    }
    if (act == "HideList") {
        if (this.ContextPanel != null) this.HideList()
        return
    }
    if (act == "Blur") {
        this.OnBlur2()
        return
    }
}

Qcombo.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	if (this.Disabled == true) this.Htxt.style.cursor="default"
}

Qcombo.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) this.Htxt.style.cursor="pointer"
}

Qcombo.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qcombo.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qcombo.prototype.ShowErr=function(msg) {GenericDisplayCtl_ShowErr.call(this, msg)}

Qcombo.prototype.HideErr=function(msg) {GenericDisplayCtl_HideErr.call(this)}

Qcombo.prototype.TestEvents=function() {
	var wval=""
	if (this.SelectedKeys.length > 0) wval=this.SelectedKeys[0]
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if ((evt.Id ==	"EQ" && evt.Valor == wval) || (evt.Id == "NE" && evt.Valor != wval) || (evt.Id ==	"GT" && wval > evt.Valor) || (evt.Id ==	"GE" && wval >= evt.Valor) || (evt.Id == "LT" && wval < evt.Valor) || (evt.Id == "LE" && wval <= evt.Valor)) {
			GenericDisplayCtl_SetRowOrig.call(this)
			ExecCmd(this.HostPage.Area, evt.Act)
		}
		if (evt.Id == "NOLIST") {
            if (this.Dados.length == 0 || (this.Dados.length == 1 && this.Dados[0].Key == wval)) {
            	GenericDisplayCtl_SetRowOrig.call(this)
            	ExecCmd(this.HostPage.Area, evt.Act)
            }
        }
	}
}

Qcombo.prototype.ShowList=function() {
	var offset=GetOffsetFor("APP", this.HostPanel)
	var xstr="<PANEL STYLE=\"" + this.Style + "\" LOCATION=\"" + (this.Locsize.ObjL - this.HostPage.Locsize.MargL + offset.Left) + "," + (this.Locsize.ObjT - this.HostPage.Locsize.MargT + this.Locsize.ObjH + offset.Top) + "\" SIZE=\"" + this.Locsize.ObjW + ",80\">"
	xstr +=  "  <MULTIGRID ID=\"" + this.Id + "MULTIGRID\" DATACTL=\"" + this.Id + "\" LOCATION=\"0,0\" SIZE=\"*,*\" AUTOCOLRESIZE=\"S\">"
	xstr +=  "    <HEADERPANEL SIZE=\"0,21\" AUTOLAYOUT=\"QRY\" AUTOSCROLL=\"S\"/>"
	xstr +=  "    <DATAPANEL AUTOLAYOUT=\"DET\" SIZE=\"0,21\"/>"
	xstr +=  "  </MULTIGRID>"
	xstr +=  "</PANEL>"
	var xnod=CreateXnode(xstr)
	this.ContextPanel = new Qitempanel(xnod, this.HostPage, App, this, "COMBO.DROPPANEL", null, null, 50, 50, 300, 400)
	this.ContextPanel.Hobj.style.zIndex=10
	this.SetDropHeight();
	this.ContextPanel.Activate()
	this.Actls.push(this.ContextPanel)
	this.Grpctls[0].SetVal()
}

Qcombo.prototype.SetDropHeight=function() {
	var offset=GetOffsetFor("APP", this.HostPanel)
	var altgrid=this.Grpctls[0].GetHeightFor(this.Dados.length, offset.ParentObj.Locsize.ObjH - offset.Top - this.Locsize.ObjT - this.Locsize.ObjH-10, offset.Top)
	var direction="down"
	if (altgrid < 0) {
		altgrid = -altgrid
		direction="up"
	}
	altgrid = altgrid + this.ContextPanel.Locsize.MargT + this.ContextPanel.Locsize.MargB
	//ver se é preciso fazer scrolling
	var wscroll=this.Grpctls[0].NeedScrolling(this.Dados.length, altgrid)
	if (wscroll == true) {
		this.Grpctls[0].Gcols[0].Larg=this.Locsize.ObjW -25
	} else {
		this.Grpctls[0].Gcols[0].Larg=this.Locsize.ObjW //-8
	}
	this.ContextPanel.SetSize(this.Locsize.ObjW + "," +  altgrid)
	if (direction == "up") this.ContextPanel.SetLocation((this.Locsize.ObjL - this.HostPage.Locsize.MargL + offset.Left) + "," + (offset.Top - altgrid - this.HostPage.Locsize.MargT + this.Locsize.ObjT))
	this.ContextPanel.Resize()
}

Qcombo.prototype.HideList=function() {
	this.ContextPanel.Destroy()
	this.ContextPanel=null
	this.Actls=new Array()
	this.Grpctls=new Array()
	this.Dados=this.DadosIni;
	var primeirakey=this.Dados[0].Key;
	this.Paginas = new Array()
    this.Paginas.push(primeirakey)
    this.PagIndex = 0
    this.SelectedKeys=new Array();
    if (this.OldSelectedKeys.length == 1) this.SelectedKeys.push(this.OldSelectedKeys[0]);
    this.Hobj.focus();
}

Qcombo.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qcombo.prototype.Destroy2=function() {
	if (this.DatactlKey != undefined) this.DatactlObj.DestroyUnit(this.DatactlKey)
	GenericDisplayCtl_Destroy2.call(this)
	this.Hobj=null
	this.Hopt=null
}

Qcombo.prototype.OnClick=function(id, hnod, keys, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") == -1) this.HostDataPanel.OnClick(id, hnod, keys, wx, wy)  //this.HostDataPanel.Select("CLK", keys)
	}
	if (this.Disabled == true || this.ReadOnly == "S") return
	this.Hobj.focus()
	if (this.ContextPanel == null) {
		this.ShowList()
	} else {
		this.Grpctls[0].FocusOnChild == false
		this.HideList()
	}
}

Qcombo.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.Select("DBL")
}

Qcombo.prototype.OnFocus=function() {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnFocus.call(this)
	if (this.Disabled == true) return
	if (this.HostDataPanel != null && this.ReadOnly != "S") {
		this.LastState = this.Frame.GetStateId()
		this.SetState("EDIT")
	}
}

Qcombo.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",Blur")  //esperar um pouco para ver se foi clique na scrollbar etc...
}

Qcombo.prototype.OnBlur2=function() {
	if (this.IsScrolling == true) {
		this.IsScrolling=false
		this.Hobj.focus()
		return
	}
	if (this.IsQuerying == true) {
		this.IsQuerying=false
		return
	}
	GenericDisplayCtl_OnBlur.call(this)
	if (this.ContextPanel != null) ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",HideList")
	if (this.Disabled == true) return
	if (this.HostDataPanel != null && this.ReadOnly != "S") this.SetState(this.LastState)
}

Qcombo.prototype.Focus=function() {GenericDisplayCtl_Focus.call(this)}

Qcombo.prototype.OnKeyDown=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	var keyused = false     //determinar se foi usada uma tecla útil
	var saveopt="SAVE";
	if (this.ContextPanel != null) saveopt="JUSTSAVE";
	if (wkey == 39 || wkey == 40) {  //proximo   39=direita  40=baixo
		keyused=true
		if (this.Dados.length > 0) {
			if (this.SelectedKeys.length == 0) {
				this.SetVal(this.Dados[0].Key, saveopt)
			} else {
				for (var i=0; i<this.Dados.length; i++) {
					if (this.SelectedKeys[0] == this.Dados[i].Key) {
						if ((i+1) < this.Dados.length) {
							this.SetVal(this.Dados[i+1].Key, saveopt)
							break
						}
					}
				}
			}
		} else {
			this.SetVal("", "SAVE")
		}
	} else {
		if (wkey == 37 || wkey == 38) {  //anterior
			keyused=true
			if (this.Dados.length > 0) {
				if (this.SelectedKeys.length == 0) {
					this.SetVal(this.Dados[this.Dados.length-1].Key, saveopt)
				} else {
					for (var i=0; i<this.Dados.length; i++) {
						if (this.SelectedKeys[0] == this.Dados[i].Key) {
							if (i > 0) {
								this.SetVal(this.Dados[i-1].Key, saveopt)
								break
							}
						}
					}
				}
			} else {
				this.SetVal("", saveopt)
			}
		} else {
			if (wkey == 46) {  //delete key
				if (this.Obrig == false) {  //se o campo é obrigatorio não deixa usar a Delete Key
					this.SetVal("", "SAVE")
					if (this.ContextPanel != null) this.HideList()
				}
			}
			if (wkey == 13 || wkey == 32) {  //Enter ou Space
				if (this.ContextPanel == null) {
					this.ShowList();
				} else {
					this.Execute("CLK");
					if (this.ContextPanel != null) this.HideList();
				}
				if (BrowserIE || BrowserOP) {
					window.event.returnValue=false
				} else {
					evt.preventDefault()
				}
			}
			if (wkey == 27) {  // escape key
				if (this.ContextPanel != null) this.HideList();
			}
		}
	}
	if (keyused == true) {  //se foi uma tecla já tratada impedir que o browser interprete mais esta tecla
        if (BrowserIE) {
            window.event.returnValue = false;
        } else {
            evt.preventDefault();
        }
    }
}

Qcombo.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qcombo.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qcombo.prototype.OnMouseDown=function(id, hnod, wx, wy) {GenericDisplayCtl_OnMouseDown.call(this, id, hnod, wx, wy)}
Qcombo.prototype.OnMouseUp=function(id, hnod, wx, wy) {GenericDisplayCtl_OnMouseUp.call(this, id, hnod, wx, wy)}


//***************************************************************** QCHECK - define Checkbox
function Qcheck(xnod, hostpage, hostpanel) {
	this.Tipo="CHECK"
	this.Class="DISPLAY"
	this.Tipo4Style=this.Tipo
	this.Tipo4Style=hostpanel.Tipo + "." + this.Tipo4Style
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Keys=new Array()
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.ReadOnly=GetAtt(xnod, "READONLY", "N")
	this.Hobj.style.cursor="pointer"
	var wvals=GetAtt(xnod, "VAL", "1{0")
	this.Keys=wvals.split("{")
	this.Val=false
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) this.Hobj.tabIndex=this.Hobj.tabIndex+100
	this.Hobj.onclick=EvtClick
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.onkeydown=EvtKeyDown
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Datactl != "") {
		this.DatactlObj.AddFieldCtl(this.Datafld, this)
		if (this.DatactlObj.Tipo == "LEDIT") {
			this.Prot="S"
			this.Disable("PROT")
		}
	}
}

Qcheck.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qcheck.prototype.Activate2=function(opt) {
	if (this.InitialFocus == "S") this.Focus()
}

Qcheck.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qcheck.prototype.SetState=function(st) {
	if (st == "SELE") return
	if (this.Disabled == true) {
		if (st == "NORM") st="DISA"
	}
	if (this.Val == true) {
		st = st + "1"
	} else {
		st = st + "0"
	}
	GenericDisplayCtl_SetState.call(this, st)
}

Qcheck.prototype.SetVal=function(valor, internal) {
	if (valor == this.Keys[0]) {
		this.Val=true
	} else {
		this.Val=false
	}
	if (this.HostDataPanel != null) this.HostDataPanel.SetCurrentRow()
	this.SetState("NORM")
	if (this.Datactl != "" && this.Disabled == false && internal != true) {
		this.DatactlObj.StoreVal(this.Datafld, valor, this)
	}
	this.TestEvents()
}

Qcheck.prototype.GetVal=function() {
	if (this.Val == true) {
		return this.Keys[0]
	} else {
		return this.Keys[1]
	}
}

Qcheck.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qcheck.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qcheck.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qcheck.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qcheck.prototype.ShowErr=function(msg) {
	this.Hobj.style.backgroundColor="#FF0000"
	this.Hobj.title=msg
}

Qcheck.prototype.HideErr=function(msg) {
	this.Hobj.style.backgroundColor=this.Bgcolor
	this.Hobj.title=this.Tip
}

Qcheck.prototype.TestEvents=function() {
	if (this.Val == true) {
		var wval = this.Keys[0]
	} else {
		var wval = this.Keys[1]
	}
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if ((evt.Id ==	"EQ" && evt.Valor == wval) || (evt.Id ==	"NE" && evt.Valor != wval) || (evt.Id ==	"GT" && wval > evt.Valor) || (evt.Id ==	"GE" && wval >= evt.Valor) || (evt.Id ==	"LT" && wval < evt.Valor) || (evt.Id ==	"LE" && wval <= evt.Valor)) {
			GenericDisplayCtl_SetRowOrig.call(this)
			ExecCmd(this.HostPage.Area, evt.Act)
		}
	}
}

Qcheck.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qcheck.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	this.SetState("HIGH")
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
}

Qcheck.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	this.SetState("NORM")
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qcheck.prototype.OnClick=function(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel != null) {
		this.HostDataPanel.SetCurrentRow()
		this.HostDataPanel.Select("CLK", keys)
	}
	if (this.ReadOnly == "S") return
	if (this.Val == true) {
		this.Val=false
		if (this.DatactlObj != null) this.DatactlObj.StoreVal(this.Datafld, this.Keys[1], this)
	} else {
		this.Val=true
		if (this.DatactlObj != null) this.DatactlObj.StoreVal(this.Datafld, this.Keys[0], this)
	}
	this.SetState("NORM")
	this.TestEvents()
	//this.Hobj.focus()
}

Qcheck.prototype.OnKeyDown=function(wkey) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	if (wkey == 13 || wkey == 32) {  //Enter ou space bar
		this.OnClick()
	}
}

Qcheck.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qcheck.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}

Qcheck.prototype.Focus=function() {GenericDisplayCtl_Focus.call(this)}

Qcheck.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qcheck.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}


//***************************************************************** QRADIO - define RadioButton
function Qradio(xnod, hostpage, hostpanel) {
	this.Tipo="RADIO"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Radio" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Keys=new Array()
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=null
	if (this.Datactl != "") {
		this.DatactlObj=hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "RADIO (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
	}
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.Events=new Array()
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.Actls=new Array()
	this.SelectedIndex=-1
	this.Locsize=new QlocSize("0,0", "5,5", hostpanel)  //apenas para compatibilidade com outros controlos
	this.Locsize.Resizable=true
	this.Disabled=false
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "RADBOT") {
			var wctl=new Qradbot(xn, hostpage, this, hostpanel)
			this.Actls.push(wctl)
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	if (this.Prot == "S") this.Disable("PROT")
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.Val=this.Keys[0]
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Activated=false
}

Qradio.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qradio.prototype.Activate2=function(opt) {}

Qradio.prototype.Resize=function() {
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Locsize.Resizable == true) this.Actls[i].Resize()
	}
}

Qradio.prototype.SetVal=function(valor, fromchild) {
	for (var i=0; i<this.Actls.length; i++) {
		var bot=this.Actls[i]
		if (bot.Val == valor) {
			bot.SetVal(1)
		} else {
			bot.SetVal(0)
		}
	}
	if (this.Datactl != "" && this.Disabled == false && fromchild == true) {
		this.DatactlObj.StoreVal(this.Datafld, valor, this)
	}
	this.TestEvents()
}

Qradio.prototype.GetVal=function() {
	return this.Val
}

Qradio.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	this.Disabled=true
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Disable(tipo)
	}
}

Qradio.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		this.Disabled=false
		for (var i=0; i<this.Actls.length; i++) {
			this.Actls[i].Enable(tipo)
		}
	}
}


Qradio.prototype.Show=function(opt) {
	if (this.Activated == false) {
		this.Activate()
		return
	}
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Show()
	}
	this.Visible=true
}

Qradio.prototype.Hide=function(opt) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Hide(opt)
	}
	this.Visible=false
}

Qradio.prototype.ShowErr=function(msg) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].ShowErr(msg)
	}
}

Qradio.prototype.HideErr=function() {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].HideErr()
	}
}

Qradio.prototype.TestEvents=function() {
	var wval=this.Val
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if ((evt.Id == "EQ" && evt.Valor == wval) || (evt.Id ==	"NE" && evt.Valor != wval) || (evt.Id == "GT" && wval > evt.Valor) || (evt.Id == "GE" && wval >= evt.Valor) || (evt.Id == "LT" && wval < evt.Valor) || (evt.Id == "LE" && wval <= evt.Valor)) {
			GenericDisplayCtl_SetRowOrig.call(this)
			ExecCmd(this.HostPage.Area, evt.Act)
		}
	}
}

Qradio.prototype.OnClick=function(id) {
	var Aw=id.split(".")
	var ix=Number(Aw[3])
	this.Actls[ix].OnClick()
}

Qradio.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";
	for (var i=0; i<this.Actls.length; i++) {
		//if (BrowserIE || BrowserOP) this.Actls[i].Destroy(opt)
		this.Actls[i].Destroy(opt);
	}
	this.Actls=null
}


//***************************************************************** QRADBOT - define radio button
function Qradbot(xnod, hostpage, parentobj, hostpanel) {
	this.Tipo="RADBOT"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel, parentobj)
	this.Val=GetAtt(xnod, "VAL", "")
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Selected=false
	this.Hobj.style.cursor="pointer"
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) this.Hobj.tabIndex=this.Hobj.tabIndex+100
	this.Hobj.alt=this.Tip
	this.SetState("NORM")
	this.Hobj.onclick=EvtClick
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.onkeydown=EvtKeyDown
}

Qradbot.prototype.SetState=function(st) {
	if (st == "SELE") return
	if (this.Selected == true) {
		st = st + "1"
	} else {
		st = st + "0"
	}
	if (this.ParentObj.Prot == "S") {
		if (st == "NORM0") st="DISA0"
		if (st == "NORM1") st="DISA1"
	}
	GenericDisplayCtl_SetState.call(this, st)
}

Qradbot.prototype.SetVal=function(valor) {
	if (valor == 1) {
		this.Selected=true
	} else {
		this.Selected=false
	}
	this.SetState("NORM")
}

Qradbot.prototype.GetVal=function() {
	if (this.Selected == true) {
		return "1"
	} else {
		return "0"
	}
}

Qradbot.prototype.Activate=function() {GenericDisplayCtl_Activate.call(this)}

Qradbot.prototype.Activate2=function() {
	if (this.InitialFocus == "S") this.Focus()
}

Qradbot.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qradbot.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qradbot.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qradbot.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qradbot.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qradbot.prototype.ShowErr=function(msg) {}

Qradbot.prototype.HideErr=function() {}

Qradbot.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qradbot.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qradbot.prototype.OnClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.ParentObj.SetVal(this.Val, true)
	GenericDisplayCtl_OnClick.call(this)
}

Qradbot.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.SetState("HIGH")
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
}

Qradbot.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.SetState("NORM")
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qradbot.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qradbot.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}

Qradbot.prototype.Focus=function() {GenericDisplayCtl_Focus.call(this)}

Qradbot.prototype.OnKeyDown=function(wkey) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) {  //Enter ou space bar
		this.OnClick()
	}
}


//***************************************************************** QIMG - define Img
function Qimg(xnod, hostpage, hostpanel) {
	this.Tipo="IMG"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Act=GetAtt(xnod, "ACT", "")
	this.ActOver=GetAtt(xnod, "ACTOVER", "")
	this.MouseIsOver=false
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DefUrl=""
	this.ImgWidth=0
	this.ImgHeight=0
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
		this.DatactlObj.AddFieldCtl(this.Datafld, this)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.Src=GetAtt(xnod, "SRC", "")
	if (this.Src.indexOf("]") != -1) this.Src=SubstVars(this.HostPage.Area, this.Src)
	if (this.Src.substr(0,1) == "*") this.Src=this.Src.substr(1)
	this.Stretch=GetAtt(xnod, "STRETCH", "N")
	this.Repeat=GetAtt(xnod, "REPEAT", "N")
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Iconid=GetAtt(xnod, "ICONID", "")
	this.Upload=GetAtt(xnod, "UPLOAD", "N")
	if (this.Upload == "S") {
		this.Tip += " Use botão direito do rato para enviar foto."
	}
	this.ContextPanel=null
	if (this.DatactlObj != null) this.DefUrl=this.DatactlObj.Provider + "_" + this.DataCol.Id + "_"
	if (this.Datactl == "") {
		this.ActUrl=GetImageAddress(this.Src)
	} else {
		this.ActUrl=""
	}
	if (this.Act != "" || this.ActOver != "") {
		this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
		//if (this.HostDataPanel != null) this.Hobj.tabIndex=this.Hobj.tabIndex+100
		this.Hobj.style.cursor="pointer"
	}
	if (this.Repeat != "N") {
		var wimg=CreateDiv(this.Hobj, this.Hid + "._.IMG", this.Locsize.MargL, this.Locsize.MargT, this.Locsize.ObjW-this.Locsize.MargL-this.Locsize.MargR, this.Locsize.ObjH-this.Locsize.MargT-this.Locsize.MargB)
	} else {
		var wimg=CreateImg(this.Hobj, this.Hid + "._.IMG")
	}
	wimg.style.borderStyle = "NONE"
	wimg.style.borderWidth="0px"
	this.Himg=wimg
	if (this.Act != "") {
		this.Hobj.onclick=EvtClick
		this.Hobj.onfocus=EvtFocus
		this.Hobj.onblur=EvtBlur
	}
	if (this.ActOver != "") this.Hobj.onmouseover=EvtMouseOver
	if (this.Upload == "S") this.Hobj.oncontextmenu=EvtContext
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Repeat != "N") return

    //Dentro das callbacks de onload o 'this' representa o elemento IMG, isso significa que a instancia do objecto Qimg fica perdida.
    //Para termos ambas aqui guardamos o valor do objeto actual para podermos usar dentro do callback.
	var myself = this;
	this.Himg.onload = function () {
	    myself.OnLoadImg(this);
	};
    //Nota: caso o OnLoad não esteja a ser re-invocado no chrome quando o src muda, ler artigo:
    // http://code.google.com/p/chromium/issues/detail?id=7731

	if ( this.Src != "")
	    this.Himg.src = GetImageAddress(this.Src);

}


Qimg.prototype.Activate=function(opt) {
	this.Activated=true
	if (this.Repeat == "N") {
		if (this.Himg.src == "" && this.Src != "") this.Himg.src=GetImageAddress(this.Src)
	} else {
		this.Himg.style.backgroundImage="url(" + GetImageAddress(this.Src) + ")"
		if (this.Repeat == "S") this.Himg.style.backgroundRepeat="repeat"
		if (this.Repeat == "H") this.Himg.style.backgroundRepeat="repeat-x"
		if (this.Repeat == "V") this.Himg.style.backgroundRepeat="repeat-y"
	}
	//if (this.Visible == true) this.Show("INIT")  ** FHC 2015/09/01 substituído por causa das imagens na primeira pataleta que ficavam hidden
	if (this.Visivel == "S") this.Show("INIT")
}

Qimg.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	if (this.Stretch == "S" || this.Repeat != "N") {
		this.Himg.style.width = (this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
		this.Himg.style.height = (this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	} else {
		this.ZoomToFit()
	}
}

Qimg.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qimg.prototype.SetVal = function (valor, cmd) {

	if (valor != "" && valor != null) {
		if (valor.substr(0,1) == "*") {
			this.ActUrl=valor.substr(1)
		} else {
			this.ActUrl=valor
		}
		if (this.Iconid == "*") {  //se iconid="*" significa que o valor é para ir para o icon e não para o image source
			this.Frame.SetDynamicIcon(this.ActUrl, "NOPATH")
		} else {
			this.Himg.src = CriarLinkRecurso(this.ActUrl, this.HostPage.Modulo)
		}
	} else {
		this.ActUrl=""
		if (this.Iconid == "*") {  //se iconid="*" significa que o valor é para ir para o icon e não para o image source
			this.Frame.SetDynamicIcon("")
		} else {
			var wiurl=GetImageAddress(this.Src)
			if (wiurl== "") {
				this.Himg.src=""
			} else {
				this.Himg.src = wiurl
			}
		}
	}

	if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") this.DatactlObj.StoreVal(this.Datafld, this.ActUrl, this)
	if (this.Tip.substr(0,1) == "(") {  //o TIP com o nome de coluna entre () é para ir buscar o valor dessa coluna
		var ix=this.Tip.indexOf(")")
		if (ix > -1) {
			var wcol=this.Tip.substr(1,ix-1)
			var wtip=""
			if (this.DatactlObj != null) {
				if (this.HostDataPanel != null) {
					wtip=this.DatactlObj.GetValFromKey(wcol, this.HostDataPanel.Record.Key)
				} else {
					wtip=this.DatactlObj.GetVal(wcol)
				}
				if (wtip != "") this.Hobj.title=wtip
			}
		}
	}
}

Qimg.prototype.GetVal=function() {
	return this.ActUrl
}

Qimg.prototype.Execute=function(act, p1) {
	if (act == "REFRESH") {
		if (this.ActUrl != "") {
		    this.Himg.src = CriarLinkRecurso(this.ActUrl, this.HostPage.Modulo)
		} else {
			this.Himg.src=GetImageAddress(this.Src)
		}
		return
	}
	if (act == "Upload") {
		if (this.Disabled == true) return
		var url=this.DefUrl + this.DatactlObj.Dados[this.DatactlObj.KeyIndex] + "_" + Agora().getTime()
		//JGF 2017.05.17 Remover caracteres não permitidos
	    url = url.replace(/[\*\<\>\\\/\?\:]/g, '')
		
		url=GetServiceAddress("UPLOAD") + "?L=" + User.Language + "&F=" + url  //passou a incluir a lingua
		if (this.ContextPanel != null) {
			this.ContextPanel.Destroy()
			this.Actls=new Array()
		}
		this.ContextPanel=new Qupload(this, url)
		this.Actls.push(this.ContextPanel)
		this.ContextPanel.Activate()
		return
	}
	if (act == "EndUpload") {
        if (p1 != "") {
            var i = p1.lastIndexOf("\\")
            this.ActUrl = "temp/" + p1.substr(i + 1)
            this.DatactlObj.StoreVal(this.Datafld, this.ActUrl, this)
            this.Himg.src = this.ActUrl
        }
        else {
            this.Himg.src = GetImageAddress(this.Src)
            this.ActUrl = ""
            this.DatactlObj.StoreVal(this.Datafld, this.ActUrl, this)
        }
		return
	}
	if (act == "MouseOver") {
		if (this.MouseIsOver == false) return
		ExecCmd(this.HostPage.Area, this.ActOver)
		return
	}
}

Qimg.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qimg.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qimg.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qimg.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qimg.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qimg.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qimg.prototype.OnClick=function(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	var wact=this.Act
	if (wact == "") {
		if (this.HostDataPanel != null) this.HostDataPanel.Select("CLK", keys)
	} else {
		if (this.HostDataPanel != null) this.HostDataPanel.Select("NOSEL")
		ExecCmd(this.HostPage.Area, wact)
	}
}

Qimg.prototype.OnContext=function(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("NOCLICK")
	if (this.Disabled == true) return
	if (this.Upload == "N") return
	this.Execute("Upload")
}

Qimg.prototype.OnLoadImg = function (img) {

	if (this.Stretch == "S") {
		this.Himg.style.width = (this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
		this.Himg.style.height = (this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	} else {

	    if (img.naturalWidth) {
	        this.ImgWidth = img.naturalWidth;
	        this.ImgHeight = img.naturalHeight;
	    }
	    else { //workarround para IE8 (ainda necessario por causa dos addins)
          //http://www.jacklmoore.com/notes/naturalwidth-and-naturalheight-in-ie/
	        var imgNat = new Image();
	        imgNat.src = this.Himg.src;
	        this.ImgWidth = imgNat.width;
	        this.ImgHeight = imgNat.height;
	    }

		if (this.Stretch == "C") {  // Crop image
			this.ZoomToCrop()
		} else {
			this.ZoomToFit()
		}

	}
}

Qimg.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
	if (this.MouseIsOver == true) return
	this.MouseIsOver=true
	if (this.ActOver != "" && this.Disabled == false) ExecCmdDelayed(400, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",MouseOver")
}

Qimg.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	this.MouseIsOver=false
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qimg.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) this.OnClick()
}

Qimg.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qimg.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}

Qimg.prototype.ZoomToFit=function() {
	var divwidth=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
	var divheight=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
	var fw = divwidth / this.ImgWidth
	var fh = divheight / this.ImgHeight
	var factor=0
	if ((this.ImgHeight * fw) <= divheight) factor = fw
	if ((this.ImgWidth * fh) <= divwidth) factor = fh
	var newwidth=this.ImgWidth * factor
	var newheight=this.ImgHeight * factor
	if (newwidth < 0) newwidth = 0
	if (newheight < 0) newheight = 0
	this.Himg.style.width = newwidth + "px"
	this.Himg.style.height = newheight + "px"
	this.Himg.style.left = (this.Locsize.MargL + (divwidth - newwidth) / 2) + "px"
	this.Himg.style.top = (this.Locsize.MargT + (divheight - newheight) / 2) + "px"
}

Qimg.prototype.ZoomToCrop=function() {
	var divwidth=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
	var divheight=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
	var fw = divwidth / this.ImgWidth
	var fh = divheight / this.ImgHeight
	var factor=0
	if (fw > fh) {
		factor=fw
	} else {
		factor=fh
	}
	var newwidth=this.ImgWidth * factor
	var newheight=this.ImgHeight * factor
	if (newwidth < 0) newwidth = 0
	if (newheight < 0) newheight = 0
	this.Himg.style.width = newwidth + "px"
	this.Himg.style.height = newheight + "px"
	this.Himg.style.left = ((divwidth - newwidth) / 2) + "px"
	this.Himg.style.top = ((divheight - newheight) / 2) + "px"
}


//***************************************************************** QDOC - define Doc
function Qdoc(xnod, hostpage, hostpanel) {
	this.Tipo="DOC"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.DefUrl=""
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
		this.DatactlObj.AddFieldCtl(this.Datafld, this)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.Src=GetAtt(xnod, "SRC", "")
	if (this.Src.substr(0,1) == "*") this.Src=this.Src.substr(1)
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Upload=GetAtt(xnod, "UPLOAD", "N")
	this.ContextPanel=null
	if (this.DatactlObj != null) this.DefUrl=this.DatactlObj.Provider + "_" + this.DataCol.Id + "_"
	if (this.Datactl == "") {
		this.ActUrl=this.Src
	} else {
		this.ActUrl=""
	}
	if (this.Act != "") this.Hobj.style.cursor="pointer"
	this.Disabled=false
	this.UpdateDisabled=false
	//if (this.Prot == "S" || this.Nivseg != "") this.DisaCtl=new Qdisactl()
	if (this.Prot == "S") {
		//this.DisaCtl.Add("PROT")
		//this.Disabled=true
		this.Disable("PROT")
	}
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) this.Hobj.tabIndex=this.Hobj.tabIndex+100
	this.Hobj.onclick=EvtClick
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.oncontextmenu=EvtContext
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) {
			//this.DisaCtl.Add("NIVSEG")
			//this.Disabled=true
			this.Disable("NIVSEG")
		}
	}
	this.DocCheck()
}

Qdoc.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}
Qdoc.prototype.Activate2=function(opt) {}

Qdoc.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qdoc.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qdoc.prototype.SetVal=function(valor) {
	if (valor != "" && valor != null) {
		if (valor.substr(0,1) == "*") {
			this.ActUrl=valor.substr(1)
		} else {
			this.ActUrl=valor
		}
		this.DocCheck()
	} else {
		this.SetState("DISA")
		this.ActUrl=""
		this.DocCheck()
	}
}

Qdoc.prototype.GetVal=function() {
	return this.ActUrl
}

Qdoc.prototype.Execute=function(act, p1) {
	if (act == "REFRESH") {
		return
	}
	if (act == "Upload") {
		var url=this.DefUrl + this.DatactlObj.Dados[this.DatactlObj.KeyIndex] + "_" + Agora().getTime()
		//JGF 2017.05.17 Remover caracteres não permitidos
	    url = url.replace(/[\*\<\>\\\/\?\:]/g, '')
		url=GetServiceAddress("UPLOAD") + "?L=" + User.Language + "&F=" + url  //passou a incluir a lingua
		if (this.ContextPanel != null) {
			this.ContextPanel.Destroy()
			this.Actls=new Array()
		}
		this.ContextPanel=new Qupload(this, url)
		this.Actls.push(this.ContextPanel)
		this.ContextPanel.Activate()
		return
	}
	if (act == "EndUpload") {
		var i=p1.lastIndexOf("\\")
		this.ActUrl="temp/" + p1.substr(i+1)
		this.DatactlObj.StoreVal(this.Datafld, this.ActUrl, this)
		this.DocCheck()
		return
	}
}

Qdoc.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	this.DocCheck(true)
}

Qdoc.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) this.DocCheck(false)
}

Qdoc.prototype.DisableUpdate=function(tipo) {  //o que fazer quando em modo de visualização.
	this.UpdateDisabled=true;
}

Qdoc.prototype.EnableUpdate=function(tipo) {  //o que fazer quando em modo de visualização.
	this.UpdateDisabled=false;
}

Qdoc.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qdoc.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qdoc.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qdoc.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qdoc.prototype.DocCheck=function(prot) {
	if (prot == undefined) prot=false
	var wtip=""
	if (this.ActUrl != "") {
		//this.Hobj.src=this.Img
		if (this.Tip != "") wtip = this.Tip + "\r\n"
		wtip += "Clique no icone para abrir o documento. "
		this.Hobj.style.cursor="pointer"
		if (this.Disabled == false && this.Upload == "S" && prot == false && this.UpdateDisabled == false) wtip += "\r\nClique com o botão direito do rato para carregar documento."
	} else {
		//this.Hobj.src=this.ImgDis
		if (this.Tip != "") wtip = this.Tip + "\r\n"
		wtip += "Documento inexistente. "
		this.Hobj.style.cursor="default"
		if (this.Disabled == false && this.Upload == "S" && prot == false && this.UpdateDisabled == false) {
			wtip += "\r\nClique com o botão direito do rato para carregar documento."
			this.Hobj.style.cursor="pointer"
		}
	}
	this.Hobj.title=wtip
}

Qdoc.prototype.OnClick=function(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	//if (this.HostDataPanel != null) this.HostDataPanel.Select("CLK", keys)
	if (this.HostDataPanel != null) this.HostDataPanel.Select("NOCLICK")
	if (this.ActUrl == "") return
	window.open(CriarLinkRecurso(this.ActUrl, this.HostPage.Modulo), "_blank")
}

Qdoc.prototype.OnContext=function(id, hnod, wx, wy) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.UpdateDisabled == true) return
	if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("NOCLICK")
	this.Execute("Upload")
}

Qdoc.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
	if (this.ActUrl == "") return
	this.SetState("HIGH")
}

Qdoc.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
	if (this.ActUrl == "") return
	this.SetState("NORM")
}

Qdoc.prototype.OnMouseDown=function() {
	if (AllInputBlocked == true) return
	if (this.ActUrl == "") return
	this.SetState("SELE")
}

Qdoc.prototype.OnMouseUp=function() {
	if (AllInputBlocked == true) return
	if (this.ActUrl == "") return
	this.SetState("HIGH")
}

Qdoc.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qdoc.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}


//***************************************************************** QBOTAO - define Botao
function Qbotao(xnod, hostpage, hostpanel, tipo) {
	this.Tipo="BOTAO"
	if (tipo == "" || tipo == undefined) {
		this.Tipo="BOTAO"
	} else {
		this.Tipo=tipo
	}
	this.Class="DISPLAY"
	this.Tipo4Style=this.Tipo
	if (this.Tipo == "BOTAUX") this.Tipo4Style="BOTAO"
	if (hostpanel.Tipo.indexOf("HEADERPANEL") > -1 || hostpanel.Tipo.indexOf("FOOTERPANEL") > -1) this.Tipo4Style=hostpanel.Tipo + "." + this.Tipo4Style
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Img=GetAtt(xnod, "IMG", "")
	this.ImgDis=GetAtt(xnod, "IMGDIS", "")
	this.IconId=GetAtt(xnod, "ICONID", "")
	if (this.IconId != "") this.Frame.SetDynamicIcon(this.IconId)
	this.Txt=GetAtt(xnod, "TXT", "")
	this.Act=GetAtt(xnod, "ACT", "")
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.DatactlObj != null) this.DatactlObj.Botoes.push(this)
	if (this.Datactl != "" && this.Datafld != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
		this.DatactlObj.AddFieldCtl(this.Datafld, this)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Autorepeat=GetAtt(xnod, "AUTOREPEAT", "N")
	this.BotDelay=400
	this.Pressed=false
	this.Hobj.style.cursor="pointer"
	if (this.Tipo == "BOTAO") {
		this.Hobj.tabIndex=this.HostPage.TabIndexBase + buttontabindex
	} else {
		this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	}
	if (this.Txt != "" || this.Datafld != "") {
	    if (this.Img != "" && this.StyleObj.UseIcons == "S") {
			var wleft=this.Locsize.MargL + 18
			var wwidth=this.Locsize.ObjW - wleft - this.Locsize.MargR
		} else {
			var wleft=this.Locsize.MargL
			var wwidth=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
		}
		var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", wleft, this.Locsize.MargT, wwidth, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
		wtxt.style.backgroundColor="transparent"
		wtxt.style.borderWidth="0"
		if (this.Tipo == "LINK") {
		    wtxt.style.textAlign = GetAtt(xnod, "ALIGN", "LEFT");
		} else {
			wtxt.style.textAlign = GetAtt(xnod, "ALIGN", "CENTER");
		}
		wtxt.innerHTML = this.Txt
		SetUnselectable(wtxt)
		wtxt.style.cursor="pointer"
		if (this.Tipo.indexOf("LINK") > -1) wtxt.style.textDecoration="underline"
		this.Htxt=wtxt
	}
	this.Hobj.onclick=EvtClick
	this.Hobj.onmousedown=EvtMouseDown
	this.Hobj.onmouseup=EvtMouseUp
	this.Hobj.onmouseover=EvtMouseOver
	this.Hobj.onmouseout=EvtMouseOut
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.onkeypress=EvtKeyPress
	if (this.Act.indexOf("GET+") > -1 || this.Act.indexOf("GET-") > -1) {
		this.SetState("DISA")  //Startar os botões de paginação em Disabled
	} else {
		this.SetState("NORM")
	}
	if (User.ActAutorizado(this.HostPage.Modulo, this.Act) == false) this.Disable("AUT")
	if (this.Nivseg != "" && this.Nivseg != undefined) {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	this.Activated=false
}

Qbotao.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this, opt)}
Qbotao.prototype.Activate2=function(opt) {}

Qbotao.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	if (this.Htxt != undefined) {
	    if (this.Img != "" && this.StyleObj.UseIcons == "S") {
			var wleft=this.Locsize.MargL + 18
			var wwidth=this.Locsize.ObjW - wleft - this.Locsize.MargR
		} else {
			var wleft=this.Locsize.MargL
			var wwidth=this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR
		}
		this.Htxt.style.left=wleft + "px"
		if (wwidth < 0) wwidth=0
		this.Htxt.style.width=wwidth + "px"
		var wheight=this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB
		if (wheight < 0) wheight=0
		this.Htxt.style.height=wheight + "px"
	}
}

Qbotao.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	if (this.Htxt != undefined) this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qbotao.prototype.SetVal=function(valor) {
	if (valor != "" && valor != null) {
		if (this.Htxt != undefined) this.Htxt.innerHTML=valor
	}
}

Qbotao.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	if (this.Htxt != undefined) {
		//this.Htxt.disabled=true
		this.Htxt.style.cursor="default"
	}
}

Qbotao.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		if (this.Htxt != undefined) {
			//this.Htxt.disabled=false
			this.Htxt.style.cursor="pointer"
		}
	}
}

Qbotao.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qbotao.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qbotao.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qbotao.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qbotao.prototype.OnClick=function(internal) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (internal != true) {
		if (this.Autorepeat == "S") return
	}
	if (this.HostDataPanel != null) {
		this.HostDataPanel.SetCurrentRow()
	}
	var wact=this.Act
	if (wact == "") {
		if (this.HostDataPanel != null) this.HostDataPanel.Select("CLK", "")
	} else {
		if (this.HostDataPanel != null) this.HostDataPanel.Select("NOCLICK")
		ExecCmd(this.HostPage.Area, wact)
	}
}

Qbotao.prototype.OnMouseDown=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.Focus()
	this.SetState("SELE")
	if (this.Autorepeat == "S") {
		this.BotDelay=500
		this.Pressed=true
		this.Execute("BotPress")
	}
}

Qbotao.prototype.OnMouseUp=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.SetState("HIGH")
	this.Pressed=false
}

Qbotao.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel == null) {
		this.HostPanel.OnMouseOver(id, hnod)
	} else {
		this.HostDataPanel.OnMouseOver(id, hnod)
	}
	this.SetState("HIGH")
}

Qbotao.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.HostDataPanel == null) {
		this.HostPanel.OnMouseOut(id, hnod)
	} else {
		this.HostDataPanel.OnMouseOut(id, hnod)
	}
	this.SetState("NORM")
}

Qbotao.prototype.OnResize=function() {
	this.Locsize.ObjW=this.Temaobj.Tema.Width
	this.Locsize.ObjH=this.Temaobj.Tema.Height
	this.Resize()
}

Qbotao.prototype.Focus=function() {
	if (this.Hobj.style.display != "none") this.Hobj.focus()
}

Qbotao.prototype.OnFocus=function() {
	if (this.Tipo != "LINK") GenericDisplayCtl_OnFocus.call(this)
}

Qbotao.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}

Qbotao.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) this.OnClick(true)
}

Qbotao.prototype.Execute=function(act, opt) {
	if (act == "BotPress") {
		if (this.Pressed == false) return
		if (this.Act != "") ExecCmd(this.HostPage.Area, this.Act)
		this.BotDelay = this.BotDelay - 50
		if (this.BotDelay < 50) this.BotDelay = 50
		ExecCmdDelayed(this.BotDelay, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",BotPress")
		return
	}
}



//***************************************************************** Qacordeon - define Barra de acordeon
function Qacordeon(xnod, hostpage, hostpanel, tipo) {
	this.Tipo="ACORDEON"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Txt=GetAtt(xnod, "TXT", "")
	this.Act=GetAtt(xnod, "ACT", "")
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Panel=GetAtt(xnod, "PANEL", "")
	this.Autocollapse=GetAtt(xnod, "AUTOCOLLAPSE", "S")
	this.Selected=GetAtt(xnod, "SELECTED", "N")
	this.Hobj.style.cursor="pointer"
	if (this.Txt != "") {
		var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", this.Locsize.MargL, this.Locsize.MargT, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
		wtxt.style.backgroundColor="transparent"
		wtxt.style.borderWidth="0"
		wtxt.style.textAlign="left"
		wtxt.innerHTML = this.Txt
		SetUnselectable(wtxt)
		wtxt.style.cursor="pointer"
		this.Htxt=wtxt
	}
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + buttontabindex
	this.Hobj.onclick=EvtClick
	this.Hobj.onmouseover=EvtMouseOver
	this.Hobj.onmouseout=EvtMouseOut
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.onkeypress=EvtKeyPress
	this.SetState("NORM")
}

Qacordeon.prototype.Activate=function(opt) {
	GenericDisplayCtl_Activate.call(this, opt)
	if (this.Selected == "S") {
		this.SetVal("1")
	} else {
		this.SetVal("0")
	}
}
Qacordeon.prototype.Activate2=function(opt) {}

Qacordeon.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qacordeon.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	if (this.Htxt != undefined) this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qacordeon.prototype.SetVal=function(valor) {
	var wpan=null
	if (this.Panel != "") wpan=this.HostPage.GetCtl(this.Panel)
	if (valor == "0") {
		this.Selected = "N"
		this.SetState("NORM")
		if (wpan != null) wpan.Collapse()
	} else {
		this.Selected = "S"
		this.SetState("SELE")
		if (wpan != null) wpan.Expand()
		if (this.Autocollapse == "S") {  // Desactivar todos os outros
			var wparent=this.HostPanel
			while (wparent.Tipo != "PANEL") {
				wparent=wparent.HostPanel
				if (wparent.Tipo == "PAGE") return
			}
			var Aobj=GetCtlChildrenByTipo(wparent, "ACORDEON")
			if (Aobj == null) return
			for (var i=0; i<Aobj.length; i++) {
				if (Aobj[i].Id != this.Id) Aobj[i].SetVal("0")
			}
		}
	}
}

Qacordeon.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	if (this.Htxt != undefined) {
		this.Htxt.disabled=true
		this.Htxt.style.cursor="default"
	}
}

Qacordeon.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		if (this.Htxt != undefined) {
			this.Htxt.disabled=false
			this.Htxt.style.cursor="pointer"
		}
	}
}

Qacordeon.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qacordeon.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qacordeon.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qacordeon.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qacordeon.prototype.OnClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Hobj.disabled == false) this.Hobj.focus()
	var wact=this.Act
	if (wact == "") {
		if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("CLK", "")
	} else {
		if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("NOCLICK")
		ExecCmd(this.HostPage.Area, wact)
	}
	var wpan=null
	if (this.Panel != "") wpan=this.HostPage.GetCtl(this.Panel)
	if (this.Selected == "S") {
		this.SetVal("0")
	} else {
		this.SetVal("1")
	}
}

Qacordeon.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.OnMouseOver(id, hnod)
	if (this.Disabled == true) return
	if (this.HostDataPanel == null) this.HostPanel.OnMouseOver(id, hnod)
	this.SetState("HIGH")
}

Qacordeon.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.OnMouseOut(id, hnod)
	if (this.Disabled == true) return
	if (this.HostDataPanel == null) this.HostPanel.OnMouseOut(id, hnod)
	if (this.Selected == "N") {
		this.SetState("NORM")
	} else {
		this.SetState("SELE")
	}
}

Qacordeon.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) this.OnClick()
}

Qacordeon.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qacordeon.prototype.OnBlur=function() {GenericDisplayCtl_OnBlur.call(this)}


//***************************************************************** QTABSTRIP - define TabStrip
function Qtabstrip(xnod, hostpage, hostpanel) {
	this.Tipo="TABSTRIP"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Id=GetAtt(xnod, "ID", "")
	this.Actls=new Array()
	if (this.Id == "") {
		this.Id="Tabstrip" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Orient=GetAtt(xnod, "ORIENT", "H")
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.TabSelected=0
	this.Disabled=false
	if (this.Prot == "S") this.Disable("PROT")
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "80,17"), hostpanel)
	var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.PanelObj=wdiv
	wdiv.style.backgroundColor="transparent"
	wdiv.style.borderWidth="0"
	wdiv.style.zIndex=2
	this.Offsetx=0
	this.Offsety=0
	this.Events=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "TAB" || xn.nodeName == "TSTRIP") {
			var wctl=new Qtab(xn, hostpage, this)
			this.Actls.push(wctl)
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Activated=false
}

Qtabstrip.prototype.Activate=function(opt) {
	//if (opt == "INIT") this.Show()
	GenericDisplayCtl_Activate.call(this, opt)
	//this.SetVal(this.TabSelected)
}
Qtabstrip.prototype.Activate2=function(opt) {
	this.RelocateTabs()
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].SetVal(0, true)
	}
	this.SetVal(this.TabSelected)
}

Qtabstrip.prototype.SetState=function(st) {}

Qtabstrip.prototype.RelocateTabs=function() {
	this.Offsetx=0
	this.Offsety=0
	for (var i=0; i<this.Actls.length; i++) {
		var wtab=this.Actls[i]
		if (wtab.Visible == true) {
			if (this.Orient == "H") {
				if ((this.Offsetx + wtab.Locsize.ObjW) > this.Locsize.ObjW) {
					this.Offsetx=0
					this.Offsety+=wtab.Locsize.ObjH
				}
			} else {
				if ((this.Offsety + wtab.Locsize.ObjH) > this.Locsize.ObjH) {
					this.Offsetx+=wtab.Locsize.ObjW
					this.Offsety=0
				}
			}
			wtab.Locsize.OffL=this.Offsetx
			wtab.Locsize.OffT=this.Offsety
			wtab.Locsize.Resize(wtab.Hobj)
			if (this.Orient == "H") {
				this.Offsetx += wtab.Locsize.ObjW
			} else {
				this.Offsety += wtab.Locsize.ObjH
			}
		}
	}
}

Qtabstrip.prototype.SetVal=function(valor, internal) {
	var wtabsel=this.TabSelected
	var wval = Number("" + valor)
	if (this.Hobj.style.display == "none") {  //para quando existe um SetVal antes de ter havido um activate
		this.TabSelected = wval
		return
	}
	if (wval == -1) {
		if (this.TabSelected > -1) {
			var novasel=-1
			for (var i=this.TabSelected+1; i<this.Actls.length; i++) {
				if (this.Actls[i].Visible == true) {
					novasel=i
					break
				}
			}
			if (novasel == -1) {
				for (var i=this.TabSelected-1; i>=0; i--) {
					if (this.Actls[i].Visible == true) {
						novasel=i
						break
					}
				}
			}
			if (novasel == -1) {
				this.TabSelected=-1
			} else {
				this.TabSelected=novasel
				this.Actls[novasel].SetVal(1, true)
			}
		}
	} else {
		if (wval >= 0 && wval < this.Actls.length) {
			if (this.TabSelected != wval) {
				if (this.TabSelected > -1) this.Actls[this.TabSelected].SetVal(0, true)
			}
			this.TabSelected=wval
			if (internal != true) this.Actls[wval].SetVal(1,true)
		}
	}
	if (wtabsel != this.TabSelected) {
		for (var i=0; i<this.Events.length; i++) {
			var evt=this.Events[i]
			if (evt.Id == "TABCHANGED") ExecCmd(this.HostPage.Area, evt.Act)
		}
	}
}

Qtabstrip.prototype.GetVal=function() {
	return this.TabSelected
}

Qtabstrip.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qtabstrip.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qtabstrip.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
}

Qtabstrip.prototype.Show=function(opt) {
	if (this.Activated == false) {
		this.Activate()
		return
	}
	if (opt == "CASCADE" && this.Visivel == "N") return
	var ntab=Number(opt)  //se for fornecido o indice de uma tab então só se refere a essa
	if (isNaN(ntab)) ntab=-1
	this.Hobj.style.display="block"
	for (var i=0; i<this.Actls.length; i++) {
		if (ntab == -1) {
			this.Actls[i].Show(opt)
		} else {
			if (i == ntab) this.Actls[i].Show(opt)
		}
	}
	if (opt != "CASCADE") this.Visivel = "S"
	if (opt == "INIT") this.Activate2()
	if (ntab != -1) this.RelocateTabs()
}

Qtabstrip.prototype.Hide=function(opt) {
	var ntab=Number(opt)  //se for fornecido o indice de uma tab então só se refere a essa
	if (ntab == NaN) ntab=-1
	if (ntab == -1) this.Hobj.style.display="none"
	for (var i=0; i<this.Actls.length; i++) {
		if (ntab == -1) {
			this.Actls[i].Hide(opt)
			if (opt != "CASCADE") this.Visivel = "N"
		} else {
			if (i == ntab) this.Actls[i].Hide()
		}
	}
	if (ntab != -1) this.RelocateTabs()
}

Qtabstrip.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}


//*** ver se ha MUÇTIGRIDs/LEDITs dentro do PANEL d TABSTRIP para activar
Qtabstrip.prototype.ActivateCtls=function(wpanel) {
	for (var i=0; i<wpanel.Actls.length; i++) {
		var wctl=wpanel.Actls[i]
		if (wctl.Tipo == "MULTIGRID" || wctl.Tipo == "LEDTXT" || wctl.Tipo == "TEXT" || wctl.Tipo == "COMBO") {
			var wdatactl = wctl.DatactlObj
			if (wdatactl != null) {
				if (wdatactl.Autostart == "T") {
					wdatactl.Autostart = "S"
					wdatactl.Activate()
				}
			}
		} else {
			if (wctl.Tipo == "PANEL") this.ActivateCtls(wctl)
		}
	}
}

Qtabstrip.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}
Qtabstrip.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}


//***************************************************************** QTAB - define Tab de uma Tabstrip
function Qtab(xnod, hostpage, hostpanel) {
	this.Tipo="TAB"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Txt=GetAtt(xnod, "TXT", "")
	this.Img=GetAtt(xnod, "IMG", "")
	this.Panel=GetAtt(xnod, "PANEL", "")
	this.Act=GetAtt(xnod, "ACT", "")
	this.Index=hostpanel.Actls.length
	this.Selected=false
	this.Disabled=hostpanel.Disabled
	this.Hobj.style.display="block"
	this.Hobj.style.cursor="pointer"
	this.Hobj.tabIndex=this.HostPage.TabIndexBase + buttontabindex
	if (this.Txt != "") {
		var wtxt=CreateDiv(this.Hobj, this.Hid + "._.TXT", 0, 0, "100%", "100%")
		wtxt.style.padding=this.Locsize.MargT + "px " + this.Locsize.MargR + "px " + this.Locsize.MargB + "px " + this.Locsize.MargL + "px"
		wtxt.style.backgroundColor="transparent"
		wtxt.style.borderWidth="0"
		wtxt.style.textAlign="center"
		wtxt.innerHTML = this.Txt
		SetUnselectable(wtxt)
		wtxt.style.cursor="pointer"
		this.Htxt=wtxt
	}
	if (this.Img != "") {
		var wimg=CreateImg(this.Hobj, this.Hid + "._.IMG", 2, 2)
		wimg.src=GetImageAddress(this.Img)
		wimg.disabled=true
		wimg.style.cursor="pointer"
		this.Himg=wimg
	}
	if (this.Disabled == false) {
		this.SetState("NORM")
	} else {
		this.SetState("DISA")
	}
	this.Hobj.onclick=EvtClick
	this.Hobj.onmouseover=EvtMouseOver
	this.Hobj.onmouseout=EvtMouseOut
	this.Hobj.onfocus=EvtFocus
	this.Hobj.onblur=EvtBlur
	this.Hobj.onkeypress=EvtKeyPress
}

Qtab.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	if (this.Htxt != undefined) this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qtab.prototype.Activate=function(opt) {
}


Qtab.prototype.SetVal=function(valor, internal) {
	valor="" + valor
	if (valor == "0") {
		this.SetState("NORM")
		if (this.Selected == true && internal != true) this.HostPanel.SetVal(-1, true)
		this.Selected=false
		if (this.Panel != "") {
			var panobj=this.HostPage.GetCtl(this.Panel)
			if (panobj != null) panobj.Hide()
		}
	} else {
		if (this.Selected == false) {
			if (internal != true) this.HostPanel.SetVal(this.Index, true)
			this.SetState("SELE")
			this.Selected=true
			if (this.Act != "") ExecCmd(this.HostPage.Area, this.Act)
		}
		if (this.Panel != "") {
			var panobj=this.HostPage.GetCtl(this.Panel)
			if (panobj != null) panobj.Show()
			this.HostPanel.ActivateCtls(panobj)
		}
	}
}

Qtab.prototype.GetVal=function() {
	if (this.Selected == true) {
		return "1"
	} else {
		return "0"
	}
}

Qtab.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qtab.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		if (this.Selected == true) this.SetState("SELE")
	}
}

Qtab.prototype.Show=function(opt) {
	if (opt == "CASCADE" && this.Visivel == "N") return
	this.Hobj.style.display="block"
	this.Visible=true
	if (opt != "CASCADE") this.Visivel = "S"
	if (this.HostPanel.TabSelected == -1 || this.Selected == true) {
		this.SetVal(1, false)
	}
	this.HostPanel.RelocateTabs()
}

Qtab.prototype.Hide=function(opt) {
	this.SetVal(0, false)
	this.Hobj.style.display="none"
	this.Visible=false
	if (opt != "CASCADE") this.Visivel = "N"
	this.HostPanel.RelocateTabs()
}

Qtab.prototype.Destroy=function(opt) {
	if (BrowserIE || BrowserOP) this.Hobj.removeNode(true)
}

Qtab.prototype.OnClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.SetVal(1)
}

Qtab.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Selected == false) this.SetState("HIGH")
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
}

Qtab.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (this.Selected == true) {
		this.SetState("SELE")
	} else {
		this.SetState("NORM")
	}
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qtab.prototype.OnFocus=function() {
	this.OnMouseOver()
}

Qtab.prototype.OnBlur=function() {
	this.OnMouseOut()
}

Qtab.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13 || wkey == 32) this.OnClick()
}


//***************************************************************** QFLVIDEO - define Flash Video
function Qflvideo(xnod, hostpage, hostpanel) {
	this.Tipo="FLVIDEO"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Src=GetAtt(xnod, "SRC", "")
	this.Autoplay=GetAtt(xnod, "AUTOPLAY", "N")
	this.Volume=GetAtt(xnod, "VOLUME", 50, "N")
	this.BgColor=GetAtt(xnod, "BGCOLOR", "000000")
	this.Hobj.onmouseover=EvtMouseOver
	this.MovHid=this.Hid + "._.SWF"
	this.MovieId=this.Hid.replace(/\./g, "9y9")
	var wautoplay=""
	if (this.Autoplay == "S") wautoplay="&autoPlay=true"
	wautoplay+="&backgroundColor=" + this.BgColor
	var wsrc=GetLoadAddress(this.Src, this.HostPage.Modulo)

	var whtml="<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='" + window.location.protocol + "//fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0' "
	whtml += "id='" + this.MovHid + "' width='100%' height='100%' align='middle'>"
	whtml += "<param name='allowScriptAccess' value='sameDomain' />"
	whtml += "<param name='allowfullscreen' value='true' />"
	whtml += "<param name='movie' value='StrobeMediaPlayback.swf' />"
	whtml += "<param name='flashvars' value='src=" + wsrc + "&volume=" + (this.Volume / 100) + wautoplay + "' />"
	whtml += "<param name='menu' value='false' />"
	whtml += "<param name='quality' value='high' />"
	whtml += "<param name='wmode' value='transparent' />"
	//retirei wmode='transparent' do embed.  Dá problemas nos textfield do flash em input com os caracteres portugueses
	whtml += "<embed src='StrobeMediaPlayback.swf' type='application/x-shockwave-flash' allowscriptaccess='always' allowfullscreen='true'  width='100%' height='100%' flashvars='src=" + wsrc + "&volume=" + (this.Volume / 100) + wautoplay + "' />"
	whtml += "</object>"
	this.Hcode=whtml
}


Qflvideo.prototype.Activate=function(opt) {
	GenericDisplayCtl_Activate.call(this, opt)
}

Qflvideo.prototype.Activate2=function(opt) {
	this.Hobj.innerHTML = this.Hcode
	if (BrowserIE) {
		this.Movieobj=document.getElementById(this.MovHid)
		this.Movieobj.onmouseover=EvtMouseOver
		this.Movieobj.onmouseout=EvtMouseOut
	} else {
		this.Movieobj=eval("window.document." + this.MovieId)
	}
}

Qflvideo.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
}

Qflvideo.prototype.Disable=function() {}
Qflvideo.prototype.Enable=function() {}
Qflvideo.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}
Qflvideo.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qflvideo.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}
Qflvideo.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qflvideo.prototype.Destroy=function(opt) {
	if (BrowserIE) {
		if (this.Movieobj != undefined) this.Movieobj.parentNode.removeChild(this.Movieobj)
	}
}


//***************************************************************** QCOLOR - define Cor
function Qcolor(xnod, hostpage, hostpanel) {
	this.Tipo="COLOR"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	var wtxt = document.createElement("INPUT")
	wtxt.type="text"
	wtxt.style.borderWidth="0px"
	wtxt.style.backgroundColor="transparent"
	wtxt.id=this.Hid + "._.TXT"
	wtxt.style.position="absolute"
	wtxt.maxLength=12
	this.Hobj.appendChild(wtxt)
	this.Htxt=wtxt
	wtxt.style.left=(this.Locsize.MargL) + "px"
	wtxt.style.top=(this.Locsize.MargT) + "px"
	wtxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR - 22) + "px"
	wtxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	wtxt.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	//if (this.HostDataPanel != null) wtxt.tabIndex=wtxt.tabIndex+100
	var wcor=CreateDiv(this.Hobj, this.Hid + "._.COR", this.Locsize.ObjW - this.Locsize.MargR - 20, this.Locsize.MargT, 20, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
	wcor.style.backgroundColor="white"
	wcor.style.borderColor="black"
	wcor.style.borderStyle="SOLID"
	wcor.style.borderWidth="1px"
	this.Hcor=wcor
	this.ContextPanel=null
	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	wtxt.onkeypress=EvtKeyPress
	wtxt.onblur=EvtBlur
	wtxt.onfocus=EvtFocus
	wcor.onblur=EvtBlur
	this.Hcor.onclick=EvtClick
	this.SetState("NORM")
}

Qcolor.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qcolor.prototype.Activate2=function(opt) {}

Qcolor.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR - 22) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	this.Hcor.style.left=(this.Locsize.ObjW - this.Locsize.MargR - 20) + "px"
	this.Hcor.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qcolor.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qcolor.prototype.SetVal=function(valor, cmd) {
	if (valor.substr(0,1) == "#") valor=valor.substr(1)
	if (valor.indexOf("rgb(") == 0) {
		var w=valor.substr(4)
		w=w.substr(0, w.length - 1)
		var Aw=w.split(",")
		var r=parseInt(Aw[0])
		var g=parseInt(Aw[1])
		var b=parseInt(Aw[2])
		var rgb = b | (g << 8) | (r << 16)
    	valor=rgb.toString(16);
	}
	var wvalor=valor
	this.Htxt.value=valor
	if (wvalor != "") {
		if (wvalor != "transparent") wvalor = "#" + wvalor
		this.Hcor.style.backgroundColor=wvalor
	}
	if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") {
		this.DatactlObj.StoreVal(this.Datafld, "#" + valor, this)
	}
}

Qcolor.prototype.GetVal=function() {
	var valor=this.Htxt.value
	if (valor.toUpperCase != "TRANSPARENT") valor = "#" + valor
	return valor
}

Qcolor.prototype.Execute=function(act) {
	if (act == "HideList") {
		if (this.ContextPanel != null) this.HideList()
		return
	}
}

Qcolor.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}

Qcolor.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qcolor.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qcolor.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qcolor.prototype.ShowErr=function(msg) {GenericDisplayCtl_ShowErr.call(this)}

Qcolor.prototype.HideErr=function(msg) {GenericDisplayCtl_HideErr.call(this)}

Qcolor.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qcolor.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qcolor.prototype.OnClick=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	GenericDisplayCtl_OnClick.call(this)
	if (this.ContextPanel == null) {
		this.ShowList()
	} else {
		this.HideList()
	}
}

Qcolor.prototype.OnKeyPress=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	if (wkey == 13) {  //Enter key
		this.ValidarInput()
		return
	}
	wkey=String.fromCharCode(wkey)
	var wtransp=false
	if (wkey == "T" || wkey == "t") wtransp=true
	var wcancel=false
	if("0123456789ABCDEFabcdef".indexOf(wkey) == -1) wcancel=true
	if (wcancel == true) {
		if (BrowserIE || BrowserOP) {
			window.event.returnValue=false
		} else {
			evt.preventDefault()
		}
	}
	if (wtransp == true) this.Htxt.value="transparent"
}

Qcolor.prototype.OnFocus=function() {GenericDisplayCtl_OnFocus.call(this)}

Qcolor.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	if (this.Disabled == true) return
	this.ValidarInput()
	if (this.ContextPanel != null) ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",HideList")
}

Qcolor.prototype.ValidarInput=function() {
	GenericDisplayCtl_OnBlur.call(this)
	var valor = this.Htxt.value
	if (valor.toUpperCase() == "TRANSPARENT") {
		valor="transparent"
		this.SetVal(valor, "SAVE")
		return
	}
	valor=valor.toUpperCase()
	valor=valor.replace(/[^0123456789ABCDEF]/g,"")
	if (valor.length == 0) {
		valor=""
	} else {
		if (valor.length > 6) valor=valor.substr(0,6)
		if (valor.length < 3) {
			valor=valor + "000"
			valor=valor.substr(0,3)
		} else {
			if (valor.length > 3 && valor.length < 6) {
				valor=valor + "000"
				valor=valor.substr(0,3)
			}
		}
	}
	this.SetVal(valor, "SAVE")
}

Qcolor.prototype.ShowList=function() {
	var offset=GetOffsetFor("PAGE", this.HostPanel)
	var xstr="<PANEL STYLE=\"" + this.Style + "\" LOCATION=\"" + (this.Locsize.ObjL - this.HostPage.Locsize.MargL + offset.Left) + "," + (this.Locsize.ObjT - this.HostPage.Locsize.MargT + this.Locsize.ObjH + offset.Top) + "\" SIZE=\"120,150\">"  // + this.Locsize.ObjW + ",80\">"
	xstr +=  "  <COLORPAD DATACTL=\"" + this.Id + "\" LOCATION=\"0,0\" SIZE=\"*,*\"/>"
	xstr +=  "</PANEL>"
	var xnod=CreateXnode(xstr)
	this.ContextPanel = new Qitempanel(xnod, this.HostPage, this.HostPage, this, "COLOR.DROPPANEL", null, null, 50, 50, 300, 400)
	this.ContextPanel.SetSize("124,154")
	this.ContextPanel.Resize()
	this.ContextPanel.Activate()
	this.Actls.push(this.ContextPanel)
}

Qcolor.prototype.HideList=function() {
	if (this.ContextPanel == null) return
	this.Actls=new Array()
	this.ContextPanel.Destroy()
	this.ContextPanel=null
}

Qcolor.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qcolor.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}


//***************************************************************** QCOLORPAD - define painel de selecção de cor
function Qcolorpad(xnod, hostpage, hostpanel, parentobj) {
	this.Tipo="COLORPAD"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	var wtes=CreateDiv(this.Hobj, this.Hid + "._.TES", 0, 0, "100%", 30)
	this.Htes=wtes
	var wtab=CreateDiv(this.Hobj, this.Hid + "._.TAB", 0, 30, "100%", this.Locsize.ObjH-30-this.Locsize.MargB)
	this.Htab=wtab

	this.Hobj.onmouseover=EvtMouseOver
	this.Hobj.onclick=EvtClick
}

Qcolorpad.prototype.Activate=function() {
	this.Hobj.style.display="block"
	var total=1657
	var X=Y=j=RG=B=0
	var aR=new Array(total)
	var aG=new Array(total)
	var aB=new Array(total)
	for (var i=0; i<256; i++) {
		aR[i+510]=aR[i+765]=aG[i+1020]=aG[i+5*255]=aB[i]=aB[i+255]=0
		aR[510-i]=aR[i+1020]=aG[i]=aG[1020-i]=aB[i+510]=aB[1530-i]=i
		aR[i]=aR[1530-i]=aG[i+255]=aG[i+510]=aB[i+765]=aB[i+1020]=255
		if (i < 255){
			aR[i/2+1530]=127
			aG[i/2+1530]=127
			aB[i/2+1530]=127
		}
	}
	var hexbase=new Array("0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F")
	var i=0
	var jl=new Array()
	for (x=0; x<16; x++) {
		for (y=0; y<16; y++) {
			jl[i++] = hexbase[x]+hexbase[y]
		}
	}
	var whtml="<table id='" + this.Hid + "._.TBL' border='0' cellspacing='0' cellpadding='0'>"
	var H=W=63
	var wc=""
	var wid=this.Hid + "._.COR"
	for (Y=0; Y<=H; Y++){
		s="<tr height='2'>"
		j=Math.round(Y*(510/(H+1))-255)
		for (X=0; X<=W; X++){
			i=Math.round(X*(total/W))
			R=aR[i]-j
			if (R<0) R=0
			if (R>255 || isNaN(R)) R=255
			G=aG[i]-j
			if (G<0) G=0
			if (G>255 || isNaN(G)) G=255
			B=aB[i]-j
			if (B<0) B=0
			if (B>255 || isNaN(B)) B=255
			wc=jl[R] + jl[G] + jl[B]
			s += "<td id='" + wid + wc + "' width='2' bgcolor='#" + wc + "'></td>"
		}
		whtml += s + "</tr>"
	}
	whtml += "</table>"
	this.Htab.innerHTML=whtml
	var ns6=document.getElementById&&!document.all
	var ie=document.all
	var artabus=''
}

Qcolorpad.prototype.Resize=function() {}

Qcolorpad.prototype.Hide=function() {}

Qcolorpad.prototype.Show=function() {}

Qcolorpad.prototype.OnMouseOver=function(id) {
	if (AllInputBlocked == true) return
	var ix=id.indexOf("._.COR")
	if (ix == -1) return
	var wcor=id.substr(ix + 6)
	this.Htes.style.backgroundColor="#" + wcor
}

Qcolorpad.prototype.OnClick=function(id) {
	if (AllInputBlocked == true) return
	var ix=id.indexOf("._.COR")
	if (ix == -1) return
	var wcor=id.substr(ix + 6)
	this.DatactlObj.HideList()
	this.DatactlObj.SetVal(wcor, "SAVE")
}

Qcolorpad.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qcolorpad.prototype.Destroy2=function() {
	GenericDisplayCtl_Destroy2.call(this)
	this.Hobj=null
}


//***************************************************************** QWEBPAGE - define Webpage
function Qwebpage(xnod, hostpage, hostpanel) {
	this.Tipo="WEBPAGE"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Src=GetAtt(xnod, "SRC", "")
	if (this.Src.indexOf("]") != -1) this.Src=SubstVars(this.HostPage.Area, this.Src)
	this.HistParms=GetAtt(xnod, "HISTPARMS", "")
	this.Parms=GetAtt(xnod, "PARMS", "")
	var wifr = document.createElement("IFRAME")
	wifr.id=this.Hid + "._.IFR"
	wifr.style.position="absolute"
	wifr.frameBorder=0
	this.Hobj.appendChild(wifr)
	wifr.style.left=this.Locsize.MargL + "px"
	wifr.style.top=this.Locsize.MargT + "px"
	wifr.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	wifr.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	this.Hifr=wifr
	var wurl=this.Src
	if (this.Parms != "") {
		var Aw=this.Parms.split("[")
		var ix=0
		for (var i=0; i<Aw.length - 1; i++) {
			var idparm=Aw[i]
			var valparm=Aw[i+1]
			if (i == 0 && wurl.indexOf("?") == -1) {
				wurl=wurl + "?"
			} else {
				wurl=wurl + "&"
			}
			wurl=wurl + idparm + "=" + encodeURIComponent(valparm)
			i++
		}
	}
	if (this.HistParms != "") {
		var Aw=this.HistParms.split("[")
		var ix=0
		for (var i=0; i<Aw.length; i++) {
			ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "EQ")
			if (ix > -1) {
				if (i == 0 && wurl.indexOf("?") == -1) {
					wurl=wurl + "?"
				} else {
					wurl=wurl + "&"
				}
				wurl=wurl + Aw[i] + "=" + this.HostPage.Area.Historial[ix].Valor
			} else {
				ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "GE")
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?"
					} else {
						wurl=wurl + "&"
					}
					wurl=wurl + Aw[i] + "GE=" + this.HostPage.Area.Historial[ix].Valor
				}
				ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "LE")
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?"
					} else {
						wurl=wurl + "&"
					}
					wurl=wurl + Aw[i] + "LE=" + this.HostPage.Area.Historial[ix].Valor
				}
			}
		}
	}
	wifr.src=wurl
}

Qwebpage.prototype.Activate=function(opt) {
	this.Show()
}

Qwebpage.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Hifr.style.left=this.Locsize.MargL + "px"
	this.Hifr.style.top=this.Locsize.MargT + "px"
	this.Hifr.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Hifr.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qwebpage.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
}

Qwebpage.prototype.SetVal = function(whtml) {
    this.Hifr.contentWindow.document.body.innerHTML=whtml
}

Qwebpage.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	this.Hifr.disabled=true
}

Qwebpage.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled = false) this.Hifr.disabled=false
}

Qwebpage.prototype.Show=function() {
	this.Hobj.style.display="block"
}

Qwebpage.prototype.Hide=function(opt) {
	this.Hobj.style.display="none"
}

Qwebpage.prototype.Destroy=function(opt) {
}



//***************************************************************** QCRYSTAL - define Crystal Report (igual ao WEBPAGE)
function Qcrystal(xnod, hostpage, hostpanel) {
	this.Tipo="CRYSTAL"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Src=GetAtt(xnod, "SRC", "")
	this.HistParms=GetAtt(xnod, "HISTPARMS", "")
	this.Parms=GetAtt(xnod, "PARMS", "")
	var wifr = document.createElement("IFRAME")
	wifr.id=this.Hid + "._.IFR"
	wifr.style.position="absolute"
	wifr.frameBorder=0
	this.Hobj.appendChild(wifr)
	wifr.style.left=this.Locsize.MargL + "px"
	wifr.style.top=this.Locsize.MargT + "px"
	wifr.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	wifr.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	this.Hifr=wifr
}

Qcrystal.prototype.Activate=function(opt) {
	this.Show()
	var wurl=this.Src
	if (this.Parms != "") {
		var Aw=this.Parms.split("[")
		var ix=0
		for (var i=0; i<Aw.length - 1; i++) {
			var idparm=Aw[i]
			var valparm=Aw[i+1]
			if (i == 0 && wurl.indexOf("?") == -1) {
				wurl=wurl + "?"
			} else {
				wurl=wurl + "&"
			}
			wurl=wurl + idparm + "=" + encodeURIComponent(valparm)
			i++
		}
	}
	if (this.HistParms != "") {
		var Aw=this.HistParms.split("[")
		var ix=0
		for (var i=0; i<Aw.length; i++) {
			ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "EQ")
			if (ix > -1) {
				if (i == 0 && wurl.indexOf("?") == -1) {
					wurl=wurl + "?"
				} else {
					wurl=wurl + "&"
				}
				wurl=wurl + Aw[i] + "=" + this.HostPage.Area.Historial[ix].Valor
			} else {
				ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "GE")
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?"
					} else {
						wurl=wurl + "&"
					}
					wurl=wurl + Aw[i] + "GE=" + this.HostPage.Area.Historial[ix].Valor
				}
				ix=GetHistorialIndex(this.HostPage.Area, Aw[i], "LE")
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?"
					} else {
						wurl=wurl + "&"
					}
					wurl=wurl + Aw[i] + "LE=" + this.HostPage.Area.Historial[ix].Valor
				}
			}
		}
	}
	this.Hifr.src=wurl
}

Qcrystal.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Hifr.style.left=this.Locsize.MargL + "px"
	this.Hifr.style.top=this.Locsize.MargT + "px"
	this.Hifr.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Hifr.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qcrystal.prototype.SetState=function(st) {
	GenericDisplayCtl_SetState.call(this, st)
}

Qcrystal.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	this.Hifr.disabled=true
}

Qcrystal.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) this.Hifr.disabled=false
}

Qcrystal.prototype.Show=function() {
	this.Hobj.style.display="block"
}

Qcrystal.prototype.Hide=function(opt) {
	this.Hobj.style.display="none"
}

Qcrystal.prototype.Destroy=function(opt) {
}



//***************************************************************** QUPLOAD - define Diálogo de Upload
function Qupload(hostctl, url, wid, hei) {
	if (wid == undefined) wid=360
	if (hei == undefined) hei=180
	this.Tipo="UPLOAD"
	this.Class="DISPLAY"
	this.HostPage=hostctl.HostPage
	this.HostPanel=hostctl.HostPage
	this.HostCtl=hostctl
	this.HostDataPanel=FindDataPanel(hostctl)
	this.Id=this.Tipo + this.HostPage.CtlCount
	this.HostPage.CtlCount ++
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostctl.Hid + "." + this.Id
	this.Actls=new Array()
	this.Events=new Array()
	this.Style=hostctl.Style
	this.StyleObj=App.GetStyle(this.Style, "UPLOAD.CONTEXTPANEL")
	this.Prot="N"
	this.Disabled=false
	this.Visivel="S"
	this.Visible=true

	var offset=GetOffsetFor("PAGE", hostctl)
	var wx=offset.Left
	var wy=offset.Top
	if (offset.MaxWidth > wx + 30 + wid) {
		wx=wx+10
	} else {
		wx=offset.MaxWidth - wid - 20
	}
	if (offset.MaxHeight > wy + 30 + hei) {
		wy=wy+10
	} else {
		wy=offset.MaxHeight - hei - 20
	}

	this.Locsize=new QlocSize(wx + "," + wy, wid + "," + hei, this.HostPanel)
	var wdiv=CreateDiv(this.HostPanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=1

	var wifr = document.createElement("IFRAME")
	wifr.style.position="absolute"
	wifr.style.left = this.Locsize.MargL + "px"
	wifr.style.top = this.Locsize.MargT + "px"
	wifr.style.width = (this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	wifr.style.height = (this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	wifr.frameBorder=0
	wdiv.appendChild(wifr)
	wifr.src=url
	wifr.qwebp1=""
	wifr.qwebp2=""
	wifr.qwebp3=""
	wifr.status=""
	wifr.id=this.Hid + "._.IFR"
	wifr.style.zindex=2
	this.Hifr=wifr

	if (BrowserIE) {
		wifr.onresizestart=EvtOk
	} else {
		wifr.onsubmit=EvtOk
	}
	App.DisableForPopup(null, "Upload")
}

Qupload.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qupload.prototype.Activate2=function(opt) {}

Qupload.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qupload.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qupload.prototype.Execute=function(act) {
	if (act == "CLOSECONTEXT") {
		this.Destroy()
		App.EnableForPopup(null, "Upload")
		return
	}
}

Qupload.prototype.Disable=function(tipo) {GenericDisplayCtl_Disable.call(this, tipo)}
Qupload.prototype.Enable=function(tipo) {GenericDisplayCtl_Enable.call(this, tipo)}

Qupload.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qupload.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qupload.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qupload.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qupload.prototype.OnOk=function() {   //um unico evento, o status é que indica o que se passou
	var wstatus=this.Hifr.status
	var wp1=this.Hifr.qwebp1
	var wp2=this.Hifr.qwebp2
	var wp3=this.Hifr.qwebp3
	if (wstatus == "OK") {
		ExecCmdDelayed(1400, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",CLOSECONTEXT")
		ExecCmdDelayed(1600, this.HostPage.Area, "ExecuteInternal(" + this.HostCtl.Id + ",EndUpload," + wp1 + "," + wp2 + "," + wp3)
		return
	}
	if (wstatus == "CANCEL") {
	    ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",CLOSECONTEXT")
	    return
	}
	if (wstatus == "ERROR") {
	    ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",CLOSECONTEXT")
	    if (wp1 != "") {
	        window.alert(GetMsg(wp1))
	    } else {
	        window.alert(GetMsg(1, "O Upload de ficheiro não foi bem sucedido"))
	    }
	    return
	}
}



//***************************************************************** QCALEND - define Calendario
function Qcalend(xnod, hostpage, hostpanel, hostctl) {
	this.Tipo="CALEND"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostCtl=hostctl
	this.HostDataPanel=FindDataPanel(this)
	this.Actls=new Array()
	this.Grpctls=new Array()
	this.List=""
	this.Disabled=false
	if (xnod != null) {
		this.Mode="control"
		this.Id=GetAtt(xnod, "ID", "")
		if (this.Id == "") {
			this.Id="Calend" + this.HostPage.CtlCount
			this.HostPage.CtlCount ++
		}
		if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
		this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)
		this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
		this.Datactl=GetAtt(xnod, "DATACTL", "")
		this.DatactlObj=null
		if (this.Datactl != "") {
			this.DatactlObj=hostpage.GetCtl(this.Datactl)
			if (this.DatactlObj == null) {
				window.alert(GetMsg(1, "CALEND (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
				return
			}
		}
		this.Datafld=GetAtt(xnod, "DATAFLD", "")
		if (this.Datactl != "") {
			this.DataCol=this.DatactlObj.GetCol(this.Datafld)
		} else {
			this.DataCol=new Qcol(null, this.Datafld, "D", "")
		}
		this.Prot=GetAtt(xnod, "PROT", "N")
		this.Tip=GetAtt(xnod, "TIP", "")
		this.Min=GetAtt(xnod, "MIN", "01/01/1800")
		this.Max=GetAtt(xnod, "MAX", "31/12/2099")
		this.Min=SubstVarsExt(this.HostPage.Area, this.Min)
		this.Max=SubstVarsExt(this.HostPage.Area, this.Max)
		var Aw=this.Max.split("/")
		this.Max=Aw[2] + "/" + Aw[1] + "/" + Aw[0]
		var Aw=this.Min.split("/")
		this.Min=Aw[2] + "/" + Aw[1] + "/" + Aw[0]
		this.List=GetAtt(xnod, "LIST", "")
	} else {
		this.Mode="popup"
		this.Id="Calend" + this.HostPage.CtlCount
		if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
		this.HostPage.CtlCount ++
		this.HostPage.Actls.push(this)
		var offset=GetOffsetFor("PAGE", hostctl.HostPanel)
		var whl=hostctl.Locsize.ObjL
		var wht=hostctl.Locsize.ObjT
		if (wht > 140) {
			var wt=wht - 136
		} else {
			var wt=wht + hostctl.Locsize.ObjH
		}
		this.Locsize=new QlocSize(("" + (whl + offset.Left) + "," + (wt + offset.Top)), "140,150", hostpage)
		this.Style=hostctl.Style
		this.Prot="N"
		this.Tip=""
		this.Min="01/01/1800"
		this.Max="31/12/2099"
	}
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Dados=new Array()
	this.SelectedKeys=new Array()
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
	this.CalenDias = new Array()
	this.Events = new Array()
	this.Datas=new Array()
	this.Tipos=new Array()
	this.Cols=new Array()
	this.XtraCols=new Array()
	var wcol=new Qcol(null, "Data", "A", "10")
	wcol.Key="S"
	this.Cols.push(wcol)
	var wcol=new Qcol(null, "Dia", "A", "2")
	wcol.Larg=20
	wcol.Vis="S"
	this.Cols.push(wcol)
	var wcol=new Qcol(null, "Tipo", "A", "15")
	wcol.Vis="N"
	this.Cols.push(wcol)
	var wcol=new Qcol(null, "ReadOnly", "A", "1")
	wcol.Vis="N"
	this.Cols.push(wcol)

	this.XtraCols.push(new Qcol(null, "$mes", "N", 2))
	this.XtraCols.push(new Qcol(null, "$ano", "N", 4))
	this.XtraCols.push(new Qcol(null, "$mesano", "A", 20))
	this.StyleObj=App.GetStyle(this.Style, this.Tipo)
	if (this.Mode == "control") {
		var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid)
		this.Hobj=wdiv
		wdiv.style.display="none"
		this.Locsize.Resize(wdiv)
		this.Frame=new Qframe(this)
		if (this.Tip != "") wdiv.title=this.Tip
		this.PanelObj=wdiv
		wdiv.style.zIndex=3
	} else {
		this.Locsize.Resize()
		var wdiv=null
		this.Hobj=wdiv
	}

	this.DefTipo=""
	if (xnod != null) {
		var xn=xnod.firstChild
		while (xn!=undefined) {
			if (xn.nodeName == "CALENDIA") {
				var calendia=new Qcalendia(xn, this.Style)
				if (calendia.Default == "S") this.DefTipo=calendia.Id
				this.CalenDias.push(calendia)
			}
			if (xn.nodeName == "EVENT") {
				var wevent=new Qevent(xn)
				this.Events.push(wevent)
			}
			xn=xn.nextSibling
		}
	}
	var wdiafil=false
	var wdianorm=false
	for (var i=0; i<this.CalenDias.length; i++) {
		if (this.CalenDias[i].Tipo == "FILLER") wdiafil=true
		if (this.CalenDias[i].Tipo == "NORMAL") wdianorm=true
	}
	if (wdiafil == false) {
		var calendia=new Qcalendia(null, "FILLER", "FILLER", "S", "N")
		this.CalenDias.push(calendia)
	}
	if (wdianorm == false) {
		var calendia=new Qcalendia(null, "DEFAULT", "NORMAL", "N", "S")
		this.CalenDias.push(calendia)
		if (this.DefTipo == "") this.DefTipo="NORMAL"
	}


	var wdthoje = Agora()
	this.Ano = wdthoje.getUTCFullYear()
	this.Mes = wdthoje.getUTCMonth() + 1
	this.Dia = wdthoje.getUTCDate()
	this.AnoH=this.Ano
	this.MesH=this.Mes
	this.DiaH=this.Dia
	this.SelData=""
	this.SelTipo=""
	if (this.List != "") this.SetList(this.List, false)
	/*
	if (xnod != null) {
		this.SetVal("")
	} else {
		var wdtref = hostctl.GetVal()
		this.SetVal(wdtref)
	}
	*/
	if (xnod != null) {
		if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	}
}

Qcalend.prototype.Activate=function(opt) {
	var dlarg=Math.floor((this.Locsize.ObjW - 6) / 7 - 1)
	var dalt=Math.floor((this.Locsize.ObjH - 6 - 25) / 7 - 1)
	var offset=0
	var daylen=3
	if (dlarg < 20) daylen=1
	var xstr="<MULTIGRID ID=\"" + this.Id + "MULTIGRID\" DATACTL=\"" + this.Id + "\" LOCATION=\"0,0\" SIZE=\"*,*\" HPADDING=\"1\" VPADDING=\"1\" FORCOL=\"Tipo\" HREPEAT=\"7\">"
	xstr += "  <HEADERPANEL ID=\"" + this.Id + "PMesAno\" SIZE=\"*,24\" AUTOLAYOUT=\"N\" AUTOSCROLL=\"N\">"
	xstr += "    <BOTAUX ID=\"" + this.Id + "BAnoAnt\" LOCATION=\"1,1\" SIZE=\"16,18\" TXT=\"&lt;\" AUTOREPEAT=\"S\" ACT=\"Execute(" + this.Id + ",ANO-\"/>"
	xstr += "    <BOTAUX ID=\"" + this.Id + "BMesAnt\" LOCATION=\"18,1\" SIZE=\"17,18\" TXT=\"-\" AUTOREPEAT=\"S\" ACT=\"Execute(" + this.Id + ",MES-\"/>"
	xstr += "    <TEXT ID=\"" + this.Id + "TMesAno\" LOCATION=\"36,1\" SIZE=\"*-33,18\" READONLY=\"S\" DATACTL=\"" + this.Id + "\" DATAFLD=\"$mesano\" ALIGN=\"center\"/>"
	xstr += "    <BOTAUX ID=\"" + this.Id + "BMesSeg\" LOCATION=\"*-35,1\" SIZE=\"16,18\" TXT=\"+\" AUTOREPEAT=\"S\" ACT=\"Execute(" + this.Id + ",MES+\"/>"
	xstr += "    <BOTAUX ID=\"" + this.Id + "BAnoSeg\" LOCATION=\"*-18,1\" SIZE=\"16,18\" TXT=\"&gt;\" AUTOREPEAT=\"S\" ACT=\"Execute(" + this.Id + ",ANO+\"/>"
	xstr += "  </HEADERPANEL>"
	xstr += "  <HEADERPANEL ID=\"" + this.Id + "PDiasSem\" SIZE=\"*," + (dalt + 2) + "\" AUTOLAYOUT=\"N\" AUTOSCROLL=\"N\">"
	xstr += "    <LABEL ID=\"Tdom\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[0].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tseg\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[1].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tter\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[2].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tqua\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[3].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tqui\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[4].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tsex\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[5].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "    <LABEL ID=\"Tsab\" LOCATION=\"" + offset + ",1\" SIZE=\"" + dlarg + "," + dalt + "\" TXT=\"" + DiaSet[6].substr(0, daylen) + "\" ALIGN=\"center\"/>"
	offset += dlarg + 1
	xstr += "  </HEADERPANEL>"
	for (var i=0; i<this.CalenDias.length; i++) {
		var whandc="S"
		if (this.CalenDias[i].Prot == "S") whandc="N"
		xstr += "  <DATAPANEL ID=\"" + this.Id + this.CalenDias[i].Id + "P\" AUTOLAYOUT=\"N\" FORVAL=\"" + this.CalenDias[i].Id + "\" SIZE=\"" + dlarg + "," + dalt + "\" PROT=\"" + this.CalenDias[i].Prot + "\" HANDCURSOR=\"" + whandc + "\" STYLE=\"" + this.CalenDias[i].Style + "\">"
	    xstr += "    <TEXT ID=\"" + this.Id + this.CalenDias[i].Id + "T\" LOCATION=\"0,0\" SIZE=\"*,*\" DATACTL=\"" + this.Id + "\" DATAFLD=\"Dia\" ALIGN=\"center\" READONLY=\"S\"/>"
	    xstr += "  </DATAPANEL>"
	}
	xstr += "</MULTIGRID>"
	if (this.Mode == "popup") {
		var offset=GetOffsetFor("APP", this.HostPanel)
		var wl=this.HostCtl.Locsize.ObjL + this.HostCtl.Locsize.ObjW  + this.HostCtl.Locsize.MargL + offset.Left   // - this.HostPage.Locsize.MargL
		var locationchanged=false
		if (wl + 150 > offset.MaxWidth) {
			wl=wl - 142
			locationchanged=true
		}
		var wt=this.HostCtl.Locsize.ObjT  + this.HostCtl.Locsize.MargT +  offset.Top   // - this.HostPage.Locsize.MargT
		if (wt + 176  + this.HostCtl.Locsize.ObjH> offset.MaxHeight) {
			wt=wt - 152
		} else {
			if (locationchanged == true) wt=wt + this.HostCtl.Locsize.ObjH
		}
		xstr="<PANEL STYLE=\"" + this.Style + "\" LOCATION=\"" + wl + "," + wt + "\" SIZE=\"142,152\">" + xstr
		xstr += "</PANEL>"
	}
	var xnod=CreateXnode(xstr)
	if (this.Mode == "popup") {
		this.ContextPanel = new Qitempanel(xnod, this.HostPage, App, this, "CALEND.DROPPANEL", null, null, 50, 50, 300, 400)
		this.ContextPanel.Activate()
		this.Actls.push(this.ContextPanel)
		this.Hgrid=this.HostPage.GetCtl(this.Id + "MULTIGRID")
	} else {
		this.Hgrid=new Qmultigrid(xnod, this.HostPage, this)
		this.Actls.push(this.Hgrid)
	}
	this.Grpctls[0]=this.Hgrid
	this.Hgrid.SetVal()
	if (this.Mode == "popup") {
		var wdt=this.HostCtl.GetVal()
		wdt=ConvertDataToSrv(wdt)
		this.SetVal(this.HostCtl.GetVal())
	} else {
		this.SetVal("")
		this.Show("INIT")
	}
}

Qcalend.prototype.Activate2=function() {
	this.Hgrid.Activate("INIT")
}

Qcalend.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qcalend.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Hgrid.Resize()
}

Qcalend.prototype.SetList=function(list, redraw) {
	var wlist=CondDecode(list)
	this.Datas=new Array()
	this.Tipos=new Array()
	var Arec=wlist.split("{")
	var Aw
	for (var r=0; r<Arec.length; r++) {
		Aw=Arec[r].split("[")
		this.Datas.push(Aw[1])
		this.Tipos.push(Aw[0])
	}
	if (redraw == undefined || redraw == true) this.CriaMes()
}

Qcalend.prototype.CriaMes=function() {
	var ndias=31
	if (this.Mes == 4 || this.Mes == 6 || this.Mes == 9 || this.Mes == 11) {
		ndias = 30
	} else {
		if (this.Mes == 2) {
			if ((this.Ano / 4) == Math.floor(this.Ano / 4)) {
				ndias = 29
			} else {
				ndias = 28
			}
		}
	}
	var wd=Agora()
	wd.setUTCFullYear(this.Ano, this.Mes - 1, 1)
	var diasem = wd.getDay()
	var primeirakey=""
	this.Dados=new Array()
	this.SelectedKeys=new Array()
	for (var i=0; i<diasem; i++) {
		var Rec=new Qrecord(this.Cols, new Array("" + i, "", "FILLER", "S"))
		if (primeirakey == "") primeirakey=Rec.Key
		this.Dados.push(Rec)
	}
	var wmes="" + this.Mes
	if (wmes.length < 2) wmes="0" + wmes
	var wmesano=wmes + "/" + this.Ano
	var wanomes=this.Ano + "/" + wmes + "/"
	var Adatas=new Array()
	var ix=0
	var wdata=""
	for (var i=0; i<this.Datas.length; i++) {
		wdata=this.Datas[i]
		ix=wdata.indexOf("*",1)
		if (ix > 0) {
			wdata=wdata.replace("/*/", "/" + wmes + "/")
			wdata=wdata.replace("/*", "/" + this.Ano)
		}
		Adatas.push(wdata)
	}
	var wdata=""
	var wdatadma=""
	var wdatadma2=""
	var wtipodia=""
	var readonly="N"
	for (var d=1; d<=ndias; d++) {
		var wdia="" + d
		if (wdia.length < 2) wdia="0" + wdia
		wdata=wanomes + wdia
		wdatadma=wdia + "/" + wmesano
		wdatadma2="*/" + wmesano
		wtipodia=""
		wsel=false
		readonly="N"
		for (var i=0; i<Adatas.length; i++) {
			if (wdatadma == Adatas[i] || wdatadma2 == Adatas[i]) wtipodia=this.Tipos[i]
		}
		if (wtipodia == "") wtipodia = this.DefTipo
		
		if (this.SelData == wdatadma) this.SelectedKeys.push(wdatadma)
		if (wdata < this.Min || wdata > this.Max) readonly="S"
		var Rec=new Qrecord(this.Cols, new Array(wdatadma, wdia, wtipodia, readonly))
		if (primeirakey == "") primeirakey=Rec.Key
		this.Dados.push(Rec)
	}
	this.Paginas=new Array()
	this.Paginas.push(primeirakey)
	this.PagIndex=0
	for (var i=0; i<this.XtraCols.length; i++) {
		var xcol=this.XtraCols[i]
		var wval=""
		if (xcol.Id == "$mes") wval=MesSet[this.Mes - 1]
		if (xcol.Id == "$ano") wval=this.Ano
		if (xcol.Id == "$mesano") {
			if (this.Locsize.ObjW > 190) {
				wval=MesSet[this.Mes - 1] + " " + this.Ano
			} else {
				wval=MesSet[this.Mes - 1].substr(0,3) + " " + this.Ano
			}
		}
		for (var c=0; c<xcol.ColCtls.length; c++) {
			xcol.ColCtls[c].SetVal(wval)
		}
	}
	if (this.Hgrid != undefined) this.Hgrid.SetVal()
}

Qcalend.prototype.GetVal=function() {
	return this.SelData
}

Qcalend.prototype.SetVal=function(valor, cmd) {
	var wval=valor.replace(/_/g, "");
	wval=wval.replace(/\/\//g, "");
	if (wval != "") {
		var re=/-/g
		var wdtref=wval.replace(re, "/")
		var Aref=wdtref.split("/")

		for (var i=0; i<3; i++) {
			var wf=User.DateFmt.substr(i,1);
			if (wf == "A") this.Ano = Number(Aref[i]);
			if (wf == "M") this.Mes = Number(Aref[i]);
			if (wf == "D") this.Dia = Number(Aref[i]);
		}
	}
	var wdia="" + this.Dia
	if (wdia.length < 2) wdia="0" + wdia
	var wmes="" + this.Mes
	if (wmes.length < 2) wmes="0" + wmes
	this.SelData=wdia + "/" + wmes + "/" + this.Ano
	this.CriaMes()
	var wrec=null
	for (var i=0; i<this.Dados.length; i++) {
		if (this.Dados[i].Key == this.SelData) {
			wrec=this.Dados[i]
			break
		}
	}
	if (wrec == null) return
	this.SelTipo=wrec.Field("Tipo").Val
	
	var wmask="";
	if (this.HostCtl != null) wmask=this.HostCtl.Mask;

	if (User.DateFmt == "AMD" || wmask == "0000/00/00") this.SelData = this.Ano + "/" + wmes + "/" + wdia;
	if (User.DateFmt == "DMA" || wmask == "00/00/0000") this.SelData = wdia + "/" + wmes + "/" + this.Ano;
	if (User.DateFmt == "MDA") this.SelData = wmes + "/" + wdia + "/" + this.Ano;
}

Qcalend.prototype.ReturnVal=function(valor) {
	var Aw=valor.split("/");
	var wdia=Aw[0]
	var wmes=Aw[1]
	var wano=Aw[2]
	/*
	var wdia="" + this.Dia
	if (wdia.length < 2) wdia="0" + wdia
	var wmes="" + this.Mes
	if (wmes.length < 2) wmes="0" + wmes
	var wano="" + this.Ano
	*/
	var wdata="";
	var wmask="";
	if (this.HostCtl != null) wmask=this.HostCtl.Mask;
	if (User.DateFmt == "AMD" || wmask == "0000/00/00") wdata = wano + "/" + wmes + "/" + wdia;
	if (User.DateFmt == "DMA" || wmask == "00/00/0000") wdata = wdia + "/" + wmes + "/" + wano;
	if (User.DateFmt == "MDA") wdata = wmes + "/" + wdia + "/" + wano;

	if (this.Mode == "popup") {
		this.HostCtl.SetVal(wdata, "SAVE")
	} else {
		if (this.Datactl != "" && this.Disabled == false) this.DatactlObj.StoreVal(wdata, this)
	}
}

Qcalend.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qcalend.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
	for (var i=0; i<this.XtraCols.length; i++) {
		if (colid == this.XtraCols[i].Id) return this.XtraCols[i]
	}
	return null
}

Qcalend.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix != null) {
		var Rec = ctl.HostDataPanel.Record
		var Field = Rec.Fields[ix]
		Field.ColCtls.push(ctl)
		return
	} else {
		for (var i=0; i<this.XtraCols.length; i++) {
			if (colid == this.XtraCols[i].Id) {
				this.XtraCols[i].ColCtls.push(ctl)
			}
		}
	}
}

Qcalend.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	this.Disabled=true
	this.Hgrid.Disable()
}

Qcalend.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) this.Hgrid.Enable(tipo)
}

Qcalend.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
	this.Hgrid.Show()
}

Qcalend.prototype.Hide=function(opt) {
	if (opt == "DESTROY" || opt == "DESTROYNOW") {
		if (this.Hgrid != null) this.Hgrid.Destroy()
		if (this.Mode == "popup") {
			if (this.ContextPanel != null) this.ContextPanel.Destroy(opt)
		}
	} else {
		this.Hgrid.Hide()
		if (this.Mode == "popup") this.ContextPanel.Hide()
	}
	if (this.Mode == "popup") {
		this.Destroy2()
		return
	}
	GenericDisplayCtl_Hide.call(this, opt)
}

Qcalend.prototype.Execute=function(act, opt) {
	if (act == "CLOSE") {
		this.Destroy()
		return
	}
	if (act == "Redraw") {
		this.CriaMes()
		this.InProcess=1
		return
	}
	if (act == "MES+") {
		this.Mes ++
		if (this.Mes > 12) {
			this.Mes=1
			this.Ano=this.Ano + 1
		}
		this.CriaMes()
		if (this.Mode == "popup") this.HostCtl.CalendInteracting=true
	}
	if (act == "MES-") {
		this.Mes --
		if (this.Mes < 1) {
			this.Mes=12
			this.Ano=this.Ano-1
		}
		this.CriaMes()
		if (this.Mode == "popup") this.HostCtl.CalendInteracting=true
	}
	if (act == "ANO+") {
		this.Ano ++
		this.CriaMes()
		if (this.Mode == "popup") this.HostCtl.CalendInteracting=true
	}
	if (act == "ANO-") {
		this.Ano --
		this.CriaMes()
		if (this.Mode == "popup") this.HostCtl.CalendInteracting=true
	}
	if (act == "CLK") {
		this.ReturnVal(this.SelectedKeys[0])
		if (this.Mode == "popup") this.Destroy()
	}
}

Qcalend.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qcalend.prototype.Destroy2=function() {
	GenericDisplayCtl_Destroy2.call(this)
	this.Hgrid=null
	this.ContextPanel=null
	if (this.Mode == "popup") this.HostCtl.Hcalend=null
}

Qcalend.prototype.OnBlur=function() {
	if (this.InProcess >0) {
		this.InProcess--
		return
	}
	if (this.HostCtl != undefined) ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",CLOSE")
}

Qcalend.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qcalend.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}


//***************************************************************** QCALENDIA - define tipo de dia de calendario
function Qcalendia(xnod, estilo, id, prot, def) {
	if (xnod == null) {
		this.Id=id
		this.Prot=prot
		this.Default=def
		this.Style=estilo
	} else {
		this.Id=GetAtt(xnod, "ID", "NORM")
		this.Prot=GetAtt(xnod, "PROT", "N")
		this.Default=GetAtt(xnod, "DEFAULT", "S")
		this.Style=GetAtt(xnod, "STYLE", estilo)
	}
}




//***************************************************************** QSINAL - define Sinalizador
function Qsinal(xnod, hostpage, hostpanel) {
	this.Tipo="SINAL"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Sinal" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Src=GetAtt(xnod, "SRC", "")
	this.Srcid=GetAtt(xnod, "SRCID", "")
	this.Val=""
	this.Values=new Array()
	this.Images=new Array()
	this.Tips=new Array()
	var w=GetAtt(xnod, "VAL", "")
	this.Values=w.split("[")
	w=GetAtt(xnod, "IMG", "")
	this.Images=w.split("[")
	w=GetAtt(xnod, "TIP", "")
	this.Tips=w.split("[")
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)
	var wdiv = document.createElement("IMG")
	wdiv.style.borderStyle="none"
	wdiv.style.borderWidth="0px"
	wdiv.id=this.Hid
	wdiv.style.position="absolute"
	wdiv.style.display="none"
	hostpanel.PanelObj.appendChild(wdiv)
	this.Locsize.Resize(wdiv)
	wdiv.style.zIndex=1
	this.Hobj=wdiv
	if (this.Src == "DBSTATUS") App.Sctls.push(this)
	this.Reset()
}

Qsinal.prototype.Activate=function(opt) {
	this.Show()
}

Qsinal.prototype.Reset=function() {
	if (this.Src == "DBSTATUS") {
		this.Val=App.DbOnline(this.Srcid)
	}
	this.SetVal(this.Val)
}

Qsinal.prototype.SetVal=function(valor) {
	this.Val=valor
	for (var i=0; i<this.Values.length; i++) {
		if (this.Val == this.Values[i]) {
			this.Hobj.src=GetImageAddress(this.Images[i])
			this.Hobj.title=this.Tips[i]
			break
		}
	}
}

Qsinal.prototype.GetVal=function() {
	return this.Val
}

Qsinal.prototype.Disable=function(tipo) {
}

Qsinal.prototype.Enable=function(tipo) {
}

Qsinal.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
}

Qsinal.prototype.Show=function() {
	this.Hobj.style.display="block"
}

Qsinal.prototype.Hide=function() {
	this.Hobj.style.display="none"
}

Qsinal.prototype.OnMouseOver=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.OnMouseOver(id, hnod)
}
Qsinal.prototype.OnMouseOut=function(id, hnod) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.OnMouseOut(id, hnod)
}

Qsinal.prototype.Destroy=function(opt) {
	for (var i=0; i<App.Sctls.length; i++) {
		if (App.Sctls.Id = this.Id) {
			App.Sctls.splice(i,1)
			break
		}
	}
}


//***************************************************************** QMETER - define Meter
function Qmeter(xnod, hostpage, hostpanel) {
	this.Tipo="METER"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Min=GetAtt(xnod, "MIN", 0, "N");
	this.Max=GetAtt(xnod, "MAX", 100, "N");
	this.Val=GetAtt(xnod, "VAL", -99999, "N");
	var wvals=GetAtt(xnod, "LIMITS", "");
	this.Limits=wvals.split("{");
	for (var i=0; i<this.Limits.length; i++) {
		this.Limits[i]=Number(this.Limits[i]);
	}
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "N", "5")
	}
	if (this.Datactl != "") {
		this.DatactlObj.AddFieldCtl(this.Datafld, this)
	}
	this.Hbar=CreateDiv(this.Hobj, this.Hid + "._.BAR", 0, 0, "0%", "100%")
	if (this.Val != -99999) {
		this.SetVal(this.Val);
	} else {
		this.SetState("NORM");
	}
}

Qmeter.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qmeter.prototype.Activate2=function(opt) {}

Qmeter.prototype.Resize=function() {GenericDisplayCtl_Resize.call(this)}

Qmeter.prototype.SetState=function(st) {
	this.Frame.SetState(st);
	this.Hbar.className = this.Frame.StateObj.TxtClass;
}

Qmeter.prototype.SetVal=function(valor) {
	this.Val=ConvertToNative(valor, this.DataCol.Type);
	if (this.Val >= this.Min && this.Val <= this.Max) {
		this.ComputedVal=this.Val * 100 / (this.Max - this.Min);
	} else {
		this.ComputedVal=0;
	}
	this.Hbar.style.width=this.ComputedVal + "%";
	if (this.Limits.length == 0) {
		this.SetState("NORM");
	} else {
		for (var i=0; i<this.Limits.length; i++) {
			if (this.Val <= this.Limits[i]) {
				this.SetState("NORM" + i);
				break;
			}
		}
	}
}

Qmeter.prototype.GetVal=function(valor) {
	return this.Val;
}

Qmeter.prototype.Disable=function() {}
Qmeter.prototype.Enable=function() {}

Qmeter.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qmeter.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qmeter.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qmeter.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qmeter.prototype.OnClick=function() {GenericDisplayCtl_OnClick.call(this)}

Qmeter.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qmeter.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}


//***************************************************************** SHARE - define controlo externo addtoany
function Qshare(xnod, hostpage, hostpanel) {
	this.Tipo="SHARE"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.Tit=GetAtt(xnod, "TIT", hostpage.Tit)
	this.Url=GetAtt(xnod, "URL", "")
	this.SetState("NORM")
	this.Hobj.style.zIndex=0
	this.Hext=CreateDiv(this.Hobj, this.Hid + "._.EXT", this.Locsize.MargL, this.Locsize.MargT, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
	this.Hext.style.zIndex=2
	this.Hext.style.backgroundColor="transparent"
	this.Hext.style.borderColor="transparent"
	this.Hext.style.borderWidth=0
	this.Hext.innerHTML="<a class=\"" + this.Id + " a2a_target\" href=\"http://www.addtoany.com/share_save\"><img src=\"http://static.addtoany.com/buttons/share_save_171_16.png\" border=\"0\" alt=\"Share\"/></a>"
}

Qshare.prototype.Activate=function(opt) {
	GenericDisplayCtl_Activate.call(this)
}

Qshare.prototype.Activate2=function(opt) {
	this.Hext.style.display="block"
	if (this.Url == "") this.Url=api.GetUrl()
	a2a_config.target = "." + this.Id
	a2a_config.linkname = this.Tit
	a2a_config.linkurl = this.Url
    a2a.init("page")
}

Qshare.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Hext.style.left=this.Locsize.MargL + "px"
	this.Hext.style.top=this.Locsize.MargT + "px"
	this.Hext.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Hext.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qshare.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qshare.prototype.Disable=function() {
}
Qshare.prototype.Enable=function() {
}

Qshare.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qshare.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qshare.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qshare.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qshare.prototype.OnClick=function() {GenericDisplayCtl_OnClick.call(this)}

Qshare.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("DBL")
}

Qshare.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qshare.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}




//***************************************************************** HTMLBOX - define caixa de Html ou editor TinyMce
function Qhtmlbox(xnod, hostpage, hostpanel) {
	this.Tipo="HTMLBOX"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.PanelObj=this.Hobj
	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
		this.DataCol=this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol=new Qcol(null, this.Datafld, "A", "255")
	}
	this.ReadOnly=GetAtt(xnod, "READONLY", "N")
	this.ViewAsDiv=GetAtt(xnod, "VIEWASDIV", "N")
	this.Value=""
	this.SetState("NORM")
	this.Hobj.style.zIndex=0

	this.Cont=CreateDiv(this.Hobj, this.Hid + "._.CNT", this.Locsize.MargL, this.Locsize.MargT, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
	this.Cont.style.zIndex=1
	this.Cont.style.backgroundColor="transparent"
	this.Cont.style.borderColor="transparent"
	this.Cont.style.borderWidth=0
	this.Cont.style.MozBoxSizing = "border-box"
	this.Cont.style.WebkitBoxSizing = "border-box"
	this.Cont.style.BoxSizing = "border-box"

	this.Hext=CreateDiv(this.Cont, this.Hid + "._.EXT", 0, 0, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB - 10)
	this.Hext.style.zIndex=1
	this.Hext.style.backgroundColor="transparent"
	this.Hext.style.borderColor="transparent"
	this.Hext.style.borderWidth=0
	this.Hext.style.MozBoxSizing = "border-box"
	this.Hext.style.WebkitBoxSizing = "border-box"
	this.Hext.style.BoxSizing = "border-box"

	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.CmdQueue=new Array()
	this.TinyInstance=null
}

Qhtmlbox.prototype.Activate=function(opt) {
	GenericDisplayCtl_Activate.call(this)
}

Qhtmlbox.prototype.Activate2=function(opt) {
	GenericDisplayCtl_Activate2.call(this)
	this.CmdQueue.push(["CHECKVAL"])
	if (this.ViewAsDiv == "N") {
		if (this.ReadOnly == "S" || this.Disabled == true) {
			this.CreateEditor(true)
		} else {
			this.CreateEditor(false)
		}
	} else {
		if (this.ReadOnly == "N" && this.Disabled == false) this.CreateEditor(false)
	}
}

Qhtmlbox.prototype.InstanceReady=function(inst) {
	this.TinyInstance=inst;
	while (this.CmdQueue.length > 0) {
		var entry=this.CmdQueue[0]
		var cmd=entry[0]  //cada entrada é um array com comando e parametro
		var parm=""
		if (entry.length > 1) parm=entry[1]
		if (cmd == "CHECKVAL") {
			if (this.Value != "") this.SetVal(this.Value)
		}
		if (cmd == "DISABLE") {
			this.Disable(parm)
		}
		if (cmd == "SETREADONLY") {
			this.SetEditorReadOnly(parm)
		}
		this.CmdQueue.splice(0,1)
	}
}

Qhtmlbox.prototype.CreateEditor = function (readonly) {
    if (tinyMCE.settings.plugins.length > 0) {
        tinyMCE.settings.writemodeplugins = tinyMCE.settings.plugins.slice(0)
    }
	if (readonly == true) {
		tinyMCE.settings["readonly"] = 1
	    tinyMCE.settings["visual"] = 0
		tinyMCE.settings["menubar"] = false
		tinyMCE.settings["toolbar"] = false
		tinyMCE.settings.plugins = []
	} else {
		tinyMCE.settings["readonly"] = 0
	    tinyMCE.settings["visual"] = 1
		tinyMCE.settings["menubar"] = true
		tinyMCE.settings["toolbar"] = true
		tinyMCE.settings.plugins = tinyMCE.settings.writemodeplugins.slice(0)
	}
	this.EditorReadOnly=readonly;
	if (this.TinyInstance == null) {
		tinyMCE.execCommand('mceAddEditor', false, this.Hid + "._.EXT")
	}
}

Qhtmlbox.prototype.DestroyEditor=function() {
	if (this.TinyInstance == null) return
	if (this.Hid != undefined)
    {
        tinymce.get(this.Hid + "._.EXT").focus()
        this.Value = this.TinyInstance.getContent()
        tinyMCE.execCommand('mceRemoveEditor', false, this.Hid + "._.EXT")
        this.TinyInstance = null
    }
}

Qhtmlbox.prototype.SetEditorReadOnly=function(opt) {
	if (this.TinyInstance == null) {
		this.CmdQueue.push(["SETREADONLY", opt])
		return
	}
	this.CmdQueue.push(["CHECKVAL"])
	if (opt == true) {
		this.DestroyEditor()
		this.CreateEditor(true)
	} else {
		this.DestroyEditor()
		this.CreateEditor(false)
	}
}

Qhtmlbox.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Cont.style.left=this.Locsize.MargL + "px"
	this.Cont.style.top=this.Locsize.MargT + "px"
	this.Cont.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Cont.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
	this.Hext.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Hext.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB - 10) + "px"
	this.DestroyEditor()
	this.CreateEditor(this.Disabled)
}

Qhtmlbox.prototype.SetState=function(st) {GenericDisplayCtl_SetState.call(this, st)}

Qhtmlbox.prototype.SetVal=function(valor, cmd) {
	this.Value=valor
	if (this.ViewAsDiv == "S" && (this.ReadOnly == "S" || this.Disabled == true)) {
		this.Hext.innerHTML=valor
	} else {
		if (this.TinyInstance == null) {
			this.CmdQueue.push(["CHECKVAL"])
		} else {
			this.TinyInstance.setContent(this.Value)
		}
	}
	if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") {
		this.DatactlObj.StoreVal(this.Datafld, valor, this)
	}
}

Qhtmlbox.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this, tipo)
	if (this.Disabled == true) {
		if (this.ViewAsDiv == "S") {
			if (this.TinyInstance != null) {
				this.DestroyEditor()
			} else {
				this.CmdQueue.push(["DISABLE", tipo])  //faz o disable quando o controlo estiver ready
			}
		} else {
			if (this.EditorReadOnly == false) this.SetEditorReadOnly(true)
		}
	}
}

Qhtmlbox.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) {
		if (this.ReadOnly == "S") return
		this.SetEditorReadOnly(false)
	}
}

Qhtmlbox.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qhtmlbox.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qhtmlbox.prototype.Destroy=function(opt) {
    if (this.Hid != undefined && this.TinyInstance != null) {
        tinymce.get(this.Hid + "._.EXT").focus()
        tinyMCE.execCommand('mceRemoveEditor', false, this.Hid + "._.EXT")
    }
    this.Hobj.removeChild(this.Cont)
    this.Cont.removeChild(this.Hext)
    GenericDisplayCtl_Destroy.call(this, opt)
}

Qhtmlbox.prototype.Destroy2=function() {GenericDisplayCtl_Destroy2.call(this)}

Qhtmlbox.prototype.OnClick=function() {GenericDisplayCtl_OnClick.call(this)}

Qhtmlbox.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.HostPanel.Tipo == "DATAPANEL") this.HostPanel.Select("DBL")
}

Qhtmlbox.prototype.OnMouseOver=function(id, hnod) {
	GenericDisplayCtl_OnMouseOver.call(this, id, hnod)
}

Qhtmlbox.prototype.OnMouseOut=function(id, hnod) {
	GenericDisplayCtl_OnMouseOut.call(this, id, hnod)
}

Qhtmlbox.prototype.OnBlur=function() {   //este evento é despoletado por um script na pagina de startup
	if (AllInputBlocked == true) return
	if (this.HostPage.Area.ActivePage != this.HostPage) return   //o evento é despoletado para todos os editores, é preciso ver se esta pagina está activa
	if (this.TinyInstance != null) {
		var valor = this.TinyInstance.getContent()
		if (this.Datactl != "" && this.ReadOnly != "S") {
			this.DatactlObj.StoreVal(this.Datafld, valor, this)
		}
	}
}

function HtmlBoxInit(inst) {
	var ctl=GetCtlByHid(inst.target.id)
	if (ctl != null) ctl.InstanceReady(inst.target)
}

function HtmlBoxBlur() {  //esta função é invocada no script do TinyMCE na pagina de startup quando um editor tinymce perde o focus
	for (edId in tinyMCE.editors) {
		var ctl=GetCtlByHid("" + edId)
		if (ctl != null) ctl.OnBlur()
	}
}




//***************************************************************** EXTCTL - define controlo com script externo
function Qextctl(xnod, hostpage, hostpanel) {
	this.Tipo="EXTCTL"
	this.Class="DISPLAY"
	GenericDisplayCtl_ConstructIni.call(this, xnod, hostpage, hostpanel)
	this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "100,20"), this.HostPanel)
	this.Hobj=CreateDiv(this.HostPanel.PanelObj, this.Hid)
	this.PanelObj=this.Hobj
	this.Value=""
	this.Invoke("INITIALIZE", this.Id, this.Hid, hostpage.Area.Id)
	this.Resize()
}

Qextctl.prototype.Invoke=function(evt, parm1, parm2, parm3) {
	var parm=""
	if (parm1 != undefined) parm +="'" + parm1 + "'"
	if (parm2 != undefined) parm +=", '" + parm2 + "'"
	if (parm3 != undefined) parm +=", '" + parm3 + "'"
	var r=""
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == evt) {
			try {eval("r=" + this.Events[i].Act + "(" + parm + ")")}
			catch(exp) {window.alert(GetMsg(1, "Erro na invocação do " + evt + " do EXTCTL (" + this.Id + ")"))}
		}
	}
	return r
}

Qextctl.prototype.Activate=function(opt) {
	this.Activated=true
	this.Invoke("ACTIVATE")
	this.Show()
}

Qextctl.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
	this.Invoke("RESIZE", this.Locsize.ObjW, this.Locsize.ObjH)
}

Qextctl.prototype.Execute=function(act, parm) {
	this.Invoke(act, parm)
}

Qextctl.prototype.SetVal=function(valor, cmd) {
	this.Value=valor
	this.Invoke("SETVAL", valor)
}

Qextctl.prototype.GetVal=function() {
	this.Value=this.Invoke("GETVAL")
	return this.Value
}

Qextctl.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	this.Disabled=true
	this.Invoke("DISABLE")
}

Qextctl.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		this.Disabled=false
		this.Invoke("ENABLE")
	}
}

Qextctl.prototype.Show=function(opt) {
	if (this.Activated == false) {
		this.Activate()
		return
	}
	this.Hobj.style.display="block"
	this.Invoke("SHOW")
	this.Visible=true
}

Qextctl.prototype.Hide=function(opt) {
	this.Invoke("HIDE")
	this.Visible=false
	this.Hobj.style.display="none"
}

Qextctl.prototype.Destroy=function(opt) {
	this.Hide()
	this.Invoke("DESTROY")
	GenericDisplayCtl_RemoveFromParent(this.HostPanel, this)
	if (this.Hobj != null) {
		var wparent=this.Hobj.parentNode;
		if (wparent != null) wparent.removeChild(this.Hobj);
	}
}



//***************************************************************** QFILECTL - define Controlo de ficheiros e versões
function Qfilectl(xnod, hostpage, hostpanel, datacol, readonly, list) {
	this.Tipo="FILECTL"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Grpctls=new Array()
	this.Actls=new Array()
	this.Dados=new Array()
	this.Events = new Array()
	this.Botoes = new Array()
	this.Tipo4Style=this.Tipo
	this.InitialFocus="N"
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="FileCtl" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=null
	if (this.Datactl != "") {
		this.DatactlObj=hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "FILECTL (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
	}
	this.Datafld = GetAtt(xnod, "DATAFLD", "")
	if (this.Datactl != "") {
	    this.DataCol = this.DatactlObj.GetCol(this.Datafld)
	} else {
	    this.DataCol = new Qcol(null, this.Datafld, "A", "255")
	}
	this.Operations = new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		} else {
			this.Operations[xn.nodeName] = new Object()
			this.Operations[xn.nodeName].ACT = GetAtt(xn, "ACT", "")
			this.Operations[xn.nodeName].VIS = GetAtt(xn, "VIS", "S")
		}
		xn=xn.nextSibling
	}
	this.Tip=GetAtt(xnod, "TIP", "")
	this.Prot=GetAtt(xnod, "PROT", "N")
	this.Nivseg=GetAtt(xnod, "NIVSEG", hostpanel.Nivseg)
	this.Visivel=GetAtt(xnod, "VIS", "S")
	this.Style=GetAtt(xnod, "STYLE", hostpanel.Style)
	this.Location=GetAtt(xnod, "LOCATION", "0,0")
	this.Size=GetAtt(xnod, "SIZE", "0,0")
	var wvals=GetAtt(xnod, "VAL", "")
	this.ReadOnly=GetAtt(xnod, "READONLY", "N")
	this.InitialFocus=GetAtt(xnod, "FOCUS", "N")
	if (this.InitialFocus == "S") this.HostPage.InitialFocusSet=true
	this.Provider = this.DatactlObj.Provider

	this.Source = GetAtt(xnod, "SOURCE", "")//Novo atributo definido para indicar a fonte de dados do controlo, fonte essa correspondente à key e nome da tabela que utiliza os docums.
	var sources=this.Source.split(",")
	this.DocFK=sources[0]
	var Aw=sources[1].split(".")
	this.DocArea=Aw[0]
	this.DocK=Aw[1]

	this.Locsize=new QlocSize(this.Location, this.Size, this.HostPanel)
	var wdiv=CreateDiv(this.HostPanel.PanelObj, this.Hid)
	wdiv.style.display="none"
	this.Locsize.Resize(wdiv)
	this.Hobj=wdiv
	this.Tipo4Style=hostpanel.Tipo + "." + this.Tipo4Style
	this.StyleObj=App.GetStyle(this.Style, this.Tipo4Style)
	this.Frame=new Qframe(this)
	wdiv.style.zIndex=1
	if (this.Tip != "") wdiv.title=this.Tip
	var wtxt=CreateDiv(wdiv, this.Hid + "._.TXT", this.Locsize.MargL + 1, this.Locsize.MargT + 2, this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR, this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB)
	wtxt.style.backgroundColor="transparent"
	wtxt.style.borderWidth="0px"
	wtxt.style.cursor="pointer"
	SetUnselectable(wtxt)
	this.Hobj.appendChild(wtxt)
	this.Htxt = wtxt

	this.Hbot = document.createElement("IMG")
	this.Hbot.style.position = "absolute"
	this.Hbot.src = GetImageAddress("fcontrol_seta.png")
	this.Hbot.style.zIndex = 2
	this.Hbot.style.cursor = "pointer"
	this.Hbot.style.top = "3px"
	this.Hbot.style.left = (this.Locsize.ObjW - 17) + "px"
	this.Hbot.style.width = "10px"
	this.Hbot.style.height = "10px"
	this.Hbot.id = this.Hid + "._.BOT"
	this.Hbot.onclick = EvtClick
	this.Hobj.appendChild(this.Hbot)

	this.Hobj.tabIndex=this.HostPage.TabIndexBase + fieldtabindex
	this.SetState("NORM")
	/*
	//Inicialização das Cols do controlo que correspondem a três valores, código do tuplo na tabela que utiliza os docums, a fk e o nome do ficheiro nessa tabela.
	var sources=this.Source.split(",")
	this.Cols=new Array()
	var wcol=new Qcol(null, this.Datafld, "A", "16")
	wcol.Key="S"
	this.Cols.push(wcol)
	var wcol=new Qcol(null, sources[0], "A", "16")
	this.Cols.push(wcol)
	wcol.Index=1
	var wcol=new Qcol(null, sources[1], "A", "16")
	this.Cols.push(wcol)
	wcol.Index=2
	*/

	this.ContextPanel=null
	this.ContextPanel2=null
	wdiv.onblur=EvtBlur
	wdiv.onfocus=EvtFocus
	wdiv.onclick=EvtClick
	wdiv.ondoubleclick=EvtDblClick
	wdiv.onkeydown=EvtKeyDown
	this.Disabled=false
	if (this.Prot == "S") this.Disable("PROT")
	if (this.Nivseg != "") {
		if (User.ModAutorizado(this.HostPage.Modulo, this.Nivseg) == false) this.Disable("NIVSEG")
	}
	if (this.Datactl != "") this.DatactlKey=this.DatactlObj.AddFieldCtl(this.Datafld, this)
	this.Visible=true
	if (this.Visivel == "N") this.Visible=false
	this.Activated = false
	this.MouseIsOver=false
	this.MouseIsOver2=false
	this.Func="FCT2"
	this.Opt="Info"
	this.Value=""
	this.FileKey=""
	this.FileName=""
	this.FileSize=""
	this.FileExt=""
	this.FileAut=""
	this.FileDate=""
	this.FileVers=""
	this.FileStatus=""
	this.FileUser=""
	this.VersNum=new Array()
	this.VersKey = new Array()
	this.SelectedVers=-1
	this.LastVers=""
	this.SubmitFileName=""
	this.SubmitOption=""
	this.SubmitVersion=""
	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
}

Qfilectl.prototype.Activate=function(opt) {GenericDisplayCtl_Activate.call(this)}
Qfilectl.prototype.Activate2=function(opt) {
	if (this.InitialFocus == "S") this.Focus()
}

Qfilectl.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	this.Htxt.style.width=(this.Locsize.ObjW - this.Locsize.MargL - this.Locsize.MargR) + "px"
	this.Htxt.style.height=(this.Locsize.ObjH - this.Locsize.MargT - this.Locsize.MargB) + "px"
}

Qfilectl.prototype.SetState=function(st) {
	if (this.HostDataPanel == null) {
		if (st == "HIGH" || st == "SELE") return
	}
	GenericDisplayCtl_SetState.call(this, st)
	this.Htxt.className = this.Frame.StateObj.TxtClass
}

Qfilectl.prototype.SetVal = function(valor, cmd) {
    if (valor == "") {
        this.Opt = "Anexar"
        this.Htxt.innerHTML = MsgSet[44]
        this.Value=""
        return
    }
    this.Value = valor
    //se o valor == "" deveria mostrar as opções Digitalizar, Imagens e Template se estiverem marcadas como visiveis
    if (this.Datactl != "" && this.Disabled == false && cmd == "SAVE") {
        this.DatactlObj.StoreVal(this.Datafld, valor, this);
    }
    this.Opt = "Info"
    this.Send()
}

Qfilectl.prototype.GetVal = function(opt) {
    return this.Value
}

Qfilectl.prototype.Execute = function(act, opt1, opt2, opt3) {
    if (act == "AbrirClicked") {
        this.Opt = "Abrir";
        this.Send();
    }
    if (act == "AbrirVersClicked") {
        this.Opt = "AbrirVers";
        this.SelectedVers = -1
        var wopt=Number(opt1)
        for (var v = 0; v < this.VersNum.length; v++) {
            if (this.VersNum[v] == wopt) {
                this.SelectedVers = v
                break
            }
        }
        this.Send();
    }
    if (act == "EditarClicked") {
        var status=""
        this.Opt = "Edit"
        status=this.Send("SYNC")
        if (status != "OK") return
        this.Opt = "Info";
        status=this.Send("SYNC")
        if (status != "OK") return
        this.Opt = "Abrir";
        this.Send()
    }
    if (act == "SubmeterClicked") {
        var status=""
        this.Opt = "Vers"
        status=this.Send("SYNC")
        if (status != "OK") return
        var url = GetServiceAddress("UPLOADFC") + "?L=" + User.Language + "&M=subm&F=" + this.LastVers
        this.UploadPanel = new Qupload(this, url, 400, 300)
        this.Actls.push(this.UploadPanel)
        this.UploadPanel.Activate()
    }
    if (act == "EliminarClicked") {
        var answer = confirm(MsgSet[65])
        if (answer) {
            this.Opt = "Remo";
            this.Send();
        }
        return
    }
    if (act == "AnexarClicked") {
        this.Opt = "Anexar"
        if (this.ContextPanel != null) this.HideList()
        var url = GetServiceAddress("UPLOADFC") + "?L=" + User.Language + "&M=anex&F=" + this.FileName
        this.UploadPanel = new Qupload(this, url, 400, 300)
        this.Actls.push(this.UploadPanel)
        this.UploadPanel.Activate()
        return
    }
    if (act == "DigitalizarClicked") {
        var waction = this.Operations["FDIGITALIZAR"].ACT
        ExecCmd(this.HostPage.Area, waction)
    }
    if (act == "ImagensClicked") {
        var waction = this.Operations["FIMAGES"].ACT
        ExecCmd(this.HostPage.Area, waction)
    }
    if (act == "TemplateClicked") {
        var waction = this.Operations["FTEMPLATE"].ACT
        ExecCmd(this.HostPage.Area, waction)
    }
    if (act == "MoreClicked") {

    }
    if (act == "DelLastClicked") {
        var answer = confirm(MsgSet[63])
        if (answer) {
            this.Opt = "DelU";
            this.Send();
        }
        return
    }
    if (act == "DelHistClicked") {
        var answer = confirm(MsgSet[64])
        if (answer) {
            this.Opt = "DelH";
            this.Send();
        }
        return
    }
    if (act == "VersoesClicked") {
        this.ShowList2()
        this.MouseIsOver = true
        return
    }
    if (act == "PropriedadesClicked") {
        var w = ""
        w += MsgSet[37] + this.FileName + "\r\n"
        w += MsgSet[38] + this.FileSize + "\r\n"
        w += MsgSet[39] + this.FileExt + "\r\n"
        w += MsgSet[40] + this.FileAut + "\r\n"
        w += MsgSet[41] + this.FileDate + "\r\n"
        w += MsgSet[42] + this.FileVers + "\r\n"
        alert(w)
        return
    }
    if (act == "EndUpload") {
        //opt1 contem a função  Ex: Anexar     opt2 contem filename/option/version
        var Aw=opt2.split("/")
    	this.SubmitFileName=Aw[0]
    	this.SubmitOption=Aw[1]
    	this.SubmitVersion=Aw[2]
        if (opt1 == "Anexar") {
        	this.Opt=opt1
        	this.Send();
        }
        if (opt1 == "Subm") {
        	this.Opt=opt1
        	this.Send();
        }
        return
    }
    if (act == "HideList") {
        if (this.ContextPanel != null) this.HideList()
        return
    }
    if (act == "Blur") {
        this.OnBlur2()
        return
    }
    if (act == "DetOut") {
        if (this.MouseIsOver2 == false) this.HideList2()
        if (this.MouseIsOver == false) this.HideList()
        return
    }
}

Qfilectl.prototype.Disable = function(tipo) {
    if (tipo == "HIST") return;  //este controlo recebe um disable do form por historial por causa do coddocum mas é para ignorar
      GenericDisplayCtl_Disable.call(this, tipo)
    if (this.Disabled == true) this.Htxt.style.cursor = "default"
}

Qfilectl.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this, tipo)
	if (this.Disabled == false) this.Htxt.style.cursor="pointer"
}

Qfilectl.prototype.Show=function(opt) {GenericDisplayCtl_Show.call(this, opt)}

Qfilectl.prototype.Hide=function(opt) {GenericDisplayCtl_Hide.call(this, opt)}

Qfilectl.prototype.ShowErr=function(msg) {GenericDisplayCtl_ShowErr.call(this, msg)}

Qfilectl.prototype.HideErr=function(msg) {GenericDisplayCtl_HideErr.call(this)}

Qfilectl.prototype.ShowList = function() {
    var offset = GetOffsetFor("APP", this.HostPanel)
    var wheight = 0
    var botoes = new Array()
    var botext = new Array()
    if (this.FileName != "") {
        if (this.Prot == "S" || this.ReadOnly == "S") {
            botoes.push("Abrir")
            botext.push(MsgSet[25])
            wheight += 20
            botoes.push("Versoes")
            botext.push(MsgSet[31])
            wheight += 20
            botoes.push("Sep")
            botext.push("")
            wheight += 1
            botoes.push("Propriedades")
            botext.push(MsgSet[33])
            wheight += 20
        } else {
			botoes.push("Abrir")
            botext.push(MsgSet[25])
            wheight += 20
            if (this.FileStatus == "") {
                botoes.push("Editar")
                botext.push(MsgSet[29])
                wheight += 20
                if (this.VersNum.length > 1) {
                    botoes.push("Versoes")
                    botext.push(MsgSet[31])
                    wheight += 20
                }
                botoes.push("Eliminar")
                botext.push(MsgSet[32])
                wheight += 20
            }
            if (this.FileStatus == "COMMIT") {
                botoes.push("Submeter")
                botext.push(MsgSet[30])
                wheight += 20
            }
            botoes.push("Sep")
            botext.push("")
            wheight += 1
            botoes.push("Propriedades")
            botext.push(MsgSet[33])
            wheight += 20
        }
    } else {
        if (this.Prot == "S" || this.ReadOnly == "S") {

        } else {
            botoes.push("Anexar")
            botext.push(MsgSet[26])
            wheight += 20
            if (this.Operations["FDIGITALIZAR"].VIS == "S") {
                botoes.push("Digitalizar")
                botext.push(MsgSet[27])
                wheight += 20
            }
            if (this.Operations["FIMAGES"].VIS == "S") {
                botoes.push("Imagens")
                botext.push("Fonte Imagens") //####### devia estar uma mensagem de tradução em vez de um literal
                wheight += 20
            }
            if (this.Operations["FTEMPLATE"].VIS == "S") {
                botoes.push("Template")
                botext.push(MsgSet[28])
                wheight += 20
            }
        }
    }
    var xstr = "<PANEL STYLE=\"" + this.Style + "\" LOCATION=\"" + (this.Locsize.ObjL - this.HostPage.Locsize.MargL + offset.Left) + "," + (this.Locsize.ObjT - this.HostPage.Locsize.MargT + this.Locsize.ObjH + offset.Top) + "\" SIZE=\"90," + (wheight + 4) + "\">"
    var wtop = 0
    for (var i = 0; i < botoes.length; i++) {
        if (botoes[i] == "Sep") {
            xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,1\" DATACTL=\"" + this.Id + "\" STYLE=\"SEPARATOR\" PROT=\"S\"/>"
            wtop += 1
        } else {
            if (botoes[i] == "Versoes") {
                xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,20\" DATACTL=\"" + this.Id + "\" STYLE=\"MOREOPT\" TXT=\"" + botext[i] + "\" ACT=\"Execute(" + this.Id + "," + botoes[i] + "Clicked\" />"
            } else {
                xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,20\" DATACTL=\"" + this.Id + "\" STYLE=\"" + this.Style + "\" TXT=\"" + botext[i] + "\" ACT=\"Execute(" + this.Id + "," + botoes[i] + "Clicked\" />"
            }
            wtop += 20
        }
    }
    xstr += "</PANEL>"

    var xnod = CreateXnode(xstr)
    this.ContextPanel = new Qitempanel(xnod, this.HostPage, App, this, "FILECTL.DROPPANEL", null, null, 50, 50, 50, wheight)
    this.ContextPanel.Hobj.style.zIndex = 10
    var maxdown = offset.ParentObj.Locsize.ObjH - offset.Top - this.Locsize.ObjT - this.Locsize.ObjH - 10
    var maxup = offset.Top - 10
    var direction = "down"
    var maxh = wheight
    if (maxdown >= wheight) {
        direction = "down"
    } else {
        if (maxup >= wheight) {
            direction = "up"
        } else {
            if (maxdown >= maxup) {
                direction = "down"
                maxh = maxdown
            } else {
                direction = "up"
                maxh = maxup
            }
        }
    }
    this.ContextPanel.SetSize("90," + maxh)
    if (direction == "down") {
        this.ContextPanel.SetLocation((this.Locsize.ObjL + this.Locsize.ObjW - 90 - this.HostPage.Locsize.MargL + offset.Left) + "," + (this.Locsize.ObjT - this.HostPage.Locsize.MargT + this.Locsize.ObjH + offset.Top))
    } else {
        this.ContextPanel.SetLocation((this.Locsize.ObjL + this.Locsize.ObjW - 90 - this.HostPage.Locsize.MargL + offset.Left) + "," + (offset.Top - maxh - this.HostPage.Locsize.MargT + this.Locsize.ObjT))
    }
    this.ContextPanel.Resize()
    this.ContextPanel.Activate()
    this.Actls.push(this.ContextPanel)
}

Qfilectl.prototype.ShowList2 = function() {
    var offset = GetOffsetFor("APP", this.ContextPanel)
    var wheight = 0
    var botoes = new Array()
    var botext = new Array()
    botoes.push("More")
    botext.push(MsgSet[34])
    wheight += 20
    botoes.push("Sep")
    botext.push("")
    wheight += 1
    for (var v=0; v<this.VersNum.length; v++) {
        botoes.push("AbrirVers")
        botext.push("" + this.VersNum[v])
        wheight += 20
    }
    botoes.push("Sep")
    botext.push("")
    wheight += 1
    botoes.push("DelLast")
    botext.push(MsgSet[35])
    wheight += 20
    botoes.push("DelHist")
    botext.push(MsgSet[36])
    wheight += 20

    var xstr = "<PANEL STYLE=\"" + this.Style + "\" LOCATION=\"" + (offset.Left + 90) + "," + (offset.Top + 40) + "\" SIZE=\"90," + (wheight + 4) + "\">"
    var wtop = 2
    for (var i = 0; i < botoes.length; i++) {
        if (botoes[i] == "Sep") {
            xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,1\" DATACTL=\"" + this.Id + "\" STYLE=\"SEPARATOR\" PROT=\"S\"/>"
            wtop += 1
        } else {
            if (botoes[i] == "AbrirVers") {
                xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,20\" DATACTL=\"" + this.Id + "\" STYLE=\"" + this.Style + "\" TXT=\"" + botext[i] + "\" ACT=\"Execute(" + this.Id + "," + botoes[i] + "Clicked," + botext[i] + "\" />"
            } else {
                xstr += "<BOTAO LOCATION=\"0," + wtop + "\" SIZE=\"*,20\" DATACTL=\"" + this.Id + "\" STYLE=\"" + this.Style + "\" TXT=\"" + botext[i] + "\" ACT=\"Execute(" + this.Id + "," + botoes[i] + "Clicked\" />"
            }
            wtop += 20
        }
    }
    xstr += "</PANEL>"

    var xnod = CreateXnode(xstr)
    this.ContextPanel2 = new Qitempanel(xnod, this.HostPage, App, this, "FILECTL.DROPPANEL", null, null, 50, 50, 50, wheight)
    this.ContextPanel2.Hobj.style.zIndex = 11
    var maxh = wheight
    var wtop = offset.Top + 40
    var maxdown = offset.ParentObj.Locsize.ObjH - offset.Top - 40
    var maxup = offset.Top - 40
    var wrodape=wheight-maxdown
    if (wrodape > 0) {
        if (wrodape > maxup) {
            maxh=wheight-offset.ParentObj.Locsize.ObjH-40
            wtop=20
        } else {
            wtop=wtop - wrodape - maxdown - 20
        }
    }
    this.ContextPanel2.SetSize("90," + maxh)
    this.ContextPanel2.SetLocation((offset.Left + 90) + "," + (wtop))
    this.ContextPanel2.Resize()
    this.ContextPanel2.Activate()
    this.Actls.push(this.ContextPanel2)
}


Qfilectl.prototype.HideList = function() {
    if (this.ContextPanel == null) return
    this.ContextPanel.Destroy()
    this.ContextPanel = null
}

Qfilectl.prototype.HideList2 = function() {
    if (this.ContextPanel2 == null) return
	this.ContextPanel2.Destroy()
	this.ContextPanel2=null
}

Qfilectl.prototype.Destroy=function(opt) {GenericDisplayCtl_Destroy.call(this, opt)}

Qfilectl.prototype.Destroy2=function() {
	if (this.DatactlKey != undefined) this.DatactlObj.DestroyUnit(this.DatactlKey)
	GenericDisplayCtl_Destroy2.call(this)
	this.Hobj=null
	this.Hopt=null
}

Qfilectl.prototype.OnClick=function(id, hnod, keys) {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) {
		if (this.HostDataPanel.Tipo.indexOf("AUTOQUERYPANEL") == -1) this.HostDataPanel.Select("CLK", keys)
	}
	if (this.Disabled == true || this.ReadOnly == "S") return
	this.Hobj.focus()
	if (id.indexOf("._.BOT") > -1) {  //Click na seta
	    if (this.ContextPanel == null) {
	        this.ShowList()
	    } else {
	        this.HideList()
	    }
	    return
	}
	//Click no controlo
	if (this.Opt == "Anexar") {
	    this.Execute("AnexarClicked")
	} else {
	    this.Execute("AbrirClicked")
	}
}

Qfilectl.prototype.OnDblClick=function() {
	if (AllInputBlocked == true) return
	if (this.HostDataPanel != null) this.HostDataPanel.Select("DBL")
}

Qfilectl.prototype.OnFocus=function() {
	if (AllInputBlocked == true) return
	GenericDisplayCtl_OnFocus.call(this)
	if (this.Disabled == true) return
	if (this.HostDataPanel != null && this.ReadOnly != "S") {
		this.LastState = this.Frame.GetStateId()
		this.SetState("EDIT")
	}
}

Qfilectl.prototype.DetOver = function(panel) {
    if (panel == this.ContextPanel2) this.MouseIsOver2=true
    this.MouseIsOver=true
}

Qfilectl.prototype.DetOut = function(panel) {
    if (panel == this.ContextPanel2) {
        if (this.ContextPanel2 == null) return
        this.MouseIsOver2 = false
        this.MouseIsOver = false
        ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",DetOut")
        return
    }
    if (this.ContextPanel == null) return
    this.MouseIsOver = false
    ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",DetOut")
}

Qfilectl.prototype.OnBlur=function() {
	if (AllInputBlocked == true) return
	ExecCmdDelayed(40, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",Blur")  //esperar um pouco para ver se foi clique num botao
}

Qfilectl.prototype.OnBlur2=function() {
	if (this.MouseIsOver == true || this.MouseIsOver2 == true) {
		return
	}
	GenericDisplayCtl_OnBlur.call(this)
	if (this.ContextPanel != null) ExecCmdDelayed(200, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",HideList")
	if (this.Disabled == true) return
	if (this.HostDataPanel != null && this.ReadOnly != "S") this.SetState(this.LastState)
}

Qfilectl.prototype.Focus=function() {GenericDisplayCtl_Focus.call(this)}

Qfilectl.prototype.OnKeyDown=function(wkey, evt) {
	if (AllInputBlocked == true) return
	if (this.Disabled == true || this.ReadOnly == "S") return
	var keyused = false     //determinar se foi usada uma tecla útil
	if (wkey == 39 || wkey == 40) {  //proximo
		keyused=true
		if (this.Dados.length > 0) {
			if (this.SelectedKeys.length == 0) {
				this.SetVal(this.Dados[0].Key, "SAVE")
			} else {
				for (var i=0; i<this.Dados.length; i++) {
					if (this.SelectedKeys[0] == this.Dados[i].Key) {
						if ((i+1) < this.Dados.length) {
							this.SetVal(this.Dados[i+1].Key, "SAVE")
							break
						}
					}
				}
			}
		} else {
			this.SetVal("", "SAVE")
		}
	} else {
		if (wkey == 37 || wkey == 38) {  //anterior
			keyused=true
			if (this.Dados.length > 0) {
				if (this.SelectedKeys.length == 0) {
					this.SetVal(this.Dados[this.Dados.length-1].Key, "SAVE")
				} else {
					for (var i=0; i<this.Dados.length; i++) {
						if (this.SelectedKeys[0] == this.Dados[i].Key) {
							if (i > 0) {
								this.SetVal(this.Dados[i-1].Key, "SAVE")
								break
							}
						}
					}
				}
			} else {
				this.SetVal("", "SAVE")
			}
		} else {
			if (wkey == 46) {  //delete key
				this.SetVal("", "SAVE")
			}
		}
	}
	if (keyused == true) {  //se foi uma tecla já tratada impedir que o browser interprete mais esta tecla
        if (BrowserIE) {
            window.event.returnValue = false;
        } else {
            evt.preventDefault();
        }
    }
}

Qfilectl.prototype.OnMouseOver=function(id, hnod) {GenericDisplayCtl_OnMouseOver.call(this, id, hnod)}

Qfilectl.prototype.OnMouseOut=function(id, hnod) {GenericDisplayCtl_OnMouseOut.call(this, id, hnod)}

Qfilectl.prototype.Send=function(synchopt) {
	if (this.Provider == "") return;
	var iblk=new Interblk();
	iblk.APP=this.Provider;
	iblk.IDENT=this.Id;
	iblk.MOD=User.GetModDb(this.HostPage.Modulo);
	iblk.FUNC=this.Func;
	iblk.FICH = ""
	iblk.COND = this.Datafld + "[=['" + this.Value + "'"
	var wrec=new Array();
	if (this.Opt == "Abrir") {
		iblk.CMPS.push("CodDocums")
		wrec.push(this.FileKey)
	}
	if (this.Opt == "AbrirVers" || this.Opt == "Abrir") {
		this.Opt="Abrir"
		iblk.CMPS.push("CodDocums")
		if (this.Opt == "Abrir") {
			wrec.push(this.FileKey)
		} else {
			wrec.push(this.VersKey[this.SelectedVers])
		}
	} else {
		//iblk.CMPS.push("DocArea")
		//wrec.push(this.DocArea)
		iblk.CMPS.push("DocFieldName")
		wrec.push(this.DocK)
	}
	if (this.Opt == "Anexar") {
		iblk.CMPS.push("FileName")
		wrec.push(this.SubmitFileName)
	}
	if (this.Opt == "Submit") {
		iblk.CMPS.push("FileName")
		wrec.push(this.SubmitFileName)
		iblk.CMPS.push("Option")
		wrec.push(this.SubmitOption)
		iblk.CMPS.push("Version")
		wrec.push(this.SubmitVersion)
	}
	iblk.DADOS.push(wrec);

	/*
	var histgetid="";
	var histop="";
	var hix=-1;
	var area=this.HostPage.Area;
	var niv=area.Pages.length;
    var wrec=new Array();
    var wval="";
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i];
        iblk.CMPS.push(col.Id)
        wval=this.Dados[i];
        wrec.push(wval);
	}
    iblk.DADOS.push(wrec);
    iblk.COND = this.Datafld + "[=['" + this.Value + "'"
	iblk.FICH = ""
	if (this.Opt == "Abrir" || this.Opt == "Edit") { //o novo atributo FICH fica com a key do ficheiro actual para enviar para o server.
		iblk.FICH=this.FileKey
    }
    if (this.Opt == "Edit") { //o novo atributo FICH fica com a key do ficheiro actual para enviar para o server.
		iblk.FICH=this.FileKey
    }
    if (this.Opt == "AbrirVers") { //o atributo FICH fica com a key do ficheiro actual para enviar para o server.
        iblk.FICH = this.VersKey[this.SelectedVers]
        this.Opt="Abrir"
    }
	if (this.Opt == "Subm") { //O atributo FICH fica com o nome do ficheiro a submeter que está na pasta temp.
		iblk.FICH=this.FileKey
	}
	if (this.Opt == "Anexar") {
		iblk.FICH=this.FileName
    }
    */

    iblk.MSG = this.Opt

    if (synchopt == "SYNC") {    //se o pedido foi sincrono
	    iblk=SendServerSync(this.HostPage, iblk);
	    this.Receive(iblk, "OK")
	    return iblk.STAT;
    }
    SendServer(this.HostPage, iblk, "SINGLE");
}

Qfilectl.prototype.Receive = function(iblk, gstatus) {
	if (iblk.STAT == "E" || iblk.STAT == "EW") {
		if (iblk.STAT == "EW") this.HostPage.ShowWarning(iblk.MSG);
		return;
	}
	if (iblk.STAT != "E" && iblk.STAT != "EW") {
	    var wrec = iblk.DADOS[0];
	    this.Dados = new Array();
	    for (var i = 0; i < wrec.length; i++) {
	        this.Dados.push(wrec[i]);
	    }
	}
    switch (this.Opt) {
        case "Anexar":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[61])
                return
            }
            this.GetFileInfo(this.Dados)
            this.DatactlObj.StoreVal(this.DocFK, this.FileKey);
            break;
        case "Info":
        	this.GetFileInfo(this.Dados)
            break;
        case "Abrir":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[58])
                return
            }
            var wticket = this.Dados[0]
            var wurl = CriarLinkRecurso("ticket:" + wticket)
            api.DoDownload(wurl)
            break;
        case "Vers":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[58])
                return
            }
            this.LastVers=this.Dados[0] + "|" + this.Dados[1]
            /*
            var widados = this.Dados[0] + "[" + this.Dados[1] + "[" + this.Dados[2]
            ExecCmd(App.Apage.Id, "SetHistorial(lastVersion," + widados + ",EQ")
            ExecCmd(App.Apage.Id, "OpenDialog(QwRSUBMIT,ALT")
            */
            break;
        case "DelU":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[59])
                return
            }
            this.Opt = "Info"
            this.Send()
            break;
        case "DelH":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[60])
                return
            }
            this.Opt = "Info"
            this.Send()
            break;
        case "Edit":
            break;
        case "Subm":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[61])
                return
            }
            this.Opt = "Info"
            this.Send()
            break;
        case "Remo":
            if (iblk.STAT == "E" && iblk.STAT == "EW") {
                alert(MsgSet[62])
                return
            }
            this.SetVal("", "SAVE")
            break;
    }
}

Qfilectl.prototype.GetFileInfo = function(dados) {
    if (dados.length <= 1) {
        this.FileName = ""
        this.FileSize = ""
        this.FileExt = ""
        this.FileAut = ""
        this.FileDate = ""
        this.FileVers = ""
        this.FileKey = ""
        this.FileStatus = ""
        this.FileUser = ""
        this.VersNum=new Array()
        this.VersKey=new Array()
        this.Htxt.innerHTML = this.FileName
        this.Opt = "Anexar"
        this.Htxt.innerHTML = MsgSet[44]
        return;
    }
    this.FileName = dados[0]
    this.FileSize = dados[1]
    this.FileExt = dados[2]
    this.FileAut = dados[3]
    this.FileDate = dados[4]
    this.FileVers = dados[5]
    this.FileKey = dados[6]
    this.FileStatus = dados[7]
    this.FileUser = dados[8]
    var Aw=dados[9].split("|")
    this.VersNum=new Array()
    this.VersKey=new Array()
    var Avers = Aw[1].split("[")
    for (var v = 0; v < Avers.length; v++) {
        var Avw = Avers[v].split(":")
        this.VersNum.push(Avw[0])
        this.VersKey.push(Avw[1])
    }
    this.Htxt.innerHTML = this.FileName
    if (this.FileStatus == "") this.SetState("NORM");
    if (this.FileStatus == "COMMIT") this.SetState("ONED");
    if (this.FileStatus == "CHECKOUT") this.SetState("LOCK");
}


//***************************************************************** RIBBON - define controlo de Ribbon usando DHX (Dhtmlx)
function Qribbon(xnod, hostpage, hostpanel) {
	this.Tipo="RIBBON"
	this.Class="DISPLAY"
	GenericDisplayCtl_Construct.call(this, xnod, hostpage, hostpanel)
	this.DatactlObj.Grpctls.push(this)
	this.Actls=new Array()
	this.PanelObj=this.Hobj
	this.Ribbon=null;
	this.Resize()
}

Qribbon.prototype.Activate=function(opt) {
	GenericDisplayCtl_Activate.call(this, opt)
}

Qribbon.prototype.Activate2=function(opt) {
	GenericDisplayCtl_Activate2.call(this, opt)
}

Qribbon.prototype.Resize=function() {
	GenericDisplayCtl_Resize.call(this)
	if (this.Ribbon != null && this.Visible == true) this.Ribbon.setSizes()
}

Qribbon.prototype.Execute=function(act, parm) {
	if (act == "Click") {
		var r=this.DatactlObj.SetRow(parm, false)
		this.DatactlObj.Execute("NAVIGATEX")
	}
}

Qribbon.prototype.SetVal=function(valor) {
	var rib=new Object();
	rib.parent=this.Hobj;
	var waddr=GetImageAddress("xxx.png"); //determinar onde devem ser procuradas as imagens e usar essa path para o ribbon
	var ix=waddr.indexOf("xxx.png");
	waddr=waddr.substr(0, ix);
	rib.icons_path=waddr;
	rib.tabs=new Array();
	var Dados = this.DatactlObj.Dados
	var key=""
	var Rec=""
	var wniv=""
	var niv=""
	var label=""
	var img=""
	var autoriz=""
	var tipo=""
	for (var r=0; r<Dados.length; r++) {
		key = Dados[r].Key
		Rec=Dados[r]
		niv=Rec.Field("niv").Val
		label=Rec.Field("label").Val
		img=Rec.Field("img").Val
		autoriz=Rec.Field("autoriz").Val
		tipo=Rec.Field("tipo").Val
		rib.scroll=false
		if (niv == 0) {  //tabs
			var wtab=new Object()
			wtab.items=new Array()
			wtab.id=key
			wtab.text=label
			if (r == 0) wtab.active=true
			if (autoriz == "S") {
				wtab.disable=false
			} else {
				wtab.disable=true
			}
			rib.tabs.push(wtab)
		}
		if (niv == 1) {   //blocks
			var wblock=new Object()
			wblock.id=key
			wblock.type="block"
			wblock.text=label
			wblock.mode="cols"
			wblock.list=new Array()
			if (autoriz == "S") {
				wblock.disable=false
			} else {
				wblock.disable=true
			}
			wtab.items.push(wblock)
		}
		if (niv == 2) {   //buttons ou buttonSelect
			var wbutton=new Object()
			wbutton.id=key
			if (tipo == "L") {
				wbutton.type="button"
			} else {
				wbutton.type="buttonSelect"
				wbutton.items=new Array()
			}
			wbutton.text=label
			opt=Rec.Field("opt").Val
			if (opt == "BIG") wbutton.isbig=true
			wbutton.img=img
			if (autoriz == "S") {
				wbutton.disable=false
			} else {
				wbutton.disable=true
			}
			var myctlid=this.Hid
			if (tipo == "L") wbutton.onclick=function(id) {Qribbon_Event(myctlid, "Click", id);}
			wblock.list.push(wbutton)
		}
		if (niv == 3) {   //items
			var witem=new Object()
			witem.id=key
			witem.text=label
			witem.img=img
			if (autoriz == "S") {
				witem.active=true
			} else {
				witem.active=false
			}
			var myctlid=this.Hid
			witem.onclick=function(id) {Qribbon_Event(myctlid, "Click", id);}
			wbutton.items.push(witem)
		}
		if (niv == 4) {   //items
			if (witem.items == undefined) witem.items=new Array()
			var wsubitem=new Object()
			wsubitem.id=key
			wsubitem.text=label
			wsubitem.img=img
			if (autoriz == "S") {
				wsubitem.active=true
			} else {
				wsubitem.active=false
			}
			var myctlid=this.Hid
			wsubitem.onclick=function(id) {Qribbon_Event(myctlid, "Click", id);}
			witem.items.push(wsubitem)
		}
	}
	this.Ribbon=new dhtmlXRibbon(rib);
	this.Ribbon.setSkin("web");
}

Qribbon.prototype.Disable=function(tipo) {
	GenericDisplayCtl_Disable.call(this)
}

Qribbon.prototype.Enable=function(tipo) {
	GenericDisplayCtl_Enable.call(this)
	if (this.Disabled == false) {
	}
}

Qribbon.prototype.Show=function(opt) {
	GenericDisplayCtl_Show.call(this, opt)
}

Qribbon.prototype.Hide=function(opt) {
	GenericDisplayCtl_Hide.call(this, opt)
}

Qribbon.prototype.Destroy=function() {
	GenericDisplayCtl_Destroy.call(this)
	if (this.Ribbon) {
		this.Ribbon.unload();
		this.Ribbon=null;
	}
}

Qribbon.prototype.Destroy2=function() {
	GenericDisplayCtl_Destroy2.call(this)
}

function Qribbon_Event(ctlid, evt, ribctlid) {
	var ctl=GetCtlByHid(ctlid)
	ctl.Execute(evt, ribctlid)
}



//*********************************************
//*********************************************
//*   Frames / Estilos / Location-Size
//*********************************************
//*********************************************


//***************************************************************** QFRAME - define objecto visual standard
function Qframe(parentobj) {
	this.ParentObj=parentobj
	this.Divs=new Array()
	this.DivIcon=null
	this.State="NORM"
	var Sobj=parentobj.StyleObj
	var wdiv=parentobj.Hobj
	wdiv.style.MozBoxSizing = "border-box"
	wdiv.style.WebkitBoxSizing = "border-box"
	wdiv.style.BoxSizing = "border-box"
	wdiv.style.boxSizing = "border-box"
	var state=Sobj.States[0]  //Sobj.GetState("NORM")
	this.StateObj=state
	if (parentobj.Locsize != undefined) parentobj.Locsize.SetMargins(Sobj.PadL, Sobj.PadR, Sobj.PadT, Sobj.PadB)
	if (Sobj.TemaId == "") {
		if (state.BgClass != "") {
			wdiv.className=state.BgClass
		}
	} else {
		var larg=parentobj.Locsize.ObjW
		var larg1=larg-Sobj.TemaMargR
		var larg2=larg-Sobj.TemaMargR * 2
		var alt=parentobj.Locsize.ObjH
		var alt1=alt-Sobj.TemaMargB
		var alt2=alt-Sobj.TemaMargB * 2
		if (larg<0) larg=0
		if (larg1<0) larg1=0
		if (larg2<0) larg2=0
		if (alt<0) alt=0
		if (alt1<0) alt1=0
		if (alt2<0) alt2=0

		switch (Sobj.TemaTipo) {  //criar as diversas partes que constituem os varios tipos de temas
			case "1i4e":
				if (Sobj.TemaAct == "F") {
					this.Divs.push(wdiv)
					parentobj.Locsize.RefW="A"
					parentobj.Locsize.OffW=Sobj.TemaWidth
					parentobj.Locsize.RefH="A"
					parentobj.Locsize.OffH=Sobj.TemaHeight
					parentobj.Locsize.ObjW=Sobj.TemaWidth
					parentobj.Locsize.ObjH=Sobj.TemaHeight
					wdiv.style.width=Sobj.TemaWidth + "px"
					wdiv.style.height=Sobj.TemaHeight + "px"
					wdiv.style.background="url('" + Sobj.TemaPath + "') no-repeat left top"
				}
				if (Sobj.TemaAct == "H") {
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, larg1, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat left top"
					this.Divs.push(wd)
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA2", larg1, 0, Sobj.TemaMargR, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat -" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px top"
					this.Divs.push(wd)
				}
				if (Sobj.TemaAct == "V") {
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, larg, alt1)
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat left top"
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					this.Divs.push(wd)
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA2", 0, alt1, larg, Sobj.TemaMargB)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat left -" + (Sobj.TemaHeight - Sobj.TemaMargB) + "px"
					this.Divs.push(wd)
				}
				if (Sobj.TemaAct == "Z") {
					if (this.ParentObj.Locsize.ObjW - Sobj.TemaMargR < 0) return
					if (this.ParentObj.Locsize.ObjH - Sobj.TemaMargB < 0) return
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, larg1, alt1)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat left top"
					this.Divs.push(wd)
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA2", larg1, 0, Sobj.TemaMargR, alt1)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat -" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px top"
					this.Divs.push(wd)
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA3", 0, alt1, larg1, Sobj.TemaMargB)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat left -" + (Sobj.TemaHeight - Sobj.TemaMargB) + "px"
					this.Divs.push(wd)
					var wd=CreateDiv(wdiv, parentobj.Hid + "._.TEMA4", larg1, alt1, Sobj.TemaMargR, Sobj.TemaMargB)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.style.background="url('" + Sobj.TemaPath + "') no-repeat -" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px -" + (Sobj.TemaHeight - Sobj.TemaMargB) + "px"
					this.Divs.push(wd)
				}
				break
			case "4i4e":
				if (Sobj.TemaAct == "S") {
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, larg, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_up.gif")
					this.Divs.push(wd)
				} else {
					this.Divs.push(wdiv)
					parentobj.Locsize.RefW="A"
					parentobj.Locsize.OffW=Sobj.TemaWidth
					parentobj.Locsize.RefH="A"
					parentobj.Locsize.OffH=Sobj.TemaHeight
					parentobj.Locsize.ObjW=Sobj.TemaWidth
					parentobj.Locsize.ObjH=Sobj.TemaHeight
					wdiv.style.width=Sobj.TemaWidth + "px"
					wdiv.style.height=Sobj.TemaHeight + "px"
					wdiv.style.background="url('" + Sobj.TemaPath + "_bot_up.gif') no-repeat left top"
				}
				break
			case "12i4e":
				if (Sobj.TemaAct == "H") {
					if (this.ParentObj.Locsize.ObjW - Sobj.TemaMargR * 2 < 0) return
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, Sobj.TemaMargR, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_esq_up.gif")
					this.Divs.push(wd)
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA2", Sobj.TemaMargR, 0, larg2, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_cen_up.gif")
					this.Divs.push(wd)
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA3", larg1, 0, Sobj.TemaMargR, alt)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_dir_up.gif")
					this.Divs.push(wd)
				}
				if (Sobj.TemaAct == "V") {
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, larg, Sobj.TemaMargR)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_esq_up.gif")
					this.Divs.push(wd)
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA2", 0, Sobj.TemaMargR, larg, alt2)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_cen_up.gif")
					this.Divs.push(wd)
					var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA3", 0, larg1, larg, Sobj.TemaMargR)
					if (BrowserIE || BrowserOP) wd.unselectable = "on"
					if (BrowserMOZ) wd.style.MozUserSelect = "none"
					if (BrowserWKIT) wd.style.webkitUserSelect = "none"
					wd.src=ImgLib.GetImg(Sobj.TemaPath + "_dir_up.gif")
					this.Divs.push(wd)
				}
				break
			case "18i2e":
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA1", 0, 0, Sobj.TemaMargR, Sobj.TemaMargR)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_cse.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA2", Sobj.TemaMargR, 0, larg2, Sobj.TemaMargR)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_bs.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA3", larg1, 0, Sobj.TemaMargR, Sobj.TemaMargR)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_csd.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA4", 0, Sobj.TemaMargR, Sobj.TemaMargR, alt2)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_be.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA5", Sobj.TemaMargR, Sobj.TemaMargR, larg2, alt2)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_bg.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA6", larg1, Sobj.TemaMargR, Sobj.TemaMargR, alt2)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_bd.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA7", 0, alt1, Sobj.TemaMargR, Sobj.TemaMargB)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_cie.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA8", Sobj.TemaMargR, alt1, larg2, Sobj.TemaMargB)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_bi.gif")
				this.Divs.push(wd)
				var wd=CreateImg(wdiv, parentobj.Hid + "._.TEMA9", larg1, alt1, Sobj.TemaMargR, Sobj.TemaMargB)
				if (BrowserIE || BrowserOP) wd.unselectable = "on"
				if (BrowserMOZ) wd.style.MozUserSelect = "none"
				if (BrowserWKIT) wd.style.webkitUserSelect = "none"
				wd.src=ImgLib.GetImg(Sobj.TemaPath + "_cid.gif")
				this.Divs.push(wd)
				break
		}
	}
	if (Sobj.IconId != "") {
		var Aw=this.CalcIconPosition()
		var wx=Aw[0]
		var wy=Aw[1]
		var wd=CreateDiv(wdiv, parentobj.Hid + "._.ICON", wx, wy, Sobj.IconWidth, Sobj.IconHeight)
		if (BrowserIE || BrowserOP) wd.unselectable = "on"
		if (BrowserMOZ) wd.style.MozUserSelect = "none"
		if (BrowserWKIT) wd.style.webkitUserSelect = "none"
		wd.style.background="url('" + Sobj.IconPath + "') no-repeat left top"
		this.DivIcon=wd
	}
	this.SetState(state.Id)
}

Qframe.prototype.SetDynamicIcon=function(iconid, opt) {
	var Sobj=this.ParentObj.StyleObj
	if (Sobj.IconId != "*") return
	if (opt == "NOPATH") {
		var wiconpath=iconid  //ja vem com path
	} else {
		var wiconpath=GetImageAddress(iconid)  //obter a path para o Icone
	}
	this.DivIcon.style.background="url('" + wiconpath + "') no-repeat left top"
}

Qframe.prototype.CalcIconPosition=function() {
	var Sobj=this.ParentObj.StyleObj
	var wx=0
	var wy=0
	if (Sobj.IconX.indexOf("*") > -1) {
		wx=Number(Sobj.IconX.substr(2))
		wx=this.ParentObj.Locsize.ObjW - Sobj.IconWidth - wx
	} else {
		if (Sobj.IconX == "C") {
			wx=(this.ParentObj.Locsize.ObjW - Sobj.IconWidth) / 2
		} else {
			wx=Number(Sobj.IconX)
		}
	}
	if (Sobj.IconY.indexOf("*") > -1) {
		wy=Number(Sobj.IconY.substr(2))
		wy=this.ParentObj.Locsize.ObjH - Sobj.IconHeight - wy
	} else {
		if (Sobj.IconY == "C") {
			wy=(this.ParentObj.Locsize.ObjH - Sobj.IconHeight) / 2
		} else {
			wy=Number(Sobj.IconY)
		}
	}
	var r=new Array(wx, wy)
	return r
}

Qframe.prototype.GetStateId=function(stateid) {
	return this.StateObj.Id
}

Qframe.prototype.SetState=function(stateid) {
	var Sobj=this.ParentObj.StyleObj
	var wdiv=this.ParentObj.Hobj
	this.State=stateid
	this.StateObj=Sobj.GetState(stateid)
	var state=this.StateObj
	if (state.BgClass != "") {
		if (wdiv.className != state.BgClass) wdiv.className=state.BgClass
	}
	if (state.BgTema != 0) {
		if (this.Divs[0] == null) return;
		var statid=""
		if (state.BgTema == 1) statid="up"
		if (state.BgTema == 2) statid="ovr"
		if (state.BgTema == 3) statid="dwn"
		if (state.BgTema == 4) statid="dis"
		switch (Sobj.TemaTipo) {
			case "1i4e":
				var wstat=state.BgTema
				var stat=wstat-1
				if (Sobj.TemaAct == "F") {
					this.Divs[0].style.backgroundPosition="left -" + (stat * Sobj.TemaHeight) + "px"
				}
				if (Sobj.TemaAct == "H") {
					this.Divs[0].style.backgroundPosition="left -" + (stat * Sobj.TemaHeight) + "px"
					this.Divs[1].style.backgroundPosition="-" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px -" + (stat * Sobj.TemaHeight) + "px"
				}
				if (Sobj.TemaAct == "V") {
					this.Divs[0].style.backgroundPosition="left -" + (stat * Sobj.TemaHeight) + "px"
					this.Divs[1].style.backgroundPosition="left -" + ((stat * Sobj.TemaHeight) + (Sobj.TemaHeight - Sobj.TemaMargB)) + "px"
				}
				if (Sobj.TemaAct == "Z") {
					this.Divs[0].style.backgroundPosition="left -" + (stat * Sobj.TemaHeight) + "px"
					this.Divs[1].style.backgroundPosition="-" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px -" + (stat * Sobj.TemaHeight) + "px"
					this.Divs[2].style.backgroundPosition="left -" + (wstat * Sobj.TemaHeight - Sobj.TemaMargB) + "px"
					this.Divs[3].style.backgroundPosition="-" + (Sobj.TemaWidth - Sobj.TemaMargR) + "px -" + (wstat * Sobj.TemaHeight - Sobj.TemaMargB) + "px"
				}
				break
			case "4i4e":
				if (Sobj.TemaAct == "S") {
					this.Divs[0].src=ImgLib.GetImg(Sobj.TemaPath + "_" + statid + ".gif")
				} else {
					this.Divs[0].style.background="url('" + Sobj.TemaPath + "_" + statid + ".gif') no-repeat left top"
				}
				break
			case "12i4e":
				this.Divs[0].src=ImgLib.GetImg(Sobj.TemaPath + "_esq_" + statid + ".gif")
				this.Divs[1].src=ImgLib.GetImg(Sobj.TemaPath + "_cen_" + statid + ".gif")
				this.Divs[2].src=ImgLib.GetImg(Sobj.TemaPath + "_dir_" + statid + ".gif")
				break
			case "18i2e":
				if (statid == "up") {
					statid=""
				} else {
					statid="_" + statid
				}
				this.Divs[0].src=ImgLib.GetImg(Sobj.TemaPath + "_cse" + statid + ".gif")
				this.Divs[1].style.background="url('" + Sobj.TemaPath + "_bs" + statid + ".gif') repeat left top"
				this.Divs[2].src=ImgLib.GetImg(Sobj.TemaPath + "_csd" + statid + ".gif")
				this.Divs[3].src=ImgLib.GetImg(Sobj.TemaPath + "_be" + statid + ".gif")
				this.Divs[4].src=ImgLib.GetImg(Sobj.TemaPath + "_bg" + statid + ".gif")
				this.Divs[5].src=ImgLib.GetImg(Sobj.TemaPath + "_bd" + statid + ".gif")
				this.Divs[6].src=ImgLib.GetImg(Sobj.TemaPath + "_cie" + statid + ".gif")
				this.Divs[7].style.background="url('" + Sobj.TemaPath + "_bi" + statid + ".gif') repeat left top"
				this.Divs[8].src=ImgLib.GetImg(Sobj.TemaPath + "_cid" + statid + ".gif")
				break
		}
	}
	if (Sobj.IconId != "") {
		var wtop=(state.IconTema - 1) * Sobj.IconHeight
		if (wtop < 0) wtop = 0
		this.DivIcon.style.backgroundPosition="left -" + wtop + "px"
	}
}

Qframe.prototype.Resize=function(opt) {
	var Sobj=this.ParentObj.StyleObj
	var wdiv=this.ParentObj.Hobj
	var state=this.StateObj
	if (Sobj.IconId != "") {
		var Aw=this.CalcIconPosition()
		this.DivIcon.style.left=Aw[0] + "px"
		this.DivIcon.style.top=Aw[1] + "px"
	}
	if (state.BgTema == 0) return
	if (opt == "ANIM") {
		var w=GetSizeNumber(this.ParentObj.Hobj.style.width)
		var h=GetSizeNumber(this.ParentObj.Hobj.style.height)
	} else {
		var w=this.ParentObj.Locsize.ObjW
		var h=this.ParentObj.Locsize.ObjH
	}
	switch (Sobj.TemaTipo) {
		case "1i4e":
			if (this.Divs[0] == null) return;
			if (Sobj.TemaAct == "H") {
				if (w - Sobj.TemaMargR < 0) return
				this.Divs[0].style.width=(w - Sobj.TemaMargR) + "px"
				this.Divs[0].style.height=(h) + "px"
				this.Divs[1].style.left=(w - Sobj.TemaMargR) + "px"
				this.Divs[1].style.height=(h) + "px"
			}
			if (Sobj.TemaAct == "V") {
				if (h - Sobj.TemaMargB < 0) return
				this.Divs[0].style.width=(w) + "px"
				this.Divs[0].style.height=(h - Sobj.TemaMargB) + "px"
				this.Divs[1].style.top=(h - Sobj.TemaMargB) + "px"
				this.Divs[1].style.width=(w) + "px"
			}
			if (Sobj.TemaAct == "Z") {
				if (w - Sobj.TemaMargR < 0) return
				if (h - Sobj.TemaMargB < 0) return
				this.Divs[0].style.width=(w - Sobj.TemaMargR) + "px"
				this.Divs[0].style.height=(h - Sobj.TemaMargB) + "px"
				this.Divs[1].style.left=(w - Sobj.TemaMargR) + "px"
				this.Divs[1].style.height=(h - Sobj.TemaMargB) + "px"
				this.Divs[2].style.top=(h - Sobj.TemaMargB) + "px"
				this.Divs[2].style.width=(w - Sobj.TemaMargR) + "px"
				this.Divs[3].style.top=(h - Sobj.TemaMargB) + "px"
				this.Divs[3].style.left=(w - Sobj.TemaMargR) + "px"
			}
			break
		case "4i4e":
			if (this.Divs[0] == null) return;
			if (Sobj.TemaAct == "S") {
				this.Divs[0].style.height=h + "px"
				this.Divs[0].style.width=w + "px"
			}
			break
		case "12i4e":
			if (this.Divs[0] == null) return;
			if (Sobj.TemaAct == "H") {
				if (w - Sobj.TemaMargR * 2 < 0) return
				this.Divs[0].style.height=h + "px"
				this.Divs[1].style.width=(w - Sobj.TemaMargR * 2) + "px"
				this.Divs[1].style.height=h + "px"
				this.Divs[2].style.left=(w - Sobj.TemaMargR) + "px"
				this.Divs[2].style.height=(h) + "px"
			}
			if (Sobj.TemaAct == "V") {
				if (h - Sobj.TemaMargB * 2 < 0) return
				this.Divs[0].style.width=w + "px"
				this.Divs[1].style.width=w + "px"
				this.Divs[1].style.height=(h - Sobj.TemaMargR * 2) + "px"
				this.Divs[2].style.top=(h - Sobj.TemaMargR) + "px"
				this.Divs[2].style.width=w + "px"
			}
			break
		case "18i2e":
			if (this.Divs[0] == null) return;
			if (w - Sobj.TemaMargR * 2 < 0) return
			if (h - Sobj.TemaMargB * 2 < 0) return
			this.Divs[1].style.width=(w - Sobj.TemaMargR * 2) + "px"
			this.Divs[2].style.left=(w - Sobj.TemaMargR) + "px"
			this.Divs[3].style.height=(h - Sobj.TemaMargR * 2) + "px"
			this.Divs[4].style.width=(w - Sobj.TemaMargR * 2) + "px"
			this.Divs[4].style.height=(h - Sobj.TemaMargR * 2) + "px"
			this.Divs[5].style.height=(h - Sobj.TemaMargR * 2) + "px"
			this.Divs[5].style.left=(w - Sobj.TemaMargR) + "px"
			this.Divs[6].style.top=(h - Sobj.TemaMargR) + "px"
			this.Divs[7].style.top=(h - Sobj.TemaMargR) + "px"
			this.Divs[7].style.width=(w - Sobj.TemaMargR * 2) + "px"
			this.Divs[8].style.top=(h - Sobj.TemaMargR) + "px"
			this.Divs[8].style.left=(w - Sobj.TemaMargR) + "px"
			break
	}
}

Qframe.prototype.Destroy=function() {
	for (var i=0; i<this.Divs.length;  i++) {
		if (this.Divs[i] != null) {
			this.Divs[i].parentNode.removeChild(this.Divs[i])
			this.Divs[i]=null
		}
	}
}



//***************************************************************** QCOLGRID - define COL de uma grid
function Qcolgrid(id, tit, type, larg, col) {
	this.Index=0
	this.Id=id
	this.Tit=tit
	this.Type=type
	this.Larg=larg
	this.Left=0
	this.Ord=""
	this.Filter=""
	this.Col = col
}


//***************************************************************** Qlocsize - define Location e Size de um controlo
function QlocSize(loc, size, parentobj) {
	this.ParentObj=parentobj
	//referencias para posicionamento
	this.RefL="L"   //referencia de posicionamento horizontal  (Left / Right / Center)
	this.RefT="T"   //referencia de posicionamento vertical  (Top / Bottom / Center)
	this.RefW="A"   //referencia de largura  (Absolute / Relative)
	this.RefH="A"   //referencia de largura  (Absolute / Relative)
	this.OffL=0  //valor de offset para posicionamento horizontal
	this.OffT=0  //valor de offset para posicionamento vertical
	this.OffW=0  //valor de offset para largura
	this.OffH=0  //valor de offset para altura
	//localização e tamanho actuais em pixels
	this.ObjL=0
	this.ObjT=0
	this.ObjW=0
	this.ObjH=0
	//margens left/top/right/bottom para dependentes por borders ou Temas ou outras razões
	this.MargL=0
	this.MargT=0
	this.MargR=0
	this.MargB=0
	//resizable ou relocatable
	this.Resizable=false

	//inicialização
	var wL="0"
	var wT="0"
	var wW="0"
	var wH="0"
	var Aw=loc.split(",")
	if (Aw[0] != "") wL=Aw[0]
	if (Aw.length > 1) wT=Aw[1]
	var Aw=size.split(",")
	if (Aw[0] != "") wW=Aw[0]
	if (Aw.length > 1) wH=Aw[1]

	var prefix=wL.substr(0,1)
	if (prefix == "*" || prefix == "C") {
		if (wL.length > 1) this.OffL=Number(wL.substr(1))
		this.Resizable=true
		if (prefix == "C") this.RefL="C"
		if (prefix == "*") this.RefL="R"
	} else {
		this.OffL=Number(wL)
	}
	prefix=wT.substr(0,1)
	if (prefix == "*" || prefix == "C") {
		if (wT.length > 1) this.OffT=Number(wT.substr(1))
		this.Resizable=true
		if (prefix == "C") this.RefT="C"
		if (prefix == "*") this.RefT="B"
	} else {
		this.OffT=Number(wT)
	}
	prefix=wW.substr(0,1)
	if (prefix == "*") {
		if (wW.length > 1) this.OffW=Number(wW.substr(1))
		this.RefW="R"
		this.Resizable=true
	} else {
		this.OffW=Number(wW)
	}
	prefix=wH.substr(0,1)
	if (prefix == "*") {
		if (wH.length > 1) this.OffH=Number(wH.substr(1))
		this.RefH="R"
		this.Resizable=true
	} else {
		this.OffH=Number(wH)
	}
}

QlocSize.prototype.SetMargins=function(ml, mr, mt, mb) {
	if (mt != undefined) {
		this.MargL=ml
		this.MargT=mt
		this.MargR=mr
		this.MargB=mb
	} else {
		this.MargL=ml
		this.MargT=ml
		this.MargR=ml
		this.MargB=ml
	}
}

QlocSize.prototype.Resize=function(obj) {   //calcular a localização e tamanho se for resizable ou relocatable
	var wObjL=this.ObjL
	var wObjT=this.ObjT
	var wObjW=this.ObjW
	var wObjH=this.ObjH
	if (this.ParentObj == null) {
		var dims=GetDocDims()
		var pw=dims[0]
		var ph=dims[1]
		var pml=0
		var pmt=0
		var pmr=0
		var pmb=0
	} else {
		var pw=this.ParentObj.Locsize.ObjW
		var ph=this.ParentObj.Locsize.ObjH
		var pml=this.ParentObj.Locsize.MargL
		var pmt=this.ParentObj.Locsize.MargT
		var pmr=this.ParentObj.Locsize.MargR
		var pmb=this.ParentObj.Locsize.MargB
	}
	if (this.RefW == "A") {
		this.ObjW=this.OffW
		if (this.ParentObj == null) {
			if (this.ObjW > (pw-pml-pmr)) this.ObjW=pw-pml-pmr
		}
	}
	if (this.RefL == "L") {
		this.ObjL=this.OffL + pml
		if (this.RefW == "R") this.ObjW=pw - this.ObjL + this.OffW - pmr
	} else {
		if (this.RefL == "R") {
			this.ObjL=pw+this.OffL - pmr
			if (this.RefW == "R") this.ObjW=pw - this.ObjL + this.OffW - pml
		} else {
			if (this.RefL == "C") {
				if (this.RefW == "R") this.ObjW=pw + this.OffW - pml - pmr
				this.ObjL=(pw - this.ObjW) / 2 + this.OffL + pml
			}
		}
	}
	if (this.RefH == "A") {
		this.ObjH=this.OffH
		if (this.ParentObj == null) {
			if (this.ObjH > (ph-pmt-pmb)) this.ObjH=ph-pmt-pmb
		}
	}
	if (this.RefT == "T") {
		this.ObjT=this.OffT + pmt
		if (this.RefH == "R") this.ObjH=ph - this.ObjT + this.OffH - pmb
	} else {
		if (this.RefT == "B") {
			this.ObjT=ph+this.OffT - pmb
			if (this.RefH == "R") this.ObjH=ph - this.ObjT + this.OffH - pmt
		} else {
			if (this.RefT == "C") {
				if (this.RefH == "R") this.ObjH=ph + this.OffH - pmt - pmb
				this.ObjT=(ph - this.ObjH) / 2 + this.OffT + pmt
			}
		}
	}
	if (this.ObjW < 0) this.ObjW=0
	if (this.ObjH < 0) this.ObjH=0
	if (obj != null && obj != undefined) {
		if (wObjL != this.ObjL) obj.style.left=this.ObjL + "px"
		if (wObjT != this.ObjT) obj.style.top=this.ObjT + "px"
		if (this.RefW == "A" && this.OffW == 0) {  // quando a altura ou largura é expressamente zero é porque não se pretende especificar e não para ser zero
		} else {
			if (wObjW != this.ObjW) obj.style.width=this.ObjW + "px"
		}
		if (this.RefH == "A" && this.OffH == 0) {
		} else {
			if (wObjH != this.ObjH) obj.style.height=this.ObjH + "px"
		}
	}
}


QlocSize.prototype.UnScrollH=function(obj) {   //eliminar scrollbars verticais deixando expandir para o seu tamanho total
	if (obj.scrollHeight != obj.clientHeight) {
		var wh=obj.scrollHeight
		this.ObjH=wh
		obj.style.height=wh + "px"
		obj.overflowY="hidden"
		this.CheckScrollBars(obj)
	}
}

QlocSize.prototype.CheckScrollBars=function(obj) {   //eliminar scrollbars duplas quando não necessarias
	var wh=obj.scrollHeight - obj.clientHeight
	var ww=obj.scrollWidth - obj.clientWidth
	var washidden=false
	if (wh > 0 && ww > 0) {
		if (ww < 22 && ww > 15) {
			obj.style.overflowX="hidden"
			washidden=true
		} else {
			obj.style.overflowX="auto"
		}
		if (washidden == false) {
			if (wh < 22 && wh > 15) {
			obj.style.overflowY="hidden"
			} else {
				obj.style.overflowY="auto"
			}
		}
	}
}



//***************************************************************** QSTYLELIB - Biblioteca de estilos
function QstyleLib() {
    this.Styles = new Array()
	this.RefObj = new QstyleObj(null)
	this.TestObj = null
	this.ImgList = new Array()
}

QstyleLib.prototype.LoadStyle=function(xnod) {
	var styleobj=new QstyleObj(xnod)
	this.Styles.push(styleobj)
}

QstyleLib.prototype.GetStyle = function(id, tipo) {
	if (this.TestObj != null) {
		if (this.TestObj.Type == tipo) return this.TestObj
		var ix = tipo.indexOf(".")
		var wtipo = tipo
	    while (ix > -1) {
	        wtipo = wtipo.substr(ix + 1)
	        if (this.TestObj.Type == wtipo)
	        if (this.TestObj.Type == wtipo) return this.TestObj
	        ix = wtipo.indexOf(".")
	    }
	}
	var ix=tipo.lastIndexOf(".")
	var wrtipo=tipo.substr(ix+1)
    var Astyles = new Array()
    var wtype=""
    //criar um array de estilos com o id especificado
    for (var i = 0; i < this.Styles.length; i++) {
        if (this.Styles[i].Id == id) {
	        wtype=this.Styles[i].Type
            if (wtype == tipo) return this.Styles[i]
            if (wtype.indexOf(wrtipo) > -1) Astyles.push(this.Styles[i])
        }
    }
    //verificar se existe tipo compatível no array de estilos com o id especificado
    var wtipo = tipo
    var ix = wtipo.indexOf(".")
    while (ix > -1) {
        wtipo = wtipo.substr(ix + 1)
        for (var i = 0; i < Astyles.length; i++) {
            if (Astyles[i].Type == wtipo) return Astyles[i]
        }
        ix = wtipo.indexOf(".")
    }
    Astyles=new Array()
    //procurar nos DEFAULT
    for (var i = 0; i < this.Styles.length; i++) {
    	if (this.Styles[i].Id == "DEFAULT") {
        	wtype=this.Styles[i].Type
        	if (wtype == tipo) {
	        	return this.Styles[i]
        	} else {
        		if (wtype.indexOf(wrtipo) > -1) Astyles.push(this.Styles[i])
    		}
		}
	}
    //verificar se existe tipo compatível no array
    if (Astyles.length == 0) return this.RefObj
    var ix = tipo.indexOf(".")
    var wtipo = tipo
    while (ix > -1) {
        wtipo = wtipo.substr(ix + 1)
        for (var i = 0; i < Astyles.length; i++) {
            if (Astyles[i].Type == wtipo) return Astyles[i]
        }
        ix = wtipo.indexOf(".")
    }
    return this.RefObj
}


QstyleLib.prototype.SetTestStyle=function(wstyle) {
	this.TestObj = wstyle
}


//***************************************************************** QSTYLEObj - define Estilo de um tipo de componente
function QstyleObj(xnod) {
	this.Id="*"
	this.Type="*"
	this.States=new Array()
	this.TemaId=""
	this.TemaPath=""
	this.TemaWidth=0
	this.TemaHeight=0
	this.TemaMargR=0
	this.TemaMargB=0
	this.TemaAct=""
	this.TemaTipo=""
	this.PadL=0
	this.PadR=0
	this.PadT=0
	this.PadB=0
	this.AnimIn=""
	this.AnimOut=""
	this.UseIcons="N"
	this.IconId=""
	this.IconPath=""
	this.IconWidth=0
	this.IconHeight=0
	this.IconX="0"
	this.IconY="0"

	if (xnod == null) {
		var state=new QstyleState(null, null)
		this.States.push(state)
		return
	}
	var refstate=null
	var w=""
	w=GetAtt(xnod, "ID", "*")
	this.Id = w
	w=GetAtt(xnod, "FOR", "*")
	this.Type=w
	this.TemaId=GetAtt(xnod, "TEMAID", "")
	if (this.TemaId != "") this.TemaPath=GetImageAddress(this.TemaId)  //obter a path para o Tema
	w=GetAtt(xnod, "TEMASIZE", "")
	if (w != "") {
		var Aw=w.split(",")
		if (Aw.length != 5) {
			window.alert(GetMsg(1, "TEMASIZE com numero de parametros incorrecto no STYLE ID=" + this.Id + " FOR=" + this.Type))
		}
		this.TemaWidth=Number(Aw[0])
		this.TemaHeight=Number(Aw[1])
		this.TemaMargR=Number(Aw[2])
		this.TemaMargB=Number(Aw[3])
		this.TemaAct=Aw[4].substr(0,1)   //Tipo de acção F(ixed) S(treched) H(orizontal) V(ertical) Z(oom)
		if (this.TemaId.indexOf("qwtema") > -1) {
			if (this.TemaAct == "F" || this.TemaAct == "S") {
				this.TemaTipo="4i4e"
				ImgLib.LoadImg(this.TemaPath + "_up.gif")
				ImgLib.LoadImg(this.TemaPath + "_ovr.gif")
				ImgLib.LoadImg(this.TemaPath + "_dwn.gif")
				ImgLib.LoadImg(this.TemaPath + "_dis.gif")
			} else {
				if (this.TemaAct == "H" || this.TemaAct == "V") {
					this.TemaTipo="12i4e"
					ImgLib.LoadImg(this.TemaPath + "_esq_up.gif")
					ImgLib.LoadImg(this.TemaPath + "_esq_ovr.gif")
					ImgLib.LoadImg(this.TemaPath + "_esq_dwn.gif")
					ImgLib.LoadImg(this.TemaPath + "_esq_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_cen_up.gif")
					ImgLib.LoadImg(this.TemaPath + "_cen_ovr.gif")
					ImgLib.LoadImg(this.TemaPath + "_cen_dwn.gif")
					ImgLib.LoadImg(this.TemaPath + "_cen_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_dir_up.gif")
					ImgLib.LoadImg(this.TemaPath + "_dir_ovr.gif")
					ImgLib.LoadImg(this.TemaPath + "_dir_dwn.gif")
					ImgLib.LoadImg(this.TemaPath + "_dir_dis.gif")
				} else {
					this.TemaTipo="18i2e"
					ImgLib.LoadImg(this.TemaPath + "_cse.gif")
					ImgLib.LoadImg(this.TemaPath + "_bs.gif")
					ImgLib.LoadImg(this.TemaPath + "_csd.gif")
					ImgLib.LoadImg(this.TemaPath + "_be.gif")
					ImgLib.LoadImg(this.TemaPath + "_bg.gif")
					ImgLib.LoadImg(this.TemaPath + "_bd.gif")
					ImgLib.LoadImg(this.TemaPath + "_cie.gif")
					ImgLib.LoadImg(this.TemaPath + "_bi.gif")
					ImgLib.LoadImg(this.TemaPath + "_cid.gif")
					ImgLib.LoadImg(this.TemaPath + "_cse_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_bs_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_csd_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_be_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_bg_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_bd_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_cie_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_bi_dis.gif")
					ImgLib.LoadImg(this.TemaPath + "_cid_dis.gif")
				}
			}
		} else {
			if (this.TemaId.indexOf("qstema") > -1) {
				this.TemaTipo="1i4e"
				ImgLib.LoadImg(this.TemaPath)
			} else {
				window.alert(GetMsg(1, "Filename incorrecto para TEMAID no STYLE ID=" + this.Id + " FOR=" + this.Type))
			}
		}
	}
	w=GetAtt(xnod, "PADDING", "")
	if (w != "") {
		var Aw=w.split(",")
		this.PadL=Number(Aw[0])
		this.PadR=this.PadL
		this.PadT=this.PadL
		this.PadB=this.PadL
		if (Aw.length > 1) {
			this.PadR=Number(Aw[1])
			if (Aw.length > 2) {
				this.PadT=Number(Aw[2])
				if (Aw.length > 3) this.PadB=Number(Aw[3])
			}
		}
	}
	this.AnimIn=GetAtt(xnod, "ANIMIN", "")
	this.AnimOut=GetAtt(xnod, "ANIMOUT", "")
	this.UseIcons = GetAtt(xnod, "USEICONS", "N")
	this.IconId=GetAtt(xnod, "ICONID", "")
	if (this.IconId != "") this.IconPath=GetImageAddress(this.IconId)  //obter a path para o Icone
	w=GetAtt(xnod, "ICONSIZE", "0,0")
	if (w != "") {
		var Aw=w.split(",")
		if (Aw.length != 2) {
			window.alert(GetMsg(1, "ICONSIZE com numero de parametros incorrecto no STYLE ID=" + this.Id + " FOR=" + this.Type))
		}
		this.IconWidth=Number(Aw[0])
		this.IconHeight=Number(Aw[1])
	}
	w=GetAtt(xnod, "ICONLOCATION", "0,0")
	if (w != "") {
		var Aw=w.split(",")
		if (Aw.length != 2) {
			window.alert(GetMsg(1, "ICONLOCATION com numero de parametros incorrecto no STYLE ID=" + this.Id + " FOR=" + this.Type))
		}
		this.IconX="" + Aw[0]
		this.IconY="" + Aw[1]
	}
	var xn=xnod.firstChild
	var state=null
	while (xn!=undefined) {
		if (xn.nodeName.indexOf("text") == -1) {
			state=new QstyleState(xn, refstate)
			if (this.TemaId == "" && state.BgClass == "") state.BgClass="BaseFrame"
			if (xn.nodeName == "NORM" || xn.nodeName == "NORM0") refstate=state
			this.States.push(state)
		}
		xn=xn.nextSibling
	}
	if (refstate == null) {
		state=new QstyleState(null, null)
		this.States.push(state)
    }
}

QstyleObj.prototype.GetState=function(stateid) {
	var state=this.States[0]
	for (var i=0; i<this.States.length; i++) {
		if (this.States[i].Id == stateid) {
			state=this.States[i]
			break
		}
	}
	return state
}

QstyleObj.prototype.StateExists=function(stateid) {
	for (var i=0; i<this.States.length; i++) {
		if (this.States[i].Id == stateid) {
			return true
		}
	}
	return false
}

QstyleObj.prototype.GetClone=function() {
	var wstyle=new QstyleObj()
	wstyle.Id=this.Id
	wstyle.Type=this.Type
	wstyle.TemaId=this.TemaId
	wstyle.TemaPath=this.TemaPath
	wstyle.TemaWidth=this.TemaWidth
	wstyle.TemaHeight=this.TemaHeight
	wstyle.TemaMargR=this.TemaMargR
	wstyle.TemaMargB=this.TemaMargB
	wstyle.TemaAct=this.TemaAct
	wstyle.TemaTipo=this.TemaTipo
	wstyle.PadL=this.PadL
	wstyle.PadR=this.PadR
	wstyle.PadT=this.PadT
	wstyle.PadB=this.PadB
	wstyle.AnimIn=this.AnimIn
	wstyle.AnimOut=this.AnimOut
	wstyle.UseIcons=this.UseIcons
	wstyle.IconId=this.IconId
	wstyle.IconPath=this.IconPath
	wstyle.IconWidth=this.IconWidth
	wstyle.IconHeight=this.IconHeight
	wstyle.IconX=this.IconX
	wstyle.IconY=this.IconY
	wstyle.States=new Array()
	for (var i=0; i<this.States.length; i++) {
		var wstate=this.States[i].GetClone()
		wstyle.States.push(wstate)
	}
	return wstyle
}

QstyleObj.prototype.Update=function() {
	this.TemaTipo=""
	if (this.TemaId.indexOf("qwtema") > -1) {
		if (this.TemaAct == "F" || this.TemaAct == "S") {
			this.TemaTipo="4i4e"
		} else {
			if (this.TemaAct == "H" || this.TemaAct == "V") {
				this.TemaTipo="12i4e"
			} else {
				this.TemaTipo="18i2e"
			}
		}
	} else {
		if (this.TemaId.indexOf("qstema") > -1) {
			this.TemaTipo="1i4e"
		}
	}
	if (this.TemaTipo == "") {
		this.TemaWidth=0
		this.TemaHeight=0
		this.TemaMargR=0
		this.TemaMargB=0
		this.TemaAct=""
	}
	if (this.IconId == "") {
		this.IconWidth=0
		this.IconHeight=0
		this.IconX="0"
		this.IconY="0"
	}
	for (var i=0; i<this.States.length; i++) {
		var state=this.States[i]
		if (this.TemaTipo == "") {
			state.BgTema=0
			if (state.BgClass == "") state.BgClass="BaseFrame"
		} else {
			state.BgClass=""
			if (state.BgTema == 0) state.BgTema=1
		}
		if (this.IconId == "") {
			state.IconTema=0
		}
	}
}


//***************************************************************** QSTYLESTATE - define Estilo de um estado de um componente
function QstyleState(xnod, refobj) {
	this.Id="NORM"
	this.BgClass="" //"BaseFrame"
	this.TxtClass="BaseText"
	this.BgTema=0
	this.IconTema=0
	this.Img=""

	if (refobj != undefined && refobj != null) {
		this.BgClass=refobj.BgClass
		this.TxtClass=refobj.TxtClass
		this.BgTema=refobj.BgTema
		this.IconTema=refobj.IconTema
		this.Img=refobj.Img
	}

	if (xnod != undefined && xnod != null) {
		this.Id=xnod.nodeName
		this.BgClass=GetAtt(xnod, "BGCLASS", this.BgClass)
		this.TxtClass=GetAtt(xnod, "TXTCLASS", this.TxtClass)
		this.BgTema=GetAtt(xnod, "BGTEMA", this.BgTema, "N")
		this.IconTema=GetAtt(xnod, "ICONTEMA", this.IconTema, "N")
		this.Img=GetAtt(xnod, "IMG", this.Img)
	}
}

QstyleState.prototype.GetClone=function() {
	var wstate=new QstyleState()
	wstate.Id=this.Id
	wstate.BgClass=this.BgClass
	wstate.TxtClass=this.TxtClass
	wstate.BgTema=this.BgTema
	wstate.IconTema=this.IconTema
	wstate.Img=this.Img
	return wstate
}

//***************************************************************** QANIMATOR - define elementos necessarios à animação
function Qanimator(ctl, inout, animparms, newleft, newtop, newwidth, newheight) {
	this.Ctl=ctl
	this.InOut=inout
	this.TipAnim=""
	this.Aframes=new Array()
	this.Frame=0
	this.Frames=0
	this.Ease=0
	this.Sync="N"
	if (animparms == "") return
	var Aw=animparms.split(",")
	this.TipAnim=Aw[0]
	if (Aw.length > 1) this.Frames=Number(Aw[1])
	if (Aw.length > 2) {
		if (Aw[2] == "Ball") {
			this.Ease = 50
		} else {
			this.Ease=Number(Aw[2])
			if (this.Ease < -10 || this.Ease > 10) {
				window.alert(GetMsg(1, "Valor de Ease (" + this.Ease + ") invalido na animação (" + this.TipAnim + ") para controlo (" + ctl.Hid + ")"))
				this.Ease=0;
			}
		}
	}
	if (Aw.length > 3) this.Sync=Aw[3]
	var ls=ctl.Locsize
	var x=ls.ObjL
	var y=ls.ObjT
	var w=ls.ObjW
	var h=ls.ObjH
	if ((ls.RefH == "A" && ls.OffH == 0) || (ls.RefW == "A" && ls.OffW == 0)) this.TipAnim="NONE"  //casos de largura=0 ou altura=0 nao devem ser animados
	if (this.Frames < 2) this.TipAnim="NONE"
	if (inout == "MOVE") {
		switch (this.TipAnim) {
			case "NONE":
				this.TipAnim=""
				//this.Frames=0
				break
			case "LINEAR":
				var wl=(newleft-x)/(this.Frames-1)
				var wt=(newtop-y)/(this.Frames-1)
				var ww=(newwidth-w)/(this.Frames-1)
				var wh=(newheight-h)/(this.Frames-1)
				for (var i=1; i<this.Frames; i++) {
					var nl=x+(i*wl)
					if (nl == x) nl=""
					var nt=y+(i*wt)
					if (nt == y) nt=""
					var nw=w+(i*ww)
					if (nw == w) nw=""
					var nh=h+(i*wh)
					if (nh == h) nh=""
					this.Aframes.push(new QanimStep(nl, nt, nw, nh))
				}
				this.Aframes.push(new QanimStep(newleft, newtop, newwidth, newheight))
				ls.ObjL=newleft
				ls.ObjT=newtop
				ls.ObjW=newwidth
				ls.ObjH=newheight
				break
		}
		return
	}
	if (inout == "WAIT") {
		switch (this.TipAnim) {
			case "NONE":
				this.TipAnim=""
				//this.Frames=0
				break
		}
		return;
	}
	if (inout == "IN") {
		switch (this.TipAnim) {
			case "NONE":
				this.TipAnim=""
				//this.Frames=0
				break
			case "GROW-T":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, w, h*f, 1))
					else this.Aframes.push(new QanimStep("", "", "", h*f, ""))
				}
				this.Aframes.push(new QanimStep("", "", "", h, ""))
				break

			case "GROW-L":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, w*f, h, 1))
					else this.Aframes.push(new QanimStep("", "", w*f, "", ""))
				}
				this.Aframes.push(new QanimStep("", "", w, "", ""))
				break

			case "GROW-B":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var wh=f*h
					if (i == 1) this.Aframes.push(new QanimStep(x, y+h-wh, w, wh, 1))
					else this.Aframes.push(new QanimStep("", y+h-wh, "", wh, ""))
				}
				this.Aframes.push(new QanimStep("", y, "", h, 1))
				break

			case "GROW-R":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					if (i == 1) this.Aframes.push(new QanimStep(x+w-ww, y, ww, h, 1))
					else this.Aframes.push(new QanimStep(x+w-ww, "", ww, "", ""))
				}
				this.Aframes.push(new QanimStep(x, "", w, "", ""))
				break

			case "GROW-H":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var wh=f*h
					if (i == 1) this.Aframes.push(new QanimStep(x, y+((h-wh)/2), w, wh, 1))
					else this.Aframes.push(new QanimStep("", y+((h-wh)/2), "", wh, ""))
				}
				this.Aframes.push(new QanimStep("", y, "", h, ""))
				break

			case "GROW-W":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					if (i == 1) this.Aframes.push(new QanimStep(x+((w-ww)/2), y, ww, h, 1))
					else this.Aframes.push(new QanimStep(x+((w-ww)/2), "", ww, "", ""))
				}
				this.Aframes.push(new QanimStep(x, "", w, "", ""))
				break

			case "GROW-S":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					var wh=f*h
					this.Aframes.push(new QanimStep(x+((w-ww)/2), y+((h-wh)/2), ww, wh, 1))
				}
				this.Aframes.push(new QanimStep(x, y, w, h, ""))
				break

			case "FADEIN":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, w, h, f))
					else this.Aframes.push(new QanimStep("", "", "", "", f))
				}
				this.Aframes.push(new QanimStep("", "", "", "", 1))
				break

			case "EXPLODE-TL":
				for (var i=1; i<this.Frames; i++) {
					var f=this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(f*x, f*y, w, h, 1))
					else this.Aframes.push(new QanimStep(f*x, f*y, "", "", ""))
				}
				this.Aframes.push(new QanimStep(x, y, "", "", ""))
				break
			default:
				window.alert(GetMsg(1, "Tipo de animação In (" + this.TipAnim + ") para controlo (" + ctl.Hid + ") inexistente"))
				this.TipAnim=""
				this.Frames=0
				break
		}
	} else {
		switch (this.TipAnim) {
			case "NONE":
				this.TipAnim=""
				//this.Frames=0
				break
			case "SHRINK-T":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, w, f*h, 1))
					else this.Aframes.push(new QanimStep("", "", "", f*h, ""))
				}
				this.Aframes.push(new QanimStep("", "", "", 0, ""))
				break
			case "SHRINK-B":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var wh=f*h
					if (i == 1) this.Aframes.push(new QanimStep(x, y+h-wh, y, wh, 1))
					else this.Aframes.push(new QanimStep("", y+h-wh, "", wh, ""))
				}
				this.Aframes.push(new QanimStep("", y, "", 0, ""))
				break
			case "SHRINK-L":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, f*w, h, 1))
					else this.Aframes.push(new QanimStep("", "", f*w, "", ""))
				}
				this.Aframes.push(new QanimStep("", "", 0, "", ""))
				break
			case "SHRINK-R":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					if (i == 1) this.Aframes.push(new QanimStep(x+w-ww, y, ww, h, 1))
					else this.Aframes.push(new QanimStep(x+w-ww, "", ww, "", ""))
				}
				this.Aframes.push(new QanimStep(x, "", 0, "", ""))
				break
			case "SHRINK-W":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					if (i == 1) this.Aframes.push(new QanimStep(x+((w-ww)/2), y, ww, h, 1))
					this.Aframes.push(new QanimStep(x+((w-ww)/2), "", ww, "", ""))
				}
				this.Aframes.push(new QanimStep("", "", 0, "", ""))
				break
			case "SHRINK-H":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var wh=f*h
					if (i == 1) this.Aframes.push(new QanimStep(x, y+((h-wh)/2), w, wh, 1))
					else this.Aframes.push(new QanimStep("", y+((h-wh)/2), "", wh, ""))
				}
				this.Aframes.push(new QanimStep("", "", "", 0, ""))
				break
			case "SHRINK-S":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					var ww=f*w
					var wh=f*h
					this.Aframes.push(new QanimStep(x+((w-ww)/2), y+((h-wh)/2), ww, wh, 1))
				}
				this.Aframes.push(new QanimStep("", "", 0, 0, ""))
				break
			case "FADEOUT":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(x, y, w, h, f))
					else this.Aframes.push(new QanimStep("", "", "", "", f))
				}
				this.Aframes.push(new QanimStep("", "", "", "", 0))
				break
			case "IMPLODE-TL":
				for (var i=1; i<this.Frames; i++) {
					var f=1 - this.GetEaseFactor(this.Frames-1, i, this.Ease)
					if (i == 1) this.Aframes.push(new QanimStep(f*x, f*y, w, h, 1))
					else this.Aframes.push(new QanimStep(f*x, f*y, "", "", ""))
				}
				this.Aframes.push(new QanimStep(0, 0, "", "", ""))
				break
			default:
				window.alert(GetMsg(1, "Tipo de animação Out (" + this.TipAnim + ") para controlo (" + ctl.Hid + ") inexistente"))
				this.TipAnim=""
				this.Frames=0
				break
		}
	}
}

Qanimator.prototype.Activate=function(functarg) {
	this.FuncTarg=functarg
	if (this.TipAnim == "" && this.Sync == "N") {
		if (this.Ctl.Hobj != null) {
			App.StopIfAnimating(this.Ctl)
			if (this.InOut == "IN") {
				this.Ctl.Hobj.style.display="block"
				if (this.Ctl.Frame != undefined) this.Ctl.Frame.Resize("ANIM")
			} else {
				this.Ctl.Hobj.style.display="none"
			}
		}
		if (functarg == undefined) return
		functarg.call(this.Ctl)
	} else {
		App.AddAnimation(this)
	}
}

Qanimator.prototype.Animate=function() {
	if (this.Ctl.Hobj == null) {
		this.Frame=this.Frames
		if (this.FuncTarg == undefined) return
		this.FuncTarg.call(this.Ctl)
		return
	}
	if (this.Frame < this.Frames) {
		if (this.InOut != "WAIT") {
			if (this.TipAnim != "") {
				var wstep=this.Aframes[this.Frame]
				if (wstep.X !== "") this.Ctl.Hobj.style.left=wstep.X + "px"
				if (wstep.Y !== "") this.Ctl.Hobj.style.top=wstep.Y + "px"
				if (wstep.W !== "") this.Ctl.Hobj.style.width=wstep.W + "px"
				if (wstep.H !== "") this.Ctl.Hobj.style.height=wstep.H + "px"
				if (wstep.O !== "") this.Ctl.Hobj.style.opacity=wstep.O
			}
			if (this.InOut == "IN" && this.Ctl.Hobj.style.display != "block") this.Ctl.Hobj.style.display="block"
			if (this.Ctl.Frame != undefined) this.Ctl.Frame.Resize("ANIM")
		}
		this.Frame++
	}
	if (this.Frame >= this.Frames) {
		if (this.InOut != "WAIT") {
			if (this.Frames == 0 && this.InOut == "IN" && this.Ctl.Hobj.style.display != "block") this.Ctl.Hobj.style.display="block"
			if (this.InOut == "OUT") this.Ctl.Hobj.style.display="none"
			if (this.InOut == "MOVE") {
				if (wstep.X !== "") this.Ctl.Locsize.ObjL=wstep.X
				if (wstep.Y !== "") this.Ctl.Locsize.ObjT=wstep.Y
				if (wstep.W !== "") this.Ctl.Locsize.ObjW=wstep.W
				if (wstep.H !== "") this.Ctl.Locsize.ObjH=wstep.H
				if (this.Ctl.Resize != undefined) this.Ctl.Resize("ANIM")
			}
		}
		if (this.FuncTarg == undefined) return
		this.FuncTarg.call(this.Ctl)
	}
}


//Calcular factor para a animação dependendo de Ease, numero de frames e o numero da frame a calcular
Qanimator.prototype.GetEaseFactor=function(steps, step, ease) {
	var progress = step / steps;
	if (ease == 0) return progress;
	if (ease > 0 && ease <= 10) {
		var circle = 1 - Math.sin(Math.acos(progress));
		return (ease * circle + (10-ease) * progress) / 10;
	}
	if (ease >= -10 && ease <0) {
		var circle = Math.sin(Math.acos(1 - progress));
		return (-ease * circle + (10+ease) * progress) / 10;
	}
	if (ease == 50) { //efeito bounce tipo bola que saltita
		var wprogress = 1 - progress
		for(var a = 0, b = 1, result; 1; a += b, b /= 2) {
		    if (wprogress >= (7 - 4 * a) / 11) {
		      var bounce=-Math.pow((11 - 6 * a - 11 * wprogress) / 4, 2) + Math.pow(b, 2);
		      return 1-bounce;
		    }
	    }
	}
}


function QanimStep(x, y, w, h, opacity) {
	if (opacity == undefined) opacity="";
	this.X=x
	this.Y=y
	this.W=w
	this.H=h
	this.O=opacity
}



//***************************************************************** QFCONTROL - define controlo para controlo de ficheiros

function Qfcontrol(xnod, hostpage, hostpanel, hostborder) {
	this.Tipo = "FCONTROL"
	this.Class = "DISPLAY"
	this.HostPage = hostpage
	this.HostPanel = hostpanel
	this.HostDataPanel = FindDataPanel(this)
	this.HostBorder = hostborder
	this.Tipo4Style = this.Tipo
	this.Id = GetAtt(xnod, "ID", "")
	this.Datactl = GetAtt(xnod, "DATACTL", "")
	this.Datafld = GetAtt(xnod, "DATAFLD", "")
	this.Datactlobj = null
	this.Provider = GetAtt(xnod, "PROVIDER", "")
	this.Modulo = GetAtt(xnod, "MOD", "")
	this.Nivseg = GetAtt(xnod, "NIVSEG", "0")
	this.ReadOnly = GetAtt(xnod, "READONLY", "N")
	this.source = GetAtt(xnod, "SOURCE", "")//Novo atributo definido para indicar a fonte de dados do controlo, fonte essa correspondente à key e nome da tabela que utiliza os docums.
	this.Locsize = new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)

	if (this.HostPage.Func == "VIS" || this.HostPage.Func == "ELI")
		this.ReadOnly = "S";

	if (this.Datactl != "") {
		this.DatactlObj = hostpage.GetCtl(this.Datactl)
		if (this.DatactlObj == null) {
			window.alert(GetMsg(1, "FCONTROL (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
			return
		}
	}

	this.Provider = this.DatactlObj.Provider
	this.Cols = new Array()

	this.Active = false//indica se o controlo está a ser utilizado ou não (muito útil para saber qual o controlo que está a ser utilizado na acção "Ver Todas")


	//Inicialização das Cols do controlo que correspondem a três valores, código do tuplo na tabela que utiliza os docums, a fk e o nome do ficheiro nessa tabela.
	var cod = new Object()
	cod.Id = this.Datafld
	this.Cols.push(cod); //cod da tabela que utiliza o docums.
	var sources = this.source.split(",")
	var source1 = new Object()
	source1.Id = sources[0]//nome
	this.Cols.push(source1);
	var source2 = new Object()
	source2.Id = sources[1]//coddocum
	this.Cols.push(source2);


	if (this.Datactl != "") {
		this.DataCol = this.DatactlObj.GetCol(this.Datafld)
	} else {
		this.DataCol = new Qcol(null, this.Datafld, "A", "255")
	}

	if (this.Id == "") {
		this.Id = "FCONTROL" + hostpage.Actls.length
	}

	var re = (/\//g);
	this.TxtOrig = GetAtt(xnod, "TXT", "")
	this.TxtOrig = this.TxtOrig.replace(re, "<br>")


	this.Dados = new Array()
	this.ficheiro = new Object()//Objecto correspodente a informação do ficheiro existente no controlo.

	this.Visivel = GetAtt(xnod, "VIS", "S")
//	var locsiz = GetLocationSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"))

	this.Left = this.Locsize.Left
	this.Top = this.Locsize.Top
	this.Width = this.Locsize.Width
	this.Height = this.Locsize.Height
	this.Actls = new Array()
	this.Values = new Array()

	this.Style = GetAtt(xnod, "STYLE", hostpanel.Style)

	var wdiv = CreateDiv(hostpanel.PanelObj, this.Hid)
	wdiv.style.display = "none"
	wdiv.style.zIndex = 1
	this.Locsize.Resize(wdiv)
	this.Hobj = wdiv
//	var wdiv = document.createElement("DIV")
//	wdiv.style.position = "absolute"
//	wdiv.style.overflow = "hidden"

//	hostpanel.Panel.appendChild(wdiv)

//	ResizeControl(wdiv, hostpanel.Panel.style.width, hostpanel.Panel.style.height, this.Left, this.Top, this.Width, this.Height, this.HostBorder)

	this.StyleObj = App.GetStyle(this.Style, this.Tipo4Style)
	this.Frame = new Qframe(this)

//	var wstyle = GetStyle(this)
//	if (wstyle != null) {
//		if (wstyle.FCONTROL != undefined) {
//			wdiv.style.backgroundColor = wstyle.FCONTROL.backgroundColor
//			wdiv.style.borderColor = wstyle.FCONTROL.borderColor
//			wdiv.style.borderWidth = wstyle.FCONTROL.borderWidth
//			wdiv.style.borderStyle = wstyle.FCONTROL.borderStyle
//			wdiv.style.color = wstyle.FCONTROL.color
//			wdiv.style.fontFamily = wstyle.FCONTROL.fontFamily
//			wdiv.style.fontSize = wstyle.FCONTROL.fontSize
//			wdiv.style.fontWeight = wstyle.FCONTROL.fontWeight
//		}
//	}

	//Criação da área de "click"
	var wspan = document.createElement("DIV")
	wspan.style.position = "absolute"
	wspan.style.cursor = "pointer"
	wspan.style.left = GetSizeNumber(wdiv.style.width) - (App.NovaWeb == "S" ? 19 : 22) + "px"
	wspan.style.width = "19px"
	wspan.style.height = wdiv.style.height
	wspan.style.zIndex = 1
	wspan.style.textAlign = "center";
	wspan.unselectable = true
	wspan.onclick = showList

	this.Bspan=wspan  //acrescentado por FHC 30/11/2015

	//Criação da imagem correspondente à seta
	var wimg = document.createElement("IMG")
	wimg.id = hostpage.Area.Id + ".IMG"
	wimg.style.position = "relative"
	wimg.style.cursor = "pointer"
	wimg.style.top = /*((GetSizeNumber(wdiv.style.height)-10) / 2) + "px"*/"5px"
	wimg.style.width = "10px"
	wimg.style.height = "10px"
	wimg.src = GetImageAddress("fcontrol_seta.png")
	wimg.style.zIndex = 1
	wimg.unselectable = true
	wspan.appendChild(wimg)
	wdiv.appendChild(wspan)

	this.Bseta=wimg  //acrescentado por FHC 30/11/2015

	//Criação da área de "click"
	var wspan2 = document.createElement("SPAN")
	wspan2.style.position = "absolute"
	wspan2.style.cursor = "pointer"
	wspan2.style.width = GetSizeNumber(wdiv.style.width) - 20 + "px"
	wspan2.style.height = GetSizeNumber(wdiv.style.height) - 2 + "px"
	wspan2.style.left = "0px"
	wspan2.style.zIndex = 10

	this.Bclick=wspan2  //acrescentado por FHC 30/11/2015

	//Criação do elemento onde é colocado o texto
	var wtext = document.createElement("INPUT")
	wtext.style.position = "absolute"
	wtext.style.cursor = "pointer"
	wtext.style.width = GetSizeNumber(wdiv.style.width) - 40 + "px"
	wtext.style.height = GetSizeNumber(wdiv.style.height) - 2 + "px"
	wtext.style.left = "0px"
	wtext.style.top = "0px"
	wtext.style.textAlign = "left"
	wtext.style.paddingLeft = "20px";
	//wtext.style.paddingTop = "2px";
	wtext.unselectable = !wtext.unselectable
	wtext.style.borderStyle = "none";
	wtext.style.background = "transparent url(" + GetImageAddress("document.png") + ") no-repeat left";
	if (this.ReadOnly == "S") {
		wtext.readOnly = true
		wtext.disabled = true
	}

	this.Bclick2=wtext  //acrescentado por FHC 30/11/2015

	var idAux = this.Id
                                                  
	wspan2.onclick = (function () {
		if (this.childNodes[0].value == MsgSet[44]) {
			if (!BrowserIE) {
				document.getElementById(idAux + "-Anexar").click = function () {
					var evt = this.ownerDocument.createEvent('MouseEvents');
					evt.initMouseEvent('click', false, true, this.ownerDocument.defaultView, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
					this.dispatchEvent(evt);
				}
			}

			document.getElementById(idAux + "-Anexar").click()

		} else {
			if (!BrowserIE) {
				document.getElementById(idAux + "-Abrir").click = function () {
					var evt = this.ownerDocument.createEvent('MouseEvents');
					evt.initMouseEvent('click', false, true, this.ownerDocument.defaultView, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
					this.dispatchEvent(evt);
				}
			}

			document.getElementById(idAux + "-Abrir").click()
		}
	})

	wtext.style.zIndex = 2
	wdiv.style.zIndex = 1

//	if (wstyle != null) {
//		if (wstyle.FCONTROL != undefined) {
//			wspan.style.borderLeft = "1px solid " + (wstyle.FCONTROL.borderColor != "" ? wstyle.FCONTROL.borderColor : "black");
//			wtext.style.color = wstyle.FCONTROL.color
//			wtext.style.fontFamily = wstyle.FCONTROL.fontFamily
//			wtext.style.fontSize = wstyle.FCONTROL.fontSize
//			wtext.style.fontWeight = wstyle.FCONTROL.fontWeight
//		}
//	}


	wspan2.appendChild(wtext);
	wdiv.appendChild(wspan2)

	//Indicação que o tipo de função que vai na mensagem é FCT, ou seja File ConTrol
	this.Func = "FCT"
	//Opção inicial, pedir informação
	this.Opt = "Info"

	this.operations = new Array()

	var xn = xnod.firstChild

	while (xn != undefined) {
		this.operations[xn.nodeName] = new Object()
		this.operations[xn.nodeName].ACT = GetAtt(xn, "ACT", "")
		this.operations[xn.nodeName].VIS = GetAtt(xn, "VIS", "S")
		xn = xn.nextSibling
	}

	//Criação do novo controlo (lista de opções)
	wdiv.id = this.Id
	this.Hobj = wdiv
	//this.Actls.push(new QfcontrolList(wdiv, hostpanel, this, /*wstyle.FCONTROL != undefined ? wstyle.FCONTROL :*/ ""))

	//criação da lista para poder funcionar quando está numa pataleta
	this.Actls.push(new QfcontrolList(this.Hobj, this.HostPanel, this, /*wstyle.FCONTROL != undefined ? wstyle.FCONTROL :*/ ""))
	this.Actls[0].Hide();
	this.FcontrolList=this.Actls[0];  //FHC atribuir uma variavel à lista

	if (this.Datactl != "") this.DatactlObj.AddFieldCtl(this.Datafld, this)
	if (this.Visivel == "N") this.Hide()

	this.Activated = false
}

function hideList(e) {
	if (!e) var e = window.event;
	var tg = (window.event) ? e.srcElement : e.target;
	var toElem = (BrowserMOZ) ? e.relatedTarget : e.toElement;

	if (tg.className != "fclist" && toElem != null)
		if ((tg.nodeName == "LI" || tg.nodeName == "IMG" || tg.nodeName == "UL") && (toElem.nodeName != "LI" && toElem.nodeName != "UL")) {
			var elems = document.getElementsByTagName("DIV")

			for (var i = 0; i < elems.length; i++) {
				if (elems[i].className == "fclist")
					elems[i].style.display = "none"
			}
		}
}

//***************************************************************** QFCONTROLLIST - define controlo para a lista do menu
function QfcontrolList(wdiv, hostpanel, parent, style) {
	this.parent = parent;

	this.Tipo = "FCONTROLLIST"
	this.Class = "DISPLAY"
//	this.HostPage = hostpage
//	this.HostPanel = hostpanel
//	this.HostDataPanel = FindDataPanel(this)
//	this.HostBorder = hostborder
	this.Tipo4Style = this.Tipo

	this.StyleObj = App.GetStyle(this.Style, this.Tipo4Style)

	this.Actls = [];

	var hpHeight = Number(hostpanel.Height);
	var wdivTop = GetSizeNumber(wdiv.style.top)
	var wdivHeight = GetSizeNumber(wdiv.style.height)
	var diff = hpHeight - wdivTop - wdivHeight;
	var height = "auto";

	//cria o div principal para colocar a lista
	var wdivlist1 = document.createElement("div")
	wdivlist1.style.position = "absolute"
	wdivlist1.style.cursor = "pointer"
	wdivlist1.style.width = "100px"

	if (diff < 65) {
		height = diff - 5 + "px";
		wdivlist1.style.overflow = "auto";
	}
	var offset=GetOffsetFor("APP", hostpanel)
	wdivlist1.style.height = height
	wdivlist1.style.backgroundColor = style != "" ? style.backgroundColor : "white"
	wdivlist1.style.borderStyle = style != "" ? style.borderStyle : "solid"
	wdivlist1.style.borderColor = style != "" ? style.borderColor : "black"
	wdivlist1.style.borderWidth = style != "" ? style.borderWidth : "1px"
	wdivlist1.style.fontSize = style != "" ? GetSizeNumber(style.fontSize) - 1 + "pt" : "7pt"
	wdivlist1.style.left = (GetSizeNumber(wdiv.style.left) + GetSizeNumber(wdiv.style.width) - 100 + offset.Left) + "px"
	wdivlist1.style.top = (GetSizeNumber(wdiv.style.top) + GetSizeNumber(wdiv.style.height) + offset.Top + (BrowserIE ? 0 : 2)) + "px"
	wdivlist1.style.textAlign = "center"
	wdivlist1.style.zIndex = 98
	wdivlist1.style.display = "none"
	wdivlist1.id = parent.Id + '-fclist'
	wdivlist1.className = "fclist"
	wdivlist1.style.borderTopWidth = "0px";


	/*wdivlist1.style.color = style.color;
	wdivlist1.style.fontFamily = style.fontFamily;
	wdivlist1.style.fontSize = style.fontSize;
	wdivlist1.style.fontWeight = style.fontWeight;*/

	// wdivlist1.onmouseout = hideList
	wdivlist1.onmouseout = hideList

	//cria a lista
	var list = document.createElement("ul")

	//criação dos elementos, o seu id indica a accção (futuramente passará para class para poder haver mais do que um controlo)
	var color = style != "" ? style.hoverColor : "#A4D6F0";

	var lElem0 = document.createElement("li")
	lElem0.innerHTML = MsgSet[25]
	lElem0.id = parent.Id + "-Abrir"
	lElem0.onclick = function (evt) { elemClick(evt, parent); };
	lElem0.onmouseover = (function () { this.style.backgroundColor = color })
	lElem0.onmouseout = (function () { this.style.backgroundColor = "" })
	list.appendChild(lElem0)

	var lElem1 = document.createElement("li")
	lElem1.innerHTML = MsgSet[26]
	lElem1.id = parent.Id + "-Anexar"
	lElem1.onclick = function (evt) { elemClick(evt, parent); };
	lElem1.onmouseover = (function () { this.style.backgroundColor = color })
	lElem1.onmouseout = (function () { this.style.backgroundColor = "" })
	list.appendChild(lElem1)
	//TODO
	var lElem2 = document.createElement("li")
	lElem2.innerHTML = MsgSet[27]
	lElem2.className = this.parent.Hobj.id + " " + "FDIGITALIZAR"
	lElem2.onmouseover = (function () { this.style.backgroundColor = color })
	lElem2.onmouseout = (function () { this.style.backgroundColor = "" })


	if (parent.operations["FDIGITALIZAR"].ACT != "")
		lElem2.onclick = operClick

	list.appendChild(lElem2)
	var lElem3 = document.createElement("li")
	lElem3.innerHTML = "Fonte imagens"
	lElem3.className = this.parent.Hobj.id + " " + "FIMAGES"
	lElem3.onmouseover = (function () { this.style.backgroundColor = color })
	lElem3.onmouseout = (function () { this.style.backgroundColor = "" })

	if (parent.operations["FIMAGES"].ACT != "")
		lElem3.onclick = operClick

	list.appendChild(lElem3)

	var lElem4 = document.createElement("li")
	lElem4.innerHTML = MsgSet[28]
	lElem4.className = this.parent.Hobj.id + " " + "FTEMPLATE"
	lElem4.onmouseover = (function () { this.style.backgroundColor = color })
	lElem4.onmouseout = (function () { this.style.backgroundColor = "" })
	if (parent.operations["FTEMPLATE"].ACT != "")
		lElem4.onclick = operClick

	list.appendChild(lElem4)
	var lElem5 = document.createElement("li")
	lElem5.innerHTML = MsgSet[29]
	lElem5.id = parent.Id + "-Edit"
	lElem5.onclick = function (evt) { elemClick(evt, parent) }
	lElem5.onmouseover = (function () { this.style.backgroundColor = color })
	lElem5.onmouseout = (function () { this.style.backgroundColor = "" })
	list.appendChild(lElem5)

	var lElem6 = document.createElement("li")
	lElem6.innerHTML = MsgSet[30]
	lElem6.id = parent.Id + "-Vers"//A acção é Vers porque em primeiro lugar pede-se a última versão do documento para assim saber qual a versão seguinte (minor e major).,
	lElem6.onclick = function (evt) { elemClick(evt, parent) }
	lElem6.onmouseover = (function () { this.style.backgroundColor = color })
	lElem6.onmouseout = (function () { this.style.backgroundColor = "" })
	list.appendChild(lElem6)

	var lElem7 = document.createElement("li")
	lElem7.innerHTML = MsgSet[31]
	lElem7.style.background = "url(" + GetImageAddress("fcontrol_setadir.png") + ") no-repeat right"
	lElem7.onmouseover = (function () { this.style.backgroundColor = color })
	lElem7.onmouseout = (function () { this.style.backgroundColor = "" })
	//Abre a lista das versões
	lElem7.onmouseover = elem7Hover
	list.appendChild(lElem7)

	var lElem8 = document.createElement("li")
	lElem8.innerHTML = MsgSet[32]
	lElem8.id = parent.Id + "-Remo"
	lElem8.onclick = function (evt) { elemClick(evt, parent) }
	lElem8.onmouseover = (function () { this.style.backgroundColor = color })
	lElem8.onmouseout = (function () { this.style.backgroundColor = "" })
	list.appendChild(lElem8)

	var lElem9 = document.createElement("li")
	lElem9.innerHTML = MsgSet[33]
	lElem9.style.borderTopStyle = style != "" ? style.borderStyle : "solid"
	lElem9.style.borderTopWidth = style != "" ? style.borderWidth : "1px"
	lElem9.style.borderTopColor = style != "" ? style.borderColor : "Black"
	lElem9.id = parent.Id + "-Prop"
	lElem9.onmouseover = (function () { this.style.backgroundColor = color })
	lElem9.onmouseout = (function () { this.style.backgroundColor = "" })
	lElem9.onclick = function (evt) { elemClick(evt, parent); };
	list.appendChild(lElem9)


	//Estilo Hardcoded que estava no  fcontrol.css e agora está aqui, melhorar (Qweb 3.0?)
	list.style.listStyleType = "none";
	list.style.padding = "0px";
	list.style.margin = "0px";
	list.style.zIndez = "999";
	for (var i = 0; i < list.childNodes.length; i++) {
		list.childNodes[i].style.padding = "5px";
		list.childNodes[i].style.width = "auto";
		list.childNodes[i].style.textAlign = "left";
		list.childNodes[i].style.zIndex = "999";
	}
	//#####################################################################################
	wdivlist1.appendChild(list)
	//hostpanel.PanelObj.appendChild(wdivlist1)
	App.Hobj.appendChild(wdivlist1)
	this.Hobj = wdivlist1

	this.Activated = false;
}

QfcontrolList.prototype.Activate = function () {
	GenericDisplayCtl_Activate.call(this)
}

QfcontrolList.prototype.Activate2 = function () {
}

QfcontrolList.prototype.Show = function (opt) {
	GenericDisplayCtl_Show.call(this, opt)
	this.Hobj.style.display = "block"
}

QfcontrolList.prototype.Hide = function (opt) {
	GenericDisplayCtl_Hide.call(this, opt)
	this.Hobj.style.display = "none"
}

QfcontrolList.prototype.SetState = function (st) {
	GenericDisplayCtl_SetState.call(this, st)
}

QfcontrolList.prototype.Resize = function () {
	GenericDisplayCtl_Resize.call(this)
}

QfcontrolList.prototype.Destroy = function (opt) {
	GenericDisplayCtl_Destroy.call(this, opt)
}

QfcontrolList.prototype.Destroy2 = function () {
	GenericDisplayCtl_Destroy2.call(this)
}

function operClick(evt) {
	if (BrowserIE || BrowserOP) {
		var className = window.event.srcElement.className
	} else {
		var className = evt.target.className
	}

	var classes = className.split(" ")
	var ctls = App.Apage.ActivePage.Actls
	var parent = new Object()

	for (var i = 0; i < ctls.length; i++) {
		if (ctls[i].Tipo == "FCONTROL" && ctls[i].Hobj.id == classes[0]) {
			parent = ctls[i]
		}
	}

	ExecCmd(App.Apage.Id, parent.operations[classes[1]].ACT)
}


function elemClick(evt, control) {//Função utilizada para todas as entradas do menu, sendo que o id indica a operação a fazer. A função tem como objectivo "forçar" o pedido ao servidor consoante o elemento "clickado"
	if (BrowserIE || BrowserOP) {
		var id = window.event.srcElement.id
	} else {
		var id = evt.target.id
	}

	var ctls = App.Apage.ActivePage.Actls

	var parts = id.split("-")
	var control = App.Apage.ActivePage.GetCtl(parts[0])

	//for (var i = 0; i < ctls.length; i++) {
		//if (ctls[i].Tipo == "FCONTROL" && ctls[i].Id == parts[0]) {
		    //var control = ctls[i].Id;
			SetHistorialCmd(App.Apage, "controlo", control.Id, "EQ")
			var option = parts[1];
			var teste = "SetHistorial(" + control.Id + ".keyOpen," + control.ficheiro.key;
			if (teste != undefined && control.ficheiro.key != undefined) {
				var versao = control.ficheiro.vers;
				if (versao == "1")
					ExecCmd("", "SetHistorial(" + control.Id + ".keyOpen," + control.ficheiro.key);
				else
					ExecCmd("", "SetHistorial(" + control.Id + ".keyOpen," + control.ficheiro.docid);
			}
            document.getElementById(control.Id + '-fclist').style.display = 'none';
			var listV = document.getElementById(control.Id + '-versionsl')

			if (listV != undefined) {
				listV.style.visibility = "hidden"
			}
			switch (option) {
				case "DelU":
					var answer = confirm(MsgSet[63])
					if (answer) {
					    control.Func = 'FCT';
					    control.Opt = option;
					    control.Send();
					} else
						return
					break;
				case "DelH":
					var answer = confirm(MsgSet[64])
					if (answer) {
					    control.Func = 'FCT';
					    control.Opt = option;
					    control.Send();
					} else
						return
					break;
				case "Remo":
					var answer = confirm(MsgSet[65])
					if (answer) {
					    control.Func = 'FCT';
					    control.Opt = option;
					    control.Send();
					} else
					   	return
					break;
				case "AVers":
					option = ""

					for (var j = 2; j < parts.length; j++)
						option += parts[j] + "-";

					option = option.substring(0, option.length - 1);
					control.Func = 'FCT';
					control.Opt = option;
					control.Send();
					return
				case "Anexar":
				    control.Opt = option;
					ExecCmd(App.Apage.Id, "OpenDialog(QwRUPLOAD,ALT")
					return
				default:
				    control.Func = 'FCT';
				    control.Opt = option;
				    control.Send();
					return
			}
		//}
	//}
}

function versaoClicked(evt) {//Função para abrir versão escolhida no dbedit das versões.

	var actpage = App.Apage.ActivePage
	var wpage=null
	for (var i = 0; i < App.Apage.Pages.length; i++) {
		if (actpage.Id == App.Apage.Pages[i].Id) {
			wpage = App.Apage.Pages[i - 1]
			break
		}
	}

	var ctl=versaoclickedfind(wpage)
	if (ctl != null) {
		var idFich = GetHistorialIndex(actpage.Area, "docums", "EQ")
		if (idFich > -1) {
			ctl.Opt = actpage.Area.Historial[idFich].Valor
			ctl.Send();
		}
	}

	/*
	var ctls
	for (var i = 0; i < App.Apage.Apages.length; i++) {
		if (actpage.Id == App.Apage.Apages[i].Id) {
			ctls = App.Apage.Apages[i - 1].Actls
			break
		}
	}

	for (var i = 0; i < ctls.length; i++) {
		if (ctls[i].Tipo == "FCONTROL") {
			if (ctls[i].Active) {
				var idFich = GetHistorialIndex(actpage.Area, "docums", "EQ")
				if (idFich > -1) {
					ctls[i].Opt = actpage.Area.Historial[idFich].Valor
					ctls[i].Send();
					break;
				}
			}
		}
	}
	*/
	return ""
}


function versaoclickedfind(ctl) {   //******* Procurar um FCONTROL Activo controlo na hierarquia
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	for (var i=0; i<ctl.Actls.length; i++) {
		if (ctl.Actls[i].Tipo == "FCONTROL") {
			if (ctl.Actls[i].Active) return ctl.Actls[i];
		}
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=versaoclickedfind(ctl.Actls[i]);
		if (wctl != null) return wctl;
	}
	return null;
}


function elem7Hover(evt) //evento de mostrar a caixa das versões
{
	if (this.childNodes.length < 2) {
		return;
	}

	var pieces = this.childNodes[1].id.split("-")

	var ctl = document.getElementById(pieces[0] + "-versionsl")
	ctl.style.display = "block"
	ctl.style.visibility = "visible"
	ctl.style.position = "absolute"
	//  ctl.style.border = "1px solid black"
	if (!BrowserIE)
		ctl.style.marginLeft = (ctl.parentNode.offsetWidth - 5) + "px";
	else
		ctl.style.marginLeft = "60px";

	ctl.style.top = ctl.parentNode.offsetTop + "px"
	ctl.style.width = "100%";
}

function elem7HoverOut(evt) {//evento de esconder a caixa das versões
	var pieces = this.childNodes[0].id.split("-")

	// var pieces = id.split("-")
	var ctl = document.getElementById(pieces[0] + "-versionsl")
	ctl.style.display = "none"
}

function showList(evt) //Evento de mostrar a lista (lançado quando se carrega na imagem da seta)
{
	var ctls = App.Apage.ActivePage.Actls
	var id = this.parentNode.id

	var ctl = document.getElementById(id + "-fclist")
	var ctl2 = document.getElementById(id + "-versionsl")


	var ctl2 = document.getElementById(id + "-versionsl")

	if (ctl2 != undefined)
		ctl2.style.display = 'none'

	if (ctl.style.display == 'none') {
		ctl.style.display = 'block'
	} else {
		ctl.style.display = 'none'
	}
}

Qfcontrol.prototype.SetState = function (st) {
	GenericDisplayCtl_SetState.call(this, st)
}

Qfcontrol.prototype.Disable = function () {
	//if(this.host
	if (this.DatactlObj.HostFunc == "VIS")
		this.ReadOnly = "S";
}
//TODO
Qfcontrol.prototype.Enable = function () { }

Qfcontrol.prototype.SetVal = function (valor, cmd) {//Função que é chamada inicialmente e que serve para actualizar o atributo value que contem a chave da tabela.

	var elem = this.Actls[0].Hobj.childNodes[0]//Elemento correspondente ao menu

	if (valor != "") {
		//this.Hobj.childNodes[1].value = valor
		//this.SetNewVal(valor)
		this.value = valor//Actualiza a chave da area actual.
		this.Send();
	} else {
		this.SetNewVal(MsgSet[44])
		//this.Hobj.childNodes[1].value = "Anexar Documento"
		elem.childNodes[0].style.display = "none"
		elem.childNodes[1].style.display = "block"

		if (this.ReadOnly == "N") {
			if (this.operations["FDIGITALIZAR"].VIS == "S")
				elem.childNodes[2].style.display = "block"
			else
				elem.childNodes[2].style.display = "none"

			if (this.operations["FIMAGES"].VIS == "S")
				elem.childNodes[3].style.display = "block"
			else
				elem.childNodes[3].style.display = "none"

			if (this.operations["FTEMPLATE"].VIS == "S")
				elem.childNodes[4].style.display = "block"
			else
				elem.childNodes[4].style.display = "none"

			elem.childNodes[5].style.display = "none"
			elem.childNodes[6].style.display = "none"
			elem.childNodes[7].style.display = "none"
			elem.childNodes[8].style.display = "none"
			elem.childNodes[9].style.display = "none"
			this.Hobj.childNodes[1].style.color = "#666666"
			// this.Hobj.childNodes[1].childNodes[0].disabled = true
		} else {  //acrescentado por FHC em 30/11/2015 
			this.SetNewVal("") //retirar o texto de anexar
			this.Bspan.style.cursor="default"
			this.Bspan.onclick=""
			this.Bspan.disabled=true
			this.Bseta.style.cursor="default"
			this.Bseta.disabled=true
			this.Bclick.style.cursor="default"
			this.Bclick.onclick=""
			this.Bclick.disabled=true
			this.Bclick2.style.cursor="default"
			this.Bclick2.disabled=true
		}

		//Actualiza os valores das colunas do Form que são utilizadas pelo controlo (Atributo SOURCE)
		this.DatactlObj.StoreVal(this.Cols[2].Id, "");
		this.DatactlObj.StoreVal(this.Cols[1].Id, "");
	}
}

Qfcontrol.prototype.SetNewVal = function (valor, cmd) {//Altera o valor no HTML (no input)
	this.Hobj.childNodes[1].childNodes[0].value = valor
}

Qfcontrol.prototype.Show = function (opt) {
	GenericDisplayCtl_Show.call(this, opt)
	this.Hobj.style.display = "block"
	//this.Actls[0].Hide(opt);
}

Qfcontrol.prototype.Refresh = function () {//Função chamada quando é realizado o UpdateCtls. Tem três comportamenteos distintos,
	//se tiver no historial o valor "modo" então pede ao servidor informação consoante esse "modo", senão por omissão pede apenas a "Info", ou seja, actualiza o controlo.

	var modo = GetHistorialIndex(this.HostPage.Area, "modo", "EQ")
	/*RGM */

	var indice = GetHistorialIndex(this.HostPage.Area, "controlo", "EQ")

	if (indice != -1) {
		var controlo = this.HostPage.Area.Historial[indice].Valor
		if (controlo != this.Id)
			return
	}

	if (modo > -1) {
		var hix = GetHistorialIndex(this.HostPage.Area, "path", "EQ")
		var path = ""

		if (hix > -1) {
			path = this.HostPage.Area.Historial[hix].Valor
			this.ficheiro.nome = path
			this.Opt = this.HostPage.Area.Historial[modo].Valor
		}

		if (this.Opt != "Info")
			this.Opt = this.HostPage.Area.Historial[modo].Valor
		/*RGM*/
		if (controlo != this.Id) {
			this.Opt = "Info"
		}
	}
	else {
		this.Opt = "Info"
		this.Active = false
	}
	this.Send()
}

Qfcontrol.prototype.Hide = function (opt) {
	GenericDisplayCtl_Hide.call(this, opt)
	this.Hobj.style.display = "none"
}

Qfcontrol.prototype.Activate = function () {
	GenericDisplayCtl_Activate.call(this)
	this.Relocate();
	this.FcontrolList.Hide();

	//as linhas seguintes foram contadas porque a lista foi criada antes para poder estar dentro de uma pataleta
	//this.Actls.push(new QfcontrolList(this.Hobj, this.HostPanel, this, /*wstyle.FCONTROL != undefined ? wstyle.FCONTROL :*/ ""))
	//this.Actls[0].Hide();
}

Qfcontrol.prototype.Activate2 = function () {
	//this.Send() //Se for feito aqui vai vazio, vai ser feito durante o setval
	this.Show()
}

Qfcontrol.prototype.Send = function () {//Função que envia o pedido ao servidor, pedido esse indicado no atributo Opt.
	var iblk = new Interblk()

	//Se for o atributo Prop, ou seja Propriedades, não é necessário comunicar com os servidor porque essa informação já foi recebida inicialmente.
	if (this.Opt == "Prop") {
		this.Proper();
		return;
	}
	//Aqui verifica se a Opt tem um espaço (chaves numéricas) ou se é maior do que 6 (para GUID) para saber que a acção consiste na abertura de um ficheiro de versão.
	else if (this.Opt.indexOf(" ") != -1 || this.Opt.length > 6) {
		iblk.FICH = this.Opt
		this.Opt = "Abrir"
	}
	//Se a Opt for "Abrir" o novo atributo FICH fica com a key do ficheiro actual para enviar para o server.
	else if (this.Opt == "Abrir") {
		iblk.FICH = this.ficheiro.key
	}
	//O atributo FICH fica com o nome do ficheiro a submeter que está na pasta temp.
	else if (this.Opt == "Subm")
		iblk.FICH = this.ficheiro.nome
	else if (this.Opt == "VTod") {
		this.Opt = "Abrir"
		this.Active = true
		/*RGM*/
		var indice = GetHistorialIndex(this.HostPage.Area, this.Id + ".keyOpen", "EQ")
		if (indice != -1) {
			var valor = this.HostPage.Area.Historial[indice].Valor
			ExecCmd("", "SetHistorial(keyOpen," + valor);
			ExecCmd(this.HostPage.Area.Id, "OpenDialog(QwVERSIONS,ALT")
		}
		return;
	} else if (this.Opt == "Anexar") {
		iblk.FICH = this.ficheiro.nome;
	}

	iblk.MOD = User.GetModDb(this.HostPage.Modulo)
	iblk.APP = this.Provider
	iblk.IDENT = this.Id
	iblk.FUNC = this.Func
	iblk.COND = this.Datafld + "[=['" + this.value + "'"

	iblk.APP = this.Provider
	iblk.MSG = this.Opt

	var wrec=new Array()
	for (var i = 0; i < this.Cols.length; i++) {
		var col = this.Cols[i]
		iblk.CMPS.push(this.Cols[i].Id)
		wrec.push("")
	}
	iblk.DADOS.push(wrec)
	var keyDocumsVal = this.DatactlObj.GetVal(this.Cols[1].Id);
	// só envia a mensagem para o servidor caso seja realmente necessário
	if (keyDocumsVal != "" || (this.Opt == "Anexar" && iblk.FICH != undefined) || this.Opt == "Subm" || this.Opt == "Info")
		SendServer(this.HostPage, iblk, "SINGLE")
	else
		this.SetVal("")
}

Qfcontrol.prototype.Receive = function (iblk, gstatus) {

	var opt = this.Opt
	var widados=""
    for (var r=0; r<iblk.DADOS.length; r++) {
    	if (r>0) widados += "{"
    	for (var c=0; c<iblk.DADOS[r].length; c++) {
    		if (c>0) widados += "["
    		widados += iblk.DADOS[r][c]
    	}
    }

	switch (opt) {
		case "Anexar":
			var results = widados.split("|")

			if (results[1] != "") {
				//Actualiza a chave do Form "pai" do controlo
				var results = results[1].split("[")
				var newKey = results[results.length - 1].split(":")
				this.DatactlObj.StoreVal(this.Cols[1].Id, newKey[1]);
				/*RGM*/
				ExecCmd("", "SetHistorial(" + this.Id + ".keyOpen," + newKey[1]);

				this.Opt = "Info"
				this.Active = true
			}
			this.Info(iblk)
			break;
		case "Info":
			this.Info(iblk)
			break
		case "Abrir":
			this.Abrir(iblk)
			break
		case "AVer":
			this.AVer(iblk)
			break
		case "DelU":
			this.DelU(iblk)
			break
		case "DelH":
			this.DelH(iblk)
			break
		case "Edit":
			this.Edit(iblk)
			break
		case "Subm":
			this.Subm(iblk)
			break
		case "Remo":
			this.Remo(iblk)
			break
		case "Vers":
			this.Vers(iblk)
			break
	}
}

Qfcontrol.prototype.Info = function (iblk) {
	var widados=""
    for (var r=0; r<iblk.DADOS.length; r++) {
    	if (r>0) widados += "{"
    	for (var c=0; c<iblk.DADOS[r].length; c++) {
    		if (c>0) widados += "["
    		widados += iblk.DADOS[r][c]
    	}
    }
	/*
	Lista de versões e documid (exemplo:),
	Informação do ficheiro (exemplo: ),
	Estado do ficheiro (Se está a ser editado ou não por outro utilizador) (exemplo: NOTCOMITTED (esta a ser editado)/ COMMITTED (pode editar))
	*/
	if (iblk.STAT != "OK") {
		this.SetVal("")
	}
	else {
		var list = this.Actls[0].Hobj.childNodes[0]
		if (this.ReadOnly == "S") {
			this.Hobj.childNodes[1].childNodes[0].readOnly = true
			this.Hobj.childNodes[1].childNodes[0].disabled = true
			list.childNodes[0].style.paddingTop = "10px";
			list.childNodes[list.childNodes.length - 1].style.paddingTop = "10px";
			list.childNodes[list.childNodes.length - 1].style.paddingBottom = "9px";
		}
		var results = widados.split("|")

		//Iniciar as opções por omissão (Abrir e Propriedades)
		list.childNodes[0].style.display = "block"//Abrir
		//Verificar se tem ficheiro (a primeira posição indica a informação do ficheiro da seguinte forma:
		//ficheiro.gif,215.0 bytes,gif,@web,11/11/2010 16:30:56,1,@web
		//nome do ficheiro, tamanho do ficheiro, extensão, utilizador que criou o ficheiro, data de criação, versão, utilizador que modificou o ficheiro
		if (results[0] != "") {
			var info = results[0].split(",")
			this.DatactlObj.StoreVal(this.Cols[2].Id, info[0]);
			this.ficheiro.nome = info[0]
			this.ficheiro.tamanho = info[1]
			this.ficheiro.ext = info[2]
			this.ficheiro.autor = info[3]
			this.ficheiro.data = info[4]
			this.ficheiro.vers = info[5]
			this.ficheiro.docid = info[6]
			this.ficheiro.edicao = info[7]
			this.SetNewVal(info[0])//altera o valor no HTML (no input)
		}
		else {
		    this.SetVal("");
		    return;
		}

		if (this.ReadOnly != "S") {
			list.childNodes[9].style.display = "block"//Propriedades
			list.childNodes[1].style.display = "none"//Anexar
			list.childNodes[2].style.display = "none"//Digitalizar
			list.childNodes[3].style.display = "none"//Fonte imagens
			list.childNodes[4].style.display = "none"//Template
			list.childNodes[5].style.display = "none"//Editar
			list.childNodes[6].style.display = "none"//Submeter
			list.childNodes[7].style.display = "none"//Versões
			list.childNodes[8].style.display = "none"//Apagar
		} else {
			if (list.childNodes.length > 2) {
				list.childNodes[9].style.display = "block"//Propriedades
				list.childNodes[1].style.display = "none"//Anexar
				list.childNodes[2].style.display = "none"//Digitalizar
				list.childNodes[3].style.display = "none"//Fonte imagens
				list.childNodes[4].style.display = "none"//Template
				list.childNodes[5].style.display = "none"//Editar
				list.childNodes[6].style.display = "none"//Submeter
				list.childNodes[7].style.display = "none"//Versões
				list.childNodes[8].style.display = "none"//Apagar
			}
			else
				list.childNodes[1].style.display = "block"//Propriedades
		}

		if (results[2] == "") {
			if (this.ReadOnly == "N") {
				list.childNodes[5].style.display = "block"//Editar
				list.childNodes[8].style.display = "block"//Apagar
			}
			this.Hobj.childNodes[1].childNodes[0].style.color = "#666666"
		}
		else if (results[2] == "COMMIT") {
			if (this.ReadOnly == "N") {
				list.childNodes[6].style.display = "block"//Submeter
			}
			this.Hobj.childNodes[1].childNodes[0].style.color = "green"
		}
		else {
			this.Hobj.childNodes[1].childNodes[0].style.color = "red"
		}

		if (results[1] != null && results[1] != "") {
			var versions = results[1].split("[")
			var firstVersion = versions[versions.length - 1].split(":")
			this.ficheiro.key = firstVersion[1]

			if (versions.length > 1) {

				list.childNodes[7].style.display = "block"//Versões

				var listRemove = document.getElementById(this.Id + "-versionsl")

				if (listRemove != undefined)
					listRemove.parentNode.removeChild(listRemove);

				var color = "#A4D6F0"
				var borderbottomstyle = "solid"
				var borderwidth = "1px"
				var bordercolor = "black"
				var backgroundColor = "white"
				var font = "8pt"


				var wstyle = this.StyleObj
				if (wstyle != null) {
					if (wstyle.FCONTROL != undefined) {
						color = wstyle.FCONTROL.hoverColor;
						borderbottomstyle = wstyle.FCONTROL.borderStyle;
						borderwidth = wstyle.FCONTROL.borderWidth;
						bordercolor = wstyle.FCONTROL.borderColor;
						backgroundColor = wstyle.FCONTROL.backgroundColor;
						font = GetSizeNumber(wstyle.FCONTROL.fontSize) + "pt"
					}
				}

				var list2 = document.createElement("ul")
				list2.id = this.Id + "-versionsl"
				list2.style.display = "none"

				list2.style.borderStyle = borderbottomstyle
				list2.style.borderWidth = borderwidth
				list2.style.borderColor = bordercolor
				list2.style.backgroundColor = backgroundColor
				list2.style.fontSize = font
				//list2.onmouseover = elem7Hover
				list2.onmouseout = elem7HoverOut

				var l2Elem0 = document.createElement("li")
				l2Elem0.innerHTML = MsgSet[34]
				l2Elem0.style.borderBottomStyle = borderbottomstyle
				l2Elem0.style.borderBottomWidth = borderwidth
				l2Elem0.style.borderBottomColor = bordercolor
				l2Elem0.id = this.Id + "-VTod"
				l2Elem0.onmouseover = (function () { this.style.backgroundColor = color })
				l2Elem0.onmouseout = (function () { this.style.backgroundColor = "" })
				l2Elem0.onclick = elemClick
				list2.appendChild(l2Elem0)

				for (var i = versions.length - 1; i >= (versions.length > 5 ? versions.length - 5 : 0); i--) {
					var listEntry = versions[i].split(":")
					var l2Elem1 = document.createElement("li")
					l2Elem1.innerHTML = listEntry[0]
					l2Elem1.id = this.Id + "-AVers-" + listEntry[1]
					l2Elem1.onmouseover = (function () { this.style.backgroundColor = color })
					l2Elem1.onmouseout = (function () { this.style.backgroundColor = "" })
					l2Elem1.onclick = elemClick
					list2.appendChild(l2Elem1)
				}
				if (this.ReadOnly == "N") {
					if (results[2] == "") {
						var l2Elem1 = document.createElement("li")
						l2Elem1.innerHTML = MsgSet[35]
						l2Elem1.style.borderTopStyle = borderbottomstyle
						l2Elem1.style.borderTopWidth = borderwidth
						l2Elem1.style.borderTopColor = bordercolor
						l2Elem1.id = this.Id + "-DelU"
						l2Elem1.onmouseover = (function () { this.style.backgroundColor = color })
						l2Elem1.onmouseout = (function () { this.style.backgroundColor = "" })
						l2Elem1.onclick = elemClick
						list2.appendChild(l2Elem1)

						var l2Elem2 = document.createElement("li")
						l2Elem2.innerHTML = MsgSet[36]
						l2Elem2.id = this.Id + "-DelH"
						l2Elem2.onmouseover = (function () { this.style.backgroundColor = color })
						l2Elem2.onmouseout = (function () { this.style.backgroundColor = "" })
						l2Elem2.onclick = elemClick
						list2.appendChild(l2Elem2)
					}
				}

				list2.style.listStyleType = "none";
				list2.style.padding = "0px";
				list2.style.margin = "0px";
				list2.style.zIndez = "999";
				for (var i = 0; i < list2.childNodes.length; i++) {
					list2.childNodes[i].style.padding = "5px";
					list2.childNodes[i].style.width = "auto";
					list2.childNodes[i].style.textAlign = "left";
					list2.childNodes[i].style.zIndex = "999";
				}

				list.childNodes[7].appendChild(list2)
			}
		}
	}
}

Qfcontrol.prototype.Proper = function () {//Mostra a informação do ficheiro.

	var nome = MsgSet[37] + this.ficheiro.nome + "\n"
	var tamanho = MsgSet[38] + this.ficheiro.tamanho + "\n"
	var ext = MsgSet[39] + this.ficheiro.ext + "\n"
	var autor = MsgSet[40] + this.ficheiro.autor + "\n"
	var data = MsgSet[41] + this.ficheiro.data + "\n"
	var vers = MsgSet[42] + this.ficheiro.vers + "\n"
	var edicao = ""
	if (this.ficheiro.edicao != "")
		edicao = MsgSet[43] + this.ficheiro.edicao + "\n"

	alert(nome + tamanho + ext + autor + data + vers + edicao)
}

Qfcontrol.prototype.Abrir = function (iblk) {//Abre o ficheiro com recurso ao aspx. Passa para o historial o valor documName que é passado para o aspx.
	var widados=""
    for (var r=0; r<iblk.DADOS.length; r++) {
    	if (r>0) widados += "{"
    	for (var c=0; c<iblk.DADOS[r].length; c++) {
    		if (c>0) widados += "["
    		widados += iblk.DADOS[r][c]
    	}
    }
	if (iblk.STAT != "OK")
	{ alert(MsgSet[58]) }
	else {
		// iblk.Dados contem o ticket para obter o ficheiro, desencadear o download do ficheiro
		// api.DoDownload("obterRecurso.aspx?rec=" + widados);
		var wurl = CriarLinkRecurso("ticket:" + widados);
  		api.DoDownload(wurl);
		//ExecCmd(App.Apage.Id, "SetHistorial(rec," + widados + ",EQ")
		//ExecCmd(App.Apage.Id, "OpenDialog(QwRVIEW,ALT{ExecDelayed(ClosePage")
	}
}


Qfcontrol.prototype.Vers = function (iblk) {
	var widados=""
    for (var r=0; r<iblk.DADOS.length; r++) {
    	if (r>0) widados += "{"
    	for (var c=0; c<iblk.DADOS[r].length; c++) {
    		if (c>0) widados += "["
    		widados += iblk.DADOS[r][c]
    	}
    }
	if (iblk.STAT != "OK")
	{ alert(MsgSet[58]) }
	else {
		ExecCmd(App.Apage.Id, "SetHistorial(lastVersion," + widados + ",EQ")
		ExecCmd(App.Apage.Id, "OpenDialog(QwRSUBMIT,ALT")
	}
}
Qfcontrol.prototype.DelU = function (iblk) {
	if (iblk.STAT != "OK")
	{ alert(MsgSet[59]) }
	else {
		this.Opt = "Info"
		this.Send()
	}
}

Qfcontrol.prototype.DelH = function (iblk) {
	if (iblk.STAT != "OK")
	{ alert(MsgSet[60]) }
	else {
		this.Opt = "Info"
		this.Send()
	}
}

Qfcontrol.prototype.Edit = function (iblk) {
	if (iblk.STAT != "OK") {
		//   alert(iblk.MSG)
		this.Opt = "Info"
		this.Send()
	}
	else {
		this.Opt = "Abrir"
		this.Send()

		this.Opt = "Info"
		this.Send()
	}

}
Qfcontrol.prototype.Subm = function (iblk) {
	if (iblk.STAT != "OK")
	{ alert(MsgSet[61]) }
	else {
		this.Opt = "Info"
		this.Send()
	}
}
Qfcontrol.prototype.Remo = function (iblk) {
	if (iblk.STAT != "OK")
		alert(MsgSet[62])

	this.Opt = "Info"
	this.DatactlObj.StoreVal(this.Cols[1].Id, "");
	this.DatactlObj.StoreVal(this.Cols[2].Id, "");
	// RR 13-02-2012
	// isto antes estava com send, mas se o ficheiro foi apagado penso que não seja necessário fazer um novo Send, basta SetVal("")
	this.SetVal("")

}

Qfcontrol.prototype.Destroy = function (opt) {
	GenericDisplayCtl_Destroy.call(this, opt)
}

Qfcontrol.prototype.Destroy2 = function () {
	GenericDisplayCtl_Destroy2.call(this)
}

Qfcontrol.prototype.Resize = function () {
	GenericDisplayCtl_Resize.call(this)
	ResizeControl(this.Hobj, this.HostPanel.Panel.style.width, this.HostPanel.Panel.style.height, this.Left, this.Top, this.Width, this.Height, this.HostBorder)
}

Qfcontrol.prototype.Relocate = function () {  //FHC para reposicionar a lista
	var wdiv=this.Hobj;
	var offset=GetOffsetFor("APP", this.HostPanel);
	this.FcontrolList.Hobj.style.left = (GetSizeNumber(wdiv.style.left) + GetSizeNumber(wdiv.style.width) - 100 + offset.Left) + "px"
	this.FcontrolList.Hobj.style.top = (GetSizeNumber(wdiv.style.top) + GetSizeNumber(wdiv.style.height) + offset.Top + (BrowserIE ? 0 : 2)) + "px"
}


//******* Criar DIV html
function CreateDiv(wparent, wid, wx, wy, ww, wh) {
	var wdiv = document.createElement("DIV")
	wdiv.style.position="absolute"
	wdiv.style.overflow="hidden"
	wdiv.style.MozBoxSizing = "border-box"
	wdiv.style.WebkitBoxSizing = "border-box"
	wdiv.style.BoxSizing = "border-box"
	wdiv.style.boxSizing = "border-box"
	wdiv.style.outlineStyle="none"
	if (wid != "" && wid != undefined) wdiv.id=wid
	if (wparent != "" && wparent != undefined) wparent.appendChild(wdiv)
	if (wx != undefined) wdiv.style.left=wx + "px"
	if (wy != undefined) wdiv.style.top=wy + "px"
	if (ww != undefined) {
		if (("" + ww).indexOf("%") == -1) {
			wdiv.style.width=ww + "px"
		} else {
			wdiv.style.width=ww
		}
	}
	if (wh != undefined) {
		if (("" + wh).indexOf("%") == -1) {
			wdiv.style.height=wh + "px"
		} else {
			wdiv.style.height=wh
		}
	}
	return wdiv
}


//******* Criar IMG html
function CreateImg(wparent, wid, wx, wy, ww, wh) {
	var wdiv = document.createElement("IMG")
	wdiv.style.position="absolute"
	wdiv.style.MozBoxSizing = "border-box"
	wdiv.style.WebkitBoxSizing = "border-box"
	wdiv.style.BoxSizing = "border-box"
	wdiv.style.boxSizing = "border-box"
	if (wid != "" && wid != undefined) wdiv.id=wid
	if (wparent != "" && wparent != undefined) wparent.appendChild(wdiv)
	if (wx != undefined) wdiv.style.left=wx + "px"
	if (wy != undefined) wdiv.style.top=wy + "px"
	if (ww != undefined) {
		if (("" + ww).indexOf("%") == -1) {
			wdiv.style.width=ww + "px"
		} else {
			wdiv.style.width=ww
		}
	}
	if (wh != undefined) {
		if (("" + wh).indexOf("%") == -1) {
			wdiv.style.height=wh + "px"
		} else {
			wdiv.style.height=wh
		}
	}
	return wdiv
}

//******* Colocar em modo Unselectable nos varios browsers
function SetUnselectable(wdiv) {
	wdiv.style.MozUserSelect = "none"
	wdiv.style.webkitUserSelect = "none"
	wdiv.style.msUserSelect = "none"
	if (BrowserIE || BrowserOP) {
		wdiv.unselectable = "on"
		wdiv.onselectstart=ReturnFalse
	}
}

//******* Função que retorna falso para SetUnselectable
function ReturnFalse() {
	return false;
}


//******* Calcular offset de um cotrolo para o PANEL, PAGE, AREA ou APP acima   - retorna um Array com o Objecto acima, o painel do Objecto acima, o offsetLeft e offsetTop
function CtlOffset(parentobj, parentpanel, offleft, offtop, maxwidth, maxheight) {
	this.ParentObj=parentobj;
	this.ParentPanel=parentpanel;
	this.Left=offleft;
	this.Top=offtop;
	this.MaxWidth=maxwidth;
	this.MaxHeight=maxheight;
}

function GetOffsetFor(tipo, hostpanel) {
	var wx=0
	var wy=0
	if (tipo == "PAGE") {
		var wtarget=hostpanel.HostPage.PanelObj
		var wtargctl=hostpanel.HostPage
	}
	if (tipo == "APP" || tipo == "WINDOW") {
		var wtarget=App.PanelObj
		var wtargctl=App
	}
	var elem=hostpanel.Hobj
	while (elem.offsetParent) {
		if (elem == wtarget) break
		wx += (elem.offsetLeft - elem.scrollLeft)
		wy += (elem.offsetTop - elem.scrollTop)
		elem=elem.offsetParent
	}
	var maxw=wtargctl.Locsize.ObjW
	var maxh=wtargctl.Locsize.ObjH
	//var maxw=document.body.clientWidth - wx
	//var maxh=document.body.clientHeight - wy
	if (tipo == "WINDOW") {
		wx=wx+App.Locsize.ObjL
		wy=wy+App.Locsize.ObjT
	}
	var r=new CtlOffset(wtargctl, wtarget, wx, wy, maxw, maxh)
	return r
}


//******* devolver valor numérico mesmo que tenha px
function GetSizeNumber(val) {
	var rval=0
	var wval="" + val
	var ix=wval.indexOf("px")
	if (ix > -1) {
		rval=Number(wval.substr(0,ix))
	} else {
		ix=wval.indexOf("pt")
		if (ix > -1) {
			rval=Number(wval.substr(0,ix))
		} else {
			rval=Number(wval)
			if (isNaN(rval)) rval=0
		}
	}
	return rval
}


//*********************************************
//*********************************************
//*   Tratamento de Eventos
//*********************************************
//*********************************************


function EvtFocus(evt) {
	var ctl
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
	} else {
		id=evt.target.id
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		ctl.OnFocus()
	}
}

function EvtBlur(evt) {
	var ctl
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
	} else {
		id=evt.target.id
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		ctl.OnBlur(id)
	}
}

function EvtKeyUp(evt) {
	var ctl
	var wkey
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
		wkey=window.event.keyCode
	} else {
		id=evt.target.id
		wkey=evt.keyCode
		if (wkey == 0) wkey=evt.charCode
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnKeyUp(wkey, evt)
}

function EvtKeyDown(evt) {
	var ctl
	var wkey
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
		wkey=window.event.keyCode
	} else {
		id=evt.target.id
		wkey=evt.keyCode
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnKeyDown(wkey, evt)
}

function EvtKeyPress(evt) {
	var ctl
	var wkey
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
		wkey=window.event.keyCode
	} else {
		id=evt.target.id
		wkey=evt.keyCode
		if (wkey == 0) wkey=evt.charCode
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnKeyPress) {
			ctl.OnKeyPress(wkey, evt)
		}
	}
}

function EvtMouseOver(evt) {
	var ctl
	var hnod
	var id
	var wx
	var wy
	if (BrowserIE || BrowserOP) {
		hnod = window.event.srcElement
		if (hnod == null) return
		id=window.event.srcElement.id
		wx=window.event.offsetX
		wy=window.event.offsetY
	} else {
		hnod = evt.target
		id=evt.target.id
		var offx=0
		var offy=0
		var elem=hnod
		while (elem.offsetParent) {
			offx += elem.offsetLeft
			offy += elem.offsetTop
			elem=elem.offsetParent
		}
		wx=evt.pageX - offx
		wy=evt.pageY - offy
	}
	var Aw=id.split(".")
	var aid=Aw[0]
	if (MouseAreaId != aid) {
		var warea=GetCtlByHid(MouseAreaId)
		MouseAreaId=aid
		if (warea != null) warea.OnMouseOut()
		var warea=GetCtlByHid(MouseAreaId)
		if (warea != null) warea.OnMouseOver()
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnMouseOver != undefined) ctl.OnMouseOver(id, hnod, wx, wy)
	}
}

function EvtMouseOut(evt) {
	var ctl
	var hnod
	var id
	var destino=null
	if (BrowserIE || BrowserOP) {
		hnod = window.event.srcElement
		if (hnod == null) return
		id=window.event.srcElement.id
		//window.event.cancelBubble=true
		destino = window.event.toElement
	} else {
		hnod = evt.target
		id=evt.target.id
		//evt.stopPropagation()
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnMouseOut != undefined) ctl.OnMouseOut(id, hnod)
	}
}

function EvtMouseDown(evt) {
	var ctl
	var hnod
	var id
	var wx
	var wy
	var cx
	var cy
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		if (BrowserOP && window.event.button != 0) return   //(se não for o botão esq.)
		if (BrowserIE && window.event.button != 1) return   //(se não for o botão esq.)
		hnod = window.event.srcElement
		id=window.event.srcElement.id
		wx=window.event.offsetX
		wy=window.event.offsetY
		cx=window.event.clientX
		cy=window.event.clientY
	} else {
		evt.stopPropagation()
		if (evt.button != 0) return   //(se não for o botão esq.)
		hnod = evt.target
		id=evt.target.id
		var offx=0
		var offy=0
		var elem=hnod
		while (elem.offsetParent) {
			offx += elem.offsetLeft
			offy += elem.offsetTop
			elem=elem.offsetParent
		}
		wx=evt.pageX - offx
		wy=evt.pageY - offy
		cx=evt.clientX
		cy=evt.clientY
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.Area != null && ctl.Area != undefined) {
			var warea=ctl.Area
		} else {
			var warea=ctl.HostPage.Area
		}
		if (warea.Tipo == "WINDOW") warea.GotFocus()
		if (ctl.OnMouseDown != undefined) ctl.OnMouseDown(id, hnod, wx, wy, cx, cy)
	}
}

function EvtMouseUp(evt) {
	var ctl
	var hnod
	var id
	if (BrowserIE || BrowserOP) {
		//window.event.cancelBubble=true
		hnod = window.event.srcElement
		id=window.event.srcElement.id
	} else {
		//evt.stopPropagation()
		hnod = evt.target
		id=evt.target.id
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnMouseUp) ctl.OnMouseUp(id, hnod)
	}
}

function EvtMouseMove(evt) {
	var ctl
	var hnod
	var id
	var wx
	var wy
	var cx
	var cy
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		hnod = window.event.srcElement
		id=window.event.srcElement.id
		wx=window.event.offsetX
		wy=window.event.offsetY
		cx=window.event.clientX
		cy=window.event.clientY
	} else {
		evt.stopPropagation()
		hnod = evt.target
		id=evt.target.id
		var offx=0
		var offy=0
		var elem=hnod
		while (elem.offsetParent) {
			offx += elem.offsetLeft - elem.scrollLeft
			offy += elem.offsetTop - elem.scrollTop
			elem=elem.offsetParent
		}
		wx=evt.pageX - offx
		wy=evt.pageY - offy
		cx=evt.clientX
		cy=evt.clientY
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnMouseMove) ctl.OnMouseMove(id, hnod, wx, wy, cx, cy)
	}
}

function EvtResize(evt) {
	var ctl
	var hnod
	var id
	if (BrowserIE || BrowserOP) {
		hnod = window.event.srcElement
		id = window.event.srcElement.id
	} else {
		hnod = evt.target
		id = evt.target.id
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnResize(id, hnod, keys)
}

function EvtClick(evt) {
	var ctl
	var hnod
	var id
	var keys = ""
	var wx
	var wy
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		hnod = window.event.srcElement
		id = window.event.srcElement.id
		if (window.event.altKey == true) keys += "ALT"
		if (window.event.ctrlKey == true) keys += "CTRL"
		if (window.event.shiftKey == true) keys += "SHIFT"
		wx=window.event.clientX
		wy=window.event.clientY
	} else {
		evt.stopPropagation()
		hnod = evt.target
		id = evt.target.id
		if (evt.altKey == true) keys += "ALT"
		if (evt.ctrlKey == true) keys += "CTRL"
		if (evt.shiftKey == true) keys += "SHIFT"
		wx=evt.clientX
		wy=evt.clientY
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnClick) {
			ctl.OnClick(id, hnod, keys, wx, wy)
		}
	}
}

function EvtDblClick(evt) {
	var ctl
	var hnod
	var id
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		hnod = window.event.srcElement
		id=window.event.srcElement.id
	} else {
		evt.stopPropagation()
		hnod = evt.target
		id=evt.target.id
	}
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnDblClick) {
			ctl.OnDblClick(id, hnod)
		} else {
			ctl.HostPanel.OnDblClick(id, hnod)
		}
	}
}

function EvtContext(evt) {
	var ctl
	var hnod
	var id
	var wx
	var wy
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		window.event.returnValue=false
		hnod = window.event.srcElement
		id=window.event.srcElement.id
		wx=window.event.clientX
		wy=window.event.clientY
	} else {
		evt.stopPropagation()
		evt.preventDefault()
		hnod = evt.target
		id=evt.target.id
		wx=evt.clientX
		wy=evt.clientY
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnContext) ctl.OnContext(id, hnod, wx, wy)
	}
}

function EvtScroll(evt) {
	var ctl
	var hnod
	var id
	if (BrowserIE || BrowserOP) {
		hnod = window.event.srcElement
		id=window.event.srcElement.id
	} else {
		hnod = evt.target
		id=evt.target.id
	}
 	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnScroll(id, hnod)
}


function EvtPaste(evt) {
	var ctl
	var hnod
	var id
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		hnod = window.event.srcElement
		id=window.event.srcElement.id
		var wevt=window.event
	} else {
		evt.stopPropagation()
		hnod = evt.target
		id=evt.target.id
		var wevt=evt
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnPaste(wevt)
	if (ctl.NoPaste == "S") {
	    if (BrowserIE || BrowserOP) {
	        event.returnValue = false
	    } else {
	        evt.preventDefault()
	    }
	    return
	}
}

function EvtOk(evt) {
	var ctl
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
	} else {
		id=evt.target.id
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnOk()
}

function EvtCancel(evt) {
	var ctl
	var id
	if (BrowserIE || BrowserOP) {
		id=window.event.srcElement.id
	} else {
		id=evt.target.id
	}
	ctl=GetCtlByHid(id)
	if (ctl != null) ctl.OnCancel()
}

function EvtMouseWheel(evt) {
	var ctl
	var hnod
	var id
	var delta=0
	if (BrowserIE || BrowserOP) {
		window.event.cancelBubble=true
		hnod = window.event.srcElement
		id=window.event.srcElement.id
		if (window.event.wheelDelta) {
			delta=window.event.wheelDelta/120
		}
		if (window.event.detail) {
			delta=-window.event.detail/3
		}
	} else {
		evt.stopPropagation()
		hnod = evt.target
		id=evt.target.id
		if (evt.wheelDelta) {
			delta=evt.wheelDelta/120
		}
		if (evt.detail) {
			delta=-evt.detail/3
		}
	}
	if (delta == 0) return
	if (id == "") return
	ctl=GetCtlByHid(id)
	if (ctl != null) {
		if (ctl.OnMouseWheel) {
			ctl.OnMouseWheel(id, hnod, delta)
		} else {
			ctl.HostPanel.OnMouseWheel(id, hnod, delta)
		}
	}
}