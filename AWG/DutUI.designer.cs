//namespace AwgConfig
namespace AwgTestFramework
{
    partial class dutui
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.writetofile = new System.Windows.Forms.Button();
            this.dut1ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.awg1contype = new System.Windows.Forms.ComboBox();
            this.timeout = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1controller = new System.Windows.Forms.CheckBox();
            this.DUT1_Name = new System.Windows.Forms.RadioButton();
            this.DUT1_IP = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.dut1name = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.scopename = new System.Windows.Forms.ComboBox();
            this.SCOPE_NAME = new System.Windows.Forms.RadioButton();
            this.SCOPE_IP = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scopeip = new System.Windows.Forms.TextBox();
            this.scopecontype = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DUT2_Name = new System.Windows.Forms.RadioButton();
            this.DUT2_IP = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dut2name = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dut2ip = new System.Windows.Forms.TextBox();
            this.awg3contype = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DUT3_Name = new System.Windows.Forms.RadioButton();
            this.DUT3_IP = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dut3name = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dut3ip = new System.Windows.Forms.TextBox();
            this.awg2contype = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DUT4_Name = new System.Windows.Forms.RadioButton();
            this.DUT4_IP = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dut4name = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dut4ip = new System.Windows.Forms.TextBox();
            this.awg4contype = new System.Windows.Forms.ComboBox();
            this.PCAppConfig = new System.Windows.Forms.RadioButton();
            this.PBUApp = new System.Windows.Forms.RadioButton();
            this.save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.extsourcename = new System.Windows.Forms.ComboBox();
            this.EXTSOURCE_NAME = new System.Windows.Forms.RadioButton();
            this.EXTSOURCE_IP = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.extsourceip = new System.Windows.Forms.TextBox();
            this.extsourcecontype = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.PIOnly = new System.Windows.Forms.CheckBox();
            this.PiOnlyHandle = new System.Windows.Forms.Label();
            this.SourceXpress = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // writetofile
            // 
            this.writetofile.Location = new System.Drawing.Point(466, 523);
            this.writetofile.Name = "writetofile";
            this.writetofile.Size = new System.Drawing.Size(132, 23);
            this.writetofile.TabIndex = 0;
            this.writetofile.Text = "Start Test";
            this.writetofile.UseVisualStyleBackColor = true;
            this.writetofile.Click += new System.EventHandler(this.writetofile_Click);
            // 
            // dut1ip
            // 
            this.dut1ip.Location = new System.Drawing.Point(111, 105);
            this.dut1ip.Name = "dut1ip";
            this.dut1ip.Size = new System.Drawing.Size(150, 20);
            this.dut1ip.TabIndex = 1;
            this.dut1ip.Text = "134.64.236.32";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DUT IP";
            // 
            // awg1contype
            // 
            this.awg1contype.FormattingEnabled = true;
            this.awg1contype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.awg1contype.Location = new System.Drawing.Point(111, 139);
            this.awg1contype.Name = "awg1contype";
            this.awg1contype.Size = new System.Drawing.Size(150, 21);
            this.awg1contype.TabIndex = 3;
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(144, 526);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(116, 20);
            this.timeout.TabIndex = 4;
            this.timeout.Text = "30";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CON TYPE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(34, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "AWG Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1controller);
            this.groupBox1.Controls.Add(this.DUT1_Name);
            this.groupBox1.Controls.Add(this.DUT1_IP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dut1name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dut1ip);
            this.groupBox1.Controls.Add(this.awg1contype);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(33, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 183);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AWG1";
            // 
            // checkBox1controller
            // 
            this.checkBox1controller.AutoSize = true;
            this.checkBox1controller.Location = new System.Drawing.Point(111, 9);
            this.checkBox1controller.Name = "checkBox1controller";
            this.checkBox1controller.Size = new System.Drawing.Size(80, 17);
            this.checkBox1controller.TabIndex = 15;
            this.checkBox1controller.Text = "Controller";
            this.checkBox1controller.UseVisualStyleBackColor = true;
            this.checkBox1controller.Click += new System.EventHandler(this.checkBox1controller_Click);
            // 
            // DUT1_Name
            // 
            this.DUT1_Name.AutoSize = true;
            this.DUT1_Name.Location = new System.Drawing.Point(139, 28);
            this.DUT1_Name.Name = "DUT1_Name";
            this.DUT1_Name.Size = new System.Drawing.Size(90, 17);
            this.DUT1_Name.TabIndex = 14;
            this.DUT1_Name.TabStop = true;
            this.DUT1_Name.Text = "AWG Name";
            this.DUT1_Name.UseVisualStyleBackColor = true;
            this.DUT1_Name.Click += new System.EventHandler(this.DUT1_Name_Click);
            // 
            // DUT1_IP
            // 
            this.DUT1_IP.AutoSize = true;
            this.DUT1_IP.Location = new System.Drawing.Point(19, 28);
            this.DUT1_IP.Name = "DUT1_IP";
            this.DUT1_IP.Size = new System.Drawing.Size(86, 17);
            this.DUT1_IP.TabIndex = 13;
            this.DUT1_IP.TabStop = true;
            this.DUT1_IP.Text = "IP Address";
            this.DUT1_IP.UseVisualStyleBackColor = true;
            this.DUT1_IP.Click += new System.EventHandler(this.DUT1_IP_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(16, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "DUT Name";
            // 
            // dut1name
            // 
            this.dut1name.FormattingEnabled = true;
            this.dut1name.Items.AddRange(new object[] {
            "AWG7122CQ010004",
            "AWG7122CQ020004",
            "AWG7122CQ030004",
            "AWG7122CQ040004",
            "AWG1-SSPL-LAB"});
            this.dut1name.Location = new System.Drawing.Point(111, 69);
            this.dut1name.Name = "dut1name";
            this.dut1name.Size = new System.Drawing.Size(150, 21);
            this.dut1name.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.scopename);
            this.groupBox2.Controls.Add(this.SCOPE_NAME);
            this.groupBox2.Controls.Add(this.SCOPE_IP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.scopeip);
            this.groupBox2.Controls.Add(this.scopecontype);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(679, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 172);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scope";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(18, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "SCOPE Name";
            // 
            // scopename
            // 
            this.scopename.FormattingEnabled = true;
            this.scopename.Items.AddRange(new object[] {
            "TEKSCOPE-F181A7",
            "DPO70K-SAPL-LAB",
            ""});
            this.scopename.Location = new System.Drawing.Point(113, 58);
            this.scopename.Name = "scopename";
            this.scopename.Size = new System.Drawing.Size(150, 21);
            this.scopename.TabIndex = 19;
            // 
            // SCOPE_NAME
            // 
            this.SCOPE_NAME.AutoSize = true;
            this.SCOPE_NAME.Location = new System.Drawing.Point(131, 24);
            this.SCOPE_NAME.Name = "SCOPE_NAME";
            this.SCOPE_NAME.Size = new System.Drawing.Size(97, 17);
            this.SCOPE_NAME.TabIndex = 18;
            this.SCOPE_NAME.TabStop = true;
            this.SCOPE_NAME.Text = "Scope Name";
            this.SCOPE_NAME.UseVisualStyleBackColor = true;
            this.SCOPE_NAME.CheckedChanged += new System.EventHandler(this.SCOPE_NAME_CheckedChanged);
            // 
            // SCOPE_IP
            // 
            this.SCOPE_IP.AutoSize = true;
            this.SCOPE_IP.Location = new System.Drawing.Point(11, 24);
            this.SCOPE_IP.Name = "SCOPE_IP";
            this.SCOPE_IP.Size = new System.Drawing.Size(86, 17);
            this.SCOPE_IP.TabIndex = 17;
            this.SCOPE_IP.TabStop = true;
            this.SCOPE_IP.Text = "IP Address";
            this.SCOPE_IP.UseVisualStyleBackColor = true;
            this.SCOPE_IP.CheckedChanged += new System.EventHandler(this.SCOPE_IP_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "SCOPE IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "CON TYPE";
            // 
            // scopeip
            // 
            this.scopeip.Location = new System.Drawing.Point(111, 91);
            this.scopeip.Name = "scopeip";
            this.scopeip.Size = new System.Drawing.Size(150, 20);
            this.scopeip.TabIndex = 1;
            this.scopeip.Text = "134.64.236.75";
            // 
            // scopecontype
            // 
            this.scopecontype.FormattingEnabled = true;
            this.scopecontype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.scopecontype.Location = new System.Drawing.Point(111, 125);
            this.scopecontype.Name = "scopecontype";
            this.scopecontype.Size = new System.Drawing.Size(150, 21);
            this.scopecontype.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(676, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Scope Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 526);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Timeout Value\r\n";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DUT2_Name);
            this.groupBox3.Controls.Add(this.DUT2_IP);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dut2name);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.dut2ip);
            this.groupBox3.Controls.Add(this.awg3contype);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(337, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 183);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AWG2";
            // 
            // DUT2_Name
            // 
            this.DUT2_Name.AutoSize = true;
            this.DUT2_Name.Location = new System.Drawing.Point(138, 26);
            this.DUT2_Name.Name = "DUT2_Name";
            this.DUT2_Name.Size = new System.Drawing.Size(90, 17);
            this.DUT2_Name.TabIndex = 16;
            this.DUT2_Name.TabStop = true;
            this.DUT2_Name.Text = "AWG Name";
            this.DUT2_Name.UseVisualStyleBackColor = true;
            this.DUT2_Name.Click += new System.EventHandler(this.DUT2_Name_Click);
            // 
            // DUT2_IP
            // 
            this.DUT2_IP.AutoSize = true;
            this.DUT2_IP.Location = new System.Drawing.Point(18, 26);
            this.DUT2_IP.Name = "DUT2_IP";
            this.DUT2_IP.Size = new System.Drawing.Size(86, 17);
            this.DUT2_IP.TabIndex = 15;
            this.DUT2_IP.TabStop = true;
            this.DUT2_IP.Text = "IP Address";
            this.DUT2_IP.UseVisualStyleBackColor = true;
            this.DUT2_IP.Click += new System.EventHandler(this.DUT2_IP_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(16, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "DUT Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "DUT IP";
            // 
            // dut2name
            // 
            this.dut2name.FormattingEnabled = true;
            this.dut2name.Items.AddRange(new object[] {
            "TEKSCOPE-F181A7",
            "AWG7122CQ010004",
            "AWG7122CQ020004",
            "AWG7122CQ030004",
            "AWG7122CQ040004"});
            this.dut2name.Location = new System.Drawing.Point(111, 69);
            this.dut2name.Name = "dut2name";
            this.dut2name.Size = new System.Drawing.Size(150, 21);
            this.dut2name.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "CON TYPE";
            // 
            // dut2ip
            // 
            this.dut2ip.Location = new System.Drawing.Point(111, 105);
            this.dut2ip.Name = "dut2ip";
            this.dut2ip.Size = new System.Drawing.Size(150, 20);
            this.dut2ip.TabIndex = 1;
            this.dut2ip.Text = "134.64.236.32";
            // 
            // awg3contype
            // 
            this.awg3contype.FormattingEnabled = true;
            this.awg3contype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.awg3contype.Location = new System.Drawing.Point(111, 139);
            this.awg3contype.Name = "awg3contype";
            this.awg3contype.Size = new System.Drawing.Size(150, 21);
            this.awg3contype.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DUT3_Name);
            this.groupBox4.Controls.Add(this.DUT3_IP);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.dut3name);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.dut3ip);
            this.groupBox4.Controls.Add(this.awg2contype);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox4.Location = new System.Drawing.Point(33, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 172);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AWG3";
            // 
            // DUT3_Name
            // 
            this.DUT3_Name.AutoSize = true;
            this.DUT3_Name.Location = new System.Drawing.Point(139, 31);
            this.DUT3_Name.Name = "DUT3_Name";
            this.DUT3_Name.Size = new System.Drawing.Size(90, 17);
            this.DUT3_Name.TabIndex = 16;
            this.DUT3_Name.TabStop = true;
            this.DUT3_Name.Text = "AWG Name";
            this.DUT3_Name.UseVisualStyleBackColor = true;
            this.DUT3_Name.Click += new System.EventHandler(this.DUT3_Name_Click);
            // 
            // DUT3_IP
            // 
            this.DUT3_IP.AutoSize = true;
            this.DUT3_IP.Location = new System.Drawing.Point(19, 31);
            this.DUT3_IP.Name = "DUT3_IP";
            this.DUT3_IP.Size = new System.Drawing.Size(86, 17);
            this.DUT3_IP.TabIndex = 15;
            this.DUT3_IP.TabStop = true;
            this.DUT3_IP.Text = "IP Address";
            this.DUT3_IP.UseVisualStyleBackColor = true;
            this.DUT3_IP.Click += new System.EventHandler(this.DUT3_IP_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(16, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "DUT Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "DUT IP";
            // 
            // dut3name
            // 
            this.dut3name.FormattingEnabled = true;
            this.dut3name.Items.AddRange(new object[] {
            "AWG7122CQ010004",
            "AWG7122CQ020004",
            "AWG7122CQ030004",
            "AWG7122CQ040004"});
            this.dut3name.Location = new System.Drawing.Point(111, 61);
            this.dut3name.Name = "dut3name";
            this.dut3name.Size = new System.Drawing.Size(150, 21);
            this.dut3name.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "CON TYPE";
            // 
            // dut3ip
            // 
            this.dut3ip.AutoCompleteCustomSource.AddRange(new string[] {
            "AWG7122CQ010004"});
            this.dut3ip.Location = new System.Drawing.Point(111, 97);
            this.dut3ip.Name = "dut3ip";
            this.dut3ip.Size = new System.Drawing.Size(150, 20);
            this.dut3ip.TabIndex = 1;
            this.dut3ip.Text = "134.64.236.32";
            // 
            // awg2contype
            // 
            this.awg2contype.FormattingEnabled = true;
            this.awg2contype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.awg2contype.Location = new System.Drawing.Point(111, 131);
            this.awg2contype.Name = "awg2contype";
            this.awg2contype.Size = new System.Drawing.Size(150, 21);
            this.awg2contype.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DUT4_Name);
            this.groupBox5.Controls.Add(this.DUT4_IP);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.dut4name);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.dut4ip);
            this.groupBox5.Controls.Add(this.awg4contype);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox5.Location = new System.Drawing.Point(337, 300);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 172);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AWG4";
            // 
            // DUT4_Name
            // 
            this.DUT4_Name.AutoSize = true;
            this.DUT4_Name.Location = new System.Drawing.Point(137, 26);
            this.DUT4_Name.Name = "DUT4_Name";
            this.DUT4_Name.Size = new System.Drawing.Size(90, 17);
            this.DUT4_Name.TabIndex = 18;
            this.DUT4_Name.TabStop = true;
            this.DUT4_Name.Text = "AWG Name";
            this.DUT4_Name.UseVisualStyleBackColor = true;
            this.DUT4_Name.Click += new System.EventHandler(this.DUT4_Name_Click);
            // 
            // DUT4_IP
            // 
            this.DUT4_IP.AutoSize = true;
            this.DUT4_IP.Location = new System.Drawing.Point(17, 26);
            this.DUT4_IP.Name = "DUT4_IP";
            this.DUT4_IP.Size = new System.Drawing.Size(86, 17);
            this.DUT4_IP.TabIndex = 17;
            this.DUT4_IP.TabStop = true;
            this.DUT4_IP.Text = "IP Address";
            this.DUT4_IP.UseVisualStyleBackColor = true;
            this.DUT4_IP.Click += new System.EventHandler(this.DUT4_IP_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(16, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "DUT Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "DUT IP";
            // 
            // dut4name
            // 
            this.dut4name.FormattingEnabled = true;
            this.dut4name.Items.AddRange(new object[] {
            "AWG7122CQ010004",
            "AWG7122CQ020004",
            "AWG7122CQ030004",
            "AWG7122CQ040004"});
            this.dut4name.Location = new System.Drawing.Point(111, 57);
            this.dut4name.Name = "dut4name";
            this.dut4name.Size = new System.Drawing.Size(150, 21);
            this.dut4name.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "CON TYPE";
            // 
            // dut4ip
            // 
            this.dut4ip.AutoCompleteCustomSource.AddRange(new string[] {
            "AWG7122CQ010004"});
            this.dut4ip.Location = new System.Drawing.Point(111, 93);
            this.dut4ip.Name = "dut4ip";
            this.dut4ip.Size = new System.Drawing.Size(150, 20);
            this.dut4ip.TabIndex = 1;
            this.dut4ip.Text = "134.64.236.32";
            // 
            // awg4contype
            // 
            this.awg4contype.FormattingEnabled = true;
            this.awg4contype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.awg4contype.Location = new System.Drawing.Point(111, 127);
            this.awg4contype.Name = "awg4contype";
            this.awg4contype.Size = new System.Drawing.Size(150, 21);
            this.awg4contype.TabIndex = 3;
            // 
            // PCAppConfig
            // 
            this.PCAppConfig.AutoSize = true;
            this.PCAppConfig.Location = new System.Drawing.Point(172, 24);
            this.PCAppConfig.Name = "PCAppConfig";
            this.PCAppConfig.Size = new System.Drawing.Size(67, 17);
            this.PCAppConfig.TabIndex = 14;
            this.PCAppConfig.TabStop = true;
            this.PCAppConfig.Text = "PC App";
            this.PCAppConfig.UseVisualStyleBackColor = true;
            this.PCAppConfig.Click += new System.EventHandler(this.PCAppConfig_Click);
            // 
            // PBUApp
            // 
            this.PBUApp.AutoSize = true;
            this.PBUApp.Location = new System.Drawing.Point(288, 24);
            this.PBUApp.Name = "PBUApp";
            this.PBUApp.Size = new System.Drawing.Size(76, 17);
            this.PBUApp.TabIndex = 15;
            this.PBUApp.TabStop = true;
            this.PBUApp.Text = "PBU App";
            this.PBUApp.UseVisualStyleBackColor = true;
            this.PBUApp.Click += new System.EventHandler(this.PBUApp_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(327, 524);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(113, 23);
            this.save.TabIndex = 16;
            this.save.Text = "Save Settings";
            this.save.UseVisualStyleBackColor = true;
            this.save.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Cancel ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.extsourcename);
            this.groupBox6.Controls.Add(this.EXTSOURCE_NAME);
            this.groupBox6.Controls.Add(this.EXTSOURCE_IP);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.extsourceip);
            this.groupBox6.Controls.Add(this.extsourcecontype);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox6.Location = new System.Drawing.Point(679, 300);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(286, 172);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "External Source";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label19.Location = new System.Drawing.Point(17, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "EXT SRC Name";
            // 
            // extsourcename
            // 
            this.extsourcename.FormattingEnabled = true;
            this.extsourcename.Items.AddRange(new object[] {
            "TEKSCOPE-F181A7",
            "DPO70K-SAPL-LAB",
            ""});
            this.extsourcename.Location = new System.Drawing.Point(111, 60);
            this.extsourcename.Name = "extsourcename";
            this.extsourcename.Size = new System.Drawing.Size(150, 21);
            this.extsourcename.TabIndex = 19;
            // 
            // EXTSOURCE_NAME
            // 
            this.EXTSOURCE_NAME.AutoSize = true;
            this.EXTSOURCE_NAME.Location = new System.Drawing.Point(131, 24);
            this.EXTSOURCE_NAME.Name = "EXTSOURCE_NAME";
            this.EXTSOURCE_NAME.Size = new System.Drawing.Size(123, 17);
            this.EXTSOURCE_NAME.TabIndex = 18;
            this.EXTSOURCE_NAME.TabStop = true;
            this.EXTSOURCE_NAME.Text = "Ext Source Name";
            this.EXTSOURCE_NAME.UseVisualStyleBackColor = true;
            this.EXTSOURCE_NAME.CheckedChanged += new System.EventHandler(this.EXTSOURCE_NAME_CheckedChanged);
            // 
            // EXTSOURCE_IP
            // 
            this.EXTSOURCE_IP.AutoSize = true;
            this.EXTSOURCE_IP.Location = new System.Drawing.Point(11, 24);
            this.EXTSOURCE_IP.Name = "EXTSOURCE_IP";
            this.EXTSOURCE_IP.Size = new System.Drawing.Size(86, 17);
            this.EXTSOURCE_IP.TabIndex = 17;
            this.EXTSOURCE_IP.TabStop = true;
            this.EXTSOURCE_IP.Text = "IP Address";
            this.EXTSOURCE_IP.UseVisualStyleBackColor = true;
            this.EXTSOURCE_IP.CheckedChanged += new System.EventHandler(this.EXTSOURCE_IP_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 94);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "EXT SRC IP";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "CON TYPE";
            // 
            // extsourceip
            // 
            this.extsourceip.Location = new System.Drawing.Point(111, 91);
            this.extsourceip.Name = "extsourceip";
            this.extsourceip.Size = new System.Drawing.Size(150, 20);
            this.extsourceip.TabIndex = 1;
            this.extsourceip.Text = "134.64.236.75";
            // 
            // extsourcecontype
            // 
            this.extsourcecontype.FormattingEnabled = true;
            this.extsourcecontype.Items.AddRange(new object[] {
            "VXI-11",
            "SOCKET"});
            this.extsourcecontype.Location = new System.Drawing.Point(111, 125);
            this.extsourcecontype.Name = "extsourcecontype";
            this.extsourcecontype.Size = new System.Drawing.Size(150, 21);
            this.extsourcecontype.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(676, 281);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(147, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "External Source Settings";
            // 
            // PIOnly
            // 
            this.PIOnly.AutoSize = true;
            this.PIOnly.Location = new System.Drawing.Point(466, 24);
            this.PIOnly.Name = "PIOnly";
            this.PIOnly.Size = new System.Drawing.Size(67, 17);
            this.PIOnly.TabIndex = 20;
            this.PIOnly.Text = "PI Only";
            this.PIOnly.UseVisualStyleBackColor = true;
            // 
            // PiOnlyHandle
            // 
            this.PiOnlyHandle.AutoSize = true;
            this.PiOnlyHandle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PiOnlyHandle.Location = new System.Drawing.Point(550, 26);
            this.PiOnlyHandle.Name = "PiOnlyHandle";
            this.PiOnlyHandle.Size = new System.Drawing.Size(277, 39);
            this.PiOnlyHandle.TabIndex = 21;
            this.PiOnlyHandle.Text = "Select \"PI Only\" when debugging PI commands\r\non your PIC using VStudio instead of" +
    " AWG app.\r\nRequires \"PBU App\" and \"Controller\" selected.";
            // 
            // SourceXpress
            // 
            this.SourceXpress.AutoSize = true;
            this.SourceXpress.Location = new System.Drawing.Point(172, 65);
            this.SourceXpress.Name = "SourceXpress";
            this.SourceXpress.Size = new System.Drawing.Size(103, 17);
            this.SourceXpress.TabIndex = 22;
            this.SourceXpress.TabStop = true;
            this.SourceXpress.Text = "SourceXpress";
            this.SourceXpress.UseVisualStyleBackColor = true;
            this.SourceXpress.Click += new System.EventHandler(this.SourceXpress_Click);
            // 
            // dutui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 556);
            this.Controls.Add(this.SourceXpress);
            this.Controls.Add(this.PiOnlyHandle);
            this.Controls.Add(this.PIOnly);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.PBUApp);
            this.Controls.Add(this.PCAppConfig);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.writetofile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "dutui";
            this.Text = "DUT CONFIGURATION";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button writetofile;
        private System.Windows.Forms.TextBox dut1ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox awg1contype;
        private System.Windows.Forms.TextBox timeout;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scopeip;
        private System.Windows.Forms.ComboBox scopecontype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox dut1name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dut2name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dut2ip;
        private System.Windows.Forms.ComboBox awg3contype;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox dut3name;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox dut3ip;
        private System.Windows.Forms.ComboBox awg2contype;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox dut4name;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox dut4ip;
        private System.Windows.Forms.ComboBox awg4contype;
        private System.Windows.Forms.RadioButton PCAppConfig;
        private System.Windows.Forms.RadioButton PBUApp;
        private System.Windows.Forms.RadioButton DUT1_Name;
        // private System.Windows.Forms.RadioButton DUT1_IP;
        public System.Windows.Forms.RadioButton DUT1_IP;
        private System.Windows.Forms.RadioButton DUT2_Name;
        private System.Windows.Forms.RadioButton DUT2_IP;
        private System.Windows.Forms.RadioButton DUT3_Name;
        private System.Windows.Forms.RadioButton DUT3_IP;
        private System.Windows.Forms.RadioButton DUT4_Name;
        private System.Windows.Forms.RadioButton DUT4_IP;
        private System.Windows.Forms.RadioButton SCOPE_NAME;
        private System.Windows.Forms.RadioButton SCOPE_IP;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox scopename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox extsourcename;
        private System.Windows.Forms.RadioButton EXTSOURCE_NAME;
        private System.Windows.Forms.RadioButton EXTSOURCE_IP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox extsourceip;
        private System.Windows.Forms.ComboBox extsourcecontype;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox checkBox1controller;
        private System.Windows.Forms.CheckBox PIOnly;
        private System.Windows.Forms.Label PiOnlyHandle;
        private System.Windows.Forms.RadioButton SourceXpress;
    }
}

