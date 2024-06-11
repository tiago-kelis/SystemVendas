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
    public partial class Pagamentos : Form
    {
        Clientes clientes = new Clientes();
        DataTable carrinho = new DataTable();
        DateTime dataAtual;


        public Pagamentos(Clientes clientes, DataTable carrinho, DateTime dataAtual)
        {
            this.clientes = clientes;
            this.carrinho = carrinho;
            this.dataAtual = dataAtual;

            InitializeComponent();           
        }

      
        private void Pagamentos_Load(object sender, EventArgs e)
        {
            txtCartao.Text = "0,00";
            txtDinheiro.Text = "0,00";
        }

     
      
       
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal v_dinheiro;
                decimal v_cartao;
                decimal troco;
                decimal totalPago;
                decimal total;

                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                v_cartao = decimal.Parse(txtCartao.Text);
                totalPago = v_cartao + v_dinheiro;
                total = decimal.Parse(lblTotal.Text);

                if (totalPago < total)
                {
                    MessageBox.Show("O total pago é menor que o total da venda");
                }
                else
                {
                    troco = totalPago - total;                  
                                      
                    lblTroco.Text = troco.ToString();                  
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu Erro: " + erro);
            }
        }

        public void btnPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                decimal v_dinheiro;
                decimal v_cartao;
                decimal troco;
                decimal totalPago;
                decimal total;

                ProdutoDao pDao = new ProdutoDao();

                int qtd_estoque;
                int qtd_comprada;
                int estoque_atualixado;


                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                v_cartao = decimal.Parse(txtCartao.Text);
                totalPago = v_cartao + v_dinheiro;
                total = decimal.Parse(lblTotal.Text);

                if (totalPago < total)
                {
                    MessageBox.Show("O total pago é menor que o total da venda");
                }
                else
                {
                    troco = totalPago - total;

                    Venda venda = new Venda();

                    venda.Client_Id = clientes.Id;
                    venda.Data_Venda = dataAtual;
                    venda.Total_Venda = total;
                    venda.Observacoes = cbDescricao.Text;

                    VendaDao dao = new VendaDao();
                  
                    dao.CadastrarVenda(venda);

                    foreach(DataRow linha  in carrinho.Rows)
                    {
                        ItensVendas itens = new ItensVendas();
                        itens.Venda_Id = dao.RetornaIdUltimaVenda();
                        itens.Produto_Id = int.Parse(linha["codigo"].ToString());
                        itens.Qtd = int.Parse(linha["qtd"].ToString());
                        itens.Subtotal = decimal.Parse(linha["subtotal"].ToString());


                        qtd_estoque = pDao.RetornaEstoqueAtual(itens.Produto_Id);
                        qtd_comprada = itens.Qtd;
                        estoque_atualixado = qtd_estoque - qtd_comprada;
                        pDao.BaixaEstoque(itens.Produto_Id, estoque_atualixado);

                        ItemVendaDao itemDao = new ItemVendaDao();
                        itemDao.CadastrarItemVenda(itens);
                    }

                    MessageBox.Show("Venda finalizada Com sucesso");                   
                    this.Dispose();                   
                    
                    new frmVendas().ShowDialog();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu Erro: " + erro);
            }
        }      
    }
}
