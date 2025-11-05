using System;
using System.Collections.Generic;
using System.Web;
using Quidgest.Persistence.GenericQuery;
using CSGenio.framework;
using CSGenio.business;
using System.Text.RegularExpressions;
using CSGenio.persistence;
using CSGenio;

/// <summary>
/// Summary description for Condition
/// </summary>
public class Condition
{
        public static CriteriaSet construirCondicaoGeneric(string condition)
        {
            CriteriaSet res = CriteriaSet.And();
            string[] elemCond = condition.Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string elem in elemCond)
            {
                //filtros de activos
                if (elem.Contains("$FILTACT$"))
                {
                    construirElementoCondicaoFiltroActivo(res, elem);
                }
                else if (elem.Contains("IN(") || elem.Contains("INLP("))
                {
                    construirElementoCondicaoIN(res, elem);
                }
				else if (elem.Contains("$FAREA$") || elem.Contains("$SRHVAL$"))
                {
                    //Ignorar propositadamente
                    
                }
				//CN Grupos de Filtros Qweb
				else if (elem.Contains("$PREFILT$"))
                {
					Dictionary<string, List<CriteriaSet>> MapaFiltros = CriarMapa();
                    construirElementoCondicaoGruposFiltros(res, elem, MapaFiltros);
                }
                else
                {
                    construirElementoCondicaoNormal(res, elem);
                }
            }

            return res;
        }

        private static void construirElementoCondicaoFiltroActivo(CriteriaSet res, string elem)
        {
			//CN Grupos de Filtros Qweb
			//Se existirem outros grupos de filtros, retira da string to construção da condição de filtro ativo
            int idx0 = 0;
            string OriginalElem = "";
            string GruposElem = "";
            if (elem.Contains("$PREFILT$"))
            {
                idx0 = elem.IndexOf("$PREFILT$");
                OriginalElem = elem;
                elem = elem.Substring(0, idx0 - 1);

                GruposElem = OriginalElem.Substring(idx0);
                Dictionary<string, List<CriteriaSet>> DicionarioFiltros = CriarMapa();
                construirElementoCondicaoGruposFiltros(res, GruposElem, DicionarioFiltros);
            }

            //separar a condição em datas consultadas, filtro e data de referencia
            string[] atoms = elem.Split(new char[] { '[' }, StringSplitOptions.None);
            if (atoms.Length < 3)
            {
                throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
            }
            //parsing intermédio
            string datas = atoms[0];
            string checkboxes = atoms[1];
            string hoje = atoms[2];

            //parsing final
            atoms = datas.Split(new char[] { '/' }, StringSplitOptions.None);
            string dataini = atoms[0];
            string datafim = atoms[1];
            bool activo = checkboxes[9] == '1';
            bool inactivo = checkboxes[10] == '1';
            bool futuro = checkboxes[11] == '1';
            //hoje = Conversion.dateString2DateStringConverted(hoje.Trim('#', ' ', '\n')); //não sei porque é que por vezes a condição vem com whitespace
            DateTime hojeDt = ConversaoQweb.ToDateTime(hoje.Trim('#', ' ', '\n'));

            ColumnReference datainiColumn = null;
            ColumnReference datafimColumn = null;
            if (!String.IsNullOrEmpty(dataini))
            {
                string[] datainiParts = dataini.Split('.');
                if (datainiParts.Length > 1)
                {
                    datainiColumn = new ColumnReference(datainiParts[0], datainiParts[1]);
                }
                else
                {
                    datainiColumn = new ColumnReference(null, datainiParts[0]);
                }
            }
            if (!String.IsNullOrEmpty(datafim))
            {
                string[] datafimParts = datafim.Split('.');
                if (datafimParts.Length > 1)
                {
                    datafimColumn = new ColumnReference(datafimParts[0], datafimParts[1]);
                }
                else
                {
                    datafimColumn = new ColumnReference(null, datafimParts[0]);
                }
            }

            //oito casos diferentes (RS: deve haver forma mais inteligente de fazer isto mas nao estou com cabeça)
            if (activo && inactivo && futuro)
            {
                //Todos, nao limita nada
                return;
            }
            if (activo && !inactivo && !futuro)
            {
                //So activos
                res.SubSet(CriteriaSet.Or()
                        .GreaterOrEqual(hojeDt, datainiColumn)
                        .Equal(datainiColumn, null))
                    .SubSet(CriteriaSet.Or()
                        .LesserOrEqual(hojeDt, datafimColumn)
                        .Equal(datafimColumn, null));

                return;
            }
            if (activo && inactivo && !futuro)
            {
                //So activos e inactivos
                res.SubSet(CriteriaSet.Or()
                    .GreaterOrEqual(hojeDt, datainiColumn)
                    .Equal(datainiColumn, null));

                return;
            }
            if (activo && !inactivo && futuro)
            {
                //So activos e futuros
                res.SubSet(CriteriaSet.Or()
                    .LesserOrEqual(hojeDt, datafimColumn)
                    .Equal(datafimColumn, null));

                return;
            }
            if (!activo && inactivo && futuro)
            {
                //So inactivos e futuros
                res.SubSet(CriteriaSet.Or()
                    .Lesser(hojeDt, datainiColumn)
                    .SubSet(CriteriaSet.And()
                        .Greater(hojeDt, datafimColumn)
                        .NotEqual(datafimColumn, null)));

                return;
            }
            if (!activo && !inactivo && futuro)
            {
                //So futuros
                res.SubSet(CriteriaSet.Or()
                    .Lesser(hojeDt, datainiColumn) // data actual inferior à data de início
                    .SubSet(CriteriaSet.And() // data de fim é superior à actual e a de início não exists
                        .Greater(datafimColumn, hojeDt)
                        .Equal(datainiColumn, null))
                    .SubSet(CriteriaSet.And() // data de início e de fim vazias
                        .Equal(datainiColumn, null)
                        .Equal(datafimColumn, null)));

                return;
            }
            if (!activo && inactivo && !futuro)
            {
                //So inactivos
                res.Greater(hojeDt, datafimColumn)
                    .NotEqual(datafimColumn, null);

                return;
            }
            if (!activo && !inactivo && !futuro)
            {
                //Estados incongruentes (Data de saída inferior à data de entrada)
                res.Lesser(datafimColumn, datainiColumn);

                return;
            }
        }

		//CN Grupos de Filtros Qweb
		public static Dictionary<string, List<CriteriaSet>> CriarMapa()
		{
			Dictionary<string, List<CriteriaSet>> res = new Dictionary<string, List<CriteriaSet>>();
			List<CriteriaSet> Grupo = new List<CriteriaSet>();
                                                                                                                          return res;
}

		//CN Grupos de Filtros Qweb
		private static void construirElementoCondicaoGruposFiltros(CriteriaSet res, string elem, Dictionary<string, List<CriteriaSet>> MapaFiltros)
        {
			//separar a condição em posição (menu ou form), grupo de filtros e filtros do grupo
			string[] listaFiltros = elem.Split(new char[] { '[', }, StringSplitOptions.RemoveEmptyEntries);
			if (listaFiltros.Length < 3)
			{
				throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
			}

			CriteriaSet FinalCriteria = CriteriaSet.And();
			var countFilters = listaFiltros.Length - 1;
			for (int i = 1; i < countFilters; i += 2)
			{
				var GrupoCriteria = listaFiltros[i];
				var Checkboxes = listaFiltros[i + 1];
				char[] ListCheckbox = Checkboxes.ToCharArray();
				List<CriteriaSet> Lista = MapaFiltros[GrupoCriteria];
				if (Lista.Count == 1)
				{
					//se apenas há um então vamos apenas buscar o subset correspondente
					if (ListCheckbox.Length == 1)
					{
						int idSub = (int)Char.GetNumericValue(ListCheckbox[0]) - 1;
						if(idSub >= 0)
						{
							if (Lista[0].SubSets.Count > 0)
								FinalCriteria.SubSet(CriteriaSet.And().SubSet(Lista[0].SubSets[idSub]));
							else
								FinalCriteria.SubSet(CriteriaSet.And().SubSet(Lista[0]));
						}
                    
					}
					else if(ListCheckbox.Length > 0)
					{
						//se há mais que um é multi 010 podendo estar vários ativos
						CriteriaSet multi = CriteriaSet.Or();
						for (int pos = 0; pos < ListCheckbox.Length; pos++)
						{
							string check = ListCheckbox[pos].ToString();
							if (check == "1")
								multi.SubSet(CriteriaSet.Or().SubSet(Lista[0].SubSets[pos]));
						}

						if(multi.SubSets.Count > 0)
							FinalCriteria.SubSet(multi);
					}
				}
				else
				{
					throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
				}
			}
			res.SubSet(FinalCriteria);
		}

        public static void construirCondicaoFiltraArea(Comunicacao comunicacao, User user)
        {
            adicionarCondicaoFiltraArea(comunicacao.CondicaoSQL, comunicacao.CondicaoOriginal, comunicacao.Identificador, comunicacao.Module, user);
        }

		public static void adicionarCondicaoFiltraArea(CriteriaSet conditions, string originalCondition, string identifier, string module, User user)
        {
            string[] elemCond = originalCondition.Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string elem in elemCond)
            {
                if(elem.Contains("$FAREA$"))
                {
			        string[] elems = elem.Split('#');
                    string[] expr = elems[1].Split('/');
			        string areaBase = expr[0];
			        string key = expr[1];
			        string areaFiltra = expr[2];

                    Area areaF = Area.createArea(areaFiltra, user, module);
                    CriteriaSet condicoesEph = Listing.CalculateConditionsEphGeneric(areaF, identifier);
                    
                    
			        AreaInfo areaB = Area.GetInfoArea(areaBase);
                    Relation relBase = areaF.ParentTables[areaBase];
			        //Field cmp = areaB.DBFields[key];
			        //Field cmp2 = areaF.DBFields[key];

			        //key IN (SELECT key FROM areaFiltra)              
			        SelectQuery expression = new SelectQuery();
			        expression.Select(areaF.Alias, relBase.SourceRelField);
			        expression.From(areaF.TableName, areaF.Alias);
                    CriteriaSet where = CriteriaSet.And();
                    if (elems[2] != "")
                    {
                        string[] chaves = elems[2].Split('/');
                        string[] areas = elems[0].Split('/');
                        
                        for (int i = 0; i < chaves.Length; i++)
                        {
                            Relation rel = areaF.ParentTables[areas[i]];
                            string Qfield = areaF.Alias + "." + rel.SourceRelField;
                            construirElementoCondicaoIN(where, Qfield + "IN " + "({" + chaves[i].Replace(",", "},{") + "})");
                        }
                    }
                    where.SubSet(condicoesEph);
                    expression.Where(where);
			        conditions.In(areaB.Alias, key, expression);

                    return;
                }
            }
            throw new FrameworkException("Condição inválida", "adicionarCondicaoFiltraArea", "formato do campo inválido");
		}

        private static void construirElementoCondicaoIN(CriteriaSet res, string elem)
        {
            //separar a condição em Qfield, operador e Qvalue
            //usar IN( se for to usar a condição no caso de IN('')
            //usar INLP( se for to ignorar a condição no caso de IN(''), e o significado é remover os filtros anteriores 
            string[] atoms = elem.Split(new string[] { "INLP" }, StringSplitOptions.None);
            bool limparFiltro = false;

            if (atoms.Length == 2)
            {
                limparFiltro = true;
            }
            else
            {
                atoms = elem.Split(new string[] { "IN" }, StringSplitOptions.None);
            }

            if (atoms.Length < 2)
            {
                throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
            }
            string Qfield = atoms[0].Trim();
            string listaValores = atoms[1].Trim();

            //se o Qfield for um guid temos de transformar o operador e o Qvalue
            int ix = Qfield.IndexOf('.');
            if (ix == -1)
            {
                throw new FrameworkException("Condição inválida", "construirCondicao, a condição não está no formato area.campo", "formato do campo inválido");
            }

            //Testar formatações e conversão dos Qvalues
            AreaInfo info = Area.GetInfoArea(Qfield.Substring(0, ix));
            Field cmp = info.DBFields[Qfield.Substring(ix + 1)];

            if (listaValores != "()")
            {
                listaValores = listaValores.Substring(1, listaValores.Length - 2);
                string[] Qvalues = listaValores.Split(',');
                object[] realValues = new object[Qvalues.Length];
                for (int i = 0; i < Qvalues.Length; i++)
                {
                    realValues[i] = ParseConditionValue(cmp, Qvalues[i]);
                }

                res.In(info.Alias, cmp.Name, realValues);
            }
            else if (!limparFiltro)
            {
                res.In(info.Alias, cmp.Name, new string[] { "" });
            }
        }

        private static void construirElementoCondicaoNormal(CriteriaSet res, string elem)
        {
            //([pdart.forneced[LIKE['*xpto*'[OR[pdart.artigopd[LIKE['*xpto*'[OR[pdart.marca[LIKE['*xpto*'[OR[pdart.modelo[LIKE['*xpto*'[)
            //remove ( and )
            string condexpr = elem.Trim("()".ToCharArray());
            string[] listaCondicoes = Regex.Split(condexpr, "\\[OR\\[");

            CriteriaSet condicaoOr = CriteriaSet.Or();
            foreach (string cond in listaCondicoes)
            {
                //separar a condição em Qfield, operador e Qvalue
                string[] atoms = cond.Split(new char[] { '[' }, StringSplitOptions.RemoveEmptyEntries);
                if (atoms.Length < 3)
                {
                    throw new FrameworkException("Condição inválida", "construirCondicao", "Número de parametros da condição insuficiente");
                }
                string Qfield = atoms[0];
                string operador = atoms[1];
                string Qvalue = atoms[2];
                ISqlExpression field = null;

                //se o Qfield for um guid temos de transformar o operador e o Qvalue
                int ix = Qfield.IndexOf('.');
                if (ix == -1)
                {
                    throw new FrameworkException("Condição inválida", "construirCondicao, a condição não está no formato area.campo", "formato do campo inválido");
                }
                //Aplicar formatações de condições dependentes do tipo do Qfield
                //criar funções to transformar condições na classe de formatação caso se queira tornar isto mais geral
                AreaInfo info = Area.GetInfoArea(Qfield.Substring(0, ix));
                Field tipo, cmp;
                if (info.DBFields.TryGetValue(Qfield.Substring(ix + 1), out tipo))
                {
                    cmp = info.DBFields[Qfield.Substring(ix + 1)];
                }
                else
                    cmp = new Field(info.Alias, Qfield, FieldType.TEXT);

                field = new ColumnReference(info.Alias, cmp.Name);

                object realValue = ParseConditionValue(cmp, Qvalue);

                //AV(2010/09/13) Passa a ser possível pesquisar pelos textos dos arrays em vez dos códigos que os utilizadores desconhecem
                if (operador == "LIKE")
                {
                    if (cmp.FieldType == FieldType.ARRAY_NUMERIC || cmp.FieldType == FieldType.ARRAY_TEXT || cmp.FieldType == FieldType.ARRAY_LOGIC)
                    {
                        //os arrays não suportam like
                        operador = "=";
                        realValue = Qvalue.Trim('*', '\'');
                    }
					else if (cmp.FieldFormat == FieldFormatting.CARACTERES)
                    {
                        field = SqlFunctions.Trim(field);
                    }
                }

                condicaoOr.Criterias.Add(new Criteria(
                    field,
                    QueryUtils.ParseSqlOperator(operador),
                    realValue));
            }

            res.SubSet(condicaoOr);
        }

        /// <summary>
        /// Converte um Qvalue da condição de string to objecto consoante o tipo do Qfield
        /// </summary>
        /// <param name="cmp">O Qfield ao qual o Qvalue se refere</param>
        /// <param name="valor">O Qvalue vindo da string da condição</param>
        private static object ParseConditionValue(Field cmp, string Qvalue)
        {
            object realValue = Qvalue;
            if (cmp.FieldFormat == FieldFormatting.GUID && Qvalue.Trim('\'').Length == 0)
            {
                realValue = null;
            }
            else if (cmp.FieldFormat == FieldFormatting.DATA)
            {
                if (Qvalue.Contains("#"))
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
                    try
                    {
						realValue = ConversaoQweb.ToDateTime(Qvalue.Substring(i1 + 1, i2 - i1 - 1));
                    }
                    catch
                    {
                        realValue = Field.GetValorEmpty(FieldFormatting.DATA);
                    }
                }
                else
                {
					try
                    {
						realValue = ConversaoQweb.ToDateTime(Qvalue);
                    }
                    catch
                    {
                        realValue = Field.GetValorEmpty(FieldFormatting.DATA);
                    }
                }
            }
            else if (cmp.FieldFormat == FieldFormatting.CARACTERES && Qvalue.Length == 0)
            {
                realValue = String.Empty;
            }
            else if ((cmp.FieldFormat == FieldFormatting.CARACTERES || cmp.FieldFormat == FieldFormatting.GUID) && Qvalue.Length > 0)
            {
                //Assume que o Qvalue vem delimitado por plicas o que significa que tem pelo menos dois characters
                //Caso não venha desta forma então é considerado nulo e assumimos a string vazia.
                //Não se deve interferir em plicas que estejam no meio da primeira e ultima plica,
                // e devem ser interpretadas literalmente .ie uma plica é uma plica.
                if (Qvalue.Length > 2)
                {
					//RS(09-01-2015) Enquanto as condições vindas do Qweb formatarem uma plica como 2 plicas no meio de strings, este replace adicional é necessario
					// to alem da remoção da primeira e ultimas plicas.
                    realValue = Qvalue.Substring(1, Qvalue.Length - 2).Replace("''", "'");
                }
                else
                {
                    realValue = null;
                }
            }
            else if (cmp.FieldFormat == FieldFormatting.TEMPO)
            {
                //TODO: quando o Qweb3 for normalizado na forma como passa os dados isto devia usar a classe de conversaoQweb to obter o dado interno
                realValue = Qvalue.Trim('\'');
            }
            else if (cmp.FieldFormat == FieldFormatting.FLOAT)
            {
                realValue = ConversaoQweb.ToDouble(Qvalue);
            }
            else if (cmp.FieldFormat == FieldFormatting.LOGICO || cmp.FieldFormat == FieldFormatting.INTEIRO)
            {
                realValue = ConversaoQweb.ToInteger(Qvalue.Trim('\''));
            }

            return realValue;
        }

        public static IList<ColumnSort> construirOrdenacao(string sorting)
        {
            IList<ColumnSort> result = new List<ColumnSort>();

            if (!String.IsNullOrEmpty(sorting))
            {
                string[] orderTerms = sorting.Split(',');
                foreach (string orderTerm in orderTerms)
                {
                    string[] orderTermParts = orderTerm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (orderTermParts.Length < 1)
                    {
                        throw new FrameworkException("Ordenação inválida", "construirOrdenacao", "Número de parametros da ordenação insuficiente");
                    }

                    string[] fieldNameParts = orderTermParts[0].Split('.');
                    string tableAlias = null;
                    string columnName = null;
                    if (fieldNameParts.Length == 1)
                    {
                        columnName = fieldNameParts[0];
                    }
                    else if (fieldNameParts.Length > 1)
                    {
                        tableAlias = fieldNameParts[0];
                        columnName = fieldNameParts[1];
                    }
                    else
                    {
                        throw new FrameworkException("Ordenação inválida", "construirOrdenacao", "O campo da ordenação não está no formato area.campo");
                    }

                    ColumnReference column = new ColumnReference(tableAlias, columnName);
                    if (orderTermParts.Length > 1
                        && String.Equals(orderTermParts[1].Trim(), "DESC", StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(new ColumnSort(column, SortOrder.Descending));
                    }
                    else
                    {
                        result.Add(new ColumnSort(column, SortOrder.Ascending));
                    }
                }
            }

            return result;
        }
        
        
        public static IList<SelectField> construirCamposPedido(string []fieldsRequested)
        {
            IList<SelectField> result = new List<SelectField>();

            if (fieldsRequested != null)
            {
                foreach (string field in fieldsRequested)
                {
                    string[] fieldParts = field.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (fieldParts.Length < 1)
                    {
                        throw new FrameworkException("Lista de campos inválida", "construirCamposPedido", "Número de parametros do campo insuficiente");
                    }

                    string[] fieldNameParts = fieldParts[0].Split('.');
                    string tableAlias = null;
                    string columnName = null;
                    if (fieldNameParts.Length == 1)
                    {
                        columnName = fieldNameParts[0];
                    }
                    else if (fieldNameParts.Length > 1)
                    {
                        tableAlias = fieldNameParts[0];
                        columnName = fieldNameParts[1];
                    }
                    else
                    {
                        throw new FrameworkException("Lista de campos  inválida", "construirCamposPedido", "O campo não está no formato area.campo");
                    }

                    ColumnReference column = new ColumnReference(tableAlias, columnName);
                    if (fieldParts.Length > 1)
                    {
                        result.Add(new SelectField(column, fieldParts[1]));
                    }
                    else
                    {
                        result.Add(new SelectField(column, tableAlias == null ? null : String.Format("{0}.{1}", column.TableAlias, column.ColumnName)));
                    }
                }
            }

            return result;
        }

        public static ITableSource construirTabelaPedido(string table)
        {
            if (String.IsNullOrEmpty(table))
            {
                throw new ArgumentNullException("tabela");
            }

            string[] parts = table.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 1)
            {
                throw new FrameworkException("Referência a tabela inválida", "construirTabelaPedido", "Número de parametros da tabela insuficiente");
            }

            string name = parts[0];
            string alias = parts[parts.Length - 1]; // if reference as no alias specified, the alias will be the table name

            return new TableReference(name, alias);
        }

}
