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
    public partial class frmProdutos : Form
    {

        char op = 'X';

        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
            dgvProdutos.DataSource = bllProdutos.Select();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtDescr.Enabled = status;
            txtQuantidade.Enabled = status;
            txtValor.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            btnCancelar.Enabled = status;
            dgvProdutos.Enabled = !status;
            if (op != 'E')
            {
                lblID.Text = "-1";
                lblIDTipoProdutos.Text = "-1";
                txtDescr.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";

            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            op = 'I';
            habilitarCampos(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                op = 'E';
                habilitarCampos(true);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                DialogResult result;
                result = MessageBox.Show("Deseja Remover Essa Produto?", "Remover Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    op = 'X';
                    Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
                    bllProdutos.Delete(bllProdutos.SelectById(Convert.ToInt32(lblID.Text)));
                    dgvProdutos.DataSource = bllProdutos.Select();
                    habilitarCampos(false);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja Gravar este Produto?", "Gravar Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
                Camadas.Modelo.Produtos produtos = new Camadas.Modelo.Produtos();
                if (op == 'E')
                    produtos = bllProdutos.SelectById(Convert.ToInt32(lblID.Text));
                produtos.idTipo_Produto = Convert.ToInt32(lblIDTipoProdutos.Text);
                produtos.descr = txtDescr.Text;
                produtos.quantidade = Convert.ToInt32(txtQuantidade.Text);
                produtos.valor = Convert.ToSingle(txtValor.Text);
                if (op == 'I')
                    bllProdutos.Insert(produtos);
                else
                    bllProdutos.Update(produtos);
                op = 'X';
                habilitarCampos(false);
                dgvProdutos.DataSource = bllProdutos.Select();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            op = 'X';
            habilitarCampos(false);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                lblID.Text = dgvProdutos.SelectedRows[0].Cells["id"].Value.ToString();
                txtDescr.Text = dgvProdutos.SelectedRows[0].Cells["descr"].Value.ToString();
                txtQuantidade.Text = dgvProdutos.SelectedRows[0].Cells["quantidade"].Value.ToString();
                txtValor.Text = dgvProdutos.SelectedRows[0].Cells["valor"].Value.ToString();

            }
        }
    }
}
