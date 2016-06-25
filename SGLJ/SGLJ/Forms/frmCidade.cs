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
    public partial class frmCidade : Form
    {
        char op = 'X';

        public frmCidade()
        {
            InitializeComponent();
        }

        private void frmCidade_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Cidade bllCidades = new Camadas.BLL.Cidade();
            dgvCidades.DataSource = bllCidades.Select();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtNome.Enabled = status;
            txtUf.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            btnCancelar.Enabled = status;
            dgvCidades.Enabled = !status;
            if (op != 'E')
            {
                lblID.Text = "-1";
                txtNome.Text = "";
                txtUf.Text = "";
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
                result = MessageBox.Show("Deseja Remover Essa Cidade?", "Remover Cidade", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    op = 'X';
                    Camadas.BLL.Cidade bllCidades = new Camadas.BLL.Cidade();
                    bllCidades.Delete(bllCidades.SelectById(Convert.ToInt32(lblID.Text)));
                    dgvCidades.DataSource = bllCidades.Select();
                    habilitarCampos(false);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja Gravar a Cidade?", "Gravar Cidade", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                Camadas.BLL.Cidade bllCidades = new Camadas.BLL.Cidade();
                Camadas.Modelo.Cidade cidade = new Camadas.Modelo.Cidade();
                if (op == 'E')
                    cidade = bllCidades.SelectById(Convert.ToInt32(lblID.Text));
                cidade.nome = txtNome.Text;
                cidade.uf = txtUf.Text;
                if (op == 'I')
                    bllCidades.Insert(cidade);
                else
                    bllCidades.Update(cidade);
                op = 'X';
                habilitarCampos(false);
                dgvCidades.DataSource = bllCidades.Select();
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

        private void dgvCidades_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCidades.SelectedRows.Count > 0)
            {
                lblID.Text = dgvCidades.SelectedRows[0].Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.SelectedRows[0].Cells["nome"].Value.ToString();
                txtUf.Text = dgvCidades.SelectedRows[0].Cells["uf"].Value.ToString();
            }
        }
    }
}