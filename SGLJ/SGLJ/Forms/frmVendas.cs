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
    public partial class frmVendas : Form
    {
        List<Camadas.Modelo.Produtos> lstCarrinho = new List<Camadas.Modelo.Produtos>();
        char op = 'X';

        public frmVendas()
        {
            InitializeComponent();
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            cmbCliente.ValueMember = "id";
            cmbCliente.DisplayMember = "nome";
            cmbProduto.ValueMember = "id";
            cmbProduto.DisplayMember = "descr";
            cmbVendedor.ValueMember = "id";
            cmbVendedor.ValueMember = "descr";
            Camadas.BLL.Clientes bllClientes = new Camadas.BLL.Clientes();
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            Camadas.BLL.Vendedores bllVendedores = new Camadas.BLL.Vendedores();
            cmbCliente.DataSource = bllClientes.Select();
            cmbProduto.DataSource = bllProdutos.Select();
            cmbVendedor.DataSource = bllVendedores.Select();
            dtpData.Value = DateTime.Now;
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            cmbVendedor.Enabled = status;
            cmbCliente.Enabled = status;
            cmbProduto.Enabled = status;
            btnAdicionar.Enabled = status;
            txtQnt.Enabled = status;
            btnNovaVenda.Enabled = !status;
            btnFinalizarVenda.Enabled = status;
            btnProcurarVenda.Enabled = !status;
            if (op != 'V')
            {
                lblID.Text = "-1";
                cmbCliente.SelectedText = "";
                cmbProduto.SelectedText = "";
                cmbVendedor.SelectedText = "";
                txtQnt.Text = "";
                dgvCompras.DataSource = null;
            }
        }

        private void txtQnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
        }

        private void txtQnt_Leave(object sender, EventArgs e)
        {
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            int qnt = bllProdutos.SelectById(Convert.ToInt32(cmbProduto.ValueMember)).quantidade;
            if (Convert.ToInt32(txtQnt.Text) > qnt)
                txtQnt.Text = "";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            Camadas.Modelo.Produtos produto = bllProdutos.SelectById(Convert.ToInt32(cmbProduto.ValueMember));
            if (lblTotal.Text != null)
                lblTotal.Text = String.Format("{0:C2}", Convert.ToSingle(lblTotal.Text) + produto.valor * Convert.ToInt32(txtQnt.Text));
            else
                lblTotal.Text = String.Format("{0:C2}", produto.valor * Convert.ToInt32(txtQnt.Text));
         lstCarrinho.Add(produto);
            carregarGrid();
        }

        private void carregarGrid()
        {
            var dados = from p in lstCarrinho
                        select new
                        {
                            descr = p.descr,
                            valorU = p.valor,
                            quantidade = Convert.ToInt32(txtQnt.Text),
                            valorT = p.valor * Convert.ToInt32(txtQnt.Text)
                        };
            dgvCompras.DataSource = dados.ToList();
        }
    }
}
