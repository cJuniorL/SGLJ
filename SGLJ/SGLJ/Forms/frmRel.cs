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
            Reports.relProdutos oRptProd = new Reports.relProdutos();
            dtsSGLJ dsSglj = new dtsSGLJ();
            dtsSGLJTableAdapters.ProdutosTableAdapter taProd = new dtsSGLJTableAdapters.ProdutosTableAdapter();
            taProd.Fill(dsSglj.Produtos);
            oRptProd.SetDataSource(dsSglj);
            crystalReportViewer1.ReportSource = oRptProd;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Reports.relClientes oRptCli = new Reports.relClientes();
            dtsSGLJ dsSglj = new dtsSGLJ();
            dtsSGLJTableAdapters.ClientesTableAdapter taCli = new dtsSGLJTableAdapters.ClientesTableAdapter();
            taCli.Fill(dsSglj.Clientes);
            oRptCli.SetDataSource(dsSglj);
            crystalReportViewer1.ReportSource = oRptCli;
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Reports.relVendas oRptVendas = new Reports.relVendas();
            dtsSGLJ dsSglj = new dtsSGLJ();
            dtsSGLJTableAdapters.VendasTableAdapter taVendas = new dtsSGLJTableAdapters.VendasTableAdapter();
            taVendas.Fill(dsSglj.Vendas);
            oRptVendas.SetDataSource(dsSglj);
            crystalReportViewer1.ReportSource = oRptVendas;
        }
    }
}
