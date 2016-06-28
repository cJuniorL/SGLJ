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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmClientes = new frmClientes();
            frmClientes.MdiParent = this;
            frmClientes.Show();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendedores frmVendedores = new frmVendedores();
            frmVendedores.MdiParent = this;
            frmVendedores.Show(); 
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos frmProdutos = new frmProdutos();
            frmProdutos.MdiParent = this;
            frmProdutos.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendas frmVendas = new frmVendas();
            frmVendas.MdiParent = this;
            frmVendas.Show();
        }

        private void relatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRel frmRelProdutos = new frmRel();
            frmRelProdutos.MdiParent = this;
            frmRelProdutos.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
