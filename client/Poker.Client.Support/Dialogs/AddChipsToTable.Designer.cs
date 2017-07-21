namespace Poker.Client.Support.Dialogs
{
    partial class AddChipsToTable
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
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblTotalMoneyValue = new System.Windows.Forms.Label();
            this.lblAvailableMoney = new System.Windows.Forms.Label();
            this.lblAvailableMoneyValue = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectedAmount = new System.Windows.Forms.Label();
            this.txtSelectedAmountValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Location = new System.Drawing.Point(39, 23);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(83, 16);
            this.lblTotalMoney.TabIndex = 0;
            this.lblTotalMoney.Text = "Total Money";
            // 
            // lblTotalMoneyValue
            // 
            this.lblTotalMoneyValue.AutoSize = true;
            this.lblTotalMoneyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTotalMoneyValue.Location = new System.Drawing.Point(216, 23);
            this.lblTotalMoneyValue.Name = "lblTotalMoneyValue";
            this.lblTotalMoneyValue.Size = new System.Drawing.Size(15, 16);
            this.lblTotalMoneyValue.TabIndex = 1;
            this.lblTotalMoneyValue.Text = "0";
            // 
            // lblAvailableMoney
            // 
            this.lblAvailableMoney.AutoSize = true;
            this.lblAvailableMoney.Location = new System.Drawing.Point(39, 53);
            this.lblAvailableMoney.Name = "lblAvailableMoney";
            this.lblAvailableMoney.Size = new System.Drawing.Size(109, 16);
            this.lblAvailableMoney.TabIndex = 2;
            this.lblAvailableMoney.Text = "Available Money";
            // 
            // lblAvailableMoneyValue
            // 
            this.lblAvailableMoneyValue.AutoSize = true;
            this.lblAvailableMoneyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblAvailableMoneyValue.Location = new System.Drawing.Point(216, 53);
            this.lblAvailableMoneyValue.Name = "lblAvailableMoneyValue";
            this.lblAvailableMoneyValue.Size = new System.Drawing.Size(15, 16);
            this.lblAvailableMoneyValue.TabIndex = 3;
            this.lblAvailableMoneyValue.Text = "0";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(300, 148);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectedAmount
            // 
            this.lblSelectedAmount.AutoSize = true;
            this.lblSelectedAmount.Location = new System.Drawing.Point(39, 103);
            this.lblSelectedAmount.Name = "lblSelectedAmount";
            this.lblSelectedAmount.Size = new System.Drawing.Size(143, 16);
            this.lblSelectedAmount.TabIndex = 6;
            this.lblSelectedAmount.Text = "Select - Amount to Add";
            // 
            // txtSelectedAmountValue
            // 
            this.txtSelectedAmountValue.Location = new System.Drawing.Point(219, 100);
            this.txtSelectedAmountValue.Name = "txtSelectedAmountValue";
            this.txtSelectedAmountValue.Size = new System.Drawing.Size(156, 22);
            this.txtSelectedAmountValue.TabIndex = 7;
            // 
            // AddChipsToTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 198);
            this.Controls.Add(this.txtSelectedAmountValue);
            this.Controls.Add(this.lblSelectedAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblAvailableMoneyValue);
            this.Controls.Add(this.lblAvailableMoney);
            this.Controls.Add(this.lblTotalMoneyValue);
            this.Controls.Add(this.lblTotalMoney);
            this.Name = "AddChipsToTable";
            this.Text = "AddChipsToTable";
            this.Load += new System.EventHandler(this.AddChipsToTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblAvailableMoney;
        private System.Windows.Forms.Label lblAvailableMoneyValue;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectedAmount;
        private System.Windows.Forms.TextBox txtSelectedAmountValue;
        protected System.Windows.Forms.Label lblTotalMoneyValue;
    }
}