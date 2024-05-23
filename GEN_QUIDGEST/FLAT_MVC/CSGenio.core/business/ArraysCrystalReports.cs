using System;
using System.Text;
using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Classe que representa a definição das arrays como formulas to listagens no Crystal Reports.
	/// </summary>
    public class ArraysCrystalReports
    {
        /// <summary>
        /// variável que vai ter todas as áreas
        /// </summary>
        private static Dictionary<string, string> todasArrays;

        static ArraysCrystalReports()
		{
            todasArrays = new Dictionary<string, string>();

            StringBuilder Qresult = new StringBuilder();
            
			// a_categ
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"G\" then \"Global\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"Nacional\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("a_categ", Qresult.ToString());
			// a_facili
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Factible\" else");
			            Qresult.AppendLine("if {{{0}}} = \"ND\" then \"No Disponible\" else");
			            Qresult.AppendLine("if {{{0}}} = \"NA\" then \"No Aplica\" else");
			            Qresult.AppendLine("if {{{0}}} = \"NF\" then \"No Factible\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("a_facili", Qresult.ToString());
			// a_nivele
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Nivel I\" else");
			            Qresult.AppendLine("if {{{0}}} = \"II\" then \"Nivel II\" else");
			            Qresult.AppendLine("if {{{0}}} = \"III\" then \"Nivel III\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("a_nivele", Qresult.ToString());
			// accustos
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Sim\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"Não\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Não existe CC (contabilidade de custos)\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("accustos", Qresult.ToString());
			// active
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"Y\" then \"Yes\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"No\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("active", Qresult.ToString());
			// activida
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"Active\" else");
			            Qresult.AppendLine("if {{{0}}} = \"0\" then \"Inactivo\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("activida", Qresult.ToString());
			// adatqual
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 5 then \"Muito Boa\" else");
			Qresult.AppendLine("if {{{0}}} = 4 then \"Boa\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"Razoável\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Má\" else");
			Qresult.AppendLine("if {{{0}}} = 1 then \"Muito Má\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("adatqual", Qresult.ToString());
			// addresst
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"postal\" then \"Postal\" else");
			            Qresult.AppendLine("if {{{0}}} = \"physical\" then \"Physical\" else");
			            Qresult.AppendLine("if {{{0}}} = \"both\" then \"Postal & Physical\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("addresst", Qresult.ToString());
			// addressu
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"home\" then \"Home\" else");
			            Qresult.AppendLine("if {{{0}}} = \"work\" then \"Work\" else");
			            Qresult.AppendLine("if {{{0}}} = \"temp\" then \"Temporary\" else");
			            Qresult.AppendLine("if {{{0}}} = \"old\" then \"Old / Incorrect\" else");
			            Qresult.AppendLine("if {{{0}}} = \"billing\" then \"Billing\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("addressu", Qresult.ToString());
			// addrtyco
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"Bill To\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Ship To\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("addrtyco", Qresult.ToString());
			// aestadm
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"DELAYED\" then \"Adiado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"COMPLETE\" then \"Concluído\" else");
			            Qresult.AppendLine("if {{{0}}} = \"ONCOURSE\" then \"Em Curso\" else");
			            Qresult.AppendLine("if {{{0}}} = \"CLOSED\" then \"Encerrado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"STOPPED\" then \"Parado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"PLANNED\" then \"Planeado\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aestadm", Qresult.ToString());
			// aestado
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"DELAYED\" then \"Adiada\" else");
			            Qresult.AppendLine("if {{{0}}} = \"COMPLETE\" then \"Concluída\" else");
			            Qresult.AppendLine("if {{{0}}} = \"ONCOURSE\" then \"Em Curso\" else");
			            Qresult.AppendLine("if {{{0}}} = \"CLOSED\" then \"Encerrada\" else");
			            Qresult.AppendLine("if {{{0}}} = \"STOPPED\" then \"Parada\" else");
			            Qresult.AppendLine("if {{{0}}} = \"PLANNED\" then \"Planeada\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aestado", Qresult.ToString());
			// aestrate
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"P\" then \"Produtividade\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Crescimento\" else");
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Prod. e Cresc.\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"N/A\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aestrate", Qresult.ToString());
			// aganttun
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"day\" then \"Day\" else");
			            Qresult.AppendLine("if {{{0}}} = \"week\" then \"Semana\" else");
			            Qresult.AppendLine("if {{{0}}} = \"month\" then \"Mês\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aganttun", Qresult.ToString());
			// ahorasse
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 35 then \"35\" else");
			Qresult.AppendLine("if {{{0}}} = 40 then \"40\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("ahorasse", Qresult.ToString());
			// alaglead
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"LG\" then \"Lag\" else");
			            Qresult.AppendLine("if {{{0}}} = \"LD\" then \"Lead\" else");
			            Qresult.AppendLine("if {{{0}}} = \"RE\" then \"Resultados\" else");
			            Qresult.AppendLine("if {{{0}}} = \"EF\" then \"Eficacia\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("alaglead", Qresult.ToString());
			// alocregr
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Tabela\" else");
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Form\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("alocregr", Qresult.ToString());
			// ameses
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"Janeiro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"2\" then \"Fevereiro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"3\" then \"Março\" else");
			            Qresult.AppendLine("if {{{0}}} = \"4\" then \"Abril\" else");
			            Qresult.AppendLine("if {{{0}}} = \"5\" then \"Maio\" else");
			            Qresult.AppendLine("if {{{0}}} = \"6\" then \"Junho\" else");
			            Qresult.AppendLine("if {{{0}}} = \"7\" then \"Julho\" else");
			            Qresult.AppendLine("if {{{0}}} = \"8\" then \"Agosto\" else");
			            Qresult.AppendLine("if {{{0}}} = \"9\" then \"Setembro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"10\" then \"Outubro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"11\" then \"Novembro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"12\" then \"Dezembro\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("ameses", Qresult.ToString());
			// aperacum
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"P\" then \"Período\" else");
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Acumulado\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aperacum", Qresult.ToString());
			// aperiodi
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"Horário\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Diário\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"Semanal\" else");
			Qresult.AppendLine("if {{{0}}} = 4 then \"Mensal\" else");
			Qresult.AppendLine("if {{{0}}} = 10 then \"Bimestral\" else");
			Qresult.AppendLine("if {{{0}}} = 5 then \"Trimestral\" else");
			Qresult.AppendLine("if {{{0}}} = 6 then \"Semestral\" else");
			Qresult.AppendLine("if {{{0}}} = 7 then \"Anual\" else");
			Qresult.AppendLine("if {{{0}}} = 9 then \"Variável\" else");
			Qresult.AppendLine("if {{{0}}} = 11 then \"Bianual\" else");
			Qresult.AppendLine("if {{{0}}} = 12 then \"5 anos\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aperiodi", Qresult.ToString());
			// apolarid
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"CR\" then \"Maior é Melhor\" else");
			            Qresult.AppendLine("if {{{0}}} = \"DE\" then \"Menor é Melhor\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Centrada\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("apolarid", Qresult.ToString());
			// apriorid
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"HIGH\" then \"High\" else");
			            Qresult.AppendLine("if {{{0}}} = \"MEDIUM\" then \"Average\" else");
			            Qresult.AppendLine("if {{{0}}} = \"LOW\" then \"Low\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("apriorid", Qresult.ToString());
			// areatecn
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Mechanical\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Electricity\" else");
			            Qresult.AppendLine("if {{{0}}} = \"L\" then \"Cleaning\" else");
			            Qresult.AppendLine("if {{{0}}} = \"G\" then \"Management\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("areatecn", Qresult.ToString());
			// arecolha
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Utilização de dados administrativos\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Recolha direta dos Dados\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Conjunto de dados Estatísticos e administrativos\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("arecolha", Qresult.ToString());
			// ascorout
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"TREE\" then \"Árvore\" else");
			            Qresult.AppendLine("if {{{0}}} = \"LIST\" then \"Lista\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("ascorout", Qresult.ToString());
			// aside
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"L\" then \"Left\" else");
			            Qresult.AppendLine("if {{{0}}} = \"R\" then \"Right\" else");
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Top\" else");
			            Qresult.AppendLine("if {{{0}}} = \"B\" then \"Bottom\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("aside", Qresult.ToString());
			// asimnao
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"0\" then \"-\" else");
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Sim\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"Não\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("asimnao", Qresult.ToString());
			// assettyp
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Equipment\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Commodity\" else");
			            Qresult.AppendLine("if {{{0}}} = \"B\" then \"Building\" else");
			            Qresult.AppendLine("if {{{0}}} = \"L\" then \"Land\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Office supplies\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("assettyp", Qresult.ToString());
			// atipoind
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"IMPACT\" then \"Impacto\" else");
			            Qresult.AppendLine("if {{{0}}} = \"RESULT\" then \"Resultados\" else");
			            Qresult.AppendLine("if {{{0}}} = \"PROCES\" then \"Processos\" else");
			            Qresult.AppendLine("if {{{0}}} = \"PRODU\" then \"Produto\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atipoind", Qresult.ToString());
			// atipopro
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"PR\" then \"Programa\" else");
			            Qresult.AppendLine("if {{{0}}} = \"PJ\" then \"Proyecto\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Componente\" else");
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Acción\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atipopro", Qresult.ToString());
			// atipouo
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Interno\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Externo\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atipouo", Qresult.ToString());
			// atpactiv
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"0\" then \"Recorrente\" else");
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"Encadeada\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpactiv", Qresult.ToString());
			// atpacumu
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"U\" then \"Valor Único\" else");
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Somatório\" else");
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Average\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Contagem\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpacumu", Qresult.ToString());
			// atpavali
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Dirigentes e Funcionários\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Dirigentes\" else");
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Funcionários\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Unidade Orgânica\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpavali", Qresult.ToString());
			// atpbonif
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Automáticas\" else");
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Manuais\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpbonif", Qresult.ToString());
			// atpindic
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"Q\" then \"Qualidade\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Eficiência\" else");
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Eficácia\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpindic", Qresult.ToString());
			// atpmes
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Período Seguinte\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Período Actual\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpmes", Qresult.ToString());
			// atpmeta
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"SUM\" then \"Soma\" else");
			            Qresult.AppendLine("if {{{0}}} = \"AVG\" then \"Average\" else");
			            Qresult.AppendLine("if {{{0}}} = \"NAN\" then \"Nenhuma\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpmeta", Qresult.ToString());
			// atpscore
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"EVAL\" then \"Avaliação\" else");
			            Qresult.AppendLine("if {{{0}}} = \"MONI\" then \"Monitorização\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpscore", Qresult.ToString());
			// atpseg
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"SEX\" then \"Sexo\" else");
			            Qresult.AppendLine("if {{{0}}} = \"SEC\" then \"Sector\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("atpseg", Qresult.ToString());
			// avisperi
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 4 then \"Mensal\" else");
			Qresult.AppendLine("if {{{0}}} = 5 then \"Trimestral\" else");
			Qresult.AppendLine("if {{{0}}} = 6 then \"Semestral\" else");
			Qresult.AppendLine("if {{{0}}} = 7 then \"Anual\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("avisperi", Qresult.ToString());
			// bankcomp
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"ST\" then \"Santander\" else");
			            Qresult.AppendLine("if {{{0}}} = \"CB\" then \"Caixa Bank\" else");
			            Qresult.AppendLine("if {{{0}}} = \"IG\" then \"ING\" else");
			            Qresult.AppendLine("if {{{0}}} = \"NB\" then \"Novobanco\" else");
			            Qresult.AppendLine("if {{{0}}} = \"AB\" then \"ActivoBank\" else");
			            Qresult.AppendLine("if {{{0}}} = \"OB\" then \"OpenBank\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("bankcomp", Qresult.ToString());
			// class
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"1C\" then \"1ªClasse\" else");
			            Qresult.AppendLine("if {{{0}}} = \"2C\" then \"2ªClasse\" else");
			            Qresult.AppendLine("if {{{0}}} = \"CE\" then \"Classe Económica\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("class", Qresult.ToString());
			// classnum
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"1º Classe\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"2ª Classe\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"Económica\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("classnum", Qresult.ToString());
			// datatype
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Text\" else");
			            Qresult.AppendLine("if {{{0}}} = \"N\" then \"Numeric\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Date\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("datatype", Qresult.ToString());
			// decplace
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 0 then \"None\" else");
			Qresult.AppendLine("if {{{0}}} = 1 then \"One\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Two\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"Three\" else");
			Qresult.AppendLine("if {{{0}}} = 4 then \"Four\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("decplace", Qresult.ToString());
			// dispstat
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Preparing\" else");
			            Qresult.AppendLine("if {{{0}}} = \"P\" then \"Prepared\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Dispatched\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("dispstat", Qresult.ToString());
			// dsiponib
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Disponível\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Descontinuado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Sem existências\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("dsiponib", Qresult.ToString());
			// faciltyp
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"B\" then \"Building\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Container depot\" else");
			            Qresult.AppendLine("if {{{0}}} = \"P\" then \"Park\" else");
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Ship\" else");
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Airplane\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Office\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("faciltyp", Qresult.ToString());
			// freqempr
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 7 then \"Average\" else");
			Qresult.AppendLine("if {{{0}}} = 1 then \"High\" else");
			Qresult.AppendLine("if {{{0}}} = 15 then \"Low\" else");
			Qresult.AppendLine("if {{{0}}} = 30 then \"Rare\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("freqempr", Qresult.ToString());
			// genconta
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Phone\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Email\" else");
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Address\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Other\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("genconta", Qresult.ToString());
			// gender
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Male\" else");
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Female\" else");
			            Qresult.AppendLine("if {{{0}}} = \"O\" then \"Other\" else");
			            Qresult.AppendLine("if {{{0}}} = \"U\" then \"Unknown\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("gender", Qresult.ToString());
			// genero
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Male\" else");
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Female\" else");
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Undifferentiated\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("genero", Qresult.ToString());
			// gpsinput
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"L\" then \"Latitude and Longitude\" else");
			            Qresult.AppendLine("if {{{0}}} = \"P\" then \"Point in Map\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("gpsinput", Qresult.ToString());
			// identtyp
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Individual\" else");
			            Qresult.AppendLine("if {{{0}}} = \"R\" then \"Returnable\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("identtyp", Qresult.ToString());
			// months
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"January\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"February\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"March\" else");
			Qresult.AppendLine("if {{{0}}} = 4 then \"April\" else");
			Qresult.AppendLine("if {{{0}}} = 5 then \"May\" else");
			Qresult.AppendLine("if {{{0}}} = 6 then \"June\" else");
			Qresult.AppendLine("if {{{0}}} = 7 then \"July\" else");
			Qresult.AppendLine("if {{{0}}} = 8 then \"August\" else");
			Qresult.AppendLine("if {{{0}}} = 9 then \"September\" else");
			Qresult.AppendLine("if {{{0}}} = 10 then \"October\" else");
			Qresult.AppendLine("if {{{0}}} = 11 then \"November\" else");
			Qresult.AppendLine("if {{{0}}} = 12 then \"December\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("months", Qresult.ToString());
			// objetype
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"Account\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Contact\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("objetype", Qresult.ToString());
			// phonepre
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"USA\" then \"+1\" else");
			            Qresult.AppendLine("if {{{0}}} = \"ESP\" then \"+34\" else");
			            Qresult.AppendLine("if {{{0}}} = \"POR\" then \"+351\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("phonepre", Qresult.ToString());
			// primviag
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"Yes\" else");
			            Qresult.AppendLine("if {{{0}}} = \"0\" then \"No\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("primviag", Qresult.ToString());
			// qartipqu
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"Não Conformidades\" else");
			            Qresult.AppendLine("if {{{0}}} = \"2\" then \"Reclamações\" else");
			            Qresult.AppendLine("if {{{0}}} = \"3\" then \"Acções Preventivas\" else");
			            Qresult.AppendLine("if {{{0}}} = \"4\" then \"Acções Correctivas\" else");
			            Qresult.AppendLine("if {{{0}}} = \"5\" then \"Acções de Melhoria\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("qartipqu", Qresult.ToString());
			// radiobtn
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"Radio\" then \"Radio\" else");
			            Qresult.AppendLine("if {{{0}}} = \"op2\" then \"Opção 2\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("radiobtn", Qresult.ToString());
			// s_modpro
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"INDIV\" then \"Individual\" else");
			            Qresult.AppendLine("if {{{0}}} = \"global\" then \"Global\" else");
			            Qresult.AppendLine("if {{{0}}} = \"unidade\" then \"Unidade orgânica\" else");
			            Qresult.AppendLine("if {{{0}}} = \"horario\" then \"Horário\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_modpro", Qresult.ToString());
			// s_module
            Qresult = new StringBuilder();
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_module", Qresult.ToString());
			// s_prstat
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"EE\" then \"Em execução\" else");
			            Qresult.AppendLine("if {{{0}}} = \"FE\" then \"Em fila de espera\" else");
			            Qresult.AppendLine("if {{{0}}} = \"AG\" then \"Agendado para execução\" else");
			            Qresult.AppendLine("if {{{0}}} = \"T\" then \"Terminado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Cancelado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"NR\" then \"Não responde\" else");
			            Qresult.AppendLine("if {{{0}}} = \"AB\" then \"Abortado\" else");
			            Qresult.AppendLine("if {{{0}}} = \"AC\" then \"A cancelar\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_prstat", Qresult.ToString());
			// s_resul
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"ok\" then \"Sucesso\" else");
			            Qresult.AppendLine("if {{{0}}} = \"er\" then \"Erro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"wa\" then \"Aviso\" else");
			            Qresult.AppendLine("if {{{0}}} = \"c\" then \"Cancelado\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_resul", Qresult.ToString());
			// s_roles
            Qresult = new StringBuilder();
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_roles", Qresult.ToString());
			// s_tpproc
            Qresult = new StringBuilder();
            Qresult.Append("\"                                              \"");
            todasArrays.Add("s_tpproc", Qresult.ToString());
			// sexo
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"Masculino\" then \"Male\" else");
			            Qresult.AppendLine("if {{{0}}} = \"Feminino\" then \"Female\" else");
			            Qresult.AppendLine("if {{{0}}} = \"Outro\" then \"Other\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("sexo", Qresult.ToString());
			// spacetyp
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"F\" then \"Floor\" else");
			            Qresult.AppendLine("if {{{0}}} = \"R\" then \"Room\" else");
			            Qresult.AppendLine("if {{{0}}} = \"S\" then \"Shelf\" else");
			            Qresult.AppendLine("if {{{0}}} = \"Y\" then \"Yard\" else");
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Another\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("spacetyp", Qresult.ToString());
			// tipoarti
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"B\" then \"Very mobile\" else");
			            Qresult.AppendLine("if {{{0}}} = \"V\" then \"Vehicle\" else");
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Property\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("tipoarti", Qresult.ToString());
			// tipocond
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"W\" then \"Warning\" else");
			            Qresult.AppendLine("if {{{0}}} = \"E\" then \"Erro\" else");
			            Qresult.AppendLine("if {{{0}}} = \"M\" then \"Obrigatório\" else");
			            Qresult.AppendLine("if {{{0}}} = \"I\" then \"Inserir\" else");
			            Qresult.AppendLine("if {{{0}}} = \"U\" then \"Editar\" else");
			            Qresult.AppendLine("if {{{0}}} = \"V\" then \"Query\" else");
			            Qresult.AppendLine("if {{{0}}} = \"D\" then \"Delete\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("tipocond", Qresult.ToString());
			// typen
            Qresult = new StringBuilder();
			Qresult.AppendLine("if {{{0}}} = 1 then \"Type 1\" else");
			Qresult.AppendLine("if {{{0}}} = 2 then \"Type 2\" else");
			Qresult.AppendLine("if {{{0}}} = 3 then \"Type 3\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("typen", Qresult.ToString());
			// typet
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"A\" then \"Type A\" else");
			            Qresult.AppendLine("if {{{0}}} = \"B\" then \"Type B\" else");
			            Qresult.AppendLine("if {{{0}}} = \"C\" then \"Type C\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("typet", Qresult.ToString());
			// yesno
            Qresult = new StringBuilder();
			            Qresult.AppendLine("if {{{0}}} = \"0\" then \"Not in use\" else");
			            Qresult.AppendLine("if {{{0}}} = \"1\" then \"In use\" else");
            Qresult.Append("\"                                              \"");
            todasArrays.Add("yesno", Qresult.ToString());
        }

        /// <summary>
        /// Função que dado o identifier da array e o Qfield da table devolve a string usada no crystal
        /// </summary>
        /// <param name="nomeArray">name da Array</param>
        /// <param name="tabelaCampo">table.Qfield</param>
        /// <param name="ano">Qyear actual da aplicacao</param>
        /// <returns>Area correspondente</returns>
        public static string returnArrayCrystal(string arrayName, string tableField, string Qyear)
        {
            if (todasArrays.ContainsKey(arrayName))
            {
                string formula = string.Format(todasArrays[arrayName], tableField);
                int iano;
                if (formula.Contains("#_ano") && Int32.TryParse(Qyear, out iano))
                {
                    formula = formula.Replace("#_ano#4#", iano.ToString());
                    for (int i = 1; i < 10; i++)
                        formula = formula.Replace("#_ano" + i +"#4#", (iano + i).ToString());
                    for (int i = 1; i < 10; i++)
                        formula = formula.Replace("#_ano_" + i + "#4#", (iano - i).ToString());
                }

                return formula;
            }

            throw new BusinessException(null, "ArrayCrystalReports..devolveArrayCrystal", "Can't find an array with name: " + arrayName);
        }
    }        
}
