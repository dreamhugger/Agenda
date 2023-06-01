using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace pj_agenda
{
    public partial class Frm_Relatorio : Form
    {
        Cl_Conexao c = new Cl_Conexao();
        Cl_Contato cont = new Cl_Contato();
        Cl_ControleContato controle = new Cl_ControleContato();

        public Frm_Relatorio()
        {
            InitializeComponent();
        }

        private void Frm_Relatorio_Load(object sender, EventArgs e)
        {
            string sql = "select * from tbcontato; ";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, c.con);

            Ds_Contatos ds = new Ds_Contatos();
            da.Fill(ds.Tables["tbcontato"]);
            ReportDocument cr = new ReportDocument();
            cr = new Cr_Contatos();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            ReportDocument cryRpt = new ReportDocument();

        }

        private void Frm_Relatorio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cl_Conexao c = new Cl_Conexao();
            c.desconectar();
        }
    }
}
