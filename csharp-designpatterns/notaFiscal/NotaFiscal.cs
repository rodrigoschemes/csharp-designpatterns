using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_designpatterns
{
    public class NotaFiscal
    {
        public String RazaoSocial { get; set; }
        public String Cnpj { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorBruto { get; set; }
        public double Impostos { get; set; }
        public IList<ItemDaNota> Itens { get; set; }
        public String Observacoes { get; set; }

        public NotaFiscal(String razaoSocial, String cnpj, DateTime dataEmissao, double valorBruto, double impostos, 
            IList<ItemDaNota> itens, String observacoes)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.DataEmissao = dataEmissao;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Itens = itens;
            this.Observacoes = observacoes;
        }

        public override string ToString()
        {
            String imprimeItens = "";

            foreach(var item in this.Itens)
            {
                imprimeItens += $"\n{item}";
            }

            return $"Razão Social: {this.RazaoSocial} " +
                $"\nCNPJ: {this.Cnpj} " +
                $"\nData Emissão: {this.DataEmissao} " +
                $"\nValor Bruto: {this.ValorBruto} " +
                $"\nImpostos: {this.Impostos} " +
                $"\nObservações: {this.Observacoes} " +
                $"\nItens da Nota:{imprimeItens}";
        }
    }
}
