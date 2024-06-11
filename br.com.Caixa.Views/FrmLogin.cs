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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            this.txtEmail.Text = string.Empty;
            this.txtSenha.Text = string.Empty;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            FuncionariosDao fDao = new FuncionariosDao();
            if (fDao.EfetuarLogin(email, senha))
            {

               
            }


        }
    }
}
