using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_EF
{
    public partial class reports_Form9 : Form
    {
        public reports_Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            store_report_Form10 rep = new store_report_Form10();
            rep.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type_report_Form11 rep = new type_report_Form11();
            rep.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transaction_report_Form12 rep = new transaction_report_Form12();
            rep.ShowDialog();
        }
    }
}
