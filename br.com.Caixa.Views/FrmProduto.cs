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
    public partial class FrmProduto : Form
    {
        private bool eNovo;
        private bool eEditar;



        public FrmProduto()
        {
            InitializeComponent();
            txtCodigo.Enabled = false;
        }

        public void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtPreco.ReadOnly = !valor;
            this.txtQtd.ReadOnly = !valor;
            this.cbFornecedor.Enabled = true;
        }

        public void Limpar()
        {
            this.txtNome.Text = string.Empty;
            this.txtPreco.Text = string.Empty;
            this.txtQtd.Text = string.Empty;
            this.cbFornecedor.Text = string.Empty;
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

        private void FrmProduto_Load(object sender, EventArgs e)
        {          
           

            this.Habilitar(false);
            this.HBotoes();
            FornecedoresDao dao = new FornecedoresDao();
            cbFornecedor.DataSource = dao.ListarFornecedores();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";

            ProdutoDao d1 = new ProdutoDao();
            dataGridView1.DataSource = d1.ListarProduto();
            cbFornecedor.Enabled = false;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNome.Text == string.Empty || this.txtPreco.Text == string.Empty || this.txtQtd.Text == string.Empty || this.cbFornecedor.Text == string.Empty)
                {
                    MessageBox.Show("Selecione todos os campos para Registrar");
                }
                else
                {
                    if (this.eNovo)
                    {
                        Produto obj = new Produto();

                        obj.Nome = txtNome.Text;
                        obj.Preco = decimal.Parse(txtPreco.Text);
                        obj.Qtd_Estoque = int.Parse(txtQtd.Text);
                        obj.For_Id = int.Parse(cbFornecedor.SelectedValue.ToString());
                        ProdutoDao Dao = new ProdutoDao();
                        Dao.CadastrarProduto(obj);                      
                       
                    }
                    else
                    {
                        this.eEditar = true;

                        Produto obj = new Produto();

                        obj.Nome = txtNome.Text;
                        obj.Preco = decimal.Parse(txtPreco.Text);
                        obj.Qtd_Estoque = int.Parse(txtQtd.Text);
                        obj.For_Id = int.Parse(cbFornecedor.Text);
                        obj.Id = int.Parse(txtCodigo.Text);

                        ProdutoDao dao = new ProdutoDao();
                        dao.AlterarProduto(obj);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Aconteceu Um Erro ao Salvar" + ex);
            }

            this.eNovo = false;
            this.eEditar = false;
            this.HBotoes();
            this.Limpar();
            ProdutoDao dao1 = new ProdutoDao();
            dataGridView1.DataSource = dao1.ListarProduto();
            cbFornecedor.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.btnExcluir.Enabled = false;
            
           

            this.HBotoes();
            this.Habilitar(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == string.Empty || this.txtPreco.Text == string.Empty || this.txtQtd.Text == string.Empty || this.cbFornecedor.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Campo para Editar");
            }
            else
            {
                this.eEditar = true;
                this.btnExcluir.Enabled = false;


                this.HBotoes();
                this.Habilitar(true);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.Limpar();
            this.HBotoes();
            this.Habilitar(false);
            this.btnNovo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnLimpar.Enabled = false;
            this.btnSalvar.Enabled = false;
            this.cbFornecedor.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.txtNome.Text == string.Empty || this.txtPreco.Text == string.Empty || this.txtQtd.Text == string.Empty || this.cbFornecedor.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Campo para Excluir");
            }
            else
            {
                Produto obj = new Produto();

                obj.Id = int.Parse(txtCodigo.Text);

                ProdutoDao dao = new ProdutoDao();
                dao.ExcluirProduto(obj);

                dataGridView1.DataSource = dao.ListarProduto();
                this.Limpar();

            }

            this.HBotoes();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.btnNovo.Enabled = false;
            this.btnExcluir.Enabled = true;
        }
    }
}
