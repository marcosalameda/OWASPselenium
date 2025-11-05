//*************** Web Player para Aplicações Quidgest *****************
//**                           Modulo Base                           **
//**                                                                 **
//**                           versão 3.00                           **
//*********************************************************************

var BrowserIE=false;
var BrowserIE10=false;
var BrowserMOZ=false;
var BrowserOP=false;
var BrowserWKIT=false;
var BrowserName = navigator.appName.toUpperCase();
var DeviceMobile=false;
var DeviceType="";
if (BrowserName.indexOf("INTERNET EXPLORER") > -1) {
	BrowserIE=true;
} else {
	if (BrowserName.indexOf("NETSCAPE") > -1) {
		BrowserMOZ=true;
	} else {
		if (BrowserName.indexOf("OPERA") > -1) {
			BrowserOP=true;
		} else {
			BrowserIE=true;
		}
	}
}
var Uagent=navigator.userAgent.toLowerCase();
if (Uagent.indexOf("msie 10") > -1) BrowserIE10=true;
if (Uagent.indexOf("windows phone") > -1) DeviceMobile=true;
if (Uagent.indexOf("webkit") > -1) BrowserWKIT=true;
if (Uagent.indexOf("iphone") > -1 || Uagent.indexOf("ipod") > -1) {
	DeviceMobile=true;
	DeviceType="iphone";
}
if (Uagent.indexOf("symbian") > -1 || Uagent.indexOf("series60") > -1) {
	DeviceMobile=true;
	DeviceType="symbian";
}
if (Uagent.indexOf("android") > -1) {
	DeviceMobile=true;
	DeviceType="android";
}
if (Uagent.indexOf("opera mobi") > -1) {
	DeviceMobile=true;
}
if (Uagent.indexOf("windows ce") > -1 || Uagent.indexOf("windows mobile") > -1) {
	DeviceMobile=true;
	DeviceType="winmobile";
}
if (Uagent.indexOf("blackberry") > -1) {
	DeviceMobile=true;
	DeviceType="blackberry";
}
if (Uagent.indexOf("palm") > -1) {
	DeviceMobile=true;
	DeviceType="palm";
}
var TouchSupport=TestEvent("ontouchstart")   //Indica se o browser suporta eventos de Touch
var InternalScrollBars=false   //Se true o qweb deve colocar scrollbars proprias
if (TouchSupport == true) InternalScrollBars=true



var App=null;
var User=new Quser();
var Aorig=null;
var RowOrig="";
var Xcond=null;
var CtlMouse=null;
var CtlMouseOver=new Array();
var MouseAreaId="";
var ErrHtml="";
var FileMode=false;
if (("" + window.location).substr(0,4) == "file") FileMode=true;
var PrintContent=null;
var api = new Qweb_api();
var MsgLog=new Array();
var RotStatus="";
var RotMsgId="";
var RotMsg="";
var RotResult="";
var ImgLib=new QimgLib();
var InterfaceId="QWEB";
var BaseAddr=window.location.href;
if (FileMode == true) {
	BaseAddr=BaseAddr.substr(8);
}
var ix=BaseAddr.lastIndexOf("/");
if (ix != BaseAddr.length-1) BaseAddr=BaseAddr.substr(0, ix+1);
var TimeLoad=Agora().getTime()
/*
try {InterfaceId=window.external.GetInterfaceId()}
catch(exp) {}
try {window.external.SetUrl(BaseAddr)}
catch(exp) {}
*/
var ComUnits=new Array();
var ComStatus="IDDLE";
var AllInputBlocked=false;
var FocusCtl=null


//======================================================================================= Testar se o browser suporta determinado evento
function TestEvent(wevent) {
	var testdiv=document.createElement("div");
	var isSupported = (wevent in testdiv);
	if (!isSupported) {
		testdiv.setAttribute(wevent, "return;");
		isSupported = typeof testdiv[wevent] == 'function';
	}
	testdiv=null
	return isSupported;
}

//======================================================================================= Eventos Gerais

window.onresize=function() {
	if (App != null && App != undefined) App.Resize();
}

window.onunload=function() {
	for (var i=0; i<App.Areas.length; i++) {
		CloseAllPages(App.Areas[i], "FORCE");
	}
}

document.onmousemove=DocMouseMove;
document.onmouseup=DocMouseUp;
document.onkeydown=DocKeyDown;
document.oncontextmenu=DocRClick;


function DocMouseMove(evt) {
	if (CtlMouse == null && CtlMouseOver.length == 0) return;
	var wx;
	var wy;
	if (BrowserIE || BrowserOP) {
		wx=window.event.clientX;
		wy=window.event.clientY;
	} else {
		wx=evt.clientX;
		wy=evt.clientY;
	}
	if (CtlMouse != null) {  //usado para mover windows ou dialogs
		CtlMouse.MouseMove(wx, wy);
		return
	}
	for (var i=0; i<CtlMouseOver.length; i++) {   //usado para Multigrids (stackpanel) com POINTERSCROLL="S"
		if (wx >= CtlMouseOver[i].MouseOverxi && wy >= CtlMouseOver[i].MouseOveryi && wx <= CtlMouseOver[i].MouseOverxf && wy <= CtlMouseOver[i].MouseOveryf) {
			CtlMouseOver[i].MouseOver(wx, wy);
		} else {
			CtlMouseOver[i].MouseOut();
		}
	}
}

function DocMouseUp(evt) {
	if (CtlMouse == null) return;
	CtlMouse.MouseUp();
	CtlMouse=null;
}

function DocKeyDown(evt) {
	if (BrowserIE || BrowserOP) {
		if (window.event.altKey == true && window.event.ctrlKey == true && window.event.shiftKey == true) OpenDebugWindow("G");
		if (window.event.ctrlKey == true && window.event.keyCode == 77) OpenDebugWindow("M");
		if (window.event.altKey == true && window.event.ctrlKey == true && window.event.keyCode == 83) OpenStyleWindow();
	} else {
		if (evt.altKey == true && evt.ctrlKey == true && evt.shiftKey == true) OpenDebugWindow("G");
		if (evt.ctrlKey == true && evt.keyCode == 77) OpenDebugWindow("M");
		if (evt.altKey == true && evt.ctrlKey == true && evt.keyCode == 83) OpenStyleWindow();
	}
}

function OpenDebugWindow(tipo) {
	if (tipo == "G") wdebug=window.open("debugger.htm","QwebDebug","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, width=500, height=650, resizable=yes");
	if (tipo == "M") wdebugmsg=window.open("debugmsg.htm","QwebDebugmsg","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, width=500, height=650");
}

function OpenStyleWindow() {
	if (DevelopModule != true) return;
	OpenWindow(App.Areas[0], "QwDstyleList", "ALT", "", "", "", "SYS", "CAPTION=S|LOCATION=C,20|SIZE=800,600|MINSIZE=800,60|ALLOWRESIZE=N");
}

function DocRClick(evt) {
	var wx;
	var wy;
	var AltKey=false;
	if (BrowserIE) {
		window.event.returnValue=false;
		wx=window.event.clientX;
		wy=window.event.clientY;
		if (window.event.altKey == true) AltKey=true;
	} else {
		evt.preventDefault();
		wx=evt.clientX;
		wy=evt.clientY;
		if (evt.altKey == true) AltKey=true;
	}
	if (wx < 10 && wy < 10) {
		if (AltKey == true) {
			OpenDebugWindow("G");
		} else {
			OpenDebugWindow("M");
		}	
	}
}



//======================================================================================= Navegação por url/hash
function HashEvent() {
	if (App.OldHash != GetCurrentHash()) {
		App.HashChanged()
		return
	}
}

function HashIframeLoaded(url) {
	if (App.HashIgnoreIframe == true) {
		App.HashIgnoreIframe=false
		return
	}
	var hash=String(url.search)
	if (hash.length == 1 && hash.charAt(0) == "?") {
		hash = "";
	} else {
		if (hash.length >= 2 && hash.charAt(0) == "?") {
			hash = hash.substring(1);
			//hash=api.Base64YDecode(hash)   // u encodeURIComponent(hash)
		}
	}
	window.location.hash=hash
	if (App.OldHash != hash) App.HashChanged("IFRAME")
}

function GetCurrentHash() {
	var r = window.location.href;
	var i = r.indexOf("#");
	if (i > 0) {
		return api.Base64YDecode(r.substr(i+1));
	} else {
		return "";
	}
}


//======================================================================================= Funções Gerais

//******* Executar Acções
function ExecCmd(area, acts) {
	if (acts.substr(0,1) == ";") {
		api.SetAreaInternal(area);
		try {eval(acts)}
		catch(exp) {window.alert(GetMsg(1, "Erro na execução de comando javascript (" + acts + ") - " + exp.message))}	
		return;
	}
	var AreaOrig=GetExecAorig(area);
	if (AreaOrig == null) {
		window.alert(GetMsg(1, "A Area especificada no ExecCmd (" + area + ") é invalida. (ExecCmd(" + area + ", " + acts + ")"));
		AreaOrig=App.Areas[0];
	}
	
	var Aliterals = new Array();
	var wacts=SubstLiterals(acts, Aliterals);
	var Aacts=wacts.split("{");
	for (var i=0; i<Aacts.length; i++) {
		var act=Aacts[i];
		act=SubstVars(AreaOrig, act);
		act=SubstLiterals(act, Aliterals);
		var ix=act.indexOf("(");
		if (ix > -1) {
			var cmd=act.substr(0, ix);
			var parms=act.substr(ix+1);
		} else {
			var cmd=act;
			var parms="";
		}
		var parmsp=parms+",,,,,,,";
		var Aparms=parmsp.split(",");
		for (var p=0; p<Aparms.length; p++) {
			Aparms[p]=RepLiterals(Aparms[p], Aliterals);
		}
		switch (cmd) {  //comandos abreviados para uso no URL
			case "SA":
				cmd="SetArea"
				break
			case "CAP":
				cmd="CloseAllPages"
				break
			case "OP":
				cmd="OpenPage"
				break
			case "OFP":
				cmd="OpenFirstPage"
				break
			case "OW":
				cmd="OpenWindow"
				break
			case "SH":
				cmd="SetHistorial"
				break
		}
		switch (cmd) {
			case "SetArea":
				var r=api.SetArea(Aparms[0]);
				if (r == "") AreaOrig=Aorig;
				break
			case "OpenApp":
				api.OpenApp(AreaOrig, Aparms[0]);
				break;
			case "OpenPage":
				api.OpenPage(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5]);
				break;
			case "OpenDialog":
				api.OpenDialog(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4]);
				break;
			case "OpenPopupDialog":
				api.OpenPopupDialog(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4]);
				break;
			case "OpenFirstPage":
				api.OpenFirstPage(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5]);
				break;
			case "OFP":   //Igual ao OpenFirstPage para usar em URLs
				api.OpenFirstPage(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5]);
				break;
			case "OpenBackPage":
				api.OpenBackPage(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5]);
				break;
			case "OpenWindow":
				api.OpenWindow(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5], Aparms[6]);
				break;
			case "OpenBrowserWindow":
				api.OpenBrowserWindow(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4]);
				break;
			case "ClosePage":
				api.ClosePage(AreaOrig, Aparms[0]);
				break;
			case "ClosePageReturn":
				api.ClosePageReturn(AreaOrig, Aparms[0]);
				break;
				/*
			case "ReloadPage":
				var wpage=AreaOrig.ActivePage;
				ReloadPage(wpage);
				break;
				*/
			case "ClosePageDelayed":
				api.ClosePageDelayed(AreaOrig, Aparms[0]);
				break;
			case "CloseAllPages":
				api.CloseAllPages(AreaOrig, Aparms[0]);
				break
			case "CloseAllPagesX":
				var r=api.CloseAllPages(AreaOrig, Aparms[0]);
				if (r == false) {
					var n=Aacts.length - i - 1;
					if (n > 0) Aacts.splice(i+1, n);
					window.alert(GetMsg(24))
				}
				break
			case "CloseWindow":
				api.CloseWindow(AreaOrig);
				break;
			case "MinimizeWindow":
				api.MinimizeWindow(AreaOrig);
				break;
			case "RestoreWindow":
				api.RestoreWindow(AreaOrig);
				break;
			case "Execute":
				api.Execute(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
				break;
			case "ExecuteInternal":  //igual ao Execute mas não faz log na api
				api.ExecuteInternal(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
				break;
			case "ReturnVal":
				api.ReturnVal(AreaOrig, Aparms[0]);
				break;
			case "Disable":
				api.Disable(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "Enable":
				api.Enable(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "Hide":
				api.Hide(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "Show":
				api.Show(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "SetError":
				api.SetError(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "External":
				api.External(AreaOrig, parms);
				break;
			case "Resize":
				api.Resize(AreaOrig, Aparms[0], Aparms[1], Aparms[2]);
				break;
			case "Relocate":
				api.Relocate(AreaOrig, Aparms[0], Aparms[1], Aparms[2]);
				break;
			case "Animate":
				api.Animate(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "SetUsrNivel":
				api.SetUsrNivel(parms);
				break;
			case "SetUsrPerm":
				api.SetUsrPerm(parms);
				break;
			case "SetUsrAno":
				api.SetUsrAno(parms);
				break;
			case "SetUsrId":
				api.SetUsrId(Aparms[0], Aparms[1]);
				break;
			case "SetUsrStatus":
				api.SetUsrStatus(Aparms[0]);
				break;
			case "SetDb":
				api.SetDb(Aparms[0], Aparms[1]);
				break;
			case "SetVal":
				api.SetVal(AreaOrig, Aparms[0], Aparms[1], Aparms[2]);
				break;
			case "SetList":
				api.SetList(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "ExecRotina":
				api.ExecRotina(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
				break;
			case "ExecRotinaAsync":
				var wcallback="";
				for (var j=i+1; j<Aacts.length; j++) {  //criar uma string com os comandos seguintes para serem executados depois da rotina completar
					var wact=Aacts[j];
					wact=SubstVars(AreaOrig, wact);
					wact=SubstLiterals(wact, Aliterals);
					if (wcallback != "") wcallback += "{";
					wcallback += wact;
				}
				var lixo=Aacts.splice(i+1, 9999) //remover da queue todos os comandos seguintes
				if (wcallback != "") wcallback = "ExecCmd('" + AreaOrig.Id + "', '" + wcallback + "')";
				api.ExecRotinaAsync(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], wcallback);
				break;
			case "SetHistorial":
				qApi.SetHistorial(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
				break;
			case "SetPerm":
				api.SetPerm(AreaOrig, Aparms[0]);
				break;
			case "Display":
				api.Display(Aparms[0]);
				break;
			case "PrintPage":
				api.PrintPage(AreaOrig);
				break;
			case "UpdateCtls":
				api.UpdateCtls(AreaOrig);
				break;
			case "SetPageUpdated":
				api.SetPageUpdated(AreaOrig);
				break;
			case "SetCond":  //SetCond(id_dbedit,col;=;valor|col;gt;valor
				api.SetCond(AreaOrig, Aparms[0], Aparms[1], Aparms[2]);
				break;
			case "Case":  //Case(arg1a,op1,arg1b,arg2a,op2,arg2b
				var wresult=false;
				switch (Aparms[1]) {
					case "EQ":
						if (Aparms[0] == Aparms[2]) wresult=true;
						break;
					case "GT":
						if (Aparms[0] > Aparms[2]) wresult=true;
						break;
					case "GE":
						if (Aparms[0] >= Aparms[2]) wresult=true;
						break;
					case "LT":
						if (Aparms[0] < Aparms[2]) wresult=true;
						break;
					case "LE":
						if (Aparms[0] <= Aparms[2]) wresult=true;
						break;
					case "NE":
						if (Aparms[0] != Aparms[2]) wresult=true;
						break;
				}
				var wresult2=true
				if (Aparms[3] != "") {
					var wresult2=false;
					switch (Aparms[4]) {
						case "EQ":
							if (Aparms[3] == Aparms[5]) wresult2=true;
							break;
						case "GT":
							if (Aparms[3] > Aparms[5]) wresult2=true;
							break;
						case "GE":
							if (Aparms[3] >= Aparms[5]) wresult2=true;
							break;
						case "LT":
							if (Aparms[3] < Aparms[5]) wresult2=true;
							break;
						case "LE":
							if (Aparms[3] <= Aparms[5]) wresult2=true;
							break;
						case "NE":
							if (Aparms[3] != Aparms[5]) wresult2=true;
							break;
					}
				}
				if (wresult == false || wresult2 == false) {
					if (i+1 < Aacts.length) Aacts.splice(i+1,1);
				}
				break;
			case "Casex":  //Case(arg1a,op1,arg1b,arg2a,op2,arg2b
				var wresult=false;
				switch (Aparms[1]) {
					case "EQ":
						if (Aparms[0] == Aparms[2]) wresult=true;
						break;
					case "GT":
						if (Aparms[0] > Aparms[2]) wresult=true;
						break;
					case "GE":
						if (Aparms[0] >= Aparms[2]) wresult=true;
						break;
					case "LT":
						if (Aparms[0] < Aparms[2]) wresult=true;
						break;
					case "LE":
						if (Aparms[0] <= Aparms[2]) wresult=true;
						break;
					case "NE":
						if (Aparms[0] != Aparms[2]) wresult=true;
						break;
				}
				var wresult2=true;
				if (Aparms[3] != "") {
					var wresult2=false;
					switch (Aparms[4]) {
						case "EQ":
							if (Aparms[3] == Aparms[5]) wresult2=true;
							break;
						case "GT":
							if (Aparms[3] > Aparms[5]) wresult2=true;
							break;
						case "GE":
							if (Aparms[3] >= Aparms[5]) wresult2=true;
							break;
						case "LT":
							if (Aparms[3] < Aparms[5]) wresult2=true;
							break;
						case "LE":
							if (Aparms[3] <= Aparms[5]) wresult2=true;
							break;
						case "NE":
							if (Aparms[3] != Aparms[5]) wresult2=true;
							break;
					}
				}
				if (wresult == false || wresult2 == false) {
					if (i+1 < Aacts.length) Aacts.splice(i+1,1);
				} else {
					if (i+2 < Aacts.length) Aacts.splice(i+2, Aacts.length - i - 2);
				}
				break;
			case "ExecDelayed":
				api.ExecDelayed(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
				break;
            case "ExecDelayed200":
                api.ExecDelayed200(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3]);
                break;
			case "Refresh":
				api.Refresh(AreaOrig, Aparms[0], Aparms[1]);
				break;
			case "SetLanguage":
				api.SetLanguage(Aparms[0]);
				break;
			case "CaseAreaClosed":   //CaseAreaClosed(area_id,msg
				var ctl=App.GetArea(Aparms[0]);
				var wresult=false;
				if (ctl == null) {
					window.alert(GetMsg(1, "O comando CaseAreaClosed referencia uma Area inexistente"));
				} else {
					if (ctl.ActivePage == null) {
						wresult=true;
					} else {
						alert(Aparms[1]);
					}
				}
				if (wresult == false) {
					var n=Aacts.length - i - 1;
					if (n > 0) Aacts.splice(i+1, n);
				}
				break;
			case "ExecInterface":
				api.ExecInterface(AreaOrig, Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5], Aparms[6], Aparms[7], Aparms[8]);
				break;
			case "RecCopy":
				api.RecCopy(AreaOrig, Aparms[0], Aparms[1], Aparms[2])
				break;
			case "RecMove":
				api.RecCopy(AreaOrig, Aparms[0], Aparms[1], Aparms[2])
				break;
			case "RecDelete":
				api.RecDelete(AreaOrig, Aparms[0], Aparms[1])
				break;
			case "SetFocus":
				api.SetFocus(AreaOrig, Aparms[0])
				break;
			case "DoLogon":
				api.DoLogon(Aparms[0], Aparms[1], Aparms[2], Aparms[3], Aparms[4], Aparms[5])
				break;
			case "DoLogoff":
				api.DoLogoff(Aparms[0])
				break;
			case "LoadCssFile":
				api.LoadCssFile(Aparms[0])
				break;
			case "UnloadCssFile":
				api.UnloadCssFile(Aparms[0])
				break;
			case "SetModulo":
				api.SetModulo(AreaOrig, Aparms[0]);
				break;
			case "ShowWaitSign":
				api.ShowWaitSign(AreaOrig);
				break;
			case "HideWaitSign":
				api.HideWaitSign(AreaOrig);
				break;
		}
	}
	if (acts == "") App.UnBlockAllInput()
}


//******* Substituir expressões incluidas num comando pelo seu valor
function SubstVars(AreaOrig, act) {
	var wact=act;
	var i=wact.indexOf("[");
	while (i > -1) {
		var j=wact.indexOf("]",i);
		var wexp=wact.substr(i+1, j-i-1);
		var wact1=wact.substr(0, i);
		var wact2=wact.substr(j+1);
		var Aw=wexp.split("(");
		var cmd=Aw[0];
		var tparms=Aw[1] + ",,,,,";
		var parms=tparms.split(",");
		var wvalor=null;
		switch (cmd) {
			case "GetVal":
				var ctl=AreaOrig.ActivePage.GetCtl(parms[0]);
				if (ctl != undefined) {
					wvalor=ctl.GetVal(parms[1], parms[2]);
				}
				break;
			case "GetHist":
				var op=parms[1];
				if (op == "" || op == undefined) op="EQ";
				var ix=GetHistorialIndex(AreaOrig, parms[0], op);
				if (ix > -1) {
					wvalor=AreaOrig.Historial[ix].Valor;
				} else {
					wvalor="";
				}
				break;
			case "GetDate":
				var dtparm=parms[0];
				var dtref=parms[1];
				var wvalor=SubstData(dtparm, dtref, false);
				break;
			case "GetSrvDate":
				var dtparm=parms[0];
				var dtref="";
				var wvalor=SubstData(dtparm, dtref, true);
				break;
			case "GetSrvTimeDif":
				var wvalor=App.ServerTimeDif;
				break;
			case "GetNivel":
				var modulo=parms[0];
				if (modulo == "") modulo=AreaOrig.Modulo;
				wvalor=User.GetNivel(modulo);
				break;
			case "SelLang":
				wvalor=SelLangTxt(parms[0]);
				break;
			case "GetUsr":
				var tipo=parms[0];
				if (parms[0] == "Name") wvalor=User.UserName;
				wvalor=User.UserId;
				break;
			case "GetRowSufix":
				var ctl=AreaOrig.ActivePage.GetCtl(parms[0]);
				if (ctl != undefined) {
					wvalor=ctl.GetCurrentRowSufix();
				}
				break;
			case "GetPageFunc":
				wvalor=AreaOrig.ActivePage.Func;
				break;
			case "GetRotResult":
				var ctl=AreaOrig.ActivePage.GetCtl(parms[0]);
				if (ctl == null) {
					window.alert(GetMsg(1, "Função (GetRotResult) - Nome da Rotina (" + parms[0] + ") invalido"));
					wvalor="";
					break;
				}
				ctl.Execute(parms[1], parms[2], parms[3]);
				wvalor=RotResult;
				break;
			case "GetUrl":
				wvalor=api.GetUrl();
				break;
		}
		if (wvalor == null) {
			window.alert(GetMsg(1, "Erro na avaliação da expressão - " + wexp));
			return "";
		} else {
			wact1=wact1 + wvalor;
		}
		wact=wact1+wact2;
		i=wact.indexOf("[");
	}
	return wact;
}

function GetExecAorig(area, func) {
	var warea=null;
	if (area == "" || area == undefined) {
		if (Aorig == null) Aorig=App.Areas[0];
		warea=Aorig;
	} else {
		if (area.Id == undefined) {
			var warea = App.GetArea(area);
		} else {
			warea=area;
		}
	}
	if (warea == null) {
		window.alert(GetMsg(1, "A Area especificada no comando - api." + func + "(" + area + ",....) é invalida."));
		warea=App.Areas[0];
		return warea;
	}
	Aorig=warea;
	return warea;
}

function SubstVarsExt(AreaOrig, act) {
	var Aliterals=new Array();
	var wact=SubstLiterals(act, Aliterals);
	wact=SubstVars(AreaOrig, wact);
	wact=RepLiterals(wact, Aliterals);
	return wact;
}

function RepLiterals(act, aliterals) {
	var ix=act.indexOf("#lit#");
	while (ix > -1) {
		var ix2=act.indexOf("#", ix+5);
		var litix=Number(act.substr(ix+5, ix2-ix-5));
		act=act.substr(0,ix) + aliterals[litix] + act.substr(ix2+1);
		ix=act.indexOf("#lit#");
	}
	return act;
}

function SubstLiterals(acts, aliterals) {
	var wacts=acts;
	var re=/««/g;
	wacts=wacts.replace(re,"#aspadupla1#");
	var re=/»»/g;
	wacts=wacts.replace(re,"#aspadupla2#");
	var j=wacts.indexOf("«");
	while (j > -1) {
		var k=wacts.indexOf("»",j+1);
		if (k == -1) {
			window.alert(GetMsg(1, "« » ímpares no comando: " + acts));
			k=wacts.length-1;
		}
		aliterals.push(wacts.substr(j+1, k-j-1));
		wacts=wacts.substr(0,j) + "#lit#" + (aliterals.length - 1) + "#" + wacts.substr(k+1);
		j=wacts.indexOf("\"");
	}
	var re=/#aspadupla1#/g;
	wacts=wacts.replace(re,"«");
	var re=/#aspadupla2#/g;
	wacts=wacts.replace(re,"»");
	return wacts;
}


//******* Abrir Aplicação
function OpenApp(AreaOrig, url) {
	if (App != null) CloseApp();
	var xroot=GetXmlData(url, "", false, "RANDOM");
	if (xroot == null) return;
	xroot=xroot.documentElement;
	App=new Qapp(xroot);
	App.Start();
}

//******* Fechar Aplicação
function CloseApp() {
	App.Destroy();
	App=null;
	User=new Quser();
}



//******* Abrir Pagina
function OpenPage(AreaOrig, url, func, key, cond, area, modulo) {
	if (area != "" && area != undefined) {
		var AreaDest=App.GetArea(area);
	} else {
		var AreaDest=App.GetArea(AreaOrig.Target);
	}
	if (AreaDest == null) AreaDest=AreaOrig;
	if (AreaDest.Disabled == true) return;
	if (modulo != undefined && modulo != "") AreaDest.Modulo = modulo
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wactpage=AreaDest.ActivePage;
	if (wactpage != null) {
		if (wactpage.GetTipoPag() == "FORM" && (wactpage.Func == "INS" || wactpage.Func == "ALT")) {  //se a pagina atual é um Form e estiver em inserção ou alteração é preciso por os valores em historial para as páginas abertas por esta
			for (var i=0; i<wactpage.Actls.length; i++) {
				if (wactpage.Actls[i].Tipo == "FORM") {
					wactpage.Actls[i].SaveHistorial();
					
				}
			}
		}
	}
	var wpage=new Qpage(xroot, AreaDest, func, key, cond)
	for (var p=0; p<AreaDest.Pages.length; p++) {  //é preciso tornar invisíveis todas as paginas anteriores. Se está a abrir uma pagina depois de um dialog este não torna invisiveis as paginas anteriores e é preciso faze-lo
		var wpagant=AreaDest.Pages[p];
		if (wpagant.Visible == true) wpagant.Hide();
	}
	if (AreaDest.Pages.length == 0 && AreaDest.BackPage != null) AreaDest.BackPage.Hide();
	AreaDest.Pages.push(wpage);
	AreaDest.ActivePage=wpage;
	wpage.Activate();
	if (App.ChangeUrl == "S") App.SetHash()
}


//******* Abrir Diálogo
function OpenDialog(AreaOrig, url, func, key, cond, area) {
	if (area != "" && area != undefined) {
		var AreaDest=App.GetArea(area);
	} else {
		var AreaDest=App.GetArea(AreaOrig.Target);
	}
	if (AreaDest == null) AreaDest=AreaOrig;
	if (AreaDest.Disabled == true) return;
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wactpage=AreaDest.ActivePage;
	if (wactpage != null) {
		if (wactpage.GetTipoPag() == "FORM" && (wactpage.Func == "INS" || wactpage.Func == "ALT")) {  //se a pagina atual é um Form e estiver em inserção ou alteração é preciso por os valores em historial para as páginas abertas por esta
			for (var i=0; i<wactpage.Actls.length; i++) {
				if (wactpage.Actls[i].Tipo == "FORM") {
					wactpage.Actls[i].SaveHistorial();
					
				}
			}
		}
	}
	var wpage=new Qpage(xroot, AreaDest, func, key, cond, "DIALOG");
	if (AreaDest.Pages.length > 0) {
		var wpagant=AreaDest.Pages[AreaDest.Pages.length - 1];
		wpagant.Disable("DIALOG");
	}
	if (AreaDest.Pages.length == 0 && AreaDest.BackPage != null) AreaDest.Disable("DIALOG");
	AreaDest.Pages.push(wpage);
	AreaDest.ActivePage=wpage;
	wpage.Activate();
	if (App.ChangeUrl == "S") App.SetHash()
}

//******* Abrir Diálogo PopUp
function OpenPopupDialog(AreaOrig, url, func, key, cond, area) {
	if (area != "" && area != undefined) {
		var AreaDest=App.GetArea(area);
	} else {
		var AreaDest=App.GetArea(AreaOrig.Target);
	}
	if (AreaDest == null) AreaDest=AreaOrig;
	if (AreaDest.Disabled == true) return;
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wpage=new Qpage(xroot, AreaDest, func, key, cond, "POPUPDIALOG");
	if (AreaDest.Pages.length > 0) {
		var wpagant=AreaDest.Pages[AreaDest.Pages.length - 1];
		wpagant.Disable("POPUPDIALOG");
	}
	if (AreaDest.Pages.length == 0 && AreaDest.BackPage != null) AreaDest.Disable("POPUPDIALOG");
	App.DisableForPopup(AreaOrig, "POPUPDIALOG");
	AreaDest.Pages.push(wpage);
	AreaDest.ActivePage=wpage;
	wpage.Activate();
	if (App.ChangeUrl == "S") App.SetHash()
}


//******* Abrir Pagina fechando todas as anteriores da mesma area
function OpenFirstPage(AreaOrig, url, func, key, cond, area, modulo) {
	if (area != "" && area != undefined) {
		var AreaDest=App.GetArea(area);
	} else {
		var AreaDest=App.GetArea(AreaOrig.Target);
	}
	if (modulo == undefined) modulo = "";
	if (AreaDest == null) AreaDest=AreaOrig;
	if (AreaDest.Disabled == true) return;
	AreaDest.Modulo = modulo;
	if (!CloseAllPages(AreaDest)) {
	    window.alert(GetMsg(24, "Existem formulários abertos em modo de edição, termine primeiro as alterações"))
	    return
	}
	if (url == "") return
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wpage=new Qpage(xroot, AreaDest, func, key, cond);
	if (AreaDest.BackPage != null) AreaDest.BackPage.Hide();
	AreaDest.Pages.push(wpage);
	AreaDest.ActivePage=wpage;
	wpage.Activate();
	if (App.ChangeUrl == "S") App.SetHash()
}


//******* Abrir Pagina de background numa area
function OpenBackPage(AreaOrig, url, func, key, cond, area, modulo) {
	if (area != "" && area != undefined) {
		var AreaDest=App.GetArea(area);
	} else {
		var AreaDest=App.GetArea(AreaOrig.Target);
	}
	if (modulo == undefined) modulo = "";
	if (AreaDest == null) AreaDest=AreaOrig;
	AreaDest.Modulo = modulo;
	if (AreaDest.Disabled == true) return;
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wpage=new Qpage(xroot, AreaDest, func, key, cond)
	if (AreaDest.BackPage != null) {
		AreaDest.BackPage.Destroy();
	}
	AreaDest.BackPage = wpage;
	wpage.Activate();
}


//******* Abrir Window
function OpenWindow(AreaOrig, url, func, key, cond, parentpath, modulo, opts) {
	if (parentpath != "" && parentpath != undefined) {
		var atarget=GetCtlByHid(AreaOrig.Target);
		parentpath = atarget.Id + "." + atarget.ActivePage.Id + "." + parentpath;
	}
	var whostpanel=GetCtlByHid(parentpath);
	if (modulo == undefined) modulo = "";
	var wopts=opts.replace(/=/g, "=\"");
	wopts=wopts.replace(/\|/g, "\" ");
	wopts+= "\"";
	if (BrowserIE) {
		var xnod=new ActiveXObject("MSXML.DOMDocument");
		xnod.loadXML("<WINDOW " + wopts + "></WINDOW>");
	} else {
		var docparser=new DOMParser();
		var xnod=docparser.parseFromString("<WINDOW " + wopts + "></WINDOW>","text/xml");
	}
	if (xnod == null) {
		window.alert(GetMsg(1, "Comando OpenWindow com parametros opcionais inválidos (" + opts + ")"));
		return;
	}
	xnod=xnod.documentElement;
	if (xnod == null) {
		window.alert(GetMsg(1, "Comando OpenWindow com parametros opcionais inválidos (" + opts + ")"));
		return;
	}
	var wid=GetAtt(xnod, "ID", "");  //se ja existe uma window com aquela ID aborta a operação
	if (wid != "") {
		var wa=App.GetArea(wid)
		if (wa != null) return
	}
	var wwindow=new Qwindow(whostpanel, modulo, xnod);
	wwindow.Activate();
	wwindow.Historial=GetHistorialCopy(AreaOrig);
	if (url == "") return;
	if (App.MultiSite == "S") {
		var xroot=GetXmlData(url, AreaDest.Modulo);
	} else {
		var xroot=GetXmlData(url);
	}
	if (xroot == null) return;
	xroot=xroot.documentElement;
	if (cond == "" && Xcond != null) {
		cond = Xcond;
		Xcond = null;
	}
	var wpage=new Qpage(xroot, wwindow, func, key, cond);
	wwindow.Pages.push(wpage);
	wwindow.ActivePage=wpage;
	//wwindow.Activate();
	wpage.Activate();
	if (App.ChangeUrl == "S") App.SetHash()
}


//******* Abrir Janela de Browser
function OpenBrowserWindow(AreaOrig, url, wid, hei, parms, histparms) {
	var wurl=url;
	if (parms != "") {
		var Aw=parms.split("|");
		var ix=0;
		for (var i=0; i<Aw.length - 1; i++) {
			var idparm=Aw[i];
			var valparm=Aw[i+1];
			if (i == 0 && wurl.indexOf("?") == -1) {
				wurl=wurl + "?";
			} else {
				wurl=wurl + "&";
			}
			wurl=wurl + idparm + "=" + encodeURIComponent(valparm);
			i++;
		}
	}
	if (histparms != null && histparms != undefined) {
		var Aw=histparms.split("|");
		var ix=0;
		for (var i=0; i<Aw.length; i++) {
			ix=GetHistorialIndex(AreaOrig, Aw[i], "EQ");
			if (ix > -1) {
				if (i == 0 && wurl.indexOf("?") == -1) {
					wurl=wurl + "?";
				} else {
					wurl=wurl + "&";
				}
				wurl=wurl + Aw[i] + "=" + AreaOrig.Historial[ix].Valor;
			} else {
				ix=GetHistorialIndex(AreaOrig, Aw[i], "GE")
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?";
					} else {
						wurl=wurl + "&";
					}
					wurl=wurl + Aw[i] + "GE=" + AreaOrig.Historial[ix].Valor;
				}
				ix=GetHistorialIndex(AreaOrig, Aw[i], "LE");
				if (ix > -1) {
					if (i == 0 && wurl.indexOf("?") == -1) {
						wurl=wurl + "?";
					} else {
						wurl=wurl + "&";
					}
					wurl=wurl + Aw[i] + "LE=" + AreaOrig.Historial[ix].Valor;
				}
			}
		}
	}
	var tamanho="";
	if (wid != undefined && wid != "") tamanho += ", width=" + wid;
	if (hei != undefined && hei != "") tamanho += ", height=" + hei;
	PopUpWindow=window.open(wurl,"_blank","toolbar=yes, directories=yes, location=yes, menubar=yes, titlebar=yes, resizable=yes, scrollbars=yes " + tamanho + ", top=" + (window.screenTop + 20) + ", left=" + (window.screenLeft + 20));
}


//******* Reabrir Pagina
function ReOpenPage(AreaOrig, wxnod, warea, wfunc, wkey, wcond, wtipo) {
	AreaOrig.Pages.splice(AreaOrig.Pages.length - 1,1);
	AreaOrig.ActivePage=new Qpage(wxnod, warea, wfunc, wkey, wcond, wtipo);
	AreaOrig.Pages.push(AreaOrig.ActivePage);
	AreaOrig.ActivePage.Activate();
}

//******* Fechar Pagina
function ClosePage(AreaOrig, opt) {
	if (AreaOrig.ActivePage != undefined) {
		if (opt != "KeepHist") RemoveNivelHistorial(AreaOrig);
		var didupdate=false;
		if (AreaOrig.ActivePage.DidUpdate == "S") didupdate=true;
		if (AreaOrig.ActivePage.Tipo == "POPUPDIALOG") {
			App.EnableForPopup(AreaOrig, "POPUPDIALOG");
		}
		var wasdialog=false;
		if (AreaOrig.ActivePage.Tipo == "POPUPDIALOG" || AreaOrig.ActivePage.Tipo == "DIALOG") wasdialog=true;
		var tipopag=AreaOrig.ActivePage.Tipo
		if (opt == "ReloadPage") {  //isto é para guardar informação da página para a poder reabrir a mesma pagina no caso de INS_REP
			var wxnod=AreaOrig.ActivePage.Xnod;
			var warea=AreaOrig.ActivePage.Area;
			var wfunc=AreaOrig.ActivePage.FuncIni;
			var wkey=AreaOrig.ActivePage.Key;
			var wcond=AreaOrig.ActivePage.Cond;
			var wtipo=AreaOrig.ActivePage.Tipo;
			AreaOrig.ActivePage.Destroy("DESTROYNOW");
			AreaOrig.ActivePage=null;
			ReOpenPage(AreaOrig, wxnod, warea, wfunc, wkey, wcond, wtipo);
			return;
		}
		AreaOrig.ActivePage.Destroy();
		AreaOrig.ActivePage=null;
		if (AreaOrig.CanExpand == "S" && wasdialog == false) AreaOrig.ResetExpand();
		AreaOrig.Pages.splice(AreaOrig.Pages.length - 1,1);
		if (AreaOrig.Pages.length > 0) {
			AreaOrig.ActivePage=AreaOrig.Pages[AreaOrig.Pages.length -1];
			if (AreaOrig.ActivePage.PanelObj.disabled == true) AreaOrig.ActivePage.Enable(tipopag);
			if (AreaOrig.ActivePage.CallerCtl.Tipo == "MULTIFORM" && didupdate == true) {
				if (AreaOrig.ReturnValue != "" && (AreaOrig.ReturnProvider == "*" || AreaOrig.ReturnProvider == AreaOrig.ActivePage.CallerCtl.Provider)) AreaOrig.ActivePage.CallerCtl.SetKey(AreaOrig.ReturnValue);     //MultiformSetKey(AreaOrig.ActivePage.CallerCtl, AreaOrig.ReturnValue)
				AreaOrig.ActivePage.CallerCtl.Activate();
			}
			if (AreaOrig.ActivePage.CallerCtl.Tipo == "FLASH" || AreaOrig.ActivePage.CallerCtl.Tipo == "CHART") {
                if (didupdate == true) {
                    AreaOrig.ActivePage.CallerCtl.ProcessEvents("Refresh", "", "");
                }
                else {
                    AreaOrig.ActivePage.CallerCtl.ProcessEvents("RefreshFromCancel", "", "");
                }
            }
			if (opt == "UpdateCtls" && didupdate == true) UpdateCtls(AreaOrig);
			if (didupdate == true) {  // testar se deve fazer Refresh a form
				var wpage=AreaOrig.ActivePage;
				for (var i=0; i<wpage.Actls.length; i++) {
					if (wpage.Actls[i].Tipo == "FORM") {
						if (wpage.Actls[i].Refreshable == true) wpage.Actls[i].Execute("Refresh");
					}
				}
			}
			var wevent=""
			for (var i=0; i<AreaOrig.ActivePage.Events.length; i++) {
				wevent=AreaOrig.ActivePage.Events[i]
				if (wevent.Id == "RETURNFROMCANCEL" && didupdate == false) {
					ExecCmd(AreaOrig, wevent.Act)
				}
				if (wevent.Id == "RETURNFROMUPDATE" && didupdate == true) {
					ExecCmd(AreaOrig, wevent.Act)
				}
			}
			AreaOrig.ActivePage.Resize();
			if (tipopag == "DIALOG" || tipopag == "POPUPDIALOG") {
				AreaOrig.ActivePage.Enable(tipopag);
			} else {
				AreaOrig.ActivePage.Show();
			}
			if (AreaOrig.ActivePage.Tipo == "DIALOG") {  // se voltou para um dialog é preciso mostrar todos os dialogs para trás até inclusive à primeira pagina que não seja dialog 
				for (var p=AreaOrig.Pages.length -2; p>=0; p--) {
					var wpage=AreaOrig.Pages[p];
					wpage.Show()
					if (wpage.Tipo == "PAGE") break;
				}
			}
			if (AreaOrig.ActivePage.LastFocusCtl != null && typeof AreaOrig.ActivePage.LastFocusCtl.Focus != 'undefined') AreaOrig.ActivePage.LastFocusCtl.Focus()   //colocar o focus no ultimo controlo onde estava antes de outra pagina ter sido aberta
		} else {
			if (AreaOrig.BackPage != null) {
			    if (AreaOrig.BackPage.PanelObj.disabled == true) AreaOrig.BackPage.Enable(tipopag);
				AreaOrig.BackPage.Resize();
				if (tipopag == "DIALOG" || tipopag == "POPUPDIALOG") {
					AreaOrig.BackPage.Enable(tipopag);
				} else {
					AreaOrig.BackPage.Show();
				}
			}
			if (AreaOrig.Tipo == "WINDOW") AreaOrig.Destroy();
		}
	}
	if (App.ChangeUrl == "S") App.SetHash();
}


//******* Fechar Pagina retornando para script
function ClosePageReturn(AreaOrig, opt) {
	if (AreaOrig.ActivePage != undefined) {
		if (opt != "KeepHist") RemoveNivelHistorial(AreaOrig);
		var wrec="";
		for (var c=0; c<AreaOrig.ActivePage.Actls.length; c++) {
			var ctl=AreaOrig.ActivePage.Actls[c]
			if (ctl.Tipo == "FORM") wrec=ctl.Dados;
		}
		if (AreaOrig.ActivePage.Tipo == "POPUPDIALOG") {
		    App.EnableForPopup(AreaOrig, "POPUPDIALOG");
		}
		var wrotina=AreaOrig.ActivePage.Cond;
		var didupdate=false;
		if (AreaOrig.ActivePage.DidUpdate == "S") didupdate=true;
		var tipopag=AreaOrig.ActivePage.Tipo
		AreaOrig.ActivePage.Destroy();
		AreaOrig.ActivePage=null;
		if (AreaOrig.CanExpand == "S") AreaOrig.ResetExpand();
		AreaOrig.Pages.splice(AreaOrig.Pages.length - 1,1);
		if (AreaOrig.Pages.length > 0) {
			AreaOrig.ActivePage=AreaOrig.Pages[AreaOrig.Pages.length -1];
			if (AreaOrig.ActivePage.PanelObj.disabled == true) AreaOrig.ActivePage.Enable(tipopag);
			if (AreaOrig.ActivePage.CallerCtl.Tipo == "MULTIFORM" && didupdate == true) {
				if (AreaOrig.ReturnValue != "" && (AreaOrig.ReturnProvider == "*" || AreaOrig.ReturnProvider == AreaOrig.ActivePage.CallerCtl.Provider)) AreaOrig.ActivePage.CallerCtl.SetKey(AreaOrig.ReturnValue);    //MultiformSetKey(AreaOrig.ActivePage.CallerCtl, AreaOrig.ReturnValue)
				AreaOrig.ActivePage.CallerCtl.Activate();
			}
			if (AreaOrig.ActivePage.CallerCtl.Tipo == "FLASH" && didupdate == true) AreaOrig.ActivePage.CallerCtl.ProcessEvents("Refresh", "", "");
			if (opt == "UpdateCtls" && didupdate == true) UpdateCtls(AreaOrig);
			AreaOrig.ActivePage.Resize();
			if (tipopag == "DIALOG" || tipopag == "POPUPDIALOG") {
			    AreaOrig.ActivePage.Enable(tipopag);
			} else {
				AreaOrig.ActivePage.Show();
			}
			if (AreaOrig.ActivePage.Tipo == "DIALOG") {  // se voltou para um dialog é preciso mostrar todos os dialogs para trás até inclusive à primeira pagina que não seja dialog 
				for (var p=AreaOrig.Pages.length -2; p>=0; p--) {
					var wpage=AreaOrig.Pages[p];
					wpage.Show()
					if (wpage.Tipo == "PAGE") break;
				}
			}
			var parms="";
			for (var p=0; p<wrec.length; p++) {
				if (p>0) parms += ", ";
				parms += "\"" + wrec[p] + "\""	;
			}
			var wexe=wrotina + "(" + parms + ")";
			try {eval(wexe)}
			catch(exp) {
				window.alert(GetMsg(1, "Função ClosePageReturn - " + exp));
				return;
			}
		} else {
			if (AreaOrig.BackPage != null) {
			    if (AreaOrig.BackPage.PanelObj.disabled == true) AreaOrig.BackPage.Enable(tipopag);
				AreaOrig.BackPage.Resize();
				if (tipopag == "DIALOG" || tipopag == "POPUPDIALOG") {
					AreaOrig.BackPage.Enable(tipopag);
				} else {
				    AreaOrig.BackPage.Show();
				}
			}
			if (AreaOrig.Tipo == "WINDOW") AreaOrig.Destroy();
		}
	}
	if (App.ChangeUrl == "S") App.SetHash()
}


//******* Fechar todas as páginas
function CloseAllPages(AreaOrig, opt) {
    if (!api.IsAreaClosed(AreaOrig, AreaOrig.Id)) {
        if (opt != "FORCE") {
            // primeiro tem de percorrer todas para verificar se pode fechar
            // se existirem forms abertos em modo de edição (INS ou ALT) não deixa fechar
            for (var i = AreaOrig.Pages.length - 1; i >= 0; i--) {
                var wpage = AreaOrig.Pages[i];
                if (wpage.UpdatePending == true) return false;
            }
        }
        // se não falhou a verificação anterior, então fecha tudo
        for (var i = AreaOrig.Pages.length - 1; i >= 0; i--) {
            var wpage = AreaOrig.Pages[i];
            for (var c = 0; c < wpage.Actls.length; c++) {  //cancelar todas as forms activas
                if (wpage.Actls[c].Tipo == "FORM") {
                    wpage.Actls[c].Execute("CancelAuto");
                    //break;
                }
            }
            AreaOrig.Pages[i].Destroy();
            AreaOrig.Pages.splice(i, 1);
        }
    }
    AreaOrig.ActivePage = null;
    RemoveNivelHistorial(AreaOrig);
    if (AreaOrig.Tipo == "WINDOW") AreaOrig.Destroy();
    if (AreaOrig.CanExpand == "S") AreaOrig.ResetExpand();
    if (AreaOrig.BackPage != null) {
        AreaOrig.BackPage.Resize();
        AreaOrig.BackPage.Show();
    }
    return true;
}


//******* Fechar paginas de modo a ficar uma específica aberta
function GoToPage(AreaOrig, ix) {
	if (AreaOrig.Disabled == true) return;
	var didupdate=false;
	for (var i=AreaOrig.Pages.length - 1; i>ix; i--) {
		if (AreaOrig.Pages[i].DidUpdate == "S") didupdate=true;
		AreaOrig.Pages[i].Hide();
		AreaOrig.Pages[i].Destroy();
		AreaOrig.Pages.splice(i,1);
	}
	AreaOrig.ActivePage=null;
	RemoveNivelHistorial(AreaOrig);
	AreaOrig.ActivePage=AreaOrig.Pages[AreaOrig.Pages.length -1];
	if (AreaOrig.ActivePage.PanelObj.disabled == true) AreaOrig.ActivePage.Enable("DIALOG");
	if (AreaOrig.ActivePage.CallerCtl.Tipo == "MULTIFORM" && didupdate == true) AreaOrig.ActivePage.CallerCtl.Activate();
	if (AreaOrig.ActivePage.CallerCtl.Tipo == "FLASH" && didupdate == true) AreaOrig.ActivePage.CallerCtl.ProcessEvents("Refresh", "", "");
	AreaOrig.ActivePage.Resize();
	AreaOrig.ActivePage.Show();
}

//******* ReloadPage  - situação provocada por pagina com partes online e outras offline
function ReloadPage(pag) {
	window.alert(GetMsg(1, "Execução da função ReloadPage ainda não implementada"));
}


//******* ReturnVal
function ReturnVal(AreaOrig, opt) {
	ClosePage(AreaOrig, opt);
	if (AreaOrig.ActivePage != null) {
		AreaOrig.ActivePage.CallerCtl.SetVal(AreaOrig.ReturnValue);
	}
}

//******* PrintPage
function PrintPage(AreaOrig) {
	if (AreaOrig.ActivePage == null) return;
	PrintContent = AreaOrig.ActivePage.Panel.cloneNode(true);
	if (BrowserIE) {
		PrintContent = AreaOrig.ActivePage.Panel.innerHTML;
	} else {
		PrintContent = AreaOrig.ActivePage.Panel.cloneNode(true);
	}
	PrintWindow=window.open("printpag.htm", "Print", "toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=no, width=100, height=60, left=0, top=0");
}

function GetPrintContent() {
	return PrintContent;
}

//******* Fazer Refresh de controlos da pagina activa
function UpdateCtls(AreaOrig) {
	var apage = AreaOrig.ActivePage;
	if (apage == undefined) return;
	UpdateCtlList(apage.Actls);
}

function UpdateCtlList(ctls) {
	for (var i = 0; i < ctls.length; i++) {
		if (ctls[i].Tipo == "MULTIFORM") ctls[i].Activate();
		if (ctls[i].Tipo == "FLASH") ctls[i].ProcessEvents("Refresh", "", "");
		if (ctls[i].Tipo == "ROTINA") ctls[i].TestRefresh();
		if (ctls[i].Tipo == "PARAGRAPH") ctls[i].Activate();
		if (ctls[i].Tipo == "FCONTROL") ctls[i].Refresh();
		if (ctls[i].Tipo == "PANEL" || ctls[i].Tipo == "TABPANEL") {
			UpdateCtlList(ctls[i].Actls);
		}
	}
}


//======================================================================================= Definição de Objectos

//***************************************************************** QUSER - define o utilizador
function Quser() {
	this.Modulos="";
	this.ModulosReais="";
	this.PermForm="";
	this.Ano=0;
	this.Actls=new Array();
	this.Apermgener=new Array();
	this.Language = InitLoadMsgSet();
	this.DateFmt=FormatSet.DateFmt;
	this.TimeFmt=FormatSet.TimeFmt;
	this.SepDec=FormatSet.SepDec;
	this.Sep1000=FormatSet.Sep1000;
	this.UserId="";
	this.UserName="";
	this.SessionId="";
	this.ModDbs=new Array();
	this.Status="0"
}

Quser.prototype.DoLogon=function(niveis, perm, ano, userid, username, status) {
	//this.Modulos="," + niveis + ",";
	this.Modulos="";
	this.ModulosReais="," + niveis + ",";
	this.PermForm=";" + perm + ";";
	if (perm.indexOf("*") > -1) {
		var Aw=perm.split(";");
		for (var i=0; i<Aw.length; i++) {
			if (Aw[i].indexOf("*") > -1) this.Apermgener.push(Aw[i]);
		}
	}
	this.Ano=Number(ano);
	if(isNaN(this.Ano)) this.Ano=0;
	this.UserId=userid;
	this.SessionId=userid;
	if (username != undefined) this.UserName=username;
	if (status == undefined || status == "") {
		this.Status="0";
	} else {
		this.Status=status;
	}
	if (this.Status == "0") this.Modulos=this.ModulosReais;
	this.ResetCtls();
	for (var i=0; i<App.Events.length; i++) {
		var event=App.Events[i];
		if (event.Id == "ONLOGON") {
			ExecCmd("", event.Act);
		}
	}
}

Quser.prototype.DoLogoff=function(opt) {
	//ver se ha updates pendentes em alguma AREA
	var flagupdate=false;
	for (var a=0; a<App.Areas.length; a++) {
		var warea=App.Areas[a];
		for (var i=warea.Pages.length - 1; i>=0; i--) {
			var wpage=warea.Pages[i];
			if (wpage.UpdatePending == true) {
				flagupdate=true;
				if (opt == "FORCE") {
					CloseAllPages(warea, "FORCE")
					break;
				}
			}
		}
	}
	if (flagupdate == true && opt != "FORCE") {
		window.alert(GetMsg(24, "Existem formulários abertos em modo de edição, termine primeiro as alterações"));
	    return;
	}
	this.Modulos="";
	this.ModulosReais="";
	this.PermForm="";
	this.Apermgener=new Array();
	this.Ano=0;
	this.UserId="";
	this.UserName="";
	this.SessionId="";
	this.ResetCtls();
	for (var i=0; i<App.Events.length; i++) {
		var event=App.Events[i];
		if (event.Id == "ONLOGOFF") {
			ExecCmd("", event.Act);
		}
	}
}

Quser.prototype.DoAnoChange = function (ano, nivel, perms) {
    this.SetAno_Internal(ano);
    this.SetNivel_Internal(nivel);
    this.SetPerm_Internal(perms);

    this.OnYearChange();
}

Quser.prototype.OnYearChange = function () {
    for (var i = 0; i < App.Events.length; i++) {
        if (App.Events[i].Id == "ONYEARDBCHANGE") {
            ExecCmd("", App.Events[i].Act)
        }
    }
}

Quser.prototype.SetNivel_Internal = function (w) {
    this.Modulos = "," + w + ",";    
}
Quser.prototype.SetNivel=function(w) {
    this.SetNivel_Internal(w);
	this.ResetCtls();
}

Quser.prototype.SetPerm_Internal = function (w) {
    this.PermForm = ";" + w + ";";
    if (w.indexOf("*") > -1) {
        var Aw = w.split(";");
        for (var i = 0; i < Aw.length; i++) {
            if (Aw[i].indexOf("*") > -1) this.Apermgener.push(Aw[i]);
        }
    }   
}
Quser.prototype.SetPerm=function(w) {
    this.SetPerm_Internal(w);
	this.ResetCtls();
}

Quser.prototype.SetAno_Internal = function (w) {
    this.Ano = Number(w);    
}
Quser.prototype.SetAno=function(w) {
    this.SetAno_Internal(w);
    this.OnYearChange();
}

Quser.prototype.SetLanguage=function(w) {
	this.Language=w;
	LoadMsgSet(w);
	this.DateFmt=FormatSet.DateFmt;
	this.TimeFmt=FormatSet.TimeFmt;
	this.SepDec=FormatSet.SepDec;
	this.Sep1000=FormatSet.Sep1000;
	if (InterfaceId != "QWEB") {
		try {window.external.SetLanguage(w);}
		catch(exp) {}
	}
}

Quser.prototype.SetId=function(uid, uname) {
	this.UserId=uid;
	this.SessionId=uid;
	if (uname != undefined) this.UserName=uname;
}

Quser.prototype.SetSessionId=function(uid) {
	if (uid == null || uid == undefined) return;
	if (uid == this.SessionId) return;
	if (uid == "*" + this.UserId) {
		this.SessionId = uid;
		for (var i=0; i<App.Events.length; i++) {
			if (App.Events[i].Id == "ONSESSIONTIMEOUT") {
				ExecCmdDelayed(200, "", App.Events[i].Act);  //executar comandos com um delay para permitir processar o pedido que deu origem à deteção da perda de sessão
			}
		}
		return;
	}
	this.SessionId = uid;
}

Quser.prototype.SetModDb=function(modulo, db) {  //guardar combinação   modulo;db  substituido se necessario alguma ja existente
	var w=modulo + ";";
	for (var i=0; i<this.ModDbs.length; i++) {
		if (this.ModDbs[i].indexOf(w) == 0) {
			this.ModDbs.splice(i,1);
			break;
		}
	}
	if (db != "") this.ModDbs.push(w + db);
}

Quser.prototype.GetModDb=function(modulo) {   //obter combinação modulo;db se existir alguma para esse modulo, senão obtem o modulo
	var w=modulo + ";";
	for (var i=0; i<this.ModDbs.length; i++) {
		if (this.ModDbs[i].indexOf(w) == 0) {
			return this.ModDbs[i];
		}
	}
	return modulo;
}

Quser.prototype.SetStatus=function(status) {
	if (status == undefined) {
		this.Status="0";
	} else {
		this.Status=status;
	}
	if (this.Status == "0") {
		this.Modulos=this.ModulosReais;
	} else {
		this.Modulos="";
	}
	this.ResetCtls();
}

Quser.prototype.ResetCtls=function() {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate("Refresh");
	}
}

Quser.prototype.GetNivel=function(modulo) {
	var wniv=0;
	var i=this.Modulos.indexOf("," + modulo + "=");
	if (i > -1) {
		var j=this.Modulos.indexOf("=", i);
		wniv=this.Modulos.substr(j+1, 2);
		if (wniv.indexOf(",") > -1) wniv=wniv.substr(0,1);
		wniv=Number(wniv);
	}
	return wniv;
}

Quser.prototype.ModAutorizado=function(modulo, nivseg) {    //****** verificar se expressão de nivel é autorizada para um módulo
	var wniv=0;
	var i=this.Modulos.indexOf("," + modulo + "=");
	if (i > -1) {
		var j=this.Modulos.indexOf("=", i);
		wniv=this.Modulos.substr(j+1, 2);
		if (wniv.indexOf(",") > -1) wniv=wniv.substr(0,1);
		wniv=Number(wniv);
	}
	var wresult=false;
	var Aw=nivseg.split(",");
	for (var s=0; s<Aw.length; s++) {
		var wns=Aw[s];
		var wi=wns.indexOf("-");
		if	(wi > 0) {
			var limi=Number(wns.substr(0, wi));
			var limf=Number(wns.substr(wi+1));
			if (wniv >= limi && wniv <= limf) wresult=true;
		} else {
			if (wniv == Number(wns)) wresult=true;
		}
	}
	return wresult;
}

Quser.prototype.ActAutorizado=function(modulo, act, area) {    //****** verificar a acção é autorizada
	if (act == "") return true;
	var Aw=act.split("(");
	if (Aw[0] != "OpenPage" && Aw[0] != "OpenFirstPage" && Aw[0] != "OpenDialog") return true;
	var parms=Aw[1] + ",,,,,";
	var Aparms=parms.split(",");
	var wpag=Aparms[0];
	var wfunc=Aparms[1];
	var wtperm="";
	//criar uma string (wtperm) com todas as permissões temporarias (de historial)
	if (area != undefined) {
		var hix=GetHistorialIndex(area, "$perm$", "EQ");
		if (hix > -1) wtperm=";" + area.Historial[hix].Valor + ";";
	}
	//procurar permissão para a pagina (wpag) que consta do comando (act) no historial
	var wpermh="";
	var i=-1;
	if (wtperm != "") {
		if (modulo != "") i=wtperm.indexOf(";" + modulo + "." + wpag + "=");
		if (i == -1) i=wtperm.indexOf(";" + wpag + "=");
		if (i > -1) {
			var j=wtperm.indexOf("=", i);
			var k=wtperm.indexOf(";", j);
			wpermh=wtperm.substr(j+1, k-j-1);
		}
	}
	//procurar permissão para a pagina (wpag) que consta do comando (act) nas permissões genericas do logon
	var wperml="";
	for (var p=0; p<this.Apermgener.length; p++) {
		var perm=this.Apermgener[p];
		var ast=perm.indexOf("*");
		var gener=perm.substr(0,ast);
		if (modulo != "" && gener.indexOf(".") > -1) {
			var w=modulo + "." + wpag;
			if (w.substr(0,ast) == gener) {
				var j=perm.indexOf("=");
				wperml=perm.substr(j+1);
				break;
			}
		}
		if (wpag.substr(0,ast) == gener) {
			var j=perm.indexOf("=");
			wperml=perm.substr(j+1);
			break;
		}
	}
	//procurar permissão para a pagina (wpag) que consta do comando (act) nas permissões específicas do logon
	if (modulo != "") i=this.PermForm.indexOf(";" + modulo + "." + wpag + "=");
	if (i == -1) i=this.PermForm.indexOf(";" + wpag + "=");
	if (i > -1) {
		var j=this.PermForm.indexOf("=", i);
		var k=this.PermForm.indexOf(";", j);
		wperml=this.PermForm.substr(j+1, k-j-1);
	}
	if (wpermh == "" && wperml == "") return true;
	var wperm="";
	if (wperml == "") {
		if (wpermh == "") {
			return true;
		} else {
			wperm=wpermh;
		}
	} else {
		if (wpermh == "") {
			wperm=wperml;
		} else {
			// merge de permissões: ficam as mais restritivas
			wperm=wperml;
			for (var i=0; i<wperml.length; i++) {
				var w=wperml.substr(i,1);
				if (wpermh.indexOf(w) == -1) wperm=wperm.replace(w, "");
			}
		}
	}
	wresult=false;
	switch(wfunc) {
		case "VIS":
			if (wperm.indexOf("V") > -1) wresult=true;
			break;
		case "ALT":
			if (wperm.indexOf("A") > -1) wresult=true;
			break;
		case "INS":
			if (wperm.indexOf("I") > -1) wresult=true;
			break;
		case "DUP":
			if (wperm.indexOf("D") > -1) wresult=true;
			break;
		case "ELI":
			if (wperm.indexOf("E") > -1) wresult=true;
			break;
		case "EXE":
			if (wperm.indexOf("X") > -1) wresult=true;
			break;
		case "EXR":
			if (wperm.indexOf("X") > -1) wresult=true;
			break;
		case "EXW":
			if (wperm.indexOf("X") > -1) wresult=true;
			break;
	}
	return wresult;
}


//***************************************************************** QAPP - define a aplicação
function Qapp(xnod) {
	this.Tipo="APP";
	this.Class="APP";
	this.Id=GetAtt(xnod, "ID", "?");
	this.Hid="";
	this.Tit=GetAtt(xnod, "TIT", "?");
	this.Dir=new Array();
	this.ImgSrc=new Array();
	this.Db=new Array();
	this.Services=new Array()
	this.Areas=new Array();
	this.Actls=new Array();
	this.Sctls=new Array();
	this.StyleLib=new QstyleLib();
	App=this;
	this.DefLanguage=GetAtt(xnod, "LANG", "");
	if (this.DefLanguage != User.Language && this.DefLanguage != "") User.SetLanguage(this.DefLanguage);
	this.Currency=GetAtt(xnod, "CURRENCY", "€");
	this.ServerTimeDif=0;
	this.WaitImg=GetAtt(xnod, "WAITIMG", "");
	this.CanExpand=GetAtt(xnod, "CANEXPAND", "N");
	this.WaitId="";
	this.MultiSite=GetAtt(xnod, "MULTISITE", "N");
	this.ReplaceDialogs=GetAtt(xnod, "REPLACEDIALOGS", "N");
	this.ChangeUrl=GetAtt(xnod, "CHANGEURL", "N");
	this.Version=GetAtt(xnod, "VER", "1.0");
	this.Queuedcmds=new Array();
	this.Queueid=0;
	this.Events=new Array();
	this.Aanim=new Array();
	this.IsAnimating=false;
	this.CmdLog=new Array();
	this.Location=GetAtt(xnod, "LOCATION", "0,0");
	this.Size= GetAtt(xnod, "SIZE", "*,*");
	this.Locsize=new QlocSize(this.Location, this.Size, null);
	var xn=xnod.firstChild;
	while (xn != undefined) {
		if (xn.nodeName == "WINDOW") {
			var w1=GetAtt(xn, "LOCATION", "0,0");
			if (w1 != "0,0") this.Location=w1;
			var w2=GetAtt(xn, "SIZE", "*,*");
			if (w2 != "*,*") this.Size=w2;
			if (w1 != "0,0" || w2 != "*,*") {
				this.Locsize=new QlocSize(this.Location, this.Size, null);
			}
			w1=GetAtt(xn, "WAITIMG", "");
			if (w1 != "") this.WaitImg=w1;
			w1=GetAtt(xn, "CANEXPAND", "N");
			if (w1 != "") this.CanExpand=w1;
			break;
		}
		xn=xn.nextSibling;
	}
	this.Satus=""
	ImgLib=new QimgLib();
	var wdiv = document.createElement("DIV");
	wdiv.style.position="absolute";
	wdiv.style.overflow="auto";
	wdiv.id="QwebScreenWindow";
	document.body.appendChild(wdiv);
	wdiv.style.zIndex=2;
	wdiv.onscroll=function() {
		App.OnScroll()
	}

	//Div para ser usada para impressão. Por CSS está invisível para media=screen e visivel para media=print ao contrario da QwebScreenWindow
	var wdivp = document.createElement("DIV");
	wdivp.id="QwebPrintWindow";
	document.body.appendChild(wdivp);
	this.Hobjp=wdivp;

	//Div para aparecer sempre que é preciso bloquear o acesso do utilizador a toda a janela
	this.WaitScreen = document.createElement("DIV");
	this.WaitScreen.style.position="absolute";
	document.body.appendChild(this.WaitScreen);
	this.WaitScreen.style.width="100%";
	this.WaitScreen.style.height="100%";
	this.WaitScreen.style.zIndex=1000;
	this.WaitScreen.style.cursor="wait";
	this.WaitScreen.style.display="none";
	if (this.WaitImg != "") {
		var wimg = document.createElement("IMG");
		wimg.src=GetImageAddress(this.WaitImg);
		wimg.style.position="absolute";
		wimg.style.margin="auto"
		wimg.style.top="0"
		wimg.style.left="0"
		wimg.style.right="0"
		wimg.style.bottom="0"
		wimg.style.display="none";
		this.WaitScreen.appendChild(wimg);
		this.Hwimg=wimg;
	}
	
	this.PanelObj=wdiv;
	this.Hobj=wdiv;
	this.Resize();
	var xn=xnod.firstChild;
	while (xn != undefined) {
		if (xn.nodeName == "DIR" || xn.nodeName == "PAGSRC") {
			var wdir=new Qdirdb(GetAtt(xn, "ID", ""), GetAtt(xn, "TYPE", ""), GetAtt(xn, "ADDR", ""));
			if (wdir.Type == "TEMP" && InterfaceId != "QWEB") {
				wdir.Address=window.external.GetTempPath();
			}
			this.Dir.push(wdir);
		}
		if (xn.nodeName == "IMGSRC") this.ImgSrc.push(new Qdirdb(GetAtt(xn, "ID", ""), GetAtt(xn, "TYPE", ""), GetAtt(xn, "ADDR", "")));
		if (xn.nodeName == "DB") this.Db.push(new Qdirdb(GetAtt(xn, "ID", ""), GetAtt(xn, "TYPE", ""), GetAtt(xn, "ADDR", "")));
		if (xn.nodeName == "STYLE") this.StyleLib.LoadStyle(xn);
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn);
			this.Events.push(wevent);
		}
		if (xn.nodeName == "SERVICE") {
			var id = GetAtt(xn, "ID", "")
			this.Services[id] = new Qdirdb(id, GetAtt(xn, "TYPE", ""), GetAtt(xn, "ADDR", ""))
		}
		xn=xn.nextSibling;
	}
	//criar uma AREA interna onde corre o Autologon e outros procesos internos q venham a ser necessarios. O Autologon abre na primeira AREA e podia originar conflitos com outros processos automaticos.
	var xstriarea="<AREA ID=\"Aqwebinternal\" TARGET=\"Aqwebinternal\" LOCATION=\"0,0\" SIZE=\"0,0\" />";
	var xiarea=CreateXnode(xstriarea);
	this.Areas.push(new Qarea(xiarea, this));
	var xn=xnod.firstChild;
	while (xn != undefined) {
		if (xn.nodeName == "AREA") this.Areas.push(new Qarea(xn, this));
		xn=xn.nextSibling;
	}
	FocusCtl=new Qfocus();
	this.OldHash=GetCurrentHash();
	if (this.ChangeUrl == "S") {
		//this.OldHash=GetCurrentHash();
		this.HashIgnore=false;
		this.HashIgnoreIframe=false;
		var docmode = document.documentMode;
		if ('onhashchange' in window && (docmode === undefined || docmode > 7 )) {
			window.onhashchange = function() {
				App.HashChanged();
			}
		} else {
			this.HashIgnoreIframe=true;
			var wifr=document.createElement("IFRAME");
			wifr.frameborder=0;
			wifr.id="qwebiframehesh";
			wifr.style.position="absolute";
			wifr.style.left="50px";
			wifr.style.top="50px";
			wifr.style.width="300px";
			wifr.style.height="100px";
			wifr.style.display="none";
			wifr.src="hashdetect.htm?" + this.OldHash;
			this.Hifr=wifr;
			this.Hobj.appendChild(wifr);
			window.setInterval("HashEvent()", 400);
		}
	}
}

Qapp.prototype.Resize=function() {
	var xtraheight=0  //uma AREA que expande com uma altura de *-nn precisa que a APP expanda com mais esses nn pixels
	this.Locsize.Resize(this.PanelObj);
	for (var i=0; i<this.Areas.length; i++) {
		this.Areas[i].Resize("appresize");
		if (this.Areas[i].CanExpand == "S") {
			var warea=this.Areas[i];
			if (warea.Locsize.RefH == "R") {
				var wh=-warea.Locsize.OffH;
				if (wh > xtraheight) xtraheight=wh;
			}
		}
	}
	if (this.Locsize.RefH == "R" && this.CanExpand == "S") {
		this.Locsize.UnScrollH(this.Hobj);
		
	}
	//if (xtraheight != 0) this.Hobj.style.height=(this.Locsize.ObjH + xtraheight) + "px";
}

Qapp.prototype.OnScroll=function() {
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == "ONSCROLL") {
			if (this.Events[i].Act != "") ExecCmd(this, this.Events[i].Act);
		}
	}
}

Qapp.prototype.Expand=function(xarea, newheight, oldheight) {   //expandir a APP na vertical sendo especificada a AREA que provoca a expansão e o tamanho da mesma
	this.Locsize.CheckScrollBars(this.Hobj)
	if (this.CanExpand != "S") return
	this.Locsize.UnScrollH(this.Hobj)

	this.Hobj.style.overflow="hidden"
	var theight=this.Locsize.ObjH + newheight - oldheight
	var Aw=this.Size.split(",");
	this.Locsize=new QlocSize(this.Location, Aw[0] + "," + theight, this.ParentObj);
	this.Resize();
}

Qapp.prototype.ResetExpand=function() {   //repor a APP do tamanho especificado nos parametros da aplicação
	this.Hobj.style.overflow="auto"
	this.Locsize=new QlocSize(this.Location, this.Size, this.ParentObj);
	this.Resize()
}

Qapp.prototype.GetArea = function(id) {
	for (var i=0; i<this.Areas.length; i++) {
		if (this.Areas[i].Id == id) return this.Areas[i];
	}
	return null;
}

Qapp.prototype.GetStyle = function(id, tipo) {
	return this.StyleLib.GetStyle(id, tipo);
}

Qapp.prototype.CloneStyle = function(id, tipo, newid) {
	return this.StyleLib.CloneStyle(id, tipo, newid);
}

Qapp.prototype.SetServerDate = function(srvdatestr) {
	var srvdate=new Date(srvdatestr);
	var wdate=new Date();
	this.ServerTimeDif=wdate.getTime() - srvdate.getTime();
	if (this.ServerTimeDif < 2000) this.ServerTimeDif=0;
}

Qapp.prototype.GetServerDate = function() {
	var wagora=Agora();
	var wdtsrv=Agora();
	wdtsrv.setTime(wagora.getTime() + this.ServerTimeDif);
	return wdtsrv;
}

Qapp.prototype.AddCmdLog = function(wstr) {
	if (this.CmdLog.length > 600) this.CmdLog.splice(0,20);  //limpar inicio do log se estiver cheio
	var t=new Date().getTime();  //preparar ultimos digitos de timestamp  
	t="" + t;
	t=t.substr(6);
	this.CmdLog.push(t + ": " + wstr);
}

Qapp.prototype.Start = function() {
	ExecCmd(this.Areas[0], "OpenPage(QwAutoLogon,,,," + this.Areas[0].Id);
	if (this.Areas[0].ActivePage != null) ExecCmd(this.Areas[0], "ClosePage(");
	for (var i=0; i<this.Areas.length; i++) {
		this[this.Areas[i].Id]=this.Areas[i];
		if (this.Areas[i].Start != "") {
			ActiveArea=this.Areas[i];
			ExecCmd(this.Areas[i], this.Areas[i].Start);
		}
	}
	var wanim=new Qanimator(this, "WAIT", "NONE,10,0,S")
	wanim.Activate(this.Start2);
}

Qapp.prototype.Start2 = function() {
	this.Status="OK";
	this.StandardHash=this.GetCurrentHash();
	this.InitialHash=this.StandardHash;
	if (this.OldHash != "") this.InitialHash=this.OldHash;
	if (this.InitialHash != this.StandardHash) {
		this.OldHash="";
		this.HashChanged();
	}
}

Qapp.prototype.HashChanged = function(opt) {
	if (this.OldHash == GetCurrentHash()) return;
	if (this.HashIgnore == false) {  //se o hash foi mudado pelo browser e não por mudança interna de pagina
		for (var i=0; i<this.Areas.length; i++) {  //verificar se há forms em edição e se for o caso aborta a navegação para o url
			var warea=this.Areas[i];
			if (warea.SaveInUrl == "S") {
				var wpage=warea.ActivePage
				if (wpage != null) {
					if (wpage.UpdatePending == true) {
						window.alert(GetMsg(24));  //Existem formulários abertos em modo de edição, termine primeiro as alterações
						if (this.Hifr == undefined) this.HashIgnoreIframe=true
						window.location.hash=api.Base64YEncode(this.OldHash);
						return;
					}
				}
			}
		}
	}
	this.OldHash=GetCurrentHash();
	if (opt != "IFRAME") this.HashIgnoreIframe=true;
	if (this.Hifr != undefined) this.Hifr.src="hashdetect.htm?" + api.Base64YEncode(this.OldHash);  //escape(this.OldHash);
	if (this.HashIgnore == true) {
		this.HashIgnore=false;
		return;
	}
	if (this.OldHash == "") {
		this.ExecHashCmd(this.StandardHash);
	} else {
		this.ExecHashCmd();
	}
}

Qapp.prototype.ExecHashCmd = function(hash) {
	//a cadeia de comandos deve começar por um SetArea (SA) seguido provavelmente de varios SetHistorial (SH) e acabar num OpenFirstPage (OFP)
	if (hash == undefined) hash=this.OldHash;
	var acts=hash.split("{");
	var warea=null;
	var wpage=null;
	var wcmd="";
	for (var i=0; i<acts.length; i++) {
		var act=acts[i];
		var ix=act.indexOf("(");
		var cmd=act.substr(0,ix);
		var wparms=act.substr(ix+1) + ",,,,,,,,,";
		var parms=wparms.split(",");
		if (cmd == "SA") {
			var ignorecmds=false;
			if (warea != null && wpage != null) {
				var ix=this.GetPageInChainIndex(hash, warea, wpage);  // se for uma pagina ja carregada na hierarquia da AREA não executar os comandos, deve ser o botão Back do browser
				if (ix > -1) {
					GoToPage(this.GetArea(warea), ix);
					wcmd="";
				}
			}
			if (wcmd != "") ExecCmd("", wcmd);
			wcmd="";
			warea=parms[0];
		}
		if (cmd == "OP") {
			wpage=parms[0];	
		}
		if (cmd == "OW") {
			ExecCmd("", act)
		} else {
			if (wcmd != "") wcmd += "{";
			wcmd += act;
		}
	}
	if (warea != null && wpage != null) {
		var ix=this.GetPageInChainIndex(hash, warea, wpage);  // se for uma pagina ja carregada na hierarquia da AREA não executar os comandos, deve ser o botão Back do browser
		if (ix > -1) {
			GoToPage(this.GetArea(warea), ix);
			wcmd="";
		}
	}
	if (wcmd != "") ExecCmd("", wcmd);
}

Qapp.prototype.GetPageInChainIndex = function(hash, warea, wpage) {
	var objarea=this.GetArea(warea);
	if (objarea != null) {
		var ix = objarea.GetPageIndex(wpage);
		if (ix == objarea.Pages.length - 1) return -1;  //não pode ser a pagina actual
		if (ix > -1) {
			var whash=objarea.Pages[ix].GetHash();
			if (hash == whash) {
				return ix;
			}
		}	
	}
	return -1;
}

Qapp.prototype.GetCurrentHash = function() {
	var hash="";
	for (var i=0; i<this.Areas.length; i++) {
		if (this.Areas[i].SaveInUrl == "S") {
			var warea=this.Areas[i];
			if (warea.ActivePage != null) {
				if (hash != "") hash += "{";
				if (warea.Tipo == "WINDOW") hash += warea.GetHash();
				hash += warea.ActivePage.GetHash();
			} else {
				if (warea.Tipo == "WINDOW") hash += warea.GetHash();
				hash = "SA(" + warea.Id + "{CAP(";
			}
		}
	}
	return hash;
}

Qapp.prototype.SetHash = function() {
	if (this.Status != "OK") return;
	var hash=this.GetCurrentHash();
	if (hash == this.StandardHash && this.OldHash == "") return;
	if (hash != this.OldHash) {
		if (hash == this.StandardHash) hash="";
		this.HashIgnore=true;
		hash=api.Base64YEncode(hash);   //escape(hash);
		window.location.hash=hash;
		if (this.Hifr != undefined) this.Hifr.src="hashdetect.htm?" + hash;
	}
}

Qapp.prototype.DisableForPopup = function(popuparea, tipo) {
	for (var i=0; i<this.Areas.length; i++) {
		if (this.Areas[i] != popuparea) {
			if (this.Areas[i].ActivePage != null) this.Areas[i].ActivePage.Disable(tipo);
		}
	}
}

Qapp.prototype.EnableForPopup = function(popuparea, tipo) {
	for (var i=0; i<this.Areas.length; i++) {
		if (this.Areas[i] != popuparea) {
			if (this.Areas[i].ActivePage != null) {
				if (this.Areas[i].ActivePage.PanelObj.disabled == true) this.Areas[i].ActivePage.Enable(tipo);
			}
		}
	}
}

Qapp.prototype.ResetCtls=function() {
	for (var i=0; i<this.Sctls.length; i++) {
		this.Sctls[i].Reset();
	}
}

Qapp.prototype.DbOnline=function(db) {
	var wonline="";
	if (db == "*") {
		wonline=this.Db[0].Online;
	} else {
		for (var i=0; i<this.Db.length; i++) {
			if (this.Db[i].Id == db) {
				wonline=this.Db[i].Online;
				break;
			}
		}
	}
	return wonline;
}

Qapp.prototype.BlockAllInput = function(id) {
	if (AllInputBlocked == true) return
	AllInputBlocked=true;
	this.WaitScreen.style.display="block";
	if (this.WaitImg != "") {
		App.InputBlockStamp=new Date().getTime();  //estabelecer um timestamp para mostrar gif animado ou não
		window.setTimeout("App.BlockAllInputTimeout(" + App.InputBlockStamp + ")", 500);
	}
}

Qapp.prototype.UnBlockAllInput = function() {
	if (ComUnits.length == 0 && IsQueueEmpty()) {
		AllInputBlocked=false;
		this.WaitScreen.style.display="none";
		if (this.WaitImg != "") {
			this.Hwimg.style.display="none";
			App.InputBlockStamp=0;
		}
	}
}

Qapp.prototype.BlockAllInputTimeout = function(timestamp) {
	if (timestamp == App.InputBlockStamp) {
		this.Hwimg.style.display="block";
	}
}

Qapp.prototype.AddAnimation = function(wanim) {
    this.StopIfAnimating(wanim.Ctl)
	this.Aanim.push(wanim);
	if (this.IsAnimating == false) this.Animate();
}

Qapp.prototype.StopIfAnimating = function(ctl) {
    for (var i = 0; i < this.Aanim.length; i++) {
        if (this.Aanim[i].Ctl == ctl) {  //se o mesmo controlo estiver a ser animado, animar a ultima frame e eliminar a entrada de animação
        	this.Aanim[i].Frame = this.Aanim[i].Frames-1;
            this.Aanim[i].Animate();
            this.Aanim.splice(i, 1);
            break;
        }
    }
}

Qapp.prototype.Animate = function() {
	this.IsAnimating=true;
	var wtimestart=Agora().getTime();
	for (var i=0; i<this.Aanim.length; i++) {
		if (this.Aanim[i].Sync == "S" && i > 0) break;
		this.Aanim[i].Animate();
		if (this.Aanim[i].Frame == this.Aanim[i].Frames) {
			this.Aanim.splice(i,1);
			i--;
		} else {
			//if (this.Aanim[i].Sync == "S") break;
		}
	}
	var wtimeend=Agora().getTime();
	if (this.Aanim.length > 0) {
		var duration=wtimeend-wtimestart;  //o intervalo seguinte deve aproximar-se das 60 frames por segundo
		duration=16.6 - duration;
		if (duration < 0) duration = 0;
		window.setTimeout("App.Animate()", duration);
		return;
	}
	this.IsAnimating=false;
}

Qapp.prototype.IsAnimating = function(hid) {
	for (var i=0; i<this.Aanim.length; i++) {
		if (this.Aanim[i].Ctl.Hid.indexOf(hid) > -1) {
			return true;
		}	
	}
	return false;
}

Qapp.prototype.OnMouseOver=function() {	
}

Qapp.prototype.OnMouseOut=function() {	
}

Qapp.prototype.Destroy = function() {
	for (var i=0; i<this.Areas.length; i++) {
		this.Areas[i].Destroy();
	}
	var wparent=this.PanelObj.parentNode;
	if (wparent != null) wparent.removeChild(this.PanelObj);
}



//***************************************************************** QAREA - define Areas de ecrã
function Qarea(xnod, parentobj) {
	this.ParentObj=parentobj;
	this.HostPanel=parentobj;
	this.TabIndexBase=(App.Areas.length + 1) * 1000
	this.Tipo="AREA";
	this.Class="AREA";
	this.Id=GetAtt(xnod, "ID", "");
	if (this.Id == "") this.Id="Area" + this.HostPanel.Areas.length;
	this.Hid=this.Id;
	this.Target=GetAtt(xnod, "TARGET", "");
	this.Hid=this.Id;
	this.Style=GetAtt(xnod, "STYLE", "DEFAULT");
	this.Start=GetAtt(xnod, "START", "");
	this.Pin=GetAtt(xnod, "PIN", "");
	this.Popup=GetAtt(xnod, "POPUP", "N");
	this.AbsCoord=GetAtt(xnod, "ABSCOORD", "N");
	this.SaveInUrl=GetAtt(xnod, "SAVEINURL", "N")
	this.CanExpand=GetAtt(xnod, "CANEXPAND", "N")
	this.Location=GetAtt(xnod, "LOCATION", "0,0")
	this.Size=GetAtt(xnod, "SIZE", "0,0")
	this.ShowWaitSign=GetAtt(xnod, "SHOWWAITSIGN", "S");
	this.Pages=new Array();
	this.Actls=new Array();
	this.ActivePage=null;
	this.BackPage=null;
	this.Historial=new Array();
	this.ReturnValue="";
	this.ReturnProvider="";
	this.Modulo="";
	this.Dialogs=0;
	this.Disabled=false;
	this.MouseIsOver=false;
	this.Events=new Array();
	var xn=xnod.firstChild;
	while (xn!=undefined) {
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn);
			this.Events.push(wevent);
		}
		xn=xn.nextSibling;
	}
	this.Location=GetAtt(xnod, "LOCATION", "0,0");
	this.Size=GetAtt(xnod, "SIZE", "0,0");
	if (this.AbsCoord == "N") {
		this.Locsize=new QlocSize(this.Location, this.Size, parentobj);
		var wdiv=CreateDiv(parentobj.PanelObj, this.Hid);
	} else {
		this.Locsize=new QlocSize(this.Location, this.Size, null);
		var wdiv=CreateDiv(document.body, this.Hid);
	}
	wdiv.style.overflow="hidden";
	this.Locsize.Resize(wdiv);
	this.Hobj=wdiv;
	this.PanelObj=wdiv;
	this.StyleObj=parentobj.GetStyle(this.Style, this.Tipo);
	this.Frame=new Qframe(this);
	wdiv.onmouseover=EvtMouseOver;
	wdiv.onmouseout=EvtMouseOut;
	if (this.Popup == "S") wdiv.style.display="none";
	if (this.Pin != "") {
		wpin=document.createElement("IMG");
		wpin.id=wdiv.id + "._.PIN";
		wpin.style.position="absolute";
		wpin.style.top="4px";
		wpin.style.left=(this.Locsize.ObjW - 20) + "px";
		if (this.Pin == "ON") {
			wpin.src=GetImageAddress("pinon.gif");
		} else {
			wpin.src=GetImageAddress("pinoff.gif");
		}
		wpin.style.cursor="pointer";
		wdiv.appendChild(wpin);
		wpin.style.zIndex="1";
		this.Hpin=wpin;
		wpin.onclick=EvtClick;
	}
}

Qarea.prototype.Resize=function(opt) {
	if (opt == "ANIM") return
	this.Locsize.Resize(this.PanelObj);
	this.Frame.Resize();
	if (this.Hpin != undefined) this.Hpin.style.left=(this.Locsize.ObjW - 20) + "px";
	if (this.ActivePage != null) this.ActivePage.Resize();
	if (this.BackPage != null && this.Pages.length == 0) this.BackPage.Resize();
	if (this.Locsize.RefH == "R" && this.CanExpand == "S") {
		this.Locsize.UnScrollH(this.Hobj)
		if (this.Locsize.OffH < 0) {
			this.Hobj.style.height=(this.Locsize.ObjH - this.Locsize.OffH) + "px"
		} 
		this.Frame.Resize()
		App.Expand(-this.Locsize.OffH)
	}
}

Qarea.prototype.GetPageIndex=function(pageid) {
	for (var i=0; i<this.Pages.length; i++) {
		if (this.Pages[i].Id == pageid) return i;
	}
	return -1;
}

Qarea.prototype.Execute=function(act) {
	if (act == "MouseOver") {
		if (this.MouseIsOver == false) return;
		if (this.IsBusy == true) return;
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "MOUSEENTER") {
				if (this.Events[i].Act != "") ExecCmd(this, this.Events[i].Act);
			}
		}
		return;
	}
	if (act == "MouseOut") {
		if (this.MouseIsOver == true) return;
		if (this.IsBusy == true) return;
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "MOUSELEAVE") {
				if (this.Events[i].Act != "") ExecCmd(this, this.Events[i].Act);
			}
		}
		return;
	}
}

Qarea.prototype.Expand=function(nheight) {   //expandir a AREA na vertical para o tamanho especificado
	this.Locsize.UnScrollH(this.Hobj);
	if (this.Locsize.ObjH >= nheight) return;
	var oldheight=this.Locsize.ObjH;
	var Aw=this.Size.split(",");
	if (this.AbsCoord == "N") {
		this.Locsize=new QlocSize(this.Location, Aw[0] + "," + nheight, this.ParentObj);
	} else {
		this.Hobj.style.height=(this.Locsize.ObjH - this.Locsize.OffH) + "px"
		this.Locsize=new QlocSize(this.Location, Aw[0] + "," + nheight, null);
	}
	this.Resize();
	this.Frame.Resize();
	if (App.CanExpand == "S") {
		App.Expand(this, nheight, oldheight)
	}
}

Qarea.prototype.ResetExpand=function() {   //repor a AREA do tamanho especificado nos parametros da aplicação
	if (this.AbsCoord == "N") {
		this.Locsize=new QlocSize(this.Location, this.Size, this.ParentObj);
	} else {
		this.Locsize=new QlocSize(this.Location, this.Size, null);
	}
	App.ResetExpand();
	this.Resize();
}
	
Qarea.prototype.AltSize=function(nwidth, nheight, opt) {
	if (this.IsBusy == true) return;
	this.IsBusy=true;
	var wlocsize=new QlocSize(this.Locsize.ObjL + "," + this.Locsize.ObjT, nwidth + "," + nheight, this.ParentObj);
	wlocsize.Resize();
	if (wlocsize.ObjW == this.Locsize.ObjW && wlocsize.ObjH == this.Locsize.ObjH) {
		this.IsBusy=false;
		return;
	}
	if (opt == "NOANIM") {
		this.Locsize.ObjW=wlocsize.ObjW;
		this.Locsize.ObjH=wlocsize.ObjH;
		this.Hobj.style.width=this.Locsize.ObjW + "px";
		this.Hobj.style.height=this.Locsize.ObjH + "px";
		this.Frame.Resize();
		this.AltSize2();
		return;
	}
	this.Size=nwidth + "," + nheight

	var wanim=new Qanimator(this, "MOVE", "LINEAR,10,N", this.Locsize.ObjL, this.Locsize.ObjT, wlocsize.ObjW, wlocsize.ObjH);
	wanim.Activate(this.AltSize2);
}

Qarea.prototype.AltSize2=function() {
	if (this.Hpin != undefined) this.Hpin.style.left=(this.Locsize.ObjW - 20) + "px";
	if (this.ActivePage != null) this.ActivePage.Resize();
	if (this.Pages.length == 0 && this.BackPage != null) this.BackPage.Resize();
	this.Locsize=new QlocSize(this.Location, this.Size, this.ParentObj);
	this.Locsize.Resize();
	this.IsBusy=false;
}
	
Qarea.prototype.AltLocation=function(nleft, ntop, opt) {
	if (this.IsBusy == true) return;
	this.IsBusy=true;
	var wlocsize=new QlocSize(nleft + "," + ntop, this.Size, this.ParentObj);
	wlocsize.Resize();
	if (wlocsize.ObjL == this.Locsize.ObjL && wlocsize.ObjT == this.Locsize.ObjT) {
		this.IsBusy=false;
		return;
	}
	if (opt == "NOANIM") {
		this.Locsize.ObjL=wlocsize.ObjL;
		this.Locsize.ObjT=wlocsize.ObjT;
		this.Hobj.style.left=this.Locsize.ObjL + "px";
		this.Hobj.style.top=this.Locsize.ObjT + "px";
		this.Frame.Resize();
		this.AltLocation2();
		return;
	}
	this.Location=nleft + "," + ntop
	var wanim=new Qanimator(this, "MOVE", "LINEAR,10,0,N", wlocsize.ObjL, wlocsize.ObjT, wlocsize.ObjW, wlocsize.ObjH);
	wanim.Activate(this.AltLocation2);
}

Qarea.prototype.AltLocation2=function() {
	if (this.ActivePage != null) this.ActivePage.Resize();
	if (this.Pages.length == 0 && this.BackPage != null) this.BackPage.Resize();
	this.Locsize=new QlocSize(this.Location, this.Size, this.ParentObj);
	this.Locsize.Resize();
	this.IsBusy=false;
}

Qarea.prototype.Hide=function() {
	this.Hobj.style.display="none";
}

Qarea.prototype.Show=function() {
	this.Hobj.style.display="block";
}

Qarea.prototype.Disable=function(tipo) {
	this.Disabled=true;
	if (this.ActivePage != null) this.ActivePage.Disable(tipo);
}

Qarea.prototype.Enable=function(tipo) {
	this.Disabled=false;
	if (this.ActivePage != null) this.ActivePage.Enable(tipo);
}
	
Qarea.prototype.Destroy=function() {
	if (this.ActivePage != null) CloseAllPages(this);
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Destroy();
	}
	var wparent=this.Hobj.parentNode;
	if (wparent != null) wparent.removeChild(this.Hobj);
}

Qarea.prototype.OnMouseOver=function() {
	if (this.MouseIsOver == true) return;
	this.MouseIsOver=true;
	ExecCmdDelayed(200, this, "ExecuteInternal(" + this.Id + ",MouseOver");
}

Qarea.prototype.OnMouseOut=function() {
	if (this.MouseIsOver == false) return;
	this.MouseIsOver=false;
	ExecCmdDelayed(200, this, "ExecuteInternal(" + this.Id + ",MouseOut");
}

Qarea.prototype.OnClick=function(id) {
	if (id.indexOf("._.PIN") == -1) return;
	if (this.Pin == "ON") {
		this.Pin = "OFF";
		this.Hpin.src=GetImageAddress("pinoff.gif");
	} else {
		this.Pin = "ON";
		this.Hpin.src=GetImageAddress("pinon.gif");
	}
}


//***************************************************************** QWINDOW - define Window
function Qwindow(hostpanel, modulo, xnod) {
	this.HostPage=this;
	this.HostPanel=hostpanel;
	this.TabIndexBase=(App.Areas.length + 1) * 1000
	this.Tipo="WINDOW";
	this.Class="AREA";
	this.Id=GetAtt(xnod, "ID", "");
	if (this.Id == "") this.Id="Window" + App.Areas.length;
	App.Areas.push(this);
	this.Hid=this.Id;
	this.AbsCoord=GetAtt(xnod, "ABSCOORD", "N");
	if (this.AbsCoord == "S") {
		this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "400,300"), null);
	} else {
		this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "400,300"), hostpanel);
	}
	this.AnchorArea=GetAtt(xnod, "ANCHORAREA", "");
	if (this.AnchorArea != "") {
		var warea=App.GetArea(this.AnchorArea);
		if (warea != null) {
			var wx=warea.Locsize.ObjL;
			var wy=warea.Locsize.ObjT;
			this.Locsize.OffL += wx;
			this.Locsize.OffT += wy;	
		}
	}
	
	
	if (hostpanel.Tipo == "WINPANEL") {
		hostpanel.Actls.push(this);
		if (this.HostPanel.WindowW != "*") this.Locsize.OffW=this.HostPanel.WindowW;
		if (this.HostPanel.WindowH != "*") this.Locsize.OffH=this.HostPanel.WindowH;
		this.Locsize.OffL=this.HostPanel.WindowX;
		this.Locsize.OffT=this.HostPanel.WindowY;
	}
	this.Style=GetAtt(xnod, "STYLE", "DEFAULT");
	this.Actls=new Array();
	this.Area=this;
	this.Pages=new Array();
	this.ActivePage=null;
	this.BackPage=null;
	this.Historial=new Array();
	this.ReturnValue="";
	this.Modulo=modulo;
	this.Popup="N";
	this.Dialogs=0;
	this.Nivseg="0-99";
	this.Minimized=false;
	this.Start="";
	if (this.AbsCoord == "S") {
		var wdiv=CreateDiv(document.body, this.Hid);
	} else {
		var wdiv=CreateDiv(hostpanel.PanelObj, this.Hid);
	}
	wdiv.style.display="none";
	wdiv.style.overflow="hidden";
	wdiv.style.zIndex=1;
	this.Locsize.Resize(wdiv);
	this.Hobj=wdiv;
	this.PanelObj=wdiv;
	this.StyleObj=App.GetStyle(this.Style, this.Tipo);
	this.Frame=new Qframe(this);
	this.Modal=GetAtt(xnod, "MODAL", "N");
	this.Context=GetAtt(xnod, "CONTEXT", "N");
	this.ShowCaption=GetAtt(xnod, "CAPTION", "N");
	this.Minbot=GetAtt(xnod, "MINBUTTON", "S");
	this.Closebot=GetAtt(xnod, "CLOSEBUTTON", "S");
	this.AllowResize=GetAtt(xnod, "ALLOWRESIZE", "N");
	this.MinSize=GetAtt(xnod, "MINSIZE", "40,40");
	this.MaxSize=GetAtt(xnod, "MAXSIZE", "1000,1000");
	this.SaveInUrl=GetAtt(xnod, "SAVEINURL", "N");
	var Aw=this.MinSize.split(",");
	this.MinWidth=Number(Aw[0]);
	this.MinHeight=Number(Aw[1]);
	Aw=this.MaxSize.split(",");
	this.MaxWidth=Number(Aw[0]);
	this.MaxHeight=Number(Aw[1]);
	this.Caption=null;
	this.Resizer=null;
	this.IniWidth=this.Locsize.ObjW;
	this.IniHeight=this.Locsize.ObjH;
	this.MoseIsOver=false;

	if (this.ShowCaption == "S" || this.ShowCaption == "OVER") {
		var xstr="<WINCAP ";
		if (this.ShowCaption == "OVER") xstr += "VIS=\"N\" ";
		xstr += ">";
		if (this.Closebot == "S") {
			xstr += "<BOTAO ID=\"Botclose\" LOCATION=\"*-24,0\" SIZE=\"16,16\" ACT=\"CloseWindow(\" STYLE=\"BCLOSE\"/>";
		}
		if (this.Minbot == "S") {
			xstr += "<BOTAO ID=\"Botmin\" LOCATION=\"*-44,0\" SIZE=\"16,16\" ACT=\"MinimizeWindow(\" STYLE=\"BMINIMIZE\"/>";
			xstr += "<BOTAO ID=\"Botrest\" LOCATION=\"*-44,0\" SIZE=\"16,16\" ACT=\"RestoreWindow\" VIS=\"N\" STYLE=\"BRESTORE\"/>";
		}
		xstr += "</WINCAP>";
		var xnod=CreateXnode(xstr);
		this.Caption=new Qwincap(xnod, this);
		this.Actls.push(this.Caption);
	}
	if (this.AllowResize == "S") {
		this.Resizer=new Qwinresizer(null, this);
		this.Actls.push(this.Resizer);
	}
	if (this.HostPanel.Tipo == "WINPANEL") this.HostPanel.Rearange();
}

Qwindow.prototype.Resize=function(opt) {
	if (opt == "appresize") {
		if (this.Locsize.Resizable == true) this.Locsize.Resize(this.Hobj)
	}
}

Qwindow.prototype.Animate=function(newleft, newtop, newwidth, newheight, nframes) {
	var w=this.Locsize.ObjW;
	var h=this.Locsize.ObjH;
	var x=this.Locsize.ObjL;
	var y=this.Locsize.ObjT;
	if (newleft != "") x=newleft;
	if (newtop != "") y=newtop;
	if (newwidth != "") w=newwidth;
	if (newheight != "") h=newheight;
	//criar um locsize para quando os valores não são absolutos (Ex: *-10)
	if (this.AbsCoord == "S") {
		wlocsize=new QlocSize(x + "," + y, w + "," + h, null);
	} else {
		wlocsize=new QlocSize(x + "," + y, w + "," + h, this.HostPanel);
	}
	wlocsize.Resize()
	x=wlocsize.ObjL
	y=wlocsize.ObjT
	w=wlocsize.ObjW
	h=wlocsize.ObjH
	if (this.HostPanel.Tipo == "WINPANEL") {
		if (this.HostPanel.Orientation == "V") {
			if (this.HostPanel.WindowW != "*") w=this.HostPanel.WindowW;
			x=this.HostPanel.WindowX;
		} else {
			if (this.HostPanel.WindowH != "*") h=this.HostPanel.WindowH;
			y=this.HostPanel.WindowY;
		}
	}
	var numframes=0;
	if (nframes != undefined) numframes=nframes;
	var wanim=new Qanimator(this, "MOVE", "LINEAR," + numframes + ",0,N", x, y, w, h, "");
	if (this.HostPanel.Tipo == "WINPANEL") this.HostPanel.Rearange();
	wanim.Activate(this.Animate2);
}

Qwindow.prototype.Animate2=function() {
	if (this.Caption != null) {
		this.Caption.Resize();
		this.Caption.RefreshWindowState();
	}
	if (this.Resizer != null) {
		this.Resizer.Resize();
	}
	if (this.ActivePage != null) this.ActivePage.Resize();
}

Qwindow.prototype.Relocate=function(wleft, wtop) {
	//this.Resize(wleft, wtop, 10);
}

Qwindow.prototype.Activate=function(opt) {
	this.GotFocus();
	this.Show("INIT");
	if (this.Modal == "S") ExecCmdDelayed(100, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",SetModal");
}

Qwindow.prototype.Activate2=function(opt) {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Activate("INIT");
	}
}

Qwindow.prototype.GetPageIndex=function(pageid) {
	for (var i=0; i<this.Pages.length; i++) {
		if (this.Pages[i].Id == pageid) return i;
	}
	return -1;
}

Qwindow.prototype.GetHash=function() {
	var str="OW(,,,,,,«ID=" + this.Id + "|CAPTION=" + this.ShowCaption + "|MINBUTTON=" + this.Minbot + "|CLOSEBUTTON=" + this.Closebot + "|CONTEXT=" + this.Context;
	str += "|MODAL=" + this.Modal + "|ALLOWRESIZE=" + this.AllowResize + "|MINSIZE=" + this.MinSize + "|MAXSIZE=" + this.MaxSize;
	str += "|STYLE=" + this.Style + "|SAVEINURL=" + this.SaveInUrl + "»{";
	return str
}

Qwindow.prototype.Minimize=function() {
	this.IniWidth=this.Locsize.ObjW;
	this.IniHeight=this.Locsize.ObjH;
	this.Animate("", "", this.MinWidth, this.MinHeight, 12);
	this.Minimized=true;
}

Qwindow.prototype.Restore=function() {
	this.Animate("", "", this.IniWidth, this.IniHeight, 12);
	this.Minimized=false;
}

Qwindow.prototype.AltSize=function(w, h) {
	this.Animate("", "", w, h, 2)
}

Qwindow.prototype.AltLocation=function(l, t) {
	this.Animate(l, t, "", "", 2)
}

Qwindow.prototype.Execute=function(act) {
	if (act == "Minimize") {
		this.Minimize();
		return;
	}
	if (act == "Restore") {
		this.Restore();
		return;
	}
	if (act == "Close") {
		this.Destroy();
		return;
	}
	if (act == "SetModal") {
		App.DisableForPopup(this, "MODALWINDOW");
		return;
	}
	if (act == "MouseOut") {
		if (this.MouseIsOver == false) this.Destroy();
		return;
	}
}

Qwindow.prototype.Show=function(opt) {
	var wanim=new Qanimator(this, "IN", this.StyleObj.AnimIn);
	if (opt == "INIT") {
		wanim.Activate(this.Activate2);
		return;
	}
	wanim.Activate();
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i].Show();
	}
}

Qwindow.prototype.Hide=function(opt) {
	if (opt == "DESTROY") {
		if (this.ActivePage != null) this.ActivePage.Destroy();
	}
	for (var i=this.Actls.length-1; i>=0; i--) {
		if (opt == "DESTROY") {
			this.Actls[i].Destroy();
		} else {
			this.Actls[i].Hide();
		}
	}
	var wanim=new Qanimator(this, "OUT", this.StyleObj.AnimOut);
	if (opt == "DESTROY") {
		wanim.Activate(this.Destroy2);
		return;
	} else {
		wanim.Activate();
	}
}

Qwindow.prototype.Destroy=function() {
	if (this.ActivePage != null) CloseAllPages(this);
	this.Hide("DESTROY");
}

Qwindow.prototype.Destroy2=function() {
	if (this.HostPanel != App) {
		for (var i=0; i<this.HostPanel.Actls.length; i++) {
			if (this.HostPanel.Actls[i].Id == this. Id) {
				this.HostPanel.Actls.splice(i,1);
				break;
			}
		}
	}
	for (var i=0; i<App.Areas.length; i++) {
		if (App.Areas[i].Id == this. Id) {
			App.Areas.splice(i,1);
			break;
		}
	}
	var wparent=this.Hobj.parentNode;
	if (wparent != null) wparent.removeChild(this.Hobj);
	if (this.Modal == "S") App.EnableForPopup(this, "MODALWINDOW");
	if (this.HostPanel.Tipo == "WINPANEL") this.HostPanel.Rearange();
}

Qwindow.prototype.OnMouseOver=function(id, hnod, wx, wy) {
	this.MouseIsOver=true;
	if (this.ShowCaption == "OVER") {
		if (this.Caption.Visible == false) this.Caption.Show();
	}
	if (this.Resizer != null) this.Resizer.SetState("HIGH");
}

Qwindow.prototype.OnMouseOut=function() {
	this.MouseIsOver=false;
	if (this.ShowCaption == "OVER") {
		if (this.Caption.Visible == true) this.Caption.Hide();
	}
	if (this.Resizer != null) this.Resizer.SetState("NORM");
	if (this.Context == "S") {
		ExecCmdDelayed(400, this, "ExecuteInternal(" + this.Id + ",MouseOut")  //esperar um pouco e testar de novo se o rato está fora
	}
}

Qwindow.prototype.CapMouseDown=function(wx, wy) {
	this.Offsetx = wx;
	this.Offsety = wy;
	this.TypeOfMove="CAPTION"
	CtlMouse=this;
	document.onselectstart=function() {return false}  //evitar que se seleccione texto
}

Qwindow.prototype.ResizeMouseDown=function(wx, wy) {
	this.Offsetx = wx;
	this.Offsety = wy;
	this.TypeOfMove="RESIZER"
	CtlMouse=this;
	document.onselectstart=function() {return false}  //evitar que se seleccione texto
}

Qwindow.prototype.MouseUp=function() {
	if (this.Caption != null) this.Caption.MouseUp();
	if (this.HostPanel.Tipo == "WINPANEL") this.HostPanel.Rearange();
	document.onselectstart=function() {return true}  //deixar que se seleccione texto
}

Qwindow.prototype.MouseMove=function(wx, wy) {
	var offx=0;
	var offy=0;
	if (this.HostPanel != App) {
		var offset=GetOffsetFor("APP", this.HostPanel);
		offx=offset.Left;
		offy=offset.Top;
	}
	if (this.TypeOfMove == "CAPTION") {
		if (this.AbsCoord == "N") {
			var wleft=wx - this.Offsetx - offx - App.Locsize.ObjL;
			var wtop=wy - this.Offsety - offy - App.Locsize.ObjT;
			var maxleft = this.HostPanel.Locsize.ObjW - this.Locsize.ObjW;
			var maxtop = this.HostPanel.Locsize.ObjH - this.Locsize.ObjH;
		} else {
			var dims=GetDocDims();
			var wleft=wx - this.Offsetx - offx;
			var wtop=wy - this.Offsety - offy;
			var maxleft = dims[0] - this.Locsize.ObjW;
			var maxtop = dims[1] - this.Locsize.ObjH;
		}
		if (wleft < 0) wleft=0;
		if (wtop < 0) wtop=0;
		if (wleft > maxleft) wleft=maxleft;
		if (wtop > maxtop) wtop=maxtop;
		this.Locsize.ObjL=wleft;
		this.Locsize.ObjT=wtop;
		this.Hobj.style.left = wleft + "px";
		this.Hobj.style.top = wtop + "px";
		return
	}
	if (this.TypeOfMove == "RESIZER") {
		var x=wx - this.Offsetx - offx + 20;
		var y=wy - this.Offsety - offy + 20;
		if (this.AbsCoord == "N") {
			var wwidth=x - this.HostPanel.Locsize.ObjL - this.Locsize.ObjL;
			var wheight=y - this.HostPanel.Locsize.ObjT - this.Locsize.ObjT;
		} else {
			var wwidth=x - this.Locsize.ObjL;
			var wheight=y - this.Locsize.ObjT;
		}
		if (wwidth < this.MinWidth) wwidth=this.MinWidth;
		if (wwidth > this.MaxWidth) wwidth=this.MaxWidth;
		if (wheight < this.MinHeight) wheight=this.MinHeight;
		if (wheight > this.MaxHeight) wheight=this.MaxHeight;
		this.Locsize.ObjW=wwidth;
		this.Locsize.ObjH=wheight;
		this.IniWidth=wwidth;
		this.IniHeight=wheight;
		this.Minimized=false;
		this.Hobj.style.width = wwidth + "px";
		this.Hobj.style.height = wheight + "px";
		this.Frame.Resize()
		this.Animate2()
		return
	}
}

Qwindow.prototype.GotFocus=function() {
	var Areas=App.Areas;
	if (this.HostPanel != App) Areas=this.HostPanel.Actls;
	for (var i=0; i<Areas.length; i++) {
		var warea=Areas[i];
		if (warea.Tipo == "WINDOW" && warea.Id != this. Id) {
			warea.PanelObj.style.zIndex=1;
		}
	}
	this.PanelObj.style.zIndex=2;
}



//***************************************************************** QPAGE - define Página de aplicação
function Qpage(xnod, area, func, key, cond, tipo) {
	this.Xnod=xnod;
	if (tipo == "" || tipo == undefined) {
		this.Tipo="PAGE";
	} else {
		this.Tipo=tipo;
	}
	this.Class="PAGE";
	App.BlockAllInput("PAGE");
	this.Actls=new Array();
	this.Area=area;
	this.HostPanel=area;
	this.ParentObj=area;
	this.TabIndexBase=area.TabIndexBase
	this.Id=GetAtt(xnod, "ID", "");
	if (this.Id == "") this.Id="page" + area.Actls.length;
	App.AddCmdLog("*-- New Page Id='" + this.Id + "' opened in '" + this.Area.Id + "'");
	this.Hid=area.Hid + "." + this.Id;
	this.Tit=GetAtt(xnod, "TIT", "?");
	this.Style=GetAtt(xnod, "STYLE", "DEFAULT");
	//this.Locsize=new QlocSize("0,0", "*,*", area);
	this.Scroll=GetAtt(xnod, "SCROLL", "N");
	this.Url=GetAtt(xnod, "URL", "");
	this.UpdateStatus=GetAtt(xnod, "UPDSTATUS", "S");
	this.Tema="";
	this.Temasize="";
	this.Func=func;
	this.FuncIni=func; //para o caso de INS_REP
	if (this.Func == "INS_REP") this.Func="INS";
	this.Key=key;
	this.Cond=cond;
	this.Modulo=area.Modulo;
	this.CallerCtl="";
	this.DidUpdate="";
	this.UpdatePending=false;
	this.Log=new Array();
	this.Events=new Array();
	this.FirstPanel="";
	this.CtlCount=0;
	this.Offsetx=0;
	this.Offsety=0;
	this.MouseDown=false;
	this.Time=Agora().getTime();
	this.BlkComArray=new Array;
	this.LastWarning="";
	this.LastWarningTime=0;
	this.InitialFocusSet=false;
	this.LastFocusCtl=null;
	this.Disabled=false;
	this.Activated=false;
	this.Visible=false;
	if (area.Popup == "S") area.Show();
	if (this.Tipo == "POPUPDIALOG") {
		this.Locsize=new QlocSize("0,0", "*,*", App);
		var wpanelobj=App.PanelObj;
	} else {
		this.Locsize=new QlocSize("0,0", "*,*", area);
		var wpanelobj=area.PanelObj;
	}
	var wdiv=CreateDiv(wpanelobj, this.Hid);
	this.Locsize.Resize(wdiv);
	this.Hobj=wdiv;
	this.PanelObj=wdiv;
	wdiv.style.display="none";
	this.Tipo4Style=this.Tipo;
	if (this.Tipo == "POPUPDIALOG") this.Tipo4Style="DIALOG"
	this.StyleObj=App.GetStyle(this.Style, this.Tipo4Style);
	this.Frame=new Qframe(this);
	if (this.Scroll == "S") {
		wdiv.style.overflow="auto";
	} else {
		wdiv.style.overflow="hidden";
	}
	wdiv.onmouseover=EvtMouseOver
	//wdiv.onmousedown=EvtMouseDown;
	wdiv.onscroll=EvtScroll;

	var xn=xnod.firstChild;
	while (xn!=undefined) {
		switch(xn.nodeName) {
			case "PANEL":
				wctl=new Qpanel(xn, this, this);
				// o this.Actls.push(wctl) é feito no proprio panel
				break;
			case "FORM":
				wctl=new Qform(xn, this);
				this.Actls.push(wctl);
				break;
			case "DBEDIT":
				window.alert(GetMsg(1, "O DBEDIT não é suportado em Qweb3 - deve usar MULTIFORM"));
				break;
			case "LEDIT":
				wctl=new Qledit(xn, this);
				this.Actls.push(wctl);
				break;
			case "LEDITM":
				wctl=new Qleditm(xn, this);
				this.Actls.push(wctl);
				break;
			case "DBPAGER":
				wctl=new Qdbpager(xn, this);
				this.Actls.push(wctl);
				break;
			case "ROTINA":
				wctl=new Qrotina(xn, this);
				this.Actls.push(wctl);
				break;
			case "VARVAL":
				wctl=new Qvarval(xn, this);
				this.Actls.push(wctl);
				break;
			case "MULTIFORM":
				wctl=new Qmultiform(xn, this);
				this.Actls.push(wctl);
				break;
			case "MENUSRC":
				wctl=new Qmenusrc(xn, this);
				this.Actls.push(wctl);
				break;
			case "TREESRC":
				wctl=new Qtreesrc(xn, this);
				this.Actls.push(wctl);
				break;
			case "EVENT":
				var wevent=new Qevent(xn);
				this.Events.push(wevent);
				break;
			case "WINPANEL":
				wctl=new Qwinpanel(xn, this, this);
				this.Actls.push(wctl);
				break;
			case "SEARCH":
				wctl=new Qsearch(xn, this, this);
				this.Actls.push(wctl);
				break;
		}
		xn=xn.nextSibling;
	}
	if (this.Tipo == "DIALOG") {
		this.Area.Dialogs ++;
		if (this.FirstPanel.LocationDialog != "") {
			var wlocsize=new QlocSize(this.FirstPanel.LocationDialog, "10,10", area);
			this.Locsize.RefL=wlocsize.RefL;
			this.Locsize.OffL=wlocsize.OffL;
			this.Locsize.RefT=wlocsize.RefT;
			this.Locsize.OffT=wlocsize.OffT;
			wlocsize=null
		} else {
			this.Locsize.RefL="L";
			this.Locsize.OffL=this.Area.Dialogs * 30;
			this.Locsize.RefT="T";
			this.Locsize.OffT=this.Area.Dialogs * 30;
		}
		this.Locsize.RefW="A";
		this.Locsize.OffW=this.FirstPanel.Locsize.ObjW + this.Locsize.MargL + this.Locsize.MargR;
		this.Locsize.RefH="A";
		this.Locsize.OffH=this.FirstPanel.Locsize.ObjH + this.Locsize.MargT + this.Locsize.MargB + 10;
		this.Locsize.Resize(wdiv);

		
		var maxwidth = this.Area.Locsize.ObjW - this.Locsize.OffL;
		var maxheight = this.Area.Locsize.ObjH - this.Locsize.OffT;
		wdiv.style.overflow="hidden";
		var resized="";
		if (this.Locsize.OffW > maxwidth) {
			resized += "W";
			this.Locsize.OffW = maxwidth - 5;
			if (maxheight > (this.Locsize.OffH + 18)) this.Locsize.OffH = this.Locsize.OffH + 18;
		}
		if (this.Locsize.OffH > maxheight) {
			resized += "H";
			this.Locsize.OffH = maxheight - 5;
			if (maxwidth > (this.Locsize.OffW + 18)) this.Locsize.OffW = this.Locsize.OffW + 18;
		}
		if (resized != "") {
			this.FirstPanel.Scroll="S";
			this.FirstPanel.Hobj.style.overflow="auto";
			this.FirstPanel.Locsize.OffW = this.Locsize.OffW - this.Locsize.MargL - this.Locsize.MargR;
			this.FirstPanel.Locsize.OffH = this.Locsize.OffH - this.Locsize.MargT - this.Locsize.MargB;

			if (BrowserIE == true && navigator.appVersion.indexOf("MSIE 9.0") > -1) {  //bug do IE9 com o scrolling
				if (resized == "H") {
					this.FirstPanel.Locsize.OffW  += 18;
					this.FirstPanel.Locsize.OffH  += 18;
				} else {
					if (resized == "W") {
						this.FirstPanel.Locsize.OffH  += 18;
					} else {
						this.FirstPanel.Locsize.OffW  += 18;
						this.FirstPanel.Locsize.OffH  += 18;
					}
				}
			}
		}
		this.Locsize.Resize(wdiv);
		this.Frame.Resize();
		wdiv.style.zIndex="1";
		this.FirstPanel.Resize();
	}
	if (this.Tipo == "POPUPDIALOG") {
		if (this.FirstPanel.LocationDialog != "") {
			var wlocsize=new QlocSize(this.FirstPanel.LocationDialog, "10,10", App);
			this.Locsize.RefL=wlocsize.RefL;
			this.Locsize.OffL=wlocsize.OffL;
			this.Locsize.RefT=wlocsize.RefT;
			this.Locsize.OffT=wlocsize.OffT;
			wlocsize=null
		} else {
			this.Locsize.RefL="L";
			this.Locsize.OffL=0;
			this.Locsize.RefT="T";
			this.Locsize.OffT=0;
		}
		this.Locsize.RefW="A";
		this.Locsize.OffW=this.FirstPanel.Locsize.ObjW + this.Locsize.MargL + this.Locsize.MargR;
		this.Locsize.RefH="A";
		this.Locsize.OffH=this.FirstPanel.Locsize.ObjH + this.Locsize.MargT + this.Locsize.MargB + 10;
		this.Locsize.Resize(wdiv);
		this.Frame.Resize();
		wdiv.style.zIndex="1";
	}
	if (this.Tipo == "DIALOG" || this.Tipo == "POPUPDIALOG") {
		var xstr="<WINCAP ";
		xstr += "VIS=\"S\"/>";
		var xnod=CreateXnode(xstr);
		this.Caption=new Qwincap(xnod, this);
		this.Actls.push(this.Caption);
	}
	//this.Resize()
}

Qpage.prototype.GetCtl=function(id) {   //******* Obter o objecto desta pagina cujo Id é fornecido
	return GetCtlChild(this, id);
}

Qpage.prototype.GetCtlChild=function(ctl, id) {   //******* Procurar o objecto na hierarquia
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	for (var i=0; i<ctl.Actls.length; i++) {
		if (ctl.Actls[i].Id == id) return this.Actls[i];
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=this.GetCtlChild(ctl.Actls[i], id);
		if (wctl != null) return wctl;
	}
	return null;
}

Qpage.prototype.GetTipoPag=function() {   //******* Saber qual o tipo de pagina se FROM ou MULTIFORM
	var firstform=-1;
	var firstdbedit=-1;
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Tipo == "FORM") firstform = i;
		if (this.Actls[i].Tipo == "MULTIFORM") firstdbedit = i;
	}
	if (firstdbedit == -1) return "FORM";
	if (firstform != -1) {
		if (this.Actls[firstform].Provider != "*") {
			return "FORM";
		} else {
			if (firstdbedit > firstform) {
				return "FORM";
			} else {
				return "MULTIFORM";
			}
		}  
	} else {
		return "MULTIFORM";
	}
}

Qpage.prototype.Activate=function() {
	var now=Agora();
	this.Time=now.getTime() - this.Time;
	//verificar evento BEFOREACTIVATE
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == "BEFOREACTIVATE") {
			ExecCmd(this.Area, this.Events[i].Act);
		}	
	}
	this.HasSkipNiv=false
	//resolver controlos limitados por outros
	var foundfirstdatactl=false
	for (var i=0; i<this.Actls.length; i++) {
		var wctl=this.Actls[i];
		if (wctl.Class == "DATA") {
			if (foundfirstdatactl == false) {  //marcar o controlo como sendo o primeiro datactl da pagina e como tal supostamente o principal
				wctl.FirstDataCtl=true
				foundfirstdatactl=true
			}
			if (wctl.Tipo == "MULTIFORM") {
				if (wctl.Skipniv != "" && wctl.Autostart == "S") this.HasSkipNiv=true;  // verificar se existe algum MULTIFORM com SkipNiv preenchido
			}
			for (var c=0; c<wctl.Limiterctls.length; c++) {
				var lctl=this.GetCtl(wctl.Limiterctls[c]);
				if (lctl != null) {
					lctl.Limitedctls.push(wctl);
				} else {
					window.alert(GetMsg(1, "O controlo (" + wctl.Id + ") está a ser limitado por um controlo (" + wctl.Limiterctls[c] + ") inexistente"));
				}
			}
			if (wctl.Tipo == "LEDIT") {
				if (wctl.DatactlObj.Tipo == "FORM") wctl.AddNoFieldUnit();
			}
		}
	}
	if (this.HasSkipNiv == true) {  //quando ha skipniv o multiform emite um ActivateCtls()
		this.ActivateDados()
	} else {
		this.ActivateCtls();
	}
}

Qpage.prototype.ActivateCtls=function() {
	if (this.Activated == true) return;
	this.Activated=true;
	this.Show("INIT");
}

Qpage.prototype.Activate2=function() {
	for (var i=0; i<this.Actls.length; i++) {
		var wctl=this.Actls[i];
		if (wctl != null && wctl.Class == "PANEL") {
			if (this.InitialFocusSet == false) {
				var wictl=GetFirstInputField(wctl)
				if (wictl != null) {
					this.InitialFocusSet=true
					wictl.InitialFocus="S"
				}
			}
			wctl.Activate("INIT");
		}
	}
	if (this.HasSkipNiv == false) this.ActivateDados();
	App.UnBlockAllInput();
	//this.Resize();
}

Qpage.prototype.ActivateDados=function() {
	for (var i=0; i<this.Actls.length; i++) {
		var wctl=this.Actls[i];
		if (wctl.Class == "DATA") {
			if (wctl.Tipo == "FORM") {
				if (wctl.Limiterctls.length == 0 && wctl.Autostart != "N") wctl.Activate("INIT");
			} else {
				if (wctl.Tipo == "MULTIFORM" || wctl.Tipo == "TREESRC") {
					wctl.VerifBotoes("INIT");
					for (j=0; j<wctl.Limiterctls.length; j++) {
						var lctl = this.GetCtl(wctl.Limiterctls[j]);
						if (lctl.Tipo == "FORM" && (lctl.HostFunc == "VIS" || lctl.HostFunc == "ELI")) {
							wctl.DisableBotoesUpdate();
							break;
						}	
					}
					if (wctl.Limiterctls.length == 0 && wctl.Autostart != "N") wctl.Activate();
				} else {
					if (wctl.Tipo == "LEDIT") {
						wctl.VerifBotoes();
					} else {
						wctl.Activate("INIT");
					}
				}
			}
		}
	}
	App.BlockAllInput("PAGE");
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == "AFTERACTIVATE") {
			ExecCmd(this.Area, this.Events[i].Act);
		}
		if (this.Events[i].Id == "ONINTERVAL") {
			ExecCmdDelayed(Number(this.Events[i].Valor), this.Area, "Execute(" + this.Id + ",ONINTERVAL", this.Id);
		}
	}
}

Qpage.prototype.Resize=function() {
	if (this.Tipo == "DIALOG" || this.Tipo == "POPUPDIALOG") return;
	this.Locsize.Resize(this.PanelObj);
	this.Frame.Resize();
	for (var i=0; i<this.Actls.length; i++) {
		var wctl=this.Actls[i];
		if (wctl.Class == "PANEL") {
			if (wctl.Locsize.Resizable == true) wctl.Resize();
			if (this.Scroll == "S") GenericDisplayCtl_TestScrollIE.call(this, wctl)
		}
	}
	if (this.Locsize.RefH == "R" && this.Area.CanExpand == "S") {
	if (this.FirstPanel.Locsize.ObjH > this.Locsize.ObjH) {
			this.Locsize.UnScrollH(this.Hobj)
			this.Locsize.OffH=this.FirstPanel.Locsize.ObjH
			this.Locsize.RefH="A"
			this.Locsize.Resize(this.PanelObj);
			this.Locsize.UnScrollH(this.Hobj)
			this.Frame.Resize();
			this.Area.Expand(this.FirstPanel.Locsize.ObjH)
		}
	}
}

Qpage.prototype.Execute=function(act) {
	if (act == "ONINTERVAL") {
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "ONINTERVAL") {
				ExecCmd(this.Area, this.Events[i].Act);
				ExecCmdDelayed(Number(this.Events[i].Valor), this.Area, "Execute(" + this.Id + ",ONINTERVAL", this.Id);
			}
		}
	}
}

Qpage.prototype.SetState=function(st) {
	this.Frame.SetState(st);
}
	
Qpage.prototype.MouseMove=function(wx, wy) {
	var offset=GetOffsetFor("APP", this.HostPanel);
	var offx=offset.Left;
	var offy=offset.Top;
	var wleft=wx - this.Offsetx - offx - App.Locsize.ObjL;
	var wtop=wy - this.Offsety - offy - App.Locsize.ObjT;
	if (this.Tipo == "POPUPDIALOG") {
		wleft += this.Area.Locsize.ObjL;
		wtop += this.Area.Locsize.ObjT;
		var maxleft = this.Area.HostPanel.Locsize.ObjW - this.Locsize.ObjW;
		var maxtop = this.Area.HostPanel.Locsize.ObjH - this.Locsize.ObjH;
	} else {
		var maxleft = this.Area.Locsize.ObjW - this.Locsize.ObjW;
		var maxtop = this.Area.Locsize.ObjH - this.Locsize.ObjH;
	}
	if (wleft < 0) wleft=0;
	if (wtop < 0) wtop=0;
	if (wleft > maxleft) wleft=maxleft;
	if (wtop > maxtop) wtop=maxtop;
	this.Locsize.ObjL=wleft;
	this.Locsize.ObjT=wtop;
	this.Hobj.style.left = wleft + "px";
	this.Hobj.style.top = wtop + "px";
}
	
Qpage.prototype.MouseUp=function() {
	document.onselectstart=function() {return true}  //deixar que se seleccione texto
}

Qpage.prototype.OnMouseOver=function() {
}
Qpage.prototype.OnMouseOut=function() {
}

Qpage.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	this.PanelObj.disabled=true;
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Tipo == "PANEL") this.Actls[i].Disable(tipo);
	}
	//if (this.FirstPanel != "") this.FirstPanel.Disable(tipo);
	// o FirstPanel nos DBEDITS passou a ser um painel de titulos em vez de ser o PANEL geral do qual todos dependiam
	this.SetState("DISA");
	this.Disabled=true;
}

Qpage.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		this.PanelObj.disabled=false
		
		//if (this.FirstPanel != "") this.FirstPanel.Enable(tipo)
		// o FirstPanel nos DBEDITS passou a ser um painel de titulos em vez de ser o PANEL geral do qual todos dependiam
		this.SetState("NORM")
		this.Disabled=false;
	}
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Tipo == "PANEL") this.Actls[i].Enable(tipo);
	}
}

Qpage.prototype.Show=function(opt) {
	var wanim=new Qanimator(this, "IN", this.StyleObj.AnimIn);
	if (opt == "INIT") {
		this.Visible=true;
		wanim.Activate(this.Activate2);
		return;
	}
	this.Visible=true;
	wanim.Activate();
	for (var i=0; i<this.Actls.length; i++) {
		if (this.Actls[i].Class == "PANEL" && this.Actls[i].Tipo != "CONTXPANEL") this.Actls[i].Show();
	}
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == "ONINTERVAL") {
			ExecCmdDelayed(Number(this.Events[i].Valor), this.Area, "Execute(" + this.Id + ",ONINTERVAL", this.Id);
		}
	}
}

Qpage.prototype.Hide=function(opt) {
	DeleteQueuedCmd(this.Id)  //apagar comandos delayed pendentes para a paginas - eventos do tipo ONINTERVAL
	this.Visible=false;
	for (var i=this.Actls.length-1; i>=0; i--) {
		if (opt == "DESTROY" || opt == "DESTROYNOW") {
			this.Actls[i].Destroy(opt);
		} else {
			if (this.Actls[i].Class == "PANEL") this.Actls[i].Hide();
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
}
	
Qpage.prototype.ShowWarning=function(wtxt) {
	agora=Agora().getTime();
	if (wtxt != this.LastWarning) {
		this.LastWarning = wtxt;
		this.LastWarningTime=agora;
		window.alert(wtxt);
		return;
	}
	if (agora > this.LastWarningTime + 2000) {
		this.LastWarningTime=agora;
		window.alert(wtxt);
		return;
	}
	this.LastWarningTime=agora;
}

Qpage.prototype.GetHash=function() {
	var ix=this.Area.GetPageIndex(this.Id) + 1;
	var str="SA(" + this.Area.Id;
	if (this.Area.Tipo == "AREA") str += "{CAP";
	str += "{" + GetHistorialForHash(this.Area, ix) + "{OP(" + this.Id + "," + this.Func + "," + this.Key + "," + this.Cond + "," + this.Area.Id + "," + this.Area.Modulo;
	return str;
}

Qpage.prototype.Destroy=function(opt) {
	if (opt == undefined || opt == "") opt="DESTROY";  //opt="DESTROYNOW" destroy em modo sincrono sem esperar animações
	App.AddCmdLog("*-- Destroy Page Id='" + this.Id + "' in '" + this.Area.Id + "' opt=" + opt);
	//verificar evento BEFORECLOSE
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == "BEFORECLOSE") {
			ExecCmd(this.Area, this.Events[i].Act);
		}	
	}
	this.Hide(opt);
}

Qpage.prototype.Destroy2=function() {
	for (var i=0; i<this.Actls.length; i++) {
		this.Actls[i]=null;
	}
	var wparent=this.Hobj.parentNode;
	if (wparent != null) wparent.removeChild(this.Hobj);
	if (this.Tipo == "DIALOG") this.Area.Dialogs --;
	if (this.Area.Popup == "S") this.Area.Hide();
}

Qpage.prototype.CapMouseDown=function(wx, wy) {
	this.Offsetx = wx;
	this.Offsety = wy;
	CtlMouse=this;
	document.onselectstart=function() {return false}  //evitar que se seleccione texto
}

Qpage.prototype.OnScroll=function() {
	if (this.Tipo == "DIALOG") return;
	CtlMouse=null;
}

Qpage.prototype.OnMouseOver=function() {
	this.Area.OnMouseOver();
}

Qpage.prototype.OnMouseOut=function() {
	this.Area.OnMouseOut();
}


//***************************************************************** QEVENT - define EVENT de um controlo
function Qevent(xnod) {
	this.Id=GetAtt(xnod, "ID", "");
	this.Act=GetAtt(xnod, "ACT", "");
	this.SelObrig=GetAtt(xnod, "SELOBRIG", "S");
	this.Valor=GetAtt(xnod, "VAL", "");
	this.ContextId=GetAtt(xnod, "CONTEXTID", "");
	this.Disabled=false;
}



//***************************************************************** QHIST - define entrada no Historial
function Qhist() {
	this.Nivel=0;
	this.Id="";
	this.Desc="";
	this.Valor="";
	this.Op="=";
}


//***************************************************************** QCMD - define comando em queue
function Qcmd(id, areaorig, cmd, pageid) {
	this.Id=id;
	this.AreaOrig=areaorig;
	this.Cmd=cmd;
	this.PageId=pageid;
}


//***************************************************************** QDIRDB - define endereços onde ir buscar paginas ou dados
function Qdirdb(id, type, address) {
	this.Id=id;
	this.Type=type;
	this.Address=address;
	this.Online="S";
}


//***************************************************************** Qdisactl - define controlo de Disable/Enable de controlos
function Qdisactl(tipo) {
	this.Atipos=new Array()
	if (tipo != undefined && tipo != "") this.Atipos.push(tipo) 	
}

Qdisactl.prototype.Find=function(tipo) {
	var ix=-1
	for (var i=0; i<this.Atipos.length; i++) {
		if (this.Atipos[i] == tipo)	{
			ix=i
			break;
		}
	}
	return ix
}

Qdisactl.prototype.Add=function(tipo) {
	if (tipo == "" || tipo == undefined) return
	var ix=this.Find(tipo)
	if (ix == -1) this.Atipos.push(tipo)
}

Qdisactl.prototype.CanEnable=function(tipo) {
	if (this.Atipos.length == 0) return true
	if (tipo == "" || tipo == undefined) return false
	var ix=this.Find(tipo)
	if (ix == -1) return false
	this.Atipos.splice(ix, 1)
	if (this.Atipos.length == 0) return true
	return false
}


//***************************************************************** Obter data em UTC
function Agora() {
	var now=new Date();
	var agora=new Date(Date.UTC(now.getFullYear(), now.getMonth(), now.getDate(), now.getHours(), now.getMinutes(), now.getSeconds(), now.getMilliseconds()));
	return agora
}


//******* Obter largura e altura da janela do browser
function GetDocDims() {
	var pw=0;
	var ph=0;
	if (DeviceMobile == true) {
		if (document.documentElement) {
			pw=document.documentElement.clientWidth;
			ph=document.documentElement.clientHeight;
		} else {
			pw=document.body.clientWidth;
			ph=document.body.clientHeight;
		}
	} else {
		if (window.innerWidth && window.innerHeight) {
		 pw = window.innerWidth;
		 ph = window.innerHeight;
		} else {		
			if (document.body && document.body.offsetWidth) {
			 pw = document.body.offsetWidth;
			 ph = document.body.offsetHeight;
			}
			if (document.compatMode=='CSS1Compat' && document.documentElement && document.documentElement.clientWidth ) {
			 pw = pw ? pw: document.documentElement.clientWidth;
			 ph = ph ? ph : document.documentElement.clientHeight;
			}
		}
	}
	return [pw, ph];
}


//******* Obter o Ctl a partir do Hid
function GetCtlByHid(hid) {
	if (hid == undefined) return null;
	if (hid.indexOf(".") == -1 && hid.indexOf("9y9") > -1) hid=hid.replace(/9y9/g, ".")
	if (hid == "") return App;
	var ix=hid.indexOf("._.");
	if (ix > -1) hid=hid.substr(0,ix);
	var areaid="";
	var ix=hid.indexOf(".");
	if (ix == -1) {
		areaid=hid;
	} else {
		areaid=hid.substr(0,ix);
	}
	if (areaid == "") {
		warea=App;
	} else {
		var warea=App.GetArea(areaid);
	}
	if (hid == areaid || warea == null) return warea;
	var whid = hid + ".";
	if (warea.BackPage != null) {
		if (whid.indexOf(warea.BackPage.Hid + ".") == 0) {
			if (whid == warea.BackPage.Hid + ".") {
				return warea.BackPage;
			} else {
				return GetCtlByHid2(warea.BackPage, whid);
			}
		}
	}
	for (var p=0; p<warea.Pages.length; p++) {
		if (whid.indexOf(warea.Pages[p].Hid + ".") == 0) {
			if (whid == warea.Pages[p].Hid + ".") {
				return warea.Pages[p];
			} else {
				return GetCtlByHid2(warea.Pages[p], whid);
			}
		}
	}
	return GetCtlByHid2(warea, whid);
}

function GetCtlByHid2(ctl, hid) {
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	var whid=""
	for (var i=0; i<ctl.Actls.length; i++) {
		whid=ctl.Actls[i].Hid + "."
		if (whid == hid) return ctl.Actls[i];
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=GetCtlByHid2(ctl.Actls[i], hid);
		if (wctl != null) return wctl;
	}
	return null;
}


//******* Procurar o objecto na hierarquia começando em ctl
function GetCtlChild(ctl, id) {
	var wrid=id + RowOrig  //se RowOrig != ""  significa que estamos num ambiente de multiform e os Ids dos controlos da mesma row têm o sufixo da RowOrig
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	var ix=id.indexOf("._.");
	if (ix > -1) id=id.substr(0,ix);
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=ctl.Actls[i];
		if (wctl != null) {
			if (wctl.Id == id || wctl.Id == wrid) return ctl.Actls[i];
		}
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=ctl.Actls[i];
		if (wctl != null) {
			var wctldest=GetCtlChild(wctl, id);
			if (wctldest != null) return wctldest;
		}
	}
	return null;
}

//******* Retornar array de objectos na hierarquia do tipo especificado, começando em ctl
function GetCtlChildrenByTipo(ctl, tipo) {
	var Aobj = new Array();
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	for (var i=0; i<ctl.Actls.length; i++) {
		if (ctl.Actls[i].Tipo == tipo) Aobj.push(ctl.Actls[i]);
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wlist=GetCtlChildrenByTipo(ctl.Actls[i], tipo);
		if (wlist != null) {
			if (wlist.length > 0) Aobj=Aobj.concat(wlist);
		}
	}
	return Aobj;
}


//******* Retornar o primeirto controlo de input começando em ctl
function GetFirstInputField(ctl) {
	if (ctl.Actls == undefined || ctl.Actls == null) return null;
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=ctl.Actls[i]
		if (wctl.Tipo == "TEXT" || wctl.Tipo == "LEDTXT" || wctl.Tipo == "COMBO" || wctl.Tipo == "CHECK" || wctl.Tipo == "RADBOT") {
			if (wctl.Prot == "N") {
				if (wctl.Tipo == "TEXT") {
					if (wctl.ReadOnly == "N") return wctl
				} else {
					return wctl
				}		
			}
		}
	}
	for (var i=0; i<ctl.Actls.length; i++) {
		var wctl=ctl.Actls[i]
		var wresult=GetFirstInputField(wctl);
		if (wresult != null) return wresult;
	}
	return null;
}

//******* Procurar DATAPANEL na hierarquia ascendente
function FindDataPanel(ctl) {
	var wctl=ctl;
	while (wctl.Tipo != "PAGE" && wctl.Tipo != "DIALOG" && wctl.Tipo != "POPUPDIALOG" && wctl.Tipo != "WINDOW" && wctl.Tipo != "APP") {
		wctl=wctl.HostPanel;
		if (wctl.Tipo.indexOf("DATAPANEL") > -1 || wctl.Tipo.indexOf("AUTOQUERYPANEL") > -1) return wctl;
	}
	return null;
}


//***************************************************************** Queue de comandos
//******* Enqueue de executação de um comando com um delay
function ExecCmdDelayed(delay, areaorig, cmd, pageid) {
	App.Queueid ++;
	var wcmd=new Qcmd(App.Queueid, areaorig, cmd, pageid);
	App.Queuedcmds.push(wcmd);
	window.setTimeout("ExecQueuedCmd(" + App.Queueid + ")", delay);
}

//******* Executa comando enqueued
function ExecQueuedCmd(id) {
	for (var i=0; i<App.Queuedcmds.length; i++) {
		var qcmd=App.Queuedcmds[i];
		if (qcmd.Id == id) {
			ExecCmd(qcmd.AreaOrig, qcmd.Cmd);
			App.Queuedcmds.splice(i,1);
			if (IsQueueEmpty()) App.UnBlockAllInput();
			return
		}
	}
	if (IsQueueEmpty()) App.UnBlockAllInput();
}

//******* Saber se a Queue está vazia para efeitos de bloqueio de ecran
function IsQueueEmpty() {
	var exeptions=0;
	for (var i=0; i<App.Queuedcmds.length; i++) {
		var qcmd=App.Queuedcmds[i];
		if (qcmd.Cmd.indexOf("ONINTERVAL") > -1) exeptions ++
	}
	if (App.Queuedcmds.length - exeptions == 0) return true;
	return false;
}

//******* Elimina entradas de uma pagina
function DeleteQueuedCmd(pageid) {
	for (var i=App.Queuedcmds.length-1; i>=0; i--) {
		var qcmd=App.Queuedcmds[i];
		if (qcmd.PageId == pageid) App.Queuedcmds.splice(i,1);
	}
	if (App.Queuedcmds.length == 0) App.UnBlockAllInput();
}

//***************************************************************** Historial
//******* Obter o index de entrada no Historial
function GetHistorialIndex(area, id, op) {
	var Hist=area.Historial;
	for (var i=Hist.length - 1; i>=0; i--) {
		if (Hist[i].Id == id && Hist[i].Op == op) {
			return i;
		}
	}
	return -1;
}


//******* Remover entrada no Historial
function RemoveEntradaHistorial(area, id) {
	var Hist=area.Historial;
	for (var i=Hist.length - 1; i>=0; i--) {
		if (Hist[i].Id == id) {
			Hist.splice(i,1);
			break;
		}
	}
}


//******* Colocar valor no Historial se valor for null apaga a entrada desse nivel se existir
function SetHistorial(area, col, valor) {
	var Hist=area.Historial;
	var niv=area.Pages.length;
	var hid=col.HistId;
	if (hid == "") hid=col.Id;
	for (var i=0; i<Hist.length; i++) {
		if (Hist[i].Id == hid && Hist[i].Nivel == niv && Hist[i].Op == col.HistOp) {
			if (valor == null) {
				Hist.splice(i,1);
				return;
			} else {
				Hist[i].Valor=valor;
				return;
			}
		}
	}
	if (valor == null) return;  //valor null só serve para eliminar caso exista
	var hentry=new Qhist();
	hentry.Nivel=niv;
	hentry.Id=hid;
	hentry.Valor=valor;
	hentry.Op=col.HistOp;
	Hist.push(hentry);
}


//******* Colocar valor no Historial no próximo nível
function SetHistNextLevel(area, col, valor) {
	var Hist=area.Historial;
	var niv=area.Pages.length + 1;  //nivel seguinte ao atual
	var hid=col.HistId;
	if (hid == "") hid=col.Id;
	if (valor == null) return;  //valor null não faz nada
	var hentry=new Qhist();
	hentry.Nivel=niv;
	hentry.Id=hid;
	hentry.Valor=valor;
	hentry.Op=col.HistOp;
	Hist.push(hentry);
}

//******* Colocar valor no Historial por comando
function SetHistorialCmd(area, id, valor, op, perm) {
	if (perm == undefined) perm="N"
	var Hist=area.Historial;
	var niv=area.Pages.length;
	if (perm == "S") niv=-1;
	var wop=op;
	if (wop == "" || wop == undefined) wop="EQ";
	for (var i=0; i<Hist.length; i++) {
		if (Hist[i].Id == id && Hist[i].Op == wop && Hist[i].Nivel == niv) {
			Hist[i].Valor=valor;
			return;
		}
	}
	var hentry=new Qhist();
	hentry.Nivel=niv;
	hentry.Id=id;
	hentry.Valor=valor;
	hentry.Op=wop;
	Hist.push(hentry);
}

//******* Remover entradas no Historial
function RemoveNivelHistorial(area, iniv) {
	var Hist=area.Historial;
	var niv=area.Pages.length;
	if (iniv != undefined) {
		if (iniv == "next") iniv=niv+1;
		niv=iniv;
	}
	for (var i=Hist.length -1; i>=0; i--) {
		if (Hist[i].Nivel >= niv && Hist[i].Nivel>=0) Hist.splice(i,1);
	}
}

//******* Obter copia do Historial
function GetHistorialCopy(area) {
	var Hist=area.Historial;
	var Nhist=new Array();
	for (var i=0; i<Hist.length; i++) {
		var hentry=new Qhist();
		hentry.Nivel=0;
		hentry.Id=Hist[i].Id;
		hentry.Valor=Hist[i].Valor;
		hentry.Op=Hist[i].Op;
		Nhist.push(hentry);
	}
	return Nhist;
}

//******* Obter todo o Historial para Hash do url - eliminar duplicados
function GetHistorialForHash(area, niv) {
	//obter os GETHISTID da página activa na area
	//o array Aw vai conter os HistGetId usados na pagina sem repetidos
	var Aw=new Array();
	var wpage=area.ActivePage;
	var found=false;
	for (var i=0; i<wpage.Actls.length; i++) {
		var wctl=wpage.Actls[i];
		if (wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM" || wctl.Tipo == "DBEDIT" || wctl.Tipo == "FORM" || wctl.Tipo == "MULTIFORM") {
			for (var c=0; c<wctl.Cols.length; c++) {
				var wcol=wctl.Cols[c];
				if (wcol.HistGetId != "") {
					found=false;
					for (var h=0; h<Aw.length; h++) {
						if (wcol.HistGetId == Aw[h]) {
							found=true;
							break;
						}
					}
					if (found == false) Aw.push(wcol.HistGetId);
				}
			}
		}
	}
	var Hist=area.Historial;
	var Aout=new Array();
	for (var h=0; h<Aw.length; h++) {
		var wid=Aw[h];
		for (var i=Hist.length - 1; i>=0; i--) {
			if (Hist[i].Id == wid) {
				if (Hist[i].Nivel < niv) {
					str = "SH(" + Hist[i].Id + "," + Hist[i].Valor + "," + Hist[i].Op;
					Aout.push(str);
					break;
				}
			}
		}
	}
	
	/*
	var Hist=area.Historial;
	var str="";
	var Aw=new Array();
	var Aout=new Array();
	var found=false;
	for (var i=Hist.length - 1; i>=0; i--) {
		var wid=Hist[i].Id + Hist[i].Op;
		found = false;
		for (var j=0; j<Aw.length; j++) {
			if (Aw[j] == wid) {
				found = true;
				break;
			}
		}
		if (found == false && Hist[i].Nivel < niv) {
			str = "SH(" + Hist[i].Id + "," + Hist[i].Valor + "," + Hist[i].Op;
			Aout.push(str);
			Aw.push(wid);
		}
	}
	*/
	
	Aw=null;
	Aout=Aout.sort();  //ordenar para que a mesma pagina não tenha hash diferente
	str="";
	for (var i=0; i<Aout.length; i++){
		if (str != "") str += "{";
		str += Aout[i];
	}
	Aout=null;
	return str;
}


//*********************************************
//*********************************************
//*   Cache de Imagens
//*********************************************
//*********************************************


//***************************************************************** QIMAGELIB - Biblioteca de imagens pre-loaded
function QimgLib() {
	this.Imgs=new Array();
	this.ImgIds=new Array();
}

QimgLib.prototype.LoadImg=function(id) {
	var wimg=new Image();
	this.ImgIds.push(id);
	this.Imgs.push(wimg);
	wimg.src=id;
}

QimgLib.prototype.GetImg=function(id) {
	for (var i=0; i<this.ImgIds.length; i++) {
		if (this.ImgIds[i] == id) {
			return this.Imgs[i].src;
		}
	}
	//return null;
	return id;
}



//*********************************************
//*********************************************
//*   Funções gerais de XML
//*********************************************
//*********************************************


// por enquanto devolve apenas o endereço do serviço definido no app.xml
function GetServiceAddress(id) {
	return App.Services[id].Address
}

// Criar um link para um recurso (utilizado pelo Qimg e Qdoc para construir os links para os ficheiros)
function CriarLinkRecurso(recurso, modulo) {
    if (recurso == "") return "";
    var link = recurso;
    var idx = link.indexOf(":");
    var tratado = true;
    var prefixo = "";
    if (idx != -1)
        prefixo = link.substr(0, idx);

    switch (prefixo) {
        case "ticket":
            link = GetServiceAddress("RECURSO") + "?rec=" + link.substr(idx + 1);
            break;
        case "url":
        default:
            //link = link
            break;
    }

    return link;
}

// devolve o endereço da imagem com base na path definida no app.xml em IMGSRC
function GetImageAddress(url) {
	if (App != null) {
		var Aw=url.split(".");
		if (Aw.length > 1) {
			var diraddr=null;
			var dirtipo="";
			for (var i=0; i<App.ImgSrc.length; i++) {
				if (App.ImgSrc[i].Id == Aw[0]) {
					diraddr=App.ImgSrc[i].Address;
					dirtipo=App.ImgSrc[i].Type;
					break;
				}
			}
			if (diraddr == null) {
				if (App.ImgSrc.length > 0) {
					var diraddr=App.ImgSrc[0].Address;
					var dirtipo=App.ImgSrc[0].Type;
				} else {
					diraddr="";
				}
				var file=url;
			} else {
				var file=Aw[1];
				if (Aw.length > 2) {
					for (var i=2; i<Aw.length; i++) {
						file += "." + Aw[i];
					}
				}
			}
		} else {
			var diraddr=""
			var dirtipo="";
			if (App.ImgSrc.length > 0) {
				if (App.ImgSrc[0].Id == Aw[0]) {
					var diraddr=App.ImgSrc[0].Address;
					var dirtipo=App.ImgSrc[0].Type;
				}
			}
			var file=Aw[0];
		}
	} else {
		var diraddr="";
		var dirtipo="";
		if (FileMode == true) dirtipo="FILE";
		var file=url;
	}
	var r= diraddr + file;
	r += "?V=" + App.Version; //garantir que renova a cache quando a versão muda
	return r;
}

function GetLoadAddress(url, modulo, nolang) {
	var Aw=GetLoadPath(url, modulo, nolang);
	return Aw[0];
}

function GetLoadPath(url, modulo, nolang) {
	if (App != null) {
		var Aw=url.split(".");
		if (modulo != undefined && modulo != "") {
			if (Aw.length == 1) {
				Aw[1]=Aw[0];
				Aw[0]=modulo;
			}
		}
		if (Aw.length > 1) {
			var diraddr=null;
			var dirtipo="";
			for (var i=0; i<App.Dir.length; i++) {
				if (App.Dir[i].Id == Aw[0]) {
					diraddr=App.Dir[i].Address;
					dirtipo=App.Dir[i].Type;
					break;
				}
			}
			if (diraddr == null) {
				var diraddr=App.Dir[0].Address;
				var dirtipo=App.Dir[0].Type;
				var file=url;
				//window.alert(GetMsg(1, "Acesso a documento no servidor - (" + Aw[0] + ") não encontrada nas DIRs da Aplicação"))
				//return null
			} else {
				var file=Aw[1];
				if (Aw.length > 2) {
					for (var i=2; i<Aw.length; i++) {
						file += "." + Aw[i];
					}
				}
			}
		} else {
			var diraddr=App.Dir[0].Address;
			var dirtipo=App.Dir[0].Type;
			var file=Aw[0];
		}
		//QwPconfirm receives its text from history, so the translation is to be set upon the dialog call
		if (nolang == false && file != "QwPconfirm") {
			if (App.DefLanguage != "") file += User.Language;
		}
	} else {
		var diraddr="";
		var dirtipo="";
		if (FileMode == true) dirtipo="FILE";
		var file=url;
	}
	var r=new Array(diraddr + file, diraddr, dirtipo, file);
	return r;
}


//******* Obter um xmldocument com o ficheiro em (url)
function GetXmlData(url, modulo, nolang, version) {
	if (nolang == undefined) nolang=false;
	var Aw=GetLoadPath(url, modulo, nolang);
	if (Aw[0].indexOf(".") == -1) {
		var wurl=Aw[0]+".xml";
	} else {
		var wurl=Aw[0];
	}
	if (version == "RANDOM") {
		var r=Math.floor(Math.random() * 1001);     // gerar numero inteiro aleatorio entre 0 e 1000 para ser sempre diferente e forçar a cache
		wurl=wurl + "?V=" + r;
	} else {
		if (version == "" || version == undefined) {
			wurl=wurl + "?V=" + App.Version;
		} else {
			wurl=wurl + "?V=" + version;
		}
	}
	var diraddr=Aw[1];
	var dirtipo=Aw[2];
	if (dirtipo == "FILE") {
		var xdoc=GetLocalXmlDoc(wurl);
		//return xdoc;
	} else {
		var xdoc=GetXmlDoc(wurl);
	}
	if (xdoc == null) return null;
	var watt = xdoc.createAttribute("URL");
	watt.value=wurl;
	xdoc.documentElement.setAttributeNode(watt);
	//**** procurar includes
	var xlist=xdoc.getElementsByTagName("include");
	for (var i=0; i<xlist.length; i++) {
		var file=GetAtt(xlist[i], "FILE", "");
		if (file != "") {
			var xincl=GetXmlData(file, modulo, true, version);
			if (xincl != null) {
				var refnode=xlist[i];
				var refparent=refnode.parentNode;
				var xinodes=xincl.documentElement.childNodes;
				for (var s=0; s<xinodes.length; s++) {
					var xn=xinodes[s].cloneNode(true);
					refparent.insertBefore(xn, refnode);
				}
			}	
		}	
	}
	for (var i=0; i<xlist.length; i++) {
		var refnode=xlist[i];
		refnode.parentNode.removeChild(refnode);
	}
	return xdoc;
}


function GetLocalXmlDoc(wurl) {
	/*
	var xdoc=document.createElement("xml");
	var r=xdoc.load(wurl);
	if (r == false) {
		if (wurl.indexOf("QwAutoLogon") > -1) return null;
		window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
		return null;
	}
	return xdoc;
	*/
	if (BrowserIE) {
		xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
 		xmlDoc.async = false;
 		while(xmlDoc.readyState != 4) {};
 		xmlDoc.load(wurl);
 		if (xmlDoc.documentElement == null) {
 			if (wurl.indexOf("QwAutoLogon") > -1) return null;
			window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
			return null;
 		}
 		return xmlDoc;
	} else {
		var xmlhttp = new XMLHttpRequest();
 		xmlhttp.open("GET", wurl, false);
		xmlhttp.setRequestHeader('Content-Type', 'text/xml');
		try{
		xmlhttp.send("");
 		var xmlDoc = xmlhttp.responseXML;
 		return xmlDoc;
 		}
 		catch(exp) {
 			if (wurl.indexOf("QwAutoLogon") > -1) return null;
			window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
			return null;
 		}
 	}
}


function GetXmlDoc(wurl) {
	if (!BrowserIE) {
		try {
			var xmlhttp = new XMLHttpRequest();
			xmlhttp.open("GET", wurl, false);
			xmlhttp.send(null);
			var xdoc=xmlhttp.responseXML;
			//var xstring = (new XMLSerializer()).serializeToString(xdoc)
			if (xmlhttp.status != 200) {
				if (wurl.indexOf("QwAutoLogon") > -1) return null;
				window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
				return null;
			}
		}
		catch(exp) {
			if (wurl.indexOf("QwAutoLogon") > -1) return null;
			window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
			return null;
		}
	} else {
		var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
		xmlhttp.Open("GET", wurl, false);
		xmlhttp.Send(null);
		var xdoc=xmlhttp.responseXML;
		if (xdoc.xml == "" || xmlhttp.status != 200) {
			if (wurl.indexOf("QwAutoLogon") > -1) return null;
			window.alert(GetMsg(1, "Erro na abertura do documento (" + wurl + ") - inexistente ou invalido."));
			return null;
		}
	}
	xmlhttp=null;
	return xdoc;
}


//******* Obter o valor do atributo (att) do elemento (xnode). Se não existir devolve (deflt). Se tipo="N" retorna valor numerico
function GetAtt(xnode, att, deflt, tipo) {
	if (BrowserIE || BrowserOP) {
		var watt=xnode.selectSingleNode("@" + att);
	} else {
		//var nodes=xnode.ownerDocument.evaluate("@" + att, xnode, null, 0, null);
		//var watt=nodes.iterateNext()
		try{var watt=xnode.attributes[att];}
			catch(exp){}
	}
	var wresult;
	if (watt == undefined) {
		wresult=deflt;
		if (att == "ACT") {  //procura segmento <ACT>
			watt=GetSegm(xnode, att);
			if (watt != null) wresult=watt;
		}
	} else {
		wresult=watt.nodeValue;
	}
	if (tipo == "N") wresult=Number(wresult);
	return wresult;
}

//******* Obter o valor do segmento segname dependente do xnode e devolve conteudo. Se não existir devolve null.
function GetSegm(xnode, segname) {
	var xn=xnode.firstChild;
	var wresult=null;
	while (xn!=undefined) {
		if (xn.nodeName == segname) {
			wresult=xn.firstChild.nodeValue;
			wresult=wresult.replace(/^\s+|\s+$/g, '');  // Trim da expressão
			break;
		}
		xn=xn.nextSibling;
	}
	return wresult;
}


//******* Modificar o valor do atributo (att) do elemento (xnode).
function SetAtt(xnode, att, valor) {
	if (BrowserIE || BrowserOP) {
		var watt=xnode.selectSingleNode("@" + att);
	} else {
		try{var watt=xnode.attributes[att];}
		catch(exp){}
	}
	if (watt == undefined) return;
	watt.nodeValue=valor;
}


//******* Modificar o valor do atributo (att) do elemento (xnode) substituindo # (se existir) pelo indice
function ReplaceAtt(xnode, att, ix) {
	if (BrowserIE || BrowserOP) {
		var watt=xnode.selectSingleNode("@" + att);
	} else {
		try{var watt=xnode.attributes[att];}
		catch(exp){}
	}
	if (watt == undefined) return;
	var wval=watt.nodeValue;
	var j=wval.indexOf("#");
	while (j > -1) {
		wval=wval.substr(0,j) + ix + wval.substr(j+1);
		j=wval.indexOf("#");
	}
	watt.nodeValue=wval;
}

//******* Obter string segura para ser enviada num atributo xml
function Xencode(w) {
	var wt=w;
	var re=/&/g;
	wt=wt.replace(re,"&amp;");
	var re=/>/g;
	wt=wt.replace(re,"&gt;");
	var re=/</g;
	wt=wt.replace(re,"&lt;");
	var re=/\"/g;
	wt=wt.replace(re,"&quot;");
	var re=/\'/g;
	wt=wt.replace(re,"&apos;");
	return wt;
}

//******* Obter string xml codificada dentro de um atributo xml
function Xdecode(w) {
	var wt=w;
	var re=/&gt;/g;
	wt=wt.replace(re,">");
	var re=/&lt;/g;
	wt=wt.replace(re,"<");
	var re=/&quot;/g;
	wt=wt.replace(re,"\"");
	var re=/&apos;/g;
	wt=wt.replace(re,"'");
	var re=/&amp;/g;
	wt=wt.replace(re,"&");
	var re=/&#xD;&#xA;/g;
	wt=wt.replace(re,"\r\n");
	return wt;
}


//******* Obter um node de um documento xml a partir de uma string
function CreateXnode(xstr) {
	if (BrowserIE) {
		var xnod=new ActiveXObject("MSXML.DOMDocument");
		xnod.loadXML(xstr);
	} else {
		var docparser=new DOMParser();
		var xnod=docparser.parseFromString(xstr,"text/xml");
	}
	xnod=xnod.documentElement;
	return xnod;
}


//*********************************************
//*********************************************
//*   Base64 encoding
//*********************************************
//*********************************************

// http://bannister.us/weblog/2007/06/09/simple-base64-encodedecode-javascript/

// Handles encode/decode of ASCII and Unicode strings.

var UTF8 = {};
UTF8.encode = function(s) {
    var u = [];
    for (var i = 0; i < s.length; ++i) {
        var c = s.charCodeAt(i);
        if (c < 0x80) {
            u.push(c);
        } else if (c < 0x800) {
            u.push(0xC0 | (c >> 6));
            u.push(0x80 | (63 & c));
        } else if (c < 0x10000) {
            u.push(0xE0 | (c >> 12));
            u.push(0x80 | (63 & (c >> 6)));
            u.push(0x80 | (63 & c));
        } else {
            u.push(0xF0 | (c >> 18));
            u.push(0x80 | (63 & (c >> 12)));
            u.push(0x80 | (63 & (c >> 6)));
            u.push(0x80 | (63 & c));
        }
    }
    return u;
};
UTF8.decode = function(u) {
    var a = [];
    var i = 0;
    while (i < u.length) {
        var v = u[i++];
        if (v < 0x80) {
            // no need to mask byte
        } else if (v < 0xE0) {
            v = (31 & v) << 6;
            v |= (63 & u[i++]);
        } else if (v < 0xF0) {
            v = (15 & v) << 12;
            v |= (63 & u[i++]) << 6;
            v |= (63 & u[i++]);
        } else {
            v = (7 & v) << 18;
            v |= (63 & u[i++]) << 12;
            v |= (63 & u[i++]) << 6;
            v |= (63 & u[i++]);
        }
        a.push(String.fromCharCode(v));
    }
    return a.join('');
};

var BASE64 = {};
(function(T){
    var encodeArray = function(u) {
        var i = 0;
        var a = [];
        var n = 0 | (u.length / 3);
        while (0 < n--) {
            var v = (u[i] << 16) + (u[i+1] << 8 ) + u[i+2];
            i += 3;
            a.push(T.charAt(63 & (v >> 18)));
            a.push(T.charAt(63 & (v >> 12)));
            a.push(T.charAt(63 & (v >> 6)));
            a.push(T.charAt(63 & v));
        }
        if (2 == (u.length - i)) {
            var v = (u[i] << 16) + (u[i+1] << 8);
            a.push(T.charAt(63 & (v >> 18)));
            a.push(T.charAt(63 & (v >> 12)));
            a.push(T.charAt(63 & (v >> 6)));
            a.push('=');
        } else if (1 == (u.length - i)) {
            var v = (u[i] << 16);
            a.push(T.charAt(63 & (v >> 18)));
            a.push(T.charAt(63 & (v >> 12)));
            a.push('==');
        }
        return a.join('');
    }
    var R = (function(){
        var a = [];
        for (var i=0; i<T.length; ++i) {
            a[T.charCodeAt(i)] = i;
        }
        a['='.charCodeAt(0)] = 0;
        return a;
    })();
    var decodeArray = function(s) {
        var i = 0;
        var u = [];
        var n = 0 | (s.length / 4);
        while (0 < n--) {
            var v = (R[s.charCodeAt(i)] << 18) + (R[s.charCodeAt(i+1)] << 12) + (R[s.charCodeAt(i+2)] << 6) + R[s.charCodeAt(i+3)];
            i += 4;
            u.push(255 & (v >> 16));
            u.push(255 & (v >> 8));
            u.push(255 & v);
        }
        if (u) {
            if ('=' == s.charAt(i-2)) {
                u.pop();
                u.pop();
            } else if ('=' == s.charAt(i-1)) {
                u.pop();
            }
        }
        return u;
    }
    var ASCII = {};
    ASCII.encode = function(s) {
        var u = [];
        for (var i = 0; i<s.length; ++i) {
            u.push(s.charCodeAt(i));
        }
        return u;
    };
    ASCII.decode = function(s) {
        for (var i = 0; i<s.length; ++i) {
            a[i] = String.fromCharCode(a[i]);
        }
        return a.join('');
    };
    BASE64.encodeASCII = function(s) {
        var u = ASCII.encode(s);
        return encodeArray(u);
    };
    BASE64.decodeASCII = function(s) {
        var a = decodeArray(s);
        return ASCII.decode(a);
    };
    BASE64.encode = function(s) {
        var u = UTF8.encode(s);
        return encodeArray(u);
    };
    BASE64.decode = function(s) {
        var u = decodeArray(s);
        return UTF8.decode(u);
    };
})("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");

if (undefined == btoa) {
    var btoa = BASE64.encode;
}
if (undefined == atob) {
    var atob = BASE64.decode;
}


//*********************************************
//*********************************************
//*   Rotinas para Debug
//*********************************************
//*********************************************

function GetLogAreas() {
	var w="";
	for (var i=0; i<App.Areas.length; i++) {
		if (i > 0) w += ";";
		w += App.Areas[i].Id;
	}
	return w;
}

function GetLogParm(areaid) {
	var area=App.GetArea(areaid);
	if (area.ActivePage != null) {
		pagid=area.ActivePage.Id;
		url=area.ActivePage.Url;
		wfunc=area.ActivePage.FuncIni;
		wkey=area.ActivePage.Key;
		wcond=area.ActivePage.Cond;
		time=area.ActivePage.Time;
	} else {
		pagid="";
		url=window.location;
		wfunc="";
		wkey="";
		wcond="";
		time="";
	}
	var wanteriores=""
	for (var i=0; i<area.Pages.length - 1; i++) {
		if (i > 0) wanteriores += " / "
		wanteriores += area.Pages[i].Id
	}
	whtml="<br><table cellspacing='3' cellpadding='0' border='0' class='FORMFLD'>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Window Id: &nbsp;</b></TD><TD width='350'>" + area.Id + "." + pagid + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Url: &nbsp;</b></TD><TD width='350'><a href='" + url + "' target='_blank'>" + url + "</a></TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Pag.Ant.: &nbsp;</b></TD><TD width='350'>" + wanteriores + "</TD></TR>"
	whtml=whtml + "<TR><TD width='130' align='right'><b>Parm. Func: &nbsp;</b></TD><TD width='350'>" + wfunc + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Parm. Cond: &nbsp;</b></TD><TD width='350'>" + wcond + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Parm. Key: &nbsp;</b></TD><TD width='350'>" + wkey + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Modulo: &nbsp;</b></TD><TD width='350'>" + area.Modulo + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Niveis: &nbsp;</b></TD><TD width='350'>" + User.Modulos.substr(1, User.Modulos.length - 2) + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>Permissões: &nbsp;</b></TD><TD width='350'>" + User.PermForm.substr(1, User.PermForm.length - 2) + "</TD></TR>";
	whtml=whtml + "<TR><TD width='130' align='right'><b>TimeToBuild(ms): &nbsp;</b></TD><TD width='350'>" + time + "</TD></TR>";
	whtml=whtml + "</table>";
	return whtml;
}

function GetLogHist(areaid) {
	var area=App.GetArea(areaid);
	whtml="<br><table cellspacing='3' cellpadding='0' border='0' class='FORMFLD'>";
	whtml=whtml + "<TR><TD width='30'><b>Nivel<b></TD><TD width='50'><b>ID<b></TD><TD width='30'><b>Op<b></TD><TD width='60'><b>Valor<b></TD><TD width='300'><b>Descrição<b></TD></TR>";
	for (var i=0; i < area.Historial.length; i++) {
		whtml=whtml + "<TR><TD>" + area.Historial[i].Nivel + "</TD><TD>" + area.Historial[i].Id + "</TD><TD>" + area.Historial[i].Op + "</TD><TD>" + area.Historial[i].Valor + "</TD><TD>" + area.Historial[i].Desc + "</TD></TR>";
	}
	whtml=whtml + "</table>";
	return whtml;
}

function GetLogCom(areaid) {
	var area=App.GetArea(areaid);
	var pag=area.ActivePage;
	if (pag == null) return "";
	var whtml ="<br>";
	for (var i=0; i < pag.Log.length; i++) {
		var wlog=pag.Log[i];
		var wdados=""
		var wrec=""
		for (var r=0; r<wlog.DADOS.length; r++) {
			if (r > 0) wdados += "<br>"
			wdados += "REC#" + (r+1) + "="
			wrec=wlog.DADOS[r]
			var wcval=""
			for (var c=0; c<wrec.length; c++) {
				if (c > 0) wdados += ","
				wcval=wrec[c] + ""
				wdados += "'" + wcval.replace(/\s/g, "&nbsp;") + "'"
			}
		}
		whtml=whtml + "<table cellspacing='2' cellpadding='0' border='0' class='FORMFLD'>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>Time(ms):<b></TD><TD width='350'>" + wlog.TIME + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>Sentido:<b></TD><TD width='350'>" + wlog.DIR + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>Módulo:<b></TD><TD width='350'>" + wlog.MOD + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>Ano:<b></TD><TD width='350'>" + wlog.YEAR + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>identificador:<b></TD><TD width='350'>" + wlog.IDENT + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>aplicacao:<b></TD><TD width='350'>" + wlog.APP + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>funcao:<b></TD><TD width='350'>" + wlog.FUNC + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>campos:<b></TD><TD style='word-break: break-all'>" + wlog.CMPS + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>condicao:<b></TD><TD width='350'>" + wlog.COND + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>ordenacao:<b></TD><TD width='350'>" + wlog.ORD + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>dados:<b></TD><TD width='350'>" + wdados + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>opções:<b></TD><TD width='350'>" + wlog.OPT + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>mensagem:<b></TD><TD width='350'>" + wlog.MSG + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>status:<b></TD><TD width='350'>" + wlog.STAT + "</TD></TR>";
		whtml=whtml + "<TR><TD valign='top' width='130'><b>online:<b></TD><TD width='350'>" + wlog.ONLINE + "</TD></TR>";
		whtml=whtml + "</table><br><br>";
	}
	return whtml;
}

function GetLogCmd() {
	var whtml="";
	var w=""
	for (var i=0; i<App.CmdLog.length; i++) {
		w=App.CmdLog[i]
		w=Xencode(w);
		w=w.replace(/ /g, "&nbsp;");
		whtml += w + "<br />"
	}
	return whtml;
}

function GetErroHtml() {
	return ErrHtml;
}

function GetLogMsg(tipo) {
	if (tipo == "html") {
		var whtml ="<br>";
		for (var i=0; i < MsgLog.length; i++) {
			var Aw=MsgLog[i].split("$|$");
			whtml=whtml + "<table cellspacing='2' cellpadding='0' border='0' class='FORMFLD'>";
			whtml=whtml + "<TR><TD valign='top' width='130'><b>" + Aw[0] + "<b></TD><TD width='350'>" + Aw[1] + "</TD></TR>";
			whtml=whtml + "</table><br><br>";
		}
		return whtml;
	}
	if (tipo == "text") {
		var txt="";
		for (var i=0; i < MsgLog.length; i++) {
			var Aw=MsgLog[i].split("$|$");
			txt+=Aw[0] + "\r\n" + Aw[1] + "\r\n\r\n";
		}
		return txt;
	}
}


function GetMsg(ix, p1, p2, p3) {
	var msg=MsgSet[ix];
	if (ix == 1) {
		var dt=Agora();
		dt=dt.getUTCDate() + "/" + (dt.getUTCMonth() + 1) + "/" + dt.getUTCFullYear() + " " + dt.getUTCHours() + ":" + dt.getUTCMinutes() + ":" + dt.getUTCSeconds();
		MsgLog.push(dt + "$|$" + p1);
		if(DeviceMobile == false) p1="";
	}
	if (p1 != undefined) {
		var re=/#1/g;
		msg=msg.replace(re, p1);
	}
	if (p2 != undefined) {
		var re=/#2/g;
		msg=msg.replace(re, p2);
	}
	if (p3 != undefined) {
		var re=/#3/g;
		msg=msg.replace(re, p3);
	}
	return msg;
}



//*   API para uso em Formulas ou Scripts
var qApi = new qapi();

qapi.prototype.SetHistorial=function(area, p0, p1, p2, p3) {
	this.LogCmd("SetHistorial", arguments);
	var warea=GetExecAorig(area, "SetHistorial");
	SetHistorialCmd(warea, p0, p1, p2, p3);
	return "";
}

qapi.prototype.Sigla=function() {  
	this.LogCmd("Sigla");
	return Sigla();
};

qapi.prototype.GetModulo=function(area) {   //** obter o modulo corrente
	this.LogCmd("GetModulo", arguments);
	var warea=GetExecAorig(area, "GetModulo");
	return warea.Modulo;
}

qapi.prototype.GetHist=function(area, nome, op) {
	this.LogCmd("GetHist", arguments);
	var warea=GetExecAorig(area, "GetHist");
	if (op == "" || op == undefined) op="EQ";
	var ix=GetHistorialIndex(warea, nome, op);
	if (ix > -1) {
		return warea.Historial[ix].Valor;
	}
	return "";
}

qapi.prototype.GetEph = function (area, nome) {
    this.LogCmd("GetEph", arguments);
    var warea = GetExecAorig(area, "GetEph");

    //pode retornar multiplos valores
    //de um modo geral esta info é guardada dentro de um historial
    //exemplo de invocação Qweb_api.prototype.SetHistorial('','func1',Qweb_api.prototype.GetEph('','func2'));
    //func2 pode ter vários valores

    //1º solução temporária
    //invocar o servidor e ficar a espera da resposta e retornar o valores     

    //2º solução de futuro
    //ter uma estrutura com os EPH todos a cabeça no momento do login
    //dois pontos de manipulação: 
    //UpdateEPH que muda o eph no servidor e desancadeia um refresh do lado qweb
    //e este GetEph que irá consultar os valores em memoria invés de ir ao servidor.

    //O GETEPH e o UPDATEEPH já estão implementados no servidor

    return "";
}

qapi.prototype.HasRole = function (area, nome) {
    this.LogCmd("HasRole", arguments);
    var warea = GetExecAorig(area, "HasRole");
    return "";
}

//*********************************************
//*********************************************
//*   API para uso interno no Qweb
//*********************************************
//*********************************************

function Qweb_api() {
	this.dummy = "API class to agregate Qweb functions";
	
	return this;
}

Qweb_api.prototype.LogCmd=function(id, args) {  //Fazer log da execução dos comandos.  Uso interno.
	var w=id + "(";
	if (args != null && args != undefined) {
		for (var i=0; i<args.length; i++) {
			if (i > 0) w += ", ";
			if (args[i] == null || args[i] == undefined) {
				if (args[i] == null) {
					w += "null"
				} else {
					w += "undefined"
				}
			} else {
				if (typeof args[i] == "object" && args[i].Id != undefined) {
					w += "'" + args[i].Id + "'"; 	
				}
				else{
					w += "'" + args[i] + "'"; 		
				}
			}
	    }
	}
	w += ")";
	if (App) {
	    App.AddCmdLog(w);
	}
    return "";
}

Qweb_api.prototype.DoLogon=function(niveis, perms, ano, userid, username, status) {  //Fazer Logon.
	this.LogCmd("DoLogon", arguments);
    User.DoLogon(niveis, perms, ano, userid, username, status);
    return "";
}

Qweb_api.prototype.DoLogoff=function(opt) {  //Fazer Logoff.
	this.LogCmd("DoLogoff", arguments);
    User.DoLogoff(opt);
    return "";
}

Qweb_api.prototype.DoAnoChange = function (ano, nivel, perms) {  //Alteração do ano e permissões.
    this.LogCmd("DoAnoChange", arguments);
    User.DoAnoChange(ano, nivel, perms);
    return "";
}

Qweb_api.prototype.SetArea=function(area) {  //estabelecer uma AREA para os comandos seguintes.
	this.LogCmd("SetArea", arguments);
	return api.SetAreaInternal(area);
}

Qweb_api.prototype.SetAreaInternal=function(area) {  //estabelecer uma AREA para os comandos seguintes.
	if (area.Id == undefined) {
		var warea = App.GetArea(area);
	} else {
		var warea=area;
	}
	if (warea != null) {
		Aorig=warea;
		return "";
	}
    return area;
}

Qweb_api.prototype.AreaExists = function(area) {  //Saber se existe uma Area ou Window.
	this.LogCmd("Exists", arguments);
	var warea=App.GetArea(area);
	var r="S"
	if (warea == null) r="N";
	return r;
}

Qweb_api.prototype.IsUpdatePending = function(area, ctlid) {  //Saber se a pagina activa está dirty (UpdatePending) ou se o Form está dirty.
	this.LogCmd("IsUpdatePending", arguments);
    var warea = GetExecAorig(area, "IsUpdatePending");
    wpage = warea.ActivePage;
    if (ctlid == "" || ctlid == undefined) {
        if (wpage.UpdatePending == true) {
            return "S";
        } else {
            return "N";
        }
    }
    var wctl = wpage.GetCtl(ctlid);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando IsUpdatePending com controlo (" + ctlid + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "FORM") {
        window.alert(GetMsg(1, "Comando IsUpdatePending com controlo (" + ctlfrom + ") de tipo diferente de FORM."));
        return "";
    }
    if (wctl.UpdatePending == true) {
        return "S";
    } else {
        return "N";
    }
}

Qweb_api.prototype.GetBrowserInfo=function() {  //Obter texto com informação sobre o browser.
	this.LogCmd("GetBrowserInfo", arguments);
    var wtxt="";
    if (BrowserIE == true) wtxt += "Browser: Internet Explorer\r\n";
    if (BrowserMOZ == true) wtxt += "Browser: FireFox\r\n";
    if (BrowserOP == true) wtxt += "Browser: Opera\r\n";
    if (BrowserWKIT == true) wtxt += "Browser: Chrome / Safari\r\n";
    if (DeviceMobile == true) {
		wtxt += "Mobile Device: true\r\n";
		wtxt += "Device type: " + DeviceType + "\r\n";
	} else {
		wtxt += "Mobile Device: false\r\n";
	}
	var dims=GetDocDims();
	wtxt += "Window width=" + dims[0] + "    height=" + dims[1] + "\r\n";
    return wtxt;
}

Qweb_api.prototype.FormatDateForUser=function(wdate) {  //Obter a data especificada (ou a do dia, se "") no formato da lingua do utilizador.
	this.LogCmd("FormatDateForUser", arguments);
    if (wdate == undefined || wdate == "" || wdate == null) wdate=Agora();
    return FormatFromDateH(wdate, "user");
}

Qweb_api.prototype.GetValArray = function(area, ctlid) {   //Obter array com os valores de um Multiform ou Treesrc
	this.LogCmd("GetValArray", arguments);
    var warea = GetExecAorig(area, "GetValArray");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctlid);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando GetValArray com id. de controlo (" + ctlid + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando GetValArray sobre controlo (" + ctlid + ") de tipo diferente de MULTIFORM ou TREESRC."));
        return "";
    }
    var ds = new Array()
    for (var i = 0; i < wctl.Dados.length; i++) {
        var rec = wctl.Dados[i];
        var orec = new Array();
        for (var c = 0; c < rec.Coldefs.length; c++) {
            orec.push(rec.Fields[c].Val);
        }
        ds.push(orec);
    }
    return ds;
}

Qweb_api.prototype.SetValArray = function(area, ctlid, wdados, refresh) {   //Carregar um Multiform ou Treesrc com os valores de um array(wdados). refresh="S" faz o refresh do controlo. 
	this.LogCmd("SetValArray", arguments);
    var warea = GetExecAorig(area, "SetValArray");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctlid);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando SetValArray com id. de controlo (" + ctlid + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando SetValArray sobre controlo (" + ctlid + ") de tipo diferente de MULTIFORM ou TREESRC."));
        return "";
    }
    if (refresh == undefined) refresh = "S";
    var wskeys = new Array();
    var dados = new Array();
    var primeirakey = "";
    for (var r = 0; r < wdados.length; r++) {
        var wrec = wdados[r];
        var Rec = new Qrecord(wctl.Cols, wrec)
        if (Rec.Status != "VAZIO") {
            dados.push(Rec);
            if (primeirakey == "") primeirakey = Rec.Key;
            for (var k = 0; k < wctl.SelectedKeys.length; k++) {
                if (Rec.Key == wctl.SelectedKeys[k]) {
                    wskeys.push(Rec.Key);
                    break;
                }
            }
        }
    }
    wctl.Dados = dados;
    wctl.Paginas = new Array();
    wctl.PagFimSup = true;
    wctl.PagFimInf = true;
    wctl.Paginas.push(primeirakey);
    wctl.PagIndex = wctl.Paginas.length - 1;
    wctl.SelectedKeys = wskeys;
    if (refresh == "S") wctl.PopulateGrid();
    return "";
}

Qweb_api.prototype.GetLang=function() {   //Obter o codigo da lingua actual
	this.LogCmd("GetLang", arguments);
	return User.Language; 
}

Qweb_api.prototype.ValidaValor=function(tipo, valor, obrig, titulo) {   // validar valor segundo o tipo=  A N $ D H T B  e retorna msg se invalido
	this.LogCmd("ValidaValor", arguments);
	var wcol=new Qcol(null, "tmpcol", tipo, 10)
	if (obrig == "S") wcol.Obrig="S"
	if (titulo != undefined) wcol.Tit=titulo
	switch (tipo) {
		case "A":
			wcol.Comp=100
			break
		case "N":
			break
		case "$":
			wcol.Dec=0
			break
		case "D":
			break
		case "H":
			wcol.Comp=16
			break
		case "T":
			wcol.Comp=8
			break
		case "B":
			wcol.Comp=1
			break
	}
	var msg=ValidarCol(wcol, valor, "OBRIG")
	return msg
}

Qweb_api.prototype.FormataValor = function(tipo, valor, decimais, destino) {   // formata valor segundo o tipo=  A N $ D H T B  e destino=server / user
	this.LogCmd("FormataValor", arguments);
    if (destino == undefined || destino == "" || destino == null) destino = "user";
    var val = valor.replace(/[\[\{\}\]]/g, "");  //retirar todos os [ ] { }
    switch (tipo) {
        case "A":
            break;
        case "N":
            val = ConvertNumeroToSrv(val);
            if (decimais == "" || decimais == undefined || decimais == null) decimais = 0;
            val = FormatNumber(val, decimais, destino);
            break;
        case "$":
            if (decimais == "" || decimais == undefined || decimais == null) decimais = 0;
            val = ConvertNumeroToSrv(val);
            val = FormatDinheiro(val, decimais, destino);
            break;
        case "D":
            val = ConvertDataToSrv(val);
            val = FormatDate(val, destino);
            break;
        case "H":
            val = ConvertDataHToSrv(val);
            val = FormatDateH(val, destino);
            break;
        case "T":
            val = ConvertHoraToSrv(val);
            val = FormatHora(val, destino);
            break;
        case "B":
            val = ConvertBooleanToSrv(val);
            val = FormatBoolean(val, destino);
            break;
    }
    return val;
}

Qweb_api.prototype.SetFocus=function(area, id) {   // por o focus no controlo ou no elemento com o respectivo id
	this.LogCmd("SetFocus", arguments);
	var warea=GetExecAorig(area, "SetFocus");
	wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(id);
	if (wctl != null) {
		wctl.Focus()
	} else {
		var welem=document.getElementById(id)
		welem.focus()
	}
	return "";
}

Qweb_api.prototype.GetDivByCtlId=function(area, ctlid) {   //** obter a div html dando o nome do controlo
	this.LogCmd("GetDivByCtlId", arguments);
	var warea=GetExecAorig(area, "GetDivByCtlId");
	wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(ctlid);
	if (wctl == null) return "";
	var wctldiv=wctl.Hobj;
	if (wctldiv == null || wctldiv == undefined) return "";
	return wctldiv;
}


//Sincroniza os registos de dois datasets de MULTIFORM ou TREESRC.
//opt="IUD" qualquer combinação das funções I(nsert) U(pdate) D(elete)
//refresh="S" faz o refresh do controlo de output
Qweb_api.prototype.SyncDataset = function(area, ctlfrom, ctlto, opt, refresh) {
	this.LogCmd("SyncDataset", arguments);
    if (refresh == undefined) refresh = "S";
    var warea = GetExecAorig(area, "SyncDataset");
    wpage = warea.ActivePage;
    var wctlfrom = wpage.GetCtl(ctlfrom);
    if (wctlfrom == null) {
        window.alert(GetMsg(1, "Comando SyncDataset com controlo de origem (" + ctlfrom + ") invalido."));
        return "";
    }
    if (wctlfrom.Tipo != "MULTIFORM" && wctlfrom.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando SyncDataset - controlo de origem (" + ctlfrom + ") de tipo diferente de MULTIFORM ou TREESRC."));
        return "";
    }
    var wctlto = wpage.GetCtl(ctlto);
    if (wctlto == null) {
        window.alert(GetMsg(1, "Comando SyncDataset com controlo de destino (" + ctlfrom + ") invalido."));
        return "";
    }
    if (wctlto.Tipo != "MULTIFORM" && wctlto.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando SyncDataset - controlo de origem (" + ctlfrom + ") de tipo diferente de MULTIFORM ou TREESRC."));
        return "";
    }
    var wdataout = new Array();
    for (var r = 0; r < wctlfrom.Dados.length; r++) {
        var wrecfrom = wctlfrom.Dados[r];
        var wkeyfrom = wrecfrom.Key;
        var wrecto = null;
        var wfunc = "";
        for (var t = 0; t < wctlto.Dados.length; t++) {
            var wrec = wctlto.Dados[t];
            if (wrec.Key == wkeyfrom) {
                wrecto = wrec;
                if (opt.indexOf("U") > -1) {
                    wctlto.Dados.splice(t, 1);
                    wfunc = "U";
                } else {
                    wdataout.push(wrecto);
                }
                break;
            }
        }
        if (wrecto == null) {
            wfunc = "I";
            wrecto = new Qrecord(wctlto.Cols);
            if (wctlto.Tipo == "TREESRC") {
                if (wrecto.Field("niv").Val == "") wrecto.Field("niv").Val = "0";
                if (wrecto.Field("vis").Val == "") wrecto.Field("vis").Val = "S";
                if (wrecto.Field("tipo").Val == "") wrecto.Field("tipo").Val = "L";
            }
        }
        if ((wfunc == "I" && opt.indexOf("I") > -1) || (wfunc == "U" && opt.indexOf("U") > -1)) {
            for (var i = 0; i < wctlto.Cols.length; i++) {
                var fid = wctlto.Cols[i].Id;
                for (var c = 0; c < wctlfrom.Cols.length; c++) {
                    if (wctlfrom.Cols[c].Id == fid) {
                        wrecto.Fields[i].Val = wrecfrom.Fields[c].Val;
                        if (wrecto.Fields[i].Coldef.Key == "S") wrecto.Key = wrecto.Fields[i].Val;
                        break;
                    }
                }
            }
            wdataout.push(wrecto);
        }
        //if ((wfunc == "U" && opt.indexOf("U") > -1) || (wfunc == "I" && opt.indexOf("I") > -1)) wdataout.push(wrecto);
    }
    if (opt.indexOf("D") > -1) {
        wctlto.Dados = wdataout;
    } else {
        wctlto.Dados = wctlto.Dados.concat(wdataout);
    }
    if (wctlto.Dados.length > 0) {
        wctlto.Paginas[0] = wdataout[0].Key;
        wctlto.PagFimSup = true;
        wctlto.PagFimInf = true;
        wctlto.PagIndex = 0;
    } else {
        wctlto.Paginas = new Array();
        wctlto.PagIndex = -1;
    }
    if (refresh == "S") wctlto.PopulateGrid();
    return "";
}

//Copia o registo seleccionado do multiform de origem para o de destino para campos que tenham o mesmo nome.
//Opt=CANCELONDUP / UPDATEONDUP / NEWKEYONDUP
//defaultval = Array de valores para default values
//refresh="S" faz o refresh do controlo de output
Qweb_api.prototype.RecCopy = function(area, ctlfrom, ctlto, opt, defaultval, refresh) {
	this.LogCmd("RecCopy", arguments);
    if (defaultval == undefined) defaultval = new Array();
    if (refresh == undefined) refresh = "S";
    var warea = GetExecAorig(area, "RecCopy/RecMove");
    wpage = warea.ActivePage;
    var wctlfrom = wpage.GetCtl(ctlfrom);
    if (wctlfrom == null) {
        window.alert(GetMsg(1, "Comando RecCopy/RecMove com controlo de origem (" + ctlfrom + ") invalido."));
        return "";
    }
    var wctlto = wpage.GetCtl(ctlto);
    if (wctlto == null) {
        window.alert(GetMsg(1, "Comando RecCopy/RecMove com controlo de destino (" + ctlfrom + ") invalido."));
        return "";
    }
    var Arecfrom = new Array()  //contem o(s) registo(s) a copiar
    if (wctlfrom.Tipo == "MULTIFORM" || wctlfrom.Tipo == "TREESRC") {
        if (wctlfrom.SelectedKeys.length == 0) {
            window.alert(GetMsg(4, ""));
            return "";
        }
        for (var i = 0; i < wctlfrom.SelectedKeys.length; i++) {
            Arecfrom.push(wctlfrom.GetRowFromKey(wctlfrom.SelectedKeys[i]));
        }
    } else {  //dados de FORM
        var wrecfrom = new Qrecord(wctlfrom.Cols, new Array());
        for (var i = 0; i < wctlfrom.Cols.length; i++) {
            wrecfrom.Fields[i].Val = wctlfrom.Dados[i]
            if (wctlfrom.Cols[i].Key == "S") wrecfrom.Key = wctlfrom.Dados[i];
        }
        Arecfrom.push(wrecfrom);
    }
    for (var r = 0; r < Arecfrom.length; r++) {
        var wrecfrom = Arecfrom[r];
        var wkeyfrom = wrecfrom.Key;
        var wrecto = new Qrecord(wctlto.Cols, defaultval);
        var wkeyto = ""
        for (var i = 0; i < wctlto.Cols.length; i++) {
            var fid = wctlto.Cols[i].Id;
            for (var c = 0; c < wctlfrom.Cols.length; c++) {
                if (wctlfrom.Cols[c].Id == fid) {
                    wrecto.Fields[i].Val = wrecfrom.Fields[c].Val;
                    if (wrecto.Fields[i].Coldef.Key == "S") {
                        wkeyto = wrecfrom.Fields[c].Val;
                        wrecto.Key = wkeyto;
                    }
                    break;
                }
            }
        }
        if (wctlto.Tipo == "MULTIFORM" || wctlto.Tipo == "TREESRC") {
            qapiRecCopyMult(wctlto, wrecto, opt);
        } else {  //Tipo == "FORM"
            qapiRecCopyForm(wctlto, wrecto, opt);
            break;
        }
    }
    if (wctlto.Tipo == "MULTIFORM" || wctlto.Tipo == "TREESRC") {
        if (refresh == "S") wctlto.PopulateGrid();
        return wctlfrom.SelectedKeys;
    } else {
        return new Array(Arecfrom[0].Key);
    }
}

function qapiRecCopyMult(wctlto, wrecto, opt) {
    if (wctlto.Tipo == "TREESRC") {
        if (wrecto.Field("niv").Val == "") wrecto.Field("niv").Val = "0";
        if (wrecto.Field("vis").Val == "") wrecto.Field("vis").Val = "S";
        if (wrecto.Field("tipo").Val == "") wrecto.Field("tipo").Val = "L";
    }
    if (opt == "CANCELONDUP" || opt == "UPDATEONDUP") {
        for (var i = 0; i < wctlto.Dados.length; i++) {
            var rec = wctlto.Dados[i];
            if (rec.Key == wrecto.Key) {
                if (opt == "UPDATEONDUP") wctlto.Dados[i] = wrecto;
                return;
            }
        }
    } else {
        if (opt == "NEWKEYONDUP") {  //se existir modificar a chave de xxxx para xxxx._01 ou um numero sequencial superior
            var maxsufix = "";
            for (var i = 0; i < wctlto.Dados.length; i++) {
                var rec = wctlto.Dados[i];
                if (rec.Key.indexOf(wrecto.Key) == 0) {
                    var sufix = rec.Key.substr(wrecto.Key.length);
                    if (sufix == "") {
                        if (maxsufix == "") maxsufix = "._";
                    } else {
                        if (sufix.indexOf("._") == 0) {
                            if (sufix > maxsufix) maxsufix = sufix;
                        }
                    }
                }
            }
            if (maxsufix != "") {
                var nseq = Number(maxsufix.substr(2));
                var wnseq = "" + (nseq + 1);
                if (wnseq.length < 2) wnseq = "0" + wnseq;
                var newkey = rec.Key + "._" + wnseq;
                for (var f = 0; f < rec.Fields.length; f++) {
                    if (rec.Fields[f].Coldef.Key == "S") {
                        rec.Fields[f].Val = newkey;
                        rec.Key = newkey;
                        break;
                    }
                }
            }
        }
    }
    wctlto.Dados.push(wrecto);
    if (wctlto.Paginas.length == 0) {
        wctlto.PagFimSup = true;
        wctlto.PagFimInf = true;
        wctlto.Paginas.push(wrecto.Key);
        wctlto.PagIndex = wctlto.Paginas.length - 1;
    }
}

function qapiRecCopyForm(wctlto, wrecto, opt) {
    wctlto.Dados = new Array();
    wctlto.UpdatePending = false;
    for (var i = 0; i < wctlto.Cols.length; i++) {
        wctlto.Dados.push(wrecto.Fields[i].Val)
    }
    for (var i = 0; i < wctlto.Cols.length; i++) {
        wctlto.Cols[i].Status = "";
        var wcol = wctlto.Cols[i];
        for (var c = 0; c < wcol.ColCtls.length; c++) {
            var wctl = wcol.ColCtls[c];
            wctl.SetVal(wctlto.Dados[i]);
        }
    }
    for (var i = 0; i < wctlto.Limitedctls.length; i++) {
        wctlto.Limitedctls[i].SetLimit(wctlto);
    }
}



Qweb_api.prototype.RecMove = function(area, ctlfrom, ctlto, unique) {  //Move o registo seleccionado do multiform de origem para o de destino para campos que tenham o mesmo nome
	this.LogCmd("RecMove", arguments);
    var wkeys = api.RecCopy(area, ctlfrom, ctlto, unique);
    if (wkeys.length == 0) return "";
    var warea = GetExecAorig(area, "RecMove");
    wpage = warea.ActivePage;
    var wctlfrom = wpage.GetCtl(ctlfrom);
    if (wctlfrom.Tipo == "MULTIFORM" || wctlfrom.Tipo == "TREESRC") {
        for (var i = 0; i < wctlfrom.Dados.length; i++) {
            var wrec = wctlfrom.Dados[i];
            for (var k = 0; k < wkeys.length; k++) {
                var wkey = wkeys[k];
                if (wrec.Key == wkey) {
                    wctlfrom.Dados.splice(i, 1);
                    break;
                }
            }
        }
        wctlfrom.PopulateGrid();
    } else {  // dados de FORM
        wctlfrom.Dados = new Array()
        for (var i = 0; i < wctlfrom.Cols.length; i++) {
            wctlfrom.Dados.push("");
            wctlfrom.Cols[i].Status = "";
            var wcol = wctlfrom.Cols[i];
            for (var c = 0; c < wcol.ColCtls.length; c++) {
                var wctl = wcol.ColCtls[c];
                wctl.SetVal("");
            }
        }
        for (var i = 0; i < wctlto.Limitedctls.length; i++) {
            wctlto.Limitedctls[i].SetLimit(this);
        }
    }
    return wkey;
}

Qweb_api.prototype.RecDelete = function(area, ctlfrom, key, refresh) {  //Apaga o registo seleccionado do multiform de origem ou o registo com a key especificada
	this.LogCmd("RecDelete", arguments);
    if (refresh == undefined) refresh = "S";
	var warea=GetExecAorig(area, "RecDelete");
	wpage=warea.ActivePage;
	var wctlfrom=wpage.GetCtl(ctlfrom);
	if (wctlfrom ==  null) {
		window.alert(GetMsg(1, "Comando RecDelete com controlo de origem (" + ctlfrom + ") invalido."));
		return "";
	}
	if (key == undefined || key == "") {
		if (wctlfrom.SelectedKeys.length == 0) {
			window.alert(GetMsg(4, ""));
			return "";
		}
		var wkey=wctlfrom.SelectedKeys[0];
		wctlfrom.SelectedKeys=new Array();
	} else {
		var wkey=key
	}
	for (var i=0; i<wctlfrom.Dados.length; i++) {
		var wrec=wctlfrom.Dados[i];
		if (i == 0) primeirakey=wrec.Key;
		if (wrec.Key == wkey) {
			wctlfrom.Dados.splice(i,1);
			break;
		}
	}
	var primeirakey="";
	if (wctlfrom.Dados.length > 0) {
		var wrec=wctlfrom.Dados[0];
		primeirakey=wrec.Key;
	}
	if (primeirakey == "") {
		wctlfrom.Paginas=new Array()
		wctlfrom.PagIndex=-1
	} else {
		wctlfrom.Paginas[0]=primeirakey
	}
	if (refresh == "S") wctlfrom.PopulateGrid();
	return wkey;
}

Qweb_api.prototype.RecUp=function(area, ctl) {  //Move o registo seleccionado uma posição para cima
	this.LogCmd("RecUp", arguments);
	var warea=GetExecAorig(area, "RecUp");
	wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(ctl);
	if (wctl ==  null) {
		window.alert(GetMsg(1, "Comando RecUp sobre controlo (" + ctl + ") invalido."));
		return "";
	}
	if (wctl.SelectedKeys.length == 0) {
		window.alert(GetMsg(4, ""));
		return "";
	}
	if (wctl.SelectedKeys.length > 1) {
	    window.alert(GetMsg(5, ""));
	    return "";
	}
	var wkey=wctl.SelectedKeys[0];
	if (wctl.Tipo == "MULTIFORM") {
		for (var i=0; i<wctl.Dados.length; i++) {
			var wrec=wctl.Dados[i];
			if (wrec.Key == wkey) {
				if (i == 0) return ""
				var wrecant = wctl.Dados[i-1]
				wctl.Dados[i]=wrecant
				wctl.Dados[i-1]=wrec
				if (i == 1) wctl.Paginas[0]=wrec.Key
				break;
			}
		}
	} else {
		alert("RecUp não implementado em controlos do tipo " + wctl.Tipo)
	}
	wctl.PopulateGrid();
	return "";
}

Qweb_api.prototype.RecDown=function(area, ctl) {  //Move o registo seleccionado uma posição para baixo
	this.LogCmd("RecDown", arguments);
	var warea=GetExecAorig(area, "RecDown");
	wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(ctl);
	if (wctl ==  null) {
		window.alert(GetMsg(1, "Comando RecDown sobre controlo (" + ctl + ") invalido."));
		return "";
	}
	if (wctl.SelectedKeys.length == 0) {
		window.alert(GetMsg(4, ""));
		return "";
	}
	if (wctl.SelectedKeys.length > 1) {
	    window.alert(GetMsg(5, ""));
	    return "";
	}
	var wkey=wctl.SelectedKeys[0];
	if (wctl.Tipo == "MULTIFORM") {
		for (var i=0; i<wctl.Dados.length; i++) {
			var wrec=wctl.Dados[i];
			if (wrec.Key == wkey) {
				if (i == (wctl.Dados.length - 1)) return ""
				var wrecseg = wctl.Dados[i+1]
				wctl.Dados[i]=wrecseg
				wctl.Dados[i+1]=wrec
				if (i == 0) wctl.Paginas[0]=wrecseg.Key
				break;
			}
		}
	} else {
		alert("RecDown não implementado em controlos do tipo " + wctl.Tipo)
	}
	wctl.PopulateGrid();
	return "";
}

Qweb_api.prototype.RecUpNiv = function(area, ctl, opt, refresh) {  //Move o registo seleccionado um nivel acima
	this.LogCmd("RecUpNiv", arguments);
    if (refresh == undefined) refresh = "S";
	var warea=GetExecAorig(area, "RecUpNiv");
	wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(ctl);
	if (wctl ==  null) {
		window.alert(GetMsg(1, "Comando RecUpNiv sobre controlo (" + ctl + ") invalido."));
		return "";
    }
    if (wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando RecUpNiv sobre controlo (" + ctl + ") de tipo diferente de TREESRC."));
        return "";
    }
	if (wctl.SelectedKeys.length == 0) {
		window.alert(GetMsg(4, ""));
		return "";
    }
    if (wctl.SelectedKeys.length > 1) {
        window.alert(GetMsg(5, ""));
        return "";
    }
	var wkey=wctl.SelectedKeys[0];
	for (var i=0; i<wctl.Dados.length; i++) {
		var wrec=wctl.Dados[i];
		if (wrec.Key == wkey) {
			var wniv=Number(wrec.Field("niv").Val)
			if (wniv == 0) return ""
			wniv--
			wrec.Field("niv").Val="" + wniv
			break;
		}
	}
	if (opt == "SORTNIV") {
		var wdados=new Array()
		var refniv=0
		for (var i=0; i<wctl.Dados.length; i++) {
			var wrec=wctl.Dados[i];
			var wniv=Number(wrec.Field("niv").Val)
			if (wniv == refniv) {
				wdados.push(wrec)
			} else {
				for (var j=i; j<wctl.Dados.length; j++) {
					var wrec2=wctl.Dados[j];
					var wniv2=Number(wrec2.Field("niv").Val)
					if (wniv2 == refniv) {
						wdados.push(wrec2)
						wctl.Dados.splice(j, 1)
						j--
					}
				}
				refniv++
				i--
			}
		}
		wctl.Dados=wdados;		
		wctl.Paginas[0]=wctl.Dados[0].Key
	}
	if (refresh == "S") wctl.PopulateGrid();
	return "";
}

Qweb_api.prototype.RecDownNiv = function(area, ctl, opt, refresh) {  //Move o registo seleccionado um nivel abaixo
	this.LogCmd("RecDownNiv", arguments);
    if (refresh == undefined) refresh = "S";
    var warea = GetExecAorig(area, "RecDownNiv");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando RecDownNiv sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando RecDownNiv sobre controlo (" + ctl + ") de tipo diferente de TREESRC."));
        return "";
    }
    if (wctl.SelectedKeys.length == 0) {
        window.alert(GetMsg(4, ""));
        return "";
    }
    if (wctl.SelectedKeys.length > 1) {
        window.alert(GetMsg(5, ""));
        return "";
    }
    var maxniv = 0;
    var maxnivkey = "";
    var nivcounts = new Array();
    for (var i = 0; i < wctl.Dados.length; i++) {
        var wrec = wctl.Dados[i];
        var wniv = Number(wrec.Field("niv").Val);
        if (nivcounts[wniv] == undefined) {
            nivcounts[wniv] = 1;
        } else {
            nivcounts[wniv]++;
        }
        if (wniv > maxniv) {
            maxniv = wniv;
            maxnivkey = wrec.Key;
        } else {
            if (wniv == maxniv) maxnivkey = "*";
        }
    }
    var wkey = wctl.SelectedKeys[0];
    for (var i = 0; i < wctl.Dados.length; i++) {
        var wrec = wctl.Dados[i];
        if (wrec.Key == wkey) {
            var wniv = Number(wrec.Field("niv").Val);
            if (wniv == maxniv) {
                if (maxnivkey == wrec.Key) return "";
            }
            if (nivcounts[wniv] == 1) return "";
            //if (wniv == 0 && nivzerocount == 1) return "";
            wniv++;
            wrec.Field("niv").Val = "" + wniv;
            break;
        }
    }
    if (opt == "SORTNIV") {
        var wdados = new Array();
        var refniv = 0;
        for (var i = 0; i < wctl.Dados.length; i++) {
            var wrec = wctl.Dados[i];
            var wniv = Number(wrec.Field("niv").Val);
            if (wniv == refniv) {
                wdados.push(wrec);
            } else {
                for (var j = i; j < wctl.Dados.length; j++) {
                    var wrec2 = wctl.Dados[j];
                    var wniv2 = Number(wrec2.Field("niv").Val);
                    if (wniv2 == refniv) {
                        wdados.push(wrec2);
                        wctl.Dados.splice(j, 1);
                        j--;
                    }
                }
                refniv++;
                i--;
            }
        }
        wctl.Dados = wdados;
        wctl.Paginas[0] = wctl.Dados[0].Key;
    }
    if (refresh == "S") wctl.PopulateGrid();
    return "";
}

Qweb_api.prototype.VerifyTree = function(area, ctl, opt, refresh) {  //Verifica e se necessario corrige a hierarquia
	this.LogCmd("VerifTree", arguments);
    if (refresh == undefined) refresh = "S";
    var warea = GetExecAorig(area, "VerifyTree");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando VerifyTree sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando VerifyTree sobre controlo (" + ctl + ") de tipo diferente de TREESRC."));
        return "";
    }
    var maxniv = 0;
    var maxnivkey = "";
    var nivcounts = new Array();
    for (var i = 0; i < wctl.Dados.length; i++) {
        var wrec = wctl.Dados[i];
        var wniv = Number(wrec.Field("niv").Val);
        if (nivcounts[wniv] == undefined) {
            nivcounts[wniv] = 1;
        } else {
            nivcounts[wniv]++;
        }
        if (wniv > maxniv) {
            maxniv = wniv;
            maxnivkey = wrec.Key;
        } else {
            if (wniv == maxniv) maxnivkey = "*";
        }
    }
    for (var i = 0; i < wctl.Dados.length; i++) {
        var wrec = wctl.Dados[i];
        var wniv = Number(wrec.Field("niv").Val);
        var wnewniv = wniv;
        for (var n = wniv - 1; n >= 0; n--) {
            if (nivcounts[n] == undefined) wnewniv--;
        }
        if (wniv != wnewniv) wrec.Field("niv").Val = wnewniv;
    }
    if (opt == "SORTNIV") {
        var wdados = new Array();
        var refniv = 0;
        for (var i = 0; i < wctl.Dados.length; i++) {
            var wrec = wctl.Dados[i];
            var wniv = Number(wrec.Field("niv").Val);
            if (wniv == refniv) {
                wdados.push(wrec);
            } else {
                for (var j = i; j < wctl.Dados.length; j++) {
                    var wrec2 = wctl.Dados[j];
                    var wniv2 = Number(wrec2.Field("niv").Val);
                    if (wniv2 == refniv) {
                        wdados.push(wrec2);
                        wctl.Dados.splice(j, 1);
                        j--;
                    }
                }
                refniv++;
                i--;
            }
        }
        wctl.Dados = wdados;
        if (wctl.Dados.length > 0) {
            wctl.Paginas[0] = wctl.Dados[0].Key;
            wctl.PagFimSup = true;
            wctl.PagFimInf = true;
            wctl.PagIndex = 0;
        } else {
            wctl.Paginas = new Array();
            wctl.PagIndex = -1;
        }
    }
    if (refresh == "S") wctl.PopulateGrid();
    return "";
}


Qweb_api.prototype.RefreshGrid = function(area, ctl) {  //Refresca a grid de um Multiform ou Treesrc
	this.LogCmd("RefreshGrid", arguments);
    var warea = GetExecAorig(area, "RefreshGrid");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando RefreshGrid sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando RefreshGrid sobre controlo (" + ctl + ") de tipo diferente de MULTIFORM ou TREESRC."));
        return "";
    }
    wctl.PopulateGrid();
}

Qweb_api.prototype.GetDataset = function(area, ctl) {  //obtem o Dataset de um controlo de dados para um array de arrays
	this.LogCmd("GetDataset", arguments);
    var warea = GetExecAorig(area, "GetDataset");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando GetDataset sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "MENUSRC" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando GetDataset sobre controlo (" + ctl + ") de tipo diferente de MULTIFORM, MENUSRC e TREESRC."));
        return "";
    }
    var wdados=new Array();
    for (var i = 0; i < wctl.Dados.length; i++) {
    	var Avalrec=new Array();
    	var Rec=wctl.Dados[i];
		for (var c=0; c<wctl.Cols.length; c++) {
			Avalrec.push(Rec.Fields[c].Val);
		}
		wdados.push(Avalrec);
    }
    return wdados;
}

Qweb_api.prototype.ReplaceDataset = function(area, ctl, dados) {  //substitui o Dataset de um controlo de dados obtendo o valor de um array de arrays
	this.LogCmd("ReplaceDataset", arguments);
    var warea = GetExecAorig(area, "ReplaceDataset");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando ReplaceDataset sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "MENUSRC" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando ReplaceDataset sobre controlo (" + ctl + ") de tipo diferente de MULTIFORM, MENUSRC e TREESRC."));
        return "";
    }
    wctl.Dados=new Array();
    var primeirakey="";
    for (var i = 0; i < dados.length; i++) {
    	var Rec=new Qrecord(wctl.Cols, dados[i]);
    	if (Rec.Status != "VAZIO") {
			wctl.Dados.push(Rec);
			if (primeirakey == "") primeirakey=Rec.Key;
		}
    }
    wctl.PopulateXtracols();
    if (wctl.Dados.length > 0) {
        wctl.Paginas[0] = wctl.Dados[0].Key;
        wctl.PagFimSup = true;
        wctl.PagFimInf = true;
        wctl.PagIndex = 0;
    } else {
        wctl.Paginas = new Array();
        wctl.PagIndex = -1;
    }
    return "";
}

Qweb_api.prototype.SelectRec = function(area, ctl, key) {  //selecciona o registo do multiform com a chave especificada
	this.LogCmd("SelectRec", arguments);
    var warea = GetExecAorig(area, "SelectRec");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando ReplaceDataset sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MULTIFORM" && wctl.Tipo != "MENUSRC" && wctl.Tipo != "TREESRC") {
        window.alert(GetMsg(1, "Comando SelectRec sobre controlo (" + ctl + ") de tipo diferente de MULTIFORM, MENUSRC e TREESRC."));
        return "";
    }
    wctl.SetRow(key, false);
    for (var i=0; i<wctl.Grpctls.length; i++) {
		wctl.Grpctls[i].RefreshSelected();	
	}
}

Qweb_api.prototype.GetUrl=function() {
	this.LogCmd("GetUrl", arguments);
	var wurl=window.location.href;
	if (App.ChangeUrl == "S") {
		return wurl;
	} else {
		var hash=App.GetCurrentHash()
		return wurl + "#" + hash;
	}
}

Qweb_api.prototype.OpenApp=function(area, url) {
	this.LogCmd("OpenApp", arguments);
	var warea=GetExecAorig(area, "OpenApp");
	OpenApp(warea, url);
	return "";
}

Qweb_api.prototype.OpenPage=function(area, url, func, key, cond, tarea) {
	this.LogCmd("OpenPage", arguments);
	var warea=GetExecAorig(area, "OpenPage");
	OpenPage(warea, url, func, key, cond, tarea);
	return "";
}

Qweb_api.prototype.OpenDialog=function(area, url, func, key, cond, tarea) {
	this.LogCmd("OpenDialog", arguments);
	var warea=GetExecAorig(area, "OpenDialog");
	if (App.ReplaceDialogs == "N") {
		OpenDialog(warea, url, func, key, cond, tarea);
	} else {
		OpenPage(warea, url, func, key, cond, tarea);
	}
	return "";
}

Qweb_api.prototype.OpenPopupDialog=function(area, url, func, key, cond, tarea) {
	this.LogCmd("OpenPopupDialog", arguments);
	var warea=GetExecAorig(area, "OpenPopupDialog");
	OpenPopupDialog(warea, url, func, key, cond, tarea);
	return "";
}

Qweb_api.prototype.OpenFirstPage=function(area, url, func, key, cond, tarea, modulo) {
	this.LogCmd("OpenFirstPage", arguments);
	var warea=GetExecAorig(area, "OpenFirstPage");
	OpenFirstPage(warea, url, func, key, cond, tarea, modulo);
	return "";
}

Qweb_api.prototype.OpenBackPage=function(area, url, func, key, cond, tarea, modulo) {
	this.LogCmd("OpenBackPage", arguments);
	var warea=GetExecAorig(area, "OpenBackPage");
	OpenBackPage(warea, url, func, key, cond, tarea, modulo);
	return "";
}

Qweb_api.prototype.OpenWindow=function(area, url, func, key, cond, parentpath, modulo, opts) {
	this.LogCmd("OpenWindow", arguments);
	var warea=GetExecAorig(area, "OpenWindow");
	OpenWindow(warea, url, func, key, cond, parentpath, modulo, opts);
	return "";
}

Qweb_api.prototype.OpenBrowserWindow=function(area, url, wid, hei, parms, histparms) {
	this.LogCmd("OpenBrowserWindow", arguments);
	var warea=GetExecAorig(area, "OpenBrowserWindow");
	OpenBrowserWindow(warea, url, wid, hei, parms, histparms);
	return "";
}

Qweb_api.prototype.ClosePage=function(area, opt) {
	this.LogCmd("ClosePage", arguments);
	var warea=GetExecAorig(area, "ClosePage");
	ClosePage(warea, opt);
	return "";
}

Qweb_api.prototype.ClosePageReturn=function(area, opt) {
	this.LogCmd("ClosePageReturn", arguments);
	var warea=GetExecAorig(area, "ClosePageReturn");
	ClosePageReturn(warea, opt);
	return "";
}

Qweb_api.prototype.CloseAllPages=function(area, opt) {
	this.LogCmd("CloseAllPages", arguments);
	var warea=GetExecAorig(area, "CloseAllPages");
	if (opt == "TARGET") {
		var AreaDest=App.GetArea(AreaOrig.Target);
		var r=CloseAllPages(AreaDest);
	} else {
	    var r = CloseAllPages(warea, opt);
	}
	return r;
}

Qweb_api.prototype.ClosePageDelayed=function(area, opt) {
	this.LogCmd("ClosePageDelayed", arguments);
	var warea=GetExecAorig(area, "ClosePageDelayed");
	if (BrowserIE && window.event != null) {
		if (window.event.ctrlKey == true) {
			ExecCmdDelayed(8000, warea, "ClosePage(" + opt);
		} else {
			ExecCmdDelayed(1500, warea, "ClosePage(" + opt);
		}
	} else {
		ExecCmdDelayed(1500, warea, "ClosePage(" + opt);
	}
	return "";
}

Qweb_api.prototype.CloseWindow=function(area) {
	this.LogCmd("CloseWindow", arguments);
	var warea=GetExecAorig(area, "CloseWindow");
	CloseAllPages(warea);
	return "";
}

Qweb_api.prototype.MinimizeWindow=function(area) {
	this.LogCmd("MinimizeWindow", arguments);
	var warea=GetExecAorig(area, "MinimizeWindow");
	warea.Minimize();
	return "";
}

Qweb_api.prototype.RestoreWindow=function(area) {
	this.LogCmd("RestoreWindow", arguments);
	var warea=GetExecAorig(area, "RestoreWindow");
	warea.Restore();
	return "";
}

Qweb_api.prototype.Execute=function(area, tctl, p1, p2, p3) {
	this.LogCmd("Execute", arguments);
	var r=this.ExecuteInternal(area, tctl, p1, p2, p3)
	return r;
}

Qweb_api.prototype.ExecuteInternal=function(area, tctl, p1, p2, p3) {
	var warea=GetExecAorig(area, "Execute");
	var tarea = App.GetArea(tctl);
	if (tarea != null) {
		tarea.Execute(p1, p2, p3);
		return "";
	}
	if (warea.ActivePage == null) return "";
	if (tctl == warea.ActivePage.Id) {
		warea.ActivePage.Execute(p1, p2, p3);
		return;
	}
	var ctl=warea.ActivePage.GetCtl(tctl);
	if (ctl != null) ctl.Execute(p1, p2, p3);
	return "";
}

Qweb_api.prototype.ReturnVal=function(area, p0, wval) {
	this.LogCmd("ReturnVal", arguments);
	var warea=GetExecAorig(area, "ReturnVal");
	if (wval != undefined && wval != null) {
		warea.ReturnValue=wval;
		warea.ReturnProvider = "*";
	}
	ReturnVal(warea, p0);
	return "";
}

Qweb_api.prototype.Disable=function(area, tctl, tipo) {
	this.LogCmd("Disable", arguments);
	var warea=GetExecAorig(area, "Disable");
	if (tctl == "" || tctl == undefined) {
		warea.Disable(tipo);
		return "";
	}
	wpage=warea.ActivePage;
	if (wpage == null) return"";
	var wctl=null;
	if (tctl == wpage.Id) {
		wctl=wpage;
	} else {
		wctl=wpage.GetCtl(tctl);
	}
	if (wctl != null) wctl.Disable(tipo);
	return "";
}

Qweb_api.prototype.Enable=function(area, tctl, tipo) {
	this.LogCmd("Enable", arguments);
	var warea=GetExecAorig(area, "Enable");
	if (tctl == "" || tctl == undefined) {
		warea.Enable(tipo);
		return "";
	}
	wpage=warea.ActivePage;
	if (wpage == null) return"";
	var wctl=null;
	if (tctl == wpage.Id) {
		wctl=wpage;
	} else {
		wctl=wpage.GetCtl(tctl);
	}
	if (wctl != null) wctl.Enable(tipo);
	return "";
}

Qweb_api.prototype.Hide=function(area, tctl, ix) {
	this.LogCmd("Hide", arguments);
	var warea=GetExecAorig(area, "Hide");
	wpage=warea.ActivePage;
	if (wpage == null) return"";
	if (tctl == wpage.Id) {
		wpage.Hide();
	} else {
		var ctl=wpage.GetCtl(tctl);
		if (ctl !=  null) ctl.Hide(ix);
	}
	return "";
}

Qweb_api.prototype.Show=function(area, tctl, ix) {
	this.LogCmd("Show", arguments);
	var warea=GetExecAorig(area, "Show");
	wpage=warea.ActivePage;
	if (wpage == null) return"";
	if (tctl == wpage.Id) {
		wpage.Show();
	} else {
		var ctl=wpage.GetCtl(tctl);
		if (ctl !=  null) ctl.Show(ix);
	}
	return "";
}

Qweb_api.prototype.SetError=function(area, tctl, p1) {
	this.LogCmd("SetError", arguments);
	var warea=GetExecAorig(area, "SetError");
	wpage=warea.ActivePage;
	var ctl=wpage.GetCtl(tctl);
	if (ctl !=  null) {
		if (ctl.ShowErr) {
			if (p1 != "") {
				ctl.ShowErr(p1);
			} else {
				ctl.HideErr();
			}
		}
	}
	return "";
}

Qweb_api.prototype.External=function(area, p0) {
	this.LogCmd("External", arguments);
	var warea=GetExecAorig(area, "External");
	Aorig=warea;
	var Aw=p0.split(",")
	var wcmd=Aw[0] + "("
	for (var i=1; i<Aw.length; i++) {
		if (i > 1) wcmd += ", "
		wcmd += "'" + Aw[i] + "'"
	}
	wcmd += ")"
	try {eval(wcmd);}
	catch(exp) {window.alert(GetMsg(1, "Comando a executar - " + wcmd + " - invalido"));}
	return "";
}

Qweb_api.prototype.Resize=function(area, tarea, p1, p2, p3) {
	this.LogCmd("Resize", arguments);
	var warea=GetExecAorig(area, "Resize");
	if (warea.Pin == "ON") return "";
	var wtarea=GetExecAorig(tarea, "Resize");
	wtarea.AltSize(p1, p2, p3);
	return "";
}

Qweb_api.prototype.Relocate=function(area, tarea, p1, p2, p3) {
	this.LogCmd("Relocate", arguments);
	var warea=GetExecAorig(area, "Relocate");
	if (warea.Pin == "ON") return "";
	var wtarea=GetExecAorig(tarea, "Relocate");
	wtarea.AltLocation(p1, p2, p3);
	return "";
}

Qweb_api.prototype.Animate=function(area, tarea, p1) {
	this.LogCmd("Animate", arguments);
	var warea=GetExecAorig(area, "Animate");
	var ctl=App.GetArea(tarea);
	ctl.Animate(p1);
	return "";
}

Qweb_api.prototype.SetUsrNivel=function(p0) {
	this.LogCmd("SetUsrNivel", arguments);
	User.SetNivel(p0);
	return "";
}

Qweb_api.prototype.SetUsrPerm=function(p0) {
	this.LogCmd("SetUsrPerm", arguments);
	User.SetPerm(p0);
	return "";
}

Qweb_api.prototype.SetUsrAno=function(p0) {
	this.LogCmd("SetUsrAno", arguments);
	User.SetAno(p0);
	return "";
}

Qweb_api.prototype.SetUsrId=function(p0, p1) {
	this.LogCmd("SetUsrId", arguments);
	User.SetId(p0, p1);
	return "";
}

Qweb_api.prototype.SetDb=function(p0, p1) {
	this.LogCmd("SetDb", arguments);
	User.SetModDb(p0, p1);
	return "";
}

Qweb_api.prototype.SetUsrStatus=function(p0) {
	this.LogCmd("SetUsrStatus", arguments);
	User.SetStatus(p0);
	return "";
}

Qweb_api.prototype.SetVal=function(area, p0, p1, p2) {
	this.LogCmd("SetVal", arguments);
	var warea=GetExecAorig(area, "SetVal");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	if (wctl != null) {;
		if (wctl.Tipo == "FORM" || wctl.Tipo == "MULTIFORM" || wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM" || wctl.Tipo == "SEARCH") {
			wctl.StoreVal(p1, p2, null, "SHOW");
		} else {
			wctl.SetVal(p1, "SAVE");
		}
	}
	return "";
}

Qweb_api.prototype.SetList=function(area, p0, p1) {
	this.LogCmd("SetList", arguments);
	var warea=GetExecAorig(area, "SetList");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	if (wctl == null) {
		window.alert(GetMsg(1, "Comando (SetList) - Nome do controlo (" + p0 + ") invalido"));
		return "";
	}
	if (wctl.Tipo != "COMBO" && wctl.Tipo != "CALEND") {
		window.alert(GetMsg(1, "Comando (SetList) - Controlo (" + p0 + ") não é COMBO nem CALEND"));
		return "";
	}
	wctl.SetList(p1);
	return "";
}

Qweb_api.prototype.ExecRotina=function(area, p0, p1, p2, p3) {
	this.LogCmd("ExecRotina", arguments);
	var warea=GetExecAorig(area, "ExecRotina");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	if (wctl == null) {
		window.alert(GetMsg(1, "Comando (ExecRotina) - Nome da Rotina (" + p0 + ") invalido"));
		return;
	}
	wctl.Execute(p1, p2, p3);
	return "";
}

Qweb_api.prototype.ExecRotinaAsync=function(area, p0, p1, p2, p3, callback, commtimeout) {
	this.LogCmd("ExecRotinaAsync", arguments);
	var warea=GetExecAorig(area, "ExecRotina");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	if (wctl == null) {
		window.alert(GetMsg(1, "Comando (ExecRotina) - Nome da Rotina (" + p0 + ") invalido"));
		return;
	}
	wctl.Execute(p1, p2, p3, "ASYNC", callback, commtimeout);
	return "";
}

Qweb_api.prototype.ExecServerFunction=function(functionname, argsarray, typesarray, resulttype, module='') {
	this.LogCmd("ExecServerFunction", arguments);
	var warea=GetExecAorig("", "ExecRotina");
	var wpage=warea.ActivePage;
	var iblk = new Interblk();
    iblk.APP = functionname;
    iblk.IDENT = functionname;
    iblk.MOD = module;
    iblk.FUNC = "EXW";
    iblk.COND = "";
	var arg="";
	var argtype="";
	var values=new Array();
	for (var i=0; i<argsarray.length; i++) {
		arg=argsarray[i];
		argtype=typesarray[i];
		values.push(ConvertFromNative(arg, argtype, 2));
		iblk.CMPS.push("arg" + (i+1));
	}
	iblk.DADOS.push(values);
	iblk = SendServerSync(wpage, iblk);
    if (iblk.STAT != "OK") {
        this.HostPage.ShowWarning(iblk.MSG);
        return null;
    }
    var wresult = iblk.DADOS[0][0];
	wresult=ConvertToNative(wresult, resulttype);
	return wresult;
}


Qweb_api.prototype.SetPerm=function(area, p0) {
	this.LogCmd("SetPerm", arguments);
	var warea=GetExecAorig(area, "SetPerm");
	SetHistorialCmd(warea, "$perm$", p0, "EQ");
	return "";
}

Qweb_api.prototype.Display=function(p0) {
	this.LogCmd("Display", arguments);
	window.alert(p0);
	return "";
}

Qweb_api.prototype.PrintPage=function(area) {
	this.LogCmd("PrintPage", arguments);
	var warea=GetExecAorig(area, "PrintPage");
	PrintPage(warea);
	return "";
}

Qweb_api.prototype.UpdateCtls=function(area) {
	this.LogCmd("UpdateCtls", arguments);
	var warea=GetExecAorig(area, "UpdateCtls");
	UpdateCtls(warea);
	return "";
}

Qweb_api.prototype.SetPageUpdated=function(area) {
	this.LogCmd("SetPageUpdated", arguments);
	var warea=GetExecAorig(area, "SetPageUpdated");
	var wpage=warea.ActivePage;
	wpage.DidUpdate="S";
	return "";
}

Qweb_api.prototype.SetCond=function(area, p0, p1, p2) {
	this.LogCmd("SetCond", arguments);
	var warea=GetExecAorig(area, "SetCond");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	wctl.Execute("SetCond", p1, p2);
	return "";
}

Qweb_api.prototype.ExecDelayed=function(area, p0, p1, p2, p3) {
	this.LogCmd("ExecDelayed", arguments);
	var warea=GetExecAorig(area, "ExecDelayed");
	ExecCmdDelayed(2000, warea, p0 + "," + p1 + "," + p2 + "," + p3);
	return "";
}

Qweb_api.prototype.ExecDelayed200 = function(area, p0, p1, p2, p3) {
	this.LogCmd("ExecDelayed200", arguments);
    var warea = GetExecAorig(area, "ExecDelayed200");
    ExecCmdDelayed(200, warea, p0 + "," + p1 + "," + p2 + "," + p3);
    return "";
}

Qweb_api.prototype.Refresh=function(area, p0, p1) {
	this.LogCmd("Refresh", arguments);
	var warea=GetExecAorig(area, "Refresh");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(p0);
	if (wctl != null) {
		if (wctl.Tipo == "LEDIT" || wctl.Tipo == "MULTIFORM" || wctl.Tipo == "MENUSRC") {
			wctl.Activate("Refresh");
		}
	}
	return "";
}

Qweb_api.prototype.SetLanguage=function(p0) {
	this.LogCmd("SetLanguage", arguments);
	User.SetLanguage(p0);
	return "";
}

Qweb_api.prototype.IsAreaClosed=function(area, p0, p1) {
	this.LogCmd("IsAreaClosed", arguments);
	var warea=GetExecAorig(area, "IsAreaClosed");
	var ctl=App.GetArea(p0);
	if (ctl == null) {
		window.alert(GetMsg(1, "A função api.IsAreaClosed referencia uma Area inexistente"));
		return false;
	}
	if (ctl.ActivePage == null) return true;
	return false;
}

Qweb_api.prototype.ExecInterface=function(area, p0, p1, p2, p3, p4, p5, p6, p7, p8) {
	this.LogCmd("ExecInterface", arguments);
	var warea=GetExecAorig(area, "ExecInterface");
	var wp=warea.Id + "[" + p1 + "[" + p2 + "[" + p3 + "[" + p4 + "[" + p5 + "[" + p6 + "[" + p7 + "[" + p8;
	var r=window.external.Execute(p0, wp);
	SetHistorialCmd(warea, "ExecInterfaceResult", r, "EQ");
	return r;
}

Qweb_api.prototype.GetVal=function(area, ctlid, p1, p2) {
	this.LogCmd("GetVal", arguments);
	var warea=GetExecAorig(area, "GetVal");
	var wpage=warea.ActivePage;
	var ctl=wpage.GetCtl(ctlid);
	if (ctl != undefined && ctl != null) {
		return ctl.GetVal(p1, p2);
	} else {
		window.alert(GetMsg(1, "A função api.GetVal referencia um controlo (" + ctlid + ") inexistente"));
	}
	return "";
}

Qweb_api.prototype.GetDate=function(dtparm, dtref) {
	this.LogCmd("GetDate", arguments);
	return SubstData(dtparm, dtref, false);
}

Qweb_api.prototype.GetSrvDate=function(dtparm) {
	this.LogCmd("GetSrvDate", arguments);
	return SubstData(dtparm, "", true);
}

Qweb_api.prototype.GetSrvTimeDif=function() {
	this.LogCmd("GetSrvTimeDif", arguments);
	return App.ServerTimeDif;
}

Qweb_api.prototype.SelLang=function(p0) {
	this.LogCmd("SelLang", arguments);
	return SelLangTxt(p0);
}

Qweb_api.prototype.GetPageFunc=function(area) {
	this.LogCmd("GetPageFunc", arguments);
	var warea=GetExecAorig(area, "GetPageFunc");
	var wpage=warea.ActivePage;
	if (wpage != null) return wpage.Func;
	return "";
}

Qweb_api.prototype.GetRotResult=function(area, rot, p1, p2, p3) {
	this.LogCmd("GetRotResult", arguments);
	var warea=GetExecAorig(area, "GetRotResult");
	var wpage=warea.ActivePage;
	if (wpage == null) {
		window.alert(GetMsg(1, "Função (api.GetRotResult) referencia pagina inactiva"));
		return "";
	}
	var ctl=wpage.GetCtl(rot)
	if (ctl == null) {
		window.alert(GetMsg(1, "Função (api.GetRotResult) - Nome da Rotina (" + rot + ") invalido"));
		return "";
	}
	ctl.Execute(p1, p2, p3);
	return RotResult;
}

Qweb_api.prototype.GetCssClasses=function() {   //** obter uma lista de nomes de classes css separados por {.  O qweb_develop.js tem que estar presente
	this.LogCmd("GetCssClasses", arguments);
	if (DevelopModule != true) return "";
	return GetCssClassList();
}

Qweb_api.prototype.GetImgList=function(opt) {   //** obter uma lista de nomes de ficgeiros de imagens separados por {.  O qweb_develop.js tem que estar presente.  opt=//IMG/ICO/TEMA
	this.LogCmd("GetImgList", arguments);
	if (DevelopModule != true) return "";
	return GetImgList(opt);
}

Qweb_api.prototype.GetInterfaceId=function() {   //** obter o Id do interface a ser utilizado: QWEB / QWIN /QADDINOL ....
	this.LogCmd("GetInterfaceId", arguments);
	return InterfaceId;
}

Qweb_api.prototype.GetUserMessage=function(id) {   //** obter mensagem com o id especificado na lingua corrente
	this.LogCmd("GetUserMessage", arguments);
	return GetUserMessage(id);
}

//RMR(2018-11-14) - Sets the user status as the given
Qweb_api.prototype.SetUserStatus = function (status) {
    User.SetStatus(status);
}

//RMR(2018-11-14) - Gets the user current status
Qweb_api.prototype.GetuserStatus = function () {
    return User.Status;
}

Qweb_api.prototype.GetUserId=function() {   //** obter o Id de Login do utilizador
	this.LogCmd("GetUserId", arguments);
	return User.UserId;
}

Qweb_api.prototype.GetUserName=function() {   //** obter o nome do utilizador do Login
	this.LogCmd("GetUserName", arguments);
	return User.UserName;
}

Qweb_api.prototype.GetUserAno=function() {
	this.LogCmd("GetUserAno", arguments);
	var wano=User.Ano
	if (wano == 0) wano=""
	return wano
}


Qweb_api.prototype.SetModulo=function(area, modulo) {   //** gravar o modulo na Area
	this.LogCmd("SetModulo", arguments);
	var warea=GetExecAorig(area, "SetModulo");
	warea.Modulo=modulo;
	if (warea.ActivePage != null) warea.ActivePage.Modulo=modulo;
	return "";
}

Qweb_api.prototype.GetNivel=function(area, modulo) {   //** obter nivel do utilizador para o modulo da area corrente ou para o modulo indicado
	this.LogCmd("GetNivel", arguments);
	var warea=GetExecAorig(area, "GetNivel");
	if (modulo != undefined && modulo != "") return User.GetNivel(modulo);
	return User.GetNivel(warea.Modulo);
}

Qweb_api.prototype.GetTextSize=function(area, ctl, maxwidth, maxheight) {   //**obter o tamanho que o controlo teria que ter para exibir o seu conteúdo sem scrollbars
	this.LogCmd("GetTextSize", arguments);
	var warea=GetExecAorig(area, "GetTextSize");
	var wpage=warea.ActivePage;
	var wctl=wpage.GetCtl(ctl);
	if (wctl == null) return null;
	if (wctl.Tipo != "TEXT" && wctl.Tipo == "LABEL") return null; 
	var wtxt=""
	var wclasse=""
	wtxt=wctl.GetVal()
	wclasse=wctl.Htxt.className
	var wdiv = document.createElement("DIV")
	wdiv.style.outlineStyle="none"
	wdiv.id="divgettextsize"
	document.body.appendChild(wdiv)
	wdiv.style.zIndex=-50
	wdiv.style.display="inline-block"
	wdiv.style.whiteSpace="pre-wrap"
	wdiv.style.overflow="auto"
	wdiv.style.width="auto"
	wdiv.style.height="auto"

	if (maxwidth != undefined) {
		wdiv.style.maxWidth=maxwidth + "px"
	}
	if (maxheight != undefined) {
		wdiv.style.maxHeight=maxheight + "px"
	}

	wdiv.className=wclasse
	wdiv.innerHTML=wtxt
	var w=wdiv.offsetWidth
	var h=wdiv.offsetHeight
	/*
	if (maxwidth != undefined) {
		if (w > maxwidth) wdiv.style.width=maxwidth + "px"
	}
	if (maxheight != undefined) {
		if (h > maxheight) wdiv.style.height=maxheight + "px"
	}
	var w=wdiv.offsetWidth
	var h=wdiv.offsetHeight
	*/
	document.body.removeChild(wdiv);
	wdiv=null
	var r=new Array()
	r.push(w)
	r.push(h)
	return r;
}

Qweb_api.prototype.DoDownload=function(url, opt) {   //** fazer o download do ficheiro indicado no url.  Se opt="DoNotOpen" faz download sem abrir (IE não suporta)
	this.LogCmd("DoDownload", arguments);

	if (opt == "DoNotOpen") {
		var link = document.createElement('a');
		if (link.download !== undefined) { //saber se suporta o atributo download. Se sim o ficheiro será downloaded sem ser aberto
			link.target="_blank";
		    link.href = url;
			var fileName = url.substring(url.lastIndexOf('/') + 1, url.length); 
			link.download = fileName; 

		    if (document.createEvent) {
		        var e = document.createEvent('MouseEvents');
		        e.initEvent('click' ,true ,true);
		        link.dispatchEvent(e);
		        return;
		    }
		} else {
			link=null;
			window.open(url, "_blank");
		}
	} else {
		window.open(url, "_blank");
	}
}

Qweb_api.prototype.SequentialExec=function() {   //** fazer o execute sequencial dos varios comandos que são dados como argumentos de cada vez que a função é invocada
	this.LogCmd("SequentialExec", arguments);
	var execindex=qApi.GetHist("", "SequentialExec_index", "EQ");
	if (execindex == "") 
		execindex="0";
	else 
		execindex=Number(execindex) + 1;
	
	if (execindex < arguments.length) {
		var wact=arguments[execindex]
		qApi.SetHistorial("", "SequentialExec_index", execindex, "EQ")
		ExecCmd("",wact);
	} else {
		qApi.SetHistorial("", "SequentialExec_index", "", "EQ")
	}
	return "";
}

Qweb_api.prototype.GetMenuList = function (area, ctl, idstart, all) {   //** obter lista de entradas de MENUSRC autorizadas dependentes de idstart ou do 1º nivel de omitido ou vazio. Retorna lista de ids separados por ; Com all retorna todos os dependentes até ao ultimo nivel
	this.LogCmd("GetMenuList", arguments);
    var warea = GetExecAorig(area, "GetMenuList");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando GetMenuList sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MENUSRC") {
        window.alert(GetMsg(1, "Comando GetMenuList sobre controlo (" + ctl + ") de tipo diferente de MENUSRC."));
        return "";
    }
    return wctl.GetIds(idstart, all)
}

Qweb_api.prototype.ExecMenu=function(area, ctl, idexec) {   //** executar entrada de MENUSRC com id=idexec como se tivesse sido seleccionada pelo utilizador
	this.LogCmd("ExecMenu", arguments);
    var warea = GetExecAorig(area, "ExecMenu");
    wpage = warea.ActivePage;
    var wctl = wpage.GetCtl(ctl);
    if (wctl == null) {
        window.alert(GetMsg(1, "Comando ExecMenu sobre controlo (" + ctl + ") invalido."));
        return "";
    }
    if (wctl.Tipo != "MENUSRC") {
        window.alert(GetMsg(1, "Comando ExecMenu sobre controlo (" + ctl + ") de tipo diferente de MENUSRC."));
        return "";
    }
	return wctl.NavigateToId(idexec)
}

Qweb_api.prototype.Base64YEncode=function(str) {   //** retorna a string encoded em BASE64 com a substituição dos caracteres "+=/" em ".-_"
	var stro=BASE64.encode(str);
	stro = stro.replace(/[\+=\/]/g, function(match){
        switch(match){
            case "+": return ".";
            case "=": return "-";
            case "/": return "_";
        }
    });
	return stro;
}

Qweb_api.prototype.Base64YDecode=function(str) {   //** retorna a descodificação da string em BASE64 com a substituição dos caracteres "+=/" em ".-_"
	var stro=str.replace(/[\._\-]/g, function(match){
        switch(match){
            case ".": return "+";
            case "-": return "=";
            case "_": return "/";
        }
    });
	stro=BASE64.decode(stro);
	return stro;
}



Qweb_api.prototype.LoadCssFile=function(fname) {   //** carregar ficheiro de css    o nome do ficheiro fica   XXX.fname.css  em que XXX é o id da Aplicação
	this.LogCmd("LoadCssFile", arguments);
	var cssfile=App.Id
	if (fname != "" && fname != undefined) cssfile += "." + fname
	cssfile += ".css"
	var fileref=document.createElement("link")
	fileref.setAttribute("rel", "stylesheet")
	fileref.setAttribute("type", "text/css")
	fileref.setAttribute("href", cssfile)
	if (typeof fileref!="undefined") document.getElementsByTagName("head")[0].appendChild(fileref)
	return "";
}

Qweb_api.prototype.UnloadCssFile=function(fname) {   //** descarregar ficheiro de css    o nome do ficheiro fica   XXX.fname.css  em que XXX é o id da Aplicação
	this.LogCmd("UnloadCssFile", arguments);
	var cssfile=App.Id
	if (fname != "" && fname != undefined) cssfile += "." + fname
	cssfile += ".css"
	var Alinks=document.getElementsByTagName("link")
	for (var i=Alinks.length; i>=0; i--) { //procurar de tras para a frente a ver se encontra
		if (Alinks[i] && Alinks[i].getAttribute("href") != null && Alinks[i].getAttribute("href").indexOf(cssfile) != -1) Alinks[i].parentNode.removeChild(Alinks[i]);
	}
	return "";
}

Qweb_api.prototype.ShowWaitSign=function(area) {
	this.LogCmd("ShowWaitSign", arguments);
	var warea=GetExecAorig(area, "ShowWaitSign");
	warea.ShowWaitSign="S";
	return "";
}

Qweb_api.prototype.HideWaitSign=function(area) {
	this.LogCmd("HideWaitSign", arguments);
	var warea=GetExecAorig(area, "HideWaitSign");
	warea.ShowWaitSign="N";
	return "";
}
