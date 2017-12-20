using System;

namespace csharp_designpatterns
{
    public class Finalizado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamentos Finalizados não recebem desconto extra");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento FINALIZADO não pode ser alterado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento FINALIZADO não pode ser alterado");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento FINALIZADO não pode ser alterado");
        }
    }
}