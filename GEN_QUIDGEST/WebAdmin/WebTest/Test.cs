using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;

namespace WebTest
{
    public enum ResultType
    {
        Neutral,
        Good,
        Bad,
        BadInput
    };

    /// <summary>
    ///This is a test class for Test and is intended
    ///to contain all Test Unit Tests
    ///</summary>
    [TestClass()]
    [DeploymentItem(@"..\..\Extra")]
    public class Test
    {

        private readonly User user;
        private PersistentSupport sp;
        private Output outp;
        private Input inp;

        //mapeamento table, n_do_registo => key primária
        Dictionary<KeyValuePair<string, string>, string> primaryKeys = new Dictionary<KeyValuePair<string, string>, string>();

        //não devo testar estas tables
        //deveria saber isto através da biblioteca GenioServer.dll, mas não encontrei
        //talvez um TODO de AreaInfo.Ishardcoded seja boa ideia
        readonly string[] hardcodedTables = { "PSW", "MEM" };

        //a GLOB tem sempre só um registo, só deve ser testada a alteração
        readonly string[] oneRegisterTables = { "GLOB" };

        public Test()
        {
            if (!System.IO.File.Exists("Webtest.ini"))
                return;

            //ler as configurações a partir de um .INI
            //não está a ser usado, por agora
            System.IO.StreamReader iniFile = new System.IO.StreamReader("Webtest.ini");

            Dictionary<string, string> iniEntries = new Dictionary<string, string>();

            while (!iniFile.EndOfStream)
            {
                string line = iniFile.ReadLine();
                int ix = line.IndexOf('=');
                if (ix != -1)
                    iniEntries.Add(line.Substring(0, ix).Trim().ToUpper(), line.Substring(ix + 1).Trim());
            }
            iniFile.Close();

            if (!iniEntries.Keys.Contains("MODULE") || !iniEntries.Keys.Contains("INFILE") || !iniEntries.Keys.Contains("CONFFILE"))
                throw new KeyNotFoundException("There are missing entries in the INI file (MODULE or INFILE or CONFFILE)");

            if (!System.IO.File.Exists(iniEntries["INFILE"]))
                return;

            if (System.IO.File.Exists(iniEntries["CONFFILE"]))
            {

                //separador de directorias (\)
                char sep = System.IO.Path.DirectorySeparatorChar;

                //Criar a pasta bin se não existir
                string bindir = AppDomain.CurrentDomain.BaseDirectory;
                //acrescentar a barra se não estiver lá.
                if (bindir[bindir.Length - 1] != sep)
                    bindir += sep;
                bindir += "bin";

                if (!System.IO.Directory.Exists(bindir))
                    System.IO.Directory.CreateDirectory(bindir);

                //é necessário copiar o file Configuracoes.Xml to a dir "bin", pois o 
                //construtor estático do Configuration baseia-se nele duma maneira hardcoded
                System.IO.File.Copy(
                    iniEntries["CONFFILE"],
                    bindir + sep + System.IO.Path.GetFileName(iniEntries["CONFFILE"]),
                    true    //overwrite
                 );

                inp = new Input(iniEntries["INFILE"]);
                outp = new Output(null);

                try
                {
                    sp = PersistentSupport.getPersistentSupport(Configuration.DefaultYear);
                    user = new User("Test", "", Configuration.DefaultYear);
                    sp.openConnection();
                }
                catch (Exception ex)
                {
                    sp.closeConnection();
                    string msgEx = getExceptionMessage(ex);
                    throw new Exception("Error on authentication: " + msgEx, ex);
                }

                sp.closeConnection();

                if (!user.IsAuthorized(iniEntries["MODULE"]))
                    throw new KeyNotFoundException("The user could not get access to the specified module " + iniEntries["MODULE"]);

                user.CurrentModule = iniEntries["MODULE"];
            }
            else
                throw new System.IO.FileNotFoundException("One of the specified input files (INFILE/CONFFILE) has not been found.");
        }

        public Test(string mod)
        {
            try
            {
                sp = PersistentSupport.getPersistentSupport(Configuration.DefaultYear);
                user = new User("Test", "", Configuration.DefaultYear);
                sp.openConnection();
            }
            catch (Exception ex)
            {
                sp.closeConnection();
                string msgEx = getExceptionMessage(ex);
                throw new Exception("Error on authentication: " + msgEx, ex);
            }
            sp.closeConnection();

            if (!user.IsAuthorized(mod))
                throw new KeyNotFoundException("The user could not get access to the specified module " + mod);

            user.CurrentModule = mod;
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void TestFromVisualStudio()
        {
            if (inp == null)
                return;

            TestEverything(inp, outp);
        }

        [TestMethod]
        public void TestLigação()
        {
            try
            {
                sp = PersistentSupport.getPersistentSupport(Configuration.DefaultYear);
                sp.openConnection();
                Assert.IsNotNull(sp);
            }
            catch (Exception ex)
            {
                sp.closeConnection();
                string msgEx = getExceptionMessage(ex);
                throw new Exception("Error on authentication: " + msgEx, ex);
            }
            sp.closeConnection();
        }

        public void TestEverything(Input inp1, Output outp1)
        {
            outp = outp1;
            inp = inp1;
            TestUserManipulateTables();
        }

        /// <summary>
        /// Obtém do input os dados (fields,Qvalues) que queremos colocar no tuplo respectivo
        /// </summary>
        /// <param name="table"></param>
        /// <param name="lineData">número da linha</param>
        /// <returns>Um dicionario (Qfield,Qvalue). Atençãoo name do Qfield é devolvido no format TABLE.FIELD</returns>
        private Dictionary<string, string> getDataFromObjectArray(Area tableBD, string[] tableFields, object[] lineData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            //os dados propriamente ditos só começam a partir da 4º coluna
            for (int j = 0; j < tableFields.Length; j++)
            {
                if (lineData[j] != null)    //Qvalue
                {
                    string nomecampo = tableFields[j].ToString().ToLower();
                    string Qvalue = lineData[j].ToString();
                    data.Add(tableBD.Alias + "." + nomecampo, Qvalue);
                }
            }
            return data;
        }

        /// <summary>
        /// Handlig das mensagens das excepções
        /// </summary>
        /// <param name="ex">A excepção</param>
        /// <returns>A mensagem adequada à excepção</returns>
        private string getExceptionMessage(Exception ex)
        {
            if (ex is GenioException)
                return ((GenioException)ex).UserMessage;
            else
                return ex.Message;
        }

        /// <summary>
        /// obter o name da table que se relaciona com o Qfield key estrangeira em questão
        /// </summary>
        /// <param name="tableBD">a table abaixo</param>
        /// <param name="campo">o name do Qfield key estrangeira</param>
        /// <returns>o name da table acima na relação</returns>
        public string getRelatedTable(Area tableBD, string ncampo)
        {
            Field Qfield = tableBD.DBFields[ncampo];
            if (Qfield.FieldType == FieldType.CHAVE_ESTRANGEIRA || Qfield.FieldType == FieldType.CHAVE_ESTRANGEIRA_GUID)
            {
                foreach (KeyValuePair<string, Relation> p in tableBD.ParentTables)
                {
                    Relation rel = p.Value;
                    if (rel.SourceRelField == ncampo)
                        return rel.AliasTargetTab;
                }
            }
            throw new KeyNotFoundException("Error on the structure of the tables. Could not find table relationed with " + tableBD.Alias + "." + ncampo);
        }

        /// <summary>
        /// To os fields solicitados, percorre todos os que são chaves estrangeiras, e busca no mapa de 
        /// primary keys a key respectiva de mode a preencher com o Qvalue correspondente
        /// </summary>
        /// <param name="tableBD">table na qual queremos preencher as chaves estrangeiras</param>
        /// <param name="aliasedData"></param>
        /// <returns>
        /// Uma lista de entradas de fields e Qvalues, onde as posições no mapa já estão 
        /// substituídas pelos respectivos Qvalues de chaves estrangeiras
        /// </returns>
        private Dictionary<string, string> fillForeignKeys(string sheet, int sheetLine, Area tableBD, Dictionary<string, string> aliasedData)
        {
            Dictionary<string, string> dataWithForeignKeys = new Dictionary<string, string>(aliasedData);
            foreach (KeyValuePair<string, string> p in aliasedData)
            {
                //name do Qfield sem a table agarrada atrás
                string ncampo = p.Key.Substring(p.Key.IndexOf('.') + 1);
                Field Qfield = tableBD.DBFields[ncampo] as Field;

                if (Qfield.FieldType == FieldType.CHAVE_ESTRANGEIRA || Qfield.FieldType == FieldType.CHAVE_ESTRANGEIRA_GUID)
                {
                    string tabmae = getRelatedTable(tableBD, Qfield.Name);
                    KeyValuePair<string, string> pkey = new KeyValuePair<string, string>(tabmae, aliasedData[p.Key]);

                    if (primaryKeys.Keys.Contains(pkey))
                        dataWithForeignKeys[p.Key] = primaryKeys[pkey];
                    else
                        throw new KeyNotFoundException("Sheet '" + sheet + "' at line " + sheetLine + ":Update of a foreign key that has never been inserted");
                }
            }
            return dataWithForeignKeys;
        }

        /// <summary>
        /// Testar uma inserção com Qvalues dos fields definidos pelo user
        /// </summary>
        /// <param name="sheet">Name da folha</param>
        /// <param name="sheetLine">Nº da linha na folha</param>
        /// <param name="tableBD">Table onde se deseja fazer a inserção</param>
        /// <param name="expectedResult">VALID|INVALID</param>
        /// <param name="aliasedData">os dados de test no format de lista de entradas TABELA.CAMPO=>VALOR</param>
        /// <returns>Se for bem sucedida, devolve a key primária, caso contrário devolve null</returns>
        private string TestUserInsert(string sheet, int sheetLine, Area tableBD, string expectedResult, Dictionary<string, string> aliasedData)
        {
            string table = tableBD.TableName;
            string ret = null;

            try
            {
                sp.openTransaction();

                //substituir a key estrangeira pelo respectivo Qvalue mapeado
                Dictionary<string, string> dataWithForeignKeys = fillForeignKeys(sheet, sheetLine, tableBD, aliasedData);

                //atenção : o introduce só faz a abertura do registo com Qvalues dummy, e o preenchimento dos fields calculados ...
                tableBD = tableBD.insertPseud(sp, dataWithForeignKeys.Keys.ToArray(), dataWithForeignKeys.Values.ToArray());

                //to posteriormente adicionar a key primária ao mapa de chaves
                string primaryKey = Conversion.internalString2InternalValidString(tableBD.returnValueField(tableBD.Alias + "." + tableBD.PrimaryKeyName));

                tableBD.addNamesValuesFields(dataWithForeignKeys.Keys.ToArray(), dataWithForeignKeys.Values.ToArray());

                // ... o resto tem de ser feito com o change
                StatusMessage msg = tableBD.change(sp, (CriteriaSet)null);
                if (msg.Status == Status.OK)
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Valid insert ");
                    else
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Invalid insert ");

                    ret = primaryKey;
                }
                else
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid insert. Description : " + msg.Message);
                    else
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid insert. Description : " + msg.Message);
                    sp.rollbackTransaction();
                }

            }
            catch (Exception ex)
            {
                string msgEx = getExceptionMessage(ex);

                if (expectedResult == "VALID")
                    outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid insert. Description : " + msgEx);
                else
                    outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid insert. Description : " + msgEx);
                sp.rollbackTransaction();
            }

            sp.closeTransaction();

            return ret;
        }

        /// <summary>
        /// Testar uma alteração com Qvalues dos fields definidos pelo user
        /// </summary>
        /// <param name="sheet">Name da folha</param>
        /// <param name="sheetLine">Nº da linha na folha</param>
        /// <param name="tableBD">Table onde se deseja fazer a alteração</param>
        /// <param name="primaryKey">o registo ao qual se deseja fazer alteração</param>
        /// <param name="expectedResult">VALID|INVALID</param>
        /// <param name="aliasedData">os dados de test no format de lista de entradas TABELA.CAMPO=>VALOR</param>
        private void TestUserUpdate(string sheet, int sheetLine, Area tableBD, string primaryKey, string expectedResult, Dictionary<string, string> aliasedData)
        {
            string table = tableBD.TableName;

            try
            {
                sp.openTransaction();

                //substituir a key estrangeira pelo respectivo Qvalue mapeado
                Dictionary<string, string> dataWithForeignKeys = fillForeignKeys(sheet, sheetLine, tableBD, aliasedData);

                tableBD.insertNamesValuesFields(dataWithForeignKeys.Keys.ToArray(), dataWithForeignKeys.Values.ToArray());

                //a key tem que ser posta no fim dos Qvalues dos fields
                tableBD.insertNameValueField(tableBD.Alias + "." + tableBD.PrimaryKeyName, primaryKey);

                StatusMessage msg = tableBD.change(sp, (CriteriaSet)null);
                if (msg.Status == Status.OK)
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Valid update ");
                    else
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Invalid update ");
                }
                else
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid update. Description : " + msg.Message);
                    else
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid update. Description : " + msg.Message);
                    sp.rollbackTransaction();
                }

            }
            catch (Exception ex)
            {
                string msgEx = getExceptionMessage(ex);
                if (expectedResult == "VALID")
                    outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid update. Description : " + msgEx);
                else
                    outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid update. Description : " + msgEx);
                sp.rollbackTransaction();
            }

            sp.closeTransaction();
        }

        /// <summary>
        /// Testar uma eleimnação com Qvalues dos fields definidos pelo user
        /// </summary>
        /// <param name="sheet">Name da folha</param>
        /// <param name="sheetLine">Nº da linha na folha</param>
        /// <param name="tableBD">Table onde se deseja fazer a inserção</param>
        /// <param name="primaryKey">o registo que se deseja eliminate</param>
        /// <param name="expectedResult">VALID|INVALID</param>
        private void TestUserDelete(string sheet, int sheetLine, Area tableBD, string primaryKey, string expectedResult)
        {
            string table = tableBD.TableName;

            try
            {
                sp.openTransaction();

                tableBD.insertNameValueField(tableBD.Alias + "." + tableBD.PrimaryKeyName, primaryKey);
                StatusMessage msg = tableBD.eliminate(sp);
                if (msg.Status == Status.OK)
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Valid delete ");
                    else
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": SUCCESS on Invalid delete ");
                }
                else
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid delete. Description : " + msg.Message);
                    else
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid delete. Description : " + msg.Message);
                    sp.rollbackTransaction();
                }
            }
            catch (Exception ex)
            {
                string msgEx = getExceptionMessage(ex);
                if (expectedResult == "VALID")
                    outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on valid delete. Description : " + msgEx);
                else
                    outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid delete. Description : " + msgEx);
                sp.rollbackTransaction();
            }
            sp.closeTransaction();
        }

        /// <summary>
        /// Testar se os Qvalues de uma query de consulta são iguais aos indicados pelo user
        /// se o Qresult esperado for VALID
        /// </summary>
        /// <param name="sheet">Name da folha</param>
        /// <param name="sheetLine">Nº da linha na folha</param>
        /// <param name="tableBD">Table onde queremos testar a igualdade</param>
        /// <param name="primaryKey">o registo onde se deseja experimentar a igualdade</param>
        /// <param name="expectedResult">VALID|INVALID</param>
        /// <param name="aliasedData">os dados de test no format de lista de entradas TABELA.CAMPO=>VALOR</param>
        private void TestUserSelect(string sheet, int sheetLine, Area tableBD, string primaryKey, string expectedResult, Dictionary<string, string> aliasedData)
        {
            string table = tableBD.TableName;

            try
            {
                sp.openConnection();

                //substituir a key estrangeira pelo respectivo Qvalue mapeado
                Dictionary<string, string> dataWithForeignKeys = fillForeignKeys(sheet, sheetLine, tableBD, aliasedData);

                tableBD.insertNamesFields(dataWithForeignKeys.Keys.ToArray());
                //a key tem que ser posta no fim dos Qvalues dos fields
                tableBD.insertNameValueField(tableBD.Alias + "." + tableBD.PrimaryKeyName, primaryKey);

                tableBD.selectSingle((CriteriaSet)null, "", sp);

                // comparar o conjunto de Qvalues obtido da db com o esperado
                // primeiro, vou converter a hashtable num dicionário. 
                Dictionary<string, string> inTableData = new Dictionary<string, string>();

                foreach (DictionaryEntry p in tableBD.Fields)
                {
                    string key = (string)p.Key;
                    //saltar a key primária                        
                    if (key == tableBD.Alias + "." + tableBD.PrimaryKeyName)
                        continue;
                    string value = (string)(p.Value as RequestedField).Value;

                    inTableData.Add(key, value);
                }

                // não posso usar o Sequence Equal sem lhe fornecer um IEqualityComparer
                // pois ele espera que esteja tudo na mesma order
                // e fornecendo-lho dá trabalho que não justifica, por isso percorre-se um-a-um
                bool isEqual = true;

                if (dataWithForeignKeys.Count != inTableData.Count)
                    isEqual = false;
                else
                {
                    foreach (KeyValuePair<string, string> p in dataWithForeignKeys)
                    {
                        if (p.Value != inTableData[p.Key])
                        {
                            isEqual = false;
                            break;//basta um ser diferente, to que tudo seja diferente
                        }
                    }
                }

                if (isEqual)
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": EQUALITY on Valid select ");
                    else
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": EQUALITY on Invalid select ");
                }
                else
                {
                    if (expectedResult == "VALID")
                        outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": INEQUALITY on Valid select.");
                    else
                        outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": INEQUALITY on Invalid select.");
                }

            }
            catch (Exception ex)
            {
                string msgEx = getExceptionMessage(ex);
                if (expectedResult == "VALID")
                    outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Valid select. Description : " + msgEx);
                else
                    outp.log(ResultType.Good, "Sheet '" + sheet + "' at line " + sheetLine + ": FAILURE on Invalid select. Description : " + msgEx);
            }

            sp.closeConnection();
        }

        /// <summary>
        /// classe auxiliar to que se tenha cada uma das linhas do input
        /// de forma estruturada e adequada ao test
        /// </summary>

        class Line
        {
            /// <summary>
            /// name da Folha
            /// </summary>
            readonly string sheet;
            public string Sheet
            {
                get
                {
                    return sheet;
                }
            }

            /// <summary>
            /// número da linha na folha
            /// </summary>
            readonly int sheetLineNo;
            public int SheetLineNo
            {
                get
                {
                    return sheetLineNo;
                }
            }

            /// <summary>
            /// name da table
            /// </summary>
            readonly string table;
            public string Table
            {
                get
                {
                    return table;
                }
            }

            /// <summary>
            /// Resultado esperado: VALID|INVALID
            /// </summary>
            readonly string expectedResult;
            public string ExpectedResult
            {
                get
                {
                    return expectedResult;
                }
            }

            /// <summary>
            /// Type de operação INSERT|UPDATE|DELETE|SELECT
            /// </summary>
            readonly string operation;
            public string Operation
            {
                get
                {
                    return operation;
                }
            }

            /// <summary>
            /// N. relativo do registo. Servirá to mapeamento entre os registos e respectiva chaves primárias. 
            /// Assim, ao introduce um registo temos controlo sobre a sua key primária, permitindo-nos  
            /// referenciar o mesmo nas operações seguintes. 
            /// Além disso também nos permitirá fazer o cross-matching das chaves estrangeiras nas tables abaixo.
            /// </summary>
            readonly string recordN;
            public string RecordN
            {
                get
                {
                    return recordN;
                }
            }

            /// <summary>
            /// Os dados proprimante ditos em format de lista com entradas TABELA.CAMPO=>VALOR
            /// </summary>
            readonly Dictionary<string, string> data = new Dictionary<string, string>();
            public Dictionary<string, string> Data
            {
                get
                {
                    return data;
                }
            }

            /// <summary>
            /// Construtor. A única maneira de definirmos os fields de uma linha
            /// </summary>
            /// <param name="sht">Name da folha</param>
            /// <param name="shtLine">Nº da linha na folha</param>
            /// <param name="tab">Name da table</param>
            /// <param name="expRes">Resultado esperado</param>
            /// <param name="optn">Operação a efectuar</param>
            /// <param name="recn">Nº do registo</param>
            /// <param name="dat">Dados concretos</param>
            public Line(string sht, int shtLine, string tab, string expRes, string optn, string recn, Dictionary<string, string> dat)
            {
                sheet = sht;
                sheetLineNo = shtLine;
                table = tab;
                expectedResult = expRes;
                operation = optn;
                recordN = recn;
                data = dat;
            }
        }

        /// <summary>
        /// A partir do input, constrói uma lista com as respectivas entradas, ordenada pela forma como o 
        /// user lá as especificou
        /// </summary>
        /// <returns>a lista referida no summary</returns>
        private SortedList<int, Line> getSortedEntries()
        {
            List<string> lastTableFields = new List<string>();

            //nas linhas de table e fields é a table da própria linha;
            //nas linhas de dados é a última table que foi lida do input
            Area lastTableBD = null;

            SortedList<int, Line> sortedEntries = new SortedList<int, Line>();

            try
            {
                //DIGERIR O INPUT E ORDENÁ-LO PELA ORDEM ESPECIFICADA
                //Também faz validações impeditivas de continuar.
                foreach (KeyValuePair<KeyValuePair<string, int>, object[]> line in inp)
                {
                    //saltar a primeira linha
                    if (line.Key.Value == 1)
                        continue;

                    string sheet = line.Key.Key;
                    int sheetLineNo = line.Key.Value;
                    object[] lineData = line.Value;

                    string table = lineData[0] != null ? lineData[0].ToString().ToLower() : "";

                    //presumir que a linha está em branco e não interessa
                    if (table == "")
                        continue;

                    //é uma linha com operações
                    int order;
                    if (Int32.TryParse(table, out order))
                    {
                        if (lastTableFields.Count == 0 || lastTableBD == null)
                            throw new KeyNotFoundException("Tentativa de inserir registos antes da especificação da tabela");

                        //Resultado esperado default é VALID
                        String expectedResult = lineData[1] != null ? lineData[1].ToString().ToUpper() : "VALID";

                        //Operação: INSERT, UPDATE, DELETE e também SELECT
                        String operation = lineData[2] != null ? lineData[2].ToString().ToUpper() : "";

                        if (!new List<string> { "INSERT", "UPDATE", "DELETE", "SELECT" }.Contains(operation))
                        {
                            outp.log(ResultType.BadInput, "Table: " + table + " at line " + sheetLineNo + ": Invalid operation requested for table: " + table);
                            continue;
                        }

                        //Número do registo
                        //no INSERT precisamos dele to o mapeamanto Nº do registo => key primária
                        String recordN = lineData[3] != null ? lineData[3].ToString().ToUpper() : "";

                        Dictionary<string, string> data = new Dictionary<string, string>();
                        //só nos interessa o Qvalue dos fields se não for um DELETE
                        if (operation != "DELETE")
                            data = getDataFromObjectArray(lastTableBD, lastTableFields.ToArray(), lineData.Skip(4).ToArray());

                        Line l = new Line(sheet, sheetLineNo, lastTableBD.Alias, expectedResult, operation, recordN, data);

                        sortedEntries.Add(order, l);
                    }

                    //Tabelas hardcoded não devem ser testadas; 
                    //qd tiver + confiança nisto passo a testar no GLOB apenas a operação de UPDATE
                    else if (oneRegisterTables.Contains(table) || hardcodedTables.Contains(table))
                    {
                        outp.log(ResultType.BadInput, "It is not testable harcoded table: " + table);
                        continue;
                    }
                    else        //é uma linha que define table e fields
                    {
                        lastTableFields.Clear();

                        try
                        {
                            lastTableBD = Area.createArea(table.ToLower(), user, user.CurrentModule);
                        }
                        catch (Exception ex)
                        {
                            string msgEx = getExceptionMessage(ex);
                            outp.log(ResultType.Bad, "Sheet '" + sheet + "' at line " + sheetLineNo + ": Could not access the area: " + table + ". Exception is " + msgEx);
                            continue;
                        }

                        //só conta a partir da 5ª coluna; excluir a partir da primeira coluna em branco
                        for (int j = 4; j < lineData.Length && lineData[j] != null; j++)
                        {
                            //name do Qfield
                            String field = lineData[j].ToString().ToLower();

                            if (field == "" || !lastTableBD.DBFields.Keys.Contains(field))
                                throw new KeyNotFoundException("Sheet '" + sheet + "' at line " + sheetLineNo + ":  The area " + table + " does not have the field " + field + " referred at the column " + (j + 1));
                            lastTableFields.Add(field);
                        }
                    }
                }
                return sortedEntries;
            }
            catch (System.IndexOutOfRangeException)
            {
                System.Diagnostics.Debugger.Break();
                outp.log(ResultType.Bad, "Implementation error, please speak with the developer!");
                return null;
            }
        }

        /// <summary>
        /// Percorre todas as entradas do input, colocando-as numa lista ordenada pela forma lá indicada
        /// </summary>
        void TestUserManipulateTables()
        {
            SortedList<int, Line> sortedEntries = getSortedEntries();

            if (sortedEntries == null)
                return;

            //JÁ ESTÁ ORDENADO, AGORA É QUE COMEÇA A FAZER O TRABALHO A SÉRIO
            foreach (Line line in sortedEntries.Values)
            {
                Area tableBD = Area.createArea(line.Table.ToLower(), user, user.CurrentModule);

                KeyValuePair<string, string> idRecord = new KeyValuePair<string, string>(line.Table, line.RecordN);

                //testar INSERÇÃO
                if (line.Operation == "INSERT")
                {

                    if (primaryKeys.Keys.Contains(idRecord))
                    {
                        outp.log(ResultType.BadInput, "Sheet '" + line.Sheet + "' at line " + line.SheetLineNo + ": Insert of a primary key that has already been inserted");
                        continue;
                    }

                    //precisamos de acrescentar a key correspondente ao novo registo no mapa de chaves primárias
                    string primaryKey = TestUserInsert(line.Sheet, line.SheetLineNo, tableBD, line.ExpectedResult, line.Data);

                    if (primaryKey != null)
                        primaryKeys.Add(idRecord, primaryKey);
                }

                //testar ACTUALIZAÇÃO
                else if (line.Operation == "UPDATE")
                {
                    if (!primaryKeys.Keys.Contains(idRecord))
                    {
                        outp.log(ResultType.BadInput, "Sheet '" + line.Sheet + "' at line " + line.SheetLineNo + ": update of a primary key that has never been inserted");
                        continue;
                    }
                    TestUserUpdate(line.Sheet, line.SheetLineNo, tableBD, primaryKeys[idRecord], line.ExpectedResult, line.Data);

                }
                //testar REMOÇÃO
                else if (line.Operation == "DELETE")
                {
                    if (!primaryKeys.Keys.Contains(idRecord))
                    {
                        outp.log(ResultType.BadInput, "Sheet '" + line.Sheet + "' at line " + line.SheetLineNo + ": Delete of a primary key that has never been inserted");
                        continue;
                    }
                    TestUserDelete(line.Sheet, line.SheetLineNo, tableBD, primaryKeys[idRecord], line.ExpectedResult);
                }
                //o test do SELECT é to indicarmos um conjunto de Qvalues, e ver se a query corresponde a esses Qvalues
                else if (line.Operation == "SELECT")
                {
                    if (!primaryKeys.Keys.Contains(idRecord))
                    {
                        outp.log(ResultType.BadInput, "Sheet '" + line.Sheet + "' at line " + line.SheetLineNo + ": Select of a primary key that has never been inserted");
                        continue;
                    }
                    TestUserSelect(line.Sheet, line.SheetLineNo, tableBD, primaryKeys[idRecord], line.ExpectedResult, line.Data);
                }
            }
        }

        public static void AssertThrows<T>(Action action) where T : Exception
        {
            bool fail;
            try
            {
                action();
                fail = true;
            }
            catch (T)
            {
                fail = false;
            }

            if (fail)
                Assert.Fail(string.Format("Exception of type {0} should be thrown.", typeof(T)));
        }
    }
}
