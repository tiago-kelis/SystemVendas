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
    public partial class FrmDetalhesDeVenda : Form
    {

        int venda_id;

        public FrmDetalhesDeVenda(int idvenda)
        {
            venda_id = idvenda;


            InitializeComponent();
        }

        private void FrmDetalhesDeVenda_Load(object sender, EventArgs e)
        {
            ItemVendaDao itemDao = new ItemVendaDao();
            dataListeDetalhesDeVendas.DataSource = itemDao.MetodoqueRetornaItensVendas(venda_id);
        }
    }
}
