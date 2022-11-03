namespace Finalline3_plc
{
    partial class Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.check_Z = new System.Windows.Forms.CheckBox();
            this.check_testtu = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.check_inlabel = new System.Windows.Forms.CheckBox();
            this.check_inlaze = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_start = new System.Windows.Forms.CheckBox();
            this.check_clip = new System.Windows.Forms.CheckBox();
            this.check_nu = new System.Windows.Forms.CheckBox();
            this.check_chanpin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_choose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkQ00 = new System.Windows.Forms.CheckBox();
            this.checkQ01 = new System.Windows.Forms.CheckBox();
            this.q01 = new System.Windows.Forms.PictureBox();
            this.q00 = new System.Windows.Forms.PictureBox();
            this.INPUT = new System.Windows.Forms.GroupBox();
            this.i0_2 = new System.Windows.Forms.Label();
            this.i0_1 = new System.Windows.Forms.Label();
            this.i0_0 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.i00 = new System.Windows.Forms.PictureBox();
            this.i02 = new System.Windows.Forms.PictureBox();
            this.i01 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_plc = new System.Windows.Forms.Button();
            this.timer_status = new System.Windows.Forms.Timer(this.components);
            this.timer_luupokayoke = new System.Windows.Forms.Timer(this.components);
            this.timer_print = new System.Windows.Forms.Timer(this.components);
            this.timer_testgiatri = new System.Windows.Forms.Timer(this.components);
            this.timer_plc = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.q01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.q00)).BeginInit();
            this.INPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.i00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.i02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.i01)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox4.Controls.Add(this.btn_save);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(560, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 482);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Condition";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Aqua;
            this.btn_save.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(118, 21);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(101, 42);
            this.btn_save.TabIndex = 21;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox3.Controls.Add(this.check_Z);
            this.groupBox3.Controls.Add(this.check_testtu);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(19, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 100);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test dien";
            // 
            // check_Z
            // 
            this.check_Z.AutoSize = true;
            this.check_Z.Location = new System.Drawing.Point(19, 32);
            this.check_Z.Name = "check_Z";
            this.check_Z.Size = new System.Drawing.Size(74, 23);
            this.check_Z.TabIndex = 12;
            this.check_Z.Text = "Test Z";
            this.check_Z.UseVisualStyleBackColor = true;
            // 
            // check_testtu
            // 
            this.check_testtu.AutoSize = true;
            this.check_testtu.Location = new System.Drawing.Point(19, 62);
            this.check_testtu.Name = "check_testtu";
            this.check_testtu.Size = new System.Drawing.Size(79, 23);
            this.check_testtu.TabIndex = 13;
            this.check_testtu.Text = "Test tu";
            this.check_testtu.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "label7";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.check_inlabel);
            this.groupBox1.Controls.Add(this.check_inlaze);
            this.groupBox1.Location = new System.Drawing.Point(19, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kieu in";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // check_inlabel
            // 
            this.check_inlabel.AutoSize = true;
            this.check_inlabel.Location = new System.Drawing.Point(19, 32);
            this.check_inlabel.Name = "check_inlabel";
            this.check_inlabel.Size = new System.Drawing.Size(112, 23);
            this.check_inlabel.TabIndex = 16;
            this.check_inlabel.Text = "Print label";
            this.check_inlabel.UseVisualStyleBackColor = true;
            // 
            // check_inlaze
            // 
            this.check_inlaze.AutoSize = true;
            this.check_inlaze.Location = new System.Drawing.Point(19, 58);
            this.check_inlaze.Name = "check_inlaze";
            this.check_inlaze.Size = new System.Drawing.Size(140, 23);
            this.check_inlaze.TabIndex = 17;
            this.check_inlaze.Text = "Laser marking";
            this.check_inlaze.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Ivory;
            this.groupBox2.Controls.Add(this.check_start);
            this.groupBox2.Controls.Add(this.check_clip);
            this.groupBox2.Controls.Add(this.check_nu);
            this.groupBox2.Controls.Add(this.check_chanpin);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(19, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 166);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pokayoke";
            // 
            // check_start
            // 
            this.check_start.AutoSize = true;
            this.check_start.Location = new System.Drawing.Point(19, 34);
            this.check_start.Name = "check_start";
            this.check_start.Size = new System.Drawing.Size(68, 23);
            this.check_start.TabIndex = 2;
            this.check_start.Text = "Start";
            this.check_start.UseVisualStyleBackColor = true;
            // 
            // check_clip
            // 
            this.check_clip.AutoSize = true;
            this.check_clip.Location = new System.Drawing.Point(19, 60);
            this.check_clip.Name = "check_clip";
            this.check_clip.Size = new System.Drawing.Size(64, 23);
            this.check_clip.TabIndex = 3;
            this.check_clip.Text = "Clip";
            this.check_clip.UseVisualStyleBackColor = true;
            // 
            // check_nu
            // 
            this.check_nu.AutoSize = true;
            this.check_nu.Location = new System.Drawing.Point(19, 89);
            this.check_nu.Name = "check_nu";
            this.check_nu.Size = new System.Drawing.Size(79, 23);
            this.check_nu.TabIndex = 5;
            this.check_nu.Text = "Bat nu";
            this.check_nu.UseVisualStyleBackColor = true;
            // 
            // check_chanpin
            // 
            this.check_chanpin.AutoSize = true;
            this.check_chanpin.Location = new System.Drawing.Point(19, 118);
            this.check_chanpin.Name = "check_chanpin";
            this.check_chanpin.Size = new System.Drawing.Size(97, 23);
            this.check_chanpin.TabIndex = 6;
            this.check_chanpin.Text = "Chan pin";
            this.check_chanpin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "label4";
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_choose.Location = new System.Drawing.Point(443, 34);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(98, 55);
            this.btn_choose.TabIndex = 27;
            this.btn_choose.Text = "Choose condition";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.INPUT);
            this.groupBox5.Controls.Add(this.btn_plc);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(43, 34);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(367, 482);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Check PLC";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(227, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 19);
            this.label18.TabIndex = 39;
            this.label18.Text = "Di vat chan pin";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(229, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 19);
            this.label17.TabIndex = 38;
            this.label17.Text = "Bat nu";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(227, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 19);
            this.label16.TabIndex = 37;
            this.label16.Text = "Start";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.checkQ00);
            this.groupBox7.Controls.Add(this.checkQ01);
            this.groupBox7.Controls.Add(this.q01);
            this.groupBox7.Controls.Add(this.q00);
            this.groupBox7.Location = new System.Drawing.Point(23, 235);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(298, 154);
            this.groupBox7.TabIndex = 36;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "OUTPUT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(194, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 19);
            this.label15.TabIndex = 36;
            this.label15.Text = "Laser mark";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(194, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 19);
            this.label14.TabIndex = 35;
            this.label14.Text = "Cylinder";
            // 
            // checkQ00
            // 
            this.checkQ00.AutoSize = true;
            this.checkQ00.Location = new System.Drawing.Point(16, 36);
            this.checkQ00.Name = "checkQ00";
            this.checkQ00.Size = new System.Drawing.Size(66, 23);
            this.checkQ00.TabIndex = 27;
            this.checkQ00.Text = "Q0.0";
            this.checkQ00.UseVisualStyleBackColor = true;
            // 
            // checkQ01
            // 
            this.checkQ01.AutoSize = true;
            this.checkQ01.Location = new System.Drawing.Point(16, 104);
            this.checkQ01.Name = "checkQ01";
            this.checkQ01.Size = new System.Drawing.Size(66, 23);
            this.checkQ01.TabIndex = 28;
            this.checkQ01.Text = "Q0.1";
            this.checkQ01.UseVisualStyleBackColor = true;
            // 
            // q01
            // 
            this.q01.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("q01.BackgroundImage")));
            this.q01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.q01.Location = new System.Drawing.Point(133, 85);
            this.q01.Name = "q01";
            this.q01.Size = new System.Drawing.Size(48, 50);
            this.q01.TabIndex = 34;
            this.q01.TabStop = false;
            // 
            // q00
            // 
            this.q00.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("q00.BackgroundImage")));
            this.q00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.q00.Location = new System.Drawing.Point(133, 21);
            this.q00.Name = "q00";
            this.q00.Size = new System.Drawing.Size(48, 50);
            this.q00.TabIndex = 33;
            this.q00.TabStop = false;
            // 
            // INPUT
            // 
            this.INPUT.Controls.Add(this.i0_2);
            this.INPUT.Controls.Add(this.i0_1);
            this.INPUT.Controls.Add(this.i0_0);
            this.INPUT.Controls.Add(this.label10);
            this.INPUT.Controls.Add(this.label11);
            this.INPUT.Controls.Add(this.i00);
            this.INPUT.Controls.Add(this.i02);
            this.INPUT.Controls.Add(this.i01);
            this.INPUT.Controls.Add(this.label12);
            this.INPUT.Location = new System.Drawing.Point(21, 26);
            this.INPUT.Name = "INPUT";
            this.INPUT.Size = new System.Drawing.Size(200, 203);
            this.INPUT.TabIndex = 35;
            this.INPUT.TabStop = false;
            this.INPUT.Text = "INPUT";
            // 
            // i0_2
            // 
            this.i0_2.AutoSize = true;
            this.i0_2.Location = new System.Drawing.Point(74, 146);
            this.i0_2.Name = "i0_2";
            this.i0_2.Size = new System.Drawing.Size(37, 19);
            this.i0_2.TabIndex = 35;
            this.i0_2.Text = "I0.2";
            // 
            // i0_1
            // 
            this.i0_1.AutoSize = true;
            this.i0_1.Location = new System.Drawing.Point(74, 88);
            this.i0_1.Name = "i0_1";
            this.i0_1.Size = new System.Drawing.Size(37, 19);
            this.i0_1.TabIndex = 34;
            this.i0_1.Text = "I0.1";
            // 
            // i0_0
            // 
            this.i0_0.AutoSize = true;
            this.i0_0.Location = new System.Drawing.Point(74, 30);
            this.i0_0.Name = "i0_0";
            this.i0_0.Size = new System.Drawing.Size(37, 19);
            this.i0_0.TabIndex = 33;
            this.i0_0.Text = "I0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "I0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "I0.1";
            // 
            // i00
            // 
            this.i00.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("i00.BackgroundImage")));
            this.i00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.i00.Location = new System.Drawing.Point(133, 21);
            this.i00.Name = "i00";
            this.i00.Size = new System.Drawing.Size(48, 50);
            this.i00.TabIndex = 29;
            this.i00.TabStop = false;
            // 
            // i02
            // 
            this.i02.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("i02.BackgroundImage")));
            this.i02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.i02.Location = new System.Drawing.Point(133, 131);
            this.i02.Name = "i02";
            this.i02.Size = new System.Drawing.Size(48, 50);
            this.i02.TabIndex = 31;
            this.i02.TabStop = false;
            // 
            // i01
            // 
            this.i01.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("i01.BackgroundImage")));
            this.i01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.i01.Location = new System.Drawing.Point(133, 75);
            this.i01.Name = "i01";
            this.i01.Size = new System.Drawing.Size(48, 50);
            this.i01.TabIndex = 30;
            this.i01.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 19);
            this.label12.TabIndex = 25;
            this.label12.Text = "I0.2";
            // 
            // btn_plc
            // 
            this.btn_plc.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_plc.Location = new System.Drawing.Point(39, 405);
            this.btn_plc.Name = "btn_plc";
            this.btn_plc.Size = new System.Drawing.Size(182, 53);
            this.btn_plc.TabIndex = 22;
            this.btn_plc.Text = "Connect to plc";
            this.btn_plc.UseVisualStyleBackColor = false;
            this.btn_plc.Click += new System.EventHandler(this.btn_plc_Click);
            // 
            // timer_status
            // 
            this.timer_status.Tick += new System.EventHandler(this.timer_status_Tick);
            // 
            // timer_luupokayoke
            // 
            this.timer_luupokayoke.Tick += new System.EventHandler(this.timer_luupokayoke_Tick);
            // 
            // timer_print
            // 
            this.timer_print.Tick += new System.EventHandler(this.timer_print_Tick);
            // 
            // timer_testgiatri
            // 
            this.timer_testgiatri.Tick += new System.EventHandler(this.timer_testgiatri_Tick);
            // 
            // timer_plc
            // 
            this.timer_plc.Tick += new System.EventHandler(this.timer_plc_Tick);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(862, 544);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.groupBox4);
            this.Name = "Setup";
            this.Text = "Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setup_FormClosed);
            this.Load += new System.EventHandler(this.Setup_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.q01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.q00)).EndInit();
            this.INPUT.ResumeLayout(false);
            this.INPUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.i00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.i02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.i01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox check_Z;
        private System.Windows.Forms.CheckBox check_testtu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox check_inlabel;
        private System.Windows.Forms.CheckBox check_inlaze;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox check_start;
        private System.Windows.Forms.CheckBox check_clip;
        private System.Windows.Forms.CheckBox check_nu;
        private System.Windows.Forms.CheckBox check_chanpin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkQ00;
        private System.Windows.Forms.CheckBox checkQ01;
        private System.Windows.Forms.PictureBox q01;
        private System.Windows.Forms.PictureBox q00;
        private System.Windows.Forms.GroupBox INPUT;
        private System.Windows.Forms.Label i0_2;
        private System.Windows.Forms.Label i0_1;
        private System.Windows.Forms.Label i0_0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox i00;
        private System.Windows.Forms.PictureBox i02;
        private System.Windows.Forms.PictureBox i01;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_plc;
        private System.Windows.Forms.Timer timer_status;
        private System.Windows.Forms.Timer timer_luupokayoke;
        private System.Windows.Forms.Timer timer_print;
        private System.Windows.Forms.Timer timer_testgiatri;
        private System.Windows.Forms.Timer timer_plc;
    }
}