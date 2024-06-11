using MySql.Data.MySqlClient;
using Mysqlx;
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
    public class ProdutoDao
    {
        private MySqlConnection Cnx;

        public ProdutoDao()
        {
            this.Cnx = new ConnectionFactory().GetConnection();
        }

        #region Cadastrar Produto
        public void CadastrarProduto(Produto obj)
        {
            try
            {
                string sql = @"insert into tb_produto(descricao, preco, qtd_estoque, fornecedores_id)
                                values(@descricao, @preco, @qtd_estoque, @fornecedores_id)";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@descricao", obj.Nome);
                exec.Parameters.AddWithValue("@preco", obj.Preco);
                exec.Parameters.AddWithValue("@qtd_estoque", obj.Qtd_Estoque);
                exec.Parameters.AddWithValue("@fornecedores_id", obj.For_Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Produto Cadastrado com sucesso");
                Cnx.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um Erro: Cadastrar Produto:" + erro.StackTrace);
              
            }

        }
        #endregion

        #region Listar Produto
        public DataTable ListarProduto()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from tb_produto";

                    MySqlCommand exec = new MySqlCommand(sql, Cnx);
                Cnx.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(exec);
                da.Fill(dt);
                Cnx.Close();

                return dt;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconnteceu Erro: Listar Produto: " + erro);

                return null;
            }

        }
        #endregion

        #region Alterar Produto
        public void AlterarProduto(Produto obj)
        {
            try
            {
                string sql = "update tb_produto set descricao=@descricao, preco=@preco, qtd_estoque=@qtd_estoque, fornecedores_id=@fornecedores_id Where id=@id";
                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@descricao", obj.Nome);
                exec.Parameters.AddWithValue("@preco", obj.Preco);
                exec.Parameters.AddWithValue("@qtd_estoque", obj.Qtd_Estoque);
                exec.Parameters.AddWithValue("@fornecedores_id", obj.For_Id);
                exec.Parameters.AddWithValue("@id", obj.Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Produto Editado com Sucesso");
                Cnx.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: Alterar Produto: " + erro);
            }

        }
        #endregion

        #region Excluir Produto
        public void ExcluirProduto(Produto obj)
        {
            try
            {
                string sql = "delete from tb_produto where id=@id";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@id", obj.Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Produto Excluidocom sucesso");
                Cnx.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu Erro: Excluir Produto: " + erro);
            }

        }
        #endregion

        #region Método que Retorna produto por Código
        public Produto RetornaprodutoPorCodigo(int id)
        {
            try
            {
              
                string sql = "select * from tb_produto where id=@id";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@id", id);
                Cnx.Open();

                MySqlDataReader rs = exec.ExecuteReader();

                if (rs.Read())
                {
                    Produto p = new Produto();
                    p.Id = rs.GetInt32("id");
                    p.Nome = rs.GetString("descricao");
                    p.Preco = rs.GetDecimal("preco");
                    Cnx.Close();
                    return p;

                }
                else
                {
                    MessageBox.Show("Nenhum Produto Encontrado");
                    Cnx.Close();
                    return null;
                }

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: " + erro);
                Cnx.Close();
                return null;
            }

        }
        #endregion

        #region Método que baixa o Estoque
        public void BaixaEstoque(int idproduto, int qtdestoque)
        {
            try
            {
                string sql = "update tb_produto set qtd_estoque=@qtd_estoque where id=@id";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);

                exec.Parameters.AddWithValue("@qtd_estoque", qtdestoque);
                exec.Parameters.AddWithValue("@id", idproduto);

                Cnx.Open();
                exec.ExecuteNonQuery();
                Cnx.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: " + erro);
                Cnx.Close();
            }
        }
        #endregion

        #region Método que Retorna estoque Atual
        public int RetornaEstoqueAtual(int idproduto)
        {
            try
            {
                string sql = @"select qtd_estoque from tb_produto where id=@id";
                int qtd_estoque = 0;

                MySqlCommand exec = new MySqlCommand(sql, Cnx);

                exec.Parameters.AddWithValue("@id", idproduto);
                Cnx.Open();

                MySqlDataReader rs = exec.ExecuteReader();

                if (rs.Read())
                {
                    qtd_estoque = rs.GetInt32("qtd_estoque");
                    Cnx.Close();
                }

                return qtd_estoque;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu Erro: " + erro);
                Cnx.Close();
                return 0;
            }
        }
        #endregion

    }
}
