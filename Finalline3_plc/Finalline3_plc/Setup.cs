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
using S7.Net;

namespace Finalline3_plc
{
    public partial class Setup : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        Plc plc = new Plc(CpuType.S71200, "192.168.0.5", 0, 0);
        public Setup()
        {
            InitializeComponent();
            connection.ConnectionString = connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\DATABASEline3\OFFSET\OFFSET.accdb';Persist Security Info=False;"; ;

        }

        private void Setup_Load(object sender, EventArgs e)
        {
            i00.Visible = false;
            i01.Visible = false;
            i02.Visible = false;
            
            timer_luupokayoke.Enabled = true;
            timer_testgiatri.Enabled = true;
            timer_print.Enabled = true;
            timer_status.Enabled = true;
            groupBox4.Enabled = false;
            // check_Z.Appearance = System.Windows.Forms.Appearance.Button;
            OleDbCommand command1 = new OleDbCommand();
            OleDbDataReader reader1;
            connection.Open();
            command1.Connection = connection;
            command1.CommandText = "select * from " + LOGIN.Type + " where CODE='" + LOGIN.code + "'";
            reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                label1.Text = reader1["Clip"].ToString();
                label2.Text = reader1["Foam"].ToString();               
                label4.Text = reader1["Bat_nu"].ToString();
                label5.Text = reader1["Chan_pin"].ToString();
                label6.Text = reader1["Test_Z"].ToString();
                label7.Text = reader1["Test_tu"].ToString();
                label8.Text = reader1["Print_label"].ToString();
                label9.Text = reader1["Laser_mark"].ToString();

            }
        }

        private void timer_testgiatri_Tick(object sender, EventArgs e)
        {
            if (check_testtu.Checked == true)
            {
                label7.Text = "1";
            }
            else
            {
                label7.Text = "0";
            }
            if (check_Z.Checked == true)
            {
                label6.Text = "1";
            }
            else
            {
                label6.Text = "0";
            }
        }

        private void timer_status_Tick(object sender, EventArgs e)
        {
            if (label1.Text == "1")
            {
                check_start.Checked = true;
            }
            else
            {
                check_start.Checked = false;
            }
            if (label2.Text == "1")
            {
                check_clip.Checked = true;
            }
            else
            {
                check_clip.Checked = false;
            }
            
            if (label4.Text == "1")
            {
                check_nu.Checked = true;
            }
            else
            {
                check_nu.Checked = false;
            }
            if (label5.Text == "1")
            {
                check_chanpin.Checked = true;
            }
            else
            {
                check_chanpin.Checked = false;
            }
            if (label6.Text == "1")
            {
                check_Z.Checked = true;
            }
            else
            {
                check_Z.Checked = false;
            }
            if (label7.Text == "1")
            {
                check_testtu.Checked = true;
            }
            else
            {
                check_testtu.Checked = false;
            }
            if (label8.Text == "yes")
            {
                check_inlabel.Checked = true;
            }
            else
            {
                check_inlabel.Checked = false;
            }
            if (label9.Text == "yes")
            {
                check_inlaze.Checked = true;
            }
            else
            {
                check_inlaze.Checked = false;
            }
            if (label8.Text == "yes" && label9.Text == "yes")
            {
                MessageBox.Show("Chon 1 trong 2 kieu in");
            }
        }

        private void timer_print_Tick(object sender, EventArgs e)
        {
            if (check_inlabel.Checked == true)
            {
                label8.Text = "yes";
                label9.Text = "no";
                check_inlaze.Enabled = false;
            }
            else
            {
                label8.Text = "no";
                check_inlaze.Enabled = true;
            }
            if (check_inlaze.Checked == true)
            {
                label8.Text = "no";
                label9.Text = "yes";
                check_inlabel.Enabled = false;
            }
            else
            {
                label9.Text = "no";
                check_inlabel.Enabled = true;
            }
        }

        private void timer_plc_Tick(object sender, EventArgs e)
        {
            if (plc.IsConnected)
            {
                object I0_0 = plc.Read("I0.0");
                i0_0.Text = Convert.ToString(I0_0);
                if (i0_0.Text == "True")
                {
                    i00.Visible = true;
                }
                else if (i0_0.Text == "False")
                {
                    i00.Visible = false;
                }
                object I0_1 = plc.Read("I0.1");
                i0_0.Text = Convert.ToString(I0_1);
                if (i0_1.Text == "True")
                {
                    i01.Visible = true;
                }
                else if (i0_0.Text == "False")
                {
                    i01.Visible = false;
                }
                object I0_2 = plc.Read("I0.2");
                i0_2.Text = Convert.ToString(I0_2);
                if (i0_2.Text == "True")
                {
                    i02.Visible = true;
                }
                else if (i0_0.Text == "False")
                {
                    i02.Visible = false;
                }                           
                if (checkQ00.Checked == true)
                {
                    plc.Write("Q0.0", 1);
                    q00.Visible = true;
                }
                else if (checkQ00.Checked == false)
                {
                    plc.Write("Q0.0", 0);
                    q00.Visible = false;
                }
                if (checkQ01.Checked == true)
                {
                    plc.Write("Q0.1", 1);
                    q01.Visible = true;
                }
                else if (checkQ01.Checked == false)
                {
                    plc.Write("Q0.1", 0);
                    q01.Visible = false;
                }
            }
        }

        private void timer_luupokayoke_Tick(object sender, EventArgs e)
        {
            if (check_start.Checked == true)
            {
                label1.Text = "1";
            }
            else
            {
                label1.Text = "0";
            }

            if (check_clip.Checked == true)
            {
                label2.Text = "1";
            }
            else
            {
                label2.Text = "0";
            }
           
            if (check_nu.Checked == true)
            {
                label4.Text = "1";
            }
            else
            {
                label4.Text = "0";
            }

            if (check_chanpin.Checked == true)
            {
                label5.Text = "1";
            }
            else
            {
                label5.Text = "0";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            connection.Close();
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "update " + LOGIN.Type + " set Start ='" + label1.Text + "',Clip ='" + label2.Text + "',Bat_nu = '" + label4.Text + "',Chan_pin ='" + label5.Text + "',Test_Z = '" + label6.Text + "',Test_tu = '" + label7.Text + "',Print_label = '" + label8.Text + "',Laser_mark = '" + label9.Text + "' where CODE = '" + LOGIN.code + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("data update successful");
            connection.Close();
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            timer_status.Enabled = false;
        }

        private void btn_plc_Click(object sender, EventArgs e)
        {
            plc.Open();
            if (plc.IsConnected)
            {
                MessageBox.Show("PLC connected");
                timer_plc.Enabled = true;
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void Setup_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
