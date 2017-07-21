namespace Poker.Client.Support.Views
{
    partial class View_Table
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
            this.SuspendLayout();
            // 
            // View_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "View_Table";
            this.Size = new System.Drawing.Size(633, 299);
            this.Load += new System.EventHandler(this.View_Table_Load);
            this.SizeChanged += new System.EventHandler(this.View_Table_SizeChanged);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.View_Table_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Table_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.View_Table_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
