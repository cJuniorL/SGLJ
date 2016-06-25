using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGLJ.Forms
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCidade frmCidade = new frmCidade();
            frmCidade.MdiParent = this;
            frmCidade.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void tipoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo_Produtos frmTipoProdutos = new frmTipo_Produtos();
            frmTipoProdutos.MdiParent = this;
            frmTipoProdutos.Show();
        }
    }
}
