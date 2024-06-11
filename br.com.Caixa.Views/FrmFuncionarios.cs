using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemVendas.br.com.Caixa.Dao;
using SystemVendas.br.com.Caixa.Model;

namespace SystemVendas.br.com.Caixa.Views
{
    public partial class FrmFuncionarios : Form
    {
        private bool eNovo;
        private bool eEditar;


        public FrmFuncionarios()
        {
            InitializeComponent();
            this.txtCodigo.Enabled = false;
        }



        public void Limpar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.mctxtRg.Text = string.Empty;
            this.mctxtCpf.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtSenha.Text = string.Empty;
            this.cbCargo.Text = string.Empty;
            this.cbNivel_Acesso.Text = string.Empty;
            this.mctxtTelefone.Text = string.Empty;
            this.mctxtCelular.Text = string.Empty;
            this.mctxtCep.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtNumero.Text = string.Empty;
            this.txtComplemento.Text = string.Empty;
            this.txtBairro.Text = string.Empty;
            this.txtCidade.Text = string.Empty;
            this.cbEstado.Text = string.Empty;

        }   


        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.mctxtRg.ReadOnly = !valor;
            this.mctxtCpf.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtSenha.ReadOnly = !valor;
            this.cbCargo.Enabled = valor;
            this.cbNivel_Acesso.Enabled = valor;
            this.mctxtTelefone.ReadOnly = !valor;
            this.mctxtCelular.ReadOnly = !valor;
            this.mctxtCep.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtNumero.ReadOnly = !valor;
            this.txtComplemento.ReadOnly = !valor;
            this.txtBairro.ReadOnly = !valor;
            this.txtCidade.ReadOnly = !valor;
            this.cbEstado.Enabled = valor;

        }

        private void HBotoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnLimpar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnLimpar.Enabled = false;

            }
        }


        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            this.HBotoes();
            this.cbEstado.Enabled = false;
            this.btnExcluir.Enabled = false;



            FuncionariosDao dao = new FuncionariosDao();
            dataLiataFuncionarios.DataSource = dao.ListarFuncionarios();

        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtNome.Text == string.Empty || this.mctxtRg.Text == string.Empty || this.mctxtCpf.Text == string.Empty ||
                 this.txtEmail.Text == string.Empty || this.txtSenha.Text == string.Empty || this.cbCargo.Text == string.Empty || this.cbNivel_Acesso.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                    this.mctxtCep.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                    this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
                {
                    MessageBox.Show("Selecione todos os campos para Cadastrar");
                }
                else
                {
                    if (this.eNovo)
                    {
                        Funcionarios obj = new Funcionarios();


                        obj.Nome = txtNome.Text;
                        obj.Rg = mctxtRg.Text;
                        obj.Cpf = mctxtCpf.Text;
                        obj.Email = txtEmail.Text;
                        obj.Senha = txtSenha.Text;
                        obj.Cargo = cbCargo.Text;
                        obj.Nivel_Acesso = cbNivel_Acesso.Text;
                        obj.Telefone = mctxtTelefone.Text;
                        obj.Celular = mctxtCelular.Text;
                        obj.Cep = mctxtCep.Text;
                        obj.Endereco = txtEndereco.Text;
                        obj.Numero = int.Parse(txtNumero.Text);
                        obj.Complemento = txtComplemento.Text;
                        obj.Bairro = txtBairro.Text;
                        obj.Cidade = txtCidade.Text;
                        obj.Estado = cbEstado.Text;

                        FuncionariosDao dao = new FuncionariosDao();
                        dao.CadastrarFuncionarios(obj);

                        MessageBox.Show("Cliemte Cadastrado com sucesso");
                    }
                    else
                    {
                        this.eEditar = true;


                        Funcionarios obj = new Funcionarios();

                        obj.Nome = txtNome.Text;
                        obj.Rg = mctxtRg.Text;
                        obj.Cpf = mctxtCpf.Text;
                        obj.Email = txtEmail.Text;
                        obj.Senha = txtSenha.Text;
                        obj.Cargo = cbCargo.Text;
                        obj.Nivel_Acesso = cbNivel_Acesso.Text;
                        obj.Telefone = mctxtTelefone.Text;
                        obj.Celular = mctxtCelular.Text;
                        obj.Cep = mctxtCep.Text;
                        obj.Endereco = txtEndereco.Text;
                        obj.Numero = int.Parse(txtNumero.Text);
                        obj.Complemento = txtComplemento.Text;
                        obj.Bairro = txtBairro.Text;
                        obj.Cidade = txtCidade.Text;
                        obj.Estado = cbEstado.Text;
                        obj.Id = int.Parse(txtCodigo.Text);



                        FuncionariosDao dao = new FuncionariosDao();
                        dao.AlterarFuncionarios(obj);


                        MessageBox.Show("Funcionário Editado com Sucesso");

                    }
                }



            }
            catch (Exception)
            {

                MessageBox.Show("Erro");
            }

            this.eNovo = false;
            this.eEditar = false;
            this.HBotoes();
            this.Limpar();
            this.cbEstado.Enabled = false;
            FuncionariosDao dao1 = new FuncionariosDao();
            dataLiataFuncionarios.DataSource = dao1.ListarFuncionarios();


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.HBotoes();
            this.Habilitar(true);
            this.txtNome.Focus();
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Selecione um registro para ser Editado");
            }
            else
            {
                this.eEditar = true;
                this.HBotoes();
                this.Habilitar(true);
              
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            this.Limpar();
            this.HBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == string.Empty || this.mctxtRg.Text == string.Empty || this.mctxtCpf.Text == string.Empty ||
              this.txtEmail.Text == string.Empty || this.txtSenha.Text == string.Empty || this.cbCargo.Text == string.Empty || this.cbNivel_Acesso.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                 this.mctxtCep.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                 this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um campo para Excluir");
            }
            else
            {
                Funcionarios obj = new Funcionarios();

                obj.Id = int.Parse(txtCodigo.Text);

                FuncionariosDao dao = new FuncionariosDao();
                dao.ExcluirFuncionarios(obj);
                dataLiataFuncionarios.DataSource = dao.ListarFuncionarios();

                this.Limpar();
                this.HBotoes();
              
            }
        }

        private void dataLiataFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataLiataFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataLiataFuncionarios.CurrentRow.Cells[1].Value.ToString();
            mctxtRg.Text = dataLiataFuncionarios.CurrentRow.Cells[2].Value.ToString();
            mctxtCpf.Text = dataLiataFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataLiataFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = dataLiataFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = dataLiataFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbNivel_Acesso.Text = dataLiataFuncionarios.CurrentRow.Cells[7].Value.ToString();
            mctxtTelefone.Text = dataLiataFuncionarios.CurrentRow.Cells[8].Value.ToString();
            mctxtCelular.Text = dataLiataFuncionarios.CurrentRow.Cells[9].Value.ToString();
            mctxtCep.Text = dataLiataFuncionarios.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = dataLiataFuncionarios.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = dataLiataFuncionarios.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = dataLiataFuncionarios.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = dataLiataFuncionarios.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = dataLiataFuncionarios.CurrentRow.Cells[15].Value.ToString();
            cbEstado.Text = dataLiataFuncionarios.CurrentRow.Cells[16].Value.ToString();
            this.btnNovo.Enabled = false;
            this.btnExcluir.Enabled = true;
            this.btnLimpar.Enabled = true;
        }
    }
}
