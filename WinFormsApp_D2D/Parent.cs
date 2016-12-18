using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp_D2D
{
    public partial class Parent : Form
    {
        private Toolbar t1, t2;
        private int t1c, t2c;
        /// <summary>
        /// 初期化処理
        /// </summary>
        public Parent()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }

        private void Parent_Load(object sender, System.EventArgs e)
        {
            apHeader1.Button1Click += ShowOneSituation;
            apHeader1.Button2Click += ShowTwoSituation;

            try
            {
                ShowOneSituation();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void ShowOneSituation()
        {
            apHeader1.Label1 = t1c++.ToString();
            try
            {
                t1?.Close();
                t1 = new Toolbar();
                t1.TopLevel = false;
                this.Controls.Add(t1);
                t1.Height = this.Height - apHeader1.Height;
                t1.Width = this.Width;
                t1.Location = new Point(this.Location.X, this.Location.Y + apHeader1.Height);
                t1.Show();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
        }


        public void ShowTwoSituation()
        {
            try
            {
                t1?.Close();
                t2?.Close();

                apHeader1.Label1 = t1c++.ToString();
                t1 = new Toolbar
                {
                    TopLevel = false,
                    Height = this.Height - apHeader1.Height,
                    Width = this.Width / 2,
                    Location = new Point(0, 0 + apHeader1.Height),
                };
                this.Controls.Add(t1);
                t1.Dock = DockStyle.Left;
                t1.BringToFront();
                t1.Show();

                apHeader1.Label2 = t2c++.ToString();
                t2 = new Toolbar
                {
                    TopLevel = false,
                    Height = this.Height - apHeader1.Height,
                    Width = this.Width / 2,
                    Location = new Point(0 + apHeader1.Width, 0 + apHeader1.Height),
                };
                this.Controls.Add(t2);
                t2.Dock = DockStyle.Right;
                t2.BringToFront();
                t2.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                System.Console.WriteLine(ex.Message);
                throw;
            }

        }

    }
}
