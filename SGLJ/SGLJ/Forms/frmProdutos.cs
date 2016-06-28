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
            Camadas.BLL.Tipo_Produtos bllTipo_Produtos = new Camadas.BLL.Tipo_Produtos();
            cmbTipo.ValueMember = "id";
            cmbTipo.DisplayMember = "descr";
            cmbTipo.DataSource = bllTipo_Produtos.Select();
            carregarGrid();
            habilitarCampos(false);
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

        private void habilitarCampos(bool status)
        {
            txtDescr.Enabled = status;
            txtQuantidade.Enabled = status;
            txtValor.Enabled = status;
            cmbTipo.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            btnCancelar.Enabled = status;
            dgvProdutos.Enabled = !status;
            if (op != 'E')
            {
                lblID.Text = "-1";
                cmbTipo.Text = "";
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
                    carregarGrid();
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
                produtos.idTipo_Produto = Convert.ToInt32(cmbTipo.SelectedValue);
                produtos.descr = txtDescr.Text;
                produtos.quantidade = Convert.ToInt32(txtQuantidade.Text);
                produtos.valor = Convert.ToSingle(txtValor.Text.Replace("R","").Replace("$",""));
                if (op == 'I')
                    bllProdutos.Insert(produtos);
                else
                    bllProdutos.Update(produtos);
                habilitarCampos(false);
                carregarGrid();
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

        }

        private void dgvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                lblID.Text = dgvProdutos.SelectedRows[0].Cells["ID"].Value.ToString();
                Camadas.BLL.Produtos bllProdutos = new Camadas.BLL.Produtos();
                Camadas.Modelo.Produtos produtos = bllProdutos.SelectById(Convert.ToInt32(lblID.Text));
                cmbTipo.SelectedValue = produtos.idTipo_Produto;
                txtDescr.Text = produtos.descr;
                txtQuantidade.Text = Convert.ToString(produtos.quantidade);
                txtValor.Text = String.Format("{0:C2}",Convert.ToDouble(produtos.valor));
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {
                txtValor.Text = String.Format("{0:C2}", Convert.ToDouble(txtValor.Text.Replace("R", "").Replace("$", "")));
            }
            catch
            {
                txtValor.Text = "";
            }
        }
    }
}
