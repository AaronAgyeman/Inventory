using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_System
{
    
    public partial class LoginForms : Form
    {
        public LoginForms()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //When the close icon is clicked
            if (MessageBox.Show("Exit Applicaton", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
              SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aaron\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30 ");
              SqlCommand cm = new SqlCommand("SELECT * FROM tbUser WHERE username='"+txtName.Text+"' AND password='"+ txtPass.Text+"'" ,con);
              SqlDataAdapter sda = new SqlDataAdapter(cm);
              DataTable dt = new DataTable();
              sda.Fill(dt);


              string cmbItemValue = comboBox1.SelectedItem.ToString();
              if (dt.Rows.Count > 0)
              {
                  for (int i = 0; i < dt.Rows.Count; i++)

                  {
                      if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                      {
                          MessageBox.Show("You are Logged in as " + dt.Rows[i][1]);
                          if (comboBox1.SelectedIndex == 0)
                          {
                              mainForm m = new mainForm();
                              m.Show();
                              this.Hide();
                          }
                          else
                          {
                              AttendantForm a = new AttendantForm();
                              a.Show();
                              this.Hide();

                          }
                      }
                  }
              }
              else
              {
                  MessageBox.Show("Error");

              }
           

        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            // this clears all context in the Username and Password textBox
            txtName.Clear();
            txtPass.Clear();
        }
    }
}
