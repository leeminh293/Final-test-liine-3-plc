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

namespace Finalline3_plc
{
    public partial class LOGIN : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public static string Type, code;

        private void LOGIN_Load(object sender, EventArgs e)
        {
            btn_login.Visible = false;
            groupBox2.Visible = false;
            btn_back.Visible = false;
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
                    comboBox1.Items.Add(reader["CODE"].ToString());

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("err" + ex);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_back.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            comboBox2.Items.Clear();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            code = comboBox2.Text;
            if (comboBox2.Text == "")
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

        private void btn_sel_Click(object sender, EventArgs e)
        {
            Type = comboBox1.Text;
            if (comboBox1.Text == "")
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

                command.CommandText = "select * from " + comboBox1.Text + "";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["CODE"].ToString());

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("err" + ex);
            }

            groupBox1.Visible = false;
            groupBox2.Visible = true;
            btn_login.Visible = true;
            btn_back.Visible = true;
        }

        private void btn_setup_Click(object sender, EventArgs e)
        {
            code = comboBox2.Text;
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please choose PN");
                return;
            }
            Setup fm2 = new Setup();
            fm2.ShowDialog();
        }

        public LOGIN()
        {
            InitializeComponent();
            connection.ConnectionString = connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\DATABASEline3\OFFSET\OFFSET.accdb';Persist Security Info=False;"; ;

        }
    }
}
