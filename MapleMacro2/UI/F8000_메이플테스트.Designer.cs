namespace MapleMacro2.UI
{
    partial class F8000
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
            this.button1 = new System.Windows.Forms.Button();
            this.timerMousePoint = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.labelImageSearch = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRight = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelLeft = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelRune = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.timer공격패턴1 = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.labelHiddenStreet = new System.Windows.Forms.Label();
            this.textBox공격패턴_1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labelDiffUser = new System.Windows.Forms.Label();
            this.button채널변경 = new System.Windows.Forms.Button();
            this.labelPixelSearch = new System.Windows.Forms.Label();
            this.labelPixelSearchHP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownMacroInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox공격패턴_2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMacroInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "매크로 시작/종료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerMousePoint
            // 
            this.timerMousePoint.Enabled = true;
            this.timerMousePoint.Interval = 1000;
            this.timerMousePoint.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 23);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mouse Postion : ";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.Location = new System.Drawing.Point(115, 9);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(32, 12);
            this.labelMousePosition.TabIndex = 4;
            this.labelMousePosition.Text = "label";
            // 
            // labelImageSearch
            // 
            this.labelImageSearch.AutoSize = true;
            this.labelImageSearch.Location = new System.Drawing.Point(109, 67);
            this.labelImageSearch.Name = "labelImageSearch";
            this.labelImageSearch.Size = new System.Drawing.Size(38, 12);
            this.labelImageSearch.TabIndex = 5;
            this.labelImageSearch.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "mini map :";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(109, 88);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(38, 12);
            this.labelUser.TabIndex = 18;
            this.labelUser.Text = "label5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "user : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "right : ";
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(109, 110);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(38, 12);
            this.labelRight.TabIndex = 18;
            this.labelRight.Text = "label5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(75, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "left : ";
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(109, 131);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(38, 12);
            this.labelLeft.TabIndex = 18;
            this.labelLeft.Text = "label5";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 280);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(224, 152);
            this.textBoxLog.TabIndex = 19;
            // 
            // labelRune
            // 
            this.labelRune.AutoSize = true;
            this.labelRune.Location = new System.Drawing.Point(109, 152);
            this.labelRune.Name = "labelRune";
            this.labelRune.Size = new System.Drawing.Size(38, 12);
            this.labelRune.TabIndex = 21;
            this.labelRune.Text = "label5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "rune : ";
            // 
            // timer공격패턴1
            // 
            this.timer공격패턴1.Interval = 2000;
            this.timer공격패턴1.Tick += new System.EventHandler(this.timer공격패턴1_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "hidden street : ";
            // 
            // labelHiddenStreet
            // 
            this.labelHiddenStreet.AutoSize = true;
            this.labelHiddenStreet.Location = new System.Drawing.Point(109, 172);
            this.labelHiddenStreet.Name = "labelHiddenStreet";
            this.labelHiddenStreet.Size = new System.Drawing.Size(38, 12);
            this.labelHiddenStreet.TabIndex = 21;
            this.labelHiddenStreet.Text = "label5";
            // 
            // textBox공격패턴_1
            // 
            this.textBox공격패턴_1.Location = new System.Drawing.Point(183, 67);
            this.textBox공격패턴_1.Multiline = true;
            this.textBox공격패턴_1.Name = "textBox공격패턴_1";
            this.textBox공격패턴_1.Size = new System.Drawing.Size(158, 148);
            this.textBox공격패턴_1.TabIndex = 22;
            this.textBox공격패턴_1.Text = "Send {Alt down}\r\nSleep 100\r\nSend {Alt up}\r\nSleep 100\r\nSend {Alt down}\r\nSleep 100\r" +
    "\nSend {Alt up}\r\nSleep 350\r\nSend {Ctrl}";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 12);
            this.label15.TabIndex = 20;
            this.label15.Text = "diff user :";
            // 
            // labelDiffUser
            // 
            this.labelDiffUser.AutoSize = true;
            this.labelDiffUser.Location = new System.Drawing.Point(109, 193);
            this.labelDiffUser.Name = "labelDiffUser";
            this.labelDiffUser.Size = new System.Drawing.Size(38, 12);
            this.labelDiffUser.TabIndex = 21;
            this.labelDiffUser.Text = "label5";
            // 
            // button채널변경
            // 
            this.button채널변경.Location = new System.Drawing.Point(508, 12);
            this.button채널변경.Name = "button채널변경";
            this.button채널변경.Size = new System.Drawing.Size(84, 23);
            this.button채널변경.TabIndex = 23;
            this.button채널변경.Text = "채널변경";
            this.button채널변경.UseVisualStyleBackColor = true;
            this.button채널변경.Click += new System.EventHandler(this.button채널변경_Click);
            // 
            // labelPixelSearch
            // 
            this.labelPixelSearch.AutoSize = true;
            this.labelPixelSearch.Location = new System.Drawing.Point(103, 237);
            this.labelPixelSearch.Name = "labelPixelSearch";
            this.labelPixelSearch.Size = new System.Drawing.Size(44, 12);
            this.labelPixelSearch.TabIndex = 24;
            this.labelPixelSearch.Text = "label16";
            // 
            // labelPixelSearchHP
            // 
            this.labelPixelSearchHP.AutoSize = true;
            this.labelPixelSearchHP.Location = new System.Drawing.Point(103, 216);
            this.labelPixelSearchHP.Name = "labelPixelSearchHP";
            this.labelPixelSearchHP.Size = new System.Drawing.Size(44, 12);
            this.labelPixelSearchHP.TabIndex = 24;
            this.labelPixelSearchHP.Text = "label16";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 25;
            this.label16.Text = "HP :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(65, 237);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 12);
            this.label17.TabIndex = 26;
            this.label17.Text = "MP :";
            // 
            // numericUpDownMacroInterval
            // 
            this.numericUpDownMacroInterval.Location = new System.Drawing.Point(332, 12);
            this.numericUpDownMacroInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMacroInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMacroInterval.Name = "numericUpDownMacroInterval";
            this.numericUpDownMacroInterval.Size = new System.Drawing.Size(87, 21);
            this.numericUpDownMacroInterval.TabIndex = 27;
            this.numericUpDownMacroInterval.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "공격패턴 1(->)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "공격패턴 2(<-)";
            // 
            // textBox공격패턴_2
            // 
            this.textBox공격패턴_2.Location = new System.Drawing.Point(356, 68);
            this.textBox공격패턴_2.Multiline = true;
            this.textBox공격패턴_2.Name = "textBox공격패턴_2";
            this.textBox공격패턴_2.Size = new System.Drawing.Size(149, 148);
            this.textBox공격패턴_2.TabIndex = 22;
            this.textBox공격패턴_2.Text = "Send {Alt down}\r\nSleep 100\r\nSend {Alt up}\r\nSleep 100\r\nSend {Alt down}\r\nSleep 100\r" +
    "\nSend {Alt up}\r\nSleep 350\r\nSend {Ctrl}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "로그";
            // 
            // F8000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownMacroInterval);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labelPixelSearchHP);
            this.Controls.Add(this.labelPixelSearch);
            this.Controls.Add(this.button채널변경);
            this.Controls.Add(this.textBox공격패턴_2);
            this.Controls.Add(this.textBox공격패턴_1);
            this.Controls.Add(this.labelDiffUser);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.labelHiddenStreet);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelRune);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelRight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelImageSearch);
            this.Controls.Add(this.labelMousePosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "F8000";
            this.Text = "F8000";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F8000_FormClosing);
            this.Load += new System.EventHandler(this.F8000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMacroInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerMousePoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMousePosition;
        private System.Windows.Forms.Label labelImageSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelRune;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer공격패턴1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelHiddenStreet;
        private System.Windows.Forms.TextBox textBox공격패턴_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelDiffUser;
        private System.Windows.Forms.Button button채널변경;
        private System.Windows.Forms.Label labelPixelSearch;
        private System.Windows.Forms.Label labelPixelSearchHP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownMacroInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox공격패턴_2;
        private System.Windows.Forms.Label label6;
    }
}