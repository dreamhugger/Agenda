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
    public partial class Frm_Manual : Form
    {
        public Frm_Manual()
        {
            InitializeComponent();
        }

        private void Frm_Manual_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("Manual.pdf");
        }
    }
}
