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

namespace SystemVendas.br.com.Caixa.Views
{
    public partial class HistoricoVendas : Form
    {
        public HistoricoVendas()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dInicio;
            DateTime dFim;

            dInicio = Convert.ToDateTime(dataInicio.Value.ToString("yyyy-MM-dd"));
            dFim = Convert.ToDateTime(dataFim.Value.ToString("yyyy-MM-dd"));

            VendaDao vdao = new VendaDao();
            datalistarHistorico.DataSource = vdao.RetornaHistoricoDEVendasPeriodo(dInicio, dFim);
            
        }

        private void HistoricoVendas_Load(object sender, EventArgs e)
        {
            VendaDao dao = new VendaDao();
            datalistarHistorico.DataSource = dao.ListarTodasVendas();

        }

        private void datalistarHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idvenda = int.Parse(datalistarHistorico.CurrentRow.Cells[0].Value.ToString());
            FrmDetalhesDeVenda TelaDVnda = new FrmDetalhesDeVenda(idvenda);

            DateTime dataVenda = Convert.ToDateTime(datalistarHistorico.CurrentRow.Cells[1].Value.ToString());

            TelaDVnda.txtCliente.Text = datalistarHistorico.CurrentRow.Cells[2].Value.ToString();
            TelaDVnda.txtData.Text = dataVenda.ToString("dd/MM/yyyy");
            TelaDVnda.txtObservacao.Text = datalistarHistorico.CurrentRow.Cells[4].Value.ToString();
            TelaDVnda.txtTotalDeVendas.Text = datalistarHistorico.CurrentRow.Cells[3].Value.ToString();
            TelaDVnda.ShowDialog();
        }
    }
}
