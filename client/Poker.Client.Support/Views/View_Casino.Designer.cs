namespace Poker.Client.Support.Views
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("2-4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Texas Holdem", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("1-3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("2-5");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("No Limit Holdem", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Omaha Hi Low");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Poker Games", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5,
            treeNode6});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtPlayerProfile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2.DoubleClick += new System.EventHandler(this.splitContainer1_Panel2_DoubleClick);
            this.splitContainer1.Size = new System.Drawing.Size(498, 326);
            this.splitContainer1.SplitterDistance = 166;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "24";
            treeNode1.Text = "2-4";
            treeNode2.Name = "TexasHoldem";
            treeNode2.Text = "Texas Holdem";
            treeNode3.Name = "13";
            treeNode3.Text = "1-3";
            treeNode4.Name = "25";
            treeNode4.Text = "2-5";
            treeNode5.Name = "NoLimitHoldem";
            treeNode5.Text = "No Limit Holdem";
            treeNode6.Name = "OmahaHiLow";
            treeNode6.Text = "Omaha Hi Low";
            treeNode7.Name = "PokerGames";
            treeNode7.Text = "Poker Games";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(166, 326);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // txtPlayerProfile
            // 
            this.txtPlayerProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPlayerProfile.Location = new System.Drawing.Point(3, 233);
            this.txtPlayerProfile.Multiline = true;
            this.txtPlayerProfile.Name = "txtPlayerProfile";
            this.txtPlayerProfile.Size = new System.Drawing.Size(160, 90);
            this.txtPlayerProfile.TabIndex = 1;
            this.txtPlayerProfile.TextChanged += new System.EventHandler(this.txtPlayerProfile_TextChanged);
            // 
            // View_Casino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "View_Casino";
            this.Size = new System.Drawing.Size(498, 326);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtPlayerProfile;
    }
}
