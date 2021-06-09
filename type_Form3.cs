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
    public partial class type_Form3 : Form
    {
        public type_Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//insert
        {
            try {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                type t = new type();
                t.type_code = textBox1.Text;
                t.type_name = textBox2.Text;
                t.type_measuring_unit = textBox3.Text;    
                t.type_quantity = 0;
                ent.types.Add(t);
                ent.SaveChanges();
                MessageBox.Show("New Type Data is Added Successfully");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
               
            }
            catch (Exception)
            {
                MessageBox.Show("The Type Code you entered is already saved. \n\nPlease Insert New Type Code or Update a Saved Type Code.");
            }

        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            try
            {
                EF_Project_1Entities1 ent = new EF_Project_1Entities1();
                string code = textBox1.Text;
                type t = (from d in ent.types
                          where d.type_code == code
                          select d).First();
                t.type_name = textBox2.Text;
                t.type_measuring_unit = textBox3.Text;
                ent.SaveChanges();
                MessageBox.Show("Type Data is Updated succesfully");
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("There is No Type Code: " + textBox1.Text+ "\n\n Please Update a Saved Type Code or Insert New Type Code.");
            }


        }


    }
}
