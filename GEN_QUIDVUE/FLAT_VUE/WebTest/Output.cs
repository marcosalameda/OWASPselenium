using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebTest
{
    /// <summary>
    /// classe auxiliar to um item de uma listbox possa ser um par (Resultado, mensagem)
    /// </summary>
    public class ListEntry
    {

        private String text;
        private ResultType result;

        public ListEntry(String t, ResultType r)
        {
            text = t;
            result = r;
        }

        public String Text
        {
            get { return text; }
            set { text = value; }
        }

        public ResultType Result
        {
            get { return result; }
            set { result = value; }
        }

        public override string ToString()
        {
            return text;
        }

    }
    /// <summary>
    /// Classe que faz o log to o output, e assim abstraímo-nos do tipo de output que tivermos
    /// </summary>
    public class Output
    {
        /// <summary>
        /// text com todo o log
        /// </summary>
        StringBuilder destLogger = new StringBuilder();

        object obj = null;

        /// <summary>
        /// Construtor que ao inicializar faz clear ao tipo de objecto que tivermos
        /// </summary>
        /// <param name="objt">tipo de objecto to onde vai o Output</param>
        public Output(Object objt)
        {
            destLogger = new StringBuilder();

            obj = objt;

            if (obj == null)//janela dos testes do Visual studio
            {
            }
            if (obj is ListBox)
            {
                ListBox l = obj as ListBox;
                l.Items.Clear();
            }

            else if (obj is TextBox)
            {
                TextBox t = obj as TextBox;
                t.Text = "";
            }

            else if (obj is Console)
            {
                Console.Clear();
            }
            else if (obj is string)
            {
                String s = obj as String;
                s = "";
            }
            else if (obj is StringBuilder)
            {
                StringBuilder s = obj as StringBuilder;
                s.Remove(0, s.Length - 1);
            }
        }

        /// <summary>
        /// Acrescenta uma linha ao output
        /// </summary>
        /// <param name="res">Type de Resultado</param>
        /// <param name="line">Message</param>
        public void log(ResultType res, String line)
        {
            destLogger.AppendLine(line);

            if (obj == null)
            {
                //Isto não dá pq assim q o primeiro Assert falhado ou inconclusivo acontece, 
                //o VS toma isso como o final do test, passando ao próximo TestMethod.
                //Talvez dê to multiplicar o mesmo método n vezes com Reflection, mas isso fica to depois.
                Assert.AreEqual<ResultType>(ResultType.Good, res, line);
            }
            else if (obj is ListBox)
            {
                ListBox l = obj as ListBox;
                l.Items.Add(new ListEntry(line, res));
                l.SelectedItem = l.Items[l.Items.Count - 1];
                l.Refresh();
            }

            else if (obj is TextBox)
            {
                TextBox t = obj as TextBox;
                t.Text += line + "\n";
                t.Refresh();
            }

            else if (obj is Console)
            {
                Console.WriteLine(line);
            }
            else if (obj is string)
            {
                String s = obj as String;
                s += line + "\n";
            }
            else if (obj is StringBuilder)
            {
                StringBuilder s = obj as StringBuilder;
                s.AppendLine(line);
            }
            Application.DoEvents();

        }

        /// <summary>
        /// todo o text do presente log
        /// </summary>
        /// <returns></returns>
        public String getFullLog()
        {
            return destLogger.ToString();
        }
    }

}
