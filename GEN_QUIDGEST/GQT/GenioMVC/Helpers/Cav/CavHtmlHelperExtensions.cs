using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Cav
{
    public static class CavHtmlHelperExtensions
    {
        public static string FinalResults(this HtmlHelper html, List<SpecialList> results)
        {
            StringBuilder htmlOutput = new StringBuilder();

            //htmlOutput.AppendLine("<table id=\"results\" class=\"condensed-table zebra-striped results\">");
            htmlOutput.AppendLine("<table id=\"results\" class=\"c-table results\">");

            int count = 1;
            foreach (SpecialList row in results)
            {
                // isto também não pode ser feito aqui, assume que a primeira linha é sempre um cabeçalho
                //if (count == 1)
                //    htmlOutput.AppendLine("<thead>");

                if (row.Type == LineType.GroupHeader || row.Type == LineType.TotalHeader)
                    htmlOutput.Append("<tr class=\"group-header\">");
                else
                    htmlOutput.Append("<tr>");

                foreach (string cell in row)
                {
                    if (row.Type == LineType.Header || row.Type == LineType.TotalHeader || row.Type == LineType.GroupHeader)
                        htmlOutput.AppendFormat("<th>{0}</th>", cell);
                    else
                        htmlOutput.AppendFormat("<td>{0}</td>", cell);
                }

                htmlOutput.AppendLine("</tr>");

                if (count == 1)
                {
                    htmlOutput.AppendLine("</thead>");
                    htmlOutput.AppendLine("<tbody>");
                }

                count++;
            }

            htmlOutput.AppendLine("</tbody>");
            htmlOutput.AppendLine("</table>");
            return htmlOutput.ToString();
        }

        private static void DrawTableSeparatorLine(StringBuilder htmlOutput, int n)
        {
            // acrescenta uma row em branco
            htmlOutput.AppendFormat("<th class=\"separator\" colspan={0}>&nbsp;</th>", n);

            // desenha uma linha na tabela
            //htmlOutput.Append("<tr>");
            //for (int i = 0; i < n; i++)
            //    htmlOutput.Append("<th style=\"border-top: 1px solid #000000;\"></th>");
            //htmlOutput.Append("</tr>");
        }

        public static void ResultsTable(this HtmlHelper html, StringBuilder htmlOutput, ReportReplyGroup group, ReportDefinition query, int nivel, bool first, List<ReportField> allFields)
        {
            // se tem filhos, então estamos num grupo
            if (!group.IsLeaf())
            {

                // tem pageBreak ?
                bool pageBreak = false;
                if (nivel <= query.Groups.Count && nivel > 0)
                    pageBreak = query.Groups[nivel - 1].PageBreak;

                // o limite é o número de campos agrupados, os restantes valores são valores totalizadores
                // aqui temos de descobrir quantos campos são agregados e subtrair esse valor ao número total de campos
                // caso contrário a opção seria saber quantos campos de groupBy existem a este nível
                // o que requer precorrer todos os grupos até nivel -1 e somar os campos de groupBy que não são totalizadores
                int limite = (nivel > 0 && nivel <= query.Groups.Count) ? group.Values.Count - query.Groups[nivel - 1].Fields.Count(f => !string.IsNullOrEmpty(f.TotalType)) : 0;

                if (nivel == 1)
                    htmlOutput.AppendLine("<tbody>");

                // sabe-se que existe pelo menos um filho, porque já se testou com !IsLeaf(group)
                //if (IsLeaf(group.Groups[0]))
                // se o 1º filho é detalhe desenha-se uma linha a separar um novo conjunto de detalhes
                //   DrawTableSeparatorLine(htmlOutput, allFields.Count + 1);

                // chamada recursiva para escrever os "filhos" do grupo actual
                for (int i = 0; i < group.Groups.Count; i++)
                {
                    html.ResultsTable(htmlOutput, group.Groups[i], query, nivel + 1, i == 0, allFields);
                }

                //if (IsLeaf(group.Groups[0]))
                //DrawTableSeparatorLine(htmlOutput, allFields.Count + 1);

                // os totalizadores passam a ser exibidos no final de cada grupo da seguinte forma
                //           campo1   campo2   ...   campoN   ...   campoX   campoY   campoZ       (linha do cabeçalho da tabela)
                // ....                                                                            (linhas de detalhes e sub-grupos)
                // Grupo N   valor1   valor2   ...   valorN                                        (linha dos valores do grupo)
                // SUM                                                  11       13       17       (linhas dos valores dos totalizadores para cada campo)
                // MAX                                                   3        5        7
                // MIN                                                   -        -        2       (podem não ter sido pedidos totalizadores para todas as colunas, nestes casos deixa um espaço em branco)

                bool escreveNivel = false;

                // se existem totalizadores
                if (group.Values.Count > limite)
                {
                    // primeiro descobrimos qual a lista de totalizadores no nível actual onde temos de procurar
                    List<ReportField> listaTotalizadores = null;
                    escreveNivel = false;

                    if (nivel > 0 && nivel <= query.Groups.Count)
                        listaTotalizadores = query.Groups[nivel - 1].Fields.FindAll(x => !string.IsNullOrEmpty(x.TotalType));
                    else
                        listaTotalizadores = query.DetailsGroup.Fields.FindAll(x => !string.IsNullOrEmpty(x.TotalType));

                    foreach (string[] totalType in ReportExtensions.totaTypeLabels)
                    {
                        // totalType[0] - id da função
                        // totalType[1] - label com a descrição da função

                        // lista de totalizadores para o tipo de função actual
                        List<ReportField> totalizadores = listaTotalizadores.FindAll(x => x.TotalType.Equals(totalType[0]));

                        // se existem totalizadores deste tipo
                        if (totalizadores.Count > 0)
                        {
                            // se ainda não escreveu o cabeçalho para este conjunto de totalizadores, então escreve-o antes dos valores
                            if (!escreveNivel)
                            {

                                escreveNivel = true;

                                // acrescenta uma linha em branco para ajudar na visualização
                                //htmlOutput.AppendFormat("<th colspan={0}>&nbsp;</th>", allFields.Count+1);

                                // escreve o nível do grupo e os valores pelos quais está agrupado nas respectivas colunas
                                htmlOutput.Append("<tr class=\"group-header\">");
                                if (nivel == 0)
                                    htmlOutput.AppendFormat("<th>Totais</th>");
                                else
                                    htmlOutput.AppendFormat("<th>Grupo {0}</th>", nivel);
                                for (int i = 0; i < allFields.Count; i++)
                                {
                                    if (i < nivel)
                                        htmlOutput.AppendFormat("<th>{0}</th>", string.IsNullOrEmpty(group.Values[i]) ? "-" : group.Values[i]);
                                    else
                                        htmlOutput.Append("<th></th>");
                                }
                                htmlOutput.Append("</tr>");
                            }

                            htmlOutput.Append("<tr class=\"group-item\">");
                            htmlOutput.AppendFormat("<th>{0}</th>", totalType[1]); // descrição do totalizador

                            // cria uma lista de "células" vazias onde vão ser colocados os valores para este agregador
                            List<string> values = new List<string>();

                            for (int i = 0; i < allFields.Count; i++)
                                values.Add("");

                            // coloca os valores nas respectivas colunas
                            foreach (ReportField f in totalizadores)
                            {
                                // isto tem de devolver sempre um valor válido, se não algo correu mal noutro sitio!
                                int pos = allFields.FindIndex(x => x.FieldId == f.FieldId);
                                int posTotalGroup = listaTotalizadores.FindIndex(x => x.FieldId == f.FieldId && x.TotalType == f.TotalType);
                                values[pos] = group.Values[posTotalGroup + limite];
                            }

                            // cria a linha com os valores
                            foreach (string value in values)
                                htmlOutput.AppendFormat("<th>{0}</th>", value);

                            htmlOutput.Append("</tr>");

                        }
                    }
                }

                if (nivel == 1)
                {
                    htmlOutput.AppendLine("</tbody>");
                    DrawTableSeparatorLine(htmlOutput, allFields.Count + 1);
                }

            }
            else
            {
                // se não tem filhos estamos numa linha

                // TODO
                // para obter o pagebreak a este nível é necessário aceder a query.Groups[nivel - 2]
                // aqui podemos verificar se estamos no primeiro elemento do grupo (if (first)) para escrever o cabeçalho, caso pagebreak = true
                // (se calhar este caso pode passar para a parte do if, porque a cada cabeçalho de um grupo é que sabemos se queremos escrever ou não as colunas - neste caso o first torna-se obsoleto)

                // escreve os valores da linha
                htmlOutput.Append("<tr>");

                // acrescenta uma coluna escondida à esquerda para ter os títulos dos totalizadores
                htmlOutput.AppendFormat("<td></td>");

                foreach (string value in group.Values)
                {
                    htmlOutput.Append("<td>");
                    htmlOutput.Append(string.IsNullOrEmpty(value) ? "-" : value);
                    htmlOutput.Append("</td>");
                }
                htmlOutput.AppendLine("</tr>");
            }
        }


        public static string Create_Results(this HtmlHelper html, ReportReplyGroup group, ReportDefinition query)
        {
            StringBuilder htmlOutput = new StringBuilder();

            // obtêm-se os campos do report
            List<ReportField> allFields = query.GetReportFields();

            // a forma de desenho de queries multi-datasource com o modo PAGE (resultados separados por datasource)
            // requer um desenho do report ligeiramente diferente do "normal"
            // TODO: penso que esta lógica e a escrita dos cabeçalhos das tabelas pode passar para a função ResultsTable
            if (query.Years.Count > 0 && query.MultiYearMode == "PAGE")
            {
                // modo paginado por ano - para cada ano renderiza o grupo principal
                int i = 0;
                foreach (var subgroup in group.Groups)
                {
                    htmlOutput.AppendFormat("<p><strong>Ano {0}</strong></p>", query.Years[i]);

                    htmlOutput.AppendFormat("<table id=\"results{0}\" class=\"condensed-table zebra-striped results\">", query.Years[i]);

                    htmlOutput.Append("<thead><tr>");

                    // acrescenta uma coluna escondida à esquerda para ter os títulos dos totalizadores
                    htmlOutput.AppendFormat("<th></th>");

                    // acrescenta as colunas "normais" da tabela
                    foreach (ReportField f in allFields)
                        htmlOutput.AppendFormat("<th>{0}</th>", f.GetTitle());

                    htmlOutput.Append("</tr></thead>");

                    // renderiza o subgrupo para o ano nº i
                    htmlOutput.AppendLine("<tbody>");
                    html.ResultsTable(htmlOutput, subgroup, query, 0, true, allFields);
                    htmlOutput.AppendLine("</tbody>");

                    htmlOutput.AppendLine("</table>");

                    i++;
                }
            }
            else
            {
                // modo "normal" - renderiza os cabeçalhos e o maingroup

                // TODO: este caso pode passar para dentro da função? como se faz isto?
                // pode-se acrescentar um parametro extra que vem de cima e que diz se tem pagebreak ou não
                // cujo valor por omissão quando se invoca a função aqui é true, o que obriga a escrever sempre os cabeçalhos
                // testar para verificar se isto funciona bem (aproveitar a oportunidade quando se implementar os pagebreaks)

                htmlOutput.AppendLine("<table id=\"results\" class=\"condensed-table zebra-striped results\">");

                htmlOutput.Append("<thead><tr>");

                // acrescenta uma coluna escondida à esquerda para ter os títulos dos totalizadores
                htmlOutput.AppendFormat("<th></th>");

                // acrescenta as colunas "normais" da tabela
                foreach (ReportField f in allFields)
                    htmlOutput.AppendFormat("<th>{0}</th>", f.GetTitle());

                htmlOutput.Append("</tr></thead>");

                htmlOutput.AppendLine("<tbody>");
                html.ResultsTable(htmlOutput, group, query, 0, true, allFields);
                htmlOutput.AppendLine("</tbody>");

                htmlOutput.AppendLine("</table>");
            }

            return htmlOutput.ToString();
        }


        public static MvcHtmlString Table(this HtmlHelper helper, string name, IList items, IDictionary<string, object> attributes)
        {
            if (items == null || items.Count == 0 || string.IsNullOrEmpty(name))
            {
                return MvcHtmlString.Create(string.Empty);
            }

            return MvcHtmlString.Create(BuildTable(name, items, attributes));
        }

        private static string BuildTable(string name, IList items, IDictionary<string, object> attributes)
        {
            StringBuilder sb = new StringBuilder();
            BuildTableHeader(sb, items[0].GetType());

            foreach (var item in items)
            {
                BuildTableRow(sb, item);
            }

            TagBuilder builder = new TagBuilder("table");
            builder.MergeAttributes(attributes);
            builder.MergeAttribute("name", name);
            builder.InnerHtml = sb.ToString();
            return builder.ToString(TagRenderMode.Normal);
        }

        private static void BuildTableRow(StringBuilder sb, object obj)
        {
            Type objType = obj.GetType();
            sb.AppendLine("\t<tr>");
            sb.AppendFormat("\t\t<td>{0}</td>\n", (string)obj);
            //foreach (var property in objType.GetProperties())
            //{
            //    object value = property.GetValue(obj, null);
            //    sb.AppendFormat("\t\t<td>{0}</td>\n", property.GetValue(obj, null));
            //}
            sb.AppendLine("\t</tr>");
        }

        private static void BuildTableHeader(StringBuilder sb, Type p)
        {
            sb.AppendLine("\t<tr>");
            foreach (var property in p.GetProperties())
            {
                sb.AppendFormat("\t\t<th>{0}</th>\n", property.Name);
            }
            sb.AppendLine("\t</tr>");
        }


    }
}