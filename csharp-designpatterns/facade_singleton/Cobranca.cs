using System;

namespace csharp_designpatterns
{
    public class Cobranca
    {
        private object boleto;
        private Fatura fatura;

        public Cobranca(object boleto, Fatura fatura)
        {
            this.boleto = boleto;
            this.fatura = fatura;
        }

        internal void Emite()
        {
            throw new NotImplementedException();
        }
    }
}