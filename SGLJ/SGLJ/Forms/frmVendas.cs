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
        List<Camadas.Modelo.Produtos_Vendas> lstCarrinho = new List<Camadas.Modelo.Produtos_Vendas>();
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
            cmbProduto.DisplayMember = "produto";
            cmbVendedor.ValueMember = "id";
            cmbVendedor.DisplayMember = "nome";
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
                cmbCliente.Text = null;
                cmbProduto.Text = null;
                cmbVendedor.Text = null;
                txtQnt.Text = "";
                dgvCompras.DataSource = null;
                lblTotal.Text = "";
            }
        }

        private void carregarDadosVenda()
        {
            Camadas.BLL.Vendas bllVendas = new Camadas.BLL.Vendas();
            Camadas.BLL.Vendedores bllVendedor = new Camadas.BLL.Vendedores();
            Camadas.BLL.Clientes bllClientes = new Camadas.BLL.Clientes();
            var dados = from v in bllVendas.Select()
                        select new
                        {
                            id = v.id,
                            vendedor = bllVendedor.SelectById(v.idVendedor).nome,
                            cliente = bllClientes.SelectById(v.idCliente).nome,
                            data = v.data,
                            total = v.total
                        };
            dgvVendas.DataSource = dados.ToList();
        }

        private void txtQnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            lstCarrinho.Clear();
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            cmbProduto.DataSource = bllProdutos.Select();
            habilitarCampos(true);
        }

        private void txtQnt_Leave(object sender, EventArgs e)
        {
            if (txtQnt.Text != "")
            {
                Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
                int qnt = bllProdutos.SelectById(Convert.ToInt32(cmbProduto.SelectedValue)).quantidade;
                if (Convert.ToInt32(txtQnt.Text) > qnt)
                    txtQnt.Text = "";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try { 
            Camadas.BLL.Produtos bllProduto = new Camadas.BLL.Produtos();
            Camadas.Modelo.Produtos_Vendas produtoVendas = new Camadas.Modelo.Produtos_Vendas();
            produtoVendas.idProdutos = Convert.ToInt32(cmbProduto.SelectedValue);
            if (lblTotal.Text != "")
                lblTotal.Text = String.Format("{0:C2}", Convert.ToSingle(lblTotal.Text.Replace("R","").Replace("$","")) + bllProduto.SelectById(produtoVendas.idProdutos).valor * Convert.ToInt32(txtQnt.Text));
            else
                lblTotal.Text = String.Format("{0:C2}", bllProduto.SelectById(produtoVendas.idProdutos).valor * Convert.ToInt32(txtQnt.Text));
            produtoVendas.quantidade = Convert.ToInt32(txtQnt.Text);
            lstCarrinho.Add(produtoVendas);
            carregarGrid();
            }
            catch
            {
                MessageBox.Show("Não é possivel realizar a operação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarGrid()
        {
            Camadas.BLL.Produtos bllProduto = new Camadas.BLL.Produtos();
            var dados = from p in lstCarrinho
                        select new
                        {
                            descr = bllProduto.SelectById(p.idProdutos).descr,
                            valorU = bllProduto.SelectById(p.idProdutos).valor,
                            quantidade = p.quantidade,
                            valorT = bllProduto.SelectById(p.idProdutos).valor * p.quantidade
                        };
            dgvCompras.DataSource = dados.ToList();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            Camadas.Modelo.Vendas venda = new Camadas.Modelo.Vendas();
            Camadas.BLL.Vendas bllVendas = new Camadas.BLL.Vendas();
            Camadas.BLL.Produtos_Vendas bllProdutosVendas = new Camadas.BLL.Produtos_Vendas();
            Camadas.Modelo.Produtos produto = new Camadas.Modelo.Produtos();
            Camadas.BLL.Produtos bllProduto = new Camadas.BLL.Produtos();
            venda.idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            venda.idVendedor = Convert.ToInt32(cmbProduto.SelectedValue);
            venda.total = Convert.ToSingle(lblTotal.Text.Replace("R", "").Replace("$", ""));
            venda.data = dtpData.Value;
            bllVendas.Insert(venda);
            List<Camadas.Modelo.Vendas> lstVendas = bllVendas.Select();
            venda = lstVendas[lstVendas.Count - 1];
            Camadas.Modelo.Produtos_Vendas produtosVendas = new Camadas.Modelo.Produtos_Vendas();
            produtosVendas.idVendas = venda.id;
            foreach (Camadas.Modelo.Produtos_Vendas produtosVendasList in lstCarrinho)
            {
                produto = bllProduto.SelectById(produtosVendasList.idProdutos);
                produto.quantidade -= produtosVendasList.quantidade;
                bllProduto.Update(produto);
                produtosVendas.idProdutos = produtosVendasList.idProdutos;
                produtosVendas.quantidade = produtosVendasList.quantidade;
                bllProdutosVendas.Insert(produtosVendas);
            }
            habilitarCampos(false);
        }

        private void btnProcurarVenda_Click(object sender, EventArgs e)
        {
            carregarDadosVenda();
        }

        private void dgvVendas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvVendas.SelectedRows.Count > 0)
            {
                lblID.Text = dgvVendas.SelectedRows[0].Cells["id"].Value.ToString();
                Camadas.BLL.Vendas bllVendas = new Camadas.BLL.Vendas();
                Camadas.Modelo.Vendas venda = new Camadas.Modelo.Vendas();
                venda = bllVendas.SelectById(Convert.ToInt32(lblID.Text));
                lblTotal.Text = Convert.ToString(venda.total);
                cmbCliente.SelectedValue = venda.idCliente;
                cmbVendedor.SelectedValue = venda.idVendedor;
                dtpData.Value = venda.data;
                Camadas.BLL.Produtos_Vendas bllProdutosVendas = new Camadas.BLL.Produtos_Vendas();
                Camadas.BLL.Produtos bllProduto = new Camadas.BLL.Produtos();
                var dados = from p in bllProdutosVendas.SelectByVenda(venda.id)
                            select new
                            {
                                descr = bllProduto.SelectById(p.idProdutos).descr,
                                valorU = bllProduto.SelectById(p.idProdutos).valor,
                                quantidade = p.quantidade,
                                valorT = bllProduto.SelectById(p.idProdutos).valor * p.quantidade
                            };
                dgvCompras.DataSource = dados.ToList();
            }
        }
    }
}
