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
    public partial class frmClientes : Form
    {
        char op = 'X';

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Cidade bllCidade = new Camadas.BLL.Cidade();
            Camadas.BLL.Clientes bllCliente = new Camadas.BLL.Clientes();
            cmbCidade.ValueMember = "id";
            cmbCidade.DisplayMember = "nome";
            cmbCidade.DataSource = bllCidade.Select();
            dgvClientes.DataSource = bllCliente.Select();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtNome.Enabled = status;
            txtCpf.Enabled = status;
            txtEmail.Enabled = status;
            txtEndereco.Enabled = status;
            txtCelular.Enabled = status;
            txtTelefone.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            btnCancelar.Enabled = status;
            dgvClientes.Enabled = !status;
            cmbCidade.Enabled = status;
            if (op != 'E')
            {
                txtNome.Text = "";
                txtCpf.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtTelefone.Text = "";
                cmbCidade.Text = "";
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            habilitarCampos(true);
            op = 'I';
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos(false);
            op = 'E';
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                DialogResult result;
                result = MessageBox.Show("Deseja Remover Esse CLiente?", "Remover Cidade", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    op = 'X';
                    Camadas.BLL.Clientes bllClientes = new Camadas.BLL.Clientes();
                    bllClientes.Delete(bllClientes.SelectById(Convert.ToInt32(lblID.Text)));
                    dgvClientes.DataSource = bllClientes.Select();
                    habilitarCampos(false);
                }
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja Gravar o Cliente?", "Gravar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                Camadas.BLL.Clientes bllCliente = new Camadas.BLL.Clientes();
                Camadas.Modelo.Clientes clientes = new Camadas.Modelo.Clientes();
                if (op == 'E')
                    clientes = bllCliente.SelectById(Convert.ToInt32(lblID.Text));
                clientes.idCidade = Convert.ToInt32(cmbCidade.SelectedValue);
                clientes.nome = txtNome.Text;
                clientes.telefone = txtTelefone.Text;
                clientes.celular = txtCelular.Text;
                clientes.endereco = txtEndereco.Text;
                clientes.cpf = txtCpf.Text;
                clientes.email = txtEmail.Text;
                if (op == 'I')
                    bllCliente.Insert(clientes);
                else
                    bllCliente.Update(clientes);
                op = 'X';
                habilitarCampos(false);
                dgvClientes.DataSource = bllCliente.Select();
            }
        }

        private void dgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                lblID.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                Camadas.BLL.Clientes bllClientes = new Camadas.BLL.Clientes();
                Camadas.Modelo.Clientes clientes = bllClientes.SelectById(Convert.ToInt32(lblID.Text));
                txtNome.Text = clientes.nome;
                txtCpf.Text = clientes.cpf;
                cmbCidade.SelectedValue = clientes.idCidade;
                txtTelefone.Text = clientes.telefone;
                txtCelular.Text = clientes.celular;
                txtEndereco.Text = clientes.endereco;
                txtEmail.Text = clientes.email;
          }
        }
    }
}
