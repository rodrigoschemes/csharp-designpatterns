using System;

namespace csharp_designpatterns
{
    public class Conta
    {
        public Conta(String nome, double saldo, int numero, int agencia)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Numero = numero;
            this.Agencia = agencia;
        }
        public String Nome { get; internal set; }
        public double Saldo { get; internal set; }
        public int Numero { get; internal set; }
        public int Agencia { get; internal set; }
    }
}