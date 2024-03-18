using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebTest
{
    /// <summary>
    /// classe que toma um input e o transforma num format digerível pela aplicação de testes
    /// que é devolvido na própria instância do objecto
    /// </summary>
    public sealed class Input : Dictionary< KeyValuePair<string,int> , object[]>
    {
        /// <summary>
        /// construtor que a partir de um file de Excel, o processa e o converte no format adequado
        /// </summary>
        /// <param name="app">Aplicação Excel</param>
        /// <param name="inputFile">Name do file de input</param>
        public Input(string inputFile)
        {
            //This class had a dependency on Excel libraries that didn't make sense for unit tests. 
            //It was not in use and was discontinued      
            throw new NotImplementedException();
        }
    }
}
