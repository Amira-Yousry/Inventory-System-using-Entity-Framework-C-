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
    public partial class supply_permission_Form6 : Form
    {
        public supply_permission_Form6()
        {
            InitializeComponent();
        }
        private void supply_permission_Form6_Load(object sender, EventArgs e)
        {
            EF_Project_1Entities1 ent = new EF_Project_1Entities1();
            //supplier
            var sup = (from x in ent.suppliers select new { x, Name = x.supplier_name, id = x.supplier_id }).ToList();
            comboBox1.DataSource = sup;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            //store
            var st = (from x in ent.stores select new { x, Name = x.store_name, id = x.store_id }).ToList();
            comboBox2.DataSource = st;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";
            //type
            var tp = (from x in ent.types select new { x, Name = x.type_name, id = x.type_code }).ToList();
            comboBox3.DataSource = tp;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "id";

        }


        private void button1_Click(object sender, EventArgs e)//insert
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                supply_permission sp = new supply_permission();
                sp.supply_permission_no = textBox1.Text;
                sp.supply_permission_date = Convert.ToDateTime(textBox2.Text);
                sp.supplier_id = int.Parse(comboBox1.SelectedValue.ToString());
                sp.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                sp.type_code = comboBox3.SelectedValue.ToString();
                sp.quantity = int.Parse(textBox3.Text);
                sp.production_date = Convert.ToDateTime(textBox4.Text);
                sp.expiry_date = Convert.ToDateTime(textBox5.Text);
                ent.supply_permission.Add(sp);
                type obj = new type();
                obj.type_quantity = obj.type_quantity + int.Parse(textBox3.Text);
                ent.SaveChanges();
                MessageBox.Show("New Supply Permission is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
            catch 
            {
                MessageBox.Show("The Supply Permission Number you entered is already saved. \n\nPlease Insert New Supply Permission Number or Update a Saved Supply Permission Number.");
            }
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                string sp_N = textBox1.Text;
                supply_permission sp = (from d in ent.supply_permission
                                        where d.supply_permission_no == sp_N
                                        select d).First();
                sp.supply_permission_date = Convert.ToDateTime(textBox2.Text);
                sp.supplier_id = int.Parse(comboBox1.SelectedValue.ToString());
                sp.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                sp.type_code = comboBox3.SelectedValue.ToString();
                sp.quantity = int.Parse(textBox3.Text);
                sp.production_date = Convert.ToDateTime(textBox4.Text);
                sp.expiry_date = Convert.ToDateTime(textBox5.Text);
                ent.SaveChanges();
                MessageBox.Show("Supply Permission Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("There is No Supply Permission Number: " + int.Parse(textBox1.Text) + "\n\n Please Update a Saved Supply Permission Number or Insert New Supply Permission Number.");

            }
        }


    }
}
