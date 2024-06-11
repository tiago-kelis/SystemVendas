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
    public partial class FrmFornecedores : Form
    {

        private bool eNovo;
        private bool eEditar;


        public FrmFornecedores()
        {
            InitializeComponent();
            this.txtCodigo.Enabled = false;
            
        }

        public void Limpar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.mctxtCnpj.Text = string.Empty;          
            this.txtEmail.Text = string.Empty;
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
            this.mctxtCnpj.ReadOnly = !valor;          
            this.txtEmail.ReadOnly = !valor;
            this.mctxtTelefone.ReadOnly = !valor;
            this.mctxtCelular.ReadOnly = !valor;
            this.mctxtCep.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtNumero.ReadOnly = !valor;
            this.txtComplemento.ReadOnly = !valor;
            this.txtBairro.ReadOnly = !valor;
            this.txtCidade.ReadOnly = !valor;
            this.cbEstado.Enabled = !valor;

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

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            this.HBotoes();
            this.cbEstado.Enabled = false;
            this.btnExcluir.Enabled = false;



            FornecedoresDao dao = new FornecedoresDao();
            dataListaFornecedores.DataSource = dao.ListarFornecedores();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtNome.Text == string.Empty || this.mctxtCnpj.Text == string.Empty || 
                 this.txtEmail.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                    this.mctxtCep.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                    this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
                {
                    MessageBox.Show("Selecione todos os campos para Cadastrar");
                }
                else
                {
                    if (this.eNovo)
                    {
                        Fornecedores obj = new Fornecedores();


                        obj.Name = txtNome.Text;
                        obj.Cnpj = mctxtCnpj.Text;                       
                        obj.Email = txtEmail.Text;
                        obj.Telefone = mctxtTelefone.Text;
                        obj.Celular = mctxtCelular.Text;
                        obj.Cep = mctxtCep.Text;
                        obj.Endereco = txtEndereco.Text;
                        obj.Numero = int.Parse(txtNumero.Text);
                        obj.Complemento = txtComplemento.Text;
                        obj.Bairro = txtBairro.Text;
                        obj.Cidade = txtCidade.Text;
                        obj.Estado = cbEstado.Text;

                        FornecedoresDao dao = new FornecedoresDao();
                        dao.CadastrarFornecedores(obj);                       
                    }
                    else
                    {
                        this.eEditar = true;


                        Fornecedores obj = new Fornecedores();


                        obj.Name = txtNome.Text;
                        obj.Cnpj = mctxtCnpj.Text;                      
                        obj.Email = txtEmail.Text;
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

                        FornecedoresDao dao = new FornecedoresDao();
                        dao.AlterarFornecedor(obj);
                                             

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
            FornecedoresDao dao1 = new FornecedoresDao();
            dataListaFornecedores.DataSource = dao1.ListarFornecedores();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.HBotoes();
            this.Habilitar(true);
            this.txtNome.Focus();
            this.btnExcluir.Enabled = false;
            this.cbEstado.Enabled = true;
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
                this.btnExcluir.Enabled = false;
                this.cbEstado.Enabled = true;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.Limpar();
            this.HBotoes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == string.Empty || this.mctxtCnpj.Text == string.Empty ||
              this.txtEmail.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                 this.mctxtCep.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                 this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um campo para Excluir");
            }
            else
            {
                Fornecedores obj = new Fornecedores();

                obj.Id = int.Parse(txtCodigo.Text);

                FornecedoresDao dao = new FornecedoresDao();
                dao.ExcluirFornecedores(obj);
                dataListaFornecedores.DataSource = dao.ListarFornecedores();
                this.Limpar();
                this.cbEstado.Enabled = false;
            }

        }

        private void dataListaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataListaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataListaFornecedores.CurrentRow.Cells[1].Value.ToString();
            mctxtCnpj.Text = dataListaFornecedores.CurrentRow.Cells[2].Value.ToString();          
            txtEmail.Text = dataListaFornecedores.CurrentRow.Cells[3].Value.ToString();
            mctxtTelefone.Text = dataListaFornecedores.CurrentRow.Cells[4].Value.ToString();
            mctxtCelular.Text = dataListaFornecedores.CurrentRow.Cells[5].Value.ToString();
            mctxtCep.Text = dataListaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = dataListaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = dataListaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = dataListaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = dataListaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = dataListaFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbEstado.Text = dataListaFornecedores.CurrentRow.Cells[12].Value.ToString();
            this.btnNovo.Enabled = false;
            this.btnSalvar.Enabled = false;
            this.btnLimpar.Enabled = true;
            this.btnEditar.Enabled = true;

            this.btnExcluir.Enabled = true;

        }
    }
    
}
