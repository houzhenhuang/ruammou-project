namespace SuperLotto
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDLT = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStop = new System.Windows.Forms.Button();
            this.lblRed1 = new System.Windows.Forms.Label();
            this.lblRed3 = new System.Windows.Forms.Label();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.lblRed4 = new System.Windows.Forms.Label();
            this.lblRed5 = new System.Windows.Forms.Label();
            this.lblBlue2 = new System.Windows.Forms.Label();
            this.lblBlue1 = new System.Windows.Forms.Label();
            this.gbDLT.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDLT
            // 
            this.gbDLT.Controls.Add(this.lblBlue1);
            this.gbDLT.Controls.Add(this.lblBlue2);
            this.gbDLT.Controls.Add(this.lblRed5);
            this.gbDLT.Controls.Add(this.lblRed4);
            this.gbDLT.Controls.Add(this.lblRed2);
            this.gbDLT.Controls.Add(this.lblRed3);
            this.gbDLT.Controls.Add(this.lblRed1);
            this.gbDLT.Location = new System.Drawing.Point(26, 23);
            this.gbDLT.Name = "gbDLT";
            this.gbDLT.Size = new System.Drawing.Size(523, 153);
            this.gbDLT.TabIndex = 0;
            this.gbDLT.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(171, 187);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStop
            // 
            this.lblStop.Location = new System.Drawing.Point(319, 187);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(75, 23);
            this.lblStop.TabIndex = 2;
            this.lblStop.Text = "Stop";
            this.lblStop.UseVisualStyleBackColor = true;
            // 
            // lblRed1
            // 
            this.lblRed1.AutoSize = true;
            this.lblRed1.ForeColor = System.Drawing.Color.Red;
            this.lblRed1.Location = new System.Drawing.Point(36, 72);
            this.lblRed1.Name = "lblRed1";
            this.lblRed1.Size = new System.Drawing.Size(17, 12);
            this.lblRed1.TabIndex = 0;
            this.lblRed1.Text = "00";
            // 
            // lblRed3
            // 
            this.lblRed3.AutoSize = true;
            this.lblRed3.ForeColor = System.Drawing.Color.Red;
            this.lblRed3.Location = new System.Drawing.Point(164, 72);
            this.lblRed3.Name = "lblRed3";
            this.lblRed3.Size = new System.Drawing.Size(17, 12);
            this.lblRed3.TabIndex = 1;
            this.lblRed3.Text = "00";
            // 
            // lblRed2
            // 
            this.lblRed2.AutoSize = true;
            this.lblRed2.ForeColor = System.Drawing.Color.Red;
            this.lblRed2.Location = new System.Drawing.Point(96, 72);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(17, 12);
            this.lblRed2.TabIndex = 2;
            this.lblRed2.Text = "00";
            // 
            // lblRed4
            // 
            this.lblRed4.AutoSize = true;
            this.lblRed4.ForeColor = System.Drawing.Color.Red;
            this.lblRed4.Location = new System.Drawing.Point(230, 72);
            this.lblRed4.Name = "lblRed4";
            this.lblRed4.Size = new System.Drawing.Size(17, 12);
            this.lblRed4.TabIndex = 3;
            this.lblRed4.Text = "00";
            // 
            // lblRed5
            // 
            this.lblRed5.AutoSize = true;
            this.lblRed5.ForeColor = System.Drawing.Color.Red;
            this.lblRed5.Location = new System.Drawing.Point(300, 72);
            this.lblRed5.Name = "lblRed5";
            this.lblRed5.Size = new System.Drawing.Size(17, 12);
            this.lblRed5.TabIndex = 4;
            this.lblRed5.Text = "00";
            // 
            // lblBlue2
            // 
            this.lblBlue2.AutoSize = true;
            this.lblBlue2.ForeColor = System.Drawing.Color.Blue;
            this.lblBlue2.Location = new System.Drawing.Point(461, 72);
            this.lblBlue2.Name = "lblBlue2";
            this.lblBlue2.Size = new System.Drawing.Size(17, 12);
            this.lblBlue2.TabIndex = 5;
            this.lblBlue2.Text = "00";
            // 
            // lblBlue1
            // 
            this.lblBlue1.AutoSize = true;
            this.lblBlue1.ForeColor = System.Drawing.Color.Blue;
            this.lblBlue1.Location = new System.Drawing.Point(393, 72);
            this.lblBlue1.Name = "lblBlue1";
            this.lblBlue1.Size = new System.Drawing.Size(17, 12);
            this.lblBlue1.TabIndex = 6;
            this.lblBlue1.Text = "00";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 248);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbDLT);
            this.Name = "frmMain";
            this.Text = "超级大乐透";
            this.gbDLT.ResumeLayout(false);
            this.gbDLT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDLT;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button lblStop;
        private System.Windows.Forms.Label lblRed1;
        private System.Windows.Forms.Label lblBlue1;
        private System.Windows.Forms.Label lblBlue2;
        private System.Windows.Forms.Label lblRed5;
        private System.Windows.Forms.Label lblRed4;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Label lblRed3;
    }
}

