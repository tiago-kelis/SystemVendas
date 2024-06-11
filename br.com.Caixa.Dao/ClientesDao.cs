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
    public class ClientesDao
    {

        private MySqlConnection Cnx;

        public ClientesDao()
        {
            this.Cnx = new ConnectionFactory().GetConnection();
        }

      #region Cadastrar Cliente
        public void CadastrarCliente(Clientes obj)
        {
            try
            {
                string sql = @" insert into tb_clientes (nome, rg, cpf, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
                                values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Nome);
                exec.Parameters.AddWithValue("@rg", obj.Rg);
                exec.Parameters.AddWithValue("@cpf", obj.Cpf);
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

                MessageBox.Show("Cliente Cadastrado com Sucesso");
                Cnx.Close();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um Erro no Comando sql, Cadastrar Clientes: " + erro);
                
            }


        }
        #endregion

        #region Listar Clientes
        public DataTable ListarCliente()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"select * from tb_clientes";

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

                MessageBox.Show("Aconteceu um Erro no Comando Sql, ListarCliente" + erro);
                return null;
            }

        }
        #endregion

        #region Alterar Cliente
        public void AlterarCliente(Clientes obj)
        {
            try
            {
                string sql = @"update tb_clientes set nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular, cep=@cep, 
                              endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado where id=@id";



                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Nome);
                exec.Parameters.AddWithValue("@rg", obj.Rg);
                exec.Parameters.AddWithValue("@cpf", obj.Cpf);
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

                MessageBox.Show("Cliente Editado com Sucesso");
                Cnx.Close();



            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro no comando Sql, Editar Cliente" + erro);
                
            }

        }
        #endregion

        #region Excluir Cliente
        public void ExcluirCliente(Clientes obj)
        {
            try
            {
                string sql = "delete from tb_clientes where id=@id";

                MySqlCommand exe = new MySqlCommand(sql, Cnx);
                exe.Parameters.AddWithValue("@id", obj.Id);
                Cnx.Open();
                exe.ExecuteNonQuery();

                MessageBox.Show("Cliente Excluído com sucesso");

                Cnx.Close();


            }
            catch (Exception  erro)
            {

                MessageBox.Show("Aconteceu um Erro No comando Sql, Excluir Clientes" + erro);
            }

        }
        #endregion

        #region Método que retorna um Cliente Por Telelfone
        public Clientes RetornaClientePorTelefone(string cell)
        {
            try
            {
                Clientes obj = new Clientes();
                string sql = "select * from tb_clientes where celular=@celular";

                MySqlCommand exe = new MySqlCommand( sql, Cnx);
                exe.Parameters.AddWithValue("@celular", cell);

                Cnx.Open();
                MySqlDataReader rs = exe.ExecuteReader();

                if (rs.Read())
                {
                    obj.Id = rs.GetInt32("id");
                    obj.Nome = rs.GetString("nome");
                    Cnx.Close();
                    return obj;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado");
                    Cnx.Close();
                    return null;
                }

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
