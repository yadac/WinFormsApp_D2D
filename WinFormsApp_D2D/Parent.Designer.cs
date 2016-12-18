using System;
using Microsoft.WindowsAPICodePack.DirectX.Graphics;

namespace WinFormsApp_D2D
{
    partial class Parent
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.apHeader1 = new CommonControl.APHeader();
            this.SuspendLayout();
            // 
            // apHeader1
            // 
            this.apHeader1.BackColor = System.Drawing.Color.SteelBlue;
            this.apHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.apHeader1.Location = new System.Drawing.Point(0, 0);
            this.apHeader1.Name = "apHeader1";
            this.apHeader1.Size = new System.Drawing.Size(1012, 83);
            this.apHeader1.TabIndex = 0;
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 411);
            this.ControlBox = false;
            this.Controls.Add(this.apHeader1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Parent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Parent_Load);
            this.ResumeLayout(false);

        }

        public static implicit operator Device(Parent v)
        {
            throw new NotImplementedException();
        }

        #endregion

        private CommonControl.APHeader apHeader1;
    }
}

