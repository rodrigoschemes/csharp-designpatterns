using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_designpatterns
{
    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }
        public string Tipo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            this.Tipo = "SEM DESCONTO";
            return 0;
        }
    }
}
