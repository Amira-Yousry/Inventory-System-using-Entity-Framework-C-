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
    public partial class transfer_Form8 : Form
    {
        EF_Project_1Entities1 ent = new EF_Project_1Entities1();

        public transfer_Form8()
        {
            InitializeComponent();
        }

        private void transfer_Form8_Load(object sender, EventArgs e)
        {

            //fromstore
            var f_st = (from x in ent.stores select new { x, Name= x.store_name, id = x.store_id}).ToList();
            comboBox1.DataSource = f_st;
            comboBox1.DisplayMember  = "Name";
            comboBox1.ValueMember  = "id";
            //tostore
            var t_st = (from y in ent.stores select new { y, Name_s = y.store_name, id_s = y.store_id }).ToList();
            comboBox2.DataSource = t_st;
            comboBox2.DisplayMember = "Name_s";
            comboBox2.ValueMember = "id_s";
            //types
            var tp = (from x in ent.types select new { x, Name = x.type_name, id = x.type_code }).ToList();
            comboBox3.DataSource = tp;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "id";
            //supplier
            var sup = (from x in ent.suppliers select new { x, Name = x.supplier_name, id = x.supplier_id }).ToList();
            comboBox4.DataSource = sup;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
  
            int tostore;
            tostore = int.Parse(comboBox2.SelectedValue.ToString());
            store st = (from g in ent.stores
                        where g.store_id == tostore
                        select g).First();

            string code;
            code = comboBox3.SelectedValue.ToString();
            type t = (from f in ent.types
                      where f.type_code == code.ToString()
                      select f).First();
            t.store_id = tostore;

            int supid;
            supid = int.Parse(comboBox4.SelectedValue.ToString());
            supplier spp = (from p in ent.suppliers
                        where p.supplier_id == supid
                        select p).First();

            //////////////////////////////////////////////////////////            

            Random random = new Random();
            supply_permission sup_per = new supply_permission();
            sup_per.supply_permission_no = random.Next(1, 1000).ToString();
            sup_per.supply_permission_date = DateTime.Today;
            sup_per.store_id = tostore;
            sup_per.type_code = code;
            sup_per.quantity = Convert.ToInt32(textBox1.Text);
            sup_per.supplier_id = supid;
            sup_per.production_date = Convert.ToDateTime(textBox2.Text);
            sup_per.expiry_date = Convert.ToDateTime(textBox3.Text);
            ent.supply_permission.Add(sup_per);
            ent.SaveChanges();
            MessageBox.Show("Transformation is done succesfully");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;

        }
    }
}
