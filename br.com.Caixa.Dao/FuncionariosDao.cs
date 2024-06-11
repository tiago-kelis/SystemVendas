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
using SystemVendas.br.com.Caixa.Views;

namespace SystemVendas.br.com.Caixa.Dao
{
    public class FuncionariosDao
    {
        private MySqlConnection Cnx;


        public FuncionariosDao()
        {
            this.Cnx = new ConnectionFactory().GetConnection();
        }

        #region Cadastrar Funcionarios
        public void CadastrarFuncionarios(Funcionarios obj)
        {
            try
            {
                string sql = @"insert into tb_funcionarios(nome, rg, cpf, email, senha, cargo, nivel_acesso, telefone, celular, 
                               cep, endereco, numero, complemento, bairro, cidade, estado)
                              values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_acesso, @telefone, @celular,  @cep, @endereco, 
                               @numero, @complemento, @bairro, @cidade, @estado)";


                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Nome);
                exec.Parameters.AddWithValue("@rg", obj.Rg);
                exec.Parameters.AddWithValue("@cpf", obj.Cpf);
                exec.Parameters.AddWithValue("@email", obj.Email);
                exec.Parameters.AddWithValue("@senha", obj.Senha);
                exec.Parameters.AddWithValue("@cargo", obj.Cargo);
                exec.Parameters.AddWithValue("@nivel_acesso", obj.Nivel_Acesso);
                exec.Parameters.AddWithValue("@telefone", obj.Telefone);
                exec.Parameters.AddWithValue("@celular", obj.Celular);
                exec.Parameters.AddWithValue("@cep", obj.Cep);
                exec.Parameters.AddWithValue("@endereco", obj.Endereco);
                exec.Parameters.AddWithValue("@numero", obj.Numero);
                exec.Parameters.AddWithValue("@complemento", obj.Complemento);
                exec.Parameters.AddWithValue("@bairro", obj.Bairro);
                exec.Parameters.AddWithValue("@cidade", obj.Cidade);
                exec.Parameters.AddWithValue("@estado", obj.Estado);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Funcionário Cadastrado com sucesso");
                Cnx.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu Erro no Cadastrar Funcionários" + erro);
          
            }

        }
        #endregion

        #region Listar Funcionarios
        public DataTable ListarFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select * from tb_funcionarios";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                Cnx.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(exec);
                da.Fill(dt);

                Cnx.Close();

                return dt;

            }
            catch (Exception errro)
            {

                MessageBox.Show("Aconteceu um erro: Listar Funcionarios" + errro);
                return null;
            }

        }
        #endregion

        #region Alterar Funcionarios
        public void AlterarFuncionarios(Funcionarios obj)
        {
            try
            {
                string sql = @"update tb_funcionarios set nome=@nome, rg=@rg, cpf=@cpf, email=@email, senha=@senha, cargo=@cargo, nivel_acesso=@nivel_acesso, telefone=@telefone,
                             celular=@celular, cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado  where id=@id";
                            

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@nome", obj.Nome);
                exec.Parameters.AddWithValue("@rg", obj.Rg);
                exec.Parameters.AddWithValue("@cpf", obj.Cpf);
                exec.Parameters.AddWithValue("@email", obj.Email);
                exec.Parameters.AddWithValue("@senha", obj.Senha);
                exec.Parameters.AddWithValue("@cargo", obj.Cargo);
                exec.Parameters.AddWithValue("@nivel_acesso", obj.Nivel_Acesso);
                exec.Parameters.AddWithValue("@telefone", obj.Telefone);
                exec.Parameters.AddWithValue("@celular", obj.Celular);
                exec.Parameters.AddWithValue("@cep", obj.Cep);
                exec.Parameters.AddWithValue("@endereco", obj.Endereco);
                exec.Parameters.AddWithValue("@numero", obj.Numero);
                exec.Parameters.AddWithValue("@complemento", obj.Complemento);
                exec.Parameters.AddWithValue("@bairro", obj.Bairro);
                exec.Parameters.AddWithValue("@cidade", obj.Cidade);
                exec.Parameters.AddWithValue("@estado", obj.Estado);
                exec.Parameters.AddWithValue("@id", obj.Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Funcionário Editado com sucesso");
                Cnx.Close();



            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um erro: Editar Funcionario:" + erro);
            }

        }
        #endregion

        #region Excluir Funcionarios
        public void ExcluirFuncionarios( Funcionarios obj)
        {
            try
            {
                string sql = "delete  from tb_funcionarios where id=@id";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("id", obj.Id);

                Cnx.Open();
                exec.ExecuteNonQuery();

                MessageBox.Show("Funcionário Excluído com Sucesso");
                Cnx.Close();


            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um erro: Excluir Funcionarios: " + erro);
            }

        }
        #endregion

        #region Método que Efetua Login
        public bool EfetuarLogin(string email, string senha)
        {
            try
            {
                string sql = @"SELECT * FROM bdvendas.tb_funcionarios
                             where email = @email and senha = @senha";

                MySqlCommand exec = new MySqlCommand(sql, Cnx);
                exec.Parameters.AddWithValue("@email", email);
                exec.Parameters.AddWithValue("@senha", senha);

                Cnx.Open();

                MySqlDataReader rs = exec.ExecuteReader();

                if (rs.Read())
                {
                    string nivel = rs.GetString("nivel_acesso");
                    string nome = rs.GetString("nome");
                    

                    MessageBox.Show("Bem Vindo ao Sistema:  " + nome + ": " + nivel);               
                                                        

                    if ( nivel.Equals("Caixa") || nivel.Equals("Gerencia") || nivel.Equals("Funcionarios"))
                    {
                        frmVendas vendas2 = new frmVendas();
                        vendas2.MenuProduto.Enabled = false;
                        vendas2.MenuFornecedor.Enabled = false;
                        vendas2.MenuClientes.Enabled = false;
                        vendas2.MenuFuncionarios.Enabled = false;
                        vendas2.lblNivel_Acesso.Text = nome + ": " + nivel;
                        vendas2.ShowDialog();

                    }
                    else
                    {
                        frmVendas vendas2 = new frmVendas();
                        vendas2.MenuProduto.Enabled = true;
                        vendas2.MenuFornecedor.Enabled = true;
                        vendas2.MenuClientes.Enabled = true;
                        vendas2.MenuFuncionarios.Enabled = true;
                        vendas2.lblNivel_Acesso.Text = nome + ": " + nivel;
                        vendas2.ShowDialog();
                    }                   
                   
                    return true;
                }
                else
                {
                    MessageBox.Show("Email ou Senha incorretos!");
                    return false;
                }

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um Erro: no Login" + erro);
                return false;

            }

        }
        #endregion
    }
}
