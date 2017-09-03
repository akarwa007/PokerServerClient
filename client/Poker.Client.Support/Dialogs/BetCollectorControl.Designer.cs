namespace Poker.Client.Support.Dialogs
{
    partial class BetCollectorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnMin = new System.Windows.Forms.Button();
            this.btn3BB = new System.Windows.Forms.Button();
            this.btnPot = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnFold = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnRaiseTo = new System.Windows.Forms.Button();
            this.txtBetAmount = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(120, 51);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(131, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Maroon;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMin.Location = new System.Drawing.Point(13, 14);
            this.btnMin.Margin = new System.Windows.Forms.Padding(2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(56, 19);
            this.btnMin.TabIndex = 1;
            this.btnMin.Text = "Min";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btn3BB
            // 
            this.btn3BB.BackColor = System.Drawing.Color.Maroon;
            this.btn3BB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn3BB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn3BB.Location = new System.Drawing.Point(74, 14);
            this.btn3BB.Margin = new System.Windows.Forms.Padding(2);
            this.btn3BB.Name = "btn3BB";
            this.btn3BB.Size = new System.Drawing.Size(56, 19);
            this.btn3BB.TabIndex = 2;
            this.btn3BB.Text = "3 BB";
            this.btn3BB.UseVisualStyleBackColor = false;
            this.btn3BB.Click += new System.EventHandler(this.btn3BB_Click);
            // 
            // btnPot
            // 
            this.btnPot.BackColor = System.Drawing.Color.Maroon;
            this.btnPot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPot.Location = new System.Drawing.Point(134, 14);
            this.btnPot.Margin = new System.Windows.Forms.Padding(2);
            this.btnPot.Name = "btnPot";
            this.btnPot.Size = new System.Drawing.Size(56, 19);
            this.btnPot.TabIndex = 3;
            this.btnPot.Text = "Pot";
            this.btnPot.UseVisualStyleBackColor = false;
            this.btnPot.Click += new System.EventHandler(this.btnPot_Click);
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.Maroon;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMax.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMax.Location = new System.Drawing.Point(195, 14);
            this.btnMax.Margin = new System.Windows.Forms.Padding(2);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(56, 19);
            this.btnMax.TabIndex = 4;
            this.btnMax.Text = "Max";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnFold
            // 
            this.btnFold.BackColor = System.Drawing.Color.Maroon;
            this.btnFold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFold.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFold.Location = new System.Drawing.Point(74, 100);
            this.btnFold.Margin = new System.Windows.Forms.Padding(2);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(56, 19);
            this.btnFold.TabIndex = 5;
            this.btnFold.Text = "Fold";
            this.btnFold.UseVisualStyleBackColor = false;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.Maroon;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCall.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCall.Location = new System.Drawing.Point(135, 100);
            this.btnCall.Margin = new System.Windows.Forms.Padding(2);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(56, 19);
            this.btnCall.TabIndex = 6;
            this.btnCall.Text = "Call";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnRaiseTo
            // 
            this.btnRaiseTo.BackColor = System.Drawing.Color.Maroon;
            this.btnRaiseTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRaiseTo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRaiseTo.Location = new System.Drawing.Point(195, 100);
            this.btnRaiseTo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaiseTo.Name = "btnRaiseTo";
            this.btnRaiseTo.Size = new System.Drawing.Size(56, 19);
            this.btnRaiseTo.TabIndex = 7;
            this.btnRaiseTo.Text = "Raise To";
            this.btnRaiseTo.UseVisualStyleBackColor = false;
            this.btnRaiseTo.Click += new System.EventHandler(this.btnRaiseTo_Click);
            // 
            // txtBetAmount
            // 
            this.txtBetAmount.Location = new System.Drawing.Point(13, 51);
            this.txtBetAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtBetAmount.Name = "txtBetAmount";
            this.txtBetAmount.Size = new System.Drawing.Size(103, 20);
            this.txtBetAmount.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.BackColor = System.Drawing.Color.Black;
            this.labelCounter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCounter.Location = new System.Drawing.Point(12, 83);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(25, 13);
            this.labelCounter.TabIndex = 9;
            this.labelCounter.Text = "------";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Silver;
            this.labelUserName.ForeColor = System.Drawing.Color.Lime;
            this.labelUserName.Location = new System.Drawing.Point(12, 106);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(35, 13);
            this.labelUserName.TabIndex = 10;
            this.labelUserName.Text = "empty";
            // 
            // BetCollectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(271, 132);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.txtBetAmount);
            this.Controls.Add(this.btnRaiseTo);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnPot);
            this.Controls.Add(this.btn3BB);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.trackBar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BetCollectorControl";
            this.Load += new System.EventHandler(this.BetCollectorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btn3BB;
        private System.Windows.Forms.Button btnPot;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnRaiseTo;
        private System.Windows.Forms.TextBox txtBetAmount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.Label labelUserName;
    }
}
