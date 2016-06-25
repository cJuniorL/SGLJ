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
    public partial class frmVendedores : Form
    {
        char op = 'X';

        public frmVendedores()
        {
            InitializeComponent();
        }

        private void frmVendedores_Load(object sender, EventArgs e)
        {
            Camadas.BLL.Cidade bllCidade = new Camadas.BLL.Cidade();
            cmbCidade.ValueMember = "id";
            cmbCidade.DisplayMember = "nome";
            cmbCidade.DataSource = bllCidade.Select();
            carregarGrid();
            habilitarCampos(false);
        }

        private void habilitarCampos(bool status)
        {
            txtNome.Enabled = status;
            txtCpf.Enabled = status;
            txtRg.Enabled = status;
            txtSalario.Enabled = status;
            txtEndereco.Enabled = status;
            txtCelular.Enabled = status;
            txtTelefone.Enabled = status;
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            btnCancelar.Enabled = status;
            dgvVendedores.Enabled = !status;
            cmbCidade.Enabled = status;
            if (op != 'E')
            {
                lblID.Text = "-1";
                txtNome.Text = "";
                txtRg.Text = "";
                txtCpf.Text = "";
                txtSalario.Text = "";
                txtEndereco.Text = "";
                txtCelular.Text = "";
                txtTelefone.Text = "";
                cmbCidade.SelectedText = "";
            }

        }

        private void carregarGrid()
        {
            Camadas.BLL.Cidade bllCidade = new Camadas.BLL.Cidade();
            Camadas.BLL.Vendedores bllVendedor = new Camadas.BLL.Vendedores();
            var dados = from v in bllVendedor.Select()
                        select new
                        {
                            id = v.id,
                            nome = v.nome,
                            cidade = bllCidade.SelectById(v.idCidade).nome,
                            endereco = v.endereco,
                            telefone = v.telefone,
                            celular = v.celular,
                            cpf = v.cpf,
                            rg = v.rg,
                            salario = v.salario
                        };
            dgvVendedores.DataSource = dados.ToList();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            op = 'X';
            habilitarCampos(false);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                DialogResult result;
                result = MessageBox.Show("Deseja Remover Esse Vendedor?", "Remover Vendedor", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    op = 'X';
                    Camadas.BLL.Vendedores bllVendedores = new Camadas.BLL.Vendedores();
                    bllVendedores.Delete(bllVendedores.SelectById(Convert.ToInt32(lblID.Text)));
                    carregarGrid();
                    habilitarCampos(false);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Deseja Gravar o Vendedor?", "Gravar Vendedor", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                Camadas.BLL.Vendedores bllVendedore = new Camadas.BLL.Vendedores();
                Camadas.Modelo.Vendedores vendedor = new Camadas.Modelo.Vendedores();
                if (op == 'E')
                    vendedor = bllVendedore.SelectById(Convert.ToInt32(lblID.Text));
                vendedor.idCidade = Convert.ToInt32(cmbCidade.SelectedValue);
                vendedor.nome = txtNome.Text;
                vendedor.telefone = txtTelefone.Text;
                vendedor.celular = txtCelular.Text;
                vendedor.endereco = txtEndereco.Text;
                vendedor.cpf = txtCpf.Text;
                vendedor.rg = txtRg.Text;
                try
                {
                    vendedor.salario = Convert.ToSingle(txtSalario.Text.Replace("R", "").Replace("$", ""));
                }
                catch
                {
                    vendedor.salario = 0;
                }
                if (op == 'I')
                    bllVendedore.Insert(vendedor);
                else
                    bllVendedore.Update(vendedor);
                habilitarCampos(false);
                carregarGrid();
            }
        }

        private void dgvVendedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvVendedores.SelectedRows.Count > 0)
            {
                lblID.Text = dgvVendedores.SelectedRows[0].Cells[0].Value.ToString();
                Camadas.BLL.Vendedores bllVendedores = new Camadas.BLL.Vendedores();
                Camadas.Modelo.Vendedores vendedores = bllVendedores.SelectById(Convert.ToInt32(lblID.Text));
                txtNome.Text = vendedores.nome;
                txtRg.Text = vendedores.rg;
                txtCpf.Text = vendedores.cpf;
                txtCelular.Text = vendedores.celular;
                txtTelefone.Text = vendedores.telefone;
                cmbCidade.SelectedValue = vendedores.idCidade;
                txtEndereco.Text = vendedores.endereco;
                txtSalario.Text = String.Format("{0:C2}", vendedores.salario);
            }
        }

        private void txtSalario_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalario.Text = String.Format("{0:C2}", Convert.ToDouble(txtSalario.Text.Replace("R", "").Replace("$", "")));
            }
            catch
            {
                txtSalario.Text = "";
            }
        }
    }
}