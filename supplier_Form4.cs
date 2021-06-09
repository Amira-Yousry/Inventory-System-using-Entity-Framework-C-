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
    public partial class supplier_Form4 : Form
    {
        public supplier_Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Insert
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                supplier sup = new supplier();
                sup.supplier_id = int.Parse(textBox1.Text);
                sup.supplier_name = textBox2.Text;
                sup.supplier_phone = textBox3.Text;
                sup.supplier_fax = textBox4.Text;
                sup.supplier_mobile = textBox5.Text;
                sup.supplier_email = textBox6.Text;
                sup.supplier_website = textBox7.Text;
                ent.suppliers.Add(sup);
                ent.SaveChanges();
                MessageBox.Show("New Supplier Data is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("The Supplier ID you entered is already saved. \n\nPlease Insert New Supplier ID or Update a Saved Supplier ID.");

            }

        }


        private void button2_Click(object sender, EventArgs e)//update
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                int id = int.Parse(textBox1.Text);
                supplier s = (from d in ent.suppliers
                              where d.supplier_id == id
                              select d).First();
                s.supplier_name = textBox2.Text;
                s.supplier_phone = textBox3.Text;
                s.supplier_fax = textBox4.Text;
                s.supplier_mobile = textBox5.Text;
                s.supplier_email = textBox6.Text;
                s.supplier_website = textBox7.Text;
                ent.SaveChanges();
                MessageBox.Show("Supplier Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("There is No Supplier ID: " + int.Parse(textBox1.Text) + "\n\n Please Update a Saved Supplier ID or Insert New Supplier ID.");

            }

        }

       
    }
}
