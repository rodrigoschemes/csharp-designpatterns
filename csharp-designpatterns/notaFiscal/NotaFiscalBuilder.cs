using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_designpatterns
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataAtual { get; private set; }
        private double valorTotal;
        private double impostos;
        private IList<ItemDaNota> todosItens = new List<ItemDaNota>();
        private IList<IAcaoAposGerarNota> todasAcoesASeremExecutadas;

        public NotaFiscalBuilder()
        {
            this.todasAcoesASeremExecutadas = new List<IAcaoAposGerarNota>();
        }

        public NotaFiscalBuilder ParaEmpresa(String razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(String cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal(this.RazaoSocial, this.Cnpj, this.DataAtual, this.valorTotal, 
                this.impostos, this.todosItens, this.Observacao);

            foreach (IAcaoAposGerarNota acao in todasAcoesASeremExecutadas)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item)
        {
            todosItens.Add(item);
            valorTotal += item.Valor;
            impostos += item.Valor * 0.05;

            return this;
        }

        public NotaFiscalBuilder ComObservacao(String observacao)
        {
            this.Observacao = observacao;
            return this;
        }

        public NotaFiscalBuilder NaDataAtual()
        {
            this.DataAtual = DateTime.Now;
            return this;
        }

        public void AdicionaAcao(IAcaoAposGerarNota novaAcao)
        {
            this.todasAcoesASeremExecutadas.Add(novaAcao);
        }
    }
}