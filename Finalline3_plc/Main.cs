using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using NationalInstruments.VisaNS;
using System.Data.OleDb;
using System.Threading;
using System.Text.RegularExpressions;
using BarTender;
using System.Diagnostics;
using System.Net;
using S7.Net;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Drawing.Printing;

namespace Finalline3_plc
{
    public partial class Main : Form
    {
        public static string testtu, intem, tanso1, lasermark, test_Z;
        string timee, timerr1, timerr2, timerr3, timerr4, ngayy;
        Plc plc = new Plc(CpuType.S71200, "192.168.0.5", 0, 0);
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection1 = new OleDbConnection();
        private OleDbConnection connection3 = new OleDbConnection();
        private MessageBasedSession GPIB;
        double tanso, soluong = 0, idmax, freq;
        int[] result = new int[6];
        string Dstyle, path,path1,path2,path3,path4,pathdelphi,laze;
        double imax, imin, qmin, qmax, imin64, imax64, i, q, rdc, rac, f, err_i, err_q, err_rac, err_rdc, racmin, racmax, rdcmin, rdcmax, z_min, z_max, z;
        string hkmc, dnke, pncode, filein, qrcode, hkmcpn, dstyle, dstyle1, symbol, link, symbol_label, makhachhang, clip, whitetap, startt, divat, nu;

        Boolean start, clipp, foaam, whiteetap, nuu, chanpinn;


        private void Date_timer_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            TimeSpan ca1 = new TimeSpan(6, 0, 0); //10 o'clock
            TimeSpan ca2 = new TimeSpan(14, 0, 0); //12 o'clock
            TimeSpan ca3 = new TimeSpan(22, 0, 0); //12 o'clock
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now >= ca1) && (now <= ca2))
            {
                timee = "Shift 1";
            }
            else if ((now <= ca3) && (now >= ca2))
            {
                timee = "Shift 2";
            }
            else
            {
                timee = "Shift 3";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                       
            Setup fm2 = new Setup();
            fm2.ShowDialog();
        }

        private void timer_start_Tick(object sender, EventArgs e)
        {
            object startt = plc.Read("I0.0");
            start = Convert.ToBoolean(startt);
            if (start == true)
            {
                plc.Write("Q0.0", 1);
                btn_start.PerformClick();
                btn_start.Visible = false;
            }

            string nn = DateTime.Now.ToString("yyyy");
            string nnn = "01-01-";
            string name = nnn + "" + nn;

            DateTime startdate = DateTime.Parse(name);
            DateTime now = DateTime.Now;
            TimeSpan songay = now.Subtract(startdate);
            double sodate = songay.TotalDays, ngay = Convert.ToDouble(Convert.ToString(sodate).Substring(0, 3));
            ngayy = string.Format("{0:000}", ngay + 1);
        }

        private void timer_loadchan_Tick(object sender, EventArgs e)
        {
            if (startt == "1")
            {
                object i00 = plc.Read("I0.0");
                System.Boolean i0_0 = Convert.ToBoolean(i00);
                if (i0_0 == true)
                {
                    start = true;
                }
                else if (i0_0 == false)
                {
                    start = false;
                    btn_start.Visible = true;
                    timer_start.Enabled = true;
                }
            }
            else if (startt == "0")
            {
                start = true;
            }


            if (nu == "1")
            {
                object i02 = plc.Read("I0.1");
                System.Boolean i0_2 = Convert.ToBoolean(i02);
                if (i0_2 == true)
                {
                    nuu = true;
                }
                else if (i0_2 == false)
                {
                    nuu = false;

                }
            }

            else if (nu == "0")
            {
                nuu = false;
            }
           
            if (divat == "1")
            {
                object i03 = plc.Read("I0.2");
                System.Boolean i0_3 = Convert.ToBoolean(i03);
                if (i0_3 == true)
                {
                    chanpinn = true;
                }
                else if (i0_3 == false)
                {
                    chanpinn = false;

                }
            }

            else if (divat == "0")
            {
                chanpinn = true;
            }
        }

        private void timer_pokayoke_Tick(object sender, EventArgs e)
        {
            if (foaam == true)
            {
                pictureStart.Visible = true;
            }
            else
            {
                pictureStart.Visible = false;
            }
                      

            if (nuu == true)
            {
                picturenu.Visible = false;
            }
            else
            {
                picturenu.Visible = true;
            }

            if (chanpinn == true)
            {
                picturedivat.Visible = true;
            }
            else
            {
                picturedivat.Visible = false;
            }
        }

        private void timer_ngat_Tick(object sender, EventArgs e)
        {
            object startt = plc.Read("I0.0");
            start = Convert.ToBoolean(startt);

            if (start == false)
            {
                plc.Write("Q0.0", 0);
                timer_start.Enabled = true;
                btn_start.Enabled = true;
                btn_start.Visible = true;
                

            }
        }

        

 

        
        private void Parameters()
        {
            Parameter.Text = LOGIN.code;

            btn_corr.Enabled = true;
            btn_corr.Visible = true;
            string a = LOGIN.Type;
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from " + a + " where code='" + Parameter.Text + "'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                intem = reader["Print_label"].ToString();
                lasermark = reader["Laser_mark"].ToString();
                testtu = reader["Test_tu"].ToString();
                test_Z = reader["Test_Z"].ToString();
                inmin.Text = reader["imin"].ToString();
                inmax.Text = reader["imax"].ToString();
                Q_min.Text = reader["qmin"].ToString();
                Q_max.Text = reader["qmax"].ToString();
                err_i = Convert.ToDouble(reader["err_i"].ToString());
                err_q = Convert.ToDouble(reader["err_q"].ToString());
                

                if (test_Z == "1")
                {
                    Rmax.Text = reader["RDCmax"].ToString();
                    Rmin.Text = reader["RDCmin"].ToString();
                    rdcmin = Convert.ToDouble(Rmin.Text);
                    rdcmax = Convert.ToDouble(Rmax.Text);
                    
                    err_rdc = Convert.ToDouble(reader["err_rdc"].ToString());
                }
                if (testtu == "1")
                {
                    Rac_min.Text = reader["RACmin"].ToString();
                    Rac_max.Text = reader["RACmax"].ToString();
                    racmin = Convert.ToDouble(Rac_min.Text);
                    racmax = Convert.ToDouble(Rac_max.Text);
                    err_rac = Convert.ToDouble(reader["err_rac"].ToString());
                }
                else if (testtu == "0")
                {
                    tanso1 = reader["tanso"].ToString();
                }
                clip = reader["Clip"].ToString();
                startt = reader["Start"].ToString();                
                nu = reader["Bat_nu"].ToString();
                divat = reader["Chan_pin"].ToString();

                imin = Convert.ToDouble(inmin.Text);
                imax = Convert.ToDouble(inmax.Text);
                qmax = Convert.ToDouble(Q_max.Text);
                qmin = Convert.ToDouble(Q_min.Text);
                imax64 = imin + (imax - imin) * 0.7;
                imin64 = imin + (imax - imin) * 0.3;
                label8.Text = "Ind>" + Convert.ToString(imax) + "";
                label15.Text = "" + Convert.ToString(imax64) + "<=Ind<=" + Convert.ToString(imax) + "";
                label16.Text = "" + Convert.ToString(imin64) + "<=Ind<" + Convert.ToString(imax64) + "";
                label19.Text = "" + Convert.ToString(imin) + "<=Ind<" + Convert.ToString(imin64) + "";
                label7.Text = "Ind<" + Convert.ToString(imin) + "";
            }
            freq = Convert.ToDouble(tanso1);
            connection.Close();
        }
        private void status()
        {

            int i = 0, j = 0, k = 0, l = 0, m = 0;
            string a;

            a = "i";

            connection1.Close();


            OleDbCommand command1 = new OleDbCommand();
            OleDbDataReader reader1;
            connection1.Open();
            command1.Connection = connection1;
            command1.CommandText = "select * from PAS where dat='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and mae= '" + timee + "'";
            reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                // if (Convert.ToDouble(reader1["" + a + ""].ToString()) > 0)
                if (reader1["i"].ToString() != "")
                {
                    double ind;
                    ind = Convert.ToDouble(reader1["" + a + ""].ToString());
                    if (ind <= imax && ind >= imax64)
                    {
                        i = i + 1;
                        tb2.Text = Convert.ToString(i);

                    }
                    else if (ind < imax64 && ind >= imin64)
                    {
                        k = k + 1;
                        tb3.Text = Convert.ToString(k);

                    }
                    else if (ind < imin64 && ind >= imin)
                    {
                        j = j + 1;
                        tb4.Text = Convert.ToString(j);
                    }
                }
            }
            if (i == 0) { tb2.Text = "0"; }
            if (k == 0) { tb3.Text = "0"; }
            if (j == 0) { tb4.Text = "0"; }
            connection1.Close();
            OleDbCommand command2 = new OleDbCommand();
            OleDbDataReader reader2;
            connection1.Open();
            command2.Connection = connection1;
            command2.CommandText = "select * from FAI where dat='" + DateTime.Now.ToString("dd/MM/yyyy") + "'and mae = '" + timee + "'";
            reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                if (reader2["i"].ToString() != "")
                {

                    double ind1;
                    ind1 = Convert.ToDouble(reader2["i"].ToString());
                    if (ind1 > imax)
                    {
                        l = l + 1;
                        tb1.Text = Convert.ToString(l);

                    }
                    else if (ind1 < imin)
                    {
                        m = m + 1;
                        tb5.Text = Convert.ToString(m);
                    }
                }
            }
            connection1.Close();
            if (l == 0) { tb1.Text = "0"; }
            if (m == 0) { tb5.Text = "0"; }
            tb6.Text = Convert.ToString(i + j + k + l + m);
        }
        private void sum()
        {
            string id;
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            connection1.Open();
            command.Connection = connection1;
            command.CommandText = "SELECT MAX(ID) AS [ID] FROM PAS";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                id = reader["ID"].ToString();
                idmax = Convert.ToDouble(id);

            }
            connection1.Close();


            OleDbCommand command1 = new OleDbCommand();
            OleDbDataReader reader1;
            connection1.Open();
            command1.Connection = connection1;
            command1.CommandText = "select * from PAS where ID=" + idmax + "";
            reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                string datee;
                datee = reader1["dat"].ToString();
                if (datee == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    string soluongstring = reader1["number"].ToString();
                    soluong = Convert.ToDouble(soluongstring);

                }
                else
                {
                    soluong = 0;
                }
            }
            connection1.Close();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            txt_loi.Visible = false;
            txt_PASS.Visible = false;
            Parameters();
            sum();
            timer_start.Enabled = true;
            Date_timer.Enabled = true;
            timer_ngat.Enabled = true;
            timer_loadchan.Enabled = true;
            timer_pokayoke.Enabled = true;
            Date_timer.Start();
            lbl_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            
            GPIB = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::6::INSTR");
            GPIB.Write("*IDN?");
            if (testtu == "0")
            {
                GPIB.Write("MEAS");
                GPIB.Write("MEAS:LEV 1V");
                GPIB.Write("MEAS:FUNC:L;Q");
                GPIB.Write("MEAS: FREQ 125000");
                Rac_max.Visible = false;
                Rac_min.Visible = false;
                label11.Visible = false;
                TB_Rac.Visible = false;
                TB_pa3.Visible = false;
                textBox20.Visible = false;
                label9.Visible = false;
                TB_Rac.Enabled = false;
                TB_pa3.Enabled = false;

                txt_donvido.Text = "µH";
            }
            else if (testtu == "1")
            {
                GPIB.Write("RESO");
                Thread.Sleep(100);
                GPIB.Write("RESO:Start 100000");
                Thread.Sleep(100);
                GPIB.Write("RESO:Stop 150000");
                Thread.Sleep(100);
                txt_donvido.Text = "KHZ";
            }
            if (test_Z == "0")
            {
               
                label13.Visible = false;
                label5.Visible = false;                
                Rmin.Visible = false;
                Rmax.Visible = false;             
                TB_pa4.Visible = false;               
                TB_rdc.Visible = false;              
                textBox3.Visible = false;               
                groupBox1.Size = new Size(416, 300);
               
                txt_PASS.Location = new Point(215, 214);
            }
            
            if (intem == "no" && lasermark == "yes")
            {
                grouplaser.Visible = true;
                grouplaser.Enabled = true;
            }
            plc.Open();
            if (plc.IsConnected)
            {
                plc.Write("Q0.0", 0);
                plc.Write("Q0.1", 0);
                //  plc.Close();
            }
        }



        private void btnlaser_off_Click(object sender, EventArgs e)
        {
            plc.Write("Q0.1", 0);
        }

        private void btnlaser_on_Click(object sender, EventArgs e)
        {
            plc.Write("Q0.1", 1);
        }
        private void btn_corr_Click(object sender, EventArgs e)
        {
            
            plc.Close();
            Correlation fm2 = new Correlation();
            fm2.ShowDialog();

        }


        public Main()
        {
            InitializeComponent();
            connection1.ConnectionString = connection1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline3\\data\\" + LOGIN.Type + "\\" + LOGIN.code + ".accdb';Persist Security Info=False;"; ;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline3\\OFFSET\\OFFSET.accdb';Persist Security Info=False;"; ;
            connection3.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline3\\LASER marking\\Lasermark.accdb';Persist Security Info=False;"; ;


        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            txt_loi.Visible = false;
            txt_PASS.Visible = false;
            if (nuu == false && chanpinn == true)
            {


                btn_start.Visible = false;

                timer_start.Enabled = false;
                string a = LOGIN.Type;
                OleDbCommand command = new OleDbCommand();
                OleDbDataReader reader;
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from " + a + " where code='" + Parameter.Text + "'";
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    testtu = reader["Test_tu"].ToString();
                    test_Z = reader["Test_Z"].ToString();
                    err_i = Convert.ToDouble(reader["err_i"].ToString());
                    err_q = Convert.ToDouble(reader["err_q"].ToString());
                    if (testtu == "yes")
                    {
                        err_rac = Convert.ToDouble(reader["err_rac"].ToString());
                    }
                    if (test_Z == "yes")
                    {
                        err_rdc = Convert.ToDouble(reader["err_rdc"].ToString());
                    }

                }
                //connection.Close();
                timerr1 = "";
                timerr2 = "";
                timerr3 = "";
                timerr4 = "";
                if (testtu == "1")
                {
                    GPIB.Write("TRIG");
                    GPIB.Write("RESO:TRIG");
                    Thread.Sleep(500);

                    timerr1 = GPIB.ReadString();
                    string result1 = timerr1.Trim();
                    // string result1 = GPIB.ReadString();
                    // MessageBox.Show(result1);
                    if (result1.Length < 55)
                    {
                        result1 = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                    }

                    f = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(0, 14), @"\d+\.*\d+").Value) / 100000 - err_i), 2);
                    TB_i.Text = Convert.ToString(f);

                    q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(50, 12), @"\d+\.*\d+").Value) / 100000 - err_q), 1);
                    TB_q.Text = Convert.ToString(q);
                    rac = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(36, 14), @"\d+\.*\d+").Value) / 10000000 - err_rac), 1);
                    TB_Rac.Text = Convert.ToString(rac);
                    if ((f <= imax) && (f >= imin))
                    {
                        TB_pa1.Visible = true;
                        TB_pa1.Text = "PASS";
                        TB_pa1.BackColor = Color.Lime;
                        result[0] = 1;
                    }
                    else
                    {
                        TB_pa1.Visible = true;
                        TB_pa1.Text = "FAIL";
                        TB_pa1.BackColor = Color.Red;
                        result[0] = 0;
                    }
                    if ((rac <= racmax) && (rac >= racmin))
                    {
                        TB_pa3.Visible = true;
                        TB_pa3.Text = "PASS";
                        TB_pa3.BackColor = Color.Lime;
                        result[2] = 1;
                    }
                    else
                    {
                        TB_pa3.Visible = true;
                        TB_pa3.Text = "FAIL";
                        TB_pa3.BackColor = Color.Red;
                        result[2] = 0;
                    }
                    if ((q <= qmax) && (q >= qmin))
                    {
                        TB_pa2.Visible = true;
                        TB_pa2.Text = "PASS";
                        TB_pa2.BackColor = Color.Lime;
                        result[1] = 1;
                    }
                    else
                    {
                        TB_pa2.Visible = true;
                        TB_pa2.Text = "FAIL";
                        TB_pa2.BackColor = Color.Red;
                        result[1] = 0;
                    }

                }
                else if (testtu == "0")
                {

                    GPIB.Write("TRIG");
                    // GPIB.Write("RESO:TRIG");
                    Thread.Sleep(500);
                    timerr1 = GPIB.ReadString();
                    string result1 = timerr1.Trim();
                    // MessageBox.Show(result1);
                    i = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(0, 5), @"\d+\.*\d+").Value) - err_i), 2);

                    q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(result1.Length - 5, 5), @"\d+\.*\d+").Value) - err_q), 1);

                    if (i < 0 || q < 0)
                    {
                        TB_i.Text = "999999999";
                        TB_q.Text = "999999999";
                    }
                    TB_i.Text = Convert.ToString(i);

                    TB_q.Text = Convert.ToString(q);
                    if ((i <= imax) && (i >= imin))
                    {
                        TB_pa1.Visible = true;
                        TB_pa1.Text = "PASS";
                        TB_pa1.BackColor = Color.Lime;
                        result[0] = 1;
                    }
                    else
                    {
                        TB_pa1.Visible = true;
                        TB_pa1.Text = "FAIL";
                        TB_pa1.BackColor = Color.Red;
                        result[0] = 0;
                    }
                    if ((q <= qmax) && (q >= qmin))
                    {
                        TB_pa2.Visible = true;
                        TB_pa2.Text = "PASS";
                        TB_pa2.BackColor = Color.Lime;
                        result[1] = 1;
                    }
                    else
                    {
                        TB_pa2.Visible = true;
                        TB_pa2.Text = "FAIL";
                        TB_pa2.BackColor = Color.Red;
                        result[1] = 0;
                    }
                    result[2] = 1;
                }
                if (test_Z == "1")
                {
                    GPIB.Write("MEAS:FUNC:Z");
                    GPIB.Write("MEAS:FREQ 50");
                    System.Threading.Thread.Sleep(10);
                    GPIB.Write("TRIG");
                    System.Threading.Thread.Sleep(50);
                    timerr2 = GPIB.ReadString();

                    string result2 = timerr2.Trim();

                    rdc = Math.Round((Convert.ToDouble(Regex.Match(result2.Substring(0, 4), @"\d+\.*\d+").Value) - err_rdc), 1);

                    TB_rdc.Text = Convert.ToString(rdc);
                    if ((rdc <= rdcmax) && (rdc >= rdcmin))
                    {
                        TB_pa4.Visible = true;
                        TB_pa4.Text = "PASS";
                        TB_pa4.BackColor = Color.Lime;
                        result[3] = 1;
                    }
                    else
                    {
                        TB_pa4.Visible = true;
                        TB_pa4.Text = "FAIL";
                        TB_pa4.BackColor = Color.Red;
                        result[3] = 0;
                    }
                    if (testtu == "0")
                    {
                        GPIB.Write("MEAS");
                        GPIB.Write("MEAS:LEV 1V");
                        GPIB.Write("MEAS:FUNC:L;Q");
                        GPIB.Write("MEAS: FREQ 125000");
                    }
                    else if (testtu == "1")
                    {
                        GPIB.Write("RESO");
                        Thread.Sleep(100);
                        GPIB.Write("RESO:Start 100000");
                        Thread.Sleep(100);
                        GPIB.Write("RESO:Stop 150000");
                        Thread.Sleep(100);
                    }
                }
                else if (test_Z == "0")
                {
                    result[3] = 1;
                    
                }
            }
            else
            {
                TB_i.Clear();
                TB_q.Clear();
                TB_Rac.Clear();
                TB_rdc.Clear();
                

                if (nuu == true)
                {
                    txt_loi.Visible = true;                   
                    txt_loi.Text = "Chưa làm sạch sau đúc";
                    txt_loi.BackColor = Color.Red;
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    

                }
                if (chanpinn == false)
                {
                    txt_loi.Visible = true;
                    txt_loi.Text = "Dị vật trong chân pin";
                    txt_loi.BackColor = Color.Red;
                    result[0] = 0;
                    result[1] = 0;
                    result[2] = 0;
                    result[3] = 0;
                    
                }
            }
            connection.Close();
            ketqua();
        }
        private void ketqua()
        {
            if ((result[0] == 1) && (result[1] == 1) && (result[2] == 1) && (result[3] == 1))
            {
                txt_PASS.Visible = true;
                txt_PASS.Text = "PASS";
                txt_PASS.BackColor = Color.Lime;
                if (check_save.Checked == true)
                {
                    sum();
                    soluong = soluong + 1;
                    string nn = DateTime.Now.ToString("yyyy");
                    string nnn = "01-01-";
                    string name = nnn + "" + nn;

                    DateTime startdate = DateTime.Parse(name);
                    DateTime now = DateTime.Now;
                    TimeSpan songay = now.Subtract(startdate);
                    double sodate = songay.TotalDays, ngay = Convert.ToDouble(Convert.ToString(sodate).Substring(0, 3));
                    ngayy = string.Format("{0:000}", ngay + 1);
                    string number1 = string.Format("{0:0000}", soluong);
                    connection1.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection1;
                    if (testtu == "1")
                    {
                        command.CommandText = "INSERT INTO PAS([code],[dat],[tim],[number],[i],[q],[Rac],[result],[mae]) values('" + LOGIN.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + number1 + "','" + f + "','" + q + "','" + rac + "','" + txt_PASS.Text + "','" + timee + "')";
                    }
                    else if (testtu == "0" && test_Z == "1")
                    {
                        command.CommandText = "INSERT INTO PAS([code],[dat],[tim],[number],[i],[q],[r],[result],[mae]) values('" + LOGIN.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + number1 + "','" + i + "','" + q + "','" + rdc + "','" + txt_PASS.Text + "','" + timee + "')";


                    }
                    command.ExecuteNonQuery();
                    connection1.Close();
                    if (intem == "no")
                    {

                        OleDbCommand command12 = new OleDbCommand();
                        OleDbDataReader reader12;
                        connection3.Open();
                        command12.Connection = connection3;
                        command12.CommandText = "select * from produit where Code='" + LOGIN.code + "'";
                        reader12 = command12.ExecuteReader();
                        while (reader12.Read())
                        {

                            hkmcpn = reader12["HKMCPN"].ToString();
                            dstyle = reader12["Dstyle"].ToString();
                            symbol = reader12["Symbol"].ToString();

                        }
                        connection3.Close();
                        
                         Dstyle = DateTime.Now.ToString(dstyle);
                         path = "I:\\DATABASEline3\\LASER marking\\number.txt";
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile = new StreamWriter(fs, Encoding.ASCII);
                        writeFile.WriteLine(string.Format("{0:0000}", soluong));
                        writeFile.Close();

                         path1 = "I:\\DATABASEline3\\LASER marking\\date.txt";
                        FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile1 = new StreamWriter(fs1, Encoding.ASCII);
                        writeFile1.WriteLine(Dstyle);
                        writeFile1.Close();

                         path2 = "I:\\DATABASEline3\\LASER marking\\Partnumber.txt";
                        FileStream fs2 = new FileStream(path2, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile2 = new StreamWriter(fs2, Encoding.ASCII);
                        writeFile2.WriteLine(Parameter.Text);
                        writeFile2.Close();

                         path3 = "I:\\DATABASEline3\\LASER marking\\hkmcpn.txt";
                        FileStream fs3 = new FileStream(path3, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile3 = new StreamWriter(fs3, Encoding.ASCII);
                        writeFile3.WriteLine(hkmcpn);
                        writeFile3.Close();

                         path4 = "I:\\DATABASEline3\\LASER marking\\symbol.txt";
                        FileStream fs4 = new FileStream(path4, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile4 = new StreamWriter(fs4, Encoding.ASCII);
                        writeFile4.WriteLine(symbol);
                        writeFile4.Close();

                        if (LOGIN.Type == "DELPHI")
                        {
                            if (LOGIN.code == "X-12652-003")
                            {
                                try
                                {
                                    LASER_IN.Visible = true;
                                    laze = "41951" + DateTime.Now.ToString("yy") + "" + ngayy + symbol + string.Format("{0:0000}", soluong) + "";
                                    LASER_IN.Text = laze;
                                    pathdelphi = "I:\\DATABASEline3\\LASER marking\\lazedelphi.txt";
                                    FileStream fsdelphi = new FileStream(pathdelphi, FileMode.OpenOrCreate, FileAccess.Write);
                                    StreamWriter writeFile5 = new StreamWriter(fsdelphi, Encoding.ASCII);
                                    writeFile5.WriteLine(laze);
                                    writeFile5.Close();
                                }
                                catch 
                                {
                                    File.Delete(pathdelphi);
                                    throw;
                                }
                            }
                            if (LOGIN.code == "X-12652-018")
                            {
                                try
                                {
                                    LASER_IN.Visible = true;
                                    laze = "P10001577#28742206" + "T" + DateTime.Now.ToString("yyyyMMdd") + "" + string.Format("{000000}", soluong) + "V500979#U";
                                    LASER_IN.Text = laze;
                                    pathdelphi = "I:\\DATABASEline3\\LASER marking\\lazedelphi.txt";
                                    FileStream fsdelphi = new FileStream(pathdelphi, FileMode.OpenOrCreate, FileAccess.Write);
                                    StreamWriter writeFile5 = new StreamWriter(fsdelphi, Encoding.ASCII);
                                    writeFile5.WriteLine(laze);
                                    writeFile5.Close();
                                }
                                catch 
                                {
                                    File.Delete(pathdelphi);
                                    throw;
                                }
                               
                            }
                        }
                        if (plc.IsConnected)
                        {
                            btnlaser_on.PerformClick();
                            Thread.Sleep(50);
                            btnlaser_off.PerformClick();
                        }
                    }
                    status();
                }
                btn_start.Visible = false;
                timer_start.Enabled = false;
            }
            else
            {
                txt_PASS.Visible = true;
                txt_PASS.Text = "FAIL";
                txt_PASS.BackColor = Color.Red;
                if (check_save.Checked == true)
                {
                    connection1.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection1;
                    if (testtu == "1")
                    {

                        command.CommandText = "INSERT INTO FAI([code],[dat],[tim],[number],[i],[q],[Rac],[result],[mae]) values('" + LOGIN.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + "0" + "','" + f + "','" + q + "','" + rac + "','" + txt_PASS.Text + "','" + timee + "')";

                    }
                    else if (testtu == "0")
                    {
                        command.CommandText = "INSERT INTO FAI([code],[dat],[tim],[number],[i],[q],[r],[result],[mae]) values('" + LOGIN.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + "0" + "','" + i + "','" + q + "','" + rdc + "','" + txt_PASS.Text + "','" + timee + "')";
                    }
                    command.ExecuteNonQuery();
                    connection1.Close();
                    status();
                }
                
                btn_start.Enabled = false;
                timer_start.Enabled = false;
            }
        }

    }
}
