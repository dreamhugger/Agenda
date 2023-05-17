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
    public partial class Frm_Login : Form
    {
        Cl_Login lgn = new Cl_Login();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Digite Login e senha para acessar o sistema!!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    bool logar = lgn.Logar(txtLogin.Text, txtSenha.Text);

                    if (logar == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login e/ou senha inválidos!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
    }

}