namespace Poker.Server
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
            this.btnStartServer1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btSendCasinoUpdate = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnViewClients = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_Clients = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnViewTables = new System.Windows.Forms.Button();
            this.dataGridView_Tables = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tables)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartServer1
            // 
            this.btnStartServer1.Location = new System.Drawing.Point(14, 12);
            this.btnStartServer1.Name = "btnStartServer1";
            this.btnStartServer1.Size = new System.Drawing.Size(155, 47);
            this.btnStartServer1.TabIndex = 0;
            this.btnStartServer1.Text = "Start Server";
            this.btnStartServer1.UseVisualStyleBackColor = true;
            this.btnStartServer1.Click += new System.EventHandler(this.btnStartServer1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 141);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btSendCasinoUpdate
            // 
            this.btSendCasinoUpdate.Location = new System.Drawing.Point(14, 204);
            this.btSendCasinoUpdate.Name = "btSendCasinoUpdate";
            this.btSendCasinoUpdate.Size = new System.Drawing.Size(152, 39);
            this.btSendCasinoUpdate.TabIndex = 2;
            this.btSendCasinoUpdate.Text = "Send Casino Update";
            this.btSendCasinoUpdate.UseVisualStyleBackColor = true;
            this.btSendCasinoUpdate.Click += new System.EventHandler(this.btSendCasinoUpdate_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 263);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 20);
            this.textBox2.TabIndex = 3;
            // 
            // btnViewClients
            // 
            this.btnViewClients.Location = new System.Drawing.Point(14, 86);
            this.btnViewClients.Name = "btnViewClients";
            this.btnViewClients.Size = new System.Drawing.Size(155, 39);
            this.btnViewClients.TabIndex = 4;
            this.btnViewClients.Text = "View Clients";
            this.btnViewClients.UseVisualStyleBackColor = true;
            this.btnViewClients.Click += new System.EventHandler(this.btnViewClients_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_Tables, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_Clients, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 295);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView_Clients
            // 
            this.dataGridView_Clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Clients.Location = new System.Drawing.Point(234, 3);
            this.dataGridView_Clients.Name = "dataGridView_Clients";
            this.dataGridView_Clients.Size = new System.Drawing.Size(225, 141);
            this.dataGridView_Clients.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.btnViewTables);
            this.splitContainer1.Panel1.Controls.Add(this.btSendCasinoUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartServer1);
            this.splitContainer1.Panel1.Controls.Add(this.btnViewClients);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 295);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 6;
            // 
            // btnViewTables
            // 
            this.btnViewTables.Location = new System.Drawing.Point(14, 145);
            this.btnViewTables.Name = "btnViewTables";
            this.btnViewTables.Size = new System.Drawing.Size(155, 39);
            this.btnViewTables.TabIndex = 5;
            this.btnViewTables.Text = "ViewTables";
            this.btnViewTables.UseVisualStyleBackColor = true;
            this.btnViewTables.Click += new System.EventHandler(this.btnViewTables_Click);
            // 
            // dataGridView_Tables
            // 
            this.dataGridView_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Tables.Location = new System.Drawing.Point(3, 150);
            this.dataGridView_Tables.Name = "dataGridView_Tables";
            this.dataGridView_Tables.Size = new System.Drawing.Size(225, 142);
            this.dataGridView_Tables.TabIndex = 3;
            this.dataGridView_Tables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Tables_CellClick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(652, 295);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clients)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStartServer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSendCasinoUpdate;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnViewClients;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_Clients;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnViewTables;
        private System.Windows.Forms.DataGridView dataGridView_Tables;
    }
}

