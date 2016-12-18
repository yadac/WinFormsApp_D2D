namespace WinFormsApp_D2D
{
    partial class Toolbar
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
            this.toolbar1 = new CommonControl.Toolbar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // toolbar1
            // 
            this.toolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar1.Location = new System.Drawing.Point(0, 0);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(584, 150);
            this.toolbar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 341);
            this.panel1.TabIndex = 1;
            // 
            // Toolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 491);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolbar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toolbar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Toolbar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.Toolbar toolbar1;
        private System.Windows.Forms.Panel panel1;
    }
}