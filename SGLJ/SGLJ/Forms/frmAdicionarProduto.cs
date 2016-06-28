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
    public partial class frmAdicionarProduto : Form
    {
        public frmAdicionarProduto()
        {
            InitializeComponent();
        }

        private void frmAdicionarProduto_Load(object sender, EventArgs e)
        {
            carregarGrid();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtQuantidade.Enabled = status;
            btnAdicionar.Enabled = status;
            txtQuantidade.Text = "";
        }

        private void carregarGrid()
        {
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            Camadas.BLL.Tipo_Produtos bllTipo_Produtos = new Camadas.BLL.Tipo_Produtos();
            var dados = from p in bllProdutos.Select()
                        select new
                        {
                            id = p.id,
                            descricao = p.descr,
                            tipoProduto = bllTipo_Produtos.SelectById(p.idTipo_Produto).descr,
                            quantidade = p.quantidade,
                            valor = p.valor
                        };
            dgvProdutos.DataSource = dados.ToList();

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.RemoverProduto.adicionar(Convert.ToInt32(lblID.Text), Convert.ToInt32(txtQuantidade.Text));
            carregarGrid();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                lblID.Text = dgvProdutos.SelectedRows[0].Cells["ID"].Value.ToString();
                Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
                Camadas.Modelo.Produtos produtos = bllProdutos.SelectById(Convert.ToInt32(lblID.Text));
                lblProduto.Text = produtos.descr;
                habilitarCampos(true);
            }
        }
    }
}
