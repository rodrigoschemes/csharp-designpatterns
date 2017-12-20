using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_designpatterns
{
    public class ProdutoDAO : IDisposable
    {
        IDbConnection conexao;

        public ProdutoDAO()
        {
            //implementação do factory
            conexao = new ConnectionFactory().GetConnection();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        public IList<Produto> Produtos()
        {
            
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.Preco = Convert.ToDouble(resultado["PrecoUnitario"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}
