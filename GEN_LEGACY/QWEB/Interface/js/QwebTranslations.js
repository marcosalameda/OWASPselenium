//*********************************************
//*********************************************
//*   Rotinas para Multi-Lingua
//*********************************************
//*********************************************
//*************************************    Mensagens nos varios Idiomas   *************************************
//função para fazer o load inicial e deefault na lingua base do cliente
function InitLoadMsgSet(){
	LoadFormats()
    var defaultLanguage = "PTPT";
    UsrMsgSet = null;
    FormatSet = new QformatSet("", "DMA", "24", ",", ".")

    LoadMsgSet(defaultLanguage);

    return defaultLanguage;
}


//*************************************  Seleccionar uma entre varias mensagens de lingus diferentes
function SelLangTxt(wtxt) {
	var Aw=wtxt.split("|");
	for (var i=0; i<Aw.length; i++) {
		if (User.Language == Aw[i].substr(0,4)) {
			return Aw[i].substr(4);
		}
	}
	return wtxt;
}


//*************************************  Mensagens para rotinas manuais
function GetUserMessage(id) {
    var wtxt = id + "|" + User.Language + " ???";

    if (UsrMsgSet == null) {  //o ficheiro não está carregado
        UsrMsgSet = LoadUserMessages();
    }

    if (UsrMsgSet.hasOwnProperty(id) && UsrMsgSet[id].hasOwnProperty(User.Language)) {
        var wtxt = UsrMsgSet[id][User.Language];
    }

    return wtxt;
}


//*************************************  formatos para as várias linguas/culturas
function LoadFormats() {
	FormatSets=new Array()
	//Carregar os sets de formatos para as várias linguas:  LangCode, DateFmt, TimeFmt, SepDec, Sep1000
	FormatSets.push(new QformatSet("PTPT", "DMA", "24", ",", "."))  //Portugues de Portugal
	FormatSets.push(new QformatSet("ENGB", "DMA", "24", ".", ","))  //Inglês do Reino Unido
	FormatSets.push(new QformatSet("ENUS", "MDA", "12", ".", ","))  //Inglês dos Estados Unidos
	FormatSets.push(new QformatSet("ENJM", "AMD", "12", ".", ","))  //Jamaican English
}



function LoadMsgSet(lang) {
	var m=new Array()
	switch (lang) {
		case "PTPT":  //por
			m[1] = "Ocorreu um Erro - comunique ao responsável. #1"
			m[2] = "Não Autorizado"
			m[3] = "Desativado temporariamente - Offline"
			m[4] = "Selecione uma linha"
			m[5] = "Selecione apenas uma linha"
			m[6] = "Selecione um registo"
			m[7] = ""
			m[8] = ""
			m[9] = "Modifique os dados e clique em 'Aceitar'"
			m[10] = "Clique em 'Aceitar' para Eliminar"
			m[11] = "Preencha os campos e clique em 'Aceitar'"
			m[12] = "Dados Eliminados"
			m[13] = "Dados Alterados"
			m[14] = "Dados Inseridos"
			m[15] = "Clique em 'Aceitar' para executar"
			m[16] = "Erro - Dados não gravados"
			m[17] = "#1 - é de preenchimento obrigatório"
			m[18] = "#1 - conteúdo demasiado extenso"
			m[19] = "#1 - valor inválido"
			m[20] = "#1 - valor demasiado grande"
			m[21] = "#1 - data inválida"
			m[22] = "#1 - hora inválida"
			m[23] = "Não é possível gravar a ficha com os valores inseridos"
			m[24] = "Existem formulários abertos em modo de edição, termine primeiro as alterações"
			m[25] = "Abrir"
			m[26] = "Anexar"
			m[27] = "Digitalizar"
			m[28] = "Template"
			m[29] = "Editar"
			m[30] = "Submeter"
			m[31] = "Versão"
			m[32] = "Apagar"
			m[33] = "Propriedades"
			m[34] = "Ver todas..."
			m[35] = "Apagar Última..."
			m[36] = "Apagar Histórico"
			m[37] = "Nome: "
			m[38] = "Tamanho: "
			m[39] = "Extensão: "
			m[40] = "Autor: "
			m[41] = "Data de criação: "
			m[42] = "Versão atual: "
			m[43] = "Em edição por: "
			m[44] = "Anexar documento"
			m[45] = "Procurar"
			m[46] = "Página seguinte"
			m[47] = "Página anterior"
			m[48] = "Fechar"
			m[50] = "Página seguinte"
			m[51] = "Página anterior"
			m[52] = "Fechar"
			m[53] = "Ver"
			m[54] = "Alterar"
			m[55] = "Inserir"
			m[56] = "Duplicar"
			m[57] = "Eliminar"
			m[58] = "Ocorreu um erro. O ficheiro pode já ter sido apagado por um utilizador."
			m[59] = "Ocorreu um erro ao apagar a última versão do ficheiro. A versão pode já ter sido apagada por outro utilizador."
			m[60] = "Ocorreu um erro ao apagar o historial. O historial pode já ter sido apagado por outro utilizador"
			m[61] = "Ocorreu um erro na submissão do ficheiro, tente novamente."
			m[62] = "O ficheiro já foi apagado!"
			m[63] = "A última versão vai ser eliminada.\nTem a certeza que quer apagar?"
			m[64] = "Todas as versões exceto a última vão ser apagadas.\nTem a certeza que quer apagar?"
			m[65] = "Tem a certeza que quer apagar?"
			m[66] = "A password não coincide com a confirmação."
			m[67] = "Tem a certeza que quer revogar esta delegação de acesso?"
			m[68] = "Verifique que tenha a biblioteca CAPICOM instalada e que os certificados se encontram registados"
			m[69] = "Por enquanto as assinaturas digitais só são oficialmente suportadas no Internet Explorer ou no Mozilla Firefox com a extensão do o IE tab. A assinatura pode falhar com o seu Browser. Deseja tentar na mesma?"
			m[70] ="Log In | Registo"
			m[71] ="Fechar Painel"
			m[72] ="Bem-vindo ao sistema Quidgest Balanced ScoreCard"
			m[73] ="Área de Autenticação"
			m[74] ="Para se autenticar insira o seu nome de utilizador e a sua palavra-chave!"
			m[75] ="Informação"
			m[76] ="Para mais informações visite o nosso"
			m[77] ="site"
			m[78] ="Autenticação"
			m[79] ="Utilizador"
			m[80] ="Palavra-chave"
			m[81] ="Bem-vindo"
			m[82] ="Atenção que pode perder dados, pretende mesmo fechar a janela?"
			m[83] ="Escolha os widgets que pretende que sejam mostrados!"
			m[84] ="Pretende gerar dados para todos os mapas estratégicos?"
			m[85] ="Geração de dados"
			m[86] ="Gerar"
			m[87] ="Cancelar"
			m[88] ="Ficheiro vazio"
			m[89] ="Nome do ficheiro ou o caminho completo de gravação muito extenso"

			MesSet=new Array("janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro")
			DiaSet=new Array("Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab")
			break
		default:
			window.alert("Error - language not supported")
			return
	}
	MsgSet=m
	//procurar set de formatos para a lingua pedida
	for (var i=0; i<FormatSets.length; i++) {
		if (lang == FormatSets[i].LangCode) {
			FormatSet=FormatSets[i];
			return;
		}
	}
	FormatSet = new QformatSet("", "DMA", "24", ",", ".");  //se não encontrou cria um default
}

function LoadUserMessages() {
    var messages = {
        '  172': {
            'PTPT': 'Se um valor mais elevado é melhor ou vice versa'},
        'GRAI': {
            'PTPT': 'GRAI'},
        'Human resources': {
            'PTPT': 'Human resources'},
        'Localization': {
            'PTPT': 'Localização'},
        'Outstanding': {
            'PTPT': 'Outstanding'},
        'Classe da viagem': {
            'PTPT': 'Classe da viagem'},
        'Shadow anchor (x-axis)': {
            'PTPT': 'Shadow anchor (x-axis)'},
        'Drives': {
            'PTPT': 'Drives'},
        'Receipt verification': {
            'PTPT': 'Receipt verification'},
        'HIGHLIGHT': {
            'PTPT': 'HIGHLIGHT'},
        'Carriers': {
            'PTPT': 'Carriers'},
        'Indicadores Superados': {
            'PTPT': 'Indicadores Superados'},
        'Choose room': {
            'PTPT': 'Choose room'},
        'Flights': {
            'PTPT': 'Flights'},
        'Escala do gráfico Gantt': {
            'PTPT': 'Escala do gráfico Gantt'},
        'Foreign Key 1': {
            'PTPT': 'Foreign Key 1'},
        'Limite Mau': {
            'PTPT': 'Limite Mau'},
        'Expose Table': {
            'PTPT': 'Expose Table'},
        'Caixa Bank': {
            'PTPT': 'Caixa Bank'},
        'Departure date (DD/MM/YEAR)': {
            'PTPT': 'Departure date (DD/MM/YEAR)'},
        'Indicator type date': {
            'PTPT': 'Indicator type date'},
        'Periodicidade': {
            'PTPT': 'Periodicidade'},
        'Full Name': {
            'PTPT': 'Full Name'},
        'Date of data': {
            'PTPT': 'Date of data'},
        'Forms': {
            'PTPT': 'Forms'},
        'Message': {
            'PTPT': 'Message'},
        'Availability': {
            'PTPT': 'Availability'},
        '  184': {
            'PTPT': 'Este campo é usado para fragmentar uma meta do indicador'},
        'CHVRH': {
            'PTPT': 'CHVRH'},
        'Designation': {
            'PTPT': 'Designação'},
        'Routine': {
            'PTPT': 'Routine'},
        'Maximum price': {
            'PTPT': 'Maximum price'},
        'Valor máximo': {
            'PTPT': 'Valor máximo'},
        'Number': {
            'PTPT': 'Number'},
        'Adress': {
            'PTPT': 'Adress'},
        ' 1108': {
            'PTPT': 'Address and shipping information. Used to store additional addresses for an account or contact.'},
        'Indiviudal notifications': {
            'PTPT': 'Indiviudal notifications'},
        'Collapsible': {
            'PTPT': 'Colapsável'},
        'Uncheck items from list -> DE + DB': {
            'PTPT': 'Uncheck items from list -> DE + DB'},
        'Text with icon': {
            'PTPT': 'Text with icon'},
        'Training Exercise 03': {
            'PTPT': 'Exercício de formação 03'},
        'Frequência de Empréstimo': {
            'PTPT': 'Frequência de Empréstimo'},
        'Total Internal Days': {
            'PTPT': 'Total Internal Days'},
        'TYPE OF EQUIPMENT': {
            'PTPT': 'TYPE OF EQUIPMENT'},
        'First level group': {
            'PTPT': 'Grupo de primeiro nível'},
        ' 1138': {
            'PTPT': 'Percentagem do valor objectivo a que corresponde o valor máximo.'},
        'Allow feature rotation': {
            'PTPT': 'Permitir a rotação de elementos'},
        'C&D': {
            'PTPT': 'C&D'},
        'EVERYTHING': {
            'PTPT': 'EVERYTHING'},
        'Encerrado': {
            'PTPT': 'Encerrado'},
        'Agrega por ano': {
            'PTPT': 'Agrega por ano'},
        'Numeric (Decimal)': {
            'PTPT': 'Numeric (Decimal)'},
        'Data Fixa': {
            'PTPT': 'Data Fixa'},
        'Tipo Meta': {
            'PTPT': 'Tipo Meta'},
        '  378': {
            'PTPT': 'Designação a dar em vez de "Perspetiva".'},
        'Vector Estratégico': {
            'PTPT': 'Vector Estratégico'},
        'DateTime': {
            'PTPT': 'DateTime'},
        'Em Curso': {
            'PTPT': 'Em Curso'},
        'Creation year of the airport': {
            'PTPT': 'Creation year of the airport'},
        'Acções de Melhoria': {
            'PTPT': 'Acções de Melhoria'},
        '   22': {
            'PTPT': 'This help is for a field of type numeric decimal'},
        'Numeric': {
            'PTPT': 'Numeric'},
        ' 1141': {
            'PTPT': 'This zone has a subtitle with the help.'},
        'Order no:': {
            'PTPT': 'Order no:'},
        'Stocks': {
            'PTPT': 'Stocks'},
        'Lista': {
            'PTPT': 'Lista'},
        'Process mode': {
            'PTPT': 'Process mode'},
        'Watermark': {
            'PTPT': 'Watermark'},
        'No Data?': {
            'PTPT': 'No Data?'},
        'Last price': {
            'PTPT': 'Last price'},
        '+1': {
            'PTPT': '+1'},
        'Sale': {
            'PTPT': 'Sale'},
        'Timeline - Years': {
            'PTPT': 'Timeline - Years'},
        '  414': {
            'PTPT': 'Titulo no kpi'},
        '2ªClasse': {
            'PTPT': '2ªClasse'},
        '   46': {
            'PTPT': 'Nome pelo qual o responsável é conhecido na Organização / Instituição.'},
        'Three': {
            'PTPT': 'Three'},
        'Name': {
            'PTPT': 'Name'},
        'Existence': {
            'PTPT': 'Existence'},
        'T1': {
            'PTPT': 'T1'},
        'Data de partida (horas)': {
            'PTPT': 'Data de partida (horas)'},
        'To whom the message was sent': {
            'PTPT': 'To whom the message was sent'},
        '  275': {
            'PTPT': 'Criar de forma automática metas e dados'},
        'Data Quality': {
            'PTPT': 'Qualidade de dados'},
        '  332': {
            'PTPT': 'Selecionar no caso de este objetivo pertencer ao conjunto de objetivos de maior relevância, cuja soma de ponderações atinge 50% das ponderações dos objetivos operacionais.'},
        'Anexos': {
            'PTPT': 'Anexos'},
        'Order lines': {
            'PTPT': 'Order lines'},
        'OpenBank': {
            'PTPT': 'OpenBank'},
        'Type (Numeric)': {
            'PTPT': 'Type (Numeric)'},
        'Date Time Second': {
            'PTPT': 'Date Time Second'},
        'REGISTO DE NOVO UTILIZADOR': {
            'PTPT': 'REGISTO DE NOVO UTILIZADOR'},
        'Tentativas de fecho': {
            'PTPT': 'Tentativas de fecho'},
        'Customer': {
            'PTPT': 'Cliente'},
        'Average of Projects': {
            'PTPT': 'Average of Projects'},
        'Acquisition:': {
            'PTPT': 'Acquisition:'},
        'Estrategia': {
            'PTPT': 'Estrategia'},
        ' 1108_VERBOSE': {
            'PTPT': 'Description: Address and shipping information. Used to store additional addresses for an account or contact.\n\nVersion: 1.2.1\n\ncdmSchemas:["/core/applicationCommon/Address.cdm.json/Address/hasAttributes/attributesAddedAtThisScope"]'},
        'Contact Data': {
            'PTPT': 'Contact Data'},
        'Alerta Sup.': {
            'PTPT': 'Alerta Sup.'},
        'Input Quantity': {
            'PTPT': 'Input Quantity'},
        'Output No:': {
            'PTPT': 'Output No:'},
        'QR Code': {
            'PTPT': 'QR Code'},
        'Cor': {
            'PTPT': 'Cor'},
        'Sign documents pdf -> DB + AD': {
            'PTPT': 'Sign documents pdf -> DB + AD'},
        'XPTO Client': {
            'PTPT': 'XPTO Client'},
        'Propescção': {
            'PTPT': 'Propescção'},
        'Fevereiro': {
            'PTPT': 'Fevereiro'},
        'Location extension': {
            'PTPT': 'Location extension'},
        'Janeiro': {
            'PTPT': 'Janeiro'},
        'Data de partida (DD/MM/ANO)': {
            'PTPT': 'Data de partida (DD/MM/ANO)'},
        'Cancelar': {
            'PTPT': 'Cancelar'},
        '  268': {
            'PTPT': 'Mau resultado'},
        '>>LOCATION EXTENSION': {
            'PTPT': '>>LOCATION EXTENSION'},
        'Total Pontos Potenciais': {
            'PTPT': 'Total Pontos Potenciais'},
        'Idioma': {
            'PTPT': 'Idioma'},
        'Airlines': {
            'PTPT': 'Companhias aéreas'},
        'Digital Attachement': {
            'PTPT': 'Digital Attachement'},
        'A validação da tabela deu um warning': {
            'PTPT': 'A validação da tabela deu um warning'},
        'Teste 2': {
            'PTPT': 'Teste 2'},
        'Organization': {
            'PTPT': 'Organization'},
        'Change': {
            'PTPT': 'Alterar'},
        'Delete Single record': {
            'PTPT': 'Eliminar registo único'},
        'Closed Map': {
            'PTPT': 'Closed Map'},
        'Block field': {
            'PTPT': 'Bloquear campo'},
        'Previous value': {
            'PTPT': 'Previous value'},
        'Ponto de Origem (ME)': {
            'PTPT': 'Ponto de Origem (ME)'},
        'Lag/Lead': {
            'PTPT': 'Lag/Lead'},
        'January': {
            'PTPT': 'January'},
        'Receipt line': {
            'PTPT': 'Receipt line'},
        '  319': {
            'PTPT': 'Imagem'},
        'Muito Má': {
            'PTPT': 'Muito Má'},
        'Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)': {
            'PTPT': 'Numeric  8.2 real=float(24) (precision 7 digits) (storage: 4 byte)'},
        'Airports From': {
            'PTPT': 'Airports From'},
        '  358': {
            'PTPT': 'Visível na página principal?'},
        '   89': {
            'PTPT': 'Detalhe da Missão. Posicionamento, atitudes e passos necessários para a concretização da Visão.'},
        'Qtd. movimentações': {
            'PTPT': 'Qtd. movimentações'},
        'Since:': {
            'PTPT': 'Since:'},
        'Semana': {
            'PTPT': 'Semana'},
        'Opções globais': {
            'PTPT': 'Opções globais'},
        'Dadatarian': {
            'PTPT': 'Dadatarian'},
        'Aggregating OU\'s Evaluation': {
            'PTPT': 'Aggregating OU\'s Evaluation'},
        'Shipping types': {
            'PTPT': 'Shipping types'},
        'Enforce form conditions': {
            'PTPT': 'Cumprir condições do formulário'},
        'Group 1': {
            'PTPT': 'Group 1'},
        'Saves on DB?': {
            'PTPT': 'Saves on DB?'},
        'Menu 2': {
            'PTPT': 'Menu 2'},
        'ID de Origem': {
            'PTPT': 'ID de Origem'},
        'Licence plate': {
            'PTPT': 'Licence plate'},
        'Data Início': {
            'PTPT': 'Data Início'},
        'Founded in': {
            'PTPT': 'Founded in'},
        'To check': {
            'PTPT': 'To check'},
        'ACCORDION': {
            'PTPT': 'ACCORDION'},
        'Date time': {
            'PTPT': 'Date time'},
        'GLN': {
            'PTPT': 'GLN'},
        'Closed map': {
            'PTPT': 'Closed map'},
        'Limite superado': {
            'PTPT': 'Limite superado'},
        'Address type': {
            'PTPT': 'Address type'},
        'Objective (Instance)': {
            'PTPT': 'Objective (Instance)'},
        'Max value': {
            'PTPT': 'Max value'},
        'GoogleMaps': {
            'PTPT': 'GoogleMaps'},
        'Order Number': {
            'PTPT': 'Order Number'},
        'Qualification': {
            'PTPT': 'Qualification'},
        '  390': {
            'PTPT': 'Data de Fim'},
        'Avião': {
            'PTPT': 'Avião'},
        'Arrival Time': {
            'PTPT': 'Arrival Time'},
        'ID of the notification that generated the message': {
            'PTPT': 'ID of the notification that generated the message'},
        'Building': {
            'PTPT': 'Edifício'},
        'Terrain': {
            'PTPT': 'Terrain'},
        'Data type': {
            'PTPT': 'Data type'},
        'Number of lending': {
            'PTPT': 'Number of lending'},
        'Valor 0%': {
            'PTPT': 'Valor 0%'},
        'Text color': {
            'PTPT': 'Text color'},
        'Calculated State': {
            'PTPT': 'Calculated State'},
        'Departure date (hours)': {
            'PTPT': 'Departure date (hours)'},
        '   56': {
            'PTPT': 'E-mail do responsável para o qual serão dirigidas todas as notificações referentes ao indicador do qual são responsáveis.'},
        'Apartment types': {
            'PTPT': 'Tipos de apartamentos'},
        'Property type': {
            'PTPT': 'Property type'},
        '100%': {
            'PTPT': '100%'},
        'Cumprir condições do formulário': {
            'PTPT': 'Cumprir condições do formulário'},
        'Menor é Melhor': {
            'PTPT': 'Menor é Melhor'},
        'Não Aplicável': {
            'PTPT': 'Não Aplicável'},
        '>>PERSON': {
            'PTPT': '>>PERSON'},
        'Fixed in': {
            'PTPT': 'Fixed in'},
        'Hide field': {
            'PTPT': 'Esconder campo'},
        'New Output': {
            'PTPT': 'New Output'},
        'Tipo Avaliação': {
            'PTPT': 'Tipo Avaliação'},
        'Year NUMBER': {
            'PTPT': 'Year NUMBER'},
        '  381': {
            'PTPT': 'Designação a dar em vez de "Projeto".'},
        ' 1028': {
            'PTPT': 'Indica se é um mapa pai (Agregador)'},
        'Icon': {
            'PTPT': 'Icon'},
        '  325': {
            'PTPT': 'Número de ordem utilizado para ordenação dos objetivos'},
        'Reason': {
            'PTPT': 'Reason'},
        '   15': {
            'PTPT': 'Documento com catálogo'},
        '>>Asset': {
            'PTPT': '>>Asset'},
        'Extensão': {
            'PTPT': 'Extensão'},
        'Level': {
            'PTPT': 'Level'},
        'Data audit': {
            'PTPT': 'Data audit'},
        'Receipt of good': {
            'PTPT': 'Receipt of good'},
        'Boxes (Strategic Map)': {
            'PTPT': 'Boxes (Strategic Map)'},
        'Professional Category Evolution': {
            'PTPT': 'Professional Category Evolution'},
        'Static Image': {
            'PTPT': 'Static Image'},
        'SMTP Server': {
            'PTPT': 'SMTP Server'},
        'Assistance': {
            'PTPT': 'Assistance'},
        ' 1107_VERBOSE': {
            'PTPT': 'If the end of the period is missing, it means no end was known or planned at the time the instance was created. The start may be in the past, and the end date in the future, which means that period is expected/planned to end at that time.\n\nThe high value includes any matching date/time. i.e. 2012-02-03T10:00:00 is in a period that has an end value of 2012-02-03.'},
        'Information Elements': {
            'PTPT': 'Information Elements'},
        ' 1125_VERBOSE': {
            'PTPT': 'help radio button opçao 2 verboso'},
        'Sender': {
            'PTPT': 'Sender'},
        'Entry': {
            'PTPT': 'Entry'},
        'Translated': {
            'PTPT': 'Translated'},
        '  117': {
            'PTPT': 'Este campo serve para criar uma fórmula de recolha de dados. Neste campo é possível criar fórmulas como no Excel. Atenção, apenas são permitidas as operações matemáticas primárias (+ - x / ). Os campos a utilizarem na fórmula devem estar entre paréntesis rectos e não devem usar quaisquer acentos ortográficos, aspas ou plicas no seu conteúdo (exemplo: {formula} ). Como exemplo de uma fórmula temos : ({valor1}+{valor2})/{valor3}) .'},
        'A traduzir': {
            'PTPT': 'A traduzir'},
        'LOCAL': {
            'PTPT': 'LOCAL'},
        'Reporting services': {
            'PTPT': 'Reporting services'},
        'Movable': {
            'PTPT': 'Movable'},
        'Non Limited Properties': {
            'PTPT': 'Non Limited Properties'},
        'Before': {
            'PTPT': 'Before'},
        'Ano de Criação do Aeroporto': {
            'PTPT': 'Ano de Criação do Aeroporto'},
        'Number of people': {
            'PTPT': 'Number of people'},
        'Imóveis na região': {
            'PTPT': 'Imóveis na região'},
        'Foreign key': {
            'PTPT': 'Foreign key'},
        'Billing': {
            'PTPT': 'Billing'},
        '1ª Viagem (Enumeração Lógica': {
            'PTPT': '1ª Viagem (Enumeração Lógica'},
        ' 1103': {
            'PTPT': 'Country - a nation as commonly understood or generally accepted.'},
        ' 1135': {
            'PTPT': 'Valor máximo para o indicador (corresponde ao valor máximo para a barra do indicador). Para indicadores QUAR de polaridade crescente este campo corresponde ao Valor Crítico.'},
        'Pre-approach': {
            'PTPT': 'Pre-approach'},
        'Comforter': {
            'PTPT': 'Comforter'},
        '1. c-groupbox--title-background': {
            'PTPT': '1. c-groupbox--title-background'},
        'Role': {
            'PTPT': 'Role'},
        'Perc. Mau': {
            'PTPT': 'Perc. Mau'},
        'Field List': {
            'PTPT': 'Field List'},
        'Closing Date': {
            'PTPT': 'Closing Date'},
        'PRICES': {
            'PTPT': 'PRICES'},
        'Fixed collection date': {
            'PTPT': 'Fixed collection date'},
        'Alphabetic 2:': {
            'PTPT': 'Alphabetic 2:'},
        'Maximum Sup.': {
            'PTPT': 'Maximum Sup.'},
        'Bad rate': {
            'PTPT': 'Bad rate'},
        'Physical': {
            'PTPT': 'Physical'},
        'Falhou a condição de escrita do form com apply': {
            'PTPT': 'Falhou a condição de escrita do form com apply'},
        'Changed on': {
            'PTPT': 'Alterado em'},
        'Sigla': {
            'PTPT': 'Sigla'},
        'Não Apaga (ME)': {
            'PTPT': 'Não Apaga (ME)'},
        'Home text': {
            'PTPT': 'Home text'},
        'Acessos região': {
            'PTPT': 'Acessos região'},
        'Airline name': {
            'PTPT': 'Nome da companhia aérea'},
        'Ministry': {
            'PTPT': 'Ministry'},
        'Scorecoard Type': {
            'PTPT': 'Scorecoard Type'},
        'Checked': {
            'PTPT': 'Checked'},
        'Responsibles for BSC': {
            'PTPT': 'Responsibles for BSC'},
        'Entity legal name': {
            'PTPT': 'Entity legal name'},
        'Destination Y (ME)': {
            'PTPT': 'Destination Y (ME)'},
        'Quidgest - Management Consultants, S.A.': {
            'PTPT': 'Quidgest - Management Consultants, S.A.'},
        'Mapas Estratégicos': {
            'PTPT': 'Mapas Estratégicos'},
        'Class da viagem': {
            'PTPT': 'Class da viagem'},
        'Equip': {
            'PTPT': 'Equip'},
        'Management Cycle Documents': {
            'PTPT': 'Management Cycle Documents'},
        '  230': {
            'PTPT': 'Contagem só com os dias úteis.'},
        'Last photo attached': {
            'PTPT': 'Last photo attached'},
        'Falhou a condição de visualização no form': {
            'PTPT': 'Falhou a condição de visualização no form'},
        'Baggage Types': {
            'PTPT': 'Baggage Types'},
        'Total References': {
            'PTPT': 'Total References'},
        '>>SUPPLIER': {
            'PTPT': '>>SUPPLIER'},
        'Row order groups level 1': {
            'PTPT': 'Row order groups level 1'},
        '1117': {
            'PTPT': 'Help in the year field'},
        'Value (Year N-2)': {
            'PTPT': 'Value (Year N-2)'},
        'Fotos': {
            'PTPT': 'Fotos'},
        'Indicadores Maus': {
            'PTPT': 'Indicadores Maus'},
        'Cancelado': {
            'PTPT': 'Cancelado'},
        'Object Type': {
            'PTPT': 'Object Type'},
        '1115_VERBOSE': {
            'PTPT': 'Help in the text field verbose'},
        'leadership numb': {
            'PTPT': 'leadership numb'},
        'Acronym for map': {
            'PTPT': 'Acronym for map'},
        'Indicadores': {
            'PTPT': 'Indicadores'},
        'Repair no.': {
            'PTPT': 'Repair no.'},
        '@mixed_zones': {
            'PTPT': 'Three zones:\n<ol>
  <li>c-groupbox--title-background</li>
  <li>c-groupbox--minor</li>
  <li>c-groupbox--background</li>
</ol>
'},
        'Remove from slaughtered downed equipment': {
            'PTPT': 'Remove from slaughtered downed equipment'},
        'Superar Objeções': {
            'PTPT': 'Superar Objeções'},
        'Bad': {
            'PTPT': 'Bad'},
        'Multiple selection of equipment types': {
            'PTPT': 'Multiple selection of equipment types'},
        'Goord Perc.': {
            'PTPT': 'Goord Perc.'},
        'Men': {
            'PTPT': 'Men'},
        'Note': {
            'PTPT': 'Note'},
        'Language': {
            'PTPT': 'Language'},
        'Property Type': {
            'PTPT': 'Property Type'},
        'Integration Formula': {
            'PTPT': 'Integration Formula'},
        'Real Percentage': {
            'PTPT': 'Real Percentage'},
        'Global Map': {
            'PTPT': 'Global Map'},
        '  123': {
            'PTPT': 'Valor do dado'},
        'Visualization': {
            'PTPT': 'Visualization'},
        'All people': {
            'PTPT': 'Todas as pessoas'},
        'Radio Btn': {
            'PTPT': 'Radio Btn'},
        'Maior é Melhor': {
            'PTPT': 'Maior é Melhor'},
        'Posição Y': {
            'PTPT': 'Posição Y'},
        '  202': {
            'PTPT': 'Colocação do número de telefone.'},
        'Address Postal Code': {
            'PTPT': 'Address Postal Code'},
        'Airplane': {
            'PTPT': 'Avião'},
        'Inactive': {
            'PTPT': 'Inactive'},
        '1122': {
            'PTPT': 'Help in the Menu'},
        'Type of article': {
            'PTPT': 'Type of article'},
        'Planeada': {
            'PTPT': 'Planeada'},
        'Erro': {
            'PTPT': 'Erro'},
        'Não existe CC (contabilidade de custos)': {
            'PTPT': 'Não existe CC (contabilidade de custos)'},
        'Address Type Code': {
            'PTPT': 'Address Type Code'},
        'Overview': {
            'PTPT': 'Overview'},
        'Official No.': {
            'PTPT': 'Official No.'},
        'Unused items': {
            'PTPT': 'Unused items'},
        'Goal': {
            'PTPT': 'Goal'},
        '  119': {
            'PTPT': 'Criado em'},
        '1115': {
            'PTPT': 'Help in the text field'},
        'Related Table (Basic)': {
            'PTPT': 'Related Table (Basic)'},
        'Training Exercise 09': {
            'PTPT': 'Exercício de formação 09'},
        'Ordem Pai': {
            'PTPT': 'Ordem Pai'},
        'collapsible group -> q-group-collapsible--audit': {
            'PTPT': 'collapsible group -> q-group-collapsible--audit'},
        'Anos': {
            'PTPT': 'Anos'},
        ' 1087': {
            'PTPT': 'A communication address at a home.'},
        'Group markers in cluster': {
            'PTPT': 'Group markers in cluster'},
        '   23': {
            'PTPT': 'This help is for a field of type Currency'},
        'Período Seguinte': {
            'PTPT': 'Período Seguinte'},
        'Outubro': {
            'PTPT': 'Outubro'},
        '  341': {
            'PTPT': 'Lista de coordenadas x,y separadas por ; que determinam os pontos de um poligono'},
        'Priority': {
            'PTPT': 'Priority'},
        'List of x,y coordinates separated by ; that determine the points of a polygon': {
            'PTPT': 'List of x,y coordinates separated by ; that determine the points of a polygon'},
        'COMPANY': {
            'PTPT': 'COMPANY'},
        'Dispatch of goods': {
            'PTPT': 'Dispatch of goods'},
        'Gantt - Scale': {
            'PTPT': 'Gantt - Scale'},
        'Exercise 1: Relational Model': {
            'PTPT': 'Exercise 1: Relational Model'},
        ' 1129': {
            'PTPT': 'Valor objectivo para este indicador na data de referência indicada. A meta não pode ser igual ao valor de referência 0%. No caso de à data de referência não existir meta, vale a primeira meta posterior.'},
        ' 1104': {
            'PTPT': 'Time period when address was/is in use.'},
        'Bathrooms': {
            'PTPT': 'Bathrooms'},
        'Training Exercise 13': {
            'PTPT': 'Exercício de formação 13'},
        'Superado': {
            'PTPT': 'Superado'},
        'No decomission': {
            'PTPT': 'No decomission'},
        'Days for return': {
            'PTPT': 'Days for return'},
        'Aeroporto': {
            'PTPT': 'Aeroporto'},
        'Time (Hours-Minutes)': {
            'PTPT': 'Time (Hours-Minutes)'},
        'Map Icon': {
            'PTPT': 'Map Icon'},
        'Objective Type': {
            'PTPT': 'Objective Type'},
        'Password': {
            'PTPT': 'Password'},
        'Office supplies': {
            'PTPT': 'Office supplies'},
        '   74': {
            'PTPT': 'Carga de trabalho, nº de horas trabalhadas previsíveis para a concretização da Inicitaiva / Projecto.'},
        ' 1148': {
            'PTPT': 'Uma ajuda que levará imagem no verboso.'},
        'Alert 1': {
            'PTPT': 'Alert 1'},
        'Perc. Máximo': {
            'PTPT': 'Perc. Máximo'},
        '  223': {
            'PTPT': 'Utilizador que insere dados'},
        'Ponderação': {
            'PTPT': 'Ponderação'},
        ' 1066': {
            'PTPT': 'Meta Real'},
        'Passport Number': {
            'PTPT': 'Passport Number'},
        'Perc. Alerta': {
            'PTPT': 'Perc. Alerta'},
        '  289': {
            'PTPT': 'Data de fim'},
        'Tipos de segmentos': {
            'PTPT': 'Tipos de segmentos'},
        'Repairs': {
            'PTPT': 'Repairs'},
        'parentId Type': {
            'PTPT': 'parentId Type'},
        'REGISTRATION ON THE PLATFORM': {
            'PTPT': 'REGISTRATION ON THE PLATFORM'},
        'Do you want to delete this record?': {
            'PTPT': 'Pretende apagar este registo?'},
        'Password date': {
            'PTPT': 'Password date'},
        'Dirigentes e Funcionários': {
            'PTPT': 'Dirigentes e Funcionários'},
        ' 1111': {
            'PTPT': 'Unique identifier of the customer address'},
        'Família de equipamento': {
            'PTPT': 'Família de equipamento'},
        'Boolean': {
            'PTPT': 'Boolean'},
        'Asset': {
            'PTPT': 'Asset'},
        'Económica': {
            'PTPT': 'Económica'},
        'Create Mock Person': {
            'PTPT': 'Create Mock Person'},
        '  316': {
            'PTPT': 'Integra c/ Documental?'},
        'Reports': {
            'PTPT': 'Reports'},
        'Manuals load': {
            'PTPT': 'Manuals load'},
        'Agendado para execução': {
            'PTPT': 'Agendado para execução'},
        'Concluído': {
            'PTPT': 'Concluído'},
        '  352': {
            'PTPT': 'Combinação indicador, serviço e uag'},
        'Respeita intervalo de tempo?': {
            'PTPT': 'Respeita intervalo de tempo?'},
        'Category type': {
            'PTPT': 'Category type'},
        '  201': {
            'PTPT': 'Inserção do nome da localidade.'},
        'Logo 1': {
            'PTPT': 'Logo 1'},
        'Boarding Pass ID': {
            'PTPT': 'Boarding Pass ID'},
        'Street': {
            'PTPT': 'Street'},
        '  200': {
            'PTPT': 'Inserção da rua, número e andar .'},
        'Quidgest - Rest': {
            'PTPT': 'Quidgest - Rest'},
        'Vertical Wizard': {
            'PTPT': 'Vertical Wizard'},
        'Sequential No.:': {
            'PTPT': 'Sequential No.:'},
        'To': {
            'PTPT': 'To'},
        'Data de criação (DD/MM/YY)': {
            'PTPT': 'Data de criação (DD/MM/YY)'},
        'Advanced Patterns': {
            'PTPT': 'Advanced Patterns'},
        'Details -> c-groupbox--minor-border-top c-groupbox--background': {
            'PTPT': 'Detalhes  -> c-groupbox--minor-border-top c-groupbox--background'},
        'Strategic Maps': {
            'PTPT': 'Strategic Maps'},
        'Acquisition': {
            'PTPT': 'Acquisition'},
        'Date fields': {
            'PTPT': 'Date fields'},
        '   76': {
            'PTPT': 'Estado da Iniciativa / Projecto de acordo com as várias fases e ou situações possíveis.'},
        'Iniciative Responsible': {
            'PTPT': 'Iniciative Responsible'},
        'Mechanografic number': {
            'PTPT': 'Mechanografic number'},
        'Facility types': {
            'PTPT': 'Facility types'},
        'antecedence': {
            'PTPT': 'antecedence'},
        'COMPANY PARENTS': {
            'PTPT': 'PAIS DA EMPRESA'},
        '  413': {
            'PTPT': 'Icone de titulo no kpi'},
        'Reclamações': {
            'PTPT': 'Reclamações'},
        '   57': {
            'PTPT': 'Indicação se está disponível para notificações individuais.'},
        'Objectivo': {
            'PTPT': 'Objectivo'},
        '>>Facility type': {
            'PTPT': '>>Facility type'},
        'Data Type': {
            'PTPT': 'Data Type'},
        'Geographic coordinate': {
            'PTPT': 'Geographic coordinate'},
        'Real Estate': {
            'PTPT': 'Real Estate'},
        ' 1100_VERBOSE': {
            'PTPT': 'District is sometimes known as county, but in some regions \'county\' is used in place of city (municipality), so county name should be conveyed in city instead.'},
        'Bad Limit Perc.': {
            'PTPT': 'Bad Limit Perc.'},
        'Image thumbnail': {
            'PTPT': 'Image thumbnail'},
        'Quantity of transactions': {
            'PTPT': 'Quantity of transactions'},
        'Building age': {
            'PTPT': 'Idade do edifício'},
        'Multiform': {
            'PTPT': 'Multiform'},
        'Specific path with conditions popup afte MB': {
            'PTPT': 'Specific path with conditions popup afte MB'},
        '   78': {
            'PTPT': 'Campo preenchido automáticamente a partir do somatório das penalizações por atrazo na conclusão das Actividades da Iniciativa / Projecto.'},
        'A cancelar': {
            'PTPT': 'A cancelar'},
        'Process info': {
            'PTPT': 'Process info'},
        'Home Team': {
            'PTPT': 'Home Team'},
        'Parada': {
            'PTPT': 'Parada'},
        'Locais da regra': {
            'PTPT': 'Locais da regra'},
        'Training Exercise 01': {
            'PTPT': 'Exercício de formação 01'},
        'Interested party': {
            'PTPT': 'Interested party'},
        'Lado': {
            'PTPT': 'Lado'},
        'Date of birth': {
            'PTPT': 'Date of birth'},
        'Spent in Hours': {
            'PTPT': 'Spent in Hours'},
        'Tabs': {
            'PTPT': 'Tabs'},
        'Products': {
            'PTPT': 'Products'},
        'Tipo Scorecard': {
            'PTPT': 'Tipo Scorecard'},
        'Order line': {
            'PTPT': 'Order line'},
        'Organism': {
            'PTPT': 'Organism'},
        'Organic Unit': {
            'PTPT': 'Organic Unit'},
        'Interno': {
            'PTPT': 'Interno'},
        'Modified by': {
            'PTPT': 'Modified by'},
        'Team of players': {
            'PTPT': 'Team of players'},
        'Nome do Artigo': {
            'PTPT': 'Nome do Artigo'},
        'Year (numbers)': {
            'PTPT': 'Year (numbers)'},
        'Menu 1': {
            'PTPT': 'Menu 1'},
        'Ticket price at tenths': {
            'PTPT': 'Ticket price at tenths'},
        'Kit component': {
            'PTPT': 'Kit component'},
        'Migrate status/report on initiatives and tasks': {
            'PTPT': 'Migrate status/report on initiatives and tasks'},
        'Santander': {
            'PTPT': 'Santander'},
        'Start': {
            'PTPT': 'Start'},
        'Creation: Date': {
            'PTPT': 'Creation: Date'},
        'Activity Type': {
            'PTPT': 'Activity Type'},
        'Superar objeções': {
            'PTPT': 'Superar objeções'},
        'Input Fields': {
            'PTPT': 'Input Fields'},
        'Total Penalizações': {
            'PTPT': 'Total Penalizações'},
        '{GQT_UNUSED_ITEMS_Count} items not in use.': {
            'PTPT': '{GQT_UNUSED_ITEMS_Count} items not in use.'},
        'SSL?': {
            'PTPT': 'SSL?'},
        'Average': {
            'PTPT': 'Average'},
        'Management': {
            'PTPT': 'Management'},
        'Does it integrate with Document': {
            'PTPT': 'Does it integrate with Document'},
        'Types (Numeric)': {
            'PTPT': 'Types (Numeric)'},
        'User Authorization': {
            'PTPT': 'User Authorization'},
        'Attached:': {
            'PTPT': 'Attached:'},
        'Company': {
            'PTPT': 'Company'},
        'SET': {
            'PTPT': 'SET'},
        'Size': {
            'PTPT': 'Size'},
        'Accompaniment': {
            'PTPT': 'Accompaniment'},
        '>GLOBAL ARTICLE': {
            'PTPT': '>GLOBAL ARTICLE'},
        'Prospecting': {
            'PTPT': 'Prospecting'},
        'Administrative Genders': {
            'PTPT': 'Administrative Genders'},
        'High': {
            'PTPT': 'High'},
        'Good points': {
            'PTPT': 'Good points'},
        'Timeline Month- Armazém': {
            'PTPT': 'Timeline Month- Armazém'},
        'Total de referências': {
            'PTPT': 'Total de referências'},
        'Companhias Aéreas': {
            'PTPT': 'Companhias Aéreas'},
        'Abordagem efectuada': {
            'PTPT': 'Abordagem efectuada'},
        'Number of employees': {
            'PTPT': 'Number of employees'},
        'Manufacturers': {
            'PTPT': 'Manufacturers'},
        '>>ASSET': {
            'PTPT': '>>ASSET'},
        '  100': {
            'PTPT': 'Valor em percentagem da meta para a emissão de alerta, sempre que o valor realizado lhe seja igual ou superior.'},
        'Data Aprovação': {
            'PTPT': 'Data Aprovação'},
        'No:': {
            'PTPT': 'No:'},
        'Alphabetic 3': {
            'PTPT': 'Alphabetic 3'},
        'Aggregator Assessment Body': {
            'PTPT': 'Aggregator Assessment Body'},
        'Description of the repair': {
            'PTPT': 'Description of the repair'},
        'Orçamento': {
            'PTPT': 'Orçamento'},
        'Multiline text': {
            'PTPT': 'Multiline text'},
        'Table (Foreign Keys)': {
            'PTPT': 'Table (Foreign Keys)'},
        'Locale': {
            'PTPT': 'Locale'},
        'Extended Form support': {
            'PTPT': 'Extended Form support'},
        'Indicadores Bons': {
            'PTPT': 'Indicadores Bons'},
        'Translated title': {
            'PTPT': 'Translated title'},
        'Razoável': {
            'PTPT': 'Razoável'},
        'Module': {
            'PTPT': 'Module'},
        'Address Type': {
            'PTPT': 'Address Type'},
        'Aba': {
            'PTPT': 'Aba'},
        'Departure date (seconds)': {
            'PTPT': 'Departure date (seconds)'},
        'Recipient': {
            'PTPT': 'Recipient'},
        'Organizations, New Organizations': {
            'PTPT': 'Organizations, New Organizations'},
        'Land': {
            'PTPT': 'Land'},
        'Access': {
            'PTPT': 'Access'},
        'Point in Map': {
            'PTPT': 'Point in Map'},
        'Componente': {
            'PTPT': 'Componente'},
        'Choose Region': {
            'PTPT': 'Choose Region'},
        '  278': {
            'PTPT': 'Designação da imagem'},
        'Categorize': {
            'PTPT': 'Categorize'},
        'Card-Img-Thumbnail': {
            'PTPT': 'Card-Img-Thumbnail'},
        'LeafletDraw': {
            'PTPT': 'LeafletDraw'},
        'Letter color': {
            'PTPT': 'Letter color'},
        '>>LOCATION': {
            'PTPT': '>>LOCATION'},
        'Address Number': {
            'PTPT': 'Address Number'},
        'Prospecção': {
            'PTPT': 'Prospecção'},
        'Create a website alert': {
            'PTPT': 'Create a website alert'},
        'Instant entrance': {
            'PTPT': 'Instant entrance'},
        'Finished': {
            'PTPT': 'Finished'},
        'There must be at least one employee working in this warehouse': {
            'PTPT': 'There must be at least one employee working in this warehouse'},
        'Project Description': {
            'PTPT': 'Project Description'},
        'Text Fields': {
            'PTPT': 'Text Fields'},
        'Reflection QUAR': {
            'PTPT': 'Reflection QUAR'},
        '  441': {
            'PTPT': 'Metodo de recolha de dados'},
        'ING': {
            'PTPT': 'ING'},
        'Project Bonus Days': {
            'PTPT': 'Project Bonus Days'},
        'Tables': {
            'PTPT': 'Tables'},
        '  424': {
            'PTPT': 'Moeda'},
        'Nationality': {
            'PTPT': 'Nationality'},
        '1ªClasse': {
            'PTPT': '1ªClasse'},
        'VIEW': {
            'PTPT': 'VIEW'},
        '  108': {
            'PTPT': 'Denominação breve do Objectivo de modo a que o mesmo seja claramente identificado em todos os quadros e relatórios.'},
        'Output:': {
            'PTPT': 'Output:'},
        'Return': {
            'PTPT': 'Return'},
        'Action button - Edit': {
            'PTPT': 'Botão de ação - Editar'},
        'Dependency': {
            'PTPT': 'Dependency'},
        '\'Person\'': {
            'PTPT': '\'Person\''},
        'Controllers': {
            'PTPT': 'Controllers'},
        'Teams': {
            'PTPT': 'Teams'},
        'People of a category': {
            'PTPT': 'People of a category'},
        'Legal name': {
            'PTPT': 'Legal name'},
        'Icon width': {
            'PTPT': 'Icon width'},
        'Vision (Instance)': {
            'PTPT': 'Vision (Instance)'},
        '  392': {
            'PTPT': 'Data Mínima'},
        'ImageMagnifier': {
            'PTPT': 'ImageMagnifier'},
        'Patients': {
            'PTPT': 'Patients'},
        ' 1130': {
            'PTPT': 'Percentagem do valor objectivo a que corresponde o valor de alerta.'},
        'Affinities': {
            'PTPT': 'Affinities'},
        '  102': {
            'PTPT': 'Valor por omissão em percentagem da meta para o limite superior do intervalo \'Superado\'. Pretende-se com este intervalo destacar valores realizados claramente inferiores ao definido como meta, numa optica de claramente superado. Atente-se que estamos perante situações de \'menor é melhor\''},
        'with routine - delete row': {
            'PTPT': 'with routine - delete row'},
        'Require field': {
            'PTPT': 'Campo obrigatório'},
        'Map with facilities:': {
            'PTPT': 'Map with facilities:'},
        '   82': {
            'PTPT': 'Pontos totais finais considerando os pontos das actividades,e bonificação atribuída. Este campo é preenchido automáticamente.'},
        'Async process argument': {
            'PTPT': 'Async process argument'},
        'Y Position': {
            'PTPT': 'Y Position'},
        'Boarding Pass': {
            'PTPT': 'Boarding Pass'},
        'Variável': {
            'PTPT': 'Variável'},
        '  183': {
            'PTPT': 'Antecedência em dias com que serão notificados os responsáveis.'},
        'Icon height': {
            'PTPT': 'Icon height'},
        'Units': {
            'PTPT': 'Units'},
        'Row ordering in group, 1 level (Integer field)': {
            'PTPT': 'Row ordering in group, 1 level (Integer field)'},
        'Type C': {
            'PTPT': 'Type C'},
        '% Limite Superado': {
            'PTPT': '% Limite Superado'},
        'Gravar': {
            'PTPT': 'Gravar'},
        '  328': {
            'PTPT': 'Prefixo dos indicadores'},
        'Bottom': {
            'PTPT': 'Bottom'},
        'Escalas dos gráficos Gantt': {
            'PTPT': 'Escalas dos gráficos Gantt'},
        'Sexo': {
            'PTPT': 'Sexo'},
        'Training Exercises': {
            'PTPT': 'Exercícios de formação'},
        '>ANO': {
            'PTPT': '>ANO'},
        'Postal': {
            'PTPT': 'Postal'},
        '  426': {
            'PTPT': 'Porta SMTP'},
        '  255': {
            'PTPT': 'Servidor que se ocupa de enviar as mensagens que escrevem os utilizadores.'},
        'Records': {
            'PTPT': 'Records'},
        'Potenciais compradores': {
            'PTPT': 'Potenciais compradores'},
        'Falhou a validação do form com apply': {
            'PTPT': 'Falhou a validação do form com apply'},
        'Breaks down': {
            'PTPT': 'Breaks down'},
        'Timeline': {
            'PTPT': 'Timeline'},
        'Código do Organismo': {
            'PTPT': 'Código do Organismo'},
        ' 1067': {
            'PTPT': 'Valor Real'},
        ' 1126_VERBOSE': {
            'PTPT': 'help radio button opçao 1 verboso'},
        'Denpendency:': {
            'PTPT': 'Denpendency:'},
        'Authentication': {
            'PTPT': 'Authentication'},
        'Proyecto': {
            'PTPT': 'Proyecto'},
        'Ref': {
            'PTPT': 'Ref'},
        'Lending: Returned': {
            'PTPT': 'Lending: Returned'},
        ' 1104_VERBOSE': {
            'PTPT': 'Allows addresses to be placed in historical context.'},
        'Identification -> c-groupbox--minor': {
            'PTPT': 'Identification -> c-groupbox--minor'},
        'Trip Duration': {
            'PTPT': 'Trip Duration'},
        'Company Repair Number': {
            'PTPT': 'Número de reparação da empresa'},
        'IBAN (International Bank Account Number)': {
            'PTPT': 'IBAN (International Bank Account Number)'},
        'Open form': {
            'PTPT': 'Open form'},
        'Region access': {
            'PTPT': 'Region access'},
        'm²': {
            'PTPT': 'm²'},
        'Host': {
            'PTPT': 'Host'},
        '5 anos': {
            'PTPT': '5 anos'},
        'Identification of business opportunity': {
            'PTPT': 'Identification of business opportunity'},
        'Movements by type': {
            'PTPT': 'Movements by type'},
        'Total Activities Completed': {
            'PTPT': 'Total Activities Completed'},
        'Good sup.': {
            'PTPT': 'Good sup.'},
        'DESIGNAT': {
            'PTPT': 'DESIGNAT'},
        'Yes or no': {
            'PTPT': 'Yes or no'},
        'Company identification': {
            'PTPT': 'Identificação da empresa'},
        'Tradutions': {
            'PTPT': 'Tradutions'},
        'Logical (tinyint) (storage 1 byte)': {
            'PTPT': 'Logical (tinyint) (storage 1 byte)'},
        'T3 and others': {
            'PTPT': 'T3 e outros'},
        'Armazém': {
            'PTPT': 'Armazém'},
        'Perc. Sup': {
            'PTPT': 'Perc. Sup'},
        'Items': {
            'PTPT': 'Items'},
        '>LAST CATEGORY': {
            'PTPT': '>LAST CATEGORY'},
        'Out-of-date observation lendings': {
            'PTPT': 'Out-of-date observation lendings'},
        'Scheduling': {
            'PTPT': 'Scheduling'},
        '   14': {
            'PTPT': 'Previsão da frequência de empréstimo do equipamento.'},
        '  228': {
            'PTPT': 'Nome completo do organismo.'},
        'QWeb': {
            'PTPT': 'QWeb'},
        '   95': {
            'PTPT': 'Valor por omissão em percentagem da meta para o limite inferior do intervalo \'Superado\'. Pretende-se com este intervalo destacar valores realizados claramente acima do definido como meta, numa optica de claramente superado.'},
        '  229': {
            'PTPT': 'Mostra os mapas que já foram fechados.'},
        'External API address': {
            'PTPT': 'External API address'},
        'Ponderações SIADAP': {
            'PTPT': 'Ponderações SIADAP'},
        'Segments (Instance)': {
            'PTPT': 'Segments (Instance)'},
        'Executed by external app': {
            'PTPT': 'Executed by external app'},
        'Decomission:': {
            'PTPT': 'Decomission:'},
        'Programa': {
            'PTPT': 'Programa'},
        'Alert?': {
            'PTPT': 'Alert?'},
        'July': {
            'PTPT': 'July'},
        'No bate': {
            'PTPT': 'No bate'},
        '  109': {
            'PTPT': 'Descrição detalhada do Objectivo.'},
        'Recorrente': {
            'PTPT': 'Recorrente'},
        'Documents Required Duplicated': {
            'PTPT': 'Documents Required Duplicated'},
        'GTIN': {
            'PTPT': 'GTIN'},
        'MANAGER': {
            'PTPT': 'MANAGER'},
        'Máximo': {
            'PTPT': 'Máximo'},
        'Limite Mínimo': {
            'PTPT': 'Limite Mínimo'},
        'Bom Sup.': {
            'PTPT': 'Bom Sup.'},
        '1122_VERBOSE': {
            'PTPT': 'Help in the Menu verbose'},
        'Output formats': {
            'PTPT': 'Output formats'},
        'Servidor SMTP': {
            'PTPT': 'Servidor SMTP'},
        'Technical areas': {
            'PTPT': 'Technical areas'},
        'Background': {
            'PTPT': 'Background'},
        'Birth': {
            'PTPT': 'Birth'},
        'Reference date': {
            'PTPT': 'Reference date'},
        'Valor Único': {
            'PTPT': 'Valor Único'},
        'Image Top': {
            'PTPT': 'Image Top'},
        'Anexos digitais': {
            'PTPT': 'Anexos digitais'},
        'Campos com condições no formulário': {
            'PTPT': 'Campos com condições no formulário'},
        ' 1093': {
            'PTPT': 'Mailing addresses - PO Boxes and care-of addresses.'},
        'Objective': {
            'PTPT': 'Objective'},
        'List (Basic Types)': {
            'PTPT': 'Lista (Tipos Básicos)'},
        'Semanal': {
            'PTPT': 'Semanal'},
        ' 1099': {
            'PTPT': 'The name of the city, town, suburb, village or other community or delivery center.'},
        'Officer': {
            'PTPT': 'Officer'},
        'No data?': {
            'PTPT': 'No data?'},
        'Estados do processo': {
            'PTPT': 'Estados do processo'},
        'Login name': {
            'PTPT': 'Login name'},
        'Sítio na net': {
            'PTPT': 'Sítio na net'},
        'People': {
            'PTPT': 'People'},
        'Letter Color:': {
            'PTPT': 'Letter Color:'},
        'quidgest@quidgest.pt': {
            'PTPT': 'quidgest@quidgest.pt'},
        'Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)': {
            'PTPT': 'Numeric 15.2 double = float(53) (precision 15 digits) (storage: 8 byte)'},
        'Text after signature': {
            'PTPT': 'Text after signature'},
        'Carrier': {
            'PTPT': 'Carrier'},
        'Polygon color': {
            'PTPT': 'Polygon color'},
        'Despesa': {
            'PTPT': 'Despesa'},
        'Limite mau': {
            'PTPT': 'Limite mau'},
        'Side of which part is linked to the origin indicator': {
            'PTPT': 'Side of which part is linked to the origin indicator'},
        'Departure date (hour)': {
            'PTPT': 'Departure date (hour)'},
        'List (Foreign Key Types)': {
            'PTPT': 'List (Foreign Key Types)'},
        'Email:': {
            'PTPT': 'Email:'},
        'Alert points': {
            'PTPT': 'Alert points'},
        ' 1134': {
            'PTPT': 'Percentagem do valor objectivo a que corresponde o valor do limite mau.'},
        'Training Exercise 06': {
            'PTPT': 'Exercício de formação 06'},
        'Returned': {
            'PTPT': 'Returned'},
        'Indicator Designation': {
            'PTPT': 'Indicator Designation'},
        'Objectives icon': {
            'PTPT': 'Objectives icon'},
        'Alert 2': {
            'PTPT': 'Alert 2'},
        'Stakeholders': {
            'PTPT': 'Stakeholders'},
        'August': {
            'PTPT': 'August'},
        'Despesas': {
            'PTPT': 'Despesas'},
        'Ano': {
            'PTPT': 'Ano'},
        'Perspectives (Instance)': {
            'PTPT': 'Perspectives (Instance)'},
        'Training Exercise 02': {
            'PTPT': 'Exercício de formação 02'},
        'Administrative Gender': {
            'PTPT': 'Administrative Gender'},
        'Affinity': {
            'PTPT': 'Affinity'},
        'Seating Capacity': {
            'PTPT': 'Seating Capacity'},
        'Bom': {
            'PTPT': 'Bom'},
        '  171': {
            'PTPT': 'Periodicidade com que se vai medir o indicador.'},
        'GIAI': {
            'PTPT': 'GIAI'},
        'Orders (Integer field)': {
            'PTPT': 'Orders (Integer field)'},
        'Total Value:': {
            'PTPT': 'Total Value:'},
        'Objetivos': {
            'PTPT': 'Objetivos'},
        'Table List One action with multiselection': {
            'PTPT': 'Table List One action with multiselection'},
        'Soma': {
            'PTPT': 'Soma'},
        'Objectives (Model)': {
            'PTPT': 'Objectives (Model)'},
        'Lendings': {
            'PTPT': 'Lendings'},
        ' 1142': {
            'PTPT': 'Help in a logic field (checkbox)'},
        'Multiline text (Text editor)': {
            'PTPT': 'Multiline text (Text editor)'},
        'X de Origem': {
            'PTPT': 'X de Origem'},
        'Limite Máximo': {
            'PTPT': 'Limite Máximo'},
        'Dia Mês Recolha': {
            'PTPT': 'Dia Mês Recolha'},
        ' 1133': {
            'PTPT': 'Valor do limite bom, acima do qual a barra do indicador é desenhada a verde. Abaixo deste valor é desenhada a amarelo.'},
        'Ponderação para objectivo': {
            'PTPT': 'Ponderação para objectivo'},
        'February': {
            'PTPT': 'February'},
        'Global parameter': {
            'PTPT': 'Global parameter'},
        'Responsibles': {
            'PTPT': 'Responsibles'},
        'Last notifications': {
            'PTPT': 'Last notifications'},
        'Kind of equipment': {
            'PTPT': 'Kind of equipment'},
        'Boarding Passes': {
            'PTPT': 'Boarding Passes'},
        'Contact types': {
            'PTPT': 'Contact types'},
        ' 1086': {
            'PTPT': 'Missão'},
        '  133': {
            'PTPT': 'Campo para o QUAR que distingue o tipo de funcionários Avaliados'},
        'Asset category': {
            'PTPT': 'Asset category'},
        '  135': {
            'PTPT': 'Ponderação para o SIADAP - QUAR.'},
        '  335': {
            'PTPT': 'Número de ordem utilizado para ordenação das perspetivas'},
        'Indicatores(Model)': {
            'PTPT': 'Indicatores(Model)'},
        'Strategic objectives': {
            'PTPT': 'Strategic objectives'},
        'SYSADMIN': {
            'PTPT': 'SYSADMIN'},
        'Allow drawing polygons': {
            'PTPT': 'Permitir desenhar polígonos'},
        'Project Designation': {
            'PTPT': 'Project Designation'},
        'Technical area': {
            'PTPT': 'Technical area'},
        'Contact telephone number': {
            'PTPT': 'Contact telephone number'},
        'Campo Auxiliar Contagem': {
            'PTPT': 'Campo Auxiliar Contagem'},
        '  340': {
            'PTPT': 'Justificação/Observações para efeitos de relatório QUAR'},
        'Parameters load': {
            'PTPT': 'Parameters load'},
        'Presentation': {
            'PTPT': 'Presentation'},
        '  288': {
            'PTPT': 'Data de início'},
        'Períodos de Acumulação': {
            'PTPT': 'Períodos de Acumulação'},
        'Nacional': {
            'PTPT': 'Nacional'},
        'Stock': {
            'PTPT': 'Stock'},
        'Não Conformidades': {
            'PTPT': 'Não Conformidades'},
        'Latitude': {
            'PTPT': 'Latitude'},
        '  110': {
            'PTPT': 'Ponderação do Objectivo em relação ao peso que o mesmo representa para a Perspectiva em que se insere. O valor por omissão é de 1,00.'},
        'É obrigatório preencher a descrição: Regra do form sem apply': {
            'PTPT': 'É obrigatório preencher a descrição: Regra do form sem apply'},
        'Grid Fotos': {
            'PTPT': 'Grid Fotos'},
        'X de Destino (ME)': {
            'PTPT': 'X de Destino (ME)'},
        'Phone prefix': {
            'PTPT': 'Phone prefix'},
        'Unauthorized': {
            'PTPT': 'Unauthorized'},
        'Multiple Inputs': {
            'PTPT': 'Multiple Inputs'},
        'c-groupbox--minor': {
            'PTPT': 'c-groupbox--minor'},
        'Salt': {
            'PTPT': 'Salt'},
        'Good limit': {
            'PTPT': 'Good limit'},
        'Do you want to execute the routine?': {
            'PTPT': 'Quer executar a rotina?'},
        'Movements': {
            'PTPT': 'Movements'},
        'Country code': {
            'PTPT': 'Código do país'},
        'Administrator': {
            'PTPT': 'Administrator'},
        'Global Article': {
            'PTPT': 'Global Article'},
        'Lines': {
            'PTPT': 'Lines'},
        'Creation hour': {
            'PTPT': 'Creation hour'},
        'Origin': {
            'PTPT': 'Origin'},
        'Filter by Organic Unit': {
            'PTPT': 'Filter by Organic Unit'},
        'December': {
            'PTPT': 'December'},
        '  225': {
            'PTPT': 'Utilizador responsável pelo BSC Quidgest.'},
        'Specific path with conditions popup after DB': {
            'PTPT': 'Specific path with conditions popup after DB'},
        'Airplane ID': {
            'PTPT': 'Airplane ID'},
        'Company initials': {
            'PTPT': 'Iniciais da empresa'},
        'Returnable': {
            'PTPT': 'Returnable'},
        'Created by': {
            'PTPT': 'Created by'},
        '   84': {
            'PTPT': 'Introduzir uma descrição completa do Mapa Estratégico, identificando inclusivé qual o seu nível (Corporativo, Departamental, Pessoal...) e a realidade a que atende.'},
        '  329': {
            'PTPT': 'Valor usado no relatório QUAR para o ano N-1'},
        'Asset parameters': {
            'PTPT': 'Asset parameters'},
        'Other': {
            'PTPT': 'Other'},
        '1121': {
            'PTPT': 'Help in the list of Menu'},
        'Deactivation of Evaluation/Monitoring': {
            'PTPT': 'Deactivation of Evaluation/Monitoring'},
        'Input fields': {
            'PTPT': 'Input fields'},
        'Date time second (Instant)': {
            'PTPT': 'Date time second (Instant)'},
        'HR key': {
            'PTPT': 'HR key'},
        'Março': {
            'PTPT': 'Março'},
        '  189': {
            'PTPT': 'Este campo serve para justificar o valor.'},
        'Foto principal': {
            'PTPT': 'Foto principal'},
        'Table prices': {
            'PTPT': 'Table prices'},
        'Dias Bonificação': {
            'PTPT': 'Dias Bonificação'},
        'Lendings in a period': {
            'PTPT': 'Lendings in a period'},
        'Dispatchment Status': {
            'PTPT': 'Dispatchment Status'},
        'Creation Date': {
            'PTPT': 'Creation Date'},
        'Person specialty': {
            'PTPT': 'Person specialty'},
        'Order in group (Integer field)': {
            'PTPT': 'Order in group (Integer field)'},
        'Buton addon': {
            'PTPT': 'Buton addon'},
        'Má': {
            'PTPT': 'Má'},
        'Pts Bonificação Projecto': {
            'PTPT': 'Pts Bonificação Projecto'},
        'Test': {
            'PTPT': 'Test'},
        'Quantity of equipment:': {
            'PTPT': 'Quantity of equipment:'},
        'Radio Button': {
            'PTPT': 'Radio Button'},
        'Specific path with conditions with trigger -> DB + MB + MC + T': {
            'PTPT': 'Specific path with conditions with trigger -> DB + MB + MC + T'},
        'Gender': {
            'PTPT': 'Gender'},
        'Good Rate': {
            'PTPT': 'Good Rate'},
        '  359': {
            'PTPT': 'Unidade orgânica ativa?'},
        '   87': {
            'PTPT': 'Data termo de validade do Mapa Estratégico. Normalmente significará que na mesma data entra em vigor um outro Mapa Estratégico, ajustado a uma nova realidade, e representando uma mudança da estratégia seguida.'},
        'Tipo': {
            'PTPT': 'Tipo'},
        ' 1147': {
            'PTPT': 'This menu allows you to delete rows in a multiple-select list'},
        'No Disponible': {
            'PTPT': 'No Disponible'},
        'Game date': {
            'PTPT': 'Game date'},
        'Dispatch lines': {
            'PTPT': 'Dispatch lines'},
        'Companhy\'s people counting': {
            'PTPT': 'Contagem de pessoas da Companhy'},
        '   39': {
            'PTPT': 'This help is for a field of type Creation: Hour'},
        'Apply': {
            'PTPT': 'Apply'},
        ' 1098': {
            'PTPT': 'Specifies the entire address as it should be displayed e.g. on a postal label. This may be provided instead of or as well as the specific parts.'},
        '  396': {
            'PTPT': 'Tem segmentos diferentes?'},
        'Image Magnifier': {
            'PTPT': 'Image Magnifier'},
        'Data Ref.ª': {
            'PTPT': 'Data Ref.ª'},
        'Prepared by': {
            'PTPT': 'Prepared by'},
        'Equipment movement history:': {
            'PTPT': 'Equipment movement history:'},
        'Data Final': {
            'PTPT': 'Data Final'},
        'Indicator(Model)': {
            'PTPT': 'Indicator(Model)'},
        'Total executed': {
            'PTPT': 'Total executed'},
        'Graphs': {
            'PTPT': 'Graphs'},
        'Kit components': {
            'PTPT': 'Kit components'},
        'Rescheduling Date': {
            'PTPT': 'Rescheduling Date'},
        'Expense': {
            'PTPT': 'Expense'},
        'Quartos': {
            'PTPT': 'Quartos'},
        'Yard': {
            'PTPT': 'Yard'},
        'Acessos a Organização': {
            'PTPT': 'Acessos a Organização'},
        'Reception': {
            'PTPT': 'Reception'},
        'Quantity of hours:': {
            'PTPT': 'Quantity of hours:'},
        '  246': {
            'PTPT': 'Neste espaço deverão ser apresentados relatórios e justificações.'},
        'If present, Start SHALL have a lower value than End': {
            'PTPT': 'If present, Start SHALL have a lower value than End'},
        'Objectives (Instance)': {
            'PTPT': 'Objectives (Instance)'},
        '  198': {
            'PTPT': 'Conjunto de dígitos ou letras utilizados para individualizar organizações.'},
        'Initial value date': {
            'PTPT': 'Initial value date'},
        'Warning': {
            'PTPT': 'Warning'},
        'Data Conclusão': {
            'PTPT': 'Data Conclusão'},
        '   91': {
            'PTPT': 'Este valor por omissão, representa o ponto \'zero\' a partir do qual se calcula o grau de concretização em termos de percentual sobre a meta. Deverá ser deixado com o valor \'zero\' na presente situação.'},
        'Asset type': {
            'PTPT': 'Asset type'},
        'XX-00-XX': {
            'PTPT': 'XX-00-XX'},
        'Repair': {
            'PTPT': 'Repair'},
        'Unidade orgânica': {
            'PTPT': 'Unidade orgânica'},
        'Static Text ': {
            'PTPT': 'Static Text '},
        'Active': {
            'PTPT': 'Active'},
        'Ponto de Partida': {
            'PTPT': 'Ponto de Partida'},
        'Card Centered': {
            'PTPT': 'Card Centered'},
        'Specialties': {
            'PTPT': 'Specialties'},
        '    8': {
            'PTPT': 'Pessoa do género sexual feminino'},
        '   72': {
            'PTPT': 'Escolha um de entre os três níveis possíveis de prioridade para a Inicitaiva / Projecto.'},
        'Filter by responsible': {
            'PTPT': 'Filter by responsible'},
        'Airports To': {
            'PTPT': 'Airports To'},
        '-': {
            'PTPT': '-'},
        'IATA Code': {
            'PTPT': 'IATA Code'},
        'Destination Y': {
            'PTPT': 'Destination Y'},
        'Ticket': {
            'PTPT': 'Ticket'},
        'New input document': {
            'PTPT': 'New input document'},
        'November': {
            'PTPT': 'November'},
        'Address Uses': {
            'PTPT': 'Address Uses'},
        'Trigger -> DB + TR + F': {
            'PTPT': 'Trigger -> DB + TR + F'},
        'Estimated price': {
            'PTPT': 'Estimated price'},
        'New Group': {
            'PTPT': 'New Group'},
        'Criado em': {
            'PTPT': 'Criado em'},
        'Show record': {
            'PTPT': 'Show record'},
        '>SPECIALTY': {
            'PTPT': '>SPECIALTY'},
        ' 1105': {
            'PTPT': 'A time period defined by a start and end date/time. \n\nPeriod is not used for a duration (a measure of elapsed time).'},
        'Popup anchor (y-axis)': {
            'PTPT': 'Popup anchor (y-axis)'},
        'Room No.': {
            'PTPT': 'Room No.'},
        'False key': {
            'PTPT': 'False key'},
        'Project data?': {
            'PTPT': 'Project data?'},
        'Phase Caption Placehoder Text': {
            'PTPT': 'Phase Caption Placehoder Text'},
        'Sítio fabricante': {
            'PTPT': 'Sítio fabricante'},
        'Notes': {
            'PTPT': 'Notes'},
        'Falhou condição de edição na tabela': {
            'PTPT': 'Falhou condição de edição na tabela'},
        'Prioridade': {
            'PTPT': 'Prioridade'},
        'Closing of the sale': {
            'PTPT': 'Closing of the sale'},
        'Data Origin': {
            'PTPT': 'Data Origin'},
        '  130': {
            'PTPT': 'Chave estrangeira do Indicador Pai'},
        'Nenhuma': {
            'PTPT': 'Nenhuma'},
        'Informação do agente': {
            'PTPT': 'Informação do agente'},
        '   38': {
            'PTPT': 'This help is for a field of type Creation: User'},
        '   62': {
            'PTPT': 'Tipo de indicador, quanto à especificação se é de Resultados / Lag, ou de Antecipação / Lead. Por indicador Lead considera-se aquele cujo impacto nos resultados e na Visão se manifestará mais tarde,por oposição um indicador Lag apresenta um impacto imediato. Enquanto os primeiros estarão associados a Objectivos das Perspectivas de Recursos e Processos, os segundo predominam nos Objectivos das Perspectivas de Clientes e Financeira.'},
        'SMTP Port': {
            'PTPT': 'SMTP Port'},
        'Person': {
            'PTPT': 'Person'},
        'Generated by formulas': {
            'PTPT': 'Generated by formulas'},
        'Without Financial Resources': {
            'PTPT': 'Without Financial Resources'},
        'Editor Multiline text': {
            'PTPT': 'Editor Multiline text'},
        'Generation': {
            'PTPT': 'Generation'},
        'View': {
            'PTPT': 'View'},
        'Concluída': {
            'PTPT': 'Concluída'},
        'Projecto': {
            'PTPT': 'Projecto'},
        'Potential Buyers': {
            'PTPT': 'Potential Buyers'},
        'Alterado em': {
            'PTPT': 'Alterado em'},
        'Exemplo de Matrix List': {
            'PTPT': 'Exemplo de Matrix List'},
        'Activity': {
            'PTPT': 'Activity'},
        'Responsibles for the indicator': {
            'PTPT': 'Responsibles for the indicator'},
        'Address City': {
            'PTPT': 'Address City'},
        'Data collection method': {
            'PTPT': 'Data collection method'},
        'Final date': {
            'PTPT': 'Final date'},
        'TYPE OF COMPONENT EQUIPMENT': {
            'PTPT': 'TYPE OF COMPONENT EQUIPMENT'},
        'Falhou a condição de escrita do form sem apply': {
            'PTPT': 'Falhou a condição de escrita do form sem apply'},
        'Button': {
            'PTPT': 'Botão'},
        'Horizontal Layout - Vue': {
            'PTPT': 'Horizontal Layout - Vue'},
        'Dispatch date': {
            'PTPT': 'Dispatch date'},
        'Tables (Basic Types)': {
            'PTPT': 'Tables (Basic Types)'},
        'Until': {
            'PTPT': 'Until'},
        'Bank Account': {
            'PTPT': 'Bank Account'},
        'VAT Number': {
            'PTPT': 'VAT Number'},
        '  419': {
            'PTPT': 'Factible: El indicador se puede medir a través de las operaciones estadísticas existentes actualmente.\nNo Disponible: No se dispone de información para reportar el indicador.\nNo Aplica: El indicador no es aplicable al país.'},
        '1116': {
            'PTPT': 'Help in the Multiline field'},
        'Selection with conditions -> SC+ DB': {
            'PTPT': 'Selection with conditions -> SC+ DB'},
        'URL': {
            'PTPT': 'URL'},
        'Utilização de dados administrativos': {
            'PTPT': 'Utilização de dados administrativos'},
        'Date (DD/MM/YY)': {
            'PTPT': 'Date (DD/MM/YY)'},
        'Maximum Date': {
            'PTPT': 'Maximum Date'},
        '    6': {
            'PTPT': 'Quantidade de Equipamentos deste Tipo'},
        'Equipment -> c-groupbox--minor': {
            'PTPT': 'Equipamento -> c-groupbox--minor'},
        'Email': {
            'PTPT': 'Email'},
        '  418': {
            'PTPT': 'Nivel 1: El indicador es conceptualmente claro, tiene una metodología establecida internacionalmente y las normas están disponibles, y los datos son producidos regularmente por los países para al menos el 50 por ciento de los países y de la población en todas las regiones donde el indicador es relevante.\nNivel 2: El indicador es conceptualmente claro, tiene una metodología establecida internacionalmente y las normas están disponibles, pero los datos no son producidos regularmente por los países.\nNivel 3: No existen metodologías o estándares establecidos internacionalmente para el indicador, pero se están desarrollando o se probarán metodologías / estándares.'},
        'Longitude': {
            'PTPT': 'Longitude'},
        'Região:': {
            'PTPT': 'Região:'},
        'Password type': {
            'PTPT': 'Password type'},
        'Contacts': {
            'PTPT': 'Contactos'},
        'Downed equipment': {
            'PTPT': 'Downed equipment'},
        '  302': {
            'PTPT': 'Ordem'},
        'Real estate of a country': {
            'PTPT': 'Real estate of a country'},
        'Adiada': {
            'PTPT': 'Adiada'},
        '  327': {
            'PTPT': 'Prefixo dos objetivos'},
        'Have you traveled before?': {
            'PTPT': 'Have you traveled before?'},
        '  254': {
            'PTPT': 'Tipo de informação'},
        'Dislocation and relationship to or from the origin of the league line': {
            'PTPT': 'Dislocation and relationship to or from the origin of the league line'},
        'Lista de campo': {
            'PTPT': 'Lista de campo'},
        'Equipment requests': {
            'PTPT': 'Equipment requests'},
        'Airline JOANA': {
            'PTPT': 'Airline JOANA'},
        'Quidgest - Vue.js': {
            'PTPT': 'Quidgest - Vue.js'},
        'Side to which the connecting line arrives': {
            'PTPT': 'Side to which the connecting line arrives'},
        'Identifier types': {
            'PTPT': 'Identifier types'},
        'ID (Mapa Estratégico)': {
            'PTPT': 'ID (Mapa Estratégico)'},
        'LOCALS': {
            'PTPT': 'LOCALS'},
        'Registo na plataforma de Empréstimos': {
            'PTPT': 'Registo na plataforma de Empréstimos'},
        'Responsáveis Dados': {
            'PTPT': 'Responsáveis Dados'},
        'Tipo Dado': {
            'PTPT': 'Tipo Dado'},
        '   34': {
            'PTPT': 'This help is for a field of type DATESECOND'},
        'Wizards': {
            'PTPT': 'Wizards'},
        ' 1144_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Verbose help in numeric enumeration field</p>
</body>
</html>'},
        'Banking Account Number': {
            'PTPT': 'Banking Account Number'},
        'Phones': {
            'PTPT': 'Phones'},
        'ACCORDEON': {
            'PTPT': 'ACCORDEON'},
        'O campo descrição é obrigatório': {
            'PTPT': 'O campo descrição é obrigatório'},
        'Away Team': {
            'PTPT': 'Away Team'},
        'Async process': {
            'PTPT': 'Async process'},
        'Training Exercise 15': {
            'PTPT': 'Exercício de formação 15'},
        'Perspective': {
            'PTPT': 'Perspective'},
        'Icon associated with the tag': {
            'PTPT': 'Icon associated with the tag'},
        'Numeric Fields': {
            'PTPT': 'Numeric Fields'},
        'Multiline Text Prop': {
            'PTPT': 'Multiline Text Prop'},
        'Last notification date': {
            'PTPT': 'Last notification date'},
        'Polarity': {
            'PTPT': 'Polarity'},
        '>ROOM': {
            'PTPT': '>ROOM'},
        'Data types': {
            'PTPT': 'Data types'},
        '  371': {
            'PTPT': 'Primeira data de referência dos dados'},
        'Training Exercise 14': {
            'PTPT': 'Exercício de formação 14'},
        'Boa': {
            'PTPT': 'Boa'},
        'Type Equipment information -> c-groupbox--title-background': {
            'PTPT': 'Type Equipment information -> c-groupbox--title-background'},
        'Logical Enumeration': {
            'PTPT': 'Logical Enumeration'},
        'Aggregate vison': {
            'PTPT': 'Aggregate vison'},
        'Spent on hours': {
            'PTPT': 'Spent on hours'},
        'Closing date': {
            'PTPT': 'Closing date'},
        'Related Tables (Basic)': {
            'PTPT': 'Related Tables (Basic)'},
        'Group 3': {
            'PTPT': 'Group 3'},
        '   81': {
            'PTPT': 'Pontos de bonificação passível de ser atribuídos à Inicitaiva / Projecto, para além dos pontos normais resultantes dos somatórios de pontos das Actividades. Esta atribuição é competência exclusiva do Conselho Directivo.'},
        'Produto': {
            'PTPT': 'Produto'},
        'Last Price': {
            'PTPT': 'Last Price'},
        'Destination X': {
            'PTPT': 'Destination X'},
        'Article categorization': {
            'PTPT': 'Article categorization'},
        'Última data relatório': {
            'PTPT': 'Última data relatório'},
        'Strategic Objectives / Operational Objectives (Instance)': {
            'PTPT': 'Strategic Objectives / Operational Objectives (Instance)'},
        '  132': {
            'PTPT': 'Data de referência para os dados gerados por integração ou agregados dos indicadores filhos deste indicador.'},
        'Shadow anchor (y-axis)': {
            'PTPT': 'Shadow anchor (y-axis)'},
        'Photos': {
            'PTPT': 'Photos'},
        'Bimestral': {
            'PTPT': 'Bimestral'},
        '[Sigla]': {
            'PTPT': '[Sigla]'},
        'Indicator Goals': {
            'PTPT': 'Indicator Goals'},
        'Quantity:': {
            'PTPT': 'Quantity:'},
        'Contacts -> c-groupbox--background': {
            'PTPT': 'Contactos -> c-groupbox--background'},
        'Email and web': {
            'PTPT': 'Correio eletrónico e Web'},
        'Type of equipment': {
            'PTPT': 'Type of equipment'},
        'Perc. Bom': {
            'PTPT': 'Perc. Bom'},
        'Warehouse:': {
            'PTPT': 'Warehouse:'},
        'Destination ID': {
            'PTPT': 'Destination ID'},
        'Organic unit': {
            'PTPT': 'Organic unit'},
        'Login': {
            'PTPT': 'Login'},
        'Wizard': {
            'PTPT': 'Wizard'},
        'Breakdown:': {
            'PTPT': 'Breakdown:'},
        'Sub categoria': {
            'PTPT': 'Sub categoria'},
        'Receiver': {
            'PTPT': 'Receiver'},
        'Manual to collect': {
            'PTPT': 'Manual to collect'},
        'Ponto de Destino (ME)': {
            'PTPT': 'Ponto de Destino (ME)'},
        'GPS input': {
            'PTPT': 'GPS input'},
        'Valor Inicial': {
            'PTPT': 'Valor Inicial'},
        'Conditional (smallint) (storage: 2 byte)': {
            'PTPT': 'Conditional (smallint) (storage: 2 byte)'},
        'Consulta dados pessoais': {
            'PTPT': 'Consulta dados pessoais'},
        '>REFERENCE YEAR': {
            'PTPT': '>REFERENCE YEAR'},
        'Grau Mau': {
            'PTPT': 'Grau Mau'},
        '>YEAR': {
            'PTPT': '>YEAR'},
        'Timeline Years- Armazém': {
            'PTPT': 'Timeline Years- Armazém'},
        ' 1092': {
            'PTPT': 'An address expressed using postal conventions (as opposed to GPS or other location definition formats)'},
        'Delete Multiple records': {
            'PTPT': 'Eliminar vários registos'},
        'External': {
            'PTPT': 'External'},
        '  338': {
            'PTPT': 'Dado não apurado para a data da referência'},
        'List (Basic Types, Counter)': {
            'PTPT': 'Lista (Tipos Básicos, Contador)'},
        'Groups and style classes': {
            'PTPT': 'Groups and style classes'},
        'Data última notificação': {
            'PTPT': 'Data última notificação'},
        'Visitas de inspeção': {
            'PTPT': 'Visitas de inspeção'},
        'Specific path with conditions with trigger -> DB + MB + MC + TR': {
            'PTPT': 'Specific path with conditions with trigger -> DB + MB + MC + TR'},
        'Year Built': {
            'PTPT': 'Ano construído'},
        'Good Indicators': {
            'PTPT': 'Good Indicators'},
        'Address State': {
            'PTPT': 'Address State'},
        ' 1100': {
            'PTPT': 'The name of the administrative area (county).'},
        'Sex': {
            'PTPT': 'Sex'},
        'Money - decimal (11-15) (storage: 9 byte)': {
            'PTPT': 'Money - decimal (11-15) (storage: 9 byte)'},
        'Dispatch line': {
            'PTPT': 'Dispatch line'},
        '>>CUSTOMER': {
            'PTPT': '>>CUSTOMER'},
        'Email 1': {
            'PTPT': 'Email 1'},
        'IBAN': {
            'PTPT': 'IBAN'},
        'Information element': {
            'PTPT': 'Information element'},
        '  185': {
            'PTPT': 'Inserir informação referente à data e ao valor anterior'},
        'Grau Suficiente': {
            'PTPT': 'Grau Suficiente'},
        'EDIT': {
            'PTPT': 'EDIT'},
        'Qualification carried out': {
            'PTPT': 'Qualification carried out'},
        'Text of sent message': {
            'PTPT': 'Text of sent message'},
        'Value': {
            'PTPT': 'Value'},
        'Space types': {
            'PTPT': 'Space types'},
        'Moving': {
            'PTPT': 'Moving'},
        'Nº Mecanográfico': {
            'PTPT': 'Nº Mecanográfico'},
        'Tolerance': {
            'PTPT': 'Tolerance'},
        'Female': {
            'PTPT': 'Female'},
        'Wizard with progress': {
            'PTPT': 'Wizard with progress'},
        'Longitudes range from -180 to 180.': {
            'PTPT': 'Longitudes range from -180 to 180.'},
        'Em fila de espera': {
            'PTPT': 'Em fila de espera'},
        '  107': {
            'PTPT': 'O valor global do Balanced Scorecard é obtido a partir dos valores de cada uma das perspectivas e de acordo com a ponderação relativa destas. O valor aqui inserido não segue nem necessita de qualquer regra especifica. O valor por omissão é de 1,00 sendo igual para todas as perspectivas.'},
        'Helps in fields': {
            'PTPT': 'Helps in fields'},
        'Metadata': {
            'PTPT': 'Metadata'},
        'Audit': {
            'PTPT': 'Auditoria'},
        'Strategic Map': {
            'PTPT': 'Strategic Map'},
        'Max Map color': {
            'PTPT': 'Max Map color'},
        'Icon anchor (y-axis)': {
            'PTPT': 'Icon anchor (y-axis)'},
        '  370': {
            'PTPT': 'Campo para não usar em formulários serve somente para verificar se a migração/evolução dos estados/relatórios nas iniciativas e tarefas'},
        'TIPOEQUI': {
            'PTPT': 'TIPOEQUI'},
        'Average days in Project': {
            'PTPT': 'Average days in Project'},
        '>PERSON': {
            'PTPT': '>PERSON'},
        'Visão (Instância)': {
            'PTPT': 'Visão (Instância)'},
        'Comodante': {
            'PTPT': 'Comodante'},
        '  104': {
            'PTPT': 'Descrição sumária da Estratégia a implementar com este mapa estratégico.'},
        'Observations': {
            'PTPT': 'Observations'},
        'Sem objectivo?': {
            'PTPT': 'Sem objectivo?'},
        'Training Exercise 11': {
            'PTPT': 'Exercício de formação 11'},
        'Answer': {
            'PTPT': 'Answer'},
        'Borrower:': {
            'PTPT': 'Borrower:'},
        'Stock evolution': {
            'PTPT': 'Stock evolution'},
        'Inputs with Masks': {
            'PTPT': 'Inputs with Masks'},
        'Maxtrix List - Items': {
            'PTPT': 'Maxtrix List - Items'},
        'INSTALAÇÕES': {
            'PTPT': 'INSTALAÇÕES'},
        'Message ID': {
            'PTPT': 'Message ID'},
        '  271': {
            'PTPT': 'Já ultrapassou o resultado.'},
        'First Name': {
            'PTPT': 'First Name'},
        'Bank Company': {
            'PTPT': 'Bank Company'},
        'Spaces': {
            'PTPT': 'Spaces'},
        'Base tables': {
            'PTPT': 'Base tables'},
        'Place of Birth': {
            'PTPT': 'Place of Birth'},
        'Não': {
            'PTPT': 'Não'},
        '  387': {
            'PTPT': 'Instrumentos de acompanhamento e monitorização'},
        'Stategic Map': {
            'PTPT': 'Stategic Map'},
        'Exceeded Indicators': {
            'PTPT': 'Exceeded Indicators'},
        'Persons': {
            'PTPT': 'Persons'},
        'Group (Basic)': {
            'PTPT': 'Group (Basic)'},
        'Square meters': {
            'PTPT': 'Square meters'},
        'Prospection': {
            'PTPT': 'Prospection'},
        'T0': {
            'PTPT': 'T0'},
        'Timeline Primary': {
            'PTPT': 'Timeline Primary'},
        'Typology': {
            'PTPT': 'Tipologia'},
        '  389': {
            'PTPT': 'Filtra os responsáveis de dados, indicadores e mapas com base no nível de acesso à aplicação'},
        'Real estate': {
            'PTPT': 'Real estate'},
        'Tipo de Scorecard': {
            'PTPT': 'Tipo de Scorecard'},
        'Input Group': {
            'PTPT': 'Input Group'},
        '  401': {
            'PTPT': 'Respeita intervalo de tempo?'},
        'decimal (11-15) (storage: 9 byte)': {
            'PTPT': 'decimal (11-15) (storage: 9 byte)'},
        'Text of the sent message': {
            'PTPT': 'Text of the sent message'},
        '  309': {
            'PTPT': 'Tipo de unidade orgânica'},
        'Categorization': {
            'PTPT': 'Categorization'},
        'Contact': {
            'PTPT': 'Contact'},
        'Time': {
            'PTPT': 'Time'},
        'Goal Points': {
            'PTPT': 'Goal Points'},
        'Mixed style': {
            'PTPT': 'Mixed style'},
        'Total Not Applicable': {
            'PTPT': 'Total Not Applicable'},
        'Project Bonus Pts': {
            'PTPT': 'Project Bonus Pts'},
        'Cabin + Checkin Luggage': {
            'PTPT': 'Cabin + Checkin Luggage'},
        'Prefix': {
            'PTPT': 'Prefix'},
        'Type 3': {
            'PTPT': 'Type 3'},
        'Training Exercise 08': {
            'PTPT': 'Exercício de formação 08'},
        'Nº Ordem': {
            'PTPT': 'Nº Ordem'},
        'No Aplica': {
            'PTPT': 'No Aplica'},
        'Responsible for the indicator': {
            'PTPT': 'Responsible for the indicator'},
        'Fórmula': {
            'PTPT': 'Fórmula'},
        'EQUIPMENT': {
            'PTPT': 'EQUIPMENT'},
        'Minimum Perc.': {
            'PTPT': 'Minimum Perc.'},
        '  190': {
            'PTPT': 'Definição de unidade.'},
        'Type A': {
            'PTPT': 'Type A'},
        '   70': {
            'PTPT': 'Indique aqui se existe alguma verba disponível e orçamentada para a referida Iniciativa / Projecto.'},
        'Allow feature editing': {
            'PTPT': 'Permitir a edição de caraterísticas'},
        'GLN Extension Component': {
            'PTPT': 'GLN Extension Component'},
        ' 1144': {
            'PTPT': 'Help in numeric enumeration field'},
        'Data Fecho': {
            'PTPT': 'Data Fecho'},
        'Two': {
            'PTPT': 'Two'},
        ' 1106': {
            'PTPT': 'The start of the period. The boundary is inclusive.'},
        'Rate exceeded': {
            'PTPT': 'Rate exceeded'},
        'Month': {
            'PTPT': 'Month'},
        'Profille picture': {
            'PTPT': 'Profille picture'},
        'Evolution in the category': {
            'PTPT': 'Evolution in the category'},
        'Symbol': {
            'PTPT': 'Symbol'},
        'Good 2': {
            'PTPT': 'Good 2'},
        'Simple Multiline text': {
            'PTPT': 'Simple Multiline text'},
        'Identification -> c-groupbox--minor-border-top': {
            'PTPT': 'Identification -> c-groupbox--minor-border-top'},
        'Localização': {
            'PTPT': 'Localização'},
        'Rodapé': {
            'PTPT': 'Rodapé'},
        'Sexo da pessoas': {
            'PTPT': 'Sexo da pessoas'},
        'To show': {
            'PTPT': 'To show'},
        'Formulário': {
            'PTPT': 'Formulário'},
        'Miniature': {
            'PTPT': 'Miniature'},
        'Total Days of Activities': {
            'PTPT': 'Total Days of Activities'},
        'Line:': {
            'PTPT': 'Line:'},
        'Site': {
            'PTPT': 'Site'},
        'Grau Superado': {
            'PTPT': 'Grau Superado'},
        '   15_VERBOSE': {
            'PTPT': 'Documento com catálogo'},
        'Resultados': {
            'PTPT': 'Resultados'},
        'Passwords': {
            'PTPT': 'Passwords'},
        '1st trip (Logical Enumeration)': {
            'PTPT': '1st trip (Logical Enumeration)'},
        'Manuals to collect': {
            'PTPT': 'Manuals to collect'},
        'EVOLUTION': {
            'PTPT': 'EVOLUTION'},
        '  206': {
            'PTPT': 'Colocar o logotipo da organização.'},
        'Since': {
            'PTPT': 'Since'},
        'Equipment groupings': {
            'PTPT': 'Equipment groupings'},
        'Funcionários do Armazéns': {
            'PTPT': 'Funcionários do Armazéns'},
        'Perspective Description': {
            'PTPT': 'Perspective Description'},
        'Adiado': {
            'PTPT': 'Adiado'},
        'group in accordian 2nd': {
            'PTPT': 'group in accordian 2nd'},
        'Dirigentes': {
            'PTPT': 'Dirigentes'},
        'q-group-collapsible--audit': {
            'PTPT': 'q-group-collapsible--audit'},
        'Cleaning': {
            'PTPT': 'Cleaning'},
        'group in accordian 1st': {
            'PTPT': 'group in accordian 1st'},
        'Minimum Date': {
            'PTPT': 'Minimum Date'},
        '  222': {
            'PTPT': 'Correio electrónico para o qual se irá enviar a notificação.'},
        'Verification of goods': {
            'PTPT': 'Verification of goods'},
        'Declive': {
            'PTPT': 'Declive'},
        'Nome': {
            'PTPT': 'Nome'},
        'Estratégia': {
            'PTPT': 'Estratégia'},
        'Sucesso': {
            'PTPT': 'Sucesso'},
        'Respons. Indicador': {
            'PTPT': 'Respons. Indicador'},
        'Table (Basic Types)': {
            'PTPT': 'Table (Basic Types)'},
        'Home': {
            'PTPT': 'Home'},
        'Item Properties': {
            'PTPT': 'Item Properties'},
        'Perspective Designation': {
            'PTPT': 'Perspective Designation'},
        'N:N Fields': {
            'PTPT': 'N:N Fields'},
        'Asset categories': {
            'PTPT': 'Asset categories'},
        'Produtividade': {
            'PTPT': 'Produtividade'},
        'Prepared': {
            'PTPT': 'Prepared'},
        'X de Origem (ME)': {
            'PTPT': 'X de Origem (ME)'},
        'My dashboard': {
            'PTPT': 'My dashboard'},
        'Collapsible Row lists': {
            'PTPT': 'Listas de linhas recolhíveis'},
        'Descrição do mapa': {
            'PTPT': 'Descrição do mapa'},
        'Card Image Thumbnail': {
            'PTPT': 'Card Image Thumbnail'},
        'Tipos de Indicador': {
            'PTPT': 'Tipos de Indicador'},
        'Goal points': {
            'PTPT': 'Goal points'},
        'ID (ME)': {
            'PTPT': 'ID (ME)'},
        'Indicator': {
            'PTPT': 'Indicator'},
        'Prosperação': {
            'PTPT': 'Prosperação'},
        'Graph Icon': {
            'PTPT': 'Graph Icon'},
        'Loan frequencies': {
            'PTPT': 'Loan frequencies'},
        'Filling in this field should not be safely ignored as it may lead to misinterpretation of the information contained in the record.': {
            'PTPT': 'Filling in this field should not be safely ignored as it may lead to misinterpretation of the information contained in the record.'},
        'Containers': {
            'PTPT': 'Containers'},
        'Table List': {
            'PTPT': 'Table List'},
        'Sign documents pdf -> DB + AD + F': {
            'PTPT': 'Sign documents pdf -> DB + AD + F'},
        'Indicador': {
            'PTPT': 'Indicador'},
        'Ativa?': {
            'PTPT': 'Ativa?'},
        'Descricao': {
            'PTPT': 'Descricao'},
        'Training Exercise 07': {
            'PTPT': 'Exercício de formação 07'},
        'Incorporation': {
            'PTPT': 'Incorporation'},
        'People\'s specialties': {
            'PTPT': 'People\'s specialties'},
        'Social Security No': {
            'PTPT': 'Social Security No'},
        'Photographs': {
            'PTPT': 'Photographs'},
        'Organismo': {
            'PTPT': 'Organismo'},
        'Zipcode': {
            'PTPT': 'Zipcode'},
        'Checklist': {
            'PTPT': 'Checklist'},
        'Days': {
            'PTPT': 'Days'},
        'Facility name': {
            'PTPT': 'Facility name'},
        'Allow feature dragging': {
            'PTPT': 'Permitir o arrastamento de funcionalidades'},
        'Alphabetic 2': {
            'PTPT': 'Alphabetic 2'},
        'Currency Decimal': {
            'PTPT': 'Currency Decimal'},
        'Container depot': {
            'PTPT': 'Container depot'},
        '1119': {
            'PTPT': 'Help in the date field'},
        'Fax': {
            'PTPT': 'Fax'},
        'Training Exercise 04': {
            'PTPT': 'Exercício de formação 04'},
        '  182': {
            'PTPT': 'O período em que a recolha irá ser feita, conforme a a periocidade de recolha definida.'},
        'Numeric  4.0 - small integer (storage: 2 byte)': {
            'PTPT': 'Numeric  4.0 - small integer (storage: 2 byte)'},
        'Inputs': {
            'PTPT': 'Inputs'},
        'List': {
            'PTPT': 'List'},
        'Total Indicators': {
            'PTPT': 'Total Indicators'},
        'Vendedor': {
            'PTPT': 'Vendedor'},
        'Falhou a condição de eliminação no form': {
            'PTPT': 'Falhou a condição de eliminação no form'},
        'Allow feature cutting': {
            'PTPT': 'Permitir o corte de caraterísticas'},
        '   16': {
            'PTPT': 'Because of the following rule: You should always be able to create a file with 12 chars in the name (including the extension, something like 8.3)\n\nSo, we have this:\n\nc:\very-long-folder-name  => MAX Length=(260-12-1) = 247. The trailing minus 1 is for the invisible NUL terminator.\n\nThen, you can create a file in this folder with a name like this: 12345678.txt\n\nSo, we have our 260 chars for the whole path, including the file name, the extension, and the NUL terminator.'},
        'Roles': {
            'PTPT': 'Roles'},
        'Property': {
            'PTPT': 'Property'},
        'Acções Preventivas': {
            'PTPT': 'Acções Preventivas'},
        'Width': {
            'PTPT': 'Width'},
        'Utilizador Acesso SMTP': {
            'PTPT': 'Utilizador Acesso SMTP'},
        'Number:': {
            'PTPT': 'Number:'},
        'List (For N:1 Relations)': {
            'PTPT': 'List (For N:1 Relations)'},
        'Very mobile': {
            'PTPT': 'Very mobile'},
        'Address Country': {
            'PTPT': 'Address Country'},
        'Loan frequency': {
            'PTPT': 'Loan frequency'},
        'User ID': {
            'PTPT': 'User ID'},
        'Article types': {
            'PTPT': 'Article types'},
        'Origin Y (ME)': {
            'PTPT': 'Origin Y (ME)'},
        'Limit Exceeded': {
            'PTPT': 'Limit Exceeded'},
        'Article categorizations': {
            'PTPT': 'Article categorizations'},
        'Sale closing': {
            'PTPT': 'Sale closing'},
        'Employee No.': {
            'PTPT': 'Employee No.'},
        'Base': {
            'PTPT': 'Base'},
        'Post office box': {
            'PTPT': 'Post office box'},
        'Please confirm that you have entered the Email correctly.': {
            'PTPT': 'Please confirm that you have entered the Email correctly.'},
        'Comforters': {
            'PTPT': 'Comforters'},
        '>SELLER': {
            'PTPT': '>SELLER'},
        '  178': {
            'PTPT': 'Aqui é escolhida a qualidade dos dados que estamos a recolher'},
        'Orders in group  (Float field)': {
            'PTPT': 'Orders in group  (Float field)'},
        'Equipment grouping': {
            'PTPT': 'Equipment grouping'},
        'Equipment request': {
            'PTPT': 'Equipment request'},
        '  167': {
            'PTPT': 'Campo para indicar se o dado é proveniente de Projecto ou não'},
        'Fixed menu name': {
            'PTPT': 'Fixed menu name'},
        'Real State Map': {
            'PTPT': 'Real State Map'},
        'País pessoa': {
            'PTPT': 'País pessoa'},
        '   63': {
            'PTPT': 'Serve o presente campo para associar a cada indicador e de acordo com as várias estratégias possíveis, a identificação da mesma.'},
        '   55': {
            'PTPT': 'Posição hierárquica, cargo do responsável na Organização / Instituição, conforme definido no Organigrama.'},
        '   27': {
            'PTPT': 'This help is for a field of type enumeration (Text)'},
        'N.R. Room': {
            'PTPT': 'N.R. Room'},
        'Repair Description': {
            'PTPT': 'Repair Description'},
        'GLN Ext': {
            'PTPT': 'GLN Ext'},
        'Orders  (Float field)': {
            'PTPT': 'Orders  (Float field)'},
        '  176': {
            'PTPT': 'A fórmula aqui inserida é meramente descritiva.'},
        '  248': {
            'PTPT': 'Data de referência do dado.'},
        'Equipment decomissions': {
            'PTPT': 'Desativação de equipamentos'},
        'Card Image Top': {
            'PTPT': 'Card Image Top'},
        'Anexo digital': {
            'PTPT': 'Anexo digital'},
        'Overcoming objections': {
            'PTPT': 'Overcoming objections'},
        'All day': {
            'PTPT': 'Todo o dia'},
        '   86': {
            'PTPT': 'Data a partir da qual o Mapa Estratégico entra em vigor.'},
        'Receiver\'s Email': {
            'PTPT': 'Receiver\'s Email'},
        'Birth Date': {
            'PTPT': 'Birth Date'},
        '  116': {
            'PTPT': 'Este campo serve para incluir o local da pasta onde os documentos do programa devem estar guardados. O não preenchimento do mesmo implica que estes serão guardados na pasta docs\\sigla que se encontra na mesma pasta do executável. Nota: O nome do local não deve incluir \\ no final.'},
        'Entities': {
            'PTPT': 'Entities'},
        'Sender Email': {
            'PTPT': 'Sender Email'},
        'Level:': {
            'PTPT': 'Level:'},
        'Detalhes': {
            'PTPT': 'Detalhes'},
        'Iniciativa': {
            'PTPT': 'Iniciativa'},
        'Sum of Recurring Bonuses': {
            'PTPT': 'Sum of Recurring Bonuses'},
        'Acções Correctivas': {
            'PTPT': 'Acções Correctivas'},
        'No decision-making capacity': {
            'PTPT': 'No decision-making capacity'},
        'Julho': {
            'PTPT': 'Julho'},
        'Overcome objections': {
            'PTPT': 'Overcome objections'},
        'Documents from Equipment': {
            'PTPT': 'Documents from Equipment'},
        'Visits:': {
            'PTPT': 'Visits:'},
        '1121_VERBOSE': {
            'PTPT': 'Help in the list of Menu Verbose'},
        'Enabled?': {
            'PTPT': 'Enabled?'},
        'Male': {
            'PTPT': 'Male'},
        'Recolha': {
            'PTPT': 'Recolha'},
        'Type of segment': {
            'PTPT': 'Type of segment'},
        '[ASSET->ASSETNUM] - [ASSET->NAME]': {
            'PTPT': '[ASSET->ASSETNUM] - [ASSET->NAME]'},
        'Exceeded %': {
            'PTPT': 'Exceeded %'},
        'Row order group level 1': {
            'PTPT': 'Row order group level 1'},
        'Numeric  9.0 - integer (storage: 4 byte)': {
            'PTPT': 'Numeric  9.0 - integer (storage: 4 byte)'},
        'Eficácia': {
            'PTPT': 'Eficácia'},
        'Horizontal Layout': {
            'PTPT': 'Horizontal Layout'},
        'UI Component': {
            'PTPT': 'UI Component'},
        '  382': {
            'PTPT': 'Designação a dar em vez de "Iniciativa".'},
        'Exit instant': {
            'PTPT': 'Exit instant'},
        'Institution': {
            'PTPT': 'Institution'},
        'Resultado': {
            'PTPT': 'Resultado'},
        'County/Province': {
            'PTPT': 'Concelho/Província'},
        'Genera': {
            'PTPT': 'Genera'},
        'Equipmet families': {
            'PTPT': 'Equipmet families'},
        'Unit': {
            'PTPT': 'Unit'},
        'Teams of players': {
            'PTPT': 'Teams of players'},
        'Allow exporting map': {
            'PTPT': 'Permitir a exportação do mapa'},
        'Items from a warehouse': {
            'PTPT': 'Items from a warehouse'},
        'Quantity of people': {
            'PTPT': 'Quantity of people'},
        'Sem recursos financeiros': {
            'PTPT': 'Sem recursos financeiros'},
        '  391': {
            'PTPT': 'Indicador tipo Data'},
        'Tag name': {
            'PTPT': 'Tag name'},
        'Capacidade de passeiros no avião': {
            'PTPT': 'Capacidade de passeiros no avião'},
        '  487': {
            'PTPT': 'A afetação indicada está concordante com o sistema de contabilidade de custos implementado?'},
        'Data Responsible': {
            'PTPT': 'Data Responsible'},
        'Organism code': {
            'PTPT': 'Organism code'},
        'Idioms': {
            'PTPT': 'Idioms'},
        'Ticket ID': {
            'PTPT': 'Ticket ID'},
        'Horizontal Wizard': {
            'PTPT': 'Horizontal Wizard'},
        '1118_VERBOSE': {
            'PTPT': 'Help in the time field v'},
        'Somatório': {
            'PTPT': 'Somatório'},
        'Main Info': {
            'PTPT': 'Informações principais'},
        '  427': {
            'PTPT': 'Servidor de SMTP tem SSL'},
        'Abortado': {
            'PTPT': 'Abortado'},
        'Idiomas': {
            'PTPT': 'Idiomas'},
        'Preço do bilhete ás décimas': {
            'PTPT': 'Preço do bilhete ás décimas'},
        'Person Histories': {
            'PTPT': 'Person Histories'},
        'decimal (1-10) (storage: 5 byte)': {
            'PTPT': 'decimal (1-10) (storage: 5 byte)'},
        'Decomission by year': {
            'PTPT': 'Decomission by year'},
        'Helps': {
            'PTPT': 'Helps'},
        'Days of all Projects': {
            'PTPT': 'Days of all Projects'},
        'Icon URL': {
            'PTPT': 'Icon URL'},
        'Entire address': {
            'PTPT': 'Entire address'},
        '>>Kind of equipment': {
            'PTPT': '>>Kind of equipment'},
        'Properties': {
            'PTPT': 'Properties'},
        'Output': {
            'PTPT': 'Output'},
        'Training Exercise 18': {
            'PTPT': 'Exercício de formação 18'},
        '@required': {
            'PTPT': '@required'},
        'Equipments': {
            'PTPT': 'Equipments'},
        'Contact Genre': {
            'PTPT': 'Contact Genre'},
        'Baseline': {
            'PTPT': 'Baseline'},
        'Weighting': {
            'PTPT': 'Weighting'},
        'Agents': {
            'PTPT': 'Agentes'},
        '   37': {
            'PTPT': 'This help is for a field of type Creation: Instant'},
        'Attached': {
            'PTPT': 'Attached'},
        'No. of the dadato': {
            'PTPT': 'No. of the dadato'},
        'Document number': {
            'PTPT': 'Document number'},
        ' 1131': {
            'PTPT': 'Valor do limite mau, abaixo do qual a barra do indicador aparece encarnada. Acima deste valor é desenhada a amarelo.'},
        'Responsible for the Indicator': {
            'PTPT': 'Responsible for the Indicator'},
        'Genio Patterns': {
            'PTPT': 'Genio Patterns'},
        'Moving accesses': {
            'PTPT': 'Moving accesses'},
        '{STY_OVERVIEW_Count} cards have been created': {
            'PTPT': '{STY_OVERVIEW_Count} cards have been created'},
        'Digital document': {
            'PTPT': 'Digital document'},
        'Electricity': {
            'PTPT': 'Electricity'},
        'Total Bonuses': {
            'PTPT': 'Total Bonuses'},
        '  443': {
            'PTPT': 'Número mecanográfico'},
        'Dia Mês': {
            'PTPT': 'Dia Mês'},
        'Semestral': {
            'PTPT': 'Semestral'},
        'Dependence on': {
            'PTPT': 'Dependence on'},
        'Icons': {
            'PTPT': 'Icons'},
        'Extended form support': {
            'PTPT': 'Extended form support'},
        'Gender contact': {
            'PTPT': 'Gender contact'},
        ' 1139': {
            'PTPT': 'Team'},
        '   64': {
            'PTPT': 'Designação do indicador, de forma a que o mesmo seja fácilmente identificável.'},
        'Value (Year N-1)': {
            'PTPT': 'Value (Year N-1)'},
        'Tipos de processos': {
            'PTPT': 'Tipos de processos'},
        'Minimum': {
            'PTPT': 'Minimum'},
        'Qnty hours': {
            'PTPT': 'Qnty hours'},
        'Entidade': {
            'PTPT': 'Entidade'},
        'Real time status': {
            'PTPT': 'Real time status'},
        'Rounded Ticket Price': {
            'PTPT': 'Rounded Ticket Price'},
        'Notificações Individuais': {
            'PTPT': 'Notificações Individuais'},
        'Data dados': {
            'PTPT': 'Data dados'},
        'Entries:': {
            'PTPT': 'Entries:'},
        'Left': {
            'PTPT': 'Left'},
        'Current account': {
            'PTPT': 'Current account'},
        'Objective type': {
            'PTPT': 'Objective type'},
        'N.º da lide': {
            'PTPT': 'N.º da lide'},
        'Icon anchor (x-axis)': {
            'PTPT': 'Icon anchor (x-axis)'},
        'Bandeira': {
            'PTPT': 'Bandeira'},
        'Edit Mode': {
            'PTPT': 'Edit Mode'},
        'April': {
            'PTPT': 'April'},
        'Ship To': {
            'PTPT': 'Ship To'},
        '  137': {
            'PTPT': 'Períodos de Acumulação de um Indicador. Se a escolha dos dados apenas se deve fazer no período para o qual o Scorecard for calculado deve-se escolher por Período. Se a escolha dos dados se faz no período mas no caso da inexistência de dados nesse período é necessário que o Indicador demonstre os dados do histórico então deve-se escolher Acumulado.'},
        'Mapa Estratégico': {
            'PTPT': 'Mapa Estratégico'},
        'List of Items': {
            'PTPT': 'List of Items'},
        'Address Use': {
            'PTPT': 'Address Use'},
        ' 1145': {
            'PTPT': 'Help in the enumeration item'},
        'Vison icon': {
            'PTPT': 'Vison icon'},
        'Location Extension Components': {
            'PTPT': 'Location Extension Components'},
        'Order in group (Float field)': {
            'PTPT': 'Order in group (Float field)'},
        'Asset tags': {
            'PTPT': 'Asset tags'},
        'Editor recursos': {
            'PTPT': 'Editor recursos'},
        'Year': {
            'PTPT': 'Year'},
        'Mapa Fechado': {
            'PTPT': 'Mapa Fechado'},
        'Global articles': {
            'PTPT': 'Global articles'},
        'Dashboard': {
            'PTPT': 'Dashboard'},
        'E-mail Remetente': {
            'PTPT': 'E-mail Remetente'},
        'Installation': {
            'PTPT': 'Installation'},
        'Sum': {
            'PTPT': 'Sum'},
        'Tax identification:': {
            'PTPT': 'Tax identification:'},
        ' 1132': {
            'PTPT': 'Percentagem do valor objectivo a que corresponde o valor mínimo.'},
        'Perc. Limite Mau': {
            'PTPT': 'Perc. Limite Mau'},
        'Logic - Internal people': {
            'PTPT': 'Logic - Internal people'},
        'Inactivo': {
            'PTPT': 'Inactivo'},
        '   35': {
            'PTPT': 'This help is for a field of type TIME'},
        'Up manual': {
            'PTPT': 'Up manual'},
        'Tax ID No:': {
            'PTPT': 'Tax ID No:'},
        'Place where you run': {
            'PTPT': 'Place where you run'},
        'weighting': {
            'PTPT': 'weighting'},
        'Modified on': {
            'PTPT': 'Modified on'},
        'Sector': {
            'PTPT': 'Sector'},
        'Lado do qual parte a linha de ligação': {
            'PTPT': 'Lado do qual parte a linha de ligação'},
        '  337': {
            'PTPT': 'Data de recolha dos dados. Data em que os dados devem ser carregados.'},
        'Person name': {
            'PTPT': 'Person name'},
        'Buttons': {
            'PTPT': 'Botões'},
        'Falhou a condição de edição no form': {
            'PTPT': 'Falhou a condição de edição no form'},
        'Scale ID': {
            'PTPT': 'Scale ID'},
        'My Lendings': {
            'PTPT': 'My Lendings'},
        'Web site': {
            'PTPT': 'Web site'},
        'Women': {
            'PTPT': 'Women'},
        'Reflection': {
            'PTPT': 'Reflection'},
        'Allow drawing polylines': {
            'PTPT': 'Permitir desenhar polilinhas'},
        'Table conditions': {
            'PTPT': 'Table conditions'},
        'Do you want to delete these records?': {
            'PTPT': 'Pretende eliminar estes registos?'},
        'Hour of Creation': {
            'PTPT': 'Hour of Creation'},
        'Abbreviation': {
            'PTPT': 'Abbreviation'},
        'Altura (ME)': {
            'PTPT': 'Altura (ME)'},
        'Login attempts': {
            'PTPT': 'Login attempts'},
        'Order number': {
            'PTPT': 'Order number'},
        'Request date': {
            'PTPT': 'Request date'},
        'Suplier': {
            'PTPT': 'Suplier'},
        'Translation': {
            'PTPT': 'Translation'},
        'Decomission': {
            'PTPT': 'Decomission'},
        'Período Actual': {
            'PTPT': 'Período Actual'},
        'Email Address': {
            'PTPT': 'Email Address'},
        'This help is for a field of type Logical': {
            'PTPT': 'This help is for a field of type Logical'},
        'Years': {
            'PTPT': 'Years'},
        'Cities': {
            'PTPT': 'Cidades'},
        'Gantt - Forward': {
            'PTPT': 'Gantt - Forward'},
        'Unique': {
            'PTPT': 'Unique'},
        'Documento a importar': {
            'PTPT': 'Documento a importar'},
        'Indicador (extenso)': {
            'PTPT': 'Indicador (extenso)'},
        'Sem existências': {
            'PTPT': 'Sem existências'},
        'Designação de Objetivo': {
            'PTPT': 'Designação de Objetivo'},
        'Single record': {
            'PTPT': 'Single record'},
        'Old / Incorrect': {
            'PTPT': 'Old / Incorrect'},
        'Employee number': {
            'PTPT': 'Employee number'},
        ' 1148_VERBOSE': {
            'PTPT': '<!DOCTYPE html>\n<html>\n<head>\n</head>\n<body>\n<p>Uma ajuda que levar&aacute; imagem no verboso.</p>\n<p><img src="Content/img/f-login__background.png"></p>\n</body>\n</html>'},
        'Origin X': {
            'PTPT': 'Origin X'},
        '>>DISPATCH': {
            'PTPT': '>>DISPATCH'},
        '  101': {
            'PTPT': 'Valor por omissão em percentagem da meta, para o limite superior do intervalo \'Bom\'.'},
        '   94': {
            'PTPT': 'Valor por omissão em precentagem da meta, para o limite inferior do intervalo \'Bom\'.'},
        'May': {
            'PTPT': 'May'},
        'Limit exceeded': {
            'PTPT': 'Limit exceeded'},
        'Type B': {
            'PTPT': 'Type B'},
        'Junho': {
            'PTPT': 'Junho'},
        'Start date': {
            'PTPT': 'Start date'},
        '  257': {
            'PTPT': 'Bonificações calculadas de maneira independente.'},
        '  435': {
            'PTPT': 'Logo'},
        '  317': {
            'PTPT': 'Chave da unidade orgânica no sistema de recursos humanos'},
        'ITEMS': {
            'PTPT': 'ITEMS'},
        'Receipt lines': {
            'PTPT': 'Receipt lines'},
        'Result message': {
            'PTPT': 'Result message'},
        'Não Apaga': {
            'PTPT': 'Não Apaga'},
        'Intern': {
            'PTPT': 'Intern'},
        'Perc. Mínimo': {
            'PTPT': 'Perc. Mínimo'},
        '  191': {
            'PTPT': 'Este campo serve para inserir o símbolo.'},
        '  273': {
            'PTPT': 'Dia, mês e ano do valor inicial'},
        'PHOTO': {
            'PTPT': 'PHOTO'},
        'Cc': {
            'PTPT': 'Cc'},
        'October': {
            'PTPT': 'October'},
        'FACILITIES': {
            'PTPT': 'FACILITIES'},
        'Word': {
            'PTPT': 'Word'},
        'Beginning of the year': {
            'PTPT': 'Beginning of the year'},
        'Category FAQS': {
            'PTPT': 'Category FAQS'},
        '   98': {
            'PTPT': 'Valor por omissão em percentagem da meta, para o limite inferior do intervalo \'Mau\''},
        'Eficiência': {
            'PTPT': 'Eficiência'},
        'Menu per table': {
            'PTPT': 'Menu per table'},
        'Falhou condição de inserção na tabela': {
            'PTPT': 'Falhou condição de inserção na tabela'},
        'Polaridade': {
            'PTPT': 'Polaridade'},
        'People from a Company': {
            'PTPT': 'People from a Company'},
        'ActivoBank': {
            'PTPT': 'ActivoBank'},
        '1123': {
            'PTPT': 'Help in table list'},
        'PDF': {
            'PTPT': 'PDF'},
        'Editable table list': {
            'PTPT': 'Expõe tabela editável'},
        'Warehouse': {
            'PTPT': 'Warehouse'},
        'Tags': {
            'PTPT': 'Tags'},
        'E-mail sent?': {
            'PTPT': 'E-mail sent?'},
        'Overcome Objections': {
            'PTPT': 'Overcome Objections'},
        '  395': {
            'PTPT': 'Sigla para mapa'},
        'Facility': {
            'PTPT': 'Facility'},
        '35': {
            'PTPT': '35'},
        'Rule': {
            'PTPT': 'Rule'},
        'Responsibles for the Indicators': {
            'PTPT': 'Responsibles for the Indicators'},
        'Local da regra': {
            'PTPT': 'Local da regra'},
        'Canceled by': {
            'PTPT': 'Canceled by'},
        'First incorporated facility': {
            'PTPT': 'Primeira instalação incorporada'},
        'Delete': {
            'PTPT': 'Eliminar'},
        '  436': {
            'PTPT': 'Entidade'},
        'Enough rate': {
            'PTPT': 'Enough rate'},
        'Período': {
            'PTPT': 'Período'},
        'Muito Boa': {
            'PTPT': 'Muito Boa'},
        'Scorecard appearance': {
            'PTPT': 'Scorecard appearance'},
        '    9': {
            'PTPT': 'Pessoa cujo género sexual não é possível identificar'},
        'Tax identification': {
            'PTPT': 'Tax identification'},
        'Equipment purchased': {
            'PTPT': 'Equipment purchased'},
        'Flight': {
            'PTPT': 'Flight'},
        'Date:': {
            'PTPT': 'Date:'},
        ' 1123': {
            'PTPT': 'Help in table list'},
        'Hora de criação': {
            'PTPT': 'Hora de criação'},
        ' 1109': {
            'PTPT': 'Choose the customer\'s address'},
        'Output quantity:': {
            'PTPT': 'Output quantity:'},
        'Facility type': {
            'PTPT': 'Facility type'},
        'Latitude and Longitude': {
            'PTPT': 'Latitude and Longitude'},
        'Passengers': {
            'PTPT': 'Passengers'},
        'Digital Attachements': {
            'PTPT': 'Digital Attachements'},
        'KPI graphics color': {
            'PTPT': 'KPI graphics color'},
        'End-of-period': {
            'PTPT': 'End-of-period'},
        'PT12345678901234567890123': {
            'PTPT': 'PT12345678901234567890123'},
        'Sales (phases)': {
            'PTPT': 'Sales (phases)'},
        '   20': {
            'PTPT': 'This help is for a field of type multiline text'},
        'Sub-goal of indicator': {
            'PTPT': 'Sub-goal of indicator'},
        'Floor': {
            'PTPT': 'Floor'},
        'Criado por:': {
            'PTPT': 'Criado por:'},
        'Text Color': {
            'PTPT': 'Text Color'},
        'string': {
            'PTPT': 'string'},
        'Game day': {
            'PTPT': 'Game day'},
        'E-mail to whom the message was sent': {
            'PTPT': 'E-mail to whom the message was sent'},
        'companhia aérea': {
            'PTPT': 'companhia aérea'},
        'External Entity': {
            'PTPT': 'External Entity'},
        'Erro on sending the email': {
            'PTPT': 'Erro on sending the email'},
        'Text (Upper case)': {
            'PTPT': 'Text (Upper case)'},
        'Profile picture': {
            'PTPT': 'Profile picture'},
        'Rooms': {
            'PTPT': 'Rooms'},
        'Sequential Movements': {
            'PTPT': 'Sequential Movements'},
        'Dispatches': {
            'PTPT': 'Dispatches'},
        'Responsavél': {
            'PTPT': 'Responsavél'},
        'Email (confirm)': {
            'PTPT': 'Email (confirmar)'},
        'Code:': {
            'PTPT': 'Código:'},
        'Profile': {
            'PTPT': 'Profile'},
        'Rare': {
            'PTPT': 'Rare'},
        'History': {
            'PTPT': 'History'},
        'Data Efeito': {
            'PTPT': 'Data Efeito'},
        '>CATEGORy': {
            'PTPT': '>CATEGORy'},
        'Region of the person:': {
            'PTPT': 'Region of the person:'},
        'Delivered': {
            'PTPT': 'Delivered'},
        '  379': {
            'PTPT': 'Designação a dar em vez de "Objetivo".'},
        'Strategic Objectives / Operational Objectives': {
            'PTPT': 'Strategic Objectives / Operational Objectives'},
        'Perspectiva': {
            'PTPT': 'Perspectiva'},
        'Professional abbreviation': {
            'PTPT': 'Professional abbreviation'},
        '  356': {
            'PTPT': 'Avanço no intervalo do Gantt'},
        '  393': {
            'PTPT': 'Data Máxima'},
        'Enforce table conditions': {
            'PTPT': 'Cumprir condições da tabela'},
        'One': {
            'PTPT': 'One'},
        '   19': {
            'PTPT': 'This help is for a field of type text'},
        '  112': {
            'PTPT': 'Descrição detalhada do Indicador, clarificando de que forma se pensa que influencia o Objectivo a que pertence.'},
        'Queue': {
            'PTPT': 'Queue'},
        'Justificação/Relatório': {
            'PTPT': 'Justificação/Relatório'},
        'Footer': {
            'PTPT': 'Footer'},
        'Currency (Interger)': {
            'PTPT': 'Currency (Interger)'},
        'Shadow height': {
            'PTPT': 'Shadow height'},
        'End date': {
            'PTPT': 'End date'},
        ' 1125': {
            'PTPT': 'help radio button opçao 2'},
        'Manufacturer\'s website': {
            'PTPT': 'Manufacturer\'s website'},
        'Active?': {
            'PTPT': 'Active?'},
        'Meta': {
            'PTPT': 'Meta'},
        '   93': {
            'PTPT': 'Valor em percentagem da meta para a emissão de alerta, sempre que o valor realizdo lhe seja igual ou inferior.'},
        '  186': {
            'PTPT': 'É a justificação referente ao alvo que se pretende alcançar.'},
        'Name:': {
            'PTPT': 'Name:'},
        'All the expenses': {
            'PTPT': 'Todas as despesas'},
        'Mapa global': {
            'PTPT': 'Mapa global'},
        'Aviso': {
            'PTPT': 'Aviso'},
        'Mensal': {
            'PTPT': 'Mensal'},
        'Origin ID': {
            'PTPT': 'Origin ID'},
        'Overcome': {
            'PTPT': 'Overcome'},
        'Identifier type': {
            'PTPT': 'Identifier type'},
        'Number of Bathrooms': {
            'PTPT': 'Numero de Casa de banhos'},
        'Destination X (ME)': {
            'PTPT': 'Destination X (ME)'},
        'Classe (Enumeração Numérica)': {
            'PTPT': 'Classe (Enumeração Numérica)'},
        ' 1088': {
            'PTPT': 'An office address. First choice for business related contacts during business hours.'},
        'Full Calendar events': {
            'PTPT': 'Full Calendar events'},
        'Last name': {
            'PTPT': 'Last name'},
        'Genio Quality Tests': {
            'PTPT': 'Genio Quality Tests'},
        'Campo Auxiliar Cont NA': {
            'PTPT': 'Campo Auxiliar Cont NA'},
        'Region': {
            'PTPT': 'Region'},
        ' 1106_VERBOSE': {
            'PTPT': 'If the low element is missing, the meaning is that the low boundary is not known.'},
        '   10': {
            'PTPT': 'Empréstimo de 7 dias'},
        'Categorizing repair...': {
            'PTPT': 'Categorizing repair...'},
        'Day Month Collection': {
            'PTPT': 'Day Month Collection'},
        'Origin X (ME)': {
            'PTPT': 'Origin X (ME)'},
        'Show and Block conditions': {
            'PTPT': 'Condições de Mostra e Bloqueia'},
        'Field Type': {
            'PTPT': 'Field Type'},
        '   24': {
            'PTPT': 'This help is for a field of type Currency decimal'},
        'Bad limit 2': {
            'PTPT': 'Bad limit 2'},
        'Point of Origin (ME)': {
            'PTPT': 'Point of Origin (ME)'},
        'Moving access': {
            'PTPT': 'Moving access'},
        'Bank Data': {
            'PTPT': 'Bank Data'},
        'Executed unique routine': {
            'PTPT': 'Executed unique routine'},
        '  177': {
            'PTPT': 'De onde vêm os dados que vão ser introduzidos neste indicador.'},
        'Strategy': {
            'PTPT': 'Strategy'},
        'Código': {
            'PTPT': 'Código'},
        'Messages': {
            'PTPT': 'Messages'},
        'Table price': {
            'PTPT': 'Table price'},
        'Lending of an equipment': {
            'PTPT': 'Lending of an equipment'},
        'Famílias de equipamentos': {
            'PTPT': 'Famílias de equipamentos'},
        'X de Destino': {
            'PTPT': 'X de Destino'},
        'June': {
            'PTPT': 'June'},
        'Company Name': {
            'PTPT': 'Nome da empresa'},
        'Languages': {
            'PTPT': 'Languages'},
        '>INTERESTED PARTY': {
            'PTPT': '>INTERESTED PARTY'},
        'Ícone do indicador': {
            'PTPT': 'Ícone do indicador'},
        ' 1141_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>This zone has verbose help.</p>
</body>
</html>'},
        'Logotipo Ministério': {
            'PTPT': 'Logotipo Ministério'},
        'Photo': {
            'PTPT': 'Photo'},
        'Beginning': {
            'PTPT': 'Beginning'},
        'Uppercase': {
            'PTPT': 'Uppercase'},
        'No rumour in the Company': {
            'PTPT': 'No rumour in the Company'},
        'Country of Birth': {
            'PTPT': 'País de nascimento'},
        'Entity': {
            'PTPT': 'Entity'},
        'Meta Real': {
            'PTPT': 'Meta Real'},
        'second level group': {
            'PTPT': 'second level group'},
        '  326': {
            'PTPT': 'Número de ordem utilizado para ordenação dos indicadores'},
        'Text with input': {
            'PTPT': 'Text with input'},
        'Condition type': {
            'PTPT': 'Condition type'},
        'Perc. Ale': {
            'PTPT': 'Perc. Ale'},
        '  174': {
            'PTPT': 'Se os dados desse indicador dizem respeito a: Valor Único,  Média, Somatório ou Contagem, dentro da periodicidade escolhida.'},
        'Loan Frequency': {
            'PTPT': 'Loan Frequency'},
        'Not applicable': {
            'PTPT': 'Not applicable'},
        'Deviation': {
            'PTPT': 'Deviation'},
        'Segment Type': {
            'PTPT': 'Segment Type'},
        'Card-Centered': {
            'PTPT': 'Card-Centered'},
        '  103': {
            'PTPT': 'Valor por omissão em percentagem da meta para o limite máximo do intervalo de referência. Pretende-se desta forma balizar o intervalo relevante de análise de modo a poder aplicar uma escala de avaliação refectivamente mensurável. Entende-se que a obtenção de resultados acima deste valor terá probabilidade baixa ou mesmo nula. No entanto o sistema comporta e controla eficazmente essa ocorrência.'},
        '  227': {
            'PTPT': 'Utilizador responsável pela actividade.'},
        'Decomission No.': {
            'PTPT': 'Decomission No.'},
        '>AGREGADOR': {
            'PTPT': '>AGREGADOR'},
        'Team': {
            'PTPT': 'Team'},
        'Filtering': {
            'PTPT': 'Filtering'},
        'Global article': {
            'PTPT': 'Global article'},
        '   33': {
            'PTPT': 'This help is for a field of type DATETIME'},
        'Fecho de Venda': {
            'PTPT': 'Fecho de Venda'},
        'Specialty': {
            'PTPT': 'Specialty'},
        'Bad limit': {
            'PTPT': 'Bad limit'},
        'Resources': {
            'PTPT': 'Resources'},
        'Coin': {
            'PTPT': 'Coin'},
        'Grouping of Equipment Types': {
            'PTPT': 'Grouping of Equipment Types'},
        'Room No:': {
            'PTPT': 'Room No:'},
        'Soma Bonif Encadeadas': {
            'PTPT': 'Soma Bonif Encadeadas'},
        'Tax data': {
            'PTPT': 'Tax data'},
        'Genre': {
            'PTPT': 'Genre'},
        'Integra c/ Documental?': {
            'PTPT': 'Integra c/ Documental?'},
        '   96': {
            'PTPT': 'Valor por omissão em percentagem da meta para o limite máximo do intervalo de referência. Pretende-se desta forma balizar o intervalo relevante de análise de modo a poder aplicar uma escala de avaliação efectivamente mensurável. Entende-se que a obtenção de resultados acima deste valor terá probabilidade baixa ou mesmo nula. No entanto o sistema comporta e controla eficazmente essa ocorrência.'},
        'Trigger -> DB + TR': {
            'PTPT': 'Trigger -> DB + TR'},
        '  173': {
            'PTPT': 'Medida que se vai usar para este indicador'},
        '  415': {
            'PTPT': 'Subtitulo no kpi'},
        'Caminho para Documentos': {
            'PTPT': 'Caminho para Documentos'},
        'Classe Económica': {
            'PTPT': 'Classe Económica'},
        'Chave Primária': {
            'PTPT': 'Chave Primária'},
        '  307': {
            'PTPT': 'Extensão'},
        'Entries': {
            'PTPT': 'Entries'},
        'Instant': {
            'PTPT': 'Instant'},
        '  253': {
            'PTPT': 'Descrição do objectivo.'},
        'Equipment Repairs': {
            'PTPT': 'Equipment Repairs'},
        'Bianual': {
            'PTPT': 'Bianual'},
        'Interessado': {
            'PTPT': 'Interessado'},
        'Equipamentos por tipos': {
            'PTPT': 'Equipamentos por tipos'},
        'Countries': {
            'PTPT': 'Países'},
        'Required': {
            'PTPT': 'Required'},
        'Manual filling field': {
            'PTPT': 'Manual filling field'},
        'Internal': {
            'PTPT': 'Internal'},
        'Cards': {
            'PTPT': 'Cards'},
        'Vertical layout - Vue': {
            'PTPT': 'Vertical layout - Vue'},
        'Indicator Goal': {
            'PTPT': 'Indicator Goal'},
        'Nº Horas Semanais': {
            'PTPT': 'Nº Horas Semanais'},
        'Campo com condições client-side': {
            'PTPT': 'Campo com condições client-side'},
        'Mínimo': {
            'PTPT': 'Mínimo'},
        'STMP User Access': {
            'PTPT': 'STMP User Access'},
        'Foto': {
            'PTPT': 'Foto'},
        ' 1110': {
            'PTPT': 'The name of the entity linked by parentId'},
        ' 1103_VERBOSE': {
            'PTPT': 'ISO 3166 3 letter codes can be used in place of a human readable country name.'},
        'Rest': {
            'PTPT': 'Rest'},
        'Header': {
            'PTPT': 'Header'},
        'Owner': {
            'PTPT': 'Owner'},
        'Perc. Min': {
            'PTPT': 'Perc. Min'},
        'Creation Date (DD/MM/YY)': {
            'PTPT': 'Creation Date (DD/MM/YY)'},
        '  330': {
            'PTPT': 'Valor usado no relatório QUAR para o ano N-2'},
        'Mail': {
            'PTPT': 'Mail'},
        'Allow feature removal': {
            'PTPT': 'Permitir a remoção de caraterísticas'},
        '1º Classe': {
            'PTPT': '1º Classe'},
        '  305': {
            'PTPT': 'Fax'},
        '1120_VERBOSE': {
            'PTPT': 'Help in the field verbose'},
        'Insert': {
            'PTPT': 'Insert'},
        '>REPAIRER': {
            'PTPT': '>REPAIRER'},
        'Modos de processamento': {
            'PTPT': 'Modos de processamento'},
        'Technical  area': {
            'PTPT': 'Technical  area'},
        '  197': {
            'PTPT': 'Escolher que tipo de Scorecard se vai utilizar:  avaliação da organização ou monitorização da mesma.'},
        'Bad Indicators': {
            'PTPT': 'Bad Indicators'},
        'Unknown': {
            'PTPT': 'Unknown'},
        'FAQS': {
            'PTPT': 'FAQS'},
        'Tipos de Unidade Org.': {
            'PTPT': 'Tipos de Unidade Org.'},
        'A condição de escrita da tabela não está a ser cumprida': {
            'PTPT': 'A condição de escrita da tabela não está a ser cumprida'},
        'Ponto de Origem': {
            'PTPT': 'Ponto de Origem'},
        'Basics': {
            'PTPT': 'Basics'},
        'Legenda': {
            'PTPT': 'Legenda'},
        'Alphabetic 3:': {
            'PTPT': 'Alphabetic 3:'},
        'Category types': {
            'PTPT': 'Category types'},
        'Obrigatório': {
            'PTPT': 'Obrigatório'},
        'Homework done': {
            'PTPT': 'Homework done'},
        'xxxx-xxx': {
            'PTPT': 'xxxx-xxx'},
        'Sub category': {
            'PTPT': 'Sub category'},
        'Expiration date': {
            'PTPT': 'Expiration date'},
        'List with columns from the Below table': {
            'PTPT': 'Lista com colunas da tabela abaixo'},
        'Total Activities': {
            'PTPT': 'Total Activities'},
        'Alternative Email': {
            'PTPT': 'Alternative Email'},
        'Recipient key \'Comodatário\'': {
            'PTPT': 'Recipient key \'Comodatário\''},
        'Logo': {
            'PTPT': 'Logo'},
        '  388': {
            'PTPT': 'Documentos do ciclo de gestão'},
        'Output documents': {
            'PTPT': 'Output documents'},
        'Timeline Secundary': {
            'PTPT': 'Timeline Secundary'},
        'Organic Unit Acronym': {
            'PTPT': 'Organic Unit Acronym'},
        'Valor (Ano N-1)': {
            'PTPT': 'Valor (Ano N-1)'},
        'Id': {
            'PTPT': 'Id'},
        'zipcode': {
            'PTPT': 'zipcode'},
        'Orders in group  (Integer field)': {
            'PTPT': 'Orders in group  (Integer field)'},
        '>TEAM PLAYING AWAY': {
            'PTPT': '>TEAM PLAYING AWAY'},
        'ZIP/Postal code': {
            'PTPT': 'ZIP/Postal code'},
        'Closing attempts': {
            'PTPT': 'Closing attempts'},
        '  422': {
            'PTPT': 'Observações'},
        'Última notificação': {
            'PTPT': 'Última notificação'},
        'Origin Y': {
            'PTPT': 'Origin Y'},
        'Condições de Mostra e Bloqueia': {
            'PTPT': 'Condições de Mostra e Bloqueia'},
        '  421': {
            'PTPT': 'Data Fim'},
        'Cabin Luggage Only': {
            'PTPT': 'Cabin Luggage Only'},
        'Accumulation Periods': {
            'PTPT': 'Accumulation Periods'},
        'Third-parties': {
            'PTPT': 'Third-parties'},
        'Row Ordering (Float field)': {
            'PTPT': 'Row Ordering (Float field)'},
        'Airport': {
            'PTPT': 'Airport'},
        'Attachment': {
            'PTPT': 'Attachment'},
        '0% Perc.': {
            'PTPT': '0% Perc.'},
        'Equipment -> c-groupbox--minor-border-top': {
            'PTPT': 'Equipamento  -> c-groupbox--minor-border-top'},
        'Background Color': {
            'PTPT': 'Background Color'},
        'Mau Sup.': {
            'PTPT': 'Mau Sup.'},
        'Shadow URL': {
            'PTPT': 'Shadow URL'},
        'Access to Organization': {
            'PTPT': 'Access to Organization'},
        'Equipment family': {
            'PTPT': 'Equipment family'},
        'List -> DB': {
            'PTPT': 'List -> DB'},
        'Order (Integer field)': {
            'PTPT': 'Order (Integer field)'},
        '  258': {
            'PTPT': 'Escolher que tipo de Scorecard se vai utilizar.'},
        '  301': {
            'PTPT': 'Código'},
        '  269': {
            'PTPT': 'Aviso de alerta relativamente ao resultado.'},
        '   29': {
            'PTPT': 'This help is for a field of type Image'},
        'Designation:': {
            'PTPT': 'Designação:'},
        '  303': {
            'PTPT': 'Ordem pai'},
        'Perpspective': {
            'PTPT': 'Perpspective'},
        'Type (Text)': {
            'PTPT': 'Type (Text)'},
        'Normal List': {
            'PTPT': 'Normal List'},
        'Estado da Iniciativa': {
            'PTPT': 'Estado da Iniciativa'},
        'Total Indicadores': {
            'PTPT': 'Total Indicadores'},
        'ALL CONTACTS': {
            'PTPT': 'TODOS OS CONTACTOS'},
        'Last': {
            'PTPT': 'Last'},
        'Cargo': {
            'PTPT': 'Cargo'},
        'DateTime (Minutes)': {
            'PTPT': 'DateTime (Minutes)'},
        'Manuals': {
            'PTPT': 'Manuals'},
        'Indicator Responsible': {
            'PTPT': 'Indicator Responsible'},
        'Em execução': {
            'PTPT': 'Em execução'},
        'Enumeration (Text)': {
            'PTPT': 'Enumeração (Texto)'},
        'Centrada': {
            'PTPT': 'Centrada'},
        'Curriculum': {
            'PTPT': 'Curriculum'},
        'Class (Enumeração de Texto)': {
            'PTPT': 'Class (Enumeração de Texto)'},
        'Somatório Pts Activ': {
            'PTPT': 'Somatório Pts Activ'},
        'All Lendings': {
            'PTPT': 'All Lendings'},
        '  199': {
            'PTPT': 'Inserção do  código postal.'},
        'Total Completed Projects': {
            'PTPT': 'Total Completed Projects'},
        'Flight ID': {
            'PTPT': 'Flight ID'},
        'Number of weekly hours': {
            'PTPT': 'Number of weekly hours'},
        'Training Exercise 12': {
            'PTPT': 'Exercício de formação 12'},
        'Aggregate': {
            'PTPT': 'Aggregate'},
        'Addresses': {
            'PTPT': 'Addresses'},
        '    4': {
            'PTPT': 'Coisa não fungível, que se há-de restituir findo o prazo estipulado.'},
        'Mock Person Creation': {
            'PTPT': 'Mock Person Creation'},
        'Operational objectives': {
            'PTPT': 'Operational objectives'},
        'Category': {
            'PTPT': 'Category'},
        'Filtered Checklist': {
            'PTPT': 'Filtered Checklist'},
        'Funcionário do Armazém': {
            'PTPT': 'Funcionário do Armazém'},
        'Identification name': {
            'PTPT': 'Identification name'},
        'Numeric Inputs': {
            'PTPT': 'Numeric Inputs'},
        '[PROPR->NAME]': {
            'PTPT': '[PROPR->NAME]'},
        ' 1136': {
            'PTPT': 'Valor de alerta, abaixo do qual é emitido um alerta ao responsáveis.'},
        '1ªViagem': {
            'PTPT': '1ªViagem'},
        '>AGGREGATOR': {
            'PTPT': '>AGGREGATOR'},
        'Client ip address': {
            'PTPT': 'Client ip address'},
        ' 1114': {
            'PTPT': 'Help in the zone'},
        'Checkin Date/Time': {
            'PTPT': 'Checkin Date/Time'},
        'Order line:': {
            'PTPT': 'Order line:'},
        '  456': {
            'PTPT': 'Número de horas semanais de trabalho na EG'},
        ' 1090': {
            'PTPT': 'This address is no longer in use (or was never correct but retained for records).'},
        'Date second': {
            'PTPT': 'Date second'},
        'Cumprir condições da tabela': {
            'PTPT': 'Cumprir condições da tabela'},
        'Alerta?': {
            'PTPT': 'Alerta?'},
        ' 1096': {
            'PTPT': 'The purpose of this address.'},
        'In use': {
            'PTPT': 'In use'},
        'Specific path with conditions with routine -> DB + MC + R': {
            'PTPT': 'Specific path with conditions with routine -> DB + MC + R'},
        'Outputs': {
            'PTPT': 'Outputs'},
        'Periodicidade de Scorecards': {
            'PTPT': 'Periodicidade de Scorecards'},
        'Asset parameter': {
            'PTPT': 'Asset parameter'},
        'Feedback Campo': {
            'PTPT': 'Feedback Campo'},
        '   13': {
            'PTPT': 'Empréstimo de 30 dias'},
        'Y de Origem (ME)': {
            'PTPT': 'Y de Origem (ME)'},
        '[EQUIP->REGISTNR] - [EQUIP->DESIGNAT] - [TPEQU->TIPOEQUI]': {
            'PTPT': '[EQUIP->REGISTNR] - [EQUIP->DESIGNAT] - [TPEQU->TIPOEQUI]'},
        'Horário': {
            'PTPT': 'Horário'},
        'UUID (aka GUID)': {
            'PTPT': 'UUID (aka GUID)'},
        'Registar': {
            'PTPT': 'Registar'},
        '1st trip (Loginal Enumeratoin)': {
            'PTPT': '1st trip (Loginal Enumeratoin)'},
        'Closing Attempts': {
            'PTPT': 'Closing Attempts'},
        'Sequence': {
            'PTPT': 'Sequence'},
        'Four': {
            'PTPT': 'Four'},
        'Normal List (Show-when columns)': {
            'PTPT': 'Lista Normal (Colunas com mostra-quando)'},
        'Valor anterior': {
            'PTPT': 'Valor anterior'},
        '  175': {
            'PTPT': 'Estratégia a adoptar pelo indicador'},
        'PERSON\'S PARENTS': {
            'PTPT': 'PERSON\'S PARENTS'},
        'It is nest within the first zone and it has the same style': {
            'PTPT': 'It is nest within the first zone and it has the same style'},
        '  270': {
            'PTPT': 'Bom resultado ou pode mesmo já ter atingido o resultado.'},
        'First': {
            'PTPT': 'Primeiro'},
        '  355': {
            'PTPT': 'Escala do Gantt'},
        'Undifferentiated': {
            'PTPT': 'Undifferentiated'},
        'Real value': {
            'PTPT': 'Real value'},
        'Process ID': {
            'PTPT': 'Process ID'},
        'Anual': {
            'PTPT': 'Anual'},
        ' 1101': {
            'PTPT': 'Sub-unit of a country with limited sovereignty in a federally organized country. A code may be used if codes are in common use (e.g. US 2 letter state codes)'},
        'Do you want to execute the routine for all records?': {
            'PTPT': 'Pretende executar a rotina para todos os registos?'},
        'Vendas': {
            'PTPT': 'Vendas'},
        'Owners': {
            'PTPT': 'Owners'},
        'Does not erase (ME)': {
            'PTPT': 'Does not erase (ME)'},
        'Popup anchor (x-axis)': {
            'PTPT': 'Popup anchor (x-axis)'},
        'Background color': {
            'PTPT': 'Background color'},
        'Catalog Items': {
            'PTPT': 'Catalog Items'},
        'Show Closed Maps': {
            'PTPT': 'Show Closed Maps'},
        'Lender: Gender': {
            'PTPT': 'Lender: Gender'},
        'Valor mínimo': {
            'PTPT': 'Valor mínimo'},
        'Real Estate List': {
            'PTPT': 'Real Estate List'},
        'PLACES': {
            'PTPT': 'PLACES'},
        'Soma Bonif Normal': {
            'PTPT': 'Soma Bonif Normal'},
        'Data de criação completa': {
            'PTPT': 'Data de criação completa'},
        'Motive': {
            'PTPT': 'Motive'},
        'To review': {
            'PTPT': 'To review'},
        '  131': {
            'PTPT': 'Sigla do Indicador Pai deste Indicador'},
        'real=float(24) (precision 7 digits) (storage: 4 byte)': {
            'PTPT': 'real=float(24) (precision 7 digits) (storage: 4 byte)'},
        'bought': {
            'PTPT': 'bought'},
        'Game': {
            'PTPT': 'Game'},
        'Employee Number': {
            'PTPT': 'Employee Number'},
        'Fields with table and form conditions': {
            'PTPT': 'Campos com condições na tabela e no formulário'},
        'Company Equipment': {
            'PTPT': 'Equipamento da empresa'},
        '  233': {
            'PTPT': 'O valor por omissão é de 1,00.'},
        'Real days (proj.)': {
            'PTPT': 'Real days (proj.)'},
        'Accumulation Type': {
            'PTPT': 'Accumulation Type'},
        'Logical (tinyint) (storage: 1 byte)': {
            'PTPT': 'Logical (tinyint) (storage: 1 byte)'},
        'Dispatch number': {
            'PTPT': 'Dispatch number'},
        'Altura': {
            'PTPT': 'Altura'},
        ' 1114_VERBOSE': {
            'PTPT': 'Help in the zone verbose'},
        'Passenger capacity on the plane': {
            'PTPT': 'Passenger capacity on the plane'},
        'Projectos': {
            'PTPT': 'Projectos'},
        'Manual name': {
            'PTPT': 'Manual name'},
        'Notifications': {
            'PTPT': 'Notifications'},
        ' 1089': {
            'PTPT': 'A temporary address. The period can provide more detailed information.'},
        '1120': {
            'PTPT': 'Help in the field'},
        '   30': {
            'PTPT': 'This help is for a field of type document'},
        'Apresentação efectuada': {
            'PTPT': 'Apresentação efectuada'},
        'Designação de Iniciativa': {
            'PTPT': 'Designação de Iniciativa'},
        'Question': {
            'PTPT': 'Question'},
        'Falhou condição de eliminação na tabela': {
            'PTPT': 'Falhou condição de eliminação na tabela'},
        'Attachments': {
            'PTPT': 'Attachments'},
        'Responsible': {
            'PTPT': 'Responsible'},
        'Logo (External File Image)': {
            'PTPT': 'Logo (External File Image)'},
        '  416': {
            'PTPT': 'Cor dos gráficos do KPI'},
        'Order No.': {
            'PTPT': 'Order No.'},
        'Status': {
            'PTPT': 'Status'},
        'Complete Date of Creation': {
            'PTPT': 'Complete Date of Creation'},
        'Equipment - 1 month until today': {
            'PTPT': 'Equipamento - 1 mês até hoje'},
        '  320': {
            'PTPT': 'Documento'},
        'Type of Equipment >Components': {
            'PTPT': 'Type of Equipment >Components'},
        'Without financial resources': {
            'PTPT': 'Without financial resources'},
        'Collapsible style': {
            'PTPT': 'Estilo colapsável'},
        '  205': {
            'PTPT': 'Escrever a morada electrónica .'},
        'Qweb Form Example': {
            'PTPT': 'Qweb Form Example'},
        'Acesso região': {
            'PTPT': 'Acesso região'},
        'Date Time': {
            'PTPT': 'Date Time'},
        'Manufacturer\'s website:': {
            'PTPT': 'Manufacturer\'s website:'},
        '  385': {
            'PTPT': 'Mapa global?'},
        'Ref.ª': {
            'PTPT': 'Ref.ª'},
        'Commodity': {
            'PTPT': 'Commodity'},
        'Types of segments': {
            'PTPT': 'Types of segments'},
        'Justification of Targets': {
            'PTPT': 'Justification of Targets'},
        'Employees by company': {
            'PTPT': 'Empregados por empresa'},
        'Manager': {
            'PTPT': 'Manager'},
        'Accordions': {
            'PTPT': 'Accordions'},
        'Y de Origem': {
            'PTPT': 'Y de Origem'},
        'Qtd output': {
            'PTPT': 'Qtd output'},
        'Tolerância': {
            'PTPT': 'Tolerância'},
        'Modo de processamento': {
            'PTPT': 'Modo de processamento'},
        'All employees': {
            'PTPT': 'Todos os trabalhadores'},
        'Árvore': {
            'PTPT': 'Árvore'},
        'Groups with style classes': {
            'PTPT': 'Groups with style classes'},
        'OU Acronym': {
            'PTPT': 'OU Acronym'},
        'Input documents': {
            'PTPT': 'Input documents'},
        'Company:': {
            'PTPT': 'Empresa:'},
        '>WAREHOUSE': {
            'PTPT': '>WAREHOUSE'},
        'Date of Creation (DD/MM/YY)': {
            'PTPT': 'Date of Creation (DD/MM/YY)'},
        'Letter Color': {
            'PTPT': 'Letter Color'},
        'Rules': {
            'PTPT': 'Rules'},
        'Output document': {
            'PTPT': 'Output document'},
        'Facilities map': {
            'PTPT': 'Facilities map'},
        '  170': {
            'PTPT': 'Classificação dos tipos de indicadores, conforme o seu impacto. Sendo Lead, de antecipação, e os Lag de resultados.'},
        ' 1092_VERBOSE': {
            'PTPT': 'An address expressed using postal conventions (as opposed to GPS or other location definition formats). This data type may be used to convey addresses for use in delivering mail as well as for visiting locations which might not be valid for mail delivery. There are a variety of postal address formats defined around the world.'},
        'ID': {
            'PTPT': 'ID'},
        'Visão': {
            'PTPT': 'Visão'},
        'Vision': {
            'PTPT': 'Vision'},
        'Phase Area': {
            'PTPT': 'Phase Area'},
        'Percentage': {
            'PTPT': 'Percentage'},
        'Visões (Instância)': {
            'PTPT': 'Visões (Instância)'},
        'Room Designation': {
            'PTPT': 'Room Designation'},
        'Not Visible on the website?': {
            'PTPT': 'Not Visible on the website?'},
        '>PERSON COUNTRY': {
            'PTPT': '>PERSON COUNTRY'},
        '   17': {
            'PTPT': 'Nesta lista só aparecem os Países com Imóveis'},
        'Details -> c-groupbox--minor': {
            'PTPT': 'Detalhes  -> c-groupbox--minor'},
        'Date of Creation': {
            'PTPT': 'Date of Creation'},
        'Shipping type': {
            'PTPT': 'Shipping type'},
        'Quantity': {
            'PTPT': 'Quantity'},
        'Budget': {
            'PTPT': 'Budget'},
        'Y (Mapa Estratégico)': {
            'PTPT': 'Y (Mapa Estratégico)'},
        'Do you want to execute the routine for a single record?': {
            'PTPT': 'Pretende executar a rotina para um único registo?'},
        'Cost': {
            'PTPT': 'Cost'},
        'Mensage ID': {
            'PTPT': 'Mensage ID'},
        '   68': {
            'PTPT': 'Data prevista de conclusão da Iniciativa / Projecto.'},
        'Order': {
            'PTPT': 'Order'},
        'Numeric 15.0 - big integer (storage: 8 byte)': {
            'PTPT': 'Numeric 15.0 - big integer (storage: 8 byte)'},
        'Objective value': {
            'PTPT': 'Objective value'},
        '>ARTICLE': {
            'PTPT': '>ARTICLE'},
        'Help in the text field': {
            'PTPT': 'Help in the text field'},
        'Zip code': {
            'PTPT': 'Zip code'},
        'Fields with table conditions': {
            'PTPT': 'Campos com condições na tabela'},
        'Price-by-hour': {
            'PTPT': 'Price-by-hour'},
        'Follow-up': {
            'PTPT': 'Follow-up'},
        'Add ANEXD': {
            'PTPT': 'Add ANEXD'},
        'Campo com condições server-side': {
            'PTPT': 'Campo com condições server-side'},
        'Parado': {
            'PTPT': 'Parado'},
        'Save and Return': {
            'PTPT': 'Save and Return'},
        'Closing the sale': {
            'PTPT': 'Closing the sale'},
        'Scorecard Frequency': {
            'PTPT': 'Scorecard Frequency'},
        'Equipment familiy': {
            'PTPT': 'Equipment familiy'},
        'Decimal places': {
            'PTPT': 'Decimal places'},
        'Parameters': {
            'PTPT': 'Parameters'},
        '  179': {
            'PTPT': 'Se os dados são inseridos data previamente estabelecida (data única) deverá colocar um visto na caixa de verificação.'},
        'Text Prop': {
            'PTPT': 'Text Prop'},
        '    7': {
            'PTPT': 'Masculine gender'},
        'Inserir': {
            'PTPT': 'Inserir'},
        'EMPLOYEE': {
            'PTPT': 'EMPLOYEE'},
        'Fixed date': {
            'PTPT': 'Fixed date'},
        'Segments': {
            'PTPT': 'Segments'},
        'Normal Form': {
            'PTPT': 'Normal Form'},
        '  428': {
            'PTPT': 'Cor minima dos mapas'},
        'Airplane Name': {
            'PTPT': 'Airplane Name'},
        'Encadeada': {
            'PTPT': 'Encadeada'},
        'Designação de Projeto': {
            'PTPT': 'Designação de Projeto'},
        '>COMOMODOR': {
            'PTPT': '>COMOMODOR'},
        'Tabela': {
            'PTPT': 'Tabela'},
        'Company\'s people count': {
            'PTPT': 'As pessoas da empresa contam'},
        'Lending Report': {
            'PTPT': 'Lending Report'},
        'Recipient\'s email': {
            'PTPT': 'Recipient\'s email'},
        'Organization access': {
            'PTPT': 'Organization access'},
        ' 1142_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Verbose Help in a logic field (checkbox)</p>
</body>
</html>'},
        'Organização': {
            'PTPT': 'Organização'},
        'Selection between limits -> SE + DB': {
            'PTPT': 'Selection between limits -> SE + DB'},
        'Acompanhamento': {
            'PTPT': 'Acompanhamento'},
        'Hidden': {
            'PTPT': 'Hidden'},
        'Changed by': {
            'PTPT': 'Alterado por'},
        'Y position': {
            'PTPT': 'Y position'},
        'IDENTIFICATION': {
            'PTPT': 'IDENTIFICATION'},
        '1234-5678-90123456789-01': {
            'PTPT': '1234-5678-90123456789-01'},
        'Agosto': {
            'PTPT': 'Agosto'},
        'Previous Value': {
            'PTPT': 'Previous Value'},
        'minimumValue=0 and maximumValue=1000000000': {
            'PTPT': 'minimumValue=0 and maximumValue=1000000000'},
        'Top': {
            'PTPT': 'Top'},
        'Prospection carried out': {
            'PTPT': 'Prospection carried out'},
        ' 1097': {
            'PTPT': 'Distinguishes between physical addresses (those you can visit) and mailing addresses (e.g. PO Boxes and care-of addresses). Most addresses are both.'},
        'Apartment type': {
            'PTPT': 'Tipo de apartamento'},
        'Item:': {
            'PTPT': 'Item:'},
        'Types of equipment': {
            'PTPT': 'Types of equipment'},
        'Palavra-Chave Acesso SMTP': {
            'PTPT': 'Palavra-Chave Acesso SMTP'},
        'Information elements': {
            'PTPT': 'Information elements'},
        'Justificação dos Alvos': {
            'PTPT': 'Justificação dos Alvos'},
        '  399': {
            'PTPT': 'Resultado: Definen los logros obtenidos con relación a los objetivos y metas planteados.\nProducto:  Miden los bienes y servicios que de manera cuantitativa son producidos y provistos por un determinado organismo público\nProceso:  Centran su medición en el desarrollo de las actividades, las cuales están vinculadas a garantizar la prestación de servicios o generación de productos'},
        'Toilet': {
            'PTPT': 'Toilet'},
        'Place Equipment in a Room': {
            'PTPT': 'Place Equipment in a Room'},
        'Facilities': {
            'PTPT': 'Facilities'},
        'Bad points': {
            'PTPT': 'Bad points'},
        'Mapa Pai?': {
            'PTPT': 'Mapa Pai?'},
        'Company Id': {
            'PTPT': 'Identificação da empresa'},
        'Nº Horas de Trabalho': {
            'PTPT': 'Nº Horas de Trabalho'},
        'Real goal': {
            'PTPT': 'Real goal'},
        'Color': {
            'PTPT': 'Color'},
        'Nivel II': {
            'PTPT': 'Nivel II'},
        'Primeira viagem': {
            'PTPT': 'Primeira viagem'},
        'Good': {
            'PTPT': 'Good'},
        'Pontos Bonificação': {
            'PTPT': 'Pontos Bonificação'},
        'Space type': {
            'PTPT': 'Space type'},
        'Geographical coordinate': {
            'PTPT': 'Geographical coordinate'},
        'Show Record': {
            'PTPT': 'Show Record'},
        '  318': {
            'PTPT': 'Estado calculado a partir da tabela de relatórios'},
        'Multiple records': {
            'PTPT': 'Multiple records'},
        'Tree Map': {
            'PTPT': 'Tree Map'},
        'Allow drawing markers': {
            'PTPT': 'Permitir marcadores de desenho'},
        'Min Points': {
            'PTPT': 'Min Points'},
        'Perc. Max': {
            'PTPT': 'Perc. Max'},
        'Image Background': {
            'PTPT': 'Image Background'},
        'Bathroom': {
            'PTPT': 'Bathroom'},
        'Address': {
            'PTPT': 'Address'},
        'Training Exercise 05': {
            'PTPT': 'Exercício de formação 05'},
        'Grau Bom': {
            'PTPT': 'Grau Bom'},
        '   80': {
            'PTPT': 'Campo preenchido automáticamente pelo somatórios dos pontos efectivos atribuídos a cada Actividade da Iniciativa / Projecto, de acordo com a conclusão das mesmas e eventual atrazo face à data prevista para o efeito.'},
        'Components': {
            'PTPT': 'Components'},
        'Technical categories': {
            'PTPT': 'Technical categories'},
        'Abril': {
            'PTPT': 'Abril'},
        'Available from': {
            'PTPT': 'Available from'},
        'Expert': {
            'PTPT': 'Expert'},
        'Comodative access': {
            'PTPT': 'Comodative access'},
        'Objective percentage': {
            'PTPT': 'Objective percentage'},
        'Telephone': {
            'PTPT': 'Telephone'},
        'Next - previous =': {
            'PTPT': 'Next - previous ='},
        'Sequential no.': {
            'PTPT': 'Sequential no.'},
        'Grau': {
            'PTPT': 'Grau'},
        'Disaggregation lines': {
            'PTPT': 'Disaggregation lines'},
        'Training Exercise 16': {
            'PTPT': 'Exercício de formação 16'},
        'Descontinuado': {
            'PTPT': 'Descontinuado'},
        'Countries Reside': {
            'PTPT': 'Países de residência'},
        'Manual destination': {
            'PTPT': 'Manual destination'},
        'Passenger ID': {
            'PTPT': 'Passenger ID'},
        '   11': {
            'PTPT': 'Empréstimo de um dia'},
        'Qualidade dos Dados': {
            'PTPT': 'Qualidade dos Dados'},
        '+351': {
            'PTPT': '+351'},
        'Translations': {
            'PTPT': 'Translations'},
        'BY OMISSION': {
            'PTPT': 'BY OMISSION'},
        'Lados': {
            'PTPT': 'Lados'},
        'Not verified': {
            'PTPT': 'Not verified'},
        'Perspective (Model)': {
            'PTPT': 'Perspective (Model)'},
        '  241': {
            'PTPT': 'Inserir palavra-chave.'},
        'Sim / Não': {
            'PTPT': 'Sim / Não'},
        'Numeric enumeration': {
            'PTPT': 'Numeric enumeration'},
        'Room Designation:': {
            'PTPT': 'Room Designation:'},
        '  380': {
            'PTPT': 'Designação a dar em vez de "Indicador".'},
        'Inspection visits': {
            'PTPT': 'Inspection visits'},
        'Nome da companhia aérea': {
            'PTPT': 'Nome da companhia aérea'},
        'Row ordering in group, 1 level (Float field)': {
            'PTPT': 'Row ordering in group, 1 level (Float field)'},
        '>DADATARY': {
            'PTPT': '>DADATARY'},
        'Async process attachments': {
            'PTPT': 'Async process attachments'},
        'AI Agents': {
            'PTPT': 'AI Agents'},
        'Indicator icon': {
            'PTPT': 'Indicator icon'},
        'Genus': {
            'PTPT': 'Genus'},
        'Organization, New Organization': {
            'PTPT': 'Organization, New Organization'},
        'Office': {
            'PTPT': 'Office'},
        'Period': {
            'PTPT': 'Period'},
        'Property types': {
            'PTPT': 'Property types'},
        'Execute': {
            'PTPT': 'Execute'},
        'External docs fields': {
            'PTPT': 'External docs fields'},
        'Colorpicker': {
            'PTPT': 'Colorpicker'},
        'Não responde': {
            'PTPT': 'Não responde'},
        'Styles': {
            'PTPT': 'Styles'},
        'Photos:': {
            'PTPT': 'Photos:'},
        'Form': {
            'PTPT': 'Form'},
        'Equipmente families': {
            'PTPT': 'Equipmente families'},
        'Row Ordering (Integer field)': {
            'PTPT': 'Row Ordering (Integer field)'},
        'date': {
            'PTPT': 'date'},
        '  383': {
            'PTPT': 'Limitações para cumprimento de metas'},
        'Notification ID that generated the message': {
            'PTPT': 'Notification ID that generated the message'},
        'Falhou a condição de inserção no form': {
            'PTPT': 'Falhou a condição de inserção no form'},
        'Data Valor Inicial': {
            'PTPT': 'Data Valor Inicial'},
        'Scorecard type': {
            'PTPT': 'Scorecard type'},
        'Pré-abordagem': {
            'PTPT': 'Pré-abordagem'},
        'Complete Date': {
            'PTPT': 'Complete Date'},
        'Parent Order': {
            'PTPT': 'Parent Order'},
        'Employees': {
            'PTPT': 'Empregados'},
        'OU type': {
            'PTPT': 'OU type'},
        '1117_VERBOSE': {
            'PTPT': 'Help in the year field  verb'},
        'Indicator Category': {
            'PTPT': 'Indicator Category'},
        'Hour': {
            'PTPT': 'Hour'},
        '  354': {
            'PTPT': 'Data'},
        'GRAI – Global Returnable Asset Identifier': {
            'PTPT': 'GRAI – Global Returnable Asset Identifier'},
        'Disponível': {
            'PTPT': 'Disponível'},
        'Work': {
            'PTPT': 'Work'},
        'Respons. Iniciativa': {
            'PTPT': 'Respons. Iniciativa'},
        'Country': {
            'PTPT': 'Pais'},
        'Organic Units': {
            'PTPT': 'Organic Units'},
        'Contact Type:': {
            'PTPT': 'Contact Type:'},
        'Ministério': {
            'PTPT': 'Ministério'},
        'Collection': {
            'PTPT': 'Collection'},
        'Imóveis': {
            'PTPT': 'Imóveis'},
        'Enum - Female people': {
            'PTPT': 'Enum - Pessoas do sexo feminino'},
        'Global parameters': {
            'PTPT': 'Global parameters'},
        'time': {
            'PTPT': 'time'},
        'Falhou condição de visualização na tabela': {
            'PTPT': 'Falhou condição de visualização na tabela'},
        'Flight Scale': {
            'PTPT': 'Flight Scale'},
        'Filtrar Responsáveis': {
            'PTPT': 'Filtrar Responsáveis'},
        'More -> c-groupbox--minor': {
            'PTPT': 'More -> c-groupbox--minor'},
        'Period End': {
            'PTPT': 'Period End'},
        'já viajou antes?': {
            'PTPT': 'já viajou antes?'},
        'big integer (storage: 8 byte)': {
            'PTPT': 'big integer (storage: 8 byte)'},
        'Relations (Strategic Map)': {
            'PTPT': 'Relations (Strategic Map)'},
        'Origem dos Dados': {
            'PTPT': 'Origem dos Dados'},
        'Report': {
            'PTPT': 'Report'},
        'Field Types': {
            'PTPT': 'Field Types'},
        'GENIO L1': {
            'PTPT': 'GENIO L1'},
        'Logbook': {
            'PTPT': 'Logbook'},
        'Dadatarians': {
            'PTPT': 'Dadatarians'},
        'Airport Name': {
            'PTPT': 'Airport Name'},
        'Error sending email': {
            'PTPT': 'Error sending email'},
        'Approach taken': {
            'PTPT': 'Approach taken'},
        'There are {STY_OVERVIEW_Count} cards in homepage': {
            'PTPT': 'There are {STY_OVERVIEW_Count} cards in homepage'},
        'language': {
            'PTPT': 'language'},
        'Remove from the Rooms an Equipment': {
            'PTPT': 'Remove from the Rooms an Equipment'},
        '    2': {
            'PTPT': 'Aquele que pede emprestado por comodato.\n\nhttps://dicionario.priberam.org/comodat%C3%A1rio [consultado em 17-12-2018].'},
        '  321': {
            'PTPT': 'Logotipo do ministério'},
        'Actividade': {
            'PTPT': 'Actividade'},
        'Layer name': {
            'PTPT': 'Layer name'},
        'Auxiliary Field Cont NA': {
            'PTPT': 'Auxiliary Field Cont NA'},
        ' 1027': {
            'PTPT': 'Total de referências'},
        'Type of data': {
            'PTPT': 'Type of data'},
        'Exceeded Points': {
            'PTPT': 'Exceeded Points'},
        'Global list': {
            'PTPT': 'Global list'},
        'Unidade': {
            'PTPT': 'Unidade'},
        'Price per hour:': {
            'PTPT': 'Price per hour:'},
        'Data de partida (segundos)': {
            'PTPT': 'Data de partida (segundos)'},
        'Trigger -> DB + T': {
            'PTPT': 'Trigger -> DB + T'},
        'Building/house number': {
            'PTPT': 'Número do edifício/casa'},
        'Numeric Decimal': {
            'PTPT': 'Numeric Decimal'},
        'Inverse?': {
            'PTPT': 'Inverse?'},
        'Calculations exclusively with working days?': {
            'PTPT': 'Calculations exclusively with working days?'},
        '  322': {
            'PTPT': 'Data de aprovação do QUAR'},
        'Conflito': {
            'PTPT': 'Conflito'},
        'integer (storage: 4 byte)': {
            'PTPT': 'integer (storage: 4 byte)'},
        'Total points': {
            'PTPT': 'Total points'},
        'Storage date': {
            'PTPT': 'Storage date'},
        'Mau': {
            'PTPT': 'Mau'},
        '>>PERSON RESPONSIBLE': {
            'PTPT': '>>PERSON RESPONSIBLE'},
        'Bcc': {
            'PTPT': 'Bcc'},
        'Separadores': {
            'PTPT': 'Separadores'},
        'Total value': {
            'PTPT': 'Total value'},
        'Balance': {
            'PTPT': 'Balance'},
        'Campos com condições na tabela e no formulário': {
            'PTPT': 'Campos com condições na tabela e no formulário'},
        'Equipment decommission': {
            'PTPT': 'Desativação de equipamento'},
        'New Menu': {
            'PTPT': 'New Menu'},
        'Add Points Activities': {
            'PTPT': 'Add Points Activities'},
        'Warehouse Management System': {
            'PTPT': 'Warehouse Management System'},
        'Sequential No.': {
            'PTPT': 'Sequential No.'},
        'More': {
            'PTPT': 'More'},
        'Asset Manual': {
            'PTPT': 'Asset Manual'},
        '  423': {
            'PTPT': 'Orçamento'},
        'Tipo de acumulação': {
            'PTPT': 'Tipo de acumulação'},
        'Profile Picture': {
            'PTPT': 'Profile Picture'},
        'Alterado por': {
            'PTPT': 'Alterado por'},
        'Label': {
            'PTPT': 'Label'},
        'Specific buttons -> DB + MB + F': {
            'PTPT': 'Specific buttons -> DB + MB + F'},
        'Alert Perc.': {
            'PTPT': 'Alert Perc.'},
        'Mostrar Anos Anteriores': {
            'PTPT': 'Mostrar Anos Anteriores'},
        'Bank Companies': {
            'PTPT': 'Bank Companies'},
        'Menu 3': {
            'PTPT': 'Menu 3'},
        '+34': {
            'PTPT': '+34'},
        'Asset number': {
            'PTPT': 'Asset number'},
        'Primary key': {
            'PTPT': 'Primary key'},
        'Field with server-side conditions': {
            'PTPT': 'Campo com condições server-side'},
        'Perc. do Objectivo': {
            'PTPT': 'Perc. do Objectivo'},
        'No decision-making power': {
            'PTPT': 'No decision-making power'},
        'HIST_PATTERN_DESCRIPTION': {
            'PTPT': 'Name and company should create history when changed. Id is not under history so it shouldn\'t create a change.'},
        'Translated Title': {
            'PTPT': 'Translated Title'},
        'ID de Destino': {
            'PTPT': 'ID de Destino'},
        'Currency (Decimal)': {
            'PTPT': 'Currency (Decimal)'},
        'Segment': {
            'PTPT': 'Segment'},
        'Tab': {
            'PTPT': 'Tab'},
        'Título traduzido': {
            'PTPT': 'Título traduzido'},
        'Text (QR Code)': {
            'PTPT': 'Text (QR Code)'},
        'Suppliers': {
            'PTPT': 'Suppliers'},
        'Nº Horas Esperadas': {
            'PTPT': 'Nº Horas Esperadas'},
        'Notification Messages': {
            'PTPT': 'Notification Messages'},
        ' 1143_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Verbose help in a manual filling field</p>
</body>
</html>'},
        'Arrival Date': {
            'PTPT': 'Arrival Date'},
        'Tipo de processo': {
            'PTPT': 'Tipo de processo'},
        'Custom action button -> MB': {
            'PTPT': 'Botão de ação personalizado -> MB'},
        'Maximum': {
            'PTPT': 'Maximum'},
        'Regra': {
            'PTPT': 'Regra'},
        'Mês': {
            'PTPT': 'Mês'},
        'Prospecção efectuada': {
            'PTPT': 'Prospecção efectuada'},
        'Chosen Categories': {
            'PTPT': 'Chosen Categories'},
        'Conditional': {
            'PTPT': 'Conditional'},
        'Sim': {
            'PTPT': 'Sim'},
        'c-groupbox--minor-border-top': {
            'PTPT': 'c-groupbox--minor-border-top'},
        'Activity Responsible': {
            'PTPT': 'Activity Responsible'},
        'Email 2': {
            'PTPT': 'Email 2'},
        'Limite Bom': {
            'PTPT': 'Limite Bom'},
        'Airport From': {
            'PTPT': 'Airport From'},
        'Table': {
            'PTPT': 'Table'},
        '  280': {
            'PTPT': 'Chave primária'},
        '>TEAM PLAYING AT HOME': {
            'PTPT': '>TEAM PLAYING AT HOME'},
        'Total Não Aplicáveis': {
            'PTPT': 'Total Não Aplicáveis'},
        'Date/Time Inputs': {
            'PTPT': 'Date/Time Inputs'},
        '@Decomission': {
            'PTPT': '@Decomission'},
        'Sem capacidade de decisão': {
            'PTPT': 'Sem capacidade de decisão'},
        ' 1094': {
            'PTPT': 'A physical address that can be visited.'},
        'Automatically Generate': {
            'PTPT': 'Automatically Generate'},
        'Start time': {
            'PTPT': 'Start time'},
        'Individual notifications': {
            'PTPT': 'Individual notifications'},
        'State/Province': {
            'PTPT': 'State/Province'},
        'Sem dados?': {
            'PTPT': 'Sem dados?'},
        'Sum Linked Bonuses': {
            'PTPT': 'Sum Linked Bonuses'},
        'Parent Map': {
            'PTPT': 'Parent Map'},
        'Polyline color': {
            'PTPT': 'Polyline color'},
        'ID (Stategic Map)': {
            'PTPT': 'ID (Stategic Map)'},
        '   25': {
            'PTPT': 'This help is for a field of type Logical'},
        'Prospect and Qualify': {
            'PTPT': 'Prospect and Qualify'},
        'Conjunto de dados Estatísticos e administrativos': {
            'PTPT': 'Conjunto de dados Estatísticos e administrativos'},
        '  429': {
            'PTPT': 'Cor máxima dos mapas'},
        'Information Element': {
            'PTPT': 'Information Element'},
        'End of period': {
            'PTPT': 'End of period'},
        'UI Components': {
            'PTPT': 'UI Components'},
        '1116_VERBOSE': {
            'PTPT': 'Help in the Multiline field verbose'},
        'Diário': {
            'PTPT': 'Diário'},
        'Query for external API': {
            'PTPT': 'Query for external API'},
        'X (Mapa Estratégico)': {
            'PTPT': 'X (Mapa Estratégico)'},
        'Airports': {
            'PTPT': 'Airports'},
        'March': {
            'PTPT': 'March'},
        '>EXIT DOCUMENT': {
            'PTPT': '>EXIT DOCUMENT'},
        'Numeric decimal': {
            'PTPT': 'Numeric decimal'},
        'Default style': {
            'PTPT': 'Estilo predefinido'},
        'Editar': {
            'PTPT': 'Editar'},
        '  274': {
            'PTPT': 'Inserir valor inicial.'},
        'Building types': {
            'PTPT': 'Tipos de edifícios'},
        'Foto de Perfil': {
            'PTPT': 'Foto de Perfil'},
        'Trigger -> T': {
            'PTPT': 'Trigger -> T'},
        '>COMPANY': {
            'PTPT': '>COMPANY'},
        'Indicator Description': {
            'PTPT': 'Indicator Description'},
        'Média dias Internos': {
            'PTPT': 'Média dias Internos'},
        'Outline weight': {
            'PTPT': 'Outline weight'},
        'Does not erase': {
            'PTPT': 'Does not erase'},
        'Type of Indicator': {
            'PTPT': 'Type of Indicator'},
        'Sufficient Indicators': {
            'PTPT': 'Sufficient Indicators'},
        'Shelf': {
            'PTPT': 'Shelf'},
        'Map height': {
            'PTPT': 'Map height'},
        'Setembro': {
            'PTPT': 'Setembro'},
        '   28': {
            'PTPT': 'This help is for a field of type enumeration (logical)'},
        'View Mode': {
            'PTPT': 'View Mode'},
        'Acumulado': {
            'PTPT': 'Acumulado'},
        'If out of date': {
            'PTPT': 'If out of date'},
        ' 1145_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Verbose help in the enumeration item</p>
</body>
</html>'},
        'Specifications': {
            'PTPT': 'Specifications'},
        'Novembro': {
            'PTPT': 'Novembro'},
        'Acesso a Organização': {
            'PTPT': 'Acesso a Organização'},
        'Lending in the period': {
            'PTPT': 'Lending in the period'},
        'Type of segments': {
            'PTPT': 'Type of segments'},
        'Owner default style': {
            'PTPT': 'Owner default style'},
        'Periodicidades de Recolha': {
            'PTPT': 'Periodicidades de Recolha'},
        'Cellphone': {
            'PTPT': 'Cellphone'},
        'Sends attachment?': {
            'PTPT': 'Sends attachment?'},
        'Size (m2)': {
            'PTPT': 'Tamanho (m2)'},
        'Date': {
            'PTPT': 'Date'},
        'conditional (Boolean) (smallint) (storage: 2 byte)': {
            'PTPT': 'conditional (Boolean) (smallint) (storage: 2 byte)'},
        'Right': {
            'PTPT': 'Right'},
        'Multiple formats': {
            'PTPT': 'Multiple formats'},
        'Furniture': {
            'PTPT': 'Furniture'},
        'Starting time with inclusive boundary': {
            'PTPT': 'Starting time with inclusive boundary'},
        'Tipo de condição': {
            'PTPT': 'Tipo de condição'},
        'Optional records': {
            'PTPT': 'Optional records'},
        'Baggage Type': {
            'PTPT': 'Baggage Type'},
        ' 1128': {
            'PTPT': 'Valor mínimo para esta meta (corresponde ao valor mínimo da barra). Para indicadores QUAR de polaridade decrescente este campo corresponde ao Valor Crítico.'},
        'Prop': {
            'PTPT': 'Prop'},
        'Manuais': {
            'PTPT': 'Manuais'},
        'Has login?': {
            'PTPT': 'Has login?'},
        'Potential points': {
            'PTPT': 'Potential points'},
        'Justification': {
            'PTPT': 'Justification'},
        'CONTACT': {
            'PTPT': 'CONTACT'},
        'Stored': {
            'PTPT': 'Stored'},
        'Lead': {
            'PTPT': 'Lead'},
        'Delete Optional records': {
            'PTPT': 'Eliminar registos facultativos'},
        '2. c-groupbox--minor': {
            'PTPT': '2. c-groupbox--minor'},
        'Date and Time': {
            'PTPT': 'Date and Time'},
        '  120': {
            'PTPT': 'Alterado em'},
        'Data de Nascimento': {
            'PTPT': 'Data de Nascimento'},
        'Traduções': {
            'PTPT': 'Traduções'},
        'Ponto de Destino': {
            'PTPT': 'Ponto de Destino'},
        'Global Item': {
            'PTPT': 'Global Item'},
        'Floor number': {
            'PTPT': 'Número do andar'},
        'Warehouse employees': {
            'PTPT': 'Warehouse employees'},
        'Displacement and relationship to the destination side of the connecting line': {
            'PTPT': 'Displacement and relationship to the destination side of the connecting line'},
        'Warehouse api': {
            'PTPT': 'Warehouse api'},
        'Training Exercise 10': {
            'PTPT': 'Exercício de formação 10'},
        'Limite bom': {
            'PTPT': 'Limite bom'},
        '   31': {
            'PTPT': 'This help is for a field of type YEAR'},
        'Product': {
            'PTPT': 'Product'},
        'Componentes do kit': {
            'PTPT': 'Componentes do kit'},
        'Money - decimal (1-10) (storage: 5 byte)': {
            'PTPT': 'Money - decimal (1-10) (storage: 5 byte)'},
        'Cliente': {
            'PTPT': 'Cliente'},
        '   85': {
            'PTPT': 'Introduza aqui uma descrição detalhada da Visão que fundamente o Mapa Estratégico. A Visão representa a forma como nos pretendemos rever no futuro, o estado de graça para o qual nos queremos direccionar.'},
        'Countries Born': {
            'PTPT': 'Países nascidos'},
        'Processing': {
            'PTPT': 'Processing'},
        'Baggage': {
            'PTPT': 'Baggage'},
        'Month day': {
            'PTPT': 'Month day'},
        'Space': {
            'PTPT': 'Space'},
        'Article': {
            'PTPT': 'Article'},
        'Designação de Perspetiva': {
            'PTPT': 'Designação de Perspetiva'},
        'Row Ordering': {
            'PTPT': 'Row Ordering'},
        'Global': {
            'PTPT': 'Global'},
        'Periodicidade de Recolha': {
            'PTPT': 'Periodicidade de Recolha'},
        'Vision icons': {
            'PTPT': 'Vision icons'},
        'Properties by agent': {
            'PTPT': 'Properties by agent'},
        'Minimum zoom to load features': {
            'PTPT': 'Minimum zoom to load features'},
        'DateSecond': {
            'PTPT': 'DateSecond'},
        'Account': {
            'PTPT': 'Account'},
        '  339': {
            'PTPT': 'Referência para efeitos de relatório QUAR'},
        '% Real': {
            'PTPT': '% Real'},
        'Valor Real': {
            'PTPT': 'Valor Real'},
        'Chave RH': {
            'PTPT': 'Chave RH'},
        'Companhia aérea': {
            'PTPT': 'Companhia aérea'},
        'Details': {
            'PTPT': 'Detalhes'},
        'Field feedback': {
            'PTPT': 'Field feedback'},
        'Digital Attachments': {
            'PTPT': 'Digital Attachments'},
        'real estate': {
            'PTPT': 'real estate'},
        ' 1095': {
            'PTPT': 'An address that is both physical and postal.'},
        'Height (ME)': {
            'PTPT': 'Height (ME)'},
        'Card-Img-Background': {
            'PTPT': 'Card-Img-Background'},
        'Receipt number': {
            'PTPT': 'Receipt number'},
        'Gerar automaticamente': {
            'PTPT': 'Gerar automaticamente'},
        'Description': {
            'PTPT': 'Description'},
        'X Position': {
            'PTPT': 'X Position'},
        'Asset identification': {
            'PTPT': 'Asset identification'},
        'Training Exercise 19': {
            'PTPT': 'Exercício de formação 19'},
        'Qualificação': {
            'PTPT': 'Qualificação'},
        'None': {
            'PTPT': 'None'},
        'Approval Date': {
            'PTPT': 'Approval Date'},
        '>AFFINITY GENRE': {
            'PTPT': '>AFFINITY GENRE'},
        'Frequency': {
            'PTPT': 'Frequency'},
        'Símbolo': {
            'PTPT': 'Símbolo'},
        'Has diferente segments?': {
            'PTPT': 'Has diferente segments?'},
        'Text (UUID aka GUID)': {
            'PTPT': 'Text (UUID aka GUID)'},
        'All': {
            'PTPT': 'Todos'},
        'Games': {
            'PTPT': 'Games'},
        'Effect Date': {
            'PTPT': 'Effect Date'},
        'Primary color': {
            'PTPT': 'Primary color'},
        'Controller': {
            'PTPT': 'Controller'},
        'Data Fim': {
            'PTPT': 'Data Fim'},
        ' 1137': {
            'PTPT': 'Percentagem do valor objectivo a que corresponde o valor do limite bom.'},
        'Cod. Postal': {
            'PTPT': 'Cod. Postal'},
        '    1': {
            'PTPT': 'Que ou quem empresta coisa não fungível para a tornar a receber; que ou quem empresta por comodato\n\nhttps://dicionario.priberam.org/comodante [consultado em 17-12-2018].'},
        'Asset Manuals': {
            'PTPT': 'Asset Manuals'},
        'Tax identification no.': {
            'PTPT': 'Tax identification no.'},
        'Address District': {
            'PTPT': 'Address District'},
        'Visão (extenso)': {
            'PTPT': 'Visão (extenso)'},
        'Nivel I': {
            'PTPT': 'Nivel I'},
        'Mission Description': {
            'PTPT': 'Mission Description'},
        '>TYPE OF EQUIPMENT': {
            'PTPT': '>TYPE OF EQUIPMENT'},
        'Height': {
            'PTPT': 'Height'},
        'Warehouses': {
            'PTPT': 'Warehouses'},
        'User': {
            'PTPT': 'User'},
        'System': {
            'PTPT': 'System'},
        '1118': {
            'PTPT': 'Help in the time field'},
        'Documents': {
            'PTPT': 'Documents'},
        '  286': {
            'PTPT': 'Chave estrangeira'},
        'Slope': {
            'PTPT': 'Slope'},
        'Tipo de UO': {
            'PTPT': 'Tipo de UO'},
        'Identification number': {
            'PTPT': 'Identification number'},
        'Another': {
            'PTPT': 'Outro'},
        'Geographic Coordinates': {
            'PTPT': 'Geographic Coordinates'},
        'Tables (Foreign Keys)': {
            'PTPT': 'Tables (Foreign Keys)'},
        'Park': {
            'PTPT': 'Park'},
        'Career record': {
            'PTPT': 'Career record'},
        'Enumerations fields': {
            'PTPT': 'Campos de enumeração'},
        'Groupbox styles': {
            'PTPT': 'Groupbox styles'},
        'Out-of-date lendings': {
            'PTPT': 'Out-of-date lendings'},
        'Ministry Logo': {
            'PTPT': 'Ministry Logo'},
        '123456789': {
            'PTPT': '123456789'},
        'Visualization form -> F': {
            'PTPT': 'Visualization form -> F'},
        'Postal & Physical': {
            'PTPT': 'Postal & Physical'},
        '  397': {
            'PTPT': 'Tipo de segmento'},
        'dateTime': {
            'PTPT': 'dateTime'},
        'Whole Line On': {
            'PTPT': 'Whole Line On'},
        'Missão': {
            'PTPT': 'Missão'},
        'Dependent on': {
            'PTPT': 'Dependent on'},
        'Asset tag lists': {
            'PTPT': 'Asset tag lists'},
        'Box (Strategic Map)': {
            'PTPT': 'Box (Strategic Map)'},
        'Boarding Gate': {
            'PTPT': 'Boarding Gate'},
        'Goal Designation': {
            'PTPT': 'Goal Designation'},
        'E-mail': {
            'PTPT': 'E-mail'},
        '   83': {
            'PTPT': 'Identificação do Mapa Estratégico de modo a que seja diferenciado dos demais. Pretende-se uma designação curta que possa ser lida em toda e qualquer forma de apresentação gráfica.'},
        'X (Strategic Map)': {
            'PTPT': 'X (Strategic Map)'},
        'Text Field': {
            'PTPT': 'Text Field'},
        'Notification Email Signatures': {
            'PTPT': 'Notification Email Signatures'},
        'Type 2': {
            'PTPT': 'Type 2'},
        'Cidade': {
            'PTPT': 'Cidade'},
        'Professional categories': {
            'PTPT': 'Professional categories'},
        'Furnished': {
            'PTPT': 'Furnished'},
        '>>RECEIPT': {
            'PTPT': '>>RECEIPT'},
        '3. c-groupbox--minor-border-top': {
            'PTPT': '3. c-groupbox--minor-border-top'},
        'Asset types': {
            'PTPT': 'Asset types'},
        'Afetação Contabilidade Custos': {
            'PTPT': 'Afetação Contabilidade Custos'},
        'Percentagem Real': {
            'PTPT': 'Percentagem Real'},
        'double = float(53) (precision 15 digits) (storage: 8 byte)': {
            'PTPT': 'double = float(53) (precision 15 digits) (storage: 8 byte)'},
        'Receipt date': {
            'PTPT': 'Receipt date'},
        'Numeric (Integer)': {
            'PTPT': 'Numeric (Integer)'},
        'Fields': {
            'PTPT': 'Fields'},
        'Preparation': {
            'PTPT': 'Preparation'},
        'Departure Date': {
            'PTPT': 'Departure Date'},
        '  440': {
            'PTPT': 'Instituição'},
        'Respons. Actividade': {
            'PTPT': 'Respons. Actividade'},
        'Equipment': {
            'PTPT': 'Equipment'},
        'Decomission per year': {
            'PTPT': 'Decomission per year'},
        'End': {
            'PTPT': 'End'},
        'Eficacia': {
            'PTPT': 'Eficacia'},
        'Amount': {
            'PTPT': 'Amount'},
        'Birthdate': {
            'PTPT': 'Data de nascimento'},
        'Project': {
            'PTPT': 'Project'},
        'Largura': {
            'PTPT': 'Largura'},
        'No': {
            'PTPT': 'No'},
        'Line': {
            'PTPT': 'Line'},
        'Objective icon': {
            'PTPT': 'Objective icon'},
        'weighting QUAR': {
            'PTPT': 'weighting QUAR'},
        'Duration': {
            'PTPT': 'Duração'},
        'Factible': {
            'PTPT': 'Factible'},
        'Ano construído': {
            'PTPT': 'Ano construído'},
        'Afetação / Contabilidade Custos': {
            'PTPT': 'Afetação / Contabilidade Custos'},
        'Project state': {
            'PTPT': 'Project state'},
        '   21': {
            'PTPT': 'This help is for a field of type numeric'},
        'Aggregated per year': {
            'PTPT': 'Aggregated per year'},
        'Certified Series Number': {
            'PTPT': 'Certified Series Number'},
        'Encerrada': {
            'PTPT': 'Encerrada'},
        'Fields with form conditions': {
            'PTPT': 'Campos com condições no formulário'},
        'No. register': {
            'PTPT': 'No. register'},
        'Async process attachment': {
            'PTPT': 'Async process attachment'},
        '40': {
            'PTPT': '40'},
        'Nivel III': {
            'PTPT': 'Nivel III'},
        'No Factible': {
            'PTPT': 'No Factible'},
        'Emission Date': {
            'PTPT': 'Emission Date'},
        'Postal location': {
            'PTPT': 'Postal location'},
        'Property Value': {
            'PTPT': 'Property Value'},
        'Observation': {
            'PTPT': 'Observation'},
        '1119_VERBOSE': {
            'PTPT': 'Help in the date field verbose'},
        'Tipo de Dado': {
            'PTPT': 'Tipo de Dado'},
        '>LANGUAGE': {
            'PTPT': '>LANGUAGE'},
        '12345678912': {
            'PTPT': '12345678912'},
        'Item Property': {
            'PTPT': 'Item Property'},
        'Please make sure you have entered email correctly': {
            'PTPT': 'Please make sure you have entered email correctly'},
        'Property List': {
            'PTPT': 'Property List'},
        'Values': {
            'PTPT': 'Values'},
        'In': {
            'PTPT': 'In'},
        'Individual Notifications': {
            'PTPT': 'Individual Notifications'},
        'Timeline - Months': {
            'PTPT': 'Timeline - Months'},
        '>>PRODUCT': {
            'PTPT': '>>PRODUCT'},
        'Lag': {
            'PTPT': 'Lag'},
        'Editor dados pessoais': {
            'PTPT': 'Editor dados pessoais'},
        'Leaflet': {
            'PTPT': 'Leaflet'},
        'Indicadores Suficientes': {
            'PTPT': 'Indicadores Suficientes'},
        'Tamanho (m2)': {
            'PTPT': 'Tamanho (m2)'},
        '  304': {
            'PTPT': 'Telefone'},
        'CONTACT TYPE': {
            'PTPT': 'CONTACT TYPE'},
        'Bonificações Automáticas': {
            'PTPT': 'Bonificações Automáticas'},
        'Completion Date': {
            'PTPT': 'Completion Date'},
        'Evaluation Type': {
            'PTPT': 'Evaluation Type'},
        '2ª Classe': {
            'PTPT': '2ª Classe'},
        '% Superado': {
            'PTPT': '% Superado'},
        'Condição': {
            'PTPT': 'Condição'},
        'Planeado': {
            'PTPT': 'Planeado'},
        'Initial Value': {
            'PTPT': 'Initial Value'},
        ' 1146': {
            'PTPT': 'Help in the second enumeration item'},
        '  134': {
            'PTPT': 'Tipo de meta para os Segmentos. Se os segmentos são Acumulados por Média ou por Somatório.'},
        'Latitudes range from -90 to 90.': {
            'PTPT': 'Latitudes range from -90 to 90.'},
        'Flag': {
            'PTPT': 'Flag'},
        'Bill To': {
            'PTPT': 'Bill To'},
        'Save': {
            'PTPT': 'Save'},
        'End time': {
            'PTPT': 'End time'},
        'Dispatch': {
            'PTPT': 'Dispatch'},
        'Equipamentos por tipos detalhes': {
            'PTPT': 'Equipamentos por tipos detalhes'},
        'Preparing': {
            'PTPT': 'Preparing'},
        'Data Fixa Recolha': {
            'PTPT': 'Data Fixa Recolha'},
        'Posição X': {
            'PTPT': 'Posição X'},
        'Dictionary': {
            'PTPT': 'Dictionary'},
        'Motive:': {
            'PTPT': 'Motive:'},
        '  299': {
            'PTPT': 'Unidade orgânica'},
        'First name': {
            'PTPT': 'Nome próprio'},
        'Room designation': {
            'PTPT': 'Room designation'},
        'REGISTRATION IN THE PLATFORM': {
            'PTPT': 'REGISTRATION IN THE PLATFORM'},
        'c': {
            'PTPT': 'c'},
        'Type of Sub-goals': {
            'PTPT': 'Type of Sub-goals'},
        'Subject': {
            'PTPT': 'Subject'},
        'NºFuncionário': {
            'PTPT': 'NºFuncionário'},
        'Received': {
            'PTPT': 'Received'},
        'Employee': {
            'PTPT': 'Employee'},
        'Professional category': {
            'PTPT': 'Professional category'},
        'Sexo da pessoa': {
            'PTPT': 'Sexo da pessoa'},
        'Image': {
            'PTPT': 'Image'},
        'history': {
            'PTPT': 'history'},
        'Parameter': {
            'PTPT': 'Parameter'},
        'CAREER': {
            'PTPT': 'CAREER'},
        'Registration': {
            'PTPT': 'Registration'},
        '  124': {
            'PTPT': 'Referência para o dado'},
        'NºTelefone': {
            'PTPT': 'NºTelefone'},
        'Time of birth': {
            'PTPT': 'Time of birth'},
        'Evolution in categories': {
            'PTPT': 'Evolution in categories'},
        '{GQT_UNUSED_ITEMS_Count} items': {
            'PTPT': '{GQT_UNUSED_ITEMS_Count} items'},
        'Specific path with conditions -> DB + MC + F': {
            'PTPT': 'Specific path with conditions -> DB + MC + F'},
        'Inversa?': {
            'PTPT': 'Inversa?'},
        ' 1124_VERBOSE': {
            'PTPT': 'Help in button to form verbose'},
        'Visible on homepage?': {
            'PTPT': 'Visible on homepage?'},
        '>> STATUS': {
            'PTPT': '>> STATUS'},
        'Group (Basic Types)': {
            'PTPT': 'Group (Basic Types)'},
        'N/A': {
            'PTPT': 'N/A'},
        'Startegic Map': {
            'PTPT': 'Startegic Map'},
        'Address Types': {
            'PTPT': 'Address Types'},
        '  398': {
            'PTPT': 'Descrição do tipo de segmento'},
        'Maximum Price': {
            'PTPT': 'Maximum Price'},
        'N.º funcionário': {
            'PTPT': 'N.º funcionário'},
        '  336': {
            'PTPT': 'Dia de recolha dos dados. Insira o dia em que os dados devem ser carregados, conforme a periocidade de recolha definida e o Tipo a definir. Exemplo: para uma periodicidade mensal, o dia 10 e o Tipo “Período seguinte” significa que os dados devem ser carregados até ao dia 10 do mês seguinte.'},
        'Number of expected hours': {
            'PTPT': 'Number of expected hours'},
        '   26': {
            'PTPT': 'This help is for a field of type conditional'},
        'Last - First =': {
            'PTPT': 'Last - First ='},
        'ADMINISTRATOR': {
            'PTPT': 'ADMINISTRATOR'},
        'GridSlideShow': {
            'PTPT': 'GridSlideShow'},
        'Previous year': {
            'PTPT': 'Previous year'},
        'Classification of Levels': {
            'PTPT': 'Classification of Levels'},
        'Support': {
            'PTPT': 'Support'},
        'Timeline Days- Armazém': {
            'PTPT': 'Timeline Days- Armazém'},
        'Qtd entry': {
            'PTPT': 'Qtd entry'},
        'Equipment repairs:': {
            'PTPT': 'Equipment repairs:'},
        'Map Description': {
            'PTPT': 'Map Description'},
        'Individual': {
            'PTPT': 'Individual'},
        'Multine Text': {
            'PTPT': 'Multine Text'},
        '>>LOGIN': {
            'PTPT': '>>LOGIN'},
        'Specific path with conditions -> DB + MB + MC + F ': {
            'PTPT': 'Specific path with conditions -> DB + MB + MC + F '},
        'Sigla da UO': {
            'PTPT': 'Sigla da UO'},
        'Tipos de condição': {
            'PTPT': 'Tipos de condição'},
        '  121': {
            'PTPT': 'Criado por'},
        '    5': {
            'PTPT': 'Notificação aos Comodatários para devolução de equipamento'},
        'Automatic bonuses': {
            'PTPT': 'Automatic bonuses'},
        'Formula Description': {
            'PTPT': 'Formula Description'},
        'Text Enumeration': {
            'PTPT': 'Text Enumeration'},
        'Timeline - Days': {
            'PTPT': 'Timeline - Days'},
        'Entid key': {
            'PTPT': 'Entid key'},
        'Users': {
            'PTPT': 'Users'},
        '  272': {
            'PTPT': 'Superou os limites.'},
        'Table List One action': {
            'PTPT': 'Table List One action'},
        'Yes': {
            'PTPT': 'Yes'},
        'Code': {
            'PTPT': 'Código'},
        ' 1102': {
            'PTPT': 'A postal code designating a region defined by the postal service.'},
        'Good limit 2': {
            'PTPT': 'Good limit 2'},
        'Group 2': {
            'PTPT': 'Group 2'},
        'Lending': {
            'PTPT': 'Lending'},
        'Query': {
            'PTPT': 'Query'},
        '>EQUIPMENT': {
            'PTPT': '>EQUIPMENT'},
        'Specific path with conditions with routine -> DB + MB + MC + R': {
            'PTPT': 'Specific path with conditions with routine -> DB + MB + MC + R'},
        'Reference': {
            'PTPT': 'Reference'},
        '  417': {
            'PTPT': 'Global: Se refiere a los indicadores de la lista oficial del sistema de Naciones Unidas.\nNacional: Se refiere a la propuesta nacional que proviene de las instituciones relacionadas a la meta.'},
        'ZIP/Popstal code': {
            'PTPT': 'ZIP/Popstal code'},
        'Town/City': {
            'PTPT': 'Town/City'},
        'Items in use': {
            'PTPT': 'Items in use'},
        'Persons by gender': {
            'PTPT': 'Persons by gender'},
        'Seat': {
            'PTPT': 'Seat'},
        'Date of the last data': {
            'PTPT': 'Date of the last data'},
        'Lista de campos': {
            'PTPT': 'Lista de campos'},
        'Seller': {
            'PTPT': 'Seller'},
        'Dispatch status': {
            'PTPT': 'Dispatch status'},
        'Day': {
            'PTPT': 'Day'},
        'Bought': {
            'PTPT': 'Bought'},
        '  377': {
            'PTPT': 'Indica se o Indicador respeita o intervalo de tempo definido para apresentação de dados?'},
        '  300': {
            'PTPT': 'Sigla da unidade orgânica'},
        '\'Entity\'': {
            'PTPT': '\'Entity\''},
        'It is nest within the third zone and it has the default style': {
            'PTPT': 'It is nest within the third zone and it has the default style'},
        'Condições': {
            'PTPT': 'Condições'},
        '  277': {
            'PTPT': 'Campo que guarda o caminho onde foi guardada a imagem.'},
        'Full Calendar': {
            'PTPT': 'Full Calendar'},
        'Document Path': {
            'PTPT': 'Document Path'},
        'Groups (Basic)': {
            'PTPT': 'Groups (Basic)'},
        'Removing Equipment from a Room': {
            'PTPT': 'Removing Equipment from a Room'},
        'City': {
            'PTPT': 'Cidade'},
        'Background color for category': {
            'PTPT': 'Background color for category'},
        'Data de nascimento': {
            'PTPT': 'Data de nascimento'},
        'Tipo de Indicador': {
            'PTPT': 'Tipo de Indicador'},
        'Avaliação': {
            'PTPT': 'Avaliação'},
        'Perspectives (Instances)': {
            'PTPT': 'Perspectives (Instances)'},
        'Interested': {
            'PTPT': 'Interested'},
        'Nacionalidade': {
            'PTPT': 'Nacionalidade'},
        'Fórmula Integração': {
            'PTPT': 'Fórmula Integração'},
        'Title': {
            'PTPT': 'Title'},
        'Ship': {
            'PTPT': 'Ship'},
        '   36': {
            'PTPT': 'This help is for a field of type Creation: Date'},
        'To routine': {
            'PTPT': 'To routine'},
        'Process type': {
            'PTPT': 'Process type'},
        'Imóveis numa Região': {
            'PTPT': 'Imóveis numa Região'},
        'Error sending mail': {
            'PTPT': 'Error sending mail'},
        'Date seconds': {
            'PTPT': 'Date seconds'},
        'Equipment: Bought': {
            'PTPT': 'Equipment: Bought'},
        'To translate': {
            'PTPT': 'To translate'},
        'Pais': {
            'PTPT': 'Pais'},
        'Repaired on': {
            'PTPT': 'Repaired on'},
        'País:': {
            'PTPT': 'País:'},
        'Contagem': {
            'PTPT': 'Contagem'},
        'Descrição da Iniciativa': {
            'PTPT': 'Descrição da Iniciativa'},
        'Degree': {
            'PTPT': 'Degree'},
        'Nome da Companhia': {
            'PTPT': 'Nome da Companhia'},
        'Age': {
            'PTPT': 'Age'},
        'title in kpi': {
            'PTPT': 'title in kpi'},
        '   66': {
            'PTPT': 'Denominação da Iniciativa / Projecto de forma a que o mesmo seja fácilmente identificável.'},
        'QUIDGEST': {
            'PTPT': 'QUIDGEST'},
        'Prod. e Cresc.': {
            'PTPT': 'Prod. e Cresc.'},
        '>ARMAZEM': {
            'PTPT': '>ARMAZEM'},
        'Facility type Parameter': {
            'PTPT': 'Facility type Parameter'},
        'HTML format?': {
            'PTPT': 'HTML format?'},
        '   75': {
            'PTPT': 'Deve aqui ser total e completamente descrita a Iniciativa / Projecto, incluindo os potenciais riscos e ou factores potenciadores da boa concretização e conclusão da mesma.'},
        'X Position (ME)': {
            'PTPT': 'X Position (ME)'},
        'Airline Name': {
            'PTPT': 'Airline Name'},
        'Multiple connections (Strategic Map)': {
            'PTPT': 'Multiple connections (Strategic Map)'},
        '   92': {
            'PTPT': 'Valor por omissão em percentagem da meta, para o limite superior do intervalo \'Mau\''},
        'Objective Perc.': {
            'PTPT': 'Objective Perc.'},
        '##CUSTOMER': {
            'PTPT': '##CUSTOMER'},
        'Novobanco': {
            'PTPT': 'Novobanco'},
        'Opção 2': {
            'PTPT': 'Opção 2'},
        'Slaughtered goods': {
            'PTPT': 'Slaughtered goods'},
        'Char String': {
            'PTPT': 'Char String'},
        'Contact type': {
            'PTPT': 'Contact type'},
        'Máximo Sup.': {
            'PTPT': 'Máximo Sup.'},
        'Lending:': {
            'PTPT': 'Lending:'},
        'Equip: Loan frequency': {
            'PTPT': 'Equip: Loan frequency'},
        'Thumbnail': {
            'PTPT': 'Thumbnail'},
        'SMTP Access Password': {
            'PTPT': 'SMTP Access Password'},
        'Maximum Perc': {
            'PTPT': 'Maximum Perc'},
        'Qnty Hours': {
            'PTPT': 'Qnty Hours'},
        ' 1105_VERBOSE': {
            'PTPT': 'A period specifies a range of times. The context of use will specify whether the entire range applies (e.g. "the patient was an inpatient of the hospital for this time range") or one value from the period applies (e.g. "give to the patient between 2 and 4 pm on 24-Jun 2013").\n\nIf the start element is missing, the start of the period is not known. If the end element is missing, it means that the period is ongoing, or the start may be in the past, and the end date in the future, which means that period is expected/planned to end at the specified time\n\nThe end value includes any matching date/time. For example, the period 2011-05-23 to 2011-05-27 includes all the times from the start of the 23rd May through to the end of the 27th of May.'},
        'Monitorização': {
            'PTPT': 'Monitorização'},
        'Title icon in kpi': {
            'PTPT': 'Title icon in kpi'},
        'Value:': {
            'PTPT': 'Value:'},
        'Ordered': {
            'PTPT': 'Ordered'},
        'last': {
            'PTPT': 'last'},
        'Person/Department to contact': {
            'PTPT': 'Person/Department to contact'},
        'Company -> c-groupbox--title-background': {
            'PTPT': 'Company -> c-groupbox--title-background'},
        'Hora de partida': {
            'PTPT': 'Hora de partida'},
        'Background color of the tag': {
            'PTPT': 'Background color of the tag'},
        'Início do Ano': {
            'PTPT': 'Início do Ano'},
        'Departure hour': {
            'PTPT': 'Departure hour'},
        'Campos com condições na tabela': {
            'PTPT': 'Campos com condições na tabela'},
        'Funcionários': {
            'PTPT': 'Funcionários'},
        'Shadow width': {
            'PTPT': 'Shadow width'},
        'Asset tag list': {
            'PTPT': 'Asset tag list'},
        'Notification ID': {
            'PTPT': 'Notification ID'},
        'Auxiliary Field Cont': {
            'PTPT': 'Auxiliary Field Cont'},
        'Catalog articles': {
            'PTPT': 'Catalog articles'},
        'Histogram': {
            'PTPT': 'Histogram'},
        'Not in use': {
            'PTPT': 'Not in use'},
        'Perc. Limite Bom': {
            'PTPT': 'Perc. Limite Bom'},
        ' 1091': {
            'PTPT': 'An address to be used to send bills, invoices, receipts etc.'},
        'Organization Sales': {
            'PTPT': 'Organization Sales'},
        'It is nest within the second zone and it has the default style': {
            'PTPT': 'It is nest within the second zone and it has the default style'},
        '   32': {
            'PTPT': 'This help is for a field of type DATE'},
        'Receipts of goods': {
            'PTPT': 'Receipts of goods'},
        'Specific path with conditions -> DB + MB + MC + F': {
            'PTPT': 'Specific path with conditions -> DB + MB + MC + F'},
        'Legend': {
            'PTPT': 'Legend'},
        'Cabeçalho': {
            'PTPT': 'Cabeçalho'},
        '  204': {
            'PTPT': 'Inserir correio electrónico .'},
        '  256': {
            'PTPT': 'Utilizador com acesso.'},
        '  122': {
            'PTPT': 'Alterado por'},
        'No financial resources': {
            'PTPT': 'No financial resources'},
        'Disaggregation line': {
            'PTPT': 'Disaggregation line'},
        'Last update': {
            'PTPT': 'Last update'},
        'Multiline Text': {
            'PTPT': 'Multiline Text'},
        'Trabalho de casa efectuado': {
            'PTPT': 'Trabalho de casa efectuado'},
        'Building type': {
            'PTPT': 'Tipo de edifício'},
        ' 1140': {
            'PTPT': 'Nome do auditor'},
        'Whole Line Off': {
            'PTPT': 'Whole Line Off'},
        'TesteTeste': {
            'PTPT': 'TesteTeste'},
        'Notification': {
            'PTPT': 'Notification'},
        'Sub-goals of indicators': {
            'PTPT': 'Sub-goals of indicators'},
        'Image (binary)': {
            'PTPT': 'Image (binary)'},
        'Tipo de equipamento em árvore': {
            'PTPT': 'Tipo de equipamento em árvore'},
        'Foreign Key': {
            'PTPT': 'Foreign Key'},
        ' 1126': {
            'PTPT': 'help radio button opçao 1'},
        'Dezembro': {
            'PTPT': 'Dezembro'},
        'Tipo de edifício': {
            'PTPT': 'Tipo de edifício'},
        'Days for return period': {
            'PTPT': 'Days for return period'},
        'Reverse?': {
            'PTPT': 'Reverse?'},
        'Multiple Select List': {
            'PTPT': 'Multiple Select List'},
        'This help is for a field of type enumeration (Text)': {
            'PTPT': 'This help is for a field of type enumeration (Text)'},
        'Alerta': {
            'PTPT': 'Alerta'},
        'Decimal (1-10) (storage: 5 byte)': {
            'PTPT': 'Decimal (1-10) (storage: 5 byte)'},
        'Months': {
            'PTPT': 'Months'},
        'Specific path with conditions with trigger -> DB + MC + T': {
            'PTPT': 'Specific path with conditions with trigger -> DB + MC + T'},
        '  125': {
            'PTPT': 'Data de referência do dado'},
        'Lending No': {
            'PTPT': 'Lending No'},
        'Author': {
            'PTPT': 'Author'},
        'Logo 2': {
            'PTPT': 'Logo 2'},
        'Activity:': {
            'PTPT': 'Activity:'},
        '1123_VERBOSE': {
            'PTPT': 'Ajuda na lista de tabelas verbosa'},
        ' 1124': {
            'PTPT': 'Help in button to form'},
        'Gauge': {
            'PTPT': 'Gauge'},
        '  105': {
            'PTPT': 'Denominação da Perspectiva. De acordo com a descrição de Empresa ou Instituição como conjunto de Recursos, Organizados para atender a determinados Clientes com vista a Resultados de Criação de Valor.'},
        'Total Bonificações': {
            'PTPT': 'Total Bonificações'},
        'Posição X (ME)': {
            'PTPT': 'Posição X (ME)'},
        'SKU': {
            'PTPT': 'SKU'},
        'Parent': {
            'PTPT': 'Parent'},
        'Impacto': {
            'PTPT': 'Impacto'},
        '>>Manufacturer': {
            'PTPT': '>>Manufacturer'},
        '>PROJECT': {
            'PTPT': '>PROJECT'},
        'Radio': {
            'PTPT': 'Radio'},
        '0%': {
            'PTPT': '0%'},
        '   18': {
            'PTPT': 'This help is for a radio button'},
        'Field state': {
            'PTPT': 'Estado do campo'},
        '  180': {
            'PTPT': 'Dia de referência dos dados. Insira o dia a que os dados devem respeitar, conforme a periocidade de recolha definida. Exemplo: para uma periodicidade mensal, o dia 31 significa que os dados vão ser referentes ao último dia de cada mês.'},
        ' 1063': {
            'PTPT': 'Documento a importar'},
        ' 1146_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Verbose help in the second enumeration item</p>
</body>
</html>'},
        'Entity name': {
            'PTPT': 'Entity name'},
        'Person History': {
            'PTPT': 'Person History'},
        'Accordion': {
            'PTPT': 'Accordion'},
        'Equipment: Loan frequency': {
            'PTPT': 'Equipment: Loan frequency'},
        'Presentation made': {
            'PTPT': 'Presentation made'},
        'Sales': {
            'PTPT': 'Sales'},
        'Monitoring and monitoring instruments': {
            'PTPT': 'Monitoring and monitoring instruments'},
        '   97': {
            'PTPT': 'Valores por omissão para o limite inferior do intervalo de referência para toda e qualquer meta, em percentagem sobre a própria meta. Pretende-se desta forma desenhar em abstracto o alvo para toda e qualquer meta, de forma a limitar o intervalo de referencia para a valoração dos vários níveis de avaliação e de concretização. No presente caso de metas de indicadores de polaridade \'menor é melhor\', ou seja de tipo decrescente, este valor deve de representar uma concretização em resultados inferiores à nossa melhor expectativa.'},
        '  425': {
            'PTPT': 'E-mail Remetente'},
        'Posição Y (ME)': {
            'PTPT': 'Posição Y (ME)'},
        ' 1107': {
            'PTPT': 'The end of the period. If the end of the period is missing, it means that the period is ongoing.'},
        'Regions of a country': {
            'PTPT': 'Regions of a country'},
        'Lending Explorer': {
            'PTPT': 'Lending Explorer'},
        'Apresentação': {
            'PTPT': 'Apresentação'},
        'Wharehouse api': {
            'PTPT': 'Wharehouse api'},
        'Approach made': {
            'PTPT': 'Approach made'},
        'Manual bonus': {
            'PTPT': 'Manual bonus'},
        'Birth date': {
            'PTPT': 'Birth date'},
        'Product identification': {
            'PTPT': 'Product identification'},
        'Mark items from list to -> DE + DB': {
            'PTPT': 'Mark items from list to -> DE + DB'},
        'Pontos Meta': {
            'PTPT': 'Pontos Meta'},
        'Contact Number': {
            'PTPT': 'Contact Number'},
        'Processos': {
            'PTPT': 'Processos'},
        'Temporary': {
            'PTPT': 'Temporary'},
        '   65': {
            'PTPT': 'Numerador, que permite ordenar as iniciativas, de modo a poder ser criada alguma forma de precedência entre as mesmas. Também se aconselha ordenar de forma diferenciada as Iniciativas / Projectos, das Iniciativas PDCA, por exemplo ordenando estas últimas sempre a partir de 90.'},
        'Username': {
            'PTPT': 'Username'},
        'Technical documentation': {
            'PTPT': 'Technical documentation'},
        'Trigger -> DB + MB + TR': {
            'PTPT': 'Trigger -> DB + MB + TR'},
        'Card-img-Background': {
            'PTPT': 'Card-img-Background'},
        'QUAR weights': {
            'PTPT': 'QUAR weights'},
        'registo': {
            'PTPT': 'registo'},
        'Designação de Indicador': {
            'PTPT': 'Designação de Indicador'},
        'Y (Strategic Map)': {
            'PTPT': 'Y (Strategic Map)'},
        'Documents path': {
            'PTPT': 'Documents path'},
        'E-mail sent': {
            'PTPT': 'E-mail sent'},
        'Locations': {
            'PTPT': 'Locations'},
        'small integer (storage: 2 byte)': {
            'PTPT': 'small integer (storage: 2 byte)'},
        'Drive': {
            'PTPT': 'Drive'},
        'Initiative designation': {
            'PTPT': 'Initiative designation'},
        'Numero de Casa de banhos': {
            'PTPT': 'Numero de Casa de banhos'},
        'e-mail': {
            'PTPT': 'e-mail'},
        'Recolha direta dos Dados': {
            'PTPT': 'Recolha direta dos Dados'},
        'Boolean Prop': {
            'PTPT': 'Boolean Prop'},
        'Timeline Weeks- Armazém': {
            'PTPT': 'Timeline Weeks- Armazém'},
        '   12': {
            'PTPT': 'Empréstimo de 15 dias'},
        'Duração Viagem': {
            'PTPT': 'Duração Viagem'},
        'Initials': {
            'PTPT': 'Initials'},
        'No.': {
            'PTPT': 'No.'},
        'Other Inputs': {
            'PTPT': 'Other Inputs'},
        'Potential buyers': {
            'PTPT': 'Potential buyers'},
        'New Static': {
            'PTPT': 'New Static'},
        'Type 1': {
            'PTPT': 'Type 1'},
        'Responsible for BSC': {
            'PTPT': 'Responsible for BSC'},
        '  226': {
            'PTPT': 'Utilizador responsável pela iniciativa.'},
        'Alert sup.': {
            'PTPT': 'Alert sup.'},
        ' 1123_VERBOSE': {
            'PTPT': '<!DOCTYPE html>
<html>
<head>
</head>
<body>
<p>Help in table list verbose - this help will appear as an info-banner</p>
</body>
</html>'},
        'Descrição da Missão': {
            'PTPT': 'Descrição da Missão'},
        'Flight Scales': {
            'PTPT': 'Flight Scales'},
        'GIAI – Global Individual Asset Identifier': {
            'PTPT': 'GIAI – Global Individual Asset Identifier'},
        'Mechanical': {
            'PTPT': 'Mechanical'},
        'Antecedência': {
            'PTPT': 'Antecedência'},
        'Supplier': {
            'PTPT': 'Supplier'},
        'Projects': {
            'PTPT': 'Projects'},
        'TABLE PRICE': {
            'PTPT': 'TABLE PRICE'},
        '   79': {
            'PTPT': 'Campo preenchido automáticamente pelo somatório dos pontos possíveis atribuídos a cada Actividade da Iniciativa / Projecto.'},
        'Articles in use': {
            'PTPT': 'Articles in use'},
        '  308': {
            'PTPT': 'Soma'},
        'Companies': {
            'PTPT': 'Companies'},
        'Cabin Luggage only': {
            'PTPT': 'Cabin Luggage only'},
        'Sends email?': {
            'PTPT': 'Sends email?'},
        'Card-Img-Top': {
            'PTPT': 'Card-Img-Top'},
        'Type of segment used': {
            'PTPT': 'Type of segment used'},
        'Perspectiva (extenso)': {
            'PTPT': 'Perspectiva (extenso)'},
        'Real %': {
            'PTPT': 'Real %'},
        'Login Name': {
            'PTPT': 'Login Name'},
        'Trimestral': {
            'PTPT': 'Trimestral'},
        'Decimal (11-15) (storage: 9 byte)': {
            'PTPT': 'Decimal (11-15) (storage: 9 byte)'},
        'Changes number': {
            'PTPT': 'Número de alterações'},
        ' 1113': {
            'PTPT': 'Shows the type code of the customer record to indicate whether the address belongs to a customer account or contact.'},
        '  224': {
            'PTPT': 'Utilizador responsável pelo indicador.'},
        'Room': {
            'PTPT': 'Room'},
        'Homepage': {
            'PTPT': 'Homepage'},
        ' 1127': {
            'PTPT': 'Data de referência da Meta deste indicador'},
        'Style': {
            'PTPT': 'Style'},
        'Legacy': {
            'PTPT': 'Legacy'},
        'Training Exercise 17': {
            'PTPT': 'Exercício de formação 17'},
        'Storage': {
            'PTPT': 'Storage'},
        'Tipo de Unidade Org.': {
            'PTPT': 'Tipo de Unidade Org.'},
        'Subtitle in kpi': {
            'PTPT': 'Subtitle in kpi'},
        'Apartment': {
            'PTPT': 'Apartamento'},
        'Local onde executa': {
            'PTPT': 'Local onde executa'},
        'objectTypeCode_display': {
            'PTPT': 'objectTypeCode_display'},
        'In Repair': {
            'PTPT': 'In Repair'},
        'Upper case': {
            'PTPT': 'Upper case'},
        'From record': {
            'PTPT': 'From record'},
        'Cancel': {
            'PTPT': 'Cancel'},
        'Modal': {
            'PTPT': 'Modal'},
        'Limite Superado': {
            'PTPT': 'Limite Superado'},
        '   90': {
            'PTPT': 'Valores por omissão para o limite inferior do intervalo de referência para toda e qualquer meta, em percentagem sobre a própria meta. Pretende-se desta forma desenhar em abstracto o alvo para toda e qualquer meta, de forma a limitar o intervalo de referência para a valoração dos vários níveis de avaliação e da concretização.'},
        'Asset location': {
            'PTPT': 'Asset location'},
        'Marca Água': {
            'PTPT': 'Marca Água'},
        'Menus': {
            'PTPT': 'Menus'},
        'For returning': {
            'PTPT': 'For returning'},
        'Date Prop': {
            'PTPT': 'Date Prop'},
        'User Management -> UM': {
            'PTPT': 'User Management -> UM'},
        'Visits': {
            'PTPT': 'Visits'},
        'Document No.': {
            'PTPT': 'Document No.'},
        'Qualidade': {
            'PTPT': 'Qualidade'},
        'Helps in other controls (List, buttons)': {
            'PTPT': 'Helps in other controls (List, buttons)'},
        'Start:': {
            'PTPT': 'Start:'},
        'Location': {
            'PTPT': 'Location'},
        'Unidade Orgânica': {
            'PTPT': 'Unidade Orgânica'},
        'Numeric Prop': {
            'PTPT': 'Numeric Prop'},
        'Property name': {
            'PTPT': 'Property name'},
        'Feedback': {
            'PTPT': 'Feedback'},
        'Groupbox': {
            'PTPT': 'Groupbox'},
        'Notification Email Signature': {
            'PTPT': 'Notification Email Signature'},
        'Registration No.': {
            'PTPT': 'Registration No.'},
        'Technical category': {
            'PTPT': 'Technical category'},
        'Ano(Numerico)': {
            'PTPT': 'Ano(Numerico)'},
        'Família de equipamentos': {
            'PTPT': 'Família de equipamentos'},
        'Has Checkin?': {
            'PTPT': 'Has Checkin?'},
        'Qtd hours': {
            'PTPT': 'Qtd hours'},
        'Airplanes': {
            'PTPT': 'Airplanes'},
        'Patient': {
            'PTPT': 'Patient'},
        'Timeline - Weeks': {
            'PTPT': 'Timeline - Weeks'},
        'Last incorporated facility': {
            'PTPT': 'Last incorporated facility'},
        'Weight': {
            'PTPT': 'Weight'},
        'Lenders': {
            'PTPT': 'Lenders'},
        'boolean (tinyint) (storage 1 byte)': {
            'PTPT': 'boolean (tinyint) (storage 1 byte)'},
        'Articles': {
            'PTPT': 'Articles'},
        'Articles [WAREH->WAREHDES]': {
            'PTPT': 'Articles [WAREH->WAREHDES]'},
        'Configuração de homepage': {
            'PTPT': 'Configuração de homepage'},
        'Tipo de segmento': {
            'PTPT': 'Tipo de segmento'},
        'This help is for a field of type numeric': {
            'PTPT': 'This help is for a field of type numeric'},
        'Order (Float field)': {
            'PTPT': 'Order (Float field)'},
        'Nif': {
            'PTPT': 'Nif'},
        'Where did the equipment go': {
            'PTPT': 'Where did the equipment go'},
        'Chave Estrangeira': {
            'PTPT': 'Chave Estrangeira'},
        'Regions': {
            'PTPT': 'Regions'},
        'Rate': {
            'PTPT': 'Rate'},
        'Criado por': {
            'PTPT': 'Criado por'},
        'Enumeration (Numeric)': {
            'PTPT': 'Enumeração (Numérico)'},
        'Campo com condição de Preenchimento': {
            'PTPT': 'Campo com condição de Preenchimento'},
        'Type': {
            'PTPT': 'Type'},
        '  287': {
            'PTPT': 'Data da última notificação enviada'},
        'Acronym': {
            'PTPT': 'Acronym'},
        'Approach': {
            'PTPT': 'Approach'},
        'Zoom level': {
            'PTPT': 'Zoom level'},
        'Path': {
            'PTPT': 'Path'},
        'Good Limit Perc.': {
            'PTPT': 'Good Limit Perc.'},
        'Naturalness': {
            'PTPT': 'Naturalness'},
        'Goal type': {
            'PTPT': 'Goal type'},
        'Codigo': {
            'PTPT': 'Codigo'},
        'Project completed': {
            'PTPT': 'Project completed'},
        'Next - Previous =': {
            'PTPT': 'Next - Previous ='},
        'Currency': {
            'PTPT': 'Currency'},
        'Valor objectivo': {
            'PTPT': 'Valor objectivo'},
        '   99': {
            'PTPT': 'Este valor por omissão, representa o ponto \'zero\' a partir do qual se calcula o grau de concretização em termos de percentual sobre a meta. Para o presente caso, destinado a metas de indicadores de polaridade \'menor é melhor\', este valor deve ser pelo menos igual ou superior ao limite máximo do intervalo, uma boa regra é representar 200% do valor da meta.'},
        'Period Start': {
            'PTPT': 'Period Start'},
        'Multiple Select List -> DM': {
            'PTPT': 'Multiple Select List -> DM'},
        'Alerts': {
            'PTPT': 'Alerts'},
        'Non qualified': {
            'PTPT': 'Non qualified'},
        'Phone number': {
            'PTPT': 'Phone number'},
        'Local': {
            'PTPT': 'Local'},
        'Origin point': {
            'PTPT': 'Origin point'},
        'Baggages': {
            'PTPT': 'Baggages'},
        'National Measurement Feasibility': {
            'PTPT': 'National Measurement Feasibility'},
        'End time with inclusive boundary, if not ongoing': {
            'PTPT': 'End time with inclusive boundary, if not ongoing'},
        'GENIO L2': {
            'PTPT': 'GENIO L2'},
        'Phone': {
            'PTPT': 'Phone'},
        'Lists': {
            'PTPT': 'Lists'},
        'Business intelligence': {
            'PTPT': 'Business intelligence'},
        'Y de Destino': {
            'PTPT': 'Y de Destino'},
        'Detailed description': {
            'PTPT': 'Detailed description'},
        'Fecho da venda': {
            'PTPT': 'Fecho da venda'},
        'Airline': {
            'PTPT': 'Companhia aérea'},
        'Automáticas': {
            'PTPT': 'Automáticas'},
        'Percentagem': {
            'PTPT': 'Percentagem'},
        'DateTime (Seconds)': {
            'PTPT': 'DateTime (Seconds)'},
        'Limitações para cumprimento de metas': {
            'PTPT': 'Limitações para cumprimento de metas'},
        'Single Inputs': {
            'PTPT': 'Single Inputs'},
        'Item': {
            'PTPT': 'Item'},
        'Graphix XML': {
            'PTPT': 'Graphix XML'},
        'Result': {
            'PTPT': 'Result'},
        'Valores': {
            'PTPT': 'Valores'},
        'Maio': {
            'PTPT': 'Maio'},
        '  420': {
            'PTPT': 'Data Início'},
        'Input document': {
            'PTPT': 'Input document'},
        'Objetivo Operacional Relevante': {
            'PTPT': 'Objetivo Operacional Relevante'},
        '% Limit Exceeded': {
            'PTPT': '% Limit Exceeded'},
        'Global Items': {
            'PTPT': 'Global Items'},
        'Complete Creation Date': {
            'PTPT': 'Complete Creation Date'},
        'Good Perc.': {
            'PTPT': 'Good Perc.'},
        'Assets': {
            'PTPT': 'Assets'},
        '  334': {
            'PTPT': 'Tolerância'},
        'Help in the Multiline field': {
            'PTPT': 'Help in the Multiline field'},
        'Asset tag': {
            'PTPT': 'Asset tag'},
        'Modules': {
            'PTPT': 'Modules'},
        'Recalendarização': {
            'PTPT': 'Recalendarização'},
        'Equip: Bought': {
            'PTPT': 'Equip: Bought'},
        'Location Extension Component': {
            'PTPT': 'Location Extension Component'},
        'Disaggregation Lines properties': {
            'PTPT': 'Disaggregation Lines properties'},
        'Multiple Values Extended': {
            'PTPT': 'Multiple Values Extended'},
        'Button to trigger': {
            'PTPT': 'Botão para acionar'},
        'Crescimento': {
            'PTPT': 'Crescimento'},
        'Manufacturer': {
            'PTPT': 'Manufacturer'},
        'Specific path with conditions with trigger -> DB + MC + TR': {
            'PTPT': 'Specific path with conditions with trigger -> DB + MC + TR'},
        'Respects time interval?': {
            'PTPT': 'Respects time interval?'},
        'Y de Destino (ME)': {
            'PTPT': 'Y de Destino (ME)'},
        'Document': {
            'PTPT': 'Document'},
        'Objectivo (extenso)': {
            'PTPT': 'Objectivo (extenso)'},
        'Estratégias': {
            'PTPT': 'Estratégias'},
        'Contact genres': {
            'PTPT': 'Contact genres'},
        'Minimum Map Color': {
            'PTPT': 'Minimum Map Color'},
        'Comodantes': {
            'PTPT': 'Comodantes'},
        'Logical': {
            'PTPT': 'Logical'},
        '  276': {
            'PTPT': 'Periodicidade de recolha'},
        'Receipt': {
            'PTPT': 'Receipt'},
        'Tipo de Actividade': {
            'PTPT': 'Tipo de Actividade'},
        'Property Name': {
            'PTPT': 'Property Name'},
        '> PERSON': {
            'PTPT': '> PERSON'},
        'Types  (Text)': {
            'PTPT': 'Types  (Text)'},
        'No objective?': {
            'PTPT': 'No objective?'},
        'Field with Fill when condition': {
            'PTPT': 'Campo com condição de Preenchimento'},
        'Authorizer': {
            'PTPT': 'Authorizer'},
        'Dispatched': {
            'PTPT': 'Dispatched'},
        'N:N List -> DC + DB': {
            'PTPT': 'N:N List -> DC + DB'},
        'REPAIRS': {
            'PTPT': 'REPAIRS'},
        '  306': {
            'PTPT': 'E-mail'},
        'Text': {
            'PTPT': 'Text'},
        'NAME': {
            'PTPT': 'NAME'},
        'Input Groups': {
            'PTPT': 'Input Groups'},
        ' 1143': {
            'PTPT': 'Help in a manual filling field'},
        'Acción': {
            'PTPT': 'Acción'},
        'Max points': {
            'PTPT': 'Max points'},
        'É obrigatório preencher a descrição: Regra do form com apply': {
            'PTPT': 'É obrigatório preencher a descrição: Regra do form com apply'},
        'Foreign Key 2': {
            'PTPT': 'Foreign Key 2'},
        'Visit': {
            'PTPT': 'Visit'},
        'Lendings of [EQUIP->REGISTNR] - [TPEQU->TIPOEQUI]': {
            'PTPT': 'Lendings of [EQUIP->REGISTNR] - [TPEQU->TIPOEQUI]'},
        'Legal registration': {
            'PTPT': 'Legal registration'},
        'Expenses': {
            'PTPT': 'Expenses'},
        'Yes / No': {
            'PTPT': 'Yes / No'},
        'Main Photo': {
            'PTPT': 'Foto principal'},
        '    3': {
            'PTPT': 'Empréstimo de coisa não fungível, que se há-de restituir findo o prazo estipulado.\n\nhttps://dicionario.priberam.org/comodato [consultado em 17-12-2018].'},
        'Async process arguments': {
            'PTPT': 'Async process arguments'},
        'Previous Year': {
            'PTPT': 'Previous Year'},
        'Manual routine -> DM + MB + R': {
            'PTPT': 'Manual routine -> DM + MB + R'},
        'Estado do processo': {
            'PTPT': 'Estado do processo'},
        'Ground Size': {
            'PTPT': 'Tamanho do terreno'},
        'Maximum Perc.': {
            'PTPT': 'Maximum Perc.'},
        'Last Name': {
            'PTPT': 'Last Name'},
        'Departure Time': {
            'PTPT': 'Departure Time'},
        '  111': {
            'PTPT': 'Denominação breve do Indicador para que o mesmo seja fácilmente identificado em todos os quadros e relatórios. O indicador é o elemento operacional do Mapa Estratégico, é ao nível do indicador que se vão definir as várias metas e associar Iniciativas Projectos e Actividades.'},
        'Patterns': {
            'PTPT': 'Patterns'},
        'Hourly price': {
            'PTPT': 'Hourly price'},
        'Agent Information': {
            'PTPT': 'Informação do agente'},
        'Lista de campos de Aeroporto': {
            'PTPT': 'Lista de campos de Aeroporto'},
        'Prospecting carried out': {
            'PTPT': 'Prospecting carried out'},
        'Text inputs': {
            'PTPT': 'Text inputs'},
        'September': {
            'PTPT': 'September'},
        'Enumeration Prop': {
            'PTPT': 'Enumeration Prop'},
        'Field with client-side conditions': {
            'PTPT': 'Campo com condições client-side'},
        'Identificação da oportunidade comercial': {
            'PTPT': 'Identificação da oportunidade comercial'},
        'Help field in the calculation of Chains': {
            'PTPT': 'Help field in the calculation of Chains'},
        'Web': {
            'PTPT': 'Web'},
        'Following': {
            'PTPT': 'Following'},
        'Traduzido': {
            'PTPT': 'Traduzido'},
        'This routine will open the form in query mode. Do you wish to continue?': {
            'PTPT': 'Esta rotina vai abrir o formulário em modo de consulta. Deseja continuar?'},
        'Output No': {
            'PTPT': 'Output No'},
        'Wizard with Progress': {
            'PTPT': 'Wizard with Progress'},
        'leader no.': {
            'PTPT': 'leader no.'},
        'Alert 3': {
            'PTPT': 'Alert 3'},
        'Urgent': {
            'PTPT': 'Urgent'},
        'c-groupbox--title-background': {
            'PTPT': 'c-groupbox--title-background'},
        'Headquarter location': {
            'PTPT': 'Headquarter location'},
        'Identification': {
            'PTPT': 'Identification'},
        'Technician': {
            'PTPT': 'Technician'},
        'Bad Perc.': {
            'PTPT': 'Bad Perc.'},
        'Justification/Report': {
            'PTPT': 'Justification/Report'},
        'Vehicle': {
            'PTPT': 'Vehicle'},
        'Notification Message': {
            'PTPT': 'Notification Message'},
        'Terminado': {
            'PTPT': 'Terminado'},
        'Internal Activities Days': {
            'PTPT': 'Internal Activities Days'},
        'Created on': {
            'PTPT': 'Created on'},
        '{GQT_DEVOL_Count} to be returned': {
            'PTPT': '{GQT_DEVOL_Count} to be returned'},
        'third level group': {
            'PTPT': 'third level group'},
        'T2': {
            'PTPT': 'T2'},
        'Important': {
            'PTPT': 'Important'},
        'Date of Birth': {
            'PTPT': 'Date of Birth'},
        '  181': {
            'PTPT': 'Data de referência dos dados. Data a que os dados devem respeitar.'},
        ' 1112': {
            'PTPT': 'Shows the number of the address, to indicate whether the address is the primary, secondary, or other address for the customer.'},
        'More -> c-groupbox--minor-border-top': {
            'PTPT': 'More -> c-groupbox--minor-border-top'},
        'Catalog': {
            'PTPT': 'Catalog'},
        'Trigger -> DB + MB + T': {
            'PTPT': 'Trigger -> DB + MB + T'},
        'Goal value': {
            'PTPT': 'Goal value'},
        'Qualificação efectuada': {
            'PTPT': 'Qualificação efectuada'},
        'Creation: Operator': {
            'PTPT': 'Creation: Operator'},
        'Price': {
            'PTPT': 'Price'},
        'Alert 4': {
            'PTPT': 'Alert 4'},
        'Side to which the connecting line arrives in the destination objective': {
            'PTPT': 'Side to which the connecting line arrives in the destination objective'},
        'Preço do Bilhete arredondado': {
            'PTPT': 'Preço do Bilhete arredondado'},
        'History table': {
            'PTPT': 'History table'},
        'Main table': {
            'PTPT': 'Main table'},
        'Valor (Ano N-2)': {
            'PTPT': 'Valor (Ano N-2)'},
        '  196': {
            'PTPT': 'Escolher o mês em que se inicia o ano.'},
        'House': {
            'PTPT': 'Casa'},
        'Perspectives (Model)': {
            'PTPT': 'Perspectives (Model)'},
        'Falhou a validação do form sem apply': {
            'PTPT': 'Falhou a validação do form sem apply'},
        'Obs': {
            'PTPT': 'Obs'},
        'Vision (Instances)': {
            'PTPT': 'Vision (Instances)'},
        'Airport To': {
            'PTPT': 'Airport To'},
        'Conditions': {
            'PTPT': 'Conditions'},
        'Numeric ISO-3166': {
            'PTPT': 'Numeric ISO-3166'},
        'Numeric Enumeration': {
            'PTPT': 'Numeric Enumeration'},
        'Facilities:': {
            'PTPT': 'Facilities:'},
        'Alert': {
            'PTPT': 'Alert'},
        'Aggregate indicator': {
            'PTPT': 'Aggregate indicator'},
        'Relevant Operating Purpose': {
            'PTPT': 'Relevant Operating Purpose'},
        'Tamanho do terreno': {
            'PTPT': 'Tamanho do terreno'},
        'Kit': {
            'PTPT': 'Kit'},
        '  106': {
            'PTPT': 'Descrição sumária da Perspectiva.'},
        'Grid Foto': {
            'PTPT': 'Grid Foto'},
        'Explore lendings': {
            'PTPT': 'Explore lendings'},
        'Informações principais': {
            'PTPT': 'Informações principais'},
        'Tickets': {
            'PTPT': 'Tickets'},
        'Perpectives': {
            'PTPT': 'Perpectives'},
        'Abordagem': {
            'PTPT': 'Abordagem'},
        'Número do andar': {
            'PTPT': 'Número do andar'},
        'MAIN CONTACT': {
            'PTPT': 'MAIN CONTACT'},
        '  203': {
            'PTPT': 'Colocação do número de fax.'},
        'Technical': {
            'PTPT': 'Technical'},
        'Menu 5': {
            'PTPT': 'Menu 5'},
        'Externo': {
            'PTPT': 'Externo'},
        'Low': {
            'PTPT': 'Low'},
        'Is prepared': {
            'PTPT': 'Is prepared'},
        'Report -> DB + L': {
            'PTPT': 'Report -> DB + L'},
        'group1': {
            'PTPT': 'group1'},
        '   67': {
            'PTPT': 'Data prevista para inicio da Iniciativa / Projecto.'},
        'Agent': {
            'PTPT': 'Agente'},
        'Global Location Number': {
            'PTPT': 'Global Location Number'},
        'Creation date': {
            'PTPT': 'Creation date'},
        'Menu 4': {
            'PTPT': 'Menu 4'},
        '>> Country': {
            'PTPT': '>> Country'},
        'Help in the date field': {
            'PTPT': 'Help in the date field'},
        'Teste': {
            'PTPT': 'Teste'},
        'WCF': {
            'PTPT': 'WCF'},
        'Passenger': {
            'PTPT': 'Passenger'},
        'a:': {
            'PTPT': 'a:'},
        'Aceitar': {
            'PTPT': 'Aceitar'},
        'Alta': {
            'PTPT': 'Alta'},
        'Alteração': {
            'PTPT': 'Alteração'},
        'Alterar': {
            'PTPT': 'Alterar'},
        'Amarelo': {
            'PTPT': 'Amarelo'},
        'Azul': {
            'PTPT': 'Azul'},
        'Baixa': {
            'PTPT': 'Baixa'},
        'Campo Vazio/Alterado': {
            'PTPT': 'Campo Vazio/Alterado'},
        'Consulta': {
            'PTPT': 'Consulta'},
        'consulta': {
            'PTPT': 'consulta'},
        'Data': {
            'PTPT': 'Data'},
        'De:': {
            'PTPT': 'De:'},
        'Desautorizado': {
            'PTPT': 'Desautorizado'},
        'Autorizado': {
            'PTPT': 'Autorizado'},
        'Invalid': {
            'PTPT': 'Inválido'},
        'Desmarcar': {
            'PTPT': 'Desmarcar'},
        'Dirigida a': {
            'PTPT': 'Dirigida a'},
        'Duplicar': {
            'PTPT': 'Duplicar'},
        'Eliminar': {
            'PTPT': 'Eliminar'},
        'Em:': {
            'PTPT': 'Em:'},
        'Empresa': {
            'PTPT': 'Empresa'},
        'Este registo não pode ser eliminado': {
            'PTPT': 'Este registo não pode ser eliminado'},
        'Este registo só pode ser consultado': {
            'PTPT': 'Este registo só pode ser consultado'},
        'Grupo': {
            'PTPT': 'Grupo'},
        'Imprimir': {
            'PTPT': 'Imprimir'},
        'Laranja': {
            'PTPT': 'Laranja'},
        'Menus Preferidos': {
            'PTPT': 'Menus Preferidos'},
        'Muito Alta': {
            'PTPT': 'Muito Alta'},
        'Muito Baixa': {
            'PTPT': 'Muito Baixa'},
        'Normal': {
            'PTPT': 'Normal'},
        'Número': {
            'PTPT': 'Número'},
        'P/ pessoas c/ perfil': {
            'PTPT': 'P/ pessoas c/ perfil'},
        'Palavra passe': {
            'PTPT': 'Palavra passe'},
        'Para Todos': {
            'PTPT': 'Para Todos'},
        'Pessoal': {
            'PTPT': 'Pessoal'},
        'Preto': {
            'PTPT': 'Preto'},
        'Procurar': {
            'PTPT': 'Procurar'},
        'Sair': {
            'PTPT': 'Sair'},
        'Entrar': {
            'PTPT': 'Entrar'},
        'Registe-se': {
            'PTPT': 'Registe-se'},
        'se ainda não tiver uma conta.': {
            'PTPT': 'se ainda não tiver uma conta.'},
        'Selecionar': {
            'PTPT': 'Selecionar'},
        'Tabela Abaixo': {
            'PTPT': 'Tabela Abaixo'},
        'Utilizador': {
            'PTPT': 'Utilizador'},
        'Verde': {
            'PTPT': 'Verde'},
        'Vermelho': {
            'PTPT': 'Vermelho'},
        'Rotinas de Apoio': {
            'PTPT': 'Rotinas de Apoio'},
        'Ajuda ao Utilizador...': {
            'PTPT': 'Ajuda ao Utilizador...'},
        'Sobre o Programa...': {
            'PTPT': 'Sobre o Programa...'},
        'Palavra-chave...': {
            'PTPT': 'Palavra-chave...'},
        'Regista SmartCard...': {
            'PTPT': 'Regista SmartCard...'},
        'Delegações': {
            'PTPT': 'Delegações'},
        'Propriedades...': {
            'PTPT': 'Propriedades...'},
        'Configurar a Impressora...': {
            'PTPT': 'Configurar a Impressora...'},
        'Notificações do utilizador...': {
            'PTPT': 'Notificações do utilizador...'},
        'Notificações do grupo...': {
            'PTPT': 'Notificações do grupo...'},
        'Administração': {
            'PTPT': 'Administração'},
        'Utilizadores...': {
            'PTPT': 'Utilizadores...'},
        'Shutdown...': {
            'PTPT': 'Shutdown...'},
        'Reindexar a BD': {
            'PTPT': 'Reindexar a BD'},
        'Exportação de MQ': {
            'PTPT': 'Exportação de MQ'},
        'Importação de MQ': {
            'PTPT': 'Importação de MQ'},
        'Lista de Queues': {
            'PTPT': 'Lista de Queues'},
        'Backup da BD...': {
            'PTPT': 'Backup da BD...'},
        'Manutenção da BD...': {
            'PTPT': 'Manutenção da BD...'},
        'MSMQ...': {
            'PTPT': 'MSMQ...'},
        'Workflow...': {
            'PTPT': 'Workflow...'},
        'Tipo de Alerta (Grupo)...': {
            'PTPT': 'Tipo de Alerta (Grupo)...'},
        'Tipo de Alerta (Util)...': {
            'PTPT': 'Tipo de Alerta (Util)...'},
        'Substituir': {
            'PTPT': 'Substituir'},
        'Outra vez': {
            'PTPT': 'Outra vez'},
        'Exportar': {
            'PTPT': 'Exportar'},
        'Exportar doc': {
            'PTPT': 'Exportar doc'},
        'Apagar': {
            'PTPT': 'Apagar'},
        'Copiar': {
            'PTPT': 'Copiar'},
        'Colar': {
            'PTPT': 'Colar'},
        'Zoom in': {
            'PTPT': 'Zoom in'},
        'Zoom out': {
            'PTPT': 'Zoom out'},
        'Ajustar': {
            'PTPT': 'Ajustar'},
        'Ajustar c/ratio': {
            'PTPT': 'Ajustar c/ratio'},
        'Original': {
            'PTPT': 'Original'},
        'Rodar (+90 graus)': {
            'PTPT': 'Rodar (+90 graus)'},
        'Rodar (-90 graus)': {
            'PTPT': 'Rodar (-90 graus)'},
        'Reflexo': {
            'PTPT': 'Reflexo'},
        'Digitalizar': {
            'PTPT': 'Digitalizar'},
        'Importar': {
            'PTPT': 'Importar'},
        '&Importar': {
            'PTPT': '&Importar'},
        'Cortar': {
            'PTPT': 'Cortar'},
        'Fonte': {
            'PTPT': 'Fonte'},
        'Negrito': {
            'PTPT': 'Negrito'},
        'Itálico': {
            'PTPT': 'Itálico'},
        'Sublinhado': {
            'PTPT': 'Sublinhado'},
        'Outros...': {
            'PTPT': 'Outros...'},
        'Parágrafo': {
            'PTPT': 'Parágrafo'},
        'Esquerda': {
            'PTPT': 'Esquerda'},
        'Centrado': {
            'PTPT': 'Centrado'},
        'Direita': {
            'PTPT': 'Direita'},
        'Documentos': {
            'PTPT': 'Documentos'},
        'Abrir': {
            'PTPT': 'Abrir'},
        'Anexar': {
            'PTPT': 'Anexar'},
        'Selecionar scanner': {
            'PTPT': 'Selecionar scanner'},
        'Criar documento': {
            'PTPT': 'Criar documento'},
        'Este documento encontra-se em edição.': {
            'PTPT': 'Este documento encontra-se em edição.'},
        'Esta versão do documento não foi ainda gravada.': {
            'PTPT': 'Esta versão do documento não foi ainda gravada.'},
        'Submeter': {
            'PTPT': 'Submeter'},
        'Versões': {
            'PTPT': 'Versões'},
        'Apagar última': {
            'PTPT': 'Apagar última'},
        'Apagar histórico': {
            'PTPT': 'Apagar histórico'},
        'Propriedades': {
            'PTPT': 'Propriedades'},
        'Tópicos de Ajuda': {
            'PTPT': 'Tópicos de Ajuda'},
        'Acerca de...': {
            'PTPT': 'Acerca de...'},
        'Office 2007 (Blue Style)': {
            'PTPT': 'Office 2007 (Blue Style)'},
        'Office 2007 (Black Style)': {
            'PTPT': 'Office 2007 (Black Style)'},
        'Office 2007 (Silver Style)': {
            'PTPT': 'Office 2007 (Silver Style)'},
        'Office 2007 (Aqua Style)': {
            'PTPT': 'Office 2007 (Aqua Style)'},
        'Projeto': {
            'PTPT': 'Projeto'},
        'Central Telefónica': {
            'PTPT': 'Central Telefónica'},
        'Euros': {
            'PTPT': 'Euros'},
        'Escudos': {
            'PTPT': 'Escudos'},
        'aaaa/mm/dd': {
            'PTPT': 'aaaa/mm/dd'},
        'dd/mm/aaaa': {
            'PTPT': 'dd/mm/aaaa'},
        'SMTP:': {
            'PTPT': 'SMTP:'},
        'Port:': {
            'PTPT': 'Port:'},
        'Entrar automaticamente nesta máquina e com este utilizador': {
            'PTPT': 'Entrar automaticamente nesta máquina e com este utilizador'},
        'Aplicar': {
            'PTPT': 'Aplicar'},
        'Unidade monetária': {
            'PTPT': 'Unidade monetária'},
        'Formato das datas': {
            'PTPT': 'Formato das datas'},
        'Formato de Número': {
            'PTPT': 'Formato de Número'},
        'Contraste dos campos bloqueados': {
            'PTPT': 'Contraste dos campos bloqueados'},
        'E-mail propriedades': {
            'PTPT': 'E-mail propriedades'},
        'Mostrar riscas coloridas nas listagens': {
            'PTPT': 'Mostrar riscas coloridas nas listagens'},
        'Mostrar icon de ordenamento nas listagens': {
            'PTPT': 'Mostrar icon de ordenamento nas listagens'},
        'Login:': {
            'PTPT': 'Login:'},
        'Logout': {
            'PTPT': 'Logout'},
        'Opções do utilizador': {
            'PTPT': 'Opções do utilizador'},
        'Delegar acesso': {
            'PTPT': 'Delegar acesso'},
        'Associar cartão': {
            'PTPT': 'Associar cartão'},
        'Contraste dos campos obrigatórios': {
            'PTPT': 'Contraste dos campos obrigatórios'},
        'E-Mail:': {
            'PTPT': 'E-Mail:'},
        'E-mail:': {
            'PTPT': 'E-mail:'},
        'Autenticação': {
            'PTPT': 'Autenticação'},
        'Utilizador:': {
            'PTPT': 'Utilizador:'},
        'Palavra-chave:': {
            'PTPT': 'Palavra-chave:'},
        'SmartCard': {
            'PTPT': 'SmartCard'},
        'Cartões': {
            'PTPT': 'Cartões'},
        'Imagem do cartão': {
            'PTPT': 'Imagem do cartão'},
        'Carrossel': {
            'PTPT': 'Carrossel'},
        'Mapas': {
            'PTPT': 'Mapas'},
        'Mapa': {
            'PTPT': 'Mapa'},
        'Foram-lhe delegados os acessos abaixo listados. Pressione \'Próprio\' para usar o seu login normal, ou selecione a delegação pretendida e pressione \'Outro\'.': {
            'PTPT': 'Foram-lhe delegados os acessos abaixo listados. Pressione \'Próprio\' para usar o seu login normal, ou selecione a delegação pretendida e pressione \'Outro\'.'},
        'Delegações:': {
            'PTPT': 'Delegações:'},
        'Mensagem:': {
            'PTPT': 'Mensagem:'},
        'Próprio': {
            'PTPT': 'Próprio'},
        'Outro': {
            'PTPT': 'Outro'},
        'Escolher': {
            'PTPT': 'Escolher'},
        'minuto(s) e': {
            'PTPT': 'minuto(s) e'},
        'Por favor, interrompa o que está a fazer e saia do programa normalmente. Não é necessário desligar o computador.': {
            'PTPT': 'Por favor, interrompa o que está a fazer e saia do programa normalmente. Não é necessário desligar o computador.'},
        'Voltar ao programa': {
            'PTPT': 'Voltar ao programa'},
        'segundo(s).': {
            'PTPT': 'segundo(s).'},
        'Shutdown': {
            'PTPT': 'Shutdown'},
        'Todos!': {
            'PTPT': 'Todos!'},
        'Apenas os selecionados': {
            'PTPT': 'Apenas os selecionados'},
        'Terminar': {
            'PTPT': 'Terminar'},
        'Forçar a saída dos utilizadores daqui a': {
            'PTPT': 'Forçar a saída dos utilizadores daqui a'},
        'segundo(s)': {
            'PTPT': 'segundo(s)'},
        'Utilize as teclas CTRL e SHIFT e o botão esquerdo do rato para efetuar múltiplas seleções': {
            'PTPT': 'Utilize as teclas CTRL e SHIFT e o botão esquerdo do rato para efetuar múltiplas seleções'},
        'Enviar a seguinte mensagem adicional:': {
            'PTPT': 'Enviar a seguinte mensagem adicional:'},
        'OK': {
            'PTPT': 'OK'},
        'Primeiro': {
            'PTPT': 'Primeiro'},
        'Próximo': {
            'PTPT': 'Próximo'},
        'Dom': {
            'PTPT': 'Dom'},
        'Seg': {
            'PTPT': 'Seg'},
        'Ter': {
            'PTPT': 'Ter'},
        'Qua': {
            'PTPT': 'Qua'},
        'Qui': {
            'PTPT': 'Qui'},
        'Sab': {
            'PTPT': 'Sab'},
        'Debugging': {
            'PTPT': 'Debugging'},
        'Ocultar tabelas compostas por chaves estrangeiras': {
            'PTPT': 'Ocultar tabelas compostas por chaves estrangeiras'},
        'Fit to area': {
            'PTPT': 'Fit to area'},
        'Não incluir': {
            'PTPT': 'Não incluir'},
        'Incluir': {
            'PTPT': 'Incluir'},
        'Última query executada sobre a tabela': {
            'PTPT': 'Última query executada sobre a tabela'},
        'Dependências entre controlos': {
            'PTPT': 'Dependências entre controlos'},
        'Entradas de Historial': {
            'PTPT': 'Entradas de Historial'},
        'Parar no primeiro caminho incoerente (para cada relação)': {
            'PTPT': 'Parar no primeiro caminho incoerente (para cada relação)'},
        'Parar ao quinto erro (para cada caminho)': {
            'PTPT': 'Parar ao quinto erro (para cada caminho)'},
        'Guardar queries em ficheiro': {
            'PTPT': 'Guardar queries em ficheiro'},
        'Atualização': {
            'PTPT': 'Atualização'},
        'Atualizações': {
            'PTPT': 'Atualizações'},
        'Disponíveis': {
            'PTPT': 'Disponíveis'},
        'Atualizar às': {
            'PTPT': 'Atualizar às'},
        'of': {
            'PTPT': 'de'},
        'Atualizar': {
            'PTPT': 'Atualizar'},
        'Backup': {
            'PTPT': 'Backup'},
        'Destino': {
            'PTPT': 'Destino'},
        'Tree1': {
            'PTPT': 'Tree1'},
        'Progresso': {
            'PTPT': 'Progresso'},
        'Escolha de diretoria': {
            'PTPT': 'Escolha de diretoria'},
        '1. Consulta Avançada': {
            'PTPT': '1. Consulta Avançada'},
        'Escolha a tabela que deseja consultar.': {
            'PTPT': 'Escolha a tabela que deseja consultar.'},
        '2. Colunas': {
            'PTPT': '2. Colunas'},
        'Escolha as colunas a incluir na consulta. Pode mudar a sua ordem ou descrição.': {
            'PTPT': 'Escolha as colunas a incluir na consulta. Pode mudar a sua ordem ou descrição.'},
        'Colunas da Tabela:': {
            'PTPT': 'Colunas da Tabela:'},
        'Colunas da Consulta:': {
            'PTPT': 'Colunas da Consulta:'},
        'Descrição:': {
            'PTPT': 'Descrição:'},
        'Formula...': {
            'PTPT': 'Formula...'},
        '3. Ordem': {
            'PTPT': '3. Ordem'},
        'Colunas de Grupo:': {
            'PTPT': 'Colunas de Grupo:'},
        'Escolha as colunas pelas quais quer agrupar e ordenar a consulta.': {
            'PTPT': 'Escolha as colunas pelas quais quer agrupar e ordenar a consulta.'},
        'Ordem:': {
            'PTPT': 'Ordem:'},
        '4. Condições': {
            'PTPT': '4. Condições'},
        'ou igual a': {
            'PTPT': 'ou igual a'},
        'Colunas de Seleção:': {
            'PTPT': 'Colunas de Seleção:'},
        'Escolha as colunas pelas quais quer selecionar as linhas a consultar.': {
            'PTPT': 'Escolha as colunas pelas quais quer selecionar as linhas a consultar.'},
        'e': {
            'PTPT': 'e'},
        'Consulta Avançada': {
            'PTPT': 'Consulta Avançada'},
        'List1': {
            'PTPT': 'List1'},
        'Guardar Consulta': {
            'PTPT': 'Guardar Consulta'},
        'Guardar como:': {
            'PTPT': 'Guardar como:'},
        'Mensagem de Correio Eletrónico': {
            'PTPT': 'Mensagem de Correio Eletrónico'},
        'Para:': {
            'PTPT': 'Para:'},
        'Assunto:': {
            'PTPT': 'Assunto:'},
        'Mensagem': {
            'PTPT': 'Mensagem'},
        'Mensagens': {
            'PTPT': 'Mensagens'},
        'Enviar por Programa de E-Mail': {
            'PTPT': 'Enviar por Programa de E-Mail'},
        'Adiciona': {
            'PTPT': 'Adiciona'},
        'A enviar mensagem...': {
            'PTPT': 'A enviar mensagem...'},
        'Estabelecer ligação...': {
            'PTPT': 'Estabelecer ligação...'},
        'Progressão': {
            'PTPT': 'Progressão'},
        'Fechar': {
            'PTPT': 'Fechar'},
        'Image print setup': {
            'PTPT': 'Image print setup'},
        'Horizontal': {
            'PTPT': 'Horizontal'},
        'Vertical': {
            'PTPT': 'Vertical'},
        'À página': {
            'PTPT': 'À página'},
        'Alinhar imagem': {
            'PTPT': 'Alinhar imagem'},
        'Conf Impressora': {
            'PTPT': 'Conf Impressora'},
        'Página atual': {
            'PTPT': 'Página atual'},
        '(1/n)': {
            'PTPT': '(1/n)'},
        'Paginação': {
            'PTPT': 'Paginação'},
        'Ajustar imagem': {
            'PTPT': 'Ajustar imagem'},
        'Por favor, aguarde...': {
            'PTPT': 'Por favor, aguarde...'},
        'Aguarde...': {
            'PTPT': 'Aguarde...'},
        'MSMQ Admin': {
            'PTPT': 'MSMQ Admin'},
        'List2': {
            'PTPT': 'List2'},
        'Queues de mensagens definidas:': {
            'PTPT': 'Queues de mensagens definidas:'},
        'Mostre mensagens na queue': {
            'PTPT': 'Mostre mensagens na queue'},
        'Parar a importação de MSMQ': {
            'PTPT': 'Parar a importação de MSMQ'},
        'Mensagens totais processadas: 0': {
            'PTPT': 'Mensagens totais processadas: 0'},
        'Refresque a lista': {
            'PTPT': 'Refresque a lista'},
        'MQ status da importação: permitido': {
            'PTPT': 'MQ status da importação: permitido'},
        'Refresque a info da queue': {
            'PTPT': 'Refresque a info da queue'},
        'Registo de erros': {
            'PTPT': 'Registo de erros'},
        'Registo de Eventos': {
            'PTPT': 'Registo de Eventos'},
        'Lista da mensagem MSMQ': {
            'PTPT': 'Lista da mensagem MSMQ'},
        'Tab1': {
            'PTPT': 'Tab1'},
        'Mensagens:': {
            'PTPT': 'Mensagens:'},
        'Tree2': {
            'PTPT': 'Tree2'},
        'Registo de erros MSMQ': {
            'PTPT': 'Registo de erros MSMQ'},
        'DateTimePicker1': {
            'PTPT': 'DateTimePicker1'},
        'Data e hora': {
            'PTPT': 'Data e hora'},
        'Data:': {
            'PTPT': 'Data:'},
        'Período:': {
            'PTPT': 'Período:'},
        'DateTimePicker2': {
            'PTPT': 'DateTimePicker2'},
        'DateTimePicker3': {
            'PTPT': 'DateTimePicker3'},
        'até': {
            'PTPT': 'até'},
        'Computador:': {
            'PTPT': 'Computador:'},
        'Aplicação:': {
            'PTPT': 'Aplicação:'},
        'Tipo:': {
            'PTPT': 'Tipo:'},
        'Queues': {
            'PTPT': 'Queues'},
        'Selecione Tudo': {
            'PTPT': 'Selecione Tudo'},
        'Ação:': {
            'PTPT': 'Ação:'},
        'Ações': {
            'PTPT': 'Ações'},
        'Código:': {
            'PTPT': 'Código:'},
        'Relatório': {
            'PTPT': 'Relatório'},
        'MSMQ Relatório do Registo': {
            'PTPT': 'MSMQ Relatório do Registo'},
        'Escolha o relatório para mostrar': {
            'PTPT': 'Escolha o relatório para mostrar'},
        'Mostrar': {
            'PTPT': 'Mostrar'},
        'Modificar': {
            'PTPT': 'Modificar'},
        'Código Queue': {
            'PTPT': 'Código Queue'},
        'Operação': {
            'PTPT': 'Operação'},
        'Código Interno': {
            'PTPT': 'Código Interno'},
        'Conteudo': {
            'PTPT': 'Conteudo'},
        'Última Alteração': {
            'PTPT': 'Última Alteração'},
        'Resposta': {
            'PTPT': 'Resposta'},
        'Estado': {
            'PTPT': 'Estado'},
        'Página': {
            'PTPT': 'Página'},
        'Páginas': {
            'PTPT': 'Páginas'},
        'Mover página': {
            'PTPT': 'Mover página'},
        'Navegar entre páginas': {
            'PTPT': 'Navegar entre páginas'},
        'Ir para página': {
            'PTPT': 'Ir para página'},
        'Linhas por página': {
            'PTPT': 'Linhas por página'},
        '/ 999': {
            'PTPT': '/ 999'},
        'Criar Nova': {
            'PTPT': 'Criar Nova'},
        'Baixo': {
            'PTPT': 'Baixo'},
        'Cima': {
            'PTPT': 'Cima'},
        'Tamanho Original': {
            'PTPT': 'Tamanho Original'},
        'Tudo': {
            'PTPT': 'Tudo'},
        'Nada': {
            'PTPT': 'Nada'},
        'InfoPath': {
            'PTPT': 'InfoPath'},
        'Database login': {
            'PTPT': 'Database login'},
        'global ini file': {
            'PTPT': 'global ini file'},
        'username': {
            'PTPT': 'username'},
        'password': {
            'PTPT': 'password'},
        'Utilizador Geral': {
            'PTPT': 'Utilizador Geral'},
        'Workgroup': {
            'PTPT': 'Workgroup'},
        'Palavra-chave': {
            'PTPT': 'Palavra-chave'},
        'Confirmar': {
            'PTPT': 'Confirmar'},
        'Domínio /': {
            'PTPT': 'Domínio /'},
        'Introduzir palavra chave': {
            'PTPT': 'Introduzir palavra chave'},
        'Tipos de Alerta p/ GRUPO': {
            'PTPT': 'Tipos de Alerta p/ GRUPO'},
        'Grupos de Alertas': {
            'PTPT': 'Grupos de Alertas'},
        'Alertas': {
            'PTPT': 'Alertas'},
        'Tipos de Alerta p/ Utilizador': {
            'PTPT': 'Tipos de Alerta p/ Utilizador'},
        'Alertas do Utilizador': {
            'PTPT': 'Alertas do Utilizador'},
        'Alertas do Grupo': {
            'PTPT': 'Alertas do Grupo'},
        'Alerta (Grupo)': {
            'PTPT': 'Alerta (Grupo)'},
        'Nome do Grupo de utilizadores': {
            'PTPT': 'Nome do Grupo de utilizadores'},
        'Data de Criação': {
            'PTPT': 'Data de Criação'},
        'Data de Resolução': {
            'PTPT': 'Data de Resolução'},
        'Tratado?': {
            'PTPT': 'Tratado?'},
        'Ativo?': {
            'PTPT': 'Ativo?'},
        'Menu': {
            'PTPT': 'Menu'},
        'Resolver': {
            'PTPT': 'Resolver'},
        'Background?': {
            'PTPT': 'Background?'},
        'SMS?': {
            'PTPT': 'SMS?'},
        'SMS Enviado?': {
            'PTPT': 'SMS Enviado?'},
        'Email?': {
            'PTPT': 'Email?'},
        'Email Enviado?': {
            'PTPT': 'Email Enviado?'},
        'Formas de Alertar': {
            'PTPT': 'Formas de Alertar'},
        'Alerta (user)': {
            'PTPT': 'Alerta (user)'},
        'Entidade do Alerta': {
            'PTPT': 'Entidade do Alerta'},
        'Tipo de Alerta': {
            'PTPT': 'Tipo de Alerta'},
        'Contador': {
            'PTPT': 'Contador'},
        'Modificado': {
            'PTPT': 'Modificado'},
        'Nome dos Utilizadores': {
            'PTPT': 'Nome dos Utilizadores'},
        'Indiv?': {
            'PTPT': 'Indiv?'},
        'E-mail?': {
            'PTPT': 'E-mail?'},
        'Área': {
            'PTPT': 'Área'},
        'Funcionário': {
            'PTPT': 'Funcionário'},
        'Data Inicial': {
            'PTPT': 'Data Inicial'},
        'Dias de Antecedência': {
            'PTPT': 'Dias de Antecedência'},
        'Todos?': {
            'PTPT': 'Todos?'},
        'Informação': {
            'PTPT': 'Informação'},
        'Quem alertar': {
            'PTPT': 'Quem alertar'},
        'Alerta de Datas': {
            'PTPT': 'Alerta de Datas'},
        'Nome do Tipo de Alerta': {
            'PTPT': 'Nome do Tipo de Alerta'},
        'Método do Tipo de Alerta': {
            'PTPT': 'Método do Tipo de Alerta'},
        'Texto das Mensagens': {
            'PTPT': 'Texto das Mensagens'},
        'Iniciar configuração': {
            'PTPT': 'Iniciar configuração'},
        'Campo da BD com o Nome': {
            'PTPT': 'Campo da BD com o Nome'},
        'Data de Alerta Inicial': {
            'PTPT': 'Data de Alerta Inicial'},
        'Data Alerta Final': {
            'PTPT': 'Data Alerta Final'},
        'Inclui ano?': {
            'PTPT': 'Inclui ano?'},
        'Diferença entre datas?': {
            'PTPT': 'Diferença entre datas?'},
        'Anos de Diferença': {
            'PTPT': 'Anos de Diferença'},
        'Nome do sistema': {
            'PTPT': 'Nome do sistema'},
        'Meses de Diferença': {
            'PTPT': 'Meses de Diferença'},
        'Dias de Diferença': {
            'PTPT': 'Dias de Diferença'},
        'Nome da Tabela Mãe': {
            'PTPT': 'Nome da Tabela Mãe'},
        'Nome da Tabela Filha': {
            'PTPT': 'Nome da Tabela Filha'},
        'Form Por Preencher': {
            'PTPT': 'Form Por Preencher'},
        'Tabela a Ver': {
            'PTPT': 'Tabela a Ver'},
        'Campo da Tabela': {
            'PTPT': 'Campo da Tabela'},
        'Condição Where': {
            'PTPT': 'Condição Where'},
        'Datas': {
            'PTPT': 'Datas'},
        'Delegações de acesso': {
            'PTPT': 'Delegações de acesso'},
        'Delegar': {
            'PTPT': 'Delegar'},
        'Revogar': {
            'PTPT': 'Revogar'},
        'Delegação de acesso': {
            'PTPT': 'Delegação de acesso'},
        'Delegador': {
            'PTPT': 'Delegador'},
        'Data de início': {
            'PTPT': 'Data de início'},
        'Data limite': {
            'PTPT': 'Data limite'},
        'Id para auditoria': {
            'PTPT': 'Id para auditoria'},
        'Auditoria': {
            'PTPT': 'Auditoria'},
        'Revogada?': {
            'PTPT': 'Revogada?'},
        'Criado em:': {
            'PTPT': 'Criado em:'},
        'Mudado em:': {
            'PTPT': 'Mudado em:'},
        'Mudado por:': {
            'PTPT': 'Mudado por:'},
        'Versões do documento': {
            'PTPT': 'Versões do documento'},
        'Eli. Última': {
            'PTPT': 'Eli. Última'},
        'Eli. Histórico': {
            'PTPT': 'Eli. Histórico'},
        'Submeter documento': {
            'PTPT': 'Submeter documento'},
        'Desbloquear: ignora as alterações atuais e desbloqueia o documento.': {
            'PTPT': 'Desbloquear: ignora as alterações atuais e desbloqueia o documento.'},
        'Gravar: mantém o documento bloqueado e salvaguarda apenas as alterações atuais.': {
            'PTPT': 'Gravar: mantém o documento bloqueado e salvaguarda apenas as alterações atuais.'},
        'Submeter: desbloqueia o documento e cria uma nova versão.': {
            'PTPT': 'Submeter: desbloqueia o documento e cria uma nova versão.'},
        'Versão principal': {
            'PTPT': 'Versão principal'},
        'Versão secundária': {
            'PTPT': 'Versão secundária'},
        'Documento a submeter:': {
            'PTPT': 'Documento a submeter:'},
        '...': {
            'PTPT': '...'},
        'Sobre o programa...': {
            'PTPT': 'Sobre o programa...'},
        'Ok': {
            'PTPT': 'Ok'},
        'R. Viriato, 7': {
            'PTPT': 'R. Viriato, 7'},
        '1050-233 LISBOA': {
            'PTPT': '1050-233 LISBOA'},
        '+351 213 870 563': {
            'PTPT': '+351 213 870 563'},
        'quidgest@quidgest.com': {
            'PTPT': 'quidgest@quidgest.com'},
        'Srv: ?': {
            'PTPT': 'Srv: ?'},
        'Configuração': {
            'PTPT': 'Configuração'},
        'Antes': {
            'PTPT': 'Antes'},
        'Depois': {
            'PTPT': 'Depois'},
        'Ascendente': {
            'PTPT': 'Ascendente'},
        'Descendente': {
            'PTPT': 'Descendente'},
        'Agrupar': {
            'PTPT': 'Agrupar'},
        'Contar': {
            'PTPT': 'Contar'},
        'Todos': {
            'PTPT': 'Todos'},
        'validade': {
            'PTPT': 'validade'},
        'Lista de Utilizadores': {
            'PTPT': 'Lista de Utilizadores'},
        'Alterar a palavra-chave': {
            'PTPT': 'Alterar a palavra-chave'},
        'Confirmar:': {
            'PTPT': 'Confirmar:'},
        'Níveis por módulo:': {
            'PTPT': 'Níveis por módulo:'},
        'Nível:': {
            'PTPT': 'Nível:'},
        'Alteração da Palavra-chave': {
            'PTPT': 'Alteração da Palavra-chave'},
        'Antiga:': {
            'PTPT': 'Antiga:'},
        'Nova:': {
            'PTPT': 'Nova:'},
        'Permissões dos Forms': {
            'PTPT': 'Permissões dos Forms'},
        'Permissão do Form': {
            'PTPT': 'Permissão do Form'},
        'Designação': {
            'PTPT': 'Designação'},
        '&Designação': {
            'PTPT': '&Designação'},
        'Perfil Utilizador': {
            'PTPT': 'Perfil Utilizador'},
        'Autorização': {
            'PTPT': 'Autorização'},
        'Precisa de Validação?': {
            'PTPT': 'Precisa de Validação?'},
        'Perfil': {
            'PTPT': 'Perfil'},
        'Dias': {
            'PTPT': 'Dias'},
        'Horas': {
            'PTPT': 'Horas'},
        'Diária': {
            'PTPT': 'Diária'},
        'Precisa de Comprovativo?': {
            'PTPT': 'Precisa de Comprovativo?'},
        'Mensagem 1': {
            'PTPT': 'Mensagem 1'},
        'Mensagem 2': {
            'PTPT': 'Mensagem 2'},
        'Alteração Aceite': {
            'PTPT': 'Alteração Aceite'},
        'Alteração Rejeitada': {
            'PTPT': 'Alteração Rejeitada'},
        'Comprovativo': {
            'PTPT': 'Comprovativo'},
        'Prazo': {
            'PTPT': 'Prazo'},
        'Validação': {
            'PTPT': 'Validação'},
        'Pedido de Alteração': {
            'PTPT': 'Pedido de Alteração'},
        'Aviso ao Validador': {
            'PTPT': 'Aviso ao Validador'},
        'Resposta ao Utilizador': {
            'PTPT': 'Resposta ao Utilizador'},
        'Sincronização de dados com outros subsistemas': {
            'PTPT': 'Sincronização de dados com outros subsistemas'},
        'Nota': {
            'PTPT': 'Nota'},
        'P/ pessoas c/perfil': {
            'PTPT': 'P/ pessoas c/perfil'},
        'Validade': {
            'PTPT': 'Validade'},
        'Workflows': {
            'PTPT': 'Workflows'},
        'Workflow': {
            'PTPT': 'Workflow'},
        'Ajuda aos Utilizadores': {
            'PTPT': 'Ajuda aos Utilizadores'},
        'Informações sobre os autores': {
            'PTPT': 'Informações sobre os autores'},
        'Abandona o programa': {
            'PTPT': 'Abandona o programa'},
        'Reindexa a Base de Dados': {
            'PTPT': 'Reindexa a Base de Dados'},
        'Alteração da palavra-chave': {
            'PTPT': 'Alteração da palavra-chave'},
        'Backup da Base de Dados': {
            'PTPT': 'Backup da Base de Dados'},
        'Manutenção da Base de Dados': {
            'PTPT': 'Manutenção da Base de Dados'},
        'Gestão dos utilizadores': {
            'PTPT': 'Gestão dos utilizadores'},
        'Seleção e configuração da impressora': {
            'PTPT': 'Seleção e configuração da impressora'},
        'Termina todos os programas que estão a aceder à Base de Dados': {
            'PTPT': 'Termina todos os programas que estão a aceder à Base de Dados'},
        'Atualiza as tabelas da Base de Dados': {
            'PTPT': 'Atualiza as tabelas da Base de Dados'},
        'Bloqueia/Permite o acesso de outros utilizadores à Base de Dados': {
            'PTPT': 'Bloqueia/Permite o acesso de outros utilizadores à Base de Dados'},
        'Propriedades da aplicação': {
            'PTPT': 'Propriedades da aplicação'},
        'Exportação de Messages Queues': {
            'PTPT': 'Exportação de Messages Queues'},
        'Importação de Messages Queues': {
            'PTPT': 'Importação de Messages Queues'},
        'Lista de queues por processar': {
            'PTPT': 'Lista de queues por processar'},
        'Regista smart card': {
            'PTPT': 'Regista smart card'},
        'Mostra as notificações do seu utilizador': {
            'PTPT': 'Mostra as notificações do seu utilizador'},
        'Mostra as notificações do seu grupo': {
            'PTPT': 'Mostra as notificações do seu grupo'},
        'Configura os tipos de alerta (por grupo)': {
            'PTPT': 'Configura os tipos de alerta (por grupo)'},
        'Configura os tipos de alerta (por utilizador)': {
            'PTPT': 'Configura os tipos de alerta (por utilizador)'},
        'Shortcuts': {
            'PTPT': 'Shortcuts'},
        'Folders': {
            'PTPT': 'Folders'},
        'Outlook Bar': {
            'PTPT': 'Outlook Bar'},
        'Menu principal': {
            'PTPT': 'Menu principal'},
        'Opções': {
            'PTPT': 'Opções'},
        'Palavra chave': {
            'PTPT': 'Palavra chave'},
        'Smart Card': {
            'PTPT': 'Smart Card'},
        'Notificações': {
            'PTPT': 'Notificações'},
        'Defina as mensagens/notificações dos utilizadores': {
            'PTPT': 'Defina as mensagens/notificações dos utilizadores'},
        'Message queueing': {
            'PTPT': 'Message queueing'},
        'TAPI': {
            'PTPT': 'TAPI'},
        'Utilizadores': {
            'PTPT': 'Utilizadores'},
        'Grupos': {
            'PTPT': 'Grupos'},
        'Configurar impressora': {
            'PTPT': 'Configurar impressora'},
        'Ajuda On-line': {
            'PTPT': 'Ajuda On-line'},
        'Opções de administração do sistema': {
            'PTPT': 'Opções de administração do sistema'},
        'Alertas de utilizador': {
            'PTPT': 'Alertas de utilizador'},
        'Alertas de grupos': {
            'PTPT': 'Alertas de grupos'},
        'Desligar remoto': {
            'PTPT': 'Desligar remoto'},
        'Reindexar a base de dados': {
            'PTPT': 'Reindexar a base de dados'},
        'Backup da base de dados': {
            'PTPT': 'Backup da base de dados'},
        'Manutenção da base de dados': {
            'PTPT': 'Manutenção da base de dados'},
        'Bloquear acessos à base de dados': {
            'PTPT': 'Bloquear acessos à base de dados'},
        'MSMQ': {
            'PTPT': 'MSMQ'},
        'Estilo': {
            'PTPT': 'Estilo'},
        'Modificar o estilo visual': {
            'PTPT': 'Modificar o estilo visual'},
        'Escolha um dos temas do Office 2007': {
            'PTPT': 'Escolha um dos temas do Office 2007'},
        'Painéis': {
            'PTPT': 'Painéis'},
        'Visibilidade dos painéis': {
            'PTPT': 'Visibilidade dos painéis'},
        'Defina neste menu quais são os painéis visíveis.': {
            'PTPT': 'Defina neste menu quais são os painéis visíveis.'},
        'ERRO: A mensagem %d não está definida!': {
            'PTPT': 'ERRO: A mensagem %d não está definida!'},
        'Entrada incorreta! Tente outra vez...': {
            'PTPT': 'Entrada incorreta! Tente outra vez...'},
        'Estado de autenticação inválido ou expirado! Tente outra vez...': {
            'PTPT': 'Estado de autenticação inválido ou expirado! Tente outra vez...'},
        'O ano do sistema é anterior a %d!': {
            'PTPT': 'O ano do sistema é anterior a %d!'},
        'ERRO: O limite de ramos por menu foi atingido!': {
            'PTPT': 'ERRO: O limite de ramos por menu foi atingido!'},
        'O campo não é válido!': {
            'PTPT': 'O campo não é válido!'},
        'Escolha um elemento da lista.': {
            'PTPT': 'Escolha um elemento da lista.'},
        'Preencha o campo.': {
            'PTPT': 'Preencha o campo.'},
        'A data não é válida!': {
            'PTPT': 'A data não é válida!'},
        'A Base de Dados não é válida ou não existe!': {
            'PTPT': 'A Base de Dados não é válida ou não existe!'},
        'Não há fichas para imprimir!': {
            'PTPT': 'Não há fichas para imprimir!'},
        'De momento não é possível concluir a operação devido ao seguinte erro:\n\n%s\n\nPretende tentar novamente (Repetir/Ignorar) ou prefere encerrar a aplicação (Abortar)?\nNOTA: Se ignorar o erro é conveniente reiniciar a aplicação assim que possível!': {
            'PTPT': 'De momento não é possível concluir a operação devido ao seguinte erro:\n\n%s\n\nPretende tentar novamente (Repetir/Ignorar) ou prefere encerrar a aplicação (Abortar)?\nNOTA: Se ignorar o erro é conveniente reiniciar a aplicação assim que possível!'},
        'A tabela \'%s\' não existe!': {
            'PTPT': 'A tabela \'%s\' não existe!'},
        'Não é possível editar a ficha!': {
            'PTPT': 'Não é possível editar a ficha!'},
        'Não é possível acrescentar uma ficha!': {
            'PTPT': 'Não é possível acrescentar uma ficha!'},
        'ERRO: Botão IDOK não definido!': {
            'PTPT': 'ERRO: Botão IDOK não definido!'},
        'Não é possível gravar a ficha!': {
            'PTPT': 'Não é possível gravar a ficha!'},
        'Não é possível apagar a ficha!': {
            'PTPT': 'Não é possível apagar a ficha!'},
        'ERRO: Botão IDALTERAR sem estar em consulta!': {
            'PTPT': 'ERRO: Botão IDALTERAR sem estar em consulta!'},
        'ERRO: Botão IDAPAGAR sem estar em consulta!': {
            'PTPT': 'ERRO: Botão IDAPAGAR sem estar em consulta!'},
        'ERRO: Botão IDACRESCENTAR sem estar em consulta!': {
            'PTPT': 'ERRO: Botão IDACRESCENTAR sem estar em consulta!'},
        'ERRO: Botão IDDUPLICAR sem estar em consulta!': {
            'PTPT': 'ERRO: Botão IDDUPLICAR sem estar em consulta!'},
        'A formatar os dados...%d%%': {
            'PTPT': 'A formatar os dados...%d%%'},
        'Formatação concluída.': {
            'PTPT': 'Formatação concluída.'},
        'DESEJA ELIMINAR ESTA FICHA?': {
            'PTPT': 'DESEJA ELIMINAR ESTA FICHA?'},
        'Não é possível gravar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.': {
            'PTPT': 'Não é possível gravar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.'},
        'Nesta data, já não é possível gravar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.': {
            'PTPT': 'Nesta data, já não é possível gravar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.'},
        'A Base de Dados está bloqueada!': {
            'PTPT': 'A Base de Dados está bloqueada!'},
        'Não é possível fazer a reindexação porque há\noutros utilizadores a aceder à Base de Dados.': {
            'PTPT': 'Não é possível fazer a reindexação porque há\noutros utilizadores a aceder à Base de Dados.'},
        'O tempo limite para entrar foi excedido!': {
            'PTPT': 'O tempo limite para entrar foi excedido!'},
        'ERRO: O ID %d não está definido!': {
            'PTPT': 'ERRO: O ID %d não está definido!'},
        'ERRO: O controlo %d é do tipo %s e devia ser do tipo %s!': {
            'PTPT': 'ERRO: O controlo %d é do tipo %s e devia ser do tipo %s!'},
        'ERRO(%s): A tabela %s não está relacionada com a tabela %s!': {
            'PTPT': 'ERRO(%s): A tabela %s não está relacionada com a tabela %s!'},
        'ERRO: A tabela %s deve ser criada antes da tabela %s devido a uma fórmula externa e/ou réplica!': {
            'PTPT': 'ERRO: A tabela %s deve ser criada antes da tabela %s devido a uma fórmula externa e/ou réplica!'},
        'ERRO: Não foi indicada uma chave para a tabela %s!': {
            'PTPT': 'ERRO: Não foi indicada uma chave para a tabela %s!'},
        'ERRO: O limite de constantes por tabela foi atingido!': {
            'PTPT': 'ERRO: O limite de constantes por tabela foi atingido!'},
        'ERRO: A chave da tabela %s tem mais do que um campo!': {
            'PTPT': 'ERRO: A chave da tabela %s tem mais do que um campo!'},
        'Os dados foram alterados, entretanto, por outro utilizador. A ficha não será gravada!': {
            'PTPT': 'Os dados foram alterados, entretanto, por outro utilizador. A ficha não será gravada!'},
        'Este registo está a ser usado como referência noutra ficha, não podendo ser apagado!': {
            'PTPT': 'Este registo está a ser usado como referência noutra ficha, não podendo ser apagado!'},
        'ERRO: O ficheiro de passwords não foi encontrado!': {
            'PTPT': 'ERRO: O ficheiro de passwords não foi encontrado!'},
        'ATENÇÃO: As alterações efetuadas vão ser perdidas! Confirma?': {
            'PTPT': 'ATENÇÃO: As alterações efetuadas vão ser perdidas! Confirma?'},
        'ERRO: Na tabela %s há elementos destino de mais do que uma fórmula!': {
            'PTPT': 'ERRO: Na tabela %s há elementos destino de mais do que uma fórmula!'},
        'ERRO: A fórmula %s não é válida!': {
            'PTPT': 'ERRO: A fórmula %s não é válida!'},
        'Este registo está a ser usado como referência na ficha %s, não podendo ser apagado!': {
            'PTPT': 'Este registo está a ser usado como referência na ficha %s, não podendo ser apagado!'},
        'Não é possível continuar a editar a ficha!': {
            'PTPT': 'Não é possível continuar a editar a ficha!'},
        'Não é possível continuar a acrescentar a ficha!': {
            'PTPT': 'Não é possível continuar a acrescentar a ficha!'},
        'Foi atingido o limite máximo de janelas!': {
            'PTPT': 'Foi atingido o limite máximo de janelas!'},
        'Não é possível duplicar a ficha!': {
            'PTPT': 'Não é possível duplicar a ficha!'},
        'ERRO: A relação N:N da tabela %s não está definida!': {
            'PTPT': 'ERRO: A relação N:N da tabela %s não está definida!'},
        'Algumas escolhas já não são válidas!': {
            'PTPT': 'Algumas escolhas já não são válidas!'},
        'Não foi possível concluir a exportação com sucesso!': {
            'PTPT': 'Não foi possível concluir a exportação com sucesso!'},
        'Os dados foram exportados para o ficheiro: %s.': {
            'PTPT': 'Os dados foram exportados para o ficheiro: %s.'},
        'Falha ao iniciar o módulo de relatórios gráficos!': {
            'PTPT': 'Falha ao iniciar o módulo de relatórios gráficos!'},
        'Não foi possível ler o relatório %s!': {
            'PTPT': 'Não foi possível ler o relatório %s!'},
        'Falha ao gerar o relatório!': {
            'PTPT': 'Falha ao gerar o relatório!'},
        'Não é possível efetuar os cálculos diários porque\nhá outros utilizadores a aceder à Base de Dados.': {
            'PTPT': 'Não é possível efetuar os cálculos diários porque\nhá outros utilizadores a aceder à Base de Dados.'},
        'A hora não é válida!': {
            'PTPT': 'A hora não é válida!'},
        'Escolha uma data do calendário!': {
            'PTPT': 'Escolha uma data do calendário!'},
        'ERRO: Falha ao estabelecer a relação desta ficha!': {
            'PTPT': 'ERRO: Falha ao estabelecer a relação desta ficha!'},
        'ERRO: Há elementos na tabela %s que são simultaneamente destino de fórmulas externas e internas ou de consultas a tabelas!': {
            'PTPT': 'ERRO: Há elementos na tabela %s que são simultaneamente destino de fórmulas externas e internas ou de consultas a tabelas!'},
        'Falha ao iniciar a biblioteca de edição!': {
            'PTPT': 'Falha ao iniciar a biblioteca de edição!'},
        'Erro ao verificar a existência de repetições!': {
            'PTPT': 'Erro ao verificar a existência de repetições!'},
        'A ficha com o valor «%s» em \'%s\' não permite valores duplicados!': {
            'PTPT': 'A ficha com o valor «%s» em \'%s\' não permite valores duplicados!'},
        'Não há nenhuma impressora selecionada!': {
            'PTPT': 'Não há nenhuma impressora selecionada!'},
        'Não é possível cancelar a edição da ficha!': {
            'PTPT': 'Não é possível cancelar a edição da ficha!'},
        'Erro ao abrir a Base de Dados para verificação da versão!': {
            'PTPT': 'Erro ao abrir a Base de Dados para verificação da versão!'},
        'Erro ao ler a versão da Base de Dados!': {
            'PTPT': 'Erro ao ler a versão da Base de Dados!'},
        'ERRO: Não é possível relacionar a tabela de passwords com a tabela %s!': {
            'PTPT': 'ERRO: Não é possível relacionar a tabela de passwords com a tabela %s!'},
        'Utilizador não relacionado! Contacte os gestores do sistema.': {
            'PTPT': 'Utilizador não relacionado! Contacte os gestores do sistema.'},
        'A palavra-chave não é válida!': {
            'PTPT': 'A palavra-chave não é válida!'},
        'Nova palavra-chave': {
            'PTPT': 'Nova palavra-chave'},
        'Confirmar nova palavra-chave': {
            'PTPT': 'Confirmar nova palavra-chave'},
        'Palavra-chave actual': {
            'PTPT': 'Palavra-chave actual'},
        'A nova palavra-chave e a confirmação não são iguais.': {
            'PTPT': 'A nova palavra-chave e a confirmação não são iguais.'},
        'Erro ao converter a Base de Dados!': {
            'PTPT': 'Erro ao converter a Base de Dados!'},
        'Selecione um ou mais elementos da lista!': {
            'PTPT': 'Selecione um ou mais elementos da lista!'},
        'O Número de Contribuinte não é válido!': {
            'PTPT': 'O Número de Contribuinte não é válido!'},
        'Escolha um intervalo de datas do calendário!': {
            'PTPT': 'Escolha um intervalo de datas do calendário!'},
        'Escolha uma ou mais datas do calendário!': {
            'PTPT': 'Escolha uma ou mais datas do calendário!'},
        'O processamento do último relatório ainda não foi concluído!': {
            'PTPT': 'O processamento do último relatório ainda não foi concluído!'},
        'Por favor, sincronize os relógios dos PCs que utilizam a aplicação e tente de novo!': {
            'PTPT': 'Por favor, sincronize os relógios dos PCs que utilizam a aplicação e tente de novo!'},
        'A data de verificação não permite o acesso à aplicação!\nPor favor, contacte a Quidgest.': {
            'PTPT': 'A data de verificação não permite o acesso à aplicação!\nPor favor, contacte a Quidgest.'},
        'Não é possível consultar a ficha!': {
            'PTPT': 'Não é possível consultar a ficha!'},
        'Não é possível criar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.': {
            'PTPT': 'Não é possível criar a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.'},
        'ERRO: O campo de comparação da tabela %s não é uma data!': {
            'PTPT': 'ERRO: O campo de comparação da tabela %s não é uma data!'},
        'Não é possível anular a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.': {
            'PTPT': 'Não é possível anular a ficha!\nO seu nível de acesso não lhe permite efetuar esta operação.\nContacte o Administrador de sistema.'},
        'ERRO: \'listagem constante\' mal definida!': {
            'PTPT': 'ERRO: \'listagem constante\' mal definida!'},
        'Não é possível lançar o processo de monitorização!': {
            'PTPT': 'Não é possível lançar o processo de monitorização!'},
        'O intervalo de espera deverá situar-se entre 10 segundos e 5 minutos!': {
            'PTPT': 'O intervalo de espera deverá situar-se entre 10 segundos e 5 minutos!'},
        'Vai forçar a saída de todos os utilizadores. Deseja continuar?': {
            'PTPT': 'Vai forçar a saída de todos os utilizadores. Deseja continuar?'},
        'Não foi possível concluir o shutdown com sucesso!': {
            'PTPT': 'Não foi possível concluir o shutdown com sucesso!'},
        'Não é possível lançar o processo de visualização!': {
            'PTPT': 'Não é possível lançar o processo de visualização!'},
        'Não é possível criar a janela inicial!': {
            'PTPT': 'Não é possível criar a janela inicial!'},
        'ERRO: Tentativa de manipulação de códigos nulos!': {
            'PTPT': 'ERRO: Tentativa de manipulação de códigos nulos!'},
        'Esta ficha está a ser criada por outro utilizador!': {
            'PTPT': 'Esta ficha está a ser criada por outro utilizador!'},
        'Não foi possível alterar o estado das fichas novas bloqueadas da tabela %s!': {
            'PTPT': 'Não foi possível alterar o estado das fichas novas bloqueadas da tabela %s!'},
        'A ficha em causa foi mal criada e vai ser removida!': {
            'PTPT': 'A ficha em causa foi mal criada e vai ser removida!'},
        'Não foi possível remover uma ficha nova da tabela %s!': {
            'PTPT': 'Não foi possível remover uma ficha nova da tabela %s!'},
        'ERRO: A tabela a atualizar não foi definida!': {
            'PTPT': 'ERRO: A tabela a atualizar não foi definida!'},
        'ERRO: Falha ao aceder ao índice %s!': {
            'PTPT': 'ERRO: Falha ao aceder ao índice %s!'},
        'ERRO: A atualização não está totalmente configurada!': {
            'PTPT': 'ERRO: A atualização não está totalmente configurada!'},
        'ERRO: O campo %s não existe na tabela origem!': {
            'PTPT': 'ERRO: O campo %s não existe na tabela origem!'},
        'ERRO: O sub-grupo tem de ser definido antes dos campos de pesquisa!': {
            'PTPT': 'ERRO: O sub-grupo tem de ser definido antes dos campos de pesquisa!'},
        'Escolha um elemento extremo da lista em árvore!': {
            'PTPT': 'Escolha um elemento extremo da lista em árvore!'},
        'Indique quais as atualizações a fazer!': {
            'PTPT': 'Indique quais as atualizações a fazer!'},
        'Não é possível bloquear a Base de Dados!': {
            'PTPT': 'Não é possível bloquear a Base de Dados!'},
        'Não é possível bloquear a Base de Dados para efetuar a mudança de ano!': {
            'PTPT': 'Não é possível bloquear a Base de Dados para efetuar a mudança de ano!'},
        'Erro ao copiar a Base de Dados para efetuar a mudança de ano!': {
            'PTPT': 'Erro ao copiar a Base de Dados para efetuar a mudança de ano!'},
        'Erro ao efetuar a mudança de ano!': {
            'PTPT': 'Erro ao efetuar a mudança de ano!'},
        'Mudança de ano concluída com sucesso': {
            'PTPT': 'Mudança de ano concluída com sucesso'},
        'O ano indicado por parâmetro não é válido!': {
            'PTPT': 'O ano indicado por parâmetro não é válido!'},
        'Erro na asserção das consultas base!': {
            'PTPT': 'Erro na asserção das consultas base!'},
        'ERRO: No form %s as listas grandes devem ter pelo menos um índice de ordenação!': {
            'PTPT': 'ERRO: No form %s as listas grandes devem ter pelo menos um índice de ordenação!'},
        'ERRO: Botão IDALTEROK sem estar em consulta!': {
            'PTPT': 'ERRO: Botão IDALTEROK sem estar em consulta!'},
        'ERRO: O tipo da última dependência não foi reconhecido!': {
            'PTPT': 'ERRO: O tipo da última dependência não foi reconhecido!'},
        'ERRO: Não foi possível preencher a lista!': {
            'PTPT': 'ERRO: Não foi possível preencher a lista!'},
        'ERRO: Em modo VIEW o SelectHist deve estar associado ao código da tabela base!': {
            'PTPT': 'ERRO: Em modo VIEW o SelectHist deve estar associado ao código da tabela base!'},
        'ERRO: As fórmulas externas da tabela %s não foram indicadas na ordem esperada!': {
            'PTPT': 'ERRO: As fórmulas externas da tabela %s não foram indicadas na ordem esperada!'},
        'Erro ao atualizar fichas de hierarquias superiores!': {
            'PTPT': 'Erro ao atualizar fichas de hierarquias superiores!'},
        'ERRO: A tabela %s tem relações com ela própria!': {
            'PTPT': 'ERRO: A tabela %s tem relações com ela própria!'},
        'ERRO: Foram definidas múltiplas relações da tabela %s!': {
            'PTPT': 'ERRO: Foram definidas múltiplas relações da tabela %s!'},
        'O Sistema encontra-se em manutenção! Pedimos desculpa pelo incómodo.': {
            'PTPT': 'O Sistema encontra-se em manutenção! Pedimos desculpa pelo incómodo.'},
        'A aplicação encontra-se em processo de shutdown!': {
            'PTPT': 'A aplicação encontra-se em processo de shutdown!'},
        'O Application Server não está disponível!': {
            'PTPT': 'O Application Server não está disponível!'},
        'Erro ao processar os números sequenciais!': {
            'PTPT': 'Erro ao processar os números sequenciais!'},
        'O ficheiro %s já existe!\nDeseja eliminá-lo?': {
            'PTPT': 'O ficheiro %s já existe!\nDeseja eliminá-lo?'},
        'Por favor introduza outra disquete!': {
            'PTPT': 'Por favor introduza outra disquete!'},
        'Não é possível criar o ficheiro %s!': {
            'PTPT': 'Não é possível criar o ficheiro %s!'},
        'Erro ao carimbar as fichas!': {
            'PTPT': 'Erro ao carimbar as fichas!'},
        'Não foi possível concluir a reindexação com sucesso!': {
            'PTPT': 'Não foi possível concluir a reindexação com sucesso!'},
        'Não foi possível concluir os cálculos diários com sucesso!': {
            'PTPT': 'Não foi possível concluir os cálculos diários com sucesso!'},
        'De momento não é possível efetuar a operação!': {
            'PTPT': 'De momento não é possível efetuar a operação!'},
        'ATENÇÃO: Assim que terminar o que tem a fazer, feche esta janela para proteger novamente a Base de Dados!': {
            'PTPT': 'ATENÇÃO: Assim que terminar o que tem a fazer, feche esta janela para proteger novamente a Base de Dados!'},
        'É necessário atualizar a Base de Dados antes de utilizar esta versão da aplicação!': {
            'PTPT': 'É necessário atualizar a Base de Dados antes de utilizar esta versão da aplicação!'},
        'Não é possível reparar a Base de Dados porque há outros utilizadores a aceder-lhe!': {
            'PTPT': 'Não é possível reparar a Base de Dados porque há outros utilizadores a aceder-lhe!'},
        'Não foi possível concluir a reparação da Base de Dados com sucesso!': {
            'PTPT': 'Não foi possível concluir a reparação da Base de Dados com sucesso!'},
        'Erro ao desmarcar as fichas!': {
            'PTPT': 'Erro ao desmarcar as fichas!'},
        'Erro ao iniciar o motor da Base de Dados!': {
            'PTPT': 'Erro ao iniciar o motor da Base de Dados!'},
        'O NIB não é válido!': {
            'PTPT': 'O NIB não é válido!'},
        'O IBAN não é válido!': {
            'PTPT': 'O IBAN não é válido!'},
        'Por favor, indique o NIB no formato XXXX-XXXX-XXXXXXXXXXX-XX!': {
            'PTPT': 'Por favor, indique o NIB no formato XXXX-XXXX-XXXXXXXXXXX-XX!'},
        'Por favor, utilize os formatos XXXX ou XXXX-XXX!': {
            'PTPT': 'Por favor, utilize os formatos XXXX ou XXXX-XXX!'},
        'ERRO: Existe mais do que um intervalo temporal automático na tabela %s!': {
            'PTPT': 'ERRO: Existe mais do que um intervalo temporal automático na tabela %s!'},
        'A palavra-chave não coincide com a confirmação!': {
            'PTPT': 'A palavra-chave não coincide com a confirmação!'},
        'Erro ao tentar ligação com dispositivo TWAIN. (Obtenção de função de entrada)': {
            'PTPT': 'Erro ao tentar ligação com dispositivo TWAIN. (Obtenção de função de entrada)'},
        'Erro ao tentar ligação com dispositivo TWAIN. (Carregamento DSM)': {
            'PTPT': 'Erro ao tentar ligação com dispositivo TWAIN. (Carregamento DSM)'},
        'Erro inesperado ao tentar ligação com dispositivo TWAIN.': {
            'PTPT': 'Erro inesperado ao tentar ligação com dispositivo TWAIN.'},
        'Erro ao tentar ligação com dispositivo TWAIN.': {
            'PTPT': 'Erro ao tentar ligação com dispositivo TWAIN.'},
        'Erro ao abrir dispositivo TWAIN.': {
            'PTPT': 'Erro ao abrir dispositivo TWAIN.'},
        'Erro ao chamar interface do dispositivo TWAIN.': {
            'PTPT': 'Erro ao chamar interface do dispositivo TWAIN.'},
        'Erro ao fechar interface do dispositivo TWAIN.': {
            'PTPT': 'Erro ao fechar interface do dispositivo TWAIN.'},
        'Erro ao fechar dispositivo TWAIN.': {
            'PTPT': 'Erro ao fechar dispositivo TWAIN.'},
        'Erro ao obter imagem do dispositivo TWAIN.': {
            'PTPT': 'Erro ao obter imagem do dispositivo TWAIN.'},
        'Erro ao obter informação da imagem do dispositivo TWAIN.': {
            'PTPT': 'Erro ao obter informação da imagem do dispositivo TWAIN.'},
        'Erro ao finalizar obtenção de imagem do dispositivo TWAIN.': {
            'PTPT': 'Erro ao finalizar obtenção de imagem do dispositivo TWAIN.'},
        'Erro ao finalizar obtenção de imagens do dispositivo TWAIN.': {
            'PTPT': 'Erro ao finalizar obtenção de imagens do dispositivo TWAIN.'},
        'O número «%s» já existia. Foi substituído por «%s».': {
            'PTPT': 'O número «%s» já existia. Foi substituído por «%s».'},
        'Não tem direitos de acesso para poder reindexar a base de dados.': {
            'PTPT': 'Não tem direitos de acesso para poder reindexar a base de dados.'},
        'O sistema vai reindexar a base de dados, porque: %s\n\nDeseja continuar ?': {
            'PTPT': 'O sistema vai reindexar a base de dados, porque: %s\n\nDeseja continuar ?'},
        'O sistema vai reindexar a base de dados remotamente (através da rede). Deseja continuar ?': {
            'PTPT': 'O sistema vai reindexar a base de dados remotamente (através da rede). Deseja continuar ?'},
        'Deseja cancelar a reindexação ?': {
            'PTPT': 'Deseja cancelar a reindexação ?'},
        'Ocorreram erros durante a reindexação. Por favor, consulte o ficheiro ERRLOG.TXT.': {
            'PTPT': 'Ocorreram erros durante a reindexação. Por favor, consulte o ficheiro ERRLOG.TXT.'},
        'O ponteiro para a ficha é inválido.': {
            'PTPT': 'O ponteiro para a ficha é inválido.'},
        'Memória insuficiente para ler a imagem.': {
            'PTPT': 'Memória insuficiente para ler a imagem.'},
        'Não foi possível ler o ficheiro %s!': {
            'PTPT': 'Não foi possível ler o ficheiro %s!'},
        'Erro ao iniciar a impressão. Por favor verifique a impressora.': {
            'PTPT': 'Erro ao iniciar a impressão. Por favor verifique a impressora.'},
        'Não é possível copiar o ficheiro do documento:\n%s': {
            'PTPT': 'Não é possível copiar o ficheiro do documento:\n%s'},
        'Erro ao imprimir a página atual. Por favor verifique se há papel na impressora.': {
            'PTPT': 'Erro ao imprimir a página atual. Por favor verifique se há papel na impressora.'},
        'Não é possível exportar o documento para a diretoria indicada.': {
            'PTPT': 'Não é possível exportar o documento para a diretoria indicada.'},
        'Não é possível importar o documento indicado.': {
            'PTPT': 'Não é possível importar o documento indicado.'},
        'Por favor, especifique o endereço do destinatário!': {
            'PTPT': 'Por favor, especifique o endereço do destinatário!'},
        'Mensagem enviada com sucesso.': {
            'PTPT': 'Mensagem enviada com sucesso.'},
        'A mensagem não foi enviada.': {
            'PTPT': 'A mensagem não foi enviada.'},
        'Não é possível criar o ficheiro de e-mail!': {
            'PTPT': 'Não é possível criar o ficheiro de e-mail!'},
        'Interpretador não encontrado para executar o programa de e-mail.': {
            'PTPT': 'Interpretador não encontrado para executar o programa de e-mail.'},
        'Memória disponível insuficiente para executar o comando.': {
            'PTPT': 'Memória disponível insuficiente para executar o comando.'},
        'É exigida autorização explícita, com /CRIAANO, para a criação de um novo ano.': {
            'PTPT': 'É exigida autorização explícita, com /CRIAANO, para a criação de um novo ano.'},
        'Não é possível efetuar as alterações!': {
            'PTPT': 'Não é possível efetuar as alterações!'},
        'O seu perfil de utilizador não lhe permite executar esta operação.': {
            'PTPT': 'O seu perfil de utilizador não lhe permite executar esta operação.'},
        'Erro ao criar o ficheiro!': {
            'PTPT': 'Erro ao criar o ficheiro!'},
        'Erro a gravar o ficheiro!': {
            'PTPT': 'Erro a gravar o ficheiro!'},
        'Ocorreu um erro ao processar o pedido.': {
            'PTPT': 'Ocorreu um erro ao processar o pedido.'},
        'O utilizador foi alterado com sucesso.': {
            'PTPT': 'O utilizador foi alterado com sucesso.'},
        'O utilizador não foi alterado!': {
            'PTPT': 'O utilizador não foi alterado!'},
        'Deverá selecionar pelo menos um utilizador.': {
            'PTPT': 'Deverá selecionar pelo menos um utilizador.'},
        'ATENÇÃO: Não foi possível converter o campo %s da tabela %s!': {
            'PTPT': 'ATENÇÃO: Não foi possível converter o campo %s da tabela %s!'},
        'Pretende substituir %s %s por %s em todas as fichas de todas as tabelas da Base de Dados?\n\nATENÇÃO: Depois de efetuar todas as substituições pretendidas, deverá reindexar a Base de Dados!': {
            'PTPT': 'Pretende substituir %s %s por %s em todas as fichas de todas as tabelas da Base de Dados?\n\nATENÇÃO: Depois de efetuar todas as substituições pretendidas, deverá reindexar a Base de Dados!'},
        'Ocorreu um erro durante a substituição! É possível que, em algumas fichas, a substituição tenha sido concluída com sucesso.': {
            'PTPT': 'Ocorreu um erro durante a substituição! É possível que, em algumas fichas, a substituição tenha sido concluída com sucesso.'},
        'A substituição foi concluída com sucesso.': {
            'PTPT': 'A substituição foi concluída com sucesso.'},
        'Não é possível selecionar elementos de listas agregadas.': {
            'PTPT': 'Não é possível selecionar elementos de listas agregadas.'},
        'O tipo de servidor \'%s\' não é válido!': {
            'PTPT': 'O tipo de servidor \'%s\' não é válido!'},
        'Sintaxe incorreta no nome da base de dados \'%s\'!': {
            'PTPT': 'Sintaxe incorreta no nome da base de dados \'%s\'!'},
        'As Bases de Dados adicionais não são válidas ou não existem!': {
            'PTPT': 'As Bases de Dados adicionais não são válidas ou não existem!'},
        'O Número de Identificação na Segurança Social não é válido!': {
            'PTPT': 'O Número de Identificação na Segurança Social não é válido!'},
        'Não é possível efetuar a manutenção porque\nhá outros utilizadores a aceder à Base de Dados.': {
            'PTPT': 'Não é possível efetuar a manutenção porque\nhá outros utilizadores a aceder à Base de Dados.'},
        'Erro ao executar o comando número %s': {
            'PTPT': 'Erro ao executar o comando número %s'},
        'Manutenção concluída (%s)!': {
            'PTPT': 'Manutenção concluída (%s)!'},
        'O relatório utiliza um tipo de ligação não suportado!': {
            'PTPT': 'O relatório utiliza um tipo de ligação não suportado!'},
        'A aplicação não suporta o SGBD indicado!': {
            'PTPT': 'A aplicação não suporta o SGBD indicado!'},
        'ATENÇÃO: Este registo está a ser usado como referência em outras fichas. Pretende eliminar todas essas fichas?\nSe responder não, poderá ainda eliminar as ficha uma a uma; se cancelar, nenhuma ficha será eliminada.': {
            'PTPT': 'ATENÇÃO: Este registo está a ser usado como referência em outras fichas. Pretende eliminar todas essas fichas?\nSe responder não, poderá ainda eliminar as ficha uma a uma; se cancelar, nenhuma ficha será eliminada.'},
        'Pretende eliminar a ficha %s?': {
            'PTPT': 'Pretende eliminar a ficha %s?'},
        'Favoritos': {
            'PTPT': 'Favoritos'},
        'remover': {
            'PTPT': 'remover'},
        'Selecione a entrada de menu que deseja guardar aqui': {
            'PTPT': 'Selecione a entrada de menu que deseja guardar aqui'},
        'Adicionar': {
            'PTPT': 'Adicionar'},
        'adicionar': {
            'PTPT': 'adicionar'},
        'Permitir o Acesso à &BD': {
            'PTPT': 'Permitir o Acesso à &BD'},
        'Bloquear o Acesso à &BD': {
            'PTPT': 'Bloquear o Acesso à &BD'},
        'Por favor, introduza os seus dados de acesso:': {
            'PTPT': 'Por favor, introduza os seus dados de acesso:'},
        'O seu número de acesso privilegiado é o %06d.': {
            'PTPT': 'O seu número de acesso privilegiado é o %06d.'},
        'The code you entered is not valid': {
            'PTPT': 'O código que introduziu não é válido'},
        '(Lista vazia)': {
            'PTPT': '(Lista vazia)'},
        '(Pesquise um registo para ver a lista)': {
            'PTPT': '(Pesquise um registo para ver a lista)'},
        'A verificar a integridade dos dados...\nAguarde, por favor!': {
            'PTPT': 'A verificar a integridade dos dados...\nAguarde, por favor!'},
        'A reindexar a base de dados...\nAguarde, por favor!': {
            'PTPT': 'A reindexar a base de dados...\nAguarde, por favor!'},
        'A efetuar a mudança de ano...\nAguarde, por favor!': {
            'PTPT': 'A efetuar a mudança de ano...\nAguarde, por favor!'},
        'A efetuar os cálculos diários...\nAguarde, por favor!': {
            'PTPT': 'A efetuar os cálculos diários...\nAguarde, por favor!'},
        'Este registo é controlado pela aplicação, não pode ser apagado!': {
            'PTPT': 'Este registo é controlado pela aplicação, não pode ser apagado!'},
        'A versão da base de dados %s no servidor %s vai ser atualizada. Quer continuar?': {
            'PTPT': 'A versão da base de dados %s no servidor %s vai ser atualizada. Quer continuar?'},
        'Erro ao criar as funções para SQL / ORACLE: %s': {
            'PTPT': 'Erro ao criar as funções para SQL / ORACLE: %s'},
        'Página principal': {
            'PTPT': 'Página principal'},
        'Anterior': {
            'PTPT': 'Anterior'},
        'Retroceder': {
            'PTPT': 'Retroceder'},
        'Seguinte': {
            'PTPT': 'Seguinte'},
        'Refrescar': {
            'PTPT': 'Refrescar'},
        'Parar': {
            'PTPT': 'Parar'},
        'ATENÇÃO: O acesso ao sistema apenas é permitido até %d/%m/%Y!\nPor favor contacte a Quidgest.': {
            'PTPT': 'ATENÇÃO: O acesso ao sistema apenas é permitido até %d/%m/%Y!\nPor favor contacte a Quidgest.'},
        '\nFoi solicitada uma reindexação pelo utilizador.': {
            'PTPT': '\nFoi solicitada uma reindexação pelo utilizador.'},
        'Falha ao remover o lock à base de dados.\15\15\12': {
            'PTPT': 'Falha ao remover o lock à base de dados.\15\15\12'},
        'Erro ao verificar a versão/data da base de dados.\15\15\12': {
            'PTPT': 'Erro ao verificar a versão/data da base de dados.\15\15\12'},
        'Erro ao gravar a data de entrada.\15\15\12;': {
            'PTPT': 'Erro ao gravar a data de entrada.\15\15\12;'},
        'Erro ao atualizar as RUVs da tabela %s.\15\15\12': {
            'PTPT': 'Erro ao atualizar as RUVs da tabela %s.\15\15\12'},
        '\nForam feitas alterações à tabela de códigos internos (%d).': {
            'PTPT': '\nForam feitas alterações à tabela de códigos internos (%d).'},
        'Erro ao apagar os índices da tabela %s.\15\15\12': {
            'PTPT': 'Erro ao apagar os índices da tabela %s.\15\15\12'},
        'Não foi possível obter um nome para o ficheiro HTML temporário': {
            'PTPT': 'Não foi possível obter um nome para o ficheiro HTML temporário'},
        'Não foi possível obter um nome para o ficheiro de wallpaper temporário': {
            'PTPT': 'Não foi possível obter um nome para o ficheiro de wallpaper temporário'},
        'Erro ao aceder à tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao aceder à tabela de códigos internos.\15\15\12'},
        'Erro ao aceder à tabela de códigos internos dos módulos.\15\15\12': {
            'PTPT': 'Erro ao aceder à tabela de códigos internos dos módulos.\15\15\12'},
        'Erro ao abrir a tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao abrir a tabela de códigos internos.\15\15\12'},
        'Erro ao criar a ficha da tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao criar a ficha da tabela de códigos internos.\15\15\12'},
        'Erro ao posicionar a ficha da tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao posicionar a ficha da tabela de códigos internos.\15\15\12'},
        'Erro ao editar a ficha da tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao editar a ficha da tabela de códigos internos.\15\15\12'},
        'Erro ao aceder à tabela de códigos.\15\15\12': {
            'PTPT': 'Erro ao aceder à tabela de códigos.\15\15\12'},
        'A tabela %s tem %d ficha(s) com o código interno degradado.\15\15\12': {
            'PTPT': 'A tabela %s tem %d ficha(s) com o código interno degradado.\15\15\12'},
        'Erro ao alterar o campo \'%s\' da tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao alterar o campo \'%s\' da tabela de códigos internos.\15\15\12'},
        'Erro ao gravar a ficha da tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao gravar a ficha da tabela de códigos internos.\15\15\12'},
        'Erro ao gravar o campo \'%s\' na tabela de códigos internos.\15\15\12': {
            'PTPT': 'Erro ao gravar o campo \'%s\' na tabela de códigos internos.\15\15\12'},
        'O código interno \'%s\' suporta apenas %d dígitos e deve ser aumentado.\15\15\12%s': {
            'PTPT': 'O código interno \'%s\' suporta apenas %d dígitos e deve ser aumentado.\15\15\12%s'},
        '\nReindexação obrigatória indicada no ficheiro ini.': {
            'PTPT': '\nReindexação obrigatória indicada no ficheiro ini.'},
        'A base de dados %s não foi encontrada e irá ser criada.': {
            'PTPT': 'A base de dados %s não foi encontrada e irá ser criada.'},
        'Erro ao verificar se deve mudar de ano.\15\15\12': {
            'PTPT': 'Erro ao verificar se deve mudar de ano.\15\15\12'},
        'Erro ao reparar a base de dados.\15\15\12': {
            'PTPT': 'Erro ao reparar a base de dados.\15\15\12'},
        'Erro no CGenioDoc ao executar BFRVRS:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar BFRVRS:\r\n'},
        'Erro ao compactar/reparar a base de dados.\15\15\12': {
            'PTPT': 'Erro ao compactar/reparar a base de dados.\15\15\12'},
        'Erro ao criar o ficheiro %s!': {
            'PTPT': 'Erro ao criar o ficheiro %s!'},
        'Erro ao mudar o nome do ficheiro %s para %s!': {
            'PTPT': 'Erro ao mudar o nome do ficheiro %s para %s!'},
        'Erro ao abrir a base de dados.\15\15\12': {
            'PTPT': 'Erro ao abrir a base de dados.\15\15\12'},
        'Erro ao abrir as base de dados adicionais.\15\15\12': {
            'PTPT': 'Erro ao abrir as base de dados adicionais.\15\15\12'},
        '\nÉ necessário criar, alterar e/ou apagar índices.': {
            'PTPT': '\nÉ necessário criar, alterar e/ou apagar índices.'},
        '\nA última reindexação não foi concluída.': {
            'PTPT': '\nA última reindexação não foi concluída.'},
        'Erro no CGenioDoc ao executar MUDAANO:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar MUDAANO:\r\n'},
        '\nEfectuou uma mudança de ano.': {
            'PTPT': '\nEfectuou uma mudança de ano.'},
        'Erro no CGenioDoc ao executar BFRINDX:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar BFRINDX:\r\n'},
        '\nFoi solicitada pelo administrador.': {
            'PTPT': '\nFoi solicitada pelo administrador.'},
        'Erro no CGenioDoc ao executar DIARIOS:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar DIARIOS:\r\n'},
        'Erro no CGenioDoc ao criar alertas:\n %s': {
            'PTPT': 'Erro no CGenioDoc ao criar alertas:\n %s'},
        'Erro no CGenioDoc ao executar BFR_EPH:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar BFR_EPH:\r\n'},
        'Erro no CGenioDoc ao executar AFT_EPH:\r\n': {
            'PTPT': 'Erro no CGenioDoc ao executar AFT_EPH:\r\n'},
        'Não foi possivel conectar a tabela %s.': {
            'PTPT': 'Não foi possivel conectar a tabela %s.'},
        'A data limite deve ser maior ou igual à data de início': {
            'PTPT': 'A data limite deve ser maior ou igual à data de início'},
        'Início': {
            'PTPT': 'Início'},
        'Fim': {
            'PTPT': 'Fim'},
        'Limite': {
            'PTPT': 'Limite'},
        'Revogado': {
            'PTPT': 'Revogado'},
        'Ver mais': {
            'PTPT': 'Ver mais'},
        'View details': {
            'PTPT': 'Ver detalhes'},
        'Tem a certeza que quer revogar a delegação selecionada?': {
            'PTPT': 'Tem a certeza que quer revogar a delegação selecionada?'},
        'Delegação revogada!': {
            'PTPT': 'Delegação revogada!'},
        'O registo é válido.': {
            'PTPT': 'O registo é válido.'},
        'O registo está incoerente com a sua assinatura!': {
            'PTPT': 'O registo está incoerente com a sua assinatura!'},
        'Este registo ainda não está assinado': {
            'PTPT': 'Este registo ainda não está assinado'},
        'O registo foi assinado!': {
            'PTPT': 'O registo foi assinado!'},
        'Este registo já está assinado': {
            'PTPT': 'Este registo já está assinado'},
        'Sugestões': {
            'PTPT': 'Sugestões'},
        'Sem sugestões': {
            'PTPT': 'Sem sugestões'},
        'Sem idiomas': {
            'PTPT': 'Sem idiomas'},
        'Anexar documento': {
            'PTPT': 'Anexar documento'},
        'Tem a certeza que quer apagar?': {
            'PTPT': 'Tem a certeza que quer apagar?'},
        'O ficheiro já está em edição. Espere que a nova versão seja submetida.': {
            'PTPT': 'O ficheiro já está em edição. Espere que a nova versão seja submetida.'},
        'Nome: %s': {
            'PTPT': 'Nome: %s'},
        'Tamanho: %.1f %s': {
            'PTPT': 'Tamanho: %.1f %s'},
        'Extensão: %s': {
            'PTPT': 'Extensão: %s'},
        'Autor: %s': {
            'PTPT': 'Autor: %s'},
        'Data de criação: %s': {
            'PTPT': 'Data de criação: %s'},
        'Versão atual: %s': {
            'PTPT': 'Versão atual: %s'},
        'Em edição por: %s': {
            'PTPT': 'Em edição por: %s'},
        'A última versão vai ser eliminada.\r\nTem a certeza que quer apagar?': {
            'PTPT': 'A última versão vai ser eliminada.\r\nTem a certeza que quer apagar?'},
        'Todas as versões exceto a última vão ser apagadas.\r\nTem a certeza que quer apagar?': {
            'PTPT': 'Todas as versões exceto a última vão ser apagadas.\r\nTem a certeza que quer apagar?'},
        'Indique o ficheiro a submeter': {
            'PTPT': 'Indique o ficheiro a submeter'},
        'O ficheiro indicado não existe': {
            'PTPT': 'O ficheiro indicado não existe'},
        'Versão': {
            'PTPT': 'Versão'},
        'Documento': {
            'PTPT': 'Documento'},
        'Bytes': {
            'PTPT': 'Bytes'},
        'Autor': {
            'PTPT': 'Autor'},
        'Erro ao criar a assinatura!': {
            'PTPT': 'Erro ao criar a assinatura!'},
        'Erro ao procurar os certificados existentes no sistema!': {
            'PTPT': 'Erro ao procurar os certificados existentes no sistema!'},
        'De': {
            'PTPT': 'De'},
        'Até': {
            'PTPT': 'Até'},
        'Finalizar documento?\r\nSeleccionar \'não\' para adicionar mais páginas.': {
            'PTPT': 'Finalizar documento?\r\nSeleccionar \'não\' para adicionar mais páginas.'},
        'Este módulo não se encontra licenciado, por favor obtenha uma licença válida.': {
            'PTPT': 'Este módulo não se encontra licenciado, por favor obtenha uma licença válida.'},
        'O ficheiro de licenciamento não está presente. A aplicação vai encerrar.': {
            'PTPT': 'O ficheiro de licenciamento não está presente. A aplicação vai encerrar.'},
        'A licença está corrompida, por favor obtenha uma licença válida. A aplicação vai encerrar.': {
            'PTPT': 'A licença está corrompida, por favor obtenha uma licença válida. A aplicação vai encerrar.'},
        'Por favor, utilize o formato %s!': {
            'PTPT': 'Por favor, utilize o formato %s!'},
        'O número final deve ser maior ou igual ao número inicial': {
            'PTPT': 'O número final deve ser maior ou igual ao número inicial'},
        'Futuros': {
            'PTPT': 'Futuros'},
        'Inativos': {
            'PTPT': 'Inativos'},
        'Ativos': {
            'PTPT': 'Ativos'},
        'Tem que permitir o uso de cookies para aceder a este portal': {
            'PTPT': 'Tem que permitir o uso de cookies para aceder a este portal'},
        'Sessão caducada': {
            'PTPT': 'Sessão caducada'},
        'Pedido Inválido': {
            'PTPT': 'Pedido Inválido'},
        'Erro na função que cria o XML para o flash': {
            'PTPT': 'Erro na função que cria o XML para o flash'},
        'Erro na função que obtém o código interno do objeto escolhido.': {
            'PTPT': 'Erro na função que obtém o código interno do objeto escolhido.'},
        'Erro a criar o flash.': {
            'PTPT': 'Erro a criar o flash.'},
        'Erro a carregar o flash do Scorecard.': {
            'PTPT': 'Erro a carregar o flash do Scorecard.'},
        'Erro a carregar o flash da Organica.': {
            'PTPT': 'Erro a carregar o flash da Organica.'},
        'Escolha um elemento da lista de Periodicidades!': {
            'PTPT': 'Escolha um elemento da lista de Periodicidades!'},
        'Login ou password incorretos.': {
            'PTPT': 'Login ou password incorretos.'},
        'Erro na função de tratamento de eventos do Mapa Estratégico': {
            'PTPT': 'Erro na função de tratamento de eventos do Mapa Estratégico'},
        'Falha ao estabelecer a ligação.': {
            'PTPT': 'Falha ao estabelecer a ligação.'},
        'Falha no acesso aos dados.': {
            'PTPT': 'Falha no acesso aos dados.'},
        'O registo não pode ser eliminado porque não tem permissões suficientes.': {
            'PTPT': 'O registo não pode ser eliminado porque não tem permissões suficientes.'},
        'Não tem permissões para alterar o registo.': {
            'PTPT': 'Não tem permissões para alterar o registo.'},
        'Iniciar ligação...': {
            'PTPT': 'Iniciar ligação...'},
        'A estabelecer ligação...': {
            'PTPT': 'A estabelecer ligação...'},
        'A enviar título...': {
            'PTPT': 'A enviar título...'},
        'A fechar ligação. Aguarde, por favor.': {
            'PTPT': 'A fechar ligação. Aguarde, por favor.'},
        'Closing connection, please, wait.': {
            'PTPT': 'Closing connection, please, wait.'},
        'Messagem enviada.': {
            'PTPT': 'Messagem enviada.'},
        'Message was sent.': {
            'PTPT': 'Message was sent.'},
        'A Exportar': {
            'PTPT': 'A Exportar'},
        'A correr aplicativo de visualização de imagem ...': {
            'PTPT': 'A correr aplicativo de visualização de imagem ...'},
        'A imagem a imprimir encontra-se fora da área de impressão.\n\rDeseja imprimir assim?': {
            'PTPT': 'A imagem a imprimir encontra-se fora da área de impressão.\n\rDeseja imprimir assim?'},
        'Menu Ctrl Doc!': {
            'PTPT': 'Menu Ctrl Doc!'},
        'Comando!': {
            'PTPT': 'Comando!'},
        'Não há memória suficiente para criar diálogo de espera.': {
            'PTPT': 'Não há memória suficiente para criar diálogo de espera.'},
        'Inicializando visualizador de documentos ...': {
            'PTPT': 'Inicializando visualizador de documentos ...'},
        'Não é possível anexar objeto do browser ao CGenioDialog.': {
            'PTPT': 'Não é possível anexar objeto do browser ao CGenioDialog.'},
        'Feito!': {
            'PTPT': 'Feito!'},
        'Todos os ficheiros de documentos suportados': {
            'PTPT': 'Todos os ficheiros de documentos suportados'},
        'A correr aplicativo para edição de documentos...': {
            'PTPT': 'A correr aplicativo para edição de documentos...'},
        'Este documento está a ser editado por outro utilizador.\nA abrir este documento apenas para leitura.\nNão são permitidas alterações.': {
            'PTPT': 'Este documento está a ser editado por outro utilizador.\nA abrir este documento apenas para leitura.\nNão são permitidas alterações.'},
        'Documento Nº %s': {
            'PTPT': 'Documento Nº %s'},
        'Deseja apagar esta(s) página(s) e imagem(s)?': {
            'PTPT': 'Deseja apagar esta(s) página(s) e imagem(s)?'},
        'O documento foi alterado. \ N Tem certeza que deseja fechá-lo sem salvar?': {
            'PTPT': 'O documento foi alterado. \ N Tem certeza que deseja fechá-lo sem salvar?'},
        'O documento foi alterado. \n Tem a certeza que quer fechar sem salvar?': {
            'PTPT': 'O documento foi alterado. \n Tem a certeza que quer fechar sem salvar?'},
        'Não pode gravar com os valores inseridos': {
            'PTPT': 'Não pode gravar com os valores inseridos'},
        'Número não encontrado: ': {
            'PTPT': 'Número não encontrado: '},
        'Não foram encontrados certificados ': {
            'PTPT': 'Não foram encontrados certificados '},
        'Palavra-chave expirada': {
            'PTPT': 'Palavra-chave expirada'},
        'Há outros utilizadores a aceder à Base de dados!': {
            'PTPT': 'Há outros utilizadores a aceder à Base de dados!'},
        'Escolha primeiro o destino!': {
            'PTPT': 'Escolha primeiro o destino!'},
        'Não é possível iniciar o backup!': {
            'PTPT': 'Não é possível iniciar o backup!'},
        'Início às %H:%M': {
            'PTPT': 'Início às %H:%M'},
        'Ocorreu um erro!': {
            'PTPT': 'Ocorreu um erro!'},
        'Operação cancelada!': {
            'PTPT': 'Operação cancelada!'},
        'Operação concluída!': {
            'PTPT': 'Operação concluída!'},
        'Não foi possível concluir a operação!': {
            'PTPT': 'Não foi possível concluir a operação!'},
        'Não há espaço suficiente para concluir a operação!': {
            'PTPT': 'Não há espaço suficiente para concluir a operação!'},
        'O sistema deverá estar disponível dentro de alguns minutos. Obrigado.': {
            'PTPT': 'O sistema deverá estar disponível dentro de alguns minutos. Obrigado.'},
        'Não há impressoras configuradas.': {
            'PTPT': 'Não há impressoras configuradas.'},
        'Diagrama Entidade-Relacionamento': {
            'PTPT': 'Diagrama Entidade-Relacionamento'},
        'Erro ao iniciar a impressão.': {
            'PTPT': 'Erro ao iniciar a impressão.'},
        'Erro ao iniciar a página.': {
            'PTPT': 'Erro ao iniciar a página.'},
        'O diagrama resultante é demasiado grande.': {
            'PTPT': 'O diagrama resultante é demasiado grande.'},
        'Foi detetada uma recursividade.': {
            'PTPT': 'Foi detetada uma recursividade.'},
        'Erros': {
            'PTPT': 'Erros'},
        'Relações': {
            'PTPT': 'Relações'},
        'Dependências': {
            'PTPT': 'Dependências'},
        'Incoerências': {
            'PTPT': 'Incoerências'},
        'Incluir todas as selecionadas': {
            'PTPT': 'Incluir todas as selecionadas'},
        'Incluir todas as selecionadas e as diretamente relacionadas': {
            'PTPT': 'Incluir todas as selecionadas e as diretamente relacionadas'},
        'Incluir todas as selecionadas e as que estão diretamente relacionadas com elas': {
            'PTPT': 'Incluir todas as selecionadas e as que estão diretamente relacionadas com elas'},
        'Incluir todas as selecionadas e as relacionadas direta ou indiretamente': {
            'PTPT': 'Incluir todas as selecionadas e as relacionadas direta ou indiretamente'},
        'Excluir todas as selecionadas': {
            'PTPT': 'Excluir todas as selecionadas'},
        'Excluir todas as selecionadas e as diretamente relacionadas': {
            'PTPT': 'Excluir todas as selecionadas e as diretamente relacionadas'},
        'Excluir todas as selecionadas e as que estão diretamente relacionadas com elas': {
            'PTPT': 'Excluir todas as selecionadas e as que estão diretamente relacionadas com elas'},
        'Excluir todas as selecionadas e as relacionadas direta ou indiretamente': {
            'PTPT': 'Excluir todas as selecionadas e as relacionadas direta ou indiretamente'},
        'Visualizar as relações puras de N:N sem a tabela de suporte': {
            'PTPT': 'Visualizar as relações puras de N:N sem a tabela de suporte'},
        'novo': {
            'PTPT': 'novo'},
        'alteração': {
            'PTPT': 'alteração'},
        'anulação': {
            'PTPT': 'anulação'},
        'duplicação': {
            'PTPT': 'duplicação'},
        'Todas as relações estão coerentes': {
            'PTPT': 'Todas as relações estão coerentes'},
        'Ficheiro com todas as queries exportado para ': {
            'PTPT': 'Ficheiro com todas as queries exportado para '},
        'Suspender': {
            'PTPT': 'Suspender'},
        'há utilizadores ligados!\15\15\12': {
            'PTPT': 'há utilizadores ligados!\15\15\12'},
        '\nFoi efetuada uma atualização de dados.': {
            'PTPT': '\nFoi efetuada uma atualização de dados.'},
        'Reindexação concluída com erro às ': {
            'PTPT': 'Reindexação concluída com erro às '},
        'Reindexação concluída às ': {
            'PTPT': 'Reindexação concluída às '},
        'Não conseguiu inicializar o controlo telefónico.': {
            'PTPT': 'Não conseguiu inicializar o controlo telefónico.'},
        'ERRO ao registar o handler': {
            'PTPT': 'ERRO ao registar o handler'},
        '(O parâmetro plRegister não é um ponteiro válido)': {
            'PTPT': '(O parâmetro plRegister não é um ponteiro válido)'},
        '(O objeto TAPI não foi inicializado)': {
            'PTPT': '(O objeto TAPI não foi inicializado)'},
        '(Não existe memória suficiente para efetuar a operação)': {
            'PTPT': '(Não existe memória suficiente para efetuar a operação)'},
        '(Recurso Indisponível)': {
            'PTPT': '(Recurso Indisponível)'},
        'Por favor, volte a iniciar a aplicação.': {
            'PTPT': 'Por favor, volte a iniciar a aplicação.'},
        'Exemplo!': {
            'PTPT': 'Exemplo!'},
        'O programa está em MANUTENÇÃO...\nPor favor tente mais tarde!': {
            'PTPT': 'O programa está em MANUTENÇÃO...\nPor favor tente mais tarde!'},
        'Ficha do Utilizador Geral por preencher!': {
            'PTPT': 'Ficha do Utilizador Geral por preencher!'},
        'O template não foi encontrado!': {
            'PTPT': 'O template não foi encontrado!'},
        'Importação de MQ...': {
            'PTPT': 'Importação de MQ...'},
        'Erro de MSMQ!': {
            'PTPT': 'Erro de MSMQ!'},
        'Ocorreu um erro durante a operação de MQ passado. \n Você gostaria de continuar?': {
            'PTPT': 'Ocorreu um erro durante a operação de MQ passado. \n Você gostaria de continuar?'},
        'Sincronização': {
            'PTPT': 'Sincronização'},
        'Tem certeza que deseja cancelar a importação MQ?': {
            'PTPT': 'Tem certeza que deseja cancelar a importação MQ?'},
        'Terminado.': {
            'PTPT': 'Terminado.'},
        'A operação de reimportação da MQ foi terminada': {
            'PTPT': 'A operação de reimportação da MQ foi terminada'},
        'O username não pode ser nulo!': {
            'PTPT': 'O username não pode ser nulo!'},
        'A password não pode ser nula!': {
            'PTPT': 'A password não pode ser nula!'},
        'As passwords não coincidem!': {
            'PTPT': 'As passwords não coincidem!'},
        'O dominio não pode ser nulo!': {
            'PTPT': 'O dominio não pode ser nulo!'},
        'Deseja apagar esta nota?': {
            'PTPT': 'Deseja apagar esta nota?'},
        'Olá': {
            'PTPT': 'Olá'},
        'Bem-vindo': {
            'PTPT': 'Bem-vindo'},
        'Bom dia': {
            'PTPT': 'Bom dia'},
        'Boa tarde': {
            'PTPT': 'Boa tarde'},
        'Boa noite': {
            'PTPT': 'Boa noite'},
        'Preencha os campos do ecrã de acordo com a imagem': {
            'PTPT': 'Preencha os campos do ecrã de acordo com a imagem'},
        'Selecione a ficha da lista mostrada na imagem': {
            'PTPT': 'Selecione a ficha da lista mostrada na imagem'},
        'Preencha os campos do filtro de acordo com a imagem': {
            'PTPT': 'Preencha os campos do filtro de acordo com a imagem'},
        'Verifique que o conteúdo do campo é igual ao da imagem': {
            'PTPT': 'Verifique que o conteúdo do campo é igual ao da imagem'},
        'Erro ao abrir o ficheiro html de captura de tutorial.': {
            'PTPT': 'Erro ao abrir o ficheiro html de captura de tutorial.'},
        'Fim do ficheiro de entrada.': {
            'PTPT': 'Fim do ficheiro de entrada.'},
        'ERRO! Comando desconhecido.  Linha:': {
            'PTPT': 'ERRO! Comando desconhecido.  Linha:'},
        'Aplicação em modo de reprodução, interrompa primeiro o processo (Ctrl-Shift-P) antes de passar ao modo de gravação.': {
            'PTPT': 'Aplicação em modo de reprodução, interrompa primeiro o processo (Ctrl-Shift-P) antes de passar ao modo de gravação.'},
        'Captura de comandos.': {
            'PTPT': 'Captura de comandos.'},
        'TESTE       SIM': {
            'PTPT': 'TESTE       SIM'},
        'TIMER       1000': {
            'PTPT': 'TIMER       1000'},
        'Modo de gravaçao de comandos: ': {
            'PTPT': 'Modo de gravaçao de comandos: '},
        'Aplicação em modo de gravação, interrompa primeiro o processo (Ctrl-Shift-P) antes de passar ao modo de reprodução.': {
            'PTPT': 'Aplicação em modo de gravação, interrompa primeiro o processo (Ctrl-Shift-P) antes de passar ao modo de reprodução.'},
        'Simulação de comandos.': {
            'PTPT': 'Simulação de comandos.'},
        'Modo de captura interrompido.': {
            'PTPT': 'Modo de captura interrompido.'},
        'Modo de simulação interrompido.': {
            'PTPT': 'Modo de simulação interrompido.'},
        'Ficheiro Jpeg :\nSem memória': {
            'PTPT': 'Ficheiro Jpeg :\nSem memória'},
        'A coluna de ordenação é invisível!': {
            'PTPT': 'A coluna de ordenação é invisível!'},
        'Há campos visíveis não agregados!': {
            'PTPT': 'Há campos visíveis não agregados!'},
        'Configuração válida.': {
            'PTPT': 'Configuração válida.'},
        'Não há colunas visíveis!': {
            'PTPT': 'Não há colunas visíveis!'},
        'Colunas visíveis': {
            'PTPT': 'Colunas visíveis'},
        'Colunas invisíveis não são pesquisáveis': {
            'PTPT': 'Colunas invisíveis não são pesquisáveis'},
        'Falha na leitura dos argumentos do Flash.': {
            'PTPT': 'Falha na leitura dos argumentos do Flash.'},
        'Erro na configuração da Impressora!\nNome da impressora secundária inválido.': {
            'PTPT': 'Erro na configuração da Impressora!\nNome da impressora secundária inválido.'},
        'Erro na configuração da Impressora!\nNome da impressora secundária inexistente ou inválido.': {
            'PTPT': 'Erro na configuração da Impressora!\nNome da impressora secundária inexistente ou inválido.'},
        'Ocorreu um erro ao tentar enviar o comando %s para o Flash.': {
            'PTPT': 'Ocorreu um erro ao tentar enviar o comando %s para o Flash.'},
        'Não foi encontrado o ficheiro %s': {
            'PTPT': 'Não foi encontrado o ficheiro %s'},
        'A lista foi exportada com sucesso.': {
            'PTPT': 'A lista foi exportada com sucesso.'},
        'Não foi possível criar o ficheiro de exportação!': {
            'PTPT': 'Não foi possível criar o ficheiro de exportação!'},
        'Selecione o template a utilizar': {
            'PTPT': 'Selecione o template a utilizar'},
        'Selecione a diretoria e o ficheiro de destino.': {
            'PTPT': 'Selecione a diretoria e o ficheiro de destino.'},
        'Deseja criar um template novo?': {
            'PTPT': 'Deseja criar um template novo?'},
        'Foram encontrados mais de 64K-records.\nPretende exportar todos?\nYES - exportar todos.\nNo - exportar apenas primeiros 64K.\nCancel - não exportar nada.': {
            'PTPT': 'Foram encontrados mais de 64K-records.\nPretende exportar todos?\nYES - exportar todos.\nNo - exportar apenas primeiros 64K.\nCancel - não exportar nada.'},
        'O novo template foi criado com sucesso:\n%s': {
            'PTPT': 'O novo template foi criado com sucesso:\n%s'},
        'Exportação de dados': {
            'PTPT': 'Exportação de dados'},
        'Exportação de dados %i/%i': {
            'PTPT': 'Exportação de dados %i/%i'},
        'Página anterior.': {
            'PTPT': 'Página anterior.'},
        'Página atual/Número de páginas.': {
            'PTPT': 'Página atual/Número de páginas.'},
        'Página seguinte.': {
            'PTPT': 'Página seguinte.'},
        'Página seguinte': {
            'PTPT': 'Página seguinte'},
        'Primeira': {
            'PTPT': 'Primeira'},
        'Última': {
            'PTPT': 'Última'},
        'Preencher a lista com fichas que respeitem as condições dos filtros.': {
            'PTPT': 'Preencher a lista com fichas que respeitem as condições dos filtros.'},
        'Alterar a apresentação da lista': {
            'PTPT': 'Alterar a apresentação da lista'},
        'Definições da tabela': {
            'PTPT': 'Definições da tabela'},
        'Tabela base': {
            'PTPT': 'Tabela base'},
        'Vista gravada': {
            'PTPT': 'Vista gravada'},
        'Tabela base por omissão': {
            'PTPT': 'Tabela base por omissão'},
        'Selecionar vista': {
            'PTPT': 'Selecionar vista'},
        'Configurar colunas': {
            'PTPT': 'Configurar colunas'},
        'Configurar filtros': {
            'PTPT': 'Configurar filtros'},
        'Gerir vistas': {
            'PTPT': 'Gerir vistas'},
        'Criar vista': {
            'PTPT': 'Criar vista'},
        'Gravar alterações': {
            'PTPT': 'Gravar alterações'},
        'Opções de visualização': {
            'PTPT': 'Opções de visualização'},
        'Mudar para vista em lista': {
            'PTPT': 'Mudar para vista em lista'},
        'Mudar para vista alternativa': {
            'PTPT': 'Mudar para vista alternativa'},
        'Nome da vista': {
            'PTPT': 'Nome da vista'},
        'Definir como vista predefinida': {
            'PTPT': 'Definir como vista predefinida'},
        'Vista predefinida': {
            'PTPT': 'Vista predefinida'},
        'Erro no parsing de XML': {
            'PTPT': 'Erro no parsing de XML'},
        'Foi solicitada uma reindexação pelo utilizador.': {
            'PTPT': 'Foi solicitada uma reindexação pelo utilizador.'},
        'Eliminação de BDs temporárias': {
            'PTPT': 'Eliminação de BDs temporárias'},
        'Não é possível renomear arquivo de log antigo!': {
            'PTPT': 'Não é possível renomear arquivo de log antigo!'},
        'Reconstrução de índices': {
            'PTPT': 'Reconstrução de índices'},
        'Verificação dos níveis de acesso': {
            'PTPT': 'Verificação dos níveis de acesso'},
        'Reconstrução de índices de pesquisa textual': {
            'PTPT': 'Reconstrução de índices de pesquisa textual'},
        'Eliminação de trigger do audit': {
            'PTPT': 'Eliminação de trigger do audit'},
        'Eliminação de índices antigos': {
            'PTPT': 'Eliminação de índices antigos'},
        'Atualização de estados': {
            'PTPT': 'Atualização de estados'},
        'Atualização de réplicas': {
            'PTPT': 'Atualização de réplicas'},
        'Eliminação de destinos': {
            'PTPT': 'Eliminação de destinos'},
        'Cálculo de fórmulas e RUVs...': {
            'PTPT': 'Cálculo de fórmulas e RUVs...'},
        'Cálculo concluído': {
            'PTPT': 'Cálculo concluído'},
        'Reconstrução de códigos internos': {
            'PTPT': 'Reconstrução de códigos internos'},
        'Criação de triggers do audit': {
            'PTPT': 'Criação de triggers do audit'},
        'Cálculo de RUVs...': {
            'PTPT': 'Cálculo de RUVs...'},
        'Cálculo de fórmulas com datas...': {
            'PTPT': 'Cálculo de fórmulas com datas...'},
        'Foram feitas alterações à tabela de códigos internos (1).': {
            'PTPT': 'Foram feitas alterações à tabela de códigos internos (1).'},
        'O registo \'%s\' na tabela de códigos internos está inválido e é necessário reindexar com zero = true.\15\15\12': {
            'PTPT': 'O registo \'%s\' na tabela de códigos internos está inválido e é necessário reindexar com zero = true.\15\15\12'},
        'Por favor, contacte o Administrador.': {
            'PTPT': 'Por favor, contacte o Administrador.'},
        'O código interno \'%s\' suporta apenas %d dígitos e deve ser aumentado.\15\15\12': {
            'PTPT': 'O código interno \'%s\' suporta apenas %d dígitos e deve ser aumentado.\15\15\12'},
        'Por favor, contacte a Quidgest.': {
            'PTPT': 'Por favor, contacte a Quidgest.'},
        'Não é possível renomear o antigo ficheiro de log!': {
            'PTPT': 'Não é possível renomear o antigo ficheiro de log!'},
        'Todas as filas MSMQ estão indisponíveis. Por favor, contacte o administrador. Todas as informações são registadas.': {
            'PTPT': 'Todas as filas MSMQ estão indisponíveis. Por favor, contacte o administrador. Todas as informações são registadas.'},
        'Pelo menos uma das filas MSMQ não está disponível. Por favor, contacte o administrador. Toda a informação é registada. \n Queues: \n': {
            'PTPT': 'Pelo menos uma das filas MSMQ não está disponível. Por favor, contacte o administrador. Toda a informação é registada. \n Queues: \n'},
        'Reparação da BD...': {
            'PTPT': 'Reparação da BD...'},
        'Reparação concluída': {
            'PTPT': 'Reparação concluída'},
        'Eliminação dos triggers de audit': {
            'PTPT': 'Eliminação dos triggers de audit'},
        'Criação de Funções auxiliares': {
            'PTPT': 'Criação de Funções auxiliares'},
        'Verificação de tabelas fixas': {
            'PTPT': 'Verificação de tabelas fixas'},
        'Verificação de tabelas': {
            'PTPT': 'Verificação de tabelas'},
        'Verificação de colunas': {
            'PTPT': 'Verificação de colunas'},
        'Atualização de stored procedures': {
            'PTPT': 'Atualização de stored procedures'},
        'Atualização de scripts T-SQL com regras de negócio': {
            'PTPT': 'Atualização de scripts T-SQL com regras de negócio'},
        'Atualização de Stored Procedured e Functions... manuais': {
            'PTPT': 'Atualização de Stored Procedured e Functions... manuais'},
        'Atualização de Stored Procedured e Functions... final': {
            'PTPT': 'Atualização de Stored Procedured e Functions... final'},
        'Compactação da BD...': {
            'PTPT': 'Compactação da BD...'},
        'Compactação concluída': {
            'PTPT': 'Compactação concluída'},
        'Backup local da BD...': {
            'PTPT': 'Backup local da BD...'},
        'Backup local concluído': {
            'PTPT': 'Backup local concluído'},
        'Verificação de Versão': {
            'PTPT': 'Verificação de Versão'},
        'Reindexação...': {
            'PTPT': 'Reindexação...'},
        '\n(Antes da mudança de ano.)': {
            'PTPT': '\n(Antes da mudança de ano.)'},
        '\nNOTA: Não é possível cancelar esta reindexação, uma vez iniciada.': {
            'PTPT': '\nNOTA: Não é possível cancelar esta reindexação, uma vez iniciada.'},
        'Mudança de Ano...%d%%': {
            'PTPT': 'Mudança de Ano...%d%%'},
        'Verificar Tabelas...%d%%': {
            'PTPT': 'Verificar Tabelas...%d%%'},
        'Não é possível inicializar instância de Msxml2.DOMDocument.4.0': {
            'PTPT': 'Não é possível inicializar instância de Msxml2.DOMDocument.4.0'},
        'Não é possível fazer o parse da string de XML fornecida.\n Queue: ': {
            'PTPT': 'Não é possível fazer o parse da string de XML fornecida.\n Queue: '},
        'Erro ao processar as queues EXPIRE: ': {
            'PTPT': 'Erro ao processar as queues EXPIRE: '},
        'Erro ao processar as queues FAIL: ': {
            'PTPT': 'Erro ao processar as queues FAIL: '},
        'Erro ao processar as queues de ACKNOWLEDGE: ': {
            'PTPT': 'Erro ao processar as queues de ACKNOWLEDGE: '},
        'Nome da Queue': {
            'PTPT': 'Nome da Queue'},
        'Trajeto da Queue': {
            'PTPT': 'Trajeto da Queue'},
        'Canal da Queue': {
            'PTPT': 'Canal da Queue'},
        'Status da Queue': {
            'PTPT': 'Status da Queue'},
        'Nº de mensagens': {
            'PTPT': 'Nº de mensagens'},
        'Último status': {
            'PTPT': 'Último status'},
        'MQ status da importação: permitido.': {
            'PTPT': 'MQ status da importação: permitido.'},
        'Parar importação de MSMQ': {
            'PTPT': 'Parar importação de MSMQ'},
        'MQ status da importação: não permitido.': {
            'PTPT': 'MQ status da importação: não permitido.'},
        'Recomeçar importação de MSMQ': {
            'PTPT': 'Recomeçar importação de MSMQ'},
        'Testar a MSMQ status...': {
            'PTPT': 'Testar a MSMQ status...'},
        'Sem conexão': {
            'PTPT': 'Sem conexão'},
        'Selecione uma mensagem da lista em primeiro lugar.': {
            'PTPT': 'Selecione uma mensagem da lista em primeiro lugar.'},
        'Gravar a mensagem no disco': {
            'PTPT': 'Gravar a mensagem no disco'},
        'Não pode criar o ficheiro.': {
            'PTPT': 'Não pode criar o ficheiro.'},
        'Computador': {
            'PTPT': 'Computador'},
        'Aplicação': {
            'PTPT': 'Aplicação'},
        'Ação': {
            'PTPT': 'Ação'},
        'Descrição': {
            'PTPT': 'Descrição'},
        'Código de erro': {
            'PTPT': 'Código de erro'},
        'Nada para escrever.': {
            'PTPT': 'Nada para escrever.'},
        'Não é possível criar o ficheiro.': {
            'PTPT': 'Não é possível criar o ficheiro.'},
        'O nome da ficheiro de relatório está vazio!': {
            'PTPT': 'O nome da ficheiro de relatório está vazio!'},
        'Estrutura de dados': {
            'PTPT': 'Estrutura de dados'},
        'Formulários': {
            'PTPT': 'Formulários'},
        'Compactação do transaction log...': {
            'PTPT': 'Compactação do transaction log...'},
        'Erro ao criar as funções para SQL / ORACLE:': {
            'PTPT': 'Erro ao criar as funções para SQL / ORACLE:'},
        'Não está definida diretoria para FileStream no ficheiro INI': {
            'PTPT': 'Não está definida diretoria para FileStream no ficheiro INI'},
        'Erro ao criar a diretoria FileStream.': {
            'PTPT': 'Erro ao criar a diretoria FileStream.'},
        'Criação da BD não implementada!': {
            'PTPT': 'Criação da BD não implementada!'},
        'Verificação da Base de Dados': {
            'PTPT': 'Verificação da Base de Dados'},
        'Replicação da BD...': {
            'PTPT': 'Replicação da BD...'},
        'Replicação concluída': {
            'PTPT': 'Replicação concluída'},
        'Versão da BD: %04.02f...': {
            'PTPT': 'Versão da BD: %04.02f...'},
        'BD inexistente. Versão: %04.02f...': {
            'PTPT': 'BD inexistente. Versão: %04.02f...'},
        'Versão inicial da BD: %04.02f...': {
            'PTPT': 'Versão inicial da BD: %04.02f...'},
        'ERRO AO IMPORTAR OS DADOS:\n%s': {
            'PTPT': 'ERRO AO IMPORTAR OS DADOS:\n%s'},
        'Upgrade para a versão %04.02f...': {
            'PTPT': 'Upgrade para a versão %04.02f...'},
        'Criação de uma BD temporária...': {
            'PTPT': 'Criação de uma BD temporária...'},
        'Upgrade concluído': {
            'PTPT': 'Upgrade concluído'},
        'conversão do campo %s': {
            'PTPT': 'conversão do campo %s'},
        'Ocorreu uma alteração de índice num CDepend sobre a tabela %s.\15\15\12O índice é %s, mas deveria ser %s!': {
            'PTPT': 'Ocorreu uma alteração de índice num CDepend sobre a tabela %s.\15\15\12O índice é %s, mas deveria ser %s!'},
        'Não foram encontrados certificados %s': {
            'PTPT': 'Não foram encontrados certificados %s'},
        'Sintaxe incorreta em fórmula de SQL\nErro: %s \nFórmula:\n%s': {
            'PTPT': 'Sintaxe incorreta em fórmula de SQL\nErro: %s \nFórmula:\n%s'},
        'Fórmulas Internas:\t%s': {
            'PTPT': 'Fórmulas Internas:\t%s'},
        'Ultimos valores:\t%s': {
            'PTPT': 'Ultimos valores:\t%s'},
        'Fórmulas Externas:\t%s': {
            'PTPT': 'Fórmulas Externas:\t%s'},
        'Operações em Árvore:\t%s': {
            'PTPT': 'Operações em Árvore:\t%s'},
        'da tabela': {
            'PTPT': 'da tabela'},
        'análise da tabela %s': {
            'PTPT': 'análise da tabela %s'},
        'Níveis de Acesso': {
            'PTPT': 'Níveis de Acesso'},
        'Grupos de Acesso': {
            'PTPT': 'Grupos de Acesso'},
        'Direitos de Acesso': {
            'PTPT': 'Direitos de Acesso'},
        'ATENÇÃO: O programa será terminado dentro de ': {
            'PTPT': 'ATENÇÃO: O programa será terminado dentro de '},
        'Colocar os sistemas em manutenção (i.e. MANUT=TRUE no INI global)': {
            'PTPT': 'Colocar os sistemas em manutenção (i.e. MANUT=TRUE no INI global)'},
        '213 870 652 / (fax) 213 870 697 ': {
            'PTPT': '213 870 652 / (fax) 213 870 697 '},
        'Ver:': {
            'PTPT': 'Ver:'},
        'Grupo:': {
            'PTPT': 'Grupo:'},
        'Níveis:': {
            'PTPT': 'Níveis:'},
        'Não é possível apagar a ficha! Há fichas relacionadas! [Ficha %s]': {
            'PTPT': 'Não é possível apagar a ficha! Há fichas relacionadas! [Ficha %s]'},
        'ATENÇÃO!!!! Ao prosseguir irá apagar TODAS as fichas que tenham relação com esta.\n Estes danos poderão ser IRREPARÁVEIS e estão à sua inteira responsabilidade.\n Tem MESMO a certeza de que deseja continuar?': {
            'PTPT': 'ATENÇÃO!!!! Ao prosseguir irá apagar TODAS as fichas que tenham relação com esta.\n Estes danos poderão ser IRREPARÁVEIS e estão à sua inteira responsabilidade.\n Tem MESMO a certeza de que deseja continuar?'},
        'Erro no código de extensão.\r\n Veja o ficheiro errlog.txt para mais pormenores.': {
            'PTPT': 'Erro no código de extensão.\r\n Veja o ficheiro errlog.txt para mais pormenores.'},
        'Confirma que deseja abandonar o projeto [%s]?': {
            'PTPT': 'Confirma que deseja abandonar o projeto [%s]?'},
        'A última reindexação não foi concluída.': {
            'PTPT': 'A última reindexação não foi concluída.'},
        '(Antes da mudança de ano.)\n NOTA: Não é possível cancelar esta reindexação, uma vez iniciada.': {
            'PTPT': '(Antes da mudança de ano.)\n NOTA: Não é possível cancelar esta reindexação, uma vez iniciada.'},
        'Valid.': {
            'PTPT': 'Valid.'},
        'Validador': {
            'PTPT': 'Validador'},
        'Compr.': {
            'PTPT': 'Compr.'},
        'Nome do Form': {
            'PTPT': 'Nome do Form'},
        'Perfil do Utilizador': {
            'PTPT': 'Perfil do Utilizador'},
        'Tipo de autorização do perfil de utilizador sobre os campos do form': {
            'PTPT': 'Tipo de autorização do perfil de utilizador sobre os campos do form'},
        'Existe necessidade de validação das alterações efetuadas ao form?': {
            'PTPT': 'Existe necessidade de validação das alterações efetuadas ao form?'},
        'Perfil do utilizador que faz a validação caso haja necessidade de validar alterações': {
            'PTPT': 'Perfil do utilizador que faz a validação caso haja necessidade de validar alterações'},
        'Prazo de entrega do comprovativo em dias': {
            'PTPT': 'Prazo de entrega do comprovativo em dias'},
        'Prazo de entrega do comprovativo em horas': {
            'PTPT': 'Prazo de entrega do comprovativo em horas'},
        'Existe necessidade de entregar um comprovativo para as alterações a este form?': {
            'PTPT': 'Existe necessidade de entregar um comprovativo para as alterações a este form?'},
        'Nome do comprovativo a entregar, caso seja necessário': {
            'PTPT': 'Nome do comprovativo a entregar, caso seja necessário'},
        'Mensagem para o utilizador quando este faz uma alteração no form': {
            'PTPT': 'Mensagem para o utilizador quando este faz uma alteração no form'},
        'Mensagem para o utilizador validador a informar que o utilizador efetuou uma alteração no form': {
            'PTPT': 'Mensagem para o utilizador validador a informar que o utilizador efetuou uma alteração no form'},
        'Mensagem para o utilizador quando a alteração foi aceite pelo validador': {
            'PTPT': 'Mensagem para o utilizador quando a alteração foi aceite pelo validador'},
        'Mensagem para o utilizador quando a alteração foi rejeitada pelo validador': {
            'PTPT': 'Mensagem para o utilizador quando a alteração foi rejeitada pelo validador'},
        'Caso os alertas sejam para grupo e seja necessário que cada um dos elementos do grupo seja notificado individualmente.': {
            'PTPT': 'Caso os alertas sejam para grupo e seja necessário que cada um dos elementos do grupo seja notificado individualmente.'},
        'Certificado registado com sucesso': {
            'PTPT': 'Certificado registado com sucesso'},
        'Não foi possivel atualizar': {
            'PTPT': 'Não foi possivel atualizar'},
        'Não foi possivel abrir o store!': {
            'PTPT': 'Não foi possivel abrir o store!'},
        'Problema com os certificados!': {
            'PTPT': 'Problema com os certificados!'},
        'Nível': {
            'PTPT': 'Nível'},
        'Níveis': {
            'PTPT': 'Níveis'},
        'Descrica': {
            'PTPT': 'Descrica'},
        'Testar o estado da MSMQ...': {
            'PTPT': 'Testar o estado da MSMQ...'},
        'Sem conexão: ': {
            'PTPT': 'Sem conexão: '},
        'Conectado: ': {
            'PTPT': 'Conectado: '},
        'No momento, MQ exportação não é permitido, a parar.': {
            'PTPT': 'No momento, MQ exportação não é permitido, a parar.'},
        'Exportar tabelas...': {
            'PTPT': 'Exportar tabelas...'},
        'Por favor selecione uma Queue para exportar.': {
            'PTPT': 'Por favor selecione uma Queue para exportar.'},
        'Por favor selecione uma Queue para importar.': {
            'PTPT': 'Por favor selecione uma Queue para importar.'},
        'ERRO: queue ': {
            'PTPT': 'ERRO: queue '},
        'não foi definido no arquivo INI! \n Deseja continuar com as outras Queues?': {
            'PTPT': 'não foi definido no arquivo INI! \n Deseja continuar com as outras Queues?'},
        'Envio-Falhou': {
            'PTPT': 'Envio-Falhou'},
        'Envio-EmProgresso': {
            'PTPT': 'Envio-EmProgresso'},
        'Envio-Expirou': {
            'PTPT': 'Envio-Expirou'},
        'Resposta-OK': {
            'PTPT': 'Resposta-OK'},
        'Resposta-Rejeitada': {
            'PTPT': 'Resposta-Rejeitada'},
        'Resposta-Falhou': {
            'PTPT': 'Resposta-Falhou'},
        'QueueID': {
            'PTPT': 'QueueID'},
        'ID Queue': {
            'PTPT': 'ID Queue'},
        'Data do Estado': {
            'PTPT': 'Data do Estado'},
        'Hoje': {
            'PTPT': 'Hoje'},
        'Grupo de Alertas': {
            'PTPT': 'Grupo de Alertas'},
        'Só é permitido validade até:': {
            'PTPT': 'Só é permitido validade até:'},
        'Erro a invocar a Area': {
            'PTPT': 'Erro a invocar a Area'},
        'Erro a inserir os nomes dos campos.': {
            'PTPT': 'Erro a inserir os nomes dos campos.'},
        'Erro na inserção dos campo e valores de campos na área.': {
            'PTPT': 'Erro na inserção dos campo e valores de campos na área.'},
        'Erro ao gravar imagem': {
            'PTPT': 'Erro ao gravar imagem'},
        'Erro na inserção dos campo e valores de campos na área': {
            'PTPT': 'Erro na inserção dos campo e valores de campos na área'},
        'Erro na inserção de um nome e valor de campo na área.': {
            'PTPT': 'Erro na inserção de um nome e valor de campo na área.'},
        'Não é possível obter o ficheiro.': {
            'PTPT': 'Não é possível obter o ficheiro.'},
        'Erro a devolver um valor de um campo.': {
            'PTPT': 'Erro a devolver um valor de um campo.'},
        'Erro no calculo de valores default': {
            'PTPT': 'Erro no calculo de valores default'},
        'Erro no calculo das replicas': {
            'PTPT': 'Erro no calculo das replicas'},
        'Erro a apagar os Ficheiros': {
            'PTPT': 'Erro a apagar os Ficheiros'},
        'O utilizador não tem permissões para eliminar o registo.': {
            'PTPT': 'O utilizador não tem permissões para eliminar o registo.'},
        'O registo não pode ser eliminado porque não tem permissões suficientes.Rel': {
            'PTPT': 'O registo não pode ser eliminado porque não tem permissões suficientes.Rel'},
        'O registo não pode ser eliminado porque existem registos relacionados.': {
            'PTPT': 'O registo não pode ser eliminado porque existem registos relacionados.'},
        'Erro na alteração do registo.': {
            'PTPT': 'Erro na alteração do registo.'},
        'Exceção na inserção do registo.': {
            'PTPT': 'Exceção na inserção do registo.'},
        'Erro na duplicação': {
            'PTPT': 'Erro na duplicação'},
        'Erro no cálculo do argumento ultimo valor': {
            'PTPT': 'Erro no cálculo do argumento ultimo valor'},
        'Ocorreu um erro interno no servidor.': {
            'PTPT': 'Ocorreu um erro interno no servidor.'},
        'Não tem permissões para efetuar a operação.': {
            'PTPT': 'Não tem permissões para efetuar a operação.'},
        'Erro interno de metadados': {
            'PTPT': 'Erro interno de metadados'},
        'Erro ao devolver a array do report': {
            'PTPT': 'Erro ao devolver a array do report'},
        'Erro a invocar a Arvore': {
            'PTPT': 'Erro a invocar a Arvore'},
        'Erro a ler o xml.': {
            'PTPT': 'Erro a ler o xml.'},
        'Propriedade não existente: ': {
            'PTPT': 'Propriedade não existente: '},
        'Erro na conversão de string para double.': {
            'PTPT': 'Erro na conversão de string para double.'},
        'Erro na conversão de string para int.': {
            'PTPT': 'Erro na conversão de string para int.'},
        'Erro na conversão de data para Datetime.': {
            'PTPT': 'Erro na conversão de data para Datetime.'},
        'O mês não tem 31 dias.': {
            'PTPT': 'O mês não tem 31 dias.'},
        'O mês de fevereiro não tem 30 nem 31 dias.': {
            'PTPT': 'O mês de fevereiro não tem 30 nem 31 dias.'},
        'O mês de fevereiro não tem 29 dias.': {
            'PTPT': 'O mês de fevereiro não tem 29 dias.'},
        'A data é inválida.': {
            'PTPT': 'A data é inválida.'},
        'Erro na conversão de data para datetime.': {
            'PTPT': 'Erro na conversão de data para datetime.'},
        'Hora inválida.': {
            'PTPT': 'Hora inválida.'},
        'Erro na conversão de horas para formato interno.': {
            'PTPT': 'Erro na conversão de horas para formato interno.'},
        'Erro na conversão de string para booleano.': {
            'PTPT': 'Erro na conversão de string para booleano.'},
        'O tipo de Formatação não está definido.': {
            'PTPT': 'O tipo de Formatação não está definido.'},
        'Erro na conversão de tipo de campo interno int, para tipo interno int Valido.': {
            'PTPT': 'Erro na conversão de tipo de campo interno int, para tipo interno int Valido.'},
        'Erro na conversão de tipo de campo interno double, para tipo interno double Valido.': {
            'PTPT': 'Erro na conversão de tipo de campo interno double, para tipo interno double Valido.'},
        'Erro na conversão de tipo de campo interno DateTime, para tipo interno DateTime Valido.': {
            'PTPT': 'Erro na conversão de tipo de campo interno DateTime, para tipo interno DateTime Valido.'},
        'Erro na passagem de tipo interno para tipo aceite pela base de dados.': {
            'PTPT': 'Erro na passagem de tipo interno para tipo aceite pela base de dados.'},
        'Erro na conversão de tipo interno DateTime para tipo data aceite numa query.': {
            'PTPT': 'Erro na conversão de tipo interno DateTime para tipo data aceite numa query.'},
        'Erro na conversão de tipo interno array binário para tipo binário aceite numa query.': {
            'PTPT': 'Erro na conversão de tipo interno array binário para tipo binário aceite numa query.'},
        'Erro na conversão das datas': {
            'PTPT': 'Erro na conversão das datas'},
        'Erro na conversão de tipo de campo interno para string.': {
            'PTPT': 'Erro na conversão de tipo de campo interno para string.'},
        'Erro na conversão de tipo de campo interno para string': {
            'PTPT': 'Erro na conversão de tipo de campo interno para string'},
        'Erro na conversão de tipo interno DateTime para string.': {
            'PTPT': 'Erro na conversão de tipo interno DateTime para string.'},
        'Erro na conversão de DateTime para string': {
            'PTPT': 'Erro na conversão de DateTime para string'},
        'Erro no apuramento das fórmulas': {
            'PTPT': 'Erro no apuramento das fórmulas'},
        'Erro no calculo do valor da formula condicao': {
            'PTPT': 'Erro no calculo do valor da formula condicao'},
        'Erro no calculo do valor da formula interna': {
            'PTPT': 'Erro no calculo do valor da formula interna'},
        'Erro no calculo do valor da replica': {
            'PTPT': 'Erro no calculo do valor da replica'},
        'Erro na função executa função da classe Funções Globais, o nome de função invocado não existe': {
            'PTPT': 'Erro na função executa função da classe Funções Globais, o nome de função invocado não existe'},
        'Erro na execução de função global': {
            'PTPT': 'Erro na execução de função global'},
        'Não foi possível concluír a operação, por favor tente novamente. Caso a situação persista entre em contacto com um administrador.': {
            'PTPT': 'Não foi possível concluír a operação, por favor tente novamente. Caso a situação persista entre em contacto com um administrador.'},
        'Versão da aplicação ({0}) não compatível com a da BD.': {
            'PTPT': 'Versão da aplicação ({0}) não compatível com a da BD.'},
        'Erro no Login': {
            'PTPT': 'Erro no Login'},
        'Por favor corrija os erros e tente de novo.': {
            'PTPT': 'Por favor corrija os erros e tente de novo.'},
        'Não existem módulos web definidos.': {
            'PTPT': 'Não existem módulos web definidos.'},
        'O utilizador não pode aceder a nenhum módulo web.': {
            'PTPT': 'O utilizador não pode aceder a nenhum módulo web.'},
        'Tipo de Login mal definido.': {
            'PTPT': 'Tipo de Login mal definido.'},
        'Password incorreta.': {
            'PTPT': 'Password incorreta.'},
        'Certificado não registado.': {
            'PTPT': 'Certificado não registado.'},
        'A nova palavra-passe não pode ser idêntica à antiga.': {
            'PTPT': 'A nova palavra-passe não pode ser idêntica à antiga.'},
        'A password antiga não é correta.': {
            'PTPT': 'A password antiga não é correta.'},
        'Erro na verificação da password antiga.': {
            'PTPT': 'Erro na verificação da password antiga.'},
        'A password não coincide com a confirmação.': {
            'PTPT': 'A password não coincide com a confirmação.'},
        'Não existe nenhum módulo web definido por isso não pode alterar a password.': {
            'PTPT': 'Não existe nenhum módulo web definido por isso não pode alterar a password.'},
        'Não podem ser geradas passwords sem o smtp e email de envio configurados.': {
            'PTPT': 'Não podem ser geradas passwords sem o smtp e email de envio configurados.'},
        'Não foi possível enviar o email.': {
            'PTPT': 'Não foi possível enviar o email.'},
        'Ordenação inválida': {
            'PTPT': 'Ordenação inválida'},
        'Lista de campos inválida': {
            'PTPT': 'Lista de campos inválida'},
        'Lista de campos  inválida': {
            'PTPT': 'Lista de campos  inválida'},
        'Referência a tabela inválida': {
            'PTPT': 'Referência a tabela inválida'},
        'Condição inválida': {
            'PTPT': 'Condição inválida'},
        'Este campo não foi assinado': {
            'PTPT': 'Este campo não foi assinado'},
        'Não foram definidos campos para assinar': {
            'PTPT': 'Não foram definidos campos para assinar'},
        'Assinatura invalida': {
            'PTPT': 'Assinatura invalida'},
        'Não foram definidos campos para a assinatura': {
            'PTPT': 'Não foram definidos campos para a assinatura'},
        'Não pode assinar um documento que não foi criado por si.': {
            'PTPT': 'Não pode assinar um documento que não foi criado por si.'},
        'Ocorreu um erro ao assinar': {
            'PTPT': 'Ocorreu um erro ao assinar'},
        'Assinatura invalida, o documento não foi assinado': {
            'PTPT': 'Assinatura invalida, o documento não foi assinado'},
        'Tipo de dados desconhecido': {
            'PTPT': 'Tipo de dados desconhecido'},
        'Não é possível efetuar a operação no controlo Flash.': {
            'PTPT': 'Não é possível efetuar a operação no controlo Flash.'},
        'Erro a criar a agenda.': {
            'PTPT': 'Erro a criar a agenda.'},
        'Erro a carregar o flash da agenda.': {
            'PTPT': 'Erro a carregar o flash da agenda.'},
        'Erro a carregar o flash de Agenda.': {
            'PTPT': 'Erro a carregar o flash de Agenda.'},
        'Erro a carregar o flash. ': {
            'PTPT': 'Erro a carregar o flash. '},
        'Erro a carregar o flash de Scorecard.': {
            'PTPT': 'Erro a carregar o flash de Scorecard.'},
        'Erro no flash de ferias.': {
            'PTPT': 'Erro no flash de ferias.'},
        'Erro a carregar o flash da ferias.': {
            'PTPT': 'Erro a carregar o flash da ferias.'},
        'Erro a criar a Gantt.': {
            'PTPT': 'Erro a criar a Gantt.'},
        'Erro a carregar o flash da Gantt.': {
            'PTPT': 'Erro a carregar o flash da Gantt.'},
        'Erro a carregar o flash de Gantt.': {
            'PTPT': 'Erro a carregar o flash de Gantt.'},
        'Erro no flash de Picagem.': {
            'PTPT': 'Erro no flash de Picagem.'},
        'Erro a carregar o flash de picagem.': {
            'PTPT': 'Erro a carregar o flash de picagem.'},
        'Erro a carregar o flash de Picagem.': {
            'PTPT': 'Erro a carregar o flash de Picagem.'},
        'Erro no flash de questionário.': {
            'PTPT': 'Erro no flash de questionário.'},
        'Erro a carregar o flash da questionário.': {
            'PTPT': 'Erro a carregar o flash da questionário.'},
        'Erro a carregar o flash de Questionário.': {
            'PTPT': 'Erro a carregar o flash de Questionário.'},
        'Erro a criar o IVC.': {
            'PTPT': 'Erro a criar o IVC.'},
        'Erro a carregar o flash de IVC.': {
            'PTPT': 'Erro a carregar o flash de IVC.'},
        'Erro a carregar o flash do Workflow.': {
            'PTPT': 'Erro a carregar o flash do Workflow.'},
        'Erro a carregar o flash do Workflow. ': {
            'PTPT': 'Erro a carregar o flash do Workflow. '},
        'Erro a posicionar o registo.': {
            'PTPT': 'Erro a posicionar o registo.'},
        'Erro a construir o relatorio': {
            'PTPT': 'Erro a construir o relatorio'},
        'Erro na função queryInserir': {
            'PTPT': 'Erro na função queryInserir'},
        'O código sequencial gerado para o objeto {0} é inválido': {
            'PTPT': 'O código sequencial gerado para o objeto {0} é inválido'},
        'A geração de codigos sequenciais para campos com a formatação {0} não é suportado.': {
            'PTPT': 'A geração de codigos sequenciais para campos com a formatação {0} não é suportado.'},
        'Erro no calculo do valor default': {
            'PTPT': 'Erro no calculo do valor default'},
        'Erro no calculo do valor da fórmula default': {
            'PTPT': 'Erro no calculo do valor da fórmula default'},
        'Erro no calculo do valor da fórmula sequencial': {
            'PTPT': 'Erro no calculo do valor da fórmula sequencial'},
        'Esse número sequencial ja existe, escreva outro e volte a gravar.': {
            'PTPT': 'Esse número sequencial ja existe, escreva outro e volte a gravar.'},
        'Erro na verificação do valor sequencial.': {
            'PTPT': 'Erro na verificação do valor sequencial.'},
        'Ano:': {
            'PTPT': 'Ano:'},
        'Consultar': {
            'PTPT': 'Consultar'},
        'Detalhe': {
            'PTPT': 'Detalhe'},
        'Data referência:': {
            'PTPT': 'Data referência:'},
        'Alterar Password': {
            'PTPT': 'Alterar Password'},
        'Alterar password': {
            'PTPT': 'Alterar password'},
        'Dados Enviados': {
            'PTPT': 'Dados Enviados'},
        'Identificação': {
            'PTPT': 'Identificação'},
        'Dados de Identificação': {
            'PTPT': 'Dados de Identificação'},
        'Dados para enviar': {
            'PTPT': 'Dados para enviar'},
        'Login bem sucedido': {
            'PTPT': 'Login bem sucedido'},
        'Exportar XLS': {
            'PTPT': 'Exportar XLS'},
        'Pedido Inválido.': {
            'PTPT': 'Pedido Inválido.'},
        'A tabela contém demasiadas colunas para caber numa só página PDF. O conteúdo exportado poderá estar desformatado!': {
            'PTPT': 'A tabela contém demasiadas colunas para caber numa só página PDF. O conteúdo exportado poderá estar desformatado!'},
        'Tem que permitir o uso de cookies para aceder a este portal.': {
            'PTPT': 'Tem que permitir o uso de cookies para aceder a este portal.'},
        'Erro na comunicação': {
            'PTPT': 'Erro na comunicação'},
        'O ano default não está preenchido.': {
            'PTPT': 'O ano default não está preenchido.'},
        'Preencha os campos e clique em \'Aceitar\'': {
            'PTPT': 'Preencha os campos e clique em \'Aceitar\''},
        'Ok para terminar a sessão': {
            'PTPT': 'Ok para terminar a sessão'},
        'Insira a nova password': {
            'PTPT': 'Insira a nova password'},
        'O utilizador não está autenticado.': {
            'PTPT': 'O utilizador não está autenticado.'},
        'Função não definida.': {
            'PTPT': 'Função não definida.'},
        'O certificado não está presente': {
            'PTPT': 'O certificado não está presente'},
        'Sessão Terminada': {
            'PTPT': 'Sessão Terminada'},
        'Função corretamente executada': {
            'PTPT': 'Função corretamente executada'},
        'A função invocada não existe': {
            'PTPT': 'A função invocada não existe'},
        'O utilizador não tem permissões para visualizar os dados!': {
            'PTPT': 'O utilizador não tem permissões para visualizar os dados!'},
        'Não existe registo da última linha lida!': {
            'PTPT': 'Não existe registo da última linha lida!'},
        'Sem registos': {
            'PTPT': 'Sem registos'},
        'O registo não está posicionado!': {
            'PTPT': 'O registo não está posicionado!'},
        'Inserção bem sucedida': {
            'PTPT': 'Inserção bem sucedida'},
        'Duplicação bem sucedida': {
            'PTPT': 'Duplicação bem sucedida'},
        'Preencha a Identificação': {
            'PTPT': 'Preencha a Identificação'},
        'Idioma alterado com sucesso': {
            'PTPT': 'Idioma alterado com sucesso'},
        'Não está autenticado. Preencha a Identificação': {
            'PTPT': 'Não está autenticado. Preencha a Identificação'},
        'Continuar': {
            'PTPT': 'Continuar'},
        'Seleção de uma data': {
            'PTPT': 'Seleção de uma data'},
        'Selecção entre limites': {
            'PTPT': 'Selecção entre limites'},
        'Campo': {
            'PTPT': 'Campo'},
        'Nível do Modulo': {
            'PTPT': 'Nível do Modulo'},
        'Operação - Form': {
            'PTPT': 'Operação - Form'},
        'Operação - Tabela': {
            'PTPT': 'Operação - Tabela'},
        'Criação': {
            'PTPT': 'Criação'},
        'Eliminação - Sempre': {
            'PTPT': 'Eliminação - Sempre'},
        'Eliminação - Até': {
            'PTPT': 'Eliminação - Até'},
        'Eliminação - Dia': {
            'PTPT': 'Eliminação - Dia'},
        'Eliminação - Semana': {
            'PTPT': 'Eliminação - Semana'},
        'Alteração - Sempre': {
            'PTPT': 'Alteração - Sempre'},
        'Alteração - Até': {
            'PTPT': 'Alteração - Até'},
        'Alteração - Dia': {
            'PTPT': 'Alteração - Dia'},
        'Alteração - Semana': {
            'PTPT': 'Alteração - Semana'},
        'AutoLogin': {
            'PTPT': 'AutoLogin'},
        'Módulos do nível': {
            'PTPT': 'Módulos do nível'},
        'Módulo do nível': {
            'PTPT': 'Módulo do nível'},
        'Autologin': {
            'PTPT': 'Autologin'},
        'Grupo de acesso': {
            'PTPT': 'Grupo de acesso'},
        'Gama de níveis de acesso': {
            'PTPT': 'Gama de níveis de acesso'},
        'Modulo': {
            'PTPT': 'Modulo'},
        'Nivel do Modulo': {
            'PTPT': 'Nivel do Modulo'},
        'Módulo': {
            'PTPT': 'Módulo'},
        'Niveis de Acesso': {
            'PTPT': 'Niveis de Acesso'},
        'Selecione a pasta': {
            'PTPT': 'Selecione a pasta'},
        'Scan': {
            'PTPT': 'Scan'},
        'Direitos de acesso': {
            'PTPT': 'Direitos de acesso'},
        'Opções de direitos de acesso': {
            'PTPT': 'Opções de direitos de acesso'},
        'Niveis de acesso': {
            'PTPT': 'Niveis de acesso'},
        'Grupos de acesso': {
            'PTPT': 'Grupos de acesso'},
        'cancelar': {
            'PTPT': 'cancelar'},
        'Não tem o nome do servidor indicado no INI.': {
            'PTPT': 'Não tem o nome do servidor indicado no INI.'},
        'O INI não foi inicializado corretamente.': {
            'PTPT': 'O INI não foi inicializado corretamente.'},
        'O nome do servidor tem / em vez de \\ no INI.': {
            'PTPT': 'O nome do servidor tem / em vez de \\ no INI.'},
        'Erro na passagem de tipo interno para tipo aceite para Crystal.': {
            'PTPT': 'Erro na passagem de tipo interno para tipo aceite para Crystal.'},
        'Erro na passagem de tipo interno para tipo aceite pela flash.': {
            'PTPT': 'Erro na passagem de tipo interno para tipo aceite pela flash.'},
        'Escolha...': {
            'PTPT': 'Escolha...'},
        'Não há resultados para': {
            'PTPT': 'Não há resultados para'},
        'Esta lista está vazia': {
            'PTPT': 'Esta lista está vazia'},
        'vazio': {
            'PTPT': 'vazio'},
        'Alteração bem sucedida': {
            'PTPT': 'Alteração bem sucedida'},
        'O tamanho do campo {0} excede o valor máximo permitido ({1}).': {
            'PTPT': 'O tamanho do campo {0} excede o valor máximo permitido ({1}).'},
        'O campo {0} não pode ter o valor {1} porque já existe outra ficha com o mesmo valor.': {
            'PTPT': 'O campo {0} não pode ter o valor {1} porque já existe outra ficha com o mesmo valor.'},
        'O campo {0} não pode ter o valor atual porque já existe outra ficha com o mesmo valor.': {
            'PTPT': 'O campo {0} não pode ter o valor atual porque já existe outra ficha com o mesmo valor.'},
        'O campo {0} não respeita a regra de preenchimento.': {
            'PTPT': 'O campo {0} não respeita a regra de preenchimento.'},
        'O campo {0} não respeita a condição de escrita, por isso não pode assumir o valor {1}.': {
            'PTPT': 'O campo {0} não respeita a condição de escrita, por isso não pode assumir o valor {1}.'},
        'Ocorreu um Erro - comunique ao responsável. #1': {
            'PTPT': 'Ocorreu um Erro - comunique ao responsável. #1'},
        'Ocorreu um erro, comunique ao responsável!': {
            'PTPT': 'Ocorreu um erro, comunique ao responsável!'},
        'Não Autorizado': {
            'PTPT': 'Não Autorizado'},
        'Desativado temporariamente - Offline': {
            'PTPT': 'Desativado temporariamente - Offline'},
        'Selecione uma linha': {
            'PTPT': 'Selecione uma linha'},
        'Selecione apenas uma linha': {
            'PTPT': 'Selecione apenas uma linha'},
        'Selecione um registo': {
            'PTPT': 'Selecione um registo'},
        'Modifique os dados e clique em \'Aceitar\'': {
            'PTPT': 'Modifique os dados e clique em \'Aceitar\''},
        'Clique em \'Aceitar\' para Eliminar': {
            'PTPT': 'Clique em \'Aceitar\' para Eliminar'},
        'Dados Eliminados': {
            'PTPT': 'Dados Eliminados'},
        'Dados Alterados': {
            'PTPT': 'Dados Alterados'},
        'Dados Inseridos': {
            'PTPT': 'Dados Inseridos'},
        'Clique em \'Aceitar\' para executar': {
            'PTPT': 'Clique em \'Aceitar\' para executar'},
        'Erro - Dados não gravados': {
            'PTPT': 'Erro - Dados não gravados'},
        '#1 - é de preenchimento obrigatório': {
            'PTPT': '#1 - é de preenchimento obrigatório'},
        'O campo {0} é obrigatório.': {
            'PTPT': 'O campo {0} é obrigatório.'},
        'é obrigatório': {
            'PTPT': 'é obrigatório'},
        'O comprimento máximo para o campo {0} é de {1} caracteres.': {
            'PTPT': 'O comprimento máximo para o campo {0} é de {1} caracteres.'},
        '#1 - conteúdo demasiado extenso': {
            'PTPT': '#1 - conteúdo demasiado extenso'},
        '#1 - valor inválido': {
            'PTPT': '#1 - valor inválido'},
        '#1 - valor demasiado grande': {
            'PTPT': '#1 - valor demasiado grande'},
        '#1 - data inválida': {
            'PTPT': '#1 - data inválida'},
        '#1 - hora inválida': {
            'PTPT': '#1 - hora inválida'},
        'Não é possível gravar a ficha com os valores inseridos': {
            'PTPT': 'Não é possível gravar a ficha com os valores inseridos'},
        'Existem formulários abertos em modo de edição, termine primeiro as alterações': {
            'PTPT': 'Existem formulários abertos em modo de edição, termine primeiro as alterações'},
        'Template': {
            'PTPT': 'Template'},
        'Ver todas...': {
            'PTPT': 'Ver todas...'},
        'Apagar Última...': {
            'PTPT': 'Apagar Última...'},
        'Apagar Histórico': {
            'PTPT': 'Apagar Histórico'},
        'Nome: ': {
            'PTPT': 'Nome: '},
        'Tamanho: ': {
            'PTPT': 'Tamanho: '},
        'Extensão: ': {
            'PTPT': 'Extensão: '},
        'Autor: ': {
            'PTPT': 'Autor: '},
        'Data de criação: ': {
            'PTPT': 'Data de criação: '},
        'Versão atual: ': {
            'PTPT': 'Versão atual: '},
        'Em edição por: ': {
            'PTPT': 'Em edição por: '},
        'Primeira página': {
            'PTPT': 'Primeira página'},
        'Última página': {
            'PTPT': 'Última página'},
        'Página anterior': {
            'PTPT': 'Página anterior'},
        'Ver': {
            'PTPT': 'Ver'},
        'janeiro': {
            'PTPT': 'janeiro'},
        'fevereiro': {
            'PTPT': 'fevereiro'},
        'março': {
            'PTPT': 'março'},
        'abril': {
            'PTPT': 'abril'},
        'maio': {
            'PTPT': 'maio'},
        'junho': {
            'PTPT': 'junho'},
        'julho': {
            'PTPT': 'julho'},
        'agosto': {
            'PTPT': 'agosto'},
        'setembro': {
            'PTPT': 'setembro'},
        'outubro': {
            'PTPT': 'outubro'},
        'novembro': {
            'PTPT': 'novembro'},
        'dezembro': {
            'PTPT': 'dezembro'},
        'Seleção de valores': {
            'PTPT': 'Seleção de valores'},
        'Por favor feche as paginas ativas e tente de novo': {
            'PTPT': 'Por favor feche as paginas ativas e tente de novo'},
        'Gráfico de Agenda': {
            'PTPT': 'Gráfico de Agenda'},
        'Marcação de Férias': {
            'PTPT': 'Marcação de Férias'},
        'Seleção de array': {
            'PTPT': 'Seleção de array'},
        'Alterar manualmente a password de utilizador.': {
            'PTPT': 'Alterar manualmente a password de utilizador.'},
        'Gerar automaticamente uma nova password.': {
            'PTPT': 'Gerar automaticamente uma nova password.'},
        'Gerar': {
            'PTPT': 'Gerar'},
        'Nivel de acesso': {
            'PTPT': 'Nivel de acesso'},
        'Gestão de Utilizadores': {
            'PTPT': 'Gestão de Utilizadores'},
        'Gestão': {
            'PTPT': 'Gestão'},
        'Ocorreu um erro. O ficheiro pode já ter sido apagado por um utilizador.': {
            'PTPT': 'Ocorreu um erro. O ficheiro pode já ter sido apagado por um utilizador.'},
        'Ocorreu um erro ao apagar a última versão do ficheiro. A versão pode já ter sido apagada por outro utilizador.': {
            'PTPT': 'Ocorreu um erro ao apagar a última versão do ficheiro. A versão pode já ter sido apagada por outro utilizador.'},
        'Ocorreu um erro ao apagar o historial. O historial pode já ter sido apagado por outro utilizador.': {
            'PTPT': 'Ocorreu um erro ao apagar o historial. O historial pode já ter sido apagado por outro utilizador.'},
        'Ocorreu um erro na submissão do ficheiro, tente novamente.': {
            'PTPT': 'Ocorreu um erro na submissão do ficheiro, tente novamente.'},
        'O ficheiro já foi apagado!': {
            'PTPT': 'O ficheiro já foi apagado!'},
        'Ocorreu um erro a aceder ao relatório pretendido.': {
            'PTPT': 'Ocorreu um erro a aceder ao relatório pretendido.'},
        'Ocorreu um erro a aceder ao conteúdo pretendido.': {
            'PTPT': 'Ocorreu um erro a aceder ao conteúdo pretendido.'},
        'Se o problema persistir por favor contacte o administrador do sistema.': {
            'PTPT': 'Se o problema persistir por favor contacte o administrador do sistema.'},
        'A última versão vai ser eliminada.\nTem a certeza que quer apagar?': {
            'PTPT': 'A última versão vai ser eliminada.\nTem a certeza que quer apagar?'},
        'Todas as versões exceto a última vão ser apagadas.\nTem a certeza que quer apagar?': {
            'PTPT': 'Todas as versões exceto a última vão ser apagadas.\nTem a certeza que quer apagar?'},
        'Tem a certeza que quer revogar esta delegação de acesso?': {
            'PTPT': 'Tem a certeza que quer revogar esta delegação de acesso?'},
        'Verifique que tenha a biblioteca CAPICOM instalada e que os certificados se encontram registados': {
            'PTPT': 'Verifique que tenha a biblioteca CAPICOM instalada e que os certificados se encontram registados'},
        'Por enquanto as assinaturas digitais só são oficialmente suportadas no Internet Explorer ou no Mozilla Firefox com a extensão do o IE tab. A assinatura pode falhar com o seu Browser. Deseja tentar na mesma?': {
            'PTPT': 'Por enquanto as assinaturas digitais só são oficialmente suportadas no Internet Explorer ou no Mozilla Firefox com a extensão do o IE tab. A assinatura pode falhar com o seu Browser. Deseja tentar na mesma?'},
        'Log In | Registo': {
            'PTPT': 'Log In | Registo'},
        'Fechar Painel': {
            'PTPT': 'Fechar Painel'},
        'Bem-vindo ao sistema Quidgest Balanced ScoreCard': {
            'PTPT': 'Bem-vindo ao sistema Quidgest Balanced ScoreCard'},
        'Área de Autenticação': {
            'PTPT': 'Área de Autenticação'},
        'Para se autenticar insira o seu nome de utilizador e a sua palavra-chave!': {
            'PTPT': 'Para se autenticar insira o seu nome de utilizador e a sua palavra-chave!'},
        'Para mais informações visite o nosso': {
            'PTPT': 'Para mais informações visite o nosso'},
        'site': {
            'PTPT': 'site'},
        'Atenção que pode perder dados, pretende mesmo fechar a janela?': {
            'PTPT': 'Atenção que pode perder dados, pretende mesmo fechar a janela?'},
        'Escolha os widgets que pretende que sejam mostrados!': {
            'PTPT': 'Escolha os widgets que pretende que sejam mostrados!'},
        'Pretende gerar dados para todos os mapas estratégicos?': {
            'PTPT': 'Pretende gerar dados para todos os mapas estratégicos?'},
        'Geração de dados': {
            'PTPT': 'Geração de dados'},
        'Selecionar Ativos': {
            'PTPT': 'Selecionar Ativos'},
        'Selecionar Inativos': {
            'PTPT': 'Selecionar Inativos'},
        'Selecionar Futuros': {
            'PTPT': 'Selecionar Futuros'},
        'Data de referência para as seleções': {
            'PTPT': 'Data de referência para as seleções'},
        'Criar': {
            'PTPT': 'Criar'},
        'Total de registos: ': {
            'PTPT': 'Total de registos: '},
        'Ative o JavaScript para poder usar o carregador de ficheiros.': {
            'PTPT': 'Ative o JavaScript para poder usar o carregador de ficheiros.'},
        'Utilize o formulário abaixo para mudar a sua password.': {
            'PTPT': 'Utilize o formulário abaixo para mudar a sua password.'},
        'Novas passwords necessitam de ter um mínimo de': {
            'PTPT': 'Novas passwords necessitam de ter um mínimo de'},
        'carateres em comprimento': {
            'PTPT': 'carateres em comprimento'},
        'A mudança de password falhou. Por favor corrija os erros e tente de novo': {
            'PTPT': 'A mudança de password falhou. Por favor corrija os erros e tente de novo'},
        'Informações de conta': {
            'PTPT': 'Informações de conta'},
        'A sua password foi alterada com sucesso.': {
            'PTPT': 'A sua password foi alterada com sucesso.'},
        'Crie uma nova conta': {
            'PTPT': 'Crie uma nova conta'},
        'Utilize o formulário abaixo para criar uma nova conta': {
            'PTPT': 'Utilize o formulário abaixo para criar uma nova conta'},
        'A criação da conta falhou. Por favor corrija os erros e tente de novo.': {
            'PTPT': 'A criação da conta falhou. Por favor corrija os erros e tente de novo.'},
        'Base de dados': {
            'PTPT': 'Base de dados'},
        'Não está disponível nenhuma diretoria de upgrade. Por favor atualize a diretoria': {
            'PTPT': 'Não está disponível nenhuma diretoria de upgrade. Por favor atualize a diretoria'},
        'do website.': {
            'PTPT': 'do website.'},
        'Criar backup da base de dados': {
            'PTPT': 'Criar backup da base de dados'},
        'Restaurar base de dados': {
            'PTPT': 'Restaurar base de dados'},
        'Consultar e criar database seed': {
            'PTPT': 'Consultar e criar database seed'},
        'Voltar': {
            'PTPT': 'Voltar'},
        'Sobre': {
            'PTPT': 'Sobre'},
        'Inserir aqui conteúdo': {
            'PTPT': 'Inserir aqui conteúdo'},
        'Filtros': {
            'PTPT': 'Filtros'},
        'Filtro inativo': {
            'PTPT': 'Filtro inativo'},
        'Resultados de pesquisa:': {
            'PTPT': 'Resultados de pesquisa:'},
        'resultados encontrados': {
            'PTPT': 'resultados encontrados'},
        'Cargos': {
            'PTPT': 'Cargos'},
        'Nome do cargo': {
            'PTPT': 'Nome do cargo'},
        'Voltar à lista': {
            'PTPT': 'Voltar à lista'},
        'Módulos': {
            'PTPT': 'Módulos'},
        'Pedimos desculpa, ocorreu um erro ao processar o seu pedido.': {
            'PTPT': 'Pedimos desculpa, ocorreu um erro ao processar o seu pedido.'},
        'Formula unavailable due to missing function implementation.': {
            'PTPT': 'Fórmula indisponível devido a uma função não implementada.'},
        'Criar novo': {
            'PTPT': 'Criar novo'},
        'Nome de utilizador': {
            'PTPT': 'Nome de utilizador'},
        'Comentário': {
            'PTPT': 'Comentário'},
        'Aprovado?': {
            'PTPT': 'Aprovado?'},
        'Último login': {
            'PTPT': 'Último login'},
        'Última mudança de password': {
            'PTPT': 'Última mudança de password'},
        'Adicionar cargo': {
            'PTPT': 'Adicionar cargo'},
        'Nenhum': {
            'PTPT': 'Nenhum'},
        'Dados do utilizador': {
            'PTPT': 'Dados do utilizador'},
        'Ir para a aplicação': {
            'PTPT': 'Ir para a aplicação'},
        'Ocorreram alterações à ficha que está a editar. As alterações efectuadas serão descartas.': {
            'PTPT': 'Ocorreram alterações à ficha que está a editar. As alterações efectuadas serão descartas.'},
        'Password:': {
            'PTPT': 'Password:'},
        'Função mal definida.': {
            'PTPT': 'Função mal definida.'},
        'Identificação:': {
            'PTPT': 'Identificação:'},
        'Palavra passe:': {
            'PTPT': 'Palavra passe:'},
        'Ocorreu um erro ao apagar o historial. O historial pode já ter sido apagado por outro utilizador': {
            'PTPT': 'Ocorreu um erro ao apagar o historial. O historial pode já ter sido apagado por outro utilizador'},
        'página anterior': {
            'PTPT': 'página anterior'},
        'página seguinte': {
            'PTPT': 'página seguinte'},
        'Seleção entre limites': {
            'PTPT': 'Seleção entre limites'},
        '&Selecionar': {
            'PTPT': '&Selecionar'},
        '&Cancelar': {
            'PTPT': '&Cancelar'},
        '&Alterar': {
            'PTPT': '&Alterar'},
        '&Inserir': {
            'PTPT': '&Inserir'},
        '&Duplicar': {
            'PTPT': '&Duplicar'},
        '&Eliminar': {
            'PTPT': '&Eliminar'},
        'C&ontinuar': {
            'PTPT': 'C&ontinuar'},
        'De&smarcar': {
            'PTPT': 'De&smarcar'},
        'Im&primir': {
            'PTPT': 'Im&primir'},
        'Seleção de uma Data': {
            'PTPT': 'Seleção de uma Data'},
        'Seleção entre Limites': {
            'PTPT': 'Seleção entre Limites'},
        'Rotinas de &Apoio': {
            'PTPT': 'Rotinas de &Apoio'},
        'Sobre o &Programa...': {
            'PTPT': 'Sobre o &Programa...'},
        '&Utilizador': {
            'PTPT': '&Utilizador'},
        'Palavra-&chave...': {
            'PTPT': 'Palavra-&chave...'},
        'Pr&opriedades...': {
            'PTPT': 'Pr&opriedades...'},
        'Configurar a &Impressora...': {
            'PTPT': 'Configurar a &Impressora...'},
        '&Administração': {
            'PTPT': '&Administração'},
        '&Utilizadores...': {
            'PTPT': '&Utilizadores...'},
        '&Reindexar a BD': {
            'PTPT': '&Reindexar a BD'},
        'E&xportação de MQ': {
            'PTPT': 'E&xportação de MQ'},
        'I&mportação de MQ': {
            'PTPT': 'I&mportação de MQ'},
        'Bac&kup da BD...': {
            'PTPT': 'Bac&kup da BD...'},
        '&Tipo de Alerta (Grupo)...': {
            'PTPT': '&Tipo de Alerta (Grupo)...'},
        'T&ipo de Alerta (Util)...': {
            'PTPT': 'T&ipo de Alerta (Util)...'},
        '&Direitos de Acesso': {
            'PTPT': '&Direitos de Acesso'},
        '&Níveis de Acesso': {
            'PTPT': '&Níveis de Acesso'},
        '&Grupos de Acesso': {
            'PTPT': '&Grupos de Acesso'},
        '&Sair': {
            'PTPT': '&Sair'},
        '&Procurar': {
            'PTPT': '&Procurar'},
        '&Outra vez': {
            'PTPT': '&Outra vez'},
        'Imp&rimir': {
            'PTPT': 'Imp&rimir'},
        '&Apagar': {
            'PTPT': '&Apagar'},
        'C&olar': {
            'PTPT': 'C&olar'},
        '&Exportar': {
            'PTPT': '&Exportar'},
        '&Fonte': {
            'PTPT': '&Fonte'},
        '&Negrito': {
            'PTPT': '&Negrito'},
        '&Itálico': {
            'PTPT': '&Itálico'},
        '&Sublinhado': {
            'PTPT': '&Sublinhado'},
        '&Outros...': {
            'PTPT': '&Outros...'},
        '&Esquerda': {
            'PTPT': '&Esquerda'},
        '&Direita': {
            'PTPT': '&Direita'},
        'E&scudos': {
            'PTPT': 'E&scudos'},
        'A&lterar': {
            'PTPT': 'A&lterar'},
        'E&ntrar automaticamente nesta máquina e com este utilizador': {
            'PTPT': 'E&ntrar automaticamente nesta máquina e com este utilizador'},
        'Mostrar &riscas coloridas nas listagens': {
            'PTPT': 'Mostrar &riscas coloridas nas listagens'},
        'Mostrar &icon de ordenamento nas listagens': {
            'PTPT': 'Mostrar &icon de ordenamento nas listagens'},
        '&Utilizador:': {
            'PTPT': '&Utilizador:'},
        '&Palavra-chave:': {
            'PTPT': '&Palavra-chave:'},
        '&Aceitar': {
            'PTPT': '&Aceitar'},
        '&Próprio': {
            'PTPT': '&Próprio'},
        '&Outro': {
            'PTPT': '&Outro'},
        '&Escolher': {
            'PTPT': '&Escolher'},
        '&Voltar ao programa': {
            'PTPT': '&Voltar ao programa'},
        '&Apenas os selecionados': {
            'PTPT': '&Apenas os selecionados'},
        '&Primeiro': {
            'PTPT': '&Primeiro'},
        'P&arar no primeiro caminho incoerente (para cada relação)': {
            'PTPT': 'P&arar no primeiro caminho incoerente (para cada relação)'},
        'Pa&rar ao quinto erro (para cada caminho)': {
            'PTPT': 'Pa&rar ao quinto erro (para cada caminho)'},
        'Guardar queries em &ficheiro': {
            'PTPT': 'Guardar queries em &ficheiro'},
        '&Progresso': {
            'PTPT': '&Progresso'},
        '&Backup': {
            'PTPT': '&Backup'},
        '&Guardar': {
            'PTPT': '&Guardar'},
        '&Imprimir': {
            'PTPT': '&Imprimir'},
        '&Lista': {
            'PTPT': '&Lista'},
        '&Assunto:': {
            'PTPT': '&Assunto:'},
        '&Enviar': {
            'PTPT': '&Enviar'},
        '&Fechar': {
            'PTPT': '&Fechar'},
        '&Conf Impressora': {
            'PTPT': '&Conf Impressora'},
        '&Queue': {
            'PTPT': '&Queue'},
        '&Gravar': {
            'PTPT': '&Gravar'},
        '&Tabela': {
            'PTPT': '&Tabela'},
        '&Código Interno': {
            'PTPT': '&Código Interno'},
        '&Conteudo': {
            'PTPT': '&Conteudo'},
        '&Última Alteração': {
            'PTPT': '&Última Alteração'},
        '&Activo?': {
            'PTPT': '&Activo?'},
        'Data d&e Resolução': {
            'PTPT': 'Data d&e Resolução'},
        'Me&nu': {
            'PTPT': 'Me&nu'},
        'Ema&il?': {
            'PTPT': 'Ema&il?'},
        'Emai&l Enviado?': {
            'PTPT': 'Emai&l Enviado?'},
        'N&ome do Grupo de utilizadores': {
            'PTPT': 'N&ome do Grupo de utilizadores'},
        'T&ipo de Alerta': {
            'PTPT': 'T&ipo de Alerta'},
        '&Data de início': {
            'PTPT': '&Data de início'},
        'D&ata limite': {
            'PTPT': 'D&ata limite'},
        '&Id para auditoria': {
            'PTPT': '&Id para auditoria'},
        '&Revogada?': {
            'PTPT': '&Revogada?'},
        'Criad&o em:': {
            'PTPT': 'Criad&o em:'},
        'Criado &por:': {
            'PTPT': 'Criado &por:'},
        'Mudado &em:': {
            'PTPT': 'Mudado &em:'},
        '&Abrir': {
            'PTPT': '&Abrir'},
        '&Eli. &Histórico': {
            'PTPT': '&Eli. &Histórico'},
        '&Ok': {
            'PTPT': '&Ok'},
        '&Depois': {
            'PTPT': '&Depois'},
        'C&rescente': {
            'PTPT': 'C&rescente'},
        'Decrescen&te': {
            'PTPT': 'Decrescen&te'},
        '&Somatório': {
            'PTPT': '&Somatório'},
        'Gra&var': {
            'PTPT': 'Gra&var'},
        'Utilizad&or:': {
            'PTPT': 'Utilizad&or:'},
        'A&lterar a palavra-chave': {
            'PTPT': 'A&lterar a palavra-chave'},
        'Palavra-&chave:': {
            'PTPT': 'Palavra-&chave:'},
        '&Nível:': {
            'PTPT': '&Nível:'},
        '&Confirmar:': {
            'PTPT': '&Confirmar:'},
        '&Perfil Utilizador': {
            'PTPT': '&Perfil Utilizador'},
        '&Autorização': {
            'PTPT': '&Autorização'},
        'P&recisa de Validação?': {
            'PTPT': 'P&recisa de Validação?'},
        'Prec&isa de Comprovativo?': {
            'PTPT': 'Prec&isa de Comprovativo?'},
        'Me&nsagem 1': {
            'PTPT': 'Me&nsagem 1'},
        'Men&sagem 2': {
            'PTPT': 'Men&sagem 2'},
        '&Nivel': {
            'PTPT': '&Nivel'},
        '&AutoLogin': {
            'PTPT': '&AutoLogin'},
        '&Módulos do nível': {
            'PTPT': '&Módulos do nível'},
        '&Autologin': {
            'PTPT': '&Autologin'},
        '&Grupo': {
            'PTPT': '&Grupo'},
        'G&ama de níveis de acesso': {
            'PTPT': 'G&ama de níveis de acesso'},
        '&Tipo': {
            'PTPT': '&Tipo'},
        '&Operação - Tabela': {
            'PTPT': '&Operação - Tabela'},
        'O&peração - Form': {
            'PTPT': 'O&peração - Form'},
        '&Modulo': {
            'PTPT': '&Modulo'},
        '&Nivel do Modulo': {
            'PTPT': '&Nivel do Modulo'},
        'D&escrição': {
            'PTPT': 'D&escrição'},
        '&Nota': {
            'PTPT': '&Nota'},
        '&Validade': {
            'PTPT': '&Validade'},
        '&Workflow': {
            'PTPT': '&Workflow'},
        'Finalizar documento?\r\nSelecionar \'não\' para adicionar mais páginas.': {
            'PTPT': 'Finalizar documento?\r\nSelecionar \'não\' para adicionar mais páginas.'},
        'Delegação': {
            'PTPT': 'Delegação'},
        'Logon': {
            'PTPT': 'Logon'},
        'Logoff': {
            'PTPT': 'Logoff'},
        'Falha na criação de conta. Por favor corrija os erros e tente de novo.': {
            'PTPT': 'Falha na criação de conta. Por favor corrija os erros e tente de novo.'},
        'Selecione uma opção': {
            'PTPT': 'Selecione uma opção'},
        'Sobre nós': {
            'PTPT': 'Sobre nós'},
        'Listagem': {
            'PTPT': 'Listagem'},
        'Ficheiro de ajuda não encontrado.': {
            'PTPT': 'Ficheiro de ajuda não encontrado.'},
        'Personalizar Barra de Ferramentas de Acesso Rápido': {
            'PTPT': 'Personalizar Barra de Ferramentas de Acesso Rápido'},
        'Mais Comandos...': {
            'PTPT': 'Mais Comandos...'},
        'Mostrar Abaixo do Friso': {
            'PTPT': 'Mostrar Abaixo do Friso'},
        'Minimizar o Friso': {
            'PTPT': 'Minimizar o Friso'},
        'Adicionar à Barra de Ferramentas de Acesso Rápido': {
            'PTPT': 'Adicionar à Barra de Ferramentas de Acesso Rápido'},
        'Personalizar Barra de Ferramentas de Acesso Rápido...': {
            'PTPT': 'Personalizar Barra de Ferramentas de Acesso Rápido...'},
        'Mostrar Barra de Ferramentas de Acesso Rápido Abaixo do Friso': {
            'PTPT': 'Mostrar Barra de Ferramentas de Acesso Rápido Abaixo do Friso'},
        'Template inexistente.': {
            'PTPT': 'Template inexistente.'},
        'Remover': {
            'PTPT': 'Remover'},
        '&Ativo?': {
            'PTPT': '&Ativo?'},
        '&Reset': {
            'PTPT': '&Reset'},
        'Repor': {
            'PTPT': 'Repor'},
        'Erro a carregar o flash do MAPGEO.': {
            'PTPT': 'Erro a carregar o flash do MAPGEO.'},
        'Erro a carregar o flash de MAPGEO.': {
            'PTPT': 'Erro a carregar o flash de MAPGEO.'},
        'Por selecionar': {
            'PTPT': 'Por selecionar'},
        'Selecionados': {
            'PTPT': 'Selecionados'},
        'Gestão de configurações': {
            'PTPT': 'Gestão de configurações'},
        'Linha': {
            'PTPT': 'Linha'},
        'Estado Linha': {
            'PTPT': 'Estado Linha'},
        'Chamada': {
            'PTPT': 'Chamada'},
        'Estado Chamada': {
            'PTPT': 'Estado Chamada'},
        'Conexão': {
            'PTPT': 'Conexão'},
        'Por favor indique um email válido ou a password irá ficar perdida e terá de ser re-gerada.': {
            'PTPT': 'Por favor indique um email válido ou a password irá ficar perdida e terá de ser re-gerada.'},
        'Geração de Password': {
            'PTPT': 'Geração de Password'},
        'Alteração de Password': {
            'PTPT': 'Alteração de Password'},
        'Password Antiga:': {
            'PTPT': 'Password Antiga:'},
        'Password Nova:': {
            'PTPT': 'Password Nova:'},
        'Confirmar Password:': {
            'PTPT': 'Confirmar Password:'},
        'A password deve ter um máximo de 9 caracteres': {
            'PTPT': 'A password deve ter um máximo de 9 caracteres'},
        'O utilizador não tem o EPH definido': {
            'PTPT': 'O utilizador não tem o EPH definido'},
        'Procurar em': {
            'PTPT': 'Procurar em'},
        'Outras áreas': {
            'PTPT': 'Outras áreas'},
        'Título': {
            'PTPT': 'Título'},
        'Descarregar': {
            'PTPT': 'Descarregar'},
        'Ficheiro não encontrado': {
            'PTPT': 'Ficheiro não encontrado'},
        'Im&portação de MQ (individual)': {
            'PTPT': 'Im&portação de MQ (individual)'},
        'Importação de Messages Queues (individual)': {
            'PTPT': 'Importação de Messages Queues (individual)'},
        'O campo {0} ({1}.{2}) é obrigatório e não está preenchido': {
            'PTPT': 'O campo {0} ({1}.{2}) é obrigatório e não está preenchido'},
        'Relatório impresso com sucesso.': {
            'PTPT': 'Relatório impresso com sucesso.'},
        'Registo criado com sucesso.': {
            'PTPT': 'Registo criado com sucesso.'},
        'Erro ao apagar o registo.': {
            'PTPT': 'Erro ao apagar o registo.'},
        'Registo apagado com sucesso.': {
            'PTPT': 'Registo apagado com sucesso.'},
        'Erro ao guardar o registo.': {
            'PTPT': 'Erro ao guardar o registo.'},
        'Alterações efetuadas com sucesso.': {
            'PTPT': 'Alterações efetuadas com sucesso.'},
        'Tem a certeza que deseja cancelar o processo?': {
            'PTPT': 'Tem a certeza que deseja cancelar o processo?'},
        'Reconstruir index de tabelas': {
            'PTPT': 'Reconstruir index de tabelas'},
        'Pesquisar': {
            'PTPT': 'Pesquisar'},
        'Configuração do Sistema': {
            'PTPT': 'Configuração do Sistema'},
        'Configuração da Aplicação': {
            'PTPT': 'Configuração da Aplicação'},
        'Procure para mais resultados': {
            'PTPT': 'Procure para mais resultados'},
        'Submissão de ficheiros': {
            'PTPT': 'Submissão de ficheiros'},
        'Seleccione o ficheiro a submeter:': {
            'PTPT': 'Seleccione o ficheiro a submeter:'},
        'Nenhum ficheiro seleccionado para submissão.': {
            'PTPT': 'Nenhum ficheiro seleccionado para submissão.'},
        'Ficheiro eliminado com sucesso.': {
            'PTPT': 'Ficheiro eliminado com sucesso.'},
        'O valor mínimo do limite não pode ser vazio.': {
            'PTPT': 'O valor mínimo do limite não pode ser vazio.'},
        'O valor máximo do limite não pode ser vazio.': {
            'PTPT': 'O valor máximo do limite não pode ser vazio.'},
        'Pesquisa avançada': {
            'PTPT': 'Pesquisa avançada'},
        'Pesquisa simples': {
            'PTPT': 'Pesquisa simples'},
        'Exportar Excel': {
            'PTPT': 'Exportar Excel'},
        'A carregar...': {
            'PTPT': 'A carregar...'},
        'A carregar o formulário...': {
            'PTPT': 'A carregar o formulário...'},
        '<a href="%url%">A imagem</a> não pôde ser carregada.': {
            'PTPT': '<a href="%url%">A imagem</a> não pôde ser carregada.'},
        'Não tem permissões para criar o registo.': {
            'PTPT': 'Não tem permissões para criar o registo.'},
        'Seleccionado': {
            'PTPT': 'Seleccionado'},
        'Outras opções': {
            'PTPT': 'Outras opções'},
        'Não foram definidas queries manuais correspondentes às tags dos templates.': {
            'PTPT': 'Não foram definidas queries manuais correspondentes às tags dos templates.'},
        'Valores separados por vírgula (CSV)': {
            'PTPT': 'Valores separados por vírgula (CSV)'},
        'Formato XML (XML)': {
            'PTPT': 'Formato XML (XML)'},
        'Formato de documento portátil (PDF)': {
            'PTPT': 'Formato de documento portátil (PDF)'},
        'Folha de cálculo Excel (XLSX)': {
            'PTPT': 'Folha de cálculo Excel (XLSX)'},
        'Download de Template Excel': {
            'PTPT': 'Download de Template Excel'},
        'Ficheiro com cabeçalho incorrecto': {
            'PTPT': 'Ficheiro com cabeçalho incorrecto'},
        'Ficheiro com dados em formato incorreto': {
            'PTPT': 'Ficheiro com dados em formato incorreto'},
        'Ficheiro importado com sucesso.': {
            'PTPT': 'Ficheiro importado com sucesso.'},
        '{0} Linhas importadas': {
            'PTPT': '{0} Linhas importadas'},
        'Folha de cálculo (ODS)': {
            'PTPT': 'Folha de cálculo (ODS)'},
        'Extensão inválida! Extensões permitidas:': {
            'PTPT': 'Extensão inválida! Extensões permitidas:'},
        'Ficheiro demasiado grande, o tamanho máximo é': {
            'PTPT': 'Ficheiro demasiado grande, o tamanho máximo é'},
        'Ficheiro vazio': {
            'PTPT': 'Ficheiro vazio'},
        'Nome do ficheiro ou o caminho completo de gravação muito extenso': {
            'PTPT': 'Nome do ficheiro ou o caminho completo de gravação muito extenso'},
        'Ocorreu um erro ao salvar o workflow.': {
            'PTPT': 'Ocorreu um erro ao salvar o workflow.'},
        'O evento não está definido.': {
            'PTPT': 'O evento não está definido.'},
        'O nome de utilizador já está autenticado noutro dispositivo.': {
            'PTPT': 'O nome de utilizador já está autenticado noutro dispositivo.'},
        'O nome de utilizador já está autenticado.': {
            'PTPT': 'O nome de utilizador já está autenticado.'},
        'Ações coletivas': {
            'PTPT': 'Ações coletivas'},
        'Todos registos selecionados': {
            'PTPT': 'Todos registos selecionados'},
        'registo(s) selecionado(s)': {
            'PTPT': 'registo(s) selecionado(s)'},
        'Não pode alterar a palavra-passe de outro utilizador': {
            'PTPT': 'Não pode alterar a palavra-passe de outro utilizador'},
        'O registo pedido não foi encontrado.': {
            'PTPT': 'O registo pedido não foi encontrado.'},
        'O certificado indicado não se encontra válido.': {
            'PTPT': 'O certificado indicado não se encontra válido.'},
        'Não foi encontrado nenhum certificado de cliente.': {
            'PTPT': 'Não foi encontrado nenhum certificado de cliente.'},
        'Não foi possível registar o certificado: ': {
            'PTPT': 'Não foi possível registar o certificado: '},
        'Registar certificado': {
            'PTPT': 'Registar certificado'},
        'Para registar o seu certificado, insira o seu nome de utilizador e a sua palavra-chave': {
            'PTPT': 'Para registar o seu certificado, insira o seu nome de utilizador e a sua palavra-chave'},
        'Ajuda - Cartão Cidadão': {
            'PTPT': 'Ajuda - Cartão Cidadão'},
        'Forgot password?': {
            'PTPT': 'Esqueceu a password?'},
        'Processo': {
            'PTPT': 'Processo'},
        'Definição': {
            'PTPT': 'Definição'},
        'Realizado por:': {
            'PTPT': 'Realizado por:'},
        'Realizado em:': {
            'PTPT': 'Realizado em:'},
        'Próxima execução em:': {
            'PTPT': 'Próxima execução em:'},
        'Ignorado': {
            'PTPT': 'Ignorado'},
        'Lista de processos': {
            'PTPT': 'Lista de processos'},
        'Visualizar estado dos processos': {
            'PTPT': 'Visualizar estado dos processos'},
        'Escolha um processo disponível neste módulo': {
            'PTPT': 'Escolha um processo disponível neste módulo'},
        'Terminar Sessão': {
            'PTPT': 'Terminar Sessão'},
        'Iniciar Sessão': {
            'PTPT': 'Iniciar Sessão'},
        'Endereço inválido!': {
            'PTPT': 'Endereço inválido!'},
        'Reordenar': {
            'PTPT': 'Reordenar'},
        'Bloquear': {
            'PTPT': 'Bloquear'},
        'Ou': {
            'PTPT': 'Ou'},
        'Repetição da Password Nova:': {
            'PTPT': 'Repetição da Password Nova:'},
        'Auditoria do Sistema': {
            'PTPT': 'Auditoria do Sistema'},
        'Bem-vindo ao módulo de administração': {
            'PTPT': 'Bem-vindo ao módulo de administração'},
        'Esta página permite-lhe configurar e manter a sua solução web Quidgest.': {
            'PTPT': 'Esta página permite-lhe configurar e manter a sua solução web Quidgest.'},
        'Existem as seguintes opções:': {
            'PTPT': 'Existem as seguintes opções:'},
        'Nesta área poderá atualizar a versão do schema, executar scripts de manutenção e outras operações relacionadas com a base de dados. Para executar corretamente qualquer operação, assegure-se primeiro de que a configuração do sistema está corretamente realizada.': {
            'PTPT': 'Nesta área poderá atualizar a versão do schema, executar scripts de manutenção e outras operações relacionadas com a base de dados. Para executar corretamente qualquer operação, assegure-se primeiro de que a configuração do sistema está corretamente realizada.'},
        'Aqui poderá realizar as configurações básicas de base de dados para a sua solução web Quidgest.': {
            'PTPT': 'Aqui poderá realizar as configurações básicas de base de dados para a sua solução web Quidgest.'},
        'Aqui poderá visualizar todas as alterações efetuadas no sistema pelos seus utilizadores.': {
            'PTPT': 'Aqui poderá visualizar todas as alterações efetuadas no sistema pelos seus utilizadores.'},
        'Opções avançadas de manutenção': {
            'PTPT': 'Opções avançadas de manutenção'},
        'Executar tarefas de manutenção': {
            'PTPT': 'Executar tarefas de manutenção'},
        'Restaurar': {
            'PTPT': 'Restaurar'},
        'Mostrar log de operações': {
            'PTPT': 'Mostrar log de operações'},
        'Nome do servidor e instância nomeada, se existir. ex.\'SRV\\SQL2008\'': {
            'PTPT': 'Nome do servidor e instância nomeada, se existir. ex.\'SRV\\SQL2008\''},
        'Número da porta do serviço de base de dados': {
            'PTPT': 'Número da porta do serviço de base de dados'},
        'Nome do serviço': {
            'PTPT': 'Nome do serviço'},
        'Identificador do serviço': {
            'PTPT': 'Identificador do serviço'},
        '[Sistema][Ano] e.g.\'SYSDIV2014\' ou utilizar customizado \'MyDB\'': {
            'PTPT': '[Sistema][Ano] e.g.\'SYSDIV2014\' ou utilizar customizado \'MyDB\''},
        'Especificar ano ou 0': {
            'PTPT': 'Especificar ano ou 0'},
        'Login de acesso à base de dados': {
            'PTPT': 'Login de acesso à base de dados'},
        'Gravar configuração': {
            'PTPT': 'Gravar configuração'},
        'Chave primária': {
            'PTPT': 'Chave primária'},
        'Valor': {
            'PTPT': 'Valor'},
        'Nome do servidor de base de dados': {
            'PTPT': 'Nome do servidor de base de dados'},
        'Nome do servidor': {
            'PTPT': 'Nome do servidor'},
        'Nome da Base de Dados': {
            'PTPT': 'Nome da Base de Dados'},
        'Porta': {
            'PTPT': 'Porta'},
        'Serviço (ORACLE)': {
            'PTPT': 'Serviço (ORACLE)'},
        'Tipo de servidor de base de dados': {
            'PTPT': 'Tipo de servidor de base de dados'},
        'Ano por omissão': {
            'PTPT': 'Ano por omissão'},
        'Ocultar anos': {
            'PTPT': 'Ocultar anos'},
        'Confirmar palavra passe': {
            'PTPT': 'Confirmar palavra passe'},
        'Estado da operação': {
            'PTPT': 'Estado da operação'},
        'Versão do schema': {
            'PTPT': 'Versão do schema'},
        'Versão da aplicação': {
            'PTPT': 'Versão da aplicação'},
        'Versão dos scripts': {
            'PTPT': 'Versão dos scripts'},
        'Atualização disponível': {
            'PTPT': 'Atualização disponível'},
        'Bases de dados disponíveis': {
            'PTPT': 'Bases de dados disponíveis'},
        'Base de dados selecionada': {
            'PTPT': 'Base de dados selecionada'},
        'Diretoria de FileStream': {
            'PTPT': 'Diretoria de FileStream'},
        'Ficheiro de configuração inválido! Por favor, execute primeiro a configuração do sistema.': {
            'PTPT': 'Ficheiro de configuração inválido! Por favor, execute primeiro a configuração do sistema.'},
        'Alguns campos estão vazios ou têm um valor inválido.': {
            'PTPT': 'Alguns campos estão vazios ou têm um valor inválido.'},
        'A versão dos ficheiros de reindexação é mais recente que a versão da aplicação! Por favor, atualize a sua aplicação.': {
            'PTPT': 'A versão dos ficheiros de reindexação é mais recente que a versão da aplicação! Por favor, atualize a sua aplicação.'},
        'A versão dos ficheiros de reindexação é mais antiga que a versão da aplicação! Por favor, atualize os ficheiros de reindexação.': {
            'PTPT': 'A versão dos ficheiros de reindexação é mais antiga que a versão da aplicação! Por favor, atualize os ficheiros de reindexação.'},
        '{0} não existe! A atualização da base de dados não poderá ser realizada enquanto os scripts de reindexação não estiverem instalados.': {
            'PTPT': '{0} não existe! A atualização da base de dados não poderá ser realizada enquanto os scripts de reindexação não estiverem instalados.'},
        'A operação foi concluída com sucesso!': {
            'PTPT': 'A operação foi concluída com sucesso!'},
        'Backup da base de dados criado com sucesso com o nome \'{0}\'.': {
            'PTPT': 'Backup da base de dados criado com sucesso com o nome \'{0}\'.'},
        'Nenhum ficheiro de backup de base de dados foi seleccionado!': {
            'PTPT': 'Nenhum ficheiro de backup de base de dados foi seleccionado!'},
        'Base de dados restaurada com sucesso!': {
            'PTPT': 'Base de dados restaurada com sucesso!'},
        'Ficheiro de configuração guardado.': {
            'PTPT': 'Ficheiro de configuração guardado.'},
        'A processar...': {
            'PTPT': 'A processar...'},
        'Mostrar _MENU_ registos': {
            'PTPT': 'Mostrar _MENU_ registos'},
        'Não foram encontrados resultados': {
            'PTPT': 'Não foram encontrados resultados'},
        'Mostrando de _START_ até _END_ de _TOTAL_ registos': {
            'PTPT': 'Mostrando de _START_ até _END_ de _TOTAL_ registos'},
        'Mostrando de 0 até 0 de 0 registos': {
            'PTPT': 'Mostrando de 0 até 0 de 0 registos'},
        '(filtrado de _MAX_ registos no total)': {
            'PTPT': '(filtrado de _MAX_ registos no total)'},
        'Procurar:': {
            'PTPT': 'Procurar:'},
        'Último': {
            'PTPT': 'Último'},
        'Ocorreram erros na criação do documento. Verifique por favor se o documento template está danificado ou em edição.': {
            'PTPT': 'Ocorreram erros na criação do documento. Verifique por favor se o documento template está danificado ou em edição.'},
        'Tag não inicializada!': {
            'PTPT': 'Tag não inicializada!'},
        'Selecione a tabela a visualizar:': {
            'PTPT': 'Selecione a tabela a visualizar:'},
        'Valores currentes:': {
            'PTPT': 'Valores currentes:'},
        'Valores anteriores:': {
            'PTPT': 'Valores anteriores:'},
        'eliminado': {
            'PTPT': 'eliminado'},
        'Erro durante o backup': {
            'PTPT': 'Erro durante o backup'},
        'Erro durante o restauro': {
            'PTPT': 'Erro durante o restauro'},
        'Erro durante a reindexação': {
            'PTPT': 'Erro durante a reindexação'},
        'Ver todas': {
            'PTPT': 'Ver todas'},
        'A ficha selecionada pertence a uma base de dados anterior.': {
            'PTPT': 'A ficha selecionada pertence a uma base de dados anterior.'},
        'Permissões': {
            'PTPT': 'Permissões'},
        'Erro durante a transferência de logs': {
            'PTPT': 'Erro durante a transferência de logs'},
        'Não existem dados para transferir!': {
            'PTPT': 'Não existem dados para transferir!'},
        'Transferir dados para histórico': {
            'PTPT': 'Transferir dados para histórico'},
        'Transferir dados com mais de {0} dias': {
            'PTPT': 'Transferir dados com mais de {0} dias'},
        'Transferir todos': {
            'PTPT': 'Transferir todos'},
        'A transferir...': {
            'PTPT': 'A transferir...'},
        'Dados transferidos com sucesso para histórico!': {
            'PTPT': 'Dados transferidos com sucesso para histórico!'},
        'Dados:': {
            'PTPT': 'Dados:'},
        'Atuais': {
            'PTPT': 'Atuais'},
        'Histórico': {
            'PTPT': 'Histórico'},
        'Gestão de utilizadores': {
            'PTPT': 'Gestão de utilizadores'},
        'Aqui poderá fazer toda a gestão de utilizadores de forma a forneceder os privilégios necessários para acederem aos módulos da sua aplicação.': {
            'PTPT': 'Aqui poderá fazer toda a gestão de utilizadores de forma a forneceder os privilégios necessários para acederem aos módulos da sua aplicação.'},
        'O número de registos selecionados para exportação é superior a {0} e a sua exportação pode sobrecarregar o sistema. Deseja prosseguir com a exportação?': {
            'PTPT': 'O número de registos selecionados para exportação é superior a {0} e a sua exportação pode sobrecarregar o sistema. Deseja prosseguir com a exportação?'},
        'Durante esta operação o acesso aos sistemas poderá tornar-se mais demorado. Deseja prosseguir com a transferência dos dados para histórico?': {
            'PTPT': 'Durante esta operação o acesso aos sistemas poderá tornar-se mais demorado. Deseja prosseguir com a transferência dos dados para histórico?'},
        'A exportar...': {
            'PTPT': 'A exportar...'},
        'A importar...': {
            'PTPT': 'A importar...'},
        'Relatório do Sistema': {
            'PTPT': 'Relatório do Sistema'},
        'Sistema': {
            'PTPT': 'Sistema'},
        'Versão de Sistema': {
            'PTPT': 'Versão de Sistema'},
        'Versão de Base de Dados': {
            'PTPT': 'Versão de Base de Dados'},
        'Versão dos Indíces': {
            'PTPT': 'Versão dos Indíces'},
        'Versão de Genio': {
            'PTPT': 'Versão de Genio'},
        'Gerado em': {
            'PTPT': 'Gerado em'},
        'Ambiente': {
            'PTPT': 'Ambiente'},
        'Servidor de SGBD': {
            'PTPT': 'Servidor de SGBD'},
        'SGBD': {
            'PTPT': 'SGBD'},
        'Versão do SGBD': {
            'PTPT': 'Versão do SGBD'},
        'Versão da BD': {
            'PTPT': 'Versão da BD'},
        'Tamanho da BD': {
            'PTPT': 'Tamanho da BD'},
        'Sistema Operativo': {
            'PTPT': 'Sistema Operativo'},
        'Processador': {
            'PTPT': 'Processador'},
        'Memória': {
            'PTPT': 'Memória'},
        'Licenciamento': {
            'PTPT': 'Licenciamento'},
        'Plataforma': {
            'PTPT': 'Plataforma'},
        'Acrónimo': {
            'PTPT': 'Acrónimo'},
        'Contactos': {
            'PTPT': 'Contactos'},
        'Espaço livre:': {
            'PTPT': 'Espaço livre:'},
        'Não foi possível encontrar o ficheiro de relatório na directoria:': {
            'PTPT': 'Não foi possível encontrar o ficheiro de relatório na directoria:'},
        'Não foi localizado o ficheiro de configurações.': {
            'PTPT': 'Não foi localizado o ficheiro de configurações.'},
        'Proceda a uma nova configuração de Sistema!': {
            'PTPT': 'Proceda a uma nova configuração de Sistema!'},
        'Erro no acesso ao servidor de base de dados. (Ex. Verifique o nome de instância, utilizador, password,...)': {
            'PTPT': 'Erro no acesso ao servidor de base de dados. (Ex. Verifique o nome de instância, utilizador, password,...)'},
        'Não foi possível localizar a base de dados deste sistema': {
            'PTPT': 'Não foi possível localizar a base de dados deste sistema'},
        'Versão de base de dados diferente do sistema presente.': {
            'PTPT': 'Versão de base de dados diferente do sistema presente.'},
        'Versão de indíces incoerente com o sistema presente.': {
            'PTPT': 'Versão de indíces incoerente com o sistema presente.'},
        'Execute a operação de manutenção da base de dados!': {
            'PTPT': 'Execute a operação de manutenção da base de dados!'},
        'Erros detectados': {
            'PTPT': 'Erros detectados'},
        'A matrícula não é válida!': {
            'PTPT': 'A matrícula não é válida!'},
        'Entrada': {
            'PTPT': 'Entrada'},
        'Saída': {
            'PTPT': 'Saída'},
        'Entrada através da página de login.': {
            'PTPT': 'Entrada através da página de login.'},
        'Saída através da opção de logoff.': {
            'PTPT': 'Saída através da opção de logoff.'},
        'Entrada através de Active Directory.': {
            'PTPT': 'Entrada através de Active Directory.'},
        'Entrada através de cookie.': {
            'PTPT': 'Entrada através de cookie.'},
        'Cookie não encontrada.': {
            'PTPT': 'Cookie não encontrada.'},
        'Estado da manutenção': {
            'PTPT': 'Estado da manutenção'},
        'Por favor faça o seu Login': {
            'PTPT': 'Por favor faça o seu Login'},
        'Por favor indique um email válido!': {
            'PTPT': 'Por favor indique um email válido!'},
        'Telefone': {
            'PTPT': 'Telefone'},
        'Forte': {
            'PTPT': 'Forte'},
        'Fraco': {
            'PTPT': 'Fraco'},
        'Pobre': {
            'PTPT': 'Pobre'},
        'Modo de autenticação': {
            'PTPT': 'Modo de autenticação'},
        'Politica de sessões concorrentes': {
            'PTPT': 'Politica de sessões concorrentes'},
        'Permite recuperação da autenticação': {
            'PTPT': 'Permite recuperação da autenticação'},
        'Fornecedores de Identidade': {
            'PTPT': 'Fornecedores de Identidade'},
        'Fornecedores de Autorização': {
            'PTPT': 'Fornecedores de Autorização'},
        'Utilizadores fixos': {
            'PTPT': 'Utilizadores fixos'},
        'Aceitar ao primeiro sucesso': {
            'PTPT': 'Aceitar ao primeiro sucesso'},
        'Rejeitar na primeira falha': {
            'PTPT': 'Rejeitar na primeira falha'},
        'Permissiva': {
            'PTPT': 'Permissiva'},
        'Por IP': {
            'PTPT': 'Por IP'},
        'Sessão única': {
            'PTPT': 'Sessão única'},
        'Precondição': {
            'PTPT': 'Precondição'},
        'Convidado': {
            'PTPT': 'Convidado'},
        'Administrador': {
            'PTPT': 'Administrador'},
        'Login automático': {
            'PTPT': 'Login automático'},
        'Segurança': {
            'PTPT': 'Segurança'},
        'Integração': {
            'PTPT': 'Integração'},
        'Relatórios': {
            'PTPT': 'Relatórios'},
        'Fornecedor de identidade': {
            'PTPT': 'Fornecedor de identidade'},
        'Fornecedor de autorização': {
            'PTPT': 'Fornecedor de autorização'},
        'Utilizador Fixo': {
            'PTPT': 'Utilizador Fixo'},
        'Mais': {
            'PTPT': 'Mais'},
        'Caminho para a aplicação': {
            'PTPT': 'Caminho para a aplicação'},
        'Caminho para documento': {
            'PTPT': 'Caminho para documento'},
        'Caminho para relatórios': {
            'PTPT': 'Caminho para relatórios'},
        'Caminho para ficheiro de log': {
            'PTPT': 'Caminho para ficheiro de log'},
        'Caminho': {
            'PTPT': 'Caminho'},
        'Caminhos': {
            'PTPT': 'Caminhos'},
        'Domínio': {
            'PTPT': 'Domínio'},
        'Separador decimal': {
            'PTPT': 'Separador decimal'},
        'Separador de grupo': {
            'PTPT': 'Separador de grupo'},
        'Motor de pesquisa (ELASTICSEARCH)': {
            'PTPT': 'Motor de pesquisa (ELASTICSEARCH)'},
        'Data, horas e segundos': {
            'PTPT': 'Data, horas e segundos'},
        'Usar formato de 12 horas': {
            'PTPT': 'Usar formato de 12 horas'},
        'Unicode': {
            'PTPT': 'Unicode'},
        'Usa MSMQ': {
            'PTPT': 'Usa MSMQ'},
        'Journal': {
            'PTPT': 'Journal'},
        'Journal timeout (Minutos)': {
            'PTPT': 'Journal timeout (Minutos)'},
        'Queue ACK': {
            'PTPT': 'Queue ACK'},
        'Configuração de Acks': {
            'PTPT': 'Configuração de Acks'},
        'Número máximo de tentativas': {
            'PTPT': 'Número máximo de tentativas'},
        'Queue origem': {
            'PTPT': 'Queue origem'},
        'Operação invalida. Esta ficha já está em modo inserção.': {
            'PTPT': 'Operação invalida. Esta ficha já está em modo inserção.'},
        'A sua versão de Browser não é suportada. Por favor atualize para a versão mais recente.': {
            'PTPT': 'A sua versão de Browser não é suportada. Por favor atualize para a versão mais recente.'},
        'O seu Browser não é suportado. A aplicação pode não funcionar corretamente.': {
            'PTPT': 'O seu Browser não é suportado. A aplicação pode não funcionar corretamente.'},
        'A Integração do Registo está em espera para ser processada.': {
            'PTPT': 'A Integração do Registo está em espera para ser processada.'},
        'Não Existe informação sobre o estado da integração.': {
            'PTPT': 'Não Existe informação sobre o estado da integração.'},
        'A Integração do Registo está a ser processada.': {
            'PTPT': 'A Integração do Registo está a ser processada.'},
        'Integração do Registo expirou.': {
            'PTPT': 'Integração do Registo expirou.'},
        'Integração do Registo falhou.': {
            'PTPT': 'Integração do Registo falhou.'},
        'Ocorreu um erro na Integração do Registo. Irá ser processada de novo em breve.': {
            'PTPT': 'Ocorreu um erro na Integração do Registo. Irá ser processada de novo em breve.'},
        'A Integração do Registo foi concluida com sucesso.': {
            'PTPT': 'A Integração do Registo foi concluida com sucesso.'},
        'Este registo foi alterado por {0} em {1}. É necessário atualizar o registo.': {
            'PTPT': 'Este registo foi alterado por {0} em {1}. É necessário atualizar o registo.'},
        'Este registo foi alterado por {0} em {1}. Se regravar o registo vai sobrepor as alterações do {0}.': {
            'PTPT': 'Este registo foi alterado por {0} em {1}. Se regravar o registo vai sobrepor as alterações do {0}.'},
        '&Digitalizar': {
            'PTPT': '&Digitalizar'},
        'Co&rtar': {
            'PTPT': 'Co&rtar'},
        '&Parágrafo': {
            'PTPT': '&Parágrafo'},
        '&Centrado': {
            'PTPT': '&Centrado'},
        'Filtrar por base de dados:': {
            'PTPT': 'Filtrar por base de dados:'},
        'P&róximo': {
            'PTPT': 'P&róximo'},
        '&Actualizar': {
            'PTPT': '&Actualizar'},
        '&Destino': {
            'PTPT': '&Destino'},
        'Guardar &como:': {
            'PTPT': 'Guardar &como:'},
        '&Enviar por Programa de E-Mail': {
            'PTPT': '&Enviar por Programa de E-Mail'},
        '&Código Queue': {
            'PTPT': '&Código Queue'},
        '&Delegador': {
            'PTPT': '&Delegador'},
        'A&ntes': {
            'PTPT': 'A&ntes'},
        '&Máximo': {
            'PTPT': '&Máximo'},
        'M&ínimo': {
            'PTPT': 'M&ínimo'},
        'C&ontar': {
            'PTPT': 'C&ontar'},
        'Tarefas do processo': {
            'PTPT': 'Tarefas do processo'},
        '&Processo': {
            'PTPT': '&Processo'},
        'Visualizar': {
            'PTPT': 'Visualizar'},
        'Lista de Process Mining': {
            'PTPT': 'Lista de Process Mining'},
        'Telefone:': {
            'PTPT': 'Telefone:'},
        '&Permissões': {
            'PTPT': '&Permissões'},
        'Prcess': {
            'PTPT': 'Prcess'},
        'Erro ao gravar a imagem.': {
            'PTPT': 'Erro ao gravar a imagem.'},
        'Erro ao ler o ficheiro de configurações.': {
            'PTPT': 'Erro ao ler o ficheiro de configurações.'},
        'Erro ao configurar o sistema de dados.': {
            'PTPT': 'Erro ao configurar o sistema de dados.'},
        'Erro ao apagar os ficheiros.': {
            'PTPT': 'Erro ao apagar os ficheiros.'},
        'O registo não foi encontrado.': {
            'PTPT': 'O registo não foi encontrado.'},
        'Erro na validação do registo.': {
            'PTPT': 'Erro na validação do registo.'},
        'Erro na inserção do registo.': {
            'PTPT': 'Erro na inserção do registo.'},
        'Erro na atualização do registo.': {
            'PTPT': 'Erro na atualização do registo.'},
        'Erro na duplicação.': {
            'PTPT': 'Erro na duplicação.'},
        'Erro ao duplicar o registo.': {
            'PTPT': 'Erro ao duplicar o registo.'},
        'Não tem permissões para alterar os registos.': {
            'PTPT': 'Não tem permissões para alterar os registos.'},
        'Erro na inserção de queue.': {
            'PTPT': 'Erro na inserção de queue.'},
        'Erro ao enviar task.': {
            'PTPT': 'Erro ao enviar task.'},
        'Erro no envio de task.': {
            'PTPT': 'Erro no envio de task.'},
        'Erro ao obter o controlo.': {
            'PTPT': 'Erro ao obter o controlo.'},
        'Erro ao obter valor de campos em fórmula interna.': {
            'PTPT': 'Erro ao obter valor de campos em fórmula interna.'},
        'Erro no cálculo da fórmula condição.': {
            'PTPT': 'Erro no cálculo da fórmula condição.'},
        'Erro na consulta à tabela.': {
            'PTPT': 'Erro na consulta à tabela.'},
        'Erro na consulta a tabela.': {
            'PTPT': 'Erro na consulta a tabela.'},
        'Erro ao obter os dados de uma área.': {
            'PTPT': 'Erro ao obter os dados de uma área.'},
        'Erro no cálculo de fórmula interna.': {
            'PTPT': 'Erro no cálculo de fórmula interna.'},
        'Não existe pesquisa definida': {
            'PTPT': 'Não existe pesquisa definida'},
        'Erro ao fazer o parse de pedido MVC.': {
            'PTPT': 'Erro ao fazer o parse de pedido MVC.'},
        'Erro ao construir o resultado para MVC.': {
            'PTPT': 'Erro ao construir o resultado para MVC.'},
        'Erro na condição de pesquisa.': {
            'PTPT': 'Erro na condição de pesquisa.'},
        'Erro ao fazer pop de expressão.': {
            'PTPT': 'Erro ao fazer pop de expressão.'},
        'Erro em citação.': {
            'PTPT': 'Erro em citação.'},
        'Erro ao adicionar subexpressão.': {
            'PTPT': 'Erro ao adicionar subexpressão.'},
        'Erro ao adicionar termo.': {
            'PTPT': 'Erro ao adicionar termo.'},
        'Erro ao executar função.': {
            'PTPT': 'Erro ao executar função.'},
        'Dados de login incorretos.': {
            'PTPT': 'Dados de login incorretos.'},
        'Erro na validação das credenciais.': {
            'PTPT': 'Erro na validação das credenciais.'},
        'Erro ao gerar password.': {
            'PTPT': 'Erro ao gerar password.'},
        'Erro na validação da assinatura.': {
            'PTPT': 'Erro na validação da assinatura.'},
        'Não foram definidos campos para a assinatura.': {
            'PTPT': 'Não foram definidos campos para a assinatura.'},
        'Ocorreu um erro ao assinar.': {
            'PTPT': 'Ocorreu um erro ao assinar.'},
        'Assinatura invalida, o documento não foi assinado.': {
            'PTPT': 'Assinatura invalida, o documento não foi assinado.'},
        'Erro ao executar função na base de dados.': {
            'PTPT': 'Erro ao executar função na base de dados.'},
        'Erro ao definir a propriedade NoLock.': {
            'PTPT': 'Erro ao definir a propriedade NoLock.'},
        'Erro ao selecionar registos.': {
            'PTPT': 'Erro ao selecionar registos.'},
        'Erro ao selecionar o registo anterior.': {
            'PTPT': 'Erro ao selecionar o registo anterior.'},
        'Erro ao obter o tipo da dados do campo.': {
            'PTPT': 'Erro ao obter o tipo da dados do campo.'},
        'Erro ao obter o tipo de campo.': {
            'PTPT': 'Erro ao obter o tipo de campo.'},
        'Erro ao obter o campo.': {
            'PTPT': 'Erro ao obter o campo.'},
        'Erro ao criar a agenda Flash.': {
            'PTPT': 'Erro ao criar a agenda Flash.'},
        'Erro a carregar o Flash da agenda.': {
            'PTPT': 'Erro a carregar o Flash da agenda.'},
        'Erro ao processar o pedido Flash.': {
            'PTPT': 'Erro ao processar o pedido Flash.'},
        'Erro ao criar o Scorecard Flash.': {
            'PTPT': 'Erro ao criar o Scorecard Flash.'},
        'Erro a carregar o Flash do Scorecard.': {
            'PTPT': 'Erro a carregar o Flash do Scorecard.'},
        'Erro ao carregar o Flash.': {
            'PTPT': 'Erro ao carregar o Flash.'},
        'Erro a carregar o Flash do calagen.': {
            'PTPT': 'Erro a carregar o Flash do calagen.'},
        'Erro a carregar o Flash das férias.': {
            'PTPT': 'Erro a carregar o Flash das férias.'},
        'Erro a carregar o Flash do Gantt.': {
            'PTPT': 'Erro a carregar o Flash do Gantt.'},
        'Erro ao criar o Flash.': {
            'PTPT': 'Erro ao criar o Flash.'},
        'Erro a carregar o Flash do MAPGEO.': {
            'PTPT': 'Erro a carregar o Flash do MAPGEO.'},
        'Erro a carregar o Flash do organograma.': {
            'PTPT': 'Erro a carregar o Flash do organograma.'},
        'Erro a carregar o Flash de picagem.': {
            'PTPT': 'Erro a carregar o Flash de picagem.'},
        'Erro a carregar o Flash do questionário.': {
            'PTPT': 'Erro a carregar o Flash do questionário.'},
        'Erro ao processar o Flash.': {
            'PTPT': 'Erro ao processar o Flash.'},
        'Erro a carregar o Flash do IVC.': {
            'PTPT': 'Erro a carregar o Flash do IVC.'},
        'Erro a carregar o Flash do Workflow.': {
            'PTPT': 'Erro a carregar o Flash do Workflow.'},
        'Erro ao converter enumerável para array.': {
            'PTPT': 'Erro ao converter enumerável para array.'},
        'Erro ao converter inteiro para tipo interno.': {
            'PTPT': 'Erro ao converter inteiro para tipo interno.'},
        'Erro ao ler operador de EPH.': {
            'PTPT': 'Erro ao ler operador de EPH.'},
        'Erro ao ler operador de SQL.': {
            'PTPT': 'Erro ao ler operador de SQL.'},
        'Erro ao preencher o relatório.': {
            'PTPT': 'Erro ao preencher o relatório.'},
        'Erro na leitura do campo.': {
            'PTPT': 'Erro na leitura do campo.'},
        'Por favor configure o sistema primeiro.': {
            'PTPT': 'Por favor configure o sistema primeiro.'},
        'Tem que fornecer um texto.': {
            'PTPT': 'Tem que fornecer um texto.'},
        'Erro ao obter a ligação à base de dados.': {
            'PTPT': 'Erro ao obter a ligação à base de dados.'},
        'Erro ao criar o backup.': {
            'PTPT': 'Erro ao criar o backup.'},
        'Erro ao restaurar base de dados.': {
            'PTPT': 'Erro ao restaurar base de dados.'},
        'Erro ao atualizar o schema da base de dados.': {
            'PTPT': 'Erro ao atualizar o schema da base de dados.'},
        'Erro durante a transferência de logs.': {
            'PTPT': 'Erro durante a transferência de logs.'},
        'Erro ao obter o suporte persistente.': {
            'PTPT': 'Erro ao obter o suporte persistente.'},
        'Não foi possível estabelecer ligação à base de dados.': {
            'PTPT': 'Não foi possível estabelecer ligação à base de dados.'},
        'Erro ao fechar a ligação á base de dados.': {
            'PTPT': 'Erro ao fechar a ligação á base de dados.'},
        'Erro ao abrir a transação.': {
            'PTPT': 'Erro ao abrir a transação.'},
        'Erro ao fechar a transação.': {
            'PTPT': 'Erro ao fechar a transação.'},
        'Erro ao fazer rollback da transação.': {
            'PTPT': 'Erro ao fazer rollback da transação.'},
        'Erro na transação.': {
            'PTPT': 'Erro na transação.'},
        'Não foi possível encontrar os registos relacionados.': {
            'PTPT': 'Não foi possível encontrar os registos relacionados.'},
        'Erro a devolver campo.': {
            'PTPT': 'Erro a devolver campo.'},
        'Erro a devolver campos.': {
            'PTPT': 'Erro a devolver campos.'},
        'Erro ao obter níveis de acesso.': {
            'PTPT': 'Erro ao obter níveis de acesso.'},
        'Erro ao seleccionar resultado único da query.': {
            'PTPT': 'Erro ao seleccionar resultado único da query.'},
        'Erro ao seleccionar um resultado da query.': {
            'PTPT': 'Erro ao seleccionar um resultado da query.'},
        'Erro ao preencher registo na tabela.': {
            'PTPT': 'Erro ao preencher registo na tabela.'},
        'Erro ao inserir dados na tabela.': {
            'PTPT': 'Erro ao inserir dados na tabela.'},
        'Erro ao construir a query de inserção.': {
            'PTPT': 'Erro ao construir a query de inserção.'},
        'Erro ao obter o código interno para inserção.': {
            'PTPT': 'Erro ao obter o código interno para inserção.'},
        'Erro ao gerar um número aleatório negativo.': {
            'PTPT': 'Erro ao gerar um número aleatório negativo.'},
        'Erro ao seleccionar registos.': {
            'PTPT': 'Erro ao seleccionar registos.'},
        'Erro ao preencher dados dos campos.': {
            'PTPT': 'Erro ao preencher dados dos campos.'},
        'Erro ao seleccionar registos no nível.': {
            'PTPT': 'Erro ao seleccionar registos no nível.'},
        'Erro ao contar os registos.': {
            'PTPT': 'Erro ao contar os registos.'},
        'Erro ao obter a posição do registo.': {
            'PTPT': 'Erro ao obter a posição do registo.'},
        'Erro ao executar a query.': {
            'PTPT': 'Erro ao executar a query.'},
        'Erro ao obter os registos.': {
            'PTPT': 'Erro ao obter os registos.'},
        'Erro ao seleccionar registo.': {
            'PTPT': 'Erro ao seleccionar registo.'},
        'Erro ao executar o procedimento gravado.': {
            'PTPT': 'Erro ao executar o procedimento gravado.'},
        'Erro ao obter registo.': {
            'PTPT': 'Erro ao obter registo.'},
        'Erro executar a query.': {
            'PTPT': 'Erro executar a query.'},
        'Erro ao obter os registos da área.': {
            'PTPT': 'Erro ao obter os registos da área.'},
        'Não é possível gravar o ficheiro.': {
            'PTPT': 'Não é possível gravar o ficheiro.'},
        'Não é possível alterar o ficheiro.': {
            'PTPT': 'Não é possível alterar o ficheiro.'},
        'Não é possível apagar o ficheiro.': {
            'PTPT': 'Não é possível apagar o ficheiro.'},
        'A chave gerada é inválida.': {
            'PTPT': 'A chave gerada é inválida.'},
        'Erro ao gerar a chave primária.': {
            'PTPT': 'Erro ao gerar a chave primária.'},
        'Erro no cálculo do valor maior mais 1.': {
            'PTPT': 'Erro no cálculo do valor maior mais 1.'},
        'Erro no cálculo do valor da fórmula default.': {
            'PTPT': 'Erro no cálculo do valor da fórmula default.'},
        'Erro no cálculo do valor da fórmula sequencial.': {
            'PTPT': 'Erro no cálculo do valor da fórmula sequencial.'},
        'Erro na verificação de alteração do prefixo de não duplicação.': {
            'PTPT': 'Erro na verificação de alteração do prefixo de não duplicação.'},
        'Erro na verificação de novo registo.': {
            'PTPT': 'Erro na verificação de novo registo.'},
        'Data de Início': {
            'PTPT': 'Data de Início'},
        'Data de Fim': {
            'PTPT': 'Data de Fim'},
        'Data limite inferior': {
            'PTPT': 'Data limite inferior'},
        'Data limite superior': {
            'PTPT': 'Data limite superior'},
        'Retirar os filtros': {
            'PTPT': 'Retirar os filtros'},
        'chave primaria': {
            'PTPT': 'chave primaria'},
        'Password Antiga': {
            'PTPT': 'Password Antiga'},
        'Password Nova': {
            'PTPT': 'Password Nova'},
        'Repetição Password Nova': {
            'PTPT': 'Repetição Password Nova'},
        'OR': {
            'PTPT': 'OR'},
        'Dados de identificação': {
            'PTPT': 'Dados de identificação'},
        'Níveis de acesso': {
            'PTPT': 'Níveis de acesso'},
        'Por favor introduza um endereço de email válido e ser-lhe-á enviada uma nova password.': {
            'PTPT': 'Por favor introduza um endereço de email válido e ser-lhe-á enviada uma nova password.'},
        'Não foi possível obter a lista de autorizações.': {
            'PTPT': 'Não foi possível obter a lista de autorizações.'},
        'Num. Serie certificado': {
            'PTPT': 'Num. Serie certificado'},
        'Atenção: Tem fichas pendentes nesta tabela. Estão sinalizadas na listagem. Por favor edite ou elimine estas fichas.': {
            'PTPT': 'Atenção: Tem fichas pendentes nesta tabela. Estão sinalizadas na listagem. Por favor edite ou elimine estas fichas.'},
        'Não é possível efetuar a pesquisa em várias colunas de múltiplos valores em simultâneo.': {
            'PTPT': 'Não é possível efetuar a pesquisa em várias colunas de múltiplos valores em simultâneo.'},
        'Manutenção': {
            'PTPT': 'Manutenção'},
        'Índices': {
            'PTPT': 'Índices'},
        'Índice': {
            'PTPT': 'Índice'},
        'Qualidade de Dados': {
            'PTPT': 'Qualidade de Dados'},
        'Apagar backup': {
            'PTPT': 'Apagar backup'},
        'Restaurar backup': {
            'PTPT': 'Restaurar backup'},
        'Esta operação irá substituir a base de dados actual. Tem a acerteza que quer restaurar este backup?': {
            'PTPT': 'Esta operação irá substituir a base de dados actual. Tem a acerteza que quer restaurar este backup?'},
        'Índices pouco usados': {
            'PTPT': 'Índices pouco usados'},
        'Última verificação': {
            'PTPT': 'Última verificação'},
        'Relações incoerentes': {
            'PTPT': 'Relações incoerentes'},
        'Estado da Integração': {
            'PTPT': 'Estado da Integração'},
        'Reenviar ficha para integração': {
            'PTPT': 'Reenviar ficha para integração'},
        'Ficha reenviada para integração': {
            'PTPT': 'Ficha reenviada para integração'},
        'O Sistema irá entrar em Manutenção a partir de {0} ': {
            'PTPT': 'O Sistema irá entrar em Manutenção a partir de {0} '},
        'Sistema em Manutenção. Apenas disponível o modo de Consulta.': {
            'PTPT': 'Sistema em Manutenção. Apenas disponível o modo de Consulta.'},
        'Desactivar Manutenção': {
            'PTPT': 'Desactivar Manutenção'},
        'Mudar Agendamento de Manutenção': {
            'PTPT': 'Mudar Agendamento de Manutenção'},
        'Agendar Manutenção': {
            'PTPT': 'Agendar Manutenção'},
        'Deixar vazio para limpar Agendamento de Manutenção': {
            'PTPT': 'Deixar vazio para limpar Agendamento de Manutenção'},
        'Esta operação pode ser demorada': {
            'PTPT': 'Esta operação pode ser demorada'},
        'O sistema não consegue mostrar a informação pretendida. Por favor desligue o bloqueador de Pop-ups para este site e tente novamente.': {
            'PTPT': 'O sistema não consegue mostrar a informação pretendida. Por favor desligue o bloqueador de Pop-ups para este site e tente novamente.'},
        'Lista de mensagens': {
            'PTPT': 'Lista de mensagens'},
        'Nº de envios': {
            'PTPT': 'Nº de envios'},
        'Data status': {
            'PTPT': 'Data status'},
        'Arquivar': {
            'PTPT': 'Arquivar'},
        'Mesagens a enviar para histórico': {
            'PTPT': 'Mesagens a enviar para histórico'},
        'Mesagens de historial': {
            'PTPT': 'Mesagens de historial'},
        'Atualizar estatísticas': {
            'PTPT': 'Atualizar estatísticas'},
        'Deseja mesmo arquivar as mensagens?': {
            'PTPT': 'Deseja mesmo arquivar as mensagens?'},
        'Enviados com sucesso': {
            'PTPT': 'Enviados com sucesso'},
        'Total enviados': {
            'PTPT': 'Total enviados'},
        'Estatísticas': {
            'PTPT': 'Estatísticas'},
        'Por enviar': {
            'PTPT': 'Por enviar'},
        'Detalhes estatísticos': {
            'PTPT': 'Detalhes estatísticos'},
        'Estatística de erros': {
            'PTPT': 'Estatística de erros'},
        'Total': {
            'PTPT': 'Total'},
        'Importar utilizadores de AD': {
            'PTPT': 'Importar utilizadores de AD'},
        'Deseja mesmo mesmo importar os utilizadores de AD?': {
            'PTPT': 'Deseja mesmo mesmo importar os utilizadores de AD?'},
        'Caminho para serviços de relatórios': {
            'PTPT': 'Caminho para serviços de relatórios'},
        'É necessario escolher o domínio!': {
            'PTPT': 'É necessario escolher o domínio!'},
        'Domínio iválido!': {
            'PTPT': 'Domínio iválido!'},
        'Antes de editar um novo registo, feche o anterior e tente de novo.': {
            'PTPT': 'Antes de editar um novo registo, feche o anterior e tente de novo.'},
        'Não é possível inserir um novo registo.': {
            'PTPT': 'Não é possível inserir um novo registo.'},
        'Auditoria de ações de utilizador': {
            'PTPT': 'Auditoria de ações de utilizador'},
        'Auditoria de login de utilizador': {
            'PTPT': 'Auditoria de login de utilizador'},
        'Mínimo de Caracteres': {
            'PTPT': 'Mínimo de Caracteres'},
        'Expiração da Password (Dias)': {
            'PTPT': 'Expiração da Password (Dias)'},
        'Dias até à expiração': {
            'PTPT': 'Dias até à expiração'},
        'Expiração': {
            'PTPT': 'Expiração'},
        'Força da Password': {
            'PTPT': 'Força da Password'},
        'Algoritmo de Encriptação': {
            'PTPT': 'Algoritmo de Encriptação'},
        'Política de Passwords': {
            'PTPT': 'Política de Passwords'},
        'Atenção: Não pode colocar a palavra-chave igual ao nome de utilizador.': {
            'PTPT': 'Atenção: Não pode colocar a palavra-chave igual ao nome de utilizador.'},
        'A Palavra-passe não cumpre a complexidade exigida pelo administrador: {0}.': {
            'PTPT': 'A Palavra-passe não cumpre a complexidade exigida pelo administrador: {0}.'},
        'A Palavra-passe não cumpre o número mínimo de carateres exigido pelo administrador: {0}.': {
            'PTPT': 'A Palavra-passe não cumpre o número mínimo de carateres exigido pelo administrador: {0}.'},
        'Mudança de ano': {
            'PTPT': 'Mudança de ano'},
        'Nome da base de dados do destino': {
            'PTPT': 'Nome da base de dados do destino'},
        'Nome da base de dados de auditoría': {
            'PTPT': 'Nome da base de dados de auditoría'},
        'Definir apenas se uma base de dados de auditoría precisa ser criada': {
            'PTPT': 'Definir apenas se uma base de dados de auditoría precisa ser criada'},
        'Criar a Base de dados': {
            'PTPT': 'Criar a Base de dados'},
        'Já existe a base de dados com mesmo nome / ano': {
            'PTPT': 'Já existe a base de dados com mesmo nome / ano'},
        'Iniciar o processo da mudança de ano': {
            'PTPT': 'Iniciar o processo da mudança de ano'},
        'Reindexação completa': {
            'PTPT': 'Reindexação completa'},
        'O utilizador tem que alterar a palavra-passe na próxima autenticação': {
            'PTPT': 'O utilizador tem que alterar a palavra-passe na próxima autenticação'},
        'Este utilizador encontra-se desactivo. Por favor contacte o seu administrador.': {
            'PTPT': 'Este utilizador encontra-se desactivo. Por favor contacte o seu administrador.'},
        'Desactivar conta': {
            'PTPT': 'Desactivar conta'},
        'Gravar e criar nova': {
            'PTPT': 'Gravar e criar nova'},
        'Nova base de dados': {
            'PTPT': 'Nova base de dados'},
        'Algumas alterações não foram gravadas. Tem certeza que deseja continuar?': {
            'PTPT': 'Algumas alterações não foram gravadas. Tem certeza que deseja continuar?'},
        'Criar um novo sistema de dados': {
            'PTPT': 'Criar um novo sistema de dados'},
        'Nenhum registo foi selecionado': {
            'PTPT': 'Nenhum registo foi selecionado'},
        'Assinalado': {
            'PTPT': 'Assinalado'},
        'Não assinalado': {
            'PTPT': 'Não assinalado'},
        'Caixa de pesquisa': {
            'PTPT': 'Caixa de pesquisa'},
        'Erro ao conetar à Base de dados': {
            'PTPT': 'Erro ao conetar à Base de dados'},
        'Não está criada a Chave Mestra': {
            'PTPT': 'Não está criada a Chave Mestra'},
        'A base de dados não está encriptada': {
            'PTPT': 'A base de dados não está encriptada'},
        'Base de dados com encriptação ativa': {
            'PTPT': 'Base de dados com encriptação ativa'},
        'É obrigatório o preenchimento da chave mestra': {
            'PTPT': 'É obrigatório o preenchimento da chave mestra'},
        'Chave Mestra': {
            'PTPT': 'Chave Mestra'},
        'Criação da Chave Mestra': {
            'PTPT': 'Criação da Chave Mestra'},
        'Tentativa': {
            'PTPT': 'Tentativa'},
        'Diaporama': {
            'PTPT': 'Diaporama'},
        'Ir para a diapositiva {0}': {
            'PTPT': 'Ir para a diapositiva {0}'},
        'Grelha': {
            'PTPT': 'Grelha'},
        'Mosaico': {
            'PTPT': 'Mosaico'},
        'Conta foi criada com sucesso': {
            'PTPT': 'Conta foi criada com sucesso'},
        'Obrigado pelo seu registo! Para finalizar o registo clique no link enviado para o email para validar a sua conta.': {
            'PTPT': 'Obrigado pelo seu registo! Para finalizar o registo clique no link enviado para o email para validar a sua conta.'},
        'Confirmação de endereço de email': {
            'PTPT': 'Confirmação de endereço de email'},
        'Erro no envio do email': {
            'PTPT': 'Erro no envio do email'},
        'Erro na confirmação da conta': {
            'PTPT': 'Erro na confirmação da conta'},
        'Email confirmado com sucesso': {
            'PTPT': 'Email confirmado com sucesso'},
        'Esta coluna contem o formulário de apoio. Para abri-lo, precione a tecla ALT e clique com o botão esquerdo do rato no texto.': {
            'PTPT': 'Esta coluna contem o formulário de apoio. Para abri-lo, precione a tecla ALT e clique com o botão esquerdo do rato no texto.'},
        'Ao pressionar a tecla SHIFT e escolher duas linhas, todas as linhas que estiverem entre essas duas serão selecionadas.': {
            'PTPT': 'Ao pressionar a tecla SHIFT e escolher duas linhas, todas as linhas que estiverem entre essas duas serão selecionadas.'},
        'Esta lista contém continuação de menu. A ação será executada clicando na linha.': {
            'PTPT': 'Esta lista contém continuação de menu. A ação será executada clicando na linha.'},
        'Atenção: Esta ficha encontra-se pendente, deverá editar ou eliminar a mesma.': {
            'PTPT': 'Atenção: Esta ficha encontra-se pendente, deverá editar ou eliminar a mesma.'},
        'Directoria de relatórios': {
            'PTPT': 'Directoria de relatórios'},
        'Url do servidor de relatórios': {
            'PTPT': 'Url do servidor de relatórios'},
        'Subpath no servidor de relatórios': {
            'PTPT': 'Subpath no servidor de relatórios'},
        'Lista de relatórios': {
            'PTPT': 'Lista de relatórios'},
        'Data instalação': {
            'PTPT': 'Data instalação'},
        'Data ficheiro': {
            'PTPT': 'Data ficheiro'},
        'Dinâmico': {
            'PTPT': 'Dinâmico'},
        'Gestão de Relatórios': {
            'PTPT': 'Gestão de Relatórios'},
        'Instalação': {
            'PTPT': 'Instalação'},
        'Diferentes': {
            'PTPT': 'Diferentes'},
        'Recentes': {
            'PTPT': 'Recentes'},
        'Apagar não usados': {
            'PTPT': 'Apagar não usados'},
        'Iniciando a instalação': {
            'PTPT': 'Iniciando a instalação'},
        'Criar directoria de reports no servidor': {
            'PTPT': 'Criar directoria de reports no servidor'},
        'Criar fonte de dados partilhada': {
            'PTPT': 'Criar fonte de dados partilhada'},
        'Actualizar relatórios no servidor': {
            'PTPT': 'Actualizar relatórios no servidor'},
        'São os relatórios locais?': {
            'PTPT': 'São os relatórios locais?'},
        'Apagar relatórios não usados': {
            'PTPT': 'Apagar relatórios não usados'},
        'Este registo é controlado pela aplicação, não pode ser alterado!': {
            'PTPT': 'Este registo é controlado pela aplicação, não pode ser alterado!'},
        'Permite envio de email?': {
            'PTPT': 'Permite envio de email?'},
        'Permite envio de alerta?': {
            'PTPT': 'Permite envio de alerta?'},
        'Permite escrita na BD?': {
            'PTPT': 'Permite escrita na BD?'},
        'Nº de mensagens configuradas': {
            'PTPT': 'Nº de mensagens configuradas'},
        'Gestão de Notificações': {
            'PTPT': 'Gestão de Notificações'},
        'Nome do remetente': {
            'PTPT': 'Nome do remetente'},
        'Remetente': {
            'PTPT': 'Remetente'},
        'Destinatário': {
            'PTPT': 'Destinatário'},
        'Servidor de SMTP': {
            'PTPT': 'Servidor de SMTP'},
        'Propriedades de envio de emails': {
            'PTPT': 'Propriedades de envio de emails'},
        'Propriedades de envio de email': {
            'PTPT': 'Propriedades de envio de email'},
        'Assinaturas de email': {
            'PTPT': 'Assinaturas de email'},
        'Assinatura de email': {
            'PTPT': 'Assinatura de email'},
        'Tem a certeza que deseja processar a notificação?\nNota: irão ser enviados emails de forma automática com as mensagens configuradas.': {
            'PTPT': 'Tem a certeza que deseja processar a notificação?\nNota: irão ser enviados emails de forma automática com as mensagens configuradas.'},
        'Processar': {
            'PTPT': 'Processar'},
        'Processar todas': {
            'PTPT': 'Processar todas'},
        'Requer autenticação?': {
            'PTPT': 'Requer autenticação?'},
        'Imagem': {
            'PTPT': 'Imagem'},
        'Texto após a assinatura': {
            'PTPT': 'Texto após a assinatura'},
        'Dados do registo': {
            'PTPT': 'Dados do registo'},
        'ID de notificação': {
            'PTPT': 'ID de notificação'},
        'Destinatário manual': {
            'PTPT': 'Destinatário manual'},
        'Notificação no portal?': {
            'PTPT': 'Notificação no portal?'},
        'Envia email?': {
            'PTPT': 'Envia email?'},
        'Assunto': {
            'PTPT': 'Assunto'},
        'Envia anexo?': {
            'PTPT': 'Envia anexo?'},
        'Formato HTML?': {
            'PTPT': 'Formato HTML?'},
        'Grava na BD?': {
            'PTPT': 'Grava na BD?'},
        'Alteração: Data': {
            'PTPT': 'Alteração: Data'},
        'Criação: Data': {
            'PTPT': 'Criação: Data'},
        'Criação: Operador': {
            'PTPT': 'Criação: Operador'},
        'Alteração: Operador': {
            'PTPT': 'Alteração: Operador'},
        'Propriedades de envio de e-mail': {
            'PTPT': 'Propriedades de envio de e-mail'},
        'Notificação: ': {
            'PTPT': 'Notificação: '},
        'Mensagens na BD': {
            'PTPT': 'Mensagens na BD'},
        'Configuração de mensagens': {
            'PTPT': 'Configuração de mensagens'},
        'Configuração da mensagem': {
            'PTPT': 'Configuração da mensagem'},
        'Configurações': {
            'PTPT': 'Configurações'},
        'Visível': {
            'PTPT': 'Visível'},
        'Nome da coluna': {
            'PTPT': 'Nome da coluna'},
        'Ordem': {
            'PTPT': 'Ordem'},
        'Migração do ficheiro de configurações': {
            'PTPT': 'Migração do ficheiro de configurações'},
        'Iniciar': {
            'PTPT': 'Iniciar'},
        'É necessário proceder à atualização do ficheiro de configurações.': {
            'PTPT': 'É necessário proceder à atualização do ficheiro de configurações.'},
        'Versão atual': {
            'PTPT': 'Versão atual'},
        'Versão do ficheiro de configuração': {
            'PTPT': 'Versão do ficheiro de configuração'},
        'WebAdmin': {
            'PTPT': 'WebAdmin'},
        'Não foi possível aceder à diretoria dos relatórios:': {
            'PTPT': 'Não foi possível aceder à diretoria dos relatórios:'},
        'O caminho para a aplicação não se encontra configurado': {
            'PTPT': 'O caminho para a aplicação não se encontra configurado'},
        'Número máximo tentativas login': {
            'PTPT': 'Número máximo tentativas login'},
        'Nome do administrador da base de dados': {
            'PTPT': 'Nome do administrador da base de dados'},
        'Ativar autenticação de dois passos': {
            'PTPT': 'Ativar autenticação de dois passos'},
        'Invalidar autenticação de dois passos': {
            'PTPT': 'Invalidar autenticação de dois passos'},
        'Esta informação só será visível neste momento, guarde em local seguro.': {
            'PTPT': 'Esta informação só será visível neste momento, guarde em local seguro.'},
        'Introduza o código de segurança de 6 dígitos da aplicação de autenticação.': {
            'PTPT': 'Introduza o código de segurança de 6 dígitos da aplicação de autenticação.'},
        'O código introduzido não é válido.': {
            'PTPT': 'O código introduzido não é válido.'},
        'Introduza o seu código': {
            'PTPT': 'Introduza o seu código'},
        'Criar autenticação de dois passos': {
            'PTPT': 'Criar autenticação de dois passos'},
        'Obrigatório a utilização de autenticação de dois passos': {
            'PTPT': 'Obrigatório a utilização de autenticação de dois passos'},
        'Nome do campo': {
            'PTPT': 'Nome do campo'},
        'Texto da ajuda': {
            'PTPT': 'Texto da ajuda'},
        'Descrição do elemento': {
            'PTPT': 'Descrição do elemento'},
        'Texto da ajuda do elemento': {
            'PTPT': 'Texto da ajuda do elemento'},
        'Nova sugestão': {
            'PTPT': 'Nova sugestão'},
        'Preencha os campos acima com o texto que pretende ver no sistema': {
            'PTPT': 'Preencha os campos acima com o texto que pretende ver no sistema'},
        'Sem sugestões inseridas': {
            'PTPT': 'Sem sugestões inseridas'},
        'Texto original': {
            'PTPT': 'Texto original'},
        'Texto sugerido': {
            'PTPT': 'Texto sugerido'},
        'Enumerado': {
            'PTPT': 'Enumerado'},
        'Elemento do enumerado': {
            'PTPT': 'Elemento do enumerado'},
        'Ajuda do elemento do enumerado': {
            'PTPT': 'Ajuda do elemento do enumerado'},
        'Ajuda do campo': {
            'PTPT': 'Ajuda do campo'},
        'Sugerir': {
            'PTPT': 'Sugerir'},
        'Entrar em modo de sugestão no formulário': {
            'PTPT': 'Entrar em modo de sugestão no formulário'},
        'Mostrar âncoras do formulário': {
            'PTPT': 'Mostrar âncoras do formulário'},
        'Esconder âncoras do formulário': {
            'PTPT': 'Esconder âncoras do formulário'},
        'Áreas do formulário': {
            'PTPT': 'Áreas do formulário'},
        'There are no changes to submit': {
            'PTPT': 'Não há alterações a submeter'},
        'Error saving suggestion': {
            'PTPT': 'Ocorreu um erro a salvar a sugestão'},
        'Suggestion was saved': {
            'PTPT': 'A sua sugestão foi registada'},
        'Suggestion text': {
            'PTPT': 'Texto da sugestão'},
        'Entrar em modo de sugestão': {
            'PTPT': 'Entrar em modo de sugestão'},
        'Itens do módulo': {
            'PTPT': 'Itens do módulo'},
        'Título do módulo': {
            'PTPT': 'Título do módulo'},
        'Assinar documentos': {
            'PTPT': 'Assinar documentos'},
        'Sugestão aberta': {
            'PTPT': 'Sugestão aberta'},
        'Pesquisa de menus': {
            'PTPT': 'Pesquisa de menus'},
        'Por aplicação (TOTP)': {
            'PTPT': 'Por aplicação (TOTP)'},
        'Por Token (WebAuth)': {
            'PTPT': 'Por Token (WebAuth)'},
        'Índices recomendados em falta': {
            'PTPT': 'Índices recomendados em falta'},
        'Incoerência de relações (Diferentes caminhos para o mesmo destino)': {
            'PTPT': 'Incoerência de relações (Diferentes caminhos para o mesmo destino)'},
        'Registos Órfãos (chave preenchida sem existir o registo correspondente)': {
            'PTPT': 'Registos Órfãos (chave preenchida sem existir o registo correspondente)'},
        'Casos': {
            'PTPT': 'Casos'},
        'Registos': {
            'PTPT': 'Registos'},
        'Colunas': {
            'PTPT': 'Colunas'},
        'Query de eliminação': {
            'PTPT': 'Query de eliminação'},
        'Colunas comparadas por igualdade (=)': {
            'PTPT': 'Colunas comparadas por igualdade (=)'},
        'Colunas comparadas por não-igualdade (<;>;!=)': {
            'PTPT': 'Colunas comparadas por não-igualdade (<;>;!=)'},
        'Colunas incluídas na pesquisa': {
            'PTPT': 'Colunas incluídas na pesquisa'},
        'Último Seek': {
            'PTPT': 'Último Seek'},
        'Melhoria (%)': {
            'PTPT': 'Melhoria (%)'},
        'Query de criação': {
            'PTPT': 'Query de criação'},
        'A processar o índice relacionado com a tabela {0}.<br>Progresso: {1}/{2}': {
            'PTPT': 'A processar o índice relacionado com a tabela {0}.<br>Progresso: {1}/{2}'},
        'Detectadas {0} incoerências nos registos das tabelas {1} e {2}, que estão relacionadas com a tabela {3}.<br>Progresso: {4}/{5}<br>Inconsistências encontradas: {6} tipos / {7} totais': {
            'PTPT': 'Detectadas {0} incoerências nos registos das tabelas {1} e {2}, que estão relacionadas com a tabela {3}.<br>Progresso: {4}/{5}<br>Inconsistências encontradas: {6} tipos / {7} totais'},
        'Detectados {0} registos orfãos na tabela {1}, que estão relacionados com a tabela {2}.<br>Progresso: {3}/{4}<br>Registos orfãos encontrados: {5} tipos / {6} totais': {
            'PTPT': 'Detectados {0} registos orfãos na tabela {1}, que estão relacionados com a tabela {2}.<br>Progresso: {3}/{4}<br>Registos orfãos encontrados: {5} tipos / {6} totais'},
        'Tipo de pesquisa': {
            'PTPT': 'Tipo de pesquisa'},
        'Considerar as chaves nulas': {
            'PTPT': 'Considerar as chaves nulas'},
        'Considerar as Views': {
            'PTPT': 'Considerar as Views'},
        'Registos Orfãos': {
            'PTPT': 'Registos Orfãos'},
        'More Properties': {
            'PTPT': 'Mais Propriedades'},
        'Key': {
            'PTPT': 'Chave'},
        'Insert new key': {
            'PTPT': 'Inserir nova chave'},
        'List default keys': {
            'PTPT': 'Listar chaves'},
        'Key cannot be empty!': {
            'PTPT': 'A chave não pode estar vazia!'},
        'This key already exists!': {
            'PTPT': 'Essa chave já existe!'},
        'Value cannot be empty!': {
            'PTPT': 'O valor não pode estar vazio!'},
        'Cannot delete this property! It was reset with the default value.': {
            'PTPT': 'Esta propriedade não pode ser apagada! Foi reposto o valor por omissão.'},
        'Existem formulários abertos no modo de edição. Tem certeza de que deseja sair do formulário?': {
            'PTPT': 'Existem formulários abertos no modo de edição. Tem certeza de que deseja sair do formulário?'},
        'O relatório que você procura não existe,tente consultar o administrador': {
            'PTPT': 'O relatório que você procura não existe,tente consultar o administrador'},
        'Ocorreu um erro inesperado. Por favor, tente executar esta ação novamente. Se o problema persistir, por favor contacte a administração. Obrigado.': {
            'PTPT': 'Ocorreu um erro inesperado. Por favor, tente executar esta ação novamente. Se o problema persistir, por favor contacte a administração. Obrigado.'},
        'Não existe conteudo na pasta ': {
            'PTPT': 'Não existe conteudo na pasta '},
        'Não existem relatórios nesta pasta': {
            'PTPT': 'Não existem relatórios nesta pasta'},
        'Línguagem': {
            'PTPT': 'Línguagem'},
        'Relatórios por Língua': {
            'PTPT': 'Relatórios por Língua'},
        'Identificador de slot': {
            'PTPT': 'Identificador de slot'},
        'Slots de relatórios': {
            'PTPT': 'Slots de relatórios'},
        'Data referência': {
            'PTPT': 'Data referência'},
        'O nome de utilizador já existe': {
            'PTPT': 'O nome de utilizador já existe'},
        'Apenas é permitido agendamento de eventos no último nível de recursos.': {
            'PTPT': 'Apenas é permitido agendamento de eventos no último nível de recursos.'},
        'Pretende editar o evento?': {
            'PTPT': 'Pretende editar o evento?'},
        'Evento alterado com sucesso.': {
            'PTPT': 'Evento alterado com sucesso.'},
        'A informação na lista de <b>{0}</b> está limitada por:': {
            'PTPT': 'A informação na lista de <b>{0}</b> está limitada por:'},
        'A informação na lista de': {
            'PTPT': 'A informação na lista de'},
        'está limitada por': {
            'PTPT': 'está limitada por'},
        'Ações do formulário': {
            'PTPT': 'Ações do formulário'},
        'Modo do formulário': {
            'PTPT': 'Modo do formulário'},
        'Página inicial': {
            'PTPT': 'Página inicial'},
        'Avançar': {
            'PTPT': 'Avançar'},
        'Avatar do utilizador': {
            'PTPT': 'Avatar do utilizador'},
        'Formulário Modal Aberto': {
            'PTPT': 'Formulário Modal Aberto'},
        'Desativar sugestões': {
            'PTPT': 'Desativar sugestões'},
        'Criar a Matriz': {
            'PTPT': 'Criar a Matriz'},
        'Irão ser criadas todas as correspondências com base nos registos existentes nas tabelas de cada eixo da matriz. Confirma?': {
            'PTPT': 'Irão ser criadas todas as correspondências com base nos registos existentes nas tabelas de cada eixo da matriz. Confirma?'},
        'Marcador inválido': {
            'PTPT': 'Marcador inválido'},
        'Ambiente de QA?': {
            'PTPT': 'Ambiente de QA?'},
        'AMBIENTE DE QUALIDADE': {
            'PTPT': 'AMBIENTE DE QUALIDADE'},
        'Aplicar filtro complexo': {
            'PTPT': 'Aplicar filtro complexo'},
        'Selecione uma hora': {
            'PTPT': 'Selecione uma hora'},
        'Selecione uma data e hora': {
            'PTPT': 'Selecione uma data e hora'},
        'Entrar em modo de relatório': {
            'PTPT': 'Entrar em modo de relatório'},
        'Encriptar Ligação': {
            'PTPT': 'Encriptar Ligação'},
        'Utilizador de domínio': {
            'PTPT': 'Utilizador de domínio'},
        'Esconder': {
            'PTPT': 'Esconder'},
        'Registo': {
            'PTPT': 'Registo'},
        'Dispensar': {
            'PTPT': 'Dispensar'},
        'Roles above': {
            'PTPT': 'Função de acesso acima'},
        'Roles bellow': {
            'PTPT': 'Função de acesso abaixo'},
        'With this role': {
            'PTPT': 'Com esta função de acesso'},
        'With permissions above this role': {
            'PTPT': 'Com permissões acima desta função de acesso'},
        'Hierarquia': {
            'PTPT': 'Hierarquia'},
        'Atenção! Algumas permissões que foram ignoradas por serem redundantes:': {
            'PTPT': 'Atenção! Algumas permissões que foram ignoradas por serem redundantes:'},
        '@child foi ignorado devido a @parent': {
            'PTPT': '@child foi ignorado devido a @parent'},
        'Pesquisar nome de utilizador': {
            'PTPT': 'Pesquisar nome de utilizador'},
        'Associar': {
            'PTPT': 'Associar'},
        'Servidor de email': {
            'PTPT': 'Servidor de email'},
        'Servidores de email': {
            'PTPT': 'Servidores de email'},
        'Registo de utilizadores': {
            'PTPT': 'Registo de utilizadores'},
        'Campos': {
            'PTPT': 'Campos'},
        'Ordenação': {
            'PTPT': 'Ordenação'},
        'Totais': {
            'PTPT': 'Totais'},
        'Operador': {
            'PTPT': 'Operador'},
        'Mostrar linhas vazias': {
            'PTPT': 'Mostrar linhas vazias'},
        'Quebra de Página': {
            'PTPT': 'Quebra de Página'},
        'Executar': {
            'PTPT': 'Executar'},
        'Filtros activos': {
            'PTPT': 'Filtros activos'},
        'Filtro Personalizado': {
            'PTPT': 'Filtro Personalizado'},
        'todos os campos': {
            'PTPT': 'todos os campos'},
        'por': {
            'PTPT': 'por'},
        'Adicionar Filtro Personalizado': {
            'PTPT': 'Adicionar Filtro Personalizado'},
        'Adicionar condição': {
            'PTPT': 'Adicionar condição'},
        'Eliminar condição': {
            'PTPT': 'Eliminar condição'},
        'Filtros avançados': {
            'PTPT': 'Filtros avançados'},
        'Aplicar filtro': {
            'PTPT': 'Aplicar filtro'},
        'Aplicar filtros': {
            'PTPT': 'Aplicar filtros'},
        'Criar filtro': {
            'PTPT': 'Criar filtro'},
        'Nome do filtro': {
            'PTPT': 'Nome do filtro'},
        'Criar condição': {
            'PTPT': 'Criar condição'},
        'Remover condição': {
            'PTPT': 'Remover condição'},
        'Filtros gravados': {
            'PTPT': 'Filtros gravados'},
        'Gravar filtro': {
            'PTPT': 'Gravar filtro'},
        'Remover filtro': {
            'PTPT': 'Remover filtro'},
        'Remover filtros': {
            'PTPT': 'Remover filtros'},
        'Activar filtro': {
            'PTPT': 'Activar filtro'},
        'Desactivar filtro': {
            'PTPT': 'Desactivar filtro'},
        'contém': {
            'PTPT': 'contém'},
        'não contém': {
            'PTPT': 'não contém'},
        'é igual a': {
            'PTPT': 'é igual a'},
        'diferente de': {
            'PTPT': 'diferente de'},
        'é como': {
            'PTPT': 'é como'},
        'palavra-chave': {
            'PTPT': 'palavra-chave'},
        'começa com': {
            'PTPT': 'começa com'},
        'está definido': {
            'PTPT': 'está definido'},
        'não está definido': {
            'PTPT': 'não está definido'},
        'é maior que': {
            'PTPT': 'é maior que'},
        'é menor que': {
            'PTPT': 'é menor que'},
        'é maior ou igual a': {
            'PTPT': 'é maior ou igual a'},
        'é menor ou igual a': {
            'PTPT': 'é menor ou igual a'},
        'está entre': {
            'PTPT': 'está entre'},
        'é verdadeiro': {
            'PTPT': 'é verdadeiro'},
        'é falso': {
            'PTPT': 'é falso'},
        'é depois': {
            'PTPT': 'é depois'},
        'é antes': {
            'PTPT': 'é antes'},
        'é depois ou igual a': {
            'PTPT': 'é depois ou igual a'},
        'é antes ou igual a': {
            'PTPT': 'é antes ou igual a'},
        'é': {
            'PTPT': 'é'},
        'não é': {
            'PTPT': 'não é'},
        'tem valor': {
            'PTPT': 'tem valor'},
        'sem valor': {
            'PTPT': 'sem valor'},
        'Ações da coluna': {
            'PTPT': 'Ações da coluna'},
        'Ordenar': {
            'PTPT': 'Ordenar'},
        'Ordenar ascendente': {
            'PTPT': 'Ordenar ascendente'},
        'Ordenar descendente': {
            'PTPT': 'Ordenar descendente'},
        'Mover para filtros avançados': {
            'PTPT': 'Mover para filtros avançados'},
        'Filtros globais': {
            'PTPT': 'Filtros globais'},
        'Filtros ativos': {
            'PTPT': 'Filtros ativos'},
        'Remover todos': {
            'PTPT': 'Remover todos'},
        'Morada': {
            'PTPT': 'Morada'},
        'Camada padrão': {
            'PTPT': 'Camada padrão'},
        'Camada de grupo': {
            'PTPT': 'Camada de grupo'},
        'Camada de formas': {
            'PTPT': 'Camada de formas'},
        'Camada externa': {
            'PTPT': 'Camada externa'},
        'Excluir último ponto': {
            'PTPT': 'Excluir último ponto'},
        'Desenhar uma polilinha': {
            'PTPT': 'Desenhar uma polilinha'},
        'Desenhar um polígono': {
            'PTPT': 'Desenhar um polígono'},
        'Desenhar um retângulo': {
            'PTPT': 'Desenhar um retângulo'},
        'Desenhar um círculo': {
            'PTPT': 'Desenhar um círculo'},
        'Desenhar um marcador': {
            'PTPT': 'Desenhar um marcador'},
        'Desenhar um marcador circular': {
            'PTPT': 'Desenhar um marcador circular'},
        'Clique no mapa para colocar o centro do círculo.': {
            'PTPT': 'Clique no mapa para colocar o centro do círculo.'},
        'Clique no mapa para terminar o círculo.': {
            'PTPT': 'Clique no mapa para terminar o círculo.'},
        'Raio': {
            'PTPT': 'Raio'},
        'Clique no mapa para colocar o marcador circular.': {
            'PTPT': 'Clique no mapa para colocar o marcador circular.'},
        'Clique no mapa para colocar o marcador.': {
            'PTPT': 'Clique no mapa para colocar o marcador.'},
        'Clique para começar a desenhar a forma.': {
            'PTPT': 'Clique para começar a desenhar a forma.'},
        'Clique para continuar a desenhar a forma.': {
            'PTPT': 'Clique para continuar a desenhar a forma.'},
        'Clique no primeiro ponto para fechar esta forma.': {
            'PTPT': 'Clique no primeiro ponto para fechar esta forma.'},
        'Clique no último ponto para terminar a linha.': {
            'PTPT': 'Clique no último ponto para terminar a linha.'},
        'Clique no mapa para terminar o desenho.': {
            'PTPT': 'Clique no mapa para terminar o desenho.'},
        'Clique no mapa para colocar o texto.': {
            'PTPT': 'Clique no mapa para colocar o texto.'},
        'Arrastar camadas': {
            'PTPT': 'Arrastar camadas'},
        'Recortar camadas': {
            'PTPT': 'Recortar camadas'},
        'Rodar camadas': {
            'PTPT': 'Rodar camadas'},
        'Redimensionar camadas': {
            'PTPT': 'Redimensionar camadas'},
        'Desenhar texto': {
            'PTPT': 'Desenhar texto'},
        'Juntar o marcador arrastado a outras camadas e vértices': {
            'PTPT': 'Juntar o marcador arrastado a outras camadas e vértices'},
        'Prender os vértices em comum': {
            'PTPT': 'Prender os vértices em comum'},
        'Detetar linha automaticamente': {
            'PTPT': 'Detetar linha automaticamente'},
        'Comprimento': {
            'PTPT': 'Comprimento'},
        'Comprimento do segmento': {
            'PTPT': 'Comprimento do segmento'},
        'Perímetro': {
            'PTPT': 'Perímetro'},
        'Posição': {
            'PTPT': 'Posição'},
        'Marcador da posição': {
            'PTPT': 'Marcador da posição'},
        'Limpar tudo': {
            'PTPT': 'Limpar tudo'},
        'Editar camadas': {
            'PTPT': 'Editar camadas'},
        'Excluir camadas': {
            'PTPT': 'Excluir camadas'},
        'Imprimir mapa': {
            'PTPT': 'Imprimir mapa'},
        'Paisagem': {
            'PTPT': 'Paisagem'},
        'Retrato': {
            'PTPT': 'Retrato'},
        'Visualização de tabela salva com sucesso': {
            'PTPT': 'Visualização de tabela salva com sucesso'},
        'Salvar as alterações na visualização da tabela atual?': {
            'PTPT': 'Salvar as alterações na visualização da tabela atual?'},
        'Descartar': {
            'PTPT': 'Descartar'},
        'Reindexar Base de Dados': {
            'PTPT': 'Reindexar Base de Dados'},
        'Criar Configuração do Sistema': {
            'PTPT': 'Criar Configuração do Sistema'},
        'Password recovery': {
            'PTPT': 'Recuperação de palavra-chave'},
        'Enter your email. You will receive a link to change your password.': {
            'PTPT': 'Introduza o seu email. Vai receber um link onde poderá alterar a sua password.'},
        'Back to login': {
            'PTPT': 'Retornar ao login'},
        'An email was sent to {0} with instructions to recover your password.': {
            'PTPT': 'Foi enviado um email para {0} com instruções para recuperar a password.'},
        'This email address was recently used in a password reset attempt at {1} but there isn\'t any user with this address': {
            'PTPT': 'Este endereço de email foi recentemente utilizado para recuperar uma password em {1}, mas não foi detectado qualquer utilizador associado.'},
        'Please try a different email.': {
            'PTPT': 'Por favor tente outro endereço de email'},
        'Hi {1},': {
            'PTPT': 'Olá {1},'},
        'A password reset was recently asked for your user. Click the link below to reset it.': {
            'PTPT': 'Foi registado um pedido de alteração para o seu utilizador. Click no link abaixo para alterar a mesma.'},
        'This link is only valid for 1 hour': {
            'PTPT': 'Este link expira ao fim de 1 hora'},
        'Password successfully changed! Please login with your new credentials.': {
            'PTPT': 'Password alterada com sucesso. Por favor volte a entrar com as novas credenciais.'},
        'User created successfully! Please login with your new user.': {
            'PTPT': 'Utilizador criado com sucesso. Por favor faça login com o novo utilizador.'},
        'Use STARTTLS': {
            'PTPT': 'Usar STARTTLS'},
        'Pesquisa de campos': {
            'PTPT': 'Pesquisa de campos'},
        'Condições a aplicar': {
            'PTPT': 'Condições a aplicar'},
        'Ordenações a aplicar': {
            'PTPT': 'Ordenações a aplicar'},
        'Mover': {
            'PTPT': 'Mover'},
        'um de': {
            'PTPT': 'um de'},
        'Geral': {
            'PTPT': 'Geral'},
        'Total de Elementos': {
            'PTPT': 'Total de Elementos'},
        'Média': {
            'PTPT': 'Média'},
        'Novo relatório': {
            'PTPT': 'Novo relatório'},
        'Novo sistema de dados': {
            'PTPT': 'Novo sistema de dados'},
        'Sair do modo de relatório': {
            'PTPT': 'Sair do modo de relatório'},
        'Política de cookies': {
            'PTPT': 'Política de cookies'},
        'Abrir relatório': {
            'PTPT': 'Abrir relatório'},
        'Fich. Excel': {
            'PTPT': 'Fich. Excel'},
        'Nome da Consulta': {
            'PTPT': 'Nome da Consulta'},
        'Acesso da Consulta': {
            'PTPT': 'Acesso da Consulta'},
        'Gravar Consulta': {
            'PTPT': 'Gravar Consulta'},
        'Pública': {
            'PTPT': 'Pública'},
        'Inactiva': {
            'PTPT': 'Inactiva'},
        'Sobrepor a consulta actual': {
            'PTPT': 'Sobrepor a consulta actual'},
        'Escolha a consulta': {
            'PTPT': 'Escolha a consulta'},
        'Consulta gravada com sucesso!': {
            'PTPT': 'Consulta gravada com sucesso!'},
        'Deactivação de utilizador': {
            'PTPT': 'Deactivação de utilizador'},
        'Falhou uma condição para o campo {0}. Verifique se o valor do campo é válido.': {
            'PTPT': 'Falhou uma condição para o campo {0}. Verifique se o valor do campo é válido.'},
        'Está a falhar uma condição de escrita neste registo.': {
            'PTPT': 'Está a falhar uma condição de escrita neste registo.'},
        'Mover imagem para a esquerda': {
            'PTPT': 'Mover imagem para a esquerda'},
        'Mover imagem para a direita': {
            'PTPT': 'Mover imagem para a direita'},
        'Mover imagem para cima': {
            'PTPT': 'Mover imagem para cima'},
        'Mover imagem para baixo': {
            'PTPT': 'Mover imagem para baixo'},
        'Virar à esquerda': {
            'PTPT': 'Virar à esquerda'},
        'Virar à direita': {
            'PTPT': 'Virar à direita'},
        'Virar na horizontal': {
            'PTPT': 'Virar na horizontal'},
        'Virar na vertical': {
            'PTPT': 'Virar na vertical'},
        'Arraste o ficheiro a submeter': {
            'PTPT': 'Arraste o ficheiro a submeter'},
        'Editar imagem': {
            'PTPT': 'Editar imagem'},
        'Atenção: Ao gravar este formulário irá substituir a imagem original': {
            'PTPT': 'Atenção: Ao gravar este formulário irá substituir a imagem original'},
        'Tamanho do bloco': {
            'PTPT': 'Tamanho do bloco'},
        'Atribuição': {
            'PTPT': 'Atribuição'},
        'Escolhidos': {
            'PTPT': 'Escolhidos'},
        'Funções': {
            'PTPT': 'Funções'},
        'Gerência de Acessos': {
            'PTPT': 'Gerência de Acessos'},
        'Selecionar Modulo': {
            'PTPT': 'Selecionar Modulo'},
        'Seleccionar Módulo': {
            'PTPT': 'Seleccionar Módulo'},
        'Função @role já tinha sido atribuída ao utilizador @user': {
            'PTPT': 'Função @role já tinha sido atribuída ao utilizador @user'},
        'Função @role não está atribuída ao utilizador @user': {
            'PTPT': 'Função @role não está atribuída ao utilizador @user'},
        'Alterações': {
            'PTPT': 'Alterações'},
        'Alterações das Configurações': {
            'PTPT': 'Alterações das Configurações'},
        'Restaurar Configuração': {
            'PTPT': 'Restaurar Configuração'},
        'Restaurar Configuração Padrão': {
            'PTPT': 'Restaurar Configuração Padrão'},
        'Quer restaurar para esta configuração ?': {
            'PTPT': 'Quer restaurar para esta configuração ?'},
        'Quer restaurar para a configuração padrão ?': {
            'PTPT': 'Quer restaurar para a configuração padrão ?'},
        'Configuração Atual: ': {
            'PTPT': 'Configuração Atual: '},
        'Erro ao restaurar': {
            'PTPT': 'Erro ao restaurar'},
        'Backup não disponivel': {
            'PTPT': 'Backup não disponivel'},
        'Configuração restaurada com sucesso': {
            'PTPT': 'Configuração restaurada com sucesso'},
        'Auditorias': {
            'PTPT': 'Auditorias'},
        'Ações dos utilizadores': {
            'PTPT': 'Ações dos utilizadores'},
        'Estatísticas de login': {
            'PTPT': 'Estatísticas de login'},
        'Logins por dia': {
            'PTPT': 'Logins por dia'},
        'from': {
            'PTPT': 'de'},
        'Logins por utilizador': {
            'PTPT': 'Logins por utilizador'},
        'Nº de logins': {
            'PTPT': 'Nº de logins'},
        'Tempo médio de login': {
            'PTPT': 'Tempo médio de login'},
        'Tempo médio de login de utilizador': {
            'PTPT': 'Tempo médio de login de utilizador'},
        'minuto(s)': {
            'PTPT': 'minuto(s)'},
        'Não há logins/logouts para calcular o tempo médio': {
            'PTPT': 'Não há logins/logouts para calcular o tempo médio'},
        'Tempo médio (minutos)': {
            'PTPT': 'Tempo médio (minutos)'},
        'Estatísticas de erro': {
            'PTPT': 'Estatísticas de erro'},
        'Tipos de erro': {
            'PTPT': 'Tipos de erro'},
        'Não existem erros': {
            'PTPT': 'Não existem erros'},
        'Tempo médio de processamento': {
            'PTPT': 'Tempo médio de processamento'},
        'Throughput': {
            'PTPT': 'Throughput'},
        'Mensagens pendentes': {
            'PTPT': 'Mensagens pendentes'},
        'minutos': {
            'PTPT': 'minutos'},
        'mensagens': {
            'PTPT': 'mensagens'},
        'Tempo de processamento': {
            'PTPT': 'Tempo de processamento'},
        'Não existem mensagens disponíveis': {
            'PTPT': 'Não existem mensagens disponíveis'},
        'Repetidas': {
            'PTPT': 'Repetidas'},
        'Por favor indique a alteração que pretende realizar sobre o evento.': {
            'PTPT': 'Por favor indique a alteração que pretende realizar sobre o evento.'},
        'Pretende alterar o evento?': {
            'PTPT': 'Pretende alterar o evento?'},
        'Pretende mover o evento?': {
            'PTPT': 'Pretende mover o evento?'},
        'Título do evento': {
            'PTPT': 'Título do evento'},
        'A data de início não é válida.': {
            'PTPT': 'A data de início não é válida.'},
        'A data de fim não é válida.': {
            'PTPT': 'A data de fim não é válida.'},
        'A data de fim tem de ser posterior à data de início.': {
            'PTPT': 'A data de fim tem de ser posterior à data de início.'},
        'O evento não está dentro do horário definido no calendário.': {
            'PTPT': 'O evento não está dentro do horário definido no calendário.'},
        'Evento movido com sucesso.': {
            'PTPT': 'Evento movido com sucesso.'},
        'Descrição do evento': {
            'PTPT': 'Descrição do evento'},
        'Hora de início': {
            'PTPT': 'Hora de início'},
        'Hora de fim': {
            'PTPT': 'Hora de fim'},
        'There was an error opening the viewer. Please verify if the content is well created': {
            'PTPT': 'Ocorreu um erro ao abrir o visualizador. Por favor verifique se o conteúdo se encontra disponível'},
        'O ficheiro selecionado excede o tamanho permitido de {0}.': {
            'PTPT': 'O ficheiro selecionado excede o tamanho permitido de {0}.'},
        'igual a': {
            'PTPT': 'igual a'},
        'maior que': {
            'PTPT': 'maior que'},
        'maior ou igual que': {
            'PTPT': 'maior ou igual que'},
        'menor que': {
            'PTPT': 'menor que'},
        'menor ou igual que': {
            'PTPT': 'menor ou igual que'},
        'inclui': {
            'PTPT': 'inclui'},
        'entre': {
            'PTPT': 'entre'},
        'é vazio': {
            'PTPT': 'é vazio'},
        'não é vazio': {
            'PTPT': 'não é vazio'},
        'Falso': {
            'PTPT': 'Falso'},
        'Verdadeiro': {
            'PTPT': 'Verdadeiro'},
        'Total de elementos': {
            'PTPT': 'Total de elementos'},
        'Quebra de linha': {
            'PTPT': 'Quebra de linha'},
        'Gestão de acessos': {
            'PTPT': 'Gestão de acessos'},
        'Ir para': {
            'PTPT': 'Ir para'},
        'Compactar': {
            'PTPT': 'Compactar'},
        'Inserir valor': {
            'PTPT': 'Inserir valor'},
        'Selecionar tipo': {
            'PTPT': 'Selecionar tipo'},
        'Nome da propriedade': {
            'PTPT': 'Nome da propriedade'},
        'Adicionar widget': {
            'PTPT': 'Adicionar widget'},
        'Sem dados para mostrar': {
            'PTPT': 'Sem dados para mostrar'},
        'Para adicionar um widget ao dashboard, arraste e solte ou selecione um widget e clique em %s.': {
            'PTPT': 'Para adicionar um widget ao dashboard, arraste e solte ou selecione um widget e clique em %s.'},
        'Não é possível aceder ao registo especificado': {
            'PTPT': 'Não é possível aceder ao registo especificado'},
        'Relatório de Gestão de Acessos': {
            'PTPT': 'Relatório de Gestão de Acessos'},
        'Time out da sessão': {
            'PTPT': 'Time out da sessão'},
        'Gráfico': {
            'PTPT': 'Gráfico'},
        'Error importing file. No line was inserted.': {
            'PTPT': 'Ocorreu um erro a importar o ficheiro. Nenhuma linha foi processada.'},
        'Error in line {0}:': {
            'PTPT': 'Erro na linha {0}:'},
        'Mensagens a ser exportadas': {
            'PTPT': 'Mensagens a ser exportadas'},
        'Two factor authentication': {
            'PTPT': 'Autenticação de dois factores'},
        'Two factor authentication (2FA) is an security system that requires two separate, distinct forms of identification in order to access': {
            'PTPT': 'A autenticação de 2 factores (2FA) é um mecanismo de segurança que requer duas formas distintas de idenficação para poder aceder a '},
        'The first factor is a password and the second is a TOTP - Time-based One-Time Password or a physical security key': {
            'PTPT': 'O primeiro factor é o utilizador e password e a segunda poderá ser TOTP ou com uma chave de segurança física'},
        'Setup 2FA': {
            'PTPT': 'Configurar 2FA'},
        'Use a Time-based one-time password (TOTP) provided by an application. A 6 digit number provided by the application must be entered during login.': {
            'PTPT': 'Utilizar uma password de tempo limitado (TOTP) obtida a partir de uma aplicação. Um nº de 6 dígitos fornecido pela aplicação deve ser introduzido durante o login.'},
        '1. Install one of the following applications:': {
            'PTPT': '1. Instale uma das seguintes aplicações:'},
        '2. Use the application to scan the QRCode or manually insert the code:': {
            'PTPT': '2. Utilize a aplicação para ler o QRCode ou introduza a chave de configuração manualmente:'},
        '3. Fill the 6 digit code obtained from the application': {
            'PTPT': '3. Coloque a chave de 6 dígitos devolvida pela aplicação'},
        'A security key is a verification method that allows you to securely sign in by plugging in directly into your computer’s USB port.': {
            'PTPT': 'A verificação por chave de segurança utiliza uma chava física que pode ser introduzida diretamente na porta USB do seu computador'},
        'Add security key': {
            'PTPT': 'Adicionar chave'},
        'Security key': {
            'PTPT': 'Chave de segurança'},
        'Make sure you have your security key with you. If you don\'t have a security key you can ': {
            'PTPT': 'Assegure que tem a chave de segurança consigo. Se não tiver nada pode '},
        'order one at a supplier you trust': {
            'PTPT': 'adquirir uma num fornecedor à sua escolha'},
        'Setup': {
            'PTPT': 'Instalar'},
        'A 2nd authentication method must be configured': {
            'PTPT': 'É obrigatória a configuração de um 2º método de autenticação'},
        'It is not allowed to have two "Tabs" from the same form (Insert mode) at same time!': {
            'PTPT': 'Não é permitido ter dois "Tabs" em simultâneo do mesmo formulário em modo "Inserir"!'},
        'Index': {
            'PTPT': 'Index'},
        'Apagar seleção': {
            'PTPT': 'Apagar seleção'},
        'Export to Excel': {
            'PTPT': 'Exportar para Excel'},
        'User Roles': {
            'PTPT': 'Funções dos Utilizadores'},
        'Pesquisa predefinida': {
            'PTPT': 'Pesquisa predefinida'},
        'Mostrar registos quando': {
            'PTPT': 'Mostrar registos quando'},
        'Guardar vista': {
            'PTPT': 'Guardar vista'},
        'Gestor de Vistas': {
            'PTPT': 'Gestor de Vistas'},
        'Limpar Redimensionamento': {
            'PTPT': 'Limpar Redimensionamento'},
        'Mover os registros selecionados para a tab': {
            'PTPT': 'Mover os registros selecionados para a tab'},
        'Escolher ficheiro': {
            'PTPT': 'Escolher ficheiro'},
        'Para alterar a ordem das linhas, use arrastar e soltar. Para mover para cima, use a seta para a esquerda, a seta para cima ou a tecla delete. Para mover para baixo, use a seta para a direita, a seta para baixo ou a tecla Shift. Se estiver usando um leitor de tela, para subir, use a tecla delete. Para descer, use a tecla shift.': {
            'PTPT': 'Para alterar a ordem das linhas, use arrastar e soltar. Para mover para cima, use a seta para a esquerda, a seta para cima ou a tecla delete. Para mover para baixo, use a seta para a direita, a seta para baixo ou a tecla Shift. Se estiver usando um leitor de tela, para subir, use a tecla delete. Para descer, use a tecla shift.'},
        'The log database cannot have the same name as the main one!': {
            'PTPT': 'A base de dados de Logs não pode ser a mesma que a principal!'},
        'Faça o download do arquivo de modelo do Excel clicando no botão abaixo': {
            'PTPT': 'Faça o download do arquivo de modelo do Excel clicando no botão abaixo'},
        'Preencha o ficheiro com a informação necessária': {
            'PTPT': 'Preencha o ficheiro com a informação necessária'},
        'Após preencher o ficheiro clique no botão de submeter para importá-lo': {
            'PTPT': 'Após preencher o ficheiro clique no botão de submeter para importá-lo'},
        'Transfering Logs...': {
            'PTPT': 'A Transferir os Logs...'},
        'Projeto criado com sucesso': {
            'PTPT': 'Projeto criado com sucesso'},
        'Erro ao criar o projeto': {
            'PTPT': 'Erro ao criar o projeto'},
        'Novo projeto': {
            'PTPT': 'Novo projeto'},
        'Língua base': {
            'PTPT': 'Língua base'},
        'Criar novo projeto': {
            'PTPT': 'Criar novo projeto'},
        'A maintenance task has already started.': {
            'PTPT': 'Uma tarefa de manutenção já se encontra a decorrer.'},
        'A maintenance task is already scheduled.': {
            'PTPT': 'Uma tarefa de manutenção já se encontra agendada.'},
        'There has been an internal error starting the maintenance.': {
            'PTPT': 'Ocorreu um erro interno ao iniciar a manutenção.'},
        'Canceling task...': {
            'PTPT': 'A cancelar a tarefa...'},
        'There are no tasks currently running.': {
            'PTPT': 'Atualmente não existem tarefas a decorrer.'},
        'There has been an internal error ending the maintenance.': {
            'PTPT': 'Ocorreu um erro interno a terminar a manutenção.'},
        'ongoing': {
            'PTPT': 'a decorrer'},
        'The maintenance task has started.': {
            'PTPT': 'A tarefa de manutenção foi iniciada.'},
        'reindexing': {
            'PTPT': 'a reindexar'},
        'The maintenance task is currently reindexing.': {
            'PTPT': 'A tarefa de manutenção está a reindexar.'},
        'upgrading': {
            'PTPT': 'a atualizar'},
        'The maintenance task is currently upgrading.': {
            'PTPT': 'A tarefa de manutenção está a atualizar.'},
        'stopped': {
            'PTPT': 'parado'},
        'There is no maintenance task running.': {
            'PTPT': 'Não existe nenhuma tarefa de manutenção a decorrer.'},
        'cancelling': {
            'PTPT': 'a cancelar'},
        'The maintenance task is cancelling.': {
            'PTPT': 'A tarefa de manutenção está a cancelar.'},
        'cancelled': {
            'PTPT': 'cancelado'},
        'The maintenance task has been cancelled.': {
            'PTPT': 'A tarefa de manutenção foi cancelada.'},
        'error': {
            'PTPT': 'erro'},
        'The current status is invalid.': {
            'PTPT': 'O estado atual é invalido.'},
        'WARNING': {
            'PTPT': 'AVISO'},
        'There are different file paths for each app. This may lead to files being missing when accessed.': {
            'PTPT': 'Existem caminhos de ficheiros diferentes para cada aplicação. Isto pode fazer com que ficheiros fiquem em falta ao serem acedidos.'},
        'Do you with to save the changes?': {
            'PTPT': 'Pretende gravar as alterações?'},
        'Migrate Files': {
            'PTPT': 'Migrar Ficheiros'},
        'Document ID': {
            'PTPT': 'ID do Documento'},
        'Field': {
            'PTPT': 'Campo'},
        'File Name': {
            'PTPT': 'Nome do Ficheiro'},
        'File Size': {
            'PTPT': 'Tamanho do Ficheiro'},
        'Files to Migrate': {
            'PTPT': 'Ficheiros por Migrar'},
        'Migrate': {
            'PTPT': 'Migrar'},
        'There is no file path defined! Please configure one before starting.': {
            'PTPT': 'Não existe nenhum caminho para os ficheiros definido! Por favor configure um antes de começar a migração.'},
        'Configuration Error': {
            'PTPT': 'Erro de Configuração'},
        'All files were migrated successfully!': {
            'PTPT': 'Todos os ficheiros foram migrados com sucesso!'},
        'File': {
            'PTPT': 'Ficheiro'},
        'Internal Error: Could not start the migration task.': {
            'PTPT': 'Erro Interno: Não foi possível iniciar a tarefa de migração.'},
        'The file you are trying to download could not be found.': {
            'PTPT': 'O ficheiro que pretende aceder não foi encontrado.'},
        'Essa vista já existe.': {
            'PTPT': 'Essa vista já existe.'},
        'A vista com o nome \'{0}\' não existe.': {
            'PTPT': 'A vista com o nome \'{0}\' não existe.'},
        'Deseja substituí-la por esta?': {
            'PTPT': 'Deseja substituí-la por esta?'},
        'Quer gravar as alterações?': {
            'PTPT': 'Quer gravar as alterações?'},
        'The following files have failed to migrate:': {
            'PTPT': 'Os seguintes ficheiros falharam na migração:'},
        'Starting...': {
            'PTPT': 'A iniciar...'},
        'There has been an error trying to cancel the migration.': {
            'PTPT': 'Ocorreu um erro ao tentar cancelar a migração.'},
        'Operation cancelled successfully!': {
            'PTPT': 'Operação cancelada com sucesso!'},
        'The migration task is already stopped.': {
            'PTPT': 'A tarefa de migração já se encontra parada.'},
        'Application version': {
            'PTPT': 'Versão da aplicação'},
        'Database version': {
            'PTPT': 'Versão da base de dados'},
        'Schema': {
            'PTPT': 'Schema'},
        'Info': {
            'PTPT': 'Info'},
        'The reindex task is already stopped!': {
            'PTPT': 'A reindexação já se encontra parada.'},
        'There has been an error trying to cancel the reindexation': {
            'PTPT': 'Ocorreu um erro ao tentar cancelar a reindexação'},
        'App Migration Version': {
            'PTPT': 'Versão de Migração da App'},
        'Framework change routines': {
            'PTPT': 'Rotinas de mudança de framework'},
        'There is no task running at the moment.': {
            'PTPT': 'Não existem tarefas a correr.'},
        'A iniciar o processo de transferência de dados': {
            'PTPT': 'A iniciar o processo de transferência de dados'},
        'A transferir os dados da tabela {0}': {
            'PTPT': 'A transferir os dados da tabela {0}'},
        'A fonte e o destino não podem ser iguais.': {
            'PTPT': 'A fonte e o destino não podem ser iguais.'},
        'Pesquisa entre datas': {
            'PTPT': 'Pesquisa entre datas'},
        'Não foi possível obter a lista de registos selecionados.': {
            'PTPT': 'Não foi possível obter a lista de registos selecionados.'},
        'Todos Registos Selecionados': {
            'PTPT': 'Todos Registos Selecionados'},
        'Registos Visíveis': {
            'PTPT': 'Registos Visíveis'},
        'FSCrawler': {
            'PTPT': 'FSCrawler'},
        'Importação concluída com sucesso.': {
            'PTPT': 'Importação concluída com sucesso.'},
        'O tipo de login não permite a importação a partir de Active directory.': {
            'PTPT': 'O tipo de login não permite a importação a partir de Active directory.'},
        'Calendário': {
            'PTPT': 'Calendário'},
        'Lista de linhas colapsáveis': {
            'PTPT': 'Lista de linhas colapsáveis'},
        'Clique para mostrar as etapas seguintes': {
            'PTPT': 'Clique para mostrar as etapas seguintes'},
        'Clique para mostrar as etapas anteriores': {
            'PTPT': 'Clique para mostrar as etapas anteriores'},
        'Clique para mostrar as ajudas': {
            'PTPT': 'Clique para mostrar as ajudas'},
        'URL do Backend de Sockets': {
            'PTPT': 'URL do Backend de Sockets'},
        'URL do Backend da API': {
            'PTPT': 'URL do Backend da API'},
        'Não foram selecionados scripts.': {
            'PTPT': 'Não foram selecionados scripts.'},
        'When applying this filter, only the available values that have not yet been used will be displayed.': {
            'PTPT': 'Ao aplicar este filtro, serão apresentados somente os valores disponíveis que ainda não foram usados.'},
        'Tomei Conhecimento': {
            'PTPT': 'Tomei Conhecimento'},
        'User settings': {
            'PTPT': 'Definições do utilizador'},
        'O sistema não foi encontrado.': {
            'PTPT': 'O sistema não foi encontrado.'},
        'Permitir operadores boleanos': {
            'PTPT': 'Permitir operadores boleanos'},
        'Maximum number of files exceeded': {
            'PTPT': 'Número máximo de ficheiros excedido'},
        'File type not allowed': {
            'PTPT': 'Este tipo de ficheiro não é permitido'},
        'File is too large': {
            'PTPT': 'O ficheiro é demasiado grande'},
        'File is too small': {
            'PTPT': 'O ficheiro é demasiado pequeno'},
        'Create new configuration': {
            'PTPT': 'Criar nova configuração'},
        'No configuration file detected': {
            'PTPT': 'Ficheiro de configurações não encontrado'},
        'New configuration created.': {
            'PTPT': 'Foi criada uma nova configuração.'},
        'Configurar o seu projeto': {
            'PTPT': 'Configurar o seu projeto'},
        'Atualizar a base de dados': {
            'PTPT': 'Atualizar a base de dados'},
        'Criar perfil de utilizador': {
            'PTPT': 'Criar perfil de utilizador'},
        'Erro!': {
            'PTPT': 'Erro!'},
        'There was an error creating a new configuration file:': {
            'PTPT': 'Ocorreu um erro a criar o ficheiro de configurações:'},
        'There is no row found with this value. Create a new one?': {
            'PTPT': 'Nenhum registo encontrado com este valor. Criar um novo?'},
        'Use password blacklist': {
            'PTPT': 'Usar blacklist de passwords'},
        'Manage password blacklist': {
            'PTPT': 'Gerir blacklist de passwords'},
        'Blacklisted passwords in database': {
            'PTPT': 'Passwords blacklisted na base de dados'},
        'Delete all blacklisted passwords': {
            'PTPT': 'Apagar todas as passwords blacklisted'},
        'Password vulnerável a listas de passwords conhecidas': {
            'PTPT': 'Password vulnerável a listas de passwords conhecidas'},
        'Mostrar alterações': {
            'PTPT': 'Mostrar alterações'},
        'Escuro': {
            'PTPT': 'Escuro'},
        'Claro': {
            'PTPT': 'Claro'},
        'Tema': {
            'PTPT': 'Tema'},
        'Escreva o seu código aqui...': {
            'PTPT': 'Escreva o seu código aqui...'},
        'O campo {0} tem um endereço inválido.': {
            'PTPT': 'O campo {0} tem um endereço inválido.'},
        'Sistema de Dados Atual': {
            'PTPT': 'Sistema de Dados Atual'},
        'Autenticação na Base de Dados': {
            'PTPT': 'Autenticação na Base de Dados'},
        'Corretor de Mensagens': {
            'PTPT': 'Corretor de Mensagens'},
        'Publicar': {
            'PTPT': 'Publicar'},
        'Inscrever-se': {
            'PTPT': 'Inscrever-se'},
        'Crystal Reports': {
            'PTPT': 'Crystal Reports'},
        'SQL Server Reporting Services': {
            'PTPT': 'SQL Server Reporting Services'},
        'Configurações de Integração com IA': {
            'PTPT': 'Configurações de Integração com IA'},
        'Deverá colocar o endereço onde estão disponíveis os serviços de chatbot, funções dinâmicas, indexação de documentos e outras integrações.': {
            'PTPT': 'Deverá colocar o endereço onde estão disponíveis os serviços de chatbot, funções dinâmicas, indexação de documentos e outras integrações.'},
        'Sistema de Dados de Log': {
            'PTPT': 'Sistema de Dados de Log'},
        'Configurações Gerais': {
            'PTPT': 'Configurações Gerais'},
        'Testar Conexão com o Servidor': {
            'PTPT': 'Testar Conexão com o Servidor'},
        'Não foi encontrado nenhum ficheiro de configuração. Por favor, crie um novo para continuar.': {
            'PTPT': 'Não foi encontrado nenhum ficheiro de configuração. Por favor, crie um novo para continuar.'},
        'Selecione um campo para ver os detalhes.': {
            'PTPT': 'Selecione um campo para ver os detalhes.'},
        'Esta ação está bloqueada porque ainda não existe um ficheiro de configuração. Estará disponível quando o ficheiro de configuração for criado corretamente.': {
            'PTPT': 'Esta ação está bloqueada porque ainda não existe um ficheiro de configuração. Estará disponível quando o ficheiro de configuração for criado corretamente.'},
        'Escolha o formato a partir do qual deseja fazer a exportação': {
            'PTPT': 'Escolha o formato a partir do qual deseja fazer a exportação'},
        'Selecione para mostrar um aviso no aplicativo indicando que você está no ambiente de QA': {
            'PTPT': 'Selecione para mostrar um aviso no aplicativo indicando que você está no ambiente de QA'},
        'O nome do servidor é o nome único desta instância do servidor SQL no seu computador': {
            'PTPT': 'O nome do servidor é o nome único desta instância do servidor SQL no seu computador'},
        'Cria um novo sistema de dados personalizado': {
            'PTPT': 'Cria um novo sistema de dados personalizado'},
        'Será redirecionado em 3 segundos.': {
            'PTPT': 'Será redirecionado em 3 segundos.'},
        'Garantia da Qualidade': {
            'PTPT': 'Garantia da Qualidade'},
        'Avançado': {
            'PTPT': 'Avançado'},
        'Propriedades Avançadas': {
            'PTPT': 'Propriedades Avançadas'},
        'Definições do ecrã': {
            'PTPT': 'Definições do ecrã'},
        'Elasticsearch': {
            'PTPT': 'Elasticsearch'},
        'Descarregar ficheiro de configuração': {
            'PTPT': 'Descarregar ficheiro de configuração'},
        'Expressão Cron inválida': {
            'PTPT': 'Expressão Cron inválida'},
        'Tarefas agendadas': {
            'PTPT': 'Tarefas agendadas'},
        'Tarefa agendada': {
            'PTPT': 'Tarefa agendada'},
        '[Segundo Minuto Hora Dia Mês DiaDaSemana] Ver expressões de agendamento Cron para mais detalhes.': {
            'PTPT': '[Segundo Minuto Hora Dia Mês DiaDaSemana] Ver expressões de agendamento Cron para mais detalhes.'},
        'Agendador': {
            'PTPT': 'Agendador'},
        'Dias para a expiração': {
            'PTPT': 'Dias para a expiração'},
        'Definições da base de dados': {
            'PTPT': 'Definições da base de dados'},
        'Mover para cima': {
            'PTPT': 'Mover para cima'},
        'Mover para baixo': {
            'PTPT': 'Mover para baixo'},
        'Adicionar nova linha após esta': {
            'PTPT': 'Adicionar nova linha após esta'},
        'Arraste e largue para alterar a ordem das linhas': {
            'PTPT': 'Arraste e largue para alterar a ordem das linhas'},
        'Mostrar ajuda': {
            'PTPT': 'Mostrar ajuda'},
        'Expandir linha': {
            'PTPT': 'Expandir linha'},
        'Colapsar linha': {
            'PTPT': 'Colapsar linha'},
        'Imagem utilizada para {0} no formulário': {
            'PTPT': 'Imagem utilizada para {0} no formulário'},
        'Imagem utilizada para {0} na tabela de dados': {
            'PTPT': 'Imagem utilizada para {0} na tabela de dados'},
        'Remover valor': {
            'PTPT': 'Remover valor'},
        'Sistemas de Dados': {
            'PTPT': 'Sistemas de Dados'},
        'Configurar': {
            'PTPT': 'Configurar'},
        'Exibição': {
            'PTPT': 'Exibição'},
        'Sistema de dados padrão': {
            'PTPT': 'Sistema de dados padrão'},
        'Ocultar sistemas de dados': {
            'PTPT': 'Ocultar sistemas de dados'},
        'Nome do Sistema de Dados': {
            'PTPT': 'Nome do Sistema de Dados'},
        'Não foi encontrado nenhum ficheiro de configuração. Os Sistemas de Dados não puderam ser carregados.': {
            'PTPT': 'Não foi encontrado nenhum ficheiro de configuração. Os Sistemas de Dados não puderam ser carregados.'},
        'Os nomes dos Sistemas de Dados devem ser únicos.': {
            'PTPT': 'Os nomes dos Sistemas de Dados devem ser únicos.'},
        'Os nomes das bases de dados devem ser únicos.': {
            'PTPT': 'Os nomes das bases de dados devem ser únicos.'},
        'Sistemas de Dados Inválidos': {
            'PTPT': 'Sistemas de Dados Inválidos'},
        'Deve concluir a configuração dos sistemas de dados marcados na lista.': {
            'PTPT': 'Deve concluir a configuração dos sistemas de dados marcados na lista.'},
        'O sistema de dados usado por omissão ao abrir a aplicação.': {
            'PTPT': 'O sistema de dados usado por omissão ao abrir a aplicação.'},
        'Quando selecionado, o utilizador não poderá alterar o sistema de dados dentro da aplicação.': {
            'PTPT': 'Quando selecionado, o utilizador não poderá alterar o sistema de dados dentro da aplicação.'},
        'Mostrar opções': {
            'PTPT': 'Mostrar opções'},
        'Autenticação de backup': {
            'PTPT': 'Autenticação de backup'},
        'Índices de baixo uso podem afetar negativamente o desempenho da sua aplicação.': {
            'PTPT': 'Índices de baixo uso podem afetar negativamente o desempenho da sua aplicação.'},
        'Durante a Manutenção do Sistema, a sua aplicação estará em modo de só leitura.': {
            'PTPT': 'Durante a Manutenção do Sistema, a sua aplicação estará em modo de só leitura.'},
        'Número de casos': {
            'PTPT': 'Número de casos'},
        'Verificar índices SQL com baixo uso': {
            'PTPT': 'Verificar índices SQL com baixo uso'},
        'Manutenção desativada': {
            'PTPT': 'Manutenção desativada'},
        'Manutenção configurada com sucesso': {
            'PTPT': 'Manutenção configurada com sucesso'},
        'A senha deve ter entre 8 e 16 caracteres e conter no mínimo três tipos de caracteres: letras minúsculas, maiúsculas, números e símbolos especiais.': {
            'PTPT': 'A senha deve ter entre 8 e 16 caracteres e conter no mínimo três tipos de caracteres: letras minúsculas, maiúsculas, números e símbolos especiais.'},
        'É uma chave usada pelo SQL Server para criptografar e descriptografar dados nos seus arquivos de banco de dados (mdf, ldf, ndf, backups) ao usar TDE (Criptografia de Dados Transparente).': {
            'PTPT': 'É uma chave usada pelo SQL Server para criptografar e descriptografar dados nos seus arquivos de banco de dados (mdf, ldf, ndf, backups) ao usar TDE (Criptografia de Dados Transparente).'},
        'Como funciona:': {
            'PTPT': 'Como funciona:'},
        '1. Criação do DEK:': {
            'PTPT': '1. Criação do DEK:'},
        'Um DEK é criado dentro de um banco de dados específico e é usado apenas para TDE.': {
            'PTPT': 'Um DEK é criado dentro de um banco de dados específico e é usado apenas para TDE.'},
        '2. Proteção do DEK:': {
            'PTPT': '2. Proteção do DEK:'},
        'O DEK é protegido por um certificado (comprado ou auto-assinado) armazenado no banco de dados mestre da instância do SQL Server.': {
            'PTPT': 'O DEK é protegido por um certificado (comprado ou auto-assinado) armazenado no banco de dados mestre da instância do SQL Server.'},
        '3. Criptografia/Descriptografia:': {
            'PTPT': '3. Criptografia/Descriptografia:'},
        'Ao abrir o banco de dados, o SQL Server usa o certificado para descriptografar o DEK. Em seguida, usa o DEK para criptografar/descriptografar dados conforme necessário.': {
            'PTPT': 'Ao abrir o banco de dados, o SQL Server usa o certificado para descriptografar o DEK. Em seguida, usa o DEK para criptografar/descriptografar dados conforme necessário.'},
        'Importante lembrar:': {
            'PTPT': 'Importante lembrar:'},
        '- O DEK não pode ser feito backup ou restaurado separadamente. Ele está vinculado ao banco de dados.': {
            'PTPT': '- O DEK não pode ser feito backup ou restaurado separadamente. Ele está vinculado ao banco de dados.'},
        '- Sem o certificado de proteção, o SQL Server não pode acessar os dados criptografados.': {
            'PTPT': '- Sem o certificado de proteção, o SQL Server não pode acessar os dados criptografados.'},
        'Diretrizes de índices': {
            'PTPT': 'Diretrizes de índices'},
        'Os índices do SQL Server são essencialmente cópias dos dados que já existem na tabela, ordenados e filtrados de maneiras diferentes para melhorar o desempenho das consultas executadas.': {
            'PTPT': 'Os índices do SQL Server são essencialmente cópias dos dados que já existem na tabela, ordenados e filtrados de maneiras diferentes para melhorar o desempenho das consultas executadas.'},
        'Os índices do SQL Server são uma excelente ferramenta para melhorar o desempenho das consultas SELECT, mas, ao mesmo tempo, os índices do SQL Server têm efeitos negativos nas atualizações de dados.': {
            'PTPT': 'Os índices do SQL Server são uma excelente ferramenta para melhorar o desempenho das consultas SELECT, mas, ao mesmo tempo, os índices do SQL Server têm efeitos negativos nas atualizações de dados.'},
        'As operações INSERT, UPDATE e DELETE causam a atualização dos índices (consumindo tempo para fazer isso) e, portanto, aumentam os dados que já existem na tabela.': {
            'PTPT': 'As operações INSERT, UPDATE e DELETE causam a atualização dos índices (consumindo tempo para fazer isso) e, portanto, aumentam os dados que já existem na tabela.'},
        'Como resultado, isso aumenta a duração das transações e a execução das consultas e frequentemente pode resultar em travamento, bloqueio, impasse e timeouts de execução bastante frequentes.': {
            'PTPT': 'Como resultado, isso aumenta a duração das transações e a execução das consultas e frequentemente pode resultar em travamento, bloqueio, impasse e timeouts de execução bastante frequentes.'},
        'Para grandes bancos de dados ou tabelas, o espaço de armazenamento também é afetado por índices redundantes.': {
            'PTPT': 'Para grandes bancos de dados ou tabelas, o espaço de armazenamento também é afetado por índices redundantes.'},
        'Um objetivo crítico, de qualquer DBA do SQL Server, é manter os índices, incluindo a criação de índices necessários, mas ao mesmo tempo removendo aqueles que não são utilizados.': {
            'PTPT': 'Um objetivo crítico, de qualquer DBA do SQL Server, é manter os índices, incluindo a criação de índices necessários, mas ao mesmo tempo removendo aqueles que não são utilizados.'},
        'No entanto, os dados presentes contêm apenas os dados desde a última reinicialização do serviço SQL Server.': {
            'PTPT': 'No entanto, os dados presentes contêm apenas os dados desde a última reinicialização do serviço SQL Server.'},
        'Portanto, é essencial que haja um tempo suficiente desde a última reinicialização do SQL Server, que permita determinar corretamente quais índices são bons candidatos para serem removidos ou criados.': {
            'PTPT': 'Portanto, é essencial que haja um tempo suficiente desde a última reinicialização do SQL Server, que permita determinar corretamente quais índices são bons candidatos para serem removidos ou criados.'},
        'Os operadores seeks, scans e lookups são usados para acessar os índices do SQL Server.': {
            'PTPT': 'Os operadores seeks, scans e lookups são usados para acessar os índices do SQL Server.'},
        'Dicas de colunas:': {
            'PTPT': 'Dicas de colunas:'},
        'Seeks': {
            'PTPT': 'Seeks'},
        '- Recupera apenas as linhas selecionadas.': {
            'PTPT': '- Recupera apenas as linhas selecionadas.'},
        'Scans': {
            'PTPT': 'Scans'},
        '- Recupera todas as linhas.': {
            'PTPT': '- Recupera todas as linhas.'},
        'Lookups': {
            'PTPT': 'Lookups'},
        '- Recupera informações de coluna nos dados não-chave do conjunto de índices não clusterizados.': {
            'PTPT': '- Recupera informações de coluna nos dados não-chave do conjunto de índices não clusterizados.'},
        '- Benefício que as consultas (com colunas apresentadas no índice) poderiam experimentar se o índice ausente fosse implementado (reduzindo o custo da consulta em %).': {
            'PTPT': '- Benefício que as consultas (com colunas apresentadas no índice) poderiam experimentar se o índice ausente fosse implementado (reduzindo o custo da consulta em %).'},
        '- Melhoria multiplicada por Seeks e Scans. Isso significa que um valor maior terá mais impacto devido ao fato de que o índice ausente será (estatisticamente) usado com mais frequência.': {
            'PTPT': '- Melhoria multiplicada por Seeks e Scans. Isso significa que um valor maior terá mais impacto devido ao fato de que o índice ausente será (estatisticamente) usado com mais frequência.'},
        'Por favor, preencha todos os campos obrigatórios para testar a ligação.': {
            'PTPT': 'Por favor, preencha todos os campos obrigatórios para testar a ligação.'},
        'Cron é necessário': {
            'PTPT': 'Cron é necessário'},
        'Selecione para mostrar um aviso na aplicação informativo que está no ambiente de QA': {
            'PTPT': 'Selecione para mostrar um aviso na aplicação informativo que está no ambiente de QA'},
        'Garantia de Qualidade': {
            'PTPT': 'Garantia de Qualidade'},
        'Executar Backup': {
            'PTPT': 'Executar Backup'},
        'Executar atualização': {
            'PTPT': 'Executar atualização'},
        'Incoerência de relações': {
            'PTPT': 'Incoerência de relações'},
        'Registos Órfãos': {
            'PTPT': 'Registos Órfãos'},
        'Diferentes caminhos para o mesmo destino': {
            'PTPT': 'Diferentes caminhos para o mesmo destino'},
        'Chave preenchida sem existir o registo correspondente': {
            'PTPT': 'Chave preenchida sem existir o registo correspondente'},
        'Agendar a Manutenção do Sistema': {
            'PTPT': 'Agendar a Manutenção do Sistema'},
        'OAuth2 options are required.': {
            'PTPT': 'As opções OAuth2 são obrigatórias.'},
        'Either \'Client Secret\' or \'Certificate\' must be provided.': {
            'PTPT': 'Deve ser fornecido o \'Client Secret\' ou o \'Certificado\'.'},
        'If the certificate is defined, it will be used as it is a more secure method than the Client Secret.': {
            'PTPT': 'Se o certificado estiver definido, ele será usado, pois é um método mais seguro do que o Client Secret.'},
        'Enter the text you see on the image': {
            'PTPT': 'Insira o texto que vê na imagem'},
        'Invalid captcha': {
            'PTPT': 'Captcha inválido'},
        'Regular': {
            'PTPT': 'Regular'},
        'Admin': {
            'PTPT': 'Admin'},
        'Este nome já existe!': {
            'PTPT': 'Este nome já existe!'},
        'TODOS OS UTILIZADORES': {
            'PTPT': 'TODOS OS UTILIZADORES'},
        'Filtrar por Módulos': {
            'PTPT': 'Filtrar por Módulos'},
        'Configuração do Utilizador': {
            'PTPT': 'Configuração do Utilizador'},
        'Utilizador criado com sucesso': {
            'PTPT': 'Utilizador criado com sucesso'},
        'Utilizador alterado com sucesso': {
            'PTPT': 'Utilizador alterado com sucesso'},
        'Utilizador excluído com sucesso': {
            'PTPT': 'Utilizador excluído com sucesso'},
        'Erro ao exportar o ficheiro': {
            'PTPT': 'Erro ao exportar o ficheiro'},
        'Pesquisar nome': {
            'PTPT': 'Pesquisar nome'},
        'Pesquisar módulo': {
            'PTPT': 'Pesquisar módulo'},
        'Todas as funções': {
            'PTPT': 'Todas as funções'},
        'Descrição da Função': {
            'PTPT': 'Descrição da Função'},
        'Atribuir Utilizadores': {
            'PTPT': 'Atribuir Utilizadores'},
        'Configurações não encontradas.': {
            'PTPT': 'Configurações não encontradas.'},
        'O Código não pode ser nulo': {
            'PTPT': 'O Código não pode ser nulo'},
        'Função atribuída aos utilizadores com sucesso.': {
            'PTPT': 'Função atribuída aos utilizadores com sucesso.'},
        'Selecione os utilizadores para atribuir a esta função': {
            'PTPT': 'Selecione os utilizadores para atribuir a esta função'},
        'Não foi possível eliminar o utilizador': {
            'PTPT': 'Não foi possível eliminar o utilizador'},
        'Parâmetros inválidos': {
            'PTPT': 'Parâmetros inválidos'},
        'Associação não encontrada': {
            'PTPT': 'Associação não encontrada'},
        'Pesquisar utilizador': {
            'PTPT': 'Pesquisar utilizador'},
        'Erro ao carregar utilizadores': {
            'PTPT': 'Erro ao carregar utilizadores'},
        'Utilizador adicionado com sucesso': {
            'PTPT': 'Utilizador adicionado com sucesso'},
        'Informação da aplicação': {
            'PTPT': 'Informação da aplicação'},
        'Informação das bases de dados': {
            'PTPT': 'Informação das bases de dados'},
        'Versão dos scripts de subida': {
            'PTPT': 'Versão dos scripts de subida'},
        'Versão do índice de subida da BD': {
            'PTPT': 'Versão do índice de subida da BD'},
        'Existem sistemas de dados que precisam executar as tarefas de manutenção da base de dados devido à incompatibilidade entre a versão da base de dados e a versão da aplicação.': {
            'PTPT': 'Existem sistemas de dados que precisam executar as tarefas de manutenção da base de dados devido à incompatibilidade entre a versão da base de dados e a versão da aplicação.'},
        'Nome da BD': {
            'PTPT': 'Nome da BD'},
        '+Info': {
            'PTPT': '+Info'},
        'Não foi possível detetar nenhum sistema de dados. Por favor, configure o sistema para prosseguir.': {
            'PTPT': 'Não foi possível detetar nenhum sistema de dados. Por favor, configure o sistema para prosseguir.'},
        'Não foi selecionado nenhum script de manutenção.': {
            'PTPT': 'Não foi selecionado nenhum script de manutenção.'},
        'Report format': {
            'PTPT': 'Formato do relatório'},
        'O formato de relatório selecionado não é permitido': {
            'PTPT': 'O formato de relatório selecionado não é permitido'},
        'MS Word': {
            'PTPT': 'MS Word'},
        'MS Excel': {
            'PTPT': 'MS Excel'},
        'RTF': {
            'PTPT': 'RTF'},
        'Report Viewer': {
            'PTPT': 'Report Viewer'},
        'Deseja gravar esta ficha?': {
            'PTPT': 'Deseja gravar esta ficha?'},
        'Deseja eliminar esta ficha?': {
            'PTPT': 'Deseja eliminar esta ficha?'},
        'Atenção! Utilizador alterado. Algumas das funções foram ignoradas porque eram redundantes:': {
            'PTPT': 'Atenção! Utilizador alterado. Algumas das funções foram ignoradas porque eram redundantes:'},
        'Por favor, escolha um sistema de dados para executar as tarefas de manutenção, utilizando a dropdown dos sistemas de dados no canto superior direito da aplicação.': {
            'PTPT': 'Por favor, escolha um sistema de dados para executar as tarefas de manutenção, utilizando a dropdown dos sistemas de dados no canto superior direito da aplicação.'},
        'Started at': {
            'PTPT': 'Começado em'},
        'Tarefa bem sucedida': {
            'PTPT': 'Tarefa bem sucedida'},
        'Last maintenance job': {
            'PTPT': 'Última tarefa de manutenção'},
        'Sistema de dados': {
            'PTPT': 'Sistema de dados'},
        'Finalizar': {
            'PTPT': 'Finalizar'},
        'Reenviar': {
            'PTPT': 'Reenviar'},
        'Tabelas partilhadas': {
            'PTPT': 'Tabelas partilhadas'},
        'Tem a certeza que quer apagar o backup?': {
            'PTPT': 'Tem a certeza que quer apagar o backup?'},
        'Gestão de Funções de Utilizadores em Massa': {
            'PTPT': 'Gestão de Funções de Utilizadores em Massa'},
        'Atribuir rapidamente um grupo de utilizadores a múltiplas funções': {
            'PTPT': 'Atribuir rapidamente um grupo de utilizadores a múltiplas funções'},
        '1. Selecione utilizadores: Escolha os utilizadores que deseja atribuir.': {
            'PTPT': '1. Selecione utilizadores: Escolha os utilizadores que deseja atribuir.'},
        '2. Selecione funções: Selecione as funções que deseja atribuir.': {
            'PTPT': '2. Selecione funções: Selecione as funções que deseja atribuir.'},
        '3. Reveja e confirme: Pré-visualize as suas alterações e confirme-as para aplicar aos utilizadores selecionados.': {
            'PTPT': '3. Reveja e confirme: Pré-visualize as suas alterações e confirme-as para aplicar aos utilizadores selecionados.'},
        'Color Picker': {
            'PTPT': 'Seletor de Cores'},
        'IA e Serviços Externos': {
            'PTPT': 'IA e Serviços Externos'},
        'Sistema de Mensagens': {
            'PTPT': 'Sistema de Mensagens'},
        'Mensagens Queue Server': {
            'PTPT': 'Mensagens Queue Server'},
        'Propriedades Extra': {
            'PTPT': 'Propriedades Extra'},
        'Origem': {
            'PTPT': 'Origem'},
        'Maintenance Details': {
            'PTPT': 'Detalhes da Manutenção'},
        'Tarefas': {
            'PTPT': 'Tarefas'},
        'No data to display for the selected maintenance tasks.': {
            'PTPT': 'Não há dados para exibir para as tarefas de manutenção selecionadas.'},
        'Resumo': {
            'PTPT': 'Resumo'},
        'An error occured while retrieving the maintenance details. Please check the logs for more information.': {
            'PTPT': 'Ocorreu um erro a recuperar os detalhes pretendidos. Consulte os logs para mais informação.'},
        'Últimas 20 entradas': {
            'PTPT': 'Últimas 20 entradas'},
        'O sistema de dados foi apagado com sucesso.': {
            'PTPT': 'O sistema de dados foi apagado com sucesso.'},
        'O sistema de dados atual foi definido como o pré-definido.': {
            'PTPT': 'O sistema de dados atual foi definido como o pré-definido.'},
        'Tem a certeza que quer apagar o sistema de dados': {
            'PTPT': 'Tem a certeza que quer apagar o sistema de dados'},
        'Mudar o nome': {
            'PTPT': 'Mudar o nome'},
        'Nenhum sistema de dados selecionado para a manutenção.': {
            'PTPT': 'Nenhum sistema de dados selecionado para a manutenção.'},
        'As suas alterações serão perdidas se sair!': {
            'PTPT': 'As suas alterações serão perdidas se sair!'},
        'Descartar alterações': {
            'PTPT': 'Descartar alterações'},
        'Especifica o caminho físico do diretório onde os ficheiros dos relatórios estão armazenados.': {
            'PTPT': 'Especifica o caminho físico do diretório onde os ficheiros dos relatórios estão armazenados.'},
        'Reporting Services': {
            'PTPT': 'Reporting Services'},
        'Utilizado para carregar os relatórios diretamente na aplicação.': {
            'PTPT': 'Utilizado para carregar os relatórios diretamente na aplicação.'},
        'Permite verificar no menu Gestão de Relatórios se as versões locais estão atualizadas face às publicadas no URL do Reporting Services.': {
            'PTPT': 'Permite verificar no menu Gestão de Relatórios se as versões locais estão atualizadas face às publicadas no URL do Reporting Services.'},
        'Editor': {
            'PTPT': 'Editor'},
        'Editor e Pré-visualização': {
            'PTPT': 'Editor e Pré-visualização'},
        'Preview': {
            'PTPT': 'Pré-visualização'},
        'Full screen': {
            'PTPT': 'Ecrã inteiro'},
        'Add bold text': {
            'PTPT': 'Adicionar texto em negrito'},
        'Add italic text': {
            'PTPT': 'Adicionar texto em itálico'},
        'Add heading text': {
            'PTPT': 'Adicionar texto de título'},
        'Add strikethrough text': {
            'PTPT': 'Adicionar texto com riscado'},
        'Insert a quote': {
            'PTPT': 'Inserir uma citação'},
        'Insert code block': {
            'PTPT': 'Inserir bloco de código'},
        'Add a link': {
            'PTPT': 'Adicionar uma ligação'},
        'Add a bullet list': {
            'PTPT': 'Adicionar uma lista com marcadores'},
        'Add a numbered list': {
            'PTPT': 'Adicionar uma lista numerada'},
        'Add a checklist': {
            'PTPT': 'Adicionar uma lista de verificação'},
        'Add a horizontal rule': {
            'PTPT': 'Adicionar uma linha horizontal'},
        'Add a table': {
            'PTPT': 'Adicionar uma tabela'},
        'Add an image': {
            'PTPT': 'Adicionar uma imagem'},
        'Gestão de Ficheiros': {
            'PTPT': 'Gestão de Ficheiros'},
        'Escolher um ficheiro...': {
            'PTPT': 'Escolher um ficheiro...'},
        'Conexão bem-sucedida': {
            'PTPT': 'Conexão bem-sucedida'},
        'Falha na conexão': {
            'PTPT': 'Falha na conexão'},
        'Ativo': {
            'PTPT': 'Ativo'},
        'A chamar o agente de IA': {
            'PTPT': 'A chamar o agente de IA'},
        'Centrar no mapa': {
            'PTPT': 'Centrar no mapa'},
        'Voltar para': {
            'PTPT': 'Voltar para'},
        'Erro ao atualizar a palavra-passe em': {
            'PTPT': 'Erro ao atualizar a palavra-passe em'},
        'Falha na autenticação. As credenciais estão incorretas.': {
            'PTPT': 'Falha na autenticação. As credenciais estão incorretas.'},
        'Insert below': {
            'PTPT': 'Inserir abaixo'},
        'A exportação não pôde ser concluída: não há colunas que possam ser exportadas.': {
            'PTPT': 'A exportação não pôde ser concluída: não há colunas que possam ser exportadas.'}
	}

    return messages;
}


//***************************************************************** Qformatset - define parametros de formatação de numeros e datas
function QformatSet(langcode, datefmt, timefmt, sepdec, sep1000) {
	this.LangCode=langcode;
	this.DateFmt=datefmt;
	this.TimeFmt=timefmt;
	this.SepDec=sepdec;
	this.Sep1000=sep1000;
}
