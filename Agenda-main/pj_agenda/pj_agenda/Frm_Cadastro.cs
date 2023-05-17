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
    public partial class Frm_Cadastro : Form
    {
        public Frm_Cadastro()
        {
            InitializeComponent();
        }

        public string operacao = "";

        Cl_Contato cont = new Cl_Contato();

        Cl_ControleContato controle = new Cl_ControleContato();

        private void limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Não é permitido cadastro sem um nome!!!");
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Digite o código do registro que deseja alterar!!!");
            }
            else
            {
                cont.Codcontato = int.Parse(txtCodigo.Text);
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.alterar(cont));
                limpar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cont = controle.buscar(int.Parse(txtCodigo.Text));

                if (cont is null)
                {
                    MessageBox.Show("Registro não encontrado!");
                }
                else
                {
                    txtCodigo.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome;
                    txtTelefone.Text = cont.Telefone;
                    txtCelular.Text = cont.Celular;
                    txtEmail.Text = cont.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Digite o código de registro que deseja excluir!!!");
            }
            else
            {
                cont.Codcontato = int.Parse(txtCodigo.Text);
                cont.Nome = txtCodigo.Text;
                cont.Email= txtEmail.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;

                MessageBox.Show(controle.excluir(cont));
                limpar();
            }
        }
    }
}
