using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;

namespace _2ndtest
{
    public partial class login : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public static string Type, code;
        public login()
        {
            InitializeComponent();
            connection.ConnectionString = connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\DATABASEline2nd\OFFSET\OFFSET.accdb';Persist Security Info=False;"; ;

        }

        private void login_Load(object sender, EventArgs e)
        {
            btn_back.Visible = false;
            BTN_LOGIN.Visible = false;
            groupBox2.Visible = false;
            try
            {
                OleDbCommand command = new OleDbCommand();
                OleDbDataReader reader;
                connection.Open();
                command.Connection = connection;

                command.CommandText = "select * from TYPE";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbb_type.Items.Add(reader["CODE"].ToString());

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("err" + ex);
            }
            
        }

        private void BTN_LOGIN_Click(object sender, EventArgs e)
        {
            code = cbb_PN.Text;
            if (cbb_PN.Text == "")
            {
                MessageBox.Show("Please choose PN");
                return;
            }
            Main fm2 = new Main();
            this.Hide();
            fm2.ShowDialog();
            //this.Show();
            Application.Exit();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            BTN_LOGIN.Visible = false;
            cbb_PN.Items.Clear();
            btn_back.Visible = false;
            groupBox1.Visible = true;
            BTN_SELECT.Visible = true;
        }

        private void BTN_SELECT_Click(object sender, EventArgs e)
        {
            btn_back.Visible = true;
            Type = cbb_type.Text;
            if (cbb_type.Text == "")
            {
                MessageBox.Show("Please choose your TYPE");
                return;
            }
            try
            {

                OleDbCommand command = new OleDbCommand();
                OleDbDataReader reader;
                connection.Open();
                command.Connection = connection;

                command.CommandText = "select * from " + cbb_type.Text + "";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbb_PN.Items.Add(reader["CODE"].ToString());

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("err" + ex);
            }
            
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            BTN_LOGIN.Visible = true;

        }

        
    }
}
