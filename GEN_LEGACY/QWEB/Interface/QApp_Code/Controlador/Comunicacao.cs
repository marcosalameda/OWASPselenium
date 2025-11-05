using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using CSGenio.framework;
using CSGenio.business;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using GenioServer.security;

namespace CSGenio
{
    /// <summary>
    /// Classe que representa o objecto Comunicacao usado na comunicação entre
    /// a interface cliente e a interface servidor.
    /// </summary>
    public class Comunicacao
    {
        /// <summary>
        /// name da área
        /// </summary>
        private string aplicacao;
        /// <summary>
        /// identifier do pedido,serve como identifier das queries
        /// </summary>
        private string identifier;
        /// <summary>
        /// tipo de função pedida
        /// </summary>
        private FunctionType functionType;
        /// <summary>
        /// condição do pedido  {  é " AND " e [ é " "
        /// </summary>
        private string condicaoOriginal;
        /// <summary>
        /// condição em format to o SQL
        /// </summary>
        private CriteriaSet condicaoSQL;
		/// <summary>
        /// exists uma condition filtra area
        /// </summary>
        private bool condicaoFiltraArea;
        /// <summary>
        /// ordenação do pedido
        /// </summary>
        private string sorting;
        /// <summary>
        /// ordenação do pedido em GenericQuery
        /// </summary>
        private IList<ColumnSort> ordenacaoSql;
        /// <summary>
        /// fields do pedido em GenericQuery
        /// </summary>
        private IList<SelectField> camposPedidoSQL;
        /// <summary>
        /// mensagem do pedido
        /// </summary>
        private string mensagem;
        /// <summary>
        /// status do pedido
        /// </summary>
        private Status status;
        /// <summary>
        /// name dos fields transformado em array(no pedido vem separado por vírgulas)
        /// </summary>
        private string[] arrayNomesCampos;
        /// <summary>
        /// Qvalues dos fields do pedido em array(no pedido vem separado por parentesis rectos)
        /// </summary>
        private List<string[]> arrayFieldValues;
        /// <summary>
        /// name dos fields transformado em array(no pedido vem separado por vírgulas)
        /// </summary>
        private List<string> arrayNomesCamposIns;
        /// <summary>
        /// name dos fields transformado em array(no pedido vem separado por vírgulas)
        /// </summary>
        private List<string> arrayValoresCamposIns;
        /// <summary>
        /// Module actual
        /// </summary>
        private string module;
        /// <summary>
        /// Bd a aceder
        /// </summary>
        private string db;
        /// <summary>
        /// nº de registos duma Qlisting
        /// </summary>
        private int numregs;
        /// <summary>
        /// indica se queremos saber o total de registos
        /// </summary>
        private bool obterTotal;
        /// <summary>
        /// Key do registo pai
        /// </summary>
        private string chavePai;
        /// <summary>
        /// pedido to preencher multiform
        /// </summary>
        private bool isPedidoMF;
        /// <summary>
        /// file to abrir (key)
        /// </summary>
        private string file;
        /// <summary>
        /// Valores de retorno to as opções da mensagem
        /// </summary>
        private Dictionary<string, string> optionReturns = new Dictionary<string,string>();
		 /// <summary>
        /// Registo a partir do qual é to retornar elementos de uma Qlisting.
        /// </summary>
        private int offset;

        /// <summary>
        /// Constructor da classe
        /// </summary>
        /// <param name="pedido">O pedido externo</param>
        public Comunicacao(Qcom pedido)
        {
            //vêm no pedido
            this.functionType = (FunctionType)FunctionType.tiposFuncao[pedido.Func];
            this.status = Status.VAZ;
            this.aplicacao = pedido.App;
            this.condicaoOriginal = pedido.Cond;
            this.condicaoSQL = construirCondicaoGeneric(condicaoOriginal);
            this.sorting = pedido.Ord;
            this.ordenacaoSql = Condition.construirOrdenacao(sorting);
            this.camposPedidoSQL = Condition.construirCamposPedido(pedido.Cmps);
            this.mensagem = pedido.Msg;
            this.Id = pedido.Ident;
            this.identifier = pedido.Ident;

            //Caso o identifier da mensagem for dirigido a uma instancia do controlo, internamente ignorar o sufixo do Id
            int ixInstanceId = this.identifier.IndexOf("._.");
            if (ixInstanceId != -1)
                this.identifier = pedido.Ident.Substring(0, ixInstanceId);

            preencherModuloBD(pedido.Mod);
            this.preencherOpcoesExtra(pedido.Opt);
            this.arrayNomesCamposIns = new List<string>();
            this.arrayValoresCamposIns = new List<string>();
            //vão ser usados no código
            this.arrayNomesCampos = pedido.Cmps;
            this.file = pedido.Fich;

            this.arrayFieldValues = pedido.Dados;
            if (this.arrayFieldValues == null)
            {
                this.arrayFieldValues = new List<string[]>();
                this.arrayFieldValues.Add(new string[1] { "" });
        	}

            if (Log.IsDebugEnabled) Log.Debug(string.Format("Comunicação recebida. [tipo] {0} [aplicacao] {1} [id] {2}", functionType, aplicacao, identifier));
        }

        public Qcom ToQcom()
        {
            Qcom res = new Qcom();

            res.App = Aplicacao;
            res.Ident = Id;
            res.Func = FunctionType.ToString();
            res.Cond = CondicaoOriginal;
            res.Ord = Sort;
            res.Cmps = ArrayNomesCampos;
            res.Dados = ArrayValoresCampos;
            res.Msg = Message;
            res.Stat = Status.ToString();
            res.Mod = Module;

			StringBuilder opt = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in optionReturns)
            {
                opt.Append(kvp.Key + "[" + kvp.Value);
                opt.Append("{");
            }
            if(opt.Length > 0)
                opt.Remove(opt.Length - 1, 1);

            res.Opt = opt.ToString();

            return res;
        }

        public CriteriaSet construirCondicaoGeneric(string condition)
        {
			if(condicaoOriginal.Contains("$FAREA$"))
				condicaoFiltraArea = true;
            //AV20090512 Passei as funções de construção da condição to as funções globais
            //to estarem acessíveis a partir do ExportList.aspx
            return Condition.construirCondicaoGeneric(condition);
        }

        public IList<ColumnSort> construirOrdenacao(string sorting)
        {
            return Condition.construirOrdenacao(sorting);
        }

        public IList<SelectField> construirCamposPedido(string []fieldsRequested)
        {
            return Condition.construirCamposPedido(fieldsRequested);
        }

        /// <summary>
        /// Método to construir o identifier, se começa com ML 
        /// acrescenta o name do módulo antes
        /// </summary>
        public void constroiIdent()
        {
            if (identifier.Substring(0, 2).Equals("ML"))
                identifier = module + identifier;

        }

        public void criaArrayNomesValoresCamposIns()
        {

            string[] elemCond = condicaoOriginal.Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string elem in elemCond)
            {
                //separar a condição em Qfield, operador e Qvalue
                string[] atoms = elem.Split(new char[] { '[' }, StringSplitOptions.None);
                if (atoms.Length < 3)
                {
                    throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
                }
                string Qfield = atoms[0];
                string operador = atoms[1];
                string Qvalue = atoms[2];

                //se o Qfield for um guid temos de transformar o operador e o Qvalue
                int ix = Qfield.IndexOf('.');
                if (ix == -1)
                {
                    throw new FrameworkException("Condição inválida", "construirCondicao, a condição não está no formato area.campo", "formato do campo inválido");
                }

                AreaInfo info = Area.GetInfoArea(Qfield.Substring(0, ix));
                Field cmp = info.DBFields[Qfield.Substring(ix + 1)];
                if ((cmp.FieldFormat == FieldFormatting.DATA)
                        && Qvalue.Contains("#"))
                {
                    int i1 = Qvalue.IndexOf('#');
                    if (i1 == -1)
                    {
                        throw new FrameworkException("Condição inválida", "construirCondicao, condição de data mal formatada", "formato da data inválido");
                    }
                    int i2 = Qvalue.IndexOf('#', i1 + 1);
                    if (i2 == -1)
                    {
                        throw new FrameworkException("Condição inválida", "construirCondicao, condição de data mal formatada", "formato da data inválido");
                    }
                    Qvalue = Qvalue.Substring(i1 + 1, i2 - i1 - 1);
                }
                else if ((cmp.FieldFormat == FieldFormatting.CARACTERES || cmp.FieldFormat == FieldFormatting.TEMPO) && Qvalue.Length == 0)
                {
                    Qvalue = "";
                }
                else if ((cmp.FieldFormat == FieldFormatting.CARACTERES || cmp.FieldFormat == FieldFormatting.GUID || cmp.FieldFormat == FieldFormatting.TEMPO) && Qvalue.Length > 0)
                {
                    if (Qvalue.StartsWith("''") && Qvalue.EndsWith("''"))
                    {
                        Qvalue = Qvalue.Trim('\'');
                        Qvalue = "'" + Qvalue + "'";
                    }
                    else
                        Qvalue = Qvalue.Trim('\'');
                }
                arrayNomesCamposIns.Add(cmp.Alias + "." + cmp.Name);
                arrayValoresCamposIns.Add(Qvalue);
                i++;

            }
            //AV(2010/09/07)
            for (int j = 0; j < arrayFieldValues[0].Length; j++)
            {
                if (!arrayFieldValues[0][j].Equals("") && !arrayNomesCamposIns.Contains(arrayNomesCampos[j]))
                {
                    arrayNomesCamposIns.Add(arrayNomesCampos[j]);
                    arrayValoresCamposIns.Add(arrayFieldValues[0][j]);
                }
            }
                
        }

        public void criaArrayValoresFormatados(string[] arrayValores, string[] arrayValoresFormatados)
        {
            for (int i = 0; i < arrayValores.Length; i++)
            {
                string Qfield = ArrayNomesCampos[i];
                string Qvalue = arrayValores[i];
                //se o Qfield for um guid temos de transformar o operador e o Qvalue
                int ix = Qfield.IndexOf('.');
                if (ix == -1) //não é um Qfield da db (pode ser o login, por ex)
                {
                    if (Qvalue.Length == 0)
                        Qvalue = "";
                    arrayValoresFormatados[i] = Qvalue;
                }
                else
                {

                    AreaInfo info = Area.GetInfoArea(Qfield.Substring(0, ix));
                    Field cmp = info.DBFields[Qfield.Substring(ix + 1)];
                    if ((cmp.FieldFormat == FieldFormatting.CARACTERES || cmp.FieldFormat == FieldFormatting.TEMPO) && Qvalue.Length == 0)
                    {
                        Qvalue = "";
                    }
                    else if ((cmp.FieldFormat == FieldFormatting.CARACTERES || cmp.FieldFormat == FieldFormatting.GUID || cmp.FieldFormat == FieldFormatting.TEMPO) && Qvalue.Length > 0)
                    {
                        // CX 2011-09-20
                        // With the new query system we need no more to format the strings for the sql,
                        // since they are passed as parameters to the dbms.
                        // But QWeb sends the quotes as double quotes, so we have to make them single quotes again.
                        //if (Qvalue.StartsWith("''") && Qvalue.EndsWith("''"))
                        //{
                        //    Qvalue = Qvalue.Trim('\'');
                        //    Qvalue = "'" + Qvalue + "'";
                        //}
                        //else
                        //    Qvalue = Qvalue.Trim('\'');
                        Qvalue = Qvalue.Replace("''", "'");
                    }
                    arrayValoresFormatados[i] = Qvalue;
                }
            }
        }

        /// <summary>
        /// Função to preencher as opções extra (ex: nº de registos duma Qlisting)
        /// </summary>
        /// <param name="opcoesExtra">opções extra recebidas pela interface</param>
        private void preencherOpcoesExtra(string opcoesExtra)
        {
            numregs = Configuration.NrRegDBedit;

            if (!opcoesExtra.Equals(""))
            {
                string[] opcoes = opcoesExtra.Split('{');
                foreach (string condition in opcoes)
                {
                    string[] atoms = condition.Split(new char[] { '[' }, StringSplitOptions.RemoveEmptyEntries);
                    if (atoms[0] == "NRECS")
                        numregs = GenFunctions.atoi(atoms[2]);
                    if (atoms[0] == "MULTIFORM")
                        if (atoms.Length == 3 && atoms[2].Equals("S"))
                            isPedidoMF = true;
                        else
                            isPedidoMF = false;
                    if (atoms[0] == "KFLD")
                        if (atoms.Length == 3)
                            chavePai = atoms[2];
                        else
                            chavePai = "";
                    if (atoms[0] == "KVAL")
                        if (atoms.Length == 3)
                            chavePai += "=" + atoms[2];
                        else
                            chavePai = "";
                    if (atoms[0] == "TRECS")
                        if (atoms.Length == 3 && atoms[2].Equals("S"))
                            obterTotal = true;
                        else
                            obterTotal = false;
					if(atoms[0] == "OFFSET")
                    {
                        if (atoms.Length == 3)
                            Offset = GenFunctions.atoi(atoms[2]);
                    }

                    //if (atoms.Length < 3)
                    //    throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
                    //string Qfield = atoms[0];
                    //string operador = atoms[1];
                    //string Qvalue = atoms[2];
                }
            }
        }

        /// <summary>
        /// Função to preencher o module e o identifier duma db auxiliar
        /// </summary>
        /// <param name="modulo">id do módulo e da db actuais (ex:WRQ;bd1) </param>
        private void preencherModuloBD(string module)
        {
            string[] opcoes = module.Split(';');
            this.module = opcoes[0];
            if (opcoes.Length > 1)
                this.db = opcoes[1];
        }
        /// <summary>
        /// Método que verifica se a função recebida no pedido é válida
        /// </summary>
        /// <returns>true se a função é válida e false caso contrário</returns>
        public bool isTipoFuncaoValida()
        {
            if (functionType.Equals(FunctionType.VAZ) || functionType == null || !(FunctionType.tiposFuncao.Contains(functionType.ToString())))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Método que constroi uma resposta de erro a um pedido
        /// </summary>
        /// <returns>Devolve o objecto comunicação com todos os atributos vazios,
        /// o status a erro e a mensagem com o text "Função inválida" no caso de
        /// a função não ser válida e em caso contrário "Erro na estrutura dos 
        /// dados recebidos"</returns>
        public Comunicacao constroiRespostaErro()
        {
            Aplicacao = "";
            Sort = "";
            CondicaoOriginal = "";
            FunctionType = FunctionType.VAZ;
            if (!FunctionType.tiposFuncao.Contains(functionType.ToString()))
            {
                Status = Status.EW;
                Message = "Função Inválida";
            }
            else
            {
                Status = Status.EW;
                Message = "Erro na estrutura dos dados recebidos";
            }
            Log.Error(string.Format("Resposta de erro na comunicação. [mensagem] {0}", Message));
            return this;
        }

        /// <summary>
        /// Método que constroi uma resposta de erro a um pedido
        /// </summary>
        /// <param name="mensagemErro">corresponda à mensagem de erro a enviar</param>
        /// <returns>Devolve um objecto comunicação com todos os atributos a
        /// vazio, o status a erro e a mensagem de erro passada como parâmetro</returns>

        public Comunicacao constroiRespostaErro(string mensagemErro, string lang)
        {
            Sort = "";
            CondicaoOriginal = "";
            Status = Status.EW;
            Message = Translations.Get(mensagemErro, lang);
            Log.Error(string.Format("Resposta de erro na comunicação. [mensagem] {0} [status] {1}", Message, Status));
            return this;
        }
        /// <summary>
        /// Método to construir uma mensagem de sucesso, usado nas funções que
        /// devolvem dados(select)	
        /// </summary>
        /// <param name="dadosParaEnviar">string com os dados a enviar</param>
        /// <param name="mensagem">string com a mensagem</param>
        /// <param name="status">string com o status</param>
        /// <returns>Devolve um objecto comunicacão com os dados a enviar, o status 
        /// e a mensagem passados como parâmetro</returns>				 
        public Comunicacao constroiRespostaSucesso(List<string[]> dadosParaEnviar, string mensagem, Status status, string lang)
        {
            Sort = "";
            CondicaoOriginal = "";
            arrayFieldValues = dadosParaEnviar; //<<<<------
            Status = status;
            Message = Translations.Get(mensagem, lang);
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Resposta de sucesso na comunicação. [mensagem] {0} [status] {1}", Message, Status));
            return this;
        }

        public Comunicacao constroiRespostaSucesso(string[] dadosParaEnviar, string mensagem, Status status, string lang)
        {
            List<string[]> matrix = null;
            if(dadosParaEnviar != null)
            {
                matrix = new List<string[]>();
                matrix.Add(dadosParaEnviar);
            }

            return constroiRespostaSucesso(matrix, mensagem, status, lang);
        }

		public Comunicacao constroiRespostaSucesso(object dadosParaEnviar, string mensagem, Status status, User user)
        {
            List<string[]> matrix = null;
            if (dadosParaEnviar != null)
            {
                matrix = new List<string[]>();
                List<object[]> dadosConverter = new List<object[]>();

                //pode chegar aqui:
                //um objecto singular
                //uma lista de objectos singulares
                //um lista de array de objectos

                //independentemente do tipo no final teremos sempre um objecto do tipo List<object[]> com os dados a converter
                IList dadosParaEnviarList = dadosParaEnviar as IList;
                if (dadosParaEnviarList != null)
                {
                    //se estamos perante uma lista temos que saber se os seus elementos também são listas ou não
                    //esta análise tem que ser feita de maneira diferente to Arrays e Lists
                    //assim sendo:
                    //se for array e os seus elementos são array
                    //se não for array (ou seja é lista) e os seus elementos são array
                    //então tratamos as linhas como linhas                    
                    Type dadosParaEnviarType = dadosParaEnviar.GetType();
                    if ((dadosParaEnviarType.IsArray && dadosParaEnviarType.GetElementType().IsArray) || (!dadosParaEnviarType.IsArray && dadosParaEnviarType.GetProperty("Item").PropertyType.IsArray))
                    {
                        //é uma List<object[]> ou um object[][]
                        //dados a converter 
                        //converter o array de objectos especificos em array de objectos 
                        foreach (object dado in dadosParaEnviarList)
                            dadosConverter.Add(dado as object[]);
                    }
                    else //lista ou array de elementos singulares
                    {
                        //se for object[] ou List<object>
                        //colocar todos os Qvalues na mesma linha
                        List<object> dados = new List<object>();
                        foreach (object dado in dadosParaEnviarList)
                            dados.Add(dado);
                        
                        dadosConverter.Add(dados.ToArray());
                    }                    
                }
                else
                    dadosConverter.Add(new object[] { dadosParaEnviar });

                //converter todos os tipos de dados to string
                foreach (object[] dados in dadosConverter)
                {
                    List<string> dadosConvertidos = new List<string>();
                    foreach (object dado in dados)
                    {
                        string value = "";
                        if (dado is ResourceQuery || dado is ResourceFile)
                            value = CriaTicketRecurso(dado as Resource, user.Name, user.Location); //Criar ticket
                        else if (dado != null)
                            value = ConversaoQweb.FromInternal(dado, dado.GetType());

                        dadosConvertidos.Add(value);
                    }

                    matrix.Add(dadosConvertidos.ToArray());
                }
            }

            return constroiRespostaSucesso(matrix, mensagem, status, user.Language);
        }

        /// <summary>
        ///Método to construir uma mensagem de sucesso, usado nas funções que
        /// não devolvem dados (apagar, introduce, actualizar e duplicate)	
        /// </summary>
        /// <param name="mensagem">string com a mensagem</param>
        /// <param name="status">string com o status</param>
        /// <returns>Devolve um objecto comunicacão com os dados a enviar, o status 
        /// e a mensagem passados como parâmetro</returns>				 
        public Comunicacao constroiRespostaSucesso(string mensagem, Status status, string lang)
        {
            Sort = "";
            CondicaoOriginal = "";
            Status = status;
            Message = Translations.Get(mensagem,lang);
            if (Log.IsDebugEnabled) Log.Debug(string.Format("Resposta de sucesso na comunicação. [mensagem] {0} [status] {1}", Message, Status));
            return this;
        }

        /// <summary>
        /// Método to construir o id da classe a instanciar 
        /// </summary>
        /// <returns>Devolve a string com o IdClasse construido</returns>
        public string constroiIdClasse()
        {
            return "CSGenioA" + aplicacao;
        }

        public void adicionarCondicaoSQL(CriteriaSet adicionar)
        {
            if (adicionar != null && (adicionar.Criterias.Count > 0 || adicionar.SubSets.Count > 0))
            {
                if (condicaoSQL == null)
                {
                    condicaoSQL = CriteriaSet.And();
                }
                condicaoSQL.SubSet(adicionar);
            }
        }

        /// <summary>
        /// Método to validar o pedido
        /// </summary>
        /// <returns>Devolve true se o pedido for válido e false caso contrário</returns>
        public bool valEstComunicacao()
        {
            if (functionType.Equals(FunctionType.EXW) || functionType.Equals(FunctionType.ALT) || functionType.Equals(FunctionType.INS))
            {
                if(this.arrayFieldValues.Count > 0 && this.arrayNomesCampos.Length != this.arrayFieldValues[0].Length)
                    return false;
            }

            //TODO faltam acrescentar aki mais validações	
            return true;
        }

        /// <summary>
        /// Método que transforma uma condition do pedido e transforma-a numa 
        /// condição aceite por um query update
        /// </summary>
        //20060814 SO alteração do método
        public void constroiCondChavePrimaria(string nomeChavePrimaria)
        {
            CriteriaSet condicoesAlt = Condition.construirCondicaoGeneric(condicaoOriginal);

            Criteria crit = FindCriteriaOfField(nomeChavePrimaria, condicoesAlt);
            condicaoSQL = CriteriaSet.And();
            condicaoSQL.Criterias.Add(crit);            
        }

		private Criteria FindCriteriaOfField(string nomeChavePrimaria, CriteriaSet condicoesAlt)
        {
            foreach (Criteria crit in condicoesAlt.Criterias)
            {
                ColumnReference c = crit.LeftTerm as ColumnReference;
                if (c != null && String.Equals(c.ColumnName, nomeChavePrimaria, StringComparison.InvariantCultureIgnoreCase))
                {
                    return crit;
                }
            }

            foreach (CriteriaSet set in condicoesAlt.SubSets)
            {
                Criteria crit = FindCriteriaOfField(nomeChavePrimaria, set);
                if (crit != null)
                {
                    return crit;
                }
            }

            return null;
        }

        /// <summary>
        /// Função to construir a condição da comunicação
        /// </summary>
        /// <param name="utilizador"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public CriteriaSet constroiCondicaoGeneric(User user, Area area, string identifier)
        {
            CriteriaSet conditions = CriteriaSet.And();
            if (this.condicaoSQL != null)
            {
                foreach (Criteria criteria in this.condicaoSQL.Criterias)
                {
                    conditions.Criterias.Add(criteria);
                }
                foreach (CriteriaSet subSet in this.condicaoSQL.SubSets)
                {
                    conditions.SubSets.Add(subSet);
                }
            }

            CriteriaSet condicoesEph = Listing.CalculateConditionsEphGeneric(area, identifier);
            if (condicoesEph != null && (condicoesEph.Criterias.Count > 0 || condicoesEph.SubSets.Count > 0))
            {
                //RMR(2016-09-05) - Adds the condition for when is a pseudo-new record, in order to not apply the EPH condition
                //This was an issue when you had a new record on a table, and had a key for the EPH condition that wasn't filled yet, this was causing the foreign key to not be filled
                //Eg. EPH for EMPRE. higher table FUNCI->CODEMPRE when CODEMPRE is a U1 from ROTAC table. Inserting a FUNCI and a ROTAC sequencially, the CODEMPRE in FUNCI wasn't filled yet
                CriteriaSet ephOrNew = CriteriaSet.Or()
                    .SubSet(condicoesEph)
                    .Equal(new Quidgest.Persistence.FieldRef(area.Alias, "zzstate")/* area.Alias + ".zzstate"*/, 1);

                conditions.SubSet(ephOrNew);
            }

            return conditions;
        }

        /// <summary>
        /// Método que tranforma uma matriz com dados, numa string a enviar
        /// no pedido. As linhas da matriz são separadas por '{' e as colunas
        /// por '['. Este método é usado na função GET.
        /// </summary>
        /// <param name="matriz">parâmetro com os dados a enviar</param>
        /// <returns>Devolve a string a enviar</returns>
        public List<string[]> DataSet2String(DataSet dataSet, User user)
        {
            List<string[]> Qresult = new List<string[]>();
            int nrLinhas = dataSet.Tables[0].Rows.Count;
            int nrColunas = dataSet.Tables[0].Columns.Count;

            List<Field> tiposColunas = new List<Field>();
            for (int i = 0; i < nrColunas; i++)
            {
                string[] colname = dataSet.Tables[0].Columns[i].ColumnName.Split('.');
                AreaInfo info = Area.GetInfoArea(colname[0]);
                Field tipo;
                if (info.DBFields.TryGetValue(colname[1], out tipo))
                    tiposColunas.Add(tipo);
                else //o number de colunas tem de ser o mesmo, marcamos aqui os fields que não conhecemos
                    tiposColunas.Add(null);
            }

            for (int linha = 0; linha < nrLinhas && (linha < Numregs || Numregs == -1); linha++)
            {
                List<string> row = new List<string>();
                for (int coluna = 0; coluna < nrColunas; coluna++)
                {
                    if (tiposColunas[coluna] != null)
                    {
                        object Qvalue = DBConversion.ToInternal(dataSet.Tables[0].Rows[linha][coluna], tiposColunas[coluna].FieldFormat);
                        if (tiposColunas[coluna].FieldType == FieldType.ARRAY_TEXT
                            || tiposColunas[coluna].FieldType == FieldType.ARRAY_NUMERIC
                            || tiposColunas[coluna].FieldType == FieldType.ARRAY_LOGIC)
                        {
                            string arr = "";
                            string strVal = "";
                            if (tiposColunas[coluna].ArrayName.StartsWith("dbo."))
                                arr = tiposColunas[coluna].ArrayName.Substring(16);
                            else
                                arr = tiposColunas[coluna].ArrayName.Substring(12);
                            strVal = ReplaceYearArray(Convert.ToString(Qvalue), user.Language, arr, user.Year);
                            row.Add(ConversaoQweb.FromInternal(strVal, FieldType.TEXT));
                        }
                        else
                        {
                            row.Add(ConversaoQweb.FromInternal(Qvalue, tiposColunas[coluna].FieldType));
                        }
                    }
                    else //usamos o tipo interno da coluna (TODO: tentar eliminate esta necessidade)
                        row.Add(Conversion.internal2String(dataSet.Tables[0].Rows[linha][coluna], dataSet.Tables[0].Columns[coluna].DataType));
                }
                Qresult.Add(row.ToArray());
                }

            return Qresult;
        }

        /// <summary>
        /// Método auxiliar to tranformar correctamete o codigo dos arrays na descrição
        /// suportando também os arrays com replaces por Qyear
        /// </summary>
        /// <param name="value">Value do codigo</param>
        /// <param name="lang">A lingua do user</param>
        /// <param name="array">A informação sobre o array</param>
        /// <param name="ano">O Qyear actual</param>
        /// <returns>A descrição do array correctamente traduzida e transformada</returns>
        public static string ReplaceYearArray(string value, string lang, string array, string Qyear)
        {
            string res = "";
            ArrayInfo ai = new ArrayInfo(array);
            try
            {
                if (!ai.IsYearReplace)
                {
                    res = ai.GetDescription(Convert.ToString(value), lang);
                }
                else
                {
                    //NOTA: Isto assume que os datasystems por Qyear são tranformáveis em nuemro inteiro
                    //é por isso que esta funcionalidade deve ser deprecated o mais rápido possível
                    // por causa disso não me preocupei muito com a eficiencia deste método
                    int iano = Int32.Parse(Qyear);

                    //1 - replace User.Year - 1 por #_ano_1#4# no codigo
                    //  - replace User.Year por #_ano#4# no codigo
                    //  - replace User.Year + 1 por #_ano1#4# no codigo
                    // ...
                    //2 - obter a descrição
                    //3 - replace #_ano#4# por User.Year - 1 na descrição
                    // ...
                    string v2 = value.Replace(iano.ToString(), "#_ano#4#");

                    v2 = v2.Replace((iano - 1).ToString(), "#_ano_1#4#");
                    v2 = v2.Replace((iano - 2).ToString(), "#_ano_2#4#");
                    v2 = v2.Replace((iano - 3).ToString(), "#_ano_3#4#");
                    v2 = v2.Replace((iano - 4).ToString(), "#_ano_4#4#");
                    v2 = v2.Replace((iano - 5).ToString(), "#_ano_5#4#");
                    v2 = v2.Replace((iano - 6).ToString(), "#_ano_6#4#");
                    v2 = v2.Replace((iano - 7).ToString(), "#_ano_7#4#");
                    v2 = v2.Replace((iano - 8).ToString(), "#_ano_8#4#");

                    v2 = v2.Replace((iano + 1).ToString(), "#_ano1#4#");
                    v2 = v2.Replace((iano + 2).ToString(), "#_ano2#4#");
                    v2 = v2.Replace((iano + 3).ToString(), "#_ano3#4#");
                    v2 = v2.Replace((iano + 4).ToString(), "#_ano4#4#");
                    v2 = v2.Replace((iano + 5).ToString(), "#_ano5#4#");

                    res = ai.GetDescription(v2, lang);

                    res = res.Replace("#_ano#4#", iano.ToString());

                    res = res.Replace("#_ano_1#4#", (iano - 1).ToString());
                    res = res.Replace("#_ano_2#4#", (iano - 2).ToString());
                    res = res.Replace("#_ano_3#4#", (iano - 3).ToString());
                    res = res.Replace("#_ano_4#4#", (iano - 4).ToString());
                    res = res.Replace("#_ano_5#4#", (iano - 5).ToString());
                    res = res.Replace("#_ano_6#4#", (iano - 6).ToString());
                    res = res.Replace("#_ano_7#4#", (iano - 7).ToString());
                    res = res.Replace("#_ano_8#4#", (iano - 8).ToString());

                    res = res.Replace("#_ano1#4#", (iano + 1).ToString());
                    res = res.Replace("#_ano2#4#", (iano + 2).ToString());
                    res = res.Replace("#_ano3#4#", (iano + 3).ToString());
                    res = res.Replace("#_ano4#4#", (iano + 4).ToString());
                    res = res.Replace("#_ano5#4#", (iano + 5).ToString());
                }
            }
            catch {}

            return res;
        }

		/// <summary>
        /// Método que tranforma uma matriz com dados, numa string a enviar
        /// no pedido dum multiform . As linhas da matriz são separadas por '{' e as colunas
        /// por '['. Este método é usado na função GET.
        /// </summary>
        /// <param name="matriz">parâmetro com os dados a enviar</param>
        /// <returns>Devolve a string a enviar</returns>
        public List<string[]> DataSetMF2String(DataSet dataSet, User user)
        {
            List<string[]> Qresult = new List<string[]>();
            int nrLinhas = dataSet.Tables[0].Rows.Count;
            int nrColunas = dataSet.Tables[0].Columns.Count;
            Dictionary<int, Area> fields = new Dictionary<int, Area>();
            string fieldName;
            object fieldValue;
            DataTableReader dtr = dataSet.CreateDataReader();
            Dictionary<string, Area> listaAreas = new Dictionary<string, Area>();
            for (int i = 0; i < nrColunas; i++)
            {
                fieldName = dtr.GetName(i).ToLower();
                int ponto = fieldName.IndexOf('.');
                string nomeArea = fieldName.Substring(0, ponto);
                Area areaAux;
                if (listaAreas.ContainsKey(nomeArea))
                    areaAux = listaAreas[nomeArea];
                else
                {
                    areaAux = Area.createArea(nomeArea, user, Module);
                    listaAreas.Add(nomeArea, areaAux);
                }
                Field tipo;
                if (areaAux.DBFields.TryGetValue(fieldName.Substring(ponto + 1), out tipo))
                {
                    FieldType fieldType = ((Field)areaAux.DBFields[fieldName.Substring(ponto + 1)]).FieldType;
                    if (fieldType.IsKey() || fieldType == FieldType.DOCUMENT || fieldType == FieldType.IMAGE || fieldType == FieldType.PATH)
                    {
                        RequestedField campoPedido = new RequestedField(fieldName, nomeArea);
                        campoPedido.FieldType = fieldType;

                        areaAux.Fields.Add(fieldName, campoPedido);

                        fields.Add(i, areaAux);
                    }
                }
            }

            for (int linha = 0; linha < nrLinhas && (linha < Numregs || Numregs == -1); linha++)
            {
                List<string> row = new List<string>();

                for (int coluna = 0; coluna < nrColunas; coluna++)
                {
                    if (coluna == 0)
                    {
                        row.Add(dataSet.Tables[0].Rows[linha][coluna].ToString());
                        fields[0].insertNameValueField(dtr.GetName(coluna).ToLower(), dataSet.Tables[0].Rows[linha][0]);
                    }
                    else
                    {
                        if (fields.ContainsKey(coluna))
                        {
                            int ponto = dtr.GetName(coluna).ToLower().IndexOf('.');
                            fieldName = dtr.GetName(coluna).ToLower().Substring(ponto + 1);
                            fieldValue = dataSet.Tables[0].Rows[linha][coluna];
                            if (fields[coluna].DBFields[fieldName].FieldType.Equals(FieldType.IMAGE))
                            {
                                // aqui estamos a assumir que o Qfield de imagem pertence à area base e que a key primária é a primeira coluna
                                // TODO: tratar os casos das imagens que não pertencem à area base
                                Byte[] img = DBConversion.ToBinary(fieldValue);
                                if (img.Length != 0)
                                    row.Add(CriaTicketImagemJpeg(fields[coluna], dtr.GetName(coluna).ToLower(), dataSet.Tables[0].Rows[linha][0].ToString()));
                                else
                                    row.Add(string.Empty);
                            }
                            else if (fields[coluna].DBFields[fieldName].FieldType.Equals(FieldType.PATH))
                            {
                                string fileName = ConversaoQweb.FromString(fieldValue);
                                row.Add(CriaTicketFicheiroExterno(fileName, "DataSetMF2String", user.Name, user.Location));
                            }
                            else
                            {
                                //TODO: to ficar um link tem de se criar um ResourceQuery tal como se faz em pedidosFCT
                                row.Add(Conversion.internal2String(dataSet.Tables[0].Rows[linha][coluna], dataSet.Tables[0].Columns[coluna].DataType));
                            }

                        }
                        else
                        {
                            //TODO: arranjar outra forma de fazer isto. A Qlisting deveria declarar à cabeça a formatação das colunas
                            // que quer devolver to o interface. So assim se preve os casos de colunas que não pertencem as definições (queries ad-hoc)
                            // Com o tipo de Qfield já é possivel converter to tipo interno e depois tambem usar o conversaoQweb de forma normalizada.

                            //TODO: Estou a inferir aqui o tipo de Qfield to devolver a formatação correcta, mas a função num todo precisa ser revista.
                            string[] colname = dataSet.Tables[0].Columns[coluna].ColumnName.Split('.');
                            Field tipo;
                            if (Area.GetInfoArea(colname[0]).DBFields.TryGetValue(colname[1], out tipo))
                            {
                                object Qvalue = DBConversion.ToInternal(dataSet.Tables[0].Rows[linha][coluna], tipo.FieldType.GetFormatting());
                                row.Add(ConversaoQweb.FromInternal(Qvalue, tipo.FieldType));
                            }
                            else
                                row.Add(Conversion.internal2String(dataSet.Tables[0].Rows[linha][coluna], dataSet.Tables[0].Columns[coluna].DataType));
                        }
                    }
                }

                Qresult.Add(row.ToArray());

            }
            return Qresult;

        }

        /// <summary>
        ///Método usado no GET1 que constroi os dados to enviar na resposta,
        /// separados por '[', pela order que foram pedidos
        /// </summary>
        /// <param name="campos">parâmetro com os fields</param>
        /// <returns>Devolve uma string com os Qvalues dos fields a enviar</returns>
        public List<string[]> Campos2String(Hashtable fields)
        {
            List<string> Qresult = new List<string>();
            for (int Qfield = 0; Qfield < arrayNomesCampos.Length; Qfield++)
            {

                if (fields.ContainsKey(arrayNomesCampos[Qfield]))
                    Qresult.Add(fields[arrayNomesCampos[Qfield]] as string);
                else
                    Qresult.Add(string.Empty);
            }

            List<string[]> res = new List<string[]>();
            res.Add(Qresult.ToArray());
            return res;
        }

        /// <summary>
        /// Método to enviar a autorização do user
        /// </summary>
        /// <param name="utilizador">parâmetro que corresponde ao user que está a fazer login</param>
        /// <returns>Devolve a string com as permissões do user</returns>
        public List<string[]> Utilizador2String(User user, string permissoesCliente)
        {
            List<string> Qresult = new List<string>();
            /*Dois '[', um to o password e outro to o codpass, que são recebidos
             * no pedido, mas não devem ir na resposta.[[*/
            Qresult.Add(user.Name);
            Qresult.Add(string.Empty);

            StringBuilder modulos = new StringBuilder();
            GetModulosPorNivel(user, modulos);
            Qresult.Add(modulos.ToString());

            Qresult.Add(user.Year);
            Qresult.Add(InterfaceObjectPermission.getPermissoesPorNivel(user));
                        
            EncryptPass.GetParameterRSA();
            Qresult.Add(StringHelper.BytesToHexString(EncryptPass.Modulus()));
            Qresult.Add(StringHelper.BytesToHexString(EncryptPass.exponent()));
			
			//RMR(2018-11-14) - Returns this user DB years
            if (user.Years != null && user.Years.Count > 0)
                Qresult.Add(string.Join(",", user.Years));
            else
                Qresult.Add(string.Empty);
            //RMR(2018-11-14) - Empty string to fill this argument cc
            Qresult.Add(string.Empty);
            //RMR(2018-11-14) - User  current DB status
            Qresult.Add(user.Status.ToString());

            List<string[]> res = new List<string[]>();
            res.Add(Qresult.ToArray());
            return res;
        }

        /// <summary>
        /// Retorna a string de descrição das permissões dos modulos
        /// </summary>
        /// <param name="utilizador">O user a partir do qual se cria a descrição dos modulos</param>
        /// <param name="resultado">[in,out] O stringbuilder onde se vai colocar a string do module</param>
        public static void GetModulosPorNivel(User user, StringBuilder Qresult)
        {
            foreach(var modulo in Configuration.Application.Modules.Select(m => m.Key))
            {
                foreach (var role in user.GetModuleRoles(modulo))
                {
                    if (role != Role.UNAUTHORIZED)//s? se enviam os m?dulos cujo n?vel ? diferente de '0'
                        Qresult.Append(modulo + "=" + role.Id + ",");
                }
            }
            if (Qresult.Length > 0)
                Qresult.Remove(Qresult.Length - 1, 1);
        }

        // função to criar um ticket de resource que permite visualizar a imagem no browser
        private string CriaTicketImagemJpeg(Area area, string Qfield, string keyValue)
        {
            int suf = new Random().Next();
            // a forma de nomear os ficheiros pode ser alterada, visto que já não são gravados na pasta temp
            string caminhoFicheiro = "imagem" + "_" + area.Alias + "_" + Qfield + suf + ".jpg";
            int posPonto = Qfield.IndexOf('.');
            string campoSemAlias = posPonto == -1 ? Qfield: Qfield.Substring(posPonto + 1);
            return CriaTicketRecursoPorQuery(new ResourceQuery(caminhoFicheiro, area, campoSemAlias, keyValue), area.User);
        }
		
		//função que cria um ticket com base num resource
        private string CriaTicketRecurso(Resource rec, string username, string location)
        {
            string recSer = QResources.CreateTicketEncryptedBase64(username, location, rec);
            return "ticket:" + recSer;
        }
        
        //função que cria um ticket com base num resource por query
        private string CriaTicketRecursoPorQuery(ResourceQuery rec, User user)
        {
            return CriaTicketRecurso(rec, user.Name, user.Location);
        }
		
		// função to criar um ticket de resource que permite fazer o download do file através do browser
        private string CriaTicketFicheiroExterno(string fileName, string function, string username, string location)
        {
            if (!String.IsNullOrEmpty(fileName))
            {

                string pathFicheiro = Path.Combine(Configuration.PathDocuments, fileName);

                if (System.IO.File.Exists(pathFicheiro))
                {
					Resource rec = new ResourceFile(fileName, pathFicheiro);
                    return CriaTicketRecurso(rec, username, location);
                }
                else
                    throw new BusinessException("O ficheiro não encontrado", "Comunicacao." + function, "O ficheiro " + fileName + " não existe na pasta de ficheiros externos");
            }
            else
                return "";
        }

        /// <summary>
        /// Método que usa uma área e constroi os dados to enviar na resposta,
        /// separados por '[', pela order que foram pedidos
        /// </summary>
        /// <param name="area">parâmetro que corresponde à área do pedido</param>
        /// <param name="criaTicketsFicheiros">se é necessário criar tickets de ficheiros to serem disponibilizados na interface</param>
        /// <returns>Devolve a string com os Qvalues do pedido</returns>
        public string[] Area2String(Area area, bool criaTicketsFicheiros)
        {
            List<string> Qresult = new List<string>();
            for (int i = 0; i < arrayNomesCampos.Length; i++)
            {
                if (area.Fields.ContainsKey(arrayNomesCampos[i]))
                {
                    RequestedField campoPedido = area.Fields[arrayNomesCampos[i]];

                    if (campoPedido.FieldType.Equals(FieldType.IMAGE))
                    {
                        if (criaTicketsFicheiros) // se está a tratar um pedido que tem de disponibilizar a imagem ao cliente
                        {
                            Byte[] img = campoPedido.Value as Byte[];
                            if (img == null || img.Length == 0 || string.IsNullOrEmpty(area.QPrimaryKey))
                                campoPedido.Value = "";
                            else if (area.Alias == campoPedido.Area)
                                campoPedido.Value = CriaTicketImagemJpeg(area, campoPedido.Name, area.QPrimaryKey);
                            else
                            {
                                Area anotherArea = area.fillRelatedArea(campoPedido.Area, new string[] { campoPedido.FullName });
                                campoPedido.Value = CriaTicketImagemJpeg(anotherArea, campoPedido.Name, anotherArea.QPrimaryKey);
                            }
                        }
                        else
                            campoPedido.Value = "";

                    }
                    else if (campoPedido.FieldType.Equals(FieldType.PATH))
                    {
                        string fileName = ConversaoQweb.FromInternal(campoPedido.Value, campoPedido.FieldType);
                        if (criaTicketsFicheiros)
                            campoPedido.Value = CriaTicketFicheiroExterno(fileName, "Area2String", area.User.Name, area.User.Location);
                        else
                            campoPedido.Value = fileName;
                    }
                    // quem gere as transferências de documentos é o controlo
                    
                    //20060914 SO alteração, só nesta altura é que os Qvalues são transformados em string
                    Qresult.Add(ConversaoQweb.FromInternal(campoPedido.Value, campoPedido.FieldType));
                }

            }
            return Qresult.ToArray();

        }

        /// <summary>
        /// Método to preencher a key primária e chaves estrangeiras do registo a apagar
        /// </summary>
        /// <param name="area">parâmetro é a area a que pertence o Qfield a apagar</param>
        /// <returns>Devolve a área com o Qfield key primária e estrangeiras preenchido</returns>
        public Area preencheCodRegApagar(Area area)
        {
            if (condicaoSQL.Equals(""))
                return null;

            string[] condicoesDel = condicaoOriginal.Trim().Split('{');

            for (int i = 0; i < condicoesDel.Length; i++)
            {
                if (!condicoesDel[i].Equals(""))
                {
                    condicoesDel[i] = condicoesDel[i].Replace("[", " ");
                    string[] campoValor = condicoesDel[i].Trim().Split('=');
                    if (campoValor.Length != 2)
                        return null;
                    else
                    {
                        campoValor[0] = campoValor[0].Trim();
                        campoValor[1] = campoValor[1].Trim().Trim('\'');
                        //SO 20060807 tirei o if to preencher todas as chaves primária e estrangeiras
                        area.insertNameValueField(campoValor[0], campoValor[1]);

                    }
                }

            }
            return area;

        }

        /// <summary>
        /// Método to devolver o Qvalue da key primária
        /// </summary>
        /// <param name="nomeChavePrimaria">name da key primária</param>
        /// <returns>Qvalue da key primária</returns>
        public string getValorChavePrimaria(string nomeChavePrimaria)
        {
            for (int i = 0; i < ArrayNomesCampos[0].Length; i++)
            {
                if (ArrayNomesCampos[i].Equals(nomeChavePrimaria))
                    return ArrayValoresCampos[0][i];
            }
            return "";
        }

        /// <summary>
        /// Método to validar a ordenação do pedido
        /// </summary>
        /// <returns></returns>
        /* public void validaEPreencheOrdenacao(string ordPedido)
         {
             string[] arrayOrd = new string[2];
             //organizar a sorting
             if (!ordPedido.Equals(""))
             {
                 arrayOrd = ordPedido.Split(' ');
                 if (arrayOrd.Length != 2)
                     throw new FrameworkException("Erro na construção do pedido.", "Comunicacao.validaOrdenacao", "Erro no campo ordenação, não está preenchido correctamente");
                 campoTipoOrdenacao = arrayOrd;
                 this.sorting = ordPedido;
             }
             else
             {
                 campoTipoOrdenacao = new string[2]{"",""};
                 this.sorting = ordPedido;
             }
            
         }*/

        /// <summary>
        /// Implementação do método equals to o tipo Comunicacao																								   */
        /// </summary>
        /// <param name="obj">objecto a comparar</param>
        /// <returns></returns>true se os objectos são iguais e false se não</returns>
        /*
        public override bool Equals(Object obj)
        {
            if (obj is Comunicacao)
            {
                Comunicacao c = (Comunicacao)obj;
                if (c.Aplicacao.Equals(aplicacao) &&
                    c.CamposPedido.Equals(fieldsRequested) &&
                    c.CondicaoSQL.Equals(condicaoSQL) &&
                    c.CondicaoOriginal.Equals(condicaoOriginal) &&
                    c.DadosPedido.Equals(dadosPedido) &&
                    c.Identificador.Equals(identifier) &&
                    c.Message.Equals(mensagem) &&
                    c.Sort.Equals(sorting) &&
                    c.Status.Equals(status) &&
                    c.FunctionType.Equals(functionType) &&
                    c.Module.Equals(module))
                    return true;
                else
                    return false;
            }
            else
                return false;

        }
        */

        /*
        /// <summary>
        /// Override do método GetHashCode do tipo Object
        /// </summary>
        /// <returns>devolve o hashcode do objecto Qfield</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }*/

        /// <summary>
        /// Método que coloca ou devolve o Qfield aplicação
        /// </summary>
        public string Aplicacao
        {
            get { return aplicacao; }
            set { aplicacao = value; }
        }

        public IList<SelectField> CamposPedidoSQL
        {
            get
            {
                return camposPedidoSQL;
            }
        }

        /// <summary>
        /// Método que coloca ou devolve o Qfield condição no format SQL
        /// </summary>
        public CriteriaSet CondicaoSQL
        {
            get { return condicaoSQL; }
            set { condicaoSQL = value; }
        }
		
		/// <summary>
        /// Método que coloca ou devolve o Qfield condição no format SQL
        /// </summary>
        public bool TemCondicaoFiltraArea
        {
            get { return condicaoFiltraArea; }
            set { condicaoFiltraArea = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o Qfield condição no format que vem do pedido
        /// </summary>
        public string CondicaoOriginal
        {
            get { return condicaoOriginal; }
            set { condicaoOriginal = value; }
        }

        private string m_id;
        /// <summary>
        /// Método que coloca ou devolve o identifier do pedido "original"
        /// </summary>
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o identifier do pedido
        /// </summary>
        public string Identificador
        {
            get { return identifier; }
            set { identifier = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve a mensagem do pedido
        /// </summary>
        public string Message
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve a ordenação pedida na 
        /// mensagem de comunicação
        /// </summary>
        public string Sort
        {
            get { return sorting; }
            set
            {
                sorting = value;
                ordenacaoSql = construirOrdenacao(sorting);
            }
        }

        public IList<ColumnSort> OrdenacaoSQL
        {
            get
            {
                return ordenacaoSql;
            }
        }

        /// <summary>
        /// Método que coloca ou devolve a array de strings
        /// </summary>
        /* public string[] CampoTipoOrdenacao
         {
             get { return campoTipoOrdenacao; }
             set { campoTipoOrdenacao = value; }
         }*/
        /// <summary>
        /// Método que coloca ou devolve o status do pedido
        /// </summary>
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o tipo de função do pedido
        /// </summary>
        public FunctionType FunctionType
        {
            get { return functionType; }
            set { functionType = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o array com os nomes dos fields
        /// </summary>
        public string[] ArrayNomesCampos
        {
            get { return arrayNomesCampos; }
            set { arrayNomesCampos = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o array com os Qvalues dos fields
        /// </summary>
        public List<string[]> ArrayValoresCampos
        {
            get { return arrayFieldValues; }
            set { arrayFieldValues = value; }
        }
        
        /// <summary>
        /// Método to obter os dados como uma Row
        /// </summary>
        /// <returns>A primeira row de dados ou null se não existir</returns>
        public string[] GetRowValoresCampos()
        {
            if (arrayFieldValues.Count == 0)
                return null;
            return arrayFieldValues[0];
        }
        /// <summary>
        /// Método to obter os dados como um escalar
        /// </summary>
        /// <returns>O primeira escalar de dados ou null se não existir</returns>
        public string GetScalarValoresCampos()
        {
            if (arrayFieldValues.Count == 0)
                return null;
            if (arrayFieldValues[0].Length == 0)
                return null;
            return arrayFieldValues[0][0];
        }

        /// <summary>
        /// Método que coloca ou devolve a lista com os nomes dos fields
        /// </summary>
        public List<string> ArrayNomesCamposIns
        {
            get { return arrayNomesCamposIns; }
            set { arrayNomesCamposIns = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve a lista com os nomes dos fields
        /// </summary>
        public List<string> ArrayValoresCamposIns
        {
            get { return arrayValoresCamposIns; }
            set { arrayValoresCamposIns = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o módulo a que pertence o pedido
        /// </summary>
        public string Module
        {
            get { return module; }
            set { module = value; }
        }
        /// <summary>
        /// Método que coloca ou devolve a db em uso neste pedido
        /// </summary>
        public string BD
        {
            get { return db; }
            set { db = value; }
        }
        /// <summary>
        /// Método que coloca ou devolve o nº de registos to uma Qlisting
        /// </summary>
        public int Numregs
        {
            get { return numregs; }
            set { numregs = value; }
        }
        /// <summary>
        /// Método que coloca ou devolve o Qvalue que diz se queremos saber o total de registos
        /// </summary>
        public bool ObterTotal
        {
            get { return obterTotal; }
            set { obterTotal = value; }
        }
        /// <summary>
        /// Método que coloca ou devolve o nº de registos to uma Qlisting
        /// </summary>
        public string ChavePai
        {
            get { return chavePai; }
            set { chavePai = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o Qvalue que diz se é um pedido dum Multiform
        /// </summary>
        public bool IsPedidoMF
        {
            get { return isPedidoMF; }
            set { isPedidoMF = value; }
        }

        /// <summary>
        /// Método que coloca ou devolve o Qvalue ao file a abrir pelo controlo de multiversões
        /// </summary>
        public string File
        {
            get { return file; }
            set { file = value; }
        }

		/// <summary>
        /// Nº do registo a partir do qual é to retornar elementos de uma Qlisting.
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }
		
		
		
		/// <summary>
        /// Adiciona um Qvalue de retorno to as opções da mensagem
        /// </summary>
        /// <param name="option">Opção da mensagem</param>
        /// <param name="value">Value to a opção da mensagem</param>
        public void SetOptionValue(string option, string value)
        {
            optionReturns[option] = value;
        }
    }
}
