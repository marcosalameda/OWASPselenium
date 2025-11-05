using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Xml;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using GenioServer.security;
using System.Web;
using System.Web.Security;

namespace CSGenio
{
    /// <summary>
    /// Summary description for InterfaceXml
    /// </summary>
    public static class InterfaceXml
    {

        private static QcomBlk respondeQcomBlk(List<Comunicacao> pedidosComunicacao, string loginSessao, string lang)
        {
            QcomBlk blk = new QcomBlk();
            blk.Stat = Status.OK.ToString();
            blk.Ses = loginSessao;
            blk.QcomList = new List<Qcom>();
            blk.Online = "";
            blk.Lang = lang;

            foreach (Comunicacao resposta in pedidosComunicacao)
        {
                Qcom reply = resposta.ToQcom();
                if (resposta.Status.Equals(Status.E))
                    blk.Stat = Status.E.ToString();
                blk.QcomList.Add(reply);
            }

            return blk;

        }

        /// <summary>
        /// Método to processar os pedidos vindo da interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static QcomBlk processRequest(ISessao session, QcomBlk xml, string userLocation)
        {
            List<Comunicacao> pedidosComunicacao = new List<Comunicacao>();

            //XmlDocument document = new XmlDocument();
            //document.LoadXml(xml);
            Comunicacao comunicacao = null;
            bool transaccaoAberta = false;
            bool conexaoAberta = false;
            PersistentSupport sp = null;
            User user = null;
            object utilizadorObj = session.User;
            string LinguaActual = xml.Lang;

            IDisposable loggerScope = null;
            if (session.User != null)
                loggerScope = Log.SetContext(new { user = session.User.Name });

            string loginSessao;
            loginSessao = xml.Ses;
            foreach (Qcom pedido in xml.QcomList)
            {
                try
                {
                    //comunicacao = new Comunicacao(pedido.Attributes["APP"].InnerText, pedido.Attributes["IDENT"].InnerText, pedido.Attributes["FUNC"].InnerText, pedido.Attributes["COND"].InnerText, pedido.Attributes["ORD"].InnerText, pedido.Attributes["CMPS"].InnerText, pedido.Attributes["DADOS"].InnerText, pedido.Attributes["MSG"].InnerText, pedido.Attributes["STAT"].InnerText, pedido.Attributes["MOD"].InnerText, pedido.Attributes["OPT"].InnerText, pedido.Attributes["FICH"].InnerText);
                    //comunicacao = new Comunicacao(pedido.App, pedido.Ident, pedido.Func, pedido.Cond, pedido.Ord, pedido.Cmps, pedido.Dados, pedido.Msg, pedido.Stat, pedido.Mod, pedido.Opt, pedido.Fich);
                    comunicacao = new Comunicacao(pedido);
                    if (pedido.Year == "0" && !Configuration.Years.Contains(pedido.Year)) // Se Qyear não estiver escolhido, vem com Qvalue "0"
                        pedido.Year = Configuration.DefaultYear;
                    if (utilizadorObj != null)
                        ((User)utilizadorObj).Year = pedido.Year;

                    //verificar se a função é válida, isto é se não é null, nem vazia ou tem um Qvalue diferente
                    //validate a estrutura dos dados se o identifier vem com o identifier do controlo e
                    //o Qvalue do nível.
                    if (!comunicacao.isTipoFuncaoValida() || !comunicacao.valEstComunicacao())
                        comunicacao = comunicacao.constroiRespostaErro("Pedido Inválido.", user.Language);
                    else
                    {
                        if (comunicacao.FunctionType.Equals(FunctionType.EXR))//se é procedimento de leitura
                            comunicacao = pedidosEXR(session, comunicacao, utilizadorObj, userLocation);
                        else
                        {
                            if (utilizadorObj == null || (session.UseAuthenticationTicket && !session.IsAuthenticationTicketValid()))
                            {
                                //AV 20090408 - Se é um pedido de logon e não exists Session é porque as cookies estão bloqueadas,
                                //se é pedido de logon o user é público e não precisa da session
                                if (comunicacao.Aplicacao.ToUpper().Equals("LOGON") && !Configuration.LoginType.Equals(Configuration.LoginTypes.AD) && !loginSessao.Equals("") && !loginSessao.StartsWith("*"))
                                    throw new BusinessException("Tem que permitir o uso de cookies para aceder a este portal.", "Interface.aspx.cs", "Tem que permitir o uso de cookies para aceder a este portal.");
                                else
                                    user = perdaSessao(session, utilizadorObj, comunicacao, userLocation,ref loginSessao);
                                    user.Language = LinguaActual;
                                if (loginSessao.StartsWith("*") && !comunicacao.Aplicacao.ToUpper().Equals("LOGON"))
                                    throw new BusinessException("Sessão caducada", "Interface.aspx.cs", "Sessão caducada.");
                            }
                            else
                            {
                                user = (User)utilizadorObj;
                                if (loginSessao.StartsWith("*") && !comunicacao.Aplicacao.ToUpper().Equals("LOGON"))
                                {
                                    pedidosComunicacao.Add(comunicacao.constroiRespostaSucesso("Sessão caducada", Status.VAZ, user.Language));
                                    continue;
                                }
                            }
                            user.CurrentModule = comunicacao.Module;
                            user.Language = LinguaActual;

                            bool shadow = false;
                            if (!conexaoAberta)
                            {
                                if (!string.IsNullOrEmpty(comunicacao.BD))
                                    sp = PersistentSupport.getPersistentSupportAux(comunicacao.BD, user.Name);
                                else
                                    sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
                                sp.openConnection();
                                conexaoAberta = true;
                            }
                            if (comunicacao.FunctionType.Equals(FunctionType.EXW))//se é procedimento de escrita
							{
                                if (!transaccaoAberta)
                                {
                                    sp.openTransaction();
                                    transaccaoAberta = true;
                                    conexaoAberta = true;
                                }

                                comunicacao = pedidoEXW(session, comunicacao, user, sp, ref loginSessao);
							}
                            else if (comunicacao.FunctionType.Equals(FunctionType.FCT))//se é procedimento de escrita
                                comunicacao = pedidosFCT(session, comunicacao, user, sp);
                            else if (comunicacao.FunctionType.Equals(FunctionType.FCT2))//refactorização das mensagens FCT
                                comunicacao = pedidosFCT2(session, comunicacao, user, sp);
                            else
                            {

                                if (comunicacao.FunctionType.Equals(FunctionType.GET_NIVELTREE))
                                    comunicacao = pedidoGETNIVELTREE(session, comunicacao, user, sp);
                                else if (comunicacao.FunctionType.Equals(FunctionType.GET_MAIS) || comunicacao.FunctionType.Equals(FunctionType.GET_MENOS) ||
                                            comunicacao.FunctionType.Equals(FunctionType.GET_UM) || comunicacao.FunctionType.Equals(FunctionType.GET_UNICO) ||
                                            comunicacao.FunctionType.Equals(FunctionType.GET))
                                    comunicacao = pedidoGET(session, comunicacao, user, sp, comunicacao.FunctionType);
								else if(comunicacao.FunctionType.Equals(FunctionType.GET_ALTERNATIVE))
                                    comunicacao = pedidoGETAlternative(session, comunicacao, user, sp, comunicacao.FunctionType);
                                else if (comunicacao.FunctionType.Equals(FunctionType.GET_POS))
                                    comunicacao = pedidoGETPOS(session, comunicacao, user, sp);
                                else
                                {
                                    if (!transaccaoAberta)
                                    {
                                        sp.openTransaction();
                                        transaccaoAberta = true;
                                        conexaoAberta = true;
                                    }
                                    if (comunicacao.FunctionType.Equals(FunctionType.ALT))
                                        comunicacao = pedidoALT(comunicacao, user, shadow, sp);
                                    else if (comunicacao.FunctionType.Equals(FunctionType.INS))
                                        comunicacao = pedidoINS(comunicacao, user, shadow, sp);
                                    else if (comunicacao.FunctionType.Equals(FunctionType.DUP))
                                        comunicacao = pedidoDUP(user, comunicacao, shadow, sp);
                                    else if (comunicacao.FunctionType.Equals(FunctionType.ELI) || comunicacao.FunctionType.Equals(FunctionType.CAN))
                                        comunicacao = pedidoELI_CAN(comunicacao, user, shadow, sp);
                                    else if (comunicacao.FunctionType.Equals(FunctionType.ELI_INS_M))
                                        comunicacao = pedidoELI_INS_M(comunicacao, user, sp);

                                }
                            }
                        }
                    }
                    pedidosComunicacao.Add(comunicacao);
                }
				catch (Exception ex)
                {
                    if (sp != null && transaccaoAberta)
                    {
                        sp.rollbackTransaction();
                        transaccaoAberta = false;
                    }

					var exceptionUserMessage = "Pedimos desculpa, ocorreu um erro ao processar o seu pedido.";
					if (ex is GenioException)
					{
						if ((ex as GenioException).UserMessage != null)
							exceptionUserMessage = (ex as GenioException).UserMessage;
					}
					else
					{
						Log.Error(ex.ToString());
					}

                    pedidosComunicacao.Add(comunicacao.constroiRespostaErro(exceptionUserMessage, user.Language));
                }
            }

            if (sp != null)
                if (transaccaoAberta)
					sp.closeTransaction();
                else
                    sp.closeConnection();

            if(loggerScope != null)
                loggerScope.Dispose();

            return respondeQcomBlk(pedidosComunicacao, loginSessao, LinguaActual); //respondeXML(pedidosComunicacao, document,loginSessao);
        }

        /// <summary>
        /// Função to tratar os pedidos EXR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizadorObj">user em sessão</param>
        /// <returns>a resposta ao pedido</returns>
        private static Comunicacao pedidosEXR(ISessao session, Comunicacao comunicacao, object utilizadorObj, string location)
        {
            string function = comunicacao.Aplicacao.ToLower();
            {
                if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido EXR. [funcao] {0} [id] {1}",function,comunicacao.Identificador));
                switch (function)
                {
                    case "logon"://verifica se é a função de logon
                        {
                            Hashtable fields = new Hashtable();
                            fields.Add("anos", string.Join("|", Configuration.Years.ToArray()));
                            fields.Add("anodb", Configuration.DefaultYear);
                            EncryptPass.GetParameterRSA();
                            fields.Add("modulus", StringHelper.BytesToHexString(EncryptPass.Modulus()));
                            fields.Add("exponent", StringHelper.BytesToHexString(EncryptPass.exponent()));

                            if (utilizadorObj != null)//se já exists user em sessão, envia o login do mesmo
                            {
                                fields.Add("nome", ((User)utilizadorObj).Name);
                                return comunicacao.constroiRespostaSucesso(comunicacao.Utilizador2String(((User)utilizadorObj), ""), "Login bem sucedido", Status.OK, ((User)utilizadorObj).Language);
                            }
                            else
                            {
                                //user virtual
                                User user = new User("", session.SessionId, Configuration.DefaultYear, location);
                                session.User = user;
                            }
                            List<string[]> dadosEnviar = comunicacao.Campos2String(fields);
                            return comunicacao.constroiRespostaSucesso(dadosEnviar, "Preencha os campos e clique em 'Aceitar'", Status.OK, "");

                        }
                    case "logoff"://se a função for de logoff
                        {
                            string Qyear = Configuration.DefaultYear;
                            if (utilizadorObj != null)
                                Qyear = ((User)utilizadorObj).Year;

                            string[] res = new string[] { Qyear };
                            return comunicacao.constroiRespostaSucesso(res, "Ok para terminar a sessão", Status.OK, "");                            
                        }
                    case "password_alterar"://se a função for change password, valido se está logado
						{
                            if (((User)utilizadorObj).Public)//se já exists user em sessão, envia o login do mesmo
                                return comunicacao.constroiRespostaErro("O utilizador não está autenticado.", "");

                            string codpsw = "";
                            Criteria critKey = comunicacao.CondicaoSQL.FindCriteria(CSGenioApsw.FldCodpsw, CriteriaOperator.Equal, CriteriaSet.FindVariable.Any);
                            //caso a condição de limite da PSW esteja vazia então estamos a change a password do user logado
                            //esta situação resulta da dupla utilização do form e da lógica password_alterar
                            //isto porque o user logado pode estar a change a sua própria password
                            //ou entao pode estar a change a password de outra user através da Gestão de utilizadores (perfil administrador)
                            if (critKey == null || GenFunctions.emptyG(critKey.RightTerm) == 1)
                                codpsw = ((User)utilizadorObj).Codpsw;
                            else
                                codpsw = ConversaoQweb.ToString(critKey.RightTerm);

                            string[] res = new string[] { codpsw };
                            return comunicacao.constroiRespostaSucesso(res, "Insira a nova password", Status.OK, "");

                        }
                    case "password_gerar":
                        {
                            if (!((User)utilizadorObj).Public)//se já exists user em sessão, envia o login do mesmo
                                return comunicacao.constroiRespostaSucesso("Insira a nova password", Status.OK, "");
                            else
                                return comunicacao.constroiRespostaErro("O utilizador não está autenticado.", "");
                        }
                    default:
                        return comunicacao.constroiRespostaErro("Função não definida.", "");
                }
            }
        }

        /*/// <summary>
        /// Função to tratar os pedidos SRH (motor de pesquisa)
        /// </summary>
        /// <param name="session">sessão web</param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizadorObj">user em sessão</param>
        /// <param name="sp">suporte persistente</param>
        /// <returns>a resposta ao pedido</returns>
        private static Comunicacao pedidosSRH(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp)
        {
                        return comunicacao;
        }
        */

        /// <summary>
        /// Função to tratar os pedidos FCT
        /// </summary>
        /// <param name="session">sessão web</param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizadorObj">user em sessão</param>
        /// <param name="sp">suporte persistente</param>
        /// <returns>a resposta ao pedido</returns>
        private static Comunicacao pedidosFCT(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            String act = comunicacao.Message;
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido {0}_FILE. [id] {1} [aplicacao] {2}", act, comunicacao.Identificador, comunicacao.Aplicacao));

            char[] sepFicheiro = { '/' };
            string[] infoFicheiro = comunicacao.File.Split(sepFicheiro);
            // caminho do file
            string pathFich = null;
            // conteúdo do file
            byte[] fich = null;
            string[] msg = new string[1];

            if (act.ToLower() != "abrir")
            {
                //instanciação da area base
                DbArea area = (DbArea)Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);
                area.insertNamesFields(comunicacao.ArrayNomesCampos);
                area.selectOne(comunicacao.CondicaoSQL, comunicacao.OrdenacaoSQL, comunicacao.Identificador, sp);
                // name do Qfield do documento vem na terceira posição do array (indice 2)
                RequestedField docField = new RequestedField(comunicacao.ArrayNomesCampos[2], area.Alias);

                switch (act)
                {
                    case "Info":

                        msg[0] = area.infoDocum(sp, docField.Name).InfoDocQweb(user);
                        if (msg != null)
                            comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);

                        break;

                    case "Anexar":
                        // o name do file vem na primeira posição do array
                        pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + infoFicheiro[0]);
                        fich = File.ReadAllBytes(pathFich);
                        ApagaFicheiroDisco(pathFich);
                        area.insertNameValueFileDB(docField.Name, fich, infoFicheiro[0], "", sp, "", "");
                        // aqui chama o update direct to não aplicar regras de negócio, só se quer change a key to a table docums e o name do file
                        area.updateDirect(sp);
                        msg[0] = area.infoDocum(sp, docField.Name).InfoDocQweb(user);
                        if (msg != null)
                            comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);

                        break;
                    case "Vers":
                        string [] res = area.returnLastVersionDocum(sp, docField.Name);
                        if (res != null)
                        {
                            msg[0] = res[0] + "|" + res[1];
                            comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                        }
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
                        break;
                    case "DelU":
                        area.deleteLastDocums(sp, docField.Name);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                    case "DelH":
                        area.deleteHistoryDocums(sp, docField.Name);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                    case "Edit":
                        string newcodDocums = "";
                        if (!area.checkoutDocums(sp, docField.Name, out newcodDocums))
                            comunicacao.constroiRespostaErro("O ficheiro já está em edição. Espere que a nova versão seja submetida.", user.Language);
                        else
                        {
                            msg[0] = newcodDocums;
                            comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                        }

                        break;

                    case "Subm":
                        // na posição 0 do array vem o name do file
                        // na posição 1 do array vem o mode
                        // na posição 3 do array vem a versão
                        if (infoFicheiro[1] != "DESBL")
                        {
                            pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + infoFicheiro[0]);
                            fich = File.ReadAllBytes(pathFich);
                            ApagaFicheiroDisco(pathFich);
                        }
                        area.submitDocum(sp, docField.Name, fich, infoFicheiro[0], infoFicheiro[1], infoFicheiro[2]);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                    case "Remo":
                        if (area.removeDocums(sp, docField.Name))
                        {
                            // tem de se actualizar a area to remover as chaves
                            area.updateDirect(sp);
                            comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        }
                        else
                            comunicacao.constroiRespostaErro("Existem ficheiros em edição", user.Language);

                        break;
                }
            }
            else
            {
                //MF - 2014.03.10
                //Movi o abrir to fora do switch, porque este pedido não recebe informações de instância da área base
                //ou de fields da mesma. Como tal, não faz sentido estar dependente desses mesmos objectos. Desta forma,
                //o abrir pode ser igualmente reutilizado to pedidos fct no motor de pesquisa
                // Obtem o name do file
                SelectQuery qs = new SelectQuery()
                    .Select("docums", "nome")
                    .Select("docums", "versao")
                    .From("docums", "docums")
                    .Where(CriteriaSet.And()
                        .Equal("docums", "coddocums", infoFicheiro[0]))
                    .PageSize(1);

                ArrayList fields = sp.executeReaderOneRow(qs);

                if (fields.Count > 0)
                {
                    string nomeFich = "";
                    string name = (string)fields[0];
                    string Qversion = (string)fields[1];

                    int posPonto = name.LastIndexOf('.');

                    if (posPonto != -1)
                        nomeFich = name.Substring(0, posPonto) + name.Substring(posPonto);
                    else
                        nomeFich = name;

                    // constrói o ticket to download
                    Resource rec = new ResourceQuery(nomeFich, "docums", "document", "coddocums", infoFicheiro[0]);
                    // neste caso devolve-se apenas o conteudo do ticket, o controlo de ficheiros é responsavel por abrir o resource
                    //msg[0] = "ticket:" + QResources.CreateTicketEncryptedBase64(user.Name, user.Location, rec);
                    msg[0] = QResources.CreateTicketEncryptedBase64(user.Name, user.Location, rec);
                    comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                }
                else
                    comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
            }

            return comunicacao;
        }

        /// <summary>
        /// Função to tratar os pedidos FCT (refatorização)
        /// </summary>
        /// <param name="session">sessão web</param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizadorObj">user em sessão</param>
        /// <param name="sp">suporte persistente</param>
        /// <returns>a resposta ao pedido</returns>
        private static Comunicacao pedidosFCT2(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            String act = comunicacao.Message;
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido {0}_FILE. [id] {1} [aplicacao] {2}", act, comunicacao.Identificador, comunicacao.Aplicacao));

            char[] sepFicheiro = { '/' };
            string[] infoFicheiro = comunicacao.File.Split(sepFicheiro);
            // caminho do file
            string pathFich = null;
            // conteúdo do file
            byte[] fich = null;
            string[] msg = new string[1];
            List<string[]> msg2 = null;

            if (act.ToLower() != "abrir")
            {
                //instanciação da area base
                DbArea area = (DbArea)Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);
                string campoDocNome = comunicacao.GetScalarValoresCampos();
                area.insertNamesFields(new string[] { area.PrimaryKeyName, campoDocNome });

                //adicionar EPH's
                CriteriaSet recordPos = CriteriaSet.And().SubSet(comunicacao.CondicaoSQL).SubSet(Listing.CalculateConditionsEphGeneric(area, comunicacao.Identificador));

                //query
                area.selectOne(recordPos, comunicacao.OrdenacaoSQL, comunicacao.Identificador, sp); //<--- Isto está a assumir que a PK vem na condição?

                //verificar EPH's
                if(area.QPrimaryKey == null)
                    return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

                //verificar se o user tem realmente autorização to ler este registo
                if (area.AccessRightsToConsult(user))
                    return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

                switch (act)
                {
                    case "Info":

                        msg2 = ConversaoQweb.FromFicheiroBD(area.infoDocum(sp, campoDocNome), user);
                        if (msg2 != null)
                            comunicacao.constroiRespostaSucesso(msg2, "Dados para enviar", Status.OK, user.Language);
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
                        break;

                    case "Anexar":
                        // o name do file vem na primeira posição do array
                        pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + infoFicheiro[0]);
                        fich = File.ReadAllBytes(pathFich);
                        ApagaFicheiroDisco(pathFich);
                        area.insertNameValueFileDB(campoDocNome, fich, infoFicheiro[0], "", sp, "", "");
                        // aqui chama o update direct to não aplicar regras de negócio, só se quer change a key to a table docums e o name do file
                        area.updateDirect(sp);

                        msg2 = ConversaoQweb.FromFicheiroBD(area.infoDocum(sp, campoDocNome), user);
                        if (msg2 != null)
                            comunicacao.constroiRespostaSucesso(msg2, "Dados para enviar", Status.OK, user.Language);
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
                        break;

                    case "Vers":
                        string []res = area.returnLastVersionDocum(sp, campoDocNome);
                        if (res != null)
                            comunicacao.constroiRespostaSucesso(res, "Dados para enviar", Status.OK, user.Language);
                        else
                            comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
                        break;
                    case "DelU":
                        area.deleteLastDocums(sp, campoDocNome);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                    case "DelH":
                        area.deleteHistoryDocums(sp, campoDocNome);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                    case "Edit":
                        string newcodDocums = "";
                        if (!area.checkoutDocums(sp, campoDocNome, out newcodDocums))
                            comunicacao.constroiRespostaErro("O ficheiro já está em edição. Espere que a nova versão seja submetida.", user.Language);
                        else
                        {
                            msg[0] = newcodDocums;
                            comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                        }

                        break;

                        /*
                    case "Subm":
                        // na posição 0 do array vem o name do file
                        // na posição 1 do array vem o mode
                        // na posição 3 do array vem a versão
                        if (infoFicheiro[1] != "DESBL")
                        {
                            pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + infoFicheiro[0]);
                            fich = File.ReadAllBytes(pathFich);
                            ApagaFicheiroDisco(pathFich);
                        }
                        area.submitDocum(sp, campoDocNome, fich, infoFicheiro[0], infoFicheiro[1], infoFicheiro[2]);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        break;
                         */
                    case "Update":
                        {
                            string filename = comunicacao.GetRowValoresCampos()[1];
                            string version = comunicacao.GetRowValoresCampos()[2];
                            pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + filename);
                            fich = File.ReadAllBytes(pathFich);
                            ApagaFicheiroDisco(pathFich);

                            area.updateDocum(sp, campoDocNome, fich, filename, version);

                            comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        }
                        break;
                    case "Commit":
                        {
                            string filename = comunicacao.GetRowValoresCampos()[1];
                            string version = comunicacao.GetRowValoresCampos()[2];
                            pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp\\" + filename);
                            fich = File.ReadAllBytes(pathFich);
                            ApagaFicheiroDisco(pathFich);

                            area.commitDocum(sp, campoDocNome, fich, filename, version);

                            comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        }
                        break;
                    case "Discard":

                        area.discardDocum(sp, campoDocNome);
                        comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);

                        break;

                    case "Remo":
                        if (area.removeDocums(sp, campoDocNome))
                        {
                            // tem de se actualizar a area to remover as chaves
                            area.updateDirect(sp);
                            comunicacao.constroiRespostaSucesso("Dados para enviar", Status.OK, user.Language);
                        }
                        else
                            comunicacao.constroiRespostaErro("Existem ficheiros em edição", user.Language);

                        break;
                }
            }
            else
            {
                //MF - 2014.03.10
                //Movi o abrir to fora do switch, porque este pedido não recebe informações de instância da área base
                //ou de fields da mesma. Como tal, não faz sentido estar dependente desses mesmos objectos. Desta forma,
                //o abrir pode ser igualmente reutilizado to pedidos fct no motor de pesquisa
                // Obtem o name do file
                SelectQuery qs = new SelectQuery()
                    .Select("docums", "nome")
                    .Select("docums", "versao")
                    .From("docums", "docums")
                    .Where(CriteriaSet.And()
                        .Equal("docums", "coddocums", infoFicheiro[0]))
                    .PageSize(1);

                ArrayList fields = sp.executeReaderOneRow(qs);

                if (fields.Count > 0)
                {
                    string nomeFich = "";
                    string name = (string)fields[0];
                    string Qversion = (string)fields[1];

                    int posPonto = name.LastIndexOf('.');

                    if (posPonto != -1)
                        nomeFich = name.Substring(0, posPonto) + "_V" + Qversion + name.Substring(posPonto);
                    else
                        nomeFich = name + "_V" + Qversion;

                    // constrói o ticket to download
                    Resource rec = new ResourceQuery(nomeFich, "docums", "document", "coddocums", infoFicheiro[0]);
                    // neste caso devolve-se apenas o conteudo do ticket, o controlo de ficheiros é responsavel por abrir o resource
                    //msg[0] = "ticket:" + QResources.CreateTicketEncryptedBase64(user.Name, user.Location, rec);
                    msg[0] = QResources.CreateTicketEncryptedBase64(user.Name, user.Location, rec);
                    comunicacao.constroiRespostaSucesso(msg, "Dados para enviar", Status.OK, user.Language);
                }
                else
                    comunicacao.constroiRespostaErro("O ficheiro não existe!", user.Language);
            }

            return comunicacao;
        }

        /// <summary>
        /// Correctamente configura a sessão de acordo com as autorizações do user.
        /// Procura o primeiro Qyear onde este tem direito de entrar.
        /// Se não puder entrar em nenhum Qyear então configura o user publico.
        /// </summary>
        /// <param name="session">A sessão do user</param>
        /// <param name="utilizador">Os dados iniciais do user</param>
        /// <param name="principal">As autorizações do user vindas do processo de segurança</param>
        /// <returns>Um user correctametente preenchido</returns>
        /// <remarks>A sessão é modificada como efeito secundário desta função</remarks>
        private static User LoginFirstAvailableYear(ISessao session, User user)
        {
            //caso estamos a fazer um login num Qyear especifico também validamos se o user tem esse acesso
            if (user == null || (!string.IsNullOrEmpty(user.Year) && !user.Years.Contains(user.Year)))
            {
                user = new User("", session.SessionId, Configuration.DefaultYear, user.Location);
                user.Public = true;
                session.User = user;

                string error = "Login ou password incorretos.";
                throw new BusinessException(error, "InterfaceXml.pedidoEXW", error);
            }

            //o user entra no primeiro Qyear a que tem direito
            Exception lastException = null;
            bool sucess = false;
			foreach (string Qyear in Configuration.Years)
				if (user.Years.Contains(Qyear))
				{
					user.Year = Qyear;
					try
					{
						user = UserFactory.ReadEphs(user);
						sucess = true;
						break;
					}
					catch (Exception e)
					{
						lastException = e; //guarda a excepção e tenta o proximo Qyear
					}
				}


            //falhou em todos os anos e mostra aqui a ultima excepção
            //caso não tenhamos entrado em nenhum Qyear relançamos a excepção
            //entra aqui caso as autorizações nem tenham roles to nenhum Qyear
            if (!sucess)
            {
                user.Public = true;
                user.Year = Configuration.DefaultYear;
                if (lastException != null)
                    throw lastException;
                else
                    throw new BusinessException("O utilizador não pode aceder a nenhum módulo web.", "GlobalFunctions.logonEXW", "O utilizador não pode aceder a nenhum módulo web.");
            }
			
			//RMR(2018-11-13) - Identification of the user status in which his account is disabled for the default year, in order to block the login and show the user message
            if (user.Status == 2)
                throw new BusinessException("Este utilizador encontra-se desactivo. Por favor contacte o seu administrador.", "FuncoesGlobais.logonEXW", "Este utilizador encontra-se desactivo. Por favor contacte o seu administrador.");

            //suporte to single sign on
            foreach(var Qyear in user.Years)
                session.SetAuthenticationTicket(user.Name, Qyear);

            //o user é colocado em sessão
            session.User = user;

            if (Log.IsDebugEnabled) Log.Debug(string.Format("O utilizador iniciou a sessão. [utilizador] {0}", user.Name));
            return user;
        }

        /// <summary>
        /// Função to tratar pedidos EXW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizador"></param>
        /// <returns>a resposta ao pedido</returns>
        private static Comunicacao pedidoEXW(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp,ref string loginSessao)
        {
            string controlo = comunicacao.Identificador;
            string function = comunicacao.Aplicacao.ToUpper();
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido EXW. [funcao] {0} [id] {1}", function,controlo));
            switch (function)
            {
                case "AUTOLOGON"://se é a função de logon
                    {
						try
                        {
							user.Year = comunicacao.ArrayValoresCampos[0][3];
							user.Public = false;
							Credential credential = null;
							User principal = null;

							//Um autologon é sempre feito através de windows authentication
							//obter o login (tirar o dominio se existir)
							string login = session.UserLogin;
							int pos = login.IndexOf("\\");
							if (pos != -1)
								login = login.Substring(pos + 1);
							user.Name = login;
							List<string[]> argumentos = new List<string[]>();
							argumentos.Add(new string[] { login, "", "", user.Year, "", "", "N" });
							comunicacao.ArrayValoresCampos = argumentos;
							DomainCredential domainCredential = new DomainCredential();
							domainCredential.DomainUser = login;
							credential = domainCredential;

							credential.Year = user.Year; //TODO: remove this
							
							//RMR(2023-04-17) - If there is a cookie for the OpenId session, authenticates with its type
                            if (GenFunctions.emptyC(FormsAuthentication.FormsCookieName) == 0)
                            {
                                HttpCookie cook = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                                if (!(cook is null))
                                {
                                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cook.Value);
                                    if (!(ticket is null) && GenFunctions.emptyC(ticket.UserData) == 0)
                                    {
                                        string[] userDaraSession = ticket.UserData.Split(new string[] { "|+" }, StringSplitOptions.None);
                                        if (userDaraSession.Length == 3 && userDaraSession[2] == "OPENIDSESSION")
                                            credential = new TokenCredential() { Token = userDaraSession[1], Year = userDaraSession[0] };
                                    }
                                }
                            }

							principal = SecurityFactory.Authenticate(credential);

							user = LoginFirstAvailableYear(session, principal);

							loginSessao = user.Name;
							return comunicacao.constroiRespostaSucesso(comunicacao.Utilizador2String(user, ""), "Login bem sucedido", Status.OK, user.Language);
						}
                        catch (Exception ex)
                        {
                            Log.Error($"[AUTOLOGON] - {ex.Message}");
                        }

                        return comunicacao.constroiRespostaSucesso("", Status.E, user.Language);
                    }

                case "LOGON"://se é a função de logon
                    {
                        user.Year = comunicacao.ArrayValoresCampos[0][3];
                        user.Public = false;
						User principal = null;

                        //verificamos se já temos um token de sigle sign on
						if (session.UseAuthenticationTicket && session.IsAuthenticationTicketValid())
						{
                            principal = SecurityFactory.Authorize(new GenioIdentity()
                            {
                                Name = session.IdentityName,
                                IsAuthenticated = true,
                                IdProperty = GenioIdentityType.InternalId,
                                AuthenticationType = "internal"
                            });
                            principal.Year = comunicacao.ArrayValoresCampos[0][3];
						}
						else //senão constuímos as credenciais de acordo com o tipo de login
						{
	                        Credential credential = null;

	                        if (Configuration.LoginType.Equals(Configuration.LoginTypes.AD)
	                            && session.UserIsAuthenticated)
	                        {
	                            //obter o login (tirar o dominio se existir
	                            string login = session.UserLogin;
	                            int pos = login.IndexOf("\\");
	                            if (pos != -1)
	                                login = login.Substring(pos + 1);
	                            user.Name = login;
	                            List<string[]> argumentos = new List<string[]>();
	                            argumentos.Add(new string[] { login, "", "", user.Year, "", "", "N" });
	                            comunicacao.ArrayValoresCampos = argumentos;
	                            DomainCredential domainCredential = new DomainCredential();
	                            domainCredential.DomainUser = login;
	                            credential = domainCredential;
	                        }
	                        else
	                        {
	                            //string permissoesCliente = "";

	                            //Vai buscar o Qfield to saber se usa o Qcertificate to a autenticação
	                            int index = Array.IndexOf(comunicacao.ArrayNomesCampos, "cc");
	                            if (index != -1 && comunicacao.ArrayValoresCampos[0][index].Equals("S"))
	                            {
	                                if (session.IsClientCertificatePresent)
	                                {
	                                    CertificateCredential certCredential = new CertificateCredential();
	                                    certCredential.Certificate = session.ClientCertificate;
	                                    credential = certCredential;
	                                }
	                                else
	                                    return comunicacao.constroiRespostaErro("O certificado não está presente", user.Language);

	                            }
	                            else
	                            {
	                                // Se for to utilizar login e password
	                                UserPassCredential upCredential = new UserPassCredential();
	                                upCredential.Username = comunicacao.ArrayValoresCampos[0][0];
                                     try
                                    {
                                        byte[] bytespass = EncryptPass.Decrypt(StringHelper.HexStringToBytes(comunicacao.ArrayValoresCampos[0][1]));
                                        upCredential.Password = System.Text.ASCIIEncoding.ASCII.GetString(bytespass);
                                    }
                                    catch {
                                        upCredential.Password = comunicacao.ArrayValoresCampos[0][1];
                                        Log.Error(string.Format("Erro a tentar descifrar a password por RSA. [utilizador] {0}", upCredential.Username));
                                    }
	                                credential = upCredential;
	                            }
	                        }

	                        credential.Year = user.Year; //TODO: remove this

	                        principal = SecurityFactory.Authenticate(credential);
						}

                        user = LoginFirstAvailableYear(session, principal);
                        loginSessao = user.Name;

                        return comunicacao.constroiRespostaSucesso(comunicacao.Utilizador2String(user, ""), "Login bem sucedido", Status.OK, user.Language);

                    }

                case "ANOSLIST":
                    {
                        if (Log.IsDebugEnabled) Log.Debug(string.Format("Pedida lista de anos. [utilizador] {0}", user.Name));

                        //construir a resposta
                        string anos = "";
                        if (session.User.Years.Count > 1)
                            anos = string.Join("|", session.User.Years.ToArray());

                        string[] msg = new string[] {
                            anos,
                            user.Year
                        };
                        return comunicacao.constroiRespostaSucesso(msg , "", Status.OK, user.Language);
                    }
                case "ANOCHANGE":
                    {
                        if (Log.IsDebugEnabled) Log.Debug(string.Format("User mudou de ano. [utilizador] {0}", user.Name));

                        string novoAno = comunicacao.GetScalarValoresCampos();

                        if (!string.IsNullOrEmpty(novoAno) && user.Years.Contains(novoAno))
                        {
                            user.Year = novoAno;
                        }
                        return comunicacao.constroiRespostaSucesso(comunicacao.Utilizador2String(user, ""), "Ok", Status.OK, user.Language);

                    }
				case "UPDATEEPH":
                    {
						if (comunicacao.ArrayValoresCampos.Count > 0)
						{
						string ephID = comunicacao.ArrayValoresCampos[0][0];
						string[] ephValues = comunicacao.ArrayValoresCampos[0][1].Split(';');
						UserFactory.UpdateEPH(user, ephID, ephValues);

						}
                        return comunicacao.constroiRespostaSucesso("Ok", Status.OK, user.Language);
                    }
				case "GETEPH":
                    {
                        string ephID = comunicacao.ArrayValoresCampos[0][0];
                        string[] res = user.GetEph(user.CurrentModule, ephID);

                        return comunicacao.constroiRespostaSucesso(res, "", Status.OK, user.Language);
                    }
                case "GENERATEDPSW":
                    {
                        return comunicacao.constroiRespostaSucesso("Ok", Status.OK, user.Language);
                    }

                case "LOGOFF": //se é uma função de logoff
                    {
                        //retirar o user que está em sessão e colocar o user público
                        if (Log.IsDebugEnabled) Log.Debug(string.Format("O utilizador terminou a sessão. [utilizador] {0}", user.Name));
                        user = new User("", session.SessionId, Configuration.DefaultYear, user.Location);
                        user.Public = true;
                        session.User = user;
                        loginSessao = "";
                        GlobalAppSessions.Instance.Remove(session.SessionId);
                        session.ClearAuthenticationTicket();

                        return comunicacao.constroiRespostaSucesso("Sessão Terminada", Status.OK, user.Language);
                    }
                case "DELEGAUSR":
                    {
                        //parsing dos argumentos
                        string coddelega = comunicacao.GetScalarValoresCampos();

                        //posicionar a delegação
                        CSGenioAdelega delega = CSGenioAdelega.search(sp, coddelega, user);
                        if (delega == null)
                            return comunicacao.constroiRespostaErro("Delegação não existente", user.Language);

                        //validate se este user tem direito a escolher esta delegação
                        if (delega.ValCodpswdw != user.Codpsw
                            || DateTime.Today < delega.ValDateini
                            || DateTime.Today > delega.ValDateend
                            || delega.ValRevoked == 1)
                            return comunicacao.constroiRespostaErro("O utilizador não tem direito de usar esta delegação de acesso", user.Language);

                        CSGenioApsw psw = CSGenioApsw.search(sp, delega.ValCodpswup, user);
                        if (psw == null)
                            return comunicacao.constroiRespostaErro("Delegação não existente", user.Language);

                        //mudar a identificação e permissões do user corrente to as permissões do delegador
                        GlobalFunctions f = new GlobalFunctions(user, user.CurrentModule, sp);

                        User otherPrincipal = SecurityFactory.Authorize(new GenioIdentity()
                            {
                                Name = psw.ValNome,
                                IsAuthenticated = true,
                                IdProperty = GenioIdentityType.InternalId,
                                AuthenticationType = "internal"
                            });
                        User novoUser = UserFactory.ReadEphs(otherPrincipal);
                        //TODO: convinha manter em sessão o facto desta identidade ter sido delegada e que a original é delega.ValCodpswdw
                        novoUser.Name = delega.ValAuditusr;

                        session.User = novoUser;//o user é colocado em sessão
                        loginSessao = novoUser.Name;
                        if (Log.IsDebugEnabled) Log.Debug(string.Format("O utilizador usou um acesso delegado {1}. [utilizador] {0}", user.Name, delega.ValDateini));

                        //construir a resposta
                        StringBuilder sb = new StringBuilder();
                        Comunicacao.GetModulosPorNivel(novoUser, sb);
                        string[] msg = new string[] {
                            loginSessao,
                            sb.ToString(),
                            InterfaceObjectPermission.getPermissoesPorNivel(novoUser)
                        };
                        return comunicacao.constroiRespostaSucesso(msg, "", Status.OK, user.Language);
                    }
                case "TEMDELEGA":
                    {
                        //Verifica se este user tem delegações atribuidas
                        SelectQuery select = new SelectQuery()
                            .Select(SqlFunctions.Count(new ColumnReference(CSGenioAdelega.FldCoddelega)), "c")
                            .From(Area.AreaDELEGA)
                            .Join(Area.AreaPSWUP).On(CriteriaSet.And().Equal(CSGenioAdelega.FldCodpswup , CSGenioApswup.FldCodpsw))
                            .Where(CriteriaSet.And()
                                .Equal(CSGenioAdelega.FldCodpswdw, user.Codpsw)
                                .NotEqual(CSGenioAdelega.FldRevoked, 1)
                                .GreaterOrEqual(SqlFunctions.Custom("Diferenca_entre_Datas", new ColumnReference(CSGenioAdelega.FldDateini), SqlFunctions.SystemDate(), "D"), 0)
                                .GreaterOrEqual(SqlFunctions.Custom("Diferenca_entre_Datas", SqlFunctions.SystemDate(), new ColumnReference(CSGenioAdelega.FldDateend), "D"), 0)
                                );
                        int count = (int)sp.ExecuteScalar(select);

                        string[] msg = new string[] {
                            count > 0 ? "1" : "0"
                        };
                        return comunicacao.constroiRespostaSucesso(msg, "", Status.OK, user.Language);
                    }
                case "DELEGAREVOKE":
                    {
                        //parsing dos argumentos
                        string coddelega = comunicacao.GetScalarValoresCampos();

                        //validar que o user pode revogar esta delegação
                        if(user.IsAdmin(user.CurrentModule))
                        {
                            SelectQuery select = new SelectQuery()
                                .Select(SqlFunctions.Count(new ColumnReference(CSGenioAdelega.FldCoddelega)), "c")
                                .From(Area.AreaDELEGA)
                                .Where(CriteriaSet.And()
                                    .Equal(CSGenioAdelega.FldCodpswup, user.Codpsw));
                            int count = (int)sp.ExecuteScalar(select);
                            if(count == 0)
                                return comunicacao.constroiRespostaErro("O utilizador não tem direito de revogar esta delegação de acesso", user.Language);
                        }

                        //marcar a delegação como revogada
                        CSGenioAdelega delega = CSGenioAdelega.search(sp, coddelega, user);
                        if (delega == null)
                            return comunicacao.constroiRespostaErro("Delegação não existente", user.Language);
                        delega.ValRevoked = 1;
                        delega.update(sp);

                        return comunicacao.constroiRespostaSucesso("", Status.OK, user.Language);
                    }
				case "ICTRLEXT"://interface for external controls request such as Flash
                    {
                        ExtControl extControlObj = ExtControl.getExtControlObj(controlo, comunicacao.GetRowValoresCampos(), user);
                        object Qresult = extControlObj.processRequest();
                        return controiRespostaResultadoGenerico(Qresult, comunicacao, user);
                    }
                /************************************Se é uma função global**************************************/
                default:
                    {
                        if (GlobalFunctions.functionValidate(comunicacao.Aplicacao))
                        {
                            object Qresult = new GlobalFunctions(user, comunicacao.Module, sp).executeFunction(comunicacao.Aplicacao, comunicacao.GetRowValoresCampos());
                            return controiRespostaResultadoGenerico(Qresult, comunicacao, user);
                        }
                        else
                            return comunicacao.constroiRespostaErro("A função invocada não existe", user.Language);

                    }
            }
        }

        private static Comunicacao controiRespostaResultadoGenerico(object Qresult, Comunicacao comunicacao, User user)
        {
            if (Qresult is Boolean)
                return comunicacao.constroiRespostaSucesso("", Status.OK, user.Language);
            else
                return comunicacao.constroiRespostaSucesso(Qresult, "", Status.OK, user);
        }

        /// <summary>
        /// Função generica que trata os seguintes pedidos:
        /// GET_MAIS,
        /// GET_MENOS,
        /// GET
        /// GETUM - quando queremos select um registo,
        /// GETU - preenche automaticamente um registo dum LED no caso de só haver um
        /// </summary>
        /// <param name="session">sessão</param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizador">user em sessão</param>
        /// <param name="sp">suporte persistente</param>
        /// <param name="tpfunc">Type função</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoGET(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp, FunctionType tpfunc)
        {
            comunicacao.constroiIdent();
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido " + tpfunc.ToString() + ". [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));

            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            if (!area.AccessRightsToConsult(user))
                return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

            int ultimaLinhaLida = 0;
            if (tpfunc.Equals(FunctionType.GET_UM) || tpfunc.Equals(FunctionType.GET_UNICO))
            {
                area.insertNamesFields(comunicacao.ArrayNomesCampos);

                comunicacao.CondicaoSQL = comunicacao.constroiCondicaoGeneric(user, area, comunicacao.Identificador);

                if(tpfunc.Equals(FunctionType.GET_UNICO))
                    area.selectSingle(comunicacao.CondicaoSQL, comunicacao.Identificador, sp);
                else
                    area.selectOne(comunicacao.CondicaoSQL, comunicacao.OrdenacaoSQL, comunicacao.Identificador, sp);

                string[] dadosParaEnviar = comunicacao.Area2String(area, true);
                return comunicacao.constroiRespostaSucesso(dadosParaEnviar, "Dados para enviar", Status.OK, user.Language);
			}
            else if (tpfunc.Equals(FunctionType.GET_MENOS))
                ultimaLinhaLida = getUltimaLinhaLida(session.UltimosLidosInicio, comunicacao.Identificador);
            else if (tpfunc.Equals(FunctionType.GET_MAIS))
                ultimaLinhaLida = getUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador);

            if (ultimaLinhaLida == -1)
                return comunicacao.constroiRespostaErro("Não existe registo da última linha lida!", user.Language);

            bool temPagAnterior = false;
            if(tpfunc.Equals(FunctionType.GET_MENOS))
            {
				int mod = ultimaLinhaLida % comunicacao.Numregs;
				if (mod == 0)
					ultimaLinhaLida = ultimaLinhaLida - 2* comunicacao.Numregs;

				else
					ultimaLinhaLida = ultimaLinhaLida - comunicacao.Numregs - mod;

				if (ultimaLinhaLida !=0)
					temPagAnterior = true;
            }

            Listing Qlisting = new Listing(area, comunicacao.OrdenacaoSQL, comunicacao.Module,comunicacao.Identificador, user, sp);
            Qlisting.obterTotal = comunicacao.ObterTotal;
            Qlisting.RequestedFields = comunicacao.ArrayNomesCampos;

            comunicacao.adicionarCondicaoSQL(Qlisting.EphQueryConditions);
			if(comunicacao.TemCondicaoFiltraArea)
            {
               Condition.construirCondicaoFiltraArea(comunicacao, user);
            }

            if(tpfunc.Equals(FunctionType.GET))
                Qlisting = Qlisting.select(comunicacao.Identificador, comunicacao.CondicaoSQL, comunicacao.Numregs + 1);
            else if(tpfunc.Equals(FunctionType.GET_NIVELTREE))
                Qlisting = Qlisting.selectLevel(area, comunicacao.CamposPedidoSQL, comunicacao.CondicaoSQL, comunicacao.ChavePai);
            else
                Qlisting = Qlisting.selectMore(comunicacao.Identificador, comunicacao.CondicaoSQL, comunicacao.Numregs + 1, ultimaLinhaLida, area.Alias + "." + area.PrimaryKeyName);

            ultimaLinhaLida = Qlisting.LastFilled;
            if (ultimaLinhaLida == comunicacao.Numregs + 1)
                ultimaLinhaLida = comunicacao.Numregs;

            Hashtable ultimosLidos;

            if(tpfunc.Equals(FunctionType.GET_MENOS))
            {
                ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosInicio, comunicacao.Identificador, 0-ultimaLinhaLida, true);
                session.UltimosLidosInicio = ultimosLidos;
            }
            else if(tpfunc.Equals(FunctionType.GET_MAIS))
            {
                ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador, ultimaLinhaLida, true);
                session.UltimosLidosFim = ultimosLidos;
			}
            else if (tpfunc.Equals(FunctionType.GET))
			{
                ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador, ultimaLinhaLida, false);
				session.UltimosLidosFim = ultimosLidos;
            }

            string mensagem = "";
            if (comunicacao.ObterTotal)
            {
				//mensagem = Translations.Get("Total de registos: ", user.Language) + Qlisting.TotalRecords;
				comunicacao.SetOptionValue("TRECS", Qlisting.TotalRecords.ToString());
            }

            List<string[]> matrizParaEnviar = null;
            if(!comunicacao.IsPedidoMF)
                matrizParaEnviar = comunicacao.DataSet2String(Qlisting.DataMatrix, user);
            else
                matrizParaEnviar = comunicacao.DataSetMF2String(Qlisting.DataMatrix, user);

            Status status;

            if (temPagAnterior)
            {
                if (Qlisting.LastFilled <= comunicacao.Numregs)
                    status = Status.OK_MENOS;
            else
                    status = Status.OK_MAIS_MENOS;
            }
            else if (Qlisting.LastFilled <= comunicacao.Numregs || comunicacao.Numregs==-1)
                status =  Status.OK;
            else
                status = Status.OK_MAIS;

            return comunicacao.constroiRespostaSucesso(matrizParaEnviar, mensagem, status, user.Language);
        }

		/// <summary>
        /// Generic function that treats the following requests:
        /// GET_ALTERNATIVE
        /// </summary>
        /// <param name="session">Session</param>
        /// <param name="comunicacao">Object with request</param>
        /// <param name="utilizador">User in session</param>
        /// <param name="sp">Persistence support</param>
        /// <param name="tpfunc">Function type</param>
        /// <returns>Object with response</returns>
        private static Comunicacao pedidoGETAlternative(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp, FunctionType tpfunc)
        {
            comunicacao.constroiIdent();
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido " + tpfunc.ToString() + ". [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));

            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            if (!area.AccessRightsToConsult(user))
                return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

           int offset = 0;
            if (comunicacao.Offset > -1)
                offset = comunicacao.Offset;

			if (comunicacao.Numregs > 0)
                comunicacao.Numregs++;

            bool temPagAnterior = false;

            Listing Qlisting = new Listing(area, comunicacao.OrdenacaoSQL, comunicacao.Module, comunicacao.Identificador, user, sp);
            Qlisting.obterTotal = comunicacao.ObterTotal;
            Qlisting.RequestedFields = comunicacao.ArrayNomesCampos;

            comunicacao.adicionarCondicaoSQL(Qlisting.EphQueryConditions);
			if(comunicacao.TemCondicaoFiltraArea)
            {
               Condition.construirCondicaoFiltraArea(comunicacao, user);
            }

            if(tpfunc.Equals(FunctionType.GET_ALTERNATIVE))
            {
                //Last updated by [CJP] at [07.10.2014]
				//As queries criadas têm o id resultante da concatenação do id da comunicação com o provider
				//Necessário to controlo em árvore (requests com o mesmo id e providers diferentes)
				string idAlternativo = comunicacao.Identificador + comunicacao.Aplicacao;
                Qlisting = Qlisting.anotherSelect(idAlternativo, comunicacao.ArrayNomesCampos, comunicacao.OrdenacaoSQL, comunicacao.CondicaoSQL, comunicacao.Numregs, offset);
            }
            int ultimaLinhaLida = offset + Qlisting.LastFilled - 1;

            Hashtable ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador, ultimaLinhaLida, false);
			session.UltimosLidosFim = ultimosLidos;

            string mensagem = "";
            if (comunicacao.ObterTotal)
            {
				//mensagem = Translations.Get("Total de registos: ", user.Language) + Qlisting.TotalRecords;
				comunicacao.SetOptionValue("TRECS", Qlisting.TotalRecords.ToString());
            }

            List<string[]> matrizParaEnviar = null;
            if(!comunicacao.IsPedidoMF)
                matrizParaEnviar = comunicacao.DataSet2String(Qlisting.DataMatrix, user);
            else
                matrizParaEnviar = comunicacao.DataSetMF2String(Qlisting.DataMatrix, user);

            Status status;

            if (temPagAnterior)
            {
                if (Qlisting.LastFilled <= comunicacao.Numregs)
                    status = Status.OK_MENOS;
            else
                    status = Status.OK_MAIS_MENOS;
            }
            else if (Qlisting.LastFilled <= comunicacao.Numregs || comunicacao.Numregs==-1)
                status =  Status.OK;
            else
                status = Status.OK_MAIS;

            return comunicacao.constroiRespostaSucesso(matrizParaEnviar, mensagem, status, user.Language);
        }

        /// <summary>
        /// Função que trata o GETNIVELTREE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizador">user em sessão</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoGETNIVELTREE(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido GETNIVELTREE. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //verificação dos direitos de acesso, se pode consultar
            if (!area.AccessRightsToConsult(user))
                return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

            //criar o objecto que vai conter os registos
            Listing Qlisting = new Listing(area, comunicacao.OrdenacaoSQL, comunicacao.Module, comunicacao.Identificador, user, sp);
            //adicionar as condições de entrada permanente de historial
            comunicacao.adicionarCondicaoSQL(Qlisting.EphQueryConditions);

            //invocar a função select do negócio
			//Last updated by [CJP] at [30.09.2014]
			//A condição da key do Pai é sempre a primeira condição a ser transmitida pelo interface

			string parentKeyCond;
            if (comunicacao.CondicaoOriginal.IndexOf('{') != -1)
                parentKeyCond = comunicacao.CondicaoOriginal.Substring(0, comunicacao.CondicaoOriginal.Length - comunicacao.CondicaoOriginal.IndexOf('{'));
            else
                parentKeyCond = comunicacao.CondicaoOriginal;

            Qlisting = Qlisting.selectLevel(area, comunicacao.CamposPedidoSQL, comunicacao.CondicaoSQL, parentKeyCond);

            List<string[]> dadosParaEnviar = comunicacao.DataSetMF2String(Qlisting.DataMatrix, user);

            //dados to responder
            return comunicacao.constroiRespostaSucesso(dadosParaEnviar, "Dados Enviados", Status.OK, user.Language);

        }

        /// <summary>
        /// Função que trata os pedidos de GETPOS - to obter uma lista de registos posicionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="utilizador">user em sessão</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoGETPOS(ISessao session, Comunicacao comunicacao, User user, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido GETPOS. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);
            //acrescentar os direitos de acesso, verificação se pode consultar
            if (!area.AccessRightsToConsult(user))
                return comunicacao.constroiRespostaErro("O utilizador não tem permissões para visualizar os dados!", user.Language);

            Listing Qlisting = new Listing(area, comunicacao.OrdenacaoSQL, comunicacao.Module, comunicacao.Identificador, user, sp);
            Qlisting.obterTotal = comunicacao.ObterTotal;
			Qlisting.RequestedFields = comunicacao.ArrayNomesCampos;

            //adicionar as condições de entrada permanente de historial
            comunicacao.adicionarCondicaoSQL(Qlisting.EphQueryConditions);
			if (comunicacao.TemCondicaoFiltraArea)
            {
                Condition.construirCondicaoFiltraArea(comunicacao, user);
            }

            // OVERRIDE da obtenção dos dados to a Qlisting
            Type funcObj = typeof(GenioServer.framework.OverrideQuery);
            //estes overrides faz sentido terem a mesma tag (OVRD_LISTAGEM.SELECCIONAR) e assinatura da funçao que as que estão na Listing.Seleccionar()
            //(Listing Qlisting, CriteriaSet condition, User user, int nrRecords, PersistentSupport sp)
            System.Reflection.MethodInfo funcOver = funcObj.GetMethod(comunicacao.Identificador);//processa IBL
            if(funcOver!=null)
            {
                try
                {
                    object[] parameters = new object[5];
                    parameters[0] = comunicacao.CondicaoSQL;//CriteriaSet
                    parameters[1] = user;//User
                    parameters[2] = sp;//PersistentSupport
                    parameters[3] = 0;//int
                    parameters[4] = Qlisting;//Listing

                    Qlisting = (Listing)funcOver.Invoke(null, parameters);
                    string mensagem = "";
                    List<string[]> dadosParaEnviar = comunicacao.DataSet2String(Qlisting.DataMatrix, user);
                    return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK, user.Language);
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    if(ex.InnerException is FrameworkException)
                        throw (FrameworkException)ex.InnerException;
                    else if(ex.InnerException is BusinessException)
                        throw (BusinessException)ex.InnerException;
                    else if (ex.InnerException is PersistenceException)
                        throw (PersistenceException)ex.InnerException;
                    else
                        throw ex.InnerException;
                }
            }
            else
            {
            /*ir buscar o Qvalue da key primária que vem nos dados*/
            string primaryKeyValue = comunicacao.getValorChavePrimaria(area.Alias + "." + area.PrimaryKeyName);

            if (primaryKeyValue.Equals(""))
                return comunicacao.constroiRespostaErro("O registo não está posicionado!", user.Language);

            if (comunicacao.Numregs == -1)
            {
                //invocar a função select do negócio
                Qlisting = Qlisting.select(comunicacao.Identificador, comunicacao.CondicaoSQL, 0);

                int nrLidos = Qlisting.LastFilled;
                if (nrLidos == comunicacao.Numregs + 1)
                    nrLidos = comunicacao.Numregs;
                //preencher as conditions em sessão com os dados resultantes da seleção
                Hashtable ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador, nrLidos , false);
                session.UltimosLidosFim = ultimosLidos;
                string mensagem = "";
                if (comunicacao.ObterTotal && comunicacao.Identificador.StartsWith(comunicacao.Module))
                {
                    Qlisting.TotalRecords = sp.count(comunicacao.Identificador, Qlisting, comunicacao.CondicaoSQL);
                    //mensagem = Translations.Get("Total de registos: ", user.Language) + Qlisting.TotalRecords;
					comunicacao.SetOptionValue("TRECS", Qlisting.TotalRecords.ToString());
                }
                //dados to responder
                List<string[]> dadosParaEnviar;
                if (!comunicacao.IsPedidoMF)
                    dadosParaEnviar = comunicacao.DataSet2String(Qlisting.DataMatrix, user);
                else
                    dadosParaEnviar = comunicacao.DataSetMF2String(Qlisting.DataMatrix, user);

                return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK, user.Language);
            }
            else
            {
                bool temPagAnterior = false;
                /*ir buscar a posição do último registo antes do que o que está seleccionado*/
                int ultimaLinhaLida = Qlisting.getRecordPos(area, primaryKeyValue, comunicacao.CondicaoSQL, comunicacao.Identificador);
                if (ultimaLinhaLida >= comunicacao.Numregs)
                    temPagAnterior = true;
                ultimaLinhaLida = ultimaLinhaLida - (((ultimaLinhaLida % comunicacao.Numregs) == 0 && ultimaLinhaLida > 0) ?
															comunicacao.Numregs :
															(ultimaLinhaLida % comunicacao.Numregs));

                //invocar a função select do negócio
                Qlisting = Qlisting.selectMore(comunicacao.Identificador, comunicacao.CondicaoSQL, comunicacao.Numregs + 1, ultimaLinhaLida, area.Alias + "." + area.PrimaryKeyName);

                int nrLidos = Qlisting.LastFilled;
                    if (nrLidos == comunicacao.Numregs + 1)
                        nrLidos = comunicacao.Numregs;
                //preencher as conditions em sessão com os dados resultantes da seleção
                Hashtable ultimosLidos = preencherUltimaLinhaLida(session.UltimosLidosFim, comunicacao.Identificador, nrLidos + ultimaLinhaLida, false);
                session.UltimosLidosFim = ultimosLidos;
                session.UltimosLidosInicio = (Hashtable)ultimosLidos.Clone();
                string mensagem = "";
                if (comunicacao.ObterTotal && comunicacao.Identificador.StartsWith(comunicacao.Module))
                {
                    Qlisting.TotalRecords = sp.count(comunicacao.Identificador, Qlisting, comunicacao.CondicaoSQL);
                    //mensagem = Translations.Get("Total de registos: ", user.Language) + Qlisting.TotalRecords;
					comunicacao.SetOptionValue("TRECS", Qlisting.TotalRecords.ToString());
                }
                //dados to responder
                List<string[]> dadosParaEnviar;
                if (!comunicacao.IsPedidoMF)
                    dadosParaEnviar = comunicacao.DataSet2String(Qlisting.DataMatrix, user);
                else
                    dadosParaEnviar = comunicacao.DataSetMF2String(Qlisting.DataMatrix, user);

                if (temPagAnterior)
                    if(Qlisting.LastFilled <= comunicacao.Numregs)
                        return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK_MENOS, user.Language);
                    else
                        return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK_MAIS_MENOS, user.Language);
                else
                if (Qlisting.LastFilled <= comunicacao.Numregs)
                    return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK, user.Language);
                else
                    return comunicacao.constroiRespostaSucesso(dadosParaEnviar, mensagem, Status.OK_MAIS, user.Language);
                }
            }

        }

        // verifica se o file exists e apaga-o
        private static void ApagaFicheiroDisco(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // verifica se um file vindo do qweb foi alterado
        private static bool FicheiroAlterado(string fileName)
        {
            return !(fileName.StartsWith("*"));
        }

        // função que preenche a area com os Qvalues vindos do qweb e faz o tratamento de ficheiros
        private static void AcrescentaValoresArea(Area area, string[] nomescampos, string[] valorescampos, PersistentSupport sp)
        {
            if (nomescampos.Length != valorescampos.Length)
                throw new Exception("erro comunicacao.ArrayNomesCampos.Length != comunicacao.ArrayValoresCampos[0].Length");

            for (int i = 0; i < nomescampos.Length; i++)
            {
                RequestedField campoPedido = new RequestedField(nomescampos[i], area.Alias);
                Field campoBD = area.DBFields[campoPedido.Name];
                string pathFich = null;

                if (campoBD.FieldType.Equals(FieldType.IMAGE))
                {
                    // aqui faz-se o replace de '/' por '\', porque em algumas situações a barra vem ao "contário"
                    pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, valorescampos[i].Replace('/', '\\'));
                    // no caso do multiform os Qvalues chegam ao servidor sem o '*' antes do name, mesmo quando o file não foi alterado
                    // portanto verifica-se também se o file exists antes de tentar gravar

                    if (valorescampos[i].Equals(""))
                        campoPedido.Value = ConversaoQweb.ToInternal("", FieldType.IMAGE.GetFormatting());
                    else
                    {
                        if (FicheiroAlterado(valorescampos[i]) && File.Exists(pathFich))
                        {
                            campoPedido.Value = File.ReadAllBytes(pathFich);
                            ApagaFicheiroDisco(pathFich);
                        }
                        else
                            // se não foi feito o upload, salta o Qfield
                            continue;
                    }

                }
                else if (campoBD.FieldType.Equals(FieldType.PATH))
                {
                    pathFich = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, valorescampos[i]);
                    // no caso do multiform os Qvalues chegam ao servidor sem o '*' antes do name, mesmo quando o file não foi alterado
                    // portanto verifica-se também se o file exists antes de tentar gravar
                    if (valorescampos[i].Equals(""))
                        campoPedido.Value = ConversaoQweb.ToInternal("", FieldType.PATH.GetFormatting());
                    else
                    {
                        if (FicheiroAlterado(valorescampos[i]) && File.Exists(pathFich))
                        {
                            string nomeCampoStr = "_" + area.Alias + "_" + area.Alias + "." + campoPedido.Name;
                            int posNomeCampo = valorescampos[i].LastIndexOf(nomeCampoStr);
                            string nomeFich = valorescampos[i].Substring(5, posNomeCampo - 5);
                            int ponto = valorescampos[i].IndexOf('.', posNomeCampo + nomeCampoStr.Length);
                            if (ponto != -1)
                                nomeFich += valorescampos[i].Substring(ponto);
                            campoPedido.Value = nomeFich;
                            string ficheiroOriginal = Path.Combine(Configuration.PathDocuments, nomeFich);
                            if (File.Exists(ficheiroOriginal))
                                File.Delete(ficheiroOriginal);
                            File.Copy(pathFich, ficheiroOriginal);
                            ApagaFicheiroDisco(pathFich);
                        }
                        else
                            // se não foi feito o upload, salta o Qfield
                            continue;
                    }
                }
                else
                {
                    // os fields respectivos a documentos são geridos pelos pedidos do tipo FCT
                    // os Qvalues que chegam da interface são descartados
                    if (area.Information.DocumsForeignKeys != null)
                    {
                        // se é o name do documento ou a key pra docums, salta o Qfield
                        // to não fazer override com os Qvalues que possam vir da interface
                        if (area.Information.DocumsForeignKeys.Contains(campoPedido.Name) ||
                            area.Information.DocumsForeignKeys.Contains(campoPedido.Name + "fk"))
                            continue;
                    }
                    campoPedido.Value = ConversaoQweb.ToInternal(valorescampos[i], campoBD.FieldType.GetFormatting());
                }

                area.insertNameValueField(campoPedido.FullName, campoPedido.Value);
            }
        }

        /// <summary>
        /// Função que trata os pedidos de alteração
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto que tem o pedido</param>
        /// <param name="utilizador">user em sessão</param>
        /// <param name="sombra">se é to change to uma table shadow</param>
        /// <param name="sp">suporte persistente</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoALT(Comunicacao comunicacao, User user, bool shadow, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido ALT. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //preencher a área com os Qvalues que vêm no pedido
            AcrescentaValoresArea(area, comunicacao.ArrayNomesCampos, comunicacao.ArrayValoresCampos[0], sp);
            area.removeCalculatedFields();
            //invocar a função change da camada de negócio
            StatusMessage Qresult = area.change(sp, comunicacao.CondicaoSQL);
            return comunicacao.constroiRespostaSucesso(comunicacao.Area2String(area, false), Qresult.PrintMessages(), Qresult.Status, user.Language);			
        }

        /// <summary>
        /// Função que trata o pedido de inserção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto comunicação</param>
        /// <param name="utilizador">objecto user</param>
        /// <param name="sombra">se é to introduce em table shadow</param>
        /// <param name="sp">instancia do suporte persistente</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoINS(Comunicacao comunicacao, User user, bool shadow, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido INS. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //construir a condition que será usada na inserção
            comunicacao.criaArrayNomesValoresCamposIns();

            //preencher Qvalues ephs quando são únicos
            area.fillEPH(user, sp, comunicacao.Identificador);

            //função que permite introduce um registo
            Area Qresult = area.insertPseud(sp, comunicacao.ArrayNomesCamposIns.ToArray(), comunicacao.ArrayValoresCamposIns.ToArray());

            //construção da resposta
            return comunicacao.constroiRespostaSucesso(comunicacao.Area2String(area, false), "Inserção bem sucedida", Status.OK, user.Language);

        }

        /// <summary>
        /// Função que trata o eliminate e cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto comunicação</param>
        /// <param name="utilizador">objecto user</param>
        /// <param name="area">objecto area</param>
        /// <param name="sombra">se é table shadow</param>
        /// <param name="sp">suporte persistente</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoELI_CAN(Comunicacao comunicacao, User user, bool shadow, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido ELI_CAN. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //introduce os nomes e Qvalues dos fields(to fórmulas)
            area.insertNamesFields(comunicacao.ArrayNomesCampos);

            //preencher a condição to apagar
            area = comunicacao.preencheCodRegApagar(area);

            //função eliminate
            StatusMessage Qresult = area.eliminate(sp);
            return comunicacao.constroiRespostaSucesso(Qresult.Message, Qresult.Status, user.Language);

        }

        /// <summary>
        /// Função que trata o pedido de duplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="utilizador">user em sessão</param>
        /// <param name="comunicacao">objecto com o pedido</param>
        /// <param name="sombra">se é to duplicate to uma table shadow</param>
        /// <param name="sp">Suporte persistente</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoDUP(User user, Comunicacao comunicacao, bool shadow, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido DUP. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
            Area area = Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //construir a condição com a key primária
            comunicacao.constroiCondChavePrimaria(area.PrimaryKeyName);

            //função to duplicate um registo
            Area areaResultado = area.duplicate(sp, comunicacao.CondicaoSQL);
            string[] dadosParaEnviar = comunicacao.Area2String(areaResultado, false);
            return comunicacao.constroiRespostaSucesso(dadosParaEnviar, "Duplicação bem sucedida", Status.OK, user.Language);

        }

        /// <summary>
        /// Função que trata o pedido de inserção/eliminação múltipla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="comunicacao">objecto comunicação</param>
        /// <param name="utilizador">objecto user</param>
        /// <param name="sombra">se é to introduce em table shadow</param>
        /// <param name="sp">instancia do suporte persistente</param>
        /// <returns>objecto com a resposta</returns>
        private static Comunicacao pedidoELI_INS_M(Comunicacao comunicacao, User user, PersistentSupport sp)
        {
            comunicacao.constroiIdent();//construção do identifier
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Processa pedido ELI_INS_M. [id] {0} [aplicacao] {1}", comunicacao.Identificador, comunicacao.Aplicacao));
            //instanciação da area base
			DbArea area = (DbArea)Area.createArea(comunicacao.Aplicacao, user, comunicacao.Module);

            //função que permite introduce um registo
            StatusMessage Qresult = area.eliminar_inserir_Varios(sp, comunicacao.ArrayNomesCampos, comunicacao.ArrayValoresCampos, comunicacao.CondicaoSQL);

            //construção da resposta
            return comunicacao.constroiRespostaSucesso(Qresult.Message, Qresult.Status, user.Language);
        }

        /// <summary>
        /// Função to ir buscar o número da última linha lida
        /// </summary>
        /// <param name="condSessao">Objecto(se estiver preenchido é uma hashtable,
        /// caso contrário está a null) com as condições que está em sessão</param>
        /// <param name="identificador">Identificador da sessão</param>
        /// <returns>Devolve -1 se não exists último registo</returns>
        private static int getUltimaLinhaLida(object condSessao, string identifier)
        {
            Hashtable condicoesSessao;
            if (condSessao !=null)
            {
                condicoesSessao = (Hashtable)condSessao;
                if (condicoesSessao.ContainsKey(identifier))
                    return (int)condicoesSessao[identifier];
                else
                    return -1;
            }
            else
                return -1;

        }

        /// <summary>
        /// Função to preencher as condições de sessão, é usada no GET e GET_MAIS
        /// </summary>
        /// <param name="condSessao">objecto (se estiver preenchido é uma hashtable,
        /// caso contrário está a null) que tem as condições de sessão</param>
        /// <param name="identificador">Identificador da condição</param>
        /// <param name="listagem">Qlisting do pedido</param>
        /// <returns>Hashtable das condições</returns>
        private static Hashtable preencherUltimaLinhaLida(object ultimosLidosObj, string identifier, int lastRead, bool isGetMais)
        {
            Hashtable ultimosLidos;

            //remover o Qvalue se já estiver em sessão
            if (ultimosLidosObj != null)
            {
                ultimosLidos = ((Hashtable)ultimosLidosObj);
                if (ultimosLidos.ContainsKey(identifier))
                {
                    if (isGetMais)
                        lastRead += (int)ultimosLidos[identifier];
                    ultimosLidos.Remove(identifier);
                }
            }
            else
                ultimosLidos = new Hashtable();

            ultimosLidos.Add(identifier, lastRead);
            return ultimosLidos;

        }

        /// <summary>
        /// Função to saber como lidar com a perda de sessão
        /// </summary>
        /// <param name="utilizadorObj">user</param>
        /// <param name="comunicacao">objecto comunicacao</param>
        private static User perdaSessao(ISessao session, object utilizadorObj, Comunicacao comunicacao, string location, ref string loginSessao)
        {
            if (SecurityFactory.AllowAuthenticationRecovery
                && session.UserIsAuthenticated
                && (comunicacao.FunctionType != FunctionType.EXW && !comunicacao.Aplicacao.Equals("LOGON")))
            {
                //obter o login (tirar o dominio se existir
                string login = session.UserLogin;
                int pos = login.IndexOf("\\");
                if (pos != -1)
                    login = login.Substring(pos + 1);
                List<string[]> argumentos = new List<string[]>();
                argumentos.Add(new string[] { login, "", "", ConversaoQweb.ToString(Configuration.DefaultYear), "", "", "N" });
                comunicacao.ArrayValoresCampos = argumentos;

                DomainCredential cred = new DomainCredential();
                cred.DomainUser = login;
                cred.Year = Configuration.DefaultYear;
                User principal = SecurityFactory.Authenticate(cred);
                principal.SessionId = session.SessionId;
                principal.Year = Configuration.DefaultYear;
                principal.Location = location;

                User user = UserFactory.ReadEphs(principal);
                user.CurrentModule = comunicacao.Module;
                session.User = user;
                if (Log.IsDebugEnabled) Log.Debug(string.Format("Cria uma nova sessão para o utilizador. [utilizador] {0}",user.Name));
                return user;

            }
            else
            {
                User utilizadorVirtual = new User("", session.SessionId, Configuration.DefaultYear, location);
                utilizadorObj = utilizadorVirtual;
                utilizadorVirtual.CurrentModule = comunicacao.Module;
                session.User = utilizadorVirtual;
                if (!loginSessao.Equals("") && !loginSessao.StartsWith("*"))
                    loginSessao = "*" + loginSessao;
                if (Log.IsDebugEnabled) Log.Debug(string.Format("Cria um utilizador virtual. [utilizador] {0}", utilizadorVirtual.Name));
                return utilizadorVirtual;
            }
        }


    }
}
