using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace CSGenio.framework
{
    /// <summary>
    /// Classe que trata das conversões de string to tipo interno e vice-versa
    /// </summary>
    public static class ConversaoQweb
    {
        #region private auxiliar objects
        private static NumberFormatInfo provider = InitNumberProvider();

        private static NumberFormatInfo InitNumberProvider()
        {
            NumberFormatInfo p = new NumberFormatInfo();
            p.NumberDecimalSeparator = ",";
            p.NumberGroupSeparator = " ";
            return p;
        }

        private static string CleanLineBreaks(string str)
        {
            if (StringReg1.IsMatch(str) || StringReg2.IsMatch(str))
            {
                str = StringReg1.Replace(str, "\r\n");
                str = StringReg2.Replace(str, "\r\n");
            }

            return str;
        }

        //é mais eficiente compilar as expressões regulares apenas uma vez e depois partilhar e reutilizar
        private static Regex Date4 = new Regex("((19|20)[0-9][0-9])[-/.]([1-9]|0[1-9]|1[012])[-/.]([1-9]|0[1-9]|[12][0-9]|3[01])");//Data com Qyear XXXX
        private static Regex Date2 = new Regex("([1-9]|0[1-9]|[12][0-9]|3[01])[-/.]([1-9]|0[1-9]|1[012])[-/.]((19|20)[0-9][0-9])");//Data com Qyear XX

        private static Regex StringReg1 = new Regex("\r(?!\n)");// \r sem ser seguido de \n
        private static Regex StringReg2 = new Regex("(?<!\r)\n");// \n sem ser precedido de \r
#endregion

        /// <summary>
        /// Converte um objecto de comunicação to string
        /// </summary>
        /// <param name="valor">O objecto de comunicação</param>
        /// <returns>A objecto convertido to o tipo interno</returns>
        public static string ToString(string Qvalue)
        {
            if (Qvalue == null)
                return "";
            return CleanLineBreaks(Qvalue.ToString());
        }

        /// <summary>
        /// Converte um objecto de comunicação to string
        /// </summary>
        /// <param name="valor">O objecto de comunicação</param>
        /// <returns>A objecto convertido to o tipo interno</returns>
        public static string ToString(object Qvalue)
        {
            if (Qvalue == null)
                return "";

            if (Qvalue is string)
                return CleanLineBreaks((string)Qvalue);
            else
                return CleanLineBreaks(Qvalue.ToString());
        }

        /// <summary>
        /// Converte um objecto de comunicação to numeric
        /// </summary>
        /// <param name="valor">O objecto de comunicação</param>
        /// <returns>A objecto convertido to o tipo interno</returns>
        public static decimal ToDouble(string Qvalue)
        {
            decimal.TryParse(Qvalue.Replace(provider.NumberGroupSeparator,""), NumberStyles.Float, provider, out decimal tmp);
            return tmp;
        }

        /// <summary>
        /// Converte um objecto de comunicação to número inteiro
        /// </summary>
        /// <param name="valor">O objecto de comunicação</param>
        /// <returns>A objecto convertido to o tipo interno</returns>
        public static int ToInteger(string Qvalue)
        {
            int tmp = 0;
            int.TryParse(Qvalue, NumberStyles.Integer, provider, out tmp);
            return tmp;
        }

        /// <summary>
        /// Converte um objecto de comunicação to uma data
        /// </summary>
        /// <param name="valor">O objecto de comunicação</param>
        /// <returns>A objecto convertido to o tipo interno</returns>
        public static DateTime ToDateTime(string Qvalue)
        {
            if (string.IsNullOrEmpty(Qvalue))
                return DateTime.MinValue;

            // separa fields
            string[] dataSplit = Qvalue.Split('/', '-', ' ', ':');

            if (dataSplit.Length < 3) //!= 6) //DD-MM-AAAA HH:MM:SS
            {
                throw new FrameworkException("Erro na conversão de data para Datetime.", "ConversaoQweb.ToDateTime", "Erro na conversão de data para DateTime.");
            }

            int hour = 0;
            int minute = 0;
			int seconds = 0;
            if(dataSplit.Length >= 4)
                hour = int.Parse(dataSplit[3].Trim());
            if(dataSplit.Length >= 5)
                minute = int.Parse(dataSplit[4].Trim());
			if(dataSplit.Length >= 6)
                seconds = int.Parse(dataSplit[5].Trim());

            /*validate datas na forma aaaa-mm-dd, o caracter separador pode ser .,/ ou -*/
            Regex expReg;
            // verifica se é data com século ou não
            if (dataSplit[0].Trim().Length == 4)
                expReg = Date4;
            else
                expReg = Date2;

            //string datamesdia = dataString.Split(' ')[0];
            Match Qresult = expReg.Match(Qvalue);

            if (Qresult.Success)
            {
                string Qyear;
                string day;
                if (dataSplit[0].Trim().Length == 4)
                {
                    Qyear = Qresult.Groups[1].Value;
                    day = Qresult.Groups[3].Value;
                }
                else
                {
                    Qyear = Qresult.Groups[3].Value;
                    day = Qresult.Groups[1].Value;
                }
                int anoInt = int.Parse(Qyear);
                string month = Qresult.Groups[2].Value;

                if (month.Length == 1)
                    month = "0" + month;
                if (day.Length == 1)
                    day = "0" + day;

                /*verificar se é um month de 30 days e o input de days é 31*/
                if (day.Equals("31") && (month.Equals("04") || month.Equals("06") || month.Equals("09") || month.Equals("11")))
                    throw new FrameworkException("O mês não tem 31 dias.", "ConversaoQweb.ToDateTime", "O mês não tem 31 dias.");
                /*Fevereiro nao tem 30, nem 31*/
                else if (day.CompareTo("30") >= 0 && month.Equals("02"))
                    throw new FrameworkException("O mês de Fevereiro não tem 30 nem 31 dias.", "ConversaoQweb.ToDateTime", "O mês de Fevereiro não tem 30 nem 31 dias.");

              /*Se o Qyear é bissexto*/
                else if (month.Equals("02") && day.Equals("29") && !(anoInt % 4 == 0 && (anoInt % 100 != 0 || anoInt % 400 == 0)))
                    throw new FrameworkException("O mês de Fevereiro não tem 29 dias.", "ConversaoQweb.ToDateTime", "O mês de Fevereiro não tem 29 dias.");

                /*else if (month.Equals("02") && day.Equals("29") && !(anoInt % 4 == 0 && (anoInt % 100 != 0 || anoInt % 400 == 0)))
                    throw new FrameworkException("O mês de Fevereiro não tem 29 dias.", "Conversion.string2DateTime", "O mês de Fevereiro não tem 29 dias.");*/

                // MA 20101019 Se a hour é inválida
                else if (hour > 23 || hour < 0 || minute > 60 || minute < 0 || seconds < 0 || seconds > 60)
                    throw new FrameworkException("Hora inválida.", "ConversaoQweb.ToDateTime", "Hora inválida.");

            }
            else
                throw new FrameworkException("A data é inválida.", "ConversaoQweb.ToDateTime", "A data é inválida.");

            DateTime data;
            if (dataSplit[2].Trim().Length == 4)//isto é to determinar se a data vem no format AAAA-DD-MM HH:MM / DD-MM-AAAA HH:MM ?
                data = new DateTime(int.Parse(dataSplit[2].Trim()), int.Parse(dataSplit[1].Trim()), int.Parse(dataSplit[0].Trim()), hour, minute, seconds);
            else
                data = new DateTime(int.Parse(dataSplit[0].Trim()), int.Parse(dataSplit[1].Trim()), int.Parse(dataSplit[2].Trim()), hour, minute, seconds);

            return data;
        }

        // Metodo "Global" que permite alternar entre os varios tipo de dados
        /// <summary>
        /// Método que converte de string to tipo interno
        /// </summary>
        /// <param name="valorCampo">Qvalue do Qfield em string</param>
        /// <param name="formatacaoCampo">formatação do Qfield</param>
        /// <returns>o Qvalue do Qfield em tipo interno</returns>
        public static object ToInternal(string fieldValue, FieldFormatting fieldFormatting)
        {
            //object valorInterno;

            switch (fieldFormatting)
            {
                case FieldFormatting.INTEIRO:
                case FieldFormatting.LOGICO:
                    return ToInteger(fieldValue);
                case FieldFormatting.FLOAT:
                    return ToDouble(fieldValue);
                case FieldFormatting.DATA:
                case FieldFormatting.DATAHORA:
                case FieldFormatting.DATASEGUNDO:
                    return ToDateTime(fieldValue);
				case FieldFormatting.CARACTERES:
                    return ToString(fieldValue);
                default:
                    return fieldValue;
            }
        }

        /// <summary>
        /// Converte uma string to um objecto de comunicação
        /// </summary>
        /// <param name="valor">O Qvalue interno</param>
        /// <returns>O Qvalue interno convertido to comunicação</returns>
        public static string FromString(string Qvalue)
        {
            if (Qvalue == null)
                return "";
            return Qvalue;
        }

		/// <summary>
        /// Converte uma string to um objecto de comunicação
        /// </summary>
        /// <param name="valor">O Qvalue interno</param>
        /// <returns>O Qvalue interno convertido to comunicação</returns>
        public static string FromString(object Qvalue)
        {
            if (Qvalue == null)
                return "";

            if (Qvalue is string)
                return (string)Qvalue;
            else
                return Qvalue.ToString();
        }

        /// <summary>
        /// Converte um numérico to um objecto de comunicação
        /// </summary>
        /// <param name="valor">O Qvalue númerico</param>
        /// <returns>O Qvalue interno convertido to comunicação</returns>
        public static string FromDouble(decimal Qvalue)
        {
            return Qvalue.ToString("0.################", provider);
        }

        /// <summary>
        /// Converte um inteiro to um objecto de comunicação
        /// </summary>
        /// <param name="valor">O Qvalue númerico</param>
        /// <returns>O Qvalue interno convertido to comunicação</returns>
        public static string FromInteger(int Qvalue)
        {
            return Qvalue.ToString(provider);
        }

        /// <summary>
        /// Converte uma data to um objecto de comunicação
        /// </summary>
        /// <param name="valor">O Qvalue interno</param>
        /// <returns>O Qvalue interno convertido to comunicação</returns>
        public static string FromDateTime(DateTime Qvalue)
        {
            if (Qvalue.Equals(DateTime.MinValue))
                return "";
            StringBuilder dataString = new StringBuilder(40);

            dataString.Append(Qvalue.Day.ToString().PadLeft(2, '0') + "/");
            dataString.Append(Qvalue.Month.ToString().PadLeft(2, '0') + "/");
            dataString.Append(Qvalue.Year.ToString().PadLeft(4, '0'));

            dataString.Append(" " + Qvalue.Hour.ToString().PadLeft(2, '0') + ":");
            dataString.Append(Qvalue.Minute.ToString().PadLeft(2, '0'));
            dataString.Append(":" + Qvalue.Second.ToString().PadLeft(2, '0'));

            return dataString.ToString();
        }

        /// <summary>
        /// Função que converte do tipo interno to string
        /// </summary>
        /// <param name="valorCampo">Qvalue do Qfield no format interno</param>
        /// <param name="tipoCampo">Type de Qfield</param>
        /// <returns>Qvalue do Qfield em string</returns>
        public static string FromInternal(object fieldValue, Type fieldType)
        {
            //RS(2008.06.11) Retirei o try catch desta função uma vez que iria apenas fazer um rethrow exactamente da mesma excepção
            if (fieldType.Equals(typeof(System.Int32)))
                return FromInteger((int)fieldValue);

            if (fieldType.Equals(typeof(double)) || fieldType.Equals(typeof(decimal)))
                return FromDouble((decimal)fieldValue);

            if (fieldType.Equals(typeof(System.DateTime)))
                return FromDateTime((DateTime)fieldValue);

            if (fieldType.Equals(typeof(System.String)) || fieldType.Equals(typeof(System.Guid)))
                return FromString(fieldValue.ToString());

            throw new FrameworkException("Erro na conversão de tipo de campo interno para string.", "ConversaoQWeb.FromInterno", "Erro na conversão de tipo de campo interno para string, o tipo de formatação do campo não está definido");
        }

        /// <summary>
        /// Função que converte do tipo interno to string
        /// </summary>
        /// <param name="valorCampo">Qvalue do Qfield no format interno</param>
        /// <param name="forCampo">formatação do Qfield</param>
        /// <returns>Qvalue do Qfield em string</returns>
        /// SO 20070514 alterei de FieldFormatting to FieldType porque no caso das arrays
        /// numéricas o tipo de Qfield é double, mas interface espera uma string e não um double.
        /// Se a array não está preenchida deve ser enviada uma string vazia e não 0
        public static string FromInternal(object fieldValue, FieldType tpField)
        {
            try
            {
                FieldFormatting forField = tpField.GetFormatting();
                switch (forField)
                {
                    case FieldFormatting.INTEIRO:
                    case FieldFormatting.LOGICO:
                        if (tpField.Equals(FieldType.ARRAY_LOGIC))
                        {
                            if (fieldValue == null || fieldValue == DBNull.Value)
                                return "";
                            else
                                return fieldValue.ToString();
                        }
                        else
                            return FromInteger(Convert.ToInt32(fieldValue));
                    case FieldFormatting.FLOAT:
                        //TODO: rever este codigo inline
                        if (tpField.Equals(FieldType.ARRAY_NUMERIC))
                        {
                            if (fieldValue == null || fieldValue == DBNull.Value)
                                return "";
                            // MA + SL 20100528 Este if fazia com que um preenchimento do array com 0 levasse o controlo a não mostrar nada e foi introduzido no day 15/5/2007 na alteração 2867 por RS
                            //else if (fieldValue.ToString() == "0.0" || fieldValue.ToString() == "0")
                            //    return "";
                            else
                                return fieldValue.ToString();
                        }
                        else
                        {
                            if (fieldValue == null || fieldValue == DBNull.Value)
                                return "0.0";
                            else
                                return FromDouble((decimal)fieldValue);
                        }
                    case FieldFormatting.DATAHORA:
                    case FieldFormatting.DATASEGUNDO:
                        if (fieldValue is DateTime)
                            return FromDateTime((DateTime)fieldValue);
                        else
                            return fieldValue.ToString();
                    case FieldFormatting.DATA:
                        return FromDateTime((DateTime)fieldValue);
                    case FieldFormatting.TEMPO:
                    case FieldFormatting.CARACTERES:
                        return FromString((string)fieldValue);
                    case FieldFormatting.GUID:
                    case FieldFormatting.JPEG://ainda faz sentido ser assim?
					case FieldFormatting.GEOGRAPHY:
                    case FieldFormatting.GEO_SHAPE:
                    case FieldFormatting.GEOMETRIC:
                        return fieldValue.ToString();
                    default:
                        throw new FrameworkException("Erro na conversão de tipo de campo interno para string.", "ConversaoQWeb.FromInterno", "Erro na conversão de tipo de campo interno para string, o tipo de formatação do campo não está definido");
                }
            }
            catch (Exception ex)
            {
                throw new FrameworkException("Erro na conversão de tipo de campo interno para string", "ConversaoQWeb.FromInterno", "Erro na conversão de tipo de campo interno, para tipo interno Valido: " + ex.Message, ex);
            }
        }

        public static List<string[]> FromFicheiroBD(CSGenio.business.DBFile f, User user)
        {
            List<string[]> res = new List<string[]>();

            if (f.IsEmptyFile)
                return res;

            string[] row = new string[10];

            row[0] = f.Name; //name
            row[1] = f.GetSizeUnit(); //size
            row[2] = f.Extension; //ext

            row[3] = f.Author; //author
            row[4] = f.CreatedAt; //date
            row[5] = f.DocumId; //documid

            if (f.IsCheckout)
            {
                if (user.Name.Equals(f.CheckoutEditor))
                    row[6] = "COMMIT"; //chkstate
                else
                    row[6] = "CHECKOUT"; //chkstate
                row[7] = f.CheckoutEditor; //chkuser

                foreach (var entry in f.Versions)
                {
                    row[8] = entry.Key; //version
                    row[9] = entry.Value; //coddocums

                    res.Add(row);
                    row = new string[10];
                }
            }

            return res;
        }

    }
}
