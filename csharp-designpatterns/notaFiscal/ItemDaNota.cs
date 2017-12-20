using System;

namespace csharp_designpatterns
{
    public class ItemDaNota
    {
        public String Nome { get; set; }
        public double Valor { get; set; }

        public ItemDaNota(String nome, double valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }

        public override string ToString()
        {
            return $"Item: {this.Nome} \t Valor: {this.Valor}";
        }
    }
}