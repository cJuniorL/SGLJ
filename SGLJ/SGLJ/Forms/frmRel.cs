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
    public partial class frmRel : Form
    {
        public frmRel()
        {
            InitializeComponent();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Reports.relProdutos oRpt = new Reports.relProdutos();
            dtsSGLJ dsSglj = new dtsSGLJ();
            dtsSGLJTableAdapters.ProdutosTableAdapter taProd = new dtsSGLJTableAdapters.ProdutosTableAdapter();
            taProd.Fill(dsSglj.Produtos);
            oRpt.SetDataSource(dsSglj);
            crystalReportViewer1.ReportSource = oRpt;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Reports.relClientes oRpt = new Reports.relClientes();
            dtsSGLJ dsSglj = new dtsSGLJ();
            dtsSGLJTableAdapters.ClientesTableAdapter taCli = new dtsSGLJTableAdapters.ClientesTableAdapter();
            taCli.Fill(dsSglj.Clientes);
            oRpt.SetDataSource(dsSglj);
            crystalReportViewer1.ReportSource = oRpt;
        }
    }
}
