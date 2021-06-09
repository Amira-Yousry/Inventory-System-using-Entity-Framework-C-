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
    public partial class client_Form5 : Form
    {
        public client_Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Insert
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                client cl = new client();
                cl.client_id = int.Parse(textBox1.Text);
                cl.client_name = textBox2.Text;
                cl.client_phone = textBox3.Text;
                cl.client_fax = textBox4.Text;
                cl.client_mobile = textBox5.Text;
                cl.client_email = textBox6.Text;
                cl.client_website = textBox7.Text;
                ent.clients.Add(cl);
                ent.SaveChanges();
                MessageBox.Show("New Client Data is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("The Client ID you entered is already saved. \n\nPlease Insert New Client ID or Update a Saved Client ID.");

            }
        }

        private void button2_Click(object sender, EventArgs e)//Update
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                int id = int.Parse(textBox1.Text);
                client cl = (from d in ent.clients
                             where d.client_id == id
                             select d).First();
                cl.client_name = textBox2.Text;
                cl.client_phone = textBox3.Text;
                cl.client_fax = textBox4.Text;
                cl.client_mobile = textBox5.Text;
                cl.client_email = textBox6.Text;
                cl.client_website = textBox7.Text;
                ent.SaveChanges();
                MessageBox.Show("Client Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("There is No Client ID: " + int.Parse(textBox1.Text) + "\n\n Please Update a Saved Client ID or Insert New Client ID.");

            }
        }
    }
}
