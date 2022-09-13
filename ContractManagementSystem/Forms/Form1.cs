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
using SLRDbConnector;

namespace ContractManagementSystem
{
    public partial class Form1 : Form
    {
        DbConnector db;
        public Form1()
        {
            InitializeComponent();
            db = new DbConnector();  
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                if (checkLogin())
                {
                  
                }
            }
        }

        private bool checkLogin()
        {
            string username = db.getSingleValue("select UserName frm tblUsers where UserName = '"+txtUserName.Text+"' and Password = '"+txtPassword.Text+"'",out username, 0);
            if(username == null)
            {
                MessageBox.Show("Username or Password is Incorrect", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true; 
            }
        }

        private bool isFormValid()
        {
            if(txtUserName.Text.ToString().Trim() == string.Empty || txtPassword.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are Empty", "Please Fill All Required Fields..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
