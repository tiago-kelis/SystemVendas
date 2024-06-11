using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemVendas.br.com.Caixa.Conexão;
using SystemVendas.br.com.Caixa.Model;

namespace SystemVendas.br.com.Caixa.Dao
{
    class ItemVendaDao
    {
        private MySqlConnection Cnx;

        public ItemVendaDao()
        {

            this.Cnx = new ConnectionFactory().GetConnection();        
            
        }

        #region Método que retorna última venda
        public void CadastrarItemVenda(ItensVendas obj)
        {
            try
            {
                string sql = @"insert into tb_itensvendas (venda_id, produto_id, qtd , subtotal)
                               values(@venda_id, @produto_id, @qtd, @subtotal)";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);              

                exec.Parameters.AddWithValue("@venda_id", obj.Venda_Id);
                exec.Parameters.AddWithValue("@produto_id", obj.Produto_Id);
                exec.Parameters.AddWithValue("@qtd", obj.Qtd);
                exec.Parameters.AddWithValue("@subtotal", obj.Subtotal);

                Cnx.Open();
                exec.ExecuteNonQuery();
             
                Cnx.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu Erro: Cadastrar venda" + erro);

            }

        }
        #endregion

        #region Método que lista todos os Itens por Venda
        public DataTable MetodoqueRetornaItensVendas(int venda_id)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT i.id as 'Código',
                                    p.descricao as 'Descricão',
                                    i.qtd as 'Quantidade',
                                    p.preco as 'Preço',
                                    i.subtotal as 'Subtotal'
                                    FROM tb_itensvendas as i join
                                    tb_produto as p on (i.produto_id = p.id) WHERE venda_id = @venda_id;";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@venda_id", venda_id);
              
                Cnx.Open();
                exec.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(exec);
                da.Fill(dt);

                Cnx.Close();

                return dt;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconreceu  um Erro: " + erro);
                return null;
            }
        }
        #endregion


    }
}
    


