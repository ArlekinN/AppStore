﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppStore.WinForms
{
    public partial class SetofProductOnTheSumForm : Form
    {
        private MainForm mainForm;
        public SetofProductOnTheSumForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
