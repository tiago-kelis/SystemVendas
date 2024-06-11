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
    public  class FornecedoresDao
    {
        private MySqlConnection Cnx;

        public FornecedoresDao()
        {
            this.Cnx = new ConnectionFactory().GetConnection();
        }

        #region Cadastrar Fornecedores
        public void CadastrarFornecedores(Fornecedores obj)
        {
            try
            {
                string sql = @" insert into tb_fornecedor (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                                values (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Name);
                exec.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                exec.Parameters.AddWithValue("@email", obj.Email);
                exec.Parameters.AddWithValue("@telefone", obj.Telefone);
                exec.Parameters.AddWithValue("@celular", obj.Celular);
                exec.Parameters.AddWithValue("@cep", obj.Cep);
                exec.Parameters.AddWithValue("@endereco", obj.Endereco);
                exec.Parameters.AddWithValue("@numero", obj.Numero);
                exec.Parameters.AddWithValue("@complemento", obj.Complemento);
                exec.Parameters.AddWithValue("@bairro", obj.Bairro);
                exec.Parameters.AddWithValue("@cidade", obj.Cidade);
                exec.Parameters.AddWithValue("@Estado", obj.Estado);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Cadastrado com Sucesso");
                Cnx.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um erro no Cadastrar Fornecedores" + erro);
            }

        }
        #endregion

        #region Listar Fornecedores
        public DataTable ListarFornecedores()
        {

            try
            {
                DataTable dt = new DataTable();
                string sql = @"select * from tb_fornecedor";

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

                MessageBox.Show("Aconteceu um Erro no Comando Sql, Listar Fornecedor" + erro);
                return null;
            }
        }
        #endregion

        #region ALterar Fornecedores
        public void AlterarFornecedor(Fornecedores obj)
        {
            try
            {
                string sql = @"update tb_fornecedor set nome=@nome, cnpj=@cnpj, email=@email, telefone=@telefone, celular=@celular, cep=@cep, 
                              endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado where id=@id";



                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Name);
                exec.Parameters.AddWithValue("@cnpj", obj.Cnpj);
                exec.Parameters.AddWithValue("@email", obj.Email);
                exec.Parameters.AddWithValue("@telefone", obj.Telefone);
                exec.Parameters.AddWithValue("@celular", obj.Celular);
                exec.Parameters.AddWithValue("@cep", obj.Cep);
                exec.Parameters.AddWithValue("@endereco", obj.Endereco);
                exec.Parameters.AddWithValue("@numero", obj.Numero);
                exec.Parameters.AddWithValue("@complemento", obj.Complemento);
                exec.Parameters.AddWithValue("@bairro", obj.Bairro);
                exec.Parameters.AddWithValue("@cidade", obj.Cidade);
                exec.Parameters.AddWithValue("@Estado", obj.Estado);
                exec.Parameters.AddWithValue("@id", obj.Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Forneceedor Editado com Sucesso");
                Cnx.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um erro ALterar Fornecedor" + erro);
            }

        }
        #endregion

        #region Excluir Fornecedores
        public void ExcluirFornecedores(Fornecedores obj)
        {
            try
            {
                string sql = "delete from tb_fornecedor where id=@id";

                MySqlCommand exe = new MySqlCommand(sql, Cnx);
                exe.Parameters.AddWithValue("@id", obj.Id);
                Cnx.Open();
                exe.ExecuteNonQuery();

                MessageBox.Show("fornecedor Excluído com sucesso");

                Cnx.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro No comando Sql, Excluir fornecedor" + erro);
            }

        }
        #endregion     

    }

}
