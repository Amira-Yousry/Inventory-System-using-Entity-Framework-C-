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
    public partial class store_Form2 : Form
    {
        public store_Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//insert
        {
            try
            {

                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                //ent.stores.Add(new store { store_id = int.Parse(textBox1.Text), store_name = textBox2.Text, store_address = textBox3.Text, store_admin = textBox4.Text });
                //ent.SaveChanges();
                //MessageBox.Show("New Store Data is Added Successfully");
                //textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
                store s = new store();
                s.store_id = int.Parse(textBox1.Text);
                s.store_name = textBox2.Text;
                s.store_address = textBox3.Text;
                s.store_admin = textBox4.Text;
                ent.stores.Add(s);
                ent.SaveChanges();
                MessageBox.Show("New Store Data is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }
            catch(Exception)
            {
                MessageBox.Show("The Store ID you entered is already saved. \n\nPlease Insert New Store ID or Update a Saved Store ID.");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                int id = int.Parse(textBox1.Text);
                store s = (from d in ent.stores
                           where d.store_id == id
                           select d).First();
                s.store_name = textBox2.Text;
                s.store_address = textBox3.Text;
                s.store_admin = textBox4.Text;
                ent.SaveChanges();
                MessageBox.Show("Store Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("There is No Store ID: "+int.Parse(textBox1.Text)+"\n\n Please Update a Saved Store ID or Insert New Store ID.");
            }
        }
    }
}
