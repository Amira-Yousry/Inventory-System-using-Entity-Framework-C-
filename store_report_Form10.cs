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
    public partial class store_report_Form10 : Form
    {
        EF_Project_1Entities1 ent = new EF_Project_1Entities1();

        public store_report_Form10()
        {
            InitializeComponent();
        }

        private void store_report_Form10_Load(object sender, EventArgs e)
        {
            var store = ent.stores;
            foreach (var s in store)
            {
                comboBox1.Items.Add(s.store_name);
            }
        }
 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in ent.stores
                                        where x.store_name == comboBox1.Text
                                        select new { x.store_id, x.store_name, x.store_address , x.store_admin }).ToList();

           
        }

   
    }
}
