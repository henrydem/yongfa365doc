using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AboutReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRDLC_Click(object sender, EventArgs e)
        {
            AboutReport.RDLC.frmRDLC frm = new AboutReport.RDLC.frmRDLC();
            frm.Show();
        }

        private void btnCrystalReport_Click(object sender, EventArgs e)
        {
            AboutReport.CrystalReport.frmCrystalReport frm = new AboutReport.CrystalReport.frmCrystalReport();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
