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

    public partial class type_report_Form11 : Form
    {
        EF_Project_1Entities1 ent = new EF_Project_1Entities1();

        public type_report_Form11()
        {
            InitializeComponent();
        }

        private void type_report_Form11_Load(object sender, EventArgs e)
        {
            var type = ent.types;
            foreach (var s in type)
            {
                comboBox1.Items.Add(s.type_code);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in ent.types
                                        where x.type_code == comboBox1.Text
                                        select new { x.type_code, x.type_name, x.type_measuring_unit, x.type_quantity }).ToList();

        }


    }
}

