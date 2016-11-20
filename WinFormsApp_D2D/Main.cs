using System;
using System.Windows.Forms;

namespace WinFormsApp_D2D
{
    public partial class Main : Form
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            try
            {
                Situation situation = new Situation();
                situation.MdiParent = this;
                situation.Show();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
