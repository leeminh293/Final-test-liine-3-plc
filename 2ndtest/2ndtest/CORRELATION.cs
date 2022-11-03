using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.VisaNS;
using System.Data.OleDb;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _2ndtest
{
    public partial class Corelation1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private MessageBasedSession GPIB;
        double[] ii = new double[15];
        double[] qq = new double[15];
        double[] itong = new double[5];
        double[] qtong = new double[5];
        double[] inhap = new double[5];
        double[] qnhap = new double[5];
        double[] err_ii = new double[5];
        double[] err_qq = new double[5];
        double i, q, r, err_i, err_q, err_r;

        

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            inhap[0] = Convert.ToDouble(in1.Text);
            inhap[1] = Convert.ToDouble(in2.Text);
            inhap[2] = Convert.ToDouble(in3.Text);
            inhap[3] = Convert.ToDouble(in4.Text);
            inhap[4] = Convert.ToDouble(in5.Text);
            qnhap[0] = Convert.ToDouble(qn1.Text);
            qnhap[1] = Convert.ToDouble(qn2.Text);
            qnhap[2] = Convert.ToDouble(qn3.Text);
            qnhap[3] = Convert.ToDouble(qn4.Text);
            qnhap[4] = Convert.ToDouble(qn5.Text);

            for (int c = 0; c < 5; c++)
            {
                err_ii[c] = itong[c] - inhap[c];
                err_qq[c] = qtong[c] - qnhap[c];


            }
            err_i = (err_ii[0] + err_ii[1] + err_ii[2] + err_ii[3] + err_ii[4]) / 5;
            err_q = (err_qq[0] + err_qq[1] + err_qq[2] + err_qq[3] + err_qq[4]) / 5;


            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            // string query = "update employee set usename='"+txt_usename.Text+"'  pay='"+txt_pay.Text+"' where ID =" +txt_EID.Text+" ";
            // MessageBox.Show(query);
            command.CommandText = "update " + login.Type + " set err_i ='" + err_i + "',err_q ='" + err_q + "',err_r ='" + err_r + "',Tim ='" + DateTime.Now.ToLongTimeString() + "',Dat ='" + DateTime.Now.ToString("dd/MM/yyyy") + "'where CODE = '" + login.code + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Data update successful");
            connection.Close();
        }
        string timer1, timer2;
        
    

        public Corelation1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline2\\OFFSET\\OFFSET.accdb';Persist Security Info=False;"; ;

        }

        private void Corelation1_Load(object sender, EventArgs e)
        {
            GPIB = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::6::INSTR");
            GPIB.Write("*IDN?");
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            for (a = 0; a < 5; a++)
            {
                MessageBox.Show("Put the part into the tool");

                for (b = 0; b < 3; b++)
                {

                    Thread.Sleep(10);
                    GPIB.Write("TRIG");
                    GPIB.Write("RESO:TRIG");

                    if (Main.testtu == "no")
                    {
                        Thread.Sleep(100);
                        timer1 = GPIB.ReadString();
                        string result1 = timer1.Trim();
                        i = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(0, 5), @"\d+\.*\d+").Value)), 2);

                        q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(9, 5), @"\d+\.*\d+").Value)), 1);
                    }
                    else if (Main.testtu == "yes")
                    {
                        Thread.Sleep(1000);
                        timer1 = GPIB.ReadString();
                        string result1 = timer1.Trim();
                        i = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(0, 14), @"\d+\.*\d+").Value) / 100000), 2);

                        q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(50, 12), @"\d+\.*\d+").Value) / 100000), 1);

                    }


                    ii[a * 3 + b] = i;
                    qq[a * 3 + b] = q;



                }
                itong[a] = (ii[a * 3] + ii[a * 3 + 1] + ii[a * 3 + 2]) / 3;
                qtong[a] = (qq[a * 3] + qq[a * 3 + 1] + qq[a * 3 + 2]) / 3;

                if (a == 0)
                {
                    n1t1.Text = Convert.ToString(ii[0]);
                    n1t2.Text = Convert.ToString(ii[1]);
                    n1t3.Text = Convert.ToString(ii[2]);
                    n1q1.Text = Convert.ToString(qq[0]);
                    n1q2.Text = Convert.ToString(qq[1]);
                    n1q3.Text = Convert.ToString(qq[2]);

                }
                if (a == 1)
                {
                    n2t1.Text = Convert.ToString(ii[3]);
                    n2t2.Text = Convert.ToString(ii[4]);
                    n2t3.Text = Convert.ToString(ii[5]);
                    n2q1.Text = Convert.ToString(qq[3]);
                    n2q2.Text = Convert.ToString(qq[4]);
                    n2q3.Text = Convert.ToString(qq[5]);

                }
                if (a == 2)
                {
                    n3t1.Text = Convert.ToString(ii[6]);
                    n3t2.Text = Convert.ToString(ii[7]);
                    n3t3.Text = Convert.ToString(ii[8]);
                    n3q1.Text = Convert.ToString(qq[6]);
                    n3q2.Text = Convert.ToString(qq[7]);
                    n3q3.Text = Convert.ToString(qq[8]);

                }
                if (a == 3)
                {
                    n4t1.Text = Convert.ToString(ii[9]);
                    n4t2.Text = Convert.ToString(ii[10]);
                    n4t3.Text = Convert.ToString(ii[11]);
                    n4q1.Text = Convert.ToString(qq[9]);
                    n4q2.Text = Convert.ToString(qq[10]);
                    n4q3.Text = Convert.ToString(qq[11]);

                }
                if (a == 4)

                {
                    n5t1.Text = Convert.ToString(ii[12]);
                    n5t2.Text = Convert.ToString(ii[13]);
                    n5t3.Text = Convert.ToString(ii[14]);
                    n5q1.Text = Convert.ToString(qq[12]);
                    n5q2.Text = Convert.ToString(qq[13]);
                    n5q3.Text = Convert.ToString(qq[14]);

                }


            }
            MessageBox.Show("Fill in the sample value in the external measure");

        }
    
    }
}
