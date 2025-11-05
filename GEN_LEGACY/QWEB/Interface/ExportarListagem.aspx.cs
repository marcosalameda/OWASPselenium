using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Text.RegularExpressions;

public class StringWriterWithEncoding : StringWriter
{
    private Encoding _encoding;
    public StringWriterWithEncoding(Encoding encoding)
        : base()
    {
        _encoding = encoding;
    }
    public override Encoding Encoding
    {
        get
        {
            return _encoding;
        }
    }
}

public partial class ExportList : System.Web.UI.Page
{
    private string _filename = "listagem.txt";
    private string conteudoCSV = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        User user = null;
        try
        {
            Response.Clear();
            user = getUtilizador();
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year,user.Name);

            //1 - id do controlo
            string listingControl = "";
            string identifier = "";
            if (Request.Params["CTLID"] != null) {
                listingControl = user.CurrentModule + Request.Params["CTLID"].ToString();
                identifier = Request.Params["CTLID"].ToString();
            }
            else
                throw new BusinessException("Erro a carregar o ficheiro excel.", "ExportarListagem.aspx.Page_Load", "O id do controlo não está definido.");

            //2 - condições da query
            CriteriaSet conditions = null;
            string originalCondition = "";
            if (Request.Params["COND"] != null) {
                originalCondition = Request.Params["COND"].ToString();
                conditions = Condition.construirCondicaoGeneric(Request.Params["COND"].ToString());
                if (originalCondition.Contains("$FAREA$"))
                    Condition.adicionarCondicaoFiltraArea(conditions, originalCondition, identifier, user.CurrentModule, user);
            }
            else
                throw new BusinessException("Erro a carregar o report do crystal.", "reportCrsytal.ConfigurarCrystalReports", "A area base do report não está definida.");

            //3 - Ordenação
            string sorting = "";
            if (Request.Params["ORD"] != null)
                sorting = Request.Params["ORD"].ToString();

            //4 - Opções extra
            string format = "XLS";
            if (Request.Params["EXT"] != null)
                format = Request.Params["EXT"].ToString();
            string titulo = "";

            //5 - Área do controlo
            string area = "";
            if (Request.Params["AREA"] != null)
                area = Request.Params["AREA"].ToString();

            //
            IDictionary<string, CSGenio.persistence.PersistentSupport.ControlQueryDefinition> controlos =
                PersistentSupport.getControlQueries();
            IDictionary<string, CSGenio.persistence.PersistentSupport.overrideDbeditQuery> controlosOverride =
                PersistentSupport.getControlQueriesOverride();

            SelectQuery qs = null;
            IList<ColumnSort> orderBy = Condition.construirOrdenacao(sorting);

            CriteriaSet csEph = Listing.CalculateConditionsEphGeneric(Area.createArea(area, user, user.CurrentModule), listingControl);

            if (controlosOverride.ContainsKey(listingControl))
            {
                qs = controlosOverride[listingControl](user, "", conditions, orderBy, sp);
            }
            else
            {
                CSGenio.persistence.PersistentSupport.ControlQueryDefinition aux = controlos[listingControl];
                qs = new SelectQuery();
                foreach (SelectField field in aux.SelectFields)
                {
                    qs.SelectFields.Add(field);
                }
                qs.FromTable = aux.FromTable;
                foreach (TableJoin join in aux.Joins)
                {
                    qs.Joins.Add(join);
                }
                qs.Where(CriteriaSet.And()
                    .SubSet(aux.WhereConditions)
                    .SubSet(conditions));
            }

			if (qs.OrderByFields.Count == 0)
			{
				foreach (ColumnSort sort in Condition.construirOrdenacao(sorting))
				{
					qs.OrderByFields.Add(sort);
				}
            }

            qs.WhereCondition.SubSets.Add(csEph);

            //get data
            sp.openConnection();
            DataSet res = sp.Execute(qs).DbDataSet;
            sp.closeConnection();

            //get column labels
            TableRow labels = new TableRow();
            List<Field> fields = new List<Field>();

            foreach (DataColumn dc in res.Tables[0].Columns)
            {
                string[] colcap = dc.Caption.Split('.');
                AreaInfo ainfo = Area.GetInfoArea(colcap[0]);
                fields.Add(ainfo.DBFields[colcap[1]]);
                if (ainfo.DBFields[colcap[1]].Name == ainfo.PrimaryKeyName)
                {
                    titulo = ainfo.AreaDesignation;
                    _filename = titulo.Trim().ToLower().Replace(' ', '_') + "."+ format.ToLower();
                }
            }

            preencheListagem(fields, res, titulo, format,user);

            if (format.ToUpper() == "XLS")
                exportarXLS(_filename);
            else if (format.ToUpper() == "CSV")
                exportarCSV(_filename, conteudoCSV);
        }
        /*catch (BusinessException)
        {
            //já foi feito o log na criação da excepção
        }
        catch (PersistenceException)
        {
            //já foi feito o log na criação da excepção
        }*/
        catch (Exception ex)
        {
            Log.Error("Erro a criar o ficheiro: " + ex.Message);
        }
    }

    /// <summary>
    /// Preenche a table com a informação do dataset e com os labels das colunas
    /// </summary>
    /// <param name="labels">Labels das colunas</param>
    /// <param name="data">Lines da Qlisting</param>
    private void preencheListagem(List<Field> fields, DataSet data, string nomeListagem, string format,User user)
    {
        //header com descrição da Qlisting
        //titulo.Text = nomeListagem;
        //adiciona nomes das colunas
        TableRow headertr = new TableRow();
		string separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator; //RMR(2019-06-03) - CSV separator can be different depending on the culture format
        foreach (Field caux in fields)
        {
            //skip primary and foreign keys
            if (caux.FieldType != FieldType.KEY_VARCHAR
                && caux.FieldType != FieldType.KEY_GUID
                && caux.FieldType != FieldType.KEY_VARCHAR
                && caux.FieldType != FieldType.KEY_GUID)
            {
                if (format.ToUpper() == "XLS")
                {
                    TableCell cell = new TableCell();
                    cell.Text = caux.FieldDescription;
                    cell.Attributes.Add("class", "text");
					cell.Width = Math.Min(Math.Max(caux.FieldSize, caux.FieldDescription.Length) * 8, 300); //RMR(2019-06-03) - Excel has a width limit (error in case of 8000 size)
                    cell.BackColor = System.Drawing.Color.LightGray;
                    cell.ForeColor = System.Drawing.Color.RoyalBlue;
                    headertr.Cells.Add(cell);
                }
                else
				{
                    if (format.ToUpper() == "CSV")
                    {
                        conteudoCSV += caux.FieldDescription + separator;
                    }
				}
            }
        }

        if (format.ToUpper() == "XLS")
            tabela.Rows.Add(headertr);
        else
            if (format.ToUpper() == "CSV")
                conteudoCSV += separator+"\r\n";

        //preenche a table com os dados do dataset
        foreach (DataRow dr in data.Tables[0].Rows)
        {
            TableRow row = new TableRow();
            for (int i = 0; i < data.Tables[0].Columns.Count; i++)
            {
                //skip keys
                if (fields[i].FieldType != FieldType.KEY_VARCHAR
                    && fields[i].FieldType != FieldType.KEY_GUID
                    && fields[i].FieldType != FieldType.KEY_VARCHAR
                    && fields[i].FieldType != FieldType.KEY_GUID)
                {
                    Regex onlyNumbers = new Regex("^[0-9 ]+$");
                    if (format.ToUpper() == "XLS")
                    {
                        TableCell cel = new TableCell();
                        //JMT - 20110909 - Caso seja o Qfield composto somente por numeros e atinga o limite de precisão do excel (15) tem de se usar uma função que converta o number pr string de mode a não ser usada a notação cientifica
                        object Qvalue = DBConversion.ToInternal(dr[i], fields[i].FieldFormat);
                        if (onlyNumbers.IsMatch(dr[i].ToString(), 0) && dr[i].ToString().Length > 15)
                            cel.Text = "=UPPER(\"" + ConversaoQweb.FromInternal(Qvalue, fields[i].FieldType) + "\")";
                        else if (fields[i].FieldType == FieldType.ARRAY_TEXT || fields[i].FieldType == FieldType.ARRAY_NUMERIC || fields[i].FieldType == FieldType.ARRAY_LOGIC)
                        {
                            string arr = "";
                            string strVal = "";
                            if (fields[i].ArrayName.StartsWith("dbo."))
                                arr = fields[i].ArrayName.Substring(16);
                            else
                                arr = fields[i].ArrayName.Substring(12);
                            strVal = CSGenio.Comunicacao.ReplaceYearArray(Convert.ToString(Qvalue), user.Language, arr, user.Year);
                            cel.Text = ConversaoQweb.FromInternal(strVal, FieldType.TEXT);
                        }
                        else
                            cel.Text = ConversaoQweb.FromInternal(Qvalue, fields[i].FieldType);
							
						cel.Width = Math.Min(Math.Max(fields[i].FieldSize, fields[i].FieldDescription.Length) * 8, 300); //RMR(2019-06-03) - Excel has a width limit (error in case of 8000 size)
                        cel.Attributes.Add("class", "text");
                        cel.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
                        row.Cells.Add(cel);
                    }
                    else
					{
                        if (format.ToUpper() == "CSV")
                        {
                            if (fields[i].FieldType == FieldType.TEXT)
                            {
                                object Qvalue = DBConversion.ToInternal(dr[i], fields[i].FieldFormat);
                                //os fields de text precisam de uma formatação de quebras de linha especial
                                conteudoCSV += memo2String(ConversaoQweb.FromInternal(Qvalue, fields[i].FieldType)) + separator;
                            }
                            //US-25/07/2018-Replicado os passos semelhantes ao do XLS, adaptado para CSV
                            else if (fields[i].FieldType == FieldType.ARRAY_TEXT || fields[i].FieldType == FieldType.ARRAY_NUMERIC || fields[i].FieldType == FieldType.ARRAY_LOGIC)
                            {
                                string arr = "";
                                string strVal = "";
                                object valor = DBConversion.ToInternal(dr[i], fields[i].FieldFormat);
                                if (fields[i].ArrayName.StartsWith("dbo."))
                                    arr = fields[i].ArrayName.Substring(16);
                                else
                                    arr = fields[i].ArrayName.Substring(12);
                                strVal = CSGenio.Comunicacao.ReplaceYearArray(Convert.ToString(valor), user.Language, arr, user.Year);
                                conteudoCSV += ConversaoQweb.FromInternal(strVal, FieldType.TEXT) + separator;
                            }
                            else
                            {
                                object Qvalue = DBConversion.ToInternal(dr[i], fields[i].FieldFormat);
                                //conteudoCSV += ConversaoQweb.FromInternal(Qvalue, fields[i].FieldType) + separator;
                                string tmp = ConversaoQweb.FromInternal(Qvalue, fields[i].FieldType);
                                if (fields[i].FieldType == FieldType.MEMO
                                    || fields[i].FieldType == FieldType.MEMO_COMP_RTF)
                                    tmp = "\"" + tmp + "\"";

                                conteudoCSV += tmp + separator;
                            }
                        }
					}
                }
            }
            if (format.ToUpper() == "XLS")
                tabela.Rows.Add(row);
            else
			{
                if (format.ToUpper() == "CSV")
                    conteudoCSV += separator+"\r\n";
			}
        }
    }    
    
    /// <summary>
    /// Função que converte uma string com characters de quebras de linha to um Qvalue string válido 
    /// </summary>
    /// <param name="valorCampo">Qvalue do Qfield</param>
    /// <returns>Qfield string formatado</returns>
    public static string memo2String(string Qvalue)
    {
        if (Qvalue.Contains(";"))
            Qvalue = Qvalue.Replace(";", ",");

        if (Qvalue.Contains("\n\r\n"))
            Qvalue = Qvalue.Replace("\n\r\n", " ");

        if (Qvalue.Contains("\n\r"))
            Qvalue = Qvalue.Replace("\n\r", " ");

        if (Qvalue.Contains("\r\n"))
            Qvalue = Qvalue.Replace("\r\n", " ");

        if (Qvalue.Contains("\n"))
            Qvalue = Qvalue.Replace("\n", " ");

        if (Qvalue.Contains("\r"))
            Qvalue = Qvalue.Replace("\r", " ");

        return Qvalue;
    }    

    /// <summary>
    /// Método to obter o user que está em sessão
    /// </summary>
    /// <returns>o user em sessão</returns>
    private User getUtilizador()
    {
        //código to ir buscar o user à sessão
        object utilizadorObj = Session["utilizador"];
        if (utilizadorObj == null)
            throw new BusinessException("O utilizador não está autenticado.", "ExportarListagem", "The user is not authenticated.");
        User user = (User)utilizadorObj;
        return user;
    }

    /// <summary>
    /// Exporta to xls
    /// </summary>
    /// <param name="filename"></param>
    private void exportarXLS(string filename)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        Response.Clear();
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", filename));
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriterWithEncoding swe = new StringWriterWithEncoding(Encoding.UTF8))
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(swe))
            {
                Response.HeaderEncoding = Encoding.UTF8;
                Response.Charset = Encoding.UTF8.WebName;
                //  render the table into the htmlwriter
                tabela.RenderControl(htw);
                //render the htmlwriter into the response
                byte[] BOM = new byte[] { 0xef, 0xbb, 0xbf };
                Response.BinaryWrite(BOM);//write the BOM first
                Response.Write(style);
                Response.Write(swe.ToString());

                Response.End();
            }
        }
    }

    private void exportarCSV(string filename, string conteudoCSV)
    {
        Response.ClearContent();
        Response.ContentEncoding = System.Text.Encoding.Default;

        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        Response.AddHeader("Content-Length", conteudoCSV.Length.ToString());
        Response.ContentType = "application/vnd.ms-excel";
        Response.Write(conteudoCSV);
        Response.Flush();

        Response.End();
    }
}
