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
    public partial class frmVendas : Form
    {
        Clientes clientes = new Clientes();
        ClientesDao dao = new ClientesDao();

        Produto p = new Produto();
        ProdutoDao pdao = new ProdutoDao();

        int qtd;
        decimal preco;
        decimal subtotal;
        decimal total;

        DataTable carrinho = new DataTable();
       

        public frmVendas()
        {
            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Quantidaded", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));
            

            dataVendas.DataSource = carrinho;
        }

        public void Limpar()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtQtd.Text = string.Empty;
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
            FuncionariosDao fdao = new FuncionariosDao();
            dataVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataVendas.DefaultCellStyle.Font = new Font("century", 8);
            this.dataVendas.DefaultCellStyle.ForeColor = Color.Yellow;
            this.dataVendas.DefaultCellStyle.BackColor = Color.Black;
           
            this.dataVendas.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
            this.dataVendas.DefaultCellStyle.SelectionBackColor = Color.Teal;

        }

        private void mcstxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                clientes = dao.RetornaClientePorTelefone(mcstxtTelefone.Text);

                if (clientes != null)
                {
                    txtNome.Text = clientes.Nome;
                }
                else
                {
                    mcstxtTelefone.Clear();
                    mcstxtTelefone.Focus();
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                p = pdao.RetornaprodutoPorCodigo(Int32.Parse(txtCodigo.Text));


                if (p != null)
                {
                  
                    txtDescricao.Text = p.Nome;
                    txtPreco.Text = p.Preco.ToString();

                }
                else
                {
                    this.Limpar();
                    this.txtCodigo.Focus();

                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtDescricao.Text == string.Empty || txtPreco.Text == string.Empty || txtQtd.Text == string.Empty)
                {
                    MessageBox.Show("Atribua Todos os Campos");
                }
                else
                {
                    qtd = int.Parse(txtQtd.Text);
                    preco = decimal.Parse(txtPreco.Text);
                    subtotal = qtd * preco;
                    total += subtotal;

                    carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, qtd, preco, subtotal);

                    lblTotalVenda.Text = total.ToString();

                    this.Limpar();
                    txtCodigo.Focus();
                }

            }
            catch (Exception erro)
            {

                MessageBox.Show("Digite o Código do produto: " + erro);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            decimal subproduto = decimal.Parse(dataVendas.CurrentRow.Cells[4].Value.ToString());
            int indice = dataVendas.CurrentRow.Index;
            DataRow linha = carrinho.Rows[indice];
            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();
            total -= subproduto;

            lblTotalVenda.Text = total.ToString();

            MessageBox.Show("Iten Removido com Sucesso");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DateTime dataAtual = DateTime.Parse(lblData.Text);
            Pagamentos tela = new Pagamentos(clientes, carrinho, dataAtual);
            tela.lblTotal.Text = total.ToString();

            tela.ShowDialog();
            this.Dispose();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto p = new FrmProduto();
            p.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedores f = new FrmFornecedores();
            f.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes C = new FrmClientes();
            C.ShowDialog();
        }      

        private void detalheDasVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoricoVendas hv = new HistoricoVendas();
            hv.ShowDialog();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionarios fun = new FrmFuncionarios();
            fun.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
