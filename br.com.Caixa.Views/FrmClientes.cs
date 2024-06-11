using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemVendas.br.com.Caixa.Dao;
using SystemVendas.br.com.Caixa.Model;

namespace SystemVendas.br.com.Caixa.Views
{
    public partial class FrmClientes : Form
    {
        private bool eNovo;
        private bool eEditar;



        public FrmClientes()
        {
           
            InitializeComponent();
            this.txtCodigo.Enabled = false;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.Habilitar(false);
            this.HBotoes();
            this.cbEstado.Enabled = false;
            this.btnExcluir.Enabled = false;

            
           
            ClientesDao dao = new ClientesDao();
            dataListaCliente.DataSource = dao.ListarCliente();         

        }       

        public void Limpar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.mctxtRG.Text = string.Empty;
            this.mctxtCPF.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.mctxtTelefone.Text = string.Empty;
            this.mctxtCelular.Text = string.Empty;
            this.mctxtCEP.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtNumero.Text = string.Empty;
            this.txtComplemento.Text = string.Empty;
            this.txtBairro.Text = string.Empty;
            this.txtCidade.Text = string.Empty;
            this.cbEstado.Text = string.Empty;          
            

        }

        private void AnularCampos()
        {

            this.txtCodigo.Enabled = false;
            this.txtNome.Enabled = false;
            this.mctxtRG.Enabled = false;
            this.mctxtCPF.Enabled = false;
            this.txtEmail.Enabled = false   ;
            this.mctxtTelefone.Enabled = false;
            this.mctxtCelular.Enabled = false;
            this.mctxtCEP.Enabled = false;
            this.txtEndereco.Enabled = false;
            this.txtNumero.Enabled = false;
            this.txtComplemento.Enabled = false ;
            this.txtBairro.Enabled = false;
            this.txtCidade.Enabled = false;
            this.cbEstado.Enabled = false;
           
        }

        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.mctxtRG.ReadOnly = !valor;
            this.mctxtCPF.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.mctxtTelefone.ReadOnly = !valor;
            this.mctxtCelular.ReadOnly = !valor;
            this.mctxtCEP.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtNumero.ReadOnly = !valor;
            this.txtComplemento.ReadOnly = !valor;
            this.txtBairro.ReadOnly = !valor;
            this.txtCidade.ReadOnly = !valor;
            this.cbEstado.Enabled = !valor;

        }
        private void HBotoes()
        {
            if(this.eNovo || this.eEditar)
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtNome.Text == string.Empty || this.mctxtRG.Text == string.Empty || this.mctxtCPF.Text == string.Empty ||
                 this.txtEmail.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                    this.mctxtCEP.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                    this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
                { 
                    MessageBox.Show("Selecione todos os campos para Cadastrar");
                }
                else
                {
                    if (this.eNovo)
                    {
                        Clientes obj = new Clientes();


                        obj.Nome = txtNome.Text;
                        obj.Rg = mctxtRG.Text;
                        obj.Cpf = mctxtCPF.Text;
                        obj.Email = txtEmail.Text;
                        obj.Telefone = mctxtTelefone.Text;
                        obj.Celular = mctxtCelular.Text;
                        obj.Cep = mctxtCEP.Text;
                        obj.Endereco = txtEndereco.Text;
                        obj.Numero = int.Parse(txtNumero.Text);
                        obj.Complemento = txtComplemento.Text;
                        obj.Bairro = txtBairro.Text;
                        obj.Cidade = txtCidade.Text;
                        obj.Estado = cbEstado.Text;

                        ClientesDao dao = new ClientesDao();
                        dao.CadastrarCliente(obj);
                       
                    }
                    else
                    {
                        this.eEditar = true;


                        Clientes obj = new Clientes();


                        obj.Nome = txtNome.Text;
                        obj.Rg = mctxtRG.Text;
                        obj.Cpf = mctxtCPF.Text;
                        obj.Email = txtEmail.Text;
                        obj.Telefone = mctxtTelefone.Text;
                        obj.Celular = mctxtCelular.Text;
                        obj.Cep = mctxtCEP.Text;
                        obj.Endereco = txtEndereco.Text;
                        obj.Numero = int.Parse(txtNumero.Text);
                        obj.Complemento = txtComplemento.Text;
                        obj.Bairro = txtBairro.Text;
                        obj.Cidade = txtCidade.Text;
                        obj.Estado = cbEstado.Text;
                        obj.Id = int.Parse(txtCodigo.Text);

                        ClientesDao dao = new ClientesDao();
                        dao.AlterarCliente(obj);                     

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
            ClientesDao dao1 = new ClientesDao();
            dataListaCliente.DataSource = dao1.ListarCliente();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.Limpar();
            this.HBotoes();
           
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.HBotoes();           
            this.Habilitar(true);
            this. txtNome.Focus();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == string.Empty || this.mctxtRG.Text == string.Empty || this.mctxtCPF.Text == string.Empty ||
               this.txtEmail.Text == string.Empty || mctxtTelefone.Text == string.Empty || mctxtCelular.Text == string.Empty ||
                  this.mctxtCEP.Text == string.Empty || this.txtEndereco.Text == string.Empty || this.txtNumero.Text == string.Empty ||
                  this.txtComplemento.Text == string.Empty || this.txtBairro.Text == string.Empty || this.txtCidade.Text == string.Empty || this.cbEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um campo para Excluir");
            }
            else
            {
                Clientes obj = new Clientes();

                obj.Id = int.Parse(txtCodigo.Text);

                ClientesDao dao = new ClientesDao();
                dao.ExcluirCliente(obj);
                dataListaCliente.DataSource = dao.ListarCliente();
                this.Limpar();
                this.cbEstado.Enabled = false;
            }

        }

        private void dataListaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataListaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataListaCliente.CurrentRow.Cells[1].Value.ToString();
            mctxtRG.Text = dataListaCliente.CurrentRow.Cells[2].Value.ToString();
            mctxtCPF.Text = dataListaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataListaCliente.CurrentRow.Cells[4].Value.ToString();
            mctxtTelefone.Text = dataListaCliente.CurrentRow.Cells[5].Value.ToString();
            mctxtCelular.Text = dataListaCliente.CurrentRow.Cells[6].Value.ToString();
            mctxtCEP.Text = dataListaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = dataListaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = dataListaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = dataListaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = dataListaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = dataListaCliente.CurrentRow.Cells[12].Value.ToString();
            cbEstado.Text = dataListaCliente.CurrentRow.Cells[13].Value.ToString();
            this.btnNovo.Enabled = false;
            this.btnSalvar.Enabled = false;
            this.btnLimpar.Enabled = true;
    
            this.btnExcluir.Enabled = true;
           

        }

      
    }
}
