namespace MapleMacro2.UI
{
    partial class F9000
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
            this.button확인 = new System.Windows.Forms.Button();
            this.button취소 = new System.Windows.Forms.Button();
            this.radioButton게임_설정_메이플스토리 = new System.Windows.Forms.RadioButton();
            this.radioButton게임_설정_디아블로3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton게임_설정_직접_입력 = new System.Windows.Forms.RadioButton();
            this.textBox게임_설정_직접_입력 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button확인
            // 
            this.button확인.Location = new System.Drawing.Point(275, 131);
            this.button확인.Name = "button확인";
            this.button확인.Size = new System.Drawing.Size(75, 23);
            this.button확인.TabIndex = 0;
            this.button확인.Text = "확인";
            this.button확인.UseVisualStyleBackColor = true;
            this.button확인.Click += new System.EventHandler(this.button확인_Click);
            // 
            // button취소
            // 
            this.button취소.Location = new System.Drawing.Point(364, 131);
            this.button취소.Name = "button취소";
            this.button취소.Size = new System.Drawing.Size(75, 23);
            this.button취소.TabIndex = 1;
            this.button취소.Text = "취소";
            this.button취소.UseVisualStyleBackColor = true;
            this.button취소.Click += new System.EventHandler(this.button취소_Click);
            // 
            // radioButton게임_설정_메이플스토리
            // 
            this.radioButton게임_설정_메이플스토리.AutoSize = true;
            this.radioButton게임_설정_메이플스토리.Location = new System.Drawing.Point(17, 20);
            this.radioButton게임_설정_메이플스토리.Name = "radioButton게임_설정_메이플스토리";
            this.radioButton게임_설정_메이플스토리.Size = new System.Drawing.Size(99, 16);
            this.radioButton게임_설정_메이플스토리.TabIndex = 2;
            this.radioButton게임_설정_메이플스토리.TabStop = true;
            this.radioButton게임_설정_메이플스토리.Text = "메이플 스토리";
            this.radioButton게임_설정_메이플스토리.UseVisualStyleBackColor = true;
            // 
            // radioButton게임_설정_디아블로3
            // 
            this.radioButton게임_설정_디아블로3.AutoSize = true;
            this.radioButton게임_설정_디아블로3.Location = new System.Drawing.Point(122, 20);
            this.radioButton게임_설정_디아블로3.Name = "radioButton게임_설정_디아블로3";
            this.radioButton게임_설정_디아블로3.Size = new System.Drawing.Size(81, 16);
            this.radioButton게임_설정_디아블로3.TabIndex = 2;
            this.radioButton게임_설정_디아블로3.TabStop = true;
            this.radioButton게임_설정_디아블로3.Text = "디아블로 3";
            this.radioButton게임_설정_디아블로3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox게임_설정_직접_입력);
            this.groupBox1.Controls.Add(this.radioButton게임_설정_직접_입력);
            this.groupBox1.Controls.Add(this.radioButton게임_설정_디아블로3);
            this.groupBox1.Controls.Add(this.radioButton게임_설정_메이플스토리);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 104);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "게임 설정";
            // 
            // radioButton게임_설정_직접_입력
            // 
            this.radioButton게임_설정_직접_입력.AutoSize = true;
            this.radioButton게임_설정_직접_입력.Location = new System.Drawing.Point(17, 73);
            this.radioButton게임_설정_직접_입력.Name = "radioButton게임_설정_직접_입력";
            this.radioButton게임_설정_직접_입력.Size = new System.Drawing.Size(75, 16);
            this.radioButton게임_설정_직접_입력.TabIndex = 3;
            this.radioButton게임_설정_직접_입력.TabStop = true;
            this.radioButton게임_설정_직접_입력.Text = "직접 입력";
            this.radioButton게임_설정_직접_입력.UseVisualStyleBackColor = true;
            this.radioButton게임_설정_직접_입력.CheckedChanged += new System.EventHandler(this.radioButton게임_설정_직접_입력_CheckedChanged);
            // 
            // textBox게임_설정_직접_입력
            // 
            this.textBox게임_설정_직접_입력.Enabled = false;
            this.textBox게임_설정_직접_입력.Location = new System.Drawing.Point(98, 69);
            this.textBox게임_설정_직접_입력.Name = "textBox게임_설정_직접_입력";
            this.textBox게임_설정_직접_입력.Size = new System.Drawing.Size(195, 21);
            this.textBox게임_설정_직접_입력.TabIndex = 4;
            // 
            // F9000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 170);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button취소);
            this.Controls.Add(this.button확인);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "F9000";
            this.Text = "옵션";
            this.Load += new System.EventHandler(this.F9000_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button확인;
        private System.Windows.Forms.Button button취소;
        private System.Windows.Forms.RadioButton radioButton게임_설정_메이플스토리;
        private System.Windows.Forms.RadioButton radioButton게임_설정_디아블로3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox게임_설정_직접_입력;
        private System.Windows.Forms.RadioButton radioButton게임_설정_직접_입력;
    }
}