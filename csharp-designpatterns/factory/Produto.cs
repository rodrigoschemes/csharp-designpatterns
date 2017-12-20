namespace csharp_designpatterns
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }

        public override string ToString()
        {
            return  $"ID...........: {this.Id} \n" +
                    $"Nome.........: {this.Nome} \n" +
                    $"Categoria....: {this.Categoria}\n" +
                    $"Preco........: {this.Preco}\n";
        }
    }
}