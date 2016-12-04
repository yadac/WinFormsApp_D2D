using System;
using System.Windows.Forms;

namespace WinFormsApp_D2D
{
    public partial class Parent : Form
    {
        private Child child;
        /// <summary>
        /// 初期化処理
        /// </summary>
        public Parent()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // this.ControlBox = false;
            // this.Text = "";
        }

        private void Parent_Load(object sender, System.EventArgs e)
        {
            try
            {
                child = new Child { MdiParent = this };
                child.Show();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            // this.WindowState = FormWindowState.Maximized;
        }

        private void Parent_Resize(object sender, EventArgs e)
        {
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            if (child != null)
            {
                this.child.WindowState = FormWindowState.Maximized;
            }
                
        }
    }
}
