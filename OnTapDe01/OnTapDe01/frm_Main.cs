﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapDe01
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HoSo frm_HoSo = new frm_HoSo();
            frm_HoSo.MdiParent = this;
            frm_HoSo.Show();
        }
    }
}
