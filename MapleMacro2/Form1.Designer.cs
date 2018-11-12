namespace MapleMacro2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button시작 = new System.Windows.Forms.Button();
            this.button중지 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button캡쳐 = new System.Windows.Forms.Button();
            this.button캡쳐2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox기술_1_키 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox기술_2_키 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox기술_3_키 = new System.Windows.Forms.TextBox();
            this.textBox기술_4_키 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.timer매크로활성 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox설정_매크로_활성_시간 = new System.Windows.Forms.TextBox();
            this.checkBox기술_4_매크로유무 = new System.Windows.Forms.CheckBox();
            this.checkBox기술_3_매크로유무 = new System.Windows.Forms.CheckBox();
            this.checkBox기술_2_매크로유무 = new System.Windows.Forms.CheckBox();
            this.checkBox기술_1_매크로유무 = new System.Windows.Forms.CheckBox();
            this.textBox기술_4_실행간격 = new System.Windows.Forms.TextBox();
            this.textBox기술_3_실행간격 = new System.Windows.Forms.TextBox();
            this.textBox기술_2_실행간격 = new System.Windows.Forms.TextBox();
            this.textBox기술_1_실행간격 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel시작유무 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar시작유무 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button시작
            // 
            this.button시작.Location = new System.Drawing.Point(13, 13);
            this.button시작.Name = "button시작";
            this.button시작.Size = new System.Drawing.Size(75, 23);
            this.button시작.TabIndex = 0;
            this.button시작.Text = "시작";
            this.button시작.UseVisualStyleBackColor = true;
            this.button시작.Click += new System.EventHandler(this.button시작_Click);
            // 
            // button중지
            // 
            this.button중지.Location = new System.Drawing.Point(13, 43);
            this.button중지.Name = "button중지";
            this.button중지.Size = new System.Drawing.Size(75, 23);
            this.button중지.TabIndex = 1;
            this.button중지.Text = "중지";
            this.button중지.UseVisualStyleBackColor = true;
            this.button중지.Click += new System.EventHandler(this.button중지_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 308);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(405, 42);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // button캡쳐
            // 
            this.button캡쳐.Location = new System.Drawing.Point(261, 276);
            this.button캡쳐.Name = "button캡쳐";
            this.button캡쳐.Size = new System.Drawing.Size(75, 23);
            this.button캡쳐.TabIndex = 3;
            this.button캡쳐.Text = "캡쳐";
            this.button캡쳐.UseVisualStyleBackColor = true;
            this.button캡쳐.Visible = false;
            this.button캡쳐.Click += new System.EventHandler(this.button캡쳐_Click);
            // 
            // button캡쳐2
            // 
            this.button캡쳐2.Location = new System.Drawing.Point(342, 276);
            this.button캡쳐2.Name = "button캡쳐2";
            this.button캡쳐2.Size = new System.Drawing.Size(75, 23);
            this.button캡쳐2.TabIndex = 4;
            this.button캡쳐2.Text = "캡쳐2";
            this.button캡쳐2.UseVisualStyleBackColor = true;
            this.button캡쳐2.Visible = false;
            this.button캡쳐2.Click += new System.EventHandler(this.button캡쳐2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "기술";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "키";
            // 
            // textBox기술_1_키
            // 
            this.textBox기술_1_키.Location = new System.Drawing.Point(55, 60);
            this.textBox기술_1_키.Name = "textBox기술_1_키";
            this.textBox기술_1_키.ReadOnly = true;
            this.textBox기술_1_키.Size = new System.Drawing.Size(100, 21);
            this.textBox기술_1_키.TabIndex = 6;
            this.textBox기술_1_키.Text = "A";
            this.textBox기술_1_키.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "실행간격";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "msec";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "msec";
            // 
            // textBox기술_2_키
            // 
            this.textBox기술_2_키.Location = new System.Drawing.Point(55, 87);
            this.textBox기술_2_키.Name = "textBox기술_2_키";
            this.textBox기술_2_키.ReadOnly = true;
            this.textBox기술_2_키.Size = new System.Drawing.Size(100, 21);
            this.textBox기술_2_키.TabIndex = 6;
            this.textBox기술_2_키.Text = "Insert";
            this.textBox기술_2_키.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "msec";
            // 
            // textBox기술_3_키
            // 
            this.textBox기술_3_키.Location = new System.Drawing.Point(55, 114);
            this.textBox기술_3_키.Name = "textBox기술_3_키";
            this.textBox기술_3_키.ReadOnly = true;
            this.textBox기술_3_키.Size = new System.Drawing.Size(100, 21);
            this.textBox기술_3_키.TabIndex = 6;
            this.textBox기술_3_키.Text = "Delete";
            this.textBox기술_3_키.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox기술_4_키
            // 
            this.textBox기술_4_키.Location = new System.Drawing.Point(55, 143);
            this.textBox기술_4_키.Name = "textBox기술_4_키";
            this.textBox기술_4_키.ReadOnly = true;
            this.textBox기술_4_키.Size = new System.Drawing.Size(100, 21);
            this.textBox기술_4_키.TabIndex = 10;
            this.textBox기술_4_키.Text = "Z";
            this.textBox기술_4_키.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(243, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "msec";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "4";
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(291, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "매크로 유무";
            // 
            // timer매크로활성
            // 
            this.timer매크로활성.Tick += new System.EventHandler(this.timer매크로활성_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.checkBox기술_4_매크로유무);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox기술_3_매크로유무);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox기술_2_매크로유무);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox기술_1_매크로유무);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox기술_4_실행간격);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox기술_4_키);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox기술_1_키);
            this.groupBox1.Controls.Add(this.textBox기술_3_실행간격);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox기술_2_실행간격);
            this.groupBox1.Controls.Add(this.textBox기술_2_키);
            this.groupBox1.Controls.Add(this.textBox기술_3_키);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox기술_1_실행간격);
            this.groupBox1.Location = new System.Drawing.Point(95, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 177);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "기술 키";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox설정_매크로_활성_시간);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(95, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 69);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "설정";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "매크로 활성 시간";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(202, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "msec";
            // 
            // textBox설정_매크로_활성_시간
            // 
            this.textBox설정_매크로_활성_시간.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MapleMacro2.Properties.Settings.Default, "설정_매크로_활성_시간", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox설정_매크로_활성_시간.Location = new System.Drawing.Point(122, 29);
            this.textBox설정_매크로_활성_시간.Name = "textBox설정_매크로_활성_시간";
            this.textBox설정_매크로_활성_시간.Size = new System.Drawing.Size(74, 21);
            this.textBox설정_매크로_활성_시간.TabIndex = 8;
            this.textBox설정_매크로_활성_시간.Text = global::MapleMacro2.Properties.Settings.Default.설정_매크로_활성_시간;
            this.textBox설정_매크로_활성_시간.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox기술_4_매크로유무
            // 
            this.checkBox기술_4_매크로유무.AutoSize = true;
            this.checkBox기술_4_매크로유무.Checked = global::MapleMacro2.Properties.Settings.Default.기술_4_매크로유무;
            this.checkBox기술_4_매크로유무.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MapleMacro2.Properties.Settings.Default, "기술_4_매크로유무", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox기술_4_매크로유무.Location = new System.Drawing.Point(316, 146);
            this.checkBox기술_4_매크로유무.Name = "checkBox기술_4_매크로유무";
            this.checkBox기술_4_매크로유무.Size = new System.Drawing.Size(15, 14);
            this.checkBox기술_4_매크로유무.TabIndex = 11;
            this.checkBox기술_4_매크로유무.UseVisualStyleBackColor = true;
            // 
            // checkBox기술_3_매크로유무
            // 
            this.checkBox기술_3_매크로유무.AutoSize = true;
            this.checkBox기술_3_매크로유무.Checked = global::MapleMacro2.Properties.Settings.Default.기술_3_매크로유무;
            this.checkBox기술_3_매크로유무.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MapleMacro2.Properties.Settings.Default, "기술_3_매크로유무", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox기술_3_매크로유무.Location = new System.Drawing.Point(316, 117);
            this.checkBox기술_3_매크로유무.Name = "checkBox기술_3_매크로유무";
            this.checkBox기술_3_매크로유무.Size = new System.Drawing.Size(15, 14);
            this.checkBox기술_3_매크로유무.TabIndex = 11;
            this.checkBox기술_3_매크로유무.UseVisualStyleBackColor = true;
            // 
            // checkBox기술_2_매크로유무
            // 
            this.checkBox기술_2_매크로유무.AutoSize = true;
            this.checkBox기술_2_매크로유무.Checked = global::MapleMacro2.Properties.Settings.Default.기술_2_매크로유무;
            this.checkBox기술_2_매크로유무.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MapleMacro2.Properties.Settings.Default, "기술_2_매크로유무", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox기술_2_매크로유무.Location = new System.Drawing.Point(316, 90);
            this.checkBox기술_2_매크로유무.Name = "checkBox기술_2_매크로유무";
            this.checkBox기술_2_매크로유무.Size = new System.Drawing.Size(15, 14);
            this.checkBox기술_2_매크로유무.TabIndex = 11;
            this.checkBox기술_2_매크로유무.UseVisualStyleBackColor = true;
            // 
            // checkBox기술_1_매크로유무
            // 
            this.checkBox기술_1_매크로유무.AutoSize = true;
            this.checkBox기술_1_매크로유무.Checked = global::MapleMacro2.Properties.Settings.Default.기술_1_매크로유무;
            this.checkBox기술_1_매크로유무.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MapleMacro2.Properties.Settings.Default, "기술_1_매크로유무", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox기술_1_매크로유무.Location = new System.Drawing.Point(316, 62);
            this.checkBox기술_1_매크로유무.Name = "checkBox기술_1_매크로유무";
            this.checkBox기술_1_매크로유무.Size = new System.Drawing.Size(15, 14);
            this.checkBox기술_1_매크로유무.TabIndex = 11;
            this.checkBox기술_1_매크로유무.UseVisualStyleBackColor = true;
            // 
            // textBox기술_4_실행간격
            // 
            this.textBox기술_4_실행간격.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MapleMacro2.Properties.Settings.Default, "기술_4_실행간격", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox기술_4_실행간격.Location = new System.Drawing.Point(163, 143);
            this.textBox기술_4_실행간격.Name = "textBox기술_4_실행간격";
            this.textBox기술_4_실행간격.Size = new System.Drawing.Size(74, 21);
            this.textBox기술_4_실행간격.TabIndex = 9;
            this.textBox기술_4_실행간격.Text = global::MapleMacro2.Properties.Settings.Default.기술_4_실행간격;
            this.textBox기술_4_실행간격.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox기술_3_실행간격
            // 
            this.textBox기술_3_실행간격.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MapleMacro2.Properties.Settings.Default, "기술_3_실행간격", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox기술_3_실행간격.Location = new System.Drawing.Point(163, 114);
            this.textBox기술_3_실행간격.Name = "textBox기술_3_실행간격";
            this.textBox기술_3_실행간격.Size = new System.Drawing.Size(74, 21);
            this.textBox기술_3_실행간격.TabIndex = 6;
            this.textBox기술_3_실행간격.Text = global::MapleMacro2.Properties.Settings.Default.기술_3_실행간격;
            this.textBox기술_3_실행간격.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox기술_2_실행간격
            // 
            this.textBox기술_2_실행간격.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MapleMacro2.Properties.Settings.Default, "기술_2_실행간격", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox기술_2_실행간격.Location = new System.Drawing.Point(163, 87);
            this.textBox기술_2_실행간격.Name = "textBox기술_2_실행간격";
            this.textBox기술_2_실행간격.Size = new System.Drawing.Size(74, 21);
            this.textBox기술_2_실행간격.TabIndex = 6;
            this.textBox기술_2_실행간격.Text = global::MapleMacro2.Properties.Settings.Default.기술_2_실행간격;
            this.textBox기술_2_실행간격.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox기술_1_실행간격
            // 
            this.textBox기술_1_실행간격.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MapleMacro2.Properties.Settings.Default, "기술_1_실행간격", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox기술_1_실행간격.Location = new System.Drawing.Point(163, 60);
            this.textBox기술_1_실행간격.Name = "textBox기술_1_실행간격";
            this.textBox기술_1_실행간격.Size = new System.Drawing.Size(74, 21);
            this.textBox기술_1_실행간격.TabIndex = 6;
            this.textBox기술_1_실행간격.Text = global::MapleMacro2.Properties.Settings.Default.기술_1_실행간격;
            this.textBox기술_1_실행간격.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel시작유무,
            this.toolStripProgressBar시작유무});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(479, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel시작유무
            // 
            this.toolStripStatusLabel시작유무.Name = "toolStripStatusLabel시작유무";
            this.toolStripStatusLabel시작유무.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel시작유무.Text = "정지";
            // 
            // toolStripProgressBar시작유무
            // 
            this.toolStripProgressBar시작유무.Name = "toolStripProgressBar시작유무";
            this.toolStripProgressBar시작유무.Size = new System.Drawing.Size(50, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 362);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button캡쳐2);
            this.Controls.Add(this.button캡쳐);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button중지);
            this.Controls.Add(this.button시작);
            this.Name = "Form1";
            this.Text = "MapleMacro2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button시작;
        private System.Windows.Forms.Button button중지;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button캡쳐;
        private System.Windows.Forms.Button button캡쳐2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox기술_1_키;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox기술_1_실행간격;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox기술_2_키;
        private System.Windows.Forms.TextBox textBox기술_2_실행간격;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox기술_3_키;
        private System.Windows.Forms.TextBox textBox기술_3_실행간격;
        private System.Windows.Forms.TextBox textBox기술_4_실행간격;
        private System.Windows.Forms.TextBox textBox기술_4_키;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox기술_1_매크로유무;
        private System.Windows.Forms.CheckBox checkBox기술_2_매크로유무;
        private System.Windows.Forms.CheckBox checkBox기술_3_매크로유무;
        private System.Windows.Forms.CheckBox checkBox기술_4_매크로유무;
        private System.Windows.Forms.Timer timer매크로활성;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox설정_매크로_활성_시간;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel시작유무;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar시작유무;
    }
}

