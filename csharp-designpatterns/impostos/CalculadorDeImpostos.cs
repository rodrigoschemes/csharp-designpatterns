using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_designpatterns
{
    public class CalculadorDeImpostos
    {
        public double RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            return imposto.Calcula(orcamento);
        }

    }
}
