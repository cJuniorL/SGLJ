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
    public partial class frmTipo_Produtos : Form
    {
        char op = 'X';

        public frmTipo_Produtos()
        {
            InitializeComponent();
        }

        private void frmTipo_Produtos_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Tipo_Produtos bllTipoProdutos = new Camadas.BLL.Tipo_Produtos();
            dgvTipoProdutos.DataSource = bllTipoProdutos.Select();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtDescr.Enabled = status;
            if (op != 'E')
            {
                lblID.Text = "-1";
                txtDescr.Text = "";
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            op = 'I';
            habilitarCampos(true);
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
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
                result = MessageBox.Show("Deseja Remover Essa Tipo_Produto?", "Remover Tipo_Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    op = 'X';
                    Camadas.BLL.Cidade bllCidades = new Camadas.BLL.Cidade();
                    bllCidades.Delete(bllCidades.SelectById(Convert.ToInt32(lblID.Text)));
                    dgvTipoProdutos.DataSource = bllCidades.Select();
                    habilitarCampos(false);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja Gravar o este Tipo de Produto?", "Gravar Tipo de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                Camadas.BLL.Tipo_Produtos bllTipoProdutos = new Camadas.BLL.Tipo_Produtos();
                Camadas.Modelo.Tipo_Produtos tipoProdutos = new Camadas.Modelo.Tipo_Produtos();
                if (op == 'E')
                    tipoProdutos = bllTipoProdutos.SelectById(Convert.ToInt32(lblID.Text));
                tipoProdutos.descr = txtDescr.Text;
                if (op == 'I')
                    bllTipoProdutos.Insert(tipoProdutos);
                else
                    bllTipoProdutos.Update(tipoProdutos);
                op = 'X';
                habilitarCampos(false);
                dgvTipoProdutos.DataSource = bllTipoProdutos.Select();
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

        private void dgvTipoProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTipoProdutos.SelectedRows.Count > 0)
            {
                lblID.Text = dgvTipoProdutos.SelectedRows[0].Cells["id"].Value.ToString();
            }
        }
    }
}
