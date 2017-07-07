namespace PokerClient
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.btbSubmit2 = new System.Windows.Forms.Button();
            this.btnSubmit3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 68);
            this.button2.TabIndex = 1;
            this.button2.Text = "Start Client";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(441, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 68);
            this.button3.TabIndex = 2;
            this.button3.Text = "Start Client";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 186);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 109);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 186);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(441, 109);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(198, 186);
            this.textBox3.TabIndex = 5;
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.Location = new System.Drawing.Point(83, 301);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(79, 23);
            this.btnSubmit1.TabIndex = 6;
            this.btnSubmit1.Text = "Submit";
            this.btnSubmit1.UseVisualStyleBackColor = true;
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Click);
            // 
            // btbSubmit2
            // 
            this.btbSubmit2.Location = new System.Drawing.Point(288, 301);
            this.btbSubmit2.Name = "btbSubmit2";
            this.btbSubmit2.Size = new System.Drawing.Size(79, 23);
            this.btbSubmit2.TabIndex = 7;
            this.btbSubmit2.Text = "Submit";
            this.btbSubmit2.UseVisualStyleBackColor = true;
            this.btbSubmit2.Click += new System.EventHandler(this.btbSubmit2_Click);
            // 
            // btnSubmit3
            // 
            this.btnSubmit3.Location = new System.Drawing.Point(495, 301);
            this.btnSubmit3.Name = "btnSubmit3";
            this.btnSubmit3.Size = new System.Drawing.Size(79, 23);
            this.btnSubmit3.TabIndex = 8;
            this.btnSubmit3.Text = "Submit";
            this.btnSubmit3.UseVisualStyleBackColor = true;
            this.btnSubmit3.Click += new System.EventHandler(this.btnSubmit3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 331);
            this.Controls.Add(this.btnSubmit3);
            this.Controls.Add(this.btbSubmit2);
            this.Controls.Add(this.btnSubmit1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSubmit1;
        private System.Windows.Forms.Button btbSubmit2;
        private System.Windows.Forms.Button btnSubmit3;
    }
}