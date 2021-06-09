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
    public partial class transaction_report_Form12 : Form
    {
        EF_Project_1Entities1 ent = new EF_Project_1Entities1();

        public transaction_report_Form12()
        {
            InitializeComponent();
        }

        private void transaction_report_Form12_Load(object sender, EventArgs e)
        {
            
            var sup = ent.supply_permission;
            foreach (var d in sup)
            {
                comboBox2.Items.Add(d.supply_permission_date);
            }
            var go = ent.outgoing_permission;
            foreach (var o in go)
            {
                comboBox1.Items.Add(o.outgoing_permission_date);
            }


        }
      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Enabled = false;
                radioButton2.Enabled = false;
                var x = Convert.ToDateTime(comboBox2.Text);
                var tp = ent.supply_permission.Where(v => v.supply_permission_date == x).First();
                string cd = tp.type_code;
                dataGridView1.DataSource = (from l in ent.types
                                            where l.type_code == cd
                                            select new { l.type_code, l.type_name, l.type_quantity, l.type_measuring_unit, l.store_id }).ToList();

            }
       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox2.Enabled = false;
                radioButton1.Enabled = false;
                var x = Convert.ToDateTime(comboBox1.Text);
                var tp = ent.outgoing_permission.Where(v => v.outgoing_permission_date == x).First();
                string cd = tp.type_code;
                dataGridView1.DataSource = (from l in ent.types
                                            where l.type_code == cd
                                            select new { l.type_code, l.type_name, l.type_quantity, l.type_measuring_unit, l.store_id }).ToList();

            }

        }
    }
}
