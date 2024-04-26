using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvedor
{
    public class HttpCondutor
    {
        public string Nome { get; set; }
        public string NumeroHabilitacao { get; set; }
        public string CategoriaHabilitacao { get; set; }
        public string VencimentoHabilitacao { get; set; }

        internal static async Task PostAsync(string url, StringContent conteudo)
        {
            throw new NotImplementedException();
        }
    }
}
