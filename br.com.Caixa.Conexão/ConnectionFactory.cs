using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Conexão
{
    public class ConnectionFactory
    {

        public MySqlConnection GetConnection()
        {
            string Cnx = ConfigurationManager.ConnectionStrings["IConnection"].ConnectionString;
            return new MySqlConnection(Cnx);
        }
    }
}
