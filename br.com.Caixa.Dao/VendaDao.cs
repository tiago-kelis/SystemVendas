using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemVendas.br.com.Caixa.Conexão;
using SystemVendas.br.com.Caixa.Model;

namespace SystemVendas.br.com.Caixa.Dao
{
    public class VendaDao
    {
        private MySqlConnection Cnx;

        public VendaDao()
        {
            this.Cnx = new ConnectionFactory().GetConnection();
        }

        #region Método Cadastrar venda
        public void CadastrarVenda(Venda obj)
        {
            try
            {
                string sql = @"insert into tb_vendas (client_id, data_venda, total_venda, observacoes)
                                values(@client_id, @data_venda, @total_venda, @observacoes)";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);

                exec.Parameters.AddWithValue("@client_id", obj.Client_Id);
                exec.Parameters.AddWithValue("@data_venda", obj.Data_Venda);
                exec.Parameters.AddWithValue("@total_venda", obj.Total_Venda);
                exec.Parameters.AddWithValue("@observacoes", obj.Observacoes);

                Cnx.Open();
                exec.ExecuteNonQuery();

               
                Cnx.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu Um Erro:" + erro);
            }

        }
        #endregion

        #region Método que retorna o Id da última venda
        public int RetornaIdUltimaVenda()
        {
            try
            {
                int idVenda = 0;

                string sql = "select max(id) id from tb_vendas";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                Cnx.Open();

                MySqlDataReader rs = exec .ExecuteReader();

                if (rs.Read())
                {
                    idVenda = rs.GetInt32("id");                  

                }

                Cnx.Close();
                return idVenda;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Acontecu Um Erro: Retorno Id " + erro);
                Cnx.Close();
                return 0;
               
            }
        }
        #endregion

        #region Método que retona Histórico de vendas
        public DataTable RetornaHistoricoDEVendasPeriodo(DateTime datainicio, DateTime datafim)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT v.id          as 'Código',
                             v.data_venda  as 'Data da Venda',
                             c.nome        as 'Cliente',
                             v.total_venda as 'Total',
                             v.observacoes as 'Observações'
                             FROM tb_vendas as v join tb_clientes as c on (v.client_id = c.id)
                             WHERE V.data_venda between @datainicio AND @datafim";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@datainicio", datainicio);
                exec.Parameters.AddWithValue("@datafim", datafim);
                Cnx.Open();
                exec.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(exec);
                da.Fill(dt);

                Cnx.Close();

                return dt;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: " + erro);
                return null;
            }

        }
        #endregion

        #region Listar Todas as Vendas
        public DataTable ListarTodasVendas()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT v.id          as 'Código',
                             v.data_venda  as 'Data da Venda',
                             c.nome        as 'Cliente',
                             v.total_venda as 'Total',
                             v.observacoes as 'Observações'
                             FROM tb_vendas as v join tb_clientes as c on (v.client_id = c.id)";
                           

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                Cnx.Open();
                exec.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(exec);
                da.Fill(dt);
                Cnx.Close();

                return dt;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: " + erro);
                return null;
            }
        }
        #endregion
    }
}
