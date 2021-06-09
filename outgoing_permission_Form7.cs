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
    public partial class outgoing_permission_Form7 : Form
    {
        public outgoing_permission_Form7()
        {
            InitializeComponent();
        }
        private void outgoing_permission_Form7_Load(object sender, EventArgs e)
        {
            EF_Project_1Entities1 ent = new EF_Project_1Entities1();
            //client
            var cl = (from x in ent.clients select new { x, Name = x.client_name, id = x.client_id }).ToList();
            comboBox1.DataSource = cl;
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
                outgoing_permission op = new outgoing_permission();
                op.outgoing_permission_no = textBox1.Text;
                op.outgoing_permission_date = Convert.ToDateTime(textBox2.Text);
                op.client_id = int.Parse(comboBox1.SelectedValue.ToString());
                op.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                op.type_code = comboBox3.SelectedValue.ToString();
                op.quantity = int.Parse(textBox3.Text);
                ent.outgoing_permission.Add(op);
                type obj = new type();
                obj.type_quantity = obj.type_quantity - int.Parse(textBox3.Text);
                ent.SaveChanges();
                MessageBox.Show("New OutGoing Permission is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("The OutGoing Permission Number you entered is already saved. \n\nPlease Insert New OutGoing Permission Number or Update a Saved OutGoing Permission Number.");
            }
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            try

            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                string op_N = textBox1.Text;
                outgoing_permission op = (from d in ent.outgoing_permission
                                          where d.outgoing_permission_no == op_N
                                          select d).First();
                op.outgoing_permission_date = Convert.ToDateTime(textBox2.Text);
                op.client_id = int.Parse(comboBox1.SelectedValue.ToString());
                op.store_id = int.Parse(comboBox2.SelectedValue.ToString());
                op.type_code = comboBox3.SelectedValue.ToString();
                op.quantity = int.Parse(textBox3.Text);

                ent.SaveChanges();
                MessageBox.Show("OutGoing Permission Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("There is No OutGoing Permission Number: " + int.Parse(textBox1.Text) + "\n\n Please Update a Saved OutGoing Permission Number or Insert New OutGoing Permission Number.");

            }

        }


    }
}
