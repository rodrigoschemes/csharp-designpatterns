using System;
using System.Collections.Generic;

namespace csharp_designpatterns
{
    public class Historico
    {
        private IList<Estado> Estados = new List<Estado>();

        public Estado Pega(int index)
        {
            return Estados[index];
        }

        public void Adiciona(Estado estado)
        {
            Estados.Add(estado);
        }

        public override string ToString()
        {
            String historico = "";

            foreach (Estado e in Estados)
            {
                historico += $"Nome.....: {e.Contrato.Cliente} Tipo.....: {e.Contrato.Tipo} Data.....: {e.Contrato.Data} \n";
            }

            return historico;
        }
    }
}