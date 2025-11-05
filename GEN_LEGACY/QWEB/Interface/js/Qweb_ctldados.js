//*************** Web Player para Aplicações Quidgest *****************
//**             Modulo de Controlos e Rotinas de Dados              **
//**                                                                 **
//**                           versão 3.00                           **
//*********************************************************************

//***************************************************************** QFORM - define Form
function Qform(xnod, hostpage) {
	this.Tipo="FORM";
	this.Class="DATA";
	this.HostPage=hostpage;
	this.Id=GetAtt(xnod, "ID", "");
	if (this.Id == "") {
		this.Id="Form" + this.HostPage.CtlCount;
		this.HostPage.CtlCount ++;
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a FORM(" + this.Id + ") Invalido"));
		return;
	}
	this.Msgctl=GetAtt(xnod, "MSGCTL", "");
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S");
	this.Cond="";
	this.Cols=new Array();
	this.Dados=new Array();
	this.Val=GetAtt(xnod, "VAL", "");
	this.Events=new Array();
	this.Botoes=new Array();
	this.KeyIndex=0;
	this.Limitedctls=new Array();
	this.Limiterctls=new Array();
	this.LimitsUsed=0;
	this.LimitConds=new Array();
	this.LimitCond="";
	this.Updatectls=new Array();
	this.Status="";
	this.ExecOpt = "";
	this.UpdatePending = false;
    this.Refreshable=false;
    this.LeditsUsed=new Array();
    this.EventFired=false;  //to ensure that AFTERREADCOMPLETE and AFTERINSERTCOMPLETE events fire only once
	var xn=xnod.firstChild;
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn);
			this.Cols.push(wcol);
			var wval=GetAtt(xn, "DEFVAL", "");
			if (wcol.Type == "D") wval=SubstData(wval);
			this.Dados.push(wval);
			if (wcol.Key == "S") this.KeyIndex=this.Cols.length - 1;
            if (wcol.Refresh == "S") this.Refreshable=true;
			if (wcol.Limitctl != "") {
				this.LimitConds.push("");
				var jaexiste=false;
				for (var i=0; i<this.Limiterctls.length; i++) {
					if (wcol.Limitctl == this.Limiterctls[i]) {
						jaexiste=true;
						break;
					}
				}
				if (jaexiste == false) this.Limiterctls.push(wcol.Limitctl);
			}
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn);
			this.Events.push(wevent);
		}
		xn=xn.nextSibling;
	}
	this.HostFunc=GetAtt(xnod, "FUNC", this.HostPage.Func);
	if (this.HostFunc == "") this.HostFunc="VIS";
	this.Func="";
	if (this.HostFunc == "" || this.HostFunc == "VIS" || this.HostFunc == "ALT" || this.HostFunc == "ELI") {
		this.Func = "GET1";
	} else {
    	if (this.HostFunc == "EXE") {
			this.Func = "EXR";
		} else {
			this.Func = this.HostFunc;
			//if (this.Provider == "*") this.Func="GET1"
		}
	}
}

Qform.prototype.Activate=function(opt) {
	if (opt == "INIT") {
		if (this.Limiterctls.length > 0 || this.Autostart == "N") return;
	}
	this.Send();
}

Qform.prototype.Execute = function(act, parm) {
    if (act == "Cancel" || act == "CancelAuto") {
        if (this.Provider != "*") {
            if (this.HostFunc == "INS" || this.HostFunc == "DUP") {
                this.Func = "CAN";
                this.ExecOpt = act;
                this.Send();
                return;
            }
        } else {
            this.UpdatePending = false;
            return;
        }
        if (act != "CancelAuto") ClosePage(this.HostPage.Area)
        return;
    }
    if (act == "Upload") {
        wctlobj = this.HostPage.GetCtl(parm);
        wctlobj.Execute("Upload", 0, 0);
        return;
    }
    if (act == "Delayed" || parm == "Delayed") {
        var wcmd = "Execute(" + this.Id;
        if (act != "" && act != "Delayed") wcmd += "," + act;
        ExecCmdDelayed(1000, this.HostPage.Area, wcmd);
        return;
    }
    if (act == "ImportInfo") {
        var wp = this.HostPage.Area.Id + "[" + parm;
        var r = window.external.Execute("IMPORTINFO", wp);
        var Arec = r.split("{");
        for (var i = 0; i < this.Cols.length; i++) {
            var col = this.Cols[i];
            if (col.Idx != "") {
                var widx = col.Idx + "[";
                for (var r = 0; r < Arec.length; r++) {
                    if (Arec[r].indexOf(widx) == 0) {
                        var ix = Arec[r].indexOf("[");
                        this.Dados[i] = Arec[r].substr(ix + 1);
                        for (var c = 0; c < col.ColCtls.length; c++) {
                            var wctl = col.ColCtls[c];
                            wctl.SetVal(this.Dados[i]);
                        }
                        break;
                    }
                }
            }
        }
        return;
    }
    if (act == "Refresh") {
        if (this.Refreshable == false) return;
        this.SendRefresh();
        return;
    }
    if (this.HostFunc == "VIS") {
        ClosePage(this.HostPage.Area);
        return;
    }
    if (this.HostFunc == "ALT") this.Func = "ALT";
    if (this.HostFunc == "ELI") this.Func = "ELI";
    if (this.HostFunc == "INS" || this.HostFunc == "DUP") this.Func = "ALT";
    if (this.HostFunc == "EXE") this.Func = "EXW";

    if (this.Func == "ALT") {      // validar campos incluindo obrigatoriedade
        for (var i = 0; i < this.Cols.length; i++) {
            var col = this.Cols[i];
            var msg = ValidarCol(col, this.Dados[i], "OBRIG");
            if (msg != "") {
                for (var c = 0; c < col.ColCtls.length; c++) {
                    var wctl = col.ColCtls[c];
                    if (wctl.Tipo == "TEXT" || wctl.Tipo == "COMBO" || wctl.Tipo == "CHECK" || wctl.Tipo == "RADIO" || wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM") {
                        wctl.ShowErr(msg);
                    }
                }
                window.alert(msg);
                return;
            } else {
                for (var c = 0; c < col.ColCtls.length; c++) {
                    var wctl = col.ColCtls[c];
                    if (wctl.Tipo == "TEXT" || wctl.Tipo == "COMBO" || wctl.Tipo == "CHECK" || wctl.Tipo == "RADIO" || wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM") {
                        wctl.HideErr();
                    }
                }
            }
        }
        //Verificar se ha evento para validação
        for (var i = 0; i < this.Events.length; i++) {
            if (this.Events[i].Id == "ONVALIDATE") {
                ExecCmd(this.HostPage.Area, this.Events[i].Act);
            }
        }
        if (RotStatus != "OK") {
            var wmsg = "";
            if (RotMsg != "") {
                wmsg = SelLangTxt(RotMsg);
            }
            if (RotMsgId != "") {
                wmsg = GetUserMessage(RotMsgId);
            }
            if (RotStatus.indexOf("W") > -1 && wmsg != "") window.alert(wmsg);
            if (RotStatus == "E" || RotStatus == "EW") {
                if (wmsg == "") wmsg = GetMsg(23);
                window.alert(wmsg);
                return;
            }
        }
    }
    this.ExecOpt = act;
    this.Send();
}

Qform.prototype.Send=function() {
	if (this.Provider == "") return;
	if (this.Func == "GET1" || this.Func == "EXR") {
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "BEFOREREAD") {
				ExecCmd(this.HostPage.Area, this.Events[i].Act);
			}	
		}	
	} else {
		for (var i=0; i<this.Events.length; i++) {
			if (this.Func == "ALT" || this.Func == "ELI" || this.Func == "EXW") {
				if (this.Events[i].Id == "BEFOREUPDATE") {
					ExecCmd(this.HostPage.Area, this.Events[i].Act);
				}
			} else {
				if (this.Func == "INS" || this.Func == "DUP") {  //FHC 2017/11/13  não fazia beforeinsert no DUP
					if (this.Events[i].Id == "BEFOREINSERT") {
						ExecCmd(this.HostPage.Area, this.Events[i].Act);
					}	
				}
			}
		}
	}
	var iblk=new Interblk();
	iblk.APP=this.Provider;
	iblk.IDENT=this.Id;
	iblk.MOD=User.GetModDb(this.HostPage.Modulo);
	iblk.FUNC=this.Func;
	iblk.COND="";
	if (this.HostPage.GetTipoPag() == "FORM") iblk.COND=CondDecode(this.HostPage.Cond);
	var histgetid="";
	var histop="";
	var hix=-1;
	var area=this.HostPage.Area;
	var niv=area.Pages.length;
    var wrec=new Array();
    var wval="";
	for (var i=0; i<this.Cols.length; i++) {
        wval="";
		var col=this.Cols[i];
        if (col.Send != "N") iblk.CMPS.push(col.Id)
        if (this.Func != "CAN" && this.Func != "ELI") wval=this.Dados[i];
		histgetid=col.HistGetId;
		histop=col.HistOp;
		if (histgetid != "") {
			if (histop == "BL") {
				hix=GetHistorialIndex(area, histgetid, "GE");
				if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "GE");
				hix=GetHistorialIndex(area, histgetid, "LE");
				if (hix > -1 && area.Historial[hix].Valor != "") iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", "LE");
			} else {
				hix=GetHistorialIndex(area, histgetid, histop);
				if (hix > -1 && area.Historial[hix].Valor != "") {
					iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, area.Historial[hix].Valor, "", histop);
					if (this.Func == "INS" || this.Func == "EXW") {   //o EXW tb passou a obter valores
						wval=area.Historial[hix].Valor;
					}
					if (area.Historial[hix].Nivel < niv) {
						for (var c=0; c<col.ColCtls.length; c++) {
							col.ColCtls[c].Disable("HIST")  //fazer o disable de todos os controlos com entrada no historial em níveis anteriores
						}
					}
				}
			}
		}
        if (col.Send != "N") wrec.push(wval);
	}
    iblk.DADOS.push(wrec);
	if (iblk.COND == "" && this.HostPage.Key != "") {  // ver se ha um KEY usada na invocação da pagina para ser usada como chave
		var col=this.Cols[this.KeyIndex];
		iblk.COND=AppendCond("", col.Id, col.Type, this.HostPage.Key, "", "EQ");
	}
	if (this.LimitCond != "") {
		if (iblk.COND != "") iblk.COND += "{";
		iblk.COND += this.LimitCond;
	}
	if (this.Cond != "") {
		if (iblk.COND != "") iblk.COND += "{";
		iblk.COND += this.Cond;
	}
	if (this.Provider == "*") {  //simula a ida ao servidor no caso de o provider ser *
		iblk.STAT="OK";
		if (this.HostPage.Key != "" && this.Func == "GET1" && this.FirstDataCtl == true) {  //não sei onde isto é usado mas coloquei a condição de FirstDataCtl para apenas ser usado nessas circunstancias
			var re=/;/g;
            var wrec=this.HostPage.Key.replace(re, "[");
            wrec=wrec.split("[")
			iblk.DADOS=new Array()
            iblk.DADOS.push(wrec)
		}
		if (this.Val != "") {
			this.InsertVal();
		}
		this.Receive(iblk, "OK");
		return;
	}
	if (this.HostPage.Id == "QwAutoLogon") {
		var oblk=SendServerSync(this.HostPage, iblk);
		this.Receive(oblk, "OK");
		return;
	}
	SendServer(this.HostPage, iblk, "FIRST");
	if (this.Updatectls.length > 0 && (this.Func == "ALT" || this.Func == "ELI" || this.Func == "EXW")) {
		for (var i=0; i<this.Updatectls.length; i++) {
			this.Updatectls[i].Execute("");
		}
	}
	SendServer(this.HostPage, null, "END");
}

Qform.prototype.Receive = function(iblk, gstatus) {
    if (this.ExecOpt == "Refresh") {
        this.ReceiveRefresh(iblk, gstatus);
        return;
    }
    var fezupdate = false;
    if (iblk.STAT != "E" && iblk.STAT != "EW") {
	    if (this.Func == "ALT" || this.Func == "ELI" || this.Func == "EXW") {
	        this.HostPage.UpdatePending = false;
	        this.UpdatePending = false;
	        fezupdate = true;
	    }
    	if (this.Func == "CAN") {
        	this.HostPage.UpdatePending = false;
        	this.UpdatePending = false;
    	} else {
	    	if ((this.Func == "INS" || this.Func == "DUP") && this.HostPage.UpdateStatus == "S") this.HostPage.UpdatePending=true;
            var wrec=iblk.DADOS[0];
            if (wrec == undefined || wrec == null) wrec=new Array();
	        for (var i = 0; i < this.Cols.length; i++) {
	            this.Cols[i].Status = "";
                if (i <= wrec.length) {
                    this.Dados[i]=wrec[i];
                    if (wrec[i] == undefined || wrec[i] == null) this.Dados[i]="";
                } else {
                    this.Dados[i]="";
                }
	            var wcol = this.Cols[i];
                //se a COL tiver FUNCTIONID é porque tem que ser calculada
                if (wcol.FunctionId != "") {
                    this.CalcColFunction(wcol, i);
                }
	            SetHistorial(this.HostPage.Area, wcol, this.Dados[i]);  //o SetHistorial é para todas as colunas, o nome com que fica depende se tem HISTID ou não
	            var temdownload = false;
	            for (var c = 0; c < wcol.ColCtls.length; c++) {
	                var wctl = wcol.ColCtls[c];
	                if (wctl.Tipo == "IMG" || wctl.Tipo == "DOC") temdownload = true;
                    //os LEDITs vão ser alimentados mais tarde, após AFTERREAD ou AFTERINSERT
	                if (wctl.Tipo != "LEDITUNIT") wctl.SetVal(FormatCol(wcol, this.Dados[i], "user"));
	                if (this.HostFunc == "VIS" || this.HostFunc == "ELI") wctl.Disable("VIS");
	            }
	            if (temdownload == true && this.Dados[i] != "") this.Dados[i] = "*" + this.Dados[i];
	        }
            /*  Isto vai sair daqui para depois dos eventos de AFTERREAD ou AFTERINSERT
	        for (var i = 0; i < this.Limitedctls.length; i++) {
	            this.Limitedctls[i].SetLimit(this);
	        }
            */
        }
    }
    if ((iblk.STAT == "OK" || iblk.STAT == "W") && gstatus == "OK") {
        this.Status = "OK";
        //os dados ja estão lidos, ver se há ROTINAs a executar
        if (this.Func == "GET1" || this.Func == "EXR" || this.Func == "INS" || this.Func == "DUP") this.VerifRotina()
        this.SetMsg(iblk.MSG);
        switch (this.Func) {
            case "GET1":
                if (this.HostFunc == "ALT") this.SetMsg(GetMsg(9));
                if (this.HostFunc == "ELI") this.SetMsg(GetMsg(10));
                break;
            case "INS":
                this.SetMsg(GetMsg(11));
                break;
            case "DUP":
                this.SetMsg(GetMsg(11));
                break;
            case "ELI":
                this.SetMsg(GetMsg(12));
                break;
            case "ALT":
                if (this.HostFunc == "ALT") this.SetMsg(GetMsg(13));
                if (this.HostFunc == "INS") this.SetMsg(GetMsg(14));
                if (this.HostFunc == "DUP") this.SetMsg(GetMsg(14));
                break;
            case "EXR":
                this.SetMsg(GetMsg(15));
                break;
        }
        if (iblk.STAT == "W") this.HostPage.ShowWarning(iblk.MSG);
    } else {
        this.Status = "ERR";    //as  ROTINAs q tenham como ARG uma coluna do form passam a perguntar pelo Status OK ou ERR
        this.SetMsg(iblk.MSG);
        if (iblk.STAT == "OK" && gstatus != "OK") this.SetMsg(GetMsg(16));
        if (iblk.STAT == "EW") this.HostPage.ShowWarning(iblk.MSG);
    }
    if (this.Status == "OK") {
        if (this.Func == "GET1" || this.Func == "EXR") {
            for (var i = 0; i < this.Events.length; i++) {
                if (this.Events[i].Id == "AFTERREAD") {
                    ExecCmd(this.HostPage.Area, this.Events[i].Act);
                }
            }
        } else {
            if (this.Func == "ALT" || this.Func == "ELI" || this.Func == "EXW") {
                for (var i = 0; i < this.Events.length; i++) {
                    if (this.Events[i].Id == "AFTERUPDATE") {
                        ExecCmd(this.HostPage.Area, this.Events[i].Act);
                    }
                }
            } else {
                if (this.Func == "INS" || this.Func == "DUP") {
                    for (var i = 0; i < this.Events.length; i++) {
                        if (this.Events[i].Id == "AFTERINSERT") {
                            ExecCmd(this.HostPage.Area, this.Events[i].Act);
                        }
                    }
                }
            }
        }
        if (this.Func != "CAN" && (this.Func != "ALT" || this.Func == "ALT" && this.ExecOpt == "NoClose") && this.Func != "ELI" && this.Func != "EXW") {  //não é preciso posicionar LEDITs ou outros controlos limitados se o form já executou correctamente (desde que seja sem NoClose) ou foi cancelado. 
            //verificar se existem LEDITs / LEDITMs para posicionar
            for (var i = 0; i < this.Cols.length; i++) {
                var wcol = this.Cols[i];
                for (var c = 0; c < wcol.ColCtls.length; c++) {
                    var wctl = wcol.ColCtls[c];
                    if (wctl.Tipo == "LEDITUNIT") wctl.SetVal(FormatCol(wcol, this.Dados[i], "user"));
                }
            }
            //verificar se existem controlos limitados depois de tudo o resto, ou seja, rotinas com triggers e eventos AFTERREAD ou AFTERINSERT
            for (var i = 0; i < this.Limitedctls.length; i++) {
                this.Limitedctls[i].SetLimit(this);
            }
        }
    }
    if (this.Func == "ALT" || this.Func == "ELI" || this.Func == "EXW") {  //***** o Form foi executado
        this.HostPage.Area.ReturnValue = "";
        this.HostPage.Area.ReturnProvider = "";
        if (this.Status == "OK") {
            this.HostPage.DidUpdate = "S";
            if (this.Func == "ALT") {
                this.HostPage.Area.ReturnValue = this.Dados[this.KeyIndex];
                this.HostPage.Area.ReturnProvider = this.Provider;
            }
            if (this.ExecOpt != "NoClose") {
                for (var b = 0; b < this.Botoes.length; b++) {
                    this.Botoes[b].Disable("UPDATE");
                }
            }
            if (this.ExecOpt == "UpdateCtls") {
                ExecCmd(this.HostPage.Area, "ClosePageDelayed(UpdateCtls");
            } else {
                if (this.ExecOpt == "KeepHist") {
                    ExecCmd(this.HostPage.Area, "ClosePageDelayed(KeepHist");
                    this.ExecOpt = "";
                    return;
                }
                if (this.ExecOpt != "NoClose") {
                    if (this.Func == "EXW") {
                        if (this.Autostart == "S") ExecCmdDelayed(100, this.HostPage.Area, "ClosePage(");
                    } else {
                        if (this.HostPage.FuncIni == "INS_REP") {
                            ExecCmd(this.HostPage.Area, "ClosePageDelayed(ReloadPage");
                        } else {
                            ExecCmd(this.HostPage.Area, "ClosePageDelayed(");
                        }
                    }
                }
            }
        }
    } else {
        if (this.Func == "CAN") {
            if (this.ExecOpt != "CancelAuto") {
                if ((iblk.STAT == "OK" || iblk.STAT == "W") && gstatus == "OK") {
                    if (this.HostPage.FuncIni == "INS_REP") this.HostPage.DidUpdate = "S";  //o INS_REP acaba com um CAN mas foi inserindo portanto tem que se considerar que houve update
                    ClosePage(this.HostPage.Area);
                } else {
                    this.Func == "ALT";
                }
            }
        }
    }
    this.ExecOpt = "";
}


Qform.prototype.SendRefresh=function() {  //Faz um pedido ao servidor de Get1 apenas para as colunas marcadas com Refresh="S" para Somas relacionadas
    if (this.Provider == "") return;
    var iblk=new Interblk();
    iblk.APP=this.Provider;
    iblk.IDENT=this.Id;
    iblk.MOD=User.GetModDb(this.HostPage.Modulo);
    iblk.FUNC="GET1";
    iblk.COND="";
    if (this.HostPage.GetTipoPag() == "FORM") iblk.COND=CondDecode(this.HostPage.Cond);
    var histgetid="";
    var histop="";
    var hix=-1;
    var area=this.HostPage.Area;
    var wrec=new Array();
    var wval="";
    for (var i=0; i<this.Cols.length; i++) {
        wval="";
        var col=this.Cols[i];
        if (col.Refresh == "S" || col.Key == "S") {
            if (col.Send != "N") {
                iblk.CMPS.push(col.Id);
                wrec.push("");
            }
        }
        if (col.Key == "S") {
            iblk.COND=AppendCond(iblk.COND, col.Id, col.Type, this.Dados[i], "", "EQ");
        }
    }
    iblk.DADOS.push(wrec);
    this.ExecOpt="Refresh";
    SendServer(this.HostPage, iblk, "SINGLE");
}

Qform.prototype.ReceiveRefresh = function(iblk, gstatus) {
    this.Func="GET1";
    var wcol="";
    var ix=0;
    if (iblk.STAT != "E" && iblk.STAT != "EW") {
        var wrec=iblk.DADOS[0]
        for (var i = 0; i < this.Cols.length; i++) {  //povoar o dataset apenas com os dsados das colunas pedidas no Refresh
            wcol=this.Cols[i];
            if (wcol.Key == "S") ix++;
            if (wcol.Refresh == "S") {
                wcol.Status = "";
                this.Dados[i]=wrec[ix];
                if (wcol.FunctionId != "") {
                    this.CalcColFunction(wcol, i);
                }
                ix++;
                SetHistorial(this.HostPage.Area, wcol, this.Dados[i]);  //o SetHistorial é para todas as colunas, o nome com que fica depende se tem HISTID ou não
                var temdownload = false;
                for (var c = 0; c < wcol.ColCtls.length; c++) {
                    var wctl = wcol.ColCtls[c];
                    if (wctl.Tipo == "IMG" || wctl.Tipo == "DOC") temdownload = true;
                    wctl.SetVal(FormatCol(wcol, this.Dados[i], "user"));
                }
                if (temdownload == true && this.Dados[i] != "") this.Dados[i] = "*" + this.Dados[i];
            }
        }
        //os dados ja estão lidos, ver se há ROTINAs a executar
        this.VerifRotina()
    }
    if ((iblk.STAT == "OK" || iblk.STAT == "W") && gstatus == "OK") {
        this.Status = "OK";
        if (iblk.STAT == "W") this.HostPage.ShowWarning(iblk.MSG);
        for (var i = 0; i < this.Events.length; i++) {
            if (this.Events[i].Id == "AFTERREFRESH") {
                ExecCmd(this.HostPage.Area, this.Events[i].Act);
            }
        }
    } else {
        this.Status = "ERR";
        this.SetMsg(iblk.MSG);
        if (iblk.STAT == "EW") this.HostPage.ShowWarning(iblk.MSG);
    }
    this.ExecOpt = "";
}

Qform.prototype.TestComplete=function() {  //test if all LEDITs have completed their cycle for triggering AFTERREADCOMPLETE or AFTERINSERTCOMPLETE events
    if (this.EventFired == true) return;
    for (var i=0; i < this.LeditsUsed.length; i++) {
        var wledit=this.LeditsUsed[i];
        if (wledit.Units[0] != undefined) {
            if (wledit.Units[0].Status != "OK") return;
        }
    }
    this.EventFired=true;
    for (var i = 0; i < this.Events.length; i++) {
        if (this.Events[i].Id == "AFTERREADCOMPLETE" && this.Func == "GET1") {
            ExecCmd(this.HostPage.Area, this.Events[i].Act);
        }
        if (this.Events[i].Id == "AFTERINSERTCOMPLETE" && this.Func == "INS") {
            ExecCmd(this.HostPage.Area, this.Events[i].Act);
        }
    }
}

Qform.prototype.SaveHistorial=function() {  //Guarda os dados do form no historial para estarem disponíveis para páginas abertas a partir desta
    for (var i = 0; i < this.Cols.length; i++) {
        var wcol = this.Cols[i];
        SetHistorial(this.HostPage.Area, wcol, this.Dados[i]);  //o SetHistorial é para todas as colunas, o nome com que fica depende se tem HISTID ou não
    }
}

Qform.prototype.CalcColFunction = function(col, ix) {
    var Aargs=col.FunctionArgs.split("[");
    var wcmd="var valcol=" + col.FunctionId + "(";
    for (var i=0; i<Aargs.length; i++) {
        if (i > 0) wcmd += ", ";
        wcmd += "wvals[" + i + "]";
    }
    wcmd += ")";
    var wvals=new Array();
    for (var c=0; c<this.Cols.length; c++) {
        for (var i=0; i<Aargs.length; i++) {
            if (this.Cols[c].Id == Aargs[i]) {
                wvals[i]=ConvertToNative(this.Dados[c], this.Cols[c].Type);
            }
        }
    }
    try {eval(wcmd)}
    catch(exp) {window.alert(GetMsg(1, "Erro na avaliação da Col (" + col.Id + ") - FunctionId (" + col.FunctionId + ") - " + exp.message));
        return;}
    this.Dados[ix]=ConvertFromNative(valcol, col.Type, col.Dec);
}

Qform.prototype.VerifRotina=function() {
	//verificar se ha rotinas a testar para execução
	if (this.Cols == undefined) return;  //o form ja foi fechado
	var Arotinas=new Array();
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i];
		for (var f=0; f<col.Formulas.length; f++) {
			var encontrou=false;
			for (var r=0; r<Arotinas.length; r++) {
				if (col.Formulas[f] == Arotinas[r]) {
					encontrou = true;
					break;
				}	
			}
			if (encontrou == false) Arotinas.push(col.Formulas[f]);
		}
	}
	for (var r=0; r<Arotinas.length; r++) {
		Arotinas[r].TestExec(this.Id);
	}
}

Qform.prototype.InsertVal=function() {
	var Adad=this.Val.split("[");
	for (var i=0; i<this.Cols.length; i++) {
		this.Cols[i].Status="";
		if (i < Adad.length) {
			this.Dados[i]=Adad[i];
		} else {
			this.Dados[i]="";
		}
	}
	this.Val="";
	this.Status="OK";
}

Qform.prototype.SetMsg=function(txt) {
	if (this.Msgctl != "") {
		var ctl=this.HostPage.GetCtl(this.Msgctl);
		if (ctl != null) ctl.SetVal(txt);
	}	
}

Qform.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i;
		}
	}
	return null;
}

Qform.prototype.GetVal=function(ix) {
	if (ix >=0 && ix < this.Cols.length) {
		return this.Dados[ix];
	}
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == ix) {
			return this.Dados[i];
		}
	}
	return "";
}

Qform.prototype.StoreVal = function(fld, valor, ctl, opt) {
    if (fld >= 0 && fld < this.Cols.length) {
        var ix = fld;
    } else {
        var ix = this.GetColIndex(fld);
        if (ix == null) return;
    }
    if (valor == this.Dados[ix]) return;
    this.Dados[ix] = valor;
    var wcol = this.Cols[ix];
    wcol.Status = "M";
    if (this.Provider != "*" && this.HostPage.UpdateStatus == "S") this.HostPage.UpdatePending=true;
    if (opt == "SHOW") {
        for (var c = 0; c < wcol.ColCtls.length; c++) {
            var wctl = wcol.ColCtls[c];
            if (wctl.Tipo == "IMG" || wctl.Tipo == "DOC") temdownload = true;
            //wctl.SetVal(valor);  FHC 5/2/2018  should set user format
            wctl.SetVal(FormatCol(wcol, valor, "user"));
        }
    }
    for (var i = 0; i < wcol.Formulas.length; i++) {
        wcol.Formulas[i].TestExec();
    }
    for (var i = 0; i < this.Limitedctls.length; i++) {  //verificar se existem controlos limitados por esta coluna
    	var lctl=this.Limitedctls[i];
    	for (var c=0; c<lctl.Cols.length; c++) {
    		var lcol=lctl.Cols[c];
    		if (lcol.Limitctl == this.Id && lcol.Limitfld == wcol.Id) lctl.SetLimit(this);
    	}
    }
}

Qform.prototype.SetLimit=function(limiterctl, lunit) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Limitctl == limiterctl.Id) {
			var wcol=this.Cols[i];
			if (lunit != undefined) limiterctl.SetIndex(lunit.Key);
			var wval=limiterctl.GetVal(wcol.Limitfld);
			for (var c=0; c<this.LimitConds.length; c++) {
				if (this.LimitConds[c] == "" || this.LimitConds[c].indexOf(wcol.Id) == 0) {
					if (this.LimitConds[c] == "") this.LimitsUsed++;
					this.LimitConds[c]=AppendCond("", wcol.Id, wcol.Type, wval);
					break;
				}
			}
		}
	}
	if (this.LimitsUsed == this.LimitConds.length) {
		this.LimitCond=this.LimitConds[0];
		for (var c=1; c<this.LimitConds.length; c++) {
			this.LimitCond += "{" + this.LimitConds[c];
		}
		this.Send();
	}
}

Qform.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid);
	if (ix != null) return this.Cols[ix];
}

Qform.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	for (var i=0; i<this.Cols[ix].ColCtls.length; i++) {
		if (this.Cols[ix].ColCtls[i] == ctl) return
	}
	this.Cols[ix].ColCtls.push(ctl)
}

Qform.prototype.SetIndex=function(lixo) {
}
	
Qform.prototype.Disable=function() {
}
Qform.prototype.Enable=function() {
}
Qform.prototype.Show=function() {
}
Qform.prototype.Hide=function() {
}

Qform.prototype.Destroy=function() {
}


//***************************************************************** QDBEDIT - para desaparecer, so está aqui para não dar erro
function Qdbedit(xnod, hostpage) {
	this.Tipo="DBEDIT";
	this.Class="DATA";
	this.Id=GetAtt(xnod, "ID", "");
	this.HostPage=hostpage;
	this.Actls=new Array();
	this.Autostart="S";
	this.Limiterctls=new Array();
	this.Botoes=new Array();
	alert("DBEDIT é um controlo não suportado no Qweb3");
}

Qdbedit.prototype.Activate=function(opt) {
}

Qdbedit.prototype.Destroy=function() {
}




//***************************************************************** QMULTIFORM - define MultiForm
function Qmultiform(xnod, hostpage) {
	this.Tipo="MULTIFORM"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Multiform" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a MULTIFORM(" + this.Id + ") Invalido"))
		return
	}
	this.Msgctl=GetAtt(xnod, "MSGCTL", "")
	this.Skipniv=GetAtt(xnod, "SKIPNIV", "")
	this.Skipcmd=GetAtt(xnod, "SKIPCMD", "")
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
	this.Defcolord=GetAtt(xnod, "DEFCOLORD", "")
	this.Search=GetAtt(xnod, "SEARCH", "")
	this.Nrecs=GetAtt(xnod, "NRECS", 0, "N")
	this.Xopt=GetAtt(xnod, "XOPT", "")
	this.Val=GetAtt(xnod, "VAL", "")
	this.StartSelected=GetAtt(xnod, "STARTSELECTED", "N")
	this.InsertLocation=GetAtt(xnod, "INSERTLOCATION", "BEFORE")
    this.HostFunc=GetAtt(xnod, "FUNC", this.HostPage.Func);
    if (this.HostFunc == "") this.HostFunc="VIS";
	this.Cols=new Array()
	this.XtraCols=new Array()
	this.Dados=new Array()
	this.Events=new Array()
	this.Grpctls=new Array()
	this.Botoes=new Array()
	this.Status=""
	this.KeyIndex=0
	this.SortCol=""
	this.SortOrder="ASC"
	this.Order=""
	this.SelectedKeys=new Array()
	this.Limitedctls=new Array()
	this.Limiterctls=new Array()
	this.LimitsUsed=0
	this.LimitConds=new Array()
    this.LimitCols=new Array()
	this.LimitCond=""
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
    this.Totalrecs=0
    this.SearchText=""
	this.PreSelKey=""
	this.PointerKey=""
	this.Cond=""
	this.LastCond=""
	this.PreCond=GetAtt(xnod, "COND", "")
    this.FilterArea = GetAtt(xnod, "FAREA", "")
    if (this.FilterArea != "") {
        if (this.PreCond != "") this.PreCond += "{"
        this.PreCond += this.FilterArea
    }
	if (this.PreCond != "") {
		this.PreCond = SubstVarsExt(this.HostPage.Area, this.PreCond)
		this.PreCond = CondDecode(this.PreCond)
	}
	this.FrmCtl=""
	this.InsCount=0
	this.ReceiveOk=true
	this.IsCancel=false
	this.PanelOnEdit=""
	this.MustRefresh=false
	this.Waiting4Server=false
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			if (wcol.Limitctl != "") {
				this.LimitConds.push("*")  //inicializadas a * para detectar se vazio ou não inicializado
                this.LimitCols.push(wcol.Id)
				var jaexiste=false
				for (var i=0; i<this.Limiterctls.length; i++) {
					if (wcol.Limitctl == this.Limiterctls[i]) {
						jaexiste=true
						break
					}
				}
				if (jaexiste == false) {
					this.Limiterctls.push(wcol.Limitctl)
					var wctl=this.HostPage.GetCtl(wcol.Limitctl)
					if (wctl == null) {
						window.alert(GetMsg(1, "O MultiForm(" + this.Id + ") referencia um LIMITCTL(" + wcol.Limitctl + ") inexistente"))
					} 
					if (wctl.Tipo == "FORM") {
						this.FrmCtl=wctl
						wctl.Updatectls.push(this)
					}
				}
			}
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	var defcol=""
    if (this.Defcolord != "") {
        defcol=this.Defcolord;
        this.SortOrder="";
    }
    for (var i=0; i<this.Cols.length; i++) {
        var wcol=this.Cols[i]
        if (wcol.Key == "S") this.KeyIndex = i
        if (defcol != "") {
            this.SortCol=defcol
        } else {
            if (wcol.Vis == "S") {
                if (this.SortCol == "") this.SortCol=wcol.Id
            }
        }
    }
	if (this.HostPage.Key != "")	{
		var existeform=false
		for (var i=0; i<this.HostPage.Actls.length; i++) {
			if (this.HostPage.Actls[i].Tipo == "FORM") existeform=true
		}
		if (existeform == false) this.PreSelKey=this.HostPage.Key
	}
	this.Func="GET"
	this.Cond=""
	this.XtraCols.push(new Qcol(null, "$pages", "N", 2))
	this.XtraCols.push(new Qcol(null, "$page", "N", 2))
	this.XtraCols.push(new Qcol(null, "$search", "A", 250))
	this.XtraCols.push(new Qcol(null, "$order", "A", 250))
	this.XtraCols.push(new Qcol(null, "$records", "N", 4))
}


Qmultiform.prototype.Activate=function(opt) {
    if (this.Autostart == "N") return
    if (this.LimitsUsed != this.LimitConds.length) return
	this.Paginas=new Array()
	this.PagIndex=-1
	if (this.Val == "") {
		this.SendRequest()
	} else {
		this.InsertVal()
	}
}

Qmultiform.prototype.Execute=function(act, opt, opt2) {
	if (this.Waiting4Server == true) {
		ExecCmdDelayed(50, this.HostPage.Area, "ExecuteInternal(" + this.Id + "," + act + "," + opt)
		return
	}
	if (act == "") {
		this.SendUpdates()
		return
	}
	if (act == "Cancel") {
		this.SendCancel()
		return
	}
	if (act == "GET") {
        if (this.Autostart != "S") this.Autostart="S"
		this.Paginas=new Array()
		this.PagIndex=-1
		this.SendRequest()
		return
	}
	if (act == "GET+") {
		if (this.PagIndex == this.Paginas.length - 1) {
			if (this.PagFimSup == false) this.SendRequest("+")
		} else {
			this.PagIndex++
            this.PopulateXtracols()
			this.PopulateGrid()	
		}
		return
	}
	if (act == "GET-") {
		if (this.PagIndex > 0) {
			this.PagIndex--
            this.PopulateXtracols()
			this.PopulateGrid()
			return
		} else {
			if (this.PagFimInf == false) this.SendRequest("-")
			return
		}
	}
    if (act == "EXW" || act == "EXR") {
        if (this.Autostart != "S") this.Autostart="S"
        this.Paginas=new Array()
        this.PagIndex=-1
        this.SendRequest(act)
        return
    }
	if (act == "Clear") {
		this.Dados=new Array()
		this.SelectedKeys=new Array()
		this.Paginas=new Array()
		this.PagIndex=-1
		this.PagFimSup=true
		this.PagFimInf=true
		this.PreSelKey=""
		this.PointerKey=""
		this.PopulateGrid()
		return
	}
	if (act == "CLK") {
		for (var i=0; i<this.Limitedctls.length; i++) {
			if (this.Limitedctls[i].Tipo != "VARVAL") this.Limitedctls[i].SetLimit(this)	//o VARVAL é limitado pelo multiform apenas como forma de definir a relação não vai fazer nada em cada clique de uma linha
		}	
	}
	if (act == "ReturnVal") {
		this.HostPage.Area.ReturnValue=this.SelectedKeys[0]
		this.HostPage.Area.ReturnProvider = "*"
		ExecCmdDelayed(20, this.HostPage.Area, "ReturnVal(")
	}
	if (act == "CheckPerm") {
		this.VerifBotoes()
		return	
	}
	if (act == "SelectAll") {
		this.SelectedKeys = new Array()
		for (var i=0; i<this.Dados.length; i++) {
			this.SelectedKeys.push(this.Dados[i].Key)
		}
		this.PopulateGrid()
		return	
	}
	if (act == "DeselectAll") {
		this.SelectedKeys = new Array()
		this.PopulateGrid()
		return	
	}
	if (act == "SetCond") {
		this.PreCond=opt
        if (this.FilterArea != "") {
            if (this.PreCond != "") this.PreCond += "|"
            this.PreCond += this.FilterArea
        }
		this.PreCond = SubstVarsExt(this.HostPage.Area, this.PreCond)
		this.PreCond = CondDecode(this.PreCond)
		if (opt2 != "NoAuto") this.Execute("GET")
		return
	}
		if (act == "GetExcel") {
		var iblk = this.SendRequest("RETURN")
		var wurl=GetServiceAddress("EXPLISTAGEM") + "?CTLID=" + encodeURIComponent(iblk.IDENT) + "&COND=" + encodeURIComponent(iblk.COND) + "&ORD=" + encodeURIComponent(iblk.ORD)+ "&AREA="+ encodeURIComponent(iblk.APP)	
		if (opt != "") wurl += "&EXT=" + encodeURIComponent(opt)
		PopUpWindow=window.open(wurl,"_blank","toolbar=yes, directories=yes, location=yes, menubar=yes, titlebar=yes, resizable=yes")
		return
	}
	if (act == "ELIREC") {
		if (this.SelectedKeys.length != 1) {
			window.alert(GetMsg(6))
  			return
		}
		var Rec=this.GetRowFromKey(this.SelectedKeys[0])
		var gridctl=this.Grpctls[0]
		Rec.Status="M"
		Rec.Func="ELI"
		this.SelectedKeys=new Array()
		gridctl.SetVal("REFRESH")
		return	
	}
	if (act == "INSREC") {
		this.SendIns()
		return	
	}
	var evtact=""
	var selobrig="S"
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == act) {
			evtact=this.Events[i].Act
			selobrig=this.Events[i].SelObrig
		}
	}
	if (evtact == "") return
	if (this.SelectedKeys.length == 0 && selobrig != "N") {
		window.alert(GetMsg(4))
  		return
	}
	if (this.SelectedKeys.length >1 && selobrig == "U") {
		window.alert(GetMsg(5))
  		return
	}
	if (selobrig == "N") {
        //limpa entradas de historial deste nível se as houver
    	SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], null)
    	for (var i=0; i<this.Cols.length; i++) {
	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
		    	SetHistorial(this.HostPage.Area, this.Cols[i], null)
	    	}
    	}
	} else {
    	var selk=""
    	for (var i=0; i<this.SelectedKeys.length; i++) {
	    	if (i > 0) selk += ";"
	    	selk += this.SelectedKeys[i]	
    	}
        if (evtact.indexOf("OpenPage") > -1 || evtact.indexOf("OpenDialog") > -1 || evtact.indexOf("External") > -1){   //remover todas as entradas de historial do nível seguinte e colocar valores no nível seguinte
            RemoveNivelHistorial(this.HostPage.Area, "next")
            SetHistNextLevel(this.HostPage.Area, this.Cols[this.KeyIndex], selk)
        	var Row = this.GetRowFromKey(this.SelectedKeys[0])
        	for (var i=0; i<this.Cols.length; i++) {
    	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
    		    	SetHistNextLevel(this.HostPage.Area, this.Cols[i], Row.Fields[i].Val)
    	    	}
        	}
        } else {
            SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], selk)  //colocar valores no historial no nível atual
            var Row = this.GetRowFromKey(this.SelectedKeys[0])
            for (var i=0; i<this.Cols.length; i++) {
                if (i != this.KeyIndex && this.Cols[i].HistId != "") {
                    SetHistorial(this.HostPage.Area, this.Cols[i], Row.Fields[i].Val)
                }
            }
        }
	}
	if (evtact.indexOf("OpenPage") > -1 || evtact.indexOf("OpenDialog") > -1 || evtact.indexOf("External") > -1){
    	this.HostPage.CallerCtl = this
	}
	ExecCmdDelayed(20, this.HostPage.Area, evtact)
}


//**** enviar uma insersão
Qmultiform.prototype.SendIns=function() {
	if (this.Provider == "*") return
	this.MustRefresh=false
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	iblk.FUNC="INS"
    var wval=""
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
        wval=""
		var col=this.Cols[i]
		iblk.CMPS.push(this.Cols[i].Id)
		histgetid=col.HistGetId
		histop=col.HistOp
		if (histgetid == "") {
			histgetid=col.Id
			histop="EQ"
		}
		if (histop == "EQ") {
			hix=GetHistorialIndex(this.HostPage.Area, histgetid, histop)
			if (hix > -1 && this.HostPage.Area.Historial[hix].Valor != "") wval=this.HostPage.Area.Historial[hix].Valor
		}
        wrec.push(wval)
	}
    iblk.DADOS.push(wrec)
	this.ReceiveOk=true
	this.Waiting4Server=true
	SendServer(this.HostPage, iblk, "SINGLE")
}


Qmultiform.prototype.SendUpdates=function() {
	if (this.Provider == "*") return
	this.MustRefresh=false
	var erros=this.ValidaRegistos()
	if (erros == true) return
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		iblk.CMPS.push(this.Cols[i].Id)
	}
	this.ReceiveOk=true
	var recupd=0
	var wsep=""
	if (this.Cols[this.KeyIndex].Type == "A") wsep="'"
	for (var r=0; r<this.Dados.length; r++) {
		var Rec=this.Dados[r]
		if (Rec.Status == "M" || Rec.Func == "INS") {
			iblk.DADOS=new Array()
			iblk.FUNC=Rec.Func
			if (Rec.Func == "INS") iblk.FUNC="ALT"
			iblk.COND=this.Cols[this.KeyIndex].Id + "[=[" + wsep + Rec.Key + wsep
            var wval=""
            var wrec=new Array()
			for (var i=0; i<this.Cols.length; i++) {
                wval=""
				if (Rec.Func != "ELI") {
                    wval=Rec.Fields[i].Val
				} else {
					if (i == this.KeyIndex) wval=Rec.Fields[i].Val	
				}
                wrec.push(wval)
			}
            iblk.DADOS.push(wrec)
			if (this.FrmCtl == "" && recupd == 0) {
				SendServer(this.HostPage, iblk, "FIRST")
			} else {
				SendServer(this.HostPage, iblk, "ADD")
			}
			iblk.DADOS=new Array()
			recupd++
		}
	}
	if (recupd > 0) {
		//if (this.FrmCtl == "") SendServer(this.HostPage, null, "END")
		this.Waiting4Server=true
		SendServer(this.HostPage, null, "END")
	} else {
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "AFTERUPDATEREQUEST") {
				ExecCmd(this.HostPage.Area, this.Events[i].Act)
			}
		}
	}
}

Qmultiform.prototype.SendCancel=function() {
	if (this.Provider == "*") return
	this.MustRefresh=false
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		iblk.CMPS.push(this.Cols[i].Id)
	}
	var recupd=0
	var wsep=""
	if (this.Cols[this.KeyIndex].Type == "A") wsep="'"
	for (var r=0; r<this.Dados.length; r++) {
		var Rec=this.Dados[r]
		if (Rec.Func == "INS") {
			iblk.DADOS=new Array()
            iblk.DADOS.push(new Array())
			iblk.FUNC="CAN"
			iblk.COND=this.Cols[this.KeyIndex].Id + "[=[" + wsep + Rec.Key + wsep
			if (this.FrmCtl == "" && recupd == 0) {
				SendServer(this.HostPage, iblk, "FIRST")
			} else {
				SendServer(this.HostPage, iblk, "ADD")
			}
			iblk.DADOS=new Array()
			recupd++
		}
	}
	if (recupd > 0) {
		this.IsCancel=true
		if (this.FrmCtl == "") {
			this.Waiting4Server=true
			SendServer(this.HostPage, null, "END")
		}
	} else {
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "AFTERCANCEL") {
				ExecCmd(this.HostPage.Area, this.Events[i].Act)
			}
		}
		return
	}
}

Qmultiform.prototype.Receive=function(iblk, gstatus, last) {
	this.Waiting4Server=false
	var gridctl=this.Grpctls[0]
	if (iblk.FUNC == "GET" || iblk.FUNC == "GET+"  || iblk.FUNC == "GET-" || iblk.FUNC == "GETP" || iblk.FUNC == "EXR" || iblk.FUNC == "EXW") {
		if (iblk.FUNC == "GET" || iblk.FUNC == "GETP" || iblk.FUNC == "EXR" || iblk.FUNC == "EXW") {
			this.Dados=new Array()
            var hasvarval=false  //saber se tem um VariosValores associado, nesse caso mantem a lista de registos seleccionados
            for (var i=0; i<this.Limitedctls.length; i++) {
                if (this.Limitedctls[i].Tipo == "VARVAL") hasvarval=true
            }
            if (hasvarval == false) this.SelectedKeys=new Array()
		} else {
			if (iblk.FUNC == "GET-") {
				var DadosOld = this.Dados
				this.Dados=new Array()
			}
		}
		var Adad=iblk.DADOS
		var wpreselrec=-1
		var primeirakey=""
		for (var r=0; r<Adad.length; r++) {
			var Rec=new Qrecord(this.Cols, Adad[r])
			if (Rec.Status != "VAZIO") {
				this.Dados.push(Rec)
				if (primeirakey == "") primeirakey=Rec.Key
				if (this.StartSelected == "S") this.SelectedKeys.push(Rec.Key)  // permitir linhas pre-seleccionadas
			}
			if (this.PreSelKey != "" && this.PreSelKey == Rec.Key) wpreselrec = r
		}
		if (iblk.FUNC == "GET-") {
			this.Dados = this.Dados.concat(DadosOld)
			DadosOld = ""
		}
		if (this.Dados.length == 1 && this.Skipniv != "") {
			if (User.ModAutorizado(this.HostPage.Modulo, this.Skipniv) == true) {
				this.HostPage.Hide()
                //colocar a chave no historial
                this.SelectedKeys[0]=this.Dados[0].Key
                SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], this.SelectedKeys[0])
                //colocar no historial outras colunas com HISTID preenchido
                var Row = this.Dados[0]
				for (var i = 0; i < this.Cols.length; i++) {
                    if (i != this.KeyIndex && this.Cols[i].HistId != "") {
                        SetHistorial(this.HostPage.Area, this.Cols[i], Row.Fields[i].Val)
				    }
				}
				if (this.Skipcmd != "") {
                    ClosePage(this.HostPage.Area, "KeepHist")
                    ExecCmd(this.HostPage.Area, this.Skipcmd)
				}
				return
			}
		}
		if (iblk.STAT.indexOf("OK") != -1) {
			this.Status="OK"
			this.LastCond=this.TempCond
			if (iblk.FUNC != "GET-") {
				this.Paginas.push(primeirakey)
				this.PagIndex=this.Paginas.length - 1
			} else {
				var Aw=new Array()
				Aw.push(primeirakey)
				this.Paginas = Aw.concat(this.Paginas)
				this.PagIndex=0
			}
			if (iblk.STAT.indexOf("+") != -1) {
				this.PagFimSup=false
			} else {
				this.PagFimSup=true
			}
			if (iblk.STAT.indexOf("-") != -1) {
				this.PagFimInf=false
			} else {
				this.PagFimInf=true
			}
            if (iblk.OPT != "") {  //saber o numero total de registos que vem nas OPT do servidor
                var Aopts=iblk.OPT.split("{")
                for (var i=0; i<Aopts.length; i++) {
                    var Aw=Aopts[i].split("[")
                    if (Aw[0] == "TRECS") this.Totalrecs=parseInt(Aw[1])
                }
            }
            this.PopulateXtracols()
			if (this.PreSelKey != "" && wpreselrec != -1) this.SetRow(this.PreSelKey, false)
			
			for (var i=0; i<this.Events.length; i++) {
				if (this.Events[i].Id == "AFTERREAD") {
					ExecCmd(this.HostPage.Area, this.Events[i].Act)
				}	
			}
            this.PopulateGrid()
            for (var i=0; i<this.Limitedctls.length; i++) {
                if (this.Limitedctls[i].Tipo == "VARVAL") this.Limitedctls[i].SetLimit(this)    
            }
		} else {
			this.Status="ERR"
			this.PopulateGrid()
		}
		this.SetMsg(iblk.MSG)
		if (iblk.STAT.indexOf("W") != -1) this.HostPage.ShowWarning(iblk.MSG)
		this.PreSelKey=""
		if (this.Skipniv != "") this.HostPage.ActivateCtls()
		return	
	}
	if (iblk.FUNC == "INS") {
		if (iblk.STAT != "OK" && iblk.STAT != "W") {
			this.ReceiveOk=false
			this.HostPage.ShowWarning(iblk.MSG)
			return
		}
		if (this.HostPage.UpdateStatus == "S") this.HostPage.UpdatePending=true;
		var RecIx=-1
		var insloc=this.InsertLocation
		if (insloc == "BEFORE" || insloc == "AFTER") {
			if (this.SelectedKeys.length == 1) {
				for (var i=0; i<this.Dados.length; i++) {
					if (this.SelectedKeys[0] == this.Dados[i].Key) {
						if (this.InsertLocation == "BEFORE") {
							RecIx=i
						} else {
							RecIx=i+1
						}
						break
					}
				}
			} else {
				if (insloc == "BEFORE") {
					insloc="TOP"
				} else {
					insloc="BOTTOM"
				}
			}
		}
		if (insloc == "TOP" || insloc == "BOTTOM") {
			var keypagseg=""
			if (this.PagIndex < this.Paginas.length - 1) keypagseg=this.Paginas[this.PagIndex + 1]
			if (keypagseg == "") {
				if (insloc == "TOP") {
					keypagseg=this.Paginas[this.PagIndex]
				} else {
					RecIx=this.Dados.length
				}
			}
			if (keypagseg != "") {
				for (var i=0; i<this.Dados.length; i++) {
					if (this.Dados[i].Key == keypagseg) {
						RecIx=i
						break
					}
				}
			}
		}
		var Nrec=new Qrecord(this.Cols, iblk.DADOS[0])
		Nrec.Status="I"
		Nrec.Func="INS"
		var w1=this.Dados.slice(0, RecIx)
		var w2=this.Dados.slice(RecIx)
		this.Dados=new Array()
		this.Dados=this.Dados.concat(w1, Nrec, w2)
		if (this.PagIndex == -1) {
			this.Paginas.push(Nrec.Key)
			this.PagIndex=0
		} else {
			if (this.Paginas[this.PagIndex] == this.SelectedKeys[0] && this.SelectedKeys.length == 1 && insloc == "BEFORE") this.Paginas[this.PagIndex]=Nrec.Key
			if (insloc == "TOP") this.Paginas[this.PagIndex]=Nrec.Key
		}
		//gridctl.SetVal("REFRESH")
		this.SetMsg(GetMsg(14))
		this.MustRefresh=true
		return
	}
	if (iblk.FUNC == "ALT") {
		var Aw=iblk.DADOS[0]
		var wkey=Aw[this.KeyIndex]
		var Rec=this.GetRowFromKey(wkey)
		if (iblk.STAT != "OK" && iblk.STAT != "W") {
			this.ReceiveOk=false
			this.HostPage.ShowWarning(iblk.MSG)
			if (Rec.Status == "I") Rec.Func="INS"
			Rec.Status="E " + iblk.MSG
			return
		}
		Rec.Update(iblk.DADOS[0])
		Rec.Status=""
		Rec.Func=""
		//gridctl.SetVal("REFRESH")
		this.MustRefresh=true
	}
	if (iblk.FUNC == "ELI") {
		var Aw=iblk.DADOS[0]
		var wkey=Aw[this.KeyIndex]
		var Rec=this.GetRowFromKey(wkey)
		if (iblk.STAT != "OK" && iblk.STAT != "W") {
			this.ReceiveOk=false
			this.HostPage.ShowWarning(iblk.MSG)
			Rec.Status="E " + iblk.MSG
			Rec.Func=""
			return
		}
		Rec.Status=""
		Rec.Func="ELI"
		//gridctl.SetVal("REFRESH")
		this.MustRefresh=true
	}
	if (iblk.FUNC == "CAN") {
	}
	
	if (last == true) {  //é o ultimo bloco
		if (this.MustRefresh == true) {
			gridctl.SetVal("REFRESH")
			this.MustRefresh=false
		}
		if (this.IsCancel == true) {
			for (var i=0; i<this.Events.length; i++) {
				if (this.Events[i].Id == "AFTERCANCEL") {
					ExecCmd(this.HostPage.Area, this.Events[i].Act)
				}
			}
			return
		}
		if (this.ReceiveOk == false) return
		for (var i=0; i<this.Events.length; i++) {
			if (this.Events[i].Id == "AFTERUPDATE") {
				ExecCmd(this.HostPage.Area, this.Events[i].Act)
			}
		}
		return	
	}
}


Qmultiform.prototype.SendRequest=function(mais) {
	if (this.Provider == "" || this.Provider == "*") return
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	iblk.FUNC=this.Func
	if (this.Nrecs != 0) iblk.OPT="NRECS[=[" + this.Nrecs
	if (iblk.OPT != "") {
		iblk.OPT += "{MULTIFORM[=[S"
	} else {
		iblk.OPT = "MULTIFORM[=[S"
	}
	if (this.Xopt != "") iblk.OPT += "{" + this.Xopt
	if (this.PreSelKey != "") iblk.FUNC="GETP"
	if (mais == "+") iblk.FUNC="GET+"
	if (mais == "-") iblk.FUNC="GET-"
    if (mais == "EXR" || mais == "EXW") iblk.FUNC=mais
	if (this.HostPage.Cond != "") iblk.COND=CondDecode(this.HostPage.Cond)
	if (this.PreCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCond
	}
	//filtra area
   if (this.PreCond.indexOf("$FAREA$") > -1) {
        var elems = this.PreCond.split("{")
        for (var i = 0; i < elems.length; i++) {
            if (elems[i].indexOf("$FAREA$") > -1 && elems[i].indexOf("#") > 0) {
                var index = elems[i].indexOf("#")
                var str = elems[i].slice(0, index)
                var listaAreas = str.split("/")
                for (var j = 0; j < listaAreas.length; j++) {
                    var hix = GetHistorialIndex(this.HostPage.Area, listaAreas[j], "EQ")
                    iblk.COND += this.HostPage.Area.Historial[hix].Valor + "/"
                }
				iblk.COND = iblk.COND.substring(0, iblk.COND.length - 1)
            }
        }
        
    }
	
	if (this.Cond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.Cond
	}
	var secorder=""
    var wval=""
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
        wval=""
		var col=this.Cols[i]
		if (col.Send != "N") {
			iblk.CMPS.push(this.Cols[i].Id)
			if (this.PreSelKey != "" && col.Key == "S") wval=this.PreSelKey
		}
		if (col.HistGetId != "") {
            var limitfound=false
			if (col.HistOp == "BL") {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "GE")
				if (hix > -1) {
                    iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "GE")
                    limitfound=true
                }
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "LE")
				if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "LE")
			} else {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
				if (hix > -1) {
                    iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", col.HistOp)
                    limitfound=true
                }
			}
            if (limitfound == false && col.OptLimit == "N") iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, "", "", col.HistOp)  //se o limite é obrigatório e não existe no historial cria condição nula
		}
		if (col.Id == this.SortCol) secorder = col.SecOrder
        wrec.push(wval)
	}
    iblk.DADOS.push(wrec)
	if (this.LimitCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.LimitCond
	}
	if (this.SortCol != "") {
		iblk.ORD=this.SortCol + " " + this.SortOrder
		if (secorder != "") iblk.ORD += ", " + secorder
	}
	if (this.Order != "") iblk.ORD=this.Order
	if (mais == "RETURN") return iblk
	this.TempCond=iblk.COND
	this.Waiting4Server=true
	SendServer(this.HostPage, iblk, "SINGLE")
}

Qmultiform.prototype.IsDisplayed=function(wkey) {
	var keypagact=this.Paginas[this.PagIndex]
	if (this.PagIndex == this.Paginas.length - 1) {
		var keypagseg="9999999999999999999999999999"
	} else {
		var keypagseg=this.Paginas[this.PagIndex + 1]
	}
	for (var r=0; r<this.Dados.length; r++) {
		if (this.Dados[r].Key == keypagact) break
	}
	for (var r=r; r<this.Dados.length; r++) {
		var key = this.Dados[r].Key
		if (key == keypagseg) return false
		if (key == wkey) return true
	}
}

Qmultiform.prototype.ValidaRegistos=function() {
	for (var r=0; r<this.Dados.length; r++) {
		var Rec=this.Dados[r]
		if (Rec.Status == "M" || Rec.Func == "INS") {
			for (var i=0; i<Rec.Fields.length; i++) {
				var col=Rec.Fields[i].Coldef
				var msg=ValidarCol(col, Rec.Fields[i].Val, "OBRIG")
				if (msg != "") {
					var recvisible=this.IsDisplayed(Rec.Key)
					for (var c=0; c<Rec.Fields[i].ColCtls.length; c++) {
						var wctl=Rec.Fields[i].ColCtls[c]
						if (wctl.Tipo == "TEXT" || wctl.Tipo == "COMBO" || wctl.Tipo == "CHECK" || wctl.Tipo == "RADIO" || wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM") {
							if (recvisible == true) wctl.ShowErr(msg)
						}
					}
					window.alert(msg)
					return true
				} else {
					for (var c=0; c<Rec.Fields[i].ColCtls.length; c++) {
						var wctl=Rec.Fields[i].ColCtls[c]
						if (wctl.Tipo == "TEXT" || wctl.Tipo == "COMBO" || wctl.Tipo == "CHECK" || wctl.Tipo == "RADIO" || wctl.Tipo == "LEDIT" || wctl.Tipo == "LEDITM") {
							if (recvisible == true) wctl.HideErr()
						}
					}
				}
			}
		}
	}
	return false
}

Qmultiform.prototype.PopulateGrid=function() {
	for (var i=0; i<this.Grpctls.length; i++) {
		this.Grpctls[i].SetVal(null)	
	}
	var wactbotmais="Execute(" + this.Id + ",GET+"
	var wactbotmenos="Execute(" + this.Id + ",GET-"
	for (var i=0; i<this.Botoes.length; i++) {
		if (this.Botoes[i].Act.indexOf(wactbotmais) > -1) {
			if (this.PagFimSup == true && this.PagIndex == this.Paginas.length - 1) {
				this.Botoes[i].Disable("PAG")
			} else {
				this.Botoes[i].Enable("PAG")
			}
		}
		if (this.Botoes[i].Act.indexOf(wactbotmenos) > -1) {
			if (this.PagFimInf == true && this.PagIndex < 1) {
				this.Botoes[i].Disable("PAG")
			} else {
				this.Botoes[i].Enable("PAG")
			}
		}
	}
}


Qmultiform.prototype.PopulateXtracols=function() {
    if (this.Nrecs != 0 && this.Nrecs != -1) {
        var paginas=Math.ceil(this.Totalrecs / this.Nrecs)
    } else {
        var paginas='...'
    }
    var Avalor=new Array()
    Avalor[0]=paginas  //$pages
    Avalor[1]=this.PagIndex+1  //$page
    Avalor[2]=this.SearchText //$search
    Avalor[3]=this.Order //$order
    Avalor[4]=this.Totalrecs  //$records
    for (var i=0; i<this.XtraCols.length; i++) {
        var col=this.XtraCols[i]
        for (var c = 0; c < col.ColCtls.length; c++) {
            var wctl = col.ColCtls[c];
            wctl.SetVal(Avalor[i]);
        }
    }
}

Qmultiform.prototype.CalcColFunction = function(col, ix) {
    var Aargs=col.FunctionArgs.split("[");
    var wcmd="var valcol=" + col.FunctionId + "(";
    for (var i=0; i<Aargs.length; i++) {
        if (i > 0) wcmd += ", ";
        wcmd += "wvals[" + i + "]";
    }
    wcmd += ")";
    var wvals=new Array();
    for (var c=0; c<this.Cols.length; c++) {
        for (var i=0; i<Aargs.length; i++) {
            if (this.Cols[c].Id == Aargs[i]) {
                wvals[i]=ConvertToNative(this.Dados[c], this.Cols[c].Type);
            }
        }
    }
    try {eval(wcmd)}
    catch(exp) {window.alert(GetMsg(1, "Erro na avaliação da Col (" + col.Id + ") - FunctionId (" + col.FunctionId + ") - " + exp.message));
        return;}
    this.Dados[ix]=valcol;
}

Qmultiform.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
    for (var i=0; i<this.XtraCols.length; i++) {
        if (this.XtraCols[i].Id == colid) return i+1000
    }
	return null
}

Qmultiform.prototype.SetMsg=function(txt) {
	if (this.Msgctl != "") {
		var ctl=this.HostPage.GetCtl(this.Msgctl)
		ctl.SetVal(txt)
	}
}

Qmultiform.prototype.GetVal = function(ix, opt) {
    if (opt == "COUNT") return this.SelectedKeys.length
    switch(ix) {
        case "$page":
            return this.PagIndex+1
            break;
        case "$pages":
            if (this.Nrecs != 0 && this.Nrecs != -1) {
                var paginas=Math.ceil(this.Totalrecs / this.Nrecs)
            } else {
                var paginas='...'
            }
            return paginas
            break;
        case "$records":
            return this.Totalrecs
            break;
        case "$search":
            return this.SearchText
            break
        case "$order":
            return this.Order
            break
    }
    if (this.SelectedKeys.length == 0) return ""
    if (opt == "" || opt == undefined) {
        var Row = this.GetRowFromKey(this.SelectedKeys[0])
        if (ix >= 0 && ix < this.Cols.length) {
            return Row.Fields[ix].Val
        } else {
            for (var i = 0; i < this.Cols.length; i++) {
                if (this.Cols[i].Id == ix) {
                    return Row.Fields[i].Val
                }
            }
        }
        return ""
    }
    var wdelim = ""
    var wsep = ""
    var ixcol = 0
    if (opt == "PV") wsep = ";"
    if (opt == "SQL") {
        wsep = ","
        wdelim = "?"
    }
    if (ix >= 0 && ix < this.Cols.length) {
        ixcol = ix
    } else {
        for (var i = 0; i < this.Cols.length; i++) {
            if (this.Cols[i].Id == ix) {
                ixcol = i
                break
            }
        }
    }
    if (wdelim == "?") {
        if (this.Cols[i].Type == "A" || this.Cols[i].Type == "D" || this.Cols[i].Type == "H" || this.Cols[i].Type == "S") {
            wdelim = "'"
        } else {
            wdelim = ""
        }
    }
    var wout = ""
    for (var i = 0; i < this.SelectedKeys.length; i++) {
        var Row = this.GetRowFromKey(this.SelectedKeys[i])
        if (i > 0) wout += wsep
        wout += wdelim + Row.Fields[ixcol].Val + wdelim
    }
    return wout
}

Qmultiform.prototype.GetValFromKey = function(ix, key) {
    switch(ix) {
        case "$page":
            return this.PagIndex+1
            break;
        case "$pages":
            if (this.Nrecs != 0 && this.Nrecs != -1) {
                var paginas=Math.ceil(this.Totalrecs / this.Nrecs)
            } else {
                var paginas='...'
            }
            return paginas
            break;
        case "$records":
            return this.Totalrecs
            break;
        case "$search":
            return this.SearchText
            break
        case "$order":
            return this.Order
            break
    }
    var Row = this.GetRowFromKey(key)
    if (Row == null) return ""
    if (ix >= 0 && ix < this.Cols.length) {
        return Row.Fields[ix].Val
    } else {
        for (var i = 0; i < this.Cols.length; i++) {
            if (this.Cols[i].Id == ix) {
                return Row.Fields[i].Val
            }
        }
    }
    return ""
}

Qmultiform.prototype.StoreVal=function(fld, valor, ctl, opt) {
	switch(fld) {
		case "$page":
			return
			break;
		case "$search":
            this.SearchText=valor
			this.PreCond=""
			if (valor == "") {
				this.PreCond = ""
			} else {
				var Aw=this.Search.split("[")
				for (var i=0; i<Aw.length; i++) {
					if (i > 0) this.PreCond+= "[OR["
					this.PreCond += Aw[i] + "[LIKE['*" + valor + "*'"	
				}
			}
			return
			break
		case "$order":
            if (this.Order != valor) {
    			this.Order=valor
    			this.Execute("GET")
            }
			return
			break
		case "*":
			this.Val=valor
			this.InsertVal()
			return
			break
	}
	if (ctl == null || ctl == undefined) {
		var HostPanel=this.PanelOnEdit
	} else {
		var HostPanel=ctl.HostDataPanel
	}
	var Rec=HostPanel.Record
	if (fld >=0 && fld < this.Cols.length) {
		var ix=fld
	} else {
		var ix=this.GetColIndex(fld)
		if (ix == null) return
	}
	var Field = Rec.Fields[ix]
	if (valor == Field.Val) return
	Field.Val = valor
	Field.Status="M"
	Rec.Status="M"
	if (Rec.Func == "") {
		Rec.Func="ALT"
		HostPanel.Mark("ALT")
	}
	if (HostPanel.Tipo.indexOf("AUTOQUERYPANEL") > -1) {
		this.Grpctls[0].OnQryChange()
		return
	}
	if (this.HostPage.UpdateStatus == "S") this.HostPage.UpdatePending=true;
	this.PanelOnEdit=HostPanel
	for (var i=0; i<Field.Coldef.Formulas.length; i++) {
		Field.Coldef.Formulas[i].TestExec()
	}
}

Qmultiform.prototype.SetRow = function(key, multi, keys) {
    if (multi == false) {
        this.SelectedKeys[0] = key
        this.PointerKey = key
    } else {
        if (keys == undefined) {  //metodo de clica uma vez para seleccionar e outra para desseleccionar
            for (var s = 0; s < this.SelectedKeys.length; s++) {
                if (key == this.SelectedKeys[s]) {
                    this.SelectedKeys.splice(s, 1)
                    this.PointerKey = ""
                    return false
                }
            }
            var warray = new Array()
            warray.push(key)
            this.SelectedKeys = warray.concat(this.SelectedKeys)
            this.PointerKey = key
            return true
        } else {  //metodo de seleção do windows usando as teclas CTRL e SHIFT
            if (keys == "") {  //apaga seleccoes anteriores e fica só esta
                this.SelectedKeys=new Array()
                this.SelectedKeys.push(key)
                this.PointerKey = key
            }
        }
    }
}

Qmultiform.prototype.SetLimit=function(limiterctl, lunit) {
    var LimitsAdded=0
    var LimitsChanged=0
    var LimitsRemoved=0
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Limitctl == limiterctl.Id) {
			var wcol=this.Cols[i]
			if (lunit != undefined) limiterctl.SetIndex(lunit.Key)
			var wval=limiterctl.GetVal(wcol.Limitfld)
            if (wval == "00000000-0000-0000-0000-000000000000") wval=""  //Guid vazio
            var wlcond=AppendCond("", wcol.Id, wcol.Type, wval)
			for (var c=0; c<this.LimitConds.length; c++) {
                if (this.LimitCols[c] == wcol.Id) {
                    if (this.LimitConds[c] == "*") {  //se nunca foi inicializado
                        if (wcol.OptLimit == "S" && wval == "") {
                            this.LimitConds[c] = ""
                            LimitsAdded ++
                            this.LimitsUsed ++
                        } else {
                            if (wval != "") {
                                this.LimitConds[c] = wlcond
                                LimitsAdded ++
                                this.LimitsUsed ++
                            }
                        }
                    } else {
                        if (this.LimitConds[c] != wlcond) {
                            if (wcol.OptLimit == "S" && wval == "") {
                                this.LimitConds[c] = ""
                            } else {
                                this.LimitConds[c] = wlcond
                            }
                            LimitsChanged ++
                        }
                    }
                    break
                }
			}
		}
	}
    if (LimitsAdded == 0 && LimitsChanged == 0 && LimitsRemoved == 0) return;
	if (this.LimitsUsed == this.LimitConds.length) {
        if (this.LimitConds.length == 0) {
            this.LimitCond=""
        } else {
            this.LimitCond=this.LimitConds[0]
        }
        for (var c=1; c<this.LimitConds.length; c++) {
            if (this.LimitConds[c] != "") {
                if (this.LimitCond != "") this.LimitCond += "{"
                this.LimitCond += this.LimitConds[c]
            }
        }
		if (this.Autostart == "S") this.SendRequest()
	}
}

Qmultiform.prototype.SetPointer=function(key) {
	this.PointerKey=key
}

Qmultiform.prototype.GetCol=function(colid) {
	if (colid == "filler")  return new Qcol(null, "filler", "A", 1);
	if (colid == "$selected")  return new Qcol(null, "$selected", "B", 1);
	var ix=this.GetColIndex(colid)
	if (ix != null) {
        if (ix < 1000) {
            return this.Cols[ix]
        } else {
            return this.XtraCols[ix-1000]
        }
	}
	return null
}

Qmultiform.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
    if (ix >= 1000) {  //é uma COL interna (Xtracols)
        this.XtraCols[ix-1000].ColCtls.push(ctl)
        return
    }
	var Rec = ctl.HostDataPanel.Record
	var Field = Rec.Fields[ix]
	Field.ColCtls.push(ctl)
}

Qmultiform.prototype.SetIndex=function(lixo) {
}

Qmultiform.prototype.Disable=function() {
}
Qmultiform.prototype.Enable=function() {
}
Qmultiform.prototype.Show=function() {
}
Qmultiform.prototype.Hide=function() {
}

Qmultiform.prototype.VerifBotoes=function(situa) {
	for (var i=0; i<this.Events.length; i++) {
		if (User.ActAutorizado(this.HostPage.Modulo, this.Events[i].Act, this.HostPage.Area) == false) {
			this.Events[i].Disabled=true
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact) this.Botoes[b].Disable("AUT")
			}
		} else {
			this.Events[i].Disabled=false
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact && situa != "INIT") this.Botoes[b].Enable("AUT")
			}
		}
	}
}

Qmultiform.prototype.DisableBotoesUpdate=function() {
	for (var i=0; i<this.Events.length; i++) {
		var act=this.Events[i].Act
		if (act != "") {
			var acts=act.split("{")
			for (var j=0; j<acts.length; j++) {
				var wact=acts[j]
				var Aw=wact.split("(")
				if (Aw[0] == "OpenPage" || Aw[0] == "OpenFirstPage" || Aw[0] == "OpenDialog") {
					var wperm=""
					var parms=Aw[1] + ",,,,,"
					var Aparms=parms.split(",")
					var wpag=Aparms[0]
					var wfunc=Aparms[1]
					if (wfunc == "ALT" || wfunc == "INS" || wfunc == "DUP" || wfunc == "ELI") {
						this.Events[i].Disabled=true
						for (var b=0; b<this.Botoes.length; b++) {
							if (this.Botoes[b].Act == "Execute(" + this.Id + "," + wfunc) this.Botoes[b].Disable("UPDATE")
						}
					}
				}
			}
		}
	}
}

Qmultiform.prototype.GetRowFromKey=function(key) {
	for (var i=0; i<this.Dados.length; i++) {
		if (this.Dados[i].Key == key) return this.Dados[i]
	}
    return null
}

Qmultiform.prototype.Destroy=function() {
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Grpctls=null
	this.Botoes=null
	this.SelectedKeys=null
	this.Limitedctls=null
	this.Limiterctls=null
	this.Paginas=null
}

Qmultiform.prototype.InsertVal=function() {
	var Adad=this.Val.split("{")
	var primeirakey=""
	for (var r=0; r<Adad.length; r++) {
		var Rec=new Qrecord(this.Cols, Adad[r].split("["))
		if (Rec.Status != "VAZIO") {
			Rec.Status="I"
			Rec.Func="INS"
			this.InsCount++
			Rec.Key="#" + this.InsCount
			this.Dados.push(Rec)
			if (primeirakey == "") primeirakey=Rec.Key
		}
	}
	this.Val=""
	this.Status="OK"
	this.PagFimSup=true
	this.PagFimInf=true
	this.Paginas.push(primeirakey)
	this.PagIndex=this.Paginas.length - 1
	this.PopulateGrid()
}

Qmultiform.prototype.SetKey=function(key) {
	this.PreSelKey=key
}




//***************************************************************** QLEDITunit - define LeditUnit
function QleditUnit(parentobj) {
	this.Tipo="LEDITUNIT"
	this.Class="DATA"
	this.ParentObj=parentobj
	this.HostPanel=""
	this.HostDataPanel=""
	this.Key=""
	this.Record=null
	this.LimitsUsed=0
	this.LimitCond=""
	this.LimitConds=new Array()
    this.LimitCols=new Array()
	this.Cond=""
	this.CondWasSet=false
	this.UserCond=""
	this.Status=""
	this.Queue=false
	this.UserRequest=false
	this.Dados=new Array()
	this.Hostval=""
	this.SelectedIndex=""
	this.Cols=new Array()
	for (var i=0; i<parentobj.Cols.length; i++) {
		this.Cols.push(new Qcol(null, parentobj.Cols[i].Id, parentobj.Cols[i].Type, parentobj.Cols[i].Comp, parentobj.Cols[i].Dec, parentobj.Cols[i].HistId))
	}
	for (var i=0; i<parentobj.LimitConds.length; i++) {
		this.LimitConds.push(parentobj.LimitConds[i])
        this.LimitCols.push(parentobj.LimitCols[i])
	}
}

QleditUnit.prototype.SetVal=function(valor) {
	this.ParentObj.SetIndex(this.Key)
	this.ParentObj.SetVal(valor)
}

QleditUnit.prototype.Disable=function(tipo) {
	this.ParentObj.Disable(tipo)
}

QleditUnit.prototype.Enable=function(tipo) {
	this.ParentObj.Enable(tipo)
}


//***************************************************************** QLEDIT - define Ledit
function Qledit(xnod, hostpage) {
	this.Tipo="LEDIT"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Ledit" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a LEDIT(" + this.Id + ") Invalido"))
		return
	}
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=hostpage.GetCtl(this.Datactl)
	if (this.DatactlObj == null) {
		window.alert(GetMsg(1, "LEDIT (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
		return
	}
    //add this control to the host form
    if (this.DatactlObj.Tipo == "FORM") {
        var leditfound=false;
        for (var i=0; i<this.DatactlObj.LeditsUsed.length; i++) {
            if (this == this.DatactlObj.LeditsUsed[i]) leditfound=true;
        }
        if (leditfound == false) this.DatactlObj.LeditsUsed.push(this);
    }

	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	this.DatafldIx=this.DatactlObj.GetColIndex(this.Datafld)
	if (this.DatafldIx == null) {
		window.alert(GetMsg(1, "LEDIT (" + this.Id + ") referencia um DATAFLD (" + this.Datafld + ") inválido"))
		return
	}
	var wcol=this.DatactlObj.Cols[this.DatafldIx]
	this.Obrig=wcol.Obrig
	this.KeyIndex=0
	this.Limiterctls=new Array()
	this.Limitedctls=new Array()
	this.LimitConds=new Array()
    this.LimitCols=new Array()
	this.PreCond=GetAtt(xnod, "COND", "")
	if (this.PreCond != "") {
		this.PreCond = SubstVarsExt(this.HostPage.Area, this.PreCond)
		this.PreCond = CondDecode(this.PreCond)
	}
	this.PreCondIns=GetAtt(xnod, "CONDINS", "")
	if (this.PreCondIns != "") {
		this.PreCondIns = SubstVarsExt(this.HostPage.Area, this.PreCondIns)
		this.PreCondIns = CondDecode(this.PreCondIns)
	}
	this.Msgctl=GetAtt(xnod, "MSGCTL", "")
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
	this.Selunico=GetAtt(xnod, "SELUNICO", "N")
	this.Disabled=false
	this.Cols=new Array()
	this.Events=new Array()
	this.Botoes=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			if (wcol.Limitctl != "") {
				this.LimitConds.push("*")  //inicializadas a * para detectar se vazio ou não inicializado
                this.LimitCols.push(wcol.Id)
				var jaexiste=false
				for (var i=0; i<this.Limiterctls.length; i++) {
					if (wcol.Limitctl == this.Limiterctls[i]) {
						jaexiste=true
						break
					}
				}
				if (jaexiste == false) this.Limiterctls.push(wcol.Limitctl)
			}
			if (wcol.Key == "S") this.KeyIndex = this.Cols.length - 1
			//this.Dados.push("")
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Units=new Array()
	this.Uix=-1
}

Qledit.prototype.SetIndex=function(key) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == key) {
			this.Uix=i
			return
		}
	}
	this.Uix=-1
}

Qledit.prototype.Activate=function(opt) {
	if (this.Autostart != "S") return
	if (opt == "INIT") {
		this.VerifBotoes()
		return
	}
	var Unit=null
	for (var i=0; i<this.Units.length; i++) {
        Unit=this.Units[i]
		if (Unit.Status == "" || opt == "Refresh") {
            this.Uix=i
            this.CheckState(Unit)
		}
    }
}

Qledit.prototype.VerifRotina=function() {
	//verificar se ha rotinas a testar para execução
	var Arotinas=new Array()
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		for (var f=0; f<col.Formulas.length; f++) {
			var encontrou=false
			for (var r=0; r<Arotinas.length; r++) {
				if (col.Formulas[f] == Arotinas[r]) {
					encontrou = true
					break
				}	
			}
			if (encontrou == false) Arotinas.push(col.Formulas[f])
		}
	}
	for (var r=0; r<Arotinas.length; r++) {
		Arotinas[r].TestExec(this.Id)
	}	
}

Qledit.prototype.Execute=function(act, opt) {
	var Unit=null
	if (this.Units.length > 1) {   //não é um form
		var selectedkey=this.DatactlObj.PointerKey  //this.DatactlObj.SelectedKeys[this.DatactlObj.SelectedKeys.length - 1]
		for (var i=0; i<this.Units.length; i++) {
			if (this.Units[i].Key == selectedkey) {
				this.Uix=i
				Unit=this.Units[i]
				break	
			}
		}
	} else {
		Unit=this.Units[0]
	}
	if (Unit == null) return
	if (act == "") {
		if (Unit.Cond == "") {
			this.DatactlObj.StoreVal(this.Datafld, "", this)
			this.ReceiveNull()
			return
		}
        if (Unit.LimitsUsed != Unit.LimitConds.length) Unit.Cond = ""; //se os limites não estão todos estabelecidos ignora input do utilizador
        this.UserRequest=true
        this.CheckState(Unit)
		return
	}
	var evtact=""
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == act) {
			evtact=this.Events[i].Act
			evtact=SubstVarsExt(this.HostPage.Area, evtact)
		}
	}
	if (evtact == "") return
	this.HostPage.CallerCtl = Unit  //this
    var wkey=Unit.Dados[this.KeyIndex]
    if (wkey == undefined) wkey=""
	var Ac = evtact.split("{");
	var wevtact=""
	for (var c=0; c<Ac.length; c++) {
		var cmd=Ac[c]
		if (cmd.indexOf("OpenDialog") == 0 || cmd.indexOf("OpenPage") == 0 || cmd.indexOf("OpenPopupDialog") == 0) {
			var w=SubstVarsExt(this.HostPage.Area, cmd) + ",,,,"    	//var w=cmd + ",,,,"
			cmd=""
			var Aw= w.split(",")
			for (var i=0; i<Aw.length; i++) {
				if (i == 2) Aw[i] = wkey  //para posicionar o DBEDIT que vai abrir
				if (i == 3) {
					Aw[i]=this.GetHistLimitCond(Unit, Aw[i])
                    var wlimitcond=this.GetLimitCond(Unit);
					if (Aw[i] == "") {
						//if (Unit.LimitCond != "") Aw[i] = CondEncode(Unit.LimitCond)
                        if (wlimitcond != "") Aw[i] = CondEncode(wlimitcond)
					} else {
						Aw[i] = CondEncode(Aw[i])
						//if (Unit.LimitCond != "") Aw[i] += "{" + CondEncode(Unit.LimitCond)
                        if (wlimitcond != "") Aw[i] += "{" + CondEncode(wlimitcond)
					}
				}
				cmd += Aw[i] + ","
			}
		}
		if (c > 0) wevtact += "{"
		wevtact += cmd
	}
	ExecCmd(this.HostPage.Area, wevtact)
}

Qledit.prototype.GetHistLimitCond=function(Unit, cond) {
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		if (col.HistGetId != "") {
            var limitfound=false
			if (col.HistOp == "BL") {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "GE")
				if (hix > -1) {
                    cond=AppendCond(cond, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "GE")
                    limitfound=true
                }
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "LE")
				if (hix > -1) cond=AppendCond(cond, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "LE")
			} else {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
				if (hix > -1) {
                    cond=AppendCond(cond, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", col.HistOp)
                    limitfound=true
                }
			}
            if (limitfound == false && col.OptLimit == "N") cond=AppendCond(cond, this.Cols[i].Id, this.Cols[i].Type, "", "", col.HistOp)  //se o limite é obrigatório e não existe no historial cria condição nula
		}
	}
	return cond
}

Qledit.prototype.GetLimitCond=function(Unit) {  //usado quando o LEDIT é executado e é preciso saber a condição para abertura de Dialog
    if (Unit.CondWasSet == true && Unit.LimitsUsed == Unit.LimitConds.length) {
        return Unit.LimitCond;
    }
    var wcond="";
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Limitctl != "") {
            var wcol=this.Cols[i];
            var wval="";
            var wcond=AppendCond(wcond, wcol.Id, wcol.Type, wval);
        }
    }
    return wcond;
}


Qledit.prototype.SetMsg=function(txt) {
	if (this.Msgctl != "") {
		var ctl=this.HostPage.GetCtl(this.Msgctl)
		ctl.SetVal(txt)
	}	
}

Qledit.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qledit.prototype.GetVal=function(ix) {
	var Unit=this.Units[this.Uix]
    var wval=""
	if (ix >=0 && ix < this.Cols.length) {
		wval=Unit.Dados[ix]
	}
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == ix) {
			wval=Unit.Dados[i]
		}
	}
    if (wval == undefined) wval=""
	return wval	
}

Qledit.prototype.SetVal=function(valor) {
	var Unit=this.Units[this.Uix]
	var wval=valor
	if (wval == null) {
		if (this.DatactlObj.Tipo == "FORM") {
			wval=this.DatactlObj.Dados[this.DatafldIx]
		} else {
			wval=Unit.Record.Fields[this.DatafldIx].Val
		}
	}
    if (wval == "00000000-0000-0000-0000-000000000000") wval=""  //Guid vazio
    Unit.Hostval=wval  //para no CheckState poder saber se o valor é vazio
    Unit.CondWasSet=true
	if (wval == "") {
		Unit.Cond=""
	} else {
		Unit.Cond=AppendCond("", this.Cols[this.KeyIndex].Id, this.Cols[this.KeyIndex].Type, wval)
	}
    this.CheckState(Unit)
}

Qledit.prototype.StoreVal = function(fld, valor, ctl, opt) {
    if (this.DatactlObj.Tipo == "FORM") {
        this.Uix=0
    } else {
        if (ctl != null && ctl != undefined) {
            this.Uix=-1
            for (var i=0; i<this.Units.length; i++) {
                if (this.Units[i].HostDataPanel == ctl.HostDataPanel) {
                    this.Uix=i
                    break
                }
            }
        }
    }
    var Unit=this.Units[this.Uix]
    if (fld >= 0 && fld < this.Cols.length) {
        var ix = fld;
    } else {
        var ix = this.GetColIndex(fld);
        if (ix == null) return;
    }
    if (valor == Unit.Dados[ix]) return;
    if (ix == this.KeyIndex) { // se o campo for a chave faz o StoreVal ao Form ou Multiform
        this.DatactlObj.StoreVal(this.Datafld, valor, Unit, opt)
        return
    }
    if (valor == "" || valor == null) { // se o valor for vazio é sempre para limpar a chave estrangeira no Form ou Multiform
        this.DatactlObj.StoreVal(this.Datafld, "", Unit, opt)
        return
    }
    var wcol=this.Cols[ix]
    Unit.Cond=AppendCond("", wcol.Id, wcol.Type, valor, "LEDTXT")
    if (Unit.Queue == false) {
        Unit.Queue = true
        this.Execute("")
    }
}


Qledit.prototype.SetLimit=function(limiterctl, lunit) {
    var LimitsAdded=0
    var LimitsChanged=0
    var LimitsRemoved=0
    var Unit=this.Units[this.Uix]
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Limitctl == limiterctl.Id) {
            var wcol=this.Cols[i]
            if (lunit != undefined) limiterctl.SetIndex(lunit.Key)
            var wval=limiterctl.GetVal(wcol.Limitfld)
            if (wval == "00000000-0000-0000-0000-000000000000") wval=""  //Guid vazio
            var wlcond=AppendCond("", wcol.Id, wcol.Type, wval)
            for (var c=0; c<Unit.LimitConds.length; c++) {
                if (Unit.LimitCols[c] == wcol.Id) {
                    if (Unit.LimitConds[c] == "*" ) {
                        if (wcol.OptLimit == "S" && wval == "") {
                            Unit.LimitConds[c] = ""
                            LimitsAdded ++
                            Unit.LimitsUsed ++
                        } else {
                            if (wval != "") {
                                Unit.LimitConds[c] = wlcond
                                LimitsAdded ++
                                Unit.LimitsUsed ++
                            }
                        }
                    } else {
                        if (Unit.LimitConds[c] != wlcond) {
                            if (wcol.OptLimit == "S" && wval == "") {
                                Unit.LimitConds[c] = ""
                            } else {
                                Unit.LimitConds[c] = wlcond
                            }
                            LimitsChanged ++
                        }
                    }
                    break
                }
            }
        }
    }
    if (LimitsAdded == 0 && LimitsChanged == 0 && LimitsRemoved == 0) return;
    if (LimitsChanged != 0) {
        Unit.Cond = "" // se os limites foram alterados é porque houve uma acção do utilizador e portanto limpa a pre-seleção
        this.DatactlObj.StoreVal(this.Datafld, "", Unit);  //se houve alteração de limites deve limpar o campo do form (FHC 2017/04/10)
        this.CheckState(Unit);
    } else {
        this.CheckState(Unit, "ADD")  //faz o CheckState com a opção ADD porque não é preciso fazer ReceiveNull se não atingir o numero total de limites resolvidos
    }
}

Qledit.prototype.CheckState=function(Unit, opt) {
    if (Unit.CondWasSet == false) return  //o form ainda não forneceu chave externa nem vazia nem preenchida
    if (Unit.LimitsUsed == Unit.LimitConds.length) {
        if (Unit.LimitConds.length == 0) {
            Unit.LimitCond=""
        } else {
            Unit.LimitCond=Unit.LimitConds[0]
        }
        for (var c=1; c<Unit.LimitConds.length; c++) {
            if (Unit.LimitConds[c] != "") {
                if (Unit.LimitCond != "") Unit.LimitCond += "{"
                Unit.LimitCond += Unit.LimitConds[c]
            }
        }
        if (Unit.Cond == "") {
            if (this.Selunico == "N") {
                this.ReceiveNull()
            } else {
                if (this.Autostart == "S") this.Send()
            }
        } else {
            if (this.Autostart == "S") this.Send()
        }
    } else {
        if (opt == "ADD") return;  //se apenas foi adicionado limite não é preciso fazer o ReceiveNull
        if (Unit.Hostval == "") this.ReceiveNull()  //se o valor da chave estrangeira esta vazio faz o ReceiveNull e fica com Status=OK
        return
    }
}

Qledit.prototype.ReceiveNull=function() {
	var Unit=this.Units[this.Uix]
	Unit.Queue = false
	for (var i=0; i<Unit.Cols.length; i++) {
		Unit.Dados[i]=""
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
			wctl.SetVal(Unit.Dados[i])
		}
		//if (this.DatactlObj.Tipo == "FORM") SetHistorial(this.HostPage.Area, wcol, Unit.Dados[i])   //todos os valores para historial
        if (this.DatactlObj.Tipo == "FORM") SetHistorial(this.HostPage.Area, wcol, null)   //retirar os valores para historial em vez de os por a ""
	}
	for (var i=0; i<this.Limitedctls.length; i++) {
		this.Limitedctls[i].SetLimit(this, Unit)
	}
	Unit.UserRequest=false
	Unit.Status="OK";
	this.VerifRotina();
    if (this.DatactlObj.Tipo == "FORM") this.DatactlObj.TestComplete();  //Inform the Form that status is complete
}

Qledit.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
}

Qledit.prototype.AddNoFieldUnit=function() {  //LEDITs sem campos de exibição
	if (this.Units.length == 0) {
		var lun=new QleditUnit(this)
		this.Units.push(lun)
		this.DatactlObj.AddFieldCtl(this.Datafld, lun)
		this.Uix=0
	}
}

Qledit.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	if (this.DatactlObj.Tipo == "FORM") {
		if (this.Units.length == 0) {
			var lun=new QleditUnit(this)
			this.Units.push(lun)
		}
		this.Uix=0
	} else {
		var wrec=ctl.HostDataPanel.Record
		var encontrou=false
		for (var u=0; u<this.Units.length; u++) {
			if (this.Units[u].Record == wrec) {
				encontrou=true
				this.Uix=u
				break
			}
		}
		if (encontrou == false) {
			var lun=new QleditUnit(this)
			lun.Key=wrec.Key
			lun.Record=wrec
			this.Uix=this.Units.length
			this.Units.push(lun)
		}
	}
	var Unit=this.Units[this.Uix]
	Unit.Cols[ix].ColCtls.push(ctl)
	if (this.DatactlObj.Tipo == "FORM") {
		Unit.HostPanel=ctl.HostPanel
	} else {
		Unit.HostDataPanel=ctl.HostDataPanel
	}
	this.DatactlObj.AddFieldCtl(this.Datafld, Unit)
	return Unit.Key
}

Qledit.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	for (var i=0; i<this.Units.length; i++) {
		var Unit=this.Units[i]
		for (var j=0; j<Unit.Cols.length; j++) {
			var wcol=Unit.Cols[j]
			for (var c=0; c<wcol.ColCtls.length; c++) {
				var wctl=wcol.ColCtls[c]
				wctl.Disable(tipo)
			}
		}
	}
	for (var i=0; i<this.Botoes.length; i++) {
		this.Botoes[i].Disable(tipo)
	}
	this.Disabled=true
}	
Qledit.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		for (var i=0; i<this.Units.length; i++) {
			var Unit=this.Units[i]
			for (var j=0; j<Unit.Cols.length; j++) {
				var wcol=Unit.Cols[j]
				for (var c=0; c<wcol.ColCtls.length; c++) {
					var wctl=wcol.ColCtls[c]
					wctl.Enable(tipo)
				}
			}
		}
		for (var i=0; i<this.Botoes.length; i++) {
			this.Botoes[i].Enable(tipo)
		}
		this.Disabled=false
	}
}
Qledit.prototype.Show=function() {
}
Qledit.prototype.Hide=function() {
}

Qledit.prototype.ShowErr=function(msg) {
	var Unit=this.Units[this.Uix]
	var j=msg.indexOf(" - ")
	if (j > 0) msg = msg.substr(j)
	var wcmp=""
	for (var i=0; i<Unit.Cols.length; i++) {
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
			if (wctl.Tipo == "LEDTXT") {
				wctl.ShowErr(wcol.Tit + msg)
				if (wcmp != "") wcmp += " / "
				wcmp += wcol.Tit
			}
		}
	}
	if (wcmp != "") window.alert(wcmp + msg)
}

Qledit.prototype.HideErr=function() {
	var Unit=this.Units[this.Uix]
	for (var i=0; i<Unit.Cols.length; i++) {
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
			if (wctl.Tipo == "LEDTXT") wctl.HideErr()
		}
	}
}

Qledit.prototype.VerifBotoes=function() {
	for (var i=0; i<this.Events.length; i++) {
		if (User.ActAutorizado(this.HostPage.Modulo, this.Events[i].Act) == false) {
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact) this.Botoes[b].Disable("AUT")
			}
		}
	}
}

Qledit.prototype.DestroyUnit=function(key) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == key) {
			this.Units[i]=null
			this.Units.splice(i,1)
			return
		}
	}
	return
}

Qledit.prototype.Destroy=function() {
	this.Limiterctls=null
	this.Limitedctls=null
	this.LimitConds=null
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Botoes=null
	for (var i=0; i<this.Units.length; i++) {
		this.Units[0]=null
		this.Units.splice(0,1)
	}
}

Qledit.prototype.Send=function() {
	if (this.Provider == "") return
	var Unit=this.Units[this.Uix]
	Unit.Queue = false
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id + "._." + Unit.Key
	iblk.FUNC="GET1"
	if (Unit.Cond == "" && this.Selunico == "S") iblk.FUNC="GETU"
	iblk.COND=Unit.Cond
	if (this.PreCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCond
	}
	if (this.PreCondIns != "" && this.DatactlObj.HostFunc == "INS") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCondIns
	}
    var wval=""
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
        wval=""
		var col=this.Cols[i]
		iblk.CMPS.push(col.Id)
		if (col.HistGetId != "") {
			if (col.HistOp == "BL") {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "GE")
				if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "GE")
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "LE")
				if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "LE")
			} else {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
				if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", col.HistOp)
			}
		}
        wrec.push(wval)
	}
    iblk.DADOS.push(wrec)
	if (Unit.LimitCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += Unit.LimitCond
	}
	if (Unit.UserCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += Unit.UserCond
	}
	Unit.UserCond=""
	SendServer(this.HostPage, iblk, "SINGLE")
}

Qledit.prototype.Receive=function(iblk, unitkey) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == unitkey) {
			this.Uix=i;
			break;	
		}
	}
	var Unit=this.Units[this.Uix]
	var Adad=iblk.DADOS[0]
	if (Adad[this.KeyIndex] == "" && Unit.UserRequest == true) {  //não obteve registo
        this.ReceiveNull()
		return
	}
	Unit.UserRequest=false
	for (var i=0; i<this.Cols.length; i++) {
		// Se o controlo esta inactivo é porque está limitado pelo historial, então fazemos merge dos valores da base de dados com os presentes no historial
        var colHistIdx = GetHistorialIndex(this.HostPage.Area, this.Cols[i].Id, "EQ");
        if (this.Disabled && colHistIdx != -1) {
            Unit.Dados[i] = this.HostPage.Area.Historial[colHistIdx].Valor;
        }
        else {
			if (i < Adad.length) {
				Unit.Dados[i]=Adad[i]
			} else {
				Unit.Dados[i]=""
			}
		}
	}
	for (var i=0; i<Unit.Cols.length; i++) {
		if (i == this.KeyIndex) this.DatactlObj.StoreVal(this.Datafld, Unit.Dados[i], Unit)
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
            wctl.SetVal(FormatCol(wcol, Unit.Dados[i], "user"));
		}
		if (this.DatactlObj.Tipo == "FORM") SetHistorial(this.HostPage.Area, this.Cols[i], Unit.Dados[i])   //todos os valores para historial
	}
	for (var i=0; i<this.Limitedctls.length; i++) {
		this.Limitedctls[i].SetIndex(Unit.Key)
		this.Limitedctls[i].SetLimit(this, Unit)	
	}
	if (iblk.STAT == "OK" || iblk.STAT == "W") {
		Unit.Status="OK"
		this.SetMsg(iblk.MSG)
		this.VerifRotina()
        if (this.DatactlObj.Tipo == "FORM") this.DatactlObj.TestComplete();  //Inform the Form that status is complete
	} else {
		Unit.Status="ERR"
		this.SetMsg(iblk.MSG)
	}
	if (iblk.STAT == "W" || iblk.STAT == "EW") this.HostPage.ShowWarning(iblk.MSG)
}


//***************************************************************** QLEDITM - define Leditm
function Qleditm(xnod, hostpage) {
	this.Tipo="LEDITM"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Leditm" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a LEDITM(" + this.Id + ") Invalido"))
		return
	}
	this.Datactl=GetAtt(xnod, "DATACTL", "")
	this.DatactlObj=hostpage.GetCtl(this.Datactl)
	if (this.DatactlObj == null) {
		window.alert(GetMsg(1, "LEDITM (" + this.Id + ") referencia um DATACTL (" + this.Datactl + ") inválido"))
		return
	}

    //add this control to the host form
    if (this.DatactlObj.Tipo == "FORM") {
        var leditfound=false;
        for (var i=0; i<this.DatactlObj.LeditsUsed.length; i++) {
            if (this == this.DatactlObj.LeditsUsed[i]) leditfound=true;
        }
        if (leditfound == false) this.DatactlObj.LeditsUsed.push(this);
    }

	this.Datafld=GetAtt(xnod, "DATAFLD", "")
	this.DatafldIx=this.DatactlObj.GetColIndex(this.Datafld)
	if (this.DatafldIx == null) {
		window.alert(GetMsg(1, "LEDITM (" + this.Id + ") referencia um DATAFLD (" + this.Datafld + ") inválido"))
		return
	}
	this.Defcolord=GetAtt(xnod, "DEFCOLORD", "")
	this.SortCol=""
	this.SortOrder="ASC"
	var wcol=this.DatactlObj.Cols[this.DatafldIx]
	this.Obrig=wcol.Obrig
	this.KeyIndex=0
	this.Limiterctls=new Array()
	this.Limitedctls=new Array()
	this.LimitConds=new Array()
    this.LimitCols=new Array()
	this.PreCond=GetAtt(xnod, "COND", "")
	if (this.PreCond != "") {
		this.PreCond = SubstVarsExt(this.HostPage.Area, this.PreCond)
		this.PreCond = CondDecode(this.PreCond)
	}
	this.PreCondIns=GetAtt(xnod, "CONDINS", "")
	if (this.PreCondIns != "") {
		this.PreCondIns = SubstVarsExt(this.HostPage.Area, this.PreCondIns)
		this.PreCondIns = CondDecode(this.PreCondIns)
	}
	this.Msgctl=GetAtt(xnod, "MSGCTL", "")
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
	this.Selunico=GetAtt(xnod, "SELUNICO", "N")
	this,Disabled=false
	this.Cols=new Array()
	this.Events=new Array()
	//this.Hostval=""
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			if (wcol.Limitctl != "") {
				this.LimitConds.push("*")
                this.LimitCols.push(wcol.Id)
				var jaexiste=false
				for (var i=0; i<this.Limiterctls.length; i++) {
					if (wcol.Limitctl == this.Limiterctls[i]) {
						jaexiste=true
						break
					}
				}
				if (jaexiste == false) this.Limiterctls.push(wcol.Limitctl)
			}
			if (wcol.Key == "S") this.KeyIndex = this.Cols.length - 1
			//this.Dados.push("")
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	var defcol=""
    if (this.Defcolord != "") {
        defcol=this.Defcolord;
        this.SortOrder="";
    }
    for (var i=0; i<this.Cols.length; i++) {
        var wcol=this.Cols[i]
        if (defcol != "") {
            this.SortCol=defcol
        } else {
            if (wcol.Vis == "S") {
                if (this.SortCol == "") this.SortCol=wcol.Id
            }
        }
    }
	this.Units=new Array()
	this.Uix=-1
}

Qleditm.prototype.SetIndex=function(key) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == key) {
			this.Uix=i
			return
		}
	}
	this.Uix=-1
}

Qleditm.prototype.Activate=function(opt) {
	if (opt == "INIT") return
	if (this.Autostart != "S") return
	var Unit=null
	for (var i=0; i<this.Units.length; i++) {
		Unit=this.Units[i]
		if (Unit.Status == "" || opt == "Refresh") {
			this.Uix=i
			if (Unit.LimitsUsed == Unit.LimitConds.length) {
                this.CheckState(Unit)
            }
		}
	}
}

Qleditm.prototype.Execute=function(act, opt) {
	this.Autostart="S"
	this.Activate()
}


Qleditm.prototype.SetMsg=function(txt) {
	if (this.Msgctl != "") {
		var ctl=this.HostPage.GetCtl(this.Msgctl)
		ctl.SetVal(txt)
	}	
}

Qleditm.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qleditm.prototype.GetVal=function(ix) {
	var Unit=this.Units[this.Uix]
	if (Unit.SelectedIndex == -1) return ""
    var wval=""
	if (ix >=0 && ix < this.Cols.length) {
		wval=Unit.Dados[Unit.SelectedIndex][ix]
	}
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == ix) {
			wval=Unit.Dados[Unit.SelectedIndex][i]
		}
	}
    if (wval == undefined) wval=""
	return wval
}

Qleditm.prototype.SetVal=function(valor) {
	var Unit=this.Units[this.Uix]
	//if (valor == null) valor = this.DatactlObj.Dados[this.DatafldIx]
    if (valor == "00000000-0000-0000-0000-000000000000") valor=""  //Guid vazio
	Unit.Hostval=valor
	Unit.CondWasSet=true
    this.CheckState(Unit)
}

Qleditm.prototype.SetLimit=function(limiterctl, lunit) {
    var LimitsAdded=0
    var LimitsChanged=0
    var LimitsRemoved=0
    var Unit=this.Units[this.Uix]
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Limitctl == limiterctl.Id) {
            var wcol=this.Cols[i]
            if (lunit != undefined) limiterctl.SetIndex(lunit.Key)
            var wval=limiterctl.GetVal(wcol.Limitfld)
            if (wval == "00000000-0000-0000-0000-000000000000") wval=""  //Guid vazio
            var wlcond=AppendCond("", wcol.Id, wcol.Type, wval)
            for (var c=0; c<Unit.LimitConds.length; c++) {
                if (Unit.LimitCols[c] == wcol.Id) {
                    if (Unit.LimitConds[c] == "*" ) {
                        if (wcol.OptLimit == "S" && wval == "") {
                            Unit.LimitConds[c] = ""
                            LimitsAdded ++
                            Unit.LimitsUsed ++
                        } else {
                            if (wval != "") {
                                Unit.LimitConds[c] = wlcond
                                LimitsAdded ++
                                Unit.LimitsUsed ++
                            }
                        }
                    } else {
                        if (Unit.LimitConds[c] != wlcond) {
                            if (wcol.OptLimit == "S" && wval == "") {
                                Unit.LimitConds[c] = ""
                            } else {
                                Unit.LimitConds[c] = wlcond
                            }
                            LimitsChanged ++
                        }
                    }
                    break
                }
            }
        }
    }
    if (LimitsAdded == 0 && LimitsChanged == 0 && LimitsRemoved == 0) return;
    if (LimitsChanged != 0) {
        Unit.Cond = "" // se os limites foram alterados é porque houve uma acção do utilizador e portanto limpa a pre-seleção
        this.CheckState(Unit)
    } else {
        this.CheckState(Unit, "ADD")  //faz o CheckState com a opção ADD porque não é preciso fazer ReceiveNull se não atingir o numero total de limites resolvidos
    }
}

Qleditm.prototype.CheckState=function(Unit, opt) {
    if (Unit.CondWasSet == false) return  //o form ainda não forneceu chave externa nem vazia nem preenchida
    if (Unit.LimitsUsed == Unit.LimitConds.length) {
        if (Unit.LimitConds.length == 0) {
            Unit.LimitCond=""
        } else {
            Unit.LimitCond=Unit.LimitConds[0]
        }
        for (var c=1; c<Unit.LimitConds.length; c++) {
            if (Unit.LimitConds[c] != "") {
                if (Unit.LimitCond != "") Unit.LimitCond += "{"
                Unit.LimitCond += Unit.LimitConds[c]
            }
        }
        if (this.Autostart == "S") this.Send()
    } else {
        if (opt == "ADD") return;  //se apenas foi adicionado limite não é preciso fazer o ReceiveNull
        //this.ReceiveNull()
        if (Unit.Hostval == "") this.ReceiveNull()  //se o valor da chave estrangeira esta vazio faz o ReceiveNull e fica com Status=OK
        return
    }
}

Qleditm.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
}

Qleditm.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	if (this.DatactlObj.Tipo == "FORM") {
		if (this.Units.length == 0) {
			var lun=new QleditUnit(this)
			this.Units.push(lun)
		}
		this.Uix=0
	} else {
		var wrec=ctl.HostDataPanel.Record
		var encontrou=false
		for (var u=0; u<this.Units.length; u++) {
			if (this.Units[u].Record == wrec) {
				encontrou=true
				this.Uix=u
				break
			}
		}
		if (encontrou == false) {
			var lun=new QleditUnit(this)
			lun.Key=wrec.Key
			lun.Record=wrec
			this.Uix=this.Units.length
			this.Units.push(lun)
		}
	}
	var Unit=this.Units[this.Uix]
	Unit.Cols[ix].ColCtls.push(ctl)
	if (this.DatactlObj.Tipo == "FORM") {
		Unit.HostPanel=ctl.HostPanel
	} else {
		Unit.HostDataPanel=ctl.HostDataPanel
	}
	this.DatactlObj.AddFieldCtl(this.Datafld, Unit)
	return Unit.Key
}


Qleditm.prototype.StoreVal=function(fld, valor, ctl, opt) {
    if (this.DatactlObj.Tipo == "FORM") {
        this.Uix=0
    } else {
        if (ctl != null && ctl != undefined) {
            this.Uix=-1
            for (var i=0; i<this.Units.length; i++) {
                if (this.Units[i].HostDataPanel == ctl.HostDataPanel) {
                    this.Uix=i
                    break
                }
            }
        }
    }
	var Unit=this.Units[this.Uix]
	if (valor == null || valor == "") {
		Unit.SelectedIndex=-1
        this.DatactlObj.StoreVal(this.Datafld, "", Unit)
        for (var i=0; i<this.Limitedctls.length; i++) {
            this.Limitedctls[i].SetIndex(Unit.Key)
            this.Limitedctls[i].SetLimit(this, Unit)
        }
		return
	} else {
		Unit.SelectedIndex=Number(valor)
	}
    var wrec=Unit.Dados[Unit.SelectedIndex]
	var wval=wrec[this.KeyIndex]
    for (var i=0; i<Unit.Cols.length; i++) {
        if (this.DatactlObj.Tipo == "FORM") SetHistorial(this.HostPage.Area, this.Cols[i], wrec[i])   //todos os valores para historial
    }


	this.DatactlObj.StoreVal(this.Datafld, wval, Unit)
	for (var i=0; i<this.Limitedctls.length; i++) {
		this.Limitedctls[i].SetIndex(Unit.Key)
		this.Limitedctls[i].SetLimit(this, Unit)
	}
}

Qleditm.prototype.ReceiveNull=function() {
    var Unit=this.Units[this.Uix]
    Unit.Dados=new Array()
    var Arec=new Array()
    for (var i=0; i<Unit.Cols.length; i++) {
        Arec.push("")
    }
    Unit.Dados.push(Arec)
    Unit.SelectedIndex=-1
    for (var i=0; i<Unit.Cols.length; i++) {
        var wcol=Unit.Cols[i]
        for (var c=0; c<wcol.ColCtls.length; c++) {
            var wctl=wcol.ColCtls[c]
            wctl.SetList("")
            wctl.SetVal("")
        }
    }
    for (var i=0; i<this.Limitedctls.length; i++) {
        this.Limitedctls[i].SetIndex(Unit.Key)
        this.Limitedctls[i].SetLimit(this, Unit)
    }
    Unit.Status="OK";
    if (this.DatactlObj.Tipo == "FORM") this.DatactlObj.TestComplete();  //Inform the Form that status is complete
}


Qleditm.prototype.Disable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	this.DisaCtl.Add(tipo)
	for (var i=0; i<this.Units.length; i++) {
		var Unit=this.Units[i]
		for (var j=0; j<Unit.Cols.length; j++) {
			var wcol=Unit.Cols[j]
			for (var c=0; c<wcol.ColCtls.length; c++) {
				var wctl=wcol.ColCtls[c]
				wctl.Disable(tipo)
			}
		}
	}
	this.Disabled=true
}	
Qleditm.prototype.Enable=function(tipo) {
	if (this.DisaCtl == undefined) this.DisaCtl=new Qdisactl()  //usar Qdisactl para controlar pedidos de disable/enable
	if (this.DisaCtl.CanEnable(tipo) == true) {
		for (var i=0; i<this.Units.length; i++) {
			var Unit=this.Units[i]
			for (var j=0; j<Unit.Cols.length; j++) {
				var wcol=Unit.Cols[j]
				for (var c=0; c<wcol.ColCtls.length; c++) {
					var wctl=wcol.ColCtls[c]
					wctl.Enable(tipo)
				}
			}
		}
		this.Disabled=false
	}
}

Qleditm.prototype.Show=function() {
}
Qleditm.prototype.Hide=function() {
}

Qleditm.prototype.ShowErr=function(msg) {
	var Unit=this.Units[this.Uix]
	var j=msg.indexOf(" - ")
	if (j > 0) msg = msg.substr(j)
	var wcmp=""
	for (var i=0; i<Unit.Cols.length; i++) {
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
			if (wctl.Tipo == "COMBO") {
				wctl.ShowErr(wcol.Tit + msg)
				if (wcmp != "") wcmp += " / "
				wcmp += wcol.Tit
			}
		}
	}
	if (wcmp != "") window.alert(wcmp + msg)
}

Qleditm.prototype.HideErr=function() {
	var Unit=this.Units[this.Uix]
	for (var i=0; i<Unit.Cols.length; i++) {
		var wcol=Unit.Cols[i]
		for (var c=0; c<wcol.ColCtls.length; c++) {
			var wctl=wcol.ColCtls[c]
			if (wctl.Tipo == "COMBO") wctl.HideErr()
		}
	}
}

Qleditm.prototype.DestroyUnit=function(key) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == key) {
			this.Units[i]=null
			this.Units.splice(i,1)
			return
		}
	}
	return
}

Qleditm.prototype.Destroy=function() {
	this.Limiterctls=null
	this.Limitedctls=null
	this.LimitConds=null
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Botoes=null
}

Qleditm.prototype.Send=function() {
	if (this.Provider == "") return
	var Unit=this.Units[this.Uix]
	Unit.Queue = false
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id + "._." + Unit.Key
	iblk.FUNC="GET"
	iblk.OPT="NRECS[=[-1"
	iblk.COND=Unit.Cond
	if (this.PreCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCond
	}
	if (this.PreCondIns != "" && this.DatactlObj.HostFunc == "INS") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCondIns
	}
	var secorder = ""
    var wval=""
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
        wval=""
		var col=this.Cols[i]
		iblk.CMPS.push(col.Id)
		if (col.HistGetId != "") {
            var limitfound=false
			if (col.HistOp == "BL") {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "GE")
				if (hix > -1) {
                    iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "GE")
                    limitfound=true
                }
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "LE")
				if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "LE")
			} else {
				var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
				if (hix > -1){
                    iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", col.HistOp)
                    limitfound=true
                }
			}
            if (limitfound == false && col.OptLimit == "N") iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, "", "", col.HistOp)  //se o limite é obrigatório e não existe no historial cria condição nula
		}
		if (col.Id == this.SortCol) secorder = col.SecOrder
        wrec.push(wval)
	}
    iblk.DADOS.push(wrec)
	if (Unit.LimitCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += Unit.LimitCond
	}
	if (Unit.UserCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += Unit.UserCond
	}
	Unit.UserCond=""
	
	if (this.SortCol != "") {
		iblk.ORD=this.SortCol + " " + this.SortOrder
		if (secorder != "") iblk.ORD += ", " + secorder
	}

	SendServer(this.HostPage, iblk, "SINGLE")
}

Qleditm.prototype.Receive=function(iblk, unitkey) {
	for (var i=0; i<this.Units.length; i++) {
		if (this.Units[i].Key == unitkey) {
			this.Uix=i;
			break;	
		}
	}
	var Unit=this.Units[this.Uix]
	Unit.Dados=new Array()
	var Alistas=new Array()
	var Adad=iblk.DADOS
	Unit.SelectedIndex=-1
	for (var r=0; r<Adad.length; r++) {
		var Arec=new Array()
		var Aw=Adad[r]
		var j=0
		for (var i=0; i<this.Cols.length; i++) {
			if (this.Cols[i].Send == "N") {
				Arec.push("")
			} else {
				if (j < Aw.length) {
					if (i == this.KeyIndex) {
						if (Unit.Hostval == Aw[j]) Unit.SelectedIndex=r	
					}
					if (Unit.Cols[i].ColCtls[0] != undefined) {
						if (Alistas[i] == undefined) {
                            Alistas[i] = r + "[" + FormatCol(this.Cols[i], Aw[j], "user")
						} else {
                            Alistas[i]+="{" + r + "[" + FormatCol(this.Cols[i], Aw[j], "user")
						}
					}
					Arec.push(Aw[j])
					j++
				} else {
					Arec.push("")
				}
			}
		}
		Unit.Dados.push(Arec)
	}
	if (this.Selunico == "S" && Unit.Dados.length == 1) Unit.SelectedIndex = 0
    var wselected=Unit.SelectedIndex
	for (var i=0; i<this.Limitedctls.length; i++) {
		this.Limitedctls[i].SetIndex(Unit.Key)
		this.Limitedctls[i].SetLimit(this, Unit)
	}
	if (iblk.STAT == "OK" || iblk.STAT == "W") {
		Unit.Status="OK"
		this.SetMsg(iblk.MSG)
		for (var i=0; i<Unit.Cols.length; i++) {
			var wcol=Unit.Cols[i]
			for (var c=0; c<wcol.ColCtls.length; c++) {
				var wctl=wcol.ColCtls[c]
				if (Alistas[i] != undefined) {
                    wctl.SetVal("")
					wctl.SetList(Alistas[i])
                    Unit.SelectedIndex = wselected  //o SetList limpa o SelectedIndex por isso está aqui a ser reposto
				} else {
					wctl.SetList("")
				}
				if (Unit.SelectedIndex != -1) {
					wctl.SetVal(Unit.SelectedIndex + "")
				} else {
					wctl.SetVal("")
				}
			}
		}
        if (this.DatactlObj.Tipo == "FORM") this.DatactlObj.TestComplete();  //Inform the Form that status is complete
	} else {
		Unit.Status="ERR"
		this.SetMsg(iblk.MSG)
	}
	if (iblk.STAT == "W" || iblk.STAT == "EW") this.HostPage.ShowWarning(iblk.MSG)
}


//***************************************************************** - define dados para menu
function Qmenusrc(xnod, hostpage) {
	this.Tipo="MENUSRC"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Menusrc" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Val=GetAtt(xnod, "VAL", "")
	this.AutoCollapse=GetAtt(xnod, "AUTOCOLLAPSE", "N")
    this.HideSingleLevelZero=GetAtt(xnod, "HIDESINGLELEVELZERO", "S")
	this.Cols=new Array()
	this.Dados=new Array()
	this.Events=new Array()
	this.Grpctls=new Array()
	this.Botoes=new Array()
    this.Provider="internalmenu"
	this.Status=""
	this.Limiterctls=new Array()
	this.KeyIndex=0
	this.SelectedKeys=new Array()
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
	this.PreSelKey=""
	this.PointerKey=""
	this.Cond=""
	this.FrmCtl=""
	this.InsCount=0
	this.PanelOnEdit=""
	var xn=xnod.firstChild
	this.Cols.push(new Qcol(null, "key", "A", 3))
	this.Cols[0].Key="S"
	this.Cols.push(new Qcol(null, "niv", "A", 1))
	this.Cols.push(new Qcol(null, "mod", "A", 5))
	this.Cols.push(new Qcol(null, "nivseg", "A", 20))
	this.Cols.push(new Qcol(null, "label", "A", 150))
	this.Cols.push(new Qcol(null, "label2", "A", 150))
	this.Cols.push(new Qcol(null, "img", "A", 100))
	this.Cols.push(new Qcol(null, "act", "A", 300))
	this.Cols.push(new Qcol(null, "cond", "A", 300))
	this.Cols.push(new Qcol(null, "condmsg", "A", 300))
    this.Cols.push(new Qcol(null, "opt", "A", 10))
	this.Cols.push(new Qcol(null, "autoriz", "A", 1))
	this.Cols.push(new Qcol(null, "vis", "A", 1))
	this.Cols.push(new Qcol(null, "tipo", "A", 1))
    this.Cols.push(new Qcol(null, "id", "A", 15))
	var nlin=100
	while (xn!=undefined) {
		if (xn.nodeName == "LIN") {
			nlin++
            var dados=new Array()
            dados.push(nlin)
            dados.push(GetAtt(xn, "NIV", ""))
            dados.push(GetAtt(xn, "MOD", ""))
            dados.push(GetAtt(xn, "NIVSEG", ""))
            dados.push(GetAtt(xn, "LABEL", ""))
            dados.push(GetAtt(xn, "LABEL2", ""))
            dados.push(GetImageAddress(GetAtt(xn, "IMG", "")))
            dados.push(GetAtt(xn, "ACT", ""))
            dados.push(GetAtt(xn, "COND", ""))
            dados.push(GetAtt(xn, "CONDMSG", ""))
            dados.push(GetAtt(xn, "OPT", ""))
            dados.push("")
            dados.push("N")
            dados.push("")
            dados.push(GetAtt(xn, "ID", ""))
			var rec=new Qrecord(this.Cols, dados)
			this.Dados.push(rec)
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Func=""
    this.NiveisZero=0
	User.Actls.push(this)
}


Qmenusrc.prototype.Activate=function(opt) {
	if (opt == "Refresh") {
		for (var i=0; i<this.Dados.length; i++) {
			rec=this.Dados[i]
			rec.Field("vis").Val="N"
			rec.Field("tipo").Val=""
		}
	}
    this.NiveisZero=0
	var rec=""
	for (var i=0; i<this.Dados.length; i++) {
		rec=this.Dados[i]
		var autoriz="?"
		var niv=rec.Field("niv").Val
		var mod=rec.Field("mod").Val
		var nivseg=rec.Field("nivseg").Val
		var act=rec.Field("act").Val
		if (User.ModAutorizado(mod, nivseg) == false) autoriz="N" 
		if (User.ActAutorizado(mod, act) == false) autoriz="N"
		var cond=rec.Field("cond").Val
		var condmsg=rec.Field("condmsg").Val
		if (cond != "") {
			var wresult=true
			try {eval("wresult=(" + cond + ")")}
			catch(exp) {window.alert(GetMsg(1, "Condição de entrada de MenuSrc inválida"))}
			if (wresult == false) autoriz="M"
		}
		if (autoriz == "N" && condmsg != "") autoriz="M"
		if (autoriz == "?") {
			autoriz="S"
            if (niv == "0") this.NiveisZero++
		}
		rec.Field("autoriz").Val=autoriz
	}
	for (var i=0; i<this.Dados.length; i++) {
		rec=this.Dados[i]
		var temfilhos=false
		var expandido=false
		var niv=rec.Field("niv").Val
		var autoriz=rec.Field("autoriz").Val
		var vis=rec.Field("vis").Val
		for (var j=i+1; j<this.Dados.length; j++) {
			var wrec=this.Dados[j]
			var wniv=wrec.Field("niv").Val
			var wvis=wrec.Field("vis").Val
			if (wniv <= niv) break
			temfilhos=true
			if (wvis == "S") expandido=true
		}
		if (niv == "0") {
			if (autoriz == "S") {
                if (this.NiveisZero > 1) {
					vis="S"
				} else {
                    if (this.HideSingleLevelZero == "S") {  //esconde o nivel zero mostrando os seus dependentes
    					vis="I"
    					for (var j=i+1; j<this.Dados.length; j++) {
    						var wrec=this.Dados[j]
    						var wniv=wrec.Field("niv").Val
    						if (wniv <= niv) break
    						if (wniv == "1") wrec.Field("vis").Val = "S"
    					}
                    } else {
                        vis="S"  //fica visivel como quando ha mais niveis zero
                    }
				}
			}
		}
		var tipo="L"
		if (temfilhos == true) {
			if (expandido == true) {
				tipo="O"
			} else {
				tipo="C"
			}
		}
		rec.Field("tipo").Val=tipo
		rec.Field("vis").Val=vis
	}
	this.Paginas[0]="101"
	this.PagIndex=0
	this.PopulateGrid()
    for (var i = 0; i < this.Events.length; i++) {
        if (this.Events[i].Id == "AFTERINIT" && (opt == "Refresh" || opt == "INIT")) {
            ExecCmd(this.HostPage.Area, this.Events[i].Act);
        }
    }
}

Qmenusrc.prototype.Reset=function() {
	for (var i=0; i<this.Dados.length; i++) {
		rec=this.Dados[i]
		rec.Field("vis").Val="N"
		rec.Field("tipo").Val=""
	}
	this.Activate()
}

Qmenusrc.prototype.Execute=function(act, opt) {
	if (act == "CheckPerm") {
		this.VerifBotoes()
		return	
	}
    if (act == "NAVIGATE" || act == "NAVIGATEX" || act == "OPEN" || act == "CLOSE" || act == "EXEC") {
		if (this.PointerKey != "") {
			var wkey=this.PointerKey
			this.PointerKey=""
		} else {
			var wkey=this.SelectedKeys[0]
		}
		var row=this.GetRowFromKey(wkey)
		if (row == null || row == undefined) return
		var actcmd=row.Field("act").Val
		var tipo=row.Field("tipo").Val
		var autoriz=row.Field("autoriz").Val
		if (autoriz == "N") {
			window.alert(GetMsg(2))
			return
		}
		if (autoriz == "M") {
			window.alert(row.Field("condmsg").Val)
			return
		}
		if (act == "EXEC" || act == "NAVIGATEX") {
			if (actcmd != "") {
                ExecCmdDelayed(300, this.HostPage.Area, actcmd)
                if (opt == "RESETONEXECUTE") this.Reset()
            }
			if (act == "EXEC") return
		}
		if (tipo == "O" && act != "OPEN") {
			//fechar filhos
			var niv=row.Field("niv").Val
			row.Field("tipo").Val = "C"
			var found=false
			for (var i=0; i<this.Dados.length; i++) {
				var rec=this.Dados[i]
				if (found == true) {
					var wniv=rec.Field("niv").Val
					if (wniv > niv) rec.Field("vis").Val="N"
					if (wniv < niv) break
				}
				if (rec.Key == wkey) found=true
			}
		}
		if (tipo == "C" && act != "CLOSE") {
			//abrir filhos
			var niv=row.Field("niv").Val
			if (niv == "0") {
				var mod=row.Field("mod").Val
				for (var i=0; i<this.Dados.length; i++) {
					var rec=this.Dados[i]
					if (rec.Field("mod").Val != mod && rec.Field("niv").Val > "0") {
						rec.Field("vis").Val = "N"
					}
				}
			}
			var nivf = (Number(niv) + 1) + ""
			if (this.AutoCollapse == "S") {
				for (var i=0; i<this.Dados.length; i++) {
					var rec=this.Dados[i]
					if (rec.Field("niv").Val >= nivf) {
						rec.Field("vis").Val = "N"
					}
				}
			}
			var found=false
			for (var i=0; i<this.Dados.length; i++) {
				var rec=this.Dados[i]
				if (found == true) {
					var wniv=rec.Field("niv").Val
					if (wniv == nivf) rec.Field("vis").Val="S"
					if (wniv < nivf) break
				}
				if (rec.Key == wkey) found=true
			}
		}
		if (tipo == "L") {
			if (this.AutoCollapse == "S") {
				var niv=row.Field("niv").Val
				for (var i=0; i<this.Dados.length; i++) {
					var rec=this.Dados[i]
					if (rec.Field("niv").Val > niv) {
						rec.Field("vis").Val = "N"
					}
				}
			}
			//if (act == "OPEN") this.Activate()
            this.Activate()
		} else {
			this.Activate()
		}
		return	
	}
	var evtact=""
	var selobrig="S"
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == act) {
			evtact=this.Events[i].Act
			selobrig=this.Events[i].SelObrig
		}
	}
	if (evtact == "") return
	if (this.SelectedKeys.length == 0 && selobrig == "S") {
		window.alert(GetMsg(6))
  		return
	}
	if (selobrig == "N") {
    	SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], "")
    	for (var i=0; i<this.Cols.length; i++) {
	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
		    	SetHistorial(this.HostPage.Area, this.Cols[i], "")
	    	}
    	}
	} else {
    	var selk=""
    	for (var i=0; i<this.SelectedKeys.length; i++) {
	    	if (i > 0) selk += ";"
	    	selk += this.SelectedKeys[i]	
    	}
    	SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], selk)
    	var Row = this.GetRowFromKey(this.SelectedKeys[0])
    	for (var i=0; i<this.Cols.length; i++) {
	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
		    	SetHistorial(this.HostPage.Area, this.Cols[i], Row[i])
	    	}
    	}
	}
	if (evtact.indexOf("OpenPage") > -1 || evtact.indexOf("OpenDialog") > -1 || evtact.indexOf("External") > -1){
    	this.HostPage.CallerCtl = this
	}
	ExecCmdDelayed(20, this.HostPage.Area, evtact)
    if (opt == "RESETONEXECUTE") this.Reset()
}

Qmenusrc.prototype.CloseItem=function() {
	
}

Qmenusrc.prototype.PopulateGrid=function() {
	for (var i=0; i<this.Grpctls.length; i++) {
		this.Grpctls[i].SetVal("REFRESH")  //SetVal(null)	
	}
}


Qmenusrc.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qmenusrc.prototype.StoreVal=function(col, valor, ctl, opt) {
}

Qmenusrc.prototype.GetVal=function(ix) {
	if (this.SelectedKeys.length == 0) return ""
	var Row = this.GetRowFromKey(this.SelectedKeys[0])
	if (ix >=0 && ix < this.Cols.length) {
		return Row.Fields[ix].Val
	}
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == ix) {
			return Row.Fields[i].Val
		}
	}
	return ""	
}

Qmenusrc.prototype.GetValFromKey=function(ix, key) {
    var Row = this.GetRowFromKey(key)
    if (Row == null) return ""
    if (ix >=0 && ix < this.Cols.length) {
        return Row.Fields[ix].Val
    }
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == ix) {
            return Row.Fields[i].Val
        }
    }
    return ""   
}

Qmenusrc.prototype.GetIds=function(idstart, all) {  //obter id de entradas de menu dependentes directamente do idstart ou do primeiro nível se omitido; com all retorna todas as dependentes até ao ultimo elemento da arvore
    var wout=""
    var wniv=""
    for (var i=0; i<this.Dados.length; i++) {
        rec=this.Dados[i]
        var niv=rec.Field("niv").Val
        var autoriz=rec.Field("autoriz").Val
        var id=rec.Field("id").Val
        if (idstart == "" || idstart == undefined) {
            if (this.NiveisZero == 1 && this.HideSingleLevelZero == "S") {
                if (niv == "1" && autoriz == "S") wout += id + ";"
            } else {
                if (niv == "0" && autoriz == "S") wout += id + ";"
            }
        } else {
            if (id == idstart) {
                wniv=niv
            } else {
                if (wniv != "") {
                    if (niv <= wniv) {
                        wniv=""
                    } else {
                        if (all == true || niv == (Number(wniv) + 1) + "") wout += id + ";"
                    }
                }
            }
        }
    }
    if (wout != "") wout=wout.substr(0, wout.length-1)
    return wout   
}

Qmenusrc.prototype.NavigateToId=function(idsearch) {
    var wpath=new Array()
    var wtipo=new Array()
    for (var i=0; i<this.Dados.length; i++) {
        rec=this.Dados[i]
        var niv=Number(rec.Field("niv").Val)
        var id=rec.Field("id").Val
        var tipo=rec.Field("tipo").Val
        wpath[niv]=rec.Key
        wtipo[niv]=tipo
        if (id == idsearch) {
            for (var j=0; j<niv; j++) {
                if (wtipo[j] == "C") {
                    this.PointerKey=wpath[j]
                    this.SelectedKeys[0]=wpath[j]
                    this.Execute("NAVIGATEX")
                }
            }
            this.PointerKey=rec.Key
            this.SelectedKeys[0]=rec.Key
            this.Execute("NAVIGATEX")
            if (this.Grpctls[0].Tipo == "MENU") this.Grpctls[0].Execute("DetOut")
            return true
        }
    }
    return false
}

Qmenusrc.prototype.SetRow=function(key, multi) {
	if (multi == false) {
		this.SelectedKeys[0]=key
	}
}

Qmenusrc.prototype.SetPointer=function(key) {
	this.PointerKey=key
}

Qmenusrc.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
}

Qmenusrc.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	var Rec = ctl.HostDataPanel.Record
	var Field = Rec.Fields[ix]
	Field.ColCtls.push(ctl)
}

Qmenusrc.prototype.Disable=function() {
}
Qmenusrc.prototype.Enable=function() {
}
Qmenusrc.prototype.Show=function() {
}
Qmenusrc.prototype.Hide=function() {
}

Qmenusrc.prototype.VerifBotoes=function(situa) {
	for (var i=0; i<this.Events.length; i++) {
		if (User.ActAutorizado(this.HostPage.Modulo, this.Events[i].Act, this.HostPage.Area) == false) {
			this.Events[i].Disabled=true
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact) this.Botoes[b].Disable("AUT")
			}
		} else {
			this.Events[i].Disabled=false
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact && situa != "INIT") this.Botoes[b].Enable("AUT")
			}
		}
	}
}

Qmenusrc.prototype.DisableBotoesUpdate=function() {
	for (var i=0; i<this.Events.length; i++) {
		var act=this.Events[i].Act
		if (act != "") {
			var acts=act.split("{")
			for (var j=0; j<acts.length; j++) {
				var wact=acts[j]
				var Aw=wact.split("(")
				if (Aw[0] == "OpenPage" || Aw[0] == "OpenFirstPage" || Aw[0] == "OpenDialog") {
					var wperm=""
					var parms=Aw[1] + ",,,,,"
					var Aparms=parms.split(",")
					var wpag=Aparms[0]
					var wfunc=Aparms[1]
					if (wfunc == "ALT" || wfunc == "INS" || wfunc == "DUP" || wfunc == "ELI") {
						this.Events[i].Disabled=true
						for (var b=0; b<this.Botoes.length; b++) {
							if (this.Botoes[b].Act == "Execute(" + this.Id + "," + wfunc) this.Botoes[b].Disable("UPD")
						}
					}
				}
			}
		}
	}
}

Qmenusrc.prototype.GetRowFromKey=function(key) {
	for (var i=0; i<this.Dados.length; i++) {
		if (this.Dados[i].Key == key) return this.Dados[i]
	}
}

Qmenusrc.prototype.Destroy=function() {
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Grpctls=null
	this.Botoes=null
	this.SelectedKeys=null
	this.Paginas=null
	for (var i=0; i<User.Actls.length; i++) {
		if (User.Actls[i] == this) {
			User.Actls.splice(i,1)
			break
		}
	}
}


//***************************************************************** Qtreesrc - define fonte de dados hierarquicos
function Qtreesrc(xnod, hostpage) {
	this.Tipo="TREESRC"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Treesrc" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a TREESRC(" + this.Id + ") Invalido"))
		return
	}
	this.Providers=this.Provider.split("[")
	this.Forniv=GetAtt(xnod, "FORNIV", "")
	this.Fornivs=this.Forniv.split("[")
	this.Msgctl=GetAtt(xnod, "MSGCTL", "")
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
	this.Defcolord=GetAtt(xnod, "DEFCOLORD", "")
	this.Search=GetAtt(xnod, "SEARCH", "")
	this.Nrecs=GetAtt(xnod, "NRECS", 0, "N")
	this.Val=GetAtt(xnod, "VAL", "")
	this.AutoCollapse=GetAtt(xnod, "AUTOCOLLAPSE", "N")
	this.Cols=new Array()
	this.Dados=new Array()
	this.Events=new Array()
	this.Grpctls=new Array()
	this.Botoes=new Array()
	this.Status=""
	this.KeyIndex=0
	this.SelectedKeys=new Array()
	this.LimitConds=new Array()
	this.LimitCond=""
	this.Limitedctls=new Array()
	this.Limiterctls=new Array()
	this.LimitsUsed=0
	this.Paginas=new Array()
	this.PagIndex=-1
	this.PagFimSup=true
	this.PagFimInf=true
	this.PreSelKey=""
	this.PointerKey=""
	this.Cond=""
	this.Order=""
	this.FrmCtl=""
	this.InsCount=0
	this.PanelOnEdit=""
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			if (wcol.Limitctl != "") {
				if (wcol.Limitctl != "*" && wcol.Limitctl != "**") {
					this.LimitConds.push("")
					var jaexiste=false
					for (var i=0; i<this.Limiterctls.length; i++) {
						if (wcol.Limitctl == this.Limiterctls[i]) {
							jaexiste=true
							break
						}
					}
					if (jaexiste == false) {
						this.Limiterctls.push(wcol.Limitctl)
						var wctl=this.HostPage.GetCtl(wcol.Limitctl)
						if (wctl == null) {
							window.alert(GetMsg(1, "O TREESRC(" + this.Id + ") referencia um LIMITCTL(" + wcol.Limitctl + ") inexistente"))
						} 
						if (wctl.Tipo == "FORM") {
							this.FrmCtl=wctl
							wctl.Updatectls.push(this)
						}
					}
				}
			}
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Cols.push(new Qcol(null, "niv", "A", 1))
	this.Cols.push(new Qcol(null, "vis", "A", 1))
	this.Cols.push(new Qcol(null, "tipo", "A", 1))
    this.Cols.push(new Qcol(null, "label", "A", 100))
	this.Func=""
}


Qtreesrc.prototype.Activate=function(opt) {
	if (opt == "INIT") {
		this.VerifBotoes("INIT")
		for (j=0; j<this.Limiterctls.length; j++) {
			var lctl=this.HostPage.GetCtl(this.Limiterctls[j])
			if (lctl.Tipo == "FORM" && lctl.HostFunc == "VIS") {
				this.DisableBotoesUpdate()
				break
			}	
		}
		if (this.Limiterctls.length > 0 || this.Autostart == "N") return
	}
	this.SendRequest()
	//this.Paginas[0]="101"
	//this.PagIndex=0
}

Qtreesrc.prototype.Execute=function(act, opt) {
	if (this.Autostart == "N") {
		this.Autostart="S"
		this.Activate()
	}
	if (act == "CheckPerm") {
		this.VerifBotoes()
		return	
	}
	if (act == "Clear") {
		this.Dados=new Array()
		this.SelectedKeys=new Array()
		this.Paginas=new Array()
		this.PagIndex=-1
		this.PagFimSup=true
		this.PagFimInf=true
		this.PreSelKey=""
		this.PointerKey=""
		this.PopulateGrid()
		return
    }
    if (act == "SelectAll") {
        this.SelectedKeys = new Array()
        for (var i = 0; i < this.Dados.length; i++) {
            this.SelectedKeys.push(this.Dados[i].Key)
        }
        this.PopulateGrid()
        return
    }
    if (act == "DeselectAll") {
        this.SelectedKeys = new Array()
        this.PopulateGrid()
        return
    }
	if (act == "NAVIGATE" || act == "NAVIGATEX") {
		if (this.PointerKey != "") {
			var wkey=this.PointerKey
		} else {
			var wkey=this.SelectedKeys[0]
		}
		var row=this.GetRowFromKey(wkey)
		if (row == null || row == undefined) return
		var tipo=row.Field("tipo").Val
		if (tipo == "O") {
			//fechar filhos
			var niv=row.Field("niv").Val
			row.Field("tipo").Val = "C"
			var found=false
			for (var i=0; i<this.Dados.length; i++) {
				var rec=this.Dados[i]
				if (found == true) {
					var wniv=rec.Field("niv").Val
					if (wniv > niv) {
						rec.Field("vis").Val="N"
						if (rec.Field("tipo").Val == "O") rec.Field("tipo").Val="C"
					}
					if (wniv <= niv) break
				}
				if (rec.Key == wkey) found=true
			}
			this.PopulateGrid()
			return
		}
		if (tipo == "C") {
			//abrir filhos
			var niv=row.Field("niv").Val
			var nivf = (Number(niv) + 1) + ""
			if (this.AutoCollapse == "S") {
				for (var i=0; i<this.Dados.length; i++) {
					var rec=this.Dados[i]
					var wniv=rec.Field("niv").Val
					if (wniv >= nivf) {
						rec.Field("vis").Val = "N"
						if (rec.Field("tipo").Val == "O") rec.Field("tipo").Val="C"
					}
					if (wniv == niv && rec.Key != wkey) {
						if (rec.Field("tipo").Val == "O") rec.Field("tipo").Val="C"
					}
				}
			}
			var found=false
			var filhos=false
			for (var i=0; i<this.Dados.length; i++) {
				var rec=this.Dados[i]
				if (found == true) {
					var wniv=rec.Field("niv").Val
					if (wniv == nivf) {
						rec.Field("vis").Val="S"
						filhos=true
					}
					if (wniv < nivf) break
				}
				if (rec.Key == wkey) found=true
			}
			var tipo=row.Field("tipo").Val
			if (filhos == false && tipo != "L") {
				//this.SendRequest()
				this.SetInternalLimit(niv, row)
				return
			}
			if (filhos == true) row.Field("tipo").Val="O"
			this.PopulateGrid()
			return
		}
		this.PointerKey=""
		if (act == "NAVIGATE") return
		if (tipo == "L") this.Execute("EXECUTE")
		return	
	}
	var evtact=""
	var selobrig="S"
	for (var i=0; i<this.Events.length; i++) {
		if (this.Events[i].Id == act) {
			evtact=this.Events[i].Act
			selobrig=this.Events[i].SelObrig
		}
	}
	if (evtact == "") return
	if (this.SelectedKeys.length == 0 && selobrig == "S") {
		window.alert(GetMsg(6))
  		return
	}
	if (selobrig == "N") {
    	SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], "")
    	for (var i=0; i<this.Cols.length; i++) {
	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
		    	SetHistorial(this.HostPage.Area, this.Cols[i], "")
	    	}
    	}
	} else {
    	var selk=""
    	for (var i=0; i<this.SelectedKeys.length; i++) {
	    	if (i > 0) selk += ";"
	    	selk += this.SelectedKeys[i]	
    	}
    	SetHistorial(this.HostPage.Area, this.Cols[this.KeyIndex], selk)
    	var Row = this.GetRowFromKey(this.SelectedKeys[0])
    	for (var i=0; i<this.Cols.length; i++) {
	    	if (i != this.KeyIndex && this.Cols[i].HistId != "") {
		    	SetHistorial(this.HostPage.Area, this.Cols[i], Row[i])
	    	}
    	}
	}
	if (evtact.indexOf("OpenPage") > -1 || evtact.indexOf("OpenDialog") > -1 || evtact.indexOf("External") > -1){
    	this.HostPage.CallerCtl = this
	}
	ExecCmdDelayed(20, this.HostPage.Area, evtact)
}


Qtreesrc.prototype.PopulateGrid=function() {
	for (var i=0; i<this.Grpctls.length; i++) {
		this.Grpctls[i].SetVal("REFRESH")	
	}
}


Qtreesrc.prototype.GetColIndex=function(colid) {
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == colid) {
			return i
		}
	}
	return null
}

Qtreesrc.prototype.StoreVal=function(col, valor, ctl, opt) {
}

Qtreesrc.prototype.SetMsg=function(txt) {
	if (this.Msgctl != "") {
		var ctl=this.HostPage.GetCtl(this.Msgctl)
		ctl.SetVal(txt)
	}
}

Qtreesrc.prototype.GetVal = function(ix, opt) {
    if (opt == "COUNT") return this.SelectedKeys.length
    if (this.SelectedKeys.length == 0) return ""
    if (opt == "" || opt == undefined) {
        var Row = this.GetRowFromKey(this.SelectedKeys[0])
        if (ix >= 0 && ix < this.Cols.length) {
            return Row.Fields[ix].Val
        } else {
            for (var i = 0; i < this.Cols.length; i++) {
                if (this.Cols[i].Id == ix) {
                    return Row.Fields[i].Val
                }
            }
        }
        return ""
    }
    var wdelim = ""
    var wsep = ""
    var ixcol = 0;
    var wprovider = ""
    if (opt == "PV") wsep = ";"
    if (opt == "SQL") {
        wsep = ","
        wdelim = "?"
    }
    for (var i = 0; i < this.Cols.length; i++) {
        if (this.Cols[i].Id == ix) {
            ixcol = i
            wprovider = this.Cols[i].Provider
            if (wdelim == "?") {
                if (this.Cols[i].Type == "A" || this.Cols[i].Type == "D" || this.Cols[i].Type == "H" || this.Cols[i].Type == "S") {
                    wdelim = "'"
                } else {
                    wdelim = ""
                }
            }
            break
        }
    }
    var Row = this.GetRowFromKey(this.SelectedKeys[0]);
    var selniv = Row.Field("niv").Val;
    var wout = ""
    for (var i = 0; i < this.SelectedKeys.length; i++) {
        var Row = this.GetRowFromKey(this.SelectedKeys[i])
        var wniv = Row.Field("niv").Val
        if (wniv == selniv) {
            if (i > 0) wout += wsep
            wout += wdelim + Row.Fields[ixcol].Val + wdelim
        }
    }
    return wout
}

Qtreesrc.prototype.SetRow=function(key, multi) {
	if (multi == false) {
		this.SelectedKeys[0]=key
		this.PointerKey=key
	} else {
		for(var s=0; s<this.SelectedKeys.length; s++) {
			if (key == this.SelectedKeys[s]) {
				this.SelectedKeys.splice(s,1)
				this.PointerKey=""
				return false	
			}
		}
		var warray=new Array()
		warray.push(key)
		this.SelectedKeys = warray.concat(this.SelectedKeys)
		this.PointerKey=key
		return true
	}
}

Qtreesrc.prototype.SetLimit=function(limiterctl, lunit) {
	/*
	if (limiterctl == this) {
		SetInternalLimit(lunit)
		return	
	}
	*/
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Limitctl == limiterctl.Id) {
			var wcol=this.Cols[i]
			if (lunit != undefined) limiterctl.SetIndex(lunit.Key)
			var wval=limiterctl.GetVal(wcol.Limitfld)
			for (var c=0; c<this.LimitConds.length; c++) {
				if (this.LimitConds[c] == "" || this.LimitConds[c].indexOf(wcol.Id) == 0) {
					if (this.LimitConds[c] == "") this.LimitsUsed++
					this.LimitConds[c]=AppendCond("", wcol.Id, wcol.Type, wval)
					break
				}
			}
		}
	}
	if (this.LimitsUsed == this.LimitConds.length) {
		this.LimitCond=this.LimitConds[0]
		for (var c=1; c<this.LimitConds.length; c++) {
			this.LimitCond += "{" + this.LimitConds[c]
		}
		this.SelectedKeys=new Array()
		//this.LimitConds=new Array()
		//this.LimitsUsed=0
		this.Paginas=new Array()
		this.PagIndex=-1
		this.PagFimSup=true
		this.PagFimInf=true
		this.PreSelKey=""
		this.PointerKey=""
		this.Dados=new Array()
		this.SendRequest()
	}
}

Qtreesrc.prototype.SetInternalLimit=function(nivel, rec) {
	var wniv=Number(nivel)
	var wprovider=this.GetProviderForNiv(wniv + 1)
	var wcond=""
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Provider == wprovider) {
            if (this.IsNivRecursive(wniv)) {
                if (this.Cols[i].Limitctl == "**") {
                    if (rec != undefined) {
                        var wfield=rec.Field(this.Cols[i].Limitfld)
                        wcond=AppendCond(wcond, this.Cols[i].Id, wfield.Coldef.Type, wfield.Val)
                    } else {  //o rec esta undefined porque é uma tabela hierarquica logo no primeiro nivel e esta rotina foi invocada pelo SendRequest
                        wcond=AppendCond(wcond, this.Cols[i].Id, this.Cols[i].Type, "")
                    }
                }
            } else {
                if (this.Cols[i].Limitctl == "*") {
                    var wfield=rec.Field(this.Cols[i].Limitfld)
                    wcond=AppendCond(wcond, this.Cols[i].Id, wfield.Coldef.Type, wfield.Val)
                }
            }
		}
	}
	this.LimitCond=wcond
	if (rec != undefined) this.SendRequest()  //se rec==undefined é porque foi invocada pelo SendRequest e portanto não faz SendRequest
}

Qtreesrc.prototype.SetPointer=function(key) {
	this.PointerKey=key
}

Qtreesrc.prototype.GetCol=function(colid) {
	var ix=this.GetColIndex(colid)
	if (ix != null) return this.Cols[ix]
}

Qtreesrc.prototype.AddFieldCtl=function(colid, ctl) {
	var ix=this.GetColIndex(colid)
	if (ix == null) return
	var Rec = ctl.HostDataPanel.Record
	var Field = Rec.Fields[ix]
	Field.ColCtls.push(ctl)
}

Qtreesrc.prototype.Disable=function() {
}
Qtreesrc.prototype.Enable=function() {
}
Qtreesrc.prototype.Show=function() {
}
Qtreesrc.prototype.Hide=function() {
}

Qtreesrc.prototype.VerifBotoes=function(situa) {
	for (var i=0; i<this.Events.length; i++) {
		if (User.ActAutorizado(this.HostPage.Modulo, this.Events[i].Act, this.HostPage.Area) == false) {
			this.Events[i].Disabled=true
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact) this.Botoes[b].Disable("AUT")
			}
		} else {
			this.Events[i].Disabled=false
			var wact="Execute(" + this.Id + "," + this.Events[i].Id
			for (var b=0; b<this.Botoes.length; b++) {
				if (this.Botoes[b].Act == wact && situa != "INIT") this.Botoes[b].Enable("AUT")
			}
		}
	}
}

Qtreesrc.prototype.DisableBotoesUpdate=function() {
	for (var i=0; i<this.Events.length; i++) {
		var act=this.Events[i].Act
		if (act != "") {
			var acts=act.split("{")
			for (var j=0; j<acts.length; j++) {
				var wact=acts[j]
				var Aw=wact.split("(")
				if (Aw[0] == "OpenPage" || Aw[0] == "OpenFirstPage" || Aw[0] == "OpenDialog") {
					var wperm=""
					var parms=Aw[1] + ",,,,,"
					var Aparms=parms.split(",")
					var wpag=Aparms[0]
					var wfunc=Aparms[1]
					if (wfunc == "ALT" || wfunc == "INS" || wfunc == "DUP" || wfunc == "ELI") {
						this.Events[i].Disabled=true
						for (var b=0; b<this.Botoes.length; b++) {
							if (this.Botoes[b].Act == "Execute(" + this.Id + "," + wfunc) this.Botoes[b].Disable("UPDATE")
						}
					}
				}
			}
		}
	}
}

Qtreesrc.prototype.GetRowFromKey=function(key) {
	for (var i=0; i<this.Dados.length; i++) {
		if (this.Dados[i].Key == key) return this.Dados[i]
	}
}

Qtreesrc.prototype.GetProviderForNiv=function(niv) {  //Saber qual o PROVIDER para o nivel indicado
	var wniv="" + niv
	for (var i=0; i<this.Providers.length; i++) {
		if (this.Fornivs[i] == wniv || this.Fornivs[i] == "*") return this.Providers[i]
	}
	return ""
}

Qtreesrc.prototype.IsNivRecursive=function(niv) {  //Saber se o nivel indicado é de uma tabela hierárquica
    if (niv == -1) niv=0
    if (niv < this.Providers.length) {
        if (this.Fornivs[niv] == "*") return true
    } else {
        if (this.Fornivs[this.Providers.length - 1] == "*") return true
    }
    return false
}

Qtreesrc.prototype.GetKeyFldForNiv=function(niv) {
	var wniv="" + niv
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].indexOf(wniv) > -1) return this.Providers[i]
	}
	return ""
}


Qtreesrc.prototype.Destroy=function() {
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Grpctls=null
	this.Botoes=null
	this.SelectedKeys=null
	this.Paginas=null
}


Qtreesrc.prototype.SendRequest=function(mais) {
	if (this.Provider == "" || this.Provider == "*") return
	var iblk=new Interblk()
	iblk.APP=""
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	var pai=""
	var niv=-1
	if (this.PointerKey != "") {
		var wkey=this.PointerKey
	} else {
		var wkey=this.SelectedKeys[0]
	}
	if (wkey != undefined) {
		var Akey=wkey.split("[")
		pai=Akey[1]
		niv=Number(Akey[0])
	}
	var provider=this.GetProviderForNiv(niv + 1)
	/*
	var provpai=this.GetProviderForNiv(niv)
	var keypai=""
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		if (col.Provider == provpai && col.Key == "S") {
			keypai=col.Id
			break;
		}
	}
	*/
	iblk.APP=provider
    iblk.FUNC="GETN2"
    if (this.IsNivRecursive(niv)) {
        iblk.FUNC="GETNIVELTREE"
        if (niv == -1) this.SetInternalLimit("0")
    }
	if (this.LimitCond != "") {
		iblk.COND=this.LimitCond
		//var Aw=this.LimitCond.split("[")
		//iblk.OPT="KFLD[=[" + Aw[0] + "{KVAL[=[" + Aw[2].replace(/[']/g,"")
		this.LimitCond=""
	//} else {
		//iblk.OPT="KFLD[=[" + keypai + "{KVAL[=[" + pai
	}
	if (this.HostPage.Cond != "") iblk.COND=CondDecode(this.HostPage.Cond)
	if (this.PreCond != "" && this.PreCond != undefined) {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.PreCond
	}
	if (this.Cond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.Cond
	}
    var wval=""
    var wrec=new Array()
	for (var i=0; i<(this.Cols.length - 2); i++) {
        wval=""
		var col=this.Cols[i]
		if (col.Provider == provider) {
			if (col.Send != "N") {
				iblk.CMPS.push(col.Id)
				wrec.push(wval)
			}
			if (col.HistGetId != "") {
				if (col.HistOp == "BL") {
					var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "GE")
					if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "GE")
					var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, "LE")
					if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", "LE")
				} else {
					var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
					if (hix > -1) iblk.COND=AppendCond(iblk.COND, this.Cols[i].Id, this.Cols[i].Type, this.HostPage.Area.Historial[hix].Valor, "", col.HistOp)
				}
			}
		}
	}
    iblk.DADOS.push(wrec)
	if (this.LimitCond != "") {
		if (iblk.COND != "") iblk.COND += "{"
		iblk.COND += this.LimitCond
	}
    var word=""
    for (var i=0; i<(this.Cols.length); i++) {
        var col=this.Cols[i]
        if (col.Provider == provider) {
            if (col.Vis == "S") {
                if (word != "") word += ", "
                word += col.Id + " ASC"
            }
        }
    }
    iblk.ORD=word
	iblk=SendServer(this.HostPage, iblk, "SINGLE")
}


Qtreesrc.prototype.Receive=function(iblk, gstatus, last) {
	var pai=""
	var niv=-1
	if (this.PointerKey != "") {
		var wkey=this.PointerKey
	} else {
		var wkey=this.SelectedKeys[0]
	}
	if (wkey != undefined) {
		var Akey=wkey.split("[")
		pai=Akey[1]
		niv=Number(Akey[0])
	}
	var provider=this.GetProviderForNiv(niv + 1)
	var Adad=iblk.DADOS
    var vazio=false
    if (Adad.length == 1) {
        if (Adad[0].length == 0) {
            vazio=true
        } else {
            vazio=true
            for (var i=0; i<Adad[0].length; i++) {
                if(Adad[0][i] != "") vazio=false
            }
        }
    }
    var winiv=niv + 1
	if (pai != "") {
		var rec=this.GetRowFromKey(niv + "[" + pai)
		if (vazio == true) {
			rec.Field("tipo").Val="L"
		} else {
			rec.Field("tipo").Val="O"
			var Ndados=new Array()
			for (var i=0; i<this.Dados.length; i++) {
				rec=this.Dados[i]
				if (rec.Key == wkey) {
					Ndados.push(rec)
					for (var r=0; r<Adad.length; r++) {
						var nrec=new Qrecord(this.Cols, Adad[r], provider, rec)
						nrec.Field("niv").Val="" + winiv
						nrec.Field("vis").Val="S"
						nrec.Field("tipo").Val="C"
						nrec.Key=(winiv) + "[" + nrec.Key
                        var wlabel=""
                        for (var c=0; c<this.Cols.length; c++) {
                            if (this.Cols[c].Vis == "S" && this.Cols[c].Provider == provider) {
                                if (wlabel != "") wlabel += " "
                                wlabel += nrec.Fields[c].Val
                            }
                        }
                        nrec.Field("label").Val=wlabel
						Ndados.push(nrec)
					}
				} else {
					Ndados.push(rec)
				}
			}
			this.Dados = Ndados
		}
	} else {
		this.Dados=new Array()
		for (var r=0; r<Adad.length; r++) {
			var nrec=new Qrecord(this.Cols, Adad[r], provider)
			nrec.Field("niv").Val="" + winiv
			nrec.Field("vis").Val="S"
			nrec.Field("tipo").Val="C"
			nrec.Key=(niv+1) + "[" + nrec.Key
            var wlabel=""
            for (var c=0; c<this.Cols.length; c++) {
                if (this.Cols[c].Vis == "S" && this.Cols[c].Provider == provider) {
                    if (wlabel != "") wlabel += " "
                    wlabel += nrec.Fields[c].Val
                }
            }
            nrec.Field("label").Val=wlabel
			this.Dados.push(nrec)
		}
	}
	this.SetMsg(iblk.MSG)
	if (iblk.STAT.indexOf("W") != -1) this.HostPage.ShowWarning(iblk.MSG)

	if (iblk.STAT.indexOf("OK") != -1) {
		this.Paginas[0]=this.Dados[0].Key
		this.PagIndex=0
		this.Status="OK"
		this.PopulateGrid()
		for (var i = 0; i < this.Events.length; i++) {
		    if (this.Events[i].Id == "AFTERREAD") {
		        ExecCmd(this.HostPage.Area, this.Events[i].Act)
		    }
		}
	} else {
		this.Status="ERR"
		this.PopulateGrid()
	}
	if (pai != "" && vazio == true) this.Execute("CLK")
}


//***************************************************************** QROTINA - define Rotina
function Qrotina(xnod, hostpage) {
	this.Tipo="ROTINA"
	this.Class="ROTINA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Rotina" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Formula=new Qformula(xnod, this)
}

Qrotina.prototype.Activate=function(opt) {
	return
}

Qrotina.prototype.TestExec=function(idform) {
	var formula=this.Formula
	var nok=0
	var flagform=false
    var argsnumber=formula.Args.length
	for (var i=0; i<formula.Args.length; i++) {
		var arg=formula.Args[i]
		if (arg.Tipo == "COL") {
            if (arg.Ctl.Tipo == "LEDIT" || arg.Ctl.Tipo == "LEDITM") {
                for (var u=0; u<arg.Ctl.Units.length; u++) {   // só pode avaliar formula depois de ter registo(s) lido(s) em todas as Units
                    if (arg.Ctl.Units[u].Status != "OK") return;
                }
            } else {
                if (arg.Ctl.Tipo == "FORM") {
                    if (arg.Ctl.Status != "OK" && arg.Ctl.Status != "ERR") return  // só pode avaliar formula depois de ter registo(s) lido(s) num FORM. O ERR foi acrescentado pq no caso de erro no retorno do servidor as rotinas não eram executadas
                } else {
                    if (arg.Ctl.Status != "OK") return  // só pode avaliar formula depois de ter registo(s) lido(s) num controlo diferente de FORM
                }
            }
			if (idform != undefined) {
				if (idform == arg.Ctl.Id) flagform=true	
			}
			if (arg.Ctl.Tipo == "MULTIFORM") {
                var wval=""
                var colstat=""
                var coltype=""
                for (var k=0; k<arg.Ctl.SelectedKeys.length; k++) {
                    var wkey=arg.Ctl.SelectedKeys[k]
                    var Rec = arg.Ctl.GetRowFromKey(wkey)
                    if (k > 0) wval += "["
                    if (Rec != null) {
                        wval += Rec.Fields[arg.ColIndex].Val
                        if (k == 0) colstat=Rec.Fields[arg.ColIndex].Status
                        coltype = Rec.Fields[arg.ColIndex].Coldef.Type
                    }
                }
                /*
				var Rec = arg.Ctl.GetRowFromKey(arg.Ctl.SelectedKeys[0])
				var wval=Rec.Fields[arg.ColIndex].Val
				var colstat=Rec.Fields[arg.ColIndex].Status
                */
			} else {
				var wval=arg.Ctl.GetVal(arg.ColIndex)
				var colstat = arg.Ctl.Cols[arg.ColIndex].Status
                var coltype = arg.Ctl.Cols[arg.ColIndex].Type
			}
            //revert to null value "" fields for different datatypes 
            if (coltype == "N" || coltype == "$") {
                if (ConvertToNative(wval, coltype) == 0) wval="";
            }
            if (coltype == "B") {
                if (wval == false) wval="";
            }
        }
        if (arg.Trigger == "ALLWAYS") nok++;
        if (arg.Trigger == "NULL" && wval == "") nok++;
        if (arg.Trigger == "NOTNULL" && wval != "") nok++;
        if (arg.Trigger == "MOD" && colstat == "M") nok++;
        if (arg.Trigger == "NULLMOD" && wval == "" && colstat == "M") nok++;
        if (arg.Trigger == "NOTNULLMOD" && wval != "" && colstat == "M") nok++;
        if (arg.Trigger == "NEVER") argsnumber--;
	}
	if (flagform == true || idform == undefined) {
		if (formula.TriggerOr == "N") {
			if (nok == argsnumber && argsnumber > 0) this.Execute();
		} else {
			if (nok > 0) this.Execute();
		}
	}
}

Qrotina.prototype.TestRefresh=function() {
	var formula=this.Formula
	var nok=0
	var refresh=false
    var argsnumber=formula.Args.length
	for (var i=0; i<formula.Args.length; i++) {
		var arg=formula.Args[i]
		if (arg.Tipo == "COL") {
			if (arg.Ctl.Tipo == "MULTIFORM") {
                var wval=""
                var colstat=""
                var coltype=""
                for (var k=0; k<arg.Ctl.SelectedKeys.length; k++) {
                    var wkey=arg.Ctl.SelectedKeys[k]
                    var Rec = arg.Ctl.GetRowFromKey(wkey)
                    if (k > 0) wval += "["
                    if (Rec != null) {
                        wval += Rec.Fields[arg.ColIndex].Val
                        if (k == 0) colstat=Rec.Fields[arg.ColIndex].Status
                        coltype = Rec.Fields[arg.ColIndex].Coldef.Type
                    }
                }
                /*
				var Rec = arg.Ctl.GetRowFromKey(arg.Ctl.SelectedKeys[0])
				var wval=Rec.Fields[arg.ColIndex].Val
				var colstat=Rec.Fields[arg.ColIndex].Status
                */
			} else {
				var wval=arg.Ctl.GetVal(arg.ColIndex)
				var colstat = arg.Ctl.Cols[arg.ColIndex].Status
                var coltype = arg.Ctl.Cols[arg.ColIndex].Type
			}
            //revert to null value "" fields for different datatypes 
            if (coltype == "N" || coltype == "$") {
                if (ConvertToNative(wval, coltype) == 0) wval="";
            }
            if (coltype == "B") {
                if (wval == false) wval="";
            }
            if (arg.Trigger == "REFRESH") {
                nok++;
                refresh=true;
            }
        } else {  //arg.Tipo != "COL"
            if (arg.Trigger == "REFRESH") refresh=true;
        }
        if (arg.Trigger == "ALLWAYS") nok++;
        if (arg.Trigger == "NULL" && wval == "") nok++;
        if (arg.Trigger == "NOTNULL" && wval != "") nok++;
        if (arg.Trigger == "MOD" && colstat == "M") nok++;
        if (arg.Trigger == "NULLMOD" && wval == "" && colstat == "M") nok++;
        if (arg.Trigger == "NOTNULLMOD" && wval != "" && colstat == "M") nok++;
        if (arg.Trigger == "NEVER") argsnumber--;
	}
	if (nok == argsnumber && argsnumber > 0 && refresh == true) this.Execute();
}

Qrotina.prototype.Execute = function(arg1, arg2, arg3, async, callback, commtimeout) {
    this.Async=async;
    this.Callback=callback;
    this.CommTimeout=commtimeout;
    RotStatus = "OK"
    RotMsg = ""
    RotMsgId = ""
    RotResult = ""
    var wresult = new Array()
    var Valores = new Array()
    var formula = this.Formula
    if (formula.Functionid != "") {   //****** formula local
        wcmd = "var wresult = " + formula.Functionid + "("
        for (var i = 0; i < formula.Args.length; i++) {
            var Arg = formula.Args[i]
            if (i > 0) wcmd += ", "
            if (Arg.Tipo == "HIST") {
                var hix = GetHistorialIndex(this.HostPage.Area, Arg.HistGetId, Arg.HistOp)
                if (hix > -1) Valores.push(this.HostPage.Area.Historial[hix].Valor)
            }
            if (Arg.Tipo == "COL") {
                if (Arg.Ctl.Tipo == "MULTIFORM") {
                    var wval=""
                    var wtype=Arg.Ctl.Cols[Arg.ColIndex].Type
                    for (var k=0; k<Arg.Ctl.SelectedKeys.length; k++) {
                        var wkey=Arg.Ctl.SelectedKeys[k]
                        var Rec = Arg.Ctl.GetRowFromKey(wkey)
                        if (k > 0) wval += "["
                        if (Rec != null) {
                            wval += Rec.Fields[Arg.ColIndex].Val
                        }
                    }
                    /*
                    var Rec = Arg.Ctl.GetRowFromKey(Arg.Ctl.SelectedKeys[0])
                    var wval = Rec.Fields[Arg.ColIndex].Val
                    var wtype = Rec.Fields[Arg.ColIndex].Coldef.Type
                    */
                } else {
                    var wval = Arg.Ctl.GetVal(Arg.ColIndex)
                    var wtype = Arg.Ctl.Cols[Arg.ColIndex].Type
                }
                if (formula.Functionid != "*") {
                    Valores.push(ConvertToNative(wval, wtype))
                } else {
                    Valores.push(wval)
                }
            }
            if (Arg.Tipo == "VAR") {
                if (Arg.Var == "FUNC") Valores.push(this.HostPage.Func)
            }
            if (Arg.Tipo == "CONST")
                Valores.push(ConvertToNative(Arg.Const, Arg.Wtype))
        }
        if (arg1 != undefined && arg1 != "") {
            Valores.push(arg1)
        }
        if (arg2 != undefined && arg2 != "") {
            Valores.push(arg2)
        }
        if (arg3 != undefined && arg3 != "") {
            Valores.push(arg3)
        }
        Aorig = this.HostPage.Area
        if (formula.Functionid != "*") {
            var Aresult = ""
            wcmd = "var Aresult = " + formula.Functionid + "("
            for (var v = 0; v < Valores.length; v++) {
                if (v > 0) wcmd += ", "
                wcmd += "Valores[" + v + "]"
            }
            wcmd += ")"
            try { eval(wcmd) }
            catch (exp) {
                window.alert(GetMsg(1, "Erro na execução da fórmula (" + formula.Id + ") - " + exp))
                return
            }
            if (Aresult == undefined) Aresult = "";
            var w = Aresult
            if (Aresult.constructor.toString().indexOf("Array") == -1) {   //testar de é Array
                Aresult = new Array()
                Aresult.push(w)
            }
            var wresult = new Array()
            for (var i = 0; i < formula.Results.length; i++) {
                var Res = formula.Results[i]
                if (Res.Tipo == "HIST" || Res.Tipo == "VAR") {
                    wresult.push(Aresult[i]);
                }
                if (Res.Tipo == "COL") {
                    var wtype = "A"
                    var wdec = 0
                    if (Res.Ctl.Tipo == "MULTIFORM") {
                        //var Rec = Res.Ctl.PanelOnEdit.Record
                        var Rec = Res.Ctl.GetRowFromKey(Res.Ctl.SelectedKeys[0])
                        wtype = Rec.Fields[Res.ColIndex].Coldef.Type
                        wdec = Rec.Fields[Res.ColIndex].Coldef.Dec
                    } else {
                        wtype = Res.Ctl.Cols[Res.ColIndex].Type
                        wdec = Res.Ctl.Cols[Res.ColIndex].Dec
                    }
                    wresult.push(ConvertFromNative(Aresult[i], wtype, wdec));
                }
            }
        } else {
            for (var v = 0; v < Valores.length; v++) {
                wresult.push(Valores[v]);
            }
        }
        //if (wresult == undefined || wresult == null) wresult = ""
    }
    if (formula.Provider != "") {   //****** formula no servidor
        var iblk = new Interblk()
        iblk.APP = formula.Provider
        iblk.IDENT = formula.Id
        iblk.MOD = User.GetModDb(this.HostPage.Modulo)
        iblk.FUNC = "EXW"
        iblk.COND = ""
        var wval=""
        var wrec=new Array()
        for (var i = 0; i < formula.Args.length; i++) {
            wval=""
            var Arg = formula.Args[i]
            iblk.CMPS.push(Arg.Id)
            if (Arg.Tipo == "COL") {
                if (Arg.Ctl.Tipo == "MULTIFORM") {
                    var wval=""
                    for (var k=0; k<Arg.Ctl.SelectedKeys.length; k++) {
                        var wkey=Arg.Ctl.SelectedKeys[k]
                        var Rec = Arg.Ctl.GetRowFromKey(wkey)
                        if (k > 0) wval += "["
                        if (Rec != null) {
                            wval += Rec.Fields[Arg.ColIndex].Val
                        }
                    }
                    /*
                    var Rec = Arg.Ctl.GetRowFromKey(Arg.Ctl.SelectedKeys[0])
                    wval = Rec.Fields[Arg.ColIndex].Val
                    */
                } else {
                    wval = Arg.Ctl.GetVal(Arg.ColIndex)
                }
            }
            if (Arg.Tipo == "HIST") {
                var hix = GetHistorialIndex(this.HostPage.Area, Arg.HistGetId, Arg.HistOp)
                if (hix > -1) wval=this.HostPage.Area.Historial[hix].Valor
            }
            if (Arg.Tipo == "VAR") {
                if (Arg.Var == "FUNC") wval=this.HostPage.Func
            }
            if (Arg.Tipo == "CONST") wval=ConvertToNative(Arg.Const, Arg.Wtype)
            wrec.push(wval)
        }
        if (arg1 != undefined && arg1 != "") {
            if (arg1.constructor.toString().indexOf("Object()") > -1) {   //testar se é Objecto
                iblk.CMPS.push("JSONobj")
                wrec.push(arg1)
            } else {
                iblk.CMPS.push("arg1")
                wrec.push(arg1)
            }
        }
        if (arg2 != undefined && arg2 != "") {
            iblk.CMPS.push("arg2")
            wrec.push(arg2)
        }
        if (arg3 != undefined && arg3 != "") {
            iblk.CMPS.push("arg3")
            wrec.push(arg3)
        }
        iblk.DADOS.push(wrec)
        if (async == "ASYNC") {
            if (this.CommTimeout != undefined) {
                SendServer(this.HostPage, iblk, "SINGLE", this.CommTimeout);
            } else {
                SendServer(this.HostPage, iblk, "SINGLE");
            }
            return;
        }
        iblk = SendServerSync(this.HostPage, iblk)
        if (iblk.STAT != "OK") {
            this.HostPage.ShowWarning(iblk.MSG)
            return
        }
        wresult = iblk.DADOS[0]
    }
    this.ProcessResults(wresult);
}

Qrotina.prototype.ProcessResults=function(wresult) {
    RotStatus = "OK"
    RotMsg = ""
    RotMsgId = ""
    RotResult = ""
    var formula = this.Formula
    if (formula == null) return; //a formula é null quando por exemplo o qua foi executado foi um ClosePage
    if (wresult.length < formula.Results.length) {
        //window.alert("Erro na execução da rotina (" + formula.Id + ") - resultado nulo")
        return
    }
    RotResult = wresult[0]
    var Aw = wresult
    for (var i = 0; i < formula.Results.length; i++) {
        var Res = formula.Results[i]
        var valcmd=Aw[i];
        if (Res.Tipo == "HIST" || Res.Tipo == "MIX") {
            if (Res.HistId != "") {
                SetHistorialCmd(this.HostPage.Area, Res.Histid, Aw[i], Res.Histop)
            }
        }
        if (Res.Tipo == "COL" || Res.Tipo == "MIX") {
            if (Res.Ctl != "") {
                Res.Ctl.StoreVal(Res.ColIndex, Aw[i])
                var wcol = Res.Ctl.Cols[Res.ColIndex]
                if (Res.Ctl.Tipo == "MULTIFORM") {
                    //var Rec = Res.Ctl.PanelOnEdit.Record
                    var Rec = Res.Ctl.GetRowFromKey(Res.Ctl.SelectedKeys[0])
                    var Field = Rec.Fields[Res.ColIndex]
                    for (var c = 0; c < Field.ColCtls.length; c++) {
                        var wctl = Field.ColCtls[c]
                        //wctl.SetVal(Aw[i]);  FHC 5/2/2018  should set user format
                        wctl.SetVal(FormatCol(wcol, Aw[i], "user"));
                    }
                } else {
                    for (var c = 0; c < wcol.ColCtls.length; c++) {
                        var wctl = wcol.ColCtls[c]
                        //wctl.SetVal(Aw[i]);  FHC 5/2/2018  should set user format
                        wctl.SetVal(FormatCol(wcol, Aw[i], "user"));
                    }
                }
            }
        }
        if (Res.Tipo == "VAR" || Res.Tipo == "MIX") {
            if (Res.Var != "") {
                if (Res.Var == "ROTSTATUS") RotStatus = Aw[i]
                if (Res.Var == "ROTMSG") RotMsg = Aw[i]
                if (Res.Var == "ROTMSGID") RotMsgId = Aw[i]
                if (Res.Var == "ROTRESULT") RotResult = Aw[i]
            }
        }
    }
    for (var i = 0; i < formula.Events.length; i++) {
        if (formula.Events[i].Id == "AFTEREXECUTE") {
            var wact = formula.Events[i].Act
            for (var r = 0; r < Aw.length; r++) {
                var re = new RegExp("#" + (r + 1) + "#", "g")
                wact = wact.replace(re, Aw[r])
            }
            ExecCmd(this.HostPage.Area, wact)
        }
    }
    if (this.Callback != "") {
        try {eval(this.Callback)}
        catch(exp) {window.alert(GetMsg(1, "Erro na execução de comando javascript (" + this.Callback + ") - " + exp.message))}  
    }
}

Qrotina.prototype.Receive=function(iblk) {
    if (iblk.STAT != "OK") {
        this.HostPage.ShowWarning(iblk.MSG)
        return
    }
    wresult=iblk.DADOS[0];
    this.ProcessResults(wresult);
}

Qrotina.prototype.Destroy=function() {
	this.Formula=null
}

//***************************************************************** QVARVAL - define Varios Valores
function Qvarval(xnod, hostpage) {
	this.Tipo="VARVAL"
	this.Class="DATA"
	this.HostPage=hostpage
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Varval" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para a VARVAL(" + this.Id + ") Invalido"))
		return
	}
	this.Cols=new Array()
	this.Dados=new Array()
	this.Events=new Array()
	this.Status=""
	this.KeyIndex=0
	this.FrmCtl=""
	this.FrmCtlFld=""
	this.FrmColix=-1
	this.DbCtl=""
	this.DbCtlFld=""
	this.DbColix=-1
    this.Limiterctls=new Array()
    this.LimitsUsed=0
    this.LimitCond=""

	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			if (wcol.Key == "S") this.KeyIndex=this.Cols.length
			this.Cols.push(wcol)
			if (wcol.Limitctl != "") {
				var wctl=this.HostPage.GetCtl(wcol.Limitctl)
				if (wctl == null) {
					window.alert(GetMsg(1, "O VARVAL(" + this.Id + ") referencia um LIMITCTL(" + wcol.Limitctl + ") inexistente"))
				} 
				if (wctl.Tipo == "FORM") {
					this.FrmCtl=wctl
					this.FrmCtlFld=wcol.Limitfld
					this.FrmColix=this.Cols.length-1
                    this.Limiterctls.push(wctl.Id)
					wctl.Updatectls.push(this)
				}
				if (wctl.Tipo == "MULTIFORM") {
					this.DbCtl=wctl
					this.DbCtlFld=wcol.Limitfld
					this.DbColix=this.Cols.length-1
                    this.Limiterctls.push(wctl.Id)
				}				
			}
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	this.Func="GET"
	this.Cond=""
}

Qvarval.prototype.Activate=function(opt) {
	if (this.LimitsUsed == 2) this.SendRequest()
    if (this.FrmCtl.HostFunc == "VIS") {  //se o form estiver em modo visualização é preciso fazer impedir que se seleccione linhas no multigrid associado (DisableSelect)
        this.DbCtl.Grpctls[0].DisableSelect();
    }
}

Qvarval.prototype.Execute=function(act, opt) {
	var frmkval=this.FrmCtl.GetVal(this.FrmCtlFld)
	var ix=this.DbCtl.GetColIndex(this.DbCtlFld)
	this.DadosN=new Array()
    var wrec=""
	for (var i=0; i<this.DbCtl.Dados.length; i++) {
        wrec=this.DbCtl.Dados[i]
		var rowselected=false
		var rowkey=wrec.Fields[this.DbCtl.KeyIndex].Val
		for (var r=0; r<this.DbCtl.SelectedKeys.length; r++) {
			if (rowkey == this.DbCtl.SelectedKeys[r]) {
				rowselected=true
				break
			}	
		}
		if (rowselected) {
			var dbkval=rowkey
			var Arecold=""
			for (var r=0; r<this.Dados.length; r++) {
				Arecold=this.Dados[r]
				if (Arecold[this.DbColix] == dbkval) {
					break
				} else {
					Arecold=""
				}
			}
			var Arec=new Array()
			for (var c=0; c<this.Cols.length; c++) {
				if (c == this.FrmColix) {
					Arec.push(frmkval)
				} else {
					if (c == this.DbColix) {
						Arec.push(dbkval)
					} else {
						if (Arecold != "") {
							Arec.push(Arecold[c])	
						} else {
							Arec.push("")
						}
					}
				}
			}
			this.DadosN.push(Arec)
		}
	}
	this.Dados=this.DadosN
	this.Send()
}

Qvarval.prototype.SetLimit=function(limiterctl) {
    if (limiterctl == this.FrmCtl) {  //se for o form estabelece a condição de limite
        var wcol=this.Cols[this.FrmColix]
        this.LimitCond=AppendCond("", wcol.Id, wcol.Type, this.FrmCtl.GetVal(this.FrmCtlFld))
        this.LimitsUsed++
    } else {
        this.LimitsUsed++  //se for o MULTIFORM é só para saber que já está carregado
    }
    if (this.LimitsUsed >= 2) {
        this.LimitsUsed=2
        this.SendRequest()
    }
}

Qvarval.prototype.Send=function() {
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	iblk.FUNC="ELINSM"
    iblk.COND=this.LimitCond
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		iblk.CMPS.push(col.Id)
	}
    var wrec=new Array()
	for (var r=0; r<this.Dados.length; r++) {
		wrec=new Array()
		for (var i=0; i<this.Cols.length; i++) {
			wrec.push(this.Dados[r][i])
		}
        iblk.DADOS.push(wrec)
	}
	SendServer(this.HostPage, iblk, "ADD")
}

Qvarval.prototype.PopulateGrid=function() {
	var ix=this.DbCtl.GetColIndex(this.DbCtlFld)
    var dbrec=""
    var dbkey=""
    var vvkey=""
	for (var i=0; i<this.DbCtl.Dados.length; i++) {
        dbrec=this.DbCtl.Dados[i]
        dbkey=dbrec.Fields[ix].Val
		for (var r=0; r<this.Dados.length; r++) {
			vvkey=this.Dados[r][this.DbColix]
			if (dbkey == vvkey) {
				this.DbCtl.SelectedKeys.push(dbkey)
			}
		}
	}
	this.DbCtl.PopulateGrid()
}


Qvarval.prototype.Disable=function() {
}
Qvarval.prototype.Enable=function() {
}
Qvarval.prototype.Show=function() {
}
Qvarval.prototype.Hide=function() {
}

Qvarval.prototype.Destroy=function() {
	this.Cols=null
	this.Dados=null
	this.Events=null
}


Qvarval.prototype.SendRequest=function() {
	if (this.Provider == "") return
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.IDENT=this.Id
	iblk.FUNC=this.Func
	iblk.COND=this.LimitCond
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
		var col=this.Cols[i]
		if (col.Send != "N") {
			iblk.CMPS.push(col.Id)
			wrec.push("")
		}
	}
	SendServer(this.HostPage, iblk, "SINGLE")
}

Qvarval.prototype.Receive=function(iblk, gstatus, last) {
    if (this.Func != "GET") {
        if (iblk.STAT != "OK") this.HostPage.ShowWarning(iblk.MSG)
        return
    }
	this.Dados=new Array()
	var Adad=iblk.DADOS
	for (var r=0; r<Adad.length; r++) {
		var Arec=new Array()
		var Aw=Adad[r]
		var j=0
		for (var i=0; i<this.Cols.length; i++) {
			if (this.Cols[i].Send == "N") {
				Arec.push("")
			} else {
				if (j < Aw.length) {
					Arec.push(Aw[j])
					j++
				} else {
					Arec.push("")
				}
			}
		}
		this.Dados.push(Arec)
	}
	if (iblk.STAT == "OK" || iblk.STAT == "OK+" || iblk.STAT == "W" || iblk.STAT == "OK+W") {
		this.Status="OK"
		this.PopulateGrid()
	} else {
		this.Status="ERR"
	}
	if (iblk.STAT == "W" || iblk.STAT == "OK+W") this.HostPage.ShowWarning(iblk.MSG)
}


//***************************************************************** QFLASH - define Flash
function Qflash(xnod, hostpage, hostpanel) {
	this.Tipo="FLASH"
	this.Class="DISPLAY"
	this.HostPage=hostpage
	this.HostPanel=hostpanel
	this.HostDataPanel=FindDataPanel(this)
	this.Id=GetAtt(xnod, "ID", "")
	if (this.Id == "") {
		this.Id="Flash" + this.HostPage.CtlCount
		this.HostPage.CtlCount ++
	}
	if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
	this.Hid=hostpanel.Hid + "." + this.Id
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	if (this.Provider == "") {
		window.alert(GetMsg(1, "Provider para o FLASH(" + this.Id + ") Invalido"))
		return
	}
    this.Actls=new Array();
	this.Movie=GetAtt(xnod, "MOVIE", "")
	this.Trace=GetAtt(xnod, "TRACE", "N")
	this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
    this.Bgcolor=GetAtt(xnod, "BGCOLOR", "FFFFFF")
	this.FlashTipo="AS2"
	this.Cols=new Array()
	this.Dados=new Array()
	this.Events=new Array()
	this.Botoes=new Array()
	var xn=xnod.firstChild
	while (xn!=undefined) {
		if (xn.nodeName == "COL") {
			var wcol=new Qcol(xn)
			this.Cols.push(wcol)
			this.Dados.push("")
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
	var wdiv = document.createElement("DIV")
    wdiv.style.position="absolute"
    this.Hobj=wdiv
    try {this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)}
    catch(expr) {this.Locsize=new QlocSizeN(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel, this)}
	this.Locsize.Resize(wdiv)
	wdiv.style.zIndex=1
	wdiv.onmouseover=EvtMouseOver
	hostpanel.PanelObj.appendChild(wdiv)
	//this.MovieId=this.HostPage.Area.Id + this.HostPage.Id + this.Id
	this.MovHid=this.Hid + "._.SWF"
	this.MovieId=this.Hid.replace(/\./g, "9y9")

	var whtml="<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='" + window.location.protocol + "//fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0' "
	whtml += "id='" + this.MovHid + "' width='100%' height='100%' align='middle'>"
	whtml += "<param name='allowScriptAccess' value='sameDomain' />"
	whtml += "<param name='movie' value='" + this.Movie + ".swf' />"
	whtml += "<param name='menu' value='false' />"
	whtml += "<param name='quality' value='high' />"
	whtml += "<param name='wmode' value='opaque' />"
	whtml += "<param name='bgcolor' value='#" + this.Bgcolor + "' />"
	//retirei wmode='transparent' do embed.  Dá problemas nos textfield do flash em input com os caracteres portugueses
	whtml += "<embed src='" + this.Movie + ".swf' menu='false' quality='high' bgcolor='#" + this.Bgcolor + "' width='100%' height='100%' wmode='opaque' swLiveConnect=true id='" + this.MovieId + "' name='" + this.MovieId + "' align='middle' allowScriptAccess='sameDomain' type='application/x-shockwave-flash' pluginspage='" + window.location.protocol + "//www.macromedia.com/go/getflashplayer' />"
	whtml += "</object>"
	this.Hcode=whtml
    this.Retries=0
}


Qflash.prototype.Activate=function(opt) {
	if (opt = "INIT") {
		if (this.Autostart != "S") return
	}
	this.Hobj.innerHTML = this.Hcode
	if (BrowserIE) {
		this.Movieobj=document.getElementById(this.MovHid)
		eval("F" + this.MovieId + " = function(cmd, args) {; FlashEvent(\"" + this.Hid + "\", cmd, args); }")
		this.Movieobj.attachEvent('FSCommand',eval("F" + this.MovieId))
	} else {
		this.Movieobj=eval("window.document." + this.MovieId)
		eval(this.MovieId + "_DoFSCommand = function(cmd, args) {; FlashEvent(\"" + this.Hid + "\", cmd, args); }")
	}
	ExecCmdDelayed(300, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",TestAs3")
	this.Movieobj.onmouseover=EvtMouseOver
	this.Movieobj.onmouseout=EvtMouseOut
}

Qflash.prototype.Resize=function() {
	this.Locsize.Resize(this.Hobj)
}

Qflash.prototype.SendFlashCmd=function(cmd, args) {
	if (cmd == "LoadLangFile" || cmd == "LoadLangXml") args += ";" + User.Language
	if (this.FlashTipo == "AS3") {
		this.SendFlash3Cmd(cmd, args)
		return	
	}
	this.Movieobj.SetVariable("ExecFunction", cmd)
	this.Movieobj.SetVariable("ExecParam", args)
	this.Movieobj.Play()
}

Qflash.prototype.SendFlash3Cmd=function(cmd, args) {
	try {
		var res=this.Movieobj.FlashCommand(cmd, args)
	}
	catch(exp) {
        this.Retries++
        if (this.Retries < 3) ExecCmdDelayed(100, this.HostPage.Area, "ExecuteInternal(" + this.Id + ",TestAs3")
		return
	}
	if (cmd == "SetFlashId") {
		if (res == "OK") {
			this.FlashTipo="AS3"
		}
		return
	}
}

Qflash.prototype.Execute=function(act, cmd, args) {
	if (act == "TestAs3") {
        this.SendFlash3Cmd("SetFlashId", this.Hid)
        return
    }
	if (act == "") {
        this.ProcessEvents("Exec","","")
        return
    }
	if (act == "Cancel") {
        this.ProcessEvents("Cancel","","")
        return
    }
    if (cmd == undefined) cmd="";
    if (args == undefined) args="";
    this.ProcessEvents(act, cmd, args)
}

/* Checks if the second argument is equal to the first assuming '*' indicates zero or more occurences of any character.
	For example TestEqualArgs("NOK*", "NOK Erro") returns true
*/
Qflash.prototype.TestEqualArgs=function(xmlArg, arg)
{
    if (xmlArg == "*")
        return true;

    var i = xmlArg.indexOf("*");
    if (i > 0) {
        if (xmlArg.substr(0, i) == arg.substr(0, i))
            return true;
    }
	//Simple case (no '*')
    else if (xmlArg == arg)
        return true

    return false;
}


Qflash.prototype.ProcessEvents=function(tipo, cmd, args) {
	if (this.Trace == "S") window.alert("----> Evento (" + this.Id + ") Origem: " + tipo + "   Cmd=" + cmd + " Parm=" + args)
    if (this.Trace == "P") window.prompt("----> Evento (" + this.Id + ") Origem: " + tipo + "   Cmd=" + cmd + " Parm=", args)
	for (var i=0; i<this.Events.length; i++) {
		var evt=this.Events[i]
		if (evt.Id == tipo) {
			var Aw=evt.Valor.split("[")
			var ecmd=Aw[0]
			var earg=Aw[1]
			if (ecmd == "*" || ecmd == cmd) {
				var equal = false;
			    if (earg.substr(0, 1) == "!") {
			        equal = this.TestEqualArgs(earg.substr(1), args) == false;
			    }
			    else {
			        equal = this.TestEqualArgs(earg, args);
			    }
				if (equal) {
					if (evt.Act.indexOf("SendFlashCmd") == 0 || evt.Act.indexOf("SendServerCmd") == 0 || evt.Act == "ShowFlashMsg(") {
						var wact=SubstVarsExt(this.HostPage.Area, evt.Act)
						var Aw=wact.split("(")
						var actcmd=Aw[0]
						Aw[1] += ","
						var Aw=Aw[1].split(",")
						var fcmd=Aw[0]
						var farg=Aw[1]
						if (fcmd == "") fcmd=cmd
						if (farg == "") farg=args
						if (this.Trace == "S") window.alert("<---- Comando (" + this.Id + ") Tipo: " + actcmd + "   Cmd=" + fcmd + " Parm=" + farg)
                        if (this.Trace == "P") window.prompt("<---- Comando (" + this.Id + ") Tipo: " + actcmd + "   Cmd=" + fcmd + " Parm=", farg)
						if (actcmd == "SendFlashCmd") this.SendFlashCmd(fcmd, farg)
						if (actcmd == "SendServerCmd") {
							for (var f=0; f<this.Cols.length; f++) {
								if (this.Cols[f].Id == "grafcmd") this.Dados[f]=fcmd
								if (this.Cols[f].Id == "grafparms") this.Dados[f]=farg
							}
							this.Send(this)
						}
						if (actcmd == "ShowFlashMsg") window.alert(farg)
					} else {
						var wact=evt.Act
						var Aparms=args.split(";")
						var j=wact.indexOf("#*")
						if (j != -1) wact=wact.substr(0, j) + earg + wact.substr(j+2)
						for (var p=0; p<Aparms.length; p++) {
						 	j=wact.indexOf("#" + (p+1))
						 	if (j != -1) wact=wact.substr(0, j) + Aparms[p] + wact.substr(j+2)
						}
						if (this.Trace == "S") window.alert("<---- Comando (" + this.Id + ") Tipo: Qweb   Cmd=" + wact)
                        if (this.Trace == "P") window.alert("<---- Comando (" + this.Id + ") Tipo: Qweb   Cmd=", wact)
						this.HostPage.CallerCtl = this
						ExecCmdDelayed(30, this.HostPage.Area, wact)
					}
				}
			}
		}
	}
}

Qflash.prototype.GetVal=function(ix) {
	if (ix >=0 && ix < this.Cols.length) {
		return this.Dados[ix]
	}
	for (var i=0; i<this.Cols.length; i++) {
		if (this.Cols[i].Id == ix) {
			return this.Dados[i]
		}
	}
	return ""	
}


//Qflash.prototype.Disable=function() {alert("flash disable")}
//Qflash.prototype.Enable=function() {}

Qflash.prototype.Disable=function(tipo) {  //para fazer disable do objecto Flash cria-se uma div transparente por cima para interceptar os eventos de rato
    GenericDisplayCtl_Disable.call(this, tipo)
    if (this.Disabled == false) return;
    this.Hmask=document.createElement("DIV")
    this.Hobj.appendChild(this.Hmask)
    this.Hmask.style.borderWidth="0px"
    this.Hmask.style.backgroundColor="transparent"
    this.Hmask.style.position="absolute"
    this.Hmask.style.top="0px"
    this.Hmask.style.left="0px"
    this.Hmask.style.width="100%"
    this.Hmask.style.height="100%"
    this.Hmask.style.zIndex=200
}

Qflash.prototype.Enable=function(tipo) {  //para fazer o Enable basta remover a div transparente que está por cima do objecto Flash
    GenericDisplayCtl_Enable.call(this, tipo)
    if (this.Disabled == true) return;
    if (this.Hmask != null && this.Hmask != undefined) {
        this.Hobj.removeChild(this.Hmask);
        this.Hmask=null;
    }
}

Qflash.prototype.SetState=function() {}

Qflash.prototype.Show=function() {}
Qflash.prototype.Hide=function() {}

Qflash.prototype.OnMouseOver=function() {
    try {GenericDisplayCtl_OnMouseOver.call(this);}
    catch(expr) {
        if (this.Disabled == true) return
        this.HostPanel.OnMouseOver()
    }
}
Qflash.prototype.OnMouseOut=function() {
    try {GenericDisplayCtl_OnMouseOut.call(this)}
    catch(expr) {
        if (this.Disabled == true) return
        this.HostPanel.OnMouseOut()
    }
}

Qflash.prototype.Destroy=function() {
	this.Cols=null
	this.Dados=null
	this.Events=null
	this.Botoes=null
	if (BrowserIE) {
		if (BrowserIE || BrowserOP) this.Movieobj.detachEvent('FSCommand',eval("F" + this.MovieId))
		this.Movieobj.removeNode(true)
		this.Hobj.removeNode(true)	
	} else {
		var obj=document.getElementById(this.MovieId)
		obj.parentNode.removeChild(obj)
	}
}

Qflash.prototype.Send=function() {
	if (this.Provider == "") return
	var iblk=new Interblk()
	iblk.APP=this.Provider
	iblk.IDENT=this.Id
	iblk.MOD=User.GetModDb(this.HostPage.Modulo)
	iblk.FUNC="EXW"
    var wval=""
    var wrec=new Array()
	for (var i=0; i<this.Cols.length; i++) {
        wval=this.Dados[i]
		var col=this.Cols[i]
		if (col.HistGetId != "") {
			var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
			if (hix > -1) wval=this.HostPage.Area.Historial[hix].Valor
		}
        if (col.Id == "grafid") wval=this.Movie
		iblk.CMPS.push(col.Id)
		wrec.push(wval)
	}
    iblk.DADOS.push(wrec)
	SendServer(this.HostPage, iblk, "SINGLE")
}
	
Qflash.prototype.Receive=function(iblk, gstatus, last) {
	var fcmd=""
	var farg=""
	var Adad=iblk.DADOS[0]
	for (var i=0; i<this.Cols.length; i++) {
		this.Cols[i].Status=""
		if (i < Adad.length) {
			this.Dados[i]=Adad[i]
			//if (this.Cols[i].Type == "X") this.Dados[i]=Xdecode(this.Dados[i])
			if (this.Cols[i].Id == "grafcmd") fcmd=this.Dados[i]
			if (this.Cols[i].Id == "grafparms") farg=this.Dados[i]
		} else {
			this.Dados[i]=""
		}
	}
	if (iblk.STAT == "OK" || iblk.STAT == "W") {
		this.Status="OK"
		this.ProcessEvents("Server", fcmd, farg)
		if (iblk.STAT == "W") this.HostPage.ShowWarning(iblk.MSG)
	} else {
		this.Status="ERR"
		this.HostPage.ShowWarning(iblk.MSG)
	}
}

Qflash.prototype.GetColIndex=function(colid) {
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == colid) {
            return i;
        }
    }
    return null;
}

Qflash.prototype.GetCol=function(colid) {
    var ix=this.GetColIndex(colid);
    if (ix != null) return this.Cols[ix];
}

Qflash.prototype.AddFieldCtl=function(colid, ctl) {
    //just for compatibility with other data controls
}

function FlashEvent(id, cmd, args) {
	var ctl=GetCtlByHid(id)
	ctl.ProcessEvents("Flash", cmd, args)
}


//***************************************************************** QCHART - define Interface gráfico
function Qchart(xnod, hostpage, hostpanel) {
    this.Tipo="CHART"
    this.Class="DISPLAY"
    this.HostPage=hostpage
    this.HostPanel=hostpanel
    this.HostDataPanel=FindDataPanel(this)
    this.Id=GetAtt(xnod, "ID", "")
    if (this.Id == "") {
        this.Id="Chart" + this.HostPage.CtlCount
        this.HostPage.CtlCount ++
    }
    if (this.HostDataPanel != null) this.Id += "_R" + this.HostDataPanel.LineNumber
    this.Hid=hostpanel.Hid + "." + this.Id
    this.Provider=GetAtt(xnod, "PROVIDER", "")
    if (this.Provider == "") {
        window.alert(GetMsg(1, "Provider para o CHART(" + this.Id + ") Invalido"))
        return
    }
    this.ClassId=GetAtt(xnod, "CLASS", "")
    this.Trace=GetAtt(xnod, "TRACE", "N")
    this.Autostart=GetAtt(xnod, "AUTOSTART", "S")
    this.Cols=new Array()
    this.Dados=new Array()
    this.Events=new Array()
    this.Botoes=new Array()
    var xn=xnod.firstChild
    while (xn!=undefined) {
        if (xn.nodeName == "COL") {
            var wcol=new Qcol(xn)
            this.Cols.push(wcol)
            this.Dados.push("")
        }
        if (xn.nodeName == "EVENT") {
            var wevent=new Qevent(xn)
            this.Events.push(wevent)
        }
        xn=xn.nextSibling
    }
    var wdiv = document.createElement("DIV")
    wdiv.id=this.Hid
    wdiv.style.position="absolute"
    this.Hobj=wdiv
    try {this.Locsize=new QlocSize(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel)}
    catch(expr) {this.Locsize=new QlocSizeN(GetAtt(xnod, "LOCATION", "0,0"), GetAtt(xnod, "SIZE", "0,0"), hostpanel, this)}
    this.Locsize.Resize(wdiv)
    wdiv.style.zIndex=1
    wdiv.onmouseover=EvtMouseOver
    hostpanel.PanelObj.appendChild(wdiv)
    var ChartPath=GetAtt(xnod, "PATH", "Charts/" + this.ClassId + "/");
    try {eval("this.ChartObj = new " + this.ClassId + "(this.Hobj, App.Hobjp, null, ChartPath)")}  // criar objecto da classe indicada passando como argumento a div onde deve ser criado o grafico + a div para impressão + a path onde estão os compenentes
    catch(expr) {window.alert(GetMsg(1, "CLASS para o CHART(" + this.Id + ") Invalido ou o respectivo script não está acessível"))}
}


Qchart.prototype.Activate=function(opt) {
    if (opt = "INIT") {
        if (this.Autostart != "S") return
    }
    try {this.ChartObj.Activate();}
    catch(expr) {window.alert(GetMsg(1, "A função Activate() para o CHART(" + this.Id + ") não foi completada com sucesso"))}
}

Qchart.prototype.Resize=function() {
    this.Locsize.Resize(this.Hobj)
    try {this.ChartObj.Resize();}
    catch(expr) {}
}

Qchart.prototype.SendChartCmd=function(cmd, args) {
    if (cmd == "LoadLangFile" || cmd == "LoadLangXml") args += ";" + User.Language
    try {this.ChartObj.ReceiveCmd(cmd, args);}
    catch(expr) {window.alert(GetMsg(1, "A função ReceiveCmd() para o CHART(" + this.Id + ") não foi completada com sucesso"));}
}

Qchart.prototype.Execute=function(act, cmd, args) {
    if (act == "") {
        this.ProcessEvents("Exec","","")
        return
    }
    if (act == "Cancel") {
        this.ProcessEvents("Cancel","","")
        return
    }
    if (cmd == undefined) cmd="";
    if (args == undefined) args="";
    this.ProcessEvents(act, cmd, args)
}

Qchart.prototype.ProcessEvents=function(tipo, cmd, args) {
    if (this.Trace == "S") window.alert("----> Evento (" + this.Id + ") Origem: " + tipo + "   Cmd=" + cmd + " Parm=" + args)
    if (this.Trace == "P") window.prompt("----> Evento (" + this.Id + ") Origem: " + tipo + "   Cmd=" + cmd + " Parm=", args)
    for (var i=0; i<this.Events.length; i++) {
        var evt=this.Events[i]
        if (evt.Id == tipo) {
            var Aw=evt.Valor.split("[")
            var ecmd=Aw[0]
            var earg=Aw[1]
            if (ecmd == "*" || ecmd == cmd) {
                var iast=earg.indexOf("*")
                if (iast > 0) {
                    if (args.substr(0, iast) == earg.substr(0, iast)) iast=-999 
                }
                if (earg == "*" || earg == args || (earg.substr(0,1) == "!" && earg.substr(1) != args) || iast==-999) {
                    if (evt.Act.indexOf("SendChartCmd") == 0 || evt.Act.indexOf("SendServerCmd") == 0 || evt.Act == "ShowChartMsg(") {
                        var wact=SubstVarsExt(this.HostPage.Area, evt.Act)
                        var Aw=wact.split("(")
                        var actcmd=Aw[0]
                        Aw[1] += ","
                        var Aw=Aw[1].split(",")
                        var fcmd=Aw[0]
                        var farg=Aw[1]
                        if (fcmd == "") fcmd=cmd
                        if (farg == "") farg=args
                        if (this.Trace == "S") window.alert("<---- Comando (" + this.Id + ") Tipo: " + actcmd + "   Cmd=" + fcmd + " Parm=" + farg)
                        if (this.Trace == "P") window.prompt("<---- Comando (" + this.Id + ") Tipo: " + actcmd + "   Cmd=" + fcmd + " Parm=", farg)
                        if (actcmd == "SendChartCmd") this.SendChartCmd(fcmd, farg)
                        if (actcmd == "SendServerCmd") {
                            for (var f=0; f<this.Cols.length; f++) {
                                if (this.Cols[f].Id == "grafcmd") this.Dados[f]=fcmd
                                if (this.Cols[f].Id == "grafparms") this.Dados[f]=farg
                            }
                            this.Send(this)
                        }
                        if (actcmd == "ShowChartMsg") window.alert(farg)
                    } else {
                        var wact=evt.Act
                        var Aparms=args.split(";")
                        var j=wact.indexOf("#*")
                        if (j != -1) wact=wact.substr(0, j) + earg + wact.substr(j+2)
                        for (var p=0; p<Aparms.length; p++) {
                            j=wact.indexOf("#" + (p+1))
                            if (j != -1) wact=wact.substr(0, j) + Aparms[p] + wact.substr(j+2)
                        }
                        if (this.Trace == "S") window.alert("<---- Comando (" + this.Id + ") Tipo: Qweb   Cmd=" + wact)
                        if (this.Trace == "P") window.alert("<---- Comando (" + this.Id + ") Tipo: Qweb   Cmd=", wact)
                        this.HostPage.CallerCtl = this
                        ExecCmdDelayed(30, this.HostPage.Area, wact)
                    }
                }
            }
        }
    }
}

Qchart.prototype.GetVal=function(ix) {
    if (ix >=0 && ix < this.Cols.length) {
        return this.Dados[ix]
    }
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == ix) {
            return this.Dados[i]
        }
    }
    return ""   
}


Qchart.prototype.Disable=function() {}
Qchart.prototype.Enable=function() {}
Qchart.prototype.Show=function() {}
Qchart.prototype.Hide=function() {}

Qchart.prototype.OnMouseOver=function() {
    try {GenericDisplayCtl_OnMouseOver.call(this);}
    catch(expr) {
        if (this.Disabled == true) return
        this.HostPanel.OnMouseOver()
    }
}
Qchart.prototype.OnMouseOut=function() {
    try {GenericDisplayCtl_OnMouseOut.call(this)}
    catch(expr) {
        if (this.Disabled == true) return
        this.HostPanel.OnMouseOut()
    }
}

Qchart.prototype.Destroy=function() {
    this.Cols=null
    this.Dados=null
    this.Events=null
    this.Botoes=null
    try {this.ChartObj.Destroy();}
    catch(expr) {}
}

Qchart.prototype.Send=function() {
    if (this.Provider == "") return
    var iblk=new Interblk()
    iblk.APP=this.Provider
    iblk.IDENT=this.Id
    iblk.MOD=User.GetModDb(this.HostPage.Modulo)
    iblk.FUNC="EXW"
    var wval=""
    var wrec=new Array()
    for (var i=0; i<this.Cols.length; i++) {
        wval=this.Dados[i]
        var col=this.Cols[i]
        if (col.HistGetId != "") {
            var hix=GetHistorialIndex(this.HostPage.Area, col.HistGetId, col.HistOp)
            if (hix > -1) wval=this.HostPage.Area.Historial[hix].Valor
        }
        if (col.Id == "grafid") wval=this.ClassId
        iblk.CMPS.push(col.Id)
        wrec.push(wval)
    }
    iblk.DADOS.push(wrec)
    SendServer(this.HostPage, iblk, "SINGLE")
}
    
Qchart.prototype.Receive=function(iblk, gstatus, last) {
    var fcmd=""
    var farg=""
    var Adad=iblk.DADOS[0]
    for (var i=0; i<this.Cols.length; i++) {
        this.Cols[i].Status=""
        if (i < Adad.length) {
            this.Dados[i]=Adad[i]
            //if (this.Cols[i].Type == "X") this.Dados[i]=Xdecode(this.Dados[i])
            if (this.Cols[i].Id == "grafcmd") fcmd=this.Dados[i]
            if (this.Cols[i].Id == "grafparms") farg=this.Dados[i]
        } else {
            this.Dados[i]=""
        }
    }
    if (iblk.STAT == "OK" || iblk.STAT == "W") {
        this.Status="OK"
        this.ProcessEvents("Server", fcmd, farg)
        if (iblk.STAT == "W") this.HostPage.ShowWarning(iblk.MSG)
    } else {
        this.Status="ERR"
        this.HostPage.ShowWarning(iblk.MSG)
    }
}

Qchart.prototype.GetColIndex=function(colid) {
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == colid) {
            return i;
        }
    }
    return null;
}

Qchart.prototype.GetCol=function(colid) {
    var ix=this.GetColIndex(colid);
    if (ix != null) return this.Cols[ix];
}

Qchart.prototype.AddFieldCtl=function(colid, ctl) {
    //just for compatibility with other data controls
}

function ReceiveChartEvent(id, cmd, args) {
    var ctl=GetCtlByHid(id)
    ctl.ProcessEvents("Chart", cmd, args)
}


//***************************************************************** QSEARCH - define controlador para pesquisas de texto
function Qsearch(xnod, hostpage) {
    this.Tipo="SEARCH";
    this.Class="DATA";
    this.HostPage=hostpage;
    this.Id=GetAtt(xnod, "ID", "");
    if (this.Id == "") {
        this.Id="Search" + this.HostPage.CtlCount;
        this.HostPage.CtlCount ++;
    }
    this.Cols=new Array();
    this.Dados=new Array();
    this.Events=new Array();
    this.Botoes=new Array();
    this.Limiterctls=new Array();
    this.TabStrip=GetAtt(xnod, "TABSTRIP", "");
    this.TabStripCtl=null;
    this.ResultsPanel=GetAtt(xnod, "RESULTSPANEL", "");
    this.ResultsPanelCtl=null;
    this.Groups=new Array();
    this.Cols.push(new Qcol(null, "$textsearch", "A", 255))  //coluna para conter a expressão a pesquisar
    this.Cols.push(new Qcol(null, "$tabcheck1", "N", 1))  //colunas para conter as checkboxes das Tabs que forem necessárias
    this.Cols.push(new Qcol(null, "$tabcheck2", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck3", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck4", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck5", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck6", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck7", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck8", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck9", "N", 1))
    this.Cols.push(new Qcol(null, "$tabcheck10", "N", 1))
    var xn=xnod.firstChild;
    while (xn!=undefined) {
        if (xn.nodeName == "GROUP") {
            var wgroup=new QsearchGroup(xn);
            this.Groups.push(wgroup);
        }
        if (xn.nodeName == "EVENT") {
            var wevent=new Qevent(xn);
            this.Events.push(wevent);
        }
        xn=xn.nextSibling;
    }
    this.InUse=false;  //flag para poder manipular as Tabs sem provocar a submissão da pesquisa. 
    this.TabSelected=-1;
}

Qsearch.prototype.Activate=function(opt) {
    if (this.ResultsPanel != "") this.ResultsPanelCtl=this.HostPage.GetCtl(this.ResultsPanel);
    if (this.TabStrip != "") this.TabStripCtl=this.HostPage.GetCtl(this.TabStrip);
    for (var g=0; g<this.Groups.length; g++) {
        var wgroup=this.Groups[g];
        if (wgroup.TabId != "") wgroup.TabCtl=this.HostPage.GetCtl(wgroup.TabId);
        this.StoreVal(g+1, "1", null, "SHOW");  //por todas a checkboxes seleccionadas
    }
}

Qsearch.prototype.Execute = function(act, parm1, parm2) {
    if (act == "DoSearch") {
        this.DoSearch();
        return;
    }
    if (act == "PrepFilter") {
        this.PrepFilter(parm1);
        return;
    }
    if (act == "TabChanged") {
        if (this.InUse == false) this.DoSearch();
        return;
    }
    if (act == "GetDocument") {
        this.GetDocument(parm1, parm2);
        return;
    }
}

Qsearch.prototype.DoSearch=function() {
    var textsearch=this.GetVal("$textsearch");
    if (textsearch == "") {
        var tfield=this.Cols[0].ColCtls[0];
        window.alert(GetMsg(17, tfield.Tip));
        return;
    }
    if (this.ResultsPanelCtl != null) this.ResultsPanelCtl.Show();
    this.InUse=true;  //ao manipular as Tabs não se pretende que o evento TabChanged desencadeie a submissão do pedido ao servidor
    for (var g=0; g<this.Groups.length; g++) {  //activar ou desctivar as Tabs correspondentes às Checkboxes
        var wgroup=this.Groups[g];
        var xtab=this.GetVal("$tabcheck" + (g+1));
        if (wgroup.TabCtl != "") tabCtl=this.HostPage.GetCtl(this.TabStrip);
        if (wgroup.TabCtl != null) {
            if (xtab == 0) {
                wgroup.TabCtl.Hide();
            } else {
                wgroup.TabCtl.Show();
            }
        }
    }
    this.TabSelected=this.TabStripCtl.GetVal();
    this.InUse=false;
    var selectedgroup=this.Groups[this.TabSelected];
    var wcond="$SRHVAL$;=;'" + textsearch + "'";
    //construir as condições com o que está seleccionado nos filtros
    for (var f=0; f<selectedgroup.FilterId.length; f++) {
        var wfilt=this.DoFilter(selectedgroup.DataCtlId, selectedgroup.FilterType[f], selectedgroup.FilterId[f]);
        if (wfilt == "ERRO") return;
        if (wfilt != "") wcond += "|" + wfilt;
    }
    var ctlobj=this.HostPage.GetCtl(selectedgroup.DataCtlId);
    if (ctlobj == null) {
        window.alert(GetMsg(1, "Controlo de dados para o GROUP do SEARCH - (" + selectedgroup.DataCtlId + ") inexistente ou inválido."))
        return;
    }
    ctlobj.Execute("SetCond", wcond, "NoAuto");
    ctlobj.Execute("EXW");  //o pedido ao servidor vai com EXW
}

Qsearch.prototype.DoFilter=function(datactlid, filtertype, filterid) {  //obter a string com a parte da condição de cada filtro
    var ctlid=datactlid + "_" + filterid.replace(/\./g, "");
    var ctlobj=this.HostPage.GetCtl(ctlid);
    if (ctlobj == null) {
        window.alert(GetMsg(1, "Controlo de dados para o filtro do SEARCH - (" + ctlid + ") inexistente ou inválido."))
        return "ERRO";
    }
    var wcond="";
    if (filtertype == "LIST") {  //filtros do tipo lista de opções
        var wval=ctlobj.GetVal("index", "PV");
        if (wval != "") {
            var Aval=wval.split(";");
            for (var v=0; v<Aval.length; v++) {
                if (wcond != "") wcond += "|";
                wcond += filterid + ";=;'" + Aval[v] + "'";
            }
        }
    }
    if (filtertype == "DATE") {  //filtros de intevalo de datas
        var colix=ctlobj.GetColIndex("valuefrom");
        var wval=ctlobj.GetVal(colix);
        var wdesc=ctlobj.Cols[colix].Tit;
        var msg=api.ValidaValor("D", wval, "N", wdesc);
        if (msg != "") {
            alert(msg);
            return "ERRO";
        }
        if (wval != "") wcond=filterid + ";>=;#" + wval + "#";
        var colix=ctlobj.GetColIndex("valueto");
        var wval=ctlobj.GetVal(colix);
        var wdesc=ctlobj.Cols[colix].Tit;
        var msg=api.ValidaValor("D", wval, "N", wdesc);
        if (msg != "") {
            alert(msg);
            return "ERRO";
        }
        if (wval != "") {
            if (wcond != "") wcond += "|";
            wcond += filterid + ";<=;#" + wval + "#";
        }
    }
    return wcond;
}

Qsearch.prototype.PrepFilter=function(datactlid) {  //coloca pré-seleccionadas as linhas do multiform que têm "checked" no campo checked
    var ctlobj=this.HostPage.GetCtl(datactlid);
    if (ctlobj == null) {
        window.alert(GetMsg(1, "Controlo de dados para a função PrepFilter do SEARCH - (" + datactlid + ") inexistente ou inválido."))
        return "ERRO";
    }
    var selectedkeys=new Array();
    for (var i = 0; i <ctlobj.Dados.length; i++) {
        var Rec=ctlobj.Dados[i];
        var checked=Rec.Field("checked").Val;
        if (checked == "checked") selectedkeys.push(Rec.Key);
    }
    ctlobj.SelectedKeys=selectedkeys;
    for (var i=0; i<ctlobj.Grpctls.length; i++) {
        wctl.Grpctls[i].RefreshSelected();  
    }
}

Qsearch.prototype.GetColIndex=function(colid) {
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == colid) {
            return i;
        }
    }
    return null;
}

Qsearch.prototype.GetVal=function(ix) {
    if (ix >=0 && ix < this.Cols.length) {
        return this.Dados[ix];
    }
    for (var i=0; i<this.Cols.length; i++) {
        if (this.Cols[i].Id == ix) {
            return this.Dados[i];
        }
    }
    return "";
}

Qsearch.prototype.StoreVal = function(fld, valor, ctl, opt) {
    if (fld >= 0 && fld < this.Cols.length) {
        var ix = fld;
    } else {
        var ix = this.GetColIndex(fld);
        if (ix == null) return;
    }
    if (valor == this.Dados[ix]) return;
    this.Dados[ix] = valor;
    var wcol = this.Cols[ix];
    wcol.Status = "M";
    if (opt == "SHOW") {
        for (var c = 0; c < wcol.ColCtls.length; c++) {
            var wctl = wcol.ColCtls[c];
            wctl.SetVal(valor);
        }
    }
}

Qsearch.prototype.GetCol=function(colid) {
    var ix=this.GetColIndex(colid);
    if (ix != null) return this.Cols[ix];
}

Qsearch.prototype.AddFieldCtl=function(colid, ctl) {
    var ix=this.GetColIndex(colid)
    if (ix == null) return
    for (var i=0; i<this.Cols[ix].ColCtls.length; i++) {
        if (this.Cols[ix].ColCtls[i] == ctl) return
    }
    this.Cols[ix].ColCtls.push(ctl)
}

Qsearch.prototype.GetDocument=function(keyvers) {  //fazer pedido de ticket ao servidor para poder abrir o documento
    //Atenção - este pedido ao servidor vai com a logica do fcontrol e deve ser alterado quando este controlo também o for.
    var iblk=new Interblk();
    iblk.APP="";
    iblk.IDENT=this.Id;
    iblk.MOD=User.GetModDb(this.HostPage.Modulo);
    iblk.FUNC="FCT";
    iblk.COND = "";
    iblk.FICH=keyvers;
    iblk.MSG="Abrir";
    var wrec=new Array();
    wrec.push("");
    iblk.DADOS.push(wrec);
    var oblk=SendServerSync(this.HostPage, iblk);
    if (oblk.STAT == "OK") {
        var ticket = oblk.DADOS[0];
        // oblk.Dados contem o ticket para obter o ficheiro, abre uma janela de browser para fazer o download do ficheiro
        var wurl = CriarLinkRecurso("ticket:" + ticket)
        ExecCmd(this.HostPage.Area.Id, "OpenBrowserWindow(" + wurl)
        return;
    } else {
        window.alert(oblk.MSG)
    }
}

Qsearch.prototype.Disable=function() {
}
Qsearch.prototype.Enable=function() {
}
Qsearch.prototype.Show=function() {
}
Qsearch.prototype.Hide=function() {
}
Qsearch.prototype.Destroy=function() {
}


//***************************************************************** QSEARCHGROUP - define GROUP para ser usado no Qserach
function QsearchGroup(xnod) {
    this.FilterId=new Array();
    this.FilterType=new Array();
    this.TabCtl=null;
    if (xnod == undefined || xnod == null) {
        this.Id="";
        this.DataCtlId="";
        this.TabId="";
        return this
    }
    this.Id=GetAtt(xnod, "ID", "");
    this.DataCtlId=GetAtt(xnod, "DATACTL", "");
    this.TabId=GetAtt(xnod, "TABID", "");
    var xn=xnod.firstChild;
    while (xn!=undefined) {
        if (xn.nodeName == "FILTER") {
            this.FilterId.push(GetAtt(xn, "ID", ""))
            this.FilterType.push(GetAtt(xn, "TYPE", ""))
        }
        xn=xn.nextSibling;
    }
}


//*********************************************
//*********************************************
//*   Classes de base
//*********************************************
//*********************************************


//***************************************************************** QCOL - define COL de um data control
function Qcol(xnod, id, type, comp, dec, histid) {
	if (xnod == undefined || xnod == null) {
		this.Id=id
		this.Tit=""
		this.Type=type
		this.Comp=comp
		this.Dec=0
        if (dec != undefined) this.Dec=dec;
		this.Obrig="N"
		this.Larg=0
		this.Vis="N"
		this.Key="N"
		this.ColCtls=new Array()
		this.HistGetId=""
		this.HistId=""
        if (histid != undefined) this.HistId=histid
		this.HistdesId=""
		this.HistOp="EQ"
		this.Limitctl=""
		this.Limitfld=""
        this.OptLimit="N"
		this.Formulas=new Array()
		this.Status=""
		this.SecOrder=""
		this.Send=""
		this.Recs=""
		this.Provider=""
		this.Idx=""
		this.Val=""  //array de valores possíveis
        this.Refresh="N"
        this.Functionid=""
        this.FuncArgs=""
		return this
	}
	this.Id=GetAtt(xnod, "ID", "")
	this.Tit=GetAtt(xnod, "TIT", "")
	this.Type=GetAtt(xnod, "TYPE", "A")
	var subt=this.Type.substr(1).split(".")
	this.Comp=-1
	this.Dec=-1
	if (subt[0] != "") this.Comp = Number(subt[0])
	if (subt.length > 1) this.Dec = Number(subt[1])
	this.Type = this.Type.substr(0, 1)
  	this.Obrig=GetAtt(xnod, "OBRIG", "N")
  	this.Key=GetAtt(xnod, "KEY", "N")
  	this.Larg=GetAtt(xnod, "LARG", "0", "N")
  	this.Vis=GetAtt(xnod, "VIS", "S")
  	this.ColCtls=new Array()
  	this.HistGetId=GetAtt(xnod, "HISTGETID", "")
  	this.HistOp=GetAtt(xnod, "HISTOP", "EQ")
  	this.HistId=GetAtt(xnod, "HISTID", "")
  	this.HistdesId=GetAtt(xnod, "HISTDESID", "")
  	this.Limitctl=GetAtt(xnod, "LIMITCTL", "")
  	this.Limitfld=GetAtt(xnod, "LIMITFLD", "")
    this.OptLimit=GetAtt(xnod, "OPTLIMIT", "N")
  	this.SecOrder=GetAtt(xnod, "SECORDER", "")
  	this.Send=GetAtt(xnod, "SEND", "S")
  	this.Provider=GetAtt(xnod, "PROVIDER", "")
  	this.Idx=GetAtt(xnod, "IDX", "")
  	this.Val=GetAtt(xnod, "VAL", "")
    this.Refresh=GetAtt(xnod, "REFRESH", "N")
  	this.Formulas=new Array()
  	this.Status=""
  	if (this.Type == "$") {
	  	if (this.Dec == -1) this.Dec=0
	  	this.Dec = this.Dec + 2    //os campos de dinheiro contam sempre com 2 decimais
  	}
    this.FunctionId=GetAtt(xnod, "FUNCTIONID", "");
    this.FunctionArgs=GetAtt(xnod, "FUNCTIONARGS", "");
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
	this.Col=col
}


//***************************************************************** Qfield - define campo de Qrecord
function Qfield(coldef, val) {
	this.Status=""
	this.Coldef=coldef
	this.Val=val
	this.ColCtls=new Array()
	if (this.Coldef.Type == "N") Val=FormatNumber(val, this.Coldef.Dec, "server")
	if (this.Coldef.Type == "$") Val=FormatDinheiro(val, this.Coldef.Dec, "server")
}

//***************************************************************** Qrecord - define record
function Qrecord(coldefs, dados, provider, recpai) {
    if (provider == undefined) provider = ""
    if (dados == undefined || dados == null) dados = new Array();
	this.Status="VAZIO"
	this.Key=""
	this.Func=""
	this.Coldefs=coldefs
	this.Fields = new Array()
	var Aw=dados
	var j=0
	var naovazios=0
	for (var i = 0; i < this.Coldefs.length; i++) {
	    var Coldef = this.Coldefs[i]
	    if (Coldef.Send == "N") {
	        this.Fields.push(new Qfield(Coldef, ""))
	    } else {
	        if (j < Aw.length && Coldef.Provider == provider) {
	            var Val = Aw[j]
	            if (Val != "") naovazios++
	            if (Coldef.Key == "S") this.Key = Val
	            this.Fields.push(new Qfield(Coldef, Val))
	            j++
	        } else {
	            if (recpai != undefined && recpai != "" && recpai != null) {
	                this.Fields.push(new Qfield(Coldef, recpai.Fields[i].Val))
	            } else {
	                this.Fields.push(new Qfield(Coldef, ""))
	            }
	        }
	    }
	}
	if (naovazios > 0) this.Status=""
    for (var i = 0; i < this.Coldefs.length; i++) {  //ver se existem campos a calcular
        if (this.Coldefs[i].Send == "N") {
            if (this.Coldefs[i].FunctionId != "") this.CalcColFunction(this.Coldefs[i], i);
        }
    }
}

Qrecord.prototype.Field=function(id) {
	for (var i=0; i<this.Fields.length; i++) {
		if (this.Fields[i].Coldef.Id == id) return this.Fields[i]	
	}
}

Qrecord.prototype.ResetCtls=function() {
	for (var i=0; i<this.Fields.length; i++) {
		this.Fields[i].ColCtls=new Array()
	}
}

Qrecord.prototype.Update=function(dados) {
	var Aw=dados
	var j=0
	for (var i=0; i<this.Coldefs.length; i++) {
		var Coldef=this.Coldefs[i]
		if (Coldef.Send == "N") {
			this.Fields[i].Val=""
		} else {
			if (j < Aw.length) {
				this.Fields[i].Val=Aw[i]
				j++
			} else {
				this.Fields[i].Val=""
			}
		}
	}
}

Qrecord.prototype.CalcColFunction=function(col, ix) {
    var Aargs=col.FunctionArgs.split("[");
    var wcmd="var valcol=" + col.FunctionId + "(";
    for (var i=0; i<Aargs.length; i++) {
        if (i > 0) wcmd += ", ";
        wcmd += "wvals[" + i + "]";
    }
    wcmd += ")";
    var wvals=new Array();
    for (var c=0; c<this.Coldefs.length; c++) {
        for (var i=0; i<Aargs.length; i++) {
            if (this.Coldefs[c].Id == Aargs[i]) {
                wvals[i]=ConvertToNative(this.Fields[c].Val, this.Coldefs[c].Type);
            }
        }
    }
    try {eval(wcmd)}
    catch(exp) {window.alert(GetMsg(1, "Erro na avaliação da Col (" + col.Id + ") - FunctionId (" + col.FunctionId + ") - " + exp.message));
        return;}
    this.Fields[ix].Val=ConvertFromNative(valcol, col.Type, col.Dec);
}


//***************************************************************** QFORMULA - define Formula
function Qformula(xnod, ctl) {
	this.Id=GetAtt(xnod, "ID", "")
	this.Parent=ctl
	this.Functionid=GetAtt(xnod, "FUNCTIONID", "")
	this.Provider=GetAtt(xnod, "PROVIDER", "")
	this.TriggerOr=GetAtt(xnod, "TRIGGEROR", "N")
	this.Args=new Array()
	this.Results=new Array()
	this.Events=new Array()
	var xn=xnod.firstChild
	var n=0
	while (xn!=undefined) {
		if (xn.nodeName == "ARG") {
			n++
			var Arg=new Object()
			Arg.Id=GetAtt(xn, "ID", "Arg" + n)
			Arg.ColIndex = -1
			Arg.Ctl=""
			Arg.HistGetId=GetAtt(xn, "HISTGETID", "")
			Arg.HistOp=GetAtt(xn, "HISTOP", "EQ")
			Arg.Var=GetAtt(xn, "VAR", "")
			Arg.Const=GetAtt(xn, "CONST", null)
			Arg.Wtype=GetAtt(xn, "WTYPE", "A")
			Arg.Tipo=""
			if (Arg.Var != "") Arg.Tipo="VAR"
			if (Arg.HistGetId != "") Arg.Tipo="HIST"
			if (Arg.Const != null) Arg.Tipo="CONST"
			var colid=GetAtt(xn, "DATAFLD", "")
			var ctlid=GetAtt(xn, "DATACTL", "")
			var wctl=ctl
			if (ctlid != "") wctl=ctl.HostPage.GetCtl(ctlid)
			if (colid != "") {
				Arg.Tipo="COL"
				Arg.Ctl=wctl
				for (var i=0; i<wctl.Cols.length; i++) {
					if (wctl.Cols[i].Id == colid) {
						wctl.Cols[i].Formulas.push(this.Parent)
						Arg.ColIndex = i
						break
					}
				}
				if (Arg.ColIndex == -1) {
					window.alert(GetMsg(1, "ROTINA (" + this.Id + ") - coluna (" + colid + ") inexistente"))
				}

            }

            Arg.Trigger = GetAtt(xn, "TRIGGER", "NEVER")
            if (Arg.Trigger != "ALLWAYS" && Arg.Trigger != "NEVER" && Arg.Trigger != "NULL" && Arg.Trigger != "NOTNULL" && Arg.Trigger != "NULLMOD" && Arg.Trigger != "NOTNULLMOD" && Arg.Trigger != "REFRESH" && Arg.Trigger != "MOD") {
                window.alert(GetMsg(1, "ROTINA (" + this.Id + ") - TRIGGER da coluna (" + colid + ") invalido"))
            }
			this.Args.push(Arg)
		}
		if (xn.nodeName == "RESULT") {
			var Result=new Object()
			Result.ColIndex=""
			Result.Tipo=""
			Result.Ctl=""
			var colid=GetAtt(xn, "DATAFLD", "")
			var ctlid=GetAtt(xn, "DATACTL", "")
			var wctl=ctl
			if (ctlid != "") wctl=ctl.HostPage.GetCtl(ctlid)
			Result.Histid=GetAtt(xn, "HISTID", "")
			Result.Histop=GetAtt(xn, "HISTOP", "EQ")
			if (Result.Histid != "") Result.Tipo="HIST"
			Result.Var=GetAtt(xn, "VAR", "")
			if (Result.Var != "") {
				if (Result.Var != "ROTSTATUS" && Result.Var != "ROTMSG" && Result.Var != "ROTMSGID" && Result.Var != "ROTRESULT") {
					window.alert(GetMsg(1, "ROTINA (" + this.Id + ") - RESULT VAR (" + colid + ") inexistente"))
				} else {
					if (Result.Tipo == "") {
						Result.Tipo="VAR"
					} else {
						Result.Tipo="MIX"
					}
				}
			}
			if (colid != "") {
				var ColIndex=-1
				Result.Ctl=wctl
				for (var i=0; i<wctl.Cols.length; i++) {
					if (wctl.Cols[i].Id == colid) {
						ColIndex = i
						break
					}
				}
				if (ColIndex == -1) {
					window.alert(GetMsg(1, "ROTINA (" + this.Id + ") - coluna (" + colid + ") inexistente"))
				}
				Result.ColIndex=ColIndex
				if (Result.Tipo == "") {
					Result.Tipo = "COL"
				} else {
					Result.Tipo = "MIX"
				}
			}
			this.Results.push(Result)
		}
		if (xn.nodeName == "EVENT") {
			var wevent=new Qevent(xn)
			this.Events.push(wevent)
		}
		xn=xn.nextSibling
	}
}


//******* adicionar condição
function AppendCond(cond, idfld, tipo, valor, tipocond, op) {
    var sep=""
    if (tipo == "A" || tipo == "T") sep="'"
    if (tipo == "D" || tipo == "H" || tipo == "S") sep="#"
    var tmp = valor.split(";");
    if (tmp.length > 1 && op == "EQ")
        op = "IN";
    else {
        var re = /;/g
        valor = valor.replace(re, "")
        var re = /--/g
        valor = valor.replace(re, "")
        var re = /\'/g
        valor = valor.replace(re, "''")
    }
    var wcond=idfld
    if (tipocond == "" || tipocond == undefined) {
        switch (op) {
            case "EQ":
                var wop="[=["
                break
            case "GT":
                var wop="[>["
                break
            case "GE":
                var wop="[>=["
                break
            case "LT":
                var wop="[<["
                break
            case "LE":
                var wop="[<=["
                break
			case "IN":
				var wop = " IN"
				break
            default:
                var wop="[=["
                break
        }
        if (wop == " IN") {
            var val = "("
            for (var i = 0; i < tmp.length; i++) {
                if (i > 0)
                    val += ","
                val += sep + tmp[i] + sep
            }
            val += ")"
        }
        else
            var val = sep + valor + sep
        wcond += wop + val
    }
    if (tipocond == "LEDTXT") {
        wcond += "[LIKE[" + sep + valor + "*" + sep
    }
    if (tipocond == "MULTIGRID") {
        var wop=""
        var wvalor=valor
        if (valor.indexOf("=") == 0) {
            wvalor=valor.substr(1)
            wop="[=["
        }
        if (valor.indexOf(">") == 0) {
            wvalor=valor.substr(1)
            wop="[>["
        }
        if (valor.indexOf("<") == 0) {
            wvalor=valor.substr(1)
            wop="[<["
        }
        if (valor.indexOf(">=") == 0) {
            wvalor=valor.substr(2)
            wop="[>=["
        }
        if (valor.indexOf("<=") == 0) {
            wvalor=valor.substr(2)
            wop="[<=["
        }
        if (valor.indexOf("!=") == 0) {
            wvalor=valor.substr(2)
            wop="[<>["
        }
        if (valor.indexOf("<>") == 0) {
            wvalor=valor.substr(2)
            wop="[<>["
        }
        if (wop == "")  {
            if (tipo == "A") {
                wop="[LIKE["
                if (wvalor.indexOf("*") == -1) wvalor=wvalor + "*"
            } else {
                wop="[=["
            }
        }
        wcond += wop + sep + wvalor + sep
    }
    if (cond != "") {
        return cond + "{" + wcond
    } else {
        return wcond
    }           
}

//***************************************************************** COMBLK, INTERBLK e PAGCOMBLK - blocos de interface com o servidor
function Comblk() {
    this.STAT=""
    this.ONLINE=""
    this.SES=""
    this.LANG=""
    this.QCOMLIST=new Array()
}

Comblk.prototype.GetXmlString=function() {
    var xblock = "<QCOMBLK STAT=\"\" ONLINE=\"\" LANG=\"" + this.LANG + "\" SES=\"" + this.SES + "\">"
    for (var i=0; i<this.QCOMLIST.length; i++) {
        var wblk=this.QCOMLIST[i]
        xblock += "<QCOM MOD=\"" + wblk.MOD + "\" APP=\"" + wblk.APP + "\" IDENT=\"" + wblk.IDENT + "\" FUNC=\"" + wblk.FUNC
        xblock += "\" COND=\"" + Xencode(wblk.COND) + "\" ORD=\"" + wblk.ORD + "\" CMPS=\"" + wblk.CMPS + "\" DADOS=\""
        var w=""
        for (var r=0; r<wblk.DADOS.length; r++) {
            var wrec=wblk.DADOS[r]
            if (r > 0) w+="{"
            for (var c=0; c<wrec.length; c++) {
                if (c > 0) w+="["
                w+=wrec[c]
            }
        }
        w=Xencode(w)
        xblock += w + "\" OPT=\"" + wblk.OPT + "\" MSG=\"" + wblk.MSG + "\" STAT=\"" + wblk.STAT + "\" FICH=\"" + wblk.FICH + "\"></QCOM>"
    }
    xblock += "</QCOMBLK>"
    return xblock
}

Comblk.prototype.LoadXmlData=function(xresp) {
    this.STAT=GetAtt(xresp, "STAT", "OK")
    this.ONLINE=GetAtt(xresp, "ONLINE", "S")
    this.SES=GetAtt(xresp, "SES", User.SessionId)
    User.SetSessionId(this.SES)
    var xblocks=xresp.getElementsByTagName("QCOM")
    var xblk=xblocks[0]
    var oblk=new Interblk()
    oblk.MOD=GetAtt(xblk, "MOD", "")
    oblk.APP=GetAtt(xblk, "APP", "")
    oblk.IDENT=GetAtt(xblk, "IDENT", "")
    oblk.FUNC=GetAtt(xblk, "FUNC", "")
    oblk.COND=GetAtt(xblk, "COND", "")
    oblk.ORD=GetAtt(xblk, "ORD", "")
    var w=GetAtt(xblk, "CMPS", "")
    oblk.CMPS=w.split("[")
    w=GetAtt(xblk, "DADOS", "")
    var wrec=new Array()
    var Aw=w.split("{")
    for (var i=0; i<Aw.length; i++) {
        wrec=Aw[i].split("[")
        oblk.DADOS.push(wrec)
    }
    oblk.OPT=GetAtt(xblk, "OPT", "")
    oblk.MSG=GetAtt(xblk, "MSG", "")
    oblk.STAT=GetAtt(xblk, "STAT", "")
    oblk.gstatus=this.STAT
    oblk.gonline=this.ONLINE
    this.QCOMLIST.push(oblk)
}


function Interblk() {
	this.MOD=""
	this.APP=""
	this.IDENT=""
	this.FUNC=""
	this.COND=""
	this.ORD=""
	this.CMPS=new Array()
	this.DADOS=new Array()
	this.OPT=""
	this.MSG=""
	this.STAT=""
	this.FICH=""
    this.YEAR="" + User.Ano;
}

Interblk.prototype.GetClone=function() {
	var oblk=new Interblk()
	oblk.MOD=this.MOD
	oblk.APP=this.APP
	oblk.IDENT=this.IDENT
	oblk.FUNC=this.FUNC
	oblk.COND=this.COND
	oblk.ORD=this.ORD
    oblk.CMPS=new Array()
    for (var i=0; i<this.CMPS.length; i++) {
        oblk.CMPS.push(this.CMPS[i])
    }
    oblk.DADOS=new Array()
    for (var i=0; i<this.DADOS.length; i++) {
        oblk.DADOS.push(this.DADOS[i])
    }
	oblk.OPT=this.OPT
	oblk.MSG=this.MSG
	oblk.STAT=this.STAT
	oblk.FICH = this.FICH
	return oblk
}


function PagComblk() {  //estrutura para conter o bloco de comunicação mais outras informações necessarias
    this.dbTipo=""
    this.dbAddr=""
    this.dbIndex=""
    this.interblk=null
}


//***************************************************************** LOGBLK - bloco de Log
function Logblk(time, dir, mod, app, ident, func, cond, ord, cmps, dados, opt, msg, stat, online, year) {
	this.TIME=time
	this.DIR=dir
	this.MOD=mod
	this.APP=app
	this.IDENT=ident
	this.FUNC=func
	this.COND=cond
	this.ORD=ord
	this.CMPS=cmps
	this.DADOS=dados
	this.OPT=opt
	this.MSG=msg
	this.STAT=stat
	this.ONLINE=online
    this.YEAR=year
}


//*********************************************
//*********************************************
//*   Comunicação com o Servidor
//*********************************************
//*********************************************


//***************************************************************** COMUNIT - Unidade de comunicação
function ComUnit(page, tipo) {
	this.Page=page
	this.Tipo=tipo
	this.Addr=""
	this.Seq=""
    this.Icomblk=null
    this.Ocomblk=null
    this.Timeout=25000;  //default timeout para comunicações assincronas
}


//******** Processar o primeiro pedido da queue
function ComDispatch() {
	if (ComStatus == "RUNNING") return
    if (ComUnits.length == 0) {
        App.UnBlockAllInput()
        return
    }
    //if (ComUnits.length == 0) return
	ComStatus="RUNNING"
	var comunit=ComUnits[0]
	switch (comunit.Tipo) {
		case "REMOTE":
			SendReceiveRemote()
			break
        case "REMOTEJSON":
            SendReceiveRemoteJson()
            break
		case "HOST":
			SendReceiveHost()
			break
		case "REST":
			SendReceiveRest()
			break
		case "INTERNAL":
			SendReceiveInternal()
			break
		case "SIMUL":
			SendReceiveSimul()
			break
		case "REMOTEXML":
			SendReceiveXml()
			break
		case "LOCALXML":
			SendReceiveXml()
			break
		default:
			window.alert(GetMsg(1, "Tipo de comunicação invalido (" + comunit.Tipo + ") "))
			ComUnitDone()
	}
}


//******** Processar resposta ao primeiro pedido da queue e fechar o pedido passando ao proximo
function ComProcessResponse() {
	var comunit=ComUnits[0]
	for (var i=0; i<comunit.Ocomblk.QCOMLIST.length; i++) {
		var oblk=comunit.Ocomblk.QCOMLIST[i]
        oblk.gstatus=comunit.Ocomblk.STAT
        oblk.gonline=comunit.Ocomblk.ONLINE
		now=Agora()
		var wlog=new Logblk(now.getTime(), "Srv - Cli &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; < < < --- @@@@ &nbsp;&nbsp;&nbsp;&nbsp; Resposta", oblk.MOD, oblk.APP, oblk.IDENT, oblk.FUNC, oblk.COND, oblk.ORD, oblk.CMPS, oblk.DADOS, oblk.OPT, oblk.MSG, oblk.STAT, oblk.gonline, oblk.YEAR)
		comunit.Page.Log.push(wlog)
		var ctlid=oblk.IDENT
		var unitkey=""
		var ix=ctlid.indexOf("._.");
		if (ix > -1) {
			unitkey=ctlid.substring(ix + 3)
			ctlid=ctlid.substr(0, ix)
		}
		wctl=comunit.Page.GetCtl(ctlid)
		if (wctl == null) {
			//window.alert(GetMsg(1, "Resposta do servidor para controlo inexistente (" + ctlid + ")"))
		} else {
			var ultimo=false
			if (i == comunit.Ocomblk.QCOMLIST.length-1 && (comunit.Seq == "GRP" || comunit.Seq == "LAST")) ultimo=true
            if (unitkey == "") {
		    	wctl.Receive(oblk, oblk.gstatus, ultimo)
	    	} else {
		    	wctl.Receive(oblk, unitkey)  //LEDITs e LEDITMs
	    	}
		}
	}
	ComUnitDone()
}

//******** Processar resposta ao primeiro pedido da queue e fechar o pedido passando ao proximo
function ComUnitDone() {
	ComUnits.splice(0,1)
	ComStatus="IDDLE"
	if (ComUnits.length > 0) {
        window.setTimeout("ComDispatch()", 50)     //ComDispatch()
    } else {
        App.UnBlockAllInput()
    }
}

function GetProviderInfo(pag, pagblk) {
    var iblk=pagblk.interblk
	var dbindex=0
	var Aw=iblk.APP.split(".")
	if (App.MultiSite == "S" && pag.Modulo != "") {
		if (Aw.length == 1) {
			Aw[1]=Aw[0]
			Aw[0]=pag.Modulo	
		}	
	}
	if (Aw.length > 1) {
		var dbaddr=""
		var dbtipo=""
		for (var i=0; i<App.Db.length; i++) {
			if (App.Db[i].Id == Aw[0]) {
				dbaddr=App.Db[i].Address
				dbtipo=App.Db[i].Type
				dbindex=i
				break
			}
		}
		if (dbtipo == "") {
			if (Aw[0] == "INTERNAL") {
				dbtipo="INTERNAL"	
			} else {
				window.alert(GetMsg(1, " (" + Aw[0] + ") não encontrada nas DBs da Aplicação"))
			}
		}
		var appl=Aw[1]
	} else {
		var dbaddr=App.Db[0].Address
		var dbtipo=App.Db[0].Type
		var appl=Aw[0]
	}
	pagblk.dbTipo=dbtipo
	pagblk.dbAddr=dbaddr
	pagblk.dbIndex=dbindex
	iblk.APP=appl
	return pagblk
}


//******* Enviar e receber dados do servidor    act=SINGLE / FIRST / ADD / END
function SendServer(pag, iblk, act, commtimeout) {
	if (iblk != null) {
        var iblk=iblk.GetClone()
        var pagblk=new PagComblk()
        pagblk.interblk=iblk
    }
	var now=Agora()
	if (act == "FIRST" || act == "SINGLE") {
		pag.BlkComArray=new Array()
	}
	if (act != "END") {
		var wlog=new Logblk(now.getTime(), "Cli - Srv &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -------------------------------------- > > > &nbsp;&nbsp;&nbsp;&nbsp; Pedido", iblk.MOD, iblk.APP, iblk.IDENT, iblk.FUNC, iblk.COND, iblk.ORD, iblk.CMPS, iblk.DADOS, iblk.OPT, iblk.MSG, iblk.STAT, "", iblk.YEAR)
		pag.Log.push(wlog)
		pagblk=GetProviderInfo(pag, pagblk)
		pag.BlkComArray.push(pagblk)
	}
	if (act == "END" || act == "SINGLE") {
		var samedb=true
		if (pag.BlkComArray.length > 1) {
			var wtipo=pag.BlkComArray[0].dbTipo
			var waddr=pag.BlkComArray[0].dbAddr
			var wdbindex=pag.BlkComArray[0].dbIndex
			for (var i=0; i<pag.BlkComArray.length; i++) {
				if (pag.BlkComArray[0].dbTipo != wtipo || pag.BlkComArray[0].dbAddr != waddr || (pag.BlkComArray[0].dbTipo != "REMOTE" && pag.BlkComArray[0].dbTipo != "HOST")) {
					samedb=false
					break
				}
			}
		} else {
			samedb=false
		}
		if (samedb == true) {   //envia um só pedido multiplo  apenas dbs do tipo REMOTE ou HOST
            var wcomblk=new Comblk()
            wcomblk.LANG=User.Language
            wcomblk.SES=User.SessionId
            for (var i=0; i<pag.BlkComArray.length; i++) {
                wcomblk.QCOMLIST.push(pag.BlkComArray[i].interblk)
            }
			pag.BlkComArray=new Array()
			var comunit=new ComUnit(pag, wtipo)
			comunit.Addr=waddr
			comunit.Seq="GRP"
            comunit.Icomblk=wcomblk
            if (commtimeout != undefined) comunit.Timeout=commtimeout;
			ComUnits.push(comunit)
		} else {
			for (var i=0; i<pag.BlkComArray.length; i++) {
                var wcomblk=new Comblk()
                wcomblk.LANG=User.Language
                wcomblk.SES=User.SessionId
                wcomblk.QCOMLIST.push(pag.BlkComArray[i].interblk)
                var comunit=new ComUnit(pag, pag.BlkComArray[i].dbTipo)
                comunit.Addr=pag.BlkComArray[i].dbAddr
				if (i == pag.BlkComArray.length-1 && i > 0) comunit.Seq="LAST"
                comunit.Icomblk=wcomblk
                if (commtimeout != undefined) comunit.Timeout=commtimeout;
				ComUnits.push(comunit)
			}
		}
		pag.BlkComArray=new Array()
		ComDispatch()
	}
}


function SendServerSync(pag, iblk) {
	var now=Agora()
    var pagblk=new PagComblk()
    pagblk.interblk=iblk
    pagblk=GetProviderInfo(pag, pagblk)
	var wlog=new Logblk(now.getTime(), "Cli - Srv", iblk.MOD, iblk.APP, iblk.IDENT, iblk.FUNC, iblk.COND, iblk.ORD, iblk.CMPS, iblk.DADOS, iblk.OPT, iblk.MSG, iblk.STAT, "", iblk.YEAR)
	pag.Log.push(wlog)
    var wcomblk=new Comblk()
    wcomblk.LANG=User.Language
    wcomblk.SES=User.SessionId
    wcomblk.QCOMLIST.push(iblk.GetClone())
    var comunit=new ComUnit(pag, pagblk.dbTipo)
    comunit.Addr=pagblk.dbAddr
    comunit.Icomblk=wcomblk

	switch (comunit.Tipo) {
		case "REMOTE":
			oblk=SendReceiveRemoteSync(comunit)
			break
        case "REMOTEJSON":
            oblk=SendReceiveRemoteJsonSync(comunit)
            break
		case "HOST":
			oblk=SendReceiveHost(comunit)
			break
		case "INTERNAL":
			oblk=SendReceiveInternal(comunit)
			oblk.gstatus="OK"
			break
		case "REST":
			oblk=SendReceiveRestSync(comunit)
			break
		case "SIMUL":
			oblk=SendReceiveSimul(comunit)
			oblk.gstatus="OK"
			break
		case "REMOTEXML":
			oblk=SendReceiveXml(comunit)
			oblk.gstatus="OK"
			break
		case "LOCALXML":
			oblk=SendReceiveXml(comunit)
			oblk.gstatus="OK"
			break
	}
	now=Agora()
	var wlog=new Logblk(now.getTime(), "Srv - Cli", oblk.MOD, oblk.APP, oblk.IDENT, oblk.FUNC, oblk.COND, oblk.ORD, oblk.CMPS, oblk.DADOS, oblk.OPT, oblk.MSG, oblk.STAT, oblk.gonline, oblk.YEAR)
	comunit.Page.Log.push(wlog)
	return oblk
}


//******* Servidor Remoto
function SendReceiveRemote() {
	var comunit=ComUnits[0]
    var Xstr=comunit.Icomblk.GetXmlString()
    if (comunit.Page.Area.ShowWaitSign == "S") App.BlockAllInput("SRV")
	var boundary = "---------------------------7d9270c30c68";
	var xmlhttp=null
	try {
		xmlhttp = new XMLHttpRequest()
	}
	catch(exp) {
		xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
	}
	if (xmlhttp == null) {
		window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
		return
	}
	xmlhttp.open("POST", comunit.Addr, true)
	xmlhttp.setRequestHeader("Content-Type" , "multipart/form-data; charset=UTF-8; boundary="+boundary);
	xmlhttp.timeout=comunit.Timeout;
    if (BrowserIE10) xmlhttp.responseType = 'msxml-document'
	xmlhttp.ontimeout=function() {
		SendReceiveRemoteTimeout(xmlhttp)
	}

    xmlhttp.send("--" + boundary + "\r\nContent-Disposition: form-data; name=\"xmldata\"\r\n\r\n" + Xstr + "\r\n" + "--" + boundary + "--\r\n");

	xmlhttp.onreadystatechange=function() {
		SendReceiveRemoteStateChange(xmlhttp)
	}
	return
}

function SendReceiveRemoteTimeout(xmlhttp) {
	var comunit=ComUnits[0]
	window.alert(GetMsg(1, "O servidor não respondeu atempadamente ao pedido (Timeout) "))
	ComUnitDone()
}

function SendReceiveRemoteStateChange(xmlhttp) {
	if (xmlhttp.readyState != 4) return
	var comunit=ComUnits[0]
	if (xmlhttp.status != 200) {
		var xresp=xmlhttp.responseText
		ErrHtml=xresp
		window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
		ComUnitDone()
		return
	}
	var xresp=xmlhttp.responseXML
	xresp=xresp.documentElement
	if (xresp == null) {
		window.alert(GetMsg(1, "Foi recebida uma resposta invalida do servidor"))
		ComUnitDone()
		return
	}
	App.SetServerDate(xmlhttp.getResponseHeader("date"))
	xmlhttp=null
    if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
    comunit.Ocomblk=new Comblk()
    comunit.Ocomblk.LoadXmlData(xresp)
	ComProcessResponse()
}

function SendReceiveRemoteSync(comunit) {
    var Xstr=comunit.Icomblk.GetXmlString()
	var boundary = "---------------------------7d9270c30c68";
	var xmlhttp=null
	try {
		xmlhttp = new XMLHttpRequest()
	}
	catch(exp) {
		xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
	}
	if (xmlhttp == null) {
		window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
		return
	}
	xmlhttp.open("POST", comunit.Addr, false)
	xmlhttp.setRequestHeader("Content-Type" , "multipart/form-data; charset=UTF-8; boundary="+boundary);
    if (BrowserIE10) xmlhttp.responseType = 'msxml-document'

    xmlhttp.send("--" + boundary + "\r\nContent-Disposition: form-data; name=\"xmldata\"\r\n\r\n" + Xstr + "\r\n" + "--" + boundary + "--\r\n");

	if (xmlhttp.status != 200) {
		var xresp=xmlhttp.responseText
		ErrHtml=xresp
		window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
		return
	}
	var xresp=xmlhttp.responseXML
	xresp=xresp.documentElement
	xmlhttp=null
    comunit.Ocomblk=new Comblk()
    comunit.Ocomblk.LoadXmlData(xresp)
    return comunit.Ocomblk.QCOMLIST[0]
}


//******* Servidor Remoto JSON
function SendReceiveRemoteJson() {
    var comunit=ComUnits[0]
    var jstr=JSON.stringify(comunit.Icomblk)
    if (comunit.Page.Area.ShowWaitSign == "S") App.BlockAllInput("SRV")
    var boundary = "---------------------------7d9270c30c68";
    var xmlhttp=null
    try {
        xmlhttp = new XMLHttpRequest()
    }
    catch(exp) {
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
    }
    if (xmlhttp == null) {
        window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
        if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
        return
    }
    xmlhttp.open("POST", comunit.Addr, true)
    xmlhttp.setRequestHeader("Content-Type" , "multipart/form-data; charset=UTF-8; boundary="+boundary);
    xmlhttp.timeout=comunit.Timeout;
    xmlhttp.ontimeout=function() {
        SendReceiveRemoteJsonTimeout(xmlhttp)
        if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
        return
    }

    xmlhttp.send("--" + boundary + "\r\nContent-Disposition: form-data; name=\"jsondata\"\r\n\r\n" + jstr + "\r\n" + "--" + boundary + "--\r\n");

    xmlhttp.onreadystatechange=function() {
        SendReceiveRemoteJsonStateChange(xmlhttp)
    }
    if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
    return
}

function SendReceiveRemoteJsonTimeout(xmlhttp) {
    var comunit=ComUnits[0]
    window.alert(GetMsg(1, "O servidor não respondeu atempadamente ao pedido (Timeout) "))
    ComUnitDone()
}

function SendReceiveRemoteJsonStateChange(xmlhttp) {
    if (xmlhttp.readyState != 4) return
    var comunit=ComUnits[0]
    var xresp=xmlhttp.responseText
    if (xmlhttp.status != 200 || xresp.substr(0,8) != "{\"STAT\":") {
        ErrHtml=xresp
        window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
        ComUnitDone()
        return
    }
    var jsobj=JSON.parse(xresp)
    if (jsobj.QCOMLIST.length == 0) jsobj.QCOMLIST.push(new Interblk())
    if (jsobj.QCOMLIST[0].DADOS.length == 0) jsobj.QCOMLIST[0].DADOS.push(new Array())
    comunit.Ocomblk=jsobj
    User.SetSessionId(comunit.Ocomblk.SES)
    ComProcessResponse()
}

function SendReceiveRemoteJsonSync(comunit) {
    var jstr=JSON.stringify(comunit.Icomblk)
    var boundary = "---------------------------7d9270c30c68";
    var xmlhttp=null
    try {
        xmlhttp = new XMLHttpRequest()
    }
    catch(exp) {
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
    }
    if (xmlhttp == null) {
        window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
        return
    }
    xmlhttp.open("POST", comunit.Addr, false)
    xmlhttp.setRequestHeader("Content-Type" , "multipart/form-data; charset=UTF-8; boundary="+boundary);

    xmlhttp.send("--" + boundary + "\r\nContent-Disposition: form-data; name=\"jsondata\"\r\n\r\n" + jstr + "\r\n" + "--" + boundary + "--\r\n");

    var xresp=xmlhttp.responseText
    if (xmlhttp.status != 200 || xresp.substr(0,8) != "{\"STAT\":") {
        ErrHtml=xresp
        window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
        return
    }
    var jsobj=JSON.parse(xresp)
    if (jsobj.QCOMLIST.length == 0) jsobj.QCOMLIST.push(new Interblk())
    if (jsobj.QCOMLIST[0].DADOS.length == 0) jsobj.QCOMLIST[0].DADOS.push(new Array())
    comunit.Ocomblk=jsobj
    User.SetSessionId(comunit.Ocomblk.SES)
    return jsobj.QCOMLIST[0]
}


//******* Servidor Host  (tipo qwin / qaddin)
function SendReceiveHost(comunit) {
	if (comunit == undefined) {
		var comunit=ComUnits[0]
		var sync=false
	} else {
		var sync=true
	}
    var Xstr=comunit.Icomblk.GetXmlString()
	if (comunit.Page.Area.ShowWaitSign == "S") App.BlockAllInput("SRV")
	var sresp=window.external.DataProvider(Xstr)
	if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
	var xresp=CreateXnode(sresp)
    comunit.Ocomblk=new Comblk()
    comunit.Ocomblk.LoadXmlData(xresp)
	if (sync == false) {
		ComProcessResponse()
	} else {
		return comunit.Ocomblk.QCOMLIST[0]
	}
}


//******* Servidor REST
function SendReceiveRest() {
	var comunit=ComUnits[0]
	if (comunit.Page.Area.ShowWaitSign == "S") App.BlockAllInput("SRV")
	var xmlhttp=null
	try {
		xmlhttp = new XMLHttpRequest()
	}
	catch(exp) {
		xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
	}
	if (xmlhttp == null) {
		window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
	    if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
		return
	}
	if (comunit.iblk.FUNC == "GETNIVELTREE") {
		var Aw1=comunit.iblk.OPT.split("{")
		var Aw=Aw1[0].split("[")
		var wcond=Aw[2] + "="
		var Aw=Aw1[1].split("[")
		wcond +=Aw[2]
	} else {
		var wcond=comunit.iblk.COND.replace(/['\[]/g,"")
	}
	if (wcond == "") {
		wcond=null
	} else {
		wcond = [ wcond ]
	}
	var Acmps=comunit.iblk.CMPS.split(",")
	var request={ "Modulo" : comunit.iblk.MOD, "Lingua" : User.Language, "Columns" : Acmps, "Conditions" : wcond}
	
	xmlhttp.open("POST", comunit.Addr + "/" + comunit.iblk.APP, true)
	xmlhttp.setRequestHeader("Content-Type" , "application/json; charset=UTF-8");
	var jstr=JSON.stringify(request)
	request=null
	xmlhttp.send(jstr);
	xmlhttp.onreadystatechange=function() {
		SendReceiveRestStateChange(xmlhttp)
	}
	if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
	return
}

function SendReceiveRestStateChange(xmlhttp) {
	if (xmlhttp.readyState != 4) return
	var comunit=ComUnits[0]
	if (xmlhttp.status != 200) {
		var xresp=xmlhttp.responseText
		ErrHtml=xresp
		window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
		ComUnitDone()
		return
	}
	var response=JSON.parse(xmlhttp.responseText)
	App.SetServerDate(xmlhttp.getResponseHeader("date"))
	xmlhttp=null
	if (comunit.Page.Area.ShowWaitSign == "S") App.UnBlockAllInput("SRV")
	comunit.oblks=new Array()
	var oblk=new Interblk()
	oblk.MOD=comunit.iblk.MOD
	oblk.APP=comunit.iblk.APP
	oblk.IDENT=comunit.iblk.IDENT
	oblk.FUNC=comunit.iblk.FUNC
	oblk.COND=""
	oblk.ORD=""
	oblk.CMPS=""
	var w=""
	if (response.Data != null) {
		for (var i=0; i<response.Data.length; i++) {
			var linha=response.Data[i]
			if (i > 0) w+="{"
			for (var j=0; j<linha.length; j++) {
				if (j > 0) w+="["
				w+=linha[j]
			}
		}
	}
	oblk.DADOS=w
	oblk.OPT=""
	oblk.MSG=response.ResultMessage
	oblk.STAT=response.Result
	oblk.gstatus=oblk.STAT
	oblk.gonline="S"
	response=null
	comunit.oblks.push(oblk)
	ComProcessResponse()
}

function SendReceiveRestSync(comunit) {
	var xmlhttp=null
	try {
		xmlhttp = new XMLHttpRequest()
	}
	catch(exp) {
		xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
	}
	if (xmlhttp == null) {
		window.alert(GetMsg(1, "Não foi possível instanciar um XmlHttp para comunicações"))
		return
	}
	var request=comunit.iblk.DADOS
	
	xmlhttp.open("POST", comunit.Addr + "/" + comunit.iblk.APP, false)
	xmlhttp.setRequestHeader("Content-Type" , "application/json; charset=UTF-8");
	var jstr=JSON.stringify(request)
	request=null
	xmlhttp.send(jstr);
	if (xmlhttp.status != 200) {
		var xresp=xmlhttp.responseText
		ErrHtml=xresp
		window.open("errohtml.htm","ERRO","toolbar=no, directories=no, location=no, menubar=no, titlebar=no, resizable=yes, scrollbars=yes, width=600, height=400, top=50, left=50")
		return
	}
	var response=JSON.parse(xmlhttp.responseText)
	App.SetServerDate(xmlhttp.getResponseHeader("date"))
	xmlhttp=null
	comunit.oblks=new Array()
	var oblk=new Interblk()
	oblk.MOD=comunit.iblk.MOD
	oblk.APP=comunit.iblk.APP
	oblk.IDENT=comunit.iblk.IDENT
	oblk.FUNC=comunit.iblk.FUNC
	oblk.COND=""
	oblk.ORD=""
	oblk.CMPS = ""
	oblk.DADOS=response.MainGroup
	oblk.OPT=""
	oblk.MSG=response.ResultMessage
	oblk.STAT=response.Result
	oblk.gstatus=oblk.STAT
	oblk.gonline="S"
	return oblk
}


//******* Servidor Xml
function SendReceiveXml(comunit) {
	if (comunit == undefined) {
		var comunit=ComUnits[0]
		var sync=false
	} else {
		var sync=true
	}
	if (comunit.Tipo == "LOCALXML") {
		if (BrowserIE || BrowserOP) {
			var xdoc=new ActiveXObject("MSXML.DOMDocument")
		} else {
			var docparser=new DOMParser()
			var xdoc=docparser.parseFromString("<a></a>","text/xml")
		}
		var r=xdoc.load(comunit.Addr)
		if (r == false) {
			window.alert(GetMsg(1, "Erro na abertura da DB em XML (" + comunit.Addr + ") - inexistente ou invalido."))
			var xdoc=null
		}
	} else {
		var xdoc=GetXmlDoc(dbaddr)
	}
	// aqui deveria invocar tratamento de db em xml que não foi ainda implementado
	comunit.oblks=new Array()
	if (sync == false) {
		ComProcessResponse()
	} else {
		return oblk
	}
}

//******* Servidor Interno
function SendReceiveInternal(comunit) {
	if (comunit == undefined) {
		var comunit=ComUnits[0]
		var sync=false
	} else {
		var sync=true
	}
	var idrotina="InternalDB_" + comunit.Icomblk.QCOMLIST[0].APP
    var iblk=comunit.Icomblk.QCOMLIST[0]
	try { eval("var oblk=" + idrotina + "(iblk)")}
	catch(exp) {
		window.alert(GetMsg(1, "Não encontrada rotina (" + idrotina + ") para tratamento de pedido de acesso a dados sobre - INTERNAL." + comunit.Icomblk.QCOMLIST[0].APP + "  - " + exp))
		return
	}
	oblk.gstatus="OK"
	if (sync == false) {
        comunit.Ocomblk=new Interblk()
        comunit.Ocomblk.QCOMLIST=new Array()
		//comunit.Ocomblk=new Array()
		comunit.Ocomblk.QCOMLIST.push(oblk)
		ComProcessResponse()
	} else {
		return oblk
	}
}

//******* Servidor Simulação
function SendReceiveSimul(comunit) {
	if (comunit == undefined) {
		var comunit=ComUnits[0]
        comunit.Ocomblk=new Comblk()
        comunit.Ocomblk.STAT="OK"
        comunit.Ocomblk.ONLINE="S"
		var sync=false
	} else {
		var sync=true
	}
    for (var i=0; i<comunit.Icomblk.QCOMLIST.length; i++) {
        var oblk=AcessoDBSimulado(comunit.Page, comunit.Icomblk.QCOMLIST[i].IDENT, comunit.Icomblk.QCOMLIST[i])
        oblk.gstatus="OK"
        if (sync == false) comunit.Ocomblk.QCOMLIST.push(oblk)
    }
	if (sync == false) {
		ComProcessResponse()
	} else {
		return oblk
	}
}


//*****************************************************************
//***                 Simulação de acesso a DB
//*****************************************************************
function AcessoDBSimulado(pag, ctlid, iblk) {
    var ctl=pag.GetCtl(ctlid)
    var oblk=new Interblk()
    oblk.FUNC=iblk.FUNC
    oblk.IDENT=iblk.IDENT
    var rnd=Math.random()
    if (iblk.FUNC == "GET" || iblk.FUNC == "GETP" || iblk.FUNC == "GETNIVELTREE") oblk.DADOS = GetRecs(ctl, Math.floor(rnd * 14 + 1), iblk)
    if (iblk.FUNC == "GET1") oblk.DADOS = GetRecs(ctl, 1, iblk)
    if (iblk.FUNC == "GETU") oblk.DADOS = GetRecs(ctl, 1, iblk)
    if (iblk.FUNC == "INS") oblk.DADOS = iblk.DADOS
    if (iblk.FUNC == "ELI") oblk.DADOS = ""
    if (iblk.FUNC == "ALT") oblk.DADOS = iblk.DADOS
    if (iblk.FUNC == "EXR") oblk.DADOS = GetRecs(ctl, 1, iblk)
    if (iblk.FUNC == "EXW") oblk.DADOS = iblk.DADOS
    oblk.STAT="OK"
    return oblk
}

//******* Simular registos
function GetRecs(ctl, nrecs, iblk) {
    var rtxt="Lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur"
    var cols=ctl.Cols
    var dados=""
    var dados=new Array()
    var wrec=new Array()
    var colsped="," + iblk.CMPS.toString() + ","
    for (var r=0; r<nrecs; r++) {
        wrec=new Array()
        for (var i=0; i<cols.length; i++) {
            if (colsped.indexOf("," + cols[i].Id + ",") != -1) { 
                var rnd=Math.random()
                if (cols[i].Type == "A") {
                    var rini=Math.floor(rnd * 300)
                    if (cols[i].Comp == -1) {
                        var rlen=Math.floor(rnd * 5 + 1)
                    } else {
                        var rlen=Math.floor(rnd * (cols[i].Comp - 1) + 1)
                    }
                    wrec.push(rtxt.substr(rini, rlen))
                }
                if (cols[i].Type == "N" || cols[i].Type == "$") {
                    var wcomp=cols[i].Comp-1
                    if (wcomp < 0) wcomp = 5
                    if (wcomp > 2) wcomp = wcomp - 1
                    if (wcomp > 4) wcomp = wcomp - 2
                    var fact=Math.pow(10,wcomp)
                    var valor=Math.floor(rnd * fact)
                    if (cols[i].Dec > 0) valor += "." + "0000000".substr(0,cols[i].Dec)
                    wrec.push("" + valor)
                }
                if (cols[i].Type == "D") {
                    var dia="" + Math.floor(rnd * 27 + 1)
                    if (dia.length == 1) dia="0" + dia
                    rnd=Math.random()
                    var mes="" + Math.floor(rnd * 11 + 1)
                    if (mes.length == 1) mes="0" + mes
                    rnd=Math.random()
                    var ano=Math.floor(rnd * 60) + 1945
                    wrec.push(dia + "/" + mes + "/" + ano)
                }
                if (cols[i].Type == "H") {
                    var dia="" + Math.floor(rnd * 27 + 1)
                    if (dia.length == 1) dia="0" + dia
                    rnd=Math.random()
                    var mes="" + Math.floor(rnd * 11 + 1)
                    if (mes.length == 1) mes="0" + mes
                    rnd=Math.random()
                    var ano=Math.floor(rnd * 60) + 1945
                    wrec.push(dia + "/" + mes + "/" + ano + " 10:23")
                }
                if (cols[i].Type == "S") {
                    var dia="" + Math.floor(rnd * 27 + 1)
                    if (dia.length == 1) dia="0" + dia
                    rnd=Math.random()
                    var mes="" + Math.floor(rnd * 11 + 1)
                    if (mes.length == 1) mes="0" + mes
                    rnd=Math.random()
                    var ano=Math.floor(rnd * 60) + 1945
                    wrec.push(dia + "/" + mes + "/" + ano + " 10:23:48")
                }
                if (cols[i].Type == "T") {
                    var hh="" + Math.floor(rnd * 23)
                    if (hh.length == 1) hh="0" + hh
                    rnd=Math.random()
                    var mm="" + Math.floor(rnd * 59)
                    if (mm.length == 1) mm="0" + mm
                    wrec.push(hh + ":" + mm)
                }
                if (cols[i].Type == "B") {
                    if (rnd > .4999) {
                        wrec.push("1")
                    } else {
                        wrec.push("0")
                    }
                }
            }
        }
        dados.push(wrec)
    }
    if (nrecs == 0) {
        wrec=new Array()
        for (var i=0; i<cols.length; i++) {
            wrec.push("")
        }
        dados.push(wrec)
    }
    return dados
}


//*********************************************
//*********************************************
//*   Conversões / Validações / Formatações
//*********************************************
//*********************************************

//******* Formatar valores consoante o tipo
function FormatCol(col, valor, dest) {
	switch (col.Type) {
		case "A":
			return valor
		case "N":
			return FormatNumber(valor, col.Dec, dest)
		case "$":
			return FormatDinheiro(valor, col.Dec, dest)
		case "D":
			return FormatDate(valor, dest)  //data com ano, mes e dia
		case "H":
			return FormatDateH(valor, dest)  //data com horas e minutos
		case "B":
			return FormatBoolean(valor, dest)
		case "T":
			return FormatHora(valor, dest)  //horas e minutos
        case "S":
            return FormatDateHS(valor, dest)  //data com horas, minutos e segundos
		default:
			return valor
	}
}

//******* Formatar valores numericos com as decimais
function FormatNumber(valor, decimais, dest) {
    valor="" + valor
	var sepdec=User.SepDec
	var sep1000=User.Sep1000
	if (dest == "server") {
		sepdec=","
		sep1000=""
		valor=valor.replace(App.Currency, "")
	}
	var re=/ /g
	valor=valor.replace(re, "")
	var re=/\./g
	valor=valor.replace(re, "")
	var negativo=false
	if (valor.substr(0,1) == "-") {
		negativo=true
		valor=valor.substr(1)
	}
	var Aw = valor.split(",")
	if (Aw[0] == "") Aw[0] = "0"
	if (decimais >= 0) {   //formatar milhares
		var w=""
		var len=Aw[0].length - 1
		for (var i=0; i<Aw[0].length; i++) {
			if (i==3 || i==6 || i==9 || i==12) w = sep1000 + w 
			w= Aw[0].substr(len-i, 1) + w
		}
		Aw[0]=w
	}
	if (decimais > 0) {
		if (Aw[1] == undefined) Aw[1]=""
		Aw[1] += "000000000000000"
		var vround=Aw[1].substr(decimais, 1)
		Aw[1]=Aw[1].substr(0,decimais)
		if (vround > "5") {
			Aw[1]="" + (Number("1" + Aw[1]) + 1)
			if (Aw[1].substr(0,1) == "2") Aw[0]="" + (Number(Aw[0]) + 1)
			Aw[1]=Aw[1].substr(1)
		}
		var wval=Aw[0] + sepdec + Aw[1]
	} else {
		var wval=Aw[0]
	}
	if (negativo == true) wval = "-" + wval
	return wval	
}

//******* Formatar valores em dinheiro com as decimais
function FormatDinheiro(valor, decimais, dest) {
	valor=valor.replace(App.Currency, "")
	var wval=FormatNumber(valor, decimais, dest)
	if (dest != "server") wval = App.Currency + wval
	return wval	
}

//******* Formatar horas
function FormatHora(whora, dest, opt) {
    var formatd=User.DateFmt
	var format=User.DateFmt
	if (dest == "server") format="24"
	if (whora == null) {
        if (opt == "SECONDS") return "__:__:__"
        return "__:__"
    }
	if (User.TimeFmt == "24") return whora
	var Aw=whora.split(":")
    var hh = Number(Aw[0])
    if (isNaN(hh) || Aw[0] == null || Aw[0] == "")
        hh = "__"
	var ap=""
	if (hh > 12) {
		ap="PM"
		hh="" + (hh - 12)
		if (hh.length < 2) hh="0" + hh
	} else {
		ap="AM"
		hh="" + hh
		if (hh.length < 2) hh="0" + hh
	}
    if (opt == "SECONDS") {
        return hh + ":" + Aw[1] + ":" + Aw[2] + ap
    } else
    {
        var mm = Number(Aw[1])
        if (isNaN(mm) || Aw[1] == null || Aw[1] == "")
            mm = "__";
		//RMR(2018-10-10) - Correct format when the minutes are lesse then 10 (AM/PM)
		mm = "" + mm;
        if (mm.length < 2) mm = "0" + mm
        return hh + ":" + mm + ap
    }
}


//******* Formatar Booleanos
function FormatBoolean(valor, dest) {
	return "" + valor	
}

//******* Formatar datas
function FormatDate(wdata, dest) {
	var format=User.DateFmt
	if (dest == "server") format="DMA"
	if (format == "DMA") {
		if (wdata == null) return "__/__/____"
		return wdata
	}
	if (wdata != null){
	    var dd = wdata.substr(0, 2)
	    var mm = wdata.substr(3, 2)
	    var aa = wdata.substr(6, 4)

	    //RMR(2016-12-19) - In case the first 3 caracters do not have a /, means that it is the year part.
        //This verification is not made through the format, because the the dates are received in both DMA and AMD regardless the culture format
	    if (wdata.substr(0, 3).indexOf('/') == -1)
	    {
	        var aa = wdata.substr(0, 4)
	        var mm = wdata.substr(5, 2)
	        var dd = wdata.substr(8, 2)
	    }
	}
	if (format == "MDA") {
		if (wdata == null) return "__/__/____"
		if (wdata == "") return ""
		return mm + "/" + dd + "/" + aa
	}
	if (format == "AMD") {
		if (wdata == null) return "____/__/__"
		if (wdata == "") return ""
		return aa + "/" + mm + "/" + dd
	}
}

//******* Formatar data / hora
function FormatDateH(wdata, dest) {
	var Aw=wdata.split(" ")
	var wd=FormatDate(Aw[0], dest)
	var wh=FormatHora(Aw[1], dest)
	return wd + " " + wh
}

//******* Formatar data / hora
function FormatDateHS(wdata, dest) {
    var Aw=wdata.split(" ")
    var wd=FormatDate(Aw[0], dest)
    var wh=FormatHora(Aw[1], dest, "SECONDS")
    return wd + " " + wh
}

//******* Formatar data a partir de uma date
function FormatFromDate(wdate, dest) {
	var format=User.DateFmt
	if (dest == "server") format="DMA"
	if (wdate == null || wdate == "" || wdate == "__/__/____") {
		if (dest == "server") return ""
		if (format == "AMD") return "____/__/__"
		return "__/__/____"
	}
	var dd = "" + wdate.getUTCDate()
	if (dd.length < 2) dd = "0" + dd
	var mm = "" + (wdate.getUTCMonth() + 1)
	if (mm.length < 2) mm = "0" + mm
	var aa = "" + wdate.getUTCFullYear()
	if (format == "DMA") return dd + "/" + mm + "/" + aa
	if (format == "MDA") return mm + "/" + dd + "/" + aa
	if (format == "AMD") return aa + "/" + mm + "/" + dd
}


//******* Formatar data / hora a partir de uma date
function FormatFromDateH(wdate, dest, opt) {
	var formath=User.TimeFmt
	//RMR(2016-12-20) - Needs to get the culture of this user, so that it applies the correct format for the interfaces
	var formatd = User.DateFmt
	if (dest == "server") formatd="DMA"
	if (wdate == null) {
		if (dest == "server") return ""
		if (formatd == "AMD") {
            var w="____/__/__ __:__"
            if (opt == "SECONDS") w += ":__"
            if (formath != "24") w += "AM"
            return w
		}
        var w="__/__/____ __:__"
        if (opt == "SECONDS") w += ":__"
        if (formath != "24") w += "AM"
        return w
	}
	var dd = "" + wdate.getUTCDate()
	if (dd.length < 2) dd = "0" + dd
	var mm = "" + (wdate.getUTCMonth() + 1)
	if (mm.length < 2) mm = "0" + mm
	var aa = "" + wdate.getUTCFullYear()
	var wd=""
	if (formatd == "DMA") wd=dd + "/" + mm + "/" + aa
	if (formatd == "MDA") wd=mm + "/" + dd + "/" + aa
	if (formatd == "AMD") wd=aa + "/" + mm + "/" + dd
	
	var hh = wdate.getUTCHours()
	var ap=""
	//RMR(2016-12-20) - Only converts to the 12 hour format when showing in the interface
	if (formath == "12" && dest == "user") {
		if (hh > 12) {
			hh=hh-12
			ap="PM"
		} else {
			ap="AM"
		}
	}
	hh="" + hh
	if (hh.length < 2) hh="0" + hh
	var mm = wdate.getUTCMinutes()
	mm="" + mm
	if (mm.length < 2) mm="0" + mm
    if (opt == "SECONDS") {
        var ss = wdate.getUTCSeconds()
        ss="" + ss
        if (ss.length < 2) ss="0" + ss
        return wd + " " + hh + ":" + mm + ":" + ss + ap
    }
	return wd + " " + hh + ":" + mm + ap
}


//******* Formatar e validar input com Mascara
// 0=numerico obrigatorio
// L=letra obrigatoria
// &=caracter obrigatorio
// Q=sinais de condição:  =  >  <  ! ou espaço
function FormatMask(texto, mask, posi) {
	if (posi == undefined) posi=0
	var textoout=""
	var posinew=posi
	texto += "                             "
	for (var i=0; i<mask.length; i++) {
		bmask=mask.substr(i,1)
		btext=texto.substr(i,1)
		switch (bmask) {
			case "0":
				if ("0123456789_".indexOf(btext) == -1) {
					textoout += "_"
				} else {
					textoout += btext
					if (i == posi) posinew = posi + 1
				}
				break
			case "L":
				if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_".indexOf(btext) == -1) {
					textoout += "_"
				} else {
					textoout += btext
					if (i == posi) posinew = posi + 1
				}
				break
			case "&":
                /*
				if ("[{".indexOf(btext) != -1) {
					textoout += "_"
				} else {
                */
					textoout += btext
					if (i == posi) posinew = posi + 1
				//}
				break
			default:
				textoout += bmask
				if (i == posi) posinew = posi + 1
				if (i == posinew) posinew++
				break
		}
	}
	var vout=new Object()
	vout.Texto=textoout
	vout.Posi=posinew
	return vout
}


//******* Validar conforme o tipo
function ValidarCol(col, valor, obrig) {
	switch (col.Type) {
		case "A":
			return ValidarAlfa(col, valor, obrig)
		case "N":
			return ValidarNumber(col, valor, obrig)
		case "$":
			return ValidarDinheiro(col, valor, obrig)
		case "D":
			return ValidarDate(col, valor, obrig)
		case "H":
			return ValidarDate(col, valor, obrig)
        case "S":
            return ValidarDate(col, valor, obrig)
		case "T":
			return ValidarTime(col, valor, obrig)
		case "B":
			return ValidarBoolean(col, valor, obrig)
		default:
			return ValidarAlfa(col, valor, obrig)
	}
}

function ValidarAlfa(wcol, valor, obrig) {
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (wcol.Comp > 0) {
		if (valor.length > wcol.Comp) return GetMsg(18, wcol.Tit)
	}
	return ""
}

function ValidarNumber(wcol, valor, obrig) {
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (valor == "") valor = "0"
	var wval=ConvertToNumber(valor)
	if (wval == null) return GetMsg(19, wcol.Tit)
	if (wcol.Comp > 0) {
		var wi="" + Math.floor(wval)
		if (wi.length > wcol.Comp) return GetMsg(20, wcol.Tit)
	}
	return ""
}

function ValidarDinheiro(wcol, valor, obrig) {
	var re=/ /g
	valor=valor.replace(re, "")
	valor=valor.replace(App.Currency, "")
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (valor == "") valor = "0"
	var wval=ConvertToNumber(valor)
	if (wval == null) return GetMsg(19, wcol.Tit)
	if (wcol.Comp > 0) {
		var wi="" + Math.floor(wval)
		if (wi.length > wcol.Comp) return GetMsg(20, wcol.Tit)
	}
	return ""
}


function ValidarDate(wcol, valor, obrig) {
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (valor == "") return ""
	var wval=ConvertToDate(valor)
	if (wval == null) return GetMsg(21, wcol.Tit)
	return ""
}

function ValidarTime(wcol, valor, obrig) {
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (valor == "") return ""
	var i=valor.indexOf(":")
	if (i != 2) return GetMsg(22, wcol.Tit)
	var hh=valor.substr(0,2)
	var mm=valor.substr(3)
	if ((hh == "  " || hh == "__" || hh == "") && (mm == "  " || mm == "__" || mm == "")) {
		if (obrig == "OBRIG" && wcol.Obrig == "S") {
			return GetMsg(17, wcol.Tit)
		} else {
			return ""
		}
	}
	if ("0123456789".indexOf(hh.substr(0,1)) == -1 || "0123456789".indexOf(hh.substr(1,1)) == -1 || "0123456789".indexOf(mm.substr(0,1)) == -1 || "0123456789".indexOf(mm.substr(1,1)) == -1) return wcol.Tit + " - hora inválida"
	var hhv=parseInt(hh)
	var mmv=parseInt(mm)
	if (isNaN(hhv) || isNaN(mmv)) return GetMsg(22, wcol.Tit)
	if (hhv < 0 || hhv > 23 || mmv < 0 || mmv > 59) return GetMsg(22, wcol.Tit)
	return ""
}

function ValidarBoolean(wcol, valor, obrig) {
	if (obrig == "OBRIG") {
		if (wcol.Obrig == "S" && valor == "") return GetMsg(17, wcol.Tit)
	}
	if (valor == "") return ""
	if (valor == "0" || valor == "1") return ""
	return GetMsg(19, wcol.Tit)
}


function ConvertNumeroToSrv(wval) {
	var w=wval
	var re=/ /g
	w=w.replace(re, "")
	if (User.Sep1000 == ",") {
		var re=/,/g
		w=w.replace(re, "")
	}
	if (User.Sep1000 == ".") {
		var re=/\./g
		w=w.replace(re, "")
	}
	if (User.SepDec == ".") {
		var re=/\./g
		w=w.replace(re, ",")
	}
	var re=/[^0-9\-\+\.,]/g
	w=w.replace(re, "")
	return w
}

function ConvertDataToSrv(wval) {
    if (wval == "") return ""
	wval=wval.replace(/-/g, "/")
	wval = wval.replace(/[^0-9\/\s:]/g, "")
	var Aw=wval.split(" ")
	var Aw = Aw[0].split("/")
	if (User.DateFmt != "DMA") {
		if (User.DateFmt == "MDA") return Aw[1] + "/" + Aw[0] + "/" + Aw[2]
		if (User.DateFmt == "AMD") return Aw[2] + "/" + Aw[1] + "/" + Aw[0]	
	} else {
		return Aw[0] + "/" + Aw[1] + "/" + Aw[2]
	}
}

function ConvertDataHToSrv(wval) {
	if (wval == "") return ""
	var Aw=wval.split(" ")
	var wdata=ConvertDataToSrv(Aw[0])
	var whora=ConvertHoraToSrv(Aw[1])
	return wdata + " " + whora
}

function ConvertHoraToSrv(wval) {
	if (wval == "__:__") wval="00:00"
	if (wval == "__:____") wval="00:00AM"
	var w=wval
	var re=/[^0-9APMapm:]/g
	w=w.replace(re, "")
	if (User.TimeFmt == "12") {
		var w=wval
		var i=w.indexOf("AM")
		if (i>-1) {
			w=w.substr(0, i)
			return w
		}
		var i=w.indexOf("PM")
		if (i>-1) {
			w=w.substr(0, i)
			var Aw=w.split(":")
			var hh=Number(Aw[0])
			hh=hh+12
			return hh + ":" + Aw[1]
		}
	}
	return wval
}


function ConvertBooleanToSrv(wval) {
	return wval
}

function ConvertToNumber(wval) {
	if (wval.indexOf("..") > -1 || wval.indexOf(",,") > -1 || wval.indexOf(",.") > -1 || wval.indexOf(".,") > -1) return null
	var re=/ /g
	wval=wval.replace(re, "")
    var re=/\./g
    wval=wval.replace(re, "")
	var i=wval.indexOf("-")
	if (i > 0) return null
	var i=wval.indexOf(",")
	if (i != -1) wval = wval.substr(0, i) + "." + wval.substr(i + 1)
	if (wval.search(/[^0-9.+-]/) > -1) return null
	var v=parseFloat(wval)
	if (isNaN(v)) return null
	return v
}


function ConvertToDate(wval) {
	var wano=""
	var wmes=""
	var wdia=""
	var whor=0
	var wmin=0
	var wseg=0
	if (wval == null || wval == undefined) return null
	var Adh=wval.split(" ")
	if (Adh[0] == "" || Adh[0] == null) return null
	if (wval.search(/[^0-9\-\/:\s]/) > -1) return null
	var isep=Adh[0].indexOf("/")
	if (Adh[0].indexOf("/") != -1) {
		var Adma=Adh[0].split("/")
	} else {
		if (Adh[0].indexOf("-") != -1) {
			var Adma=Adh[0].split("-")
		} else {
			return null
		}
	}
	if (Adma.length != 3) return null
	if (Adma[0].length == 4) {
		wano=Adma[0]
		wmes=Adma[1]
		wdia=Adma[2]
	} else {
		wano=Adma[2]
		wmes=Adma[1]
		wdia=Adma[0]
	}
	wano=parseInt(wano,10)
	if (isNaN(wano)) return null
	if (wano < 100) {
		if (wano >= 50) {
			wano = 1900 + wano	
		} else {
			wano = 2000 + wano
		}
	}
	if (wano < 1800 || wano > 2070) return null
	wmes=parseInt(wmes,10)
	if (isNaN(wmes)) return null
	if (wmes < 1 || wmes > 12) return null
	wdia=parseInt(wdia,10)
	if (isNaN(wdia)) return null
	if (wdia < 1 || wdia > 31) return null
	if (wmes == 4 || wmes == 6 || wmes == 9 || wmes == 11) {
		if (wdia > 30) return null
	}
	if (wmes == 2) {
		if ((wano / 4) == (Math.floor(wano / 4))) {
			if (wdia > 29) return null
		} else {
			if (wdia > 28) return null
		}
	}
	if (Adh[1] != "" && Adh[1] != null) {
		if (Adh[1] == "__:__") Adh[1]="00:00"
		if (Adh[1] == "__:____") Adh[1]="00:00AM"
        if (Adh[1] == "__:__:__") Adh[1]="00:00:00"
        if (Adh[1] == "__:__:____") Adh[1]="00:00:00AM"
		Adh[1] = Adh[1].toUpperCase()
		var wpm=0
        var ix=Adh[1].indexOf("AM");
        if (ix > 0) {
            Adh[1]=Adh[1].substr(0,ix)
        }
        var ix=Adh[1].indexOf("PM");
        if (ix > 0) {
            Adh[1]=Adh[1].substr(0,ix)
            wpm=12
        }
		var Ahms=Adh[1].split(":")
		whor=Ahms[0]
		whor=parseInt(whor,10)
		if (isNaN(whor)) return null
		whor=whor + wpm
		if (whor < 0 || whor > 23) return null
		if (Ahms.length > 0) {
			wmin=Ahms[1]
			wmin=parseInt(wmin,10)
			if (isNaN(wmin)) return null
			if (wmin < 0 || wmin > 59) return null
		}
		if (Ahms.length > 2) {
			wseg=Ahms[2]
			wseg=parseInt(wseg,10)
			if (isNaN(wseg)) return null
			if (wseg < 0 || wseg > 59) return null
		}
	}
	var v=Agora()
	v.setUTCFullYear(wano, wmes-1, wdia)
	v.setUTCHours(whor, wmin, wseg, 0)
	return v
}

function ConvertToBoolean(wval) {
	if (wval == "1") return 1
	return 0
}


//******* converter para o datatype correspondente ao tipo
function ConvertToNative(wval, wtype) {
	switch(wtype) {
		case "A":
			return wval
		case "N":
			if (wval == "") wval="0"
			return ConvertToNumber(wval)
		case "$":
			var re=/ /g
			wval=wval.replace(re, "")
			wval=wval.replace(App.Currency, "")
			if (wval == "") wval="0"
			return ConvertToNumber(wval)
		case "D":
			return ConvertToDate(wval)
		case "H":
			return ConvertToDate(wval)
        case "S":
            return ConvertToDate(wval)
		case "T":
			return ConvertHoraToSrv(wval)
		case "B":
		case "L":
			return ConvertToBoolean(wval)
	}
}

//******* converter do datatype correspondente ao tipo para string
function ConvertFromNative(wval, wtype, wdec) {
	switch(wtype) {
		case "A":
			return wval
		case "N":
		    var w = "" + ((wdec >= 0) ? wval.toFixed(wdec) : wval)
			var re=/\./g
			w=w.replace(re, ",")
			return FormatNumber(w, wdec, "server")
		case "$":
		    var w = "" + ((wdec >= 0) ? wval.toFixed(wdec) : wval)
			var re=/\./g
			w=w.replace(re, ",")
			return FormatDinheiro(w, wdec, "server")
		case "D":
			return FormatFromDate(wval, "server")
		case "H":
			return FormatFromDateH(wval, "server")
        case "S":
            return FormatFromDateH(wval, "server", "SECONDS")
		case "T":
			if (wval == null) return ""
			return wval
		case "B":
		case "L":
			return FormatBoolean(wval, "server")
	}
}

//******* devolver string com txtsearch substituido por txtreplace
function ReplaceText(wvar, txtsearch, txtreplace) {
	var w=wvar
	var len=txtsearch.length
	var ix=w.indexOf(txtsearch)
	while (ix > -1) {
		w = w.substr(0, ix) + txtreplace + w.substr(ix+len)
		ix=w.indexOf(txtsearch)
	}
	return w
}


//******* Substituir datas parametrizadas
function SubstData(wdt, wdtref, server) {
	if (wdt.indexOf("ano") == -1 && wdt.indexOf("mes") == -1 && wdt.indexOf("dia") == -1 && wdt.indexOf("tri") == -1 && wdt.indexOf("ult") == -1) return wdt
	var Aw=wdt.split("/")
	var wdia=Aw[0]
	var wmes=Aw[1]
	var wano=Aw[2]
	if (server == undefined) server = false
	if (wdtref == null || wdtref == undefined || wdtref == "") {
		var Hoje=Agora()
		if (server == true) Hoje.setTime(Hoje.getTime() + App.ServerTimeDif)
		var whano=Hoje.getUTCFullYear()
		var whmes=Hoje.getUTCMonth() + 1
		var whdia=Hoje.getUTCDate()
	} else {
		var Awr=wdtref.split("/")
		var whdia=Number(Awr[0])
		var whmes=Number(Awr[1])
		var whano=Number(Awr[2])
	}
	var v=GetValSomarData(wano)
	if (v == null) {
		if (wano == "ano") {
			wano=whano
		} else {
			wano=Number(wano)
		}
	} else {
		wano=whano + v
	}
	var v=GetValSomarData(wmes)
	if (v == null) {
		if (wmes == "mes") {
			wmes=whmes
		} else {
			if (wmes == "tri") {
				if (whmes < 4) wmes=1
				if (whmes > 3 && whmes < 7) wmes=4
				if (whmes > 6 && whmes < 10) wmes=7
				if (whmes > 9) wmes=10
			} else {
				wmes=Number(wmes)
			}
		}
	} else {
		if (wmes.substr(0, 3) == "tri") {
			if (whmes < 4) wmes=1
			if (whmes > 3 && whmes < 7) wmes=4
			if (whmes > 6 && whmes < 10) wmes=7
			if (whmes > 9) wmes=10
			wmes=wmes + v
		} else {
			if (wmes.substr(0, 3) == "mes") wmes=whmes + v
		}
	}
	var v=GetValSomarData(wdia)
	if (v == null) {
		if (wdia == "dia") {
			wdia=whdia
		} else {
			if (wdia == "ult") {
				wdia=GetUltDiaMes(wmes, wano)
			} else {
				if (wdia != "dia" && wdia != "ult") wdia=Number(wdia)
			}
		}
	} else {
		if (wdia.substr(0, 3) == "ult") {
			wdia=GetUltDiaMes(wmes, wano) + v
		} else {
			if (wdia.substr(0, 3) == "dia") {
				wdia=whdia + v
			} else {
				wdia=Number(wdia)
			}
		}
	}
	var wult=GetUltDiaMes(wmes, wano)
	if (wdia > wult) {
		wmes = wmes + 1
		wdia = wdia-wult
	}
	if (wmes > 12) {
		wmes=1
		wano=wano+1
	}
	wmes="" + wmes
	if (wmes.length < 2) wmes = "0" + wmes
	wdia="" + wdia
	if (wdia.length < 2) wdia = "0" + wdia
	return wdia + "/" + wmes + "/" + wano
}

//******* obter valor a somar ou subtrair a partes da data
function GetValSomarData(w) {
	if (w.length < 5) return null
	var op = w.substr(3,1)
	var val = Number(w.substr(4))
	if (op == "-") return -val
	return val	
}

//******* obter o ultimo dia do mes
function GetUltDiaMes(wmes, wano) {
	if (wmes == 1 || wmes == 3 || wmes == 5 || wmes == 7 || wmes == 8 || wmes == 10 || wmes == 12) return 31
	if (wmes == 4 || wmes == 6 || wmes == 9 || wmes == 11) return 30
	if (wmes == 2) {
		if (wano / 4 == Math.floor(wano / 4)) {
			return 29
		} else {
			return 28
		}	
	}
}


//******* Obter string de condição segura para enviar em comando
function CondEncode(w) {
	var wt=w
	var re=/{/g
	wt=wt.replace(re,"|")
	var re=/\[/g
	wt=wt.replace(re,";")
	return wt
}

//******* Obter string de condição descodificada para execução
function CondDecode(w) {
	var wt=w
	var re=/\|/g
	wt=wt.replace(re,"{")
	var re=/;/g
	wt=wt.replace(re,"[")
	return wt
}
