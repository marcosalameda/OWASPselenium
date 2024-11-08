using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers.Table.Utils
{
    public sealed class TableString
    {
        private readonly String name;
        private readonly int value;

        public static TableString EmptyList { get { return new TableString(1, GenioMVC.Resources.Resources.VAZIO58398); } }
        public static TableString Actions { get { return new TableString(2, GenioMVC.Resources.Resources.ACOES22599); } }
        public static TableString Insert { get { return new TableString(3, GenioMVC.Resources.Resources.INSERIR43365); } }
        public static TableString Edit { get { return new TableString(4, GenioMVC.Resources.Resources.EDITAR11616); } }
        public static TableString Delete { get { return new TableString(5, GenioMVC.Resources.Resources.ELIMINAR21155); } }
        public static TableString View { get { return new TableString(6, GenioMVC.Resources.Resources.CONSULTAR57388); } }
        public static TableString Duplicate { get { return new TableString(7, GenioMVC.Resources.Resources.DUPLICAR09748); } }
        public static TableString Page { get { return new TableString(8, GenioMVC.Resources.Resources.PAGINA18394); } }
        public static TableString NextPage { get { return new TableString(9, GenioMVC.Resources.Resources.PAGINA_SEGUINTE34153); } }
        public static TableString PreviousPage { get { return new TableString(10, GenioMVC.Resources.Resources.PAGINA_ANTERIOR17471); } }
        public static TableString FirstPage { get { return new TableString(11, GenioMVC.Resources.Resources.PRIMEIRA43991 + " " + TableString.Page.ToString()); } }
        public static TableString LastPage { get { return new TableString(12, GenioMVC.Resources.Resources.ULTIMA04868 + " " + TableString.Page.ToString()); } }
        public static TableString Until { get { return new TableString(13, GenioMVC.Resources.Resources.ATE14291); } }
        public static TableString Choice { get { return new TableString(14, GenioMVC.Resources.Resources.ESCOLHA___40245); } }
        public static TableString NoResults { get { return new TableString(15, GenioMVC.Resources.Resources.NAO_HA_RESULTADOS_PA53055); } }
		public static TableString SimpleSearch { get { return new TableString(16, GenioMVC.Resources.Resources.PESQUISA_SIMPLES56899); } }
		public static TableString Download { get { return new TableString(13, GenioMVC.Resources.Resources.DESCARREGAR58418); } }
        public static TableString FileNotFound { get { return new TableString(14, GenioMVC.Resources.Resources.FICHEIRO_NAO_ENCONTR42952); } }
        public static TableString SelectedRecords { get { return new TableString(15, GenioMVC.Resources.Resources.REGISTO_S__SELECIONA64172); } }
		public static TableString GroupActions { get { return new TableString(16, GenioMVC.Resources.Resources.ACOES_COLETIVAS25162); } }

        private TableString(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
    }
}