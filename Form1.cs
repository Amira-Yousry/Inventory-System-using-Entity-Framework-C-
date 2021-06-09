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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Store_properties_Click_1(object sender, EventArgs e)
        {
            store_Form2 sf = new store_Form2();
            sf.ShowDialog();
        }

        private void Type_properties_Click_1(object sender, EventArgs e)
        {
            type_Form3 tf = new type_Form3();
            tf.ShowDialog();
        }

        private void Supplier_properties_Click_1(object sender, EventArgs e)
        {
            supplier_Form4 sf = new supplier_Form4();
            sf.ShowDialog();
        }

        private void Client_properties_Click_1(object sender, EventArgs e)
        {
            client_Form5 tf = new client_Form5();
            tf.ShowDialog();
        }

        private void Supply_Permission_Click_1(object sender, EventArgs e)
        {
            supply_permission_Form6 tf = new supply_permission_Form6();
            tf.ShowDialog();
        }

        private void Outgoing_Permission_Click_1(object sender, EventArgs e)
        {
            outgoing_permission_Form7 tf = new outgoing_permission_Form7();
            tf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)//Transefer
        {
            transfer_Form8 tf = new transfer_Form8();
            tf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reports_Form9 tf = new reports_Form9();
            tf.ShowDialog();
        }
    }
}
