
using System.Collections.Generic;
using System.ComponentModel;

namespace GenioServer.business
{
    public class ElasticsearchResult<T> where T : class
    {
        public int TotalHits { get; set; }
        public int Took { get; set; } // The 'took' attribute in the response object is the execution time in milliseconds
        public double TookSeconds { get { return Took / 1000; } }
        public string Error { get; set; }
        public ICollection<Facet> Facets { get; set; }
        public string SearchText { get; set; } // Searched text written by the user
        public ICollection<string> Highlight { get; set; } // The highlighted result list
        public float Score { get; set; } // score=?
        public ICollection<KeyValuePair<string, string>> LastFacetSelected { get; set; } // The user selected aggregations (buckets)
        public bool FirstLook { get; set; }
        public ICollection<T> Docs { get; set; }
        
        public ElasticsearchResult(ICollection<T> docs)
        {
            this.Docs = docs;
            this.Facets = new List<Facet>();
        }

        public bool IsFirstLook => FirstLook;
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ElasticsearchNestedAttribute : System.Attribute
    {
        public ElasticsearchNestedAttribute(bool isNested, string fieldName)
        {
            this.IsNested = isNested;
            this.FieldName = fieldName;
        }

        public bool IsNested { get; }
        public string FieldName { get; }
    }

    /// <summary>
    /// Tipos de pesquisa disponíveis para serem usados na selecção sobre qual a pesquisa que deve ser realizada no motor de pesquisa para o Elasticsearch
    /// Existem 3 indices e cada um dos enumerados representa cada um deles.
    /// Isto tem influência para duas coisas:
    /// Primeiro, para saber qual o index que vai ser usado para realizar as pesquisas
    /// Segundo, para renderizar os objectos da view de acordo com o tipo de pesquisa
    /// </summary>
    /// <remarks>
    /// Created by [HG] at [2019.12.05]
    /// </remarks>
    public enum SearchType
	{
        [Description("ITEMS")]
		Dexittm,
        [Description("Repairs")]
		Prepairs,
        [Description("Repairs")]
		Reparaco,
        [Description("Repairs")]
		Reparaso,
        [Description("Articles")]
		Tmlinem,
        [Description("Articles")]
		Tmlinew,
        [Description("Articles")]
		Tmliney,
        [Description("Articles")]
		Tmlleday,
        [Description("Visitas de inspeção")]
		Visitas
    }

    /// <summary>
    /// Representa uma lista facetada encontrada pela pesquisa
    /// É usada na class SearchHits, que depois usamos para a renderização da view e assim mostrar os faceted results disponíveis
    /// </summary>
    public class Facet
    {
        public int Order { get; set; }
        public string Nome { get; set; }
        public string Descrica { get; set; }
        public string ResourceName { get; set; }
        public string Type { get; set; }
        public IEnumerable<KeyValuePair<string, int>> List { get; set; }
        public Facet(int order, string nome, string descrica, string resourceName, string type, IEnumerable<KeyValuePair<string, int>> list)
        {
            this.Order = order;
            this.Nome = nome;
            this.Descrica = descrica;
            this.ResourceName = resourceName;
            this.Type = type;
            this.List = list;
        }
    }
}
