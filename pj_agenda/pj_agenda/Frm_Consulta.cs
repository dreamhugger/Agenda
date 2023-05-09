using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_agenda
{
    public partial class Frm_Consulta : Form
    {
        Cl_ControleContato controle = new Cl_ControleContato();

        public Frm_Consulta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex == 0)
            {
                try
                {
                    int codigo = Convert.ToInt32(txtBusca.Text);
                    dataGridView1.DataSource = controle.pesquisaCodigo(codigo);
                }
                catch
                {
                    MessageBox.Show("Digite um valor inteiro para o código!");
                    txtBusca.Clear();
                    txtBusca.Focus();
                }
            }
            else if (cbOpcao.SelectedIndex == 1)
            {
                string telefone = (txtBusca.Text);
                dataGridView1.DataSource = controle.pesquisaTelefone(telefone);
            }
            else if (cbOpcao.SelectedIndex == 2)
            {
                string celular = (txtBusca.Text);
                dataGridView1.DataSource = controle.pesquisaCelular(celular);
            }
            else
            {
                string email = (txtBusca.Text);
                dataGridView1.DataSource = controle.pesquisaEmail(email);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex < 0)
            {
                txtBusca.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcao.Text = "";
            }
            else
            {
                txtBusca.Enabled = true;
                lblOpcao.Text = "Digite o " + cbOpcao.Text;
                txtBusca.Clear();
                txtBusca.Focus();
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }
    }
}
