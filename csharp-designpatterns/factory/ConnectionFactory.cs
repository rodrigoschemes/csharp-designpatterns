using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_designpatterns
{
    public class ConnectionFactory : IDisposable
    {
        IDbConnection conexao = new SqlConnection();

        public IDbConnection GetConnection()
        {
            conexao.ConnectionString = "Server = (localdb)\\mssqllocaldb; Database = LojaDB; Trusted_Connection = true;";
            conexao.Open();

            return conexao;
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        
    }
}
