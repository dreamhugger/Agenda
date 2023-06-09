﻿using System;
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
    public partial class Frm_Principal : Form
    {
        Cl_ControleContato controle = new Cl_ControleContato();

        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Frm_Login TelaLogin = new Frm_Login();
            TelaLogin.ShowDialog();
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
            Frm_Sobre sobre = new Frm_Sobre();
            sobre.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Consulta consulta = new Frm_Consulta();
            consulta.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string CaminhoBackup = openFileDialog1.FileName;
                MessageBox.Show(controle.Retore(CaminhoBackup), "Restauração do BD",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Manual manual = new Frm_Manual();
            manual.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Relatorio relatorio = new Frm_Relatorio();
            relatorio.Show();
        }
    }
}
