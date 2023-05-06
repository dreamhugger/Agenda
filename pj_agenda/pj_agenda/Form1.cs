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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cl_Conexao conexao = new Cl_Conexao();
            MessageBox.Show(conexao.conectar());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cadastro cadastro = new Frm_Cadastro();
            cadastro.MdiParent = this;
            cadastro.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutBox sobre = new FormAboutBox();
            sobre.ShowDialog();
        }
    }
}
