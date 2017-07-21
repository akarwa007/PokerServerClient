﻿namespace Poker.Client.Support.Views
{
    partial class View_Casino
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
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("2-4");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Texas Holdem", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("1-3");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("2-5");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("No Limit Holdem", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Omaha Hi Low");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Poker Games", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode19,
            treeNode20});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtPlayerProfile = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPlayerProfile);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2.DoubleClick += new System.EventHandler(this.splitContainer1_Panel2_DoubleClick);
            this.splitContainer1.Size = new System.Drawing.Size(664, 401);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtPlayerProfile
            // 
            this.txtPlayerProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPlayerProfile.Location = new System.Drawing.Point(4, 287);
            this.txtPlayerProfile.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlayerProfile.Multiline = true;
            this.txtPlayerProfile.Name = "txtPlayerProfile";
            this.txtPlayerProfile.Size = new System.Drawing.Size(212, 110);
            this.txtPlayerProfile.TabIndex = 1;
            this.txtPlayerProfile.TextChanged += new System.EventHandler(this.txtPlayerProfile_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode15.Name = "24";
            treeNode15.Text = "2-4";
            treeNode16.Name = "TexasHoldem";
            treeNode16.Text = "Texas Holdem";
            treeNode17.Name = "13";
            treeNode17.Text = "1-3";
            treeNode18.Name = "25";
            treeNode18.Text = "2-5";
            treeNode19.Name = "NoLimitHoldem";
            treeNode19.Text = "No Limit Holdem";
            treeNode20.Name = "OmahaHiLow";
            treeNode20.Text = "Omaha Hi Low";
            treeNode21.Name = "PokerGames";
            treeNode21.Text = "Poker Games";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21});
            this.treeView1.Size = new System.Drawing.Size(221, 401);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 401);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel1_DragDrop);
            this.tableLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel1_DragEnter);
            // 
            // View_Casino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "View_Casino";
            this.Size = new System.Drawing.Size(664, 401);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtPlayerProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
