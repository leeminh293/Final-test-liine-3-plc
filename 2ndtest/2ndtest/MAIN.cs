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


namespace _2ndtest
{
    public partial class Main : Form
    {
        public static string testtu, intem, tanso1;
        string timee, timerr1, timerr2,datee,id, number1, number2;
        Plc plc = new Plc(CpuType.S71200, "192.168.0.5", 0, 0);
        private OleDbConnection connection = new OleDbConnection();
        private OleDbConnection connection1 = new OleDbConnection();
        private OleDbConnection connection2 = new OleDbConnection();
        private OleDbConnection connection3 = new OleDbConnection();

        private MessageBasedSession GPIB;
        double tanso, soluong = 0, idmax, freq  ;
        double imax, imin, qmin, qmax, imin64, imax64, i, q, rac, f, err_i, err_q, err_rac, racmin, racmax;
        string hkmc, dnke, pncode, filein, qrcode, hkmcpn, dstyle, dstyle1,symbol, link, symbol_label;
        private bool lazebtnclicked = false;

        #region cylinder
        private void button2_Click(object sender, EventArgs e)
        {
            plc.Write("Q0.0", 0);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plc.Write("Q0.0", 1);
           
        }
        #endregion
       

        private void timer_ngat_Tick(object sender, EventArgs e)
        {
           // object startt = plc.Read("I0.5");
           // start = Convert.ToBoolean(startt);
           
            if (start == false)
            {
                plc.Write("Q0.0", 0);
                start_timer.Enabled=true;
                btn_start.Enabled=true;
                btn_start.Visible=true;
                btn_confirm.Visible = false;
                
            }
        }

        private async void Date_timer_Tick_1(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        PrintDocument inn = new PrintDocument();
        Boolean start;
        BarTender.Application btApp;
        BarTender.Format btFormat;
        BarTender.Messages btMsgs;

        #region laser_button
        private void btnlaser_off_Click(object sender, EventArgs e)
        {
            lazebtnclicked = false;
           // plc.Open();
            if (plc.IsConnected)
            {                
                plc.Write("Q0.1", 0);
                
              //  plc.Close();

            }
        }

        private void btnlaser_on_Click(object sender, EventArgs e)
        {
            lazebtnclicked = true;
           // plc.Open();
            if (plc.IsConnected)
            {               
                plc.Write("Q0.1", 1);
               
               // plc.Close();

            }
        }
        #endregion

        int[] result = new int[3];
        
        private void btn_corrkotu_Click(object sender, EventArgs e)
        {
            Corelation1 fm2 = new Corelation1();
            fm2.ShowDialog();          
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            start_timer.Enabled = true;
            //plc.Open();
            if (plc.IsConnected)
            {
                plc.Write("Q0.0", 0);
                plc.Write("Q0.1", 0);
               // plc.Close();

            }
            btn_start.Visible = true;
            btn_start.Enabled = true;
            btn_confirm.Visible = false;
                                
        }

        public Main()
        {
            InitializeComponent();
            connection1.ConnectionString = connection1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline2nd\\data\\" + login.Type + "\\" + login.code + ".accdb';Persist Security Info=False;"; ;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline2nd\\OFFSET\\OFFSET.accdb';Persist Security Info=False;"; ;
            connection2.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline2nd\\Label2nd\\Labelprint.accdb';Persist Security Info=False;"; ;
            connection3.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Provider=Microsoft.ACE.OLEDB.12.0;Data Source='I:\\DATABASEline2nd\\LASER marking\\Lasermark.accdb';Persist Security Info=False;"; ;

        }
        #region Main_Load
        private void Main_Load(object sender, EventArgs e)
        {
            
            timer_den.Enabled = true;
            start_timer.Enabled=true;
            Date_timer.Enabled = true;     
          //  timer_ngat.Enabled = true;
            Date_timer.Start();
            lbl_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            btn_confirm.Visible = false;
            Parameters();
            GPIB = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::6::INSTR");
            GPIB.Write("*IDN?");
            if (testtu == "no")
            {
                GPIB.Write("MEAS");
                GPIB.Write("MEAS:LEV 1V");
                GPIB.Write("MEAS:FUNC:L;Q");
                GPIB.Write("MEAS: FREQ " + freq + "");
                lbl_Racmax.Visible = false;
                lbl_Racmin.Visible = false;
                label11.Visible = false;
                TB_Rac.Visible = false;
                TB_pa3.Visible = false;
                textBox20.Visible = false;
                label16.Visible = false;
                TB_Rac.Enabled = false;
                TB_pa3.Enabled = false;
                txt_donvido.Text = "µH";                             
            }
            if (testtu == "yes")
            {
                GPIB.Write("RESO");
                Thread.Sleep(100);
                GPIB.Write("RESO:Start 100000");
                Thread.Sleep(100);
                GPIB.Write("RESO:Stop 150000");
                Thread.Sleep(100);
                txt_donvido.Text = "KHZ";
            }
            if (intem == "yes")
            {
                grouplaser.Visible = false;
                grouplaser.Enabled = false;
                cb_printer.Items.Clear();
                string innhan = inn.PrinterSettings.PrinterName;
                foreach (string strprinte in PrinterSettings.InstalledPrinters)
                {
                    cb_printer.Items.Add(strprinte);
                    if (strprinte == innhan)
                    {
                        cb_printer.SelectedIndex = cb_printer.Items.IndexOf(strprinte);
                    }
                }
            }
            if (intem == "no")
            {
                grouplabel.Visible = false;
                grouplabel.Enabled = false;
            }
           // plc.Open();
            if (plc.IsConnected)
            {
                plc.Write("Q0.0", 0);
                plc.Write("Q0.1", 0);
              //  plc.Close();
            }
            sum();
            #region Date_printing styles
            string p = DateTime.Now.ToString("yyMMdd");
            cbb_date.Items.Add(p);
            cbb_date.Items.Add(DateTime.Now.ToString("ddMMyy"));
            cbb_date.Items.Add(DateTime.Now.ToString("yyyyMMdd"));
            cbb_date.Items.Add(DateTime.Now.ToString("ddMMyyyy"));
            cbb_date.Items.Add(DateTime.Now.ToString("yy/MM/dd"));           
            cbb_date.Items.Add(DateTime.Now.ToString("dd/MM/yy"));
            cbb_date.Items.Add(DateTime.Now.ToString("yyyy/MM/dd"));
            cbb_date.Items.Add(DateTime.Now.ToString("dd/MM/yyyy"));
            cbb_date.SelectedIndex = cbb_date.Items.IndexOf(p);
            #endregion

        }
        #endregion

        #region Parameters
        private void Parameters()
        {
            txt_PASS.Visible = false;   
            lbl_PN.Text = login.code;
            if (login.Type == "DENSO" || login.Type == "HKMC" || login.Type == "OTHERS")
            {
                lbl_PN.Text = login.code;
                btn_corr.Enabled = true;
                btn_corr.Visible = true;
                string a = login.Type;
                OleDbCommand command = new OleDbCommand();
                OleDbDataReader reader;
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from " + a + " where code='" + lbl_PN.Text + "'";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    intem = reader["intem"].ToString();
                    testtu = reader["test_tu"].ToString();
                    lbl_Lmin.Text = reader["imin"].ToString();
                    lbl_Lmax.Text = reader["imax"].ToString();
                    lbl_Qmin.Text = reader["qmin"].ToString();
                    lbl_Qmax.Text = reader["qmax"].ToString();
                    err_i = Convert.ToDouble(reader["err_i"].ToString());
                    err_q = Convert.ToDouble(reader["err_q"].ToString());

                    if (testtu == "yes")
                    {
                        lbl_Racmin.Text = reader["RACmin"].ToString();
                        lbl_Racmax.Text = reader["RACmax"].ToString();
                        racmin = Convert.ToDouble(lbl_Racmin.Text);
                        racmax = Convert.ToDouble(lbl_Racmax.Text);
                        err_rac = Convert.ToDouble(reader["err_rac"].ToString());
                    }
                    else if (testtu == "no")
                    {
                        tanso1 = reader["tanso"].ToString();
                    }
                    imin = Convert.ToDouble(lbl_Lmin.Text);
                    imax = Convert.ToDouble(lbl_Lmax.Text);
                    qmax = Convert.ToDouble(lbl_Qmax.Text);
                    qmin = Convert.ToDouble(lbl_Qmin.Text);
                    imax64 = imin + (imax - imin) * 0.7;
                    imin64 = imin + (imax - imin) * 0.3;
                    label2.Text = "Ind>" + Convert.ToString(imax) + "";
                    label3.Text = "" + Convert.ToString(imax64) + "<=Ind<=" + Convert.ToString(imax) + "";
                    label4.Text = "" + Convert.ToString(imin64) + "<=Ind<" + Convert.ToString(imax64) + "";
                    label5.Text = "" + Convert.ToString(imin) + "<=Ind<" + Convert.ToString(imin64) + "";
                    label6.Text = "Ind<" + Convert.ToString(imin) + "";
                }
                
                freq = Convert.ToDouble(tanso1);
                connection.Close();
            }
        }
        #endregion
        
        #region status
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
        #endregion

        #region print_label
        private void btn_print_Click(object sender, EventArgs e)
        {
            OleDbCommand command11 = new OleDbCommand();
            OleDbDataReader reader11;
            connection2.Open();
            command11.Connection = connection2;
            command11.CommandText = "select * from produit where Code='" + login.code + "'"; 
            reader11 = command11.ExecuteReader();
            while (reader11.Read())
            {
                pncode = reader11["Code"].ToString();
                hkmc = reader11["HKMC"].ToString();
                dnke = reader11["DNKE"].ToString();
                dstyle1 = reader11["Dstyles"].ToString();
                link = reader11["Links"].ToString();
                symbol_label = reader11["symbols"].ToString();
            }
            connection2.Close();
            
            number2 = string.Format("{0:000}", soluong);
            string Dstyles2 = DateTime.Now.ToString(dstyle1);
         
            qrcode = dnke + number2 + Dstyles2 + hkmc;
            //string fileName = @"I:\DATABASEline2nd\Label2nd\Chung.btw";
            string fileName = @link;
            BarTender.Application barTenderEngine = new BarTender.Application();
            var format = barTenderEngine.Formats.Open(fileName, true, cb_printer.Text);
            format.SetNamedSubStringValue("cpremo", pncode);
            format.SetNamedSubStringValue("HKMC", hkmc);
            format.SetNamedSubStringValue("DNKE", dnke);
            format.SetNamedSubStringValue("datee", Dstyles2);
            format.SetNamedSubStringValue("QRcode", qrcode);
            format.SetNamedSubStringValue("sym", symbol_label);
            format.PrintSetup.IdenticalCopiesOfLabel = 1;
            format.PrintOut(true, false);
            format.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
        }
        #endregion

        #region ketqua
        private void ketqua()
        {
            if ((result[0] == 1) && (result[1] == 1) && (result[2] == 1) )
            {
                txt_PASS.Visible = true;
                txt_PASS.Text = "PASS";
                txt_PASS.BackColor = Color.Lime;
                

                if (check_save.Checked == true)
                {
                    sum();
                    soluong = soluong + 1;
                    number1 = string.Format("{0:0000}", soluong);
                    string nn = DateTime.Now.ToString("yyyy");
                    string nnn = "01-01-";
                    string name = nnn + "" + nn;

                    DateTime startdate = DateTime.Parse(name);
                    DateTime now = DateTime.Now;
                    TimeSpan songay = now.Subtract(startdate);
                    double sodate = songay.TotalDays, ngay = Convert.ToDouble(Convert.ToString(sodate).Substring(0, 3));
                    string ngayy = string.Format("{0:000}", ngay + 1);
                    connection1.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection1;
                    if (testtu == "yes")
                    {
                        command.CommandText = "INSERT INTO PAS([code],[dat],[tim],[number],[i],[q],[Rac],[result],[mae]) values('" + login.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + number1 + "','" + f + "','" + q + "','" + rac + "','" + txt_PASS.Text + "','" + timee + "')";
                    }                    

                    else if (testtu == "no") 
                    {                       
                        command.CommandText = "INSERT INTO PAS([code],[dat],[tim],[number],[i],[q],[result],[mae]) values('" + login.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + number1 + "','" + i + "','" + q + "','" + txt_PASS.Text + "','" + timee + "')";                        
                    }
                    command.ExecuteNonQuery();
                    connection1.Close(); 
                   
                    if (intem == "no") 
                    {
                        OleDbCommand command12 = new OleDbCommand();
                        OleDbDataReader reader12;
                        connection3.Open();
                        command12.Connection = connection3;
                        command12.CommandText = "select * from produit where Code='" + login.code + "'";
                        reader12 = command12.ExecuteReader();
                        while (reader12.Read())
                        {
                            
                            hkmcpn = reader12["HKMCPN"].ToString();
                            dstyle = reader12["Dstyle"].ToString();
                            symbol = reader12["Symbol"].ToString();
                            
                        }
                        connection3.Close();
                        string Dstyle = DateTime.Now.ToString(dstyle);
                        string path = "I:\\DATABASEline2nd\\LASER marking\\number.txt";
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);                        
                        StreamWriter writeFile = new StreamWriter(fs, Encoding.UTF8);
                        writeFile.WriteLine(string.Format("{0:0000}", soluong));
                        writeFile.Close();

                        string path1 = "I:\\DATABASEline2nd\\LASER marking\\date.txt";
                        FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile1 = new StreamWriter(fs1, Encoding.UTF8);
                        writeFile1.WriteLine(Dstyle);
                        writeFile1.Close();

                        string path2 = "I:\\DATABASEline2nd\\LASER marking\\Partnumber.txt";
                        FileStream fs2 = new FileStream(path2, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile2 = new StreamWriter(fs2, Encoding.UTF8);
                        writeFile2.WriteLine(lbl_PN.Text);
                        writeFile2.Close();

                        string path3 = "I:\\DATABASEline2nd\\LASER marking\\hkmcpn.txt";
                        FileStream fs3 = new FileStream(path3, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile3 = new StreamWriter(fs3, Encoding.UTF8);
                        writeFile3.WriteLine(hkmcpn);
                        writeFile3.Close();

                        string path4 = "I:\\DATABASEline2nd\\LASER marking\\symbol.txt";
                        FileStream fs4 = new FileStream(path4, FileMode.Open, FileAccess.Write);
                        StreamWriter writeFile4 = new StreamWriter(fs4, Encoding.UTF8);
                        writeFile4.WriteLine(symbol);
                        writeFile4.Close();
                        //plc.Open();
                        if (plc.IsConnected)
                        {
                            btnlaser_on.PerformClick();
                            
                            Thread.Sleep(300);
                            btnlaser_off.PerformClick();                           
                          
                           
                        }
                        
                    }
                    else if (intem == "yes")
                    {
                        
                        btn_print.PerformClick();
                        
                    }
                    status();
                    
                }
                
                btn_start.Visible = true;
                start_timer.Enabled = false;

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
                    if (testtu == "yes")
                    {
                        
                         command.CommandText = "INSERT INTO FAI([code],[dat],[tim],[number],[i],[q],[Rac],[result],[mae]) values('" + login.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + "0" + "','" + f + "','" + q + "','" + rac + "','" + txt_PASS.Text + "','" + timee + "')"; 
                        
                    }
                    else if (testtu == "no")
                    {
                         command.CommandText = "INSERT INTO FAI([code],[dat],[tim],[number],[i],[q],[result],[mae]) values('" + login.code + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + "0" + "','" + i + "','" + q + "','" + txt_PASS.Text + "','" + timee + "')"; 
                    }
                    command.ExecuteNonQuery();
                    connection1.Close();
                    status();
                }
               btn_confirm.Visible = true;
                btn_start.Enabled = false;
                start_timer.Enabled = false;
            }
            

        }
        #endregion

        #region start
        private async void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Visible = true;
            btn_confirm.Visible=false;
           //lazeoff.BackColor = Color.White;
            start_timer.Enabled = false;
           // plc.Open();
            
            
            string a = login.Type;
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from " + a + " where code='" + lbl_PN.Text + "'";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                testtu = reader["test_tu"].ToString();
                err_i = Convert.ToDouble(reader["err_i"].ToString());
                err_q = Convert.ToDouble(reader["err_q"].ToString());
                if (testtu == "yes")
                {
                    err_rac = Convert.ToDouble(reader["err_rac"].ToString());
                }
                    
            }
            //connection.Close();
            timerr1 = "";
            if (testtu == "yes")
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
                rac = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(36, 14), @"\d+\.*\d+").Value)/ 10000000 - err_rac), 1);
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
            else if (testtu == "no")
            {

                GPIB.Write("TRIG");

                await Task.Delay(200);
                timerr1 = GPIB.ReadString();
                string result1 = timerr1.Trim();
               // MessageBox.Show(result1);
                i = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(0, 5), @"\d+\.*\d+").Value) - err_i), 2);
                //q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(9, 5), @"\d+\.*\d+").Value) - err_q), 2);
                q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(result1.Length - 5, 5), @"\d+\.*\d+").Value)), 1);

                if (i < 0 || q < 0)
                {
                    TB_i.Text = "999999999";
                    TB_q.Text = "999999999";
                }    
                TB_i.Text = Convert.ToString(i);
                //q = Math.Round((Convert.ToDouble(Regex.Match(result1.Substring(result1.Length - 6, 6), @"\d+\.*\d+").Value) - err_q), 1);
                //MessageBox.Show(result1);
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
           connection.Close();
            ketqua();
        }
        #endregion

        private void start_timer_Tick(object sender, EventArgs e)
        {
            //plc.Open();
        //    object startt = plc.Read("I0.5");
        //    start = Convert.ToBoolean(startt);
            if (start == true)
            {
                plc.Write("Q0.0", 1);
                btn_start.PerformClick();
                btn_start.Visible = false;
            }
            
        }

        private void Date_timer_Tick(object sender, EventArgs e)
        {
            
            
        }
        #region sum
        private void sum()
        {
            




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
                
                datee = reader1["dat"].ToString();
                if (datee != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    MessageBox.Show(Convert.ToString(soluong));
                    soluong = 0;
                }
                if (datee == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    string soluongstring = reader1["number"].ToString();
                    soluong = Convert.ToDouble(soluongstring);
                    
                }
               if (datee != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    MessageBox.Show(Convert.ToString(soluong));
                    soluong = 0;
                }
            }
            connection1.Close();

        }
        #endregion
    }
}
